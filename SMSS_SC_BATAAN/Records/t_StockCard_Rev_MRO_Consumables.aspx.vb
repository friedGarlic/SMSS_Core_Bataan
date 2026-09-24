Imports System.Data
Imports System.Data.SqlClient

Partial Class Records_t_StockCard_Rev_MRO_Consumables
    Inherits System.Web.UI.Page

    Private objDerived As New BaseClasses.AccountClassAcounts

    Protected Sub Page_Load(
    ByVal sender As Object,
    ByVal e As System.EventArgs
) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim classification As String = objDerived.GetValue(
            "SELECT ClassificationId " &
            "FROM dbo.tbl_Classification " &
            "WHERE ClassificationName = 'MRO Consumables'",
            CommandType.Text
        )

            Session("ClassificationID") = classification

            LoadGLAccounts()

            DrpSubClass.Items.Clear()
            DrpSubClass.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )
            DrpSubClass.Enabled = True

            ClearItemDesc()
            BindEmptyLedger()
            loadwarehouse()


        End If
    End Sub

    Private Sub LoadSubClassifications()
        DrpSubClass.Items.Clear()

        If ddGlAccount.SelectedValue Is Nothing OrElse
       ddGlAccount.SelectedValue = "" OrElse
       ddGlAccount.SelectedValue = "0" Then

            DrpSubClass.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

            DrpSubClass.Enabled = True
            Exit Sub
        End If

        Dim sql As String =
        "SELECT DISTINCT " &
        "    SubClassificationID, " &
        "    SubClassificationName " &
        "FROM dbo.tbl_SubClassification " &
        "WHERE ClassificationID = '" & Session("ClassificationID") & "' " &
        "AND GA_ID = '" & ddGlAccount.SelectedValue & "' " &
        "ORDER BY SubClassificationName"

        AddTrace(sql)

        Dim dt As DataTable = objDerived.GetDataTable(
        sql,
        CommandType.Text
    )

        If dt IsNot Nothing Then

            Dim dr As DataRow = dt.NewRow()
            dr("SubClassificationID") = 0
            dr("SubClassificationName") = "No Subclass"
            dt.Rows.InsertAt(dr, 0)

            DrpSubClass.DataSource = dt
            DrpSubClass.DataTextField = "SubClassificationName"
            DrpSubClass.DataValueField = "SubClassificationID"
            DrpSubClass.DataBind()

        Else

            DrpSubClass.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

        End If

        DrpSubClass.Enabled = True
    End Sub
    Private Sub LoadGLAccounts()
        ddGlAccount.Items.Clear()
        Dim sql As String =
            "SELECT DISTINCT " &
            "    ga.GA_ID, " &
            "    ga.GA_Title, " &
            "    cm.ga_id AS Matrix_GA_ID " &
            "FROM dbo.tbl_SubClassification AS sc " &
            "INNER JOIN dbo.view_Accntg_gen_accnt AS ga " &
            "    ON ga.GA_ID = sc.GA_ID " &
            "LEFT JOIN dbo.tblclassmatrix AS cm " &
            "    ON cm.classificationid = sc.ClassificationID " &
            "    AND cm.ga_id = sc.GA_ID " &
            "WHERE sc.ClassificationID = '" & Session("ClassificationID") & "' " &
            "UNION " &
            "SELECT DISTINCT " &
            "    ga.GA_ID, " &
            "    ga.GA_Title, " &
            "    cm.ga_id AS Matrix_GA_ID " &
            "FROM dbo.tblclassmatrix AS cm " &
            "INNER JOIN dbo.view_Accntg_gen_accnt AS ga " &
            "    ON ga.GA_ID = cm.ga_id " &
            "WHERE cm.classificationid = '" & Session("ClassificationID") & "' " &
            "ORDER BY GA_Title;"

        AddTrace(sql)

        Dim dt As DataTable = objDerived.GetDataTable(
        sql,
        CommandType.Text
    )

        If dt IsNot Nothing Then

            Dim dr As DataRow = dt.NewRow()
            dr("GA_ID") = 0
            dr("GA_Title") = "Select"
            dt.Rows.InsertAt(dr, 0)

            ddGlAccount.DataSource = dt
            ddGlAccount.DataTextField = "GA_Title"
            ddGlAccount.DataValueField = "GA_ID"
            ddGlAccount.DataBind()

        Else

            ddGlAccount.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

        End If

        ddGlAccount.Enabled = True
    End Sub

    Private Sub ClearItemDesc()
        drpConsOthersName.Items.Clear()

        drpConsOthersName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        drpConsOthersName.Enabled = True
    End Sub

    Private Sub LoadItemDesc()

        If ddGlAccount.SelectedValue Is Nothing OrElse
       ddGlAccount.SelectedValue = "" OrElse
       ddGlAccount.SelectedValue = "0" Then

            ClearItemDesc()
            Exit Sub
        End If



        Dim sqlQuery As String = "SELECT DISTINCT " &
        "dbo.m_item.Item_ID, " &
        "dbo.m_item.ItemCompleteDesc as Item_Desc " &
        "FROM " &
        "dbo.m_item " &
        "INNER JOIN dbo.tbl_Classification ON dbo.m_item.ClassificationID = dbo.tbl_Classification.ClassificationId " &
        "INNER JOIN dbo.m_item_detail ON dbo.m_item.Item_ID = dbo.m_item_detail.Item_ID " &
        "INNER JOIN dbo.tblclassmatrix AS cm ON cm.item_id = dbo.m_item.Item_ID " &
        "LEFT JOIN dbo.tbl_SubCategory ON dbo.m_item.SubCategoryID = dbo.tbl_SubCategory.SubCategoryID " &
        "LEFT JOIN dbo.tbl_SubClassification ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID " &
        "WHERE " &
        "dbo.m_item.SubClassificationID = " & DrpSubClass.SelectedValue & " " &
        "AND cm.ga_id = " & ddGlAccount.SelectedValue & " " &
        "ORDER BY dbo.m_item.ItemCompleteDesc"

        ' Add trace for the SQL query
        AddTrace("Executing SQL Query: " & sqlQuery)


        Dim dtitem As DataTable = objDerived.GetDataTable(sqlQuery, CommandType.Text)




        If dtitem Is Nothing Then
            ClearItemDesc()
            Exit Sub
        End If

        Dim dr As DataRow = dtitem.NewRow()
        dr("Item_ID") = 0
        dr("Item_Desc") = "Select"
        dtitem.Rows.InsertAt(dr, 0)

        drpConsOthersName.DataSource = dtitem
        drpConsOthersName.DataTextField = "Item_Desc"
        drpConsOthersName.DataValueField = "Item_ID"
        drpConsOthersName.DataBind()

        drpConsOthersName.Enabled = True
    End Sub
    Public Sub loadUnit()
        Dim dt As DataTable = objDerived.GetDataTable("select Unit_ID,Description From ams.m_Unit as a order by Description", CommandType.Text)
        drpConsOthersUnit.DataSource = dt
        drpConsOthersUnit.DataTextField = "Description"
        drpConsOthersUnit.DataValueField = "Unit_ID"
        drpConsOthersUnit.DataBind()

        Dim Unit_ID As Integer = objDerived.GetValue("SELECT Unit_ID FROM DBO.m_item WHERE Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        drpConsOthersUnit.SelectedValue = Unit_ID


    End Sub

    Public Sub loadwarehouse()
        Dim dt As DataTable = objDerived.GetDataTable("select warehouse_id,wname From ams.loc_warehouse where isUsed='True'", CommandType.Text)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            drpMROConsOthersWarehouse.DataTextField = "wname"
            drpMROConsOthersWarehouse.DataValueField = "warehouse_id"
            drpMROConsOthersWarehouse.DataSource = dt
            drpMROConsOthersWarehouse.DataBind()
        End If
        drpMROConsOthersWarehouse.Items.Insert(0, New ListItem("Select", "0"))
        drpMROConsOthersWarehouse.SelectedIndex = 0
        drpMROConsOthersWarehouse.Enabled = True

    End Sub


    Public Sub LoadLedger()
        Dim dtStock As DataTable = objDerived.GetDataTable(
            "EXEC [AMS].[sp_SuppliesLedger] '" & drpConsOthersName.SelectedValue & "'",
            CommandType.Text
        )

        If dtStock Is Nothing Then
            BindEmptyLedger()
        Else
            If dtStock.Rows.Count < 4 Then
                For i As Integer = 1 To (4 - dtStock.Rows.Count)
                    dtStock.Rows.Add(dtStock.NewRow())
                Next
            End If

            grdLedger.DataSource = dtStock
            grdLedger.DataBind()
        End If
    End Sub

    Protected Sub DrpSubClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As System.EventArgs
)

        LoadItemDesc()
        BindEmptyLedger()
        loadwarehouse()

    End Sub

    Protected Sub ddGlAccount_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As System.EventArgs
)

        LoadSubClassifications()
        ClearItemDesc()
        LoadItemDesc()
        BindEmptyLedger()


    End Sub

    Protected Sub drpConsOthersName_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Session("Item_ID") = drpConsOthersName.SelectedValue
        LoadLedger()
        loadUnit()
        loadwarehouse()

    End Sub

    Protected Sub grdLedger_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim cbInspection As CheckBox = TryCast(e.Row.FindControl("cbInspection"), CheckBox)
            Dim TransType As String = ""

            If e.Row.DataItem IsNot Nothing Then
                TransType = DataBinder.Eval(e.Row.DataItem, "Trans_Type").ToString().Trim()
            End If

            If cbInspection IsNot Nothing Then
                If TransType = "Starting Balance" Or TransType = "Starting Inventory" Then
                    cbInspection.Enabled = True
                Else
                    cbInspection.Checked = False
                    cbInspection.Enabled = False
                End If
            End If

        End If

    End Sub

    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        If cb Is Nothing Then Exit Sub

        Dim row As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
        If row Is Nothing Then Exit Sub

        grdLedger.SelectedIndex = row.RowIndex

        If Not cb.Checked Then
            ClearTextBoxesCons()
            Exit Sub
        End If

        Dim stockObj As Object = grdLedger.SelectedDataKey("StockID")
        Dim stockID As Long = 0
        If stockObj IsNot Nothing AndAlso Not IsDBNull(stockObj) Then
            Long.TryParse(stockObj.ToString(), stockID)
        End If

        If stockID <= 0 Then
            ClearTextBoxesCons()
            Exit Sub
        End If

        LoadConsDetailsFromStock(stockID)
    End Sub


    Private Sub ClearTextBoxesCons()
        grdLedger.SelectedIndex = -1

        For Each row As GridViewRow In grdLedger.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim cb As CheckBox = TryCast(row.FindControl("cbInspection"), CheckBox)
                If cb IsNot Nothing Then cb.Checked = False
            End If
        Next

        drpConsOthersUnit.SelectedIndex = 0

        txtConsOthersBrandName.Text = ""
        txtConsOthersForm.Text = ""
        txtConsOthersUnitPrice.Text = ""
        txtConsOthersReOrderPt.Text = ""
        txtConsOthersQuantity.Text = ""
        txtSellectDateCons.Text = ""

        txtConsOthersBatch.Text = ""
        txtConsOthersLot.Text = ""
        txtMDateConsOthers.Text = ""
        txtEDateConsOthers.Text = ""
        txtAlertConsOthers.Text = ""

        If drpMROConsOthersWarehouse.Items.Count > 0 Then drpMROConsOthersWarehouse.SelectedIndex = 0
        txtConsOthersBay.Text = ""
        txtConsOthersColumn.Text = ""
        txtConsOthersFloor.Text = ""
        txtConsOthersRoom.Text = ""
        txtConsOthersShelves.Text = ""
        txtConsOthersRack.Text = ""
        txtConsOthersBin.Text = ""

        btnConsOthersSave.Text = "SAVE"
    End Sub

    Private Sub LoadConsDetailsFromStock(ByVal stockID As Long)
        Dim dt As DataTable = objDerived.GetDataTable("EXEC AMS.sp_Encoding_Supplies " & stockID, CommandType.Text)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearTextBoxesCons()
            Exit Sub
        End If

        Dim r As DataRow = dt.Rows(0)

        Dim itemIdStr As String = Convert.ToString(r("Item_ID")).Trim()
        If drpConsOthersName.Items.Count > 0 AndAlso itemIdStr <> "" AndAlso drpConsOthersName.Items.FindByValue(itemIdStr) IsNot Nothing Then
            drpConsOthersName.SelectedValue = itemIdStr
        End If

        Dim unitIdStr As String = Convert.ToString(r("NonFoodUnit")).Trim()
        If drpConsOthersUnit.Items.Count > 0 AndAlso unitIdStr <> "" AndAlso drpConsOthersUnit.Items.FindByValue(unitIdStr) IsNot Nothing Then
            drpConsOthersUnit.SelectedValue = unitIdStr
        ElseIf drpConsOthersUnit.Items.Count > 0 Then
            drpConsOthersUnit.SelectedIndex = 0
        End If

        txtConsOthersBrandName.Text = Convert.ToString(r("NonFoodBrandName"))
        txtConsOthersForm.Text = Convert.ToString(r("NonFoodForm"))
        txtConsOthersBatch.Text = Convert.ToString(r("NonFoodBatch"))
        txtConsOthersLot.Text = Convert.ToString(r("NonFoodLot"))

        txtMDateConsOthers.Text = Convert.ToString(r("NonFoodMftgdate"))
        txtEDateConsOthers.Text = Convert.ToString(r("NonFoodEpiryDate"))
        txtAlertConsOthers.Text = Convert.ToString(r("NonFoodAlert"))

        txtConsOthersUnitPrice.Text = Convert.ToString(r("UnitCost"))
        txtConsOthersReOrderPt.Text = Convert.ToString(r("ReorderPoint"))
        txtConsOthersQuantity.Text = Convert.ToString(r("Quantity"))





        Dim dtStr As String = Convert.ToString(r("Date"))
        Dim dtVal As DateTime
        If DateTime.TryParse(dtStr, dtVal) Then
            txtSellectDateCons.Text = dtVal.ToString("MM/dd/yyyy")
        Else
            txtSellectDateCons.Text = dtStr
        End If

        Dim whName As String = Convert.ToString(r("Warehouse")).Trim()
        If drpMROConsOthersWarehouse.Items.Count > 0 AndAlso whName <> "" Then
            Dim it As ListItem = drpMROConsOthersWarehouse.Items.FindByText(whName)
            If it IsNot Nothing Then
                drpMROConsOthersWarehouse.ClearSelection()
                it.Selected = True
            Else
                drpMROConsOthersWarehouse.SelectedIndex = 0
            End If
        ElseIf drpMROConsOthersWarehouse.Items.Count > 0 Then
            drpMROConsOthersWarehouse.SelectedIndex = 0
        End If

        txtConsOthersBay.Text = Convert.ToString(r("Bay"))
        txtConsOthersColumn.Text = Convert.ToString(r("Column"))
        txtConsOthersFloor.Text = Convert.ToString(r("Floor"))
        txtConsOthersRoom.Text = Convert.ToString(r("Room"))
        txtConsOthersShelves.Text = Convert.ToString(r("Shelves"))
        txtConsOthersRack.Text = Convert.ToString(r("Rack"))
        txtConsOthersBin.Text = Convert.ToString(r("Bin"))

        btnConsOthersSave.Text = "EDIT"
    End Sub


    Protected Sub btnROP_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub BtnCompute_Click(sender As Object, e As EventArgs)
        Try
            RP.Text = DRP.Text * LTD.Text
            txtConsOthersReOrderPt.Text = DRP.Text * LTD.Text
            ModalPopupExtender1.Show()
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill Demand Per Day & Lead Time For Deliver.")
            ModalPopupExtender1.Show()
        End Try
    End Sub

    Protected Sub btnConsOthersSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        If btnConsOthersSave.Text = "SAVE" Then
            save()

        ElseIf btnConsOthersSave.Text = "EDIT" Then
            loadApprovalOfficer()
            ModalPopupExtenderApproval.Show()

        ElseIf btnConsOthersSave.Text = "UPDATE" Then
            update()
        End If
    End Sub

    Public Sub save()
        Try

            If String.IsNullOrWhiteSpace(txtConsOthersBrandName.Text) OrElse
           String.IsNullOrWhiteSpace(txtConsOthersUnitPrice.Text) OrElse
           String.IsNullOrWhiteSpace(txtConsOthersQuantity.Text) OrElse
           String.IsNullOrWhiteSpace(txtSellectDateCons.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity / Date")
                Exit Sub
            End If

            Dim qtyValue As Decimal
            If Not Decimal.TryParse(txtConsOthersQuantity.Text.Replace(",", ""), qtyValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity is not numeric.")
                Exit Sub
            End If

            Dim unitPriceValue As Decimal
            If Not Decimal.TryParse(txtConsOthersUnitPrice.Text.Replace(",", ""), unitPriceValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unit Price is not numeric.")
                Exit Sub
            End If

            Dim reorderVal As Integer


            Dim selectDateValue As Date
            If Not Date.TryParse(txtSellectDateCons.Text, selectDateValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Date.")
                Exit Sub
            End If

            Dim itemId As Long = Convert.ToInt64(drpConsOthersName.SelectedValue)
            Dim gaId As Long = Convert.ToInt64(ddGlAccount.SelectedValue)

            hdnGAId.Value = gaId.ToString()
            hdnItemNo.Value = itemId.ToString()

            Dim classification As String = Convert.ToString(Session("ClassificationID"))
            If String.IsNullOrEmpty(classification) Then
                classification = objDerived.GetValue("SELECT ClassificationId FROM dbo.tbl_Classification WHERE ClassificationName = 'MRO Consumables'", CommandType.Text)
                Session("ClassificationID") = classification
            End If

            Dim categoryId As String = objDerived.GetValue(
            "SELECT a.item_particular_id " &
            "FROM dbo.m_item AS a INNER JOIN ams.item_particular AS b ON a.item_particular_id = b.item_particular_id " &
            "WHERE a.Item_ID = " & itemId,
            CommandType.Text
        )

            Dim matrix As String = objDerived.GetValue(
            "SELECT id FROM dbo.tblclassmatrix " &
            "WHERE classificationid = " & classification &
            " AND ga_id = " & gaId &
            " AND item_id = " & itemId,
            CommandType.Text
        )

            If String.IsNullOrEmpty(matrix) Then
                objDerived.Execute(
                "INSERT INTO dbo.tblclassmatrix(classificationid, ga_id, item_id, categoryid, bga_id) " &
                "VALUES(" & classification & "," & gaId & "," & itemId & "," & categoryId & ",0)",
                CommandType.Text
            )
            End If

            '========================
            ' RECEIVING HEADER
            '========================
            Dim rcv As New Receiving.t_receiving
            With rcv
                .Received_Date = Date.Today
                .ReceivedBY = 0
                .POHdr_ID = 0
                .PO_No = "Starting Inventory"
                .Supplier_ID = 0
                .GA_ID = Convert.ToInt32(gaId)
                .isAccepted = False
                .UserID = Convert.ToString(Session("@UserName"))
            End With

            Dim rcvID As Long = rcv.save()
            If rcvID <= 0 Then Throw New Exception("Failed to save AMS.Tb_Receiving.")
            Session("Received_ID") = rcvID

            '========================
            ' LOCATION STRING (clean build)
            '========================
            Dim locationBuilder As New System.Text.StringBuilder()
            If Not String.IsNullOrWhiteSpace(txtConsOthersBay.Text) Then locationBuilder.Append("Bay-").Append(txtConsOthersBay.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersColumn.Text) Then locationBuilder.Append(" Column-").Append(txtConsOthersColumn.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersFloor.Text) Then locationBuilder.Append(" Floor-").Append(txtConsOthersFloor.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersRoom.Text) Then locationBuilder.Append(" Room-").Append(txtConsOthersRoom.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersShelves.Text) Then locationBuilder.Append(" Shelves-").Append(txtConsOthersShelves.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersRack.Text) Then locationBuilder.Append(" Rack-").Append(txtConsOthersRack.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersBin.Text) Then locationBuilder.Append(" Bin-").Append(txtConsOthersBin.Text)

            Dim location As String = locationBuilder.ToString()

            '========================
            ' RECEIVING DETAIL
            '========================
            Dim rcv_dtl As New Receiving.t_receiving_dtl
            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = itemId
                .PO_Qty = qtyValue
                .Qty_Received = qtyValue
                .Cost = unitPriceValue
                .Condition = ""
                .Location = location
            End With

            Dim rcvDtl_ID As Long = rcv_dtl.save()
            If rcvDtl_ID <= 0 Then Throw New Exception("Failed to save AMS.Tb_Receiving_Dtl.")

            Dim total As Decimal = qtyValue * unitPriceValue
            Session("ContractPrice") = total

            '=========================================================
            ' NOTE: PO_HDR and PO_DTL are intentionally NOT used here
            '=========================================================
            Dim POnumber As String = "Starting Inventory"
            Dim pohdr_id As Long = 0 ' keep variable pattern; DO NOT save/update PO tables.

            '========================
            ' AIR HEADER
            '========================
            Dim airNo As String = objDerived.GetValue(
            "EXEC [AMS].[sp_Generate_AIR_No] '" & selectDateValue.ToString("MM/dd/yyyy") & "'",
            CommandType.Text
        )

            Dim objhdr As New t_inspection_and_acceptance_hdr
            With objhdr
                .AIR_No = airNo
                .AIR_Date = Date.Today
                .Date_Received = Date.Today
                .Date_Inspect = Date.Today
                .Date_Accepted = Date.Today
                .Invoice_No = ""
                .Invoice_date = Date.Today
                .PO_No = POnumber
                .Supplier_ID = 0
                .Signatory1 = ""
                .Signatory2 = ""
                .Signatory3 = ""
                .isComplete = True
                .POHdr_ID = 0
                .RC_ID = 0
                .Function_ID = 0
            End With

            Dim airhdr_id As Long = objhdr.save()
            If airhdr_id <= 0 Then Throw New Exception("Failed to save AMS.AIR_Hdr.")
            Session("AIRHDR_ID") = airhdr_id

            objDerived.Execute(
            "UPDATE AMS.AIR_Hdr SET UserID = '" & Replace(Convert.ToString(Session("@UserName")), "'", "''") & "', Received_ID = " & rcvID & " WHERE AIRHdr_ID = " & airhdr_id,
            CommandType.Text
        )

            '========================
            ' AIR DETAIL
            '========================
            Dim objdtl As New t_inspection_and_acceptance_dtl
            objdtl.Item_ID = itemId
            objdtl.Qty = qtyValue
            objdtl.Cost = unitPriceValue
            objdtl.AIRHdr_ID = airhdr_id
            objdtl.GA_ID = Convert.ToInt32(gaId)

            Dim iaDtl_ID As Integer = objdtl.save()
            If iaDtl_ID <= 0 Then Throw New Exception("Failed to save AMS.AIR_Dtl.")
            Session("AIRDtl_ID") = iaDtl_ID

            '========================
            ' STOCK
            '========================
            Dim whVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpMROConsOthersWarehouse.SelectedValue), whVal)

            Dim rcParsed As Integer = 0
            Dim rcValString As String = objDerived.GetValue(
            "SELECT TOP 1 [RC_id] FROM [dbo].[View_RespCenter_withFunctions] WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'",
            CommandType.Text
        )
            If Not String.IsNullOrEmpty(rcValString) AndAlso IsNumeric(rcValString) Then rcParsed = Convert.ToInt32(rcValString)

            Dim objStock As New Supplies_Stock
            With objStock
                .StockDate = Date.Today
                .Item_ID = itemId
                .Qty = qtyValue
                .Balance = qtyValue
                .Location = location
                .Expiration_Date = DateTime.Parse("01/01/1900")
                .Cost = unitPriceValue
                .Issuance = 0
                .RC_ID = rcParsed
                .Function_ID = 0
                .Project_ID = 0
                .Program_id = 0
                .F_ID = 4
                .AIRDtl_ID = iaDtl_ID
                .GA_ID = Convert.ToInt32(gaId)
                .Warehouseid = whVal
                .ReorderPt = reorderVal
            End With

            Dim StockID As Long = objStock.save()
            If StockID <= 0 Then Throw New Exception("Failed to save AMS.Stock.")

            objDerived.Execute("UPDATE AMS.Stock SET AIR_HDR_ID = 0, Received_ID = " & rcvID & " WHERE StockID = " & StockID, CommandType.Text)

            '========================
            ' STOCK LEDGER (Starting Balance)
            '========================
            Dim unitDesc As String = objDerived.GetValue(
            "SELECT TOP 1 AMS.m_Unit.Description FROM AMS.m_Unit " &
            "INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID " &
            "WHERE dbo.m_item.Item_ID = " & itemId,
            CommandType.Text
        )

            Dim objStockLedger As New t_StockLedger
            With objStockLedger
                .StockID = StockID
                .Trans_Type = "Starting Balance"
                .Ref = airNo
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .ReceivedBy = ""
                .CreditQty = 0
                .CreditUnit = "-"
                .CreditCost = 0D
                .dDate = selectDateValue
                .Item_ID = itemId
                .DebitQty = qtyValue
                .DebitCost = Decimal.Round(unitPriceValue * qtyValue, 2)
                .DebitUnit = unitDesc
                .BalanceUnit = unitDesc
                .BalanceQty = qtyValue
                .BalanceCost = Decimal.Round(unitPriceValue * qtyValue, 2)
            End With
            objStockLedger.save()

            '========================
            ' TBNONFOOD INSERT (Consumables details)
            '========================
            Dim depRateDec As Decimal = 0D
            Dim depYearInt As Integer = 0

            Dim depRateStr As String = Convert.ToString(objDerived.GetValue(
            "SELECT ISNULL(DepRate,0) FROM dbo.m_item WHERE Item_ID = " & itemId,
            CommandType.Text
        ))
            Decimal.TryParse(depRateStr, depRateDec)

            Dim depYearStr As String = Convert.ToString(objDerived.GetValue(
            "SELECT ISNULL(DepYear,0) FROM dbo.m_item WHERE Item_ID = " & itemId,
            CommandType.Text
        ))
            Integer.TryParse(depYearStr, depYearInt)

            Dim depValue As Decimal = Decimal.Round(total * (depRateDec / 100D), 2)
            Dim salvageValue As Decimal = Decimal.Round(total - depValue, 2)

            Dim mftgDateVal As DateTime
            Dim expiryDateVal As DateTime
            Dim alertDateVal As DateTime

            Dim mftgSql As String = "NULL"
            Dim expirySql As String = "NULL"
            Dim alertSql As String = "NULL"

            If DateTime.TryParse(txtMDateConsOthers.Text, mftgDateVal) Then
                mftgSql = "'" & mftgDateVal.ToString("MM/dd/yyyy") & "'"
            End If
            If DateTime.TryParse(txtEDateConsOthers.Text, expiryDateVal) Then
                expirySql = "'" & expiryDateVal.ToString("MM/dd/yyyy") & "'"
            End If
            If DateTime.TryParse(txtAlertConsOthers.Text, alertDateVal) Then
                alertSql = "'" & alertDateVal.ToString("MM/dd/yyyy") & "'"
            End If

            Dim deliveryDateSql As String = "'" & selectDateValue.ToString("MM/dd/yyyy") & "'"

            Dim itemDesc As String = drpConsOthersName.SelectedItem.Text

            Dim sqlNonFood As String =
            "INSERT INTO AMS.TbNonFood " &
            "(StockId, AIRDtl_ID, Received_ID, Item_ID, Unit_ID, Form, OTCRx, Mftgdate, Batch, Lot, ActualPrice, EpiryDate, Alert, ItemDesc, BrandName, Supplier_ID, DeliveryDate, Storage, DepreciationRate, DepreciationValue, Status, UploadedBy, DateUploaded, Dimension, PowerInput, Model, AreaCapacity, Warranty, MarketValue, NoYears, UsefulLife, SalvageValue, Specs) " &
            "VALUES (" &
            StockID & ", " &
            iaDtl_ID & ", " &
            rcvID & ", " &
            itemId & ", " &
            Convert.ToInt32(drpConsOthersUnit.SelectedValue) & ", " &
            "'" & Replace(txtConsOthersForm.Text.Trim(), "'", "''") & "', " &
            "NULL, " &
            mftgSql & ", " &
            "'" & Replace(txtConsOthersBatch.Text.Trim(), "'", "''") & "', " &
            "'" & Replace(txtConsOthersLot.Text.Trim(), "'", "''") & "', " &
            unitPriceValue.ToString() & ", " &
            expirySql & ", " &
            alertSql & ", " &
            "'" & Replace(itemDesc.Trim(), "'", "''") & "', " &
            "'" & Replace(txtConsOthersBrandName.Text.Trim(), "'", "''") & "', " &
            "0, " &
            deliveryDateSql & ", " &
            "NULL, " &
            "'" & Replace(depRateDec.ToString(), "'", "''") & "', " &
            depValue.ToString() & ", " &
            "'Received', " &
            "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " &
            depYearInt.ToString() & ", " &
            depYearInt.ToString() & ", " &
            salvageValue.ToString() & ", " &
            "NULL" &
            ")"

            objDerived.Execute(sqlNonFood, CommandType.Text)

            LoadLedger()
            ClearTextBoxesCons()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.Message)
        End Try
    End Sub




    Public Sub update()
        Try
            Dim stockObj As Object = grdLedger.SelectedDataKey("StockID")
            Dim stockID As Long = 0
            If stockObj IsNot Nothing AndAlso Not IsDBNull(stockObj) Then
                Long.TryParse(stockObj.ToString(), stockID)
            End If

            If stockID <= 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a ledger row to edit.")
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtConsOthersBrandName.Text) OrElse
           String.IsNullOrWhiteSpace(txtConsOthersUnitPrice.Text) OrElse
           String.IsNullOrWhiteSpace(txtConsOthersQuantity.Text) OrElse
           String.IsNullOrWhiteSpace(txtSellectDateCons.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill up the required Fields: Name / Brand Name / Unit Cost / Quantity  / Date")
                Exit Sub
            End If

            Dim qtyValue As Decimal
            If Not Decimal.TryParse(txtConsOthersQuantity.Text.Replace(",", ""), qtyValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity is not numeric.")
                Exit Sub
            End If

            Dim unitPriceValue As Decimal
            If Not Decimal.TryParse(txtConsOthersUnitPrice.Text.Replace(",", ""), unitPriceValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unit Price is not numeric.")
                Exit Sub
            End If

            Dim reorderVal As Integer

            Dim selectDateValue As Date
            If Not Date.TryParse(txtSellectDateCons.Text, selectDateValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Date.")
                Exit Sub
            End If

            Dim itemId As Long = 0
            Long.TryParse(Convert.ToString(drpConsOthersName.SelectedValue), itemId)

            Dim gaId As Long = 0
            Long.TryParse(Convert.ToString(ddGlAccount.SelectedValue), gaId)

            If itemId <= 0 OrElse gaId <= 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select Name and General Account.")
                Exit Sub
            End If

            Dim whVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpMROConsOthersWarehouse.SelectedValue), whVal)

            Dim unitIdVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpConsOthersUnit.SelectedValue), unitIdVal)

            Dim locationBuilder As New System.Text.StringBuilder()
            If Not String.IsNullOrWhiteSpace(txtConsOthersBay.Text) Then locationBuilder.Append("Bay-").Append(txtConsOthersBay.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersColumn.Text) Then locationBuilder.Append(" Column-").Append(txtConsOthersColumn.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersFloor.Text) Then locationBuilder.Append(" Floor-").Append(txtConsOthersFloor.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersRoom.Text) Then locationBuilder.Append(" Room-").Append(txtConsOthersRoom.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersShelves.Text) Then locationBuilder.Append(" Shelves-").Append(txtConsOthersShelves.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersRack.Text) Then locationBuilder.Append(" Rack-").Append(txtConsOthersRack.Text)
            If Not String.IsNullOrWhiteSpace(txtConsOthersBin.Text) Then locationBuilder.Append(" Bin-").Append(txtConsOthersBin.Text)

            Dim location As String = locationBuilder.ToString()
            Dim locEsc As String = Replace(location, "'", "''")

            Dim brand As String = Replace(txtConsOthersBrandName.Text.Trim(), "'", "''")
            Dim formVal As String = Replace(txtConsOthersForm.Text.Trim(), "'", "''")
            Dim batchVal As String = Replace(txtConsOthersBatch.Text.Trim(), "'", "''")
            Dim lotVal As String = Replace(txtConsOthersLot.Text.Trim(), "'", "''")

            Dim depRateDec As Decimal = 0D
            Dim depYearInt As Integer = 0

            Dim depRateStr As String = Convert.ToString(objDerived.GetValue(
            "SELECT ISNULL(DepRate,0) FROM dbo.m_item WHERE Item_ID = " & itemId,
            CommandType.Text
        ))
            Decimal.TryParse(depRateStr, depRateDec)

            Dim depYearStr As String = Convert.ToString(objDerived.GetValue(
            "SELECT ISNULL(DepYear,0) FROM dbo.m_item WHERE Item_ID = " & itemId,
            CommandType.Text
        ))
            Integer.TryParse(depYearStr, depYearInt)

            Dim total As Decimal = qtyValue * unitPriceValue
            Dim depValue As Decimal = Decimal.Round(total * (depRateDec / 100D), 2)
            Dim salvageValue As Decimal = Decimal.Round(total - depValue, 2)

            Dim mftgDateVal As DateTime
            Dim expiryDateVal As DateTime
            Dim alertDateVal As DateTime

            Dim mftgSql As String = "NULL"
            Dim expirySql As String = "NULL"
            Dim alertSql As String = "NULL"

            If DateTime.TryParse(txtMDateConsOthers.Text, mftgDateVal) Then
                mftgSql = "'" & mftgDateVal.ToString("yyyy-MM-dd") & "'"
            End If
            If DateTime.TryParse(txtEDateConsOthers.Text, expiryDateVal) Then
                expirySql = "'" & expiryDateVal.ToString("yyyy-MM-dd") & "'"
            End If
            If DateTime.TryParse(txtAlertConsOthers.Text, alertDateVal) Then
                alertSql = "'" & alertDateVal.ToString("yyyy-MM-dd") & "'"
            End If

            objDerived.Execute(
            "UPDATE AMS.Stock SET " &
            "Item_ID = " & itemId & ", " &
            "GA_ID = " & gaId & ", " &
            "Cost = " & unitPriceValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "ReorderPt = " & reorderVal & ", " &
            "StockDate = '" & selectDateValue.ToString("yyyy-MM-dd") & "', " &
            "Qty = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "Balance = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "Location = '" & locEsc & "', " &
            "Warehouse_ID = " & whVal & " " &
            "WHERE StockID = " & stockID,
            CommandType.Text
        )

            Dim itemDesc As String = Replace(drpConsOthersName.SelectedItem.Text.Trim(), "'", "''")

            objDerived.Execute(
            "UPDATE AMS.TbNonFood SET " &
            "Item_ID = " & itemId & ", " &
            "Unit_ID = " & unitIdVal & ", " &
            "Form = '" & formVal & "', " &
            "Mftgdate = " & mftgSql & ", " &
            "Batch = '" & batchVal & "', " &
            "Lot = '" & lotVal & "', " &
            "ActualPrice = " & unitPriceValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "EpiryDate = " & expirySql & ", " &
            "Alert = " & alertSql & ", " &
            "ItemDesc = '" & itemDesc & "', " &
            "BrandName = '" & brand & "', " &
            "DeliveryDate = '" & selectDateValue.ToString("yyyy-MM-dd") & "', " &
            "DepreciationRate = '" & Replace(depRateDec.ToString(), "'", "''") & "', " &
            "DepreciationValue = " & depValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "NoYears = " & depYearInt.ToString() & ", " &
            "UsefulLife = " & depYearInt.ToString() & ", " &
            "SalvageValue = " & salvageValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & " " &
            "WHERE StockId = " & stockID,
            CommandType.Text
        )

            Dim unitDesc As String = objDerived.GetValue(
            "SELECT TOP 1 AMS.m_Unit.Description FROM AMS.m_Unit " &
            "INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID " &
            "WHERE dbo.m_item.Item_ID = " & itemId,
            CommandType.Text
        )
            unitDesc = Replace(Convert.ToString(unitDesc), "'", "''")

            objDerived.Execute(
            "WITH x AS (" &
            "   SELECT TOP 1 * " &
            "   FROM AMS.TbStock_Ledger " &
            "   WHERE StockID = " & stockID & " AND Trans_Type = 'Starting Balance' " &
            "   ORDER BY dDate ASC " &
            ") " &
            "UPDATE x SET " &
            "   dDate = '" & selectDateValue.ToString("yyyy-MM-dd") & "', " &
            "   Item_ID = " & itemId & ", " &
            "   DebitQty = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "   DebitCost = ROUND(" & (qtyValue * unitPriceValue).ToString(System.Globalization.CultureInfo.InvariantCulture) & ", 2), " &
            "   DebitUnit = '" & unitDesc & "', " &
            "   BalanceUnit = '" & unitDesc & "', " &
            "   BalanceQty = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "   BalanceCost = ROUND(" & (qtyValue * unitPriceValue).ToString(System.Globalization.CultureInfo.InvariantCulture) & ", 2) ",
            CommandType.Text
        )

            LoadLedger()
            ClearTextBoxesCons()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.Message)
        End Try
    End Sub


    Protected Sub btnConsOthersCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        ClearTextBoxesCons()
    End Sub

    Private Sub AddTrace(ByVal message As String)

        Dim safeMessage As String =
            message.Replace("'", "\'")

        ScriptManager.RegisterClientScriptBlock(
            Me,
            Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)

    End Sub

    Private Sub BindEmptyLedger()
        Dim dt As New DataTable()
        dt.Columns.Add("dDate", GetType(Date))
        dt.Columns.Add("Trans_Type", GetType(String))
        dt.Columns.Add("ref", GetType(String))
        dt.Columns.Add("AccountablePerson", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("position", GetType(String))
        dt.Columns.Add("acceptedby", GetType(String))
        dt.Columns.Add("BalanceUnit", GetType(String))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("DebitQty", GetType(Decimal))
        dt.Columns.Add("DebitCost", GetType(Decimal))
        dt.Columns.Add("CreditQty", GetType(Decimal))
        dt.Columns.Add("CreditCost", GetType(Decimal))
        dt.Columns.Add("BalQty", GetType(Decimal))
        dt.Columns.Add("BalCost", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("StockID", GetType(Long))

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdLedger.DataSource = dt
        grdLedger.DataBind()
    End Sub



    Private Sub loadApprovalOfficer()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT approvalid,full_name FROM ams.tbl_approval", CommandType.Text)

        drpApprovedOfficer.DataSource = dt
        drpApprovedOfficer.DataTextField = ("full_name")
        drpApprovedOfficer.DataValueField = ("approvalid")
        drpApprovedOfficer.DataBind()
    End Sub

    Protected Sub btnApprovalProceed_Click(sender As Object, e As EventArgs)
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
            ModalPopupExtenderApproval.Show()
        Else
            btnConsOthersSave.Text = "UPDATE"
            btnConsOthersSave.Enabled = True
            txtApprovedPass.Text = ""
            ModalPopupExtenderApproval.Hide()
        End If
    End Sub

    Protected Sub btnApprovalCancel_Click(sender As Object, e As EventArgs)
        txtApprovedPass.Text = ""
        ModalPopupExtenderApproval.Hide()
    End Sub

    Private Function DecryptEncrypt(ByVal TheText As String) As String
        Dim tempChar As String = Nothing
        Dim i As Integer = 0

        For i = 1 To TheText.Length
            If Convert.ToInt32(TheText.Chars(i - 1)) < 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) + 100)
            ElseIf Convert.ToInt32(TheText.Chars(i - 1)) > 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) - 100)
            End If

            TheText = TheText.Remove(i - 1, 1).Insert(i - 1, (CChar(ChrW(tempChar))).ToString())
        Next i

        Return TheText
    End Function


End Class
