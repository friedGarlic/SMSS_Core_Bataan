
Partial Class Reports_and_Query_rpt_RequestInspection
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub Reports_and_Query_rpt_RequestInspection_Load(sender As Object, e As EventArgs) Handles Me.Load
        If rdFormat.SelectedIndex = 0 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("AIRHdr_ID"))

        ElseIf rdFormat.SelectedIndex = 1 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue(0, Session("AIRHdr_ID"))
        End If
    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Reports and Query/RQ_Request_Inspection.aspx")
    End Sub

    Private Sub Reports_and_Query_rpt_RequestInspection_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False


    End Sub
End Class
