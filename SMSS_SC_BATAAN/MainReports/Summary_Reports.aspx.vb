
Partial Class MainReports_Summary_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub MainReports_Summary_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub MainReports_Summary_Reports_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("PAGE") = "RPRI" Then
            Me.Summary_RPRI.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Summary_RPRI.Attributes.Clear()

            Me.Summary_RPRI.ReportSource = Me.Crystalreportsource6
            Me.Crystalreportsource6.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource6.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
            Me.Crystalreportsource6.ReportDocument.SetParameterValue("@Month", Session("Month"))

            Me.Crystalreportsource6.ReportDocument.SetParameterValue("@CYEAR", Session("Year"))



        ElseIf Session("Report") = "RPCPPE" Then
            Me.Summary_RPCPPE.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.Summary_RPCPPE.ReportSource = Me.Crystalreportsource1
            Me.Crystalreportsource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@AsOF", Session("AsOF"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@F_ID", Session("F_ID"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@NotedBy", Session("NotedBy"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@PreparedBy1", Session("PreparedBy1"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@PreparedBy2", Session("PreparedBy2"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@PreparedBy3", Session("PreparedBy3"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@PreparedBy4", Session("PreparedBy4"))

        ElseIf Session("Report") = "RPCPPE_Conso" Then
            Me.Summary_RPCPPE_Conso.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.Summary_RPCPPE_Conso.ReportSource = Me.Crystalreportsource2
            Me.Crystalreportsource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@AsOF", Session("AsOF"))
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@NotedBy", Session("NotedBy"))
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@PreparedBy1", Session("PreparedBy1"))
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@PreparedBy2", Session("PreparedBy2"))
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@PreparedBy3", Session("PreparedBy3"))
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@PreparedBy4", Session("PreparedBy4"))

        ElseIf Session("Report") = "Schools" Then
            Me.Summary_SChools.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.Summary_SChools.ReportSource = Me.Crystalreportsource3
            Me.Crystalreportsource3.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@AsOF", Session("AsOF"))

        ElseIf Session("Report") = "PAR" Then
            Me.Summary_PAR.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Summary_PAR.Attributes.Clear()

            Me.Crystalreportsource4.Report.FileName = "rpt_Summary_PAR.rpt"
            Me.Crystalreportsource4.ReportDocument.Refresh()

            Me.Summary_PAR.ReportSource = Me.Crystalreportsource4
            Me.Crystalreportsource4.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource4.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
            Me.Crystalreportsource4.ReportDocument.SetParameterValue("@Month", Session("Month"))
            Me.Crystalreportsource4.ReportDocument.SetParameterValue("@CYear", Session("CYear"))
            Me.Summary_PAR.Zoom(80)

        ElseIf Session("Report") = "PRS" Then
            Me.Summary_PRS.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Summary_PRS.Attributes.Clear()

            Me.Crystalreportsource5.Report.FileName = "rpt_Summary_PRS.rpt"
            Me.Crystalreportsource5.ReportDocument.Refresh()

            Me.Summary_PRS.ReportSource = Me.Crystalreportsource5
            Me.Crystalreportsource5.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource5.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
            Me.Crystalreportsource5.ReportDocument.SetParameterValue("@Status", Session("Status"))
            Me.Crystalreportsource5.ReportDocument.SetParameterValue("@Year", Session("Year"))
            Me.Crystalreportsource5.ReportDocument.SetParameterValue("@Month", Session("Month"))
            Me.Crystalreportsource5.ReportDocument.SetParameterValue("@PreparedBy_ID", Session("PreparedBy"))

        Else

        End If

    End Sub

    Private Sub MainReports_Summary_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        If Session("Report") = "RPCPPE" Or Session("Report") = "RPCPPE_Conso" Or Session("Report") = "Schools" Then
            Me.Page.Response.Redirect("~/Reports and Query/Summary_RPCPPE.aspx")

        ElseIf Session("Report") = "PAR" Or Session("Report") = "PRS" Or Session("PAGE") = "RPRI" Then
            Me.Page.Response.Redirect("~/Reports and Query/Summary_PAR_PRS.aspx")

        Else

        End If

    End Sub
End Class
