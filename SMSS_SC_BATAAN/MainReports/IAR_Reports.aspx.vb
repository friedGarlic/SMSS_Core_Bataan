Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class MainReports_IAR_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument
    Private Sub MainReports_IAR_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load

        lblTitle.Text = "INSPECTION AND ACCEPTANCE REPORTS"

        LoadReportFormat()

    End Sub

    Private Sub MainReports_IAR_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub

    Protected Sub drpReportFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpReportFormat.SelectedIndexChanged
        LoadReportFormat()
    End Sub

    Protected Sub LoadReportFormat()
        If drpReportFormat.SelectedItem.Value = 1 Then
            'Me.CrystalReportSource1.Report.FileName = "IAR_Short.rpt"
            'Me.IARReports.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@AIRHdr_ID", Session("AIRHdr_ID"))
            rpt.FileName = Server.MapPath("IAR_Short.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue(0, Me.Session("AIRHdr_ID"))
            Me.IARReports.ReportSource = rpt

        ElseIf drpReportFormat.SelectedItem.Value = 2 Then
            'Me.CrystalReportSource2.Report.FileName = "IAR_Long.rpt"
            'Me.IARReports.ReportSource = Me.CrystalReportSource2
            'Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@AIRHdr_ID", Session("AIRHdr_ID"))
            rpt.FileName = Server.MapPath("IAR_Long.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue(0, Me.Session("AIRHdr_ID"))
            Me.IARReports.ReportSource = rpt
        End If
    End Sub


    Protected Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click
        If Session("Page") = "RQ" Then
            Me.Page.Response.Redirect("~/Procurement/t_inspection_and_acceptanceR.aspx")
        ElseIf Session("Page") = "IAR" Then
            Me.Page.Response.Redirect("~/procurement/t_Inspection_Acceptance.aspx")
        End If
    End Sub
End Class
