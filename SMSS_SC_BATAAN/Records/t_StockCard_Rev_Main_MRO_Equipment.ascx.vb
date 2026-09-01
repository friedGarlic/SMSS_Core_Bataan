Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_t_StockCard_Rev_Main_MRO_Equipment
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
            BindMROEquipmentStockList()
            BindEmptyMROEquipmentIncomingDeliveries()
            BindEmptyMROEquipmentLedger()
            ClearMROEquipmentInventoryCard()
        End If
    End Sub

    Public Sub RefreshGridData()
        BindMROEquipmentStockList()
        BindEmptyMROEquipmentIncomingDeliveries()
        BindEmptyMROEquipmentLedger()
        ClearMROEquipmentInventoryCard()
    End Sub

    Private Sub BindMROEquipmentStockList()
        Dim classId As String = If(TryCast(Session("ClassificationID"), String), "0")
        Dim subClassId As String = If(TryCast(Session("SubClassificationID"), String), "0")
        Dim gaId As String = If(TryCast(Session("GA_ID"), String), "0")

        If String.IsNullOrWhiteSpace(classId) Then classId = "0"
        If String.IsNullOrWhiteSpace(subClassId) Then subClassId = "0"
        If String.IsNullOrWhiteSpace(gaId) Then gaId = "0"

        If gaId = "0" AndAlso subClassId = "0" AndAlso classId = "0" Then
            BindEmptyMROEquipmentStockList()
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
            grdMROEquipmentStockList.DataSource = dt
            grdMROEquipmentStockList.DataBind()
        Else
            BindEmptyMROEquipmentStockList()
        End If
    End Sub

    Private Sub BindEmptyMROEquipmentStockList()
        Dim dt As DataTable = CreateMROEquipmentStockListSchema()
        dt = AddEmptyRows(dt, 4)
        grdMROEquipmentStockList.DataSource = dt
        grdMROEquipmentStockList.DataBind()
    End Sub

    Private Sub BindEmptyMROEquipmentIncomingDeliveries()
        Dim dt As DataTable = CreateMROEquipmentIncomingDeliveriesSchema()
        dt = AddEmptyRows(dt, 4)

        ' Include Stock_ID only in DataKeyNames
        grdMROEquipmentIncomingDeliveries.DataKeyNames = New String() {"Stock_ID"}
        grdMROEquipmentIncomingDeliveries.DataSource = dt
        grdMROEquipmentIncomingDeliveries.DataBind()
    End Sub

    Private Sub BindEmptyMROEquipmentLedger()
        Dim dt As DataTable = CreateMROEquipmentLedgerSchema()
        dt = AddEmptyRows(dt, 4)
        grdMROEquipmentLedger.DataSource = dt
        grdMROEquipmentLedger.DataBind()
    End Sub

    Private Function CreateMROEquipmentStockListSchema() As DataTable
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

    Private Function CreateMROEquipmentIncomingDeliveriesSchema() As DataTable
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

    Private Function CreateMROEquipmentLedgerSchema() As DataTable
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

    Protected Sub grdMROEquipmentStockList_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdMROEquipmentStockList.PageIndex = e.NewPageIndex
        BindMROEquipmentStockList()
    End Sub

    Protected Sub grdMROEquipmentStockList_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("style") = "cursor:pointer;"
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdMROEquipmentStockList, "Select$" & e.Row.RowIndex, True)
        End If
    End Sub

    ' Now accepts Item_ID instead of POHdr_ID
    Private Sub BindMROEquipmentIncomingDeliveries(ByVal itemId As Long)
        Dim dt As DataTable = Nothing
        Try
            AddTrace("Item_ID: " & itemId)
            Dim sql As String = "EXEC [AMS].[sp_StockCard_Rev_IncomingDeliveries] @Item_ID = " & itemId
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdMROEquipmentIncomingDeliveries.DataSource = dt
            grdMROEquipmentIncomingDeliveries.DataBind()
        Else
            BindEmptyMROEquipmentIncomingDeliveries()
        End If
    End Sub

    Protected Sub grdMROEquipmentIncomingDeliveries_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdMROEquipmentIncomingDeliveries.PageIndex = e.NewPageIndex

        ' Now retrieving Item_ID from ViewState
        Dim itemId As Long = 0
        If ViewState("SelectedMROEquipmentItemID") IsNot Nothing Then
            Long.TryParse(ViewState("SelectedMROEquipmentItemID").ToString(), itemId)
        End If

        If itemId > 0 Then
            BindMROEquipmentIncomingDeliveries(itemId)
        Else
            BindEmptyMROEquipmentIncomingDeliveries()
        End If
    End Sub

    Protected Sub grdMROEquipmentIncomingDeliveries_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        ' Intentionally left empty - grid is display-only with no click functionality
    End Sub

    Protected Sub btnViewMROEquipmentStockInventoryReport_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim script As String = "window.open('/Records/rpt_stockcardinventory.aspx', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OpenReport", script, True)
    End Sub

    Private Sub BindMROEquipmentLedger(ByVal itemId As Long)
        Dim dt As DataTable = Nothing
        Try
            Dim sql As String = "EXEC [AMS].[sp_SuppliesLedger] @Item_ID=" & itemId
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdMROEquipmentLedger.DataSource = dt
            grdMROEquipmentLedger.DataBind()
        Else
            BindEmptyMROEquipmentLedger()
        End If
    End Sub

    Protected Sub grdMROEquipmentStockList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim stockId As Long = 0
        Dim itemId As Long = 0

        ' Add trace for debugging
        If grdMROEquipmentStockList.SelectedDataKey IsNot Nothing Then
            If grdMROEquipmentStockList.SelectedDataKey.Values("Item_ID") IsNot Nothing Then
                AddTrace("Item_ID: " & grdMROEquipmentStockList.SelectedDataKey.Values("Item_ID").ToString())
            End If
            If grdMROEquipmentStockList.SelectedDataKey.Values("Stock_ID") IsNot Nothing Then
                AddTrace("Stock_ID: " & grdMROEquipmentStockList.SelectedDataKey.Values("Stock_ID").ToString())
            End If
        End If

        If grdMROEquipmentStockList.SelectedDataKey IsNot Nothing Then
            If grdMROEquipmentStockList.SelectedDataKey.Values("Stock_ID") IsNot Nothing Then
                Long.TryParse(grdMROEquipmentStockList.SelectedDataKey.Values("Stock_ID").ToString(), stockId)
            End If
            If grdMROEquipmentStockList.SelectedDataKey.Values("Item_ID") IsNot Nothing Then
                Long.TryParse(grdMROEquipmentStockList.SelectedDataKey.Values("Item_ID").ToString(), itemId)
            End If
        End If

        ViewState("SelectedMROEquipmentStockID") = stockId
        ViewState("SelectedMROEquipmentItemID") = itemId

        AddTrace("Selected StockID: " & stockId)
        AddTrace("Selected Item_ID: " & itemId)

        ' Incoming Deliveries - NOW USING Item_ID (matches updated stored proc)
        If itemId > 0 Then
            BindMROEquipmentIncomingDeliveries(itemId)
        Else
            BindEmptyMROEquipmentIncomingDeliveries()
        End If

        If stockId > 0 Then
            PopulateMROEquipmentInventoryCard(stockId)
        Else
            ClearMROEquipmentInventoryCard()
        End If

        If itemId > 0 Then
            BindMROEquipmentLedger(itemId)
        Else
            BindEmptyMROEquipmentLedger()
        End If
    End Sub

    Private Sub PopulateMROEquipmentInventoryCard(ByVal stockId As Long)
        If stockId <= 0 Then
            ClearMROEquipmentInventoryCard()
            Exit Sub
        End If

        Dim dt As DataTable = Nothing
        Try
            dt = objDerived.GetDataTable("EXEC AMS.sp_Encoding_Supplies " & stockId, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearMROEquipmentInventoryCard()
            Exit Sub
        End If

        Dim r As DataRow = dt.Rows(0)

        lblMROEquipmentName.Text = Convert.ToString(r("Description"))

        Dim Unit As String = Convert.ToString(r("NonFoodUnit"))
        Dim dtUnit As DataTable = objDerived.GetDataTable("SELECT Description FROM AMS.m_Unit WHERE Unit_ID = " & Unit, CommandType.Text)

        If dtUnit IsNot Nothing AndAlso dtUnit.Rows.Count > 0 Then
            lblMROEquipmentUnit.Text = Convert.ToString(dtUnit.Rows(0)("Description"))
        Else
            lblMROEquipmentUnit.Text = String.Empty
        End If

        lblMROEquipmentDescription.Text = Convert.ToString(r("NonFoodEquipmentDescription"))
        lblMROEquipmentDimension.Text = Convert.ToString(r("NonFoodDimension"))
        lblMROEquipmentPowerInput.Text = Convert.ToString(r("NonFoodPowerInput"))
        lblMROEquipmentAreaCapacity.Text = Convert.ToString(r("NonFoodAreaCapacity"))
        lblMROEquipmentModel.Text = Convert.ToString(r("NonFoodModel"))
        lblMROEquipmentWarranty.Text = Convert.ToString(r("NonFoodWarranty"))
        lblMROEquipmentReorderPt.Text = Convert.ToString(r("ReorderPoint"))

        Dim acqStr As String = Convert.ToString(r("Date"))
        Dim acqVal As DateTime
        If DateTime.TryParse(acqStr, acqVal) Then
            lblMROEquipmentAcquisitionDate.Text = acqVal.ToString("MM/dd/yyyy")
        Else
            lblMROEquipmentAcquisitionDate.Text = acqStr
        End If

        lblMROEquipmentMarketValue.Text = Convert.ToString(r("NonFoodMarketValue"))
        lblMROEquipmentAcquisitionCost.Text = Convert.ToString(r("UnitCost"))
        lblMROEquipmentNoOfYears.Text = Convert.ToString(r("NonFoodNoYears"))
        lblMROEquipmentDepreciatedRate.Text = Convert.ToString(r("NonFoodDepreciationRate"))
        lblMROEquipmentUsefulLife.Text = Convert.ToString(r("NonFoodUsefulLife"))
        lblMROEquipmentDepreciatedValue.Text = Convert.ToString(r("NonFoodDepreciationValue"))
        lblMROEquipmentSalvageValue.Text = Convert.ToString(r("NonFoodSalvageValue"))
        lblMROEquipmentDepreciationValue.Text = Convert.ToString(r("NonFoodDepreciationValuePerYear"))
        lblMROEquipmentQuantity.Text = Convert.ToString(r("Quantity"))

        Dim whName As String = Convert.ToString(r("Warehouse")).Trim()
        If drpMROEquipmentWarehouse.Items.Count > 0 AndAlso whName <> "" Then
            Dim it As ListItem = drpMROEquipmentWarehouse.Items.FindByText(whName)
            If it IsNot Nothing Then
                drpMROEquipmentWarehouse.ClearSelection()
                it.Selected = True
            Else
                drpMROEquipmentWarehouse.SelectedIndex = 0
            End If
        ElseIf drpMROEquipmentWarehouse.Items.Count > 0 Then
            drpMROEquipmentWarehouse.SelectedIndex = 0
        End If

        txtMROEquipmentBay.Text = Convert.ToString(r("Bay"))
        txtMROEquipmentColumn.Text = Convert.ToString(r("Column"))
        txtMROEquipmentFloor.Text = Convert.ToString(r("Floor"))
        txtMROEquipmentRoom.Text = Convert.ToString(r("Room"))
        txtMROEquipmentShelves.Text = Convert.ToString(r("Shelves"))
        txtMROEquipmentRack.Text = Convert.ToString(r("Rack"))
        txtMROEquipmentBin.Text = Convert.ToString(r("Bin"))
    End Sub

    Private Sub ClearMROEquipmentInventoryCard()
        lblMROEquipmentName.Text = ""
        lblMROEquipmentUnit.Text = ""

        lblMROEquipmentDescription.Text = ""
        lblMROEquipmentDimension.Text = ""
        lblMROEquipmentPowerInput.Text = ""
        lblMROEquipmentAreaCapacity.Text = ""
        lblMROEquipmentModel.Text = ""
        lblMROEquipmentWarranty.Text = ""
        lblMROEquipmentReorderPt.Text = ""

        lblMROEquipmentAcquisitionDate.Text = ""
        lblMROEquipmentMarketValue.Text = ""
        lblMROEquipmentAcquisitionCost.Text = ""
        lblMROEquipmentNoOfYears.Text = ""
        lblMROEquipmentDepreciatedRate.Text = ""
        lblMROEquipmentUsefulLife.Text = ""
        lblMROEquipmentDepreciatedValue.Text = ""
        lblMROEquipmentSalvageValue.Text = ""
        lblMROEquipmentDepreciationValue.Text = ""
        lblMROEquipmentQuantity.Text = ""

        If drpMROEquipmentWarehouse.Items.Count > 0 Then
            drpMROEquipmentWarehouse.SelectedIndex = 0
        End If

        txtMROEquipmentBay.Text = ""
        txtMROEquipmentColumn.Text = ""
        txtMROEquipmentFloor.Text = ""
        txtMROEquipmentRoom.Text = ""
        txtMROEquipmentShelves.Text = ""
        txtMROEquipmentRack.Text = ""
        txtMROEquipmentBin.Text = ""
    End Sub

End Class