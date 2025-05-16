
Partial Class Reports_and_Query_rpt_RreportViewer
    Inherits System.Web.UI.Page
    Private objDerived_rpt As New connectionreport


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Report") = "HexProperty" Then
            lblRptTitle.Text = "LIST OF PROPERTY NUMBER BY HEX"
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived_rpt.username, objDerived_rpt.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Year", Session("YEAR"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
            Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        Else

        End If

    End Sub

    Protected Sub lnkBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBack.Click
        If Session("Report") = "HexProperty" Then
            Me.Page.Response.Redirect("~/Reports and Query/rpt_ListPropertyNo.aspx")
        Else

        End If
    End Sub

    Private Sub Reports_and_Query_rpt_RreportViewer_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub
End Class
