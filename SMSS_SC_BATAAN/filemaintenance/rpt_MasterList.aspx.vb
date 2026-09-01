
Partial Class filemaintenance_rpt_MasterList
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

        LoadReportReset()
        LoadReport()
    End Sub

    Public Sub LoadReportReset()
        Session("Reset") = 0

        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("Reset"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(1, Session("Reset"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(2, Session("Reset"))
    End Sub


    Public Sub LoadReport()
        AddTrace("Year: " & Session("Year"))
        AddTrace("Allotment_Type: " & Session("Allotment_Type"))
        AddTrace("GA_ID: " & Session("GA_ID"))

        Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
        Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("xYear"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(1, Session("Allotment_Type"))
        Me.CrystalReportSource1.ReportDocument.SetParameterValue(2, Session("GA_ID"))
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/filemaintenance/t_goods_master_list.aspx")
    End Sub
End Class
