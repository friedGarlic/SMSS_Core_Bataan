
Partial Class Reports_and_Query_AdditionalReports_Req_PreRepairInspec
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private obj As New connectionreport

    Private Sub Reports_and_Query_AdditionalReports_Req_PreRepairInspec_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtDate.Text = Date.Today.ToShortDateString

        'Me.PreRepair.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.PreRepair.ReportSource = Me.CrystalReportSource1
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        'Me.PreRepair.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.PreRepair.ReportSource = Me.CrystalReportSource1
    End Sub
End Class
