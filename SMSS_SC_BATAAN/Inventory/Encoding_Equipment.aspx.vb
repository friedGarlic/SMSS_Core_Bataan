Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Drawing

Partial Class Inventory_Encoding_Equipment
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim counts As Integer = 0
    Dim objDerived As New DerivedDal

    Private Sub Inventory_Encoding_Equipment_Load(sender As Object, e As EventArgs) Handles Me.Load
        objx.GetAccessRight(Me.Session("@UserName"), Page)
        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If
        If Not Page.IsPostBack Then
            txtDate.text = Date.Now.ToString("MM-dd-yyyy")

            Dim Classification As New DataTable
            Classification = objDerived.GetDataTable("select [ClassificationId],[ClassificationName] From [dbo].[tbl_Classification] where [ClassificationName] like 'Equipment%'", CommandType.Text)
            ddClass.DataSource = CType(Classification, DataTable)
            Me.ddClass.DataTextField = ("ClassificationName")
            Me.ddClass.DataValueField = ("ClassificationId")
            Me.ddClass.DataBind()
            selectClassification()


        End If

    End Sub
    Public Function selectClassification()
        lblClass.text = "Encoding of " & ddClass.selecteditem.text
        ' lblClass1.text = ddClass.selecteditem.text
        Dim PListofGL As New DataTable
        PListofGL = objDerived.GetDataTable("select distinct c.SubClassificationID,c.SubClassificationName " &
                                            "	From tbl_SubClassification as c" &
                                            "        Left outer join tblclassmatrix as b on b.SubClassificationID = c.SubClassificationID" &
                                            "        inner join  tbl_Classification as a on a.ClassificationId = b.classificationid " &
                                            "        where b.classificationid ='" & ddClass.SelectedItem.Value & "' order by c.SubClassificationName ", CommandType.Text)

        'PListofGL = objDerived.GetDataTable("SELECT dbo.tbl_SubClassification.SubClassificationID, dbo.tbl_SubClassification.SubClassificationName " &
        '                                    "FROM dbo.tbl_Classification INNER JOIN " &
        '                                    "dbo.tbl_SubClassification ON dbo.tbl_Classification.ClassificationId = dbo.tbl_SubClassification.ClassificationID INNER JOIN " &
        '                                    "dbo.tbl_SubCategory ON dbo.tbl_SubClassification.ClassificationID = dbo.tbl_SubCategory.ClassificationID " &
        '                                    "WHERE (dbo.tbl_Classification.ClassificationId = '" & ddClass.SelectedItem.Value & "')", CommandType.Text)


        Me.drpSubClass.items.add("Select")
        Me.drpSubClass.DataSource = CType(PListofGL, DataTable)
        Me.drpSubClass.DataTextField = ("SubClassificationName")
        Me.drpSubClass.DataValueField = ("SubClassificationID")
        Me.drpSubClass.DataBind()
        Me.drpSubClass.enabled = True
        SelectSubClassification()
    End Function

    Public Function SelectSubClassification()
        On Error Resume Next
        lblSubClass.Text = drpSubClass.SelectedItem.Text.ToUpper & " INFORMATION"
        Dim PListofGL As New DataTable
        PListofGL = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & ddClass.SelectedItem.Value & "','" & drpSubClass.SelectedItem.Value & "'", CommandType.Text)
        Me.ddGlAccount.Items.Add("Select")
        Me.ddGlAccount.DataSource = CType(PListofGL, DataTable)
        Me.ddGlAccount.DataTextField = ("GA_Title")
        Me.ddGlAccount.DataValueField = ("GA_ID")
        Me.ddGlAccount.DataBind()
        Me.ddGlAccount.Enabled = True

        SelectGAaccount()
    End Function
    Public Function SelectGAaccount()
        Dim dt As New DataTable
        Dim GLaccount As String
        If ddGlAccount.text = "" Then
            GLaccount = 0
        Else
            GLaccount = ddGlAccount.selecteditem.value
        End If
        dt = objDerived.GetDataTable("select distinct item_particular_id,description From AMS.item_particular " &
                                            " inner join tblclassmatrix as c on c.categoryid =  AMS.item_particular.item_particular_id" &
                                            " where c.GA_ID ='" & GLaccount & "'", CommandType.Text)
        ddCategory.datasource = dt
        ddCategory.DataTextField = ("description")
        ddCategory.DataValueField = ("item_particular_id")
        ddCategory.DataBind()
        selectCatergory()
        multiviewselected()

        '  MultiviewSupplier()
        '        MultiviewSupplier()
    End Function

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

        ' loadStockOfficeSupplies()
        '  MultiviewSupplier()
        multiviewselected()
    End Function

    Protected Sub ddGlAccount_SelectedIndexChanged(sender As Object, e As EventArgs)
        SelectGAaccount()
    End Sub
    Public Sub multiviewselected()
        Dim subcategory As Integer


        If ddSubCategory.text = "" Then
            subcategory = 0
        Else
            subcategory = ddSubCategory.selecteditem.value
        End If


        Dim Categoryid As Integer
        If ddCategory.text = "" Then
            Categoryid = 0
        Else
            Categoryid = ddCategory.selecteditem.value
        End If

        Dim dtAccount As New DataTable

        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_v1_02262022] '" & ddGlAccount.SelectedValue() & "','" & Categoryid & "','" & subcategory & "'", CommandType.Text)

        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
        End If

        gvsearchproperty.DataSource = dtAccount
        gvsearchproperty.DataBind()
        gvsearchproperty.SelectedIndex = 0

        If drpSubClass.selecteditem.text.contains("Vehicle") Then
            Me.mvEquipment.ActiveViewIndex = 1

            Dim itemdesc As New DataTable
            Dim dtitemdesc As New DataTable
            dtitemdesc = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_v2_03102022] " & ddClass.selectedvalue() & ",'" & drpSubClass.selecteditem.value & "'", CommandType.Text)
            DrpVehicleName.datasource = dtitemdesc
            DrpVehicleName.DataTextField = ("ItemDescription")
            DrpVehicleName.DataValueField = ("Item_ID")
            DrpVehicleName.DataBind()
            DrpVehicleName.enabled = True
            'loadEquipmentInformation_from_drpName()
            'loadEquipmentList()
            'loadEquipmentLedger()
        ElseIf drpSubClass.selecteditem.text.contains("Military, Police And Security Equipment") And ddCategory.SelectedItem.Text.Contains("Gun") Then
            Me.mvEquipment.ActiveViewIndex = 2
            Dim itemdesc As New DataTable
            Dim dtitemdesc As New DataTable
            dtitemdesc = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_v2_03102022] " & ddClass.selectedvalue() & ",'" & drpSubClass.selecteditem.value & "','" & ddcategory.SelectedItem.Value & "'", CommandType.Text)
            drpMilitaryEquipmentName.datasource = dtitemdesc
            drpMilitaryEquipmentName.DataTextField = ("ItemDescription")
            drpMilitaryEquipmentName.DataValueField = ("Item_ID")
            drpMilitaryEquipmentName.DataBind()
            drpMilitaryEquipmentName.enabled = True
            loadEquipmentInformation_from_drpMilitaryName()

        Else
            Me.mvEquipment.ActiveViewIndex = 0

            Dim itemdesc As New DataTable
            Dim dtitemdesc As New DataTable
            dtitemdesc = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_v2_03102022] " & ddClass.selectedvalue() & ",'" & drpSubClass.selecteditem.value & "','" & ddcategory.SelectedItem.Value & "'", CommandType.Text)
            drpName.datasource = dtitemdesc
            drpName.DataTextField = ("ItemDescription")
            drpName.DataValueField = ("Item_ID")
            drpName.DataBind()
            drpName.enabled = True
            loadEquipmentInformation_from_drpName()
            loadEquipmentList()
            loadEquipmentLedger()
        End If


    End Sub

    Public Function createdatatable15(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("ItemDescription", GetType(String))
        dt.Columns.Add("unit", GetType(String))
        dt.Columns.Add("item_particular_id", GetType(Long))
        dt.Columns.Add("TD_ID", GetType(Integer))
        dt.Columns.Add("ItemCount", GetType(Integer))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("reorderpt", GetType(Integer))
        'dt.Columns.Add("Balance", GetType(Integer))
        'dt.Columns.Add("orders", GetType(String))
        'dt.Columns.Add("minqty", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Property_code") = DBNull.Value
            dr("ItemCount") = DBNull.Value
            dr("ItemDescription") = DBNull.Value
            dr("unit") = DBNull.Value
            dr("reorderpt") = DBNull.Value
            dr("item_particular_id") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("TD_ID") = DBNull.Value
            'dr("Balance") = DBNull.Value
            'dr("orders") = DBNull.Value
            'dr("minqty") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Sub loadEquipmentList()
        Dim dtEquipments As New DataTable
        dtEquipments = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtEquipments.Rows.Count < 4 Then
            dtEquipments.Merge(createdatatable4A(3 - dtEquipments.Rows.Count))
        End If
        grdlistofEuipment.DataSource = dtEquipments
        grdlistofEuipment.DataBind()
        grdlistofEuipment.SelectedIndex = 0

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

    Public Sub loadEquipmentLedger()
        btnEquipmentLedger.CssClass = "Clicked"
        btnequipmentrepairs.CssClass = "Initial"
        btnequipmentattachdoc.CssClass = "Initial"
        Me.mvledger.SetActiveView(Me.vwledger)

        Dim dtAccount As New DataTable
        Dim itemid As String
        'If 

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "' order by dDate", CommandType.Text)
        If hdnItemNo.value = "" Then
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)

        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.value & "'", CommandType.Text)

        End If
        ' dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtAccount.Rows.Count > 0 Then
            btnSave.Text = "EDIT"
        Else
            btnSave.Text = "SAVE"
            LoadEquipDTL()
        End If


        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If


        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
    End Sub

    Public Function createdatatableledger(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        dt.Columns.Add("dDate", GetType(Date))
        dt.Columns.Add("Trans_Type", GetType(String))
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
        For i As Integer = 0 To row
            dr = dt.NewRow
            'dr("Property_Dtl_ID") = DBNull.Value
            dr("dDate") = DBNull.Value
            dr("Trans_Type") = DBNull.Value
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

    Protected Sub btnequipmentrepairs_Click(sender As Object, e As EventArgs)
        loadEquipmentRepair()
    End Sub

    Protected Sub loadEquipmentRepair()
        btnEquipmentLedger.CssClass = "Initial"
        btnequipmentrepairs.CssClass = "Clicked"
        btnequipmentattachdoc.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwrepairsandmaintenance) '[dbo].[View_EquipmentRepair]
        Dim dtAccount As New DataTable

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_RepairAndMaintenance] where PropertyNo = '" & grdlistofEuipment.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable11(7 - dtAccount.Rows.Count))
        End If
        grdrepairsandmaintenance.DataSource = dtAccount
        grdrepairsandmaintenance.DataBind()

    End Sub
    Public Function createdatatable11(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        dt.Columns.Add("Date", GetType(String))
        dt.Columns.Add("serviceprovider", GetType(String))
        dt.Columns.Add("NatureRepair", GetType(String))
        dt.Columns.Add("invoiceno", GetType(String))
        dt.Columns.Add("Amount", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Property_Dtl_ID") = DBNull.Value
            dr("Date") = DBNull.Value
            dr("serviceprovider") = DBNull.Value
            dr("NatureRepair") = DBNull.Value
            dr("invoiceno") = DBNull.Value
            dr("amount") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Protected Sub btnEquipmentLedger_Click(sender As Object, e As EventArgs)
        loadEquipmentLedger()
    End Sub
    Protected Sub btnequipmentattachdoc_Click(sender As Object, e As EventArgs)
        loadEquipmentAttchDocu()
        loadAttchDocuChangeIndex()
    End Sub
    Protected Sub loadEquipmentAttchDocu()
        btnEquipmentLedger.CssClass = "Initial"
        btnequipmentrepairs.CssClass = "Initial"
        btnequipmentattachdoc.CssClass = "Clicked"
        Me.mvledger.SetActiveView(Me.vwdocumentattachment)

        Dim dtAccount As New DataTable
        dtAccount = objDerived.GetDataTable("Select *  from AMS.DocumentAttachment where IdentityNo = '" & grdlistofEuipment.SelectedDataKey("PODtl_ID") & "' and TableName = 'AIR_EquipAttchDocu'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable3(7 - dtAccount.Rows.Count))
        End If
        grdpropertydocdetails.DataSource = dtAccount
        grdpropertydocdetails.DataBind()
        grdpropertydocdetails.SelectedIndex = 0

        loadAttchDocuChangeIndex()
    End Sub

    Public Function createdatatable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("DocuId", GetType(Long))
        dt.Columns.Add("IdentityNo", GetType(Long))
        dt.Columns.Add("documentname", GetType(String))
        dt.Columns.Add("documentno", GetType(String))
        dt.Columns.Add("validatedby", GetType(String))
        dt.Columns.Add("datevalidated", GetType(String))
        dt.Columns.Add("Remarks", GetType(String))
        dt.Columns.Add("TableName", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("DocuId") = DBNull.Value
            dr("IdentityNo") = DBNull.Value
            dr("documentname") = DBNull.Value
            dr("documentno") = DBNull.Value
            dr("validatedby") = DBNull.Value
            dr("datevalidated") = DBNull.Value
            dr("Remarks") = DBNull.Value
            dr("TableName") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub loadAttchDocuChangeIndex()
        Try
            Dim id As New Integer
            id = grdpropertydocdetails.SelectedDataKey(0).ToString
            imgpropertydocs.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & id
        Catch ex As Exception
            imgpropertydocs.ImageUrl = "~/images/BlankImage.jpg"
        End Try

        Me.mvledger.SetActiveView(Me.vwdocumentattachment)
    End Sub

    Protected Sub grdlistofEuipment_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")

            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdlistofEuipment, "Select$" + e.Row.RowIndex.ToString()))
            ' e.Row.Cells(0).Visible = False

        End If



    End Sub
    Protected Sub grdlistofEuipment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            loadEquipmentInformation()
            loadEquipmentLedger()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grdlistofEuipment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtAccount As New DataTable
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
        End If

        grdlistofEuipment.PageIndex = e.NewPageIndex
        grdlistofEuipment.DataSource = dtAccount
        grdlistofEuipment.DataBind()
        grdlistofEuipment.SelectedIndex = 0
    End Sub

    Protected Sub gvsearchproperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSave.enabled = True
        btnCancel.enabled = True
        loadEquipmentList()

        grdlistofEuipment.SelectedIndex = 0
        loadEquipmentInformation()
        loadEquipmentLedger()

    End Sub
    Protected Sub gvsearchproperty_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearchproperty, "Select$" + e.Row.RowIndex.ToString()))
        End If

        '=-= Notify if Balance reach re-order point
        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    If e.Row.Cells(7).Text = "&nbsp;" Then
        '        Exit Sub
        '    Else
        '        If CInt(e.Row.Cells(4).Text) <= CInt(e.Row.Cells(7).Text) Then  'e.Row.Cells(4).Text <= e.Row.Cells(3).Text Then
        '            e.Row.BackColor = Drawing.Color.OrangeRed
        '        End If
        '    End If
        'End If


    End Sub


    Protected Sub loadEquipmentInformation()
        Dim CYear As String = "CY" & Year(txtdate.text)
        Dim itemid As String
        If gvsearchproperty.SelectedDataKey("Item_ID") Is Nothing Or isdbnull(gvsearchproperty.SelectedDataKey("Item_ID")) Then

            itemid = "0"
        Else
            itemid = gvsearchproperty.SelectedDataKey("Item_ID")
        End If
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & " from dbo.m_item as a inner join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadEquipDTL()
        Else
            txtName.Text = dt.Rows(0).Item("Name").ToString
            txtequipmentdesciption.Text = dt.Rows(0).Item("description").ToString
            txtequipmentpowerinput.Text = ""
            txtequipmentdimension.Text = ""
            txtequipmentareacapacity.Text = ""
            txtequipmentmodel.Text = ""
            txtequipmentwaranty.Text = ""
            txtSpecification.Text = ""
            txtEAcqDate.text = Date.Now.ToString("MM/dd/yyyy")
            txtEAcqCost.text = dt.Rows(0).Item(CYear).ToString
            txtEMarketValue.text = dt.Rows(0).Item(CYear).ToString
            'Dim DA As DateTime
            'DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")
            txtNoYears.Text = "0"
            txtequipmentdepreciatedvalue.Text = FormatNumber(0, 2)
            lblequipmentdepreciatedRate.Text = "0"
            lblequipmentdepreciatedRate.readonly = False

            txtUsefulLife.Text = ""
            txtSalvageValue.Text = FormatNumber(0, 2)
            Session("useful_life") = 0

        End If
    End Sub
    Protected Sub LoadEquipDTL()
        'txtequipmentpowerinput.Text = ""
        'txtequipmentmodel.Text = ""
        'txtequipmentSerialNo.Text = ""

        'txtEquipmentQuantity.Text = ""
        'txtequipmentwaranty.Text = ""

        'txtequipmentdimension.Text = ""
        'txtContractor.Text = ""
        'txtContactPerson.Text = ""
        'txtCellphoneNo.Text = ""
        'txtEAcqDate.Text = ""
        'txtEAcqCost.Text = ""
        'txtDepreciatedRate.Text = ""
        'txtequipmentdepreciatedvalue.Text = ""
        'txtEMarketValue.Text = ""
        'txtNoYears.Text = ""
        'txtUsefulLife.Text = ""
        'txtSalvageValue.Text = ""
        'txtSpecification.Text = ""
        ' Create an array to store references to the textboxes
        Dim textboxes As TextBox() = New TextBox() _
{
    txtequipmentpowerinput, txtequipmentmodel, txtequipmentSerialNo, txtEquipmentQuantity,
    txtequipmentwaranty, txtequipmentdimension, txtContractor, txtContactPerson,
    txtCellphoneNo, txtEAcqDate, txtEAcqCost, txtDepreciatedRate, txtequipmentdepreciatedvalue,
    txtEMarketValue, txtNoYears, txtUsefulLife, txtSalvageValue, txtSpecification
}

        ' Iterate through the array and clear the text in each textbox
        For Each textbox As TextBox In textboxes
            textbox.Text = ""
        Next


    End Sub


    Protected Sub LoadMilitaryEquipDTL()
        hdnItemNo.value = ""
        hdnGAId.value = ""
        'txtMilitaryEquipmentdescription.Text = ""
        'txtMilitaryEquipmentFrame.Text = ""
        'txtMilitaryEquipmentManufacturer.Text = ""
        'txtMilitaryEquipmentColor.Text = ""
        'txtMilitaryEquipmentCaliber.Text = ""
        'txtMilitaryEquipmentCapacityExtended.Text = ""
        'txtMilitaryEquipmentBarrel.Text = ""
        'txtMilitaryEquipmentSights.Text = ""
        'Optimize code
        Dim txtBoxes As TextBox() = {txtMilitaryEquipmentdescription, txtMilitaryEquipmentFrame, txtMilitaryEquipmentManufacturer, txtMilitaryEquipmentColor, txtMilitaryEquipmentCaliber, txtMilitaryEquipmentCapacityExtended, txtMilitaryEquipmentBarrel, txtMilitaryEquipmentSights}

        For Each txtBox As TextBox In txtBoxes
            txtBox.Text = ""
        Next

    End Sub

    Protected Sub drpSubClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        SelectSubClassification()

    End Sub
    Protected Sub ddCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectCatergory()

    End Sub


    Protected Sub lblequipmentdepreciatedRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' LoadEquipDepreciation()
    End Sub

    Protected Sub LoadEquipDepreciation()
        'Try
        '    Dim Cost As Double
        '    Dim SalValue As Double
        '    Dim TDepValue As Double
        '    Dim AcquisitionYear As Date
        '    Dim NoYears As Integer
        '    Dim DepVRate As Double
        '    Dim DepPRate As Double
        '    Dim ULife As Integer

        '    AcquisitionYear = txtEAcqDate.text
        '    Cost = txtEAcqCost.text
        '    ULife = txtUsefulLife.text
        '    SalValue = FormatNumber(CType(txtSalvageValue.Text, Decimal), 2)
        '    NoYears = (Year(txtdate.text) - Year(AcquisitionYear))

        '    'FORMULA USE: 
        '    'LET:
        '    'DV = DEPRECIATED VALUE
        '    'LFE = USEFUL LIFE
        '    'AC = ACQUISITION COST
        '    'NY = NUMBER OF YEARS FROM DATE ITEM ACQUIRED
        '    'DR = DEPRECIATION RATE
        '    'SalValue = SALVAGE VALUE
        '    'DepVRate = DEPRECIATION RATE AMOUNT PER YEAR
        '    'DepPRate = DEPRECIATION RATE PERCENT PER YEAR

        '    '============================
        '    'DEPRECIATION RATE (AMOUNT) = (COST - SALVAGE) / USEFUL LIFE
        '    DepVRate = ((Cost - SalValue) / ULife)

        '    'DEPRECIATION RATE (PERCENT) = (SALVAGE / COST) * 100
        '    DepPRate = FormatNumber(((DepVRate / Cost) * 100), 2)

        '    'TOTAL DEPRECIATION VALUE = COST - (DEP.VALUE * NO. YEARS)
        '    TDepValue = FormatNumber(Cost - (DepVRate * NoYears), 2)

        '    'objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET DepreciationRate = '" & DepPRate & "',DepreciationValue = '" & TDepValue & "',SalvageValue = '" & SalValue & "' WHERE Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)

        '    lblequipmentdepreciatedRate.Text = DepPRate
        '    If FormatNumber(TDepValue, 2) = 0.00 Then
        '        txtequipmentdepreciatedvalue.Text = " "
        '    Else
        '        txtequipmentdepreciatedvalue.Text = FormatNumber(TDepValue, 2)

        '    End If
        '    If FormatNumber(SalValue, 2) = 0.00 Then
        '        txtSalvageValue.Text = " "
        '    Else
        '        txtSalvageValue.Text = FormatNumber(SalValue, 2)

        '    End If

        '    txtEMarketValue.text = FormatNumber(Cost - TDepValue, 2)

        'Catch ex As Exception
        'End Try
    End Sub

    Protected Sub txtEAcqDate_TextChanged(sender As Object, e As EventArgs)
        'LoadEquipDepreciation()
    End Sub

    Protected Sub txtSalvageValue_TextChanged(sender As Object, e As EventArgs)
        ' LoadEquipDepreciation()
    End Sub


    Protected Sub btnMilitaryEquipmentSave_Click(sender As Object, e As EventArgs)
        'If drpMilitaryEquipmentName.SelectedItem.text = "" Or txtMilitaryEquipmentDescription.text = "" Or txtMilitaryEquipmentUsefulLife.text = "" Or txtMilitaryEquipmentDepRate.text = "" Or txtMilitaryEquipmentAcqCost.text = "" Or txtMilitaryEquipmentDepValue.text = "" Or txtMilitaryEquipmentSalvageValue.text = "" Or txtMilitaryEquipmentMarketValue.text = "" Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")

        'Else
        If Not IsNumeric(txtMilitaryEquipmentDepRate.text) Or Not IsNumeric(txtMilitaryEquipmentAcqCost.text) Or Not IsNumeric(txtMilitaryEquipmentDepValue.text) Or Not IsNumeric(txtMilitaryEquipmentSalvageValue.text) Or Not IsNumeric(txtMilitaryEquipmentMarketValue.text) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
            Else
                Dim Prop_Hdr As New t_property_hdr
                With Prop_Hdr
                    '.Property_ID = Property_ID
                    .Property_Date = txtMilitaryEquipmentAcqDate.Text
                    .Issuance = 0
                    .Remarks = "Manual Encoding of Old Properties"
                    .Emp_ID = 0
                    .F_ID = 1
                    .AIRDtl_ID = 0
                    .deptid = 0
                    .isDonated = False
                    .GA_ID = hdnGAId.Value
                    .DonationRemarks = ""
                    .Qty = txtMilitaryEquipmentQuantity.text
                    .Balance = txtMilitaryEquipmentQuantity.text
                    .Cost = CType(txtMilitaryEquipmentAcqCost.Text, Decimal)
                    .Item_ID = hdnItemNo.value
                    .Property_code = objDerived.GetValue("select ga_code2 from [AMS].[vw_item_master_list] where Item_ID ='" & hdnItemNo.value & "' ", CommandType.Text)
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .Function_ID = 86
                    .TD_ID = 1
                    .Project_ID = 0
                    .Program_id = 0
                    .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.value & "' ", CommandType.Text)
                End With

                Dim PropHdr_ID As Integer = 0
                PropHdr_ID = Prop_Hdr.save()

                objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

                For i As Integer = 0 To grdPropertyInfo.rows.count - 1



                    Dim Prop_Dtl As New t_property_dtl
                    With Prop_Dtl
                        .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                        .Property_ID = PropHdr_ID
                        .Issued = False
                        .Repair = False
                        .Dispose = False
                        .DisposeDate = "1/1/1900"
                        .IsInspectionForDisposal = False
                        .InspectionDate = txtMilitaryEquipmentAcqDate.Text
                        .F_ID = 1
                        .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                        .Barcode = " "
                        .Amount = CType(txtMilitaryEquipmentAcqCost.Text, Decimal)
                        .Status = "Accepted"
                        .Details = ""
                        .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.value & "' ", CommandType.Text)
                        .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                        .AccountablePerson = ""
                        .Function_ID = 86
                    End With

                    Dim PropDtl_ID As Integer
                    PropDtl_ID = Prop_Dtl.save()

                    objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtMilitaryEquipmentMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

                    Dim info_id As Integer
                    Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info

                    With objEquipInfo
                        .EquipInfoId = 0
                        .AIRDtl_ID = 0
                        .IsAccepted = True
                        .Property_Dtl_ID = PropDtl_ID
                        .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                        .Name = drpMilitaryEquipmentName.SelectedItem.text
                        .Description = txtMilitaryEquipmentdescription.text
                        .manufacturer = txtMilitaryEquipmentmanufacturer.text
                        .caliber = txtMilitaryEquipmentcaliber.text
                        .barrel = txtMilitaryEquipmentbarrel.text
                        .frame = txtMilitaryEquipmentframe.text
                        .color = txtMilitaryEquipmentcolor.text
                        .capacity = txtMilitaryEquipmentCapacityExtended.text
                        .sights = txtMilitaryEquipmentsights.text
                        .DepreciationRate = 0
                        .DepreciationValue = 0
                        .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                        .RoomLocation = ""
                        .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                        'CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).SelectedItem.value
                        .AccountablePerson = ""
                        .SalvageValue = txtMilitaryEquipmentSalvageValue.text

                    End With



                    info_id = objEquipInfo.save()
                    objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

                    Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details
                    With objEquipDtl
                        .EquipmentId = 0
                        .EquipInfoId = info_id
                        .Property_Dtl_ID = PropDtl_ID
                        .MarketValue = txtMilitaryEquipmentMarketValue.Text
                        .Condition = ""
                        .Status = "Accepted"
                        ' .WarehouseID = drpEquipmentWarehouse.selectedvalue
                        Dim drp As DropDownList
                        drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtMac"), DropDownList)
                        .BuildingId = drp.SelectedValue
                        '    .MaintenanceContactNo = txtMilitaryEquipmentContractor.text
                        '     .MaintenanceContactPerson = txtMilitaryEquipmentContactPerson.text
                        '     .MaintenanceContractor = txtMilitaryEquipmentCellphoneNo.text
                    End With
                    objEquipDtl.save()


                    Dim Prop_Ledger As New t_PropertyLedger

                    With Prop_Ledger
                        .Ledger_ID = 0
                        .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                        .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                        .Trans_Type = "Manual Entry"
                        .dDate = txtMilitaryEquipmentAcqDate.Text
                        .Ref = ""
                        .AccountablePerson = ""
                        .Department = 0
                        .Position = ""
                        .AcceptedBy = ""
                        .InspectedBy = ""
                        .Item_ID = hdnItemNo.Value
                        .DebitQty = txtMilitaryEquipmentQuantity.Text
                        .DebitCost = CType(txtMilitaryEquipmentAcqCost.Text, Decimal) * txtMilitaryEquipmentQuantity.Text
                        .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)
                        .CreditQty = "0"
                        .CreditUnit = "-"
                        .CreditCost = "0.00"
                        .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)

                        Dim Eqty As Integer
                        Dim Eqbalance As Decimal
                        Dim dtledger As New DataTable

                        dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                        If dtledger.Rows.Count = 0 Then
                            Eqty = 0
                            Eqbalance = 0.0
                        Else
                            Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                            Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                        End If
                        .BalanceQty = Eqty + 1
                        .BalanceCost = CType(txtMilitaryEquipmentAcqCost.Text, Decimal) + CType(Eqbalance, Decimal)
                    End With
                    Prop_Ledger.save()
                Next





                btnMilitaryEquipmentSave.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                multiviewselected()
                'loadEquipmentList()
                'loadEquipmentInformation()
                loadEquipmentInformation_from_drpMilitaryName()
                loadEquipmentLedger()
            End If
        'End If


    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        If btnSave.Text = "SAVE" Then
            SAVE()
        ElseIf btnSave.Text = "EDIT" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            ModalPopupExtender1.Show()
        ElseIf btnSave.Text = "UPDATE" Then
            Edit()
        End If
    End Sub
    Public Sub SAVE()
        Dim a1 As String
        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            'msgbox(CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text)

            If CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text = "" Then
                a1 = ""
            Else
                a1 = 1
            End If
        Next

        If a1 = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill Up the Property Information Fields")
            Exit Sub
        End If

        'If txtName.Text = "" Or txtequipmentdesciption.Text = "" Or txtUsefulLife.Text = "" Or txtDepreciatedRate.Text = "" Or txtEAcqCost.Text = "" Or txtequipmentdepreciatedvalue.Text = "" Or txtSalvageValue.Text = "" Or txtEMarketValue.Text = "" Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")

        'Else
        If Not IsNumeric(txtDepreciatedRate.Text) Or Not IsNumeric(txtEAcqCost.Text) Or Not IsNumeric(txtequipmentdepreciatedvalue.Text) Or Not IsNumeric(txtSalvageValue.Text) Or Not IsNumeric(txtEMarketValue.Text) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
            Else
                Dim Prop_Hdr As New t_property_hdr
                With Prop_Hdr
                    '.Property_ID = Property_ID
                    .Property_Date = txtEAcqDate.Text
                    .Issuance = 0
                    .Remarks = "Manual Encoding of Old Properties"
                    .Emp_ID = 0
                    .F_ID = 1
                    .AIRDtl_ID = 0
                    .deptid = 0
                    .isDonated = False
                    .GA_ID = hdnGAId.Value
                    .DonationRemarks = ""
                    .Qty = txtEquipmentQuantity.Text
                    .Balance = txtEquipmentQuantity.Text
                    .Cost = CType(txtEAcqCost.Text, Decimal)
                    .Item_ID = hdnItemNo.Value
                    .Property_code = objDerived.GetValue("select ga_code2 from [AMS].[vw_item_master_list] where Item_ID ='" & hdnItemNo.Value & "' ", CommandType.Text)
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .Function_ID = 86
                    .TD_ID = 1
                    .Project_ID = 0
                    .Program_id = 0
                    .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                End With

                Dim PropHdr_ID As Integer = 0
                PropHdr_ID = Prop_Hdr.save()

                objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

                For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1

                    Dim Prop_Dtl As New t_property_dtl
                    With Prop_Dtl
                        .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                        .Property_ID = PropHdr_ID
                        .Issued = False
                        .Repair = False
                        .Dispose = False
                        .DisposeDate = "1/1/1900"
                        .IsInspectionForDisposal = False
                        .InspectionDate = txtEAcqDate.Text
                        .F_ID = 1
                        .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                        .Barcode = " "
                        .Amount = CType(txtEAcqCost.Text, Decimal)
                        .Status = "Accepted"
                        .Details = txtSpecification.Text
                        .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                        .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                        .AccountablePerson = ""
                        .Function_ID = 86
                    End With

                    Dim PropDtl_ID As Integer
                    PropDtl_ID = Prop_Dtl.save()

                    objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtEMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

                    Dim info_id As Integer
                    Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info

                    With objEquipInfo
                        .EquipInfoId = 0
                        .AIRDtl_ID = 0
                        .IsAccepted = True
                        .Property_Dtl_ID = PropDtl_ID
                        .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                        .Name = txtName.Text
                        .Description = txtequipmentdesciption.Text
                        .PowerInput = txtequipmentpowerinput.Text
                        .Dimension = txtequipmentdimension.Text
                        .AreaCapacity = txtequipmentareacapacity.Text
                        .Model = txtequipmentmodel.Text
                        .Warranty = txtequipmentwaranty.Text
                        .Specification = txtSpecification.Text
                        .DepreciationRate = txtDepreciatedRate.Text
                        .DepreciationValue = txtequipmentdepreciatedvalue.Text
                        .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                        .RoomLocation = ""
                        .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                        'CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).SelectedItem.value
                        .AccountablePerson = ""
                        .SalvageValue = txtSalvageValue.Text
                        .UsefulLife = txtUsefulLife.Text
                    End With

                    info_id = objEquipInfo.save()
                    objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)


                    Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details
                    With objEquipDtl
                        .EquipmentId = 0
                        .EquipInfoId = info_id
                        .Property_Dtl_ID = PropDtl_ID
                        .MarketValue = txtEMarketValue.Text
                        .Condition = ""

                        Dim location As String

                        If String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                            location = "Bay-" & txtEquipmentBay.Text
                        ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                            location = "Column-" & txtEquipmentColumn.Text
                        ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                            location = "Floor-" & txtEquipmentFloor.Text
                        ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                            location = "Room-" & txtEquipmentRoom.Text
                        ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                            location = "Shelves-" & txtEquipmentShelves.Text
                        ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                            location = "Rack-" & txtEquipmentRack.Text
                        ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) Then
                            location = "Bin-" & txtEquipmentBin.Text
                        End If
                        .Location = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                        .Status = "Accepted"
                        .WarehouseID = drpEquipmentWarehouse.SelectedValue
                        Dim drp As DropDownList
                        drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtEquip"), DropDownList)

                        If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                            .BuildingId = 0
                        Else
                            .BuildingId = drp.SelectedValue
                        End If

                        .MaintenanceContactNo = txtContractor.Text
                        .MaintenanceContactPerson = txtContactPerson.Text
                        .MaintenanceContractor = txtCellphoneNo.Text
                    End With
                    objEquipDtl.save()



                Next

                Dim Prop_Ledger As New t_PropertyLedger

                With Prop_Ledger
                    .Ledger_ID = 0
                    .PropertyNo = ""
                    .SerialNo = ""
                    .Trans_Type = "Manual Entry"
                    .dDate = txtEAcqDate.Text
                    .Ref = ""
                    .AccountablePerson = ""
                    .Department = 0
                    .Position = ""
                    .AcceptedBy = ""
                    .InspectedBy = ""
                    .Item_ID = hdnItemNo.Value
                    .DebitQty = txtEquipmentQuantity.Text
                    .DebitCost = CType(txtEAcqCost.Text, Decimal) * txtEquipmentQuantity.Text
                    .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)
                    .CreditQty = "0"
                    .CreditUnit = "-"
                    .CreditCost = "0.00"
                    .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)

                    Dim Eqty As Integer
                    Dim Eqbalance As Decimal
                    Dim dtledger As New DataTable

                    dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                    If dtledger.Rows.Count = 0 Then
                        Eqty = 0
                        Eqbalance = 0.0
                    Else
                        Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                        Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                    End If
                    .BalanceQty = Eqty + 1
                    .BalanceCost = CType(txtEAcqCost.Text, Decimal) + CType(Eqbalance, Decimal)
                End With
                Prop_Ledger.save()



                btnSave.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                multiviewselected()
                loadEquipmentList()
                loadEquipmentInformation()
                loadEquipmentInformation_from_drpName()
                loadEquipmentLedger()
            End If
        'End If
    End Sub
    Public Sub Edit()
        If txtName.Text = "" Or txtequipmentdesciption.Text = "" Or txtUsefulLife.Text = "" Or txtDepreciatedRate.Text = "" Or txtEAcqCost.Text = "" Or txtequipmentdepreciatedvalue.Text = "" Or txtSalvageValue.Text = "" Or txtEMarketValue.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")

        Else
            If Not IsNumeric(txtDepreciatedRate.Text) Or Not IsNumeric(txtEAcqCost.Text) Or Not IsNumeric(txtequipmentdepreciatedvalue.Text) Or Not IsNumeric(txtSalvageValue.Text) Or Not IsNumeric(txtEMarketValue.Text) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
            Else
                If drpInstalledAtBuilding.SelectedItem.Text = "" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please select the Building where the property is located.")
                Else
                    Try
                        Dim objDerived As New DerivedDal
                        objDerived.conStr = objDerived.DbaseConnect()

                        objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", hf_EquipInfoId.Value)
                        objDerived.cmd.Parameters.AddWithValue("@PowerInput", txtequipmentpowerinput.Text)
                        objDerived.cmd.Parameters.AddWithValue("@Dimension", txtequipmentdimension.Text)
                        objDerived.cmd.Parameters.AddWithValue("@Model", txtequipmentmodel.Text)
                        objDerived.cmd.Parameters.AddWithValue("@Warranty", txtequipmentwaranty.Text)
                        objDerived.cmd.Parameters.AddWithValue("@NoYears", txtNoYears.Text)
                        objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtequipmentdepreciatedvalue.Text.Replace(",", ""))
                        objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", txtDepreciatedRate.Text)
                        objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtUsefulLife.Text)
                        objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtSalvageValue.Text.Replace(",", ""))
                        objDerived.cmd.Parameters.AddWithValue("@Specification", txtSpecification.Text)

                        objDerived.cmd.Parameters.AddWithValue("@EquipmentId", hf_EquipmentId.Value)
                        objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", txtContractor.Text)
                        objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", txtContactPerson.Text)
                        objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", txtCellphoneNo.Text)
                        'objDerived.cmd.Parameters.AddWithValue("@Buildingid", drpInstalledAtBuilding.SelectedItem.Value)
                        objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtEMarketValue.Text.Replace(",", ""))

                        objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", hf_PropertyDetai_ID.Value)
                        objDerived.cmd.Parameters.AddWithValue("@SerialNo", txtequipmentSerialNo.Text)

                        objDerived.cmd.Parameters.AddWithValue("@Property_ID", hf_Property_ID.Value)
                        objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtEAcqDate.Text)
                        objDerived.cmd.Parameters.AddWithValue("@Cost", txtEAcqCost.Text.Replace(",", ""))
                        objDerived.cmd.Parameters.AddWithValue("@Qty", txtEquipmentQuantity.Text)


                        objDerived.cmd.Parameters.AddWithValue("@Item_ID", hf_Item_ID.Value)
                        objDerived.cmd.Parameters.AddWithValue("@Unit_ID", drpUnit.SelectedItem.Value)




                        objDerived.Execute("AMS.sp_Edit_Equipment_Encoding", CommandType.StoredProcedure)



                        Dim dt1 As New DataTable
                        dt1 = objDerived.GetDataTable("SELECT b.SerialNo, b.PropertyNo, AMS.TbEquipment_Dtl.Buildingid, AMS.TbEquipment_Dtl.Location, AMS.TbEquipment_Dtl.EquipmentId " &
                                                " FROM AMS.Property as a INNER JOIN " &
                                                " AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID INNER JOIN " &
                                                " AMS.TbEquipment_Dtl INNER JOIN " &
                                                " AMS.TbEquipment_Info as c ON AMS.TbEquipment_Dtl.EquipInfoId = c.EquipInfoId ON b.SerialNo = c.SerialNo " &
                                                " where a.Item_ID=" & hdnItemNo.Value & "", CommandType.Text)


                        For i As Integer = 0 To dt1.Rows.Count - 1
                            objDerived.GetRecords("UPDATE AMS.Property_Dtl SET PropertyNo = '" _
                                                                                            & CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text &
                                                                             "',SerialNo='" & CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text &
                                                                             "' WHERE PropertyNo = '" & dt1.Rows(i).Item("PropertyNo").ToString & "'", CommandType.Text)

                            objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET SerialNo='" & CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text &
                                                                            "' WHERE SerialNo = '" & dt1.Rows(i).Item("SerialNo").ToString & "'", CommandType.Text)

                            Dim drp As DropDownList
                            Dim drpval As Integer

                            drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtEquip"), DropDownList)

                            If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                                drpval = 0
                            Else
                                drpval = drp.SelectedValue
                            End If

                            objDerived.GetRecords("UPDATE AMS.TbEquipment_Dtl SET Buildingid = '" & drpval & "', Location='" & CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text & "' WHERE EquipmentId = '" & dt1.Rows(i).Item("EquipmentId").ToString & "'", CommandType.Text)

                        Next
                        Dim PropHdr_ID As Integer
                        PropHdr_ID = objDerived.GetValue("select Property_ID from AMS.Property WHERE Item_ID='" & hdnItemNo.Value & "'", CommandType.Text)

                        For i As Integer = dt1.Rows.Count To grdPropertyInfo.Rows.Count - 1

                            Dim Prop_Dtl As New t_property_dtl
                            With Prop_Dtl
                                .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                                .Property_ID = PropHdr_ID
                                .Issued = False
                                .Repair = False
                                .Dispose = False
                                .DisposeDate = "1/1/1900"
                                .IsInspectionForDisposal = False
                                .InspectionDate = txtEAcqDate.Text
                                .F_ID = 1
                                .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                                .Barcode = " "
                                .Amount = CType(txtEAcqCost.Text, Decimal)
                                .Status = "Accepted"
                                .Details = txtSpecification.Text
                                .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                                .AccountablePerson = ""
                                .Function_ID = 86
                            End With

                            Dim PropDtl_ID As Integer
                            PropDtl_ID = Prop_Dtl.save()

                            objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtEMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

                            Dim info_id As Integer
                            Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info

                            With objEquipInfo
                                .EquipInfoId = 0
                                .AIRDtl_ID = 0
                                .IsAccepted = True
                                .Property_Dtl_ID = PropDtl_ID
                                .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text 'txtMachineryFloorLocation.Text
                                .Name = txtName.Text
                                .Description = txtequipmentdesciption.Text
                                .PowerInput = txtequipmentpowerinput.Text
                                .Dimension = txtequipmentdimension.Text
                                .AreaCapacity = txtequipmentareacapacity.Text
                                .Model = txtequipmentmodel.Text
                                .Warranty = txtequipmentwaranty.Text
                                .Specification = txtSpecification.Text
                                .DepreciationRate = lblequipmentdepreciatedRate.Text
                                .DepreciationValue = txtequipmentdepreciatedvalue.Text
                                .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                                .RoomLocation = ""
                                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                                'CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).SelectedItem.value
                                .AccountablePerson = ""
                                .SalvageValue = txtSalvageValue.Text
                                .UsefulLife = txtUsefulLife.Text
                                .NoYears = txtNoYears.Text
                            End With



                            info_id = objEquipInfo.save()
                            objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

                            Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details
                            With objEquipDtl
                                .EquipmentId = 0
                                .EquipInfoId = info_id
                                .Property_Dtl_ID = PropDtl_ID
                                .MarketValue = txtEMarketValue.Text
                                .Condition = ""

                                'Dim location As String

                                'If String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                                '    location = "Bay-" & txtEquipmentBay.Text
                                'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                                '    location = "Column-" & txtEquipmentColumn.Text
                                'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                                '    location = "Floor-" & txtEquipmentFloor.Text
                                'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                                '    location = "Room-" & txtEquipmentRoom.Text
                                'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                                '    location = "Shelves-" & txtEquipmentShelves.Text
                                'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                                '    location = "Rack-" & txtEquipmentRack.Text
                                'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) Then
                                '    location = "Bin-" & txtEquipmentBin.Text
                                'End If

                                Dim location As String = ""

                                If Not String.IsNullOrEmpty(txtEquipmentBay.Text) Then
                                    location = "Bay-" & txtEquipmentBay.Text
                                ElseIf Not String.IsNullOrEmpty(txtEquipmentColumn.Text) Then
                                    location = "Column-" & txtEquipmentColumn.Text
                                ElseIf Not String.IsNullOrEmpty(txtEquipmentFloor.Text) Then
                                    location = "Floor-" & txtEquipmentFloor.Text
                                ElseIf Not String.IsNullOrEmpty(txtEquipmentRoom.Text) Then
                                    location = "Room-" & txtEquipmentRoom.Text
                                ElseIf Not String.IsNullOrEmpty(txtEquipmentShelves.Text) Then
                                    location = "Shelves-" & txtEquipmentShelves.Text
                                ElseIf Not String.IsNullOrEmpty(txtEquipmentRack.Text) Then
                                    location = "Rack-" & txtEquipmentRack.Text
                                ElseIf Not String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                                    location = "Bin-" & txtEquipmentBin.Text
                                End If
                                .Location = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                                .Status = "Accepted"
                                .WarehouseID = drpEquipmentWarehouse.SelectedValue
                                Dim drp As DropDownList
                                drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtEquip"), DropDownList)
                                If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                                    .BuildingId = 0
                                Else
                                    .BuildingId = drp.SelectedValue
                                End If
                                .MaintenanceContactNo = txtContractor.Text
                                .MaintenanceContactPerson = txtContactPerson.Text
                                .MaintenanceContractor = txtCellphoneNo.Text

                            End With
                            objEquipDtl.save()



                        Next




                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                        btnSave.Text = "EDIT"
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If

            End If
        End If

    End Sub
    Protected Sub ddSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        multiviewselected()
    End Sub
    Public Sub loadUnit()
        Dim dt As New datatable
        dt = objDerived.getdatatable("select Unit_ID,Description  From ams.m_Unit as a order by Description", commandtype.text)
        drpUnit.datasource = dt
        drpUnit.DataTextField = ("Description")
        drpUnit.DataValueField = ("Unit_ID")
        drpUnit.DataBind()

        drpMilitaryEquipmentUnit.datasource = dt
        drpMilitaryEquipmentUnit.DataTextField = ("Description")
        drpMilitaryEquipmentUnit.DataValueField = ("Unit_ID")
        drpMilitaryEquipmentUnit.DataBind()
    End Sub

    Public Sub loadwarehouse()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("select warehouse_id,wname From ams.loc_warehouse", CommandType.Text)
        drpEquipmentWarehouse.DataTextField = ("wname")
        drpEquipmentWarehouse.DataValueField = ("warehouse_id")
        drpEquipmentWarehouse.datasource = dt
        drpEquipmentWarehouse.databind()

    End Sub


    Protected Sub drpName_SelectedIndexChanged(sender As Object, e As EventArgs)
        loadEquipmentInformation_from_drpName()
        loadEquipmentLedger()

    End Sub

    Protected Sub drpMilitaryEquipmentName_SelectedIndexChanged(sender As Object, e As EventArgs)
        loadEquipmentInformation_from_drpMilitaryName()
        loadEquipmentLedger()

    End Sub


    Protected Sub loadEquipmentInformation_from_drpMilitaryName()
        Dim CYear As String = "CY" & Year(txtdate.text)
        Dim itemid As String
        loadUnit()
        loadwarehouse()
        LoadBuildings()
        LoadMilitaryEquipDTL()
        If drpMilitaryEquipmentName.text = "" Then

            itemid = "0"
        Else
            itemid = drpMilitaryEquipmentName.selectedvalue
        End If

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadEquipDTL()
        Else

            hdnItemNo.value = itemid
            hdnGAId.value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & HDnItemNo.value, CommandType.Text)
            txtMilitaryEquipmentdescription.Text = dt.Rows(0).Item("description").ToString
            txtMilitaryEquipmentFrame.Text = objDerived.GetValue("select e.Frame from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentManufacturer.Text = objDerived.GetValue("select e.Manufacturer from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentColor.Text = objDerived.GetValue("select e.Color from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentCaliber.Text = objDerived.GetValue("select e.Caliber from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentCapacityExtended.Text = objDerived.GetValue("select e.Capacity from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentBarrel.Text = objDerived.GetValue("select e.Barrel from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentSights.Text = objDerived.GetValue("select e.Sights from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)



            'txtUsefulLife.Text = ""
            'txtSalvageValue.Text = FormatNumber(0, 2)
            'txtSalvageValue.Text = ""
            'Session("useful_life") = 0
            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("[AMS].[sp_View_Encoding] 'OfficeEquipment','" & itemid & "'", CommandType.Text)
            If dt1.Rows.Count > 0 Then

            End If



            drpUnit.items.FindByValue(dt.Rows(0).Item(9)).Selected = True
            btnMilitaryEquipmentSave.enabled = True
            btnMilitaryEquipmentCancel.enabled = True

        End If
    End Sub


    Protected Sub loadEquipmentInformation_from_drpName()
        Dim CYear As String = "CY" & Year(txtdate.text)
        Dim itemid As String
        loadUnit()
        loadwarehouse()
        LoadBuildings()

        If drpName.text = "" Then

            itemid = "0"
        Else
            itemid = drpName.selectedvalue
        End If

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadEquipDTL()
        Else

            hdnItemNo.value = itemid
            hdnGAId.value = objDerived.getvalue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & HDnItemNo.value, Commandtype.text)
            txtName.Text = dt.Rows(0).Item("Name").ToString
            txtequipmentdesciption.Text = dt.Rows(0).Item("description").ToString
            'txtequipmentpowerinput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtequipmentdimension.Text = objDerived.GetValue("select e.Dimension from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtequipmentareacapacity.Text = objDerived.GetValue("select e.AreaCapacity from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtequipmentmodel.Text = objDerived.GetValue("select e.Model from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtequipmentwaranty.Text = objDerived.GetValue("select e.Warranty from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtSpecification.Text = objDerived.GetValue("select e.Specification from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtEAcqDate.text = objDerived.GetValue("select c.Property_Date from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtEAcqCost.text = objDerived.GetValue("select c.Cost from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtEMarketValue.text = dt.Rows(0).Item(CYear).ToString
            'Dim DA As DateTime
            'DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")
            'txtNoYears.Text = " "
            'txtequipmentdepreciatedvalue.Text = FormatNumber(0, 2)
            'lblequipmentdepreciatedRate.Text = " "
            'lblequipmentdepreciatedRate.readonly = False


            '''--------------------location
            Dim location As String
            location = objDerived.GetValue("select Location from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Dtl  as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)
            If location IsNot Nothing Then
                Dim locationsplit As String() = location.Split("-")
                If location.Contains("Bay") Then
                    txtEquipmentBay.text = locationsplit(1)
                ElseIf location.Contains("Column") Then
                    txtEquipmentColumn.text = locationsplit(1)
                ElseIf location.Contains("Floor") Then
                    txtEquipmentFloor.text = locationsplit(1)
                ElseIf location.Contains("Room") Then
                    txtEquipmentRoom.text = locationsplit(1)
                ElseIf location.Contains("Shelves") Then
                    txtEquipmentShelves.text = locationsplit(1)
                ElseIf location.Contains("Rack") Then
                    txtEquipmentRack.text = locationsplit(1)
                ElseIf location.Contains("Bin") Then
                    txtEquipmentBin.text = locationsplit(1)
                End If

                Dim warehouse As String
                warehouse = objDerived.GetValue("select warehouseid from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Dtl  as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

                drpEquipmentWarehouse.SelectedValue = warehouse


                Dim dt1 As New DataTable
                dt1 = objDerived.GetDataTable("[AMS].[sp_View_Encoding] 'OfficeEquipment','" & itemid & "'", CommandType.Text)
                If dt1.Rows.Count > 0 Then
                    txtequipmentpowerinput.Text = dt1.Rows(0).Item("PowerInput").ToString
                    txtequipmentmodel.Text = dt1.Rows(0).Item("Model").ToString
                    txtequipmentSerialNo.Text = dt1.Rows(0).Item("SerialNo").ToString
                    drpUnit.SelectedValue = dt1.Rows(0).Item("Unit_ID").ToString
                    txtEquipmentQuantity.Text = dt1.Rows(0).Item("DebitQty").ToString
                    txtequipmentwaranty.Text = dt1.Rows(0).Item("Warranty").ToString
                    'drpInstalledAtBuilding.SelectedValue = dt1.Rows(0).Item("Buildingid").ToString
                    txtequipmentdimension.Text = dt1.Rows(0).Item("Dimension").ToString
                    txtContractor.Text = dt1.Rows(0).Item("MaintenanceContractor").ToString
                    txtContactPerson.Text = dt1.Rows(0).Item("MaintenanceContactPerson").ToString
                    txtCellphoneNo.Text = dt1.Rows(0).Item("MaintenanceContactNo").ToString
                    txtEAcqDate.Text = Convert.ToDateTime(dt1.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
                    txtEAcqCost.Text = Val(dt1.Rows(0).Item("Cost").ToString).ToString("n2")
                    txtDepreciatedRate.Text = dt1.Rows(0).Item("DepreciationRate").ToString
                    txtequipmentdepreciatedvalue.Text = Val(dt1.Rows(0).Item("DepreciationValue").ToString).ToString("n2")
                    txtEMarketValue.Text = Val(dt1.Rows(0).Item("MarketValue").ToString).ToString("n2")
                    txtNoYears.Text = dt1.Rows(0).Item("NoYears").ToString
                    txtUsefulLife.Text = dt1.Rows(0).Item("UsefulLife").ToString
                    txtSalvageValue.Text = Val(dt1.Rows(0).Item("SalvageValue").ToString).ToString("n2")
                    txtSpecification.Text = dt1.Rows(0).Item("Specification").ToString


                    hf_EquipInfoId.Value = dt1.Rows(0).Item("EquipInfoId").ToString
                    hf_EquipmentId.Value = dt1.Rows(0).Item("EquipmentId").ToString
                    hf_PropertyDetai_ID.Value = dt1.Rows(0).Item("PropertyDetai_ID").ToString
                    hf_Property_ID.Value = dt1.Rows(0).Item("Property_ID").ToString
                    hf_Item_ID.Value = dt1.Rows(0).Item("Item_ID").ToString
                End If


            End If


            '    txtUsefulLife.Text = ""
            'txtSalvageValue.Text = FormatNumber(0, 2)
            'txtSalvageValue.Text = ""
            'Session("useful_life") = 0

            drpUnit.items.FindByValue(dt.Rows(0).Item(9)).Selected = True
            btnSave.enabled = True
            btnCancel.Enabled = True
        End If
    End Sub

    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "EQUIPMENT"
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
        grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)
    End Sub

    Protected Sub grdLedger1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

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

    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)



        'If (e.Row.RowType = DataControlRowType.DataRow) Then

        '    Dim ddlCountries As DropDownList = CType(e.Row.FindControl("drpInstalledAtEquip"), DropDownList)
        '    ddlCountries.DataSource = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        '    ' ddlCountries.DataSource = dtDepartment
        '    ddlCountries.DataTextField = ("Name")
        '    ddlCountries.DataValueField = ("BuildingId")
        '    ddlCountries.DataBind()

        '    'Add Default Item in the DropDownList
        '    ddlCountries.Items.Insert(0, New ListItem("N/A"))
        '    ddlCountries.Items.Insert(0, New ListItem("Field"))




        '    Dim drp As DropDownList
        '    Dim textPN As TextBox
        '    Dim textSN As TextBox
        '    Dim textL As TextBox


        '    Dim dt1 As New DataTable
        '    dt1 = objDerived.GetDataTable("SELECT b.SerialNo, b.PropertyNo, AMS.TbEquipment_Dtl.Buildingid, AMS.TbEquipment_Dtl.Location, AMS.TbEquipment_Dtl.EquipmentId " &
        '                                        " FROM AMS.Property as a INNER JOIN " &
        '                                        " AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID INNER JOIN " &
        '                                        " AMS.TbEquipment_Dtl INNER JOIN " &
        '                                        " AMS.TbEquipment_Info as c ON AMS.TbEquipment_Dtl.EquipInfoId = c.EquipInfoId ON b.SerialNo = c.SerialNo " &
        '                                        " where a.Item_ID=" & hdnItemNo.Value & "", CommandType.Text)

        '    drp = CType(e.Row.FindControl("drpInstalledAtEquip"), DropDownList)
        '    textPN = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
        '    textSN = CType(e.Row.FindControl("txtSerialNoOfEquip"), TextBox)
        '    textL = CType(e.Row.FindControl("txtPIFloorLocation"), TextBox)



        '    If counts > dt1.Rows.Count - 1 Then

        '    Else
        '        textSN.Text = dt1.Rows(counts).Item("SerialNo").ToString
        '        textPN.Text = dt1.Rows(counts).Item("PropertyNo").ToString
        '        drp.SelectedValue = dt1.Rows(counts).Item("Buildingid").ToString
        '        textL.Text = dt1.Rows(counts).Item("Location").ToString

        '    End If


        '    counts = counts + 1
        'End If
        'ViewState("Customers") = DirectCast(grdPropertyInfo.DataSource, DataTable)
        'Optimize code

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim ddlCountries As DropDownList = CType(e.Row.FindControl("drpInstalledAtEquip"), DropDownList)
            ddlCountries.DataSource = objDerived.GetDataTable("SELECT BuildingId, BuildingName + ' - ' + Address AS Name FROM ams.TbBuilding_Dtl AS a INNER JOIN ams.Property_Dtl AS b ON a.Property_Dtl_ID = b.PropertyDetai_ID ORDER BY BuildingName", CommandType.Text)
            ddlCountries.DataTextField = "Name"
            ddlCountries.DataValueField = "BuildingId"
            ddlCountries.DataBind()

            'Add Default Items in the DropDownList
            ddlCountries.Items.Insert(0, New ListItem("Field"))
            ddlCountries.Items.Insert(0, New ListItem("N/A"))

            Dim drp As DropDownList = CType(e.Row.FindControl("drpInstalledAtEquip"), DropDownList)
            Dim textPN As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
            Dim textSN As TextBox = CType(e.Row.FindControl("txtSerialNoOfEquip"), TextBox)
            Dim textL As TextBox = CType(e.Row.FindControl("txtPIFloorLocation"), TextBox)

            Dim dt1 As DataTable = objDerived.GetDataTable("SELECT b.SerialNo, b.PropertyNo, AMS.TbEquipment_Dtl.Buildingid, AMS.TbEquipment_Dtl.Location, AMS.TbEquipment_Dtl.EquipmentId " &
                                                                    " FROM AMS.Property AS a INNER JOIN " &
                                                                    " AMS.Property_Dtl AS b ON a.Property_ID = b.Property_ID INNER JOIN " &
                                                                    " AMS.TbEquipment_Dtl INNER JOIN " &
                                                                    " AMS.TbEquipment_Info AS c ON AMS.TbEquipment_Dtl.EquipInfoId = c.EquipInfoId ON b.SerialNo = c.SerialNo " &
                                                                    " WHERE a.Item_ID=" & hdnItemNo.Value, CommandType.Text)

            If counts < dt1.Rows.Count Then
                textSN.Text = dt1.Rows(counts)("SerialNo").ToString()
                textPN.Text = dt1.Rows(counts)("PropertyNo").ToString()
                drp.SelectedValue = dt1.Rows(counts)("Buildingid").ToString()
                textL.Text = dt1.Rows(counts)("Location").ToString()
                counts += 1
            End If
        End If
        ViewState("Customers") = TryCast(grdPropertyInfo.DataSource, DataTable)
    End Sub

    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        For Each row As GridViewRow In grdPropertyInfo.Rows

            Dim _str As String = TryCast(row.FindControl("txtPropertyNo"), TextBox).Text
            ' msgbox(_str)
        Next
    End Sub
    Protected Sub btnMilitaryEquipmentaddpropertyinfo_Click(sender As Object, e As EventArgs)
        Dim dt As New DataTable()
        ' dt.Columns.AddRange(New DataColumn(1) {New DataColumn("Name"), New DataColumn("Country")})
        ' dt = ViewState("Customers")
        If txtMilitaryEquipmentQuantity.text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
        Else
            For i As Integer = 0 To txtMilitaryEquipmentQuantity.text - 1
                dt.Rows.Add()
            Next
            ViewState("Customers") = dt
            Me.BindGrid()

            ModalPopupExtender2.show()
        End If


    End Sub

    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)
        'Dim dt As New DataTable()
        '' dt.Columns.AddRange(New DataColumn(1) {New DataColumn("Name"), New DataColumn("Country")})
        '' dt = ViewState("Customers")
        'If txtEquipmentQuantity.text = "" Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
        'Else
        '    For i As Integer = 0 To txtEquipmentQuantity.text - 1
        '        dt.Rows.Add()
        '    Next
        '    ViewState("Customers") = dt
        '    Me.BindGrid()

        '    ModalPopupExtender2.show()
        'End If



        If btnSave.Text = "SAVE" Then

            If txtEquipmentQuantity.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
            Else
                Dim dt As New DataTable()
                dt = DirectCast(grdPropertyInfo.DataSource, DataTable)

                'If grdPropertyInfo.Rows.Count = 0 Then
                dt = New DataTable
                For i As Integer = 0 To txtEquipmentQuantity.Text - 1
                    dt.Rows.Add()
                    ViewState("Customers") = dt
                Next


                Me.BindGrid()

                ModalPopupExtender2.Show()
                'Else
                '    ModalPopupExtender2.Show()
                'End If

                ' dt.Columns.AddRange(New DataColumn(1) {New DataColumn("Name"), New DataColumn("Country")})
                ' dt = ViewState("Customers")

            End If

        ElseIf btnSave.Text = "EDIT" Or btnSave.Text = "UPDATE" Then
            counts = 0
            If txtEquipmentQuantity.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
            Else



                Dim dt As New DataTable()
                dt = DirectCast(grdPropertyInfo.DataSource, DataTable)
                dt = New DataTable

                For i As Integer = 0 To txtEquipmentQuantity.Text - 1
                    dt.Rows.Add()

                    ViewState("Customers") = dt

                Next


                Me.BindGrid()



                ModalPopupExtender2.Show()

            End If
        End If

    End Sub
    Protected Sub BindGrid()
        grdPropertyInfo.DataSource = DirectCast(ViewState("Customers"), DataTable)
        grdPropertyInfo.DataBind()
    End Sub

    Public Sub LoadBuildings()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        drpInstalledAtBuilding.datasource = dt
        drpInstalledAtBuilding.DataTextField = ("Name")
        drpInstalledAtBuilding.DataValueField = ("BuildingId")
        drpInstalledAtBuilding.DataBind()
        drpInstalledAtBuilding.Items.Insert(0, New ListItem("N/A"))
    End Sub
    Protected Sub txtEMarketValue_TextChanged(sender As Object, e As EventArgs) Handles txtEMarketValue.TextChanged

    End Sub
    Protected Sub drpInstalledAtBuilding_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpInstalledAtBuilding.SelectedIndexChanged

    End Sub
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ModalPopupExtender1.Hide()
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else
            btnSave.Text = "UPDATE"
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
    Protected Sub drpInstalledAtMac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim drp As DropDownList
        Dim text As TextBox
        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtEquip"), DropDownList)
            If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = True
                text.Text = ""
            Else
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = False

                Dim drp1 As DropDownList
                drp1 = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtEquip"), DropDownList)

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("select (case when Address IS NULL then '' else Address end) + " _
                                             & " (case when Barangay IS NULL then  '' else ', ' + Barangay end) + " _
                                             & "  (case when Area1 IS NULL then  '' else  ', ' + Area1 end) " _
                                             & "  as Adress from AMS.TbBuilding_Dtl where BuildingId=" & drp1.SelectedValue & "", CommandType.Text)
                If dt.Rows.Count > 0 Then
                    text.Text = dt.Rows(0).Item(0)
                Else
                    text.Text = ""
                End If
            End If
        Next
        ModalPopupExtender2.Show()
    End Sub
    Protected Sub txtPropertyNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim text As TextBox
        If btnSave.Text = "SAVE" Then

            For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPropertyNo"), TextBox)
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT a.Item_ID, b.PropertyNo FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID WHERE  (b.PropertyNo = '" & text.Text & "')", CommandType.Text)
                If dt.Rows.Count > 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is already exist!")
                    text.Text = ""
                Else

                End If
            Next

        ElseIf btnSave.Text = "EDIT" Then

            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("SELECT b.SerialNo, b.PropertyNo, AMS.TbEquipment_Dtl.Buildingid, AMS.TbEquipment_Dtl.Location, AMS.TbEquipment_Dtl.EquipmentId " &
                                                " FROM AMS.Property as a INNER JOIN " &
                                                " AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID INNER JOIN " &
                                                " AMS.TbEquipment_Dtl INNER JOIN " &
                                                " AMS.TbEquipment_Info as c ON AMS.TbEquipment_Dtl.EquipInfoId = c.EquipInfoId ON b.SerialNo = c.SerialNo " &
                                                " where a.Item_ID=" & hdnItemNo.Value & "", CommandType.Text)

            For i As Integer = dt1.Rows.Count To grdPropertyInfo.Rows.Count - 1
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPropertyNo"), TextBox)
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT a.Item_ID, b.PropertyNo FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID WHERE  (b.PropertyNo = '" & text.Text & "')", CommandType.Text)
                If dt.Rows.Count > 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is already exist!")
                    text.Text = ""
                Else

                End If
            Next

        End If
        ModalPopupExtender2.Show()
    End Sub
End Class
