Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Bidding_t_AlternativeMode
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            dtPurchaseRequest = objDerived.GetDataTable("EXEC [AMS].[sp_RQ_AlternativeMode]", CommandType.Text)
            If dtPurchaseRequest.Rows.Count < 10 Then
                dtPurchaseRequest.Merge(CDPurchaseRequest(10 - dtPurchaseRequest.Rows.Count))
            End If
            grdPurchaseRequest.DataSource = dtPurchaseRequest
            grdPurchaseRequest.DataBind()

            txtDate_From.Text = Date.Today.ToString("MM/dd/yyyy")
            txtDate_To.Text = Date.Today.ToString("MM/dd/yyyy")

            txtSearch_PRNo.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_PRNo.ClientID & "')")
            txtDate_From.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_PRDate.ClientID & "')")
            txtDate_To.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_PRDate.ClientID & "')")

            LoadrbChoice()

        End If
    End Sub

    Protected Sub grdPurchaseRequest_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdPurchaseRequest.DataSource = dtPurchaseRequest
        grdPurchaseRequest.PageIndex = e.NewPageIndex
        grdPurchaseRequest.DataBind()
    End Sub

    Protected Sub rbChoices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadrbChoice()
    End Sub

    Protected Sub LoadrbChoice()
        If rbChoices.SelectedItem.Value = 1 Then
            Me.mvSearch.SetActiveView(Me.vwPRNumber)
        Else
            Me.mvSearch.SetActiveView(Me.vwPRDate)
        End If
    End Sub

    Protected Sub btnSearch_PRNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtPurchaseRequest.DefaultView
        myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearch_PRNo.Text) & "%'"
        grdPurchaseRequest.DataSource = myview
        grdPurchaseRequest.DataBind()
    End Sub

    Protected Sub btnSearch_PRDate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtPurchaseRequest.DefaultView
        myview.RowFilter = "PR_Date >= '" & txtDate_From.Text & "' AND PR_Date <= '" & txtDate_To.Text & "'"
        grdPurchaseRequest.DataSource = myview
        grdPurchaseRequest.DataBind()
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub lnkSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub grdPurchaseRequest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("obr_evaluation_hdr_id") = grdPurchaseRequest.SelectedDataKey("obr_evaluation_hdr_id")
        Session("Page") = "RQ"
        Session("Report") = "AMP"
        Me.Page.Response.Redirect("~/bidding/rpt_AlternativeMode.aspx")
    End Sub

    Private Property dtPurchaseRequest() As DataTable
        Get
            Return CType(Session("dtPurchaseRequest"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPurchaseRequest") = value
        End Set
    End Property

    Public Function CDPurchaseRequest(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("obr_evaluation_hdr_id", GetType(Long))
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("remarks", GetType(String))
        dt.Columns.Add("PR_Date", GetType(Date))
        dt.Columns.Add("MOP_Desc", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("obr_evaluation_hdr_id") = DBNull.Value
            dr("prhdr_id") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("remarks") = DBNull.Value
            dr("PR_Date") = DBNull.Value
            dr("MOP_Desc") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function


End Class
