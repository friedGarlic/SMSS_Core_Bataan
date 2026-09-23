Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class MainReports_Inventory_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub MainReports_Inventory_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("INV_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect(GetBackUrl())
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "InventoryReport")

            Me.Page.Response.End()

        End If

        If Session("Report") = "ICS" Then
            loadRIS_Size()

        ElseIf Session("Report") = "RIS" Then
            loadRIS_Size()
        End If

        drpReportFormat.Visible = False
    End Sub

    Private Sub MainReports_Inventory_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub

    Private Function GetBackUrl() As String
        If Session("Page") = "INV" And Session("Report") = "ICS" Then
            Return "~/Inventory/ICS.aspx"

        ElseIf Session("Page") = "INV" And Session("Report") = "RIS" Then
            Return "~/Inventory/t_RequisitionAndIssunace.aspx"

        ElseIf Session("Page") = "RQ" And Session("Report") = "ICS" Then
            Return "~/Reports and Query/t_rpt_ICS.aspx"

        ElseIf Session("Page") = "RQ" And Session("Report") = "RIS" Then
            Return "~/Reports and Query/t_requisition_and_issuance.aspx"

        End If

        Return "~/Inventory/ICS.aspx"
    End Function

    Private Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click
        Me.Page.Response.Redirect(GetBackUrl())
    End Sub

    Protected Sub drpReportFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpReportFormat.SelectedIndexChanged
        loadRIS_Size()
        drpReportFormat.Visible = False
    End Sub

    Protected Sub loadRIS_Size()
        Me.InventoryReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        InventoryReports.EnableParameterPrompt = False   ' prevent popup UI
        InventoryReports.ReuseParameterValuesOnRefresh = False

        If Session("Report") = "ICS" Then
            lblTitle.Text = "INVENTORY CUSTODIAN SLIP"
            AddTrace("ICSHdr_ID: " & Session("ICSHdr_ID"))

            If drpReportFormat.SelectedItem.Value = 1 Then

                Me.CrystalReportSource1.Report.FileName = "Inventory_ICS_v2.rpt"

                ' If you really want Refresh, call it BEFORE params:
                Me.CrystalReportSource1.ReportDocument.Refresh()

                Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource1.ReportDocument.SetParameterValue("@ICSHdr_ID", Session("ICSHdr_ID"))

                Me.InventoryReports.ReportSource = Me.CrystalReportSource1
                Session("INV_Report") = Me.CrystalReportSource1.ReportDocument

            ElseIf drpReportFormat.SelectedItem.Value = 2 Then

                Me.CrystalReportSource2.Report.FileName = "Inventory_ICS_v2_Long.rpt"

                Me.CrystalReportSource2.ReportDocument.Refresh()

                Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@ICSHdr_ID", Session("ICSHdr_ID"))

                Me.InventoryReports.ReportSource = Me.CrystalReportSource2
                Session("INV_Report") = Me.CrystalReportSource2.ReportDocument

            End If

        ElseIf Session("Report") = "RIS" Then
            lblTitle.Text = "REQUISITION AND ISSUANCE SLIP"

            If drpReportFormat.SelectedItem.Value = 1 Then

                Me.CrystalReportSource1.Report.FileName = "Inventory_RIS_v2.rpt"

                Me.CrystalReportSource1.ReportDocument.Refresh()

                Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RIS_No", Session("ris_no"))

                Me.InventoryReports.ReportSource = Me.CrystalReportSource1
                Session("INV_Report") = Me.CrystalReportSource1.ReportDocument

            ElseIf drpReportFormat.SelectedItem.Value = 2 Then

                Me.CrystalReportSource2.Report.FileName = "Inventory_RIS_v2_Long.rpt"

                Me.CrystalReportSource2.ReportDocument.Refresh()

                Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@RIS_No", Session("ris_no"))

                Me.InventoryReports.ReportSource = Me.CrystalReportSource2
                Session("INV_Report") = Me.CrystalReportSource2.ReportDocument

            End If
        End If
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

End Class