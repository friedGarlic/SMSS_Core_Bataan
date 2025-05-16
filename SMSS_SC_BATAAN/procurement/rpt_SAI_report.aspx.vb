
Partial Class procurement_rpt_SAI_report
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@sai_hdr_id", Session("sai_hdr_id"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@SAI", Session("SAI").ToString)

    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Session("SAI") = "Preparation" Then
            Me.Page.Response.Redirect("~/Procurement/t_SupplyAvailabilityInquiry.aspx")
        ElseIf Session("SAI") = "Status" Then
            Me.Page.Response.Redirect("~/Procurement/t_SupplyAvailabilityInquiry_Status.aspx")
        End If
    End Sub
End Class
