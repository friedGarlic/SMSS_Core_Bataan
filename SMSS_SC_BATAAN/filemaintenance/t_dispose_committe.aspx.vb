Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class filemaintenance_t_dispose_committe
    Inherits System.Web.UI.Page
    Dim objAccess As New AccessRule
    Private objDerived As New DerivedDal

    Dim objDC As New FM_Signatories.TbDisposal_Committee_Members


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objAccess.GetAccessRight(Session("@UserName"), Page)
        If objAccess.HasAccess = False Then
            Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            Dim dtmembers As DataTable = objDerived.GetDataTable("SELECT * FROM dbo.View_Disposal_Committe_Members", CommandType.Text)

            If dtmembers IsNot Nothing AndAlso dtmembers.Rows.Count > 0 Then
                grdDisposalComm.DataSource = dtmembers
                grdDisposalComm.DataBind()
            Else
                grdDisposalComm.DataSource = Nothing
                grdDisposalComm.DataBind()
            End If

            ddPosition.Enabled = False
            ddNames.Enabled = False
            txtDepartment.Enabled = False
            btnsave.Enabled = False
            btncancel.Enabled = False
        End If
    End Sub


    Protected Sub grdDisposalComm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Get signatories list and bind to dropdown
        Dim signatoriesTable As DataTable = objDerived.GetDataTable("SELECT * FROM dbo.tb_Signatories ORDER BY Full_Name", CommandType.Text)
        With ddNames
            .DataSource = signatoriesTable
            .DataTextField = "Full_Name"
            .DataValueField = "EmpID"
            .DataBind()
            .Items.Insert(0, "Select")
        End With

        ' Rebind positions before selecting from it
        ddPosition.DataSource = objDerived.GetDataTable("SELECT UPPER(position_desc) AS position_desc, position_id FROM dbo.m_position ORDER BY position_desc", CommandType.Text)
        ddPosition.DataTextField = "position_desc"
        ddPosition.DataValueField = "position_id"
        ddPosition.DataBind()
        ddPosition.Items.Insert(0, "Select")

        ' Get member info from View_Disposal_Committe_Members
        Dim selectedDC_ID As String = grdDisposalComm.SelectedDataKey("DC_ID")
        Dim dtMember As DataTable = objDerived.GetDataTable(" SELECT empsig_id, pos_desc, Department, Status FROM dbo.View_Disposal_Committe_Members WHERE DC_ID = '" & selectedDC_ID & "'", CommandType.Text)

        If dtMember.Rows.Count > 0 Then
            Dim row As DataRow = dtMember.Rows(0)

            ' Select name
            Dim empID As Object = row("empsig_id")
            If empID IsNot Nothing AndAlso Not String.IsNullOrEmpty(empID.ToString()) Then
                If ddNames.Items.FindByValue(empID.ToString()) IsNot Nothing Then
                    ddNames.SelectedValue = empID.ToString()
                End If
            End If

            ' Select position (by text match)
            Dim posDesc As String = row("pos_desc").ToString()
            If ddPosition.Items.FindByText(posDesc) IsNot Nothing Then
                ddPosition.ClearSelection()
                ddPosition.Items.FindByText(posDesc).Selected = True
            End If

            ' Set department textbox
            txtDepartment.Text = row("Department").ToString()

            ' Set status
            Dim statusVal As String = row("Status").ToString()
            If ddStatus.Items.FindByValue(statusVal) IsNot Nothing Then
                ddStatus.SelectedValue = statusVal
            End If
        End If

        ' Enable inputs
        ddPosition.Enabled = True
        ddNames.Enabled = True
        txtDepartment.Enabled = True
        ddStatus.Enabled = True
        btnsave.Enabled = True

        ' Mark for update
        Session("Action") = "UPDATE"
    End Sub



    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)
    End Sub


    Protected Sub ddNames_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim dep As String = objDerived.GetValue("Select office_name from HRMS.view_signatory where empsig_id ='" & ddNames.SelectedItem.Value & "'", CommandType.Text)
        txtDepartment.Text = dep


        btnsave.Enabled = True
        btncancel.Enabled = True
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        AddTrace("ddPosition.SelectedValue: " & ddPosition.SelectedValue)
        If Session("Action") = "UPDATE" Then
            With objDC
                .DC_ID = grdDisposalComm.SelectedDataKey("DC_ID")
                .Name = ddNames.SelectedItem.Text
                .DC_position_id = grdDisposalComm.SelectedDataKey("DC_position_id")
                .empsig_id = ddNames.SelectedItem.Value
                .Department = txtDepartment.Text
                .Status = ddStatus.SelectedItem.Value
                .Status_Desc = ddStatus.SelectedItem.Text
                .update()
            End With



            ' Get the DC_position_id from the members table
            Dim DCpositionID As Object = objDerived.GetValue(" SELECT DC_position_id FROM AMS.TbDisposal_Committee_Members WHERE DC_ID = " & grdDisposalComm.SelectedDataKey("DC_ID"), CommandType.Text)


            ' Update the position description using the dropdown value
            If DCpositionID IsNot Nothing Then
                objDerived.Execute("UPDATE AMS.TbDisposal_Committe_Position SET Position_Desc = '" & ddPosition.SelectedValue & "', Position_Code = '" & ddPosition.SelectedValue & "' WHERE DC_position_id = " & DCpositionID, CommandType.Text)
            End If

            ' Show success message
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Disposal committee member has been successfully updated.")



        ElseIf Session("Action") = "ADD" Then
            If ddPosition.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up position.")
                Exit Sub
            End If

            Dim pos As New DataTable
            pos = objDerived.GetDataTable("Select * from AMS.TbDisposal_Committe_Position where Position_Desc like '" & ddPosition.Text & "'", CommandType.Text)
            If pos.Rows.Count = 0 Then
                Me.objDerived.Execute("insert into AMS.TbDisposal_Committe_Position(Position_Desc,Position_Code) values('" & ddPosition.Text & "','" & ddPosition.Text & "')", CommandType.Text)
            End If

            Dim pos_id As Integer
            pos_id = objDerived.GetValue("Select DC_position_id from AMS.TbDisposal_Committe_Position where Position_Desc like '" & ddPosition.Text & "'", CommandType.Text)

            With objDC
                '.DC_ID = 0
                .Name = ddNames.SelectedItem.Text
                .DC_position_id = pos_id
                .empsig_id = ddNames.SelectedItem.Value
                .Department = txtDepartment.Text
                .Status = ddStatus.SelectedItem.Value
                .Status_Desc = ddStatus.SelectedItem.Text
                .save()
            End With

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Disposal committee member has been successfully saved.")

        End If


        LoadMembers()
    End Sub

    Protected Sub LoadMembers()
        ddNames.Enabled = False
        btnsave.Enabled = False
        btncancel.Enabled = False

        ddPosition.Text = "Select"
        txtDepartment.Text = ""

        ddNames.DataSource = Nothing
        ddNames.DataBind()

        If ddNames.Items.Count = 0 Then
            ddNames.Items.Insert(0, "Select")
        Else
            ddNames.SelectedItem.Text = "Select"
        End If

        Dim dtmembers As DataTable = objDerived.GetDataTable("SELECT * FROM dbo.View_Disposal_Committe_Members", CommandType.Text)

        If dtmembers IsNot Nothing AndAlso dtmembers.Rows.Count > 0 Then
            grdDisposalComm.DataSource = dtmembers
            grdDisposalComm.DataBind()
        Else
            grdDisposalComm.DataSource = Nothing
            grdDisposalComm.DataBind()
        End If
    End Sub


    Protected Sub btnADD_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim x As New DataTable
        'x = objDerived.GetDataTable("Select * from dbo.tb_Signatories by Full_Name", CommandType.Text)
        'ddNames.DataSource = x
        'ddNames.DataTextField = ("Full_Name")
        'ddNames.DataValueField = ("EmpID")
        'ddNames.DataBind()
        'ddNames.Items.Insert(0, "Select")

        'Assuming objDerived Is already declared And instantiated elsewhere

        ' Using a clear and descriptive variable name
        Dim signatoriesTable As DataTable

        ' Directly assigning the DataTable without creating a new instance
        signatoriesTable = objDerived.GetDataTable("SELECT * FROM dbo.tb_Signatories ORDER BY Full_Name", CommandType.Text)

        ' Configuring the dropdown list (ddNames)
        With ddNames
            .DataSource = signatoriesTable
            .DataTextField = "Full_Name"
            .DataValueField = "EmpID"
            .DataBind()
            .Items.Insert(0, "Select")
        End With


        ddPosition.DataSource = objDerived.GetDataTable("SELECT UPPER(position_desc) AS position_desc,position_id FROM dbo.m_position ORDER BY position_desc", CommandType.Text)
        ddPosition.DataTextField = ("position_desc")
        ddPosition.DataValueField = ("position_id")
        ddPosition.DataBind()
        ddPosition.Items.Insert(0, "Select")

        ' It is not necessary to declare x as a new DataTable since it's immediately overwritten


        ddPosition.Enabled = True
        ' ddPosition.ReadOnly = False
        ddNames.Enabled = True
        txtDepartment.Enabled = True
        ddStatus.Enabled = True

        Session("Action") = "ADD"

    End Sub
    Protected Sub ddPosition_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class
