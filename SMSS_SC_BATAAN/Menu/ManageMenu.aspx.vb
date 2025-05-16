Imports System.Data
Imports System.Data.SqlClient

Partial Class Menu_ManageMenu
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim msg As New MsgeBox

#Region "property"
    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property
#End Region

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

    Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Dim objBase As New BaseGeneral

        If Session("Menu") = "New" Then
            Dim rtn As Integer
            objBase.cmd.Parameters.AddWithValue("@ModuleName", Me.txtModule.Text)
            objBase.cmd.Parameters.AddWithValue("@Description", Me.txtDescription.Text)
            objBase.cmd.Parameters.AddWithValue("@HomePageURL", Me.txtURL.Text)
            objBase.cmd.Parameters.AddWithValue("@ApplicationId", Me.ddlApplication.SelectedValue)
            objBase.cmd.Parameters.AddWithValue("@SequenceNo", Me.txtSequence.Text)
            objBase.cmd.Parameters.Add("@ModuleID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            rtn = objBase.Execute("@ModuleID", "spModule_SaveModule", CommandType.StoredProcedure)

            If rtn = 0 Then
                Me.CreateStatus.Text = "Menu already exists.Cannot duplicate menu name."
            End If

            msg.UserMsgBox("Module successfully save.", Me, False)

            txtModule.Text = ""
            txtDescription.Text = ""
            txtURL.Text = ""
            txtSequence.Text = ""

        ElseIf Session("Menu") = "Update" Then
            objBase.GetRecords("Update dbo.tbl_Module set ModuleName = '" & txtModule.Text & "',Description ='" & txtDescription.Text & "',HomePageURL ='" & txtURL.Text & "',SequenceNo ='" & txtSequence.Text & "' where ModuleID ='" & grdMenu.SelectedDataKey("ModuleID") & "'", CommandType.Text)
            msg.UserMsgBox("Module successfully updated.", Me, False)
        End If

        Dim dt As New DataTable
        dt = objBase.GetDataTable("SELECT * FROM tbl_Module WHERE ApplicationId ='" & Session("app") & "' ORDER BY SequenceNo", CommandType.Text)
        grdMenu.DataSource = dt
        grdMenu.DataBind()


    End Sub

    Protected Sub ddlApplication_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlApplication.SelectedIndexChanged
        'LoadMenuByApplication()
        Dim objBase As New BaseGeneral
        Dim dt As New DataTable
        Session("app") = ddlApplication.SelectedValue
        Session("Menu") = "New"

        dt = objBase.GetDataTable("SELECT * FROM tbl_Module WHERE ApplicationId ='" & Me.ddlApplication.SelectedValue & "' ORDER BY SequenceNo", CommandType.Text)
        grdMenu.DataSource = dt
        grdMenu.DataBind()

    End Sub
    Private Sub LoadMenuByApplication()
        Dim objBase As New BaseGeneral
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim qry As String = "SELECT * FROM tbl_Module WHERE ApplicationId='" & Me.ddlApplication.SelectedValue & "' ORDER BY SequenceNo"
        dt = objBase.GetDataTable(qry, CommandType.Text)

        Me.grdMenu.DataSource = dt
        Me.grdMenu.DataBind()
    End Sub

    Protected Sub grdMenu_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMenu.SelectedIndexChanged
        Session("Menu") = "Update"

        txtModule.Text = grdMenu.SelectedDataKey("ModuleName")
        txtDescription.Text = grdMenu.SelectedDataKey("Description")
        txtSequence.Text = grdMenu.SelectedDataKey("SequenceNo")
        txtURL.Text = ""
        txtURL.ReadOnly = True
    End Sub
End Class
