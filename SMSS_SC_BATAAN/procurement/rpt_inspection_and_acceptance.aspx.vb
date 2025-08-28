
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
        rpt.SetParameterValue("@Received_ID", Session("Received_ID"))
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
            AddTrace("Report file path: rpt_Inspection_Acceptance.rpt")

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            AddTrace("Set database login with user: " & objDerived.username)

            rpt.SetParameterValue("@POHdr_ID", Session("POHdr_ID"))
            rpt.SetParameterValue("@Received_ID", Session("Received_ID"))
            rpt.SetParameterValue("@AcceptingPerson", Session("AcceptingPerson"))
            rpt.SetParameterValue("@AcceptingPersonPos", Session("AcceptingPosition"))
            rpt.SetParameterValue("@IsPartial", Session("IsPartial"))
            rpt.SetParameterValue("@IsComplete", Session("IsComplete"))
            rpt.SetParameterValue("@IsInspected", Session("IsInspected"))
            rpt.SetParameterValue("@IsAcceptedDate", Session("AcceptedDate"))

            ' Trace complete procedure call with values
            AddTrace("[AMS].[sp_rpt_InspectionAcceptance_Dtl] " & Session("POHdr_ID") & ", " & Session("Received_ID") & ", '" & Session("AcceptingPerson") & "', '" & Session("AcceptingPosition") & "', '" & Session("IsPartial") & "', '" & Session("IsComplete") & "', '" & Session("IsInspected") & "', '" & Session("AcceptedDate") & "'")

            Me.CrystalReportViewer1.ReportSource = rpt

        Else
            '==== Format (Long) ====
            rpt.FileName = Server.MapPath("rpt_Inspection_Acceptance_Long.rpt")
            AddTrace("Report file path: rpt_Inspection_Acceptance_Long.rpt")

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            AddTrace("Set database login with user: " & objDerived.username)

            rpt.SetParameterValue("@POHdr_ID", Session("POHdr_ID"))
            rpt.SetParameterValue("@Received_ID", Session("Received_ID"))
            rpt.SetParameterValue("@AcceptingPerson", Session("AcceptingPerson"))
            rpt.SetParameterValue("@AcceptingPersonPos", Session("AcceptingPosition"))
            rpt.SetParameterValue("@IsPartial", Session("IsPartial"))
            rpt.SetParameterValue("@IsComplete", Session("IsComplete"))
            rpt.SetParameterValue("@IsInspected", Session("IsInspected"))
            rpt.SetParameterValue("@IsAcceptedDate", Session("AcceptedDate"))

            ' Trace complete procedure call with values
            AddTrace("[AMS].[sp_rpt_InspectionAcceptance_Dtl] " & Session("POHdr_ID") & ", " & Session("Received_ID") & ", '" & Session("AcceptingPerson") & "', '" & Session("AcceptingPosition") & "', '" & Session("IsPartial") & "', '" & Session("IsComplete") & "', '" & Session("IsInspected") & "', '" & Session("AcceptedDate") & "'")

            Me.CrystalReportViewer1.ReportSource = rpt
        End If
    End Sub



    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub



End Class
