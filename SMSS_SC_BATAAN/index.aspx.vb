Imports System.Web
Imports System.Net.Http
Imports System.Web.Configuration
Imports Newtonsoft.Json

Partial Class index
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private getprofile As New ProfileCommon
    Dim msg2 As New MsgeBox
    Dim api As New UserInfoDTO


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.IsAuthenticated AndAlso Not String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
                ' This is an unauthorized, authenticated request...
                Response.Redirect("~/UnauthorizedAccess.aspx")
            End If
        End If
    End Sub

    'Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
    '     Validate the user against the Membership framework user store
    '    If Membership.ValidateUser(UserName.Text, Password.Text) Then
    '         Log the user into the site
    '        FormsAuthentication.RedirectFromLoginPage(UserName.Text, RememberMe.Checked)
    '    End If

    '     If we reach here, the user's credentials were invalid
    '        InvalidCredentialsMessage.Visible = True
    'End Sub

    'Protected Sub myLogin_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles myLogin.Authenticate
    '    ' Verify that the username/password pair is valid
    '    If Membership.ValidateUser(myLogin.UserName, myLogin.Password) Then
    '        ' Username/password are valid, check email
    '        e.Authenticated = True
    '    Else
    '        ' Username/password are not valid...
    '        e.Authenticated = False
    '    End If
    'End Sub

    'Protected Sub myLogin_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles myLogin.LoggedIn
    '    Try
    '        Dim userName As String = myLogin.UserName
    '        Dim password As String = myLogin.Password

    '        Dim user As MembershipUser = Membership.GetUser(userName, True)
    '        'get the app id of user
    '        Dim userID As String = Convert.ToString(user.ProviderUserKey)
    '        Session("user") = FileClass.b64encode(userName)

    '        Session.Add("@UserID", userID)
    '        Session.Add("@UserName", userName)
    '        Session.Add("@Password", password)
    '        Session.Add("@RoleID", Roles.GetRolesForUser(userName).GetValue(0).ToString)

    '        obj.LoadAccessibleURL(Session("@UserID"), Session("@RoleID"))
    '        Dim a = Session("@RoleID")

    '        Dim Fname, MI, Lname As String
    '        Fname = getprofile.GetProfile(Session("@UserName")).FirstName.ToString()
    '        MI = getprofile.GetProfile(Session("@UserName")).MiddleName.ToString
    '        Lname = getprofile.GetProfile(Session("@UserName")).LastName.ToString()

    '        Me.Session("LogUser") = UCase("WELCOME, " & Fname)

    '        If Membership.ValidateUser(userName, password) Then
    '            Me.Session("SubModuleID") = 0
    '            'If Roles.IsUserInRole(userName, "administrator") Then
    '            Response.Redirect("~/etc/body.aspx")
    '        Else
    '            Response.Redirect("index.aspx")
    '            'End If
    '            'Response.Redirect("~/profile/ChangePassword.aspx?user=" & user.UserName)
    '        End If
    '    Catch ex As Exception
    '        MsgeBox.UserMsgBox("Your account has no ROLE assigned!. Please contact the administrator to have your account a ROLE.", Me, False)
    '    End Try
    '    '
    '    ' myLogin.FailureText = "Your account has no ROLE assiged!. Please contact the administrator to have your account a ROLE."
    'End Sub

    'Protected Sub myLogin_LoginError(ByVal sender As Object, ByVal e As System.EventArgs) Handles myLogin.LoginError
    '    ' Determine why the user could not login...        
    '    myLogin.FailureText = "Your login attempt was not successful. Please try again."

    '    ' Does there exist a User account for this user?
    '    Dim usrInfo As MembershipUser = Membership.GetUser(myLogin.UserName)
    '    If usrInfo IsNot Nothing Then
    '        ' Is this user locked out?
    '        If usrInfo.IsLockedOut Then
    '            myLogin.FailureText = "Your account has been locked out because of too many invalid login attempts. Please contact the administrator to have your account unlocked."
    '        ElseIf Not usrInfo.IsApproved Then
    '            myLogin.FailureText = "Your account has not yet been approved. You cannot login until an administrator has approved your account."
    '        End If
    '    End If
    'End Sub

    'Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'Validate the user against the Membership framework user store
    '    If Membership.ValidateUser(myLogin.UserName, myLogin.Password) Then
    '        ' Log the user into the site
    '        '   FormsAuthentication.RedirectFromLoginPage(myLogin.UserName, RememberMe)
    '    End If

    '    'If we reach here, the user's credentials were invalid
    '    ' mylogin.InvalidCredentialsMessage.Visible = True
    'End Sub

    'Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    'End Sub

    Protected Sub Password_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim userName As String = myLogin.UserName
            Dim password As String = myLogin.Password

            Dim user As MembershipUser = Membership.GetUser(userName, True)
            'get the app id of user
            Dim userID As String = Convert.ToString(user.ProviderUserKey)
            Session("user") = FileClass.b64encode(userName)

            Session.Add("@UserID", userID)
            Session.Add("@UserName", userName)
            Session.Add("@Password", password)
            Session.Add("@RoleID", Roles.GetRolesForUser(userName).GetValue(0).ToString)

            obj.LoadAccessibleURL(Session("@UserID"), Session("@RoleID"))
            Dim a = Session("@RoleID")

            Dim Fname, MI, Lname As String
            Fname = getprofile.GetProfile(Session("@UserName")).FirstName.ToString()
            MI = getprofile.GetProfile(Session("@UserName")).MiddleName.ToString
            Lname = getprofile.GetProfile(Session("@UserName")).LastName.ToString()

            Me.Session("LogUser") = UCase("WELCOME, " & Fname)
            Session("NotificationStatus") = "Show"

            If Membership.ValidateUser(userName, password) Then
                Me.Session("SubModuleID") = 0
                'If Roles.IsUserInRole(userName, "administrator") Then

                'Dim client As New HttpClient
                'Dim url As String
                'Dim usernameapi As String = "admin super"
                'url = String.Format(apiUrl + "/api/User/GetUserInfo?UserName={0}", usernameapi)

                'api = JavaScriptConvert.DeserializeObject(Of UserInfoDTO)(client.GetAsync(url).Result.Content.ReadAsStringAsync().Result)

                'Dim collection As NameValueCollection = New NameValueCollection()
                'collection.Set("UserDefaultModule", "/ViewRecords/ViewRecordsLand")
                'collection.Set("UserName", usernameapi)
                'collection.Set("EmployeeInfo", JavaScriptConvert.SerializeObject(api.EmployeeInfo))
                'collection.Set("EmployeeUser", JavaScriptConvert.SerializeObject(api.EmployeeUser))
                'collection.Set("EmployeeImage", JavaScriptConvert.SerializeObject(api.EmployeeImage))

                'Dim cookies As HttpCookie = New HttpCookie("PATAS PREMIER")
                'cookies.Values.Add(collection)
                'cookies.Expires = Date.Now.AddHours(10)
                'cookies.HttpOnly = False
                '' MsgBox(cookies.Values("UserName"))
                'Response.Cookies.Add(cookies)
                Response.Redirect("body.aspx")

            Else
                Response.Redirect("index.aspx")
                ''Your Login attempt was Not successful. Please try again
                'Response.Redirect("~/profile/ChangePassword.aspx?user=" & user.UserName)
            End If



            'collection.Set("EmployeeUser", pathName)
            'cookies.Values.Add()


        Catch ex As Exception
            msg2.UserMsgBox("Your account has no ROLE assigned!. Please contact the administrator to have your account a ROLE.", Me, False)
        End Try
    End Sub

    Dim apiUrl As String = ConfigurationManager.AppSettings("SampleAPI")
    Public Sub GetUserInfo(UserName As String)

    End Sub
End Class
