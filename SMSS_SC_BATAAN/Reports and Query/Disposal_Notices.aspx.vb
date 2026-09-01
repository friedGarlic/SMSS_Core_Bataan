
Partial Class MainReports_Disposal_Notice
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub MainReports_Disposal_Notice_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Private Sub MainReports_Disposal_Notice_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("Report") = "NOA" Or Session("Report") = "RQ_NOA" Then
            pnlDate.Visible = False
            Me.Disposal_NOA.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.Disposal_NOA.ReportSource = Me.Crystalreportsource1
            Me.Crystalreportsource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))

        ElseIf Session("Report") = "NTP" Or Session("Report") = "RQ_NTP" Then
            pnlDate.Visible = False
            Me.Disposal_NTP.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.Disposal_NTP.ReportSource = Me.Crystalreportsource2
            Me.Crystalreportsource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))

        ElseIf Session("Report") = "Accntg" Then
            pnlDate.Visible = False
            Me.Disposal_Accntng.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.Disposal_Accntng.ReportSource = Me.Crystalreportsource3
            Me.Crystalreportsource3.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))

        ElseIf Session("Report") = "WMR" Or Session("Report") = "WMR2" Then
            pnlDate.Visible = False
            Me.DisposalWMR.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.DisposalWMR.ReportSource = Me.Crystalreportsource4
            Me.Crystalreportsource4.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource4.ReportDocument.SetParameterValue("@WMHdr_ID", Session("WMHdr_ID"))

        ElseIf Session("Report") = "Checklist" Then
            pnlDate.Visible = False
            Me.DisposalChecklist.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.DisposalChecklist.ReportSource = Me.Crystalreportsource5
            Me.Crystalreportsource5.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource5.ReportDocument.SetParameterValue("@checklist_ID", Session("checklist_ID"))

        ElseIf Session("Report") = "Checklist_OE" Then
            pnlDate.Visible = False
            Me.DisposalChecklist_OE.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.DisposalChecklist_OE.ReportSource = Me.Crystalreportsource7
            Me.Crystalreportsource7.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource7.ReportDocument.SetParameterValue("@OE_checklist_ID", Session("OE_checklist_ID"))

        ElseIf Session("Report") = "AppraisalRpt" Or Session("Report") = "AppraisalRpt_RQ" Then
            pnlDate.Visible = False
            Me.Disposal_AppraisalReport.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.Disposal_AppraisalReport.ReportSource = Me.Crystalreportsource6
            Me.Crystalreportsource6.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource6.ReportDocument.SetParameterValue("@Appraisal_rpt_id", Session("Appraisal_rpt_id"))

        ElseIf Session("Report") = "Notice_COA" Then
            pnlDate.Visible = False
            Me.Disposal_NoticeCOA.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.Disposal_NoticeCOA.ReportSource = Me.Crystalreportsource8
            Me.Crystalreportsource8.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource8.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
            'Me.Crystalreportsource8.ReportDocument.SetParameterValue("@NoticeDate", Session("Notice_COA_Date"))

        ElseIf Session("Report") = "Notice_Conspicuous" Then
            txtDate.Text = Date.Today.ToShortDateString
            pnlDate.Visible = True
            Me.Disposal_NoticeConspicuous.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.Disposal_NoticeConspicuous.ReportSource = Me.Crystalreportsource9
            Me.Crystalreportsource9.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource9.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
            Me.Crystalreportsource9.ReportDocument.SetParameterValue("@Date", Session("Date"))

        ElseIf Session("Report") = "Summary_WMR" Then
            pnlDate.Visible = False
            Me.Disposal_SummaryWMR.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.Disposal_SummaryWMR.ReportSource = Me.Crystalreportsource10
            Me.Crystalreportsource10.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource10.ReportDocument.SetParameterValue("@Date", Session("Date"))
            Me.Crystalreportsource10.ReportDocument.SetParameterValue("@PrepareBy1", Session("PrepareBy1"))
            Me.Crystalreportsource10.ReportDocument.SetParameterValue("@PrepareBy2", Session("PrepareBy2"))
            Me.Disposal_SummaryWMR.Zoom(80)
        Else

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

        Me.Disposal_NoticeConspicuous.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        Me.Disposal_NoticeConspicuous.ReportSource = Me.Crystalreportsource9
        Me.Crystalreportsource9.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.Crystalreportsource9.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
        Me.Crystalreportsource9.ReportDocument.SetParameterValue("@Date", Session("Date"))
    End Sub
End Class
