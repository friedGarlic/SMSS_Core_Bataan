
Partial Class Inventory_t_rpt_return_slip
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Session("view") = "2"
        'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        'Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("Returned_ID"))
        If Session("Report") = "PRS_EndUser" Then
            Me.PRS_EndUser.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.CrystalReportSource2.Report.FileName = "rpt_Temp_PRS.rpt"

            Me.PRS_EndUser.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue("@prs_hdr_id", Session("prs_hdr_id"))

        Else
            Me.ReturnSlipReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.ReturnSlipReports.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("Returned_ID"))

        End If

    End Sub

    Private Sub Inventory_t_rpt_return_slip_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("Report") = "PRS_EndUser" Then
            Me.PRS_EndUser.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.CrystalReportSource2.Report.FileName = "rpt_Temp_PRS.rpt"

            Me.PRS_EndUser.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue("@prs_hdr_id", Session("prs_hdr_id"))

        Else
            Me.ReturnSlipReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.ReturnSlipReports.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("Returned_ID"))

        End If



    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        If Session("Page") = "RQ" Then
            ReturnSlipReports.ReportSource = Nothing
            ReturnSlipReports.RefreshReport()

            Me.Page.Response.Redirect("~/Reports and Query/t_rpt_PRS.aspx")

        ElseIf Session("Page") = "PRS_EndUser" Then
            PRS_EndUser.ReportSource = Nothing
            PRS_EndUser.RefreshReport()

            Me.Page.Response.Redirect("~/Inventory/Issuance_PRS.aspx")

        ElseIf Session("Page") = "PRS_Approved" Then
            ReturnSlipReports.ReportSource = Nothing
            ReturnSlipReports.RefreshReport()

            Me.Page.Response.Redirect("~/Inventory/Issuance_PRSApproval.aspx")

        End If
    End Sub
    Private Sub Inventory_t_rpt_return_slip_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub

End Class
