Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Inventory_Disposal_rpt_IIRUP
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("IIRUP_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Reports and Query/DisposalReports.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "IIRUP_Report")

            Me.Page.Response.End()

        End If

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not IsPostBack Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("IIRUP.rpt"))
            rpt.SetParameterValue(0, Me.Session("TransID"))
            Session("IIRUP_Report") = rpt

        Else

            rpt = CType(Session("IIRUP_Report"), ReportDocument)

            If rpt Is Nothing Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("IIRUP.rpt"))
                rpt.SetParameterValue(0, Me.Session("TransID"))
                Session("IIRUP_Report") = rpt

            End If

        End If

        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        Me.Disposal_Reports.ReportSource = rpt

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        ' Intentionally left blank.
        ' The ReportDocument lives in Session and must NOT be disposed
        ' while the ?print=1 branch still needs it.

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Reports and Query/DisposalReports.aspx")
    End Sub
End Class