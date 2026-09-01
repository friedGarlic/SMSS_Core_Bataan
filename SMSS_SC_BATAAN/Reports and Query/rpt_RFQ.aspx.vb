
Partial Class Reports_and_Query_rpt_RFQ
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub Reports_and_Query_rpt_RFQ_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("prhdr_id"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isRecanvass", Session("isRecanvass"))



    End Sub

    Protected Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        If Session("Page") = "RQ" Then
            Me.Page.Response.Redirect("~/Reports and Query/RFQ.aspx")
        Else

        End If

    End Sub

End Class
