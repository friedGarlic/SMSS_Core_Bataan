Imports System.Data
Imports System.Data.SqlClient

Partial Class Records_t_StockCard_Rev
    Inherits System.Web.UI.Page

    Private objDerived As New BaseClasses.AccountClassAcounts

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim classification As String = objDerived.GetValue("SELECT ClassificationId FROM dbo.tbl_Classification WHERE ClassificationName = 'Supplies'", CommandType.Text)
            Session("ClassificationID") = classification

            LoadSubClassifications()
            ClearItemDesc()
            BindEmptyLedger()

            loadwarehouse()
        End If
    End Sub

    '========================
    ' SUBCLASSIFICATION
    '========================
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

    '========================
    ' GL ACCOUNT
    '========================
    Private Sub LoadGLAccounts()
        ddGlAccount.Items.Clear()

        If DrpSubClass.SelectedValue Is Nothing OrElse DrpSubClass.SelectedValue = "0" Then
            ddGlAccount.Items.Insert(0, New ListItem("Select", "0"))
            Exit Sub
        End If

        AddTrace("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & Session("ClassificationID") & "','" & DrpSubClass.SelectedItem.Value & "'")

        Dim PListofGL As DataTable = objDerived.GetDataTable(
            "Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & Session("ClassificationID") & "','" & DrpSubClass.SelectedItem.Value & "'",
            CommandType.Text
        )

        If PListofGL IsNot Nothing Then
            Dim dr As DataRow = PListofGL.NewRow()
            dr("GA_ID") = 0
            dr("GA_Title") = "Select"
            PListofGL.Rows.InsertAt(dr, 0)
        End If

        ddGlAccount.DataSource = PListofGL
        ddGlAccount.DataTextField = "GA_Title"
        ddGlAccount.DataValueField = "GA_ID"
        ddGlAccount.DataBind()
    End Sub

    '========================
    ' ITEM DESCRIPTION (drpItemDesc1)
    '========================
    Private Sub ClearItemDesc()
        drpItemDesc1.Items.Clear()
        drpItemDesc1.Items.Insert(0, New ListItem("Select", "0"))
        drpItemDesc1.Enabled = False
    End Sub

    Private Sub LoadItemDesc()
        If DrpSubClass.SelectedValue Is Nothing OrElse DrpSubClass.SelectedValue = "0" Then
            ClearItemDesc()
            Exit Sub
        End If

        Dim dtitemdesc As DataTable = objDerived.GetDataTable(
            "SELECT DISTINCT dbo.m_item.Item_ID, dbo.m_item.ItemCompleteDesc as Item_Desc " &
            "FROM dbo.tbl_SubClassification INNER JOIN " &
            "dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID INNER JOIN " &
            "dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId INNER JOIN " &
            "dbo.m_item_detail ON dbo.m_item.Item_ID = dbo.m_item_detail.Item_ID " &
            "WHERE (dbo.tbl_SubClassification.SubClassificationID = " & DrpSubClass.SelectedValue & ") " &
            "ORDER BY dbo.m_item.ItemCompleteDesc",
            CommandType.Text
        )

        ' Add first row Select (0)
        Dim dr As DataRow = dtitemdesc.NewRow()
        dr("Item_ID") = 0
        dr("Item_Desc") = "Select"
        dtitemdesc.Rows.InsertAt(dr, 0)

        drpItemDesc1.DataSource = dtitemdesc
        drpItemDesc1.DataTextField = "Item_Desc"
        drpItemDesc1.DataValueField = "Item_ID"
        drpItemDesc1.DataBind()

        drpItemDesc1.Enabled = True
    End Sub
    Public Sub loadUnit()


        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT Unit_ID, Description FROM ams.m_Unit AS a ORDER BY CASE WHEN Description = '-' THEN 0 ELSE 1 END, Description;", CommandType.Text)
        drpUnit.DataSource = dt
        drpUnit.DataTextField = ("Description")
        drpUnit.DataValueField = ("Unit_ID")
        drpUnit.DataBind()

        Dim Unit_ID As Integer = objDerived.GetValue("SELECT Unit_ID FROM DBO.m_item WHERE Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        drpUnit.SelectedValue = Unit_ID



    End Sub

    Public Sub loadwarehouse()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select warehouse_id,wname From ams.loc_warehouse where isUsed='True'", CommandType.Text)
        drpWarehouse.DataTextField = ("wname")
        drpWarehouse.DataValueField = ("warehouse_id")
        drpWarehouse.DataSource = dt
        drpWarehouse.DataBind()

    End Sub


    Public Sub LoadLedger()
        Dim dtStock As DataTable = objDerived.GetDataTable(
            "EXEC [AMS].[sp_SuppliesLedger] '" & drpItemDesc1.SelectedValue & "'",
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



    '========================
    ' DROPDOWN HANDLER
    '========================
    Protected Sub DrpSubClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ctrl As Control = CType(sender, Control)

        If ctrl IsNot Nothing AndAlso ctrl.ID = "DrpSubClass" Then
            LoadGLAccounts()
            'LoadItemDesc()
            'loadUnit()

        End If
    End Sub

    Protected Sub ddGlAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)


        LoadItemDesc()
        'loadUnit()
        loadwarehouse()

    End Sub

    '========================
    ' TRACE HELPER
    '========================
    Private Sub AddTrace(ByVal msg As String)
        System.Diagnostics.Debug.WriteLine(msg)
    End Sub

    '========================
    ' EMPTY LEDGER (4 rows)
    '========================
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

    '========================
    ' STUBS
    '========================
    Protected Sub drpItemDesc1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Session("Item_ID") = drpItemDesc1.SelectedValue

        loadUnit()


        LoadLedger()
    End Sub

    Protected Sub grdLedger_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
    End Sub




    Protected Sub btnROP_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub BtnCompute_Click(sender As Object, e As EventArgs)
        Try
            RP.Text = DRP.Text * LTD.Text
            ModalPopupExtender1.Show()
            txtReOrderPt.Text = DRP.Text * LTD.Text

            'If hdnROP.Value = "Electrical" Then
            '    txtReorderPointElectrical.Text = DRP.Text * LTD.Text
            'ElseIf hndMed.Value = "MED" Then
            '    txtReorderPointMed.Text = DRP.Text * LTD.Text
            'End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill Demand Per Day & Lead Time For Deliver.")

        End Try
    End Sub




    Protected Sub btnEdit1_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        If btnSave.Text = "SAVE" Then
            saveSupplies()
        ElseIf btnSave.Text = "UPDATE" Then
            editSupplies()
        End If
    End Sub

    Public Sub saveSupplies()
        Try
            '========================
            ' 1) REQUIRED FIELDS
            '========================
            If DrpSubClass.SelectedValue = "0" OrElse ddGlAccount.SelectedValue = "0" OrElse drpItemDesc1.SelectedValue = "0" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select Sub Classification / General Account / Name.")
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtBrandName1.Text) OrElse
               String.IsNullOrWhiteSpace(txtUnitPrice.Text) OrElse
               String.IsNullOrWhiteSpace(txtQuantity.Text) OrElse
               String.IsNullOrWhiteSpace(txtSellectDate.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity / Date")
                Exit Sub
            End If

            '========================
            ' 2) PARSE NUMERICS (remove commas)
            '========================
            Dim qtyValue As Decimal
            If Not Decimal.TryParse(txtQuantity.Text.Replace(",", ""), qtyValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity is not numeric.")
                Exit Sub
            End If

            Dim unitPriceValue As Decimal
            If Not Decimal.TryParse(txtUnitPrice.Text.Replace(",", ""), unitPriceValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unit Price is not numeric.")
                Exit Sub
            End If

            Dim reorderVal As Integer = 0

            If Not String.IsNullOrWhiteSpace(txtReOrderPt.Text) Then
                If Not Integer.TryParse(txtReOrderPt.Text.Replace(",", ""), reorderVal) Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Reorder Point is not numeric.")
                    Exit Sub
                End If
            End If

            Dim selectDateValue As Date
            If Not Date.TryParse(txtSellectDate.Text, selectDateValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Date.")
                Exit Sub
            End If

            '========================
            ' 3) SET HIDDEN VALUES (GA + Item)
            '========================
            hdnGAId.Value = ddGlAccount.SelectedValue
            hdnItemNo.Value = drpItemDesc1.SelectedValue

            ''========================
            '' 4) UPDATE m_item UNIT(No update needed)
            ''========================
            'If drpUnit.SelectedValue IsNot Nothing AndAlso drpUnit.SelectedValue <> "" Then
            '    objDerived.Execute("UPDATE dbo.m_item SET unit_id = " & drpUnit.SelectedValue &
            '                   " WHERE item_id = " & hdnItemNo.Value, CommandType.Text)
            'End If

            '========================
            ' 5) ENSURE tblclassmatrix ROW EXISTS
            '========================
            Dim classification As String = Convert.ToString(Session("ClassificationID"))
            If String.IsNullOrEmpty(classification) Then
                classification = objDerived.GetValue("SELECT ClassificationId FROM dbo.tbl_Classification WHERE ClassificationName = 'Supplies'", CommandType.Text)
                Session("ClassificationID") = classification
            End If

            Dim category As String = objDerived.GetValue(
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
                    "VALUES(" & classification & "," & hdnGAId.Value & "," & hdnItemNo.Value & "," & category & ",0)",
                    CommandType.Text
                )
            End If

            '========================
            ' 6) SAVE RECEIVING (AMS.Tb_Receiving)
            '========================
            Dim rcv As New Receiving.t_receiving
            With rcv
                .Received_Date = Date.Today
                .ReceivedBY = 0
                .POHdr_ID = 0
                .PO_No = ""
                .Supplier_ID = 0
                .GA_ID = Convert.ToInt32(ddGlAccount.SelectedValue)
                .isAccepted = False
                .UserID = Convert.ToString(Session("@UserName"))
            End With

            Dim rcvID As Long = rcv.save()
            If rcvID <= 0 Then Throw New Exception("Failed to save AMS.Tb_Receiving.")
            Session("Received_ID") = rcvID

            '========================
            ' 7) SAVE RECEIVING DETAILS (AMS.Tb_Receiving_Dtl)
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

            Dim rcv_dtl As New Receiving.t_receiving_dtl
            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = Convert.ToInt64(drpItemDesc1.SelectedValue)
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

            '========================
            ' 8) SAVE / UPDATE PO HEADER (Starting Inventory)
            '========================
            Dim POnumber As String = "Starting Inventory"
            Dim pohdr_id As Long = 0

            Dim POhdr As New t_purchase_order_hdr
            With POhdr
                .PO_No = POnumber
                .PO_Date = Date.Today
                .Supplier_ID = 0
                .mode_of_procurement_id = 2
                .DeliveryTerm = 0
                .paymentTerm = 0
                .DeliveryDate = Date.Today
                .DeliveryPlace = ""
                .isDelivered = True
                .pre_procurement_hdr_id = 0
                .withdv = False
                .ContractPrice = 0
                .isStag = False
                .isContinueCutOff = False
                .isStopForCutOff = False
                .isShoppingA = False
                .isPublicInfra = False
                .isStraight = True
                .isApproved_PO_Mayor = True
                .isReceived_PO_Mayor = True
                .DateApproved_PO_Mayor = Date.Today
                .DateReceived_PO_Mayor = Date.Today
                .DateDisApprove = DateTime.Parse("01/01/1900")
                .isGasoline = False
                .isReimbursement = False
            End With

            Dim po_id As DataTable = objDerived.GetDataTable(
            "SELECT pohdr_id FROM ams.po_hdr WHERE po_no = '" & POnumber & "' AND Supplier_ID = 0",
            CommandType.Text
            )

            If po_id Is Nothing OrElse po_id.Rows.Count = 0 Then
                pohdr_id = POhdr.save()
            Else
                Dim poid As Integer = Convert.ToInt32(objDerived.GetValue(
                    "SELECT pohdr_id FROM ams.po_hdr WHERE po_no = '" & POnumber & "' AND Supplier_ID = 0",
                    CommandType.Text
                ))

                Dim TAmount As Decimal = Convert.ToDecimal(objDerived.GetValue(
                    "SELECT ContractPrice FROM ams.po_hdr WHERE pohdr_id = " & poid,
                    CommandType.Text
                ))

                POhdr.ContractPrice = TAmount + total
                POhdr.POHdr_ID = poid
                pohdr_id = POhdr.update()
            End If

            If pohdr_id <= 0 Then Throw New Exception("Failed to save/update AMS.PO_Hdr.")
            Session("POHdr_ID") = pohdr_id

            objDerived.Execute(
            "UPDATE AMS.PO_Hdr SET GA_ID = " & hdnGAId.Value & ", ProjectName = 'Manual Encode' WHERE POHdr_ID = " & pohdr_id,
            CommandType.Text
            )

            '========================
            ' 9) SAVE AIR HEADER (Inspection & Acceptance)
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
                .POHdr_ID = pohdr_id
                .RC_ID = 0
                .Function_ID = 0
            End With

            Dim airhdr_id As Long = objhdr.save()
            If airhdr_id <= 0 Then Throw New Exception("Failed to save AMS.AIR_Hdr.")
            Session("AIRHDR_ID") = airhdr_id

            objDerived.Execute(
                "UPDATE AMS.AIR_Hdr SET UserID = '" & Convert.ToString(Session("@UserName")) & "', Received_ID = " & rcvID & " WHERE AIRHdr_ID = " & airhdr_id,
                CommandType.Text
            )

            '========================
            ' 10) SAVE PO DETAIL + AIR DETAIL
            '========================
            Dim POdtl As New t_purchase_order_dtl
            POdtl.POHdr_ID = pohdr_id
            POdtl.Item_ID = Convert.ToInt64(drpItemDesc1.SelectedValue)
            POdtl.cost = unitPriceValue
            POdtl.qty = qtyValue
            POdtl.remarks = "Manual Encode"
            POdtl.save()

            Dim objdtl As New t_inspection_and_acceptance_dtl
            objdtl.Item_ID = Convert.ToInt64(drpItemDesc1.SelectedValue)
            objdtl.Qty = qtyValue
            objdtl.Cost = unitPriceValue
            objdtl.AIRHdr_ID = airhdr_id
            objdtl.GA_ID = Convert.ToInt32(ddGlAccount.SelectedValue)

            Dim iaDtl_ID As Integer = objdtl.save()
            If iaDtl_ID <= 0 Then Throw New Exception("Failed to save AMS.AIR_Dtl.")
            Session("AIRDtl_ID") = iaDtl_ID

            '========================
            ' 11) SAVE STOCK
            '========================
            Dim whVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpWarehouse.SelectedValue), whVal)

            Dim rcParsed As Integer = 0
            Dim rcValString As String = objDerived.GetValue(
                "SELECT TOP 1 [RC_id] FROM [dbo].[View_RespCenter_withFunctions] WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'",
                CommandType.Text
            )
            If Not String.IsNullOrEmpty(rcValString) AndAlso IsNumeric(rcValString) Then rcParsed = Convert.ToInt32(rcValString)

            Dim objStock As New Supplies_Stock
            With objStock
                .StockDate = Date.Today
                .Item_ID = Convert.ToInt64(drpItemDesc1.SelectedValue)
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
            ' 12) SAVE LEDGER
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
                .dDate = selectDateValue
                .Item_ID = Convert.ToInt64(drpItemDesc1.SelectedValue)
                .DebitQty = qtyValue
                .DebitCost = Decimal.Round(unitPriceValue * qtyValue, 2)
                .DebitUnit = unitDesc
                .BalanceUnit = unitDesc
                .BalanceQty = qtyValue
                .BalanceCost = Decimal.Round(unitPriceValue * qtyValue, 2)
            End With
            objStockLedger.save()



            '========================
            ' 12.5) SAVE SUPPLIES INFO (AMS.TBSupplies_Info)
            '========================
            Dim unitIdVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpUnit.SelectedValue), unitIdVal)

            Dim sqlSuppliesInfo As String =
                "INSERT INTO AMS.TBSupplies_Info " &
                "(AIRDtl_ID, ItemId, Received_ID, StockID, Unit_ID, BrandName, Color, Length, Size, Width, Height, Weight) " &
                "VALUES " &
                "(" & iaDtl_ID & ", " & Convert.ToInt64(drpItemDesc1.SelectedValue) & ", " & rcvID & ", " & StockID & ", " & unitIdVal & ", " &
                "'" & Replace(txtBrandName1.Text.Trim(), "'", "''") & "', " &
                "'" & Replace(txtColor.Text.Trim(), "'", "''") & "', " &
                "'" & Replace(txtLenght.Text.Trim(), "'", "''") & "', " &
                "'" & Replace(txtSize.Text.Trim(), "'", "''") & "', " &
                "'" & Replace(txtWidth.Text.Trim(), "'", "''") & "', " &
                "'" & Replace(txtHeight.Text.Trim(), "'", "''") & "', " &
                "'" & Replace(txtWeight.Text.Trim(), "'", "''") & "'" &
                ")"

            objDerived.Execute(sqlSuppliesInfo, CommandType.Text)


            '========================
            ' 13) REFRESH LEDGER GRID
            '========================
            LoadLedger()
            ClearTextBoxes()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.Message)
        End Try
    End Sub
    Public Sub editSupplies()
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

            If String.IsNullOrWhiteSpace(txtBrandName1.Text) OrElse
           String.IsNullOrWhiteSpace(txtUnitPrice.Text) OrElse
           String.IsNullOrWhiteSpace(txtQuantity.Text) OrElse
           String.IsNullOrWhiteSpace(txtSellectDate.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity  / Date")
                Exit Sub
            End If

            Dim qtyValue As Decimal
            If Not Decimal.TryParse(txtQuantity.Text.Replace(",", ""), qtyValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity is not numeric.")
                Exit Sub
            End If

            Dim unitPriceValue As Decimal
            If Not Decimal.TryParse(txtUnitPrice.Text.Replace(",", ""), unitPriceValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unit Price is not numeric.")
                Exit Sub
            End If

            Dim reorderVal As Integer = 0

            If Not String.IsNullOrWhiteSpace(txtReOrderPt.Text) Then
                If Not Integer.TryParse(txtReOrderPt.Text.Replace(",", ""), reorderVal) Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Reorder Point is not numeric.")
                    Exit Sub
                End If
            End If

            Dim selectDateValue As Date
            If Not Date.TryParse(txtSellectDate.Text, selectDateValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Date.")
                Exit Sub
            End If

            Dim itemId As Long = 0
            Long.TryParse(Convert.ToString(drpItemDesc1.SelectedValue), itemId)

            Dim gaId As Long = 0
            Long.TryParse(Convert.ToString(ddGlAccount.SelectedValue), gaId)

            If itemId <= 0 OrElse gaId <= 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select Name and General Account.")
                Exit Sub
            End If

            Dim whVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpWarehouse.SelectedValue), whVal)

            Dim unitIdVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpUnit.SelectedValue), unitIdVal)

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

            Dim brand As String = Replace(txtBrandName1.Text.Trim(), "'", "''")
            Dim col As String = Replace(txtColor.Text.Trim(), "'", "''")
            Dim lenStr As String = Replace(txtLenght.Text.Trim(), "'", "''")
            Dim sizeStr As String = Replace(txtSize.Text.Trim(), "'", "''")
            Dim widStr As String = Replace(txtWidth.Text.Trim(), "'", "''")
            Dim heiStr As String = Replace(txtHeight.Text.Trim(), "'", "''")
            Dim weiStr As String = Replace(txtWeight.Text.Trim(), "'", "''")

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

            objDerived.Execute(
            "UPDATE AMS.TBSupplies_Info SET " &
            "ItemId = " & itemId & ", " &
            "Unit_ID = " & unitIdVal & ", " &
            "BrandName = '" & brand & "', " &
            "Color = '" & col & "', " &
            "[Length] = '" & lenStr & "', " &
            "[Size] = '" & sizeStr & "', " &
            "[Width] = '" & widStr & "', " &
            "[Height] = '" & heiStr & "', " &
            "[Weight] = '" & weiStr & "' " &
            "WHERE StockID = " & stockID,
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
            ClearTextBoxes()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.Message)
        End Try
    End Sub


    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        ClearTextBoxes()
        grdLedger.SelectedIndex = -1

        For Each row As GridViewRow In grdLedger.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim cb As CheckBox = TryCast(row.FindControl("cbInspection"), CheckBox)
                If cb IsNot Nothing Then cb.Checked = False
            End If
        Next

    End Sub



    '-------------------- LEDGER GRIDVIEW-------------------------------
    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        If cb Is Nothing Then Exit Sub

        Dim row As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
        If row Is Nothing Then Exit Sub

        grdLedger.SelectedIndex = row.RowIndex

        If Not cb.Checked Then
            ClearTextBoxes()
            Exit Sub
        End If

        Dim stockObj As Object = grdLedger.SelectedDataKey("StockID")
        Dim stockID As Long = 0
        If stockObj IsNot Nothing AndAlso Not IsDBNull(stockObj) Then
            Long.TryParse(stockObj.ToString(), stockID)
        End If

        If stockID <= 0 Then
            ClearTextBoxes()
            Exit Sub
        End If

        Dim dt As DataTable = objDerived.GetDataTable("EXEC AMS.sp_Encoding_Supplies " & stockID, CommandType.Text)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearTextBoxes()
            Exit Sub
        End If

        Dim r As DataRow = dt.Rows(0)

        Dim unitIdStr As String = Convert.ToString(r("Unit_ID")).Trim()
        'If drpUnit.Items.Count > 0 AndAlso unitIdStr <> "" AndAlso drpUnit.Items.FindByValue(unitIdStr) IsNot Nothing Then
        '    drpUnit.SelectedValue = unitIdStr
        'ElseIf drpUnit.Items.Count > 0 Then
        '    drpUnit.SelectedIndex = 0
        'End If

        txtBrandName1.Text = Convert.ToString(r("BrandName"))
        txtLenght.Text = Convert.ToString(r("Length"))
        txtSize.Text = Convert.ToString(r("Size"))
        txtWidth.Text = Convert.ToString(r("Width"))
        txtColor.Text = Convert.ToString(r("Color"))
        txtHeight.Text = Convert.ToString(r("Height"))
        txtWeight.Text = Convert.ToString(r("Weight"))

        txtUnitPrice.Text = Convert.ToString(r("UnitCost"))
        txtReOrderPt.Text = Convert.ToString(r("ReorderPoint"))
        txtQuantity.Text = Convert.ToString(r("Quantity"))
        txtSellectDate.Text = Convert.ToString(r("Date"))

        Dim whName As String = Convert.ToString(r("Warehouse")).Trim()
        If drpWarehouse.Items.Count > 0 AndAlso whName <> "" Then
            Dim it As ListItem = drpWarehouse.Items.FindByText(whName)
            If it IsNot Nothing Then
                drpWarehouse.ClearSelection()
                it.Selected = True
            Else
                drpWarehouse.SelectedIndex = 0
            End If
        ElseIf drpWarehouse.Items.Count > 0 Then
            drpWarehouse.SelectedIndex = 0
        End If

        txtBay.Text = Convert.ToString(r("Bay"))
        txtColumn.Text = Convert.ToString(r("Column"))
        txtFloor.Text = Convert.ToString(r("Floor"))
        txtRoom.Text = Convert.ToString(r("Room"))
        txtShelves.Text = Convert.ToString(r("Shelves"))
        txtRack.Text = Convert.ToString(r("Rack"))
        txtBin.Text = Convert.ToString(r("Bin"))

        btnSave.Text = "UPDATE"
    End Sub


    Private Sub ClearTextBoxes()
        ' If drpUnit.Items.Count > 0 Then drpUnit.SelectedIndex = 0
        If drpWarehouse.Items.Count > 0 Then drpWarehouse.SelectedIndex = 0

        txtBrandName1.Text = ""
        txtLenght.Text = ""
        txtSize.Text = ""
        txtWidth.Text = ""
        txtColor.Text = ""
        txtHeight.Text = ""
        txtWeight.Text = ""

        txtUnitPrice.Text = ""
        txtReOrderPt.Text = ""
        txtQuantity.Text = ""
        txtSellectDate.Text = ""

        txtBay.Text = ""
        txtColumn.Text = ""
        txtFloor.Text = ""
        txtRoom.Text = ""
        txtShelves.Text = ""
        txtRack.Text = ""
        txtBin.Text = ""

        btnSave.Text = "SAVE"
    End Sub


End Class
