
Partial Class MainReports_rpt_ssmi
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub MainReports_rpt_ssmi_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.SSMI.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        Me.SSMI.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@DateFrom", Session("DateFrom"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@DateTo", Session("DateTo"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Preparedby", Session("Preparedby"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Certifiedby", Session("Certifiedby"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Postedby", Session("Postedby"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", Session("GA_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", 0)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", 0)
        Me.SSMI.Zoom(80)
    End Sub

    Private Sub MainReports_rpt_ssmi_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Protected Sub lnkback_Click(sender As Object, e As EventArgs)
        Me.Page.Response.Redirect("~/Reports and Query/AdditionalReports/summarysuppliedused.aspx")
    End Sub
End Class
