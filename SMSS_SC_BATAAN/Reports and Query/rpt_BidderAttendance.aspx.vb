
Partial Class Inventory_Disposal_rpt_BidderAttendance
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub
    Private Sub Inventory_Disposal_rpt_BidderAttendance_Init(sender As Object, e As EventArgs) Handles Me.Init
        LoadReport()
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_ISSP_List.aspx")

    End Sub

    Private Sub Inventory_Disposal_rpt_BidderAttendance_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Session("Copies") = txtCopies.Text
        Session("Price") = txtPrice.Text
        LoadReport()
    End Sub

    Protected Sub LoadReport()
        Me.BidderReport.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        Me.BidderReport.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Copies", Session("Copies"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Price", Session("Price"))
    End Sub


End Class
