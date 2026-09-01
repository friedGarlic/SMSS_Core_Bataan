
Partial Class Reports_and_Query_rpt_APP_dept
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim DBPassUsernname As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Format") = "GPPB" Then
            rbFormat.Visible = True
            LoadRbChoice()

        ElseIf Session("Format") = "DILG" Then
            rbFormat.Visible = False

            Me.CrystalReportViewer1.ReportSource = Me.Crystalreportsource2
            Me.Crystalreportsource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@CYear", Session("DeptYear"))
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@RC_ID", Session("Department_ID"))
            Me.Crystalreportsource2.ReportDocument.SetParameterValue("@Function_ID", Session("Dept_Function_ID"))
        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Planning/APPreports.aspx")
    End Sub

    Protected Sub rbFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbFormat.SelectedIndexChanged
        LoadRbChoice()
    End Sub

    Protected Sub LoadRbChoice()
        If rbFormat.SelectedItem.Value = 1 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Year", Session("DeptYear"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("Department_ID"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", Session("Dept_Function_ID"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))

        ElseIf rbFormat.SelectedItem.Value = 2 Then
            Me.CrystalReportViewer1.ReportSource = Me.Crystalreportsource3
            Me.Crystalreportsource3.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@Year", Session("DeptYear"))
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@RC_ID", Session("Department_ID"))
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@Function_ID", Session("Dept_Function_ID"))
            Me.Crystalreportsource3.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
        End If
    End Sub
End Class
