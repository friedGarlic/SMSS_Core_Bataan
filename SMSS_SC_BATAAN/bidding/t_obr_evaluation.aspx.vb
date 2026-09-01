Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class bidding_t_obr_evaluation
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim hdr As New t_obr_evaluation_hdr
    Dim dtl As New t_obr_evaluation_dtl
    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl

    Private C_hdr As New t_canvass_hdr
    Private C_dtl As New t_canvass_dtl
    Private getprofile As New ProfileCommon

#Region "property"
    Private Property pAMount() As DataTable
        Get
            Return CType(Session("pAMount"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAMount") = value
        End Set
    End Property

    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property
    Private Property pIncomingPR() As DataTable
        Get
            Return CType(Session("pIncomingPR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pIncomingPR") = value
        End Set
    End Property
    Private Property pPR_Detail() As DataTable
        Get
            Return CType(Session("pPR_Detail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPR_Detail") = value
        End Set
    End Property
#End Region
#Region "function"
    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("remarks", GetType(String))
        dt.Columns.Add("Transaction_type", GetType(Integer))
        dt.Columns.Add("DateApproved", GetType(Date))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("Function_Desc", GetType(String))
        dt.Columns.Add("isPublicInfra", GetType(Boolean))
        dt.Columns.Add("isStraight", GetType(Boolean))
        dt.Columns.Add("F_ID_Accntg", GetType(Long))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Project_ID", GetType(Long))
        dt.Columns.Add("Program_id", GetType(Long))
        dt.Columns.Add("isOnBid", GetType(Boolean))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("remarks") = DBNull.Value
            dr("Transaction_type") = DBNull.Value
            dr("DateApproved") = DBNull.Value
            dr("Function_Desc") = DBNull.Value
            dr("isPublicInfra") = DBNull.Value
            dr("isStraight") = DBNull.Value
            dr("F_ID_Accntg") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("Project_ID") = DBNull.Value
            dr("Program_id") = DBNull.Value
            dr("isOnBid") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            ddFund.DataSource = objDerived.GetRecords("select * from accntg.Funds_Parent", CommandType.Text)
            ddFund.DataTextField = ("Description")
            ddFund.DataValueField = ("FundClassno")
            ddFund.DataBind()
            ddFund.SelectedIndex = 0

            pIncomingPR = objDerived.GetDataTable("EXEC [AMS].[sp_OBR_Evaluation]", CommandType.Text)
            If pIncomingPR.Rows.Count < 5 Then
                pIncomingPR.Merge(createdatatable(5 - pIncomingPR.Rows.Count))
            End If
            gvIncomingPR.DataSource = pIncomingPR
            gvIncomingPR.DataBind()

            'LoadSignatories()

            gvGoods.DataSource = Nothing
            gvGoods.DataBind()

            pAMount = objDerived.GetDataTable("SELECT * FROM ams.mode_of_procurement where Active = 1", CommandType.Text)
            dd_mode_of_procurement.DataSource = pAMount
            dd_mode_of_procurement.DataTextField = ("mode_description2")
            dd_mode_of_procurement.DataValueField = ("mode_of_procurement_id")
            dd_mode_of_procurement.DataBind()

            btnPreview.Visible = False
            btnBACCertificate.Visible = False

        End If

        txtOBR_Search.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
    End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not Page.IsPostBack Then
    '        CheckUserAccess()
    '        BindFundsDropdown()
    '        LoadIncomingPR()
    '        LoadSignatories()
    '        InitializeGoodsGridView()
    '        BindProcurementModes()
    '        ConfigureSearch()
    '    End If
    'End Sub

    'Private Sub CheckUserAccess()
    '    obj.GetAccessRight(Me.Session("@UserName"), Page)
    '    If Not obj.HasAccess Then
    '        Response.Redirect("~/UnauthorizedAccess.aspx")
    '    End If
    'End Sub

    'Private Sub BindFundsDropdown()
    '    ddFund.DataSource = objDerived.GetRecords("SELECT * FROM accntg.Funds_Parent", CommandType.Text)
    '    ddFund.DataTextField = "Description"
    '    ddFund.DataValueField = "FundClassno"
    '    ddFund.DataBind()
    '    ddFund.SelectedIndex = 0
    'End Sub

    'Private Sub LoadIncomingPR()
    '    Dim pIncomingPR As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_OBR_Evaluation]", CommandType.Text)
    '    If pIncomingPR.Rows.Count < 5 Then
    '        pIncomingPR.Merge(createdatatable(5 - pIncomingPR.Rows.Count))
    '    End If
    '    gvIncomingPR.DataSource = pIncomingPR
    '    gvIncomingPR.DataBind()
    'End Sub



    'Private Sub InitializeGoodsGridView()
    '    gvGoods.DataSource = Nothing ' Explicitly setting to Nothing for clarity
    '    gvGoods.DataBind()
    'End Sub

    'Private Sub BindProcurementModes()
    '    Dim pAmount As DataTable = objDerived.GetDataTable("SELECT * FROM ams.mode_of_procurement", CommandType.Text)
    '    dd_mode_of_procurement.DataSource = pAmount
    '    dd_mode_of_procurement.DataTextField = "mode_description2"
    '    dd_mode_of_procurement.DataValueField = "mode_of_procurement_id"
    '    dd_mode_of_procurement.DataBind()
    'End Sub

    'Private Sub ConfigureSearch()
    '    txtOBR_Search.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
    'End Sub

    Protected Sub LoadSignatories()
        Dim dtBAC As New DataTable

        dtBAC = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, empsig_id, UPPER(Position_desc) as Position_desc  FROM dbo.View_BAC ORDER BY Name", CommandType.Text)
        ddBAC1.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND Code = 'BAC1' ", CommandType.Text)
        ddBAC1.DataTextField = ("Name")
        ddBAC1.DataValueField = ("empsig_id")
        ddBAC1.DataBind()

        ddBAC2.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND Code = 'BAC2' ", CommandType.Text)
        ddBAC2.DataTextField = ("Name")
        ddBAC2.DataValueField = ("empsig_id")
        ddBAC2.DataBind()

        ddBAC3.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND Code = 'BAC3' ", CommandType.Text)
        ddBAC3.DataTextField = ("Name")
        ddBAC3.DataValueField = ("empsig_id")
        ddBAC3.DataBind()

        ddBAC4.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND  Code = 'BAC4' ", CommandType.Text)
        ddBAC4.DataTextField = ("Name")
        ddBAC4.DataValueField = ("empsig_id")
        ddBAC4.DataBind()

        ddBAC5.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND Code = 'BAC5' ", CommandType.Text)
        ddBAC5.DataTextField = ("Name")
        ddBAC5.DataValueField = ("empsig_id")
        ddBAC5.DataBind()

        ddBACVC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 2", CommandType.Text)
        ddBACVC.DataTextField = ("Name")
        ddBACVC.DataValueField = ("empsig_id")
        ddBACVC.DataBind()

        ddBACC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 1", CommandType.Text)
        ddBACC.DataTextField = ("Name")
        ddBACC.DataValueField = ("empsig_id")
        ddBACC.DataBind()

        ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT empid, UPPER(full_name) AS full_name FROM HRMS.view_signatory WHERE deptid IN (1,2,3,8,13,104) AND division_key = 86 AND isDeptHead = 'Yes' ORDER BY full_name", CommandType.Text)
        ddApprovedBy.DataTextField = ("full_name")
        ddApprovedBy.DataValueField = ("empid")
        ddApprovedBy.DataBind()
        ddApprovedBy.Items.Insert(0, "Select")

    End Sub


    Private Sub ValidateSignatoriesDefault()
        txtIsInfra.Text = objDerived.Execute("SELECT isPublicInfra FROM ams.pr_hdr WHERE [prhdr_id] = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        Dim Service As String = txtIsInfra.Text

        Dim isInfra As String
        If Service = 0 Then
            isInfra = "Goods"
        Else
            isInfra = "Infrastructure"
        End If

        Dim dtCheck = objDerived.GetDataTable(
    "SELECT COUNT(*) AS Cnt " &
    "FROM [dbo].[View_BAC] " &
    "WHERE isActive = 1 " &
    "AND isDefault = 0 " &
    "AND isPublicInfra = '" & isInfra & "' " &
    "AND (Code IN ('BAC1','BAC2','BAC3','BAC4','BAC5') " &
    "     OR BAC_PostionID IN (1,2))", CommandType.Text)

        If dtCheck.Rows(0)("Cnt") > 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Please ensure that all BAC signatories are set as default in File Maintenance.")
            Exit Sub
        End If
    End Sub

    Protected Sub LoadSignatories1()
        Dim dtBAC As New DataTable
        txtIsInfra.Text = objDerived.Execute("SELECT isPublicInfra FROM ams.pr_hdr WHERE [prhdr_id] = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        Dim Service As String = txtIsInfra.Text

        Dim isInfra As String
        If Service = 0 Then
            isInfra = "Goods"
        Else
            isInfra = "Infrastructure"
        End If

        ddBAC1.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND Code = 'BAC1' AND isPublicInfra ='" & isInfra & "'", CommandType.Text)
        ddBAC1.DataTextField = "Name"
        ddBAC1.DataValueField = "empsig_id"
        ddBAC1.DataBind()

        ddBAC2.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND Code = 'BAC2' AND isPublicInfra ='" & isInfra & "'", CommandType.Text)
        ddBAC2.DataTextField = "Name"
        ddBAC2.DataValueField = "empsig_id"
        ddBAC2.DataBind()

        ddBAC3.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND Code = 'BAC3' AND isPublicInfra ='" & isInfra & "'", CommandType.Text)
        ddBAC3.DataTextField = "Name"
        ddBAC3.DataValueField = "empsig_id"
        ddBAC3.DataBind()

        ddBAC4.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND Code = 'BAC4' AND isPublicInfra ='" & isInfra & "'", CommandType.Text)
        ddBAC4.DataTextField = "Name"
        ddBAC4.DataValueField = "empsig_id"
        ddBAC4.DataBind()

        ddBAC5.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND Code = 'BAC5' AND isPublicInfra ='" & isInfra & "'", CommandType.Text)
        ddBAC5.DataTextField = "Name"
        ddBAC5.DataValueField = "empsig_id"
        ddBAC5.DataBind()

        ddBACVC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 2 AND isPublicInfra ='" & isInfra & "'", CommandType.Text)
        ddBACVC.DataTextField = "Name"
        ddBACVC.DataValueField = "empsig_id"
        ddBACVC.DataBind()

        ddBACC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 1 AND isPublicInfra ='" & isInfra & "'", CommandType.Text)
        ddBACC.DataTextField = "Name"
        ddBACC.DataValueField = "empsig_id"
        ddBACC.DataBind()

        ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT empid, UPPER(full_name) AS full_name FROM HRMS.view_signatory WHERE deptid IN (1,2,3,8,13,104) AND division_key = 86 AND isDeptHead = 'Yes' ORDER BY full_name", CommandType.Text)
        ddApprovedBy.DataTextField = "full_name"
        ddApprovedBy.DataValueField = "empid"
        ddApprovedBy.DataBind()
        ddApprovedBy.Items.Insert(0, "Select")
    End Sub



    Protected Sub LoadrbChoice()
        If RadioButtonList1.SelectedIndex = 0 Then
            pIncomingPR = objDerived.GetDataTable("EXEC [AMS].[sp_OBR_Evaluation]", CommandType.Text)
            If pIncomingPR.Rows.Count < 5 Then
                pIncomingPR.Merge(createdatatable(5 - pIncomingPR.Rows.Count))
            End If
            gvIncomingPR.DataSource = pIncomingPR
            gvIncomingPR.DataBind()

        Else

        End If
    End Sub

    Protected Sub gvIncomingPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ValidateSignatoriesDefault()
            LoadSignatories1()
            btnsave.Enabled = True
            If Lbtn = "lb" Then
                Dim cb As CheckBox = CType(gvIncomingPR.SelectedRow.FindControl("CheckBox1"), CheckBox)
                Dim lb As LinkButton = CType(gvIncomingPR.SelectedRow.FindControl("LinkButton1"), LinkButton)

                dd_mode_of_procurement.Enabled = True

                pPR_Detail = objDerived.GetDataTable("exec ams.sp_purchase_request_detail " & gvIncomingPR.SelectedDataKey(0) & "", CommandType.Text)
                gvGoods.DataSource = pPR_Detail
                gvGoods.DataBind()

                CType(gvGoods.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pPR_Detail.Compute("sum(total)", ""), 2)
                Dim data As DataTable = pIncomingPR

                If cb.Checked = False Then

                    If lb.Enabled = True Then
                        cb.Checked = True
                        pIncomingPR.Rows(gvIncomingPR.SelectedIndex)("isChecked") = True
                        Dim x As Integer = pIncomingPR.Rows(gvIncomingPR.SelectedIndex)("prhdr_id")
                    Else
                        cb.Checked = False
                        pIncomingPR.Rows(gvIncomingPR.SelectedIndex)("isChecked") = False
                    End If

                    Dim dt1 As New DataTable
                    dt1 = pIncomingPR

                Else
                    cb.Checked = False
                    pIncomingPR.Rows(gvIncomingPR.SelectedIndex)("isChecked") = False
                    pIncomingPR.Compute("count(isChecked)", "isChecked=true")
                    If pIncomingPR.Compute("count(isChecked)", "isChecked=true") = 0 Then
                        For i As Integer = 0 To Me.gvIncomingPR.Rows.Count - 1
                            Dim lb2 As LinkButton = CType(gvIncomingPR.Rows(i).FindControl("LinkButton1"), LinkButton)
                            lb2.Enabled = True
                        Next
                        dd_mode_of_procurement.Enabled = False
                        dd_mode_of_procurement.SelectedIndex = 0
                    End If
                    gvGoods.DataSource = Nothing
                    gvGoods.DataBind()

                End If


                btnsave.Enabled = True

            ElseIf Lbtn = "cb" Then
                pPR_Detail = objDerived.GetDataTable("exec ams.sp_purchase_request_detail " & gvIncomingPR.SelectedDataKey(0) & "", CommandType.Text)
                gvGoods.DataSource = pPR_Detail
                gvGoods.DataBind()

            ElseIf Lbtn = "lbView" Then
                Session("prhdr_id") = gvIncomingPR.SelectedDataKey("prhdr_id")
                Me.Page.Response.Redirect("~/bidding/rpt_obr_evaluation_canvass.aspx")

            End If

        Catch ex As Exception
        End Try
    End Sub

    'Protected Sub gvIncomingPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvIncomingPR.SelectedIndexChanged
    '    Try
    '        LoadSignatories1()  ' Assuming this method sets up signatory information correctly.
    '        btnsave.Enabled = True  ' Enable the save button by default.

    '        Select Case Lbtn  ' Assuming Lbtn is a variable that holds the type of action triggered.
    '            Case "lb"
    '                HandleLinkButtonSelection()
    '            Case "cb"
    '                LoadPurchaseRequestDetails()
    '            Case "lbView"
    '                RedirectToEvaluationCanvas()
    '        End Select
    '    Catch ex As Exception
    '        ' Log the error or handle it according to your application's error management practices.
    '    End Try
    'End Sub

    Private Sub HandleLinkButtonSelection()
        Dim cb As CheckBox = CType(gvIncomingPR.SelectedRow.FindControl("CheckBox1"), CheckBox)
        Dim lb As LinkButton = CType(gvIncomingPR.SelectedRow.FindControl("LinkButton1"), LinkButton)
        dd_mode_of_procurement.Enabled = True

        LoadPurchaseRequestDetails()

        ToggleCheckboxState(cb, lb)
    End Sub

    Private Sub LoadPurchaseRequestDetails()
        Dim prDetailSQL As String = "EXEC ams.sp_purchase_request_detail " & gvIncomingPR.SelectedDataKey(0).ToString()
        pPR_Detail = objDerived.GetDataTable(prDetailSQL, CommandType.Text)
        gvGoods.DataSource = pPR_Detail
        gvGoods.DataBind()

        If gvGoods.FooterRow IsNot Nothing Then
            Dim lblTotal As Label = CType(gvGoods.FooterRow.FindControl("lbltotal"), Label)
            lblTotal.Text = FormatNumber(pPR_Detail.Compute("SUM(total)", ""), 2)
        End If
    End Sub

    Private Sub RedirectToEvaluationCanvas()
        Session("prhdr_id") = gvIncomingPR.SelectedDataKey("prhdr_id").ToString()
        Response.Redirect("~/bidding/rpt_obr_evaluation_canvass.aspx")
    End Sub

    Private Sub ToggleCheckboxState(cb As CheckBox, lb As LinkButton)
        Dim isSelected As Boolean = cb.Checked

        If lb.Enabled Then
            cb.Checked = Not isSelected
            pIncomingPR.Rows(gvIncomingPR.SelectedIndex)("isChecked") = Not isSelected

            If Not isSelected Then
                ' Logic for when checkbox becomes checked
                Dim rowIndex As Integer = gvIncomingPR.SelectedIndex
                pIncomingPR.Rows(rowIndex)("isChecked") = True
            Else
                ' Logic for when checkbox becomes unchecked
                pIncomingPR.Rows(gvIncomingPR.SelectedIndex)("isChecked") = False
                RefreshLinkButtonsState()
            End If
        End If
    End Sub

    Private Sub RefreshLinkButtonsState()
        Dim allUnchecked As Boolean = Convert.ToInt32(pIncomingPR.Compute("COUNT(isChecked)", "isChecked = True")) = 0

        If allUnchecked Then
            For Each row As GridViewRow In gvIncomingPR.Rows
                Dim lb2 As LinkButton = CType(row.FindControl("LinkButton1"), LinkButton)
                lb2.Enabled = True
            Next
            dd_mode_of_procurement.Enabled = False
            dd_mode_of_procurement.SelectedIndex = 0
        End If
    End Sub

    Protected Sub ddSearchOption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddSearchOption.SelectedIndexChanged
        If ddSearchOption.SelectedItem.Value = 1 Then
            Session("BAC Members") = "seven"
            LoadSignatoryEnable()
            ddBAC4.Enabled = True
            ddBAC5.Enabled = True
        ElseIf ddSearchOption.SelectedItem.Value = 2 Then
            Session("BAC Members") = "five"
            LoadSignatoryEnable()
            ddBAC4.Enabled = False
            ddBAC5.Enabled = False
        End If
    End Sub

    Protected Sub LoadSignatoryEnable()
        Dim controls As List(Of Control) = New List(Of Control) From {
            ddBAC1,
            ddBAC2,
            ddBAC3,
            ddBAC4,
            ddBAC5,
            ddBACVC,
            ddBACC,
            ddApprovedBy
        }

        For Each control As Control In controls
            If TypeOf control Is WebControl Then
                CType(control, WebControl).Enabled = True
            End If
        Next
    End Sub

    '10112024 EM
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Identify the current GridView row containing the checkbox
        Dim currentRow As GridViewRow = CType(CType(sender, CheckBox).NamingContainer, GridViewRow)

        ' Automatically select or deselect the row's corresponding LinkButton1 based on checkbox state
        Dim lb As LinkButton = CType(currentRow.FindControl("LinkButton1"), LinkButton)
        Dim cb As CheckBox = CType(currentRow.FindControl("CheckBox1"), CheckBox)

        If lb IsNot Nothing AndAlso cb IsNot Nothing Then
            If cb.Checked Then
                ' Checkbox is checked, select the row and corresponding LinkButton1
                lb.CommandName = "Select"
                lb_Click(lb, New EventArgs()) ' Trigger the same behavior as clicking LinkButton1
                gvIncomingPR.SelectedIndex = currentRow.RowIndex ' Select the row

                ' Enable the signatories section just like when LinkButton1 is clicked
                LoadSignatories1()

                ' Make the Mode of Procurement editable
                dd_mode_of_procurement.Enabled = True

                ' Load and display the List of Goods
                pPR_Detail = objDerived.GetDataTable("exec ams.sp_purchase_request_detail " & gvIncomingPR.SelectedDataKey(0).ToString() & "", CommandType.Text)
                gvGoods.DataSource = pPR_Detail
                gvGoods.DataBind()

                ' Enable the save button
                btnsave.Enabled = True
            Else
                ' Checkbox is unchecked, deselect the row and disable the signatories
                gvIncomingPR.SelectedIndex = -1 ' Deselect the row
                btnsave.Enabled = False ' Disable the save button if no row is selected

                ' Disable the Mode of Procurement dropdown
                dd_mode_of_procurement.Enabled = False

                ' Clear the List of Goods and hide it
                gvGoods.DataSource = Nothing
                gvGoods.DataBind()
            End If
        End If

        ' Set Lbtn to "cb" to signify the checkbox action
        Lbtn = "cb"
    End Sub

    '10112024 EM
    Protected Sub lb_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Manually trigger selection of the row
        gvIncomingPR.SelectedIndex = CType(CType(sender, LinkButton).NamingContainer, GridViewRow).RowIndex
        gvIncomingPR_SelectedIndexChanged(sender, e)
    End Sub


    'Original CheckBox1_
    'Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Lbtn = "cb"
    'End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "lb"
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            AddTrace("btnsave_Click: Entering first try block for signatory checks.")
            Session("HBS_ID") = objDerived.GetValue("SELECT TOP(1) ISNULL([empsig_id],0) FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 7", CommandType.Text)
            AddTrace("btnsave_Click: HBS_ID retrieved = " & Session("HBS_ID"))

            If ddBAC1.SelectedItem.Text = "" Or ddBAC2.SelectedItem.Text = "" Or ddBAC3.SelectedItem.Text = "" Or ddBAC4.SelectedItem.Text = "" Then
                AddTrace("btnsave_Click: One of the ddBAC text fields is empty.")
            ElseIf ddBACVC.SelectedItem.Text = "" Or ddBACC.SelectedItem.Text = "" Then
                AddTrace("btnsave_Click: ddBACVC or ddBACC text field is empty.")
            ElseIf ddApprovedBy.SelectedItem.Text = "Select" Then
                AddTrace("btnsave_Click: ddApprovedBy is 'Select'.")
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Select signatory")
                Exit Sub
            ElseIf Session("HBS_ID") = 0 Then
                AddTrace("btnsave_Click: HBS_ID is 0.")
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Update default BAC Head Secretariat in File Maintenance.")
                Exit Sub
            End If
        Catch ex As Exception
            AddTrace("btnsave_Click: Exception in first try block - " & ex.Message)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Set default BAC signatories in File Maintenance.")
            Exit Sub
        End Try

        '===============================================================================

        Try
            AddTrace("btnsave_Click: Entering second try block for main processing.")
            If RadioButtonList1.SelectedIndex = 0 Then
                AddTrace("btnsave_Click: RadioButtonList1.SelectedIndex is 0.")
                Dim GAID As Integer = 0
                Dim GAID2 As Integer = 0

                For i As Integer = 0 To Me.gvIncomingPR.Rows.Count - 1
                    If CType(gvIncomingPR.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True Then
                        AddTrace("btnsave_Click: Checkbox in row " & i & " is checked.")
                        GAID = objDerived.GetValue("SELECT GA_ID FROM AMS.PR_Hdr WHERE prhdr_id = '" & pIncomingPR.Rows(i)("prhdr_id") & "'", CommandType.Text)
                        AddTrace("btnsave_Click: GAID for row " & i & " is " & GAID)
                        If GAID2 = 0 Then
                            GAID2 = GAID
                            AddTrace("btnsave_Click: GAID2 set to " & GAID)
                        Else
                            If GAID2 <> GAID Then
                                AddTrace("btnsave_Click: Different GAIDs detected. GAID2 = " & GAID2 & ", current GAID = " & GAID)
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Selected transactions have different accounts.")
                                Exit Sub
                            End If
                        End If
                    End If
                Next

                Session("GA_ID") = GAID
                AddTrace("btnsave_Click: GA_ID session set to " & GAID)
                '=-= SAVE OBR_Evaluation Hdr
                hdr.transaction_date = Date.Today.ToString("MM/dd/yyyy")
                hdr.mode_of_procurement_id = dd_mode_of_procurement.SelectedItem.Value
                hdr.datePreProcurement = "01/01/1900"
                hdr.withPreProcurement = False
                hdr.F_ID = pIncomingPR.Rows(0)("F_ID_Accntg")
                hdr.UserID = Session("@UserName")
                AddTrace("btnsave_Click: Saving obr_evaluation_hdr.")
                Dim hdrid As Long = hdr.save()
                AddTrace("btnsave_Click: obr_evaluation_hdr saved with ID = " & hdrid)



                objDerived.GetRecords("UPDATE [AMS].[obr_evaluation_hdr] SET [BAC1] = '" & ddBAC1.SelectedItem.Value & "',[BAC2] = '" & ddBAC2.SelectedItem.Value & "', " & " [BAC3] = '" & ddBAC3.SelectedItem.Value & "',[BAC4] = '" & ddBAC4.SelectedItem.Value & "',[BAC5]='" & ddBAC5.SelectedItem.Value & "',[BACVC] = '" & ddBACVC.SelectedItem.Value & "',[BACC] = '" & ddBACC.SelectedItem.Value & "', " &
                                    " [ApprovedBy] = '" & ddApprovedBy.SelectedItem.Value & "' WHERE [obr_evaluation_hdr_id] = '" & hdrid & "'", CommandType.Text)

                AddTrace("btnsave_Click: Updated obr_evaluation_hdr with signatories.")

                objDerived.GetRecords("UPDATE [AMS].[obr_evaluation_hdr] SET [BAC1] = '" & ddBAC1.SelectedItem.Value & "',[BAC2] = '" & ddBAC2.SelectedItem.Value & "', " & " [BAC3] = '" & ddBAC3.SelectedItem.Value & "',[BAC4] = '" & ddBAC4.SelectedItem.Value & "',[BAC5]='" & ddBAC5.SelectedItem.Value & "',[BACVC] = '" & ddBACVC.SelectedItem.Value & "',[BACC] = '" & ddBACC.SelectedItem.Value & "', " &
                                    " [ApprovedBy] = '" & ddApprovedBy.SelectedItem.Value & "' WHERE [obr_evaluation_hdr_id] = '" & hdrid & "'", CommandType.Text)



                Session("obr_evaluation_hdr_id") = hdrid
                AddTrace("btnsave_Click: Session obr_evaluation_hdr_id set to " & hdrid)

                Dim x As Integer = 0
                Dim TotalABC As Decimal = 0
                For i As Integer = 0 To Me.gvIncomingPR.Rows.Count - 1
                    If CType(gvIncomingPR.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True Then
                        AddTrace("btnsave_Click: Processing checked row " & i)
                        Dim x2 As Integer = pIncomingPR.Rows(i)("prhdr_id")
                        AddTrace("btnsave_Click: prhdr_id for row " & i & " is " & x2)
                        dtl.obr_evaluation_hdr_id = hdrid
                        dtl.prhdr_id = pIncomingPR.Rows(i)("prhdr_id")
                        dtl.withPreProcurement = False
                        dtl.save()
                        AddTrace("btnsave_Click: Saved evaluation detail for row " & i)

                        If dd_mode_of_procurement.SelectedItem.Value = "7" Then
                            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isOnBid = 1,mode_of_procurement_id = 6 '" & "' WHERE prhdr_id=" & pIncomingPR.Rows(i)("prhdr_id") & "", CommandType.Text)


                        Else
                            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isOnBid = 1,mode_of_procurement_id = '" & dd_mode_of_procurement.SelectedItem.Value & "' WHERE prhdr_id=" & pIncomingPR.Rows(i)("prhdr_id") & "", CommandType.Text)

                        End If



                        AddTrace("btnsave_Click: Updated PR_Hdr for row " & i)
                        x = x + 1
                        TotalABC = TotalABC + pIncomingPR.Rows(i)("ABC")
                        AddTrace("btnsave_Click: Accumulated TotalABC = " & TotalABC)
                    End If
                Next

                '======================================================================
                '   AUTO SAVE FOR CONSOLIDATED PURCHASE REQUEST, FOR APPROVAL
                '======================================================================
                If x > 1 Then
                    AddTrace("btnsave_Click: More than one PR processed, initiating consolidated PR save.")
                    Dim prhdrID As Long
                    '=-= Saving PR_Hdr (Goods)
                    prhdr.PR_Year = Year(Date.Today.ToString("MM/dd/yyyy"))
                    prhdr.PR_Date = "01/01/1900"
                    prhdr.RC_ID = 1
                    prhdr.Function_ID = 86
                    prhdr.remarks = "Consolidated Purchase Request"
                    prhdr.Transaction_type = 2
                    prhdr.Project_ID = 0
                    prhdr.Program_id = 0
                    prhdr.ABC = TotalABC
                    prhdr.Requestedby = objDerived.GetValue("SELECT ISNULL(empid,0) FROM HRMS.view_signatory WHERE deptid = 7 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                    prhdr.Approvedby = objDerived.GetValue("SELECT ISNULL(empid,0) FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                    prhdr.Date_Submitted = Date.Today.ToString("MM/dd/yyyy")
                    prhdr.Date_gso_rcv = Date.Today.ToString("MM/dd/yyyy")
                    prhdr.IsCancelled = False
                    prhdr.IsApproved = False
                    prhdr.isOnBid = False
                    prhdr.POHdr_ID = 0
                    prhdr.withWinner = False
                    prhdr.withPO = False
                    prhdr.declarationDate = "01/01/1900"
                    prhdr.rcv_date = Date.Today.ToString("MM/dd/yyyy")
                    prhdr.isPublicInfra = False
                    prhdr.isStraight = False
                    prhdr.DateApproved_PR_Mayor = "01/01/1900"
                    prhdr.DateReceived_PR_Mayor = Date.Today.ToString("MM/dd/yyyy")
                    prhdr.isApproved_PR_Mayor = False
                    prhdr.isReceived_PR_Mayor = True
                    prhdr.DateDisApprove = "01/01/1900"
                    prhdr.isGasoline = False
                    prhdr.pr_period_key_id = 0
                    prhdr.pr_invoice_hdr_id = 0
                    prhdr.isReimbursement = False
                    prhdr.isContract = False
                    prhdr.isEditable = False
                    prhdr.RequestingOfficer = ""
                    prhdr.Position = ""
                    prhdr.isContinuing = False
                    prhdr.mode_of_procurement_id = 0
                    prhdr.isTrustFund = False
                    prhdr.GA_ID = Session("GA_ID")
                    prhdr.UserID = Session("@UserName")
                    prhdr.CheckBy = 0
                    prhdr.NotedBy = 0

                    prhdrID = prhdr.save
                    AddTrace("btnsave_Click: Consolidated PR_Hdr saved with ID = " & prhdrID)
                    Session("PRNo") = prhdrID
                    Session("prhdr_id") = prhdrID
                    AddTrace("btnsave_Click: Session PRNo and prhdr_id set to " & prhdrID)

                    Dim CTO As Integer
                    CTO = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                    AddTrace("btnsave_Click: Retrieved CTO = " & CTO)
                    objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = 1, CityTreasurer = '" & CTO & "',isConsolidated = 1 WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)
                    AddTrace("btnsave_Click: Updated PR_Hdr for consolidated purchase request with CityTreasurer = " & CTO)

                    '==== UPDATE EVERY INDIVIDUAL PR ====
                    For i As Integer = 0 To Me.gvIncomingPR.Rows.Count - 1
                        If CType(gvIncomingPR.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True Then
                            AddTrace("btnsave_Click: Updating individual PR for row " & i)
                            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET PR_ConsoID = '" & Session("prhdr_id") & "' WHERE prhdr_id = '" & pIncomingPR.Rows(i)("prhdr_id") & "'", CommandType.Text)
                        End If
                    Next

                    '=== Saving PR_Dtl ===
                    objDerived.GetRecords("EXEC [AMS].[sp_SaveConsolidatePR_Dtl] '" & hdrid & "','" & Session("prhdr_id") & "'", CommandType.Text)
                    AddTrace("btnsave_Click: Executed stored procedure to save consolidated PR_Dtl.")
                End If

                '======================================================================
                '   END FOR CONSOLIDATED PURCHASE REQUEST
                '======================================================================
            Else
                AddTrace("btnsave_Click: RadioButtonList1.SelectedIndex is not 0.")
            End If

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been succesfully saved.")
            AddTrace("btnsave_Click: Transaction saved message displayed.")
            LoadrbChoice()
            AddTrace("btnsave_Click: LoadrbChoice() executed.")

            pAMount = objDerived.GetDataTable("SELECT * FROM ams.mode_of_procurement", CommandType.Text)
            AddTrace("btnsave_Click: Retrieved mode_of_procurement data.")
            dd_mode_of_procurement.DataSource = pAMount
            dd_mode_of_procurement.DataTextField = ("mode_description2")
            dd_mode_of_procurement.DataValueField = ("mode_of_procurement_id")
            dd_mode_of_procurement.DataBind()
            dd_mode_of_procurement.Items.Insert(0, "Select")
            AddTrace("btnsave_Click: dd_mode_of_procurement bound with data.")

            gvGoods.DataSource = Nothing
            gvGoods.DataBind()
            AddTrace("btnsave_Click: gvGoods cleared.")

            btnsave.Enabled = False
            btnPreview.Enabled = True
            btnBACCertificate.Enabled = True
            AddTrace("btnsave_Click: Buttons updated: btnsave disabled, btnPreview and btnBACCertificate enabled.")
            LoadSignatories()
            AddTrace("btnsave_Click: LoadSignatories() executed.")

            ''HERE 
            txtDateFrom.Text = Date.Today.ToString("MM/dd/yyyy")
            txtDateTo.Text = Date.Today.ToString("MM/dd/yyyy")
            txtDateIssued.Text = Date.Today.ToString("MM/dd/yyyy")
            AddTrace("btnsave_Click: Date fields updated.")
            '' ModalPopupExtendepopup.Show()

        Catch ex As Exception
            AddTrace("btnsave_Click: Exception occurred - " & ex.Message)
            MsgBox(ex.Message)
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



    Protected Sub ddFund_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            LoadrbChoice()

            dd_mode_of_procurement.Enabled = False
            dd_mode_of_procurement.SelectedIndex = 0

            pPR_Detail = Nothing
            gvGoods.DataSource = Nothing
            gvGoods.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "lbView"
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        pIncomingPR = Nothing
        ddFund.SelectedIndex = 0

        LoadrbChoice()

        dd_mode_of_procurement.Enabled = False
        dd_mode_of_procurement.SelectedIndex = 0

        pPR_Detail = Nothing
        gvGoods.DataSource = Nothing
        gvGoods.DataBind()

    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "lb"
    End Sub



    Protected Sub gvGoods_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub dd_mode_of_procurement_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pIncomingPR = objDerived.GetDataTable("EXEC [AMS].[sp_OBR_Evaluation_Search] '" & txtOBR_Search.Text & "'", CommandType.Text)
        gvIncomingPR.DataSource = pIncomingPR
        gvIncomingPR.DataBind()

        'Dim myview As DataView
        'myview = pIncomingPR.DefaultView
        'myview.RowFilter = "pr_no like '%" & txtOBR_Search.Text & "%'"
        'gvIncomingPR.DataSource = myview
        'gvIncomingPR.DataBind()

    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "OBR_Eval"
        Session("Report") = "AMP"
        Dim url As String = "rpt_AlternativeMode.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
        'Me.Page.Response.Redirect("~/bidding/rpt_AlternativeMode.aspx")
    End Sub

    Protected Sub btnBACCertificate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtDateFrom.Text = Date.Today.ToString("MM/dd/yyyy")
        txtDateTo.Text = Date.Today.ToString("MM/dd/yyyy")
        txtDateIssued.Text = Date.Today.ToString("MM/dd/yyyy")

        ModalPopupExtendepopup.Show()

    End Sub

    Protected Sub btnBACCertSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            objDerived.GetRecords("UPDATE [AMS].[obr_evaluation_hdr] SET [BACCert_DateFrom] = '" & txtDateFrom.Text & "',[BACCert_DateTo] = '" & txtDateTo.Text & "',[BACCert_Issued] = '" & txtDateIssued.Text & "', [BAC_HBS] = '" & Session("HBS_ID") & "' WHERE [obr_evaluation_hdr_id] = '" & Session("obr_evaluation_hdr_id") & "'", CommandType.Text)

            Dim url As String = "rpt_BAC_Certification.aspx?"
            Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        Catch ex As Exception

        End Try
    End Sub
End Class
