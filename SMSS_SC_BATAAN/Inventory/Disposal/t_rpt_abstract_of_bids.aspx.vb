Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class t_rpt_abstract_of_bids
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("AbstractBids_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_ISSP_List.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "AbstractOfBids")

            Me.Page.Response.End()

        End If

    End Sub

    Private Sub t_rpt_abstract_of_bids_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Session("Page") = "ISSP_List" Then

            If Not IsPostBack Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_AbstractProposal.rpt"))
                rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                Session("AbstractBids_Report") = rpt

            Else

                rpt = CType(Session("AbstractBids_Report"), ReportDocument)

                If rpt Is Nothing Then

                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_AbstractProposal.rpt"))
                    rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                    Session("AbstractBids_Report") = rpt

                End If

            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.AbstractReport_template.ReportSource = rpt

        ElseIf Session("Page") = "Abstract" Then

            If Not IsPostBack Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_AbstractProposal_No2.rpt"))
                rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                Session("AbstractBids_Report") = rpt

            Else

                rpt = CType(Session("AbstractBids_Report"), ReportDocument)

                If rpt Is Nothing Then

                    rpt = New ReportDocument()
                    rpt.Load(Server.MapPath("rpt_AbstractProposal_No2.rpt"))
                    rpt.SetParameterValue("@IsspHdr_ID", Me.Session("IsspHdr_ID"))
                    Session("AbstractBids_Report") = rpt

                End If

            End If

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            Me.AbstractReports.ReportSource = rpt

        Else

            ' No valid Session("Page") value - leave both viewers unbound.

        End If

    End Sub

    Private Sub t_rpt_abstract_of_bids_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        If Session("Page") = "ISSP_List" Then

            AbstractReport_template.RefreshReport()
            AbstractReport_template.ReportSource = Nothing


            Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_ISSP_List.aspx")
        Else
            Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_Abstract.aspx")
        End If


    End Sub


End Class