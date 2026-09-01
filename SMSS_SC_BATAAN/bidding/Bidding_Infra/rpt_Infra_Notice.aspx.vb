
Partial Class bidding_Bidding_Infra_rpt_Infra_Notice
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Notice") = "NOA" Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("Infra_Hdr_ID"))

        ElseIf Session("Notice") = "NTP" Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue(0, Session("Infra_Hdr_ID"))
        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/bidding/Bidding_Infra/t_Infra_Notices.aspx")
    End Sub
End Class
