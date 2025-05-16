
Partial Class MainReports_Disposal_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub MainReports_Disposal_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Report") = "ITB" Then
            lblTitle.Text = "INVITATION TO BID REPORT"

            Me.CrystalReportSource1.Report.FileName = "Disposal_ITB.rpt"
            Me.DisposalReport.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@IIRUPHdr_ID", Session("IIRUPHdr_ID"))


        ElseIf Session("Report") = "----" Then

        End If

    End Sub

    Private Sub MainReports_Disposal_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click
        If Session("Report") = "ITB" Then
            Me.Page.Response.Redirect("~/Inventory/Disposal/t_inventory_of_unserviceable_property.aspx")
        ElseIf Session("Report") = "----" Then

        End If
    End Sub
End Class
