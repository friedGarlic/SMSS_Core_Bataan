Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data

Partial Class rpt_purchase_request
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private objDer As New DerivedDal
    Dim rpt_PR As New ReportDocument
    Dim rpt_AIR As New ReportDocument
    Dim rpt_PerLot As New ReportDocument



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Session("view") = "0"

        ' Convert database bit values to Boolean
        Dim isPerLot As Boolean = Convert.ToBoolean(objDer.GetValue("SELECT ISNULL(isPerLot, 0) FROM AMS.PR_Hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text))
        Dim isDBM As Boolean = Convert.ToBoolean(objDer.GetValue("SELECT ISNULL(isDBM, 0) FROM AMS.PR_Hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text))

        If isPerLot Then
            rpt_PerLot.FileName = Server.MapPath("~/MainReports/Procurement_PR_PerLot.rpt")
            rpt_PerLot.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt_PerLot.SetParameterValue(0, Session("prhdr_id"))
            CrystalReportViewer1.ReportSource = rpt_PerLot
        ElseIf Not isDBM Then
            'Dim reportFileName As String = If(rdPRFormat.SelectedItem.Value = 1,
            '                              "rpt_purchase_request.rpt",
            '                              "rpt_purchase_request_Short.rpt")

            Dim reportFileName As String = If(rdPRFormat.SelectedItem.Value = 1,
                                          "rpt_purchase_request.rpt",
                                          "rpt_purchase_request_Short.rpt")

            rpt_PR.FileName = Server.MapPath(reportFileName)
            rpt_PR.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt_PR.SetParameterValue(0, Session("prhdr_id"))
            CrystalReportViewer1.ReportSource = rpt_PR
        Else
            rpt_AIR.FileName = Server.MapPath("rpt_APR.rpt")
            rpt_AIR.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt_AIR.SetParameterValue(0, Me.Session("prhdr_id"))
            Me.CrystalReportViewer1.ReportSource = rpt_AIR
        End If
    End Sub


    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt_PR.Close()
        rpt_PR.Dispose()

        rpt_AIR.Close()
        rpt_AIR.Dispose()
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "RQ" Then
            Me.Page.Response.Redirect("~/Reports and Query/t_purchase_request.aspx")
        ElseIf Session("Page") = "CancelPR" Then
            Me.Page.Response.Redirect("~/procurement/t_Cancelled_PR.aspx")
        Else
            Me.Page.Response.Redirect("~/procurement/t_purchase_request_v2.aspx")
        End If

    End Sub

    Protected Sub rdPRFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPRFormat.SelectedIndexChanged
        If rdPRFormat.SelectedItem.Value = 1 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportViewer1.DisplayToolbar = True
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("prhdr_id"))

        ElseIf rdPRFormat.SelectedItem.Value = 2 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue(0, Session("prhdr_id"))
        End If
    End Sub

    Private Sub rpt_purchase_request_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False


    End Sub
End Class
