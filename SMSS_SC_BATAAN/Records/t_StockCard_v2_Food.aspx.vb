
Imports System.Data
Imports System.Drawing

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
        objx.GetAccessRight(Me.Session("@UserName"), Page)
        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If
        If Not Page.IsPostBack Then

            txtDate.Text = Date.Now.ToString("MM-dd-yyyy")
            btnPreview.Visible = False
            btnFoodSave.Text = "SAVE"

            Dim dtClassification As New DataTable
            dtClassification = objDerived.GetDataTable("select [ClassificationId],[ClassificationName] From [dbo].[tbl_Classification] where [ClassificationName] like 'Food'", CommandType.Text)
            Me.ddClass.DataSource = CType(dtClassification, DataTable)
            Me.ddClass.DataTextField = ("ClassificationName")
            Me.ddClass.DataValueField = ("ClassificationId")
            Me.ddClass.DataBind()
            'MultiviewSupplier()

            selectClassification()
            BindSubClassifications()

            AddTrace("ddClass:" & ddClass.SelectedValue)
            ddClass.AutoPostBack = True
            ddSubClass.AutoPostBack = True
            ddGlAccount.AutoPostBack = True

            BindGAAccountsFromSubClass()
            ledger()
            'selectitemdesc()

        End If


    End Sub



    ' Keep a copy to avoid requerying when GA needs the SubClass row
    Private Property SubClassTable As DataTable
        Get
            Return TryCast(ViewState("SubClassTable"), DataTable)
        End Get
        Set(value As DataTable)
            ViewState("SubClassTable") = value
        End Set
    End Property

    Private Sub BindSubClassifications()
        ' When Classification is not chosen, just provide a placeholder
        If String.IsNullOrWhiteSpace(ddClass.SelectedValue) Then
            ddSubClass.Items.Clear()
            ddSubClass.Items.Insert(0, New ListItem("Select", ""))
            SubClassTable = Nothing
            Exit Sub
        End If

        Dim sql As String =
        "SELECT SubClassificationID, SubClassificationName, ClassificationID, GA_ID " &
        "FROM dbo.tbl_SubClassification " &
        "WHERE ClassificationID = " & ddClass.SelectedValue & " " &
        "ORDER BY SubClassificationName;"

        Dim dt As DataTable = objDerived.GetDataTable(sql, CommandType.Text)

        ddSubClass.DataSource = dt
        ddSubClass.DataTextField = "SubClassificationName"
        ddSubClass.DataValueField = "SubClassificationID"
        ddSubClass.DataBind()
        ddSubClass.Items.Insert(0, New ListItem("Select", ""))

        SubClassTable = dt

        AddTrace(ddSubClass.SelectedValue)
    End Sub

    Private Sub BindGAAccountsFromSubClass()

        Dim dtGA1 As DataTable
        If ddSubClass.SelectedIndex = 0 Then
            ' Update the SQL query to join both tables and order by GA_Title
            Dim sql1 As String =
                "SELECT DISTINCT a.ga_id, b.GA_Title " &
                "FROM tblclassmatrix a " &
                "INNER JOIN geobos.dbo.view_allotmentclassaccounts b " &
                "ON a.ga_id = b.GA_ID " &
                "WHERE a.classificationid = " & ddClass.SelectedValue & " " &
                "ORDER BY b.GA_Title;"

            dtGA1 = objDerived.GetDataTable(sql1, CommandType.Text)
        Else

            Dim sql1 As String =
              "SELECT DISTINCT a.ga_id, b.GA_Title " &
              "FROM tblclassmatrix a " &
              "INNER JOIN geobos.dbo.view_allotmentclassaccounts b " &
              "ON a.ga_id = b.GA_ID " &
              "WHERE a.classificationid = " & ddClass.SelectedValue & " AND a.SubClassificationID = " & ddSubClass.SelectedValue & "  " &
              "ORDER BY b.GA_Title;"

            dtGA1 = objDerived.GetDataTable(sql1, CommandType.Text)
        End If


        ddGlAccount.DataSource = dtGA1
        ddGlAccount.DataTextField = "GA_Title"
        ddGlAccount.DataValueField = "GA_ID"
        ddGlAccount.DataBind()
        ddGlAccount.Items.Insert(0, New ListItem("Select", ""))


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

    End Function

    Protected Sub ddGlAccount_SelectedIndexChanged(sender As Object, e As EventArgs)
        SelectGAaccount()
    End Sub
    Public Function selectClassification()

        lblClass1.Text = ddClass.SelectedItem.Text
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
        ' Keep the old behavior: fill GA list for the whole Classification
        selectClassification()

        ' Now add SubClass list and, if selected later, it can override GA
        BindSubClassifications()

        ' Optional: if you want an immediate default, auto-pick first real SubClass and bind GA from it
        If ddSubClass.Items.Count > 1 AndAlso ddSubClass.SelectedIndex <= 0 Then
            ddSubClass.SelectedIndex = 1
            BindGAAccountsFromSubClass()

            ' Keep your downstream logic consistent
            SelectGAaccount()      ' fills ddCategory based on ddGlAccount
            ' loadStockOfficeSupplies() ' if you want to refresh grids immediately
            ' ledger()
        End If
    End Sub

    Protected Sub ddSubClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Rebind GA based on chosen SubClass (overrides the GA list from selectClassification)
        BindGAAccountsFromSubClass()

        ' Reuse your existing pipeline that depends on ddGlAccount
        SelectGAaccount()          ' fills ddCategory
        ' Optionally refresh downstream UI:
        ' loadStockOfficeSupplies()
        ' ledger()
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
    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Protected Sub loadStockOfficeSupplies()
        Dim CY As String
        CY = "CY" & Year(txtDate.Text)

        Dim dtStock As New DataTable

        Dim emptyddGlAccount As Integer
        If ddGlAccount.SelectedValue = "Select" Then
            emptyddGlAccount = 0
        End If
        AddTrace("ddGlAccount: " & ddGlAccount.SelectedValue)
        AddTrace("ddCategory: " & ddCategory.SelectedValue)
        AddTrace("ddSubCategory: " & ddSubCategory.SelectedValue)
        AddTrace("emptyddGlAccount: " & emptyddGlAccount)
        AddTrace("CY: " & CY)



        dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022] '" & ddGlAccount.SelectedValue & "','0','" & CY & "','" & ddCategory.SelectedValue & "','" & ddSubCategory.SelectedValue & "'", CommandType.Text)
        If dtStock.Rows.Count < 10 Then
            dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
        End If
        grdStockList.DataSource = dtStock
        grdStockList.DataBind()
        grdStockList.SelectedIndex = -1



        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_StockSupplies_Batches] '" & ddGlAccount.SelectedValue() & "','" & 0 & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatable2(3 - dtStock.Rows.Count))
        End If
        grdsupplies.DataSource = dtStock
        grdsupplies.DataBind()
        grdsupplies.SelectedIndex = -1
        MultiviewSupplier()
        loadCleartext()
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



        'optimize code
        ' define an array of control names to clear
        Dim controlNames() As String = {
    "txtItemDesc2", "txtBrandName2", "txtSize", "txtColor", "txtDepRate",
    "txtLenght", "txtWidth", "txtHeight", "txtWeight", "txtDepValue",
    "lnksuppliermed", "txtItemDesc2", "txtBrandName2",
    "txtDepRate", "txtDepValue",
    "txtEDate", "txtAlert", "txtUnitPrice", "txtQuantity",
    "txtBay", "txtColumn", "txtFloor", "txtRoom", "txtShelves", "txtRack", "txtBin",
    "txtFoodName", "txtFoodBrandName", "txtFoodUnitprice", "txtFoodQuantity",
    "txtFoodDepRate", "txtFoodDepValue", "txtFoodForm", "txtFoodBatch1",
    "txtFoodBatch", "txtFoodLot", "txtFoodMdate", "txtFoodEdate", "txtFoodAlert",
    "txtFoodBay", "txtFoodColumn", "txtFoodFloor", "txtFoodRoom",
    "txtFoodShelves", "txtFoodRack", "txtFoodBin"
}

        ' clear the values of all controls in the array
        For Each controlName As String In controlNames
            Dim control As Control = Me.FindControl(controlName)
            If TypeOf control Is TextBox Then
                CType(control, TextBox).Text = ""
            ElseIf TypeOf control Is HyperLink Then
                CType(control, HyperLink).Text = ""
            End If
        Next


    End Sub
    Public Sub loadwarehouse()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("select warehouse_id,wname From ams.loc_warehouse", CommandType.Text)
        drpFoodWarehouse.DataTextField = ("wname")
        drpFoodWarehouse.DataValueField = ("warehouse_id")
        drpFoodWarehouse.DataSource = dt
        drpFoodWarehouse.DataBind()



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

                dt = objDerived.GetDataTable("EXEC [dbo].[GetFoodItemDetails] " & grdStockList.SelectedDataKey("Item_ID") & " ", CommandType.Text)
                txtFoodName.Text = dt.Rows(0).Item(0)
                txtFoodName.ReadOnly = False

                txtFoodBrandName.Text = dt.Rows(0).Item(1)
                txtFoodBrandName.ReadOnly = False

                txtFoodUnitprice.Text = dt.Rows(0).Item(2)
                txtFoodUnitprice.ReadOnly = False


                txtFoodQuantity.Text = dt.Rows(0).Item(3)
                txtFoodQuantity.ReadOnly = False



                txtFoodDepRate.Text = dt.Rows(0).Item(4)
                txtFoodDepRate.ReadOnly = False


                txtFoodDepValue.Text = dt.Rows(0).Item(5)
                txtFoodDepValue.ReadOnly = False


                txtFoodForm.Text = dt.Rows(0).Item(6)
                txtFoodForm.ReadOnly = False


                txtFoodBatch1.Text = dt.Rows(0).Item(7)
                txtFoodBatch1.ReadOnly = False


                txtFoodBatch.Text = dt.Rows(0).Item(7)
                txtFoodBatch.ReadOnly = False


                txtFoodLot.Text = dt.Rows(0).Item(8)
                txtFoodLot.ReadOnly = False


                txtFoodMdate.Text = dt.Rows(0).Item(9)
                txtFoodMdate.ReadOnly = False


                txtFoodEdate.Text = dt.Rows(0).Item(10)
                txtFoodEdate.ReadOnly = False


                txtFoodAlert.Text = dt.Rows(0).Item(11)
                txtFoodAlert.ReadOnly = False




                '''--------------------location
                Dim location As String
                location = dt.Rows(0).Item(12)
                Dim locationsplit As String() = location.Split("-")
                If location.Contains("Bay") Then
                    txtFoodBay.Text = locationsplit(1)
                ElseIf location.Contains("Column") Then
                    txtFoodColumn.Text = locationsplit(1)
                ElseIf location.Contains("Floor") Then
                    txtFoodFloor.Text = locationsplit(1)
                ElseIf location.Contains("Room") Then
                    txtFoodRoom.Text = locationsplit(1)
                ElseIf location.Contains("Shelves") Then
                    txtFoodShelves.Text = locationsplit(1)
                ElseIf location.Contains("Rack") Then
                    txtFoodRack.Text = locationsplit(1)
                ElseIf location.Contains("Bin") Then
                    txtFoodBin.Text = locationsplit(1)
                End If

                Dim warehouse As String
                warehouse = dt.Rows(0).Item(13)
                drpFoodWarehouse.SelectedValue = warehouse

                btnFoodSave.Enabled = False
                btnFoodSave.Enabled = False
            Else
                Dim dt As New DataTable
                Dim obj As New BaseClasses.Items
                txtFoodName.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                txtFoodName.ReadOnly = False

                txtFoodBrandName.Text = obj.GetValue("select Brand From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                txtFoodBrandName.ReadOnly = False
                txtFoodBatch.ReadOnly = False
                txtFoodDose.ReadOnly = False
                txtFoodBatch1.ReadOnly = False

                txtFoodForm.ReadOnly = False
                txtFoodUnitprice.Text = obj.GetValue("select " & CY & " From dbo.m_item_detail where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

                txtFoodUnitprice.ReadOnly = False
                txtFoodLot.ReadOnly = False
                txtFoodQuantity.ReadOnly = False

                txtFoodMdate.ReadOnly = False
                txtFoodDepRate.ReadOnly = False
                txtFoodEdate.ReadOnly = False
                txtFoodDepValue.ReadOnly = False
                txtFoodAlert.ReadOnly = False
                btnFoodSave.Enabled = True
                btnFoodSave.Enabled = True


            End If

            ledger()
        End If




    End Sub

    Protected Sub ledger()


        Dim dtStock As New DataTable
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

        txtSearchStock.Text = ""
        lblHistoryDetails.Text = "DETAILS"

        Dim dtitemdesc As New DataTable
        dtitemdesc = objDerived.GetDataTable(" SELECT a.Item_ID, a.ItemCompleteDesc FROM dbo.m_item AS a INNER JOIN ams.item_particular AS c ON a.item_particular_id = c.item_particular_id LEFT OUTER JOIN dbo.m_item_detail AS b ON a.Item_ID = b.Item_ID LEFT OUTER JOIN dbo.tblclassmatrix AS d ON a.Item_ID = d.Item_ID WHERE a.ClassificationID = " & ddClass.SelectedValue() & " AND d.ga_id = " & ddGlAccount.SelectedValue() & " ORDER BY a.Item_Desc", CommandType.Text)
        drpFoodName.DataSource = dtitemdesc
        drpFoodName.DataTextField = ("ItemCompleteDesc")
        drpFoodName.DataValueField = ("Item_ID")
        drpFoodName.DataBind()
        drpFoodName.Enabled = True
        selectitemdesc()

        Me.MultiView1.SetActiveView(Me.View1)
        'imgmedical.ImageUrl = "~/images/blankImage.jpg"
        'LoadSupplies()
    End Sub

    Protected Sub ddSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        MultiviewSupplier()
        loadStockOfficeSupplies()

    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        If txtFoodName.Text = "" Or txtFoodBrandName.Text = "" Or txtFoodUnitprice.Text = "" Or txtFoodQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")

            If String.IsNullOrEmpty(hdnItemNo.Value) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Item ID. Please select a valid item.")
                Exit Sub
            End If

            Dim unitId As Integer
            If Not Integer.TryParse(drpUnit.SelectedItem.Value, unitId) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Unit ID.")
                Exit Sub
            End If

            Dim itemId As Integer
            If Not Integer.TryParse(hdnItemNo.Value, itemId) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Item ID.")
                Exit Sub
            End If



        Else

            If String.IsNullOrEmpty(hdnItemNo.Value) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Item ID. Please select a valid item.")
                Exit Sub
            End If

            Dim unitId As Integer
            If Not Integer.TryParse(drpUnit.SelectedItem.Value, unitId) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Unit ID.")
                Exit Sub
            End If

            Dim itemId As Integer
            If Not Integer.TryParse(hdnItemNo.Value, itemId) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Item ID.")
                Exit Sub
            End If




            Dim rcv As New Receiving.t_receiving
            With rcv
                .Received_Date = txtDate.Text
                .ReceivedBY = 0
                .POHdr_ID = 0
                .PO_No = ""
                .Supplier_ID = 0
                .GA_ID = hdnGAId.Value
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


            'Optimize code
            Select Case True
                Case Not String.IsNullOrEmpty(txtBay.Text)
                    location = "Bay-" & txtBay.Text
                Case Not String.IsNullOrEmpty(txtColumn.Text)
                    location = "Column-" & txtColumn.Text
                Case Not String.IsNullOrEmpty(txtFloor.Text)
                    location = "Floor-" & txtFloor.Text
                Case Not String.IsNullOrEmpty(txtRoom.Text)
                    location = "Room-" & txtRoom.Text
                Case Not String.IsNullOrEmpty(txtShelves.Text)
                    location = "Shelves-" & txtShelves.Text
                Case Not String.IsNullOrEmpty(txtRack.Text)
                    location = "Rack-" & txtRack.Text
                Case Not String.IsNullOrEmpty(txtBin.Text)
                    location = "Bin-" & txtBin.Text
            End Select


            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = hdnItemNo.Value
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
            Dim objhdr As New t_inspection_and_acceptance_hdr
            Dim airhdr_id As Long
            Dim air As String
            air = objDerived.GetValue("select [AMS].[func_GenerateAIR]('" & txtDate.Text & "')", CommandType.Text)
            With objhdr
                .AIR_No = air
                .AIR_Date = ValidateDateInput(txtDate.Text, DateTime.Now)
                .Date_Received = ValidateDateInput(txtDate.Text, DateTime.Now)
                .Date_Inspect = ValidateDateInput(txtDate.Text, DateTime.Now)
                .Date_Accepted = ValidateDateInput(txtDate.Text, DateTime.Now)
                .Invoice_No = " "
                .Invoice_date = ValidateDateInput(txtDate.Text, DateTime.Now)
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
            '=-= AIR DETAILS
            Dim txtPriceair As TextBox = CType(txtUnitPrice, TextBox)
            Dim txtqtyair As TextBox = CType(txtQuantity, TextBox)

            objdtl.Item_ID = hdnItemNo.Value
            objdtl.Qty = txtqtyair.Text
            objdtl.Cost = CType(txtPriceair.Text, Decimal)
            objdtl.AIRHdr_ID = Session("AIRHDR_ID")
            objdtl.GA_ID = hdnGAId.Value
            Dim iaDtl_ID As Integer = objdtl.save()
            Session("AIRDtl_ID") = iaDtl_ID

            Dim objStock As New Supplies_Stock

            '=-= SAVE STOCK
            With objStock
                '.StockID = StockID
                .StockDate = ValidateDateInput(txtDate.Text, DateTime.Now)
                .Item_ID = hdnItemNo.Value
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
                .GA_ID = hdnGAId.Value
                .Warehouseid = drpWarehouse.SelectedValue()
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
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .ReceivedBy = ""
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .dDate = If(String.IsNullOrWhiteSpace(txtSellectDate.Text), DateTime.Now, DateTime.Parse(txtSellectDate.Text))
                .Item_ID = hdnItemNo.Value
                .DebitQty = txtqtyair.Text
                .DebitCost = FormatNumber(CType(txtPriceair.Text, Decimal) * txtqtyair.Text, 2)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceQty = 0
                .BalanceCost = 0
                .save()
            End With
            Dim objOfficeSup As New SupplieINFO
            With objOfficeSup
                '.SuppliesId = SuppliesId
                .StockID = StockID
                .AIRDtl_ID = Session("AIRDtl_ID")
                .ItemId = hdnItemNo.Value
                .Description = txtItemDesc2.Text
                .BrandName = txtBrandName2.Text
                .SupplierId = 0
                .Size = txtSize.Text
                .Color = txtColor.Text
                .Category = ddCategory.SelectedItem.Text
                .Length = txtLenght.Text
                .Width = txtWidth.Text
                .Height = txtHeight.Text
                .Weight = txtWeight.Text
                .DepreciatedValue = txtDepRate.Text
                .DepreciatedRate = txtDepValue.Text
                .Status = "Accepted"
                .Componentof = txtComponentof.Text
            End With

            Dim Supp_ID As Long = objOfficeSup.save
            objDerived.GetRecords("UPDATE AMS.TBSupplies_Info SET Received_ID = '" & rcvID & "' WHERE SuppliesId = '" & Supp_ID & "'", CommandType.Text)
            Dim dtStock As New DataTable
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
            If dtStock.Rows.Count < 4 Then
                dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
            End If
            grdLedger.DataSource = dtStock
            grdLedger.DataBind()
            'loadCleartext()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")
            selectitemdesc()
            ledger()

        End If


    End Sub
    Public Sub updateFood()
        If txtFoodBrandName.Text = "" Or txtFoodUnitprice.Text = "" Or txtFoodQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")


        Else

            objDerived.Execute("UPDATE dbo.m_item SET unit_id = " & drpUnit.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)
            ''02142023
            Dim locations As String

            If txtFoodBay.Text <> "" Then
                locations = "Bay-" & txtFoodBay.Text
            End If

            If txtFoodColumn.Text <> "" Then
                locations = locations + " " + "Column-" & txtFoodColumn.Text
            End If

            If txtFoodFloor.Text <> "" Then
                locations = locations + " " + "Floor-" & txtFoodFloor.Text
            End If

            If txtFoodRoom.Text <> "" Then
                locations = locations + " " + "Room-" & txtFoodRoom.Text
            End If

            If txtFoodShelves.Text <> "" Then
                locations = locations + " " + "Shelves-" & txtFoodShelves.Text
            End If

            If txtFoodRack.Text <> "" Then
                locations = locations + " " + "Rack-" & txtFoodRack.Text
            End If

            If txtFoodBin.Text <> "" Then
                locations = locations + " " + "Bin-" & txtFoodBin.Text
            End If


            Dim t1 As Decimal
            Dim total As Decimal = 0

            t1 = txtFoodQuantity.Text * txtFoodUnitprice.Text
            total = total + t1
            Session("ContractPrice") = total


            ''----Update Receiving
            'objDerived.GetRecords("UPDATE [AMS].[Tb_Receiving_Dtl] " +
            '                    " SET [PO_Qty] = '" & txtFoodQuantity.Text & "' " +
            '                    " ,[Qty_Received] = '" & txtFoodQuantity.Text & "' " +
            '                    " ,[Cost] = '" & txtFoodUnitprice.Text & "' " +
            '                    " ,[Location] = '" & locations & "' " +
            '                    " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)

            ''----Update PO_dtl
            'objDerived.GetRecords("UPDATE [AMS].[PO_Dtl] " +
            '                        " SET [qty] = '" & txtFoodQuantity.Text & "' " +
            '                        " ,[cost] = '" & txtFoodUnitprice.Text & "' " +
            '                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)


            ''----Update AIR_Dtl
            'objDerived.GetRecords("UPDATE [AMS].[AIR_Dtl] " +
            '                        " SET [Qty] = '" & txtFoodQuantity.Text & "' " +
            '                        " ,[Cost] = '" & txtFoodUnitprice.Text & "' " +
            '                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)

            '----Update STOCK


            Dim dt As DataTable = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpFoodName.SelectedItem.Value & "'", CommandType.Text)

            'CHECK IF MULTI UPDATING; IF CHECKBOX HAVE FIRING EVENTS
            For i As Integer = 0 To grdLedger.Rows.Count - 1
                Dim cb1 As CheckBox = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then

                    If dt.Rows.Count > 0 Then
                        Dim stockID As String = dt.Rows(i).Item("StockID").ToString()


                        objDerived.GetRecords("UPDATE [AMS].[stock] " +
                                        " SET [Qty] = '" & txtFoodQuantity.Text & "' " +
                                        " ,[Balance] = '" & txtFoodQuantity.Text & "' " +
                                        " ,[Cost] = '" & txtFoodUnitprice.Text & "' " +
                                        " ,[Location] = '" & locations & "' " +
                                        " ,[warehouse_ID] = '" & drpFoodWarehouse.SelectedValue() & "' " +
                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "'  ", CommandType.Text)

                        '----Update stockledger
                        Dim qty As Decimal
                        Dim unitPrice As Decimal

                        ' Check if the values are numeric and convert them
                        If IsNumeric(txtFoodQuantity.Text) AndAlso IsNumeric(txtFoodUnitprice.Text) Then
                            qty = CDec(txtFoodQuantity.Text)
                            unitPrice = CDec(txtFoodUnitprice.Text)

                            ' Proceed with the SQL query
                            objDerived.GetRecords("UPDATE [AMS].[TbStock_Ledger] " +
                                                " SET DebitUnit = '" & drpUnit.SelectedItem.Text & "', " &
                                                " [DebitQty] = '" & qty & "', " &
                                                " [DebitCost] = '" & (qty * unitPrice) & "', " &
                                                " BalanceUnit = '" & drpUnit.SelectedItem.Text & "', " &
                                                " BalanceCost = (SELECT TOP 1 BalanceCost FROM AMS.TbStock_Ledger WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "' ORDER BY StockLedger_ID DESC) + (" & (qty * unitPrice) & ") " &
                                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "'", CommandType.Text)
                        Else
                            ' Handle the case where the input is not valid (e.g., show an error message); well for now its useless so do nothing i guess
                        End If


                        '----Update suppliesinfo
                        objDerived.GetRecords("UPDATE [AMS].[TbFood] " +
                                                    " SET [Form] = '" & txtFoodForm.Text & "' " +
                                                    " ,[Mftgdate] = '" & txtFoodMdate.Text & "' " +
                                                    " ,[Batch] = '" & txtFoodBatch.Text & "' " +
                                                    " ,[Lot] = '" & txtFoodLot.Text & "' " +
                                                    " ,[EpiryDate] = '" & txtFoodEdate.Text & "' " +
                                                    " ,[Alert] = '" & txtFoodAlert.Text & "' " +
                                                    " ,[ItemDesc] = '" & txtFoodName.Text & "' " +
                                                    " ,[BrandName] = '" & txtFoodBrandName.Text & "' " +
                                            " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockId = '" & stockID & "' ", CommandType.Text)

                    End If
                End If
            Next


            'objDerived.Execute("EXEC sp_UpdateBalancefromLedger " & hdnItemNo.Value, CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer = txtFoodQuantity.Text
            If a >= c Then
                ModalPopupExtender3.Show()
            End If
            selectitemdesc()
            ledger()

        End If


    End Sub

    Public Function ValidateDateInput(dateInput As String, defaultDate As DateTime) As DateTime
        Dim parsedDate As DateTime
        If Not DateTime.TryParse(dateInput, parsedDate) Then
            Return defaultDate ' Use a default value like DateTime.Now
        End If
        Return parsedDate
    End Function

    Public Sub saveFood()


        If txtFoodBrandName.Text = "" Or txtFoodUnitprice.Text = "" Or txtFoodQuantity.Text = "" Or txtFoodMdate.Text = "" Or txtFoodEdate.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity / Mftg Info")
            If String.IsNullOrEmpty(hdnItemNo.Value) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Item ID. Please select a valid item.")
                Exit Sub
            End If

            Dim unitId As Integer
            If Not Integer.TryParse(drpUnit.SelectedItem.Value, unitId) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Unit ID.")
                Exit Sub
            End If

            Dim itemId As Integer
            If Not Integer.TryParse(hdnItemNo.Value, itemId) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Item ID.")
                Exit Sub
            End If

        Else

            If String.IsNullOrEmpty(hdnItemNo.Value) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Item ID. Please select a valid item.")
                Exit Sub
            End If

            Dim unitId As Integer
            If Not Integer.TryParse(drpUnit.SelectedItem.Value, unitId) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Unit ID.")
                Exit Sub
            End If

            Dim itemId As Integer
            If Not Integer.TryParse(hdnItemNo.Value, itemId) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Item ID.")
                Exit Sub
            End If


            objDerived.Execute("Update dbo.m_item set unit_id = " & drpUnit.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)

            Dim rcv As New Receiving.t_receiving
            With rcv
                .Received_Date = txtDate.Text
                .ReceivedBY = 0
                .POHdr_ID = 0
                .PO_No = ""
                .Supplier_ID = 0
                .GA_ID = hdnGAId.Value
                .isAccepted = False
                .UserID = Session("@UserName")
            End With
            Dim rcvID As Long = rcv.save

            Session("Received_ID") = rcvID
            Dim rcv_dtl As New Receiving.t_receiving_dtl
            Dim total As Decimal = 0
            Dim txtPrice As TextBox = CType(txtFoodUnitprice, TextBox)
            Dim txtqty As TextBox = CType(txtFoodQuantity, TextBox)
            Dim location As String


            'Optimize code
            Select Case True
                Case Not String.IsNullOrEmpty(txtBay.Text)
                    location = "Bay-" & txtBay.Text
                Case Not String.IsNullOrEmpty(txtColumn.Text)
                    location = "Column-" & txtColumn.Text
                Case Not String.IsNullOrEmpty(txtFloor.Text)
                    location = "Floor-" & txtFloor.Text
                Case Not String.IsNullOrEmpty(txtRoom.Text)
                    location = "Room-" & txtRoom.Text
                Case Not String.IsNullOrEmpty(txtShelves.Text)
                    location = "Shelves-" & txtShelves.Text
                Case Not String.IsNullOrEmpty(txtRack.Text)
                    location = "Rack-" & txtRack.Text
                Case Not String.IsNullOrEmpty(txtBin.Text)
                    location = "Bin-" & txtBin.Text
            End Select

            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = hdnItemNo.Value
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
            Dim objhdr As New t_inspection_and_acceptance_hdr
            Dim airhdr_id As Long
            Dim air As String
            air = objDerived.GetValue("select [AMS].[func_GenerateAIR]('" & txtDate.Text & "')", CommandType.Text)
            With objhdr
                .AIR_No = air
                .AIR_Date = ValidateDateInput(txtDate.Text, DateTime.Now)
                .Date_Received = ValidateDateInput(txtDate.Text, DateTime.Now)
                .Date_Inspect = ValidateDateInput(txtDate.Text, DateTime.Now)
                .Date_Accepted = ValidateDateInput(txtDate.Text, DateTime.Now)
                .Invoice_No = " "
                .Invoice_date = ValidateDateInput(txtDate.Text, DateTime.Now)
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
            '=-= AIR DETAILS
            Dim txtPriceair As TextBox = CType(txtFoodUnitprice, TextBox)
            Dim txtqtyair As TextBox = CType(txtFoodQuantity, TextBox)

            objdtl.Item_ID = hdnItemNo.Value
            objdtl.Qty = txtqtyair.Text
            objdtl.Cost = CType(txtPriceair.Text, Decimal)
            objdtl.AIRHdr_ID = Session("AIRHDR_ID")
            objdtl.GA_ID = hdnGAId.Value
            Dim iaDtl_ID As Integer = objdtl.save()
            Session("AIRDtl_ID") = iaDtl_ID

            Dim objStock As New Supplies_Stock

            '=-= SAVE STOCK
            With objStock
                '.StockID = StockID
                .StockDate = ValidateDateInput(txtDate.Text, DateTime.Now)
                .Item_ID = hdnItemNo.Value
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
                .GA_ID = hdnGAId.Value
                .Warehouseid = drpFoodWarehouse.SelectedValue()
                .ReorderPt = IIf(IsNumeric(txtFoodReOrderPt.Text), txtFoodReOrderPt.Text, 0)


                Dim locations As String

                If txtFoodBay.Text <> "" Then
                    locations = "Bay-" & txtFoodBay.Text
                End If

                If txtFoodColumn.Text <> "" Then
                    locations = locations + " " + "Column-" & txtFoodColumn.Text
                End If

                If txtFoodFloor.Text <> "" Then
                    locations = locations + " " + "Floor-" & txtFoodFloor.Text
                End If

                If txtFoodRoom.Text <> "" Then
                    locations = locations + " " + "Room-" & txtFoodRoom.Text
                End If

                If txtFoodShelves.Text <> "" Then
                    locations = locations + " " + "Shelves-" & txtFoodShelves.Text
                End If

                If txtFoodRack.Text <> "" Then
                    locations = locations + " " + "Rack-" & txtFoodRack.Text
                End If

                If txtFoodBin.Text <> "" Then
                    locations = locations + " " + "Bin-" & txtFoodBin.Text
                End If
                .Location = locations
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
                .dDate = If(String.IsNullOrWhiteSpace(txtSellectDate.Text), DateTime.Now, DateTime.Parse(txtSellectDate.Text))
                .Item_ID = hdnItemNo.Value
                .DebitQty = txtqtyair.Text
                .DebitCost = FormatNumber(CType(txtPriceair.Text, Decimal) * txtqtyair.Text, 2)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceQty = 0
                .BalanceCost = 0
                .save()
            End With
            ' Dim objOfficeSup As New SupplieINFO
            Dim objFood As New ConsolidatedMedicineSaving.TbFood
            With objFood
                '.Food_ID = Food_ID
                .StockId = StockID
                .AIRDtl_ID = Session("AIRDtl_ID")
                .Item_ID = hdnItemNo.Value
                .ActualPrice = txtFoodUnitprice.Text
                .ItemDesc = txtFoodName.Text
                .BrandName = txtFoodBrandName.Text
                .Supplier_Id = 0
                .Form = txtFoodForm.Text
                .OTCRx = ""
                .Batch = txtFoodBatch.Text
                .Lot = txtFoodLot.Text
                .Storage = ""
                .Status = "Accepted"
                .DeliveryDate = txtDate.Text
                .Mftgdate = txtFoodMdate.Text
                .EpiryDate = txtFoodEdate.Text
                .Alert = If(String.IsNullOrWhiteSpace(txtFoodAlert.Text), DateTime.Now, DateTime.Parse(txtFoodAlert.Text))

                .Depreciationrate = txtFoodDepRate.Text
                Dim depvalue As Decimal
                If txtFoodDepValue.Text = "" Then
                    depvalue = 0.00
                Else
                    depvalue = txtFoodDepValue.Text
                End If
                .Depreciationvalue = depvalue
            End With

            Dim FoodID As Long = objFood.save
            objDerived.GetRecords("UPDATE AMS.TbFood SET Received_ID = '" & rcvID & "' WHERE Food_ID = '" & FoodID & "'", CommandType.Text)

            Dim dtStock As New DataTable
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
            If dtStock.Rows.Count < 4 Then
                dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
            End If
            grdLedger.DataSource = dtStock
            grdLedger.DataBind()
            'loadCleartext()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")
            Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer = txtFoodQuantity.Text
            If a >= c Then
                ModalPopupExtender3.Show()
            End If
            ' loadStockOfficeSupplies()
            selectitemdesc()
        End If

    End Sub
    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else

            Dim obj As New BaseClasses.Items

            ' define an array of control names to make read-write
            Dim controlNames() As String = {
                "txtFoodName", "txtFoodBrandName", "txtFoodBatch", "txtFoodDose", "txtFoodBatch1",
                "txtFoodForm", "txtFoodUnitprice", "txtFoodLot", "txtFoodQuantity", "txtFoodMdate",
                "txtFoodDepRate", "txtFoodEdate", "txtFoodDepValue", "txtFoodAlert", "txtFoodBay",
                "txtFoodColumn", "txtFoodFloor", "txtFoodRoom", "txtFoodShelves", "txtFoodRack",
                "txtFoodBin"
            }

            ' loop through the controls and make them read-write
            For Each controlName As String In controlNames
                Dim control As Control = Me.FindControl(controlName)
                If TypeOf control Is TextBox Then
                    CType(control, TextBox).ReadOnly = False
                End If
            Next

            CalendarExtender4.Enabled = True
            CalendarExtender5.Enabled = True
            CalendarExtender6.Enabled = True
            btnFoodSave.Text = "UPDATE"
            btnCancel.Enabled = True
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fields are now open for editing")
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
    Protected Sub btnAuthCancel_Click(sender As Object, e As EventArgs)
        ModalPopupExtender2.Hide()

    End Sub
    Protected Sub btnFoodSave_Click(sender As Object, e As EventArgs)
        If btnFoodSave.Text = "SAVE" Then
            saveFood()
        ElseIf btnFoodSave.Text = "EDIT" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()

            ModalPopupExtender2.Show()
        Else
            updateFood()
            btnFoodSave.Text = "EDIT"
        End If
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim a As Integer = objDerived.GetValue("Select item_ID from dbo.m_item where item_desc ='" & drpFoodName.SelectedItem.Text & "'", CommandType.Text)
        'Session("Item_ID") = grdStocklist.SelectedDataKey("Item_ID")
        Session("Item_ID") = a
        Me.Page.Response.Redirect("~/Records/rpt_stockcard.aspx")
    End Sub

    Protected Sub drpFoodName_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectitemdesc()
    End Sub

    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpUnit.DataSource = dt
        drpUnit.DataTextField = ("Description")
        drpUnit.DataValueField = ("Unit_ID")
        drpUnit.DataBind()

    End Sub
    Public Sub selectitemdesc()

        Dim CY As String = "CY" & Year(txtDate.Text)
        Dim dtitemdetails As New DataTable
        loadUnit()
        If drpFoodName.SelectedValue = "" Then
            dtitemdetails = objDerived.GetDataTable("select a.Item_ID,Item_Desc,isnull(brand,''),isnull(color,''),isnull(size,''),isnull(" & CY & ",0.00) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID IS null", CommandType.Text)
        Else
            dtitemdetails = objDerived.GetDataTable("select a.Item_ID,Item_Desc,isnull(brand,''),isnull(color,''),isnull(size,''),isnull(" & CY & ",0.00),Unit_ID  from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & drpFoodName.SelectedValue, CommandType.Text)

        End If
        If dtitemdetails.Rows.Count > 0 Then
            hdnItemNo.Value = dtitemdetails.Rows(0).Item(0)
            txtFoodBrandName.Text = dtitemdetails.Rows(0).Item(2)
            txtColor.Text = dtitemdetails.Rows(0).Item(3)
            txtSize.Text = dtitemdetails.Rows(0).Item(4)
            txtUnitPrice.Text = dtitemdetails.Rows(0).Item(4)
            drpUnit.Items.FindByValue(dtitemdetails.Rows(0).Item(6)).Selected = True
        End If

        LoadStockGridBatches_From_dropdown()
    End Sub
    Public Sub LoadStockGridBatches_From_dropdown()
        Dim CY As String = "CY" & Year(txtDate.Text)

        Dim itemid As String
        If hdnItemNo.Value = "" Then
            itemid = "0"
        Else
            itemid = hdnItemNo.Value
        End If

        loadCleartext()
        loadwarehouse()
        hdnGAId.Value = objDerived.GetValue("select TOP 1 GA_ID From LnkdSrvrBOSS.GEOBOS.BOS.m_GenAccnt   where GA_title  Like '%Food Supplies Expenses%' order by GA_ID desc", CommandType.Text)
        'objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & itemid, CommandType.Text)


        Dim dt As New DataTable

        'dt = objDerived.GetDataTable("select a.ItemDesc ,a.BrandName,b.Cost,convert(int,b.Qty) ,a.Depreciationrate,a.Depreciationvalue , a.Form , a.Batch , a.Lot , a.Mftgdate, a.EpiryDate,a.Alert ,isnull(b.Location,' - '),case when (isnull(b.warehouse_id,1)) = 0  then 1 else isnull(b.warehouse_id,1) end , b.ReorderPt  From [AMS].[TbFood] as a inner join ams.Stock as b on a.StockID = b.StockID  where a.Item_ID =" & itemid, CommandType.Text)
        dt = objDerived.GetDataTable("EXEC GetFoodStockInfo " & itemid & "", CommandType.Text)

        If dt.Rows.Count > 0 Then

            '=========================NOW ENABLES TEXTBOXES===================
            Dim readWriteControls() As TextBox = {
            txtFoodBrandName, txtFoodBatch, txtFoodForm, txtFoodUnitprice, txtFoodLot,
            txtFoodQuantity, txtFoodMdate, txtFoodDepRate, txtFoodEdate, txtFoodDepValue,
            txtFoodAlert, txtFoodBay, txtFoodColumn, txtFoodFloor, txtFoodRoom, txtFoodShelves,
            txtFoodRack, txtFoodBin
        }
            ' loop through the read-write controls and set their ReadOnly property to False
            For Each control As TextBox In readWriteControls
                control.ReadOnly = False
            Next

            'Refactored Location
            '''--------------------location (robust)
            Dim locationRaw As String = If(dt.Rows(0).IsNull(12), "", CStr(dt.Rows(0).Item(12))).Trim()

            ' Build a map like { "Bay" -> "3", "Room" -> "1", ... } from tokens such as "Bay-3"
            Dim tokens As String() = locationRaw.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
            Dim locMap As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

            For Each t In tokens
                Dim kv() As String = t.Split("-"c)
                If kv.Length >= 2 Then
                    Dim key As String = kv(0).Trim()
                    ' In case value itself contains '-', join the rest back
                    Dim value As String = String.Join("-", kv.Skip(1)).Trim()
                    If key <> "" AndAlso value <> "" Then
                        locMap(key) = value
                    End If
                End If
            Next

            Dim val As String = Nothing
            txtFoodBay.Text = If(locMap.TryGetValue("Bay", val), val, "")
            txtFoodColumn.Text = If(locMap.TryGetValue("Column", val), val, "")
            txtFoodFloor.Text = If(locMap.TryGetValue("Floor", val), val, "")
            txtFoodRoom.Text = If(locMap.TryGetValue("Room", val), val, "")
            txtFoodShelves.Text = If(locMap.TryGetValue("Shelves", val), val, "")
            txtFoodRack.Text = If(locMap.TryGetValue("Rack", val), val, "")
            txtFoodBin.Text = If(locMap.TryGetValue("Bin", val), val, "")




            ''''--------------------location
            'Dim location As String
            'location = dt.Rows(0).Item(12)
            'Dim locationsplit As String() = location.Split(" ")


            '' Dim locationsplit As String() = location.Split(" ")
            'If location.Contains("Bay") Then
            '    Dim a As String = locationsplit(0)
            '    Dim a1 As String() = a.Split("-")
            '    txtFoodBay.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtFoodBay.Text = ""
            'End If
            'If location.Contains("Column") Then
            '    Dim a As String = locationsplit(1)
            '    Dim a1 As String() = a.Split("-")
            '    txtFoodColumn.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtFoodColumn.Text = ""
            'End If
            'If location.Contains("Floor") Then
            '    Dim a As String = locationsplit(2)
            '    Dim a1 As String() = a.Split("-")
            '    txtFoodFloor.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtFoodFloor.Text = ""
            'End If
            'If location.Contains("Room") Then
            '    Dim a As String = locationsplit(3)
            '    Dim a1 As String() = a.Split("-")
            '    txtFoodRoom.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtFoodRoom.Text = ""
            'End If
            'If location.Contains("Shelves") Then
            '    Dim a As String = locationsplit(4)
            '    Dim a1 As String() = a.Split("-")
            '    txtFoodShelves.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtFoodShelves.Text = ""
            'End If
            'If location.Contains("Rack") Then

            '    Dim a As String = locationsplit(5)
            '    Dim a1 As String() = a.Split("-")
            '    txtFoodRack.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtFoodRack.Text = ""
            'End If
            'If location.Contains("Bin") Then
            '    Dim a As String = locationsplit(6)
            '    Dim a1 As String() = a.Split("-")
            '    txtFoodBin.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtFoodBin.Text = ""
            'End If


            Dim warehouse As String
            warehouse = dt.Rows(0).Item(13)
            drpFoodWarehouse.SelectedValue = warehouse

            CalendarExtender4.Enabled = False
            CalendarExtender5.Enabled = False
            CalendarExtender6.Enabled = False
            'btnFoodSave.enabled = False
            'btnFoodSave.Text = "EDIT"
            'btnFoodSave.Enabled = True

            Dim cb1 As CheckBox
            Dim x As Integer = 0

            For i As Integer = 0 To grdLedger.Rows.Count - 1
                cb1 = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then
                    x = 1

                    btnFoodSave.Enabled = True
                    btnFoodSave.Text = "EDIT"
                End If
            Next

            If x = 0 Then
                btnFoodSave.Enabled = True
                btnFoodSave.Text = "SAVE"
            End If




        Else
            'Dim dt As New DataTable
            Dim obj As New BaseClasses.Items
            txtFoodName.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & itemid, CommandType.Text)
            txtFoodName.ReadOnly = False

            txtFoodBrandName.Text = obj.GetValue("select Brand From dbo.m_item where Item_ID =" & itemid, CommandType.Text)

            txtFoodUnitprice.Text = obj.GetValue("select " & CY & " From dbo.m_item_detail where Item_ID =" & itemid, CommandType.Text)
            btnFoodSave.Text = "SAVE"

            ' define arrays of controls with the same read-write property value
            Dim readOnlyControls() As TextBox = {
                txtFoodDose, txtFoodBatch1
            }

            Dim readWriteControls() As TextBox = {
                txtFoodBrandName, txtFoodBatch, txtFoodForm, txtFoodUnitprice, txtFoodLot,
                txtFoodQuantity, txtFoodMdate, txtFoodDepRate, txtFoodEdate, txtFoodDepValue,
                txtFoodAlert, txtFoodBay, txtFoodColumn, txtFoodFloor, txtFoodRoom, txtFoodShelves,
                txtFoodRack, txtFoodBin
            }

            ' loop through the read-only controls and set their ReadOnly property to False
            For Each control As TextBox In readOnlyControls
                control.ReadOnly = False
            Next

            ' loop through the read-write controls and set their ReadOnly property to False
            For Each control As TextBox In readWriteControls
                control.ReadOnly = False
            Next

            btnFoodSave.Enabled = True

            btnFoodSave.Enabled = True
            DRP.Text = ""
            LTD.Text = ""
            RP.Text = ""
            txtFoodReOrderPt.Text = ""


            CalendarExtender4.Enabled = True
            CalendarExtender5.Enabled = True
            CalendarExtender6.Enabled = True
            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("select reorderPT from dbo.m_item where  Item_ID='" & hdnItemNo.Value & "'", CommandType.Text)
            If dt1.Rows.Count > 0 Then
                txtFoodQuantity.Text = dt1.Rows(0).Item(0)
            Else
            End If

            ' txtItemDesc2.text = dt.Rows(0).Item(0)
        End If

        ledger()
    End Sub

    Protected Sub grdLedger_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        Dim dt As DataTable
        Dim cb1 As CheckBox

        Dim FoodName As String = ""

        If drpFoodName.SelectedItem IsNot Nothing AndAlso drpFoodName.SelectedItem.Value <> "" Then
            FoodName = drpFoodName.SelectedItem.Value
        End If


        dt = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & FoodName & "'", CommandType.Text)


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

    Protected Sub btnROP_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Show()
    End Sub



    Protected Sub BtnCompute_Click1(sender As Object, e As EventArgs) Handles BtnCompute.Click
        Try
            RP.Text = DRP.Text * LTD.Text
            'ModalPopupExtender1.Show()
            txtFoodReOrderPt.Text = RP.Text
        Catch ex As Exception
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill Demand Per Day & Lead Time For Deliver.")
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub DRP_TextChanged(sender As Object, e As EventArgs) Handles DRP.TextChanged
        ModalPopupExtender1.Show()
    End Sub
    Protected Sub LTD_TextChanged(sender As Object, e As EventArgs) Handles LTD.TextChanged
        ModalPopupExtender1.Show()
    End Sub


    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtFoodBrandName.Text = String.Empty
        txtFoodForm.Text = String.Empty
        txtFoodUnitprice.Text = String.Empty
        txtFoodReOrderPt.Text = String.Empty
        txtFoodQuantity.Text = String.Empty
        txtSellectDate.Text = String.Empty

        txtFoodBatch.Text = String.Empty
        txtFoodLot.Text = String.Empty
        txtFoodMdate.Text = String.Empty
        txtFoodEdate.Text = String.Empty
        txtFoodAlert.Text = String.Empty

        '===========================ENABLING TEXTBOX===========================
        Dim readWriteControls() As TextBox = {
            txtFoodBrandName, txtFoodBatch, txtFoodForm, txtFoodUnitprice, txtFoodLot,
            txtFoodQuantity, txtFoodMdate, txtFoodDepRate, txtFoodEdate, txtFoodDepValue,
            txtFoodAlert, txtFoodBay, txtFoodColumn, txtFoodFloor, txtFoodRoom, txtFoodShelves,
            txtFoodRack, txtFoodBin
        }
        ' loop through the read-write controls and set their ReadOnly property to False
        For Each control As TextBox In readWriteControls
            control.ReadOnly = False
        Next


        '=========================DISPLAYING TEXTBOX DATA VALUES===================

        Dim dt As DataTable = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpFoodName.SelectedItem.Value & "'", CommandType.Text)


        Dim cb1 As CheckBox
        Dim x As Integer = 0

        For i As Integer = 0 To grdLedger.Rows.Count - 1
            cb1 = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

            If cb1.Visible AndAlso cb1.Checked Then
                x = 1

                btnFoodSave.Enabled = True
                btnFoodSave.Text = "EDIT"
            End If
        Next

        If x = 0 Then
            btnFoodSave.Enabled = True
            btnFoodSave.Text = "SAVE"
        End If


        If dt.Rows.Count > 0 Then

            For xa As Integer = 0 To grdLedger.Rows.Count - 1
                cb1 = CType(Me.grdLedger.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then
                    If dt.Rows.Count > 0 Then
                        txtFoodUnitprice.Text = dt.Rows(xa).Item("cost").ToString()
                        txtSellectDate.Text = dt.Rows(xa).Item("dDate").ToString()

                        'SOME UNIT FROM STOCK TABLE FOR SOME REASON DONT EXIST IN LIST OF DROPDOWN UNIT
                        Dim unitValue As String = dt.Rows(xa).Item("DebitUnit").ToString()
                        drpUnit.SelectedItem.Text = unitValue

                        txtFoodQuantity.Text = dt.Rows(xa).Item("DebitQty").ToString()

                        Dim dt2 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TbFood AS a WHERE  (Item_ID = '" & drpFoodName.SelectedItem.Value & "')  AND (StockId = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                        If dt2.Rows.Count > 0 Then
                            txtFoodForm.Text = dt2.Rows(0).Item("Form").ToString()
                            txtFoodBrandName.Text = dt2.Rows(0).Item("BrandName").ToString()
                            txtFoodBatch.Text = dt2.Rows(0).Item("Batch").ToString()
                            txtFoodLot.Text = dt2.Rows(0).Item("Lot").ToString()
                            txtFoodMdate.Text = dt2.Rows(0).Item("Mftgdate").ToString()
                            txtFoodAlert.Text = dt2.Rows(0).Item("Alert").ToString()
                            txtFoodEdate.Text = dt2.Rows(0).Item("EpiryDate").ToString()
                        End If


                        Dim dt4 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.Stock AS a WHERE  (Item_ID = '" & drpFoodName.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                        If dt4.Rows.Count > 0 Then
                            txtFoodReOrderPt.Text = dt4.Rows(0).Item("ReorderPt").ToString()
                        End If

                        Dim dt5 As DataTable = objDerived.GetDataTable("SELECT TOP (1) wName FROM AMS.Loc_Warehouse AS a WHERE  (warehouse_ID = '" & dt4.Rows(0).Item("warehouse_ID").ToString() & "')  ", CommandType.Text)

                        If dt5.Rows.Count > 0 Then

                            Dim valueUnit As String = dt5.Rows(0).Item("wName").ToString()
                            drpFoodWarehouse.SelectedItem.Text = valueUnit
                        End If

                    End If
                End If
            Next
        End If

    End Sub


    Protected Sub grdLedger_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles grdLedger.RowCreated

        If grdLedger.HeaderRow IsNot Nothing AndAlso grdLedger.Rows.Count > 0 Then
            If grdLedger.Rows.Count > 0 AndAlso grdLedger.Controls(0).Controls.Count > 0 Then

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
