Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Partial Class Roles_UsersAndRoles
    Inherits System.Web.UI.Page
#Region "Paging Interface Click Event Handlers"
    Protected Sub lnkFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFirst.Click
        Me.PageIndex = 0
        BindUserAccounts()
    End Sub

    Protected Sub lnkPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrev.Click
        Me.PageIndex -= 1
        BindUserAccounts()
    End Sub

    Protected Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
        Me.PageIndex += 1
        BindUserAccounts()
    End Sub

    Protected Sub lnkLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLast.Click
        ' Determine the total number of records
        Dim totalRecords As Integer
        Membership.FindUsersByName(Me.UsernameToMatch + "%", Me.PageIndex, Me.PageSize, totalRecords)

        ' Navigate to the last page index
        Me.PageIndex = (totalRecords - 1) / Me.PageSize
        BindUserAccounts()
    End Sub
#End Region

#Region "Properties"
    Private Property UsernameToMatch() As String
        Get
            Dim o As Object = ViewState("UsernameToMatch")
            If o Is Nothing Then
                Return String.Empty
            Else
                Return o.ToString()
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("UsernameToMatch") = Value
        End Set
    End Property

    Private Property PageIndex() As Integer
        Get
            Dim o As Object = ViewState("PageIndex")
            If o Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(o)
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState("PageIndex") = Value
        End Set
    End Property

    Private ReadOnly Property PageSize() As Integer
        Get
            Return 10
        End Get
    End Property
#End Region
    Private Sub BindFilteringUI()
        Dim filterOptions() As String = {"All", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        FilteringUI.DataSource = filterOptions
        FilteringUI.DataBind()
    End Sub

    Private Sub BindUserAccounts()
        Dim totalRecords As Integer
        UserAccounts.DataSource = Membership.FindUsersByName(Me.UsernameToMatch + "%", Me.PageIndex, Me.PageSize, totalRecords)
        UserAccounts.DataBind()

        ' Enable/disable the paging interface
        Dim visitingFirstPage As Boolean = (Me.PageIndex = 0)
        lnkFirst.Enabled = Not visitingFirstPage
        lnkPrev.Enabled = Not visitingFirstPage

        Dim lastPageIndex As Integer = (totalRecords - 1) / Me.PageSize
        Dim visitingLastPage As Boolean = (Me.PageIndex >= lastPageIndex)
        lnkNext.Enabled = Not visitingLastPage
        lnkLast.Enabled = Not visitingLastPage
    End Sub

    Protected Sub FilteringUI_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles FilteringUI.ItemCommand
        If e.CommandName = "All" Then
            Me.UsernameToMatch = String.Empty
        Else
            Me.UsernameToMatch = e.CommandName
        End If

        BindUserAccounts()
    End Sub
    Private Sub LoadApplications()
        Dim objDrpDwn As New BaseDrpDwn.DropdownLoad
        objDrpDwn.loadDrpDwnList(Me.ddlApplication, "SELECT * FROM aspnet_Applications", "ApplicationName", "ApplicationId", CommandType.Text)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadApplications()
            BindUserAccounts()
            BindFilteringUI()
            BindRolesToList()
        End If
    End Sub

    Private Sub BindRolesToList()
        ' Get all of the roles
        Dim roleNames() As String = Roles.GetAllRoles()
        RoleList.DataSource = roleNames
        RoleList.DataBind()
    End Sub
    Private Sub FilterRoleByApplication()
        Dim objDrpDwn As New BaseDrpDwn.DropdownLoad
        Dim qry As String = "SELECT * FROM aspnet_Roles WHERE ApplicationId='" & Me.ddlApplication.SelectedValue & "'"

        objDrpDwn.loadDrpDwnList(Me.RoleList, qry, "RoleName", "RoleName", CommandType.Text)
    End Sub

#Region "'By User' Interface-Specific Methods"
    Private Sub BindUsersToUserList()
        ' Get all of the user accounts
        Dim users As MembershipUserCollection = Membership.GetAllUsers()
        'UserList.DataSource = users
        'UserList.DataBind()
    End Sub
#End Region

#Region "'By Role' Interface-Specific Methods"
    
    Private Sub DisplayUsersBelongingToRole()
        ' Get the selected role
        Dim selectedRoleName As String = RoleList.SelectedValue

        ' Get the list of usernames that belong to the role
        Dim usersBelongingToRole() As String = Roles.GetUsersInRole(selectedRoleName)

        ' Bind the list of users to the GridView
        RolesUserList.DataSource = usersBelongingToRole
        RolesUserList.DataBind()
    End Sub

    Protected Sub RolesUserList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles RolesUserList.RowDeleting
        ' Get the selected role
        Dim selectedRoleName As String = RoleList.SelectedValue

        ' Reference the UserNameLabel
        Dim UserNameLabel As Label = CType(RolesUserList.Rows(e.RowIndex).FindControl("UserNameLabel"), Label)

        ' Remove the user from the role
        Roles.RemoveUserFromRole(UserNameLabel.Text, selectedRoleName)

        ' Refresh the GridView
        DisplayUsersBelongingToRole()

        ' Display a status message
        ActionStatus.Text = String.Format("User {0} was removed from role {1}.", UserNameLabel.Text, selectedRoleName)

        ' Refresh the "by user" interface
        'heckRolesForSelectedUser()
    End Sub

    Protected Sub AddUserToRoleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddUserToRoleButton.Click
        'Get the selected role and username
        Dim selectedRoleName As String = RoleList.SelectedValue

        Dim users As New List(Of String)
        'Dim x As Integer = 0
        For Each gvr As GridViewRow In UserAccounts.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("RowLevelCheckBox"), CheckBox)
            If cb.Checked = True Then
                'Dim s As String = gvr.Cells(1).Text
                users.Add((gvr.Cells(1).Text))

            End If
        Next
        
        For Each userToAddToRole As String In users
            Dim rolesBelong() As String = Roles.GetRolesForUser(userToAddToRole)
            For Each s As String In rolesBelong
                Roles.RemoveUserFromRole(userToAddToRole, s)
            Next
        Next

        For Each userToAddToRole As String In users
            Roles.AddUserToRole(userToAddToRole, selectedRoleName)
        Next
       
        'Refresh the GridView
        DisplayUsersBelongingToRole()

    End Sub
#End Region

    Protected Sub UserAccounts_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserAccounts.DataBound
        'Each time the data is bound to the grid we need to build up the CheckBoxIDs array
        Try
            'Get the header CheckBox
            Dim cbHeader As CheckBox = CType(UserAccounts.HeaderRow.FindControl("HeaderLevelCheckBox"), CheckBox)

            'Run the ChangeCheckBoxState client-side function whenever the
            'header checkbox is checked/unchecked
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"

            'Add the CheckBox's ID to the client-side CheckBoxIDs array
            Dim ArrayValues As New List(Of String)
            ArrayValues.Add(String.Concat("'", cbHeader.ClientID, "'"))

            For Each gvr As GridViewRow In UserAccounts.Rows
                'Get a programmatic reference to the CheckBox control
                Dim cb As CheckBox = CType(gvr.FindControl("RowLevelCheckBox"), CheckBox)

                'If the checkbox is unchecked, ensure that the Header CheckBox is unchecked
                cb.Attributes("onclick") = "ChangeHeaderAsNeeded();"

                'Add the CheckBox's ID to the client-side CheckBoxIDs array
                ArrayValues.Add(String.Concat("'", cb.ClientID, "'"))
            Next

            'Output the array to the Literal control (CheckBoxIDsArray)
            CheckBoxIDsArray.Text = "<script type=""text/javascript"">" & vbCrLf & _
                                    "<!--" & vbCrLf & _
                                    String.Concat("var CheckBoxIDs =  new Array(", String.Join(",", ArrayValues.ToArray()), ");") & vbCrLf & _
                                    "// -->" & vbCrLf & _
                                    "</script>"
        Catch ex As Exception

        End Try
       
    End Sub

    
   
    
    Protected Sub ViewUsers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewUsers.Click
        DisplayUsersBelongingToRole()
    End Sub

    Protected Sub ddlApplication_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlApplication.SelectedIndexChanged
        FilterUsersByApplication()
        FilterRoleByApplication()
    End Sub

    Private Sub FilterUsersByApplication()
        Dim objBase As New BaseGeneral
        Dim dt As New DataTable
        Dim qry As String = "select * from dbo.vw_aspnet_MembershipUsers where ApplicationId='" & Me.ddlApplication.SelectedValue & "'"

        dt = objBase.GetDataTable(qry, CommandType.Text)

        Dim totalRecords As Integer
        totalRecords = dt.Rows.Count

        UserAccounts.DataSource = dt
        UserAccounts.DataBind()

        'Membership.FindUsersByName(Me.UsernameToMatch + "%", Me.PageIndex, Me.PageSize, totalRecords)


        ' Enable/disable the paging interface
        Dim visitingFirstPage As Boolean = (Me.PageIndex = 0)
        lnkFirst.Enabled = Not visitingFirstPage
        lnkPrev.Enabled = Not visitingFirstPage

        Dim lastPageIndex As Integer = (totalRecords - 1) / Me.PageSize
        Dim visitingLastPage As Boolean = (Me.PageIndex >= lastPageIndex)
        lnkNext.Enabled = Not visitingLastPage
        lnkLast.Enabled = Not visitingLastPage
    End Sub
End Class
