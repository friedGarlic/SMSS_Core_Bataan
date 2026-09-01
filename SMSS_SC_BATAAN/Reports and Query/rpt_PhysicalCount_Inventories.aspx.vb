
Partial Class Reports_and_Query_rpt_PhysicalCount_Inventories
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddTrace("GA_ID: " & Session("GA_ID"))
        AddTrace("StockDate: " & Session("StockDate"))
        'If Session("Report") = "ALL" Then

        '    Me.rpt_PhysicalCount_Inventories.ReportSource = Me.CrystalReportSource2
        '    Me.rpt_PhysicalCount_Inventories.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        '    Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)

        'Else
        '    Me.rpt_PhysicalCount_Inventories.ReportSource = Me.CrystalReportSource1
        '    Me.rpt_PhysicalCount_Inventories.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        '    Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", Session("GA_ID"))
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@StockDate", Session("StockDate"))
        'End If


        Me.rpt_PhysicalCount_Inventories.ReportSource = Me.CrystalReportSource1
        Me.rpt_PhysicalCount_Inventories.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", Session("GA_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@StockDate", Session("StockDate"))


    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Reports and Query/t_rpt_physical_count_of_inventory.aspx")
    End Sub
End Class
