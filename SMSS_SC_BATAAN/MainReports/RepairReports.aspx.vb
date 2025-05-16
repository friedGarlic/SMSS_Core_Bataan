
Partial Class MainReports_RepairReports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub MainReports_RepairReports_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub MainReports_RepairReports_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("Report") = "PreRepair" Then
            Me.PreRepairReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.PreRepairReports.Attributes.Clear()

            Me.Crystalreportsource2.Report.FileName = "rpt_PreRepairInspection.rpt"
            Me.Crystalreportsource2.ReportDocument.Refresh()

            Me.PreRepairReports.ReportSource = Me.Crystalreportsource2
            Me.Crystalreportsource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@repair_hdr_id", Session("repair_hdr_id"))

        ElseIf Session("Report") = "PreRepairReportPreview" Then
            Me.PreRepairReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.PreRepairReports.Attributes.Clear()

            Me.Crystalreportsource2.Report.FileName = "rpt_PreRepairInspection.rpt"
            Me.Crystalreportsource2.ReportDocument.Refresh()

            Me.PreRepairReports.ReportSource = Me.Crystalreportsource2
            Me.Crystalreportsource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@repair_hdr_id", Session("repair_hdr_id"))

        ElseIf Session("Page") = "RepairCard" Then
            Me.RepairCard.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.RepairCard.Attributes.Clear()

            Me.Crystalreportsource1.Report.FileName = "rpt_RepairCard.rpt"
            Me.Crystalreportsource1.ReportDocument.Refresh()

            Me.RepairCard.ReportSource = Me.Crystalreportsource1
            Me.Crystalreportsource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@PropertyDetai_ID", Session("PropertyDetai_ID"))

        ElseIf Session("report") = "RepairCard" Then
            Me.RepairCard.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.RepairCard.Attributes.Clear()

            Me.Crystalreportsource1.Report.FileName = "rpt_RepairCard.rpt"
            Me.Crystalreportsource1.ReportDocument.Refresh()

            Me.RepairCard.ReportSource = Me.Crystalreportsource1
            Me.Crystalreportsource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@PropertyDetai_ID", Session("PropertyDetai_ID"))

        Else


        End If

    End Sub

    Private Sub MainReports_RepairReports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click

        PreRepairReports.Dispose()
        RepairCard.Dispose()

        If Session("Page") = "PropertyCard" Then
            Me.Page.Response.Redirect("~/Records/Property_Card.aspx")

        ElseIf Session("Page") = "RepairCard" Then
            Me.Page.Response.Redirect("~/Inventory/RepairCard.aspx")

        ElseIf Session("Page") = "PreRepair" Then
            Me.Page.Response.Redirect("~/Inventory/prerepair_inspection.aspx")


        ElseIf Session("Page") = "PreRepairReport" Then
            Me.Page.Response.Redirect("~/Reports and Query/t_Pre_Repair_Inspection.aspx")

        ElseIf Session("Page") = "PreRepairReportPreview" Then
            Me.Page.Response.Redirect("~/Inventory/Repair_Approval.aspx")
        End If



    End Sub
End Class
