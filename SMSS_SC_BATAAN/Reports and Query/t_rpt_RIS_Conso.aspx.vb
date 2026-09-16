Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web

Partial Class Reports_and_Query_t_rpt_RIS_Conso
    Inherits System.Web.UI.Page

    Private objDerived As New connectionreport
    Private rpt As New ReportDocument

    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Bind the report on EVERY request (initial load + postbacks)
        ' so the CrystalReportViewer's built-in toolbar buttons
        ' (Export, Print, Refresh) have a valid ReportSource to act on.
        LoadRISConso()

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

        ' Load the report into the class-level ReportDocument (like the reference)
        rpt = New ReportDocument()
        rpt.Load(Server.MapPath("~/Inventory/Inventory_RIS_Conso.rpt"))

        ' Set database logon credentials
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        ' Set parameter values from Session
        rpt.SetParameterValue("@RC_ID", Session("RIS_RC_ID"))
        rpt.SetParameterValue("@Cyear", Session("RIS_Year"))
        rpt.SetParameterValue("@MonthFrom", Session("RIS_MonthFrom"))
        rpt.SetParameterValue("@MonthTo", Session("RIS_MonthTo"))

        ' Bind the ReportDocument object DIRECTLY to the viewer
        Me.RISConsoReport.ReportSource = rpt

    End Sub

    Private Sub LoadReset()
        Session("Reset") = 0

        ' Configure Crystal Report Viewer
        RISConsoReport.ToolPanelView = ToolPanelViewType.None
        RISConsoReport.HasToggleGroupTreeButton = False
        RISConsoReport.HasCrystalLogo = False
        RISConsoReport.BackColor = Drawing.Color.White

        ' Load the report into the class-level ReportDocument
        rpt = New ReportDocument()
        rpt.Load(Server.MapPath("~/Inventory/Inventory_RIS_Conso.rpt"))

        ' Set database logon credentials
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        ' Set parameter values from Session
        rpt.SetParameterValue("@RC_ID", Session("Reset"))
        rpt.SetParameterValue("@Cyear", Session("Reset"))
        rpt.SetParameterValue("@MonthFrom", Session("Reset"))
        rpt.SetParameterValue("@MonthTo", Session("Reset"))

        ' Bind the ReportDocument object DIRECTLY to the viewer
        Me.RISConsoReport.ReportSource = rpt

    End Sub

    Protected Sub btnExportPDF_Click(sender As Object, e As EventArgs)
        Try
            ' Create a new ReportDocument instance and load the report
            Dim rptExport As New ReportDocument()
            rptExport.Load(Server.MapPath("~/Inventory/Inventory_RIS_Conso.rpt"))
            rptExport.SetDatabaseLogon(objDerived.username, objDerived.Password)

            ' Set parameters (same as before)
            rptExport.SetParameterValue("@RC_ID", Session("RIS_RC_ID"))
            rptExport.SetParameterValue("@Cyear", Session("RIS_Year"))
            rptExport.SetParameterValue("@MonthFrom", Session("RIS_MonthFrom"))
            rptExport.SetParameterValue("@MonthTo", Session("RIS_MonthTo"))

            ' Export to PDF and write to response
            Dim stream As System.IO.Stream = rptExport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)
            Response.Clear()
            Response.ContentType = "application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=RIS_Conso_Report.pdf")
            stream.CopyTo(Response.OutputStream)
            Response.Flush()
            Response.End()
        Catch ex As Exception
            AddTrace("Export failed: " & ex.Message)
        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Try
            If rpt IsNot Nothing Then
                rpt.Close()
                rpt.Dispose()
            End If
        Catch ex As Exception
            AddTrace("Page_Unload dispose error: " & ex.Message)
        End Try
    End Sub

End Class