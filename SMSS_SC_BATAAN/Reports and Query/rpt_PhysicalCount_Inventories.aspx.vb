Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Reports_and_Query_rpt_PhysicalCount_Inventories
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private rpt As New ReportDocument

    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("PhysCount_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Reports and Query/t_rpt_physical_count_of_inventory.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "PhysicalCount_Inventories")

            Me.Page.Response.End()

        End If

        AddTrace("GA_ID: " & Session("GA_ID"))
        AddTrace("StockDate: " & Session("StockDate"))

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' On the very first request, build the report and stash it in Session.
        ' On every subsequent request (including pagination postbacks),
        ' pull the SAME instance from Session — this preserves page state.
        If Not IsPostBack Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_PhysicalCount_Inventories.rpt"))
            rpt.SetParameterValue("@GA_ID", Session("GA_ID"))
            rpt.SetParameterValue("@StockDate", Session("StockDate"))
            Session("PhysCount_Report") = rpt

        Else

            rpt = CType(Session("PhysCount_Report"), ReportDocument)

            ' Session may have expired or been lost — rebuild as fallback.
            If rpt Is Nothing Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_PhysicalCount_Inventories.rpt"))
                rpt.SetParameterValue("@GA_ID", Session("GA_ID"))
                rpt.SetParameterValue("@StockDate", Session("StockDate"))
                Session("PhysCount_Report") = rpt

            End If

        End If

        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        Me.rpt_PhysicalCount_Inventories.ReportSource = rpt

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Reports and Query/t_rpt_physical_count_of_inventory.aspx")
    End Sub
End Class