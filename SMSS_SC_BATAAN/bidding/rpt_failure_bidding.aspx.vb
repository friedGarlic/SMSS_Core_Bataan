Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_rpt_failure_bidding
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("pre_procurement_hdr_id").ToString)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(1, Session("isPublicInfra"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(2, Session("ResolutionNumber").ToString)
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/bidding/t_bid_opening.aspx")
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        objDerived.GetRecords("Delete  from  AMS.pre_procurement where pre_procurement_hdr_id =  " & Session("pre_procurement_hdr_id") & "", CommandType.Text)
        objDerived.GetRecords("Delete  from  AMS.pre_procurement_dtl where pre_procurement_hdr_id =  " & Session("pre_procurement_hdr_id") & "", CommandType.Text)
        objDerived.GetRecords("Update AMS.obr_evaluation_dtl set withPreProcurement=0 where obr_evaluation_hdr_id =  " & Session("Evaluation_Hdr") & "", CommandType.Text)
    End Sub
End Class
