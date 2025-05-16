Imports System.Data

Partial Class rpt_PropertyCardInventory
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private rptDerived As New connectionreport

    Private Sub rpt_PropertyCardInventory_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            If Not Page.IsPostBack Then
                drpYear.DataSource = objDerived.GetDataTable("select DISTINCT Year(Property_Date) as Year From ams.Property", CommandType.Text)
                drpYear.DataTextField = ("Year")
                drpYear.DataValueField = ("Year")
                drpYear.DataBind()

                Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
                Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(rptDerived.username, rptDerived.Password)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", ddMonth.SelectedItem.Value)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Report", ddReport.SelectedItem.Value)
            End If
            loadreport()
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Public Sub loadreport()
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(rptDerived.username, rptDerived.Password)
        If ddReport.SelectedItem.Value = 0 Then
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@startdate", "1/1/1900")
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@enddate", "12/31/" & drpYear.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@report", ddReport.SelectedItem.Value)
        Else
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@startdate", ddMonth.SelectedItem.Value & "/1/" & drpYear.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@enddate", "12/31/" & drpYear.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@report", ddReport.SelectedItem.Value)

        End If

    End Sub

    Protected Sub BtnPreview_Click(sender As Object, e As EventArgs)
        Try

            'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(rptDerived.username, rptDerived.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CY", drpYear.SelectedItem.Value)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", ddMonth.SelectedItem.Value)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Report", ddReport.SelectedItem.Value)


            loadreport()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Protected Sub ddReport_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If ddReport.selecteditem.value = 0 Then
                ddmonth.enabled = False
                ' drpyear.enabled = False
                ddMonth.SelectedItem.Value = 0
                drpYear.Enabled = True
            Else
                ddmonth.enabled = True
                drpyear.enabled = True
            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.updatepanel1, "something went wrong, please contact system admin.")


        End Try
    End Sub




End Class

