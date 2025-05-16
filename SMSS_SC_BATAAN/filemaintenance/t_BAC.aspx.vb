Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class filemaintenance_t_BAC
    Inherits System.Web.UI.Page
    Dim objAccess As New AccessRule
    Private objDerived As New DerivedDal
    Dim objBAC As New FM_Signatories.BAC_Members
    Dim serv As Boolean
    Private Property dtBAC() As DataTable
        Get
            Return CType(Session("dtBAC"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtBAC") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("@UserName") = "" Then
            Response.Redirect("~/SessionExpired.aspx")
        End If

        objAccess.GetAccessRight(Session("@UserName"), Page)
        If objAccess.HasAccess = False Then
            Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            RadioButtonList1.SelectedIndex = 0

            Me.MultiView1.SetActiveView(Me.View2)
            btnADD.Text = "ADD MEMBER"
            lblBAC.Text = "ADD MEMBER"
            LoadMembers()

        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadMembers()
        If Radiobuttonlist1.SelectedItem.text = "Goods" Then
            DdServ.SelectedItem.Text = "Goods"
            DDIsPubInfra.SelectedItem.Text = "Goods"
        Else
            DdServ.SelectedItem.Text = "Infrastructure"
            DDIsPubInfra.SelectedItem.Text = "Infrastructure"
        End If
    End Sub

    Protected Sub LoadMembers()
        dtBAC = objDerived.GetDataTable("Select name,position,ispublicInfra,code,empsig_id,Bac_postionID,id,isActive,isDefault, (Position_desc + ' (' + Code + ')') AS Position_desc from dbo.view_BAC where isPublicInfra = '" & RadioButtonList1.SelectedItem.Value & "' ORDER BY Position_Desc", CommandType.Text)
        grdBAC.DataSource = dtBAC
        grdBAC.DataBind()

        grdDefault.DataSource = objDerived.GetDataTable("SELECT *, (Position_desc + ' (' + Code + ')') AS BAC_Pos FROM [dbo].[View_BAC] WHERE [isDefault] = 1 ORDER BY BAC_Pos", CommandType.Text)
        grdDefault.DataBind()

    End Sub
    Protected Sub grdBAC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MultiView1.SetActiveView(Me.View1)
        lblBAC.text = "UPDATE MEMBER"
        ddBACpos.DataSource = objDerived.GetDataTable("SELECT BAC_PostionID, (Position_desc + ' (' + Code + ')') AS Position_desc FROM AMS.BAC_position ORDER BY Position_desc", CommandType.Text)
        ddBACpos.DataTextField = ("Position_desc")
        ddBACpos.DataValueField = ("BAC_PostionID")
        ddBACpos.DataBind()
        'ddBACpos.Items.Insert(0, "Select")
        ddBACpos.SelectedValue = grdBAC.SelectedDataKey("BAC_PostionID")

        lblName.Text = grdBAC.SelectedDataKey("Name")

        Session("ID") = grdBAC.SelectedDatakey("id")
        If grdBAC.SelectedDataKey("isPublicInfra") = "Infrastructure" Then
            DDIsPubInfra.SelectedIndex = 1
        Else
            DDIsPubInfra.SelectedIndex = 2
        End If


        If grdBAC.SelectedDataKey("isActive") = True Then
            ddisActive.SelectedIndex = 1
        Else
            ddisActive.SelectedIndex = 2
        End If

        If grdBAC.SelectedDataKey("isDefault") = True Then
            ddDefault.SelectedIndex = 1
        Else
            ddDefault.SelectedIndex = 2
        End If
        btnsave.text = "UPDATE"
        Session("BAC_Act") = "UPDATE"
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim serv As Boolean
            If DDIsPubInfra.Selecteditem.text = "Infrastructure" Then
                serv = True
            ElseIf DDIsPubInfra.Selecteditem.text = "Goods" Then
                serv = False
            End If

            If ddisActive.SelectedItem.Text = "Select" Or ddBACpos.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Complete the dropdown selection.")
            Else
                If ddDefault.SelectedItem.Value = 1 And ddisActive.SelectedItem.Value = 1 Then
                    objDerived.GetRecords("UPDATE AMS.BAC_Members SET isDefault = 0 WHERE BAC_PostionID = '" & ddBACpos.SelectedItem.Value & "' ", CommandType.Text)
                End If

                objDerived.GetRecords("UPDATE AMS.BAC_Members SET BAC_PostionID = '" & ddBACpos.SelectedItem.Value &
                                      "', isPublicInfra ='" & serv &
                                      "', isActive = '" & ddisActive.SelectedItem.Value &
                                      "', isDefault = '" & ddDefault.SelectedItem.Value &
                                      "' WHERE id = '" & Session("ID") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "BAC Members has been successfully updated.")

                ddBACpos.ClearSelection()
                ddBACpos.DataSource = Nothing
                ddBACpos.DataBind()
                ddBACpos.Items.Insert(0, "Select")
                ddisActive.SelectedIndex = 0

                LoadMembers()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadMembers()

    End Sub

    Protected Sub btnADD_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnADD.Text = "ADD MEMBER" Then
            Me.MultiView1.SetActiveView(Me.View2)

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT DISTINCT UPPER(full_name) as full_name, empid FROM HRMS.view_signatory ORDER BY full_name", CommandType.Text)
            ddNewBAC.DataSource = dt
            ddNewBAC.DataTextField = ("full_name")
            ddNewBAC.DataValueField = ("empid")
            ddNewBAC.DataBind()
            ddNewBAC.Items.Insert(0, "Select")

            'ddBACpos2.DataSource = objDerived.GetDataTable("SELECT BAC_PostionID, (Position_desc + ' (' + Code + ')') AS Position_desc FROM AMS.BAC_position WHERE (BAC_PostionID IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 14, 15)) ORDER BY Position_desc", CommandType.Text)
            ddBACpos2.DataSource = objDerived.GetDataTable("SELECT BAC_PostionID, (Position_desc + ' (' + Code + ')') AS Position_desc FROM AMS.BAC_position  ORDER BY Position_desc", CommandType.Text)
            'ddBACpos2.DataSource = objDerived.GetDataTable("SELECT BAC_PostionID, CASE WHEN BAC_PostionID = 14 THEN Position_desc + ' (' + Code + ')' ELSE Position_desc END AS Position_desc FROM AMS.BAC_position WHERE (BAC_PostionID IN (1, 2, 3, 6, 7, 8,14))", CommandType.Text)
            ddBACpos2.DataTextField = ("Position_desc")
            ddBACpos2.DataValueField = ("BAC_PostionID")
            ddBACpos2.DataBind()
            ddBACpos2.Items.Insert(0, "Select")

            btnADD.Text = "UPDATE MEMBER"
            lblBAC.Text = "ADD MEMBER"

        ElseIf btnADD.Text = "UPDATE MEMBER" Then
            Me.MultiView1.SetActiveView(Me.View1)
            LoadMembers()

            btnADD.Text = "ADD MEMBER"
            lblBAC.Text = "UPDATE MEMBER"
        End If


    End Sub

    Protected Sub ddNewBAC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dep As String = objDerived.GetValue("Select office_name from HRMS.view_signatory where empid ='" & ddNewBAC.SelectedItem.Value & "'", CommandType.Text)

        txtNewDep.Text = dep
        hndDepID.value = objDerived.GetValue("Select deptid from HRMS.view_signatory where empid ='" & ddNewBAC.SelectedItem.Value & "'", CommandType.Text)




        btnSaveNew.Enabled = True
        btnCancelNew.Enabled = True
    End Sub


    Protected Sub btnSaveNew_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnNewPosition.text = "NEW" Then
            '=== SAVE NEW BAC
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM AMS.BAC_Members WHERE empsig_id = '" & ddNewBAC.SelectedItem.Value & "'", CommandType.Text)

            'If dt.Rows.Count = 0 Then
            'Dim serv As Boolean

            'If RadioButtonList1.SelectedIndex = 0 Then
            '    DdServ.Text = "Goods"
            'Else
            '    DdServ.Text = "Infrastructure"
            'End If

            If DdServ.SelectedItem.Text = "Infrastructure" Then
                serv = True
            Else
                serv = False
            End If

            With objBAC
                '.id = grdBAC.SelectedDataKey("id")
                .Name = ddNewBAC.SelectedItem.Text
                .BAC_PostionID = ddBACpos2.SelectedItem.Value
                .isPublicInfra = serv
                .Position = txtNewDep.Text
                .empsig_id = ddNewBAC.SelectedItem.Value
                If DDIsAct.SelectedItem.text = "Select" Or DDIsAct.SelectedItem.Value = 3 Or DDIsDef.SelectedItem.Value = 3 Or DDIsDef.SelectedItem.text = "Select " Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please complete the information.")
                    Exit Sub
                Else
                    .isActive = DDIsAct.SelectedItem.Value
                    .isDefault = DDIsDef.SelectedItem.Value
                End If

                .save()
            End With

            'objDerived.GetRecords("UPDATE AMS.BAC_Members SET isActive = 1, isDefault = 0 WHERE empsig_id = '" & ddNewBAC.SelectedItem.Value & "'", CommandType.Text)
            btnADD.Text = "ADD MEMBER"
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            'Else
            '    objDerived.GetRecords("UPDATE AMS.BAC_Members SET BAC_PostionID = '" & ddBACpos2.SelectedItem.Value & "', isActive = 1 WHERE empsig_id = '" & ddNewBAC.SelectedItem.Value & "'", CommandType.Text)
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "BAC Members has been successfully updated.")

            'End If

            LoadMembers()
            btnSaveNew.Enabled = False
        ElseIf btnNewPosition.text = "SEARCH" Then
            '=== SAVE POSITION DETAILS ===
            objDerived.GetRecords("INSERT INTO dbo.m_position (position_desc,dept_id) VALUES('" & replaceapostrophe(txtNewPosition.Text) & "', '" & hndDepID.value & "')", CommandType.Text)
            Dim PositionID As Integer
            Dim Position_Description As String
            PositionID = objDerived.GetValue("SELECT TOP(1) Position_ID FROM dbo.m_position ORDER BY Position_ID DESC", CommandType.Text)
            Position_Description = objDerived.GetValue("SELECT TOP(1) position_desc FROM dbo.m_position ORDER BY Position_ID DESC", CommandType.Text)


            '=== SAVE NEW BAC
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM AMS.BAC_Members WHERE empsig_id = '" & ddNewBAC.SelectedItem.Value & "'", CommandType.Text)

            'If dt.Rows.Count = 0 Then
            'Dim serv As Boolean

            'If RadioButtonList1.SelectedIndex = 0 Then
            '    DdServ.Text = "Goods"
            'Else
            '    DdServ.Text = "Infrastructure"
            'End If

            If DdServ.SelectedItem.Text = "Infrastructure" Then
                serv = True
            Else
                serv = False
            End If

            With objBAC
                '.id = grdBAC.SelectedDataKey("id")
                .Name = ddNewBAC.SelectedItem.Text
                .BAC_PostionID = PositionID
                .isPublicInfra = serv
                .Position = Position_Description
                .empsig_id = ddNewBAC.SelectedItem.Value
                If DDIsAct.SelectedItem.text = "Select" Or DDIsAct.SelectedItem.Value = 3 Or DDIsDef.SelectedItem.Value = 3 Or DDIsDef.SelectedItem.text = "Select " Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please complete the information.")
                    Exit Sub
                Else
                    .isActive = DDIsAct.SelectedItem.Value
                    .isDefault = DDIsDef.SelectedItem.Value
                End If

                .save()
            End With

            'objDerived.GetRecords("UPDATE AMS.BAC_Members SET isActive = 1, isDefault = 0 WHERE empsig_id = '" & ddNewBAC.SelectedItem.Value & "'", CommandType.Text)
            btnADD.Text = "ADD MEMBER"
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            'Else
            '    objDerived.GetRecords("UPDATE AMS.BAC_Members SET BAC_PostionID = '" & ddBACpos2.SelectedItem.Value & "', isActive = 1 WHERE empsig_id = '" & ddNewBAC.SelectedItem.Value & "'", CommandType.Text)
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "BAC Members has been successfully updated.")

            'End If

            LoadMembers()
            btnSaveNew.Enabled = False
        End If



    End Sub

    Protected Sub btnCancelNew_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtNewDep.Text = ""
        Dim dt As New DataTable
        ddNewBAC.DataSource = dt
        ddNewBAC.DataBind()
        ddNewBAC.Items.Insert(0, "Select")
    End Sub
    Protected Sub ddBACpos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnsave.Enabled = True
    End Sub
    Protected Sub grdBAC_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdBAC.PageIndex = e.NewPageIndex
        LoadMembers()
    End Sub
    Protected Sub DDIsPubInfra_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim serv As Boolean
        If DDIsPubInfra.text = "Infrastructure" Then
            serv = True
        ElseIf DDIsPubInfra.text = "Goods" Then
            serv = False
        End If
    End Sub
    Protected Sub DdServ_SelectedIndexChanged(sender As Object, e As EventArgs)
        If DdServ.Text = "Infrastructure" Then
            serv = True
        ElseIf DdServ.Text = "Goods" Then
            serv = False
        End If
    End Sub
    Protected Sub btnNewPosition_Click(sender As Object, e As EventArgs)
        If btnNewPosition.text = "NEW" Then
            btnNewPosition.text = "SEARCH"
            txtnewposition.visible = True
            ddBACpos2.visible = False
        Else
            btnNewPosition.text = "NEW"
            ddBACpos2.visible = True
            txtnewposition.visible = False
        End If
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
End Class
