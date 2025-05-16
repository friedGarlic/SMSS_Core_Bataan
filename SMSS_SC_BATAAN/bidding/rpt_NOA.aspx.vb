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
Imports CrystalDecisions.CrystalReports.Engine


Partial Class bidding_rpt_NOA
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private objDerived2 As New DerivedDal
    Dim rpt As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("pre_procurement_hdr_id"))
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue(1, Session("Supplier_Id"))

        rpt.FileName = Server.MapPath("rpt_notice_of_award.rpt")
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue(0, Me.Session("pre_procurement_hdr_id"))
        rpt.SetParameterValue(1, Me.Session("Supplier_Id"))
        Me.CrystalReportViewer1.ReportSource = rpt

    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub
End Class
