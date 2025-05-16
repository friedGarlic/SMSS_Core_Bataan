
Partial Class Site
    Inherits System.Web.UI.MasterPage
    Dim obj As New AccessRule

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.lblDate.Text = Now.ToLongDateString & " | " & DateTime.Now.ToLongTimeString()
        'Me.lblTime.Text = DateTime.Now.ToLongTimeString()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.lblDate.Text = Now.ToLongDateString & " | " & DateTime.Now.ToLongTimeString()
            If Not Session("user") = Nothing Then
                Me.lblUser.Text = FileClass.b64decode(Session("user"))
            End If
        End If
        obj.LoadAccessibleURL(Session("@UserID"), Session("@RoleID"))
        'Me.lblDate.Text = Now.ToLongDateString
        'Me.lblTime.Text = DateTime.Now.ToLongTimeString()

    End Sub
End Class

