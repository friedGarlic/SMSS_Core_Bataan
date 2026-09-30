Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class filemaintenance_rpt_MasterList
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("MasterList_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/filemaintenance/t_goods_master_list.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "MasterList")

            Me.Page.Response.End()

        End If

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not IsPostBack Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_FM_MasterList.rpt"))
            rpt.SetParameterValue(0, Me.Session("xYear"))
            rpt.SetParameterValue(1, Me.Session("Allotment_Type"))
            Session("MasterList_Report") = rpt

        Else

            rpt = CType(Session("MasterList_Report"), ReportDocument)

            If rpt Is Nothing Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_FM_MasterList.rpt"))
                rpt.SetParameterValue(0, Me.Session("xYear"))
                rpt.SetParameterValue(1, Me.Session("Allotment_Type"))
                Session("MasterList_Report") = rpt

            End If

        End If

        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        Me.CrystalReportViewer1.ReportSource = rpt

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/filemaintenance/t_goods_master_list.aspx")
    End Sub
End Class