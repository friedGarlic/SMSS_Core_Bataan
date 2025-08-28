Imports System.Data
Imports System.Drawing
Imports System.Configuration
Imports System.Data.SqlClient



Partial Class Inventory_t_for_Acceptance
    Inherits System.Web.UI.Page
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal
    Private pojectdetail As New ProjectDtl
    Dim obj As New AccessRule
    Dim myview As DataView
    Dim total As Decimal = 0
    Dim ImageDocument As New ImageDocument
    Private supplies As New t_supplies_hdr
    Public dinNo As String
    Dim rcv As New Receiving.t_receiving
    Dim rcv_dtl As New Receiving.t_receiving_dtl
    Private objMotorInfo As New ConsolidatedPropertySaving.TbMotor_Info_Acceptance
    Private objMotorDtl As New ConsolidatedPropertySaving.TbMotor_Dtl
#Region "BaseDAL"
    Dim AIR_Hdr As New t_inspection_and_acceptance_hdr
    Dim AIR_Dtl As New t_inspection_and_acceptance_dtl

    '=-= CAPITAL OUTLAY
    Dim Prop_Ledger As New t_PropertyLedger
    Dim Prop_Hdr As New t_property_hdr
    Dim Prop_Dtl As New t_property_dtl

    Dim LandDtl As New ConsolidatedPropertySaving.TBLand_Details
    Dim LandTech As New ConsolidatedPropertySaving.TB_Landdescription
    Dim LandDocument As New ConsolidatedPropertySaving.TbLand_LandDocu
    Dim LandOwner As New ConsolidatedPropertySaving.TbLand_OwnerHistory
    Dim LandValuation As New ConsolidatedPropertySaving.TbLand_Valuation
    Dim LandImprovement As New ConsolidatedPropertySaving.TbLand_Improvements
    Dim LandPropHis As New ConsolidatedPropertySaving.TbLand_PropertyHistory

    Dim BldgInfo As New ConsolidatedPropertySaving.TBBuilding_Details

    Dim EquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info
    Dim EquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details

    Dim FurnitureInfo As New ConsolidatedPropertySaving.TbFurniture_Info
    Dim FurnitureDtl As New ConsolidatedPropertySaving.TbFurniture_Dtl

    Dim MachineInfo As New ConsolidatedPropertySaving.TbMachinery_Information
    Dim MachineDtl As New ConsolidatedPropertySaving.TbMachinery_Dtl

    Dim MotorInfo As New ConsolidatedPropertySaving.TbMotor_Info
    Dim MotorDtl As New ConsolidatedPropertySaving.TbMotor_Dtl

    Dim AmbulanceInfo As New ConsolidatedPropertySaving.TbAmbulance_Info
    Dim AmbulanceDtl As New ConsolidatedPropertySaving.TbAmbulance_Dtl

    Dim PropSerial As New ConsolidatedPropertySaving.PropSerial

    '=-= SUPPLIES
    Dim Stock_Ledger As New t_StockLedger
    Dim Stock As New Supplies_Stock

    Dim OfficeSup As New SupplieINFO

    Dim MedDtl As New ConsolidatedMedicineSaving.TBMedicine_DTl
    Dim MedInfo As New ConsolidatedMedicineSaving.TBMedicine_Info

    Dim Blood As New ConsolidatedMedicineSaving.TbBlood
    Dim NonFood As New ConsolidatedMedicineSaving.TbNonFood
    Dim Food As New ConsolidatedMedicineSaving.TbFood
    Dim Water As New ConsolidatedMedicineSaving.TbWater
#End Region
#Region "property"
    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property

    Private Property AllotmentClass() As Integer
        Get
            Return CType(Session("AllotmentClass"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("AllotmentClass") = value
        End Set
    End Property

    Private Property pPurchase_Order() As DataTable
        Get
            Return CType(Session("pPurchase_Order"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order") = value
        End Set
    End Property

    Private Property pPurchase_Order_detail() As DataTable
        Get
            Return CType(Session("pPurchase_Order_detail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order_detail") = value
        End Set
    End Property

    Private Property pInspection_detail() As DataTable
        Get
            Return CType(Session("pInspection_detail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pInspection_detail") = value
        End Set
    End Property

    Private Property pGoodsPerSupplier(ByVal supplier_id As String) As DataTable
        Get
            Return CType(Session(supplier_id), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session(supplier_id) = value
        End Set
    End Property

    Private Property pItemForSerial() As DataTable
        Get
            Return CType(Session("pItemForSerial"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItemForSerial") = value
        End Set
    End Property

    Private Property DefaultId() As Integer
        Get
            Return CType(Session("DefaultId"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("DefaultId") = value
        End Set
    End Property
#End Region
#Region "Tables"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("pr_no", GetType(String))
        'dt.Columns.Add("ReqDept", GetType(String))
        'dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("ProjectName", GetType(String))
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("PO_Date", GetType(Date))
        dt.Columns.Add("ContractPrice", GetType(Decimal))
        dt.Columns.Add("dvno", GetType(String))
        dt.Columns.Add("checkno", GetType(String))
        dt.Columns.Add("amountpaid", GetType(String))
        dt.Columns.Add("jevno", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            'dr("pr_no") = DBNull.Value
            'dr("ReqDept") = DBNull.Value
            'dr("OBR_No") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("ProjectName") = DBNull.Value
            dr("PO_No") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("ContractPrice") = DBNull.Value
            dr("dvno") = DBNull.Value
            dr("checkno") = DBNull.Value
            dr("amountpaid") = DBNull.Value
            dr("jevno") = DBNull.Value
            dr("POHdr_ID") = 0
            dr("GA_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function CreateTable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Qty", GetType(Decimal))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("cost") = DBNull.Value
            dr("MarketValue") = DBNull.Value
            dr("Condition") = DBNull.Value
            dr("Location") = DBNull.Value
            dr("Status") = DBNull.Value
            dr("POHdr_ID") = 0
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function CreateTable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Qty_Received", GetType(Decimal))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Status1", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("Received_Date", GetType(Date))
        dt.Columns.Add("isAccepted", GetType(Boolean))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Qty_Received") = DBNull.Value
            dr("cost") = DBNull.Value
            dr("MarketValue") = DBNull.Value
            dr("Condition") = DBNull.Value
            dr("Location") = DBNull.Value
            dr("Status1") = DBNull.Value
            dr("POHdr_ID") = 0
            dr("Received_Date") = DBNull.Value
            dr("isAccepted") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function CreateTable4(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("no", GetType(Integer))
        dt.Columns.Add("barcode")
        For i As Integer = 1 To row
            dr = dt.NewRow
            dr("no") = i
            dr("barcode") = ""
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Private Sub Inventory_t_for_Acceptance_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Set AllotmentClass to 0 to load all POs by default
            AllotmentClass = 0
            LoadSearchBy()
            LoadrbALL() ' This will display all the POs without filtering when the page loads


        End If
    End Sub

    ' Updated LoadSearchBy method
    Protected Sub LoadSearchBy()
        If ddSearch.SelectedItem.Value = "1" Then
            Dim viewALL As View = TryCast(mvSearch.FindControl("vwALL"), View)
            If viewALL IsNot Nothing Then
                mvSearch.SetActiveView(viewALL)
            End If
            rbALL.Visible = True
            AllotmentClass = 0
            LoadrbALL()
            Session("Page") = "ALL"
        ElseIf ddSearch.SelectedItem.Value = "2" Then
            Dim viewAccount As View = TryCast(mvSearch.FindControl("vwAccount"), View)
            If viewAccount IsNot Nothing Then
                mvSearch.SetActiveView(viewAccount)
            End If
        ElseIf ddSearch.SelectedItem.Value = "3" Then
            Dim viewPO As View = TryCast(mvSearch.FindControl("vwPO"), View)
            If viewPO IsNot Nothing Then
                mvSearch.SetActiveView(viewPO)
            End If
        ElseIf ddSearch.SelectedItem.Value = "4" Then
            Dim viewSupp As View = TryCast(mvSearch.FindControl("vwSupp"), View)
            If viewSupp IsNot Nothing Then
                mvSearch.SetActiveView(viewSupp)
            End If
            BindSupplierData()
        End If
    End Sub

    ' Updated LoadMOOE method
    Protected Sub LoadMOOE()
        If grdAIR.SelectedDataKey("GA_ID") = 1427 Then
            Dim viewOffice As View = TryCast(mvAccounts.FindControl("vwOfficeSupplies"), View)
            If viewOffice IsNot Nothing Then
                mvAccounts.SetActiveView(viewOffice)
            End If
        Else
            Dim viewOther As View = TryCast(mvAccounts.FindControl("vwOtherSupplies"), View)
            If viewOther IsNot Nothing Then
                mvAccounts.SetActiveView(viewOther)
            End If
        End If
    End Sub

    Private Sub BindSupplierData()
        ' Example query to get supplier data
        Dim dt As DataTable = objDerived.GetDataTable("SELECT Supplier_Id, SuppName FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)

        ddSupplier.DataSource = dt
        ddSupplier.DataTextField = "SuppName"
        ddSupplier.DataValueField = "Supplier_Id"
        ddSupplier.DataBind()

        ' Insert a "Select" option at the beginning of the dropdown
        ddSupplier.Items.Insert(0, New ListItem("Select", "0"))
    End Sub


    Protected Sub LoadrbALL()
        ' Fetch data from the stored procedure
        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List_Acceptance]", CommandType.Text)

        ' Apply the filter based on AllotmentClass value
        Dim filteredTable As DataTable = pPurchase_Order.Clone() ' Clone the structure of the original DataTable

        ' Check if AllotmentClass is not 0 (i.e., MOOE or Capital Outlay was selected)
        If AllotmentClass <> 0 Then
            ' Filter based on AllotmentClass selection (MOOE or Capital Outlay)
            For Each row As DataRow In pPurchase_Order.Rows
                If (AllotmentClass = 2 And row("AllotmentClass_ID") = 2) OrElse (AllotmentClass = 3 And row("AllotmentClass_ID") = 3) Then
                    filteredTable.ImportRow(row) ' Import rows matching the filter
                End If
            Next
        Else
            ' If AllotmentClass is 0, display all POs (no filtering)
            filteredTable = pPurchase_Order.Copy() ' No filtering, just copy all rows
        End If

        ' Check if we need to add empty rows (if the row count is less than 5)
        If filteredTable.Rows.Count < 5 Then
            ' Calculate how many rows to add
            Dim emptyRowsToAdd As Integer = 5 - filteredTable.Rows.Count
            ' Create empty rows and merge them into the DataTable
            Dim emptyRows As DataTable = CreateTable1(emptyRowsToAdd)
            filteredTable.Merge(emptyRows) ' Merge empty rows into the filtered DataTable
        End If

        ' Bind the filtered (and potentially merged) DataTable to the GridView
        grdAIR.DataSource = filteredTable
        grdAIR.DataBind()

        ' Reset the selected index to avoid accidental row selection
        grdAIR.SelectedIndex = -1
    End Sub


    Protected Sub grdAIR_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdAIR, "Select$" + e.Row.RowIndex.ToString()))

        End If
    End Sub
    Protected Sub grdAIR_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdAIR.DataSource = pPurchase_Order
        grdAIR.PageIndex = e.NewPageIndex
        grdAIR.DataBind()


    End Sub
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub txtMarketValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Sub ClearTextBoxes(ParamArray textBoxes() As TextBox)
        For Each textBox As TextBox In textBoxes
            textBox.Text = String.Empty
        Next
    End Sub
    Protected Sub grdAIR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        AddTrace("POHdr_ID:" & grdAIR.SelectedDataKey("POHdr_ID"))
        If grdAIR.SelectedDataKey("POHdr_ID") = 0 Then

            grdInspection.DataSource = CreateTable3(5)
            grdInspection.DataBind()
        Else
            txtAcceptDate.Text = DateTime.Now.ToString("MM/dd/yyyy")

            txtSupplierName.Text = grdAIR.SelectedDataKey("SuppName")
            txtPoNumber.Text = grdAIR.SelectedDataKey("PO_No")
            txtPodate.Text = CType(grdAIR.SelectedDataKey("PO_Date"), Date).ToString("MM/dd/yyyy")
            txtInvoiceNumber.Text = If(grdAIR.SelectedDataKey("Invoice_No") IsNot DBNull.Value, grdAIR.SelectedDataKey("Invoice_No").ToString(), String.Empty)

            txtInvoiceDate.Text = Date.Today.ToString("MM/dd/yyyy")

            Dim rcvID As Long = grdAIR.SelectedDataKey("Received_ID")
            Session("Received_ID") = rcvID

            Dim stck1 As Long = 0
            If AllotmentClass = 2 Then
                stck1 = objDerived.GetValue("SELECT StockID FROM AMS.Stock WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            ElseIf AllotmentClass = 3 Then
                stck1 = objDerived.GetValue("SELECT Property_ID FROM AMS.Property WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            End If
            AddTrace("EXEC [AMS].[sp_ReceivedItems_Acceptance] " & grdAIR.SelectedDataKey("POHdr_ID") & ", " & stck1 & ", " & AllotmentClass & ", " & rcvID)

            pInspection_detail = objDerived.GetDataTable("EXEC [AMS].[sp_ReceivedItems_Acceptance] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & stck1 & "','" & AllotmentClass & "', '" & rcvID & "' ", CommandType.Text)

            'pInspection_detail = objDerived.GetDataTable("EXEC [AMS].[sp_ReceivedItems_Acceptance] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & stck1 & "','" & AllotmentClass & "', '" & rcvID & "' ", CommandType.Text)
            txtHiddenReceiveQty.Value = pInspection_detail.Rows.Count

            If pInspection_detail.Rows.Count < 5 Then
                pInspection_detail.Merge(CreateTable3(5 - pInspection_detail.Rows.Count))
            End If


            grdInspection.DataSource = pInspection_detail
            grdInspection.DataBind()

            Dim AllotmentClass_ID As Long
            AllotmentClass_ID = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

            If AllotmentClass_ID = 2 Then
                LoadMOOE()

            ElseIf AllotmentClass_ID = 3 Then
                LoadPPE()
            End If

            Dim accpt As New DataTable
            accpt = objDerived.GetDataTable("Select * from HRMS.view_signatory where deptid = 7 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            ddAcceptedBy.DataSource = accpt
            ddAcceptedBy.DataTextField = ("full_name")
            ddAcceptedBy.DataValueField = ("Signatory_ID")
            ddAcceptedBy.DataBind()
            ddAcceptedBy.Items.Insert(0, "Select")
            AllotmentClass = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)


        End If
        btnReturn.Enabled = True
        txtSupplierName.Enabled = False
        txtPoNumber.Enabled = False
        txtPodate.Enabled = False
        txtInvoiceNumber.Enabled = False
        txtInvoiceDate.Enabled = False
        txtRemakrs.Enabled = False

    End Sub

    Protected Sub LoadPPE()
        'If grdAIR.SelectedDataKey("GA_ID") = 1060 Or grdAIR.SelectedDataKey("GA_ID") = 1067 Then
        '    '=-= LAND
        '    '  Me.mvAccounts.SetActiveView(Me.vwLand)

        'ElseIf grdAIR.SelectedDataKey("GA_ID") = 1082 Or grdAIR.SelectedDataKey("GA_ID") = 1085 Then
        '    '=-= BUILDINGS  vwBuilding
        '    ' Me.mvAccounts.SetActiveView(Me.vwBuilding)

        'ElseIf grdAIR.SelectedDataKey("GA_ID") = 1118 Then
        '    '=-= FURNITURE AND FIXTURES
        '    ' Me.mvAccounts.SetActiveView(Me.vwEquipments)

        'ElseIf grdAIR.SelectedDataKey("GA_ID") = 1127 Then
        '    '=-= MACHINIRIES
        '    '   Me.mvAccounts.SetActiveView(Me.vwEquipments)

        'ElseIf grdAIR.SelectedDataKey("GA_ID") = 1166 Then
        '    '=-= TRANSPORTATION
        '    '  Me.mvAccounts.SetActiveView(Me.vwMotors)

        'Else '=-= ALL EQUIPMENTS
        '    'Me.mvAccounts.SetActiveView(Me.vwEquipments)

        'End If

        Select Case grdAIR.SelectedDataKey("GA_ID")
            Case 1060, 1067
                '  =-= LAND
                Me.mvAccounts.SetActiveView(Me.vwLand)

            Case 1082, 1085
                '  =-= BUILDINGS
                Me.mvAccounts.SetActiveView(Me.vwBuilding)

            Case 1118, 1127
                '  =-= FURNITURE And FIXTURES, MACHINERIES
                Me.mvAccounts.SetActiveView(Me.vwEquipments)

            Case 1166
                '  =-= TRANSPORTATION
                Me.mvAccounts.SetActiveView(Me.vwMotors)

            Case Else
                '  =-= ALL EQUIPMENTS
                Me.mvAccounts.SetActiveView(Me.vwEquipments)

        End Select
    End Sub
    Protected Sub ddSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadSearchBy()
    End Sub

    Protected Sub btnSearchPO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Assuming `pPurchase_Order` is a DataTable containing all PO data.
        Dim myview As DataView = pPurchase_Order.DefaultView
        myview.RowFilter = "PO_No LIKE '%" & replaceapostrophe(txtPO.Text) & "%'"
        grdAIR.DataSource = myview
        grdAIR.DataBind()
    End Sub

    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Check if any supplier is selected
        If ddSupplier.SelectedIndex > 0 Then
            Dim myview As DataView = pPurchase_Order.DefaultView
            myview.RowFilter = "SuppName LIKE '%" & replaceapostrophe(ddSupplier.SelectedItem.Text) & "%'"
            grdAIR.DataSource = myview
            grdAIR.DataBind()
        End If
    End Sub



    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function


    Protected Sub btnSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub rbALL_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Handle radio button selection change
        Select Case rbALL.SelectedIndex
            Case 0 ' MOOE (AllotmentClass = 2)
                AllotmentClass = 2
            Case 1 ' Capital Outlay (AllotmentClass = 3)
                AllotmentClass = 3
            Case Else
                AllotmentClass = 0 ' No filter, if needed (All)
        End Select

        ' Reload data with the selected filter
        LoadrbALL()
    End Sub


    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Button currently on fix, Please use the return item instead!.")
        Exit Sub

        Try
            ' Ensure that a row is selected in grdAIR
            If grdAIR.SelectedDataKey IsNot Nothing Then

                'for crystal report, please dont remove
                Session("IsComplete") = " "
                Session("IsPartial") = " "
                Session("AcceptedDate") = " "
                Session("AcceptingPerson") = " "
                Session("AcceptingPosition") = " "


                ' Retrieve key values from the selected row
                Dim POHdr_ID As Long = Convert.ToInt64(grdAIR.SelectedDataKey("POHdr_ID"))
                Dim PO_No As String = grdAIR.SelectedDataKey("PO_No").ToString()
                Dim GA_ID As Long = Convert.ToInt64(grdAIR.SelectedDataKey("GA_ID"))

                ' Retrieve the Received_ID for this PO (if any)
                Dim rcvID As Long = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = " & POHdr_ID, CommandType.Text)
                Session("rcvID") = rcvID

                ' --- Revert the acceptance transaction ---
                ' 1. Delete the AIR header and detail records (if they exist)
                Dim AIRHdr_ID As Long = 0
                If Not IsNothing(Session("AIRHdr_ID")) Then
                    AIRHdr_ID = Convert.ToInt64(Session("AIRHdr_ID"))
                End If
                If AIRHdr_ID <> 0 Then
                    ' Delete detail records first
                    objDerived.GetRecords("DELETE FROM AMS.AIR_Dtl WHERE AIRHdr_ID = " & AIRHdr_ID, CommandType.Text)
                    ' Then delete the header record
                    objDerived.GetRecords("DELETE FROM AMS.AIR_Hdr WHERE AIRHdr_ID = " & AIRHdr_ID, CommandType.Text)
                End If

                ' 2. Revert the main receiving record (clear inspection/acceptance data)
                ' *** Change here: set Status back to 1 (so that the record appears in t_for_Inspection) ***
                objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET Status = 1, inspection_date = NULL, InspectedBy = 0, InspectedBy2 = 0, InspectedBy3 = 0 WHERE Received_ID = " & rcvID, CommandType.Text)

                ' 3. Revert all receiving detail records by setting Qty_Received back to 0 and Status = 0
                objDerived.GetRecords("UPDATE AMS.Tb_Receiving_Dtl SET Status = 0 WHERE Received_ID = " & rcvID, CommandType.Text)

                ' 4. (Optionally) Mark the PO header as not delivered
                'objDerived.GetRecords("UPDATE AMS.PO_Hdr SET isDelivered = 0 WHERE POHdr_ID = " & POHdr_ID, CommandType.Text)

                ' Provide feedback to the user
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully returned.")

                ' Refresh the grid so that the changes are reflected
                LoadSearchBy()
                grdAIR.SelectedIndex = -1
                btnReturn.Enabled = False
            Else
                ' Optionally alert the user if no row was selected.
            End If
        Catch ex As Exception
            ' Optionally handle the exception here.
        End Try
    End Sub
    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Validate if a row is selected in grdAIR
        If grdAIR.SelectedDataKey Is Nothing Then
            AddTrace("CheckBox2_CheckedChanged: No row selected in grdAIR.")
            Exit Sub
        End If

        ' Get POHdr_ID from selected row
        Dim POHdr_ID As Long = Convert.ToInt64(grdAIR.SelectedDataKey("POHdr_ID"))
        AddTrace("CheckBox2_CheckedChanged: POHdr_ID = " & POHdr_ID)

        ' Get Received_ID from database
        Dim rcvID As Long = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = " & POHdr_ID, CommandType.Text)
        Session("rcvID") = rcvID
        AddTrace("CheckBox2_CheckedChanged: Received_ID = " & rcvID)

        ' Cast sender to CheckBox
        Dim headerCb As CheckBox = TryCast(sender, CheckBox)
        If headerCb Is Nothing Then
            AddTrace("CheckBox2_CheckedChanged: sender is not a CheckBox.")
            Exit Sub
        End If

        ' Determine if header checkbox is checked or unchecked
        Dim isSelectAll As Boolean = headerCb.Checked
        AddTrace("CheckBox2_CheckedChanged: isSelectAll = " & isSelectAll)

        ' Loop through each row in grdInspection
        For Each row As GridViewRow In grdInspection.Rows
            If row.RowType = DataControlRowType.DataRow Then
                ' Find the row-level checkbox
                Dim rowCb As CheckBox = TryCast(row.FindControl("cbInspection"), CheckBox)
                If rowCb IsNot Nothing AndAlso rowCb.Visible Then
                    ' Set its Checked property to match the header
                    rowCb.Checked = isSelectAll
                End If
            End If
        Next

        ' Update button states based on selection
        btnActSave.Enabled = isSelectAll
        returnItemBtn.Enabled = isSelectAll

        ' Handle RadioButtonList control
        If isSelectAll Then
            ' === Get all selected Item_IDs from grdInspection ===
            Dim itemIds As New List(Of String)
            For Each row As GridViewRow In grdInspection.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim cb As CheckBox = TryCast(row.FindControl("cbInspection"), CheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked AndAlso cb.Visible Then
                        Dim itemID As String = grdInspection.DataKeys(row.RowIndex).Value.ToString()
                        itemIds.Add(itemID)
                    End If
                End If
            Next

            ' Convert list to comma-separated string
            Dim idList As String = String.Join(",", itemIds)
            AddTrace("CheckBox2_CheckedChanged: Selected Item_IDs = " & idList)

            ' If nothing selected, fallback
            If itemIds.Count = 0 Then
                AddTrace("CheckBox2_CheckedChanged: No items checked.")
                rbStatus.Items(0).Enabled = True
                rbStatus.Items(1).Enabled = False
                rbStatus.SelectedValue = "1"
                Exit Sub
            End If

            ' NEW LOGIC - Aligned with cbInspection_CheckedChanged
            ' Retrieve all Received_IDs for this POHdr_ID
            Dim dtRcv As DataTable = objDerived.GetDataTable("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = " & POHdr_ID, CommandType.Text)

            Dim total_PO_Qty As Long = 0
            Dim total_Qty_Accepting As Long = 0
            Dim rcvIDs As String = ""

            If dtRcv IsNot Nothing AndAlso dtRcv.Rows.Count > 0 Then
                Dim ids As New List(Of String)
                For Each row As DataRow In dtRcv.Rows
                    ids.Add(row("Received_ID").ToString())
                Next
                rcvIDs = String.Join(",", ids)

                AddTrace("POHdr_ID: " & POHdr_ID)
                AddTrace("Received_IDs: " & rcvIDs)

                ' Sum PO_Qty for selected items only
                total_PO_Qty = objDerived.GetValue("SELECT ISNULL(SUM(PO_Qty), 0) FROM AMS.Tb_Receiving_Dtl WHERE Received_ID IN (" & rcvIDs & ") AND Item_ID IN (" & idList & ")", CommandType.Text)
                ' Sum Qty_Accepting for selected items only
                total_Qty_Accepting = objDerived.GetValue("SELECT ISNULL(SUM(Qty_Accepting), 0) FROM AMS.Tb_Receiving_Dtl WHERE Received_ID IN (" & rcvIDs & ") AND Item_ID IN (" & idList & ")", CommandType.Text)
            End If

            AddTrace("PO_Qty: " & total_PO_Qty)
            AddTrace("POQty_Accepting_Qty: " & total_Qty_Accepting)

            ' Configure radio buttons based on new logic
            rbStatus.Items(0).Enabled = (total_PO_Qty <> total_Qty_Accepting) ' Partial
            rbStatus.Items(1).Enabled = (total_PO_Qty = total_Qty_Accepting)  ' Complete

            ' Set default selection based on new logic
            If total_PO_Qty = total_Qty_Accepting Then
                rbStatus.SelectedValue = "2" ' Complete
            Else
                rbStatus.SelectedValue = "1" ' Partial
            End If

            ' Additional check for all PO items being present (kept from original logic)
            Dim poItemsQuery As String = "SELECT Item_ID FROM AMS.PO_Dtl WHERE POHdr_ID = " & POHdr_ID
            AddTrace("CheckBox2_CheckedChanged: Executing query to get PO_Dtl items: " & poItemsQuery)

            Dim dtPOItems As DataTable = objDerived.GetDataTable(poItemsQuery, CommandType.Text)
            Dim allPOItemIDs As New List(Of Long)
            For Each row As DataRow In dtPOItems.Rows
                Dim itemID As Long = Convert.ToInt64(row("Item_ID"))
                allPOItemIDs.Add(itemID)
                AddTrace("CheckBox2_CheckedChanged: Found PO_Dtl Item_ID: " & itemID)
            Next
            AddTrace("CheckBox2_CheckedChanged: Total PO_Dtl items found: " & allPOItemIDs.Count)

            ' If not all PO items are selected, force Partial status
            If allPOItemIDs.Count <> itemIds.Count Then
                rbStatus.Items(0).Enabled = True
                rbStatus.Items(1).Enabled = False
                rbStatus.SelectedValue = "1"
                AddTrace("CheckBox2_CheckedChanged: Not all PO items selected, forcing Partial status")
            End If
        Else
            ' If unselected, enable Partial and disable Complete
            rbStatus.Items(0).Enabled = True
            rbStatus.Items(1).Enabled = False
            rbStatus.SelectedValue = "1"
            AddTrace("CheckBox2_CheckedChanged: isSelectAll is False, set rbStatus.SelectedValue = 1 (Partial)")
        End If

        ' Rest of the original function (unaffected code)
        Dim AllotmentClass_ID As Long
        AllotmentClass_ID = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

        If AllotmentClass_ID = 2 Then
            Dim cb As CheckBox
            Session("cb") = 0
            For i As Integer = 0 To grdInspection.Rows.Count - 1
                cb = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                If cb.Checked = True Then
                    Session("cb") = 1
                    Exit For
                End If
            Next

            Dim dt As New DataTable
            Dim cb1a As CheckBox
            For xa As Integer = 0 To grdInspection.Rows.Count - 1
                cb1a = CType(Me.grdInspection.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)
                If cb1a.Checked = True Then
                    Dim itemID As String = pInspection_detail.Rows(xa)("Item_ID").ToString()
                    dt = objDerived.GetDataTable("EXEC [AMS].[sp_Receipt_and_Inspection_Dtl] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & itemID & "'", CommandType.Text)
                    If dt.Rows.Count > 0 Then
                        txtOSDescription.Text = dt.Rows(0).Item("Description").ToString
                        txtOSBrandName.Text = dt.Rows(0).Item("Brand").ToString
                        txtOSSize.Text = dt.Rows(0).Item("Size").ToString
                        txtOSColor.Text = dt.Rows(0).Item("Color").ToString
                        txtOSCategory.Text = dt.Rows(0).Item("Category").ToString
                    Else
                        txtOSDescription.Text = ""
                        txtOSBrandName.Text = ""
                        txtOSSize.Text = ""
                        txtOSColor.Text = ""
                        txtOSCategory.Text = ""
                    End If
                End If
            Next
        ElseIf AllotmentClass_ID = 3 Then
            Dim dt As New DataTable
            Dim cb12 As CheckBox
            For xx1 As Integer = 0 To grdInspection.Rows.Count - 1
                cb12 = CType(Me.grdInspection.Rows(xx1).Cells(0).FindControl("cbInspection"), CheckBox)
                If cb12.Checked = True Then
                    Dim a As String = pInspection_detail.Rows(xx1)("Item_ID")
                    dt = objDerived.GetDataTable("EXEC [AMS].[sp_Receipt_and_Inspection_Dtl] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & pInspection_detail.Rows(xx1)("Item_ID") & "'", CommandType.Text)

                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        txtCO_MName.Text = If(IsDBNull(dt.Rows(0).Item("Description")), "", dt.Rows(0).Item("Description").ToString())
                        txtCO_Name.Text = txtCO_MName.Text
                        txtCO_Description.Text = txtCO_MName.Text
                    Else
                        txtCO_MName.Text = ""
                        txtCO_Name.Text = ""
                        txtCO_Description.Text = ""
                    End If
                End If
            Next
        End If

        Session("AcceptedDate") = DateTime.Parse(txtAcceptDate.Text).ToString("MMMM, dd yyyy")
        System.Diagnostics.Debug.WriteLine(Session("AcceptedDate"))
    End Sub
    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox
        Dim cb2 As CheckBox
        Dim x As Integer = 0

        Dim anyChecked As Boolean = False
        Dim allChecked As Boolean = True ' Assume all are checked initially

        For i As Integer = 0 To grdInspection.Rows.Count - 1
            cb1 = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
            If cb1.Visible = True Then
                If cb1.Checked = True Then
                    x = 1
                    Dim RcvDate As Date = CType(CType(grdInspection.Rows(i).FindControl("lblRcvDate"), Label).Text, Date)

                    anyChecked = True 'flag

                    cb2 = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                    Dim txtQty As TextBox = CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox)
                    'txtQty.Enabled = True

                    If cb2.Visible = True Then
                        If CType(CType(grdInspection.Rows(i).FindControl("lblRcvDate"), Label).Text, Date) = RcvDate Then
                            cb2.Enabled = True
                        Else
                            cb2.Enabled = False
                        End If
                    End If
                Else
                    ' If any checkbox is unchecked, set allChecked to False
                    allChecked = False
                    Dim txtQty As TextBox = CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox)
                    txtQty.Enabled = False
                End If
            End If
        Next
        returnItemBtn.Enabled = anyChecked

        ' New code for RadioButtonList control based on cbInspection checkboxes
        If allChecked Then
            ' Get POHdr_ID from selected row
            Dim POHdr_ID As Long = Convert.ToInt64(grdAIR.SelectedDataKey("POHdr_ID"))

            ' Retrieve all Received_IDs for this POHdr_ID
            Dim dtRcv As DataTable = objDerived.GetDataTable("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = " & POHdr_ID, CommandType.Text)

            Dim total_PO_Qty As Long = 0
            Dim total_Qty_Accepting As Long = 0
            Dim rcvIDs As String = ""

            If dtRcv IsNot Nothing AndAlso dtRcv.Rows.Count > 0 Then
                Dim ids As New List(Of String)
                For Each row As DataRow In dtRcv.Rows
                    ids.Add(row("Received_ID").ToString())
                Next
                rcvIDs = String.Join(",", ids)

                AddTrace("POHdr_ID: " & POHdr_ID)
                AddTrace("Received_IDs: " & rcvIDs)

                ' Sum PO_Qty
                total_PO_Qty = objDerived.GetValue("SELECT ISNULL(SUM(PO_Qty), 0) FROM AMS.Tb_Receiving_Dtl WHERE Received_ID IN (" & rcvIDs & ")", CommandType.Text)
                ' Sum Qty_Accepting
                total_Qty_Accepting = objDerived.GetValue("SELECT ISNULL(SUM(Qty_Accepting), 0) FROM AMS.Tb_Receiving_Dtl WHERE Received_ID IN (" & rcvIDs & ")", CommandType.Text)
            End If

            AddTrace("PO_Qty: " & total_PO_Qty)
            AddTrace("POQty_Accepting_Qty: " & total_Qty_Accepting)

            ' Configure radio buttons
            rbStatus.Items(0).Enabled = (total_PO_Qty <> total_Qty_Accepting) ' Partial
            rbStatus.Items(1).Enabled = (total_PO_Qty = total_Qty_Accepting)  ' Complete

            ' Set default selection
            If total_PO_Qty = total_Qty_Accepting Then
                rbStatus.SelectedValue = "2" ' Complete
            Else
                rbStatus.SelectedValue = "1" ' Partial
            End If

        Else
            ' If not all cbInspection are checked, enable Partial and disable Complete
            rbStatus.Items(0).Enabled = True  ' Partial
            rbStatus.Items(1).Enabled = False ' Complete
            rbStatus.SelectedValue = "1"      ' Select Partial
        End If

        If x = 0 Then
            For i As Integer = 0 To grdInspection.Rows.Count - 1
                cb2 = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                cb2.Enabled = True
            Next
            btnActSave.Enabled = False
        Else
            If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                ddDepartment.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_AIR_ConsolidatedPR] '" & grdAIR.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
                ddDepartment.DataTextField = ("RC_Name")
                ddDepartment.DataValueField = ("RC_ID")
                ddDepartment.DataBind()
                ddDepartment.Items.Insert(0, "Select")

                ddFunction.Items.Clear()
                ddFunction.DataSource = Nothing
                ddFunction.DataBind()
                ddFunction.Items.Insert(0, "Select")
            Else
                txtDepartment.Text = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                txtFunction.Text = objDerived.GetValue("SELECT Function_Desc FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "' AND Function_ID = '" & grdAIR.SelectedDataKey("Function_ID") & "'", CommandType.Text)
            End If

            btnActSave.Enabled = True
        End If

        Dim AllotmentClass_ID As Long
        AllotmentClass_ID = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

        If AllotmentClass_ID = 2 Then
            Dim cb As CheckBox
            Session("cb") = 0
            For i As Integer = 0 To grdInspection.Rows.Count - 1
                cb = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                If cb.Checked = True Then
                    Session("cb") = 1
                    Exit For
                End If
            Next

            Dim dt As New DataTable
            Dim cb1a As CheckBox
            For xa As Integer = 0 To grdInspection.Rows.Count - 1
                cb1a = CType(Me.grdInspection.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)
                If cb1a.Checked = True Then
                    Dim itemID As String = pInspection_detail.Rows(xa)("Item_ID").ToString()
                    dt = objDerived.GetDataTable("EXEC [AMS].[sp_Receipt_and_Inspection_Dtl] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & itemID & "'", CommandType.Text)
                    If dt.Rows.Count > 0 Then
                        txtOSDescription.Text = dt.Rows(0).Item("Description").ToString
                        txtOSBrandName.Text = dt.Rows(0).Item("Brand").ToString
                        txtOSSize.Text = dt.Rows(0).Item("Size").ToString
                        txtOSColor.Text = dt.Rows(0).Item("Color").ToString
                        txtOSCategory.Text = dt.Rows(0).Item("Category").ToString
                    Else
                        txtOSDescription.Text = ""
                        txtOSBrandName.Text = ""
                        txtOSSize.Text = ""
                        txtOSColor.Text = ""
                        txtOSCategory.Text = ""
                    End If
                End If
            Next
        ElseIf AllotmentClass_ID = 3 Then
            Dim dt As New DataTable
            Dim cb12 As CheckBox
            For xx1 As Integer = 0 To grdInspection.Rows.Count - 1
                cb12 = CType(Me.grdInspection.Rows(xx1).Cells(0).FindControl("cbInspection"), CheckBox)
                If cb12.Checked = True Then
                    Dim a As String = pInspection_detail.Rows(xx1)("Item_ID")
                    dt = objDerived.GetDataTable("EXEC [AMS].[sp_Receipt_and_Inspection_Dtl] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & pInspection_detail.Rows(xx1)("Item_ID") & "'", CommandType.Text)

                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        txtCO_MName.Text = If(IsDBNull(dt.Rows(0).Item("Description")), "", dt.Rows(0).Item("Description").ToString())
                        txtCO_Name.Text = txtCO_MName.Text
                        txtCO_Description.Text = txtCO_MName.Text
                    Else
                        txtCO_MName.Text = ""
                        txtCO_Name.Text = ""
                        txtCO_Description.Text = ""
                    End If


                End If
            Next
        End If

        Session("AcceptedDate") = DateTime.Parse(txtAcceptDate.Text).ToString("MMMM, dd yyyy")
        System.Diagnostics.Debug.WriteLine(Session("AcceptedDate"))
    End Sub

    Protected Sub txtActQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtActQty As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtActQty.NamingContainer, GridViewRow)
        If txtActQty.Text = "" Then
            txtActQty.Text = "0"
        End If
        txtActQty.Text = FormatNumber(txtActQty.Text, 2)

        ''here 2
        'Dim cb5 As CheckBox
        'Dim x1 As Integer = 0
        'Dim x2 As Integer = 0
        'For xxx As Integer = 0 To grdInspection.Rows.Count - 1
        '    cb5 = CType(Me.grdInspection.Rows(xxx).Cells(0).FindControl("cbInspection"), CheckBox)

        '    If cb5.Checked = True Then
        '        x1 = x1 + 1
        '    Else

        '    End If

        'Next


        'Dim a1 As Integer = 0
        'Try
        '    If pInspection_detail.Rows.Count > 0 Then
        '        Dim a As Double = 0
        '        For i As Integer = 0 To pInspection_detail.Rows.Count - 1
        '            Dim b As String = CType(CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox).Text, String)
        '            a = a + Val(b)
        '        Next
        '        a1 = a
        '    Else

        '        a1 = 0
        '    End If

        'Catch ex As Exception

        'End Try

        'If (x1) = (txtHiddenReceiveQty.Value) And a1 = Val(txtHidenQTY.Value) Then
        '    rbStatus.Items.Item(1).Enabled = True
        'Else
        '    rbStatus.Items.Item(1).Selected = False
        '    rbStatus.Items.Item(0).Selected = True
        '    rbStatus.Items.Item(1).Enabled = False

        'End If
        'x1 = 0
        ''End here 2
    End Sub
    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Save1()
    End Sub

    Protected Sub btnSaveOS_Click(sender As Object, e As EventArgs)
        Save1()
    End Sub
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        For i As Integer = 0 To grdSerialVehicles.Rows.Count - 1
            CType(grdSerialVehicles.Rows(i).FindControl("txtSerialNo"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtChasisNo"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtLicensePlateNo"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtMvfileno"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtConsticker"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtChasis_No"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtVehicle_color"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtCS_no"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtEngine_No"), TextBox).Text = "N/A"

        Next

        ModalPopupExtender2.Show()
    End Sub

    'Public Sub Save1()
    '    Try
    '        btnSaveOS.Enabled = False
    '        '========================== ACCEPTANCE ==========================
    '        Dim Quanityx As Integer = 0
    '        Dim ReceivedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("ReceivedBY") & "'", CommandType.Text)
    '        Dim InspectedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("InspectedBy") & "'", CommandType.Text)
    '        Dim rcvID As Long = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

    '        ''=-= SAVE AMS.AIR_Hdr
    '        'Dim AIR_No As String = supplies.GetValue("select [AMS].[func_GenerateAIR]( '" & txtAcceptDate.Text & "')", CommandType.Text)

    '        'With AIR_Hdr
    '        '    .AIR_No = AIR_No
    '        '    .AIR_Date = txtAcceptDate.Text
    '        '    .Invoice_No = txtInvoiceNumber.Text
    '        '    .Invoice_date = Date.Parse(txtInvoiceDate.Text)
    '        '    .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
    '        '    .PO_No = grdAIR.SelectedDataKey("PO_No")
    '        '    .Supplier_ID = grdAIR.SelectedDataKey("Supplier_Id")
    '        '    .Date_Received = pInspection_detail.Rows(0)("Received_Date")
    '        '    .Date_Inspect = pInspection_detail.Rows(0)("Received_Date")
    '        '    .Date_Accepted = txtAcceptDate.Text
    '        '    .Trans_ID = 1
    '        '    .remarks = txtRemakrs.Text
    '        '    If rbStatus.SelectedIndex = 0 Then
    '        '        .IsPartial = True
    '        '    End If

    '        '    If rbStatus.SelectedItem.Value = 2 Then
    '        '        .isComplete = True
    '        '    Else
    '        '        .isComplete = False
    '        '    End If
    '        '    AddTrace("AIR_Hdr isComplete: " & .isComplete.ToString())

    '        '    If grdAIR.SelectedDataKey("RC_ID") = 0 Then
    '        '        AddTrace("RC_ID=0 => Using ddDepartment/ddFunction.")
    '        '        .RC_ID = ddDepartment.SelectedItem.Value
    '        '        .Function_ID = ddFunction.SelectedItem.Value
    '        '    Else
    '        '        .RC_ID = grdAIR.SelectedDataKey("RC_ID")
    '        '        .Function_ID = grdAIR.SelectedDataKey("Function_ID")
    '        '        AddTrace("RC_ID and Function_ID read from SelectedDataKey: RC_ID=" & .RC_ID & ", Function_ID=" & .Function_ID)
    '        '    End If

    '        '    AddTrace("Looping through grdInspection checkboxes to find first checked item.")
    '        '    Dim Box As CheckBox
    '        '    For a As Integer = 0 To grdInspection.Rows.Count - 1
    '        '        Box = CType(Me.grdInspection.Rows(a).Cells(0).FindControl("cbInspection"), CheckBox)
    '        '        If Box IsNot Nothing AndAlso Box.Checked Then
    '        '            Dim zx As Long = pInspection_detail.Rows(a)("Received_ID")
    '        '            Session("xReceived_ID") = zx
    '        '            AddTrace("Found a checked item. xReceived_ID set to: " & zx)
    '        '            Exit For
    '        '        End If
    '        '    Next

    '        '    .Received_ID = Session("xReceived_ID")
    '        '    .UserID = Session("@UserName")
    '        'End With

    '        'Dim xAIRHdr_ID As Long = AIR_Hdr.save
    '        'Session("AIRHdr_ID") = xAIRHdr_ID

    '        Dim cb As CheckBox
    '        For x As Integer = 0 To grdInspection.Rows.Count - 1
    '            cb = CType(Me.grdInspection.Rows(x).Cells(0).FindControl("cbInspection"), CheckBox)
    '            If cb.Checked = True Then
    '                Dim AcptQty As Decimal = CType(CType(grdInspection.Rows(x).FindControl("txtActQty"), TextBox).Text, Decimal)

    '                ''=-= SAVE AMS.AIR_Dtl
    '                'AddTrace("Now saving AIR_Dtl for item_id=" & pInspection_detail.Rows(x)("Item_ID").ToString())
    '                'With AIR_Dtl
    '                '    .AIRHdr_ID = xAIRHdr_ID
    '                '    .Item_ID = pInspection_detail.Rows(x)("Item_ID")
    '                '    .Qty = AcptQty
    '                '    .Cost = pInspection_detail.Rows(x)("Cost")
    '                '    .GA_ID = grdAIR.SelectedDataKey("GA_ID")
    '                '    .Warranty = 0
    '                'End With


    '                'Dim AIRDtl_ID As Long = AIR_Dtl.save
    '                'objDerived.GetRecords("UPDATE AMS.AIR_Dtl SET OtherSpecs = '" & pInspection_detail.Rows(x)("OtherSpecs") & "', isAccepted = 1 WHERE AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)

    '                '============== CAPITAL OUTLAY ==============
    '                '=-= SAVE AMS.PROPERTY
    '                Dim Particular_Desc As String = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item " &
    '                "INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id " &
    '                "WHERE dbo.m_item.Item_ID = '" & pInspection_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
    '                Dim PropCode As String = objDerived.GetValue("SELECT GA_Code FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

    '                With Prop_Hdr
    '                    .Property_Date = txtAcceptDate.Text
    '                    .Property_code = PropCode
    '                    '.AIRDtl_ID = AIRDtl_ID
    '                    .GA_ID = grdAIR.SelectedDataKey("GA_ID")
    '                    .Particular = Particular_Desc
    '                    .Item_ID = pInspection_detail.Rows(x)("Item_ID")
    '                    .Qty = AcptQty
    '                    .Balance = AcptQty
    '                    .Issuance = 0
    '                    .Cost = pInspection_detail.Rows(x)("Cost")
    '                    .Project_ID = 0
    '                    .Program_id = 0
    '                    .Emp_ID = 0
    '                    .TD_ID = 1
    '                    .F_ID = 1
    '                    .Remarks = ""
    '                    .isDonated = False
    '                    .DonationRemarks = ""

    '                    If grdAIR.SelectedDataKey("RC_ID") = 0 Then
    '                        .RC_ID = ddDepartment.SelectedItem.Value
    '                        .Function_ID = ddFunction.SelectedItem.Value
    '                        Session("RC_ID") = ddDepartment.SelectedItem.Value
    '                        Session("Function_ID") = ddFunction.SelectedItem.Value
    '                    Else
    '                        .RC_ID = grdAIR.SelectedDataKey("RC_ID")
    '                        .Function_ID = grdAIR.SelectedDataKey("Function_ID")
    '                        Session("RC_ID") = grdAIR.SelectedDataKey("RC_ID")
    '                        Session("Function_ID") = grdAIR.SelectedDataKey("Function_ID")
    '                    End If

    '                    .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
    '                    .Received_ID = Session("xReceived_ID")
    '                    .UserID = Session("@UserName")
    '                End With

    '                Dim Item_ID As Integer = pInspection_detail.Rows(x)("Item_ID")
    '                Dim PropHdr_ID As Long = Prop_Hdr.save
    '                objDerived.Execute("UPDATE [AMS].[Property] SET [OtherSpecs] = '" & pInspection_detail.Rows(x)("OtherSpecs") & "' WHERE [Property_ID] = " & PropHdr_ID & "", CommandType.Text)

    '                Dim dt1 As New DataTable
    '                dt1 = objDerived.GetDataTable("EXEC [AMS].[sp_Acceptance_SerialNo_List] '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

    '                grdSerial.Columns(3).Visible = True
    '                '=-= SAVE AMS.PROPERTY_DTL
    '                ' === If no serial entry matched, still insert minimal Property_Dtl ===
    '                Dim PropDtl_ID As Integer

    '                If PropDtl_ID = 0 Then

    '                    Dim PropertyNumber As String = supplies.GetValue("SELECT [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtAcceptDate.Text & "', '" & PropCode & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "')", CommandType.Text)
    '                    Dim Prop_Dtl As New t_property_dtl
    '                    With Prop_Dtl
    '                        .PropertyNo = PropertyNumber
    '                        .Property_ID = PropHdr_ID
    '                        .Barcode = ""
    '                        .SerialNo = "" ' No serial, can leave empty
    '                        .Amount = pInspection_detail.Rows(x)("Cost")
    '                        .type = Particular_Desc
    '                        .Issued = False
    '                        .Repair = False
    '                        .Details = ""
    '                        .F_ID = 1
    '                        .Status = "Accepted"
    '                        .IsInspectionForDisposal = False
    '                        .InspectionDate = "1/1/1900"
    '                        .Dispose = False
    '                        .DisposeDate = "1/1/1900"
    '                        .UserID = Session("@UserName")
    '                        .RC_ID = Session("RC_ID")
    '                        .Function_ID = Session("Function_ID")
    '                        .AccountablePerson = "" ' Optional, can be added if needed
    '                    End With
    '                    PropDtl_ID = Prop_Dtl.save()

    '                    AddTrace("Saved1 : PropDtl_ID = Prop_Dtl.save()")
    '                    grdInspection.DataSource = Nothing
    '                    grdInspection.DataBind()

    '                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
    '                    btnActSave.Enabled = False
    '                    btnActPreview.Enabled = True
    '                End If


    '                Dim a As String = objDerived.GetValue("SELECT DISTINCT dbo.tbl_Classification.ClassificationName " &
    '                "FROM dbo.tbl_SubClassification INNER JOIN dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId " &
    '                "INNER JOIN dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID " &
    '                "WHERE dbo.m_item.Item_ID = '" & pInspection_detail.Rows(x)("Item_ID") & "'", CommandType.Text)

    '                If a = "Vehicle" Then
    '                    ' Dim PropDtl_ID As Integer

    '                    For Quanity As Integer = 1 To 1
    '                        If CType(grdSerialVehicles.Rows(Quanityx).FindControl("lblItem_ID1"), Label).Text = pInspection_detail.Rows(x)("Item_ID") Then
    '                            Dim PropertyNumber As String = supplies.GetValue("SELECT [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtAcceptDate.Text & "', '" & PropCode & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "')", CommandType.Text)
    '                            Dim Prop_Dtl As New t_property_dtl
    '                            With Prop_Dtl
    '                                .PropertyNo = PropertyNumber
    '                                .Property_ID = PropHdr_ID
    '                                .Barcode = ""
    '                                .SerialNo = CType(grdSerialVehicles.Rows(Quanityx).FindControl("txtSerialNo"), TextBox).Text
    '                                .Amount = pInspection_detail.Rows(x)("Cost")
    '                                .type = Particular_Desc
    '                                .Issued = False
    '                                .Repair = False
    '                                .Details = ""
    '                                .F_ID = 1
    '                                .Status = "Accepted"
    '                                .IsInspectionForDisposal = False
    '                                ' Validate all date fields
    '                                If String.IsNullOrEmpty(.InspectionDate) Then
    '                                    .InspectionDate = "1/1/1900"
    '                                End If


    '                                .Dispose = False

    '                                If String.IsNullOrEmpty(.DisposeDate) Then
    '                                    .DisposeDate = "1/1/1900"
    '                                End If
    '                                .UserID = Session("@UserName")
    '                            End With
    '                            PropDtl_ID = Prop_Dtl.save()

    '                            AddTrace("Saved2 : PropDtl_ID = Prop_Dtl.save()")
    '                            grdInspection.DataSource = Nothing
    '                            grdInspection.DataBind()

    '                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
    '                            btnActSave.Enabled = False
    '                            btnActPreview.Enabled = True
    '                        End If

    '                        If a = "Vehicle" Then
    '                            With objMotorInfo
    '                                .Motor_InfoId = pItemForSerial.Rows(x)("motor_id").ToString
    '                                .AIRDtl_ID = 0
    '                                .IsAccepted = True
    '                                .Property_Dtl_ID = PropDtl_ID
    '                                .Name = grdSerialVehicles.Rows(Quanityx).Cells(1).Text
    '                                .PlateNo = CType(grdSerialVehicles.Rows(Quanityx).FindControl("txtLicensePlateNo"), TextBox).Text
    '                                .MotorNo = ""
    '                                .Model = ""
    '                                .ChasisNo = CType(grdSerialVehicles.Rows(Quanityx).FindControl("txtChasisNo"), TextBox).Text
    '                                .VehicleColor = ""
    '                                .WheelsCapacity = ""
    '                                .GrossWeight = ""
    '                                .Seats = ""
    '                                .Warranty = ""
    '                                .VehicleOwner = ""
    '                                .DeclaredName = ""
    '                                .BeneficialUser = ""
    '                                .VehicleSpecification = ""
    '                                .VehicleDesc = grdSerialVehicles.Rows(Quanityx).Cells(1).Text
    '                                .VehicleMake = ""
    '                                .VehicleType = ""
    '                                .PowerInput = ""
    '                                .MVfileNo = CType(grdSerialVehicles.Rows(Quanityx).FindControl("txtMvfileno"), TextBox).Text
    '                                .ConSticker = CType(grdSerialVehicles.Rows(Quanityx).FindControl("txtConsticker"), TextBox).Text
    '                                .DepRate = 0
    '                                .DepValue = 0
    '                                .NoofYears = 0
    '                                .UsefulLife = 0
    '                                .SalvageValue = 0
    '                                .Received_ID = rcvID
    '                            End With
    '                            Dim motor_info_id As Integer
    '                            motor_info_id = objMotorInfo.update()

    '                            Dim MotorID As Integer = objDerived.GetValue("select MotorID from AMS.TbMotor_Dtl where Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)
    '                            With objMotorDtl
    '                                .MotorID = MotorID
    '                                .Motor_InfoId = motor_info_id
    '                                .Property_Dtl_ID = PropDtl_ID
    '                                .MarketValue = 0
    '                                .Condition = ""
    '                                .Location = ""
    '                                .Status = "Accepted"
    '                            End With
    '                            objMotorDtl.update()

    '                            AddTrace("Saved3 :  objMotorDtl.update()")
    '                            grdInspection.DataSource = Nothing
    '                            grdInspection.DataBind()

    '                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
    '                            btnActSave.Enabled = False
    '                            btnActPreview.Enabled = True


    '                        End If
    '                        Quanityx = Quanityx + 1
    '                    Next
    '                Else
    '                    ' Dim PropDtl_ID As Integer
    '                    For Quanity As Integer = 0 To grdSerial.Rows.Count - 1
    '                        If CType(grdSerial.Rows(Quanity).FindControl("lblItem_ID"), Label).Text = pInspection_detail.Rows(x)("Item_ID") Then
    '                            Dim PropertyNumber As String = supplies.GetValue("SELECT [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtAcceptDate.Text & "', '" & PropCode & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "')", CommandType.Text)
    '                            Dim Prop_Dtl As New t_property_dtl
    '                            With Prop_Dtl
    '                                .PropertyNo = PropertyNumber
    '                                .Property_ID = PropHdr_ID
    '                                .Barcode = ""
    '                                .SerialNo = CType(grdSerial.Rows(Quanity).FindControl("txtSerialNo"), TextBox).Text
    '                                .Amount = pInspection_detail.Rows(x)("Cost")
    '                                .type = Particular_Desc
    '                                .Issued = False
    '                                .Repair = False
    '                                .Details = ""
    '                                .F_ID = 1
    '                                .Status = "Accepted"
    '                                .IsInspectionForDisposal = False
    '                                If String.IsNullOrEmpty(.InspectionDate) Then
    '                                    .InspectionDate = "1/1/1900"
    '                                End If


    '                                .Dispose = False

    '                                If String.IsNullOrEmpty(.DisposeDate) Then
    '                                    .DisposeDate = "1/1/1900"
    '                                End If
    '                                .UserID = Session("@UserName")
    '                            End With
    '                            PropDtl_ID = Prop_Dtl.save()

    '                            AddTrace("Saved4 :  Prop_Dtl.save()")
    '                            grdInspection.DataSource = Nothing
    '                            grdInspection.DataBind()

    '                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
    '                            btnActSave.Enabled = False
    '                            btnActPreview.Enabled = True
    '                        End If
    '                    Next
    '                End If

    '                grdSerial.Columns(3).Visible = False

    '                Dim asv As String = pInspection_detail.Rows(x)("Item_ID")
    '                Dim Remarks = objDerived.GetValue("select count(*) from [AMS].[TbProperty_Ledger] WHERE Item_ID = " & pInspection_detail.Rows(x)("Item_ID") & "", CommandType.Text)

    '                If Remarks <> 0 Then
    '                    With Prop_Ledger
    '                        .PropertyNo = ""
    '                        .SerialNo = ""
    '                        .Item_ID = pInspection_detail.Rows(x)("Item_ID")
    '                        .dDate = txtAcceptDate.Text
    '                        .Trans_Type = "Purchase Order Delivered"
    '                        '.Ref = AIR_No
    '                        .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
    '                        .AcceptedBy = ddAcceptedBy.SelectedItem.Text
    '                        .InspectedBy = InspectedBy
    '                        .DebitQty = AcptQty
    '                        .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
    '                        .DebitUnit = pInspection_detail.Rows(x)("Unit")
    '                        .CreditQty = 0
    '                        .CreditCost = "0.00"
    '                        .CreditUnit = " - "
    '                        .BalanceUnit = pInspection_detail.Rows(x)("Unit")

    '                        If grdAIR.SelectedDataKey("RC_ID") = 0 Then
    '                            .Department = ddDepartment.SelectedItem.Text
    '                        Else
    '                            .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
    '                        End If
    '                        .save()
    '                        AddTrace("Saved6 : With Prop_Ledger update")
    '                        grdInspection.DataSource = Nothing
    '                        grdInspection.DataBind()

    '                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
    '                        btnActSave.Enabled = False
    '                        btnActPreview.Enabled = True
    '                    End With
    '                Else
    '                    With Prop_Ledger
    '                        .PropertyNo = ""
    '                        .SerialNo = ""
    '                        .Item_ID = pInspection_detail.Rows(x)("Item_ID")
    '                        .dDate = txtAcceptDate.Text
    '                        .Trans_Type = "Starting Inventory"
    '                        '.Ref = AIR_No
    '                        .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
    '                        .AcceptedBy = ddAcceptedBy.SelectedItem.Text
    '                        .InspectedBy = InspectedBy
    '                        .DebitQty = AcptQty
    '                        .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
    '                        .DebitUnit = pInspection_detail.Rows(x)("Unit")
    '                        .CreditQty = 0
    '                        .CreditCost = "0.00"
    '                        .CreditUnit = " - "
    '                        .BalanceUnit = pInspection_detail.Rows(x)("Unit")

    '                        If grdAIR.SelectedDataKey("RC_ID") = 0 Then
    '                            .Department = ddDepartment.SelectedItem.Text
    '                        Else
    '                            .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
    '                        End If
    '                        .save()

    '                        AddTrace("Saved7 : With Prop_Ledger update")
    '                        grdInspection.DataSource = Nothing
    '                        grdInspection.DataBind()

    '                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
    '                        btnActSave.Enabled = False
    '                        btnActPreview.Enabled = True
    '                    End With
    '                End If
    '            End If
    '        Next

    '        Dim newPOHdrID As Long = CLng(grdAIR.SelectedDataKey("POHdr_ID"))
    '        Session("POHdr_ID") = newPOHdrID


    '        Session("CapitalOutlay") = True
    '        ' -- Clear Inspection Grid
    '        LoadrbALL()
    '        'LoadSearchBy() ' Rebind grdAIR

    '        ' -- Clear dropdowns
    '        ddSearch.SelectedIndex = 0
    '        ddSupplier.Items.Clear()
    '        ddSupplier.Items.Insert(0, New ListItem("Select", "0"))
    '        ddDepartment.Items.Clear()
    '        ddDepartment.Items.Insert(0, New ListItem("Select", "0"))
    '        ddFunction.Items.Clear()
    '        ddFunction.Items.Insert(0, New ListItem("Select", "0"))
    '        ddAcceptedBy.Items.Clear()
    '        ddAcceptedBy.Items.Insert(0, New ListItem("Select", "0"))

    '        ' -- Clear textboxes
    '        txtSupplierName.Text = ""
    '        txtPoNumber.Text = ""
    '        txtPodate.Text = ""
    '        txtInvoiceNumber.Text = ""
    '        txtInvoiceDate.Text = ""
    '        txtAcceptDate.Text = ""
    '        txtRemakrs.Text = ""



    '    Catch ex As Exception
    '        Dim errMsg As String = ex.Message
    '        errMsg = errMsg.Replace("\", "\\")
    '        errMsg = errMsg.Replace("'", "\'")
    '        errMsg = errMsg.Replace("""", "\""")
    '        errMsg = errMsg.Replace(vbCr, " ")
    '        errMsg = errMsg.Replace(vbLf, " ")
    '        'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, errMsg)
    '    End Try
    'End Sub


    'Public Sub Save1()
    '    Try
    '        btnSaveOS.Enabled = True
    '        '========================== ACCEPTANCE ==========================
    '        Dim Quanityx As Integer = 0
    '        Dim ReceivedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("ReceivedBY") & "'", CommandType.Text)
    '        Dim InspectedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("InspectedBy") & "'", CommandType.Text)
    '        Dim rcvID As Long = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
    '        Dim allSavedProps As New List(Of Long) ' Track all saved Property IDs

    '        ' Find first checked item for Received_ID
    '        Dim Box As CheckBox
    '        For a As Integer = 0 To grdInspection.Rows.Count - 1
    '            Box = CType(Me.grdInspection.Rows(a).Cells(0).FindControl("cbInspection"), CheckBox)
    '            If Box IsNot Nothing AndAlso Box.Checked Then
    '                Dim zx As Long = pInspection_detail.Rows(a)("Received_ID")
    '                Session("xReceived_ID") = zx
    '                AddTrace("Found a checked item. xReceived_ID set to: " & zx)
    '                Exit For
    '            End If
    '        Next

    '        ' Save AIR_Hdr
    '        Dim AIR_No As String = supplies.GetValue("select [AMS].[func_GenerateAIR]( '" & txtAcceptDate.Text & "')", CommandType.Text)
    '        Dim xAIRHdr_ID As Long = 0

    '        With AIR_Hdr
    '            .AIR_No = AIR_No
    '            .AIR_Date = txtAcceptDate.Text
    '            .Invoice_No = txtInvoiceNumber.Text
    '            .Invoice_date = Date.Parse(txtInvoiceDate.Text)
    '            .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
    '            .PO_No = grdAIR.SelectedDataKey("PO_No")
    '            .Supplier_ID = grdAIR.SelectedDataKey("Supplier_Id")
    '            .Date_Received = pInspection_detail.Rows(0)("Received_Date")
    '            .Date_Inspect = pInspection_detail.Rows(0)("Received_Date")
    '            .Date_Accepted = txtAcceptDate.Text
    '            .Trans_ID = 1
    '            .remarks = txtRemakrs.Text
    '            .IsPartial = (rbStatus.SelectedIndex = 0)
    '            .isComplete = (rbStatus.SelectedItem.Value = 2)

    '            If grdAIR.SelectedDataKey("RC_ID") = 0 Then
    '                .RC_ID = ddDepartment.SelectedItem.Value
    '                .Function_ID = ddFunction.SelectedItem.Value
    '            Else
    '                .RC_ID = grdAIR.SelectedDataKey("RC_ID")
    '                .Function_ID = grdAIR.SelectedDataKey("Function_ID")
    '            End If

    '            .Received_ID = Session("xReceived_ID")
    '            .UserID = Session("@UserName")
    '        End With

    '        xAIRHdr_ID = AIR_Hdr.save()
    '        Session("AIRHdr_ID") = xAIRHdr_ID
    '        AddTrace("Saved AIR_Hdr: ID=" & xAIRHdr_ID)


    '        ' Loop through each row in grdInspection
    '        For x As Integer = 0 To grdInspection.Rows.Count - 1
    '            Dim cb As CheckBox = CType(grdInspection.Rows(x).Cells(0).FindControl("cbInspection"), CheckBox)

    '            If cb IsNot Nothing AndAlso cb.Checked Then
    '                Dim AcptQty As Decimal = CDec(CType(grdInspection.Rows(x).FindControl("txtActQty"), TextBox).Text)
    '                Dim currentItemID As Integer = pInspection_detail.Rows(x)("Item_ID")
    '                Dim currentCost As Decimal = pInspection_detail.Rows(x)("Cost")
    '                Dim currentUnit As String = pInspection_detail.Rows(x)("Unit")
    '                Dim currentReceivedID As Long = pInspection_detail.Rows(x)("Received_ID")
    '                Dim OtherSpecs As String = pInspection_detail.Rows(x)("OtherSpecs")

    '                Session("xReceived_ID") = currentReceivedID
    '                AddTrace("Processing checked row: ItemID=" & currentItemID & ", Qty=" & AcptQty)


    '                ' Save AIR_Dtl
    '                With AIR_Dtl
    '                    .AIRHdr_ID = xAIRHdr_ID
    '                    .Item_ID = currentItemID
    '                    .Qty = AcptQty
    '                    .Cost = currentCost
    '                    .GA_ID = grdAIR.SelectedDataKey("GA_ID")
    '                    .Warranty = 0
    '                End With

    '                Dim AIRDtl_ID As Long = AIR_Dtl.save()
    '                objDerived.Execute("UPDATE AMS.AIR_Dtl SET OtherSpecs = '" & OtherSpecs & "', isAccepted = 1 WHERE AIRDtl_ID = " & AIRDtl_ID, CommandType.Text)
    '                AddTrace("Saved AIR_Dtl: ID=" & AIRDtl_ID & ", ItemID=" & currentItemID)


    '                ' Get item details
    '                Dim Particular_Desc As String = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item " &
    '            "INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id " &
    '            "WHERE dbo.m_item.Item_ID = '" & currentItemID & "'", CommandType.Text)
    '                Dim PropCode As String = objDerived.GetValue("SELECT GA_Code FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

    '                ' Determine department and function
    '                Dim rcID As Integer, funcID As Integer
    '                If grdAIR.SelectedDataKey("RC_ID") = 0 Then
    '                    rcID = ddDepartment.SelectedItem.Value
    '                    funcID = ddFunction.SelectedItem.Value
    '                Else
    '                    rcID = grdAIR.SelectedDataKey("RC_ID")
    '                    funcID = grdAIR.SelectedDataKey("Function_ID")
    '                End If
    '                Session("RC_ID") = rcID
    '                Session("Function_ID") = funcID

    '                ' Create PROPERTY HEADER
    '                With Prop_Hdr
    '                    .Property_Date = txtAcceptDate.Text
    '                    .Property_code = PropCode
    '                    .AIRDtl_ID = AIRDtl_ID
    '                    .GA_ID = grdAIR.SelectedDataKey("GA_ID")
    '                    .Particular = Particular_Desc
    '                    .Item_ID = currentItemID
    '                    .Qty = AcptQty
    '                    .Balance = AcptQty
    '                    .Issuance = 0
    '                    .Cost = currentCost
    '                    .RC_ID = rcID
    '                    .Function_ID = funcID
    '                    .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
    '                    .Received_ID = currentReceivedID
    '                    .UserID = Session("@UserName")
    '                End With

    '                Dim PropHdr_ID As Long = Prop_Hdr.save()
    '                allSavedProps.Add(PropHdr_ID)
    '                objDerived.Execute("UPDATE [AMS].[Property] SET [OtherSpecs] = '" & OtherSpecs & "' WHERE [Property_ID] = " & PropHdr_ID, CommandType.Text)
    '                AddTrace("Saved Prop_Hdr: ID=" & PropHdr_ID & ", ItemID=" & currentItemID)


    '                ' Get classification
    '                Dim classification As String = objDerived.GetValue("SELECT DISTINCT dbo.tbl_Classification.ClassificationName " &
    '            "FROM dbo.tbl_SubClassification INNER JOIN dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId " &
    '            "INNER JOIN dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID " &
    '            "WHERE dbo.m_item.Item_ID = '" & currentItemID & "'", CommandType.Text)

    '                ' ====== VEHICLE ITEMS ======
    '                If classification = "Vehicle" Then
    '                    AddTrace("Processing VEHICLE item")
    '                    For v As Integer = 0 To grdSerialVehicles.Rows.Count - 1
    '                        Dim vehicleItemID As Integer = CInt(CType(grdSerialVehicles.Rows(v).FindControl("lblItem_ID1"), Label).Text)

    '                        If vehicleItemID = currentItemID Then
    '                            Dim PropertyNumber As String = supplies.GetValue("SELECT [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtAcceptDate.Text & "', '" & PropCode & "','" & rcID & "','" & funcID & "')", CommandType.Text)

    '                            ' Create PROPERTY DETAIL
    '                            Dim Prop_Dtl As New t_property_dtl
    '                            With Prop_Dtl
    '                                .PropertyNo = PropertyNumber
    '                                .Property_ID = PropHdr_ID
    '                                .Barcode = ""
    '                                .SerialNo = CType(grdSerialVehicles.Rows(v).FindControl("txtSerialNo"), TextBox).Text
    '                                .Amount = currentCost
    '                                .type = Particular_Desc
    '                                .Issued = False
    '                                .Repair = False
    '                                .Details = ""
    '                                .F_ID = 1
    '                                .Status = "Accepted"
    '                                .IsInspectionForDisposal = False
    '                                .InspectionDate = "1/1/1900"
    '                                .Dispose = False
    '                                .DisposeDate = "1/1/1900"
    '                                .UserID = Session("@UserName")
    '                                .RC_ID = rcID
    '                                .Function_ID = funcID
    '                            End With

    '                            Dim PropDtl_ID As Long = Prop_Dtl.save()
    '                            AddTrace("Saved Vehicle Prop_Dtl: ID=" & PropDtl_ID & ", Serial=" & Prop_Dtl.SerialNo)


    '                            ' Save motor information
    '                            With objMotorInfo
    '                                .Motor_InfoId = pItemForSerial.Rows(x)("motor_id").ToString
    '                                .AIRDtl_ID = AIRDtl_ID
    '                                .IsAccepted = True
    '                                .Property_Dtl_ID = PropDtl_ID
    '                                .Name = grdSerialVehicles.Rows(v).Cells(1).Text
    '                                .PlateNo = CType(grdSerialVehicles.Rows(v).FindControl("txtLicensePlateNo"), TextBox).Text
    '                                .MotorNo = ""
    '                                .Model = ""
    '                                .ChasisNo = CType(grdSerialVehicles.Rows(v).FindControl("txtChasisNo"), TextBox).Text
    '                                .VehicleColor = ""
    '                                .WheelsCapacity = ""
    '                                .GrossWeight = ""
    '                                .Seats = ""
    '                                .Warranty = ""
    '                                .VehicleOwner = ""
    '                                .DeclaredName = ""
    '                                .BeneficialUser = ""
    '                                .VehicleSpecification = ""
    '                                .VehicleDesc = grdSerialVehicles.Rows(v).Cells(1).Text
    '                                .VehicleMake = ""
    '                                .VehicleType = ""
    '                                .PowerInput = ""
    '                                .MVfileNo = CType(grdSerialVehicles.Rows(v).FindControl("txtMvfileno"), TextBox).Text
    '                                .ConSticker = CType(grdSerialVehicles.Rows(v).FindControl("txtConsticker"), TextBox).Text
    '                                .DepRate = 0
    '                                .DepValue = 0
    '                                .NoofYears = 0
    '                                .UsefulLife = 0
    '                                .SalvageValue = 0
    '                                .Received_ID = rcvID
    '                            End With

    '                            Dim motor_info_id As Integer = objMotorInfo.update()
    '                            AddTrace("Saved MotorInfo: ID=" & motor_info_id)


    '                            Dim MotorID As Integer = objDerived.GetValue("SELECT MotorID FROM AMS.TbMotor_Dtl WHERE Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)

    '                            With objMotorDtl
    '                                .MotorID = MotorID
    '                                .Motor_InfoId = motor_info_id
    '                                .Property_Dtl_ID = PropDtl_ID
    '                                .MarketValue = 0
    '                                .Condition = ""
    '                                .Location = ""
    '                                .Status = "Accepted"
    '                            End With
    '                            objMotorDtl.update()
    '                            AddTrace("Saved MotorDtl: ID=" & MotorID)

    '                        End If
    '                    Next
    '                    ' ====== NON-VEHICLE ITEMS ======
    '                Else
    '                    AddTrace("Processing NON-VEHICLE item")
    '                    ' Create one PROPERTY DETAIL per unit
    '                    For q As Integer = 1 To AcptQty
    '                        Dim PropertyNumber As String = supplies.GetValue("SELECT [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtAcceptDate.Text & "', '" & PropCode & "','" & rcID & "','" & funcID & "')", CommandType.Text)
    '                        Dim serialNo As String = ""

    '                        ' Try to find matching serial number
    '                        For s As Integer = 0 To grdSerial.Rows.Count - 1
    '                            Dim serialItemID As Integer = CInt(CType(grdSerial.Rows(s).FindControl("lblItem_ID"), Label).Text)

    '                            If serialItemID = currentItemID Then
    '                                serialNo = CType(grdSerial.Rows(s).FindControl("txtSerialNo"), TextBox).Text
    '                                Exit For
    '                            End If
    '                        Next

    '                        ' Create PROPERTY DETAIL
    '                        Dim Prop_Dtl As New t_property_dtl
    '                        With Prop_Dtl
    '                            .PropertyNo = PropertyNumber
    '                            .Property_ID = PropHdr_ID
    '                            .Barcode = ""
    '                            .SerialNo = serialNo
    '                            .Amount = currentCost
    '                            .type = Particular_Desc
    '                            .Issued = False
    '                            .Repair = False
    '                            .Details = ""
    '                            .F_ID = 1
    '                            .Status = "Accepted"
    '                            .IsInspectionForDisposal = False
    '                            .InspectionDate = "1/1/1900"
    '                            .Dispose = False
    '                            .DisposeDate = "1/1/1900"
    '                            .UserID = Session("@UserName")
    '                            .RC_ID = rcID
    '                            .Function_ID = funcID
    '                        End With

    '                        Dim PropDtl_ID As Long = Prop_Dtl.save()
    '                        AddTrace("Saved Prop_Dtl: ID=" & PropDtl_ID & ", Item=" & currentItemID & ", Qty=" & q & "/" & AcptQty & ", Serial=" & serialNo)

    '                    Next
    '                End If

    '                ' ====== PROPERTY LEDGER ======
    '                Dim ledgerCount As Integer = CInt(objDerived.GetValue("SELECT COUNT(*) FROM [AMS].[TbProperty_Ledger] WHERE Item_ID = " & currentItemID, CommandType.Text))
    '                Dim transType As String = If(ledgerCount > 0, "Purchase Order Delivered", "Starting Inventory")

    '                With Prop_Ledger
    '                    .PropertyNo = ""
    '                    .SerialNo = ""
    '                    .Item_ID = currentItemID
    '                    .dDate = txtAcceptDate.Text
    '                    .Trans_Type = transType
    '                    .Ref = AIR_No
    '                    .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
    '                    .AcceptedBy = ddAcceptedBy.SelectedItem.Text
    '                    .InspectedBy = InspectedBy
    '                    .DebitQty = AcptQty
    '                    .DebitCost = FormatNumber(AcptQty * currentCost, 2)
    '                    .DebitUnit = currentUnit
    '                    .CreditQty = 0
    '                    .CreditCost = "0.00"
    '                    .CreditUnit = " - "
    '                    .BalanceUnit = currentUnit
    '                    .Department = If(grdAIR.SelectedDataKey("RC_ID") = 0, ddDepartment.SelectedItem.Text,
    '                                objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & rcID & "'", CommandType.Text))
    '                    .save()
    '                End With
    '                AddTrace("Saved Ledger: ItemID=" & currentItemID & ", Type=" & transType)

    '            End If
    '        Next

    '        ' Final cleanup
    '        Session("POHdr_ID") = CLng(grdAIR.SelectedDataKey("POHdr_ID"))
    '        Session("CapitalOutlay") = True
    '        AddTrace("Saved ALL properties: ")

    '        ' UI Reset
    '        grdInspection.DataSource = Nothing
    '        grdInspection.DataBind()
    '        ClearForm()

    '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
    '        btnActSave.Enabled = False
    '        btnActPreview.Enabled = True

    '    Catch ex As Exception
    '        Dim errMsg As String = ex.Message
    '        errMsg = errMsg.Replace("\", "\\")
    '        errMsg = errMsg.Replace("'", "\'")
    '        errMsg = errMsg.Replace("""", "\""")
    '        errMsg = errMsg.Replace(vbCr, " ")
    '        errMsg = errMsg.Replace(vbLf, " ")
    '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error: " & errMsg)
    '    End Try
    'End Sub


    Public Sub Save1()
        Try
            btnSaveOS.Enabled = True
            '========================== ACCEPTANCE ==========================
            Dim Quanityx As Integer = 0
            Dim ReceivedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("ReceivedBY") & "'", CommandType.Text)
            Dim InspectedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("InspectedBy") & "'", CommandType.Text)
            Dim rcvID As Long = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            Dim allSavedProps As New List(Of Long) ' Track all saved Property IDs

            ' Find first checked item for Received_ID
            Dim Box As CheckBox
            For a As Integer = 0 To grdInspection.Rows.Count - 1
                Box = CType(Me.grdInspection.Rows(a).Cells(0).FindControl("cbInspection"), CheckBox)
                If Box IsNot Nothing AndAlso Box.Checked Then
                    Dim zx As Long = pInspection_detail.Rows(a)("Received_ID")
                    Session("xReceived_ID") = zx
                    AddTrace("Found a checked item. xReceived_ID set to: " & zx)
                    Exit For
                End If
            Next

            ' Save AIR_Hdr
            Dim AIR_No As String = supplies.GetValue("select [AMS].[func_GenerateAIR]( '" & txtAcceptDate.Text & "')", CommandType.Text)
            Dim xAIRHdr_ID As Long = 0

            With AIR_Hdr
                .AIR_No = AIR_No
                .AIR_Date = txtAcceptDate.Text
                .Invoice_No = txtInvoiceNumber.Text
                .Invoice_date = Date.Parse(txtInvoiceDate.Text)
                .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
                .PO_No = grdAIR.SelectedDataKey("PO_No")
                .Supplier_ID = grdAIR.SelectedDataKey("Supplier_Id")
                .Date_Received = pInspection_detail.Rows(0)("Received_Date")
                .Date_Inspect = pInspection_detail.Rows(0)("Received_Date")
                .Date_Accepted = txtAcceptDate.Text
                .Trans_ID = 1
                .remarks = txtRemakrs.Text
                .IsPartial = (rbStatus.SelectedIndex = 0)
                .isComplete = (rbStatus.SelectedItem.Value = 2)

                If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                    .RC_ID = ddDepartment.SelectedItem.Value
                    .Function_ID = ddFunction.SelectedItem.Value
                Else
                    .RC_ID = grdAIR.SelectedDataKey("RC_ID")
                    .Function_ID = grdAIR.SelectedDataKey("Function_ID")
                End If

                .Received_ID = Session("xReceived_ID")
                .UserID = Session("@UserName")
            End With

            xAIRHdr_ID = AIR_Hdr.save()
            Session("AIRHdr_ID") = xAIRHdr_ID
            AddTrace("Saved AIR_Hdr: ID=" & xAIRHdr_ID)


            ' Loop through each row in grdInspection
            For x As Integer = 0 To grdInspection.Rows.Count - 1
                Dim cb As CheckBox = CType(grdInspection.Rows(x).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb IsNot Nothing AndAlso cb.Checked Then
                    Dim AcptQty As Decimal = CDec(CType(grdInspection.Rows(x).FindControl("txtActQty"), TextBox).Text)
                    Dim currentItemID As Integer = pInspection_detail.Rows(x)("Item_ID")
                    Dim currentCost As Decimal = pInspection_detail.Rows(x)("Cost")
                    Dim currentUnit As String = pInspection_detail.Rows(x)("Unit")
                    Dim currentReceivedID As Long = pInspection_detail.Rows(x)("Received_ID")
                    Dim OtherSpecs As String = pInspection_detail.Rows(x)("OtherSpecs")

                    Session("xReceived_ID") = currentReceivedID
                    AddTrace("Processing checked row: ItemID=" & currentItemID & ", Qty=" & AcptQty)


                    ' Save AIR_Dtl
                    With AIR_Dtl
                        .AIRHdr_ID = xAIRHdr_ID
                        .Item_ID = currentItemID
                        .Qty = AcptQty
                        .Cost = currentCost
                        .GA_ID = grdAIR.SelectedDataKey("GA_ID")
                        .Warranty = 0
                    End With

                    Dim AIRDtl_ID As Long = AIR_Dtl.save()
                    objDerived.Execute("UPDATE AMS.AIR_Dtl SET OtherSpecs = '" & OtherSpecs & "', isAccepted = 1 WHERE AIRDtl_ID = " & AIRDtl_ID, CommandType.Text)
                    AddTrace("Saved AIR_Dtl: ID=" & AIRDtl_ID & ", ItemID=" & currentItemID)


                    ' Get item details
                    Dim Particular_Desc As String = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item " &
            "INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id " &
            "WHERE dbo.m_item.Item_ID = '" & currentItemID & "'", CommandType.Text)
                    Dim PropCode As String = objDerived.GetValue("SELECT GA_Code FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

                    ' Determine department and function
                    Dim rcID As Integer, funcID As Integer
                    If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                        rcID = ddDepartment.SelectedItem.Value
                        funcID = ddFunction.SelectedItem.Value
                    Else
                        rcID = grdAIR.SelectedDataKey("RC_ID")
                        funcID = grdAIR.SelectedDataKey("Function_ID")
                    End If
                    Session("RC_ID") = rcID
                    Session("Function_ID") = funcID

                    ' Create PROPERTY HEADER
                    With Prop_Hdr
                        .Property_Date = txtAcceptDate.Text
                        .Property_code = PropCode
                        .AIRDtl_ID = AIRDtl_ID
                        .GA_ID = grdAIR.SelectedDataKey("GA_ID")
                        .Particular = Particular_Desc
                        .Item_ID = currentItemID
                        .Qty = AcptQty
                        .Balance = AcptQty
                        .Issuance = 0
                        .Cost = currentCost
                        .RC_ID = rcID
                        .Function_ID = funcID
                        .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
                        .Received_ID = currentReceivedID
                        .UserID = Session("@UserName")
                    End With

                    Dim PropHdr_ID As Long = Prop_Hdr.save()
                    allSavedProps.Add(PropHdr_ID)
                    objDerived.Execute("UPDATE [AMS].[Property] SET [OtherSpecs] = '" & OtherSpecs & "' WHERE [Property_ID] = " & PropHdr_ID, CommandType.Text)
                    AddTrace("Saved Prop_Hdr: ID=" & PropHdr_ID & ", ItemID=" & currentItemID)


                    ' Get classification
                    Dim classification As String = objDerived.GetValue("SELECT DISTINCT dbo.tbl_Classification.ClassificationName " &
            "FROM dbo.tbl_SubClassification INNER JOIN dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId " &
            "INNER JOIN dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID " &
            "WHERE dbo.m_item.Item_ID = '" & currentItemID & "'", CommandType.Text)

                    ' ====== VEHICLE ITEMS ======
                    If classification = "Vehicle" Then
                        AddTrace("Processing VEHICLE item")
                        For v As Integer = 0 To grdSerialVehicles.Rows.Count - 1
                            Dim vehicleItemID As Integer = CInt(CType(grdSerialVehicles.Rows(v).FindControl("lblItem_ID1"), Label).Text)

                            If vehicleItemID = currentItemID Then
                                Dim PropertyNumber As String = supplies.GetValue("SELECT [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtAcceptDate.Text & "', '" & PropCode & "','" & rcID & "','" & funcID & "')", CommandType.Text)

                                ' Create PROPERTY DETAIL
                                Dim Prop_Dtl As New t_property_dtl
                                With Prop_Dtl
                                    .PropertyNo = PropertyNumber
                                    .Property_ID = PropHdr_ID
                                    .Barcode = ""
                                    .SerialNo = CType(grdSerialVehicles.Rows(v).FindControl("txtSerialNo"), TextBox).Text
                                    .Amount = currentCost
                                    .type = Particular_Desc
                                    .Issued = False
                                    .Repair = False
                                    .Details = ""
                                    .F_ID = 1
                                    .Status = "Accepted"
                                    .IsInspectionForDisposal = False
                                    .InspectionDate = "1/1/1900"
                                    .Dispose = False
                                    .DisposeDate = "1/1/1900"
                                    .UserID = Session("@UserName")
                                    .RC_ID = rcID
                                    .Function_ID = funcID
                                End With

                                Dim PropDtl_ID As Long = Prop_Dtl.save()
                                AddTrace("Saved Vehicle Prop_Dtl: ID=" & PropDtl_ID & ", Serial=" & Prop_Dtl.SerialNo)


                                ' Save motor information
                                With objMotorInfo
                                    .Motor_InfoId = pItemForSerial.Rows(x)("motor_id").ToString
                                    .AIRDtl_ID = AIRDtl_ID
                                    .IsAccepted = True
                                    .Property_Dtl_ID = PropDtl_ID
                                    .Name = grdSerialVehicles.Rows(v).Cells(1).Text
                                    .PlateNo = CType(grdSerialVehicles.Rows(v).FindControl("txtLicensePlateNo"), TextBox).Text
                                    .MotorNo = ""
                                    .Model = ""
                                    .ChasisNo = CType(grdSerialVehicles.Rows(v).FindControl("txtChasisNo"), TextBox).Text
                                    .VehicleColor = ""
                                    .WheelsCapacity = ""
                                    .GrossWeight = ""
                                    .Seats = ""
                                    .Warranty = ""
                                    .VehicleOwner = ""
                                    .DeclaredName = ""
                                    .BeneficialUser = ""
                                    .VehicleSpecification = ""
                                    .VehicleDesc = grdSerialVehicles.Rows(v).Cells(1).Text
                                    .VehicleMake = ""
                                    .VehicleType = ""
                                    .PowerInput = ""
                                    .MVfileNo = CType(grdSerialVehicles.Rows(v).FindControl("txtMvfileno"), TextBox).Text
                                    .ConSticker = CType(grdSerialVehicles.Rows(v).FindControl("txtConsticker"), TextBox).Text
                                    .DepRate = 0
                                    .DepValue = 0
                                    .NoofYears = 0
                                    .UsefulLife = 0
                                    .SalvageValue = 0
                                    .Received_ID = rcvID
                                End With

                                Dim motor_info_id As Integer = objMotorInfo.update()
                                AddTrace("Saved MotorInfo: ID=" & motor_info_id)


                                Dim MotorID As Integer = objDerived.GetValue("SELECT MotorID FROM AMS.TbMotor_Dtl WHERE Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)

                                With objMotorDtl
                                    .MotorID = MotorID
                                    .Motor_InfoId = motor_info_id
                                    .Property_Dtl_ID = PropDtl_ID
                                    .MarketValue = 0
                                    .Condition = ""
                                    .Location = ""
                                    .Status = "Accepted"
                                End With
                                objMotorDtl.update()
                                AddTrace("Saved MotorDtl: ID=" & MotorID)

                            End If
                        Next
                        ' ====== NON-VEHICLE ITEMS ======
                    Else
                        AddTrace("Processing NON-VEHICLE item")

                        ' FIXED SERIAL NUMBER HANDLING - COLLECT ALL SERIALS FOR THIS ITEM
                        Dim serialsForItem As New List(Of String)
                        For s As Integer = 0 To grdSerial.Rows.Count - 1
                            Dim serialItemID As Integer = CInt(CType(grdSerial.Rows(s).FindControl("lblItem_ID"), Label).Text)
                            If serialItemID = currentItemID Then
                                Dim serialText As String = CType(grdSerial.Rows(s).FindControl("txtSerialNo"), TextBox).Text
                                serialsForItem.Add(serialText.Trim())
                            End If
                        Next

                        ' Create one PROPERTY DETAIL per unit
                        For q As Integer = 1 To AcptQty
                            Dim PropertyNumber As String = supplies.GetValue("SELECT [dbo].[func_GeneratePropertyNo_BATAAN]('" & txtAcceptDate.Text & "', '" & PropCode & "','" & rcID & "','" & funcID & "')", CommandType.Text)

                            ' Use serial if available, else empty
                            Dim serialNo As String = If(q <= serialsForItem.Count, serialsForItem(q - 1), "")

                            ' Create PROPERTY DETAIL
                            Dim Prop_Dtl As New t_property_dtl
                            With Prop_Dtl
                                .PropertyNo = PropertyNumber
                                .Property_ID = PropHdr_ID
                                .Barcode = ""
                                .SerialNo = serialNo
                                .Amount = currentCost
                                .type = Particular_Desc
                                .Issued = False
                                .Repair = False
                                .Details = ""
                                .F_ID = 1
                                .Status = "Accepted"
                                .IsInspectionForDisposal = False
                                .InspectionDate = "1/1/1900"
                                .Dispose = False
                                .DisposeDate = "1/1/1900"
                                .UserID = Session("@UserName")
                                .RC_ID = rcID
                                .Function_ID = funcID
                            End With

                            Dim PropDtl_ID As Long = Prop_Dtl.save()
                            AddTrace("Saved Prop_Dtl: ID=" & PropDtl_ID & ", Item=" & currentItemID & ", Qty=" & q & "/" & AcptQty & ", Serial=" & serialNo)
                        Next
                    End If

                    ' ====== PROPERTY LEDGER ======
                    Dim ledgerCount As Integer = CInt(objDerived.GetValue("SELECT COUNT(*) FROM [AMS].[TbProperty_Ledger] WHERE Item_ID = " & currentItemID, CommandType.Text))
                    Dim transType As String = If(ledgerCount > 0, "Purchase Order Delivered", "Starting Inventory")

                    With Prop_Ledger
                        .PropertyNo = ""
                        .SerialNo = ""
                        .Item_ID = currentItemID
                        .dDate = txtAcceptDate.Text
                        .Trans_Type = transType
                        .Ref = AIR_No
                        .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                        .AcceptedBy = ddAcceptedBy.SelectedItem.Text
                        .InspectedBy = InspectedBy
                        .DebitQty = AcptQty
                        .DebitCost = FormatNumber(AcptQty * currentCost, 2)
                        .DebitUnit = currentUnit
                        .CreditQty = 0
                        .CreditCost = "0.00"
                        .CreditUnit = " - "
                        .BalanceUnit = currentUnit
                        .Department = If(grdAIR.SelectedDataKey("RC_ID") = 0, ddDepartment.SelectedItem.Text,
                                objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & rcID & "'", CommandType.Text))
                        .save()
                    End With
                    AddTrace("Saved Ledger: ItemID=" & currentItemID & ", Type=" & transType)

                End If
            Next

            ' Final cleanup
            Session("POHdr_ID") = CLng(grdAIR.SelectedDataKey("POHdr_ID"))
            Session("CapitalOutlay") = True
            AddTrace("Saved ALL properties: ")

            ' UI Reset
            grdInspection.DataSource = Nothing
            grdInspection.DataBind()
            ClearForm()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btnActSave.Enabled = False
            btnActPreview.Enabled = True

        Catch ex As Exception
            Dim errMsg As String = ex.Message
            errMsg = errMsg.Replace("\", "\\")
            errMsg = errMsg.Replace("'", "\'")
            errMsg = errMsg.Replace("""", "\""")
            errMsg = errMsg.Replace(vbCr, " ")
            errMsg = errMsg.Replace(vbLf, " ")
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error: " & errMsg)
        End Try
    End Sub

    Private Sub ClearForm()
        ' Clear dropdowns
        ddSearch.SelectedIndex = 0
        ddSupplier.Items.Clear()
        ddSupplier.Items.Insert(0, New ListItem("Select", "0"))
        ddDepartment.Items.Clear()
        ddDepartment.Items.Insert(0, New ListItem("Select", "0"))
        ddFunction.Items.Clear()
        ddFunction.Items.Insert(0, New ListItem("Select", "0"))
        ddAcceptedBy.Items.Clear()
        ddAcceptedBy.Items.Insert(0, New ListItem("Select", "0"))

        ' Clear textboxes
        txtSupplierName.Text = ""
        txtPoNumber.Text = ""
        txtPodate.Text = ""
        txtInvoiceNumber.Text = ""
        txtInvoiceDate.Text = ""

        txtRemakrs.Text = ""

        ' Rebind grids
        LoadrbALL()
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub



    Protected Sub btnSave_Click(sender As Object, e As EventArgs)

        ' --- TRACER: Check if any row is selected in grdAIR ---
        'Try


        If grdAIR.SelectedIndex < 0 OrElse grdAIR.SelectedDataKey Is Nothing Then
            AddTrace("No row is currently selected in grdAIR. Exiting.")
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No row selected. Please select a row from the Purchase Orders list before saving.")
            Exit Sub
        Else
            AddTrace("Row is selected. SelectedIndex = " & grdAIR.SelectedIndex.ToString() &
                 ", POHdr_ID = " & grdAIR.SelectedDataKey("POHdr_ID").ToString() &
                 ", RC_ID = " & grdAIR.SelectedDataKey("RC_ID").ToString())
        End If

        AddTrace("Attempting to parse invoiceDate from txtInvoiceDate.Text = '" & txtInvoiceDate.Text & "'")
        Dim invoiceDate As DateTime = DateTime.Parse(txtInvoiceDate.Text)
        AddTrace("invoiceDate successfully parsed: " & invoiceDate.ToString("yyyy-MM-dd"))

        ' Ensure Department/Function is selected if RC_ID=0
        If grdAIR.SelectedDataKey("RC_ID") = 0 Then
            AddTrace("Checking if ddDepartment or ddFunction is set to 'Select' because RC_ID=0")
            If ddDepartment.SelectedItem.Text = "Select" Or ddFunction.SelectedItem.Text = "Select" Then
                AddTrace("Either Department or Function not selected; exiting.")
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select department and its function.")
                Exit Sub
            End If
        End If

        Dim poHdrIdVal As String = grdAIR.SelectedDataKey("POHdr_ID").ToString()
        AddTrace("poHdrIdVal: " & poHdrIdVal)
        Dim rcvID As Long
        'AddTrace("rcvID: " & rcvID)

        Dim selectedReceivedId As Long = CLng(grdAIR.SelectedDataKey("Received_ID"))
        Dim resetIsDisplayReport = "UPDATE AMS.Tb_Receiving_Dtl SET IsDisplayReport = 0 WHERE Received_ID = " & selectedReceivedId
        objDerived.Execute(resetIsDisplayReport, CommandType.Text)


        '--ALREADY EXIST
        'UPDATE

        Dim cb_1 As CheckBox
        If Session("CapitalOutlay") = False Then

            For x As Integer = 0 To grdInspection.Rows.Count - 1
                ' Determine the correct Received_ID by matching both POHdr_ID and Item_ID
                Dim itemID As Long = 0
                If Not IsDBNull(pInspection_detail.Rows(x)("Item_ID")) Then
                    itemID = Convert.ToInt64(pInspection_detail.Rows(x)("Item_ID"))
                Else
                    AddTrace("Warning: Item_ID is NULL in pInspection_detail.Rows(" & x & ")")
                    Continue For ' Skip to next loop iteration
                End If

                ' Use the actual Received_ID tied to this row/item (from your data table)
                rcvID = Convert.ToInt64(pInspection_detail.Rows(x)("Received_ID"))
                AddTrace("Resolved rcvID (from row) for Item_ID=" & itemID.ToString() & ": " & rcvID)

                ' Look up per-item/per-receiving existence AFTER itemID/rcvID are known
                Dim checkAIR As Long = objDerived.GetValue(
                "SELECT TOP 1 AIRHdr_ID FROM AMS.AIR_Hdr WHERE Received_ID = " & rcvID & " AND POHdr_ID = " & poHdrIdVal,
                CommandType.Text)

                Dim checkStock As Long = objDerived.GetValue(
                "SELECT TOP 1 StockID FROM AMS.Stock WHERE Received_ID = " & rcvID & " AND Item_ID = " & itemID,
                CommandType.Text)



                cb_1 = CType(Me.grdInspection.Rows(x).Cells(0).FindControl("cbInspection"), CheckBox)
                Dim RcvDtl_ID As Long = objDerived.GetValue("SELECT Received_Dtl_ID FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = '" & rcvID & "' AND Item_ID = '" & pInspection_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
                AddTrace("rcvID: " & rcvID)
                AddTrace("Item_ID: " & pInspection_detail.Rows(x)("Item_ID"))



                AddTrace("RcvDtl_ID: " & RcvDtl_ID)
                Dim txtQty As TextBox = CType(grdInspection.Rows(x).FindControl("txtActQty"), TextBox)

                Dim receivedQty As Decimal
                If Not Decimal.TryParse(txtQty.Text, receivedQty) Then
                    receivedQty = 0 ' Default to 0 if parsing fails
                End If

                If cb_1 IsNot Nothing AndAlso cb_1.Checked Then

                    '=== Check if item exists in tblclassmatrix for this GA_ID ===
                    Dim checkClassMatrix As Integer = objDerived.GetValue("SELECT COUNT(*) FROM dbo.tblclassmatrix WHERE item_id = '" & pInspection_detail.Rows(x)("Item_ID") & "' AND ga_id = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

                    If checkClassMatrix = 0 Then
                        '=== Insert mapping using same classification/category as existing item for same GA_ID ===
                        Dim categoryid As Integer = objDerived.GetValue("SELECT TOP 1 categoryid FROM dbo.tblclassmatrix WHERE ga_id = '" & grdAIR.SelectedDataKey("GA_ID") & "' AND categoryid IS NOT NULL", CommandType.Text)
                        Dim classificationid As Integer = objDerived.GetValue("SELECT TOP 1 classificationid FROM dbo.tblclassmatrix WHERE ga_id = '" & grdAIR.SelectedDataKey("GA_ID") & "' AND classificationid IS NOT NULL", CommandType.Text)

                        If IsDBNull(categoryid) OrElse categoryid = 0 Then
                            categoryid = 0  ' Default category 
                        End If
                        If IsDBNull(classificationid) OrElse classificationid = 0 Then
                            classificationid = 0 ' Default classification 
                        End If

                        Dim insertMatrix As String = "INSERT INTO dbo.tblclassmatrix (classificationid, ga_id, categoryid, subcategoryid, item_id, SubClassificationID, BGA_ID) " &
                                 "VALUES ('" & classificationid & "','" & grdAIR.SelectedDataKey("GA_ID") & "','" & categoryid & "',0,'" & pInspection_detail.Rows(x)("Item_ID") & "',NULL,0)"
                        objDerived.Execute(insertMatrix, CommandType.Text)
                        AddTrace("tblclassmatrix row inserted for Item_ID=" & pInspection_detail.Rows(x)("Item_ID") & " and GA_ID=" & grdAIR.SelectedDataKey("GA_ID"))
                    End If





                    'for report
                    Dim updateItemReportDisplay = "update AMS.Tb_Receiving_Dtl set AMS.Tb_Receiving_Dtl.IsDisplayReport = 1 where AMS.Tb_Receiving_Dtl.Received_Dtl_ID = '" & RcvDtl_ID & "' "
                    objDerived.Execute(updateItemReportDisplay, CommandType.Text)

                    'for report
                    Dim updateTempQuantity As String = "update AMS.Tb_Receiving_Dtl set AMS.Tb_Receiving_Dtl.tempReportQuantity = '" & receivedQty & "' where AMS.Tb_Receiving_Dtl.Received_Dtl_ID = '" & RcvDtl_ID & "' "
                    objDerived.Execute(updateTempQuantity, CommandType.Text)

                    Dim result As Object = objDerived.GetValue("SELECT Qty_Accepting FROM AMS.Tb_Receiving_Dtl WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
                    Dim Qty_AcceptedValue As Decimal
                    Dim calResult As Decimal
                    AddTrace("RcvDtl_ID: " & RcvDtl_ID)
                    AddTrace("result: " & result)

                    If result IsNot DBNull.Value Then
                        ' Try parsing the result as Decimal
                        If Decimal.TryParse(result.ToString(), Qty_AcceptedValue) Then
                        End If
                    End If

                    AddTrace("receivedQty: " & receivedQty)
                    AddTrace("Qty_AcceptedValue: " & Qty_AcceptedValue)
                    If (receivedQty <= Qty_AcceptedValue) Then
                        calResult = Math.Abs(Qty_AcceptedValue - receivedQty) '// 0 if complete, 8-8
                    Else
                        'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The quantity desired to return is more that existing quantity, Reminder: Reload to see existing quantity.")

                        ' Exit Sub
                    End If

                    'UPDATE QTY_Accepted VALUE
                    AddTrace("calResult: " & calResult)
                    AddTrace("RcvDtl_ID: " & RcvDtl_ID)

                    Dim updateDtlSQL As String = "UPDATE AMS.Tb_Receiving_Dtl SET Qty_Accepting = " & calResult & " WHERE Received_Dtl_ID = " & RcvDtl_ID
                    objDerived.Execute(updateDtlSQL, CommandType.Text)

                    If checkStock <> 0 Then
                        'stock no dtl

                        Dim updateStock As String = "UPDATE AMS.Stock " &
                            "SET Qty = Qty + " & receivedQty & ", Balance = Balance + " & receivedQty & " " &
                            "WHERE Received_ID = " & rcvID & " AND Item_ID = " & pInspection_detail.Rows(x)("Item_ID")
                        objDerived.Execute(updateStock, CommandType.Text)

                        'update stock ledger
                        Dim updateStockLedger As String = "update AMS.TbStock_Ledger set AMS.TbStock_Ledger.DebitQty = '" & receivedQty & "' + AMS.TbStock_Ledger.DebitQty where AMS.TbStock_Ledger.StockID = '" & checkStock & "' and AMS.TbStock_Ledger.Item_ID = '" & pInspection_detail.Rows(x)("Item_ID") & "' "
                    End If

                    If checkAIR <> 0 Then
                        'stock no dtl
                        Dim getAIR_ID As Integer = objDerived.GetValue("SELECT AIRHdr_ID FROM AMS.AIR_Hdr WHERE Received_ID = " & rcvID & " AND POHdr_ID = " & poHdrIdVal, CommandType.Text)
                        Dim updateAirDtl As String = "UPDATE AMS.AIR_Dtl " &
                                                     "SET Qty = Qty + " & receivedQty & " " &
                                                     "WHERE AIRHdr_ID = " & getAIR_ID & " AND Item_ID = " & pInspection_detail.Rows(x)("Item_ID")
                        objDerived.Execute(updateAirDtl, CommandType.Text)

                    End If
                End If
            Next
        End If
        Session("CapitalOutlay") = False '--==IMPORTANT, USED AS FLAGGING FOR CAPITAL OUTLAY AS IT LOOP AGAIN DOING DUPLICATE LOOP.

        '--NON EXISTING STOCK AND AIR
        'SAVE AND CREATE ROW
        AddTrace("AllotmentClass: " & AllotmentClass)
        If AllotmentClass = 2 Then
            AddTrace("AllotmentClass=2 => MOOE flow.")
            Dim ReceivedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("ReceivedBY") & "'", CommandType.Text)
            AddTrace("ReceivedBy from pInspection_detail: " & ReceivedBy)
            Dim InspectedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("InspectedBy") & "'", CommandType.Text)
            AddTrace("InspectedBy from pInspection_detail: " & InspectedBy)

            AddTrace("Generating AIR_No via [AMS].[func_GenerateAIR] for date = " & txtAcceptDate.Text)
            Dim AIR_No As String = supplies.GetValue("select [AMS].[func_GenerateAIR]( '" & txtAcceptDate.Text & "')", CommandType.Text)
            AddTrace("AIR_No generated: " & AIR_No)

            Dim xAIRHdr_ID As Long

            With AIR_Hdr
                .AIR_No = AIR_No
                .AIR_Date = txtAcceptDate.Text
                .Invoice_No = txtInvoiceNumber.Text
                .Invoice_date = Date.Parse(txtInvoiceDate.Text)
                .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
                .PO_No = grdAIR.SelectedDataKey("PO_No")
                .Supplier_ID = grdAIR.SelectedDataKey("Supplier_Id")
                .Date_Received = pInspection_detail.Rows(0)("Received_Date")
                .Date_Inspect = pInspection_detail.Rows(0)("Received_Date")
                .Date_Accepted = txtAcceptDate.Text
                .Trans_ID = 1
                .remarks = txtRemakrs.Text
                .IsInspected = True

                If rbStatus.SelectedIndex = 0 Then
                    .IsPartial = True
                End If

                If rbStatus.SelectedItem.Value = 2 Then
                    .isComplete = True
                Else
                    .isComplete = False
                End If
                AddTrace("AIR_Hdr isComplete: " & .isComplete.ToString())

                If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                    AddTrace("RC_ID=0 => Using ddDepartment/ddFunction.")
                    .RC_ID = ddDepartment.SelectedItem.Value
                    .Function_ID = ddFunction.SelectedItem.Value
                Else
                    .RC_ID = grdAIR.SelectedDataKey("RC_ID")
                    .Function_ID = grdAIR.SelectedDataKey("Function_ID")
                    AddTrace("RC_ID and Function_ID read from SelectedDataKey: RC_ID=" & .RC_ID & ", Function_ID=" & .Function_ID)
                End If

                AddTrace("Looping through grdInspection checkboxes to find first checked item.")
                Dim Box As CheckBox
                For a As Integer = 0 To grdInspection.Rows.Count - 1
                    Box = CType(Me.grdInspection.Rows(a).Cells(0).FindControl("cbInspection"), CheckBox)
                    If Box IsNot Nothing AndAlso Box.Checked Then
                        Dim zx As Long = pInspection_detail.Rows(a)("Received_ID")
                        Session("xReceived_ID") = zx
                        AddTrace("Found a checked item. xReceived_ID set to: " & zx)
                        Exit For
                    End If
                Next

                .Received_ID = Session("xReceived_ID")
                .UserID = Session("@UserName")
            End With

            AddTrace("Saving AIR_Hdr record now...")
            xAIRHdr_ID = AIR_Hdr.save
            AddTrace("AIR_Hdr saved. xAIRHdr_ID = " & xAIRHdr_ID.ToString())
            Session("AIRHdr_ID") = xAIRHdr_ID

            '
            Dim updateAcceptSignatory As String = "UPDATE AMS.Tb_Receiving SET InspectedBy3 = '" & If(ddAcceptedBy.SelectedItem.Value, Nothing) & "' WHERE Received_ID = '" & Session("xReceived_ID") & "'"
            objDerived.Execute(updateAcceptSignatory, CommandType.Text)

            ' Validate StockDate format
            Try
                Dim testDate As DateTime = DateTime.Parse(txtAcceptDate.Text)
                AddTrace("StockDate is valid: " & testDate.ToString("yyyy-MM-dd"))
            Catch ex As Exception
                AddTrace("ERROR: Invalid StockDate format: " & txtAcceptDate.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid date format for Stock Date")
                Exit Sub
            End Try

            Dim cb As CheckBox
            For x As Integer = 0 To grdInspection.Rows.Count - 1
                cb = CType(Me.grdInspection.Rows(x).Cells(0).FindControl("cbInspection"), CheckBox)
                If cb IsNot Nothing AndAlso cb.Checked Then
                    ' ➕ Resolve row-specific IDs first
                    Dim itemID As Long = CLng(pInspection_detail.Rows(x)("Item_ID"))
                    rcvID = CLng(pInspection_detail.Rows(x)("Received_ID"))
                    AddTrace("[MOOE loop] rcvID=" & rcvID.ToString() & ", itemID=" & itemID.ToString())


                    ' ➕ Recompute existence checks for THIS row/item
                    Dim checkStock As Long = CLng(objDerived.GetValue(
            "SELECT TOP 1 StockID FROM AMS.Stock WHERE Received_ID = " & rcvID & " AND Item_ID = " & itemID,
            CommandType.Text))

                    ' (Optional) only if you need it later:
                    'Dim checkAIR As Long = CLng(objDerived.GetValue(
                    '    "SELECT TOP 1 AIRHdr_ID FROM AMS.AIR_Hdr WHERE Received_ID = " & rcvID & " AND POHdr_ID = " & poHdrIdVal,
                    '    CommandType.Text))

                    Dim AcptQty As Decimal = CType(CType(grdInspection.Rows(x).FindControl("txtActQty"), TextBox).Text, Decimal)
                    AddTrace("Accepting item with index " & x & ": AcptQty=" & AcptQty.ToString())


                    objDerived.GetRecords("UPDATE AMS.Tb_Receiving_Dtl Set Status = 2 where Received_ID = '" & rcvID & "' and Item_ID='" & pInspection_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
                    AddTrace("Executed: UPDATE AMS.Tb_Receiving_Dtl for Received_ID=" & rcvID & " Item_ID=" & pInspection_detail.Rows(x)("Item_ID").ToString())

                    Dim AIRDtl_ID As Long

                    '=-= SAVE AMS.AIR_Dtl
                    AddTrace("Now saving AIR_Dtl for item_id=" & pInspection_detail.Rows(x)("Item_ID").ToString())
                    With AIR_Dtl
                        .AIRHdr_ID = xAIRHdr_ID
                        .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                        .Qty = AcptQty
                        .Cost = pInspection_detail.Rows(x)("Cost")
                        .GA_ID = grdAIR.SelectedDataKey("GA_ID")
                        .Warranty = 0
                    End With


                    AIRDtl_ID = AIR_Dtl.save
                    AddTrace("AIR_Dtl saved with ID=" & AIRDtl_ID.ToString())

                    objDerived.GetRecords("UPDATE AMS.AIR_Dtl SET OtherSpecs = '" & pInspection_detail.Rows(x)("OtherSpecs") & "', isAccepted = 1 WHERE AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)
                    AddTrace("Updated AMS.AIR_Dtl => set isAccepted=1, OtherSpecs=" & pInspection_detail.Rows(x)("OtherSpecs").ToString())

                    '==================================================================================
                    '=-= SAVE AMS.STOCK

                    If checkStock = 0 Then
                        With Stock
                            .StockDate = txtAcceptDate.Text
                            .AIRDtl_ID = AIRDtl_ID
                            .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                            .Qty = AcptQty
                            .Balance = AcptQty
                            .Expiration_Date = CDate(txtAcceptDate.Text).AddYears(5)

                            .Issuance = 0
                            .Cost = pInspection_detail.Rows(x)("Cost")
                            .Project_ID = 0
                            .Program_id = 0
                            .F_ID = 1
                            .GA_ID = grdAIR.SelectedDataKey("GA_ID")
                            .Location = If(IsDBNull(pInspection_detail.Rows(x)("Location")), "", pInspection_detail.Rows(x)("Location").ToString())


                            If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                                .RC_ID = ddDepartment.SelectedItem.Value
                                .Function_ID = ddFunction.SelectedItem.Value
                            Else
                                .RC_ID = grdAIR.SelectedDataKey("RC_ID")
                                .Function_ID = grdAIR.SelectedDataKey("Function_ID")
                            End If

                            .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
                            .Received_ID = Session("xReceived_ID")
                            .UserID = Session("@UserName")
                        End With

                        AddTrace("Stock object initialized successfully. Proceeding to save...")

                        Dim StckID As Long = Stock.save
                        AddTrace("Stock record saved with ID=" & StckID.ToString())


                        objDerived.Execute("update ams.TBSupplies_Info set StockID = '" & StckID & "' where ams.TBSupplies_Info.Received_ID = '" & rcvID & "' And ams.TBSupplies_Info.ItemId = '" & pInspection_detail.Rows(x)("Item_ID") & "' ", CommandType.Text)


                        objDerived.Execute("UPDATE [AMS].[Stock] SET [OtherSpecs] = '" & pInspection_detail.Rows(x)("OtherSpecs") & "' WHERE [StockID] = " & StckID & "", CommandType.Text)
                        AddTrace("Updated [AMS].[Stock] => set OtherSpecs=" & pInspection_detail.Rows(x)("OtherSpecs").ToString())

                        Dim Remarks = objDerived.Execute("select count(*) from [AMS].[Stock]  WHERE [StockID] = " & StckID & "", CommandType.Text)
                        AddTrace("Remarks count from AMS.Stock => " & Remarks.ToString())

                        '=-= SAVE AMS.TbStock_Ledger
                        Dim A As String = objDerived.GetValue("select distinct Trans_Type from AMS.TbStock_Ledger where Trans_Type = 'Starting Inventory' and Item_ID='" & pInspection_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
                        If A = "Starting Inventory" Then
                            AddTrace("Existing 'Starting Inventory' ledger found for Item_ID=" & pInspection_detail.Rows(x)("Item_ID").ToString())
                            If Remarks <> 0 Then
                                AddTrace("Saving Stock_Ledger => Trans_Type='Purchase Order Delivered'")
                                With Stock_Ledger
                                    .StockID = StckID
                                    .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                                    .dDate = txtAcceptDate.Text
                                    .Trans_Type = "Purchase Order Delivered"
                                    .Ref = AIR_No
                                    .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                                    .ReceivedBy = ReceivedBy
                                    .InspectedBy = InspectedBy
                                    .AcceptedBy = ddAcceptedBy.SelectedItem.Text
                                    .DebitQty = AcptQty
                                    .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
                                    .DebitUnit = pInspection_detail.Rows(x)("Unit")
                                    .CreditQty = 0
                                    .CreditCost = "0.00"
                                    .CreditUnit = pInspection_detail.Rows(x)("Unit")
                                    .BalanceUnit = pInspection_detail.Rows(x)("Unit")

                                    If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                                        .Department = ddDepartment.SelectedItem.Text
                                    Else
                                        .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                                    End If
                                    .save()
                                End With
                            Else
                                AddTrace("No remarks in Stock => still using 'Purchase Order Delivered' ledger entry")
                                With Stock_Ledger
                                    .StockID = StckID
                                    .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                                    .dDate = txtAcceptDate.Text
                                    .Trans_Type = "Purchase Order Delivered"
                                    .Ref = AIR_No
                                    .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                                    .ReceivedBy = ReceivedBy
                                    .InspectedBy = InspectedBy
                                    .AcceptedBy = ddAcceptedBy.SelectedItem.Text
                                    .DebitQty = AcptQty
                                    .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
                                    .DebitUnit = pInspection_detail.Rows(x)("Unit")
                                    .CreditQty = 0
                                    .CreditCost = "0.00"
                                    .CreditUnit = pInspection_detail.Rows(x)("Unit")
                                    .BalanceUnit = pInspection_detail.Rows(x)("Unit")

                                    If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                                        .Department = ddDepartment.SelectedItem.Text
                                    Else
                                        .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                                    End If
                                    .save()
                                End With
                            End If
                        ElseIf IsDBNull(A) OrElse A = "" Then
                            AddTrace("No 'Starting Inventory' ledger => creating new one.")
                            If Remarks <> 0 Then
                                AddTrace("Some remarks => saving with Trans_Type='Starting Inventory'")
                                With Stock_Ledger
                                    .StockID = StckID
                                    .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                                    .dDate = txtAcceptDate.Text
                                    .Trans_Type = "Starting Inventory"
                                    .Ref = AIR_No
                                    .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                                    .ReceivedBy = ReceivedBy
                                    .InspectedBy = InspectedBy
                                    .AcceptedBy = ddAcceptedBy.SelectedItem.Text
                                    .DebitQty = AcptQty
                                    .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
                                    .DebitUnit = pInspection_detail.Rows(x)("Unit")
                                    .CreditQty = 0
                                    .CreditCost = "0.00"
                                    .CreditUnit = pInspection_detail.Rows(x)("Unit")
                                    .BalanceUnit = pInspection_detail.Rows(x)("Unit")

                                    If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                                        .Department = ddDepartment.SelectedItem.Text
                                    Else
                                        .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                                    End If
                                    .save()
                                End With
                            Else
                                AddTrace("No remarks => STILL saving with Trans_Type='Starting Inventory'")
                                With Stock_Ledger
                                    .StockID = StckID
                                    .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                                    .dDate = txtAcceptDate.Text
                                    .Trans_Type = "Starting Inventory"
                                    .Ref = AIR_No
                                    .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                                    .ReceivedBy = ReceivedBy
                                    .InspectedBy = InspectedBy
                                    .AcceptedBy = ddAcceptedBy.SelectedItem.Text
                                    .DebitQty = AcptQty
                                    .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
                                    .DebitUnit = pInspection_detail.Rows(x)("Unit")
                                    .CreditQty = 0
                                    .CreditCost = "0.00"
                                    .CreditUnit = pInspection_detail.Rows(x)("Unit")
                                    .BalanceUnit = pInspection_detail.Rows(x)("Unit")

                                    If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                                        .Department = ddDepartment.SelectedItem.Text
                                    Else
                                        .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                                    End If
                                    .save()
                                End With
                            End If
                        End If
                        'end of checking if stock exist
                    End If
                End If
            Next

            AddTrace("MOOE transaction completed => Alert user & refresh grids.")
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btnActSave.Enabled = False
            btnActPreview.Enabled = True
            'LoadSearchBy()

            Dim currentPOHdrID As Long = CLng(grdAIR.SelectedDataKey("POHdr_ID"))


            LoadSearchBy()
            Session("POHdr_ID") = currentPOHdrID
            AddTrace("newPOHdrID => " & currentPOHdrID.ToString())

            ' Clear the GridView
            grdInspection.DataSource = Nothing
            grdInspection.DataBind()


        ElseIf AllotmentClass = 3 Then
            AddTrace("AllotmentClass=3 => Capital Outlay flow.")
            Dim a As String = objDerived.GetValue("SELECT DISTINCT dbo.tbl_Classification.ClassificationName " &
             "FROM dbo.tbl_SubClassification INNER JOIN " &
             "dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId " &
             "INNER JOIN dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID " &
             "WHERE dbo.m_item.Item_ID = '" & pInspection_detail.Rows(0)("Item_ID") & "'", CommandType.Text)
            AddTrace("ClassificationName => " & a)

            If a = "Vehicle" Then
                AddTrace("Deleting from Temp_ForSerial for POHdr_ID=" & poHdrIdVal)
                objDerived.GetRecords("DELETE dbo.Temp_ForSerial WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' ", CommandType.Text)

                Dim cb As CheckBox
                For i As Integer = 0 To grdInspection.Rows.Count - 1
                    cb = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        Dim item_ida As Integer = pInspection_detail.Rows(i)("Item_ID").ToString
                        AddTrace("Processing Vehicle item_id=" & item_ida.ToString())
                        Dim Motor_InfoId As Integer = objDerived.GetValue("select Motor_InfoId from AMS.TbMotor_Info WHERE Received_ID = '" & rcvID & "' AND Item_ID='" & pInspection_detail.Rows(i)("Item_ID").ToString & "'", CommandType.Text)
                        AddTrace("Motor_InfoId => " & Motor_InfoId.ToString())

                        Dim POHdr_ID As Long = grdAIR.SelectedDataKey("POHdr_ID")
                        Dim AcptQty As Decimal = CType(CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox).Text, Decimal)
                        Dim Item_ID As Long = pInspection_detail.Rows(i)("Item_ID").ToString
                        Dim Item_Desc As String = pInspection_detail.Rows(i)("Item_Desc").ToString
                        AddTrace("Saving spSave_Temp_ForSerial => POHdr_ID=" & POHdr_ID.ToString() &
                             ", Item_ID=" & Item_ID.ToString() & ", AcptQty=" & AcptQty.ToString())

                        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
                        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
                        objDerived.cmd.Parameters.AddWithValue("@Item_Desc", Item_Desc)
                        objDerived.cmd.Parameters.AddWithValue("@AcptQty", AcptQty)
                        objDerived.cmd.Parameters.AddWithValue("@motor_id", Motor_InfoId)
                        objDerived.Execute("[AMS].[spSave_Temp_ForSerial]", CommandType.StoredProcedure, Nothing)
                    End If
                Next

                AddTrace("Binding data to grdSerialVehicles from sp_Acceptance_SerialNo_List.")
                pItemForSerial = objDerived.GetDataTable("EXEC [AMS].[sp_Acceptance_SerialNo_List] '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
                grdSerialVehicles.DataSource = pItemForSerial
                grdSerialVehicles.DataBind()

                grdSerial.Columns(3).Visible = False
                ModalPopupExtender2.Show()
            Else
                AddTrace("Non-Vehicle classification => " & a & " => still CO.")
                objDerived.GetRecords("DELETE dbo.Temp_ForSerial WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' ", CommandType.Text)

                Dim cb As CheckBox
                For i As Integer = 0 To grdInspection.Rows.Count - 1
                    cb = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        Dim Motor_InfoId As Integer = objDerived.GetValue("select Motor_InfoId from AMS.TbMotor_Info WHERE Received_ID = '" & rcvID & "' AND Item_ID='" & pInspection_detail.Rows(i)("Item_ID").ToString & "'", CommandType.Text)
                        AddTrace("Motor_InfoId => " & Motor_InfoId.ToString())

                        Dim POHdr_ID As Long = grdAIR.SelectedDataKey("POHdr_ID")
                        Dim AcptQty As Decimal = CType(CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox).Text, Decimal)
                        Dim Item_ID As Long = pInspection_detail.Rows(i)("Item_ID").ToString
                        Dim Item_Desc As String = pInspection_detail.Rows(i)("Item_Desc").ToString
                        AddTrace("spSave_Temp_ForSerial => POHdr_ID=" & POHdr_ID.ToString() & ", Item_ID=" & Item_ID.ToString() & ", AcptQty=" & AcptQty.ToString())

                        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
                        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
                        objDerived.cmd.Parameters.AddWithValue("@Item_Desc", Item_Desc)
                        objDerived.cmd.Parameters.AddWithValue("@AcptQty", AcptQty)
                        objDerived.cmd.Parameters.AddWithValue("@motor_id", Motor_InfoId)

                        objDerived.Execute("[AMS].[spSave_Temp_ForSerial]", CommandType.StoredProcedure, Nothing)
                    End If
                Next

                AddTrace("Binding data to grdSerial from sp_Acceptance_SerialNo_List.")
                pItemForSerial = objDerived.GetDataTable("EXEC [AMS].[sp_Acceptance_SerialNo_List] '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
                grdSerial.DataSource = pItemForSerial
                grdSerial.DataBind()

                grdSerial.Columns(3).Visible = False
                ModalPopupExtender1.Show()
            End If

            ' Re-check if there's a selected row (should be, if we got here)
            Dim newPOHdrID As Long = CLng(grdAIR.SelectedDataKey("POHdr_ID"))
            AddTrace("Capital Outlay path => newPOHdrID = " & newPOHdrID.ToString())
            Session("POHdr_ID") = newPOHdrID

            For x As Integer = 0 To grdInspection.Rows.Count - 1
                ' First check if the checkbox is checked
                Dim cbInspection As CheckBox = CType(grdInspection.Rows(x).Cells(0).FindControl("cbInspection"), CheckBox)
                If cbInspection Is Nothing OrElse Not cbInspection.Checked Then
                    AddTrace("Skipping row " & x & " - checkbox not checked")
                    Continue For
                End If

                ' Determine the correct Received_ID by matching both POHdr_ID and Item_ID
                Dim itemID As Long = 0
                If Not IsDBNull(pInspection_detail.Rows(x)("Item_ID")) Then
                    itemID = Convert.ToInt64(pInspection_detail.Rows(x)("Item_ID"))
                Else
                    AddTrace("Warning: Item_ID is NULL in pInspection_detail.Rows(" & x & ")")
                    Continue For ' Skip to next loop iteration
                End If

                ' Use the actual Received_ID tied to this row/item (from your data table)
                rcvID = Convert.ToInt64(pInspection_detail.Rows(x)("Received_ID"))
                AddTrace("Resolved rcvID (from row) for Item_ID=" & itemID.ToString() & ": " & rcvID)
                ' Look up per-item/per-receiving existence AFTER itemID/rcvID are known
                Dim checkAIR As Long = objDerived.GetValue(
                "SELECT TOP 1 AIRHdr_ID FROM AMS.AIR_Hdr WHERE Received_ID = " & rcvID & " AND POHdr_ID = " & poHdrIdVal,
                CommandType.Text)

                Dim checkStock As Long = objDerived.GetValue(
                "SELECT TOP 1 StockID FROM AMS.Stock WHERE Received_ID = " & rcvID & " AND Item_ID = " & itemID,
                CommandType.Text)



                Dim RcvDtl_ID As Long = objDerived.GetValue("SELECT Received_Dtl_ID FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = '" & rcvID & "' AND Item_ID = '" & pInspection_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
                AddTrace("rcvID: " & rcvID)
                AddTrace("Item_ID: " & pInspection_detail.Rows(x)("Item_ID"))

                ' Get current accepted quantity from database
                Dim result As Object = objDerived.GetValue("SELECT Qty_Accepting FROM AMS.Tb_Receiving_Dtl WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
                Dim Qty_AcceptedValue As Decimal = 0
                Dim calResult As Decimal = 0

                AddTrace("RcvDtl_ID: " & RcvDtl_ID)
                AddTrace("result: " & result)

                ' Parse the current accepted quantity
                If result IsNot DBNull.Value Then
                    If Decimal.TryParse(result.ToString(), Qty_AcceptedValue) Then
                        AddTrace("Successfully parsed Qty_AcceptedValue: " & Qty_AcceptedValue)
                    End If
                End If

                ' Get the new quantity from the grid's textbox
                Dim txtActQty As TextBox = CType(grdInspection.Rows(x).FindControl("txtActQty"), TextBox)
                Dim receivedQty As Decimal = 0

                AddTrace("Check Failed: receivedQty (" & receivedQty & ") > Qty_AcceptedValue (" & Qty_AcceptedValue & ") in row " & x)


                If txtActQty IsNot Nothing AndAlso Decimal.TryParse(txtActQty.Text, receivedQty) Then
                    AddTrace("receivedQty: " & receivedQty)
                    AddTrace("Qty_AcceptedValue: " & Qty_AcceptedValue)

                    ' Validate the quantity
                    If (receivedQty <= Qty_AcceptedValue) Then
                        calResult = Math.Abs(Qty_AcceptedValue - receivedQty)
                        AddTrace("calResult: " & calResult)

                        ' Update the quantity in database
                        Dim updateDtlSQL As String = "UPDATE AMS.Tb_Receiving_Dtl SET Qty_Accepting = " & calResult & " WHERE Received_Dtl_ID = " & RcvDtl_ID
                        objDerived.Execute(updateDtlSQL, CommandType.Text)
                        AddTrace("Updated Received_Dtl_ID " & RcvDtl_ID & " with Qty_Accepting = " & calResult)
                    Else
                        'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The quantity desired to return is more than existing quantity. Reminder: Reload to see existing quantity.")
                        'Exit Sub
                    End If
                Else
                    AddTrace("Warning: Could not parse quantity from txtActQty in row " & x)
                End If
            Next

        End If

        If rbStatus.SelectedItem.Value = 2 Then
            Session("IsComplete") = "X"
            Session("IsPartial") = " "
        Else
            Session("IsComplete") = " "
            Session("IsPartial") = "X"
        End If

        btnActPreview.Enabled = True
        AddTrace("btnSave_Click completed successfully.")

        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error: '" & ex.Message & "'")
        'End Try
    End Sub




    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddDepartment.SelectedItem.Text = "Select" Then
            ddFunction.Items.Clear()
            ddFunction.DataSource = Nothing
            ddFunction.DataBind()
            ddFunction.Items.Insert(0, "Select")

        Else
            ddFunction.Items.Clear()
            ddFunction.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
            ddFunction.DataTextField = ("Function_Desc")
            ddFunction.DataValueField = ("Function_ID")
            ddFunction.DataBind()
            ddFunction.Items.Insert(0, "Select")

        End If
    End Sub
    Protected Sub btnNA_Click(sender As Object, e As EventArgs) Handles btnNA.Click
        For i As Integer = 0 To grdSerial.Rows.Count - 1
            CType(grdSerial.Rows(i).FindControl("txtSerialNo"), TextBox).Text = "N/A"

        Next

        ModalPopupExtender1.Show()
    End Sub


    'Protected Sub btnActPreview_Click(sender As Object, e As EventArgs)
    '    Session("Page") = "IAR"

    '    Update the URL to point to the correct path
    '    Dim url As String = "/procurement/IAR_Reports.aspx?"  ' Change the path here
    '    Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
    '    ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    'End Sub

    Protected Sub btnActPreview_Click(sender As Object, e As EventArgs) Handles btnActPreview.Click
        Dim savedPOHdrID As String = ""
        If Session("POHdr_ID") IsNot Nothing Then
            savedPOHdrID = Session("POHdr_ID").ToString().Trim()
        End If

        Try
            ' Parse the date with proper format handling
            Dim acceptDate As DateTime
            If DateTime.TryParse(txtAcceptDate.Text, acceptDate) Then
                Session("AcceptedDate") = acceptDate.ToString("MMMM dd, yyyy")

                If rbStatus.SelectedItem.Value = 2 Then
                    Session("IsComplete") = "X"
                    Session("IsPartial") = " "
                    Session("IsInspected") = "X"
                Else
                    Session("IsComplete") = " "
                    Session("IsPartial") = "X"
                    Session("IsInspected") = "X"
                End If
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid acceptance date.")
                Return
            End If

            If Not String.IsNullOrEmpty(savedPOHdrID) AndAlso savedPOHdrID <> "0" Then
                ' Build the URL for the report page
                Dim url As String = "/Procurement/rpt_inspection_and_acceptance.aspx?POHdr_ID=" & savedPOHdrID
                url = url.Replace("'", "\'")
                Dim script As String = "window.open('" & url & "', '_blank');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No saved transaction available for preview.")
            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error processing date: " & ex.Message)
        End Try
    End Sub



    Protected Sub ddAcceptedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddAcceptedBy.SelectedIndexChanged

        Dim accpt As New DataTable
        accpt = objDerived.GetDataTable("Select * from HRMS.view_signatory where deptid = 7 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)

        If ddAcceptedBy.SelectedIndex > 0 Then
            Dim selectedRow As DataRow = accpt.Rows(ddAcceptedBy.SelectedIndex - 1) ' Get the selected row
            Session("AcceptingPerson") = ddAcceptedBy.SelectedItem.Text
            Session("AcceptingPosition") = selectedRow("position_desc").ToString()
        End If
    End Sub

    Protected Sub btnReturnItem_Click(sender As Object, e As EventArgs)
        ' Get stock/property ID based on allotment class
        Dim stck1 As Long = 0
        If AllotmentClass = 2 Then 'MOOE
            stck1 = objDerived.GetValue("SELECT StockID FROM AMS.Stock WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        ElseIf AllotmentClass = 3 Then 'Capital Outlay
            stck1 = objDerived.GetValue("SELECT Property_ID FROM AMS.Property WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        End If

        Dim origReceivedID As Long = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE TableName = 'NoticeOfDelivery' AND POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        AddTrace("origReceivedID: " & origReceivedID)

        Dim rcvID As Long = grdAIR.SelectedDataKey("Received_ID")
        Dim anyItemReturned As Boolean = False
        Dim dtCheck As DataTable = Nothing

        ' Process each selected item
        For i As Integer = 0 To grdInspection.Rows.Count - 1
            Dim cb As CheckBox = CType(grdInspection.Rows(i).FindControl("cbInspection"), CheckBox)
            If cb IsNot Nothing AndAlso cb.Checked AndAlso cb.Visible Then
                anyItemReturned = True
                Dim itemID As Long = pInspection_detail.Rows(i)("Item_ID")
                Dim txtQty As TextBox = CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox)
                Dim returnQty As Decimal = 0

                ' Parse return quantity
                If Decimal.TryParse(txtQty.Text, returnQty) AndAlso returnQty > 0 Then
                    ' Get current quantities from DB for current receiving record
                    Dim currentAccepting As Decimal = CDec(objDerived.GetValue("SELECT Qty_Accepting FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & rcvID & " AND Item_ID = " & itemID, CommandType.Text))
                    Dim currentInspecting As Decimal = CDec(objDerived.GetValue("SELECT Qty_Inspecting FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & rcvID & " AND Item_ID = " & itemID, CommandType.Text))

                    ' Get current inspecting quantity from original receiving record
                    Dim origInspecting As Decimal = 0
                    Dim origInspectingObj As Object = objDerived.GetValue("SELECT Qty_Inspecting FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & origReceivedID & " AND Item_ID = " & itemID, CommandType.Text)
                    If origInspectingObj IsNot Nothing AndAlso Not IsDBNull(origInspectingObj) Then
                        origInspecting = CDec(origInspectingObj)
                    End If

                    AddTrace("currentAccepting: " & currentAccepting)
                    AddTrace("currentInspecting: " & currentInspecting)
                    AddTrace("origInspecting: " & origInspecting)

                    ' Validate return quantity
                    If returnQty <= currentAccepting Then
                        ' Calculate new quantities for current receiving record
                        Dim newAccepting As Decimal = currentAccepting - returnQty
                        Dim newInspecting As Decimal = currentInspecting + returnQty

                        ' Calculate new quantity for original receiving record
                        Dim newOrigInspecting As Decimal = origInspecting + returnQty

                        AddTrace("rcvID: " & rcvID)
                        AddTrace("itemID: " & itemID)

                        ' Update quantities in current receiving record
                        Dim updateSQL As String = "UPDATE AMS.Tb_Receiving_Dtl SET " &
                        "Qty_Accepting = " & newAccepting & ", " &
                        "Qty_Inspecting = " & newInspecting & " " &
                        "WHERE Received_ID = " & rcvID & " AND Item_ID = " & itemID
                        objDerived.Execute(updateSQL, CommandType.Text)

                        ' === Check if all Qty_Accepting for the same Received_ID are 0 ===
                        Dim checkZeroAcceptingSQL As String = " SELECT COUNT(*) FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & rcvID & " AND ISNULL(Qty_Accepting, 0) > 0"
                        Dim nonZeroAcceptingCount As Integer = Convert.ToInt32(objDerived.GetValue(checkZeroAcceptingSQL, CommandType.Text))

                        If nonZeroAcceptingCount = 0 Then
                            ' Check if TableName = 'AMS.Tb_Receiving' for this rcvID before deleting
                            Dim tableNameCheck As String = CStr(objDerived.GetValue("SELECT TableName FROM AMS.Tb_Receiving WHERE Received_ID = " & rcvID, CommandType.Text))

                            If tableNameCheck = "AMS.Tb_Receiving" Then
                                ' Proceed to delete details and header
                                Dim deleteDtlSQL As String = "DELETE FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & rcvID
                                objDerived.Execute(deleteDtlSQL, CommandType.Text)
                                AddTrace("Deleted all Tb_Receiving_Dtl rows for Received_ID = " & rcvID & " (Qty_Accepting all 0 and TableName = 'AMS.Tb_Receiving')")

                                Dim deleteHdrSQL As String = "DELETE FROM AMS.Tb_Receiving WHERE Received_ID = " & rcvID
                                objDerived.Execute(deleteHdrSQL, CommandType.Text)
                                AddTrace("Deleted Tb_Receiving row for Received_ID = " & rcvID & " (TableName = 'AMS.Tb_Receiving')")
                            Else
                                AddTrace("Skipped deletion for Received_ID = " & rcvID & " (TableName is not 'AMS.Tb_Receiving', it is '" & tableNameCheck & "')")
                            End If
                        End If






                        ' Update inspecting quantity in original receiving record
                        Dim updateOrigSQL As String = "UPDATE AMS.Tb_Receiving_Dtl SET " &
                        "Qty_Inspecting = " & newOrigInspecting & " " &
                        "WHERE Received_ID = " & origReceivedID & " AND Item_ID = " & itemID
                        objDerived.Execute(updateOrigSQL, CommandType.Text)

                        ' Update status if no quantity left in acceptance
                        If newAccepting = 0 Then
                            objDerived.Execute("UPDATE AMS.Tb_Receiving_Dtl SET Status = 1 WHERE Received_ID = " & rcvID & " AND Item_ID = " & itemID, CommandType.Text)
                        End If
                    Else
                        ' Handle invalid quantity
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Return quantity exceeds accepted quantity for item " & (i + 1))
                        Exit Sub
                    End If
                End If
            End If
        Next

        ' Update receiving header status if all items returned
        If anyItemReturned Then
            dtCheck = objDerived.GetDataTable("EXEC [AMS].[sp_ReceivedItems_Acceptance] '" &
            grdAIR.SelectedDataKey("POHdr_ID") & "','" & stck1 & "','" &
            AllotmentClass & "', '" & rcvID & "'", CommandType.Text)

            If dtCheck.Rows.Count = 0 Then
                objDerived.Execute("UPDATE AMS.Tb_Receiving SET Status = 1 WHERE Received_ID = " & rcvID, CommandType.Text)
            End If

            ' Refresh data grid
            pInspection_detail = objDerived.GetDataTable("EXEC [AMS].[sp_Get_ReceivedItems] '" &
            grdAIR.SelectedDataKey("POHdr_ID") & "','" & rcvID & "', 2", CommandType.Text)
            grdInspection.DataSource = pInspection_detail
            grdInspection.DataBind()

            ' Clear selections and reset UI
            'ClearTextBoxes(Me)
            'btnReturnItem.Enabled = (pInspection_detail.Rows.Count > 0)
            LoadSearchBy()
            LoadrbALL() ' This will display all the POs without filtering when the page loads
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Items returned to inspection successfully.")
        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No items selected for return.")
        End If
    End Sub




    'Protected Sub btnReturnItem_Click(sender As Object, e As EventArgs)
    '    ' Get stock/property ID based on allotment class
    '    Dim stck1 As Long = 0
    '    If AllotmentClass = 2 Then 'MOOE
    '        stck1 = objDerived.GetValue("SELECT StockID FROM AMS.Stock WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
    '    ElseIf AllotmentClass = 3 Then 'Capital Outlay
    '        stck1 = objDerived.GetValue("SELECT Property_ID FROM AMS.Property WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
    '    End If

    '    Dim origReceivedID As Long = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE TableName = 'NoticeOfDelivery' AND  POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
    '    AddTrace("origReceivedID: " & origReceivedID)

    '    Dim rcvID As Long = grdAIR.SelectedDataKey("Received_ID")
    '    Dim anyItemReturned As Boolean = False
    '    Dim dtCheck As DataTable = Nothing

    '    ' Process each selected item
    '    For i As Integer = 0 To grdInspection.Rows.Count - 1
    '        Dim cb As CheckBox = CType(grdInspection.Rows(i).FindControl("cbInspection"), CheckBox)
    '        If cb IsNot Nothing AndAlso cb.Checked AndAlso cb.Visible Then
    '            anyItemReturned = True
    '            Dim itemID As Long = pInspection_detail.Rows(i)("Item_ID")
    '            Dim txtQty As TextBox = CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox)
    '            Dim returnQty As Decimal = 0

    '            ' Parse return quantity
    '            If Decimal.TryParse(txtQty.Text, returnQty) AndAlso returnQty > 0 Then
    '                ' Get current quantities from DB
    '                Dim currentAccepting As Decimal = CDec(objDerived.GetValue("SELECT Qty_Accepting FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & rcvID & " AND Item_ID = " & itemID, CommandType.Text))
    '                Dim currentInspecting As Decimal = CDec(objDerived.GetValue("SELECT Qty_Inspecting FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & rcvID & " AND Item_ID = " & itemID, CommandType.Text))

    '                AddTrace("currentAccepting: " & currentAccepting)
    '                AddTrace("currentInspecting: " & currentInspecting)
    '                ' Validate return quantity
    '                If returnQty <= currentAccepting Then
    '                    ' Calculate new quantities
    '                    Dim newAccepting As Decimal = currentAccepting - returnQty
    '                    Dim newInspecting As Decimal = currentInspecting + returnQty

    '                    AddTrace("rcvID: " & rcvID)
    '                    AddTrace("itemID: " & itemID)
    '                    ' Update quantities in DB
    '                    Dim updateSQL As String = "UPDATE AMS.Tb_Receiving_Dtl SET " &
    '                    "Qty_Accepting = " & newAccepting & ", " &
    '                    "Qty_Inspecting = " & newInspecting & " " &
    '                    "WHERE Received_ID = " & rcvID & " AND Item_ID = " & itemID
    '                    objDerived.Execute(updateSQL, CommandType.Text)

    '                    ' Update status if no quantity left in acceptance
    '                    If newAccepting = 0 Then
    '                        objDerived.Execute("UPDATE AMS.Tb_Receiving_Dtl SET Status = 1 WHERE Received_ID = " & rcvID & " AND Item_ID = " & itemID, CommandType.Text)
    '                    End If
    '                Else
    '                    ' Handle invalid quantity
    '                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Return quantity exceeds accepted quantity for item " & (i + 1))
    '                    Exit Sub
    '                End If
    '            End If
    '        End If
    '    Next

    '    ' Update receiving header status if all items returned
    '    If anyItemReturned Then
    '        dtCheck = objDerived.GetDataTable("EXEC [AMS].[sp_ReceivedItems_Acceptance] '" &
    '        grdAIR.SelectedDataKey("POHdr_ID") & "','" & stck1 & "','" &
    '        AllotmentClass & "', '" & rcvID & "'", CommandType.Text)

    '        If dtCheck.Rows.Count = 0 Then
    '            objDerived.Execute("UPDATE AMS.Tb_Receiving SET Status = 1 WHERE Received_ID = " & rcvID, CommandType.Text)
    '        End If

    '        ' Refresh data grid
    '        pInspection_detail = objDerived.GetDataTable("EXEC [AMS].[sp_Get_ReceivedItems] '" &
    '        grdAIR.SelectedDataKey("POHdr_ID") & "','" & rcvID & "', 2", CommandType.Text)
    '        grdInspection.DataSource = pInspection_detail
    '        grdInspection.DataBind()

    '        ' Clear selections and reset UI
    '        'ClearTextBoxes(Me)
    '        'btnReturnItem.Enabled = (pInspection_detail.Rows.Count > 0)
    '        LoadSearchBy()
    '        LoadrbALL() ' This will display all the POs without filtering when the page loads
    '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Items returned to inspection successfully.")
    '    Else
    '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No items selected for return.")
    '    End If
    'End Sub

End Class
