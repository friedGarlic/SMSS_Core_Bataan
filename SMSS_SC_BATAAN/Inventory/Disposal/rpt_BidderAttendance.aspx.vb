Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Inventory_Disposal_rpt_BidderAttendance
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("BidderAttendance_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_ISSP_List.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "BidderAttendance")

            Me.Page.Response.End()

        End If

    End Sub

    Private Sub Inventory_Disposal_rpt_BidderAttendance_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Not IsPostBack Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_BiddersAttendance.rpt"))
            rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
            rpt.SetParameterValue("@Copies", Me.Session("Copies"))
            rpt.SetParameterValue("@Price", Me.Session("Price"))
            Session("BidderAttendance_Report") = rpt

        Else

            rpt = CType(Session("BidderAttendance_Report"), ReportDocument)

            If rpt Is Nothing Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_BiddersAttendance.rpt"))
                rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                rpt.SetParameterValue("@Copies", Me.Session("Copies"))
                rpt.SetParameterValue("@Price", Me.Session("Price"))
                Session("BidderAttendance_Report") = rpt

            End If

        End If

        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        Me.BidderReport.ReportSource = rpt

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_ISSP_List.aspx")

    End Sub

    Private Sub Inventory_Disposal_rpt_BidderAttendance_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        Session("Copies") = txtCopies.Text
        Session("Price") = txtPrice.Text

        rpt = New ReportDocument()
        rpt.Load(Server.MapPath("rpt_BiddersAttendance.rpt"))
        rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
        rpt.SetParameterValue("@Copies", Me.Session("Copies"))
        rpt.SetParameterValue("@Price", Me.Session("Price"))
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Session("BidderAttendance_Report") = rpt

        Me.BidderReport.ReportSource = rpt

    End Sub

End Class