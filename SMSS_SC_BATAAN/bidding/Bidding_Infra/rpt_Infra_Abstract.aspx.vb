
Partial Class bidding_Bidding_Infra_rpt_Infra_Abstract
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub bidding_Bidding_Infra_rpt_Infra_Abstract_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadAbstract()
    End Sub

    Protected Sub loadAbstract()
        If drpAbstractType.SelectedItem.Value = 1 Then
            '== AS READ
            Me.CrystalReportSource1.Report.FileName = ""
            Me.Infra_Abstract_Reports.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Infra_Hdr_ID", Session("Infra_Hdr_ID"))

        Else
            '== AS CALCULATED
            Me.CrystalReportSource1.Report.FileName = ""
            Me.Infra_Abstract_Reports.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Infra_Hdr_ID", Session("Infra_Hdr_ID"))

        End If
    End Sub
    Private Sub drpAbstractType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpAbstractType.SelectedIndexChanged
        loadAbstract()
    End Sub

    Private Sub bidding_Bidding_Infra_rpt_Infra_Abstract_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click

    End Sub



    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    loadReport()
    'End Sub

    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    Me.Page.Response.Redirect("~/bidding/Bidding_Infra/t_Infra_Abstract.aspx")
    'End Sub

    'Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbChoice.SelectedIndexChanged
    '    loadReport()
    'End Sub

    'Protected Sub loadReport()
    '    If rbChoice.SelectedItem.Value = 1 Then
    '        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
    '        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
    '        Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("Infra_Hdr_ID"))
    '    Else
    '        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource2
    '        Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
    '        Me.CrystalReportSource2.ReportDocument.SetParameterValue(0, Session("Infra_Hdr_ID"))

    '    End If
    'End Sub
End Class
