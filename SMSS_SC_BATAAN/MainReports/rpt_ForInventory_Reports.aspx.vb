
Partial Class MainReports_rpt_ForInventory_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private Sub MainReports_rpt_ForInventory_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub

    Private Sub MainReports_rpt_ForInventory_Reports_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("Page") = "Manual_Supplies" Then
            Me.ForInventory_Supplies.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.ForInventory_Supplies.ReportSource = Me.Crystalreportsource1
            Me.Crystalreportsource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@GA_ID", Session("GA_ID"))
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@BGA_ID", Session("BGA_ID"))

        ElseIf Session("Page") = "SchedulingInventories" Then

            Me.SchedulingReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            Me.SchedulingReports.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Inventory", Session("Inventory"))

        Else

        End If


    End Sub

    Private Sub MainReports_rpt_ForInventory_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        If Session("Page") = "Manual_Supplies" Then
            Me.Page.Response.Redirect("~/Inventory/t_encoding_supplies.aspx")
        ElseIf Session("Page") = "SchedulingInventories" Then
            Me.Page.Response.Redirect("~/Reports and Query/schedulinginventorysupplies.aspx")
        Else

        End If

    End Sub
End Class
