Imports System.Data
Partial Class procurement_t_Inspection_Acceptance
    Inherits System.Web.UI.Page
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal
    Private pojectdetail As New ProjectDtl
    Dim obj As New AccessRule
    Dim myview As DataView
    Dim total As Decimal = 0
    Dim ImageDocument As New ImageDocument
    Private supplies As New t_supplies_hdr
    Public dinNo As String
    Dim rcv As New Receiving.t_receiving
    Dim rcv_dtl As New Receiving.t_receiving_dtl
    Private objMotorInfo As New ConsolidatedPropertySaving.TbMotor_Info
    Private objMotorDtl As New ConsolidatedPropertySaving.TbMotor_Dtl
#Region "BaseDAL"
    Dim AIR_Hdr As New t_inspection_and_acceptance_hdr
    Dim AIR_Dtl As New t_inspection_and_acceptance_dtl

    '=-= CAPITAL OUTLAY
    Dim Prop_Ledger As New t_PropertyLedger
    Dim Prop_Hdr As New t_property_hdr
    Dim Prop_Dtl As New t_property_dtl

    Dim LandDtl As New ConsolidatedPropertySaving.TBLand_Details
    Dim LandTech As New ConsolidatedPropertySaving.TB_Landdescription
    Dim LandDocument As New ConsolidatedPropertySaving.TbLand_LandDocu
    Dim LandOwner As New ConsolidatedPropertySaving.TbLand_OwnerHistory
    Dim LandValuation As New ConsolidatedPropertySaving.TbLand_Valuation
    Dim LandImprovement As New ConsolidatedPropertySaving.TbLand_Improvements
    Dim LandPropHis As New ConsolidatedPropertySaving.TbLand_PropertyHistory

    Dim BldgInfo As New ConsolidatedPropertySaving.TBBuilding_Details

    Dim EquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info
    Dim EquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details

    Dim FurnitureInfo As New ConsolidatedPropertySaving.TbFurniture_Info
    Dim FurnitureDtl As New ConsolidatedPropertySaving.TbFurniture_Dtl

    Dim MachineInfo As New ConsolidatedPropertySaving.TbMachinery_Information
    Dim MachineDtl As New ConsolidatedPropertySaving.TbMachinery_Dtl

    Dim MotorInfo As New ConsolidatedPropertySaving.TbMotor_Info
    Dim MotorDtl As New ConsolidatedPropertySaving.TbMotor_Dtl

    Dim AmbulanceInfo As New ConsolidatedPropertySaving.TbAmbulance_Info
    Dim AmbulanceDtl As New ConsolidatedPropertySaving.TbAmbulance_Dtl

    Dim PropSerial As New ConsolidatedPropertySaving.PropSerial

    '=-= SUPPLIES
    Dim Stock_Ledger As New t_StockLedger
    Dim Stock As New Supplies_Stock

    Dim OfficeSup As New SupplieINFO

    Dim MedDtl As New ConsolidatedMedicineSaving.TBMedicine_DTl
    Dim MedInfo As New ConsolidatedMedicineSaving.TBMedicine_Info

    Dim Blood As New ConsolidatedMedicineSaving.TbBlood
    Dim NonFood As New ConsolidatedMedicineSaving.TbNonFood
    Dim Food As New ConsolidatedMedicineSaving.TbFood
    Dim Water As New ConsolidatedMedicineSaving.TbWater
#End Region
#Region "property"
    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property

    Private Property AllotmentClass() As Integer
        Get
            Return CType(Session("AllotmentClass"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("AllotmentClass") = value
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

    Private Property pInspection_detail() As DataTable
        Get
            Return CType(Session("pInspection_detail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pInspection_detail") = value
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

    Private Property pItemForSerial() As DataTable
        Get
            Return CType(Session("pItemForSerial"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItemForSerial") = value
        End Set
    End Property

    Private Property DefaultId() As Integer
        Get
            Return CType(Session("DefaultId"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("DefaultId") = value
        End Set
    End Property
#End Region
#Region "Tables"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("pr_no", GetType(String))
        'dt.Columns.Add("ReqDept", GetType(String))
        'dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("ProjectName", GetType(String))
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("PO_Date", GetType(Date))
        dt.Columns.Add("ContractPrice", GetType(Decimal))
        dt.Columns.Add("dvno", GetType(String))
        dt.Columns.Add("checkno", GetType(String))
        dt.Columns.Add("amountpaid", GetType(String))
        dt.Columns.Add("jevno", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            'dr("pr_no") = DBNull.Value
            'dr("ReqDept") = DBNull.Value
            'dr("OBR_No") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("ProjectName") = DBNull.Value
            dr("PO_No") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("ContractPrice") = DBNull.Value
            dr("dvno") = DBNull.Value
            dr("checkno") = DBNull.Value
            dr("amountpaid") = DBNull.Value
            dr("jevno") = DBNull.Value
            dr("POHdr_ID") = 0
            dr("GA_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function CreateTable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Qty", GetType(Decimal))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("cost") = DBNull.Value
            dr("MarketValue") = DBNull.Value
            dr("Condition") = DBNull.Value
            dr("Location") = DBNull.Value
            dr("Status") = DBNull.Value
            dr("POHdr_ID") = 0
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function CreateTable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Qty_Received", GetType(Decimal))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Status1", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("Received_Date", GetType(Date))
        dt.Columns.Add("isAccepted", GetType(Boolean))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Qty_Received") = DBNull.Value
            dr("cost") = DBNull.Value
            dr("MarketValue") = DBNull.Value
            dr("Condition") = DBNull.Value
            dr("Location") = DBNull.Value
            dr("Status1") = DBNull.Value
            dr("POHdr_ID") = 0
            dr("Received_Date") = DBNull.Value
            dr("isAccepted") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function CreateTable4(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("no", GetType(Integer))
        dt.Columns.Add("barcode")
        For i As Integer = 1 To row
            dr = dt.NewRow
            dr("no") = i
            dr("barcode") = ""
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If

        If Not Page.IsPostBack Then
            '====== DEFAULT VIEW ======
            ddSearch.SelectedIndex = 0
            'rbALL.SelectedIndex = 0
            '===========================
            LoadSearchBy()

            grdItems.DataSource = CreateTable2(5)
            grdItems.DataBind()

            grdInspection.DataSource = CreateTable3(5)
            grdInspection.DataBind()

            txtPO.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchPO.ClientID & "')")

        End If


    End Sub
    Protected Sub ddSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        rbALL.SelectedIndex = -1
        LoadSearchBy()
    End Sub
    Protected Sub rbALL_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtInvoiceNumber.Text = ""
        txtRemarks.Text = ""

        grdItems.DataSource = CreateTable2(5)
        grdItems.DataBind()

        grdInspection.DataSource = CreateTable3(5)
        grdInspection.DataBind()

        tb_1Dept.Visible = False
        tb_2Dept.Visible = False

        Dim myview As DataView
        myview = pPurchase_Order.DefaultView
        myview.RowFilter = "AllotmentClass_ID = '" & rbALL.SelectedItem.Value & "'"
        grdAIR.DataSource = myview
        grdAIR.DataBind()
        grdAIR.SelectedIndex = -1

    End Sub
    Protected Sub LoadSearchBy()
        If ddSearch.SelectedItem.Value = 1 Then
            '=-= ALL
            Me.mvSearch.SetActiveView(Me.vwALL)
            rbALL.Visible = True
            LoadrbALL()

            Session("Page") = "ALL"

        ElseIf ddSearch.SelectedItem.Value = 2 Then
            '=-= ACCOUNT CODE
            Me.mvSearch.SetActiveView(Me.vwAccount)
            ddAccount.DataSource = objDerived.GetDataTable("SELECT DISTINCT GA_ID, GA_Title FROM AMS.View_AccountList", CommandType.Text)
            ddAccount.DataTextField = ("GA_Title")
            ddAccount.DataValueField = ("GA_ID")
            ddAccount.DataBind()
            ddAccount.Items.Insert(0, "Select")

            Session("Page") = "AccountCode"

        ElseIf ddSearch.SelectedItem.Value = 3 Then
            '=-= PO NUMBER
            Me.mvSearch.SetActiveView(Me.vwPO)
            Session("Page") = "PO"

        ElseIf ddSearch.SelectedItem.Value = 4 Then
            '=-= SUPPLIER
            Me.mvSearch.SetActiveView(Me.vwSupp)

            ddSupplier.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
            ddSupplier.DataTextField = ("SuppName")
            ddSupplier.DataValueField = ("Supplier_Id")
            ddSupplier.DataBind()
            ddSupplier.Items.Insert(0, "Select")

            Session("Page") = "SUPPLIER"

        End If
    End Sub
    Protected Sub LoadrbALL()
        'pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List] '" & rbALL.SelectedItem.Value & "'", CommandType.Text)
        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List]", CommandType.Text)
        If pPurchase_Order.Rows.Count < 5 Then
            pPurchase_Order.Merge(CreateTable1(5 - pPurchase_Order.Rows.Count))
        End If
        grdAIR.DataSource = pPurchase_Order
        grdAIR.DataBind()
        grdAIR.SelectedIndex = -1

    End Sub
    Protected Sub grdAIR_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdAIR.DataSource = pPurchase_Order
        grdAIR.PageIndex = e.NewPageIndex
        grdAIR.DataBind()

        'Dim myview As DataView
        'myview = pPurchase_Order.DefaultView

        'If Session("Page") = "ALL" Then
        '    pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List]", CommandType.Text)
        '    If pPurchase_Order.Rows.Count < 5 Then
        '        pPurchase_Order.Merge(CreateTable1(5 - pPurchase_Order.Rows.Count))
        '    End If
        '    grdAIR.DataSource = pPurchase_Order
        '    grdAIR.DataBind()

        'ElseIf Session("Page") = "PO" Then
        '    myview.RowFilter = "PO_No like '%" & txtPO.Text & "%'"
        '    grdAIR.DataSource = myview
        '    grdAIR.DataBind()

        'ElseIf Session("Page") = "SUPPLIER" Then
        '    myview.RowFilter = "Supplier_ID = '" & ddSupplier.SelectedItem.Value & "'"
        '    grdAIR.DataSource = myview
        '    grdAIR.DataBind()

        'End If




        'If Session("Page") = "ALL" Then
        '    pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List] '" & rbALL.SelectedItem.Value & "'", CommandType.Text)
        '    If pPurchase_Order.Rows.Count < 5 Then
        '        pPurchase_Order.Merge(CreateTable1(5 - pPurchase_Order.Rows.Count))
        '    End If
        '    grdAIR.PageIndex = e.NewPageIndex
        '    grdAIR.DataSource = pPurchase_Order
        '    grdAIR.DataBind()

        'ElseIf Session("Page") = "PO" Then
        '    pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List_ByPO] '" & txtPO.Text & "'", CommandType.Text)
        '    If pPurchase_Order.Rows.Count < 5 Then
        '        pPurchase_Order.Merge(CreateTable1(5 - pPurchase_Order.Rows.Count))
        '    End If
        '    grdAIR.PageIndex = e.NewPageIndex
        '    grdAIR.DataSource = pPurchase_Order
        '    grdAIR.DataBind()

        'ElseIf Session("Page") = "SUPPLIER" Then
        '    pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List_BySupplier] '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
        '    If pPurchase_Order.Rows.Count < 5 Then
        '        pPurchase_Order.Merge(CreateTable1(5 - pPurchase_Order.Rows.Count))
        '    End If
        '    grdAIR.PageIndex = e.NewPageIndex
        '    grdAIR.DataSource = pPurchase_Order
        '    grdAIR.DataBind()

        'End If

        'pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List]", CommandType.Text)
        'If pPurchase_Order.Rows.Count < 5 Then
        '    pPurchase_Order.Merge(CreateTable1(5 - pPurchase_Order.Rows.Count))
        'End If
        'grdAIR.PageIndex = e.NewPageIndex
        'grdAIR.DataSource = pPurchase_Order
        'grdAIR.DataBind()

    End Sub
    Protected Sub grdAIR_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdAIR, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Sub ClearTextBoxes(ParamArray textBoxes() As TextBox)
        For Each textBox As TextBox In textBoxes
            textBox.Text = String.Empty
        Next
    End Sub

    'Protected Sub grdItems_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
    '    If (e.Row.RowType = DataControlRowType.DataRow) Then
    '        e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
    '        e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
    '        e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdItems, "Select$" + e.Row.RowIndex.ToString()))
    '    End If
    'End Sub
    Protected Sub grdAIR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If grdAIR.SelectedDataKey("POHdr_ID") = 0 Then
            ClearTextBoxes(txtSuppName, txtPONumber, txtPODate, txtInvoiceDate, txtReceiveDate, txtAcceptDate)
            grdItems.DataSource = CreateTable2(5)
            grdItems.DataBind()

            grdInspection.DataSource = CreateTable3(5)
            grdInspection.DataBind()

            ddReceiveBy.Items.Clear()
            ddInspectedBy.Items.Clear()
            ddAcceptedBy.Items.Clear()

            btnRcvSave.Enabled = False
            btnRcvPreview.Enabled = False

            tb_1Dept.Visible = False
            tb_2Dept.Visible = False

        Else
            btnRcvSave.Enabled = True
            btnRcvPreview.Enabled = False
            btnReturn.Enabled = True
            btnNoIAR.Enabled = True

            txtSuppName.Text = grdAIR.SelectedDataKey("SuppName")
            txtPONumber.Text = grdAIR.SelectedDataKey("PO_No")
            txtPODate.Text = CType(grdAIR.SelectedDataKey("PO_Date"), Date).ToString("MM/dd/yyyy")

            txtInvoiceDate.Text = CType(grdAIR.SelectedDataKey("PO_Date"), Date).ToString("MM/dd/yyyy")
            txtReceiveDate.Text = Date.Today.ToString("MM/dd/yyyy")
            txtAcceptDate.Text = Date.Today.ToString("MM/dd/yyyy")

            If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                tb_1Dept.Visible = False
                tb_2Dept.Visible = True
            Else
                tb_1Dept.Visible = True
                tb_2Dept.Visible = False
            End If

            AllotmentClass = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)


            LoadAllItems() '=-= LOAD ITEMS



            Dim Rcv As New DataTable
            Rcv = objDerived.GetDataTable("Select * from HRMS.view_signatory where deptid = 7 and division_key = 86", CommandType.Text)
            ddReceiveBy.DataSource = Rcv
            ddReceiveBy.DataTextField = ("full_name")
            ddReceiveBy.DataValueField = ("Signatory_ID")
            ddReceiveBy.DataBind()
            ddReceiveBy.Items.Insert(0, "Select")

            Dim ins As New DataTable
            ins = objDerived.GetDataTable("Select DISTINCT * from HRMS.view_signatory where isInspector = 1 ORDER BY full_name", CommandType.Text)
            ddInspectedBy.DataSource = ins
            ddInspectedBy.DataTextField = ("full_name")
            ddInspectedBy.DataValueField = ("empid")
            ddInspectedBy.DataBind()
            ddInspectedBy.Items.Insert(0, "Select")

            ddInspectedBy2.DataSource = ins
            ddInspectedBy2.DataTextField = ("full_name")
            ddInspectedBy2.DataValueField = ("empid")
            ddInspectedBy2.DataBind()
            ddInspectedBy2.Items.Insert(0, "Select")

            ddInspectedBy3.DataSource = ins
            ddInspectedBy3.DataTextField = ("full_name")
            ddInspectedBy3.DataValueField = ("empid")
            ddInspectedBy3.DataBind()
            ddInspectedBy3.Items.Insert(0, "Select")

            Dim accpt As New DataTable
            accpt = objDerived.GetDataTable("Select * from HRMS.view_signatory where deptid = 7 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            ddAcceptedBy.DataSource = accpt
            ddAcceptedBy.DataTextField = ("full_name")
            ddAcceptedBy.DataValueField = ("Signatory_ID")
            ddAcceptedBy.DataBind()
            'ddAcceptedBy.Items.Insert(0, "Select")

            Dim AllotmentClass_ID As Long
            AllotmentClass_ID = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

            If AllotmentClass_ID = 2 Then
                LoadMOOE()

            ElseIf AllotmentClass_ID = 3 Then
                LoadPPE()
            End If


        End If
    End Sub
    Protected Sub LoadAllItems()
        '=-= CHECKING ITEMS
        Dim rcv1 As Long = 0
        rcv1 = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

        pPurchase_Order_detail = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_Items] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & rcv1 & "','" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

        If pPurchase_Order_detail.Rows.Count < 1 Then
            rbStatus.Items.Item(1).Enabled = True
        Else
            rbStatus.Items.Item(1).Enabled = False
        End If

        If pPurchase_Order_detail.Rows.Count < 5 Then
            pPurchase_Order_detail.Merge(CreateTable2(5 - pPurchase_Order_detail.Rows.Count))
        End If
        grdItems.DataSource = pPurchase_Order_detail
        grdItems.DataBind()

        Dim stck1 As Long = 0
        If AllotmentClass = 2 Then
            stck1 = objDerived.GetValue("SELECT StockID FROM AMS.Stock WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        ElseIf AllotmentClass = 3 Then
            stck1 = objDerived.GetValue("SELECT Property_ID FROM AMS.Property WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        End If

        pInspection_detail = objDerived.GetDataTable("EXEC [AMS].[sp_ReceivedItems] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & stck1 & "','" & AllotmentClass & "'", CommandType.Text)
        txtHiddenReceiveQty.Value = pInspection_detail.Rows.Count

        If txtHiddenReceiveQty.Value > 0 Then
            btnReturn.Enabled = False
        Else

            btnReturn.Enabled = True
        End If

        If pInspection_detail.Rows.Count < 5 Then
            pInspection_detail.Merge(CreateTable3(5 - pInspection_detail.Rows.Count))
        End If


        grdInspection.DataSource = pInspection_detail
        grdInspection.DataBind()

        ''here 1
        'Try
        '    If pInspection_detail.Rows.Count > 0 Then
        '        Dim a As Double = 0
        '        For i As Integer = 0 To pInspection_detail.Rows.Count - 1
        '            Dim b As String = CType(CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox).Text, String)
        '            a = a + Val(b)
        '        Next
        '        txtHidenQTY.Value = a
        '    Else


        '    End If
        'Catch ex As Exception

        'End Try

    End Sub
    Protected Sub LoadMOOE()
        If grdAIR.SelectedDataKey("GA_ID") = 1427 Then
            '=-= OFFICE SUPPLIES
            Me.mvAccounts.SetActiveView(Me.vwOfficeSupplies)

        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1432 Or grdAIR.SelectedDataKey("GA_ID") = 1433 Then
            '=-= MEDICINES SUPPLIES AND MEDICAL SUPPLIES
            Me.mvAccounts.SetActiveView(Me.vwOtherSupplies)

        Else '=-= OTHER SUPPLIES / MEDICINES SUPPLIES AND MEDICAL SUPPLIES
            Me.mvAccounts.SetActiveView(Me.vwOtherSupplies)

        End If
    End Sub
    Protected Sub LoadPPE()
        If grdAIR.SelectedDataKey("GA_ID") = 1060 Or grdAIR.SelectedDataKey("GA_ID") = 1067 Then
            '=-= LAND
            Me.mvAccounts.SetActiveView(Me.vwLand)

        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1082 Or grdAIR.SelectedDataKey("GA_ID") = 1085 Then
            '=-= BUILDINGS  vwBuilding
            Me.mvAccounts.SetActiveView(Me.vwBuilding)

        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1118 Then
            '=-= FURNITURE AND FIXTURES
            Me.mvAccounts.SetActiveView(Me.vwEquipments)

        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1127 Then
            '=-= MACHINIRIES
            Me.mvAccounts.SetActiveView(Me.vwEquipments)

        ElseIf grdAIR.SelectedDataKey("GA_ID") = 1166 Then
            '=-= TRANSPORTATION
            Me.mvAccounts.SetActiveView(Me.vwMotors)

        Else '=-= ALL EQUIPMENTS
            Me.mvAccounts.SetActiveView(Me.vwEquipments)

        End If
    End Sub
    Protected Sub grdItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdItems.SelectedIndexChanged
        Session("origQty") = grdItems.SelectedDataKey("Qty")
    End Sub
    Protected Sub btnRcvSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)


        If txtTraps.Value = "Yes" Then
            Try
                Dim cb As CheckBox
                Session("cb") = 0

                For i As Integer = 0 To grdItems.Rows.Count - 1
                    cb = CType(Me.grdItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If cb.Checked = True Then
                        Session("cb") = 1
                        Exit For
                    End If
                Next
                If Session("cb") = 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No selected item.")
                    Exit Sub
                End If

                Dim AllotmentClass_ID As Long
                AllotmentClass_ID = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

                '==== ALL FIELDS REQUIRED CHECKING
                If AllotmentClass_ID = 3 Then
                    If grdAIR.SelectedDataKey("GA_ID") = 1060 Or grdAIR.SelectedDataKey("GA_ID") = 1067 Then '
                        '=-= LAND
                        'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Not Available at this Time, Contanct Administrator.")


                    ElseIf grdAIR.SelectedDataKey("GA_ID") = 1082 Or grdAIR.SelectedDataKey("GA_ID") = 1085 Then
                        '=-= BUILDINGS
                        'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Not Available at this Time, Contanct Administrator.")


                    ElseIf grdAIR.SelectedDataKey("GA_ID") = 1166 Then
                        '=-= TRANSPORTATION
                        If txtCO_MName.Text = "" Or txtCO_MModel.Text = "" Or txtCO_MCapacity.Text = "" Or txtCO_MWeight.Text = "" Or txtCO_MSeats.Text = "" Or txtCO_MWarranty.Text = "" Or txtBeneficialUser.Text = "" Or txtDeclaredName.Text = "" Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields, write N/A if Not Applicable.")
                            Exit Sub
                            ' ElseIf txtDisplacement.Text = "" Or txtCSNumber.Text = "" Or txtEngineNo.Text = "" Then
                        ElseIf txtDisplacement.Text = "" Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields, write N/A if Not Applicable.")
                            Exit Sub
                        End If

                    Else '=-= OTHERS CAPITAL OUTLAY
                        If txtCO_Name.Text = "" Or txtCO_Description.Text = "" Or txtCO_PowerIn.Text = "" Or txtCO_Dimension.Text = "" Or txtCO_AreaCap.Text = "" Or txtCO_Model.Text = "" Or txtWarranty.Text = "" Or txtCO_DepRate.Text = "" Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields, write N/A if Not Applicable.")
                            Exit Sub
                        End If

                    End If
                End If

                If ddReceiveBy.SelectedItem.Text = "Select" Or ddInspectedBy.SelectedItem.Text = "Select" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select received by and inspected by.")
                    Exit Sub
                End If
                '=-= SAVE AMS.Tb_Receiving
                With rcv
                    .Received_Date = txtReceiveDate.Text
                    .ReceivedBY = ddReceiveBy.SelectedItem.Value
                    .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
                    .PO_No = grdAIR.SelectedDataKey("PO_No")
                    .Supplier_ID = grdAIR.SelectedDataKey("Supplier_Id")
                    .GA_ID = grdAIR.SelectedDataKey("GA_ID")
                    .isAccepted = False
                    .UserID = Session("@UserName")
                End With

                Dim RR_No As String
                Dim rcvID As Long = objDerived.GetValue("SELECT * FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' AND Received_Date = '" & txtReceiveDate.Text & "'", CommandType.Text)
                If rcvID = 0 Then
                    rcvID = rcv.save

                    RR_No = objDerived.GetValue("SELECT [AMS].[func_GenerateRR_No] ('" & txtReceiveDate.Text & "')", CommandType.Text)
                    objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET RR_No = '" & RR_No & "',InvoiceNo = '" & txtInvoiceNumber.Text & "' WHERE Received_ID = '" & rcvID & "'", CommandType.Text)

                Else
                    rcv.Received_ID = rcvID
                    rcv.update()
                End If

                Session("Received_ID") = rcvID

                'objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InspectedBy = '" & ddInspectedBy.SelectedItem.Value & "',InspectedBy2 = '" & ddInspectedBy2.SelectedItem.Value & "',InspectedBy3 = '" & ddInspectedBy3.SelectedItem.Value & "' WHERE Received_ID = '" & rcvID & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InspectedBy = '" & ddInspectedBy.SelectedItem.Value & "',InspectedBy2 = 0 ,InspectedBy3 = 0 WHERE Received_ID = '" & rcvID & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.PO_Hdr SET isDelivered = 1  WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)


                For x As Integer = 0 To grdItems.Rows.Count - 1
                    cb = CType(Me.grdItems.Rows(x).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If cb.Checked = True Then
                        Dim RcvQty As Decimal = CType(CType(grdItems.Rows(x).FindControl("txtQty"), TextBox).Text, Decimal)
                        Dim Cndtion As String = CType(CType(grdItems.Rows(x).FindControl("txtCondition"), TextBox).Text, String)
                        Dim Lction As String = CType(CType(grdItems.Rows(x).FindControl("txtLocation"), TextBox).Text, String)
                        Dim MarketValue As Decimal = CType(CType(grdItems.Rows(x).FindControl("txtMarketValue"), TextBox).Text, Decimal)


                        '=-= SAVE AMS.Tb_Receiving_Dtl
                        With rcv_dtl
                            .Received_ID = rcvID
                            .Item_ID = pPurchase_Order_detail.Rows(x)("Item_ID")
                            .PO_Qty = pPurchase_Order_detail.Rows(x)("qty") 'objDerived.GetValue("SELECT qty FROM [dbo].[View_PO_ItemQty] WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' AND Item_ID = '" & pPurchase_Order_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
                            .Qty_Received = RcvQty
                            .Cost = pPurchase_Order_detail.Rows(x)("cost")
                            .Condition = Cndtion
                            .Location = Lction
                        End With

                        Dim RcvDtl_ID As Long = objDerived.GetValue("SELECT Received_Dtl_ID FROM AMS.Tb_Receiving_Dtl WHERE Received_ID = '" & rcvID & "' AND Item_ID = '" & pPurchase_Order_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
                        If RcvDtl_ID = 0 Then
                            RcvDtl_ID = rcv_dtl.save
                            objDerived.GetRecords("UPDATE AMS.Tb_Receiving_Dtl SET OtherSpecs = '" & pPurchase_Order_detail.Rows(x)("PO_Remarks") & "' ,MarketValue = '" & MarketValue & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)
                        Else
                            rcv_dtl.Received_Dtl_ID = RcvDtl_ID
                            rcv_dtl.update()
                            objDerived.GetRecords("UPDATE AMS.Tb_Receiving_Dtl SET OtherSpecs = '" & pPurchase_Order_detail.Rows(x)("PO_Remarks") & "', MarketValue = '" & MarketValue & "' WHERE Received_Dtl_ID = '" & RcvDtl_ID & "'", CommandType.Text)

                        End If

                        Session("Received_Dtl_ID") = RcvDtl_ID

                    End If
                Next


                '=-= SAVE ITEM DETAILS
                Dim cnt As Integer = 0
                For x As Integer = 0 To grdItems.Rows.Count - 1
                    cb = CType(Me.grdItems.Rows(x).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If cb.Checked = True Then
                        cnt = cnt + 1
                    End If
                Next


                If cnt = 1 Then
                    If AllotmentClass_ID = 2 Then '=-= MOOE ITEMS

                        If txtMOOE_MftgDate.Text = "" Then
                            txtMOOE_MftgDate.Text = "1/1/1900"
                        End If
                        If txtMOOE_ExpiryDate.Text = "" Then
                            txtMOOE_ExpiryDate.Text = "1/1/1900"
                        End If
                        If txtMOOE_AlertDate.Text = "" Then
                            txtMOOE_AlertDate.Text = "1/1/1900"
                        End If

                        For MOOE As Integer = 0 To grdItems.Rows.Count - 1
                            Dim Lction As String = CType(CType(grdItems.Rows(MOOE).FindControl("txtLocation"), TextBox).Text, String)
                            cb = CType(Me.grdItems.Rows(MOOE).Cells(0).FindControl("CheckBox1"), CheckBox)
                            If cb.Checked = True Then
                                If grdAIR.SelectedDataKey("GA_ID") = 1427 Then '=== grdAIR.SelectedDataKey("GA_ID") = 788 Then
                                    '=-= OFFICE SUPPLIES 
                                    With OfficeSup
                                        .StockID = 0
                                        .AIRDtl_ID = 0
                                        .ItemId = pPurchase_Order_detail.Rows(MOOE)("Item_ID")
                                        .Description = txtOfficeItemDesc.Text
                                        .BrandName = txtOfficeBrandName.Text
                                        .SupplierId = grdAIR.SelectedDataKey("Supplier_Id")
                                        .Size = txtOfficeSize.Text
                                        .Color = txtOfficeColor.Text
                                        .Category = txtOfficeCategory.Text
                                        .Length = txtOfficeLength.Text
                                        .Width = txtOfficeWidth.Text
                                        .Height = txtOfficeHeight.Text
                                        .Weight = txtOfficeWeight.Text
                                        .DepreciatedRate = txtOfficeDepRate.Text
                                        If txtOfficeDepValue.Text = "" Then
                                            .DepreciatedValue = 0
                                        Else
                                            .DepreciatedValue = txtOfficeDepValue.Text
                                        End If
                                        .Status = "Received"
                                        .Received_ID = rcvID
                                        .Componentof = ""
                                    End With
                                    'here fix
                                    Dim Supp_ID As Long = OfficeSup.save

                                ElseIf grdAIR.SelectedDataKey("GA_ID") = 1432 Or grdAIR.SelectedDataKey("GA_ID") = 1433 Then '=== grdAIR.SelectedDataKey("GA_ID") = 792 Or grdAIR.SelectedDataKey("GA_ID") = 793 Then
                                    '=-= MEDICINES SUPPLIES AND MEDICAL SUPPLIES
                                    With MedInfo
                                        .StockId = 0
                                        .AIRDtl_ID = 0
                                        .Item_ID = pPurchase_Order_detail.Rows(MOOE)("Item_ID")
                                        .DeliveryDate = txtReceiveDate.Text
                                        .Description = txtMOOE_Description.Text
                                        .DrugName = txtMOOE_Description.Text
                                        .BrandName = txtMOOE_Brand.Text
                                        .SupplierId = grdAIR.SelectedDataKey("Supplier_Id")
                                        .Dose = txtDose.Text
                                        .Location = Lction
                                        .Status = "Received"
                                        .Received_ID = rcvID
                                        .Depreciatedrate = txtMOOE_DepRate.Text
                                        If txtMOOE_DepValue.Text = "" Then
                                            .Depreciatedvalue = 0
                                        Else
                                            .Depreciatedvalue = txtMOOE_DepValue.Text
                                        End If

                                    End With

                                    Dim MedID As Long = MedInfo.save

                                    With MedDtl
                                        .MedicineID = MedID
                                        .StockId = 0
                                        .Item_ID = pPurchase_Order_detail.Rows(MOOE)("Item_ID")
                                        .Form = txtMOOE_Form.Text
                                        .OTCRx = txtMOOE_OTCRx.Text
                                        .Batch = txtMOOE_Batch.Text
                                        .Lot = txtMOOE_Lot.Text
                                        .Mftgdate = txtMOOE_MftgDate.Text
                                        .EpiryDate = txtMOOE_ExpiryDate.Text
                                        .Alert = txtMOOE_AlertDate.Text
                                        .save()
                                    End With


                                ElseIf grdAIR.SelectedDataKey("GA_ID") = 1441 Then '=== grdAIR.SelectedDataKey("GA_ID") = 799 Then
                                    '=-= WATER SUPPLIES
                                    With Water
                                        .StockId = 0
                                        .AIRDtl_ID = 0
                                        .Item_ID = pPurchase_Order_detail.Rows(MOOE)("Item_ID")
                                        .DeliveryDate = txtReceiveDate.Text
                                        .Form = txtMOOE_Form.Text
                                        .OTCRx = txtMOOE_OTCRx.Text
                                        .Batch = txtMOOE_Batch.Text
                                        .Lot = txtMOOE_Lot.Text
                                        .Mftgdate = txtMOOE_MftgDate.Text
                                        .EpiryDate = txtMOOE_ExpiryDate.Text
                                        .Alert = txtMOOE_AlertDate.Text
                                        .ItemDesc = txtMOOE_Description.Text
                                        .BrandName = txtMOOE_Brand.Text
                                        .Supplier_Id = grdAIR.SelectedDataKey("Supplier_Id")
                                        .Storage = Lction
                                        .Depreciationrate = txtMOOE_DepRate.Text
                                        If txtMOOE_DepValue.Text = "" Then
                                            .Depreciationvalue = 0
                                        Else
                                            .Depreciationvalue = txtMOOE_DepValue.Text
                                        End If

                                        .Status = "Received"
                                        .Received_ID = rcvID
                                    End With

                                    Dim WaterID As Long = Water.save

                                ElseIf grdAIR.SelectedDataKey("GA_ID") = 1430 Then '=== grdAIR.SelectedDataKey("GA_ID") = 791 Then
                                    '=-= FOOD SUPPLIES
                                    With Food
                                        .StockId = 0
                                        .AIRDtl_ID = 0
                                        .Item_ID = pPurchase_Order_detail.Rows(MOOE)("Item_ID")
                                        .DeliveryDate = txtReceiveDate.Text
                                        .Form = txtMOOE_Form.Text
                                        .OTCRx = txtMOOE_OTCRx.Text
                                        .Batch = txtMOOE_Batch.Text
                                        .Lot = txtMOOE_Lot.Text
                                        .Mftgdate = txtMOOE_MftgDate.Text
                                        .EpiryDate = txtMOOE_ExpiryDate.Text
                                        .Alert = txtMOOE_AlertDate.Text
                                        .ItemDesc = txtMOOE_Description.Text
                                        .BrandName = txtMOOE_Brand.Text
                                        .Supplier_Id = grdAIR.SelectedDataKey("Supplier_Id")
                                        .Storage = Lction
                                        .Depreciationrate = txtMOOE_DepRate.Text
                                        If txtMOOE_DepValue.Text = "" Then
                                            .Depreciationvalue = 0
                                        Else
                                            .Depreciationvalue = txtMOOE_DepValue.Text
                                        End If

                                        .Status = "Received"
                                        .Received_ID = rcvID
                                    End With

                                    Dim FoodID As Long = Food.save

                                Else '=-= OTHER SUPPLIES 
                                    With NonFood
                                        .StockId = 0
                                        .AIRDtl_ID = 0
                                        .Item_ID = pPurchase_Order_detail.Rows(MOOE)("Item_ID")
                                        .DeliveryDate = txtReceiveDate.Text
                                        .Form = txtMOOE_Form.Text
                                        .OTCRx = txtMOOE_OTCRx.Text
                                        .Batch = txtMOOE_Batch.Text
                                        .Lot = txtMOOE_Lot.Text
                                        .Mftgdate = txtMOOE_MftgDate.Text
                                        .EpiryDate = txtMOOE_ExpiryDate.Text
                                        .Alert = txtMOOE_AlertDate.Text
                                        .ItemDesc = txtMOOE_Description.Text
                                        .BrandName = txtMOOE_Brand.Text
                                        .Supplier_Id = grdAIR.SelectedDataKey("Supplier_Id")
                                        .Storage = Lction
                                        .Depreciationrate = txtMOOE_DepRate.Text
                                        If txtMOOE_DepValue.Text = "" Then
                                            .Depreciationvalue = 0
                                        Else
                                            .Depreciationvalue = txtMOOE_DepValue.Text
                                        End If

                                        .Status = "Received"
                                        .Received_ID = rcvID
                                    End With

                                    Dim NonFoodID As Long = NonFood.save

                                End If
                            End If
                        Next


                    ElseIf AllotmentClass_ID = 3 Then '=-= CAPITAL OUTLAY ITEMS
                        For CO As Integer = 0 To grdItems.Rows.Count - 1
                            cb = CType(Me.grdItems.Rows(CO).Cells(0).FindControl("CheckBox1"), CheckBox)
                            If cb.Checked = True Then
                                Dim Lction As String = CType(CType(grdItems.Rows(CO).FindControl("txtLocation"), TextBox).Text, String)
                                Dim MrketValue As Decimal = CType(CType(grdItems.Rows(CO).FindControl("txtMarketValue"), TextBox).Text, Decimal)
                                Dim Cndtion As String = CType(CType(grdItems.Rows(CO).FindControl("txtCondition"), TextBox).Text, String)

                                If grdAIR.SelectedDataKey("GA_ID") = 1060 Or grdAIR.SelectedDataKey("GA_ID") = 1062 Or grdAIR.SelectedDataKey("GA_ID") = 1067 Then '=== grdAIR.SelectedDataKey("GA_ID") = 520 Or grdAIR.SelectedDataKey("GA_ID") = 521 Then
                                    '=-= LAND
                                    'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Not Available at this Time, Contanct Administrator.")
                                    With LandDtl
                                        '.LandId = LandId
                                        .LguCode = txtLandlgucode.Text
                                        .SectionNo = txtLandSectionno.Text
                                        .PIN = txtLandPIN.Text
                                        .TDN = txtLandTdn.Text
                                        .DistrictCode = txtLanddistrictcode.Text
                                        .ParcelNo = txtLandParcelno.Text
                                        .ARP = txtLandARP.Text
                                        .CityMunCode = txtLandcitymunicipality1.Text
                                        .SeriesNo = txtLandSeriesno.Text
                                        .RevYear = txtLandrevyear.Text
                                        .BarangayCode = txtLandbrgycode.Text
                                        .RPTIN = txtLandRPTIN.Text
                                        .DepreciationRate = txtLandDepriciationRate.Text
                                        .DepreciationValue = txtLandDepreciatedValue.Text
                                        .LotNo = txtLandlocationLot.Text
                                        .BlkNo = txtLandlocationblkno.Text
                                        .StreetName = txtLandlocationstreetname.Text
                                        .Subdivision = txtLandlocationsubdivisionvillage.Text
                                        .PhaseNo = txtLandlocationphaseno.Text
                                        .Purok = txtLandlocationpurok.Text
                                        .Sitio = txtLandlocationsitio.Text
                                        .Barangay = txtLandbarangay.Text
                                        .District = txtLandDistrict.Text
                                        .CityMunicipal = txtLandCitymunicipality.Text
                                        .Province = txtLandprovince.Text
                                        .Region = txtLandRegion.Text
                                        .ZipCode = txtLandzipcode.Text
                                        .Classification = txtLandClassification.Text
                                        .SubClass = txtLandSubClass.Text
                                        .LandUse = txtLandUse.Text
                                        .Area = txtLandArea.Text
                                        .AVAmountWords = txtLandAssessedAmount.Text
                                        .MVAmountWords = txtLandMarketAmount.Text
                                        .AssessmentLevel = dpLandAssessmentLvl.SelectedValue
                                        .Status_1 = txtLandStatus1.Text
                                        .Status_2 = txtLandStatus2.Text
                                        .AssessedValue = txtLandAssessedValue.Text
                                        .MarketValue = txtLandMarketValue.Text
                                        .UnitValue = txtLandUnitValue.Text
                                        .Taxable = ddwnLandTaxable.SelectedItem.Text

                                        If txtLandAssessedDate.Text = "" Then
                                            .AssessedDate = "01/01/1900"
                                        Else
                                            .AssessedDate = txtLandAssessedDate.Text
                                        End If

                                        If txtLandMarketDate.Text = "" Then
                                            .MarketDate = "01/01/1900"
                                        Else
                                            .MarketDate = txtLandMarketDate.Text
                                        End If

                                        If txtLandUnitDate.Text = "" Then
                                            .UnitDate = "01/01/1900"
                                        Else
                                            .UnitDate = txtLandUnitDate.Text
                                        End If
                                        .Received_ID = rcvID
                                        .save()
                                    End With

                                ElseIf grdAIR.SelectedDataKey("GA_ID") = 1082 Or grdAIR.SelectedDataKey("GA_ID") = 1085 Then '=== grdAIR.SelectedDataKey("GA_ID") = 525 Or grdAIR.SelectedDataKey("GA_ID") = 526 Then
                                    '=-= BUILDINGS
                                    'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Not Available at this Time, Contanct Administrator.")
                                    With BldgInfo
                                        '.BuildingId = BuildingId
                                        .BuildingControlNo = txtbuildingcontolno.Text
                                        .BuildingCode = txtbuildingcode.Text
                                        .BuildingName = txtbuildingname.Text
                                        .Address = txtbuildingaddress.Text
                                        .PostalCode = txtbuildingpostalcode.Text

                                        If txtbuildingdepreciationrate.Text = "" Then
                                            .BuildingDepreciationRate = "0.00"
                                        Else
                                            .BuildingDepreciationRate = txtbuildingdepreciationrate.Text
                                        End If
                                        .BuildingUse = txtbuildinguse.Text
                                        .BuildingOccupancy = txtbuildingoccupancy.Text
                                        .NumberFloors = txtbuildingnumberoffloors.Text
                                        .AvgAreaFloor = txtbuildingavgareaperfloor.Text
                                        .CostPerArea = txtbuildingcostperarea.Text
                                        '.Status_AIR = ""

                                        If txtbuildingdepreciationvalue.Text = "" Then
                                            .BuildingDepreciationValue = "0.00"
                                        Else
                                            .BuildingDepreciationValue = txtbuildingdepreciationvalue.Text
                                        End If
                                        .Received_ID = rcvID
                                        .save()

                                    End With


                                ElseIf grdAIR.SelectedDataKey("GA_ID") = 1118 Then '=== grdAIR.SelectedDataKey("GA_ID") = 534 Then
                                    '=-= FURNITURE AND FIXTURES
                                    With FurnitureInfo
                                        .AIRDtl_ID = 0
                                        .IsAccepted = False
                                        .Property_Dtl_ID = 0
                                        .SerialNo = "-"
                                        .Name = txtCO_Name.Text
                                        .Description = txtCO_Description.Text
                                        .Dimension = txtCO_Dimension.Text
                                        .AreaCapacity = txtCO_AreaCap.Text
                                        .Model = txtCO_Model.Text
                                        .Warranty = txtWarranty.Text
                                        .Specification = txtCO_Specs.Text
                                        .DepreciationRate = txtCO_DepRate.Text
                                        If txtCO_DepValue.Text = "" Then
                                            .DepreciationValue = 0
                                        Else
                                            .DepreciationValue = txtCO_DepValue.Text
                                        End If
                                        .Received_ID = rcvID
                                    End With

                                    Dim FurniID As Long = FurnitureInfo.save
                                    objDerived.GetRecords("UPDATE AMS.TbFurniture_Info SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "' WHERE FurnitureInfoId = '" & FurniID & "'", CommandType.Text)

                                    With FurnitureDtl
                                        .FurnitureInfoId = FurniID
                                        .Property_Dtl_ID = 0
                                        .MarketValue = MrketValue
                                        .Condition = Cndtion
                                        .Location = Lction
                                        .Status = "Received"
                                        .save()
                                    End With

                                ElseIf grdAIR.SelectedDataKey("GA_ID") = 1127 Then '=== grdAIR.SelectedDataKey("GA_ID") = 537 Then
                                    '=-= MACHINIRIES
                                    With MachineInfo
                                        .AIRDtl_ID = 0
                                        .IsAccepted = False
                                        .Property_Dtl_ID = 0
                                        .SerialNo = "-"
                                        .MachineDesc = txtCO_Description.Text
                                        .MachineLocation = Lction
                                        .BrandModel = txtCO_Model.Text
                                        .DepreciationRate = txtCO_DepRate.Text
                                        If txtCO_DepValue.Text = "" Then
                                            .DepreciationValue = 0
                                        Else
                                            .DepreciationValue = txtCO_DepValue.Text
                                        End If
                                        .Received_ID = rcvID
                                    End With

                                    Dim MachineID As Long = MachineInfo.save
                                    objDerived.GetRecords("UPDATE AMS.TbMachinery_Information SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "' WHERE MachineryInfoId = '" & MachineID & "'", CommandType.Text)

                                    With MachineDtl
                                        .MachineryInfoId = MachineID
                                        .Property_Dtl_ID = 0
                                        .MarketValue = MrketValue
                                        .Condition = Cndtion
                                        .Location = Lction
                                        .Status = "Received"
                                        .save()
                                    End With

                                ElseIf grdAIR.SelectedDataKey("GA_ID") = 1166 Then
                                    '=-= TRANSPORTATION
                                    ''here 12012023
                                    'With MotorInfo

                                    '    .AIRDtl_ID = 0
                                    '    .IsAccepted = False
                                    '    .Property_Dtl_ID = 0
                                    '    .Name = txtCO_MName.Text
                                    '    .PlateNo = ""
                                    '    .Model = txtCO_MModel.Text
                                    '    .MotorNo = ""
                                    '    .ChasisNo = txtCO_MChasisNo.Text
                                    '    .VehicleColor = txtCO_MColor.Text
                                    '    .WheelsCapacity = txtCO_MCapacity.Text
                                    '    .GrossWeight = txtCO_MWeight.Text
                                    '    .Seats = txtCO_MSeats.Text
                                    '    .Warranty = txtCO_MWarranty.Text
                                    '    .VehicleOwner = ""
                                    '    .DeclaredName = txtDeclaredName.Text
                                    '    .BeneficialUser = txtBeneficialUser.Text
                                    '    .VehicleSpecification = txtCO_MSpecs.Text
                                    '    .Received_ID = rcvID
                                    'End With

                                    'Dim MotorID As Long = MotorInfo.save
                                    'objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "', CSNo = '" & txtCSNumber.Text & "', EngineNo = '" & txtEngineNo.Text & "', Displacement = '" & txtDisplacement.Text & "' WHERE Motor_InfoId = '" & MotorID & "'", CommandType.Text)

                                    'With MotorDtl
                                    '    .Motor_InfoId = MotorID
                                    '    .Property_Dtl_ID = 0
                                    '    .MarketValue = MrketValue
                                    '    .Condition = Cndtion
                                    '    .Location = Lction
                                    '    .Status = "Received"
                                    '    .save()
                                    'End With

                                Else '=-= ALL EQUIPMENTS
                                    With EquipInfo
                                        .AIRDtl_ID = 0
                                        .IsAccepted = False
                                        .Property_Dtl_ID = 0
                                        .SerialNo = "-"
                                        .Name = txtCO_Name.Text
                                        .Description = txtCO_Description.Text
                                        .PowerInput = txtCO_PowerIn.Text
                                        .Dimension = txtCO_Dimension.Text
                                        .AreaCapacity = txtCO_AreaCap.Text
                                        .Model = txtCO_Model.Text
                                        .Warranty = txtWarranty.Text
                                        .Specification = txtCO_Specs.Text
                                        .DepreciationRate = txtCO_DepRate.Text
                                        If txtCO_DepValue.Text = "" Then
                                            .DepreciationValue = 0
                                        Else
                                            .DepreciationValue = txtCO_DepValue.Text
                                        End If
                                        .Received_ID = rcvID
                                    End With

                                    Dim EuipID As Long = EquipInfo.save
                                    objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "' WHERE EquipInfoId = '" & EuipID & "'", CommandType.Text)

                                    With EquipDtl
                                        .EquipInfoId = EuipID
                                        .Property_Dtl_ID = 0
                                        .MarketValue = MrketValue
                                        .Condition = Cndtion
                                        .Location = Lction
                                        .Status = "Received"
                                        .save()
                                    End With

                                End If
                            End If
                        Next
                    End If

                End If

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                btnRcvSave.Enabled = False
                btnRcvPreview.Enabled = True
                LoadAllItems()
                ''LoadMOOE()
                '=-= CLEAR ENCODED DATA
                LoadClearEncodedData()

            Catch ex As Exception
                ' MsgBox(ex.Message)
            End Try

        Else

        End If


    End Sub
    Protected Sub LoadClearEncodedData()
        Dim eAllotmentClass_ID As Long
        eAllotmentClass_ID = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

        If eAllotmentClass_ID = 2 Then

            If grdAIR.SelectedDataKey("GA_ID") = 1427 Then
                '=-= OFFICE SUPPLIES
                'txtOfficeItemDesc.Text = ""
                'txtOfficeBrandName.Text = ""
                'txtOfficeSize.Text = ""
                'txtOfficeColor.Text = ""
                'txtOfficeCategory.Text = ""
                'txtOfficeLength.Text = ""
                'txtOfficeWidth.Text = ""
                'txtOfficeHeight.Text = ""
                'txtOfficeWeight.Text = ""
                'txtOfficeDepRate.Text = ""
                'txtOfficeDepValue.Text = ""
                For Each control As Control In controls
                    If TypeOf control Is TextBox Then
                        CType(control, TextBox).Text = ""
                    End If
                Next
            Else
                'txtMOOE_Form.Text = ""
                'txtMOOE_OTCRx.Text = ""
                'txtMOOE_Batch.Text = ""
                'txtMOOE_Lot.Text = ""
                'txtMOOE_MftgDate.Text = ""
                'txtMOOE_ExpiryDate.Text = ""
                'txtMOOE_AlertDate.Text = ""
                'txtMOOE_Description.Text = ""
                'txtMOOE_Brand.Text = ""
                'txtMOOE_DepRate.Text = ""
                'txtMOOE_DepValue.Text = ""
                'txtDose.Text = ""
                For Each control As Control In controls
                    If TypeOf control Is TextBox Then
                        CType(control, TextBox).Text = ""
                    End If
                Next

            End If

        ElseIf eAllotmentClass_ID = 3 Then
            If grdAIR.SelectedDataKey("GA_ID") = 1166 Then
                '=-= TRANSPORTATION
                'txtCO_MName.Text = ""
                'txtCO_MModel.Text = ""
                'txtCO_MChasisNo.Text = ""
                'txtCO_MColor.Text = ""
                'txtCO_MCapacity.Text = ""
                'txtCO_MWeight.Text = ""
                'txtCO_MSeats.Text = ""
                'txtCO_MWarranty.Text = ""
                'txtDeclaredName.Text = ""
                'txtBeneficialUser.Text = ""
                'txtCO_MSpecs.Text = ""
                'txtCSNumber.Text = ""
                'txtEngineNo.Text = ""
                'txtDisplacement.Text = ""
                For Each control As Control In controls
                    If TypeOf control Is TextBox Then
                        CType(control, TextBox).Text = ""
                    End If
                Next
            Else
                'txtCO_Name.Text = ""
                'txtCO_Description.Text = ""
                'txtCO_PowerIn.Text = ""
                'txtCO_Dimension.Text = ""
                'txtCO_AreaCap.Text = ""
                'txtCO_Model.Text = ""
                'txtWarranty.Text = ""
                'txtCO_Specs.Text = ""
                'txtCO_DepRate.Text = ""
                'txtCO_DepValue.Text = ""
                For Each control As Control In controls
                    If TypeOf control Is TextBox Then
                        CType(control, TextBox).Text = ""
                    End If
                Next
            End If
        End If
    End Sub
    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '''here 2
        'Dim cb5 As CheckBox
        'Dim x1 As Integer = 0
        'Dim x2 As Integer = 0
        'For xxx As Integer = 0 To grdInspection.Rows.Count - 1
        '    cb5 = CType(Me.grdInspection.Rows(xxx).Cells(0).FindControl("cbInspection"), CheckBox)

        '    If cb5.Checked = True Then
        '        x1 = x1 + 1
        '    Else

        '    End If

        'Next


        'Dim a1 As Integer = 0
        'Try
        '    If pInspection_detail.Rows.Count > 0 Then
        '        Dim a As Double = 0
        '        For i As Integer = 0 To pInspection_detail.Rows.Count - 1
        '            Dim b As String = CType(CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox).Text, String)
        '            a = a + Val(b)
        '        Next
        '        a1 = a
        '    Else

        '        a1 = 0
        '    End If

        'Catch ex As Exception

        'End Try

        'If (x1) = (txtHiddenReceiveQty.Value) And a1 = Val(txtHidenQTY.Value) Then
        '    rbStatus.Items.Item(1).Enabled = True
        'Else
        '    rbStatus.Items.Item(1).Selected = False
        '    rbStatus.Items.Item(0).Selected = True
        '    rbStatus.Items.Item(1).Enabled = False

        'End If
        'x1 = 0
        ''End here 2


        '''End here 1


        Dim cb1 As CheckBox
        Dim cb2 As CheckBox
        Dim x As Integer = 0

        For i As Integer = 0 To grdInspection.Rows.Count - 1
            cb1 = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
            If cb1.Visible = True Then
                If cb1.Checked = True Then
                    x = 1
                    Dim RcvDate As Date = CType(CType(grdInspection.Rows(i).FindControl("lblRcvDate"), Label).Text, Date)

                    For r As Integer = 0 To grdInspection.Rows.Count - 1
                        cb2 = CType(Me.grdInspection.Rows(r).Cells(0).FindControl("cbInspection"), CheckBox)
                        If cb2.Visible = True Then
                            If CType(CType(grdInspection.Rows(r).FindControl("lblRcvDate"), Label).Text, Date) = RcvDate Then
                                cb2.Enabled = True
                            Else
                                cb2.Enabled = False
                            End If

                        End If

                    Next
                End If
            End If
        Next

        If x = 0 Then
            For i As Integer = 0 To grdInspection.Rows.Count - 1
                cb2 = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                cb2.Enabled = True
            Next
            btnRcvSave.Enabled = True
            btnActSave.Enabled = False
        Else
            If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                ddDepartment.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_AIR_ConsolidatedPR] '" & grdAIR.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
                ddDepartment.DataTextField = ("RC_Name")
                ddDepartment.DataValueField = ("RC_ID")
                ddDepartment.DataBind()
                ddDepartment.Items.Insert(0, "Select")

                ddFunction.Items.Clear()
                ddFunction.DataSource = Nothing
                ddFunction.DataBind()
                ddFunction.Items.Insert(0, "Select")

                tb_1Dept.Visible = False
                tb_2Dept.Visible = True
            Else
                txtDepartment.Text = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                txtFunction.Text = objDerived.GetValue("SELECT Function_Desc FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "' AND Function_ID = '" & grdAIR.SelectedDataKey("Function_ID") & "'", CommandType.Text)
                tb_1Dept.Visible = True
                tb_2Dept.Visible = False
            End If

            btnRcvSave.Enabled = False
            btnActSave.Enabled = True
        End If

    End Sub
    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddDepartment.SelectedItem.Text = "Select" Then
            ddFunction.Items.Clear()
            ddFunction.DataSource = Nothing
            ddFunction.DataBind()
            ddFunction.Items.Insert(0, "Select")

        Else
            ddFunction.Items.Clear()
            ddFunction.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
            ddFunction.DataTextField = ("Function_Desc")
            ddFunction.DataValueField = ("Function_ID")
            ddFunction.DataBind()
            ddFunction.Items.Insert(0, "Select")

        End If

    End Sub
    Protected Sub btnActSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtTraps.Value = "Yes" Then

            Try

                If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                    If ddDepartment.SelectedItem.Text = "Select" Or ddFunction.SelectedItem.Text = "Select" Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select deparment and its function.")
                        Exit Sub
                    End If
                End If

                '========================== ACCEPTANCE ==========================
                If AllotmentClass = 2 Then
                    '============== MOOE ==============
                    Dim ReceivedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("ReceivedBY") & "'", CommandType.Text)
                    Dim InspectedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("InspectedBy") & "'", CommandType.Text)

                    '=-= SAVE AMS.AIR_Hdr
                    Dim AIR_No As String = supplies.GetValue("select [AMS].[func_GenerateAIR]( '" & txtAcceptDate.Text & "')", CommandType.Text)
                    With AIR_Hdr
                        .AIR_No = AIR_No
                        .AIR_Date = txtAcceptDate.Text
                        .Invoice_No = txtInvoiceNumber.Text
                        .Invoice_date = txtInvoiceDate.Text
                        .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
                        .PO_No = grdAIR.SelectedDataKey("PO_No")
                        .Supplier_ID = grdAIR.SelectedDataKey("Supplier_Id")
                        .Date_Received = pInspection_detail.Rows(0)("Received_Date")
                        .Date_Inspect = pInspection_detail.Rows(0)("Received_Date")
                        .Date_Accepted = txtAcceptDate.Text
                        .Signatory1 = ReceivedBy
                        .Signatory2 = InspectedBy
                        .Signatory3 = ddAcceptedBy.SelectedItem.Text
                        .Trans_ID = 1
                        .remarks = txtRemarks.Text

                        If rbStatus.SelectedItem.Value = 2 Then
                            .isComplete = True
                        Else
                            .isComplete = False
                        End If

                        If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                            .RC_ID = ddDepartment.SelectedItem.Value
                            .Function_ID = ddFunction.SelectedItem.Value
                        Else
                            .RC_ID = grdAIR.SelectedDataKey("RC_ID")
                            .Function_ID = grdAIR.SelectedDataKey("Function_ID")
                        End If

                        Dim Box As CheckBox
                        For a As Integer = 0 To grdInspection.Rows.Count - 1
                            Box = CType(Me.grdInspection.Rows(a).Cells(0).FindControl("cbInspection"), CheckBox)
                            If Box.Checked = True Then
                                Dim zx As Long = pInspection_detail.Rows(a)("Received_ID")
                                Session("xReceived_ID") = zx
                                Exit For
                            End If
                        Next

                        .Received_ID = Session("xReceived_ID")
                        .UserID = Session("@UserName")

                    End With

                    Dim xAIRHdr_ID As Long = AIR_Hdr.save
                    Session("AIRHdr_ID") = xAIRHdr_ID


                    Dim cb As CheckBox
                    For x As Integer = 0 To grdInspection.Rows.Count - 1
                        cb = CType(Me.grdInspection.Rows(x).Cells(0).FindControl("cbInspection"), CheckBox)
                        If cb.Checked = True Then
                            Dim AcptQty As Decimal = CType(CType(grdInspection.Rows(x).FindControl("txtActQty"), TextBox).Text, Decimal)

                            '=-= SAVE AMS.AIR_Dtl
                            With AIR_Dtl
                                .AIRHdr_ID = xAIRHdr_ID
                                .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                                .Qty = AcptQty
                                .Cost = pInspection_detail.Rows(x)("Cost")
                                .GA_ID = grdAIR.SelectedDataKey("GA_ID")
                                .Warranty = txtWarranty.Text
                            End With

                            Dim AIRDtl_ID As Long = AIR_Dtl.save

                            objDerived.GetRecords("UPDATE AMS.AIR_Dtl SET OtherSpecs = '" & pInspection_detail.Rows(x)("OtherSpecs") & "', isAccepted = 1 WHERE AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)

                            '==================================================================================

                            '=-= SAVE AMS.STOCK

                            With Stock
                                .StockDate = txtAcceptDate.Text
                                .AIRDtl_ID = AIRDtl_ID
                                .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                                .Qty = AcptQty
                                .Balance = AcptQty
                                .Issuance = 0
                                .Cost = pInspection_detail.Rows(x)("Cost")
                                .Project_ID = 0
                                .Program_id = 0
                                .F_ID = 1
                                .GA_ID = grdAIR.SelectedDataKey("GA_ID")
                                .Location = pInspection_detail.Rows(x)("Location")

                                If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                                    .RC_ID = ddDepartment.SelectedItem.Value
                                    .Function_ID = ddFunction.SelectedItem.Value
                                Else
                                    .RC_ID = grdAIR.SelectedDataKey("RC_ID")
                                    .Function_ID = grdAIR.SelectedDataKey("Function_ID")
                                End If

                                .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
                                .Received_ID = Session("xReceived_ID")
                                .UserID = Session("@UserName")

                            End With

                            Dim StckID As Long = Stock.save
                            objDerived.Execute("UPDATE [AMS].[Stock] SET [OtherSpecs] = '" & pInspection_detail.Rows(x)("OtherSpecs") & "' WHERE [StockID] = " & StckID & "", CommandType.Text)


                            Dim Remarks = objDerived.Execute("select count(*) from [AMS].[Stock]  WHERE [StockID] = " & StckID & "", CommandType.Text)
                            '=-= SAVE AMS.TbStock_Ledger
                            Dim A As String = objDerived.GetValue("select distinct Trans_Type from AMS.TbStock_Ledger where Trans_Type = 'Starting Inventory' and Item_ID='" & pInspection_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
                            If A = "Starting Inventory" Then
                                If Remarks <> 0 Then
                                    With Stock_Ledger
                                        .StockID = StckID
                                        .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                                        .dDate = txtAcceptDate.Text
                                        .Trans_Type = "Purchase Order Delivered"
                                        .Ref = AIR_No
                                        .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                                        .ReceivedBy = ReceivedBy
                                        .InspectedBy = InspectedBy
                                        .AcceptedBy = ddAcceptedBy.SelectedItem.Text
                                        .DebitQty = AcptQty
                                        .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
                                        .DebitUnit = pInspection_detail.Rows(x)("Unit")
                                        .CreditQty = 0
                                        .CreditCost = "0.00"
                                        .CreditUnit = pInspection_detail.Rows(x)("Unit")
                                        .BalanceUnit = pInspection_detail.Rows(x)("Unit")

                                        If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                                            .Department = ddDepartment.SelectedItem.Text
                                        Else
                                            .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                                        End If

                                        .save()
                                    End With

                                Else
                                    With Stock_Ledger
                                        .StockID = StckID
                                        .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                                        .dDate = txtAcceptDate.Text
                                        .Trans_Type = "Purchase Order Delivered"
                                        .Ref = AIR_No
                                        .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                                        .ReceivedBy = ReceivedBy
                                        .InspectedBy = InspectedBy
                                        .AcceptedBy = ddAcceptedBy.SelectedItem.Text
                                        .DebitQty = AcptQty
                                        .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
                                        .DebitUnit = pInspection_detail.Rows(x)("Unit")
                                        .CreditQty = 0
                                        .CreditCost = "0.00"
                                        .CreditUnit = pInspection_detail.Rows(x)("Unit")
                                        .BalanceUnit = pInspection_detail.Rows(x)("Unit")

                                        If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                                            .Department = ddDepartment.SelectedItem.Text
                                        Else
                                            .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                                        End If

                                        .save()
                                    End With

                                End If
                            ElseIf IsDBNull(A) Or A = "" Then
                                If Remarks <> 0 Then
                                    With Stock_Ledger
                                        .StockID = StckID
                                        .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                                        .dDate = txtAcceptDate.Text
                                        .Trans_Type = "Starting Inventory"
                                        .Ref = AIR_No
                                        .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                                        .ReceivedBy = ReceivedBy
                                        .InspectedBy = InspectedBy
                                        .AcceptedBy = ddAcceptedBy.SelectedItem.Text
                                        .DebitQty = AcptQty
                                        .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
                                        .DebitUnit = pInspection_detail.Rows(x)("Unit")
                                        .CreditQty = 0
                                        .CreditCost = "0.00"
                                        .CreditUnit = pInspection_detail.Rows(x)("Unit")
                                        .BalanceUnit = pInspection_detail.Rows(x)("Unit")

                                        If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                                            .Department = ddDepartment.SelectedItem.Text
                                        Else
                                            .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                                        End If

                                        .save()
                                    End With

                                Else
                                    With Stock_Ledger
                                        .StockID = StckID
                                        .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                                        .dDate = txtAcceptDate.Text
                                        .Trans_Type = "Starting Inventory"
                                        .Ref = AIR_No
                                        .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                                        .ReceivedBy = ReceivedBy
                                        .InspectedBy = InspectedBy
                                        .AcceptedBy = ddAcceptedBy.SelectedItem.Text
                                        .DebitQty = AcptQty
                                        .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
                                        .DebitUnit = pInspection_detail.Rows(x)("Unit")
                                        .CreditQty = 0
                                        .CreditCost = "0.00"
                                        .CreditUnit = pInspection_detail.Rows(x)("Unit")
                                        .BalanceUnit = pInspection_detail.Rows(x)("Unit")

                                        If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                                            .Department = ddDepartment.SelectedItem.Text
                                        Else
                                            .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                                        End If

                                        .save()
                                    End With

                                End If
                            End If



                        End If
                    Next

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                    btnActSave.Enabled = False
                    btnActPreview.Enabled = True


                    ''grdInspection.Columns(0).Visible = False

                    ''LoadAllItems()
                    LoadAllItems()
                    LoadSearchBy()
                ElseIf AllotmentClass = 3 Then
                    '============== CAPITAL OUTLAY ==============
                    '11252022
                    Dim a As String = objDerived.GetValue("SELECT DISTINCT dbo.tbl_Classification.ClassificationName " &
                         "FROM dbo.tbl_SubClassification INNER JOIN " &
                         "dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId INNER JOIN " &
                         "dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID " &
                         "WHERE dbo.m_item.Item_ID = '" & pInspection_detail.Rows(0)("Item_ID") & "'", CommandType.Text)
                    If a = "Vehicle" Then
                        objDerived.GetRecords("DELETE dbo.Temp_ForSerial WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' ", CommandType.Text)

                        Dim cb As CheckBox
                        For i As Integer = 0 To grdInspection.Rows.Count - 1
                            cb = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                            If cb.Checked = True Then

                                Dim POHdr_ID As Long = grdAIR.SelectedDataKey("POHdr_ID").ToString
                                Dim AcptQty As Decimal = CType(CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox).Text, Decimal)
                                Dim Item_ID As Long = pInspection_detail.Rows(i)("Item_ID").ToString
                                Dim Item_Desc As String = pInspection_detail.Rows(i)("Item_Desc").ToString

                                'objDerived.GetRecords("INSERT INTO dbo.Temp_ForSerial (POHdr_ID,Item_ID,Item_Desc,AcptQty) VALUES ('" & POHdr_ID & "','" & Item_ID & "','" & Item_Desc & "','" & AcptQty & "')", CommandType.Text)

                                objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
                                objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
                                objDerived.cmd.Parameters.AddWithValue("@Item_Desc", Item_Desc)
                                objDerived.cmd.Parameters.AddWithValue("@AcptQty", AcptQty)
                                objDerived.Execute("[AMS].[spSave_Temp_ForSerial]", CommandType.StoredProcedure, Nothing)

                            End If
                        Next

                        pItemForSerial = objDerived.GetDataTable("EXEC [AMS].[sp_Acceptance_SerialNo_List] '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
                        grdSerialVehicles.DataSource = pItemForSerial
                        grdSerialVehicles.DataBind()

                        grdSerial.Columns(3).Visible = False
                        ModalPopupExtender2.Show()
                    Else
                        objDerived.GetRecords("DELETE dbo.Temp_ForSerial WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "' ", CommandType.Text)

                        Dim cb As CheckBox
                        For i As Integer = 0 To grdInspection.Rows.Count - 1
                            cb = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                            If cb.Checked = True Then

                                Dim POHdr_ID As Long = grdAIR.SelectedDataKey("POHdr_ID").ToString
                                Dim AcptQty As Decimal = CType(CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox).Text, Decimal)
                                Dim Item_ID As Long = pInspection_detail.Rows(i)("Item_ID").ToString
                                Dim Item_Desc As String = pInspection_detail.Rows(i)("Item_Desc").ToString

                                'objDerived.GetRecords("INSERT INTO dbo.Temp_ForSerial (POHdr_ID,Item_ID,Item_Desc,AcptQty) VALUES ('" & POHdr_ID & "','" & Item_ID & "','" & Item_Desc & "','" & AcptQty & "')", CommandType.Text)

                                objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
                                objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
                                objDerived.cmd.Parameters.AddWithValue("@Item_Desc", Item_Desc)
                                objDerived.cmd.Parameters.AddWithValue("@AcptQty", AcptQty)
                                objDerived.Execute("[AMS].[spSave_Temp_ForSerial]", CommandType.StoredProcedure, Nothing)

                            End If
                        Next

                        pItemForSerial = objDerived.GetDataTable("EXEC [AMS].[sp_Acceptance_SerialNo_List] '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
                        grdSerial.DataSource = pItemForSerial
                        grdSerial.DataBind()

                        grdSerial.Columns(3).Visible = False
                        ModalPopupExtender1.Show()
                    End If



                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Else

        End If
    End Sub
    Protected Sub btnRcvPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "Rcv"
        ' Me.Page.Response.Redirect("~/procurement/t_rpt_receiving.aspx")


        Dim url As String = "t_rpt_receiving.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Save1()
    End Sub
    Public Sub Save1()
        btnSave.Enabled = False
        '========================== ACCEPTANCE ==========================
        Dim Quanityx As Integer = 0
        Dim ReceivedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("ReceivedBY") & "'", CommandType.Text)
        Dim InspectedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE Signatory_ID = '" & pInspection_detail.Rows(0)("InspectedBy") & "'", CommandType.Text)

        '=-= SAVE AMS.AIR_Hdr
        Dim AIR_No As String = supplies.GetValue("select [AMS].[func_GenerateAIR]( '" & txtAcceptDate.Text & "')", CommandType.Text)
        With AIR_Hdr
            .AIR_No = AIR_No
            .AIR_Date = txtAcceptDate.Text
            .Invoice_No = txtInvoiceNumber.Text
            .Invoice_date = txtInvoiceDate.Text
            .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
            .PO_No = grdAIR.SelectedDataKey("PO_No")
            .Supplier_ID = grdAIR.SelectedDataKey("Supplier_Id")
            .Date_Received = pInspection_detail.Rows(0)("Received_Date")
            .Date_Inspect = pInspection_detail.Rows(0)("Received_Date")
            .Date_Accepted = txtAcceptDate.Text
            .Signatory1 = ReceivedBy
            .Signatory2 = InspectedBy
            .Signatory3 = ddAcceptedBy.SelectedItem.Text
            .Trans_ID = 1
            .remarks = txtRemarks.Text

            If rbStatus.SelectedItem.Value = 2 Then
                .isComplete = True
            Else
                .isComplete = False
            End If

            If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                .RC_ID = ddDepartment.SelectedItem.Value
                .Function_ID = ddFunction.SelectedItem.Value
            Else
                .RC_ID = grdAIR.SelectedDataKey("RC_ID")
                .Function_ID = grdAIR.SelectedDataKey("Function_ID")
            End If

            Dim Box As CheckBox
            For a As Integer = 0 To grdInspection.Rows.Count - 1
                Box = CType(Me.grdInspection.Rows(a).Cells(0).FindControl("cbInspection"), CheckBox)
                If Box.Checked = True Then
                    Dim zx As Long = pInspection_detail.Rows(a)("Received_ID")
                    Session("xReceived_ID") = zx
                    Exit For
                End If
            Next

            .Received_ID = Session("xReceived_ID")
            .UserID = Session("@UserName")

        End With

        Dim xAIRHdr_ID As Long = AIR_Hdr.save
        Session("AIRHdr_ID") = xAIRHdr_ID


        Dim cb As CheckBox
        For x As Integer = 0 To grdInspection.Rows.Count - 1
            cb = CType(Me.grdInspection.Rows(x).Cells(0).FindControl("cbInspection"), CheckBox)
            If cb.Checked = True Then
                Dim AcptQty As Decimal = CType(CType(grdInspection.Rows(x).FindControl("txtActQty"), TextBox).Text, Decimal)

                '=-= SAVE AMS.AIR_Dtl
                With AIR_Dtl
                    .AIRHdr_ID = xAIRHdr_ID
                    .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                    .Qty = AcptQty
                    .Cost = pInspection_detail.Rows(x)("Cost")
                    .GA_ID = grdAIR.SelectedDataKey("GA_ID")
                    .Warranty = txtWarranty.Text
                End With

                Dim AIRDtl_ID As Long = AIR_Dtl.save
                objDerived.GetRecords("UPDATE AMS.AIR_Dtl SET  OtherSpecs = '" & pInspection_detail.Rows(x)("OtherSpecs") & "', isAccepted = 1 WHERE AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)


                '============== CAPITAL OUTLAY ==============
                '=-= SAVE AMS.PROPERTY
                Dim Particular_Desc As String = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id WHERE dbo.m_item.Item_ID = '" & pInspection_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
                Dim PropCode As String = objDerived.GetValue("SELECT GA_Code FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

                With Prop_Hdr
                    .Property_Date = txtAcceptDate.Text
                    .Property_code = PropCode
                    .AIRDtl_ID = AIRDtl_ID
                    .GA_ID = grdAIR.SelectedDataKey("GA_ID")
                    .Particular = Particular_Desc
                    .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                    .Qty = AcptQty
                    .Balance = AcptQty
                    .Issuance = 0
                    .Cost = pInspection_detail.Rows(x)("Cost")
                    .Project_ID = 0
                    .Program_id = 0
                    .Emp_ID = 0
                    .TD_ID = 1
                    .F_ID = 1
                    .Remarks = ""
                    .isDonated = False
                    .DonationRemarks = ""

                    If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                        .RC_ID = ddDepartment.SelectedItem.Value
                        .Function_ID = ddFunction.SelectedItem.Value
                        Session("RC_ID") = ddDepartment.SelectedItem.Value
                        Session("Function_ID") = ddFunction.SelectedItem.Value

                    Else
                        .RC_ID = grdAIR.SelectedDataKey("RC_ID")
                        .Function_ID = grdAIR.SelectedDataKey("Function_ID")
                        Session("RC_ID") = grdAIR.SelectedDataKey("RC_ID")
                        Session("Function_ID") = grdAIR.SelectedDataKey("Function_ID")
                    End If

                    .POHdr_ID = grdAIR.SelectedDataKey("POHdr_ID")
                    .Received_ID = Session("xReceived_ID")
                    .UserID = Session("@UserName")

                End With

                Dim Item_ID As Integer = pInspection_detail.Rows(x)("Item_ID")
                Dim PropHdr_ID As Long = Prop_Hdr.save
                objDerived.Execute("UPDATE [AMS].[Property] SET [OtherSpecs] = '" & pInspection_detail.Rows(x)("OtherSpecs") & "' WHERE [Property_ID] = " & PropHdr_ID & "", CommandType.Text)


                Dim dt1 As New DataTable
                dt1 = objDerived.GetDataTable("EXEC [AMS].[sp_Acceptance_SerialNo_List] '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

                grdSerial.Columns(3).Visible = True
                '=-= SAVE AMS.PROPERTY_DTL
                Dim a As String = objDerived.GetValue("SELECT DISTINCT dbo.tbl_Classification.ClassificationName " &
                         "FROM dbo.tbl_SubClassification INNER JOIN " &
                         "dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId INNER JOIN " &
                         "dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID " &
                         "WHERE dbo.m_item.Item_ID = '" & pInspection_detail.Rows(x)("Item_ID") & "'", CommandType.Text)

                If a = "Vehicle" Then
                    Dim PropDtl_ID As Integer

                    For Quanity As Integer = 1 To 1
                        If CType(grdSerialVehicles.Rows(Quanityx).FindControl("lblItem_ID1"), Label).Text = pInspection_detail.Rows(x)("Item_ID") Then
                            Dim PropertyNumber As String = supplies.GetValue("SELECT [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtAcceptDate.Text & "', '" & PropCode & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "')", CommandType.Text)
                            Dim Prop_Dtl As New t_property_dtl
                            With Prop_Dtl
                                .PropertyNo = PropertyNumber
                                .Property_ID = PropHdr_ID
                                .Barcode = ""
                                .SerialNo = CType(grdSerialVehicles.Rows(Quanityx).FindControl("txtSerialNo"), TextBox).Text
                                .Amount = pInspection_detail.Rows(x)("Cost")
                                .type = Particular_Desc
                                .Issued = False
                                .Repair = False
                                .Details = ""
                                .F_ID = 1
                                .Status = "Accepted"
                                .IsInspectionForDisposal = False
                                .InspectionDate = "1/1/1900"
                                .Dispose = False
                                .DisposeDate = "1/1/1900"
                                .UserID = Session("@UserName")
                                '.save()
                            End With

                            PropDtl_ID = Prop_Dtl.save()
                        End If

                        If a = "Vehicle" Then
                            '121320231
                            With objMotorInfo
                                .Motor_InfoId = 0
                                .AIRDtl_ID = 0
                                .IsAccepted = True
                                .Property_Dtl_ID = PropDtl_ID
                                .Name = grdSerialVehicles.Rows(Quanityx).Cells(1).Text
                                .PlateNo = CType(grdSerialVehicles.Rows(Quanityx).FindControl("txtLicensePlateNo"), TextBox).Text
                                .MotorNo = ""
                                .Model = ""
                                .ChasisNo = CType(grdSerialVehicles.Rows(Quanityx).FindControl("txtChasisNo"), TextBox).Text
                                .VehicleColor = ""
                                .WheelsCapacity = ""
                                .GrossWeight = ""
                                .Seats = ""
                                .Warranty = ""
                                .VehicleOwner = ""
                                .DeclaredName = ""
                                .BeneficialUser = ""
                                .VehicleSpecification = ""
                                .VehicleDesc = grdSerialVehicles.Rows(Quanityx).Cells(1).Text
                                .VehicleMake = ""
                                .VehicleType = ""
                                .PowerInput = ""
                                .MVfileNo = CType(grdSerialVehicles.Rows(Quanityx).FindControl("txtMvfileno"), TextBox).Text
                                .ConSticker = CType(grdSerialVehicles.Rows(Quanityx).FindControl("txtConsticker"), TextBox).Text
                                .DepRate = 0
                                .DepValue = 0
                                .NoofYears = 0
                                .UsefulLife = 0
                                .SalvageValue = 0
                            End With
                            Dim motor_info_id As Integer
                            motor_info_id = objMotorInfo.save()

                            objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Received_ID = 0, Received_Dtl_ID = 0 WHERE Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)

                            With objMotorDtl
                                .MotorID = 0
                                .Motor_InfoId = motor_info_id
                                .Property_Dtl_ID = PropDtl_ID
                                .MarketValue = 0
                                .Condition = ""
                                .Location = ""
                                .Status = "Accepted"
                            End With
                            objMotorDtl.save()
                        End If
                        Quanityx = Quanityx + 1
                    Next
                Else
                    Dim PropDtl_ID As Integer
                    For Quanity As Integer = 0 To grdSerial.Rows.Count - 1
                        If CType(grdSerial.Rows(Quanity).FindControl("lblItem_ID"), Label).Text = pInspection_detail.Rows(x)("Item_ID") Then

                            Dim PropertyNumber As String = supplies.GetValue("SELECT [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtAcceptDate.Text & "', '" & PropCode & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "')", CommandType.Text)
                            Dim Prop_Dtl As New t_property_dtl
                            With Prop_Dtl
                                .PropertyNo = PropertyNumber
                                .Property_ID = PropHdr_ID
                                .Barcode = ""
                                .SerialNo = CType(grdSerial.Rows(Quanity).FindControl("txtSerialNo"), TextBox).Text
                                .Amount = pInspection_detail.Rows(x)("Cost")
                                .type = Particular_Desc
                                .Issued = False
                                .Repair = False
                                .Details = ""
                                .F_ID = 1
                                .Status = "Accepted"
                                .IsInspectionForDisposal = False
                                .InspectionDate = "1/1/1900"
                                .Dispose = False
                                .DisposeDate = "1/1/1900"
                                .UserID = Session("@UserName")
                                '.save()
                            End With

                            PropDtl_ID = Prop_Dtl.save()
                        End If

                    Next
                End If




                grdSerial.Columns(3).Visible = False

                Dim asv As String = pInspection_detail.Rows(x)("Item_ID")

                Dim Remarks = objDerived.GetValue("select count(*) from [AMS].[TbProperty_Ledger] WHERE Item_ID = " & pInspection_detail.Rows(x)("Item_ID") & "", CommandType.Text)

                If Remarks <> 0 Then
                    With Prop_Ledger
                        .PropertyNo = ""
                        .SerialNo = ""
                        .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                        .dDate = txtAcceptDate.Text
                        .Trans_Type = "Purchase Order Delivered"
                        .Ref = AIR_No
                        .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                        .AcceptedBy = ddAcceptedBy.SelectedItem.Text
                        .InspectedBy = InspectedBy
                        .DebitQty = AcptQty
                        .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
                        .DebitUnit = pInspection_detail.Rows(x)("Unit")
                        .CreditQty = 0
                        .CreditCost = "0.00"
                        .CreditUnit = " - "
                        .BalanceUnit = pInspection_detail.Rows(x)("Unit")

                        If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                            .Department = ddDepartment.SelectedItem.Text
                        Else
                            .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                        End If
                        .save()
                    End With
                Else
                    With Prop_Ledger
                        .PropertyNo = ""
                        .SerialNo = ""
                        .Item_ID = pInspection_detail.Rows(x)("Item_ID")
                        .dDate = txtAcceptDate.Text
                        .Trans_Type = "Starting Inventory"
                        .Ref = AIR_No
                        .AccountablePerson = objDerived.GetValue("SELECT SuppName FROM dbo.Supplier WHERE Supplier_Id = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
                        .AcceptedBy = ddAcceptedBy.SelectedItem.Text
                        .InspectedBy = InspectedBy
                        .DebitQty = AcptQty
                        .DebitCost = FormatNumber(AcptQty * pInspection_detail.Rows(x)("Cost"), 2)
                        .DebitUnit = pInspection_detail.Rows(x)("Unit")
                        .CreditQty = 0
                        .CreditCost = "0.00"
                        .CreditUnit = " - "
                        .BalanceUnit = pInspection_detail.Rows(x)("Unit")

                        If grdAIR.SelectedDataKey("RC_ID") = 0 Then
                            .Department = ddDepartment.SelectedItem.Text
                        Else
                            .Department = objDerived.GetValue("SELECT RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & grdAIR.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                        End If
                        .save()
                    End With
                End If




            End If
        Next


        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        btnActSave.Enabled = False
        btnActPreview.Enabled = True
        LoadAllItems()
        LoadSearchBy()
        ''11242022
    End Sub
    Protected Sub btnActPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "IAR"

        ' Me.Page.Response.Redirect("~/MainReports/IAR_Reports.aspx")
        'Me.Page.Response.Redirect("~/Procurement/rpt_inspection_and_acceptance.aspx")


        Dim url As String = "IAR_Reports.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub
    Protected Sub btnSearchPO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List_ByPO] '" & txtPO.Text & "'", CommandType.Text)
        'If pPurchase_Order.Rows.Count < 5 Then
        '    pPurchase_Order.Merge(CreateTable1(5 - pPurchase_Order.Rows.Count))
        'End If
        'grdAIR.DataSource = pPurchase_Order
        'grdAIR.DataBind()
        'grdAIR.SelectedIndex = -1

        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List]", CommandType.Text)

        Dim myview As DataView
        myview = pPurchase_Order.DefaultView
        myview.RowFilter = "PO_No like '%" & replaceapostrophe(txtPO.Text) & "%'"
        grdAIR.DataSource = myview
        grdAIR.DataBind()
        grdAIR.SelectedIndex = -1

    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub btnSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List_BySupplier] '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
        'If pPurchase_Order.Rows.Count < 5 Then
        '    pPurchase_Order.Merge(CreateTable1(5 - pPurchase_Order.Rows.Count))
        'End If
        'grdAIR.DataSource = pPurchase_Order
        'grdAIR.DataBind()
        'grdAIR.SelectedIndex = -1

        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List]", CommandType.Text)

        Dim myview As DataView
        myview = pPurchase_Order.DefaultView
        myview.RowFilter = "Supplier_Id = '" & ddSupplier.SelectedItem.Value & "'"
        grdAIR.DataSource = myview
        grdAIR.DataBind()
        grdAIR.SelectedIndex = -1
    End Sub
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AllotmentClass_ID As Long
        AllotmentClass_ID = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdAIR.SelectedDataKey("GA_ID") & "'", CommandType.Text)

        If AllotmentClass_ID = 2 Then
            Dim cb As CheckBox
            Session("cb") = 0
            For i As Integer = 0 To grdItems.Rows.Count - 1
                cb = CType(Me.grdItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Checked = True Then
                    Session("cb") = 1
                    Exit For
                End If
            Next

            Dim dt As New DataTable
            Dim cb1 As CheckBox
            For x As Integer = 0 To grdItems.Rows.Count - 1
                cb1 = CType(Me.grdItems.Rows(x).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb1.Checked = True Then
                    Dim a As String = pPurchase_Order_detail.Rows(x)("Item_ID")
                    dt = objDerived.GetDataTable("EXEC [AMS].[sp_Receipt_and_Inspection_Dtl] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & pPurchase_Order_detail.Rows(x)("Item_ID") & "'", CommandType.Text)
                    txtOfficeItemDesc.Text = dt.Rows(0).Item("Description").ToString
                    txtOfficeBrandName.Text = dt.Rows(0).Item("Brand").ToString
                    txtOfficeSize.Text = dt.Rows(0).Item("Size").ToString
                    txtOfficeColor.Text = dt.Rows(0).Item("Color").ToString
                    txtOfficeDepRate.Text = dt.Rows(0).Item("DepRate").ToString
                    txtOfficeDepValue.Text = dt.Rows(0).Item("Depvalue").ToString
                    txtOfficeCategory.Text = dt.Rows(0).Item("Category").ToString
                Else

                End If
            Next

        ElseIf AllotmentClass_ID = 3 Then

            Dim dt As New DataTable
            Dim cb1 As CheckBox
            For xx1 As Integer = 0 To grdItems.Rows.Count - 1
                cb1 = CType(Me.grdItems.Rows(xx1).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb1.Checked = True Then
                    Dim a As String = pPurchase_Order_detail.Rows(xx1)("Item_ID")
                    dt = objDerived.GetDataTable("EXEC [AMS].[sp_Receipt_and_Inspection_Dtl] '" & grdAIR.SelectedDataKey("POHdr_ID") & "','" & pPurchase_Order_detail.Rows(xx1)("Item_ID") & "'", CommandType.Text)
                    txtCO_MName.Text = dt.Rows(0).Item("Description").ToString
                    txtCO_Name.Text = dt.Rows(0).Item("Description").ToString
                    txtCO_Description.Text = dt.Rows(0).Item("Description").ToString
                Else

                End If
            Next

            Dim cb As CheckBox
            Dim x As Integer = 0
            Session("cb") = 0
            For i As Integer = 0 To grdItems.Rows.Count - 1
                If x = 0 Then
                    cb = CType(Me.grdItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If cb.Checked = True Then
                        x = 1
                        Session("cb") = 1
                    ElseIf cb.Checked = False Then
                        cb.Enabled = True
                    End If
                Else
                    For p As Integer = 0 To grdItems.Rows.Count - 1
                        cb = CType(Me.grdItems.Rows(p).Cells(0).FindControl("CheckBox1"), CheckBox)
                        If cb.Checked = True Then
                            cb.Enabled = True
                        ElseIf cb.Checked = False Then
                            cb.Enabled = False
                        End If
                    Next
                    Exit For
                End If
            Next
        End If



        If Session("cb") = 1 Then
            btnRcvSave.Enabled = True
        Else
            btnRcvSave.Enabled = False
        End If
    End Sub
    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List_BySupplier] '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
        'If pPurchase_Order.Rows.Count < 5 Then
        '    pPurchase_Order.Merge(CreateTable1(5 - pPurchase_Order.Rows.Count))
        'End If
        'grdAIR.DataSource = pPurchase_Order
        'grdAIR.DataBind()
        'grdAIR.SelectedIndex = -1

        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List]", CommandType.Text)

        Dim myview As DataView
        myview = pPurchase_Order.DefaultView
        myview.RowFilter = "Supplier_Id = '" & ddSupplier.SelectedItem.Value & "'"
        grdAIR.DataSource = myview
        grdAIR.DataBind()
        grdAIR.SelectedIndex = -1

    End Sub
    Protected Sub txtMarketValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtMarketValue As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtMarketValue.NamingContainer, GridViewRow)

        txtMarketValue.Text = FormatNumber(txtMarketValue.Text, 2)
    End Sub
    Protected Sub txtActQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtActQty As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtActQty.NamingContainer, GridViewRow)
        If txtActQty.Text = "" Then
            txtActQty.Text = "0"
        End If
        txtActQty.Text = FormatNumber(txtActQty.Text, 2)

        ''here 2
        'Dim cb5 As CheckBox
        'Dim x1 As Integer = 0
        'Dim x2 As Integer = 0
        'For xxx As Integer = 0 To grdInspection.Rows.Count - 1
        '    cb5 = CType(Me.grdInspection.Rows(xxx).Cells(0).FindControl("cbInspection"), CheckBox)

        '    If cb5.Checked = True Then
        '        x1 = x1 + 1
        '    Else

        '    End If

        'Next


        'Dim a1 As Integer = 0
        'Try
        '    If pInspection_detail.Rows.Count > 0 Then
        '        Dim a As Double = 0
        '        For i As Integer = 0 To pInspection_detail.Rows.Count - 1
        '            Dim b As String = CType(CType(grdInspection.Rows(i).FindControl("txtActQty"), TextBox).Text, String)
        '            a = a + Val(b)
        '        Next
        '        a1 = a
        '    Else

        '        a1 = 0
        '    End If

        'Catch ex As Exception

        'End Try

        'If (x1) = (txtHiddenReceiveQty.Value) And a1 = Val(txtHidenQTY.Value) Then
        '    rbStatus.Items.Item(1).Enabled = True
        'Else
        '    rbStatus.Items.Item(1).Selected = False
        '    rbStatus.Items.Item(0).Selected = True
        '    rbStatus.Items.Item(1).Enabled = False

        'End If
        'x1 = 0
        ''End here 2
    End Sub
    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'HERE
        Dim item As String

        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Val(txtHiddenReceiveQty.Value) - 1
                item = Me.grdInspection.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                    btnActSave.Enabled = True
                    ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = True
                    'pInspection_detail.Rows(Me.grdInspection.Rows(i).Cells(4).Text)("isChecked") = True


                End If
            Next
        Else
            For i As Integer = 0 To Val(txtHiddenReceiveQty.Value) - 1
                item = Me.grdInspection.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdInspection.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                s.Checked = False
                ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = False
                ' pInspection_detail.Rows(Me.grdInspection.Rows(i).Cells(4).Text)("isChecked") = False
            Next
        End If


    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            '=============== CHECK IF PUBLIC BIDDING
            Dim MOP_ID As Integer = objDerived.GetValue("SELECT mode_of_procurement_id FROM [AMS].[PO_Hdr] WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            If MOP_ID = 1 Then
                objDerived.GetRecords("UPDATE [AMS].[Bid_Information] SET [withNTP] = 0 WHERE [pre_procurement_hdr_id] = '" & grdAIR.SelectedDataKey("pre_procurement_hdr_id") & "' AND [Supplier_ID] = '" & grdAIR.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Else
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT * FROM AMS.Tb_Receiving WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

                If dt.Rows.Count = 0 Then
                    objDerived.GetRecords("UPDATE AMS.PO_Hdr SET isApproved = 0 WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been returned to PO approval.")
                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase Order was already received.")
                End If
            End If


            LoadSearchBy()
            grdItems.DataSource = CreateTable2(5)
            grdItems.DataBind()

            grdInspection.DataSource = CreateTable3(5)
            grdInspection.DataBind()

            btnReturn.Enabled = False

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnNoIAR_Click(sender As Object, e As EventArgs) Handles btnNoIAR.Click
        objDerived.Execute("UPDATE AMS.PO_Hdr SET [withIAR] = 0 WHERE POHdr_ID = '" & grdAIR.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
    End Sub
    Protected Sub btnNA_Click(sender As Object, e As EventArgs) Handles btnNA.Click
        For i As Integer = 0 To grdSerial.Rows.Count - 1
            CType(grdSerial.Rows(i).FindControl("txtSerialNo"), TextBox).Text = "N/A"

        Next

        ModalPopupExtender1.Show()
    End Sub
    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Save1()
    End Sub
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        For i As Integer = 0 To grdSerialVehicles.Rows.Count - 1
            CType(grdSerialVehicles.Rows(i).FindControl("txtSerialNo"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtChasisNo"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtLicensePlateNo"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtMvfileno"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtConsticker"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtChasis_No"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtVehicle_color"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtCS_no"), TextBox).Text = "N/A"
            CType(grdSerialVehicles.Rows(i).FindControl("txtEngine_No"), TextBox).Text = "N/A"

        Next

        ModalPopupExtender2.Show()
    End Sub
End Class
