Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Partial Class Reports_and_Query_rpt_abstract_of_bids_calculated
    Inherits System.Web.UI.Page

    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("ReportType") = "bidding_AOB" ' Default selection
        End If
        LoadReport(Session("ReportType").ToString()) ' Ensure report is loaded on every postback
    End Sub


    'Protected Sub btnLoadReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim selectedReport As String = ddlReportSelection.SelectedValue
    '    LoadReport(selectedReport)
    'End Sub
    Private Sub LoadReport(ByVal reportType As String)
        Dim reportPath As String

        If reportType = "bidding_AOB" Then
            reportPath = "rpt_abstract_bids_bidding_AOB.rpt"

        ElseIf reportType = "bidding" Then
            reportPath = "rpt_abstract_bids_bidding.rpt"
        Else
            reportPath = "rpt_abstract_bids_bidding_read.rpt"
        End If

        rpt.FileName = Server.MapPath(reportPath)
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue(0, Me.Session("pre_procurement_hdr_id"))
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub


    Protected Sub ddlReportSelection_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Session("ReportType") = ddlReportSelection.SelectedValue
        LoadReport(Session("ReportType").ToString())
    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/bidding/t_abstract_of_bids.aspx")
    End Sub
End Class
