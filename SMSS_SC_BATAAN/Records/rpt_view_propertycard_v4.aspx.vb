Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Inventory_rpt_view_propertycard_v4
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '=================== CONVERT HEX TO ASCII AND SAVE TO [AMS].[tb_RFID] ===================
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub
    Protected Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click
        Me.Page.Response.Redirect("~/Records/PropertyCard_v4.aspx")
    End Sub
    Protected Sub ddReport_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If ddReport.selecteditem.value = 0 Then
                ddmonth.enabled = False
                drpyear.enabled = False
                ddmonth.SelectedItem.Value = 0

            Else
                ddmonth.enabled = True
                drpyear.enabled = True
            End If
        Catch ex As exception
            msgebox.createmessagealertinupdatepanel(Me.updatepanel1, "something went wrong, please contact system admin.")


        End Try
    End Sub
    Protected Sub BtnPreview_Click(sender As Object, e As EventArgs)
        Try
            Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CY", drpYear.SelectedItem.Value)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", ddMonth.SelectedItem.Value)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Report", ddReport.SelectedItem.Value)

            rpt.FileName = Server.MapPath("rpt_view_property_card_report.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue("@CY", drpYear.SelectedItem.Value)
            rpt.SetParameterValue("@Month", ddMonth.SelectedItem.Value)
            rpt.SetParameterValue("@Report", ddReport.SelectedItem.Value)

            Me.CrystalReportViewer1.ReportSource = rpt


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
End Class
