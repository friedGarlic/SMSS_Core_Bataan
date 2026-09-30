Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class MainReports_Disposal_Notice
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Private Sub MainReports_Disposal_Notice_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("DisposalNotice_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_Notice.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "DisposalNotice")

            Me.Page.Response.End()

        End If

    End Sub

    Private Sub MainReports_Disposal_Notice_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Session("Report") = "NOA" Or Session("Report") = "RQ_NOA" Then
            pnlDate.Visible = False

            If Not IsPostBack Then
                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_Disposal_NOA.rpt"))
                rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                Session("DisposalNotice_Report") = rpt
            Else
                rpt = CType(Session("DisposalNotice_Report"), ReportDocument)
                If rpt Is Nothing Then
                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_Disposal_NOA.rpt"))
                    rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                    Session("DisposalNotice_Report") = rpt
                End If
            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Disposal_NOA.ReportSource = rpt

        ElseIf Session("Report") = "NTP" Or Session("Report") = "RQ_NTP" Then
            pnlDate.Visible = False

            If Not IsPostBack Then
                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_Disposal_NTP.rpt"))
                rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                Session("DisposalNotice_Report") = rpt
            Else
                rpt = CType(Session("DisposalNotice_Report"), ReportDocument)
                If rpt Is Nothing Then
                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_Disposal_NTP.rpt"))
                    rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                    Session("DisposalNotice_Report") = rpt
                End If
            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Disposal_NTP.ReportSource = rpt

        ElseIf Session("Report") = "Accntg" Then
            pnlDate.Visible = False

            If Not IsPostBack Then
                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_Disposal_Accntng.rpt"))
                rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                Session("DisposalNotice_Report") = rpt
            Else
                rpt = CType(Session("DisposalNotice_Report"), ReportDocument)
                If rpt Is Nothing Then
                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_Disposal_Accntng.rpt"))
                    rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                    Session("DisposalNotice_Report") = rpt
                End If
            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Disposal_Accntng.ReportSource = rpt

        ElseIf Session("Report") = "WMR" Or Session("Report") = "WMR2" Then
            pnlDate.Visible = False

            If Not IsPostBack Then
                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_WasteMaterialReport.rpt"))
                rpt.SetParameterValue("@WMHdr_ID", Me.Session("WMHdr_ID"))
                Session("DisposalNotice_Report") = rpt
            Else
                rpt = CType(Session("DisposalNotice_Report"), ReportDocument)
                If rpt Is Nothing Then
                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_WasteMaterialReport.rpt"))
                    rpt.SetParameterValue("@WMHdr_ID", Me.Session("WMHdr_ID"))
                    Session("DisposalNotice_Report") = rpt
                End If
            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.DisposalWMR.ReportSource = rpt

        ElseIf Session("Report") = "Checklist" Then
            pnlDate.Visible = False

            If Not IsPostBack Then
                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_checklistunserviceableppe.rpt"))
                rpt.SetParameterValue("@checklist_ID", Me.Session("checklist_ID"))
                Session("DisposalNotice_Report") = rpt
            Else
                rpt = CType(Session("DisposalNotice_Report"), ReportDocument)
                If rpt Is Nothing Then
                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_checklistunserviceableppe.rpt"))
                    rpt.SetParameterValue("@checklist_ID", Me.Session("checklist_ID"))
                    Session("DisposalNotice_Report") = rpt
                End If
            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.DisposalChecklist.ReportSource = rpt

        ElseIf Session("Report") = "Checklist_OE" Then
            pnlDate.Visible = False

            If Not IsPostBack Then
                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_checklistunserviceable_OE.rpt"))
                rpt.SetParameterValue("@OE_checklist_ID", Me.Session("OE_checklist_ID"))
                Session("DisposalNotice_Report") = rpt
            Else
                rpt = CType(Session("DisposalNotice_Report"), ReportDocument)
                If rpt Is Nothing Then
                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_checklistunserviceable_OE.rpt"))
                    rpt.SetParameterValue("@OE_checklist_ID", Me.Session("OE_checklist_ID"))
                    Session("DisposalNotice_Report") = rpt
                End If
            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.DisposalChecklist_OE.ReportSource = rpt

        ElseIf Session("Report") = "AppraisalRpt" Or Session("Report") = "AppraisalRpt_RQ" Then
            pnlDate.Visible = False

            If Not IsPostBack Then
                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_Disposal_Appraisal.rpt"))
                rpt.SetParameterValue("@Appraisal_rpt_id", Me.Session("Appraisal_rpt_id"))
                Session("DisposalNotice_Report") = rpt
            Else
                rpt = CType(Session("DisposalNotice_Report"), ReportDocument)
                If rpt Is Nothing Then
                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_Disposal_Appraisal.rpt"))
                    rpt.SetParameterValue("@Appraisal_rpt_id", Me.Session("Appraisal_rpt_id"))
                    Session("DisposalNotice_Report") = rpt
                End If
            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Disposal_AppraisalReport.ReportSource = rpt

        ElseIf Session("Report") = "Notice_COA" Then
            pnlDate.Visible = False

            If Not IsPostBack Then
                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_Disposal_NoticeCOA.rpt"))
                rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                Session("DisposalNotice_Report") = rpt
            Else
                rpt = CType(Session("DisposalNotice_Report"), ReportDocument)
                If rpt Is Nothing Then
                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_Disposal_NoticeCOA.rpt"))
                    rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                    Session("DisposalNotice_Report") = rpt
                End If
            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Disposal_NoticeCOA.ReportSource = rpt

        ElseIf Session("Report") = "Notice_Conspicuous" Then
            txtDate.Text = Date.Today.ToShortDateString
            pnlDate.Visible = True

            If Not IsPostBack Then
                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_Disposal_NoticeConspicuous.rpt"))
                rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                rpt.SetParameterValue("@Date", Me.Session("Date"))
                Session("DisposalNotice_Report") = rpt
            Else
                rpt = CType(Session("DisposalNotice_Report"), ReportDocument)
                If rpt Is Nothing Then
                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_Disposal_NoticeConspicuous.rpt"))
                    rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                    rpt.SetParameterValue("@Date", Me.Session("Date"))
                    Session("DisposalNotice_Report") = rpt
                End If
            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Disposal_NoticeConspicuous.ReportSource = rpt

        ElseIf Session("Report") = "Summary_WMR" Then
            pnlDate.Visible = False

            If Not IsPostBack Then
                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_Summary_WMR.rpt"))
                rpt.SetParameterValue("@Date", Me.Session("Date"))
                rpt.SetParameterValue("@PrepareBy1", Me.Session("PrepareBy1"))
                rpt.SetParameterValue("@PrepareBy2", Me.Session("PrepareBy2"))
                Session("DisposalNotice_Report") = rpt
            Else
                rpt = CType(Session("DisposalNotice_Report"), ReportDocument)
                If rpt Is Nothing Then
                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_Summary_WMR.rpt"))
                    rpt.SetParameterValue("@Date", Me.Session("Date"))
                    rpt.SetParameterValue("@PrepareBy1", Me.Session("PrepareBy1"))
                    rpt.SetParameterValue("@PrepareBy2", Me.Session("PrepareBy2"))
                    Session("DisposalNotice_Report") = rpt
                End If
            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Disposal_SummaryWMR.ReportSource = rpt
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

        rpt = New ReportDocument()
        rpt.Load(Server.MapPath("rpt_Disposal_NoticeConspicuous.rpt"))
        rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
        rpt.SetParameterValue("@Date", Me.Session("Date"))
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Session("DisposalNotice_Report") = rpt

        Me.Disposal_NoticeConspicuous.ReportSource = rpt
    End Sub
End Class