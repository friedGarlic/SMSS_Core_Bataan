Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Hosting

Partial Class MainReports_rpt_StockCard_Rev
    Inherits System.Web.UI.Page

    Dim obj As New BaseClasses.DBPassUsernname
    Private objDerived As New DerivedDal
    Dim rpt_StockCard As New ReportDocument

    Private Sub MainReports_rpt_StockCard_Rev_Load(sender As Object, e As EventArgs) Handles Me.Load
        LOAD_RP()

        ' PDF export path for the hidden print iframe.  rpt_StockCard was just
        ' built IN THIS SAME REQUEST by LOAD_RP() above, so we export it right
        ' away and stop the pipeline -- no ReportDocument crosses a request
        ' boundary.
        If Request.QueryString("print") = "1" Then

            If rpt_StockCard Is Nothing Then
                Me.Page.Response.Redirect("~/Records/t_StockCard_Rev_Main.aspx")
                Return
            End If

            rpt_StockCard.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "StockCard")

            Me.Page.Response.End()

        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        If rpt_StockCard IsNot Nothing Then
            rpt_StockCard.Close()
            rpt_StockCard.Dispose()
            rpt_StockCard = Nothing
        End If
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' On a print request the response is already being aborted by
        ' Response.End(); registering scripts would be a no-op anyway.
        If Request.QueryString("print") = "1" Then Exit Sub

        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Private Sub LOAD_RP()
        ' Disable caching to ensure fresh data
        Me.StockCardReport.ReuseParameterValuesOnRefresh = False
        Me.StockCardReport.EnableDatabaseLogonPrompt = False
        Me.StockCardReport.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        ' Step 1: Read the credentials from web.config ("constr")
        Dim connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim userIDFromConfig As String = ""
        Dim passwordFromConfig As String = ""

        Try
            ' Parse to extract "uid=..." and "pwd=..." from the connection string
            Dim parts As String() = connectionString.Split(";"c)
            For Each part As String In parts
                If part.ToLower().Contains("uid=") Then
                    userIDFromConfig = part.Split("="c)(1).Trim()
                ElseIf part.ToLower().Contains("pwd=") Then
                    passwordFromConfig = part.Split("="c)(1).Trim()
                End If
            Next
        Catch ex As Exception
            ' If any parsing error occurs, handle accordingly
        End Try

        ' Step 2: Use DSN name
        Dim dsn As String = "SMSS" ' ODBC DSN name

        ' Load the Stock Card Report
        rpt_StockCard = New ReportDocument()
        Dim rptPath As String = HostingEnvironment.MapPath("~/Records/rpt_StockCard_v2.rpt")
        rpt_StockCard.FileName = rptPath

        ' Apply database logon
        ApplyDatabaseLogon(rpt_StockCard, dsn, userIDFromConfig, passwordFromConfig)

        ' Set default parameter values first
        rpt_StockCard.SetParameterValue("@GA_ID", 0)

        ' Set the report source
        Me.StockCardReport.ReportSource = rpt_StockCard

        ' Check if Session("GA_ID") exists and set the parameter
        If Session("GA_ID") IsNot Nothing AndAlso Not IsDBNull(Session("GA_ID")) Then
            Dim gaID As Long = 0
            Dim sessGAID As Object = Session("GA_ID")

            If sessGAID IsNot Nothing Then
                Dim s As String = Convert.ToString(sessGAID).Trim()
                If s <> "" Then
                    Long.TryParse(s, gaID)
                End If
            End If

            rpt_StockCard.SetParameterValue("@GA_ID", gaID)
            AddTrace("Set @GA_ID = " & Convert.ToString(gaID))
        Else
            AddTrace("Warning: Session('GA_ID') is not set or is empty")
        End If

        ' Refresh the report source
        Me.StockCardReport.ReportSource = rpt_StockCard
    End Sub

    Private Sub ApplyDatabaseLogon(report As ReportDocument, dsn As String, userId As String, password As String)
        For Each table As Table In report.Database.Tables
            Dim logonInfo As TableLogOnInfo = table.LogOnInfo
            logonInfo.ConnectionInfo.ServerName = dsn
            logonInfo.ConnectionInfo.DatabaseName = "SMSS_Premium"
            logonInfo.ConnectionInfo.UserID = userId
            logonInfo.ConnectionInfo.Password = password
            table.ApplyLogOnInfo(logonInfo)
        Next

        ' Also handle subreports if any
        For Each subrep As ReportDocument In report.Subreports
            For Each table As Table In subrep.Database.Tables
                Dim logonInfo As TableLogOnInfo = table.LogOnInfo
                logonInfo.ConnectionInfo.ServerName = dsn
                logonInfo.ConnectionInfo.DatabaseName = "SMSS_Premium"
                logonInfo.ConnectionInfo.UserID = userId
                logonInfo.ConnectionInfo.Password = password
                table.ApplyLogOnInfo(logonInfo)
            Next
        Next

        ' Force report to refresh data
        report.Refresh()
    End Sub

    Private Sub MainReports_rpt_StockCard_Rev_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        ' Hide master page elements if they exist
        If Master.FindControl("MasterRowModules") IsNot Nothing Then
            Master.FindControl("MasterRowModules").Visible = False
        End If
        If Master.FindControl("UserRow") IsNot Nothing Then
            Master.FindControl("UserRow").Visible = False
        End If
        If Master.FindControl("Menu1") IsNot Nothing Then
            Master.FindControl("Menu1").Visible = False
        End If
    End Sub

    Private Sub lnkBackPrevious_Click(sender As Object, e As EventArgs) Handles lnkBackPrevious.Click
        ' Redirect back to the previous page - modify this according to your navigation needs
        Me.Page.Response.Redirect("~/Records/t_StockCard_Rev_Main.aspx") ' Change this to your actual previous page
    End Sub

End Class