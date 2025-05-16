Imports System.Data
Imports System.Data.SqlClient
Partial Class Menu_ManageComponent
    Inherits System.Web.UI.Page
    Dim msg As New MsgeBox

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadApplications()
        End If

    End Sub

    Private Sub LoadApplications()
        Dim dt As New DataTable
        Dim objDrpDwn As New BaseDrpDwn.DropdownLoad
        'objDrpDwn.conStr = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        objDrpDwn.loadDrpDwnList(Me.ddlApplication, "SELECT * FROM aspnet_Applications", "ApplicationName", "ApplicationId", CommandType.Text)

    End Sub
    Private Sub LoadMenu()
        Dim dt As New DataTable
        Dim objDrpDwn As New BaseDrpDwn.DropdownLoad
        'objDrpDwn.conStr = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        objDrpDwn.loadDrpDwnList(Me.ddlMenu, "SELECT * FROM tbl_Module WHERE ApplicationId='" & Me.ddlApplication.SelectedValue & "'", "ModuleName", "ModuleId", CommandType.Text)

    End Sub
    Private Sub LoadSubMenu()
        Dim dt As New DataTable
        Dim objDrpDwn As New BaseDrpDwn.DropdownLoad
        'objDrpDwn.conStr = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        objDrpDwn.loadDrpDwnList(Me.ddlSubMenu, "SELECT * FROM tbl_SubModule WHERE ModuleId=" & Me.ddlMenu.SelectedValue, "SubModuleName", "SubModuleID", CommandType.Text)

    End Sub

    Protected Sub ddlApplication_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlApplication.SelectedIndexChanged
        LoadMenu()
        'LoadComponentByApplication()
    End Sub

    Protected Sub drpMenu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMenu.SelectedIndexChanged
        txtComponent.Text = ""
        txtDescription.Text = ""
        txtURL.Text = ""
        txtSequence.Text = ""

        LoadSubMenu()
    End Sub

    Private Sub LoadComponentByApplication()
        Dim objBase As New BaseGeneral
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim qry As String = "SELECT * FROM tbl_Component WHERE ApplicationId='" & Me.ddlApplication.SelectedValue & "' ORDER BY SubModuleId,SequenceNo"
        dt = objBase.GetDataTable(qry, CommandType.Text)

        Me.grdComponents.DataSource = dt
        Me.grdComponents.DataBind()
    End Sub
    Private Sub LoadComponentBySubMenu()
        Dim objBase As New BaseGeneral
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim qry As String = "SELECT * FROM tbl_Component WHERE SubModuleID=" & Me.ddlSubMenu.SelectedValue & " ORDER BY SequenceNo"
        dt = objBase.GetDataTable(qry, CommandType.Text)

        Me.grdComponents.DataSource = dt
        Me.grdComponents.DataBind()
    End Sub
    Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Dim objBase As New BaseGeneral

        If Session("Component") = "New" Then
            Dim componentitem As String
            Dim objDerived As New DerivedDal
            componentitem = Me.txtComponent.Text
            Dim componentname() As String = componentitem.Split("?")

            Dim rtn As Integer
            objBase.cmd.Parameters.AddWithValue("@ComponentName", Me.txtComponent.Text)
            objBase.cmd.Parameters.AddWithValue("@Description", Me.txtDescription.Text)
            objBase.cmd.Parameters.AddWithValue("@HomePageURL", Me.txtURL.Text)
            objBase.cmd.Parameters.AddWithValue("@ApplicationId", Me.ddlApplication.SelectedValue)
            objBase.cmd.Parameters.AddWithValue("@SequenceNo", Me.txtSequence.Text)
            objBase.cmd.Parameters.AddWithValue("@ModuleId", Me.ddlMenu.SelectedValue)
            objBase.cmd.Parameters.AddWithValue("@SubModuleId", Me.ddlSubMenu.SelectedValue)
            objBase.cmd.Parameters.Add("@ComponentID", SqlDbType.Int).Direction = ParameterDirection.Output
            rtn = objBase.Execute("@ComponentID", "spComponent_SaveComponent", CommandType.StoredProcedure)
            If rtn = 0 Then
                Me.CreateStatus.Text = "Component already exists.Cannot duplicate component name."
            End If

            msg.UserMsgBox("Component successfully save.", Me, False)

            txtComponent.Text = ""
            txtDescription.Text = ""
            txtURL.Text = ""
            txtSequence.Text = ""

        ElseIf Session("Component") = "Update" Then
            objBase.GetRecords("Update dbo.tbl_Component set ComponentName = '" & txtComponent.Text & "',Description ='" & txtDescription.Text & "',HomePageURL ='" & txtURL.Text & "',SequenceNo ='" & txtSequence.Text & "' where ModuleID ='" & grdComponents.SelectedDataKey("ModuleID") & "' and SubModuleID ='" & grdComponents.SelectedDataKey("SubModuleID") & "' and ComponentID ='" & grdComponents.SelectedDataKey("ComponentID") & "'", CommandType.Text)
            msg.UserMsgBox("Component successfully updated.", Me, False)
        End If

        LoadComponentBySubMenu()
        'LoadComponentByApplication()
        'LoadApplications()
     
    End Sub

    Protected Sub ddlSubMenu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubMenu.SelectedIndexChanged
        Session("Component") = "New"

        txtComponent.Text = ""
        txtDescription.Text = ""
        txtURL.Text = ""
        txtSequence.Text = ""

        LoadComponentBySubMenu()
    End Sub
    Protected Sub grdComponents_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdComponents.SelectedIndexChanged
        Session("Component") = "Update"

        txtComponent.Text = grdComponents.SelectedDataKey("ComponentName")
        txtDescription.Text = grdComponents.SelectedDataKey("Description")
        txtURL.Text = grdComponents.SelectedDataKey("HomePageURL")
        txtSequence.Text = grdComponents.SelectedDataKey("SequenceNo")
    End Sub
End Class
