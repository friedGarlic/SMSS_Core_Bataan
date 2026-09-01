Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO


Partial Class procurement_t_APR
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

#Region "property"
    Private Property pRoleName() As DataTable
        Get
            Return CType(Session("pRoleName"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRoleName") = value
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
    Private Property pAccounts() As DataTable
        Get
            Return CType(Session("pAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAccounts") = value
        End Set

    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Page.IsPostBack Then
                obj.GetAccessRight(Me.Session("@UserName"), Page)
                Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
                Dim role() As String = Roles.GetRolesForUser(usr.UserName)
                Dim rolename As String = role(0)

                pRoleName = objDerived.GetDataTable("exec dbo.sp_get_rc_by_role '" & rolename & "'", CommandType.Text)

                ddYear.DataSource = objDerived.GetDataTable("SELECT DISTINCT year FROM AMS.APP WHERE STATUS <> 3 ORDER BY year DESC", CommandType.Text)
                ddYear.DataTextField = ("year")
                ddYear.DataValueField = ("year")
                ddYear.DataBind()
                ddYear.Items.Insert(0, "Select")

                ddAccount.DataSource = Nothing
                ddAccount.DataBind()
                ddAccount.Items.Insert(0, "Select")

                gvItems.DataSource = Nothing
                gvItems.DataBind()


            End If

        Catch ex As Exception
        End Try

    End Sub

    Protected Sub ddYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddYear.SelectedIndexChanged
        If ddYear.SelectedItem.Text = "Select" Then
            Me.Page.Response.Redirect("~/procurement/t_APR.aspx")
        End If

        Dim APPstatus As Integer = objDerived.GetValue("SELECT DISTINCT status FROM AMS.APP WHERE year = '" & ddYear.SelectedItem.Value & "'", CommandType.Text)
        If APPstatus = 1 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Execute APP First.")
        Else

            ddAllotment.Enabled = True
        End If

    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/procurement/rpt_ARP.aspx")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/procurement/t_APR.aspx")
    End Sub

    Protected Sub ddAllotment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddAllotment.Enabled = False
        ddAccount.Enabled = True

        If ddAllotment.SelectedItem.Value = 1 Then

        Else
            pAccounts = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & ddAllotment.SelectedItem.Value & "'", CommandType.Text)

            ddAccount.DataSource = pAccounts
            ddAccount.DataTextField = ("GA_Title")
            ddAccount.DataValueField = ("GA_ID")
            ddAccount.DataBind()
            ddAccount.Items.Insert(0, "Select")
        End If

    End Sub

    Protected Sub ddAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddAccount.Enabled = False

        Dim dtAPR As New DataTable
        dtAPR = objDerived.GetDataTable("EXEC [AMS].[sp_APR_ItemList] '" & ddAccount.SelectedItem.Value & "'", CommandType.Text)
        gvItems.DataSource = dtAPR
        gvItems.DataBind()

        btnPreview.Enabled = True

        Session("Year") = ddYear.SelectedItem.Value
        Session("GA_ID") = ddAccount.SelectedItem.Value

    End Sub
End Class
