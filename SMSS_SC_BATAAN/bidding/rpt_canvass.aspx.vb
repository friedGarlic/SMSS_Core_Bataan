
Partial Class bidding_rpt_canvass
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
 

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@PRHdr_ID", Session("prhdr_id"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Supplier_ID", Session("Supplier_ID"))
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Me.Session("page") = "canvass_goods" Then
            Me.Page.Response.Redirect("~/bidding/t_canvass_goods.aspx")

        ElseIf Me.Session("page") = "canvass_infra" Then
            Me.Page.Response.Redirect("~/bidding/t_canvass_infra.aspx")

        ElseIf Me.Session("page") = "abstractofcanvass" Then
            Me.Page.Response.Redirect("~/bidding/t_abstract_of_canvass.aspx")

        ElseIf Me.Session("page") = "negotiated" Then
            Me.Page.Response.Redirect("~/bidding/t_pre_procurement_negotiated_v2.aspx")

        ElseIf Me.Session("page") = "OBR Evaluation" Then
            Me.Page.Response.Redirect("~/bidding/t_obr_evaluation.aspx")
        End If

    End Sub
End Class
