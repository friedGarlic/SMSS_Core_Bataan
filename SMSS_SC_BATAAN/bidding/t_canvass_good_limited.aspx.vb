Imports System.Data
Partial Class bidding_t_canvass_good_limited
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Private cnvss_hdr As New Consolidated_Canvass_Limited.m_Canvass_Hdr
    Private cnvss_dtl1 As New Consolidated_Canvass_Limited.m_Canvass_Dtl1
    Private cnvss_dtl2 As New Consolidated_Canvass_Limited.m_Canvass_Dtl2
    Private cnvss_PR1 As New Consolidated_Canvass_Limited.m_Canvass_Dtl_PR1
    Private cnvss_PR2 As New Consolidated_Canvass_Limited.m_Canvass_Dtl_PR2

    Dim pohdr As New t_purchase_order_hdr
    Dim podtl As New t_purchase_order_dtl
    Dim total As Integer = 0
    Dim PR_Canvass As New t_PR_Canvass
    Private cb As CheckBox


#Region "property"
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

            Session("MOP") = objDerived.GetValue("Select mode_of_procurement_id from ams.mode_of_procurement where mode_description='Limited Source'", CommandType.Text)


            pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassList_Search_DD] '" & Session("RoleName") & "','" & Session("MOP") & "'", CommandType.Text)

            If pShopping.Rows.Count < 8 Then
                pShopping.Merge(createdatatable(8 - pShopping.Rows.Count))
            End If
            gvIncomingPR.DataSource = pShopping
            gvIncomingPR.DataBind()

            'ddSupplier1.DataSource = objDerived.GetDataTable("Select * from dbo.Supplier order by SuppName", CommandType.Text)
            'ddSupplier1.DataTextField = ("SuppName")
            'ddSupplier1.DataValueField = ("Supplier_Id")
            'ddSupplier1.DataBind()
            'ddSupplier1.Items.Insert(0, "Select")

            Using dt As DataTable = objDerived.GetDataTable("SELECT Supplier_Id, SuppName FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
                ' Clear existing items to ensure no duplicates and prepare for fresh data load
                ddSupplier1.Items.Clear()

                ' Bind the data source
                ddSupplier1.DataSource = dt
                ddSupplier1.DataTextField = "SuppName"
                ddSupplier1.DataValueField = "Supplier_Id"
                ddSupplier1.DataBind()
            End Using

            ' Add an initial item for prompting user selection. Setting Value to an empty string or a specific default value if needed.
            ddSupplier1.Items.Insert(0, New ListItem("Select", String.Empty))


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

            'drpModeOfProcurement.DataSource = objDerived.GetDataTable("Select * from ams.mode_of_procurement where mode_description='Small Value Procurement' or mode_description = 'Shopping' or mode_description='Emergency Purchase'", CommandType.Text)
            'drpModeOfProcurement.DataTextField = ("mode_description")
            'drpModeOfProcurement.DataValueField = ("mode_of_procurement_id")
            'drpModeOfProcurement.DataBind()
            'drpModeOfProcurement.Items.Insert(0, "Select")


        End If

        txtcanvassearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnsearch.ClientID & "')")

    End Sub
    Protected Sub gvIncomingPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Session("Action") <> "" Then
            AddTrace("Session Action: " & Session("Action"))

            ' Capture and log selected DataKey values
            Session("prhdr_id") = gvIncomingPR.SelectedDataKey("prhdr_id")
            Session("isRecanvass") = gvIncomingPR.SelectedDataKey("isRecanvass")
            Session("isDBM") = gvIncomingPR.SelectedDataKey("isDBM")

            AddTrace("Selected PR Hdr ID: " & gvIncomingPR.SelectedDataKey("prhdr_id"))
            AddTrace("Selected isRecanvass: " & gvIncomingPR.SelectedDataKey("isRecanvass"))
            AddTrace("Selected isDBM: " & gvIncomingPR.SelectedDataKey("isDBM"))

            If Session("Action") = "Cancel" Then
                AddTrace("Action is 'Cancel'")

                If gvIncomingPR.SelectedDataKey("isRecanvass") = True Then
                    AddTrace("Cannot return to OBR evaluation: isRecanvass is True")
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Re-Canvass transactions cannot be return to OBR evaluation.")
                    Exit Sub
                Else
                    Try
                        ' Trace before fetching data
                        AddTrace("Fetching data for View_Return_Canvass with prhdr_id: " & gvIncomingPR.SelectedDataKey("prhdr_id"))
                        Dim dt As New DataTable
                        dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Return_Canvass] WHERE prhdr_id = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        AddTrace("Fetched rows from View_Return_Canvass: " & dt.Rows.Count)

                        If dt.Rows(0)("Hdr_ID") = 0 Then
                            AddTrace("Hdr_ID is 0, proceeding to update and delete records")

                            '======= UPDATE AMS.PR_Hdr (mode_of_procurement_id)
                            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET mode_of_procurement_id = 0,isOnBid = 0 WHERE prhdr_id = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                            '======= DELETE RECORDS IN AMS.obr_evaluation_hdr
                            objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_hdr WHERE obr_evaluation_hdr_id = '" & dt.Rows(0)("obr_evaluation_hdr_id") & "'", CommandType.Text)
                            objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id = '" & dt.Rows(0)("obr_evaluation_hdr_id") & "'", CommandType.Text)

                            AddTrace("Records in AMS.obr_evaluation_hdr and AMS.obr_evaluation_dtl deleted.")

                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "PR has been successfully returned to OBR Evaluation.")

                            ' Fetching the shopping list after the action
                            pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassList_Search_DD] '" & Session("RoleName") & "','" & Session("MOP") & "'", CommandType.Text)
                            AddTrace("Fetched pShopping rows: " & pShopping.Rows.Count)

                            If pShopping.Rows.Count < 8 Then
                                pShopping.Merge(createdatatable(8 - pShopping.Rows.Count))
                            End If
                            gvIncomingPR.DataSource = pShopping
                            gvIncomingPR.DataBind()
                            gvIncomingPR.SelectedIndex = -1

                            grdPerItems.DataSource = Nothing
                            grdPerItems.DataBind()

                        Else
                            AddTrace("Hdr_ID is not 0, cannot proceed with return to OBR Evaluation.")
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Remove all supplier under this transaction before returning into OBR Evaluation.")
                        End If
                    Catch ex As Exception
                        AddTrace("Error in processing 'Cancel': " & ex.Message)
                    End Try
                End If
                Session("Action") = ""

            ElseIf Session("Action") = "PRNumber" Then
                AddTrace("Action is 'PRNumber'")

                btnPrint.Enabled = True
                LoadrbChoice()

                '=-= DEFAULT - ALL CHECKBOX
                If gvIncomingPR.Rows.Count <> 0 Then
                    AddTrace("Setting all checkboxes to checked")
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
        Try
            Session("rbChoice") = 1

            'If gvIncomingPR.SelectedDataKey("isRecanvass") = True Then
            '    pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassItemList_reCanvass] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            '    grdPerItems.DataSource = pPurchase_Order_detail
            '    grdPerItems.DataBind()

            '    Dim dtSuppliers As New DataTable
            '    dtSuppliers = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List_limited] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "',1", CommandType.Text)
            '    grdSupplier1.DataSource = dtSuppliers
            '    grdSupplier1.DataBind()

            'ElseIf gvIncomingPR.SelectedDataKey("isDBM") = True Then
            '    pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassItemList_DBM] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            '    grdPerItems.DataSource = pPurchase_Order_detail
            '    grdPerItems.DataBind()

            '    Dim dtSuppliers As New DataTable
            '    dtSuppliers = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List_limited] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "',0", CommandType.Text)
            '    grdSupplier1.DataSource = dtSuppliers
            '    grdSupplier1.DataBind()

            'Else
            '    pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassItemList] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            '    grdPerItems.DataSource = pPurchase_Order_detail
            '    grdPerItems.DataBind()

            '    Dim dtSuppliers As New DataTable
            '    dtSuppliers = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_List_limited] '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "',0", CommandType.Text)
            '    grdSupplier1.DataSource = dtSuppliers
            '    grdSupplier1.DataBind()
            'End If


            'If grdPerItems.Rows.Count <> 0 Then
            '    LoadtxtCostItems()
            'End If




            ' Determine the key parameters from the selected data
            Dim prhdr_id As String = gvIncomingPR.SelectedDataKey("prhdr_id").ToString()
            Dim isRecanvass As Boolean = Convert.ToBoolean(gvIncomingPR.SelectedDataKey("isRecanvass"))
            Dim isDBM As Boolean = Convert.ToBoolean(gvIncomingPR.SelectedDataKey("isDBM"))

            ' Initialize variables for stored procedures
            Dim spItems As String = "[AMS].[sp_CanvassItemList]"
            Dim spSuppliers As String = "[AMS].[sp_CanvassBidder_List_limited]"
            Dim recanvassOrDBMFlag As Integer = 0 ' default value

            ' Adjust the stored procedures and parameters based on conditions
            If isRecanvass Then
                spItems = "[AMS].[sp_CanvassItemList_reCanvass]"
                recanvassOrDBMFlag = 1
            ElseIf isDBM Then
                spItems = "[AMS].[sp_CanvassItemList_DBM]"
                ' recanvassOrDBMFlag remains 0 as initialized for DBM
            End If

            ' Fetch and bind Purchase Order details
            pPurchase_Order_detail = objDerived.GetDataTable("EXEC " & spItems & " '" & prhdr_id & "'", CommandType.Text)
            grdPerItems.DataSource = pPurchase_Order_detail
            grdPerItems.DataBind()

            ' Fetch and bind Suppliers
            Dim dtSuppliers As DataTable = objDerived.GetDataTable("EXEC " & spSuppliers & " '" & prhdr_id & "'," & recanvassOrDBMFlag, CommandType.Text)
            grdSupplier1.DataSource = dtSuppliers
            grdSupplier1.DataBind()

            ' Load cost items if there are any rows in the items grid
            If grdPerItems.Rows.Count <> 0 Then
                LoadtxtCostItems()
            End If
        Catch ex As Exception

        End Try


    End Sub
    Protected Sub LoadtxtCostItems()
        Try
            ''Dim x As Decimal
            ''For i As Integer = 0 To grdPerItems.Rows.Count - 1
            ''    Dim cb As CheckBox = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            ''    cb.Checked = True
            ''Next

            ''grdPerItems.Columns(7).Visible = True
            ''For i As Integer = 0 To grdPerItems.Rows.Count - 1
            ''    cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            ''    If cb.Checked = True Then
            ''        Dim ApprovedBudget As Decimal = CType(grdPerItems.Rows(i).FindControl("lblApprovedBudget"), Label).Text
            ''        Dim txtcost As TextBox = CType(grdPerItems.Rows(i).FindControl("txtcost1"), TextBox)
            ''        Dim txtqty As TextBox = CType(grdPerItems.Rows(i).FindControl("txtqty"), TextBox)

            ''        Dim Tcost As Decimal = FormatNumber(txtcost.Text * txtqty.Text, 2)
            ''        CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = FormatNumber(Tcost, 2)
            ''        x = x + (txtcost.Text * txtqty.Text)
            ''    Else
            ''        CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = "0.00"
            ''    End If
            ''Next

            ''CType(grdPerItems.FooterRow.Cells(4).FindControl("lblTotalAmount1"), Label).Text = FormatNumber(x, 2)
            ''grdPerItems.Columns(7).Visible = False


            ''--------------------- Optimize

            'The enhanced version Of your code aims To improve readability, efficiency, And error handling. I've also corrected an issue where you attempt to parse the text of a Label as a Decimal without conversion. Here is the revised code:

            'vb
            ' Copy code
            ' Initialize total cost variable
            Dim totalCost As Decimal = 0

            ' Ensure the specific column is visible during processing
            grdPerItems.Columns(7).Visible = True

            For i As Integer = 0 To grdPerItems.Rows.Count - 1
                ' Retrieve the checkbox, and ensure it's checked
                Dim cb As CheckBox = CType(grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                cb.Checked = True  ' This line checks all checkboxes, remove if only status check is required

                ' Only proceed if the checkbox is checked
                If cb.Checked Then
                    ' Parse the Approved Budget, Cost, and Quantity safely
                    Dim lblApprovedBudget As Label = CType(grdPerItems.Rows(i).FindControl("lblApprovedBudget"), Label)
                    Dim approvedBudget As Decimal = If(Decimal.TryParse(lblApprovedBudget.Text, approvedBudget), approvedBudget, 0D)

                    Dim txtCost As TextBox = CType(grdPerItems.Rows(i).FindControl("txtcost1"), TextBox)
                    Dim cost As Decimal = If(Decimal.TryParse(txtCost.Text, cost), cost, 0D)

                    Dim txtQty As TextBox = CType(grdPerItems.Rows(i).FindControl("txtqty"), TextBox)
                    Dim quantity As Decimal = If(Decimal.TryParse(txtQty.Text, quantity), quantity, 0D)

                    ' Calculate total cost for the item
                    Dim itemTotalCost As Decimal = cost * quantity

                    ' Set the total cost in the respective TextBox
                    CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = FormatNumber(itemTotalCost, 2)

                    ' Accumulate the total cost
                    totalCost += itemTotalCost
                Else
                    ' If checkbox is not checked, reset the total cost for the item to 0.00
                    CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = "0.00"
                End If
            Next

            ' Update the footer row total amount
            If grdPerItems.FooterRow IsNot Nothing Then
                CType(grdPerItems.FooterRow.Cells(4).FindControl("lblTotalAmount1"), Label).Text = FormatNumber(totalCost, 2)
            End If

            ' Hide the specific column after processing if needed
            grdPerItems.Columns(7).Visible = False
        Catch ex As Exception

        End Try



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
        AddTrace("btnSave1_Click triggered. ddSupplier1.SelectedItem.Text=" & ddSupplier1.SelectedItem.Text)

        If ddSupplier1.SelectedItem.Text = "Select" Then
            AddTrace("Condition met: ddSupplier1.SelectedItem.Text = 'Select'. Displaying message and exiting Sub.")
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Select a supplier.")
            Exit Sub
        End If

        Try
            AddTrace("Entering Try block.")
            Dim cb As CheckBox
            Session("cb") = 0
            AddTrace("Initialized Session('cb') to 0. Looping through grdPerItems rows count = " & grdPerItems.Rows.Count)

            For i As Integer = 0 To grdPerItems.Rows.Count - 1
                cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                AddTrace("Row " & i.ToString() & ", cb.Checked=" & cb.Checked.ToString())
                If cb.Checked = True Then
                    AddTrace("Found a checked item at row " & i.ToString() & ". Setting Session('cb') = 1 and exiting loop.")
                    Session("cb") = 1
                    Exit For
                End If
            Next

            If Session("cb") = 0 Then
                AddTrace("No items were checked. Displaying message and exiting Sub.")
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "No selected item.")
                Exit Sub
            End If

            AddTrace("Saving header data into AMS.m_Canvass_Hdr_Limited object. txtdate.Text=" & txtdate.Text & ", PR_Hdr_ID=" & gvIncomingPR.SelectedDataKey("prhdr_id"))
            '=-= SAVE HEADER "AMS.m_Canvass_Hdr" 
            With cnvss_hdr
                .Canvass_Date = txtdate.Text
                .PR_Hdr_ID = gvIncomingPR.SelectedDataKey("prhdr_id")
                .withWinner = False
                AddTrace("Checking if ddSupplier1.SelectedItem.Value=117 (PS-DBM). Actual value: " & ddSupplier1.SelectedItem.Value)
                If ddSupplier1.SelectedItem.Value = 117 Then
                    .isDBM = True
                    AddTrace("isDBM set to True.")
                Else
                    .isDBM = False
                    AddTrace("isDBM set to False.")
                End If
            End With

            AddTrace("Checking if gvIncomingPR.SelectedDataKey('isRecanvass') is True. Value: " & gvIncomingPR.SelectedDataKey("isRecanvass").ToString())
            '============= CHECK IF RECANVASS ================
            Dim Hdr_ID As Long
            If gvIncomingPR.SelectedDataKey("isRecanvass") = True Then
                AddTrace("Condition met: isRecanvass = True.")
                AddTrace("Executing SQL: SELECT Hdr_ID FROM AMS.m_Canvass_Hdr_Limited ... AND isReCanvass = 1")
                Hdr_ID = objDerived.GetValue("SELECT Hdr_ID FROM AMS.m_Canvass_Hdr_Limited WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "' AND isDBM = 0 AND isReCanvass = 1", CommandType.Text)
                AddTrace("SQL result for Hdr_ID=" & Hdr_ID.ToString())
                If Hdr_ID = 0 Then
                    AddTrace("Hdr_ID = 0, calling cnvss_hdr.save().")
                    Session("Hdr_ID") = cnvss_hdr.save()
                    AddTrace("Session('Hdr_ID') set to " & Session("Hdr_ID"))
                    AddTrace("Executing SQL to update AMS.m_Canvass_Hdr_Limited SET isReCanvass = 1 ...")
                    objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr_Limited SET isReCanvass = 1 WHERE Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)
                Else
                    AddTrace("Hdr_ID <> 0, so Session('Hdr_ID') = existing value " & Hdr_ID)
                    Session("Hdr_ID") = Hdr_ID
                End If
            Else
                AddTrace("Condition NOT met: isRecanvass = False.")
                AddTrace("Executing SQL: SELECT Hdr_ID FROM AMS.m_Canvass_Hdr_Limited ... AND isReCanvass = 0")
                Hdr_ID = objDerived.GetValue("SELECT Hdr_ID FROM AMS.m_Canvass_Hdr_Limited WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "' AND isDBM = 0 AND isReCanvass = 0", CommandType.Text)
                AddTrace("SQL result for Hdr_ID=" & Hdr_ID.ToString())
                If Hdr_ID = 0 Then
                    AddTrace("Hdr_ID = 0, calling cnvss_hdr.save().")
                    Session("Hdr_ID") = cnvss_hdr.save()
                    AddTrace("Session('Hdr_ID') set to " & Session("Hdr_ID"))
                    ' REMOVE THIS LINE: Session("Hdr_ID") = Hdr_ID
                Else
                    AddTrace("Hdr_ID <> 0, so Session('Hdr_ID') = existing value " & Hdr_ID)
                    Session("Hdr_ID") = Hdr_ID
                End If
            End If

            AddTrace("Checking if ddSupplier1.SelectedItem.Text <> 'PS-DBM'. Actual text: " & ddSupplier1.SelectedItem.Text)
            If ddSupplier1.SelectedItem.Text <> "PS-DBM" Then 'REGULAR SUPPLIER/ BIDDER
                AddTrace("Condition met: REGULAR SUPPLIER. Proceeding to save data in AMS.m_Canvass_Dtl1_Limited and AMS.m_Canvass_Dtl2.")
                '=-= SAVE CANVASS List of Items in PR "AMS.m_Canvass_Dtl1" 
                AddTrace("Executing SQL: SELECT * FROM AMS.m_Canvass_Dtl1_Limited WHERE Hdr_ID = '" & Session("Hdr_ID") & "'")
                Dim dtl1 As New DataTable
                dtl1 = objDerived.GetDataTable("SELECT * FROM AMS.m_Canvass_Dtl1_Limited WHERE Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)
                AddTrace("dtl1.Rows.Count=" & dtl1.Rows.Count)

                If dtl1.Rows.Count = 0 Then
                    AddTrace("No existing rows in AMS.m_Canvass_Dtl1_Limited for this Hdr_ID. Inserting new records.")
                    For i As Integer = 0 To grdPerItems.Rows.Count - 1
                        cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                        AddTrace("Row " & i.ToString() & ", cb.Checked=" & cb.Checked.ToString())
                        If cb.Checked = True Then
                            AddTrace("Saving item with Item_ID=" & pPurchase_Order_detail.Rows(i)("Item_ID").ToString())
                            With cnvss_dtl1
                                .Hdr_ID = Session("Hdr_ID")
                                .Item_ID = pPurchase_Order_detail.Rows(i)("Item_ID")
                                .save()
                            End With
                        End If
                    Next
                Else
                    AddTrace("Existing rows found in AMS.m_Canvass_Dtl1_Limited for this Hdr_ID. Skipping insert.")
                End If

                AddTrace("Saving list of Bidders in AMS.m_Canvass_Dtl2.")
                '=-= SAVE CANVASS List of Bidders "AMS.m_Canvass_Dtl2"
                For i As Integer = 0 To grdPerItems.Rows.Count - 1
                    cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If cb.Checked = True Then
                        AddTrace("Row " & i.ToString() & " is checked. Retrieving Dtl_ID1 for Item_ID=" & pPurchase_Order_detail.Rows(i)("Item_ID").ToString())
                        Dim Dtl_ID1 As Long = objDerived.GetValue("SELECT * FROM AMS.m_Canvass_Dtl1_Limited WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND Item_ID = '" & pPurchase_Order_detail.Rows(i)("Item_ID") & "'", CommandType.Text)
                        AddTrace("Retrieved Dtl_ID1=" & Dtl_ID1)

                        Dim CanvassPrice As Decimal = CType(CType(grdPerItems.Rows(i).FindControl("txtCost1"), TextBox).Text, Decimal)
                        Dim CanvassQty As Decimal = CType(CType(grdPerItems.Rows(i).FindControl("txtqty"), TextBox).Text, Decimal)
                        AddTrace("CanvassPrice=" & CanvassPrice & ", CanvassQty=" & CanvassQty)

                        AddTrace("Executing SQL: SELECT * FROM [dbo].[View_CanvassItem_Check_Limited] WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND Item_ID = '" & pPurchase_Order_detail.Rows(i)("Item_ID") & "' AND Supplier_ID = '" & ddSupplier1.SelectedItem.Value & "'")
                        Dim dtl2 As New DataTable
                        dtl2 = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassItem_Check_Limited] WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND Item_ID = '" & pPurchase_Order_detail.Rows(i)("Item_ID") & "' AND Supplier_ID = '" & ddSupplier1.SelectedItem.Value & "'", CommandType.Text)
                        AddTrace("dtl2.Rows.Count=" & dtl2.Rows.Count)

                        If dtl2.Rows.Count = 0 Then
                            AddTrace("No existing record in m_Canvass_Dtl2 for this bidder. Inserting new.")
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
                            AddTrace("Existing record found in m_Canvass_Dtl2 for this bidder. Updating record with Dtl_ID2=" & dtl2.Rows(0)("Dtl_ID2").ToString())
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
                AddTrace("Condition met: ddSupplier1.SelectedItem.Text = 'PS-DBM'. Marking record as Approved and saving PR details.")
                AddTrace("Executing SQL: UPDATE AMS.m_Canvass_Hdr_Limited SET isApproved = 1, DateApproved = '" & txtdate.Text & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "'")
                objDerived.Execute("UPDATE AMS.m_Canvass_Hdr_Limited SET isApproved = 1, DateApproved = '" & txtdate.Text & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)

                AddTrace("Saving detail in AMS.m_Canvass_Dtl_PR1.")
                '=-= SAVE DETAIL "AMS.m_Canvass_Dtl_PR1" 
                With cnvss_PR1
                    .Dtl_ID_PR1 = 0
                    .Hdr_ID = Session("Hdr_ID")
                    .Supplier_ID = ddSupplier1.SelectedItem.Value

                    AddTrace("Checking if ddSupplier1.SelectedItem.Value=117 => isWinner. Actual value: " & ddSupplier1.SelectedItem.Value)
                    If ddSupplier1.SelectedItem.Value = 117 Then
                        .isWinner = True
                        AddTrace("isWinner = True")
                    Else
                        .isWinner = False
                        AddTrace("isWinner = False")
                    End If
                End With

                Dim Dtl_ID_PR1 As Long = cnvss_PR1.save()
                AddTrace("Dtl_ID_PR1 saved: " & Dtl_ID_PR1)
                Session("Dtl_ID_PR1") = Dtl_ID_PR1

                AddTrace("Executing SQL: UPDATE AMS.m_Canvass_Dtl_PR1 SET withPO = 0 WHERE Dtl_ID_PR1 = '" & Session("Dtl_ID_PR1") & "'")
                objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl_PR1 SET withPO = 0 WHERE Dtl_ID_PR1 = '" & Session("Dtl_ID_PR1") & "'", CommandType.Text)

                AddTrace("Saving detail in AMS.m_Canvass_Dtl_PR2.")
                '=-= SAVE DETAIL "AMS.m_Canvass_Dtl_PR2" 
                For i As Integer = 0 To grdPerItems.Rows.Count - 1
                    cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If cb.Checked = True Then
                        Dim CanvassPrice As Decimal = CType(CType(grdPerItems.Rows(i).FindControl("txtCost1"), TextBox).Text, Decimal)
                        Dim CanvassQty As Decimal = CType(CType(grdPerItems.Rows(i).FindControl("txtqty"), TextBox).Text, Decimal)
                        AddTrace("Row " & i.ToString() & " is checked. Will save to AMS.m_Canvass_Dtl_PR2. Price=" & CanvassPrice & ", Qty=" & CanvassQty & ", Item_ID=" & pPurchase_Order_detail.Rows(i)("Item_ID").ToString())

                        With cnvss_PR2
                            .Dtl_ID_PR2 = 0
                            .Dtl_ID_PR1 = Session("Dtl_ID_PR1")
                            .Item_ID = pPurchase_Order_detail.Rows(i)("Item_ID")
                            .UnitPrice = CanvassPrice
                            .Quantity = CanvassQty

                            If CanvassPrice <> 0 And CanvassQty <> 0 Then
                                .save()
                                AddTrace("Record saved to AMS.m_Canvass_Dtl_PR2.")
                            Else
                                AddTrace("Skipping save because CanvassPrice=0 or CanvassQty=0.")
                            End If
                        End With
                    End If
                Next
            End If

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been successfully saved.")
            AddTrace("Transaction saved successfully. Reloading ddSupplier1 and clearing selection.")

            ddSupplier1.DataSource = objDerived.GetDataTable("Select * from dbo.Supplier order by SuppName", CommandType.Text)
            ddSupplier1.DataTextField = ("SuppName")
            ddSupplier1.DataValueField = ("Supplier_Id")
            ddSupplier1.DataBind()
            ddSupplier1.Items.Insert(0, "Select")

            'grdPerItems.Columns(0).Visible = False

            LoadrbChoice()
            AddTrace("End of btnSave1_Click function. Exiting Try block.")

        Catch ex As Exception
            AddTrace("Exception caught: " & ex.Message)
        End Try

    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
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

        Try
            'Dim x As Decimal
            'For i As Integer = 0 To grdPerItems.Rows.Count - 1
            '    cb = CType(Me.grdPerItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            '    If cb.Checked = True Then
            '        Dim txtcost As TextBox = CType(grdPerItems.Rows(i).FindControl("txtcost1"), TextBox)
            '        Dim txtqty As TextBox = CType(grdPerItems.Rows(i).FindControl("txtqty"), TextBox)

            '        Dim Tcost As Decimal = FormatNumber(txtcost.Text * txtqty.Text, 2)

            '        CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = Tcost
            '        x = x + (txtcost.Text * txtqty.Text)
            '    Else
            '        CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = "0.00"
            '    End If
            'Next

            'CType(grdPerItems.FooterRow.Cells(4).FindControl("lblTotalAmount1"), Label).Text = FormatNumber(x, 2)


            '-------------Optimize
            ' Initialize the total cost variable
            Dim totalCost As Decimal = 0D

            ' Iterate through each row in the GridView
            For i As Integer = 0 To grdPerItems.Rows.Count - 1
                ' Retrieve the checkbox control
                Dim cb As CheckBox = CType(grdPerItems.Rows(i).FindControl("CheckBox1"), CheckBox)

                ' Process only if the checkbox is checked
                If cb IsNot Nothing AndAlso cb.Checked Then
                    ' Safely retrieve and convert cost and quantity values from TextBoxes
                    Dim txtCost As TextBox = CType(grdPerItems.Rows(i).FindControl("txtcost1"), TextBox)
                    Dim cost As Decimal = If(Not String.IsNullOrEmpty(txtCost.Text), Convert.ToDecimal(txtCost.Text), 0D)

                    Dim txtQty As TextBox = CType(grdPerItems.Rows(i).FindControl("txtqty"), TextBox)
                    Dim quantity As Decimal = If(Not String.IsNullOrEmpty(txtQty.Text), Convert.ToDecimal(txtQty.Text), 0D)

                    ' Calculate total cost for the current row
                    Dim itemTotalCost As Decimal = cost * quantity

                    ' Set the total cost for the current row in its corresponding TextBox
                    CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = FormatNumber(itemTotalCost, 2)

                    ' Accumulate the total cost for all items
                    totalCost += itemTotalCost
                Else
                    ' Set the row's total cost to 0.00 if checkbox is unchecked
                    CType(grdPerItems.Rows(i).FindControl("txtTotal1"), TextBox).Text = "0.00"
                End If
            Next

            ' Display the accumulated total cost in the footer row, if it exists
            If grdPerItems.FooterRow IsNot Nothing Then
                CType(grdPerItems.FooterRow.Cells(4).FindControl("lblTotalAmount1"), Label).Text = FormatNumber(totalCost, 2)
            End If
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub lnkviewItems_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "view"
    End Sub
    Protected Sub linkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "delete"
    End Sub
    Protected Sub grdSupplier1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ' Trace the values of the selected keys
            AddTrace("Selected Supplier ID: " & grdSupplier1.SelectedDataKey("Supplier_ID"))
            AddTrace("Selected PR Hdr ID: " & gvIncomingPR.SelectedDataKey("prhdr_id"))

            If Lbtn = "view" Then
                AddTrace("Lbtn is 'view'")

                dtItemList = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassBidder_ItemList_Limited] '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "','" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                AddTrace("Fetched dtItemList: " & dtItemList.Rows.Count & " rows")

                grdItemList.DataSource = dtItemList
                grdItemList.DataBind()

                ModalPopupExtendepopup.Show()

            ElseIf Lbtn = "delete" Then
                AddTrace("Lbtn is 'delete'")

                Try
                    If grdSupplier1.SelectedDataKey("Supplier_ID") = 117 Then
                        '================ DEPARTMENT OF BUDGET AND MANAGEMENT
                        AddTrace("Selected Supplier ID is DBM (117)")

                        Dim dt As New DataTable
                        dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassSuppList] WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        AddTrace("Fetched dt from View_CanvassSuppList: " & dt.Rows.Count & " rows")

                        If dt.Rows.Count <> 0 Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Remove other supplier before removing DBM from the list.")
                            AddTrace("Cannot remove DBM. Other suppliers exist.")
                        Else
                            '================ DELETE IN CANVASS HEADER
                            Dim dtDBM As New DataTable
                            dtDBM = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassDBMList] WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                            AddTrace("Fetched dtDBM from View_CanvassDBMList: " & dtDBM.Rows.Count & " rows")

                            objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Hdr_Limited WHERE Hdr_ID = '" & dtDBM.Rows(0)("Hdr_ID") & "'", CommandType.Text)

                            '================ DELETE IN CANVASS DETAIL 2
                            Dim ID As Integer
                            ID = objDerived.GetValue("SELECT Dtl_ID_PR1 FROM AMS.m_Canvass_Dtl_PR1 WHERE Hdr_ID = '" & dtDBM.Rows(0)("Hdr_ID") & "'", CommandType.Text)
                            AddTrace("Fetched Dtl_ID_PR1: " & ID)

                            objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl_PR2 WHERE Dtl_ID_PR1 = '" & ID & "'", CommandType.Text)

                            '================ DELETE IN CANVASS DETAIL 1
                            objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl_PR1 WHERE Hdr_ID = '" & dtDBM.Rows(0)("Hdr_ID") & "'", CommandType.Text)

                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "DBM has been successfully removed from the list.")
                            AddTrace("DBM successfully removed from the list.")
                        End If

                    Else
                        '================ OTHER SUPPLIERS
                        AddTrace("Other Supplier removal process")

                        Dim dt As New DataTable
                        dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassSuppList] WHERE Supplier_ID = '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "' AND PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        AddTrace("Fetched dt from View_CanvassSuppList: " & dt.Rows.Count & " rows")

                        For i As Integer = 0 To dt.Rows.Count - 1
                            objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl2 WHERE Dtl_ID2 = '" & dt.Rows(i)("Dtl_ID2") & "'", CommandType.Text)
                            AddTrace("Deleted Dtl_ID2: " & dt.Rows(i)("Dtl_ID2"))
                        Next

                        '================ IF ALL SUPPLIER HAS BEEN REMOVED, DELETE CANVASS HEADER
                        Dim dt2 As New DataTable
                        dt2 = objDerived.GetDataTable("SELECT * FROM [dbo].[View_CanvassSuppList] WHERE PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        AddTrace("Fetched dt2 from View_CanvassSuppList: " & dt2.Rows.Count & " rows")

                        If dt2.Rows.Count = 0 Then
                            Dim Hdr_ID As Integer
                            Hdr_ID = objDerived.GetValue("SELECT Hdr_ID FROM AMS.m_Canvass_Hdr_Limited WHERE isDBM = 0 AND PR_Hdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                            AddTrace("Fetched Hdr_ID: " & Hdr_ID)

                            objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Dtl1 WHERE Hdr_ID = '" & Hdr_ID & "'", CommandType.Text)
                            objDerived.GetRecords("DELETE FROM AMS.m_Canvass_Hdr_Limited WHERE Hdr_ID = '" & Hdr_ID & "'", CommandType.Text)

                            AddTrace("Canvass Header and Detail successfully deleted.")
                        End If

                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Supplier has been successfully removed from the list.")
                    End If

                Catch ex As Exception
                    AddTrace("Error during 'delete' operation: " & ex.Message)
                End Try
            End If

            LoadrbChoice()
        Catch ex As Exception
            AddTrace("Error during grdSupplier1_SelectedIndexChanged: " & ex.Message)
        End Try
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
            Dim DTL_ID2 As Integer = objDerived.GetValue("SELECT Dtl_ID2 FROM [dbo].[View_EditCanvassPrice_Limited] WHERE PR_Hdr_ID = '" & Session("prhdr_id") & "' AND Supplier_ID = '" & grdSupplier1.SelectedDataKey("Supplier_ID") & "' AND Item_ID = '" & ItemID & "'", CommandType.Text)

            objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2_Limited SET UnitPrice = '" & Cost & "' WHERE Dtl_ID2 = '" & DTL_ID2 & "'", CommandType.Text)
        Next

        LoadrbChoice()
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "All canvass unit price has been successfully updated.")

    End Sub
    Protected Sub drpModeOfProcurement_SelectedIndexChanged(sender As Object, e As EventArgs)
        'pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassList_Search_DD] '" & Session("RoleName") & "','" & drpModeOfProcurement.SelectedItem.Value & "'", CommandType.Text)
        'If pShopping.Rows.Count < 8 Then
        '    pShopping.Merge(createdatatable(8 - pShopping.Rows.Count))
        'End If
        'gvIncomingPR.DataSource = pShopping
        'gvIncomingPR.DataBind()
    End Sub

End Class
