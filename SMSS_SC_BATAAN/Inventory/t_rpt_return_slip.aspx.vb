Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Inventory_t_rpt_return_slip
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("PRS_Report"), ReportDocument)

            If rptPrint Is Nothing Then

                If Session("Page") = "RQ" Then
                    Me.Page.Response.Redirect("~/Reports and Query/t_rpt_PRS.aspx")
                ElseIf Session("Page") = "PRS_EndUser" Then
                    Me.Page.Response.Redirect("~/Inventory/Issuance_PRS.aspx")
                ElseIf Session("Page") = "PRS_Approved" Then
                    Me.Page.Response.Redirect("~/Inventory/Issuance_PRSApproval.aspx")
                End If

                Return

            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "PRS_Report")

            Me.Page.Response.End()

        End If

    End Sub

    Private Sub Inventory_t_rpt_return_slip_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Session("Report") = "PRS_EndUser" Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_Temp_PRS.rpt"))
            rpt.SetParameterValue("@prs_hdr_id", Session("prs_hdr_id"))
            Session("PRS_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.PRS_EndUser.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.PRS_EndUser.ReportSource = rpt
            Me.PRS_EndUser.Visible = True
            Me.ReturnSlipReports.Visible = False

        Else

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("PRS_v2.rpt"))
            rpt.SetParameterValue(0, Session("Returned_ID"))
            Session("PRS_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.ReturnSlipReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.ReturnSlipReports.ReportSource = rpt
            Me.ReturnSlipReports.Visible = True
            Me.PRS_EndUser.Visible = False

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