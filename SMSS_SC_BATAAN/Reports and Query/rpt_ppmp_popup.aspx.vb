
Partial Class planning_rpt_ppmp_popup
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportSource1.Report.FileName = "t_rpt__ppmp_history.rpt"
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@rc_id", Session("RC_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("Year"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", Session("GA_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@BGA_ID", Session("BGA_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Project_ID", Session("Project_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Program_ID", Session("Program_id"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prev", False)
    End Sub
End Class
