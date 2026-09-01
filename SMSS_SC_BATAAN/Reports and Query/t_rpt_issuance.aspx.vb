Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class t_rpt_issuance
    Inherits System.Web.UI.Page
    Dim DBPassUsernname As New connectionreport
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule
    Dim msg As New MsgeBox

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ddYear.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.APP ORDER BY year", CommandType.Text)
            ddYear.DataTextField = ("year")
            ddYear.DataValueField = ("year")
            ddYear.DataBind()
            ddYear.Items.Insert(0, "Select")
        End If
    End Sub


    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            If ddMonth.SelectedItem.Text = "Select" Or ddYear.SelectedItem.Text = "Select" Then

            Else
                Me.Page.Response.Redirect("~/Reports and Query/rpt_IssuanceReport.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddMonth.SelectedIndexChanged
        Session("Month") = ddMonth.SelectedItem.Value
    End Sub

    Protected Sub ddYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddYear.SelectedIndexChanged
        Session("Year") = ddYear.SelectedItem.Value

    End Sub
End Class
