
Imports System.Data

Partial Class Reports_and_Query_PhysicalCount_DisposedItem
    Inherits System.Web.UI.Page
    Dim DBPassUsernname As New connectionreport
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule

    Private Property pAccountCodes() As DataTable
        Get
            Return CType(Session("pAccountCodes"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAccountCodes") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToShortDateString

            drpDepartment.DataSource = objDerived.GetDataTable("SELECT RC_ID, RC_Name FROM DBO.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
            drpDepartment.DataTextField = "RC_Name"
            drpDepartment.DataValueField = "RC_ID"
            drpDepartment.DataBind()
            drpDepartment.Items.Insert(0, "Select")

            drpGenAccount.DataSource = objDerived.GetDataTable("SELECT GA_ID, BGA_ID, GA_Code2, GA_Title, (GA_Code + ' - ' + GA_Title) AS GenAccount FROM AMS.View_AccountList WHERE AllotmentClass_ID = 3 AND BGA_ID = 0 ORDER BY GA_Title", CommandType.Text)
            drpGenAccount.DataTextField = "GenAccount"
            drpGenAccount.DataValueField = "GA_ID"
            drpGenAccount.DataBind()
            drpGenAccount.Items.Insert(0, "Select")

            LoadReportFormat()

        End If

        drpReportFormat.Attributes.Add("onChange", "StartProgressBar();")
    End Sub

    Private Sub drpReportFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpReportFormat.SelectedIndexChanged
        LoadReportFormat()
    End Sub

    Private Sub LoadReportFormat()
        If drpReportFormat.SelectedItem.Value = 1 Then
            Session("ReportFormat") = "Per Department"
            drpDepartment.Enabled = True
            drpGenAccount.Enabled = False

        ElseIf drpReportFormat.SelectedItem.Value = 2 Then
            Session("ReportFormat") = "Per Account"
            drpDepartment.Enabled = False
            drpGenAccount.Enabled = True

        Else
            drpDepartment.Enabled = False
            drpGenAccount.Enabled = False
        End If
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Session("Report") = "Dispose"

        Session("PreparedBy1") = replaceapostrophe(txtPreparedBy1.Text)
        Session("PreparedBy1_Pos") = replaceapostrophe(txtPreparedBy1_Pos.Text)

        Session("PreparedBy2") = replaceapostrophe(txtPreparedBy2.Text)
        Session("PreparedBy2_Pos") = replaceapostrophe(txtPreparedBy2_Pos.Text)

        Session("PreparedBy3") = replaceapostrophe(txtPreparedBy3.Text)
        Session("PreparedBy3_Pos") = replaceapostrophe(txtPreparedBy3_Pos.Text)

        Session("PreparedBy4") = replaceapostrophe(txtPreparedBy4.Text)
        Session("PreparedBy4_Pos") = replaceapostrophe(txtPreparedBy4_Pos.Text)

        If drpReportFormat.SelectedItem.Value = 1 Then
            Session("Date") = CType(txtDate.Text, Date)
            Session("RC_ID") = drpDepartment.SelectedItem.Value
            Session("Function_ID") = 86
            Session("F_ID") = drpFund.SelectedItem.Value

        ElseIf drpReportFormat.SelectedItem.Value = 2 Then
            Session("Date") = CType(txtDate.Text, Date)
            Session("GA_ID") = drpGenAccount.SelectedItem.Value
            Session("F_ID") = drpFund.SelectedItem.Value

        Else

        End If


        Me.Page.Response.Redirect("~/Reports and Query/rpt_PhysicalCount_PPE.aspx")
    End Sub
End Class
