Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_t_StockCard_Rev_Main_Food
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
            BindFoodStockList()
            BindEmptyFoodIncomingDeliveries()
            ClearFoodInventoryCard()
            BindEmptyFoodLedger()
        End If
    End Sub

    Public Sub RefreshGridData()
        BindFoodStockList()
        BindEmptyFoodIncomingDeliveries()
        ClearFoodInventoryCard()
        BindEmptyFoodLedger()
    End Sub

    Private Sub BindFoodStockList()
        Dim classId As String = If(TryCast(Session("ClassificationID"), String), "0")
        Dim subClassId As String = If(TryCast(Session("SubClassificationID"), String), "0")
        Dim gaId As String = If(TryCast(Session("GA_ID"), String), "0")

        If String.IsNullOrWhiteSpace(classId) Then classId = "0"
        If String.IsNullOrWhiteSpace(subClassId) Then subClassId = "0"
        If String.IsNullOrWhiteSpace(gaId) Then gaId = "0"

        If gaId = "0" AndAlso subClassId = "0" AndAlso classId = "0" Then
            BindEmptyFoodStockList()
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
            grdFoodStockList.DataSource = dt
            grdFoodStockList.DataBind()
        Else
            BindEmptyFoodStockList()
        End If
    End Sub

    Private Sub BindEmptyFoodStockList()
        Dim dt As DataTable = CreateFoodStockListSchema()
        dt = AddEmptyRows(dt, 4)
        grdFoodStockList.DataSource = dt
        grdFoodStockList.DataBind()
    End Sub

    Private Sub BindEmptyFoodIncomingDeliveries()
        Dim dt As DataTable = CreateFoodIncomingDeliveriesSchema()
        dt = AddEmptyRows(dt, 4)

        ' Include Stock_ID only in DataKeyNames
        grdFoodIncomingDeliveries.DataKeyNames = New String() {"Stock_ID"}
        grdFoodIncomingDeliveries.DataSource = dt
        grdFoodIncomingDeliveries.DataBind()
    End Sub

    Private Sub BindEmptyFoodLedger()
        Dim dt As DataTable = CreateFoodLedgerSchema()
        dt = AddEmptyRows(dt, 4)
        grdFoodLedger.DataSource = dt
        grdFoodLedger.DataBind()
    End Sub

    Private Function CreateFoodStockListSchema() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Stock_ID", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Balance", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        Return dt
    End Function

    Private Function CreateFoodIncomingDeliveriesSchema() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Stock_ID", GetType(String))      ' This is actually POHdr_ID from stored proc (legacy comment)
        dt.Columns.Add("POHdr_ID", GetType(String))      ' kept as column since stored proc returns it
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

    Private Function CreateFoodLedgerSchema() As DataTable
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

    Protected Sub grdFoodStockList_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdFoodStockList.PageIndex = e.NewPageIndex
        BindFoodStockList()
    End Sub

    Protected Sub grdFoodStockList_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("style") = "cursor:pointer;"
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdFoodStockList, "Select$" & e.Row.RowIndex, True)
        End If
    End Sub

    Protected Sub grdFoodStockList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim stockId As Long = 0
        Dim itemId As Long = 0

        ' Add trace for debugging
        If grdFoodStockList.SelectedDataKey IsNot Nothing Then
            If grdFoodStockList.SelectedDataKey.Values("Item_ID") IsNot Nothing Then
                AddTrace("Item_ID: " & grdFoodStockList.SelectedDataKey.Values("Item_ID").ToString())
            End If
            If grdFoodStockList.SelectedDataKey.Values("Stock_ID") IsNot Nothing Then
                AddTrace("Stock_ID: " & grdFoodStockList.SelectedDataKey.Values("Stock_ID").ToString())
            End If
        End If

        If grdFoodStockList.SelectedDataKey IsNot Nothing Then
            If grdFoodStockList.SelectedDataKey.Values("Stock_ID") IsNot Nothing Then
                Long.TryParse(grdFoodStockList.SelectedDataKey.Values("Stock_ID").ToString(), stockId)
            End If
            If grdFoodStockList.SelectedDataKey.Values("Item_ID") IsNot Nothing Then
                Long.TryParse(grdFoodStockList.SelectedDataKey.Values("Item_ID").ToString(), itemId)
            End If
        End If

        ViewState("SelectedFoodStockID") = stockId
        ViewState("SelectedFoodItemID") = itemId

        ' Incoming Deliveries - NOW USING Item_ID (matches updated stored proc)
        If itemId > 0 Then
            BindFoodIncomingDeliveries(itemId)
        Else
            BindEmptyFoodIncomingDeliveries()
        End If

        ' Inventory Card - uses StockID (correct)
        If stockId > 0 Then
            PopulateFoodInventoryCard(stockId)
        Else
            ClearFoodInventoryCard()
        End If

        ' Ledger - uses Item_ID (correct)
        If itemId > 0 Then
            BindFoodLedger(itemId)
        Else
            BindEmptyFoodLedger()
        End If
    End Sub

    ' Now accepts Item_ID instead of POHdr_ID
    Private Sub BindFoodIncomingDeliveries(ByVal itemId As Long)
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
            grdFoodIncomingDeliveries.DataSource = dt
            grdFoodIncomingDeliveries.DataBind()
        Else
            BindEmptyFoodIncomingDeliveries()
        End If
    End Sub

    Protected Sub grdFoodIncomingDeliveries_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdFoodIncomingDeliveries.PageIndex = e.NewPageIndex

        ' Now retrieving Item_ID from ViewState
        Dim itemId As Long = 0
        If ViewState("SelectedFoodItemID") IsNot Nothing Then
            Long.TryParse(ViewState("SelectedFoodItemID").ToString(), itemId)
        End If

        If itemId > 0 Then
            BindFoodIncomingDeliveries(itemId)
        Else
            BindEmptyFoodIncomingDeliveries()
        End If
    End Sub

    Protected Sub btnViewFoodStockInventoryReport_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim script As String = "window.open('/Records/rpt_stockcardinventory.aspx', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OpenReport", script, True)
    End Sub

    Protected Sub grdFoodIncomingDeliveries_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        ' Intentionally left empty - grid is display-only with no click functionality
    End Sub

    Private Sub PopulateFoodInventoryCard(ByVal stockId As Long)
        If stockId <= 0 Then
            ClearFoodInventoryCard()
            Exit Sub
        End If

        AddTrace("stockId: " & stockId)
        Dim dt As DataTable = Nothing
        Try
            dt = objDerived.GetDataTable("EXEC AMS.sp_Encoding_Food " & stockId, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearFoodInventoryCard()
            Exit Sub
        End If

        Dim r As DataRow = dt.Rows(0)

        Dim GetStr As Func(Of String, String) =
        Function(col As String)
            If Not dt.Columns.Contains(col) OrElse IsDBNull(r(col)) Then Return ""
            Return Convert.ToString(r(col)).Trim()
        End Function

        lblFoodName.Text = GetStr("ItemCompleteDesc")
        lblFoodBrandName.Text = GetStr("BrandName")
        lblFoodSize.Text = GetStr("Size")
        lblFoodColor.Text = GetStr("Color")

        lblFoodLength.Text = GetStr("Length")
        lblFoodWidth.Text = GetStr("Width")
        lblFoodHeight.Text = GetStr("Height")
        lblFoodWeight.Text = GetStr("Weight")

        lblFoodComponentof.Text = GetStr("ComponentOf")
        lblFoodUnitPrice.Text = GetStr("UnitCost")
        lblFoodQuantity.Text = GetStr("Quantity")

        lblFoodDepRate.Text = GetStr("DepRate")
        lblFoodDepValue.Text = GetStr("DepValue")

        Dim whName As String = GetStr("Warehouse").Trim()
        If drpFoodWarehouse.Items.Count > 0 AndAlso whName <> "" Then
            Dim it As ListItem = drpFoodWarehouse.Items.FindByText(whName)
            If it IsNot Nothing Then
                drpFoodWarehouse.ClearSelection()
                it.Selected = True
            Else
                drpFoodWarehouse.SelectedIndex = 0
            End If
        ElseIf drpFoodWarehouse.Items.Count > 0 Then
            drpFoodWarehouse.SelectedIndex = 0
        End If

        txtFoodBay.Text = GetStr("Bay")
        txtFoodColumn.Text = GetStr("Column")
        txtFoodFloor.Text = GetStr("Floor")
        txtFoodRoom.Text = GetStr("Room")
        txtFoodShelves.Text = GetStr("Shelves")
        txtFoodRack.Text = GetStr("Rack")
        txtFoodBin.Text = GetStr("Bin")
    End Sub

    Private Sub ClearFoodInventoryCard()
        lblFoodName.Text = ""
        lblFoodLength.Text = ""
        lblFoodBrandName.Text = ""
        lblFoodWidth.Text = ""
        lblFoodSize.Text = ""
        lblFoodWeight.Text = ""
        lblFoodColor.Text = ""
        lblFoodHeight.Text = ""
        lblFoodComponentof.Text = ""
        lblFoodUnitPrice.Text = ""
        lblFoodDepRate.Text = ""
        lblFoodQuantity.Text = ""
        lblFoodDepValue.Text = ""

        If drpFoodWarehouse.Items.Count > 0 Then
            drpFoodWarehouse.SelectedIndex = 0
        End If

        txtFoodBay.Text = ""
        txtFoodColumn.Text = ""
        txtFoodFloor.Text = ""
        txtFoodRoom.Text = ""
        txtFoodShelves.Text = ""
        txtFoodRack.Text = ""
        txtFoodBin.Text = ""
    End Sub

    Private Sub BindFoodLedger(ByVal itemId As Long)
        Dim dt As DataTable = Nothing
        Try
            Dim sql As String = "EXEC [AMS].[sp_SuppliesLedger] @Item_ID=" & itemId
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdFoodLedger.DataSource = dt
            grdFoodLedger.DataBind()
        Else
            BindEmptyFoodLedger()
        End If
    End Sub

End Class