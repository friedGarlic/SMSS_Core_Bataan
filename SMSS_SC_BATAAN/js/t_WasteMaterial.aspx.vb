Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports OnBarcode

Partial Class Inventory_t_WasteMaterial
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim hdr As New WMR_hdr
    Dim dtl As New WMR_dtl
    Public hdr_id As Integer
    Public hdrid As Long

#Region "Property"
    Private Property rolename() As String
        Get
            Return CType(Session("rolename"), String)
        End Get
        Set(ByVal value As String)
            Session("rolename") = value
        End Set
    End Property
    Private Property pRC() As DataTable
        Get
            Return CType(Session("pRC"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRC") = value
        End Set

    End Property
    Private Property pFunction() As DataTable
        Get
            Return CType(Session("pFunction"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pFunction") = value
        End Set

    End Property
    Private Property pRoleName() As DataTable
        Get
            Return CType(Session("pRoleName"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRoleName") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then

            Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
            Dim role() As String = Roles.GetRolesForUser(usr.UserName)
            rolename = role(0)
            Session("RoleName") = rolename
            pRoleName = objDerived.GetDataTable("exec dbo.sp_get_rc_by_role '" & rolename & "'", CommandType.Text)

            pRC = objDerived.GetDataTable("exec dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)

            drpdept.DataSource = CType(pRC, DataTable)
            drpdept.DataTextField = ("rc_name")
            drpdept.DataValueField = ("rc_id")
            drpdept.DataBind()

            loadsignatory()

            '=-= Default View
            Me.mvCategory.SetActiveView(Me.vwSupplies)
            grdSupplies.DataSource = Nothing
            grdSupplies.DataBind()

        End If
       
    End Sub

    Protected Sub drpdept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("rc") = drpdept.SelectedItem.Value

        Try
            ddFunction.Items.Clear()
            If drpdept.SelectedItem.Text = "Select" Then
                pFunction = Nothing
                ddFunction.DataSource = pFunction
                ddFunction.DataBind()
                ddFunction.Items.Add("Select")
            Else

                pFunction = objDerived.GetDataTable("select Office_id as Rc_id , Function_id,Function_desc from ams.vw_functions  where Office_id = " & drpdept.SelectedItem.Value & "", CommandType.Text)
                ddFunction.Items.Add("Select")

                ddFunction.DataSource = pFunction
                ddFunction.DataTextField = ("Function_Desc")
                ddFunction.DataValueField = ("Function_ID")
                ddFunction.DataBind()
                ddFunction.Enabled = True

            End If
            Session("rc") = drpdept.SelectedItem.Value
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnADD_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadrbChoice()
    End Sub

    Protected Sub LoadSignatory()
        Dim certby As New DataTable
        certby = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE(deptid = 7) AND (division_key = 86) AND (isDeptHead LIKE 'Yes')", CommandType.Text)
        drpCertified.DataSource = certby
        drpCertified.DataTextField = ("full_name")
        drpCertified.DataValueField = ("Signatory_ID")
        drpCertified.DataBind()
        drpCertified.Items.Insert(0, "Select")

        Dim apprvd As New DataTable
        apprvd = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE (isDeptHead LIKE 'Yes')", CommandType.Text)
        drpApproving.DataSource = apprvd
        drpApproving.DataTextField = ("full_name")
        drpApproving.DataValueField = ("Signatory_ID")
        drpApproving.DataBind()
        drpApproving.Items.Insert(0, "Select")

        Dim propIns As New DataTable
        propIns = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE(deptid = 7) AND (division_key = 86)", CommandType.Text)
        drpPropertyOfficer.DataSource = propIns
        drpPropertyOfficer.DataTextField = ("full_name")
        drpPropertyOfficer.DataValueField = ("Signatory_ID")
        drpPropertyOfficer.DataBind()
        drpPropertyOfficer.Items.Insert(0, "Select")

    End Sub
    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnADD.Enabled = True
        rbChoice.Enabled = True

        rbChoice.SelectedItem.Value = 1
        LoadrbChoice()
    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadrbChoice()
    End Sub

    Protected Sub LoadrbChoice()
        If rbChoice.SelectedItem.Value = 1 Then
            '=-= Supplies
            Me.mvCategory.SetActiveView(Me.vwSupplies)

            Dim dtSupplies As New DataTable
            dtSupplies = objDerived.GetDataTable("EXEC [AMS].[sp_supplies_usefulife] '" & Date.Today.ToString("MM/dd/yyyy") & "','" & drpdept.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
            grdSupplies.DataSource = dtSupplies
            grdSupplies.DataBind()

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            '=-= Porperties
            Me.mvCategory.SetActiveView(Me.vwProperties)

            Dim dtproperties As New DataTable
            dtproperties = objDerived.GetDataTable("EXEC [AMS].[sp_properties_usefulife] '" & Date.Today.ToString("MM/dd/yyyy") & "','" & drpdept.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
            grdProperties.DataSource = dtproperties
            grdProperties.DataBind()

        End If

    End Sub

    Protected Sub cbAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdSupplies.Rows.Count - 1
                Dim s As CheckBox = CType(Me.grdSupplies.Rows(i).Cells(0).FindControl("cbSelect"), CheckBox)
                s.Checked = True
            Next
        Else
            For i As Integer = 0 To Me.grdSupplies.Rows.Count - 1
                Dim s As CheckBox = CType(Me.grdSupplies.Rows(i).Cells(0).FindControl("cbSelect"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub

    Protected Sub cbAll_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdProperties.Rows.Count - 1
                Dim s As CheckBox = CType(Me.grdProperties.Rows(i).Cells(0).FindControl("cbProp"), CheckBox)
                s.Checked = True
            Next
        Else
            For i As Integer = 0 To Me.grdProperties.Rows.Count - 1
                Dim s As CheckBox = CType(Me.grdProperties.Rows(i).Cells(0).FindControl("cbProp"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub

    Protected Sub ddDisposal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Page is still under development. Thank you for your consideration.")
    End Sub

    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnpreview_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/Inventory/t_rpt_mw.aspx")
    End Sub
End Class