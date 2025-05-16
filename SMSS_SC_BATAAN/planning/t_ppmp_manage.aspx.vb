Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class planning_t_ppmp_manage
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim history As New t_revision_history
    Dim gvGAPPMP As GridView
#Region "property"
    Private Property PAPS() As DataTable
        Get
            Return CType(Session("PAPS"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PAPS") = value
        End Set
    End Property
    Private Property pYear() As DataTable
        Get
            Return CType(Session("pYear"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pYear") = value
        End Set
    End Property
    Private Property pDepartment() As DataTable
        Get
            Return CType(Session("pDepartment"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pDepartment") = value
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
    Private Property pLbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property
    'added 03062013 8:57Am
    Private Property rolename() As String
        Get
            Return CType(Session("rolename"), String)
        End Get
        Set(ByVal value As String)
            Session("rolename") = value
        End Set
    End Property
    'added 03062013 8:57Am
    Private Property pListAccount() As DataTable
        Get
            Return CType(Session("ListAccount"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("ListAccount") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
            Dim role() As String = Roles.GetRolesForUser(usr.UserName)
            rolename = role(0)
            Session("RoleName") = rolename
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            pYear = objDerived.GetDataTable("Select * from ams.vw_app_status", CommandType.Text)
            ddYear.DataSource = pYear
            ddYear.DataTextField = ("year_title")
            ddYear.DataValueField = ("app_id")
            ddYear.DataBind()
            ddYear.Items.Insert(0, "Select")

            Dim dt As New DataTable
            ddDepartments.DataSource = dt
            ddDepartments.DataBind()
            ddDepartments.Items.Insert(0, "Select")

            ddPPA.DataSource = dt
            ddPPA.DataBind()
            ddPPA.Items.Insert(0, "Select")

            gvAccount.DataSource = createdatatable3(9)
            gvAccount.DataBind()

            Session("year_title") = ddYear.SelectedValue

        End If

        Dim a
        a = Session("year_title")



    End Sub
   
    Protected Sub ddYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddYear.SelectedIndexChanged
        If Me.ddYear.SelectedItem.Value = "Select" Then
            Me.ddDepartments.Enabled = False

        Else
            Session("iscontinuing") = pYear.Rows(Me.ddYear.SelectedIndex - 1)("iscontinuing")
            Session("Year") = pYear.Rows(Me.ddYear.SelectedIndex - 1)("year")
            Session("year_title") = pYear.Rows(Me.ddYear.SelectedIndex - 1)("year_title")

            pDepartment = objDerived.GetDataTable("EXEC [AMS].[sp_ManagePPMP_RCList] '" & Session("Year") & "', '" & Session("iscontinuing") & "'", CommandType.Text)
            ddDepartments.DataSource = pDepartment
            ddDepartments.DataTextField = ("RC_Name")
            ddDepartments.DataValueField = ("Func_per_Office_ID")
            ddDepartments.DataBind()
            ddDepartments.Items.Insert(0, "Select")

            ddDepartments.Enabled = True
        End If

    End Sub

    Protected Sub ddDepartments_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddDepartments.SelectedIndexChanged
        If Me.ddDepartments.SelectedItem.Value = "Select" Then
            Me.ddDepartments.Enabled = False

        Else
            ddYear.SelectedItem.Value = Session("year_title")

            Dim x As String = ddDepartments.SelectedValue.ToString
            PAPS = objDerived.GetDataTable("exec AMS.sp_Programs_Activities_Project_manage_PPMP " & Me.ddDepartments.SelectedValue.ToString & "," & Session("Year") & ",'" & Session("iscontinuing") & "' ", CommandType.Text)
            ddPPA.DataSource = PAPS
            ddPPA.DataTextField = ("description")
            ddPPA.DataValueField = ("description")
            ddPPA.DataBind()
            ddPPA.Items.Insert(0, "Select")

            ddPPA.Enabled = True
        End If
    End Sub

    Protected Sub gvAccount_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvAccount.RowCommand

        If ddDepartments.SelectedValue.ToString = "Select" Or ddPPA.SelectedValue.ToString = "Select" Then
            If pLbtn = "revise" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Cannot revised make sure you select the Department and PPA.")
                Me.ddPPA.Enabled = True
                Me.ddDepartments.Enabled = True




            ElseIf pLbtn = "Locked" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Cannot locked make sure you select the Department and PPA.")
                Me.ddPPA.Enabled = True
                Me.ddDepartments.Enabled = True
            Else

            End If
        Else
            Try
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim row As GridViewRow = Me.gvAccount.Rows(index)
                'Dim a As String = pLbtn
                If pLbtn = "revise" Then
                    If Session("Approved_Revise") = "" Then
                        Dim dt As New DataTable
                        dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
                        drpApprovedOfficer.DataSource = dt
                        drpApprovedOfficer.DataTextField = ("full_name")
                        drpApprovedOfficer.DataValueField = ("approvalid")
                        drpApprovedOfficer.DataSource = dt
                        drpApprovedOfficer.DataBind()
                        ModalPopupExtender1.Show()
                    End If


                    If Session("Approved_Revise") = "Approved" Then
                        objDerived.GetRecords("Update AMS.PPMP_Monthly_Hdr set forRevision='true'  where rc_id= " & gvAccount.DataKeys(row.RowIndex).Values("rc_id") _
                                                                                     & " and function_ID=" & gvAccount.DataKeys(row.RowIndex).Values("Function_id") _
                                                                                     & " and cyear=" & Session("Year") _
                                                                                     & " and ga_id= " & gvAccount.DataKeys(row.RowIndex).Values("ga_id") _
                                                                                     & " and BGA_ID= " & gvAccount.DataKeys(row.RowIndex).Values("bga_id") _
                                                                                     & " and Project_ID=" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") _
                                                                                     & " and Program_id=" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id") & "", CommandType.Text)
                        history.rc_id = gvAccount.DataKeys(row.RowIndex).Values("rc_id") 'gvAccount.SelectedDataKey(5)
                        history.function_id = gvAccount.DataKeys(row.RowIndex).Values("Function_id") 'gvAccount.SelectedDataKey(6)
                        history.status = "revision"
                        history.transaction_date = DateTime.Now
                        history.username2 = Me.Session("@UserName")
                        ''(Me.Session("@UserName")
                        history.save()
                        Me.ddDepartments.Enabled = True

                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The PPMP of the selected department is now  ready for revision.")
                        Session("Approved_Revise") = ""
                    Else

                    End If





                Else
                    objDerived.GetRecords("Update AMS.PPMP_Monthly_Hdr set forRevision='false'  where rc_id= " & gvAccount.DataKeys(row.RowIndex).Values("rc_id") _
                                                                                       & " and function_ID=" & gvAccount.DataKeys(row.RowIndex).Values("Function_id") _
                                                                                       & " and cyear=" & Session("Year") _
                                                                                       & " and ga_id= " & gvAccount.DataKeys(row.RowIndex).Values("ga_id") _
                                                                                       & " and BGA_ID= " & gvAccount.DataKeys(row.RowIndex).Values("bga_id") _
                                                                                       & " and Project_ID=" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") _
                                                                                       & " and Program_id=" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id") & "", CommandType.Text)
                    history.rc_id = gvAccount.DataKeys(row.RowIndex).Values("rc_id")
                    history.function_id = gvAccount.DataKeys(row.RowIndex).Values("Function_id")
                    history.status = "locked"
                    history.transaction_date = DateTime.Now
                    history.username2 = Me.Session("@UserName")
                    history.save()
                    Me.ddDepartments.Enabled = True

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The PPMP of the selected department is now locked.")
                End If
                'Me.ddYear.Text = Session("Year")
                'gvAccount.DataSource = objDerived.GetRecords("select Distinct Ga_title,Status,ga_id,BGA_ID,isforRevision,enable,rc_id,Function_id,Project_ID, Program_id,isRepair from dbo.Resp_Per_function where rc_id= " & gvAccount.DataKeys(row.RowIndex).Values("rc_id") & " and function_ID=" & gvAccount.DataKeys(row.RowIndex).Values("Function_id") & " and cyear=" & Session("Year") & " and Project_ID=" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & " and Program_id=" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id") & "and iscontinuing='" & Session("iscontinuing") & "'", CommandType.Text)
                'gvAccount.DataBind()

                'pListAccount = objDerived.GetDataTable("select Distinct Ga_title,Status,ga_id,BGA_ID,isforRevision,enable,rc_id,Function_id,Project_ID, Program_id,isRepair from dbo.Resp_Per_function where rc_id= " & gvAccount.DataKeys(row.RowIndex).Values("rc_id") & " and function_ID=" & gvAccount.DataKeys(row.RowIndex).Values("Function_id") & " and cyear=" & Session("Year") & " and Project_ID=" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & " and Program_id=" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id") & "and iscontinuing='" & Session("iscontinuing") & "'", CommandType.Text)

                pListAccount = objDerived.GetDataTable("EXEC [AMS].[sp_ManagePPMP] '" & ddDepartments.SelectedValue.ToString & "','" & Session("Year") & "','" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id") & "','" & Session("iscontinuing") & "'", CommandType.Text)
                pListAccount.Merge(createdatatable3(9))
                gvAccount.DataSource = pListAccount 'createdatatable3(9)
                gvAccount.DataBind()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub gvAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAccount.SelectedIndexChanged

    End Sub

    Protected Sub ddPPA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddPPA.SelectedIndexChanged
        Me.ddYear.SelectedItem.Value = Session("year_title")

        'pListAccount = objDerived.GetDataTable("select Distinct Ga_title,Status,ga_id,bga_id,isforRevision,enable,rc_id,Function_id,Project_ID, Program_id,isRepair from dbo.Resp_Per_function where Func_per_Office_ID= " & Me.ddDepartments.SelectedValue.ToString & " and cyear=" & Session("Year") & " and Project_ID=" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & " and Program_id =" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id") & " and iscontinuing='" & Session("iscontinuing") & "' ", CommandType.Text)
        pListAccount = objDerived.GetDataTable("EXEC [AMS].[sp_ManagePPMP] '" & ddDepartments.SelectedValue.ToString & "','" & Session("Year") & "','" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id") & "'", CommandType.Text)
        pListAccount.Merge(createdatatable3(9))
        gvAccount.DataSource = pListAccount
        gvAccount.DataBind()

    End Sub

    Protected Sub ImageButton1_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        pLbtn = "revise"
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        pLbtn = "Locked"
    End Sub

    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        pLbtn = "Locked"
    End Sub

    Public Function createdatatable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Ga_title", GetType(String))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("ga_id", GetType(Long))
        dt.Columns.Add("bga_id", GetType(Long))
        dt.Columns.Add("isforRevision", GetType(Boolean))
        dt.Columns.Add("enable", GetType(Boolean))
        dt.Columns.Add("rc_id", GetType(Long))
        dt.Columns.Add("Function_id", GetType(Long))
        dt.Columns.Add("Project_ID", GetType(Long))
        dt.Columns.Add("Program_id", GetType(Long))
        dt.Columns.Add("isRepair", GetType(Boolean))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Ga_title") = DBNull.Value
            dr("Status") = DBNull.Value
            dr("ga_id") = DBNull.Value
            dr("bga_id") = DBNull.Value
            dr("isforRevision") = True
            dr("enable") = False
            dr("rc_id") = DBNull.Value
            dr("Function_id") = DBNull.Value
            dr("Project_ID") = DBNull.Value
            dr("Program_id") = DBNull.Value
            dr("isRepair") = False
            
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub gvAccount_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Me.ddYear.SelectedItem.Value = Session("year_title")

        'pListAccount = objDerived.GetDataTable("select Distinct Ga_title,Status,ga_id,bga_id,isforRevision,enable,rc_id,Function_id,Project_ID, Program_id,isRepair from dbo.Resp_Per_function where Func_per_Office_ID= " & Me.ddDepartments.SelectedValue.ToString & " and cyear=" & Session("Year") & " and Project_ID=" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & " and Program_id =" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id") & " and iscontinuing='" & Session("iscontinuing") & "' ", CommandType.Text)
        pListAccount = objDerived.GetDataTable("EXEC [AMS].[sp_ManagePPMP] '" & ddDepartments.SelectedValue.ToString & "','" & Session("Year") & "','" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id") & "'", CommandType.Text)
        pListAccount.Merge(createdatatable3(9))
        gvAccount.PageIndex = e.NewPageIndex
        gvAccount.DataSource = pListAccount
        gvAccount.DataBind()
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else
            'btnSave.Text = "UPDATE"
            Session("Approved_Revise") = "Approved"
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Revise is unlock")
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Hide()
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
