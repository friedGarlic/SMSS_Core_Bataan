Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Drawing

Partial Class Records_t_StockCard_v2

    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim image As New Image
    Dim obj As New BaseClasses.Items
    Public dtStock As New DataTable
    Dim objx As New AccessRule


    ' Fix “SuppliesId is not declared”
    Private SuppliesId As Long

    ' Fix “StockLedger_ID is not declared”
    Private StockLedger_ID As Long

    ' If “txtIAremarks” is a control on your .aspx page, 
    ' it might need to be declared as:
    Protected WithEvents txtIAremarks As TextBox

    ' If “txtContractprice” is also a control:
    Protected WithEvents txtContractprice As TextBox

    ' If “pItems” is some sort of table or control:
    Private pItems As DataTable  ' or a GridView, or a List, etc.

    ' If “StockID” is used in multiple places but never declared:
    Private StockID As Long = 0
#Region "PROPERTY"
    Private Property PListofGL() As DataTable
        Get
            Return CType(Session("PListofGL"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PListofGL") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objx.GetAccessRight(Me.Session("@UserName"), Page)

        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            txtSearchStock.Text = ""
            Dim classification As String = objDerived.GetValue("select * From dbo.tbl_Classification where ClassificationName like '%Supplies%' ", CommandType.Text)
            txtDate.Text = Date.Now.ToString("MM-dd-yyyy")

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("select distinct a.SubClassificationID,a.SubClassificationName " &
                                           "From tbl_SubClassification As a " &
                                            " inner join tblclassmatrix as b on a.SubClassificationID = b.SubClassificationID " &
                                            " inner join tbl_Classification As c On b.classificationid = c.ClassificationId" &
                                            " where c.ClassificationId = '" & classification & "'", CommandType.Text)
            DrpSubClass.DataSource = CType(dt, DataTable)
            DrpSubClass.DataTextField = ("SubClassificationName")
            DrpSubClass.DataValueField = ("SubClassificationID")
            DrpSubClass.DataBind()
            SelectSubClassification()





            txtSearchStock.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchStock.ClientID & "')")

            Me.MultiView1.SetActiveView(Me.View1)


            hndLoad.Value = 0
        End If

        ' ledger()

    End Sub
    Public Sub SelectSubClassification()

        Dim classification As String = objDerived.GetValue("select * From dbo.tbl_Classification where ClassificationName like '%Supplies%' ", CommandType.Text)

        PListofGL = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & classification & "','" & DrpSubClass.SelectedItem.Value & "'", CommandType.Text)
        ddGlAccount.DataSource = CType(PListofGL, DataTable)
        ddGlAccount.DataTextField = ("GA_Title")
        ddGlAccount.DataValueField = ("GA_ID")
        ddGlAccount.DataBind()

        selectGLAccount()

    End Sub

    Public Sub selectGLAccount()
        Dim dt As New DataTable
        dt = obj.GetDataTable("select item_particular_id,description From AMS.item_particular where GA_ID =" & ddGlAccount.SelectedItem.Value & " order by description", CommandType.Text)
        ddCategory.DataSource = dt
        ddCategory.DataTextField = ("description")
        ddCategory.DataValueField = ("item_particular_id")
        ddCategory.DataBind()
        SelectCategory()
    End Sub

    Protected Sub ddGlAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddGlAccount.SelectedIndexChanged
        selectGLAccount()
        MultiviewSupplier()
    End Sub
    Public Sub loadwarehouse()
        Dim dt As New DataTable
        dt = obj.GetDataTable("select warehouse_id,wname From ams.loc_warehouse where isUsed='True'", CommandType.Text)
        drpWarehouse.DataTextField = ("wname")
        drpWarehouse.DataValueField = ("warehouse_id")
        drpWarehouse.DataSource = dt
        drpWarehouse.DataBind()

    End Sub


    Public Sub MultiviewSupplier()

        If ddGlAccount.SelectedItem.Value = 1432 Then
            ' Drugs and Medicines
            'lblDetails.Text = "DRUGS & MEDICINE DETAILS"
            txtSearchStock.Text = ""
            'lblHistoryDetails.Text = "DRUGS & MEDICINE DETAILS"
            lblHistoryDetails.Text = "DETAILS"


            Me.MultiView1.SetActiveView(Me.View2)
            'imgmedical.ImageUrl = "~/images/medicine_icon.jpg"
            loadStockMedSupplies()

        ElseIf ddGlAccount.SelectedItem.Value = 1433 Then
            ' Medical, Dental and Laboratory Supplies
            'lblDetails.Text = "MEDICAL SUPPLY DETAILS"
            txtSearchStock.Text = ""
            'lblHistoryDetails.Text = "MEDICAL SUPPLY DETAILS"
            lblHistoryDetails.Text = "DETAILS"

            Me.MultiView1.SetActiveView(Me.View1)
            'imgmedical.ImageUrl = "~/images/medicine_icon.jpg"
            loadStockMedSupplies()

        ElseIf ddGlAccount.SelectedItem.Value = 1430 Then
            ' Food Supplies
            'lblDetails.Text = "FOOD DETAILS"
            txtSearchStock.Text = ""
            lblHistoryDetails.Text = "DETAILS"
            'lblHistoryDetails.Text = "FOOD DETAILS"

            Me.MultiView1.SetActiveView(Me.View2)
            'imgmedical.ImageUrl = "~/images/Food.JPG"
            LoadSupplies()

        ElseIf ddGlAccount.SelectedItem.Value = 1441 Then
            'Water
            'lblDetails.Text = "WATER DETAILS"
            txtSearchStock.Text = ""
            lblHistoryDetails.Text = "DETAILS"
            'lblHistoryDetails.Text = "WATER DETAILS"

            Me.MultiView1.SetActiveView(Me.View2)
            'imgmedical.ImageUrl = "~/images/Water.jpg"
            LoadSupplies()


        ElseIf ddGlAccount.SelectedItem.Value = 1427 Then
            'Office Supplies
            'lblDetails.Text = "OFFICE SUPPLY DETAILS"
            txtSearchStock.Text = ""
            lblHistoryDetails.Text = "DETAILS"
            'lblHistoryDetails.Text = "OFFICE SUPPLY DETAILS"
            Me.MultiView1.SetActiveView(Me.View1)
            'imgOffice.ImageUrl = "~/images/supplies_icon.jpg"
            loadStockOfficeSupplies()
            'LoadStockChangeIndex()

        Else  'Non-Food & Others Items
            'lblDetails.Text = "NON-FOOD DETAILS"
            txtSearchStock.Text = ""
            lblHistoryDetails.Text = "DETAILS"
            'lblHistoryDetails.Text = "NON-FOOD DETAILS"

            Me.MultiView1.SetActiveView(Me.View2)
            'imgmedical.ImageUrl = "~/images/blankImage.jpg"

            LoadSupplies()
        End If
    End Sub

    ' ==== Search Options =====
    Protected Sub btnSearchStock_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        loadSearch()
        'LoadStockChangeIndex()
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "")
    End Function
    Protected Sub loadSearch()


        Dim subcategory As String
        If ddSubCategory.Text = "" Then
            subcategory = "0"
        Else
            subcategory = ddSubCategory.SelectedValue()
        End If
        Dim CY As String = "CY" & Year(txtDate.Text)
        Dim dtStock As New DataTable
        'Try





        ' dtStock = objDerived.GetDataTable("EXEC [dbo].[sp_SMSSStockSupplies_Search] '" & ddGlAccount.SelectedItem.Value & "', '%" & replaceapostrophe(txtSearchStock.Text) & "%'", CommandType.Text)
        dtStock = objDerived.GetDataTable("EXEC [dbo].[sp_SMSSStockSupplies_Search_v1_02092022] '" & ddGlAccount.SelectedItem.Value & "', 0,'" & CY & "','" & ddCategory.SelectedItem.Value & "','" & subcategory & "','%" & replaceapostrophe(txtSearchStock.Text) & "%'", CommandType.Text)

        If dtStock.Rows.Count < 10 Then
            dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
        End If
        grdStockList.DataSource = dtStock
        grdStockList.DataBind()
        grdStockList.SelectedIndex = 0

        Me.MultiView1.SetActiveView(Me.View1)
        loadStockSupplyDetails()

        'grdOfficeSupplyLedger.DataSource = createdatatableledger(10)
        'grdOfficeSupplyLedger.DataBind()

        ' Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Protected Sub loadMedSearch()
        Dim dtStock As New DataTable
        Try
            dtStock = objDerived.GetDataTable("EXEC spMedicineSupplies_search '" & ddGlAccount.SelectedValue() & "', '%" & txtSearchStock.Text & "%'", CommandType.Text)
            If dtStock.Rows.Count < 10 Then
                dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
            End If
            grdStockList.DataSource = dtStock
            grdStockList.DataBind()
            grdStockList.SelectedIndex = 0

            Me.MultiView1.SetActiveView(Me.View2)
            LoadStockGridBatches()
            loadStockDetails()

            grdLedger.DataSource = createdatatableledger(5)
            grdLedger.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    ' ==== Offices Supplies =====
    Protected Sub grdStockList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdStockList.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdStockList, "Select$" + e.Row.RowIndex.ToString()))

            If e.Row.Cells(4).Text <= e.Row.Cells(6).Text Then
                e.Row.Cells(4).BackColor = IIf(CStr(e.Row.Cells(6).Text).ToString = "&nbsp;", Drawing.Color.Empty, Drawing.Color.Red)
            End If
        End If

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
    Protected Sub grdStockList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdStockList.SelectedIndexChanged
        loadCleartext()
        LoadStockChangeIndex()

    End Sub
    Protected Sub LoadStockChangeIndex()

        If ddGlAccount.SelectedItem.Value = 1432 Then
            ' Drugs and Medicines
            Me.MultiView1.SetActiveView(Me.View2)
            LoadStockGridBatches()
            'loadStockDetails()

            ledger()


        ElseIf ddGlAccount.SelectedItem.Value = 1433 Then
            ' Medical, Dental and Laboratory Supplies
            Me.MultiView1.SetActiveView(Me.View2)
            LoadStockGridBatches()
            'loadStockDetails()

            ledger()

        ElseIf ddGlAccount.SelectedItem.Value = 1427 Then
            ' Office Supplies
            Me.MultiView1.SetActiveView(Me.View1)
            'Me.MultiView1.SetActiveView(Me.View2)
            LoadStockGridBatches()
            'loadStockSupplyDetails()

            ledger()

        ElseIf ddGlAccount.SelectedItem.Value = 1430 Then
            ' Food Supplies
            Me.MultiView1.SetActiveView(Me.View2)
            LoadStockGridBatches()
            'loadStockDetails()

            ledger()

        ElseIf ddGlAccount.SelectedItem.Value = 1441 Then
            'Water
            Me.MultiView1.SetActiveView(Me.View2)
            LoadStockGridBatches()
            'loadStockDetails()

            ledger()

        ElseIf ddGlAccount.SelectedItem.Value = 1443 And DrpSubClass.SelectedValue = "5" Then
            Me.MultiView1.SetActiveView(Me.View3)
            hdnROP.Value = "Electrical"
            LoadStockGridBatches()
            loadUnitElectrical()
            loadwarehouseElectrical()
            ledger()


        ElseIf ddGlAccount.SelectedItem.Value = 1443 And DrpSubClass.SelectedValue = "6" Then
            Me.MultiView1.SetActiveView(Me.View3)
            hdnROP.Value = "Electrical"
            LoadStockGridBatches()
            loadUnitElectrical()
            loadwarehouseElectrical()
            ledger()

        Else 'If ddGlAccount.SelectedItem.Value = 927 Or ddGlAccount.SelectedItem.Value = 790 Or ddGlAccount.SelectedItem.Value = 795 Then
            'Non-Food Items
            Me.MultiView1.SetActiveView(Me.View2)
            LoadStockGridBatches()
            'loadStockDetails()

            ledger()

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

    Protected Sub loadStockOfficeSupplies()
        Dim subcategory As String
        If ddSubCategory.Text = "" Then
            subcategory = "0"
        Else
            subcategory = ddSubCategory.SelectedValue()
        End If
        Dim CY As String = "CY" & Year(txtDate.Text)

        Dim classification As String = objDerived.GetValue("select * From dbo.tbl_Classification where ClassificationName like '%Supplies%' ", CommandType.Text)

        Dim dtitemdesc As New DataTable
        'dtitemdesc = objDerived.GetDataTable("select a.Item_ID, c.description+ ',' + isnull(e.SubCat_desc, '') + ',' + isnull(a.Brand, '') + ',' + isnull(a.Color,'') + ',' + isnull(a.Size,'') + ',' + a.item_desc AS Item_Desc " &
        '                                        " From dbo.m_item as a " &
        '                                        " left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
        '                                        " inner join dbo.tblclassmatrix As d On a.Item_ID = d.item_id" &
        '                                        " inner join ams.item_particular as c on d.categoryid = c.item_particular_id " &
        '                                        " left outer join dbo.tbl_SubCategory As e On d.subcategoryid = e.SubCategoryID " &
        '                                        " where c.ClassificationID = " & classification & " order by  Item_Desc", CommandType.Text)

        'dtitemdesc = objDerived.GetDataTable("SELECT dbo.m_item.Item_ID, dbo.m_item.ItemCompleteDesc as Item_Desc " &
        '                                     " FROM dbo.m_item LEFT OUTER JOIN " &
        '                                     " dbo.m_item_detail ON dbo.m_item.Item_ID = dbo.m_item_detail.Item_ID INNER JOIN " &
        '                                     " dbo.tblclassmatrix ON dbo.m_item.Item_ID = dbo.tblclassmatrix.item_id INNER JOIN " &
        '                                     " AMS.item_particular ON dbo.tblclassmatrix.categoryid = AMS.item_particular.item_particular_id LEFT OUTER JOIN " &
        '                                     " dbo.tbl_SubCategory ON dbo.tblclassmatrix.subcategoryid = dbo.tbl_SubCategory.SubCategoryID " &
        '                                     " WHERE(AMS.item_particular.ClassificationID = " & classification & ") ORDER BY dbo.m_item.ItemCompleteDesc", CommandType.Text)
        'drpItemDesc1.datasource = dtitemdesc
        'drpItemDesc1.DataTextField = ("Item_Desc")
        'drpItemDesc1.DataValueField = ("Item_ID")
        'drpItemDesc1.DataBind()

        If DrpSubClass.SelectedValue = "1" Then
            drpItemDesc1.Items.Clear()
            dtitemdesc = objDerived.GetDataTable("SELECT DISTINCT dbo.m_item.Item_ID, dbo.m_item.ItemCompleteDesc as Item_Desc " &
                         "FROM dbo.tbl_SubClassification INNER JOIN " &
                         "dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID INNER JOIN " &
                         "dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId INNER JOIN " &
                         "dbo.m_item_detail ON dbo.m_item.Item_ID = dbo.m_item_detail.Item_ID " &
                         "WHERE (dbo.tbl_SubClassification.SubClassificationID = " & DrpSubClass.SelectedValue & ") " &
                         "ORDER BY dbo.m_item.ItemCompleteDesc", CommandType.Text)
            drpItemDesc1.DataSource = dtitemdesc
            drpItemDesc1.DataTextField = ("Item_Desc")
            drpItemDesc1.DataValueField = ("Item_ID")
            drpItemDesc1.DataBind()
            drpItemDesc1.Enabled = True
            selectitemdesc()

        ElseIf DrpSubClass.SelectedValue = "2" Then
            drpItemDesc1.Items.Clear()
            dtitemdesc = objDerived.GetDataTable("SELECT DISTINCT dbo.m_item.Item_ID, dbo.m_item.ItemCompleteDesc as Item_Desc " &
                         "FROM dbo.tbl_SubClassification INNER JOIN " &
                         "dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID INNER JOIN " &
                         "dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId INNER JOIN " &
                         "dbo.m_item_detail ON dbo.m_item.Item_ID = dbo.m_item_detail.Item_ID " &
                         "WHERE (dbo.tbl_SubClassification.SubClassificationID = " & DrpSubClass.SelectedValue & ") " &
                         "ORDER BY dbo.m_item.ItemCompleteDesc", CommandType.Text)
            drpItemDesc1.DataSource = dtitemdesc
            drpItemDesc1.DataTextField = ("Item_Desc")
            drpItemDesc1.DataValueField = ("Item_ID")
            drpItemDesc1.DataBind()
            drpItemDesc1.Enabled = True
            selectitemdesc()
        ElseIf DrpSubClass.SelectedValue = "3" Then
            drpItemDesc1.Items.Clear()
            dtitemdesc = objDerived.GetDataTable("SELECT DISTINCT dbo.m_item.Item_ID, dbo.m_item.ItemCompleteDesc as Item_Desc " &
                         "FROM dbo.tbl_SubClassification INNER JOIN " &
                         "dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID INNER JOIN " &
                         "dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId INNER JOIN " &
                         "dbo.m_item_detail ON dbo.m_item.Item_ID = dbo.m_item_detail.Item_ID " &
                         "WHERE (dbo.tbl_SubClassification.SubClassificationID = " & DrpSubClass.SelectedValue & ") " &
                         "ORDER BY dbo.m_item.ItemCompleteDesc", CommandType.Text)
            drpItemDesc1.DataSource = dtitemdesc
            drpItemDesc1.DataTextField = ("Item_Desc")
            drpItemDesc1.DataValueField = ("Item_ID")
            drpItemDesc1.DataBind()
            drpItemDesc1.Enabled = True
            selectitemdesc()
        ElseIf DrpSubClass.SelectedValue = "5" Then
            drpNameElectrical.Items.Clear()
            dtitemdesc = objDerived.GetDataTable("SELECT DISTINCT dbo.m_item.Item_ID, dbo.m_item.ItemCompleteDesc as Item_Desc " &
                         "FROM dbo.tbl_SubClassification INNER JOIN " &
                         "dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID INNER JOIN " &
                         "dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId INNER JOIN " &
                         "dbo.m_item_detail ON dbo.m_item.Item_ID = dbo.m_item_detail.Item_ID " &
                         "WHERE (dbo.tbl_SubClassification.SubClassificationID = " & DrpSubClass.SelectedValue & ") " &
                         "ORDER BY dbo.m_item.ItemCompleteDesc", CommandType.Text)
            drpNameElectrical.DataSource = dtitemdesc
            drpNameElectrical.DataTextField = ("Item_Desc")
            drpNameElectrical.DataValueField = ("Item_ID")
            drpNameElectrical.DataBind()
            Electrical()
        ElseIf DrpSubClass.SelectedValue = "6" Then
            drpNameElectrical.Items.Clear()
            dtitemdesc = objDerived.GetDataTable("SELECT DISTINCT dbo.m_item.Item_ID, dbo.m_item.ItemCompleteDesc as Item_Desc " &
                      "FROM dbo.tbl_SubClassification INNER JOIN " &
                      "dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID INNER JOIN " &
                      "dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId INNER JOIN " &
                      "dbo.m_item_detail ON dbo.m_item.Item_ID = dbo.m_item_detail.Item_ID " &
                      "WHERE (dbo.tbl_SubClassification.SubClassificationID = " & DrpSubClass.SelectedValue & ") " &
                      "ORDER BY dbo.m_item.ItemCompleteDesc", CommandType.Text)
            drpNameElectrical.DataSource = dtitemdesc
            drpNameElectrical.DataTextField = ("Item_Desc")
            drpNameElectrical.DataValueField = ("Item_ID")
            drpNameElectrical.DataBind()
            drpNameElectrical.Enabled = True
            Electrical()
        ElseIf DrpSubClass.SelectedValue = "1069" Then
            drpJanitorial.Items.Clear()
            dtitemdesc = objDerived.GetDataTable("SELECT DISTINCT dbo.m_item.Item_ID, dbo.m_item.ItemCompleteDesc as Item_Desc " &
                      "FROM dbo.tbl_SubClassification INNER JOIN " &
                      "dbo.m_item ON dbo.tbl_SubClassification.SubClassificationID = dbo.m_item.SubClassificationID INNER JOIN " &
                      "dbo.tbl_Classification ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_Classification.ClassificationId INNER JOIN " &
                      "dbo.m_item_detail ON dbo.m_item.Item_ID = dbo.m_item_detail.Item_ID " &
                      "WHERE (dbo.tbl_SubClassification.SubClassificationID = " & DrpSubClass.SelectedValue & ") " &
                      "ORDER BY dbo.m_item.ItemCompleteDesc", CommandType.Text)
            drpJanitorial.DataSource = dtitemdesc
            drpJanitorial.DataTextField = ("Item_Desc")
            drpJanitorial.DataValueField = ("Item_ID")
            drpJanitorial.DataBind()
            drpJanitorial.Enabled = True
            Med()
            loadUnitMed()
            loadwarehouseMedical()
            RetriveMed()

        End If





        Dim dtStock As New DataTable
        ' dtStock = objDerived.GetDataTable("Exec [dbo].[sp_SMSSStockSupplies] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022] '" & ddGlAccount.SelectedValue() & "','0','" & CY & "','" & ddCategory.SelectedValue() & "','" & subcategory & "'", CommandType.Text)
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

    ' ==== Medical Supplies =====    
    Protected Sub loadStockMedSupplies()
        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [dbo].[sp_SMSSStockSupplies] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        If dtStock.Rows.Count = 0 Then
            grdStockList.DataSource = createdatatableStock(8)
            grdStockList.DataBind()

            grdsupplies.DataSource = createdatatableMedicine(3)
            grdsupplies.DataBind()

            grdLedger.DataSource = createdatatableledger(5)
            grdLedger.DataBind()

        Else
            If dtStock.Rows.Count < 10 Then
                dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
            End If
            grdStockList.DataSource = dtStock
            grdStockList.DataBind()
            grdStockList.SelectedIndex = 0

            LoadStockGridBatches()

            Dim dtStockLedger As New DataTable
            dtStockLedger = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            If dtStockLedger.Rows.Count < 10 Then
                dtStockLedger.Merge(createdatatableledger(9 - dtStockLedger.Rows.Count))
            End If
            grdLedger.DataSource = dtStockLedger
            grdLedger.DataBind()

        End If
        'LoadStockGridBatches()
    End Sub
    Protected Sub LoadStockGridBatches()
        Dim CY As String = "CY" & Year(txtDate.Text)

        Dim dtStock As New DataTable
        'dtStock = objDerived.GetDataTable("select *  from [dbo].[View_StockSupplyBatches] where  Item_ID = '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        Dim itemID As String

        If grdStockList.SelectedIndex < 0 Then
            itemID = 0
        Else
            If IsDBNull(grdStockList.SelectedDataKey("Item_ID")) Then
                itemID = 0
                loadCleartext()
                loadwarehouse()
                btnSave.Enabled = True
                btnSave.Text = "SAVE"
                '  btnCancel.enabled = False
            Else
                itemID = grdStockList.SelectedDataKey("Item_ID")
                loadCleartext()
                loadwarehouse()
                hdnItemNo.Value = itemID
                hdnGAId.Value = ddGlAccount.SelectedValue()
                Dim a As Integer
                If grdStockList.SelectedRow.Cells(3).Text <> 0 Then
                    Dim dt As New DataTable
                    dt = obj.GetDataTable("select a.Description,a.BrandName,a.Size,a.Color,a.DepreciatedRate,a.DepreciatedValue,a.Length,a.Width,a.Height,a.Weight,b.Cost,convert(int,b.Qty) ,isnull(b.Location,' - '),isnull(b.warehouse_id,1),b.StockDate  From [AMS].[TBSupplies_Info] as a inner join ams.Stock as b on a.StockID = b.StockID  where Item_ID =" & hdnItemNo.Value, CommandType.Text)
                    If dt.Rows.Count > 0 Then
                        'txtItemDesc1.text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                        'txtItemDesc1.Text = dt.Rows(0).Item(0)
                        'txtItemDesc1.ReadOnly = True

                        'txtBrandName1.Text = dt.Rows(0).Item(1)
                        'txtBrandName1.ReadOnly = True

                        'txtSize.Text = dt.Rows(0).Item(2)
                        'txtSize.ReadOnly = True

                        'txtColor.Text = dt.Rows(0).Item(3)
                        'txtColor.ReadOnly = True

                        'txtDepRate1.Text = dt.Rows(0).Item(4)
                        'txtDepRate1.ReadOnly = True
                        'txtDepValue1.Text = dt.Rows(0).Item(5)
                        'txtDepValue1.ReadOnly = True

                        'txtCategory.ReadOnly = True

                        'txtLenght.Text = dt.Rows(0).Item(6)
                        'txtLenght.ReadOnly = True
                        'txtWidth.Text = dt.Rows(0).Item(7)
                        'txtWidth.ReadOnly = True
                        'txtHeight.Text = dt.Rows(0).Item(8)
                        'txtHeight.ReadOnly = True
                        'txtWeight.Text = dt.Rows(0).Item(9)
                        'txtWeight.ReadOnly = True

                        'txtUnitPrice.Text = dt.Rows(0).Item(10)
                        'txtUnitPrice.ReadOnly = True
                        'txtQuantity.Text = dt.Rows(0).Item(11)
                        'txtQuantity.ReadOnly = True
                        'txtReOrderPt.ReadOnly = True


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

                        Dim warehouse As String
                        warehouse = dt.Rows(0).Item(13)
                        drpWarehouse.SelectedValue = warehouse

                        txtSellectDate.Text = dt.Rows(0).Item(15)
                        btnSave.Enabled = True
                        '   btnCancel.enabled = False
                    Else
                        txtItemDesc1.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                        txtItemDesc1.ReadOnly = False
                        txtBrandName1.Text = obj.GetValue("select Brand From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                        txtBrandName1.ReadOnly = False
                        txtSize.Text = obj.GetValue("select size From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                        txtSize.ReadOnly = False
                        txtColor.Text = obj.GetValue("select color From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                        txtColor.ReadOnly = False
                        txtDepRate1.ReadOnly = False

                        txtCategory.ReadOnly = False
                        txtLenght.ReadOnly = False
                        txtWidth.ReadOnly = False
                        txtHeight.ReadOnly = False
                        txtWeight.ReadOnly = False
                        txtDepValue1.ReadOnly = False
                        txtUnitPrice.Text = obj.GetValue("select " & CY & " From dbo.m_item_detail where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                        txtUnitPrice.ReadOnly = False
                        txtQuantity.ReadOnly = False

                    End If

                Else
                    txtItemDesc1.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                    txtItemDesc1.ReadOnly = False
                    txtBrandName1.Text = obj.GetValue("select Brand From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                    txtBrandName1.ReadOnly = False
                    txtSize.Text = obj.GetValue("select size From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                    txtSize.ReadOnly = False
                    txtColor.Text = obj.GetValue("select color From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                    txtColor.ReadOnly = False
                    txtDepRate1.ReadOnly = False

                    txtCategory.ReadOnly = False
                    txtLenght.ReadOnly = False
                    txtWidth.ReadOnly = False
                    txtHeight.ReadOnly = False
                    txtWeight.ReadOnly = False
                    txtDepValue1.ReadOnly = False
                    txtUnitPrice.Text = obj.GetValue("select " & CY & " From dbo.m_item_detail where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
                    txtUnitPrice.ReadOnly = False
                    txtQuantity.ReadOnly = False

                    btnSave.Enabled = True
                    btnCancel.Enabled = True
                End If


            End If






        End If


        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_StockSupplies_Batches] '" & ddGlAccount.SelectedValue() & "','" & itemID & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatable2(3 - dtStock.Rows.Count))
        End If
        grdsupplies.DataSource = dtStock
        grdsupplies.DataBind()
        grdsupplies.SelectedIndex = -1


    End Sub
    Protected Sub LoadSuppliesBatches()
        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("select *  from [dbo].[View_StockMedicineBatches] where  Item_ID = '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatable2(3 - dtStock.Rows.Count))
            grdsupplies.DataSource = dtStock
            grdsupplies.DataBind()
            grdsupplies.SelectedIndex = 0
            loadStockDetails()
        End If
    End Sub
    Protected Sub loadStockDetails()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("Exec [AMS].[sp_StockSupplyDetails] '" & grdStockList.SelectedDataKey("GA_ID") & "','" & grdsupplies.SelectedDataKey("Received_ID") & "','" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dt.Rows.Count = 0 Then
            lnksupplieroffice.Text = ""
            txtItemDesc1.Text = ""
            txtBrandName1.Text = ""
            txtSize.Text = ""
            txtColor.Text = ""
            txtDepRate1.Text = ""

            txtCategory.Text = ""
            txtLenght.Text = ""
            txtWidth.Text = ""
            txtHeight.Text = ""
            txtWeight.Text = ""
            'txtDepValue1.Text = ""
            'lnksuppliermed.Text = ""
            txtItemDesc2.Text = ""
            'txtBrandName2.Text = ""
            txtDose.Text = ""
            txtForm.Text = ""
            txtOTC.Text = ""
            txtBatch.Text = ""
            txtLot.Text = ""
            txtMDate.Text = ""
            txtEDate.Text = ""
            txtAlert.Text = ""

        Else
            If grdStockList.SelectedDataKey("GA_ID") = 1427 Then

                lnksupplieroffice.Text = dt.Rows(0).Item("SuppName").ToString
                txtItemDesc1.Text = dt.Rows(0).Item("Description").ToString
                txtBrandName1.Text = dt.Rows(0).Item("BrandName").ToString
                txtSize.Text = dt.Rows(0).Item("Size").ToString
                txtColor.Text = dt.Rows(0).Item("Color").ToString
                txtDepRate1.Text = dt.Rows(0).Item("DepreciatedRate").ToString

                txtCategory.Text = dt.Rows(0).Item("Category").ToString
                txtLenght.Text = dt.Rows(0).Item("Length").ToString
                txtWidth.Text = dt.Rows(0).Item("Width").ToString
                txtHeight.Text = dt.Rows(0).Item("Height").ToString
                txtWeight.Text = dt.Rows(0).Item("Weight").ToString
                txtDepValue1.Text = dt.Rows(0).Item("depreciatedvalue").ToString

                Session("StockID") = dt.Rows(0).Item("StockID").ToString

                'If dt.Rows.Count = 0 Then
                '    lblofficesuppliesitemdescription.Text = ""
                '    lblofficesuppliesbrandname.Text = ""
                '    lnksupplieroffice.Text = ""
                '    lblofficesuppliessize.Text = ""
                '    lblofficesuppliescolor.Text = ""
                '    lblofficesuppliesdepreciatedRate.Text = ""
                '    lblofficesuppliescategory.Text = ""
                '    lblofficesupplieslength.Text = ""
                '    lblofficesupplieswidth.Text = ""
                '    lblofficesuppliesheight.Text = ""
                '    lblofficesupplieswieght.Text = ""
                '    lblofficesuppliesdepreciatedvalue.Text = ""
                'Else
                '    lblofficesuppliesitemdescription.Text = dt.Rows(0).Item("Description").ToString
                '    lblofficesuppliesbrandname.Text = dt.Rows(0).Item("BrandName").ToString
                '    lnksupplieroffice.Text = dt.Rows(0).Item("SuppName").ToString
                '    lblofficesuppliessize.Text = dt.Rows(0).Item("Size").ToString
                '    lblofficesuppliescolor.Text = dt.Rows(0).Item("Color").ToString
                '    lblofficesuppliesdepreciatedRate.Text = dt.Rows(0).Item("DepreciatedRate").ToString
                '    lblofficesuppliescategory.Text = dt.Rows(0).Item("Category").ToString
                '    lblofficesupplieslength.Text = dt.Rows(0).Item("Length").ToString
                '    lblofficesupplieswidth.Text = dt.Rows(0).Item("Width").ToString
                '    lblofficesuppliesheight.Text = dt.Rows(0).Item("Height").ToString
                '    lblofficesupplieswieght.Text = dt.Rows(0).Item("Weight").ToString
                '    lblofficesuppliesdepreciatedvalue.Text = dt.Rows(0).Item("depreciatedvalue").ToString

                'End If

            Else

                lnksuppliermed.Text = dt.Rows(0).Item("SuppName").ToString
                txtItemDesc2.Text = dt.Rows(0).Item("Item_Desc").ToString
                txtBrandName2.Text = dt.Rows(0).Item("BrandName").ToString
                txtDose.Text = dt.Rows(0).Item("Dose").ToString
                'txtDepRate.Text = dt.Rows(0).Item("Depreciationrate").ToString
                'txtDepValue.Text = dt.Rows(0).Item("Depreciationvalue").ToString

                txtForm.Text = dt.Rows(0).Item("Form").ToString
                txtOTC.Text = dt.Rows(0).Item("OTCRx").ToString
                txtBatch.Text = dt.Rows(0).Item("Batch").ToString
                txtLot.Text = dt.Rows(0).Item("Lot").ToString
                txtMDate.Text = dt.Rows(0).Item("Mftgdate").ToString
                txtEDate.Text = dt.Rows(0).Item("EpiryDate").ToString
                txtAlert.Text = dt.Rows(0).Item("Alert").ToString

                Session("StockID") = dt.Rows(0).Item("StockID").ToString

                'If dt.Rows.Count = 0 Then
                '    lblItem_Desc.Text = ""
                '    lblName.Text = ""
                '    lnksuppliermed.Text = ""
                '    lblDose.Text = ""
                '    lblDepRate.Text = ""
                '    lblDepValue.Text = ""
                '    lblForm.Text = ""
                '    lblLot.Text = ""
                '    lblQTC.Text = ""
                '    lblMftg.Text = ""
                '    lblBatch.Text = ""
                '    lblExpire.Text = ""
                '    lblAlert.Text = ""
                'Else
                '    If grdsupplies.SelectedDataKey("GA_ID") = 1432 Or grdsupplies.SelectedDataKey("GA_ID") = 1433 Then
                '        lblDose.Text = dt.Rows(0).Item("Dose").ToString
                '    Else
                '        lblDose.Text = "NA"
                '    End If
                '    lblItem_Desc.Text = dt.Rows(0).Item("Item_Desc").ToString
                '    lblName.Text = dt.Rows(0).Item("BrandName").ToString
                '    lnksuppliermed.Text = dt.Rows(0).Item("SuppName").ToString
                '    lblDepRate.Text = dt.Rows(0).Item("Depreciationrate").ToString
                '    lblDepValue.Text = dt.Rows(0).Item("Depreciationvalue").ToString
                '    lblForm.Text = dt.Rows(0).Item("Form").ToString
                '    lblQTC.Text = dt.Rows(0).Item("OTCRx").ToString
                '    lblLot.Text = dt.Rows(0).Item("Lot").ToString
                '    lblMftg.Text = dt.Rows(0).Item("Mftgdate").ToString
                '    lblBatch.Text = dt.Rows(0).Item("Batch").ToString
                '    lblExpire.Text = dt.Rows(0).Item("EpiryDate").ToString
                '    lblAlert.Text = dt.Rows(0).Item("Alert").ToString
                'End If
            End If
        End If

    End Sub

    Protected Sub grdmedicalsupplies_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdsupplies, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdmedicalsupplies_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        loadStockDetails()
    End Sub

    Protected Sub ledger()

        txtBinElectrical.Text = String.Empty
        txtBinMedical.Text = String.Empty
        txtBin.Text = String.Empty

        If hdnItemNo.Value = "" Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] null", CommandType.Text)
        Else
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
        End If

        Button4.Text = "SAVE"
        btnUpdateDetails2.Text = "SAVE"


        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
        End If
        grdLedger.DataSource = dtStock
        grdLedger.DataBind()

    End Sub
    Protected Sub grdMedicalSupplyLedger_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
        End If
    End Sub

    ' ==== Link to Supplier Card ====
    Protected Sub lnksuppliermed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnksuppliermed.Click
        Session("Action") = "Search"
        Session("SupplierName") = lnksuppliermed.Text
        Page.Response.Redirect("~/Records/SupplierCard.aspx")
    End Sub
    Protected Sub lnksupplieroffice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnksupplieroffice.Click
        Session("Action") = "Search"
        Session("SupplierName") = lnksupplieroffice.Text
        Page.Response.Redirect("~/Records/SupplierCard.aspx")
    End Sub
    Protected Sub LoadSupplies()
        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [dbo].[sp_SMSSStockSupplies] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        If dtStock.Rows.Count = 0 Then
            grdStockList.DataSource = createdatatableStock(8)
            grdStockList.DataBind()

            grdsupplies.DataSource = createdatatableMedicine(3)
            grdsupplies.DataBind()

            grdLedger.DataSource = createdatatableledger(5)
            grdLedger.DataBind()

            'lblItem_Desc.Text = ""
            'lblName.Text = ""
            'lnksuppliermed.Text = ""
            'lblDose.Text = ""
            'lblDepRate.Text = ""
            'lblDepValue.Text = ""
            'lblForm.Text = ""
            'lblLot.Text = ""
            'lblMftg.Text = ""
            'lblBatch.Text = ""
            'lblLot.Text = ""
            'lblExpire.Text = ""
            'lblAlert.Text = ""

        Else
            If dtStock.Rows.Count < 10 Then
                dtStock.Merge(createdatatable1B(9 - dtStock.Rows.Count))
            End If
            grdStockList.DataSource = dtStock
            grdStockList.DataBind()
            grdStockList.SelectedIndex = 0

            LoadStockGridBatches()

            Dim dtStockLedger As New DataTable
            dtStockLedger = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            If dtStockLedger.Rows.Count < 10 Then
                dtStockLedger.Merge(createdatatableledger(9 - dtStockLedger.Rows.Count))
            End If
            grdLedger.DataSource = dtStockLedger
            grdLedger.DataBind()

        End If

    End Sub



    ' ===== CreateDataTable =====
    Public Function createdatatableSupp(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("QtyPerBox", GetType(Long))
        dt.Columns.Add("totalpcs", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("serialno", GetType(String))
        dt.Columns.Add("PO_Date", GetType(Date))
        dt.Columns.Add("AcquisitionCost", GetType(Decimal))
        dt.Columns.Add("marketvalue", GetType(Decimal))
        dt.Columns.Add("location", GetType(String))
        dt.Columns.Add("status", GetType(String))
        dt.Columns.Add("RespCenter", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("price", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Unit") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("QtyPerBox") = DBNull.Value
            dr("totalpcs") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("serialno") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("AcquisitionCost") = DBNull.Value
            dr("marketvalue") = DBNull.Value
            dr("location") = DBNull.Value
            dr("status") = DBNull.Value
            dr("RespCenter") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("price") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("StockID", GetType(String))
        dt.Columns.Add("ItemNo", GetType(Integer))
        dt.Columns.Add("itemdesc", GetType(String))
        dt.Columns.Add("unit", GetType(String))
        dt.Columns.Add("balqty", GetType(Long))
        dt.Columns.Add("noofordersyear", GetType(String))
        dt.Columns.Add("minQty", GetType(Long))
        dt.Columns.Add("reorderpt", GetType(Integer))
        dt.Columns.Add("location", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_ID") = DBNull.Value
            dr("StockID") = DBNull.Value
            dr("ItemNo") = DBNull.Value
            dr("itemdesc") = DBNull.Value
            dr("unit") = DBNull.Value
            dr("balqty") = DBNull.Value
            dr("noofordersyear") = DBNull.Value
            dr("minQty") = DBNull.Value
            dr("reorderpt") = DBNull.Value
            dr("location") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
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
    Public Function createdatatableStock(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("reorderPT", GetType(Integer))
        dt.Columns.Add("GA_ID", GetType(Long))
        dt.Columns.Add("Location", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_ID") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("reorderPT") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("Location") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
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

    Protected Sub grdsupplies_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_StockSupplies_Batches] '" & grdStockList.SelectedDataKey("GA_ID") & "','" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatable2(3 - dtStock.Rows.Count))
        End If
        grdsupplies.SelectedIndex = e.NewPageIndex
        grdsupplies.DataSource = dtStock
        grdsupplies.DataBind()

    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Item_ID") = drpItemDesc1.SelectedItem.Value
        Me.Page.Response.Redirect("~/Records/rpt_stockcard.aspx")
    End Sub

    Protected Sub loadCleartext()
        lnksupplieroffice.Text = ""
        txtItemDesc1.Text = ""
        txtBrandName1.Text = ""
        txtSize.Text = ""
        txtColor.Text = ""
        txtDepRate1.Text = ""

        txtCategory.Text = ""
        txtLenght.Text = ""
        txtWidth.Text = ""
        txtHeight.Text = ""
        txtWeight.Text = ""
        txtDepValue1.Text = ""

        lnksuppliermed.Text = ""
        txtItemDesc2.Text = ""
        txtBrandName2.Text = ""
        txtDose.Text = ""
        'txtDepRate.Text = ""
        'txtDepValue.Text = ""

        txtForm.Text = ""
        txtOTC.Text = ""
        txtBatch.Text = ""
        txtLot.Text = ""
        txtMDate.Text = ""
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
        txtBinElectrical.Text = String.Empty



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
    End Sub

    Protected Sub btnEdit2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'txtItemDesc2.ReadOnly = False
        'txtBrandName2.ReadOnly = False
        'txtDose.ReadOnly = False

        'txtForm.ReadOnly = False
        'txtOTC.ReadOnly = False
        'txtBatch.ReadOnly = False
        'txtLot.ReadOnly = False
        'txtMDate.ReadOnly = False
        'txtEDate.ReadOnly = False
        'txtAlert.ReadOnly = False

        'OPTIMIZE CODE
        Dim textBoxes As TextBox() = {txtItemDesc2, txtBrandName2, txtDose, txtForm, txtOTC, txtBatch, txtLot, txtMDate, txtEDate, txtAlert}

        For Each textBox As TextBox In textBoxes
            textBox.ReadOnly = False
        Next

    End Sub

    Protected Sub btnUpdateDetails2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Session("StockID")
        If btnUpdateDetails2.Text = "SAVE" Then
            saveOfficeSuppliesMedical()
        ElseIf btnUpdateDetails2.Text = "UPDATE" Then
            UpdateMed()
        Else

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()

            ModalPopupExtender2.Show()
            hdnApproval.Value = "Med"
        End If

    End Sub

    Public Sub SaveMedicalSupplies()

    End Sub
    Public Sub UpdateMed()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT AMS.Stock.StockID, AMS.TBSupplies_Info.SuppliesId, AMS.TbNonFood.NonFood_ID, AMS.TbStock_Ledger.StockLedger_ID " &
                         "FROM AMS.TBSupplies_Info INNER JOIN " &
                         "AMS.TbNonFood ON AMS.TBSupplies_Info.StockID = AMS.TbNonFood.StockId INNER JOIN " &
                         "AMS.Stock ON AMS.TBSupplies_Info.StockID = AMS.Stock.StockID INNER JOIN " &
                         "AMS.TbStock_Ledger ON AMS.TbNonFood.StockId = AMS.TbStock_Ledger.StockID " &
                         "WHERE AMS.TbNonFood.Item_ID = " & hdnItemNo.Value, CommandType.Text)


        Dim locations As String

        If txtBayMedical.Text <> "" Then
            locations = "Bay-" & txtBayMedical.Text
        End If

        If txtColumnMedical.Text <> "" Then
            locations = locations + " " + "Column-" & txtColumnMedical.Text
        End If

        If txtFloorMedical.Text <> "" Then
            locations = locations + " " + "Floor-" & txtFloorMedical.Text
        End If

        If txtRoodMedical.Text <> "" Then
            locations = locations + " " + "Room-" & txtRoodMedical.Text
        End If

        If txtShelvesMedical.Text <> "" Then
            locations = locations + " " + "Shelves-" & txtShelvesMedical.Text
        End If

        If txtRackMedical.Text <> "" Then
            locations = locations + " " + "Rack-" & txtRackMedical.Text
        End If

        If txtBinMedical.Text <> "" Then
            locations = locations + " " + "Bin-" & txtBinMedical.Text
        End If


        For i As Integer = 0 To grdLedger.Rows.Count - 1
            Dim cb1 As CheckBox = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

            If cb1.Visible AndAlso cb1.Checked Then

                If dt.Rows.Count > 0 Then
                    Dim stockID As String = dt.Rows(i).Item("StockID").ToString()

                    objDerived.GetRecords("UPDATE [AMS].[TBSupplies_Info] SET [BrandName] = '" & txtBrandName2.Text & "' " +
                                    " ,[Size] = '" & txtSizeMed.Text & "' ,[Color] = '" & txtColorMed.Text & "' " +
                                    " ,[Dose] = '" & txtDose.Text & "' " +
                                    " ,[Description] = '" & txtItemDesc2.Text & "' " +
                                    " WHERE SuppliesId = '" & dt.Rows(0).Item("SuppliesId").ToString & "'", CommandType.Text)


                    'Todo might be wrong dropdown warehouse
                    objDerived.GetRecords("UPDATE [AMS].[Stock] " +
                                                " SET [StockDate] = '" & txtDateMed.Text & "' " +
                                                " ,[Qty] = '" & txtQuantityMed.Text & "' " +
                                                " ,[Cost] = '" & txtUnitCostMed.Text.Replace(",", "") & "' " +
                                                " ,[Location] = '" & locations & "' " +
                                                " ,[Batch] = '" & txtBatch.Text & "' " +
                                                " ,[Expiration_Date] = '" & txtEDate.Text & "' " +
                                                " ,[Alert] = '" & txtAlert.Text & "' " +
                                                " ,[ReorderPt] = '" & txtReorderPointMed.Text & "' " +
                                                " ,[warehouse_ID] = '" & drpWarehouse.SelectedValue() & "' " +
                                                " WHERE StockID = '" & stockID & "'", CommandType.Text)


                    objDerived.GetRecords("UPDATE [AMS].[TbNonFood] " +
                                                    " SET [Form] = '" & txtForm.Text & "' " +
                                                    " ,[OTCRx] = '" & txtOTC.Text & "' " +
                                                    " ,[Mftgdate] = '" & txtMDate.Text & "' " +
                                                    " ,[Batch] = '" & txtBatch.Text & "' " +
                                                    " ,[Lot] = '" & txtLot.Text & "' " +
                                                    " ,[EpiryDate] = '" & txtEDate.Text & "' " +
                                                    " ,[Alert] = '" & txtAlert.Text & "' " +
                                                    " ,[ItemDesc] = '" & txtItemDesc2.Text & "' " +
                                                    " ,[BrandName] = '" & txtBrandName2.Text & "' " +
                                                    " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)



                    Dim qty As Decimal
                    Dim unitPrice As Decimal

                    ' Check if the values are numeric and convert them
                    If IsNumeric(txtQuantityMed.Text) AndAlso IsNumeric(txtUnitCostMed.Text) Then
                        qty = CDec(txtQuantityMed.Text)
                        unitPrice = CDec(txtUnitCostMed.Text)

                        ' Proceed with the SQL query
                        objDerived.GetRecords("UPDATE [AMS].[TbStock_Ledger] " +
                                                " SET DebitUnit = '" & drpUnitMed.SelectedItem.Text & "', " &
                                                " [DebitQty] = '" & qty & "', " &
                                                " [DebitCost] = '" & (qty * unitPrice) & "', " &
                                                " BalanceUnit = '" & drpUnitMed.SelectedItem.Text & "', " &
                                                " dDate = '" & txtDateMed.Text & "', " &
                                                " BalanceCost = (SELECT TOP 1 BalanceCost FROM AMS.TbStock_Ledger WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "' ORDER BY StockLedger_ID DESC) " &
                                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "'", CommandType.Text)
                    Else
                        ' Handle the case where the input is not valid (e.g., show an error message)
                    End If
                End If
            End If
        Next




        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        btnUpdateDetails2.Text = "EDIT"
        Med()
        ledger()
        RetriveMed()
    End Sub
    Protected Sub btnCancel2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        loadStockDetails()

        txtItemDesc2.ReadOnly = True
        txtBrandName2.ReadOnly = True
        txtDose.ReadOnly = True
        'txtDepRate.ReadOnly = True
        'txtDepValue.ReadOnly = True

        txtForm.ReadOnly = True
        txtOTC.ReadOnly = True
        txtBatch.ReadOnly = True
        txtLot.ReadOnly = True
        txtMDate.ReadOnly = True
        txtEDate.ReadOnly = True
        txtAlert.ReadOnly = True
    End Sub

    Protected Sub btnEdit1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'txtItemDesc1.ReadOnly = False
        'txtBrandName1.ReadOnly = False
        'txtSize.ReadOnly = False
        'txtColor.ReadOnly = False
        'txtDepRate1.ReadOnly = False

        'txtCategory.ReadOnly = False
        'txtLenght.ReadOnly = False
        'txtWidth.ReadOnly = False
        'txtHeight.ReadOnly = False
        'txtWeight.ReadOnly = False
        'txtDepValue1.ReadOnly = False


        'optimize code

        Dim controls As Control() = {txtItemDesc1, txtBrandName1, txtSize, txtColor, txtDepRate1, txtCategory, txtLenght, txtWidth, txtHeight, txtWeight, txtDepValue1}

        For Each control As Control In controls
            If TypeOf control Is TextBox Then
                Dim textBox As TextBox = DirectCast(control, TextBox)
                textBox.ReadOnly = False
            End If
        Next


    End Sub

    Protected Sub btnUpdate1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            'objDerived.GetRecords("UPDATE [AMS].[TBSupplies_Info] " +
            '                        " SET [Description] = '" & txtItemDesc1.Text & "' " +
            '                        " ,[BrandName] = '" & txtBrandName1.Text & "' " +
            '                        " ,[Size] = '" & txtSize.Text & "' " +
            '                        " ,[Color] = '" & txtColor.Text & "' " +
            '                        " ,[Category] = '" & txtCategory.Text & "' " +
            '                        " ,[Length] = '" & txtLenght.Text & "' " +
            '                        " ,[Width] = '" & txtWidth.Text & "' " +
            '                        " ,[Height] = '" & txtHeight.Text & "' " +
            '                        " ,[Weight] = '" & txtWeight.Text & "' " +
            '                        " ,[DepreciatedValue] = '" & txtDepValue1.Text & "' " +
            '                        " ,[DepreciatedRate] = '" & txtDepRate1.Text & "' " +
            '                        " WHERE StockID = '" & Session("StockID") & "' AND ItemId = '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)

            ' MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            loadStockDetails()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error occured, pls contact administrator.")
        End Try
    End Sub

    Protected Sub btnCancel1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        loadStockDetails()

        'txtItemDesc1.ReadOnly = True
        'txtBrandName1.ReadOnly = True
        'txtSize.ReadOnly = True
        'txtColor.ReadOnly = True
        'txtDepRate1.ReadOnly = True

        'txtCategory.ReadOnly = True
        'txtLenght.ReadOnly = True
        'txtWidth.ReadOnly = True
        'txtHeight.ReadOnly = True
        'txtWeight.ReadOnly = True
        'txtDepValue1.ReadOnly = True
        'txtUnitPrice.ReadOnly = True
        'txtQuantity.Text = True

        'optimize
        Dim readOnlyFields() As TextBox = {txtItemDesc1, txtBrandName1, txtSize, txtColor, txtDepRate1, txtCategory, txtLenght, txtWidth, txtHeight, txtWeight, txtDepValue1, txtUnitPrice}
        For Each field As TextBox In readOnlyFields
            field.ReadOnly = True
        Next

        txtQuantity.ReadOnly = True

    End Sub

    Dim rcv As New Receiving.t_receiving

    Public Sub saveOfficeSupplies()
        'Try

        ' --- Start of method tracer
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog1",
                                        "console.log('saveOfficeSupplies: Method start');", True)

        ' 1) Check required fields
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog2",
                                        "console.log('Checking required fields for Name / Brand Name / Unit Cost / Quantity / ROP / SelectDate');",
                                        True)
        If String.IsNullOrEmpty(txtBrandName1.Text) OrElse
       String.IsNullOrEmpty(txtUnitPrice.Text) OrElse
       String.IsNullOrEmpty(txtQuantity.Text) OrElse
       String.IsNullOrEmpty(txtReOrderPt.Text) OrElse
       String.IsNullOrEmpty(txtSellectDate.Text) Then

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog3",
                                            "console.log('Missing required fields. Exiting function.');", True)
            Return
        End If

        ' 2) Safely parse numeric fields
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

        ' 3) Update m_item's unit_id
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog4",
                "console.log('Updating dbo.m_item with unit_id = " & drpUnit.SelectedItem.Value & "');", True)
        objDerived.Execute("UPDATE dbo.m_item SET unit_id = " & drpUnit.SelectedItem.Value &
                       " WHERE item_id = " & hdnItemNo.Value, CommandType.Text)

        ' 4) Gather classification, category, matrix
        Dim classification As String =
        objDerived.GetValue("SELECT classificationid FROM dbo.tbl_Classification " &
                            "WHERE ClassificationName LIKE '%Supplies%' ", CommandType.Text)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog5",
                                        "console.log('classification ID: " & classification & "');", True)

        Dim category As Integer =
        objDerived.GetValue("SELECT a.item_particular_id " &
                            "FROM dbo.m_item AS a INNER JOIN ams.item_particular AS b ON a.item_particular_id = b.item_particular_id " &
                            "WHERE a.Item_ID = " & hdnItemNo.Value, CommandType.Text)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog6",
                                        "console.log('category ID: " & category & "');", True)

        Dim matrix As String =
        objDerived.GetValue("SELECT id FROM tblclassmatrix " &
                            "WHERE classificationid = " & classification &
                            " AND ga_id = " & hdnGAId.Value &
                            " AND item_id = " & hdnItemNo.Value, CommandType.Text)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog7",
                                        "console.log('matrix ID: " & matrix & "');", True)

        If String.IsNullOrEmpty(matrix) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog8",
            "console.log('Inserting into tblclassmatrix => classification=" & classification &
            ", ga_id=" & hdnGAId.Value & "');", True)

            objDerived.Execute("INSERT INTO tblclassmatrix(classificationid, ga_id, item_id, categoryid, bga_id) " &
                           "VALUES('" & classification & "','" & hdnGAId.Value & "','" & hdnItemNo.Value & "','" & category & "','0')",
                           CommandType.Text)
        End If

        ' 5) SAVE AMS.Tb_Receiving
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog9",
                                        "console.log('Saving to AMS.Tb_Receiving');", True)
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
        Dim rcvID As Long = rcv.save()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog10",
                                        "console.log('AMS.Tb_Receiving saved. rcvID=' + " & rcvID & ");", True)
        Session("Received_ID") = rcvID

        ' 6) Loop to save AMS.Tb_Receiving_Dtl
        Dim rcv_dtl As New Receiving.t_receiving_dtl
        Dim total As Decimal = 0

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog11",
                "console.log('Begin loop for AMS.Tb_Receiving_Dtl');", True)

        ' If you truly want to loop pItems, do: For i As Integer = 0 To pItems.Rows.Count - 1
        ' Otherwise, you're only looping once
        For i As Integer = 0 To 0
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog12",
            "console.log('Index i=' + " & i & " + ' in AMS.Tb_Receiving_Dtl loop');", True)

            ' Build location
            Dim locationBuilder As New System.Text.StringBuilder()
            If Not String.IsNullOrEmpty(txtBay.Text) Then locationBuilder.Append("Bay-").Append(txtBay.Text)
            If Not String.IsNullOrEmpty(txtColumn.Text) Then locationBuilder.Append(" Column-").Append(txtColumn.Text)
            If Not String.IsNullOrEmpty(txtFloor.Text) Then locationBuilder.Append(" Floor-").Append(txtFloor.Text)
            If Not String.IsNullOrEmpty(txtRoom.Text) Then locationBuilder.Append(" Room-").Append(txtRoom.Text)
            If Not String.IsNullOrEmpty(txtShelves.Text) Then locationBuilder.Append(" Shelves-").Append(txtShelves.Text)
            If Not String.IsNullOrEmpty(txtRack.Text) Then locationBuilder.Append(" Rack-").Append(txtRack.Text)
            If Not String.IsNullOrEmpty(txtBin.Text) Then locationBuilder.Append(" Bin-").Append(txtBin.Text)

            Dim location As String = locationBuilder.ToString()

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog13",
            "console.log('Saving AMS.Tb_Receiving_Dtl with location=' + '" & location & "');", True)

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
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog14",
            "console.log('AMS.Tb_Receiving_Dtl record saved. RcvDtl_ID=' + " & RcvDtl_ID & ");", True)

            If RcvDtl_ID <= 0 Then
                Throw New Exception("Failed to save Tb_Receiving_Dtl.")
            End If

            total += (qtyValue * unitPriceValue)
        Next

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog15",
        "console.log('Receiving_Dtl loop ended. total=' + " & total & ");", True)
        Session("ContractPrice") = total

        ' 7) SAVE OF PURCHASED ORDER
        Dim pohdr_id As Long
        Dim POnumber As String = "Starting Inventory"
        Dim POhdr As New t_purchase_order_hdr

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog16",
        "console.log('Preparing t_purchase_order_hdr with PO_No=" & POnumber & "');", True)

        ' If your page or code-behind does NOT have a control named txtContractprice,
        ' you MUST remove or handle it conditionally to avoid NullReferenceException.
        Dim contractPriceDecimal As Decimal = 0
        Dim contractPriceExists As Boolean = (Me.FindControl("txtContractprice") IsNot Nothing)

        If contractPriceExists Then
            Dim ctrl As TextBox = CType(Me.FindControl("txtContractprice"), TextBox)
            If ctrl IsNot Nothing AndAlso Not String.IsNullOrEmpty(ctrl.Text) AndAlso IsNumeric(ctrl.Text) Then
                contractPriceDecimal = Convert.ToDecimal(ctrl.Text)
            Else
                ' fallback to what was in Session("ContractPrice")
                contractPriceDecimal = Convert.ToDecimal(Session("ContractPrice"))
            End If
        Else
            ' fallback if there's no txtContractprice control
            contractPriceDecimal = Convert.ToDecimal(Session("ContractPrice"))
        End If

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
            .ContractPrice = contractPriceDecimal
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

        ' Check if PO exists in ams.po_hdr
        Dim po_id As DataTable =
        objDerived.GetDataTable("SELECT pohdr_id FROM ams.po_hdr " &
                                "WHERE po_no LIKE '" & POnumber & "' AND Supplier_ID = '0'",
                                CommandType.Text)

        If po_id.Rows.Count = 0 Then
            ' No existing PO
            POhdr.ContractPrice = Convert.ToDecimal(Session("ContractPrice"))
            pohdr_id = POhdr.save()
        Else
            ' existing PO
            Dim poid As Integer =
            objDerived.GetValue("SELECT pohdr_id FROM ams.po_hdr " &
                                "WHERE po_no LIKE '" & POnumber & "' AND Supplier_ID = '0'",
                                CommandType.Text)
            Dim TAmount As Decimal =
            objDerived.GetValue("SELECT ContractPrice FROM ams.po_hdr " &
                                "WHERE pohdr_id = '" & poid & "'",
                                CommandType.Text)

            POhdr.ContractPrice = TAmount + Convert.ToDecimal(Session("ContractPrice"))
            POhdr.POHdr_ID = poid
            pohdr_id = POhdr.update()
        End If

        objDerived.GetRecords("UPDATE AMS.PO_Hdr " &
                          "SET GA_ID = '" & hdnGAId.Value & "', ProjectName = 'Manual Encode' " &
                          "WHERE POHdr_ID = '" & pohdr_id & "'",
                          CommandType.Text)
        Session("POHdr_ID") = pohdr_id

        ' 8) SAVE OF INSPECTION & ACCEPTANCE
        Dim objhdr As New t_inspection_and_acceptance_hdr
        Dim airhdr_id As Long
        Dim air As String

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog22",
        "console.log('Generating AIR No. using [AMS].[func_GenerateAIR]');", True)
        air = objDerived.GetValue("SELECT [AMS].[func_GenerateAIR]('" & txtDate.Text & "')",
                              CommandType.Text)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog23",
        "console.log('AIR generated: " & air & "');", True)

        With objhdr
            .AIR_No = air
            .AIR_Date = DateTime.Parse(txtDate.Text)
            .Date_Received = DateTime.Parse(txtDate.Text)
            .Date_Inspect = DateTime.Parse(txtDate.Text)
            .Date_Accepted = DateTime.Parse(txtDate.Text)
            .Invoice_No = " "
            .Invoice_date = DateTime.Parse(txtDate.Text)
            .PO_No = POnumber
            .Supplier_ID = 0
            .Signatory1 = " "
            .Signatory2 = " "
            .Signatory3 = " "
            .isComplete = True
            .POHdr_ID = Session("POHdr_ID")
            .RC_ID = 0
            .Function_ID = 0

            ' If you have a txtIAremarks control:
            If txtIAremarks IsNot Nothing Then
                .remarks = txtIAremarks.Text
            End If
        End With

        airhdr_id = objhdr.save()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog24",
        "console.log('AIR_Hdr saved. airhdr_id=' + " & airhdr_id & ");", True)
        Session("AIRHDR_ID") = airhdr_id

        objDerived.GetRecords("UPDATE AMS.AIR_Hdr " &
                          "SET UserID = '" & Session("@UserName") & "', Received_ID = '" & Session("Received_ID") & "'" &
                          " WHERE AIRHdr_ID = '" & Session("AIRHDR_ID") & "'", CommandType.Text)

        Dim objdtl As New t_inspection_and_acceptance_dtl

        ' 9) PO Details Save
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog25",
        "console.log('Saving t_purchase_order_dtl');", True)

        Dim POdtl As New t_purchase_order_dtl
        POdtl.POHdr_ID = Session("POHdr_ID")
        POdtl.Item_ID = hdnItemNo.Value
        POdtl.cost = txtUnitPrice.Text
        POdtl.qty = txtQuantity.Text
        POdtl.remarks = "Manual Encode"
        POdtl.save()

        ' =-=- AIR DETAILS
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog26",
        "console.log('Saving t_inspection_and_acceptance_dtl');", True)
        objdtl.Item_ID = hdnItemNo.Value
        objdtl.Qty = txtQuantity.Text
        objdtl.Cost = CType(txtUnitPrice.Text, Decimal)
        objdtl.AIRHdr_ID = Session("AIRHDR_ID")
        objdtl.GA_ID = hdnGAId.Value
        Dim iaDtl_ID As Integer = objdtl.save()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog27",
        "console.log('AIR_Dtl saved. iaDtl_ID=' + " & iaDtl_ID & ");", True)

        Session("AIRDtl_ID") = iaDtl_ID

        ' 10) SAVE STOCK
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog28",
        "console.log('Saving to AMS.Stock');", True)
        Dim objStock As New Supplies_Stock

        ' warehouse parse
        Dim whVal As String = drpWarehouse.SelectedValue
        If String.IsNullOrEmpty(whVal) OrElse Not IsNumeric(whVal) Then
            whVal = "0"
        End If

        ' parse RC_ID
        Dim rcValString As String =
        objDerived.GetValue("SELECT DISTINCT [RC_id] FROM [dbo].[View_RespCenter_withFunctions] " &
                            "WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'",
                            CommandType.Text)
        Dim rcParsed As Integer = 0
        If Not String.IsNullOrEmpty(rcValString) AndAlso IsNumeric(rcValString) Then
            rcParsed = Convert.ToInt32(rcValString)
        End If

        ' parse reorder
        Dim reorderVal As Integer = 0
        If Not String.IsNullOrEmpty(txtReOrderPt.Text) AndAlso IsNumeric(txtReOrderPt.Text) Then
            reorderVal = Convert.ToInt32(txtReOrderPt.Text)
        End If

        ' Build location for Stock

        Dim sbStockLoc As New System.Text.StringBuilder()
        If Not String.IsNullOrEmpty(txtBay.Text) Then sbStockLoc.Append("Bay-").Append(txtBay.Text)
        If Not String.IsNullOrEmpty(txtColumn.Text) Then sbStockLoc.Append(" Column-").Append(txtColumn.Text)
        If Not String.IsNullOrEmpty(txtFloor.Text) Then sbStockLoc.Append(" Floor-").Append(txtFloor.Text)
        If Not String.IsNullOrEmpty(txtRoom.Text) Then sbStockLoc.Append(" Room-").Append(txtRoom.Text)
        If Not String.IsNullOrEmpty(txtShelves.Text) Then sbStockLoc.Append(" Shelves-").Append(txtShelves.Text)
        If Not String.IsNullOrEmpty(txtRack.Text) Then sbStockLoc.Append(" Rack-").Append(txtRack.Text)
        If Not String.IsNullOrEmpty(txtBin.Text) Then sbStockLoc.Append(" Bin-").Append(txtBin.Text)

        With objStock
            .StockDate = DateTime.Parse(txtDate.Text)
            .Item_ID = hdnItemNo.Value
            .Qty = txtQuantity.Text
            .Balance = txtQuantity.Text
            .Location = sbStockLoc.ToString()
            .Expiration_Date = DateTime.Parse("1/1/1900")
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
        End With

        Dim StockID As Long = objStock.save()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog29",
        "console.log('AMS.Stock saved. StockID=' + " & StockID & ");", True)
        objDerived.GetRecords("UPDATE AMS.Stock SET Received_ID = '" & rcvID & "' WHERE StockID = '" & StockID & "'",
                          CommandType.Text)

        ' 11) SAVE LEDGER
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog30",
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
            .dDate = DateTime.Parse(txtSellectDate.Text)
            .Item_ID = hdnItemNo.Value
            .DebitQty = txtQuantity.Text
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

        ' 12) TBSupplies_Info if GA_ID=1427
        If hdnGAId.Value = 1427 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog31",
            "console.log('GA_ID=1427 => Saving TBSupplies_Info');", True)

            Dim objOfficeSup As New SupplieINFO
            With objOfficeSup
                .StockID = StockID
                .AIRDtl_ID = Session("AIRDtl_ID")
                .ItemId = hdnItemNo.Value
                .Description = txtItemDesc1.Text
                .BrandName = txtBrandName1.Text
                .SupplierId = 0
                .Size = txtSize.Text
                .Color = txtColor.Text
                .Category = txtCategory.Text
                .Length = txtLenght.Text
                .Width = txtWidth.Text
                .Height = txtHeight.Text
                .Weight = txtWeight.Text
                .DepreciatedValue = txtDepRate1.Text
                .DepreciatedRate = txtDepValue1.Text
                .Status = "Accepted"
                .Received_ID = 0
                .Componentof = " "
            End With

            Dim Supp_ID As Long = objOfficeSup.save()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog32",
            "console.log('TBSupplies_Info saved. Supp_ID=' + " & Supp_ID & ");", True)

            objDerived.GetRecords("UPDATE AMS.TBSupplies_Info " &
                              "SET Received_ID = '" & rcvID & "' WHERE SuppliesId = '" & Supp_ID & "'",
                              CommandType.Text)
        End If

        ' 13) Refresh the ledger grid
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog33",
        "console.log('Calling sp_SuppliesLedger for Item_ID=' + " & hdnItemNo.Value & ");", True)
        dtStock =
        objDerived.GetDataTable("EXEC [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'",
                                CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
        End If
        grdLedger.DataSource = dtStock
        grdLedger.DataBind()

        ' Refill UI / Clear text fields if desired
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog34",
        "console.log('selectitemdesc called');", True)
        selectitemdesc()

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")

        ' 14) Check reorder point
        Dim ropVal As String =
        objDerived.GetValue("SELECT ReorderPt FROM ams.Stock WHERE Item_ID = '" & hdnItemNo.Value & "'",
                            CommandType.Text)

        Dim c As Integer = 0
        Integer.TryParse(txtQuantity.Text, c)

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog35",
            "console.log('Check ROP => ROP=' + " & ropVal & " + ', QTY=' + " & c & ");", True)

        If Not String.IsNullOrEmpty(ropVal) AndAlso IsNumeric(ropVal) Then
            If Convert.ToInt32(ropVal) >= c Then
                ModalPopupExtender3.Show()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog36",
                "console.log('ROP reached. Showing ModalPopupExtender3.');", True)
            End If
        End If

        ' End of method tracer
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog37",
        "console.log('saveOfficeSupplies: Method end');", True)

        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.Message)
        'End Try
    End Sub


    'Original codes before modification on 1/25/2025
    '    Public Sub saveOfficeSupplies()
    '        If txtItemDesc1.Text = "" Or txtBrandName1.Text = "" Or txtUnitPrice.Text = "" Or txtQuantity.Text = "" Or txtReOrderPt.Text = "" Or txtSellectDate.Text = "" Then
    '            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
    '        Else
    '            Dim unit As String = objDerived.GetValue("select unit_id From dbo.m_item where item_id = " & hdnItemNo.Value, CommandType.Text)
    '            If unit = "" Then
    '                objDerived.Execute("Update dbo.m_item set unit_id = " & drpUnit.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)
    '            End If
    '            Dim classification As String = objDerived.GetValue("select classificationid From dbo.tbl_Classification where ClassificationName like '%Supplies%' ", CommandType.Text)
    '            Dim category As Integer = objDerived.GetValue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
    '            Dim matrix As String = objDerived.GetValue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & hdnGAId.Value & " and item_id = " & hdnItemNo.Value & "", CommandType.Text)

    '            If matrix = "" Then
    '                objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id) values('" & classification & "','" & hdnGAId.Value & "','" & hdnItemNo.Value & "','" & category & "','0')", CommandType.Text)
    '            End If







    '            ORIGINAL CODE
    '            --------------------------------------------------------------
    '            =-= SAVE AMS.Tb_Receiving
    '            With rcv
    '                .Received_Date = txtDate.Text
    '                .ReceivedBY = 0
    '                .POHdr_ID = 0
    '                .PO_No = ""
    '                .Supplier_ID = 0
    '                .GA_ID = hdnGAId.Value
    '                .isAccepted = False
    '                .UserID = Session("@UserName")
    '            End With
    '            Dim rcvID As Long = rcv.save

    '            Session("Received_ID") = rcvID

    '            Dim rcv_dtl As New Receiving.t_receiving_dtl

    '            Dim total As Decimal = 0

    '            For i As Integer = 0 To pItems.Rows.Count - 1
    '                For i As Integer = 0 To 1 - 1

    '                    Dim txtPrice As TextBox = CType(txtUnitPrice, TextBox)
    '                    Dim txtqty As TextBox = CType(txtQuantity, TextBox)
    '                    Dim location As String




    '                    OPTIMIZE CODE
    '                Dim locationBuilder As New StringBuilder()

    '                    If Not String.IsNullOrEmpty(txtBay.Text) Then
    '                        locationBuilder.Append("Bay-").Append(txtBay.Text)
    '                    ElseIf Not String.IsNullOrEmpty(txtColumn.Text) Then
    '                        locationBuilder.Append("Column-").Append(txtColumn.Text)
    '                    ElseIf Not String.IsNullOrEmpty(txtFloor.Text) Then
    '                        locationBuilder.Append("Floor-").Append(txtFloor.Text)
    '                    ElseIf Not String.IsNullOrEmpty(txtRoom.Text) Then
    '                        locationBuilder.Append("Room-").Append(txtRoom.Text)
    '                    ElseIf Not String.IsNullOrEmpty(txtShelves.Text) Then
    '                        locationBuilder.Append("Shelves-").Append(txtShelves.Text)
    '                    ElseIf Not String.IsNullOrEmpty(txtRack.Text) Then
    '                        locationBuilder.Append("Rack-").Append(txtRack.Text)
    '                    ElseIf Not String.IsNullOrEmpty(txtBin.Text) Then
    '                        locationBuilder.Append("Bin-").Append(txtBin.Text)
    '                    End If

    '                    location = locationBuilder.ToString()


    '                =-= SAVE AMS.Tb_Receiving_Dtl
    '                With rcv_dtl
    '                        .Received_ID = rcvID
    '                        .Item_ID = hdnItemNo.Value
    '                        .PO_Qty = txtqty.Text
    '                        .Qty_Received = txtqty.Text
    '                        .Cost = txtPrice.Text
    '                        .Condition = ""
    '                        .Location = location
    '                    End With

    '                    Dim RcvDtl_ID As Long = rcv_dtl.save

    '                    Dim t1 As Decimal
    '                    t1 = txtPrice.Text * txtqty.Text
    '                    total = total + t1

    '                Next
    '                Session("ContractPrice") = total


    '            =-= SAVE OF PURCHASED ORDER
    '            Dim pohdr_id As Long
    '                Dim POhdr As New t_purchase_order_hdr
    '                Dim POnumber As String = "Starting Inventory"


    '                POhdr.PO_No = POnumber
    '                POhdr.PO_Date = txtDate.Text
    '                POhdr.Supplier_ID = 0
    '                POhdr.mode_of_procurement_id = 2
    '                POhdr.DeliveryTerm = 0
    '                POhdr.paymentTerm = 0
    '                POhdr.DeliveryDate = txtDate.Text
    '                POhdr.DeliveryPlace = ""
    '                POhdr.isDelivered = True
    '                POhdr.isDelivered = True
    '                POhdr.pre_procurement_hdr_id = 0
    '                POhdr.withdv = False
    '                POhdr.ContractPrice = CType(txtContractprice.Text, Decimal)
    '                POhdr.isStag = False
    '                POhdr.isContinueCutOff = False
    '                POhdr.isStopForCutOff = False
    '                POhdr.isShoppingA = False
    '                POhdr.isPublicInfra = False
    '                POhdr.isStraight = True
    '                POhdr.isApproved_PO_Mayor = True
    '                POhdr.isReceived_PO_Mayor = True
    '                POhdr.DateApproved_PO_Mayor = txtDate.Text
    '                POhdr.DateReceived_PO_Mayor = txtDate.Text
    '                POhdr.DateDisApprove = "01/01/1900"
    '                POhdr.isGasoline = False
    '                POhdr.isReimbursement = False

    '                Dim po_id As New DataTable
    '                po_id = objDerived.GetDataTable("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
    '                If po_id.Rows.Count = 0 Then
    '                    POhdr.ContractPrice = CType(Session("ContractPrice"), Decimal)
    '                    pohdr_id = POhdr.save()
    '                Else
    '                    Dim poid As Integer
    '                    Dim TAmount As Decimal
    '                    poid = objDerived.GetValue("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
    '                    TAmount = objDerived.GetValue("Select ContractPrice from ams.po_hdr where pohdr_id = '" & poid & "'", CommandType.Text)

    '                    POhdr.ContractPrice = CType(TAmount + CType(Session("ContractPrice"), Decimal), Decimal)
    '                    POhdr.POHdr_ID = poid
    '                    pohdr_id = POhdr.update()
    '                End If

    '                objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = '" & hdnGAId.Value & "', ProjectName = 'Manual Encode' WHERE POHdr_ID = '" & pohdr_id & "'", CommandType.Text)
    '                Session("POHdr_ID") = pohdr_id



    '            =-= SAVE OF INSPECTION & ACCEPTANCE
    '            Dim objhdr As New t_inspection_and_acceptance_hdr

    '                Dim airhdr_id As Long
    '                Dim air As String
    '                air = objDerived.GetValue("select [AMS].[func_GenerateAIR]('" & txtDate.Text & "')", CommandType.Text)

    '                With objhdr
    '                    .AIR_No = air
    '                    .AIR_Date = DateTime.Parse(txtDate.Text)
    '                    .Date_Received = DateTime.Parse(txtDate.Text)
    '                    .Date_Inspect = DateTime.Parse(txtDate.Text)
    '                    .Date_Accepted = DateTime.Parse(txtDate.Text)
    '                    .Invoice_No = " "
    '                    .Invoice_date = DateTime.Parse(txtDate.Text)
    '                    .PO_No = POnumber
    '                    .Supplier_ID = 0
    '                    .Signatory1 = " "
    '                    .Signatory2 = " "
    '                    .Signatory3 = " "
    '                    .isComplete = True
    '                    .POHdr_ID = Session("POHdr_ID")
    '                    objhdr.remarks = txtIAremarks.Text
    '                    .RC_ID = 0
    '                    .Function_ID = 0
    '                End With
    '                airhdr_id = objhdr.save()
    '                Session("AIRHDR_ID") = airhdr_id
    '                objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET UserID = '" & Session("@UserName") & "', Received_ID = '" & Session("Received_ID") & "' WHERE AIRHdr_ID = '" & Session("AIRHDR_ID") & "'", CommandType.Text)

    '                Dim objdtl As New t_inspection_and_acceptance_dtl

    '            =-= PO Details Save
    '            Dim POdtl As New t_purchase_order_dtl
    '                Dim txtPricePO As TextBox = CType(txtUnitPrice, TextBox)
    '                Dim txtqtyPO As TextBox = CType(txtQuantity, TextBox)

    '                POdtl.POHdr_ID = Session("POHdr_ID")
    '                POdtl.Item_ID = hdnItemNo.Value
    '                POdtl.cost = txtPricePO.Text
    '                POdtl.qty = txtqtyPO.Text
    '                POdtl.remarks = "Manual Encode"
    '                POdtl.save()

    '            =-= AIR DETAILS
    '            Dim txtPriceair As TextBox = CType(txtUnitPrice, TextBox)
    '                Dim txtqtyair As TextBox = CType(txtQuantity, TextBox)

    '                objdtl.Item_ID = hdnItemNo.Value
    '                objdtl.Qty = txtqtyair.Text
    '                objdtl.Cost = CType(txtPriceair.Text, Decimal)
    '                objdtl.AIRHdr_ID = Session("AIRHDR_ID")
    '                objdtl.GA_ID = hdnGAId.Value
    '                Dim iaDtl_ID As Integer = objdtl.save()

    '                Session("AIRDtl_ID") = iaDtl_ID
    '                Dim objStock As New Supplies_Stock

    '            =-= SAVE STOCK
    '            With objStock
    '                    .StockID = StockID
    '                    .StockDate = DateTime.Parse(txtDate.Text)
    '                    .Item_ID = hdnItemNo.Value
    '                    .Qty = txtqtyair.Text
    '                    .Balance = txtqtyair.Text
    '                    Dim locations As String
    '11212022



    '                If txtBay.Text <> "" Then
    '                        locations = "Bay-" & txtBay.Text
    '                    End If

    '                    If txtColumn.Text <> "" Then
    '                        locations = locations + " " + "Column-" & txtColumn.Text
    '                    End If

    '                    If txtFloor.Text <> "" Then
    '                        locations = locations + " " + "Floor-" & txtFloor.Text
    '                    End If

    '                    If txtRoom.Text <> "" Then
    '                        locations = locations + " " + "Room-" & txtRoom.Text
    '                    End If

    '                    If txtShelves.Text <> "" Then
    '                        locations = locations + " " + "Shelves-" & txtShelves.Text
    '                    End If

    '                    If txtRack.Text <> "" Then
    '                        locations = locations + " " + "Rack-" & txtRack.Text
    '                    End If

    '                    If txtBin.Text <> "" Then
    '                        locations = locations + " " + "Bin-" & txtBin.Text
    '                        End Ifw

    '                Optimize code
    '                Dim sb As New StringBuilder()

    '                        If Not String.IsNullOrEmpty(txtBay.Text) Then
    '                            sb.Append("Bay-").Append(txtBay.Text)
    '                        End If

    '                        If Not String.IsNullOrEmpty(txtColumn.Text) Then
    '                            sb.Append(" Column-").Append(txtColumn.Text)
    '                        End If

    '                        If Not String.IsNullOrEmpty(txtFloor.Text) Then
    '                            sb.Append(" Floor-").Append(txtFloor.Text)
    '                        End If

    '                        If Not String.IsNullOrEmpty(txtRoom.Text) Then
    '                            sb.Append(" Room-").Append(txtRoom.Text)
    '                        End If

    '                        If Not String.IsNullOrEmpty(txtShelves.Text) Then
    '                            sb.Append(" Shelves-").Append(txtShelves.Text)
    '                        End If

    '                        If Not String.IsNullOrEmpty(txtRack.Text) Then
    '                            sb.Append(" Rack-").Append(txtRack.Text)
    '                        End If

    '                        If Not String.IsNullOrEmpty(txtBin.Text) Then
    '                            sb.Append(" Bin-").Append(txtBin.Text)
    '                        End If

    '                        Dim locations As String = sb.ToString().Trim()



    '                        .Location = sb.ToString()
    '                        .Expiration_Date = "1/1/1900"
    '                        .Cost = CType(txtPriceair.Text, Decimal)
    '                        .Issuance = 0
    '                        .RC_ID = objDerived.GetValue("SELECT DISTINCT [RC_id] FROM [dbo].[View_RespCenter_withFunctions] WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'", CommandType.Text)
    '                        .Function_ID = 0
    '                        .Project_ID = 0
    '                        .Program_id = 0
    '                        .F_ID = 4
    '                        .AIRDtl_ID = Session("AIRDtl_ID")
    '                        .GA_ID = hdnGAId.Value
    '                        .Warehouseid = drpWarehouse.SelectedValue()
    '                        .ReorderPt = IIf(IsNumeric(txtReOrderPt.Text), txtReOrderPt.Text, 0)

    '            End With

    '                Dim StockID As Long = objStock.save
    '                objDerived.GetRecords("UPDATE AMS.Stock SET  Received_ID = '" & rcvID & "' WHERE StockID = '" & StockID & "'", CommandType.Text)


    '                Dim objStockLedger As New t_StockLedger

    '            ---------------------------------------------------------
    '            ====== save ledger ========
    '            With objStockLedger
    '                    .StockLedger_ID = StockLedger_ID
    '                    .StockID = StockID
    '                    .Trans_Type = "Starting Balance"
    '                    .Ref = air
    '                    .AccountablePerson = objDerived.GetValue("SELECT ContactP FROM  dbo.Supplier where Supplier_Id ='" & Session("Supplier_Id") & "' ", CommandType.Text)
    '                    .Department = ""
    '                    .Position = ""
    '                    .AcceptedBy = ""
    '                    .InspectedBy = ""
    '                    .ReceivedBy = ""
    '                    .CreditQty = "0"
    '                    .CreditUnit = "-"
    '                    .CreditCost = "0.00"
    '                    .dDate = DateTime.Parse(txtSellectDate.Text)
    '                    .Item_ID = hdnItemNo.Value
    '                    .DebitQty = txtqtyair.Text
    '                    .DebitCost = FormatNumber(CType(txtPriceair.Text, Decimal) * txtqtyair.Text, 2)
    '                    .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
    '                    .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
    '                    .BalanceQty = 0
    '                    .BalanceCost = 0
    '                    .save()
    '                End With
    '                Dim objOfficeSup As New SupplieINFO

    '                If hdnGAId.Value = 1427 Then
    '                    Office Supplies
    '                With objOfficeSup
    '                        .SuppliesId = SuppliesId
    '                        .StockID = StockID
    '                        .AIRDtl_ID = Session("AIRDtl_ID")
    '                        .ItemId = hdnItemNo.Value
    '                        .Description = txtItemDesc1.Text
    '                        .BrandName = txtBrandName1.Text
    '                        .SupplierId = 0
    '                        .Size = txtSize.Text
    '                        .Color = txtColor.Text
    '                        .Category = txtCategory.Text
    '                        .Length = txtLenght.Text
    '                        .Width = txtWidth.Text
    '                        .Height = txtHeight.Text
    '                        .Weight = txtWeight.Text
    '                        .DepreciatedValue = txtDepRate1.Text
    '                        .DepreciatedRate = txtDepValue1.Text
    '                        .Status = "Accepted"
    '                        .Dose = ""
    '                        .Received_ID = 0
    '                        .Componentof = " "
    '                    End With

    '                    Dim Supp_ID As Long = objOfficeSup.save
    '                    objDerived.GetRecords("UPDATE AMS.TBSupplies_Info SET Received_ID = '" & rcvID & "' WHERE SuppliesId = '" & Supp_ID & "'", CommandType.Text)
    '                End If

    '                dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
    '                If dtStock.Rows.Count < 4 Then
    '                    dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
    '                End If
    '                grdLedger.DataSource = dtStock
    '                grdLedger.DataBind()
    '                loadCleartext()
    '                selectitemdesc()
    '                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")
    '                Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
    '                Dim c As Integer = txtQuantity.Text
    '                If a >= c Then
    '                    ModalPopupExtender3.Show()
    '                End If
    '                loadStockOfficeSupplies()

    '        End If


    '    End Sub


    Public Sub updateOfficeSupplies()

        Dim dt As DataTable = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpItemDesc1.SelectedItem.Value & "'", CommandType.Text)

        If txtUnitPrice.Text = "" Or txtQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Unit Cost or Quantity")
        Else
            objDerived.Execute("Update dbo.m_item set unit_id = " & drpUnit.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)

            Dim location As String

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


            For i As Integer = 0 To grdLedger.Rows.Count - 1
                Dim cb1 As CheckBox = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then

                    If dt.Rows.Count > 0 Then
                        Dim stockID As String = dt.Rows(i).Item("StockID").ToString()

                        Dim qty As Decimal
                        Dim cost As Decimal

                        If Not Decimal.TryParse(txtQuantity.Text, qty) Then
                        End If
                        If Not Decimal.TryParse(txtUnitPrice.Text, cost) Then
                        End If

                        objDerived.GetRecords("UPDATE [AMS].[stock] " +
                                    " SET [Qty] = '" & qty & "' " +
                                    " ,[Cost] = '" & cost & "' " +
                                    " ,[Location] = '" & location & "' " +
                                    " ,[warehouse_ID] = '" & drpWarehouse.SelectedValue() & "' " +
                                    " ,[ReorderPt] = '" & txtReOrderPt.Text & "' " +
                                    " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "'  ", CommandType.Text)

                        ' Declare variables to hold the converted values
                        Dim qty2 As Decimal
                        Dim unitPrice As Decimal
                        Dim unitOtherPrice As Decimal

                        ' Check if the values are numeric and convert them
                        If IsNumeric(txtQuantity.Text) AndAlso IsNumeric(txtUnitPrice.Text) Then
                            qty = CDec(txtQuantity.Text)
                            unitPrice = CDec(txtUnitPrice.Text)

                            ' Proceed with the SQL query
                            objDerived.GetRecords("UPDATE [AMS].[TbStock_Ledger] " +
                                                " SET DebitUnit = '" & drpUnit.SelectedItem.Text & "', " &
                                                " [DebitQty] = '" & qty & "', " &
                                                " [DebitCost] = '" & (qty * unitPrice) & "', " &
                                                " BalanceUnit = '" & drpUnit.SelectedItem.Text & "', " &
                                                " dDate = '" & txtSellectDate.Text & "', " &
                                                " BalanceCost = (SELECT TOP 1 BalanceCost FROM AMS.TbStock_Ledger WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "' ORDER BY StockLedger_ID DESC) " &
                                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & stockID & "'", CommandType.Text)

                        Else
                            ' Handle the case where the input is not valid (e.g., show an error message)
                        End If



                        objDerived.GetRecords("UPDATE [AMS].[TBSupplies_Info] " +
                                                " SET [Description] = '" & txtItemDesc1.Text & "' " +
                                                " ,[BrandName] = '" & txtBrandName1.Text & "' " +
                                                " ,[Size] = '" & txtSize.Text & "' " +
                                                " ,[Color] = '" & txtColor.Text & "' " +
                                                " ,[Length] = '" & txtLenght.Text & "' " +
                                                " ,[Width] = '" & txtWidth.Text & "' " +
                                                " ,[Height] = '" & txtHeight.Text & "' " +
                                                " ,[Weight] = '" & txtWeight.Text & "' " +
                                                " WHERE ItemId = '" & hdnItemNo.Value & "' and  StockID = '" & stockID & "'  ", CommandType.Text)
                    End If
                End If
            Next


            ''----Update Receiving
            'WAS UPDATING RECEIVING_DTL BEFORE BUT COMMENTED AFTER READING THE SYNTAX, THAT IT UPDATES ALL ROWS WITH THE SAME ITEM_ID,
            'EX. Item_ID 1 is 5 rows, 5 rows is updated even if not intended.

            'objDerived.GetRecords("UPDATE [AMS].[Tb_Receiving_Dtl] " +
            '                    " SET [PO_Qty] = '" & txtQuantity.Text & "' " +
            '                    " ,[Qty_Received] = '" & txtQuantity.Text & "' " +
            '                    " ,[Cost] = '" & txtUnitPrice.Text & "' " +
            '                    " ,[Location] = '" & location & "' " +
            '                    " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim t1 As Decimal
            Dim total As Decimal = 0

            t1 = txtQuantity.Text * txtUnitPrice.Text
            total = total + t1
            Session("ContractPrice") = total


            'WAS UPDATING RECEIVING_DTL BEFORE BUT COMMENTED AFTER READING THE SYNTAX, THAT IT UPDATES ALL ROWS WITH THE SAME ITEM_ID,
            'EX. Item_ID 1 is 5 rows, 5 rows is updated even if not intended.
            '----Update PO_dtl
            'objDerived.GetRecords("UPDATE [AMS].[PO_Dtl] " +
            '                        " SET [qty] = '" & txtQuantity.Text & "' " +
            '                        " ,[cost] = '" & txtUnitPrice.Text & "' " +
            '                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)


            ''----Update AIR_Dtl
            'objDerived.GetRecords("UPDATE [AMS].[AIR_Dtl] " +
            '                        " SET [Qty] = '" & txtQuantity.Text & "' " +
            '                        " ,[Cost] = '" & txtUnitPrice.Text & "' " +
            '                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)

            '----Update STOCK
            'objDerived.GetRecords("UPDATE [AMS].[stock] " +
            '                        " SET [Qty] = '" & txtQuantity.Text & "' " +
            '                        " ,[Balance] = '" & txtQuantity.Text & "' " +
            '                        " ,[Cost] = '" & txtUnitPrice.Text & "' " +
            '                        " ,[Location] = '" & location & "' " +
            '                        " ,[warehouse_ID] = '" & drpWarehouse.SelectedValue() & "' " +
            '                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)

            '----Update stockledger

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer = txtQuantity.Text
            If a >= c Then
                ModalPopupExtender3.Show()
            End If
            selectitemdesc()
            ledger()


        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)

        If btnSave.Text = "SAVE" Then
            saveOfficeSupplies()
            'here


        ElseIf btnSave.Text = "EDIT" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()

            ModalPopupExtender2.Show()

        Else
            updateOfficeSupplies()
            btnSave.Text = "EDIT"

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
    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else


            If hdnApproval.Value = "Med" Then
                btnUpdateDetails2.Text = "UPDATE"
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fields are now open for editing")
            Else
                'txtItemDesc1.ReadOnly = False
                'txtBrandName1.ReadOnly = False
                'txtSize.ReadOnly = False
                'txtColor.ReadOnly = False
                'txtDepRate1.ReadOnly = False
                'txtCategory.ReadOnly = False
                'txtLenght.ReadOnly = False
                'txtWidth.ReadOnly = False
                'txtHeight.ReadOnly = False
                'txtWeight.ReadOnly = False
                'txtDepValue1.ReadOnly = False
                'txtUnitPrice.ReadOnly = False
                'txtQuantity.ReadOnly = True
                'txtBay.ReadOnly = False
                'txtColumn.ReadOnly = False
                'txtFloor.ReadOnly = False
                'txtRoom.ReadOnly = False
                'txtShelves.ReadOnly = False
                'txtRack.ReadOnly = False
                'txtBin.ReadOnly = False
                'TextBox1.ReadOnly = False
                Dim textBoxes() As TextBox = {txtItemDesc1, txtBrandName1, txtSize, txtColor, txtDepRate1, txtCategory,
                               txtLenght, txtWidth, txtHeight, txtWeight, txtDepValue1, txtUnitPrice,
                               txtBay, txtColumn, txtFloor, txtRoom, txtShelves, txtRack,
                               txtBin, TextBox1}
                'txtQuantity, 

                For Each tb As TextBox In textBoxes
                    tb.ReadOnly = False
                Next


                btnSave.Text = "UPDATE"
                If Button4.Text = "EDIT" Then
                    Button4.Text = "UPDATE"
                Else

                End If

                btnCancel.Enabled = True
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fields are now open for editing")
            End If
        End If


    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        selectitemdesc()
    End Sub

    Protected Sub btnAuthCancel_Click(sender As Object, e As EventArgs)
        ModalPopupExtender2.Hide()

    End Sub




    Public Sub SelectCategory()
        Dim category As String
        If ddCategory.Text = "" Then
            category = 0
        Else
            category = ddCategory.SelectedValue()
        End If
        Dim subcategory As New DataTable
        subcategory = obj.GetDataTable("select [SubCategoryID],[SubCat_Desc]  From [dbo].[tbl_SubCategory] where item_particular_id = " & category & " order by SubCat_Desc", CommandType.Text)
        ddSubCategory.DataSource = subcategory
        ddSubCategory.DataTextField = ("SubCat_Desc")
        ddSubCategory.DataValueField = ("SubCategoryID")
        ddSubCategory.DataBind()
        ddSubCategory.Enabled = True
        loadStockOfficeSupplies()
        LoadStockChangeIndex()



        ledger()

    End Sub


    Protected Sub ddCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        SelectCategory()

        MultiviewSupplier()



    End Sub
    Protected Sub ddClass_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub


    Protected Sub ddSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)

        MultiviewSupplier()
    End Sub

    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpUnit.DataSource = dt
        drpUnit.DataTextField = ("Description")
        drpUnit.DataValueField = ("Unit_ID")
        drpUnit.DataBind()

    End Sub
    Public Sub loadUnitMed()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpUnitMed.DataSource = dt
        drpUnitMed.DataTextField = ("Description")
        drpUnitMed.DataValueField = ("Unit_ID")
        drpUnitMed.DataBind()

    End Sub


    Public Sub selectitemdesc()


        Dim CY As String = "CY" & Year(txtDate.Text)
        Dim dtitemdetails As New DataTable
        loadUnit()
        If drpItemDesc1.SelectedValue = "" Then
            dtitemdetails = objDerived.GetDataTable("select a.Item_ID,Item_Desc,isnull(brand,''),isnull(color,''),isnull(size,''),isnull(" & CY & ",0.00) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID = null", CommandType.Text)
        Else
            dtitemdetails = objDerived.GetDataTable("select a.Item_ID,Item_Desc,isnull(brand,''),isnull(color,''),isnull(size,''),isnull(" & CY & ",0.00),isnull(Unit_ID,1)  from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & drpItemDesc1.SelectedValue, CommandType.Text)

        End If
        If dtitemdetails.Rows.Count > 0 Then

            hdnItemNo.Value = dtitemdetails.Rows(0).Item(0)


        End If

        LoadStockGridBatches_from_dropdown()
    End Sub

    Protected Sub drpItemDesc1_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectitemdesc()

    End Sub


    Protected Sub LoadStockGridBatches_from_dropdown()
        '11212022
        Dim CY As String = "CY" & Year(txtDate.Text)

        Dim textBoxes As TextBox() = {txtBrandElectrical, txtSizeElectrical, txtUnitPrice, txtSellectDate, txtQuantity, txtSize, txtBrandName1, txtColor, txtLenght, txtWidth, txtHeight}

        For Each textBox As TextBox In textBoxes
            textBox.ReadOnly = False
        Next

        Dim dtStock As New DataTable
        'dtStock = objDerived.GetDataTable("select *  from [dbo].[View_StockSupplyBatches] where  Item_ID = '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        Dim itemID As String
        loadCleartext()
        loadwarehouse()
        hdnGAId.Value = ddGlAccount.SelectedValue()

        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_StockSupplies_Batches] '" & ddGlAccount.SelectedValue() & "','" & itemID & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatable2(3 - dtStock.Rows.Count))
        End If
        grdsupplies.DataSource = dtStock
        grdsupplies.DataBind()
        grdsupplies.SelectedIndex = -1

        ledger()

    End Sub

    Public Shared Function SearchCustomers(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        'Dim objDerived As New DerivedDal

        'Dim customers As List(Of String) = New List(Of String)()


        'Dim classification As String = objDerived.getvalue("select * From dbo.tbl_Classification where ClassificationName like '%Office Supplies%' ", commandtype.text)



        'customers = objDerived.getdatatable("select a.Item_ID,Item_Desc from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID inner join ams.item_particular as c on a.item_particular_id = c.item_particular_id where Item_Desc like '" & prefixText & "%' ", commandtype.text)

        'Return customers
    End Function

    Protected Sub grdLedger_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        Dim dt As DataTable
        Dim cb1 As CheckBox

        dt = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)


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


            '--=======
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
    Protected Sub DrpSubClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        SelectSubClassification()
    End Sub

    Protected Sub btnROP_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub BtnCompute_Click(sender As Object, e As EventArgs)
        Try
            RP.Text = DRP.Text * LTD.Text
            ModalPopupExtender1.Show()
            txtReOrderPt.Text = DRP.Text * LTD.Text

            If hdnROP.Value = "Electrical" Then
                txtReorderPointElectrical.Text = DRP.Text * LTD.Text
            ElseIf hndMed.Value = "MED" Then
                txtReorderPointMed.Text = DRP.Text * LTD.Text
            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill Demand Per Day & Lead Time For Deliver.")

        End Try
    End Sub
    Protected Sub drpJanitorial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpJanitorial.SelectedIndexChanged
        Med()


        ledger()
        RetriveMed()

    End Sub
    Public Sub RetriveMed()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT AMS.TBSupplies_Info.BrandName, AMS.TBSupplies_Info.Dose, AMS.TBSupplies_Info.Size, AMS.TBSupplies_Info.Color, AMS.Stock.ReorderPt, AMS.TbNonFood.Form, AMS.TbNonFood.OTCRx, AMS.Stock.Cost, AMS.Stock.Qty, " &
                             "AMS.Stock.StockDate, AMS.TbNonFood.Batch, AMS.TbNonFood.Lot, AMS.TbNonFood.Mftgdate, AMS.TbNonFood.EpiryDate, AMS.TbNonFood.Alert,AMS.Stock.Location " &
                             "FROM AMS.TBSupplies_Info INNER JOIN " &
                             "AMS.TbNonFood ON AMS.TBSupplies_Info.StockID = AMS.TbNonFood.StockId INNER JOIN " &
                             "AMS.Stock ON AMS.TBSupplies_Info.StockID = AMS.Stock.StockID " &
                             "WHERE AMS.TbNonFood.Item_ID = " & hdnItemNo.Value, CommandType.Text)
        If dt.Rows.Count > 0 Then

            'OPTIMIZE code
            txtBrandName2.Text = dt.Rows(0).Item("BrandName").ToString
            txtDose.Text = dt.Rows(0).Item("Dose").ToString
            txtSizeMed.Text = dt.Rows(0).Item("Size").ToString
            txtColorMed.Text = dt.Rows(0).Item("Color").ToString
            txtReorderPointMed.Text = dt.Rows(0).Item("ReorderPt").ToString
            txtForm.Text = dt.Rows(0).Item("Form").ToString
            txtOTC.Text = dt.Rows(0).Item("OTCRx").ToString
            txtUnitCostMed.Text = dt.Rows(0).Item("Cost").ToString
            txtQuantityMed.Text = dt.Rows(0).Item("Qty").ToString
            txtBatch.Text = dt.Rows(0).Item("Batch").ToString
            txtLot.Text = dt.Rows(0).Item("Lot").ToString
            txtMDate.Text = Convert.ToDateTime(dt.Rows(0).Item("Mftgdate").ToString).ToString("MM/dd/yyyy")
            txtEDate.Text = Convert.ToDateTime(dt.Rows(0).Item("EpiryDate").ToString).ToString("MM/dd/yyyy")
            txtAlert.Text = Convert.ToDateTime(dt.Rows(0).Item("Alert").ToString).ToString("MM/dd/yyyy")
            txtDateMed.Text = Convert.ToDateTime(dt.Rows(0).Item("StockDate").ToString).ToString("MM/dd/yyyy")


            Dim i As Integer = DateDiff("d", txtAlert.Text, Date.Now)

            If i >= 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "This Item is going to expire on " & txtAlert.Text)
            End If


            Dim a12 = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer = txtQuantityMed.Text
            If a12 >= c Then
                ModalPopupExtender3.Show()
            End If

            Try
                Dim location As String
                location = dt.Rows(0).Item("Location").ToString

                Dim locationsplit As String() = location.Split(" ")
                If location.Contains("Bay") Then
                    Dim a As String = locationsplit(0)
                    Dim a1 As String() = a.Split("-")
                    txtBayMedical.Text = a1(1)
                Else
                    txtBayMedical.Text = ""
                End If
                If location.Contains("Column") Then
                    Dim a As String = locationsplit(1)
                    Dim a1 As String() = a.Split("-")
                    txtColumnMedical.Text = a1(1)
                Else
                    txtColumnMedical.Text = ""
                End If
                If location.Contains("Floor") Then
                    Dim a As String = locationsplit(2)
                    Dim a1 As String() = a.Split("-")
                    txtFloorMedical.Text = a1(1)
                Else
                    txtFloorMedical.Text = ""
                End If
                If location.Contains("Room") Then
                    Dim a As String = locationsplit(3)
                    Dim a1 As String() = a.Split("-")
                    txtRoodMedical.Text = a1(1)
                Else
                    txtRoodMedical.Text = ""
                End If
                If location.Contains("Shelves") Then
                    Dim a As String = locationsplit(4)
                    Dim a1 As String() = a.Split("-")
                    txtShelvesMedical.Text = a1(1)
                Else
                    txtShelvesMedical.Text = ""
                End If
                If location.Contains("Rack") Then

                    Dim a As String = locationsplit(5)
                    Dim a1 As String() = a.Split("-")
                    txtRackMedical.Text = a1(1)
                Else
                    txtRackMedical.Text = ""
                End If
                If location.Contains("Bin") Then
                    Dim a As String = locationsplit(6)
                    Dim a1 As String() = a.Split("-")
                    txtBinMedical.Text = a1(1)
                Else
                    txtBinMedical.Text = ""
                End If
            Catch ex As Exception

            End Try

        Else

        End If
    End Sub
    Public Sub Electrical()
        Dim CYear As String = "CY" & Year(txtDate.Text)


        If drpNameElectrical.Text = "" Then
            hdnItemNo.Value = "0"
        Else
            hdnItemNo.Value = drpNameElectrical.SelectedValue
        End If

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
        If dt.Rows.Count > 0 Then
            txtBrandElectrical.Text = dt.Rows(0).Item("description").ToString
        Else

        End If
    End Sub
    Public Sub Med()
        Dim CYear As String = "CY" & Year(txtDate.Text)


        If drpJanitorial.Text = "" Then
            hdnItemNo.Value = "0"
        Else
            hdnItemNo.Value = drpJanitorial.SelectedValue
        End If

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
        If dt.Rows.Count > 0 Then
            txtItemDesc2.Text = dt.Rows(0).Item("description").ToString
        Else

        End If

        Dim dt1 As New DataTable
        dt1 = obj.GetDataTable("select reorderPT from dbo.m_item where  Item_ID='" & hdnItemNo.Value & "'", CommandType.Text)
        If dt1.Rows.Count > 0 Then
            txtReorderPointMed.Text = dt1.Rows(0).Item(0)

        Else

        End If



    End Sub
    Public Sub RetriveElectrical()
        Dim dt As New DataTable
        'dt = obj.GetDataTable("select a.Description,a.BrandName,a.Size,a.Color,a.DepreciatedRate,a.DepreciatedValue,a.Length,a.Width,a.Height,a.Weight,b.Cost,convert(int,b.Qty) ,isnull(b.Location,' - '),isnull(b.warehouse_id,1),isnull(b.ReorderPt,' - ')   From [AMS].[TBSupplies_Info] as a inner join ams.Stock as b on a.StockID = b.StockID  where Item_ID =" & hdnItemNo.Value, CommandType.Text)
        dt = obj.GetDataTable("SELECT a.Description, a.BrandName, a.Size, a.Color, a.DepreciatedRate, a.DepreciatedValue, a.Length, a.Width, a.Height, a.Weight, b.Cost, CONVERT(int, b.Qty) AS Expr1, ISNULL(b.Location, ' - ') AS Expr2, ISNULL(b.warehouse_ID, 1) " &
                         "AS Expr3, ISNULL(b.ReorderPt, ' - ') AS Expr4, AMS.Stock.StockDate,  dbo.m_item.Unit_ID " &
                         "FROM AMS.TBSupplies_Info AS a INNER JOIN " &
                         "AMS.Stock AS b ON a.StockID = b.StockID INNER JOIN " &
                         "AMS.Stock ON b.StockID = AMS.Stock.StockID INNER JOIN " &
                         "dbo.m_item ON a.ItemId = dbo.m_item.Item_ID " &
                         "WHERE b.Item_ID = " & hdnItemNo.Value, CommandType.Text)




        If dt.Rows.Count > 0 Then
            txtSizeElectrical.Text = dt.Rows(0).Item(2)
            txtColorElectrical.Text = dt.Rows(0).Item(3)
            txtUnitCostElectrical.Text = dt.Rows(0).Item(10)
            txtReorderPointElectrical.Text = dt.Rows(0).Item(14)
            txtDateElectrical.Text = Convert.ToDateTime(dt.Rows(0).Item(15)).ToString("MM/dd/yyyy")
            drpUnitElectrical.SelectedValue = dt.Rows(0).Item(16)
            txtLengthElectrical.Text = dt.Rows(0).Item(6)
            txtWidthElectrical.Text = dt.Rows(0).Item(7)
            txtWeightElectrical.Text = dt.Rows(0).Item(9)
            txtHeightElectrical.Text = dt.Rows(0).Item(8)
            txtQuantityElectrical.Text = dt.Rows(0).Item(11)
            drpWarehouseElectrical.SelectedValue = dt.Rows(0).Item(13)

            Dim location As String

            location = dt.Rows(0).Item(12)

            Dim locationsplit As String() = location.Split(" ")
            If location.Contains("Bay") Then
                Dim a As String = locationsplit(0)
                Dim a1 As String() = a.Split("-")
                txtBayElectrical.Text = a1(1)
                On Error Resume Next
            Else
                txtBayElectrical.Text = ""
            End If

            If location.Contains("Column") Then
                Dim a As String = locationsplit(1)
                Dim a1 As String() = a.Split("-")
                txtColumnElectrical.Text = a1(1)
                On Error Resume Next
            Else
                txtColumnElectrical.Text = ""
            End If

            If location.Contains("Floor") Then
                Dim a As String = locationsplit(2)
                Dim a1 As String() = a.Split("-")
                txtFloorElectrical.Text = a1(1)
                On Error Resume Next
            Else
                txtFloorElectrical.Text = ""
            End If

            If location.Contains("Room") Then
                Dim a As String = locationsplit(3)
                Dim a1 As String() = a.Split("-")
                txtRoomElectrical.Text = a1(1)
                On Error Resume Next
            Else
                txtRoomElectrical.Text = ""
            End If

            If location.Contains("Shelves") Then
                Dim a As String = locationsplit(4)
                Dim a1 As String() = a.Split("-")
                txtShelvesElectrical.Text = a1(1)
                On Error Resume Next
            Else
                txtShelvesElectrical.Text = ""
            End If

            If location.Contains("Rack") Then
                Dim a As String = locationsplit(5)
                Dim a1 As String() = a.Split("-")
                txtRackElectrical.Text = a1(1)
                On Error Resume Next
            Else
                txtRackElectrical.Text = ""
            End If

            If location.Contains("Bin") Then
                Dim a As String = locationsplit(6)
                Dim a1 As String() = a.Split("-")
                txtBinElectrical.Text = a1(1)
                On Error Resume Next
            Else
                txtBinElectrical.Text = ""
            End If


        Else
            txtSizeElectrical.Text = ""
            txtColorElectrical.Text = ""
            txtUnitCostElectrical.Text = ""
            txtReorderPointElectrical.Text = ""
            txtDateElectrical.Text = ""
            drpUnitElectrical.SelectedIndex = 0
            txtLengthElectrical.Text = ""
            txtWidthElectrical.Text = ""
            txtWeightElectrical.Text = ""
            txtHeightElectrical.Text = ""
            txtQuantityElectrical.Text = ""
            drpWarehouseElectrical.SelectedIndex = 0


            txtBayElectrical.Text = ""

            txtColumnElectrical.Text = ""

            txtFloorElectrical.Text = ""

            txtRoomElectrical.Text = ""

            txtShelvesElectrical.Text = ""

            txtRackElectrical.Text = ""

            txtBinElectrical.Text = ""
            Dim dt4 As New DataTable
            dt4 = obj.GetDataTable("select reorderPT from dbo.m_item where  Item_ID='" & hdnItemNo.Value & "'", CommandType.Text)
            If dt4.Rows.Count > 0 Then
                txtReorderPointElectrical.Text = dt4.Rows(0).Item(0)
            Else

            End If
        End If

    End Sub

    Protected Sub drpNameElectrical_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpNameElectrical.SelectedIndexChanged
        Electrical()
        RetriveElectrical()
        ledger()
    End Sub

    Public Sub loadUnitElectrical()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("Select Unit_ID,Description  From ams.m_Unit As a order by Description", CommandType.Text)
        drpUnitElectrical.DataSource = dt
        drpUnitElectrical.DataTextField = ("Description")
        drpUnitElectrical.DataValueField = ("Unit_ID")
        drpUnitElectrical.DataBind()

    End Sub
    Public Sub loadwarehouseElectrical()
        Dim dt As New DataTable
        dt = obj.GetDataTable("Select warehouse_id,wname From ams.loc_warehouse", CommandType.Text)
        drpWarehouseElectrical.DataTextField = ("wname")
        drpWarehouseElectrical.DataValueField = ("warehouse_id")
        drpWarehouseElectrical.DataSource = dt
        drpWarehouseElectrical.DataBind()
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "SAVE" Then
            SaveElectrical()
        ElseIf Button4.Text = "EDIT" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            ModalPopupExtender2.Show()
        Else
            updateElectrical()
        End If

    End Sub
    Public Sub SaveElectrical()
        If txtReorderPointElectrical.Text = "" Or txtQuantityElectrical.Text = "" Or txtUnitCostElectrical.Text = "" Or txtDateElectrical.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
        Else
            'Dim unit As String = objDerived.getvalue("select unit_id From dbo.m_item where item_id = " & hdnItemNo.value, commandtype.text)
            'If unit = "" Then
            objDerived.Execute("Update dbo.m_item set unit_id = " & drpUnitElectrical.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)
            'End If
            Dim classification As String = objDerived.GetValue("select classificationid From dbo.tbl_Classification where ClassificationName like '%Supplies%' ", CommandType.Text)
            Dim category As Integer = objDerived.GetValue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
            Dim matrix As String = objDerived.GetValue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & hdnGAId.Value & " and item_id = " & hdnItemNo.Value & "", CommandType.Text)

            If matrix = "" Then
                objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id) values('" & classification & "','" & hdnGAId.Value & "','" & hdnItemNo.Value & "','" & category & "','0')", CommandType.Text)
            End If

            '--------------------------------------------------------------
            '=-= SAVE AMS.Tb_Receiving
            With rcv
                .Received_Date = txtDateElectrical.Text
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

            '  For i As Integer = 0 To pItems.Rows.Count - 1
            For i As Integer = 0 To 1 - 1

                Dim txtPrice As TextBox = CType(txtUnitCostElectrical, TextBox)
                Dim txtqty As TextBox = CType(txtQuantityElectrical, TextBox)
                Dim locations As String

                If txtBayElectrical.Text <> "" Then
                    locations = "Bay-" & txtBayElectrical.Text
                End If

                If txtColumnElectrical.Text <> "" Then
                    locations = locations + " " + "Column-" & txtColumnElectrical.Text
                End If

                If txtFloorElectrical.Text <> "" Then
                    locations = locations + " " + "Floor-" & txtFloorElectrical.Text
                End If

                If txtRoomElectrical.Text <> "" Then
                    locations = locations + " " + "Room-" & txtRoomElectrical.Text
                End If

                If txtShelvesElectrical.Text <> "" Then
                    locations = locations + " " + "Shelves-" & txtShelvesElectrical.Text
                End If

                If txtRackElectrical.Text <> "" Then
                    locations = locations + " " + "Rack-" & txtRackElectrical.Text
                End If

                If txtBinElectrical.Text <> "" Then
                    locations = locations + " " + "Bin-" & txtBinElectrical.Text
                End If

                '=-= SAVE AMS.Tb_Receiving_Dtl
                With rcv_dtl
                    .Received_ID = rcvID
                    .Item_ID = hdnItemNo.Value
                    .PO_Qty = txtQuantityElectrical.Text
                    .Qty_Received = txtQuantityElectrical.Text
                    .Cost = txtUnitCostElectrical.Text
                    .Condition = ""
                    .Location = locations
                End With

                Dim RcvDtl_ID As Long = rcv_dtl.save

                Dim t1 As Decimal
                t1 = txtUnitCostElectrical.Text * txtQuantityElectrical.Text
                total = total + t1

            Next
            Session("ContractPrice") = total


            '=-= SAVE OF PURCHASED ORDER
            Dim pohdr_id As Long
            Dim POhdr As New t_purchase_order_hdr
            Dim POnumber As String = "Starting Inventory"


            POhdr.PO_No = POnumber
            POhdr.PO_Date = txtDateElectrical.Text
            POhdr.Supplier_ID = 0
            POhdr.mode_of_procurement_id = 2
            POhdr.DeliveryTerm = 0
            POhdr.paymentTerm = 0
            POhdr.DeliveryDate = txtDateElectrical.Text
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
            POhdr.DateApproved_PO_Mayor = txtDateElectrical.Text
            POhdr.DateReceived_PO_Mayor = txtDateElectrical.Text
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

            objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = '" & hdnGAId.Value & "', ProjectName = 'Manual Encode' WHERE POHdr_ID = '" & pohdr_id & "'", CommandType.Text)
            Session("POHdr_ID") = pohdr_id



            '=-= SAVE OF INSPECTION & ACCEPTANCE
            Dim objhdr As New t_inspection_and_acceptance_hdr

            Dim airhdr_id As Long
            Dim air As String
            air = objDerived.GetValue("select [AMS].[func_GenerateAIR]('" & txtDate.Text & "')", CommandType.Text)

            With objhdr
                .AIR_No = air
                .AIR_Date = DateTime.Parse(txtDateElectrical.Text)
                .Date_Received = DateTime.Parse(txtDateElectrical.Text)
                .Date_Inspect = DateTime.Parse(txtDateElectrical.Text)
                .Date_Accepted = DateTime.Parse(txtDateElectrical.Text)
                .Invoice_No = " "
                .Invoice_date = DateTime.Parse(txtDateElectrical.Text)
                .PO_No = POnumber
                .Supplier_ID = 0
                .Signatory1 = " "
                .Signatory2 = " "
                .Signatory3 = " "
                .isComplete = True
                .POHdr_ID = Session("POHdr_ID")
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
            Dim txtPricePO As TextBox = CType(txtDateElectrical, TextBox)
            Dim txtqtyPO As TextBox = CType(txtQuantityElectrical, TextBox)

            POdtl.POHdr_ID = Session("POHdr_ID")
            POdtl.Item_ID = hdnItemNo.Value
            POdtl.cost = txtUnitCostElectrical.Text
            POdtl.qty = txtQuantityElectrical.Text
            POdtl.remarks = "Manual Encode"
            POdtl.save()

            '=-= AIR DETAILS
            Dim txtPriceair As TextBox = CType(txtUnitPrice, TextBox)
            Dim txtqtyair As TextBox = CType(txtQuantity, TextBox)

            objdtl.Item_ID = hdnItemNo.Value
            objdtl.Qty = txtQuantityElectrical.Text
            objdtl.Cost = CType(txtUnitCostElectrical.Text, Decimal)
            objdtl.AIRHdr_ID = Session("AIRHDR_ID")
            objdtl.GA_ID = hdnGAId.Value
            Dim iaDtl_ID As Integer = objdtl.save()

            Session("AIRDtl_ID") = iaDtl_ID
            Dim objStock As New Supplies_Stock

            '=-= SAVE STOCK
            With objStock
                '.StockID = StockID
                .StockDate = DateTime.Parse(txtDateElectrical.Text)
                .Item_ID = hdnItemNo.Value
                .Qty = txtQuantityElectrical.Text
                .Balance = txtQuantityElectrical.Text
                Dim locations As String

                'If String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                '    location = "Bay-" & txtBay.Text
                'ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                '    location = "Column-" & txtColumn.Text
                'ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                '    location = "Floor-" & txtFloor.Text
                'ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                '    location = "Room-" & txtRoom.Text
                'ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                '    location = "Shelves-" & txtShelves.Text
                'ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                '    location = "Rack-" & txtRack.Text
                'ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) Then
                '    location = "Bin-" & txtBin.Text
                'End If

                If txtBayElectrical.Text <> "" Then
                    locations = "Bay-" & txtBayElectrical.Text
                End If

                If txtColumnElectrical.Text <> "" Then
                    locations = locations + " " + "Column-" & txtColumnElectrical.Text
                End If

                If txtFloorElectrical.Text <> "" Then
                    locations = locations + " " + "Floor-" & txtFloorElectrical.Text
                End If

                If txtRoomElectrical.Text <> "" Then
                    locations = locations + " " + "Room-" & txtRoomElectrical.Text
                End If

                If txtShelvesElectrical.Text <> "" Then
                    locations = locations + " " + "Shelves-" & txtShelvesElectrical.Text
                End If

                If txtRackElectrical.Text <> "" Then
                    locations = locations + " " + "Rack-" & txtRackElectrical.Text
                End If

                If txtBinElectrical.Text <> "" Then
                    locations = locations + " " + "Bin-" & txtBinElectrical.Text
                End If


                .Location = locations

                .Expiration_Date = "1/1/1900"
                .Cost = CType(txtUnitCostElectrical.Text, Decimal)
                .Issuance = 0
                .RC_ID = objDerived.GetValue("SELECT DISTINCT [RC_id] FROM [dbo].[View_RespCenter_withFunctions] WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'", CommandType.Text)
                .Function_ID = 0
                .Project_ID = 0
                .Program_id = 0
                .F_ID = 4
                .AIRDtl_ID = Session("AIRDtl_ID")
                .GA_ID = hdnGAId.Value
                .Warehouseid = drpWarehouseElectrical.SelectedValue()
                .ReorderPt = IIf(IsNumeric(txtReorderPointElectrical.Text), txtReorderPointElectrical.Text, 0)

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
                .dDate = DateTime.Parse(txtDateElectrical.Text)
                .Item_ID = hdnItemNo.Value
                .DebitQty = txtQuantityElectrical.Text
                .DebitCost = FormatNumber(CType(txtUnitCostElectrical.Text, Decimal) * txtQuantityElectrical.Text, 2)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceQty = 0
                .BalanceCost = 0
                .save()
            End With
            Dim objOfficeSup As New SupplieINFO

            If hdnGAId.Value = 1427 Then
                'Office Supplies
                With objOfficeSup
                    '.SuppliesId = SuppliesId
                    .StockID = StockID
                    .AIRDtl_ID = Session("AIRDtl_ID")
                    .ItemId = hdnItemNo.Value
                    .Description = txtBrandElectrical.Text
                    .BrandName = txtBrandElectrical.Text
                    .SupplierId = 0
                    .Size = txtSizeElectrical.Text
                    .Color = txtColorElectrical.Text
                    .Category = txtCategory.Text
                    .Componentof = " "
                    .Length = txtLengthElectrical.Text
                    .Width = txtWidthElectrical.Text
                    .Height = txtHeightElectrical.Text
                    .Weight = txtWeightElectrical.Text
                    .DepreciatedValue = txtDepRate1.Text
                    .DepreciatedRate = txtDepValue1.Text
                    .Status = "Accepted"

                End With

                Dim Supp_ID As Long = objOfficeSup.save
                objDerived.GetRecords("UPDATE AMS.TBSupplies_Info SET Received_ID = '" & rcvID & "' WHERE SuppliesId = '" & Supp_ID & "'", CommandType.Text)
            End If

            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
            If dtStock.Rows.Count < 4 Then
                dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
            End If
            grdLedger.DataSource = dtStock
            grdLedger.DataBind()
            'loadCleartext()
            Electrical()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")
            Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer = txtQuantityElectrical.Text
            If a >= c Then
                ModalPopupExtender3.Show()
            End If
            ' loadStockOfficeSupplies()
            RetriveElectrical()
        End If
    End Sub

    Public Sub updateElectrical()
        If txtReorderPointElectrical.Text = "" Or txtQuantityElectrical.Text = "" Or txtUnitCostElectrical.Text = "" Or txtDateElectrical.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
        Else
            objDerived.Execute("Update dbo.m_item set unit_id = " & drpUnitElectrical.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)

            Dim locations As String

            If txtBayElectrical.Text <> "" Then
                locations = "Bay-" & txtBayElectrical.Text
            End If

            If txtColumnElectrical.Text <> "" Then
                locations = locations + " " + "Column-" & txtColumnElectrical.Text
            End If

            If txtFloorElectrical.Text <> "" Then
                locations = locations + " " + "Floor-" & txtFloorElectrical.Text
            End If

            If txtRoomElectrical.Text <> "" Then
                locations = locations + " " + "Room-" & txtRoomElectrical.Text
            End If

            If txtShelvesElectrical.Text <> "" Then
                locations = locations + " " + "Shelves-" & txtShelvesElectrical.Text
            End If

            If txtRackElectrical.Text <> "" Then
                locations = locations + " " + "Rack-" & txtRackElectrical.Text
            End If

            If txtBinElectrical.Text <> "" Then
                locations = locations + " " + "Bin-" & txtBinElectrical.Text
            End If

            Dim dt As DataTable = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpNameElectrical.SelectedItem.Value & "'", CommandType.Text)

            Dim cb1 As CheckBox
            Dim x As Integer = 0

            If dt.Rows.Count > 0 Then

                For xa As Integer = 0 To grdLedger.Rows.Count - 1
                    cb1 = CType(Me.grdLedger.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)

                    If cb1.Visible AndAlso cb1.Checked Then

                        '----Update STOCK
                        objDerived.GetRecords("UPDATE [AMS].[stock] " +
                                    " SET [Qty] = '" & txtQuantityElectrical.Text & "' " +
                                    " ,[Balance] = '" & txtQuantityElectrical.Text & "' " +
                                    " ,[Cost] = '" & txtUnitCostElectrical.Text & "' " +
                                    " ,[Location] = '" & locations & "' " +
                                    " ,[warehouse_ID] = '" & drpWarehouseElectrical.SelectedValue() & "' " +
                                    " ,[StockDate] = '" & txtDateElectrical.Text & "' " +
                                    " ,[ReorderPt] = '" & txtReOrderPt.Text & "' " +
                                    " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "' ", CommandType.Text)

                        '----Update stockledger
                        ' Declare variables to hold the converted values
                        Dim qty As Decimal
                        Dim unitPrice As Decimal

                        ' Check if the values are numeric and convert them
                        If IsNumeric(txtQuantityElectrical.Text) AndAlso IsNumeric(txtUnitCostElectrical.Text) Then
                            qty = CDec(txtQuantityElectrical.Text)
                            unitPrice = CDec(txtUnitCostElectrical.Text)

                            ' Proceed with the SQL query
                            objDerived.GetRecords("UPDATE [AMS].[TbStock_Ledger] " +
                                                " SET DebitUnit = '" & drpUnitElectrical.SelectedItem.Text & "', " &
                                                " [DebitQty] = '" & qty & "', " &
                                                " [DebitCost] = '" & (qty * unitPrice) & "', " &
                                                " BalanceUnit = '" & drpUnitElectrical.SelectedItem.Text & "', " &
                                                " [dDate] = '" & txtDateElectrical.Text & "', " &
                                                " BalanceCost = (SELECT TOP 1 BalanceCost FROM AMS.TbStock_Ledger WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "' ORDER BY StockLedger_ID DESC) " &
                                                " WHERE Item_ID = '" & hdnItemNo.Value & "' and StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "'", CommandType.Text)
                        Else
                            ' Handle the case where the input is not valid (e.g., show an error message)
                        End If

                        '----Update suppliesinfo
                        objDerived.GetRecords("UPDATE [AMS].[TBSupplies_Info] " +
                                    " SET [Description] = '" & txtBrandElectrical.Text & "' " +
                                    " ,[BrandName] = '" & txtBrandElectrical.Text & "' " +
                                    " ,[Size] = '" & txtSizeElectrical.Text & "' " +
                                    " ,[Color] = '" & txtColorElectrical.Text & "' " +
                                    " ,[Length] = '" & txtLengthElectrical.Text & "' " +
                                    " ,[Width] = '" & txtWidthElectrical.Text & "' " +
                                    " ,[Height] = '" & txtHeightElectrical.Text & "' " +
                                    " ,[Weight] = '" & txtWeightElectrical.Text & "' " +
                                    " WHERE ItemId = '" & hdnItemNo.Value & "' and StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "'", CommandType.Text)

                    End If
                Next
            End If


            ''----Update Receiving
            'objDerived.GetRecords("UPDATE [AMS].[Tb_Receiving_Dtl] " +
            '                                " SET [PO_Qty] = '" & txtQuantityElectrical.Text & "' " +
            '                                " ,[Qty_Received] = '" & txtQuantityElectrical.Text & "' " +
            '                                " ,[Cost] = '" & txtUnitCostElectrical.Text & "' " +
            '                                " ,[Location] = '" & locations & "' " +
            '                                " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)

            ''----Update PO_dtl
            'objDerived.GetRecords("UPDATE [AMS].[PO_Dtl] " +
            '                        " SET [qty] = '" & txtQuantityElectrical.Text & "' " +
            '                        " ,[cost] = '" & txtUnitCostElectrical.Text & "' " +
            '                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)


            ''----Update AIR_Dtl
            'objDerived.GetRecords("UPDATE [AMS].[AIR_Dtl] " +
            '                        " SET [Qty] = '" & txtQuantityElectrical.Text & "' " +
            '                        " ,[Cost] = '" & txtUnitCostElectrical.Text & "' " +
            '                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim t1 As Decimal
            Dim total As Decimal = 0

            t1 = txtQuantityElectrical.Text * txtUnitCostElectrical.Text
            total = total + t1
            Session("ContractPrice") = total

            'objDerived.Execute("EXEC sp_UpdateBalancefromLedger " & hdnItemNo.Value, CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer = txtQuantityElectrical.Text
            If a >= c Then
                ModalPopupExtender3.Show()
            End If
            Electrical()
            RetriveElectrical()
            ledger()
            Button4.Text = "EDIT"

        End If

    End Sub
    Protected Sub btnROPMed_Click(sender As Object, e As EventArgs) Handles btnROPMed.Click
        hndMed.Value = "MED"
        ModalPopupExtender1.Show()
    End Sub
    Protected Sub txtSize_TextChanged(sender As Object, e As EventArgs) Handles txtSize.TextChanged, txtColor.TextChanged, txtSellectDate.TextChanged, txtLenght.TextChanged, txtWidth.TextChanged, txtHeight.TextChanged, txtUnitPrice.TextChanged, txtReOrderPt.TextChanged
        hndLoad.Value = "1"
    End Sub
    Public Sub loadwarehouseMedical()
        Dim dt As New DataTable
        dt = obj.GetDataTable("Select warehouse_id,wname From ams.loc_warehouse", CommandType.Text)
        drpWarehouseMedical.DataTextField = ("wname")
        drpWarehouseMedical.DataValueField = ("warehouse_id")
        drpWarehouseMedical.DataSource = dt
        drpWarehouseMedical.DataBind()
    End Sub


    Public Sub saveOfficeSuppliesMedical()
        ' -- Start of method tracer
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog1", "console.log('saveOfficeSuppliesMedical: Method start');", True)

        ' Check required fields
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog2", "console.log('Checking required fields: txtBrandName2, txtUnitCostMed, txtQuantityMed, txtReorderPointMed');", True)
        If txtBrandName2.Text = "" Or txtUnitCostMed.Text = "" Or txtQuantityMed.Text = "" Or txtReorderPointMed.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog3", "console.log('Required fields missing. Exiting method.');", True)
        Else
            ' Attempt updating m_item with the new unit
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog4", "console.log('Updating dbo.m_item with unit_id = ' + " & drpUnit.SelectedItem.Value & " );", True)
            objDerived.Execute("Update dbo.m_item set unit_id = " & drpUnit.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)

            ' Get classification
            Dim classification As String = objDerived.GetValue("select classificationid From dbo.tbl_Classification where ClassificationName like '%Supplies%' ", CommandType.Text)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog5", "console.log('classification ID fetched: " & classification & "');", True)

            ' Get category
            Dim category As Integer = objDerived.GetValue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog6", "console.log('category ID fetched: " & category & "');", True)

            ' Check matrix
            Dim matrix As String = objDerived.GetValue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & hdnGAId.Value & " and item_id = " & hdnItemNo.Value & "", CommandType.Text)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog7", "console.log('Matrix check result: " & matrix & "');", True)
            If matrix = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog8", "console.log('Inserting into tblclassmatrix');", True)
                objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id) values('" & classification & "','" & hdnGAId.Value & "','" & hdnItemNo.Value & "','" & category & "','0')", CommandType.Text)
            End If

            ' =-=- SAVE AMS.Tb_Receiving
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog9", "console.log('Preparing AMS.Tb_Receiving record');", True)
            With rcv
                .Received_Date = Date.Parse(txtDateMed.Text)
                .ReceivedBY = 0
                .POHdr_ID = 0
                .PO_No = ""
                .Supplier_ID = 0
                .GA_ID = hdnGAId.Value
                .isAccepted = False
                .UserID = Session("@UserName")
            End With

            Dim rcvID As Long = rcv.save
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog10", "console.log('AMS.Tb_Receiving saved. rcvID = " & rcvID & "');", True)

            Session("Received_ID") = rcvID

            Dim rcv_dtl As New Receiving.t_receiving_dtl

            Dim total As Decimal = 0
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog11", "console.log('Loop for AMS.Tb_Receiving_Dtl start');", True)

            ' For i As Integer = 0 To pItems.Rows.Count - 1
            For i As Integer = 0 To 1 - 1
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog12", "console.log('Index i=' + " & i & " + ' in the AMS.Tb_Receiving_Dtl loop');", True)

                Dim txtPrice As TextBox = CType(txtUnitPrice, TextBox)
                Dim txtqty As TextBox = CType(txtQuantity, TextBox)

                'here 123
                Dim locations As String

                ' Build location string
                If txtBayMedical.Text <> "" Then
                    locations = "Bay-" & txtBayMedical.Text
                End If

                If txtColumnMedical.Text <> "" Then
                    locations = locations + " " + "Column-" & txtColumnMedical.Text
                End If

                If txtFloorMedical.Text <> "" Then
                    locations = locations + " " + "Floor-" & txtFloorMedical.Text
                End If

                If txtRoodMedical.Text <> "" Then
                    locations = locations + " " + "Room-" & txtRoodMedical.Text
                End If

                If txtShelvesMedical.Text <> "" Then
                    locations = locations + " " + "Shelves-" & txtShelvesMedical.Text
                End If

                If txtRackMedical.Text <> "" Then
                    locations = locations + " " + "Rack-" & txtRackMedical.Text
                End If

                If txtBinMedical.Text <> "" Then
                    locations = locations + " " + "Bin-" & txtBinMedical.Text
                End If

                ' =-=- SAVE AMS.Tb_Receiving_Dtl
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog13", "console.log('Saving AMS.Tb_Receiving_Dtl with location = " & locations & "');", True)
                With rcv_dtl
                    .Received_ID = rcvID
                    .Item_ID = hdnItemNo.Value
                    .PO_Qty = txtQuantityMed.Text
                    .Qty_Received = txtQuantityMed.Text
                    .Cost = txtUnitCostMed.Text
                    .Condition = ""
                    .Location = locations
                End With

                Dim RcvDtl_ID As Long = rcv_dtl.save
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog14", "console.log('AMS.Tb_Receiving_Dtl record saved. RcvDtl_ID = " & RcvDtl_ID & "');", True)

                Dim t1 As Decimal
                t1 = txtUnitCostMed.Text * txtQuantityMed.Text
                total = total + t1
            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog15", "console.log('Loop ended. total ContractPrice = " & total & "');", True)

            Session("ContractPrice") = total

            ' =-=- SAVE OF PURCHASED ORDER
            Dim pohdr_id As Long
            Dim POhdr As New t_purchase_order_hdr
            Dim POnumber As String = "Starting Inventory"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog16", "console.log('Preparing to save t_purchase_order_hdr. PO_No = " & POnumber & "');", True)

            POhdr.PO_No = POnumber
            POhdr.PO_Date = DateTime.Parse(txtDateMed.Text)
            POhdr.Supplier_ID = 0
            POhdr.mode_of_procurement_id = 2
            POhdr.DeliveryTerm = 0
            POhdr.paymentTerm = 0
            POhdr.DeliveryDate = DateTime.Parse(txtDateMed.Text)
            POhdr.DeliveryPlace = ""
            POhdr.isDelivered = True
            POhdr.isDelivered = True
            POhdr.pre_procurement_hdr_id = 0
            POhdr.withdv = False
            POhdr.isStag = False
            POhdr.isContinueCutOff = False
            POhdr.isStopForCutOff = False
            POhdr.isShoppingA = False
            POhdr.isPublicInfra = False
            POhdr.isStraight = True
            POhdr.isApproved_PO_Mayor = True
            POhdr.isReceived_PO_Mayor = True
            POhdr.DateApproved_PO_Mayor = DateTime.Parse(txtDateMed.Text)
            POhdr.DateReceived_PO_Mayor = DateTime.Parse(txtDateMed.Text)
            POhdr.DateDisApprove = "01/01/1900"
            POhdr.isGasoline = False
            POhdr.isReimbursement = False

            Dim po_id As New DataTable
            po_id = objDerived.GetDataTable("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog17", "console.log('Checking existing PO. Found rows: " & po_id.Rows.Count & "');", True)

            If po_id.Rows.Count = 0 Then
                POhdr.ContractPrice = CType(Session("ContractPrice"), Decimal)
                pohdr_id = POhdr.save()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog18", "console.log('No existing PO. Creating new POHdr. pohdr_id=' + " & pohdr_id & ");", True)
            Else
                Dim poid As Integer
                Dim TAmount As Decimal
                poid = objDerived.GetValue("Select pohdr_id from ams.po_hdr where po_no like '" & POnumber & "' AND Supplier_ID = '" & 0 & "'", CommandType.Text)
                TAmount = objDerived.GetValue("Select ContractPrice from ams.po_hdr where pohdr_id = '" & poid & "'", CommandType.Text)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog19", "console.log('Existing PO found. poid=' + " & poid & " + ', TAmount=' + " & TAmount & ");", True)

                POhdr.ContractPrice = CType(TAmount + CType(Session("ContractPrice"), Decimal), Decimal)
                POhdr.POHdr_ID = poid
                pohdr_id = POhdr.update()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog20", "console.log('Updating existing POHdr. pohdr_id=' + " & pohdr_id & ");", True)
            End If

            objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = '" & hdnGAId.Value & "', ProjectName = 'Manual Encode' WHERE POHdr_ID = '" & pohdr_id & "'", CommandType.Text)
            Session("POHdr_ID") = pohdr_id
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog21", "console.log('POHdr updated with GA_ID. Session(POHdr_ID)=' + " & pohdr_id & ");", True)

            ' =-=- SAVE OF INSPECTION & ACCEPTANCE
            Dim objhdr As New t_inspection_and_acceptance_hdr
            Dim airhdr_id As Long
            Dim air As String
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog22", "console.log('Generating AIR No via [AMS].[func_GenerateAIR]');", True)
            air = objDerived.GetValue("select [AMS].[func_GenerateAIR]('" & txtDate.Text & "')", CommandType.Text)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog23", "console.log('AIR generated: " & air & "');", True)

            With objhdr
                .AIR_No = air
                .AIR_Date = DateTime.Parse(txtDateMed.Text)
                .Date_Received = DateTime.Parse(txtDateMed.Text)
                .Date_Inspect = DateTime.Parse(txtDateMed.Text)
                .Date_Accepted = DateTime.Parse(txtDateMed.Text)
                .Invoice_No = " "
                .Invoice_date = DateTime.Parse(txtDateMed.Text)
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
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog24", "console.log('AIR_Hdr saved. airhdr_id = " & airhdr_id & "');", True)
            Session("AIRHDR_ID") = airhdr_id

            objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET UserID = '" & Session("@UserName") & "', Received_ID = '" & Session("Received_ID") & "' WHERE AIRHdr_ID = '" & Session("AIRHDR_ID") & "'", CommandType.Text)

            Dim objdtl As New t_inspection_and_acceptance_dtl

            ' =-=- PO Details Save
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog25", "console.log('Saving t_purchase_order_dtl');", True)
            Dim POdtl As New t_purchase_order_dtl
            Dim txtPricePO As TextBox = CType(txtUnitCostMed, TextBox)
            Dim txtqtyPO As TextBox = CType(txtQuantityMed, TextBox)

            POdtl.POHdr_ID = Session("POHdr_ID")
            POdtl.Item_ID = hdnItemNo.Value
            POdtl.cost = txtUnitCostMed.Text
            POdtl.qty = txtQuantityMed.Text
            POdtl.remarks = "Manual Encode"
            POdtl.save()

            ' =-=- AIR DETAILS
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog26", "console.log('Saving t_inspection_and_acceptance_dtl');", True)
            Dim txtPriceair As TextBox = CType(txtUnitCostMed, TextBox)
            Dim txtqtyair As TextBox = CType(txtQuantityMed, TextBox)

            objdtl.Item_ID = hdnItemNo.Value
            objdtl.Qty = txtQuantityMed.Text
            objdtl.Cost = CType(txtUnitCostMed.Text, Decimal)
            objdtl.AIRHdr_ID = Session("AIRHDR_ID")
            objdtl.GA_ID = hdnGAId.Value
            Dim iaDtl_ID As Integer = objdtl.save()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog27", "console.log('AIR_Dtl saved. iaDtl_ID = " & iaDtl_ID & "');", True)

            Session("AIRDtl_ID") = iaDtl_ID
            Dim objStock As New Supplies_Stock

            ' =-=- SAVE STOCK
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog28", "console.log('Saving to AMS.Stock');", True)
            With objStock
                .StockDate = DateTime.Parse(txtDateMed.Text)
                .Item_ID = hdnItemNo.Value
                .Qty = txtQuantityMed.Text
                .Balance = txtQuantityMed.Text

                Dim sb As New StringBuilder()
                If Not String.IsNullOrEmpty(txtBayMedical.Text) Then
                    sb.Append("Bay-" & txtBayMedical.Text)
                End If
                If Not String.IsNullOrEmpty(txtColumnMedical.Text) Then
                    sb.Append(" Column-" & txtColumnMedical.Text)
                End If
                If Not String.IsNullOrEmpty(txtFloorMedical.Text) Then
                    sb.Append(" Floor-" & txtFloorMedical.Text)
                End If
                If Not String.IsNullOrEmpty(txtRoodMedical.Text) Then
                    sb.Append(" Room-" & txtRoodMedical.Text)
                End If
                If Not String.IsNullOrEmpty(txtShelvesMedical.Text) Then
                    sb.Append(" Shelves-" & txtShelvesMedical.Text)
                End If
                If Not String.IsNullOrEmpty(txtRackMedical.Text) Then
                    sb.Append(" Rack-" & txtRackMedical.Text)
                End If
                If Not String.IsNullOrEmpty(txtBinMedical.Text) Then
                    sb.Append(" Bin-" & txtBinMedical.Text)
                End If

                Dim locations As String = sb.ToString().Trim()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog29", "console.log('Stock location: " & locations & "');", True)

                .Location = locations
                .Expiration_Date = txtEDate.Text
                .Cost = CType(txtUnitCostMed.Text, Decimal)
                .Issuance = 0
                .RC_ID = objDerived.GetValue("SELECT DISTINCT [RC_id] FROM [dbo].[View_RespCenter_withFunctions] WHERE [RC_Name] = 'PROVINCIAL GENERAL SERVICES OFFICE'", CommandType.Text)
                .Function_ID = 0
                .Project_ID = 0
                .Program_id = 0
                .F_ID = 4
                .AIRDtl_ID = Session("AIRDtl_ID")
                .GA_ID = hdnGAId.Value
                .Warehouseid = drpWarehouseMedical.SelectedValue()
                .ReorderPt = IIf(IsNumeric(txtReorderPointMed.Text), txtReOrderPt.Text, 0)
            End With

            Dim StockID As Long = objStock.save
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog30", "console.log('AMS.Stock saved. StockID = " & StockID & "');", True)

            objDerived.GetRecords("UPDATE AMS.Stock SET  Received_ID = '" & rcvID & "' WHERE StockID = '" & StockID & "'", CommandType.Text)

            ' =-=- SAVE LEDGER
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog31", "console.log('Saving to AMS.TbStock_Ledger');", True)
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
                .dDate = DateTime.Parse(txtDateMed.Text)
                .Item_ID = hdnItemNo.Value
                .DebitQty = txtQuantityMed.Text
                .DebitCost = FormatNumber(CType(txtPriceair.Text, Decimal) * txtqtyair.Text, 2)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                .BalanceQty = 0
                .BalanceCost = 0
            End With
            objStockLedger.save()

            ' =-=- If GA_ID = 1427 (Office Supplies)
            If hdnGAId.Value = 1427 Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog32", "console.log('GA_ID = 1427. Saving TBSupplies_Info for Office Supplies.');", True)
                Dim objOfficeSup As New SupplieINFO
                With objOfficeSup
                    .StockID = StockID
                    .AIRDtl_ID = Session("AIRDtl_ID")
                    .ItemId = hdnItemNo.Value
                    .Description = txtItemDesc2.Text
                    .BrandName = txtBrandName2.Text
                    .SupplierId = 0
                    .Size = txtSizeMed.Text
                    .Color = txtColorMed.Text
                    .Category = txtCategory.Text
                    .Componentof = " "
                    .Length = txtLenght.Text
                    .Width = txtWidth.Text
                    .Height = txtHeight.Text
                    .Weight = txtWeight.Text
                    .DepreciatedValue = txtDepRate1.Text
                    .DepreciatedRate = txtDepValue1.Text
                    .Status = "Accepted"
                    .Dose = txtDose.Text
                End With
                Dim Supp_ID As Long = objOfficeSup.save
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog33", "console.log('TBSupplies_Info saved. Supp_ID = " & Supp_ID & "');", True)

                objDerived.GetRecords("UPDATE AMS.TBSupplies_Info SET Received_ID = '" & rcvID & "' WHERE SuppliesId = '" & Supp_ID & "'", CommandType.Text)
            End If

            ' =-=- Insert into [AMS].[TbNonFood]
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog34", "console.log('Inserting into AMS.TbNonFood');", True)
            objDerived.GetRecords("INSERT INTO [AMS].[TbNonFood] ([Form],[OTCRx],[Mftgdate],[Batch],[Lot],[EpiryDate],[Alert],[ItemDesc],[BrandName],[StockId],[Item_ID])VALUES('" _
                                  & txtForm.Text & "','" & txtOTC.Text & "','" _
                                  & txtMDate.Text & "','" & txtBatch.Text & "','" _
                                  & txtLot.Text & "','" & txtEDate.Text & "','" _
                                  & txtAlert.Text & "' ,'" & txtItemDesc2.Text & "','" _
                                  & txtBrandName2.Text & "','" & StockID & "','" & hdnItemNo.Value & "') ", CommandType.Text)

            ' Refresh ledger data
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog35", "console.log('Retrieving sp_SuppliesLedger data for Item_ID = " & hdnItemNo.Value & "');", True)
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
            If dtStock.Rows.Count < 4 Then
                dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
            End If
            grdLedger.DataSource = dtStock
            grdLedger.DataBind()

            ' selectitemdesc
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog36", "console.log('Calling selectitemdesc()');", True)
            selectitemdesc()

            ' Final success message
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")

            ' Check reorder point
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog37", "console.log('Checking reorder point for Item_ID = " & hdnItemNo.Value & "');", True)
            Dim a = objDerived.GetValue("select ReorderPt from ams.Stock where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
            Dim c As Integer = Val(txtQuantity.Text)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog38", "console.log('ReorderPt = ' + " & a & " + ', Quantity = ' + " & c & ");", True)
            If a >= c Then
                ModalPopupExtender3.Show()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog39", "console.log('Showing ModalPopupExtender3 because reorder point is reached.');", True)
            End If

            ' End method
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleLog40", "console.log('saveOfficeSuppliesMedical: Method end');", True)
        End If
    End Sub

#Region "Multiple selection grdLedger"

    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Clear all the textbox before displaying something:

        ClearTextBoxes()

        Dim textBoxes As TextBox() = {txtBrandElectrical, txtSizeElectrical, txtUnitPrice, txtSellectDate, txtQuantity, txtSize, txtBrandName1, txtColor, txtLenght, txtWidth, txtHeight, txtWeight}

        For Each textBox As TextBox In textBoxes
            textBox.ReadOnly = False
        Next
        Dim dt As DataTable

        '==FOR ELECTRIC SUPPLIES SUB CATEGORY
        If (DrpSubClass.SelectedItem.Value = 5 Or DrpSubClass.SelectedItem.Value = 6) Then
            dt = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpNameElectrical.SelectedItem.Value & "'", CommandType.Text)
            'drpUnitMed
        ElseIf (DrpSubClass.SelectedItem.Value = 1069) Then

            dt = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
        Else

            dt = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger] '" & drpItemDesc1.SelectedItem.Value & "'", CommandType.Text)
        End If

        Dim cb1 As CheckBox
        Dim x As Integer = 0

        For i As Integer = 0 To grdLedger.Rows.Count - 1
            cb1 = CType(Me.grdLedger.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

            If cb1.Visible AndAlso cb1.Checked Then
                x = 1

                If (DrpSubClass.SelectedItem.Value = 5 Or DrpSubClass.SelectedItem.Value = 6) Then
                    Button4.Enabled = True
                    Button4.Text = "EDIT"
                ElseIf (DrpSubClass.SelectedItem.Value = 1069) Then
                    btnUpdateDetails2.Enabled = True
                    btnUpdateDetails2.Text = "EDIT"
                Else
                    btnSave.Enabled = True
                    btnSave.Text = "EDIT"
                End If

            End If
        Next

        If x = 0 Then

            If (DrpSubClass.SelectedItem.Value = 5 Or DrpSubClass.SelectedItem.Value = 6) Then
                Button4.Enabled = True
                Button4.Text = "SAVE"

            ElseIf (DrpSubClass.SelectedItem.Value = 1069) Then
                btnUpdateDetails2.Enabled = True
                btnUpdateDetails2.Text = "SAVE"
            Else
                btnSave.Enabled = True
                btnSave.Text = "SAVE"
            End If
        End If


        If dt.Rows.Count > 0 Then
            txtBrandElectrical.Text = String.Empty
            txtSizeElectrical.Text = String.Empty


            For xa As Integer = 0 To grdLedger.Rows.Count - 1
                cb1 = CType(Me.grdLedger.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Visible AndAlso cb1.Checked Then
                    If dt.Rows.Count > 0 Then


                        '==FOR MEDICAL SUBCATEGORY
                        If (DrpSubClass.SelectedItem.Value = 1069) Then

                            txtUnitCostMed.Text = dt.Rows(xa).Item("cost").ToString()
                            txtDateMed.Text = dt.Rows(xa).Item("dDate").ToString()

                            Dim unitsValue As String = dt.Rows(xa).Item("DebitUnit").ToString()
                            drpUnitMed.SelectedItem.Text = unitsValue

                            txtQuantityMed.Text = dt.Rows(xa).Item("DebitQty").ToString()

                            Dim dt2 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TBSupplies_Info AS a WHERE  (ItemId = '" & hdnItemNo.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                            Dim dt3 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.Stock AS a WHERE  (Item_ID = '" & hdnItemNo.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                            Dim dt4 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TbNonFood AS a WHERE  (Item_ID = '" & hdnItemNo.Value & "')  AND (StockId = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                            'Dim warehouseName As String = objDerived.GetValue("select AMS.Loc_Warehouse.wName from AMS.Loc_Warehouse where AMS.Loc_Warehouse.warehouse_ID = '" & dt3.Rows(0).Item("warehouse_ID").ToString() & "' ", CommandType.Text)

                            If dt2.Rows.Count > 0 Then
                                txtSizeMed.Text = dt2.Rows(0).Item("Size").ToString()
                                txtBrandName2.Text = dt2.Rows(0).Item("BrandName").ToString()
                                txtColorMed.Text = dt2.Rows(0).Item("Color").ToString()
                                txtItemDesc2.Text = dt2.Rows(0).Item("Description").ToString()
                                txtDose.Text = dt2.Rows(0).Item("Dose").ToString()
                            End If

                            If dt3.Rows.Count > 0 Then
                                txtReorderPointMed.Text = dt3.Rows(0).Item("ReorderPt").ToString()
                                'drpWarehouseMedical.SelectedValue = dt3.Rows(0).Item("warehouse_ID").ToString()
                                'drpWarehouseMedical.SelectedItem.Text = warehouseName
                            End If

                            If dt4.Rows.Count > 0 Then
                                txtForm.Text = dt4.Rows(0).Item("Form").ToString()
                                txtOTC.Text = dt4.Rows(0).Item("OTCRx").ToString()
                                txtMDate.Text = dt4.Rows(0).Item("Mftgdate").ToString()
                                txtLot.Text = dt4.Rows(0).Item("Lot").ToString()
                                txtAlert.Text = dt4.Rows(0).Item("Alert").ToString()
                                txtEDate.Text = dt4.Rows(0).Item("EpiryDate").ToString()
                                txtBatch.Text = dt4.Rows(0).Item("Batch").ToString()
                            End If

                        End If

                        '==FOR ELECTRIC SUPPLIES & JANITOR SUB CATEGORY
                        If (DrpSubClass.SelectedItem.Value = 5 Or DrpSubClass.SelectedItem.Value = 6) Then

                            txtUnitCostElectrical.Text = dt.Rows(xa).Item("cost").ToString()
                            txtDateElectrical.Text = dt.Rows(xa).Item("dDate").ToString()

                            Dim unitsValue As String = dt.Rows(xa).Item("DebitUnit").ToString()
                            drpUnitElectrical.SelectedItem.Text = unitsValue

                            txtQuantityElectrical.Text = dt.Rows(xa).Item("DebitQty").ToString()

                            Dim dt2 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TBSupplies_Info AS a WHERE  (ItemId = '" & drpNameElectrical.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                            Dim dt3 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.Stock AS a WHERE  (Item_ID = '" & drpNameElectrical.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                            'Dim warehouseName As String = objDerived.GetValue("select AMS.Loc_Warehouse.wName from AMS.Loc_Warehouse where AMS.Loc_Warehouse.warehouse_ID = '" & dt3.Rows(0).Item("warehouse_ID").ToString() & "' ", CommandType.Text)

                            If dt2.Rows.Count > 0 Then
                                txtSizeElectrical.Text = dt2.Rows(0).Item("Size").ToString()
                                txtBrandElectrical.Text = dt2.Rows(0).Item("BrandName").ToString()
                                txtColorElectrical.Text = dt2.Rows(0).Item("Color").ToString()
                                txtLengthElectrical.Text = dt2.Rows(0).Item("Length").ToString()
                                txtWidthElectrical.Text = dt2.Rows(0).Item("Width").ToString()
                                txtHeightElectrical.Text = dt2.Rows(0).Item("Height").ToString()

                            End If
                            If dt3.Rows.Count > 0 Then
                                txtReorderPointElectrical.Text = dt3.Rows(0).Item("ReorderPt").ToString()
                                'drpWarehouseElectrical.SelectedValue = dt3.Rows(0).Item("warehouse_ID").ToString()
                                'drpWarehouseElectrical.SelectedItem.Text = warehouseName
                            End If

                            '==FOR COMMON SUPPLIES AND OFFICE SUPP
                        Else

                            txtUnitPrice.Text = dt.Rows(xa).Item("cost").ToString()
                            txtSellectDate.Text = dt.Rows(xa).Item("dDate").ToString()

                            'SOME UNIT FROM STOCK TABLE FOR SOME REASON DONT EXIST IN LIST OF DROPDOWN UNIT
                            Dim unitValue As String = dt.Rows(xa).Item("DebitUnit").ToString()
                            drpUnit.SelectedItem.Text = unitValue

                            txtQuantity.Text = dt.Rows(xa).Item("DebitQty").ToString()

                            Dim dt2 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TBSupplies_Info AS a WHERE  (ItemId = '" & drpItemDesc1.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)
                            Dim dt3 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.Stock AS a WHERE  (Item_ID = '" & drpItemDesc1.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)

                            'Dim warehouseName As String = objDerived.GetValue("select AMS.Loc_Warehouse.wName from AMS.Loc_Warehouse where AMS.Loc_Warehouse.warehouse_ID = '" & dt3.Rows(0).Item("warehouse_ID").ToString() & "' ", CommandType.Text)

                            If dt2.Rows.Count > 0 Then
                                txtSize.Text = dt2.Rows(0).Item("Size").ToString()
                                txtBrandName1.Text = dt2.Rows(0).Item("BrandName").ToString()
                                txtColor.Text = dt2.Rows(0).Item("Color").ToString()
                                txtLenght.Text = dt2.Rows(0).Item("Length").ToString()
                                txtWidth.Text = dt2.Rows(0).Item("Width").ToString()
                                txtHeight.Text = dt2.Rows(0).Item("Height").ToString()
                            End If
                            If dt3.Rows.Count > 0 Then
                                txtReOrderPt.Text = dt3.Rows(0).Item("ReorderPt").ToString()
                                'drpWarehouse.SelectedValue = dt3.Rows(0).Item("warehouse_ID").ToString()
                                'drpWarehouse.SelectedItem.Text = warehouseName

                                'drpWarehouseElectrical
                            End If
                        End If

                    End If
                End If
            Next
        End If

    End Sub

#End Region
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



#Region "HELPER METHODS"


    Protected Sub ClearTextBoxes()

        '=====================CONDITIONS ARE BASED ON SUB CATEGORY SELECTION====================
        If (DrpSubClass.SelectedItem.Value = 1069) Then
            txtItemDesc2.Text = String.Empty
            txtBrandName2.Text = String.Empty
            txtDose.Text = String.Empty
            txtSizeMed.Text = String.Empty
            txtColorMed.Text = String.Empty

            txtReorderPointMed.Text = String.Empty
            txtForm.Text = String.Empty
            txtOTC.Text = String.Empty
            txtUnitCostMed.Text = String.Empty
            txtQuantityMed.Text = String.Empty
            txtDateMed.Text = String.Empty

            txtBatch.Text = String.Empty
            txtLot.Text = String.Empty
            txtMDate.Text = String.Empty
            txtEDate.Text = String.Empty
            txtAlert.Text = String.Empty
        End If

        If (DrpSubClass.SelectedItem.Value = 5 Or DrpSubClass.SelectedItem.Value = 6) Then
            txtBrandElectrical.Text = String.Empty
            txtSizeElectrical.Text = String.Empty
            txtColorElectrical.Text = String.Empty
            txtUnitCostElectrical.Text = String.Empty
            txtReorderPointElectrical.Text = String.Empty
            txtDateElectrical.Text = String.Empty
            txtLengthElectrical.Text = String.Empty
            txtWidthElectrical.Text = String.Empty
            txtWeightElectrical.Text = String.Empty
            txtHeightElectrical.Text = String.Empty
            txtQuantityElectrical.Text = String.Empty
        End If

        txtBrandElectrical.Text = String.Empty
        txtSizeElectrical.Text = String.Empty
        txtUnitPrice.Text = String.Empty
        txtSellectDate.Text = String.Empty
        drpUnit.SelectedItem.Text = String.Empty
        txtQuantity.Text = String.Empty
        txtSize.Text = String.Empty
        txtBrandName1.Text = String.Empty
        txtColor.Text = String.Empty
        txtLenght.Text = String.Empty
        txtWidth.Text = String.Empty
        txtHeight.Text = String.Empty
    End Sub

#End Region

End Class


'TODO bin inbox on janitorial subcategory and bellow have weird textbox
'TODO warehouse have different functions