
Imports System.Data
Imports System.Drawing

Partial Class Records_t_StockCard_v2_MRO
    Inherits System.Web.UI.Page

    Dim objDerived As New DerivedDal
    Dim objx As New AccessRule
    Private ppq As New Price_per_qty
    Private Property PListofGL() As DataTable
        Get
            Return CType(Session("PListofGL"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PListofGL") = value
        End Set
    End Property

    Private Property pPricePerQty(ByVal PPQ_ID As String) As DataTable
        Get
            Return CType(Session(PPQ_ID), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session(PPQ_ID) = value
        End Set
    End Property
    Private Property pTempPPQ() As DataTable
        Get
            Return CType(Session("pTempPPQ"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pTempPPQ") = value
        End Set
    End Property
    Private Property pPPQ() As DataTable
        Get
            Return CType(Session("pPPQ"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPPQ") = value
        End Set
    End Property

    Private Property DrpSubClassF() As DataTable
        Get
            Return CType(Session("DrpSubClassF"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("DrpSubClassF") = value
        End Set
    End Property

    Private Function BuildLocation() As String
        Dim sb As New System.Text.StringBuilder()

        If Not String.IsNullOrWhiteSpace(txtMedicineBay.Text) Then
            sb.Append("Bay-" & txtMedicineBay.Text & " ")
        End If

        If Not String.IsNullOrWhiteSpace(txtMedicineColumn.Text) Then
            sb.Append("Column-" & txtMedicineColumn.Text & " ")
        End If

        If Not String.IsNullOrWhiteSpace(txtMedicineFloor.Text) Then
            sb.Append("Floor-" & txtMedicineFloor.Text & " ")
        End If

        If Not String.IsNullOrWhiteSpace(txtMedicineRoom.Text) Then
            sb.Append("Room-" & txtMedicineRoom.Text & " ")
        End If

        If Not String.IsNullOrWhiteSpace(txtMedicineShelves.Text) Then
            sb.Append("Shelves-" & txtMedicineShelves.Text & " ")
        End If

        If Not String.IsNullOrWhiteSpace(txtMedicineRack.Text) Then
            sb.Append("Rack-" & txtMedicineRack.Text & " ")
        End If

        If Not String.IsNullOrWhiteSpace(txtMedicineBin.Text) Then
            sb.Append("Bin-" & txtMedicineBin.Text & " ")
        End If

        ' Trim the trailing space and return
        Return sb.ToString().Trim()


    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' MsgBox(port)
        objx.GetAccessRight(Me.Session("@UserName"), Page)
        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            txtDate.Text = Date.Now.ToString("MM-dd-yyyy")

            ' Load classifications and related dropdowns
            Dim dtClassification As New DataTable
            dtClassification = objDerived.GetDataTable("select [ClassificationId],[ClassificationName] From [dbo].[tbl_Classification] where [ClassificationName] like '%Medicine%'", CommandType.Text)
            Me.ddClass.DataSource = CType(dtClassification, DataTable)
            Me.ddClass.DataTextField = ("ClassificationName")
            Me.ddClass.DataValueField = ("ClassificationId")
            Me.ddClass.DataBind()
            selectClassification()

            Session("PriceperQuantity") = 1

            ' Populate drpGenericName before loading PPQ
            loadGenericnames()

            loadPPQ()


        End If


    End Sub

    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpUnit.DataSource = dt
        drpUnit.DataTextField = ("Description")
        drpUnit.DataValueField = ("Unit_ID")
        drpUnit.DataBind()


    End Sub

    Public Sub loadpriceperquantitytable(ByVal totaltxt As Integer)

        Dim col1 As Double = Math.Ceiling((totaltxt / 2))
        Dim col2 As Integer = totaltxt - col1

        Dim ctr As Integer = 1
        For i As Integer = 1 To col1
            Dim tr As TableRow = New TableRow()

            Dim td1 As TableCell = New TableCell()
            Dim td2 As TableCell = New TableCell()
            Dim td3 As TableCell = New TableCell()
            If i = 0 Then

                tr.Cells.Add(td1)
                tr.Cells.Add(td2)
                Dim _txt1 As Label = New Label()

                _txt1.ID = "txtprice_" + i.ToString
                _txt1.Text = "Selling Price:"
                _txt1.Width = 100
                _txt1.CssClass = "column_RightBold"

                tr.Cells.Add(td3)
                td3.Controls.Add(_txt1)

                tr.Cells.Add(td3)
            Else
                Dim _lbl As Label = New Label()
                _lbl.Text = "Qty/Pack :"
                _lbl.Width = 100
                _lbl.CssClass = "column_RightBold"

                Dim _txt As TextBox = New TextBox()
                _txt.ID = "txtquantity_" + i.ToString
                _txt.Width = 100

                td1.Controls.Add(_lbl)
                td2.Controls.Add(_txt)

                Dim _txt1 As TextBox = New TextBox()
                _txt1.ID = "txtprice_" + i.ToString
                _txt1.Width = 100
                tr.Cells.Add(td3)
                td3.Controls.Add(_txt1)
                tr.Cells.Add(td1)
                tr.Cells.Add(td2)
                tr.Cells.Add(td3)
            End If


            If ctr <= col2 Then
                Dim td4 As TableCell = New TableCell()
                Dim td5 As TableCell = New TableCell()
                Dim td6 As TableCell = New TableCell()

                If i = 0 Then
                    tr.Cells.Add(td4)
                    tr.Cells.Add(td5)
                    Dim _txt1 As Label = New Label()

                    _txt1.ID = "txtprice1_" + i.ToString
                    _txt1.Text = "Selling Price :"
                    _txt1.Width = 100
                    _txt1.CssClass = "column_RightBold"

                    td6.Controls.Add(_txt1)
                    tr.Cells.Add(td6)
                Else
                    Dim _lbl1 As Label = New Label()
                    _lbl1.Text = "Qty/Pack:"
                    _lbl1.CssClass = "column_RightBold"

                    Dim _txt2 As TextBox = New TextBox()
                    _txt2.ID = "txtquantity1_" + i.ToString
                    _txt2.Width = 100

                    Dim _txt3 As TextBox = New TextBox()
                    _txt3.ID = "txtprice1_" + i.ToString
                    _txt3.Width = 100

                    td4.Controls.Add(_lbl1)
                    td5.Controls.Add(_txt2)
                    td6.Controls.Add(_txt3)


                    tr.Cells.Add(td4)
                    tr.Cells.Add(td5)
                    tr.Cells.Add(td6)

                End If
                ctr += 1
            End If

            Table1.Rows.Add(tr)

        Next

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
        LoadMedicineInfo()
        Return True
    End Function

    Protected Sub ddGlAccount_SelectedIndexChanged(sender As Object, e As EventArgs)
        SelectGAaccount()
        loadGenericnames()
    End Sub
    Public Function selectClassification()
        ' lblClass.text = ddClass.selecteditem.text
        lblClass1.Text = ddClass.SelectedItem.Text

        DrpSubClassF = objDerived.GetDataTable("Select SubClassificationID, SubclassificationName from dbo.tbl_SubClassification where ClassificationID = '" & ddClass.SelectedValue & "'", CommandType.Text)
        ddSubClass.DataSource = DrpSubClassF
        ddSubClass.DataTextField = "SubClassificationName"
        ddSubClass.DataValueField = "SubClassificationID"
        ddSubClass.Items.Clear()
        ddSubClass.DataBind()
        ddSubClass.Items.Insert(0, New ListItem("Select", "0"))


        LoadMedicineInfo()

    End Function

    Protected Sub ddSubClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        PListofGL = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & ddClass.SelectedItem.Value & "', '" & ddSubClass.SelectedValue & "'   ", CommandType.Text)
        Me.ddGlAccount.Items.Add("Select")
        Me.ddGlAccount.DataSource = CType(PListofGL, DataTable)
        Me.ddGlAccount.DataTextField = ("GA_Title")
        Me.ddGlAccount.DataValueField = ("GA_ID")
        Me.ddGlAccount.DataBind()
        Me.ddGlAccount.Enabled = True
        SelectGAaccount()
        loadGenericnames()
    End Sub


    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
    "TraceKey" & Guid.NewGuid().ToString("N"),
    "console.log('" & safeMessage & "');",
    True)
    End Sub


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
        subcategory = objDerived.GetDataTable("select [SubCategoryID],[SubCat_Desc]  From [dbo].[tbl_SubCategory] where item_particular_id = '" & Categoryid & "' order by SubCat_Desc", CommandType.Text)
        ddSubCategory.DataSource = subcategory
        ddSubCategory.DataTextField = ("SubCat_Desc")
        ddSubCategory.DataValueField = ("SubCategoryID")
        ddSubCategory.DataBind()
        ddSubCategory.Enabled = True
        Dim categoryname As String = objDerived.GetValue("select description From AMS.item_particular where item_particular_id = " & Categoryid, CommandType.Text)

        lblcategory.Text = " - " & categoryname
        MultiviewSupplier()
        loadStockOfficeSupplies()


        '  MultiviewSupplier()
    End Function

    Public Sub loadGenericnames()
        Dim dtitemdesc As New DataTable
        AddTrace("ddCategory.SelectedValue: " & ddCategory.SelectedValue & ", ddClass.SelectedValue: " & ddClass.SelectedValue)

        dtitemdesc = objDerived.GetDataTable("select max(a.Item_ID) as Item_ID, GenericName from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID inner join ams.item_particular as c on a.item_particular_id = c.item_particular_id where a.item_particular_id = " & ddCategory.SelectedValue & " and c.ClassificationID = " & ddClass.SelectedValue & " and GenericName is not null group by GenericName order by GenericName", CommandType.Text)
        drpGenericName.DataSource = dtitemdesc
        drpGenericName.DataTextField = ("GenericName")
        drpGenericName.DataValueField = ("Item_ID")
        drpGenericName.DataBind()
        drpGenericName.Enabled = True

        ' Set default selected item
        If drpGenericName.Items.Count > 0 Then
            drpGenericName.SelectedIndex = 0
        End If
    End Sub


    Public Sub loadPPQ()
        If drpGenericName IsNot Nothing AndAlso drpGenericName.SelectedItem IsNot Nothing Then
            Dim itemId As String = drpGenericName.SelectedItem.Value
            If Not String.IsNullOrEmpty(itemId) Then
                pPPQ = objDerived.GetDataTable("Select * from ams.tbl_Price_per_qty where item_id ='" & itemId & "'", CommandType.Text)
                pTempPPQ = objDerived.GetDataTable("Select * from ams.tbl_Price_per_qty where item_id ='" & itemId & "'", CommandType.Text)
                GridPPQ.DataSource = pTempPPQ
                GridPPQ.DataBind()
            Else
                GridPPQ.DataSource = Nothing
                GridPPQ.DataBind()
            End If
        Else
            GridPPQ.DataSource = Nothing
            GridPPQ.DataBind()
        End If
    End Sub



    Protected Sub drpGenericName_SelectedIndexChanged(sender As Object, e As EventArgs)
        LoadMedicineInfo()
        pTempPPQ = objDerived.GetDataTable("Select * from ams.tbl_Price_per_qty where item_id ='" & drpGenericName.SelectedItem.Value & "'", CommandType.Text)
        GridPPQ.DataSource = pTempPPQ
        GridPPQ.DataBind()
        Button1.Text = "ADD"
        txtQtyPack.Text = ""
        txtUnitCost.Text = ""
        txtpercent.Text = ""
        txtSellingPrice1.Text = ""
        GridPPQ.SelectedIndex = -1
    End Sub


    Protected Sub LoadMedicineInfo()

        'hdnItemNo.value = drpGenericName.selectedvalue

        Dim CY As String
        CY = "CY" & Year(txtDate.Text)


        If ddClass.SelectedItem.Value = 1 Then
            Me.MultiView1.SetActiveView(Me.View2)
        Else
            Me.MultiView1.SetActiveView(Me.View1)
        End If
        loadCleartext()
        loadUnit()

        If IsDBNull(drpGenericName.SelectedValue()) Or drpGenericName.SelectedValue() = "" Then
            loadCleartext()
            loadwarehouse()
            ledger()
        Else
            loadCleartext()
            loadwarehouse()
            hdnItemNo.Value = drpGenericName.SelectedValue()

            hdnGAId.Value = objDerived.GetValue("select GA_Id from dbo.m_item as a right outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID inner join ams.item_particular as c on a.item_particular_id = c.item_particular_id where a.item_id = " & hdnItemNo.Value, CommandType.Text)
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("select a.Description,a.BrandName,a.Dose,c.ActualPrice,convert(int,b.Qty) ,a.Depreciatedrate,a.Depreciatedvalue,c.Form,c.OTCRx,c.Batch, c.Lot ,c.Mftgdate, c.EpiryDate,c.Alert,isnull(b.Location,' - '),isnull(b.warehouse_id,1),a.bfadno,a.itemcode,a.reorderpt,c.sellingprice,b.ReorderPt,b.StockDate From ams.TBMedicine_Info as a inner join ams.TBMedicine_DTl as c on a.MedicineId = c.MedicineID inner join ams.Stock as b on a.StockID = b.StockID  where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)


            'optimize code
            Dim textBoxes() As TextBox = {txtMedicineBrandName, txtMedicineOTXRX, txtMedicineDose, txtMedicineBatch1,
                                    txtMedicineForm, txtMedicineUnitprice, txtMedicineLot, txtMedicineQuantity,
                                    txtMedicineMdate, txtMedicineDepRate, txtMedicineEdate, txtMedicineDepValue,
                                    txtMedicineAlert, txtSellPrice, txtBFADNo, txtItemCode}

            For Each txtBox As TextBox In textBoxes
                txtBox.ReadOnly = False
            Next


            btnMedicineSave.Enabled = True
            btnMedicineSave.Enabled = True
            btnMedicineSave.Text = "SAVE"
            DRP.Text = ""
            LTD.Text = ""
            RP.Text = ""
            txtReOrderPt.Text = ""
            txtSellPrice.Text = ""

            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("select reorderPT from dbo.m_item where  Item_ID='" & hdnItemNo.Value & "'", CommandType.Text)
            If dt1.Rows.Count > 0 Then
                txtReOrderPt.Text = dt1.Rows(0).Item(0)
            Else
            End If


            ledger()
        End If
    End Sub


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
        Dim CY As String
        CY = "CY" & Year(txtDate.Text)

        Dim dtStock As New DataTable
        ' dtStock = objDerived.GetDataTable("Exec [dbo].[sp_SMSSStockSupplies] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022] '" & ddGlAccount.SelectedValue() & "','0','" & CY & "','" & ddCategory.SelectedValue() & "','" & ddSubCategory.SelectedValue() & "'", CommandType.Text)
        If dtStock.Rows.Count < 10 Then
            dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
        End If
        grdStockList.DataSource = dtStock
        grdStockList.DataBind()
        grdStockList.SelectedIndex = 0


        loadGenericnames()
        LoadMedicineInfo()

        'Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_StockSupplies_Batches] '" & grdStockList.SelectedDataKey("GA_ID") & "','" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatable2(3 - dtStock.Rows.Count))
        End If
        grdsupplies.DataSource = dtStock
        grdsupplies.DataBind()
        grdsupplies.SelectedIndex = -1
        ledger()



    End Sub


    Protected Sub ddCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectCatergory()
        pTempPPQ = objDerived.GetDataTable("Select * from ams.tbl_Price_per_qty where item_id ='" & drpGenericName.SelectedValue & "'", CommandType.Text)
        GridPPQ.DataSource = pTempPPQ
        GridPPQ.DataBind()

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
        Dim CY As String
        CY = "CY" & Year(txtDate.Text)

        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [dbo].[sp_SMSSStockSupplies_Search_v1_02092022]'" & ddGlAccount.SelectedValue() & "','0','" & CY & "','" & ddCategory.SelectedValue() & "','" & ddSubCategory.SelectedValue() & "', '%" & replaceapostrophe(txtSearchStock.Text) & "%'", CommandType.Text)
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
        txtLenght.Text = ""
        txtWidth.Text = ""
        txtHeight.Text = ""
        txtWeight.Text = ""
        txtDepValue.Text = ""

        lnksuppliermed.Text = ""
        txtItemDesc2.Text = ""
        txtBrandName2.Text = ""
        txtDepRate.Text = ""
        txtDepValue.Text = ""
        txtEDate.Text = ""
        txtAlert.Text = ""
        txtUnitPrice.Text = ""
        txtQuantity.Text = ""
        txtBay.Text = ""
        txtColumn.Text = ""
        txtFloor.Text = ""
        txtRoom.Text = ""
        txtShelves.Text = ""
        txtRack.Text = ""
        txtBin.Text = ""


        txtMedicineName.Text = ""
        txtMedicineBrandName.Text = ""
        txtBFADNo.Text = ""
        txtItemCode.Text = ""
        txtMedicineDose.Text = ""

        txtMedicineUnitprice.Text = ""

        txtMedicineQuantity.Text = ""

        txtMedicineDepRate.Text = ""


        txtMedicineDepValue.Text = ""


        txtMedicineForm.Text = ""


        txtMedicineOTXRX.Text = ""

        txtMedicineBatch1.Text = ""


        txtMedicineLot.Text = ""

        txtMedicineMdate.Text = ""

        txtMedicineEdate.Text = ""

        txtMedicineAlert.Text = ""

        txtMedicineBay.Text = ""
        txtMedicineColumn.Text = ""
        txtMedicineFloor.Text = ""
        txtMedicineRoom.Text = ""
        txtMedicineRack.Text = ""
        txtMedicineShelves.Text = ""

        txtMedicineBin.Text = ""

    End Sub
    Public Sub loadwarehouse()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("select warehouse_id,wname From ams.loc_warehouse where isUsed = 'True'", CommandType.Text)
        drpMedicineWarehouse.DataTextField = ("wname")
        drpMedicineWarehouse.DataValueField = ("warehouse_id")
        drpMedicineWarehouse.DataSource = dt
        drpMedicineWarehouse.DataBind()

    End Sub

    Protected Sub LoadStockChangeIndex()

        Dim CY As String
        CY = "CY" & Year(txtDate.Text)


        If ddClass.SelectedItem.Value = 1 Then
            Me.MultiView1.SetActiveView(Me.View2)
        Else
            Me.MultiView1.SetActiveView(Me.View1)
        End If
        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_StockSupplies_Batches] '" & grdStockList.SelectedDataKey("GA_ID") & "','" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatable2(3 - dtStock.Rows.Count))
        End If
        grdsupplies.DataSource = dtStock
        grdsupplies.DataBind()
        grdsupplies.SelectedIndex = -1


        If IsDBNull(grdStockList.SelectedDataKey("Item_ID")) Then
            loadCleartext()
            loadwarehouse()
            ledger()
        Else
            loadCleartext()
            loadwarehouse()
            hdnItemNo.Value = grdStockList.SelectedDataKey("Item_ID")
            hdnGAId.Value = grdStockList.SelectedDataKey("GA_ID")
            If grdStockList.SelectedRow.Cells(3).Text <> 0 Then
                Dim dt As New DataTable

                dt = objDerived.GetDataTable("select a.Description,a.BrandName,a.Dose,c.ActualPrice,convert(int,b.Qty) , " _
                                                 & "" & "a.Depreciatedrate,a.Depreciatedvalue,c.Form,c.OTCRx,c.Batch," _
                                                 & "" & " c.Lot ,c.Mftgdate, c.EpiryDate,c.Alert,isnull(b.Location,' - ')," _
                                                 & "" & "isnull(b.warehouse_id,1)  From ams.TBMedicine_Info as a inner join ams.TBMedicine_DTl as c on a.MedicineId = c.MedicineID inner join ams.Stock as b on a.StockID = b.StockID  where a.Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                txtMedicineName.Text = dt.Rows(0).Item(0)
                txtMedicineName.ReadOnly = False


                txtMedicineBrandName.Text = dt.Rows(0).Item(1)
                txtMedicineBrandName.ReadOnly = False


                txtMedicineDose.Text = dt.Rows(0).Item(2)
                txtMedicineDose.ReadOnly = False

                txtMedicineUnitprice.Text = dt.Rows(0).Item(3)
                txtMedicineUnitprice.ReadOnly = False


                txtMedicineQuantity.Text = dt.Rows(0).Item(4)
                txtMedicineQuantity.ReadOnly = False


                txtMedicineDepRate.Text = dt.Rows(0).Item(5)
                txtMedicineDepRate.ReadOnly = False


                txtMedicineDepValue.Text = dt.Rows(0).Item(6)
                txtMedicineDepValue.ReadOnly = False


                txtMedicineForm.Text = dt.Rows(0).Item(7)
                txtMedicineForm.ReadOnly = False


                txtMedicineOTXRX.Text = dt.Rows(0).Item(8)
                txtMedicineOTXRX.ReadOnly = False

                txtMedicineBatch1.Text = dt.Rows(0).Item(9)
                txtMedicineBatch1.ReadOnly = False


                txtMedicineLot.Text = dt.Rows(0).Item(10)
                txtMedicineLot.ReadOnly = False


                txtMedicineMdate.Text = dt.Rows(0).Item(11)
                txtMedicineMdate.ReadOnly = False


                txtMedicineEdate.Text = dt.Rows(0).Item(12)
                txtMedicineEdate.ReadOnly = False


                txtMedicineAlert.Text = dt.Rows(0).Item(13)
                txtMedicineAlert.ReadOnly = False


                Dim i As Integer = DateDiff("d", txtMedicineAlert.Text, Date.Now)

                If i >= 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "This Item is going to expire on " & txtMedicineEdate.Text)
                End If




                '''--------------------location
                Dim location As String
                location = dt.Rows(0).Item(14)
                Dim locationsplit As String() = location.Split("-")
                If location.Contains("Bay") Then
                    txtMedicineBay.Text = locationsplit(1)
                ElseIf location.Contains("Column") Then
                    txtMedicineColumn.Text = locationsplit(1)
                ElseIf location.Contains("Floor") Then
                    txtMedicineFloor.Text = locationsplit(1)
                ElseIf location.Contains("Room") Then
                    txtMedicineRoom.Text = locationsplit(1)
                ElseIf location.Contains("Shelves") Then
                    txtMedicineShelves.Text = locationsplit(1)
                ElseIf location.Contains("Rack") Then
                    txtMedicineRack.Text = locationsplit(1)
                ElseIf location.Contains("Bin") Then
                    txtMedicineBin.Text = locationsplit(1)
                End If

                Dim warehouse As String
                warehouse = dt.Rows(0).Item(15)
                drpMedicineWarehouse.SelectedValue = warehouse

                btnMedicineSave.Enabled = False
                btnMedicineSave.Enabled = False
            Else
                Dim dt As New DataTable
                Dim obj As New BaseClasses.Items
                txtMedicineName.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                txtMedicineName.ReadOnly = False

                txtMedicineBrandName.Text = obj.GetValue("select Brand From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                txtMedicineBrandName.ReadOnly = False

                txtMedicineOTXRX.ReadOnly = False
                txtMedicineDose.ReadOnly = False
                txtMedicineBatch1.ReadOnly = False

                txtMedicineForm.ReadOnly = False
                txtMedicineUnitprice.Text = obj.GetValue("select " & CY & " From dbo.m_item_detail where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                txtMedicineUnitprice.ReadOnly = False
                txtMedicineLot.ReadOnly = False
                txtMedicineQuantity.ReadOnly = False
                txtMedicineMdate.ReadOnly = False
                txtMedicineDepRate.ReadOnly = False
                txtMedicineEdate.ReadOnly = False
                txtMedicineDepValue.ReadOnly = False
                txtMedicineAlert.ReadOnly = False
                btnMedicineSave.Enabled = True
                btnMedicineSave.Enabled = True

                ' txtItemDesc2.text = dt.Rows(0).Item(0)
            End If
            ledger()
        End If



    End Sub

    Protected Sub ledger()
        Dim dtStock As New DataTable
        Dim gaid As Integer

        If hdnItemNo.Value = "" Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] null", CommandType.Text)
        Else
            gaid = hdnItemNo.Value
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & gaid & "'", CommandType.Text)

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

        Me.MultiView1.SetActiveView(Me.View1)
        'imgmedical.ImageUrl = "~/images/blankImage.jpg"
        loadStockOfficeSupplies()
        'LoadSupplies()
    End Sub

    Protected Sub ddSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        MultiviewSupplier()
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs)

        If btnSave.Text = "SAVE" Then

        End If




    End Sub
    ''Before optimization orginal code
    Public Sub UpdateMedicines_OriginalCode()
        If txtMedicineName.Text = "" Or txtMedicineBrandName.Text = "" Or txtMedicineUnitprice.Text = "" Or txtMedicineQuantity.Text = "" Or txtReOrderPt.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity / Reorder Pt.")
        Else

            objDerived.Execute("Update dbo.m_item set unit_id = " & drpUnit.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)


            Dim locations As String

            If txtMedicineBay.Text <> "" Then
                locations = "Bay-" & txtMedicineBay.Text
            End If

            If txtMedicineColumn.Text <> "" Then
                locations = locations + " " + "Column-" & txtMedicineColumn.Text
            End If

            If txtMedicineFloor.Text <> "" Then
                locations = locations + " " + "Floor-" & txtMedicineFloor.Text
            End If

            If txtMedicineRoom.Text <> "" Then
                locations = locations + " " + "Room-" & txtMedicineRoom.Text
            End If

            If txtMedicineShelves.Text <> "" Then
                locations = locations + " " + "Shelves-" & txtMedicineShelves.Text
            End If

            If txtMedicineRack.Text <> "" Then
                locations = locations + " " + "Rack-" & txtMedicineRack.Text
            End If

            If txtMedicineBin.Text <> "" Then
                locations = locations + " " + "Bin-" & txtMedicineBin.Text
            End If



            Dim txtPrice As TextBox = CType(txtMedicineUnitprice, TextBox)
            Dim txtqty As TextBox = CType(txtMedicineQuantity, TextBox)

            '----Update Receiving
            objDerived.GetRecords("UPDATE [AMS].[Tb_Receiving_Dtl] " +
                                    " SET [PO_Qty] = '" & txtqty.Text & "' " +
                                    " ,[Qty_Received] = '" & txtqty.Text & "' " +
                                    " ,[Cost] = '" & txtPrice.Text & "' " +
                                    " ,[Location] = '" & locations & "' " +
                                    " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim t1 As Decimal
            Dim total As Decimal = 0

            t1 = txtqty.Text * txtPrice.Text
            total = total + t1
            Session("ContractPrice") = total

            '----Update PO_dtl
            objDerived.GetRecords("UPDATE [AMS].[PO_Dtl] " +
                                        " SET [qty] = '" & txtqty.Text & "' " +
                                        " ,[cost] = '" & txtPrice.Text & "' " +
                                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)


            '----Update AIR_Dtl
            objDerived.GetRecords("UPDATE [AMS].[AIR_Dtl] " +
                                        " SET [Qty] = '" & txtqty.Text & "' " +
                                        " ,[Cost] = '" & txtPrice.Text & "' " +
                                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)

            '----Update STOCK
            objDerived.GetRecords("UPDATE [AMS].[stock] " +
                                        " SET [Qty] = '" & txtqty.Text & "' " +
                                        " ,[Balance] = '" & txtqty.Text & "' " +
                                        " ,[Cost] = '" & txtPrice.Text & "' " +
                                        " ,[Location] = '" & locations & "' " +
                                        " ,[warehouse_ID] = '" & drpMedicineWarehouse.SelectedValue() & "' " +
                                        " ,[StockDate] = '" & txtSellectDate.Text & "' " +
                                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)

            '----Update stockledger
            objDerived.GetRecords("UPDATE [AMS].[TbStock_Ledger] " +
                                        " SET DebitUnit = '" & drpUnit.SelectedItem.Text & "',[DebitQty] = '" & txtqty.Text & "' " +
                                        " ,[DebitCost] = '" & CType(txtqty.Text * txtPrice.Text, Decimal) & "',BalanceUnit = '" & drpUnit.SelectedItem.Text & "' " +
                                         " WHERE Item_ID = '" & hdnItemNo.Value & "'and Trans_Type like 'Starting Balance'", CommandType.Text)

            '----Update MEDICINE INFO
            objDerived.GetRecords("UPDATE [AMS].[TBMedicine_Info] " +
                                            " SET [Description] = '" & txtMedicineName.Text & "' " +
                                            " ,[DrugName ] = '" & txtMedicineName.Text & "' " +
                                            " ,[BrandName ] = '" & txtMedicineBrandName.Text & "' " +
                                            " ,[Dose] = '" & txtMedicineDose.Text & "' " +
                                            " ,[Location] = '" & locations & "' " +
                                            " ,[DeliveryDate] = '" & txtDate.Text & "' " +
                                            " WHERE Item_Id = '" & hdnItemNo.Value & "'", CommandType.Text)


            objDerived.Execute("EXEC sp_UpdateBalancefromLedger " & hdnItemNo.Value, CommandType.Text)

            '----Update MEDICINE INFO
            objDerived.GetRecords("UPDATE [AMS].[TBMedicine_DTl] " +
                                            " SET [OTCRx] = '" & txtMedicineOTXRX.Text & "' " +
                                            " ,[Form ] = '" & txtMedicineForm.Text & "' " +
                                            " ,[Mftgdate ] = '" & txtMedicineMdate.Text & "' " +
                                            " ,[Alert] = '" & txtMedicineAlert.Text & "' " +
                                            " ,[Batch] = '" & txtMedicineBatch1.Text & "' " +
                                            " ,[Lot] = '" & txtMedicineLot.Text & "' " +
                                            " ,[ActualPrice] = '" & txtMedicineUnitprice.Text & "' " +
                                            " ,[EpiryDate] = '" & txtMedicineEdate.Text & "' " +
                                            " ,[SellingPrice] = '" & txtSellPrice.Text & "' " +
                                            " WHERE Item_Id = '" & hdnItemNo.Value & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer = txtqty.Text
            If a >= c Then
                ModalPopupExtender3.Show()
            End If
            LoadMedicineInfo()
            ledger()



        End If

    End Sub



    Public Sub UpdateMedicines()
        ' Server-Side Validation
        Dim itemId As Long
        Dim unitId As Long
        Dim gaId As Long
        Dim warehouseId As Long
        Dim quantity As Integer
        Dim reorderPt As Integer
        Dim unitCost As Decimal
        Dim sellingPrice As Decimal
        Dim ppqPercent As Integer
        Dim receivedDate As DateTime
        Dim stockDate As DateTime
        Dim expiryDate As DateTime

        ' Validate hdnItemNo.Value
        If String.IsNullOrWhiteSpace(hdnItemNo.Value) OrElse Not Long.TryParse(hdnItemNo.Value, itemId) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid or missing Item ID.")
            Exit Sub
        End If

        ' Validate drpUnit.SelectedValue
        If drpUnit.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(drpUnit.SelectedValue) OrElse Not Long.TryParse(drpUnit.SelectedValue, unitId) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a valid Unit.")
            Exit Sub
        End If

        ' Validate hdnGAId.Value
        If String.IsNullOrWhiteSpace(hdnGAId.Value) OrElse Not Long.TryParse(hdnGAId.Value, gaId) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid or missing GA ID.")
            Exit Sub
        End If

        ' Validate drpMedicineWarehouse.SelectedValue
        'If String.IsNullOrWhiteSpace(drpMedicineWarehouse.SelectedValue) OrElse Not Long.TryParse(drpMedicineWarehouse.SelectedValue, warehouseId) Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a valid Warehouse.")
        '    Exit Sub
        'End If

        ' Validate required TextBoxes
        If String.IsNullOrWhiteSpace(txtMedicineBrandName.Text) OrElse
       String.IsNullOrWhiteSpace(txtMedicineUnitprice.Text) OrElse
       String.IsNullOrWhiteSpace(txtMedicineQuantity.Text) OrElse
       String.IsNullOrWhiteSpace(txtReOrderPt.Text) OrElse
       String.IsNullOrWhiteSpace(txtSellectDate.Text) OrElse
       String.IsNullOrWhiteSpace(txtMedicineAlert.Text) OrElse
       String.IsNullOrWhiteSpace(txtMedicineEdate.Text) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill up the required fields: Name, Brand Name, Unit Cost, Quantity, Reorder Point, Manufacturing Info.")
            Exit Sub
        End If

        ' Validate numeric TextBoxes
        If Not Integer.TryParse(txtMedicineQuantity.Text, quantity) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid integer for Quantity.")
            Exit Sub
        End If

        If Not Integer.TryParse(txtReOrderPt.Text, reorderPt) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid integer for Reorder Point.")
            Exit Sub
        End If

        If Not Decimal.TryParse(txtMedicineUnitprice.Text, unitCost) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Unit Cost.")
            Exit Sub
        End If

        If Not Decimal.TryParse(txtSellPrice.Text, sellingPrice) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Selling Price.")
            Exit Sub
        End If

        ' Validate PPQ Percent if applicable
        If Not String.IsNullOrWhiteSpace(txtpercent.Text) AndAlso Not Integer.TryParse(txtpercent.Text, ppqPercent) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid integer for PPQ Percent.")
            Exit Sub
        End If

        ' Validate Date Fields
        If Not TryParseDate(txtDate.Text, receivedDate, "Received Date") Then Exit Sub
        If Not TryParseDate(txtSellectDate.Text, stockDate, "Stock Date") Then Exit Sub
        If Not TryParseDate(txtMedicineEdate.Text, expiryDate, "Expiration Date") Then Exit Sub

        ' Proceed with updating since all validations passed
        objDerived.Execute("UPDATE dbo.m_item SET unit_id = " & unitId & " WHERE item_id = " & itemId, CommandType.Text)

        ' Reconstruct Location String using StringBuilder
        Dim sb As New StringBuilder()
        If Not String.IsNullOrWhiteSpace(txtMedicineBay.Text) Then
            sb.Append("Bay-").Append(txtMedicineBay.Text)
        End If
        If Not String.IsNullOrWhiteSpace(txtMedicineColumn.Text) Then
            sb.Append(" Column-").Append(txtMedicineColumn.Text)
        End If
        If Not String.IsNullOrWhiteSpace(txtMedicineFloor.Text) Then
            sb.Append(" Floor-").Append(txtMedicineFloor.Text)
        End If
        If Not String.IsNullOrWhiteSpace(txtMedicineRoom.Text) Then
            sb.Append(" Room-").Append(txtMedicineRoom.Text)
        End If
        If Not String.IsNullOrWhiteSpace(txtMedicineShelves.Text) Then
            sb.Append(" Shelves-").Append(txtMedicineShelves.Text)
        End If
        If Not String.IsNullOrWhiteSpace(txtMedicineRack.Text) Then
            sb.Append(" Rack-").Append(txtMedicineRack.Text)
        End If
        If Not String.IsNullOrWhiteSpace(txtMedicineBin.Text) Then
            sb.Append(" Bin-").Append(txtMedicineBin.Text)
        End If
        Dim locations As String = sb.ToString()


        Dim dt As DataTable = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpGenericName.SelectedItem.Value & "'", CommandType.Text)

        For i As Integer = 0 To grdLedger.Rows.Count - 1
            Dim cb1 As CheckBox = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

            If cb1.Visible AndAlso cb1.Checked Then

                If dt.Rows.Count > 0 Then
                    Dim stockID As String = dt.Rows(i).Item("StockID").ToString()



                    '----Update STOCK
                    objDerived.GetRecords("UPDATE [AMS].[stock] " &
                                     " SET [Qty] = " & quantity & " " &
                                     " ,[Balance] = " & quantity & " " &
                                     " ,[Cost] = " & unitCost & " " &
                                     " ,[Location] = '" & Replace(locations, "'", "''") & "' " &
                                     " ,[warehouse_ID] = " & warehouseId & " " &
                                     " ,[StockDate] = '" & stockDate.ToString("MM/dd/yyyy") & "' " &
                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "'  ", CommandType.Text)

                    '----Update stockledger
                    Dim qty As Decimal
                    Dim unitPrice As Decimal
                    Dim unitOtherPrice As Decimal

                    ' Check if the values are numeric and convert them
                    If IsNumeric(quantity) AndAlso IsNumeric(txtMedicineUnitprice.Text) AndAlso IsNumeric(unitCost) Then
                        qty = CDec(quantity)
                        unitPrice = CDec(txtMedicineUnitprice.Text)
                        unitOtherPrice = CDec(unitCost)

                        ' Proceed with the SQL query
                        objDerived.GetRecords("UPDATE [AMS].[TbStock_Ledger] " +
                                                " SET DebitUnit = '" & drpUnit.SelectedItem.Text & "', " &
                                                " [DebitQty] = '" & qty & "', " &
                                                " [DebitCost] = '" & (qty * unitPrice) & "', " &
                                                " BalanceUnit = '" & drpUnit.SelectedItem.Text & "', " &
                                                " BalanceCost = (SELECT TOP 1 BalanceCost FROM AMS.TbStock_Ledger WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "' ORDER BY StockLedger_ID DESC) + (" & (qty * unitOtherPrice) & ") " &
                                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "'", CommandType.Text)
                    Else
                        ' Handle the case where the input is not valid (e.g., show an error message); well for now its useless so do nothing i guess
                    End If

                    '----Update MEDICINE INFO
                    objDerived.GetRecords("UPDATE [AMS].[TBMedicine_Info] " &
                                     " SET [Description] = '" & Replace(txtMedicineName.Text, "'", "''") & "' " &
                                     " ,[DrugName] = '" & Replace(txtMedicineName.Text, "'", "''") & "' " &
                                     " ,[BrandName] = '" & Replace(txtMedicineBrandName.Text, "'", "''") & "' " &
                                     " ,[Dose] = '" & Replace(txtMedicineDose.Text, "'", "''") & "' " &
                                     " ,[Location] = '" & Replace(locations, "'", "''") & "' " &
                                     " ,[DeliveryDate] = '" & receivedDate.ToString("MM/dd/yyyy") & "' " &
                                            " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "' ", CommandType.Text)

                    '----Update MEDICINE_DTl
                    objDerived.GetRecords("UPDATE [AMS].[TBMedicine_DTl] " &
                                     " SET [OTCRx] = '" & Replace(txtMedicineOTXRX.Text, "'", "''") & "' " &
                                     " ,[Form] = '" & Replace(txtMedicineForm.Text, "'", "''") & "' " &
                                     " ,[Mftgdate] = '" & receivedDate.ToString("MM/dd/yyyy") & "' " &
                                     " ,[Alert] = '" & Replace(txtMedicineAlert.Text, "'", "''") & "' " &
                                     " ,[Batch] = '" & Replace(txtMedicineBatch1.Text, "'", "''") & "' " &
                                     " ,[Lot] = '" & Replace(txtMedicineLot.Text, "'", "''") & "' " &
                                     " ,[ActualPrice] = " & unitCost & " " &
                                     " ,[EpiryDate] = '" & expiryDate.ToString("MM/dd/yyyy") & "' " &
                                     " ,[SellingPrice] = " & sellingPrice & " " &
                                            " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockId = '" & stockID & "' ", CommandType.Text)

                End If
            End If
        Next



        ''----Update Receiving
        'objDerived.GetRecords("UPDATE [AMS].[Tb_Receiving_Dtl] " &
        '                 " SET [PO_Qty] = " & quantity & " " &
        '                 " ,[Qty_Received] = " & quantity & " " &
        '                 " ,[Cost] = " & unitCost & " " &
        '                 " ,[Location] = '" & Replace(locations, "'", "''") & "' " &
        '                 " WHERE Item_ID = " & itemId, CommandType.Text)

        ''----Update PO_dtl
        'objDerived.GetRecords("UPDATE [AMS].[PO_Dtl] " &
        '                 " SET [qty] = " & quantity & " " &
        '                 " ,[cost] = " & unitCost & " " &
        '                 " WHERE Item_ID = " & itemId, CommandType.Text)

        ''----Update AIR_Dtl
        'objDerived.GetRecords("UPDATE [AMS].[AIR_Dtl] " &
        '                 " SET [Qty] = " & quantity & " " &
        '                 " ,[Cost] = " & unitCost & " " &
        '                 " WHERE Item_ID = " & itemId, CommandType.Text)

        Dim total As Decimal = 0
        Dim t1 As Decimal = unitCost * quantity
        total += t1
        Session("ContractPrice") = total

        ' Refresh Ledger
        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_SuppliesLedger] '" & itemId & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
        End If
        grdLedger.DataSource = dtStock
        grdLedger.DataBind()

        ' Display Success Message
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        ' Check Reorder Point
        Dim a As Integer = objDerived.GetValue("SELECT ReorderPt FROM ams.Stock WHERE Item_ID = " & itemId, CommandType.Text)
        Dim c As Integer = quantity
        If a >= c Then
            ModalPopupExtender3.Show()
        End If

        ' Reload Stock Supplies
        loadStockOfficeSupplies()

    End Sub


    Private Function TryParseDate(input As String, ByRef output As DateTime, fieldName As String) As Boolean
        If String.IsNullOrWhiteSpace(input) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, fieldName & " is required.")
            Return False
        End If

        If Not DateTime.TryParse(input, output) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid date for " & fieldName & ".")
            Return False
        End If

        Return True
    End Function



    Public Sub SaveMedicines()
        ' Server-Side Validation
        Dim itemId As Long
        Dim unitId As Long
        Dim gaId As Long
        Dim warehouseId As Long
        Dim quantity As Integer
        Dim reorderPt As Integer
        Dim unitCost As Decimal
        Dim sellingPrice As Decimal
        Dim ppqPercent As Integer
        Dim receivedDate As DateTime
        Dim stockDate As DateTime
        Dim expiryDate As DateTime

        ' Validate hdnItemNo.Value
        If String.IsNullOrWhiteSpace(hdnItemNo.Value) OrElse Not Long.TryParse(hdnItemNo.Value, itemId) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid or missing Item ID.")
            Exit Sub
        End If

        ' Validate drpUnit.SelectedValue
        If drpUnit.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(drpUnit.SelectedValue) OrElse Not Long.TryParse(drpUnit.SelectedValue, unitId) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a valid Unit.")
            Exit Sub
        End If

        ' Validate hdnGAId.Value
        If String.IsNullOrWhiteSpace(hdnGAId.Value) OrElse Not Long.TryParse(hdnGAId.Value, gaId) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid or missing GA ID.")
            Exit Sub
        End If

        ' Validate drpMedicineWarehouse.SelectedValue
        'If String.IsNullOrWhiteSpace(drpMedicineWarehouse.SelectedValue) OrElse Not Long.TryParse(drpMedicineWarehouse.SelectedValue, warehouseId) Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a valid Warehouse.")
        '    Exit Sub
        'End If

        ' Validate required TextBoxes
        If String.IsNullOrWhiteSpace(drpGenericName.Text) OrElse
       String.IsNullOrWhiteSpace(txtMedicineBrandName.Text) OrElse
       String.IsNullOrWhiteSpace(txtMedicineUnitprice.Text) OrElse
       String.IsNullOrWhiteSpace(txtMedicineQuantity.Text) OrElse
       String.IsNullOrWhiteSpace(txtReOrderPt.Text) OrElse
       String.IsNullOrWhiteSpace(txtSellectDate.Text) OrElse
       String.IsNullOrWhiteSpace(txtMedicineAlert.Text) OrElse
       String.IsNullOrWhiteSpace(txtMedicineEdate.Text) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill up the required fields: Name, Brand Name, Unit Cost, Quantity, Reorder Point, Manufacturing Info.")
            Exit Sub
        End If

        ' Validate numeric TextBoxes
        If Not Integer.TryParse(txtMedicineQuantity.Text, quantity) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid integer for Quantity.")
            Exit Sub
        End If

        If Not Integer.TryParse(txtReOrderPt.Text, reorderPt) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid integer for Reorder Point.")
            Exit Sub
        End If

        If Not Decimal.TryParse(txtMedicineUnitprice.Text, unitCost) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Unit Cost.")
            Exit Sub
        End If

        If Not Decimal.TryParse(txtSellPrice.Text, sellingPrice) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Selling Price.")
            Exit Sub
        End If

        ' Validate PPQ Percent if applicable
        If Not String.IsNullOrWhiteSpace(txtpercent.Text) AndAlso Not Integer.TryParse(txtpercent.Text, ppqPercent) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid integer for PPQ Percent.")
            Exit Sub
        End If

        ' Validate Date Fields
        If Not TryParseDate(txtDate.Text, receivedDate, "Received Date") Then Exit Sub
        If Not TryParseDate(txtSellectDate.Text, stockDate, "Stock Date") Then Exit Sub
        If Not TryParseDate(txtMedicineEdate.Text, expiryDate, "Expiration Date") Then Exit Sub

        ' Proceed with saving since all validations passed
        objDerived.Execute("UPDATE dbo.m_item SET unit_id = " & unitId & " WHERE item_id = " & itemId, CommandType.Text)

        '--------------------------------------------------------------
        '=-= SAVE AMS.Tb_Receiving
        Dim rcv As New Receiving.t_receiving
        With rcv
            .Received_Date = receivedDate
            .ReceivedBY = 0
            .POHdr_ID = 0
            .PO_No = ""
            .Supplier_ID = 0
            .GA_ID = gaId
            .isAccepted = False
            .UserID = Session("@UserName")
        End With
        Dim rcvID As Long = rcv.save()

        Session("Received_ID") = rcvID
        Dim rcv_dtl As New Receiving.t_receiving_dtl
        Dim total As Decimal = 0
        Dim location As String = BuildLocation()

        With rcv_dtl
            .Received_ID = rcvID
            .Item_ID = itemId
            .PO_Qty = quantity
            .Qty_Received = quantity
            .Cost = unitCost
            .Condition = ""
            .Location = location
        End With
        Dim RcvDtl_ID As Long = rcv_dtl.save()

        Dim t1 As Decimal = unitCost * quantity
        total += t1
        Session("ContractPrice") = total

        '=-= SAVE OF PURCHASED ORDER
        Dim pohdr_id As Long
        Dim POhdr As New t_purchase_order_hdr
        Dim POnumber As String = "Starting Inventory"

        With POhdr
            .PO_No = POnumber
            .PO_Date = receivedDate
            .Supplier_ID = 0
            .mode_of_procurement_id = 2
            .DeliveryTerm = 0
            .paymentTerm = 0
            .DeliveryDate = receivedDate
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
            .DateApproved_PO_Mayor = receivedDate
            .DateReceived_PO_Mayor = receivedDate
            .DateDisApprove = New Date(1900, 1, 1)
            .isGasoline = False
            .isReimbursement = False
        End With

        Dim po_id As New DataTable
        po_id = objDerived.GetDataTable("SELECT pohdr_id FROM ams.po_hdr WHERE po_no LIKE '" & POnumber & "' AND Supplier_ID = 0", CommandType.Text)

        If po_id.Rows.Count = 0 Then
            POhdr.ContractPrice = CType(Session("ContractPrice"), Decimal)
            pohdr_id = POhdr.save()
        Else
            Dim poid As Integer = objDerived.GetValue("SELECT pohdr_id FROM ams.po_hdr WHERE po_no LIKE '" & POnumber & "' AND Supplier_ID = 0", CommandType.Text)
            Dim TAmount As Decimal = objDerived.GetValue("SELECT ContractPrice FROM ams.po_hdr WHERE pohdr_id = " & poid, CommandType.Text)

            POhdr.ContractPrice = TAmount + CType(Session("ContractPrice"), Decimal)
            POhdr.POHdr_ID = poid
            pohdr_id = POhdr.update()
        End If

        objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = " & gaId & ", ProjectName = 'Manual Encode' WHERE POHdr_ID = " & pohdr_id, CommandType.Text)
        Session("POHdr_ID") = pohdr_id

        '=-= SAVE OF INSPECTION & ACCEPTANCE
        Dim objhdr As New t_inspection_and_acceptance_hdr
        Dim airhdr_id As Long
        Dim air As String = objDerived.GetValue("SELECT [AMS].[func_GenerateAIR]('" & receivedDate.ToString("MM/dd/yyyy") & "')", CommandType.Text)

        With objhdr
            .AIR_No = air
            .AIR_Date = receivedDate
            .Date_Received = receivedDate
            .Date_Inspect = receivedDate
            .Date_Accepted = receivedDate
            .Invoice_No = " "
            .Invoice_date = receivedDate
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

        objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET UserID = '" & Session("@UserName") & "', Received_ID = " & rcvID & " WHERE AIRHdr_ID = " & airhdr_id, CommandType.Text)

        Dim objdtl As New t_inspection_and_acceptance_dtl

        '=-= PO Details Save
        Dim POdtl As New t_purchase_order_dtl
        With POdtl
            .POHdr_ID = pohdr_id
            .Item_ID = itemId
            .cost = unitCost
            .qty = quantity
            .remarks = "Manual Encode"
        End With
        POdtl.save()

        '=-= AIR DETAILS
        With objdtl
            .Item_ID = itemId
            .Qty = quantity
            .Cost = unitCost ' Assuming UnitCost is the same as AIR Cost
            .AIRHdr_ID = airhdr_id
            .GA_ID = gaId
        End With
        Dim iaDtl_ID As Integer = objdtl.save()
        Session("AIRDtl_ID") = iaDtl_ID

        Dim objStock As New Supplies_Stock

        '=-= SAVE STOCK
        With objStock
            .StockDate = stockDate
            .Item_ID = itemId
            .Qty = quantity
            .Balance = quantity
            .Location = location
            .Expiration_Date = New Date(1900, 1, 1)
            .Cost = unitCost
            .Issuance = 0
            .RC_ID = objDerived.GetValue("SELECT DISTINCT [RC_id] FROM [dbo].[View_RespCenter_withFunctions] WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'", CommandType.Text)
            .Function_ID = 0
            .Project_ID = 0
            .Program_id = 0
            .F_ID = 4
            .AIRDtl_ID = iaDtl_ID
            .GA_ID = gaId
            .Warehouseid = warehouseId
            .ReorderPt = reorderPt

            ' Reconstruct Location String
            .Location = location
        End With

        Dim StockID As Long = objStock.save()
        objDerived.GetRecords("UPDATE AMS.Stock SET Received_ID = " & rcvID & " WHERE StockID = " & StockID, CommandType.Text)

        Dim objStockLedger As New t_StockLedger
        '---------------------------------------------------------
        '====== save ledger ========
        With objStockLedger
            .StockID = StockID
            .Trans_Type = "Starting Balance"
            .Ref = air
            .Department = ""
            .Position = ""
            .AcceptedBy = ""
            .InspectedBy = ""
            .ReceivedBy = ""
            .CreditQty = 0
            .CreditUnit = "-"
            .CreditCost = 0.00D
            .dDate = stockDate
            .Item_ID = itemId
            .DebitQty = quantity
            .DebitCost = unitCost * quantity
            .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = " & itemId, CommandType.Text)
            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = " & itemId, CommandType.Text)
            .BalanceQty = 0
            .BalanceCost = 0
        End With
        objStockLedger.save()

        'Medicine and Medical Supplies
        Dim objMedInfo As New ConsolidatedMedicineSaving.TBMedicine_Info

        With objMedInfo
            .StockId = StockID
            .AIRDtl_ID = iaDtl_ID
            .Item_ID = itemId
            .Description = Replace(txtMedicineName.Text, "'", "''")
            .DrugName = Replace(txtMedicineName.Text, "'", "''")
            .BrandName = Replace(txtMedicineBrandName.Text, "'", "''")
            .SupplierId = 0
            .Dose = Replace(txtMedicineDose.Text, "'", "''")
            .Location = location
            .Status = "Accepted"
            .DeliveryDate = receivedDate
            .Depreciatedrate = If(String.IsNullOrWhiteSpace(txtMedicineDepRate.Text), 0D, CType(txtMedicineDepRate.Text, Decimal))
            .Depreciatedvalue = If(String.IsNullOrWhiteSpace(txtMedicineDepValue.Text), 0D, CType(txtMedicineDepValue.Text, Decimal))
        End With

        Dim MedicineId As Long = objMedInfo.save()

        objDerived.GetRecords("UPDATE AMS.TBMedicine_Info SET Received_ID = " & rcvID & ", bfadno = '" & Replace(txtBFADNo.Text, "'", "''") & "', itemcode = '" & Replace(txtItemCode.Text, "'", "''") & "', reorderpt = " & reorderPt & " WHERE MedicineId = " & MedicineId, CommandType.Text)

        Dim objMedDtl As New ConsolidatedMedicineSaving.TBMedicine_DTl

        With objMedDtl
            .MedicineID = MedicineId
            .StockId = StockID
            .Item_ID = itemId
            .Form = Replace(txtMedicineForm.Text, "'", "''")
            .OTCRx = Replace(txtMedicineOTXRX.Text, "'", "''")
            .Mftgdate = receivedDate ' Assuming Mftgdate is the same as receivedDate
            .Alert = Replace(txtMedicineAlert.Text, "'", "''")
            .Batch = Replace(txtMedicineBatch1.Text, "'", "''")
            .Lot = Replace(txtMedicineLot.Text, "'", "''")
            .ActualPrice = unitCost
            .EpiryDate = expiryDate
            .SellingPrice = sellingPrice
        End With
        objMedDtl.save()

        ' Refresh Ledger
        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_SuppliesLedger] '" & itemId & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
        End If
        grdLedger.DataSource = dtStock
        grdLedger.DataBind()

        ' Display Success Message
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        ' Check Reorder Point
        Dim a As Integer = objDerived.GetValue("SELECT ReorderPt FROM ams.Stock WHERE Item_ID = " & itemId, CommandType.Text)
        Dim c As Integer = quantity
        If a >= c Then
            ModalPopupExtender3.Show()
        End If

        ' Reload Stock Supplies
        loadStockOfficeSupplies()
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
    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)

        Dim classification As String = objDerived.GetValue("select ClassificationName From dbo.tbl_Classification where Classificationid =" & ddClass.SelectedValue, CommandType.Text)
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)
        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else


            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    Dim txtBox As TextBox = DirectCast(ctrl, TextBox)
                    If txtBox IsNot txtBFADNo AndAlso txtBox IsNot txtItemCode AndAlso txtBox IsNot txtMedicineBrandName AndAlso txtBox IsNot txtMedicineName _
               AndAlso txtBox IsNot txtSellPrice AndAlso txtBox IsNot txtMedicineUnitprice AndAlso txtBox IsNot txtMedicineQuantity _
               AndAlso txtBox IsNot txtMedicineDepRate AndAlso txtBox IsNot txtMedicineDepValue AndAlso txtBox IsNot txtMedicineForm _
               AndAlso txtBox IsNot txtMedicineOTXRX AndAlso txtBox IsNot txtMedicineBatch1 AndAlso txtBox IsNot txtMedicineLot Then
                        txtBox.ReadOnly = False
                    End If
                End If
            Next

            btnROP.Enabled = True

            CalendarExtender4.Enabled = True
            CalendarExtender5.Enabled = True
            CalendarExtender6.Enabled = True
            btnMedicineSave.Text = "UPDATE"
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fields are now open for editing")
        End If
    End Sub
    Protected Sub btnAuthCancel_Click(sender As Object, e As EventArgs)
        ModalPopupExtender2.Hide()

    End Sub

    Protected Sub btnMedicineSave_Click(sender As Object, e As EventArgs)
        If btnMedicineSave.Text = "SAVE" Then
            SaveMedicines()
            'Save_PPQ()
        ElseIf btnMedicineSave.Text = "UPDATE" Then
            UpdateMedicines()
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
    Public Sub Save_PPQ()
        For i As Integer = 0 To Me.GridPPQ.Rows.Count - 1
            'objDerived.GetValue("Select Supplier_id from dbo.Supplier where suppname='" & pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(i)("SuppName") & "'", CommandType.Text)
            ppq.item_ID = drpGenericName.SelectedItem.Value
            ppq.QtyPack = pTempPPQ.Rows(i)("QtyPack")
            ppq.Unit_Cost = pTempPPQ.Rows(i)("Unit_cost")
            ppq.PPQ_Percent = pTempPPQ.Rows(i)("PPQ_Percent")
            ppq.Selling_price = pTempPPQ.Rows(i)("Selling_price")
            ppq.save()
        Next
    End Sub
    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Session("Item_ID") = hdnItemNo.Value
        Session("paramRP") = txtReOrderPt.Text




        Dim url As String = "rpt_stockcard.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub

    Protected Sub btnMedicineAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Button1.Text <> "UPDATE" Then
            ' Server-Side Validation
            Dim qtyPack As Integer
            Dim unitCost As Decimal
            Dim percent As Decimal
            Dim sellingPrice As Decimal

            ' Validate QtyPack
            If String.IsNullOrWhiteSpace(txtQtyPack.Text) OrElse Not Integer.TryParse(txtQtyPack.Text, qtyPack) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid integer for Quantity Pack.")
                Exit Sub
            End If

            ' Validate UnitCost
            If String.IsNullOrWhiteSpace(txtUnitCost.Text) OrElse Not Decimal.TryParse(txtUnitCost.Text, unitCost) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Unit Cost.")
                Exit Sub
            End If

            ' Validate Percent
            If String.IsNullOrWhiteSpace(txtpercent.Text) OrElse Not Decimal.TryParse(txtpercent.Text, percent) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Percent.")
                Exit Sub
            End If

            ' Validate SellingPrice
            If String.IsNullOrWhiteSpace(txtSellingPrice1.Text) OrElse Not Decimal.TryParse(txtSellingPrice1.Text, sellingPrice) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Selling Price.")
                Exit Sub
            End If

            ' Assign Validated Values
            ppq.item_ID = drpGenericName.SelectedItem.Value
            ppq.QtyPack = qtyPack
            ppq.Unit_Cost = unitCost
            ppq.PPQ_Percent = percent
            ppq.Selling_price = sellingPrice
            ppq.save()

            ' Rebind GridPPQ
            pTempPPQ = objDerived.GetDataTable("Select * from ams.tbl_Price_per_qty where item_id ='" & drpGenericName.SelectedItem.Value & "'", CommandType.Text)
            GridPPQ.DataSource = pTempPPQ
            GridPPQ.DataBind()

        Else
            ' UPDATE logic with similar validation...
            ' Example for UPDATE case:
            ' Validate before updating
            Dim updatedQtyPack As Integer
            Dim updatedUnitCost As Decimal
            Dim updatedPercent As Decimal
            Dim updatedSellingPrice As Decimal

            If String.IsNullOrWhiteSpace(txtQtyPack.Text) OrElse Not Integer.TryParse(txtQtyPack.Text, updatedQtyPack) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid integer for Quantity Pack.")
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtUnitCost.Text) OrElse Not Decimal.TryParse(txtUnitCost.Text, updatedUnitCost) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Unit Cost.")
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtpercent.Text) OrElse Not Decimal.TryParse(txtpercent.Text, updatedPercent) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Percent.")
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtSellingPrice1.Text) OrElse Not Decimal.TryParse(txtSellingPrice1.Text, updatedSellingPrice) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid number for Selling Price.")
                Exit Sub
            End If

            ' Execute UPDATE command with validated values
            objDerived.Execute("UPDATE ams.tbl_price_per_qty SET QtyPack=" & updatedQtyPack & ", Unit_cost=" & updatedUnitCost & ", PPQ_percent=" & updatedPercent & ", Selling_Price=" & updatedSellingPrice & " WHERE PPQ_ID=" & GridPPQ.SelectedDataKey(0) & "", CommandType.Text)
            Button1.Text = "ADD"
            loadPPQ()
            GridPPQ.SelectedIndex = -1

            txtQtyPack.Text = ""
            txtUnitCost.Text = ""
            txtpercent.Text = ""
            txtSellingPrice1.Text = ""
        End If
    End Sub





    Protected Sub btnMedicineRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        objDerived.Execute("Delete from ams.tbl_price_per_qty where PPQ_ID=" & GridPPQ.SelectedDataKey(0) & "", CommandType.Text)
        loadPPQ()
        GridPPQ.SelectedIndex = -1

        txtQtyPack.Text = ""
        txtUnitCost.Text = ""
        txtpercent.Text = ""
        txtSellingPrice1.Text = ""
        Button2.Enabled = False

    End Sub

    Protected Sub btnROP_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub BtnCompute_Click(sender As Object, e As EventArgs)
        Try
            RP.Text = DRP.Text * LTD.Text
            ModalPopupExtender1.Show()
            txtReOrderPt.Text = DRP.Text * LTD.Text
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill Demand Per Day & Lead Time For Deliver.")

        End Try
    End Sub
    Protected Sub txtpercent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpercent.TextChanged
        Dim SellingPrice As Decimal

        Dim percent As Decimal
        If txtpercent.Text = "" Then
            percent = 0
        Else
            percent = txtpercent.Text
        End If

        Dim UnitCost As Decimal
        If txtUnitCost.Text = "" Then
            UnitCost = 0

        Else
            UnitCost = txtUnitCost.Text
        End If




        SellingPrice = (UnitCost * percent / 100 + UnitCost)
        txtSellingPrice1.Text = SellingPrice
    End Sub
    Protected Sub txtQtyPack_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQtyPack.TextChanged


        Dim SellingPrice As Decimal

        Dim percent As Decimal
        If txtpercent.Text = "" Then
            percent = 0
        Else
            percent = txtpercent.Text
        End If

        Dim UnitCost As Decimal
        If txtUnitCost.Text = "" Then
            UnitCost = 0

        Else
            UnitCost = txtUnitCost.Text
        End If




        SellingPrice = (UnitCost * percent / 100 + UnitCost)
        txtSellingPrice1.Text = SellingPrice
    End Sub
    Protected Sub txtUnitCost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnitCost.TextChanged
        Dim SellingPrice As Decimal

        Dim percent As Decimal
        If txtpercent.Text = "" Then
            percent = 0
        Else
            percent = txtpercent.Text
        End If

        Dim UnitCost As Decimal
        If txtUnitCost.Text = "" Then
            UnitCost = 0

        Else
            UnitCost = txtUnitCost.Text
        End If




        SellingPrice = (UnitCost * percent / 100 + UnitCost)
        txtSellingPrice1.Text = SellingPrice
    End Sub


    Protected Sub GridPPQ_SelectedIndexChanged(sender As Object, e As EventArgs)
        Button1.Text = "UPDATE"
        Button2.Enabled = True
        txtQtyPack.Text = GridPPQ.SelectedDataKey(2)
        txtUnitCost.Text = GridPPQ.SelectedDataKey(3)
        txtpercent.Text = GridPPQ.SelectedDataKey(4)
        txtSellingPrice1.Text = GridPPQ.SelectedDataKey(5)



    End Sub
    Protected Sub GridPPQ_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtPPQ As New DataTable

        dtPPQ = objDerived.GetDataTable("Select * from ams.tbl_Price_per_qty where item_id ='" & drpGenericName.SelectedItem.Value & "'", CommandType.Text)
        GridPPQ.PageIndex = e.NewPageIndex
        GridPPQ.DataSource = dtPPQ
        GridPPQ.DataBind()

    End Sub


    'PURELY FOR DISPLAYING AND CLEARING WHEN CHECKBOX EVENT IS FIRED
    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        txtMedicineUnitprice.Text = String.Empty
        txtMedicineBrandName.Text = String.Empty
        txtMedicineDose.Text = String.Empty
        txtSellPrice.Text = String.Empty
        txtReOrderPt.Text = String.Empty
        txtSellectDate.Text = String.Empty

        txtMedicineUnit.Text = String.Empty
        txtMedicineForm.Text = String.Empty
        txtMedicineOTXRX.Text = String.Empty
        txtBFADNo.Text = String.Empty
        txtItemCode.Text = String.Empty
        txtMedicineQuantity.Text = String.Empty
        txtMedicineDepValue.Text = String.Empty

        txtMedicineBatch1.Text = String.Empty
        txtMedicineLot.Text = String.Empty
        txtMedicineMdate.Text = String.Empty
        txtMedicineEdate.Text = String.Empty
        txtMedicineAlert.Text = String.Empty


        Dim dt As DataTable = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpGenericName.SelectedItem.Value & "'", CommandType.Text)

        Dim cb1 As CheckBox
        Dim x As Integer = 0

        For i As Integer = 0 To grdLedger.Rows.Count - 1
            cb1 = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

            If cb1.Visible AndAlso cb1.Checked Then
                x = 1

                btnMedicineSave.Enabled = True
                btnMedicineSave.Text = "EDIT"
            End If
        Next

        If x = 0 Then
            btnMedicineSave.Enabled = False
        End If


        If dt.Rows.Count > 0 Then


            For xa As Integer = 0 To grdLedger.Rows.Count - 1
                cb1 = CType(Me.grdLedger.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then
                    If dt.Rows.Count > 0 Then
                        txtMedicineUnitprice.Text = dt.Rows(xa).Item("cost").ToString()
                        txtSellectDate.Text = dt.Rows(xa).Item("dDate").ToString()
                        txtMedicineUnit.Text = dt.Rows(xa).Item("DebitUnit").ToString()

                        'SOME UNIT FROM STOCK TABLE FOR SOME REASON DONT EXIST IN LIST OF DROPDOWN UNIT
                        Dim unitValue As String = dt.Rows(xa).Item("DebitUnit").ToString()
                        drpUnit.SelectedItem.Text = unitValue

                        txtMedicineQuantity.Text = dt.Rows(xa).Item("DebitQty").ToString()

                        Dim dt2 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TBMedicine_Info AS a WHERE  (Item_ID = '" & drpGenericName.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                        If dt2.Rows.Count > 0 Then
                            txtMedicineBrandName.Text = dt2.Rows(0).Item("BrandName").ToString()
                            txtMedicineDose.Text = dt2.Rows(0).Item("Dose").ToString()
                            txtReOrderPt.Text = dt2.Rows(0).Item("reorderpt").ToString()
                            txtBFADNo.Text = dt2.Rows(0).Item("bfadno").ToString()
                            txtItemCode.Text = dt2.Rows(0).Item("itemcode").ToString()
                        End If

                        Dim dt3 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TBMedicine_DTl AS a WHERE  (Item_ID = '" & drpGenericName.SelectedItem.Value & "')  AND (StockId = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                        If dt3.Rows.Count > 0 Then
                            txtSellPrice.Text = dt3.Rows(0).Item("SellingPrice").ToString()
                            txtMedicineForm.Text = dt3.Rows(0).Item("Form").ToString()
                            txtMedicineOTXRX.Text = dt3.Rows(0).Item("OTCRx").ToString()
                            txtMedicineBatch1.Text = dt3.Rows(0).Item("Batch").ToString()
                            txtMedicineLot.Text = dt3.Rows(0).Item("Lot").ToString()
                            txtMedicineMdate.Text = dt3.Rows(0).Item("Mftgdate").ToString()
                            txtMedicineEdate.Text = dt3.Rows(0).Item("EpiryDate").ToString()
                            txtMedicineAlert.Text = dt3.Rows(0).Item("Alert").ToString()
                        End If

                        Dim dt4 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.Stock AS a WHERE  (Item_ID = '" & drpGenericName.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)
                        Dim dt5 As DataTable = objDerived.GetDataTable("SELECT TOP (1) wName FROM AMS.Loc_Warehouse AS a WHERE  (warehouse_ID = '" & dt4.Rows(0).Item("warehouse_ID").ToString() & "')  ", CommandType.Text)

                        If dt5.Rows.Count > 0 Then

                            Dim valueUnit As String = dt5.Rows(0).Item("wName").ToString()
                            drpMedicineWarehouse.SelectedItem.Text = valueUnit
                        End If


                    End If
                End If
            Next
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

    Protected Sub grdLedger_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdLedger.RowDataBound

        Dim dt As DataTable
        Dim cb1 As CheckBox

        dt = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpGenericName.SelectedValue & "'", CommandType.Text)


        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim maxCount As Integer = Math.Min(dt.Rows.Count, grdLedger.Rows.Count)

            For xa As Integer = 0 To maxCount - 1
                cb1 = CType(Me.grdLedger.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)

                Dim transType As String = dt.Rows(xa).Item("Trans_Type").ToString()
                Dim firstWord As String = transType.Split(" "c)(0)

                If transType = "Purchase Order Delivered" Or firstWord = "Issuance" Then
                    cb1.Enabled = False
                End If
            Next


        End If
    End Sub

End Class


