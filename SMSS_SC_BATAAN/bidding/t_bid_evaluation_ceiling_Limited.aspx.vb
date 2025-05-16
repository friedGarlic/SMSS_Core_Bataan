Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class t_bid_evaluation_ceiling_Limited
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal


#Region "Property"
    Private Property pBidEvaluation() As DataTable
        Get
            Return CType(Session("pBidEvaluation"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBidEvaluation") = value
        End Set
    End Property
    Private Property pBidEvaluation_Goods() As DataTable
        Get
            Return CType(Session("pBidEvaluation_Goods"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBidEvaluation_Goods") = value
        End Set
    End Property
    Private Property pBidEvaluation_Bidders() As DataTable
        Get
            Return CType(Session("pBidEvaluation_Bidders"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBidEvaluation_Bidders") = value
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
    Public Function CreateTable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("NoItems", GetType(Integer))
        dt.Columns.Add("BidAmount", GetType(Decimal))
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = DBNull.Value
            dr("NoItems") = DBNull.Value
            dr("BidAmount") = DBNull.Value
            dr("pre_procurement_hdr_id") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_Limited]", CommandType.Text)
            If pBidEvaluation.Rows.Count < 5 Then
                pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
            End If
            grdBidEvaluation.DataSource = pBidEvaluation
            grdBidEvaluation.DataBind()

            grdBidders.DataSource = Nothing
            grdBidders.DataBind()

            lblBidEvaluationStage.Text = "Ceiling For Bid Prices"
        End If
    End Sub

    Protected Sub grdBidEvaluation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Integer = 1
        Dim cb As CheckBox

        pBidEvaluation_Bidders = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BidEvaluation_Bidders_Items] WHERE pre_procurement_hdr_id = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        If pBidEvaluation_Bidders.Rows.Count = 0 Then
            x = 0
        End If
        grdBidders.DataSource = pBidEvaluation_Bidders
        grdBidders.DataBind()

        If x <> 0 Then
            For i As Integer = 0 To pBidEvaluation_Bidders.Rows.Count - 1
                cb = CType(Me.grdBidders.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If pBidEvaluation_Bidders.Rows(i)("BidAmount") <> 0 Then
                    cb.Enabled = True
                Else
                    cb.Enabled = False
                End If
            Next

            btnback.Enabled = True
            btnFail.Enabled = True

        Else
            For i As Integer = 0 To pBidEvaluation_Bidders.Rows.Count - 1
                cb = CType(Me.grdBidders.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                cb.Enabled = False
            Next
        End If
    End Sub

    Protected Sub grdBidEvaluation_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdBidEvaluation, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdBidEvaluation_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_Limited]", CommandType.Text)
        If pBidEvaluation.Rows.Count < 5 Then
            pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
        End If
        grdBidEvaluation.PageIndex = e.NewPageIndex
        grdBidEvaluation.DataSource = pBidEvaluation
        grdBidEvaluation.DataBind()
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox
        Dim x As Integer = 0
        For i As Integer = 0 To pBidEvaluation_Bidders.Rows.Count - 1
            cb = CType(Me.grdBidders.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If cb.Checked = True Then
                x = 1
            End If
        Next

        If x = 1 Then
            btnNext.Enabled = True
        Else
            btnNext.Enabled = False
        End If

    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox
        If lblBidEvaluationStage.Text = "Ceiling For Bid Prices" Then
            Me.Page.Response.Redirect("~/bidding/t_bid_evaluation.aspx")
        ElseIf lblBidEvaluationStage.Text = "Post Qualification" Then
            lblBidEvaluationStage.Text = "Ceiling For Bid Prices"

            For i As Integer = 0 To pBidEvaluation_Bidders.Rows.Count - 1
                cb = CType(Me.grdBidders.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                cb.Checked = False
                cb.Enabled = True
            Next
        End If

    End Sub

    Protected Sub btnFail_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '=-= DELETE OBR EVALUATION AND UPDATE PR_HDR (ISONBID)
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id =  '" & grdBidEvaluation.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)
            For i As Integer = 0 To dt.Rows.Count - 1
                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isOnBid = 0 WHERE prhdr_id =  '" & dt.Rows(i)("prhdr_id") & "'", CommandType.Text)
            Next

            objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id =  '" & grdBidEvaluation.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)
            objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_hdr WHERE obr_evaluation_hdr_id =  '" & grdBidEvaluation.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)

            '=-= DELETE PRE PROCUREMENT
            objDerived.GetRecords("DELETE FROM AMS.pre_procurement WHERE pre_procurement_hdr_id = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
            objDerived.GetRecords("DELETE FROM AMS.pre_procurement_dtl WHERE pre_procurement_hdr_id =  '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

            '=-= DELETE BID OPENING
            Dim dt2 As New DataTable
            dt2 = objDerived.GetDataTable("SELECT * FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
            For i As Integer = 0 To dt2.Rows.Count - 1
                objDerived.GetRecords("DELETE FROM AMS.bid_opening_dtl WHERE bid_opening_hdr_id =  '" & dt2.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)
            Next

            objDerived.GetRecords("DELETE FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id =  '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

            '=-= DELETE COLLECTIONS (BIDDERS)
            objDerived.GetRecords("DELETE FROM dbo.tbl_integrated_collections_table WHERE Transaction_ID =  '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Failure of bidding confirmed.")

            '=-= DEFAULT PAGE
            pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_Limited]", CommandType.Text)
            If pBidEvaluation.Rows.Count < 5 Then
                pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
            End If
            grdBidEvaluation.DataSource = pBidEvaluation
            grdBidEvaluation.DataBind()

            grdBidders.DataSource = Nothing
            grdBidders.DataBind()

            lblBidEvaluationStage.Text = "Ceiling For Bid Prices"
            btnback.Enabled = False
            btnFail.Enabled = False
            btnNext.Enabled = False

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox

        If lblBidEvaluationStage.Text = "Ceiling For Bid Prices" Then
            lblBidEvaluationStage.Text = "Post Qualification"

            For i As Integer = 0 To pBidEvaluation_Bidders.Rows.Count - 1
                cb = CType(Me.grdBidders.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Checked = True Then
                    objDerived.GetRecords("UPDATE AMS.bid_opening_hdr SET ceiling_price = 1 WHERE bid_opening_hdr_id = '" & pBidEvaluation_Bidders.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)
                Else
                    objDerived.GetRecords("UPDATE AMS.bid_opening_hdr SET ceiling_price = 0 WHERE bid_opening_hdr_id = '" & pBidEvaluation_Bidders.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)
                    cb.Enabled = False
                End If
            Next

            For i As Integer = 0 To pBidEvaluation_Bidders.Rows.Count - 1
                cb = CType(Me.grdBidders.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                cb.Checked = False
            Next

        ElseIf lblBidEvaluationStage.Text = "Post Qualification" Then
            For i As Integer = 0 To pBidEvaluation_Bidders.Rows.Count - 1
                cb = CType(Me.grdBidders.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Checked = True Then
                    objDerived.GetRecords("UPDATE AMS.bid_opening_hdr SET isPostQualification = 1 WHERE bid_opening_hdr_id = '" & pBidEvaluation_Bidders.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)
                Else
                    objDerived.GetRecords("UPDATE AMS.bid_opening_hdr SET isPostQualification = 0 WHERE bid_opening_hdr_id = '" & pBidEvaluation_Bidders.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)
                    cb.Enabled = False
                End If
            Next

            Me.Page.Response.Redirect("~/bidding/t_bid_evaluation_LCB_Limited.aspx")
        End If
    End Sub
End Class
