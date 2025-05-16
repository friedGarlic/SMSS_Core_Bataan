
Partial Class bidding_rpt_canvass_sheet
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportSource1.Report.FileName = "rpt_canvass_sheet.rpt"
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@PRHdr_ID", Session("prhdr_id"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isRecanvass", Session("isRecanvass"))
    End Sub
End Class
