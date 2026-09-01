
Partial Class MasterPageSysmanager
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.lblDate.Text = Now.ToLongDateString & " | " & DateTime.Now.ToLongTimeString()
            If Not Session("user") = Nothing Then
                Me.lblUser.Text = FileClass.b64decode(Session("user"))
            End If
        End If
    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session.Abandon()
        FormsAuthentication.SignOut()
        Page.Response.Redirect("~\MainPage\frm_index.aspx")
    End Sub

    
End Class

