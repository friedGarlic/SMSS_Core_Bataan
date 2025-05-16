Imports System.Data

Partial Class Reports_and_Query_AdditionalReports_summarysuppliesused
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private Property dtGenAccount() As DataTable
        Get
            Return CType(Session("dtGenAccount"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtGenAccount") = value
        End Set
    End Property
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Private Sub Reports_and_Query_AdditionalReports_summarysuppliesused_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'Dim monday As DateTime = Today.AddDays((Today.DayOfWeek - DayOfWeek.Monday) * -1)
            'Dim friday As DateTime = Today.AddDays((Today.DayOfWeek - DayOfWeek.Friday) * -1)
            'txtDateFrom.Text = monday
            'txtDateTo.Text = friday
            txtDateFrom.Text = Date.Today.ToString("MM/dd/yyyy")
            txtDateTo.Text = Date.Today.ToString("MM/dd/yyyy")


            dtGenAccount = objDerived.GetDataTable("SELECT (GA_Code2 + ' ' + SUBSTRING(GA_Title2,1,100)) AS GA_Title, GA_ID, BGA_ID, GA_Code2 FROM AMS.View_AccountList WHERE AllotmentClass_ID = 2 ORDER BY GA_Title", CommandType.Text)
            drpGenAccount.DataSource = dtGenAccount
            drpGenAccount.DataTextField = "GA_Title"
            drpGenAccount.DataValueField = "GA_Code2"
            drpGenAccount.DataBind()
            drpGenAccount.Items.Insert(0, "Select")

        End If

        txtDateFrom.Attributes.Add("onChange", "StartProgressBar();")
    End Sub

    'Private Sub txtDateFrom_TextChanged(sender As Object, e As EventArgs) Handles txtDateFrom.TextChanged
    '    Try
    '        Dim det As DateTime = CType(txtDateFrom.Text, DateTime)
    '        Dim monday As DateTime = det.AddDays((det.DayOfWeek - DayOfWeek.Monday) * -1)
    '        Dim friday As DateTime = det.AddDays((det.DayOfWeek - DayOfWeek.Friday) * -1)
    '        txtDateFrom.Text = monday
    '        txtDateTo.Text = friday

    '    Catch ex As Exception
    '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
    '    End Try
    'End Sub
    Private Sub drpGenAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpGenAccount.SelectedIndexChanged
        Try
            Session("GA_ID") = dtGenAccount.Rows(drpGenAccount.SelectedIndex - 1)("GA_ID")
            Session("BGA_ID") = dtGenAccount.Rows(drpGenAccount.SelectedIndex - 1)("BGA_ID")

            'Select Case Session("GA_ID")
            '    Case 1432, 1427, 1428, 1438, 1430, 1433, 1434, 1436, 1443
            '        drpDepartment.DataSource = objDerived.GetDataTable("SELECT * FROM DBO.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
            '        drpDepartment.DataTextField = "RC_Name"
            '        drpDepartment.DataValueField = "RC_ID"
            '        drpDepartment.DataBind()
            '        drpDepartment.Items.Insert(0, "Select")

            '        drpFunction.Dispose()
            '        drpFunction.ClearSelection()
            '        drpFunction.DataSource = Nothing
            '        drpFunction.DataBind()
            '        drpFunction.Items.Insert(0, "Select")

            '        drpDepartment.Enabled = True
            '        drpFunction.Enabled = True

            '    Case Else
            '        drpDepartment.SelectedIndex = 0
            '        drpFunction.SelectedIndex = 0
            'End Select


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub drpDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpDepartment.SelectedIndexChanged
        drpFunction.DataSource = objDerived.GetDataTable("SELECT * FROM DBO.View_RespCenter_withFunctions WHERE RC_ID = '" & drpDepartment.SelectedItem.Value & "' ORDER BY RC_Name", CommandType.Text)
        drpFunction.DataTextField = "Function_Desc"
        drpFunction.DataValueField = "Function_ID"
        drpFunction.DataBind()
        drpFunction.Items.Insert(0, "Select")
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        If drpGenAccount.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select general account to preview report.")
        Else
            Session("DateFrom") = txtDateFrom.Text
            Session("DateTo") = txtDateTo.Text
            Session("Preparedby") = replaceapostrophe(txtPreparedby.Text)
            Session("Certifiedby") = replaceapostrophe(txtCertifiedby.Text)
            Session("Postedby") = replaceapostrophe(txtPostedby.Text)

            'If drpDepartment.SelectedItem.Text = "Select" Then
            '    Session("RC_ID") = 0
            '    Session("Function_ID") = 0
            'Else
            '    Session("RC_ID") = drpDepartment.SelectedItem.Value
            '    Session("Function_ID") = drpFunction.SelectedItem.Value
            'End If

            Me.Page.Response.Redirect("~/MainReports/rpt_ssmi.aspx")
        End If

    End Sub


End Class
