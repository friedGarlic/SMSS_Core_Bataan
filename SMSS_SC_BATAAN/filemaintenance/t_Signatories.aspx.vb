Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class filemaintenance_t_Signatories
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal

    Dim obj_mSignatory As New FM_Signatories.m_Signatory
    Dim dt_mSignatoru As New DataTable

    Dim obj_EmpSig As New FM_Signatories.m_Emp_Signatory
    Dim dt_EmpSig As New DataTable

    Dim obj_m_emp_payroll_info As New FM_Signatories.pay_m_emp_payroll_info
    Dim dt_m_emp_payroll_info As New DataTable

    Private Property dtEmployee() As DataTable
        Get
            Return CType(Session("dtEmployee"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtEmployee") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objAccess As New AccessRule
        If Session("@UserName") = "" Then
            Response.Redirect("~/SessionExpired.aspx")
        End If

        objAccess.GetAccessRight(Session("@UserName"), Page)
        If objAccess.HasAccess = False Then
            Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            With Me
                Me.showAllDept.Value = 0
                .grdSignatory.Style.Add("table-layout", "fixed")
                .grdAddSignatory.Style.Add("table-layout", "fixed")
                .grdAddSignatory.Attributes.Add("bordercolor", "dimgray")
            End With

            grdSignatory.DataSource = Nothing
            grdSignatory.DataBind()

            Dim pRC As New DataTable
            pRC = objDerived.GetDataTable("SELECT DISTINCT RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
            drpOffice.DataSource = CType(pRC, DataTable)
            drpOffice.DataTextField = ("RC_Name")
            drpOffice.DataValueField = ("RC_ID")
            drpOffice.DataBind()
            drpOffice.Items.Insert(0, "Select")


            drpDepartment.Enabled = True

            '=-= UPDATE SIGNATORIES
            Dim dtDeptUpdate As New DataTable
            dtDeptUpdate = objDerived.GetDataTable("SELECT * FROM HRMS.vw_m_department order BY deptdesc", CommandType.Text)
            drpUpdateDepartment.DataSource = dtDeptUpdate
            drpUpdateDepartment.DataTextField = ("deptdesc")
            drpUpdateDepartment.DataValueField = ("deptid")
            drpUpdateDepartment.DataBind()
            drpUpdateDepartment.Items.Insert(0, "Select")

            drpUpdateFunction.DataSource = Nothing
            drpUpdateFunction.DataBind()
            drpUpdateFunction.Items.Insert(0, "Select")

            drpAddSigPosition.DataSource = objDerived.GetDataTable("Select * from dbo.m_position order by position_desc", CommandType.Text)
            drpAddSigPosition.DataTextField = ("position_desc")
            drpAddSigPosition.DataValueField = ("position_id")
            drpAddSigPosition.DataBind()
            drpAddSigPosition.Items.Insert(0, "Select")

            Session.Add("Page", "File Maintenance")

            btnList.Visible = False
            btnAdd.Visible = True
            Me.MultiView1.SetActiveView(Me.View2)


            txtname.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchEmp.ClientID & "')")

        End If

    End Sub

    Public Sub LoadFunction()
        Dim objs As New BaseClasses.Signatory
        'Me.drpFunction.DataSource = objs.GetDataTable("select * from dbo.view_Function_per_office where office_id = '" & Me.drpDepartment.SelectedValue & "'", CommandType.Text)
        'Me.drpFunction.DataTextField = "Function_Desc"
        'Me.drpFunction.DataValueField = "Function_ID"
        'Me.drpFunction.DataBind()

        Dim pFunction As New DataTable
        pFunction = Nothing
        drpFunction.DataSource = pFunction
        drpFunction.DataBind()

        pFunction = objs.GetDataTable("select Office_id as Rc_id , Function_id,Function_desc from ams.vw_functions  where Office_id = " & drpDepartment.SelectedItem.Value & "", CommandType.Text)
        drpFunction.DataSource = pFunction
        drpFunction.DataTextField = ("Function_Desc")
        drpFunction.DataValueField = ("Function_ID")
        drpFunction.DataBind()
        drpFunction.Items.Insert(0, "Select")

    End Sub
    Protected Sub LoadUpdateFunction()
        Dim dtUpFunct As New DataTable
        dtUpFunct = objDerived.GetDataTable("select Office_id as Rc_id , Function_id,Function_desc from ams.vw_functions  where Office_id = " & drpUpdateDepartment.SelectedItem.Value & "", CommandType.Text)
        drpUpdateFunction.DataSource = dtUpFunct
        drpUpdateFunction.DataTextField = ("Function_Desc")
        drpUpdateFunction.DataValueField = ("Function_ID")
        drpUpdateFunction.DataBind()
        drpUpdateFunction.Items.Insert(0, "Select")

    End Sub
    Public Sub LoadGrid()
        Dim objs As New BaseClasses.Signatory
        If Me.showAllDept.Value = 0 Then
            grdSignatory.DataSource = objs.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & drpOffice.SelectedItem.Value & "' ORDER BY isDeptHead DESC, Function_desc", CommandType.Text)
        Else
            grdSignatory.DataSource = objs.GetDataTable("SELECT * FROM HRMS.view_signatory ORDER BY isDeptHead DESC, office_name, Function_desc ", CommandType.Text)
        End If
        grdSignatory.DataBind()
    End Sub

    Private Sub FocusControl(ByVal ctrl As Control)
        'Define the JavaScript function for the specified control.
        Dim focusScript As String = "<script language='javascript'>" & _
        "document.getElementById('" + ctrl.ClientID & _
        "').focus();</script>"

        'Add the JavaScript code to the page.
        ClientScript.RegisterStartupScript(Me.GetType, "FocusScript", focusScript)
    End Sub
    Protected Sub LoadRespCenter()
        Dim pRC As New DataTable
        pRC = Nothing

        pRC = objDerived.GetDataTable("Select * from dbo.view_Code_RespCenters order by RespCenter2", CommandType.Text)
        drpDepartment.DataSource = CType(pRC, DataTable)
        drpDepartment.DataTextField = ("RespCenter2")
        drpDepartment.DataValueField = ("Office_ID")
        drpDepartment.DataBind()
        drpDepartment.Items.Insert(0, "Select")

        drpDepartment.Enabled = True
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Session.Add("State", "Add")
        'lblSignatory.Text = "Add Signatory"
        grdSignatory.SelectedIndex = -1
        ClearPopUp()

        txtAddPosition.Visible = True
        btnSearchPos.Visible = True
        drpAddSigPosition.Visible = False
        btnAddPosition.Visible = False

        drpDepartment.Enabled = True
        txtAddPosition.Enabled = True
        lblrequired.Visible = False


        'dtEmployee = objDerived.GetDataTable("SELECT UPPER(full_name) AS full_name, UPPER(PositionDesc) AS PositionDesc FROM dbo.View_GeoPIMS_Employee ORDER BY full_name", CommandType.Text)
        'grdAddSignatory.DataSource = dtEmployee
        'grdAddSignatory.DataBind()

        grdEmployee.DataSource = Nothing
        grdEmployee.DataBind()

        txtEmployee.Text = ""

        Dim pRC As New DataTable
        pRC = Nothing

        pRC = objDerived.GetDataTable("SELECT * FROM HRMS.vw_m_department order BY deptdesc", CommandType.Text)
        drpDepartment.DataSource = pRC
        drpDepartment.DataTextField = ("deptdesc")
        drpDepartment.DataValueField = ("deptid")
        drpDepartment.DataBind()
        drpDepartment.Items.Insert(0, "Select")

        drpDepartment.Enabled = True

        drpFunction.Items.Insert(0, "Select")

        btnAdd.Visible = False
        btnList.Visible = True
        Me.MultiView1.SetActiveView(Me.View1)

     
    End Sub
    Protected Sub ClearPopUp()
        Me.grdAddSignatory.SelectedIndex = -1
        Me.drpFunction.Items.Clear()
        Me.drpDepartment.Items.Clear()
        Me.drpDepartment.Enabled = False
        Me.drpFunction.Enabled = False
    End Sub
    Protected Sub grdSignatory_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdSignatory.PageIndexChanging
        Dim objs As New BaseClasses.Signatory
        If Me.showAllDept.Value = 0 Then
            grdSignatory.DataSource = objs.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & drpOffice.SelectedItem.Value & "' ORDER BY isDeptHead DESC, Function_desc", CommandType.Text)
        Else
            grdSignatory.DataSource = objs.GetDataTable("SELECT * FROM HRMS.view_signatory ORDER BY isDeptHead DESC, office_name, Function_desc ", CommandType.Text)
        End If
        grdSignatory.PageIndex = e.NewPageIndex
        grdSignatory.DataBind()

    End Sub
    Protected Sub grdSignatory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSignatory.SelectedIndexChanged
        txtUpdateEmpName.Text = Server.HtmlDecode(Me.grdSignatory.SelectedRow.Cells(4).Text)

        drpPosition.DataSource = objDerived.GetDataTable("SELECT DISTINCT position_desc,position_id from dbo.m_position ORDER BY position_desc", CommandType.Text)
        drpPosition.DataTextField = ("position_desc")
        drpPosition.DataValueField = ("position_id")
        drpPosition.DataBind()
        drpPosition.SelectedValue = grdSignatory.SelectedDataKey("position_id")
     
        If Me.grdSignatory.SelectedRow.Cells(11).Text = "Yes" Then
            Me.drpUpdateDeptHead.SelectedIndex = 1
        Else
            Me.drpUpdateDeptHead.SelectedIndex = 0
        End If

        Dim dtDeptUpdate As New DataTable
        dtDeptUpdate = objDerived.GetDataTable("SELECT * FROM HRMS.vw_m_department ORDER BY deptdesc", CommandType.Text)
        drpUpdateDepartment.DataSource = dtDeptUpdate
        drpUpdateDepartment.DataTextField = ("deptdesc")
        drpUpdateDepartment.DataValueField = ("deptid")
        drpUpdateDepartment.DataBind()
        drpUpdateDepartment.SelectedValue = grdSignatory.SelectedDataKey("deptID")


        Dim dtUpFunct As New DataTable
        dtUpFunct = objDerived.GetDataTable("select Office_id as Rc_id , Function_id,Function_desc from ams.vw_functions  where Office_id = " & drpUpdateDepartment.SelectedItem.Value & " ORDER BY Function_desc", CommandType.Text)
        drpUpdateFunction.DataSource = dtUpFunct
        drpUpdateFunction.DataTextField = ("Function_Desc")
        drpUpdateFunction.DataValueField = ("Function_ID")
        drpUpdateFunction.DataBind()
        drpUpdateFunction.SelectedValue = grdSignatory.SelectedDataKey("division_key")



        Me.ModalPopupExtender2.Show()
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        '=== Check Dept Head
        If drpDeptHead.SelectedValue = True Then
            Dim head As Long = objDerived.GetValue("SELECT Signatory_ID FROM BOS.m_Signatory WHERE deptid = '" & drpDepartment.SelectedItem.Value & "' AND division_key = '" & drpFunction.SelectedValue & "' AND isDeptHead = 1", CommandType.Text)
            If head <> 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "(1) One department head only.")
                'ModalPopupExtender1.Show()
                Exit Sub
            End If
        End If

        '=== CHECK EMPLOYEE IF EXISTING
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & drpDepartment.SelectedItem.Value & "' AND division_key = '" & drpFunction.SelectedValue & "' AND full_name = '" & txtEmployee.Text & "'", CommandType.Text)
        If dt.Rows.Count <> 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Employee already exists.")
            Exit Sub
        End If

        Dim position As String = drpAddSigPosition.SelectedItem.Text

        drpAddSigPosition.DataSource = objDerived.GetDataTable("Select * from dbo.m_position order by position_desc", CommandType.Text)
        drpAddSigPosition.DataTextField = ("position_desc")
        drpAddSigPosition.DataValueField = ("position_id")
        drpAddSigPosition.DataBind()
        drpAddSigPosition.Items.Insert(0, "Select")

        If txtEmployee.Text = "" Or drpDepartment.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
            'ModalPopupExtender1.Show()
            Exit Sub

        Else

            If btnSearchPos.Visible = True Then
                If txtAddPosition.Text = "" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
                    'ModalPopupExtender1.Show()
                    Exit Sub
                End If
            ElseIf btnAddPosition.Visible = True Then
                If position = "Select" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
                    'ModalPopupExtender1.Show()
                    Exit Sub
                End If
            End If

            'HRMS.pay_m_emp_payroll_info
            obj_m_emp_payroll_info.deptid = drpDepartment.SelectedItem.Value
            obj_m_emp_payroll_info.division_key = drpFunction.SelectedValue
            Dim empid As Long = obj_m_emp_payroll_info.save()

            'objDerived.GetDataTable("INSERT INTO HRMS.pay_m_emp_payroll_info (deptid,division_key) Values ('" & drpDepartment.SelectedValue & "' ,'" & drpFunction.SelectedValue & "')", CommandType.Text)

            'dbo.m_position
            Dim pos_id As Integer
            Dim pos As New DataTable

            If btnSearchPos.Visible = True Then
                pos = objDerived.GetDataTable("Select * from dbo.m_position where position_desc like '" & txtAddPosition.Text & "'", CommandType.Text)
            ElseIf btnAddPosition.Visible = True Then
                pos = objDerived.GetDataTable("Select * from dbo.m_position where position_desc like '" & position & "'", CommandType.Text)
            End If

            If pos.Rows.Count = 0 Then
                If btnSearchPos.Visible = True Then
                    Me.objDerived.Execute("insert into dbo.m_position(position_desc) values('" & txtAddPosition.Text & "')", CommandType.Text)
                    pos_id = objDerived.GetValue("Select position_id from dbo.m_position where position_desc = '" & txtAddPosition.Text & "'", CommandType.Text)

                ElseIf btnAddPosition.Visible = True Then
                    Me.objDerived.Execute("insert into dbo.m_position(position_desc) values('" & position & "')", CommandType.Text)
                    pos_id = objDerived.GetValue("Select position_id from dbo.m_position where position_desc = '" & position & "'", CommandType.Text)

                End If
            Else
                If btnSearchPos.Visible = True Then
                    pos_id = objDerived.GetValue("Select position_id from dbo.m_position where position_desc = '" & txtAddPosition.Text & "'", CommandType.Text)
                ElseIf btnAddPosition.Visible = True Then
                    pos_id = objDerived.GetValue("Select position_id from dbo.m_position where position_desc = '" & position & "'", CommandType.Text)
                End If
            End If

            'BOS.m_Emp_Signatory
            obj_EmpSig.position_id = pos_id
            obj_EmpSig.empid = empid
            obj_EmpSig.full_name = txtEmployee.Text
            If txtEffectiveDate.Text = "" Then
                obj_EmpSig.effectivity_date = Date.Today.ToString("MM/dd/yyyy")
            End If

            If btnSearchPos.Visible = True Then
                obj_EmpSig.position_desc = txtAddPosition.Text
            ElseIf btnAddPosition.Visible = True Then
                obj_EmpSig.position_desc = position
            End If

            Dim empsig_id As Long = obj_EmpSig.save()

            'm_Signatory
            obj_mSignatory.deptid = drpDepartment.SelectedValue
            obj_mSignatory.division_key = drpFunction.SelectedValue
            obj_mSignatory.isDeptHead = drpDeptHead.SelectedValue
            obj_mSignatory.empsig_ID = empsig_id
            Dim Signatory_ID As Long = obj_mSignatory.save()


            Session("RC_ID") = drpDepartment.SelectedItem.Value
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Signatory has been successfully saved.")

            Dim pRC As New DataTable
            pRC = Nothing

            pRC = objDerived.GetDataTable("SELECT * FROM HRMS.vw_m_department order BY deptdesc", CommandType.Text)
            drpDepartment.DataSource = pRC
            drpDepartment.DataTextField = ("deptdesc")
            drpDepartment.DataValueField = ("deptid")
            drpDepartment.DataBind()
            drpDepartment.Items.Insert(0, "Select")
            drpDepartment.SelectedValue = Session("RC_ID")
        End If

        drpDepartment.Enabled = True
        drpFunction.DataSource = Nothing
        drpFunction.DataBind()

        txtEmployee.Text = ""
        txtAddPosition.Text = ""
        txtEffectiveDate.Text = ""

        drpDeptHead.DataSource = Nothing
        drpDeptHead.DataBind()

        'ModalPopupExtender1.Show()

        '=== RELOAD SIGNATORY LIST
        Dim objs As New BaseClasses.Signatory
        grdEmployee.DataSource = objs.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & Session("RC_ID") & "'", CommandType.Text)
        grdEmployee.DataBind()

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtEmployee.Text = ""
        txtAddPosition.Text = ""

        'Me.ModalPopupExtender1.Hide()
    End Sub

    Protected Sub grdAddSignatory_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdAddSignatory.PageIndexChanging
        Dim employee As New DataTable
        If ddSort.SelectedItem.Value = 1 Then
            employee = objDerived.GetDataTable("Select * from dbo.View_GeoPIMS_Employee order by full_name", CommandType.Text)
        ElseIf ddSort.SelectedItem.Value = 2 Then
            employee = objDerived.GetDataTable("Select * from dbo.View_GeoPIMS_Employee order by positiondesc", CommandType.Text)
        End If
        grdAddSignatory.PageIndex = e.NewPageIndex
        grdAddSignatory.DataSource = employee
        grdAddSignatory.DataBind()
        'ModalPopupExtender1.Show()
    End Sub

    Protected Sub grdAddSignatory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAddSignatory.SelectedIndexChanged
        txtAddPosition.Visible = True
        drpAddSigPosition.Visible = False

        txtEmployee.Text = grdAddSignatory.SelectedDataKey("full_name")
        txtAddPosition.Text = grdAddSignatory.SelectedDataKey("positiondesc")

        drpDepartment.Enabled = True
        drpFunction.DataSource = Nothing
        drpFunction.DataBind()

        drpDeptHead.DataSource = Nothing
        drpDeptHead.DataBind()
        txtEffectiveDate.Text = ""

        'ModalPopupExtender1.Show()

    End Sub

    Protected Sub btnSearchEmpName_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ClearPopUp()
        'Me.ModalPopupExtender1.Show()
    End Sub

    Protected Sub btnSearchPosition_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ClearPopUp()
        'Me.ModalPopupExtender1.Show()
    End Sub

    Protected Sub btnSearchDept_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ClearPopUp()
        'Me.ModalPopupExtender1.Show()
    End Sub

    Protected Sub drpDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        drpFunction.Enabled = True
        drpAddSigPosition.Enabled = True
        drpDeptHead.Enabled = True
        txtEffectiveDate.Enabled = True

        Dim x As Integer = drpDepartment.SelectedItem.Value
        Dim y As String = drpDepartment.SelectedItem.Text

        LoadFunction()

        Dim objs As New BaseClasses.Signatory
        grdEmployee.DataSource = objs.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & drpDepartment.SelectedItem.Value & "'", CommandType.Text)
        grdEmployee.DataBind()

        'ModalPopupExtender1.Show()
    End Sub

    Protected Sub drpUpdateDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadUpdateFunction()
        ModalPopupExtender2.Show()
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=-= Check Dept Head
        If drpUpdateDeptHead.SelectedValue = True Then
            Dim head As Long = objDerived.GetValue("SELECT Signatory_ID FROM BOS.m_Signatory WHERE deptid = '" & drpUpdateDepartment.SelectedValue & "' AND division_key = '" & drpUpdateFunction.SelectedValue & "' AND isDeptHead = 1", CommandType.Text)
            If head <> 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "(1) One department head only.")
                Exit Sub
            End If
        End If

        Dim objEmpSig As New BaseClasses.m_Emp_Signatory
        Dim x As Integer = objEmpSig.GetValue("SELECT empsig_id FROM BOS.m_Emp_Signatory WHERE empid = " & Me.grdSignatory.SelectedDataKey(2).ToString, CommandType.Text)
        With objEmpSig
            .position_id = drpPosition.SelectedItem.Value 'grdSignatory.SelectedDataKey(1).ToString
            .empid = grdSignatory.SelectedDataKey(2).ToString
            .full_name = txtUpdateEmpName.Text
            .effectivity_date = Date.Today.ToString("MM/dd/yyyy")
            .position_desc = drpPosition.SelectedItem.Text 'Me.txtUpdatePosition.Text
        End With

        If x = 0 Then
            'SAVE EMP
            objEmpSig.save()
            x = objEmpSig.GetValue("SELECT MAX(empsig_id) as empsig_ID FROM BOS.m_Emp_Signatory", CommandType.Text)
        Else
            'UPDATE EMP
            objEmpSig.empsig_id = x
            objEmpSig.update()
        End If

        Dim objs As New BaseClasses.Signatory
        With objs
            .Signatory_ID = Me.grdSignatory.SelectedDataKey(0).ToString
            .deptid = Me.drpUpdateDepartment.SelectedValue
            .division_key = Me.drpUpdateFunction.SelectedValue
            .isDeptHead = Me.drpUpdateDeptHead.SelectedValue
            .empsig_ID = x
            .update_signatory()
        End With


        Me.mpeConfirm.Show()

        Me.grdSignatory.SelectedIndex = -1
        LoadGrid()
        Me.ModalPopupExtender2.Hide()
    End Sub

    Protected Sub SelectRespCenter()
        Dim obj As New BaseClasses.AccountClassAcounts
        Me.DeptID.Value = obj.GetValue("SELECT Office_ID FROM dbo.[view_Code_RespCenters] WHERE Func_Per_Office_ID = " & Me.drpOffice.SelectedValue, CommandType.Text)
        Me.FuncID.Value = obj.GetValue("SELECT Function_ID FROM dbo.[view_Code_RespCenters] WHERE Func_Per_Office_ID = " & Me.drpOffice.SelectedValue, CommandType.Text)
    End Sub
    Protected Sub drpFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'ModalPopupExtender1.Show()
    End Sub

    Protected Sub drpUpdateFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnAddPosition_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        drpAddSigPosition.Visible = False
        txtAddPosition.Visible = True
        btnAddPosition.Enabled = False

        btnsavepos.Visible = False
        btncancelpos.Visible = False
        txtAddPosition.Enabled = True
        'btnOk.Enabled = False

        btnSearchPos.Visible = True
        btnAddPosition.Visible = False

        'ModalPopupExtender1.Show()

    End Sub

    Protected Sub btncancelpos_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        drpAddSigPosition.DataSource = objDerived.GetDataTable("Select * from dbo.m_position order by position_desc", CommandType.Text)
        drpAddSigPosition.DataTextField = ("position_desc")
        drpAddSigPosition.DataValueField = ("position_id")
        drpAddSigPosition.DataBind()
        drpAddSigPosition.Items.Insert(0, "Select")

        drpAddSigPosition.Visible = True
        txtAddPosition.Visible = False
        btnAddPosition.Enabled = True

        btnsavepos.Visible = False
        btncancelpos.Visible = False
        lblrequired.Visible = False
        btnAddPosition.Visible = True

        'ModalPopupExtender1.Show()
    End Sub

    Protected Sub btnsavepos_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtAddPosition.Text = "" Then
            lblrequired.Visible = True
            btnAddPosition.Visible = False
        Else
            lblrequired.Visible = False
            btnAddPosition.Visible = True
            drpAddSigPosition.Visible = True
            txtAddPosition.Visible = False
            btnAddPosition.Enabled = True

            btnsavepos.Visible = False
            btncancelpos.Visible = False
            drpAddSigPosition.Enabled = True
            btnOk.Enabled = True

            Dim pos As New DataTable
            pos = objDerived.GetDataTable("Select * from dbo.m_position where position_desc like '" & txtAddPosition.Text & "'", CommandType.Text)
            If pos.Rows.Count = 0 Then '=== save dbo.m_position
                Me.objDerived.Execute("insert into dbo.m_position(position_desc) values('" & txtAddPosition.Text & "')", CommandType.Text)
            End If

            Dim pos_id As Integer
            pos_id = objDerived.GetValue("Select position_id from dbo.m_position where position_desc = '" & txtAddPosition.Text & "'", CommandType.Text)


            'objDerived.GetRecords("Insert into dbo.m_position (position_desc,dept_id) Values ('" & txtAddPosition.Text & "','" & drpDepartment.SelectedItem.Value & "')", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Position has been successfully saved.")
        End If

        drpAddSigPosition.DataSource = objDerived.GetDataTable("Select * from dbo.m_position order by position_desc", CommandType.Text)
        drpAddSigPosition.DataTextField = ("position_desc")
        drpAddSigPosition.DataValueField = ("position_id")
        drpAddSigPosition.DataBind()
        drpAddSigPosition.Items.Insert(0, "Select")

        'ModalPopupExtender1.Show()
    End Sub

    Protected Sub cbShowAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.cbShowAll.Checked = True Then
            showAllDept.Value = 1
            drpOffice.Enabled = False
            LoadGrid()
        Else
            showAllDept.Value = 0
            drpOffice.Enabled = True

            grdSignatory.DataSource = Nothing
            grdSignatory.DataBind()

        End If
    End Sub
    Protected Sub drpOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadGrid()
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function


    Protected Sub btnSearchEmp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchEmp.Click
        Dim myview As DataView
        myview = dtEmployee.DefaultView
        myview.RowFilter = "full_name like '%" & replaceapostrophe(txtname.Text.ToString) & "%'"
        grdAddSignatory.DataSource = myview
        grdAddSignatory.DataBind()
        grdAddSignatory.PageIndex = 0

        Session("SearchEmp") = 1
    End Sub

    Protected Sub btnSearchPos_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        drpAddSigPosition.Visible = True
        txtAddPosition.Visible = False
        btnAddPosition.Visible = True
        btnSearchPos.Visible = False
        btnAddPosition.Enabled = True

        btnsavepos.Visible = False
        btncancelpos.Visible = False
        'ModalPopupExtender1.Show()

    End Sub

    Protected Sub ddSort_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim employee As New DataTable

        If ddSort.SelectedItem.Value = 1 Then
            employee = objDerived.GetDataTable("Select * from dbo.View_GeoPIMS_Employee order by full_name", CommandType.Text)
        ElseIf ddSort.SelectedItem.Value = 2 Then
            employee = objDerived.GetDataTable("Select * from dbo.View_GeoPIMS_Employee order by positiondesc", CommandType.Text)
        End If

       grdAddSignatory.DataSource = employee
        grdAddSignatory.DataBind()

        'ModalPopupExtender1.Show()
    End Sub

    Protected Sub grdEmployee_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim objs As New BaseClasses.Signatory
        grdEmployee.DataSource = objs.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & drpDepartment.SelectedItem.Value & "'", CommandType.Text)
        grdEmployee.PageIndex = e.NewPageIndex
        grdEmployee.DataBind()
    End Sub

    Protected Sub btnList_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnList.Visible = False
        btnAdd.Visible = True
        Me.MultiView1.SetActiveView(Me.View2)
    End Sub
End Class


