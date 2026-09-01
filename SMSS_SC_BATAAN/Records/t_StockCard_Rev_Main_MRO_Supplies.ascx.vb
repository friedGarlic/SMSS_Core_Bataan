Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_t_StockCard_Rev_Main_MRO_Supplies
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
            BindMROStockList()
            BindEmptyMROIncomingDeliveries()
            BindEmptyMROLedger()
            ClearMROInventoryCard()
        End If
    End Sub

    Public Sub RefreshGridData()
        BindMROStockList()
        BindEmptyMROIncomingDeliveries()
        BindEmptyMROLedger()
        ClearMROInventoryCard()
    End Sub

    Private Sub BindMROStockList()
        Dim classId As String = If(TryCast(Session("ClassificationID"), String), "0")
        Dim subClassId As String = If(TryCast(Session("SubClassificationID"), String), "0")
        Dim gaId As String = If(TryCast(Session("GA_ID"), String), "0")

        If String.IsNullOrWhiteSpace(classId) Then classId = "0"
        If String.IsNullOrWhiteSpace(subClassId) Then subClassId = "0"
        If String.IsNullOrWhiteSpace(gaId) Then gaId = "0"

        If gaId = "0" AndAlso subClassId = "0" AndAlso classId = "0" Then
            BindEmptyMROStockList()
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
            grdMROStockList.DataSource = dt
            grdMROStockList.DataBind()
        Else
            BindEmptyMROStockList()
        End If
    End Sub

    Private Sub BindEmptyMROStockList()
        Dim dt As DataTable = CreateMROStockListSchema()
        dt = AddEmptyRows(dt, 4)
        grdMROStockList.DataSource = dt
        grdMROStockList.DataBind()
    End Sub

    Private Sub BindEmptyMROIncomingDeliveries()
        Dim dt As DataTable = CreateMROIncomingDeliveriesSchema()
        dt = AddEmptyRows(dt, 4)

        ' Include Stock_ID only in DataKeyNames
        grdMROIncomingDeliveries.DataKeyNames = New String() {"Stock_ID"}
        grdMROIncomingDeliveries.DataSource = dt
        grdMROIncomingDeliveries.DataBind()
    End Sub

    Private Sub BindEmptyMROLedger()
        Dim dt As DataTable = CreateMROLedgerSchema()
        dt = AddEmptyRows(dt, 4)
        grdMROLedger.DataSource = dt
        grdMROLedger.DataBind()
    End Sub

    Private Function CreateMROStockListSchema() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Stock_ID", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Balance", GetType(String))
        dt.Columns.Add("ReorderPT", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        Return dt
    End Function

    Private Function CreateMROIncomingDeliveriesSchema() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Stock_ID", GetType(String))      ' This is actually POHdr_ID from stored proc
        dt.Columns.Add("POHdr_ID", GetType(String))      ' Explicit POHdr_ID column
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

    Private Function CreateMROLedgerSchema() As DataTable
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

    Protected Sub grdMROStockList_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdMROStockList.PageIndex = e.NewPageIndex
        BindMROStockList()
    End Sub

    Protected Sub grdMROStockList_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("style") = "cursor:pointer;"
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdMROStockList, "Select$" & e.Row.RowIndex, True)
        End If
    End Sub

    ' Now accepts Item_ID instead of POHdr_ID
    Private Sub BindMROIncomingDeliveries(ByVal itemId As Long)
        Dim dt As DataTable = Nothing
        Try
            AddTrace("Item_ID: " & itemId)
            Dim sql As String = "EXEC [AMS].[sp_StockCard_Rev_IncomingDeliveries] @Item_ID = " & itemId
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdMROIncomingDeliveries.DataSource = dt
            grdMROIncomingDeliveries.DataBind()
        Else
            BindEmptyMROIncomingDeliveries()
        End If
    End Sub

    Protected Sub grdMROIncomingDeliveries_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdMROIncomingDeliveries.PageIndex = e.NewPageIndex

        ' Now retrieving Item_ID from ViewState
        Dim itemId As Long = 0
        If ViewState("SelectedMROItemID") IsNot Nothing Then
            Long.TryParse(ViewState("SelectedMROItemID").ToString(), itemId)
        End If

        AddTrace("Item_ID from ViewState: " & itemId)

        If itemId > 0 Then
            BindMROIncomingDeliveries(itemId)
        Else
            BindEmptyMROIncomingDeliveries()
        End If
    End Sub

    Protected Sub grdMROIncomingDeliveries_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        ' Intentionally left empty - grid is display-only with no click functionality
    End Sub

    Protected Sub btnViewMROStockInventoryReport_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim script As String = "window.open('/Records/rpt_stockcardinventory.aspx', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OpenReport", script, True)
    End Sub

    Private Sub BindMROLedger(ByVal itemId As Long)
        Dim dt As DataTable = Nothing
        Try
            Dim sql As String = "EXEC [AMS].[sp_SuppliesLedger] @Item_ID=" & itemId
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdMROLedger.DataSource = dt
            grdMROLedger.DataBind()
        Else
            BindEmptyMROLedger()
        End If
    End Sub

    Protected Sub grdMROStockList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim stockId As Long = 0
        Dim itemId As Long = 0

        ' Add trace for debugging
        If grdMROStockList.SelectedDataKey IsNot Nothing Then
            If grdMROStockList.SelectedDataKey.Values("Item_ID") IsNot Nothing Then
                AddTrace("Item_ID: " & grdMROStockList.SelectedDataKey.Values("Item_ID").ToString())
            End If
            If grdMROStockList.SelectedDataKey.Values("Stock_ID") IsNot Nothing Then
                AddTrace("Stock_ID: " & grdMROStockList.SelectedDataKey.Values("Stock_ID").ToString())
            End If
        End If

        If grdMROStockList.SelectedDataKey IsNot Nothing Then
            If grdMROStockList.SelectedDataKey.Values("Stock_ID") IsNot Nothing Then
                Long.TryParse(grdMROStockList.SelectedDataKey.Values("Stock_ID").ToString(), stockId)
            End If
            If grdMROStockList.SelectedDataKey.Values("Item_ID") IsNot Nothing Then
                Long.TryParse(grdMROStockList.SelectedDataKey.Values("Item_ID").ToString(), itemId)
            End If
        End If

        ViewState("SelectedMROStockID") = stockId
        ViewState("SelectedMROItemID") = itemId

        AddTrace("Selected StockID: " & stockId)
        AddTrace("Selected Item_ID: " & itemId)

        ' Incoming Deliveries - NOW USING Item_ID
        If itemId > 0 Then
            BindMROIncomingDeliveries(itemId)
        Else
            BindEmptyMROIncomingDeliveries()
        End If

        If stockId > 0 Then
            PopulateMROInventoryCard(stockId)
        Else
            ClearMROInventoryCard()
        End If

        If itemId > 0 Then
            BindMROLedger(itemId)
        Else
            BindEmptyMROLedger()
        End If
    End Sub

    Private Sub PopulateMROInventoryCard(ByVal stockId As Long)
        If stockId <= 0 Then
            ClearMROInventoryCard()
            Exit Sub
        End If

        Dim dt As DataTable = Nothing
        AddTrace("stockId: " & stockId)

        Try
            dt = objDerived.GetDataTable("EXEC AMS.sp_Encoding_Supplies " & stockId, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearMROInventoryCard()
            Exit Sub
        End If

        Dim r As DataRow = dt.Rows(0)

        lblMROName.Text = Convert.ToString(r("Description"))

        Dim Unit As String = Convert.ToString(r("Unit_ID"))

        Dim dtUnit As DataTable = objDerived.GetDataTable("SELECT Description FROM AMS.m_Unit WHERE Unit_ID = " & Unit, CommandType.Text)

        If dtUnit IsNot Nothing AndAlso dtUnit.Rows.Count > 0 Then
            lblMROUnit.Text = Convert.ToString(dtUnit.Rows(0)("Description"))
        Else
            lblMROUnit.Text = String.Empty
        End If

        lblMROBrandName.Text = Convert.ToString(r("BrandName"))
        lblMROLength.Text = Convert.ToString(r("Length"))
        lblMROSize.Text = Convert.ToString(r("Size"))
        lblMROWidth.Text = Convert.ToString(r("Width"))
        lblMROColor.Text = Convert.ToString(r("Color"))
        lblMROWeight.Text = Convert.ToString(r("Weight"))
        lblMROComponentOf.Text = Convert.ToString(r("ComponentOf"))
        lblMROHeight.Text = Convert.ToString(r("Height"))

        lblMROUnitPrice.Text = Convert.ToString(r("UnitCost"))
        lblMROQuantity.Text = Convert.ToString(r("Quantity"))
        lblMROReorderPt.Text = Convert.ToString(r("ReorderPoint"))
        lblMRODate.Text = Convert.ToString(r("Date"))

        Dim whName As String = Convert.ToString(r("Warehouse")).Trim()
        If drpMROWarehouse.Items.Count > 0 AndAlso whName <> "" Then
            Dim it As ListItem = drpMROWarehouse.Items.FindByText(whName)
            If it IsNot Nothing Then
                drpMROWarehouse.ClearSelection()
                it.Selected = True
            Else
                drpMROWarehouse.SelectedIndex = 0
            End If
        ElseIf drpMROWarehouse.Items.Count > 0 Then
            drpMROWarehouse.SelectedIndex = 0
        End If

        txtMROBay.Text = Convert.ToString(r("Bay"))
        txtMROColumn.Text = Convert.ToString(r("Column"))
        txtMROFloor.Text = Convert.ToString(r("Floor"))
        txtMRORoom.Text = Convert.ToString(r("Room"))
        txtMROShelves.Text = Convert.ToString(r("Shelves"))
        txtMRORack.Text = Convert.ToString(r("Rack"))
        txtMROBin.Text = Convert.ToString(r("Bin"))
    End Sub

    Private Sub ClearMROInventoryCard()
        lblMROName.Text = ""
        lblMROUnit.Text = ""

        lblMROBrandName.Text = ""
        lblMROLength.Text = ""
        lblMROSize.Text = ""
        lblMROWidth.Text = ""
        lblMROColor.Text = ""
        lblMROWeight.Text = ""
        lblMROComponentOf.Text = ""
        lblMROHeight.Text = ""

        lblMROUnitPrice.Text = ""
        lblMROQuantity.Text = ""
        lblMROReorderPt.Text = ""
        lblMRODate.Text = ""

        If drpMROWarehouse.Items.Count > 0 Then
            drpMROWarehouse.SelectedIndex = 0
        End If

        txtMROBay.Text = ""
        txtMROColumn.Text = ""
        txtMROFloor.Text = ""
        txtMRORoom.Text = ""
        txtMROShelves.Text = ""
        txtMRORack.Text = ""
        txtMROBin.Text = ""
    End Sub

End Class