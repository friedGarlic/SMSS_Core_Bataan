Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Drawing
Partial Class Inventory_t_sub_inventory_mooe
    Inherits System.Web.UI.Page

    Dim objDerived As New DerivedDal
    Dim image As New Image
    Dim obj As New BaseClasses.Items
    Public dtStock As New DataTable
    Dim objx As New AccessRule
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
    Protected Sub loadStockSupplyDetails()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("Select * from [dbo].[View_StockDetails] where Item_ID = '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dt.Rows.Count = 0 Then
            'lblofficesuppliesitemdescription.Text = ""
            'lblofficesuppliesbrandname.Text = ""
            'lnksupplieroffice.Text = ""
            'lblofficesuppliessize.Text = ""
            'lblofficesuppliescolor.Text = ""
            'lblofficesuppliesdepreciatedRate.Text = ""
            'lblofficesuppliescategory.Text = ""
            'lblofficesupplieslength.Text = ""
            'lblofficesupplieswidth.Text = ""
            'lblofficesuppliesheight.Text = ""
            'lblofficesupplieswieght.Text = ""
            'lblofficesuppliesdepreciatedvalue.Text = ""
        Else
            'lblofficesuppliesitemdescription.Text = dt.Rows(0).Item("Item_Desc").ToString
            'lblofficesuppliesbrandname.Text = dt.Rows(0).Item("BrandName").ToString
            'lnksupplieroffice.Text = dt.Rows(0).Item("SuppName").ToString
            'lblofficesuppliessize.Text = dt.Rows(0).Item("Size").ToString
            'lblofficesuppliescolor.Text = dt.Rows(0).Item("Color").ToString
            'lblofficesuppliesdepreciatedRate.Text = dt.Rows(0).Item("DepreciatedRate").ToString
            'lblofficesuppliescategory.Text = dt.Rows(0).Item("Category").ToString
            'lblofficesupplieslength.Text = dt.Rows(0).Item("Length").ToString
            'lblofficesupplieswidth.Text = dt.Rows(0).Item("Width").ToString
            'lblofficesuppliesheight.Text = dt.Rows(0).Item("Height").ToString
            'lblofficesupplieswieght.Text = dt.Rows(0).Item("Weight").ToString
            'lblofficesuppliesdepreciatedvalue.Text = dt.Rows(0).Item("depreciatedvalue").ToString

        End If
    End Sub
    Public Function createdatatableStock(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("description", GetType(String))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("reorderPT", GetType(Integer))
        dt.Columns.Add("GA_ID", GetType(Long))
        dt.Columns.Add("Location", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_ID") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("description") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("reorderPT") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("Location") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
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
            dr("BalCost") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function createdatatableMedicine(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("batch", GetType(String))
        dt.Columns.Add("lot", GetType(String))
        dt.Columns.Add("qty", GetType(Integer))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("qtybox", GetType(String))
        dt.Columns.Add("TotalPcs", GetType(Long))
        dt.Columns.Add("actualprice", GetType(Decimal))
        dt.Columns.Add("deliverydate", GetType(String))
        dt.Columns.Add("EpiryDate", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long)) 'StockID
        dt.Columns.Add("StockID", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Long))
        dt.Columns.Add("Received_ID", GetType(Long))
        dt.Columns.Add("SuppName", GetType(Long))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PO_No") = DBNull.Value
            dr("batch") = DBNull.Value
            dr("lot") = DBNull.Value
            dr("qty") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("qtybox") = DBNull.Value
            dr("TotalPcs") = DBNull.Value
            dr("actualprice") = DBNull.Value
            dr("deliverydate") = DBNull.Value
            dr("EpiryDate") = DBNull.Value
            dr("POHdr_ID") = DBNull.Value
            dr("StockID") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("Received_ID") = DBNull.Value
            dr("SuppName") = DBNull.Value

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            grdStockList.DataSource = createdatatableStock(8)
            grdStockList.DataBind()

            grdLedger.DataSource = createdatatableledger(5)
            grdLedger.DataBind()

            grdsupplies.DataSource = createdatatableMedicine(3)
            grdsupplies.DataBind()

            Classification_load()
            loadDepartments()
        End If
    End Sub
    Protected Sub drpClassification_SelectedIndexChanged(sender As Object, e As EventArgs)
        Sub_Classification_load()
    End Sub
    Protected Sub drpSub_Classification_SelectedIndexChanged(sender As Object, e As EventArgs)
        GeneralAccount_Load()
    End Sub
    Protected Sub drpGeneral_Account_SelectedIndexChanged(sender As Object, e As EventArgs)
        Category_load()
        loadStockOfficeSupplies()
    End Sub
    Protected Sub drpCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        SubCategory_Load()
    End Sub
    Protected Sub Classification_load()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.ClassificationId,ClassificationName From dbo.tbl_Classification as a inner join tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id = b.GA_ID and c.BGA_ID = b.BGA_ID where b.AllotmentClass_ID = 2 and a.isenable = 1 group by a.ClassificationId,ClassificationName,seqno order by seqno", CommandType.Text)
        drpClassification.DataSource = CType(dt, DataTable)
        drpClassification.DataTextField = ("ClassificationName")
        drpClassification.DataValueField = ("ClassificationId")
        drpClassification.DataBind()
        Sub_Classification_load()
    End Sub
    Public Sub Sub_Classification_load()
        drpSub_Classification.DataSource = obj.GetDataTable("select distinct b.SubClassificationName ,b.SubClassificationID  From tblclassmatrix as a inner join dbo.tbl_SubClassification as b on  b.ClassificationID = a.ClassificationID and b.SubClassificationID = a.SubClassificationID where a.classificationid = '" & drpClassification.selectedvalue() & "'", CommandType.Text)
        drpSub_Classification.DataTextField = ("SubClassificationName")
        drpSub_Classification.DataValueField = ("SubClassificationID")
        drpSub_Classification.DataBind
        GeneralAccount_Load()
    End Sub
    Public Sub GeneralAccount_Load()

        drpGeneral_Account.DataSource = obj.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & drpClassification.selectedvalue() & "'", CommandType.Text)
        drpGeneral_Account.DataTextField = ("GA_Title")
        drpGeneral_Account.DataValueField = ("GA_ID")
        drpGeneral_Account.DataBind()
        Category_load()
    End Sub
    Public Sub Category_load()
        Dim dt As New DataTable
        Dim glaccount As Integer

        If drpGeneral_Account.text = "" Then
            glaccount = 0
        Else
            glaccount = drpGeneral_Account.selecteditem.value
        End If

        Dim classification As Integer

        If drpClassification.SelectedItem.Value = 0 Then
            classification = 0
        Else
            classification = drpClassification.SelectedItem.Value
        End If


        Dim sub_classification As Integer
        If drpSub_Classification.SelectedItem.Value = 0 Then
            sub_classification = 0
        Else
            sub_classification = drpSub_Classification.SelectedItem.Value
        End If



        drpCategory.DataSource = obj.GetDataTable("exec ams.FMparticularsSupplies '" & glaccount & "','" & 0 & "','" & classification & "','" & sub_classification & "'", CommandType.Text)
        drpCategory.DataTextField = ("description")
        drpCategory.DataValueField = ("item_particular_id")
        drpCategory.DataBind()
        drpCategory.items.insert(0, "All")
        SubCategory_Load()
    End Sub
    Protected Sub loadSearch()


        Dim subcategory As String
        If drpSub_Category.text = "" Then
            subcategory = "0"
        Else
            subcategory = drpSub_Category.selectedvalue()
        End If
        Dim CY As String = "CY" & Year(Date.Today)

        Dim dtStock As New DataTable
        'Try

        ' dtStock = objDerived.GetDataTable("EXEC [dbo].[sp_SMSSStockSupplies_Search] '" & ddGlAccount.SelectedItem.Value & "', '%" & replaceapostrophe(txtSearchStock.Text) & "%'", CommandType.Text)
        dtStock = objDerived.GetDataTable("EXEC [dbo].[sp_SMSSStockSupplies_Search_v1_05172024_SUB] '" & drpGeneral_Account.SelectedItem.Value & "', 0,'" & CY & "','" & drpCategory.selecteditem.value & "','" & subcategory & "','%" & replaceapostrophe(txtSearch.Text) & "%','" & drpDepartment.SelectedValue() & "'", CommandType.Text)

        If dtStock.Rows.Count < 10 Then
            dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
        End If
        grdStockList.DataSource = dtStock
        grdStockList.DataBind()
        grdStockList.SelectedIndex = 0

        'Me.MultiView1.SetActiveView(Me.View1)
        loadStockSupplyDetails()

        'grdOfficeSupplyLedger.DataSource = createdatatableledger(10)
        'grdOfficeSupplyLedger.DataBind()

        ' Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "")
    End Function
    Public Sub SubCategory_Load()
        Dim category As String
        If drpCategory.text = "" Then
            category = 0
        Else
            If drpCategory.selectedvalue() = "All" Then
                category = 0
            Else
                category = drpCategory.selectedvalue()
            End If

        End If

        Dim subcategory As New DataTable
        drpSub_Category.items.clear()
        '
        subcategory = obj.GetDataTable("select [SubCategoryID],[SubCat_Desc]  From [dbo].[tbl_SubCategory] where item_particular_id = " & category & "", CommandType.Text)
        drpSub_Category.datasource = subcategory
        drpSub_Category.DataTextField = ("SubCat_Desc")
        drpSub_Category.DataValueField = ("SubCategoryID")
        drpSub_Category.DataBind()
        drpSub_Category.items.insert(0, "All")

    End Sub
    Public Sub loadDepartments()


        drpDepartment.DataSource = obj.GetDataTable("[AMS].[sp_VIEW_Departments] '" & Session("@UserID") & "'", CommandType.Text)
        drpDepartment.DataTextField = ("RC_Name")
        drpDepartment.DataValueField = ("RC_ID")
        drpDepartment.DataBind()

    End Sub

    Protected Sub drpSub_Category_SelectedIndexChanged(sender As Object, e As EventArgs)
        loadStockOfficeSupplies()
    End Sub
    Protected Sub loadStockOfficeSupplies()
        Dim subcategory As String
        If drpSub_Category.text = "" Then
            subcategory = "0"
        Else
            subcategory = drpSub_Category.selectedvalue()
        End If
        Dim CY As String = "CY" & Year(Date.Today)
        Dim SubCatID As Integer
        If drpSub_Category.selectedItem.text = "All" Then
            SubCatID = 0
        Else
            SubCatID = drpSub_Category.SelectedItem.value
        End If

        If drpCategory.SelectedIndex = 0 Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_05132024_Stockcardmain] '" & drpGeneral_Account.SelectedValue() & "','0','" & CY & "','" & 0 & "','" & 0 & "','" & drpDepartment.SelectedValue() & "'", CommandType.Text)
        ElseIf drpCategory.SelectedIndex > 0 Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_05132024_Stockcardmain] '" & drpGeneral_Account.SelectedValue() & "','0','" & CY & "','" & drpCategory.SelectedValue() & "','" & 0 & "','" & drpDepartment.SelectedValue() & "'", CommandType.Text)
        ElseIf drpCategory.SelectedIndex <> 0 And drpSub_Category.SelectedIndex <> 0 Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_05132024_Stockcardmain] '" & drpGeneral_Account.SelectedValue() & "','0','" & CY & "','" & drpCategory.SelectedValue() & "','" & drpSub_Category.SelectedValue() & "','" & drpDepartment.SelectedValue() & "'", CommandType.Text)
        End If

        If dtStock.Rows.Count = 0 Then
            grdStockList.DataSource = createdatatableStock(8)
            grdStockList.DataBind()

            'grdOfficeSupplyLedger.DataSource = createdatatableledger(10)
            'grdOfficeSupplyLedger.DataBind()

        Else
            If dtStock.Rows.Count < 10 Then
                dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
            End If
            grdStockList.DataSource = dtStock
            grdStockList.DataBind()
            grdStockList.SelectedIndex = 0

            loadStockSupplyDetails()

            Dim dtStockLedger As New DataTable
            dtStockLedger = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            If dtStockLedger.Rows.Count < 10 Then
                dtStockLedger.Merge(createdatatableledger(9 - dtStockLedger.Rows.Count))
            End If
            'grdOfficeSupplyLedger.DataSource = dtStockLedger
            'grdOfficeSupplyLedger.DataBind()
            grdStockList.SelectedIndex = -1
        End If

    End Sub
    Protected Sub grdStockList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdStockList, "Select$" + e.Row.RowIndex.ToString()))

        End If
    End Sub
    Protected Sub ledger()
        If hdnItemNo.value = "" Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] null", CommandType.Text)
        Else
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.value & "'", CommandType.Text)

        End If
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
        End If
        grdLedger.DataSource = dtStock
        grdLedger.DataBind()
    End Sub
    Protected Sub grdStockList_SelectedIndexChanged(sender As Object, e As EventArgs)
        hdnItemNo.value = grdStockList.SelectedDataKey("Item_ID")

        ledger()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        loadSearch()
    End Sub
End Class
