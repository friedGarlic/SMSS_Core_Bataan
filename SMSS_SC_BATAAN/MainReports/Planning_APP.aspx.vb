Imports System.Data

Partial Class Reports_and_Query_Main_Reports_Planning_APP
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport



    Private Sub Reports_and_Query_Main_Reports_Planning_APP_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.PlanningReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.PlanningReports.Attributes.Clear()

        If Session("Format") = "MOOE" Then

            Me.Crystalreportsource3.Report.FileName = "rpt_APP_AllotmentType.rpt"
            Me.Crystalreportsource3.ReportDocument.Refresh()

            Me.PlanningReports.ReportSource = Me.Crystalreportsource3
            Me.Crystalreportsource3.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@CYear", Session("DeptYear"))
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@RC_ID", Session("Department_ID"))
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@Function_ID", Session("Dept_Function_ID"))
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@AllotmentClass_ID", Session("AllotmentClass_ID"))
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@PPA", Session("PPA"))
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@Program_ID", Session("Program_ID"))
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@Project_ID", Session("Project_ID"))
            'Me.PlanningReports.Zoom(90)

        ElseIf Session("Format") = "CO" Or Session("Format") = "SUPPLIES" Then
            If Session("PPA") = "All" Then
                Me.Crystalreportsource1.Report.FileName = "rpt_APP_AllotmentType_wGoods_all.rpt"
            Else

                Me.Crystalreportsource1.Report.FileName = "rpt_APP_AllotmentType_wGoods.rpt"
            End If
            Me.Crystalreportsource1.ReportDocument.Refresh()

            Me.PlanningReports.ReportSource = Me.Crystalreportsource1
            Me.Crystalreportsource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@CYear", Session("DeptYear"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@RC_ID", Session("Department_ID"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@Function_ID", Session("Dept_Function_ID"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@AllotmentClass_ID", Session("AllotmentClass_ID"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@PPA", Session("PPA"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@Program_ID", Session("Program_ID"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@Project_ID", Session("Project_ID"))
            'Me.PlanningReports.Zoom(90)


        ElseIf Session("Format") = "Consolidated" Then

            Me.Crystalreportsource2.Report.FileName = "rpt_APP_Consolidated.rpt"
            Me.Crystalreportsource2.ReportDocument.Refresh()

            Me.PlanningReports.ReportSource = Me.Crystalreportsource2

            Me.Crystalreportsource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@CYear", Session("year"))
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("PreparedBy", Session("PreparedBy"))
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("ApprovedBy", Session("ApprovedBy"))
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("PreparedByPos", Session("PreparedByPos"))
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("ApprovedByPos", Session("ApprovedByPos"))
        ElseIf Session("Format") = "All" Then
            Me.Crystalreportsource4.Report.FileName = "rpt_app_test(2).rpt"
            Me.Crystalreportsource4.ReportDocument.Refresh()

            Me.PlanningReports.ReportSource = Me.Crystalreportsource4

            Me.Crystalreportsource4.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource4.ReportDocument.SetParameterValue("@CYear", Session("DeptYear"))
            Me.Crystalreportsource4.ReportDocument.SetParameterValue("@RC_ID", Session("Department_ID"))
            Me.Crystalreportsource4.ReportDocument.SetParameterValue("@Function_ID", Session("Dept_Function_ID"))
        End If
    End Sub

    Private Sub Reports_and_Query_Main_Reports_Planning_APP_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.PlanningReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        'If Session("Format") = "MOOE" Then

        '    Me.PlanningReports.ReportSource = Me.Crystalreportsource3
        '    Me.Crystalreportsource3.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        '    Me.Crystalreportsource3.ReportDocument.SetParameterValue("@CYear", Session("DeptYear"))
        '    Me.Crystalreportsource3.ReportDocument.SetParameterValue("@RC_ID", Session("Department_ID"))
        '    Me.Crystalreportsource3.ReportDocument.SetParameterValue("@Function_ID", Session("Dept_Function_ID"))
        '    Me.Crystalreportsource3.ReportDocument.SetParameterValue("@AllotmentClass_ID", Session("AllotmentClass_ID"))
        '    Me.Crystalreportsource3.ReportDocument.SetParameterValue("@PPA", Session("PPA"))
        '    Me.Crystalreportsource3.ReportDocument.SetParameterValue("@Program_ID", Session("Program_ID"))
        '    Me.Crystalreportsource3.ReportDocument.SetParameterValue("@Project_ID", Session("Project_ID"))
        '    'Me.PlanningReports.Zoom(90)

        'ElseIf Session("Format") = "CO" Or Session("Format") = "SUPPLIES" Then
        '    Me.PlanningReports.ReportSource = Me.Crystalreportsource1
        '    Me.Crystalreportsource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        '    Me.Crystalreportsource1.ReportDocument.SetParameterValue("@CYear", Session("DeptYear"))
        '    Me.Crystalreportsource1.ReportDocument.SetParameterValue("@RC_ID", Session("Department_ID"))
        '    Me.Crystalreportsource1.ReportDocument.SetParameterValue("@Function_ID", Session("Dept_Function_ID"))
        '    Me.Crystalreportsource1.ReportDocument.SetParameterValue("@AllotmentClass_ID", Session("AllotmentClass_ID"))
        '    Me.Crystalreportsource1.ReportDocument.SetParameterValue("@PPA", Session("PPA"))
        '    Me.Crystalreportsource1.ReportDocument.SetParameterValue("@Program_ID", Session("Program_ID"))
        '    Me.Crystalreportsource1.ReportDocument.SetParameterValue("@Project_ID", Session("Project_ID"))
        '    'Me.PlanningReports.Zoom(90)
        'End If

    End Sub

    Private Sub Reports_and_Query_Main_Reports_Planning_APP_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        Me.Page.Response.Redirect("~/planning/t_annual_procurement_plan.aspx")
    End Sub


End Class
