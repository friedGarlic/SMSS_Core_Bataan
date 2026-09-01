Imports System.Data
Imports System.Data.SqlClient

Partial Class Records_t_StockCard_Rev_Food
    Inherits System.Web.UI.Page

    Private objDerived As New BaseClasses.AccountClassAcounts

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim classification As String = objDerived.GetValue("SELECT ClassificationId FROM dbo.tbl_Classification WHERE ClassificationName = 'Food'", CommandType.Text)
            Session("ClassificationID") = classification

            LoadSubClassifications()
            LoadGLAccounts()
            ClearItemDesc()
            LoadWarehouse()
            ClearTextBoxesFood()
            BindEmptyLedger()
        End If
    End Sub

    Private Sub LoadSubClassifications()
        Dim dt As DataTable = objDerived.GetDataTable(
                "select distinct a.SubClassificationID,a.SubClassificationName " &
                "From tbl_SubClassification As a " &
                " inner join tblclassmatrix as b on a.SubClassificationID = b.SubClassificationID " &
                " inner join tbl_Classification As c On b.classificationid = c.ClassificationId " &
                " where c.ClassificationId = '" & Session("ClassificationID") & "'",
                CommandType.Text
            )

        Dim dr As DataRow = dt.NewRow()
        dr("SubClassificationID") = 0
        dr("SubClassificationName") = "Select"
        dt.Rows.InsertAt(dr, 0)

        DrpSubClass.DataSource = dt
        DrpSubClass.DataTextField = "SubClassificationName"
        DrpSubClass.DataValueField = "SubClassificationID"
        DrpSubClass.DataBind()

        ddGlAccount.Items.Clear()
        ddGlAccount.Items.Insert(0, New ListItem("Select", "0"))




    End Sub

    Private Sub LoadGLAccounts()
        ddGlAccount.Items.Clear()

        Dim dt As DataTable = Nothing

        If DrpSubClass.SelectedValue Is Nothing OrElse DrpSubClass.SelectedValue = "0" Then

            dt = objDerived.GetDataTable(
            "EXEC AMS.FMgetGenAccntNoSubClass '" & Session("ClassificationID") & "', 0",
            CommandType.Text
        )

        Else
            AddTrace("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & Session("ClassificationID") & "','" & DrpSubClass.SelectedItem.Value & "'")

            dt = objDerived.GetDataTable(
            "Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & Session("ClassificationID") & "','" & DrpSubClass.SelectedItem.Value & "'",
            CommandType.Text
        )
        End If

        'Insert "Select" row
        If dt IsNot Nothing Then
            Dim dr As DataRow = dt.NewRow()
            dr("GA_ID") = 0
            dr("GA_Title") = "Select"
            dt.Rows.InsertAt(dr, 0)
        End If

        ddGlAccount.DataSource = dt
        ddGlAccount.DataTextField = "GA_Title"
        ddGlAccount.DataValueField = "GA_ID"
        ddGlAccount.DataBind()
    End Sub


    Public Sub LoadWarehouse()
        Dim dt As DataTable = objDerived.GetDataTable("select warehouse_id,wname From ams.loc_warehouse where isUsed='True' order by wname", CommandType.Text)

        drpWarehouse.Items.Clear()
        drpWarehouse.DataTextField = "wname"
        drpWarehouse.DataValueField = "warehouse_id"
        drpWarehouse.DataSource = dt
        drpWarehouse.DataBind()
        drpWarehouse.Items.Insert(0, New ListItem("Select", "0"))
    End Sub

    Public Sub LoadLedger()
        If ddlItemDesc2.SelectedValue Is Nothing OrElse ddlItemDesc2.SelectedValue = "0" Then
            BindEmptyLedger()
            Exit Sub
        End If
        AddTrace("asdasdas")
        AddTrace(ddlItemDesc2.SelectedValue)
        Dim dtStock As DataTable = objDerived.GetDataTable(
            "EXEC [AMS].[sp_SuppliesLedger] '" & ddlItemDesc2.SelectedValue & "'",
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


    Private Sub ClearItemDesc()
        ddlItemDesc2.Items.Clear()
        ddlItemDesc2.Items.Insert(0, New ListItem("Select", "0"))
        ddlItemDesc2.Enabled = False
    End Sub

    Private Sub LoadItemDesc()

        Dim classId As String = Session("ClassificationID").ToString()
        Dim subClassId As String = If(DrpSubClass.SelectedValue Is Nothing, "0", DrpSubClass.SelectedValue.ToString())

        Dim sql As String = ""

        'If no subclass selected (0), show items with NULL/0 SubClassificationID under the selected ClassificationID
        If subClassId = "0" Then
            sql =
            "SELECT DISTINCT " &
            "   i.Item_ID, i.ItemCompleteDesc AS Item_Desc " &
            "FROM dbo.m_item AS i " &
            "LEFT JOIN dbo.m_item_detail AS d ON d.Item_ID = i.Item_ID " &
            "LEFT JOIN dbo.tbl_SubClassification AS sc ON sc.SubClassificationID = i.SubClassificationID " &
            "WHERE i.ClassificationID = " & classId & " " &
            "  AND (i.SubClassificationID IS NULL OR i.SubClassificationID = 0) " &
            "ORDER BY i.ItemCompleteDesc"
        Else
            'If a subclass is selected, filter by that SubClassificationID under the selected ClassificationID
            sql =
            "SELECT DISTINCT " &
            "   i.Item_ID, i.ItemCompleteDesc AS Item_Desc " &
            "FROM dbo.m_item AS i " &
            "LEFT JOIN dbo.m_item_detail AS d ON d.Item_ID = i.Item_ID " &
            "LEFT JOIN dbo.tbl_SubClassification AS sc ON sc.SubClassificationID = i.SubClassificationID " &
            "WHERE i.ClassificationID = " & classId & " " &
            "  AND i.SubClassificationID = " & subClassId & " " &
            "ORDER BY i.ItemCompleteDesc"
        End If

        Dim dtitem As DataTable = objDerived.GetDataTable(sql, CommandType.Text)

        If dtitem IsNot Nothing Then
            Dim dr As DataRow = dtitem.NewRow()
            dr("Item_ID") = 0
            dr("Item_Desc") = "Select"
            dtitem.Rows.InsertAt(dr, 0)
        End If

        ddlItemDesc2.DataSource = dtitem
        ddlItemDesc2.DataTextField = "Item_Desc"
        ddlItemDesc2.DataValueField = "Item_ID"
        ddlItemDesc2.DataBind()

        ddlItemDesc2.Enabled = True
    End Sub






    Protected Sub DrpSubClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadGLAccounts()
        LoadWarehouse()
        ClearTextBoxesFood()
        BindEmptyLedger()
    End Sub

    Protected Sub ddGlAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        hdnGAId.Value = ddGlAccount.SelectedValue

        LoadItemDesc()
        LoadWarehouse()

        ClearTextBoxesFood()
        BindEmptyLedger()    ' <-- better than LoadLedger() at this stage
    End Sub



    Protected Sub ddlItemDesc2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        hdnItemNo.Value = ddlItemDesc2.SelectedValue
        LoadLedger()
    End Sub



    Protected Sub btnFoodSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        If btnFoodSave.Text = "SAVE" Then
            save()
        Else
            update()
        End If
    End Sub

    Public Sub save()
        Try

            If ddlItemDesc2.SelectedValue Is Nothing OrElse ddlItemDesc2.SelectedValue = "0" OrElse
           String.IsNullOrWhiteSpace(txtBrandName2.Text) OrElse
           String.IsNullOrWhiteSpace(txtUnitPrice.Text) OrElse
           String.IsNullOrWhiteSpace(txtQuantity.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill up the required fields: Name / Brand Name / Unit Cost / Quantity.")
                Exit Sub
            End If


            Dim qtyValue As Decimal
            If Not Decimal.TryParse(txtQuantity.Text.Replace(",", ""), qtyValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity is not numeric.")
                Exit Sub
            End If

            Dim unitPriceValue As Decimal
            If Not Decimal.TryParse(txtUnitPrice.Text.Replace(",", ""), unitPriceValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unit Cost is not numeric.")
                Exit Sub
            End If

            hdnGAId.Value = ddGlAccount.SelectedValue

            Dim classification As String = Convert.ToString(Session("ClassificationID"))
            If String.IsNullOrEmpty(classification) Then
                classification = objDerived.GetValue("SELECT ClassificationId FROM dbo.tbl_Classification WHERE ClassificationName = 'Food'", CommandType.Text)
                Session("ClassificationID") = classification
            End If

            ' If you already set hdnItemNo elsewhere, keep it. Otherwise, require it.
            'If String.IsNullOrWhiteSpace(hdnItemNo.Value) OrElse hdnItemNo.Value = "0" Then
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Item No is missing. Please select/load an item first.")
            '    Exit Sub
            'End If

            Dim categoryId As String = objDerived.GetValue(
            "SELECT a.item_particular_id " &
            "FROM dbo.m_item AS a INNER JOIN ams.item_particular AS b ON a.item_particular_id = b.item_particular_id " &
            "WHERE a.Item_ID = " & hdnItemNo.Value,
            CommandType.Text
        )

            Dim matrix As String = objDerived.GetValue(
            "SELECT id FROM tblclassmatrix " &
            "WHERE classificationid = " & classification &
            " AND ga_id = " & hdnGAId.Value &
            " AND item_id = " & hdnItemNo.Value,
            CommandType.Text
        )

            If String.IsNullOrEmpty(matrix) Then
                objDerived.Execute(
                "INSERT INTO tblclassmatrix(classificationid, ga_id, item_id, categoryid, bga_id) " &
                "VALUES(" & classification & "," & hdnGAId.Value & "," & hdnItemNo.Value & "," & categoryId & ",0)",
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
                .GA_ID = Convert.ToInt32(ddGlAccount.SelectedValue)
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
            If Not String.IsNullOrWhiteSpace(txtBay.Text) Then locationBuilder.Append("Bay-").Append(txtBay.Text)
            If Not String.IsNullOrWhiteSpace(txtColumn.Text) Then locationBuilder.Append(" Column-").Append(txtColumn.Text)
            If Not String.IsNullOrWhiteSpace(txtFloor.Text) Then locationBuilder.Append(" Floor-").Append(txtFloor.Text)
            If Not String.IsNullOrWhiteSpace(txtRoom.Text) Then locationBuilder.Append(" Room-").Append(txtRoom.Text)
            If Not String.IsNullOrWhiteSpace(txtShelves.Text) Then locationBuilder.Append(" Shelves-").Append(txtShelves.Text)
            If Not String.IsNullOrWhiteSpace(txtRack.Text) Then locationBuilder.Append(" Rack-").Append(txtRack.Text)
            If Not String.IsNullOrWhiteSpace(txtBin.Text) Then locationBuilder.Append(" Bin-").Append(txtBin.Text)

            Dim location As String = locationBuilder.ToString()

            '========================
            ' RECEIVING DETAIL
            '========================
            Dim rcv_dtl As New Receiving.t_receiving_dtl
            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = Convert.ToInt64(hdnItemNo.Value)
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
            Dim pohdr_id As Long = 0   ' keep variable (unaffected line pattern), but DO NOT save/update PO tables.

            '========================
            ' AIR HEADER
            '========================
            Dim airNo As String = objDerived.GetValue(
            "EXEC [AMS].[sp_Generate_AIR_No] '" & Date.Today.ToString("MM/dd/yyyy") & "'",
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
            objdtl.Item_ID = Convert.ToInt64(hdnItemNo.Value)
            objdtl.Qty = qtyValue
            objdtl.Cost = unitPriceValue
            objdtl.AIRHdr_ID = airhdr_id
            objdtl.GA_ID = Convert.ToInt32(ddGlAccount.SelectedValue)

            Dim iaDtl_ID As Integer = objdtl.save()
            If iaDtl_ID <= 0 Then Throw New Exception("Failed to save AMS.AIR_Dtl.")
            Session("AIRDtl_ID") = iaDtl_ID

            '========================
            ' STOCK
            '========================
            Dim whVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpWarehouse.SelectedValue), whVal)

            Dim rcParsed As Integer = 0
            Dim rcValString As String = objDerived.GetValue(
            "SELECT TOP 1 [RC_id] FROM [dbo].[View_RespCenter_withFunctions] WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'",
            CommandType.Text
        )
            If Not String.IsNullOrEmpty(rcValString) AndAlso IsNumeric(rcValString) Then rcParsed = Convert.ToInt32(rcValString)

            Dim reorderVal As Integer = 0
            Integer.TryParse(Convert.ToString(Val(txtDepRate.Text.Replace(",", ""))), reorderVal) 'placeholder if you later add ROP textbox

            Dim objStock As New Supplies_Stock
            With objStock
                .StockDate = Date.Today
                .Item_ID = Convert.ToInt64(hdnItemNo.Value)
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
                .GA_ID = Convert.ToInt32(ddGlAccount.SelectedValue)
                .Warehouseid = whVal
                .ReorderPt = reorderVal
            End With

            Dim StockID As Long = objStock.save()
            If StockID <= 0 Then Throw New Exception("Failed to save AMS.Stock.")

            objDerived.Execute("UPDATE AMS.Stock SET Received_ID = " & rcvID & " WHERE StockID = " & StockID, CommandType.Text)

            '========================
            ' STOCK LEDGER (Starting Balance)
            '========================
            Dim unitDesc As String = objDerived.GetValue(
            "SELECT TOP 1 AMS.m_Unit.Description FROM AMS.m_Unit " &
            "INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID " &
            "WHERE dbo.m_item.Item_ID = " & hdnItemNo.Value,
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
                .dDate = Date.Today
                .Item_ID = Convert.ToInt64(hdnItemNo.Value)
                .DebitQty = qtyValue
                .DebitCost = Decimal.Round(unitPriceValue * qtyValue, 2)
                .DebitUnit = unitDesc
                .BalanceUnit = unitDesc
                .BalanceQty = qtyValue
                .BalanceCost = Decimal.Round(unitPriceValue * qtyValue, 2)
            End With
            objStockLedger.save()

            '========================
            ' TBSupplies_Info INSERT
            '========================
            Dim unitIdVal As Integer = 0
            Integer.TryParse(Convert.ToString(objDerived.GetValue(
            "SELECT Unit_ID FROM dbo.m_item WHERE Item_ID = " & hdnItemNo.Value,
            CommandType.Text
        )), unitIdVal)

            Dim categoryDesc As String = objDerived.GetValue(
            "SELECT b.description " &
            "FROM dbo.m_item AS a INNER JOIN ams.item_particular AS b ON a.item_particular_id = b.item_particular_id " &
            "WHERE a.Item_ID = " & Convert.ToInt64(hdnItemNo.Value),
            CommandType.Text
        )

            Dim sqlSuppliesInfo As String =
            "INSERT INTO AMS.TBSupplies_Info " &
            "(AIRDtl_ID, ItemId, Received_ID, StockID, Unit_ID, BrandName, Color, Length, Size, Width, Height, Weight, Category, Componentof, DepreciatedRate, DepreciatedValue, Description) " &
            "VALUES " &
            "(" & iaDtl_ID & ", " & Convert.ToInt64(hdnItemNo.Value) & ", " & rcvID & ", " & StockID & ", " & unitIdVal & ", " &
            "'" & Replace(txtBrandName2.Text.Trim(), "'", "''") & "', " &
            "'" & Replace(txtColor.Text.Trim(), "'", "''") & "', " &
            "'" & Replace(txtLenght.Text.Trim(), "'", "''") & "', " &
            "'" & Replace(txtSize.Text.Trim(), "'", "''") & "', " &
            "'" & Replace(txtWidth.Text.Trim(), "'", "''") & "', " &
            "'" & Replace(txtHeight.Text.Trim(), "'", "''") & "', " &
            "'" & Replace(txtWeight.Text.Trim(), "'", "''") & "', " &
            "'" & Replace(Convert.ToString(categoryDesc), "'", "''") & "', " &
            "'" & Replace(txtComponentof.Text.Trim(), "'", "''") & "', " &
            "'" & Replace(txtDepRate.Text.Trim(), "'", "''") & "', " &
            "'" & Replace(txtDepValue.Text.Trim(), "'", "''") & "', " &
            "'" & Replace(ddlItemDesc2.SelectedItem.Text.Trim(), "'", "''") & "'" &
            ")"

            objDerived.Execute(sqlSuppliesInfo, CommandType.Text)

            LoadLedger()
            ClearTextBoxesFood()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.Message)
        End Try
    End Sub


    Public Sub update()
        Try
            '========================
            ' 1) Get selected StockID
            '========================
            Dim stockObj As Object = grdLedger.SelectedDataKey("StockID")
            Dim stockID As Long = 0
            If stockObj IsNot Nothing AndAlso Not IsDBNull(stockObj) Then
                Long.TryParse(stockObj.ToString(), stockID)
            End If

            If stockID <= 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a ledger row to edit.")
                Exit Sub
            End If

            '========================
            ' 2) Validate required fields (Food page)
            '========================
            If ddlItemDesc2.SelectedValue Is Nothing OrElse ddlItemDesc2.SelectedValue = "0" OrElse
               String.IsNullOrWhiteSpace(txtBrandName2.Text) OrElse
               String.IsNullOrWhiteSpace(txtUnitPrice.Text) OrElse
               String.IsNullOrWhiteSpace(txtQuantity.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill up the required fields: Name / Brand Name / Unit Cost / Quantity.")
                Exit Sub
            End If

            '========================
            ' 3) Parse numeric fields
            '========================
            Dim qtyValue As Decimal
            If Not Decimal.TryParse(txtQuantity.Text.Replace(",", ""), qtyValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity is not numeric.")
                Exit Sub
            End If

            Dim unitPriceValue As Decimal
            If Not Decimal.TryParse(txtUnitPrice.Text.Replace(",", ""), unitPriceValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unit Cost is not numeric.")
                Exit Sub
            End If

            Dim itemId As Long = 0
            Long.TryParse(Convert.ToString(ddlItemDesc2.SelectedValue), itemId)

            Dim gaId As Long = 0
            Long.TryParse(Convert.ToString(ddGlAccount.SelectedValue), gaId)

            If itemId <= 0 OrElse gaId <= 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select Name and General Account.")
                Exit Sub
            End If

            Dim whVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpWarehouse.SelectedValue), whVal)

            '========================
            ' 4) Build location string (same format as save())
            '========================
            Dim locationBuilder As New System.Text.StringBuilder()
            If Not String.IsNullOrWhiteSpace(txtBay.Text) Then locationBuilder.Append("Bay-").Append(txtBay.Text)
            If Not String.IsNullOrWhiteSpace(txtColumn.Text) Then locationBuilder.Append(" Column-").Append(txtColumn.Text)
            If Not String.IsNullOrWhiteSpace(txtFloor.Text) Then locationBuilder.Append(" Floor-").Append(txtFloor.Text)
            If Not String.IsNullOrWhiteSpace(txtRoom.Text) Then locationBuilder.Append(" Room-").Append(txtRoom.Text)
            If Not String.IsNullOrWhiteSpace(txtShelves.Text) Then locationBuilder.Append(" Shelves-").Append(txtShelves.Text)
            If Not String.IsNullOrWhiteSpace(txtRack.Text) Then locationBuilder.Append(" Rack-").Append(txtRack.Text)
            If Not String.IsNullOrWhiteSpace(txtBin.Text) Then locationBuilder.Append(" Bin-").Append(txtBin.Text)

            Dim location As String = locationBuilder.ToString()
            Dim locEsc As String = Replace(location, "'", "''")

            '========================
            ' 5) Update AMS.Stock
            '========================
            objDerived.Execute(
                "UPDATE AMS.Stock SET " &
                "Item_ID = " & itemId & ", " &
                "GA_ID = " & gaId & ", " &
                "Cost = " & unitPriceValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
                "Qty = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
                "Balance = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
                "Location = '" & locEsc & "', " &
                "Warehouse_ID = " & whVal & " " &
                "WHERE StockID = " & stockID,
                CommandType.Text
            )

            '========================
            ' 6) Update AMS.TBSupplies_Info (latest row for this StockID)
            '========================

            ' Get Unit_ID and Category (same way as save())
            Dim unitIdVal As Integer = 0
            Integer.TryParse(Convert.ToString(objDerived.GetValue(
                "SELECT Unit_ID FROM dbo.m_item WHERE Item_ID = " & itemId,
                CommandType.Text
            )), unitIdVal)

            Dim categoryDesc As String = Convert.ToString(objDerived.GetValue(
                "SELECT b.description " &
                "FROM dbo.m_item AS a INNER JOIN ams.item_particular AS b ON a.item_particular_id = b.item_particular_id " &
                "WHERE a.Item_ID = " & itemId,
                CommandType.Text
            ))
            categoryDesc = Replace(categoryDesc, "'", "''")

            Dim brand As String = Replace(txtBrandName2.Text.Trim(), "'", "''")
            Dim colorVal As String = Replace(txtColor.Text.Trim(), "'", "''")
            Dim lengthVal As String = Replace(txtLenght.Text.Trim(), "'", "''")
            Dim sizeVal As String = Replace(txtSize.Text.Trim(), "'", "''")
            Dim widthVal As String = Replace(txtWidth.Text.Trim(), "'", "''")
            Dim heightVal As String = Replace(txtHeight.Text.Trim(), "'", "''")
            Dim weightVal As String = Replace(txtWeight.Text.Trim(), "'", "''")
            Dim componentVal As String = Replace(txtComponentof.Text.Trim(), "'", "''")
            Dim depRateVal As String = Replace(txtDepRate.Text.Trim(), "'", "''")
            Dim depValueVal As String = Replace(txtDepValue.Text.Trim(), "'", "''")
            Dim descVal As String = Replace(ddlItemDesc2.SelectedItem.Text.Trim(), "'", "''")

            objDerived.Execute(
                "WITH x AS (" &
                "   SELECT TOP 1 * " &
                "   FROM AMS.TBSupplies_Info " &
                "   WHERE StockID = " & stockID & " " &
                "   ORDER BY SuppliesId DESC " &
                ") " &
                "UPDATE x SET " &
                "   ItemId = " & itemId & ", " &
                "   Unit_ID = " & unitIdVal & ", " &
                "   BrandName = '" & brand & "', " &
                "   Color = '" & colorVal & "', " &
                "   Length = '" & lengthVal & "', " &
                "   Size = '" & sizeVal & "', " &
                "   Width = '" & widthVal & "', " &
                "   Height = '" & heightVal & "', " &
                "   Weight = '" & weightVal & "', " &
                "   Category = '" & categoryDesc & "', " &
                "   Componentof = '" & componentVal & "', " &
                "   DepreciatedRate = '" & depRateVal & "', " &
                "   DepreciatedValue = '" & depValueVal & "', " &
                "   Description = '" & descVal & "'",
                CommandType.Text
            )

            '========================
            ' 7) Update Starting Balance in AMS.TbStock_Ledger
            '========================
            Dim unitDesc As String = Convert.ToString(objDerived.GetValue(
                "SELECT TOP 1 AMS.m_Unit.Description FROM AMS.m_Unit " &
                "INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID " &
                "WHERE dbo.m_item.Item_ID = " & itemId,
                CommandType.Text
            ))
            unitDesc = Replace(unitDesc, "'", "''")

            objDerived.Execute(
                "WITH x AS (" &
                "   SELECT TOP 1 * " &
                "   FROM AMS.TbStock_Ledger " &
                "   WHERE StockID = " & stockID & " AND Trans_Type = 'Starting Balance' " &
                "   ORDER BY dDate ASC " &
                ") " &
                "UPDATE x SET " &
                "   Item_ID = " & itemId & ", " &
                "   DebitQty = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
                "   DebitCost = ROUND(" & (qtyValue * unitPriceValue).ToString(System.Globalization.CultureInfo.InvariantCulture) & ", 2), " &
                "   DebitUnit = '" & unitDesc & "', " &
                "   BalanceUnit = '" & unitDesc & "', " &
                "   BalanceQty = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
                "   BalanceCost = ROUND(" & (qtyValue * unitPriceValue).ToString(System.Globalization.CultureInfo.InvariantCulture) & ", 2)",
                CommandType.Text
            )

            '========================
            ' 8) Refresh UI
            '========================
            LoadLedger()
            ClearTextBoxesFood()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.Message)
        End Try
    End Sub


    Protected Sub btnFoodCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        ClearTextBoxesFood()
        BindEmptyLedger()
    End Sub

    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        If cb Is Nothing Then Exit Sub

        Dim row As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
        If row Is Nothing Then Exit Sub

        grdLedger.SelectedIndex = row.RowIndex

        If Not cb.Checked Then
            ClearTextBoxesFood()
            Exit Sub
        End If

        Dim stockObj As Object = grdLedger.SelectedDataKey("StockID")
        Dim stockID As Long = 0
        If stockObj IsNot Nothing AndAlso Not IsDBNull(stockObj) Then
            Long.TryParse(stockObj.ToString(), stockID)
        End If

        If stockID <= 0 Then
            ClearTextBoxesFood()
            Exit Sub
        End If

        LoadItemDesc()
        LoadFoodDetailsFromStock(stockID)

    End Sub

    Private Sub LoadFoodDetailsFromStock(ByVal stockID As Long)

        ' 1) Get data from SP
        Dim dt As DataTable = objDerived.GetDataTable("EXEC AMS.sp_Encoding_Food " & stockID, CommandType.Text)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearTextBoxesFood()
            Exit Sub
        End If

        Dim r As DataRow = dt.Rows(0)

        ' Helper to avoid DBNull issues
        Dim GetStr As Func(Of String, String) =
            Function(col As String)
                If Not dt.Columns.Contains(col) OrElse IsDBNull(r(col)) Then Return ""
                Return Convert.ToString(r(col)).Trim()
            End Function

        ' 2) Read IDs
        Dim itemIdStr As String = GetStr("Item_ID")
        Dim gaIdStr As String = GetStr("GA_ID")
        Dim whIdStr As String = GetStr("Warehouse_ID")

        hdnItemNo.Value = itemIdStr
        hdnGAId.Value = gaIdStr

        ' 3) Ensure upper dropdowns are selected/bound (SubClass -> GA -> Item list)
        '    This is important because ddlItemDesc2 must have items before SelectedValue works.

        ' Set GA dropdown if possible
        If ddGlAccount.Items.Count > 0 AndAlso gaIdStr <> "" AndAlso ddGlAccount.Items.FindByValue(gaIdStr) IsNot Nothing Then
            ddGlAccount.SelectedValue = gaIdStr
        End If

        ' LoadItemDesc uses DrpSubClass.SelectedValue as filter.
        ' If you want perfect auto-selection of SubClass as well, the SP must return SubClassificationID.
        ' For now: ensure item list is loaded (will work if user already selected subclass/GA).
        LoadItemDesc()

        ' 4) Select item in ddlItemDesc2 safely (avoid firing SelectedIndexChanged logic)
        Dim oldAutoPostBack As Boolean = ddlItemDesc2.AutoPostBack
        ddlItemDesc2.AutoPostBack = False

        If ddlItemDesc2.Items.Count > 0 AndAlso itemIdStr <> "" AndAlso ddlItemDesc2.Items.FindByValue(itemIdStr) IsNot Nothing Then
            ddlItemDesc2.SelectedValue = itemIdStr
        ElseIf ddlItemDesc2.Items.Count > 0 Then
            ddlItemDesc2.SelectedIndex = 0
        End If

        ddlItemDesc2.AutoPostBack = oldAutoPostBack

        ' 5) Fill text fields
        txtBrandName2.Text = GetStr("BrandName")
        txtSize.Text = GetStr("Size")
        txtColor.Text = GetStr("Color")

        txtLenght.Text = GetStr("Length")
        txtWidth.Text = GetStr("Width")
        txtHeight.Text = GetStr("Height")
        txtWeight.Text = GetStr("Weight")

        txtComponentof.Text = GetStr("ComponentOf")
        txtUnitPrice.Text = GetStr("UnitCost")
        txtQuantity.Text = GetStr("Quantity")

        txtDepRate.Text = GetStr("DepRate")
        txtDepValue.Text = GetStr("DepValue")

        ' 6) Warehouse
        If drpWarehouse.Items.Count > 0 AndAlso whIdStr <> "" AndAlso drpWarehouse.Items.FindByValue(whIdStr) IsNot Nothing Then
            drpWarehouse.SelectedValue = whIdStr
        ElseIf drpWarehouse.Items.Count > 0 Then
            drpWarehouse.SelectedIndex = 0
        End If

        ' 7) Location fields (parsed by SP)
        txtBay.Text = GetStr("Bay")
        txtColumn.Text = GetStr("Column")
        txtFloor.Text = GetStr("Floor")
        txtRoom.Text = GetStr("Room")
        txtShelves.Text = GetStr("Shelves")
        txtRack.Text = GetStr("Rack")
        txtBin.Text = GetStr("Bin")

        btnFoodSave.Text = "UPDATE"
    End Sub

    Protected Sub grdLedger_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
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

    Private Sub ClearTextBoxesFood()
        hdnItemNo.Value = ""
        hdnGAId.Value = ""

        If ddlItemDesc2.Items.Count > 0 Then
            ddlItemDesc2.SelectedIndex = 0
        End If

        txtBrandName2.Text = ""
        txtSize.Text = ""
        txtColor.Text = ""

        txtLenght.Text = ""
        txtWidth.Text = ""
        txtHeight.Text = ""
        txtWeight.Text = ""

        txtComponentof.Text = ""
        txtUnitPrice.Text = ""
        txtQuantity.Text = ""

        txtDepRate.Text = ""
        txtDepValue.Text = ""

        If drpWarehouse IsNot Nothing AndAlso drpWarehouse.Items.Count > 0 Then
            drpWarehouse.ClearSelection()
            drpWarehouse.SelectedIndex = 0
        End If

        txtBay.Text = ""
        txtColumn.Text = ""
        txtFloor.Text = ""
        txtRoom.Text = ""
        txtShelves.Text = ""
        txtRack.Text = ""
        txtBin.Text = ""

        grdLedger.SelectedIndex = -1
        For Each row As GridViewRow In grdLedger.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim cb As CheckBox = TryCast(row.FindControl("cbInspection"), CheckBox)
                If cb IsNot Nothing Then cb.Checked = False
            End If
        Next

        btnFoodSave.Text = "SAVE"
        btnFoodSave.Enabled = True
    End Sub

End Class
