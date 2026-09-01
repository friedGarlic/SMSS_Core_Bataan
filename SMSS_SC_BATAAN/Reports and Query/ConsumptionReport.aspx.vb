Imports System.Data



Partial Class Reports_and_Query_ConsumptionReport
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private rptDerived As New connectionreport

    Private Sub Reports_and_Query_ConsumptionReport_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            drpAccount.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.View_AccountList WHERE GA_ID IN (1427,1443) ORDER BY GA_TITLE", CommandType.Text)
            drpAccount.DataTextField = ("GA_Title")
            drpAccount.DataValueField = ("GA_ID")
            drpAccount.DataBind()

            drpYear.DataSource = objDerived.GetDataTable("SELECT DISTINCT Year FROM AMS.APP WHERE STATUS <> 3 ORDER BY Year DESC", CommandType.Text)
            drpYear.DataTextField = ("Year")
            drpYear.DataValueField = ("Year")
            drpYear.DataBind()
        End If
        CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(rptDerived.username, rptDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", drpAccount.SelectedItem.Value)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", drpMonth.SelectedItem.Value)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Year", drpYear.SelectedItem.Value)


    End Sub

    Protected Sub BtnPreview_Click1(sender As Object, e As EventArgs) Handles BtnPreview.Click
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(rptDerived.username, rptDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", drpAccount.SelectedItem.Value)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", drpMonth.SelectedItem.Value)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Year", drpYear.SelectedItem.Value)
    End Sub

End Class
