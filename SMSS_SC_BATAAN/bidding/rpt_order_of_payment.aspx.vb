Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class rpt_order_of_payment


    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Session("view") = "2"

        'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Me.Session("pre_procurement_hdr_id").ToString)

        rpt.FileName = Server.MapPath("rpt_order_of_payment.rpt")
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue(0, Me.Session("pre_procurement_hdr_id"))
        Me.CrystalReportViewer1.ReportSource = rpt

    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "BID" Then
            Me.Page.Response.Redirect("~/bidding/t_pre_procurement_public_bidding.aspx")
        Else
            Me.Page.Response.Redirect("~/bidding/t_order_of_paymentR.aspx")
        End If

    End Sub

End Class
