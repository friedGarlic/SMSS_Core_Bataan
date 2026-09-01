
Partial Class Inventory_t_rpt_receiving
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("AIRHDR_ID"))
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "PPE" Then
            Me.Page.Response.Redirect("~/Inventory/t_inventory_encoding.aspx")
        ElseIf Session("Page") = "ICS" Then
            Me.Page.Response.Redirect("~/Inventory/t_CustodianEncoding.aspx")
        ElseIf Session("Page") = "RQ" Then

        End If

    End Sub
End Class
