Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_t_post_qualification_report
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

    Private pq_hdr As New t_post_qualification_hdr
    Private pq_dtl As New t_post_qualification_dtl

#Region "Property"
    Private Property pPostQualification() As DataTable
        Get
            Return CType(Session("pPostQualification"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPostQualification") = value
        End Set
    End Property

    Private Property pBidders() As DataTable
        Get
            Return CType(Session("pBidders"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBidders") = value
        End Set
    End Property
#End Region

#Region "Function"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("RefNumber", GetType(String))
        dt.Columns.Add("BidLocation", GetType(String))
        dt.Columns.Add("countSupplier", GetType(Integer))
        dt.Columns.Add("TotalABC", GetType(Decimal))
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("obr_evaluation_hdr_id", GetType(Long))
        dt.Columns.Add("isPublicInfra", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("RefNumber") = DBNull.Value
            dr("BidLocation") = DBNull.Value
            dr("countSupplier") = DBNull.Value
            dr("TotalABC") = DBNull.Value
            dr("pre_procurement_hdr_id") = DBNull.Value
            dr("obr_evaluation_hdr_id") = DBNull.Value
            dr("isPublicInfra") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
#End Region

    Protected Sub Page_Load() Handles Me.Load
        If Not Page.IsPostBack Then
            pPostQualification = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_report]", CommandType.Text)
            If pPostQualification.Rows.Count < 5 Then
                pPostQualification.Merge(CreateTable1(5 - pPostQualification.Rows.Count))
            End If
            grdPostQualification.DataSource = pPostQualification
            grdPostQualification.DataBind()

            grdBidders1.DataSource = Nothing
            grdBidders1.DataBind()
        End If
    End Sub

    Protected Sub grdPostQualification_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Integer = 1

        pBidders = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BidEvaluation_Bidders_Items] WHERE pre_procurement_hdr_id = '" & grdPostQualification.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        If pBidders.Rows.Count = 0 Then
            x = 0
        End If
        grdBidders1.DataSource = pBidders
        grdBidders1.DataBind()
    End Sub

    Protected Sub grdPostQualification_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onClick", ClientScript.GetPostBackEventReference(grdPostQualification, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdPostQualification_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pPostQualification = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_report]", CommandType.Text)
        If pPostQualification.Rows.Count < 5 Then
            pPostQualification.Merge(CreateTable1(5 - pPostQualification.Rows.Count))
        End If
        grdPostQualification.PageIndex = e.NewPageIndex
        grdPostQualification.DataSource = pPostQualification
        grdPostQualification.DataBind()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim myview As DataView
            myview = pPostQualification.DefaultView

            If drpSearch.SelectedItem.Value = 1 Then
                myview.RowFilter = "RefNumber like '%" & txtSearch.Text & "%'"
            ElseIf drpSearch.SelectedItem.Value = 2 Then
                myview.RowFilter = "BidLocation like '%" & txtSearch.Text & "%'"
            End If

            grdPostQualification.DataSource = myview
            grdPostQualification.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grdBidders1_SelectedIndexChanged() Handles grdBidders1.SelectedIndexChanged
        'Dim check_id As Long

        'check_id = objDerived.GetValue("SELECT DISTINCT pre_procurement_hdr_id FROM [AMS].[post_qualification_hdr] WHERE pre_procurement_hdr_id = '" & grdPostQualification.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        'If check_id <> 0 Then
        '    btnPQ.Enabled = True
        'Else
        '    btnPQ.Enabled = False
        'End If
        btnPQ.Enabled = True
    End Sub

    Protected Sub grdBidders1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBidders1.RowDataBound

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdBidders1, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub btnPQ_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Supplier_Id") = grdBidders1.SelectedDataKey("Supplier_id")
        Session("obr_hdr") = grdPostQualification.SelectedDataKey("obr_evaluation_hdr_id")
        Session("PQ") = "Report"

        'Me.Page.Response.Redirect("~/bidding/rpt_BidEval_PostQua_v2.aspx")
        Dim url As String = "rpt_BidEval_PostQua_v2.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub
End Class
