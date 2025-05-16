
Partial Class Disposal_IIRUP
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Me.Session("TransID"))

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Me.Session("INI") = True Then
            'Me.Page.Response.Redirect("~/Disposal/form_INI.aspx")
            Me.Page.Response.Redirect("~/Inventory/Disposal/t_inventory_of_unserviceable_property.aspx.aspx")
        Else
            'Me.Page.Response.Redirect("~/Disposal/frmDisposal_Inspection.aspx")
            Me.Page.Response.Redirect("~/Inventory/Disposal/t_insperction_and_appraisal.aspx")
        End If
    End Sub
End Class
