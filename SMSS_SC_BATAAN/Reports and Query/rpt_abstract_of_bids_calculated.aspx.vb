Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Reports_and_Query_rpt_abstract_of_bids_calculated
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("isCalculated") = True Then
            'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@pre_procurement_hdr_id", Session("pre_procurement_hdr_id"))

            rpt.FileName = Server.MapPath("rpt_abstract_bids_bidding.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue("@pre_procurement_hdr_id", Me.Session("pre_procurement_hdr_id"))
            Me.CrystalReportViewer1.ReportSource = rpt

        Else
            'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource2
            'Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@pre_procurement_hdr_id", Session("pre_procurement_hdr_id"))


            rpt.FileName = Server.MapPath("rpt_abstract_bids_bidding_read.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue("@pre_procurement_hdr_id", Me.Session("pre_procurement_hdr_id"))
            Me.CrystalReportViewer1.ReportSource = rpt
        End If
   
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/bidding/t_abstract_of_bids.aspx")
    End Sub
End Class
