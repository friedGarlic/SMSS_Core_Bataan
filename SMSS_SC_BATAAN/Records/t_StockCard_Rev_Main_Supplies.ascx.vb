Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_t_StockCard_Rev_Main_Supplies
    Inherits System.Web.UI.UserControl

    Private objDerived As New DerivedDal
    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindStockList()
            BindEmptyIncomingDeliveries()
            BindEmptyLedger()
        End If
    End Sub

    Public Sub RefreshGridData()
        BindStockList()
        BindEmptyIncomingDeliveries()
        BindEmptyLedger()
    End Sub

    Private Sub BindStockList()
        Dim classId As String = If(TryCast(Session("ClassificationID"), String), "0")
        Dim subClassId As String = If(TryCast(Session("SubClassificationID"), String), "0")
        Dim gaId As String = If(TryCast(Session("GA_ID"), String), "0")

        If String.IsNullOrWhiteSpace(classId) Then classId = "0"
        If String.IsNullOrWhiteSpace(subClassId) Then subClassId = "0"
        If String.IsNullOrWhiteSpace(gaId) Then gaId = "0"

        If gaId = "0" AndAlso subClassId = "0" AndAlso classId = "0" Then
            BindEmptyStockList()
            Exit Sub
        End If

        Dim dt As DataTable = Nothing
        Try
            Dim sql As String = "EXEC [AMS].[sp_StockCard_Rev_ListOfSupplies] " &
                                "@ClassificationID=" & Session("ClassificationID") & ", " &
                                "@SubClassificationID=" & Session("SubClassificationID") & ", " &
                                "@GA_ID=" & Session("GA_ID")
            dt = objDerived.GetDataTable(sql, CommandType.Text)
            AddTrace("ClassificationID: " & Session("ClassificationID"))
            AddTrace("SubClassificationID: " & Session("SubClassificationID"))
            AddTrace("GA_ID: " & Session("GA_ID"))


        Catch ex As Exception
            dt = Nothing
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdStockList.DataSource = dt
            grdStockList.DataBind()
        Else
            BindEmptyStockList()
        End If
    End Sub

    Private Sub BindEmptyStockList()
        Dim dt As DataTable = CreateStockListSchema()
        dt = AddEmptyRows(dt, 4)
        grdStockList.DataSource = dt
        grdStockList.DataBind()
    End Sub

    Private Sub BindEmptyIncomingDeliveries()
        Dim dt As DataTable = CreateIncomingDeliveriesSchema()
        dt = AddEmptyRows(dt, 4)

        ' Include Stock_ID only in DataKeyNames
        grdIncomingDeliveries.DataKeyNames = New String() {"Stock_ID"}
        grdIncomingDeliveries.DataSource = dt
        grdIncomingDeliveries.DataBind()
    End Sub

    Private Sub BindEmptyLedger()
        Dim dt As DataTable = CreateLedgerSchema()
        dt = AddEmptyRows(dt, 4)
        grdLedger.DataSource = dt
        grdLedger.DataBind()
    End Sub

    Private Function CreateStockListSchema() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Stock_ID", GetType(String))
        dt.Columns.Add("Item_No", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Balance", GetType(String))
        dt.Columns.Add("Location", GetType(String))

        Return dt
    End Function

    Private Function CreateIncomingDeliveriesSchema() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Stock_ID", GetType(String))      ' This is actually POHdr_ID from stored proc
        dt.Columns.Add("POHdr_ID", GetType(String))      ' Explicit POHdr_ID column (kept as output column)
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Qty", GetType(String))
        dt.Columns.Add("TotalPcs", GetType(String))
        dt.Columns.Add("ActualPrice", GetType(String))
        dt.Columns.Add("DeliveryDate", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("GA_ID", GetType(String))
        dt.Columns.Add("Received_ID", GetType(String))
        dt.Columns.Add("AIR_HDR_ID", GetType(String))
        dt.Columns.Add("TableName", GetType(String))
        dt.Columns.Add("Supplier_ID", GetType(String))
        Return dt
    End Function

    Private Function CreateLedgerSchema() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("dDate", GetType(String))
        dt.Columns.Add("Trans_Type", GetType(String))
        dt.Columns.Add("BalanceUnit", GetType(String))
        dt.Columns.Add("Cost", GetType(String))
        dt.Columns.Add("DebitQty", GetType(String))
        dt.Columns.Add("DebitCost", GetType(String))
        dt.Columns.Add("CreditQty", GetType(String))
        dt.Columns.Add("CreditCost", GetType(String))
        dt.Columns.Add("BalQty", GetType(String))
        dt.Columns.Add("BalCost", GetType(String))
        Return dt
    End Function

    Private Function AddEmptyRows(ByVal dt As DataTable, ByVal rowCount As Integer) As DataTable
        For i As Integer = 1 To rowCount
            dt.Rows.Add(dt.NewRow())
        Next
        Return dt
    End Function

    Protected Sub grdStockList_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdStockList.PageIndex = e.NewPageIndex
        BindStockList()
    End Sub

    Protected Sub grdStockList_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("style") = "cursor:pointer;"
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdStockList, "Select$" & e.Row.RowIndex, True)
        End If
    End Sub

    ' Now accepts Item_ID instead of POHdr_ID
    Private Sub BindIncomingDeliveries(ByVal itemId As Long)
        Dim dt As DataTable = Nothing
        Try
            ' Now using @Item_ID parameter (matches stored proc)
            AddTrace("Item_ID: " & itemId)
            Dim sql As String = "EXEC [AMS].[sp_StockCard_Rev_IncomingDeliveries] @Item_ID = " & itemId
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdIncomingDeliveries.DataSource = dt
            grdIncomingDeliveries.DataBind()
        Else
            BindEmptyIncomingDeliveries()
        End If
    End Sub

    Protected Sub grdIncomingDeliveries_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdIncomingDeliveries.PageIndex = e.NewPageIndex

        ' Now retrieving Item_ID from ViewState
        Dim itemId As Long = 0
        If ViewState("SelectedItemID") IsNot Nothing Then
            Long.TryParse(ViewState("SelectedItemID").ToString(), itemId)
        End If

        If itemId > 0 Then
            BindIncomingDeliveries(itemId)
        Else
            BindEmptyIncomingDeliveries()
        End If
    End Sub

    Protected Sub btnViewStockInventoryReport_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim script As String = "window.open('/Records/rpt_stockcardinventory.aspx', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OpenReport", script, True)
    End Sub

    Protected Sub grdLedger_DataBound(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    '------------------------- INVENTORY CARD  ------------------------------------------------------------------------
    Private Sub PopulateSuppliesInventoryCard(ByVal stockId As Long)
        If stockId <= 0 Then
            ClearSuppliesInventoryCard()
            Exit Sub
        End If

        AddTrace("stockId: " & stockId)
        Dim dt As DataTable = Nothing
        Try
            dt = objDerived.GetDataTable("EXEC AMS.sp_Encoding_Supplies " & stockId, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearSuppliesInventoryCard()
            Exit Sub
        End If

        Dim r As DataRow = dt.Rows(0)

        lblMROsuppliesName.Text = Convert.ToString(r("Description"))

        Dim Unit As String = Convert.ToString(r("Unit_ID"))

        Dim dtUnit As DataTable = objDerived.GetDataTable("SELECT Description FROM AMS.m_Unit WHERE Unit_ID = " & Unit, CommandType.Text)

        If dtUnit IsNot Nothing AndAlso dtUnit.Rows.Count > 0 Then
            lblMROsuppliesUnit.Text = Convert.ToString(dtUnit.Rows(0)("Description"))
        Else
            lblMROsuppliesUnit.Text = String.Empty
        End If

        lblMROsuppliesBrandName.Text = Convert.ToString(r("BrandName"))
        lblMROsuppliesLength.Text = Convert.ToString(r("Length"))
        lblMROsuppliesSize.Text = Convert.ToString(r("Size"))
        lblMROsuppliesWidth.Text = Convert.ToString(r("Width"))
        lblMROsuppliesColor.Text = Convert.ToString(r("Color"))
        lblMROsuppliesHeight.Text = Convert.ToString(r("Height"))
        lblMROsuppliesWeight.Text = Convert.ToString(r("Weight"))

        lblMROsuppliesUnitPrice.Text = Convert.ToString(r("UnitCost"))
        lblMROsuppliesReorderPt.Text = Convert.ToString(r("ReorderPoint"))
        lblMROsuppliesQuantity.Text = Convert.ToString(r("Quantity"))
        lblMROsuppliesDate.Text = Convert.ToString(r("Date"))

        Dim whName As String = Convert.ToString(r("Warehouse")).Trim()
        If drpMROsuppliesWarehouse.Items.Count > 0 AndAlso whName <> "" Then
            Dim it As ListItem = drpMROsuppliesWarehouse.Items.FindByText(whName)
            If it IsNot Nothing Then
                drpMROsuppliesWarehouse.ClearSelection()
                it.Selected = True
            Else
                drpMROsuppliesWarehouse.SelectedIndex = 0
            End If
        ElseIf drpMROsuppliesWarehouse.Items.Count > 0 Then
            drpMROsuppliesWarehouse.SelectedIndex = 0
        End If

        txtMROsuppliesBay.Text = Convert.ToString(r("Bay"))
        txtMROsuppliesColumn.Text = Convert.ToString(r("Column"))
        txtMROsuppliesFloor.Text = Convert.ToString(r("Floor"))
        txtMROsuppliesRoom.Text = Convert.ToString(r("Room"))
        txtMROsuppliesShelves.Text = Convert.ToString(r("Shelves"))
        txtMROsuppliesRack.Text = Convert.ToString(r("Rack"))
        txtMROsuppliesBin.Text = Convert.ToString(r("Bin"))
    End Sub

    Private Sub ClearSuppliesInventoryCard()
        lblMROsuppliesName.Text = ""
        lblMROsuppliesUnit.Text = ""

        lblMROsuppliesBrandName.Text = ""
        lblMROsuppliesLength.Text = ""
        lblMROsuppliesSize.Text = ""
        lblMROsuppliesWidth.Text = ""
        lblMROsuppliesColor.Text = ""
        lblMROsuppliesHeight.Text = ""
        lblMROsuppliesWeight.Text = ""

        lblMROsuppliesUnitPrice.Text = ""
        lblMROsuppliesReorderPt.Text = ""
        lblMROsuppliesQuantity.Text = ""
        lblMROsuppliesDate.Text = ""

        If drpMROsuppliesWarehouse.Items.Count > 0 Then
            drpMROsuppliesWarehouse.SelectedIndex = 0
        End If

        txtMROsuppliesBay.Text = ""
        txtMROsuppliesColumn.Text = ""
        txtMROsuppliesFloor.Text = ""
        txtMROsuppliesRoom.Text = ""
        txtMROsuppliesShelves.Text = ""
        txtMROsuppliesRack.Text = ""
        txtMROsuppliesBin.Text = ""
    End Sub

    Protected Sub grdIncomingDeliveries_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        ' Intentionally left empty - grid is display-only with no click functionality
    End Sub

    '------------------------- GRID LEDGER ------------------------------------------------------------------------
    Private Sub BindLedger(ByVal itemId As Long)
        Dim dt As DataTable = Nothing

        Try
            Dim sql As String = "EXEC [AMS].[sp_SuppliesLedger] @Item_ID=" & itemId
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdLedger.DataSource = dt
            grdLedger.DataBind()
        Else
            BindEmptyLedger()
        End If
    End Sub

    Protected Sub grdStockList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim stockId As Long = 0
        Dim itemId As Long = 0

        AddTrace("Item_ID: " & grdStockList.SelectedDataKey.Values("Item_ID"))
        AddTrace("Stock_ID: " & grdStockList.SelectedDataKey.Values("Stock_ID"))

        If grdStockList.SelectedDataKey IsNot Nothing Then
            If grdStockList.SelectedDataKey.Values("Stock_ID") IsNot Nothing Then
                Long.TryParse(grdStockList.SelectedDataKey.Values("Stock_ID").ToString(), stockId)
            End If
            If grdStockList.SelectedDataKey.Values("Item_ID") IsNot Nothing Then
                Long.TryParse(grdStockList.SelectedDataKey.Values("Item_ID").ToString(), itemId)
            End If
        End If

        ViewState("SelectedStockID") = stockId
        ViewState("SelectedItemID") = itemId

        ' Incoming Deliveries - NOW USING Item_ID (matches updated stored proc)
        If itemId > 0 Then
            BindIncomingDeliveries(itemId)
        Else
            BindEmptyIncomingDeliveries()
        End If

        If stockId > 0 Then
            PopulateSuppliesInventoryCard(stockId)
        Else
            ClearSuppliesInventoryCard()
        End If

        If itemId > 0 Then
            BindLedger(itemId)
        Else
            BindEmptyLedger()
        End If
    End Sub

    Protected Sub grdLedger_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdLedger.PageIndex = e.NewPageIndex

        Dim itemId As Long = 0
        If ViewState("SelectedItemID") IsNot Nothing Then
            Long.TryParse(ViewState("SelectedItemID").ToString(), itemId)
        End If

        If itemId > 0 Then
            BindLedger(itemId)
        Else
            BindEmptyLedger()
        End If
    End Sub

End Class