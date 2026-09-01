Imports System.Data
Partial Class rpt_purchase_request_gasoline
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim msg As New MsgeBox
#Region "Property"
    Private Property p_datasummary() As DataTable
        Get
            Return CType(Session("p_datasummary"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("p_datasummary") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'p_datasummary = objDerived.GetDataTable("select rc_name,total,isVarious,pr_period_key_id,rc_id,function_id,OBR_Hdr_ID from ams.vw_pr_gasoline_summary_report  where pr_period_key_id='" & Me.Session("pr_period_key_id") & "'", CommandType.Text)
            p_datasummary = objDerived.GetDataTable("select rc_name,total,isVarious,pr_period_key_id,rc_id,function_id,OBR_Hdr_ID from dbo.view_pr_gasoline_summary_report  where pr_period_key_id='" & Me.Session("pr_period_key_id") & "'", CommandType.Text)
            gvSummary.DataSource = p_datasummary
            gvSummary.DataBind()

            If p_datasummary.Rows.Count >= 1 Then
                gvSummary.FooterRow.Cells(1).Text = FormatNumber(p_datasummary.Compute("sum(total)", ""), 2)
            End If
            gvSummary.SelectedIndex = 0

        End If


        If gvSummary.Rows.Count = 0 Then

        Else
            report()
        End If
    End Sub
    Public Sub Report1()
        'Me.CrystalReportViewer1.RefreshReport()
        'CrystalReportSource1.Report.FileName = "rpt_purchase_request_gasoline.rpt"
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Me.Session("pr_period_key_id"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(1, gvSummary.SelectedDataKey(2))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(2, gvSummary.SelectedDataKey(3))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(3, gvSummary.SelectedDataKey(0))

    End Sub
    Public Sub Report2()
        ' Me.CrystalReportViewer2.RefreshReport()
        'CrystalReportSource2.Report.FileName = "OBRReport_gasoline.rpt"
        Me.CrystalReportViewer2.ReportSource = Me.CrystalReportSource2
        Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource2.ReportDocument.SetParameterValue(0, gvSummary.SelectedDataKey(4))
        Me.CrystalReportSource2.ReportDocument.SetParameterValue(1, Me.Session("pr_period_key_id"))
        Me.CrystalReportSource2.ReportDocument.SetParameterValue(2, gvSummary.SelectedDataKey(0))

    End Sub
    Public Sub Report3()
        'Me.CrystalReportViewer3.RefreshReport()
        'CrystalReportSource3.Report.FileName = "rpt_purchase_request_gasoline_summaryrpt.rpt"
        Me.CrystalReportViewer3.ReportSource = Me.CrystalReportSource3
        Me.CrystalReportSource3.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource3.ReportDocument.SetParameterValue(0, Me.Session("pr_period_key_id"))

    End Sub
    Public Sub Report4()
        'Me.CrystalReportViewer4.RefreshReport()
        'CrystalReportSource4.Report.FileName = "rpt_purchase_request_gasoline_detailed.rpt"
        Me.CrystalReportViewer4.ReportSource = Me.CrystalReportSource4
        Me.CrystalReportSource4.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource4.ReportDocument.SetParameterValue(0, Me.Session("pr_period_key_id"))

    End Sub

    Public Sub report()
        Try
            If RadioButtonList1.SelectedIndex = 0 Then

                Report4()
                Report3()
                Report2()
                Report1()


                Me.CrystalReportViewer2.Visible = False
                Me.CrystalReportViewer3.Visible = False
                Me.CrystalReportViewer4.Visible = False
                Me.CrystalReportViewer1.Visible = True
            ElseIf RadioButtonList1.SelectedIndex = 1 Then
                Report4()
                Report3()
                Report1()
                Report2()
                Me.CrystalReportViewer1.Visible = False
                Me.CrystalReportViewer3.Visible = False
                Me.CrystalReportViewer4.Visible = False
                Me.CrystalReportViewer2.Visible = True

            ElseIf RadioButtonList1.SelectedIndex = 2 Then

                Report4()
                Report2()
                Report1()
                Report3()
                Me.CrystalReportViewer1.Visible = False
                Me.CrystalReportViewer2.Visible = False
                Me.CrystalReportViewer4.Visible = False
                Me.CrystalReportViewer3.Visible = True
            ElseIf RadioButtonList1.SelectedIndex = 3 Then
                Report3()
                Report2()
                Report1()
                Report4()

                Me.CrystalReportViewer1.Visible = False
                Me.CrystalReportViewer2.Visible = False
                Me.CrystalReportViewer3.Visible = False
                Me.CrystalReportViewer4.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/procurement/t_purchase_request_gasoline.aspx")

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        report()
    End Sub
    Protected Sub gvSummary_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvSummary.SelectedIndexChanged
        Try
            report()
        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub

End Class
