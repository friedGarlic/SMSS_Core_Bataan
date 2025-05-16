
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class bidding_rpt_AlternativeMode
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt_AMP As New ReportDocument
    Dim rpt_BAC As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Report") = "AMP" Then
            'Me.CrystalReportSource1.Report.FileName = "rpt_AlternativeMode.rpt"
            'Me.AlternativeModeReports.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@obr_evaluation_hdr_id", Session("obr_evaluation_hdr_id"))

            rpt_AMP.FileName = Server.MapPath("rpt_AlternativeMode.rpt")
            rpt_AMP.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt_AMP.SetParameterValue(0, Me.Session("obr_evaluation_hdr_id"))
            Me.AlternativeModeReports.ReportSource = rpt_AMP

        ElseIf Session("Report") = "BACResolution" Then
            'Me.CrystalReportSource1.Report.FileName = "rpt_BACResolution_Agency.rpt"
            'Me.AlternativeModeReports.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@PRHdr_ID", Session("prhdr_id"))

            rpt_BAC.FileName = Server.MapPath("rpt_BACResolution_Agency.rpt")
            rpt_BAC.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt_BAC.SetParameterValue(0, Me.Session("prhdr_id"))
            Me.AlternativeModeReports.ReportSource = rpt_BAC
        End If

    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt_AMP.Close()
        rpt_AMP.Dispose()

        rpt_BAC.Close()
        rpt_BAC.Dispose()

    End Sub

    Protected Sub lnkBtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBtnBack.Click
        If Session("Page") = "OBR_Eval" Then
            Me.Page.Response.Redirect("~/bidding/t_obr_evaluation.aspx")
        Else
            Me.Page.Response.Redirect("~/Reports and Query/t_AlternativeMode.aspx")
        End If
    End Sub

    Private Sub bidding_rpt_AlternativeMode_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False



    End Sub
End Class
