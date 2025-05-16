Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Drawing
Partial Class t_sub_inventory_capital_outlay
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim image As New Image
    Dim obj As New BaseClasses.Items
    Public dtStock As New DataTable
    Dim objx As New AccessRule

#Region "property"
    Private Property dtEquipments() As DataTable
        Get
            Return CType(Session("dtEquipments"), DataTable)

        End Get
        Set(ByVal value As DataTable)
            Session("dtEquipments") = value
        End Set
    End Property
    Private Property dtMachines() As DataTable
        Get
            Return CType(Session("dtMachines"), DataTable)

        End Get
        Set(ByVal value As DataTable)
            Session("dtMachines") = value
        End Set
    End Property
    Private Property dtAccount() As DataTable
        Get
            Return CType(Session("dtAccount"), DataTable)

        End Get
        Set(ByVal value As DataTable)
            Session("dtAccount") = value
        End Set
    End Property
#End Region
#Region "GridDesign"
    Public Function createdatatable16(ByVal row As Integer) As DataTable
        Try
            'Here 1
            Dim dt As New DataTable()
            Dim dr As DataRow
            Dim myDataColumn As DataColumn
            myDataColumn = New DataColumn()
            dt.Columns.Add("Item_Code", GetType(String))
            dt.Columns.Add("Title", GetType(String))
            dt.Columns.Add("Brand", GetType(String))
            dt.Columns.Add("SerialNo", GetType(String))
            dt.Columns.Add("Noofdisc", GetType(String))
            dt.Columns.Add("Model", GetType(String))
            dt.Columns.Add("LicenceDuration", GetType(String))
            dt.Columns.Add("Property_Date", GetType(String))
            dt.Columns.Add("Cost", GetType(String))
            dt.Columns.Add("DepreciationRate", GetType(String))
            dt.Columns.Add("DepreciatedValue", GetType(String))
            dt.Columns.Add("MarketValue", GetType(String))
            dt.Columns.Add("NoofYears", GetType(String))
            dt.Columns.Add("Usefullife", GetType(String))
            dt.Columns.Add("SalvageValue", GetType(String))
            dt.Columns.Add("WarehouseID", GetType(Long))
            dt.Columns.Add("Bay", GetType(String))
            dt.Columns.Add("Column", GetType(String))
            dt.Columns.Add("Floor", GetType(String))
            dt.Columns.Add("Room", GetType(String))
            dt.Columns.Add("Shelves", GetType(String))
            dt.Columns.Add("Rack", GetType(String))
            dt.Columns.Add("Bin", GetType(String))
            dt.Columns.Add("Item_ID", GetType(Long))
            dt.Columns.Add("Property_ID", GetType(Long))
            dt.Columns.Add("PropertyDetai_ID", GetType(Long))
            dt.Columns.Add("IntangibleAssetInfoId", GetType(Long))
            dt.Columns.Add("IntangibleAssetID", GetType(Long))
            dt.Columns.Add("Ledger_ID", GetType(Long))

            For i As Integer = 0 To row
                dr = dt.NewRow
                dr("Item_Code") = DBNull.Value
                dr("Title") = DBNull.Value
                dr("Brand") = DBNull.Value
                dr("SerialNo") = DBNull.Value
                dr("Noofdisc") = DBNull.Value
                dr("Model") = DBNull.Value
                dr("LicenceDuration") = DBNull.Value
                dr("Property_Date") = DBNull.Value
                dr("Cost") = DBNull.Value
                dr("DepreciationRate") = DBNull.Value
                dr("DepreciatedValue") = DBNull.Value
                dr("MarketValue") = DBNull.Value
                dr("NoofYears") = DBNull.Value
                dr("Usefullife") = DBNull.Value
                dr("SalvageValue") = DBNull.Value
                dr("WarehouseID") = DBNull.Value
                dr("Bay") = DBNull.Value
                dr("Column") = DBNull.Value
                dr("Floor") = DBNull.Value
                dr("Room") = DBNull.Value
                dr("Shelves") = DBNull.Value
                dr("Rack") = DBNull.Value
                dr("Bin") = DBNull.Value
                dr("Item_ID") = DBNull.Value
                dr("Property_ID") = DBNull.Value
                dr("PropertyDetai_ID") = DBNull.Value
                dr("IntangibleAssetInfoId") = DBNull.Value
                dr("IntangibleAssetID") = DBNull.Value
                dr("Ledger_ID") = DBNull.Value

            Next

            Return dt
        Catch ex As Exception

        End Try


    End Function
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
        dt.Columns.Add("DeclaredOwner", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Barangay", GetType(String))
        dt.Columns.Add("Area", GetType(String))
        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(String))
        dt.Columns.Add("MarketValue", GetType(String))
        dt.Columns.Add("VehicleType", GetType(String))
        dt.Columns.Add("VehicleMake", GetType(String))
        dt.Columns.Add("Warranty", GetType(String))
        dt.Columns.Add("Title", GetType(String))
        dt.Columns.Add("Author", GetType(String))



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
        dt.Columns.Add("ServiceFloors", GetType(String))
        dt.Columns.Add("MachineLocation", GetType(String))
        dt.Columns.Add("MaintenanceContractor", GetType(String))
        dt.Columns.Add("MaintenanceContactPerson", GetType(String))
        dt.Columns.Add("MaintenanceContactNo", GetType(String))
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("FloorLocation", GetType(String))
        dt.Columns.Add("RoomLocation", GetType(String))
        dt.Columns.Add("Warranty", GetType(String))



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
            dr("ServiceFloors") = DBNull.Value
            dr("MachineLocation") = DBNull.Value
            dr("MaintenanceContractor") = DBNull.Value
            dr("MaintenanceContactPerson") = DBNull.Value
            dr("MaintenanceContactNo") = DBNull.Value
            dr("Name") = DBNull.Value
            dr("FloorLocation") = DBNull.Value
            dr("RoomLocation") = DBNull.Value
            dr("Warranty") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("Item_Code", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("item_particular_id", GetType(Long))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("description", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("PO_Date", GetType(Date))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("GA_ID", GetType(Long))
        dt.Columns.Add("Received_ID", GetType(Long))
        dt.Columns.Add("Received_Dtl_ID", GetType(Long))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("Property_Date", GetType(Date))
        dt.Columns.Add("AcquisitionCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        dt.Columns.Add("OwnerName", GetType(String))
        dt.Columns.Add("FullAddress", GetType(String))
        dt.Columns.Add("Barangay1", GetType(String))
        dt.Columns.Add("Area1", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Property_code") = DBNull.Value
            dr("Item_Code") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("item_particular_id") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("description") = DBNull.Value
            dr("SerialNo") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("Received_ID") = 0
            dr("Received_Dtl_ID") = DBNull.Value
            dr("Condition") = DBNull.Value
            dr("Location") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("Property_Date") = DBNull.Value
            dr("AcquisitionCost") = DBNull.Value
            dr("MarketValue") = DBNull.Value
            dr("OwnerName") = DBNull.Value
            dr("FullAddress") = DBNull.Value
            dr("Barangay1") = DBNull.Value
            dr("Area1") = DBNull.Value
            dr("Property_ID") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
#End Region
    Public Sub loadIntanSubClassification()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("Select SubClassificationID, SubclassificationName from dbo.tbl_SubClassification where ClassificationID = '13'", CommandType.Text)
        drpIntanSubClassification.DataSource = dt
        drpIntanSubClassification.DataTextField = "SubClassificationName"
        drpIntanSubClassification.DataValueField = "SubClassificationID"
        drpIntanSubClassification.Items.Clear()
        drpIntanSubClassification.DataBind()
    End Sub
    Public Sub LoadMachineInBuildings()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        drpMachineInstalledBuilding.DataSource = dt
        drpMachineInstalledBuilding.DataTextField = ("Name")
        drpMachineInstalledBuilding.DataValueField = ("BuildingId")
        drpMachineInstalledBuilding.DataBind()
        drpMachineInstalledBuilding.Items.Insert(0, New ListItem("N/A"))
        drpMachineInstalledBuilding.Items.Insert(0, New ListItem("N/A"))
    End Sub
    Public Sub loadMachineUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpMachineUnit.DataSource = dt
        drpMachineUnit.DataTextField = ("Description")
        drpMachineUnit.DataValueField = ("Unit_ID")
        drpMachineUnit.DataBind()
    End Sub
    Public Sub LoadOfficeEquipmentBuildings()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        drpOfficeEquipmentBuilding.DataSource = dt
        drpOfficeEquipmentBuilding.DataTextField = ("Name")
        drpOfficeEquipmentBuilding.DataValueField = ("BuildingId")
        drpOfficeEquipmentBuilding.DataBind()
        drpOfficeEquipmentBuilding.Items.Insert(0, New ListItem("N/A"))
    End Sub
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpbookUnit.DataSource = dt
        drpbookUnit.DataTextField = ("Description")
        drpbookUnit.DataValueField = ("Unit_ID")
        drpbookUnit.DataBind()
    End Sub
    Public Sub loadOfficeEquipmentUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpOfficeEquipmentUnit.DataSource = dt
        drpOfficeEquipmentUnit.DataTextField = ("Description")
        drpOfficeEquipmentUnit.DataValueField = ("Unit_ID")
        drpOfficeEquipmentUnit.DataBind()
    End Sub
    Public Sub loadwarehouse()
        Dim dt As New DataTable
        dt = obj.GetDataTable("Select warehouse_id, wname From ams.loc_warehouse", CommandType.Text)
        drpbookWarehouse.DataTextField = ("wname")
        drpbookWarehouse.DataValueField = ("warehouse_id")
        drpbookWarehouse.DataSource = dt
        drpbookWarehouse.DataBind()

    End Sub
    Public Sub loadBrgy()
        ddBrgy1.DataSource = objDerived.GetDataTable("Select * from dbo.tbl_Brgy_Invent", CommandType.Text)
        ddBrgy1.DataTextField = ("Brgy_Name")
        ddBrgy1.DataValueField = ("Brgy_ID")
        ddBrgy1.DataBind()
        ddBrgy1.Items.Insert(0, "Select")
    End Sub
    Public Sub loadwarehouseForIntangible()
        Dim dt As New DataTable
        dt = obj.GetDataTable("Select warehouse_id, wname From ams.loc_warehouse", CommandType.Text)
        drpIntanWarehouse.DataTextField = ("wname")
        drpIntanWarehouse.DataValueField = ("warehouse_id")
        drpIntanWarehouse.DataSource = dt
        drpIntanWarehouse.DataBind()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadDepartments()
            Classification_load()
            loadBrgy()
            loadIntanSubClassification()
        End If

    End Sub
    Protected Sub gvsearch_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

    End Sub
    Protected Sub grdocumentdetails_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdocumentdetails, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Public Sub multiviewselected()
        If drpClassification.selecteditem.text.contains("roads") Or drpClassification.selecteditem.text.contains("Roads") Then
        Else
            If drpGeneral_Account.SelectedItem.Value = 1060 Or drpGeneral_Account.SelectedItem.Value = 1062 Or drpGeneral_Account.SelectedItem.Value = 1067 Then
                Me.viewMultiDataGrid.SetActiveView(Me.viewLandGrid)
                Me.viewData.SetActiveView(Me.viewLandData)
                LoadLandMainGrid()
                enableFalseLand()
            ElseIf drpGeneral_Account.SelectedItem.Value = 1082 Or drpGeneral_Account.SelectedItem.Value = 1085 Then
                Me.viewMultiDataGrid.SetActiveView(Me.viewLandGrid)
                Me.viewData.SetActiveView(Me.viewBuildingData)
                LoadBuildingMainGrid()
            ElseIf drpGeneral_Account.SelectedItem.Value = 1124 Then
                Me.viewMultiDataGrid.SetActiveView(Me.viewBookGrid)
                Me.viewData.SetActiveView(Me.viewBooksData)
                loadBooksMainGrid()
                loadwarehouse()
                loadUnit()
            ElseIf drpGeneral_Account.SelectedItem.Value = 1127 Then
                Me.viewMultiDataGrid.SetActiveView(Me.viewMachineriesGrid)
                Me.viewData.SetActiveView(Me.viewMachineriesData)
                loadMachineryMainGrid()
                loadMachineUnit()
                LoadMachineInBuildings()
            ElseIf drpGeneral_Account.SelectedItem.Value = 1118 Then
                Me.viewMultiDataGrid.SetActiveView(Me.viewMachineriesGrid)
                Me.viewData.SetActiveView(Me.viewFunitureFixtureData)
            ElseIf drpGeneral_Account.SelectedItem.Value = 1222 Then
                loadIntanSubClassification()
                viewMultiDataGrid.SetActiveView(Me.vwGridViewIntangible)
                LoadIntangible()
                Me.viewData.SetActiveView(Me.vwIntangibleAsset)
                'Me.mvledger.SetActiveView(Me.vwledger)
            Else
                Me.viewMultiDataGrid.SetActiveView(Me.viewMachineriesGrid)
                Me.viewData.SetActiveView(Me.viewEquipmentData)
                LoadEquipmentMainGrid()
            End If


        End If

    End Sub
    Protected Sub LoadEquipmentMainGrid()
        ' for Equipments
        'Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)
        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Equipments] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_Equipment] '1082','" & drpGeneral_Account.SelectedValue & "'", CommandType.Text)

        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty.DataSource = createdatatable15(3)
            gvsearchproperty.DataBind()

            grdlistofEuipment.DataSource = createdatatable4A(3)
            grdlistofEuipment.DataBind()

            LoadEquipDTL()
            grdLedger.DataSource = createdatatableledger(10)
            grdLedger.DataBind()

        Else
            If drpClassification.selecteditem.text.contains("Office Equipment") Then
                mvEquipment.SetActiveView(Me.vwOfficeEquipment)
                loadOfficeEquipmentUnit()
                LoadOfficeEquipmentBuildings()
            ElseIf drpClassification.selecteditem.text.contains("Medical Equipment") Then
                mvEquipment.SetActiveView(Me.View1)
            Else
                '                mvEquipment.SetActiveView(Me.vwDefaultEquipment)
                mvEquipment.SetActiveView(Me.vwDefault)

            End If

            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

            loadEquipmentList()
            loadEquipmentInformation()
            loadEquipmentLedger()

        End If
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
    Protected Sub grdfurnitureandfixtures_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

    End Sub
    Protected Sub grdlistofEuipment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        'here 123
        'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_11022022_EQUIPMENT] '" _
                                            & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" _
                                            & gvsearchproperty.SelectedDataKey("Item_ID") & "','" _
                                            & drpGeneral_Account.SelectedItem.Value & "','" _
                                            & gvsearchproperty.SelectedDataKey("DeclaredOwner") & "','" _
                                            & gvsearchproperty.SelectedDataKey("Barangay") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
        End If
        grdlistofEuipment.PageIndex = e.NewPageIndex
        grdlistofEuipment.DataSource = dtAccount
        grdlistofEuipment.DataBind()
        grdlistofEuipment.SelectedIndex = 0
    End Sub
    Protected Sub grdlistofEuipment_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdlistofEuipment, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdlistofEuipment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub grdlistofEuipment_ondatabound(sender As Object, e As EventArgs)
        grdlistofEuipment.HeaderRow.Cells(0).Visible = False
        grdlistofEuipment.HeaderRow.Cells(1).Visible = False
        grdlistofEuipment.HeaderRow.Cells(4).Visible = False
        grdlistofEuipment.HeaderRow.Cells(8).Visible = False
        Dim row As New GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "Property No."
        cell.ColumnSpan = 1
        cell.rowspan = 2
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.rowspan = 2
        cell.Text = "NAME"
        row.Controls.Add(cell)


        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 2
        'cell.Text = "LOCATION"
        'row.Controls.Add(cell)


        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.ROWSPAN = 2
        cell.Text = "WARRANTY PERIOD"
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 3
        cell.Text = "MAINTENANCE"
        row.Controls.Add(cell)

        row.BackColor = ColorTranslator.FromHtml("#5c85d6")
        row.ForeColor = ColorTranslator.FromHtml("WHITE")
        grdlistofEuipment.HeaderRow.Parent.Controls.AddAt(0, row)

    End Sub
    Protected Sub grdfurnitureandfixtures_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdfurnitureandfixtures, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdfurnitureandfixtures_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub grdfurnitureandfixtures_ondatabound(sender As Object, e As EventArgs)
        grdfurnitureandfixtures.HeaderRow.Cells(0).Visible = False
        grdfurnitureandfixtures.HeaderRow.Cells(1).Visible = False
        grdfurnitureandfixtures.HeaderRow.Cells(4).Visible = False
        Dim row As New GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "ITEM CODE"
        cell.ColumnSpan = 1
        cell.rowspan = 2
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.rowspan = 2
        cell.Text = "NAME"
        row.Controls.Add(cell)


        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 2
        'cell.Text = "LOCATION"
        'row.Controls.Add(cell)


        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.ROWSPAN = 2
        cell.Text = "WARRANTY PERIOD"
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 3
        cell.Text = "MAINTENANCE"
        row.Controls.Add(cell)

        row.BackColor = ColorTranslator.FromHtml("#5c85d6")
        row.ForeColor = ColorTranslator.FromHtml("WHITE")
        grdfurnitureandfixtures.HeaderRow.Parent.Controls.AddAt(0, row)
    End Sub
    Protected Sub loadMachineryMainGrid()
        ' for Machinery
        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Machinery] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
        ' dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_MACHINERY] '1082'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_MACHINERY] '1082'", CommandType.Text)


        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty.DataSource = createdatatable15(3)
            gvsearchproperty.DataBind()

            grdpropertyListofmachinery.DataSource = createdatatable4A(3)
            grdpropertyListofmachinery.DataBind()

            LoadMachineryDTL()

            grdLedger.DataSource = createdatatableledger(10)
            grdLedger.DataBind()
        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

            loadMachineryList()
            loadMachineryInformation()
            loadMachineryLedger()
        End If
    End Sub
    Protected Sub loadMachineryLedger()
        ''here 1
        'lblHistoryDetails.Text = drpClassification.SelectedItem.Text
        btnmachineryLedger.CssClass = "Clicked"
        btnmachineryRepairs.CssClass = "Initial"
        btnmachineryDocattach.CssClass = "Initial"

        ' Me.mvledger.SetActiveView(Me.vwledger)

        If hdnItemNo.Value = "" Then
            'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)
        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        End If
        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtAccount.Rows.Count > 1 Then
            'btnLandEdit.Enabled = False
            'btnBuildingEdit.Enabled = False
            'btn_Edit_Road_and_Bridge.Enabled = False
            'btnEdit_Mechinery.Enabled = False
            'btn_Edit_Road.Enabled = False
        Else
            'btnLandEdit.Enabled = True
            'btnBuildingEdit.Enabled = True
            'btn_Edit_Road_and_Bridge.Enabled = True
            'btnEdit_Mechinery.Enabled = True
            'btn_Edit_Road.Enabled = True

        End If


        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If
        grdLedger.DataSource = dtAccount
        grdLedger.DataBind()
    End Sub
    Protected Sub loadEquipmentList() '[dbo].[SMSS_EquipmentList]
        '11232022
        ' dtEquipments = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        dtEquipments = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_11022022_EQUIPMENT] '" _
                                               & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" _
                                               & gvsearchproperty.SelectedDataKey("Item_ID") & "','" _
                                               & drpGeneral_Account.SelectedItem.Value & "','" _
                                               & gvsearchproperty.SelectedDataKey("DeclaredOwner") & "','" _
                                               & gvsearchproperty.SelectedDataKey("Barangay") & "'", CommandType.Text)
        If dtEquipments.Rows.Count > 1 Then

        Else
            ClearOfficeEquipment()
            ClearEquipment()
        End If

        If dtEquipments.Rows.Count < 4 Then
            dtEquipments.Merge(createdatatable4A(3 - dtEquipments.Rows.Count))
        End If
        grdlistofEuipment.DataSource = dtEquipments
        grdlistofEuipment.DataBind()
        grdlistofEuipment.SelectedIndex = 0

    End Sub
    Protected Sub loadEquipmentInformation()
        Dim dt As New DataTable
        ' dt = objDerived.GetDataTable("Select * from [dbo].[View_EquipmentInformation] where Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [ams].[View_EquipmentInformation_v1_4222022] where Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)

        If dt.Rows.Count = 0 Then
            LoadEquipDTL()
        Else
            If drpClassification.SelectedItem.Text.Contains("Office Equipment") Then
                LoadOfficeEquipment()
            ElseIf drpClassification.SelectedItem.Text.Contains("Medical Equipment") Then
                LoadMedicalEquipment()
            Else
                LoadDefaultEquipment()
            End If

        End If
    End Sub
    Protected Sub loadEquipmentLedger()

    End Sub
    Protected Sub LoadMachineryDTL()
        lblmachiniriesbrandmodel.Text = ""
        lblmachiniriesDesc.Text = ""
        lblmachinirieslocation.Text = ""
        lblmachiniriesnoofpassenger.Text = ""
        lblmachiniriesservicefloor.Text = ""
        lblmachiniriesunitno.Text = ""
        lblmachiniriesworkingload.Text = ""
        lblmachiniriesratedspeed.Text = ""
        lblmachiniriescardimension.Text = ""
        lblmachiniriesdepreciatedrate.Text = ""
        lblmachiniriesdepriciatedvalue.Text = ""
        lblmachiniriesmechpermitno.Text = ""
        lblmachiniriesdatetooperate.Text = ""
        lblmachiniriesdateissued.Text = ""
        lblmachiniriesdateinspected.Text = ""
        lblmachiniriesinspectedby.Text = ""
        lblmachiniriesremarks.Text = ""
        lblMchneDateTaken.Text = ""
        lblMchneUploadedBy.Text = ""
        lblMchnePosition.Text = ""
        lblMNoYears.Text = ""
        lblMULife.Text = ""
        txtMSalValue.Text = ""


        hdnItemNo.Value = ""
        txtMachineryName.Text = ""
        txtMachineryDescription.Text = ""
        txtMachineryPowerInput.Text = ""
        txtMachineryModel.Text = ""
        txtInstalledAt.Text = ""
        txtMachineryUnit.Text = ""
        txtMachineryDimension.Text = ""
        txtMachineryAreaCapacity.Text = ""
        txtMachineryWarranty.Text = ""
        txtMachineryFloorLocation.Text = ""
        txtMachineryRoom.Text = ""
        txtContractor.Text = ""
        txtContactPerson.Text = ""
        txtCellphoneNo.Text = ""
        txtMachineryAcqDate.Text = ""
        txtMachineryMarketValue.Text = ""
        txtMachineryAcqCost.Text = ""
        txtMachineryNoYears.Text = ""
        txtMachineryDepRate.Text = ""
        txtMachineryUsefulLife.Text = ""
        txtequipmentdepreciatedvalue.Text = ""
        txtMachinerySalvageValue.Text = ""
    End Sub
    Protected Sub loadMachineryList() '[dbo].[SMSS_MachineList]
        ' dtMachines = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        dtMachines = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_07182022_MACHINE] '" _
                                             & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" _
                                             & gvsearchproperty.SelectedDataKey("Item_ID") & "','" _
                                             & drpGeneral_Account.SelectedItem.Value & "','" _
                                             & gvsearchproperty.SelectedDataKey("DeclaredOwner") & "','" _
                                             & gvsearchproperty.SelectedDataKey("Barangay") & "'", CommandType.Text)
        If dtMachines.Rows.Count < 4 Then
            dtMachines.Merge(createdatatable4A(3 - dtMachines.Rows.Count))
        End If
        grdpropertyListofmachinery.DataSource = dtMachines
        grdpropertyListofmachinery.DataBind()
        grdpropertyListofmachinery.SelectedIndex = 0
    End Sub
    Protected Sub loadMachineryInformation()
        Dim dt As New DataTable
        '        dt = objDerived.GetDataTable("Select * from [dbo].[View_MachineryInformation] where Property_Dtl_ID = '" & grdpropertyListofmachinery.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [dbo].[View_MachineryInformation_v1_04082022] where Property_Dtl_ID = '" & grdpropertyListofmachinery.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        If dt.Rows.Count = 0 Then
            Dim dt2 As New DataTable
            dt2 = objDerived.GetDataTable("Select * from [dbo].[View_MachineryInformation_v1_None_Building_04082022] where Property_Dtl_ID = '" & grdpropertyListofmachinery.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)

            If dt2.Rows.Count = 0 Then
                LoadMachineryDTL()
            Else
                hdnItemNo.Value = dt2.Rows(0).Item("Item_ID").ToString

                lbl_Machine_Item_ID.Text = dt2.Rows(0).Item("Item_ID").ToString
                lbl_MachineryId.Text = dt2.Rows(0).Item("MachineryId").ToString
                lbl_MachineryInfoId.Text = dt2.Rows(0).Item("MachineryInfoId").ToString
                lbl_machine_Property_ID.Text = dt2.Rows(0).Item("Property_ID").ToString

                txtMachineryName.Text = dt2.Rows(0).Item("MachineName").ToString
                txtMachineryDescription.Text = dt2.Rows(0).Item("MachineDesc").ToString
                txtMachineryPowerInput.Text = dt2.Rows(0).Item("PowerInput").ToString
                txtMachineryModel.Text = dt2.Rows(0).Item("BrandModel").ToString

                ''txtInstalledAt.Text = objDerived.GetValue("select BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID where BuildingId ='" & dt.Rows(0).Item("BuildingId").ToString & "' order by BuildingName", CommandType.Text)
                'If dt2.Rows(0).Item("BuildingId").ToString = "N/A" Or dt2.Rows(0).Item("BuildingId").ToString = "Field" Then

                'Else
                '    drpMachineInstalledBuilding.SelectedValue = dt2.Rows(0).Item("BuildingId").ToString
                'End If


                ''txtMachineryUnit.Text = objDerived.GetValue("select Description  From ams.m_Unit as a where Unit_ID = '" & dt.Rows(0).Item("Unit_ID").ToString & "'order by Description", CommandType.Text)
                drpMachineUnit.SelectedValue = dt2.Rows(0).Item("Unit_ID").ToString

                txtMachineryDimension.Text = dt2.Rows(0).Item("CarDimensions").ToString
                txtMachineryAreaCapacity.Text = dt2.Rows(0).Item("AreaCapacity").ToString
                txtMachineryWarranty.Text = dt2.Rows(0).Item("Warranty").ToString
                txtMachineryFloorLocation.Text = dt2.Rows(0).Item("MachineLocation").ToString
                txtMachineryRoom.Text = dt2.Rows(0).Item("ServiceFloors").ToString
                txtContractor.Text = dt2.Rows(0).Item("MaintenanceContractor").ToString
                txtContactPerson.Text = dt2.Rows(0).Item("MaintenanceContactPerson").ToString
                txtCellphoneNo.Text = dt2.Rows(0).Item("MaintenanceContactNo").ToString
                txtMachineryAcqDate.Text = Convert.ToDateTime(dt2.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
                txtMachineryMarketValue.Text = dt2.Rows(0).Item("MarketValue").ToString
                txtMachineryAcqCost.Text = dt2.Rows(0).Item("Cost").ToString
                txtMachineryNoYears.Text = dt2.Rows(0).Item("NoYears").ToString
                txtMachineryDepRate.Text = FormatNumber(dt2.Rows(0)("DepreciationRate"), 2)
                txtMachineryUsefulLife.Text = dt2.Rows(0).Item("UsefulLife").ToString
                txtequipmentdepreciatedvalue.Text = FormatNumber(dt2.Rows(0)("DepreciationValue"), 2)
                txtMachinerySalvageValue.Text = FormatNumber(dt2.Rows(0)("SalvageValue"), 2)


                lblmachiniriesbrandmodel.Text = dt2.Rows(0).Item("BrandModel").ToString
                lblmachiniriesDesc.Text = dt2.Rows(0).Item("MachineDesc").ToString
                lblmachinirieslocation.Text = dt2.Rows(0).Item("MachineLocation").ToString
                lblmachiniriesnoofpassenger.Text = dt2.Rows(0).Item("NoPassengers").ToString
                lblmachiniriesservicefloor.Text = dt2.Rows(0).Item("ServiceFloors").ToString
                lblmachiniriesunitno.Text = dt2.Rows(0).Item("MachineUnitNo").ToString
                lblmachiniriesworkingload.Text = dt2.Rows(0).Item("WorkingLoad").ToString
                lblmachiniriesratedspeed.Text = dt2.Rows(0).Item("RatedSpeed").ToString
                lblmachiniriescardimension.Text = dt2.Rows(0).Item("CarDimensions").ToString
                lblmachiniriesmechpermitno.Text = dt2.Rows(0).Item("MechinePermitNo").ToString
                lblmachiniriesdatetooperate.Text = dt2.Rows(0).Item("DateOperate").ToString
                lblmachiniriesdateissued.Text = dt2.Rows(0).Item("DateIssued").ToString
                lblmachiniriesdateinspected.Text = dt2.Rows(0).Item("DateInspected").ToString
                lblmachiniriesinspectedby.Text = dt2.Rows(0).Item("InspectedBy").ToString
                lblmachiniriesremarks.Text = dt2.Rows(0).Item("Remarks").ToString
                lblMchneDateTaken.Text = dt2.Rows(0).Item("DateTaken").ToString
                lblMchneUploadedBy.Text = dt2.Rows(0).Item("UploadedBy").ToString
                lblMchnePosition.Text = dt2.Rows(0).Item("Position").ToString


                Dim DA As DateTime
                DA = grdpropertyListofmachinery.SelectedDataKey("Date_Accepted")
                lblMNoYears.Text = Year(Date.Today.ToString("MM/dd/yyyy")) - Year(DA) & " Year/s"


                lblmachiniriesdepreciatedrate.Text = FormatNumber(dt2.Rows(0)("DepreciationRate"), 2)
                lblmachiniriesdepriciatedvalue.Text = FormatNumber(dt2.Rows(0)("DepreciationValue"), 2)

                lblMULife.Text = IIf(IsDBNull(dt2.Rows(0)("useful_life")), 0, dt2.Rows(0)("useful_life"))
                txtMSalValue.Text = FormatNumber(dt2.Rows(0)("SalvageValue"), 2)

                Session("useful_life") = dt2.Rows(0)("useful_life")
            End If
        Else
            hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString

            lbl_Machine_Item_ID.Text = dt.Rows(0).Item("Item_ID").ToString
            lbl_MachineryId.Text = dt.Rows(0).Item("MachineryId").ToString
            lbl_MachineryInfoId.Text = dt.Rows(0).Item("MachineryInfoId").ToString
            lbl_machine_Property_ID.Text = dt.Rows(0).Item("Property_ID").ToString

            txtMachineryName.Text = dt.Rows(0).Item("MachineName").ToString
            txtMachineryDescription.Text = dt.Rows(0).Item("MachineDesc").ToString
            txtMachineryPowerInput.Text = dt.Rows(0).Item("PowerInput").ToString
            txtMachineryModel.Text = dt.Rows(0).Item("BrandModel").ToString

            ''txtInstalledAt.Text = objDerived.GetValue("select BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID where BuildingId ='" & dt.Rows(0).Item("BuildingId").ToString & "' order by BuildingName", CommandType.Text)
            drpMachineInstalledBuilding.SelectedValue = dt.Rows(0).Item("BuildingId").ToString

            ''txtMachineryUnit.Text = objDerived.GetValue("select Description  From ams.m_Unit as a where Unit_ID = '" & dt.Rows(0).Item("Unit_ID").ToString & "'order by Description", CommandType.Text)
            drpMachineUnit.SelectedValue = dt.Rows(0).Item("Unit_ID").ToString

            txtMachineryDimension.Text = dt.Rows(0).Item("CarDimensions").ToString
            txtMachineryAreaCapacity.Text = dt.Rows(0).Item("AreaCapacity").ToString
            txtMachineryWarranty.Text = dt.Rows(0).Item("Warranty").ToString
            txtMachineryFloorLocation.Text = dt.Rows(0).Item("MachineLocation").ToString
            txtMachineryRoom.Text = dt.Rows(0).Item("ServiceFloors").ToString
            txtContractor.Text = dt.Rows(0).Item("MaintenanceContractor").ToString
            txtContactPerson.Text = dt.Rows(0).Item("MaintenanceContactPerson").ToString
            txtCellphoneNo.Text = dt.Rows(0).Item("MaintenanceContactNo").ToString
            txtMachineryAcqDate.Text = Convert.ToDateTime(dt.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
            txtMachineryMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString
            txtMachineryAcqCost.Text = dt.Rows(0).Item("Cost").ToString
            txtMachineryNoYears.Text = dt.Rows(0).Item("NoYears").ToString
            txtMachineryDepRate.Text = FormatNumber(dt.Rows(0)("DepreciationRate"), 2)
            txtMachineryUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString
            txtequipmentdepreciatedvalue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)
            txtMachinerySalvageValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

            lblmachiniriesbrandmodel.Text = dt.Rows(0).Item("BrandModel").ToString
            lblmachiniriesDesc.Text = dt.Rows(0).Item("MachineDesc").ToString
            lblmachinirieslocation.Text = dt.Rows(0).Item("MachineLocation").ToString
            lblmachiniriesnoofpassenger.Text = dt.Rows(0).Item("NoPassengers").ToString
            lblmachiniriesservicefloor.Text = dt.Rows(0).Item("ServiceFloors").ToString
            lblmachiniriesunitno.Text = dt.Rows(0).Item("MachineUnitNo").ToString
            lblmachiniriesworkingload.Text = dt.Rows(0).Item("WorkingLoad").ToString
            lblmachiniriesratedspeed.Text = dt.Rows(0).Item("RatedSpeed").ToString
            lblmachiniriescardimension.Text = dt.Rows(0).Item("CarDimensions").ToString
            lblmachiniriesmechpermitno.Text = dt.Rows(0).Item("MechinePermitNo").ToString
            lblmachiniriesdatetooperate.Text = dt.Rows(0).Item("DateOperate").ToString
            lblmachiniriesdateissued.Text = dt.Rows(0).Item("DateIssued").ToString
            lblmachiniriesdateinspected.Text = dt.Rows(0).Item("DateInspected").ToString
            lblmachiniriesinspectedby.Text = dt.Rows(0).Item("InspectedBy").ToString
            lblmachiniriesremarks.Text = dt.Rows(0).Item("Remarks").ToString
            lblMchneDateTaken.Text = dt.Rows(0).Item("DateTaken").ToString
            lblMchneUploadedBy.Text = dt.Rows(0).Item("UploadedBy").ToString
            lblMchnePosition.Text = dt.Rows(0).Item("Position").ToString


            Dim DA As DateTime
            DA = grdpropertyListofmachinery.SelectedDataKey("Date_Accepted")
            lblMNoYears.Text = Year(Date.Today.ToString("MM/dd/yyyy")) - Year(DA) & " Year/s"


            lblmachiniriesdepreciatedrate.Text = FormatNumber(dt.Rows(0)("DepreciationRate"), 2)
            lblmachiniriesdepriciatedvalue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)

            lblMULife.Text = IIf(IsDBNull(dt.Rows(0)("useful_life")), 0, dt.Rows(0)("useful_life"))
            txtMSalValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

            Session("useful_life") = dt.Rows(0)("useful_life")

        End If
    End Sub
    Protected Sub gvsearchproperty_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

    End Sub
    Protected Sub gvsearchproperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub gvsearchproperty_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearchproperty, "Select$" + e.Row.RowIndex.ToString()))
        End If


    End Sub
    Protected Sub grdpropertyListofmachinery_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

    End Sub
    Protected Sub grdpropertyListofmachinery_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub grdpropertyListofmachinery_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdpropertyListofmachinery, "Select$" + e.Row.RowIndex.ToString()))


            ''e.Row.Attributes("onmouseover") = "this.style.backgroundColor='#F7A400';"
            ''e.Row.Attributes("onmouseout") = "this.style.backgroundColor='white';"


        End If
    End Sub
    Protected Sub grdpropertyListofmachinery_ondatabound(sender As Object, e As EventArgs)
        grdpropertyListofmachinery.HeaderRow.Cells(0).Visible = False
        grdpropertyListofmachinery.HeaderRow.Cells(1).Visible = False
        grdpropertyListofmachinery.HeaderRow.Cells(4).Visible = False
        Dim row As New GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "Property No."
        cell.ColumnSpan = 1
        cell.RowSpan = 2
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.RowSpan = 2
        cell.Text = "NAME"
        row.Controls.Add(cell)


        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 2
        'cell.Text = "LOCATION"
        'row.Controls.Add(cell)


        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.RowSpan = 2
        cell.Text = "Acquisition Cost"
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 3
        cell.Text = "MAINTENANCE"
        row.Controls.Add(cell)

        row.BackColor = ColorTranslator.FromHtml("#5c85d6")
        row.ForeColor = ColorTranslator.FromHtml("WHITE")
        grdpropertyListofmachinery.HeaderRow.Parent.Controls.AddAt(0, row)




    End Sub
    Protected Sub lblmachiniriesdepreciatedrate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub txtMSalValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub loadBooksMainGrid()
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '" & drpGeneral_Account.SelectedValue() & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty_Books.DataSource = createdatatable15(3)
            gvsearchproperty_Books.DataBind()
        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_Books.DataSource = dtAccount
            gvsearchproperty_Books.DataBind()
            gvsearchproperty_Books.SelectedIndex = -1
            loadBookLedger()
        End If
    End Sub
    Protected Sub gvsearchproperty_Books_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

    End Sub
    Protected Sub gvsearchproperty_Books_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub gvsearchproperty_Books_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearchproperty_Books, "Select$" + e.Row.RowIndex.ToString()))
        End If




    End Sub
    Protected Sub loadBookLedger()
        ''lblHistoryDetails.Text = "Book"
        ''btnvehicleledger.CssClass = "Clicked"
        ''btnvehiclerepairs.CssClass = "Initial"
        ''btnvehicledocattach.CssClass = "Initial"

        'Me.mvledger.SetActiveView(Me.vwledger)

        ''dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        ''dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        'If hdnItemNo.Value = "" Then
        '    'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        '    dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)
        'Else
        '    dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        'End If

        'If dtAccount.Rows.Count > 1 Then
        '    btn_EditBooks.Enabled = False
        'Else
        '    btn_EditBooks.Enabled = True
        'End If

        'If dtAccount.Rows.Count < 10 Then
        '    dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        'End If
        'grdLedger.DataSource = dtAccount
        'grdLedger.DataBind()
    End Sub

    Protected Sub LoadBldgDTL()
        lblbuildingcontrolno.Text = ""
        lblbuildingCode.Text = ""
        'lblbuildingname.Text = ""
        txtBuildingName.Text = ""
        ' lblbuildingaddress.Text = ""
        txtAddress.Text = ""
        lblbuildingpostalcode.Text = ""
        'lblbuildingDepriciationrate.Text = ""
        txtBuildingDepRate.Text = ""
        lblbuildinguse.Text = ""
        lblbuildingoccupancy.Text = ""
        lblbuildingnumberoffloors.Text = ""
        lblbuildingavgareaperfloor.Text = ""
        lblbuildingcostperarea.Text = ""
        ' lblbuildingdepreciatedvalue.Text = ""
        txtBuildingdepreciatedvalue.Text = ""
        lblbuildingdatetaken.Text = ""
        lblbuildinguploadedby.Text = ""
        lblbuildingposition.Text = ""
        txtEAcqDateBuilding.Text = ""
        txtEAcqCost.Text = ""
        txtEMarketValue.Text = ""
        txtNoYears.Text = ""
        txtUsefulLife.Text = ""
        txtSalvageValueBuilding.Text = ""
        txtPreviousOwner.Text = ""

    End Sub
    Protected Sub loadBuildingDtl()
        Dim dt As New DataTable
        ' dt = objDerived.GetDataTable("Select * from [dbo].[View_BuildingInformation] where Received_Dtl_ID = '" & gvsearch.SelectedDataKey("Received_Dtl_ID") & "'", CommandType.Text)
        dt = objDerived.GetDataTable("SELECT * from [dbo].[View_BuildingInformation_v2_04052022] where Property_ID  =  '" & gvsearch.SelectedDataKey("Property_ID") & "'", CommandType.Text)

        If dt.Rows.Count = 0 Then
            LoadBldgDTL()
        Else
            'Separate
            txtEAcqDateBuilding.Text = Convert.ToDateTime(dt.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
            txtEAcqCost.Text = Val(dt.Rows(0).Item("Cost").ToString()).ToString("n2")
            '/end separate


            ''lblbuildingcontrolno.Text = dt.Rows(0).Item("BuildingControlNo").ToString
            txtbuildingcontrolno.Text = dt.Rows(0).Item("BuildingControlNo").ToString


            ''lblbuildingCode.Text = dt.Rows(0).Item("BuildingCode").ToString
            txtbuildingCode.Text = dt.Rows(0).Item("BuildingCode").ToString


            txtBuildingBrgy.Text = dt.Rows(0).Item("Barangay").ToString

            txtBuildingArea.Text = dt.Rows(0).Item("Area1").ToString
            txtBuildingTaxDecNo.Text = dt.Rows(0).Item("TaxDeclarationNo").ToString

            ' lblbuildingname.Text = dt.Rows(0).Item("BuildingName").ToString
            txtBuildingName.Text = dt.Rows(0).Item("BuildingName").ToString
            ' lblbuildingaddress.Text = dt.Rows(0).Item("BuildingAddress").ToString
            txtAddress.Text = dt.Rows(0).Item("BuildingAddress").ToString

            'lblbuildingpostalcode.Text = dt.Rows(0).Item("PostalCode").ToString
            txtbuildingpostalcode.Text = dt.Rows(0).Item("PostalCode").ToString

            'lblbuildingDepriciationrate.Text = dt.Rows(0).Item("BuildingDepreciationRate").ToString
            txtBuildingDepRate.Text = dt.Rows(0).Item("BuildingDepreciationRate").ToString

            ''lblbuildinguse.Text = dt.Rows(0).Item("BuildingUse").ToString
            txtbuildinguse.Text = dt.Rows(0).Item("BuildingUse").ToString

            'lblbuildingoccupancy.Text = dt.Rows(0).Item("BuildingOccupancy").ToString
            txtbuildingoccupancy.Text = dt.Rows(0).Item("BuildingOccupancy").ToString

            'lblbuildingnumberoffloors.Text = dt.Rows(0).Item("NumberFloors").ToString
            txtbuildingnumberoffloors.Text = dt.Rows(0).Item("NumberFloors").ToString

            'lblbuildingavgareaperfloor.Text = dt.Rows(0).Item("AvgAreaFloor").ToString
            txtbuildingavgareaperfloor.Text = dt.Rows(0).Item("AvgAreaFloor").ToString

            'lblbuildingcostperarea.Text = dt.Rows(0).Item("CostPerArea").ToString
            txtbuildingcostperarea.Text = dt.Rows(0).Item("CostPerArea").ToString

            'lblbuildingdepreciatedvalue.Text = FormatNumber(dt.Rows(0).Item("BuildingDepreciationValue").ToString, 2)
            txtBuildingdepreciatedvalue.Text = FormatNumber(dt.Rows(0).Item("BuildingDepreciationValue").ToString, 2)
            lblbuildingdatetaken.Text = dt.Rows(0).Item("DateTaken").ToString
            lblbuildinguploadedby.Text = dt.Rows(0).Item("UploadedBy").ToString
            lblbuildingposition.Text = dt.Rows(0).Item("Position").ToString



            txtEMarketValue.Text = Val(dt.Rows(0).Item("MarketValue").ToString).ToString("n2")
            txtNoYears.text = dt.Rows(0).Item("NoofYears").ToString
            txtUsefulLife.text = dt.Rows(0).Item("UsefuleLife").ToString
            txtSalvageValueBuilding.Text = Val(dt.Rows(0).Item("SalvageValue").ToString).ToString("n2")

            'Separate
            txtPreviousOwner.Text = dt.Rows(0).Item("CorporationName").ToString

            lblBuildingitem_id.Text = dt.Rows(0).Item("Item_ID").ToString
            lblBuildingProperty_ID.Text = dt.Rows(0).Item("Property_ID").ToString
            lblBuilding_Get_ID.Text = dt.Rows(0).Item("BuildingId").ToString
        End If
    End Sub
    Protected Sub LoadBuildingMainGrid()

        dtAccount = objDerived.GetDataTable("EXEC [AMS].[sp_RecordsList_LandBldg] '" & drpGeneral_Account.SelectedItem.Value & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearch.DataSource = createdatatable2(3)
            gvsearch.DataBind()
            LoadBldgDTL()
        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable2(3 - dtAccount.Rows.Count))
            End If
            gvsearch.DataSource = dtAccount
            gvsearch.DataBind()
        End If

    End Sub
    Protected Sub LoadLandMainGrid()
        dtAccount = objDerived.GetDataTable("EXEC [AMS].[sp_RecordsList_LandBldg] '" & drpGeneral_Account.SelectedItem.Value & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearch.DataSource = createdatatable2(3)
            gvsearch.DataBind()
        End If
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
            dr("BalCost") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Sub enableFalseLand()
        txtLguCode.Enabled = False
        txtDistrictCode.Enabled = False
        txtMunicipalCode.Enabled = False
        txtBrgyCode.Enabled = False
        txtSectionNo.Enabled = False
        txtParcelNo.Enabled = False
        txtSeriesNo.Enabled = False
        txtPin.Enabled = False
        txtArp.Enabled = False
        txtRevYear.Enabled = False
        txtRptin.Enabled = False
        txtTdn.Enabled = False
        txtDepRate.Enabled = False
        lblDepValue.Enabled = False
        txtLotNo.Enabled = False
        txtBlkNo.Enabled = False
        txtStreetName.Enabled = False
        txtSubdivision.Enabled = False
        txtPhaseNo.Enabled = False
        txtPurok.Enabled = False
        txtSitio.Enabled = False
        txtBrgy.Enabled = False
        txtDistrict.Enabled = False
        txtMunicipal.Enabled = False
        txtRegion.Enabled = False
        txtProvince.Enabled = False
        txtZipCode.Enabled = False
        txtClassification.Enabled = False
        txtSubClass.Enabled = False
        txtLandUse.Enabled = False
        txtStatus1.Enabled = False
        txtTaxable.Enabled = False
        txtArea.Enabled = False
        txtStatus2.Enabled = False
        txtAssessedValue.Enabled = False
        txtAVDate.Enabled = False
        txtMarketValue1.Enabled = False
        txtMVDate.Enabled = False
        txtUnitValue.Enabled = False
        txtUVDate.Enabled = False
        txtAVAmount.Enabled = False
        txtMVAmount.Enabled = False
        ddAssessmentLvl.Enabled = False
        ddAssessmentLvl.Enabled = False
        txtLocation.Enabled = False
        ddBrgy1.Enabled = False
        txtArea1.Enabled = False
        ddTaxDecNo.Enabled = False
        txtPrevOwner.Enabled = False
        txtEAcqDate.Enabled = False
        txtAcqCost.Enabled = False
        txtMarketValue.Enabled = False
        txtAcqMode.Enabled = False
    End Sub
    Protected Sub drpClassification_SelectedIndexChanged(sender As Object, e As EventArgs)
        Sub_Classification_load()
        multiviewselected()
    End Sub
    Protected Sub drpSub_Classification_SelectedIndexChanged(sender As Object, e As EventArgs)
        GeneralAccount_Load()
    End Sub
    Protected Sub drpGeneral_Account_SelectedIndexChanged(sender As Object, e As EventArgs)
        Category_load()
    End Sub
    Protected Sub drpCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        SubCategory_Load()
    End Sub
    Protected Sub Classification_load()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("Select * from dbo.tbl_Classification where AllotmentClass_id = 3 order by ClassificationName  ", CommandType.Text)
        drpClassification.DataSource = CType(dt, DataTable)
        drpClassification.DataTextField = ("ClassificationName")
        drpClassification.DataValueField = ("ClassificationId")
        drpClassification.DataBind()
        Sub_Classification_load()
    End Sub
    Public Sub Sub_Classification_load()
        drpSub_Classification.DataSource = obj.GetDataTable("Select SubClassificationID, SubclassificationName from dbo.tbl_SubClassification where ClassificationID = '" & drpClassification.SelectedItem.Value & "'", CommandType.Text)
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
    Protected Sub gvsearch_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvsearch.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearch, "Select$" + e.Row.RowIndex.ToString()))

        End If
    End Sub
    Protected Sub gvsearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvsearch.SelectedIndexChanged
        If drpGeneral_Account.SelectedItem.Value = 1060 Or drpGeneral_Account.SelectedItem.Value = 1067 Or drpGeneral_Account.SelectedItem.Value = 1062 Then
            loadLandInformation()
        ElseIf drpGeneral_Account.SelectedItem.Value = 1082 Or drpGeneral_Account.SelectedItem.Value = 1085 Then
            loadBuildingDtl()
        End If
    End Sub
    Protected Sub loadLandInformation()
        Dim dt As New DataTable
        ' dt = objDerived.GetDataTable("Select * from [dbo].[View_LandInformation] where Received_Dtl_ID = '" & gvsearch.SelectedDataKey("Received_Dtl_ID") & "'", CommandType.Text)
        dt = objDerived.GetDataTable("SELECT * from [AMS].[View_LandInformation_v2_07062022] where Property_ID  =  '" & gvsearch.SelectedDataKey("Property_ID") & "'", CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadLandDTL()
        Else
            'lblLguCode.Text = dt.Rows(0).Item("LguCode").ToString
            'lblDistrictCode.Text = dt.Rows(0).Item("DistrictCode").ToString
            'lblMunicipalCode.Text = dt.Rows(0).Item("CityMunCode").ToString
            'lblBrgyCode.Text = dt.Rows(0).Item("BarangayCode").ToString
            'lblSectionNo.Text = dt.Rows(0).Item("SectionNo").ToString
            'lblParcelNo.Text = dt.Rows(0).Item("ParcelNo").ToString
            'lblSeriesNo.Text = dt.Rows(0).Item("SeriesNo").ToString
            'lblPin.Text = dt.Rows(0).Item("PIN").ToString
            'lblArp.Text = dt.Rows(0).Item("ARP").ToString
            'lblRevYear.Text = dt.Rows(0).Item("RevYear").ToString
            'lblRptin.Text = dt.Rows(0).Item("RPTIN").ToString
            'lblTdn.Text = dt.Rows(0).Item("TDN").ToString
            'lblDepRate.Text = dt.Rows(0).Item("DepreciationRate").ToString
            'lblDepValue.Text = dt.Rows(0).Item("DepreciationValue").ToString
            'lblLotNo.Text = dt.Rows(0).Item("LotNo").ToString
            'lblBlkNo.Text = dt.Rows(0).Item("BlkNo").ToString
            'lblStreetName.Text = dt.Rows(0).Item("StreetName").ToString
            'lblSubdivision.Text = dt.Rows(0).Item("Subdivision").ToString
            'lblPhaseNo.Text = dt.Rows(0).Item("PhaseNo").ToString
            'lblPurok.Text = dt.Rows(0).Item("Purok").ToString
            'lblSitio.Text = dt.Rows(0).Item("Sitio").ToString
            'lblBrgy.Text = dt.Rows(0).Item("Barangay").ToString
            'lblDistrict.Text = dt.Rows(0).Item("District").ToString
            'lblMunicipal.Text = dt.Rows(0).Item("CityMunicipal").ToString
            'lblRegion.Text = dt.Rows(0).Item("Region").ToString
            'lblProvince.Text = dt.Rows(0).Item("Province").ToString
            'lblZipCode.Text = dt.Rows(0).Item("ZipCode").ToString
            'lblClassification.Text = dt.Rows(0).Item("Classification").ToString
            'lblSubClass.Text = dt.Rows(0).Item("SubClass").ToString
            'lblLandUse.Text = dt.Rows(0).Item("LandUse").ToString
            'lblStatus1.Text = dt.Rows(0).Item("Status_1").ToString
            'lblTaxable.Text = dt.Rows(0).Item("Taxable").ToString
            'lblArea.Text = dt.Rows(0).Item("Area").ToString
            'lblStatus2.Text = dt.Rows(0).Item("Status_2").ToString
            'lblAssessedValue.Text = dt.Rows(0).Item("AssessedValue").ToString
            'lblAVDate.Text = Convert.ToDateTime(dt.Rows(0).Item("AssessedDate").ToString).ToString("MM/dd/yyyy")
            'lblMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString
            'lblMVDate.Text = Convert.ToDateTime(dt.Rows(0).Item("MarketDate").ToString).ToString("MM/dd/yyyy")
            'lblUnitValue.Text = dt.Rows(0).Item("UnitValue").ToString
            'lblUVDate.Text = Convert.ToDateTime(dt.Rows(0).Item("UnitDate").ToString).ToString("MM/dd/yyyy")
            'lblAVAmount.Text = dt.Rows(0).Item("AVAmountWords").ToString
            'lblMVAmount.Text = dt.Rows(0).Item("MVAmountWords").ToString
            'ddAssessmentLvl.SelectedValue = dt.Rows(0).Item("AssessmentLevel").ToString
            'ddAssessmentLvl.SelectedValue = dt.Rows(0).Item("AssessmentLevel").ToString
            'txtLocation.text = dt.Rows(0).Item("FullAddress").ToString
            'txtBrgy1.text = dt.Rows(0).Item("Barangay1").ToString
            'txtArea1.text = dt.Rows(0).Item("Area1").ToString
            'txtTaxDecNo.text = dt.Rows(0).Item("TaxDeclarationNo").ToString
            'txtPrevOwner.text = dt.Rows(0).Item("OwnerName").ToString
            'txtEAcqDate.text = dt.Rows(0).Item("Property_Date").ToString
            'txtAcqCost.text = dt.Rows(0).Item("Cost").ToString
            'txtMarketValue.text = dt.Rows(0).Item("MarketValue1").ToString
            'txtAcqMode.Text = dt.Rows(0).Item("AcqMode").ToString

            ''heres
            lblIntLandId.Text = dt.Rows(0).Item("LandId").ToString
            lblIntProperty_Dtl_ID.Text = dt.Rows(0).Item("Property_Dtl_ID").ToString
            lblIntProperty_ID.Text = dt.Rows(0).Item("Property_ID").ToString
            lblIntM_Item_ID.Text = dt.Rows(0).Item("Item_ID").ToString
            txtLguCode.Text = dt.Rows(0).Item("LguCode").ToString
            txtDistrictCode.Text = dt.Rows(0).Item("DistrictCode").ToString
            txtMunicipalCode.Text = dt.Rows(0).Item("CityMunCode").ToString
            txtBrgyCode.Text = dt.Rows(0).Item("BarangayCode").ToString
            txtSectionNo.Text = dt.Rows(0).Item("SectionNo").ToString
            txtParcelNo.Text = dt.Rows(0).Item("ParcelNo").ToString
            txtSeriesNo.Text = dt.Rows(0).Item("SeriesNo").ToString
            txtPin.Text = dt.Rows(0).Item("PIN").ToString
            txtArp.Text = dt.Rows(0).Item("ARP").ToString
            txtRevYear.Text = dt.Rows(0).Item("RevYear").ToString
            txtRptin.Text = dt.Rows(0).Item("RPTIN").ToString
            txtTdn.Text = dt.Rows(0).Item("TDN").ToString
            txtDepRate.Text = dt.Rows(0).Item("DepreciationRate").ToString
            lblDepValue.Text = dt.Rows(0).Item("DepreciationValue").ToString
            txtLotNo.Text = dt.Rows(0).Item("LotNo").ToString
            txtBlkNo.Text = dt.Rows(0).Item("BlkNo").ToString
            txtStreetName.Text = dt.Rows(0).Item("StreetName").ToString
            txtSubdivision.Text = dt.Rows(0).Item("Subdivision").ToString
            txtPhaseNo.Text = dt.Rows(0).Item("PhaseNo").ToString
            txtPurok.Text = dt.Rows(0).Item("Purok").ToString
            txtSitio.Text = dt.Rows(0).Item("Sitio").ToString
            txtBrgy.Text = dt.Rows(0).Item("Barangay").ToString
            txtDistrict.Text = dt.Rows(0).Item("District").ToString
            txtMunicipal.Text = dt.Rows(0).Item("CityMunicipal").ToString
            txtRegion.Text = dt.Rows(0).Item("Region").ToString
            txtProvince.Text = dt.Rows(0).Item("Province").ToString
            txtZipCode.Text = dt.Rows(0).Item("ZipCode").ToString
            txtClassification.Text = dt.Rows(0).Item("Classification").ToString
            txtSubClass.Text = dt.Rows(0).Item("SubClass").ToString
            txtLandUse.Text = dt.Rows(0).Item("LandUse").ToString
            txtStatus1.Text = dt.Rows(0).Item("Status_1").ToString
            txtTaxable.Text = dt.Rows(0).Item("Taxable").ToString
            txtArea.Text = dt.Rows(0).Item("Area").ToString
            txtStatus2.Text = dt.Rows(0).Item("Status_2").ToString
            txtAssessedValue.Text = CDec(dt.Rows(0).Item("AssessedValue").ToString).ToString("n2")
            txtAVDate.Text = Convert.ToDateTime(dt.Rows(0).Item("AssessedDate").ToString).ToString("MM/dd/yyyy")
            txtMarketValue1.Text = CDec(dt.Rows(0).Item("MarketValue").ToString).ToString("n2")
            txtMVDate.Text = Convert.ToDateTime(dt.Rows(0).Item("MarketDate").ToString).ToString("MM/dd/yyyy")
            txtUnitValue.Text = CDec(dt.Rows(0).Item("UnitValue").ToString).ToString("n2")
            txtUVDate.Text = Convert.ToDateTime(dt.Rows(0).Item("UnitDate").ToString).ToString("MM/dd/yyyy")
            txtAVAmount.Text = dt.Rows(0).Item("AVAmountWords").ToString
            txtMVAmount.Text = dt.Rows(0).Item("MVAmountWords").ToString
            ddAssessmentLvl.SelectedValue = dt.Rows(0).Item("AssessmentLevel").ToString
            ddAssessmentLvl.SelectedValue = dt.Rows(0).Item("AssessmentLevel").ToString
            txtLocation.Text = dt.Rows(0).Item("FullAddress").ToString
            ddBrgy1.SelectedItem.Text = dt.Rows(0).Item("Barangay1").ToString
            txtArea1.Text = dt.Rows(0).Item("Area1").ToString
            ddTaxDecNo.SelectedItem.Text = dt.Rows(0).Item("TaxDeclarationNo").ToString
            txtPrevOwner.Text = dt.Rows(0).Item("OwnerName").ToString

            txtEAcqDate.Text = Convert.ToDateTime(dt.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")

            txtAcqCost.Text = CDec(dt.Rows(0).Item("Cost").ToString).ToString("n2")
            txtMarketValue.Text = CDec(dt.Rows(0).Item("MarketValue1").ToString).ToString("n2")
            txtAcqMode.Text = dt.Rows(0).Item("AcqMode").ToString
        End If
    End Sub
    Protected Sub LoadLandDTL()
        'lblLguCode.Text = ""
        'lblDistrictCode.Text = ""
        'lblMunicipalCode.Text = ""
        'lblBrgyCode.Text = ""
        'lblSectionNo.Text = ""
        'lblParcelNo.Text = ""
        'lblSeriesNo.Text = ""
        'lblPin.Text = ""
        'lblArp.Text = ""
        'lblRevYear.Text = ""
        'lblRptin.Text = ""
        'lblTdn.Text = ""
        'lblDepRate.Text = ""
        'lblDepValue.Text = ""
        'lblLotNo.Text = ""
        'lblBlkNo.Text = ""
        'lblStreetName.Text = ""
        'lblSubdivision.Text = ""
        'lblPhaseNo.Text = ""
        'lblPurok.Text = ""
        'lblSitio.Text = ""
        'lblBrgy.Text = ""
        'lblDistrict.Text = ""
        'lblMunicipal.Text = ""
        'lblRegion.Text = ""
        'lblProvince.Text = ""
        'lblZipCode.Text = ""
        'lblClassification.Text = ""
        'lblSubClass.Text = ""
        'lblLandUse.Text = ""
        'lblStatus1.Text = ""
        'lblTaxable.Text = ""
        'lblArea.Text = ""
        'lblStatus2.Text = ""
        'lblAssessedValue.Text = ""
        'lblAVDate.Text = ""
        'lblMarketValue.Text = ""
        'lblMVDate.Text = ""
        'lblUnitValue.Text = ""
        'lblUVDate.Text = ""
        'lblAVAmount.Text = ""
        'lblMVAmount.Text = ""
        ''________
        txtLguCode.Text = ""
        txtDistrictCode.Text = ""
        txtMunicipalCode.Text = ""
        txtBrgyCode.Text = ""
        txtSectionNo.Text = ""
        txtParcelNo.Text = ""
        txtSeriesNo.Text = ""
        txtPin.Text = ""
        txtArp.Text = ""
        txtRevYear.Text = ""
        txtRptin.Text = ""
        txtTdn.Text = ""
        txtDepRate.Text = ""
        lblDepValue.Text = ""
        txtLotNo.Text = ""
        txtBlkNo.Text = ""
        txtStreetName.Text = ""
        txtSubdivision.Text = ""
        txtPhaseNo.Text = ""
        txtPurok.Text = ""
        txtSitio.Text = ""
        txtBrgy.Text = ""
        txtDistrict.Text = ""
        txtMunicipal.Text = ""
        txtRegion.Text = ""
        txtProvince.Text = ""
        txtZipCode.Text = ""
        txtClassification.Text = ""
        txtSubClass.Text = ""
        txtLandUse.Text = ""
        txtStatus1.Text = ""
        txtTaxable.Text = ""
        txtArea.Text = ""
        txtStatus2.Text = ""
        txtAssessedValue.Text = ""
        txtAVDate.Text = ""
        txtMarketValue.Text = ""
        txtMVDate.Text = ""
        txtUnitValue.Text = ""
        txtUVDate.Text = ""
        txtAVAmount.Text = ""
        txtMVAmount.Text = ""

        ddAssessmentLvl.SelectedValue = ""
        txtLocation.text = ""
        ddBrgy1.SelectedItem.Text = "Select"
        txtArea1.text = ""
        ddTaxDecNo.SelectedItem.Text = "Select"
        txtPrevOwner.text = ""
        txtEAcqDate.text = ""
        txtAcqCost.text = ""
        txtMarketValue.text = ""
        txtAcqMode.text = ""
    End Sub
    Public Sub Category_load()
        Try
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
            SubCategory_Load()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub SubCategory_Load()
        Dim category As String
        If drpCategory.text = "" Then
            category = 0
        Else
            category = drpCategory.selectedvalue()
        End If

        Dim subcategory As New DataTable
        drpSub_Category.items.clear()
        '
        subcategory = obj.GetDataTable("select [SubCategoryID],[SubCat_Desc]  From [dbo].[tbl_SubCategory] where item_particular_id = " & category & "", CommandType.Text)
        drpSub_Category.datasource = subcategory
        drpSub_Category.DataTextField = ("SubCat_Desc")
        drpSub_Category.DataValueField = ("SubCategoryID")
        drpSub_Category.DataBind()
    End Sub
    Public Sub loadDepartments()


        drpDepartment.DataSource = obj.GetDataTable("[AMS].[sp_VIEW_Departments] '" & Session("@UserID") & "'", CommandType.Text)
        drpDepartment.DataTextField = ("RC_Name")
        drpDepartment.DataValueField = ("RC_ID")
        drpDepartment.DataBind()

    End Sub
    Public Sub ClearOfficeEquipment()

        txtOfficeEquipmentName.Text = ""
        txtOfficeEquipmentDesc.Text = ""
        txtOfficeEquipmentPowerInput.Text = ""
        txtOfficeEquipmentDimension.Text = ""
        txtOfficeEquipmentModel.Text = ""
        txtOfficeEquipmentWarranty.Text = ""
        txtOfficeEquipmentContractor.Text = ""
        txtOfficeEquipmentContactPerson.Text = ""
        txtOfficeEquipmentContactNo.Text = ""
        txtOfficeEquipmentSerialNo.Text = ""



        ''txtOfficeEquipmentInstalledat.Text = ""
        txtOfficeEquipmentMarketValue.Text = ""

        txtOfficeEquipmentAcqDate.Text = ""
        txtOfficeEquipmentAcqCost.Text = ""


        'Dim DA As DateTime
        'DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")
        txtOfficeEquipmentNoYears.Text = ""
        txtOfficeEquipmentDepValue.Text = ""
        txtOfficeEquipmentDepRate.Text = ""
        txtOfficeEquipmentUsefulLife.Text = ""
        txtOfficeEquipmentSalvageValue.Text = ""

        txtequipmentareacapacity.Text = ""
    End Sub
    Public Sub ClearEquipment()
        txtDefaultEquipmentName.Text = ""
        txtDefaultEquipmentDescription.Text = ""
        txtDefaultEquipmentPowerInput.Text = ""
        txtDefaultEquipmentModel.Text = ""
        txtDefaultEquipmentSerialNumber.Text = ""
        txtDefaultEquipmentQuantity.Text = ""
        txtDefaultEquipmentWarranty.Text = ""
        txtDefaultEquipmentSpecifications.Text = ""
        txtDefaultEquipmentDimension.Text = ""

        txtDefaultEquipmentContractor.Text = ""
        txtDefaultEquipmentContactPerson.Text = ""
        txtDefaultEquipmentContactNo.Text = ""

        txtDefaultEquipmentAcquisitionDate.Text = ""
        txtDefaultEquipmentAcquisitionCost.Text = ""
        txtDefaultEquipmentDepRate.Text = ""
        txtDefaultEquipmentDepValue.Text = ""
        txtDefaultEquipmentMarketValue.Text = ""
        txtDefaultEquipmentNoYears.Text = ""
        txtDefaultEquipmentUsefulLife.Text = ""
        txtDefaultEquipmentSalvageValue.Text = ""
    End Sub
    Public Sub LoadOfficeEquipment()
        Dim dt As New DataTable
        ' dt = objDerived.GetDataTable("Select * from [dbo].[View_EquipmentInformation] where Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [ams].[View_EquipmentInformation_v1_4222022] where Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString
        'lblOfficeEquipmentName.Text = dt.Rows(0).Item("Name").ToString
        'lblOfficeEquipmentDesc.Text = dt.Rows(0).Item("Description").ToString
        'lblOfficeEquipmentPowerInput.Text = dt.Rows(0).Item("PowerInput").ToString
        'lblOfficeEquipmentDimension.Text = dt.Rows(0).Item("Dimension").ToString
        'lblOfficeEquipmentModel.Text = dt.Rows(0).Item("Model").ToString
        'lblOfficeEquipmentWarranty.Text = dt.Rows(0).Item("Warranty").ToString
        'lblOfficeEquipmentContractor.Text = dt.Rows(0).Item("MaintenanceContractor").ToString
        'lblOfficeEquipmentContactPerson.Text = dt.Rows(0).Item("MaintenanceContactPerson").ToString
        'lblOfficeEquipmentContactNo.Text = dt.Rows(0).Item("MaintenanceContactNo").ToString
        'lblOfficeEquipmentSerialNo.Text = dt.Rows(0).Item("SerialNo").ToString


        'lblOfficeEquipmentUnit.Text = dt.Rows(0).Item("UnitDesc").ToString
        'lblOfficeEquipmentInstalledat.Text = dt.Rows(0).Item("InstalledAt").ToString
        'lblOfficeEquipmentMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString

        'lblOfficeEquipmentAcqDate.Text = grdlistofEuipment.SelectedDataKey("Date_Accepted")
        'lblOfficeEquipmentAcqCost.Text = grdlistofEuipment.SelectedDataKey("AcquisitionCost")


        'Dim DA As DateTime
        'DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")
        'lblOfficeEquipmentNoYears.Text = Year(Date.Today.ToString("MM/dd/yyyy")) - Year(DA) & " Year/s"
        'lblOfficeEquipmentDepValue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)
        'lblOfficeEquipmentDepRate.Text = dt.Rows(0)("DepreciationRate")
        'lblOfficeEquipmentUsefulLife.Text = IIf(IsDBNull(dt.Rows(0)("useful_life")), 0, dt.Rows(0)("useful_life"))
        'lblOfficeEquipmentSalvageValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

        'lblequipmentareacapacity.Text = dt.Rows(0).Item("AreaCapacity").ToString
        'lblSpecification.Text = dt.Rows(0).Item("Specification").ToString

        txtOfficeEquipmentName.Text = dt.Rows(0).Item("Name").ToString
        txtOfficeEquipmentDesc.Text = dt.Rows(0).Item("Description").ToString
        txtOfficeEquipmentPowerInput.Text = dt.Rows(0).Item("PowerInput").ToString
        txtOfficeEquipmentDimension.Text = dt.Rows(0).Item("Dimension").ToString
        txtOfficeEquipmentModel.Text = dt.Rows(0).Item("Model").ToString
        txtOfficeEquipmentWarranty.Text = dt.Rows(0).Item("Warranty").ToString
        txtOfficeEquipmentContractor.Text = dt.Rows(0).Item("MaintenanceContractor").ToString
        txtOfficeEquipmentContactPerson.Text = dt.Rows(0).Item("MaintenanceContactPerson").ToString
        txtOfficeEquipmentContactNo.Text = dt.Rows(0).Item("MaintenanceContactNo").ToString
        txtOfficeEquipmentSerialNo.Text = dt.Rows(0).Item("SerialNo").ToString


        drpOfficeEquipmentUnit.SelectedValue = dt.Rows(0).Item("Unit_ID").ToString
        Dim a As String = dt.Rows(0).Item("Buildingid").ToString
        If dt.Rows(0).Item("Buildingid").ToString = 0 Then

        Else
            drpOfficeEquipmentBuilding.SelectedValue = dt.Rows(0).Item("Buildingid").ToString
        End If



        txtOfficeEquipmentMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString

        txtOfficeEquipmentAcqDate.Text = Convert.ToDateTime(dt.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
        txtOfficeEquipmentAcqCost.Text = dt.Rows(0).Item("Cost").ToString


        Dim DA As DateTime
        DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")
        txtOfficeEquipmentNoYears.Text = dt.Rows(0).Item("NoYears").ToString
        txtOfficeEquipmentDepValue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)
        txtOfficeEquipmentDepRate.Text = dt.Rows(0)("DepreciationRate")
        txtOfficeEquipmentUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString
        txtOfficeEquipmentSalvageValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

        txtequipmentareacapacity.Text = dt.Rows(0).Item("AreaCapacity").ToString
        txtOfficeEquipmentQuantity.Text = dt.Rows(0).Item("Qty").ToString
        txtSpecification.Text = dt.Rows(0).Item("Specification").ToString

        lbl_OfficeEquipment_EquipInfoId.Text = dt.Rows(0).Item("EquipInfoId").ToString
        lbl_OfficeEquipment_EquipmentId.Text = dt.Rows(0).Item("EquipmentId").ToString
        lbl_OfficeEquipment_PropertyDetai_ID.Text = dt.Rows(0).Item("PropertyDetai_ID").ToString
        lbl_OfficeEquipment_Property_ID.Text = dt.Rows(0).Item("Property_ID").ToString
        lbl_OfficeEquipment_Item_ID.Text = dt.Rows(0).Item("Item_ID").ToString



        Session("useful_life") = dt.Rows(0)("useful_life")

    End Sub
    Public Sub LoadMedicalEquipment()
        Dim dt As New DataTable
        ' dt = objDerived.GetDataTable("Select * from [dbo].[View_EquipmentInformation] where Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [ams].[View_EquipmentInformation_v1_4222022] where Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString
        lblMedicalEquipmentName.Text = dt.Rows(0).Item("Name").ToString
        lblMedicalEquipmentDesc.Text = dt.Rows(0).Item("Description").ToString
        lblMedicalEquipmentPowerInput.Text = dt.Rows(0).Item("PowerInput").ToString
        lblMedicalEquipmentDimension.Text = dt.Rows(0).Item("Dimension").ToString
        lblMedicalEquipmentModel.Text = dt.Rows(0).Item("Model").ToString
        lblMedicalEquipmentWarranty.Text = dt.Rows(0).Item("Warranty").ToString
        lblMedicalEquipmentContractor.Text = dt.Rows(0).Item("MaintenanceContractor").ToString
        lblMedicalEquipmentContactPerson.Text = dt.Rows(0).Item("MaintenanceContactPerson").ToString
        lblMedicalEquipmentContactNo.Text = dt.Rows(0).Item("MaintenanceContactNo").ToString
        lblMedicalEquipmentSerialNo.Text = dt.Rows(0).Item("SerialNo").ToString


        lblMedicalEquipmentUnit.Text = dt.Rows(0).Item("UnitDesc").ToString
        lblMedicalEquipmentInstalledAt.Text = dt.Rows(0).Item("InstalledAt").ToString
        lblMedicalEquipmentMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString

        lblMedicalEquipmentAcqDate.Text = grdlistofEuipment.SelectedDataKey("Date_Accepted")
        lblMedicalEquipmentAcqCost.Text = grdlistofEuipment.SelectedDataKey("AcquisitionCost")


        Dim DA As DateTime
        DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")
        lblMedicalEquipmentNoYears.Text = Year(Date.Today.ToString("MM/dd/yyyy")) - Year(DA) & " Year/s"
        lblMedicalEquipmentDepValue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)
        lblMedicalEquipmentDepRate.Text = dt.Rows(0)("DepreciationRate")
        lblMedicalEquipmentUsefulLife.Text = IIf(IsDBNull(dt.Rows(0)("useful_life")), 0, dt.Rows(0)("useful_life"))
        lblMedicalEquipmentSalvageValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

        lblequipmentareacapacity.Text = dt.Rows(0).Item("AreaCapacity").ToString
        lblSpecification.Text = dt.Rows(0).Item("Specification").ToString

        Session("useful_life") = dt.Rows(0)("useful_life")

    End Sub
    Public Sub LoadDefaultEquipment()
        Dim dt As New DataTable
        ' dt = objDerived.GetDataTable("Select * from [dbo].[View_EquipmentInformation] where Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [ams].[View_EquipmentInformation_v1_4222022] where Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)

        hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString

        lblequipmentname.Text = dt.Rows(0).Item("Name").ToString
        txtDefaultEquipmentName.Text = dt.Rows(0).Item("Name").ToString

        lblequipmentdesciption.Text = dt.Rows(0).Item("Description").ToString
        txtDefaultEquipmentDescription.Text = dt.Rows(0).Item("Description").ToString

        lblequipmentpowerinput.Text = dt.Rows(0).Item("PowerInput").ToString
        txtDefaultEquipmentPowerInput.Text = dt.Rows(0).Item("PowerInput").ToString

        lblequipmentdimension.Text = dt.Rows(0).Item("Dimension").ToString
        txtDefaultEquipmentDimension.Text = dt.Rows(0).Item("Dimension").ToString

        lblequipmentareacapacity.Text = dt.Rows(0).Item("AreaCapacity").ToString
        lblDefaultEquipmentAreaCapacity.Text = dt.Rows(0).Item("AreaCapacity").ToString

        lblequipmentmodel.Text = dt.Rows(0).Item("Model").ToString
        txtDefaultEquipmentModel.Text = dt.Rows(0).Item("Model").ToString

        lblequipmentwaranty.Text = dt.Rows(0).Item("Warranty").ToString
        txtDefaultEquipmentWarranty.Text = dt.Rows(0).Item("Warranty").ToString

        lblSpecification.Text = dt.Rows(0).Item("Specification").ToString
        txtDefaultEquipmentSpecifications.Text = dt.Rows(0).Item("Specification").ToString


        Dim DA As DateTime
        DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")

        lblNoYears.Text = Year(Date.Today.ToString("MM/dd/yyyy")) - Year(DA) & " Year/s"
        txtDefaultEquipmentNoYears.Text = dt.Rows(0).Item("NoYears").ToString

        lblequipmentdepreciatedvalue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)
        txtDefaultEquipmentDepValue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)

        lblequipmentdepreciatedRate.Text = dt.Rows(0)("DepreciationRate").ToString
        txtDefaultEquipmentDepRate.Text = dt.Rows(0)("DepreciationRate").ToString

        'lblUsefulLife.Text = IIf(IsDBNull(dt.Rows(0)("useful_life")), 0, dt.Rows(0)("useful_life"))
        txtDefaultEquipmentUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString

        txtSalvageValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)
        txtDefaultEquipmentSalvageValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

        Session("useful_life") = dt.Rows(0)("useful_life")

        txtDefaultEquipmentAcquisitionDate.Text = Convert.ToDateTime(dt.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyy")
        txtDefaultEquipmentAcquisitionCost.Text = dt.Rows(0)("Cost")

        txtDefaultEquipmentSerialNumber.Text = dt.Rows(0).Item("SerialNo").ToString
        txtDefaultEquipmentContractor.Text = dt.Rows(0).Item("MaintenanceContractor").ToString
        txtDefaultEquipmentContactPerson.Text = dt.Rows(0).Item("MaintenanceContactPerson").ToString
        txtDefaultEquipmentContactNo.Text = dt.Rows(0).Item("MaintenanceContactNo").ToString
        txtDefaultEquipmentMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString

        drpEquipmentInstalledBuilding.SelectedValue = dt.Rows(0).Item("Buildingid").ToString
        drpEquipmentUnit.SelectedValue = dt.Rows(0).Item("Unit_ID").ToString

        txtDefaultEquipmentQuantity.Text = dt.Rows(0).Item("Qty").ToString


        lbl_Equipment_EquipInfoId.Text = dt.Rows(0).Item("EquipInfoId").ToString
        lbl_Equipment_EquipmentId.Text = dt.Rows(0).Item("EquipmentId").ToString
        lbl_Equipment_PropertyDetai_ID.Text = dt.Rows(0).Item("PropertyDetai_ID").ToString
        lbl_Equipment_Property_ID.Text = dt.Rows(0).Item("Property_ID").ToString
        lbl_Equipment_Item_ID.Text = dt.Rows(0).Item("Item_ID").ToString


    End Sub
    Protected Sub grdPropertyIntangible_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPropertyIntangible.RowDataBound
        'Here 1
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand'; ")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow'; ")

            'e.Row.Attributes("onmouseover") = "this.style.backgroundColor='#ffcc33';"
            'e.Row.Attributes("onmouseout") = "this.style.backgroundColor='white';"

            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdPropertyIntangible, "Select$" + e.Row.RowIndex.ToString()))

        End If
    End Sub
    Protected Sub LoadIntangible()
        'Here 1
        dtAccount = objDerived.GetDataTable("select * from ams.view_IntangibleAsset where SubClassificationID ='" & drpIntanSubClassification.SelectedValue & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            grdPropertyIntangible.DataSource = createdatatable16(5)
            grdPropertyIntangible.DataBind()
        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable16(3 - dtAccount.Rows.Count))
            End If
            grdPropertyIntangible.DataSource = dtAccount
            grdPropertyIntangible.DataBind()
            grdPropertyIntangible.SelectedIndex = -1

        End If
        loadIntangibleAssetLedger()
    End Sub
    Protected Sub drpIntanSubClassification_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpIntanSubClassification.SelectedIndexChanged
        viewMultiDataGrid.SetActiveView(Me.vwGridViewIntangible)
        LoadIntangible()
    End Sub
    Protected Sub loadIntangibleAssetLedger()
        ''Here 1
        'lblHistoryDetails.Text = "Intangible Asset"
        'btnvehicleledger.CssClass = "Clicked"
        'btnvehiclerepairs.CssClass = "Initial"
        'btnvehicledocattach.CssClass = "Initial"

        'Me.mvledger.SetActiveView(Me.vwledger)

        ''dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        ''dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        'If hdnItemNo.Value = "" Then
        '    'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        '    dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)
        'Else
        '    dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        'End If


        'If dtAccount.Rows.Count < 10 Then
        '    dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        'End If
        'grdLedger.DataSource = dtAccount
        'grdLedger.DataBind()
    End Sub
    Protected Sub grdPropertyIntangible_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPropertyIntangible.SelectedIndexChanged
        If IsDBNull(grdPropertyIntangible.SelectedDataKey("Item_ID")) Then
            hdnItemNo.Value = ""
        Else
            hdnItemNo.Value = grdPropertyIntangible.SelectedDataKey("Item_ID")
        End If
        loadwarehouseForIntangible()
        loadIntangibleAssetLedger()
        LoadIntangibleData()
    End Sub
    Public Sub LoadIntangibleData()
        'dr("Item_Code") = DBNull.Value
        'dr("Title") = DBNull.Value
        'dr("Brand") = DBNull.Value
        'dr("SerialNo") = DBNull.Value
        'dr("Noofdisc") = DBNull.Value
        'dr("Model") = DBNull.Value
        'dr("LicenceDuration") = DBNull.Value
        'dr("Property_Date") = DBNull.Value
        'dr("Cost") = DBNull.Value
        'dr("DepreciationRate") = DBNull.Value
        'dr("DepreciatedValue") = DBNull.Value
        'dr("MarketValue") = DBNull.Value
        'dr("NoofYears") = DBNull.Value
        'dr("Usefullife") = DBNull.Value
        'dr("SalvageValue") = DBNull.Value
        'dr("WarehouseID") = DBNull.Value
        'dr("Bay") = DBNull.Value
        'dr("Column") = DBNull.Value
        'dr("Floor") = DBNull.Value
        'dr("Room") = DBNull.Value
        'dr("Shelves") = DBNull.Value
        'dr("Rack") = DBNull.Value
        'dr("Bin") = DBNull.Value
        'dr("Item_ID") = DBNull.Value
        'dr("Property_ID") = DBNull.Value
        'dr("PropertyDetai_ID") = DBNull.Value
        'dr("IntangibleAssetInfoId") = DBNull.Value
        'dr("IntangibleAssetID") = DBNull.Value
        'dr("Ledger_ID") = DBNull.Value

        txtIntanTitle.Text = grdPropertyIntangible.SelectedDataKey("Title")
        txtIntanBrand.Text = grdPropertyIntangible.SelectedDataKey("Brand")
        txtIntanSerialNo.Text = grdPropertyIntangible.SelectedDataKey("SerialNo")
        txtIntanNoofdisc.Text = grdPropertyIntangible.SelectedDataKey("Noofdisc")
        txtIntanModel.Text = grdPropertyIntangible.SelectedDataKey("Model")
        txtIntanLicenceDuration.Text = grdPropertyIntangible.SelectedDataKey("LicenceDuration")
        txtIntanAcquisitionDate.Text = grdPropertyIntangible.SelectedDataKey("Property_Date")
        txtIntanAcquisitionCost.Text = grdPropertyIntangible.SelectedDataKey("Cost")
        txtIntanDepreciatedRate.Text = grdPropertyIntangible.SelectedDataKey("DepreciationRate")
        txtIntanDepreciatedValue.Text = grdPropertyIntangible.SelectedDataKey("DepreciatedValue")
        txtIntanMarketValue.Text = grdPropertyIntangible.SelectedDataKey("MarketValue")
        txtIntanNoofYears.Text = grdPropertyIntangible.SelectedDataKey("NoofYears")
        txtIntanUsefullife.Text = grdPropertyIntangible.SelectedDataKey("Usefullife")
        txtIntanSalvageValue.Text = grdPropertyIntangible.SelectedDataKey("SalvageValue")
        drpIntanWarehouse.SelectedValue = grdPropertyIntangible.SelectedDataKey("WarehouseID")
        txtIntanBay.Text = grdPropertyIntangible.SelectedDataKey("Bay")
        txtIntanColumn.Text = grdPropertyIntangible.SelectedDataKey("Column")
        txtIntanFloor.Text = grdPropertyIntangible.SelectedDataKey("Floor")
        txtIntanRoom.Text = grdPropertyIntangible.SelectedDataKey("Room")
        txtIntanShelves.Text = grdPropertyIntangible.SelectedDataKey("Shelves")
        txtIntanRack.Text = grdPropertyIntangible.SelectedDataKey("Rack")
        txtIntanBin.Text = grdPropertyIntangible.SelectedDataKey("Bin")

    End Sub
End Class
