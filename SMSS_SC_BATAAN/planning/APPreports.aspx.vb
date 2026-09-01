Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Planning_APP_Reports
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            rbChoice.SelectedItem.Value = 2
            LoadAPP()

        End If
    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbChoice.SelectedIndexChanged
        LoadAPP()
    End Sub
    Protected Sub LoadDropdown()
        '=== SIGNATORIES
        ddBAC1.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND ([BAC_PostionID] = 3 or [BAC_PostionID] = 4 or [BAC_PostionID] = 5)", CommandType.Text)
        ddBAC1.DataTextField = ("Name")
        ddBAC1.DataValueField = ("empsig_id")
        ddBAC1.DataBind()

        ddBAC2.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND ([BAC_PostionID] = 3 or [BAC_PostionID] = 4 or [BAC_PostionID] = 5)", CommandType.Text)
        ddBAC2.DataTextField = ("Name")
        ddBAC2.DataValueField = ("empsig_id")
        ddBAC2.DataBind()

        ddBAC3.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND ([BAC_PostionID] = 3 or [BAC_PostionID] = 4 or [BAC_PostionID] = 5)", CommandType.Text)
        ddBAC3.DataTextField = ("Name")
        ddBAC3.DataValueField = ("empsig_id")
        ddBAC3.DataBind()

        '===== COPY THIS CODE ===== 02/12/2025
        ddBAC4.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [Position_desc] = 'BAC Member'", CommandType.Text)
        ddBAC4.DataTextField = ("Name")
        ddBAC4.DataValueField = ("empsig_id")
        ddBAC4.DataBind()

        '===== COPY THIS CODE ===== 02/12/2025
        ddBAC5.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [Position_desc] = 'BAC Member'", CommandType.Text)
        ddBAC5.DataTextField = ("Name")
        ddBAC5.DataValueField = ("empsig_id")
        ddBAC5.DataBind()

        ddBACVC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 2", CommandType.Text)
        ddBACVC.DataTextField = ("Name")
        ddBACVC.DataValueField = ("empsig_id")
        ddBACVC.DataBind()

        ddBACC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 1", CommandType.Text)
        ddBACC.DataTextField = ("Name")
        ddBACC.DataValueField = ("empsig_id")
        ddBACC.DataBind()

        ddPreparedBy.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 ORDER BY [BAC_PostionID], [Name]", CommandType.Text)
        ddPreparedBy.DataTextField = ("Name")
        ddPreparedBy.DataValueField = ("empsig_id")
        ddPreparedBy.DataBind()
        ddPreparedBy.Items.Insert(0, "Select")

        ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT empid, UPPER(full_name) AS full_name FROM HRMS.view_signatory WHERE deptid IN (1,2,3,8,13,104) AND division_key = 86 AND isDeptHead = 'Yes' ORDER BY full_name", CommandType.Text)
        ddApprovedBy.DataTextField = ("full_name")
        ddApprovedBy.DataValueField = ("empid")
        ddApprovedBy.DataBind()
        ddApprovedBy.Items.Insert(0, "Select")
    End Sub


    Protected Sub LoadAPP()
        If rbChoice.SelectedItem.Value = 1 Then
            ddYear.ClearSelection()
            ddYear.DataSource = objDerived.GetDataTable("SELECT year FROM AMS.APP ORDER BY year DESC", CommandType.Text)
            ddYear.DataTextField = "year"
            ddYear.DataValueField = "year"
            ddYear.DataBind()
            ddYear.Items.Insert(0, "Select")

            Me.mvAPP.SetActiveView(Me.vwLGU)
            LoadDropdown()

            Session("APP") = "LGU"

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            ddDeptYear.ClearSelection()
            ddDeptYear.DataSource = objDerived.GetDataTable("SELECT year FROM AMS.APP ORDER BY year DESC", CommandType.Text)
            ddDeptYear.DataTextField = "year"
            ddDeptYear.DataValueField = "year"
            ddDeptYear.DataBind()
            ddDeptYear.Items.Insert(0, "Select")

            ddDepartment.ClearSelection()
            ddDepartment.DataSource = Nothing
            ddDepartment.DataBind()
            ddDepartment.Items.Insert(0, "Select")

            ddFunction.ClearSelection()
            ddFunction.DataSource = Nothing
            ddFunction.DataBind()
            ddFunction.Items.Insert(0, "Select")

            Me.mvAPP.SetActiveView(Me.vwDepartment)
            LoadDropdown()

            Session("APP") = "Department"
        End If
    End Sub


    Protected Sub ddYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddYear.SelectedIndexChanged
        Session("Year") = ddYear.SelectedItem.Value
        Session("isContinuing") = False
        Session("isSupplemental") = False

        'btnPreview.Enabled = True
        LoadSignatoryEnable()
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            If ddBAC1.SelectedItem.Text = "" Or ddBAC2.SelectedItem.Text = "" Or ddBAC3.SelectedItem.Text = "" Then
            ElseIf ddBAC4.SelectedItem.Text = "" Or ddBAC5.SelectedItem.Text = "" Then '===== ADD THIS LINE 02/21/2025 =====
            ElseIf ddBACVC.SelectedItem.Text = "" Or ddBACC.SelectedItem.Text = "" Then
            ElseIf ddApprovedBy.SelectedItem.Text = "Select" And ddPreparedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory")
                Exit Sub
            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set default BAC signatories in File Maintenance.")
            Exit Sub
        End Try

        '===============================================================================

        Session("Page") = "RQ"

        LoadSignatories()

        If rbLGU.SelectedItem.Value = 1 Then
            ' Me.Page.Response.Redirect("~/PLANNING/rpt_app.aspx")
            Dim url As String = "/PLANNING/rpt_app.aspx"
            Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"

            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)

        ElseIf rbLGU.SelectedItem.Value = 2 Then
            'Me.Page.Response.Redirect("~/Reports and Query/rpt_APP_LGU.aspx")
            Dim url As String = "/Reports and Query/rpt_APP_LGU.aspx"
            Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"

            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)
        End If
    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddDepartment.SelectedIndexChanged
        ddFunction.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
        ddFunction.DataTextField = "Function_Desc"
        ddFunction.DataValueField = "Function_ID"
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")

        ddFunction.Enabled = True

    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddFunction.SelectedIndexChanged
        'btnAPPDept.Enabled = True
        'btnConti.Enabled = True
        ddPreparedBy.ClearSelection()
        ddPreparedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(full_name) as full_name, empid FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' ORDER BY full_name", CommandType.Text)
        ddPreparedBy.DataTextField = ("full_name")
        ddPreparedBy.DataValueField = ("empid")
        ddPreparedBy.DataBind()
        ddPreparedBy.Items.Insert(0, "Select")

        LoadSignatoryEnable()
    End Sub

    Protected Sub ddDeptYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddDeptYear.SelectedIndexChanged
        ddDepartment.DataSource = Nothing
        ddDepartment.DataBind()
        ddDepartment.Items.Insert(0, "Select")

        ddDepartment.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
        ddDepartment.DataTextField = "RC_Name"
        ddDepartment.DataValueField = "RC_id"
        ddDepartment.DataBind()
        ddDepartment.Items.Insert(0, "Select")

        ddDepartment.Enabled = True
    End Sub

    Protected Sub btnAPPDept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAPPDept.Click
        Try
            If ddBAC1.SelectedItem.Text = "" Or ddBAC2.SelectedItem.Text = "" Or ddBAC3.SelectedItem.Text = "" Then
            ElseIf ddBAC4.SelectedItem.Text = "" Or ddBAC5.SelectedItem.Text = "" Then '===== ADD THIS LINE 02/21/2025 =====
            ElseIf ddBACVC.SelectedItem.Text = "" Or ddBACC.SelectedItem.Text = "" Then
            ElseIf ddApprovedBy.SelectedItem.Text = "Select" And ddPreparedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory")
                Exit Sub
            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set default BAC signatories in File Maintenance.")
            Exit Sub
        End Try

        '===============================================================================

        Session("DeptYear") = ddDeptYear.SelectedItem.Value
        Session("Department_ID") = ddDepartment.SelectedItem.Value
        Session("Dept_Function_ID") = ddFunction.SelectedItem.Value

        If cbSupplemental.Checked = True Then
            Session("isSupplemental") = 1
        Else
            Session("isSupplemental") = 0
        End If

        LoadSignatories()

        'Me.Page.Response.Redirect("~/Reports and Query/rpt_APP_dept.aspx")
        Dim url As String = "/Reports and Query/rpt_APP_dept.aspx"
        Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"

        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)
    End Sub

    Protected Sub btnConti_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConti.Click
        Session("DeptYear") = ddDeptYear.SelectedItem.Value
        Session("Department_ID") = ddDepartment.SelectedItem.Value
        Session("Dept_Function_ID") = ddFunction.SelectedItem.Value

        'Me.Page.Response.Redirect("~/Reports and Query/rpt_APP_dept.aspx")
        Dim url As String = "/Reports and Query/rpt_APP_dept.aspx"
        Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"

        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)
    End Sub

    Protected Sub rbPerDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbPerDept.SelectedIndexChanged
        ddDeptYear.Enabled = True

        If rbPerDept.SelectedItem.Value = 1 Then
            Session("Format") = "GPPB"

        ElseIf rbPerDept.SelectedItem.Value = 2 Then
            Session("Format") = "DILG"

        End If
    End Sub

    Protected Sub rbLGU_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbLGU.SelectedIndexChanged
        ddYear.Enabled = True

        If rbLGU.SelectedItem.Value = 1 Then
            Session("Format") = "GPPB"

        ElseIf rbLGU.SelectedItem.Value = 2 Then
            Session("Format") = "DILG"

        End If
    End Sub

    Protected Sub ddPreparedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddPreparedBy.SelectedIndexChanged
        btnPreview.Enabled = True
        btnAPPDept.Enabled = True
    End Sub

    Protected Sub LoadSignatoryEnable()
        ddBAC1.Enabled = True
        ddBAC2.Enabled = True
        ddBAC3.Enabled = True
        ddBAC4.Enabled = True '===== ADD THIS LINE 02/21/2025 =====
        ddBAC5.Enabled = True '===== ADD THIS LINE 02/21/2025 =====
        ddBACVC.Enabled = True
        ddBACC.Enabled = True
        ddPreparedBy.Enabled = True
        ddApprovedBy.Enabled = True
    End Sub

    Protected Sub LoadSignatories()

        Dim Prep As String
        Prep = objDerived.GetValue("SELECT UPPER(Position_desc) as Position_desc FROM HRMS.view_signatory WHERE empid = '" & ddPreparedBy.SelectedItem.Value & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE dbo.Temp_BACSignatories SET BAC1 = '" & ddBAC1.SelectedItem.Value & "', BAC2 = '" & ddBAC2.SelectedItem.Value & "', BAC3 = '" & ddBAC3.SelectedItem.Value & "', BACVC = '" & ddBACVC.SelectedItem.Value & "', BACC = '" & ddBACC.SelectedItem.Value & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE dbo.Temp_BACSignatories SET BAC4 = '" & ddBAC4.SelectedItem.Value & "', BAC5 = '" & ddBAC5.SelectedItem.Value & "'", CommandType.Text) '===== ADD THIS LINE 02/21/2025 =====
        objDerived.GetRecords("UPDATE dbo.Temp_BACSignatories SET ApprovedBy = '" & ddApprovedBy.SelectedItem.Value & "', PreparedBy = '" & ddPreparedBy.SelectedItem.Text.Replace("'", "") & "', PreparedBy_Pos = '" & Prep.Replace("'", "") & "', DateSet = '" & Date.Today.ToString("MM/dd/yyyy") & "', UserName = '" & Session("@UserName") & "'", CommandType.Text)

    End Sub


End Class
