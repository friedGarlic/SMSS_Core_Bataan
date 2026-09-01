
Partial Class Reports_and_Query_rpt_APP_LGU
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim DBPassUsernname As New connectionreport


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CYear", Session("Year"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isSupplemental", Session("isSupplemental"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isContinuing", Session("isContinuing"))

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "RQ" Then
            Me.Page.Response.Redirect("~/Planning/APPreports.aspx")
        Else
            Me.Page.Response.Redirect("~/Reports and Query/APP.aspx")

        End If

    End Sub
End Class
