Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class bidding_rpt_CanvassAwards
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Award") = "NOA" Then

            'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Hdr_ID", Session("Hdr_ID"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Supplier_Id", Session("Supplier_ID"))

            rpt.FileName = Server.MapPath("rpt_Canvass_NOA.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue(0, Me.Session("Hdr_ID"))
            AddTrace("Session('Hdr_ID'): " & Session("Hdr_ID"))

            rpt.SetParameterValue(1, Me.Session("prhdr_id"))
            AddTrace("Session('prhdr_id'): " & Session("prhdr_id"))

            rpt.SetParameterValue(2, Me.Session("Supplier_ID"))
            Me.CrystalReportViewer1.ReportSource = rpt

        Else

            'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource2
            'Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Hdr_ID", Session("Hdr_ID"))
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))

            rpt.FileName = Server.MapPath("rpt_Canvass_Resolution_v2.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue(0, Me.Session("Hdr_ID"))
            AddTrace("Session('Hdr_ID'): " & Session("Hdr_ID"))
            rpt.SetParameterValue(1, Me.Session("prhdr_id"))
            AddTrace("Session('prhdr_id'): " & Session("prhdr_id"))
            Me.CrystalReportViewer1.ReportSource = rpt
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub

    Protected Sub lnkBtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBtnBack.Click
        If Session("Page") = "BID" Then
            Me.Page.Response.Redirect("~/bidding/t_CanvassAwards.aspx")

        ElseIf Session("Page") = "Direct" Then
            Me.Page.Response.Redirect("~/bidding/t_Award_of_Contract_Direct.aspx")
        Else
            Me.Page.Response.Redirect("~/Reports and Query/RQ_CanvassAwards.aspx")
        End If
    End Sub

    Private Sub bidding_rpt_CanvassAwards_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

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
