Imports System.Data
Partial Class Roles_ManageRoles
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New BaseClasses.allotmentClass

#Region "property"
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

    Private Property pExistingData() As DataTable
        Get
            Return CType(Session("pExistingData"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pExistingData") = value
        End Set

    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MultiView1.SetActiveView(View2)
            CreateRoleButton.ValidationGroup = "save2"

            DisplayRolesInGrid()
            pRC = objDerived.GetDataTable("SELECT * FROM dbo.m_Resp_center ORDER BY RC_Name", CommandType.Text)
            ddRC.DataSource = CType(pRC, DataTable)
            ddRC.DataTextField = ("RC_Name")
            ddRC.DataValueField = ("RC_ID")
            ddRC.DataBind()

            Me.Panel1.Visible = False
            Me.Panel2.Visible = False
        End If
    End Sub

    Private Sub DisplayRolesInGrid()

        RoleList.DataSource = Roles.GetAllRoles()
        RoleList.DataBind()

    End Sub

    Protected Sub CreateRoleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateRoleButton.Click
        Try
            If RadioButtonList1.SelectedIndex = 1 Then

                Dim newRoleName As String = RoleName.Text.Trim()
                pExistingData = objDerived.GetDataTableSysmanager("SELECT RoleName FROM dbo.aspnet_Roles where RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_ID = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
                If pExistingData.Rows.Count >= 1 Then
                    'msg.UserMsgBox("The department and function is already used in the ROLE '" & pExistingData.Rows(0)("RoleName") & "'.", Me, False)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The department and function is already used in the ROLE " & pExistingData.Rows(0)("RoleName") & ".")
                    DisplayRolesInGrid()
                    lblRoleConfirm.Visible = False
                Else
                    If Not Roles.RoleExists(newRoleName) Then
                        Roles.CreateRole(newRoleName)

                        objDerived.GetRecordsSysmanager("Update aspnet_roles set rc_id =" & ddRC.SelectedItem.Value & ",function_id=" & ddFunction.SelectedItem.Value & " where RoleName='" & newRoleName & "'", CommandType.Text)

                        Dim rc_id As Integer = obj.GetValue("Select office_id from dbo.view_RC_SystemManager where rc_name like '" & replaceapostrophe(ddRC.SelectedItem.Text) & "'", CommandType.Text)
                        Dim function_id As Integer = obj.GetValue("Select function_id from dbo.view_RC_SystemManager where rc_name like '" & replaceapostrophe(ddRC.SelectedItem.Text) & "'", CommandType.Text)
                        obj.GetRecords("exec dbo.spSave_tbl_RC_Management '" & RoleName.Text & "','" & rc_id & "','" & function_id & "','" & True & "'", CommandType.Text)


                        'msg.UserMsgBox("Transaction has been succesfully saved", Me, False)
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                        DisplayRolesInGrid()

                        lblRoleConfirm.Visible = True

                    Else
                        'msg.UserMsgBox("Role Name is already existing.", Me, False)
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Role Name is already existing.")

                    End If
                    RoleName.Text = String.Empty

                End If

            Else
                Dim newRoleName As String = txtRoleName.Text.Trim()
                If Not Roles.RoleExists(newRoleName) Then

                    Roles.CreateRole(newRoleName)
                    objDerived.GetRecordsSysmanager("Update aspnet_roles set rc_id=" & 0 & ",function_id=" & 0 & " where RoleName='" & newRoleName & "'", CommandType.Text)


                    'msg.UserMsgBox("Transaction has been succesfully saved", Me, False)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                    DisplayRolesInGrid()

                Else
                    'msg.UserMsgBox("Role Name is already existing.", Me, False)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Role Name is already existing.")

                End If

                RoleName.Text = String.Empty
            End If


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub

    Protected Sub RoleList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles RoleList.RowCommand
        Dim currentCommand As String = e.CommandName
        Dim currentRowIndex As Integer = Int32.Parse(e.CommandArgument)
        Dim RoleNameLabel As Label = CType(RoleList.Rows(currentRowIndex).FindControl("RoleNameLabel"), Label)
        Select Case currentCommand
            Case "Manage"
                Response.Redirect("AccessRules.aspx?role=" & FileClass.b64encode(RoleNameLabel.Text))
            Case "View"
                LoadUsers(RoleNameLabel.Text)
            Case "Manage RC"
                LoadRC(RoleNameLabel.Text)
        End Select
    End Sub
    Private Sub LoadRC(ByVal rolename As String)
        Me.Panel2.Visible = True
        Me.Panel1.Visible = False

        Dim dtRCList As DataTable = obj.GetDataTable("exec dbo.sp_view_RCList  '" & rolename & "'", Data.CommandType.Text)
        ChkRCList.DataSource = dtRCList
        ChkRCList.DataTextField = "rc_name"
        ChkRCList.DataValueField = "ischecked"
        ChkRCList.DataBind()

        For x As Integer = 0 To ChkRCList.Items.Count - 1
            ChkRCList.Items(x).Selected = dtRCList.Rows(x)("ischecked")
            ChkRCList.Items(x).Enabled = dtRCList.Rows(x)("isenable")
        Next

        lblRoleName.Text = rolename
    End Sub
    Private Sub LoadUsers(ByVal roleName As String)
        Me.Panel1.Visible = True
        Me.Panel2.Visible = False

        Me.UserAccounts.DataSource = Roles.GetUsersInRole(roleName)
        Me.UserAccounts.DataBind()
        TextBox1.Text = roleName
    End Sub
    Protected Sub RoleList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles RoleList.RowDeleting
        ' Get the RoleNameLabel
        Dim RoleNameLabel As Label = CType(RoleList.Rows(e.RowIndex).FindControl("RoleNameLabel"), Label)

        ' Delete the role
        Roles.DeleteRole(RoleNameLabel.Text, False)

        ' Rebind the data to the RoleList grid
        DisplayRolesInGrid()
    End Sub

   
    Protected Sub UserAccounts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles UserAccounts.RowCommand
        Dim currentCommand As String = e.CommandName
        Dim currentRowIndex As Integer = Int32.Parse(e.CommandArgument)
        Dim UserNameLabel As Label = CType(UserAccounts.Rows(currentRowIndex).FindControl("UserNameLabel"), Label)
        Select Case currentCommand
            Case "Manage"
                Response.Redirect("~/membership/UserInformation.aspx?user=" & UserNameLabel.Text)
            Case "Remove"
                Roles.RemoveUserFromRole(UserNameLabel.Text, TextBox1.Text)
        End Select
    End Sub

    
    Protected Sub ddRC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddRC.SelectedIndexChanged
        pFunction = Nothing
        ddFunction.DataSource = pFunction
        ddFunction.DataBind()
        pFunction = objDerived.GetDataTable("exec ams.m_function " & ddRC.SelectedItem.Value & "", CommandType.Text)
        ddFunction.DataSource = pFunction
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.Enabled = True
        ddRC.Enabled = False
    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddFunction.SelectedIndexChanged
        ddFunction.Enabled = False

        RoleName.Text = objDerived.replaceapostrophe(ddRC.SelectedItem.Text) + " " + objDerived.replaceapostrophe(ddFunction.SelectedItem.Text)
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedIndex = 0 Then
            MultiView1.SetActiveView(View2)
            CreateRoleButton.ValidationGroup = "save2"
        Else
            MultiView1.SetActiveView(View1)
            CreateRoleButton.ValidationGroup = "save1"
        End If
    End Sub

    Protected Sub ChkRCList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkRCList.SelectedIndexChanged
        Try
            For i As Integer = 0 To ChkRCList.Items.Count - 1

                If ChkRCList.Items(i).Selected = True Then
                    Dim rc_id As Integer = obj.GetValue("Select office_id from dbo.view_RC_SystemManager where rc_name like '" & replaceapostrophe(ChkRCList.Items(i).Text) & "'", CommandType.Text)
                    Dim function_id As Integer = obj.GetValue("Select function_id from dbo.view_RC_SystemManager where rc_name like '" & replaceapostrophe(ChkRCList.Items(i).Text) & "'", CommandType.Text)
                    obj.GetRecords("exec dbo.spSave_tbl_RC_Management '" & lblRoleName.Text & "','" & rc_id & "','" & function_id & "','" & True & "'", CommandType.Text)

                Else
                    Try
                        Dim rc_id As Integer = obj.GetValue("Select office_id from dbo.view_RC_SystemManager where rc_name like '" & replaceapostrophe(ChkRCList.Items(i).Text) & "'", CommandType.Text)
                        Dim function_id As Integer = obj.GetValue("Select function_id from dbo.view_RC_SystemManager where rc_name like '" & replaceapostrophe(ChkRCList.Items(i).Text) & "'", CommandType.Text)
                        obj.GetRecords("Delete from dbo.tbl_RC_Management where RoleName like '" & lblRoleName.Text & "' and rc_ID = '" & rc_id & "' and function_id = '" & function_id & "'", CommandType.Text)

                    Catch ex As Exception

                    End Try

                End If
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Function replaceapostrophe(ByVal str As String) As String
        Return Replace(Str, "'", "''")
    End Function

    Protected Sub RoleList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RoleList.SelectedIndexChanged

    End Sub
End Class
