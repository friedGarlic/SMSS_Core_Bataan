Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class procurement_t_Cancelled_PR
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal



    Private Property dtPRList() As DataTable
        Get
            Return CType(Session("dtPRList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPRList") = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            dtPRList = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Cancelled_PR] ORDER BY pr_no DESC, Date_Submitted DESC", CommandType.Text)
            If dtPRList.Rows.Count < 10 Then
                dtPRList.Merge(CreateTable1(10 - dtPRList.Rows.Count))
            End If
            grdPurchaseRequest.DataSource = dtPRList
            grdPurchaseRequest.DataBind()

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

    End Sub

    Protected Sub grdPurchaseRequest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "CancelPR"
        Session("prhdr_id") = grdPurchaseRequest.SelectedDataKey("prhdr_id")
        Me.Page.Response.Redirect("~/procurement/rpt_purchase_request.aspx")
    End Sub

    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("PR_Date", GetType(String))
        dt.Columns.Add("RC_NAME", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("IsCancelled", GetType(Boolean))
        dt.Columns.Add("IsVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("PR_Date") = DBNull.Value
            dr("RC_NAME") = DBNull.Value
            dr("remarks") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("IsCancelled") = DBNull.Value
            dr("IsVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub grdPurchaseRequest_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdPurchaseRequest.PageIndex = e.NewPageIndex
        grdPurchaseRequest.DataSource = dtPRList
        grdPurchaseRequest.DataBind()
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(Str, "'", "''")
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtPRList.DefaultView
        If ddSearch.SelectedItem.Value = 1 Then
            myview.RowFilter = "PR_no like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        ElseIf ddSearch.SelectedItem.Value = 2 Then
            myview.RowFilter = "RC_Name like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        End If

        grdPurchaseRequest.DataSource = myview
        grdPurchaseRequest.DataBind()

    End Sub
End Class
