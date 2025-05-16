
Imports CrystalDecisions.CrystalReports.Engine

Partial Class rpt_inspection_and_acceptance
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Optionally update the session value if the query string is provided.
        If Not String.IsNullOrEmpty(Request.QueryString("POHdr_ID")) Then
            Session("POHdr_ID") = Request.QueryString("POHdr_ID")
        End If


        rpt.FileName = Server.MapPath("rpt_Inspection_Acceptance_Long.rpt")
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue("@POHdr_ID", Session("POHdr_ID"))
        rpt.SetParameterValue("@AcceptingPerson", Session("AcceptingPerson"))
        rpt.SetParameterValue("@AcceptingPersonPos", Session("AcceptingPosition"))
        rpt.SetParameterValue("@IsPartial", Session("IsPartial"))
        rpt.SetParameterValue("@IsComplete", Session("IsComplete"))
        rpt.SetParameterValue("@IsInspected", Session("IsInspected"))
        rpt.SetParameterValue("@IsAcceptedDate", Session("AcceptedDate"))
        '
        Me.CrystalReportViewer1.ReportSource = rpt

    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "AIR" Then
            Me.Page.Response.Redirect("~/Procurement/t_Inspection_Acceptance.aspx")
        Else
            Me.Page.Response.Redirect("~/Reports and Query/t_inspection_and_acceptance.aspx")
        End If
    End Sub


    Protected Sub rbFormatChoice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbFormatChoice.SelectedIndexChanged

        If rbFormatChoice.SelectedValue = 1 Then
            '==== Format (Short) ====
            rpt.FileName = Server.MapPath("rpt_Inspection_Acceptance.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue("@POHdr_ID", Session("POHdr_ID"))
            rpt.SetParameterValue("@AcceptingPerson", Session("AcceptingPerson"))
            rpt.SetParameterValue("@AcceptingPersonPos", Session("AcceptingPosition"))
            rpt.SetParameterValue("@IsPartial", Session("IsPartial"))
            rpt.SetParameterValue("@IsComplete", Session("IsComplete"))
            rpt.SetParameterValue("@IsInspected", Session("IsInspected"))
            rpt.SetParameterValue("@IsAcceptedDate", Session("AcceptedDate"))
            Me.CrystalReportViewer1.ReportSource = rpt
        Else
            '==== Format (Long) ====
            'TODO SAME MODIFICATION WITH LONG
            rpt.FileName = Server.MapPath("rpt_Inspection_Acceptance_Long.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue("@POHdr_ID", Session("POHdr_ID"))
            rpt.SetParameterValue("@AcceptingPerson", Session("AcceptingPerson"))
            rpt.SetParameterValue("@AcceptingPersonPos", Session("AcceptingPosition"))
            rpt.SetParameterValue("@IsPartial", Session("IsPartial"))
            rpt.SetParameterValue("@IsComplete", Session("IsComplete"))
            rpt.SetParameterValue("@IsInspected", Session("IsInspected"))
            rpt.SetParameterValue("@IsAcceptedDate", Session("AcceptedDate"))
            Me.CrystalReportViewer1.ReportSource = rpt
        End If
    End Sub
End Class
