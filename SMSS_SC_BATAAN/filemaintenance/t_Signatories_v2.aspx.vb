Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Drawing

Partial Class filemaintenance_t_Signatories_v2
    Inherits System.Web.UI.Page
    Dim objAccess As New AccessRule
    Dim objDerived As New DerivedDal

    Dim obj_mSignatory As New FM_Signatories.m_Signatory
    Dim dt_mSignatoru As New DataTable
    Dim obj_EmpSig As New FM_Signatories.m_Emp_Signatory
    Dim dt_EmpSig As New DataTable
    Dim obj_m_emp_payroll_info As New FM_Signatories.pay_m_emp_payroll_info
    Dim dt_m_emp_payroll_info As New DataTable

#Region "Property"
    Private Property dtDepartment() As DataTable
        Get
            Return CType(Session("dtDepartment"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDepartment") = value
        End Set
    End Property

    Private Property dtSignatories() As DataTable
        Get
            Return CType(Session("dtSignatories"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSignatories") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objAccess.GetAccessRight(Session("@UserName"), Page)
        If objAccess.HasAccess = False Then
            Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            PageLoadDefault()
        End If

    End Sub

    Protected Sub PageLoadDefault()
        dtDepartment = objDerived.GetDataTable("SELECT DISTINCT UPPER(RC_Name) AS RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
        ddDepartment.DataSource = dtDepartment
        ddDepartment.DataTextField = ("RC_Name")
        ddDepartment.DataValueField = ("RC_ID")
        ddDepartment.DataBind()
        ddDepartment.Items.Insert(0, "Select")

        ddFunction.Items.Insert(0, "Select")

        ddPosition.DataSource = objDerived.GetDataTable("SELECT UPPER(position_desc) AS position_desc,position_id FROM dbo.m_position ORDER BY position_desc", CommandType.Text)
        ddPosition.DataTextField = ("position_desc")
        ddPosition.DataValueField = ("position_id")
        ddPosition.DataBind()
        ddPosition.Items.Insert(0, "Select")

        ddDepartment_Search.DataSource = objDerived.GetDataTable("SELECT DISTINCT UPPER(RC_Name) AS RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
        ddDepartment_Search.DataSource = dtDepartment
        ddDepartment_Search.DataTextField = ("RC_Name")
        ddDepartment_Search.DataValueField = ("RC_ID")
        ddDepartment_Search.DataBind()
        ddDepartment_Search.Items.Insert(0, "ALL")

        LoadSignatories()
    End Sub

    Protected Sub LoadSignatories()
        If ddDepartment_Search.SelectedItem.Text = "ALL" Then
            Session("RC_ID") = 0
        Else
            Session("RC_ID") = ddDepartment_Search.SelectedItem.Value
        End If

        dtSignatories = objDerived.GetDataTable("[AMS].[sp_SignatoryList] '" & ddDepartment_Search.SelectedItem.Text & "','" & Session("RC_ID") & "'", CommandType.Text)
        grdSignatories.DataSource = dtSignatories
        grdSignatories.DataBind()

    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        ddFunction.DataSource = objDerived.GetDataTable("SELECT UPPER(Function_desc) AS Function_desc, Function_ID FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & ddDepartment.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        ddFunction.DataTextField = ("Function_desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")

    End Sub

    Protected Sub btnNewPosition_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnNewPosition.Text = "New" Then
            ddPosition.Visible = False
            txtPositionDesc.Visible = True
            txtPositionDesc.Text = ""
            btnNewPosition.Text = "Search"

        ElseIf btnNewPosition.Text = "Search" Then
            ddPosition.Visible = True
            txtPositionDesc.Visible = False
            txtPositionDesc.Text = ""
            btnNewPosition.Text = "New"

        End If

    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If btnSave.Text = "SAVE" Then
                '=== CHECKING OF POSITION ===
                If btnNewPosition.Text = "New" Then
                    '=== VERIFICATION ===
                    'Select existing position 
                    If txtName.Text = "" Or ddFunction.SelectedItem.Text = "Select" Or ddPosition.SelectedItem.Text = "Select" Or ddDeptHead.SelectedItem.Text = "Select" Or ddIsActive.SelectedItem.Text = "Select" Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "All fields are required.")
                        Exit Sub
                    Else
                        '=== SAVE SIGNATORY DETAILS ===
                        Dim VerifyHead As Integer = 0
                        If ddDeptHead.SelectedItem.Value = 2 Then
                            VerifyHead = objDerived.GetValue("SELECT TOP(1) EmpID FROM dbo.tb_Signatories WHERE isDeptHead = 'Yes' AND isActive = 1 AND deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_Key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
                        End If

                        If VerifyHead = 0 Then
                            objDerived.GetRecords("INSERT INTO dbo.tb_Signatories (Full_Name,Position_ID,isDeptHead,deptid,division_Key,isActive,isInspector) " &
                                                " VALUES ('" & txtName.Text.ToUpper() & "','" & ddPosition.SelectedItem.Value & "','" & ddDeptHead.SelectedItem.Text & "','" & ddDepartment.SelectedItem.Value & "', " &
                                                " '" & ddFunction.SelectedItem.Value & "','" & ddIsActive.SelectedItem.Value & "','" & ddisInspector.SelectedItem.Value & "')", CommandType.Text)
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                            PageLoadDefault()

                            ddDepartment.Enabled = False
                            ddFunction.Enabled = False
                            txtName.Enabled = False
                            txtPositionDesc.Enabled = False
                            ddDeptHead.Enabled = False
                            ddIsActive.Enabled = False

                        Else
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Department head was already assigned to this office.")
                            Exit Sub
                        End If

                    End If

                ElseIf btnNewPosition.Text = "Search" Then
                    '=== VERIFICATION ===
                    'New position
                    If txtName.Text = "" Or ddFunction.SelectedItem.Text = "Select" Or txtPositionDesc.Text = "" Or ddDeptHead.SelectedItem.Text = "Select" Or ddIsActive.SelectedItem.Text = "Select" Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "All fields are required.")
                        Exit Sub

                    Else
                        Try
                            Dim Position_ID As Integer
                            Position_ID = objDerived.GetValue("SELECT DISTINCT Position_ID FROM dbo.m_position WHERE position_desc LIKE '" & replaceapostrophe(txtPositionDesc.Text) & "'", CommandType.Text)
                            If Position_ID = 0 Then
                                lblNoti.Visible = False

                                '=== SAVE POSITION DETAILS ===
                                objDerived.GetRecords("INSERT INTO dbo.m_position (position_desc,dept_id) VALUES('" & replaceapostrophe(txtPositionDesc.Text) & "', '" & ddDepartment.SelectedItem.Value & "')", CommandType.Text)
                                Dim PositionID As Integer
                                PositionID = objDerived.GetValue("SELECT TOP(1) Position_ID FROM dbo.m_position ORDER BY Position_ID DESC", CommandType.Text)

                                '=== SAVE SIGNATORY DETAILS ===
                                Dim VerifyHead As Integer = 0
                                If ddDeptHead.SelectedItem.Value = 2 Then
                                    VerifyHead = objDerived.GetValue("SELECT TOP(1) EmpID FROM dbo.tb_Signatories WHERE isDeptHead = 'Yes' AND isActive = 1 AND deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_Key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
                                End If

                                If VerifyHead = 0 Then
                                    objDerived.GetRecords("INSERT INTO dbo.tb_Signatories (Full_Name,Position_ID,isDeptHead,deptid,division_Key,isActive,isInspector) " &
                                                            " VALUES ('" & txtName.Text.ToUpper() & "','" & PositionID & "','" & ddDeptHead.SelectedItem.Text & "','" & ddDepartment.SelectedItem.Value & "', " &
                                                            " '" & ddFunction.SelectedItem.Value & "','" & ddIsActive.SelectedItem.Value & "','" & ddisInspector.SelectedItem.Value & "')", CommandType.Text)
                                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                                    PageLoadDefault()

                                    ddDepartment.Enabled = False
                                    ddFunction.Enabled = False
                                    txtName.Enabled = False
                                    txtPositionDesc.Enabled = False
                                    ddDeptHead.Enabled = False
                                    ddIsActive.Enabled = False

                                Else
                                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Department head was already assigned to this office.")
                                    Exit Sub
                                End If

                            Else
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Position already exist.")
                                lblNoti.Visible = True
                                Exit Sub
                            End If
                        Catch ex As Exception
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error occured during saving, contact administrator.")
                        End Try

                    End If
                End If

            ElseIf btnSave.Text = "UPDATE" Then
                objDerived.GetRecords("UPDATE [dbo].[tb_Signatories] SET [isDeptHead] = '" & ddDeptHead.SelectedItem.Text & "', [isActive] = '" & ddIsActive.SelectedItem.Value & "',[isInspector] = '" & ddisInspector.SelectedItem.Value & "' WHERE [EmpID] = '" & grdSignatories.SelectedDataKey("EmpID") & "'", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")

                PageLoadDefault()

                ddDepartment.Enabled = False
                ddFunction.Enabled = False
                txtName.Enabled = False
                txtPositionDesc.Enabled = False
                ddDeptHead.Enabled = False
                ddIsActive.Enabled = False

            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong with the process, pls refresh the system to continue.")

            End If
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/filemaintenance/t_Signatories_v2.aspx")
    End Sub

    Protected Sub btnSearchSignatories_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadSignatories()
    End Sub


    Protected Sub grdSignatories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSignatories.SelectedIndexChanged
        ddDepartment.DataSource = objDerived.GetDataTable("SELECT DISTINCT UPPER(RC_Name) AS RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions", CommandType.Text)
        ddDepartment.DataTextField = ("RC_Name")
        ddDepartment.DataValueField = ("RC_ID")
        ddDepartment.DataBind()
        ddDepartment.SelectedValue = grdSignatories.SelectedDataKey("RC_ID")

        ddFunction.DataSource = objDerived.GetDataTable("SELECT DISTINCT UPPER(Function_desc) AS Function_desc, Function_ID FROM dbo.View_RespCenter_withFunctions", CommandType.Text)
        ddFunction.DataTextField = ("Function_desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.SelectedValue = CType(grdSignatories.SelectedDataKey("Function_ID"), Integer)

        btnNewPosition.Enabled = False
        btnNewPosition.Text = "Search"

        ddPosition.Visible = False
        txtPositionDesc.Visible = True

        txtName.Text = grdSignatories.SelectedDataKey("FullName")
        txtPositionDesc.Text = grdSignatories.SelectedDataKey("Position_Desc")
        ddDeptHead.SelectedItem.Text = grdSignatories.SelectedDataKey("isDeptHead")
        ddIsActive.SelectedValue = grdSignatories.SelectedDataKey("isActive")
        ddisInspector.SelectedValue = grdSignatories.SelectedDataKey("isInspector")

        ddDepartment.Enabled = False
        ddFunction.Enabled = False
        txtName.Enabled = False
        txtPositionDesc.Enabled = False

        btnSave.Text = "UPDATE"

    End Sub

    Protected Sub grdSignatories_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

        grdSignatories.DataSource = dtSignatories
        grdSignatories.PageIndex = e.NewPageIndex
        grdSignatories.DataBind()

    End Sub
    Protected Sub grdSignatories_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSignatories.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Get the value of the IsActive column
            Dim isActive As Boolean = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "isActive"))

            ' Set the desired colors based on the IsActive value
            Dim inactiveBackColor As Color = Color.Red
            Dim inactiveForeColor As Color = Color.White
            Dim activeBackColor As Color = grdSignatories.RowStyle.BackColor
            Dim activeForeColor As Color = grdSignatories.RowStyle.ForeColor

            ' Set the row colors based on the IsActive value
            If isActive Then
                e.Row.BackColor = activeBackColor
                e.Row.ForeColor = activeForeColor
            Else
                e.Row.BackColor = inactiveBackColor
                e.Row.ForeColor = inactiveForeColor
            End If
        End If
    End Sub
End Class
