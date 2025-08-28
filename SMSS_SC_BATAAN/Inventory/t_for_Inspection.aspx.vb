Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Partial Class Inventory_t_for_Inspection
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule
    Dim strFinish As Integer = 0

    Private supplies As New t_supplies_hdr

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
    Private Sub Inventory_t_for_Inspection_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Set AllotmentClass to 0 to load all POs by default
            AllotmentClass = 0
            LoadSearchBy()
            LoadrbALL() ' This will display all the POs without filtering when the page loads
        End If
    End Sub

    Protected Sub LoadSearchBy()
        If ddSearch.SelectedItem.Value = "1" Then
            ' Show all records (ALL)
            Me.mvSearch.SetActiveView(Me.vwALL)
            rbALL.Visible = True
            AllotmentClass = 0 ' Set to 0 to show all records
            LoadrbALL()  ' This will load all POs without any filter
            Session("Page") = "ALL"
        ElseIf ddSearch.SelectedItem.Value = "2" Then
            ' Account Code search logic
            Me.mvSearch.SetActiveView(Me.vwAccount)
            ddAccount.DataSource = objDerived.GetDataTable("SELECT DISTINCT GA_ID, GA_Title FROM AMS.View_AccountList", CommandType.Text)
            ddAccount.DataTextField = "GA_Title"
            ddAccount.DataValueField = "GA_ID"
            ddAccount.DataBind()
            ddAccount.Items.Insert(0, "Select")
            Session("Page") = "AccountCode"
        ElseIf ddSearch.SelectedItem.Value = "3" Then
            ' PO Number search logic
            Me.mvSearch.SetActiveView(Me.vwPO)
            txtSearchPO.Visible = True
            btnSearchPO.Visible = True
            Session("Page") = "PO"
        ElseIf ddSearch.SelectedItem.Value = "4" Then
            ' Supplier search logic
            Me.mvSearch.SetActiveView(Me.vwSupp)
            ddSupplier.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
            ddSupplier.DataTextField = "SuppName"
            ddSupplier.DataValueField = "Supplier_Id"
            ddSupplier.DataBind()
            ddSupplier.Items.Insert(0, "Select")
            Session("Page") = "SUPPLIER"
        End If
    End Sub

    Protected Sub LoadrbALL()
        ' Fetch data from the stored procedure
        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List_Inspection]", CommandType.Text)

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

    'poostback
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try



            ' 1. Verify that a valid PO is selected.
            If grdAIR.SelectedDataKey Is Nothing OrElse grdAIR.SelectedDataKey("POHdr_ID") Is Nothing Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a valid PO to return.")
                Exit Sub
            End If


            Dim poHdrId As Long = CLng(grdAIR.SelectedDataKey("POHdr_ID"))
            AddTrace("btnReturn_Click triggered for POHdr_ID: " & poHdrId)


            ' Restriction Check: Prevent return if any Qty_Accepting > 0 for the PO
            Dim restrictSQL As String = "SELECT COUNT(*) FROM AMS.Tb_Receiving_Dtl d " &
                            "JOIN AMS.Tb_Receiving r ON d.Received_ID = r.Received_ID " &
                            "WHERE r.POHdr_ID = " & poHdrId & " AND ISNULL(d.Qty_Accepting, 0) > 0"
            Dim acceptingCount As Integer = Convert.ToInt32(objDerived.GetValue(restrictSQL, CommandType.Text))

            If acceptingCount > 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PO cannot be returned — accepted items found with the same PO number.")
                AddTrace("Return blocked: Qty_Accepting > 0 found for POHdr_ID " & poHdrId)
                Exit Sub
            End If



            ' 2. Retrieve all Received_IDs for the selected PO from AMS.Tb_Receiving.
            Dim dsReceived As DataSet = objDerived.GetRecords("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = " & poHdrId, CommandType.Text)
            Dim dtReceived As DataTable = dsReceived.Tables(0)

            If dtReceived Is Nothing OrElse dtReceived.Rows.Count = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No receiving transactions found for this PO.")
                Exit Sub
            End If

            ' 3. Loop through each Received_ID and delete its corresponding details and header
            For Each row As DataRow In dtReceived.Rows
                Dim rcvID As Long = CLng(row("Received_ID"))

                ' Delete detail rows
                Dim deleteDetailSql As String = "DELETE FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & rcvID
                objDerived.Execute(deleteDetailSql, CommandType.Text)
                AddTrace("Deleted all Tb_Receiving_Dtl rows for Received_ID: " & rcvID)

                ' Delete header
                Dim deleteHeaderSql As String = "DELETE FROM AMS.Tb_Receiving WHERE Received_ID = " & rcvID
                objDerived.Execute(deleteHeaderSql, CommandType.Text)
                AddTrace("Deleted Tb_Receiving row for Received_ID: " & rcvID)
            Next

            ' 4. Update IsNoticeForDelivery to NULL in PO_Hdr
            Dim resetNoticeSQL As String = "UPDATE AMS.PO_Hdr SET IsNoticeForDelivery = NULL WHERE POHdr_ID = " & poHdrId
            objDerived.Execute(resetNoticeSQL, CommandType.Text)
            AddTrace("Updated PO_Hdr.IsNoticeForDelivery to NULL for POHdr_ID: " & poHdrId)

            ' 5. Notify user and refresh UI
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved. PO and items returned.")
            LoadrbALL()

        Catch ex As Exception
            AddTrace("Error in btnReturn_Click: " & ex.Message)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error returning PO: " & ex.Message)
        End Try
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub txtMarketValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub ddSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadSearchBy()
    End Sub
    ' Modify btnSearchPO_Click to implement PO filtering logic as per the receiving page:
    Protected Sub btnSearchPO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Create a DataView for filtering
        Dim myview As DataView = pPurchase_Order.DefaultView

        ' Apply filter for PO Number if text is entered
        If Not String.IsNullOrEmpty(txtSearchPO.Text) Then
            myview.RowFilter = "PO_No LIKE '%" & replaceapostrophe(txtSearchPO.Text) & "%'"
        End If

        ' Bind filtered data to the GridView
        grdAIR.DataSource = myview
        grdAIR.DataBind()

        ' Ensure GridView has at least 5 rows
        If pPurchase_Order.Rows.Count < 5 Then
            pPurchase_Order.Merge(CreateTable1(5 - pPurchase_Order.Rows.Count))
        End If
        grdAIR.DataSource = myview
        grdAIR.DataBind()
        grdAIR.SelectedIndex = -1
    End Sub

    ' Modify ddSupplier_SelectedIndexChanged to implement supplier filtering logic:
    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Create a DataView for filtering
        Dim myview As DataView = pPurchase_Order.DefaultView

        ' Apply filter for Supplier if selected
        If ddSupplier.SelectedIndex > 0 Then
            myview.RowFilter = "SuppName LIKE '%" & replaceapostrophe(ddSupplier.SelectedItem.Text) & "%'"
        Else
            ' If no supplier is selected, reload all records
            LoadrbALL()
        End If

        ' Bind filtered data to the GridView
        grdAIR.DataSource = myview
        grdAIR.DataBind()
    End Sub

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

    Sub ClearTextBoxes(ParamArray textBoxes() As TextBox)
        For Each textBox As TextBox In textBoxes
            textBox.Text = String.Empty
        Next
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub grdAIR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If grdAIR.SelectedDataKey("POHdr_ID") = 0 Then
            ClearTextBoxes(txtOSDescription, txtOSBrandName, txtOSSize, txtOSColor, txtOSCategory, txtOSLength, txtOSWidth, txtOSHeight, txtOSWeight)
            grdInspection.DataSource = CreateTable3(5)
            grdInspection.DataBind()

        Else


            Dim Received_ID As Long = Convert.ToInt64(grdAIR.SelectedDataKey("Received_ID"))
            Dim existingInvoiceNo As String = objDerived.GetValue("SELECT TOP 1 InvoiceNo FROM AMS.Tb_Receiving WHERE Received_ID = '" & Received_ID & "'", CommandType.Text).ToString()

            ' Generate new invoice number only if the existing one is empty or "0"
            Dim invcNo As String
            If String.IsNullOrEmpty(existingInvoiceNo) OrElse existingInvoiceNo = "0" Then
                invcNo = objDerived.GetValue("EXEC [AMS].[sp_Generate_UniqueInvoiceNo]", CommandType.Text).ToString()
            Else
                invcNo = existingInvoiceNo
            End If

            txtSupplierName.Text = grdAIR.SelectedDataKey("SuppName")
            txtPoNumber.Text = grdAIR.SelectedDataKey("PO_No")
            txtPodate.Text = CType(grdAIR.SelectedDataKey("PO_Date"), Date).ToString("MM/dd/yyyy")
            txtInvoiceNumber.Text = invcNo ' This will always have either existing or new invoice number
            txtInvoiceDate.Text = Date.Today.ToString("MM/dd/yyyy")


            txtDate.Text = DateTime.Now.ToString("MM/dd/yyyy")
            txtDepartment.Text = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)

            Dim stck1 As Long = 0
            If AllotmentClass = 2 Then
                stck1 = objDerived.GetValue("SELECT StockID FROM AMS.Stock WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            ElseIf AllotmentClass = 3 Then
                stck1 = objDerived.GetValue("SELECT Property_ID FROM AMS.Property WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            End If

            Dim sqlInspectionDetail As String = "EXEC [AMS].[sp_ReceivedItems_Inspection] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & stck1 & "','" & AllotmentClass & "', '" & grdAIR.SelectedDataKey("Received_ID") & "'"
            AddTrace("SQL for pInspection_detail: " & sqlInspectionDetail)

            pInspection_detail = objDerived.GetDataTable(sqlInspectionDetail, CommandType.Text)

            'txtHiddenReceiveQty.Value = pInspection_detail.Rows.Count
            ' AddTrace("txtHiddenReceiveQty: " & txtHiddenReceiveQty.Value)

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

            'Dim ReceivedID As Integer = objDerived.GetValue("select ReceivedBY from AMS.Tb_Receiving where POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            'txtReceivedBy.Text = objDerived.GetValue("Select full_name from HRMS.view_signatory where deptid = 7 and division_key = 86 and Signatory_ID='" & ReceivedID & "'", CommandType.Text)
            ' Get the Signatory_ID (ReceivedBY) from Tb_Receiving
            Dim ReceivedID As Integer = objDerived.GetValue("SELECT ReceivedBY FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

            ' Populate the dropdown with possible signatories
            Dim dtSignatories As DataTable = objDerived.GetDataTable("SELECT Signatory_ID, full_name FROM HRMS.view_signatory WHERE deptid = 7 AND division_key = 86", CommandType.Text)

            If dtSignatories.Rows.Count > 0 Then
                ddReceivedBy.DataSource = dtSignatories
                ddReceivedBy.DataTextField = "full_name"
                ddReceivedBy.DataValueField = "Signatory_ID"
                ddReceivedBy.DataBind()

                ' Set the selected value to match the ReceivedID from the database
                If ddReceivedBy.Items.FindByValue(ReceivedID.ToString()) IsNot Nothing Then
                    ddReceivedBy.SelectedValue = ReceivedID.ToString()
                End If
            End If


            Dim ins As New DataTable
            ins = objDerived.GetDataTable("Select DISTINCT * from HRMS.view_signatory where isInspector = 1 ORDER BY full_name", CommandType.Text)
            ddInspection1.DataSource = ins
            ddInspection1.DataTextField = ("full_name")
            ddInspection1.DataValueField = ("empid")
            ddInspection1.DataBind()
            ddInspection1.Items.Insert(0, "Select")

            Dim ins2 As New DataTable
            ins2 = objDerived.GetDataTable("Select DISTINCT * from HRMS.view_signatory where isInspector = 1 ORDER BY full_name", CommandType.Text)
            ddInspection2.DataSource = ins
            ddInspection2.DataTextField = ("full_name")
            ddInspection2.DataValueField = ("empid")
            ddInspection2.DataBind()
            ddInspection2.Items.Insert(0, "Select")


        End If
        btnReturn.Enabled = True

    End Sub

    Protected Sub LoadMOOE()
        If grdAIR.SelectedDataKey("GA_ID") = 1427 Then
            '=-= OFFICE SUPPLIES
            Me.mvAccounts.SetActiveView(Me.vwOfficeSupplies)

        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1432 Or grdAIR.SelectedDataKey("GA_ID") = 1433 Then
            '=-= MEDICINES SUPPLIES AND MEDICAL SUPPLIES
            Me.mvAccounts.SetActiveView(Me.vwOtherSupplies)

        Else '=-= OTHER SUPPLIES / MEDICINES SUPPLIES AND MEDICAL SUPPLIES
            Me.mvAccounts.SetActiveView(Me.vwOtherSupplies)

        End If
    End Sub
    Protected Sub LoadPPE()
        If grdAIR.SelectedDataKey("GA_ID") = 1060 Or grdAIR.SelectedDataKey("GA_ID") = 1067 Then
            '=-= LAND
            Me.mvAccounts.SetActiveView(Me.vwLand)

        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1082 Or grdAIR.SelectedDataKey("GA_ID") = 1085 Then
            '=-= BUILDINGS  vwBuilding
            Me.mvAccounts.SetActiveView(Me.vwBuilding)

        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1118 Then
            '=-= FURNITURE AND FIXTURES
            Me.mvAccounts.SetActiveView(Me.vwEquipments)

        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1127 Then
            '=-= MACHINIRIES
            Me.mvAccounts.SetActiveView(Me.vwEquipments)

        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1166 Then
            '=-= TRANSPORTATION
            Me.mvAccounts.SetActiveView(Me.vwMotors)

        Else '=-= ALL EQUIPMENTS
            Me.mvAccounts.SetActiveView(Me.vwEquipments)

        End If
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
    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Get the "Select All" checkbox
        Dim chkSelectAll As CheckBox = CType(sender, CheckBox)

        ' Iterate through all rows in grdInspection
        For i As Integer = 0 To grdInspection.Rows.Count - 1 ' Fixed this line: previously used txtHiddenReceiveQty.Value which may be incorrect
            ' Get the row’s checkbox and quantity TextBox
            Dim row As GridViewRow = grdInspection.Rows(i)
            Dim chkItem As CheckBox = CType(row.FindControl("cbInspection"), CheckBox)
            Dim txtQty As TextBox = CType(row.FindControl("txtActQty"), TextBox)

            ' Only update if checkbox is visible (same condition used in cbInspection_CheckedChanged)
            If chkItem.Visible Then
                ' If "Select All" is checked, check all cbInspection and enable txtActQty and returnItemBtn
                If chkSelectAll.Checked Then
                    chkItem.Checked = True
                    chkItem.Enabled = True
                    txtQty.Enabled = True
                    returnItemBtn.Enabled = True
                Else
                    ' If "Select All" is unchecked, uncheck all and disable txtActQty
                    chkItem.Checked = False
                    txtQty.Enabled = False
                End If
            End If
        Next

        ' Enable or disable btnSave depending on selection
        btnSave.Enabled = chkSelectAll.Checked
    End Sub

    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' ===== NEW FUNCTIONALITY ADDED HERE =====
        Dim cb As CheckBox = CType(sender, CheckBox)
        Dim currentRow As GridViewRow = CType(cb.NamingContainer, GridViewRow)

        ' ===== END OF NEW FUNCTIONALITY =====

        ' ===== ORIGINAL CODE PRESERVED BELOW =====
        Dim cb1 As CheckBox
        Dim cb2 As CheckBox
        Dim x As Integer = 0

        Dim anyChecked As Boolean = False
        For i As Integer = 0 To grdInspection.Rows.Count - 1
            cb1 = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
            Dim txtActQty As TextBox = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("txtActQty"), TextBox)
            If cb1.Visible = True Then
                If cb1.Checked = True Then
                    x = 1
                    Dim RcvDate As Date = CType(CType(grdInspection.Rows(i).FindControl("lblRcvDate"), Label).Text, Date)

                    cb2 = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                    anyChecked = True

                    cb1.Enabled = True
                    cb2.Enabled = True

                    txtActQty.Enabled = True

                    ' === Added AddTrace to log the Item_ID of the checked row ===
                    Dim itemId As String = grdInspection.DataKeys(i)("Item_ID").ToString()
                    AddTrace("Checked cbInspection at row " & i & " with Item_ID: " & itemId)
                Else
                    txtActQty.Enabled = False
                End If
            End If
        Next
        returnItemBtn.Enabled = anyChecked

        If x = 0 Then
            For i As Integer = 0 To grdInspection.Rows.Count - 1
                cb2 = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                cb2.Enabled = True
            Next
            btnSave.Enabled = False
        Else
            If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                ' Original commented code preserved
            Else
                txtDepartment.Text = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                txtFunction.Text = objDerived.GetValue("SELECT Function_Desc FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "' AND Function_ID = '" & grdAIR.SelectedDataKey("Function_ID") & "'", CommandType.Text)
            End If
            btnSave.Enabled = True
        End If

        Dim AllotmentClass_ID As Long
        AllotmentClass_ID = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

        If AllotmentClass_ID = 2 Then
            Dim cbCheck As CheckBox
            Session("cb") = 0
            For i As Integer = 0 To grdInspection.Rows.Count - 1
                cbCheck = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                If cbCheck.Checked = True Then
                    Session("cb") = 1
                    Dim itemId As String = grdInspection.DataKeys(i)("Item_ID").ToString()
                    AddTrace("Checked cbInspection at row " & i & " with Item_ID: " & itemId)
                    Exit For
                End If
            Next

            Dim dt As New DataTable
            Dim cb1z As CheckBox
            For x1x As Integer = 0 To grdInspection.Rows.Count - 1
                cb1z = CType(Me.grdInspection.Rows(x1x).Cells(0).FindControl("cbInspection"), CheckBox)
                If cb1z.Checked = True Then
                    Dim a As String = pInspection_detail.Rows(x1x)("Item_ID")
                    dt = objDerived.GetDataTable("EXEC [AMS].[sp_Receipt_and_Inspection_Dtl] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & pInspection_detail.Rows(x1x)("Item_ID") & "'", CommandType.Text)
                    txtOSDescription.Text = dt.Rows(0).Item("Description").ToString
                    txtOSBrandName.Text = dt.Rows(0).Item("Brand").ToString
                    txtOSSize.Text = dt.Rows(0).Item("Size").ToString
                    txtOSColor.Text = dt.Rows(0).Item("Color").ToString
                    txtOSCategory.Text = dt.Rows(0).Item("Category").ToString
                End If
            Next

        ElseIf AllotmentClass_ID = 3 Then
            Dim dt As New DataTable
            Dim cb1x As CheckBox
            For xx1 As Integer = 0 To grdInspection.Rows.Count - 1
                cb1x = CType(Me.grdInspection.Rows(xx1).Cells(0).FindControl("cbInspection"), CheckBox)
                If cb1x.Checked = True Then
                    Dim a As String = pInspection_detail.Rows(xx1)("Item_ID")
                    dt = objDerived.GetDataTable("EXEC [AMS].[sp_Receipt_and_Inspection_Dtl] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & pInspection_detail.Rows(xx1)("Item_ID") & "'", CommandType.Text)

                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        If Not IsDBNull(dt.Rows(0)("Description")) Then
                            txtCO_MName.Text = dt.Rows(0)("Description").ToString
                            txtCO_Name.Text = dt.Rows(0)("Description").ToString
                            txtCO_Description.Text = dt.Rows(0)("Description").ToString
                        Else
                            txtCO_MName.Text = ""
                            txtCO_Name.Text = ""
                            txtCO_Description.Text = ""
                        End If
                    Else
                        ' Optionally handle when no data is returned
                        txtCO_MName.Text = ""
                        txtCO_Name.Text = ""
                        txtCO_Description.Text = ""
                        AddTrace("No data returned for Item_ID: " & pInspection_detail.Rows(xx1)("Item_ID"))
                    End If

                End If
            Next

            Dim cbRow As CheckBox
            Dim xc1 As Integer = 0
            Session("cb") = 0
            For ix As Integer = 0 To grdInspection.Rows.Count - 1
                If x = 0 Then
                    cbRow = CType(Me.grdInspection.Rows(ix).Cells(0).FindControl("cbInspection"), CheckBox)
                    If cbRow.Checked = True Then
                        xc1 = 1
                        Session("cb") = 1
                    ElseIf cbRow.Checked = False Then
                        cbRow.Enabled = True
                    End If
                Else
                    'For p As Integer = 0 To grdInspection.Rows.Count - 1
                    '    cbRow = CType(Me.grdInspection.Rows(p).Cells(0).FindControl("cbInspection"), CheckBox)
                    '    cbRow.Enabled = cbRow.Checked
                    'Next
                    Exit For
                End If
            Next
        End If
    End Sub


    Protected Sub txtActQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtActQty As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtActQty.NamingContainer, GridViewRow)
        Dim hdnCurrentQty As HiddenField = CType(gvr.FindControl("hdnCurrentQty"), HiddenField)

        AddTrace("txtActQty.Text: " & txtActQty.Text)
        AddTrace("hdnCurrentQty.Value: " & hdnCurrentQty.Value)

        Dim enteredQty As Decimal = 0
        Dim maxQty As Decimal = 0

        Decimal.TryParse(txtActQty.Text.Trim(), enteredQty)
        Decimal.TryParse(hdnCurrentQty.Value.Trim(), maxQty)

        If enteredQty > maxQty Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid quantity.")
            txtActQty.Text = maxQty.ToString("N0")
            Exit Sub
        End If

        If txtActQty.Text = "" Then
            txtActQty.Text = "0"
        End If

        txtActQty.Text = enteredQty.ToString("N0")
    End Sub



    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        'Try

        '-------------------Checking of ID and Invoice Number ----------------------------------------------
        Dim rcvID As Long = grdAIR.SelectedDataKey("Received_ID")
        Dim isInsertNewRow As Integer = 0
        Dim invoiceNoInput As String = replaceapostrophe(txtInvoiceNumber.Text.Trim())
        ' Truncate the invoice number to 50 characters if it's too long
        If invoiceNoInput.Length > 50 Then
            invoiceNoInput = invoiceNoInput.Substring(0, 50)
        End If

        Dim currentInvoiceObj As Object = objDerived.GetValue("SELECT InvoiceNo FROM AMS.Tb_Receiving WHERE Received_ID = " & rcvID, CommandType.Text)
        Dim currentInvoiceNo As String = ""
        If Not IsDBNull(currentInvoiceObj) Then
            currentInvoiceNo = currentInvoiceObj.ToString().Trim()
        End If


        If txtInvoiceNumber.Text <> "" Then

            ' Step 1: Get current InvoiceNo from the record

            AddTrace("currentInvoiceNo: " & currentInvoiceNo)
            AddTrace("invoiceNoInput: " & invoiceNoInput)
            AddTrace("currentInvoiceNo: " & currentInvoiceNo)

            ' Step 2: Only clone if current InvoiceNo is NOT NULL and was changed
            If currentInvoiceNo <> "" AndAlso invoiceNoInput <> currentInvoiceNo Then

                ' Step 3: Ensure new InvoiceNo is not already used elsewhere
                Dim invExist As Integer = objDerived.GetValue("SELECT COUNT(*) FROM AMS.Tb_Receiving WHERE InvoiceNo = '" & invoiceNoInput & "'", CommandType.Text)


                If invExist = 0 Then
                    isInsertNewRow = 1

                    DeleteReceivingIfNoDetails()
                Else
                    isInsertNewRow = 0
                End If

            Else
                isInsertNewRow = 0
            End If
        End If


        '-------------------Start ----------------------------------------------
        strFinish = 0

        If ddInspection1.SelectedItem.Value = "Select" And ddInspection2.SelectedItem.Value = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select one or two Inspector.")
            Exit Sub
        End If

        Dim cb As CheckBox
        Dim cb1 As CheckBox
        Session("cb") = 0

        For i As Integer = 0 To grdInspection.Rows.Count - 1
            cb = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
            If cb.Checked = True Then
                Session("cb") = 1
                Exit For
            End If
        Next
        If Session("cb") = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No selected item.")
            Exit Sub
        End If

        Dim AllotmentClass_ID As Long
        AllotmentClass_ID = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

        '=-= SAVE ITEM DETAILS
        Dim cnt As Integer = 0
        For x As Integer = 0 To grdInspection.Rows.Count - 1
            cb = CType(Me.grdInspection.Rows(x).Cells(0).FindControl("cbInspection"), CheckBox)
            If cb.Checked = True Then
                cnt = cnt + 1
            End If
        Next

        If cnt > 0 Then
            If AllotmentClass_ID = 2 Then '=-= MOOE ITEMS
                If txtMOOE_MftgDate.Text = "" Then
                    txtMOOE_MftgDate.Text = "1/1/1900"
                End If
                If txtMOOE_ExpiryDate.Text = "" Then
                    txtMOOE_ExpiryDate.Text = "1/1/1900"
                End If
                If txtMOOE_AlertDate.Text = "" Then
                    txtMOOE_AlertDate.Text = "1/1/1900"
                End If


                Dim invoiceNum As String = objDerived.GetValue("SELECT InvoiceNo FROM AMS.Tb_Receiving WHERE Received_ID = '" & rcvID & "'", CommandType.Text)

                'reset flag for if displaying to report or not:
                Dim resetIsDisplayReport = "update AMS.Tb_Receiving_Dtl set AMS.Tb_Receiving_Dtl.IsDisplayReport = 0 where AMS.Tb_Receiving_Dtl.Received_ID = '" & rcvID & "' "
                objDerived.Execute(resetIsDisplayReport, CommandType.Text)

                Dim rcv_Date As String = objDerived.GetValue("SELECT Received_Date FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

                Session("Received_ID") = rcvID

                For MOOE As Integer = 0 To grdInspection.Rows.Count - 1
                    cb = CType(Me.grdInspection.Rows(MOOE).Cells(0).FindControl("cbInspection"), CheckBox)
                    Dim txtQty As TextBox = CType(grdInspection.Rows(MOOE).FindControl("txtActQty"), TextBox)

                    If cb.Checked = True Then
                        strFinish += 1

                        ' Ensure the quantity value is captured safely
                        Dim receivedQty As Decimal
                        If Not Decimal.TryParse(txtQty.Text, receivedQty) Then
                            receivedQty = 0 ' Default to 0 if parsing fails
                        End If

                        ' Check if record exists for update
                        Dim RcvDtl_ID As Long = objDerived.GetValue("SELECT Received_Dtl_ID FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = '" & rcvID & "' AND Item_ID = '" & pInspection_detail.Rows(MOOE)("Item_ID") & "'", CommandType.Text)


                        If RcvDtl_ID = 0 Then
                            ' Insert new record if not existing
                            objDerived.GetRecords("INSERT INTO AMS.Tb_Receiving_Dtl (Received_ID, Item_ID, Qty_Received, Status) VALUES ('" & rcvID & "', '" & pInspection_detail.Rows(MOOE)("Item_ID") & "', '" & receivedQty & "', 1)", CommandType.Text)
                        Else

                            'parse txtActQty
                            Dim receivedQtyTextValue As Decimal

                            If Not Decimal.TryParse(txtQty.Text, receivedQtyTextValue) Then
                                receivedQtyTextValue = 0 ' Default to 0 if parsing fails
                            End If

                            Dim calResult As Decimal
                            Dim calResultReceived As Decimal

                            Dim result As Object = objDerived.GetValue("SELECT AMS.Tb_Receiving_Dtl.Qty_Accepting FROM AMS.Tb_Receiving_Dtl WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
                            Dim Qty_AcceptedValue As Decimal

                            If result IsNot DBNull.Value Then
                                ' Try parsing the result as Decimal
                                If Decimal.TryParse(result.ToString(), Qty_AcceptedValue) Then
                                End If
                            End If

                            Dim result2 As Object = objDerived.GetValue("select AMS.Tb_Receiving_Dtl.Qty_Inspecting from AMS.Tb_Receiving_Dtl  WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
                            Dim Qty_InspectedValue As Decimal

                            If result2 IsNot DBNull.Value Then
                                ' Try parsing the result as Decimal
                                If Decimal.TryParse(result2.ToString(), Qty_InspectedValue) Then
                                End If
                            End If


                            If (receivedQtyTextValue <= Qty_InspectedValue) Then
                                calResult = Qty_AcceptedValue + receivedQtyTextValue
                                calResultReceived = Math.Abs(Qty_InspectedValue - receivedQtyTextValue)
                            Else
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The quantity desired to return is more that existing quantity, Reminder: Reload to see existing quantity.")

                                Exit Sub
                            End If

                            'UPDATE QTY_Accepted VALUE
                            Dim updateDtlSQL As String = "UPDATE AMS.Tb_Receiving_Dtl SET Qty_Accepting = '" & calResult & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'"
                            objDerived.Execute(updateDtlSQL, CommandType.Text)

                            'UPDATE QTY_Inspected VALUE
                            Dim updateDtlReceived As String = "UPDATE AMS.Tb_Receiving_Dtl SET Qty_Inspecting = '" & calResultReceived & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'"
                            objDerived.Execute(updateDtlReceived, CommandType.Text)

                            'for report
                            Dim updateItemReportDisplay = "update AMS.Tb_Receiving_Dtl set AMS.Tb_Receiving_Dtl.IsDisplayReport = 1 where AMS.Tb_Receiving_Dtl.Received_Dtl_ID = '" & RcvDtl_ID & "' "
                            objDerived.Execute(updateItemReportDisplay, CommandType.Text)

                            'for report
                            Dim updateTempQuantity As String = "update AMS.Tb_Receiving_Dtl set AMS.Tb_Receiving_Dtl.tempReportQuantity = '" & receivedQtyTextValue & "' where AMS.Tb_Receiving_Dtl.Received_Dtl_ID = '" & RcvDtl_ID & "' "
                            objDerived.Execute(updateTempQuantity, CommandType.Text)


                            Dim Re_Qty_InspectedValue As Decimal = objDerived.GetValue("select AMS.Tb_Receiving_Dtl.Qty_Inspecting from AMS.Tb_Receiving_Dtl  WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
                            'ONLY PASS TO Acceptance WHEN NO QTY IS Received, should be inspected (NOT DISPLAY)
                            If Re_Qty_InspectedValue = 0 Then
                                Dim updateDtlStatus As String = "UPDATE AMS.Tb_Receiving_Dtl SET Status = 2  WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'"
                            End If

                        End If

                        If grdAIR.SelectedDataKey("GA_ID") = 1427 Then '=== grdAIR.SelectedDataKey("GA_ID") = 788 Then
                            '=-= OFFICE SUPPLIES 
                            With OfficeSup
                                .StockID = 0
                                .AIRDtl_ID = 0
                                .ItemId = pInspection_detail.Rows(MOOE)("Item_ID")
                                .Description = txtOSDescription.Text
                                .BrandName = txtOSBrandName.Text
                                .SupplierId = grdAIR.SelectedDataKey("Supplier_Id")
                                .Size = txtOSSize.Text
                                .Color = txtOSColor.Text
                                .Category = txtOSCategory.Text
                                .Length = txtOSLength.Text
                                .Width = txtOSWidth.Text
                                .Height = txtOSHeight.Text
                                .Weight = txtOSWeight.Text
                                .DepreciatedRate = 0

                                .DepreciatedValue = 0

                                .Status = "Received"
                                .Received_ID = rcvID
                                .Componentof = ""
                            End With
                            'here fix
                            Dim Supp_ID As Long = OfficeSup.save

                        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1432 Or grdAIR.SelectedDataKey("GA_ID") = 1433 Then '=== grdAIR.SelectedDataKey("GA_ID") = 792 Or grdAIR.SelectedDataKey("GA_ID") = 793 Then
                            '=-= MEDICINES SUPPLIES AND MEDICAL SUPPLIES
                            With MedInfo
                                .StockId = 0
                                .AIRDtl_ID = 0
                                .Item_ID = pInspection_detail.Rows(MOOE)("Item_ID")
                                .DeliveryDate = rcv_Date
                                .Description = txtMOOE_Description.Text
                                .DrugName = txtMOOE_Description.Text
                                .BrandName = txtMOOE_Brand.Text
                                .SupplierId = grdAIR.SelectedDataKey("Supplier_Id")
                                .Dose = txtDose.Text
                                .Location = ""
                                .Status = "Received"
                                .Received_ID = rcvID
                                .Depreciatedrate = txtMOOE_DepRate.Text
                                If txtMOOE_DepValue.Text = "" Then
                                    .Depreciatedvalue = 0
                                Else
                                    .Depreciatedvalue = txtMOOE_DepValue.Text
                                End If

                            End With

                            Dim MedID As Long = MedInfo.save

                            With MedDtl
                                .MedicineID = MedID
                                .StockId = 0
                                .Item_ID = pInspection_detail.Rows(MOOE)("Item_ID")
                                .Form = txtMOOE_Form.Text
                                .OTCRx = txtMOOE_OTCRx.Text
                                .Batch = txtMOOE_Batch.Text
                                .Lot = txtMOOE_Lot.Text
                                .Mftgdate = txtMOOE_MftgDate.Text
                                .EpiryDate = txtMOOE_ExpiryDate.Text
                                .Alert = txtMOOE_AlertDate.Text
                                .save()
                            End With


                        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1441 Then '=== grdAIR.SelectedDataKey("GA_ID") = 799 Then
                            '=-= WATER SUPPLIES
                            With Water
                                .StockId = 0
                                .AIRDtl_ID = 0
                                .Item_ID = pInspection_detail.Rows(MOOE)("Item_ID")
                                .DeliveryDate = rcv_Date
                                .Form = txtMOOE_Form.Text
                                .OTCRx = txtMOOE_OTCRx.Text
                                .Batch = txtMOOE_Batch.Text
                                .Lot = txtMOOE_Lot.Text
                                .Mftgdate = txtMOOE_MftgDate.Text
                                .EpiryDate = txtMOOE_ExpiryDate.Text
                                .Alert = txtMOOE_AlertDate.Text
                                .ItemDesc = txtMOOE_Description.Text
                                .BrandName = txtMOOE_Brand.Text
                                .Supplier_Id = grdAIR.SelectedDataKey("Supplier_Id")
                                .Storage = ""
                                .Depreciationrate = txtMOOE_DepRate.Text
                                If txtMOOE_DepValue.Text = "" Then
                                    .Depreciationvalue = 0
                                Else
                                    .Depreciationvalue = txtMOOE_DepValue.Text
                                End If

                                .Status = "Received"
                                .Received_ID = rcvID
                            End With

                            Dim WaterID As Long = Water.save

                        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1430 Then '=== grdAIR.SelectedDataKey("GA_ID") = 791 Then
                            '=-= FOOD SUPPLIES
                            With Food
                                .StockId = 0
                                .AIRDtl_ID = 0
                                .Item_ID = pInspection_detail.Rows(MOOE)("Item_ID")
                                .DeliveryDate = rcv_Date
                                .Form = txtMOOE_Form.Text
                                .OTCRx = txtMOOE_OTCRx.Text
                                .Batch = txtMOOE_Batch.Text
                                .Lot = txtMOOE_Lot.Text
                                .Mftgdate = txtMOOE_MftgDate.Text
                                .EpiryDate = txtMOOE_ExpiryDate.Text
                                .Alert = txtMOOE_AlertDate.Text
                                .ItemDesc = txtMOOE_Description.Text
                                .BrandName = txtMOOE_Brand.Text
                                .Supplier_Id = grdAIR.SelectedDataKey("Supplier_Id")
                                .Storage = ""
                                .Depreciationrate = txtMOOE_DepRate.Text
                                If txtMOOE_DepValue.Text = "" Then
                                    .Depreciationvalue = 0
                                Else
                                    .Depreciationvalue = txtMOOE_DepValue.Text
                                End If

                                .Status = "Received"
                                .Received_ID = rcvID
                            End With

                            Dim FoodID As Long = Food.save

                        Else '=-= OTHER SUPPLIES 
                            With NonFood
                                .StockId = 0
                                .AIRDtl_ID = 0
                                .Item_ID = pInspection_detail.Rows(MOOE)("Item_ID")
                                .DeliveryDate = rcv_Date
                                .Form = txtMOOE_Form.Text
                                .OTCRx = txtMOOE_OTCRx.Text
                                .Batch = txtMOOE_Batch.Text
                                .Lot = txtMOOE_Lot.Text
                                .Mftgdate = txtMOOE_MftgDate.Text
                                .EpiryDate = txtMOOE_ExpiryDate.Text
                                .Alert = txtMOOE_AlertDate.Text
                                .ItemDesc = txtMOOE_Description.Text
                                .BrandName = txtMOOE_Brand.Text
                                .Supplier_Id = grdAIR.SelectedDataKey("Supplier_Id")
                                .Storage = ""
                                .Depreciationrate = txtMOOE_DepRate.Text
                                If txtMOOE_DepValue.Text = "" Then
                                    .Depreciationvalue = 0
                                Else
                                    .Depreciationvalue = txtMOOE_DepValue.Text
                                End If

                                .Status = "Received"
                                .Received_ID = rcvID
                            End With

                            Dim NonFoodID As Long = NonFood.save

                        End If
                    End If


                Next

                If ddInspection1.SelectedItem.Value = "Select" Then
                    objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InspectedBy = '" & 0 & "' ,InspectedBy3 = 0 WHERE Received_ID = '" & rcvID & "'", CommandType.Text)
                Else
                    objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InspectedBy = '" & ddInspection1.SelectedItem.Value & "' ,InspectedBy3 = 0 WHERE Received_ID = '" & rcvID & "'", CommandType.Text)
                End If

                If ddInspection2.SelectedItem.Value = "Select" Then
                    objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InspectedBy2 = '" & 0 & "' ,InspectedBy3 = 0 WHERE Received_ID = '" & rcvID & "'", CommandType.Text)
                Else
                    objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InspectedBy2 = '" & ddInspection2.SelectedItem.Value & "' ,InspectedBy3 = 0 WHERE Received_ID = '" & rcvID & "'", CommandType.Text)
                End If


                'objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InspectedBy = '" & ddInspection1.SelectedItem.Value & "',InspectedBy2 = '" & ddInspection2.SelectedItem.Value & "' ,InspectedBy3 = 0 WHERE Received_ID = '" & rcvID & "'", CommandType.Text)

                objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET inspection_date='" & txtDate.Text & "' WHERE Received_ID = '" & rcvID & "'", CommandType.Text)

                ''here 12355


                Dim stck1 As Long = 0
                'For allotment class 2
                stck1 = objDerived.GetValue("SELECT StockID FROM AMS.Stock WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)


                Dim poHdrId As String = grdAIR.SelectedDataKey("POHdr_ID").ToString()
                Dim receivedId As String = grdAIR.SelectedDataKey("Received_ID").ToString()

                AddTrace("sp_ReceivedItems_Inspection - POHdr_ID: " & poHdrId)
                AddTrace("sp_ReceivedItems_Inspection - Stock: " & stck1)
                AddTrace("sp_ReceivedItems_Inspection - AllotmentClass: " & AllotmentClass)
                AddTrace("sp_ReceivedItems_Inspection - Received_ID: " & receivedId)

                Dim dt2 As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_ReceivedItems_Inspection] '" & poHdrId & "','" & stck1 & "','" & AllotmentClass & "', '" & receivedId & "'  ", CommandType.Text)

                If dt2 IsNot Nothing AndAlso dt2.Rows.Count = 0 Then
                    objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET Status = 2 WHERE Received_ID = '" & rcvID & "'", CommandType.Text)
                End If


                ' Retrieve the newly saved POHdr_ID. (This example uses MAX; adjust as needed.)
                Dim newPOHdrID As Long = CLng(grdAIR.SelectedDataKey("POHdr_ID"))
                Session("POHdr_ID") = newPOHdrID
                btnPreview.Enabled = True


            ElseIf AllotmentClass_ID = 3 Then
                ' Dim rcvID As Long = grdAIR.SelectedDataKey("Received_ID")

                Dim rcv_Date As String = objDerived.GetValue("SELECT Received_Date FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

                Session("Received_ID") = rcvID

                Dim updateQuery As String = "UPDATE AMS.Tb_Receiving SET "
                Dim conditions As New List(Of String)()

                If ddInspection1.SelectedIndex > 0 Then
                    conditions.Add("InspectedBy = '" & ddInspection1.SelectedItem.Value & "'")
                End If
                If ddInspection2.SelectedIndex > 0 Then
                    conditions.Add("InspectedBy2 = '" & ddInspection2.SelectedItem.Value & "'")
                End If
                If conditions.Count > 0 Then
                    updateQuery &= String.Join(", ", conditions) & " WHERE Received_ID = '" & rcvID & "'"
                    objDerived.GetRecords(updateQuery, CommandType.Text)
                End If

                '----------------SAVING AIR

                For CO As Integer = 0 To grdInspection.Rows.Count - 1
                    cb = CType(Me.grdInspection.Rows(CO).Cells(0).FindControl("cbInspection"), CheckBox)

                    If cb.Checked = True Then
                        Dim AcptQty As Decimal = CType(CType(grdInspection.Rows(CO).FindControl("txtActQty"), TextBox).Text, Decimal)

                        strFinish += 1
                        Dim Lction As String = ""
                        Dim MrketValue As Decimal = 0
                        Dim Cndtion As String = ""

                        Dim a As Integer = pInspection_detail.Rows(CO)("Item_ID")

                        Dim RcvDtl_ID As Long = objDerived.GetValue("SELECT Received_Dtl_ID FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = '" & rcvID & "' AND Item_ID = '" & a & "'", CommandType.Text)

                        Dim QtyTextValue As Decimal

                        If Not Decimal.TryParse(CType(grdInspection.Rows(CO).FindControl("txtActQty"), TextBox).Text, QtyTextValue) Then
                            QtyTextValue = 0 ' Default to 0 if parsing fails
                        End If


                        Dim calResultAccepting As Decimal
                        Dim calResultInspecting As Decimal

                        'save Inspection > Acceptance
                        Dim result As Object = objDerived.GetValue("select AMS.Tb_Receiving_Dtl.Qty_Inspecting from AMS.Tb_Receiving_Dtl  WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
                        Dim Qty_InspectingValue As Decimal

                        If result IsNot DBNull.Value Then
                            ' Try parsing the result as Decimal
                            If Decimal.TryParse(result.ToString(), Qty_InspectingValue) Then
                            End If
                        End If


                        Dim result2 As Object = objDerived.GetValue("select AMS.Tb_Receiving_Dtl.Qty_Accepting from AMS.Tb_Receiving_Dtl  WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
                        Dim Qty_AcceptingValue As Decimal

                        If result2 IsNot DBNull.Value Then
                            ' Try parsing the result as Decimal
                            If Decimal.TryParse(result2.ToString(), Qty_AcceptingValue) Then
                            End If
                        End If

                        If (QtyTextValue <= Qty_InspectingValue) Then
                            calResultAccepting = Qty_AcceptingValue + QtyTextValue
                            calResultInspecting = Math.Abs(Qty_InspectingValue - QtyTextValue)
                        Else
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The quantity desired to return is more that existing quantity, Reminder: Reload to see existing quantity.")

                            Exit Sub
                        End If

                        'UPDATE QTY_INSPECTED VALUE
                        Dim updateDtlSQL As String = "UPDATE AMS.Tb_Receiving_Dtl SET Qty_Inspecting = '" & calResultInspecting & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'"
                        objDerived.Execute(updateDtlSQL, CommandType.Text)

                        'UPDATE QTY_RECEIVE VALUE
                        Dim updateDtlReceived As String = "UPDATE AMS.Tb_Receiving_Dtl SET Qty_Accepting = '" & calResultAccepting & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'"
                        objDerived.Execute(updateDtlReceived, CommandType.Text)

                        'for report
                        Dim updateItemReportDisplay = "update AMS.Tb_Receiving_Dtl set AMS.Tb_Receiving_Dtl.IsDisplayReport = 1 where AMS.Tb_Receiving_Dtl.Received_Dtl_ID = '" & RcvDtl_ID & "' "
                        objDerived.Execute(updateItemReportDisplay, CommandType.Text)

                        'for report
                        Dim updateTempQuantity As String = "update AMS.Tb_Receiving_Dtl set AMS.Tb_Receiving_Dtl.tempReportQuantity = '" & QtyTextValue & "' where AMS.Tb_Receiving_Dtl.Received_Dtl_ID = '" & RcvDtl_ID & "' "
                        objDerived.Execute(updateTempQuantity, CommandType.Text)

                        Dim Re_Qty_ReceivedValue As Decimal = objDerived.GetValue("select AMS.Tb_Receiving_Dtl.Qty_Receiving from AMS.Tb_Receiving_Dtl  WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
                        'ONLY PASS TO Acceptance WHEN NO QTY IS Received, should be inspected (NOT DISPLAY)
                        If Re_Qty_ReceivedValue = 0 Then
                            Dim updateDtlStatus As String = "UPDATE AMS.Tb_Receiving_Dtl SET Status = 2  WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'"
                        End If


                        If grdAIR.SelectedDataKey("GA_ID") = 1060 Or grdAIR.SelectedDataKey("GA_ID") = 1062 Or grdAIR.SelectedDataKey("GA_ID") = 1067 Then '=== grdAIR.SelectedDataKey("GA_ID") = 520 Or grdAIR.SelectedDataKey("GA_ID") = 521 Then
                            '=-= LAND
                            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Not Available at this Time, Contanct Administrator.")
                            With LandDtl
                                '.LandId = LandId
                                .LguCode = txtLandlgucode.Text
                                .SectionNo = txtLandSectionno.Text
                                .PIN = txtLandPIN.Text
                                .TDN = txtLandTdn.Text
                                .DistrictCode = txtLanddistrictcode.Text
                                .ParcelNo = txtLandParcelno.Text
                                .ARP = txtLandARP.Text
                                .CityMunCode = txtLandcitymunicipality1.Text
                                .SeriesNo = txtLandSeriesno.Text
                                .RevYear = txtLandrevyear.Text
                                .BarangayCode = txtLandbrgycode.Text
                                .RPTIN = txtLandRPTIN.Text
                                .DepreciationRate = txtLandDepriciationRate.Text
                                .DepreciationValue = txtLandDepreciatedValue.Text
                                .LotNo = txtLandlocationLot.Text
                                .BlkNo = txtLandlocationblkno.Text
                                .StreetName = txtLandlocationstreetname.Text
                                .Subdivision = txtLandlocationsubdivisionvillage.Text
                                .PhaseNo = txtLandlocationphaseno.Text
                                .Purok = txtLandlocationpurok.Text
                                .Sitio = txtLandlocationsitio.Text
                                .Barangay = txtLandbarangay.Text
                                .District = txtLandDistrict.Text
                                .CityMunicipal = txtLandCitymunicipality.Text
                                .Province = txtLandprovince.Text
                                .Region = txtLandRegion.Text
                                .ZipCode = txtLandzipcode.Text
                                .Classification = txtLandClassification.Text
                                .SubClass = txtLandSubClass.Text
                                .LandUse = txtLandUse.Text
                                .Area = txtLandArea.Text
                                .AVAmountWords = txtLandAssessedAmount.Text
                                .MVAmountWords = txtLandMarketAmount.Text
                                .AssessmentLevel = dpLandAssessmentLvl.SelectedValue
                                .Status_1 = txtLandStatus1.Text
                                .Status_2 = txtLandStatus2.Text
                                .AssessedValue = txtLandAssessedValue.Text
                                .MarketValue = txtLandMarketValue.Text
                                .UnitValue = txtLandUnitValue.Text
                                .Taxable = ddwnLandTaxable.SelectedItem.Text

                                If txtLandAssessedDate.Text = "" Then
                                    .AssessedDate = "01/01/1900"
                                Else
                                    .AssessedDate = txtLandAssessedDate.Text
                                End If

                                If txtLandMarketDate.Text = "" Then
                                    .MarketDate = "01/01/1900"
                                Else
                                    .MarketDate = txtLandMarketDate.Text
                                End If

                                If txtLandUnitDate.Text = "" Then
                                    .UnitDate = "01/01/1900"
                                Else
                                    .UnitDate = txtLandUnitDate.Text
                                End If
                                .Received_ID = rcvID
                                .save()
                            End With

                        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1082 Or grdAIR.SelectedDataKey("GA_ID") = 1085 Then '=== grdAIR.SelectedDataKey("GA_ID") = 525 Or grdAIR.SelectedDataKey("GA_ID") = 526 Then
                            '=-= BUILDINGS
                            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Not Available at this Time, Contanct Administrator.")
                            With BldgInfo
                                '.BuildingId = BuildingId
                                .BuildingControlNo = txtbuildingcontolno.Text
                                .BuildingCode = txtbuildingcode.Text
                                .BuildingName = txtbuildingname.Text
                                .Address = txtbuildingaddress.Text
                                .PostalCode = txtbuildingpostalcode.Text

                                If txtbuildingdepreciationrate.Text = "" Then
                                    .BuildingDepreciationRate = "0.00"
                                Else
                                    .BuildingDepreciationRate = txtbuildingdepreciationrate.Text
                                End If
                                .BuildingUse = txtbuildinguse.Text
                                .BuildingOccupancy = txtbuildingoccupancy.Text
                                .NumberFloors = txtbuildingnumberoffloors.Text
                                .AvgAreaFloor = txtbuildingavgareaperfloor.Text
                                .CostPerArea = txtbuildingcostperarea.Text
                                '.Status_AIR = ""

                                If txtbuildingdepreciationvalue.Text = "" Then
                                    .BuildingDepreciationValue = "0.00"
                                Else
                                    .BuildingDepreciationValue = txtbuildingdepreciationvalue.Text
                                End If
                                .Received_ID = rcvID
                                .save()

                            End With


                        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1118 Then '=== grdAIR.SelectedDataKey("GA_ID") = 534 Then
                            '=-= FURNITURE AND FIXTURES
                            With FurnitureInfo
                                .AIRDtl_ID = 0
                                .IsAccepted = False
                                .Property_Dtl_ID = 0
                                .SerialNo = "-"
                                .Name = txtCO_Name.Text
                                .Description = txtCO_Description.Text
                                .Dimension = txtCO_Dimension.Text
                                .AreaCapacity = txtCO_AreaCap.Text
                                .Model = txtCO_Model.Text
                                .Warranty = txtWarranty.Text
                                .Specification = txtCO_Specs.Text
                                .DepreciationRate = txtCO_DepRate.Text
                                If txtCO_DepValue.Text = "" Then
                                    .DepreciationValue = 0
                                Else
                                    .DepreciationValue = txtCO_DepValue.Text
                                End If
                                .Received_ID = rcvID
                            End With

                            Dim FurniID As Long = FurnitureInfo.save
                            objDerived.GetRecords("UPDATE AMS.TbFurniture_Info SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "' WHERE FurnitureInfoId = '" & FurniID & "'", CommandType.Text)

                            With FurnitureDtl
                                .FurnitureInfoId = FurniID
                                .Property_Dtl_ID = 0
                                .MarketValue = MrketValue
                                .Condition = Cndtion
                                .Location = Lction
                                .Status = "Received"
                                .save()
                            End With

                        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1127 Then '=== grdAIR.SelectedDataKey("GA_ID") = 537 Then
                            '=-= MACHINIRIES
                            With MachineInfo
                                .AIRDtl_ID = 0
                                .IsAccepted = False
                                .Property_Dtl_ID = 0
                                .SerialNo = "-"
                                .MachineDesc = txtCO_Description.Text
                                .MachineLocation = Lction
                                .BrandModel = txtCO_Model.Text
                                .DepreciationRate = txtCO_DepRate.Text
                                If txtCO_DepValue.Text = "" Then
                                    .DepreciationValue = 0
                                Else
                                    .DepreciationValue = txtCO_DepValue.Text
                                End If
                                .Received_ID = rcvID
                            End With

                            Dim MachineID As Long = MachineInfo.save
                            objDerived.GetRecords("UPDATE AMS.TbMachinery_Information SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "' WHERE MachineryInfoId = '" & MachineID & "'", CommandType.Text)

                            With MachineDtl
                                .MachineryInfoId = MachineID
                                .Property_Dtl_ID = 0
                                .MarketValue = MrketValue
                                .Condition = Cndtion
                                .Location = Lction
                                .Status = "Received"
                                .save()
                            End With

                        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1166 Then
                            '=-= TRANSPORTATION
                            ''here 12012023

                            With MotorInfo

                                .AIRDtl_ID = 0
                                .IsAccepted = False
                                .Property_Dtl_ID = 0
                                .Name = txtCO_MName.Text
                                .PlateNo = ""
                                .Model = txtCO_MModel.Text
                                .MotorNo = ""
                                .ChasisNo = txtCO_MChasisNo.Text
                                .VehicleColor = txtCO_MColor.Text
                                .WheelsCapacity = txtCO_MCapacity.Text
                                .GrossWeight = txtCO_MWeight.Text
                                .Seats = txtCO_MSeats.Text
                                .Warranty = txtCO_MWarranty.Text
                                .VehicleOwner = ""
                                .DeclaredName = txtDeclaredName.Text
                                .BeneficialUser = txtBeneficialUser.Text
                                .VehicleSpecification = txtCO_MSpecs.Text
                                .Received_ID = rcvID
                                .Item_ID = pInspection_detail.Rows(CO)("Item_ID")
                            End With

                            Dim MotorID As Long = MotorInfo.save
                            objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "', CSNo = '" & txtCSNumber.Text & "', EngineNo = '" & txtEngineNo.Text & "', Displacement = '" & txtDisplacement.Text & "' WHERE Motor_InfoId = '" & MotorID & "'", CommandType.Text)

                            With MotorDtl
                                .Motor_InfoId = MotorID
                                .Property_Dtl_ID = 0
                                .MarketValue = MrketValue
                                .Condition = Cndtion
                                .Location = Lction
                                .Status = "Received"
                                .save()
                            End With

                        Else '=-= ALL EQUIPMENTS
                            With EquipInfo
                                .AIRDtl_ID = 0
                                .IsAccepted = False
                                .Property_Dtl_ID = 0
                                .SerialNo = "-"
                                .Name = txtCO_Name.Text
                                .Description = txtCO_Description.Text
                                .PowerInput = txtCO_PowerIn.Text
                                .Dimension = txtCO_Dimension.Text
                                .AreaCapacity = txtCO_AreaCap.Text
                                .Model = txtCO_Model.Text
                                .Warranty = txtWarranty.Text
                                .Specification = txtCO_Specs.Text
                                .DepreciationRate = txtCO_DepRate.Text
                                If txtCO_DepValue.Text = "" Then
                                    .DepreciationValue = 0
                                Else
                                    .DepreciationValue = txtCO_DepValue.Text
                                End If
                                .Received_ID = rcvID
                            End With

                            Dim EuipID As Long = EquipInfo.save
                            objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "' WHERE EquipInfoId = '" & EuipID & "'", CommandType.Text)

                            With EquipDtl
                                .EquipInfoId = EuipID
                                .Property_Dtl_ID = 0
                                .MarketValue = MrketValue
                                .Condition = Cndtion
                                .Location = Lction
                                .Status = "Received"
                                .save()
                            End With

                        End If
                    End If
                Next
                Dim stck1 As Long = 0
                'For allotment class 3
                stck1 = objDerived.GetValue("SELECT Property_ID FROM AMS.Property WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

                Dim dt2 As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_ReceivedItems_Inspection] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & stck1 & "','" & AllotmentClass & "', '" & grdAIR.SelectedDataKey("Received_ID") & "'  ", CommandType.Text)

                objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET Status = 2 WHERE Received_ID = '" & rcvID & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET inspection_date='" & txtDate.Text & "' WHERE Received_ID = '" & rcvID & "'", CommandType.Text)




                'Dim rcvID As Long = grdAIR.SelectedDataKey("Received_ID")
                Dim poHdrId As Long = grdAIR.SelectedDataKey("POHdr_ID")
                Dim supplierId As Long = grdAIR.SelectedDataKey("Supplier_Id")

                '=== Update AMS.Tb_Receiving table ===


                ' If you also need to capture the header ID here, add the same block as above:
                Dim newPOHdrID As Long = CLng(grdAIR.SelectedDataKey("POHdr_ID"))
                Session("POHdr_ID") = newPOHdrID
                btnPreview.Enabled = True

            End If
        End If



        If isInsertNewRow = 1 Then
            ' Step 4: Clone the current record (rcvID) with the new InvoiceNo
            Dim sqlInsertReceiving As New StringBuilder()

            sqlInsertReceiving.AppendLine("INSERT INTO AMS.Tb_Receiving ")
            sqlInsertReceiving.AppendLine("(POHdr_ID, PO_No, InvoiceNo, Received_Date, Supplier_ID, GA_ID, Status, UserID, ReceivedBY, InspectedBy, InspectedBy2, inspection_date, TableName)")
            sqlInsertReceiving.AppendLine("SELECT")
            sqlInsertReceiving.AppendLine("ISNULL(POHdr_ID, 0),")
            sqlInsertReceiving.AppendLine("ISNULL(PO_No, ''),")
            sqlInsertReceiving.AppendLine("'" & invoiceNoInput & "',")
            sqlInsertReceiving.AppendLine("GETDATE(),")
            sqlInsertReceiving.AppendLine("ISNULL(Supplier_ID, 0),")
            sqlInsertReceiving.AppendLine("ISNULL(GA_ID, 0),")
            sqlInsertReceiving.AppendLine("ISNULL(Status, 0),")
            sqlInsertReceiving.AppendLine("ISNULL(UserID, ''),")
            sqlInsertReceiving.AppendLine("ISNULL(ReceivedBY, NULL),")
            sqlInsertReceiving.AppendLine("ISNULL(InspectedBy, NULL),")
            sqlInsertReceiving.AppendLine("ISNULL(InspectedBy2, NULL),")
            sqlInsertReceiving.AppendLine("ISNULL(inspection_date, NULL),")
            sqlInsertReceiving.AppendLine("'AMS.Tb_Receiving'")
            sqlInsertReceiving.AppendLine("FROM AMS.Tb_Receiving WHERE Received_ID = " & rcvID & ";")
            sqlInsertReceiving.AppendLine("SELECT CAST(SCOPE_IDENTITY() AS BIGINT);")

            Dim newReceivedID As Long = objDerived.GetValue(sqlInsertReceiving.ToString(), CommandType.Text)
            Session("Received_ID") = newReceivedID

            ' Step 5: Clone details (only for checked rows in grdInspection)
            Dim dtDetails As DataTable = objDerived.GetDataTable("SELECT * FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & rcvID, CommandType.Text)

            For i As Integer = 0 To grdInspection.Rows.Count - 1
                Dim cb2 As CheckBox = CType(grdInspection.Rows(i).FindControl("cbInspection"), CheckBox)
                If cb2 IsNot Nothing AndAlso cb2.Checked Then

                    ' Get Item_ID from DataKeys of the GridView row
                    Dim item_ID As String = grdInspection.DataKeys(i)("Item_ID").ToString()
                    If Not IsNumeric(item_ID) Then item_ID = "NULL"

                    ' Fetch the actual DataRow of this Item_ID
                    Dim rows() As DataRow = dtDetails.Select("Item_ID = " & item_ID)
                    If rows.Length = 0 Then Continue For
                    Dim row As DataRow = rows(0)

                    Dim qtyReceiving = If(IsDBNull(row("Qty_Receiving")), "0", row("Qty_Receiving").ToString())
                    Dim qtyReceived = If(IsDBNull(row("Qty_Received")), "0", row("Qty_Received").ToString())
                    'Dim qtyInspecting = If(IsDBNull(row("Qty_Inspecting")), "0", row("Qty_Inspecting").ToString())
                    Dim qtyInspecting As Decimal = 0

                    ' Get the actual user-inputted Qty_Accepting from the textbox in the GridView
                    Dim txtQty As TextBox = CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox)
                    Dim qtyAccepting As Decimal = 0
                    Decimal.TryParse(txtQty.Text, qtyAccepting)

                    Dim cost = If(IsDBNull(row("Cost")), "0", row("Cost").ToString())
                    Dim marketValue = If(IsDBNull(row("MarketValue")), "0", row("MarketValue").ToString())
                    Dim poQty = If(IsDBNull(row("PO_Qty")), "0", row("PO_Qty").ToString())
                    Dim isDisplayReport = If(IsDBNull(row("IsDisplayReport")), "0", If(CBool(row("IsDisplayReport")), "1", "0"))
                    Dim status = If(IsDBNull(row("Status")), "0", row("Status").ToString())
                    Dim tempReportQuantity = If(IsDBNull(row("tempReportQuantity")), "0", row("tempReportQuantity").ToString())
                    Dim condition = replaceapostrophe(If(IsDBNull(row("Condition")), "", row("Condition").ToString()))
                    Dim location = replaceapostrophe(If(IsDBNull(row("Location")), "", row("Location").ToString()))
                    Dim otherSpecs = replaceapostrophe(If(IsDBNull(row("OtherSpecs")), "", row("OtherSpecs").ToString()))

                    Dim sqlInsertDtl As New StringBuilder()
                    sqlInsertDtl.Append("INSERT INTO AMS.Tb_Receiving_Dtl ")
                    sqlInsertDtl.Append("(Received_ID, Item_ID, Qty_Receiving, Qty_Received, Qty_Inspecting, Qty_Accepting, Cost, MarketValue, PO_Qty, Status, IsDisplayReport, tempReportQuantity, Condition, Location, OtherSpecs) ")
                    sqlInsertDtl.Append("VALUES (")
                    sqlInsertDtl.Append(newReceivedID & ", ")
                    sqlInsertDtl.Append(item_ID & ", ")
                    sqlInsertDtl.Append(qtyReceiving & ", ")
                    sqlInsertDtl.Append(qtyReceived & ", ")
                    sqlInsertDtl.Append(qtyInspecting & ", ")
                    sqlInsertDtl.Append(qtyAccepting & ", ")
                    sqlInsertDtl.Append(cost & ", ")
                    sqlInsertDtl.Append(marketValue & ", ")
                    sqlInsertDtl.Append(poQty & ", ")
                    sqlInsertDtl.Append(status & ", ")
                    sqlInsertDtl.Append(isDisplayReport & ", ")
                    sqlInsertDtl.Append(tempReportQuantity & ", '")
                    sqlInsertDtl.Append(condition & "', '")
                    sqlInsertDtl.Append(location & "', '")
                    sqlInsertDtl.Append(otherSpecs & "')")

                    AddTrace("Inserting Detail for Item_ID: " & item_ID & " into new Received_ID: " & newReceivedID)
                    objDerived.Execute(sqlInsertDtl.ToString(), CommandType.Text)

                    ' ===== START OF NEW CODE =====
                    ' Step 6: Update original receiving details by subtracting new quantities for this specific item only
                    Dim currentNewQty As Decimal = CDec(qtyAccepting)
                    AddTrace("Updating original detail for Item_ID: " & item_ID & " subtracting Qty_Accepting: " & currentNewQty.ToString())

                    Dim updateQuery As String = "UPDATE AMS.Tb_Receiving_Dtl " &
                        "SET Qty_Accepting = CASE " &
                            "WHEN Qty_Accepting >= " & qtyAccepting.ToString() & " THEN Qty_Accepting - " & qtyAccepting.ToString() & " " &
                            "ELSE 0 " &
                        "END " &
                        "WHERE Received_ID = " & rcvID & " " &
                        "AND Item_ID = " & item_ID


                    objDerived.Execute(updateQuery, CommandType.Text)
                    ' ===== END OF NEW CODE =====

                End If
            Next




            DeleteReceivingIfNoDetails()


            AddTrace("Invoice Number : " & txtInvoiceNumber.Text)
            objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InvoiceNo = '" & txtInvoiceNumber.Text & "', PO_No = '" & txtPoNumber.Text & "' WHERE Received_ID = '" & newReceivedID & "'", CommandType.Text)

            '=== Update AMS.AIR_Hdr table ===
            objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET Invoice_No = '" & txtInvoiceNumber.Text & "', Invoice_date = '" & txtInvoiceDate.Text & "', PO_No = '" & txtPoNumber.Text & "', remarks = '" & txtRemakrs.Text & "' WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' AND Received_ID = '" & newReceivedID & "'", CommandType.Text)

        Else

            AddTrace("currentInvoiceObj: " & currentInvoiceObj)
            AddTrace("POHdr_ID: " & grdAIR.SelectedDataKey("POHdr_ID"))
            AddTrace("Received_ID: " & grdAIR.SelectedDataKey("Received_ID"))
            AddTrace("Invoice Number : " & txtInvoiceNumber.Text)

            ' Check if currentInvoiceObj is null, DBNull, or empty
            If currentInvoiceObj Is Nothing OrElse IsDBNull(currentInvoiceObj) OrElse currentInvoiceObj.ToString().Trim() = "" Then

                objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InvoiceNo = '" & txtInvoiceNumber.Text & "', PO_No = '" & txtPoNumber.Text & "' WHERE Received_ID = '" & grdAIR.SelectedDataKey("Received_ID") & "'", CommandType.Text)

                '=== Update AMS.AIR_Hdr table ===
                objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET Invoice_No = '" & txtInvoiceNumber.Text & "', Invoice_date = '" & txtInvoiceDate.Text & "', PO_No = '" & txtPoNumber.Text & "', remarks = '" & txtRemakrs.Text & "' WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' AND Received_ID = '" & grdAIR.SelectedDataKey("Received_ID") & "'", CommandType.Text)

            End If




        End If





        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        LoadrbALL()

        grdInspection.DataSource = Nothing
        grdInspection.DataBind()
        ClearTextBoxes(Me)
        btnSave.Enabled = False



        DeleteReceivingIfNoDetails()
        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error: '" & ex.Message & "'")
        'End Try
    End Sub

    Private Sub DeleteReceivingIfNoDetails()
        Try
            ' Get all orphaned Received_IDs from Tb_Receiving (those not present in Tb_Receiving_Dtl)
            Dim dtOrphaned As DataTable = objDerived.GetDataTable(" SELECT Received_ID FROM AMS.Tb_Receiving WHERE Received_ID NOT IN ( SELECT DISTINCT Received_ID FROM AMS.Tb_Receiving_Dtl WHERE Received_ID IS NOT NULL ) ", CommandType.Text)

            If dtOrphaned.Rows.Count = 0 Then
                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No orphaned Receiving records found.")
                Exit Sub
            End If

            ' Loop and delete each orphaned record
            For Each row As DataRow In dtOrphaned.Rows
                Dim orphanID As Long = CLng(row("Received_ID"))
                objDerived.Execute("DELETE FROM AMS.Tb_Receiving WHERE Received_ID = " & orphanID, CommandType.Text)
            Next

            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, dtOrphaned.Rows.Count & " orphaned Receiving record(s) deleted.")

        Catch ex As Exception
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error deleting orphaned Receiving rows: " & ex.Message)
        End Try
    End Sub




    Protected Sub ScriptManager1_AsyncPostBackError(sender As Object, e As AsyncPostBackErrorEventArgs)
        ScriptManager1.AsyncPostBackErrorMessage = "Error: " & e.Exception.Message
    End Sub

    Protected Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click


        ' Retrieve the saved POHdr_ID from the session.
        Dim savedPOHdrID As String = ""
        If Session("POHdr_ID") IsNot Nothing Then
            savedPOHdrID = Session("POHdr_ID").ToString()
        End If

        Session("IsInspected") = "X"
        Session("AcceptedDate") = ""
        Session("IsPartial") = ""
        Session("AcceptingPerson") = ""
        Session("AcceptingPosition") = ""
        Session("IsComplete") = ""
        '/procurement/t_rpt_receiving

        If Not String.IsNullOrEmpty(savedPOHdrID) Then
            ' Build the URL for the report page
            Dim url As String = "/Procurement/t_rpt_receiving.aspx"
            ' Open the report page in a new window/tab.
            Dim script As String = "window.open('" & url & "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)
        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No saved transaction available for preview.")
        End If


        ' If a valid ID is stored, open the report page using that ID.
        'If Not String.IsNullOrEmpty(savedPOHdrID) Then
        '    ' Build the URL for the report page
        '    Dim url As String = "/Procurement/rpt_inspection_and_acceptance.aspx?POHdr_ID=" & savedPOHdrID
        '    ' Open the report page in a new window/tab.
        '    Dim script As String = "window.open('" & url & "', '_blank');"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)
        'Else
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No saved transaction available for preview.")
        'End If
    End Sub

    Private Sub ClearTextBoxes(ByVal parent As Control)
        For Each c As Control In parent.Controls
            If TypeOf c Is TextBox Then
                DirectCast(c, TextBox).Text = String.Empty
            ElseIf c.HasControls() Then
                ClearTextBoxes(c)
            End If
        Next
    End Sub

    Protected Sub btnReturnItem_Click(sender As Object, e As EventArgs)
        Try
            Dim poHdrId As Integer = grdAIR.SelectedDataKey("POHdr_ID")
            Dim currentNODId As Integer = If(Session("NOD_ID") IsNot Nothing, Convert.ToInt32(Session("NOD_ID")), 0)
            Dim allItemsReturned As Boolean = True
            Dim processedReceivedIds As New List(Of Long)()

            AddTrace("Selected POHdr_ID from grdAIR: " & poHdrId)
            AddTrace("Current NOD_ID from session: " & currentNODId)

            ' Step 1: Process checked items in inspection grid
            For Each row As GridViewRow In grdInspection.Rows
                Dim cbInspection As CheckBox = DirectCast(row.FindControl("cbInspection"), CheckBox)
                Dim txtActQty As TextBox = DirectCast(row.FindControl("txtActQty"), TextBox)
                Dim keys As DataKey = grdInspection.DataKeys(row.RowIndex)

                If cbInspection IsNot Nothing AndAlso cbInspection.Checked Then
                    Dim receivedDtlId As Long = Convert.ToInt64(keys("Received_Dtl_ID"))
                    Dim receivedId As Long = Convert.ToInt64(keys("Received_ID"))

                    AddTrace("Processing checked item - Received_Dtl_ID: " & receivedDtlId & ", Received_ID: " & receivedId)


                    'Updating of Quantity or Delete row with 0 Qty_Inspecting
                    ' Fetch current Qty_Inspecting from DB
                    Dim getQtySQL As String = "SELECT ISNULL(Qty_Inspecting, 0) FROM AMS.Tb_Receiving_Dtl WHERE Received_Dtl_ID = " & receivedDtlId
                    Dim currentQtyInspecting As Decimal = Convert.ToDecimal(objDerived.GetValue(getQtySQL, CommandType.Text))

                    Dim returnQty As Decimal = 0
                    If Not Decimal.TryParse(txtActQty.Text.Trim(), returnQty) Then
                        returnQty = 0
                    End If

                    If returnQty < currentQtyInspecting Then
                        ' Update Qty_Inspecting = current - returnQty
                        Dim newQtyInspecting As Decimal = currentQtyInspecting - returnQty
                        Dim updateSQL As String = "UPDATE AMS.Tb_Receiving_Dtl SET Qty_Inspecting = " & newQtyInspecting &
                                      " WHERE Received_Dtl_ID = " & receivedDtlId
                        objDerived.Execute(updateSQL, CommandType.Text)
                        AddTrace("Updated Qty_Inspecting to " & newQtyInspecting & " for Received_Dtl_ID: " & receivedDtlId)
                    Else
                        ' Delete specific receiving detail
                        Dim deleteDtlSql As String = "DELETE FROM AMS.Tb_Receiving_Dtl WHERE Received_Dtl_ID = " & receivedDtlId
                        objDerived.Execute(deleteDtlSql, CommandType.Text)
                        AddTrace("Deleted receiving detail for Received_Dtl_ID: " & receivedDtlId)
                    End If

                    ' Track processed header IDs
                    If Not processedReceivedIds.Contains(receivedId) Then
                        processedReceivedIds.Add(receivedId)
                    End If
                Else
                    ' If any item is not checked, mark as not fully returned
                    allItemsReturned = False
                End If
            Next


            ' Step 3: Handle NOD and PO status only if ALL items returned
            If allItemsReturned AndAlso currentNODId > 0 Then
                AddTrace("All items returned - processing NOD and PO status")

                ' Delete NOD record
                Dim deleteNOD As String = "DELETE FROM [AMS].[t_Notice_Of_Delivery] WHERE NOD_ID = " & currentNODId
                objDerived.Execute(deleteNOD, CommandType.Text)
                AddTrace("Deleted Notice of Delivery with ID: " & currentNODId)

                ' Revert PO status
                Dim revertPOStatusSQL As String = "UPDATE [AMS].[PO_Hdr] SET IsNoticeForDelivery = 0 WHERE POHdr_ID = " & poHdrId
                objDerived.Execute(revertPOStatusSQL, CommandType.Text)
                AddTrace("Reverted PO status for POHdr_ID: " & poHdrId)

                ' Clear session
                Session.Remove("NOD_ID")
                AddTrace("Session NOD_ID removed")
            End If

            ' Step 4: Refresh UI
            If grdInspection IsNot Nothing Then
                AddTrace("Clearing and rebinding grdInspection")
                ' Rebind grid to show updated items
                BindInspectionGrid() ' You'll need to implement this
            End If

            ' Update button states
            returnItemBtn.Enabled = False ' Disable return after processing
            If btnPreview IsNot Nothing Then btnPreview.Enabled = False
            If btnSave IsNot Nothing Then btnSave.Enabled = True
            AddTrace("Updated button states")




            'Qty_Inspecting value checking and deleting rows
            ' Step 1: Process checked items in inspection grid
            For Each row As GridViewRow In grdInspection.Rows
                Dim cbInspection As CheckBox = DirectCast(row.FindControl("cbInspection"), CheckBox)
                If cbInspection IsNot Nothing AndAlso cbInspection.Checked Then
                    Dim keys As DataKey = grdInspection.DataKeys(row.RowIndex)
                    Dim receivedDtlId As Long = Convert.ToInt64(keys("Received_Dtl_ID"))
                    Dim receivedId As Long = Convert.ToInt64(keys("Received_ID"))

                    AddTrace("Processing checked item - Received_Dtl_ID: " & receivedDtlId & ", Received_ID: " & receivedId)

                    ' Delete specific receiving detail
                    Dim deleteDtlSql As String = "DELETE FROM AMS.Tb_Receiving_Dtl WHERE Received_Dtl_ID = " & receivedDtlId
                    objDerived.Execute(deleteDtlSql, CommandType.Text)
                    AddTrace("Deleted receiving detail for Received_Dtl_ID: " & receivedDtlId)

                    ' Track processed header IDs
                    If Not processedReceivedIds.Contains(receivedId) Then
                        processedReceivedIds.Add(receivedId)
                    End If
                Else
                    ' If any item is not checked, mark as not fully returned
                    allItemsReturned = False
                End If
            Next

            ' Step 1.5: Delete rows where Qty_Inspecting = 0 and remove empty headers
            For Each receivedId As Long In processedReceivedIds
                ' Delete detail rows with Qty_Inspecting = 0
                Dim deleteZeroInspectingSQL As String =
        "DELETE FROM AMS.Tb_Receiving_Dtl " &
        "WHERE Received_ID = " & receivedId & " " &
        "AND ISNULL(Qty_Inspecting, 0) = 0"
                objDerived.Execute(deleteZeroInspectingSQL, CommandType.Text)
                AddTrace("Deleted all receiving detail rows with Qty_Inspecting = 0 for Received_ID: " & receivedId)

                ' Check if header is now empty
                Dim checkDtlSQL1 As String = "SELECT COUNT(*) FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & receivedId
                Dim remainingDtlCount As Integer = Convert.ToInt32(objDerived.GetValue(checkDtlSQL1, CommandType.Text))

                If remainingDtlCount = 0 Then
                    Dim deleteHdrSQL As String = "DELETE FROM AMS.Tb_Receiving WHERE Received_ID = " & receivedId
                    objDerived.Execute(deleteHdrSQL, CommandType.Text)
                    AddTrace("Deleted Tb_Receiving row because it had no remaining details (Received_ID: " & receivedId & ")")
                End If
            Next

            ' Step 1.6: Clean up other orphaned Received_IDs under same POHdr_ID
            Dim orphanCheckSQL As String = "SELECT Received_ID FROM AMS.Tb_Receiving " &
                                "WHERE POHdr_ID = " & poHdrId & " " &
                                "AND Received_ID NOT IN (SELECT DISTINCT Received_ID FROM AMS.Tb_Receiving_Dtl)"
            Dim orphanTable As DataTable = objDerived.GetDataTable(orphanCheckSQL, CommandType.Text)

            For Each row As DataRow In orphanTable.Rows
                Dim orphanReceivedId As Long = Convert.ToInt64(row("Received_ID"))
                Dim deleteOrphanSql As String = "DELETE FROM AMS.Tb_Receiving WHERE Received_ID = " & orphanReceivedId
                objDerived.Execute(deleteOrphanSql, CommandType.Text)
                AddTrace("Deleted orphaned Tb_Receiving (no detail rows) for Received_ID: " & orphanReceivedId)
            Next




            'IsNoticeForDelivery update if POHdr_ID not exist on Tb_Receiving and Tb_Receiving_Dtl

            ' Step 1.6: If the POHdr_ID has no entries in both Tb_Receiving_Dtl and Tb_Receiving, reset IsNoticeForDelivery
            Dim checkDtlSQL As String = "SELECT COUNT(*) FROM AMS.Tb_Receiving_Dtl rd " &
                             "JOIN AMS.Tb_Receiving r ON rd.Received_ID = r.Received_ID " &
                             "WHERE r.POHdr_ID = " & poHdrId
            Dim countDtl As Integer = Convert.ToInt32(objDerived.GetValue(checkDtlSQL, CommandType.Text))

            Dim checkHdrSQL As String = "SELECT COUNT(*) FROM AMS.Tb_Receiving WHERE POHdr_ID = " & poHdrId
            Dim countHdr As Integer = Convert.ToInt32(objDerived.GetValue(checkHdrSQL, CommandType.Text))

            If countDtl = 0 AndAlso countHdr = 0 Then
                Dim resetNoticeSQL As String = "UPDATE AMS.PO_Hdr SET IsNoticeForDelivery = NULL WHERE POHdr_ID = " & poHdrId
                objDerived.Execute(resetNoticeSQL, CommandType.Text)
                AddTrace("Reset IsNoticeForDelivery to NULL for POHdr_ID: " & poHdrId)
            End If


            grdInspection.DataSource = Nothing
            grdInspection.DataBind()

            ' Show success message
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected items have been successfully returned.")
            LoadrbALL()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error returning items: " & ex.Message)
            AddTrace("Error in btnReturnItem_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub BindInspectionGrid()
        Try
            ' Validate PO selection
            If grdAIR.SelectedDataKey Is Nothing Then Exit Sub

            Dim poHdrId As Long = CLng(grdAIR.SelectedDataKey("POHdr_ID"))
            Dim receivedId As Long = CLng(grdAIR.SelectedDataKey("Received_ID"))
            Dim allotmentClass As Integer = allotmentClass

            Dim stockOrPropertyId As Long = 0

            ' Determine stock or property ID based on allotment class
            If allotmentClass = 2 Then ' MOOE
                stockOrPropertyId = objDerived.GetValue("SELECT StockID FROM AMS.Stock WHERE POHdr_ID = '" & poHdrId & "'", CommandType.Text)
            ElseIf allotmentClass = 3 Then ' Capital Outlay
                stockOrPropertyId = objDerived.GetValue("SELECT Property_ID FROM AMS.Property WHERE POHdr_ID = '" & poHdrId & "'", CommandType.Text)
            End If

            ' Fetch updated inspection detail
            pInspection_detail = objDerived.GetDataTable("EXEC [AMS].[sp_ReceivedItems_Inspection] '" & poHdrId & "','" & stockOrPropertyId & "','" & allotmentClass & "','" & receivedId & "'", CommandType.Text)

            txtHiddenReceiveQty.Value = pInspection_detail.Rows.Count
            AddTrace("BindInspectionGrid: Fetched " & pInspection_detail.Rows.Count & " rows for POHdr_ID " & poHdrId)

            ' Pad rows to maintain 5-row UI
            If pInspection_detail.Rows.Count < 5 Then
                pInspection_detail.Merge(CreateTable3(5 - pInspection_detail.Rows.Count))
            End If

            ' Bind to GridView
            grdInspection.DataSource = pInspection_detail
            grdInspection.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error in BindInspectionGrid: " & ex.Message)
            AddTrace("Error in BindInspectionGrid: " & ex.Message)
        End Try
    End Sub


    'Protected Sub btnReturnItem_Click(sender As Object, e As EventArgs)
    '    Try
    '        Dim poHdrId As Integer = grdAIR.SelectedDataKey("POHdr_ID")
    '        AddTrace("Selected POHdr_ID from grdAIR: " & poHdrId)

    '        ' Step 1: Delete ALL Notice of Delivery records for this PO (not just one)
    '        Dim deleteNOD As String = "DELETE FROM [AMS].[t_Notice_Of_Delivery] WHERE POHdr_ID = " & poHdrId
    '        AddTrace("SQL to delete NOD: " & deleteNOD)
    '        objDerived.Execute(deleteNOD, CommandType.Text)
    '        AddTrace("Deleted all Notice of Delivery records for POHdr_ID: " & poHdrId)

    '        ' Step 2: Revert PO status
    '        Dim revertPOStatusSQL As String = "UPDATE [AMS].[PO_Hdr] SET IsNoticeForDelivery = 0 WHERE POHdr_ID = " & poHdrId
    '        AddTrace("SQL to revert PO status: " & revertPOStatusSQL)
    '        objDerived.Execute(revertPOStatusSQL, CommandType.Text)
    '        AddTrace("Reverted PO status for POHdr_ID: " & poHdrId)

    '        ' Step 3: Delete ALL receiving records for this PO (not just one)
    '        Dim getReceivingIdsSql As String = "SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = " & poHdrId & " AND TableName = 'NoticeOfDelivery'"
    '        AddTrace("SQL to get Received_IDs: " & getReceivingIdsSql)
    '        Dim receivingIds As DataTable = objDerived.GetDataTable(getReceivingIdsSql, CommandType.Text)

    '        For Each row As DataRow In receivingIds.Rows
    '            Dim receivedId As Long = Convert.ToInt64(row("Received_ID"))
    '            AddTrace("Processing Received_ID: " & receivedId)

    '            ' Delete receiving details
    '            Dim deleteDtlSql As String = "DELETE FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & receivedId
    '            objDerived.Execute(deleteDtlSql, CommandType.Text)
    '            AddTrace("Deleted receiving details for Received_ID: " & receivedId)

    '            ' Delete receiving header
    '            Dim deleteHdrSql As String = "DELETE FROM AMS.Tb_Receiving WHERE Received_ID = " & receivedId
    '            objDerived.Execute(deleteHdrSql, CommandType.Text)
    '            AddTrace("Deleted receiving header for Received_ID: " & receivedId)
    '        Next

    '        ' Clear the session variable
    '        Session.Remove("NOD_ID")
    '        AddTrace("Session NOD_ID removed.")

    '        ' Refresh UI
    '        If grdInspection IsNot Nothing Then
    '            AddTrace("Clearing and rebinding grdInspection.")
    '            grdInspection.DataSource = Nothing
    '            grdInspection.DataBind()
    '        End If

    '        ' Update button states
    '        If btnPreview IsNot Nothing Then btnPreview.Enabled = False
    '        If btnSave IsNot Nothing Then btnSave.Enabled = True
    '        AddTrace("Updated button states: btnPreview.Enabled = False, btnSave.Enabled = True")

    '        ' Show success message
    '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Notice of Delivery has been successfully returned.")
    '        LoadrbALL()
    '    Catch ex As Exception
    '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error returning Notice of Delivery: " & ex.Message)
    '        AddTrace("Error in btnReturnItem_Click: " & ex.Message)
    '    End Try
    'End Sub

    'Protected Sub btnReturnItem_Click(sender As Object, e As EventArgs)

    '    Dim stck1 As Long = 0
    '    If AllotmentClass = 2 Then
    '        Dim sqlStock = "SELECT StockID FROM AMS.Stock WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'"
    '        AddTrace("Executing: " & sqlStock)
    '        stck1 = objDerived.GetValue(sqlStock, CommandType.Text)
    '    ElseIf AllotmentClass = 3 Then
    '        Dim sqlProperty = "SELECT Property_ID FROM AMS.Property WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'"
    '        AddTrace("Executing: " & sqlProperty)
    '        stck1 = objDerived.GetValue(sqlProperty, CommandType.Text)
    '    End If

    '    AddTrace("Start btnReturnItem_Click")
    '    AddTrace("POHdr_ID: " & grdAIR.SelectedDataKey("POHdr_ID"))
    '    AddTrace("Received_ID: " & grdAIR.SelectedDataKey("Received_ID"))
    '    AddTrace("stck1: " & stck1)

    '    Dim sp = "EXEC [AMS].[sp_ReceivedItems_Inspection] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & stck1 & "','" & AllotmentClass & "', '" & grdAIR.SelectedDataKey("Received_ID") & "'"
    '    AddTrace("Executing: " & sp)
    '    Dim dt As DataTable = objDerived.GetDataTable(sp, CommandType.Text)

    '    Dim cb1 As CheckBox

    '    If dt.Rows.Count > 0 Then
    '        For xa As Integer = 0 To grdInspection.Rows.Count - 1
    '            cb1 = CType(Me.grdInspection.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)

    '            If cb1.Visible AndAlso cb1.Checked Then
    '                Dim num As String = dt.Rows(xa).Item("Item_ID").ToString()
    '                Dim rcvID As String = dt.Rows(xa).Item("Received_ID").ToString()
    '                AddTrace("Processing Item_ID=" & num & ", Received_ID=" & rcvID)

    '                Dim receivedQtyTextValue As Decimal
    '                Dim txtQty As TextBox = CType(grdInspection.Rows(xa).FindControl("txtActQty"), TextBox)
    '                If Not Decimal.TryParse(txtQty.Text, receivedQtyTextValue) Then
    '                    receivedQtyTextValue = 0
    '                End If
    '                AddTrace("Returned Qty from UI: " & receivedQtyTextValue)

    '                Dim Qty_InspectedValue As Decimal
    '                Dim sqlInspect = "SELECT Qty_Inspecting FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & rcvID & " AND Item_ID = " & num
    '                AddTrace("Executing: " & sqlInspect)
    '                Dim result2 As Object = objDerived.GetValue(sqlInspect, CommandType.Text)
    '                If result2 IsNot DBNull.Value Then Decimal.TryParse(result2.ToString(), Qty_InspectedValue)

    '                Dim Qty_ReceivedValue As Decimal
    '                Dim sqlReceive = "SELECT Qty_Receiving FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & rcvID & " AND Item_ID = " & num
    '                AddTrace("Executing: " & sqlReceive)
    '                Dim result As Object = objDerived.GetValue(sqlReceive, CommandType.Text)
    '                If result IsNot DBNull.Value Then Decimal.TryParse(result.ToString(), Qty_ReceivedValue)

    '                AddTrace("Current Qty_Inspecting: " & Qty_InspectedValue)
    '                AddTrace("Current Qty_Receiving: " & Qty_ReceivedValue)

    '                Dim calResult As Decimal
    '                Dim calResultReceived As Decimal

    '                If (receivedQtyTextValue <= Qty_InspectedValue) Then
    '                    calResult = Math.Abs(Qty_InspectedValue - receivedQtyTextValue)
    '                    calResultReceived = Qty_ReceivedValue + receivedQtyTextValue
    '                    AddTrace("New Qty_Inspecting: " & calResult)
    '                    AddTrace("New Qty_Receiving: " & calResultReceived)
    '                Else
    '                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The quantity desired to return is more that existing quantity, Reminder: Reload to see existing quantity.")
    '                    AddTrace("Invalid return attempt — returned qty exceeds inspected.")
    '                    Exit Sub
    '                End If

    '                Dim updateDtlSQL As String = "UPDATE AMS.Tb_Receiving_Dtl SET Qty_Inspecting = '" & calResult & "' WHERE Received_ID = " & rcvID & " AND Item_ID = " & num
    '                AddTrace("Executing: " & updateDtlSQL)
    '                objDerived.Execute(updateDtlSQL, CommandType.Text)

    '                Dim updateDtlReceived As String = "UPDATE AMS.Tb_Receiving_Dtl SET Qty_Receiving = '" & calResultReceived & "' WHERE Received_ID = " & rcvID & " AND Item_ID = " & num
    '                AddTrace("Executing: " & updateDtlReceived)
    '                objDerived.Execute(updateDtlReceived, CommandType.Text)
    '            End If
    '        Next
    '    End If

    '    ' Check if all Qty_Inspecting = 0 for the Received_ID
    '    Dim checkInspectingZeroSql As String = " SELECT COUNT(*) FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & grdAIR.SelectedDataKey("Received_ID") & " AND ISNULL(Qty_Inspecting, 0) > 0"
    '    AddTrace("Checking if all Qty_Inspecting = 0: " & checkInspectingZeroSql)
    '    Dim remainingInspectingCount As Integer = Convert.ToInt32(objDerived.GetValue(checkInspectingZeroSql, CommandType.Text))

    '    If remainingInspectingCount = 0 Then
    '        ' All Qty_Inspecting are 0 → safe to delete details and header
    '        Dim deleteDtlSql As String = "DELETE FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = " & grdAIR.SelectedDataKey("Received_ID")
    '        AddTrace("Deleting from AMS.Tb_Receiving_Dtl: " & deleteDtlSql)
    '        objDerived.Execute(deleteDtlSql, CommandType.Text)

    '        Dim deleteHdrSql As String = "DELETE FROM AMS.Tb_Receiving WHERE Received_ID = " & grdAIR.SelectedDataKey("Received_ID")
    '        AddTrace("Deleting from AMS.Tb_Receiving: " & deleteHdrSql)
    '        objDerived.Execute(deleteHdrSql, CommandType.Text)

    '        AddTrace("All receiving data removed due to Qty_Inspecting = 0 for all items.")
    '    End If

    '    ' Refetch stock or property ID
    '    Dim stck2 As Long = 0
    '    If AllotmentClass = 2 Then
    '        Dim sqlStock2 = "SELECT StockID FROM AMS.Stock WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'"
    '        AddTrace("Executing: " & sqlStock2)
    '        stck2 = objDerived.GetValue(sqlStock2, CommandType.Text)
    '    ElseIf AllotmentClass = 3 Then
    '        Dim sqlProperty2 = "SELECT Property_ID FROM AMS.Property WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'"
    '        AddTrace("Executing: " & sqlProperty2)
    '        stck2 = objDerived.GetValue(sqlProperty2, CommandType.Text)
    '    End If

    '    Dim finalSp = "EXEC [AMS].[sp_ReceivedItems_Inspection] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & stck1 & "','" & AllotmentClass & "', '" & grdAIR.SelectedDataKey("Received_ID") & "'"
    '    AddTrace("Final refresh with: " & finalSp)
    '    pInspection_detail = objDerived.GetDataTable(finalSp, CommandType.Text)

    '    txtHiddenReceiveQty.Value = pInspection_detail.Rows.Count

    '    If pInspection_detail.Rows.Count < 5 Then
    '        pInspection_detail.Merge(CreateTable3(5 - pInspection_detail.Rows.Count))
    '    End If

    '    grdInspection.DataSource = pInspection_detail
    '    grdInspection.DataBind()

    '    LoadrbALL()
    '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The selected PO has been returned successfully.")
    '    AddTrace("btnReturnItem_Click completed.")
    'End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)
    End Sub



    Protected Sub txtInvoiceNumber_TextChanged(sender As Object, e As EventArgs)

        Dim rcvID As Long = grdAIR.SelectedDataKey("Received_ID")
        Dim currentInvoiceObj As Object = objDerived.GetValue("SELECT InvoiceNo FROM AMS.Tb_Receiving WHERE Received_ID = " & rcvID, CommandType.Text)


        If String.IsNullOrEmpty(txtInvoiceNumber.Text) Then
            ' Generate new invoice number if empty
            txtInvoiceNumber.Text = objDerived.GetValue("EXEC [AMS].[sp_Generate_UniqueInvoiceNo]", CommandType.Text).ToString()
        Else
            Dim invcNo As String = txtInvoiceNumber.Text
            Dim invoiceExist As String = objDerived.GetValue("Select AMS.Tb_Receiving.InvoiceNo from AMS.Tb_Receiving where AMS.Tb_Receiving.InvoiceNo = '" & invcNo & "' ", CommandType.Text)

            If invoiceExist IsNot Nothing AndAlso invoiceExist <> "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "This invoice number already exists.")

                If currentInvoiceObj Is Nothing Then
                    txtInvoiceNumber.Text = objDerived.GetValue("EXEC [AMS].[sp_Generate_UniqueInvoiceNo]", CommandType.Text).ToString()
                Else
                    txtInvoiceNumber.Text = currentInvoiceObj
                End If



            End If
        End If
    End Sub


    Private Function SaveAIR(ByVal rcvID As Long) As Integer

        'Check AIR----------------------------------
        'Dim checkAIR As Long = objDerived.GetValue("select * from AMS.AIR_Hdr where AMS.AIR_Hdr.Received_ID = '" & rcvID & "' or AMS.AIR_Hdr.POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

        Dim AIR_No As String = supplies.GetValue("select [AMS].[func_GenerateAIR]( '" & txtDate.Text & "')", CommandType.Text)

        Dim ReceivedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("ReceivedBY") & "'", CommandType.Text)
        Dim InspectedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("InspectedBy") & "'", CommandType.Text)

        Dim functionID As Long = objDerived.GetValue("SELECT Function_ID FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "' AND Function_ID = '" & grdAIR.SelectedDataKey("Function_ID") & "'", CommandType.Text)
        Dim rc_ID As Long = objDerived.GetValue("SELECT RC_ID FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
        Dim invoiceNum As String = objDerived.GetValue("SELECT InvoiceNo FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

        Dim xAIRHdr_ID As Long

        'If checkAIR = 0 Then
        With AIR_Hdr
            .AIR_No = AIR_No
            .AIR_Date = txtDate.Text
            .Invoice_No = invoiceNum
            .Invoice_date = Date.Today.ToString("MM/dd/yyyy")
            .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
            .PO_No = grdAIR.SelectedDataKey("PO_No")
            .Supplier_ID = grdAIR.SelectedDataKey("Supplier_Id")
            .Date_Received = CDate(pInspection_detail.Rows(0)("Received_Date")).Date
            .Date_Inspect = txtDate.Text
            .Trans_ID = 1
            .remarks = Nothing 'No column in tbReceivng
            .IsInspected = True
            .Date_Accepted = New DateTime(1900, 1, 1)
            '.InspectedPersonPos = Nothing --ON SP 
            '.InspectedPersonPos2 = Nothing

            If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                .RC_ID = functionID
                .Function_ID = rc_ID
            Else
                .RC_ID = grdAIR.SelectedDataKey("RC_ID")
                .Function_ID = grdAIR.SelectedDataKey("Function_ID")
            End If

            Dim Box As CheckBox
            For a As Integer = 0 To grdInspection.Rows.Count - 1
                Box = CType(Me.grdInspection.Rows(a).Cells(0).FindControl("cbInspection"), CheckBox)
                If Box IsNot Nothing AndAlso Box.Checked Then
                    Dim zx As Long = pInspection_detail.Rows(a)("Received_ID")
                    Session("xReceived_ID") = zx
                    Exit For
                End If
            Next

            .Received_ID = Session("xReceived_ID")
            .UserID = Session("@UserName")
        End With

        xAIRHdr_ID = AIR_Hdr.save
        'End If

        Return xAIRHdr_ID
    End Function
End Class
