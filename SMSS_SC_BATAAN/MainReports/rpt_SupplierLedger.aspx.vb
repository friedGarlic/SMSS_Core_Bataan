
Partial Class MainReports_rpt_SupplierLedger
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport


    Private Sub MainReports_rpt_SupplierLedger_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.SupplierLedger.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.CrystalReportSource1.Report.FileName = "rpt_SupplierLedger.rpt"
        Me.SupplierLedger.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Supplier_ID", Session("Supplier_id"))





    End Sub
    Private Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click

        Me.Page.Response.Redirect("~/Records/SupplierCard.aspx")

    End Sub

End Class
