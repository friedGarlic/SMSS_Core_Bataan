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
                'rbFormat.SelectedValue = 2

                rbFormat.Items(0).Enabled = True    ' Enaable value 0
                rbFormat.Items(1).Enabled = False   ' Disable value 1
                rbFormat.Items(3).Enabled = False   ' Disable value 3
                rbFormat.Items(2).Enabled = True    ' Enable value 2
                rbFormat.Items(4).Enabled = True    ' Enable value 4
                LoadRbChoice()
            Case "five"
                'rbFormat.SelectedValue = 1

                rbFormat.Items(0).Enabled = True    ' Enaable value 0
                rbFormat.Items(1).Enabled = True    ' Enable value 1
                rbFormat.Items(3).Enabled = True    ' Enable value 3
                rbFormat.Items(2).Enabled = False   ' Disable value 2
                rbFormat.Items(4).Enabled = False   ' Disable value 4
                LoadRbChoice()
        End Select


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

        Select Case Session("BAC Members")
            Case "seven"
                If rbFormat.SelectedItem.Value = 2 Then
                    Me.CrystalReportSource1.Report.FileName = "rpt_app_GPPB_LGU_v4.rpt"
                    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource1
                    Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("year"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                ElseIf rbFormat.SelectedItem.Value = 4 Then
                    Me.CrystalReportSource2.Report.FileName = "app_cagayan_nonCSE_Updated_v2.rpt"
                    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource2
                    Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@CYear", Session("year"))
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                End If
            Case "five"
                If rbFormat.SelectedItem.Value = 1 Then
                    Me.CrystalReportSource1.Report.FileName = "rpt_app_GPPB_LGU.rpt"
                    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource1
                    Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("year"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                ElseIf rbFormat.SelectedItem.Value = 3 Then
                    Me.CrystalReportSource2.Report.FileName = "app_cagayan_nonCSE_Updated.rpt"
                    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource2
                    Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@CYear", Session("year"))
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                    Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                End If
        End Select
    End Sub
End Class
