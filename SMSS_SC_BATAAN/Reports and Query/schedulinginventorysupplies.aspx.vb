Imports System
Imports System.Data

Partial Class Reports_and_Query_AdditionalReports_schedulinginventorysupplies
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private obj As New connectionreport
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Private Sub Reports_and_Query_AdditionalReports_schedulinginventorysupplies_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            objDerived.Execute("DELETE FROM [AMS].[tbl_ScheduleInventories]", CommandType.Text)

            txtDate.Text = Date.Today.ToShortDateString

            drpDepartment.DataSource = objDerived.GetDataTable("SELECT RC_ID, RC_Name FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
            drpDepartment.DataTextField = "RC_Name"
            drpDepartment.DataValueField = "RC_ID"
            drpDepartment.DataBind()
            drpDepartment.Items.Insert(0, "Select")

            drpFunction.Items.Clear()
            drpFunction.Items.Insert(0, "Select")

            drpInventory.Enabled = True

        End If

        LoadDepartments()


    End Sub
    Protected Sub LoadDepartments()
        grdDepartments.DataSource = objDerived.GetDataTable("SELECT * FROM [AMS].[tbl_ScheduleInventories] WHERE [isOutside] = 0", CommandType.Text)
        grdDepartments.DataBind()

        grdOutside.DataSource = objDerived.GetDataTable("SELECT * FROM [AMS].[tbl_ScheduleInventories] WHERE [isOutside] = 1", CommandType.Text)
        grdOutside.DataBind()
    End Sub

    Private Sub Reports_and_Query_AdditionalReports_schedulinginventorysupplies_Init(sender As Object, e As EventArgs) Handles Me.Init

    End Sub

    Private Sub drpDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpDepartment.SelectedIndexChanged
        drpFunction.DataSource = objDerived.GetDataTable("SELECT Function_ID, Function_Desc FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & drpDepartment.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        drpFunction.DataTextField = "Function_Desc"
        drpFunction.DataValueField = "Function_ID"
        drpFunction.DataBind()
        drpFunction.Items.Insert(0, "Select")
    End Sub

    Private Sub btnAdd_Dept_Click(sender As Object, e As EventArgs) Handles btnAdd_Dept.Click
        Try
            If drpDepartment.SelectedItem.Text = "Select" Or drpFunction.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select department and its function.")
            Else
                objDerived.Execute("INSERT INTO [AMS].[tbl_ScheduleInventories] ([Department],[SchedDate],[isOutside],[Inventory])                                             " &
                                 " VALUES                     " &
                                 " ('" & IIf(drpFunction.SelectedItem.Value = 86, replaceapostrophe(drpDepartment.SelectedItem.Text), replaceapostrophe(drpFunction.SelectedItem.Text)) & "'    " &
                                 " ,'" & CType(txtDate.Text, Date) & "'       " &
                                 " ,'" & cbOutside.Checked & "'       " &
                                 " ,'" & drpInventory.SelectedItem.Text & "')", CommandType.Text)


                drpDepartment.DataSource = objDerived.GetDataTable("SELECT RC_ID, RC_Name FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
                drpDepartment.DataTextField = "RC_Name"
                drpDepartment.DataValueField = "RC_ID"
                drpDepartment.DataBind()
                drpDepartment.Items.Insert(0, "Select")

                drpFunction.Items.Clear()
                drpFunction.Items.Insert(0, "Select")

                Session("Inventory") = drpInventory.SelectedItem.Text

                LoadDepartments()

                drpInventory.Enabled = False

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            End If



        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Session("Page") = "SchedulingInventories"

        Me.Page.Response.Redirect("~/MainReports/rpt_ForInventory_Reports.aspx")
    End Sub


End Class
