Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Inventory_Disposal_rpt_NoticePublicBidding
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private objDerived2 As New DerivedDal
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("NoticePB_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Records/PropertyCard_Rev.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "NoticePublicBidding")

            Me.Page.Response.End()

        End If

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not IsPostBack Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_Notice_PubBidding.rpt"))
            rpt.SetParameterValue("@IIRUPHdr_ID", Me.Session("IIRUPHdr_ID"))
            Session("NoticePB_Report") = rpt

        Else

            rpt = CType(Session("NoticePB_Report"), ReportDocument)

            If rpt Is Nothing Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_Notice_PubBidding.rpt"))
                rpt.SetParameterValue("@IIRUPHdr_ID", Me.Session("IIRUPHdr_ID"))
                Session("NoticePB_Report") = rpt

            End If

        End If

        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        Me.CrystalReportViewer1.ReportSource = rpt

    End Sub

End Class