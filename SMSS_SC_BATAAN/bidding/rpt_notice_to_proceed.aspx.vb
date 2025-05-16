Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class rpt_notice_to_proceed
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Me.Session("view") = "0"
        'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("Bid_ID"))

        rpt.FileName = Server.MapPath("rpt_notice_to_proceed.rpt")
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue(0, Me.Session("Bid_ID"))
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "BID" Then
            Me.Page.Response.Redirect("~/bidding/t_notice_to_proceed.aspx")
        ElseIf Session("Page") = "Direct" Then
            Me.Page.Response.Redirect("~/bidding/t_Award_of_Contract_Direct.aspx")
        Else

            Me.Page.Response.Redirect("~/bidding/t_notice_to_proceedR.aspx")
        End If

    End Sub

    Private Sub rpt_notice_to_proceed_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub
End Class
