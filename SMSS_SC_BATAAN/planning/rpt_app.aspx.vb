Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class rpt_app
    Inherits Page

    Private objDerived As New connectionreport
    Dim obj As New BaseClasses.DBPassUsernname

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        If Not IsPostBack Then
            ' Set up dropdowns and initial settings
            Session("view") = "0"
            Select Case Session("BAC Members")
                Case "seven"
                    rbFormat.SelectedValue = "4"
                    rbFormat.Items(0).Enabled = True
                    rbFormat.Items(1).Enabled = False
                    rbFormat.Items(3).Enabled = False
                    rbFormat.Items(2).Enabled = True
                    rbFormat.Items(4).Enabled = True
                Case "five"
                    rbFormat.SelectedValue = "3"
                    rbFormat.Items(0).Enabled = True
                    rbFormat.Items(1).Enabled = True
                    rbFormat.Items(3).Enabled = True
                    rbFormat.Items(2).Enabled = False
                    rbFormat.Items(4).Enabled = False
            End Select

            ' Load fresh report and save it in Session
            LoadRbChoice()
        Else
            ' For postbacks (paging, drilldown), reuse report from Session
            If Session("ReportDoc") IsNot Nothing Then
                Dim rptDoc As ReportDocument = CType(Session("ReportDoc"), ReportDocument)
                rptDoc.SetDatabaseLogon(objDerived.username, objDerived.Password)

                ' Reapply parameters on every postback
                rptDoc.SetParameterValue("@CYear", Session("year"))
                rptDoc.SetParameterValue("@isContinuing", Session("isContinuing"))
                rptDoc.SetParameterValue("@isSupplemental", Session("isSupplemental"))

                CrystalReportViewer.ReportSource = rptDoc
                CrystalReportViewer.DataBind()
            End If
        End If
    End Sub

    Protected Sub rbFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbFormat.SelectedIndexChanged
        ClearCachedReport()
        LoadRbChoice()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "Planning" Then
            Response.Redirect("~/Planning/t_annual_procurement_plan.aspx")
        ElseIf Session("Page") = "RQ" Then
            Response.Redirect("~/Planning/APPreports.aspx")
        End If
    End Sub

    Private Sub LoadRbChoice()
        Dim reportPath As String = ""
        Dim reportDoc As New ReportDocument()

        Select Case Session("BAC Members").ToString().ToLower()
            Case "seven"
                If rbFormat.SelectedItem.Value = "2" Then
                    reportPath = Server.MapPath("~/planning/rpt_app_GPPB_LGU_v6.rpt")
                ElseIf rbFormat.SelectedItem.Value = "4" Then
                    reportPath = Server.MapPath("~/planning/app_cagayan_nonCSE_Updated_v4.rpt")
                End If
            Case "five"
                If rbFormat.SelectedItem.Value = "1" Then
                    reportPath = Server.MapPath("~/planning/rpt_app_GPPB_LGU_v5.rpt")
                ElseIf rbFormat.SelectedItem.Value = "3" Then
                    reportPath = Server.MapPath("~/planning/app_cagayan_nonCSE_Updated_v3.rpt")
                End If
        End Select

        If reportPath = "" Then Exit Sub

        reportDoc.Load(reportPath)
        reportDoc.SetDatabaseLogon(objDerived.username, objDerived.Password)

        ' Set parameters
        reportDoc.SetParameterValue("@CYear", Session("year"))
        reportDoc.SetParameterValue("@isContinuing", Session("isContinuing"))
        reportDoc.SetParameterValue("@isSupplemental", Session("isSupplemental"))

        CrystalReportViewer.ReportSource = reportDoc
        CrystalReportViewer.DataBind()

        ' Save report instance in Session for reuse on postbacks
        Session("ReportDoc") = reportDoc
    End Sub

    Private Sub ClearCachedReport()
        If Session("ReportDoc") IsNot Nothing Then
            Dim rptDoc As ReportDocument = CType(Session("ReportDoc"), ReportDocument)
            rptDoc.Close()
            rptDoc.Dispose()
            Session("ReportDoc") = Nothing
        End If
    End Sub

    'Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
    '    ' Dispose report on unload to release resources
    '    If Session("ReportDoc") IsNot Nothing Then
    '        Dim rptDoc As ReportDocument = CType(Session("ReportDoc"), ReportDocument)
    '        rptDoc.Close()
    '        rptDoc.Dispose()
    '        Session("ReportDoc") = Nothing
    '    End If
    'End Sub


End Class
