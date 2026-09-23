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

    ' Page_Load now handles the ?print=1 PDF-stream branch.
    ' Report binding still happens in Page_Init so the CrystalReportViewer
    ' can process pagination postbacks (Next Page, Previous Page, Print,
    ' Export) against the SAME report instance it is navigating with.
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("RISConso_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Reports and Query/t_requisition_and_issuance.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "RIS_Conso_Report")

            Me.Page.Response.End()

        End If

        ' Intentionally left blank otherwise.

    End Sub

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' On the very first request, build the report and stash it in Session.
        ' On every subsequent request (including pagination postbacks),
        ' pull the SAME instance from Session — this preserves page state.
        If Not IsPostBack Then

            LoadRISConso()

        Else

            rpt = CType(Session("RISConso_Report"), ReportDocument)

            ' Session may have expired or been lost — rebuild as fallback.
            If rpt Is Nothing Then

                LoadRISConso()

            Else

                ' Re-apply database credentials on EVERY request.
                ' Crystal Reports drops the runtime logon across postbacks;
                ' re-applying here ensures no login prompt appears.
                rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

                ' Bind BEFORE the viewer processes its view state.
                Me.RISConsoReport.ReportSource = rpt

            End If

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

        ' Cache the loaded report in Session so it can be reused
        ' across pagination postbacks (Next Page, Previous Page, etc.)
        Session("RISConso_Report") = rpt

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

        ' Cache the loaded report in Session
        Session("RISConso_Report") = rpt

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
        ' Intentionally left blank.
        ' The ReportDocument lives in Session and must NOT be disposed
        ' while the viewer still needs it for pagination.
    End Sub

End Class