
Partial Class MainReports_Agency_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub MainReports_Agency_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblTitle.Text = "AGENCY BAC RESOLUTION REPORT"

        Me.CrystalReportSource1.Report.FileName = "Agency_BACResolution.rpt"
        Me.AgencyReports.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@PRHdr_ID", Session("prhdr_id"))

    End Sub


    Private Sub MainReports_Agency_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub

    Private Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click
        If Session("Page") = "Agency" Then
            Me.Page.Response.Redirect("~/bidding/t_Agency.aspx")
        Else
            Me.Page.Response.Redirect("~/bidding/RQ_BAC_ResolutionR.aspx")
        End If
    End Sub
End Class
