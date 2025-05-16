
Partial Class Reports_and_Query_AdditionalReports_summaryinspection
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private obj As New connectionreport
    Private Sub Reports_and_Query_AdditionalReports_summaryinspection_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Private Sub Reports_and_Query_AdditionalReports_summaryinspection_Init(sender As Object, e As EventArgs) Handles Me.Init
        txtDateFrom.Text = Date.Today.ToShortDateString
        txtDateTo.Text = Date.Today.ToShortDateString

        'Me.InspectionReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.InspectionReports.ReportSource = Me.CrystalReportSource1
        Me.InspectionReports.Zoom(90)
    End Sub
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        Session("Date_From") = CType(txtDateFrom.Text, Date)
        Session("Date_To") = CType(txtDateTo.Text, Date)


        'Me.InspectionReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        Me.InspectionReports.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(obj.username, obj.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Date_From", Session("Date_From"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Date_To", Session("Date_To"))
        Me.InspectionReports.Zoom(90)

    End Sub


End Class
