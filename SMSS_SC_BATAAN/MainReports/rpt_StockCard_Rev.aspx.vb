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
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        If rpt_StockCard IsNot Nothing Then
            rpt_StockCard.Close()
            rpt_StockCard.Dispose()
            rpt_StockCard = Nothing
        End If
    End Sub

    Private Sub AddTrace(ByVal message As String)
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
        rpt_StockCard.SetParameterValue("@Item_ID", 0)

        ' Set the report source
        Me.StockCardReport.ReportSource = rpt_StockCard

        ' Check if Session("Item_ID") exists and set the parameter
        If Session("Item_ID") IsNot Nothing AndAlso Not IsDBNull(Session("Item_ID")) Then
            Dim itemID As Integer = 0
            Dim sessItemID As Object = Session("Item_ID")

            If sessItemID IsNot Nothing Then
                Dim s As String = Convert.ToString(sessItemID).Trim()
                If s <> "" Then
                    Integer.TryParse(s, itemID)
                End If
            End If

            rpt_StockCard.SetParameterValue("@Item_ID", itemID)
            AddTrace("Set @Item_ID = " & Convert.ToString(itemID))
        Else
            AddTrace("Warning: Session('Item_ID') is not set or is empty")
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