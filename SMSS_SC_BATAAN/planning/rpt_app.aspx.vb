Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Partial Class rpt_app
    Inherits Page
    Private objDerived As New connectionreport
    Dim obj As New BaseClasses.DBPassUsernname


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Session("view") = "0"
        Select Case Session("BAC Members")
            Case "seven"
                If Not IsPostBack Then
                    rbFormat.SelectedValue = 4
                End If
                rbFormat.Items(0).Enabled = True    ' Enaable value 0
                rbFormat.Items(1).Enabled = False   ' Disable value 1
                rbFormat.Items(3).Enabled = False   ' Disable value 3
                rbFormat.Items(2).Enabled = True    ' Enable value 2
                rbFormat.Items(4).Enabled = True    ' Enable value 4

            Case "five"
                If Not IsPostBack Then
                    rbFormat.SelectedValue = 3
                End If
                rbFormat.Items(0).Enabled = True    ' Enaable value 0
                rbFormat.Items(1).Enabled = True    ' Enable value 1
                rbFormat.Items(3).Enabled = True    ' Enable value 3
                rbFormat.Items(2).Enabled = False   ' Disable value 2
                rbFormat.Items(4).Enabled = False   ' Disable value 4

        End Select
        LoadRbChoice()

    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "Planning" Then
            Me.Page.Response.Redirect("~/Planning/t_annual_procurement_plan.aspx")
        ElseIf Session("Page") = "RQ" Then
            Me.Page.Response.Redirect("~/Planning/APPreports.aspx")
        End If
    End Sub

    Protected Sub rbFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbFormat.SelectedIndexChanged
        LoadRbChoice()
    End Sub

    Protected Sub LoadRbChoice()
        'If rbFormat.SelectedItem.Value = 1 Then
        '    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource1
        '    Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("year"))
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
        '    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))


        'ElseIf rbFormat.SelectedItem.Value = 2 Then
        '    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource2
        '    Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        '    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@CYear", Session("year"))
        '    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
        '    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))

        'ElseIf rbFormat.SelectedItem.Value = 3 Then
        '    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource3
        '    Me.CrystalReportSource3.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        '    Me.CrystalReportSource3.ReportDocument.SetParameterValue("@CYear", Session("year"))
        '    Me.CrystalReportSource3.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
        '    Me.CrystalReportSource3.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))

        'ElseIf rbFormat.SelectedItem.Value = 4 Then
        '    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource4
        '    Me.CrystalReportSource4.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        '    Me.CrystalReportSource4.ReportDocument.SetParameterValue("@CYear", Session("year"))
        '    Me.CrystalReportSource4.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
        '    Me.CrystalReportSource4.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))

        'End If
        Me.CrystalReportViewer3.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

        Me.CrystalReportViewer3.ReportSource = Nothing ' clear old report

        Select Case Session("BAC Members")
            Case "seven"
                If rbFormat.SelectedItem.Value = 2 Then
                    Me.CrystalReportSource1.Report.FileName = "rpt_app_GPPB_LGU_v6.rpt"
                    Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("year"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource1
                ElseIf rbFormat.SelectedItem.Value = 4 Then
                    Me.CrystalReportSource2.Report.FileName = "app_cagayan_nonCSE_Updated_v4.rpt"
                    Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@CYear", Session("year"))
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource2
                End If
            Case "five"
                If rbFormat.SelectedItem.Value = 1 Then
                    Me.CrystalReportSource1.Report.FileName = "rpt_app_GPPB_LGU_v5.rpt"
                    Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("year"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource1
                ElseIf rbFormat.SelectedItem.Value = 3 Then
                    Me.CrystalReportSource2.Report.FileName = "app_cagayan_nonCSE_Updated_v3.rpt"
                    Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@CYear", Session("year"))
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource2
                End If
        End Select
    End Sub
End Class
