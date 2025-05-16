
Partial Class Membership_CreatingUserAccounts
    Inherits System.Web.UI.Page

    Const passwordQuestion As String = "Birthdate"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            SecurityQuestion.Text = passwordQuestion
            'Dim objSec As New AccessRule
            'objSec.GetAccessRight(Session("user"), Me)
            'If objSec.HasAccess = False Then
            '    Response.Redirect("~/UnauthorizedAccess.aspx")
            'Else
            '    'Set Button Level Access Rights
            '    Me.CreateAccountButton.Enabled = objSec.CanAdd
            'End If

        End If
    End Sub
    Private Sub CreateProfile(ByVal userName As String)
        ProfileBase.Create(userName)
        Dim ProfileID As ProfileCommon

        ProfileID = Profile.GetProfile(userName)
        ProfileID.FirstName = Me.txtFName.Text
        ProfileID.LastName = Me.txtLName.Text
        ProfileID.MiddleName = Me.txtMI.Text
        ProfileID.EmailAddress = Me.Email.Text
        ProfileID.Cellphone = Me.txtContact.Text
        ProfileID.Position = Me.txtPosition.Text
        ProfileID.Department = Me.txtDept.Text
        ProfileID.Save()
    End Sub
    Protected Sub CreateAccountButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateAccountButton.Click
        Dim createStatus As MembershipCreateStatus
        'Dim user As MembershipUser
        'user.ChangePassword("", "")

        If ValidateCredentials() = True Then
            Dim newUser As MembershipUser = _
                    Membership.CreateUser(Username.Text, Password.Text, _
                                       Email.Text, "When's my bday?", _
                                       SecurityAnswer.Text, True, _
                                       createStatus)

            Select Case createStatus
                Case MembershipCreateStatus.Success
                    CreateAccountResults.Text = "The user account was successfully created!"
                    CreateProfile(Username.Text)

                Case MembershipCreateStatus.DuplicateUserName
                    CreateAccountResults.Text = "There already exists a user with this username."

                Case MembershipCreateStatus.DuplicateEmail
                    CreateAccountResults.Text = "There already exists a user with this email address."

                Case MembershipCreateStatus.InvalidEmail
                    CreateAccountResults.Text = "There email address you provided in invalid."

                Case MembershipCreateStatus.InvalidAnswer
                    CreateAccountResults.Text = "There security answer was invalid."

                Case MembershipCreateStatus.InvalidPassword
                    CreateAccountResults.Text = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character."

                Case Else
                    CreateAccountResults.Text = "There was an unknown error; the user account was NOT created."
            End Select


        End If
    End Sub

    Private Function ValidateCredentials() As Boolean
        Dim trimmedUserName As String = Me.Username.Text
        If Me.Username.Text.Length <> trimmedUserName.Length Then
            ' Show the error message
            InvalidUserNameOrPasswordMessage.Text = "The username cannot contain leading or trailing spaces."
            InvalidUserNameOrPasswordMessage.Visible = True

            ' Cancel the create user workflow
            Return False 'e.Cancel = True
        Else
            ' Username is valid, make sure that the password does not contain the username
            If Me.Password.Text.IndexOf(Me.Username.Text, StringComparison.OrdinalIgnoreCase) >= 0 Then
                ' Show the error message
                InvalidUserNameOrPasswordMessage.Text = "The username may not appear anywhere in the password."
                InvalidUserNameOrPasswordMessage.Visible = True

                ' Cancel the create user workflow
                'e.Cancel = True
                Return False
            Else
                Return True
            End If
        End If
    End Function
End Class
