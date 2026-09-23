Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class MainReports_Summary_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private rpt As New ReportDocument

    Private Sub MainReports_Summary_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("Summary_Report"), ReportDocument)

            If rptPrint Is Nothing Then

                If Session("Report") = "RPCPPE" Or Session("Report") = "RPCPPE_Conso" Or Session("Report") = "Schools" Then
                    Me.Page.Response.Redirect("~/Reports and Query/Summary_RPCPPE.aspx")
                ElseIf Session("Report") = "PAR" Or Session("Report") = "PRS" Or Session("PAGE") = "RPRI" Then
                    Me.Page.Response.Redirect("~/Reports and Query/Summary_PAR_PRS.aspx")
                End If

                Return

            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "Summary_Report")

            Me.Page.Response.End()

        End If

    End Sub

    Private Sub MainReports_Summary_Reports_Init(sender As Object, e As EventArgs) Handles Me.Init

        ' Hide every viewer first; the matching branch below will make its
        ' viewer visible again. This prevents the five inactive Crystal
        ' shells from rendering empty frames on the page.
        Me.Summary_RPRI.Visible = False
        Me.Summary_RPCPPE.Visible = False
        Me.Summary_RPCPPE_Conso.Visible = False
        Me.Summary_SChools.Visible = False
        Me.Summary_PAR.Visible = False
        Me.Summary_PRS.Visible = False

        If Session("PAGE") = "RPRI" Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("SummaryOfRPRI.rpt"))
            rpt.SetParameterValue("@RC_ID", Session("RC_ID"))
            rpt.SetParameterValue("@Month", Session("Month"))
            rpt.SetParameterValue("@CYEAR", Session("Year"))
            Session("Summary_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Summary_RPRI.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Summary_RPRI.ReportSource = rpt
            Me.Summary_RPRI.Visible = True

        ElseIf Session("Report") = "RPCPPE" Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_SummaryRPCPPE.rpt"))
            rpt.SetParameterValue("@AsOF", Session("AsOF"))
            rpt.SetParameterValue("@F_ID", Session("F_ID"))
            rpt.SetParameterValue("@NotedBy", Session("NotedBy"))
            rpt.SetParameterValue("@PreparedBy1", Session("PreparedBy1"))
            rpt.SetParameterValue("@PreparedBy2", Session("PreparedBy2"))
            rpt.SetParameterValue("@PreparedBy3", Session("PreparedBy3"))
            rpt.SetParameterValue("@PreparedBy4", Session("PreparedBy4"))
            Session("Summary_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Summary_RPCPPE.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Summary_RPCPPE.ReportSource = rpt
            Me.Summary_RPCPPE.Visible = True

        ElseIf Session("Report") = "RPCPPE_Conso" Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_SummaryRPCPPE_Conso.rpt"))
            rpt.SetParameterValue("@AsOF", Session("AsOF"))
            rpt.SetParameterValue("@NotedBy", Session("NotedBy"))
            rpt.SetParameterValue("@PreparedBy1", Session("PreparedBy1"))
            rpt.SetParameterValue("@PreparedBy2", Session("PreparedBy2"))
            rpt.SetParameterValue("@PreparedBy3", Session("PreparedBy3"))
            rpt.SetParameterValue("@PreparedBy4", Session("PreparedBy4"))
            Session("Summary_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Summary_RPCPPE_Conso.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Summary_RPCPPE_Conso.ReportSource = rpt
            Me.Summary_RPCPPE_Conso.Visible = True

        ElseIf Session("Report") = "Schools" Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_SummarySchools.rpt"))
            rpt.SetParameterValue("@AsOF", Session("AsOF"))
            Session("Summary_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Summary_SChools.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Summary_SChools.ReportSource = rpt
            Me.Summary_SChools.Visible = True

        ElseIf Session("Report") = "PAR" Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_Summary_PAR.rpt"))
            rpt.SetParameterValue("@RC_ID", Session("RC_ID"))
            rpt.SetParameterValue("@Month", Session("Month"))
            rpt.SetParameterValue("@CYear", Session("CYear"))
            Session("Summary_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Summary_PAR.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Summary_PAR.ReportSource = rpt
            Me.Summary_PAR.Visible = True
            Me.Summary_PAR.Zoom(80)

        ElseIf Session("Report") = "PRS" Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_Summary_PRS.rpt"))
            rpt.SetParameterValue("@RC_ID", Session("RC_ID"))
            rpt.SetParameterValue("@Status", Session("Status"))
            rpt.SetParameterValue("@Year", Session("Year"))
            rpt.SetParameterValue("@Month", Session("Month"))
            rpt.SetParameterValue("@PreparedBy_ID", Session("PreparedBy"))
            Session("Summary_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Summary_PRS.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Summary_PRS.ReportSource = rpt
            Me.Summary_PRS.Visible = True

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