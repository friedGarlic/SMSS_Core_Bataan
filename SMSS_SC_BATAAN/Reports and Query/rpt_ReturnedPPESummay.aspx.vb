
Partial Class Reports_and_Query_rpt_ReturnedPPESummay
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Status", Session("Status"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Year", Session("Year"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", Session("Month"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@PreparedBy_ID", Session("PreparedBy"))

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Reports and Query/t_ReturnedSummary.aspx")
    End Sub
End Class
