
Partial Class Inventory_Disposal_InspectionAppraisal_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private Sub Inventory_Disposal_InspectionAppraisal_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Report") = "IIRUP" Then
            Me.CrystalReportSource1.Report.FileName = "IIRUP.rpt"
            Me.Disposal_IIRUP.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Me.Session("TransID"))

        ElseIf Session("Report") = "Form" Then
            Me.CrystalReportSource2.Report.FileName = "rpt_Auction_BidForm.rpt"
            Me.Disposal_BidForm.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue("@IIRUPHdr_ID", Session("IIRUPHdr_ID"))

        ElseIf Session("Report") = "Notice" Then
            Me.CrystalReportSource3.Report.FileName = "rpt_Notice_PubBidding.rpt"
            Me.Disposal_Notice.ReportSource = Me.CrystalReportSource3
            Me.CrystalReportSource3.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource3.ReportDocument.SetParameterValue("@IIRUPHdr_ID", Session("IIRUPHdr_ID"))

        End If

    End Sub

    Private Sub Inventory_Disposal_InspectionAppraisal_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub
End Class
