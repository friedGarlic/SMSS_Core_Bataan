Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_t_bid_evaluation
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal
    Private hdr As New t_bid_opening_hdr
    Private dtl As New t_bid_opening_dtl

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
    Private Property cb1Count() As Integer
        Get
            Return CType(Session("cb1Count"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("cb1Count") = value
        End Set
    End Property
    Private Property cb2Count() As Integer
        Get
            Return CType(Session("cb2Count"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("cb2Count") = value
        End Set
    End Property
    Private Property cb3Count() As Integer
        Get
            Return CType(Session("cb3Count"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("cb3Count") = value
        End Set
    End Property

    Private Property pGoodsPerSupplier(ByVal supplier_id As String) As DataTable
        Get
            Return CType(Session(supplier_id), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session(supplier_id) = value
        End Set
    End Property

    Private Property pTempSupplier() As DataTable
        Get
            Return CType(Session("pTempSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pTempSupplier") = value
        End Set
    End Property
    Private Property pSupplier() As DataTable
        Get
            Return CType(Session("pSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pSupplier") = value
        End Set
    End Property
    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property
    Private Property pItems() As DataTable
        Get
            Return CType(Session("pItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItems") = value
        End Set
    End Property
    Private Property pPublicBidding() As DataTable
        Get
            Return CType(Session("pPublicBidding"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPublicBidding") = value
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

    Public Function CreateTableGoods(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("Item_Desc")
        dt.Columns.Add("Description")
        dt.Columns.Add("total", GetType(Decimal))
        dt.Columns.Add("enable", GetType(Boolean))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_ID") = 0
            dr("Qty") = 0
            dr("Cost") = "0.00"
            dr("Item_Desc") = ""
            dr("Description") = ""
            dr("total") = "0.00"
            dr("enable") = False
            dr("isVisible") = False

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("obr_evaluation_hdr_id", GetType(Long))
        dt.Columns.Add("project_reference_no")
        dt.Columns.Add("project_name")
        dt.Columns.Add("project_description")
        dt.Columns.Add("project_location")
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("bid_docs", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("CountSupplier", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pre_procurement_hdr_id") = 0
            dr("obr_evaluation_hdr_id") = 0
            dr("project_reference_no") = ""
            dr("project_name") = ""
            dr("project_description") = ""
            dr("project_location") = ""
            dr("ABC") = "0.00"
            dr("bid_docs") = "0.00"
            dr("isVisible") = False
            dr("CountSupplier") = 0
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatableSuppliers(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("indexNo", GetType(Long))
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("SuppName")
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("examination_bid", GetType(Boolean))
        dt.Columns.Add("ceiling_price", GetType(Boolean))
        dt.Columns.Add("isWinner", GetType(Boolean))
        dt.Columns.Add("isPostQualification", GetType(Boolean))
        dt.Columns.Add("bid_opening_hdr_id", GetType(Long))

        dt.Columns.Add("BidSecurity_id", GetType(Long))
        dt.Columns.Add("BankName")
        dt.Columns.Add("Number")
        dt.Columns.Add("ValidityPeriod", GetType(Integer))
        dt.Columns.Add("BidSecurityAmount", GetType(Decimal))
        dt.Columns.Add("remarks")
        dt.Columns.Add("status")
        dt.Columns.Add("withOR", GetType(Boolean))
        dt.Columns.Add("orstatus")
        dt.Columns.Add("enable", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("indexNo") = 0
            dr("Supplier_Id") = 0
            dr("SuppName") = ""
            dr("amount") = "0.00"
            dr("isVisible") = False
            dr("examination_bid") = True
            dr("ceiling_price") = True
            dr("isWinner") = True
            dr("isPostQualification") = True
            dr("bid_opening_hdr_id") = 0
            dr("BidSecurity_id") = 0
            dr("BankName") = ""
            dr("Number") = ""
            dr("ValidityPeriod") = 0
            dr("BidSecurityAmount") = "0.00"
            dr("remarks") = ""
            dr("status") = ""
            dr("withOR") = False
            dr("orstatus") = ""
            dr("enable") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                'obj.GetAccessRight(Me.Session("@UserName"), Page)
                'If obj.HasAccess = False Then
                '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
                'End If

                pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
                If pBidEvaluation.Rows.Count < 5 Then
                    pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
                End If
                grdBidEvaluation.DataSource = pBidEvaluation
                grdBidEvaluation.DataBind()

                lblBidEvaluationStage.Text = "Preliminary Examination Of Bids"

                ddBidder.DataSource = Nothing
                ddBidder.DataBind()
                ddBidder.Items.Insert(0, "Select")

                grdGoods.DataSource = CreateTableGoods(5)
                grdGoods.DataBind()

                grdBidders.DataSource = CreateTable2(5)
                grdBidders.DataBind()


            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grdBidEvaluation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadDetails()
    End Sub

    Protected Sub LoadDetails()
        ddBidder.Enabled = True

        pSupplier = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_Bidders] '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        ddBidder.DataSource = pSupplier
        ddBidder.DataTextField = "SuppName"
        ddBidder.DataValueField = "Supplier_id"
        ddBidder.DataBind()
        ddBidder.Items.Insert(0, "Select")

        pBidEvaluation_Goods = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_Goods] '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        grdGoods.DataSource = pBidEvaluation_Goods
        grdGoods.DataBind()

        LoadCost()

        pBidEvaluation_Bidders = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BidEvaluation_Bidders_Items] WHERE pre_procurement_hdr_id = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        grdBidders.DataSource = pBidEvaluation_Bidders
        grdBidders.DataBind()

        btnSave.Enabled = False
        'btnback.Enabled = True
    End Sub
    'Protected Sub LoadDetails()
    '    ' Enable dropdown for bidders
    '    ddBidder.Enabled = True
    '    btnSave.Enabled = False
    '    'btnback.Enabled = True (Uncomment if the back button needs to be enabled)

    '    ' Load data for the drop-down list of bidders
    '    LoadBidderDropdown()

    '    ' Load data for the goods associated with the bid evaluation
    '    LoadGoodsForBidEvaluation()

    '    ' Load data for the bidder evaluation
    '    LoadBidderEvaluation()

    '    ' Load additional cost details if necessary
    '    LoadCost()
    'End Sub

    'Private Sub LoadBidderDropdown()
    '    Dim procurementId As String = Convert.ToString(grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id"))
    '    Dim pSupplier As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_Bidders] '" & procurementId & "'", CommandType.Text)

    '    With ddBidder
    '        .DataSource = pSupplier
    '        .DataTextField = "SuppName"
    '        .DataValueField = "Supplier_id"
    '        .DataBind()
    '        .Items.Insert(0, New ListItem("Select", ""))
    '    End With
    'End Sub

    'Private Sub LoadGoodsForBidEvaluation()
    '    Dim procurementId As String = Convert.ToString(grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id"))
    '    Dim pBidEvaluationGoods As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_Goods] '" & procurementId & "'", CommandType.Text)

    '    grdGoods.DataSource = pBidEvaluationGoods
    '    grdGoods.DataBind()
    'End Sub

    Private Sub LoadBidderEvaluation()
        Dim procurementId As String = Convert.ToString(grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id"))
        Dim pBidEvaluationBidders As DataTable = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BidEvaluation_Bidders_Items] WHERE pre_procurement_hdr_id = '" & procurementId & "'", CommandType.Text)

        grdBidders.DataSource = pBidEvaluationBidders
        grdBidders.DataBind()
    End Sub


    Protected Sub grdGoods_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdGoods.SelectedIndexChanged
        Try

            If Session("Delete") = 0 Then
                If grdBidders.Rows.Count = 0 Then
                    objDerived.Execute("EXEC [AMS].[sp_BidEval_ItemRemove] " & grdGoods.SelectedDataKey("PRDtlID") & "," & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "", CommandType.Text)

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected item has been successfully removed from purchase request.")

                    pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
                    If pBidEvaluation.Rows.Count < 5 Then
                        pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
                    End If
                    grdBidEvaluation.DataSource = pBidEvaluation
                    grdBidEvaluation.DataBind()

                    LoadDetails()

                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "All items are now on bid. Deletion cannot be performed.")
                End If

                Session("Delete") = 1
            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please contact system admin.")
        End Try
    End Sub
    'Protected Sub grdGoods_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdGoods.SelectedIndexChanged
    '    Try
    '        If Convert.ToInt32(Session("Delete")) = 0 Then
    '            If grdBidders.Rows.Count = 0 Then
    '                RemoveSelectedItem()
    '            Else
    '                DisplayAlert("All items are now on bid. Deletion cannot be performed.")
    '            End If

    '            ' Mark the item as deleted after attempting to remove it
    '            Session("Delete") = 1
    '        End If
    '    Catch ex As Exception
    '        DisplayAlert("Please contact system admin.")
    '        ' Log the exception here if you have a logging framework
    '    End Try
    'End Sub

    Private Sub RemoveSelectedItem()
        ' Executes stored procedure to remove an item
        Dim itemRemoveQuery As String = String.Format("EXEC [AMS].[sp_BidEval_ItemRemove] {0}, {1}",
                                                  grdGoods.SelectedDataKey("PRDtlID"),
                                                  grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id"))
        objDerived.Execute(itemRemoveQuery, CommandType.Text)

        ' Notify the user of successful deletion
        DisplayAlert("Selected item has been successfully removed from purchase request.")

        ' Reload the bid evaluation to reflect changes
        ReloadBidEvaluation()

        ' Reload the detail section
        LoadDetails()
    End Sub

    Private Sub ReloadBidEvaluation()
        Dim pBidEvaluation As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
        If pBidEvaluation.Rows.Count < 5 Then
            pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
        End If
        grdBidEvaluation.DataSource = pBidEvaluation
        grdBidEvaluation.DataBind()
    End Sub

    Private Sub DisplayAlert(message As String)
        MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, message)
    End Sub

    Protected Sub lnkRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Delete") = 0
    End Sub

    Protected Sub ddBidder_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("bid_opening_hdr_id") = pSupplier.Rows(ddBidder.SelectedIndex - 1)("bid_opening_hdr_id")
        Session("BidAmount") = pSupplier.Rows(ddBidder.SelectedIndex - 1)("amount")

        If Session("BidAmount") = 0.00 Then
            For i As Integer = 0 To grdGoods.Rows.Count - 1
                CType(grdGoods.Rows(i).FindControl("txtBidUnitPrice"), TextBox).Text = 0.00
            Next

            LoadCost()

        End If

        btnSave.Enabled = True
    End Sub

    Protected Sub grdBidEvaluation_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBidEvaluation.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdBidEvaluation, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub txtBidUnitPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtBidUnitPrice As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtBidUnitPrice.NamingContainer, GridViewRow)

        txtBidUnitPrice.Text = FormatNumber(txtBidUnitPrice.Text, 2)

        LoadCost()
    End Sub

    Protected Sub LoadCost()
        If grdGoods.Rows.Count <> 0 Then
            Dim x As Decimal = 0
            For i As Integer = 0 To grdGoods.Rows.Count - 1
                Dim txtUnitPrice As TextBox = CType(grdGoods.Rows(i).FindControl("txtBidUnitPrice"), TextBox)
                Dim txtqty As Label = CType(grdGoods.Rows(i).FindControl("txtQty"), Label)

                Dim TAmount As Decimal = FormatNumber(txtUnitPrice.Text * txtqty.Text, 2)
                CType(grdGoods.Rows(i).FindControl("lblTotal"), Label).Text = FormatNumber(TAmount, 2)

                x = x + (txtUnitPrice.Text * txtqty.Text)
            Next

            CType(grdGoods.FooterRow.Cells(5).FindControl("lblTotalBid"), Label).Text = FormatNumber(x, 2)

            btnFail.Enabled = True
            btnNext.Enabled = True

        Else
            btnFail.Enabled = False
            btnNext.Enabled = False
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim TotalBid As Decimal = CType(grdGoods.FooterRow.Cells(5).FindControl("lblTotalBid"), Label).Text

        If Session("BidAmount") > TotalBid Then
            Dim Amount As Decimal = FormatNumber(Session("BidAmount"), 2)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The total amount exceed to your total bid amount of " & FormatNumber(Amount, 2) & ".")
        Else
            For i As Integer = 0 To grdGoods.Rows.Count - 1
                Dim txtUnitPrice As TextBox = CType(grdGoods.Rows(i).FindControl("txtBidUnitPrice"), TextBox)
                Dim txtqty As Label = CType(grdGoods.Rows(i).FindControl("txtQty"), Label)

                With dtl
                    .bid_opening_hdr_id = Session("bid_opening_hdr_id")
                    .item_id = pBidEvaluation_Goods.Rows(i)("Item_ID")
                    .qty = txtqty.Text

                    If Session("BidAmount") = 0.00 Then
                        .Cost = 0.00
                    Else
                        .Cost = txtUnitPrice.Text
                    End If

                End With

                Dim dtl_ID As Long
                dtl_ID = objDerived.GetValue("SELECT bid_opening_dtl_id FROM AMS.bid_opening_dtl WHERE bid_opening_hdr_id = '" & Session("bid_opening_hdr_id") & "' AND item_id = '" & pBidEvaluation_Goods.Rows(i)("Item_ID") & "'", CommandType.Text)
                If dtl_ID = 0 Then
                    dtl.save()
                Else
                    dtl.bid_opening_dtl_id = dtl_ID
                    dtl.update()
                End If

            Next

            objDerived.GetRecords("UPDATE AMS.bid_opening_dtl SET withWinner = 0 where bid_opening_hdr_id = '" & Session("bid_opening_hdr_id") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            pBidEvaluation_Goods = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_Goods] '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
            grdGoods.DataSource = pBidEvaluation_Goods
            grdGoods.DataBind()

            LoadCost()

            pBidEvaluation_Bidders = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BidEvaluation_Bidders_Items] WHERE pre_procurement_hdr_id = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
            grdBidders.DataSource = pBidEvaluation_Bidders
            grdBidders.DataBind()

            btnSave.Enabled = False
        End If
    End Sub

    Protected Sub btnFail_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        'Try
        '=-= DELETE OBR EVALUATION AND UPDATE PR_HDR (ISONBID)
        Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id =  '" & grdBidEvaluation.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)
        For i As Integer = 0 To dt.Rows.Count - 1
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isOnBid = 0  WHERE prhdr_id =  '" & dt.Rows(i)("prhdr_id") & "'", CommandType.Text)

            objDerived.GetRecords("UPDATE AMS.Pre_procurement SET isFailureToBid = 1  WHERE [pre_procurement_hdr_id] = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

        Next

        'objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id =  '" & grdBidEvaluation.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)
        'objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_hdr WHERE obr_evaluation_hdr_id =  '" & grdBidEvaluation.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)

        '=-= DELETE PRE PROCUREMENT
        'objDerived.GetRecords("DELETE FROM AMS.pre_procurement WHERE pre_procurement_hdr_id = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        'objDerived.GetRecords("DELETE FROM AMS.pre_procurement_dtl WHERE pre_procurement_hdr_id =  '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

        'objDerived.GetRecords("UPDATE [AMS].[pre_procurement] SET [withBid] = 0 WHERE [pre_procurement_hdr_id] = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        'objDerived.GetRecords("UPDATE [AMS].[pre_procurement_dtl] SET [obr_evaluation_dtl_id] = 0 WHERE [pre_procurement_hdr_id] = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

        '=-= DELETE BID OPENING
        Dim dt2 As New DataTable
            dt2 = objDerived.GetDataTable("SELECT * FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        For i As Integer = 0 To dt2.Rows.Count - 1
            'objDerived.GetRecords("DELETE FROM AMS.bid_opening_dtl WHERE bid_opening_hdr_id =  '" & dt2.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)
        Next

        'objDerived.GetRecords("DELETE FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id =  '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

        ''=-= DELETE COLLECTIONS (BIDDERS)
        'objDerived.GetRecords("DELETE FROM dbo.tbl_integrated_collections_table WHERE Transaction_ID =  '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.Pre_procurement SET CountFailureToBid = ISNULL(CountFailureToBid, 0) + 1  WHERE [pre_procurement_hdr_id] = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        Dim intCountFailureToBid As Integer
        intCountFailureToBid = objDerived.GetValue("select CountFailureToBid from AMS.Pre_procurement where [pre_procurement_hdr_id] = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        If intCountFailureToBid = 2 Then
            Dim HDR_ID As Integer
            HDR_ID = objDerived.GetValue("SELECT  distinct d.prhdr_id " &
                                         " FROM  AMS.obr_evaluation_hdr AS a INNER JOIN " &
                                         " AMS.pre_procurement AS b ON a.obr_evaluation_hdr_id = b.obr_evaluation_hdr_id INNER JOIN " &
                                         " AMS.obr_evaluation_dtl AS c INNER JOIN " &
                                         " AMS.PR_Hdr AS d ON c.prhdr_id = d.prhdr_id ON a.obr_evaluation_hdr_id = c.obr_evaluation_hdr_id " &
                                         " where b.pre_procurement_hdr_id = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
            If HDR_ID <> 0 Then
                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET mode_of_procurement_id = 4  WHERE prhdr_id = '" & HDR_ID & "'", CommandType.Text)
            End If
            objDerived.GetRecords("UPDATE [AMS].[pre_procurement] SET [withBid] = 0 WHERE [pre_procurement_hdr_id] = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE [AMS].[pre_procurement_dtl] SET [obr_evaluation_dtl_id] = 0 WHERE [pre_procurement_hdr_id] = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

        Else

        End If
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Failure of bidding confirmed.")

        '=-= DEFAULT PAGE
        pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
        If pBidEvaluation.Rows.Count < 5 Then
            pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
        End If
        grdBidEvaluation.DataSource = pBidEvaluation
        grdBidEvaluation.DataBind()

        lblBidEvaluationStage.Text = "PRELIMINARY EXAMINATION OF BIDS"

        ddBidder.DataSource = Nothing
        ddBidder.DataBind()
        ddBidder.Items.Insert(0, "Select")

        grdGoods.DataSource = Nothing
        grdGoods.DataBind()

        grdBidders.DataSource = Nothing
        grdBidders.DataBind()

        btnback.Enabled = False
        btnFail.Enabled = False
        btnNext.Enabled = False

        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Contact Admin.")
        'End Try
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If grdBidders.Rows.Count = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No bidders selected.")

        ElseIf pSupplier.Rows.Count <> grdBidders.Rows.Count Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set all bidders information.")
        Else
            For i As Integer = 0 To pBidEvaluation_Bidders.Rows.Count - 1
                If pBidEvaluation_Bidders.Rows(i)("BidAmount") <> 0 Then
                    objDerived.GetRecords("UPDATE AMS.bid_opening_hdr SET examination_bid = 1 WHERE bid_opening_hdr_id = '" & pBidEvaluation_Bidders.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)
                Else
                    objDerived.GetRecords("UPDATE AMS.bid_opening_hdr SET examination_bid = 0 WHERE bid_opening_hdr_id = '" & pBidEvaluation_Bidders.Rows(i)("bid_opening_hdr_id") & "'", CommandType.Text)
                End If
            Next
            Me.Page.Response.Redirect("~/bidding/t_bid_evaluation_ceiling.aspx")
            btnback.Enabled = True
        End If

    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            objDerived.GetRecords("UPDATE AMS.pre_procurement SET withBid = 0 WHERE pre_procurement_hdr_id = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully return to previous process.")

            pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
            If pBidEvaluation.Rows.Count < 5 Then
                pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
            End If
            grdBidEvaluation.DataSource = pBidEvaluation
            grdBidEvaluation.DataBind()

            grdGoods.DataSource = Nothing
            grdGoods.DataBind()


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdBidEvaluation_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
        If pBidEvaluation.Rows.Count < 5 Then
            pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
        End If
        grdBidEvaluation.PageIndex = e.NewPageIndex
        grdBidEvaluation.DataSource = pBidEvaluation
        grdBidEvaluation.DataBind()

    End Sub

    Protected Sub txtQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Page.Response.Redirect("~/bidding/t_bid_evaluation.aspx")
    End Sub


End Class


