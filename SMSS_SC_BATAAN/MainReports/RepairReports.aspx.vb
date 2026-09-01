Partial Class MainReports_RepairReports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub MainReports_RepairReports_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub MainReports_RepairReports_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            ' Hide all panels initially
            pnlRepairCard.Visible = False
            pnlPreRepair.Visible = False
            pnlError.Visible = False

            If Session("Report") = "PreRepair" Then
                LoadPreRepairReport()

            ElseIf Session("Report") = "PreRepairReportPreview" Then
                LoadPreRepairReport()

            ElseIf Session("Page") = "RepairCard" Then
                LoadRepairCardReport()

            ElseIf Session("report") = "RepairCard" Then
                LoadRepairCardReport()

            Else
                ' No valid report type - show maintenance image
                ShowError("Report type not configured.")
            End If

        Catch ex As Exception
            ' Show maintenance image with error
            ShowError(ex.Message)
        End Try
    End Sub

    Private Sub LoadPreRepairReport()
        Try
            Me.PreRepairReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.PreRepairReports.Attributes.Clear()

            Me.Crystalreportsource2.Report.FileName = "rpt_PreRepairInspection.rpt"
            Me.Crystalreportsource2.ReportDocument.Refresh()

            Me.PreRepairReports.ReportSource = Me.Crystalreportsource2
            Me.Crystalreportsource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@repair_hdr_id", Session("repair_hdr_id"))

            ' Show the report panel
            pnlPreRepair.Visible = True

        Catch ex As Exception
            ShowError("Error loading Pre-Repair Report: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadRepairCardReport()
        Try
            Me.RepairCard.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.RepairCard.Attributes.Clear()

            Me.Crystalreportsource1.Report.FileName = "rpt_RepairCard.rpt"
            Me.Crystalreportsource1.ReportDocument.Refresh()

            Me.RepairCard.ReportSource = Me.Crystalreportsource1
            Me.Crystalreportsource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@PropertyDetai_ID", Session("PropertyDetai_ID"))

            ' Show the report panel
            pnlRepairCard.Visible = True

        Catch ex As Exception
            ShowError("Error loading Repair Card Report: " & ex.Message)
        End Try
    End Sub

    Private Sub ShowError(ByVal errorMessage As String)
        ' Hide report panels
        pnlRepairCard.Visible = False
        pnlPreRepair.Visible = False

        ' Show error panel
        pnlError.Visible = True

        ' Optionally display error message for debugging
        lblErrorMessage.Text = errorMessage
        lblErrorMessage.Visible = False
    End Sub

    ' FIX FOR ZOOM/POSTBACK ISSUES - Add these event handlers
    Protected Sub PreRepairReports_OnLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles PreRepairReports.Load
        If Page.IsPostBack AndAlso pnlPreRepair.Visible AndAlso Session("repair_hdr_id") IsNot Nothing Then
            Me.PreRepairReports.ReportSource = Me.Crystalreportsource2
            Me.Crystalreportsource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@repair_hdr_id", Session("repair_hdr_id"))
        End If
    End Sub

    Protected Sub RepairCard_OnLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles RepairCard.Load
        If Page.IsPostBack AndAlso pnlRepairCard.Visible AndAlso Session("PropertyDetai_ID") IsNot Nothing Then
            Me.RepairCard.ReportSource = Me.Crystalreportsource1
            Me.Crystalreportsource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource1.ReportDocument.SetParameterValue("@PropertyDetai_ID", Session("PropertyDetai_ID"))
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