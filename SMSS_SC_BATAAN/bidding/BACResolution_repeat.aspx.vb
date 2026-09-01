Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine

Partial Class bidding_BACResolution_repeat
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    'Dim obj As New BaseClasses.DBPassUsernname

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Session("view") = 0
        Loadreport()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "Bidding" Then
            Me.Page.Response.Redirect("~/bidding/t_repeatorderapproval.aspx")
        ElseIf Session("Page") = "Reports" Then
            Me.Page.Response.Redirect("~/bidding/RQ_BAC_ResolutionR.aspx")
        End If
    End Sub

    Protected Sub Loadreport()
        Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource1

        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Hdr_ID", Session("Hdr_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Supplier_ID", Session("Supplier_ID"))
    End Sub

End Class
