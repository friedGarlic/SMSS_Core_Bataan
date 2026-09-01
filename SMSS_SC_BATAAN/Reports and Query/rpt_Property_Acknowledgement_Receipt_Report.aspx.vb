Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Drawing
Partial Class Reports_and_Query_rpt_Property_Acknowledgement_Receipt_Report
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Public Sub LoadNotedBy()
        AddTrace("MRENumber: " & Session("MRENumber"))
        drpNotedBy.Items.Clear()
        drpNotedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory ", CommandType.Text)
        drpNotedBy.DataTextField = ("full_name")
        drpNotedBy.DataValueField = ("empid")
        drpNotedBy.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.MultiView1.SetActiveView(Me.View1)
            If Session("MRENumber") <> "" Then
                Me.MultiView1.SetActiveView(Me.View1)
                Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
                Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource1.ReportDocument.SetParameterValue("@MRENumber", Session("MRENumber"))
            Else
            End If
            LoadNotedBy()
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Inventory/Property_Acknowledgement_Receipt_Report.aspx")
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If RadioButtonList1.SelectedValue = 1 Then
            Me.MultiView1.SetActiveView(Me.View1)
            If Session("MRENumber") <> "" Then
                Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
                Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource1.ReportDocument.SetParameterValue("@MRENumber", Session("MRENumber"))
            Else
            End If
        Else
            lblPosition.Text = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory where EmpID='" & drpNotedBy.SelectedItem.Value & "'", CommandType.Text)
            Me.MultiView1.SetActiveView(Me.View2)
            If Session("MRENumber") <> "" Then
                Me.CrystalReportViewer2.ReportSource = Me.CrystalReportSource2
                Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("@MRENumber", Session("MRENumber"))
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("NotedBy", drpNotedBy.SelectedItem.Text)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("Position", lblPosition.Text)
            Else
            End If
        End If
    End Sub

    Protected Sub drpNotedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpNotedBy.SelectedIndexChanged
        lblPosition.Text = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory where EmpID='" & drpNotedBy.SelectedItem.Value & "'", CommandType.Text)
        Me.MultiView1.SetActiveView(Me.View2)
        If Session("MRENumber") <> "" Then
            Me.CrystalReportViewer2.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue("@MRENumber", Session("MRENumber"))
            Me.CrystalReportSource2.ReportDocument.SetParameterValue("NotedBy", drpNotedBy.SelectedItem.Text)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue("Position", lblPosition.Text)
        Else
        End If
    End Sub

    ' ================================================================
    ' MINIMAL FIX - JUST ADD THIS EVENT HANDLER
    ' This fires when the user interacts with the Crystal Viewer toolbar
    ' (zoom, page navigation, export, print, etc.)
    ' ================================================================
    Protected Sub CrystalReportViewer1_OnLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        ' Only reapply if this is a postback from the viewer itself
        If Page.IsPostBack AndAlso Session("MRENumber") <> "" AndAlso MultiView1.GetActiveView() Is View1 Then
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@MRENumber", Session("MRENumber"))
        End If
    End Sub

    Protected Sub CrystalReportViewer2_OnLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer2.Load
        ' Only reapply if this is a postback from the viewer itself
        If Page.IsPostBack AndAlso Session("MRENumber") <> "" AndAlso MultiView1.GetActiveView() Is View2 Then
            Me.CrystalReportViewer2.ReportSource = Me.CrystalReportSource2
            Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource2.ReportDocument.SetParameterValue("@MRENumber", Session("MRENumber"))
            If drpNotedBy.SelectedItem IsNot Nothing Then
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("NotedBy", drpNotedBy.SelectedItem.Text)
                Me.CrystalReportSource2.ReportDocument.SetParameterValue("Position", lblPosition.Text)
            End If
        End If
    End Sub
    ' ================================================================
    ' END OF FIX
    ' ================================================================

End Class