Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class planning_t_ppmpList
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule

    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try

        obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            If Not Page.IsPostBack Then
                ddYear.DataSource = objDerived.GetDataTable("SELECT DISTINCT year FROM AMS.APP ORDER BY year DESC", CommandType.Text)
                ddYear.DataTextField = ("year")
                ddYear.DataValueField = ("year")
                ddYear.DataBind()
                ddYear.Items.Insert(0, "Select")

                grdDept.DataSource = Nothing
                grdDept.DataBind()

                grdAccounts.DataSource = Nothing
                grdAccounts.DataBind()
            End If

        'Catch ex As Exception
        'End Try
    End Sub

    Protected Sub ddYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Year") = ddYear.SelectedItem.Value
        If ddCategory.SelectedItem.Text = "Select" Or ddYear.SelectedItem.Text = "Select" Then

        Else
            LoadPPMP()
        End If
    End Sub
    Protected Sub ddCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Search") = ddCategory.SelectedItem.Value
        If ddYear.SelectedItem.Text = "Select" Or ddCategory.SelectedItem.Text = "Select" Then

        Else
            LoadPPMP()
        End If
    End Sub

    Protected Sub LoadPPMP()
        grdDept.DataSource = Nothing
        grdDept.DataBind()

        grdAccounts.DataSource = Nothing
        grdAccounts.DataBind()

        Dim dtwith As New DataTable

        dtwith = objDerived.GetDataTable("EXEC [AMS].[sp_ppmp_departments] '" & Session("Search") & "','" & Session("Year") & "'", CommandType.Text)
        grdDept.DataSource = dtwith
        grdDept.DataBind()

        Dim x As Integer = dtwith.Rows.Count
        lblCount.Visible = True
        lblCount.Text = CType(x, String) + " " + "Departments"

    End Sub

    Protected Sub grdDept_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtwith As New DataTable
        dtwith = objDerived.GetDataTable("EXEC [AMS].[sp_ppmp_departments] '" & Session("Search") & "','" & Session("Year") & "'", CommandType.Text)
        If dtwith.Rows.Count < 20 Then
            dtwith.Merge(createdatatable1(20 - dtwith.Rows.Count))
        End If
        grdDept.PageIndex = e.NewPageIndex
        grdDept.DataSource = dtwith
        grdDept.DataBind()

    End Sub
    Protected Sub linkSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub grdDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("RC_ID") = grdDept.SelectedDataKey("RC_ID")
        Session("Function_ID") = grdDept.SelectedDataKey("Function_ID")

        LoadAccounts()
    End Sub
    Protected Sub LoadAccounts()
        Dim dtAccounts As New DataTable
        'dtAccounts = objDerived.GetDataTable("SELECT * [dbo].[View_PPMP_Account] WHERE RC_ID = '" & Session("RC_ID") & "' AND Function_ID = '" & Session("Function_ID") & "' AND CYear = '" & Session("Year") & "'", CommandType.Text)
        dtAccounts = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PPMP_Account] WHERE RC_ID = '" & Session("RC_ID") & "' AND Function_ID = '" & Session("Function_ID") & "' AND CYear = '" & Session("Year") & "'", CommandType.Text)
        grdAccounts.DataSource = dtAccounts
        grdAccounts.DataBind()

    End Sub

    Protected Sub grdAccounts_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtAccounts As New DataTable
        dtAccounts = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PPMP_Account] WHERE RC_ID = '" & Session("RC_ID") & "' AND Function_ID = '" & Session("Function_ID") & "'", CommandType.Text)
        'If dtAccounts.Rows.Count < 20 Then
        '    dtAccounts.Merge(createdatatable2(20 - dtAccounts.Rows.Count))
        'End If
        grdAccounts.PageIndex = e.NewPageIndex
        grdAccounts.DataSource = dtAccounts
        grdAccounts.DataBind()
    End Sub
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("RespCenter", GetType(String))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("RespCenter") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("GA_Title", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("GA_Title") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub grdAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Session("GA_ID") = grdAccounts.SelectedDataKey("GA_ID")
        'Session("BGA_ID") = grdAccounts.SelectedDataKey("BGA_ID")
        'Session("Project_ID") = grdAccounts.SelectedDataKey("Project_ID")
        'Session("Program_id") = grdAccounts.SelectedDataKey("Program_id")
        'Session("isContinuing") = False
        'Session("isSupplemental") = False
        'Dim url As String = "rpt_ppmp_popup.aspx?"
        'Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=0,scrollbars=1,width=1200px,height=650px,left=100,top=10');"
        'ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)



        Session("CYear") = grdAccounts.SelectedDataKey("CYear")
        Session("RC_ID") = grdAccounts.SelectedDataKey("RC_ID")
        Session("Function_ID") = grdAccounts.SelectedDataKey("Function_ID")
        Session("Project_ID") = grdAccounts.SelectedDataKey("Project_ID")
        Session("Program_id") = grdAccounts.SelectedDataKey("Program_id")
        Session("isInfra") = 0
        Session("GA_ID") = grdAccounts.SelectedDataKey("GA_ID")

        Session("Page") = "Planning_PPMP"

        Me.Page.Response.Redirect("~/MainReports/Report_Planning.aspx")

    End Sub
End Class
