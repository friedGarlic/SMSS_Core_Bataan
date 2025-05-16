Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO

Partial Class t_purchase_order_v2
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim hdr As New t_purchase_order_hdr
    Dim dtl As New t_purchase_order_dtl
    Private objBidderDtl As New BidderDtl
    Dim ImageDocument As New ImageDocument
    Dim objStock As New Supplies_Stock

    Dim objOfficeSup As New SupplieINFO
    Dim objMedDtl As New ConsolidatedMedicineSaving.TBMedicine_DTl
    Dim objMedInfo As New ConsolidatedMedicineSaving.TBMedicine_Info
    Dim objNonFood As New ConsolidatedMedicineSaving.TbNonFood
    Dim objFood As New ConsolidatedMedicineSaving.TbFood
    Dim objWater As New ConsolidatedMedicineSaving.TbWater
    Dim objStockLedger As New t_StockLedger


#Region "property"
    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property
    Private Property pPurchase_Order() As DataTable
        Get
            Return CType(Session("pPurchase_Order"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order") = value
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

    'Private pPOTableList As DataTable
    'Public Property POTableList() As DataTable
    '    Get
    '        Return pPOTableList
    '    End Get
    '    Set(ByVal value As DataTable)
    '        pPOTableList = value
    '    End Set
    'End Property

    Private Property POTableList() As DataTable
        Get
            Return CType(Session("POTableList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("POTableList") = value
        End Set
    End Property

#End Region
#Region "Funtion"
    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("project_reference_no")
        dt.Columns.Add("Office_Name", GetType(String))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("SuppName")
        dt.Columns.Add("project_name")
        'dt.Columns.Add("pono")
        'dt.Columns.Add("podate")
        'dt.Columns.Add("poamount")
        'dt.Columns.Add("dvno")
        'dt.Columns.Add("checkno")
        'dt.Columns.Add("amountpaid")
        'dt.Columns.Add("jevno")
        dt.Columns.Add("project_location")
        dt.Columns.Add("Address1")
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("amount", GetType(Decimal))
        'dt.Columns.Add("isVisible", GetType(Boolean))
        'dt.Columns.Add("isShoppingA", GetType(Boolean))
        'dt.Columns.Add("isPublicInfra", GetType(Boolean))
        'dt.Columns.Add("isStraight", GetType(Boolean))
        dt.Columns.Add("mode_of_procurement_id", GetType(Integer))
        dt.Columns.Add("pr_period_key_id", GetType(Long))
        dt.Columns.Add("isGasoline", GetType(Boolean))
        'dt.Columns.Add("isVarious", GetType(Boolean))
        dt.Columns.Add("rc_id", GetType(Long))
        dt.Columns.Add("function_id", GetType(Long))
        'dt.Columns.Add("isReimbursement", GetType(Boolean))
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("isConsolidated", GetType(Boolean))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("ID") = 0
            dr("pre_procurement_hdr_id") = 0
            dr("project_reference_no") = DBNull.Value
            dr("Office_Name") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("project_name") = DBNull.Value
            'dr("pono") = DBNull.Value
            'dr("podate") = DBNull.Value
            'dr("poamount") = DBNull.Value
            'dr("dvno") = DBNull.Value
            'dr("checkno") = DBNull.Value
            'dr("amountpaid") = DBNull.Value
            'dr("jevno") = DBNull.Value
            dr("project_location") = DBNull.Value
            dr("Address1") = DBNull.Value
            dr("Supplier_Id") = 0
            dr("amount") = "0.00"
            'dr("isVisible") = False
            'dr("isShoppingA") = False
            'dr("isPublicInfra") = False
            'dr("isStraight") = False
            dr("mode_of_procurement_id") = 0
            dr("pr_period_key_id") = 0
            dr("isGasoline") = False
            'dr("isVarious") = False
            dr("rc_id") = 0
            dr("function_id") = 0
            'dr("isReimbursement") = False
            dr("prhdr_id") = DBNull.Value
            dr("isConsolidated") = False

            dt.Rows.Add(dr)


        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim direction As String = "DesC"
        Dim sortExpression As String = "OBR_No"
   
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            LoadPO_MainGrid()

            cbReimbursement.Enabled = False

            If Me.Drpsearch.Text = 1 Then
                Me.Lblsearch.Text = "Reference No.:"
                Me.txtsearchRPN.Text = "View ALL"
                Me.MultiView2.SetActiveView(View5)
                Me.txtsearchRPN.ReadOnly = True
            ElseIf Me.Drpsearch.Text = 2 Then
                Me.Lblsearch.Text = "Purchase Request No.:"
                Me.txtsearch.Enabled = True
                Me.txtsearch.Text = ""
                Me.MultiView2.SetActiveView(View4)
            ElseIf Me.Drpsearch.Text = 3 Then
                Me.Lblsearch.Text = "Project Reference No.:"
                Me.txtsearch.Enabled = True
                Me.txtsearchRPN.Text = ""
                Me.MultiView2.SetActiveView(Me.View5)
            End If
       

            btnpreview.Enabled = False
            lblmsg.Text = ""
            btnsave.Enabled = False

            Me.mvGoods.SetActiveView(Me.vwGoods)

            gvGoods.DataSource = CreateDatatable1(4)
            gvGoods.DataBind()

            grdocumentdetails.DataSource = createdatatable2(4)
            grdocumentdetails.DataBind()

        End If
        txtsearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnview.ClientID & "')")
        txtsearchRPN.Attributes.Add("onkeypress", "return fun1(event,'" & btnview.ClientID & "')")
    End Sub
    Protected Sub LoadPO_MainGrid()
        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_List]", CommandType.Text)
        If pPurchase_Order.Rows.Count < 10 Then
            pPurchase_Order.Merge(createdatatable(10 - pPurchase_Order.Rows.Count))
        End If
        gvPurchase_Order.DataSource = pPurchase_Order
        gvPurchase_Order.DataBind()
    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "pr_no"
    End Sub
    Protected Sub gvPurchase_Order_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvPurchase_Order.PageIndexChanging
        'Dim direction As String = "DesC"
        'Dim sortExpression As String = "OBR_No"

        'Dim dv As New DataView(pPurchase_Order)
        'dv.Sort = sortExpression & " DESC"
        'gvPurchase_Order.DataSource = dv
        'gvPurchase_Order.PageIndex = e.NewPageIndex
        'gvPurchase_Order.DataBind()

        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_List]", CommandType.Text)
        If pPurchase_Order.Rows.Count < 10 Then
            pPurchase_Order.Merge(createdatatable(10 - pPurchase_Order.Rows.Count))
        End If
        gvPurchase_Order.PageIndex = e.NewPageIndex
        gvPurchase_Order.DataSource = pPurchase_Order
        gvPurchase_Order.DataBind()
    End Sub
    Protected Sub gvPurchase_Order_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPurchase_Order.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvPurchase_Order, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Private Function replaceapostrophe(ByVal str As String) As String
        Return Replace(Str, "'", "''")
    End Function
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles btnsave.Click
        Dim direction As String = "DesC"
        Dim sortExpression As String = "OBR_No"

        '==== NEWLY ADDED 03222016
        'If gvPurchase_Order.SelectedDataKey("RC_ID") = 8 Or gvPurchase_Order.SelectedDataKey("RC_ID") = 9 Or gvPurchase_Order.SelectedDataKey("RC_ID") = 10 Then
        '    If ddApprovedBy.SelectedItem.Text = "Select" Then
        '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory for approved by.")
        '        Exit Sub
        '    End If

        'Else
        '    Session("ApprovedBy") = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
        'End If
  
        Session("ApprovedBy") = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)

        If ddPterm.SelectedItem.Value = "Select" Or txtDeliveryDate.Text = "" Or txtDPlace.Text = "" Or txtPOnum.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
            Exit Sub
        End If

        Try
            If Me.Session("save") = False Then
                '=-= SAVE AMS.PO_HDR
                If cbReimbursement.Checked = True Then
                    txtPOnum.Text = "none"
                End If

                hdr.PO_No = txtPOnum.Text
                If txtPOnum.Text = "" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up PO Number.")
                    Exit Sub
                End If

                hdr.PO_Date = txtPOdate.Text
                hdr.Supplier_ID = gvPurchase_Order.SelectedDataKey("Supplier_ID")
                hdr.mode_of_procurement_id = gvPurchase_Order.SelectedDataKey("mode_of_procurement_id")
                hdr.DeliveryTerm = ddDT.SelectedItem.Value
                hdr.paymentTerm = ddPterm.SelectedItem.Value
                hdr.DeliveryDate = txtDeliveryDate.Text
                hdr.DeliveryPlace = txtDPlace.Text
                hdr.isDelivered = gvPurchase_Order.SelectedDataKey("isGasoline")
                hdr.pre_procurement_hdr_id = gvPurchase_Order.SelectedDataKey("pre_procurement_hdr_id")
                hdr.isComplete = False
                hdr.withdv = False
                hdr.ContractPrice = gvPurchase_Order.SelectedDataKey("ContractPrice")
                hdr.isStag = False
                hdr.isContinueCutOff = False
                hdr.isStopForCutOff = False
                hdr.isShoppingA = gvPurchase_Order.SelectedDataKey("isCanvass")
                hdr.isPublicInfra = False
                hdr.isStraight = True
                hdr.isApproved_PO_Mayor = True
                hdr.isReceived_PO_Mayor = True
                hdr.DateApproved_PO_Mayor = txtPOdate.Text
                hdr.DateReceived_PO_Mayor = txtPOdate.Text
                hdr.DateDisApprove = "1/1/1900"
                hdr.isGasoline = gvPurchase_Order.SelectedDataKey("isGasoline")
                hdr.isReimbursement = cbReimbursement.Checked
                hdr.RC_ID = gvPurchase_Order.SelectedDataKey("RC_ID")
                hdr.Function_ID = gvPurchase_Order.SelectedDataKey("Function_ID")
                hdr.ApprovedBy = CType(Session("ApprovedBy"), Integer)

                Dim hdr_id As Long = hdr.save()

                Session("POHdr_ID") = hdr_id
                Session("Year") = Year(txtPOdate.Text)

                Dim project As String = replaceapostrophe(gvPurchase_Order.SelectedDataKey("ProjectName"))

                objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = '" & gvPurchase_Order.SelectedDataKey("GA_ID") & "', ProjectName = '" & project & "' WHERE POHdr_ID = '" & hdr_id & "'", CommandType.Text)
                
                If gvPurchase_Order.SelectedDataKey("isGasoline") = False Then
                    '====== PO Details ====== 
                    For i As Integer = 0 To pPurchase_Order_detail.Rows.Count - 1
                        dtl.POHdr_ID = hdr_id
                        dtl.Item_ID = pPurchase_Order_detail.Rows(i)("Item_ID")
                        dtl.cost = CType(gvGoods.Rows(i).FindControl("txtcost"), TextBox).Text
                        dtl.qty = pPurchase_Order_detail.Rows(i)("Quantity")
                        dtl.remarks = CType(gvGoods.Rows(i).FindControl("txtremarks"), TextBox).Text 'vbCrLf & CType(gvGoods.Rows(i).FindControl("txtremarks"), TextBox).Text
                        dtl.save()
                    Next
                End If

                '=-= UPDATE TABLES WITHPO
                If gvPurchase_Order.SelectedDataKey("ID") = 1 Then
                    '=-= CANVASS PER PR
                    objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl_PR1 SET withPO = 1 WHERE Hdr_ID = '" & Session("CanvassID") & "' AND Supplier_ID = '" & Session("Supplier_ID") & "'", CommandType.Text)

                ElseIf gvPurchase_Order.SelectedDataKey("ID") = 2 Then
                    '=-= CANVASS PER ITEM
                    Dim dt As New DataTable
                    For i As Integer = 0 To pPurchase_Order_detail.Rows.Count - 1
                        dt = objDerived.GetDataTable("SELECT * FROM AMS.m_Canvass_Dtl1 WHERE Hdr_ID = '" & Session("CanvassID") & "'", CommandType.Text)
                        For x As Integer = 0 To dt.Rows.Count - 1
                            objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 SET withPO = 1 WHERE Dtl_ID1 = '" & dt.Rows(x)("Dtl_ID1") & "' AND Supplier_ID = '" & Session("Supplier_ID") & "' AND isWinner = 1", CommandType.Text)
                            objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 SET withPO = 0 WHERE Dtl_ID1 = '" & dt.Rows(x)("Dtl_ID1") & "' AND Supplier_ID = '" & Session("Supplier_ID") & "' AND isWinner = 0", CommandType.Text)
                        Next
                    Next

                ElseIf gvPurchase_Order.SelectedDataKey("ID") = 3 Then
                    '=-= PUBLIC BIDDING
                    objDerived.GetRecords("UPDATE AMS.Bid_Information SET withPO = 1 WHERE pre_procurement_hdr_id = '" & Session("CanvassID") & "' AND Supplier_ID = '" & Session("Supplier_ID") & "'", CommandType.Text)
                    objDerived.GetRecords("UPDATE AMS.tb_Infra_Hdr SET withPO = 1 WHERE pre_procurement_hdr_id = '" & Session("CanvassID") & "'", CommandType.Text)

                End If

                btnsave.Enabled = False
                btnpreview.Enabled = True
                Me.Session("save") = True
                Dim data As DataTable

                If gvPurchase_Order.SelectedDataKey("isGasoline") = False Then
                    If gvPurchase_Order.SelectedDataKey("isCanvass") = True Then
                        data = objDerived.GetDataTable("exec ams.sp_purchase_order_detail_pr '" & gvPurchase_Order.SelectedDataKey("prhdr_id") & "','" & gvPurchase_Order.SelectedDataKey("isShoppingA") & "'", CommandType.Text)
                    Else
                        data = objDerived.GetDataTable("exec ams.sp_purchase_order_detail_pr '" & gvPurchase_Order.SelectedDataKey("pre_procurement_hdr_id") & "','" & gvPurchase_Order.SelectedDataKey("isShoppingA") & "'", CommandType.Text)
                        objDerived.GetRecords("Update ams.pre_procurement set withPO =1  where pre_procurement_hdr_id=" & gvPurchase_Order.SelectedDataKey(0) & "", CommandType.Text)
                    End If

                Else '=-= GASOLINE
                    data = objDerived.GetDataTable("exec ams.sp_purchase_order_detail_pr_gasoline '" & gvPurchase_Order.SelectedDataKey(0) & "','" & gvPurchase_Order.SelectedDataKey(11) & "','" & gvPurchase_Order.SelectedDataKey(13) & "'", CommandType.Text)
                End If

                For i As Integer = 0 To data.Rows.Count - 1
                    '==== not applicable since "1 PR - Many PO" =====
                    'If cbReimbursement.Checked = True Then
                    '    objDerived.GetRecords("Update LnkdSrvrBOSS.GEOBOS.BOS.t_obr_hdr set Supplier_ID='" & gvPurchase_Order.SelectedDataKey(3) & "' where prhdr_id='" & data.Rows(i)("prhdr_id") & "'", CommandType.Text)
                    'Else
                    '    objDerived.GetRecords("Update LnkdSrvrBOSS.GEOBOS.BOS.t_obr_hdr set Supplier_ID='" & gvPurchase_Order.SelectedDataKey(3) & "',payee='" & objDerived.replaceapostrophe(gvPurchase_Order.SelectedDataKey(1)) & "', address='" & objDerived.replaceapostrophe(gvPurchase_Order.SelectedDataKey(2)) & "' where prhdr_id='" & data.Rows(i)("prhdr_id") & "'", CommandType.Text)
                    'End If
                    'objDerived.GetRecords("Update ams.pr_hdr set POHdr_ID='" & Session("POHdr_ID") & "' where prhdr_id='" & data.Rows(i)("prhdr_id") & "'", CommandType.Text)
                    '================================================

                    If gvPurchase_Order.SelectedDataKey(12) = False Then
                        objDerived.GetRecords("Update ams.obr_adjustment_hdr set POHdr_ID='" & hdr_id & "',isforAdjustment=1 where prhdr_id='" & data.Rows(i)("prhdr_id") & "'", CommandType.Text)
                    Else
                        objDerived.GetRecords("Update ams.obr_adjustment_hdr set POHdr_ID='" & hdr_id & "',isforAdjustment=0 where prhdr_id='" & data.Rows(i)("prhdr_id") & "'", CommandType.Text)
                    End If

                    Dim adjustment As DataTable
                    adjustment = objDerived.GetDataTable("select obr_adjustment_dtl_id,new_amount from ams.view_obr_adjustment_master_list where prhdr_id='" & data.Rows(i)("prhdr_id") & "'", CommandType.Text)
                    For dtlID As Integer = 0 To adjustment.Rows.Count - 1
                        objDerived.GetRecords("Update ams.obr_adjustment_dtl set new_amount='" & adjustment.Rows(dtlID)("new_amount") & "' where obr_adjustment_dtl_id='" & adjustment.Rows(dtlID)("obr_adjustment_dtl_id") & "'", CommandType.Text)
                    Next
                Next

                '=-= CASE WHEN PURCHASED @ DBM > NO AIR > DIRECT TO STOCK / RIS
                '=-= DISABLE FOR THE MEANTIME DUE TO THE SUGGESTION OF RGC DURING WEBCON 10012015
                Session("Supplier_Id") = gvPurchase_Order.SelectedDataKey("Supplier_ID")
                If gvPurchase_Order.SelectedDataKey("Supplier_ID") = 999999 Then '117
                    For i As Integer = 0 To pPurchase_Order_detail.Rows.Count - 1
                        Session("Item_ID") = pPurchase_Order_detail.Rows(i)("Item_ID")
                        Session("AIRDtl_ID") = 0

                        Dim Item_Desc As String = objDerived.GetValue("SELECT Item_Desc FROM dbo.m_item WHERE Item_ID = '" & pPurchase_Order_detail.Rows(i)("Item_ID") & "'", CommandType.Text)

                        '=-= Stock Save
                        With objStock
                            .StockDate = txtPOdate.Text
                            .Item_ID = pPurchase_Order_detail.Rows(i)("Item_ID")
                            .Qty = pPurchase_Order_detail.Rows(i)("Quantity")
                            .Balance = pPurchase_Order_detail.Rows(i)("Quantity")
                            '.Location = txtLocation.Text
                            .Expiration_Date = "1/1/1900"
                            .Cost = CType(gvGoods.Rows(i).FindControl("txtcost"), TextBox).Text
                            .Issuance = 0
                            .RC_ID = gvPurchase_Order.SelectedDataKey("RC_ID")
                            .Function_ID = gvPurchase_Order.SelectedDataKey("Function_ID")
                            .Project_ID = 0
                            .Program_id = 0
                            .F_ID = 1
                            .AIRDtl_ID = 0
                            .GA_ID = pPurchase_Order_detail.Rows(i)("GA_ID")
                            .save()
                        End With

                        Dim StockID As Long
                        StockID = objStock.GetValue("Select max(StockID) from AMS.Stock ", CommandType.Text)

                        With objStockLedger
                            '.StockLedger_ID = StockLedger_ID
                            .StockID = StockID
                            .Trans_Type = "Purchased at DBM"
                            .Ref = ""
                            .AccountablePerson = objDerived.GetValue("SELECT ContactP FROM  dbo.Supplier where Supplier_Id ='" & Session("Supplier_Id") & "' ", CommandType.Text)
                            .Department = gvPurchase_Order.SelectedDataKey("RC_ID")
                            .Position = ""
                            .AcceptedBy = ""
                            .InspectedBy = ""
                            .CreditQty = "0"
                            .CreditUnit = "-"
                            .CreditCost = "0.00"
                            .dDate = txtPOdate.Text
                            .Item_ID = pPurchase_Order_detail.Rows(i)("Item_ID")
                            .DebitQty = pPurchase_Order_detail.Rows(i)("Quantity")
                            .DebitCost = gvPurchase_Order.SelectedDataKey("ContractPrice")
                            .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & pPurchase_Order_detail.Rows(i)("Item_ID") & "'", CommandType.Text)
                            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & pPurchase_Order_detail.Rows(i)("Item_ID") & "'", CommandType.Text)
                            .BalanceQty = 0
                            .BalanceCost = 0
                            .save()
                        End With

                        '------------------------------------------------------
                        '=-= Supplies Save
                        If pPurchase_Order_detail.Rows(i)("GA_ID") = 788 Then
                            'Office Supplies
                            With objOfficeSup
                                '.SuppliesId = SuppliesId
                                .StockID = StockID
                                .AIRDtl_ID = Session("AIRDtl_ID")
                                .ItemId = Session("Item_ID")
                                .Description = Item_Desc
                                .BrandName = ""
                                .SupplierId = Session("Supplier_Id")
                                .Size = ""
                                .Color = ""
                                .Category = ""
                                .Length = ""
                                .Width = ""
                                .Height = ""
                                .Weight = ""
                                .DepreciatedValue = 0
                                .DepreciatedRate = 0
                                .Status = "Accepted"
                                .save()
                            End With

                        ElseIf pPurchase_Order_detail.Rows(i)("GA_ID") = 792 Or pPurchase_Order_detail.Rows(i)("GA_ID") = 793 Then
                            'Medicine and Medical Supplies
                            With objMedInfo
                                .StockId = StockID
                                .AIRDtl_ID = Session("AIRDtl_ID")
                                .Item_ID = Session("Item_ID")
                                .Description = Item_Desc
                                .DrugName = Item_Desc
                                .BrandName = ""
                                .SupplierId = Session("Supplier_Id")
                                .Dose = ""
                                .Location = ""
                                .Status = "Accepted"
                                .DeliveryDate = txtDeliveryDate.Text
                                .Depreciatedrate = 0
                                .Depreciatedvalue = 0
                                .save()
                            End With

                            Dim MedicineId As Long
                            MedicineId = objMedInfo.GetValue("Select max(MedicineId) from AMS.TBMedicine_Info ", CommandType.Text)

                            With objMedDtl
                                '.MedicineDtl = MedicineDtl
                                .MedicineID = MedicineId
                                .StockId = StockID
                                .Item_ID = Session("Item_ID")
                                .Form = ""
                                .OTCRx = ""
                                .Mftgdate = DateTime.Today.AddDays(-30).ToShortDateString()
                                .Alert = "01/01/2000"
                                .Batch = ""
                                .Lot = ""
                                .ActualPrice = 0.0
                                .EpiryDate = DateTime.Today.AddDays(730).ToShortDateString()
                                .save()
                            End With

                        ElseIf pPurchase_Order_detail.Rows(i)("GA_ID") = 791 Then
                            'FOOD
                            With objFood
                                '.Food_ID = Food_ID
                                .StockId = StockID
                                .AIRDtl_ID = Session("AIRDtl_ID")
                                .Item_ID = Session("Item_ID")
                                .ActualPrice = CType(gvGoods.Rows(i).FindControl("txtcost"), TextBox).Text
                                .ItemDesc = Item_Desc
                                .BrandName = ""
                                .Supplier_Id = Session("Supplier_Id")
                                .Form = ""
                                .OTCRx = ""
                                .Batch = ""
                                .Lot = ""
                                .Storage = ""
                                .Status = "Accepted"
                                .DeliveryDate = txtDeliveryDate.Text
                                .Mftgdate = "01/01/1900"
                                .EpiryDate = "01/01/1900"
                                .Alert = "01/01/1900"
                                .Depreciationrate = 0.0
                                .Depreciationvalue = 0.0
                                .save()
                            End With

                        ElseIf pPurchase_Order_detail.Rows(i)("GA_ID") = 799 Then
                            'Water
                            With objWater
                                '.Water_ID = Water_ID
                                .StockId = StockID
                                .AIRDtl_ID = Session("AIRDtl_ID")
                                .Item_ID = Session("Item_ID")
                                .ActualPrice = CType(gvGoods.Rows(i).FindControl("txtcost"), TextBox).Text
                                .ItemDesc = Item_Desc
                                .BrandName = ""
                                .Supplier_Id = Session("Supplier_Id")
                                .Form = ""
                                .OTCRx = ""
                                .Batch = ""
                                .Lot = ""
                                .Storage = ""
                                .Status = "Accepted"
                                .DeliveryDate = txtDeliveryDate.Text
                                .Mftgdate = "01/01/1900"
                                .EpiryDate = "01/01/1900"
                                .Alert = "01/01/1900"
                                .Depreciationrate = 0.0
                                .Depreciationvalue = 0.0
                                .save()
                            End With

                        Else 'NonFood & Others
                            With objNonFood
                                '.NonFood_ID = NonFood_ID
                                .StockId = StockID
                                .AIRDtl_ID = Session("AIRDtl_ID")
                                .Item_ID = Session("Item_ID")
                                .ActualPrice = CType(gvGoods.Rows(i).FindControl("txtcost"), TextBox).Text
                                .ItemDesc = Item_Desc
                                .BrandName = ""
                                .Supplier_Id = Session("Supplier_Id")
                                .Form = ""
                                .OTCRx = ""
                                .Batch = ""
                                .Lot = ""
                                .Storage = ""
                                .Status = "Accepted"
                                .DeliveryDate = txtDeliveryDate.Text
                                .Mftgdate = "01/01/1900"
                                .EpiryDate = "01/01/1900"
                                .Alert = "01/01/1900"
                                .Depreciationrate = 0.0
                                .Depreciationvalue = 0.0
                                .save()
                            End With
                        End If
                    Next
                End If

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.ToString)
        End Try

        LoadPO_MainGrid()

        btnsave.Enabled = False
        btnReturn.Enabled = False

        txtSupplier.Text = ""
        txtaddress.Text = ""
        txtDPlace.Text = ""
        txtDeliveryDate.Text = ""
        txtAmount.Text = ""
        txtPOnum.Text = ""
        txtPOdate.Text = ""

        gvGoods.DataSource = CreateDatatable1(4)
        gvGoods.DataBind()

        grdocumentdetails.DataSource = createdatatable2(4)
        grdocumentdetails.DataBind()
        imgPOAttachDoc.ImageUrl = "~/images/Blankimage.jpg"
    End Sub

    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Session("Supplier_ID") = 117 Then
            Session("Page") = "PO"
            Me.Page.Response.Redirect("~/Procurement/rpt_ARP.aspx")
        Else
            Session("Page") = "PO"
            Me.Page.Response.Redirect("~/Procurement/rpt_purchase_order.aspx")
        End If
 
    End Sub

    Protected Sub txtcost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtCost As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtCost.NamingContainer, GridViewRow)
            If txtCost.Text = "" Then
                txtCost.Text = "0.00"
            End If
            txtCost.Text = FormatNumber(txtCost.Text, 2)

            CType(gvGoods.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(CType(CType(Me.gvGoods.Rows(gvr.RowIndex).FindControl("lblqty"), Label).Text, Integer) * CType(txtCost.Text, Decimal), 2)
            pPurchase_Order_detail.Rows(gvr.RowIndex)("total") = CType(gvGoods.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text
            CType(gvGoods.FooterRow.FindControl("lbltotal"), Label).Text = FormatNumber(pPurchase_Order_detail.Compute("sum(total)", ""), 2)

            If CType(gvGoods.FooterRow.FindControl("lbltotal"), Label).Text > CType(gvPurchase_Order.SelectedDataKey(4), Decimal) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Amount have exceed " & FormatNumber(gvPurchase_Order.SelectedDataKey(4), 2) & ".")

                CType(gvGoods.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(CType(pPurchase_Order_detail.Rows(gvr.RowIndex)("cost"), Decimal) * CType(pPurchase_Order_detail.Rows(gvr.RowIndex)("qty"), Integer), 2)
                pPurchase_Order_detail.Rows(gvr.RowIndex)("total") = CType(gvGoods.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text
                CType(gvGoods.FooterRow.FindControl("lbltotal"), Label).Text = FormatNumber(pPurchase_Order_detail.Compute("sum(total)", ""), 2)
                txtCost.Text = FormatNumber(pPurchase_Order_detail.Rows(gvr.RowIndex)("cost"), 2)
                ScriptManager.GetCurrent(Me.Page).SetFocus(txtCost)
            Else
                ' pPurchase_Order_detail.Rows(gvr.RowIndex)("amount") = txtCost.Text
                If txtAmount.Text < CType(gvGoods.FooterRow.FindControl("lbltotal"), Label).Text Then
                    lblmsg.Text = "Please adjust the price of the goods."
                    btnsave.Enabled = False
                    'btnsave.Enabled = True
                Else
                    lblmsg.Text = ""
                    btnsave.Enabled = True
                End If
                pPurchase_Order_detail.Rows(gvr.RowIndex)("cost") = FormatNumber(CType(txtCost.Text, Decimal), 2)

                ScriptManager.GetCurrent(Me.Page).SetFocus(CType(gvGoods.Rows(gvr.RowIndex + 1).FindControl("txtcost"), TextBox))
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Protected Sub txtremarks_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim txtremarkst As TextBox = TryCast(sender, TextBox)
    '        Dim gvr As GridViewRow = TryCast(txtremarkst.NamingContainer, GridViewRow)
    '        ScriptManager.GetCurrent(Me.Page).SetFocus(CType(gvGoods.Rows(gvr.RowIndex + 1).FindControl("txtremarks"), TextBox))

    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Function CheckIfTitleExists(ByVal strval As String) As String
        Dim title As String = ViewState("title")
        If title = strval Then
            Me.Session("1strow") = False
            Return String.Empty
        Else
            title = strval
            ViewState("title") = title
            Me.Session("1strow") = True
            If Me.Session("gvProject1stLoad") = True Then
                Return "<b>" & title & "</b><br>"
                ' Me.Session("gvProject1stLoad") = False
            Else
                Return "<br><b>" & title & "</b><br>"
            End If

        End If
    End Function
    Protected Function CheckIfTitleExists2(ByVal strval As String) As String

        If Me.Session("1strow") = True Then
            If Me.Session("gvProject1stLoad") = True Then
                Me.Session("gvProject1stLoad") = False
                Return "<b></b><br>"
            Else
                Return "<br><b></b><br>"
            End If
        Else
            Return String.Empty
        End If
    End Function


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        If Me.Drpsearch.Text = 1 Then
          
            pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_List]", CommandType.Text)
            If pPurchase_Order.Rows.Count < 10 Then
                pPurchase_Order.Merge(createdatatable(10 - pPurchase_Order.Rows.Count))
            End If
            gvPurchase_Order.DataSource = pPurchase_Order
            gvPurchase_Order.DataBind()

        ElseIf Me.Drpsearch.Text = 2 Then
            If Me.txtsearch.Text = "" Then
                msg.UserMsgBox("Please input Purchase Request No.", Me, False)
            Else

                pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_List_Search] '" & txtsearch.Text & "'", CommandType.Text)
                If pPurchase_Order.Rows.Count < 10 Then
                    pPurchase_Order.Merge(createdatatable(10 - pPurchase_Order.Rows.Count))
                End If
                gvPurchase_Order.DataSource = pPurchase_Order
                gvPurchase_Order.DataBind()


            End If

        ElseIf Me.Drpsearch.Text = 3 Then
            If Me.txtsearchRPN.Text = "" Then
                msg.UserMsgBox("Please input Project Reference No.", Me, False)

            Else
                pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_List_Search] '" & txtsearchRPN.Text & "'", CommandType.Text)
                If pPurchase_Order.Rows.Count < 10 Then
                    pPurchase_Order.Merge(createdatatable(10 - pPurchase_Order.Rows.Count))
                End If
                gvPurchase_Order.DataSource = pPurchase_Order
                gvPurchase_Order.DataBind()

            End If
        End If

        Me.gvPurchase_Order.SelectedIndex = -1

        txtSupplier.Text = ""
        txtaddress.Text = ""
        txtDeliveryDate.Text = ""
        txtAmount.Text = ""
        ddDT.Enabled = False
        ddPterm.Enabled = False
        btnsave.Enabled = False
        Me.btnpreview.Enabled = False
        Me.txtDPlace.Text = ""

        'pPurchase_Order_detail = Nothing
        'pPurchase_Order_detail.Merge(CreateDatatable1(4))
        'gvGoods.DataSource = pPurchase_Order_detail
        'gvGoods.DataBind()

        'btnpreview.Enabled = False
        'lblmsg.Text = ""
        'btnsave.Enabled = False
        'Me.mvPurchaseOrder.SetActiveView(Me.vwCreatePO)
        'Me.MultiView1.SetActiveView(Me.View1)

        'Dim dv As New DataView(pPurchase_Order)
        'dv.Sort = sortExpression & " DESC"
        'gvPurchase_Order.DataSource = dv
        'gvPurchase_Order.DataBind()

        'gvGoods.DataSource = CreateDatatable1(4)
        'gvGoods.DataBind()
        'grdocumentdetails.DataSource = createdatatable2(4)
        'grdocumentdetails.DataBind()

    End Sub

    Protected Sub Drpsearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Drpsearch.SelectedIndexChanged
        If Me.Drpsearch.Text = 1 Then
            Me.Lblsearch.Text = "Reference No.:"

            Me.txtsearchRPN.Text = "View ALL"

            pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_List]", CommandType.Text)
            If pPurchase_Order.Rows.Count < 10 Then
                pPurchase_Order.Merge(createdatatable(10 - pPurchase_Order.Rows.Count))
            End If
            gvPurchase_Order.DataSource = pPurchase_Order
            gvPurchase_Order.DataBind()

            Me.MultiView2.SetActiveView(View5)

        ElseIf Me.Drpsearch.Text = 2 Then
            Me.Lblsearch.Text = "Purchase Request No.:"
            Me.txtsearch.Enabled = True
            Me.txtsearch.Text = ""

            Me.MultiView2.SetActiveView(View4)

        ElseIf Me.Drpsearch.Text = 3 Then
            Me.Lblsearch.Text = "Project Reference No.:"
            Me.txtsearch.Enabled = True
            Me.txtsearchRPN.Text = ""
            Me.MultiView2.SetActiveView(View5)
            Me.txtsearchRPN.ReadOnly = False

        End If
    End Sub

    Protected Sub cbReimbursement_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If cbReimbursement.Checked = False Then
            txtPOnum.Text = objDerived.GetValue("select AMS.func_GeneratePO('" & txtPOdate.Text & "')", CommandType.Text)
        Else
            txtPOnum.Text = "none"
        End If
    End Sub

    Protected Sub txtPOdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If gvPurchase_Order.SelectedDataKey(7) = False Then
        '    txtPOnum.Text = objDerived.GetValue("select AMS.func_GeneratePO('" & txtPOdate.Text & "')", CommandType.Text)
        '    cbReimbursement.Checked = False
        'End If
        'If gvPurchase_Order.SelectedDataKey(16) = True Then
        '    txtPOnum.Text = "none"
        '    cbReimbursement.Checked = True
        'End If

        ' txtPOnum.Text = objDerived.GetValue("select AMS.func_GeneratePO('" & txtPOdate.Text & "')", CommandType.Text)
    End Sub
    Protected Sub gvGoods_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.SelectedIndex = 0 Then
            pPurchase_Order = objDerived.GetDataTable("select * from dbo.View_PO_List order by pr_date desc", CommandType.Text)
            If pPurchase_Order.Rows.Count < 8 Then
                pPurchase_Order.Merge(createdatatable(7 - pPurchase_Order.Rows.Count))
            End If
            gvPurchase_Order.DataSource = pPurchase_Order
            gvPurchase_Order.DataBind()


        Else

        End If
    End Sub

    Protected Sub btnAddlist_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim filePath As String = hdfbuilding.Value
        Dim filename As String = Path.GetFileName(filePath)
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
        br.Close()
        fs.Close()


        If Me.hdfbuilding.Value <> "" Then
            ImageDocument.IdentityNo = Session("prhdr_id")
            ImageDocument.Imagefile = bytes
            ImageDocument.DocumentName = txtDocumentname.Text
            ImageDocument.DocumentNo = txtdocumentno.Text
            ImageDocument.ValidatedBy = txtvalidatedby.Text

            If txtdatevalidated.Text = "" Then
                ImageDocument.DateValidated = Date.Today.ToString("MM/dd/yyyy")
            Else
                ImageDocument.DateValidated = txtdatevalidated.Text
            End If
            ImageDocument.Remarks = txtdocremarks.Text
            ImageDocument.TableName = "PO"
            Dim Id As Long = ImageDocument.SaveImage()
            imgPOAttachDoc.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & Id
        End If
        '' Clear TextBox
        txtDocumentname.Text = ""
        txtdocumentno.Text = ""
        txtdatevalidated.Text = ""
        txtdocremarks.Text = ""
        txtvalidatedby.Text = ""
        '' Clear TextBox

        Dim AttachDocument As New DataTable
        AttachDocument = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = " & Session("prhdr_id") & " and TableName = 'PO'", CommandType.Text)
        Dim rows As New Integer
        rows = AttachDocument.Rows.Count
        AttachDocument.Merge(createdatatable9(4 - rows))
        grdocumentdetails.DataSource = AttachDocument
        grdocumentdetails.DataBind()
        grdocumentdetails.SelectedIndex = 0

    End Sub
    Protected Sub grdocumentdetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadAttachDocu()
    End Sub
    Protected Sub LoadAttachDocu()
        Try
            Dim id As New Integer
            id = grdocumentdetails.SelectedDataKey(1).ToString
            imgPOAttachDoc.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & id
        Catch ex As Exception
            imgPOAttachDoc.ImageUrl = "~/images/Blankimage.jpg"
        End Try
    End Sub
    Protected Sub grdocumentdetails_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdocumentdetails.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdocumentdetails, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub


    Protected Sub gvPurchase_Order_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvPurchase_Order.SelectedIndexChanged
        Session("prhdr_id") = gvPurchase_Order.SelectedDataKey("prhdr_id")
        Session("Supplier_ID") = gvPurchase_Order.SelectedDataKey("Supplier_ID")
        Session("CanvassID") = gvPurchase_Order.SelectedDataKey("CanvassID")
        Session("isBidding") = gvPurchase_Order.SelectedDataKey("isBidding")
        Session("mode_of_procurement_id") = gvPurchase_Order.SelectedDataKey("mode_of_procurement_id")

        'Dim strSelectedID
        'strSelectedID = gvPurchase_Order.SelectedDataKey(1)
        'imgPOAttachDoc.ImageUrl = "~/images/Blankimage.jpg"

        '======== NEW: 03222016 =========
        'ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(full_name) AS full_name, empid FROM HRMS.view_signatory WHERE deptid IN (1,8) AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
        'ddApprovedBy.DataTextField = ("full_name")
        'ddApprovedBy.DataValueField = ("empid")
        'ddApprovedBy.DataBind()
        'ddApprovedBy.Items.Insert(0, "Select")

        'If gvPurchase_Order.SelectedDataKey("RC_ID") = 8 Or gvPurchase_Order.SelectedDataKey("RC_ID") = 9 Or gvPurchase_Order.SelectedDataKey("RC_ID") = 10 Then
        '    tb_approvedby.Visible = True
        'Else
        '    tb_approvedby.Visible = False
        'End If
        '============= END ==============


        Try
            Session("save") = False

            txtSupplier.Text = gvPurchase_Order.SelectedDataKey("SuppName")
            txtaddress.Text = gvPurchase_Order.SelectedDataKey("Address1")
            txtAmount.Text = FormatNumber(gvPurchase_Order.SelectedDataKey("ContractPrice"), 2)


            ddDT.Enabled = True
            ddPterm.Enabled = True
            CalendarExtender1.Enabled = True
            CalendarExtender2.Enabled = True

            btnpreview.Enabled = False
            btnsave.Enabled = True
            txtDeliveryDate.ReadOnly = False


            Session("isGasoline") = gvPurchase_Order.SelectedDataKey("isGasoline")

            If gvPurchase_Order.SelectedDataKey("isGasoline") = True Then
                Session("1strow") = False
                Session("gvProject1stLoad") = True
                Me.mvGoods.SetActiveView(Me.vwGasoline)

                pPurchase_Order_detail = objDerived.GetDataTable("exec [AMS].[sp_purchase_order_detail_gasoline_v2] '" & gvPurchase_Order.SelectedDataKey("CanvassID") & "'", CommandType.Text)
                gvProject.DataSource = pPurchase_Order_detail
                gvProject.DataBind()

                gvProject.FooterRow.Cells(3).Text = FormatNumber(pPurchase_Order_detail.Compute("sum(total)", ""), 2)
                gvProject.FooterRow.Cells(2).Text = "TOTAL :"

                btnsave.Enabled = True
                Session("pr_period_key_id") = gvPurchase_Order.SelectedDataKey("pr_period_key_id")
                Session("rc_id") = gvPurchase_Order.SelectedDataKey("rc_id")
                Session("function_id") = gvPurchase_Order.SelectedDataKey("function_id")
                Session("isVarious") = True
                txtPOdate.Text = Date.Today.ToString("MM/dd/yyyy")

            Else
                Me.mvGoods.SetActiveView(Me.vwGoods)
                txtPOdate.Text = Date.Today.ToString("MM/dd/yyyy")


                If gvPurchase_Order.SelectedDataKey("isBidding") = False Then
                    txtPOnum.Text = gvPurchase_Order.SelectedDataKey("pr_no")
                    pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_Details] '" & Session("prhdr_id") & "','" & gvPurchase_Order.SelectedDataKey("Supplier_ID") & "'", CommandType.Text)
                    gvGoods.DataSource = pPurchase_Order_detail
                    gvGoods.DataBind()

                    CType(gvGoods.FooterRow.FindControl("lbltotal"), Label).Text = FormatNumber(pPurchase_Order_detail.Compute("sum(total)", ""), 2)

                    If CDec(txtAmount.Text) < CDec(CType(gvGoods.FooterRow.FindControl("lbltotal"), Label).Text) Then
                        lblmsg.Text = "Please adjust the price of the goods."
                        btnsave.Enabled = False
                    Else
                        lblmsg.Text = ""
                        btnsave.Enabled = True
                    End If

                ElseIf gvPurchase_Order.SelectedDataKey("isBidding") = True Then
                    If gvPurchase_Order.SelectedDataKey("isConsolidated") = True Then
                        txtPOnum.Text = gvPurchase_Order.SelectedDataKey("Consolidated_PRNumber")
                        txtPOnum.ReadOnly = True
                    Else
                        txtPOnum.Text = gvPurchase_Order.SelectedDataKey("pr_no")
                        txtPOnum.ReadOnly = True
                    End If

                    pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_Details_Bidding] '" & Session("CanvassID") & "','" & gvPurchase_Order.SelectedDataKey("Supplier_ID") & "'", CommandType.Text)
                    gvGoods.DataSource = pPurchase_Order_detail
                    gvGoods.DataBind()

                    CType(gvGoods.FooterRow.FindControl("lbltotal"), Label).Text = FormatNumber(pPurchase_Order_detail.Compute("sum(total)", ""), 2)

                End If
            End If

            'cbReimbursement.Enabled = True
            'If gvPurchase_Order.SelectedDataKey(7) = False Then
            '    cbReimbursement.Checked = False
            'End If
            'If gvPurchase_Order.SelectedDataKey(16) = True Then
            '    txtPOnum.Text = "none"
            '    cbReimbursement.Checked = True
            'End If

            btnReturn.Enabled = True
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.ToString)
        End Try


        'Dim AttachDocument As New DataTable
        'AttachDocument = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = '" & Session("prhdr_id") & "' and TableName = 'PO' ", CommandType.Text)
        'Dim rows As New Integer
        'rows = AttachDocument.Rows.Count
        'AttachDocument.Merge(createdatatable9(4 - rows))
        'grdocumentdetails.DataSource = AttachDocument
        'grdocumentdetails.DataBind()
        'grdocumentdetails.SelectedIndex = 0


    End Sub
    Protected Sub gvGoods_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pPurchase_Order_detail = objDerived.GetDataTable("exec ams.sp_purchase_order_detail " & gvPurchase_Order.SelectedDataKey(0) & "," & gvPurchase_Order.SelectedDataKey(6) & "", CommandType.Text)
        'pPurchase_Order_detail.Merge(CreateDatatable1(4))
        If pPurchase_Order_detail.Rows.Count < 4 Then
            pPurchase_Order_detail.Merge(CreateDatatable1(3 - pPurchase_Order_detail.Rows.Count))
        End If
        gvGoods.PageIndex = e.NewPageIndex
        gvGoods.DataSource = pPurchase_Order_detail
        gvGoods.DataBind()
    End Sub

    Protected Sub btnAddlist_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Check if the Account is MOOE or Capital outlay
        Dim filePath As String = hdfbuilding.Value
        Dim filename As String = Path.GetFileName(filePath)
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
        br.Close()
        fs.Close()

        If Me.hdfbuilding.Value <> "" Then
            ImageDocument.IdentityNo = Session("prhdr_id")
            ImageDocument.Imagefile = bytes
            ImageDocument.DocumentName = txtDocumentname.Text
            ImageDocument.DocumentNo = txtdocumentno.Text
            ImageDocument.ValidatedBy = txtvalidatedby.Text

            If txtdatevalidated.Text = "" Then
                ImageDocument.DateValidated = Date.Today.ToString("MM/dd/yyyy")
            Else
                ImageDocument.DateValidated = txtdatevalidated.Text
            End If
            ImageDocument.Remarks = txtdocremarks.Text
            ImageDocument.TableName = "PO"
            Dim Id As Long = ImageDocument.SaveImage()
            imgPOAttachDoc.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & Id
            ' imgbuilding.ImageUrl = "~/Handler/ShowImage.ashx?id=" & ID

        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Hellow Wold")
        End If

        '' Clear TextBox
        txtDocumentname.Text = ""
        txtdocumentno.Text = ""
        txtvalidatedby.Text = ""
        txtdatevalidated.Text = ""
        txtdocremarks.Text = ""
        '' Clear TextBox
        Dim AttachDocument As New DataTable
        AttachDocument = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = " & Session("prhdr_id") & "and TableName='PO'", CommandType.Text)
        Dim rows As New Integer
        rows = AttachDocument.Rows.Count
        AttachDocument.Merge(createdatatable9(4 - rows))
        Me.grdocumentdetails.DataSource = AttachDocument
        grdocumentdetails.DataBind()
        grdocumentdetails.SelectedIndex = 0



    End Sub


    Protected Sub btnBuildingBrowse_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Public Function CreateDatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Quantity", GetType(Integer))
        dt.Columns.Add("UnitPrice", GetType(Decimal))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        dt.Columns.Add("GA_ID", GetType(Long))
        dt.Columns.Add("BGA_ID", GetType(Long))
        dt.Columns.Add("Total", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_ID") = DBNull.Value
            dr("Quantity") = DBNull.Value
            dr("Quantity") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("remarks") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("BGA_ID") = DBNull.Value
            dr("Total") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("DocuId", GetType(Long))
        dt.Columns.Add("IdentityNo", GetType(Long))
        dt.Columns.Add("documentname", GetType(String))
        dt.Columns.Add("documentno", GetType(String))
        dt.Columns.Add("validatedby", GetType(String))
        dt.Columns.Add("datevalidated", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow

            dr("DocuId") = DBNull.Value
            dr("IdentityNo") = DBNull.Value
            dr("documentname") = DBNull.Value
            dr("documentno") = DBNull.Value
            dr("validatedby") = DBNull.Value
            dr("datevalidated") = DBNull.Value
            dr("remarks") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt


    End Function
    Public Function createdatatable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("typeofservice", GetType(String))
        dt.Columns.Add("plateno", GetType(String))
        dt.Columns.Add("datepurchased", GetType(String))
        dt.Columns.Add("acquisitioncost", GetType(Decimal))
        dt.Columns.Add("marketvalue", GetType(Decimal))
        dt.Columns.Add("condition", GetType(String))
        dt.Columns.Add("location", GetType(String))
        dt.Columns.Add("status", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("typeofservice") = DBNull.Value
            dr("plateno") = DBNull.Value
            dr("datepurchased") = DBNull.Value
            dr("acquisitioncost") = DBNull.Value
            dr("marketvalue") = DBNull.Value
            dr("condition") = DBNull.Value
            dr("location") = DBNull.Value
            dr("status") = DBNull.Value

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function createdatatable4(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Type", GetType(String))
        dt.Columns.Add("serialno", GetType(String))
        dt.Columns.Add("datepurchased", GetType(Date))
        dt.Columns.Add("acquisitioncost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Integer))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("status", GetType(String))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("PODtl_ID", GetType(Long))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Type") = DBNull.Value
            dr("serialno") = DBNull.Value
            dr("datepurchased") = DBNull.Value
            dr("acquisitioncost") = DBNull.Value
            dr("MarketValue") = DBNull.Value
            dr("Condition") = DBNull.Value
            dr("Location") = DBNull.Value
            dr("status") = DBNull.Value
            dr("Property_ID") = DBNull.Value
            dr("PropertyDetai_ID") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("PODtl_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function createdatatable9(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("DocuId", GetType(Long))
        dt.Columns.Add("IdentityNo", GetType(Long))
        dt.Columns.Add("documentname", GetType(String))
        dt.Columns.Add("documentno", GetType(String))
        dt.Columns.Add("validatedby", GetType(String))
        dt.Columns.Add("datevalidated", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow

            dr("DocuId") = DBNull.Value
            dr("IdentityNo") = DBNull.Value
            dr("documentname") = DBNull.Value
            dr("documentno") = DBNull.Value
            dr("validatedby") = DBNull.Value
            dr("datevalidated") = DBNull.Value
            dr("remarks") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable10(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prno", GetType(String))
        dt.Columns.Add("requestingdept", GetType(String))
        dt.Columns.Add("obrno", GetType(String))
        dt.Columns.Add("supplier", GetType(String))
        dt.Columns.Add("projectname", GetType(String))
        dt.Columns.Add("pono", GetType(String))
        dt.Columns.Add("podate", GetType(String))
        dt.Columns.Add("poamount", GetType(Decimal))
        dt.Columns.Add("dvno", GetType(String))
        dt.Columns.Add("checkno", GetType(String))
        dt.Columns.Add("amountpaid", GetType(String))
        dt.Columns.Add("jevno", GetType(String))
        dt.Columns.Add("m_SpecialAccount_Dtl_ID", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Integer))
        'dt.Columns.Add("ppmp_hdr_id", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prno") = DBNull.Value
            dr("requestingdept") = DBNull.Value
            dr("obrno") = DBNull.Value
            dr("supplier") = DBNull.Value
            dr("projectname") = DBNull.Value
            dr("pono") = DBNull.Value
            dr("podate") = DBNull.Value
            dr("poamount") = DBNull.Value
            dr("dvno") = DBNull.Value
            dr("checkno") = DBNull.Value
            dr("amountpaid") = DBNull.Value
            dr("jevno") = DBNull.Value
            dr("m_SpecialAccount_Dtl_ID") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            'dr("ppmp_hdr_id") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable11(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("typeofservice", GetType(String))
        dt.Columns.Add("plateno", GetType(String))
        dt.Columns.Add("datepurchased", GetType(String))
        dt.Columns.Add("acquisitioncost", GetType(Decimal))
        dt.Columns.Add("marketvalue", GetType(Decimal))
        dt.Columns.Add("condition", GetType(String))
        dt.Columns.Add("location", GetType(String))
        dt.Columns.Add("status", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("typeofservice") = DBNull.Value
            dr("plateno") = DBNull.Value
            dr("datepurchased") = DBNull.Value
            dr("acquisitioncost") = DBNull.Value
            dr("marketvalue") = DBNull.Value
            dr("condition") = DBNull.Value
            dr("location") = DBNull.Value
            dr("status") = DBNull.Value

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub ddApprovedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("ApprovedBy") = ddApprovedBy.SelectedItem.Value
    End Sub

    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Session("mode_of_procurement_id") = 1 Then
                '====== Public Bidding
                objDerived.GetRecords("DELETE FROM AMS.Bid_Information WHERE pre_procurement_hdr_id = '" & gvPurchase_Order.SelectedDataKey("CanvassID") & "' AND Supplier_ID = '" & Session("Supplier_ID") & "'", CommandType.Text)


                Dim ID As Long
                ID = objDerived.GetValue("SELECT Infra_Hdr_ID FROM AMS.tb_Infra_Hdr WHERE pre_procurement_hdr_id = '" & gvPurchase_Order.SelectedDataKey("CanvassID") & "'", CommandType.Text)

                If ID <> 0 Then
                    objDerived.GetRecords("UPDATE AMS.tb_Infra_Hdr SET withNOA = 0 WHERE pre_procurement_hdr_id = '" & gvPurchase_Order.SelectedDataKey("CanvassID") & "'", CommandType.Text)
                End If

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR has been successfully returned to Notice of Award.")


            ElseIf Session("mode_of_procurement_id") = 3 Then
                '====== Direct Contracting
                objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl_PR2 WHERE Dtl_ID_PR1 = (SELECT Dtl_ID_PR1 FROM AMS.m_Canvass_Dtl_PR1 WHERE Hdr_ID = '" & gvPurchase_Order.SelectedDataKey("CanvassID") & "')", CommandType.Text)
                objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Hdr WHERE Hdr_ID =  '" & gvPurchase_Order.SelectedDataKey("CanvassID") & "'", CommandType.Text)
                objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl_PR1 WHERE Hdr_ID = '" & gvPurchase_Order.SelectedDataKey("CanvassID") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR has been successfully returned to Canvassing as Direct Contracting.")

            ElseIf Session("mode_of_procurement_id") = 4 Then
                '====== Negotiated Procurement
                objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl_PR2 WHERE Dtl_ID_PR1 = (SELECT Dtl_ID_PR1 FROM AMS.m_Canvass_Dtl_PR1 WHERE Hdr_ID = '" & gvPurchase_Order.SelectedDataKey("CanvassID") & "')", CommandType.Text)
                objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Hdr WHERE Hdr_ID =  '" & gvPurchase_Order.SelectedDataKey("CanvassID") & "'", CommandType.Text)
                objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl_PR1 WHERE Hdr_ID = '" & gvPurchase_Order.SelectedDataKey("CanvassID") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR has been successfully returned to Pre-procurement as Negotiated.")

            Else
                '====== Canvassing
                objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET isApproved = 0 WHERE Hdr_ID = '" & gvPurchase_Order.SelectedDataKey("CanvassID") & "'", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR has been successfully returned to Abstract of Canvass Approval.")

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error. Contact Administrator.")
        End Try

        LoadPO_MainGrid()
        gvGoods.DataSource = CreateDatatable1(4)
        gvGoods.DataBind()
    End Sub
End Class
