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

Partial Class bidding_t_rpt_BACResolution
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private objDerived2 As New DerivedDal


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@pre_procurement_hdr_id", Session("pre_procurement_hdr_id"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Supplier_ID", Session("Supplier_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@TotalBidAmount", Session("TotalBidAmount"))
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Reports and Query/t_BACResolution.aspx")
    End Sub
End Class
