Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Reports_and_Query_rpt_IssuanceReport
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("IssuanceReport_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Reports and Query/t_rpt_issuance.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "IssuanceReport")

            Me.Page.Response.End()

        End If

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not IsPostBack Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_IssuanceReport.rpt"))
            rpt.SetParameterValue("@Month", Me.Session("Month"))
            rpt.SetParameterValue("@Year", Me.Session("Year"))
            Session("IssuanceReport_Report") = rpt

        Else

            rpt = CType(Session("IssuanceReport_Report"), ReportDocument)

            If rpt Is Nothing Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_IssuanceReport.rpt"))
                rpt.SetParameterValue("@Month", Me.Session("Month"))
                rpt.SetParameterValue("@Year", Me.Session("Year"))
                Session("IssuanceReport_Report") = rpt

            End If

        End If

        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        Me.CrystalReportViewer1.ReportSource = rpt

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Reports and Query/t_rpt_issuance.aspx")
    End Sub
End Class