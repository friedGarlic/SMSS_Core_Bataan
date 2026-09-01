
Partial Class Inventory_t_rpt_InventoryCustodianSlip
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Session("view") = "2"
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("ris_no").ToString)

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        If Session("Page") = "RQ" Then
            Me.Page.Response.Redirect("~/Reports and Query/t_rpt_ICS.aspx")
        ElseIf Session("Page") = "INV" Then
            Me.Page.Response.Redirect("~/Inventory/t_RequisitionAndIssunace.aspx")
        End If

    End Sub
End Class
