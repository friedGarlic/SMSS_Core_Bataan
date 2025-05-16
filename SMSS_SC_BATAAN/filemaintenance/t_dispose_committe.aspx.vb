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
            Dim dtmembers As New DataTable
            dtmembers = objDerived.GetDataTable("Select * from dbo.View_Disposal_Committe_Members", CommandType.Text)
            If dtmembers.Rows.Count = 0 Then
                grdDisposalComm.DataSource = Nothing
                grdDisposalComm.DataBind()
            Else
                grdDisposalComm.DataSource = dtmembers
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
        ddPosition.Text = grdDisposalComm.SelectedDataKey("Position_Desc")

        'Dim x As New DataTable
        'x = objDerived.GetDataTable("Select * from dbo.tb_Signatories order by Full_Name", CommandType.Text)
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

        ' It is not necessary to declare x as a new DataTable since it's immediately overwritten

        ddPosition.Enabled = True
        ddNames.Enabled = True
        txtDepartment.Enabled = True
        ddStatus.Enabled = True

        Session("Action") = "UPDATE"
    End Sub

    Protected Sub ddNames_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim dep As String = objDerived.GetValue("Select office_name from HRMS.view_signatory where empsig_id ='" & ddNames.SelectedItem.Value & "'", CommandType.Text)
        txtDepartment.Text = dep


        btnsave.Enabled = True
        btncancel.Enabled = True
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If Session("Action") = "UPDATE" Then
            With objDC
                .DC_ID = grdDisposalComm.SelectedDataKey("DC_ID")
                .Name = ddNames.SelectedItem.Text
                .DC_position_id = grdDisposalComm.SelectedDataKey("DC_position_id")
                .empsig_id = ddNames.SelectedItem.Value
                .Department = txtDepartment.Text
                .Status = ddStatus.selecteditem.value
                .Status_Desc = ddStatus.selecteditem.text
                .update()
            End With
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Disposal committee members has been successfully updated.")

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
                .DC_ID = 0
                .Name = ddNames.SelectedItem.Text
                .DC_position_id = pos_id
                .empsig_id = ddNames.SelectedItem.Value
                .Department = txtDepartment.Text
                .Status = ddStatus.selecteditem.value
                .Status_Desc = ddStatus.selecteditem.text
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

        ddNames.SelectedItem.Text = "Select"

        Dim dtmembers As New DataTable
        dtmembers = objDerived.GetDataTable("Select * from dbo.View_Disposal_Committe_Members", CommandType.Text)
        If dtmembers.Rows.Count = 0 Then
            grdDisposalComm.DataSource = Nothing
            grdDisposalComm.DataBind()
        Else
            grdDisposalComm.DataSource = dtmembers
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
