Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Reports_and_Query_rpt_ReturnedPPESummay
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("ReturnedPPE_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Reports and Query/t_ReturnedSummary.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "ReturnedPPE_Summary")

            Me.Page.Response.End()

        End If

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not IsPostBack Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_ReturnedSummary.rpt"))
            rpt.SetParameterValue("@RC_ID", Session("RC_ID"))
            rpt.SetParameterValue("@Status", Session("Status"))
            rpt.SetParameterValue("@Year", Session("Year"))
            rpt.SetParameterValue("@Month", Session("Month"))
            rpt.SetParameterValue("@PreparedBy_ID", Session("PreparedBy"))
            Session("ReturnedPPE_Report") = rpt

        Else

            rpt = CType(Session("ReturnedPPE_Report"), ReportDocument)

            If rpt Is Nothing Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_ReturnedSummary.rpt"))
                rpt.SetParameterValue("@RC_ID", Session("RC_ID"))
                rpt.SetParameterValue("@Status", Session("Status"))
                rpt.SetParameterValue("@Year", Session("Year"))
                rpt.SetParameterValue("@Month", Session("Month"))
                rpt.SetParameterValue("@PreparedBy_ID", Session("PreparedBy"))
                Session("ReturnedPPE_Report") = rpt

            End If

        End If

        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        Me.CrystalReportViewer1.ReportSource = rpt

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Reports and Query/t_ReturnedSummary.aspx")
    End Sub
End Class