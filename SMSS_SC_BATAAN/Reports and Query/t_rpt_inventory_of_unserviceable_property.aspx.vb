
Partial Class t_rpt_inventory_of_unserviceable_property

    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("rbChoice") = 1 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Me.Session("TransID"))

        ElseIf Session("rbChoice") = 2 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue(0, Me.Session("IIRUS_ID"))

        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Me.Session("INI") = True Then
            Me.Page.Response.Redirect("~/Inventory/Disposal/t_inventory_of_unserviceable_property.aspx")
        Else
            Me.Page.Response.Redirect("~/Inventory/disposal/t_inspection_and_appraisal.aspx")
        End If
    End Sub
End Class
