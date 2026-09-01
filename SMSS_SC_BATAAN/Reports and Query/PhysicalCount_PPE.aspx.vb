Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Reports_and_Query_PhysicalCount_PPE
    Inherits System.Web.UI.Page
    Dim DBPassUsernname As New connectionreport
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule

    Private Property pAccountCodes() As DataTable
        Get
            Return CType(Session("pAccountCodes"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAccountCodes") = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            LoadrbChoice()
        End If
    End Sub

    'Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbChoice.SelectedIndexChanged
    '    LoadrbChoice()
    'End Sub

    Protected Sub drptSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drptSearchBy.SelectedIndexChanged
        LoadrbChoice()
    End Sub

    Protected Sub LoadrbChoice()
        btnAccounts.Enabled = False
        btnDept.Enabled = False

        If drptSearchBy.SelectedItem.Value = 0 Then
            tb_Dept.Visible = False
            tb_Accnt.Visible = False

        ElseIf drptSearchBy.SelectedItem.Value = 1 Then 'By Department
            Session("Search") = 1
            Session("Item_Desc") = ""
            tb_Dept.Visible = True
            tb_Accnt.Visible = False
            tb_Item.Visible = False

            ddDept.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
            ddDept.DataTextField = "RC_Name"
            ddDept.DataValueField = "RC_id"
            ddDept.DataBind()
            ddDept.Items.Insert(0, "Select")

            ddFunction.DataSource = Nothing
            ddFunction.DataBind()
            ddFunction.Items.Insert(0, "Select")

        ElseIf drptSearchBy.SelectedItem.Value = 2 Then 'Consolidated
            Session("Search") = 2
            Session("Item_Desc") = ""
            tb_Accnt.Visible = True
            tb_Dept.Visible = False
            tb_Item.Visible = False

            'pAccountCodes = objDerived.GetDataTable("select * from AMS.vw_PhysicalCount_PPE", CommandType.Text)
            pAccountCodes = objDerived.GetDataTable("SELECT * FROM AMS.View_AccountList WHERE AllotmentClass_ID = 3 AND BGA_ID = 0 ORDER BY GA_Title", CommandType.Text)
            ddcode.DataSource = pAccountCodes
            ddcode.DataTextField = "GA_Title"
            ddcode.DataValueField = "GA_ID"
            ddcode.DataBind()
            ddcode.Items.Insert(0, "Select")
            ddcode.Items.Insert(1, "ALL")

        ElseIf drptSearchBy.SelectedItem.Value = 3 Then 'By Item
            Session("Search") = 3
            tb_Accnt.Visible = False
            tb_Dept.Visible = False
            tb_Item.Visible = True


        End If
    End Sub

    Protected Sub ddDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddDept.SelectedIndexChanged
        ddFunction.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & ddDept.SelectedItem.Value & "'", CommandType.Text)
        ddFunction.DataTextField = "Function_Desc"
        ddFunction.DataValueField = "Function_ID"
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")
    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddFunction.SelectedIndexChanged
        ddSorting.Enabled = True
    End Sub

    Protected Sub ddSorting_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddSorting.SelectedIndexChanged
        btnDept.Enabled = True
    End Sub

    Protected Sub btnDept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDept.Click
        Session("isConsoldiated") = False
        Session("isPerDepartment") = True
        Session("isPerItems") = False

        Session("RC_ID") = ddDept.SelectedItem.Value
        Session("Function_ID") = ddFunction.SelectedItem.Value

        If ddSorting.SelectedItem.Value = 1 Then
            Session("SortBy") = "Accounts"
        Else
            Session("SortBy") = "AccntblePerson"
        End If

        Session("ItemDesc") = ""
        Session("GA_ID") = 0

        Me.Page.Response.Redirect("~/Reports and Query/rpt_PhysicalCount_PPE.aspx")

    End Sub

    Protected Sub ddcode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddcode.SelectedIndexChanged
        btnAccounts.Enabled = True
    End Sub

    Protected Sub btnAccounts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccounts.Click
        Session("isConsoldiated") = True
        Session("isPerDepartment") = False
        Session("isPerItems") = False

        If ddcode.SelectedItem.Text = "ALL" Then
            Session("GA_ID") = 0
        Else
            Session("GA_ID") = ddcode.SelectedItem.Value
        End If

        Session("RC_ID") = 0
        Session("Function_ID") = 0
        Session("ItemDesc") = ""
        Session("SortBy") = ""

        Me.Page.Response.Redirect("~/Reports and Query/rpt_PhysicalCount_PPE.aspx")
    End Sub


    Protected Sub btnItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnItem.Click
        Session("isConsoldiated") = False
        Session("isPerDepartment") = False
        Session("isPerItems") = True

        Session("ItemDesc") = txtSearchItem.Text

        Session("RC_ID") = 0
        Session("Function_ID") = 0
        Session("SortBy") = ""
        Session("GA_ID") = 0

        Me.Page.Response.Redirect("~/Reports and Query/rpt_PhysicalCount_PPE.aspx")
    End Sub


End Class
