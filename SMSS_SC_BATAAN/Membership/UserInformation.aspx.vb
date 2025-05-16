Partial Class Administration_UserInformation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Page.IsPostBack Then
                ' If querystring value is missing, send the user to ManageUsers.aspx
                Dim userName As String = Request.QueryString("user")
                If String.IsNullOrEmpty(userName) Then
                    Response.Redirect("ManageUsers.aspx")
                End If

                ' Get information about this user
                Dim usr As MembershipUser = Membership.GetUser(userName)
                If usr Is Nothing Then
                    Response.Redirect("ManageUsers.aspx")
                End If

                UserNameLabel.Text = usr.UserName
                IsApproved.Checked = usr.IsApproved


                If usr.LastLockoutDate.Year < 2000 Then
                    LastLockoutDateLabel.Text = String.Empty
                Else
                    LastLockoutDateLabel.Text = usr.LastLockoutDate.ToShortDateString()

                    UnlockUserButton.Enabled = usr.IsLockedOut
                End If
                BindRolesToList()

                Dim role() As String = Roles.GetRolesForUser(usr.UserName)
                Me.lblRole.Text = role(0)
            End If

        Catch ex As Exception
            Me.lblRole.Text = ""
        End Try
    End Sub
    Private Sub BindRolesToList()
        ' Get all of the roles
        Dim roleNames() As String = Roles.GetAllRoles()

        RoleList.DataSource = roleNames
        RoleList.DataBind()
    End Sub

    Protected Sub IsApproved_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles IsApproved.CheckedChanged
        'Toggle the user's approved status
        Dim userName As String = Request.QueryString("user")
        Dim usr As MembershipUser = Membership.GetUser(userName)
        usr.IsApproved = IsApproved.Checked
        Membership.UpdateUser(usr)

        StatusMessage.Text = "The user's approved status has been updated."
    End Sub

    Protected Sub UnlockUserButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UnlockUserButton.Click
        'Unlock the user account
        Dim userName As String = Request.QueryString("user")
        Dim usr As MembershipUser = Membership.GetUser(userName)
        usr.UnlockUser()

        UnlockUserButton.Enabled = False
        StatusMessage.Text = "The user account has been unlocked."
    End Sub

    Protected Sub AddUserToRoleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddUserToRoleButton.Click
        ' Get the selected role and username
        Dim selectedRoleName As String = RoleList.SelectedValue
        Dim userToAddToRole As String = UserNameLabel.Text

        ' Make sure that the user exists in the system
        Dim userInfo As MembershipUser = Membership.GetUser(userToAddToRole)

        ' Make sure that the user doesn't already belong to this role
        If Roles.IsUserInRole(userToAddToRole, selectedRoleName) Then
            StatusMessage.Text = String.Format("User {0} is already a member of role {1}.", userToAddToRole, selectedRoleName)
            Exit Sub
        End If

        'Check if user exists in other roles
        Dim rolesBelong() As String = Roles.GetRolesForUser(userToAddToRole)
        For Each s As String In rolesBelong
            Roles.RemoveUserFromRole(userToAddToRole, s)
        Next

        ' If we reach here, we need to add the user to the role
        Roles.AddUserToRole(userToAddToRole, selectedRoleName)
        Roles.GetRolesForUser(userToAddToRole)

        ' Display a status message
        StatusMessage.Text = String.Format("User {0} was added to role {1}.", userToAddToRole, selectedRoleName)

        ' Refresh the "by user" interface
        Me.lblRole.Text = selectedRoleName
    End Sub
End Class
