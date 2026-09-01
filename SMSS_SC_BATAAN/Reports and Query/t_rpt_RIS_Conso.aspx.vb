Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web

Partial Class Reports_and_Query_t_rpt_RIS_Conso
    Inherits System.Web.UI.Page

    Private objDerived As New connectionreport

    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            LoadReset()
            LoadRISConso()

        End If
    End Sub

    Private Sub LoadRISConso()
        AddTrace("RIS_RC_ID: " & Session("RIS_RC_ID"))
        AddTrace("RIS_Year: " & Session("RIS_Year"))
        AddTrace("RIS_MonthFrom: " & Session("RIS_MonthFrom"))
        AddTrace("RIS_MonthTo: " & Session("RIS_MonthTo"))

        ' Configure Crystal Report Viewer
        RISConsoReport.ToolPanelView = ToolPanelViewType.None
        RISConsoReport.HasToggleGroupTreeButton = False
        RISConsoReport.HasCrystalLogo = False
        RISConsoReport.BackColor = Drawing.Color.White

        ' Set report file (relative path like reference)
        Me.CrystalReportSource1.Report.FileName = "~/Inventory/Inventory_RIS_Conso.rpt"

        ' Set report source
        Me.RISConsoReport.ReportSource = Me.CrystalReportSource1

        ' Set database logon credentials
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)

        ' Set parameter values from Session
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("RIS_RC_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Cyear", Session("RIS_Year"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@MonthFrom", Session("RIS_MonthFrom"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@MonthTo", Session("RIS_MonthTo"))

        ' DataBind the report viewer
        Me.RISConsoReport.DataBind()
    End Sub

    Private Sub LoadReset()
        Session("Reset") = 0

        ' Configure Crystal Report Viewer
        RISConsoReport.ToolPanelView = ToolPanelViewType.None
        RISConsoReport.HasToggleGroupTreeButton = False
        RISConsoReport.HasCrystalLogo = False
        RISConsoReport.BackColor = Drawing.Color.White

        ' Set report file (relative path like reference)
        Me.CrystalReportSource1.Report.FileName = "~/Inventory/Inventory_RIS_Conso.rpt"

        ' Set report source
        Me.RISConsoReport.ReportSource = Me.CrystalReportSource1

        ' Set database logon credentials
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)

        ' Set parameter values from Session
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("Reset"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Cyear", Session("Reset"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@MonthFrom", Session("Reset"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@MonthTo", Session("Reset"))

        ' DataBind the report viewer
        Me.RISConsoReport.DataBind()
    End Sub

End Class