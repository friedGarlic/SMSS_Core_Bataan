Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class MainReports_Disposal_Notice
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private rpt As New ReportDocument

    Private Sub MainReports_Disposal_Notice_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("Disposal_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_Notice.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "Disposal_Report")

            Me.Page.Response.End()

        End If

    End Sub

    Private Sub MainReports_Disposal_Notice_Init(sender As Object, e As EventArgs) Handles Me.Init

        ' Hide every viewer first; the matching branch below will make its
        ' viewer visible again. This prevents the nine inactive Crystal
        ' shells from rendering empty frames on the page.
        Me.Disposal_NOA.Visible = False
        Me.Disposal_NTP.Visible = False
        Me.Disposal_Accntng.Visible = False
        Me.DisposalWMR.Visible = False
        Me.DisposalChecklist.Visible = False
        Me.DisposalChecklist_OE.Visible = False
        Me.Disposal_AppraisalReport.Visible = False
        Me.Disposal_NoticeCOA.Visible = False
        Me.Disposal_NoticeConspicuous.Visible = False
        Me.Disposal_SummaryWMR.Visible = False

        If Session("Report") = "NOA" Or Session("Report") = "RQ_NOA" Then

            pnlDate.Visible = False

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_Disposal_NOA.rpt"))
            rpt.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
            Session("Disposal_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Disposal_NOA.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Disposal_NOA.ReportSource = rpt
            Me.Disposal_NOA.Visible = True

        ElseIf Session("Report") = "NTP" Or Session("Report") = "RQ_NTP" Then

            pnlDate.Visible = False

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_Disposal_NTP.rpt"))
            rpt.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
            Session("Disposal_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Disposal_NTP.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Disposal_NTP.ReportSource = rpt
            Me.Disposal_NTP.Visible = True

        ElseIf Session("Report") = "Accntg" Then

            pnlDate.Visible = False

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_Disposal_Accntng.rpt"))
            rpt.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
            Session("Disposal_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Disposal_Accntng.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Disposal_Accntng.ReportSource = rpt
            Me.Disposal_Accntng.Visible = True

        ElseIf Session("Report") = "WMR" Or Session("Report") = "WMR2" Then

            pnlDate.Visible = False

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_WasteMaterialReport_v2.rpt"))
            rpt.SetParameterValue("@WMHdr_ID", Session("WMHdr_ID"))
            Session("Disposal_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.DisposalWMR.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.DisposalWMR.ReportSource = rpt
            Me.DisposalWMR.Visible = True

        ElseIf Session("Report") = "Checklist" Then

            pnlDate.Visible = False

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_checklistunserviceableppe.rpt"))
            rpt.SetParameterValue("@checklist_ID", Session("checklist_ID"))
            Session("Disposal_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.DisposalChecklist.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.DisposalChecklist.ReportSource = rpt
            Me.DisposalChecklist.Visible = True

        ElseIf Session("Report") = "Checklist_OE" Then

            pnlDate.Visible = False

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_checklistunserviceable_OE.rpt"))
            rpt.SetParameterValue("@OE_checklist_ID", Session("OE_checklist_ID"))
            Session("Disposal_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.DisposalChecklist_OE.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.DisposalChecklist_OE.ReportSource = rpt
            Me.DisposalChecklist_OE.Visible = True

        ElseIf Session("Report") = "AppraisalRpt" Or Session("Report") = "AppraisalRpt_RQ" Then

            pnlDate.Visible = False

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_Disposal_Appraisal.rpt"))
            rpt.SetParameterValue("@Appraisal_rpt_id", Session("Appraisal_rpt_id"))
            Session("Disposal_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Disposal_AppraisalReport.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Disposal_AppraisalReport.ReportSource = rpt
            Me.Disposal_AppraisalReport.Visible = True

        ElseIf Session("Report") = "Notice_COA" Then

            pnlDate.Visible = False

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_Disposal_NoticeCOA.rpt"))
            rpt.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
            'rpt.SetParameterValue("@NoticeDate", Session("Notice_COA_Date"))
            Session("Disposal_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Disposal_NoticeCOA.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Disposal_NoticeCOA.ReportSource = rpt
            Me.Disposal_NoticeCOA.Visible = True

        ElseIf Session("Report") = "Notice_Conspicuous" Then

            txtDate.Text = Date.Today.ToShortDateString
            pnlDate.Visible = True

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_Disposal_NoticeConspicuous.rpt"))
            rpt.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
            rpt.SetParameterValue("@Date", Session("Date"))
            Session("Disposal_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Disposal_NoticeConspicuous.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Disposal_NoticeConspicuous.ReportSource = rpt
            Me.Disposal_NoticeConspicuous.Visible = True

        ElseIf Session("Report") = "Summary_WMR" Then

            pnlDate.Visible = False

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_Summary_WMR.rpt"))
            rpt.SetParameterValue("@Date", Session("Date"))
            rpt.SetParameterValue("@PrepareBy1", Session("PrepareBy1"))
            rpt.SetParameterValue("@PrepareBy2", Session("PrepareBy2"))
            Session("Disposal_Report") = rpt

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.Disposal_SummaryWMR.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.Disposal_SummaryWMR.ReportSource = rpt
            Me.Disposal_SummaryWMR.Visible = True
            Me.Disposal_SummaryWMR.Zoom(80)

        End If

    End Sub

    Private Sub MainReports_Disposal_Notice_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        If (Session("Report") = "WMR" And Session("Page") = "Disposal") Or Session("Report") = "Summary_WMR" Then
            Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_WasteMaterials.aspx")

        ElseIf Session("Report") = "WMR" And Session("Page") = "RQ" Then
            Me.Page.Response.Redirect("~/Reports and Query/WasteMaterials_Reports.aspx")

        ElseIf Session("Report") = "WMR2" Then
            Me.Page.Response.Redirect("~/Reports and Query/RQ_WasteMaterials.aspx")

        ElseIf Session("Report") = "Checklist" Or Session("Report") = "Checklist_OE" Then
            Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_CheckList.aspx")

        ElseIf Session("Report") = "AppraisalRpt" Then
            Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_InspectionAppraisal.aspx")

        ElseIf Session("Report") = "AppraisalRpt_RQ" Then
            Me.Page.Response.Redirect("~/Reports and Query/AdditionalReports/appraisal.aspx")

        ElseIf Session("Report") = "RQ_NOA" Or Session("Report") = "RQ_NTP" Then
            Me.Page.Response.Redirect("~/Reports and Query/DisposalReports.aspx")

        ElseIf Session("Report") = "Notice_COA" Or Session("Report") = "Notice_Conspicuous" Then
            Me.Page.Response.Redirect("~/inventory/Disposal/Disposal_ISSP_List.aspx")

        Else
            Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_Notice.aspx")

        End If

    End Sub

    Private Sub btnPreview_Conspicuous_Click(sender As Object, e As EventArgs) Handles btnPreview_Conspicuous.Click
        pnlDate.Visible = True
        Session("Date") = CType(txtDate.Text, DateTime)

        rpt = New ReportDocument()
        rpt.Load(Server.MapPath("rpt_Disposal_NoticeConspicuous.rpt"))
        rpt.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
        rpt.SetParameterValue("@Date", Session("Date"))
        Session("Disposal_Report") = rpt

        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        Me.Disposal_NoticeConspicuous.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.Disposal_NoticeConspicuous.ReportSource = rpt
    End Sub
End Class