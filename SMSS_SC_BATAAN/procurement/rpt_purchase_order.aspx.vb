Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class rpt_purchase_order
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        load_report()

        Me.Session("view") = "1"

    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()

    End Sub
    Public Sub load_report()
        Try

            If Session("POHdr_ID") Is Nothing OrElse String.IsNullOrEmpty(Session("POHdr_ID").ToString()) Then
                Response.Write("Error: POHdr_ID is missing.")
                Exit Sub
            End If
            Dim reportPath As String = Server.MapPath("rpt_purchase_order_Short.rpt")
            If Not System.IO.File.Exists(reportPath) Then
                Response.Write("Error: Report file not found at " & reportPath)
                Exit Sub
            End If

            If drpPaperSize.SelectedItem.Value = 1 Then

                'Me.CrystalReportSource1.Report.FileName = "rpt_purchase_order_Short.rpt"
                'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
                'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("POHdr_ID"))

                rpt.Load(Server.MapPath("rpt_purchase_order_Short.rpt"))
                rpt.FileName = Server.MapPath("rpt_purchase_order_Short.rpt")
                rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rpt.SetParameterValue(0, Me.Session("POHdr_ID"))
                Me.CrystalReportViewer1.ReportSource = rpt
            ElseIf drpPaperSize.SelectedItem.Value = 2 Then

                'Me.CrystalReportSource1.Report.FileName = "rpt_purchase_order_Long.rpt"
                'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
                'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("POHdr_ID"))

                rpt.Load(Server.MapPath("rpt_purchase_order_Long.rpt"))
                rpt.FileName = Server.MapPath("rpt_purchase_order_Long.rpt")
                rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rpt.SetParameterValue(0, Me.Session("POHdr_ID"))
                Me.CrystalReportViewer1.ReportSource = rpt
            End If

        Catch ex As Exception
            Response.Write("Error loading Crystal Report: " & ex.Message)
        End Try


    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "PO" Then
            Me.Page.Response.Redirect("~/procurement/t_Purchase_Order.aspx")
        ElseIf Session("Page") = "RQ" Then
            Me.Page.Response.Redirect("~/Procurement/t_List_of_Approved_PO.aspx")
        End If

    End Sub

    Protected Sub rdPRFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPRFormat.SelectedIndexChanged
        If rdPRFormat.SelectedItem.Value = 1 Then
            CrystalReportSource1.Report.FileName = "rpt_purchase_order.rpt"
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("POHdr_ID"))

        ElseIf rdPRFormat.SelectedItem.Value = 2 Then
            CrystalReportSource1.Report.FileName = "rpt_purchase_order_v2.rpt"
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("POHdr_ID"))
        End If
    End Sub

    Protected Sub drpPaperSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpPaperSize.SelectedIndexChanged
        load_report()
    End Sub

    Private Sub rpt_purchase_order_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub
End Class
