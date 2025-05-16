
Partial Class Reports_and_Query_rpt_PhysicalCount_PPE_Consolidated
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Report") = "ALL" Then
            Me.CrystalReportViewer1.ReportSource = Me.Crystalreportsource2
            Me.Crystalreportsource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Else
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Search", Session("Search"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@PARTICULAR_ID", Session("particular"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@PERSON", Session("employee"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("Department"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", Session("GA_ID"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@FUNCTION_ID", Session("Function_ID"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Item_Desc", Session("Item_Desc"))
        End If
    
    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Reports and Query/PhysicalCount_PPE.aspx")
    End Sub
End Class
