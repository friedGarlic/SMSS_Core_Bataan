
Partial Class t_rpt_notice_of_award

    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Me.Session("Disposal_Bid_hdr_id"))

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        Me.Page.Response.Redirect("~/Inventory/Disposal/t_notice.aspx")

    End Sub
End Class
