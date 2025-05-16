Imports System
Imports System.Data


Partial Class Inventory_Disposal_rpt_ISSP
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Page") = "RQ" Then
            lnkBack.Visible = True
        Else
            lnkBack.Visible = False
        End If

    End Sub
    Private Sub Inventory_Disposal_rpt_ISSP_Init(sender As Object, e As EventArgs) Handles Me.Init
        Me.ISSPReport.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        Me.ISSPReport.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        Me.Page.Response.Redirect("~/Reports and Query/DisposalReports.aspx")
    End Sub

    Private Sub Inventory_Disposal_rpt_ISSP_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub
End Class
