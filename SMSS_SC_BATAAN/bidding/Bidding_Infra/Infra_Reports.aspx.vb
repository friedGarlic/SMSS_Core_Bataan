Imports System
Imports System.Data

Partial Class bidding_Bidding_Infra_Infra_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub bidding_Bidding_Infra_Infra_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Page") = "Abstract" Then
            pnlAbstractReport.Visible = True
            divAbstract.Visible = True
            divNotice.Visible = False

            LoadAbstractRpt()

        ElseIf Session("Page") = "Resolution" Then
            pnlAbstractReport.Visible = False
            divAbstract.Visible = False
            divNotice.Visible = True

            Me.ReportSource_Resolution.Report.FileName = "rpt_BAC_Resolution.rpt"
            Me.InfrastructureNotice.ReportSource = Me.ReportSource_Resolution
            Me.ReportSource_Resolution.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.ReportSource_Resolution.ReportDocument.SetParameterValue("@Infra_Hdr_ID", Session("Infra_Hdr_ID"))

        ElseIf Session("Page") = "NOA" Then
            pnlAbstractReport.Visible = False
            divAbstract.Visible = False
            divNotice.Visible = True

            Me.ReportSource_NOA.Report.FileName = "rpt_Infra_NOA.rpt"
            Me.InfrastructureNotice.ReportSource = Me.ReportSource_NOA
            Me.ReportSource_NOA.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.ReportSource_NOA.ReportDocument.SetParameterValue("@Infra_Hdr_ID", Session("Infra_Hdr_ID"))

        ElseIf Session("Page") = "Contract" Then
            pnlAbstractReport.Visible = False
            divAbstract.Visible = False
            divNotice.Visible = True

            Me.ReportSource_Contract.Report.FileName = "rpt_Infra_ContractAgreement.rpt"
            Me.InfrastructureNotice.ReportSource = Me.ReportSource_Contract
            Me.ReportSource_Contract.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.ReportSource_Contract.ReportDocument.SetParameterValue("@Infra_Hdr_ID", Session("Infra_Hdr_ID"))

        ElseIf Session("Page") = "NTP" Then
            pnlAbstractReport.Visible = False
            divAbstract.Visible = False
            divNotice.Visible = True

            Me.ReportSource_NTP.Report.FileName = "rpt_Infra_NTP.rpt"
            Me.InfrastructureNotice.ReportSource = Me.ReportSource_NTP
            Me.ReportSource_NTP.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.ReportSource_NTP.ReportDocument.SetParameterValue("@Infra_Hdr_ID", Session("Infra_Hdr_ID"))
        End If
    End Sub

    Private Sub bidding_Bidding_Infra_Infra_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        If Session("Page") = "Abstract" Then
            Me.Page.Response.Redirect("~/bidding/Bidding_Infra/Infra_Abstract.aspx")
        ElseIf Session("Page") = "Resolution" Then
            Me.Page.Response.Redirect("~/bidding/Bidding_Infra/Infra_Notices.aspx")
        ElseIf Session("Page") = "NOA" Then
            Me.Page.Response.Redirect("~/bidding/Bidding_Infra/Infra_Notices.aspx")
        ElseIf Session("Page") = "Contract" Then
            Me.Page.Response.Redirect("~/bidding/Bidding_Infra/Infra_Notices.aspx")
        ElseIf Session("Page") = "NTP" Then
            Me.Page.Response.Redirect("~/bidding/Bidding_Infra/Infra_Notices.aspx")
        End If

    End Sub

    Private Sub drpAbstractReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpAbstractReport.SelectedIndexChanged
        LoadAbstractRpt()
    End Sub

    Protected Sub LoadAbstractRpt()
        Dim abstract As String = ""

        If drpAbstractReport.SelectedItem.Text = "As Read" Then
            abstract = "READ"
            Me.ReportSource_AbstractRead.Report.FileName = "rpt_Infra_Abstract.rpt"
            Me.InfrastructureReports.ReportSource = Me.ReportSource_AbstractRead
            Me.ReportSource_AbstractRead.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.ReportSource_AbstractRead.ReportDocument.SetParameterValue("@Infra_Hdr_ID", Session("Infra_Hdr_ID_Abstract"))
            Me.ReportSource_AbstractRead.ReportDocument.SetParameterValue("@Report", abstract)

        Else
            abstract = "CALCULATED"
            Me.ReportSource_AbstractCalculated.Report.FileName = "rpt_Infra_Abstract.rpt"
            Me.InfrastructureReports.ReportSource = Me.ReportSource_AbstractCalculated
            Me.ReportSource_AbstractCalculated.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.ReportSource_AbstractCalculated.ReportDocument.SetParameterValue("@Infra_Hdr_ID", Session("Infra_Hdr_ID_Abstract"))
            Me.ReportSource_AbstractCalculated.ReportDocument.SetParameterValue("@Report", abstract)
        End If
    End Sub
End Class
