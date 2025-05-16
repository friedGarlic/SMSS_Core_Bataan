Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.Extensions
Partial Class bidding_t_abstract_of_bids_Limited
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal
    Private hdr As New t_bid_opening_hdr
    Private dtl As New t_bid_opening_dtl


#Region "Property"
    Private Property dtAbstractBids() As DataTable
        Get
            Return CType(Session("dtAbstractBids"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAbstractBids") = value
        End Set
    End Property
    Private Property dtAbstractBids_Info() As DataTable
        Get
            Return CType(Session("dtAbstractBids_Info"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAbstractBids_Info") = value
        End Set
    End Property
    Private Property isEdited() As Boolean
        Get
            Return CType(Session("isEdited"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("isEdited") = value
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
            'obj.GetAccessRight(Me.Session("@UserName"), Page)
            'If obj.HasAccess = False Then
            '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            'End If

            txtResDate.Text = Date.Today.ToString("MM/dd/yyyy")

            dtAbstractBids = objDerived.GetDataTable("EXEC [AMS].[sp_AbstractOfBid_Limited]", CommandType.Text)
            If dtAbstractBids.Rows.Count < 5 Then
                dtAbstractBids.Merge(CreateTable1(5 - dtAbstractBids.Rows.Count))
            End If
            grdAbstractBids.DataSource = dtAbstractBids
            grdAbstractBids.DataBind()

            grdGoods.DataSource = Nothing
            grdGoods.DataBind()

        End If
    End Sub
    'Protected Sub grdAbstractBids_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Session("pre_procurement_hdr_id") = grdAbstractBids.SelectedDataKey("pre_procurement_hdr_id")

    '    dtAbstractBids_Info = objDerived.GetDataTable("EXEC [AMS].[sp_AbstractBid_Info] '" & grdAbstractBids.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
    '    grdGoods.DataSource = dtAbstractBids_Info
    '    grdGoods.DataBind()

    '    If dtAbstractBids_Info.Rows.Count <> 0 Then
    '        Dim x As Decimal = 0
    '        For i As Integer = 0 To dtAbstractBids_Info.Rows.Count - 1
    '            Dim Total As Decimal = dtAbstractBids_Info.Rows(i)("TotalBid")
    '            x = x + Total
    '        Next

    '        CType(grdGoods.FooterRow.Cells(5).FindControl("lblTotalBid"), Label).Text = FormatNumber(x, 2)

    '        btnSave.Enabled = True
    '        btnPreviewCalculated.Enabled = True
    '        btnPreviewRead.Enabled = True
    '        btnReturn.Enabled = True
    '    Else
    '        btnSave.Enabled = False
    '        btnPreviewCalculated.Enabled = False
    '        btnPreviewRead.Enabled = False
    '        btnReturn.Enabled = False

    '    End If
    'End Sub
    Protected Sub grdAbstractBids_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAbstractBids.SelectedIndexChanged
        ' Update session with the selected pre-procurement header ID
        Dim selectedPreProcHdrId As String = Convert.ToString(grdAbstractBids.SelectedDataKey("pre_procurement_hdr_id"))
        Session("pre_procurement_hdr_id") = selectedPreProcHdrId

        ' Fetch and bind abstract bid information
        BindAbstractBidInfo(selectedPreProcHdrId)

        ' Enable or disable buttons based on data availability
        Dim areButtonsEnabled As Boolean = dtAbstractBids_Info.Rows.Count <> 0
        EnableDisableButtons(areButtonsEnabled)
    End Sub

    Private Sub BindAbstractBidInfo(ByVal preProcHdrId As String)
        dtAbstractBids_Info = objDerived.GetDataTable("EXEC [AMS].[sp_AbstractBid_Info] '" & preProcHdrId & "'", CommandType.Text)
        grdGoods.DataSource = dtAbstractBids_Info
        grdGoods.DataBind()

        ' Calculate and display total bid if information exists
        If dtAbstractBids_Info IsNot Nothing AndAlso dtAbstractBids_Info.Rows.Count > 0 Then
            Dim totalBid As Decimal = dtAbstractBids_Info.AsEnumerable().Sum(Function(row) Convert.ToDecimal(row("TotalBid")))
            If grdGoods.FooterRow IsNot Nothing Then
                CType(grdGoods.FooterRow.Cells(5).FindControl("lblTotalBid"), Label).Text = FormatNumber(totalBid, 2)
            End If
        End If
    End Sub

    Private Sub EnableDisableButtons(ByVal isEnabled As Boolean)
        btnSave.Enabled = isEnabled
        btnPreviewCalculated.Enabled = isEnabled
        btnPreviewRead.Enabled = isEnabled
        btnReturn.Enabled = isEnabled
    End Sub
    Protected Sub grdAbstractBids_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdAbstractBids, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdAbstractBids_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtAbstractBids = objDerived.GetDataTable("EXEC [AMS].[sp_AbstractOfBid_Limited]", CommandType.Text)
        If dtAbstractBids.Rows.Count < 5 Then
            dtAbstractBids.Merge(CreateTable1(5 - dtAbstractBids.Rows.Count))
        End If
        grdAbstractBids.PageIndex = e.NewPageIndex
        grdAbstractBids.DataSource = dtAbstractBids
        grdAbstractBids.DataBind()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Reso As String = objDerived.GetValue("SELECT [AMS].[func_GenerateBAC] ('" & txtResDate.Text & "')", CommandType.Text)
        txtResolutionNumber.Text = Reso

        txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

        isEdited = False
        txtResolutionNumber.ReadOnly = True

        ModalPopupExtender1.Show()
    End Sub

    Protected Sub btnPreviewCalculated_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("isCalculated") = True
        ' Me.Page.Response.Redirect("~/bidding/rpt_abstract_of_bids_calculated.aspx")

        Dim url As String = "rpt_abstract_of_bids_calculated_and_read.aspx"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub

    Protected Sub btnPreviewRead_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Session("isCalculated") = False
        ' Me.Page.Response.Redirect("~/bidding/rpt_abstract_of_bids_calculated.aspx")
        Dim url As String = "rpt_abstract_of_bids_calculated_and_read.aspx"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)



    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click

        objDerived.GetRecords("UPDATE AMS.pre_procurement SET isResoNo_Edited = '" & isEdited & "', resolution_number_date = '" & txtDate.Text & "', declarationDate='" & txtResDate.Text & "', resolution_number = '" & txtResolutionNumber.Text & "' WHERE pre_procurement_hdr_id = '" & grdAbstractBids.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        btnSave.Enabled = False
        btnPreviewCalculated.Enabled = True

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Abstract of bids has been successfully saved.")

        dtAbstractBids = objDerived.GetDataTable("EXEC [AMS].[sp_AbstractOfBid_Limited]", CommandType.Text)
        If dtAbstractBids.Rows.Count < 5 Then
            dtAbstractBids.Merge(CreateTable1(5 - dtAbstractBids.Rows.Count))
        End If
        btnReturn.Enabled = False
        grdAbstractBids.DataSource = dtAbstractBids
        grdAbstractBids.DataBind()

        grdGoods.DataSource = Nothing
        grdGoods.DataBind()

    End Sub

    Protected Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click

        objDerived.GetRecords("UPDATE [AMS].[pre_procurement] SET [withWinner] = 0 WHERE [pre_procurement_hdr_id] = '" & grdAbstractBids.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully returned.")

        dtAbstractBids = objDerived.GetDataTable("EXEC [AMS].[sp_AbstractOfBid_Limited]", CommandType.Text)
        If dtAbstractBids.Rows.Count < 5 Then
            dtAbstractBids.Merge(CreateTable1(5 - dtAbstractBids.Rows.Count))
        End If
        grdAbstractBids.DataSource = dtAbstractBids
        grdAbstractBids.DataBind()

        grdGoods.DataSource = Nothing
        grdGoods.DataBind()

    End Sub
    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        txtResolutionNumber.ReadOnly = False
        isEdited = True

        ModalPopupExtender1.Show()
    End Sub

End Class
