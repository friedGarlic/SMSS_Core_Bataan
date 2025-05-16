Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Reports_and_Query_t_rpt_receiving
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        rpt.FileName = Server.MapPath("rpt_receiving.rpt")
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue("@Received_ID", Me.Session("Received_ID"))
        Me.CrystalReportViewer1.ReportSource = rpt

    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "Rcv" Then
            Me.Page.Response.Redirect("~/procurement/t_Inspection_Acceptance.aspx")
        ElseIf Session("Page") = "PPE" Then
            Me.Page.Response.Redirect("~/Inventory/t_inventory_encoding.aspx")
        ElseIf Session("Page") = "Supplies" Then
            Me.Page.Response.Redirect("~/Inventory/t_encoding_supplies.aspx")
        ElseIf Session("Page") = "RQ" Then
            Me.Page.Response.Redirect("~/Procurement/t_receivingR.aspx")
        ElseIf Session("Page") = "Donation" Then
            Me.Page.Response.Redirect("~/Inventory/t_inventory_Donation.aspx")
        End If

    End Sub

    Private Sub Reports_and_Query_t_rpt_receiving_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub
End Class
