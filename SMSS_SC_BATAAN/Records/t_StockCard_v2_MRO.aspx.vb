Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Drawing

Partial Class Records_t_StockCard_v2_MRO
    Inherits System.Web.UI.Page

    Dim objDerived As New DerivedDal
    Dim objx As New AccessRule

    Private getprofile As New ProfileCommon

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
        Session("menu") = "Encoding"
        objx.GetAccessRight(Me.Session("@UserName"), Page)
        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If
        If Not Page.IsPostBack Then
            Dim MROClass As String = Request.QueryString("val")

            Page.Title = "Encoding of MRO " & MROClass.Substring(3)
            '  Dim mroclassification() As String = 
            txtDate.Text = Date.Now.ToString("MM-dd-yyyy")

            ' msgbox(MROClass.Substring(3))

            Dim dtClassification As New DataTable
            dtClassification = objDerived.GetDataTable("select [ClassificationId],[ClassificationName] From [dbo].[tbl_Classification] where [ClassificationName] like 'MRO '+'" & MROClass.Substring(3) & "%'", CommandType.Text)
            Me.ddClass.DataSource = CType(dtClassification, DataTable)
            Me.ddClass.DataTextField = ("ClassificationName")
            Me.ddClass.DataValueField = ("ClassificationId")
            Me.ddClass.DataBind()
            selectClassification()

        End If



        'ledger()
    End Sub


    Protected Sub grdStockList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

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
        If ddGlAccount.Text = "" Then
            GLaccount = 0
        Else
            GLaccount = ddGlAccount.SelectedItem.Value
        End If
        dt = objDerived.GetDataTable("select item_particular_id,description From AMS.item_particular where GA_ID ='" & GLaccount & "' order by description", CommandType.Text)
        ddCategory.DataSource = dt
        ddCategory.DataTextField = ("description")
        ddCategory.DataValueField = ("item_particular_id")
        ddCategory.DataBind()
        selectCatergory()

        '        MultiviewSupplier()
    End Function

    Protected Sub ddGlAccount_SelectedIndexChanged(sender As Object, e As EventArgs)
        SelectGAaccount()
    End Sub
    Public Function selectClassification()
        lblClass.Text = ddClass.SelectedItem.Text
        PListofGL = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & ddClass.SelectedItem.Value & "'", CommandType.Text)
        Me.ddGlAccount.Items.Add("Select")
        Me.ddGlAccount.DataSource = CType(PListofGL, DataTable)
        Me.ddGlAccount.DataTextField = ("GA_Title")
        Me.ddGlAccount.DataValueField = ("GA_ID")
        Me.ddGlAccount.DataBind()
        Me.ddGlAccount.Enabled = True
        SelectGAaccount()
    End Function
    Protected Sub ddClass_SelectedIndexChanged(sender As Object, e As EventArgs)

        selectClassification()

    End Sub
    Public Function selectCatergory()
        Dim subcategory As New DataTable
        Dim Categoryid As Integer
        If ddCategory.Text = "" Then
            Categoryid = 0
        Else
            Categoryid = ddCategory.SelectedItem.Value
        End If
        subcategory = objDerived.GetDataTable("select [SubCategoryID],[SubCat_Desc]  From [dbo].[tbl_SubCategory] where item_particular_id = '" & Categoryid & "' order by subcat_desc", CommandType.Text)
        ddSubCategory.DataSource = subcategory
        ddSubCategory.DataTextField = ("SubCat_Desc")
        ddSubCategory.DataValueField = ("SubCategoryID")
        ddSubCategory.DataBind()
        ddSubCategory.Enabled = True
        loadStockOfficeSupplies()
        MultiviewSupplier()
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

        Dim classification As String = objDerived.GetValue("select * From dbo.tbl_Classification where ClassificationName like '%Office Supplies%' ", CommandType.Text)



        Dim dtStock As New DataTable
        ' dtStock = objDerived.GetDataTable("Exec [dbo].[sp_SMSSStockSupplies] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022] '" & ddGlAccount.SelectedValue() & "','0','CY2022','" & ddCategory.SelectedValue() & "','" & ddSubCategory.SelectedValue() & "'", CommandType.Text)
        If dtStock.Rows.Count < 10 Then
            dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
        End If
        grdStockList.DataSource = dtStock
        grdStockList.DataBind()
        grdStockList.SelectedIndex = 0

        'Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_StockSupplies_Batches] '" & ddGlAccount.SelectedValue() & "','" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatable2(3 - dtStock.Rows.Count))
        End If
        loadCleartext()
        loadwarehouse()
        grdsupplies.DataSource = dtStock
        grdsupplies.DataBind()
        grdsupplies.SelectedIndex = -1
        grdStockList.SelectedIndex = -1



        ledger()

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

    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "")
    End Function
    Protected Sub loadSearch()
        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [dbo].[sp_SMSSStockSupplies_Search_v1_02092022] '" & ddGlAccount.SelectedItem.Value & "','0','CY2022','" & ddCategory.SelectedValue() & "','" & ddSubCategory.SelectedValue() & "', '%" & replaceapostrophe(txtSearchStock.Text) & "%'", CommandType.Text)
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



        ' Group the fields together based on their purpose or category
        Dim textFields() As TextBox = {
    txtItemDesc2, txtBrandName2, txtSize, txtColor, txtDepRate,
    txtLenght, txtWidth, txtHeight, txtWeight, txtDepValue,
    txtConsOthersName, txtConsOthersBrandName, txtConsOthersUnitPrice, txtConsOthersQuantity,
    txtConsOthersDepValue, txtConsOthersDepRate, txtConsOthersForm, txtConsOthersBatch, txtConsOthersLot,
    txtMDateConsOthers, txtEDateConsOthers, txtAlertConsOthers,
    txtConsOthersBay, txtConsOthersColumn, txtConsOthersFloor, txtConsOthersRoom,
    txtConsOthersShelves, txtConsOthersRack, txtConsOthersBin,
    txtMROEquipmentName, txtequipmentdesciption, txtequipmentpowerinput,
    txtequipmentmodel, txtequipmentdimension, txtEAcqCost,
    txtequipmentareacapacity, txtequipmentwaranty, txtSellectDateCons, txtDepreciationValue,
    txtUnitPrice, txtQuantity, txtBay, txtColumn, txtFloor, txtRoom, txtShelves, txtRack, txtBin,
    txtEDate, txtAlert, txtConsOthersBay, txtConsOthersColumn, txtConsOthersFloor, txtConsOthersRoom,
    txtConsOthersShelves, txtConsOthersRack, txtConsOthersBin
}

        ' Loop through the fields and clear them
        For Each field As TextBox In textFields
            field.Text = ""
        Next



    End Sub
    Public Sub loadwarehouse()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("select warehouse_id,wname From ams.loc_warehouse where isUsed='True'", CommandType.Text)
        drpWarehouse.DataTextField = ("wname")
        drpWarehouse.DataValueField = ("warehouse_id")
        drpWarehouse.DataSource = dt
        drpWarehouse.DataBind()

        drpMROConsOthersWarehouse.DataTextField = ("wname")
        drpMROConsOthersWarehouse.DataValueField = ("warehouse_id")
        drpMROConsOthersWarehouse.DataSource = dt
        drpMROConsOthersWarehouse.DataBind()

        drpEquipmentWarehouse.DataTextField = ("wname")
        drpEquipmentWarehouse.DataValueField = ("warehouse_id")
        drpEquipmentWarehouse.DataSource = dt
        drpEquipmentWarehouse.DataBind()


    End Sub

    Public Sub SelectMROConsOthers()
        If grdStockList.SelectedRow.Cells(3).Text <> 0 Then
            Dim dt As New DataTable

            dt = objDerived.GetDataTable("select  a.ItemDesc,a.BrandName,b.Cost,convert(int,b.Qty),a.DepreciationRate ,a.DepreciationValue,a.Form, a.Batch ,a.Lot , a.Mftgdate , a.EpiryDate, a.Alert ,isnull(b.Location,' - '),isnull(b.warehouse_id,1)   From [AMS].TbNonFood as a inner join ams.Stock as b on a.StockID = b.StockID  where a.Item_ID = " & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            txtConsOthersName.Text = dt.Rows(0).Item(0)
            txtConsOthersName.ReadOnly = False

            txtConsOthersBrandName.Text = dt.Rows(0).Item(1)
            txtConsOthersBrandName.ReadOnly = False

            txtConsOthersUnitPrice.Text = dt.Rows(0).Item(2)
            txtConsOthersUnitPrice.ReadOnly = False

            txtConsOthersQuantity.Text = dt.Rows(0).Item(3)
            txtConsOthersQuantity.ReadOnly = False


            txtConsOthersDepValue.Text = dt.Rows(0).Item(4)
            txtConsOthersDepValue.ReadOnly = False

            txtConsOthersDepRate.Text = dt.Rows(0).Item(5)
            txtConsOthersDepRate.ReadOnly = False
            'txtCategory.ReadOnly = False

            txtConsOthersForm.Text = dt.Rows(0).Item(6)
            txtConsOthersForm.ReadOnly = False

            txtConsOthersBatch.Text = dt.Rows(0).Item(7)
            txtConsOthersBatch.ReadOnly = False

            txtConsOthersLot.Text = dt.Rows(0).Item(8)
            txtConsOthersLot.ReadOnly = False

            txtMDateConsOthers.Text = dt.Rows(0).Item(9)
            ' txtConsOthersQuantity.ReadOnly = False
            txtMDateConsOthers.ReadOnly = False

            txtEDateConsOthers.Text = dt.Rows(0).Item(10)
            txtEDateConsOthers.ReadOnly = False

            txtAlertConsOthers.Text = dt.Rows(0).Item(11)
            txtAlertConsOthers.ReadOnly = False

            txtConsOthersBay.ReadOnly = False
            txtConsOthersColumn.ReadOnly = False
            txtConsOthersFloor.ReadOnly = False
            txtConsOthersRoom.ReadOnly = False
            txtConsOthersShelves.ReadOnly = False
            txtConsOthersRack.ReadOnly = False
            txtConsOthersBin.ReadOnly = False

            '''--------------------location
            Dim location As String
            location = dt.Rows(0).Item(12)
            Dim locationsplit As String() = location.Split("-")
            If location.Contains("Bay") Then
                txtConsOthersBay.Text = locationsplit(1)
            ElseIf location.Contains("Column") Then
                txtConsOthersColumn.Text = locationsplit(1)
            ElseIf location.Contains("Floor") Then
                txtConsOthersFloor.Text = locationsplit(1)
            ElseIf location.Contains("Room") Then
                txtConsOthersRoom.Text = locationsplit(1)
            ElseIf location.Contains("Shelves") Then
                txtConsOthersShelves.Text = locationsplit(1)
            ElseIf location.Contains("Rack") Then
                txtConsOthersRack.Text = locationsplit(1)
            ElseIf location.Contains("Bin") Then
                txtConsOthersBin.Text = locationsplit(1)
            End If

            Dim warehouse As String
            warehouse = dt.Rows(0).Item(13)
            drpMROConsOthersWarehouse.SelectedValue = warehouse

            btnConsOthersSave.Enabled = False
            btnCancel.Enabled = False

        Else
            Dim dt As New DataTable
            Dim obj As New BaseClasses.Items
            txtConsOthersName.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)


            'optimize code
            Dim txtBoxes() As TextBox = {txtConsOthersName, txtConsOthersBrandName, txtConsOthersUnitPrice, txtConsOthersQuantity,
txtConsOthersDepValue, txtConsOthersDepRate, txtConsOthersForm, txtConsOthersBatch, txtConsOthersLot,
txtMDateConsOthers, txtEDateConsOthers, txtAlertConsOthers, txtConsOthersBay, txtConsOthersColumn,
txtConsOthersFloor, txtConsOthersRoom, txtConsOthersShelves, txtConsOthersRack, txtConsOthersBin}

            For Each txtBox As TextBox In txtBoxes
                txtBox.ReadOnly = False
            Next

            btnConsOthersSave.Enabled = True
            btnCancel.Enabled = True

            ' txtItemDesc2.text = dt.Rows(0).Item(0)
        End If
    End Sub

    Public Sub SelectMROsupplies()
        Dim CY As String = "CY" & Year(txtDate.Text)

        If grdStockList.SelectedRow.Cells(3).Text <> 0 Then
            Dim dt As New DataTable

            dt = objDerived.GetDataTable("select a.Description,a.BrandName,a.Size,a.Color,a.DepreciatedRate,a.DepreciatedValue,a.Length,a.Width,a.Height,a.Weight,b.Cost,convert(int,b.Qty) ,isnull(b.Location,' - '),isnull(b.warehouse_id,1) ,isnull(a.componentof,'')  From [AMS].[TBSupplies_Info] as a inner join ams.Stock as b on a.StockID = b.StockID  where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            txtItemDesc2.Text = dt.Rows(0).Item(0)
            txtItemDesc2.ReadOnly = True

            txtBrandName2.Text = dt.Rows(0).Item(1)
            txtBrandName2.ReadOnly = True

            txtSize.Text = dt.Rows(0).Item(2)
            txtSize.ReadOnly = True

            txtColor.Text = dt.Rows(0).Item(3)
            txtColor.ReadOnly = True

            txtDepRate.Text = dt.Rows(0).Item(4)
            txtDepRate.ReadOnly = True
            txtDepValue.Text = dt.Rows(0).Item(5)
            txtDepValue.ReadOnly = True

            'txtCategory.ReadOnly = True

            txtLenght.Text = dt.Rows(0).Item(6)
            txtLenght.ReadOnly = True
            txtWidth.Text = dt.Rows(0).Item(7)
            txtWidth.ReadOnly = True
            txtHeight.Text = dt.Rows(0).Item(8)
            txtHeight.ReadOnly = True
            txtWeight.Text = dt.Rows(0).Item(9)
            txtWeight.ReadOnly = True

            txtUnitPrice.Text = dt.Rows(0).Item(10)
            txtUnitPrice.ReadOnly = True
            txtQuantity.Text = dt.Rows(0).Item(11)
            txtQuantity.ReadOnly = True

            txtReOrderPt.ReadOnly = True


            '''--------------------location
            Dim location As String
            location = dt.Rows(0).Item(12)
            Dim locationsplit As String() = location.Split("-")
            If location.Contains("Bay") Then
                txtBay.Text = locationsplit(1)
            ElseIf location.Contains("Column") Then
                txtColumn.Text = locationsplit(1)
            ElseIf location.Contains("Floor") Then
                txtFloor.Text = locationsplit(1)
            ElseIf location.Contains("Room") Then
                txtRoom.Text = locationsplit(1)
            ElseIf location.Contains("Shelves") Then
                txtShelves.Text = locationsplit(1)
            ElseIf location.Contains("Rack") Then
                txtRack.Text = locationsplit(1)
            ElseIf location.Contains("Bin") Then
                txtBin.Text = locationsplit(1)
            End If
            txtBay.ReadOnly = True
            txtColumn.ReadOnly = True
            txtFloor.ReadOnly = True
            txtRoom.ReadOnly = True
            txtShelves.ReadOnly = True
            txtRack.ReadOnly = True
            txtBin.ReadOnly = True


            Dim warehouse As String
            warehouse = dt.Rows(0).Item(13)
            drpWarehouse.SelectedValue = warehouse
            txtComponentof.Text = dt.Rows(0).Item(14)
            txtComponentof.ReadOnly = True
            btnSave.Enabled = False
            btnCancel.Enabled = False
        Else
            Dim dt As New DataTable
            Dim obj As New BaseClasses.Items
            txtItemDesc2.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            txtBrandName2.Text = obj.GetValue("select Brand From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            txtSize.Text = obj.GetValue("select size From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            txtColor.Text = obj.GetValue("select color From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            txtUnitPrice.Text = obj.GetValue("select " & CY & " From dbo.m_item_detail where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)


            Dim allTextBoxes() As TextBox = {txtColor, txtDepRate, txtItemDesc2, txtBrandName2, txtLenght, txtWidth, txtHeight, txtWeight, txtDepValue, txtSize, txtUnitPrice, txtQuantity, txtComponentof, txtBay, txtColumn, txtFloor, txtRoom, txtShelves, txtRack, txtBin}

            For Each txtBox As TextBox In allTextBoxes
                txtBox.ReadOnly = False
            Next

            btnSave.Enabled = False
            btnCancel.Enabled = False

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
        If ddClass.SelectedItem.Value = 1 Then
            SelectMROsupplies()

            Me.MultiView1.SetActiveView(Me.View2)

        Else
            Me.MultiView1.SetActiveView(Me.View1)
            SelectMROConsOthers()
        End If

        hdnItemNo.Value = grdStockList.SelectedDataKey("Item_ID")
        hdnGAId.Value = grdStockList.SelectedDataKey("GA_ID")

        ledger()
    End Sub

    Protected Sub ledger()
        Dim b As String = drpItemDesc2.SelectedValue
        ''Dim a As Integer = objDerived.GetValue("Select item_id from dbo.m_item where item_desc like ='" & b & "'", CommandType.Text)

        Dim Trans As Integer = objDerived.GetValue("Select count(Trans_type) as Trans_type from AMS.TbStock_Ledger where trans_type like '%Starting Inventory%' and Item_id ='" & b & "'", CommandType.Text)
        If Trans >= 1 Then
            btnSave.Enabled = False

        End If
        Dim dtStock As New DataTable
        Dim gaid As Integer
        If hdnItemNo.Value = "" Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] null", CommandType.Text)
        Else
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        End If

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
        dt.Columns.Add("DebitQty", GetType(Integer))

        dt.Columns.Add("DebitUnit", GetType(String))
        dt.Columns.Add("DebitCost", GetType(Decimal))
        dt.Columns.Add("CreditQty", GetType(Integer))
        dt.Columns.Add("CreditUnit", GetType(String))
        dt.Columns.Add("CreditCost", GetType(Decimal))
        dt.Columns.Add("BalQty", GetType(Integer))
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
        Dim classification As String = objDerived.GetValue("Select ClassificationName from dbo.tbl_Classification where ClassificationId = " & ddClass.Text, CommandType.Text)
        If classification.Contains("Supplies") Then

            Dim dtitemdesc As New DataTable

            dtitemdesc = objDerived.GetDataTable("SELECT dbo.m_item.Item_ID, dbo.m_item.ItemCompleteDesc as Item_Desc " &
                                                   " FROM dbo.m_item LEFT OUTER JOIN " &
                                                   " dbo.m_item_detail ON dbo.m_item.Item_ID = dbo.m_item_detail.Item_ID INNER JOIN " &
                                                   " dbo.tblclassmatrix ON dbo.m_item.Item_ID = dbo.tblclassmatrix.item_id INNER JOIN " &
                                                   " AMS.item_particular ON dbo.tblclassmatrix.categoryid = AMS.item_particular.item_particular_id LEFT OUTER JOIN " &
                                                   " dbo.tbl_SubCategory ON dbo.tblclassmatrix.subcategoryid = dbo.tbl_SubCategory.SubCategoryID " &
                                                   " WHERE(AMS.item_particular.ClassificationID = " & ddClass.SelectedValue() & ") ORDER BY dbo.m_item.ItemCompleteDesc", CommandType.Text)


            drpItemDesc2.DataSource = dtitemdesc
            drpItemDesc2.DataTextField = ("Item_Desc")
            drpItemDesc2.DataValueField = ("Item_ID")
            drpItemDesc2.DataBind()
            drpItemDesc2.Enabled = True
            selectitemdescMROsupplies()


            Me.MultiView1.SetActiveView(Me.View2)
        ElseIf classification.Contains("Consumables") Then
            Dim dtitemdesc As New DataTable


            dtitemdesc = objDerived.GetDataTable("SELECT i.Item_ID, i.ItemCompleteDesc AS Item_Desc " &
                                                   " FROM dbo.m_item AS i " &
                                                   " INNER JOIN dbo.tblclassmatrix AS cm ON i.Item_ID = cm.item_id " &
                                                   "  INNER JOIN AMS.item_particular AS ip ON cm.categoryid = ip.item_particular_id " &
                                                   "  LEFT OUTER JOIN dbo.m_item_detail AS id ON i.Item_ID = id.Item_ID " &
                                                   "  LEFT OUTER JOIN dbo.tbl_SubCategory AS sc ON cm.subcategoryid = sc.SubCategoryID " &
                                                   "  WHERE ip.ClassificationID = " & ddClass.SelectedValue() & " ORDER BY i.ItemCompleteDesc", CommandType.Text)
            drpConsOthersName.DataSource = dtitemdesc
            drpConsOthersName.DataTextField = ("Item_Desc")
            drpConsOthersName.DataValueField = ("Item_ID")
            drpConsOthersName.DataBind()
            drpConsOthersName.Enabled = True
            selectitemdescMROConsOthers()
            Me.MultiView1.SetActiveView(Me.View1)
        Else
            lblClass.Text = "MRO Equipment"

            Dim dtitemdesc As New DataTable

            dtitemdesc = objDerived.GetDataTable("SELECT m_item.Item_ID, m_item.ItemCompleteDesc AS Item_Desc " &
                                                  " FROM dbo.m_item " &
                                                  " INNER JOIN dbo.m_item_detail ON m_item.Item_ID = m_item_detail.Item_ID " &
                                                  " INNER JOIN dbo.tblclassmatrix ON m_item.Item_ID = tblclassmatrix.item_id " &
                                                  " INNER JOIN AMS.item_particular ON tblclassmatrix.categoryid = AMS.item_particular.item_particular_id " &
                                                  " LEFT OUTER JOIN dbo.tbl_SubCategory ON tblclassmatrix.subcategoryid = tbl_SubCategory.SubCategoryID " &
                                                  " WHERE AMS.item_particular.ClassificationID = " & ddClass.SelectedValue() & " " &
                                                  " ORDER BY m_item.ItemCompleteDesc", CommandType.Text)


            drpMROEquipmentName.DataSource = dtitemdesc
            drpMROEquipmentName.DataTextField = ("Item_Desc")
            drpMROEquipmentName.DataValueField = ("Item_ID")
            drpMROEquipmentName.DataBind()
            drpMROEquipmentName.Enabled = True

            selectitemdescMROEquipment()

            Me.MultiView1.SetActiveView(Me.View3)
        End If

        'imgmedical.ImageUrl = "~/images/blankImage.jpg"
        'loadStockOfficeSupplies()
        'LoadSupplies()
    End Sub

    Protected Sub ddSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        MultiviewSupplier()
    End Sub
    Public Sub SaveMROSupplies()
        Try
            '--- Start: Method Tracer ---
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogStart",
            "console.log('SaveMROSupplies: Method start');", True)

            ' 1) Validate Required Fields
            If String.IsNullOrEmpty(txtItemDesc2.Text) OrElse
           String.IsNullOrEmpty(txtBrandName2.Text) OrElse
           String.IsNullOrEmpty(txtUnitPrice.Text) OrElse
           String.IsNullOrEmpty(txtQuantity.Text) OrElse
           String.IsNullOrEmpty(txtSellectDate.Text) OrElse
           String.IsNullOrEmpty(txtReOrderPt.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity / Date")
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogFieldsMissing",
                "console.log('Missing required fields in SaveMROSupplies. Exiting.');", True)
                Return
            End If

            ' 2) Safe parsing for numeric fields
            Dim qtyValue As Decimal
            If Not Decimal.TryParse(txtQuantity.Text, qtyValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity is not numeric.")
                Return
            End If

            Dim unitPriceValue As Decimal
            If Not Decimal.TryParse(txtUnitPrice.Text, unitPriceValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unit Price is not numeric.")
                Return
            End If

            Dim reorderValue As Integer
            If Not Integer.TryParse(txtReOrderPt.Text, reorderValue) Then
                reorderValue = 0  ' fallback if not numeric
            End If

            ' 3) Update m_item.unit_id
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogUpdateUnit",
            "console.log('Updating dbo.m_item with unit_id = " & drpUnit.SelectedItem.Value & "');", True)
            objDerived.Execute("UPDATE dbo.m_item SET unit_id = " & drpUnit.SelectedItem.Value &
                           " WHERE item_id = " & hdnItemNo.Value, CommandType.Text)

            ' 4) Fetch classification, category, matrix
            Dim classification As String = objDerived.GetValue(
            "SELECT ClassificationName FROM dbo.tbl_Classification WHERE ClassificationId = " & ddClass.Text,
            CommandType.Text)
            Dim category As Integer = objDerived.GetValue(
            "SELECT a.item_particular_id " &
            "FROM dbo.m_item AS a " &
            "INNER JOIN ams.item_particular AS b ON a.item_particular_id = b.item_particular_id " &
            "WHERE a.Item_ID = " & hdnItemNo.Value, CommandType.Text)
            Dim matrix As String = objDerived.GetValue(
            "SELECT id FROM tblclassmatrix " &
            "WHERE classificationid = " & ddClass.Text &
            "  AND ga_id = " & hdnGAId.Value &
            "  AND item_id = " & hdnItemNo.Value, CommandType.Text)

            If String.IsNullOrEmpty(matrix) Then
                objDerived.Execute(
                "INSERT INTO tblclassmatrix (classificationid, ga_id, item_id, categoryid, bga_id) " &
                "VALUES ('" & ddClass.Text & "','" & hdnGAId.Value & "','" & hdnItemNo.Value & "','" & category & "','0')",
                CommandType.Text)
            End If

            ' 5) SAVE AMS.Tb_Receiving
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogSavingRCV",
            "console.log('Saving AMS.Tb_Receiving record');", True)
            Dim rcv As New Receiving.t_receiving
            With rcv
                .Received_Date = txtDate.Text
                .ReceivedBY = 0
                .POHdr_ID = Session("POHdr_ID")

                .PO_No = ""
                .Supplier_ID = 0
                .GA_ID = hdnGAId.Value
                .isAccepted = False
                .UserID = Session("@UserName")
            End With

            Dim rcvID As Long = rcv.save()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogRCVID",
            "console.log('Tb_Receiving saved. rcvID=' + " & rcvID & ");", True)
            Session("Received_ID") = rcvID

            ' 6) Build location safely (Instead of the big If/Else block, use a builder)
            Dim locationBuilder As New System.Text.StringBuilder()
            If Not String.IsNullOrEmpty(txtBay.Text) Then locationBuilder.Append("Bay-").Append(txtBay.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtColumn.Text) Then locationBuilder.Append("Column-").Append(txtColumn.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtFloor.Text) Then locationBuilder.Append("Floor-").Append(txtFloor.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtRoom.Text) Then locationBuilder.Append("Room-").Append(txtRoom.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtShelves.Text) Then locationBuilder.Append("Shelves-").Append(txtShelves.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtRack.Text) Then locationBuilder.Append("Rack-").Append(txtRack.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtBin.Text) Then locationBuilder.Append("Bin-").Append(txtBin.Text)

            Dim finalLocation As String = locationBuilder.ToString().Trim()

            ' 7) SAVE Receiving Details
            Dim rcv_dtl As New Receiving.t_receiving_dtl
            Dim total As Decimal = 0

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogSavingDTL",
            "console.log('Saving AMS.Tb_Receiving_Dtl with location: " & finalLocation & "');", True)

            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = hdnItemNo.Value
                .PO_Qty = qtyValue
                .Qty_Received = qtyValue
                .Cost = unitPriceValue
                .Condition = ""
                .Location = finalLocation
            End With
            Dim RcvDtl_ID As Long = rcv_dtl.save()
            If RcvDtl_ID <= 0 Then Throw New Exception("Failed to save Receiving Details.")

            total = qtyValue * unitPriceValue
            Session("ContractPrice") = total

            ' 8) SAVE Purchase Order
            Dim pohdr_id As Long
            Dim POnumber As String = "Starting Inventory"
            Dim POhdr As New t_purchase_order_hdr

            With POhdr
                .PO_No = POnumber
                .PO_Date = txtDate.Text
                .Supplier_ID = 0
                .mode_of_procurement_id = 2
                .DeliveryTerm = 0
                .paymentTerm = 0
                .DeliveryDate = txtDate.Text
                .DeliveryPlace = ""
                .isDelivered = True
                .pre_procurement_hdr_id = 0
                .withdv = False
                .isStag = False
                .isContinueCutOff = False
                .isStopForCutOff = False
                .isShoppingA = False
                .isPublicInfra = False
                .isStraight = True
                .isApproved_PO_Mayor = True
                .isReceived_PO_Mayor = True
                .DateApproved_PO_Mayor = txtDate.Text
                .DateReceived_PO_Mayor = txtDate.Text
                .DateDisApprove = "01/01/1900"
                .isGasoline = False
                .isReimbursement = False
            End With

            ' Check if the PO already exists
            Dim po_id As New DataTable
            po_id = objDerived.GetDataTable("SELECT pohdr_id FROM ams.po_hdr " &
                                        "WHERE po_no LIKE '" & POnumber & "' AND Supplier_ID='0'",
                                        CommandType.Text)
            If po_id.Rows.Count = 0 Then
                POhdr.ContractPrice = Convert.ToDecimal(Session("ContractPrice"))
                pohdr_id = POhdr.save()
            Else
                Dim poid As Integer = objDerived.GetValue("SELECT pohdr_id FROM ams.po_hdr WHERE po_no LIKE '" & POnumber & "' AND Supplier_ID='0'", CommandType.Text)
                Dim TAmount As Decimal = objDerived.GetValue("SELECT ContractPrice FROM ams.po_hdr WHERE pohdr_id = " & poid, CommandType.Text)
                POhdr.ContractPrice = TAmount + Convert.ToDecimal(Session("ContractPrice"))
                POhdr.POHdr_ID = poid
                pohdr_id = POhdr.update()
            End If

            objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = '" & hdnGAId.Value & "', " &
                              "ProjectName = 'Manual Encode' WHERE POHdr_ID = '" & pohdr_id & "'",
                              CommandType.Text)
            Session("POHdr_ID") = pohdr_id

            ' 9) SAVE Inspection & Acceptance
            Dim objhdr As New t_inspection_and_acceptance_hdr
            Dim airhdr_id As Long
            Dim air As String = objDerived.GetValue("SELECT [AMS].[func_GenerateAIR]('" & txtDate.Text & "')", CommandType.Text)
            ' Safe parsing for DeliveryDate
            Dim deliveryDateValue As Date = #1/1/1900#
            If Not String.IsNullOrEmpty(txtDate.Text) AndAlso IsDate(txtDate.Text) Then
                deliveryDateValue = DateTime.Parse(txtDate.Text)
            End If


            With objhdr
                .AIR_No = air
                .AIR_Date = deliveryDateValue
                .Date_Received = deliveryDateValue
                .Date_Inspect = deliveryDateValue
                .Date_Accepted = deliveryDateValue
                .Invoice_date = deliveryDateValue
                .Invoice_No = " "

                .POHdr_ID = Session("POHdr_ID")
                .Supplier_ID = 0
                .Signatory1 = " "
                .Signatory2 = " "
                .Signatory3 = " "
                .isComplete = True

                .RC_ID = 0
                .Function_ID = 0
                ' If you have remarks:
                ' .remarks = txtIAremarks.Text
            End With
            airhdr_id = objhdr.save()
            Session("AIRHDR_ID") = airhdr_id

            objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET UserID = '" & Session("@UserName") & "', " &
                              "Received_ID = '" & Session("Received_ID") & "' " &
                              "WHERE AIRHdr_ID = '" & Session("AIRHDR_ID") & "'",
                              CommandType.Text)

            ' 10) PO Details Save
            Dim POdtl As New t_purchase_order_dtl
            POdtl.POHdr_ID = Session("POHdr_ID")
            POdtl.Item_ID = hdnItemNo.Value
            POdtl.cost = unitPriceValue
            POdtl.qty = qtyValue
            POdtl.remarks = "Manual Encode"
            POdtl.save()

            ' 11) AIR Details
            Dim objdtl As New t_inspection_and_acceptance_dtl
            objdtl.Item_ID = hdnItemNo.Value
            objdtl.Qty = qtyValue
            objdtl.Cost = unitPriceValue
            objdtl.AIRHdr_ID = Session("AIRHDR_ID")
            objdtl.GA_ID = hdnGAId.Value
            Dim iaDtl_ID As Integer = objdtl.save()
            Session("AIRDtl_ID") = iaDtl_ID

            ' 12) Save Stock
            Dim objStock As New Supplies_Stock
            With objStock
                .StockDate = DateTime.Parse(txtDate.Text)
                .Item_ID = hdnItemNo.Value
                .Qty = qtyValue
                .Balance = qtyValue
                .Location = finalLocation
                .Expiration_Date = Date.Parse(txtEDateConsOthers.Text)
                .Cost = unitPriceValue
                .Issuance = 0
                .RC_ID = objDerived.GetValue("SELECT DISTINCT [RC_id] FROM [dbo].[View_RespCenter_withFunctions] " &
                                         "WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'", CommandType.Text)
                .Function_ID = 0
                .Project_ID = 0
                .Program_id = 0
                .F_ID = 4
                .AIRDtl_ID = Session("AIRDtl_ID")
                .GA_ID = hdnGAId.Value

                Dim whVal As String = drpWarehouse.SelectedValue
                If String.IsNullOrEmpty(whVal) OrElse Not IsNumeric(whVal) Then
                    whVal = "0"
                End If
                .Warehouseid = Convert.ToInt64(whVal)
                .ReorderPt = reorderValue
            End With

            Dim StockID As Long = objStock.save()
            objDerived.GetRecords("UPDATE AMS.Stock SET Received_ID = '" & rcvID & "' WHERE StockID = '" & StockID & "'",
                              CommandType.Text)

            ' 13) Save Ledger
            Dim objStockLedger As New t_StockLedger
            With objStockLedger
                .StockID = StockID
                .Trans_Type = "Starting Balance"
                .Ref = air
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .ReceivedBy = ""
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                ' Choose correct date based on MRO Class
                If lblClass.Text = "MRO Equipment" Then
                    .dDate = DateTime.Parse(txtEAcqDate.Text)
                ElseIf lblClass.Text = "MRO Supplies" Then
                    .dDate = DateTime.Parse(txtSellectDate.Text)
                ElseIf lblClass.Text = "MRO Consumables" Then
                    .dDate = DateTime.Parse(txtSellectDateCons.Text)
                End If

                .Item_ID = hdnItemNo.Value
                .DebitQty = qtyValue
                .DebitCost = FormatNumber(unitPriceValue * qtyValue, 2)
                .DebitUnit = objDerived.GetValue(
                "SELECT AMS.m_Unit.Description FROM AMS.m_Unit " &
                "INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID " &
                "WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceUnit = objDerived.GetValue(
                "SELECT AMS.m_Unit.Description FROM AMS.m_Unit " &
                "INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID " &
                "WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceQty = 0
                .BalanceCost = 0
            End With
            objStockLedger.save()

            ' 14) Save TBSupplies_Info
            Dim objOfficeSup As New SupplieINFO
            With objOfficeSup
                .StockID = StockID
                .AIRDtl_ID = Session("AIRDtl_ID")
                .ItemId = hdnItemNo.Value
                .Description = txtItemDesc2.Text
                .BrandName = txtBrandName2.Text
                .SupplierId = 0
                .Size = txtSize.Text
                .Color = txtColor.Text
                ' Category => from a.item_particular_id => describing itemPart
                .Category = objDerived.GetValue(
                "SELECT description FROM dbo.m_item AS a INNER JOIN ams.item_particular AS b " &
                "ON a.item_particular_id = b.item_particular_id " &
                "WHERE a.Item_ID = " & hdnItemNo.Value, CommandType.Text)

                .Length = txtLenght.Text
                .Width = txtWidth.Text
                .Height = txtHeight.Text
                .Weight = txtWeight.Text
                .DepreciatedValue = txtDepRate.Text
                .DepreciatedRate = txtDepValue.Text
                .Status = "Accepted"
                .Componentof = txtComponentof.Text
            End With

            Dim Supp_ID As Long = objOfficeSup.save()
            objDerived.GetRecords("UPDATE AMS.TBSupplies_Info SET Received_ID = '" & rcvID & "' WHERE SuppliesId = '" & Supp_ID & "'", CommandType.Text)

            ' Optionally refresh ledger or do other tasks
            ' selectitemdescMROsupplies()
            ' ledger()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")

            ' Reorder Check
            Dim reorderCheck As String = objDerived.GetValue(
            "SELECT ReorderPt FROM ams.Stock WHERE Item_ID = '" & hdnItemNo.Value & "'",
            CommandType.Text)
            If Not String.IsNullOrEmpty(reorderCheck) AndAlso IsNumeric(reorderCheck) Then
                Dim rop As Integer = Convert.ToInt32(reorderCheck)
                If rop >= qtyValue Then
                    ModalPopupExtender3.Show()
                End If
            End If

            ' 15) Refresh the ledger grid
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogRefreshGrid", "console.log('Refreshing ledger grid after SaveMROSupplies');", True)

            Dim dtStockRefresh As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
            If dtStockRefresh.Rows.Count < 4 Then
                dtStockRefresh.Merge(createdatatableledger(3 - dtStockRefresh.Rows.Count))
            End If

            grdLedger.DataSource = dtStockRefresh
            grdLedger.DataBind()


            '--- End: Method Tracer ---
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogFinish",
            "console.log('SaveMROSupplies: Method end');", True)

        Catch ex As Exception
            ' Handle Exceptions Gracefully
            Dim safeMessage As String = ex.Message.Replace("'", "\'").Replace(vbCrLf, " ").Replace(vbLf, " ")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogCatchError",
            "console.error('Exception in SaveMROSupplies: " & safeMessage & "');", True)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error in SaveMROSupplies: " & ex.Message)
        End Try
    End Sub

    Public Sub updateMROSupplies()
        If txtUnitPrice.Text = "" Or txtQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")

        Else
            Dim locations As String

            If txtBay.Text <> "" Then
                locations = "Bay-" & txtBay.Text
            End If

            If txtColumn.Text <> "" Then
                locations = locations + " " + "Column-" & txtColumn.Text
            End If

            If txtFloor.Text <> "" Then
                locations = locations + " " + "Floor-" & txtFloor.Text
            End If

            If txtRoom.Text <> "" Then
                locations = locations + " " + "Room-" & txtRoom.Text
            End If

            If txtShelves.Text <> "" Then
                locations = locations + " " + "Shelves-" & txtShelves.Text
            End If

            If txtRack.Text <> "" Then
                locations = locations + " " + "Rack-" & txtRack.Text
            End If

            If txtBin.Text <> "" Then
                locations = locations + " " + "Bin-" & txtBin.Text
            End If

            Dim dt As DataTable = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpItemDesc2.SelectedItem.Value & "'", CommandType.Text)

            For i As Integer = 0 To grdLedger.Rows.Count - 1
                Dim cb1 As CheckBox = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then

                    If dt.Rows.Count > 0 Then
                        Dim stockID As String = dt.Rows(i).Item("StockID").ToString()
                        Dim receivedID As String = dt.Rows(i).Item("ReceiveID").ToString()


                        'objDerived.GetRecords("UPDATE [AMS].[Tb_Receiving_Dtl] " +
                        '                    " SET [PO_Qty] = '" & txtQuantity.Text & "' " +
                        '                    " ,[Qty_Received] = '" & txtQuantity.Text & "' " +
                        '                    " ,[Cost] = '" & txtUnitPrice.Text & "' " +
                        '                    " ,[Location] = '" & locations & "' " +
                        '                    " WHERE Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)


                        '----Update Receiving


                        ''----Update PO_dtl
                        'objDerived.GetRecords("UPDATE [AMS].[PO_Dtl] " +
                        '                        " SET [qty] = '" & txtQuantity.Text & "' " +
                        '                        " ,[cost] = '" & txtUnitPrice.Text & "' " +
                        '                        " WHERE Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)


                        ''----Update AIR_Dtl
                        'objDerived.GetRecords("UPDATE [AMS].[AIR_Dtl] " +
                        '                        " SET [Qty] = '" & txtQuantity.Text & "' " +
                        '                        " ,[Cost] = '" & txtUnitPrice.Text & "' " +
                        '                        " WHERE Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)

                        '----Update STOCK
                        objDerived.GetRecords("UPDATE [AMS].[stock] " +
                                                " SET [Qty] = '" & txtQuantity.Text & "' " +
                                                " ,[Cost] = '" & txtUnitPrice.Text & "' " +
                                                " ,[Location] = '" & locations & "' " +
                                                " ,[StockDate] = '" & txtSellectDate.Text & "'" +
                                                " ,[warehouse_ID] = '" & drpWarehouse.SelectedValue() & "' " +
                                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and Received_ID = '" & receivedID & "' and StockID = '" & stockID & "' ", CommandType.Text)

                        '----Update stockledger
                        objDerived.GetRecords("UPDATE [AMS].[TbStock_Ledger] " +
                                                " SET DebitUnit = '" & drpUnit.SelectedItem.Text & "', [DebitQty] = '" & txtQuantity.Text & "' " +
                                                " ,[DebitCost] = '" & CType(txtQuantity.Text * txtUnitPrice.Text, Decimal) & "', " +
                                                " BalanceUnit = '" & drpUnit.SelectedItem.Text & "', " +
                                                " BalanceCost = (SELECT TOP 1 BalanceCost FROM AMS.TbStock_Ledger WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "' ORDER BY StockLedger_ID DESC) + (" & CType(txtQuantity.Text * txtUnitPrice.Text, Decimal) & ") " +
                                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "' ", CommandType.Text)



                        '----Update suppliesinfo
                        objDerived.GetRecords("UPDATE [AMS].[TBSupplies_Info] " +
                                                " SET [Description] = '" & txtItemDesc2.Text & "' " +
                                                " ,[BrandName] = '" & txtBrandName2.Text & "' " +
                                                " ,[Size] = '" & txtSize.Text & "' " +
                                                " ,[Color] = '" & txtColor.Text & "' " +
                                                " ,[Length] = '" & txtLenght.Text & "' " +
                                                " ,[Width] = '" & txtWidth.Text & "' " +
                                                " ,[Componentof] = '" & txtComponentof.Text & "' " +
                                                " ,[Height] = '" & txtHeight.Text & "' " +
                                                " ,[Weight] = '" & txtWeight.Text & "' " +
                                                " WHERE ItemId = '" & hdnItemNo.Value & "' and Received_ID = '" & receivedID & "' and StockID = '" & stockID & "' ", CommandType.Text)

                    End If
                End If
            Next

            Dim t1 As Decimal
            Dim total As Decimal = 0

            t1 = txtQuantity.Text * txtUnitPrice.Text
            total = total + t1
            Session("ContractPrice") = total

            'objDerived.Execute("EXEC sp_UpdateBalancefromLedger " & hdnItemNo.Value, CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer = txtQuantity.Text
            If a >= c Then
                ModalPopupExtender3.Show()
            End If
            selectitemdescMROsupplies()
            ledger()
        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)

        If btnSave.Text = "SAVE" Then
            SaveMROSupplies()
        ElseIf btnSave.Text = "UPDATE" Then
            updateMROSupplies()
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Ledger Card Updated Successfully")
        Else
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            btnCancel.Enabled = True

            ModalPopupExtender2.Show()

        End If
    End Sub
    Private Function DecryptEncrypt(ByVal TheText As String) As String
        Dim tempChar As String = Nothing
        Dim i As Integer = 0
        For i = 1 To TheText.Length
            If Convert.ToInt32(TheText.Chars(i - 1)) < 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) + 100)
            ElseIf Convert.ToInt32(TheText.Chars(i - 1)) > 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) - 100)
            End If
            TheText = TheText.Remove(i - 1, 1).Insert(i - 1, (CChar(ChrW(tempChar))).ToString())
        Next i
        Return TheText

    End Function
    Public Sub ProceedMROEquipment()
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)
        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else

            txtMROEquipmentName.ReadOnly = False
            txtequipmentdesciption.ReadOnly = False
            txtEAcqCost.ReadOnly = False
            txtEquipmentQuantity.ReadOnly = False
            txtequipmentpowerinput.ReadOnly = False
            txtequipmentmodel.ReadOnly = False
            txtequipmentdimension.ReadOnly = False
            txtequipmentareacapacity.ReadOnly = False
            txtequipmentwaranty.ReadOnly = False
            txtSpecification.ReadOnly = False
            txtEAcqDate.ReadOnly = False
            txtEMarketValue.ReadOnly = False
            txtSalvageValue.ReadOnly = False
            txtNoYears.ReadOnly = False
            txtequipmentdepreciatedvalue.ReadOnly = False
            lblequipmentdepreciatedRate.ReadOnly = False
            txtUsefulLife.ReadOnly = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fields are now open for editing")
        End If

    End Sub

    Public Sub ProceedMROConsumables()
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)
        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else

            'OPTIMIZE CODE
            Dim controls() As Control = {txtConsOthersName, txtConsOthersBrandName, txtConsOthersUnitPrice, txtConsOthersQuantity, txtConsOthersDepValue, txtConsOthersDepRate, txtConsOthersForm, txtConsOthersBatch1, txtConsOthersLot, txtMDateConsOthers, txtEDateConsOthers, txtAlertConsOthers}

            For Each c As Control In controls
                If TypeOf c Is TextBox Then
                    CType(c, TextBox).ReadOnly = False
                End If
            Next





            'OPTIMIZE CODE
            For Each extender As AjaxControlToolkit.CalendarExtender In {CalendarExtender4, CalendarExtender5, CalendarExtender6}
                extender.Enabled = True
            Next

            btnConsOthersSave.Text = "UPDATE"
            btnConsOthersSave.Enabled = True
            btnConsOthersCancel.Enabled = True
            txtConsOthersBay.ReadOnly = False
            txtConsOthersColumn.ReadOnly = False
            txtConsOthersFloor.ReadOnly = False
            txtConsOthersRoom.ReadOnly = False
            txtConsOthersShelves.ReadOnly = False
            txtConsOthersRack.ReadOnly = False
            txtConsOthersBin.ReadOnly = False

        End If

    End Sub

    Public Sub ProceedMROSupplies()
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else

            Dim textBoxes() As TextBox = {txtItemDesc2, txtBrandName2, txtSize, txtColor, txtDepRate, txtLenght, txtWidth, txtHeight, txtWeight, txtDepValue, txtUnitPrice, txtQuantity, txtComponentof, txtBay, txtColumn, txtFloor, txtRoom, txtShelves, txtRack, txtBin, TextBox1}

            For Each tb As TextBox In textBoxes
                tb.ReadOnly = False
            Next

            'TextBox1.Visible = False
            btnSave.Text = "UPDATE"
            drpWarehouse.Enabled = True
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fields are now open for editing")

        End If
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        selectitemdescMROsupplies()
    End Sub


    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)


        Dim classification As String = objDerived.GetValue("select ClassificationName From dbo.tbl_Classification where Classificationid =" & ddClass.SelectedValue, CommandType.Text)


        If classification.Contains("Consumables") Then
            ProceedMROConsumables()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "You can now update the record.")
        ElseIf classification.Contains("Supplies") Then
            ProceedMROSupplies()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "You can now update the record.")
        Else
            ProceedMROEquipment()
            btnEquipmentSave.Text = "UPDATE"
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "You can now update the record.")
        End If



    End Sub

    Protected Sub btnConsOthersCancel_Click(sender As Object, e As EventArgs)
        selectitemdescMROConsOthers()
    End Sub



    Protected Sub btnAuthCancel_Click(sender As Object, e As EventArgs)
        ModalPopupExtender2.Hide()

    End Sub

    Public Sub UpdateEquipment()
        If txtMROEquipmentName.Text = "" Or txtequipmentdesciption.Text = "" Or txtEAcqCost.Text = "" Or txtEquipmentQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
        Else
            '02132023
            Dim locations As String

            If txtEquipmentBay.Text <> "" Then
                locations = "Bay-" & txtEquipmentBay.Text
            End If

            If txtEquipmentColumn.Text <> "" Then
                locations = locations + " " + "Column-" & txtEquipmentColumn.Text
            End If

            If txtEquipmentFloor.Text <> "" Then
                locations = locations + " " + "Floor-" & txtEquipmentFloor.Text
            End If

            If txtEquipmentRoom.Text <> "" Then
                locations = locations + " " + "Room-" & txtEquipmentRoom.Text
            End If

            If txtEquipmentShelves.Text <> "" Then
                locations = locations + " " + "Shelves-" & txtEquipmentShelves.Text
            End If

            If txtEquipmentRack.Text <> "" Then
                locations = locations + " " + "Rack-" & txtEquipmentRack.Text
            End If

            If txtEquipmentBin.Text <> "" Then
                locations = locations + " " + "Bin-" & txtEquipmentBin.Text
            End If


            Dim dt As DataTable = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpMROEquipmentName.SelectedItem.Value & "'", CommandType.Text)

            For i As Integer = 0 To grdLedger.Rows.Count - 1
                Dim cb1 As CheckBox = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then

                    If dt.Rows.Count > 0 Then
                        Dim stockID As String = dt.Rows(i).Item("StockID").ToString()
                        Dim receivedID As String = dt.Rows(i).Item("ReceiveID").ToString()


                        Dim t1 As Decimal
                        Dim total As Decimal = 0

                        t1 = txtEquipmentQuantity.Text * txtEAcqCost.Text
                        total = total + t1
                        Session("ContractPrice") = total


                        '----Update STOCK
                        objDerived.GetRecords("UPDATE [AMS].[stock] " +
                                                " SET [Qty] = '" & txtEquipmentQuantity.Text & "' " +
                                                " ,[Balance] = '" & txtEquipmentQuantity.Text & "' " +
                                                " ,[Cost] = '" & txtEAcqCost.Text.Replace(",", "") & "' " +
                                                " ,[Location] = '" & locations & "' " +
                                                " ,[ReorderPt] = '" & txtequipmentReOrderPt.Text & "' " +
                                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and Received_ID = '" & receivedID & "' and StockID = '" & stockID & "' ", CommandType.Text)

                        '----Update stockledger
                        ' Declare variables to hold the converted values
                        Dim qty As Decimal
                        Dim unitPrice As Decimal
                        Dim unitOtherPrice As Decimal

                        ' Check if the values are numeric and convert them
                        If IsNumeric(txtConsOthersQuantity.Text) AndAlso IsNumeric(txtUnitPrice.Text) AndAlso IsNumeric(txtConsOthersUnitPrice.Text) Then
                            qty = CDec(txtConsOthersQuantity.Text)
                            unitPrice = CDec(txtUnitPrice.Text)
                            unitOtherPrice = CDec(txtConsOthersUnitPrice.Text)

                            ' Proceed with the SQL query
                            objDerived.GetRecords("UPDATE [AMS].[TbStock_Ledger] " +
                                                " SET DebitUnit = '" & drpConsOthersUnit.SelectedItem.Text & "', " &
                                                " [DebitQty] = '" & qty & "', " &
                                                " [DebitCost] = '" & (qty * unitPrice) & "', " &
                                                " BalanceUnit = '" & drpConsOthersUnit.SelectedItem.Text & "', " &
                                                " BalanceCost = (SELECT TOP 1 BalanceCost FROM AMS.TbStock_Ledger WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "' ORDER BY StockLedger_ID DESC) + (" & (qty * unitOtherPrice) & ") " &
                                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "'", CommandType.Text)
                        Else
                            ' Handle the case where the input is not valid (e.g., show an error message)
                        End If


                        '----Update suppliesinfo' Declare numeric variables
                        Dim marketValue As Decimal = 0
                        Decimal.TryParse(txtEMarketValue.Text.Replace(",", ""), marketValue)

                        Dim noYears As Integer = 0
                        Integer.TryParse(txtNoYears.Text, noYears)

                        Dim usefulLife As Integer = 0
                        Integer.TryParse(txtUsefulLife.Text, usefulLife)

                        Dim salvageValue As Decimal = 0
                        Decimal.TryParse(txtSalvageValue.Text.Replace(",", ""), salvageValue)

                        Dim depreciationRate As Decimal = 0
                        Decimal.TryParse(lblequipmentdepreciatedRate.Text, depreciationRate)

                        Dim depreciationValue As Decimal = 0
                        Decimal.TryParse(txtDepreciationValue.Text.Replace(",", ""), depreciationValue)


                        ' Build SQL string using parsed values (numeric values NOT in quotes)
                        Dim query As String = "UPDATE AMS.TbNonFood SET " &
                                              "Dimension = '" & txtequipmentdimension.Text & "', " &
                                              "PowerInput = '" & txtequipmentpowerinput.Text & "', " &
                                              "Model = '" & txtequipmentmodel.Text & "', " &
                                              "Warranty = '" & txtequipmentwaranty.Text & "', " &
                                              "MarketValue = " & marketValue & ", " &
                                              "NoYears = " & noYears & ", " &
                                              "UsefulLife = " & usefulLife & ", " &
                                              "SalvageValue = " & salvageValue & ", " &
                                              "Specs = '" & txtSpecification.Text & "', " &
                                              "DepreciationRate = " & depreciationRate & ", " &
                                              "DeliveryDate = '" & txtEAcqDate.Text & "', " &
                                              "DepreciationValue = " & depreciationValue & " " &
                                              "WHERE Item_ID = '" & hdnItemNo.Value & "' " &
                                              "AND Received_ID = '" & receivedID & "' " &
                                              "AND StockId = '" & stockID & "'"

                        ' Run your query
                        objDerived.GetRecords(query, CommandType.Text)

                    End If
                End If
            Next

            ''----Update Receiving
            'objDerived.GetRecords("UPDATE [AMS].[Tb_Receiving_Dtl] " +
            '                    " SET [PO_Qty] = '" & txtEquipmentQuantity.Text & "' " +
            '                    " ,[Qty_Received] = '" & txtEquipmentQuantity.Text & "' " +
            '                    " ,[Cost] = '" & txtEAcqCost.Text.Replace(",", "") & "' " +
            '                    " ,[Location] = '" & locations & "' " +
            '                    " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)



            ''----Update PO_dtl
            'objDerived.GetRecords("UPDATE [AMS].[PO_Dtl] " +
            '                        " SET [qty] = '" & txtEquipmentQuantity.Text & "' " +
            '                        " ,[cost] = '" & txtEAcqCost.Text.Replace(",", "") & "' " +
            '                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)


            ''----Update AIR_Dtl
            'objDerived.GetRecords("UPDATE [AMS].[AIR_Dtl] " +
            '                        " SET [Qty] = '" & txtEquipmentQuantity.Text & "' " +
            '                        " ,[Cost] = '" & txtEAcqCost.Text.Replace(",", "") & "' " +
            '                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)


            'objDerived.Execute("EXEC sp_UpdateBalancefromLedger " & hdnItemNo.Value, CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer = txtEquipmentQuantity.Text
            If a >= c Then
                ModalPopupExtender3.Show()
            End If
            selectitemdescMROEquipment()
            ledger()


        End If
    End Sub


    Public Sub UpdateConsOthers()
        If txtConsOthersUnitPrice.Text = "" Or txtConsOthersQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
        Else


            objDerived.Execute("Update dbo.m_item set unit_id = " & drpConsOthersUnit.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)

            Dim location As String

            If txtConsOthersBay.Text <> "" Then
                location = "Bay-" & txtConsOthersBay.Text
            End If

            If txtConsOthersColumn.Text <> "" Then
                location = location + " " + "Column-" & txtConsOthersColumn.Text
            End If

            If txtConsOthersFloor.Text <> "" Then
                location = location + " " + "Floor-" & txtConsOthersFloor.Text
            End If

            If txtConsOthersRoom.Text <> "" Then
                location = location + " " + "Room-" & txtConsOthersRoom.Text
            End If

            If txtConsOthersShelves.Text <> "" Then
                location = location + " " + "Shelves-" & txtConsOthersShelves.Text
            End If

            If txtConsOthersRack.Text <> "" Then
                location = location + " " + "Rack-" & txtConsOthersRack.Text
            End If

            If txtConsOthersBin.Text <> "" Then
                location = location + " " + "Bin-" & txtConsOthersBin.Text
            End If



            Dim dt As DataTable = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpConsOthersName.SelectedItem.Value & "'", CommandType.Text)

            For i As Integer = 0 To grdLedger.Rows.Count - 1
                Dim cb1 As CheckBox = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then

                    If dt.Rows.Count > 0 Then
                        Dim stockID As String = dt.Rows(i).Item("StockID").ToString()
                        Dim receivedID As String = dt.Rows(i).Item("ReceiveID").ToString()

                        Dim unitPriceValue As Decimal
                        If Not Decimal.TryParse(txtConsOthersUnitPrice.Text, unitPriceValue) Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unit Price is not numeric.")
                            Return
                        End If

                        Dim qtyValue As Decimal
                        If Not Decimal.TryParse(txtConsOthersQuantity.Text, qtyValue) Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity is not numeric.")
                            Return
                        End If


                        Dim expiryDateValue As Date = #1/1/1900#
                        If Not String.IsNullOrEmpty(txtEDateConsOthers.Text) AndAlso IsDate(txtEDateConsOthers.Text) Then
                            expiryDateValue = DateTime.Parse(txtEDateConsOthers.Text)
                        End If

                        Dim mainDateValue As Date = #1/1/1900#
                        If Not String.IsNullOrEmpty(txtDate.Text) AndAlso IsDate(txtDate.Text) Then
                            mainDateValue = DateTime.Parse(txtDate.Text)
                        End If


                        Dim rcValString As String =
                                objDerived.GetValue("SELECT DISTINCT [RC_id] FROM [dbo].[View_RespCenter_withFunctions] " &
                                "WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'",
                                CommandType.Text)
                        Dim rcParsed As Integer = 0
                        If Not String.IsNullOrEmpty(rcValString) AndAlso IsNumeric(rcValString) Then
                            rcParsed = Convert.ToInt32(rcValString)
                        End If


                        Dim reorderVal As Integer = 0
                        If Not String.IsNullOrEmpty(txtConsOthersReOrderPt.Text) AndAlso IsNumeric(txtConsOthersReOrderPt.Text) Then
                            reorderVal = Convert.ToInt32(txtConsOthersReOrderPt.Text)
                        End If


                        Dim whVal As String = drpMROConsOthersWarehouse.SelectedValue
                        If String.IsNullOrEmpty(whVal) OrElse Not IsNumeric(whVal) Then
                            whVal = "0"
                        End If

                        objDerived.GetRecords("UPDATE [AMS].[stock] " +
                                                " SET [Qty] = '" & qtyValue & "' " +
                                                " ,[Cost] = '" & unitPriceValue & "' " +
                                                " ,[StockDate] = '" & txtSellectDateCons.Text & "'" +
                                                " ,[Balance] = '" & (qtyValue * unitPriceValue) & "' " +
                                                " ,[Expiration_Date] = '" & expiryDateValue & "' " +
                                                " ,[Batch] = '" & txtConsOthersBatch1.Text & "' " +
                                                " ,[warehouse_ID] = '" & drpMROConsOthersWarehouse.SelectedValue() & "' " +
                                                " ,[ReorderPt] = '" & reorderVal & "' " +
                                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and Received_ID = '" & receivedID & "' and StockID = '" & stockID & "' ", CommandType.Text)

                        '----Update stockledger
                        ' Declare variables to hold the converted values
                        Dim qty As Decimal
                        Dim unitPrice As Decimal
                        Dim unitOtherPrice As Decimal

                        ' Check if the values are numeric and convert them
                        If IsNumeric(txtConsOthersQuantity.Text) AndAlso IsNumeric(txtUnitPrice.Text) AndAlso IsNumeric(txtConsOthersUnitPrice.Text) Then
                            qty = CDec(txtConsOthersQuantity.Text)
                            unitPrice = CDec(txtUnitPrice.Text)
                            unitOtherPrice = CDec(txtConsOthersUnitPrice.Text)

                            ' Proceed with the SQL query
                            objDerived.GetRecords("UPDATE [AMS].[TbStock_Ledger] " +
                                                " SET DebitUnit = '" & drpConsOthersUnit.SelectedItem.Text & "', " &
                                                " [DebitQty] = '" & qty & "', " &
                                                " [DebitCost] = '" & (qty * unitPrice) & "', " &
                                                " BalanceUnit = '" & drpConsOthersUnit.SelectedItem.Text & "', " &
                                                " BalanceCost = (SELECT TOP 1 BalanceCost FROM AMS.TbStock_Ledger WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "' ORDER BY StockLedger_ID DESC) + (" & (qty * unitOtherPrice) & ") " &
                                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "'", CommandType.Text)
                        Else
                            ' Handle the case where the input is not valid (e.g., show an error message)
                        End If


                    End If
                End If
            Next



            ''----Update Receiving
            'objDerived.GetRecords("UPDATE [AMS].[Tb_Receiving_Dtl] " +
            '                " SET [PO_Qty] = '" & txtConsOthersQuantity.Text & "' " +
            '                " ,[Qty_Received] = '" & txtConsOthersQuantity.Text & "' " +
            '                " ,[Cost] = '" & txtConsOthersUnitPrice.Text & "' " +
            '                " ,[Location] = '" & location & "' " +
            '                " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)

            Dim t1 As Decimal
            Dim total As Decimal = 0

            t1 = txtConsOthersQuantity.Text * txtConsOthersUnitPrice.Text
            total = total + t1
            Session("ContractPrice") = total


            ''----Update PO_dtl
            'objDerived.GetRecords("UPDATE [AMS].[PO_Dtl] " +
            '                        " SET [qty] = '" & txtConsOthersQuantity.Text & "' " +
            '                        " ,[cost] = '" & txtConsOthersUnitPrice.Text & "' " +
            '                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)


            ''----Update AIR_Dtl
            'objDerived.GetRecords("UPDATE [AMS].[AIR_Dtl] " +
            '                        " SET [Qty] = '" & txtConsOthersQuantity.Text & "' " +
            '                        " ,[Cost] = '" & txtConsOthersUnitPrice.Text & "' " +
            '                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)




            'objDerived.Execute("EXEC sp_UpdateBalancefromLedger " & hdnItemNo.Value, CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer = txtConsOthersQuantity.Text
            If a >= c Then
                ModalPopupExtender3.Show()
            End If

            selectitemdescMROConsOthers()
            ledger()


        End If
    End Sub

    Public Sub saveConsOthers()
        Try
            ' --------------------------------------------------------------------------
            ' 1) Start of Method Tracer and Check Required Fields
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog1",
            "console.log('saveConsOthers: Method start');", True)

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog2",
            "console.log('Checking required fields for Name / Brand Name / Unit Price / Quantity');", True)

            If String.IsNullOrEmpty(txtConsOthersName.Text) OrElse
           String.IsNullOrEmpty(txtConsOthersBrandName.Text) OrElse
           String.IsNullOrEmpty(txtConsOthersUnitPrice.Text) OrElse
           String.IsNullOrEmpty(txtConsOthersQuantity.Text) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog3",
                "console.log('Missing required fields. Exiting function.');", True)
                Return
            End If

            ' --------------------------------------------------------------------------
            ' 2) Safe Parsing of Numeric Fields
            ' --------------------------------------------------------------------------
            Dim unitPriceValue As Decimal
            If Not Decimal.TryParse(txtConsOthersUnitPrice.Text, unitPriceValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unit Price is not numeric.")
                Return
            End If

            Dim qtyValue As Decimal
            If Not Decimal.TryParse(txtConsOthersQuantity.Text, qtyValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity is not numeric.")
                Return
            End If

            ' --------------------------------------------------------------------------
            ' 3) Safe Parsing of Date Fields
            '    (Prevents "Conversion from string "" to type 'Date' is not valid.")
            ' --------------------------------------------------------------------------
            ' This is important if txtDate.Text, txtMDateConsOthers.Text, or
            ' txtEDateConsOthers.Text can be empty. We'll default them to 1/1/1900
            ' if not provided or invalid.
            '
            ' If these fields are guaranteed to be filled or always valid dates,
            ' you can remove the fallback logic as needed.
            ' --------------------------------------------------------------------------

            Dim mainDateValue As Date = #1/1/1900#
            If Not String.IsNullOrEmpty(txtDate.Text) AndAlso IsDate(txtDate.Text) Then
                mainDateValue = DateTime.Parse(txtDate.Text)
            End If

            Dim alertDateValue As Date = #1/1/1900#
            If Not String.IsNullOrEmpty(txtAlertConsOthers.Text) AndAlso IsDate(txtAlertConsOthers.Text) Then
                mainDateValue = DateTime.Parse(txtAlertConsOthers.Text)
            End If

            Dim mftgDateValue As Date = #1/1/1900#
            If Not String.IsNullOrEmpty(txtMDateConsOthers.Text) AndAlso IsDate(txtMDateConsOthers.Text) Then
                mftgDateValue = DateTime.Parse(txtMDateConsOthers.Text)
            End If


            Dim expiryDateValue As Date = #1/1/1900#
            If Not String.IsNullOrEmpty(txtEDateConsOthers.Text) AndAlso IsDate(txtEDateConsOthers.Text) Then
                expiryDateValue = DateTime.Parse(txtEDateConsOthers.Text)
            End If


            ' For the ledger date logic, if you have multiple date pickers
            ' (txtSellectDate, txtSellectDateCons, etc.), parse them similarly:
            Dim ledgerDateValue As Date = mainDateValue
            If lblClass.Text = "MRO Equipment" Then
                If Not String.IsNullOrEmpty(txtEAcqDate.Text) AndAlso IsDate(txtEAcqDate.Text) Then
                    ledgerDateValue = DateTime.Parse(txtEAcqDate.Text)
                End If
            ElseIf lblClass.Text = "MRO Supplies" Then
                If Not String.IsNullOrEmpty(txtSellectDate.Text) AndAlso IsDate(txtSellectDate.Text) Then
                    ledgerDateValue = DateTime.Parse(txtSellectDate.Text)
                End If
            ElseIf lblClass.Text = "MRO Consumables" Then
                If Not String.IsNullOrEmpty(txtSellectDateCons.Text) AndAlso IsDate(txtSellectDateCons.Text) Then
                    ledgerDateValue = DateTime.Parse(txtSellectDateCons.Text)
                End If
            End If

            ' --------------------------------------------------------------------------
            ' 4) Update m_item's unit_id
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog4",
            "console.log('Updating dbo.m_item with unit_id = " & drpConsOthersUnit.SelectedItem.Value & "');", True)
            objDerived.Execute("UPDATE dbo.m_item " &
                           "SET unit_id = " & drpConsOthersUnit.SelectedItem.Value &
                           " WHERE item_id = " & hdnItemNo.Value,
                           CommandType.Text)

            ' --------------------------------------------------------------------------
            ' 5) Gather classification, category, matrix
            ' --------------------------------------------------------------------------
            Dim classificationName As String =
            objDerived.GetValue("SELECT ClassificationName FROM dbo.tbl_Classification " &
                                "WHERE ClassificationId = " & ddClass.Text,
                                CommandType.Text)

            Dim category As Integer =
            objDerived.GetValue("SELECT a.item_particular_id " &
                                "FROM dbo.m_item AS a " &
                                "INNER JOIN ams.item_particular AS b ON a.item_particular_id = b.item_particular_id " &
                                "WHERE a.Item_ID = " & hdnItemNo.Value,
                                CommandType.Text)

            Dim matrix As String =
            objDerived.GetValue("SELECT id FROM tblclassmatrix " &
                                "WHERE classificationid = " & ddClass.Text &
                                "  AND ga_id = " & hdnGAId.Value &
                                "  AND item_id = " & hdnItemNo.Value,
                                CommandType.Text)

            If String.IsNullOrEmpty(matrix) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog5",
                "console.log('Inserting into tblclassmatrix => classificationId=" & ddClass.Text &
                ", ga_id=" & hdnGAId.Value & "');", True)

                objDerived.Execute("INSERT INTO tblclassmatrix (classificationid, ga_id, item_id, categoryid, bga_id) " &
                               "VALUES ('" & ddClass.Text & "', '" & hdnGAId.Value & "', '" & hdnItemNo.Value & "', '" & category & "', '0')",
                               CommandType.Text)
            End If

            ' --------------------------------------------------------------------------
            ' 6) SAVE AMS.Tb_Receiving
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog6",
            "console.log('Saving to AMS.Tb_Receiving');", True)

            Dim rcv As New Receiving.t_receiving
            With rcv
                .Received_Date = mainDateValue.ToString("MM/dd/yyyy")
                .ReceivedBY = 0
                .POHdr_ID = 0
                .PO_No = ""
                .Supplier_ID = 0
                .GA_ID = hdnGAId.Value
                .isAccepted = False
                .UserID = Session("@UserName")
            End With
            Dim rcvID As Long = rcv.save()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog7",
            "console.log('AMS.Tb_Receiving saved. rcvID=' + " & rcvID & ");", True)
            Session("Received_ID") = rcvID

            ' --------------------------------------------------------------------------
            ' 7) SAVE AMS.Tb_Receiving_Dtl
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog8",
            "console.log('Saving AMS.Tb_Receiving_Dtl');", True)

            ' Build location dynamically using StringBuilder
            Dim locationBuilder As New System.Text.StringBuilder()
            If Not String.IsNullOrEmpty(txtConsOthersBay.Text) Then locationBuilder.Append("Bay-").Append(txtConsOthersBay.Text)
            If Not String.IsNullOrEmpty(txtConsOthersColumn.Text) Then locationBuilder.Append(" Column-").Append(txtConsOthersColumn.Text)
            If Not String.IsNullOrEmpty(txtConsOthersFloor.Text) Then locationBuilder.Append(" Floor-").Append(txtConsOthersFloor.Text)
            If Not String.IsNullOrEmpty(txtConsOthersRoom.Text) Then locationBuilder.Append(" Room-").Append(txtConsOthersRoom.Text)
            If Not String.IsNullOrEmpty(txtConsOthersShelves.Text) Then locationBuilder.Append(" Shelves-").Append(txtConsOthersShelves.Text)
            If Not String.IsNullOrEmpty(txtConsOthersRack.Text) Then locationBuilder.Append(" Rack-").Append(txtConsOthersRack.Text)
            If Not String.IsNullOrEmpty(txtConsOthersBin.Text) Then locationBuilder.Append(" Bin-").Append(txtConsOthersBin.Text)

            Dim location As String = locationBuilder.ToString()

            Dim rcv_dtl As New Receiving.t_receiving_dtl
            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = hdnItemNo.Value
                .PO_Qty = qtyValue
                .Qty_Received = qtyValue
                .Cost = unitPriceValue
                .Condition = ""
                .Location = location
            End With

            Dim RcvDtl_ID As Long = rcv_dtl.save()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog9",
            "console.log('AMS.Tb_Receiving_Dtl record saved. RcvDtl_ID=' + " & RcvDtl_ID & ");", True)

            ' Calculate total cost for single-line receiving
            Dim totalCost As Decimal = qtyValue * unitPriceValue
            Session("ContractPrice") = totalCost

            ' --------------------------------------------------------------------------
            ' 8) SAVE OF PURCHASED ORDER (PO_Hdr)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog10",
            "console.log('Preparing purchase order data for PO_No=Starting Inventory');", True)

            Dim POnumber As String = "Starting Inventory"
            Dim pohdr_id As Long
            Dim POhdr As New t_purchase_order_hdr

            ' Handle txtContractprice if it exists
            Dim contractPriceDecimal As Decimal = totalCost
            Dim controlExists As Boolean = (Me.FindControl("txtContractprice") IsNot Nothing)
            If controlExists Then
                Dim ctrlPrice As TextBox = CType(Me.FindControl("txtContractprice"), TextBox)
                If ctrlPrice IsNot Nothing AndAlso IsNumeric(ctrlPrice.Text) Then
                    contractPriceDecimal = Convert.ToDecimal(ctrlPrice.Text)
                End If
            End If

            With POhdr
                .PO_No = POnumber
                .PO_Date = mainDateValue.ToString("MM/dd/yyyy")
                .Supplier_ID = 0
                .mode_of_procurement_id = 2
                .DeliveryTerm = 0
                .paymentTerm = 0
                .DeliveryDate = mainDateValue.ToString("MM/dd/yyyy")
                .DeliveryPlace = ""
                .isDelivered = True
                .pre_procurement_hdr_id = 0
                .withdv = False
                .ContractPrice = contractPriceDecimal
                .isStag = False
                .isContinueCutOff = False
                .isStopForCutOff = False
                .isShoppingA = False
                .isPublicInfra = False
                .isStraight = True
                .isApproved_PO_Mayor = True
                .isReceived_PO_Mayor = True
                .DateApproved_PO_Mayor = mainDateValue.ToString("MM/dd/yyyy")
                .DateReceived_PO_Mayor = mainDateValue.ToString("MM/dd/yyyy")
                .DateDisApprove = "01/01/1900"
                .isGasoline = False
                .isReimbursement = False
            End With

            ' Check if PO already exists
            Dim po_id As DataTable =
            objDerived.GetDataTable("SELECT pohdr_id FROM ams.po_hdr " &
                                    "WHERE po_no LIKE '" & POnumber & "' " &
                                    "  AND Supplier_ID = '0'",
                                    CommandType.Text)

            If po_id.Rows.Count = 0 Then
                ' No existing PO => Insert
                POhdr.ContractPrice = totalCost
                pohdr_id = POhdr.save()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog11",
                "console.log('New PO created. POHdr_ID=' + " & pohdr_id & ");", True)
            Else
                ' Existing PO => update total
                Dim existingPOID As Integer =
                objDerived.GetValue("SELECT pohdr_id FROM ams.po_hdr " &
                                    "WHERE po_no LIKE '" & POnumber & "' " &
                                    "  AND Supplier_ID = '0'",
                                    CommandType.Text)
                Dim TAmount As Decimal =
                objDerived.GetValue("SELECT ContractPrice FROM ams.po_hdr " &
                                    "WHERE pohdr_id = '" & existingPOID & "'",
                                    CommandType.Text)

                POhdr.ContractPrice = TAmount + totalCost
                POhdr.POHdr_ID = existingPOID
                pohdr_id = POhdr.update()

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog12",
                "console.log('Existing PO found. Updated POHdr_ID=' + " & pohdr_id & ");", True)
            End If

            objDerived.GetRecords("UPDATE AMS.PO_Hdr " &
                              "SET GA_ID = '" & hdnGAId.Value & "', ProjectName = 'Manual Encode' " &
                              "WHERE POHdr_ID = '" & pohdr_id & "'",
                              CommandType.Text)
            Session("POHdr_ID") = pohdr_id

            ' --------------------------------------------------------------------------
            ' 9) SAVE OF INSPECTION & ACCEPTANCE (AIR_Hdr)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog13",
            "console.log('Generating AIR and saving t_inspection_and_acceptance_hdr');", True)

            Dim objhdr As New t_inspection_and_acceptance_hdr
            Dim airhdr_id As Long
            Dim air As String =
            objDerived.GetValue("SELECT [AMS].[func_GenerateAIR]('" & mainDateValue.ToString("MM/dd/yyyy") & "')",
                                CommandType.Text)

            With objhdr
                .AIR_No = air
                .AIR_Date = mainDateValue
                .Date_Received = mainDateValue
                .Date_Inspect = mainDateValue
                .Date_Accepted = mainDateValue
                .Invoice_No = " "
                .Invoice_date = mainDateValue
                .PO_No = POnumber
                .Supplier_ID = 0
                .Signatory1 = " "
                .Signatory2 = " "
                .Signatory3 = " "
                .isComplete = True
                .POHdr_ID = Session("POHdr_ID")
                .RC_ID = 0
                .Function_ID = 0
            End With

            airhdr_id = objhdr.save()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog14",
            "console.log('AIR_Hdr saved. airhdr_id=' + " & airhdr_id & ");", True)
            Session("AIRHDR_ID") = airhdr_id

            objDerived.GetRecords("UPDATE AMS.AIR_Hdr " &
                              "SET UserID = '" & Session("@UserName") & "', " &
                              "    Received_ID = '" & Session("Received_ID") & "' " &
                              "WHERE AIRHdr_ID = '" & Session("AIRHDR_ID") & "'",
                              CommandType.Text)

            ' --------------------------------------------------------------------------
            ' 10) PO Details Save (t_purchase_order_dtl)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog15",
            "console.log('Saving t_purchase_order_dtl');", True)

            Dim POdtl As New t_purchase_order_dtl
            With POdtl
                .POHdr_ID = Session("POHdr_ID")
                .Item_ID = hdnItemNo.Value
                .cost = unitPriceValue
                .qty = qtyValue
                .remarks = "Manual Encode"
            End With
            POdtl.save()

            ' --------------------------------------------------------------------------
            ' 11) AIR Details (t_inspection_and_acceptance_dtl)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog16",
            "console.log('Saving t_inspection_and_acceptance_dtl');", True)

            Dim objdtl As New t_inspection_and_acceptance_dtl
            With objdtl
                .Item_ID = hdnItemNo.Value
                .Qty = qtyValue
                .Cost = unitPriceValue
                .AIRHdr_ID = Session("AIRHDR_ID")
                .GA_ID = hdnGAId.Value
            End With

            Dim iaDtl_ID As Integer = objdtl.save()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog17",
            "console.log('AIR_Dtl saved. iaDtl_ID=' + " & iaDtl_ID & ");", True)
            Session("AIRDtl_ID") = iaDtl_ID

            ' --------------------------------------------------------------------------
            ' 12) SAVE STOCK (AMS.Stock)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog18",
            "console.log('Saving to AMS.Stock');", True)

            ' Parse Warehouse safely
            Dim whVal As String = drpMROConsOthersWarehouse.SelectedValue
            If String.IsNullOrEmpty(whVal) OrElse Not IsNumeric(whVal) Then
                whVal = "0"
            End If

            ' Parse RC_ID
            Dim rcValString As String =
            objDerived.GetValue("SELECT DISTINCT [RC_id] FROM [dbo].[View_RespCenter_withFunctions] " &
                                "WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'",
                                CommandType.Text)
            Dim rcParsed As Integer = 0
            If Not String.IsNullOrEmpty(rcValString) AndAlso IsNumeric(rcValString) Then
                rcParsed = Convert.ToInt32(rcValString)
            End If

            ' Parse ReorderPt
            Dim reorderVal As Integer = 0
            If Not String.IsNullOrEmpty(txtConsOthersReOrderPt.Text) AndAlso IsNumeric(txtConsOthersReOrderPt.Text) Then
                reorderVal = Convert.ToInt32(txtConsOthersReOrderPt.Text)
            End If

            Dim objStock As New Supplies_Stock
            With objStock
                .StockDate = mainDateValue
                .Item_ID = hdnItemNo.Value
                .Qty = qtyValue
                .Balance = qtyValue
                .Location = location
                .Expiration_Date = expiryDateValue
                .Cost = unitPriceValue
                .Issuance = 0
                .RC_ID = rcParsed
                .Function_ID = 0
                .Project_ID = 0
                .Program_id = 0
                .F_ID = 4
                .AIRDtl_ID = Session("AIRDtl_ID")
                .GA_ID = hdnGAId.Value
                .Warehouseid = Convert.ToInt32(whVal)
                .ReorderPt = reorderVal
                .Batch = txtConsOthersBatch1.Text

            End With

            Dim StockID As Long = objStock.save()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog19",
            "console.log('AMS.Stock saved. StockID=' + " & StockID & ");", True)

            objDerived.GetRecords("UPDATE AMS.Stock " &
                              "SET Received_ID = '" & rcvID & "' " &
                              "WHERE StockID = '" & StockID & "'",
                              CommandType.Text)

            ' --------------------------------------------------------------------------
            ' 13) SAVE LEDGER (AMS.TbStock_Ledger)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog20",
            "console.log('Saving to AMS.TbStock_Ledger');", True)

            Dim objStockLedger As New t_StockLedger
            With objStockLedger
                .StockID = StockID
                .Trans_Type = "Starting Balance"
                .Ref = air
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .ReceivedBy = ""
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .dDate = ledgerDateValue

                .Item_ID = hdnItemNo.Value
                .DebitQty = qtyValue.ToString()
                .DebitCost = FormatNumber(unitPriceValue * qtyValue, 2)
                .DebitUnit =
                objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit " &
                                    "INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID " &
                                    "WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'",
                                    CommandType.Text)
                .BalanceUnit =
                objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit " &
                                    "INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID " &
                                    "WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'",
                                    CommandType.Text)
                .BalanceQty = 0
                .BalanceCost = 0
            End With
            objStockLedger.save()

            ' --------------------------------------------------------------------------
            ' 14) SAVE TbNonFood (Specific for Non-Food Items)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog21",
            "console.log('Saving TbNonFood record');", True)

            Dim objNonFood As New ConsolidatedMedicineSaving.TbNonFood
            With objNonFood
                .StockId = StockID
                .AIRDtl_ID = Session("AIRDtl_ID")
                .Item_ID = hdnItemNo.Value
                .ActualPrice = txtConsOthersUnitPrice.Text
                .ItemDesc = txtConsOthersName.Text
                .BrandName = txtConsOthersBrandName.Text
                .Supplier_Id = 0
                .Form = txtConsOthersForm.Text
                .OTCRx = ""
                .Batch = txtConsOthersBatch1.Text
                .Lot = txtConsOthersLot.Text
                .Storage = ""
                .Status = "Accepted"
                If Not String.IsNullOrEmpty(txtDate.Text) AndAlso IsDate(txtDate.Text) Then
                    .DeliveryDate = DateTime.Parse(txtDate.Text)
                Else
                    .DeliveryDate = #1/1/1900# ' Assign a default date or handle accordingly
                End If

                .Mftgdate = #1/1/1900#
                .EpiryDate = #1/1/1900#
                .Alert = #1/1/1900#

                .Depreciationrate = 0.0
                .Depreciationvalue = 0.0
            End With

            Dim NonFoodID As Long = objNonFood.save()
            objDerived.GetRecords("UPDATE AMS.TbNonFood " &
                              "SET Received_ID = '" & rcvID & "' " &
                              "WHERE NonFood_ID = '" & NonFoodID & "'",
                              CommandType.Text)

            ' --------------------------------------------------------------------------
            ' 15) Refresh the ledger grid
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogRefreshGrid", "console.log('Refreshing ledger grid after SaveMROSupplies');", True)

            Dim dtStock As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
            If dtStock.Rows.Count < 4 Then
                dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
            End If

            grdLedger.DataSource = dtStock
            grdLedger.DataBind()
            ledger()


            ' --------------------------------------------------------------------------
            ' 16) Final UI updates
            ' --------------------------------------------------------------------------
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")

            ' Check reorder point
            Dim ropVal As String =
            objDerived.GetValue("SELECT ReorderPt FROM ams.Stock WHERE Item_ID = '" & hdnItemNo.Value & "'",
                                CommandType.Text)

            Dim c As Integer = Convert.ToInt32(qtyValue)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog23",
            "console.log('Check ROP => ROP=' + '" & ropVal & "' + ', QTY=' + " & c & ");", True)

            If Not String.IsNullOrEmpty(ropVal) AndAlso IsNumeric(ropVal) Then
                If Convert.ToInt32(ropVal) >= c Then
                    ModalPopupExtender3.Show()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog24",
                    "console.log('ROP reached. Showing ModalPopupExtender3.');", True)
                End If
            End If

            loadStockOfficeSupplies()
            selectitemdescMROConsOthers()

            ' --------------------------------------------------------------------------
            ' End of method tracer
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogEnd",
            "console.log('saveConsOthers: Method end');", True)

        Catch ex As Exception
            ' --------------------------------------------------------------------------
            ' Enhanced exception handling
            ' --------------------------------------------------------------------------
            Dim safeMessage As String = ex.Message.Replace("'", "\'").Replace(vbCrLf, " ").Replace(vbLf, " ")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogError",
            "console.error('Exception in saveConsOthers: " & safeMessage & "');", True)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error: " & ex.Message)
        End Try
    End Sub


    'Public Sub saveConsOthers()
    '    If txtConsOthersName.text = "" Or txtConsOthersBrandName.text = "" Or txtConsOthersUnitPrice.text = "" Or txtConsOthersQuantity.text = "" Then
    '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
    '    Else

    '        'Dim unit As String = objDerived.getvalue("select unit_id From dbo.m_item where item_id = " & hdnItemNo.value, commandtype.text)
    '        'If unit = "" Then
    '        objDerived.Execute("Update dbo.m_item set unit_id = " & drpConsOthersUnit.selecteditem.value & " where item_id = " & hdnItemNo.value, CommandType.Text)
    '        'End If
    '        Dim classification As String = objDerived.getvalue("Select ClassificationName from dbo.tbl_Classification where ClassificationId = " & ddClass.text, commandtype.text)
    '        Dim category As Integer = objDerived.getvalue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.value, commandtype.text)
    '        Dim matrix As String = objDerived.getvalue("select id From tblclassmatrix where classificationid = " & ddClass.text & " and ga_id = " & hdnGAId.value & " and item_id = " & hdnItemNo.value & "", commandtype.text)

    '        If matrix = "" Then
    '            objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id) values('" & ddClass.text & "','" & hdnGAId.value & "','" & hdnItemNo.value & "','" & category & "','0')", commandtype.text)
    '        End If

    '        '--------------------------------------------------------------
    '        '=-= SAVE AMS.Tb_Receiving
    '        Dim rcv As New Receiving.t_receiving
    '        With rcv
    '            .Received_Date = txtDate.Text
    '            .ReceivedBY = 0
    '            .POHdr_ID = 0
    '            .PO_No = ""
    '            .Supplier_ID = 0
    '            .GA_ID = hdnGAId.value
    '            .isAccepted = False
    '            .UserID = Session("@UserName")
    '        End With
    '        Dim rcvID As Long = rcv.save

    '        Session("Received_ID") = rcvID

    '        Dim rcv_dtl As New Receiving.t_receiving_dtl
    '        Dim total As Decimal = 0
    '        Dim txtPrice As TextBox = CType(txtConsOthersUnitPrice, TextBox)
    '        Dim txtqty As TextBox = CType(txtConsOthersQuantity, TextBox)
    '        Dim location As String

    '        'If String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
    '        '    location = "Bay-" & txtConsOthersBay.text
    '        'ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
    '        '    location = "Column-" & txtConsOthersColumn.text
    '        'ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
    '        '    location = "Floor-" & txtConsOthersFloor.text
    '        'ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
    '        '    location = "Room-" & txtConsOthersRoom.text
    '        'ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
    '        '    location = "Shelves-" & txtConsOthersShelves.text
    '        'ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersBin.Text) Then
    '        '    location = "Rack-" & txtConsOthersRack.text
    '        'ElseIf String.IsNullOrEmpty(txtConsOthersBay.Text) And String.IsNullOrEmpty(txtConsOthersColumn.Text) And String.IsNullOrEmpty(txtConsOthersFloor.Text) And String.IsNullOrEmpty(txtConsOthersRoom.Text) And String.IsNullOrEmpty(txtConsOthersShelves.Text) And String.IsNullOrEmpty(txtConsOthersRack.Text) Then
    '        '    location = "Bin-" & txtConsOthersBin.text
    '        'End If


    '        If txtConsOthersBay.Text <> "" Then
    '            location = "Bay-" & txtConsOthersBay.Text
    '        End If

    '        If txtConsOthersColumn.Text <> "" Then
    '            location = location + " " + "Column-" & txtConsOthersColumn.Text
    '        End If

    '        If txtConsOthersFloor.Text <> "" Then
    '            location = location + " " + "Floor-" & txtConsOthersFloor.Text
    '        End If

    '        If txtConsOthersRoom.Text <> "" Then
    '            location = location + " " + "Room-" & txtConsOthersRoom.Text
    '        End If

    '        If txtConsOthersShelves.Text <> "" Then
    '            location = location + " " + "Shelves-" & txtConsOthersShelves.Text
    '        End If

    '        If txtConsOthersRack.Text <> "" Then
    '            location = location + " " + "Rack-" & txtConsOthersRack.Text
    '        End If

    '        If txtConsOthersBin.Text <> "" Then
    '            location = location + " " + "Bin-" & txtConsOthersBin.Text
    '        End If




    '        With rcv_dtl
    '            .Received_ID = rcvID
    '            .Item_ID = hdnItemNo.value
    '            .PO_Qty = txtqty.Text
    '            .Qty_Received = txtqty.Text
    '            .Cost = txtPrice.Text
    '            .Condition = ""
    '            .Location = location
    '        End With
    '        Dim RcvDtl_ID As Long = rcv_dtl.save

    '        Dim t1 As Decimal
    '        t1 = txtPrice.Text * txtqty.Text
    '        total = total + t1
    '        Session("ContractPrice") = total


    '        '=-= SAVE OF PURCHASED ORDER
    '        Dim pohdr_id As Long
    '        Dim POhdr As New t_purchase_order_hdr
    '        Dim POnumber As String = "Starting Inventory"


    '        POhdr.PO_No = POnumber
    '        POhdr.PO_Date = txtDate.Text
    '        POhdr.Supplier_ID = 0
    '        POhdr.mode_of_procurement_id = 2
    '        POhdr.DeliveryTerm = 0
    '        POhdr.paymentTerm = 0
    '        POhdr.DeliveryDate = txtDate.Text
    '        POhdr.DeliveryPlace = ""
    '        POhdr.isDelivered = True
    '        POhdr.isDelivered = True
    '        POhdr.pre_procurement_hdr_id = 0
    '        POhdr.withdv = False
    '        'POhdr.ContractPrice = CType(txtContractprice.Text, Decimal)
    '        POhdr.isStag = False
    '        POhdr.isContinueCutOff = False
    '        POhdr.isStopForCutOff = False
    '        POhdr.isShoppingA = False
    '        POhdr.isPublicInfra = False
    '        POhdr.isStraight = True
    '        POhdr.isApproved_PO_Mayor = True
    '        POhdr.isReceived_PO_Mayor = True
    '        POhdr.DateApproved_PO_Mayor = txtDate.Text
    '        POhdr.DateReceived_PO_Mayor = txtDate.Text
    '        POhdr.DateDisApprove = "01/01/1900"
    '        POhdr.isGasoline = False
    '        POhdr.isReimbursement = False

    '        Dim po_id As New DataTable
    '        po_id = objDerived.GetDataTable("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
    '        If po_id.Rows.Count = 0 Then
    '            POhdr.ContractPrice = CType(Session("ContractPrice"), Decimal)
    '            pohdr_id = POhdr.save()
    '        Else
    '            Dim poid As Integer
    '            Dim TAmount As Decimal
    '            poid = objDerived.GetValue("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
    '            TAmount = objDerived.GetValue("Select ContractPrice from ams.po_hdr where pohdr_id = '" & poid & "'", CommandType.Text)

    '            POhdr.ContractPrice = CType(TAmount + CType(Session("ContractPrice"), Decimal), Decimal)
    '            POhdr.POHdr_ID = poid
    '            pohdr_id = POhdr.update()
    '        End If

    '        objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = '" & hdnGAId.value & "', ProjectName = 'Manual Encode' WHERE POHdr_ID = '" & pohdr_id & "'", CommandType.Text)
    '        Session("POHdr_ID") = pohdr_id



    '        '=-= SAVE OF INSPECTION & ACCEPTANCE
    '        Dim objhdr As New t_inspection_and_acceptance_hdr
    '        Dim airhdr_id As Long
    '        Dim air As String
    '        air = objDerived.GetValue("select [AMS].[func_GenerateAIR]('" & txtDate.Text & "')", CommandType.Text)
    '        With objhdr
    '            .AIR_No = air
    '            .AIR_Date = DateTime.Parse(txtDate.Text)
    '            .Date_Received = DateTime.Parse(txtDate.Text)
    '            .Date_Inspect = DateTime.Parse(txtDate.Text)
    '            .Date_Accepted = DateTime.Parse(txtDate.Text)
    '            .Invoice_No = " "
    '            .Invoice_date = DateTime.Parse(txtDate.Text)
    '            .PO_No = " "
    '            .Supplier_ID = 0
    '            .Signatory1 = " "
    '            .Signatory2 = " "
    '            .Signatory3 = " "
    '            .isComplete = True
    '            .POHdr_ID = 0
    '            'objhdr.remarks = txtIAremarks.Text
    '            .RC_ID = 0
    '            .Function_ID = 0
    '        End With
    '        airhdr_id = objhdr.save()
    '        Session("AIRHDR_ID") = airhdr_id
    '        objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET UserID = '" & Session("@UserName") & "', Received_ID = '" & Session("Received_ID") & "' WHERE AIRHdr_ID = '" & Session("AIRHDR_ID") & "'", CommandType.Text)
    '        Dim objdtl As New t_inspection_and_acceptance_dtl


    '        '=-= PO Details Save
    '        Dim POdtl As New t_purchase_order_dtl
    '        Dim txtPricePO As TextBox = CType(txtConsOthersUnitPrice, TextBox)
    '        Dim txtqtyPO As TextBox = CType(txtConsOthersQuantity, TextBox)

    '        POdtl.POHdr_ID = Session("POHdr_ID")
    '        POdtl.Item_ID = hdnItemNo.value
    '        POdtl.cost = txtPricePO.Text
    '        POdtl.qty = txtqtyPO.Text
    '        POdtl.remarks = "Manual Encode"
    '        POdtl.save()

    '        '=-= AIR DETAILS
    '        Dim txtPriceair As TextBox = CType(txtConsOthersUnitPrice, TextBox)
    '        Dim txtqtyair As TextBox = CType(txtConsOthersQuantity, TextBox)

    '        objdtl.Item_ID = hdnItemNo.value
    '        objdtl.Qty = txtqtyair.Text
    '        objdtl.Cost = CType(txtPriceair.Text, Decimal)
    '        objdtl.AIRHdr_ID = Session("AIRHDR_ID")
    '        objdtl.GA_ID = hdnGAId.value
    '        Dim iaDtl_ID As Integer = objdtl.save()
    '        Session("AIRDtl_ID") = iaDtl_ID

    '        Dim objStock As New Supplies_Stock

    '        '=-= SAVE STOCK
    '        With objStock
    '            '.StockID = StockID
    '            .StockDate = DateTime.Parse(txtDate.Text)
    '            .Item_ID = hdnItemNo.value
    '            .Qty = txtqtyair.Text
    '            .Balance = txtqtyair.Text
    '            Dim locations As String
    '            If txtConsOthersBay.Text <> "" Then
    '                locations = "Bay-" & txtConsOthersBay.Text
    '            End If

    '            If txtConsOthersColumn.Text <> "" Then
    '                locations = locations + " " + "Column-" & txtConsOthersColumn.Text
    '            End If

    '            If txtConsOthersFloor.Text <> "" Then
    '                locations = locations + " " + "Floor-" & txtConsOthersFloor.Text
    '            End If

    '            If txtConsOthersRoom.Text <> "" Then
    '                locations = locations + " " + "Room-" & txtConsOthersRoom.Text
    '            End If

    '            If txtConsOthersShelves.Text <> "" Then
    '                locations = locations + " " + "Shelves-" & txtConsOthersShelves.Text
    '            End If

    '            If txtConsOthersRack.Text <> "" Then
    '                locations = locations + " " + "Rack-" & txtConsOthersRack.Text
    '            End If

    '            If txtConsOthersBin.Text <> "" Then
    '                locations = locations + " " + "Bin-" & txtConsOthersBin.Text
    '            End If

    '            .Location = locations
    '            .Expiration_Date = "1/1/1900"
    '            .Cost = CType(txtPriceair.Text, Decimal)
    '            .Issuance = 0
    '            .RC_ID = objDerived.GetValue("SELECT DISTINCT [RC_id] FROM [dbo].[View_RespCenter_withFunctions] WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'", CommandType.Text)
    '            .Function_ID = 0
    '            .Project_ID = 0
    '            .Program_id = 0
    '            .F_ID = 4
    '            .AIRDtl_ID = Session("AIRDtl_ID")
    '            .GA_ID = hdnGAId.value
    '            .Warehouseid = drpMROConsOthersWarehouse.selectedvalue()
    '            .ReorderPt = iif(IsNumeric(txtConsOthersReOrderPt.text), txtConsOthersReOrderPt.text, 0)


    '        End With

    '        Dim StockID As Long = objStock.save
    '        objDerived.GetRecords("UPDATE AMS.Stock SET  Received_ID = '" & rcvID & "' WHERE StockID = '" & StockID & "'", CommandType.Text)

    '        Dim objStockLedger As New t_StockLedger
    '        '---------------------------------------------------------
    '        '====== save ledger ========
    '        With objStockLedger
    '            '.StockLedger_ID = StockLedger_ID
    '            .StockID = StockID
    '            .Trans_Type = "Starting Balance"
    '            .Ref = air
    '            '    .AccountablePerson = objDerived.GetValue("SELECT ContactP FROM  dbo.Supplier where Supplier_Id ='" & Session("Supplier_Id") & "' ", CommandType.Text)
    '            .Department = ""
    '            .Position = ""
    '            .AcceptedBy = ""
    '            .InspectedBy = ""
    '            .ReceivedBy = ""
    '            .CreditQty = "0"
    '            .CreditUnit = "-"
    '            .CreditCost = "0.00"
    '            If lblClass.Text = "MRO Equipment" Then
    '                .dDate = DateTime.Parse(txtEAcqDate.Text)
    '            ElseIf lblClass.Text = "MRO Supplies" Then
    '                .dDate = DateTime.Parse(txtSellectDate.Text)
    '            ElseIf lblClass.Text = "MRO Consumables" Then
    '                .dDate = DateTime.Parse(txtSellectDateCons.Text)
    '            End If
    '            .Item_ID = hdnItemNo.value
    '            .DebitQty = txtqtyair.Text
    '            .DebitCost = FormatNumber(CType(txtPriceair.Text, Decimal) * txtqtyair.Text, 2)
    '            .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.value & "'", CommandType.Text)
    '            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.value & "'", CommandType.Text)
    '            .BalanceQty = 0
    '            .BalanceCost = 0
    '            .save()
    '        End With

    '        Dim objOfficeSup As New SupplieINFO
    '        Dim objNonFood As New ConsolidatedMedicineSaving.TbNonFood

    '        With objNonFood
    '            '.NonFood_ID = NonFood_ID
    '            .StockId = StockID
    '            .AIRDtl_ID = Session("AIRDtl_ID")
    '            .Item_ID = hdnItemNo.value
    '            .ActualPrice = txtConsOthersUnitPrice.text
    '            .ItemDesc = txtConsOthersName.text
    '            .BrandName = txtConsOthersBrandName.text
    '            .Supplier_Id = 0
    '            .Form = txtConsOthersForm.text
    '            .OTCRx = ""
    '            .Batch = txtConsOthersBatch1.text
    '            .Lot = txtConsOthersLot.text
    '            .Storage = ""
    '            .Status = "Accepted"
    '            .DeliveryDate = DateTime.Parse(txtDate.Text)
    '            .Mftgdate = txtMDateConsOthers.text
    '            .EpiryDate = txtEDateConsOthers.text
    '            .Alert = txtAlertConsOthers.text
    '            .Depreciationrate = 0.0
    '            .Depreciationvalue = 0.0
    '        End With

    '        Dim NonFoodID As Long = objNonFood.save
    '        objDerived.GetRecords("UPDATE AMS.TbNonFood SET Received_ID = '" & rcvID & "' WHERE NonFood_ID = '" & NonFoodID & "'", CommandType.Text)

    '        Dim dtStock As New datatable
    '        dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.value & "'", CommandType.Text)
    '        If dtStock.Rows.Count < 4 Then
    '            dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
    '        End If
    '        grdLedger.DataSource = dtStock
    '        grdLedger.DataBind()
    '        'loadCleartext()

    '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")
    '        Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.value & "'", CommandType.Text)
    '        Dim c As Integer = txtConsOthersQuantity.Text
    '        If a >= c Then
    '            ModalPopupExtender3.show()
    '        End If
    '        loadStockOfficeSupplies()
    '        selectitemdescMROConsOthers()
    '    End If

    'End Sub








    Protected Sub btnConsOthersSave_Click(sender As Object, e As EventArgs)
        If btnConsOthersSave.Text = "SAVE" Then
            saveConsOthers()
        ElseIf btnConsOthersSave.Text = "UPDATE" Then
            UpdateConsOthers()
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Ledger Card Updated Successfully")
        Else
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()

            ModalPopupExtender2.Show()

        End If

    End Sub
    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Item_ID") = hdnItemNo.Value
        ''  Me.Page.Response.Redirect("~/Records/rpt_stockcard.aspx")



        Dim url As String = "rpt_stockcard.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
    Protected Sub drpItemDesc2_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectitemdescMROsupplies()
    End Sub
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpUnit.DataSource = dt
        drpUnit.DataTextField = ("Description")
        drpUnit.DataValueField = ("Unit_ID")
        drpUnit.DataBind()
        drpConsOthersUnit.DataSource = dt
        drpConsOthersUnit.DataTextField = ("Description")
        drpConsOthersUnit.DataValueField = ("Unit_ID")
        drpConsOthersUnit.DataBind()

        drpMROEquipmentUnit.DataSource = dt
        drpMROEquipmentUnit.DataTextField = ("Description")
        drpMROEquipmentUnit.DataValueField = ("Unit_ID")
        drpMROEquipmentUnit.DataBind()

    End Sub


    Public Sub selectitemdescMROsupplies()

        Dim CY As String = "CY" & Year(txtDate.Text)
        Dim dtitemdetails As New DataTable
        loadCleartext()
        loadUnit()


        If drpItemDesc2.SelectedValue = "" Then
            dtitemdetails = objDerived.GetDataTable("select a.Item_ID,Item_Desc,isnull(brand,''),isnull(color,''),isnull(size,''),isnull(" & CY & ",0.00) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID = null", CommandType.Text)
        Else
            dtitemdetails = objDerived.GetDataTable("select a.Item_ID,Item_Desc,isnull(brand,''),isnull(color,''),isnull(size,''),isnull(" & CY & ",0.00),isnull(Unit_ID,1)  from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & drpItemDesc2.SelectedValue, CommandType.Text)

        End If
        If dtitemdetails.Rows.Count > 0 Then
            hdnItemNo.Value = dtitemdetails.Rows(0).Item(0)
            txtBrandName2.Text = dtitemdetails.Rows(0).Item(2)
            txtColor.Text = dtitemdetails.Rows(0).Item(3)
            txtSize.Text = dtitemdetails.Rows(0).Item(4)
            txtUnitPrice.Text = dtitemdetails.Rows(0).Item(4)
            drpUnit.Items.FindByValue(dtitemdetails.Rows(0).Item(6)).Selected = True
        End If
        SelectMROsupplies_from_dropdown()

    End Sub
    Public Sub SelectMROsupplies_from_dropdown()
        '11212022
        Dim CY As String = "CY" & Year(txtDate.Text)

        Dim balance As Integer
        hdnGAId.Value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
        balance = objDerived.GetValue("select isnull(sum(Qty),0) from ams.Stock where Item_ID = " & hdnItemNo.Value, CommandType.Text)

        If balance <> 0 Then
            Dim dt As New DataTable
            '02132023
            dt = objDerived.GetDataTable("select a.Description,a.BrandName,a.Size,a.Color,a.DepreciatedRate,a.DepreciatedValue,a.Length,a.Width,a.Height,a.Weight,b.Cost,convert(int,b.Qty) ,isnull(b.Location,' - '),isnull(b.warehouse_id,1) ,isnull(a.componentof,''),b.ReorderPt,b.StockDate  From [AMS].[TBSupplies_Info] as a inner join ams.Stock as b on a.StockID = b.StockID  where Item_ID =" & hdnItemNo.Value, CommandType.Text)


            Dim textboxes() As TextBox = {txtColor, txtSize, txtDepRate, txtBrandName2, txtItemDesc2, txtLenght,
                              txtWidth, txtHeight, txtWeight, txtDepValue, txtUnitPrice, txtQuantity,
                              txtComponentof, txtBay, txtColumn, txtFloor, txtRoom, txtShelves,
                              txtRack, txtBin}

            For Each textbox As TextBox In textboxes
                textbox.ReadOnly = False
            Next

        Else
            Dim dt As New DataTable
            Dim obj As New BaseClasses.Items
            txtItemDesc2.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtBrandName2.Text = obj.GetValue("select Brand From dbo.m_item where Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtSize.Text = obj.GetValue("select size From dbo.m_item where Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtColor.Text = obj.GetValue("select color From dbo.m_item where Item_ID =" & hdnItemNo.Value, CommandType.Text)


            Dim textboxes() As TextBox = {txtColor, txtSize, txtDepRate, txtBrandName2, txtItemDesc2, txtLenght,
                              txtWidth, txtHeight, txtWeight, txtDepValue, txtUnitPrice, txtQuantity,
                              txtComponentof, txtBay, txtColumn, txtFloor, txtRoom, txtShelves,
                              txtRack, txtBin}

            For Each textbox As TextBox In textboxes
                textbox.ReadOnly = False
            Next

            txtUnitPrice.Text = obj.GetValue("select " & CY & " From dbo.m_item_detail where Item_ID =" & hdnItemNo.Value, CommandType.Text)



            DRP.Text = ""
            LTD.Text = ""
            RP.Text = ""
            txtReOrderPt.Text = ""

            btnSave.Text = "SAVE"
            btnSave.Enabled = True
            btnCancel.Enabled = True

            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("select reorderPT from dbo.m_item where  Item_ID='" & hdnItemNo.Value & "'", CommandType.Text)
            If dt1.Rows.Count > 0 Then
                txtReOrderPt.Text = dt1.Rows(0).Item(0)
                Session("paramRP") = dt1.Rows(0).Item(0)

            Else
            End If
            ' txtItemDesc2.text = dt.Rows(0).Item(0)
        End If
        ledger()

    End Sub

    Protected Sub drpConsOthersName_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectitemdescMROConsOthers()
    End Sub

    Public Sub selectitemdescMROConsOthers()

        Dim CY As String = "CY" & Year(txtDate.Text)
        Dim dtitemdetails As New DataTable
        loadUnit()
        loadCleartext()

        If drpConsOthersName.SelectedValue = "" Then
            dtitemdetails = objDerived.GetDataTable("select a.Item_ID,Item_Desc,isnull(brand,''),isnull(color,''),isnull(size,''),isnull(" & CY & ",0.00) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID = null", CommandType.Text)
        Else
            dtitemdetails = objDerived.GetDataTable("select a.Item_ID,Item_Desc,isnull(brand,''),isnull(color,''),isnull(size,''),isnull(" & CY & ",0.00),isnull(Unit_ID,1)  from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & drpConsOthersName.SelectedValue, CommandType.Text)

        End If
        If dtitemdetails.Rows.Count > 0 Then
            hdnItemNo.Value = dtitemdetails.Rows(0).Item(0)
            txtConsOthersBrandName.Text = dtitemdetails.Rows(0).Item(2)
            txtColor.Text = dtitemdetails.Rows(0).Item(3)
            txtSize.Text = dtitemdetails.Rows(0).Item(4)
            txtConsOthersUnitPrice.Text = dtitemdetails.Rows(0).Item(5)
            drpConsOthersUnit.Items.FindByValue(dtitemdetails.Rows(0).Item(6)).Selected = True
        Else
            hdnItemNo.Value = -1
        End If
        SelectMROConsOthers_from_dropdown()

    End Sub

    Protected Sub drpMROEquipmentName_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectitemdescMROEquipment()
    End Sub

    Public Sub selectitemdescMROEquipment()

        Dim CY As String = "CY" & Year(txtDate.Text)
        Dim dtitemdetails As New DataTable
        loadUnit()

        If drpMROEquipmentName.SelectedValue = "" Then
            dtitemdetails = objDerived.GetDataTable("select a.Item_ID,Item_Desc,isnull(brand,''),isnull(color,''),isnull(size,''),isnull(" & CY & ",0.00) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID = null", CommandType.Text)

        Else
            dtitemdetails = objDerived.GetDataTable("select a.Item_ID,Item_Desc,isnull(PowerInput,''),isnull(Model,''),isnull(Dimension,''),isnull(CY2022,0.00),isnull(Unit_ID,1) ,isnull(AreaCapacity,0.00),isnull(Warranty,0.00)  from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & drpMROEquipmentName.SelectedValue, CommandType.Text)

        End If

        If dtitemdetails.Rows.Count > 0 Then
            hdnItemNo.Value = dtitemdetails.Rows(0).Item(0)
            txtMROEquipmentName.Text = dtitemdetails.Rows(0).Item(1)
            txtequipmentdesciption.Text = dtitemdetails.Rows(0).Item(1)
            txtequipmentpowerinput.Text = dtitemdetails.Rows(0).Item(2)
            txtequipmentmodel.Text = dtitemdetails.Rows(0).Item(3)
            txtequipmentdimension.Text = dtitemdetails.Rows(0).Item(4)
            txtEAcqCost.Text = dtitemdetails.Rows(0).Item(5)
            drpConsOthersUnit.Items.FindByValue(dtitemdetails.Rows(0).Item(6)).Selected = True
            txtequipmentareacapacity.Text = dtitemdetails.Rows(0).Item(7)
            txtequipmentwaranty.Text = dtitemdetails.Rows(0).Item(8)

        End If
        SelectMROEquipment_from_dropdown()

    End Sub

    Public Sub SelectMROEquipment_from_dropdown()
        Dim CYear As String = "CY" & Year(txtDate.Text)
        Dim itemid As String
        loadUnit()
        If drpMROEquipmentName.Text = "" Then

            itemid = "0"
        Else
            itemid = drpMROEquipmentName.SelectedValue
        End If
        Dim balance As Integer
        hdnGAId.Value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
        balance = objDerived.GetValue("select isnull(sum(Qty),0) from ams.Stock where Item_ID = " & hdnItemNo.Value, CommandType.Text)

        'If balance <> 0 Then
        '    Dim dt As New DataTable
        '    dt = objDerived.GetDataTable("select  a.ItemDesc,a.BrandName,b.Cost,convert(int,b.Qty),isnull(PowerInput,''),isnull(Model,''),isnull(Dimension,''),isnull(AreaCapacity,0.00),isnull(Warranty,0.00) ,isnull(DeliveryDate, ''),isnull(MarketValue, 0),isnull(SalvageValue, 0),isnull(NoYears, 0),isnull(UsefulLife, 0),specs,isnull(b.Location,' - '),isnull(b.warehouse_id,1),b.ReorderPt, ISNULL(a.DepreciationRate,0),a.DeliveryDate,a.DepreciationValue   From [AMS].TbNonFood as a inner join ams.Stock as b on a.StockID = b.StockID   where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
        '    txtMROEquipmentName.Text = dt.Rows(0).Item(0)
        '    txtMROEquipmentName.ReadOnly = True
        '    txtequipmentdesciption.Text = dt.Rows(0).Item(0)
        '    txtequipmentdesciption.ReadOnly = True
        '    txtEAcqCost.Text = dt.Rows(0).Item(2)
        '    txtEAcqCost.ReadOnly = True
        '    txtEquipmentQuantity.Text = dt.Rows(0).Item(3)
        '    txtEquipmentQuantity.ReadOnly = True
        '    txtequipmentpowerinput.Text = dt.Rows(0).Item(4)
        '    txtequipmentpowerinput.ReadOnly = True
        '    txtequipmentmodel.Text = dt.Rows(0).Item(5)
        '    txtequipmentmodel.ReadOnly = True

        '    txtequipmentdimension.Text = dt.Rows(0).Item(6)
        '    txtequipmentdimension.ReadOnly = True
        '    txtequipmentareacapacity.Text = dt.Rows(0).Item(7)
        '    txtequipmentareacapacity.ReadOnly = True
        '    txtequipmentwaranty.Text = dt.Rows(0).Item(8)
        '    txtequipmentwaranty.ReadOnly = True
        '    txtSpecification.Text = ""
        '    txtSpecification.ReadOnly = True
        '    txtEAcqDate.Text = dt.Rows(0).Item(9)
        '    txtEAcqDate.ReadOnly = True

        '    txtEMarketValue.Text = dt.Rows(0).Item(10)
        '    txtEMarketValue.ReadOnly = True
        '    txtSalvageValue.Text = dt.Rows(0).Item(11)
        '    txtSalvageValue.ReadOnly = True
        '    txtNoYears.Text = dt.Rows(0).Item(12)
        '    txtNoYears.ReadOnly = True
        '    txtequipmentdepreciatedvalue.Text = FormatNumber(0, 2)
        '    txtequipmentdepreciatedvalue.ReadOnly = True
        '    lblequipmentdepreciatedRate.Text = dt.Rows(0).Item(18)

        '    lblequipmentdepreciatedRate.ReadOnly = True
        '    txtUsefulLife.Text = dt.Rows(0).Item(13)
        '    txtUsefulLife.ReadOnly = True
        '    Session("useful_life") = txtUsefulLife.Text
        '    txtSpecification.Text = dt.Rows(0).Item(14).ToString
        '    txtequipmentReOrderPt.Text = dt.Rows(0).Item(17).ToString
        '    txtEAcqDate.Text = dt.Rows(0).Item(19)
        '    txtDepreciationValue.Text = dt.Rows(0).Item(20)
        '    Dim unit As Integer = objDerived.GetValue("select unit_id From dbo.m_item where Item_ID =" & hdnItemNo.Value, CommandType.Text)
        '    drpMROEquipmentUnit.Items.FindByValue(unit).Selected = True
        '    btnEquipmentSave.Text = "EDIT"
        '    btnEquipmentSave.Enabled = True
        '    btnEquipmentCancel.Enabled = False
        '    DRP.Text = ""
        '    LTD.Text = ""
        '    RP.Text = ""

        '    If dt.Rows(0).Item(17) >= dt.Rows(0).Item(3) Then
        '        ModalPopupExtender3.Show()
        '    End If

        '    Dim location As String
        '    location = dt.Rows(0).Item(15)

        '    Dim locationsplit As String() = location.Split(" ")
        '    If location.Contains("Bay") Then
        '        Dim a As String = locationsplit(0)
        '        Dim a1 As String() = a.Split("-")
        '        txtEquipmentBay.Text = a1(1)
        '        On Error Resume Next
        '    Else
        '        txtEquipmentBay.Text = ""
        '    End If

        '    If location.Contains("Column") Then
        '        Dim a As String = locationsplit(1)
        '        Dim a1 As String() = a.Split("-")
        '        txtEquipmentColumn.Text = a1(1)
        '        On Error Resume Next
        '    Else
        '        txtEquipmentColumn.Text = ""
        '    End If

        '    If location.Contains("Floor") Then
        '        Dim a As String = locationsplit(2)
        '        Dim a1 As String() = a.Split("-")
        '        txtEquipmentFloor.Text = a1(1)
        '        On Error Resume Next
        '    Else
        '        txtEquipmentFloor.Text = ""
        '    End If

        '    If location.Contains("Room") Then
        '        Dim a As String = locationsplit(3)
        '        Dim a1 As String() = a.Split("-")
        '        txtEquipmentRoom.Text = a1(1)
        '        On Error Resume Next
        '    Else
        '        txtEquipmentRoom.Text = ""
        '    End If

        '    If location.Contains("Shelves") Then
        '        Dim a As String = locationsplit(4)
        '        Dim a1 As String() = a.Split("-")
        '        txtEquipmentShelves.Text = a1(1)
        '        On Error Resume Next
        '    Else
        '        txtEquipmentShelves.Text = ""
        '    End If

        '    If location.Contains("Rack") Then
        '        Dim a As String = locationsplit(5)
        '        Dim a1 As String() = a.Split("-")
        '        txtEquipmentRack.Text = a1(1)
        '        On Error Resume Next
        '    Else
        '        txtEquipmentRack.Text = ""
        '    End If

        '    If location.Contains("Bin") Then
        '        Dim a As String = locationsplit(6)
        '        Dim a1 As String() = a.Split("-")
        '        txtEquipmentBin.Text = a1(1)
        '        On Error Resume Next
        '    Else
        '        txtEquipmentBin.Text = ""
        '    End If
        'Else
        '    Dim obj As New BaseClasses.Items
        '    'txtConsOthersName.text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & HDnItemNo.value, CommandType.Text)
        '    txtMROEquipmentName.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & hdnItemNo.Value, CommandType.Text)
        '    txtequipmentdesciption.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & hdnItemNo.Value, CommandType.Text)


        '    'optimize code
        '    Dim textBoxes() As TextBox = {txtequipmentpowerinput, txtequipmentdimension, txtequipmentareacapacity, txtequipmentmodel, txtequipmentwaranty, txtSpecification, txtEAcqCost, txtEMarketValue, DRP, LTD, RP, txtequipmentReOrderPt, txtUsefulLife}

        '    For Each textBox As TextBox In textBoxes
        '        textBox.Text = ""
        '    Next

        '    txtEAcqDate.Text = Date.Now.ToString("MM/dd/yyyy")

        '    'Dim DA As DateTime
        '    'DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")
        '    txtNoYears.Text = " "
        '    txtequipmentdepreciatedvalue.Text = FormatNumber(0, 2)
        '    lblequipmentdepreciatedRate.Text = " "
        '    lblequipmentdepreciatedRate.ReadOnly = False


        '    txtSalvageValue.Text = FormatNumber(0, 2)
        '    txtSalvageValue.Text = ""
        '    Session("useful_life") = 0
        '    txtEquipmentQuantity.Text = ""
        '    Dim unit As Integer = obj.GetValue("select isnull(Unit_ID,1)  From dbo.m_item where Item_ID =" & hdnItemNo.Value, CommandType.Text)
        '    drpMROEquipmentUnit.Items.FindByValue(unit).Selected = True

        '    txtMROEquipmentName.ReadOnly = False
        '    txtequipmentdesciption.ReadOnly = False
        '    txtEAcqCost.ReadOnly = False
        '    txtEquipmentQuantity.ReadOnly = False
        '    txtequipmentpowerinput.ReadOnly = False
        '    txtequipmentmodel.ReadOnly = False
        '    txtequipmentReOrderPt.ReadOnly = False

        '    txtequipmentdimension.ReadOnly = False
        '    txtequipmentareacapacity.ReadOnly = False
        '    txtequipmentwaranty.ReadOnly = False
        '    txtSpecification.ReadOnly = False
        '    txtEAcqDate.ReadOnly = False
        '    txtEMarketValue.ReadOnly = False
        '    txtSalvageValue.ReadOnly = False
        '    txtNoYears.ReadOnly = False
        '    txtequipmentdepreciatedvalue.ReadOnly = False
        '    lblequipmentdepreciatedRate.ReadOnly = False
        '    txtUsefulLife.ReadOnly = False





        '    btnEquipmentSave.Enabled = True
        '    btnEquipmentCancel.Enabled = True
        '    btnEquipmentSave.Text = "SAVE"

        '    Dim dt1 As New DataTable
        '    dt1 = objDerived.GetDataTable("select reorderPT from dbo.m_item where  Item_ID='" & hdnItemNo.Value & "'", CommandType.Text)
        '    If dt1.Rows.Count > 0 Then
        '        txtequipmentReOrderPt.Text = dt1.Rows(0).Item(0)
        '    Else
        '    End If
        'End If
        btnEquipmentSave.Enabled = True
        ledger()


    End Sub

    Public Sub SelectMROConsOthers_from_dropdown()

        Dim CY As String = "CY" & Year(txtDate.Text)

        Dim balance As Integer
        hdnGAId.Value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
        balance = objDerived.GetValue("select isnull(sum(Qty),0) from ams.Stock where Item_ID = " & hdnItemNo.Value, CommandType.Text)


        If balance <> 0 Then
            Dim dt As New DataTable

            dt = objDerived.GetDataTable("select  a.ItemDesc,a.BrandName,b.Cost,convert(int,b.Qty),a.DepreciationRate ,a.DepreciationValue,a.Form, a.Batch ,a.Lot , a.Mftgdate , a.EpiryDate, a.Alert ,isnull(b.Location,' - '),isnull(b.warehouse_id,1),b.ReorderPt,b.StockDate   From [AMS].TbNonFood as a inner join ams.Stock as b on a.StockID = b.StockID  where a.Item_ID = " & hdnItemNo.Value, CommandType.Text)


            For Each textBox In {txtConsOthersName, txtConsOthersBrandName, txtConsOthersUnitPrice, txtConsOthersQuantity, txtConsOthersDepValue, txtConsOthersDepRate, txtConsOthersForm, txtConsOthersBatch1, txtConsOthersLot, txtMDateConsOthers, txtEDateConsOthers, txtAlertConsOthers}
                textBox.ReadOnly = False
            Next

        Else
            Dim dt As New DataTable
            Dim obj As New BaseClasses.Items
            txtConsOthersName.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & hdnItemNo.Value, CommandType.Text)

            'txtCategory.ReadOnly = False
            txtConsOthersReOrderPt.Text = ""
            DRP.Text = ""
            LTD.Text = ""
            RP.Text = ""

            'OPTIMIZE CODE
            For Each textBox In {txtConsOthersName, txtConsOthersBrandName, txtConsOthersUnitPrice, txtConsOthersQuantity, txtConsOthersDepValue, txtConsOthersDepRate, txtConsOthersForm, txtConsOthersBatch1, txtConsOthersLot, txtMDateConsOthers, txtEDateConsOthers, txtAlertConsOthers}
                textBox.ReadOnly = False
            Next

            CalendarExtender4.Enabled = True
            CalendarExtender5.Enabled = True
            CalendarExtender6.Enabled = True

            ' txtComponentof.ReadOnly = False
            btnConsOthersSave.Text = "SAVE"
            btnConsOthersSave.Enabled = True
            btnCancel.Enabled = True


            'OPTIMIZE CODE
            Dim txtBoxes() As TextBox = {txtConsOthersBay, txtConsOthersColumn, txtConsOthersFloor, txtConsOthersRoom, txtConsOthersShelves, txtConsOthersRack, txtConsOthersBin}

            For Each txtBox As TextBox In txtBoxes
                txtBox.ReadOnly = False
            Next

            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("select reorderPT from dbo.m_item where  Item_ID='" & hdnItemNo.Value & "'", CommandType.Text)
            If dt1.Rows.Count > 0 Then
                txtConsOthersReOrderPt.Text = dt1.Rows(0).Item(0)
            Else
            End If
            ' txtItemDesc2.text = dt.Rows(0).Item(0)
        End If
        ledger()

    End Sub

    Protected Sub grdLedger_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(9).Text = "0" Then
                e.Row.Cells(9).Text = " "
            End If
            If e.Row.Cells(10).Text = "0.00" Then
                e.Row.Cells(10).Text = " "
            End If
            If e.Row.Cells(11).Text = "0" Then
                e.Row.Cells(11).Text = " "
            End If
            If e.Row.Cells(12).Text = "0.00" Then
                e.Row.Cells(12).Text = " "
            End If

        End If
    End Sub

    Protected Sub btnEquipmentSave_Click(sender As Object, e As EventArgs)
        If btnEquipmentSave.Text = "SAVE" Then
            saveMROEquipment()
        ElseIf btnEquipmentSave.Text = "UPDATE" Then
            UpdateEquipment()
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Ledger Card Updated Successfully")
        Else
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()

            ModalPopupExtender2.Show()

        End If

    End Sub

    Public Sub saveMROEquipment()
        Try
            ' --------------------------------------------------------------------------
            ' 1) Start of Method Tracer and Check Required Fields
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogStart", "console.log('saveMROEquipment: Method start');", True)

            ' Check if required fields are filled
            If txtMROEquipmentName.Text = "" OrElse
               txtequipmentdesciption.Text = "" OrElse
               txtEAcqCost.Text = "" OrElse
               txtEquipmentQuantity.Text = "" OrElse
               txtequipmentReOrderPt.Text = "" Then

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity / Other Specs")
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogMissingFields", "console.log('saveMROEquipment: Missing required fields.');", True)
                Return
            End If

            ' --------------------------------------------------------------------------
            ' 2) Update m_item's unit_id
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogUpdateUnit", "console.log('saveMROEquipment: Updating m_item with unit_id = " & drpMROEquipmentUnit.SelectedItem.Value & " for item_id = " & hdnItemNo.Value & "');", True)
            objDerived.Execute("Update dbo.m_item set unit_id = " & drpMROEquipmentUnit.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)

            ' --------------------------------------------------------------------------
            ' 3) Gather Classification, Category, Matrix
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogGatheringData", "console.log('saveMROEquipment: Gathering classification, category, matrix data.');", True)
            Dim classification As String = objDerived.GetValue("Select ClassificationName from dbo.tbl_Classification where ClassificationId = " & ddClass.Text, CommandType.Text)
            Dim category As Integer = objDerived.GetValue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
            Dim matrix As String = objDerived.GetValue("select id From tblclassmatrix where classificationid = " & ddClass.Text & " and ga_id = " & hdnGAId.Value & " and item_id = " & hdnItemNo.Value & "", CommandType.Text)

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogMatrixCheck", "console.log('saveMROEquipment: Matrix ID = " & matrix & "');", True)

            ' Insert into tblclassmatrix if not exists
            If matrix = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogInsertMatrix", "console.log('saveMROEquipment: Inserting into tblclassmatrix');", True)
                objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id) values('" & ddClass.Text & "','" & hdnGAId.Value & "','" & hdnItemNo.Value & "','" & category & "','0')", CommandType.Text)
            End If

            ' --------------------------------------------------------------------------
            ' 4) SAVE AMS.Tb_Receiving
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogSavingReceiving", "console.log('saveMROEquipment: Saving to AMS.Tb_Receiving');", True)
            Dim rcv As New Receiving.t_receiving
            With rcv
                .Received_Date = txtEAcqDate.Text
                .ReceivedBY = 0
                .POHdr_ID = 0
                .PO_No = ""
                .Supplier_ID = 0
                .GA_ID = hdnGAId.Value
                .isAccepted = False
                .UserID = Session("@UserName")
            End With
            Dim rcvID As Long = rcv.save()
            Session("Received_ID") = rcvID
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogReceivingSaved", "console.log('saveMROEquipment: AMS.Tb_Receiving saved with rcvID = " & rcvID & "');", True)

            ' --------------------------------------------------------------------------
            ' 5) SAVE AMS.Tb_Receiving_Dtl
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogSavingReceivingDtl", "console.log('saveMROEquipment: Saving to AMS.Tb_Receiving_Dtl');", True)
            Dim rcv_dtl As New Receiving.t_receiving_dtl
            Dim total As Decimal = 0
            Dim txtPrice As Decimal
            Dim txtqty As Integer

            ' Parse and validate Quantity and Unit Price
            If Not Decimal.TryParse(txtEAcqCost.Text, txtPrice) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Unit Price.")
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogInvalidUnitPrice", "console.log('saveMROEquipment: Invalid Unit Price.');", True)
                Return
            End If

            If Not Integer.TryParse(txtEquipmentQuantity.Text, txtqty) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Quantity.")
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogInvalidQuantity", "console.log('saveMROEquipment: Invalid Quantity.');", True)
                Return
            End If

            ' Build location string
            Dim locationBuilder As New System.Text.StringBuilder()
            If Not String.IsNullOrEmpty(txtEquipmentBay.Text) Then locationBuilder.Append("Bay-").Append(txtEquipmentBay.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtEquipmentColumn.Text) Then locationBuilder.Append("Column-").Append(txtEquipmentColumn.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtEquipmentFloor.Text) Then locationBuilder.Append("Floor-").Append(txtEquipmentFloor.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtEquipmentRoom.Text) Then locationBuilder.Append("Room-").Append(txtEquipmentRoom.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtEquipmentShelves.Text) Then locationBuilder.Append("Shelves-").Append(txtEquipmentShelves.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtEquipmentRack.Text) Then locationBuilder.Append("Rack-").Append(txtEquipmentRack.Text).Append(" ")
            If Not String.IsNullOrEmpty(txtEquipmentBin.Text) Then locationBuilder.Append("Bin-").Append(txtEquipmentBin.Text).Append(" ")

            Dim location As String = locationBuilder.ToString().Trim()

            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = hdnItemNo.Value
                .PO_Qty = txtqty
                .Qty_Received = txtqty
                .Cost = txtPrice
                .Condition = ""
                .Location = location
            End With
            Dim RcvDtl_ID As Long = rcv_dtl.save()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogReceivingDtlSaved", "console.log('saveMROEquipment: AMS.Tb_Receiving_Dtl saved with RcvDtl_ID = " & RcvDtl_ID & "');", True)

            ' Calculate total cost
            Dim t1 As Decimal = txtPrice * txtqty
            total += t1
            Session("ContractPrice") = total
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogTotalCost", "console.log('saveMROEquipment: Total Cost = " & total & "');", True)

            ' --------------------------------------------------------------------------
            ' 6) SAVE OF PURCHASE ORDER (PO_Hdr)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogSavingPOHdr", "console.log('saveMROEquipment: Preparing Purchase Order data');", True)
            Dim pohdr_id As Long
            Dim POhdr As New t_purchase_order_hdr
            Dim POnumber As String = "Starting Inventory"

            With POhdr
                .PO_No = POnumber
                .PO_Date = txtEAcqDate.Text
                .Supplier_ID = 0
                .mode_of_procurement_id = 2
                .DeliveryTerm = 0
                .paymentTerm = 0
                .DeliveryDate = txtDate.Text
                .DeliveryPlace = ""
                .isDelivered = True
                .pre_procurement_hdr_id = 0
                .withdv = False
                .isStag = False
                .isContinueCutOff = False
                .isStopForCutOff = False
                .isShoppingA = False
                .isPublicInfra = False
                .isStraight = True
                .isApproved_PO_Mayor = True
                .isReceived_PO_Mayor = True
                .DateApproved_PO_Mayor = txtDate.Text
                .DateReceived_PO_Mayor = txtDate.Text
                .DateDisApprove = "01/01/1900"
                .isGasoline = False
                .isReimbursement = False
            End With

            ' Check if PO already exists
            Dim po_id As New DataTable
            po_id = objDerived.GetDataTable("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
            If po_id.Rows.Count = 0 Then
                ' No existing PO => Insert
                POhdr.ContractPrice = CType(Session("ContractPrice"), Decimal)
                pohdr_id = POhdr.save()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogNewPO", "console.log('saveMROEquipment: New PO_Hdr created with pohdr_id = " & pohdr_id & "');", True)
            Else
                ' Existing PO => Update total
                Dim poid As Integer = objDerived.GetValue("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
                Dim TAmount As Decimal = objDerived.GetValue("Select ContractPrice from ams.po_hdr where pohdr_id = '" & poid & "'", CommandType.Text)

                POhdr.ContractPrice = CType(TAmount + CType(Session("ContractPrice"), Decimal), Decimal)
                POhdr.POHdr_ID = poid
                pohdr_id = POhdr.update()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogUpdatePO", "console.log('saveMROEquipment: Existing PO_Hdr updated with pohdr_id = " & pohdr_id & "');", True)
            End If

            ' Update PO_Hdr with GA_ID and ProjectName
            objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = '" & hdnGAId.Value & "', ProjectName = 'Manual Encode' WHERE POHdr_ID = '" & pohdr_id & "'", CommandType.Text)
            Session("POHdr_ID") = pohdr_id
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogPOHdrUpdated", "console.log('saveMROEquipment: PO_Hdr updated with GA_ID and ProjectName for pohdr_id = " & pohdr_id & "');", True)

            ' --------------------------------------------------------------------------
            ' 7) SAVE OF INSPECTION & ACCEPTANCE (AIR_Hdr)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogSavingAIRHdr", "console.log('saveMROEquipment: Generating and saving AIR_Hdr');", True)
            Dim objhdr As New t_inspection_and_acceptance_hdr
            Dim airhdr_id As Long
            Dim air As String = objDerived.GetValue("select [AMS].[func_GenerateAIR]('" & txtDate.Text & "')", CommandType.Text)

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
                .RC_ID = 0
                .Function_ID = 0
            End With
            airhdr_id = objhdr.save()
            Session("AIRHDR_ID") = airhdr_id
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogAIRHdrSaved", "console.log('saveMROEquipment: AIR_Hdr saved with airhdr_id = " & airhdr_id & "');", True)

            ' Update AIR_Hdr with UserID and Received_ID
            objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET UserID = '" & Session("@UserName") & "', Received_ID = '" & Session("Received_ID") & "' WHERE AIRHdr_ID = '" & Session("AIRHDR_ID") & "'", CommandType.Text)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogAIRHdrUpdated", "console.log('saveMROEquipment: AIR_Hdr updated with UserID and Received_ID for airhdr_id = " & airhdr_id & "');", True)

            ' --------------------------------------------------------------------------
            ' 8) PO Details Save (t_purchase_order_dtl)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogSavingPOdtl", "console.log('saveMROEquipment: Saving to t_purchase_order_dtl');", True)
            Dim POdtl As New t_purchase_order_dtl
            Dim txtPricePO As Decimal
            Dim txtqtyPO As Integer

            ' Parse and validate PO Quantity and Cost
            If Not Decimal.TryParse(txtEAcqCost.Text, txtPricePO) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Unit Price for PO Details.")
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogInvalidPOUnitPrice", "console.log('saveMROEquipment: Invalid Unit Price for PO Details.');", True)
                Return
            End If

            If Not Integer.TryParse(txtEquipmentQuantity.Text, txtqtyPO) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Quantity for PO Details.")
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogInvalidPOQuantity", "console.log('saveMROEquipment: Invalid Quantity for PO Details.');", True)
                Return
            End If

            With POdtl
                .POHdr_ID = pohdr_id
                .Item_ID = hdnItemNo.Value
                .cost = txtPricePO
                .qty = txtqtyPO
                .remarks = "Manual Encode"
            End With
            POdtl.save()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogPOdtlSaved", "console.log('saveMROEquipment: t_purchase_order_dtl saved for POHdr_ID = " & pohdr_id & "');", True)

            ' --------------------------------------------------------------------------
            ' 9) AIR Details (t_inspection_and_acceptance_dtl)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogSavingAIRDtl", "console.log('saveMROEquipment: Saving to t_inspection_and_acceptance_dtl');", True)
            Dim objdtl As New t_inspection_and_acceptance_dtl
            Dim txtPriceair As Decimal
            Dim txtqtyair As Integer

            ' Parse and validate AIR Quantity and Cost
            If Not Decimal.TryParse(txtEAcqCost.Text, txtPriceair) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Unit Price for AIR Details.")
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogInvalidAIRUnitPrice", "console.log('saveMROEquipment: Invalid Unit Price for AIR Details.');", True)
                Return
            End If

            If Not Integer.TryParse(txtEquipmentQuantity.Text, txtqtyair) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Quantity for AIR Details.")
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogInvalidAIRQuantity", "console.log('saveMROEquipment: Invalid Quantity for AIR Details.');", True)
                Return
            End If

            With objdtl
                .Item_ID = hdnItemNo.Value
                .Qty = txtqtyair
                .Cost = txtPriceair
                .AIRHdr_ID = airhdr_id
                .GA_ID = hdnGAId.Value
            End With
            Dim iaDtl_ID As Integer = objdtl.save()
            Session("AIRDtl_ID") = iaDtl_ID
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogAIRDtlSaved", "console.log('saveMROEquipment: t_inspection_and_acceptance_dtl saved with iaDtl_ID = " & iaDtl_ID & "');", True)

            ' --------------------------------------------------------------------------
            ' 10) SAVE STOCK (AMS.Stock)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogSavingStock", "console.log('saveMROEquipment: Saving to AMS.Stock');", True)

            ' Parse Warehouse safely
            Dim whVal As String = drpMROConsOthersWarehouse.SelectedValue
            If String.IsNullOrEmpty(whVal) OrElse Not IsNumeric(whVal) Then
                whVal = "0"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogInvalidWarehouse", "console.log('saveMROEquipment: Invalid Warehouse ID. Defaulting to 0.');", True)
            End If

            ' Parse RC_ID
            Dim rcValString As String = objDerived.GetValue("SELECT DISTINCT [RC_id] FROM [dbo].[View_RespCenter_withFunctions] WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'", CommandType.Text)
            Dim rcParsed As Integer = 0
            If Not String.IsNullOrEmpty(rcValString) AndAlso IsNumeric(rcValString) Then
                rcParsed = Convert.ToInt32(rcValString)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogRCParsed", "console.log('saveMROEquipment: RC_ID parsed as " & rcParsed & "');", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogRCDefault", "console.log('saveMROEquipment: RC_ID defaulted to 0.');", True)
            End If

            ' Parse ReorderPt
            Dim reorderVal As Integer = 0
            If Not String.IsNullOrEmpty(txtequipmentReOrderPt.Text) AndAlso IsNumeric(txtequipmentReOrderPt.Text) Then
                reorderVal = Convert.ToInt32(txtequipmentReOrderPt.Text)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogReorderParsed", "console.log('saveMROEquipment: ReorderPt parsed as " & reorderVal & "');", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogReorderDefault", "console.log('saveMROEquipment: ReorderPt defaulted to 0.');", True)
            End If

            ' Build location string again for stock
            Dim locationBuilderStock As New System.Text.StringBuilder()
            If Not String.IsNullOrEmpty(txtEquipmentBay.Text) Then
                locationBuilderStock.Append("Bay-").Append(txtEquipmentBay.Text).Append(" ")
            End If
            If Not String.IsNullOrEmpty(txtEquipmentColumn.Text) Then
                locationBuilderStock.Append("Column-").Append(txtEquipmentColumn.Text).Append(" ")
            End If
            If Not String.IsNullOrEmpty(txtEquipmentFloor.Text) Then
                locationBuilderStock.Append("Floor-").Append(txtEquipmentFloor.Text).Append(" ")
            End If
            If Not String.IsNullOrEmpty(txtEquipmentRoom.Text) Then
                locationBuilderStock.Append("Room-").Append(txtEquipmentRoom.Text).Append(" ")
            End If
            If Not String.IsNullOrEmpty(txtEquipmentShelves.Text) Then
                locationBuilderStock.Append("Shelves-").Append(txtEquipmentShelves.Text).Append(" ")
            End If
            If Not String.IsNullOrEmpty(txtEquipmentRack.Text) Then
                locationBuilderStock.Append("Rack-").Append(txtEquipmentRack.Text).Append(" ")
            End If
            If Not String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                locationBuilderStock.Append("Bin-").Append(txtEquipmentBin.Text).Append(" ")
            End If

            Dim locationStock As String = locationBuilderStock.ToString().Trim()

            Dim objStock As New Supplies_Stock
            With objStock
                .StockDate = DateTime.Parse(txtDate.Text)
                .Item_ID = hdnItemNo.Value
                .Qty = txtqtyair
                .Balance = txtqtyair
                .Location = locationStock
                .Expiration_Date = #1/1/1900#
                .Cost = txtPriceair
                .Issuance = 0
                .RC_ID = rcParsed
                .Function_ID = 0
                .Project_ID = 0
                .Program_id = 0
                .F_ID = 4
                .AIRDtl_ID = Session("AIRDtl_ID")
                .GA_ID = hdnGAId.Value
                .Warehouseid = Convert.ToInt32(whVal)
                .ReorderPt = reorderVal
            End With
            Dim StockID As Long = objStock.save()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogStockSaved", "console.log('saveMROEquipment: AMS.Stock saved with StockID = " & StockID & "');", True)

            ' Update AMS.Stock with Received_ID
            objDerived.GetRecords("UPDATE AMS.Stock SET Received_ID = '" & rcvID & "' WHERE StockID = '" & StockID & "'", CommandType.Text)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogStockUpdated", "console.log('saveMROEquipment: AMS.Stock updated with Received_ID = " & rcvID & " for StockID = " & StockID & "');", True)

            ' --------------------------------------------------------------------------
            ' 11) SAVE LEDGER (AMS.TbStock_Ledger)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogSavingLedger", "console.log('saveMROEquipment: Saving to AMS.TbStock_Ledger');", True)
            Dim objStockLedger As New t_StockLedger
            With objStockLedger
                .StockID = StockID
                .Trans_Type = "Starting Balance"
                .Ref = air
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .ReceivedBy = ""
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"

                If lblClass.Text = "MRO Equipment" Then
                    .dDate = DateTime.Parse(txtEAcqDate.Text)
                ElseIf lblClass.Text = "MRO Supplies" Then
                    .dDate = DateTime.Parse(txtSellectDate.Text)
                ElseIf lblClass.Text = "MRO Consumables" Then
                    .dDate = DateTime.Parse(txtSellectDateCons.Text)
                End If

                .Item_ID = hdnItemNo.Value
                .DebitQty = txtqtyair
                .DebitCost = FormatNumber(txtPriceair * txtqtyair, 2)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceQty = 0
                .BalanceCost = 0
                .save()
            End With
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogLedgerSaved", "console.log('saveMROEquipment: AMS.TbStock_Ledger saved for StockID = " & StockID & "');", True)

            ' --------------------------------------------------------------------------
            ' 12) SAVE TbNonFood (Specific for Non-Food Items)
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogSavingTbNonFood", "console.log('saveMROEquipment: Saving TbNonFood record');", True)
            Dim objNonFood As New ConsolidatedMedicineSaving.TbNonFood
            With objNonFood
                .StockId = StockID
                .AIRDtl_ID = Session("AIRDtl_ID")
                .Item_ID = hdnItemNo.Value
                .ActualPrice = txtEAcqCost.Text
                .ItemDesc = txtequipmentdesciption.Text
                .BrandName = ""
                .Supplier_Id = 0
                .Form = ""
                .OTCRx = ""
                .Batch = ""
                .Lot = ""
                .Storage = ""
                .Status = "Accepted"
                .DeliveryDate = DateTime.Parse(txtEAcqDate.Text)
                .Mftgdate = #1/1/1900#
                .EpiryDate = #1/1/1900#
                .Alert = #1/1/1900#
                .Depreciationrate = lblequipmentdepreciatedRate.Text
                .Depreciationvalue = 0.0
            End With
            Dim NonFoodID As Long = objNonFood.save()
            objDerived.GetRecords("UPDATE AMS.TbNonFood SET Received_ID = '" & rcvID & "' WHERE NonFood_ID = '" & NonFoodID & "'", CommandType.Text)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogTbNonFoodSaved", "console.log('saveMROEquipment: TbNonFood saved with NonFood_ID = " & NonFoodID & "');", True)

            ' Update TbNonFood with Equipment-specific fields
            ' --------------------------------------------------------------------------
            ' * Modify this section to escape single quotes in text fields
            ' --------------------------------------------------------------------------
            ' --------------------------------------------------------------------------
            ' Update TbNonFood with Equipment-specific fields
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogUpdatingTbNonFood", "console.log('saveMROEquipment: Updating TbNonFood with equipment-specific fields');", True)

            ' Escape single quotes in text fields
            Dim escapedDimension As String = txtequipmentdimension.Text.Replace("'", "''")
            Dim escapedPowerInput As String = txtequipmentpowerinput.Text.Replace("'", "''")
            Dim escapedModel As String = txtequipmentmodel.Text.Replace("'", "''")
            Dim escapedWarranty As String = txtequipmentwaranty.Text.Replace("'", "''")
            Dim escapedSpecs As String = txtSpecification.Text.Replace("'", "''")

            ' Parse and validate numeric fields
            Dim marketValueDecimal As Decimal = 0
            If Not Decimal.TryParse(txtEMarketValue.Text.Replace(",", ""), marketValueDecimal) Then
                marketValueDecimal = 0
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogInvalidMarketValue", "console.log('saveMROEquipment: Invalid MarketValue. Defaulting to 0.');", True)
            End If

            Dim salvageValueDecimal As Decimal = 0
            If Not Decimal.TryParse(txtSalvageValue.Text.Replace(",", ""), salvageValueDecimal) Then
                salvageValueDecimal = 0
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogInvalidSalvageValue", "console.log('saveMROEquipment: Invalid SalvageValue. Defaulting to 0.');", True)
            End If

            ' Optionally, validate other numeric fields like NoYears and UsefulLife
            Dim noYears As String = txtNoYears.Text
            Dim usefulLife As String = txtUsefulLife.Text



            ' Construct the SQL statement with escaped and validated values
            Dim updateTbNonFoodSQL As String = "UPDATE AMS.TbNonFood SET " &
            "Dimension='" & escapedDimension & "', " &
            "PowerInput='" & escapedPowerInput & "', " &
            "Model='" & escapedModel & "', " &
            "Warranty='" & escapedWarranty & "', " &
            "MarketValue=" & marketValueDecimal.ToString() & ", " &
            "NoYears='" & noYears & "', " &
            "UsefulLife='" & usefulLife & "', " &
            "SalvageValue=" & salvageValueDecimal.ToString() & ", " &
            "Specs='" & escapedSpecs & "' " &
            "WHERE NonFood_ID=" & Val(NonFoodID)

            ' Optional: Log the final SQL statement for debugging
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogUpdateTbNonFoodSQL", "console.log('saveMROEquipment: UPDATE AMS.TbNonFood SQL: " & updateTbNonFoodSQL.Replace("'", "\'") & "');", True)

            ' Execute the updated SQL statement
            objDerived.GetRecords(updateTbNonFoodSQL, CommandType.Text)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogTbNonFoodUpdated", "console.log('saveMROEquipment: TbNonFood updated with NonFood_ID = " & NonFoodID & "');", True)

            ' --------------------------------------------------------------------------
            ' 13) Refresh the ledger grid
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogRefreshingLedgerGrid", "console.log('saveMROEquipment: Refreshing ledger grid');", True)
            Dim dtStock As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
            If dtStock.Rows.Count < 4 Then
                dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
            End If

            grdLedger.DataSource = dtStock
            grdLedger.DataBind()
            ledger()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogLedgerGridRefreshed", "console.log('saveMROEquipment: Ledger grid refreshed');", True)

            ' --------------------------------------------------------------------------
            ' 14) Final UI updates
            ' --------------------------------------------------------------------------
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogTransactionSuccess", "console.log('saveMROEquipment: Transaction successfully saved');", True)

            ' Check reorder point
            Dim ropVal As String = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer
            If Integer.TryParse(txtEquipmentQuantity.Text, c) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogROPCheck", "console.log('saveMROEquipment: Checking Reorder Point. ROP = " & ropVal & ", Quantity = " & c & "');", True)
                If Not String.IsNullOrEmpty(ropVal) AndAlso IsNumeric(ropVal) Then
                    If Convert.ToInt32(ropVal) >= c Then
                        ModalPopupExtender3.Show()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogROPTriggered", "console.log('saveMROEquipment: Reorder Point reached. Showing ModalPopupExtender3.');", True)
                    End If
                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogInvalidQuantityForROP", "console.log('saveMROEquipment: Invalid Quantity for Reorder Point check.');", True)
            End If

            ' Reload stock and equipment descriptions
            loadStockOfficeSupplies()
            selectitemdescMROEquipment()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogFinalUIUpdates", "console.log('saveMROEquipment: Final UI updates completed');", True)

            ' --------------------------------------------------------------------------
            ' End of method tracer
            ' --------------------------------------------------------------------------
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogEnd", "console.log('saveMROEquipment: Method end');", True)

        Catch ex As Exception
            ' --------------------------------------------------------------------------
            ' Enhanced exception handling
            ' --------------------------------------------------------------------------
            Dim safeMessage As String = ex.Message.Replace("'", "\'").Replace(vbCrLf, " ").Replace(vbLf, " ")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLogError", "console.error('Exception in saveMROEquipment: " & safeMessage & "');", True)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error: " & ex.Message)
        End Try
    End Sub


    Protected Sub btnROP_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub BtnCompute_Click(sender As Object, e As EventArgs)
        Try
            RP.Text = DRP.Text * LTD.Text
            ModalPopupExtender1.Show()
            txtConsOthersReOrderPt.Text = DRP.Text * LTD.Text
            txtReOrderPt.Text = DRP.Text * LTD.Text
            txtequipmentReOrderPt.Text = DRP.Text * LTD.Text
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill Demand Per Day & Lead Time For Deliver.")

        End Try
    End Sub

    Protected Sub txtConsOthersQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtConsOthersQuantity.TextChanged

    End Sub



    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)


        '=================== FOR MRO SUPPLY SUBMODULE ENCODING=================
        Dim dt As DataTable
        If drpItemDesc2.SelectedItem IsNot Nothing AndAlso drpItemDesc2.SelectedItem.Value <> "0" Then

            'FOR UNCHECKING FIRE EVENT

            txtBrandName2.Text = String.Empty
            txtSize.Text = String.Empty
            txtUnitPrice.Text = String.Empty
            txtSellectDate.Text = String.Empty
            drpUnit.SelectedItem.Text = String.Empty
            txtQuantity.Text = String.Empty
            txtSize.Text = String.Empty
            txtBrandName2.Text = String.Empty
            txtColor.Text = String.Empty
            txtLenght.Text = String.Empty
            txtWidth.Text = String.Empty
            txtHeight.Text = String.Empty
            txtReOrderPt.Text = String.Empty


            Dim textboxes() As TextBox = {txtColor, txtSize, txtDepRate, txtBrandName2, txtItemDesc2, txtLenght,
                              txtWidth, txtHeight, txtWeight, txtDepValue, txtUnitPrice, txtQuantity,
                              txtComponentof, txtBay, txtColumn, txtFloor, txtRoom, txtShelves,
                              txtRack, txtBin}

            For Each textbox As TextBox In textboxes
                textbox.ReadOnly = False
            Next


            dt = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpItemDesc2.SelectedItem.Value & "'", CommandType.Text)


            Dim cb1 As CheckBox
            Dim x As Integer = 0

            For i As Integer = 0 To grdLedger.Rows.Count - 1
                cb1 = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then
                    x = 1

                    btnSave.Enabled = True
                    btnSave.Text = "EDIT"
                End If
            Next

            If x = 0 Then
                btnSave.Enabled = True
                btnSave.Text = "SAVE"
            End If


            If dt.Rows.Count > 0 Then

                For xa As Integer = 0 To grdLedger.Rows.Count - 1
                    cb1 = CType(Me.grdLedger.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)

                    If cb1.Visible AndAlso cb1.Checked Then
                        If dt.Rows.Count > 0 Then
                            txtUnitPrice.Text = dt.Rows(xa).Item("cost").ToString()
                            txtSellectDate.Text = dt.Rows(xa).Item("dDate").ToString()

                            'SOME UNIT FROM STOCK TABLE FOR SOME REASON DONT EXIST IN LIST OF DROPDOWN UNIT
                            Dim unitValue As String = dt.Rows(xa).Item("DebitUnit").ToString()
                            drpUnit.SelectedItem.Text = unitValue

                            txtQuantity.Text = dt.Rows(xa).Item("DebitQty").ToString()

                            Dim dt2 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TBSupplies_Info AS a WHERE  (ItemId = '" & drpItemDesc2.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                            If dt2.Rows.Count > 0 Then
                                txtSize.Text = dt2.Rows(0).Item("Size").ToString()
                                txtBrandName2.Text = dt2.Rows(0).Item("BrandName").ToString()
                                txtColor.Text = dt2.Rows(0).Item("Color").ToString()
                                txtLenght.Text = dt2.Rows(0).Item("Length").ToString()
                                txtWidth.Text = dt2.Rows(0).Item("Width").ToString()
                                txtHeight.Text = dt2.Rows(0).Item("Height").ToString()
                            End If

                            Dim dt3 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.Stock AS a WHERE  (Item_ID = '" & drpItemDesc2.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)
                            If dt3.Rows.Count > 0 Then
                                txtReOrderPt.Text = dt3.Rows(0).Item("ReorderPt").ToString()
                            End If

                        End If
                    End If
                Next
            End If
        End If


        '=================== FOR MRO CONSUMABLES SUBMODULE ENCODING=================
        If drpConsOthersName.SelectedItem IsNot Nothing AndAlso drpConsOthersName.SelectedItem.Value <> "0" Then
            dt = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpConsOthersName.SelectedItem.Value & "'", CommandType.Text)

            txtBrandName2.Text = String.Empty
            txtConsOthersUnitPrice.Text = String.Empty
            txtSellectDateCons.Text = String.Empty
            drpConsOthersUnit.SelectedItem.Text = String.Empty
            txtConsOthersQuantity.Text = String.Empty
            txtConsOthersDose.Text = String.Empty
            txtConsOthersBrandName.Text = String.Empty
            txtEDateConsOthers.Text = String.Empty
            txtAlertConsOthers.Text = String.Empty
            txtConsOthersReOrderPt.Text = String.Empty


            For Each textBox In {txtConsOthersName, txtConsOthersBrandName, txtConsOthersUnitPrice, txtConsOthersQuantity, txtConsOthersDepValue, txtConsOthersDepRate, txtConsOthersForm, txtConsOthersBatch1, txtConsOthersLot, txtMDateConsOthers, txtEDateConsOthers, txtAlertConsOthers}
                textBox.ReadOnly = False
            Next

            Dim cb1 As CheckBox
            Dim x As Integer = 0

            For i As Integer = 0 To grdLedger.Rows.Count - 1
                cb1 = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then
                    x = 1

                    btnConsOthersSave.Enabled = True
                    btnConsOthersSave.Text = "EDIT"
                End If
            Next

            If x = 0 Then
                btnConsOthersSave.Enabled = True
                btnConsOthersSave.Text = "SAVE"
            End If


            If dt.Rows.Count > 0 Then

                For xa As Integer = 0 To grdLedger.Rows.Count - 1
                    cb1 = CType(Me.grdLedger.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)

                    If cb1.Visible AndAlso cb1.Checked Then
                        If dt.Rows.Count > 0 Then
                            txtConsOthersUnitPrice.Text = dt.Rows(xa).Item("cost").ToString()
                            txtSellectDateCons.Text = dt.Rows(xa).Item("dDate").ToString()

                            'SOME UNIT FROM STOCK TABLE FOR SOME REASON DONT EXIST IN LIST OF DROPDOWN UNIT
                            Dim unitValue As String = dt.Rows(xa).Item("DebitUnit").ToString()
                            drpConsOthersUnit.SelectedItem.Text = unitValue
                            txtConsOthersQuantity.Text = dt.Rows(xa).Item("DebitQty").ToString()

                            Dim dt2 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TBSupplies_Info AS a WHERE  (ItemId = '" & drpConsOthersName.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                            If dt2.Rows.Count > 0 Then
                                txtConsOthersDose.Text = dt2.Rows(0).Item("Dose").ToString()
                                txtConsOthersBrandName.Text = dt2.Rows(0).Item("BrandName").ToString()
                            End If

                            Dim dt3 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.Stock AS a WHERE  (Item_ID = '" & drpConsOthersName.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)
                            If dt3.Rows.Count > 0 Then
                                txtEDateConsOthers.Text = dt3.Rows(0).Item("Expiration_Date").ToString()
                                txtAlertConsOthers.Text = dt3.Rows(0).Item("Expiration_Date").ToString()
                                txtConsOthersBatch1.Text = dt3.Rows(0).Item("Batch").ToString()
                                txtConsOthersReOrderPt.Text = dt3.Rows(0).Item("ReorderPt").ToString()

                            End If

                        End If
                    End If
                Next
            End If
        End If

        '================================FOR MRO EQUIPEMENT SUBMODULE==============================
        If drpMROEquipmentName.SelectedItem IsNot Nothing AndAlso drpMROEquipmentName.SelectedItem.Value <> "0" Then
            dt = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpMROEquipmentName.SelectedItem.Value & "'", CommandType.Text)

            txtequipmentpowerinput.Text = String.Empty
            txtequipmentmodel.Text = String.Empty
            'drpMROEquipmentUnit.Text = String.Empty
            txtequipmentdimension.Text = String.Empty
            txtequipmentareacapacity.Text = String.Empty
            txtequipmentwaranty.Text = String.Empty
            txtequipmentReOrderPt.Text = String.Empty
            txtEAcqDate.Text = String.Empty
            txtEAcqCost.Text = String.Empty
            lblequipmentdepreciatedRate.Text = String.Empty
            txtequipmentdesciption.Text = String.Empty
            txtequipmentdepreciatedvalue.Text = String.Empty
            txtDepreciationValue.Text = String.Empty
            txtEMarketValue.Text = String.Empty
            txtNoYears.Text = String.Empty
            txtUsefulLife.Text = String.Empty
            txtSalvageValue.Text = String.Empty
            txtEquipmentQuantity.Text = String.Empty

            Dim textBoxes() As TextBox = {txtequipmentpowerinput, txtequipmentdimension, txtequipmentareacapacity, txtequipmentmodel, txtequipmentwaranty, txtSpecification, txtEAcqCost, txtEMarketValue, DRP, LTD, RP, txtequipmentReOrderPt, txtUsefulLife}

            For Each textBox As TextBox In textBoxes
                textBox.ReadOnly = False
            Next

            Dim cb1 As CheckBox
            Dim x As Integer = 0

            For i As Integer = 0 To grdLedger.Rows.Count - 1
                cb1 = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then
                    x = 1

                    btnEquipmentSave.Enabled = True
                    btnEquipmentSave.Text = "EDIT"
                End If
            Next


            If x = 0 Then
                btnEquipmentSave.Enabled = True
                btnEquipmentSave.Text = "SAVE"
            End If

            If dt.Rows.Count > 0 Then

                For xa As Integer = 0 To grdLedger.Rows.Count - 1
                    cb1 = CType(Me.grdLedger.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)

                    If cb1.Visible AndAlso cb1.Checked Then
                        If dt.Rows.Count > 0 Then
                            txtEAcqCost.Text = dt.Rows(xa).Item("cost").ToString()
                            txtEAcqDate.Text = dt.Rows(xa).Item("dDate").ToString()

                            'SOME UNIT FROM STOCK TABLE FOR SOME REASON DONT EXIST IN LIST OF DROPDOWN UNIT
                            Dim unitValue As String = dt.Rows(xa).Item("DebitUnit").ToString()
                            drpMROEquipmentUnit.SelectedItem.Text = unitValue
                            txtEquipmentQuantity.Text = dt.Rows(xa).Item("DebitQty").ToString()

                            Dim dt2 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TbNonFood AS a WHERE  (Item_ID = '" & drpMROEquipmentName.SelectedItem.Value & "')  AND (StockId = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                            If dt2.Rows.Count > 0 Then
                                txtSalvageValue.Text = dt2.Rows(xa).Item("SalvageValue").ToString()
                                txtUsefulLife.Text = dt2.Rows(xa).Item("UsefulLife").ToString()
                                txtNoYears.Text = dt2.Rows(xa).Item("NoYears").ToString()
                                txtEMarketValue.Text = dt2.Rows(xa).Item("MarketValue").ToString()
                                txtequipmentwaranty.Text = dt2.Rows(xa).Item("Warranty").ToString()
                                txtequipmentareacapacity.Text = dt2.Rows(xa).Item("AreaCapacity").ToString()
                                txtequipmentmodel.Text = dt2.Rows(xa).Item("Model").ToString()
                                txtequipmentpowerinput.Text = dt2.Rows(xa).Item("PowerInput").ToString()
                                txtequipmentdimension.Text = dt2.Rows(xa).Item("Dimension").ToString()
                                txtequipmentdepreciatedvalue.Text = dt2.Rows(xa).Item("DepreciationValue").ToString()
                                lblequipmentdepreciatedRate.Text = dt2.Rows(xa).Item("DepreciationRate").ToString()
                                txtSpecification.Text = dt2.Rows(xa).Item("Specs").ToString()
                                txtequipmentdesciption.Text = dt2.Rows(xa).Item("ItemDesc").ToString()
                                'TODO deprevation value per year calculation herem and the description
                            End If

                            Dim dt3 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.Stock AS a WHERE  (Item_ID = '" & drpMROEquipmentName.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)
                            If dt3.Rows.Count > 0 Then
                                txtequipmentReOrderPt.Text = dt3.Rows(0).Item("ReorderPt").ToString()

                            End If

                        End If
                    End If
                Next
            End If

        End If


    End Sub
    Protected Sub grdLedger_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles grdLedger.RowCreated

        If grdLedger.HeaderRow IsNot Nothing AndAlso grdLedger.Rows.Count > 0 Then
            If grdLedger.Controls.Count > 0 AndAlso grdLedger.Controls(0).Controls.Count > 0 Then
                ' Prevent duplicate custom header rows
                Dim headerAlreadyExists As Boolean = False
                For Each row As GridViewRow In grdLedger.Controls(0).Controls
                    If row.RowType = DataControlRowType.Header AndAlso row.Cells(0).Text = "DETAILS" Then
                        headerAlreadyExists = True
                        Exit For
                    End If
                Next

                If Not headerAlreadyExists Then
                    Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)

                    Dim cell As New TableHeaderCell()
                    cell.Text = "DETAILS"
                    cell.ColumnSpan = 4
                    row.Cells.Add(cell)

                    cell = New TableHeaderCell()
                    cell.Text = "DEBIT"
                    cell.ColumnSpan = 2
                    row.Cells.Add(cell)

                    cell = New TableHeaderCell()
                    cell.Text = "CREDIT"
                    cell.ColumnSpan = 2
                    row.Cells.Add(cell)

                    cell = New TableHeaderCell()
                    cell.Text = "BALANCE"
                    cell.ColumnSpan = 2
                    row.Cells.Add(cell)

                    row.BackColor = Color.White
                    row.ForeColor = Color.Black

                    grdLedger.Controls(0).Controls.AddAt(0, row)
                End If
            End If
        End If

    End Sub
End Class
