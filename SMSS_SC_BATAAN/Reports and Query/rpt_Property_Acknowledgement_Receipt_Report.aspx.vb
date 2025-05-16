
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Drawing
Partial Class Reports_and_Query_rpt_Property_Acknowledgement_Receipt_Report
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Public Sub LoadNotedBy()
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
End Class
