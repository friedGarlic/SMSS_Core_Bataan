
Partial Class body
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
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

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim url As String = objDerived.GetValue("select URL from GEOFMS_INTEGRATION.dbo.Application_Links where SystemID=5", Data.CommandType.Text)
        Me.Page.Response.Redirect(url.ToString)
    End Sub
End Class
