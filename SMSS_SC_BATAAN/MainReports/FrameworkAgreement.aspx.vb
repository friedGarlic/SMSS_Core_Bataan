Imports System.Data
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class MainReports_FrameworkAgreement
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument
    Private Sub MainReports_FrameworkAgreement_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.FrameWorkAgreement.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        'Me.FrameWorkAgreement.ReportSource = Me.Crystalreportsource1
        'Me.Crystalreportsource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        'Me.Crystalreportsource1.ReportDocument.SetParameterValue("@ITB_Hdr_ID", Session("ITB_Hdr_ID"))



        rpt.FileName = Server.MapPath("rpt_FrameworkAgreement2.rpt")        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)        rpt.SetParameterValue(0, Me.Session("ITB_Hdr_ID"))        Me.FrameWorkAgreement.ReportSource = rpt

    End Sub
    Protected Sub MainReports_FrameworkAgreement_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload        rpt.Close()        rpt.Dispose()    End Sub
    Private Sub MainReports_FrameworkAgreement_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub
End Class
