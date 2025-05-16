
Imports System.Data

Partial Class Records_t_StockCard_v2_MRO
    Inherits System.Web.UI.Page

    Dim objDerived As New DerivedDal
    Dim objx As New AccessRule

    Private Property PListofGL() As DataTable
        Get
            Return CType(Session("PListofGL"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PListofGL") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' MsgBox(port)
        objx.GetAccessRight(Me.Session("@UserName"), page)
        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If
        If Not Page.IsPostBack Then
            Dim MROClass As String = Request.QueryString("val")
            '  Dim mroclassification() As String = 

            ' msgbox(MROClass.Substring(3))

            Dim dtClassification As New DataTable
            dtClassification = objDerived.GetDataTable("select [ClassificationId],[ClassificationName],* From [dbo].[tbl_Classification] where [ClassificationName] like 'Equipment%'", CommandType.Text)
            Me.ddClass.DataSource = CType(dtClassification, DataTable)
            Me.ddClass.DataTextField = ("ClassificationName")
            Me.ddClass.DataValueField = ("ClassificationId")
            Me.ddClass.DataBind()
            selectClassification()
            txtDate.text = Date.Now.ToString("MM-dd-yyyy")



        End If
    End Sub


    Protected Sub grdStockList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        'Dim Stocktable As New DataTable
        ''Stocktable = objDerived.GetDataTable("SELECT * from [dbo].[View_StockSupplies] where  GA_ID = '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        'Stocktable = objDerived.GetDataTable("EXEC spMedicineSupplies '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)

        Dim dtStock As New DataTable

        '  dtStock = objDerived.GetDataTable("EXEC [dbo].[sp_SMSSStockSupplies] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022] '" & ddGlAccount.SelectedValue() & "','0','CY2022'", CommandType.Text)

        If dtStock.Rows.Count < 10 Then
            dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
        End If
        grdStockList.PageIndex = e.NewPageIndex
        grdStockList.DataSource = dtStock
        grdStockList.DataBind()

    End Sub

    Public Function SelectGAaccount()
        Dim dt As New DataTable
        Dim GLaccount As String
        If ddGlAccount.text = "" Then
            GLaccount = 0
        Else
            GLaccount = ddGlAccount.selecteditem.value
        End If
        dt = objDerived.GetDataTable("select item_particular_id,description From AMS.item_particular where GA_ID ='" & GLaccount & "'", CommandType.Text)
        ddCategory.datasource = dt
        ddCategory.DataTextField = ("description")
        ddCategory.DataValueField = ("item_particular_id")
        ddCategory.DataBind()
        selectCatergory()
        '  MultiviewSupplier()
        '        MultiviewSupplier()
    End Function

    Protected Sub ddGlAccount_SelectedIndexChanged(sender As Object, e As EventArgs)
        SelectGAaccount()
    End Sub
    Public Function selectClassification()
        lblClass.text = ddClass.selecteditem.text
        lblClass1.text = ddClass.selecteditem.text
        PListofGL = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & ddClass.selecteditem.value & "'", CommandType.Text)
        Me.ddGlAccount.items.add("Select")
        Me.ddGlAccount.DataSource = CType(PListofGL, DataTable)
        Me.ddGlAccount.DataTextField = ("GA_Title")
        Me.ddGlAccount.DataValueField = ("GA_ID")
        Me.ddGlAccount.DataBind()
        Me.ddGlAccount.enabled = True
        SelectGAaccount()
    End Function
    Protected Sub ddClass_SelectedIndexChanged(sender As Object, e As EventArgs)

        selectClassification()

    End Sub
    Public Function selectCatergory()
        Dim subcategory As New DataTable
        Dim Categoryid As Integer
        If ddCategory.text = "" Then
            Categoryid = 0
        Else
            Categoryid = ddCategory.selecteditem.value
        End If
        subcategory = objDerived.GetDataTable("select [SubCategoryID],[SubCat_Desc]  From [dbo].[tbl_SubCategory] where item_particular_id = '" & Categoryid & "'", CommandType.Text)
        ddSubCategory.datasource = subcategory
        ddSubCategory.DataTextField = ("SubCat_Desc")
        ddSubCategory.DataValueField = ("SubCategoryID")
        ddSubCategory.DataBind()
        ddSubCategory.enabled = True
        loadStockOfficeSupplies()
        '  MultiviewSupplier()
    End Function
    Public Function createdatatable1B(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("unit", GetType(String))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("reorderPT", GetType(Integer))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("Location", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_ID") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("unit") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("reorderPT") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("Location") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Protected Sub loadStockOfficeSupplies()

        Dim dtStock As New DataTable
        ' dtStock = objDerived.GetDataTable("Exec [dbo].[sp_SMSSStockSupplies] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022] '" & ddGlAccount.SelectedValue() & "','0','CY2022','" & ddCategory.SelectedValue() & "','" & ddSubCategory.selectedvalue() & "'", CommandType.Text)
        If dtStock.Rows.Count < 10 Then
            dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
        End If
        grdStockList.DataSource = dtStock
        grdStockList.DataBind()
        grdStockList.SelectedIndex = 0
        ' grdStockList.columns(0).Visible = False
        '  LoadStockChangeIndex()

        ' grdStockList.SelectedIndex = -1

    End Sub


    Protected Sub ddCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectCatergory()

    End Sub

    Protected Sub grdStockList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdStockList.RowDataBound

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdStockList, "Select$" + e.Row.RowIndex.ToString()))
            '  e.Row.Cells(0).Visible = False

            If e.Row.Cells(4).Text <= e.Row.Cells(6).Text Then
                e.Row.Cells(4).BackColor = IIf(CStr(e.Row.Cells(6).Text).ToString = "&nbsp;", Drawing.Color.Empty, Drawing.Color.Red)
            End If
        End If
        '  e.Row.Cells(0).Visible = False
        '=-= Notify if Balance reach re-order point
        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    If e.Row.Cells(4).Text = "&nbsp;" Then
        '        Exit Sub
        '    Else
        '        If CInt(e.Row.Cells(3).Text) <= CInt(e.Row.Cells(4).Text) Then  'e.Row.Cells(4).Text <= e.Row.Cells(3).Text Then
        '            e.Row.BackColor = Drawing.Color.OrangeRed
        '        End If
        '    End If
        'End If
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "")
    End Function
    Protected Sub loadSearch()
        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [dbo].[sp_SMSSStockSupplies_Search_v1_02092022] '" & ddGlAccount.SelectedItem.Value & "', '%" & replaceapostrophe(txtSearchStock.Text) & "%','" & ddCategory.selecteditem.value & "'", CommandType.Text)
        If dtStock.Rows.Count < 10 Then
            dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
        End If
        grdStockList.DataSource = dtStock
        grdStockList.DataBind()
        grdStockList.SelectedIndex = 0

    End Sub
    Protected Sub btnSearchStock_Click(sender As Object, e As EventArgs)
        loadSearch()
    End Sub
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("ponumber", GetType(String))
        dt.Columns.Add("batch", GetType(String))
        dt.Columns.Add("lot", GetType(String))
        dt.Columns.Add("quantity", GetType(Decimal))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("qtybox", GetType(String))
        dt.Columns.Add("TotalPcs", GetType(Decimal))
        dt.Columns.Add("actualprice", GetType(Decimal))
        dt.Columns.Add("deliverydate", GetType(String))
        dt.Columns.Add("expirydate", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("Received_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("ponumber") = DBNull.Value
            dr("batch") = DBNull.Value
            dr("lot") = DBNull.Value
            dr("quantity") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("qtybox") = DBNull.Value
            dr("TotalPcs") = DBNull.Value
            dr("actualprice") = DBNull.Value
            dr("deliverydate") = DBNull.Value
            dr("expirydate") = DBNull.Value
            dr("POHdr_ID") = DBNull.Value
            dr("Received_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Protected Sub loadCleartext()

        'lnksupplieroffice.Text = ""
        txtItemDesc2.Text = ""
        txtBrandName2.Text = ""
        txtSize.Text = ""
        txtColor.Text = ""
        txtDepRate.Text = ""

        '        txtCategory.Text = ""
        txtLenght.Text = ""
        txtWidth.Text = ""
        txtHeight.Text = ""
        txtWeight.Text = ""
        txtDepValue.Text = ""

        lnksuppliermed.Text = ""
        txtItemDesc2.Text = ""
        txtBrandName2.Text = ""
        '   txtDose.Text = ""
        txtDepRate.Text = ""
        txtDepValue.Text = ""

        '     txtForm.Text = ""
        '   txtOTC.Text = ""
        '  txtBatch.Text = ""
        '  txtLot.Text = ""
        ' txtMDate.Text = ""
        txtEDate.Text = ""
        txtAlert.Text = ""
        txtUnitPrice.text = ""
        txtQuantity.text = ""
        txtBay.text = ""
        txtColumn.text = ""
        txtFloor.text = ""
        txtRoom.text = ""
        txtShelves.text = ""
        txtRack.text = ""
        txtBin.text = ""
    End Sub
    Public Sub loadwarehouse()
        Dim dt As New datatable
        Dim obj As New BaseClasses.Items
        dt = obj.getdatatable("select warehouse_id,wname From ams.loc_warehouse", commandtype.text)
        drpWarehouse.DataTextField = ("wname")
        drpWarehouse.DataValueField = ("warehouse_id")
        drpWarehouse.datasource = dt
        drpWarehouse.databind()

        drpMROConsOthersWarehouse.DataTextField = ("wname")
        drpMROConsOthersWarehouse.DataValueField = ("warehouse_id")
        drpMROConsOthersWarehouse.datasource = dt
        drpMROConsOthersWarehouse.databind()




    End Sub

    Public Sub SelectMROConsOthers()
        If grdStockList.SelectedRow.Cells(3).Text <> 0 Then
            Dim dt As New DataTable

            dt = objDerived.GetDataTable("select  a.ItemDesc,a.BrandName,b.Cost,convert(int,b.Qty),a.DepreciationRate ,a.DepreciationValue,a.Form, a.Batch ,a.Lot , a.Mftgdate , a.EpiryDate, a.Alert ,isnull(b.Location,' - '),isnull(b.warehouse_id,1)   From [AMS].TbNonFood as a inner join ams.Stock as b on a.StockID = b.StockID  where a.Item_ID = " & grdStockList.SelectedDataKey("Item_ID"), commandtype.text)
            txtConsOthersName.text = dt.Rows(0).Item(0)
            txtConsOthersName.ReadOnly = False

            txtConsOthersBrandName.text = dt.Rows(0).Item(1)
            txtConsOthersBrandName.ReadOnly = False

            txtConsOthersUnitPrice.text = dt.Rows(0).Item(2)
            txtConsOthersUnitPrice.ReadOnly = False

            txtConsOthersQuantity.text = dt.Rows(0).Item(3)
            txtConsOthersQuantity.ReadOnly = False

            txtConsOthersDepValue.text = dt.Rows(0).Item(4)
            txtConsOthersDepValue.ReadOnly = False

            txtConsOthersDepRate.text = dt.Rows(0).Item(5)
            txtConsOthersDepRate.ReadOnly = False
            'txtCategory.ReadOnly = False

            txtConsOthersForm.text = dt.Rows(0).Item(6)
            txtConsOthersForm.ReadOnly = False

            txtConsOthersBatch.text = dt.Rows(0).Item(7)
            txtConsOthersBatch.ReadOnly = False

            txtConsOthersLot.text = dt.Rows(0).Item(8)
            txtConsOthersLot.ReadOnly = False

            txtMDateConsOthers.text = dt.Rows(0).Item(9)
            ' txtConsOthersQuantity.ReadOnly = False
            txtMDateConsOthers.ReadOnly = False

            txtEDateConsOthers.text = dt.Rows(0).Item(10)
            txtEDateConsOthers.ReadOnly = False

            txtAlertConsOthers.text = dt.Rows(0).Item(11)
            txtAlertConsOthers.ReadOnly = False



            '''--------------------location
            Dim location As String
            location = dt.Rows(0).Item(12)
            Dim locationsplit As String() = location.Split("-")
            If location.Contains("Bay") Then
                txtConsOthersBay.text = locationsplit(1)
            ElseIf location.Contains("Column") Then
                txtConsOthersColumn.text = locationsplit(1)
            ElseIf location.Contains("Floor") Then
                txtConsOthersFloor.text = locationsplit(1)
            ElseIf location.Contains("Room") Then
                txtConsOthersRoom.text = locationsplit(1)
            ElseIf location.Contains("Shelves") Then
                txtConsOthersShelves.text = locationsplit(1)
            ElseIf location.Contains("Rack") Then
                txtConsOthersRack.text = locationsplit(1)
            ElseIf location.Contains("Bin") Then
                txtConsOthersBin.text = locationsplit(1)
            End If

            Dim warehouse As String
            warehouse = dt.Rows(0).Item(13)
            drpMROConsOthersWarehouse.selectedvalue = warehouse

            btnConsOthersSave.enabled = False
            btnCancel.enabled = False

        Else
            Dim dt As New DataTable
            Dim obj As New BaseClasses.Items
            txtConsOthersName.text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            txtConsOthersName.ReadOnly = False

            txtConsOthersBrandName.ReadOnly = False
            txtConsOthersUnitPrice.ReadOnly = False
            txtConsOthersQuantity.ReadOnly = False

            txtConsOthersDepValue.ReadOnly = False
            txtConsOthersDepRate.ReadOnly = False
            'txtCategory.ReadOnly = False

            txtConsOthersForm.ReadOnly = False
            txtConsOthersBatch.ReadOnly = False
            txtConsOthersLot.ReadOnly = False
            ' txtConsOthersQuantity.ReadOnly = False
            txtMDateConsOthers.ReadOnly = False
            txtEDateConsOthers.ReadOnly = False
            txtAlertConsOthers.ReadOnly = False
            ' txtComponentof.ReadOnly = False
            btnConsOthersSave.enabled = True
            btnCancel.enabled = True

            ' txtItemDesc2.text = dt.Rows(0).Item(0)
        End If
    End Sub

    Public Sub SelectMROsupplies()
        If grdStockList.SelectedRow.Cells(3).Text <> 0 Then
            Dim dt As New DataTable

            dt = objDerived.GetDataTable("select a.Description,a.BrandName,a.Size,a.Color,a.DepreciatedRate,a.DepreciatedValue,a.Length,a.Width,a.Height,a.Weight,b.Cost,convert(int,b.Qty) ,isnull(b.Location,' - '),isnull(b.warehouse_id,1) ,isnull(a.componentof,'')  From [AMS].[TBSupplies_Info] as a inner join ams.Stock as b on a.StockID = b.StockID  where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), commandtype.text)

            txtItemDesc2.text = dt.Rows(0).Item(0)
            txtItemDesc2.ReadOnly = True

            txtBrandName2.text = dt.Rows(0).Item(1)
            txtBrandName2.ReadOnly = True

            txtSize.text = dt.Rows(0).Item(2)
            txtSize.ReadOnly = True

            txtColor.text = dt.Rows(0).Item(3)
            txtColor.ReadOnly = True

            txtDepRate.text = dt.Rows(0).Item(4)
            txtDepRate.ReadOnly = True
            txtDepValue.text = dt.Rows(0).Item(5)
            txtDepValue.ReadOnly = True

            'txtCategory.ReadOnly = True

            txtLenght.text = dt.Rows(0).Item(6)
            txtLenght.ReadOnly = True
            txtWidth.text = dt.Rows(0).Item(7)
            txtWidth.ReadOnly = True
            txtHeight.text = dt.Rows(0).Item(8)
            txtHeight.ReadOnly = True
            txtWeight.text = dt.Rows(0).Item(9)
            txtWeight.ReadOnly = True

            txtUnitPrice.text = dt.Rows(0).Item(10)
            txtUnitPrice.ReadOnly = True
            txtQuantity.text = dt.Rows(0).Item(11)
            txtQuantity.ReadOnly = True



            '''--------------------location
            Dim location As String
            location = dt.Rows(0).Item(12)
            Dim locationsplit As String() = location.Split("-")
            If location.Contains("Bay") Then
                txtBay.text = locationsplit(1)
            ElseIf location.Contains("Column") Then
                txtColumn.text = locationsplit(1)
            ElseIf location.Contains("Floor") Then
                txtFloor.text = locationsplit(1)
            ElseIf location.Contains("Room") Then
                txtRoom.text = locationsplit(1)
            ElseIf location.Contains("Shelves") Then
                txtShelves.text = locationsplit(1)
            ElseIf location.Contains("Rack") Then
                txtRack.text = locationsplit(1)
            ElseIf location.Contains("Bin") Then
                txtBin.text = locationsplit(1)
            End If

            Dim warehouse As String
            warehouse = dt.Rows(0).Item(13)
            drpWarehouse.selectedvalue = warehouse
            txtComponentof.text = dt.Rows(0).Item(14)
            txtComponentof.ReadOnly = True
            btnSave.enabled = False
            btnCancel.enabled = False
        Else
            Dim dt As New DataTable
            Dim obj As New BaseClasses.Items
            txtItemDesc2.text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            txtItemDesc2.ReadOnly = False

            txtBrandName2.ReadOnly = False
            txtSize.ReadOnly = False
            txtColor.ReadOnly = False
            txtDepRate.ReadOnly = False

            'txtCategory.ReadOnly = False
            txtLenght.ReadOnly = False
            txtWidth.ReadOnly = False
            txtHeight.ReadOnly = False
            txtWeight.ReadOnly = False
            txtDepValue.ReadOnly = False
            txtUnitPrice.ReadOnly = False
            txtQuantity.ReadOnly = False
            txtComponentof.ReadOnly = False
            btnSave.enabled = True
            btnCancel.enabled = True

            ' txtItemDesc2.text = dt.Rows(0).Item(0)
        End If
    End Sub

    Protected Sub LoadStockChangeIndex()

        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_StockSupplies_Batches] '" & grdStockList.SelectedDataKey("GA_ID") & "','" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatable2(3 - dtStock.Rows.Count))
        End If
        loadCleartext()
        loadwarehouse()
        grdsupplies.DataSource = dtStock
        grdsupplies.DataBind()
        grdsupplies.SelectedIndex = -1
        If ddClass.selecteditem.value = 1 Then
            SelectMROsupplies()
            Me.MultiView1.SetActiveView(Me.View2)

        Else
            Me.MultiView1.SetActiveView(Me.View1)
            SelectMROConsOthers()
        End If

        hdnItemNo.value = grdStockList.SelectedDataKey("Item_ID")
        hdnGAId.value = grdStockList.SelectedDataKey("GA_ID")

        ledger()
    End Sub

    Protected Sub ledger()
        Dim dtStock As New datatable
        Dim gaid As Integer

        If isdbnull(grdStockList.SelectedDataKey("Item_ID")) Then
            gaid = 0
        Else
            gaid = grdStockList.SelectedDataKey("Item_ID")
        End If
        dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & gaid & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
        End If
        grdLedger.DataSource = dtStock
        grdLedger.DataBind()
    End Sub
    Public Function createdatatableledger(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        dt.Columns.Add("dDate", GetType(Date))
        dt.Columns.Add("trans_type", GetType(String))
        dt.Columns.Add("ref", GetType(String))
        dt.Columns.Add("AccountablePerson", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("position", GetType(String))
        dt.Columns.Add("acceptedby", GetType(String))
        dt.Columns.Add("inspectedby", GetType(String))
        dt.Columns.Add("DebitQty", GetType(Decimal))

        dt.Columns.Add("DebitUnit", GetType(String))
        dt.Columns.Add("DebitCost", GetType(Decimal))
        dt.Columns.Add("CreditQty", GetType(Decimal))
        dt.Columns.Add("CreditUnit", GetType(String))
        dt.Columns.Add("CreditCost", GetType(Decimal))
        dt.Columns.Add("BalQty", GetType(Decimal))
        dt.Columns.Add("BalanceUnit", GetType(String))
        dt.Columns.Add("BalCost", GetType(Decimal))
        dt.Columns.Add("Cost", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            'dr("Property_Dtl_ID") = DBNull.Value
            dr("dDate") = DBNull.Value
            dr("trans_type") = DBNull.Value
            dr("ref") = DBNull.Value
            dr("AccountablePerson") = DBNull.Value
            dr("Department") = DBNull.Value
            dr("position") = DBNull.Value
            dr("acceptedby") = DBNull.Value
            dr("inspectedby") = DBNull.Value
            dr("DebitQty") = DBNull.Value
            dr("DebitUnit") = DBNull.Value
            dr("DebitCost") = DBNull.Value
            dr("CreditQty") = DBNull.Value
            dr("CreditUnit") = DBNull.Value
            dr("CreditCost") = DBNull.Value
            dr("BalQty") = DBNull.Value
            dr("BalanceUnit") = DBNull.Value
            dr("Cost") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Protected Sub grdStockList_SelectedIndexChanged(sender As Object, e As EventArgs)
        LoadStockChangeIndex()
    End Sub
    Public Sub MultiviewSupplier()
        'lblDetails.Text = "NON-FOOD DETAILS"
        txtSearchStock.Text = ""
        lblHistoryDetails.Text = "DETAILS"
        'lblHistoryDetails.Text = "NON-FOOD DETAILS"

        Me.MultiView1.SetActiveView(Me.View2)
        'imgmedical.ImageUrl = "~/images/blankImage.jpg"
        loadStockOfficeSupplies()
        'LoadSupplies()
    End Sub

    Protected Sub ddSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        MultiviewSupplier()
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        If txtItemDesc2.text = "" Or txtBrandName2.text = "" Or txtUnitPrice.text = "" Or txtQuantity.text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
        Else

            '--------------------------------------------------------------
            '=-= SAVE AMS.Tb_Receiving
            Dim rcv As New Receiving.t_receiving
            With rcv
                .Received_Date = txtDate.Text
                .ReceivedBY = 0
                .POHdr_ID = 0
                .PO_No = ""
                .Supplier_ID = 0
                .GA_ID = hdnGAId.value
                .isAccepted = False
                .UserID = Session("@UserName")
            End With
            Dim rcvID As Long = rcv.save

            Session("Received_ID") = rcvID

            Dim rcv_dtl As New Receiving.t_receiving_dtl
            Dim total As Decimal = 0
            Dim txtPrice As TextBox = CType(txtUnitPrice, TextBox)
            Dim txtqty As TextBox = CType(txtQuantity, TextBox)
            Dim location As String

            If String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                location = "Bay-" & txtBay.text
            ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                location = "Column-" & txtColumn.text
            ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                location = "Floor-" & txtFloor.text
            ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                location = "Room-" & txtRoom.text
            ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                location = "Shelves-" & txtShelves.text
            ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                location = "Rack-" & txtRack.text
            ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) Then
                location = "Bin-" & txtBin.text
            End If

            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = hdnItemNo.value
                .PO_Qty = txtqty.Text
                .Qty_Received = txtqty.Text
                .Cost = txtPrice.Text
                .Condition = ""
                .Location = location
            End With
            Dim RcvDtl_ID As Long = rcv_dtl.save

            Dim t1 As Decimal
            t1 = txtPrice.Text * txtqty.Text
            total = total + t1
            Session("ContractPrice") = total


            '=-= SAVE OF PURCHASED ORDER
            Dim pohdr_id As Long
            Dim POhdr As New t_purchase_order_hdr
            Dim POnumber As String = "Starting Inventory"


            POhdr.PO_No = POnumber
            POhdr.PO_Date = txtDate.Text
            POhdr.Supplier_ID = 0
            POhdr.mode_of_procurement_id = 2
            POhdr.DeliveryTerm = 0
            POhdr.paymentTerm = 0
            POhdr.DeliveryDate = txtDate.Text
            POhdr.DeliveryPlace = ""
            POhdr.isDelivered = True
            POhdr.isDelivered = True
            POhdr.pre_procurement_hdr_id = 0
            POhdr.withdv = False
            'POhdr.ContractPrice = CType(txtContractprice.Text, Decimal)
            POhdr.isStag = False
            POhdr.isContinueCutOff = False
            POhdr.isStopForCutOff = False
            POhdr.isShoppingA = False
            POhdr.isPublicInfra = False
            POhdr.isStraight = True
            POhdr.isApproved_PO_Mayor = True
            POhdr.isReceived_PO_Mayor = True
            POhdr.DateApproved_PO_Mayor = txtDate.Text
            POhdr.DateReceived_PO_Mayor = txtDate.Text
            POhdr.DateDisApprove = "01/01/1900"
            POhdr.isGasoline = False
            POhdr.isReimbursement = False

            Dim po_id As New DataTable
            po_id = objDerived.GetDataTable("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
            If po_id.Rows.Count = 0 Then
                POhdr.ContractPrice = CType(Session("ContractPrice"), Decimal)
                pohdr_id = POhdr.save()
            Else
                Dim poid As Integer
                Dim TAmount As Decimal
                poid = objDerived.GetValue("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
                TAmount = objDerived.GetValue("Select ContractPrice from ams.po_hdr where pohdr_id = '" & poid & "'", CommandType.Text)

                POhdr.ContractPrice = CType(TAmount + CType(Session("ContractPrice"), Decimal), Decimal)
                POhdr.POHdr_ID = poid
                pohdr_id = POhdr.update()
            End If

            objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = '" & hdnGAId.value & "', ProjectName = 'Manual Encode' WHERE POHdr_ID = '" & pohdr_id & "'", CommandType.Text)
            Session("POHdr_ID") = pohdr_id



            '=-= SAVE OF INSPECTION & ACCEPTANCE

            Dim objhdr As New t_inspection_and_acceptance_hdr
            Dim airhdr_id As Long
            Dim air As String
            air = objDerived.GetValue("select [AMS].[func_GenerateAIR]('" & txtDate.Text & "')", CommandType.Text)
            With objhdr
                .AIR_No = air
                .AIR_Date = DateTime.Parse(txtDate.Text)
                .Date_Received = DateTime.Parse(txtDate.Text)
                .Date_Inspect = DateTime.Parse(txtDate.Text)
                .Date_Accepted = DateTime.Parse(txtDate.Text)
                .Invoice_No = " "
                .Invoice_date = DateTime.Parse(txtDate.Text)
                .PO_No = " "
                .Supplier_ID = 0
                .Signatory1 = " "
                .Signatory2 = " "
                .Signatory3 = " "
                .isComplete = True
                .POHdr_ID = 0
                'objhdr.remarks = txtIAremarks.Text
                .RC_ID = 0
                .Function_ID = 0
            End With
            airhdr_id = objhdr.save()
            Session("AIRHDR_ID") = airhdr_id
            objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET UserID = '" & Session("@UserName") & "', Received_ID = '" & Session("Received_ID") & "' WHERE AIRHdr_ID = '" & Session("AIRHDR_ID") & "'", CommandType.Text)
            Dim objdtl As New t_inspection_and_acceptance_dtl


            '=-= PO Details Save
            Dim POdtl As New t_purchase_order_dtl
            Dim txtPricePO As TextBox = CType(txtUnitPrice, TextBox)
            Dim txtqtyPO As TextBox = CType(txtQuantity, TextBox)

            POdtl.POHdr_ID = Session("POHdr_ID")
            POdtl.Item_ID = hdnItemNo.value
            POdtl.cost = txtPricePO.Text
            POdtl.qty = txtqtyPO.Text
            POdtl.remarks = "Manual Encode"
            POdtl.save()

            '=-= AIR DETAILS
            Dim txtPriceair As TextBox = CType(txtUnitPrice, TextBox)
            Dim txtqtyair As TextBox = CType(txtQuantity, TextBox)

            objdtl.Item_ID = hdnItemNo.value
            objdtl.Qty = txtqtyair.Text
            objdtl.Cost = CType(txtPriceair.Text, Decimal)
            objdtl.AIRHdr_ID = Session("AIRHDR_ID")
            objdtl.GA_ID = hdnGAId.value
            Dim iaDtl_ID As Integer = objdtl.save()
            Session("AIRDtl_ID") = iaDtl_ID

            Dim objStock As New Supplies_Stock

            '=-= SAVE STOCK
            With objStock
                '.StockID = StockID
                .StockDate = DateTime.Parse(txtDate.Text)
                .Item_ID = hdnItemNo.value
                .Qty = txtqtyair.Text
                .Balance = txtqtyair.Text
                .Location = location
                .Expiration_Date = "1/1/1900"
                .Cost = CType(txtPriceair.Text, Decimal)
                .Issuance = 0
                .RC_ID = 0
                .Function_ID = 0
                .Project_ID = 0
                .Program_id = 0
                .F_ID = 4
                .AIRDtl_ID = Session("AIRDtl_ID")
                .GA_ID = hdnGAId.value
                .Warehouseid = drpWarehouse.selectedvalue()
            End With

            Dim StockID As Long = objStock.save
            objDerived.GetRecords("UPDATE AMS.Stock SET  Received_ID = '" & rcvID & "' WHERE StockID = '" & StockID & "'", CommandType.Text)

            Dim objStockLedger As New t_StockLedger
            '---------------------------------------------------------
            '====== save ledger ========
            With objStockLedger
                '.StockLedger_ID = StockLedger_ID
                .StockID = StockID
                .Trans_Type = "Starting Balance"
                .Ref = air
                '    .AccountablePerson = objDerived.GetValue("SELECT ContactP FROM  dbo.Supplier where Supplier_Id ='" & Session("Supplier_Id") & "' ", CommandType.Text)
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .ReceivedBy = ""
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .dDate = DateTime.Parse(txtDate.Text)
                .Item_ID = hdnItemNo.value
                .DebitQty = txtqtyair.Text
                .DebitCost = FormatNumber(CType(txtPriceair.Text, Decimal) * txtqtyair.Text, 2)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.value & "'", CommandType.Text)
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.value & "'", CommandType.Text)
                .BalanceQty = 0
                .BalanceCost = 0
                .save()
            End With
            Dim objOfficeSup As New SupplieINFO
            With objOfficeSup
                '.SuppliesId = SuppliesId
                .StockID = StockID
                .AIRDtl_ID = Session("AIRDtl_ID")
                .ItemId = hdnItemNo.value
                .Description = txtItemDesc2.text
                .BrandName = txtBrandName2.text
                .SupplierId = 0
                .Size = txtSize.text
                .Color = txtColor.text
                .Category = ddCategory.selecteditem.text
                .Length = txtLenght.text
                .Width = txtWidth.text
                .Height = txtHeight.text
                .Weight = txtWeight.text
                .DepreciatedValue = txtDepRate.text
                .DepreciatedRate = txtDepValue.text
                .Status = "Accepted"
                .Componentof = txtComponentof.text
            End With

            Dim Supp_ID As Long = objOfficeSup.save
            objDerived.GetRecords("UPDATE AMS.TBSupplies_Info SET Received_ID = '" & rcvID & "' WHERE SuppliesId = '" & Supp_ID & "'", CommandType.Text)
            Dim dtStock As New datatable
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.value & "'", CommandType.Text)
            If dtStock.Rows.Count < 4 Then
                dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
            End If
            grdLedger.DataSource = dtStock
            grdLedger.DataBind()
            'loadCleartext()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")
            loadStockOfficeSupplies()

        End If


    End Sub

    Protected Sub btnConsOthersSave_Click(sender As Object, e As EventArgs)
        If txtConsOthersName.text = "" Or txtConsOthersBrandName.text = "" Or txtConsOthersUnitPrice.text = "" Or txtConsOthersQuantity.text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
        Else
            '--------------------------------------------------------------
            '=-= SAVE AMS.Tb_Receiving
            Dim rcv As New Receiving.t_receiving
            With rcv
                .Received_Date = txtDate.Text
                .ReceivedBY = 0
                .POHdr_ID = 0
                .PO_No = ""
                .Supplier_ID = 0
                .GA_ID = hdnGAId.value
                .isAccepted = False
                .UserID = Session("@UserName")
            End With
            Dim rcvID As Long = rcv.save

            Session("Received_ID") = rcvID

            Dim rcv_dtl As New Receiving.t_receiving_dtl
            Dim total As Decimal = 0
            Dim txtPrice As TextBox = CType(txtConsOthersUnitPrice, TextBox)
            Dim txtqty As TextBox = CType(txtConsOthersQuantity, TextBox)
            Dim location As String

            If String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
                location = "Bay-" & txtConsOthersBay.text
            ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
                location = "Column-" & txtConsOthersColumn.text
            ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
                location = "Floor-" & txtConsOthersFloor.text
            ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
                location = "Room-" & txtConsOthersRoom.text
            ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
                location = "Shelves-" & txtConsOthersShelves.text
            ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
                location = "Rack-" & txtConsOthersRack.text
            ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) Then
                location = "Bin-" & txtConsOthersBin.text
            End If

            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = hdnItemNo.value
                .PO_Qty = txtqty.Text
                .Qty_Received = txtqty.Text
                .Cost = txtPrice.Text
                .Condition = ""
                .Location = location
            End With
            Dim RcvDtl_ID As Long = rcv_dtl.save

            Dim t1 As Decimal
            t1 = txtPrice.Text * txtqty.Text
            total = total + t1
            Session("ContractPrice") = total


            '=-= SAVE OF PURCHASED ORDER
            Dim pohdr_id As Long
            Dim POhdr As New t_purchase_order_hdr
            Dim POnumber As String = "Starting Inventory"


            POhdr.PO_No = POnumber
            POhdr.PO_Date = txtDate.Text
            POhdr.Supplier_ID = 0
            POhdr.mode_of_procurement_id = 2
            POhdr.DeliveryTerm = 0
            POhdr.paymentTerm = 0
            POhdr.DeliveryDate = txtDate.Text
            POhdr.DeliveryPlace = ""
            POhdr.isDelivered = True
            POhdr.isDelivered = True
            POhdr.pre_procurement_hdr_id = 0
            POhdr.withdv = False
            'POhdr.ContractPrice = CType(txtContractprice.Text, Decimal)
            POhdr.isStag = False
            POhdr.isContinueCutOff = False
            POhdr.isStopForCutOff = False
            POhdr.isShoppingA = False
            POhdr.isPublicInfra = False
            POhdr.isStraight = True
            POhdr.isApproved_PO_Mayor = True
            POhdr.isReceived_PO_Mayor = True
            POhdr.DateApproved_PO_Mayor = txtDate.Text
            POhdr.DateReceived_PO_Mayor = txtDate.Text
            POhdr.DateDisApprove = "01/01/1900"
            POhdr.isGasoline = False
            POhdr.isReimbursement = False

            Dim po_id As New DataTable
            po_id = objDerived.GetDataTable("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
            If po_id.Rows.Count = 0 Then
                POhdr.ContractPrice = CType(Session("ContractPrice"), Decimal)
                pohdr_id = POhdr.save()
            Else
                Dim poid As Integer
                Dim TAmount As Decimal
                poid = objDerived.GetValue("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
                TAmount = objDerived.GetValue("Select ContractPrice from ams.po_hdr where pohdr_id = '" & poid & "'", CommandType.Text)

                POhdr.ContractPrice = CType(TAmount + CType(Session("ContractPrice"), Decimal), Decimal)
                POhdr.POHdr_ID = poid
                pohdr_id = POhdr.update()
            End If

            objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = '" & hdnGAId.value & "', ProjectName = 'Manual Encode' WHERE POHdr_ID = '" & pohdr_id & "'", CommandType.Text)
            Session("POHdr_ID") = pohdr_id



            '=-= SAVE OF INSPECTION & ACCEPTANCE
            Dim objhdr As New t_inspection_and_acceptance_hdr
            Dim airhdr_id As Long
            Dim air As String
            air = objDerived.GetValue("select [AMS].[func_GenerateAIR]('" & txtDate.Text & "')", CommandType.Text)
            With objhdr
                .AIR_No = air
                .AIR_Date = DateTime.Parse(txtDate.Text)
                .Date_Received = DateTime.Parse(txtDate.Text)
                .Date_Inspect = DateTime.Parse(txtDate.Text)
                .Date_Accepted = DateTime.Parse(txtDate.Text)
                .Invoice_No = " "
                .Invoice_date = DateTime.Parse(txtDate.Text)
                .PO_No = " "
                .Supplier_ID = 0
                .Signatory1 = " "
                .Signatory2 = " "
                .Signatory3 = " "
                .isComplete = True
                .POHdr_ID = 0
                'objhdr.remarks = txtIAremarks.Text
                .RC_ID = 0
                .Function_ID = 0
            End With
            airhdr_id = objhdr.save()
            Session("AIRHDR_ID") = airhdr_id
            objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET UserID = '" & Session("@UserName") & "', Received_ID = '" & Session("Received_ID") & "' WHERE AIRHdr_ID = '" & Session("AIRHDR_ID") & "'", CommandType.Text)
            Dim objdtl As New t_inspection_and_acceptance_dtl


            '=-= PO Details Save
            Dim POdtl As New t_purchase_order_dtl
            Dim txtPricePO As TextBox = CType(txtConsOthersUnitPrice, TextBox)
            Dim txtqtyPO As TextBox = CType(txtConsOthersQuantity, TextBox)

            POdtl.POHdr_ID = Session("POHdr_ID")
            POdtl.Item_ID = hdnItemNo.value
            POdtl.cost = txtPricePO.Text
            POdtl.qty = txtqtyPO.Text
            POdtl.remarks = "Manual Encode"
            POdtl.save()

            '=-= AIR DETAILS
            Dim txtPriceair As TextBox = CType(txtConsOthersUnitPrice, TextBox)
            Dim txtqtyair As TextBox = CType(txtConsOthersQuantity, TextBox)

            objdtl.Item_ID = hdnItemNo.value
            objdtl.Qty = txtqtyair.Text
            objdtl.Cost = CType(txtPriceair.Text, Decimal)
            objdtl.AIRHdr_ID = Session("AIRHDR_ID")
            objdtl.GA_ID = hdnGAId.value
            Dim iaDtl_ID As Integer = objdtl.save()
            Session("AIRDtl_ID") = iaDtl_ID

            Dim objStock As New Supplies_Stock

            '=-= SAVE STOCK
            With objStock
                '.StockID = StockID
                .StockDate = DateTime.Parse(txtDate.Text)
                .Item_ID = hdnItemNo.value
                .Qty = txtqtyair.Text
                .Balance = txtqtyair.Text
                .Location = location
                .Expiration_Date = "1/1/1900"
                .Cost = CType(txtPriceair.Text, Decimal)
                .Issuance = 0
                .RC_ID = 0
                .Function_ID = 0
                .Project_ID = 0
                .Program_id = 0
                .F_ID = 4
                .AIRDtl_ID = Session("AIRDtl_ID")
                .GA_ID = hdnGAId.value
                .Warehouseid = drpMROConsOthersWarehouse.selectedvalue()
            End With

            Dim StockID As Long = objStock.save
            objDerived.GetRecords("UPDATE AMS.Stock SET  Received_ID = '" & rcvID & "' WHERE StockID = '" & StockID & "'", CommandType.Text)

            Dim objStockLedger As New t_StockLedger
            '---------------------------------------------------------
            '====== save ledger ========
            With objStockLedger
                '.StockLedger_ID = StockLedger_ID
                .StockID = StockID
                .Trans_Type = "Starting Balance"
                .Ref = air
                '    .AccountablePerson = objDerived.GetValue("SELECT ContactP FROM  dbo.Supplier where Supplier_Id ='" & Session("Supplier_Id") & "' ", CommandType.Text)
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .ReceivedBy = ""
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .dDate = DateTime.Parse(txtDate.Text)
                .Item_ID = hdnItemNo.value
                .DebitQty = txtqtyair.Text
                .DebitCost = FormatNumber(CType(txtPriceair.Text, Decimal) * txtqtyair.Text, 2)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.value & "'", CommandType.Text)
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.value & "'", CommandType.Text)
                .BalanceQty = 0
                .BalanceCost = 0
                .save()
            End With

            Dim objOfficeSup As New SupplieINFO
            Dim objNonFood As New ConsolidatedMedicineSaving.TbNonFood

            With objNonFood
                '.NonFood_ID = NonFood_ID
                .StockId = StockID
                .AIRDtl_ID = Session("AIRDtl_ID")
                .Item_ID = hdnItemNo.value
                .ActualPrice = txtConsOthersUnitPrice.text
                .ItemDesc = txtConsOthersName.text
                .BrandName = txtConsOthersBrandName.text
                .Supplier_Id = 0
                .Form = txtConsOthersForm.text
                .OTCRx = ""
                .Batch = txtConsOthersBatch.text
                .Lot = txtConsOthersLot.text
                .Storage = ""
                .Status = "Accepted"
                .DeliveryDate = DateTime.Parse(txtDate.Text)
                .Mftgdate = txtMDateConsOthers.text
                .EpiryDate = txtEDateConsOthers.text
                .Alert = txtAlertConsOthers.text
                .Depreciationrate = 0.0
                .Depreciationvalue = 0.0
            End With

            Dim NonFoodID As Long = objNonFood.save
            objDerived.GetRecords("UPDATE AMS.TbNonFood SET Received_ID = '" & rcvID & "' WHERE NonFood_ID = '" & NonFoodID & "'", CommandType.Text)

            Dim dtStock As New datatable
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.value & "'", CommandType.Text)
            If dtStock.Rows.Count < 4 Then
                dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
            End If
            grdLedger.DataSource = dtStock
            grdLedger.DataBind()
            'loadCleartext()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")
            loadStockOfficeSupplies()

        End If
    End Sub

    Protected Sub grdlistofEuipment_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdlistofEuipment, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdlistofEuipment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtaccount As New datatable
        dtaccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & grdStockList.SelectedDataKey("item_particular_id") & "','" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
        End If
        grdlistofEuipment.PageIndex = e.NewPageIndex
        grdlistofEuipment.DataSource = dtAccount
        grdlistofEuipment.DataBind()
        grdlistofEuipment.SelectedIndex = 0
    End Sub

    Protected Sub grdlistofEuipment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            loadEquipmentInformation()
            loadEquipmentLedger()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lblequipmentdepreciatedRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadEquipDepreciation()
    End Sub

    Protected Sub txtSalvageValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadEquipDepreciation()
    End Sub

    Public Function createdatatable4A(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Type", GetType(String))
        dt.Columns.Add("serialno", GetType(String))
        dt.Columns.Add("datepurchased", GetType(String))
        dt.Columns.Add("acquisitioncost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("status", GetType(String))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("PODtl_ID", GetType(Long))
        dt.Columns.Add("Barcode", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Received_ID", GetType(Long))
        dt.Columns.Add("Received_Date", GetType(Date))
        dt.Columns.Add("Date_Accepted", GetType(Date))
        dt.Columns.Add("useful_life", GetType(Integer))
        dt.Columns.Add("Received_Dtl_ID", GetType(Long))

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
            dr("Barcode") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("Received_ID") = DBNull.Value
            dr("Received_Date") = DBNull.Value
            dr("Date_Accepted") = DBNull.Value
            dr("useful_life") = DBNull.Value
            dr("Received_Dtl_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub loadEquipmentInformation()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("Select * from [dbo].[View_EquipmentInformation] where Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadEquipDTL()
        Else
            lblequipmentname.Text = dt.Rows(0).Item("Name").ToString
            lblequipmentdesciption.Text = dt.Rows(0).Item("Description").ToString
            lblequipmentpowerinput.Text = dt.Rows(0).Item("PowerInput").ToString
            lblequipmentdimension.Text = dt.Rows(0).Item("Dimension").ToString
            lblequipmentareacapacity.Text = dt.Rows(0).Item("AreaCapacity").ToString
            lblequipmentmodel.Text = dt.Rows(0).Item("Model").ToString
            lblequipmentwaranty.Text = dt.Rows(0).Item("Warranty").ToString
            lblSpecification.Text = dt.Rows(0).Item("Specification").ToString

            Dim DA As DateTime
            DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")
            lblNoYears.Text = Year(Date.Today.ToString("MM/dd/yyyy")) - Year(DA) & " Year/s"
            lblequipmentdepreciatedvalue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)
            lblequipmentdepreciatedRate.Text = dt.Rows(0)("DepreciationRate")
            lblUsefulLife.Text = dt.Rows(0)("useful_life")
            txtSalvageValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

            Session("useful_life") = dt.Rows(0)("useful_life")

        End If
    End Sub
    Protected Sub loadEquipmentLedger()
        btnEquipmentLedger.CssClass = "Clicked"
        btnequipmentrepairs.CssClass = "Initial"
        btnequipmentattachdoc.CssClass = "Initial"
        'Me.mvledger.SetActiveView(Me.vwledger)

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "' order by dDate", CommandType.Text)


        Dim dtAccount As New datatable


        dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        'grdLedger1.DataSource = dtAccount
        'grdLedger1.DataBind()

    End Sub


    Protected Sub LoadEquipDepreciation()
        Try
            Dim Cost As Double
            Dim SalValue As Double
            Dim TDepValue As Double
            Dim AcquisitionYear As Date
            Dim NoYears As Integer
            Dim DepVRate As Double
            Dim DepPRate As Double
            Dim ULife As Integer

            AcquisitionYear = grdlistofEuipment.SelectedDataKey("Date_Accepted")
            Cost = grdlistofEuipment.SelectedDataKey("AcquisitionCost")
            ULife = Session("useful_life")
            SalValue = FormatNumber(CType(txtSalvageValue.Text, Decimal), 2)
            NoYears = (Year(Date.Today.ToString("MM/dd/yyyy")) - Year(AcquisitionYear))

            'FORMULA USE: 
            'LET:
            'DV = DEPRECIATED VALUE
            'LFE = USEFUL LIFE
            'AC = ACQUISITION COST
            'NY = NUMBER OF YEARS FROM DATE ITEM ACQUIRED
            'DR = DEPRECIATION RATE
            'SalValue = SALVAGE VALUE
            'DepVRate = DEPRECIATION RATE AMOUNT PER YEAR
            'DepPRate = DEPRECIATION RATE PERCENT PER YEAR

            '============================
            'DEPRECIATION RATE (AMOUNT) = (COST - SALVAGE) / USEFUL LIFE
            DepVRate = ((Cost - SalValue) / ULife)

            'DEPRECIATION RATE (PERCENT) = (SALVAGE / COST) * 100
            DepPRate = FormatNumber(((DepVRate / Cost) * 100), 2)

            'TOTAL DEPRECIATION VALUE = COST - (DEP.VALUE * NO. YEARS)
            TDepValue = FormatNumber(Cost - (DepVRate * NoYears), 2)

            objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET DepreciationRate = '" & DepPRate & "',DepreciationValue = '" & TDepValue & "',SalvageValue = '" & SalValue & "' WHERE Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)

            lblequipmentdepreciatedRate.Text = DepPRate
            lblequipmentdepreciatedvalue.Text = FormatNumber(TDepValue, 2)
            txtSalvageValue.Text = FormatNumber(SalValue, 2)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub LoadEquipDTL()
        lblequipmentname.Text = ""
        lblequipmentdesciption.Text = ""
        lblequipmentpowerinput.Text = ""
        lblequipmentdepreciatedRate.Text = ""
        lblequipmentdimension.Text = ""
        lblequipmentareacapacity.Text = ""
        lblequipmentmodel.Text = ""
        lblequipmentwaranty.Text = ""
        lblequipmentdepreciatedvalue.Text = ""
        lblSpecification.Text = ""
        txtSalvageValue.Text = ""
    End Sub

End Class
