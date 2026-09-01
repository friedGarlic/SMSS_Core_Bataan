Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Drawing
Partial Class Roles_time
    Inherits System.Web.UI.Page




    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim dob As DateTime = DateTime.Parse(Request.Form(txtDate.UniqueID))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cssLink As New HtmlLink()
        cssLink.Href = "~/Styles/calendar-blue.css"
        cssLink.Attributes.Add("rel", "stylesheet")
        cssLink.Attributes.Add("type", "text/css")
        Header.Controls.Add(cssLink)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class
