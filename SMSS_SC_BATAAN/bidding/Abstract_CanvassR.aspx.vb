Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Bidding_Canvass
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Property dtPurchaseRequest() As DataTable
        Get
            Return CType(Session("dtPurchaseRequest"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPurchaseRequest") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            dtPurchaseRequest = objDerived.GetDataTable("EXEC [AMS].[sp_RQ_CanvassSearch]", CommandType.Text)
            If dtPurchaseRequest.Rows.Count < 10 Then
                dtPurchaseRequest.Merge(PR_DataTable(10 - dtPurchaseRequest.Rows.Count))
            End If
            gvcanvass.DataSource = dtPurchaseRequest
            gvcanvass.DataBind()

            txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

        End If

    End Sub
    Protected Sub drpSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpSearchBy.SelectedIndexChanged
        If drpSearchBy.SelectedItem.Value = 1 Then
            lblSearchBy.Text = "PR Number :"
        ElseIf drpSearchBy.SelectedItem.Value = 2 Then
            lblSearchBy.Text = "Supplier Name :"
        Else
            lblSearchBy.Text = "Pls Select :"
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtPurchaseRequest.DefaultView

        If drpSearchBy.SelectedItem.Value = 1 Then
            myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        ElseIf drpSearchBy.SelectedItem.Value = 2 Then
            myview.RowFilter = "SuppName like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        Else

        End If

        gvcanvass.DataSource = myview
        gvcanvass.DataBind()

    End Sub

    Protected Sub gvcanvass_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        gvcanvass.DataSource = dtPurchaseRequest
        gvcanvass.PageIndex = e.NewPageIndex
        gvcanvass.DataBind()
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function




    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub gvcanvass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "RQ"


        Session("Report") = "AOQ"
        Session("prhdr_id") = gvcanvass.SelectedDataKey("prhdr_id")
        Session("Hdr_ID") = gvcanvass.SelectedDataKey("Hdr_ID")

        Me.Page.Response.Redirect("~/MainReports/Canvass_Reports.aspx")

    End Sub

    Public Function PR_DataTable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("Hdr_ID", GetType(Long))
        dt.Columns.Add("Supplier_ID", GetType(Long))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("isWinner", GetType(Boolean))
        dt.Columns.Add("PR_Date", GetType(Date))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("CanvassYear", GetType(Integer))
        dt.Columns.Add("isDBM", GetType(Boolean))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("Hdr_ID") = DBNull.Value
            dr("Supplier_ID") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("isWinner") = DBNull.Value
            dr("PR_Date") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("CanvassYear") = DBNull.Value
            dr("isDBM") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function


End Class