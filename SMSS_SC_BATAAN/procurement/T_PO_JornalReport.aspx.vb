Imports System.Data



Partial Class T_PO_JornalReport
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private rptDerived As New connectionreport

    Private Sub PurchaseJornalReports_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                drpYear.DataSource = objDerived.GetDataTable("SELECT DISTINCT Year FROM AMS.APP WHERE STATUS <> 3 ORDER BY Year DESC", CommandType.Text)
                drpYear.DataTextField = ("Year")
                drpYear.DataValueField = ("Year")
                drpYear.DataBind()

                ddPrepared.DataSource = objDerived.GetDataTable("SELECT EmpID, Upper(Full_Name) AS Full_Name  FROM HRMS.view_signatory WHERE deptid = 7 ORDER BY Full_Name", CommandType.Text)
                ddPrepared.DataTextField = "Full_Name"
                ddPrepared.DataValueField = "EmpID"
                ddPrepared.DataBind()



                ddApproved.DataSource = objDerived.GetDataTable("SELECT EmpID, Upper(Full_Name) AS Full_Name  FROM HRMS.view_signatory WHERE deptid = 7 ORDER BY Full_Name", CommandType.Text)
                ddApproved.DataTextField = "Full_Name"
                ddApproved.DataValueField = "EmpID"
                ddApproved.DataBind()



            End If

            Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(rptDerived.username, rptDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Cyear", drpYear.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", drpMonth.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@F_ID", ddFund.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Allotment_Type", DDallotment.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Prepared", 0)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Approved", 0)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")


        End Try


    End Sub
    Protected Sub BtnPreview_Click(sender As Object, e As EventArgs)
        If ddfund.SelectedItem.Text = "Select" Or DDallotment.SelectedItem.Text = "Select" Or ddPrepared.SelectedItem.Text = "Select" Or ddApproved.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Complete all search option.")
        Else
            Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(rptDerived.username, rptDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Cyear", drpYear.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", drpMonth.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@F_ID", ddFund.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Allotment_Type", DDallotment.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Prepared", ddPrepared.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Approved", ddApproved.SelectedItem.Value)
        End If
    End Sub
End Class
