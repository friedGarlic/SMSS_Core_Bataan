Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class bidding_rpt_canvass_sheet
    Inherits Page

    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadReport()
    End Sub

    Private Sub LoadReport()
        Dim reportPath As String = Server.MapPath("~/bidding/rpt_canvass_sheet_v2.rpt")
        Dim reportDoc As New ReportDocument()
        reportDoc.Load(reportPath)
        reportDoc.SetDatabaseLogon(objDerived.username, objDerived.Password)
        reportDoc.SetParameterValue("@PRHdr_ID", Session("prhdr_id"))
        reportDoc.SetParameterValue("@isRecanvass", Session("isRecanvass"))
        CrystalReportViewer1.ReportSource = reportDoc
        CrystalReportViewer1.DataBind()
        Session("ReportDoc") = reportDoc
    End Sub

End Class
