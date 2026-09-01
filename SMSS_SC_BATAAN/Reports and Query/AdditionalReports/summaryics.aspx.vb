Imports System.Data
Partial Class Reports_and_Query_AdditionalReports_summaryics
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private obj As New connectionreport

    Private Sub Reports_and_Query_AdditionalReports_summaryics_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            drpYear.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.APP WHERE status <> 3 ORDER BY YEAR DESC", CommandType.Text)
            drpYear.DataTextField = "year"
            drpYear.DataValueField = "year"
            drpYear.DataBind()

            drpPreparedby.DataSource = objDerived.GetDataTable("SELECT Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = 7 ORDER BY Full_Name", CommandType.Text)
            drpPreparedby.DataTextField = "Full_Name"
            drpPreparedby.DataValueField = "EmpID"
            drpPreparedby.DataBind()

            drpNotedby.DataSource = objDerived.GetDataTable("SELECT Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = 7 ORDER BY Full_Name", CommandType.Text)
            drpNotedby.DataTextField = "Full_Name"
            drpNotedby.DataValueField = "EmpID"
            drpNotedby.DataBind()

            'Me.SummaryReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            'Me.SummaryReports.ReportSource = Me.CrystalReportSource1
            'Me.SummaryReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            'Me.SummaryReports.Zoom(90)

        Else
            'LoadReportPreview()

        End If

    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        LoadReportPreview()
    End Sub

    Protected Sub LoadReportPreview()
        'Me.SummaryReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.SummaryReports.ReportSource = Me.CrystalReportSource1
        Me.SummaryReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(obj.username, obj.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Year", drpYear.SelectedItem.Value)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", drpMonths.SelectedItem.Value)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@PreparedBy", drpPreparedby.SelectedItem.Value)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@NotedBy", drpNotedby.SelectedItem.Value)
        'Me.SummaryReports.Zoom(90)

    End Sub
End Class
