Imports System.Data
Partial Class bidding_t_RepeatOrder
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Private cnvss_hdr As New Consolidated_Canvass.m_Canvass_Hdr
    Private cnvss_dtl1 As New Consolidated_Canvass.m_Canvass_Dtl1
    Private cnvss_dtl2 As New Consolidated_Canvass.m_Canvass_Dtl2
    Private cnvss_PR1 As New Consolidated_Canvass.m_Canvass_Dtl_PR1
    Private cnvss_PR2 As New Consolidated_Canvass.m_Canvass_Dtl_PR2

    Dim pohdr As New t_purchase_order_hdr
    Dim podtl As New t_purchase_order_dtl
    Dim total As Integer = 0
    Dim PR_Canvass As New t_PR_Canvass
    Private cb As CheckBox


#Region "property"

    Private Property dtSuppliers() As DataTable
        Get
            Return CType(Session("dtSuppliers"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSuppliers") = value
        End Set
    End Property

    Private Property pBody() As DataTable
        Get
            Return CType(Session("pBody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBody") = value
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
    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
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

    Private Property pGoodsPerSupplier2() As DataTable
        Get
            Return CType(Session("supplier_id"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("supplier_id") = value
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

    Private Property dtItemList() As DataTable
        Get
            Return CType(Session("dtItemList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItemList") = value
        End Set
    End Property

#End Region
#Region "Functions"
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("Supplier_Id", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("status", GetType(String))
        dt.Columns.Add("isOld", GetType(Boolean))
        dt.Columns.Add("canvass_hdr_id", GetType(Integer))
        dt.Columns.Add("prhdr_id", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = DBNull.Value
            dr("Supplier_Id") = DBNull.Value
            dr("isVisible") = True
            dr("amount") = DBNull.Value
            dr("status") = DBNull.Value
            dr("isOld") = False
            dr("canvass_hdr_id") = DBNull.Value
            dr("prhdr_id") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_no", GetType(Integer))
        dt.Columns.Add("Item_ID", GetType(Integer))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("total", GetType(Decimal))
        dt.Columns.Add("item_desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("BGA_ID", GetType(Integer))
        dt.Columns.Add("isEnable", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_no") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("qty") = DBNull.Value
            dr("cost") = DBNull.Value
            dr("total") = DBNull.Value
            dr("item_desc") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("remarks") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("BGA_ID") = DBNull.Value
            dr("isEnable") = True
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createtable_gvbody(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("total", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("cost") = DBNull.Value
            dr("total") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("rc_name")
        dt.Columns.Add("Function_Desc")
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("pr_no")
        dt.Columns.Add("DateApproved", GetType(Date))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("RC_ID", GetType(Long))
        dt.Columns.Add("Function_ID", GetType(Long))
        dt.Columns.Add("OBR_No")
        dt.Columns.Add("isReimbursement", GetType(Boolean))
        'dt.Columns.Add("isDC", GetType(Boolean))
        dt.Columns.Add("isPublicInfra", GetType(Boolean))
        'dt.Columns.Add("isStraight", GetType(Boolean))
        'dt.Columns.Add("FundClassno", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("rc_name") = ""
            dr("Function_Desc") = ""
            dr("isVisible") = False
            dr("prhdr_id") = 0
            dr("pr_no") = ""
            dr("DateApproved") = CType("01/01/1900", Date)
            dr("ABC") = "0.00"
            dr("RC_ID") = 0
            dr("Function_ID") = 0
            dr("OBR_No") = ""
            dr("isReimbursement") = False
            'dr("isDC") = False
            dr("isPublicInfra") = False
            'dr("isStraight") = False
            'dr("FundClassno") = 0
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function createdatatableSuppliers(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName")
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("status")
        dt.Columns.Add("isOld", GetType(Boolean))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = ""
            dr("Supplier_Id") = 0
            dr("isVisible") = False
            dr("amount") = "0.00"
            dr("status") = ""
            dr("isOld") = False

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

            Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
            Dim role() As String = Roles.GetRolesForUser(usr.UserName)
            Dim rolename As String = role(0)
            Session("RoleName") = rolename

            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")

            Session("MOP") = objDerived.GetValue("Select mode_of_procurement_id from ams.mode_of_procurement where mode_description='Repeat Order'", CommandType.Text)


            pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassList_Search_DD] '" & Session("RoleName") & "','" & Session("MOP") & "'", CommandType.Text)

            If pShopping.Rows.Count < 8 Then
                pShopping.Merge(createdatatable(8 - pShopping.Rows.Count))
            End If
            gvIncomingPR.DataSource = pShopping
            gvIncomingPR.DataBind()

            ddSupplier1.DataSource = objDerived.GetDataTable("Select * from dbo.Supplier order by SuppName", CommandType.Text)
            ddSupplier1.DataTextField = ("SuppName")
            ddSupplier1.DataValueField = ("Supplier_Id")
            ddSupplier1.DataBind()
            ddSupplier1.Items.Insert(0, "Select")

            Me.Session("page") = "canvass"

            pPurchase_Order_detail = Nothing
            grdPerItems.DataSource = pPurchase_Order_detail
            grdPerItems.DataBind()

            grdSupplier1.DataSource = Nothing
            grdSupplier1.DataBind()

            Dim cnvss As New DataTable
            cnvss = Nothing

            Me.mvCategory.SetActiveView(Me.vwItems)
            btnPrint.Enabled = False
            'LoadrbChoice()



        End If

        txtcanvassearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnsearch.ClientID & "')")

    End Sub
    Protected Sub gvIncomingPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Session("Action") <> "" Then

            Session("prhdr_id") = gvIncomingPR.SelectedDataKey("prhdr_id")
            Session("isRecanvass") = gvIncomingPR.SelectedDataKey("isRecanvass")
            Session("isDBM") = gvIncomingPR.SelectedDataKey("isDBM")


            If Session("Action") = "Cancel" Then
                If gvIncomingPR.SelectedDataKey("isRecanvass") = True Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Re-Canvass transactions cannot be return to OBR evaluation.")
                    Exit Sub
                Else
                    Try
                        Dim dt As New DataTable
                        dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Return_Canvass] WHERE prhdr_id = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                        If dt.Rows(0)("Hdr_ID") = 0 Then
                            '======= UPDATE AMS.PR_Hdr (mode_of_procurement_id)
                            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET mode_of_procurement_id = 0,isOnBid = 0 WHERE prhdr_id = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                            '======= DELETE RECORDS IN AMS.obr_evaluation_hdr
                            objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_hdr WHERE obr_evaluation_hdr_id = '" & dt.Rows(0)("obr_evaluation_hdr_id") & "'", CommandType.Text)
                            objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id = '" & dt.Rows(0)("obr_evaluation_hdr_id") & "'", CommandType.Text)

                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "PR has been successfully returned to OBR Evaluation.")

                            pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassList_Search_DD] '" & Session("RoleName") & "','" & Session("MOP") & "'", CommandType.Text)
                            If pShopping.Rows.Count < 8 Then
                                pShopping.Merge(createdatatable(8 - pShopping.Rows.Count))
                            End If
                            gvIncomingPR.DataSource = pShopping
                            gvIncomingPR.DataBind()
                            gvIncomingPR.SelectedIndex = -1

                            grdPerItems.DataSource = Nothing
                            grdPerItems.DataBind()

                        Else
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Remove all supplier under this transaction before returning into OBR Evaluation.")
                        End If
                    Catch ex As Exception
                    End Try
                End If
                Session("Action") = ""

            ElseIf Session("Action") = "PRNumber" Then
                btnPrint.Enabled = True
                LoadrbChoice()

                '=-= DEFAULT - ALL CHECKBOX
                If gvIncomingPR.Rows.Count <> 0 Then
                    For i As Integer = 0 To grdPerItems.Rows.Count - 1
                        Dim cb As CheckBox = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                        cb.Checked = True
                    Next
                End If
                Session("Action") = ""
            End If

        End If

    End Sub
    Protected Sub gvIncomingPR_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvIncomingPR.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvIncomingPR, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub gvIncomingPR_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        'pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassList] '" & Session("RoleName") & "'", CommandType.Text)
        'If pShopping.Rows.Count < 8 Then
        '    pShopping.Merge(createdatatable(8 - pShopping.Rows.Count))
        'End If
        gvIncomingPR.DataSource = pShopping
        gvIncomingPR.PageIndex = e.NewPageIndex
        gvIncomingPR.DataBind()

    End Sub
    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdPerItems.Rows.Count - 1
                item = Me.grdPerItems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.grdPerItems.Rows.Count - 1
                item = Me.grdPerItems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If

        LoadtxtCostItems()
    End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim myview As DataView
        myview = pShopping.DefaultView
        myview.RowFilter = "pr_no like '%" & txtcanvassearch.Text & "%'"
        gvIncomingPR.DataSource = myview
        gvIncomingPR.DataBind()

        grdPerItems.DataSource = Nothing
        grdPerItems.DataBind()

    End Sub
    Protected Sub btnviewAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtcanvassearch.Text = ""

        pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassList_Search] '" & txtcanvassearch.Text & "'", CommandType.Text)
        If pShopping.Rows.Count < 8 Then
            pShopping.Merge(createdatatable(8 - pShopping.Rows.Count))
        End If
        gvIncomingPR.DataSource = pShopping
        gvIncomingPR.DataBind()
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.Session("page") = "canvass_goods"
            Me.Page.Response.Redirect("~/bidding/rpt_canvass_persupplier.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Public Sub call_laod_supplier_per_project()

        Session("pre_procurement_hdr_id") = gvIncomingPR.SelectedDataKey(0)
        pTempSupplier = Nothing

        pSupplier = objDerived.GetDataTable("exec ams.sp_supplier_per_canvass " & gvIncomingPR.SelectedDataKey(0) & "," & True & "", CommandType.Text)
        pTempSupplier = objDerived.GetDataTable("exec ams.sp_supplier_per_canvass " & gvIncomingPR.SelectedDataKey(0) & "," & True & "", CommandType.Text)
        If pTempSupplier.Rows.Count < 8 Then
            pTempSupplier.Merge(createdatatableSuppliers(7 - pTempSupplier.Rows.Count))
        End If

        If pSupplier.Rows.Count >= 1 Then
            For i As Integer = 0 To pSupplier.Rows.Count - 1
                Dim a As Integer = gvIncomingPR.SelectedDataKey(0)
                Dim b As Integer = pSupplier.Rows(i)("Supplier_Id")
                Dim data As DataTable = objDerived.GetDataTable("exec ams.sp_canvass_form_detail_vb_existing " & gvIncomingPR.SelectedDataKey(0) & ", " & pSupplier.Rows(i)("Supplier_Id") & "," & True & "", CommandType.Text)
                pGoodsPerSupplier(pSupplier.Rows(i)("Supplier_Id").ToString) = objDerived.GetDataTable("exec ams.sp_canvass_form_detail_vb_existing " & gvIncomingPR.SelectedDataKey(0) & ", " & pSupplier.Rows(i)("Supplier_Id") & "," & True & "", CommandType.Text)
            Next
        End If
    End Sub
    Protected Sub LoadrbChoice()
        Session("rbChoice") = 1

        If gvIncomingPR.SelectedDataKey("isRecanvass") = True Then
            pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassItemList_reCanvass] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            grdPerItems.DataSource = pPurchase_Order_detail
            grdPerItems.DataBind()

            '  Dim dtSuppliers As New DataTable
            dtSuppliers = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "',1", CommandType.Text)
            grdSupplier1.DataSource = dtSuppliers
            grdSupplier1.DataBind()

        ElseIf gvIncomingPR.SelectedDataKey("isDBM") = True Then
            pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassItemList_DBM] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            grdPerItems.DataSource = pPurchase_Order_detail
            grdPerItems.DataBind()

            '  Dim dtSuppliers As New DataTable
            dtSuppliers = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "',0", CommandType.Text)
            grdSupplier1.DataSource = dtSuppliers
            grdSupplier1.DataBind()

        Else
            pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassItemList] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            grdPerItems.DataSource = pPurchase_Order_detail
            grdPerItems.DataBind()

            '    Dim dtSuppliers As New DataTable
            dtSuppliers = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "',0", CommandType.Text)
            grdSupplier1.DataSource = dtSuppliers
            grdSupplier1.DataBind()
        End If


        If grdPerItems.Rows.Count <> 0 Then
            LoadtxtCostItems()
        End If

        'pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassItemList] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        'grdPerItems.DataSource = pPurchase_Order_detail
        'grdPerItems.DataBind()

        'Dim dtSuppliers As New DataTable
        'dtSuppliers = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        'grdSupplier1.DataSource = dtSuppliers
        'grdSupplier1.DataBind()

        'If grdPerItems.Rows.Count <> 0 Then
        '    LoadtxtCostItems()
        'End If

    End Sub
    Protected Sub LoadtxtCostItems()
        Dim x As Decimal
        For i As Integer = 0 To grdPerItems.Rows.Count - 1
            Dim cb As CheckBox = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            cb.Checked = True
        Next

        grdPerItems.Columns(7).Visible = True
        For i As Integer = 0 To grdPerItems.Rows.Count - 1
            cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If cb.Checked = True Then
                Dim ApprovedBudget As Decimal = CType(grdPerItems.Rows(i).FindControl("lblApprovedBudget"), Label).Text
                Dim txtcost As TextBox = CType(grdPerItems.Rows(i).FindControl("txtcost1"), TextBox)
                Dim txtqty As TextBox = CType(grdPerItems.Rows(i).FindControl("txtqty"), TextBox)

                Dim Tcost As Decimal = FormatNumber(txtcost.Text * txtqty.Text, 2)
                CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = FormatNumber(Tcost, 2)
                x = x + (txtcost.Text * txtqty.Text)

                'If ApprovedBudget < CType(txtcost.Text, Decimal) Then
                '    CType(grdPerItems.Rows(i).FindControl("txtcost1"), TextBox).Text = FormatNumber(0, 2)
                '    CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = FormatNumber(0, 2)
                '    x = x
                'Else
                '    CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = FormatNumber(Tcost, 2)
                '    x = x + (txtcost.Text * txtqty.Text)
                'End If
            Else
                CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = "0.00"
            End If
        Next

        CType(grdPerItems.FooterRow.Cells(4).FindControl("lblTotalAmount1"), Label).Text = FormatNumber(x, 2)
        grdPerItems.Columns(7).Visible = False

    End Sub
    Protected Sub txtqty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSupplier1.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Select a supplier first.")
            Exit Sub
        ElseIf ddSupplier1.SelectedItem.Value = 117 Then
            LoadPSDBM()
        Else
            LoadtxtCostItems()
        End If

    End Sub
    Protected Sub btnSave1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSupplier1.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Select a supplier.")
            Exit Sub
        End If

        If dtSuppliers.Rows.Count > 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Multiple suppliers are invalid!")
            Exit Sub
        End If


        Try
            Dim cb As CheckBox
            Session("cb") = 0
            For i As Integer = 0 To grdPerItems.Rows.Count - 1
                cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Checked = True Then
                    Session("cb") = 1
                    Exit For
                End If
            Next

            If Session("cb") = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "No selected item.")
                Exit Sub
            End If

            '=-= SAVE HEADER "AMS.m_Canvass_Hdr" 
            With cnvss_hdr
                .Canvass_Date = txtdate.Text
                .PR_Hdr_ID = gvIncomingPR.SelectedDataKey("prhdr_id")
                .withWinner = False
                If ddSupplier1.SelectedItem.Value = 117 Then
                    .isDBM = True
                Else
                    .isDBM = False
                End If
            End With

            'Dim Hdr_ID As Long
            'Hdr_ID = objDerived.GetValue("SELECT Hdr_ID FROM AMS.m_Canvass_Hdr WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "' AND isDBM = 0", CommandType.Text)
            'If Hdr_ID = 0 Then
            '    Session("Hdr_ID") = cnvss_hdr.save()
            'Else
            '    'objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET Canvass_Date = '" & txtdate.Text & "' WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "' AND isDBM = 0", CommandType.Text)
            '    Session("Hdr_ID") = Hdr_ID
            'End If


            '============= CHECK IF RECANVASS ================
            Dim Hdr_ID As Long
            If gvIncomingPR.SelectedDataKey("isRecanvass") = True Then
                Hdr_ID = objDerived.GetValue("SELECT Hdr_ID FROM AMS.m_Canvass_Hdr WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "' AND isDBM = 0 AND isReCanvass = 1", CommandType.Text)
                If Hdr_ID = 0 Then
                    Session("Hdr_ID") = cnvss_hdr.save()
                    objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET isReCanvass = 1 WHERE Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)
                Else
                    Session("Hdr_ID") = Hdr_ID
                End If
            Else
                Hdr_ID = objDerived.GetValue("SELECT Hdr_ID FROM AMS.m_Canvass_Hdr WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "' AND isDBM = 0 AND isReCanvass = 0", CommandType.Text)
                If Hdr_ID = 0 Then
                    Session("Hdr_ID") = cnvss_hdr.save()
                Else
                    Session("Hdr_ID") = Hdr_ID
                End If
            End If


            If ddSupplier1.SelectedItem.Text <> "PS-DBM" Then 'REGULAR SUPPLIER/ BIDDER
                '=-= SAVE CANVASS List of Items in PR "AMS.m_Canvass_Dtl1" 
                Dim dtl1 As New DataTable
                dtl1 = objDerived.GetDataTable("SELECT * FROM AMS.m_Canvass_Dtl1 WHERE Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)
                If dtl1.Rows.Count = 0 Then
                    For i As Integer = 0 To grdPerItems.Rows.Count - 1
                        cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                        If cb.Checked = True Then
                            With cnvss_dtl1
                                .Hdr_ID = Session("Hdr_ID")
                                .Item_ID = pPurchase_Order_detail.Rows(i)("Item_ID")
                                .save()
                            End With
                        End If
                    Next
                End If


                '=-= SAVE CANVASS List of Bidders "AMS.m_Canvass_Dtl2"
                For i As Integer = 0 To grdPerItems.Rows.Count - 1
                    cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If cb.Checked = True Then
                        Dim Dtl_ID1 As Long = objDerived.GetValue("SELECT * FROM AMS.m_Canvass_Dtl1 WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND Item_ID = '" & pPurchase_Order_detail.Rows(i)("Item_ID") & "'", CommandType.Text)
                        Dim CanvassPrice As Decimal = CType(CType(grdPerItems.Rows(i).FindControl("txtCost1"), TextBox).Text, Decimal)
                        Dim CanvassQty As Decimal = CType(CType(grdPerItems.Rows(i).FindControl("txtqty"), TextBox).Text, Decimal)

                        Dim dtl2 As New DataTable
                        dtl2 = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassItem_Check] WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND Item_ID = '" & pPurchase_Order_detail.Rows(i)("Item_ID") & "' AND Supplier_ID = '" & ddSupplier1.SelectedItem.Value & "'", CommandType.Text)
                        If dtl2.Rows.Count = 0 Then
                            With cnvss_dtl2
                                .Dtl_ID1 = Dtl_ID1
                                .Supplier_ID = ddSupplier1.SelectedItem.Value
                                .isWinner = False
                                .UnitPrice = CanvassPrice
                                .Quantity = CanvassQty
                                .ItemSpecs = CType(grdPerItems.Rows(i).FindControl("txtItemSpecs"), TextBox).Text
                                .save()
                            End With

                        Else
                            With cnvss_dtl2
                                .Dtl_ID2 = dtl2.Rows(0)("Dtl_ID2")
                                .Dtl_ID1 = Dtl_ID1
                                .Supplier_ID = ddSupplier1.SelectedItem.Value
                                .isWinner = False
                                .UnitPrice = CanvassPrice
                                .Quantity = CanvassQty
                                .ItemSpecs = CType(grdPerItems.Rows(i).FindControl("txtItemSpecs"), TextBox).Text
                                .update()
                            End With
                        End If

                    End If
                Next

            Else 'FOR DBM AS SUPPLIER/ BIDDER

                objDerived.Execute("UPDATE AMS.m_Canvass_Hdr SET isApproved = 1, DateApproved = '" & txtdate.Text & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)

                '=-= SAVE DETAIL "AMS.m_Canvass_Dtl_PR1" 
                With cnvss_PR1
                    .Dtl_ID_PR1 = 0
                    .Hdr_ID = Session("Hdr_ID")
                    .Supplier_ID = ddSupplier1.SelectedItem.Value

                    If ddSupplier1.SelectedItem.Value = 117 Then
                        .isWinner = True
                    Else
                        .isWinner = False
                    End If

                End With

                Dim Dtl_ID_PR1 As Long = cnvss_PR1.save()
                Session("Dtl_ID_PR1") = Dtl_ID_PR1
                objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl_PR1 SET withPO = 0 WHERE Dtl_ID_PR1 = '" & Session("Dtl_ID_PR1") & "'", CommandType.Text)


                '=-= SAVE DETAIL "AMS.m_Canvass_Dtl_PR2" 
                For i As Integer = 0 To grdPerItems.Rows.Count - 1
                    cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If cb.Checked = True Then
                        Dim CanvassPrice As Decimal = CType(CType(grdPerItems.Rows(i).FindControl("txtCost1"), TextBox).Text, Decimal)
                        Dim CanvassQty As Decimal = CType(CType(grdPerItems.Rows(i).FindControl("txtqty"), TextBox).Text, Decimal)

                        With cnvss_PR2
                            .Dtl_ID_PR2 = 0
                            .Dtl_ID_PR1 = Session("Dtl_ID_PR1")
                            .Item_ID = pPurchase_Order_detail.Rows(i)("Item_ID")
                            .UnitPrice = CanvassPrice
                            .Quantity = CanvassQty

                            If CanvassPrice <> 0 And CanvassQty <> 0 Then
                                .save()
                            End If
                        End With
                    End If
                Next
            End If

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been successfully saved.")

            ddSupplier1.DataSource = objDerived.GetDataTable("Select * from dbo.Supplier order by SuppName", CommandType.Text)
            ddSupplier1.DataTextField = ("SuppName")
            ddSupplier1.DataValueField = ("Supplier_Id")
            ddSupplier1.DataBind()
            ddSupplier1.Items.Insert(0, "Select")
            'grdPerItems.Columns(0).Visible = False

            LoadrbChoice()

        Catch ex As Exception
        End Try

    End Sub
    'Protected Sub loadold()
    '    '=-= SAVE DETAIL 1 "AMS.m_Canvass_Dtl1"
    '    For i As Integer = 0 To grdPerItems.Rows.Count - 1
    '        cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
    '        If cb.Checked = True Then
    '            With cnvss_dtl1
    '                .Dtl_ID1 = 0
    '                .Hdr_ID = Session("Hdr_ID")
    '                .Item_ID = pPurchase_Order_detail.Rows(i)("Item_ID")

    '                If ddSupplier1.SelectedItem.Value = 117 Then
    '                    .withWinner = True
    '                Else
    '                    .withWinner = False
    '                End If

    '            End With

    '            Dim Dtl_ID1 As Long
    '            Dtl_ID1 = objDerived.GetValue("SELECT Dtl_ID1 FROM AMS.m_Canvass_Dtl1 WHERE Item_ID = '" & pPurchase_Order_detail.Rows(i)("Item_ID") & "' AND Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)

    '            If Dtl_ID1 = 0 Then
    '                Session("Dtl_ID1") = cnvss_dtl1.save
    '            Else
    '                Session("Dtl_ID1") = Dtl_ID1
    '            End If


    '            '=-= SAVE DETAIL 2 "AMS.m_Canvass_Dtl2"
    '            With cnvss_dtl2
    '                .Dtl_ID2 = 0
    '                .Dtl_ID1 = Session("Dtl_ID1")
    '                .Supplier_ID = ddSupplier1.SelectedItem.Value
    '                .UnitPrice = CType(CType(grdPerItems.Rows(i).FindControl("txtCost1"), TextBox).Text, Decimal)
    '                .Quantity = pPurchase_Order_detail.Rows(i)("qty")

    '                If ddSupplier1.SelectedItem.Value = 117 Then
    '                    .isWinner = True
    '                Else
    '                    .isWinner = False
    '                End If

    '            End With

    '            Dim Dtl_ID2 As Long
    '            Dtl_ID2 = objDerived.GetValue("SELECT Dtl_ID2 FROM AMS.m_Canvass_Dtl2 WHERE Supplier_ID = '" & ddSupplier1.SelectedItem.Value & "' AND Dtl_ID1 = '" & Session("Dtl_ID1") & "'", CommandType.Text)

    '            If Dtl_ID2 = 0 Then
    '                Dtl_ID2 = cnvss_dtl2.save()
    '            Else
    '                cnvss_dtl2.update()
    '            End If

    '            objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 SET withPO = 0 WHERE Dtl_ID2 = '" & Dtl_ID2 & "'", CommandType.Text)
    '        End If
    '    Next
    'End Sub
    Protected Sub txtCost1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSupplier1.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Select a supplier first.")
            Exit Sub
        End If

        Dim txtCost1 As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtCost1.NamingContainer, GridViewRow)
        txtCost1.Text = FormatNumber(txtCost1.Text, 2)

        If ddSupplier1.SelectedItem.Value = 117 Then
            LoadPSDBM()
        Else
            LoadtxtCostItems()
        End If

    End Sub
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadPSDBM()
    End Sub
    Protected Sub LoadPSDBM()
        Dim x As Decimal
        For i As Integer = 0 To grdPerItems.Rows.Count - 1
            cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If cb.Checked = True Then
                Dim txtcost As TextBox = CType(grdPerItems.Rows(i).FindControl("txtcost1"), TextBox)
                Dim txtqty As TextBox = CType(grdPerItems.Rows(i).FindControl("txtqty"), TextBox)

                Dim Tcost As Decimal = FormatNumber(txtcost.Text * txtqty.Text, 2)

                CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = Tcost
                x = x + (txtcost.Text * txtqty.Text)
            Else
                CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = "0.00"
            End If
        Next

        CType(grdPerItems.FooterRow.Cells(4).FindControl("lblTotalAmount1"), Label).Text = FormatNumber(x, 2)
    End Sub
    Protected Sub lnkviewItems_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "view"
    End Sub
    Protected Sub linkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "delete"
    End Sub
    Protected Sub grdSupplier1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Lbtn = "view" Then
            dtItemList = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_ItemList] '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "','" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            grdItemList.DataSource = dtItemList
            grdItemList.DataBind()

            ModalPopupExtendepopup.Show()

        ElseIf Lbtn = "delete" Then
            Try
                If grdSupplier1.SelectedDataKey("Supplier_ID") = 117 Then
                    '================ DEPARTMENT OF BUDGET AND MANAGEMENT
                    Dim dt As New DataTable
                    dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassSuppList] WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                    If dt.Rows.Count <> 0 Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Remove other supplier before removing DBM from the list.")
                    Else
                        '================ DELETE IN CANVASS HEADER
                        Dim dtDBM As New DataTable
                        dtDBM = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassDBMList] WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Hdr WHERE Hdr_ID = '" & dtDBM.Rows(0)("Hdr_ID") & "'", CommandType.Text)

                        '================ DELETE IN CANVASS DETAIL 2
                        Dim ID As Integer
                        ID = objDerived.GetValue("SELECT Dtl_ID_PR1 FROM AMS.m_Canvass_Dtl_PR1 WHERE Hdr_ID = '" & dtDBM.Rows(0)("Hdr_ID") & "'", CommandType.Text)
                        objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl_PR2 WHERE Dtl_ID_PR1 = '" & ID & "'", CommandType.Text)

                        '================ DELETE IN CANVASS DETAIL 1
                        objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl_PR1 WHERE Hdr_ID = '" & dtDBM.Rows(0)("Hdr_ID") & "'", CommandType.Text)

                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "DBM has been successfully removed from the list.")
                    End If


                Else
                    '================ OTHER SUPPLIERS
                    Dim dt As New DataTable
                    dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassSuppList] WHERE Supplier_ID = '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "' AND PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                    For i As Integer = 0 To dt.Rows.Count - 1
                        objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl2 WHERE Dtl_ID2 = '" & dt.Rows(i)("Dtl_ID2") & "'", CommandType.Text)
                    Next

                    '================ IF ALL SUPPLIER HAS BEEN REMOVED, DELETE CANVASS HEADER
                    Dim dt2 As New DataTable
                    dt2 = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassSuppList] WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                    If dt2.Rows.Count = 0 Then
                        Dim Hdr_ID As Integer
                        Hdr_ID = objDerived.GetValue("SELECT Hdr_ID FROM AMS.m_Canvass_Hdr WHERE isDBM = 0 AND PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                        objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl1 WHERE Hdr_ID = '" & Hdr_ID & "'", CommandType.Text)
                        objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Hdr WHERE Hdr_ID = '" & Hdr_ID & "'", CommandType.Text)
                    End If

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Supplier has been successfully removed from the list.")
                End If

            Catch ex As Exception
            End Try
        End If

        LoadrbChoice()
    End Sub
    Protected Sub grdSupplier1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdSupplier1, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdItemList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtItemList As New DataTable
        dtItemList = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Canvass_BidderItem_List] WHERE Supplier_ID = '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "' AND PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        grdItemList.PageIndex = e.NewPageIndex
        grdItemList.DataSource = dtItemList
        grdItemList.DataBind()

        ModalPopupExtendepopup.Show()
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
                objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl2 WHERE Supplier_ID = '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "' AND Dtl_ID2 = '" & grdItemList.SelectedDataKey("Dtl_ID2") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Item has been successfully removed.")

                Dim dtItemList As New DataTable
                dtItemList = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassPerItem_Items] WHERE Supplier_ID = '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "' AND PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                grdItemList.DataSource = dtItemList
                grdItemList.DataBind()

                LoadrbChoice()

                ModalPopupExtendepopup.Show()
            Catch ex As Exception
            End Try

        End If
    End Sub
    Protected Sub ddSupplier1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadrbChoice()

        If ddSupplier1.SelectedItem.Value = 117 Then
            'grdPerItems.Columns(0).Visible = True
            For i As Integer = 0 To grdPerItems.Rows.Count - 1
                CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox).Enabled = True
                CType(Me.grdPerItems.Rows(i).Cells(3).FindControl("txtqty"), TextBox).ReadOnly = False
            Next
        Else
            'grdPerItems.Columns(0).Visible = False
            For i As Integer = 0 To grdPerItems.Rows.Count - 1
                CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox).Enabled = False
                CType(Me.grdPerItems.Rows(i).Cells(3).FindControl("txtqty"), TextBox).ReadOnly = True
            Next
        End If

    End Sub
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        LoadrbChoice()
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txt_RFQDate.Text = Date.Today.ToString("MM/dd/yyyy")
        Me.ModalPopup_RFQ.Show()

    End Sub
    Protected Sub btn_RFQDate_Click(sender As Object, e As EventArgs) Handles btn_RFQDate.Click
        Try
            objDerived.GetRecords("UPDATE [AMS].[PR_Hdr] SET [RFQ_Date] = '" & txt_RFQDate.Text & "' WHERE [prhdr_id] = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

            Dim url As String = "rpt_canvass_sheet.aspx?"
            Dim fullurl As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenx=0,resizable=0,scrollbars=0,width=900px,height=650px,left=250,top=10');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "open_window", fullurl, True)

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub lbPR_No_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Action") = "PRNumber"
    End Sub
    Protected Sub lbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Action") = "Cancel"
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To Me.grdItemList.Rows.Count - 1
            Dim Cost As Decimal = CType(grdItemList.Rows(i).FindControl("txtCanvassPrice"), TextBox).Text
            Dim ItemID As Integer = CType(grdItemList.Rows(i).FindControl("lblItem_ID"), Label).Text
            Dim DTL_ID2 As Integer = objDerived.GetValue("SELECT Dtl_ID2 FROM [dbo].[View_EditCanvassPrice] WHERE PR_Hdr_ID = '" & Session("prhdr_id") & "' AND Supplier_ID = '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "' AND Item_ID = '" & ItemID & "'", CommandType.Text)

            objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 SET UnitPrice = '" & Cost & "' WHERE Dtl_ID2 = '" & DTL_ID2 & "'", CommandType.Text)
        Next

        LoadrbChoice()
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "All canvass unit price has been successfully updated.")

    End Sub
    'Protected Sub drpModeOfProcurement_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassList_Search_DD] '" & Session("RoleName") & "','" & drpModeOfProcurement.SelectedItem.Value & "'", CommandType.Text)
    '    If pShopping.Rows.Count < 8 Then
    '        pShopping.Merge(createdatatable(8 - pShopping.Rows.Count))
    '    End If
    '    gvIncomingPR.DataSource = pShopping
    '    gvIncomingPR.DataBind()
    'End Sub
End Class
