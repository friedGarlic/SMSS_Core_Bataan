
Imports System.Data

Partial Class rpt_stockcardinventory
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private rptDerived As New connectionreport



    Private Sub rpt_stockcardinventory_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            If Not Page.IsPostBack Then
                drpYear.DataSource = objDerived.GetDataTable("SELECT DISTINCT Year FROM AMS.APP WHERE STATUS <> 3 ORDER BY Year DESC", CommandType.Text)
                drpYear.DataTextField = ("Year")
                drpYear.DataValueField = ("Year")
                drpYear.DataBind()

            End If

            Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(rptDerived.username, rptDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CY", drpYear.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", ddMonth.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Report", ddReport.SelectedItem.Value)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")


        End Try

    End Sub
    Protected Sub BtnPreview_Click(sender As Object, e As EventArgs)
        Try
            Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(rptDerived.username, rptDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CY", drpYear.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", ddMonth.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Report", ddReport.SelectedItem.Value)
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
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




    Private Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click

        Me.Page.Response.Redirect("~/Records/t_StockCard_v2_main.aspx")

    End Sub
End Class
