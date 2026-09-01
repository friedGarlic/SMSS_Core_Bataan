Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_t_StockCard_Rev_Main_Medicine
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
            BindMedicineStockList()
            BindEmptyMedicineIncomingDeliveries()
            BindEmptyMedicineLedger()
            ClearMedicineInventoryCard()
        End If
    End Sub

    Public Sub RefreshGridData()
        BindMedicineStockList()
        BindEmptyMedicineIncomingDeliveries()
        BindEmptyMedicineLedger()
        ClearMedicineInventoryCard()
    End Sub

    '============================== STOCK LIST ==============================
    Private Sub BindMedicineStockList()
        Dim classId As String = If(TryCast(Session("ClassificationID"), String), "0")
        Dim subClassId As String = If(TryCast(Session("SubClassificationID"), String), "0")
        Dim gaId As String = If(TryCast(Session("GA_ID"), String), "0")

        If String.IsNullOrWhiteSpace(classId) Then classId = "0"
        If String.IsNullOrWhiteSpace(subClassId) Then subClassId = "0"
        If String.IsNullOrWhiteSpace(gaId) Then gaId = "0"

        If gaId = "0" AndAlso subClassId = "0" AndAlso classId = "0" Then
            BindEmptyMedicineStockList()
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
            grdMedicineStockList.DataSource = dt
            grdMedicineStockList.DataBind()
        Else
            BindEmptyMedicineStockList()
        End If
    End Sub

    Private Sub BindEmptyMedicineStockList()
        Dim dt As DataTable = CreateMedicineStockListSchema()
        dt = AddEmptyRows(dt, 4)
        grdMedicineStockList.DataSource = dt
        grdMedicineStockList.DataBind()
    End Sub

    Private Function CreateMedicineStockListSchema() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Stock_ID", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Balance", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        Return dt
    End Function

    Protected Sub grdMedicineStockList_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdMedicineStockList.PageIndex = e.NewPageIndex
        BindMedicineStockList()
    End Sub

    Protected Sub grdMedicineStockList_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("style") = "cursor:pointer;"
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdMedicineStockList, "Select$" & e.Row.RowIndex, True)
        End If
    End Sub

    Protected Sub grdMedicineStockList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim stockId As Long = 0
        Dim itemId As Long = 0

        ' Add trace for debugging
        If grdMedicineStockList.SelectedDataKey IsNot Nothing Then
            If grdMedicineStockList.SelectedDataKey.Values("Item_ID") IsNot Nothing Then
                AddTrace("Item_ID: " & grdMedicineStockList.SelectedDataKey.Values("Item_ID").ToString())
            End If
            If grdMedicineStockList.SelectedDataKey.Values("Stock_ID") IsNot Nothing Then
                AddTrace("Stock_ID: " & grdMedicineStockList.SelectedDataKey.Values("Stock_ID").ToString())
            End If
        End If

        If grdMedicineStockList.SelectedDataKey IsNot Nothing Then
            If grdMedicineStockList.SelectedDataKey.Values("Stock_ID") IsNot Nothing Then
                Long.TryParse(grdMedicineStockList.SelectedDataKey.Values("Stock_ID").ToString(), stockId)
            End If
            If grdMedicineStockList.SelectedDataKey.Values("Item_ID") IsNot Nothing Then
                Long.TryParse(grdMedicineStockList.SelectedDataKey.Values("Item_ID").ToString(), itemId)
            End If
        End If

        ViewState("SelectedMedicineStockID") = stockId
        ViewState("SelectedMedicineItemID") = itemId

        ' Incoming Deliveries - NOW USING Item_ID
        If itemId > 0 Then
            BindMedicineIncomingDeliveries(itemId)
        Else
            BindEmptyMedicineIncomingDeliveries()
        End If

        ' Inventory Card - uses StockID (correct)
        If stockId > 0 Then
            PopulateMedicineInventoryCard(stockId)
        Else
            ClearMedicineInventoryCard()
        End If

        ' Ledger - uses Item_ID (correct)
        If itemId > 0 Then
            BindMedicineLedger(itemId)
        Else
            BindEmptyMedicineLedger()
        End If
    End Sub

    '============================== INCOMING DELIVERIES ==============================
    ' Now accepts Item_ID instead of POHdr_ID
    Private Sub BindMedicineIncomingDeliveries(ByVal itemId As Long)
        Dim dt As DataTable = Nothing
        Try
            AddTrace("Item_ID: " & itemId)
            Dim sql As String = "EXEC [AMS].[sp_StockCard_Rev_IncomingDeliveries] @Item_ID = " & itemId
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdMedicineIncomingDeliveries.DataSource = dt
            grdMedicineIncomingDeliveries.DataBind()
        Else
            BindEmptyMedicineIncomingDeliveries()
        End If
    End Sub

    Private Sub BindEmptyMedicineIncomingDeliveries()
        Dim dt As DataTable = CreateMedicineIncomingDeliveriesSchema()
        dt = AddEmptyRows(dt, 4)

        ' Include Stock_ID only in DataKeyNames
        grdMedicineIncomingDeliveries.DataKeyNames = New String() {"Stock_ID"}
        grdMedicineIncomingDeliveries.DataSource = dt
        grdMedicineIncomingDeliveries.DataBind()
    End Sub

    Private Function CreateMedicineIncomingDeliveriesSchema() As DataTable
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

    Protected Sub grdMedicineIncomingDeliveries_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdMedicineIncomingDeliveries.PageIndex = e.NewPageIndex

        ' Now retrieving Item_ID from ViewState
        Dim itemId As Long = 0
        If ViewState("SelectedMedicineItemID") IsNot Nothing Then
            Long.TryParse(ViewState("SelectedMedicineItemID").ToString(), itemId)
        End If

        If itemId > 0 Then
            BindMedicineIncomingDeliveries(itemId)
        Else
            BindEmptyMedicineIncomingDeliveries()
        End If
    End Sub

    Protected Sub grdMedicineIncomingDeliveries_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        ' Intentionally left empty - grid is display-only with no click functionality
    End Sub

    '============================== INVENTORY CARD ==============================
    Private Sub PopulateMedicineInventoryCard(ByVal stockId As Long)
        If stockId <= 0 Then
            ClearMedicineInventoryCard()
            Exit Sub
        End If

        AddTrace("stockId: " & stockId)
        Dim dt As DataTable = Nothing
        Try
            dt = objDerived.GetDataTable("EXEC AMS.sp_Encoding_Medicines " & stockId, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearMedicineInventoryCard()
            Exit Sub
        End If

        Dim r As DataRow = dt.Rows(0)

        Dim itemId As Long = Convert.ToInt64(r("Item_ID"))

        Dim result As Object = objDerived.GetValue(
            "SELECT ItemCompleteDesc FROM dbo.m_item WHERE Item_ID = " & itemId,
            CommandType.Text
        )

        If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
            lblMedicineGenericName.Text = Convert.ToString(result)
        Else
            lblMedicineGenericName.Text = String.Empty
        End If

        Dim Unit As String = Convert.ToString(r("Unit_ID"))
        Dim dtUnit As DataTable = objDerived.GetDataTable("SELECT Description FROM AMS.m_Unit WHERE Unit_ID = " & Unit, CommandType.Text)

        If dtUnit IsNot Nothing AndAlso dtUnit.Rows.Count > 0 Then
            lblMedicineUnit.Text = Convert.ToString(dtUnit.Rows(0)("Description"))
        Else
            lblMedicineUnit.Text = String.Empty
        End If

        lblMedicineBFADNo.Text = Convert.ToString(r("bfadno"))
        lblMedicineItemCode.Text = Convert.ToString(r("itemcode"))

        lblMedicineBrandName.Text = Convert.ToString(r("BrandName"))
        lblMedicineDosage.Text = Convert.ToString(r("Dose"))
        lblMedicineForm.Text = Convert.ToString(r("Form"))
        lblMedicineOtcRx.Text = Convert.ToString(r("OTCRx"))

        lblMedicineQtyBalance.Text = Convert.ToString(r("Quantity"))
        lblMedicineUnitPrice.Text = Convert.ToString(r("UnitCost"))
        lblMedicineSellingPrice.Text = Convert.ToString(r("SellingPrice"))
        lblMedicineReorderPt.Text = Convert.ToString(r("ReorderPoint"))

        Dim dtStr As String = Convert.ToString(r("Date"))
        Dim dtVal As DateTime
        If DateTime.TryParse(dtStr, dtVal) Then
            lblMedicineDate.Text = dtVal.ToString("MM/dd/yyyy")
        Else
            lblMedicineDate.Text = dtStr
        End If

        lblMedicineBatch.Text = Convert.ToString(r("Batch"))
        lblMedicineLot.Text = Convert.ToString(r("Lot"))

        Dim mftgStr As String = Convert.ToString(r("Mftgdate"))
        Dim mftgVal As DateTime
        If DateTime.TryParse(mftgStr, mftgVal) Then
            lblMedicineMftgDate.Text = mftgVal.ToString("MM/dd/yyyy")
        Else
            lblMedicineMftgDate.Text = mftgStr
        End If

        Dim expStr As String = Convert.ToString(r("EpiryDate"))
        Dim expVal As DateTime
        If DateTime.TryParse(expStr, expVal) Then
            lblMedicineExpiryDate.Text = expVal.ToString("MM/dd/yyyy")
        Else
            lblMedicineExpiryDate.Text = expStr
        End If

        Dim alertStr As String = Convert.ToString(r("Alert"))
        Dim alertVal As DateTime
        If DateTime.TryParse(alertStr, alertVal) Then
            lblMedicineAlert.Text = alertVal.ToString("MM/dd/yyyy")
        Else
            lblMedicineAlert.Text = alertStr
        End If

        Dim whName As String = Convert.ToString(r("Warehouse")).Trim()
        If drpMedicineWarehouse.Items.Count > 0 AndAlso whName <> "" Then
            Dim it As ListItem = drpMedicineWarehouse.Items.FindByText(whName)
            If it IsNot Nothing Then
                drpMedicineWarehouse.ClearSelection()
                it.Selected = True
            Else
                drpMedicineWarehouse.SelectedIndex = 0
            End If
        ElseIf drpMedicineWarehouse.Items.Count > 0 Then
            drpMedicineWarehouse.SelectedIndex = 0
        End If

        txtMedicineBay.Text = Convert.ToString(r("Bay"))
        txtMedicineColumn.Text = Convert.ToString(r("Column"))
        txtMedicineFloor.Text = Convert.ToString(r("Floor"))
        txtMedicineRoom.Text = Convert.ToString(r("Room"))
        txtMedicineShelves.Text = Convert.ToString(r("Shelves"))
        txtMedicineRack.Text = Convert.ToString(r("Rack"))
        txtMedicineBin.Text = Convert.ToString(r("Bin"))

        lblMedicineQtyPerPack.Text = ""
        lblMedicinePricePerQtyUnitCost.Text = ""
        lblMedicinePricePerQtySellingPrice.Text = ""
    End Sub

    Private Sub ClearMedicineInventoryCard()
        lblMedicineGenericName.Text = ""
        lblMedicineUnit.Text = ""
        lblMedicineBrandName.Text = ""
        lblMedicineForm.Text = ""
        lblMedicineDosage.Text = ""
        lblMedicineOtcRx.Text = ""
        lblMedicineUnitPrice.Text = ""
        lblMedicineBFADNo.Text = ""
        lblMedicineSellingPrice.Text = ""
        lblMedicineItemCode.Text = ""
        lblMedicineReorderPt.Text = ""
        lblMedicineQtyBalance.Text = ""
        lblMedicineDate.Text = ""

        lblMedicineBatch.Text = ""
        lblMedicineLot.Text = ""
        lblMedicineMftgDate.Text = ""
        lblMedicineExpiryDate.Text = ""
        lblMedicineAlert.Text = ""

        lblMedicineQtyPerPack.Text = ""
        lblMedicinePricePerQtyUnitCost.Text = ""
        lblMedicinePricePerQtySellingPrice.Text = ""

        If drpMedicineWarehouse.Items.Count > 0 Then
            drpMedicineWarehouse.SelectedIndex = 0
        End If

        txtMedicineBay.Text = ""
        txtMedicineColumn.Text = ""
        txtMedicineFloor.Text = ""
        txtMedicineRoom.Text = ""
        txtMedicineShelves.Text = ""
        txtMedicineRack.Text = ""
        txtMedicineBin.Text = ""
    End Sub

    '============================== LEDGER ==============================
    Private Sub BindMedicineLedger(ByVal itemId As Long)
        Dim dt As DataTable = Nothing
        Try
            Dim sql As String = "EXEC [AMS].[sp_SuppliesLedger] @Item_ID=" & itemId
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdMedicineLedger.DataSource = dt
            grdMedicineLedger.DataBind()
        Else
            BindEmptyMedicineLedger()
        End If
    End Sub

    Private Sub BindEmptyMedicineLedger()
        Dim dt As DataTable = CreateMedicineLedgerSchema()
        dt = AddEmptyRows(dt, 4)
        grdMedicineLedger.DataSource = dt
        grdMedicineLedger.DataBind()
    End Sub

    Private Function CreateMedicineLedgerSchema() As DataTable
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

    Protected Sub grdMedicineLedger_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdMedicineLedger.PageIndex = e.NewPageIndex

        Dim itemId As Long = 0
        If ViewState("SelectedMedicineItemID") IsNot Nothing Then
            Long.TryParse(ViewState("SelectedMedicineItemID").ToString(), itemId)
        End If

        If itemId > 0 Then
            BindMedicineLedger(itemId)
        Else
            BindEmptyMedicineLedger()
        End If
    End Sub

    '============================== COMMON ==============================
    Private Function AddEmptyRows(ByVal dt As DataTable, ByVal rowCount As Integer) As DataTable
        For i As Integer = 1 To rowCount
            dt.Rows.Add(dt.NewRow())
        Next
        Return dt
    End Function

    Protected Sub btnViewMedicineStockInventoryReport_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim script As String = "window.open('/Records/rpt_stockcardinventory.aspx', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OpenReport", script, True)
    End Sub

    Protected Sub grdMedicineLedger_DataBound(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

End Class