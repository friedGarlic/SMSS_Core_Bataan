Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO


Partial Class procurement_t_purchased_request_trustfund
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl
    Private pr_obr As New PR_OBR
    Private obr_hdr As New t_purchase_request_obr_hdr
    Private obr_dtl As New t_purchase_request_obr_dtl
    Private obr_Adjsutment_hdr As New t_purchase_request_obr_adjustment_hdr
    Private obr_Adjsutment_dtl As New t_purchase_request_obr_adjustment_dtl
    Private disbursement As New t_Purchase_request_disbursement
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim image As New Image
    Dim ImageDocument As New ImageDocument
    Dim dtRep As New DataTable
    Dim objRep_Dtl As New t_RepairAndMaintenance.TbRepair_Dtl
    Private getprofile As New ProfileCommon


#Region "property"
    Private pPRTable As DataTable
    Public Property PRTable() As DataTable
        Get
            Return pPRTable
        End Get
        Set(ByVal value As DataTable)
            pPRTable = value
        End Set
    End Property

    Private Property porgibody() As DataTable
        Get
            Return CType(Session("porgibody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("porgibody") = value
        End Set
    End Property

    Private Property rolename() As String
        Get
            Return CType(Session("rolename"), String)
        End Get
        Set(ByVal value As String)
            Session("rolename") = value
        End Set
    End Property
    Private Property datahdr() As DataTable
        Get
            Return CType(Session("datahdr"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("datahdr") = value
        End Set
    End Property
    Private Property pPRlist() As DataTable
        Get
            Return CType(Session("pPRlist"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPRlist") = value
        End Set
    End Property
    Private Property pBudgetInfo() As DataTable
        Get
            Return CType(Session("pBudgetInfo"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBudgetInfo") = value
        End Set
    End Property
    Private Property PAPS() As DataTable
        Get
            Return CType(Session("PAPS"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PAPS") = value
        End Set
    End Property
    Private Property pRoleName() As DataTable
        Get
            Return CType(Session("pRoleName"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRoleName") = value
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
    Private Property pApprovedPR() As DataTable
        Get
            Return CType(Session("pApprovedPR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pApprovedPR") = value
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

    Private Property pFunction() As DataTable
        Get
            Return CType(Session("pFunction"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pFunction") = value
        End Set
    End Property

    Private Property pRC() As DataTable
        Get
            Return CType(Session("pRC"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRC") = value
        End Set
    End Property
    Private Property popen() As DataTable
        Get
            Return CType(Session("popen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("popen") = value
        End Set
    End Property
    Private Property pOnloadData() As DataTable
        Get
            Return CType(Session("pOnloadData"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pOnloadData") = value
        End Set
    End Property

    Private Property pitems() As DataTable
        Get
            Return CType(Session("pitems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pitems") = value
        End Set

    End Property

    Private Property pBody() As DataTable
        Get
            Return CType(Session("pBody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBody") = value
        End Set
    End Property

    Private Property p_GA_ID() As DataTable
        Get
            Return CType(Session("p_GA_ID"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("p_GA_ID") = value
        End Set
    End Property
    Private Property pAccounts() As DataTable
        Get
            Return CType(Session("pAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAccounts") = value
        End Set

    End Property
#End Region
#Region "function"

    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("InputQty", GetType(Integer))
        dt.Columns.Add("total", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("BGA_ID", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("cost") = DBNull.Value
            dr("InputQty") = DBNull.Value
            dr("total") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("BGA_ID") = DBNull.Value
            dr("id") = DBNull.Value
            dt.Rows.Add(dr)

        Next
        Return dt

    End Function

    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("Remarks", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("Date_Submitted", GetType(Date))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("Remarks") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("Date_Submitted") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function createdatatable1Repair(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("NatureRepair", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("NatureRepair") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("InputQty", GetType(Integer))
        dt.Columns.Add("qty", GetType(Integer))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("total", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("ReadOnly", GetType(Boolean))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("BGA_ID", GetType(Integer))
        dt.Columns.Add("GA_Code2", GetType(String))
        dt.Columns.Add("Project_title", GetType(String))
        dt.Columns.Add("PR_ItemSpecs", GetType(String))
        dt.Columns.Add("ppmp_dtl_id", GetType(Long))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("id") = 0
            dr("Item_Desc") = ""
            dr("Description") = ""
            dr("InputQty") = 0
            dr("qty") = 0
            dr("cost") = "0.00"
            dr("total") = "0.00"
            dr("Item_ID") = 0
            dr("isVisible") = False
            dr("ReadOnly") = True
            dr("GA_ID") = 0
            dr("BGA_ID") = 0
            dr("GA_Code2") = ""
            dr("Project_title") = ""
            dr("PR_ItemSpecs") = ""
            dr("ppmp_dtl_id") = 0
            dt.Rows.Add(dr)

        Next
        Return dt

    End Function
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                rbTrustFund.SelectedItem.Value = 3
                cbReinbursement.Checked = False

                txtprdate.Text = Date.Today.ToString("MM/dd/yyyy")

                Session("CYear") = "CY" & Year(txtprdate.Text)

                Session("RoleName") = rolename
                pRoleName = objDerived.GetDataTable("EXEC [dbo].[sp_GetRC_ByRole_systemManager] '" & rolename & "'", CommandType.Text)

                gvbody.Columns(0).Visible = False

                pRC = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RespCenter_withFunctions] WHERE FUNCTION_ID = 86 ORDER BY RC_NAME", CommandType.Text)
                ddRC.DataSource = CType(pRC, DataTable)
                ddRC.DataTextField = ("RC_Name")
                ddRC.DataValueField = ("RC_ID")
                ddRC.DataBind()
                ddRC.Items.Insert(0, "Select")

                Session("Current") = 0

                pBody = Nothing

                gvbody.Columns(6).Visible = False
                gvbody.DataSource = createdatatable1(5)
                gvbody.DataBind()

                gvListPR.DataSource = createdatatable2(5)
                gvListPR.DataBind()

                '=-= DROPDOWN
                ddFunction.DataSource = Nothing
                ddFunction.DataBind()
                ddFunction.Items.Add("Select")

                ddPAPS.DataSource = Nothing
                ddPAPS.DataBind()
                ddPAPS.Items.Add("Select")

                ddAccounts.DataSource = Nothing
                ddAccounts.DataBind()
                ddAccounts.Items.Add("Select")


                gvBudgetInfo2.DataSource = Nothing
                gvBudgetInfo2.DataBind()


                btnSave.Enabled = False
                btnSubmit.Enabled = False

                Session("edit_pr") = False



            End If

            SearchBut.Attributes.Add("onkeypress", "return fun1(event,'" & Button5.ClientID & "')")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "You dont have a PPMP. Please create your pppmp first before preparing Purchase Request")
        End Try

    End Sub

    Protected Sub ddRC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles ddRC.SelectedIndexChanged
        If ddRC.SelectedItem.Text = "Select" Then
            pFunction = Nothing
            ddFunction.DataSource = pFunction
            ddFunction.DataBind()
            ddFunction.Items.Add("Select")

        Else
            pFunction = objDerived.GetDataTable("EXEC [dbo].[sp_function_systemManager] '" & Session("RoleName") & "','" & ddRC.SelectedItem.Value & "'", CommandType.Text)
            ddFunction.DataSource = pFunction
            ddFunction.DataTextField = ("Function_Desc")
            ddFunction.DataValueField = ("Function_ID")
            ddFunction.DataBind()
            ddFunction.Items.Insert(0, "Select")

        End If
    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim app As Integer
        app = objDerived.GetValue("Select Status from AMS.APP where year = '" & Year(Date.Today.ToString("MM/dd/yyyy")) & "'", CommandType.Text)
        If app = 1 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Execute your APP first.")

        Else
            Dim dtDeptHead As New DataTable
            dtDeptHead = objDerived.GetDataTable("SELECT * FROM [dbo].[View_DepartmentHeads] WHERE RC_ID = '" & ddRC.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
            If dtDeptHead.Rows.Count = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Assign department head first. Contact GSD Personnel")
                Exit Sub
            End If

            If ddFunction.SelectedItem.Text = "Select" Then
                PAPS = Nothing
                ddPAPS.DataSource = PAPS
                ddPAPS.DataBind()
                ddPAPS.Items.Insert(0, "Select")

            Else
                PAPS = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project_With_OOE " & Me.ddRC.SelectedItem.Value & ",'" & Year(CDate(txtprdate.Text)) & "'," & ddFunction.SelectedItem.Value & ",'" & Session("Current") & "'," & rbTrustFund.SelectedItem.Value & "", CommandType.Text)
                ddPAPS.DataSource = PAPS
                ddPAPS.DataTextField = ("description")
                ddPAPS.DataValueField = ("description")
                ddPAPS.DataBind()
                ddPAPS.Items.Insert(0, "Select")

            End If
        End If

        pPRlist = Nothing
        pPRlist = objDerived.GetDataTable("SELECT * FROM AMS.PR_Hdr WHERE rc_id = '" & Me.ddRC.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "' and Year(Date_Submitted) = '" & Year(CDate(txtprdate.Text)) & "' AND isTrustFund = 1 AND F_ID = 3 AND IsApproved = 0 AND isFinal = 0 AND IsCancelled = 0", CommandType.Text)
        If pPRlist.Rows.Count < 5 Then
            pPRlist.Merge(createdatatable2(5 - pPRlist.Rows.Count))
        End If
        gvListPR.DataSource = pPRlist
        gvListPR.DataBind()

        ddnature.Enabled = True

        ddRequestedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
        ddRequestedBy.DataTextField = ("full_name")
        ddRequestedBy.DataValueField = ("empid")
        ddRequestedBy.DataBind()

        ddRequestedBy.Enabled = True

        ddCheckedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, id, isActive FROM AMS.BAC_Members WHERE isActive = 1 ORDER BY Name", CommandType.Text)
        ddCheckedBy.DataTextField = ("Name")
        ddCheckedBy.DataValueField = ("id")
        ddCheckedBy.DataBind()
        ddCheckedBy.Items.Insert(0, "Select")

        ddNotedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, id, isActive FROM AMS.BAC_Members WHERE isActive = 1 ORDER BY Name", CommandType.Text)
        ddNotedBy.DataTextField = ("Name")
        ddNotedBy.DataValueField = ("id")
        ddNotedBy.DataBind()
        ddNotedBy.Items.Insert(0, "Select")



        ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid IN (1,67) AND division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' ORDER BY deptid", CommandType.Text)
        ddApprovedBy.DataTextField = ("full_name")
        ddApprovedBy.DataValueField = ("empid")
        ddApprovedBy.DataBind()

    End Sub

    Protected Sub ddPAPS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddnature.Enabled = True
        ddAccounts.Items.Clear()

        Dim proj As Integer = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
        Dim prog As Integer = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")

        txtpurpose.Text = ddPAPS.SelectedItem.Text
    End Sub
    Protected Sub ddnature_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'pAccounts = objDerived.GetDataTable("SELECT DISTINCT GA_Title, CONVERT(VARCHAR(20),GA_CODE2) AS GA_CODE2,GA_ID  from AMS.vw_Ga_Title where AllotmentClass_ID = '" & ddnature.SelectedValue.ToString & "' and RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_ID = '" & ddFunction.SelectedItem.Value & "' and Project_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "' and Program_id = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "' and CYear = '" & Year(CDate(txtprdate.Text)) & "'", CommandType.Text)
        'pAccounts = objDerived.GetDataTable("SELECT DISTINCT * FROM AMS.View_AccountList WHERE AllotmentClass_ID = '" & ddnature.SelectedValue.ToString & "' ORDER BY GA_Title", CommandType.Text)
        Dim Prj As Integer
        If ddPAPS.SelectedItem.Text = "Select" Then

            Prj = 0

        Else
            Prj = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
        End If
        Dim Prg As Integer
        If ddPAPS.SelectedItem.Text = "Select" Then
            Prg = 0
        Else
            Prg = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")

        End If
        pAccounts = objDerived.GetDataTable("SELECT DISTINCT GA_Title, CONVERT(VARCHAR(20),GA_CODE2) AS GA_CODE2,GA_ID  from AMS.vw_Ga_Title where AllotmentClass_ID = '" & ddnature.SelectedValue.ToString & "' and RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_ID = '" & ddFunction.SelectedItem.Value & "' and Project_ID = '" & Prj & "' and Program_id = '" & Prg & "' and CYear = '" & Year(CDate(txtprdate.Text)) & "'", CommandType.Text)
        ddAccounts.DataSource = pAccounts
        ddAccounts.DataTextField = ("GA_Title")
        ddAccounts.DataValueField = ("GA_CODE2")
        ddAccounts.DataBind()
        ddAccounts.Items.Insert(0, "Select")

    End Sub

    Protected Sub ddAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddAccounts.SelectedIndexChanged
        Dim GA_ID As Integer
        Dim BGA_ID As Integer
        GA_ID = objDerived.GetValue("Select GA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)
        BGA_ID = objDerived.GetValue("Select BGA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)

        Session("GA_ID") = GA_ID
        Session("BGA_ID") = BGA_ID

        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True

        If ddnature.SelectedIndex = 1 Then
            Dim isGasoline As Boolean
            isGasoline = False
            Dim prj1 As Integer = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
            Dim prg1 As Integer = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_ID")
            'pitems = objDerived.GetDataTable("EXEC [AMS].[sp_goods_per_account_withPrice] '" & Session("GA_ID") & "','" & Session("BGA_ID") & "', '" & Session("CYear") & "'", CommandType.Text)
            pitems = objDerived.GetDataTable("exec ams.sp_supplies_for_pr '" & Year(CDate(txtprdate.Text)) & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & isGasoline & "' ,0, '" & GA_ID & "','" & BGA_ID & "'", CommandType.Text)
            gvitems.DataSource = pitems
            gvitems.DataBind()
            LinkButton2.Enabled = True
            'lbmeals.Enabled = False

        ElseIf ddnature.SelectedIndex = 2 Then
            'pitems = objDerived.GetDataTable("EXEC [AMS].[sp_goods_per_account_withPrice] '" & Session("GA_ID") & "','" & Session("BGA_ID") & "', '" & Session("CYear") & "'", CommandType.Text)
            Dim proj As Integer = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
            Dim Prog As Integer = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_ID")
            pitems = objDerived.GetDataTable("exec ams.sp_ppe_for_pr '" & Year(CDate(txtprdate.Text)) & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & ddAccounts.SelectedValue & "',0", CommandType.Text)
            gvitems.DataSource = pitems
            gvitems.DataBind()
            LinkButton2.Enabled = True

        Else
            GA_ID = 0
            LinkButton2.Enabled = False
            cbReinbursement.Enabled = False
            cbReinbursement.Checked = False
        End If
        'pitems = objDerived.GetDataTable("EXEC [AMS].[sp_goods_per_account_withPrice] '" & Session("GA_ID") & "','" & Session("BGA_ID") & "', '" & Session("CYear") & "'", CommandType.Text)
        'gvitems.DataSource = pitems
        'gvitems.DataBind()

        LinkButton2.Enabled = True

        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False

        Dim Prj As Integer
        If ddPAPS.SelectedItem.Text = "Select" Then

            Prj = 0

        Else
            Prj = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
        End If
        Dim Prg As Integer
        If ddPAPS.SelectedItem.Text = "Select" Then
            Prg = 0
        Else
            Prg = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")

        End If

        pBudgetInfo = objDerived.GetDataTable("EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & Prj & "','" & Prg & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
        gvBudgetInfo2.DataSource = pBudgetInfo
        gvBudgetInfo2.DataBind()

        gvbody.DataSource = createdatatable1(19)
        gvbody.DataBind()
        LinkButton2.Enabled = True
        btnSave.Enabled = True

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ModalPopupExtender1.Hide()
    End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles Button3.Click
        'Try
        gvbody.Columns(6).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True

        Dim dt, dt_GA_ID As New DataTable
        Dim dr As DataRow
        Dim cb As CheckBox

        If pBody Is Nothing Then
            dt.Columns.Add("Item_Desc", GetType(String))
            dt.Columns.Add("Description", GetType(String))
            dt.Columns.Add("cost", GetType(Decimal))
            dt.Columns.Add("InputQty", GetType(Integer))
            dt.Columns.Add("qty", GetType(Integer))
            dt.Columns.Add("total", GetType(Decimal))
            dt.Columns.Add("Item_ID", GetType(Integer))
            dt.Columns.Add("GA_ID", GetType(Integer))
            dt.Columns.Add("BGA_ID", GetType(Integer))
            dt.Columns.Add("id", GetType(Long))

            'For i As Integer = 0 To Me.gvitems.Rows.Count - 1
            '    cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            '    If cb.Checked = True Then
            '        dr = dt.NewRow
            '        dr("Item_Desc") = gvitems.Rows(i).Cells(1).Text
            '        dr("Description") = gvitems.Rows(i).Cells(2).Text
            '        dr("cost") = gvitems.Rows(i).Cells(3).Text
            '        dr("InputQty") = 0
            '        dr("total") = CType(0 * gvitems.Rows(i).Cells(3).Text, Decimal)
            '        dr("Item_ID") = gvitems.Rows(i).Cells(4).Text
            '        dr("GA_ID") = Session("GA_ID")
            '        dr("BGA_ID") = Session("BGA_ID")
            '        dr("id") = 1
            '        dt.Rows.Add(dr)

            '        'pitems.Rows(i)("isUsed") = True
            '        'pitems.Rows(i)("isChecked") = False
            '    End If
            'Next

            For i As Integer = 0 To Me.pitems.Rows.Count - 1
                If pitems.Rows(i)("isChecked") = True Then
                    dr = dt.NewRow
                    dr("Item_Desc") = pitems.Rows(i)("Item_Desc")
                    dr("Description") = pitems.Rows(i)("Description")
                    dr("cost") = pitems.Rows(i)("cost")
                    dr("InputQty") = pitems.Rows(i)("qty")
                    dr("qty") = pitems.Rows(i)("qty")
                    dr("total") = CType(0 * pitems.Rows(i)("cost"), Decimal)
                    dr("Item_ID") = pitems.Rows(i)("Item_ID")
                    dr("GA_ID") = Session("GA_ID")
                    dr("BGA_ID") = Session("BGA_ID")
                    dr("id") = 1
                    dt.Rows.Add(dr)
                    pitems.Rows(i)("isUsed") = True
                    pitems.Rows(i)("isChecked") = False
                End If
            Next

            pBody = dt

        Else
            Dim dt2 As New DataTable
            Dim dr2 As DataRow

            dt.Columns.Add("id", GetType(Long))

            dt = pBody

            'For i As Integer = 0 To Me.gvitems.Rows.Count - 1
            '    cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            '    If cb.Checked = True Then
            '        dr2 = dt.NewRow
            '        dr2("Item_Desc") = gvitems.Rows(i).Cells(1).Text
            '        dr2("Description") = gvitems.Rows(i).Cells(2).Text
            '        dr2("cost") = gvitems.Rows(i).Cells(3).Text
            '        dr2("InputQty") = 0
            '        dr2("total") = CType(0 * gvitems.Rows(i).Cells(3).Text, Decimal)
            '        dr2("Item_ID") = gvitems.Rows(i).Cells(4).Text
            '        dr2("GA_ID") = Session("GA_ID")
            '        dr2("BGA_ID") = Session("BGA_ID")
            '        dr2("id") = 1
            '        dt.Rows.Add(dr2)
            '        pBody = dt
            '        'pitems.Rows(i)("isUsed") = True
            '        'pitems.Rows(i)("isChecked") = False
            '    End If
            'Next

            For i As Integer = 0 To Me.pitems.Rows.Count - 1
                If pitems.Rows(i)("isChecked") = True Then
                    dr2 = dt.NewRow
                    dr2("Item_Desc") = pitems.Rows(i)("Item_Desc")
                    dr2("Description") = pitems.Rows(i)("Description")
                    dr2("cost") = pitems.Rows(i)("price")
                    dr2("InputQty") = pitems.Rows(i)("qty")
                    dr("qty") = pitems.Rows(i)("qty")
                    dr2("total") = CType(0 * pitems.Rows(i)("cost"), Decimal)
                    dr2("Item_ID") = pitems.Rows(i)("Item_ID")
                    dr2("GA_ID") = Session("GA_ID")
                    dr2("BGA_ID") = Session("BGA_ID")
                    dr2("id") = 1
                    dt.Rows.Add(dr2)
                    pBody = dt
                    pitems.Rows(i)("isUsed") = True
                    pitems.Rows(i)("isChecked") = False
                End If
            Next

        End If

        gvbody.DataSource = pBody
        gvbody.DataBind()

        Dim myview As DataView
        myview = pitems.DefaultView
        myview.RowFilter = "isUsed = false"
        gvitems.DataSource = myview
        gvitems.DataBind()

        gvbody.Columns(6).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False

        For i As Integer = 0 To Me.gvitems.Rows.Count - 1
            cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            cb.Checked = False
        Next



        'ModalPopupExtender1.Show()

        Dim x As Decimal
        For i As Integer = 0 To gvbody.Rows.Count - 1
            Dim lblCost As Label = CType(gvbody.Rows(i).FindControl("lblCost"), Label)
            Dim txtqty As TextBox = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox)

            CType(gvbody.Rows(i).FindControl("lbltotal"), Label).Text = FormatNumber(lblCost.Text * txtqty.Text, 2)
            x = x + (lblCost.Text * txtqty.Text)
        Next
        CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal2"), Label).Text = FormatNumber(x, 2)
        'Catch ex As Exception
        'End Try
    End Sub

    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "PR"
        Me.Page.Response.Redirect("~/procurement/rpt_purchase_request.aspx")
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If ddRequestedBy.SelectedItem.Text = "Select" Or ddCheckedBy.SelectedItem.Text = "Select" Or ddNotedBy.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatories.")
            Exit Sub
        End If

        AddTrace("pBody row count: " & pBody.Rows.Count)
        AddTrace("Session pBody exists: " & (Not Session("pBody") Is Nothing))


        ' Get the current pBody from session
        Dim currentBody As DataTable = CType(Session("pBody"), DataTable)

        If currentBody Is Nothing OrElse currentBody.Rows.Count = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select an item")
            Exit Sub
        End If

        If txtpurpose.Text = "" Then
            req1.Visible = True
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up required fields.")

        Else
            Dim check As Integer = 0
            For i As Integer = 0 To gvbody.Rows.Count - 1
                If CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text = 0 Then
                    check = 1
                    Exit For
                End If
            Next

            If check = 1 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up required fields.")
            Else
                req1.Visible = False
                Dim ABC As Decimal = CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal2"), Label).Text
                Session("ABC") = ABC

                SaveGoods()

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


                btnSave.Enabled = False
                btnSubmit.Enabled = True
                btnpreview.Enabled = True
                gvbody.Columns(0).Visible = False
            End If
        End If



    End Sub

    Public Sub SaveGoods()
        Try
            Dim prhdrID As Long
            If Me.Session("edit_pr") = False Then


                '=-= Saving PR_Hdr (Goods)
                prhdr.PR_Year = Year(CDate(txtprdate.Text))
                prhdr.PR_Date = txtprdate.Text
                prhdr.RC_ID = ddRC.SelectedItem.Value
                prhdr.Function_ID = ddFunction.SelectedItem.Value
                prhdr.remarks = txtpurpose.Text
                prhdr.Transaction_type = ddnature.SelectedItem.Value

                If ddPAPS.SelectedItem.Text = "Select" Or ddPAPS.SelectedItem.Text = "Office Operational Expense" Then
                    prhdr.Project_ID = 0
                    prhdr.Program_id = 0
                Else
                    prhdr.Project_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
                    prhdr.Program_id = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
                End If

                prhdr.ABC = Session("ABC")
                prhdr.Requestedby = ddRequestedBy.SelectedItem.Value
                'prhdr.Approvedby = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text) 'Mayor's EmpID

                prhdr.Approvedby = ddApprovedBy.SelectedItem.Value

                prhdr.Date_Submitted = Me.txtprdate.Text
                prhdr.Date_gso_rcv = "01/01/1900"
                prhdr.IsCancelled = False
                prhdr.IsApproved = False
                prhdr.isOnBid = False
                prhdr.POHdr_ID = 0
                prhdr.withWinner = False
                prhdr.withPO = False
                prhdr.declarationDate = "01/01/1900"
                prhdr.rcv_date = "01/01/1900"
                prhdr.isPublicInfra = False
                prhdr.isStraight = False
                prhdr.DateApproved_PR_Mayor = "01/01/1900"
                prhdr.DateReceived_PR_Mayor = "01/01/1900"
                prhdr.isApproved_PR_Mayor = False
                prhdr.isReceived_PR_Mayor = False
                prhdr.DateDisApprove = "01/01/1900"
                prhdr.isGasoline = False
                prhdr.pr_period_key_id = 0
                prhdr.pr_invoice_hdr_id = 0
                prhdr.isReimbursement = cbReinbursement.Checked
                prhdr.isContract = False
                prhdr.isEditable = True
                prhdr.Position = Me.txtposition.Text
                prhdr.isContinuing = Session("Current")
                prhdr.mode_of_procurement_id = 0
                prhdr.CheckBy = ddCheckedBy.SelectedItem.Value
                prhdr.NotedBy = ddNotedBy.SelectedItem.Value

                prhdrID = prhdr.save

                Session("PRNo") = prhdrID
                Session("prhdr_id") = prhdrID

                Dim CTO As Integer
                CTO = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = 3, isFinal = 0,CityTreasurer = '" & CTO & "', Userid ='" & Session("@UserName") & "', isTrustFund = 1, GA_ID = '" & Session("GA_ID") & "', comment = '" & replaceapostrophe(txtNote.Text) & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)


                '=-= Saving PR_Dtl
                For i As Integer = 0 To Me.gvbody.Rows.Count - 1

                    If CType(Me.gvbody.Rows(i).Cells(5).FindControl("lbltotal"), Label).Text <> "0.00" Then
                        prdtl.PRHdr_ID = prhdrID
                        prdtl.Item_ID = pBody.Rows(i)("Item_ID")
                        prdtl.Project_title = txtpurpose.Text
                        prdtl.Qty = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text()
                        prdtl.Cost = CType(gvbody.Rows(i).FindControl("lblCost"), Label).Text
                        prdtl.ppmp_dtl_id = 0
                        prdtl.save()
                    End If

                    CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).ReadOnly = False
                Next

                Dim GA_ID As Integer = Session("GA_ID")



            Else
                gvbody.Columns(6).Visible = True
                Dim ABC As Decimal = CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal2"), Label).Text

                '======== PR_HDR Edit ========      
                objDerived.GetRecords("UPDATE ams.pr_hdr set Date_Submitted ='" & txtprdate.Text & "', ABC='" & ABC & "',remarks='" & replaceapostrophe(txtpurpose.Text) & "' where prhdr_id='" & gvListPR.SelectedDataKey(0) & "' ", CommandType.Text)
                Session("prhdr_id") = gvListPR.SelectedDataKey(0)

                '======== PR_Dtl Edit ======== 
                Session("PRNo") = gvListPR.SelectedDataKey(0)
                Dim origcount As Integer = Me.Session("row_num_edit")

                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    Dim Qty As Integer = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text
                    Dim Cost As Decimal = CType(gvbody.Rows(i).FindControl("lblCost"), Label).Text
                    Dim itemID As Long = CType(gvbody.Rows(i).FindControl("lblItem_ID"), Label).Text

                    Dim dtPRdtl As New DataTable

                    dtPRdtl = objDerived.GetDataTable("Select * from AMS.PR_Dtl where prhdr_id='" & gvListPR.SelectedDataKey(0) & "' and Item_ID ='" & itemID & "'", CommandType.Text)
                    If dtPRdtl.Rows.Count = 0 Then
                        objDerived.Execute("INSERT INTO AMS.PR_Dtl (PRHdr_ID,Item_ID,Project_title,Qty,Cost) values('" & gvListPR.SelectedDataKey(0) & "','" & itemID & "','" & txtpurpose.Text & "','" & Qty & "','" & Cost & "')", CommandType.Text)
                    Else
                        objDerived.GetRecords("Update AMS.PR_Dtl set Qty ='" & Qty & "',Project_title = '" & txtpurpose.Text & "' where prhdr_id='" & gvListPR.SelectedDataKey(0) & "' and Item_ID ='" & itemID & "'", CommandType.Text)
                    End If
                Next


                gvbody.Columns(6).Visible = False

            End If
            '=-= Saving OBR_Hdr
            obr_hdr.TempOBR_No = ""
            Dim obj As New BaseClassesint.AccountClassAcounts
            Dim func_per_office As String = objDerived.GetValue("SELECT Func_per_Office_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office WHERE Office_ID = '" & ddRC.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)

            Dim str As String
            If rbTrustFund.SelectedItem.Value = 1 Then
                str = "100"
            Else
                str = "200"
            End If

            Dim d As Date = txtprdate.Text
            Dim FundSourceID As Integer = objDerived.GetValue("SELECT TOP(1) F_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Program AS m_Program WHERE Program_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "'", CommandType.Text)

            If FundSourceID = 14 Then
                obr_hdr.OBR_No = str & "(18)" & "-" & d.ToString("yy") & "-"
            Else
                obr_hdr.OBR_No = str & "-" & d.ToString("yy") & "-"
            End If

            obr_hdr.F_ID_Accntg = rbTrustFund.SelectedItem.Value
            obr_hdr.Period_key = 0
            obr_hdr.PRHdr_ID = prhdrID
            obr_hdr.OBR_Date = txtprdate.Text
            obr_hdr.OBR_Title = txtpurpose.Text
            obr_hdr.Budget_Year = Year(txtprdate.Text)
            obr_hdr.Supplier_ID = 0
            obr_hdr.Payee = txtpeyee.Text
            obr_hdr.Func_per_Office_ID = func_per_office
            obr_hdr.Address = txtaddpeyee.Text
            obr_hdr.Remarks = txtpurpose.Text
            obr_hdr.isPayroll = False
            obr_hdr.isApprovedMayor = False
            obr_hdr.isApproved = True
            obr_hdr.isCancelled = False
            obr_hdr.DateSigned1 = txtprdate.Text
            obr_hdr.DateSigned2 = txtprdate.Text
            obr_hdr.isPayroll = False
            obr_hdr.Signatory1_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_EmployeeSignatories WHERE dept_id = '" & ddRC.SelectedItem.Value & "' AND func_id = '" & ddFunction.SelectedItem.Value & "' AND isDeptHead = 1", CommandType.Text)
            obr_hdr.Signatory2_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_CityBudgetOfficer", CommandType.Text)
            obr_hdr.Status = "Pending"
            obr_hdr.isAdjusted = False
            obr_hdr.isAddForDisbursement = False
            obr_hdr.isPayrollATM = False
            obr_hdr.isGasoline = False
            obr_hdr.pr_period_key_id = 0
            obr_hdr.pr_invoice_hdr_id = 0
            obr_hdr.DateDisapprovedMayor = "01/01/1900"
            obr_hdr.DateApprovedMayor = "01/01/1900"
            obr_hdr.DateReceivedMayor = "01/01/1900"
            obr_hdr.isReceivedBO = False
            obr_hdr.PayeeOffice = ""

            Dim obr_hdr_id As Long = obr_hdr.save()
            Session("obr_id") = obr_hdr_id

            objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Hdr SET forContinuing = 'false' WHERE OBR_Hdr_ID = " & obr_hdr_id, CommandType.Text)


            '=-= Saving OBR_Dtl 
            obr_dtl.OBR_Hdr_ID = obr_hdr_id
            obr_dtl.particulars = txtpurpose.Text
            obr_dtl.BGA_ID = Session("BGA_ID")
            obr_dtl.RC_ID = ddRC.SelectedItem.Value
            obr_dtl.Function_ID = ddFunction.SelectedItem.Value
            obr_dtl.Program_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
            obr_dtl.Project_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
            obr_dtl.GA_ID = Session("GA_ID")
            obr_dtl.Amount = FormatNumber(pBody.Compute("sum(total)", "GA_ID=" & obr_dtl.GA_ID & " and BGA_ID=" & obr_dtl.BGA_ID & ""), 2)
            obr_dtl.AllotmentClass_ID = ddnature.SelectedItem.Value
            obr_dtl.save()

            pPRlist = Nothing
            pPRlist = objDerived.GetDataTable("SELECT * FROM AMS.PR_Hdr WHERE rc_id = '" & Me.ddRC.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "' and Year(Date_Submitted) = '" & Year(CDate(txtprdate.Text)) & "' AND isTrustFund = 1 AND IsApproved = 0 AND isReceived_PR_Mayor = 0 AND isFinal = 0", CommandType.Text)
            If pPRlist.Rows.Count < 5 Then
                pPRlist.Merge(createdatatable2(5 - pPRlist.Rows.Count))
            End If
            gvListPR.DataSource = pPRlist
            gvListPR.DataBind()

            txtpurpose.ReadOnly = True
            LinkButton2.Enabled = False

            btnSave.Enabled = False
            btnSubmit.Enabled = True
            btnpreview.Enabled = True

            gvbody.DataSource = createdatatable1(5)
            gvbody.DataBind()

            Session("edit_pr") = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "An Error occurred please inform the admin ." + ex.ToString)
            '' MsgBox(ex.Message)
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


    Public Sub LoaditemsEdit()
        AddTrace("Lbtn is edit. Preparing to edit purchase request.")

        Session("prhdr_id") = gvListPR.SelectedDataKey("prhdr_id")
        Session("edit_pr") = True

        AddTrace("Session('prhdr_id') = " & Session("prhdr_id"))

        AddTrace("Session('edit_pr') = " & Session("edit_pr"))


        ' Get GA_ID and BGA_ID for Trust Fund PR
        Dim oGA_ID As Integer = objDerived.GetValue("SELECT GA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
        Dim oBGA_ID As Integer = objDerived.GetValue("SELECT BGA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
        AddTrace("oGA_ID = " & oGA_ID & ", oBGA_ID = " & oBGA_ID)

        ' Handle Non-PPMP PR (GA_ID = 0)
        If oGA_ID = 0 Then
            AddTrace("GA_ID is 0, using View_PR_GABGA_NONPPMP to fetch GA_ID. This is a NON-PPMP PR.")
            ' Handle Non-PPMP PR logic
            oGA_ID = objDerived.GetValue("SELECT GA_ID FROM [dbo].[View_PR_GABGA_NONPPMP] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
            oBGA_ID = 0 ' Non-PPMP BGA_ID is not used
            AddTrace("Fetched oGA_ID = " & oGA_ID)
        End If

        ' Populate account list
        ddAccounts.DataSource = objDerived.GetDataTable("SELECT DISTINCT * FROM AMS.View_AccountList", CommandType.Text)
        ddAccounts.DataTextField = "GA_Title"
        ddAccounts.DataValueField = "GA_CODE2"
        ddAccounts.DataBind()

        ' Get selected GA_Code2 for the PR
        Dim selectedGA As String = objDerived.GetValue("SELECT GA_Code2 FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
        If String.IsNullOrEmpty(selectedGA) Then
            selectedGA = objDerived.GetValue("SELECT GA_Code2 FROM [dbo].[View_PR_GABGA_NONPPMP] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
        End If
        ddAccounts.SelectedValue = selectedGA
        Session("GA_ID") = oGA_ID
        Session("BGA_ID") = oBGA_ID
        AddTrace("ddAccounts.SelectedValue set to " & selectedGA)

        ' Disable fields for editing
        ddPAPS.Enabled = False
        ddnature.Enabled = False
        LinkButton2.Enabled = False
        ddRC.Enabled = False
        ddFunction.Enabled = False
        ddAccounts.Enabled = False

        ' Fetch PR header data
        Dim dt1 As DataTable = objDerived.GetDataTable("SELECT * FROM AMS.PR_Hdr WHERE prhdr_id = '" & gvListPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        txtpurpose.Text = dt1.Rows(0)("remarks")
        ddnature.SelectedValue = dt1.Rows(0)("Transaction_type")
        ddnature.Enabled = False

        'NEED TRACKING
        'txtNote.Text = dt1.Rows(0)("Note")
        'txtOBRpurpose.Text = dt1.Rows(0)("OBR_Title")
        'txtpeyee.Text = dt1.Rows(0)("Payee")
        'txtaddpeyee.Text = dt1.Rows(0)("Address")

        ' Load items based on PR type (PPMP or Non-PPMP)
        Dim pBody As DataTable
        If dt1.Rows(0)("IsNonPPMP") = True Then
            pBody = objDerived.GetDataTable("EXEC ams.sp_edit_purchase_request_detail_NONPPMP '" & Session("prhdr_id") & "'", CommandType.Text)
        Else

            pBody = objDerived.GetDataTable("EXEC ams.sp_edit_purchase_request_detail '" & Session("prhdr_id") & "'", CommandType.Text)
            Session("pBody") = pBody ' Explicitly store in session


        End If

        gvbody.DataSource = pBody
        gvbody.DataBind()

        ' Calculate total amount for the PR items
        Dim totalAmount As Decimal = 0
        For i As Integer = 0 To gvbody.Rows.Count - 1
            Dim lblCost As Label = CType(gvbody.Rows(i).FindControl("lblCost"), Label)
            Dim txtqty As TextBox = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox)
            CType(gvbody.Rows(i).FindControl("lbltotal"), Label).Text = FormatNumber(lblCost.Text * txtqty.Text, 2)
            totalAmount += lblCost.Text * txtqty.Text
        Next
        CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal2"), Label).Text = FormatNumber(totalAmount, 2)

        ' Enable/Disable controls based on PR approval status
        If dt1.Rows(0)("IsApproved") = True Then
            For i As Integer = 0 To gvbody.Rows.Count - 1
                CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Enabled = True
                CType(gvbody.Rows(i).FindControl("ImageButton4"), ImageButton).Enabled = True
            Next
        End If

        ' Update session variables with PR details
        Session("origbody") = pBody
        Session("row_num_edit") = pBody.Rows.Count - 1

        ' Get the selected value from RadioButtonList (0 for Current, 1 for Continuing)
        Dim isContinuing As Integer = Convert.ToInt32(RadioButtonList1.SelectedValue)

        ' Build the query string with the added isContinuing parameter
        ' Before executing the query, log the parameters or relevant details
        Dim queryString As String = "EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & Session("project_ID") & "','" & Session("Program_id") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "'," & isContinuing
        AddTrace("Executing query with parameters: " & queryString)

        ' Execute the SQL query and retrieve data into the DataTable
        Dim pBudgetInfo As DataTable = objDerived.GetDataTable(queryString, CommandType.Text)

        ' Log the result of the query execution (you can also log how many rows were returned if needed)
        AddTrace("Query executed. Number of rows returned: " & pBudgetInfo.Rows.Count)

        ' Optionally, log any other relevant information after the query execution
        ' AddTrace("Other relevant information here")

        ' Bind the result to the GridView
        gvBudgetInfo2.DataSource = pBudgetInfo
        gvBudgetInfo2.DataBind()

        ' Enable Save and Add List buttons
        btnSave.Enabled = True
        LinkButton2.Enabled = True



        'btnAddlist.Enabled = True
    End Sub


    Protected Sub gvListPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListPR.SelectedIndexChanged
        AddTrace("gvListPR_SelectedIndexChanged called.")

        If IsDBNull(gvListPR.SelectedDataKey(0)) = True Then
            AddTrace("Condition met: gvListPR.SelectedDataKey(0) is DBNull.")
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select purchase request transaction.")
            Exit Sub
        Else
            AddTrace("gvListPR.SelectedDataKey(0) is not DBNull, proceeding with further logic.")

            Try
                If Lbtn = "edit" Then
                    ' Editing PR: Load the items for editing
                    LoaditemsEdit()

                    ' Check if PAPS has rows and ddPAPS has a valid selection
                    If PAPS IsNot Nothing AndAlso PAPS.Rows.Count > 0 AndAlso ddPAPS.SelectedIndex > 0 Then
                        pitems = objDerived.GetDataTable("exec [AMS].[sp_supplies_for_pr_EDIT2] " &
                        Year(CDate(txtprdate.Text)) & "," &
                        ddRC.SelectedItem.Value & "," &
                        ddFunction.SelectedItem.Value & "," &
                        PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "," &
                        PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & ",0," &
                        Session("Current") & "," &
                        Session("GA_ID"), CommandType.Text)

                        gvitems.Columns(4).Visible = True
                        gvitems.DataSource = pitems
                        gvitems.DataBind()
                        gvitems.Columns(4).Visible = False
                    Else
                        ' Handle case when no PAPS is selected or available
                        pitems = objDerived.GetDataTable("exec [AMS].[sp_supplies_for_pr_EDIT2] " &
                        Year(CDate(txtprdate.Text)) & "," &
                        ddRC.SelectedItem.Value & "," &
                        ddFunction.SelectedItem.Value & ",0,0,0," &
                        Session("Current") & "," &
                        Session("GA_ID"), CommandType.Text)

                        gvitems.Columns(4).Visible = True
                        gvitems.DataSource = pitems
                        gvitems.DataBind()
                        gvitems.Columns(4).Visible = False
                    End If

                ElseIf Lbtn = "PR" Then
                    ' Open PR report in a new tab (for viewing)
                    Session("Page") = "PR"
                    Session("Report") = "PR"
                    Session("prhdr_id") = gvListPR.SelectedDataKey("prhdr_id")
                    Dim url As String = "rpt_purchase_request_pop_up.aspx?"
                    Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
                ElseIf Lbtn = "cancel" Then
                    ' Cancel the PR and update the status
                    Dim cancelQuery As String = "UPDATE ams.PR_Hdr set IsCancelled='" & True & "', isEditable='" & False & "' where PRHdr_ID='" & gvListPR.SelectedDataKey(0) & "'"
                    objDerived.GetRecords(cancelQuery, CommandType.Text)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully cancelled.")
                    Me.Page.Response.Redirect("~/procurement/t_purchased_request_trustfund.aspx")
                End If
            Catch ex As Exception
                AddTrace("Error in gvListPR_SelectedIndexChanged: " & ex.Message)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "An error occurred while processing. Please contact the admin.")
            End Try
        End If
    End Sub


    Protected Sub LinkButton1_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "PR"
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "ObR"
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "edit"
    End Sub

    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "cancel"
    End Sub

    Protected Sub rbTrustFund_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If rbTrustFund.SelectedItem.Value = 3 Then
            Me.Page.Response.Redirect("~/procurement/t_purchased_request_trustfund.aspx")
        Else
            Me.Page.Response.Redirect("~/procurement/t_purchase_request_v2.aspx")
        End If
    End Sub

    Protected Sub lnkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "Delete"
    End Sub

    Protected Sub gvbody_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Lbtn = "detail" Then

        ElseIf Lbtn = "Delete" Then
            Dim ppmp As Integer = gvbody.SelectedDataKey("ppmp_dtl_id")
            Dim itemid As Integer = gvbody.SelectedDataKey("Item_ID")

            objDerived.Execute("DELETE AMS.PR_dtl where ppmp_dtl_id='" & gvbody.SelectedDataKey("ppmp_dtl_id") & "' and Item_ID ='" & gvbody.SelectedDataKey("Item_ID") & "'", CommandType.Text)

            pBody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
            gvbody.DataSource = pBody
            gvbody.DataBind()

            For i As Integer = 0 To gvbody.Rows.Count - 1
                Dim txtcost As TextBox = CType(gvbody.Rows(i).Cells(5).FindControl("txtcost"), TextBox)
                txtcost.Enabled = False
            Next

            pitems = objDerived.GetDataTable("exec ams.sp_supplies_for_construction_edit " & Year(CDate(txtprdate.Text)) & "," & datahdr.Rows(0)("RC_ID") & "," & datahdr.Rows(0)("function_ID") & "," & datahdr.Rows(0)("project_id") & "," & datahdr.Rows(0)("program_id") & "," & datahdr.Rows(0)("GA_ID") & "," & datahdr.Rows(0)("BGA_ID") & ", '" & gvListPR.SelectedDataKey(0) & "','" & datahdr.Rows(0)("isContinuing") & "'", CommandType.Text)

            gvitems.Columns(4).Visible = True

            gvitems.DataSource = pitems
            gvitems.DataBind()

            gvitems.Columns(4).Visible = False

        ElseIf Lbtn = "DEL" Then
            Dim dt As New DataTable

            dt = objDerived.GetDataTable("SELECT PRHdr_ID, Item_ID FROM AMS.PR_Dtl WHERE prhdr_id = '" & Session("prhdr_id") & "' AND Item_ID = '" & gvbody.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            If dt.Rows.Count = 0 Then
                For i As Integer = 0 To pBody.Rows.Count - 1
                    If pBody.Rows(i).Item("Item_ID") = gvbody.SelectedDataKey("Item_ID") Then
                        '=============== DELETE ITEMS TO THE GRIDVIEW
                        pBody.Rows(i).Delete()

                        '============== ITEM BACK TO THE LIST
                        For cn As Integer = 0 To pitems.Rows.Count - 1
                            If pitems.Rows(cn)("Item_ID") = gvbody.SelectedDataKey("Item_ID") Then
                                pitems.Rows(cn)("isUsed") = False
                                pitems.Rows(cn)("isChecked") = False
                            End If
                        Next

                        Exit For
                    End If
                Next

                gvbody.DataSource = pBody
                gvbody.DataBind()
                gvbody.SelectedIndex = -1

                'CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal2"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2) 'FormatNumber(x, 2)

                gvitems.Columns(3).Visible = True
                gvitems.Columns(4).Visible = True
                gvitems.Columns(5).Visible = True
                'gvitems.Columns(6).Visible = True
                'gvitems.Columns(7).Visible = True
                'gvitems.Columns(8).Visible = True
                'gvitems.Columns(10).Visible = True

                Dim myview As DataView
                myview = pitems.DefaultView
                myview.RowFilter = "isUsed = 'false'"
                gvitems.DataSource = myview
                gvitems.DataBind()
                gvitems.PageIndex = 0

                gvitems.Columns(3).Visible = False
                gvitems.Columns(4).Visible = False
                'gvitems.Columns(6).Visible = False
                'gvitems.Columns(7).Visible = False
                'gvitems.Columns(8).Visible = False
                'gvitems.Columns(10).Visible = False

            Else

                'Dim ppmp As Integer = gvbody.SelectedDataKey("ppmp_dtl_id")
                'Dim itemid As Integer = gvbody.SelectedDataKey("Item_ID")

                For i As Integer = 0 To pBody.Rows.Count - 1
                    If pBody.Rows(i).Item("Item_ID") = gvbody.SelectedDataKey("Item_ID") Then
                        '=============== DELETE ITEMS TO THE GRIDVIEW
                        pBody.Rows(i).Delete()
                        Exit For
                    End If
                Next

                objDerived.GetRecords("DELETE FROM [AMS].[PR_Dtl] WHERE [PRHdr_ID] = '" & Session("prhdr_id") & "' AND [Item_ID] = '" & gvbody.SelectedDataKey("Item_ID") & "'", CommandType.Text)

                Dim ABC As Decimal = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET ABC = '" & ABC & "' WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)

                'CType(gvbody.FooterRow.Cells(7).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal2"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2) 'FormatNumber(x, 2)

                gvbody.DataSource = pBody
                gvbody.DataBind()
                gvbody.SelectedIndex = -1

                gvitems.Columns(3).Visible = True
                gvitems.Columns(4).Visible = True
                gvitems.Columns(5).Visible = True
                'gvitems.Columns(6).Visible = True
                'gvitems.Columns(7).Visible = True
                'gvitems.Columns(8).Visible = True
                'gvitems.Columns(10).Visible = True

                'gvitems.DataSource = pitems
                'gvitems.DataBind()

                gvitems.Columns(3).Visible = False
                gvitems.Columns(4).Visible = False
                'gvitems.Columns(6).Visible = False
                'gvitems.Columns(7).Visible = False
                'gvitems.Columns(8).Visible = False
                'gvitems.Columns(10).Visible = False

                Session("edit_pr") = True
            End If
        End If
    End Sub

    Protected Sub gvbody_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Lbtn = "Delete"

        Dim ppmp As Integer = gvbody.SelectedDataKey("ppmp_dtl_id")
        Dim itemid As Integer = gvbody.SelectedDataKey("Item_ID")

        objDerived.Execute("DELETE AMS.PR_dtl where ppmp_dtl_id='" & gvbody.SelectedDataKey("ppmp_dtl_id") & "' and Item_ID ='" & gvbody.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        pBody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
        gvbody.DataSource = pBody
        gvbody.DataBind()
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                    pitems.Rows(Me.gvitems.Rows(i).Cells(5).Text)("isChecked") = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
                pitems.Rows(Me.gvitems.Rows(i).Cells(5).Text)("isChecked") = False
            Next
        End If

        ModalPopupExtender1.Show()
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'gvitems.DataSource = objDerived.Search(pitems, ddpopup.SelectedValue, replaceapostrophe(SearchBut.Text.ToString))

        If SearchBut.Text = "" Then
            Session("Search") = 0
        Else
            Session("Search") = 1
            'pitems = objDerived.GetDataTable("EXEC [AMS].[sp_Goods_Search] '" & ddAccounts.SelectedItem.Value & "','" & Session("BGA_ID") & "', '" & Session("CYear") & "','" & SearchBut.Text & "'", CommandType.Text)
        End If


        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True

        gvitems.DataSource = objDerived.Search(pitems, ddpopup.SelectedValue, SearchBut.Text)
        gvitems.DataBind()

        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False

        ModalPopupExtender1.Show()
    End Sub

    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True

        If Session("Search") = 0 Then
            'pitems = objDerived.GetDataTable("EXEC [AMS].[sp_goods_per_account_withPrice] '" & ddAccounts.SelectedItem.Value & "','" & Session("BGA_ID") & "', '" & Session("CYear") & "'", CommandType.Text)
            'gvitems.PageIndex = e.NewPageIndex
            'gvitems.DataSource = pitems
            'gvitems.DataBind()

            gvitems.PageIndex = e.NewPageIndex
            gvitems.DataSource = CType(pitems, DataTable)
            gvitems.DataBind()

        ElseIf Session("Search") = 1 Then
            gvitems.DataSource = objDerived.Search(pitems, ddpopup.SelectedValue, replaceapostrophe(SearchBut.Text.ToString))
            gvitems.PageIndex = e.NewPageIndex
            gvitems.DataBind()


        End If

        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False

        ModalPopupExtender1.Show()
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function


    Protected Sub txtqty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim x As Decimal
        For i As Integer = 0 To gvbody.Rows.Count - 1
            Dim lblCost As Label = CType(gvbody.Rows(i).FindControl("lblCost"), Label)
            Dim txtqty As TextBox = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox)

            CType(gvbody.Rows(i).FindControl("lbltotal"), Label).Text = FormatNumber(lblCost.Text * txtqty.Text, 2)
            x = x + (lblCost.Text * txtqty.Text)
        Next

        CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal2"), Label).Text = FormatNumber(x, 2)

    End Sub


    Protected Sub LinkButton2_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Search") = 0
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True

        Dim cb As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)

        If cb.Checked = True Then
            pitems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(5).Text)("isChecked") = True

        Else
            pitems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(5).Text)("isChecked") = False

        End If

        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False

        ModalPopupExtender1.Show()
    End Sub

    Protected Sub ddRequestedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtposition.Text = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND empid = '" & ddRequestedBy.SelectedItem.Value & "'", CommandType.Text)
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CheckPR As String = objDerived.GetValue("SELECT ISNULL([pr_no],'0') FROM [AMS].[PR_Hdr] WHERE [prhdr_id] = '" & Session("prhdr_id") & "'", CommandType.Text)
        If CheckPR = "0" Then
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isFinal = 1, Date_Submitted = '" & Date.Today.ToString("MM/dd/yyyy") & "' WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
        Else
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isFinal = 1, [IsApproved] = 1, [isEditable] = 0 WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
        End If

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase request has been submitted.")

        btnSubmit.Enabled = False

        gvListPR.DataSource = createdatatable2(5)
        gvListPR.DataBind()

    End Sub
    Protected Sub ImageButton4_Click(sender As Object, e As ImageClickEventArgs)
        Lbtn = "DEL"
    End Sub
    Protected Sub gvBudgetInfo2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class
