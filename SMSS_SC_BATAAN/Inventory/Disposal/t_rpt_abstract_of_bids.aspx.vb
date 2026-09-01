
Partial Class t_rpt_abstract_of_bids
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub t_rpt_abstract_of_bids_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Session("Page") = "ISSP_List" Then
            Me.AbstractReport_template.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.AbstractReport_template.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))

        ElseIf Session("Page") = "Abstract" Then
            Me.AbstractReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.AbstractReports.ReportSource = Me.CrystalReportSource4
            Me.CrystalReportSource4.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource4.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))

        Else

        End If



    End Sub
    Private Sub t_rpt_abstract_of_bids_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        If Session("Page") = "ISSP_List" Then

            AbstractReport_template.RefreshReport()
            AbstractReport_template.ReportSource = Nothing


            Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_ISSP_List.aspx")
        Else
            Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_Abstract.aspx")
        End If


    End Sub


End Class
