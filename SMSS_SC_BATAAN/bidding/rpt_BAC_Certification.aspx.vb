
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class bidding_rpt_BAC_Certification
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CrystalReportSource1.Report.FileName = "rpt_BAC_Certification.rpt"
        'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@obr_evaluation_hdr_id", Session("obr_evaluation_hdr_id"))

        rpt.FileName = Server.MapPath("rpt_BAC_Certification.rpt")
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue(0, Me.Session("obr_evaluation_hdr_id"))
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub
End Class
