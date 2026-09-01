Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class MainReports_NoticeOfDelivery
    Inherits System.Web.UI.Page

    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.NoticeOfDeliveryReport.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        If Not IsPostBack Then
            If Session("NOD_ID") IsNot Nothing Then
                LoadReport()
            Else
                ' Optional: Redirect or notify
            End If
        End If
    End Sub

    Private Sub LoadReport()
        Dim rptPath As String = Server.MapPath("~/MainReports/rpt_NoticeDelivery.rpt")

        ' Bind to CrystalReportSource
        CrystalReportSource1.Report.FileName = rptPath
        CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        CrystalReportSource1.ReportDocument.SetParameterValue("@nod_id", Session("NOD_ID"))

        ' Bind CrystalReportSource to viewer (auto through ReportSourceID)
        NoticeOfDeliveryReport.ReportSource = CrystalReportSource1
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Try
            If CrystalReportSource1.ReportDocument IsNot Nothing Then
                CrystalReportSource1.ReportDocument.Close()
                CrystalReportSource1.ReportDocument.Dispose()
            End If
        Catch
        End Try
    End Sub
End Class
