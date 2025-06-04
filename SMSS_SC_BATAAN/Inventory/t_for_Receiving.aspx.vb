Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Partial Class Inventory_t_for_Receiving
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
    Private objMotorInfo As New ConsolidatedPropertySaving.TbMotor_Info
    Private objMotorDtl As New ConsolidatedPropertySaving.TbMotor_Dtl
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
    Private Sub Inventory_t_for_Receiving(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            rbALL.Visible = True

            LoadPageData()

            'LoadSearchBy()

        End If
    End Sub



    ' On page load, set initial view for search and grid data binding
    Private Sub LoadPageData()
        ' Default filter: Load all data
        LoadrbALL()



        ' Set default view
        SetActiveView(vwALL)

        ' Show all fields initially
        txtPO.Visible = False
        ddSupplier.Visible = False
    End Sub



    Protected Sub LoadSearchBy()
        Select Case ddSearch.SelectedItem.Value
            Case "1"  ' ALL
                SetActiveView(vwALL, "ALL")
                rbALL.Visible = True  ' Ensure rbALL is visible
                LoadrbALL()  ' Load data based on the radio button selection

            Case "2"  ' ACCOUNT CODE
                SetActiveView(vwAccount, "AccountCode")
                BindDropdown(ddAccount, "SELECT DISTINCT GA_ID, GA_Title FROM AMS.View_AccountList", "GA_Title", "GA_ID")

            Case "3"  ' PO NUMBER
                SetActiveView(vwPO, "PO")
            ' Additional logic for PO NUMBER view can be added here.

            Case "4"  ' SUPPLIER
                SetActiveView(vwSupp, "SUPPLIER")
                BindDropdown(ddSupplier, "SELECT * FROM dbo.Supplier ORDER BY SuppName", "SuppName", "Supplier_Id")

            Case Else
                ' Optionally handle unexpected values.
        End Select
    End Sub


    Private Sub SetActiveView(view As View, page As String)
        mvSearch.SetActiveView(view)
        Session("Page") = page
    End Sub

    Private Sub BindDropdown(dropdown As DropDownList, query As String, textField As String, valueField As String)
        Dim dataTable As DataTable = objDerived.GetDataTable(query, CommandType.Text)
        With dropdown
            .DataSource = dataTable
            .DataTextField = textField
            .DataValueField = valueField
            .DataBind()
            .Items.Insert(0, New ListItem("Select", "0"))
        End With
    End Sub
    'Protected Sub ddSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    rbALL.SelectedIndex = -1
    '    LoadSearchBy()
    'End Sub

    ' Handles the dropdown selection change to show/hide relevant search controls
    Protected Sub ddSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case ddSearch.SelectedValue
            Case "1"  ' ALL
                SetActiveView(vwALL)
                rbALL.Visible = True  ' Ensure rbALL is visible
                txtPO.Visible = False
                ddSupplier.Visible = False
                LoadrbALL()

            Case "3"  ' Purchase Order
                SetActiveView(vwPO)
                txtPO.Visible = True
                ddSupplier.Visible = False

            Case "4"  ' Supplier / Bidder
                SetActiveView(vwSupp)
                ddSupplier.Visible = True
                txtPO.Visible = False
                BindSupplierDropdown()  ' Bind the supplier dropdown dynamically

            Case Else
                ' Default for all cases
                txtPO.Visible = False
                ddSupplier.Visible = False
        End Select
    End Sub

    ' Method to bind supplier dropdown
    Private Sub BindSupplierDropdown()
        ddSupplier.DataSource = objDerived.GetDataTable("SELECT Supplier_Id, SuppName FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
        ddSupplier.DataTextField = "SuppName"
        ddSupplier.DataValueField = "Supplier_Id"
        ddSupplier.DataBind()
        ddSupplier.Items.Insert(0, New ListItem("Select Supplier", "0"))
    End Sub

    ' Method to set active view based on the selected search type
    Private Sub SetActiveView(view As View)
        mvSearch.SetActiveView(view)
    End Sub

    Protected Sub btnSearchPO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Create a DataView to filter the data
        Dim myview As DataView = pPurchase_Order.DefaultView

        ' Apply filter for PO Number
        myview.RowFilter = "PO_No LIKE '%" & replaceapostrophe(txtPO.Text) & "%'"

        ' Bind filtered data to the GridView
        grdAIR.DataSource = myview
        grdAIR.DataBind()


        If pPurchase_Order.Rows.Count < 5 Then
            pPurchase_Order.Merge(CreateTable1(5 - pPurchase_Order.Rows.Count))
        End If
        grdAIR.DataSource = myview
        grdAIR.DataBind()
        grdAIR.SelectedIndex = -1


    End Sub

    ' Helper function to escape apostrophes in the search text
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    ' Handles filtering based on selected supplier
    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Create a DataView to filter the data
        Dim myview As DataView = pPurchase_Order.DefaultView

        ' Apply filter for Supplier Name
        myview.RowFilter = "SuppName LIKE '%" & replaceapostrophe(ddSupplier.SelectedItem.Text) & "%'"

        ' Bind filtered data to the GridView
        grdAIR.DataSource = myview
        grdAIR.DataBind()
    End Sub

    Protected Sub btnSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub rbALL_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case rbALL.SelectedIndex
            Case 0 ' MOOE (AllotmentClass = 2)
                AllotmentClass = 2
            Case 1 ' Capital Outlay (AllotmentClass = 3)
                AllotmentClass = 3
            Case Else
                AllotmentClass = 0 ' No filter, if needed
        End Select
        LoadrbALL() ' Re-load data with the filter applied
    End Sub

    Protected Sub LoadrbALL()
        ' Fetch data from the stored procedure
        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List]", CommandType.Text)

        ' Apply filter based on AllotmentClass value
        Dim filteredTable As DataTable = pPurchase_Order.Clone() ' Clone the structure of the original DataTable
        For Each row As DataRow In pPurchase_Order.Rows
            If (AllotmentClass = 2 And row("AllotmentClass_ID") = 2) OrElse (AllotmentClass = 3 And row("AllotmentClass_ID") = 3) OrElse AllotmentClass = 0 Then
                filteredTable.ImportRow(row) ' Import rows matching the filter
            End If
        Next

        ' Check the row count after filtering
        If filteredTable.Rows.Count < 5 Then
            ' Calculate how many rows to add
            Dim emptyRowsToAdd As Integer = 5 - filteredTable.Rows.Count
            ' Create empty rows and merge them into the DataTable
            Dim emptyRows As DataTable = CreateTable1(emptyRowsToAdd)
            filteredTable.Merge(emptyRows) ' Merge empty rows into the filtered DataTable
        End If

        ' Bind the filtered DataTable (with merged empty rows) to the GridView
        grdAIR.DataSource = filteredTable
        grdAIR.DataBind()

        ' Reset the selected index to avoid accidental row selection
        grdAIR.SelectedIndex = -1

        btnSave.Enabled = False
    End Sub

    Sub ClearTextBoxes(ParamArray textBoxes() As TextBox)
        For Each textBox As TextBox In textBoxes
            textBox.Text = String.Empty
        Next
    End Sub
    Protected Sub LoadAllItems()
        'disable qty value text
        Dim rcv1 As String
        'rcv1 = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

        rcv1 = pPurchase_Order.Rows(grdAIR.SelectedRow.RowIndex).Item("Received_ID").ToString()

        pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_Items] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & rcv1 & "','" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

        If pPurchase_Order_detail.Rows.Count < 5 Then
            pPurchase_Order_detail.Merge(CreateTable2(5 - pPurchase_Order_detail.Rows.Count))
        End If
        grdItems.DataSource = pPurchase_Order_detail
        grdItems.DataBind()

        CheckboxVerficationEnabling()
    End Sub
    Protected Sub grdAIR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If grdAIR.SelectedDataKey("POHdr_ID") = 0 Then
            ClearTextBoxes(txtSupplierName, txtPoNumber, txtPodate, txtInvoiceNumber, txtInvoiceDate, txtRemakrs)
            grdItems.DataSource = CreateTable2(5)
            grdItems.DataBind()
            btnSave.Enabled = False
        Else

            Dim invcNo As String = pPurchase_Order.Rows(grdAIR.SelectedRow.RowIndex).Item("InvoiceNo").ToString()

            txtSupplierName.Text = grdAIR.SelectedDataKey("SuppName")
            txtPoNumber.Text = grdAIR.SelectedDataKey("PO_No")
            txtPodate.Text = CType(grdAIR.SelectedDataKey("PO_Date"), Date).ToString("MM/dd/yyyy")

            If invcNo IsNot Nothing Then
                txtInvoiceNumber.Text = invcNo
            Else
                txtInvoiceNumber.Text = ""
            End If

            txtInvoiceDate.Text = Date.Today.ToString("MM/dd/yyyy")
            txtDateReceivedBy.Text = Date.Today.ToString("MM/dd/yyyy")

            LoadAllItems()

            Dim Rcv As New DataTable
            Rcv = objDerived.GetDataTable("Select * from HRMS.view_signatory where deptid = 7 and division_key = 86", CommandType.Text)
            ddReceiveBy.DataSource = Rcv
            ddReceiveBy.DataTextField = ("full_name")
            ddReceiveBy.DataValueField = ("Signatory_ID")
            ddReceiveBy.DataBind()
            ddReceiveBy.Items.Insert(0, "Select")

            btnReturn.Enabled = True
            btnSave.Enabled = False
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
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            AddTrace("btnReturn_Click: Function started.")

            '=============== CHECK IF PUBLIC BIDDING
            Dim POHdr_ID As String = grdAIR.SelectedDataKey("POHdr_ID").ToString()
            Dim pre_procurement_hdr_id As String = grdAIR.SelectedDataKey("pre_procurement_hdr_id").ToString()
            Dim Supplier_Id As String = grdAIR.SelectedDataKey("Supplier_Id").ToString()

            AddTrace("btnReturn_Click: POHdr_ID = " & POHdr_ID)
            AddTrace("btnReturn_Click: pre_procurement_hdr_id = " & pre_procurement_hdr_id)
            AddTrace("btnReturn_Click: Supplier_Id = " & Supplier_Id)

            Dim MOP_ID As Integer = objDerived.GetValue("SELECT mode_of_procurement_id FROM [AMS].[PO_Hdr] WHERE POHdr_ID = '" & POHdr_ID & "'", CommandType.Text)

            AddTrace("btnReturn_Click: Retrieved MOP_ID = " & MOP_ID)

            If MOP_ID = 1 Then
                AddTrace("btnReturn_Click: Public Bidding detected. Updating [Bid_Information].")
                objDerived.GetRecords("UPDATE [AMS].[Bid_Information] SET [withNTP] = 0 WHERE [pre_procurement_hdr_id] = '" & pre_procurement_hdr_id & "' AND [Supplier_ID] = '" & Supplier_Id & "'", CommandType.Text)
            Else
                AddTrace("btnReturn_Click: Not Public Bidding. Checking if PO was received.")

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT * FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & POHdr_ID & "'", CommandType.Text)

                AddTrace("btnReturn_Click: Received data count from Tb_Receiving = " & dt.Rows.Count)

                If dt.Rows.Count = 0 Then
                    AddTrace("btnReturn_Click: PO was NOT received. Setting isApproved = 0.")
                    objDerived.GetRecords("UPDATE AMS.PO_Hdr SET isApproved = 0 WHERE POHdr_ID = '" & POHdr_ID & "'", CommandType.Text)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been returned to PO approval.")
                    AddTrace("btnReturn_Click: PO approval status reset and message displayed.")
                Else
                    AddTrace("btnReturn_Click: PO was already received. Displaying message.")
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase Order was already received.")
                End If
            End If

            LoadSearchBy()
            AddTrace("btnReturn_Click: LoadSearchBy() executed.")

            btnReturn.Enabled = False
            AddTrace("btnReturn_Click: btnReturn disabled.")

        Catch ex As Exception
            AddTrace("btnReturn_Click: Exception occurred - " & ex.Message)
        End Try
    End Sub


    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)
    End Sub


    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '' Whenever a row-level checkbox changes, see if at least one item is checked
        'Dim atLeastOneChecked As Boolean = False

        'For Each row As GridViewRow In grdItems.Rows
        '    If row.RowType = DataControlRowType.DataRow Then
        '        Dim rowCb As CheckBox = TryCast(row.FindControl("CheckBox1"), CheckBox)
        '        If rowCb IsNot Nothing AndAlso rowCb.Checked Then
        '            atLeastOneChecked = True
        '            Exit For
        '        End If
        '    End If
        'Next

        '' Toggle btnSave based on whether we found at least one row checked
        'btnSave.Enabled = atLeastOneChecked

        CheckboxVerficationEnabling()
    End Sub

    Protected Sub txtMarketValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        'Try
        If txtInvoiceNumber Is Nothing Or txtInvoiceNumber.Text = "" Or txtInvoiceNumber.Text = "0" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Kindly ADD an Invoice Number for this P.O proper receiving process.")

            Exit Sub
        End If
        'Check if receiving exist and is returned

        Dim invcNoExist As Object = objDerived.GetValue("select AMS.Tb_Receiving.InvoiceNo from AMS.Tb_Receiving where AMS.Tb_Receiving.InvoiceNo =  '" & txtInvoiceNumber.Text & "' ", CommandType.Text)

        Dim rcvIdExist As Object

        If invcNoExist Is Nothing Or invcNoExist = "0" Then
            rcvIdExist = objDerived.GetValue("select AMS.Tb_Receiving.Received_ID from AMS.Tb_Receiving where AMS.Tb_Receiving.POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' ", CommandType.Text) 'from PO approval no Tb_Receiving yet.
        Else
            rcvIdExist = objDerived.GetValue("select AMS.Tb_Receiving.Received_ID from AMS.Tb_Receiving where AMS.Tb_Receiving.POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' and AMS.Tb_Receiving.InvoiceNo = '" & invcNoExist & "' ", CommandType.Text) 'Returned or items not yet received
        End If


        If txtInvoiceNumber.Text <> invcNoExist Then

            SaveReceivingHeaderAndDetail()

        ElseIf rcvIdExist IsNot Nothing Or rcvIdExist <> "" Then 'INVOICE EXIST, WILL MERGE WITH EXISTING INVOICE, UPDATE

            Dim rcv1 As Long = 0
            rcv1 = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

            'reset flag for if displaying to report or not:
            Dim resetIsDisplayReport = "update AMS.Tb_Receiving_Dtl set AMS.Tb_Receiving_Dtl.IsDisplayReport = 0 where AMS.Tb_Receiving_Dtl.Received_ID = '" & rcv1 & "' "
            objDerived.Execute(resetIsDisplayReport, CommandType.Text)

            Dim dt As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_Items] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & rcv1 & "','" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

            Dim cb1 As CheckBox

            If dt.Rows.Count > 0 Then
                Dim isReceiveDtlCreation As Boolean = False

                For xa As Integer = 0 To grdItems.Rows.Count - 1
                    cb1 = CType(Me.grdItems.Rows(xa).Cells(0).FindControl("CheckBox1"), CheckBox)
                    Dim txtQty As TextBox = CType(grdItems.Rows(xa).Cells(0).FindControl("txtQty"), TextBox)

                    If cb1.Visible AndAlso cb1.Checked Then
                        ' Extract values
                        Dim num As String = dt.Rows(xa).Item("Item_ID").ToString()
                        'Dim rcvID As String = dt.Rows(xa).Item("Received_ID").ToString()

                        Dim rcvID As String = rcvIdExist

                        Dim qty As String = dt.Rows(xa).Item("qty").ToString()

                        Dim receivedQtyTextValue As Decimal
                        If Not Decimal.TryParse(txtQty.Text, receivedQtyTextValue) Then receivedQtyTextValue = 0

                        Dim Cndtion As String = CType(grdItems.Rows(xa).FindControl("txtCondition"), TextBox).Text
                        Dim Lction As String = CType(grdItems.Rows(xa).FindControl("txtLocation"), TextBox).Text
                        Dim MarketValue As Decimal = CType(grdItems.Rows(xa).FindControl("txtMarketValue"), TextBox).Text

                        ' Check for existing Received_Dtl_ID
                        Dim RcvDtl_ID As Object = objDerived.GetValue("SELECT Received_Dtl_ID FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = '" & rcvID & "' AND Item_ID = '" & num & "'", CommandType.Text)

                        Dim count As Object = objDerived.GetValue("SELECT COUNT(*) FROM AMS.PO_Hdr WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

                        If IsDBNull(RcvDtl_ID) OrElse Convert.ToInt64(RcvDtl_ID) = 0 Then
                            ' === CREATE NEW ===
                            With rcv_dtl
                                .Received_ID = rcvID
                                .Item_ID = pPurchase_Order_detail.Rows(xa)("Item_ID")
                                .PO_Qty = pPurchase_Order_detail.Rows(xa)("qty")
                                If count >= 1 Then
                                    .Qty_Received = 0
                                Else
                                    .Qty_Received = Math.Abs(receivedQtyTextValue - qty)
                                End If
                                .Cost = pPurchase_Order_detail.Rows(xa)("cost")
                                .Condition = Cndtion
                                .Location = Lction
                                .Status = 1
                                .Qty_Inspecting = receivedQtyTextValue
                            End With

                            RcvDtl_ID = rcv_dtl.save

                            objDerived.Execute("UPDATE AMS.Tb_Receiving_Dtl SET OtherSpecs = '" & pPurchase_Order_detail.Rows(xa)("PO_Remarks") & "', MarketValue = '" & MarketValue & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)

                            isReceiveDtlCreation = True
                        Else
                            ' === UPDATE EXISTING ===
                            Dim Qty_ReceivingValue As Decimal = Convert.ToDecimal(objDerived.GetValue("SELECT ISNULL(Qty_Receiving, 0) FROM AMS.Tb_Receiving_Dtl WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text))
                            Dim Qty_InspectingValue As Decimal = Convert.ToDecimal(objDerived.GetValue("SELECT ISNULL(Qty_Inspecting, 0) FROM AMS.Tb_Receiving_Dtl WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text))

                            If receivedQtyTextValue > Qty_ReceivingValue Then
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The quantity desired to return is more than existing quantity. Reminder: Reload to see existing quantity.")
                                Exit Sub
                            End If

                            Dim calResult As Decimal = Math.Abs(Qty_ReceivingValue - receivedQtyTextValue)
                            Dim calResultInspecting As Decimal = Qty_InspectingValue + receivedQtyTextValue

                            objDerived.Execute("UPDATE AMS.Tb_Receiving_Dtl SET Qty_Receiving = '" & calResult & "', Qty_Inspecting = '" & calResultInspecting & "', MarketValue = '" & MarketValue & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
                        End If

                        ' Common updates for both create and update
                        objDerived.Execute("UPDATE AMS.Tb_Receiving_Dtl SET IsDisplayReport = 1, tempReportQuantity = '" & receivedQtyTextValue & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)

                        ' Check if all items handled
                        Dim dt2 As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_Items] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & rcv1 & "','" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                        If dt2.Rows.Count = 0 Then
                            objDerived.Execute("UPDATE AMS.Tb_Receiving SET Status = 1 WHERE Received_ID = " & rcvID, CommandType.Text)
                        End If

                        Session("Received_ID") = rcvID
                    End If
                Next

                If isReceiveDtlCreation Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Data is merged to existing invoice number successfully applied.")
                End If

            End If
        End If


        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        grdItems.DataSource = Nothing
        grdItems.DataBind()
        LoadrbALL()
        btnPreview.Enabled = True
        btnSave.Enabled = False


    End Sub

    'Protected Sub btnPreview_Click(sender As Object, e As EventArgs)
    '    Dim url As String = ResolveUrl("~/Reports and Query/RQ_Request_Inspection.aspx")
    '    Dim script As String = "window.open('" & url & "', '_blank');"
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)

    'End Sub

    Protected Sub chkSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' 1) Cast the sender to a CheckBox
        Dim headerCb As CheckBox = TryCast(sender, CheckBox)
        If headerCb Is Nothing Then Exit Sub

        ' 2) Determine if header checkbox is now checked or unchecked
        Dim isSelectAll As Boolean = headerCb.Checked

        ' 3) Loop through each row in the grdItems
        For Each row As GridViewRow In grdItems.Rows
            Dim txtQty As TextBox = CType(row.FindControl("txtQty"), TextBox)

            If row.RowType = DataControlRowType.DataRow Then
                ' Find the row-level checkbox, "CheckBox1"
                Dim rowCb As CheckBox = TryCast(row.FindControl("CheckBox1"), CheckBox)
                If rowCb IsNot Nothing AndAlso rowCb.Visible Then
                    ' 4) Set its Checked property to match the header
                    rowCb.Checked = isSelectAll
                End If
            End If

            ' 5) (Optional) If you want to enable/disable the Save button immediately:
            If isSelectAll Then
                ' We checked them all
                btnSave.Enabled = True
                btnReturn.Enabled = True
                txtQty.Enabled = True
            Else
                ' If unchecking all, you might want to disable Save 
                ' or keep it enabled if a user might re-check items manually
                btnReturn.Enabled = False
                txtQty.Enabled = False
                btnSave.Enabled = False
            End If
        Next


    End Sub



    Protected Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click


        ' 1) Verify we have a valid Received_ID in session
        If Session("Received_ID") Is Nothing OrElse Convert.ToInt64(Session("Received_ID")) = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No Received transaction found. Please save a receiving record first.")
            Exit Sub
        End If

        ' 2) (Optional) Set this so the back link on t_rpt_receiving can come back here
        Session("Page") = "Rcv"

        ' 3) Redirect (open in new tab) to your new receiving report page
        Dim url As String = ResolveUrl("~/procurement/t_rpt_receiving.aspx")
        Dim script As String = "window.open('" & url & "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)
    End Sub

    Protected Sub CheckboxVerficationEnabling()
        btnSave.Enabled = False

        Dim cb1 As CheckBox
        Dim isReturn As Boolean = False

        For i As Integer = 0 To grdItems.Rows.Count - 1
            cb1 = CType(Me.grdItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            Dim txtQty As TextBox = CType(grdItems.Rows(i).FindControl("txtQty"), TextBox)
            If cb1.Checked = True Then

                txtQty.Enabled = True
                btnReturn.Enabled = True

                'FLAGGING
                isReturn = True
            Else
                txtQty.Enabled = False
            End If

        Next

        btnReturn.Enabled = isReturn
        If ddReceiveBy.SelectedIndex > 0 Then
            btnSave.Enabled = True
        End If

    End Sub

    Protected Sub ddReceiveBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddReceiveBy.SelectedIndexChanged

        Dim cb1 As CheckBox
        Dim itemIsSelected As Boolean = False

        For i As Integer = 0 To grdItems.Rows.Count - 1
            cb1 = CType(Me.grdItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            Dim txtQty As TextBox = CType(grdItems.Rows(i).FindControl("txtQty"), TextBox)
            If cb1.Checked = True Then
                itemIsSelected = True

            End If
        Next

        If itemIsSelected = True And ddReceiveBy.SelectedIndex > 0 Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If

    End Sub

    Protected Sub txtInvoiceNumber_TextChanged(sender As Object, e As EventArgs)
        Dim invcNo As String = txtInvoiceNumber.Text

        Dim invoiceExist As String = objDerived.GetValue("Select AMS.Tb_Receiving.InvoiceNo from AMS.Tb_Receiving where AMS.Tb_Receiving.InvoiceNo = '" & invcNo & "' ", CommandType.Text)

        If invoiceExist IsNot Nothing Or invoiceExist <> "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "This items already have invoice number.")
        End If

    End Sub

    Protected Sub QtyText_TextChanged()

        Dim cb1 As CheckBox

        Dim rcv1 As Long = 0
        rcv1 = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

        Dim dt As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_Items] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & rcv1 & "','" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

        For xa As Integer = 0 To grdItems.Rows.Count - 1

            cb1 = CType(Me.grdItems.Rows(xa).Cells(0).FindControl("CheckBox1"), CheckBox)
            Dim txtQty As TextBox = CType(grdItems.Rows(xa).Cells(0).FindControl("txtQty"), TextBox)

            If cb1.Visible AndAlso cb1.Checked Then

                Dim RcvQty As Decimal = CType(CType(grdItems.Rows(xa).FindControl("txtQty"), TextBox).Text, Decimal)

                Dim qty1 As String = dt.Rows(xa).Item("qty").ToString()

                Dim Qty As Decimal

                If qty1 IsNot DBNull.Value Then
                    If Decimal.TryParse(qty1.ToString(), Qty) Then
                    End If
                End If

                If (RcvQty > Qty) Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Input Quantity is greater than existing Quantity, Reload to see existing quantity first.")

                    txtQty.Text = Qty

                    Exit Sub
                End If
            End If
        Next
    End Sub

    Protected Sub UpdateOldReceiveDtl()

        Dim rcv1 As Long = 0
        rcv1 = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

        Dim dt As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_Items] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & rcv1 & "','" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

        'for non existing Tb_Receiving_Hdr items
        If rcv1 = 0 Then
            Exit Sub
        End If

        Dim cb1 As CheckBox
        For xa As Integer = 0 To grdItems.Rows.Count - 1
            cb1 = CType(Me.grdItems.Rows(xa).Cells(0).FindControl("CheckBox1"), CheckBox)
            Dim txtQty As TextBox = CType(grdItems.Rows(xa).Cells(0).FindControl("txtQty"), TextBox)

            If cb1.Visible AndAlso cb1.Checked Then

                Dim num As String = dt.Rows(xa).Item("Item_ID").ToString()

                Dim oldrcvID As String = dt.Rows(xa).Item("Received_ID").ToString()

                Dim RcvDtl_ID As Object = objDerived.GetValue("SELECT Received_Dtl_ID FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = '" & oldrcvID & "' AND Item_ID = '" & num & "'", CommandType.Text) 'TODO BUGGED

                'for non existing Tb_Receiving_Dtl items
                If RcvDtl_ID Is Nothing Then
                    Exit Sub
                End If

                Dim qty1 As String = dt.Rows(xa).Item("qty").ToString()

                Dim receivedQtyTextValue As Decimal
                If Not Decimal.TryParse(txtQty.Text, receivedQtyTextValue) Then receivedQtyTextValue = 0

                Dim calResult As Decimal = Math.Abs(qty1 - receivedQtyTextValue)

                objDerived.Execute("UPDATE AMS.Tb_Receiving_Dtl SET Qty_Receiving = '" & calResult & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
            End If
        Next
    End Sub

    Protected Sub SaveReceivingHeaderAndDetail()

        Dim cb As CheckBox
        Session("cb") = 0

        For i As Integer = 0 To grdItems.Rows.Count - 1
            cb = CType(Me.grdItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
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

        If ddReceiveBy.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select received by and inspected by.")
            Exit Sub
        End If

        Dim receivedDate As String = Date.Today.ToString("MM/dd/yyyy")

        '--==========
        'UPDATE OLD DTL FIRST, dtl exist checker inside
        UpdateOldReceiveDtl()

        '=-= SAVE AMS.Tb_Receiving
        With rcv
            .Received_Date = txtDateReceivedBy.Text
            .ReceivedBY = ddReceiveBy.SelectedItem.Value
            .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID") 'basis for one to many realtionship of P.O -> Receiving(by invoice)
            .PO_No = grdAIR.SelectedDataKey("PO_No")
            .Supplier_ID = grdAIR.SelectedDataKey("Supplier_Id")
            .GA_ID = grdAIR.SelectedDataKey("GA_ID")
            .isAccepted = False
            .UserID = Session("@UserName")
            .Status = 1
        End With

        Dim RR_No As String

        Dim rcvID As Long

        rcvID = rcv.save

        RR_No = objDerived.GetValue("SELECT [AMS].[func_GenerateRR_No] ('" & txtDateReceivedBy.Text & "')", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET RR_No = '" & RR_No & "',InvoiceNo = '" & txtInvoiceNumber.Text & "' WHERE Received_ID = '" & rcvID & "'", CommandType.Text)


        Session("Received_ID") = rcvID

        'objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InspectedBy = '" & ddInspectedBy.SelectedItem.Value & "',InspectedBy2 = '" & ddInspectedBy2.SelectedItem.Value & "',InspectedBy3 = '" & ddInspectedBy3.SelectedItem.Value & "' WHERE Received_ID = '" & rcvID & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InspectedBy2 = 0 ,InspectedBy3 = 0 WHERE Received_ID = '" & rcvID & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.PO_Hdr SET isDelivered = 1  WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)


        For x As Integer = 0 To grdItems.Rows.Count - 1
            cb = CType(Me.grdItems.Rows(x).Cells(0).FindControl("CheckBox1"), CheckBox)
            If cb.Checked = True Then
                Dim RcvQty As Decimal = CType(CType(grdItems.Rows(x).FindControl("txtQty"), TextBox).Text, Decimal)
                Dim Cndtion As String = CType(CType(grdItems.Rows(x).FindControl("txtCondition"), TextBox).Text, String)
                Dim Lction As String = CType(CType(grdItems.Rows(x).FindControl("txtLocation"), TextBox).Text, String)
                Dim MarketValue As Decimal = CType(CType(grdItems.Rows(x).FindControl("txtMarketValue"), TextBox).Text, Decimal)

                Dim result As Object = objDerived.GetValue("SELECT AMS.PO_Dtl.qty FROM AMS.PO_Dtl WHERE POHdr_ID = '" & pPurchase_Order_detail.Rows(x)("POHdr_ID") & "'", CommandType.Text)
                Dim Qty As Decimal

                If result IsNot DBNull.Value Then
                    If Decimal.TryParse(result.ToString(), Qty) Then
                    End If
                End If

                Dim count As Object = objDerived.GetValue("SELECT COUNT(*) FROM AMS.PO_Hdr WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

                Dim FirstRcvID As Object = objDerived.GetValue("SELECT AMS.Tb_Receiving.Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

                If count >= 1 Then
                    Dim cal1Res = Math.Abs(RcvQty - Qty)

                    With rcv_dtl
                        .Received_ID = FirstRcvID '60264
                        .Item_ID = pPurchase_Order_detail.Rows(x)("Item_ID") '
                        .PO_Qty = pPurchase_Order_detail.Rows(x)("qty") 'objDerived.GetValue("SELECT qty FROM [dbo].[View_PO_ItemQty] WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' AND Item_ID = '" & pPurchase_Order_detail.Rows(x)("Item_ID") & "'", CommandType.Text)

                        .Qty_Received = cal1Res

                        .Cost = pPurchase_Order_detail.Rows(x)("cost")
                        .Condition = Cndtion
                        .Location = Lction
                        .Status = 1
                        .Qty_Inspecting = 0
                        .IsDisplayReport = 0
                        .tempReportQuantity = 0
                    End With

                    Dim RcvDtl_ID1 As Long = objDerived.GetValue("SELECT Received_Dtl_ID FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = '" & rcvID & "' AND Item_ID = '" & pPurchase_Order_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
                    RcvDtl_ID1 = rcv_dtl.save
                    objDerived.GetRecords("UPDATE AMS.Tb_Receiving_Dtl SET OtherSpecs = '" & pPurchase_Order_detail.Rows(x)("PO_Remarks") & "' ,MarketValue = '" & MarketValue & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID1 & "'", CommandType.Text)
                End If

                '=-= SAVE AMS.Tb_Receiving_Dtl
                With rcv_dtl
                    .Received_ID = rcvID
                    .Item_ID = pPurchase_Order_detail.Rows(x)("Item_ID")
                    .PO_Qty = pPurchase_Order_detail.Rows(x)("qty") 'objDerived.GetValue("SELECT qty FROM [dbo].[View_PO_ItemQty] WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' AND Item_ID = '" & pPurchase_Order_detail.Rows(x)("Item_ID") & "'", CommandType.Text)

                    If count >= 1 Then
                        .Qty_Received = 0
                    Else
                        .Qty_Received = Math.Abs(RcvQty - Qty)
                    End If

                    .Cost = pPurchase_Order_detail.Rows(x)("cost")
                    .Condition = Cndtion
                    .Location = Lction
                    .Status = 1
                    .Qty_Inspecting = RcvQty
                    .IsDisplayReport = 1
                    .tempReportQuantity = RcvQty
                End With

                Dim RcvDtl_ID As Long = objDerived.GetValue("SELECT Received_Dtl_ID FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = '" & rcvID & "' AND Item_ID = '" & pPurchase_Order_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
                If RcvDtl_ID = 0 Then
                    RcvDtl_ID = rcv_dtl.save
                    objDerived.GetRecords("UPDATE AMS.Tb_Receiving_Dtl SET OtherSpecs = '" & pPurchase_Order_detail.Rows(x)("PO_Remarks") & "' ,MarketValue = '" & MarketValue & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
                Else
                    rcv_dtl.Received_Dtl_ID = RcvDtl_ID
                    rcv_dtl.update()
                    objDerived.GetRecords("UPDATE AMS.Tb_Receiving_Dtl SET OtherSpecs = '" & pPurchase_Order_detail.Rows(x)("PO_Remarks") & "', MarketValue = '" & MarketValue & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)

                End If

            End If
        Next


        Session("Received_ID") = rcvID


    End Sub

End Class
