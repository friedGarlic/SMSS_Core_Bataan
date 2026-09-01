
Partial Class rpt_ppmp
    Inherits System.Web.UI.Page
    Private objDerived As New BaseClasses.DBPassUsernname
    Dim rc, year, function_id, GA_ID, project_id, program_id, BGA_ID As Integer
    Dim Previous, Current, Radio1, Radio2, isContinuing, isSupplemental As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.RadioButtonList3.Visible = False
        If Not Page.IsPostBack Then
            Me.RadioButtonList1.Visible = False
            'Me.RadioButtonList2.Items(0).Text = Session("ASPPName")
            'Me.RadioButtonList2.Items(1).Text = Session("ASPPNameWithbal")
            rc = Session("rc")
            year = Session("year")
            function_id = Session("Function_ID")
            GA_ID = Me.Session("GA_ID")
            project_id = Me.Session("Project_ID")
            program_id = Me.Session("Program_id")
            BGA_ID = Me.Session("BGA_ID")

            'added 06-072013
            If Me.RadioButtonList2.SelectedIndex = 0 Then
                Me.RadioButtonList3.Visible = False
                Me.RadioButtonList3.SelectedIndex = 1
                LoadReport2()
            Else
                Me.RadioButtonList3.Visible = False

                LoadReport2()
            End If

        Else
            If Me.RadioButtonList2.SelectedIndex = 0 Then
                Me.RadioButtonList3.Visible = False
            Else
                Me.RadioButtonList3.Visible = False
                rc = Session("rc")
                year = Session("year")
                function_id = Session("Function_ID")
                GA_ID = Me.Session("GA_ID")
                project_id = Me.Session("Project_ID")
                program_id = Me.Session("Program_id")
                BGA_ID = Me.Session("BGA_ID")
                LoadReport2()
            End If
            rc = Session("rc")
            year = Session("year")
            function_id = Session("Function_ID")
            GA_ID = Me.Session("GA_ID")
            project_id = Me.Session("Project_ID")
            program_id = Me.Session("Program_id")
            BGA_ID = Me.Session("BGA_ID")
            isContinuing = Me.Session("isContinuing")
            isSupplemental = Me.Session("isSupplemental")
            LoadReport2()
        End If

    End Sub

    Private Sub rpt_ppmp_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub
    Public Sub WithoutBAL()
        Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@rc_id", rc)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("year"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", function_id)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", GA_ID)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@BGA_ID", Session("BGA_ID"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Project_ID", project_id)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Program_ID", program_id)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prev", False)
    End Sub
    Public Sub withBal()
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource2
        Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource2.ReportDocument.SetParameterValue("@CYear", Session("year"))
        Me.CrystalReportSource2.ReportDocument.SetParameterValue("@rc_id", rc)
        Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Function_ID", function_id)
        Me.CrystalReportSource2.ReportDocument.SetParameterValue("@GA_ID", GA_ID)
        Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Project_ID", project_id)
        Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Program_ID", program_id)
        Me.CrystalReportSource2.ReportDocument.SetParameterValue("@BGA_ID", Session("BGA_ID"))
        Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
        Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
    End Sub
    Public Sub LoadReport2()
        Dim ClickConsolidatedView, ClickView As Integer
        ClickConsolidatedView = Session("ClickConsolidatedView")
        ClickView = Session("ClickView")

        If Me.RadioButtonList2.SelectedIndex = 0 Then

            If ClickConsolidatedView = 2 Then
                'Consolidated
                Me.CrystalReportViewer2.ReportSource = Me.CrystalReportSource3
                Me.CrystalReportSource3.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource3.ReportDocument.SetParameterValue("@rc_id", rc)
                Me.CrystalReportSource3.ReportDocument.SetParameterValue("@CYear", year)
                Me.CrystalReportSource3.ReportDocument.SetParameterValue("@Function_ID", function_id)
                Me.CrystalReportSource3.ReportDocument.SetParameterValue("@GA_ID", GA_ID)
                Me.CrystalReportSource3.ReportDocument.SetParameterValue("@BGA_ID", BGA_ID)
                Me.CrystalReportSource3.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                Me.CrystalReportSource3.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))

            Else

                'Normal with History Reports
                If Me.RadioButtonList3.SelectedIndex = 1 Then

                    '=-= already save
                    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource1
                    Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@rc_id", rc)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("year"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", function_id)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", GA_ID)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@BGA_ID", Session("BGA_ID"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Project_ID", project_id)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Program_ID", program_id)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prev", False)
                    withBal()
                Else
                    Dim prevYear
                    prevYear = Session("year")
                    Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource1
                    Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@rc_id", rc)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("year"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", function_id)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", GA_ID)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@BGA_ID", Session("BGA_ID"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Project_ID", project_id)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Program_ID", program_id)
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                    Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prev", True)


                End If
                'Old 05-30-2013
                'Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource1
                'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, rc)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue(1, year)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue(2, function_id)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue(3, GA_ID)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue(6, project_id)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue(7, program_id)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue(4, Session("BGA_ID"))
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue(5, Session("isContinuing"))
                'Old 05-30-2013
            End If



        Else


            If ClickConsolidatedView = 2 Then
                Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource4
                Me.CrystalReportSource4.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource4.ReportDocument.SetParameterValue("@rc_id", rc)
                Me.CrystalReportSource4.ReportDocument.SetParameterValue("@CYear", year)
                Me.CrystalReportSource4.ReportDocument.SetParameterValue("@Function_ID", function_id)
                Me.CrystalReportSource4.ReportDocument.SetParameterValue("@GA_ID", GA_ID)
                Me.CrystalReportSource4.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                Me.CrystalReportSource4.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                'Me.CrystalReportSource3.ReportDocument.SetParameterValue(5, BGA_ID)


            Else


                Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource2
                Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@CYear", Session("year"))
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@rc_id", rc)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Function_ID", function_id)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@GA_ID", GA_ID)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Project_ID", project_id)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Program_ID", program_id)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@BGA_ID", Session("BGA_ID"))
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
                WithoutBAL()

            End If


        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/planning/t_ppmp.aspx")

    End Sub


End Class
