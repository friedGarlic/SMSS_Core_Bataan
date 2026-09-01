
'Partial Class Reports_and_Query_rpt_PhysicalCount_PPE
'    Inherits System.Web.UI.Page
'    Private objDerived As New connectionreport
'    Dim DBPassUsernname As New connectionreport

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        Me.rpt_PhysicalCount_PPE.ReportSource = Me.CrystalReportSource1
'        Me.rpt_PhysicalCount_PPE.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

'        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
'        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isConsoldiated", Session("isConsoldiated"))
'        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isPerDepartment", Session("isPerDepartment"))
'        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isPerItems", Session("isPerItems"))
'        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
'        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Function_ID", Session("Function_ID"))
'        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@ItemDesc", Session("ItemDesc"))
'        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@SortBy", Session("SortBy"))
'        Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", Session("GA_ID"))


'        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Search", Session("Search"))
'        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@PARTICULAR_ID", Session("particular"))
'        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@PERSON", Session("employee"))
'        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("Department"))
'        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@GA_ID", Session("GA_ID"))
'        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@FUNCTION_ID", Session("Function_ID"))
'        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Item_Desc", Session("Item_Desc"))

'        '@isConsoldiated BIT,
'        '@isPerDepartment BIT,
'        '@isPerItems BIT,
'        '@ INTEGER,
'        '@Function_ID INTEGER,
'        '@ItemDesc VARCHAR(5000),
'        '@SortBy VARCHAR(200),
'        '@GA_ID INTEGER

'    End Sub

'    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
'        Me.Page.Response.Redirect("~/Reports and Query/PhysicalCount_PPE.aspx")

'    End Sub

'    Private Sub Reports_and_Query_rpt_PhysicalCount_PPE_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
'        Master.FindControl("MasterRowModules").Visible = False
'        Master.FindControl("UserRow").Visible = False
'        Master.FindControl("Menu1").Visible = False

'    End Sub
'End Class



Imports CrystalDecisions.CrystalReports.Engine

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