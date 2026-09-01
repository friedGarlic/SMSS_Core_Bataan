Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Partial Class bidding_rpt_BidEval_PostQua_v2
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim obj As New BaseClasses.DBPassUsernname

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Session("view") = "0"

        Me.CrystalReportViewer5.ReportSource = Me.CrystalReportSource1

        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Supplier_Id", Session("Supplier_Id"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@obr_evaluation_hdr_id", Session("obr_hdr"))

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("PQ") = "Post_Qua" Then
            Me.Page.Response.Redirect("~/bidding/t_bid_evaluation_PQ.aspx")
        ElseIf Session("PQ") = "Report" Then
            Me.Page.Response.Redirect("~/bidding/t_post_qualification_report.aspx")

        End If

    End Sub

End Class
