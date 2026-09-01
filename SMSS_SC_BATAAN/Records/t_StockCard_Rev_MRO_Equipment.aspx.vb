Imports System.Data
Imports System.Data.SqlClient


Partial Class Records_t_StockCard_Rev_MRO_Equipment
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
            "WHERE ClassificationName = 'MRO Equipment'",
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

            ClearEquipmentName()
            loadwarehouse()
            BindEmptyLedger()

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
        loadwarehouse()
    End Sub
    Private Sub ClearEquipmentName()
        drpMROEquipmentName.Items.Clear()

        drpMROEquipmentName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        drpMROEquipmentName.Enabled = True
    End Sub


    Private Sub LoadEquipmentNames()

        If ddGlAccount.SelectedValue Is Nothing OrElse
       ddGlAccount.SelectedValue = "" OrElse
       ddGlAccount.SelectedValue = "0" Then

            ClearEquipmentName()
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

        Dim dt As DataTable = objDerived.GetDataTable(sqlQuery, CommandType.Text)

        If dt Is Nothing Then
            ClearEquipmentName()
            Exit Sub
        End If

        Dim dr As DataRow = dt.NewRow()
        dr("Item_ID") = 0
        dr("Item_Desc") = "Select"
        dt.Rows.InsertAt(dr, 0)

        drpMROEquipmentName.DataSource = dt
        drpMROEquipmentName.DataTextField = "Item_Desc"
        drpMROEquipmentName.DataValueField = "Item_ID"
        drpMROEquipmentName.DataBind()

        drpMROEquipmentName.Enabled = True
    End Sub

    Public Sub loadUnit()
        Dim dt As DataTable = objDerived.GetDataTable("select Unit_ID,Description From ams.m_Unit as a order by Description", CommandType.Text)
        drpMROEquipmentUnit.DataSource = dt
        drpMROEquipmentUnit.DataTextField = "Description"
        drpMROEquipmentUnit.DataValueField = "Unit_ID"
        drpMROEquipmentUnit.DataBind()


        Dim Unit_ID As Integer = objDerived.GetValue("SELECT Unit_ID FROM DBO.m_item WHERE Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        drpMROEquipmentUnit.SelectedValue = Unit_ID

    End Sub

    Public Sub loadwarehouse()
        Dim dt As DataTable = objDerived.GetDataTable("select warehouse_id,wname From ams.loc_warehouse where isUsed='True'", CommandType.Text)
        drpEquipmentWarehouse.DataTextField = "wname"
        drpEquipmentWarehouse.DataValueField = "warehouse_id"
        drpEquipmentWarehouse.DataSource = dt
        drpEquipmentWarehouse.DataBind()
    End Sub

    Public Sub LoadLedger()
        Dim dtStock As DataTable = objDerived.GetDataTable(
            "EXEC [AMS].[sp_SuppliesLedger] '" & drpMROEquipmentName.SelectedValue & "'",
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

        LoadEquipmentNames()
        loadwarehouse()
        BindEmptyLedger()

    End Sub

    Protected Sub ddGlAccount_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As System.EventArgs
)

        LoadSubClassifications()
        ClearEquipmentName()
        LoadEquipmentNames()
        BindEmptyLedger()

    End Sub


    Protected Sub drpMROEquipmentName_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Session("Item_ID") = drpMROEquipmentName.SelectedValue
        LoadLedger()
        loadUnit()
        loadUsefulLife()
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

    Protected Sub btnROP_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub BtnCompute_Click(sender As Object, e As EventArgs)
        Try
            RP.Text = DRP.Text * LTD.Text
            ModalPopupExtender1.Show()
            txtEquipmentReOrderPt.Text = DRP.Text * LTD.Text
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill Demand Per Day & Lead Time For Deliver.")
        End Try
    End Sub



    Protected Sub btnEquipmentSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        If btnEquipmentSave.Text = "SAVE" Then
            save()

        ElseIf btnEquipmentSave.Text = "EDIT" Then
            loadApprovalOfficer()
            ModalPopupExtenderApproval.Show()

        ElseIf btnEquipmentSave.Text = "UPDATE" Then
            update()
        End If
    End Sub

    Public Sub save()
        Try
            '========================
            ' 1) VALIDATIONS
            '========================
            If drpMROEquipmentName.SelectedValue = "0" OrElse
       ddGlAccount.SelectedValue = "0" OrElse
       String.IsNullOrWhiteSpace(txtEquipmentAcqCost.Text) OrElse
       String.IsNullOrWhiteSpace(txtEquipmentQuantity.Text) OrElse
       String.IsNullOrWhiteSpace(txtEquipmentAcqDate.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1,
            "Please complete required fields: Name, Account, Acquisition Cost, Quantity, Acquisition Date.")
                Exit Sub
            End If

            Dim qty As Decimal
            Dim unitCost As Decimal
            Dim reorderPt As Integer
            Dim acqDate As Date

            If Not Decimal.TryParse(txtEquipmentQuantity.Text.Replace(",", ""), qty) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Quantity is not numeric.")
                Exit Sub
            End If

            If Not Decimal.TryParse(txtEquipmentAcqCost.Text.Replace(",", ""), unitCost) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Acquisition Cost is not numeric.")
                Exit Sub
            End If



            If Not Date.TryParse(txtEquipmentAcqDate.Text, acqDate) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Invalid Acquisition Date.")
                Exit Sub
            End If

            Dim itemId As Long = CLng(drpMROEquipmentName.SelectedValue)
            Dim gaId As Long = CLng(ddGlAccount.SelectedValue)

            '========================
            ' 2) RECEIVING HEADER
            '========================
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

            '========================
            ' 3) LOCATION STRING (clean build)
            '========================
            Dim locationBuilder As New System.Text.StringBuilder()
            If Not String.IsNullOrWhiteSpace(txtEquipmentBay.Text) Then locationBuilder.Append("Bay-").Append(txtEquipmentBay.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentColumn.Text) Then locationBuilder.Append(" Column-").Append(txtEquipmentColumn.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentFloor.Text) Then locationBuilder.Append(" Floor-").Append(txtEquipmentFloor.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentRoom.Text) Then locationBuilder.Append(" Room-").Append(txtEquipmentRoom.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentShelves.Text) Then locationBuilder.Append(" Shelves-").Append(txtEquipmentShelves.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentRack.Text) Then locationBuilder.Append(" Rack-").Append(txtEquipmentRack.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentBin.Text) Then locationBuilder.Append(" Bin-").Append(txtEquipmentBin.Text)

            Dim location As String = locationBuilder.ToString()

            '========================
            ' 4) RECEIVING DETAIL
            '========================
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

            '========================
            ' 5) AIR HEADER
            '========================
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

            '========================
            ' 6) AIR DETAIL
            '========================
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

            '========================
            ' 7) STOCK
            '========================
            Dim whId As Integer = 0
            Integer.TryParse(Convert.ToString(drpEquipmentWarehouse.SelectedValue), whId)

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

            '========================
            ' 8) STOCK LEDGER (MISSING PART) -> INSERT Starting Balance
            '========================
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

            Dim ledId As Long = stockLedger.save()
            ' (If your t_StockLedger.save() returns nothing/void, remove this check.)
            ' If ledId <= 0 Then Throw New Exception("Failed to save Stock Ledger (Starting Balance).")

            '========================
            ' 9) TBNONFOOD INSERT
            '========================
            Dim itemDesc As String = drpMROEquipmentName.SelectedItem.Text

            Dim sqlNonFood As String =
        "INSERT INTO AMS.TbNonFood (" &
        "StockId,AIRDtl_ID,Received_ID,Item_ID,Form,OTCRx,Mftgdate,Batch,Lot,ActualPrice," &
        "EpiryDate,Alert,ItemDesc,BrandName,Supplier_ID,DeliveryDate,Storage," &
        "DepreciationRate,DepreciationValue,DepreciationValuePerYear,EquipmentDescription,Status,UploadedBy,DateUploaded," &
        "Dimension,PowerInput,Model,AreaCapacity,Warranty,MarketValue,NoYears," &
        "UsefulLife,SalvageValue,Specs,Unit_ID) VALUES (" &
        stockID & "," &
        airDtlID & "," &
        rcvID & "," &
        itemId & ",NULL,NULL,'01/01/1900',NULL,NULL," &
        unitCost.ToString(System.Globalization.CultureInfo.InvariantCulture) & ",'01/01/1900','01/01/1900'," &
        "'" & Replace(itemDesc, "'", "''") & "',NULL,0," &
        "'" & acqDate.ToString("MM/dd/yyyy") & "',NULL," &
        "'" & Replace(txtEquipmentDepreciatedRate.Text, "'", "''") & "'," &
        Val(txtEquipmentDepreciatedValue.Text.Replace(",", "")).ToString(System.Globalization.CultureInfo.InvariantCulture) & "," &
        Val(txtEquipmentDepreciationValue.Text.Replace(",", "")).ToString(System.Globalization.CultureInfo.InvariantCulture) & "," &
        "N'" & Replace(txtEquipmentDescription.Text, "'", "''") & "'," &
        "'Accepted',NULL,NULL," &
        "'" & Replace(txtEquipmentDimension.Text, "'", "''") & "'," &
        "'" & Replace(txtEquipmentPowerInput.Text, "'", "''") & "'," &
        "'" & Replace(txtEquipmentModel.Text, "'", "''") & "'," &
        "'" & Replace(txtEquipmentAreaCapacity.Text, "'", "''") & "'," &
        "'" & Replace(txtEquipmentWarranty.Text, "'", "''") & "'," &
        Val(txtEquipmentMarketValue.Text.Replace(",", "")).ToString(System.Globalization.CultureInfo.InvariantCulture) & "," &
        Val(txtEquipmentNoYears.Text.Replace(",", "")).ToString(System.Globalization.CultureInfo.InvariantCulture) & "," &
        Val(txtEquipmentUsefulLife.Text.Replace(",", "")).ToString(System.Globalization.CultureInfo.InvariantCulture) & "," &
        Val(txtEquipmentSalvageValue.Text.Replace(",", "")).ToString(System.Globalization.CultureInfo.InvariantCulture) & "," &
        "'" & Replace(txtEquipmentSpecification.Text, "'", "''") & "'," &
        drpMROEquipmentUnit.SelectedValue & ")"

            objDerived.Execute(sqlNonFood, CommandType.Text)

            LoadLedger()
            ClearTextBoxesEquipment()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")

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

            If drpMROEquipmentName.SelectedValue = "0" OrElse
       ddGlAccount.SelectedValue = "0" OrElse
       String.IsNullOrWhiteSpace(txtEquipmentAcqCost.Text) OrElse
       String.IsNullOrWhiteSpace(txtEquipmentQuantity.Text) OrElse
       String.IsNullOrWhiteSpace(txtEquipmentAcqDate.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please complete required fields: Name, Account, Acquisition Cost, Quantity, Acquisition Date.")
                Exit Sub
            End If

            Dim qtyValue As Decimal
            If Not Decimal.TryParse(txtEquipmentQuantity.Text.Replace(",", ""), qtyValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity is not numeric.")
                Exit Sub
            End If

            Dim unitCostValue As Decimal
            If Not Decimal.TryParse(txtEquipmentAcqCost.Text.Replace(",", ""), unitCostValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Acquisition Cost is not numeric.")
                Exit Sub
            End If

            Dim reorderVal As Integer


            Dim acqDateValue As Date
            If Not Date.TryParse(txtEquipmentAcqDate.Text, acqDateValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Acquisition Date.")
                Exit Sub
            End If

            Dim itemId As Long = 0
            Long.TryParse(Convert.ToString(drpMROEquipmentName.SelectedValue), itemId)

            Dim gaId As Long = 0
            Long.TryParse(Convert.ToString(ddGlAccount.SelectedValue), gaId)

            If itemId <= 0 OrElse gaId <= 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select Name and General Account.")
                Exit Sub
            End If

            Dim whVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpEquipmentWarehouse.SelectedValue), whVal)

            Dim unitIdVal As Integer = 0
            Integer.TryParse(Convert.ToString(drpMROEquipmentUnit.SelectedValue), unitIdVal)

            Dim locationBuilder As New System.Text.StringBuilder()
            If Not String.IsNullOrWhiteSpace(txtEquipmentBay.Text) Then locationBuilder.Append("Bay-").Append(txtEquipmentBay.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentColumn.Text) Then locationBuilder.Append(" Column-").Append(txtEquipmentColumn.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentFloor.Text) Then locationBuilder.Append(" Floor-").Append(txtEquipmentFloor.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentRoom.Text) Then locationBuilder.Append(" Room-").Append(txtEquipmentRoom.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentShelves.Text) Then locationBuilder.Append(" Shelves-").Append(txtEquipmentShelves.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentRack.Text) Then locationBuilder.Append(" Rack-").Append(txtEquipmentRack.Text)
            If Not String.IsNullOrWhiteSpace(txtEquipmentBin.Text) Then locationBuilder.Append(" Bin-").Append(txtEquipmentBin.Text)

            Dim location As String = locationBuilder.ToString()
            Dim locEsc As String = Replace(location, "'", "''")

            Dim dimensionVal As String = Replace(txtEquipmentDimension.Text.Trim(), "'", "''")
            Dim powerInputVal As String = Replace(txtEquipmentPowerInput.Text.Trim(), "'", "''")
            Dim modelVal As String = Replace(txtEquipmentModel.Text.Trim(), "'", "''")
            Dim areaCapVal As String = Replace(txtEquipmentAreaCapacity.Text.Trim(), "'", "''")
            Dim warrantyVal As String = Replace(txtEquipmentWarranty.Text.Trim(), "'", "''")
            Dim specsVal As String = Replace(txtEquipmentSpecification.Text.Trim(), "'", "''")

            Dim marketValueDec As Decimal = 0D
            Decimal.TryParse(txtEquipmentMarketValue.Text.Replace(",", ""), marketValueDec)

            Dim noYearsInt As Integer = 0
            Integer.TryParse(txtEquipmentNoYears.Text.Replace(",", ""), noYearsInt)

            Dim usefulLifeInt As Integer = 0
            Integer.TryParse(txtEquipmentUsefulLife.Text.Replace(",", ""), usefulLifeInt)

            Dim salvageValueDec As Decimal = 0D
            Decimal.TryParse(txtEquipmentSalvageValue.Text.Replace(",", ""), salvageValueDec)

            Dim depValueDec As Decimal = 0D
            Decimal.TryParse(txtEquipmentDepreciatedValue.Text.Replace(",", ""), depValueDec)

            Dim depRateStr As String = Replace(txtEquipmentDepreciatedRate.Text.Trim(), "'", "''")


            Dim equipDescVal As String = Replace(txtEquipmentDescription.Text.Trim(), "'", "''")

            Dim depValuePerYearDec As Decimal = 0D
            Decimal.TryParse(txtEquipmentDepreciationValue.Text.Replace(",", ""), depValuePerYearDec)


            objDerived.Execute(
        "UPDATE AMS.Stock SET " &
        "Item_ID = " & itemId & ", " &
        "GA_ID = " & gaId & ", " &
        "Cost = " & unitCostValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
        "ReorderPt = " & reorderVal & ", " &
        "StockDate = '" & acqDateValue.ToString("yyyy-MM-dd") & "', " &
        "Qty = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
        "Balance = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
        "Location = '" & locEsc & "', " &
        "Warehouse_ID = " & whVal & " " &
        "WHERE StockID = " & stockID,
        CommandType.Text
    )

            Dim itemDesc As String = Replace(drpMROEquipmentName.SelectedItem.Text.Trim(), "'", "''")

            objDerived.Execute(
        "UPDATE AMS.TbNonFood SET " &
        "Item_ID = " & itemId & ", " &
        "Unit_ID = " & unitIdVal & ", " &
        "ActualPrice = " & unitCostValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
        "ItemDesc = '" & itemDesc & "', " &
        "DeliveryDate = '" & acqDateValue.ToString("yyyy-MM-dd") & "', " &
        "DepreciationRate = '" & depRateStr & "', " &
        "DepreciationValue = " & depValueDec.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
        "Status = 'Accepted', " &
        "Dimension = '" & dimensionVal & "', " &
        "PowerInput = '" & powerInputVal & "', " &
        "Model = '" & modelVal & "', " &
        "AreaCapacity = '" & areaCapVal & "', " &
        "Warranty = '" & warrantyVal & "', " &
        "MarketValue = " & marketValueDec.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
        "NoYears = " & noYearsInt.ToString() & ", " &
        "UsefulLife = " & usefulLifeInt.ToString() & ", " &
        "SalvageValue = " & salvageValueDec.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
        "Specs = '" & specsVal & "', " &
        "EquipmentDescription = '" & equipDescVal & "', " &
        "DepreciationValuePerYear = " & depValuePerYearDec.ToString(System.Globalization.CultureInfo.InvariantCulture) & " " &
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
        "   dDate = '" & acqDateValue.ToString("yyyy-MM-dd") & "', " &
        "   Item_ID = " & itemId & ", " &
        "   DebitQty = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
        "   DebitCost = ROUND(" & (qtyValue * unitCostValue).ToString(System.Globalization.CultureInfo.InvariantCulture) & ", 2), " &
        "   DebitUnit = '" & unitDesc & "', " &
        "   BalanceUnit = '" & unitDesc & "', " &
        "   BalanceQty = " & qtyValue.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " &
        "   BalanceCost = ROUND(" & (qtyValue * unitCostValue).ToString(System.Globalization.CultureInfo.InvariantCulture) & ", 2) ",
        CommandType.Text
    )

            LoadLedger()
            ClearTextBoxesEquipment()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.Message)
        End Try
    End Sub

    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        If cb Is Nothing Then Exit Sub

        Dim row As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
        If row Is Nothing Then Exit Sub

        grdLedger.SelectedIndex = row.RowIndex

        If Not cb.Checked Then
            ClearTextBoxesEquipment()
            Exit Sub
        End If

        Dim stockObj As Object = grdLedger.SelectedDataKey("StockID")
        Dim stockID As Long = 0
        If stockObj IsNot Nothing AndAlso Not IsDBNull(stockObj) Then
            Long.TryParse(stockObj.ToString(), stockID)
        End If

        If stockID <= 0 Then
            ClearTextBoxesEquipment()
            Exit Sub
        End If

        LoadEquipmentDetailsFromStock(stockID)
    End Sub

    Private Sub LoadEquipmentDetailsFromStock(ByVal stockID As Long)
        Dim dt As DataTable = objDerived.GetDataTable("EXEC AMS.sp_Encoding_Supplies " & stockID, CommandType.Text)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearTextBoxesEquipment()
            Exit Sub
        End If

        Dim r As DataRow = dt.Rows(0)

        Dim itemIdStr As String = Convert.ToString(r("Item_ID")).Trim()
        If drpMROEquipmentName.Items.Count > 0 AndAlso itemIdStr <> "" AndAlso drpMROEquipmentName.Items.FindByValue(itemIdStr) IsNot Nothing Then
            drpMROEquipmentName.SelectedValue = itemIdStr
        ElseIf drpMROEquipmentName.Items.Count > 0 Then
            drpMROEquipmentName.SelectedIndex = 0
        End If

        Dim unitIdStr As String = Convert.ToString(r("NonFoodUnit")).Trim()
        If drpMROEquipmentUnit.Items.Count > 0 AndAlso unitIdStr <> "" AndAlso drpMROEquipmentUnit.Items.FindByValue(unitIdStr) IsNot Nothing Then
            drpMROEquipmentUnit.SelectedValue = unitIdStr
        ElseIf drpMROEquipmentUnit.Items.Count > 0 Then
            drpMROEquipmentUnit.SelectedIndex = 0
        End If

        txtEquipmentDescription.Text = Convert.ToString(r("NonFoodEquipmentDescription"))
        txtEquipmentDimension.Text = Convert.ToString(r("NonFoodDimension"))
        txtEquipmentPowerInput.Text = Convert.ToString(r("NonFoodPowerInput"))
        txtEquipmentAreaCapacity.Text = Convert.ToString(r("NonFoodAreaCapacity"))
        txtEquipmentModel.Text = Convert.ToString(r("NonFoodModel"))
        txtEquipmentWarranty.Text = Convert.ToString(r("NonFoodWarranty"))
        txtEquipmentSpecification.Text = Convert.ToString(r("NonFoodSpecs"))

        txtEquipmentReOrderPt.Text = Convert.ToString(r("ReorderPoint"))
        txtEquipmentQuantity.Text = Convert.ToString(r("Quantity"))
        txtEquipmentAcqCost.Text = Convert.ToString(r("UnitCost"))
        txtEquipmentDepreciatedRate.Text = Convert.ToString(r("NonFoodDepreciationRate"))
        txtEquipmentDepreciatedValue.Text = Convert.ToString(r("NonFoodDepreciationValue"))
        txtEquipmentDepreciationValue.Text = Convert.ToString(r("NonFoodDepreciationValuePerYear"))

        '  ADDED: missing acquisition fields
        txtEquipmentMarketValue.Text = Convert.ToString(r("NonFoodMarketValue"))
        txtEquipmentNoYears.Text = Convert.ToString(r("NonFoodNoYears"))
        txtEquipmentUsefulLife.Text = Convert.ToString(r("NonFoodUsefulLife"))
        txtEquipmentSalvageValue.Text = Convert.ToString(r("NonFoodSalvageValue"))

        Dim dtStr As String = Convert.ToString(r("Date"))
        Dim dtVal As DateTime
        If DateTime.TryParse(dtStr, dtVal) Then
            txtEquipmentAcqDate.Text = dtVal.ToString("MM/dd/yyyy")
        Else
            txtEquipmentAcqDate.Text = dtStr
        End If

        Dim whName As String = Convert.ToString(r("Warehouse")).Trim()
        If drpEquipmentWarehouse.Items.Count > 0 AndAlso whName <> "" Then
            Dim it As ListItem = drpEquipmentWarehouse.Items.FindByText(whName)
            If it IsNot Nothing Then
                drpEquipmentWarehouse.ClearSelection()
                it.Selected = True
            Else
                drpEquipmentWarehouse.SelectedIndex = 0
            End If
        ElseIf drpEquipmentWarehouse.Items.Count > 0 Then
            drpEquipmentWarehouse.SelectedIndex = 0
        End If

        txtEquipmentBay.Text = Convert.ToString(r("Bay"))
        txtEquipmentColumn.Text = Convert.ToString(r("Column"))
        txtEquipmentFloor.Text = Convert.ToString(r("Floor"))
        txtEquipmentRoom.Text = Convert.ToString(r("Room"))
        txtEquipmentShelves.Text = Convert.ToString(r("Shelves"))
        txtEquipmentRack.Text = Convert.ToString(r("Rack"))
        txtEquipmentBin.Text = Convert.ToString(r("Bin"))

        btnEquipmentSave.Text = "EDIT"
    End Sub


    Private Sub ClearTextBoxesEquipment()
        '--- Dropdowns ---
        grdLedger.SelectedIndex = -1

        For Each row As GridViewRow In grdLedger.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim cb As CheckBox = TryCast(row.FindControl("cbInspection"), CheckBox)
                If cb IsNot Nothing Then cb.Checked = False
            End If
        Next


        If drpMROEquipmentUnit IsNot Nothing AndAlso drpMROEquipmentUnit.Items.Count > 0 Then
            drpMROEquipmentUnit.ClearSelection()
            drpMROEquipmentUnit.SelectedIndex = 0
        End If

        If drpEquipmentWarehouse IsNot Nothing AndAlso drpEquipmentWarehouse.Items.Count > 0 Then
            drpEquipmentWarehouse.ClearSelection()
            drpEquipmentWarehouse.SelectedIndex = 0
        End If

        '--- Basic info ---
        txtEquipmentDescription.Text = ""
        txtEquipmentDimension.Text = ""
        txtEquipmentPowerInput.Text = ""
        txtEquipmentAreaCapacity.Text = ""
        txtEquipmentModel.Text = ""
        txtEquipmentWarranty.Text = ""
        txtEquipmentSpecification.Text = ""

        '--- Reorder / quantities ---
        txtEquipmentReOrderPt.Text = ""
        txtEquipmentQuantity.Text = ""

        '--- Acquisition / depreciation ---
        txtEquipmentAcqDate.Text = ""
        txtEquipmentMarketValue.Text = ""
        txtEquipmentAcqCost.Text = ""
        txtEquipmentNoYears.Text = ""
        txtEquipmentUsefulLife.Text = ""
        txtEquipmentDepreciatedRate.Text = ""
        txtEquipmentDepreciatedValue.Text = ""
        txtEquipmentDepreciationValue.Text = ""
        txtEquipmentSalvageValue.Text = "0.00"   'matches your markup default

        '--- Location ---
        txtEquipmentBay.Text = ""
        txtEquipmentColumn.Text = ""
        txtEquipmentFloor.Text = ""
        txtEquipmentRoom.Text = ""
        txtEquipmentShelves.Text = ""
        txtEquipmentRack.Text = ""
        txtEquipmentBin.Text = ""

        '--- Image reset ---
        If imgEquipment IsNot Nothing Then
            imgEquipment.ImageUrl = "~/images/blankImage.jpg"
        End If

        '--- Button label/state ---
        If btnEquipmentSave IsNot Nothing Then
            btnEquipmentSave.Text = "SAVE"
            btnEquipmentSave.Enabled = True
        End If
    End Sub


    Protected Sub btnEquipmentCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        ClearTextBoxesEquipment()
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
            btnEquipmentSave.Text = "UPDATE"
            btnEquipmentSave.Enabled = True
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


    Public Sub loadUsefulLife()

        Dim usefulLife As String =
            objDerived.GetValue(
                "SELECT TOP 1 ISNULL(useful_life, 0) " &
                "FROM AMS.item_particular " &
                "WHERE item_particular_id = (" &
                "    SELECT TOP 1 item_particular_id " &
                "    FROM dbo.m_item " &
                "    WHERE Item_ID = '" & Session("Item_ID") & "'" &
                ")",
                CommandType.Text
            )

        If String.IsNullOrWhiteSpace(usefulLife) Then
            txtEquipmentUsefulLife.Text = "0"
        Else
            txtEquipmentUsefulLife.Text = usefulLife
        End If

    End Sub

End Class
