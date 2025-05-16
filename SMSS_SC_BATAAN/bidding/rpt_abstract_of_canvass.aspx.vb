
Partial Class bidding_rpt_abstract_of_canvass
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Hdr_ID", Session("Hdr_ID"))

    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "Bidding" Then
            Me.Page.Response.Redirect("~/bidding/t_abstract_of_canvass.aspx")
        Else
            Me.Page.Response.Redirect("~/Reports and Query/Abstract_Canvass.aspx")
        End If
    End Sub
End Class
