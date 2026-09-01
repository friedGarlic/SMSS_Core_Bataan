
Partial Class procurement_rpt_ARP
    Inherits System.Web.UI.Page
    Private objDerived As New BaseClasses.DBPassUsernname

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.CrystalReportSource1.Report.FileName = "rpt_APR.rpt"
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))

        'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@DBM_ID", Session("DBM_ID"))
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Year", Session("Year"))
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Quarter", Session("Quarter"))

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/procurement/t_DBM_APR.aspx")
    End Sub
End Class
