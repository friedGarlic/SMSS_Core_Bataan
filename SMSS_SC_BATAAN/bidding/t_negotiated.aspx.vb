Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_t_negotiated
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Private hdr As New t_canvass_hdr
    Private dtl As New t_canvass_dtl
    Dim hdr2 As New t_obr_evaluation_hdr
    Dim dtl2 As New t_obr_evaluation_dtl
    Dim pohdr As New t_purchase_order_hdr
    Dim podtl As New t_purchase_order_dtl

    Private cnvss_hdr As New canvass_negotiated.m_Canvass_Hdr
    Private cnvss_dtl1 As New Consolidated_Canvass.m_Canvass_Dtl1
    Private cnvss_dtl2 As New Consolidated_Canvass.m_Canvass_Dtl2
    Private cnvss_PR1 As New Consolidated_Canvass.m_Canvass_Dtl_PR1
    Private cnvss_PR2 As New Consolidated_Canvass.m_Canvass_Dtl_PR2

#Region "property"
    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
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
    Private Property pProjectReference() As DataTable
        Get
            Return CType(Session("pProjectReference"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pProjectReference") = value
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
    Private Property pGoodsPerSupplier(ByVal supplier_id As String) As DataTable
        Get
            Return CType(Session(supplier_id), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session(supplier_id) = value
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
    Private Property pTempSupplier() As DataTable
        Get
            Return CType(Session("pTempSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pTempSupplier") = value
        End Set
    End Property
    Private Property pPurchase_Order_detail() As DataTable
        Get
            Return CType(Session("pPurchase_Order_detail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order_detail") = value
        End Set
    End Property
    Private Property pShopping() As DataTable
        Get
            Return CType(Session("pShopping"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pShopping") = value
        End Set
    End Property
#End Region
#Region "Functions"

    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("Function_Desc", GetType(String))
        dt.Columns.Add("DateApproved", GetType(Date))
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("Function_Desc") = DBNull.Value
            dr("DateApproved") = DBNull.Value
            dr("prhdr_id") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt


    End Function

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_NegotiatedList_v2]", CommandType.Text)
            If pShopping.Rows.Count < 8 Then
                pShopping.Merge(createdatatable1(7 - pShopping.Rows.Count))
            End If
            grdNegotiated.DataSource = pShopping
            grdNegotiated.DataBind()

            grdNegoItems.DataSource = Nothing
            grdNegoItems.DataBind()

            dd_mode_of_procurement.DataSource = objDerived.GetDataTable("SELECT * FROM ams.Negotiated_Mode_of_Procurement", CommandType.Text)
            dd_mode_of_procurement.DataTextField = ("Mode_of_Procurement")
            dd_mode_of_procurement.DataValueField = ("ID")
            dd_mode_of_procurement.DataBind()
            dd_mode_of_procurement.Items.Insert(0, "Select")

            grdSupplier1.DataSource = Nothing
            grdSupplier1.DataBind()

            Session("page") = "canvass"

            txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
            btnRFQ.Enabled = False
        End If
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = pShopping.DefaultView

        If ddSearch.SelectedItem.Value = 1 Then
            myview.RowFilter = "pr_no like '%" & txtSearch.Text & "%'"
        ElseIf ddSearch.SelectedItem.Value = 2 Then
            myview.RowFilter = "rc_name like '%" & txtSearch.Text & "%'"
        ElseIf ddSearch.SelectedItem.Value = 3 Then
            myview.RowFilter = "OBR_No like '%" & txtSearch.Text & "%'"
        End If

        grdNegotiated.DataSource = myview
        grdNegotiated.DataBind()

    End Sub

    Protected Sub grdNegotiated_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdNegotiated.PageIndexChanging
        grdNegotiated.DataSource = pShopping
        grdNegotiated.PageIndex = e.NewPageIndex
        grdNegotiated.DataBind()
    End Sub

    Protected Sub lbPR_No_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Action") = "PRNumber"
    End Sub

    Protected Sub lbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Action") = "Cancel"
    End Sub

    Protected Sub grdNegotiated_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdNegotiated.SelectedIndexChanged
        Session("prhdr_id") = grdNegotiated.SelectedDataKey("prhdr_id")

        If Session("Action") = "PRNumber" Then
            dtItems = objDerived.GetDataTable("SELECT * FROM [dbo].[View_DC_ItemList] WHERE prhdr_id = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            grdNegoItems.DataSource = dtItems
            grdNegoItems.DataBind()

            pSupplier = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List_Nego] '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            grdSupplier1.DataSource = pSupplier
            grdSupplier1.DataBind()

            LoadtxtCostItems()

            Dim cb As CheckBox
            For i As Long = 0 To Me.grdNegoItems.Rows.Count - 1
                cb = CType(Me.grdNegoItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                cb.Checked = True
            Next

            ddSupplier.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
            ddSupplier.DataTextField = ("SuppName")
            ddSupplier.DataValueField = ("Supplier_Id")
            ddSupplier.DataBind()
            ddSupplier.Items.Insert(0, "Select")

            ddSupplier.Enabled = True

        Else
            Try

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Return_Canvass] WHERE prhdr_id = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                If dt.Rows(0)("Hdr_ID") = 0 Then

                    '======= UPDATE AMS.PR_Hdr (mode_of_procurement_id)
                    objDerived.GetRecords("UPDATE AMS.PR_Hdr SET mode_of_procurement_id = 0,isOnBid = 0 WHERE prhdr_id = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                    '======= DELETE RECORDS IN AMS.obr_evaluation_hdr
                    objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_hdr WHERE obr_evaluation_hdr_id = '" & dt.Rows(0)("obr_evaluation_hdr_id") & "'", CommandType.Text)
                    objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id = '" & dt.Rows(0)("obr_evaluation_hdr_id") & "'", CommandType.Text)

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "PR has been successfully returned to OBR Evaluation.")

                    pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_NegotiatedList_v2]", CommandType.Text)
                    If pShopping.Rows.Count < 8 Then
                        pShopping.Merge(createdatatable1(7 - pShopping.Rows.Count))
                    End If
                    grdNegotiated.DataSource = pShopping
                    grdNegotiated.DataBind()

                    grdNegoItems.DataSource = Nothing
                    grdNegoItems.DataBind()

                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Remove all supplier under this transaction before returning into OBR Evaluation.")

                End If

            Catch ex As Exception
            End Try

        End If
    End Sub

    Protected Sub grdNegotiated_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdNegotiated.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdNegotiated, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub txtCost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtCost As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtCost.NamingContainer, GridViewRow)
        If txtCost.Text = "" Then
            txtCost.Text = 0
        End If
        txtCost.Text = FormatNumber(txtCost.Text, 2)

        LoadtxtCostItems()
    End Sub

    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSave.Enabled = True
        btnRFQ.Enabled = True
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        If ddSupplier.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Select a supplier")
            Exit Sub
        ElseIf dd_mode_of_procurement.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Select a mode of procurement")
            Exit Sub
        End If


        Try
            Dim cb As CheckBox

            '=-= SAVE HEADER "AMS.m_Canvass_Hdr"
            With cnvss_hdr
                .Hdr_ID = 0
                .Canvass_Date = txtDate.Text
                .PR_Hdr_ID = grdNegotiated.SelectedDataKey("prhdr_id")
                .withWinner = True
                .isDBM = False
                .MOP_NEGO = dd_mode_of_procurement.SelectedValue
            End With

            Dim Hdr_ID As Long
            Hdr_ID = objDerived.GetValue("SELECT Hdr_ID FROM AMS.m_Canvass_Hdr WHERE PR_Hdr_ID = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "' AND isDBM = 0", CommandType.Text)

            If Hdr_ID = 0 Then
                Session("Hdr_ID") = cnvss_hdr.save()
            Else
                Session("Hdr_ID") = Hdr_ID
            End If

            'objDerived.Execute("UPDATE AMS.m_Canvass_Hdr SET isApproved = 1, DateApproved = '" & txtDate.Text & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)

            '=-= SAVE DETAIL "AMS.m_Canvass_Dtl_PR1" 
            With cnvss_PR1
                .Dtl_ID_PR1 = 0
                .Hdr_ID = Session("Hdr_ID")
                .Supplier_ID = ddSupplier.SelectedItem.Value
                .isWinner = True
            End With

            Dim Dtl_ID_PR1 As Long = cnvss_PR1.save()
            Session("Dtl_ID_PR1") = Dtl_ID_PR1
            objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl_PR1 SET withPO = 0 WHERE Dtl_ID_PR1 = '" & Session("Dtl_ID_PR1") & "'", CommandType.Text)

            '=-= SAVE DETAIL "AMS.m_Canvass_Dtl_PR2" 
            For i As Integer = 0 To grdNegoItems.Rows.Count - 1
                cb = CType(Me.grdNegoItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Checked = True Then
                    Dim CanvassPrice As Decimal = CType(CType(grdNegoItems.Rows(i).FindControl("txtCost"), TextBox).Text, Decimal)
                    Dim CanvassQty As Decimal = CType(CType(grdNegoItems.Rows(i).FindControl("lblqty"), Label).Text, Decimal)

                    With cnvss_PR2
                        .Dtl_ID_PR2 = 0
                        .Dtl_ID_PR1 = Session("Dtl_ID_PR1")
                        .Item_ID = dtItems.Rows(i)("Item_ID")
                        .UnitPrice = CanvassPrice
                        .Quantity = CanvassQty
                        .save()
                    End With
                End If
            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been successfully saved.")


            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_NegotiatedList_v2]", CommandType.Text)
            If pShopping.Rows.Count < 8 Then
                pShopping.Merge(createdatatable1(7 - pShopping.Rows.Count))
            End If
            grdNegotiated.DataSource = pShopping
            grdNegotiated.DataBind()

            dtItems = objDerived.GetDataTable("SELECT * FROM [dbo].[View_DC_ItemList] WHERE prhdr_id = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            grdNegoItems.DataSource = dtItems
            grdNegoItems.DataBind()

            pSupplier = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List_Nego] '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            grdSupplier1.DataSource = pSupplier
            grdSupplier1.DataBind()



        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cbALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdNegoItems.Rows.Count - 1
                item = Me.grdNegoItems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdNegoItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.grdNegoItems.Rows.Count - 1
                item = Me.grdNegoItems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdNegoItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If

        LoadtxtCostItems()
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadtxtCostItems()
    End Sub
    Protected Sub LoadtxtCostItems()
        Dim x As Decimal
        Dim cb As CheckBox

        For i As Integer = 0 To grdNegoItems.Rows.Count - 1
            cb = CType(Me.grdNegoItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If cb.Checked = True Then
                Dim txtCost As TextBox = CType(grdNegoItems.Rows(i).FindControl("txtcost"), TextBox)
                Dim lblqty As Label = CType(grdNegoItems.Rows(i).FindControl("lblqty"), Label)

                Dim Tcost As Decimal = FormatNumber(txtCost.Text * lblqty.Text, 2)

                CType(grdNegoItems.Rows(i).FindControl("lbltotalx"), Label).Text = Tcost
                x = x + (txtCost.Text * lblqty.Text)
            Else
                CType(grdNegoItems.Rows(i).FindControl("lbltotalx"), Label).Text = "0.00"
            End If
        Next

        CType(grdNegoItems.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(x, 2)

    End Sub

    Protected Sub ddSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSearch.SelectedItem.Value = 1 Then

        ElseIf ddSearch.SelectedItem.Value = 2 Then

        ElseIf ddSearch.SelectedItem.Value = 3 Then

        End If
    End Sub

    Protected Sub lnkviewItems_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "view"
    End Sub

    Protected Sub linkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "delete"
    End Sub

    Protected Sub grdSupplier1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Lbtn = "view" Then
            dtItemList = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_ItemList_Nego] '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "', '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            grdItemList.DataSource = dtItemList
            grdItemList.DataBind()

            ModalPopupExtendepopup.Show()

        ElseIf Lbtn = "delete" Then
            Try
                '========== DELETE IN CANVASS DETAIL 2 ==========
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassDBMList] WHERE Supplier_ID = '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "' AND PR_Hdr_ID = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                For i As Integer = 0 To dt.Rows.Count - 1
                    objDerived.GetRecords("DELETE FROM [AMS].[m_Canvass_Dtl_PR1] WHERE Dtl_ID_PR1 = '" & dt.Rows(i)("Dtl_ID_PR1") & "'", CommandType.Text)
                Next

                '========== IF ALL SUPPLIER HAS BEEN REMOVED, DELETE CANVASS HEADER ==========
                Dim dt2 As New DataTable
                dt2 = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassDBMList] WHERE PR_Hdr_ID = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                If dt2.Rows.Count = 0 Then
                    Dim Hdr_ID As Integer
                    Dim dtl_pr2 As Integer
                    Hdr_ID = objDerived.GetValue("SELECT Hdr_ID FROM [AMS].[m_Canvass_Hdr] WHERE isDBM = 0 AND PR_Hdr_ID = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                    dtl_pr2 = objDerived.GetValue("SELECT Dtl_ID_PR1 FROM [AMS].[m_Canvass_Dtl_PR1] WHERE Hdr_ID = '" & Hdr_ID & "'", CommandType.Text)

                    objDerived.GetRecords("DELETE FROM [AMS].[m_Canvass_Dtl_PR2] WHERE Dtl_ID_PR1 = '" & dtl_pr2 & "'", CommandType.Text)
                    objDerived.GetRecords("DELETE FROM [AMS].[m_Canvass_Hdr] WHERE Hdr_ID = '" & Hdr_ID & "'", CommandType.Text)
                End If

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Supplier has been successfully removed from the list.")
            Catch ex As Exception

            End Try
        End If

        dtItems = objDerived.GetDataTable("SELECT * FROM [dbo].[View_DC_ItemList] WHERE prhdr_id = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        grdNegoItems.DataSource = dtItems
        grdNegoItems.DataBind()

        pSupplier = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List_Nego] '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        grdSupplier1.DataSource = pSupplier
        grdSupplier1.DataBind()

        LoadtxtCostItems()

    End Sub

    Protected Sub grdSupplier1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdSupplier1, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdItemList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtItemList = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_ItemList_Nego] '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "', '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        grdItemList.PageIndex = e.NewPageIndex
        grdItemList.DataSource = dtItemList
        grdItemList.DataBind()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "Item_delete"
    End Sub

    Protected Sub grdItemList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdItemList, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdItemList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Lbtn = "Item_delete" Then
            Try
                objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl_PR1 WHERE Supplier_ID = '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "' AND Dtl_ID_PR1 = '" & grdItemList.SelectedDataKey("Dtl_ID_PR1") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Item has been successfully removed.")

                Dim dtItemList As New DataTable
                dtItemList = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_ItemList_Nego] '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "', '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                grdItemList.DataSource = dtItemList
                grdItemList.DataBind()

                dtItems = objDerived.GetDataTable("SELECT * FROM [dbo].[View_DC_ItemList] WHERE prhdr_id = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                grdNegoItems.DataSource = dtItems
                grdNegoItems.DataBind()

                pSupplier = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List_Nego] '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                grdSupplier1.DataSource = pSupplier
                grdSupplier1.DataBind()

                ModalPopupExtendepopup.Show()

            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub btnRFQ_Click(sender As Object, e As EventArgs)
        txt_RFQDate.Text = Date.Today.ToString("MM/dd/yyyy")
        Me.ModalPopup_RFQ.Show()
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)

    End Sub
    Protected Sub btn_RFQDate_Click(sender As Object, e As EventArgs)
        Try
            Session("isRecanvass") = 0
            Session("prhdr_id") = grdNegotiated.SelectedDataKey("prhdr_id")
            objDerived.GetRecords("UPDATE [AMS].[PR_Hdr] SET [RFQ_Date] = '" & txt_RFQDate.Text & "' WHERE [prhdr_id] = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

            Dim url As String = "rpt_canvass_sheet.aspx?"
            Dim fullurl As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenx=0,resizable=0,scrollbars=0,width=900px,height=650px,left=250,top=10');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "open_window", fullurl, True)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To grdItemList.Rows.Count - 1
            Dim Cost As Decimal = CType(grdItemList.Rows(i).FindControl("txtCanvassPrice"), TextBox).Text
            Dim ItemID As Integer = CType(grdItemList.Rows(i).FindControl("lblItem_ID"), Label).Text
            Dim Dtl_ID_PR2 As Integer = objDerived.GetValue("SELECT Dtl_ID_PR2 FROM AMS.m_Canvass_Hdr A INNER JOIN " &
                                                            "AMS.m_Canvass_Dtl_PR1 B ON A.Hdr_ID = B.Hdr_ID INNER JOIN " &
                                                            "AMS.m_Canvass_Dtl_PR2 C ON B.Dtl_ID_PR1 = C.Dtl_ID_PR1 " &
                                                            "WHERE PR_Hdr_ID = '" &
                                                            Session("prhdr_id") &
                                                            "' AND Supplier_ID = '" &
                                                            grdSupplier1.SelectedDataKey("Supplier_ID") &
                                                            "' AND Item_ID = '" &
                                                            ItemID & "'", CommandType.Text)

            objDerived.GetRecords("UPDATE [AMS].[m_Canvass_Dtl_PR2] SET UnitPrice = '" & Cost & "' WHERE Dtl_ID_PR2 = '" & Dtl_ID_PR2 & "'", CommandType.Text)
        Next

        dtItems = objDerived.GetDataTable("SELECT * FROM [dbo].[View_DC_ItemList] WHERE prhdr_id = '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        grdNegoItems.DataSource = dtItems
        grdNegoItems.DataBind()

        pSupplier = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List_Nego] '" & grdNegotiated.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        grdSupplier1.DataSource = pSupplier
        grdSupplier1.DataBind()

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "All canvass unit price has been successfully updated.")

    End Sub

End Class
