
Partial Class MainReports_Procurement_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub MainReports_Procurement_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load

        RadioButtonList1.Items(1).Enabled = False
        RadioButtonList1.Items(1).Attributes.Add("style", "display:none;")
        Me.ProcurementReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        If RadioButtonList1.SelectedIndex = 0 Then
            'here
            If Session("Report") = "PR" Then
                lblTitle.Text = "PURCHASE REQUEST REPORT"

                Me.CrystalReportSource1.Report.FileName = "Procurement_PR.rpt"
                Me.ProcurementReports.ReportSource = Me.CrystalReportSource1
                Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))

                Me.CrystalReportSource3.Report.FileName = "BOSS_OBR.rpt"
                Me.OBR_Report.ReportSource = Me.CrystalReportSource3
                Me.CrystalReportSource3.ReportDocument.DataSourceConnections.Item(0).IntegratedSecurity = False
                Me.CrystalReportSource3.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource3.ReportDocument.SetParameterValue("@PRHdr_ID", Session("prhdr_id"))

                CAFOA2()
            End If

        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            Me.CAFOA.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.RPT_CAFOA.Report.FileName = "rpt_CAFOA.rpt"
            Me.CAFOA.ReportSource = Me.RPT_CAFOA
            Me.RPT_CAFOA.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.RPT_CAFOA.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))

        End If


    End Sub
    Public Sub CAFOA2()
        Me.CAFOA.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.RPT_CAFOA.Report.FileName = "rpt_CAFOA.rpt"
        Me.CAFOA.ReportSource = Me.RPT_CAFOA
        Me.RPT_CAFOA.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.RPT_CAFOA.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))
    End Sub

    Private Sub MainReports_Procurement_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click
        'If Session("Page") = "RQ" Then
        '    If Session("Report") = "PR" Then
        '        Me.Page.Response.Redirect("~/Procurement/t_purchase_request.aspx")
        '    Else

        '    End If
        'ElseIf Session("Page") = "PR_Approval" Then
        '    Me.Page.Response.Redirect("~/procurement/t_purchase_request_Approval.aspx")

        'ElseIf Session("Page") = "PR_Receiving" Then


        'ElseIf Session("Page") = "PR" Then
        '    Me.Page.Response.Redirect("~/procurement/t_purchase_request_v2.aspx")

        'ElseIf Session("Page") = "PPA" Then
        Me.Page.Response.Redirect("~/PLANNING/boss_BudgetPPA.aspx")

        'ElseIf Session("Page") = "OOE" Then
        '    Me.Page.Response.Redirect("~/PLANNING/boss_BudgetOOE.aspx")
        'End If
    End Sub

    Private Sub drpReportFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpReportFormat.SelectedIndexChanged
        loadPR_Size()
    End Sub

    Protected Sub loadPR_Size()
        lblTitle.Text = "PURCHASE REQUEST REPORT"

        If drpReportFormat.SelectedItem.Value = 1 Then
            Me.CrystalReportSource1.Report.FileName = "Procurement_PR.rpt"
            Me.ProcurementReports.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))

        ElseIf drpReportFormat.SelectedItem.Value = 2 Then
            Me.CrystalReportSource1.Report.FileName = "Procurement_PR_Long.rpt"
            Me.ProcurementReports.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))
        End If

    End Sub
End Class
