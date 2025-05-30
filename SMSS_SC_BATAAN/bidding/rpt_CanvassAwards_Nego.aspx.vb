Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Partial Class bidding_rpt_CanvassAwards_Nego
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Award") = "NOA" Then

            rpt.FileName = Server.MapPath("rpt_Canvass_NOA_PR.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue(0, Me.Session("Hdr_ID"))
            rpt.SetParameterValue(1, Me.Session("prhdr_id"))
            rpt.SetParameterValue(2, Me.Session("Supplier_ID"))
            Me.CrystalReportViewer1.ReportSource = rpt
        ElseIf Session("Award") = "RRA" Then

            AddTrace(Me.Session("Hdr_ID"))
            AddTrace(Me.Session("prhdr_id"))
            rpt.FileName = Server.MapPath("rpt_Canvass_Resolution_PR.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rpt.SetParameterValue(0, Me.Session("prhdr_id"))
            rpt.SetParameterValue(1, Me.Session("Hdr_ID"))

            Me.CrystalReportViewer1.ReportSource = rpt


        ElseIf Session("Award") = "NTP" Then

            rpt.FileName = Server.MapPath("rpt_Canvass_Resolution.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            AddTrace("Hdr_ID: " & Me.Session("Hdr_ID"))
            AddTrace("prhdr_id: " & Me.Session("prhdr_id"))

            rpt.SetParameterValue(0, Me.Session("Hdr_ID"))
            rpt.SetParameterValue(1, Me.Session("prhdr_id"))

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

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub

    Protected Sub lnkBtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBtnBack.Click
        If Session("Page") = "BID" Then
            Me.Page.Response.Redirect("~/bidding/t_contact_award_nego.aspx")
        End If
    End Sub

    Private Sub bidding_rpt_CanvassAwards_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

End Class
