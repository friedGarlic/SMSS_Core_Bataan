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

#Region "PROPERTY"
    Private Property PListofGL() As DataTable
        Get
            Return CType(Session("PListofGL"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PListofGL") = value
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
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'objx.GetAccessRight(Me.Session("@UserName"), Page)

        'If objx.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If

        If Not Page.IsPostBack Then
            txtDate.Text = Date.Now.ToString("MM-dd-yyyy")

            txtSearchStock.Text = ""
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("select a.ClassificationId,ClassificationName From dbo.tbl_Classification as a inner join tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id = b.GA_ID and c.BGA_ID = b.BGA_ID where b.AllotmentClass_ID = 2 and a.isenable = 1 group by a.ClassificationId,ClassificationName,seqno order by seqno", CommandType.Text)
            ddClassification.DataSource = CType(dt, DataTable)
            ddClassification.DataTextField = ("ClassificationName")
            ddClassification.DataValueField = ("ClassificationId")
            ddClassification.DataBind()

            'try defaultvalue
            ddClassification.Items.Insert(0, New ListItem("-- Please select --", ""))
            ddClassification.SelectedIndex = 0

            'drpDepartment.DataSource = objDerived.GetDataTable("[AMS].[sp_VIEW_Departments] '" & Session("@UserID") & "'", CommandType.Text)
            'drpDepartment.DataTextField = ("RC_Name")
            'drpDepartment.DataValueField = ("RC_ID")
            'drpDepartment.DataBind()


            SelectClassification()



            txtSearchStock.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchStock.ClientID & "')")

            'Me.MultiView1.SetActiveView(Me.View2)


        End If
        ledger()

    End Sub
    Public Sub SelectGLAccount()
        Dim dt As New DataTable
        Dim glaccount As Integer

        If ddGlAccount.Text = "" Then
            glaccount = 0
        Else
            glaccount = ddGlAccount.SelectedItem.Value
        End If

        Dim classification As Integer
        'Added default index as 1 for intial page load
        'If ddClassification.SelectedItem.Value = 0 Then
        If ddClassification.SelectedIndex = 0 Then
            classification = 1
            ddClassification.SelectedIndex = 1
        Else
            classification = ddClassification.SelectedIndex
        End If

        Dim sub_classification As Integer
        If drpSubClass.SelectedIndex = 0 Then
            sub_classification = 1
            drpSubClass.SelectedIndex = 1
        Else
            sub_classification = drpSubClass.SelectedIndex
        End If


        '        dt = obj.GetDataTable("select DISTINCT item_particular_id,description	" &
        '"	From AMS.item_particular as a " &
        '"        inner join tblclassmatrix as c on a.item_particular_id = c.categoryid	" &
        ' "        where " &
        ' "        c.ga_id = " & glaccount & " order by description", CommandType.Text)
        'ddCategory.DataSource = obj.GetDataTable("select DISTINCT item_particular_id,description" &
        '        "	From AMS.item_particular as a " &
        '        "        inner join tblclassmatrix as c on a.item_particular_id = c.categoryid	" &
        '        "        where " &
        '        "        c.ga_id = '" & glaccount & "' order by description", CommandType.Text)

        ddCategory.DataSource = obj.GetDataTable("exec ams.FMparticularsSupplies '" & glaccount & "','" & 0 & "','" & classification & "','" & sub_classification & "'", CommandType.Text)
        ddCategory.DataTextField = ("description")
        ddCategory.DataValueField = ("item_particular_id")
        ddCategory.DataBind()



        SelectCategory()
    End Sub

    Protected Sub ddGlAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddGlAccount.SelectedIndexChanged

        SelectGLAccount()
        MultiviewSupplier()
    End Sub
    Public Sub loadwarehouse()
        Dim dt As New DataTable
        dt = obj.GetDataTable("Select warehouse_id, wname From ams.loc_warehouse", CommandType.Text)
        drpWarehouse.DataTextField = ("wname")
        drpWarehouse.DataValueField = ("warehouse_id")
        drpWarehouse.DataSource = dt
        drpWarehouse.DataBind()

        drpMROsuppliesWarehouse.DataTextField = ("wname")
        drpMROsuppliesWarehouse.DataValueField = ("warehouse_id")
        drpMROsuppliesWarehouse.DataSource = dt
        drpMROsuppliesWarehouse.DataBind()

        drpMedicineWarehouse.DataTextField = ("wname")
        drpMedicineWarehouse.DataValueField = ("warehouse_id")
        drpMedicineWarehouse.DataSource = dt
        drpMedicineWarehouse.DataBind()

        drpFoodWarehouse.DataTextField = ("wname")
        drpFoodWarehouse.DataValueField = ("warehouse_id")
        drpFoodWarehouse.DataSource = dt
        drpFoodWarehouse.DataBind()


        drpMROConsOthersWarehouse.DataTextField = ("wname")
        drpMROConsOthersWarehouse.DataValueField = ("warehouse_id")
        drpMROConsOthersWarehouse.DataSource = dt
        drpMROConsOthersWarehouse.DataBind()


    End Sub


    Public Sub MultiviewSupplier()
        lblCategory.Text = ""
        Dim glaccount As Integer
        If ddGlAccount.Text = "" Then
            glaccount = 0
        Else
            glaccount = ddGlAccount.SelectedItem.Value
        End If

        If glaccount = 1432 Then
            ''0329
            Dim category As String
            category = objDerived.GetValue("Select description from ams.item_particular  where item_particular_id =" & ddCategory.SelectedValue(), CommandType.Text)
            lblCategory.Text = " - " & category
            ' Drugs and Medicines
            'lblDetails.Text = "DRUGS & MEDICINE DETAILS"
            txtSearchStock.Text = ""
            'lblHistoryDetails.Text = "DRUGS & MEDICINE DETAILS"
            lblHistoryDetails.Text = "DETAILS"


            Me.MultiView1.SetActiveView(Me.View5)
            'imgmedical.ImageUrl = "~/images/medicine_icon.jpg"
            loadStockMedSupplies()

        ElseIf glaccount = 1433 Then
            ' Medical, Dental and Laboratory Supplies
            'lblDetails.Text = "MEDICAL SUPPLY DETAILS"
            txtSearchStock.Text = ""
            'lblHistoryDetails.Text = "MEDICAL SUPPLY DETAILS"
            lblHistoryDetails.Text = "DETAILS"

            Me.MultiView1.SetActiveView(Me.View1)
            'imgmedical.ImageUrl = "~/images/medicine_icon.jpg"
            loadStockMedSupplies()

        ElseIf glaccount = 1430 Then
            ' Food Supplies
            'lblDetails.Text = "FOOD DETAILS"
            txtSearchStock.Text = ""
            lblHistoryDetails.Text = "DETAILS"
            'lblHistoryDetails.Text = "FOOD DETAILS"

            Me.MultiView1.SetActiveView(Me.View4)
            'imgmedical.ImageUrl = "~/images/Food.JPG"
            LoadSupplies()

        ElseIf glaccount = 1441 Then
            'Water
            'lblDetails.Text = "WATER DETAILS"
            txtSearchStock.Text = ""
            lblHistoryDetails.Text = "DETAILS"
            'lblHistoryDetails.Text = "WATER DETAILS"

            Me.MultiView1.SetActiveView(Me.View2)
            'imgmedical.ImageUrl = "~/images/Water.jpg"
            LoadSupplies()


        ElseIf glaccount = 1427 Then
            'Office Supplies
            'lblDetails.Text = "OFFICE SUPPLY DETAILS"
            txtSearchStock.Text = ""
            lblHistoryDetails.Text = "DETAILS"
            'lblHistoryDetails.Text = "OFFICE SUPPLY DETAILS"
            Me.MultiView1.SetActiveView(Me.View1)
            'imgOffice.ImageUrl = "~/images/supplies_icon.jpg"
            loadStockOfficeSupplies()
            'LoadStockChangeIndex()

        Else


            'Non-Food & Others Items
            'lblDetails.Text = "NON-FOOD DETAILS"
            txtSearchStock.Text = ""
            lblHistoryDetails.Text = "DETAILS"
            'lblHistoryDetails.Text = "NON-FOOD DETAILS"
            Dim classification As String = objDerived.GetValue("select ClassificationName from dbo.tbl_Classification where ClassificationId = " & ddClassification.SelectedIndex, CommandType.Text)
            LoadSupplies()
            If classification.Contains("Consumables") Then
                Me.MultiView1.SetActiveView(Me.View6)

            ElseIf classification.Contains("Supplies") Then
                Me.MultiView1.SetActiveView(Me.View3)
            Else
                Me.MultiView1.SetActiveView(Me.View7)
            End If

            'imgmedical.ImageUrl = "~/images/blankImage.jpg"


        End If
    End Sub

    ' ==== Search Options =====
    Protected Sub btnSearchStock_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        loadSearch()
        LoadStockChangeIndex()
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

        Dim dt2 As New DataTable
        dt2 = objDerived.GetDataTable("select Item_ID from ams.Stock group by Item_ID having sum(ReorderPt) > sum(Balance)", CommandType.Text)

        If dt2.Rows.Count <> 0 Then
            ModalPopupExtender3.Show()
        End If

        pTempPPQ = objDerived.GetDataTable("Select * from ams.tbl_Price_per_qty where item_id ='" & grdStockList.SelectedDataKey(0) & "'", CommandType.Text)
        GridPPQ.DataSource = pTempPPQ
        GridPPQ.DataBind()


    End Sub
    Protected Sub LoadStockChangeIndex()
        If ddGlAccount.SelectedItem.Value = 1432 Then
            ' Drugs and Medicines
            Me.MultiView1.SetActiveView(Me.View5)
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
            Me.MultiView1.SetActiveView(Me.View4)
            LoadStockGridBatches()
            'loadStockDetails()

            ledger()

        ElseIf ddGlAccount.SelectedItem.Value = 1441 Then
            'Water
            Me.MultiView1.SetActiveView(Me.View2)
            LoadStockGridBatches()
            'loadStockDetails()

            ledger()



        Else 'If ddGlAccount.SelectedItem.Value = 927 Or ddGlAccount.SelectedItem.Value = 790 Or ddGlAccount.SelectedItem.Value = 795 Then
            'Non-Food Items
            Dim classification As String = objDerived.GetValue("select ClassificationName from dbo.tbl_Classification where ClassificationId = " & ddClassification.SelectedValue(), CommandType.Text)

            If classification.Contains("Consumables") Then
                Me.MultiView1.SetActiveView(Me.View6)
            ElseIf classification.Contains("Supplies") Then
                Me.MultiView1.SetActiveView(Me.View3)
            Else
                Me.MultiView1.SetActiveView(Me.View7)
            End If


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
        Dim CY As String = "CY" & Year(txtDate.Text)

        dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022_Stockcardmain] '" & ddGlAccount.SelectedValue() & "','0','" & CY & "','" & 0 & "','" & 0 & "'", CommandType.Text)

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
        Dim SubCatID As Integer
        If ddSubCategory.SelectedItem.Text = "All" Then
            SubCatID = 0
        Else
            SubCatID = ddSubCategory.SelectedItem.Value
        End If

        If ddCategory.SelectedIndex = 0 Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022_Stockcardmain] '" & ddGlAccount.SelectedValue() & "','0','" & CY & "','" & 0 & "','" & 0 & "'", CommandType.Text)
        ElseIf ddCategory.SelectedIndex > 0 Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022_Stockcardmain] '" & ddGlAccount.SelectedValue() & "','0','" & CY & "','" & ddCategory.SelectedValue() & "','" & 0 & "'", CommandType.Text)
        ElseIf ddCategory.SelectedIndex <> 0 And ddSubCategory.SelectedIndex <> 0 Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022_Stockcardmain] '" & ddGlAccount.SelectedValue() & "','0','" & CY & "','" & ddCategory.SelectedValue() & "','" & ddSubCategory.SelectedValue() & "'", CommandType.Text)
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
        Dim subcategory As String
        If ddSubCategory.Text = "" Then
            subcategory = "0"
        Else
            subcategory = ddSubCategory.SelectedValue()
        End If

        Dim dtStock As New DataTable
        If ddCategory.SelectedItem.Value = 0 Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022_Stockcardmain] '" & ddGlAccount.SelectedValue() & "','0','CY2022','" & 0 & "','" & subcategory & "'", CommandType.Text)
        ElseIf ddSubCategory.SelectedIndex = 0 Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022_Stockcardmain] '" & ddGlAccount.SelectedValue() & "','0','CY2022','" & 0 & "','" & 0 & "'", CommandType.Text)
        Else
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022_Stockcardmain] '" & ddGlAccount.SelectedValue() & "','0','CY2022','" & 0 & "','" & subcategory & "'", CommandType.Text)
        End If
        loadCleartext()

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


    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpUnit.DataSource = dt
        drpUnit.DataTextField = ("Description")
        drpUnit.DataValueField = ("Unit_ID")
        drpUnit.DataBind()

        drpMROEquipmentUnit.DataSource = dt
        drpMROEquipmentUnit.DataTextField = ("Description")
        drpMROEquipmentUnit.DataValueField = ("Unit_ID")
        drpMROEquipmentUnit.DataBind()

    End Sub

    Public Sub loadmrosuppliesInfo()

        If grdStockList.SelectedRow.Cells(3).Text <> 0 Then
            loadUnit()
            Dim dt As New DataTable

            dt = objDerived.GetDataTable("select a.Description,a.BrandName,a.Size,a.Color,a.DepreciatedRate,a.DepreciatedValue,a.Length,a.Width,a.Height,a.Weight,b.Cost,convert(int,b.Qty) ,isnull(b.Location,' - '),isnull(b.warehouse_id,1) ,isnull(a.componentof,''),c.Unit_ID  From [AMS].[TBSupplies_Info] as a inner join ams.Stock as b on a.StockID = b.StockID inner join dbo.m_item as c on a.ItemId = c.Item_ID   where c.Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            If dt.Rows.Count > 0 Then
                lblMROsuppliesName.Text = grdStockList.SelectedRow.Cells(2).Text 'dt.Rows(0).Item(0)
                txtMROsuppliesName.Text = dt.Rows(0).Item(0).ToString
                txtItemDesc2.ReadOnly = True

                lblMROsuppliesBrandName.Text = dt.Rows(0).Item(1)
                txtMROsuppliesBrandName.Text = dt.Rows(0).Item(1)
                txtBrandName2.ReadOnly = True


                lblMROsuppliesSize.Text = dt.Rows(0).Item(2)
                txtMROsuppliesSize.Text = dt.Rows(0).Item(2)
                txtSize.Text = dt.Rows(0).Item(2)
                txtSize.ReadOnly = True

                lblMROsuppliesColor.Text = dt.Rows(0).Item(3)
                txtMROsuppliesColor.Text = dt.Rows(0).Item(3)

                txtColor.Text = dt.Rows(0).Item(3)
                txtColor.ReadOnly = True


                lblMROsuppliesDeprate.Text = dt.Rows(0).Item(4)
                txtDepRate.ReadOnly = True
                lblMROsuppliesDepValue.Text = dt.Rows(0).Item(5)
                txtDepValue.ReadOnly = True

                'txtCategory.ReadOnly = True

                lblMROsuppliesLength.Text = dt.Rows(0).Item(6)
                txtMROsuppliesLength.Text = dt.Rows(0).Item(6)
                txtLenght.ReadOnly = True

                lblMROsuppliesWidth.Text = dt.Rows(0).Item(7)
                txtMROsuppliesWidth.Text = dt.Rows(0).Item(7)
                txtWidth.ReadOnly = True

                lblMROsuppliesheight.Text = dt.Rows(0).Item(8)
                txtMROsuppliesheight.Text = dt.Rows(0).Item(8)
                txtHeight.ReadOnly = True

                lblMROsuppliesWeight.Text = dt.Rows(0).Item(8)
                txtMROsuppliesWeight.Text = dt.Rows(0).Item(8)
                txtWeight.ReadOnly = True

                lblMROsuppliesUnitPrice.Text = dt.Rows(0).Item(10)
                txtMROsuppliesUnitPrice.Text = dt.Rows(0).Item(10)
                txtUnitPrice.ReadOnly = True
                'lblMROsuppliesQuantity.Text = dt.Rows(0).Item(11)
                'txtMROsuppliesQuantity.Text = dt.Rows(0).Item(11)
                lblMROsuppliesQuantity.Text = grdStockList.SelectedRow.Cells(3).Text
                txtMROsuppliesQuantity.Text = grdStockList.SelectedRow.Cells(3).Text

                txtQuantity.ReadOnly = True



                '''--------------------location
                Dim location As String
                location = dt.Rows(0).Item(12)
                Dim locationsplit As String() = location.Split("-")
                If location.Contains("Bay") Then
                    txtMROsuppliesBay.Text = locationsplit(1)
                ElseIf location.Contains("Column") Then
                    txtMROsuppliesColumn.Text = locationsplit(1)
                ElseIf location.Contains("Floor") Then
                    txtMROsuppliesFloor.Text = locationsplit(1)
                ElseIf location.Contains("Room") Then
                    txtMROsuppliesRoom.Text = locationsplit(1)
                ElseIf location.Contains("Shelves") Then
                    txtMROsuppliesShelves.Text = locationsplit(1)
                ElseIf location.Contains("Rack") Then
                    txtMROsuppliesRack.Text = locationsplit(1)
                ElseIf location.Contains("Bin") Then
                    txtMROsuppliesBin.Text = locationsplit(1)
                End If

                Dim warehouse As String
                warehouse = dt.Rows(0).Item(13)
                drpMROsuppliesWarehouse.SelectedValue = warehouse
                lblMROsuppliesComponentof.Text = dt.Rows(0).Item(14)
                txtMROsuppliesComponentof.Text = dt.Rows(0).Item(14)

                lblMROsuppliesUnit.Text = objDerived.GetValue("select Description  from ams.m_Unit where Unit_ID =" & dt.Rows(0).Item(15), CommandType.Text)
                drpUnit.Items.FindByValue(dt.Rows(0).Item(15)).Selected = True
                ' lblMROsuppliesComponentof.ReadOnly = True
                btnSave.Enabled = False
                btnCancel.Enabled = False

            End If



        Else

            lblMROsuppliesName.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)


        End If


    End Sub

    Public Sub loadofficesuppliesInfo()
        Dim dt As New DataTable
        'dt = obj.GetDataTable("select a.Description,a.BrandName,a.Size,a.Color,a.DepreciatedRate,a.DepreciatedValue,a.Length,a.Width,a.Height,a.Weight,b.Cost,convert(int,b.Qty) ,isnull(b.Location,' - '),isnull(b.warehouse_id,1)  From [AMS].[TBSupplies_Info] as a inner join ams.Stock as b on a.StockID = b.StockID  where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), commandtype.text)
        dt = obj.GetDataTable("EXEC [dbo].[usp_GetSuppliesInfo] " & grdStockList.SelectedDataKey("Item_ID") & "", CommandType.Text)
        'txtItemDesc1.text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
        If dt.Rows.Count > 0 Then
            lblItemDesc1.Text = grdStockList.SelectedRow.Cells(2).Text
            txtItemDesc1.Text = grdStockList.SelectedRow.Cells(2).Text
            txtItemDesc1.ReadOnly = True

            lblBrandName1.Text = dt.Rows(0).Item(1)
            txtBrandName1.Text = dt.Rows(0).Item(1)
            txtBrandName1.ReadOnly = True

            lblSize.Text = dt.Rows(0).Item(2)
            txtSize.Text = dt.Rows(0).Item(2)
            txtSize.ReadOnly = True

            lblColor.Text = dt.Rows(0).Item(3)
            txtColor.Text = dt.Rows(0).Item(3)
            txtColor.ReadOnly = True

            lblDepRate1.Text = dt.Rows(0).Item(4)
            txtDepRate1.Text = dt.Rows(0).Item(4)
            txtDepRate1.ReadOnly = True

            lblDepValue1.Text = dt.Rows(0).Item(5)
            txtDepValue1.Text = dt.Rows(0).Item(5)
            txtDepValue1.ReadOnly = True


            txtCategory.ReadOnly = True

            lblLenght.Text = dt.Rows(0).Item(6)
            txtLenght.Text = dt.Rows(0).Item(6)
            txtLenght.ReadOnly = True

            lblWidth.Text = dt.Rows(0).Item(7)
            txtWidth.Text = dt.Rows(0).Item(7)
            txtWidth.ReadOnly = True

            lblHeight.Text = dt.Rows(0).Item(8)
            txtHeight.Text = dt.Rows(0).Item(8)
            txtHeight.ReadOnly = True

            lblWeight.Text = dt.Rows(0).Item(9)
            txtWeight.Text = dt.Rows(0).Item(9)
            txtWeight.ReadOnly = True

            lblUnitPrice.Text = dt.Rows(0).Item(10)
            txtUnitPrice.Text = dt.Rows(0).Item(10)
            txtUnitPrice.ReadOnly = True

            lblQuantity.Text = dt.Rows(0).Item(11)
            txtQuantity.Text = dt.Rows(0).Item(11)
            txtQuantity.ReadOnly = True



            '''--------------------location
            'Dim location As String
            'location = dt.Rows(0).Item(12)
            'Dim locationsplit As String() = location.Split(" ")

            'If location.Contains("Bay") Then
            '    Dim a As String = locationsplit(0)
            '    Dim a1 As String() = a.Split("-")
            '    txtBay.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtBay.Text = ""
            'End If
            'If location.Contains("Column") Then
            '    Dim a As String = locationsplit(1)
            '    Dim a1 As String() = a.Split("-")
            '    txtColumn.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtColumn.Text = ""
            'End If
            'If location.Contains("Floor") Then
            '    Dim a As String = locationsplit(2)
            '    Dim a1 As String() = a.Split("-")
            '    txtFloor.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtFloor.Text = ""
            'End If
            'If location.Contains("Room") Then
            '    Dim a As String = locationsplit(3)
            '    Dim a1 As String() = a.Split("-")
            '    txtRoom.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtRoom.Text = ""
            'End If
            'If location.Contains("Shelves") Then
            '    Dim a As String = locationsplit(4)
            '    Dim a1 As String() = a.Split("-")
            '    txtShelves.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtShelves.Text = ""
            'End If
            'If location.Contains("Rack") Then

            '    Dim a As String = locationsplit(5)
            '    Dim a1 As String() = a.Split("-")
            '    txtRack.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtRack.Text = ""
            'End If
            'If location.Contains("Bin") Then
            '    Dim a As String = locationsplit(6)
            '    Dim a1 As String() = a.Split("-")
            '    txtBin.Text = a1(1)
            '    On Error Resume Next
            'Else
            '    txtBin.Text = ""
            'End If

            Dim location As String = dt.Rows(0).Item(12)
            Dim locationParts As String() = location.Split(" ")

            txtBay.Text = ""
            txtColumn.Text = ""
            txtFloor.Text = ""
            txtRoom.Text = ""
            txtShelves.Text = ""
            txtRack.Text = ""
            txtBin.Text = ""

            For Each part As String In locationParts
                Dim partParts As String() = part.Split("-")

                Select Case True
                    Case part.Contains("Bay")
                        txtBay.Text = partParts(1)
                    Case part.Contains("Column")
                        txtColumn.Text = partParts(1)
                    Case part.Contains("Floor")
                        txtFloor.Text = partParts(1)
                    Case part.Contains("Room")
                        txtRoom.Text = partParts(1)
                    Case part.Contains("Shelves")
                        txtShelves.Text = partParts(1)
                    Case part.Contains("Rack")
                        txtRack.Text = partParts(1)
                    Case part.Contains("Bin")
                        txtBin.Text = partParts(1)
                End Select
            Next


            Dim warehouse As String
            warehouse = dt.Rows(0).Item(13)
            drpWarehouse.SelectedValue = warehouse
            btnSave.Enabled = False
            btnCancel.Enabled = False

        Else
            lblItemDesc1.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            txtItemDesc1.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)


            lblBrandName1.Text = obj.GetValue("select Brand From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            txtBrandName1.Text = obj.GetValue("select Brand From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            txtSize.Text = obj.GetValue("select size From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            txtColor.Text = obj.GetValue("select color From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            txtBrandName1.ReadOnly = False
            Dim CY As String = "CY" & Year(txtDate.Text)

            lblUnitPrice.Text = obj.GetValue("select " & CY & " From dbo.m_item_detail where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            lblQuantity.Text = obj.GetValue("select sum(Qty) From ams.Stock where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            'txtQuantity.ReadOnly = False
            'txtUnitPrice.ReadOnly = False
            'txtColor.ReadOnly = False
            'txtDepRate1.ReadOnly = False
            'txtItemDesc1.ReadOnly = False
            'txtCategory.ReadOnly = False
            'txtLenght.ReadOnly = False
            'txtWidth.ReadOnly = False
            'txtHeight.ReadOnly = False
            'txtWeight.ReadOnly = False
            'txtSize.ReadOnly = False
            'txtDepValue1.ReadOnly = False
            For Each textBox As TextBox In New TextBox() {txtQuantity, txtUnitPrice, txtColor, txtDepRate1, txtItemDesc1, txtCategory, txtLenght, txtWidth, txtHeight, txtWeight, txtSize, txtDepValue1}
                textBox.ReadOnly = False
            Next

            btnSave.Enabled = True
            btnCancel.Enabled = True

            Dim itemlocation As New DataTable
            itemlocation = obj.GetDataTable("select Location,warehouse_ID From ams.Stock where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            '''--------------------location
            Dim location As String
            location = itemlocation.Rows(0).Item(0)
            Dim locationsplit As String() = location.Split(" ")
            'If location.Contains("Bay") Then
            '    txtBay.text = locationsplit(1)
            'ElseIf location.Contains("Column") Then
            '    txtColumn.text = locationsplit(1)
            'ElseIf location.Contains("Floor") Then
            '    txtFloor.text = locationsplit(1)
            'ElseIf location.Contains("Room") Then
            '    txtRoom.text = locationsplit(1)
            'ElseIf location.Contains("Shelves") Then
            '    txtShelves.text = locationsplit(1)
            'ElseIf location.Contains("Rack") Then
            '    txtRack.text = locationsplit(1)
            'ElseIf location.Contains("Bin") Then
            '    txtBin.text = locationsplit(1)
            'End If

            If location.Contains("Bay") Then
                Dim a As String = locationsplit(0)
                Dim a1 As String() = a.Split("-")
                txtBay.Text = a1(1)
                On Error Resume Next
            Else
                txtBay.Text = ""
            End If
            If location.Contains("Column") Then
                Dim a As String = locationsplit(1)
                Dim a1 As String() = a.Split("-")
                txtColumn.Text = a1(1)
                On Error Resume Next
            Else
                txtColumn.Text = ""
            End If
            If location.Contains("Floor") Then
                Dim a As String = locationsplit(2)
                Dim a1 As String() = a.Split("-")
                txtFloor.Text = a1(1)
                On Error Resume Next
            Else
                txtFloor.Text = ""
            End If
            If location.Contains("Room") Then
                Dim a As String = locationsplit(3)
                Dim a1 As String() = a.Split("-")
                txtRoom.Text = a1(1)
                On Error Resume Next
            Else
                txtRoom.Text = ""
            End If
            If location.Contains("Shelves") Then
                Dim a As String = locationsplit(4)
                Dim a1 As String() = a.Split("-")
                txtShelves.Text = a1(1)
                On Error Resume Next
            Else
                txtShelves.Text = ""
            End If
            If location.Contains("Rack") Then

                Dim a As String = locationsplit(5)
                Dim a1 As String() = a.Split("-")
                txtRack.Text = a1(1)
                On Error Resume Next
            Else
                txtRack.Text = ""
            End If
            If location.Contains("Bin") Then
                Dim a As String = locationsplit(6)
                Dim a1 As String() = a.Split("-")
                txtBin.Text = a1(1)
                On Error Resume Next
            Else
                txtBin.Text = ""
            End If


            Dim warehouse As String
            warehouse = itemlocation.Rows(0).Item(1)
            '       drpWarehouse.selectedvalue = warehouse

        End If


    End Sub

    Public Sub loadfoodsinfo()
        Dim dt As New DataTable

        dt = objDerived.GetDataTable("select a.ItemDesc ,a.BrandName,b.Cost,convert(int,b.Qty) ,a.Depreciationrate,a.Depreciationvalue , a.Form , a.Batch , a.Lot , a.Mftgdate, a.EpiryDate,a.Alert ,isnull(b.Location,' - '),case when (isnull(b.warehouse_id,1)) = 0  then 1 else isnull(b.warehouse_id,1) end From [AMS].[TbFood] as a inner join ams.Stock as b on a.StockID = b.StockID  where a.Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
        'txtItemDesc1.text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
        If dt.Rows.Count > 0 Then



            lblFoodName.Text = grdStockList.SelectedRow.Cells(2).Text
            txtFoodName.ReadOnly = False

            lblFoodUnit.Text = objDerived.GetValue("select Description from ams.m_Unit as a inner join dbo.m_item as b on a.Unit_ID = b.Unit_ID where Item_ID = " & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            lblFoodBrandName.Text = dt.Rows(0).Item(1)
            txtFoodBrandName.ReadOnly = False

            lblFoodUnitprice.Text = dt.Rows(0).Item(2)
            txtFoodUnitprice.ReadOnly = False


            lblFoodQuantity.Text = dt.Rows(0).Item(3)
            txtFoodQuantity.ReadOnly = False


            lblFoodDepRate.Text = dt.Rows(0).Item(4)
            txtFoodDepRate.ReadOnly = False


            lblFoodDepValue.Text = dt.Rows(0).Item(5)
            txtFoodDepValue.ReadOnly = False


            lblFoodForm.Text = dt.Rows(0).Item(6)
            txtFoodForm.ReadOnly = False


            lblFoodBatch1.Text = dt.Rows(0).Item(7)
            txtFoodBatch1.ReadOnly = False


            lblFoodBatch.Text = dt.Rows(0).Item(7)
            txtFoodBatch.ReadOnly = False


            lblFoodLot.Text = dt.Rows(0).Item(8)
            txtFoodLot.ReadOnly = False


            lblFoodMdate.Text = dt.Rows(0).Item(9)
            txtFoodMdate.ReadOnly = False


            lblFoodEdate.Text = dt.Rows(0).Item(10)
            txtFoodEdate.ReadOnly = False


            lblFoodAlert.Text = dt.Rows(0).Item(11)
            txtFoodAlert.ReadOnly = False


            Dim itemlocation As New DataTable
            itemlocation = obj.GetDataTable("select Location,warehouse_ID From ams.Stock where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            '''--------------------location
            Dim location As String
            location = itemlocation.Rows(0).Item(0)
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
            warehouse = itemlocation.Rows(0).Item(1)
            drpFoodWarehouse.SelectedValue = warehouse
        Else
            lblFoodName.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            lblFoodBrandName.Text = obj.GetValue("select brand From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            lblFoodQuantity.Text = obj.GetValue("select sum(Qty) From ams.Stock where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            Dim CY As String = "CY" & Year(txtDate.Text)

            lblFoodUnitprice.Text = obj.GetValue("select " & CY & " From dbo.m_item_detail where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            lblFoodForm.Text = obj.GetValue("select form From ams.TbFood where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            lblFoodBatch.Text = obj.GetValue("select batch From ams.TbFood where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            lblFoodLot.Text = obj.GetValue("select lot From ams.TbFood where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
            Dim itemlocation As New DataTable
            itemlocation = obj.GetDataTable("select Location,warehouse_ID From ams.Stock where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            Dim location As String
            location = itemlocation.Rows(0).Item(0)
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
            warehouse = itemlocation.Rows(0).Item(1)
            drpFoodWarehouse.SelectedValue = warehouse

        End If

    End Sub

    Public Sub loadmedicineinfo()
        Dim dt As New DataTable

        dt = objDerived.GetDataTable("select a.Description,a.BrandName,a.Dose,c.ActualPrice,convert(int,b.Qty) ,a.Depreciatedrate,a.Depreciatedvalue,c.Form,c.OTCRx,c.Batch, c.Lot ,c.Mftgdate, c.EpiryDate,c.Alert,isnull(b.Location,' - '),isnull(b.warehouse_id,1),a.bfadno,a.itemcode,a.reorderpt,c.sellingprice  From ams.TBMedicine_Info as a inner join ams.TBMedicine_DTl as c on a.MedicineId = c.MedicineID inner join ams.Stock as b on a.StockID = b.StockID  where a.Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
        lblMedicineName.Text = dt.Rows(0).Item(0)
        txtMedicineName.ReadOnly = False

        lblunit.Text = objDerived.GetValue("select Description from ams.m_Unit as a inner join dbo.m_item as b on a.Unit_ID = b.Unit_ID where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
        lblGenericName.Text = objDerived.GetValue("select GenericName From dbo.m_item where Item_ID = " & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

        lblMedicineBrandName.Text = dt.Rows(0).Item(1)
        txtMedicineBrandName.ReadOnly = False


        lblMedicineDose.Text = dt.Rows(0).Item(2)
        txtMedicineDose.ReadOnly = False

        lblMedicineUnitprice.Text = dt.Rows(0).Item(3)
        txtMedicineUnitprice.ReadOnly = False


        lblMedicineQuantity.Text = dt.Rows(0).Item(4)
        txtMedicineQuantity.ReadOnly = False


        lblMedicineDepRate.Text = dt.Rows(0).Item(5)
        txtMedicineDepRate.ReadOnly = False


        lblMedicineDepValue.Text = dt.Rows(0).Item(6)
        txtMedicineDepValue.ReadOnly = False


        lblMedicineForm.Text = dt.Rows(0).Item(7)
        txtMedicineForm.ReadOnly = False


        lblMedicineOTXRX.Text = dt.Rows(0).Item(8)
        txtMedicineOTXRX.ReadOnly = False

        lblMedicineBatch1.Text = dt.Rows(0).Item(9)
        txtMedicineBatch1.ReadOnly = False


        lblMedicineLot.Text = dt.Rows(0).Item(10)
        txtMedicineLot.ReadOnly = False


        lblMedicineMdate.Text = dt.Rows(0).Item(11)
        txtMedicineMdate.ReadOnly = False


        lblMedicineEdate.Text = dt.Rows(0).Item(12)
        txtMedicineEdate.ReadOnly = False


        lblMedicineAlert.Text = dt.Rows(0).Item(13)
        txtMedicineAlert.ReadOnly = False




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

        lblBfadNo.Text = dt.Rows(0).Item(16)
        txtBfadNo.ReadOnly = True

        lblItemCode.Text = dt.Rows(0).Item(17)
        txtItemCode.ReadOnly = True

        lblReorderPt.Text = dt.Rows(0).Item(18)
        txtReorderPt.ReadOnly = True

        lblSellingPrice.Text = dt.Rows(0).Item(19)
        ' txtSellPrice.ReadOnly = True


    End Sub
    Public Sub loadMROEquipment()

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select  a.ItemDesc,a.BrandName,b.Cost,convert(int,b.Qty),isnull(PowerInput,''),isnull(Model,''),isnull(Dimension,''),isnull(AreaCapacity,0.00),isnull(Warranty,0.00) ,isnull(DeliveryDate, ''),isnull(MarketValue, 0),isnull(SalvageValue, 0),isnull(NoYears, 0),isnull(UsefulLife, 0),specs,isnull(b.Location,' - '),isnull(b.warehouse_id,1)   From [AMS].TbNonFood as a inner join ams.Stock as b on a.StockID = b.StockID  where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
        If dt.Rows.Count > 0 Then
            On Error Resume Next
            lblequipmentname.Text = dt.Rows(0).Item(0)
            txtMROEquipmentName.Text = dt.Rows(0).Item(0)
            txtMROEquipmentName.ReadOnly = True
            lblequipmentdesciption.Text = dt.Rows(0).Item(0)
            txtequipmentdesciption.Text = dt.Rows(0).Item(0)
            txtequipmentdesciption.ReadOnly = True
            lblEAcqCost.Text = dt.Rows(0).Item(2)
            txtEAcqCost.Text = dt.Rows(0).Item(2)
            txtEAcqCost.ReadOnly = True
            lblEquipmentQuantity.Text = dt.Rows(0).Item(3)
            txtEquipmentQuantity.Text = dt.Rows(0).Item(3)
            txtEquipmentQuantity.ReadOnly = True
            lblequipmentpowerinput.Text = dt.Rows(0).Item(4)
            txtequipmentpowerinput.Text = dt.Rows(0).Item(4)
            txtequipmentpowerinput.ReadOnly = True
            lblequipmentmodel.Text = dt.Rows(0).Item(5)
            txtequipmentmodel.Text = dt.Rows(0).Item(5)
            txtequipmentmodel.ReadOnly = True
            lblequipmentdimension.Text = dt.Rows(0).Item(6)
            txtequipmentdimension.Text = dt.Rows(0).Item(6)
            txtequipmentdimension.ReadOnly = True
            lblequipmentareacapacity.Text = dt.Rows(0).Item(7)
            txtequipmentareacapacity.Text = dt.Rows(0).Item(7)
            txtequipmentareacapacity.ReadOnly = True
            lblequipmentwaranty.Text = dt.Rows(0).Item(8)
            txtequipmentwaranty.Text = dt.Rows(0).Item(8)
            txtequipmentwaranty.ReadOnly = True
            lblSpecification.Text = ""
            txtSpecification.Text = ""
            txtSpecification.ReadOnly = True
            lblEAcqDate.Text = dt.Rows(0).Item(9)
            txtEAcqDate.Text = dt.Rows(0).Item(9)
            txtEAcqDate.ReadOnly = True

            lblEMarketValue.Text = dt.Rows(0).Item(10)
            txtEMarketValue.Text = dt.Rows(0).Item(10)
            txtEMarketValue.ReadOnly = True
            txtSalvageValue.Text = dt.Rows(0).Item(11)
            txtSalvageValue.Text = dt.Rows(0).Item(11)
            txtSalvageValue.ReadOnly = True
            lblNoYears.Text = dt.Rows(0).Item(12)
            txtNoYears.Text = dt.Rows(0).Item(12)
            txtNoYears.ReadOnly = True
            lblequipmentdepreciatedvalue.Text = FormatNumber(0, 2)
            txtequipmentdepreciatedvalue.Text = FormatNumber(0, 2)
            txtequipmentdepreciatedvalue.ReadOnly = True
            lblequipmentdepreciatedRate.Text = " "
            lblequipmentdepreciatedRate.Text = 0.00
            lblequipmentdepreciatedRate.ReadOnly = True
            lblUsefulLife.Text = dt.Rows(0).Item(13)
            txtUsefulLife.Text = dt.Rows(0).Item(13)
            txtUsefulLife.ReadOnly = True
            Session("useful_life") = txtUsefulLife.Text
            lblSpecification.Text = dt.Rows(0).Item(14)
            txtSpecification.Text = dt.Rows(0).Item(14)
            Dim unit As Integer = objDerived.GetValue("select unit_id From dbo.m_item where Item_ID =" & hdnItemNo.Value, CommandType.Text)
            lblMROEquipmentUnit.Text = objDerived.GetValue("select Description  from ams.m_Unit where unit_id =" & unit, CommandType.Text)
        Else

        End If


        'drpMROEquipmentUnit.items.FindByValue(unit).Selected = True

    End Sub
    Public Sub loadMROConsothers()
        Dim dt As New DataTable

        dt = objDerived.GetDataTable("select  a.ItemDesc,a.BrandName,b.Cost,convert(int,b.Qty),a.DepreciationRate ,a.DepreciationValue,a.Form, a.Batch ,a.Lot , a.Mftgdate , a.EpiryDate, a.Alert ,isnull(b.Location,' - '),isnull(b.warehouse_id,1)   From [AMS].TbNonFood as a inner join ams.Stock as b on a.StockID = b.StockID  where a.Item_ID = " & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)
        If dt.Rows.Count > 0 Then
            lblConsOthersName.Text = grdStockList.SelectedRow.Cells(2).Text
            txtConsOthersName.Text = grdStockList.SelectedRow.Cells(2).Text

            txtConsOthersName.ReadOnly = False

            lblConsOthersUnit.Text = objDerived.GetValue("select Description from ams.m_Unit as a inner join dbo.m_item as b on a.Unit_ID = b.Unit_ID where Item_ID = " & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

            lblConsOthersBrandName.Text = dt.Rows(0).Item(1)
            txtConsOthersBrandName.Text = dt.Rows(0).Item(1)
            txtConsOthersBrandName.ReadOnly = False

            lblConsOthersUnitPrice.Text = dt.Rows(0).Item(2)
            txtConsOthersUnitPrice.Text = dt.Rows(0).Item(2)
            txtConsOthersUnitPrice.ReadOnly = False

            lblConsOthersQuantity.Text = dt.Rows(0).Item(3)
            txtConsOthersQuantity.Text = dt.Rows(0).Item(3)
            txtConsOthersQuantity.ReadOnly = False

            lblConsOthersDepValue.Text = dt.Rows(0).Item(4)
            txtConsOthersDepValue.Text = dt.Rows(0).Item(4)
            txtConsOthersDepValue.ReadOnly = False

            lblConsOthersDepRate.Text = dt.Rows(0).Item(5)
            txtConsOthersDepRate.Text = dt.Rows(0).Item(5)
            txtConsOthersDepRate.ReadOnly = False
            'txtCategory.ReadOnly = False

            lblConsOthersForm.Text = dt.Rows(0).Item(6)
            txtConsOthersForm.Text = dt.Rows(0).Item(6)
            txtConsOthersForm.ReadOnly = False

            lblConsOthersBatch.Text = dt.Rows(0).Item(7)
            txtConsOthersBatch.Text = dt.Rows(0).Item(7)
            txtConsOthersBatch.ReadOnly = False

            lblConsOthersLot.Text = dt.Rows(0).Item(8)
            txtConsOthersLot.Text = dt.Rows(0).Item(8)
            txtConsOthersLot.ReadOnly = False

            lblMDateConsOthers.Text = dt.Rows(0).Item(9)
            txtMDateConsOthers.Text = dt.Rows(0).Item(9)
            ' txtConsOthersQuantity.ReadOnly = False
            txtMDateConsOthers.ReadOnly = False

            lblEDateConsOthers.Text = dt.Rows(0).Item(10)
            txtEDateConsOthers.Text = dt.Rows(0).Item(10)
            txtEDateConsOthers.ReadOnly = False

            lblAlertConsOthers.Text = dt.Rows(0).Item(11)
            txtAlertConsOthers.Text = dt.Rows(0).Item(11)
            txtAlertConsOthers.ReadOnly = False



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
            txtConsOthersBay.ReadOnly = True
            txtConsOthersColumn.ReadOnly = True
            txtConsOthersFloor.ReadOnly = True
            txtConsOthersShelves.ReadOnly = True
            txtConsOthersRoom.ReadOnly = True
            txtConsOthersRack.ReadOnly = True
            txtConsOthersBin.ReadOnly = True
            Dim warehouse As String
            warehouse = dt.Rows(0).Item(13)
            drpMROConsOthersWarehouse.SelectedValue = warehouse
        Else

        End If


        'btnConsOthersSave.enabled = False
        'btnCancel.enabled = False

    End Sub

    Protected Sub LoadStockGridBatches()
        Dim CY As String = "CY" & Year(txtDate.Text)
        Dim dtStock As New DataTable
        'dtStock = objDerived.GetDataTable("select *  from [dbo].[View_StockSupplyBatches] where  Item_ID = '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_StockSupplies_Batches] '" & grdStockList.SelectedDataKey("GA_ID") & "','" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtStock.Rows.Count < 4 Then
            dtStock.Merge(createdatatable2(3 - dtStock.Rows.Count))
        End If
        grdsupplies.DataSource = dtStock
        grdsupplies.DataBind()
        grdsupplies.SelectedIndex = 0


        If IsDBNull(grdStockList.SelectedDataKey("Item_ID")) Then
            loadCleartext()
            loadwarehouse()

            btnEditMROSupplies.Enabled = False
            btnUploadMROSupplies.Enabled = False
            btnConsOthersEdit.Enabled = False
            btnConsOthersCancel.Enabled = False

        Else
            loadCleartext()
            loadwarehouse()

            hdnItemNo.Value = grdStockList.SelectedDataKey("Item_ID")
            hdnGAId.Value = grdStockList.SelectedDataKey("GA_ID")
            Dim a As Integer

            Dim classification As String = obj.GetValue("select ClassificationName From dbo.tbl_Classification where ClassificationId =" & ddClassification.Text, CommandType.Text)
            If classification = "Supplies" Then
                loadofficesuppliesInfo()
            ElseIf classification.Contains("MRO Supplies") Then
                loadmrosuppliesInfo()
                btnEditMROSupplies.Enabled = True
                btnUploadMROSupplies.Enabled = True

            ElseIf classification.Contains("Food") Then
                loadfoodsinfo()
            ElseIf classification.Contains("Medicine") Then
                loadmedicineinfo()
            ElseIf classification.Contains("MRO Consumables") Then
                loadMROConsothers()
                btnConsOthersEdit.Enabled = True
            Else
                loadMROEquipment()
            End If

            txtItemDesc1.Text = obj.GetValue("select Item_Desc From dbo.m_item where Item_ID =" & grdStockList.SelectedDataKey("Item_ID"), CommandType.Text)

        End If

        dtStock = objDerived.GetDataTable("EXEC [AMS].[sp_StockSupplies_Batches] '" & ddGlAccount.SelectedValue() & "','" & hdnItemNo.Value & "'", CommandType.Text)
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
            'lnksupplieroffice.Text = ""
            'txtItemDesc1.Text = ""
            'txtBrandName1.Text = ""
            'txtSize.Text = ""
            'txtColor.Text = ""
            'txtDepRate1.Text = ""

            'txtCategory.Text = ""
            'txtLenght.Text = ""
            'txtWidth.Text = ""
            'txtHeight.Text = ""
            'txtWeight.Text = ""

            'txtItemDesc2.Text = ""

            'txtDose.Text = ""
            'txtDepRate.Text = ""
            'txtDepValue.Text = ""

            'txtForm.Text = ""
            'txtOTC.Text = ""
            'txtBatch.Text = ""
            'txtLot.Text = ""
            'txtMDate.Text = ""
            'txtEDate.Text = ""
            'txtAlert.Text = ""
            For Each ctrl As Control In Page.Controls
                If TypeOf ctrl Is TextBox AndAlso ctrl.ID <> "txtExclude" Then
                    DirectCast(ctrl, TextBox).Text = ""
                End If
            Next


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
                txtDepRate.Text = dt.Rows(0).Item("Depreciationrate").ToString
                txtDepValue.Text = dt.Rows(0).Item("Depreciationvalue").ToString

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





    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "DETAILS"
        cell.ColumnSpan = 4
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 2
        cell.Text = "DEBIT"
        row.Controls.Add(cell)


        cell = New TableHeaderCell()
        cell.ColumnSpan = 2
        cell.Text = "CREDIT"
        row.Controls.Add(cell)


        cell = New TableHeaderCell()
        cell.ColumnSpan = 2
        cell.Text = "BALANCE"
        row.Controls.Add(cell)

        row.BackColor = ColorTranslator.FromHtml("WHITE")
        row.ForeColor = ColorTranslator.FromHtml("BLACK")
        grdLedger.HeaderRow.Parent.Controls.AddAt(0, row)
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
        Dim cy As String
        cy = "CY" & Year(txtDate.Text)

        loadCleartext()

        Dim dtStock As New DataTable
        If ddCategory.SelectedItem.Value = 0 Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022_Stockcardmain] '" & ddGlAccount.SelectedValue() & "','0','" & cy & "','" & 0 & "','" & 0 & "'", CommandType.Text)
        ElseIf ddSubCategory.SelectedIndex = 0 Then
            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022_Stockcardmain] '" & ddGlAccount.SelectedValue() & "','0','" & cy & "','" & ddCategory.SelectedValue() & "','" & 0 & "'", CommandType.Text)
        Else

            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesList_wPrice_v1_02092022_Stockcardmain] '" & ddGlAccount.SelectedValue() & "','0','" & cy & "','" & ddCategory.SelectedValue() & "','" & ddSubCategory.SelectedValue() & "'", CommandType.Text)
        End If

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
        dt.Columns.Add("suppname", GetType(Long))


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
            dr("suppname") = DBNull.Value
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
    Public Function createdatatableledger(ByVal row As Integer) As DataTable
        'Dim dt As New DataTable()
        'Dim dr As DataRow
        'Dim myDataColumn As DataColumn
        'myDataColumn = New DataColumn()
        ''dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        'dt.Columns.Add("dDate", GetType(Date))
        'dt.Columns.Add("trans_type", GetType(String))
        'dt.Columns.Add("ref", GetType(String))
        'dt.Columns.Add("AccountablePerson", GetType(String))
        'dt.Columns.Add("Department", GetType(String))
        'dt.Columns.Add("position", GetType(String))
        'dt.Columns.Add("acceptedby", GetType(String))
        'dt.Columns.Add("inspectedby", GetType(String))
        'dt.Columns.Add("DebitQty", GetType(Integer))

        'dt.Columns.Add("DebitUnit", GetType(String))
        'dt.Columns.Add("DebitCost", GetType(Decimal))
        'dt.Columns.Add("CreditQty", GetType(Integer))
        'dt.Columns.Add("CreditUnit", GetType(String))
        'dt.Columns.Add("CreditCost", GetType(Decimal))
        'dt.Columns.Add("BalQty", GetType(Integer))
        'dt.Columns.Add("BalanceUnit", GetType(String))
        'dt.Columns.Add("BalCost", GetType(Decimal))
        'dt.Columns.Add("Cost", GetType(Decimal))
        'For i As Integer = 0 To row
        '    dr = dt.NewRow
        '    'dr("Property_Dtl_ID") = DBNull.Value
        '    dr("dDate") = DBNull.Value
        '    dr("trans_type") = DBNull.Value
        '    dr("ref") = DBNull.Value
        '    dr("AccountablePerson") = DBNull.Value
        '    dr("Department") = DBNull.Value
        '    dr("position") = DBNull.Value
        '    dr("acceptedby") = DBNull.Value
        '    dr("inspectedby") = DBNull.Value
        '    dr("DebitQty") = DBNull.Value
        '    dr("DebitUnit") = DBNull.Value
        '    dr("DebitCost") = DBNull.Value
        '    dr("CreditQty") = DBNull.Value
        '    dr("CreditUnit") = DBNull.Value
        '    dr("CreditCost") = DBNull.Value
        '    dr("BalQty") = DBNull.Value
        '    dr("BalanceUnit") = DBNull.Value
        '    dr("BalCost") = DBNull.Value
        '    dt.Rows.Add(dr)
        'Next
        'Return dt
        ''Optmize code
        Dim dt As New DataTable()
        With dt.Columns
            .Add("dDate", GetType(Date)).DefaultValue = DBNull.Value
            .Add("trans_type", GetType(String)).DefaultValue = DBNull.Value
            .Add("ref", GetType(String)).DefaultValue = DBNull.Value
            .Add("AccountablePerson", GetType(String)).DefaultValue = DBNull.Value
            .Add("Department", GetType(String)).DefaultValue = DBNull.Value
            .Add("position", GetType(String)).DefaultValue = DBNull.Value
            .Add("acceptedby", GetType(String)).DefaultValue = DBNull.Value
            .Add("inspectedby", GetType(String)).DefaultValue = DBNull.Value
            .Add("DebitQty", GetType(Integer)).DefaultValue = DBNull.Value
            .Add("DebitUnit", GetType(String)).DefaultValue = DBNull.Value
            .Add("DebitCost", GetType(Decimal)).DefaultValue = DBNull.Value
            .Add("CreditQty", GetType(Integer)).DefaultValue = DBNull.Value
            .Add("CreditUnit", GetType(String)).DefaultValue = DBNull.Value
            .Add("CreditCost", GetType(Decimal)).DefaultValue = DBNull.Value
            .Add("BalQty", GetType(Integer)).DefaultValue = DBNull.Value
            .Add("BalanceUnit", GetType(String)).DefaultValue = DBNull.Value
            .Add("BalCost", GetType(Decimal)).DefaultValue = DBNull.Value
            .Add("Cost", GetType(Decimal)).DefaultValue = DBNull.Value
        End With

        For i As Integer = 0 To row
            dt.Rows.Add(dt.NewRow())
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
        Session("Item_ID") = grdStockList.SelectedDataKey("Item_ID")
        Session("paramRP") = grdStockList.SelectedDataKey("reorderpt")
        Me.Page.Response.Redirect("~/Records/rpt_stockcard.aspx")
    End Sub

    Protected Sub loadCleartext()
        ' Define an array of controls to reset
        Dim controlsToReset() As Control = {
    lnksupplieroffice, txtItemDesc1, txtBrandName1, txtSize, txtColor, txtDepRate1,
    txtCategory, txtLenght, txtWidth, txtHeight, txtWeight, txtDepValue1,
    lnksuppliermed, txtItemDesc2, txtBrandName2, txtDose, txtDepRate, txtDepValue,
    txtForm, txtOTC, txtBatch, txtLot, txtMDate, txtEDate, txtAlert, txtUnitPrice,
    txtQuantity, txtBay, txtColumn, txtFloor, txtRoom, txtShelves, txtRack, txtBin,
    hdnItemNo, lblBrandName1, lblSize, lblUnitPrice, lblQuantity, lblItemDesc1,
    lblBrandName1, lblSize, lblColor, lblDepRate1, lblDepValue1, lblLenght,
    lblWidth, lblHeight, lblWeight, lblUnitPrice, lblQuantity, txtBay, txtColumn,
    txtFloor, txtRoom, txtShelves, txtRack, txtBin, lblMROsuppliesName, txtItemDesc2,
    lblMROsuppliesBrandName, txtBrandName2, lblMROsuppliesSize, txtSize,
    lblMROsuppliesColor, txtColor, lblMROsuppliesDeprate, lblMROsuppliesDepValue,
    lblMROsuppliesLength, lblMROsuppliesWidth, lblMROsuppliesheight, lblMROsuppliesWeight,
    lblMROsuppliesUnitPrice, lblMROsuppliesQuantity, txtMROsuppliesBay, txtMROsuppliesColumn,
    txtMROsuppliesFloor, txtMROsuppliesRoom, txtMROsuppliesShelves, txtMROsuppliesRack,
    txtMROsuppliesBin, lblMROsuppliesComponentof, lblConsOthersName, lblConsOthersBrandName,
    lblConsOthersUnitPrice, lblConsOthersQuantity, lblConsOthersDepValue, lblConsOthersDepRate,
    lblConsOthersForm, lblConsOthersBatch, lblConsOthersLot, lblMDateConsOthers, lblEDateConsOthers,
    lblAlertConsOthers, txtConsOthersBay, txtConsOthersColumn, txtConsOthersFloor, txtConsOthersRoom,
    txtConsOthersShelves, txtConsOthersRack, txtConsOthersBin, lblFoodName, lblFoodBrandName,
    lblFoodUnitprice, lblFoodQuantity, lblFoodDepRate, lblFoodDepValue, lblFoodForm, lblFoodBatch1,
    lblFoodBatch, lblFoodLot, lblFoodMdate, lblFoodEdate, lblFoodAlert, txtFoodBin, txtFoodRack,
    txtFoodShelves, txtFoodRoom, txtFoodFloor, txtFoodColumn, txtFoodBay, lblMedicineName,
    lblMedicineBrandName, lblMedicineDose, lblMedicineUnitprice, lblMedicineQuantity, lblMedicineDepRate,
    lblMedicineDepValue, lblMedicineForm, lblMedicineOTXRX
}

        ' Reset the values of all the controls
        For Each control As Control In controlsToReset
            If TypeOf control Is TextBox Then
                CType(control, TextBox).Text = ""
            ElseIf TypeOf control Is Label Then
                CType(control, Label).Text = ""
            End If
        Next
        'lnksupplieroffice.Text = ""
        'txtItemDesc1.Text = ""
        'txtBrandName1.Text = ""
        'txtSize.Text = ""
        'txtColor.Text = ""
        'txtDepRate1.Text = ""

        'txtCategory.Text = ""
        'txtLenght.Text = ""
        'txtWidth.Text = ""
        'txtHeight.Text = ""
        'txtWeight.Text = ""
        'txtDepValue1.Text = ""

        'lnksuppliermed.Text = ""
        'txtItemDesc2.Text = ""
        'txtBrandName2.Text = ""
        'txtDose.Text = ""
        'txtDepRate.Text = ""
        'txtDepValue.Text = ""

        'txtForm.Text = ""
        'txtOTC.Text = ""
        'txtBatch.Text = ""
        'txtLot.Text = ""
        'txtMDate.Text = ""
        'txtEDate.Text = ""
        'txtAlert.Text = ""
        'txtUnitPrice.text = ""
        'txtQuantity.text = ""
        'txtBay.text = ""
        'txtColumn.text = ""
        'txtFloor.text = ""
        'txtRoom.text = ""
        'txtShelves.text = ""
        'txtRack.text = ""
        'txtBin.text = ""

        'hdnItemNo.value = ""
        'lblBrandName1.text = ""
        'txtBrandName1.text = ""
        'lblSize.text = ""
        'txtSize.text = ""
        'txtColor.text = ""
        'lblUnitPrice.text = ""
        'lblQuantity.text = ""
        'txtBay.text = ""
        'txtColumn.text = ""
        'txtFloor.text = ""
        'txtRoom.text = ""
        'txtShelves.text = ""
        'txtRack.text = ""
        'txtBin.text = ""


        ''--office supplies
        'lblItemDesc1.text = ""
        'txtItemDesc1.text = ""

        'lblBrandName1.text = ""
        'txtBrandName1.text = ""

        'lblSize.text = ""
        'txtSize.text = ""

        'lblColor.text = ""
        'txtColor.text = ""

        'lblDepRate1.text = ""
        'txtDepRate1.text = ""

        'lblDepValue1.text = ""
        'txtDepValue1.text = ""


        'lblLenght.text = ""
        'txtLenght.text = ""

        'lblWidth.text = ""
        'txtWidth.text = ""

        'lblHeight.text = ""
        'txtHeight.text = ""

        'lblWeight.text = ""
        'txtWeight.text = ""

        'lblUnitPrice.text = ""
        'txtUnitPrice.text = ""

        'lblQuantity.text = ""
        'txtQuantity.text = ""

        'txtBay.text = ""
        'txtColumn.text = ""
        'txtFloor.text = ""
        'txtRoom.text = ""
        'txtShelves.text = ""
        'txtRack.text = ""
        'txtBin.text = ""
        '''end office supplies


        ''--MRO supplies

        'lblMROsuppliesName.text = ""
        'txtItemDesc2.text = ""

        'lblMROsuppliesBrandName.text = ""
        'txtBrandName2.text = ""


        'lblMROsuppliesSize.text = ""
        'txtSize.text = ""

        'lblMROsuppliesColor.text = ""
        'txtColor.text = ""


        'lblMROsuppliesDeprate.text = ""
        'lblMROsuppliesDepValue.text = ""

        ''txtCategory.ReadOnly = True

        'lblMROsuppliesLength.text = ""
        'lblMROsuppliesWidth.text = ""
        'lblMROsuppliesheight.text = ""
        'lblMROsuppliesWeight.text = ""

        'lblMROsuppliesUnitPrice.text = ""
        'lblMROsuppliesQuantity.text = ""

        'txtMROsuppliesBay.text = ""
        'txtMROsuppliesColumn.text = ""
        'txtMROsuppliesFloor.text = ""
        'txtMROsuppliesRoom.text = ""
        'txtMROsuppliesShelves.text = ""
        'txtMROsuppliesRack.text = ""
        'txtMROsuppliesBin.text = ""

        'lblMROsuppliesComponentof.text = ""

        ''end MRO Supplies

        ''--MRO CONsumables
        'lblConsOthersName.text = ""

        'lblConsOthersBrandName.text = ""

        'lblConsOthersUnitPrice.text = ""

        'lblConsOthersQuantity.text = ""

        'lblConsOthersDepValue.text = ""

        'lblConsOthersDepRate.text = ""
        ''txtCategory.ReadOnly = False

        'lblConsOthersForm.text = ""

        'lblConsOthersBatch.text = ""

        'lblConsOthersLot.text = ""

        'lblMDateConsOthers.text = ""
        '' txtConsOthersQuantity.ReadOnly = False

        'lblEDateConsOthers.text = ""

        'lblAlertConsOthers.text = ""

        'txtConsOthersBay.text = ""
        'txtConsOthersColumn.text = ""
        'txtConsOthersFloor.text = ""
        'txtConsOthersRoom.text = ""
        'txtConsOthersShelves.text = ""
        'txtConsOthersRack.text = ""
        'txtConsOthersBin.text = ""


        ''--end MRO Consumables
        ''--Food Supplies


        'lblFoodName.text = ""

        'lblFoodBrandName.text = ""

        'lblFoodUnitprice.text =""

        'lblFoodQuantity.text = ""


        'lblFoodDepRate.text = ""

        'lblFoodDepValue.text = ""


        'lblFoodForm.text = ""


        'lblFoodBatch1.text = ""


        'lblFoodBatch.text = ""


        'lblFoodLot.text = ""

        'lblFoodMdate.text = ""

        'lblFoodEdate.text = ""


        'lblFoodAlert.text = ""

        'txtFoodBin.text = ""
        'txtFoodRack.text = ""
        'txtFoodShelves.text = ""
        'txtFoodRoom.text = ""
        'txtFoodFloor.text = ""
        'txtFoodColumn.text = ""
        'txtFoodBay.text = ""
        ''--end food supplies

        ''MEdicine
        'lblMedicineName.text = ""

        'lblMedicineBrandName.text = ""

        'lblMedicineDose.text = ""

        'lblMedicineUnitprice.text = ""


        'lblMedicineQuantity.text = ""

        'lblMedicineDepRate.text = ""

        'lblMedicineDepValue.text = ""


        'lblMedicineForm.text = ""


        'lblMedicineOTXRX.text = ""

        'lblMedicineBatch1.text = ""


        'lblMedicineLot.text = ""


        'lblMedicineMdate.text = ""


        'lblMedicineEdate.text = ""
        'txtMedicineEdate.ReadOnly = False


        'lblMedicineAlert.text = ""




        ''''--------------------location

        'txtMedicineBay.text = ""
        'txtMedicineColumn.text = ""
        'txtMedicineFloor.text = ""
        'txtMedicineRoom.text = ""
        'txtMedicineShelves.text = ""
        'txtMedicineRack.text = ""
        'txtMedicineBin.text = ""



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
        'txtDepRate.ReadOnly = False
        'txtDepValue.ReadOnly = False

        'txtForm.ReadOnly = False
        'txtOTC.ReadOnly = False
        'txtBatch.ReadOnly = False
        'txtLot.ReadOnly = False
        'txtMDate.ReadOnly = False
        'txtEDate.ReadOnly = False
        'txtAlert.ReadOnly = False
        Dim controlsToModify As New List(Of TextBox) From {txtItemDesc2, txtBrandName2, txtDose, txtDepRate, txtDepValue, txtForm, txtOTC, txtBatch, txtLot, txtMDate, txtEDate, txtAlert}

        For Each ctrl As TextBox In controlsToModify
            ctrl.ReadOnly = False
        Next

    End Sub

    Protected Sub btnUpdateDetails2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Session("StockID")
        Try
            If grdStockList.SelectedDataKey("GA_ID") = 1432 Or grdStockList.SelectedDataKey("GA_ID") = 1433 Then
                'MEDICINES
                objDerived.GetRecords("UPDATE [AMS].[TBMedicine_DTl] " +
                                        " SET [Form] = '" & txtForm.Text & "' " +
                                        " ,[OTCRx] = '" & txtOTC.Text & "' " +
                                        " ,[Mftgdate] = '" & txtMDate.Text & "'  " +
                                        " ,[Batch] = '" & txtBatch.Text & "' " +
                                        " ,[Lot] = '" & txtLot.Text & "' " +
                                        " ,[EpiryDate] = '" & txtEDate.Text & "' " +
                                        " ,[Alert] = '" & txtAlert.Text & "' " +
                                        " WHERE StockId = '" & Session("StockID") & "' AND Item_ID = '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)

                objDerived.GetRecords("UPDATE [AMS].[TBMedicine_Info]  " +
                                        " SET [Description] = '" & txtItemDesc2.Text & "' " +
                                        " ,[BrandName] = '" & txtBrandName2.Text & "' " +
                                        " ,[Dose] = '" & txtDose.Text & "' " +
                                        " ,[Depreciatedrate] = '" & txtDepRate.Text & "' " +
                                        " ,[Depreciatedvalue] = '" & txtDepValue.Text & "' " +
                                        " WHERE StockID = '" & Session("StockID") & "' AND Item_ID = '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)

            ElseIf grdStockList.SelectedDataKey("GA_ID") = 1430 Then
                'FOOD
                objDerived.GetRecords("UPDATE [AMS].[TbFood] " +
                                        " SET [Form] = '" & txtForm.Text & "' " +
                                        " ,[OTCRx] = '" & txtOTC.Text & "' " +
                                        " ,[Mftgdate] = '" & txtMDate.Text & "' " +
                                        " ,[Batch] = '" & txtBatch.Text & "' " +
                                        " ,[Lot] = '" & txtLot.Text & "' " +
                                        " ,[EpiryDate] = '" & txtEDate.Text & "' " +
                                        " ,[Alert] = '" & txtAlert.Text & "' " +
                                        " ,[ItemDesc] = '" & txtItemDesc2.Text & "' " +
                                        " ,[BrandName] = '" & txtBrandName2.Text & "' " +
                                        " ,[DepreciationRate] = '" & txtDepRate.Text & "' " +
                                        " ,[DepreciationValue] = '" & txtDepValue.Text & "' " +
                                        " WHERE StockId = '" & Session("StockID") & "' AND Item_ID = '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)


            Else
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
                                        " ,[DepreciationRate] = '" & txtDepRate.Text & "' " +
                                        " ,[DepreciationValue] = '" & txtDepValue.Text & "' " +
                                        " WHERE StockId = '" & Session("StockID") & "' AND Item_ID = '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)

            End If

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            loadStockDetails()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error occured, pls contact administrator.")
        End Try

    End Sub

    Protected Sub btnCancel2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        loadStockDetails()

        'txtItemDesc2.ReadOnly = True
        'txtBrandName2.ReadOnly = True
        'txtDose.ReadOnly = True
        'txtDepRate.ReadOnly = True
        'txtDepValue.ReadOnly = True

        'txtForm.ReadOnly = True
        'txtOTC.ReadOnly = True
        'txtBatch.ReadOnly = True
        'txtLot.ReadOnly = True
        'txtMDate.ReadOnly = True
        'txtEDate.ReadOnly = True
        'txtAlert.ReadOnly = True
        For Each control As Control In Me.Controls
            If TypeOf control Is TextBox Then
                CType(control, TextBox).ReadOnly = True
            End If
        Next

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
        For Each txtBox As TextBox In {txtItemDesc1, txtBrandName1, txtSize, txtColor, txtDepRate1, txtCategory, txtLenght, txtWidth, txtHeight, txtWeight, txtDepValue1}
            txtBox.ReadOnly = False
        Next

    End Sub

    Protected Sub btnUpdate1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            objDerived.GetRecords("UPDATE [AMS].[TBSupplies_Info] " +
                                    " SET [Description] = '" & txtItemDesc1.Text & "' " +
                                    " ,[BrandName] = '" & txtBrandName1.Text & "' " +
                                    " ,[Size] = '" & txtSize.Text & "' " +
                                    " ,[Color] = '" & txtColor.Text & "' " +
                                    " ,[Category] = '" & txtCategory.Text & "' " +
                                    " ,[Length] = '" & txtLenght.Text & "' " +
                                    " ,[Width] = '" & txtWidth.Text & "' " +
                                    " ,[Height] = '" & txtHeight.Text & "' " +
                                    " ,[Weight] = '" & txtWeight.Text & "' " +
                                    " ,[DepreciatedValue] = '" & txtDepValue1.Text & "' " +
                                    " ,[DepreciatedRate] = '" & txtDepRate1.Text & "' " +
                                    " WHERE StockID = '" & Session("StockID") & "' AND ItemId = '" & grdStockList.SelectedDataKey("Item_ID") & "'", CommandType.Text)

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
        Dim myControl As Control = New Control()

        Dim myTextBox As TextBox = TryCast(myControl, TextBox)
        If myTextBox IsNot Nothing Then
            myTextBox.ReadOnly = True
        End If


        txtQuantity.Text = True
    End Sub

    Dim rcv As New Receiving.t_receiving



    Protected Sub btnSave_Click(sender As Object, e As EventArgs)

        If txtItemDesc1.Text = "" Or txtBrandName1.Text = "" Or txtUnitPrice.Text = "" Or txtQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Brand Name / Unit Cost / Quantity")
        Else
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
            '  For i As Integer = 0 To pItems.Rows.Count - 1
            For i As Integer = 0 To 1 - 1

                Dim txtPrice As TextBox = CType(txtUnitPrice, TextBox)
                Dim txtqty As TextBox = CType(txtQuantity, TextBox)

                '=-= SAVE AMS.Tb_Receiving_Dtl
                With rcv_dtl
                    .Received_ID = rcvID
                    .Item_ID = hdnItemNo.Value
                    .PO_Qty = txtqty.Text
                    .Qty_Received = txtqty.Text
                    .Cost = txtPrice.Text
                    .Condition = ""
                    .Location = ""
                End With

                Dim RcvDtl_ID As Long = rcv_dtl.save

                Dim t1 As Decimal
                t1 = txtPrice.Text * txtqty.Text
                total = total + t1

            Next
            Session("ContractPrice") = total

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
                .StockDate = DateTime.Parse(txtDate.Text)
                .Item_ID = hdnItemNo.Value
                .Qty = txtqtyair.Text
                .Balance = txtqtyair.Text
                Dim location As String

                If String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                    location = "Bay-" & txtBay.Text
                ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                    location = "Column-" & txtColumn.Text
                ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                    location = "Floor-" & txtFloor.Text
                ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                    location = "Room-" & txtRoom.Text
                ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtRack.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                    location = "Shelves-" & txtShelves.Text
                ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtBin.Text) Then
                    location = "Rack-" & txtRack.Text
                ElseIf String.IsNullOrEmpty(txtBay.Text) And String.IsNullOrEmpty(txtColumn.Text) And String.IsNullOrEmpty(txtFloor.Text) And String.IsNullOrEmpty(txtRoom.Text) And String.IsNullOrEmpty(txtShelves.Text) And String.IsNullOrEmpty(txtRack.Text) Then
                    location = "Bin-" & txtBin.Text
                End If


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

            If hdnGAId.Value = 1427 Then
                'Office Supplies
                With objOfficeSup
                    '.SuppliesId = SuppliesId
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

                End With

                Dim Supp_ID As Long = objOfficeSup.save
                objDerived.GetRecords("UPDATE AMS.TBSupplies_Info SET Received_ID = '" & rcvID & "' WHERE SuppliesId = '" & Supp_ID & "'", CommandType.Text)
            End If

            dtStock = objDerived.GetDataTable("Exec [AMS].[sp_SuppliesLedger.] '" & hdnItemNo.Value & "'", CommandType.Text)
            If dtStock.Rows.Count < 4 Then
                dtStock.Merge(createdatatableledger(3 - dtStock.Rows.Count))
            End If
            grdLedger.DataSource = dtStock
            grdLedger.DataBind()
            loadCleartext()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction Has been Successfully Saved")
            loadStockOfficeSupplies()
        End If





    End Sub

    Public Sub SelectCategory()
        Dim category As String
        If ddCategory.Text = "" Then
            category = 0
        Else
            category = ddCategory.SelectedValue()
        End If
        If category = 0 Then
            MultiviewSupplier()
            ddSubCategory.Enabled = True
        Else
            Dim subcategory As New DataTable
            ddSubCategory.Items.Clear()
            '
            subcategory = obj.GetDataTable("select [SubCategoryID],[SubCat_Desc]  From [dbo].[tbl_SubCategory] where item_particular_id = " & category & "", CommandType.Text)
            ddSubCategory.DataSource = subcategory
            ddSubCategory.DataTextField = ("SubCat_Desc")
            ddSubCategory.DataValueField = ("SubCategoryID")
            ddSubCategory.DataBind()
            ddSubCategory.Items.Insert(0, "All")
            ddSubCategory.Enabled = True
            MultiviewSupplier()
        End If



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

    Protected Sub drpSubClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        SelectSubClassification()
    End Sub

    Public Sub SelectSubClassification()
        PListofGL = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & ddClassification.SelectedValue() & "'", CommandType.Text)
        ddGlAccount.DataSource = CType(PListofGL, DataTable)
        ddGlAccount.DataTextField = ("GA_Title")
        ddGlAccount.DataValueField = ("GA_ID")
        ddGlAccount.DataBind()
        SelectGLAccount()
        ''lblclass1.Text = objDerived.GetValue("select upper(ClassificationName) From dbo.tbl_Classification where ClassificationId =" & ddClassification.SelectedValue(), CommandType.Text)

    End Sub


    Public Sub SelectClassification()
        PListofGL = objDerived.GetDataTable("select distinct b.SubClassificationName ,b.SubClassificationID  From tblclassmatrix as a inner join dbo.tbl_SubClassification as b on  b.ClassificationID = a.ClassificationID and b.SubClassificationID = a.SubClassificationID where a.classificationid = '" & ddClassification.SelectedValue() & "'", CommandType.Text)
        drpSubClass.DataSource = CType(PListofGL, DataTable)
        drpSubClass.DataTextField = ("SubClassificationName")
        drpSubClass.DataValueField = ("SubClassificationID")
        drpSubClass.DataBind()
        SelectSubClassification()
        lblclass1.Text = objDerived.GetValue("select upper(ClassificationName) From dbo.tbl_Classification where ClassificationId =" & ddClassification.SelectedValue(), CommandType.Text)

    End Sub

    Protected Sub ddClassification_SelectedIndexChanged(sender As Object, e As EventArgs)
        SelectClassification()

    End Sub

    Protected Sub btnEditMROSupplies_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnEditMROSupplies.Text = "SAVE" Then

            Try
                Dim location As String

                If String.IsNullOrEmpty(txtMROsuppliesColumn.Text) And String.IsNullOrEmpty(txtMROsuppliesFloor.Text) And String.IsNullOrEmpty(txtMROsuppliesRoom.Text) And String.IsNullOrEmpty(txtMROsuppliesShelves.Text) And String.IsNullOrEmpty(txtMROsuppliesRack.Text) And String.IsNullOrEmpty(txtMROsuppliesBin.Text) Then
                    location = "Bay-" & txtMROsuppliesBay.Text
                ElseIf String.IsNullOrEmpty(txtMROsuppliesBay.Text) And String.IsNullOrEmpty(txtMROsuppliesFloor.Text) And String.IsNullOrEmpty(txtMROsuppliesRoom.Text) And String.IsNullOrEmpty(txtMROsuppliesShelves.Text) And String.IsNullOrEmpty(txtMROsuppliesRack.Text) And String.IsNullOrEmpty(txtMROsuppliesBin.Text) Then
                    location = "Column-" & txtMROsuppliesColumn.Text
                ElseIf String.IsNullOrEmpty(txtMROsuppliesBay.Text) And String.IsNullOrEmpty(txtMROsuppliesColumn.Text) And String.IsNullOrEmpty(txtMROsuppliesRoom.Text) And String.IsNullOrEmpty(txtMROsuppliesShelves.Text) And String.IsNullOrEmpty(txtMROsuppliesRack.Text) And String.IsNullOrEmpty(txtMROsuppliesBin.Text) Then
                    location = "Floor-" & txtMROsuppliesFloor.Text
                ElseIf String.IsNullOrEmpty(txtMROsuppliesBay.Text) And String.IsNullOrEmpty(txtMROsuppliesColumn.Text) And String.IsNullOrEmpty(txtMROsuppliesFloor.Text) And String.IsNullOrEmpty(txtMROsuppliesShelves.Text) And String.IsNullOrEmpty(txtMROsuppliesRack.Text) And String.IsNullOrEmpty(txtMROsuppliesBin.Text) Then
                    location = "Room-" & txtMROsuppliesRoom.Text
                ElseIf String.IsNullOrEmpty(txtMROsuppliesBay.Text) And String.IsNullOrEmpty(txtMROsuppliesColumn.Text) And String.IsNullOrEmpty(txtMROsuppliesFloor.Text) And String.IsNullOrEmpty(txtMROsuppliesRoom.Text) And String.IsNullOrEmpty(txtMROsuppliesRack.Text) And String.IsNullOrEmpty(txtMROsuppliesBin.Text) Then
                    location = "Shelves-" & txtMROsuppliesShelves.Text
                ElseIf String.IsNullOrEmpty(txtMROsuppliesBay.Text) And String.IsNullOrEmpty(txtMROsuppliesColumn.Text) And String.IsNullOrEmpty(txtMROsuppliesFloor.Text) And String.IsNullOrEmpty(txtMROsuppliesRoom.Text) And String.IsNullOrEmpty(txtMROsuppliesShelves.Text) And String.IsNullOrEmpty(txtMROsuppliesBin.Text) Then
                    location = "Rack-" & txtMROsuppliesRack.Text
                ElseIf String.IsNullOrEmpty(txtMROsuppliesBay.Text) And String.IsNullOrEmpty(txtMROsuppliesColumn.Text) And String.IsNullOrEmpty(txtMROsuppliesFloor.Text) And String.IsNullOrEmpty(txtMROsuppliesRoom.Text) And String.IsNullOrEmpty(txtMROsuppliesShelves.Text) And String.IsNullOrEmpty(txtMROsuppliesRack.Text) Then
                    location = "Bin-" & txtMROsuppliesBin.Text
                End If

                '----Update Receiving
                objDerived.GetRecords("UPDATE [AMS].[Tb_Receiving_Dtl] " +
                                    " SET [PO_Qty] = '" & txtMROsuppliesQuantity.Text & "' " +
                                    " ,[Qty_Received] = '" & txtMROsuppliesQuantity.Text & "' " +
                                    " ,[Cost] = '" & txtMROsuppliesUnitPrice.Text & "' " +
                                    " ,[Location] = '" & location & "' " +
                                    " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                Dim t1 As Decimal
                Dim total As Decimal = 0

                t1 = txtMROsuppliesUnitPrice.Text * txtMROsuppliesQuantity.Text
                total = total + t1
                Session("ContractPrice") = total

                '----Update PO_dtl
                objDerived.GetRecords("UPDATE [AMS].[PO_Dtl] " +
                                    " SET [qty] = '" & txtMROsuppliesQuantity.Text & "' " +
                                    " ,[cost] = '" & txtMROsuppliesUnitPrice.Text & "' " +
                                    " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)


                '----Update AIR_Dtl
                objDerived.GetRecords("UPDATE [AMS].[AIR_Dtl] " +
                                    " SET [Qty] = '" & txtMROsuppliesQuantity.Text & "' " +
                                    " ,[Cost] = '" & txtMROsuppliesUnitPrice.Text & "' " +
                                    " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)

                '----Update STOCK
                objDerived.GetRecords("UPDATE [AMS].[stock] " +
                                    " SET [Qty] = '" & txtMROsuppliesQuantity.Text & "' " +
                                    " ,[Balance] = '" & txtMROsuppliesQuantity.Text & "' " +
                                    " ,[Cost] = '" & txtMROsuppliesUnitPrice.Text & "' " +
                                    " ,[Location] = '" & location & "' " +
                                    " ,[warehouse_ID] = '" & drpMROsuppliesWarehouse.SelectedValue() & "' " +
                                    " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)

                '----Update stockledger
                objDerived.GetRecords("UPDATE [AMS].[TbStock_Ledger] " +
                                    " SET [DebitQty] = '" & txtMROsuppliesQuantity.Text & "' " +
                                    " ,[DebitCost] = '" & CType(txtMROsuppliesQuantity.Text * txtMROsuppliesUnitPrice.Text, Decimal) & "' " +
                                     " WHERE Item_ID = '" & hdnItemNo.Value & "'and Trans_Type like 'Starting Balance'", CommandType.Text)

                '----Update suppliesinfo
                objDerived.GetRecords("UPDATE [AMS].[TBSupplies_Info] " +
                                    " SET [Description] = '" & txtMROsuppliesName.Text & "' " +
                                    " ,[BrandName] = '" & txtMROsuppliesBrandName.Text & "' " +
                                    " ,[Size] = '" & txtMROsuppliesSize.Text & "' " +
                                    " ,[Color] = '" & txtMROsuppliesColor.Text & "' " +
                                    " ,[Length] = '" & txtMROsuppliesLength.Text & "' " +
                                    " ,[Width] = '" & txtMROsuppliesWidth.Text & "' " +
                                    " ,[Componentof] = '" & txtMROsuppliesComponentof.Text & "' " +
                                    " ,[Height] = '" & txtMROsuppliesheight.Text & "' " +
                                    " ,[Weight] = '" & txtMROsuppliesWeight.Text & "' " +
                                    " WHERE ItemId = '" & hdnItemNo.Value & "'", CommandType.Text)




                ' MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                LoadStockGridBatches()
            Catch ex As Exception
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error occured, pls contact administrator.")
            End Try


            btnEditMROSupplies.Text = "EDIT"

            'lblMROsuppliesName.visible = True
            'lblMROsuppliesUnit.visible = True
            'lblMROsuppliesBrandName.visible = True
            'lblMROsuppliesLength.visible = True
            'lblMROsuppliesSize.visible = True

            'lblMROsuppliesWidth.visible = True
            'lblMROsuppliesColor.visible = True
            'lblMROsuppliesWeight.visible = True
            'lblMROsuppliesComponentof.visible = True
            'lblMROsuppliesheight.visible = True
            'lblMROsuppliesUnitPrice.visible = True
            'lblMROsuppliesQuantity.visible = True
            Dim labels() As Label = {lblMROsuppliesName, lblMROsuppliesUnit, lblMROsuppliesBrandName, lblMROsuppliesLength, lblMROsuppliesSize, lblMROsuppliesWidth, lblMROsuppliesColor, lblMROsuppliesWeight, lblMROsuppliesComponentof, lblMROsuppliesheight, lblMROsuppliesUnitPrice, lblMROsuppliesQuantity}

            For Each label As Label In labels
                label.Visible = True
            Next



            'txtMROsuppliesName.visible = False
            'txtMROsuppliesBrandName.visible = False
            'txtMROsuppliesLength.Visible = False
            'txtMROsuppliesSize.Visible = False

            'txtMROsuppliesWidth.Visible = False
            'txtMROsuppliesColor.Visible = False
            'txtMROsuppliesWeight.Visible = False
            'txtMROsuppliesComponentof.Visible = False
            'txtMROsuppliesheight.Visible = False
            'txtMROsuppliesUnitPrice.Visible = False
            'txtMROsuppliesQuantity.Visible = False
            'drpUnit.Visible = False

            Dim controlsToHide() As Control = {txtMROsuppliesName, txtMROsuppliesBrandName, txtMROsuppliesLength, txtMROsuppliesSize, txtMROsuppliesWidth, txtMROsuppliesColor, txtMROsuppliesWeight, txtMROsuppliesComponentof, txtMROsuppliesheight, txtMROsuppliesUnitPrice, txtMROsuppliesQuantity, drpUnit}

            For Each control As Control In controlsToHide
                control.Visible = False
            Next


            txtMROsuppliesName.ReadOnly = True
            txtMROsuppliesBrandName.ReadOnly = True
            txtMROsuppliesLength.ReadOnly = True
            txtMROsuppliesSize.ReadOnly = True

            txtMROsuppliesWidth.ReadOnly = True
            txtMROsuppliesColor.ReadOnly = True
            txtMROsuppliesWeight.ReadOnly = True
            txtMROsuppliesComponentof.ReadOnly = True
            txtMROsuppliesheight.ReadOnly = True
            txtMROsuppliesUnitPrice.ReadOnly = True
            txtMROsuppliesQuantity.ReadOnly = True


            txtMROsuppliesBay.ReadOnly = True
            txtMROsuppliesColumn.ReadOnly = True
            txtMROsuppliesFloor.ReadOnly = True
            txtMROsuppliesRoom.ReadOnly = True
            txtMROsuppliesShelves.ReadOnly = True
            txtMROsuppliesRack.ReadOnly = True
            txtMROsuppliesBin.ReadOnly = True

            btnCancelMROSupplies.Enabled = False


        Else

            btnEditMROSupplies.Text = "SAVE"
            lblMROsuppliesName.Visible = False
            lblMROsuppliesUnit.Visible = False
            lblMROsuppliesBrandName.Visible = False
            lblMROsuppliesLength.Visible = False
            lblMROsuppliesSize.Visible = False

            lblMROsuppliesWidth.Visible = False
            lblMROsuppliesColor.Visible = False
            lblMROsuppliesWeight.Visible = False
            lblMROsuppliesComponentof.Visible = False
            lblMROsuppliesheight.Visible = False
            lblMROsuppliesUnitPrice.Visible = False
            lblMROsuppliesQuantity.Visible = False
            txtMROsuppliesName.Visible = True
            txtMROsuppliesBrandName.Visible = True



            txtMROsuppliesName.Visible = True
            txtMROsuppliesBrandName.Visible = True
            txtMROsuppliesLength.Visible = True
            txtMROsuppliesSize.Visible = True

            txtMROsuppliesWidth.Visible = True
            txtMROsuppliesColor.Visible = True
            txtMROsuppliesWeight.Visible = True
            txtMROsuppliesComponentof.Visible = True
            txtMROsuppliesheight.Visible = True
            txtMROsuppliesUnitPrice.Visible = True
            txtMROsuppliesQuantity.Visible = True
            drpUnit.Visible = True


            'txtMROsuppliesName.ReadOnly = False
            txtMROsuppliesBrandName.ReadOnly = False
            txtMROsuppliesLength.ReadOnly = False
            txtMROsuppliesSize.ReadOnly = False

            txtMROsuppliesWidth.ReadOnly = False
            txtMROsuppliesColor.ReadOnly = False
            txtMROsuppliesWeight.ReadOnly = False
            txtMROsuppliesComponentof.ReadOnly = False
            txtMROsuppliesheight.ReadOnly = False
            txtMROsuppliesUnitPrice.ReadOnly = False
            txtMROsuppliesQuantity.ReadOnly = False

            txtMROsuppliesBay.ReadOnly = False
            txtMROsuppliesColumn.ReadOnly = False
            txtMROsuppliesFloor.ReadOnly = False
            txtMROsuppliesRoom.ReadOnly = False
            txtMROsuppliesShelves.ReadOnly = False
            txtMROsuppliesRack.ReadOnly = False
            txtMROsuppliesBin.ReadOnly = False


            btnCancelMROSupplies.Enabled = True

        End If

    End Sub
    Protected Sub btnCancelMROSupplies_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnEditMROSupplies.Text = "EDIT"

        'lblMROsuppliesName.Visible = True
        'lblMROsuppliesUnit.Visible = True
        'lblMROsuppliesBrandName.Visible = True
        'lblMROsuppliesLength.Visible = True
        'lblMROsuppliesSize.Visible = True

        'lblMROsuppliesWidth.Visible = True
        'lblMROsuppliesColor.Visible = True
        'lblMROsuppliesWeight.Visible = True
        'lblMROsuppliesComponentof.Visible = True
        'lblMROsuppliesheight.Visible = True
        'lblMROsuppliesUnitPrice.Visible = True
        'lblMROsuppliesQuantity.Visible = True
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Label Then
                CType(ctrl, Label).Visible = True
            End If
        Next

        'txtMROsuppliesName.Visible = False
        'txtMROsuppliesBrandName.Visible = False
        'txtMROsuppliesLength.Visible = False
        'txtMROsuppliesSize.Visible = False

        'txtMROsuppliesWidth.Visible = False
        'txtMROsuppliesColor.Visible = False
        'txtMROsuppliesWeight.Visible = False
        'txtMROsuppliesComponentof.Visible = False
        'txtMROsuppliesheight.Visible = False
        'txtMROsuppliesUnitPrice.Visible = False
        'txtMROsuppliesQuantity.Visible = False
        For Each txt As TextBox In Me.Controls.OfType(Of TextBox)()
            txt.Visible = False
        Next
        'txtMROsuppliesName.ReadOnly = True
        'txtMROsuppliesBrandName.ReadOnly = True
        'txtMROsuppliesLength.ReadOnly = True
        'txtMROsuppliesSize.ReadOnly = True

        'txtMROsuppliesWidth.ReadOnly = True
        'txtMROsuppliesColor.ReadOnly = True
        'txtMROsuppliesWeight.ReadOnly = True
        'txtMROsuppliesComponentof.ReadOnly = True
        'txtMROsuppliesheight.ReadOnly = True
        'txtMROsuppliesUnitPrice.ReadOnly = True
        'txtMROsuppliesQuantity.ReadOnly = True

        'txtMROsuppliesBay.ReadOnly = True
        'txtMROsuppliesColumn.ReadOnly = True
        'txtMROsuppliesFloor.ReadOnly = True
        'txtMROsuppliesRoom.ReadOnly = True
        'txtMROsuppliesShelves.ReadOnly = True
        'txtMROsuppliesRack.ReadOnly = True
        'txtMROsuppliesBin.ReadOnly = True
        For Each txt As TextBox In Me.Controls.OfType(Of TextBox)()
            txt.ReadOnly = True
        Next

        drpUnit.Visible = False
        btnCancelMROSupplies.Enabled = False

    End Sub
    Protected Sub btnConsOthersEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnConsOthersEdit.Text = "EDIT" Then


            btnConsOthersEdit.Text = "SAVE"
            'btnConsOthersCancel.enabled = True
            'txtConsOthersName.Visible = True
            'txtConsOthersBrandName.Visible = True
            'txtConsOthersQuantity.Visible = True
            'txtConsOthersUnitPrice.Visible = True
            'txtConsOthersDepValue.Visible = True
            'txtConsOthersDepRate.Visible = True
            'txtConsOthersForm.Visible = True
            'txtConsOthersBatch.Visible = True
            'txtConsOthersLot.Visible = True
            'txtMDateConsOthers.Visible = True
            'txtEDateConsOthers.Visible = True
            'txtAlertConsOthers.Visible = True

            Dim controlsToSetVisible As New List(Of Control) From {
     btnConsOthersCancel,
     txtConsOthersName,
     txtConsOthersBrandName,
     txtConsOthersQuantity,
     txtConsOthersUnitPrice,
     txtConsOthersDepValue,
     txtConsOthersDepRate,
     txtConsOthersForm,
     txtConsOthersBatch,
     txtConsOthersLot,
     txtMDateConsOthers,
     txtEDateConsOthers,
     txtAlertConsOthers
 }

            For Each control As Control In controlsToSetVisible
                control.Visible = True
            Next


            'lblConsOthersName.Visible = False
            'lblConsOthersBrandName.Visible = False
            'lblConsOthersUnitPrice.Visible = False
            'lblConsOthersQuantity.Visible = False
            'lblConsOthersDepValue.Visible = False
            'lblConsOthersDepRate.Visible = False
            'lblConsOthersForm.Visible = False
            'lblConsOthersBatch.Visible = False
            'lblConsOthersLot.Visible = False
            'lblMDateConsOthers.Visible = False
            'lblEDateConsOthers.Visible = False
            'lblAlertConsOthers.Visible = False
            'Dim labelsToHide As New List(Of Label) From {lblConsOthersName, lblConsOthersBrandName, lblConsOthersUnitPrice, lblConsOthersQuantity, lblConsOthersDepValue, lblConsOthersDepRate, lblConsOthersForm, lblConsOthersBatch, lblConsOthersLot, lblMDateConsOthers, lblEDateConsOthers, lblAlertConsOthers}

            'For Each label As Label In labelsToHide
            '    label.Visible = False
            'Next






        Else
            Try
                objDerived.GetRecords("UPDATE [AMS].[TbNonFood] " +
                                        " SET [Form] = '" & txtConsOthersForm.Text & "' " +
                                        " ,[Mftgdate] = '" & txtMDateConsOthers.Text & "' " +
                                        " ,[Batch] = '" & txtConsOthersBatch.Text & "' " +
                                        " ,[Lot] = '" & txtConsOthersLot.Text & "' " +
                                        " ,[EpiryDate] = '" & txtEDateConsOthers.Text & "' " +
                                        " ,[Alert] = '" & txtAlertConsOthers.Text & "' " +
                                        " ,[ItemDesc] = '" & txtConsOthersName.Text & "' " +
                                        " ,[BrandName] = '" & txtConsOthersBrandName.Text & "' " +
                                        " WHERE Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                LoadStockGridBatches()

            Catch ex As Exception
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error occured, pls contact administrator.")
            End Try

            btnConsOthersEdit.Text = "EDIT"
            'btnConsOthersCancel.enabled = False
            'lblConsOthersBrandName.Visible = True
            'lblConsOthersQuantity.Visible = True
            'lblConsOthersUnitPrice.Visible = True
            'lblConsOthersName.Visible = True
            'lblConsOthersDepValue.Visible = True
            'lblConsOthersDepRate.Visible = True
            'txtConsOthersName.Visible = False
            'lblConsOthersForm.Visible = True
            'lblConsOthersBatch.Visible = True
            'lblConsOthersLot.Visible = True
            'lblMDateConsOthers.Visible = True
            'lblEDateConsOthers.Visible = True
            'lblAlertConsOthers.Visible = True
            Dim visibleControls() As Control = {lblConsOthersBrandName, lblConsOthersQuantity, lblConsOthersUnitPrice, lblConsOthersName, lblConsOthersDepValue, lblConsOthersDepRate, lblConsOthersForm, lblConsOthersBatch, lblConsOthersLot, lblMDateConsOthers, lblEDateConsOthers, lblAlertConsOthers}
            Dim hiddenControls() As Control = {txtConsOthersName}

            btnConsOthersCancel.Enabled = False

            For Each control As Control In visibleControls
                control.Visible = True
            Next

            For Each control As Control In hiddenControls
                control.Visible = False
            Next

            'txtConsOthersBrandName.Visible = False
            'txtConsOthersUnitPrice.Visible = False
            'txtConsOthersQuantity.Visible = False
            'txtConsOthersDepValue.Visible = False
            'txtConsOthersDepRate.Visible = False
            'txtConsOthersForm.Visible = False
            'txtConsOthersBatch.Visible = False
            'txtConsOthersLot.Visible = False
            'txtMDateConsOthers.Visible = False
            'txtEDateConsOthers.Visible = False
            'txtAlertConsOthers.Visible = False
            For Each control As Control In Me.Controls
                If TypeOf control Is TextBox AndAlso control.ID.StartsWith("txtConsOthers") Then
                    control.Visible = False
                End If
            Next

        End If

    End Sub
    Protected Sub btnConsOthersCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnConsOthersEdit.Text = "EDIT"
        btnConsOthersCancel.Enabled = False

        'lblConsOthersName.Visible = True
        'lblConsOthersBrandName.Visible = True
        'lblConsOthersUnitPrice.Visible = True
        'lblConsOthersQuantity.Visible = True
        'lblConsOthersDepValue.Visible = True
        'lblConsOthersDepRate.Visible = True
        'lblConsOthersForm.Visible = True
        'lblConsOthersBatch.Visible = True
        'lblConsOthersLot.Visible = True
        'lblMDateConsOthers.Visible = True
        'lblEDateConsOthers.Visible = True
        'lblAlertConsOthers.Visible = True
        Dim labels() As Label = {lblConsOthersName, lblConsOthersBrandName, lblConsOthersUnitPrice, lblConsOthersQuantity, lblConsOthersDepValue, lblConsOthersDepRate, lblConsOthersForm, lblConsOthersBatch, lblConsOthersLot, lblMDateConsOthers, lblEDateConsOthers, lblAlertConsOthers}

        For Each lbl As Label In labels
            lbl.Visible = True
        Next


        'txtAlertConsOthers.Visible = False
        'txtEDateConsOthers.Visible = False
        'txtMDateConsOthers.Visible = False
        'txtConsOthersLot.Visible = False
        'txtConsOthersBatch.Visible = False
        'txtConsOthersForm.Visible = False
        'txtConsOthersDepRate.Visible = False
        'txtConsOthersDepValue.Visible = False
        'txtConsOthersQuantity.Visible = False
        'txtConsOthersUnitPrice.Visible = False
        'txtConsOthersBrandName.Visible = False
        'txtConsOthersName.Visible = False
        For Each control As Control In Me.Controls
            If control.ID IsNot Nothing AndAlso control.ID.StartsWith("txtConsOthers") Then
                control.Visible = False
            End If
        Next


    End Sub



    Protected Sub txtMROsuppliesQuantity_TextChanged(sender As Object, e As EventArgs)
        Dim creditqty As Integer = objDerived.GetValue("select sum(CreditQty) from ams.TbStock_Ledger  where Item_ID =" & hdnItemNo.Value, CommandType.Text)
        If creditqty >= txtMROsuppliesQuantity.Text Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must not be less than the Credit Quantity")
            txtMROsuppliesQuantity.Text = objDerived.GetValue("Select cast(balance As int) from ams.Stock where Item_ID =" & hdnItemNo.Value, CommandType.Text)

        End If

    End Sub
    Protected Sub btnMedicineAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Table1.Rows.Count >= 5 Then
        '    loadpriceperquantitytable(1)
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Maximum Price Per Quantity is 8")
        'Else
        '    Session("PriceperQuantity") += 1
        '    loadpriceperquantitytable(Session("PriceperQuantity"))
        'End If
        'Dim i As Integer = Table1.Rows.Count
        'Table1.Rows().Clear()
        'loadpriceperquantitytable(i + 1)

        'MsgBox(Table1.Rows.Count)

    End Sub


    Protected Sub btnViewSIR_Click(sender As Object, e As EventArgs)
        Dim CY As String = "CY" & Year(txtDate.Text)
        Session("cyear") = CY
        Me.Page.Response.Redirect("~/Records/rpt_stockcardinventory.aspx")



    End Sub
    Protected Sub BtnList_Click(sender As Object, e As EventArgs)
        ' Try
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select sum(a.ReorderPt) as ReorderPt ,sum(a.Balance) as Balance,e.Description,isnull(b.Item_Code,'') as Item_Code,                                              " &
                    "  b.itemCompletedesc as Item_Desc from ams.Stock as a " &
                    " inner join dbo.m_item as b on a.Item_ID = b.Item_ID                                                                                    " &
                    " inner join ams.m_Unit as e on b.Unit_ID = e.Unit_ID                                                                                    " &
                    " inner join ams.item_particular as c on b.item_particular_id = c.item_particular_id                                                     " &
                    "group by e.Description,Item_Code,c.description,b.Brand,b.Color,b.Size,b.item_desc,b.itemCompletedesc" &
                    " HAVING sum(a.ReorderPt) > sum(a.Balance)", CommandType.Text)
        grdItemROP.DataSource = dt
        grdItemROP.DataBind()

        ModalPopupExtender5.Show()
        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.updatepanel1, "something went wrong, please contact system admin.")
        'End Try
    End Sub



    Protected Sub grdItemROP_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("select sum(a.ReorderPt) as ReorderPt ,sum(a.Balance) as Balance,e.Description,isnull(b.Item_Code,'') as Item_Code,                                              " &
                    " c.description + ',' + isnull(b.Brand, '') + ',' + isnull(b.Color,'') + ',' + isnull(b.Size,'') + ',' + b.item_desc as Item_Desc from ams.Stock as a " &
                    " inner join dbo.m_item as b on a.Item_ID = b.Item_ID                                                                                    " &
                    " inner join ams.m_Unit as e on b.Unit_ID = e.Unit_ID                                                                                    " &
                    " inner join ams.item_particular as c on b.item_particular_id = c.item_particular_id                                                     " &
                    "group by e.Description,Item_Code,c.description,b.Brand,b.Color,b.Size,b.item_desc" &
                    " HAVING sum(a.ReorderPt) > sum(a.Balance)", CommandType.Text)
            grdItemROP.PageIndex = e.NewPageIndex
            grdItemROP.DataSource = dt
            grdItemROP.DataBind()
            ModalPopupExtender5.Show()
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "something went wrong, please contact system admin.")
        End Try

    End Sub


End Class
