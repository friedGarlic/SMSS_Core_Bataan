
Partial Class planning_rpt_ppmp_contingency
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim DBPassUsernname As New connectionreport


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Year", Session("Year"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/planning/t_ppmp_contingency.aspx")
    End Sub
End Class
