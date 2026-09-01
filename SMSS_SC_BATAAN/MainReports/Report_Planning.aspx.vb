Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Hosting

Partial Class MainReports_Report_Planning
    Inherits System.Web.UI.Page

    Dim obj As New BaseClasses.DBPassUsernname
    Private objDerived As New DerivedDal
    Dim rpt_Monthly As New ReportDocument
    Dim rpt_PPMP_Monthly_Revision As New ReportDocument
    Dim rpt_PPMP_Monthly_PERPPA As New ReportDocument

    Private Sub MainReports_Report_Planning_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PPMP_FORMAT.SelectedItem.Value = 2 Then
            Session("Page") = "PPMP PERPPA"
        ElseIf PPMP_FORMAT.SelectedItem.Value = 1 Then
            Session("Page") = "Planning_PPMP"
        End If
        LOAD_RP()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt_Monthly.Close()
        rpt_Monthly.Dispose()

        rpt_PPMP_Monthly_Revision.Close()
        rpt_PPMP_Monthly_Revision.Dispose()

        rpt_PPMP_Monthly_PERPPA.Close()
        rpt_PPMP_Monthly_PERPPA.Dispose()
    End Sub

    Private Sub MainReports_Report_Planning_Init(sender As Object, e As EventArgs) Handles Me.Init
        'Me.PlanningReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        'Me.CrystalReportSource1.Report.FileName = "PPMP_Monthly.rpt"
        'Me.CrystalReportSource1.ReportDocument.Refresh()

        'If Session("Page") = "PPMP PERPPA" Then
        '    Me.PlanningReports.ReportSource = Me.CrystalReportSource3
        '    Me.CrystalReportSource3.ReportDocument.SetDatabaseLogon(obj.username, obj.Password)
        '    Me.CrystalReportSource3.ReportDocument.SetParameterValue("@CYear", Session("CYear"))
        '    Me.CrystalReportSource3.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
        '    Me.CrystalReportSource3.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
        '    Me.CrystalReportSource3.ReportDocument.SetParameterValue("@Project_ID", Session("Project_ID"))
        '    Me.CrystalReportSource3.ReportDocument.SetParameterValue("@Program_ID", Session("Program_id"))
        '    Me.CrystalReportSource3.ReportDocument.SetParameterValue("@isInfra", Session("isInfra"))
        '    Me.CrystalReportSource3.ReportDocument.SetParameterValue("@GA_ID", Session("GA_ID"))
        'End If

        'If Session("Page") = "Planning_List" Then
        '    Dim CYear As Integer = Session("CYear")
        '    Dim RC_ID As Integer = Session("RC_ID")
        '    Dim FunctionID As Integer = Session("Function_ID")
        '    Me.PlanningReports.ReportSource = Me.CrystalReportSource1
        '    Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(obj.username, obj.Password)
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("CYear"))
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isInfra", Session("isInfra"))
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isGoods", Session("isGoods"))
        '    'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear1", Session("CYear"))
        '    'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID1", Session("RC_ID"))
        '    'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID1", Session("Function_ID"))
        '    'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isInfra1", Session("isInfra"))
        '    'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isGoods", Session("isGoods"))
        'End If

        'If Session("Page") = "Planning_PPMP" Then
        '    Me.PlanningReports.ReportSource = Me.CrystalReportSource1
        '    Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(obj.username, obj.Password)
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("CYear"))
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isInfra", Session("isInfra"))
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isGoods", Session("isGoods"))
        'End If

        'If Session("Page") = "PPMP HISTORY" Then
        '    Me.PlanningReports.ReportSource = Me.CrystalReportSource2
        '    Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(obj.username, obj.Password)
        '    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@CYear", Session("CYear"))
        '    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
        '    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
        '    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isInfra", Session("isInfra"))
        'End If
    End Sub

    Private Sub LOAD_RP()

        Me.PlanningReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        ' Step 1: Read the credentials from web.config ("constr")
        Dim connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("constr").ConnectionString
        ' We are not removing or renaming any lines; we simply parse the user and password dynamically:
        Dim userIDFromConfig As String = ""
        Dim passwordFromConfig As String = ""

        Try
            ' This is a quick parse approach to extract "uid=..." and "pwd=..." from the connection string
            Dim parts As String() = connectionString.Split(";"c)
            For Each part As String In parts
                If part.ToLower().Contains("uid=") Then
                    userIDFromConfig = part.Split("="c)(1).Trim()
                ElseIf part.ToLower().Contains("pwd=") Then
                    passwordFromConfig = part.Split("="c)(1).Trim()
                End If
            Next
        Catch ex As Exception
            ' If any parsing error occurs, we fallback to default or handle accordingly
            'Use the database Username and Password here:
            'userIDFromConfig = ""
            'passwordFromConfig = ""
        End Try

        ' Step 2: Because code lines for DSN "SMSS" are not removed or renamed, we keep them
        Dim dsn As String = "SMSS" ' ODBC DSN name from existing lines

        'Me.CrystalReportSource1.Report.FileName = "PPMP_Monthly.rpt"
        'Me.CrystalReportSource1.ReportDocument.Refresh()

        If Session("Page") = "PPMP PERPPA" Then
            Dim rptPath_PPMP As String = HostingEnvironment.MapPath("~/MainReports/PPMP_Monthly_PERPPA.rpt")
            rpt_PPMP_Monthly_PERPPA.FileName = rptPath_PPMP


            ' Commented out, replaced by dynamic user/password from web.config:

            ApplyDatabaseLogon(rpt_PPMP_Monthly_PERPPA, dsn, userIDFromConfig, passwordFromConfig)

            rpt_PPMP_Monthly_PERPPA.SetParameterValue("@CYear", Session("CYear"))
            rpt_PPMP_Monthly_PERPPA.SetParameterValue("@RC_ID", Session("RC_ID"))
            rpt_PPMP_Monthly_PERPPA.SetParameterValue("@Function_ID", Session("Function_ID"))
            rpt_PPMP_Monthly_PERPPA.SetParameterValue("@Project_ID", Session("Project_ID"))
            rpt_PPMP_Monthly_PERPPA.SetParameterValue("@Program_ID", Session("Program_ID"))
            rpt_PPMP_Monthly_PERPPA.SetParameterValue("@isInfra", Session("isInfra"))
            rpt_PPMP_Monthly_PERPPA.SetParameterValue("@GA_ID", Session("GA_ID"))
            Me.PlanningReports.ReportSource = rpt_PPMP_Monthly_PERPPA


            'Me.PlanningReports.ReportSource = Me.CrystalReportSource3
            'Me.CrystalReportSource3.ReportDocument.SetDatabaseLogon(obj.username, obj.Password)
            'Me.CrystalReportSource3.ReportDocument.SetParameterValue("@CYear", Session("CYear"))
            'Me.CrystalReportSource3.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
            'Me.CrystalReportSource3.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
            'Me.CrystalReportSource3.ReportDocument.SetParameterValue("@Project_ID", Session("Project_ID"))
            'Me.CrystalReportSource3.ReportDocument.SetParameterValue("@Program_ID", Session("Program_id"))
            'Me.CrystalReportSource3.ReportDocument.SetParameterValue("@isInfra", Session("isInfra"))
            'Me.CrystalReportSource3.ReportDocument.SetParameterValue("@GA_ID", Session("GA_ID"))

            ' Original line:
            ' rpt_PPMP_Monthly_PERPPA.FileName = Server.MapPath("PPMP_Monthly_PERPPA.rpt")
            ' Causing error, so we comment it out and add a HostingEnvironment-based approach:
            ' rpt_PPMP_Monthly_PERPPA.FileName = Server.MapPath("PPMP_Monthly_PERPPA.rpt")


        End If

        If Session("Page") = "Planning_List" Then

            Dim CYear As Integer = Session("CYear")
            Dim RC_ID As Integer = Session("RC_ID")
            Dim FunctionID As Integer = Session("Function_ID")
            'Me.PlanningReports.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(obj.username, obj.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("CYear"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isInfra", Session("isInfra"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isGoods", Session("isGoods"))

            ' rpt_Monthly.FileName = Server.MapPath("PPMP_Monthly.rpt")
            ' We comment out the original line and replace it:
            ' rpt_Monthly.FileName = Server.MapPath("PPMP_Monthly.rpt")
            Dim rptPath_Monthly As String = HostingEnvironment.MapPath("~/MainReports/PPMP_Monthly.rpt")
            rpt_Monthly.FileName = rptPath_Monthly

            'ApplyDatabaseLogon(rpt_Monthly, "SMSS", "Username", "Password")
            ApplyDatabaseLogon(rpt_Monthly, dsn, userIDFromConfig, passwordFromConfig)

            rpt_Monthly.SetParameterValue("@CYear", Session("CYear"))
            rpt_Monthly.SetParameterValue("@RC_ID", Session("RC_ID"))
            rpt_Monthly.SetParameterValue("@Function_ID", Session("Function_ID"))
            rpt_Monthly.SetParameterValue("@isInfra", Session("isInfra"))
            'rpt_Monthly.SetParameterValue("@isGoods", Session("isGoods"))
            Me.PlanningReports.ReportSource = rpt_Monthly
        End If

        If Session("Page") = "Planning_PPMP" Then
            'Me.PlanningReports.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(obj.username, obj.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("CYear"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isInfra", Session("isInfra"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isGoods", Session("isGoods"))

            ' rpt_Monthly.FileName = Server.MapPath("PPMP_Monthly.rpt")
            Dim rptPath_MonthlyPPMP As String = HostingEnvironment.MapPath("~/MainReports/PPMP_Monthly.rpt")
            rpt_Monthly.FileName = rptPath_MonthlyPPMP


            ApplyDatabaseLogon(rpt_Monthly, dsn, userIDFromConfig, passwordFromConfig)

            rpt_Monthly.SetParameterValue(0, Session("CYear"))
            rpt_Monthly.SetParameterValue(1, Session("RC_ID"))
            rpt_Monthly.SetParameterValue(2, Session("Function_ID"))
            rpt_Monthly.SetParameterValue(3, Session("isInfra"))
            'rpt_Monthly.SetParameterValue(4, Session("isGoods"))
            Me.PlanningReports.ReportSource = rpt_Monthly
        End If

        If Session("Page") = "PPMP_HISTORY" Then
            'Me.PlanningReports.ReportSource = Me.CrystalReportSource2
            'Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(obj.username, obj.Password)
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@CYear", Session("CYear"))
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isInfra", Session("isInfra"))

            ' rpt_PPMP_Monthly_Revision.FileName = Server.MapPath("PPMP_Monthly_Revision.rpt")
            Dim rptPath_Revision As String = HostingEnvironment.MapPath("~/MainReports/PPMP_Monthly_Revision.rpt")
            rpt_PPMP_Monthly_Revision.FileName = rptPath_Revision


            ApplyDatabaseLogon(rpt_PPMP_Monthly_Revision, dsn, userIDFromConfig, passwordFromConfig)

            rpt_PPMP_Monthly_Revision.SetParameterValue(0, Session("CYear"))
            rpt_PPMP_Monthly_Revision.SetParameterValue(1, Session("RC_ID"))
            rpt_PPMP_Monthly_Revision.SetParameterValue(2, Session("Function_ID"))
            rpt_PPMP_Monthly_Revision.SetParameterValue(3, Session("isInfra"))
            Me.PlanningReports.ReportSource = rpt_PPMP_Monthly_Revision
        End If
    End Sub

    Private Sub ApplyDatabaseLogon(report As ReportDocument, dsn As String, userId As String, password As String)
        For Each table As Table In report.Database.Tables
            Dim logonInfo As TableLogOnInfo = table.LogOnInfo
            logonInfo.ConnectionInfo.ServerName = dsn  ' The ODBC DSN name or Data Source
            logonInfo.ConnectionInfo.DatabaseName = "SMSS_Premium" ' Target database (from your code)
            logonInfo.ConnectionInfo.UserID = userId   ' ODBC UserID (parsed from connection string)
            logonInfo.ConnectionInfo.Password = password  ' ODBC Password (parsed from connection string)
            table.ApplyLogOnInfo(logonInfo)
        Next
    End Sub

    Private Sub MainReports_Report_Planning_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub lnkBackPrevious_Click(sender As Object, e As EventArgs) Handles lnkBackPrevious.Click
        'If Session("Page") = "PPMP PERPPA" Then
        '    Me.Page.Response.Redirect("~/Reports and Query/T_PPMPHistory.aspx")
        'ElseIf Session("Page") = "Planning_List" Then
        '    Me.Page.Response.Redirect("~/planning/PPMP_Monthly.aspx")
        'ElseIf Session("Page") = "Planning_List" Then
        '    Me.Page.Response.Redirect("~/planning/t_ppmpList.aspx")
        'ElseIf Session("Page") = "PPMP HISTORY" Then
        '    Me.Page.Response.Redirect("~/Reports and Query/T_PPMPHistory.aspx")
        'End If
        Me.Page.Response.Redirect("~/planning/t_ppmpList.aspx")
    End Sub

End Class
