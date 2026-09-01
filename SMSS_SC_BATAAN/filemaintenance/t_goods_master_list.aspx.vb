
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class filemaintenance_t_goods_master_list
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim particular As New item_particular
    Dim item As New m_item
    Dim item_detail As New m_item_detail
    Dim msg As New MsgeBox
    Dim msg2 As New MsgeBox

    Dim obj As New AccessRule

    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub


    Private Property categ() As DataTable
        Get
            Return CType(Session("categ"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("categ") = value
        End Set
    End Property

    Private Property dtItemList() As DataTable
        Get
            Return CType(Session("dtItemList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItemList") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Session("Search") = 0
                Session("Year") = "CY" & Year(Date.Today.ToString("MM/dd/yyyy"))
                Session("xYear") = Year(Date.Today.ToString("MM/dd/yyyy"))



                loadYear()
                loadcategory()

                txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnsearch.ClientID & "')")

            End If

        Catch ex As Exception
            AddTrace("Page_Load Error: " & ex.Message)
        End Try

    End Sub

    Public Sub loadYear()
        Dim CYear As New DataTable
        CYear = objDerived.GetDataTable("Select * from AMS.APP order by year desc", CommandType.Text)

        ddYear.DataSource = CYear
        ddYear.DataTextField = "year"
        ddYear.DataValueField = "year"
        ddYear.DataBind()
        ddYear.Items.Insert(0, "Select")

    End Sub

    Protected Sub loadcategory()

        If RadioButtonList1.SelectedItem.Value = 2 Then
            categ = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 2 & "'", CommandType.Text)
            ddCategories.DataSource = CType(categ, DataTable)
            ddCategories.DataTextField = ("GA_Title")
            ddCategories.DataValueField = ("GA_ID")
            ddCategories.DataBind()
            ddCategories.Items.Insert(0, "Select")
            ddCategories.SelectedIndex = 0
            'ddCategories.Items.Insert(0, "Select")

            Session("Allotment_Type") = 2

        ElseIf RadioButtonList1.SelectedItem.Value = 3 Then
            categ = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 3 & "'", CommandType.Text)
            ddCategories.DataSource = CType(categ, DataTable)
            ddCategories.DataTextField = ("GA_Title")
            ddCategories.DataValueField = ("GA_ID")
            ddCategories.DataBind()

            ddCategories.Items.Insert(0, "Select")

            ddCategories.SelectedIndex = 0
            'ddCategories.Items.Insert(0, "Select")

            Session("Allotment_Type") = 3

        End If

        LoadCategories()
    End Sub

    Protected Sub ddYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddYear.SelectedIndex > 0 Then
            Session("Year") = "CY" & ddYear.SelectedValue

            Session("xYear") = ddYear.SelectedValue
            AddTrace("Year changed to: " & Session("Year"))
        End If
    End Sub

    Protected Sub ddCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadCategories()
        Session("GA_ID") = ddCategories.SelectedValue

    End Sub
    Protected Sub LoadCategories()
        txtSearch.Text = ""

        ' ADD THIS CHECK - Exit if categ is Nothing
        If categ Is Nothing Then
            AddTrace("LoadCategories: categ is Nothing, exiting")
            Exit Sub
        End If

        If ddCategories.SelectedItem.Text = "Select" Then
            gvstock.DataSource = createdatatable1(50)
            gvstock.DataBind()
            Exit Sub  ' ADD THIS - Exit early for "Select"
        End If

        Session("GA_ID") = ddCategories.SelectedItem.Value

        lblAccntCode.Text = "Account Code : " + CType(categ.Rows(ddCategories.SelectedIndex - 1)("GA_Code"), String)

        AddTrace("GA_ID: " & Session("GA_ID"))
        AddTrace("Year: " & Session("Year"))
        AddTrace("RadioButtonList1: " & RadioButtonList1.SelectedValue)

        dtItemList = objDerived.GetDataTable("Exec [AMS].[sp_masterlist_categories] '" & Session("GA_ID") & "' , '" & Session("Year") & "' , '" & RadioButtonList1.SelectedValue & "'  ", CommandType.Text)

        ' ADD THIS NULL CHECK
        If dtItemList Is Nothing Then
            AddTrace("LoadCategories: dtItemList is Nothing, creating empty table")
            gvstock.DataSource = createdatatable1(50)
            gvstock.DataBind()
            Exit Sub
        End If

        If dtItemList.Rows.Count = 0 Then
            gvstock.DataSource = createdatatable1(50)
            gvstock.DataBind()

        Else
            If dtItemList.Rows.Count < 50 Then
                dtItemList.Merge(createdatatable1(50 - dtItemList.Rows.Count))
            End If
            gvstock.DataSource = dtItemList
            gvstock.DataBind()
        End If

    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        If txtSearch.Text = "" Then
            Session("Search") = 0
        Else
            Session("Search") = 1
        End If

        If ddSearch.SelectedItem.Value = 1 Then
            Dim myview As DataView
            myview = dtItemList.DefaultView
            Dim searchTerm As String = txtSearch.Text.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]")
            myview.RowFilter = "Item_desc like '%" & searchTerm & "%'"
            gvstock.DataSource = myview
            gvstock.DataBind()

        ElseIf ddSearch.SelectedItem.Value = 2 Then
            Dim myview As DataView
            myview = dtItemList.DefaultView
            Dim searchTerm As String = txtSearch.Text.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]")
            myview.RowFilter = "ItemCode like '%" & searchTerm & "%'"
            gvstock.DataSource = myview
            gvstock.DataBind()
        End If



    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            rb.SelectedIndex = 0
            txtSearch.Text = ""
            gvstock.PageIndex = 0
            gvstock.DataSource = objDerived.GetRecords("exec ams.sp_search_master_list '" & txtSearch.Text & "'," & rb.SelectedIndex & "", CommandType.Text)
            gvstock.DataBind()
        Catch ex As Exception
            AddTrace("Page_Load Error: " & ex.Message)
        End Try
    End Sub

    Protected Sub gvstock_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvstock.PageIndexChanging
        gvstock.PageIndex = e.NewPageIndex
        gvstock.DataSource = dtItemList
        gvstock.DataBind()

        'If Session("Search") = 0 Then
        '    Dim dtInspect As New DataTable
        '    dtInspect = objDerived.GetDataTable("Exec [AMS].[sp_masterlist_categories] '" & Session("GA_ID") & "','" & Session("Year") & "'", CommandType.Text)
        '    If dtInspect.Rows.Count < 50 Then
        '        dtInspect.Merge(createdatatable1(50 - dtInspect.Rows.Count))
        '    End If
        '    gvstock.PageIndex = e.NewPageIndex
        '    gvstock.DataSource = dtInspect
        '    gvstock.DataBind()

        'ElseIf Session("Search") = 1 Then

        '    Dim dtsearch As New DataTable
        '   dtsearch = objDerived.GetDataTable("Exec [AMS].[sp_masterlist_categories_Search] '" & Session("GA_ID") & "','" & Session("Year") & "','" & txtSearch.Text & "'", CommandType.Text)
        '    If dtsearch.Rows.Count < 50 Then
        '        dtsearch.Merge(createdatatable1(50 - dtsearch.Rows.Count))
        '    End If
        '    gvstock.PageIndex = e.NewPageIndex
        '    gvstock.DataSource = dtsearch
        '    gvstock.DataBind()

        'End If

    End Sub
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("no", GetType(Long))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("unit_Desc", GetType(String))
        dt.Columns.Add("price", GetType(Decimal))
        dt.Columns.Add("ga_code2", GetType(Integer))
        dt.Columns.Add("ItemCode", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("no") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("unit_Desc") = DBNull.Value
            dr("price") = DBNull.Value
            dr("ga_code2") = DBNull.Value
            dr("ItemCode") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        loadcategory()
        Session("Allotment_Type") = RadioButtonList1.SelectedValue
        AddTrace("Allotment_Type" & Session("Allotment_Type"))
    End Sub



    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim url As String = ResolveUrl("~/filemaintenance/rpt_MasterList.aspx")

        ScriptManager.RegisterStartupScript(
        Me,
        Me.GetType(),
        "OpenMasterListReport",
        "window.open('" & url & "', '_blank');",
        True
    )

    End Sub
End Class
