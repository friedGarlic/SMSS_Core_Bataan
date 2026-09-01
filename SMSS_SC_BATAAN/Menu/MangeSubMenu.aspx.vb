Imports System.Data
Imports System.Data.SqlClient
Partial Class Menu_MangeSubMenu
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
        objDrpDwn.loadDrpDwnList(Me.ddlApplication, "SELECT * FROM aspnet_Applications", "ApplicationName", "ApplicationId", CommandType.Text)

    End Sub
    Private Sub LoadMenu()
        Dim dt As New DataTable
        Dim objDrpDwn As New BaseDrpDwn.DropdownLoad
        objDrpDwn.loadDrpDwnList(Me.ddlMenu, "SELECT * FROM tbl_Module WHERE ApplicationId='" & Me.ddlApplication.SelectedValue & "' order by SequenceNo", "ModuleName", "ModuleId", CommandType.Text)

        'Dim objBase As New BaseGeneral
        'Dim dt As New DataTable
        'dt = objBase.GetDataTable("SELECT * FROM tbl_Module WHERE ApplicationId ='" & Session("app") & "' ORDER BY SequenceNo", CommandType.Text)
        'grdMenu.DataSource = dt
        'grdMenu.DataBind()
    End Sub

    Private Sub LoadSubMenuByApplication()
        Dim objBase As New BaseGeneral
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim qry As String = "SELECT * FROM tbl_SubModule WHERE ApplicationId='" & Me.ddlApplication.SelectedValue & "' and ModuleId='" & ddlMenu.SelectedValue & "' ORDER BY SequenceNo"
        dt = objBase.GetDataTable(qry, CommandType.Text)

        grdSubMenu.DataSource = dt
        grdSubMenu.DataBind()
    End Sub

    Protected Sub ddlApplication_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlApplication.SelectedIndexChanged
        LoadMenu()
    End Sub

    Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.Click

        Dim objBase As New BaseGeneral
        If Session("SubMenu") = "New" Then

            Dim rtn As Integer
            objBase.cmd.Parameters.AddWithValue("@SubModuleName", Me.txtSubMenu.Text)
            objBase.cmd.Parameters.AddWithValue("@Description", Me.txtDescription.Text)
            objBase.cmd.Parameters.AddWithValue("@HomePageURL", Me.txtURL.Text)
            objBase.cmd.Parameters.AddWithValue("@ApplicationId", Me.ddlApplication.SelectedValue)
            objBase.cmd.Parameters.AddWithValue("@SequenceNo", Me.txtSequence.Text)
            objBase.cmd.Parameters.AddWithValue("@ModuleId", Me.ddlMenu.SelectedValue)
            objBase.cmd.Parameters.Add("@SubModuleID", SqlDbType.Int).Direction = ParameterDirection.Output
            rtn = objBase.Execute("@SubModuleID", "spSubModule_SaveSubModule", CommandType.StoredProcedure)
            If rtn = 0 Then
                Me.CreateStatus.Text = "Submenu already exists.Cannot duplicate submenu name."
            End If

            msg.UserMsgBox("Sub Module successfully save.", Me, False)

            txtSubMenu.Text = ""
            txtDescription.Text = ""
            txtURL.Text = ""
            txtSequence.Text = ""

        ElseIf Session("SubMenu") = "Update" Then
            objBase.GetRecords("Update dbo.tbl_SubModule set SubModuleName = '" & txtSubMenu.Text & "',Description ='" & txtDescription.Text & "',HomePageURL ='" & txtURL.Text & "',SequenceNo ='" & txtSequence.Text & "' where ModuleID ='" & grdSubMenu.SelectedDataKey("ModuleID") & "' and SubModuleID ='" & grdSubMenu.SelectedDataKey("SubModuleID") & "'", CommandType.Text)
            msg.UserMsgBox("Sub Module successfully updated.", Me, False)
        End If


        LoadSubMenuByApplication()

        'LoadApplications()
        'ddlMenu.Items.Clear()

    End Sub

    Protected Sub ddlMenu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMenu.SelectedIndexChanged
        Session("SubMenu") = "New"

        txtSubMenu.Text = ""
        txtDescription.Text = ""
        txtURL.Text = ""
        txtSequence.Text = ""

        LoadSubMenuByApplication()
    End Sub

    Protected Sub grdSubMenu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSubMenu.SelectedIndexChanged
        Session("SubMenu") = "Update"

        txtSubMenu.Text = grdSubMenu.SelectedDataKey("SubModuleName")
        txtDescription.Text = grdSubMenu.SelectedDataKey("Description")
        txtURL.Text = grdSubMenu.SelectedDataKey("HomePageURL")
        txtSequence.Text = grdSubMenu.SelectedDataKey("SequenceNo")

    End Sub
End Class
