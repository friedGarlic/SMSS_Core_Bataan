Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class t_rpt_physical_count_of_inventory
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
            pAccountCodes = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 2 & "'", CommandType.Text)
            ddcode.DataSource = pAccountCodes
            ddcode.DataTextField = "GA_Title"
            ddcode.DataValueField = "GA_ID"
            ddcode.DataBind()
            ddcode.Items.Insert(0, "Select")
            ddcode.Items.Insert(1, "ALL")

            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")

        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Session("StockDate") = txtdate.Text

        Me.Page.Response.Redirect("~/Reports and Query/rpt_PhysicalCount_Inventories.aspx")
    End Sub

    Protected Sub ddcode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("GA_ID") = ddcode.SelectedItem.Value
        Session("Report") = ddcode.SelectedItem.Text
        Button2.Enabled = True
    End Sub
End Class
