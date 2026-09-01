
Partial Class Reports_and_Query_rpt_IssuanceReport
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", Session("Month"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Year", Session("Year"))
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Reports and Query/t_rpt_issuance.aspx")
    End Sub
End Class
