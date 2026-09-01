Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO

Partial Class bidding_rpt_resulotion_recommending_award
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim obj As New AccessRule
    Private objDerived2 As New DerivedDal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportSource1.Report.FileName = "rpt_BACResolution.rpt"
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@pre_procurement_hdr_id", Session("pre_procurement_hdr_id"))
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/bidding/t_notice_of_award.aspx")
    End Sub

End Class
