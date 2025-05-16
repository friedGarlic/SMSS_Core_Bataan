
Partial Class Inventory_rpt_RFID_InventoryTaking
    Inherits System.Web.UI.Page
    Private objDerived_rpt As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '=================== CONVERT HEX TO ASCII AND SAVE TO [AMS].[tb_RFID] ===================
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived_rpt.username, objDerived_rpt.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("CYear"))
    End Sub


End Class
