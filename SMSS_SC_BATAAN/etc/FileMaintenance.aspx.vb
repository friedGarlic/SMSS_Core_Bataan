
Partial Class FileMaintenance
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblUser.Text = Me.Session("LogUser")
        Me.lblDate.Text = Now.ToLongDateString & " | " & DateTime.Now.ToLongTimeString()

        If Not Page.IsPostBack Then
            obj.LoadAccessibleURL(Session("@UserID"), Session("@RoleID"))
            Dim a = Session("@RoleID")
        End If
    End Sub

    Protected Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLogout.Click
        Session.Abandon()
        FormsAuthentication.SignOut()

        'redirect to login page
        Response.Redirect("~/index.aspx")
    End Sub
End Class
