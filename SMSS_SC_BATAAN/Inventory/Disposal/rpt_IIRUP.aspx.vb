Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Inventory_Disposal_rpt_IIRUP
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.Disposal_Reports.ReportSource = Me.CrystalReportSource1
        'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Me.Session("TransID"))

        loadReport()
    End Sub
    Public Sub loadReport()
        'objDAL.conStr = objDerived.DbaseConnect()
        rpt.FileName = Server.MapPath("IIRUP.rpt")
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue(0, Me.Session("TransID"))
        Me.Disposal_Reports.ReportSource = rpt
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub


    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Dim a As String
        Me.Page.Response.Redirect("~/Reports and Query/DisposalReports.aspx")
    End Sub
End Class
