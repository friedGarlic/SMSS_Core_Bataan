
Partial Class Membership_ChangePassword
    Inherits System.Web.UI.Page

    Dim obj As New AccessRule
    Dim msg As New MsgeBox
    ' Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
            If usr.GetPassword.ToString = txtoldpassword.Text Then
                If txtnewpassword.Text = txtconfirmpassword.Text Then
                    If Membership.ValidateUser(Me.Session("@UserName").ToString, txtoldpassword.Text) Then
                        usr.ChangePassword(txtoldpassword.Text, txtnewpassword.Text)

                        msg.UserMsgBox("Password succesfully changed", Me, False)
                        lblerror.Text = " "
                    End If
                Else
                    lblerror.Text = "The Confirm New Password must match the New Password entry."
                End If

            Else
                lblerror.Text = "Invalid Old Password"
            End If
        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)

        End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
      
            txtoldpassword.Text = ""
            txtnewpassword.Text = ""
            txtconfirmpassword.Text = ""
            lblerror.Text = " "
        End If
        ' Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
        ' lblerror.Text = usr.PasswordQuestion()
    End Sub

    
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim usr As MembershipUser = Membership.GetUser(txtuser.Text)
            Label1.Text = usr.GetPassword(TextBox1.Text)
            ' Label1.Text = usr.PasswordQuestion().ToString()
            lblinfo.Text = "Password Retrieved!"
        Catch ex As Exception

            lblinfo.Text = "Your answer is incorrect. Please try again."

            ' Does there exist a User account for this user?
            Dim usrInfo As MembershipUser = Membership.GetUser(txtuser.Text)
            If usrInfo IsNot Nothing Then
                ' Is this user locked out?
                If usrInfo.IsLockedOut Then
                    lblinfo.Text = "Your account has been locked out because of too many invalid retrieve password attempts. Please contact the administrator to have your account unlocked."
                End If
            End If

            
        End Try
        
    End Sub

   
End Class
