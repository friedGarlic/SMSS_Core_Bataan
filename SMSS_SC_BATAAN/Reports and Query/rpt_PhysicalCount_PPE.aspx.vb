Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Reports_and_Query_rpt_PhysicalCount_PPE
    Inherits System.Web.UI.Page

    Private objDerived As New connectionreport

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

            Dim rptPrint As ReportDocument = CType(Session("ReportDoc"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Reports and Query/PhysicalCount_PPE.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "PhysicalCount_PPE")

            Me.Page.Response.End()

        End If

    End Sub


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        AddTrace("isConsoldiated: " & Session("isConsoldiated"))
        AddTrace("isPerDepartment: " & Session("isPerDepartment"))
        AddTrace("isPerItems: " & Session("isPerItems"))
        AddTrace("RC_ID: " & Session("RC_ID"))
        AddTrace("ItemDesc: " & Session("ItemDesc"))

        AddTrace("SortBy: " & Session("SortBy"))
        AddTrace("GA_ID: " & Session("GA_ID"))

        Dim rpt As ReportDocument

        If Session("ReportDoc") Is Nothing Then

            rpt = New ReportDocument()

            'rpt.Load(Server.MapPath("~/Reports and Query/rpt_PhysicalCount_PPE.rpt"))
            rpt.Load(Server.MapPath("~/Reports and Query/rpt_PhysicalCount_PPE_v2.rpt"))

            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rpt.SetParameterValue("@isConsoldiated", Session("isConsoldiated"))
            rpt.SetParameterValue("@isPerDepartment", Session("isPerDepartment"))
            rpt.SetParameterValue("@isPerItems", Session("isPerItems"))
            rpt.SetParameterValue("@RC_ID", Session("RC_ID"))
            rpt.SetParameterValue("@Function_ID", Session("Function_ID"))
            rpt.SetParameterValue("@ItemDesc", Session("ItemDesc"))
            rpt.SetParameterValue("@SortBy", Session("SortBy"))
            rpt.SetParameterValue("@GA_ID", Session("GA_ID"))

            Session("ReportDoc") = rpt

        Else

            rpt = CType(Session("ReportDoc"), ReportDocument)

        End If

        rpt_PhysicalCount_PPE.ReportSource = rpt
        rpt_PhysicalCount_PPE.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        If Session("ReportDoc") IsNot Nothing Then

            CType(Session("ReportDoc"), ReportDocument).Close()
            CType(Session("ReportDoc"), ReportDocument).Dispose()

            Session("ReportDoc") = Nothing

        End If

        Response.Redirect("~/Reports and Query/PhysicalCount_PPE.aspx")

    End Sub

    Private Sub Reports_and_Query_rpt_PhysicalCount_PPE_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub

End Class