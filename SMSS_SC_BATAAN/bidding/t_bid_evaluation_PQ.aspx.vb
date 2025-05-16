Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_t_bid_evaluation_PQ
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

    Private pq_hdr As New t_post_qualification_hdr
    Private pq_dtl As New t_post_qualification_dtl

#Region "Property"
    Private Property pBidEvaluation() As DataTable
        Get
            Return CType(Session("pBidEvaluation"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBidEvaluation") = value
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
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
            If pBidEvaluation.Rows.Count < 5 Then
                pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
            End If
            grdBidEvaluation1.DataSource = pBidEvaluation
            grdBidEvaluation1.DataBind()

            grdBidders.DataSource = Nothing
            grdBidders.DataBind()

        End If
    End Sub

    Protected Sub grdBidEvaluation1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Integer = 1
        Dim cb As CheckBox

        pBidEvaluation_Bidders = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BidEvaluation_Bidders_Items] WHERE pre_procurement_hdr_id = '" & grdBidEvaluation1.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
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
            'btnDoc.Enabled = True
            'btnPQ.Enabled = True
            'btnSave.Enabled = True

        Else
            For i As Integer = 0 To pBidEvaluation_Bidders.Rows.Count - 1
                cb = CType(Me.grdBidders.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                cb.Enabled = False
            Next
        End If
    End Sub

    Protected Sub grdBidEvaluation1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdBidEvaluation1, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdBidEvaluation1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
        If pBidEvaluation.Rows.Count < 5 Then
            pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
        End If
        grdBidEvaluation1.PageIndex = e.NewPageIndex
        grdBidEvaluation1.DataSource = pBidEvaluation
        grdBidEvaluation1.DataBind()
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
            btnSave.Enabled = True
            btnNext.Enabled = True
        Else
            btnSave.Enabled = False
            'btnNext.Enabled = False
        End If

    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/bidding/t_bid_evaluation_ceiling.aspx")
    End Sub

    Protected Sub btnFail_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '=-= DELETE OBR EVALUATION AND UPDATE PR_HDR (ISONBID)
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id =  '" & grdBidEvaluation1.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)
            For i As Integer = 0 To dt.Rows.Count - 1
                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isOnBid = 0 WHERE prhdr_id =  '" & dt.Rows(i)("prhdr_id") & "'", CommandType.Text)
            Next

            objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id = '" & grdBidEvaluation1.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)
            objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_hdr WHERE obr_evaluation_hdr_id = '" & grdBidEvaluation1.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)

            '=-= DELETE PRE PROCUREMENT
            objDerived.GetRecords("DELETE FROM AMS.pre_procurement WHERE pre_procurement_hdr_id = '" & grdBidEvaluation1.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
            objDerived.GetRecords("DELETE FROM AMS.pre_procurement_dtl WHERE pre_procurement_hdr_id =  '" & grdBidEvaluation1.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

            '=-= DELETE BID OPENING
            Dim dt2 As New DataTable
            dt2 = objDerived.GetDataTable("SELECT * FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id = '" & grdBidEvaluation1.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
            For i As Integer = 0 To dt2.Rows.Count - 1
                objDerived.GetRecords("DELETE FROM AMS.bid_opening_dtl WHERE bid_opening_hdr_id =  '" & dt2.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)
            Next

            objDerived.GetRecords("DELETE FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id =  '" & grdBidEvaluation1.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

            '=-= DELETE COLLECTIONS (BIDDERS)
            objDerived.GetRecords("DELETE FROM dbo.tbl_integrated_collections_table WHERE Transaction_ID =  '" & grdBidEvaluation1.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Failure of bidding confirmed.")

            '=-= DEFAULT PAGE
            pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
            If pBidEvaluation.Rows.Count < 5 Then
                pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
            End If
            grdBidEvaluation1.DataSource = pBidEvaluation
            grdBidEvaluation1.DataBind()

            grdBidders.DataSource = Nothing
            grdBidders.DataBind()

            btnback.Enabled = False
            btnFail.Enabled = False
            btnNext.Enabled = False
            btnSave.Enabled = False
            btnPQ.Enabled = False

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox

        For i As Integer = 0 To pBidEvaluation_Bidders.Rows.Count - 1
            cb = CType(Me.grdBidders.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If cb.Checked = True Then
                objDerived.GetRecords("UPDATE AMS.bid_opening_hdr SET isPostQualification = 1 WHERE bid_opening_hdr_id = '" & pBidEvaluation_Bidders.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)
            Else
                objDerived.GetRecords("UPDATE AMS.bid_opening_hdr SET isPostQualification = 0 WHERE bid_opening_hdr_id = '" & pBidEvaluation_Bidders.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)
                cb.Enabled = False
            End If
        Next

        Me.Page.Response.Redirect("~/bidding/t_bid_evaluation_LCB.aspx")

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSave.Enabled = False
        Try

            Dim cb As CheckBox

            Dim check_id As Long

            check_id = objDerived.GetValue("SELECT DISTINCT pre_procurement_hdr_id FROM [AMS].[post_qualification_hdr] WHERE pre_procurement_hdr_id = '" & grdBidEvaluation1.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

            If check_id <> 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Data already existed")
                Exit Sub
            Else
                '===== SAVE HEADER "post_qualification_hdr"
                For i As Integer = 0 To pBidEvaluation_Bidders.Rows.Count - 1
                    cb = CType(Me.grdBidders.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If cb.Checked = True Then
                        Dim t_date = objDerived.GetValue("SELECT transaction_date FROM AMS.pre_procurement WHERE pre_procurement_hdr_id = '" & pBidEvaluation_Bidders.Rows(i)("pre_procurement_hdr_id") & "'", CommandType.Text)

                        With pq_hdr
                            .post_qualification_hdr_id = 0
                            .pre_procurement_hdr_id = pBidEvaluation_Bidders.Rows(i)("pre_procurement_hdr_id")
                            .Supplier_Id = pBidEvaluation_Bidders.Rows(i)("Supplier_Id")
                            .amount = pBidEvaluation_Bidders.Rows(i)("BidAmount")
                            .transaction_date = t_date
                            .isWinner = False
                        End With

                        Dim post_qualification_hdr_id As Long = pq_hdr.save()
                        Session("post_qualification_hdr_id") = post_qualification_hdr_id

                        '===== SAVE DETAIL "post_qualification_dtl"
                        Dim dt4 As New DataTable
                        dt4 = objDerived.GetDataTable("SELECT * FROM [AMS].[bid_opening_dtl] BDtl INNER JOIN [dbo].[View_BidEvaluation_Bidders_Items] BV ON BV.bid_opening_hdr_id = BDtl.bid_opening_hdr_id WHERE BV.bid_opening_hdr_id = '" & pBidEvaluation_Bidders.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)

                        For j As Integer = 0 To dt4.Rows.Count - 1
                            With pq_dtl
                                .post_qualification_dtl_id = 0
                                .post_qualification_hdr_id = Session("post_qualification_hdr_id")
                                .Item_ID = dt4.Rows(j)("item_id")
                                .Qty = dt4.Rows(j)("qty")
                                .Cost = dt4.Rows(j)("Cost")
                                .save()
                            End With
                        Next

                    End If
                Next

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved")


            End If
            btnSave.Enabled = False
            btnNext.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub grdBidders_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBidders.SelectedIndexChanged
        Dim check_id As Long

        check_id = objDerived.GetValue("SELECT DISTINCT pre_procurement_hdr_id FROM [AMS].[post_qualification_hdr] WHERE pre_procurement_hdr_id = '" & grdBidEvaluation1.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

        If check_id <> 0 Then

            btnPQ.Enabled = True
        Else

            btnPQ.Enabled = False
        End If

        btnPQ.Enabled = True
    End Sub

    Protected Sub grdBidders_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBidders.RowDataBound

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdBidders, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub btnPQ_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Supplier_Id") = grdBidders.SelectedDataKey("Supplier_id")
        Session("obr_hdr") = grdBidEvaluation1.SelectedDataKey("obr_evaluation_hdr_id")
        Session("PQ") = "Post_Qua"

        'Me.Page.Response.Redirect("~/bidding/rpt_BidEval_PostQua_v2.aspx")
        Dim url As String = "rpt_BidEval_PostQua_v2.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub

End Class
