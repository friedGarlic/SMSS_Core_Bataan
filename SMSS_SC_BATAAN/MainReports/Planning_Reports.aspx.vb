
Partial Class MainReports_Planning_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub MainReports_Planning_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.CrystalReportSource1.Report.FileName = "Procurement_PR.rpt"
        Me.ProcurementReports.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))

    End Sub

    Private Sub MainReports_Planning_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click

    End Sub
End Class
