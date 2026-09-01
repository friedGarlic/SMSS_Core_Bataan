
Partial Class MainReports_Inventory_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub


    Private Sub MainReports_Inventory_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Session("Report") = "ICS" Then
            loadRIS_Size()

        ElseIf Session("Report") = "RIS" Then
            loadRIS_Size()
        End If

    End Sub

    Private Sub MainReports_Inventory_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click
        If Session("Page") = "INV" And Session("Report") = "ICS" Then
            Me.Page.Response.Redirect("~/Inventory/ICS.aspx")

        ElseIf Session("Page") = "INV" And Session("Report") = "RIS" Then
            Me.Page.Response.Redirect("~/Inventory/t_RequisitionAndIssunace.aspx")

        ElseIf Session("Page") = "RQ" And Session("Report") = "ICS" Then
            Me.Page.Response.Redirect("~/Reports and Query/t_rpt_ICS.aspx")

        ElseIf Session("Page") = "RQ" And Session("Report") = "RIS" Then
            Me.Page.Response.Redirect("~/Reports and Query/t_requisition_and_issuance.aspx")

        End If
    End Sub

    Protected Sub drpReportFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpReportFormat.SelectedIndexChanged
        loadRIS_Size()
    End Sub


    Protected Sub loadRIS_Size()
        Me.InventoryReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        If Session("Report") = "ICS" Then
            lblTitle.Text = "INVENTORY CUSTODIAN SLIP"

            If drpReportFormat.SelectedItem.Value = 1 Then
                Me.CrystalReportSource1.Report.FileName = "Inventory_ICS_v2.rpt"
                Me.InventoryReports.ReportSource = Me.CrystalReportSource1
                Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource1.ReportDocument.SetParameterValue("@ICSHdr_ID", Session("ICSHdr_ID"))

            ElseIf drpReportFormat.SelectedItem.Value = 2 Then
                Me.CrystalReportSource2.Report.FileName = "Inventory_ICS_v2_Long.rpt"
                Me.InventoryReports.ReportSource = Me.CrystalReportSource2
                Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@ICSHdr_ID", Session("ICSHdr_ID"))

            End If

        ElseIf Session("Report") = "RIS" Then
            lblTitle.Text = "REQUISITION AND ISSUANCE SLIP"
            Addtrace("ris_no: " & Session("ris_no"))
            ReportSize.Visible = False
            If drpReportFormat.SelectedItem.Value = 1 Then
                Me.CrystalReportSource1.Report.FileName = "Inventory_RIS_v2.rpt"
                Me.InventoryReports.ReportSource = Me.CrystalReportSource1
                Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RIS_No", Session("ris_no"))

            ElseIf drpReportFormat.SelectedItem.Value = 2 Then
                Me.CrystalReportSource2.Report.FileName = "Inventory_RIS_v2_Long.rpt"
                Me.InventoryReports.ReportSource = Me.CrystalReportSource2
                Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@RIS_No", Session("ris_no"))
            End If
        End If


    End Sub
End Class
