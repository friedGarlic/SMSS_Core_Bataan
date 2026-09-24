
Imports System.Data
Imports System.Data.SqlClient

Partial Class Records_t_StockCard_Rev_Medicines
    Inherits System.Web.UI.Page

    Private objDerived As New BaseClasses.AccountClassAcounts

    Private ppq As New Price_per_qty
    Private Property PListofGL() As DataTable
        Get
            Return CType(Session("PListofGL"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PListofGL") = value
        End Set
    End Property

    Private Property pPricePerQty(ByVal PPQ_ID As String) As DataTable
        Get
            Return CType(Session(PPQ_ID), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session(PPQ_ID) = value
        End Set
    End Property
    Private Property pTempPPQ() As DataTable
        Get
            Return CType(Session("pTempPPQ"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pTempPPQ") = value
        End Set
    End Property
    Private Property pPPQ() As DataTable
        Get
            Return CType(Session("pPPQ"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPPQ") = value
        End Set
    End Property



    Protected Sub Page_Load(
    ByVal sender As Object,
    ByVal e As System.EventArgs
) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim classification As String = objDerived.GetValue(
            "SELECT ClassificationId " &
            "FROM dbo.tbl_Classification " &
            "WHERE ClassificationName = 'Medicines'",
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

            ClearGenericName()
            BindEmptyLedger()
            BindEmptyPPQ()

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

        LoadWarehouse()
    End Sub

    Private Sub ClearGenericName()
        drpGenericName.Items.Clear()

        drpGenericName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        drpGenericName.Enabled = True
    End Sub

    Private Sub LoadGenericNames()
        If ddGlAccount.SelectedValue Is Nothing OrElse
           ddGlAccount.SelectedValue = "" OrElse
           ddGlAccount.SelectedValue = "0" Then

            ClearGenericName()
            Exit Sub
        End If

        Dim sql As String =
        "SELECT DISTINCT " &
        "    i.Item_ID, " &
        "    CASE " &
        "        WHEN NULLIF(LTRIM(RTRIM(i.GenericName)), '') IS NOT NULL " &
        "        THEN CONCAT(i.GenericName, ', ', i.ItemCompleteDesc) " &
        "        ELSE i.ItemCompleteDesc " &
        "    END AS Item_Desc " &
        "FROM " &
        "    dbo.m_item AS i " &
        "INNER JOIN dbo.tbl_Classification ON i.ClassificationID = dbo.tbl_Classification.ClassificationId " &
        "INNER JOIN dbo.m_item_detail AS id ON i.Item_ID = id.Item_ID " &
        "INNER JOIN dbo.tblclassmatrix AS cm ON cm.item_id = i.Item_ID " &
        "LEFT JOIN dbo.tbl_SubCategory ON i.SubCategoryID = dbo.tbl_SubCategory.SubCategoryID " &
        "LEFT JOIN dbo.tbl_SubClassification ON dbo.tbl_SubClassification.SubClassificationID = i.SubClassificationID " &
        "WHERE " &
        "    i.SubClassificationID = " & DrpSubClass.SelectedValue & " " &
        "AND cm.ga_id = " & ddGlAccount.SelectedValue & " " &
        "ORDER BY " &
        "    CASE " &
        "        WHEN NULLIF(LTRIM(RTRIM(i.GenericName)), '') IS NOT NULL " &
        "        THEN CONCAT(i.GenericName, ', ', i.ItemCompleteDesc) " &
        "        ELSE i.ItemCompleteDesc " &
        "    END"

        AddTrace(sql)

        Dim dt As DataTable = objDerived.GetDataTable(
        sql,
        CommandType.Text
    )

        If dt Is Nothing Then
            ClearGenericName()
            Exit Sub
        End If

        Dim dr As DataRow = dt.NewRow()
        dr("Item_ID") = 0
        dr("Item_Desc") = "Select"
        dt.Rows.InsertAt(dr, 0)

        drpGenericName.DataSource = dt
        drpGenericName.DataTextField = "Item_Desc"
        drpGenericName.DataValueField = "Item_ID"
        drpGenericName.DataBind()

        drpGenericName.Enabled = True
    End Sub
    Public Sub LoadUnit()
        Dim dt As DataTable = objDerived.GetDataTable("select Unit_ID,Description From ams.m_Unit as a order by Description", CommandType.Text)
        drpUnit.DataSource = dt
        drpUnit.DataTextField = "Description"
        drpUnit.DataValueField = "Unit_ID"
        drpUnit.DataBind()


        Dim Unit_ID As Integer = objDerived.GetValue("SELECT Unit_ID FROM DBO.m_item WHERE Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        drpUnit.SelectedValue = Unit_ID


    End Sub

    Public Sub LoadWarehouse()
        Dim dt As DataTable = objDerived.GetDataTable("select warehouse_id,wname From ams.loc_warehouse where isUsed='True'", CommandType.Text)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            drpMedicineWarehouse.DataTextField = "wname"
            drpMedicineWarehouse.DataValueField = "warehouse_id"
            drpMedicineWarehouse.DataSource = dt
            drpMedicineWarehouse.DataBind()
        End If
        drpMedicineWarehouse.Items.Insert(0, New ListItem("Select", "0"))
        drpMedicineWarehouse.SelectedIndex = 0
        drpMedicineWarehouse.Enabled = True

    End Sub

    Public Sub LoadLedger()
        Dim dtStock As DataTable = objDerived.GetDataTable(
            "EXEC [AMS].[sp_SuppliesLedger] '" & drpGenericName.SelectedValue & "'",
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

    Public Sub LoadPPQ()
        If drpGenericName IsNot Nothing AndAlso drpGenericName.SelectedItem IsNot Nothing Then
            Dim itemId As String = drpGenericName.SelectedItem.Value
            If Not String.IsNullOrEmpty(itemId) Then
                pPPQ = objDerived.GetDataTable("Select * from ams.tbl_Price_per_qty where item_id ='" & itemId & "'", CommandType.Text)
                pTempPPQ = objDerived.GetDataTable("Select * from ams.tbl_Price_per_qty where item_id ='" & itemId & "'", CommandType.Text)
                GridPPQ.DataSource = pTempPPQ
                GridPPQ.DataBind()
            Else
                BindEmptyPPQ()
            End If
        Else
            BindEmptyPPQ()
        End If


    End Sub

    Protected Sub DrpSubClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As System.EventArgs
)

        LoadGenericNames()

        BindEmptyLedger()
        BindEmptyPPQ()
        ClearTextBoxesMedicine()

    End Sub

    Protected Sub ddGlAccount_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As System.EventArgs
)

        LoadSubClassifications()
        ClearGenericName()
        LoadGenericNames()

        BindEmptyLedger()
        BindEmptyPPQ()
        ClearTextBoxesMedicine()

    End Sub
    Protected Sub drpGenericName_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Session("Item_ID") = drpGenericName.SelectedValue
        LoadLedger()
        LoadPPQ()

        LoadUnit()
        ClearMedicineDetailsOnly()
    End Sub

    Protected Sub GridPPQ_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GridPPQ.PageIndex = e.NewPageIndex
        LoadPPQ()
    End Sub

    Protected Sub GridPPQ_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If GridPPQ.SelectedIndex < 0 Then Exit Sub

        Dim qtyPackObj As Object = GridPPQ.SelectedDataKey("QtyPack")
        Dim unitCostObj As Object = GridPPQ.SelectedDataKey("Unit_cost")
        Dim percentObj As Object = GridPPQ.SelectedDataKey("PPQ_Percent")
        Dim sellingObj As Object = GridPPQ.SelectedDataKey("Selling_Price")

        txtQtyPack.Text = Convert.ToString(qtyPackObj)
        txtUnitCost.Text = Convert.ToString(unitCostObj)
        txtPercent.Text = Convert.ToString(percentObj)
        txtSellingPrice1.Text = Convert.ToString(sellingObj)


        ViewState("SelectedPPQ_ID") = GridPPQ.SelectedDataKey("PPQ_ID")

        btnMedicineRemove.Enabled = True

        btnMedicineAdd.Text = "UPDATE"
        btnMedicineAdd.Enabled = True

        'txtQtyPack.Text = GridPPQ.SelectedDataKey(2)
        'txtUnitCost.Text = GridPPQ.SelectedDataKey(3)
        'txtPercent.Text = GridPPQ.SelectedDataKey(4)
        'txtSellingPrice1.Text = GridPPQ.SelectedDataKey(5)


    End Sub

    Protected Sub btnROP_Click(sender As Object, e As EventArgs)
        'Optional: clear previous compute
        txtDemandPerDay.Text = ""
        txtLeadTime.Text = ""
        txtComputedROP.Text = ""

        ModalPopupExtenderROP.Show()
    End Sub

    Protected Sub BtnCompute_Click(sender As Object, e As EventArgs)
        Dim demand As Decimal
        Dim leadTime As Decimal

        'Basic validation
        If Not Decimal.TryParse(txtDemandPerDay.Text.Replace(",", ""), demand) OrElse demand <= 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid Demand Per Day.")
            ModalPopupExtenderROP.Show()
            Exit Sub
        End If

        If Not Decimal.TryParse(txtLeadTime.Text.Replace(",", ""), leadTime) OrElse leadTime <= 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid Lead Time for Delivery.")
            ModalPopupExtenderROP.Show()
            Exit Sub
        End If

        'Compute ROP (adjust rounding if your business rule is different)
        Dim rop As Decimal = demand * leadTime
        Dim ropRounded As Integer = CInt(Math.Ceiling(rop))

        txtComputedROP.Text = ropRounded.ToString()
        txtReOrderPt.Text = ropRounded.ToString()   ' <-- IMPORTANT: main textbox used by SAVE/UPDATE validation

        'Keep modal open after partial postback
        ModalPopupExtenderROP.Show()
    End Sub



    Protected Sub btnMedicineAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnMedicineAdd.Text <> "UPDATE" Then
            ' Server-Side Validation
            Dim qtyPack As Integer
            Dim unitCost As Decimal
            Dim percent As Decimal
            Dim sellingPrice As Decimal

            ' Validate QtyPack
            If String.IsNullOrWhiteSpace(txtQtyPack.Text) OrElse Not Integer.TryParse(txtQtyPack.Text, qtyPack) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid integer for Quantity Pack.")
                Exit Sub
            End If

            ' Validate UnitCost
            If String.IsNullOrWhiteSpace(txtUnitCost.Text) OrElse Not Decimal.TryParse(txtUnitCost.Text, unitCost) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Unit Cost.")
                Exit Sub
            End If

            ' Validate Percent
            If String.IsNullOrWhiteSpace(txtPercent.Text) OrElse Not Decimal.TryParse(txtPercent.Text, percent) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Percent.")
                Exit Sub
            End If

            ' Validate SellingPrice
            ' Selling Price: allow auto-calc if blank/invalid
            If Not Decimal.TryParse(txtSellingPrice1.Text.Replace(",", ""), sellingPrice) Then
                ' Option A (markup):
                sellingPrice = ComputePPQSellingPrice(qtyPack, unitCost, percent)
                txtSellingPrice1.Text = sellingPrice.ToString("N2")
            End If


            ' Assign Validated Values
            ppq.item_ID = drpGenericName.SelectedItem.Value
            ppq.QtyPack = qtyPack
            ppq.Unit_Cost = unitCost
            ppq.PPQ_Percent = percent
            ppq.Selling_price = sellingPrice
            ppq.save()

            ' Rebind GridPPQ
            pTempPPQ = objDerived.GetDataTable("Select * from ams.tbl_Price_per_qty where item_id ='" & drpGenericName.SelectedItem.Value & "'", CommandType.Text)
            GridPPQ.DataSource = pTempPPQ
            GridPPQ.DataBind()

        Else
            Dim updatedQtyPack As Integer
            Dim updatedUnitCost As Decimal
            Dim updatedPercent As Decimal
            Dim updatedSellingPrice As Decimal
            Dim ppqID As Long = 0

            If ViewState("SelectedPPQ_ID") Is Nothing OrElse Not Long.TryParse(ViewState("SelectedPPQ_ID").ToString(), ppqID) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a price per quantity record to update.")
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtQtyPack.Text) OrElse Not Integer.TryParse(txtQtyPack.Text.Replace(",", ""), updatedQtyPack) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid integer for Quantity Pack.")
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtUnitCost.Text) OrElse Not Decimal.TryParse(txtUnitCost.Text.Replace(",", ""), updatedUnitCost) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Unit Cost.")
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtPercent.Text) OrElse Not Decimal.TryParse(txtPercent.Text.Replace(",", ""), updatedPercent) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Percent.")
                Exit Sub
            End If

            updatedSellingPrice = ComputePPQSellingPrice(updatedQtyPack, updatedUnitCost, updatedPercent)
            txtSellingPrice1.Text = updatedSellingPrice.ToString("N2")

            objDerived.Execute("UPDATE ams.tbl_price_per_qty SET " &
                       "QtyPack = " & updatedQtyPack & ", " &
                       "Unit_cost = " & updatedUnitCost.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
                       "PPQ_percent = " & updatedPercent.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
                       "Selling_Price = " & updatedSellingPrice.ToString(System.Globalization.CultureInfo.InvariantCulture) & " " &
                       "WHERE PPQ_ID = " & ppqID, CommandType.Text)

            btnMedicineAdd.Text = "ADD"
            btnMedicineRemove.Enabled = False
            ViewState("SelectedPPQ_ID") = Nothing

            LoadPPQ()
            GridPPQ.SelectedIndex = -1

            txtQtyPack.Text = ""
            txtUnitCost.Text = ""
            txtPercent.Text = ""
            txtSellingPrice1.Text = ""
        End If
    End Sub




    Protected Sub btnMedicineRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub btnMedicineSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        If btnMedicineSave.Text = "SAVE" Then
            save()

        ElseIf btnMedicineSave.Text = "EDIT" Then
            loadApprovalOfficer()
            ModalPopupExtenderApproval.Show()

        ElseIf btnMedicineSave.Text = "UPDATE" Then
            update()
        End If
    End Sub


    Public Sub save()
        Try
            If drpGenericName.SelectedValue = "0" OrElse
           String.IsNullOrWhiteSpace(txtMedicineUnitprice.Text) OrElse
           String.IsNullOrWhiteSpace(txtMedicineQuantity.Text) OrElse
           String.IsNullOrWhiteSpace(txtSellectDate.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1,
                "Please complete required fields: Generic Name, Unit Cost, Quantity and Date.")
                Exit Sub
            End If

            Dim qty As Decimal
            Dim unitCost As Decimal
            Dim reorderPt As Integer
            Dim acqDate As Date

            If Not Decimal.TryParse(txtMedicineQuantity.Text.Replace(",", ""), qty) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Quantity is not numeric.")
                Exit Sub
            End If

            If Not Decimal.TryParse(txtMedicineUnitprice.Text.Replace(",", ""), unitCost) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Unit Cost is not numeric.")
                Exit Sub
            End If



            If Not Date.TryParse(txtSellectDate.Text, acqDate) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Invalid Date.")
                Exit Sub
            End If

            Dim itemId As Long = CLng(drpGenericName.SelectedValue)
            Dim gaId As Long = CLng(ddGlAccount.SelectedValue)

            Dim rcv As New Receiving.t_receiving
            With rcv
                .Received_Date = Date.Today
                .ReceivedBY = 0
                .POHdr_ID = 0
                .PO_No = "Starting Inventory"
                .Supplier_ID = 0
                .GA_ID = gaId
                .isAccepted = True
                .UserID = Convert.ToString(Session("@UserName"))
            End With

            Dim rcvID As Long = rcv.save()
            If rcvID <= 0 Then Throw New Exception("Failed to save Receiving.")

            Dim locationBuilder As New System.Text.StringBuilder()

            If Not String.IsNullOrWhiteSpace(txtMedicineBay.Text) Then locationBuilder.Append("Bay-").Append(txtMedicineBay.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineColumn.Text) Then locationBuilder.Append(" Column-").Append(txtMedicineColumn.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineFloor.Text) Then locationBuilder.Append(" Floor-").Append(txtMedicineFloor.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineRoom.Text) Then locationBuilder.Append(" Room-").Append(txtMedicineRoom.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineShelves.Text) Then locationBuilder.Append(" Shelves-").Append(txtMedicineShelves.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineRack.Text) Then locationBuilder.Append(" Rack-").Append(txtMedicineRack.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineBin.Text) Then locationBuilder.Append(" Bin-").Append(txtMedicineBin.Text)

            Dim location As String = locationBuilder.ToString()

            Dim rcvDtl As New Receiving.t_receiving_dtl
            With rcvDtl
                .Received_ID = rcvID
                .Item_ID = itemId
                .PO_Qty = qty
                .Qty_Received = qty
                .Cost = unitCost
                .Location = location
                .Condition = ""
            End With

            Dim rcvDtlID As Long = rcvDtl.save()
            If rcvDtlID <= 0 Then Throw New Exception("Failed to save Receiving Detail.")

            Dim airNo As String = objDerived.GetValue(
            "EXEC AMS.sp_Generate_AIR_No '" & acqDate.ToString("MM/dd/yyyy") & "'",
            CommandType.Text)

            Dim airHdr As New t_inspection_and_acceptance_hdr
            With airHdr
                .AIR_No = airNo
                .AIR_Date = Date.Today
                .Date_Received = Date.Today
                .Date_Inspect = Date.Today
                .Date_Accepted = Date.Today
                .Invoice_No = ""
                .Invoice_date = Date.Today
                .PO_No = "Starting Inventory"
                .Supplier_ID = 0
                .isComplete = True
                .POHdr_ID = 0
                .RC_ID = 0
                .Function_ID = 0
                .Received_ID = rcvID
            End With

            Dim airHdrID As Long = airHdr.save()
            If airHdrID <= 0 Then Throw New Exception("Failed to save AIR Header.")

            objDerived.Execute(
            "UPDATE AMS.AIR_Hdr SET Received_ID=" & rcvID &
            ", UserID='" & Replace(Convert.ToString(Session("@UserName")), "'", "''") & "'" &
            " WHERE AIRHdr_ID=" & airHdrID,
            CommandType.Text)

            Dim airDtl As New t_inspection_and_acceptance_dtl
            With airDtl
                .AIRHdr_ID = airHdrID
                .Item_ID = itemId
                .Qty = qty
                .Cost = unitCost
                .GA_ID = gaId
            End With

            Dim airDtlID As Long = airDtl.save()
            If airDtlID <= 0 Then Throw New Exception("Failed to save AIR Detail.")

            Dim whId As Integer = 0
            Integer.TryParse(Convert.ToString(drpMedicineWarehouse.SelectedValue), whId)

            Dim stock As New Supplies_Stock
            With stock
                .StockDate = Date.Today
                .Item_ID = itemId
                .Qty = qty
                .Balance = qty
                .Location = location
                .Expiration_Date = #1/1/1900#
                .Cost = unitCost
                .Issuance = 0
                .RC_ID = 0
                .Function_ID = 0
                .Project_ID = 0
                .Program_id = 0
                .F_ID = 4
                .AIRDtl_ID = airDtlID
                .GA_ID = gaId
                .Warehouseid = whId
                .ReorderPt = reorderPt
            End With

            Dim stockID As Long = stock.save()
            If stockID <= 0 Then Throw New Exception("Failed to save Stock.")

            objDerived.Execute(
            "UPDATE AMS.Stock SET AIR_HDR_ID = 0, Received_ID=" & rcvID &
            " WHERE StockID=" & stockID,
            CommandType.Text)

            Dim unitDesc As String = objDerived.GetValue(
            "SELECT TOP 1 AMS.m_Unit.Description " &
            "FROM AMS.m_Unit " &
            "INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID " &
            "WHERE dbo.m_item.Item_ID = " & itemId,
            CommandType.Text)

            Dim stockLedger As New t_StockLedger
            With stockLedger
                .StockID = stockID
                .Trans_Type = "Starting Balance"
                .Ref = airNo
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .ReceivedBy = ""
                .CreditQty = 0D
                .CreditUnit = "-"
                .CreditCost = 0D
                .dDate = acqDate
                .Item_ID = itemId
                .DebitQty = qty
                .DebitCost = Decimal.Round(unitCost * qty, 2)
                .DebitUnit = Convert.ToString(unitDesc)
                .BalanceUnit = Convert.ToString(unitDesc)
                .BalanceQty = qty
                .BalanceCost = Decimal.Round(unitCost * qty, 2)
            End With

            stockLedger.save()

            Dim sqlMed As String =
                "INSERT INTO AMS.TBMedicine_Info (" &
                "StockID,AIRDtl_ID,Received_ID,Item_ID,Description,Drugname,BrandName,SupplierId,Dose,DeliveryDate," &
                "Depreciatedrate,Depreciatedvalue,Location,Status,bfadno,itemcode,reorderpt) VALUES (" &
                stockID & "," &
                airDtlID & "," &
                rcvID & "," &
                itemId & "," &
                "NULL," &
                "NULL," &
                "N'" & Replace(txtMedicineBrandName.Text, "'", "''") & "'," &
                "0," &
                "N'" & Replace(txtMedicineDose.Text, "'", "''") & "'," &
                "'" & acqDate.ToString("MM/dd/yyyy") & "'," &
                "'0'," &
                "0," &
                "N'" & Replace(location, "'", "''") & "'," &
                "N'Received'," &
                "N'" & Replace(txtBFADNo.Text, "'", "''") & "'," &
                "N'" & Replace(txtItemCode.Text, "'", "''") & "'," &
                reorderPt & "); SELECT CAST(SCOPE_IDENTITY() AS bigint)"


            Dim medicineID As Long = CLng(objDerived.GetValue(sqlMed, CommandType.Text))
            If medicineID <= 0 Then Throw New Exception("Failed to save TBMedicine_Info.")

            Dim actualPrice As Decimal = 0D
            Decimal.TryParse(txtMedicineUnitprice.Text.Replace(",", ""), actualPrice)

            Dim sellingPrice As Decimal = 0D
            Decimal.TryParse(txtSellPrice.Text.Replace(",", ""), sellingPrice)

            Dim mftgDate As Date
            Dim expDate As Date
            Dim alertDate As Date

            Dim mftgSql As String = "NULL"
            If Date.TryParse(txtMedicineMdate.Text, mftgDate) Then mftgSql = "'" & mftgDate.ToString("MM/dd/yyyy") & "'"

            Dim expSql As String = "NULL"
            If Date.TryParse(txtMedicineEdate.Text, expDate) Then expSql = "'" & expDate.ToString("MM/dd/yyyy") & "'"

            Dim alertSql As String = "NULL"
            If Date.TryParse(txtMedicineAlert.Text, alertDate) Then alertSql = "'" & alertDate.ToString("MM/dd/yyyy") & "'"

            Dim sqlMedDtl As String =
            "INSERT INTO AMS.TBMedicine_DTl (" &
            "MedicineID,StockId,Item_ID,Form,OTCRx,Mftgdate,Batch,Lot,ActualPrice,EpiryDate,Alert,SellingPrice,Unit_ID) VALUES (" &
            medicineID & "," &
            stockID & "," &
            itemId & "," &
            "N'" & Replace(txtMedicineForm.Text, "'", "''") & "'," &
            "N'" & Replace(txtMedicineOTXRX.Text, "'", "''") & "'," &
            mftgSql & "," &
            "N'" & Replace(txtMedicineBatch.Text, "'", "''") & "'," &
            "N'" & Replace(txtMedicineLot.Text, "'", "''") & "'," &
            actualPrice.ToString(System.Globalization.CultureInfo.InvariantCulture) & "," &
            expSql & "," &
            alertSql & "," &
            sellingPrice.ToString(System.Globalization.CultureInfo.InvariantCulture) & "," &
            CLng(drpUnit.SelectedValue) & ")"

            objDerived.Execute(sqlMedDtl, CommandType.Text)

            LoadLedger()
            ClearTextBoxesMedicine()
            MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Transaction has been successfully updated.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, ex.Message)
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

            If drpGenericName.SelectedValue = "0" OrElse
           String.IsNullOrWhiteSpace(txtMedicineUnitprice.Text) OrElse
           String.IsNullOrWhiteSpace(txtMedicineQuantity.Text) OrElse
           String.IsNullOrWhiteSpace(txtSellectDate.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1,
            "Please complete required fields: Generic Name, Unit Cost, Quantity and Date.")
                Exit Sub
            End If

            Dim qty As Decimal
            Dim unitCost As Decimal
            Dim reorderPt As Integer
            Dim acqDate As Date

            If Not Decimal.TryParse(txtMedicineQuantity.Text.Replace(",", ""), qty) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Quantity is not numeric.")
                Exit Sub
            End If

            If Not Decimal.TryParse(txtMedicineUnitprice.Text.Replace(",", ""), unitCost) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Unit Cost is not numeric.")
                Exit Sub
            End If


            If Not Date.TryParse(txtSellectDate.Text, acqDate) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Invalid Date.")
                Exit Sub
            End If

            Dim itemId As Long = CLng(drpGenericName.SelectedValue)
            Dim gaId As Long = CLng(ddGlAccount.SelectedValue)

            Dim whId As Integer = 0
            Integer.TryParse(Convert.ToString(drpMedicineWarehouse.SelectedValue), whId)

            Dim unitIdVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpUnit.SelectedValue), unitIdVal)

            Dim locationBuilder As New System.Text.StringBuilder()
            If Not String.IsNullOrWhiteSpace(txtMedicineBay.Text) Then locationBuilder.Append("Bay-").Append(txtMedicineBay.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineColumn.Text) Then locationBuilder.Append(" Column-").Append(txtMedicineColumn.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineFloor.Text) Then locationBuilder.Append(" Floor-").Append(txtMedicineFloor.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineRoom.Text) Then locationBuilder.Append(" Room-").Append(txtMedicineRoom.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineShelves.Text) Then locationBuilder.Append(" Shelves-").Append(txtMedicineShelves.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineRack.Text) Then locationBuilder.Append(" Rack-").Append(txtMedicineRack.Text)
            If Not String.IsNullOrWhiteSpace(txtMedicineBin.Text) Then locationBuilder.Append(" Bin-").Append(txtMedicineBin.Text)

            Dim location As String = locationBuilder.ToString()
            Dim locEsc As String = Replace(location, "'", "''")

            Dim actualPrice As Decimal = 0D
            Decimal.TryParse(txtMedicineUnitprice.Text.Replace(",", ""), actualPrice)

            Dim sellingPrice As Decimal = 0D
            Decimal.TryParse(txtSellPrice.Text.Replace(",", ""), sellingPrice)

            Dim mftgDate As Date
            Dim expDate As Date
            Dim alertDate As Date

            Dim mftgSql As String = "NULL"
            If Date.TryParse(txtMedicineMdate.Text, mftgDate) Then mftgSql = "'" & mftgDate.ToString("yyyy-MM-dd") & "'"

            Dim expSql As String = "NULL"
            If Date.TryParse(txtMedicineEdate.Text, expDate) Then expSql = "'" & expDate.ToString("yyyy-MM-dd") & "'"

            Dim alertSql As String = "NULL"
            If Date.TryParse(txtMedicineAlert.Text, alertDate) Then alertSql = "'" & alertDate.ToString("yyyy-MM-dd") & "'"

            objDerived.Execute(
            "UPDATE AMS.Stock SET " &
            "Item_ID = " & itemId & ", " &
            "GA_ID = " & gaId & ", " &
            "Cost = " & unitCost.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "ReorderPt = " & reorderPt & ", " &
            "StockDate = '" & acqDate.ToString("yyyy-MM-dd") & "', " &
            "Qty = " & qty.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "Balance = " & qty.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "Location = '" & locEsc & "', " &
            "Warehouse_ID = " & whId & " " &
            "WHERE StockID = " & stockID,
            CommandType.Text
        )

            objDerived.Execute(
            "UPDATE AMS.TBMedicine_Info SET " &
            "Item_ID = " & itemId & ", " &
            "BrandName = N'" & Replace(txtMedicineBrandName.Text, "'", "''") & "', " &
            "Dose = N'" & Replace(txtMedicineDose.Text, "'", "''") & "', " &
            "DeliveryDate = '" & acqDate.ToString("yyyy-MM-dd") & "', " &
            "Location = N'" & locEsc & "', " &
            "Status = N'Received', " &
            "bfadno = N'" & Replace(txtBFADNo.Text, "'", "''") & "', " &
            "itemcode = N'" & Replace(txtItemCode.Text, "'", "''") & "', " &
            "reorderpt = " & reorderPt & " " &
            "WHERE StockID = " & stockID,
            CommandType.Text
        )

            objDerived.Execute(
            "UPDATE AMS.TBMedicine_DTl SET " &
            "Item_ID = " & itemId & ", " &
            "Form = N'" & Replace(txtMedicineForm.Text, "'", "''") & "', " &
            "OTCRx = N'" & Replace(txtMedicineOTXRX.Text, "'", "''") & "', " &
            "Mftgdate = " & mftgSql & ", " &
            "Batch = N'" & Replace(txtMedicineBatch.Text, "'", "''") & "', " &
            "Lot = N'" & Replace(txtMedicineLot.Text, "'", "''") & "', " &
            "ActualPrice = " & actualPrice.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "EpiryDate = " & expSql & ", " &
            "Alert = " & alertSql & ", " &
            "SellingPrice = " & sellingPrice.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "Unit_ID = " & unitIdVal & " " &
            "WHERE StockId = " & stockID,
            CommandType.Text
        )

            Dim unitDesc As String = objDerived.GetValue(
            "SELECT TOP 1 AMS.m_Unit.Description " &
            "FROM AMS.m_Unit " &
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
            "   dDate = '" & acqDate.ToString("yyyy-MM-dd") & "', " &
            "   Item_ID = " & itemId & ", " &
            "   DebitQty = " & qty.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "   DebitCost = ROUND(" & (qty * unitCost).ToString(System.Globalization.CultureInfo.InvariantCulture) & ", 2), " &
            "   DebitUnit = '" & unitDesc & "', " &
            "   BalanceUnit = '" & unitDesc & "', " &
            "   BalanceQty = " & qty.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
            "   BalanceCost = ROUND(" & (qty * unitCost).ToString(System.Globalization.CultureInfo.InvariantCulture) & ", 2) ",
            CommandType.Text
        )

            LoadLedger()
            ClearTextBoxesMedicine()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.Message)
        End Try
    End Sub


    Protected Sub btnMedicineCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        ClearTextBoxesMedicine()
    End Sub

    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        If cb Is Nothing Then Exit Sub

        Dim row As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
        If row Is Nothing Then Exit Sub

        grdLedger.SelectedIndex = row.RowIndex

        If Not cb.Checked Then
            ClearTextBoxesMedicine()
            Exit Sub
        End If

        Dim stockObj As Object = grdLedger.SelectedDataKey("StockID")
        Dim stockID As Long = 0
        If stockObj IsNot Nothing AndAlso Not IsDBNull(stockObj) Then
            Long.TryParse(stockObj.ToString(), stockID)
        End If

        If stockID <= 0 Then
            ClearTextBoxesMedicine()
            Exit Sub
        End If

        LoadMedicineDetailsFromStock(stockID)
    End Sub

    Private Sub LoadMedicineDetailsFromStock(ByVal stockID As Long)
        Dim dt As DataTable = objDerived.GetDataTable("EXEC AMS.sp_Encoding_Medicines " & stockID, CommandType.Text)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearTextBoxesMedicine()
            Exit Sub
        End If

        Dim r As DataRow = dt.Rows(0)

        Dim itemIdStr As String = Convert.ToString(r("Item_ID")).Trim()
        If drpGenericName.Items.Count > 0 AndAlso itemIdStr <> "" AndAlso drpGenericName.Items.FindByValue(itemIdStr) IsNot Nothing Then
            drpGenericName.SelectedValue = itemIdStr
        ElseIf drpGenericName.Items.Count > 0 Then
            drpGenericName.SelectedIndex = 0
        End If

        Dim unitIdStr As String = Convert.ToString(r("Unit_ID")).Trim()
        If drpUnit.Items.Count > 0 AndAlso unitIdStr <> "" AndAlso drpUnit.Items.FindByValue(unitIdStr) IsNot Nothing Then
            drpUnit.SelectedValue = unitIdStr
        ElseIf drpUnit.Items.Count > 0 Then
            drpUnit.SelectedIndex = 0
        End If

        '  added
        txtBFADNo.Text = Convert.ToString(r("bfadno"))
        txtItemCode.Text = Convert.ToString(r("itemcode"))

        txtMedicineBrandName.Text = Convert.ToString(r("BrandName"))
        txtMedicineDose.Text = Convert.ToString(r("Dose"))

        txtMedicineForm.Text = Convert.ToString(r("Form"))
        txtMedicineOTXRX.Text = Convert.ToString(r("OTCRx"))
        txtMedicineBatch.Text = Convert.ToString(r("Batch"))
        txtMedicineLot.Text = Convert.ToString(r("Lot"))

        txtMedicineQuantity.Text = Convert.ToString(r("Quantity"))
        txtMedicineUnitprice.Text = Convert.ToString(r("UnitCost"))
        txtSellPrice.Text = Convert.ToString(r("SellingPrice"))
        txtReOrderPt.Text = Convert.ToString(r("ReorderPoint"))

        Dim dtStr As String = Convert.ToString(r("Date"))
        Dim dtVal As DateTime
        If DateTime.TryParse(dtStr, dtVal) Then
            txtSellectDate.Text = dtVal.ToString("MM/dd/yyyy")
        Else
            txtSellectDate.Text = dtStr
        End If

        Dim mftgStr As String = Convert.ToString(r("Mftgdate"))
        Dim mftgVal As DateTime
        If DateTime.TryParse(mftgStr, mftgVal) Then
            txtMedicineMdate.Text = mftgVal.ToString("MM/dd/yyyy")
        Else
            txtMedicineMdate.Text = mftgStr
        End If

        Dim expStr As String = Convert.ToString(r("EpiryDate"))
        Dim expVal As DateTime
        If DateTime.TryParse(expStr, expVal) Then
            txtMedicineEdate.Text = expVal.ToString("MM/dd/yyyy")
        Else
            txtMedicineEdate.Text = expStr
        End If

        Dim alertStr As String = Convert.ToString(r("Alert"))
        Dim alertVal As DateTime
        If DateTime.TryParse(alertStr, alertVal) Then
            txtMedicineAlert.Text = alertVal.ToString("MM/dd/yyyy")
        Else
            txtMedicineAlert.Text = alertStr
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

        btnMedicineSave.Text = "EDIT"
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
    Private Sub AddTrace(ByVal msg As String)
        System.Diagnostics.Debug.WriteLine(msg)
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

    Private Sub BindEmptyPPQ()
        Dim dt As New DataTable()
        dt.Columns.Add("PPQ_ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("QtyPack", GetType(Decimal))
        dt.Columns.Add("Unit_cost", GetType(Decimal))
        dt.Columns.Add("PPQ_Percent", GetType(Decimal))
        dt.Columns.Add("Selling_Price", GetType(Decimal))

        GridPPQ.DataSource = dt
        GridPPQ.DataBind()

        btnMedicineRemove.Enabled = False
    End Sub

    Private Sub ClearMedicineDetailsOnly()
        txtMedicineBrandName.Text = ""
        txtMedicineForm.Text = ""
        txtMedicineDose.Text = ""
        txtMedicineOTXRX.Text = ""
        txtMedicineUnitprice.Text = ""
        txtBFADNo.Text = ""
        txtSellPrice.Text = ""
        txtItemCode.Text = ""
        txtReOrderPt.Text = ""
        txtMedicineQuantity.Text = ""
        txtSellectDate.Text = ""

        txtMedicineBatch.Text = ""
        txtMedicineLot.Text = ""
        txtMedicineMdate.Text = ""
        txtMedicineEdate.Text = ""
        txtMedicineAlert.Text = ""

        txtMedicineBay.Text = ""
        txtMedicineColumn.Text = ""
        txtMedicineFloor.Text = ""
        txtMedicineRoom.Text = ""
        txtMedicineShelves.Text = ""
        txtMedicineRack.Text = ""
        txtMedicineBin.Text = ""

        txtQtyPack.Text = ""
        txtUnitCost.Text = ""
        txtPercent.Text = ""
        txtSellingPrice1.Text = ""

        btnMedicineRemove.Enabled = False

        grdLedger.SelectedIndex = -1
        For Each row As GridViewRow In grdLedger.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim cb As CheckBox = TryCast(row.FindControl("cbInspection"), CheckBox)
                If cb IsNot Nothing Then cb.Checked = False
            End If
        Next
    End Sub

    Private Sub ClearTextBoxesMedicine()
        ClearMedicineDetailsOnly()

        If drpUnit IsNot Nothing AndAlso drpUnit.Items.Count > 0 Then
            drpUnit.ClearSelection()
            drpUnit.SelectedIndex = 0
        End If

        If drpMedicineWarehouse IsNot Nothing AndAlso drpMedicineWarehouse.Items.Count > 0 Then
            drpMedicineWarehouse.ClearSelection()
            drpMedicineWarehouse.SelectedIndex = 0
        End If

        If btnMedicineSave IsNot Nothing Then
            btnMedicineSave.Text = "SAVE"
            btnMedicineSave.Enabled = True
        End If
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
            btnMedicineSave.Text = "UPDATE"
            btnMedicineSave.Enabled = True
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





    Private Function ComputePPQSellingPrice(ByVal qtyPack As Decimal, ByVal unitCost As Decimal, ByVal percent As Decimal) As Decimal
        Dim totalCostPerPack As Decimal = qtyPack * unitCost
        Dim markupPerPack As Decimal = totalCostPerPack * (percent / 100D)
        Dim sellingPricePerPack As Decimal = totalCostPerPack + markupPerPack

        If qtyPack <= 0 Then
            Return 0D
        End If

        Return Math.Round(sellingPricePerPack / qtyPack, 2)
    End Function


End Class
