Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class rpt_purchase_request
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Session("view") = "0"

        If rdPRFormat.SelectedItem.Value = 1 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("prhdr_id"))

        ElseIf rdPRFormat.SelectedItem.Value = 2 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue(0, Session("prhdr_id"))
        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "RQ" Then
            Me.Page.Response.Redirect("~/Reports and Query/t_purchase_request.aspx")
        ElseIf Session("Page") = "CancelPR" Then
            Me.Page.Response.Redirect("~/procurement/t_Cancelled_PR.aspx")
        Else
            Me.Page.Response.Redirect("~/procurement/t_purchase_request_v2.aspx")
        End If

    End Sub

    Protected Sub rdPRFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPRFormat.SelectedIndexChanged
        If rdPRFormat.SelectedItem.Value = 1 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportViewer1.DisplayToolbar = True
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("prhdr_id"))

        ElseIf rdPRFormat.SelectedItem.Value = 2 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue(0, Session("prhdr_id"))
        End If
    End Sub
End Class
