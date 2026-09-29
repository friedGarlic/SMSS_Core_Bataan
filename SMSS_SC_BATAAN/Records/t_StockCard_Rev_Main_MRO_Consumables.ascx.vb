Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_t_StockCard_Rev_Main_MRO_Consumables
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
            BindMROConsumablesStockList()
            BindEmptyMROConsumablesIncomingDeliveries()
            BindEmptyMROConsumablesLedger()
            ClearMROConsumablesInventoryCard()
        End If
    End Sub

    Public Sub RefreshGridData()
        BindMROConsumablesStockList()
        BindEmptyMROConsumablesIncomingDeliveries()
        BindEmptyMROConsumablesLedger()
        ClearMROConsumablesInventoryCard()
    End Sub

    Private Sub BindMROConsumablesStockList()
        Dim classId As String = If(TryCast(Session("ClassificationID"), String), "0")
        Dim subClassId As String = If(TryCast(Session("SubClassificationID"), String), "0")
        Dim gaId As String = If(TryCast(Session("GA_ID"), String), "0")

        If String.IsNullOrWhiteSpace(classId) Then classId = "0"
        If String.IsNullOrWhiteSpace(subClassId) Then subClassId = "0"
        If String.IsNullOrWhiteSpace(gaId) Then gaId = "0"

        If gaId = "0" AndAlso subClassId = "0" AndAlso classId = "0" Then
            BindEmptyMROConsumablesStockList()
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
            grdMROConsumablesStockList.DataSource = dt
            grdMROConsumablesStockList.DataBind()
        Else
            BindEmptyMROConsumablesStockList()
        End If
    End Sub

    Private Sub BindEmptyMROConsumablesStockList()
        Dim dt As DataTable = CreateMROConsumablesStockListSchema()
        dt = AddEmptyRows(dt, 4)
        grdMROConsumablesStockList.DataSource = dt
        grdMROConsumablesStockList.DataBind()
    End Sub

    Private Sub BindEmptyMROConsumablesIncomingDeliveries()
        Dim dt As DataTable = CreateMROConsumablesIncomingDeliveriesSchema()
        dt = AddEmptyRows(dt, 4)

        ' Include Stock_ID only in DataKeyNames
        grdMROConsumablesIncomingDeliveries.DataKeyNames = New String() {"Stock_ID"}
        grdMROConsumablesIncomingDeliveries.DataSource = dt
        grdMROConsumablesIncomingDeliveries.DataBind()
    End Sub

    Private Sub BindEmptyMROConsumablesLedger()
        Dim dt As DataTable = CreateMROConsumablesLedgerSchema()
        dt = AddEmptyRows(dt, 4)
        grdMROConsumablesLedger.DataSource = dt
        grdMROConsumablesLedger.DataBind()
    End Sub

    Private Function CreateMROConsumablesStockListSchema() As DataTable
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

    Private Function CreateMROConsumablesIncomingDeliveriesSchema() As DataTable
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

    Private Function CreateMROConsumablesLedgerSchema() As DataTable
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

    Protected Sub grdMROConsumablesStockList_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdMROConsumablesStockList.PageIndex = e.NewPageIndex
        BindMROConsumablesStockList()
    End Sub

    Protected Sub grdMROConsumablesStockList_RowDataBound(
ByVal sender As Object,
ByVal e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim itemIdObject As Object =
        DataBinder.Eval(
            e.Row.DataItem,
            "Item_ID"
        )

            Dim itemId As String = ""

            If itemIdObject IsNot Nothing AndAlso
        Not Convert.IsDBNull(itemIdObject) Then

                itemId = itemIdObject.ToString()

            End If

            ' Only actual MRO Consumables records are clickable.
            If Not String.IsNullOrEmpty(itemId) Then

                e.Row.Attributes("onclick") =
            Page.ClientScript.GetPostBackClientHyperlink(
                grdMROConsumablesStockList,
                "Select$" & e.Row.RowIndex,
                True
            )

                e.Row.Style("cursor") = "pointer"

            End If

        End If

    End Sub

    ' Now accepts Item_ID instead of POHdr_ID
    Private Sub BindMROConsumablesIncomingDeliveries(ByVal itemId As Long)
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
            grdMROConsumablesIncomingDeliveries.DataSource = dt
            grdMROConsumablesIncomingDeliveries.DataBind()
        Else
            BindEmptyMROConsumablesIncomingDeliveries()
        End If
    End Sub

    Protected Sub grdMROConsumablesIncomingDeliveries_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdMROConsumablesIncomingDeliveries.PageIndex = e.NewPageIndex

        ' Now retrieving Item_ID from ViewState
        Dim itemId As Long = 0
        If ViewState("SelectedMROConsumablesItemID") IsNot Nothing Then
            Long.TryParse(ViewState("SelectedMROConsumablesItemID").ToString(), itemId)
        End If

        If itemId > 0 Then
            BindMROConsumablesIncomingDeliveries(itemId)
        Else
            BindEmptyMROConsumablesIncomingDeliveries()
        End If
    End Sub

    Protected Sub grdMROConsumablesIncomingDeliveries_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        ' Intentionally left empty - grid is display-only with no click functionality
    End Sub

    Protected Sub btnViewMROConsumablesStockInventoryReport_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim script As String = "window.open('/Records/rpt_stockcardinventory.aspx', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OpenReport", script, True)
    End Sub

    Private Sub BindMROConsumablesLedger(ByVal itemId As Long)
        Dim dt As DataTable = Nothing
        Try
            Dim sql As String = "EXEC [AMS].[sp_SuppliesLedger] @Item_ID=" & itemId
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdMROConsumablesLedger.DataSource = dt
            grdMROConsumablesLedger.DataBind()
        Else
            BindEmptyMROConsumablesLedger()
        End If
    End Sub

    Protected Sub grdMROConsumablesStockList_SelectedIndexChanged(
ByVal sender As Object,
ByVal e As EventArgs)

        Dim stockId As Long = 0
        Dim itemId As Long = 0

        If grdMROConsumablesStockList.SelectedDataKey Is Nothing Then
            Exit Sub
        End If

        If grdMROConsumablesStockList.SelectedDataKey.Values(
        "Stock_ID"
    ) IsNot Nothing Then

            Long.TryParse(
            grdMROConsumablesStockList.SelectedDataKey.Values(
                "Stock_ID"
            ).ToString(),
            stockId
        )

        End If

        If grdMROConsumablesStockList.SelectedDataKey.Values(
        "Item_ID"
    ) IsNot Nothing Then

            Long.TryParse(
            grdMROConsumablesStockList.SelectedDataKey.Values(
                "Item_ID"
            ).ToString(),
            itemId
        )

        End If

        AddTrace(
        "Item_ID: " &
        itemId
    )

        AddTrace(
        "Stock_ID: " &
        stockId
    )

        ProcessSelectedMROConsumablesStockItem(
        stockId,
        itemId
    )

    End Sub


    Private Sub ProcessSelectedMROConsumablesStockItem(
ByVal stockId As Long,
ByVal itemId As Long)

        ViewState("SelectedMROConsumablesStockID") = stockId
        ViewState("SelectedMROConsumablesItemID") = itemId

        Session("Item_ID") = itemId

        AddTrace(
        "Selected StockID: " &
        stockId
    )

        AddTrace(
        "Selected Item_ID: " &
        itemId
    )

        ' Incoming Deliveries uses Item_ID.
        If itemId > 0 Then
            BindMROConsumablesIncomingDeliveries(itemId)
        Else
            BindEmptyMROConsumablesIncomingDeliveries()
        End If

        ' Inventory Card uses Stock_ID.
        If stockId > 0 Then
            PopulateMROConsumablesInventoryCard(stockId)
        Else
            ClearMROConsumablesInventoryCard()
        End If

        ' Ledger uses Item_ID.
        If itemId > 0 Then
            BindMROConsumablesLedger(itemId)
        Else
            BindEmptyMROConsumablesLedger()
        End If



    End Sub


    Public Sub LoadSelectedItem(
ByVal itemId As Long)

        If itemId <= 0 Then

            Session("Item_ID") = 0

            ViewState("SelectedMROConsumablesStockID") = Nothing
            ViewState("SelectedMROConsumablesItemID") = Nothing

            grdMROConsumablesStockList.PageIndex = 0
            grdMROConsumablesStockList.SelectedIndex = -1

            BindEmptyMROConsumablesIncomingDeliveries()
            ClearMROConsumablesInventoryCard()
            BindEmptyMROConsumablesLedger()

            Exit Sub

        End If

        Session("Item_ID") = itemId

        AddTrace(
        "MRO Consumables User Control Item_ID: " &
        itemId
    )

        Dim classId As String =
    Convert.ToString(
        Session("ClassificationID")
    )

        Dim subClassId As String =
    Convert.ToString(
        Session("SubClassificationID")
    )

        Dim gaId As String =
    Convert.ToString(
        Session("GA_ID")
    )

        If String.IsNullOrWhiteSpace(classId) Then
            classId = "0"
        End If

        If String.IsNullOrWhiteSpace(subClassId) Then
            subClassId = "0"
        End If

        If String.IsNullOrWhiteSpace(gaId) Then
            gaId = "0"
        End If

        Dim dt As DataTable = Nothing

        Try

            ' Use the same dataset as
            ' BindMROConsumablesStockList.
            Dim sql As String =
        "EXEC [AMS].[sp_StockCard_Rev_ListOfSupplies] " &
        "@ClassificationID=" & classId & ", " &
        "@SubClassificationID=" & subClassId & ", " &
        "@GA_ID=" & gaId

            AddTrace(
            "Loading selected MRO Consumables item: " &
            sql
        )

            dt = objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        Catch ex As Exception

            System.Diagnostics.Debug.WriteLine(
            "Error loading selected MRO Consumables item: " &
            ex.Message
        )

            dt = Nothing

        End Try

        Dim selectedStockId As Long = 0
        Dim selectedRecordIndex As Integer = -1

        If dt IsNot Nothing AndAlso
    dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1

                Dim currentItemId As Long = 0

                Long.TryParse(
                Convert.ToString(
                    dt.Rows(i).Item("Item_ID")
                ),
                currentItemId
            )

                If currentItemId = itemId Then

                    selectedRecordIndex = i

                    Long.TryParse(
                    Convert.ToString(
                        dt.Rows(i).Item("Stock_ID")
                    ),
                    selectedStockId
                )

                    Exit For

                End If

            Next

            If selectedRecordIndex >= 0 Then

                ' Display the page containing
                ' the selected item.
                grdMROConsumablesStockList.PageIndex =
            selectedRecordIndex \
            grdMROConsumablesStockList.PageSize

            Else

                grdMROConsumablesStockList.PageIndex = 0

            End If

            grdMROConsumablesStockList.DataSource = dt
            grdMROConsumablesStockList.DataBind()

            If selectedRecordIndex >= 0 Then

                ' Maintain the selected row so the
                ' existing Preview process still works.
                grdMROConsumablesStockList.SelectedIndex =
            selectedRecordIndex Mod
            grdMROConsumablesStockList.PageSize

                ProcessSelectedMROConsumablesStockItem(
                selectedStockId,
                itemId
            )

            Else

                grdMROConsumablesStockList.SelectedIndex = -1

                ViewState("SelectedMROConsumablesStockID") =
            Nothing

                ViewState("SelectedMROConsumablesItemID") =
            Nothing

                BindEmptyMROConsumablesIncomingDeliveries()
                ClearMROConsumablesInventoryCard()
                BindEmptyMROConsumablesLedger()

            End If

        Else

            BindEmptyMROConsumablesStockList()

            ViewState("SelectedMROConsumablesStockID") =
        Nothing

            ViewState("SelectedMROConsumablesItemID") =
        Nothing

            BindEmptyMROConsumablesIncomingDeliveries()
            ClearMROConsumablesInventoryCard()
            BindEmptyMROConsumablesLedger()

        End If

    End Sub





    Protected Sub grdMROConsumablesLedger_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdMROConsumablesLedger.PageIndex = e.NewPageIndex

        Dim itemId As Long = 0
        If ViewState("SelectedMROConsumablesItemID") IsNot Nothing Then
            Long.TryParse(ViewState("SelectedMROConsumablesItemID").ToString(), itemId)
        End If

        If itemId > 0 Then
            BindMROConsumablesLedger(itemId)
        Else
            BindEmptyMROConsumablesLedger()
        End If
    End Sub

    Private Sub PopulateMROConsumablesInventoryCard(ByVal stockId As Long)
        If stockId <= 0 Then
            ClearMROConsumablesInventoryCard()
            Exit Sub
        End If

        Dim dt As DataTable = Nothing
        Try
            dt = objDerived.GetDataTable("EXEC AMS.sp_Encoding_Supplies " & stockId, CommandType.Text)
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearMROConsumablesInventoryCard()
            Exit Sub
        End If

        Dim r As DataRow = dt.Rows(0)

        lblMROConsumablesName.Text = Convert.ToString(r("Description"))

        Dim Unit As String = Convert.ToString(r("NonFoodUnit"))

        Dim dtUnit As DataTable = objDerived.GetDataTable("SELECT Description FROM AMS.m_Unit WHERE Unit_ID = " & Unit, CommandType.Text)

        If dtUnit IsNot Nothing AndAlso dtUnit.Rows.Count > 0 Then
            lblMROConsumablesUnit.Text = Convert.ToString(dtUnit.Rows(0)("Description"))
        Else
            lblMROConsumablesUnit.Text = String.Empty
        End If

        lblMROConsumablesBrandName.Text = Convert.ToString(r("NonFoodBrandName"))
        lblMROConsumablesForm.Text = Convert.ToString(r("NonFoodForm"))

        lblMROConsumablesBatch.Text = Convert.ToString(r("NonFoodBatch"))
        lblMROConsumablesLot.Text = Convert.ToString(r("NonFoodLot"))
        lblMROConsumablesMftgDate.Text = Convert.ToString(r("NonFoodMftgdate"))
        lblMROConsumablesExpiryDate.Text = Convert.ToString(r("NonFoodEpiryDate"))
        lblMROConsumablesAlert.Text = Convert.ToString(r("NonFoodAlert"))

        lblMROConsumablesUnitPrice.Text = Convert.ToString(r("UnitCost"))
        lblMROConsumablesReorderPt.Text = Convert.ToString(r("ReorderPoint"))
        lblMROConsumablesQuantity.Text = Convert.ToString(r("Quantity"))

        Dim dtStr As String = Convert.ToString(r("Date"))
        Dim dtVal As DateTime
        If DateTime.TryParse(dtStr, dtVal) Then
            lblMROConsumablesDate.Text = dtVal.ToString("MM/dd/yyyy")
        Else
            lblMROConsumablesDate.Text = dtStr
        End If

        Dim whName As String = Convert.ToString(r("Warehouse")).Trim()
        If drpMROConsumablesWarehouse.Items.Count > 0 AndAlso whName <> "" Then
            Dim it As ListItem = drpMROConsumablesWarehouse.Items.FindByText(whName)
            If it IsNot Nothing Then
                drpMROConsumablesWarehouse.ClearSelection()
                it.Selected = True
            Else
                drpMROConsumablesWarehouse.SelectedIndex = 0
            End If
        ElseIf drpMROConsumablesWarehouse.Items.Count > 0 Then
            drpMROConsumablesWarehouse.SelectedIndex = 0
        End If

        txtMROConsumablesBay.Text = Convert.ToString(r("Bay"))
        txtMROConsumablesColumn.Text = Convert.ToString(r("Column"))
        txtMROConsumablesFloor.Text = Convert.ToString(r("Floor"))
        txtMROConsumablesRoom.Text = Convert.ToString(r("Room"))
        txtMROConsumablesShelves.Text = Convert.ToString(r("Shelves"))
        txtMROConsumablesRack.Text = Convert.ToString(r("Rack"))
        txtMROConsumablesBin.Text = Convert.ToString(r("Bin"))
    End Sub

    Private Sub ClearMROConsumablesInventoryCard()
        lblMROConsumablesName.Text = ""
        lblMROConsumablesUnit.Text = ""

        lblMROConsumablesBrandName.Text = ""
        lblMROConsumablesForm.Text = ""

        lblMROConsumablesUnitPrice.Text = ""
        lblMROConsumablesReorderPt.Text = ""
        lblMROConsumablesQuantity.Text = ""
        lblMROConsumablesDate.Text = ""

        lblMROConsumablesBatch.Text = ""
        lblMROConsumablesLot.Text = ""
        lblMROConsumablesMftgDate.Text = ""
        lblMROConsumablesExpiryDate.Text = ""
        lblMROConsumablesAlert.Text = ""

        If drpMROConsumablesWarehouse.Items.Count > 0 Then
            drpMROConsumablesWarehouse.SelectedIndex = 0
        End If

        txtMROConsumablesBay.Text = ""
        txtMROConsumablesColumn.Text = ""
        txtMROConsumablesFloor.Text = ""
        txtMROConsumablesRoom.Text = ""
        txtMROConsumablesShelves.Text = ""
        txtMROConsumablesRack.Text = ""
        txtMROConsumablesBin.Text = ""
    End Sub

End Class