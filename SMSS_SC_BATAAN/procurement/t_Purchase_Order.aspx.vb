Imports System.Data

Partial Class procurement_t_Purchase_Order
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Dim hdr As New t_purchase_order_hdr
    Dim dtl As New t_purchase_order_dtl
    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl
    Private pr_obr As New PR_OBR
    Private obr_hdr_NEW As New t_purchase_request_obr_hdr_OBR
    Private obr_dtl_NEW As New t_purchase_request_obr_dtl_OBR

    Private obr_hdr As New t_purchase_request_obr_hdr
    Private obr_dtl As New t_purchase_request_obr_dtl
    Private obr_Adjsutment_hdr As New t_purchase_request_obr_adjustment_hdr
    Private obr_Adjsutment_dtl As New t_purchase_request_obr_adjustment_dtl
    Private disbursement As New t_Purchase_request_disbursement

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
        dt.Columns.Add("project_location")
        dt.Columns.Add("Address1")
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("mode_of_procurement_id", GetType(Integer))
        dt.Columns.Add("pr_period_key_id", GetType(Long))
        dt.Columns.Add("isGasoline", GetType(Boolean))
        dt.Columns.Add("rc_id", GetType(Long))
        dt.Columns.Add("function_id", GetType(Long))
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
            dr("project_location") = DBNull.Value
            dr("Address1") = DBNull.Value
            dr("Supplier_Id") = 0
            dr("amount") = "0.00"
            dr("mode_of_procurement_id") = 0
            dr("pr_period_key_id") = 0
            dr("isGasoline") = False
            dr("rc_id") = 0
            dr("function_id") = 0
            dr("prhdr_id") = DBNull.Value
            dr("isConsolidated") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
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
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            txtSearch.Visible = False
            btnSearch.Visible = False
            lblSearch.Visible = False
            LoadPO_MainGrid()

            btnpreview.Enabled = False
            btnpreviewPO.Enabled = False
        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
    End Sub

    Protected Sub LoadPO_MainGrid()
        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_List]", CommandType.Text)
        If pPurchase_Order.Rows.Count < 10 Then
            pPurchase_Order.Merge(createdatatable(9 - pPurchase_Order.Rows.Count))
        End If
        gvPurchase_Order.DataSource = pPurchase_Order
        gvPurchase_Order.DataBind()

        gvGoods.DataSource = Nothing
        gvGoods.DataSource = Nothing
        gvGoods.DataBind()
    End Sub

    Protected Sub ddSearchOption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSearchOption.SelectedIndex = 0 Then
            lblSearch.Text = "ALL"
            txtSearch.Visible = False
            btnSearch.Visible = False
            lblSearch.Visible = False
            LoadPO_MainGrid()
        ElseIf ddSearchOption.SelectedIndex = 1 Then
            lblSearch.Text = "PR Number"
            txtSearch.Visible = True
            btnSearch.Visible = True
            lblSearch.Visible = True
        ElseIf ddSearchOption.SelectedIndex = 2 Then
            lblSearch.Text = "Reference No."
            txtSearch.Visible = True
            btnSearch.Visible = True
            lblSearch.Visible = True
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If ddSearchOption.SelectedIndex = 0 Then
            pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_List]", CommandType.Text)
            If pPurchase_Order.Rows.Count < 10 Then
                pPurchase_Order.Merge(createdatatable(10 - pPurchase_Order.Rows.Count))
            End If

            gvPurchase_Order.DataSource = pPurchase_Order
            gvPurchase_Order.DataBind()
        Else
            Dim myview As DataView
            myview = pPurchase_Order.DefaultView
            myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%'"
            gvPurchase_Order.DataSource = myview
            gvPurchase_Order.DataBind()
        End If

        Me.gvPurchase_Order.SelectedIndex = -1

        txtSupplier.Text = ""
        txtaddress.Text = ""
        txtDeliveryDate.Text = ""
        txtAmount.Text = ""
        ddPterm.Enabled = False
        btnsave.Enabled = False
        Me.btnpreview.Enabled = False
        Me.txtDPlace.Text = ""

    End Sub

    Protected Sub gvPurchase_Order_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        'pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_List]", CommandType.Text)
        'If pPurchase_Order.Rows.Count < 10 Then
        '    pPurchase_Order.Merge(createdatatable(10 - pPurchase_Order.Rows.Count))
        'End If
        gvPurchase_Order.DataSource = pPurchase_Order
        gvPurchase_Order.PageIndex = e.NewPageIndex
        gvPurchase_Order.DataBind()
    End Sub

    Protected Sub gvPurchase_Order_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("prhdr_id") = gvPurchase_Order.SelectedDataKey("prhdr_id")

        Session("Supplier_ID") = gvPurchase_Order.SelectedDataKey("Supplier_ID")
        Session("CanvassID") = gvPurchase_Order.SelectedDataKey("CanvassID")
        Session("isBidding") = gvPurchase_Order.SelectedDataKey("isBidding")
        Session("mode_of_procurement_id") = gvPurchase_Order.SelectedDataKey("mode_of_procurement_id")
        Session("SupplierName") = gvPurchase_Order.SelectedDataKey("SuppName")

        Dim func_per_office As String = objDerived.GetValue("SELECT Func_per_Office_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office WHERE Office_ID = '" & gvPurchase_Order.SelectedDataKey("RC_ID") & "' AND Function_ID = '" & gvPurchase_Order.SelectedDataKey("Function_ID") & "'", CommandType.Text)
        Dim str As String = objDerived.GetValue("SELECT m_Fund.Fund_Code FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Fund as m_Fund INNER JOIN LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office ON m_Fund.F_ID = m_Function_per_Office.F_ID WHERE (m_Function_per_Office.Func_per_Office_ID = " & func_per_office & ")", CommandType.Text)

        txtOBR_NO.text = objDerived.GetValue("SELECT [dbo].[func_Generate_OBR_Num_OBR] ('" & str & "','" & Date.Now & "')", CommandType.Text)

        'ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(full_name) AS full_name, empid FROM HRMS.view_signatory WHERE deptid IN (1,67) AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
        ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(full_name) AS full_name, empid FROM HRMS.view_signatory WHERE (division_Key = 86) And (isDeptHead = 'Yes') AND (position_desc = 'Governor' OR position_desc = 'Provincial Administrator')", CommandType.Text)


        ddApprovedBy.DataTextField = ("full_name")
        ddApprovedBy.DataValueField = ("empid")
        ddApprovedBy.DataBind()
        ddApprovedBy.Items.Insert(0, "Select")

        ddApprovedBy.Enabled = True

        'Try
        Session("save") = False

        txtSupplier.Text = gvPurchase_Order.SelectedDataKey("SuppName")
        txtaddress.Text = gvPurchase_Order.SelectedDataKey("Address1").ToString
        txtAmount.Text = FormatNumber(gvPurchase_Order.SelectedDataKey("ContractPrice"), 2)

        ddPterm.Enabled = True

        'btnpreview.Enabled = True
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
                txtPOnum.Text = objDerived.GetValue("SELECT [AMS].[func_GeneratePO_Bataan] ('" & txtPOdate.Text & "')", CommandType.Text)

                pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_Details] '" & Session("prhdr_id") & "','" & gvPurchase_Order.SelectedDataKey("Supplier_ID") & "','" & gvPurchase_Order.SelectedDataKey("CanvassID") & "'", CommandType.Text)
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
                txtPOnum.Text = objDerived.GetValue("SELECT [AMS].[func_GeneratePO_Bataan] ('" & txtPOdate.Text & "')", CommandType.Text)
                txtPOnum.ReadOnly = True

                pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_PurchasedOrder_Details_Bidding] '" & Session("CanvassID") & "','" & gvPurchase_Order.SelectedDataKey("Supplier_ID") & "'", CommandType.Text)
                gvGoods.DataSource = pPurchase_Order_detail
                gvGoods.DataBind()

                CType(gvGoods.FooterRow.FindControl("lbltotal"), Label).Text = FormatNumber(pPurchase_Order_detail.Compute("sum(total)", ""), 2)

            End If
        End If

        btnReturn.Enabled = True

        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        'End Try
    End Sub

    Protected Sub gvPurchase_Order_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvPurchase_Order, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub ddApprovedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("ApprovedBy") = ddApprovedBy.SelectedItem.Value

        ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(full_name) AS full_name, position_desc, empid FROM HRMS.view_signatory WHERE (division_Key = 86) And (isDeptHead = 'Yes') AND (position_desc = 'Governor' OR position_desc = 'Provincial Administrator')", CommandType.Text)

        Dim dt As New DataTable
        dt = ddApprovedBy.DataSource

        If ddApprovedBy.SelectedIndex > 0 Then
            Dim selectedRow As DataRow = dt.Rows(ddApprovedBy.SelectedIndex - 1) ' Get the selected row
            Session("AcceptingPerson") = ddApprovedBy.SelectedItem.Text
            Session("AcceptingPosition") = selectedRow("position_desc").ToString()
        End If
    End Sub

    Private Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim direction As String = "DesC"
        Dim sortExpression As String = "OBR_No"

        If ddApprovedBy.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory for approved by.")
            Exit Sub
        ElseIf ddPterm.SelectedItem.Value = "Select" Or txtDPlace.Text = "" Or txtPOnum.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
            Exit Sub
        End If

        Try
            If Me.Session("save") = False Then
                '=-= SAVE AMS.PO_HDR
                hdr.PO_No = txtPOnum.Text
                hdr.PO_Date = txtPOdate.Text
                hdr.Supplier_ID = gvPurchase_Order.SelectedDataKey("Supplier_ID")
                hdr.mode_of_procurement_id = gvPurchase_Order.SelectedDataKey("mode_of_procurement_id")
                hdr.DeliveryTerm = txtDeliveryTerm.Text
                hdr.paymentTerm = ddPterm.SelectedItem.Value
                hdr.DeliveryDate = txtDeliveryDate.Text
                hdr.DeliveryPlace = txtDPlace.Text
                hdr.isDelivered = False
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
                hdr.DateApproved_PO_Mayor = Date.Today.ToString("MM/dd/yyyy")
                hdr.DateReceived_PO_Mayor = Date.Today.ToString("MM/dd/yyyy")
                hdr.DateDisApprove = "1/1/1900"
                hdr.isGasoline = gvPurchase_Order.SelectedDataKey("isGasoline")
                hdr.isReimbursement = False
                hdr.RC_ID = gvPurchase_Order.SelectedDataKey("RC_ID")
                hdr.Function_ID = gvPurchase_Order.SelectedDataKey("Function_ID")
                hdr.ApprovedBy = CType(Session("ApprovedBy"), Integer)

                Dim hdr_id As Long = hdr.save()

                Session("POHdr_ID") = hdr_id
                Session("Year") = Year(Date.Today.ToString("MM/dd/yyyy"))

                ' Hidden Field to Retain Value After Postback
                hfPOHdr_ID.Value = hdr_id.ToString()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "debug", "console.log('Saved POHdr_ID: " & hdr_id & "');", True)


                Dim project As String = replaceapostrophe(gvPurchase_Order.SelectedDataKey("ProjectName"))

                objDerived.GetRecords("UPDATE AMS.PO_Hdr SET PR_No = '" & gvPurchase_Order.SelectedDataKey("pr_no") & "', GA_ID = '" & gvPurchase_Order.SelectedDataKey("GA_ID") & "', ProjectName = '" & project & "' WHERE POHdr_ID = '" & hdr_id & "'", CommandType.Text)

                If gvPurchase_Order.SelectedDataKey("isGasoline") = False Then
                    '====== PO Details ====== 
                    For i As Integer = 0 To pPurchase_Order_detail.Rows.Count - 1
                        dtl.POHdr_ID = hdr_id
                        dtl.Item_ID = pPurchase_Order_detail.Rows(i)("Item_ID")
                        'dtl.cost = CType(gvGoods.Rows(i).FindControl("txtcost"), TextBox).Text

                        Dim cost As Decimal
                        If Decimal.TryParse(CType(gvGoods.Rows(i).FindControl("txtcost"), TextBox).Text, cost) Then
                            dtl.cost = cost
                        Else
                            ' Handle the case where the value is not a valid decimal
                            dtl.cost = 0 ' or set an error flag
                        End If


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
                    'objDerived.GetRecords("UPDATE AMS.tb_Infra_Hdr SET withPO = 1 WHERE pre_procurement_hdr_id = '" & Session("CanvassID") & "'", CommandType.Text)

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


                'SAVING OF OBR  
                If gvPurchase_Order.SelectedDataKey("F_ID") <> 3 Then
                    '--- SAVE OBR AFTER PO SAVING
                    If gvPurchase_Order.SelectedDataKey("isConsolidated") = True Then

                        '===== GET LIST OF PR FOR CONSOLIDATED PURPOSE (SAVING IN OBR)
                        Dim dtSupplierOBR As New DataTable
                        dtSupplierOBR = objDerived.GetDataTable("EXEC [AMS].[sp_SupplierOBR] '" & Session("pohdr_id") & "'", CommandType.Text)



                        For i As Integer = 0 To dtSupplierOBR.Rows.Count - 1
                            'Try
                            '--- START SAVING OF OBR_Hdr
                            obr_hdr_NEW.TempOBR_No = ""
                            Dim obj As New BaseClassesint.AccountClassAcounts
                            Dim func_per_office As String = objDerived.GetValue("SELECT Func_per_Office_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office WHERE Office_ID = '" & gvPurchase_Order.SelectedDataKey("RC_ID") & "' AND Function_ID = '" & gvPurchase_Order.SelectedDataKey("Function_ID") & "'", CommandType.Text)
                            'Dim str As String = objDerived.GetValue("SELECT m_Fund.Fund_Code FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Fund as m_Fund INNER JOIN LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office ON m_Fund.F_ID = m_Function_per_Office.F_ID WHERE (m_Function_per_Office.Func_per_Office_ID = '" & func_per_office & "')", CommandType.Text)

                            obr_hdr_NEW.OBR_No = txtOBR_NO.Text
                            obr_hdr_NEW.F_ID_Accntg = 1
                            obr_hdr_NEW.Period_key = 0
                            obr_hdr_NEW.PRHdr_ID = Session("prhdr_id")
                            obr_hdr_NEW.OBR_Date = Date.Today.ToString("MM/dd/yyyy")
                            obr_hdr_NEW.OBR_Title = dtSupplierOBR.Rows(i)("remarks") & " >PO Number :" & txtPOnum.Text & " >" & replaceapostrophe(Session("ItemDesc"))
                            obr_hdr_NEW.Budget_Year = Year(Date.Today.ToString("MM/dd/yyyy"))
                            obr_hdr_NEW.Supplier_ID = dtSupplierOBR.Rows(i)("Supplier_ID")
                            obr_hdr_NEW.Payee = txtSupplier.Text
                            obr_hdr_NEW.Func_per_Office_ID = func_per_office
                            obr_hdr_NEW.Address = txtaddress.Text
                            obr_hdr_NEW.Remarks = replaceapostrophe(dtSupplierOBR.Rows(i)("remarks"))
                            obr_hdr_NEW.isPayroll = False
                            obr_hdr_NEW.isApprovedMayor = False
                            obr_hdr_NEW.isApproved = False
                            obr_hdr_NEW.isCancelled = False
                            obr_hdr_NEW.DateSigned1 = Date.Today.ToString("MM/dd/yyyy")
                            obr_hdr_NEW.DateSigned2 = Date.Today.ToString("MM/dd/yyyy")
                            obr_hdr_NEW.isPayroll = False
                            obr_hdr_NEW.Signatory1_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_EmployeeSignatories WHERE dept_id = '" & gvPurchase_Order.SelectedDataKey("RC_ID") & "' AND func_id = '" & gvPurchase_Order.SelectedDataKey("Function_ID") & "' AND isDeptHead = 1", CommandType.Text)
                            obr_hdr_NEW.Signatory2_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_CityBudgetOfficer", CommandType.Text)
                            obr_hdr_NEW.Status = "Pending"
                            obr_hdr_NEW.isAdjusted = False
                            obr_hdr_NEW.isAddForDisbursement = False
                            obr_hdr_NEW.isPayrollATM = False
                            obr_hdr_NEW.isGasoline = False
                            obr_hdr_NEW.pr_period_key_id = 0
                            obr_hdr_NEW.pr_invoice_hdr_id = 0
                            obr_hdr_NEW.DateDisapprovedMayor = "01/01/1900"
                            obr_hdr_NEW.DateApprovedMayor = "01/01/1900"
                            obr_hdr_NEW.DateReceivedMayor = "01/01/1900"
                            obr_hdr_NEW.isReceivedBO = False
                            'obr_hdr.Userid = Me.Session("@UserName").ToString

                            Dim obr_hdr_id As Long = obr_hdr_NEW.save()
                            Session("obr_id") = obr_hdr_id

                            Dim isContinuing As Boolean = objDerived.GetValue("SELECT isContinuing FROM AMS.PR_Hdr WHERE prhdr_id = '" & gvPurchase_Order.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                            objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Hdr SET OBR_No = '" & txtOBR_NO.Text & "', forContinuing = '" & isContinuing & "' WHERE OBR_Hdr_ID = " & obr_hdr_id, CommandType.Text)

                            '------------- END OF SAVING OBR_Hdr ------------- 

                            '------------- START OF SAVING OBR_DTL -------------
                            obr_dtl_NEW.OBR_Hdr_ID = obr_hdr_id
                            obr_dtl_NEW.particulars = replaceapostrophe(dtSupplierOBR.Rows(i)("remarks"))
                            obr_dtl_NEW.BGA_ID = objDerived.GetValue("SELECT BGA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & gvPurchase_Order.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                            obr_dtl_NEW.RC_ID = dtSupplierOBR.Rows(i)("RC_ID")
                            obr_dtl_NEW.Function_ID = dtSupplierOBR.Rows(i)("Function_ID")
                            obr_dtl_NEW.Program_ID = objDerived.GetValue("SELECT Program_id FROM AMS.tb_GSOPR_HDR WHERE prhdr_id = '" & gvPurchase_Order.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                            obr_dtl_NEW.Project_ID = objDerived.GetValue("SELECT Project_ID FROM AMS.tb_GSOPR_HDR WHERE prhdr_id = '" & gvPurchase_Order.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                            obr_dtl_NEW.GA_ID = gvPurchase_Order.SelectedDataKey("GA_ID")
                            obr_dtl_NEW.Amount = dtSupplierOBR.Rows(i)("ABC")
                            obr_dtl_NEW.AllotmentClass_ID = objDerived.GetValue("SELECT Transaction_type FROM AMS.PR_Hdr WHERE prhdr_id = '" & gvPurchase_Order.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                            obr_dtl_NEW.save()
                            '------------- END OF SAVING OBR_DTL -------------



                            'Catch ex As Exception

                            'End Try
                        Next

                        'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                    Else
                        'Try
                        '--- START SAVING OF OBR_Hdr
                        obr_hdr_NEW.TempOBR_No = ""
                        Dim obj As New BaseClassesint.AccountClassAcounts

                        Dim func_per_office As String = objDerived.GetValue("SELECT Func_per_Office_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office WHERE Office_ID = '" & gvPurchase_Order.SelectedDataKey("RC_ID") & "' AND Function_ID = '" & gvPurchase_Order.SelectedDataKey("Function_ID") & "'", CommandType.Text)
                        'Dim str As String = objDerived.GetValue("SELECT m_Fund.Fund_Code FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Fund as m_Fund INNER JOIN LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office ON m_Fund.F_ID = m_Function_per_Office.F_ID WHERE (m_Function_per_Office.Func_per_Office_ID = " & func_per_office & ")", CommandType.Text)

                        obr_hdr_NEW.OBR_No = txtOBR_NO.Text
                        obr_hdr_NEW.F_ID_Accntg = 1
                        obr_hdr_NEW.Period_key = 0
                        obr_hdr_NEW.PRHdr_ID = Session("prhdr_id")
                        obr_hdr_NEW.OBR_Date = Date.Today.ToString("MM/dd/yyyy")
                        obr_hdr_NEW.OBR_Title = replaceapostrophe(gvPurchase_Order.SelectedDataKey("ProjectName")) & " >PO Number :" & txtPOnum.Text & " >" & replaceapostrophe(Session("ItemDesc"))
                        obr_hdr_NEW.Budget_Year = Year(Date.Today.ToString("MM/dd/yyyy"))
                        obr_hdr_NEW.Supplier_ID = 0
                        obr_hdr_NEW.Payee = txtSupplier.Text
                        obr_hdr_NEW.Func_per_Office_ID = func_per_office
                        obr_hdr_NEW.Address = txtaddress.Text
                        obr_hdr_NEW.Remarks = replaceapostrophe(gvPurchase_Order.SelectedDataKey("ProjectName"))
                        obr_hdr_NEW.isPayroll = False
                        obr_hdr_NEW.isApprovedMayor = False
                        obr_hdr_NEW.isApproved = False
                        obr_hdr_NEW.isCancelled = False
                        obr_hdr_NEW.DateSigned1 = Date.Today.ToString("MM/dd/yyyy")
                        obr_hdr_NEW.DateSigned2 = Date.Today.ToString("MM/dd/yyyy")
                        obr_hdr_NEW.isPayroll = False
                        obr_hdr_NEW.Signatory1_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_EmployeeSignatories WHERE dept_id = '" & gvPurchase_Order.SelectedDataKey("RC_ID") & "' AND func_id = '" & gvPurchase_Order.SelectedDataKey("Function_ID") & "' AND isDeptHead = 1", CommandType.Text)
                        obr_hdr_NEW.Signatory2_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_CityBudgetOfficer", CommandType.Text)
                        obr_hdr_NEW.Status = "Pending"
                        obr_hdr_NEW.isAdjusted = False
                        obr_hdr_NEW.isAddForDisbursement = False
                        obr_hdr_NEW.isPayrollATM = False
                        obr_hdr_NEW.isGasoline = False
                        obr_hdr_NEW.pr_period_key_id = 0
                        obr_hdr_NEW.pr_invoice_hdr_id = 0
                        obr_hdr_NEW.DateDisapprovedMayor = "01/01/1900"
                        obr_hdr_NEW.DateApprovedMayor = "01/01/1900"
                        obr_hdr_NEW.DateReceivedMayor = "01/01/1900"
                        obr_hdr_NEW.isReceivedBO = False
                        'obr_hdr.Userid = Me.Session("@UserName").ToString

                        Dim obr_hdr_id As Long = obr_hdr_NEW.save()
                        Session("obr_id") = obr_hdr_id

                        Dim isContinuing As Boolean = objDerived.GetValue("SELECT isContinuing FROM AMS.PR_Hdr WHERE prhdr_id = '" & gvPurchase_Order.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Hdr SET obr_no = '" & txtOBR_NO.Text & "', forContinuing = '" & isContinuing & "' WHERE OBR_Hdr_ID = " & obr_hdr_id, CommandType.Text)

                        '------------- END OF SAVING OBR_Hdr ------------- 

                        '------------- START OF SAVING OBR_DTL -------------
                        obr_dtl_NEW.OBR_Hdr_ID = obr_hdr_id
                        obr_dtl_NEW.particulars = replaceapostrophe(gvPurchase_Order.SelectedDataKey("ProjectName"))
                        obr_dtl_NEW.BGA_ID = objDerived.GetValue("SELECT BGA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & gvPurchase_Order.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        obr_dtl_NEW.RC_ID = gvPurchase_Order.SelectedDataKey("RC_ID")
                        obr_dtl_NEW.Function_ID = gvPurchase_Order.SelectedDataKey("Function_ID")
                        obr_dtl_NEW.Program_ID = objDerived.GetValue("SELECT Program_id FROM AMS.PR_Hdr WHERE prhdr_id = '" & gvPurchase_Order.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        obr_dtl_NEW.Project_ID = objDerived.GetValue("SELECT Project_ID FROM AMS.PR_Hdr WHERE prhdr_id = '" & gvPurchase_Order.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        obr_dtl_NEW.GA_ID = gvPurchase_Order.SelectedDataKey("GA_ID")
                        obr_dtl_NEW.Amount = txtAmount.Text
                        obr_dtl_NEW.AllotmentClass_ID = objDerived.GetValue("SELECT Transaction_type FROM AMS.PR_Hdr WHERE prhdr_id = '" & gvPurchase_Order.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        obr_dtl_NEW.save()
                        '------------- END OF SAVING OBR_DTL -------------

                        'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                        'Catch ex As Exception
                        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.ToString)
                        'End Try
                    End If
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                End If
            End If
            'Dim Purpose As String = replaceapostrophe(gvPurchase_Order.SelectedDataKey("ProjectName"))
            ''======== OBR_HDR Edit ======== 
            'Dim OBR_HDR_ID As Integer = objDerived.GetValue("SELECT OBR_Hdr_ID FROM GeoBOS.BOS.T_OBR_Hdr AS A WHERE A.PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
            'objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Hdr SET Remarks='" & Purpose & "', OBR_Title = '" & Purpose & "', Payee='" & txtSupplier.Text & "', Address='" & txtaddress.Text & "' WHERE OBR_Hdr_ID = " & OBR_HDR_ID & "", CommandType.Text)

            ''======== OBR_Dtl Edit ========
            'objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Dtl SET amount = '" & txtAmount.Text & "', Particulars='" & Purpose & "' WHERE OBR_Hdr_ID= " & OBR_HDR_ID & " ", CommandType.Text)


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "something went wrong, please contact system admin")
        End Try

        LoadPO_MainGrid()

        btnsave.Enabled = False
        btnReturn.Enabled = False

        btnpreview.Enabled = True
        btnpreviewPO.Enabled = True

        txtSupplier.Text = ""
        txtaddress.Text = ""
        txtDPlace.Text = ""
        txtDeliveryDate.Text = ""
        txtAmount.Text = ""
        txtPOnum.Text = ""
        txtPOdate.Text = ""

        gvGoods.DataSource = CreateDatatable1(4)
        gvGoods.DataBind()
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

    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Retrieve POHdr_ID from Session or HiddenField
        Dim poHdrID As String = If(Session("POHdr_ID") IsNot Nothing, Session("POHdr_ID").ToString(), hfPOHdr_ID.Value)

        Session("pohdr_id") = poHdrID
        ' Ensure POHdr_ID is Available
        If String.IsNullOrEmpty(poHdrID) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error: POHdr_ID is missing. Please save the Purchase Order first.")
            Exit Sub
        End If

        ' Set Session Variables for the Report
        'Session("POHdr_ID") = poHdrID
        Session("Page") = "PO"



        ' Debugging Log
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "debug", "console.log('Previewing POHdr_ID: " & poHdrID & "');", True)

        ' Redirect to Report Page
        Dim url As String = "/Procurement/rpt_POcontract.aspx"
        Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)
    End Sub


    Protected Sub btnpreviewPO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Retrieve POHdr_ID from Session or HiddenField
        Dim poHdrID As String = If(Session("POHdr_ID") IsNot Nothing, Session("POHdr_ID").ToString(), hfPOHdr_ID.Value)

        ' Ensure POHdr_ID is Available
        If String.IsNullOrEmpty(poHdrID) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error: POHdr_ID is missing. Please save the Purchase Order first.")
            Exit Sub
        End If


        Session("POHdr_ID") = poHdrID

        ' Debugging Log
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "debug", "console.log('Previewing POHdr_ID: " & poHdrID & "');", True)

        ' Redirect to Report Page
        If Session("SupplierName") = "PS-DBM" Then
            Session("Page") = "PO"
            ' Me.Page.Response.Redirect("~/Procurement/rpt_ARP.aspx")

            Dim url As String = "/Procurement/rpt_ARP.aspx"
            Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)


        Else
            Session("Page") = "PO"
            'Me.Page.Response.Redirect("~/Procurement/rpt_purchase_order.aspx")

            Dim url As String = "/Procurement/rpt_purchase_order.aspx"
            Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"

            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)
        End If
    End Sub


    'Protected Sub btnpreviewPO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'Session("prhdr_id")
    '    'Session("Supplier_ID")
    '    'Session("AcceptingPerson")
    '    'Session("AcceptingPosition")
    '    Session("PODate") = txtPOdate.Text
    '    Session("ContractPrice") = txtAmount.Text

    '    'Added for required parameter
    '    Session("POHdr_ID") = gvPurchase_Order.SelectedDataKey("POHdr_ID")

    '    If Session("SupplierName") = "PS-DBM" Then
    '        Session("Page") = "PO"
    '        Me.Page.Response.Redirect("~/Procurement/rpt_ARP.aspx")
    '    Else
    '        Session("Page") = "PO"
    '        Me.Page.Response.Redirect("~/Procurement/rpt_purchase_order.aspx")
    '        'Me.Page.Response.Redirect("~/Procurement/rpt_POcontract.aspx")
    '    End If

    'End Sub

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
                If txtAmount.Text < CType(gvGoods.FooterRow.FindControl("lbltotal"), Label).Text Then
                    lblmsg.Text = "Please adjust the price of the goods."
                    btnsave.Enabled = False
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

End Class
