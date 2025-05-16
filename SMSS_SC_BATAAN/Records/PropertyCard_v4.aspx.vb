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
Partial Class Records_PropertyCard_v3
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim image As New Image
    Dim obj As New BaseClasses.Items
    Dim BuildingDocumentID As New Integer
    Dim objLandDtl As New ConsolidatedPropertySaving.TBLand_Details
    Dim IntLandId As Integer
    Dim IntProperty_Dtl_ID As Integer
    Dim IntProperty_ID As Integer
    Dim IntM_Item_ID As Integer
    Dim objIntangibleDtl As New ConsolidatedPropertySaving.TBIntangibleAsset_Dtl
    Dim objIntangibleInfo As New ConsolidatedPropertySaving.TBIntangibleAsset_Info
#Region "property"
    Private Property gvAccount() As DataTable
        Get
            Return CType(Session("gvaccount"), DataTable)

        End Get
        Set(ByVal value As DataTable)
            Session("gvaccount") = value
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


    Private Property dtMotors() As DataTable
        Get
            Return CType(Session("dtMotors"), DataTable)

        End Get
        Set(ByVal value As DataTable)
            Session("dtMotors") = value
        End Set
    End Property

    Private Property dtEquipments() As DataTable
        Get
            Return CType(Session("dtEquipments"), DataTable)

        End Get
        Set(ByVal value As DataTable)
            Session("dtEquipments") = value
        End Set
    End Property

    Private Property dtFurnitures() As DataTable
        Get
            Return CType(Session("dtFurnitures"), DataTable)

        End Get
        Set(ByVal value As DataTable)
            Session("dtFurnitures") = value
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
#End Region
#Region "Load_Brgy_Unit"
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
    Public Sub loadBrgy()
        ddBrgy1.DataSource = objDerived.GetDataTable("Select * from dbo.tbl_Brgy_Invent", CommandType.Text)
        ddBrgy1.DataTextField = ("Brgy_Name")
        ddBrgy1.DataValueField = ("Brgy_ID")
        ddBrgy1.DataBind()
        ddBrgy1.Items.Insert(0, "Select")
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
    Public Sub loadMachineUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpMachineUnit.DataSource = dt
        drpMachineUnit.DataTextField = ("Description")
        drpMachineUnit.DataValueField = ("Unit_ID")
        drpMachineUnit.DataBind()
    End Sub
    Public Sub loadEquipmentUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpEquipmentUnit.DataSource = dt
        drpEquipmentUnit.DataTextField = ("Description")
        drpEquipmentUnit.DataValueField = ("Unit_ID")
        drpEquipmentUnit.DataBind()
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
    Public Sub LoadOfficeEquipmentBuildings()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        drpOfficeEquipmentBuilding.DataSource = dt
        drpOfficeEquipmentBuilding.DataTextField = ("Name")
        drpOfficeEquipmentBuilding.DataValueField = ("BuildingId")
        drpOfficeEquipmentBuilding.DataBind()
        drpOfficeEquipmentBuilding.Items.Insert(0, New ListItem("N/A"))
    End Sub
    Public Sub LoadEquipmentBuildings()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        drpEquipmentInstalledBuilding.DataSource = dt
        drpEquipmentInstalledBuilding.DataTextField = ("Name")
        drpEquipmentInstalledBuilding.DataValueField = ("BuildingId")
        drpEquipmentInstalledBuilding.DataBind()
        drpEquipmentInstalledBuilding.Items.Insert(0, New ListItem("N/A"))
    End Sub
    Public Sub LoadFurnitureBuildings()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        drpInstalledAtBuilding.DataSource = dt
        drpInstalledAtBuilding.DataTextField = ("Name")
        drpInstalledAtBuilding.DataValueField = ("BuildingId")
        drpInstalledAtBuilding.DataBind()
        drpInstalledAtBuilding.Items.Insert(0, New ListItem("N/A"))
    End Sub
    Public Sub loadFurnitureUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpFurnitureUnit.DataSource = dt
        drpFurnitureUnit.DataTextField = ("Description")
        drpFurnitureUnit.DataValueField = ("Unit_ID")
        drpFurnitureUnit.DataBind()
    End Sub
    Public Sub loadDepartmentFurnitureUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT DISTINCT UPPER(RC_Name) AS RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
        drpDepartmentFurnifure.DataSource = dt
        drpDepartmentFurnifure.DataTextField = ("RC_Name")
        drpDepartmentFurnifure.DataValueField = ("RC_ID")
        drpDepartmentFurnifure.DataBind()
    End Sub
    Public Sub loadwarehouseForIntangible()
        Dim dt As New DataTable
        dt = obj.GetDataTable("Select warehouse_id, wname From ams.loc_warehouse", CommandType.Text)
        drpIntanWarehouse.DataTextField = ("wname")
        drpIntanWarehouse.DataValueField = ("warehouse_id")
        drpIntanWarehouse.DataSource = dt
        drpIntanWarehouse.DataBind()

    End Sub
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'loadMachineryMainGrid()
        If Not Page.IsPostBack Then

            LoadUpdateDepreciatedValue()
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("select a.ClassificationId,ClassificationName From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID    where b.AllotmentClass_ID = 3 and a.isenable = 1 group by a.ClassificationId,ClassificationName,seqno order by seqno", CommandType.Text)
            drpClassification.DataSource = CType(dt, DataTable)
            drpClassification.DataTextField = ("ClassificationName")
            drpClassification.DataValueField = ("ClassificationId")
            drpClassification.DataBind()

            loadBrgy()

            If Session("Records") = "Search" Then
                Dim GLAccnt As Integer
                If Session("GL_Account") = 521 Then
                    GLAccnt = 1 'LAND
                ElseIf Session("GL_Account") = 520 Then
                    GLAccnt = 2 'BUILDING
                ElseIf Session("GL_Account") = 533 Or Session("GL_Account") = 535 Or Session("GL_Account") = 543 Or Session("GL_Account") = 540 Or Session("GL_Account") = 542 Or Session("GL_Account") = 544 Or Session("GL_Account") = 545 Or Session("GL_Account") = 548 Or Session("GL_Account") = 546 Or Session("GL_Account") = 94 Then
                    GLAccnt = 3 'ALL EQUIPMENT
                ElseIf Session("GL_Account") = 549 Then
                    GLAccnt = 4 'MOTORS
                ElseIf Session("GL_Account") = 537 Then
                    GLAccnt = 5 'MACHINERIES
                ElseIf Session("GL_Account") = 534 Then
                    GLAccnt = 6 'FURNITURE AND FIXTURES
                End If



                gvAccount = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 3 & "'", CommandType.Text)
                ddGlAccount.DataSource = CType(gvAccount, DataTable)
                ddGlAccount.DataTextField = ("GA_Title")
                ddGlAccount.DataValueField = ("GA_ID")
                ddGlAccount.DataBind()

                Session("GLAccount") = GLAccnt
                ' multiviewselected()

                txtAccountSearch.Text = Session("ItemName")
                LoadSearchMe()

                Session("Records") = ""

            Else
                'gvAccount = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 3 & "'", CommandType.Text)
                gvAccount = objDerived.GetDataTable(" Exec dbo.sp_Accounts_Category_v1_02152022 '" & 3 & "','" & drpClassification.SelectedItem.Value & "'", CommandType.Text)
                ddGlAccount.DataSource = CType(gvAccount, DataTable)
                ddGlAccount.DataTextField = ("GA_Title")
                ddGlAccount.DataValueField = ("GA_ID")
                ddGlAccount.DataBind()

                dtMotors = Nothing
                dtEquipments = Nothing
                dtFurnitures = Nothing
                dtMachines = Nothing



            End If
            multiviewselected()
        End If


        ' loadEquipmentLedger()
        txtAccountSearch.Attributes.Add("onkeypress", "return fun1(event,'" & ItemSearch.ClientID & "')")
        txtMotorSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnMotorSerialSearch.ClientID & "')")
        txtSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnEquipmentSerialSearch.ClientID & "')")
        txtMachinerySearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnMachinerySerial.ClientID & "')")
        txtFurnitureSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & Button3.ClientID & "')")

    End Sub
    Protected Sub ddGlAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddGlAccount.SelectedIndexChanged
        Dim x As Integer
        x = ddGlAccount.SelectedValue()
        Session("GA_ID") = ddGlAccount.SelectedValue()
        multiviewselected()
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
    Protected Sub drpClassification_SelectedIndexChanged(sender As Object, e As EventArgs)
        'here123
        gvAccount = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 3 & "','" & drpClassification.SelectedItem.Value & "'", CommandType.Text)
        ddGlAccount.DataSource = CType(gvAccount, DataTable)
        ddGlAccount.DataTextField = ("GA_Title")
        ddGlAccount.DataValueField = ("GA_ID")
        ddGlAccount.DataBind()
        Session("GA_ID") = ddGlAccount.SelectedValue()
        multiviewselected()

    End Sub
    Public Sub multiviewselected()
        'hdnItemNo.value = ""
        If drpClassification.selecteditem.text.contains("roads") Or drpClassification.selecteditem.text.contains("Roads") Then
            'ROADS AND BRIDGES
            txtAccountSearch.Text = ""
            lblHistoryDetails.Text = "LAND"
            LoadLandDTL()
            Me.mvPropertyDetailed.SetActiveView(Me.vwInfrastructures)
            Me.mvInfrastructures.SetActiveView(Me.vwRoad)
            ' Me.mvLand.SetActiveView(Me.vwTechnicalTechnicaldescription)
            'pnlhistoryledger.Visible = False

            LoadRoadBridgesMainGrid()

        Else
            If ddGlAccount.SelectedItem.Value = 1060 Or ddGlAccount.SelectedItem.Value = 1062 Or ddGlAccount.SelectedItem.Value = 1067 Then
                ' LAND AND LAND IMPROVEMENTS
                txtAccountSearch.Text = ""

                lblHistoryDetails.Text = "LAND"
                enableFalseLand()
                LoadLandDTL()
                Me.mvPropertyDetailed.SetActiveView(Me.vwLandInfo)
                Me.mvLand.SetActiveView(Me.vwTechnicalTechnicaldescription)
                'pnlhistoryledger.Visible = False

                LoadLandMainGrid()
                HdfLedgerReport.Value = "Land"

            ElseIf ddGlAccount.SelectedItem.Value = 1082 Or ddGlAccount.SelectedItem.Value = 1085 Then
                ' BUILDINGS
                txtAccountSearch.Text = ""

                lblHistoryDetails.Text = "BUILDING"
                LoadBldgDTL()

                Me.mvPropertyDetailed.SetActiveView(Me.vwBLDG)
                Me.mvBLDG.SetActiveView(Me.vwConstructionDetails)
                'pnlhistoryledger.Visible = False

                LoadBuildingMainGrid()
                'loadBuildingDtl()
                'loadConstructionDtl()

            ElseIf ddGlAccount.SelectedItem.Value = 1166 Or ddGlAccount.SelectedItem.Value = 1175 Or ddGlAccount.SelectedItem.Value = 1178 Then
                ' TRANSPORTATIONS
                'Vehicles
                mvGridviewwithproperty.SetActiveView(Me.vwGridviewwithproperty_Without_Building)
                txtAccountSearch.Text = ""
                txtMotorSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnMotorSerialSearch.ClientID & "')")

                lblHistoryDetails.Text = "TRANSPORTATION"
                Me.mvPropertyDetailed.SetActiveView(Me.vwMotorVehicle)
                Me.mvledger.SetActiveView(Me.vwledger)
                'pnlhistoryledger.Visible = True

                loadMotorMainGrid()

                'loadMotorList()
                'loadMotorInformation()
                'loadMotorLedger()

            ElseIf ddGlAccount.SelectedItem.Value = 1127 Then
                ' MACHINERIES
                mvGridviewwithproperty.SetActiveView(Me.vwGridviewwithproperty_onBuilding)
                txtAccountSearch.Text = ""
                txtMachinerySearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnMachinerySerial.ClientID & "')")

                lblHistoryDetails.Text = "MACHINERY"
                Me.mvPropertyDetailed.SetActiveView(Me.vwmachineries)
                Me.mvledger.SetActiveView(Me.vwledger)

                'pnlhistoryledger.Visible = True

                loadMachineryMainGrid()
                loadMachineUnit()
                LoadMachineInBuildings()

                'loadMachineryList()
                'loadMachineryInformation()
                'loadMachineryLedger()
            ElseIf ddGlAccount.SelectedItem.Value = 1118 Then
                ' FURNITURE AND FIXTURES
                mvGridviewwithproperty.SetActiveView(Me.vwGridviewwithproperty_onBuilding)
                txtAccountSearch.Text = ""
                txtFurnitureSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & Button3.ClientID & "')")

                lblHistoryDetails.Text = "FURNITURE AND FIXTURES HISTORY DETAILS"
                Me.mvPropertyDetailed.SetActiveView(Me.vwfurnitureandfixtures)
                Me.mvledger.SetActiveView(Me.vwledger)
                'pnlhistoryledger.Visible = True

                loadFurnitureMainGrid()
                loadDepartmentFurnitureUnit()
                loadFurnitureUnit()
                LoadFurnitureBuildings()

            ElseIf ddGlAccount.SelectedItem.Value = 1124 Then
                ' Books
                ' mwProperty.SetActiveView(Me.vwGridviewwithproperty)

                mvGridviewwithproperty.SetActiveView(Me.vwGridviewwithproperty_Books)
                lblHistoryDetails.Text = "BOOKS"

                Me.mvPropertyDetailed.SetActiveView(Me.vwBooks)
                Me.mvledger.SetActiveView(Me.vwledger)
                loadBooksMainGrid()
                loadwarehouse()
                loadUnit()
            ElseIf ddGlAccount.SelectedItem.Value = 1151 Then

                mvGridviewwithproperty.SetActiveView(Me.vwMilitary)
                lblHistoryDetails.Text = "MILITARY, POLICE and SECURITY PROPERTY"
                Me.mvPropertyDetailed.SetActiveView(Me.vwGun)
                loadMilitaryMainGrid()
                Me.mvledger.SetActiveView(Me.vwledger)

            ElseIf ddGlAccount.SelectedItem.Value = 1222 Then
                'Intangible Asset'
                'Here 1
                loadIntanSubClassification()
                mwProperty.SetActiveView(Me.vwGridViewIntangible)
                lblHistoryDetails.Text = "INTANGIBLE ASSET"
                LoadIntangible()
                Me.mvPropertyDetailed.SetActiveView(Me.vwIntangibleAsset)
                Me.mvledger.SetActiveView(Me.vwledger)

            Else
                'ALL EQUIPMENTS

                Dim subclassification As String = objDerived.getValue("select SubClassificationName From " &
                                                                " dbo.tbl_SubClassification as c " &
                                                                " inner join tblclassmatrix as b on b.SubClassificationID = c.SubClassificationID" &
                                                                " where b.GA_ID = " & ddGlAccount.SelectedItem.Value, commandtype.text)


                mvGridviewwithproperty.SetActiveView(Me.vwGridviewwithproperty_onBuilding)
                txtAccountSearch.Text = ""
                txtSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnEquipmentSerialSearch.ClientID & "')")

                lblHistoryDetails.Text = "EQUIPMENTS"

                Me.mvPropertyDetailed.SetActiveView(Me.vwEquipment)
                Me.mvledger.SetActiveView(Me.vwledger)
                'pnlhistoryledger.Visible = True

                LoadEquipmentMainGrid()
                LoadEquipmentBuildings()
                loadEquipmentUnit()


            End If

        End If

    End Sub
    Protected Sub gvsearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvsearch.SelectedIndexChanged
        If ddGlAccount.SelectedItem.Value = 1060 Or ddGlAccount.SelectedItem.Value = 1067 Or ddGlAccount.SelectedItem.Value = 1062 Then
            'LAND AND LAND IMPROVEMENTS
            loadLandInformation()

            LoadTechDesc()

            Me.mwProperty.SetActiveView(Me.vwgridviewsearch)
            If IsDBNull(gvsearch.SelectedDataKey("Item_ID")) Then
                hdnItemNo.Value = ""
            Else
                hdnItemNo.Value = gvsearch.SelectedDataKey("Item_ID")

            End If

            loadMachineryLedger()
            'loadLandDocuAttch()
            'loadLandDocuAttch_IndexChanged()
            'loadtecnicaldesc()

        ElseIf ddGlAccount.SelectedItem.Value = 1082 Or ddGlAccount.SelectedItem.Value = 1085 Then
            'BUILDING
            If IsDBNull(gvsearch.SelectedDataKey("Item_ID")) Then
                hdnItemNo.Value = ""
            Else
                hdnItemNo.Value = gvsearch.SelectedDataKey("Item_ID")
            End If
            loadBuildingDtl()
            loadConstructionDtl()
            loadMachineryLedger()

        End If

    End Sub
    Protected Sub gvsearchproperty_without_Building_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Try
        If ddGlAccount.SelectedItem.Value = 1166 Or ddGlAccount.SelectedItem.Value = 1175 Or ddGlAccount.SelectedItem.Value = 1178 Then
            'TRANSPORTATION 
            If gvsearchproperty_without_Building.SelectedDataKey("Item_ID").ToString = "" Then
                grdlistofMotors.DataSource = createdatatable4A(3)
                grdlistofMotors.DataBind()
                LoadMotorDtl()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                loadMotorList()
                grdlistofMotors.SelectedIndex = 0
                Dim subclassification As String = objDerived.GetValue("select SubClassificationName From " &
                                                                " dbo.tbl_SubClassification as c " &
                                                                " inner join tblclassmatrix as b on b.SubClassificationID = c.SubClassificationID" &
                                                                " where b.GA_ID = " & ddGlAccount.SelectedItem.Value, CommandType.Text)


                If subclassification.Contains("Motor Vehicle") Then
                    LoadMotorVehicleInformation()
                    Me.mvVehicleInformation.SetActiveView(Me.vwMotorVehicleInformation)
                ElseIf subclassification.Contains("Watercraft") Then
                    LoadWaterCraftInformation()
                    Me.mvVehicleInformation.SetActiveView(Me.vwWatercrafInformation)
                Else
                    '  LoadMotorVehicleInformationDefault()
                    Me.mvVehicleInformation.SetActiveView(Me.vwMotorVehicleInformationDefault)

                End If
                loadMotorLedger()

                Session("Propertyno") = gvsearchproperty_without_Building.SelectedDataKey("Property_Code")
            End If

        ElseIf ddGlAccount.SelectedItem.Value = 1127 Then
                'MACHINERIES
                If gvsearchproperty_without_Building.SelectedDataKey("Item_ID").ToString = "" Then
                    grdpropertyListofmachinery.DataSource = createdatatable4A(3)
                    grdpropertyListofmachinery.DataBind()
                    LoadMachineryDTL()
                    grdLedger.DataSource = createdatatableledger(10)
                    grdLedger.DataBind()
                Else
                    loadMachineryList()
                    grdpropertyListofmachinery.SelectedIndex = 0

                    loadMachineryInformation()
                    loadMachineryLedger()
                End If
            ElseIf ddGlAccount.SelectedItem.Value = 1118 Then
                'FRUNITURE AND FIXTURE
                If gvsearchproperty_without_Building.SelectedDataKey("Item_ID").ToString = "" Then
                    grdfurnitureandfixtures.DataSource = createdatatable4A(3)
                    grdfurnitureandfixtures.DataBind()
                    LoadFurnitureDTL()
                    grdLedger.DataSource = createdatatableledger(10)
                    grdLedger.DataBind()
                Else
                    loadFurnitureList()
                    grdfurnitureandfixtures.SelectedIndex = 0

                    loadFurnitureInformation()
                    loadFurnitureLedger()
                End If

            Else
                'ALL EQUIPMENTS
                If gvsearchproperty_without_Building.SelectedDataKey("Item_ID").ToString = "" Then
                    grdlistofEuipment.DataSource = createdatatable4A(3)
                    grdlistofEuipment.DataBind()
                    LoadEquipDTL()
                    grdLedger.DataSource = createdatatableledger(10)
                    grdLedger.DataBind()
                Else
                    loadEquipmentList()
                    grdlistofEuipment.SelectedIndex = 0

                    loadEquipmentInformation()
                    loadEquipmentLedger()
                End If


            End If
        'Catch ex As Exception
        '    msgbox(ex.tostring)
        'End Try
    End Sub
    Protected Sub gvsearchproperty_Military_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Try
        If ddGlAccount.SelectedItem.Value = 1166 Or ddGlAccount.SelectedItem.Value = 1175 Or ddGlAccount.SelectedItem.Value = 1178 Then
            'TRANSPORTATION 
            If gvsearchproperty_Military.SelectedDataKey("Item_ID").ToString = "" Then
                grdlistofMotors.DataSource = createdatatable4A(3)
                grdlistofMotors.DataBind()
                LoadMotorDtl()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                loadMotorList()
                grdlistofMotors.SelectedIndex = 0
                loadMotorInformation()
                loadMotorLedger()

            End If

        ElseIf ddGlAccount.SelectedItem.Value = 1127 Then
            'MACHINERIES
            If gvsearchproperty_Military.SelectedDataKey("Item_ID").ToString = "" Then
                grdpropertyListofmachinery.DataSource = createdatatable4A(3)
                grdpropertyListofmachinery.DataBind()
                LoadMachineryDTL()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                loadMachineryList()
                grdpropertyListofmachinery.SelectedIndex = 0

                loadMachineryInformation()
                loadMachineryLedger()
            End If
        ElseIf ddGlAccount.SelectedItem.Value = 1118 Then
            'FRUNITURE AND FIXTURE
            If gvsearchproperty_Military.SelectedDataKey("Item_ID").ToString = "" Then
                grdfurnitureandfixtures.DataSource = createdatatable4A(3)
                grdfurnitureandfixtures.DataBind()
                LoadFurnitureDTL()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                loadFurnitureList()
                grdfurnitureandfixtures.SelectedIndex = 0

                loadFurnitureInformation()
                loadFurnitureLedger()
            End If
        ElseIf ddGlAccount.SelectedItem.Value = 1124 Then
            'BOOKS
            If gvsearchproperty_Military.SelectedDataKey("Item_ID").ToString = "" Then

                LoadBookDtl()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                LoadBooksInformation()
                loadBookLedger()
            End If
        ElseIf ddGlAccount.SelectedItem.Value = 1151 Then
            'MILITARY
            If gvsearchproperty_Military.SelectedDataKey("Item_ID").ToString = "" Then

                LoadMilitaryDtl()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                LoadMilitaryInformation()
                loadMilitaryLedger()
            End If
        Else
            'ALL EQUIPMENTS
            If gvsearchproperty_Military.SelectedDataKey("Item_ID").ToString = "" Then
                grdlistofEuipment.DataSource = createdatatable4A(3)
                grdlistofEuipment.DataBind()
                LoadEquipDTL()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                loadEquipmentList()
                grdlistofEuipment.SelectedIndex = 0

                loadEquipmentInformation()
                loadEquipmentLedger()
            End If


        End If
        'Catch ex As Exception
        '    msgbox(ex.tostring)
        'End Try
    End Sub
    Protected Sub gvsearchproperty_Books_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Try
        If ddGlAccount.SelectedItem.Value = 1166 Or ddGlAccount.SelectedItem.Value = 1175 Or ddGlAccount.SelectedItem.Value = 1178 Then
            'TRANSPORTATION 
            If gvsearchproperty_Books.SelectedDataKey("Item_ID").ToString = "" Then
                grdlistofMotors.DataSource = createdatatable4A(3)
                grdlistofMotors.DataBind()
                LoadMotorDtl()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                loadMotorList()
                grdlistofMotors.SelectedIndex = 0
                loadMotorInformation()
                loadMotorLedger()

            End If

        ElseIf ddGlAccount.SelectedItem.Value = 1127 Then
            'MACHINERIES
            If gvsearchproperty_Books.SelectedDataKey("Item_ID").ToString = "" Then
                grdpropertyListofmachinery.DataSource = createdatatable4A(3)
                grdpropertyListofmachinery.DataBind()
                LoadMachineryDTL()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                loadMachineryList()
                grdpropertyListofmachinery.SelectedIndex = 0

                loadMachineryInformation()
                loadMachineryLedger()
            End If
        ElseIf ddGlAccount.SelectedItem.Value = 1118 Then
            'FRUNITURE AND FIXTURE
            If gvsearchproperty_Books.SelectedDataKey("Item_ID").ToString = "" Then
                grdfurnitureandfixtures.DataSource = createdatatable4A(3)
                grdfurnitureandfixtures.DataBind()
                LoadFurnitureDTL()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                loadFurnitureList()
                grdfurnitureandfixtures.SelectedIndex = 0

                loadFurnitureInformation()
                loadFurnitureLedger()
            End If
        ElseIf ddGlAccount.SelectedItem.Value = 1124 Then
            If gvsearchproperty_Books.SelectedDataKey("Item_ID").ToString = "" Then

                LoadBookDtl()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                Session("Propertyno") = gvsearchproperty_Books.SelectedDataKey("Property_Code")
                LoadBooksInformation()
                loadBookLedger()
            End If
        Else
            'ALL EQUIPMENTS
            If gvsearchproperty_Books.SelectedDataKey("Item_ID").ToString = "" Then
                grdlistofEuipment.DataSource = createdatatable4A(3)
                grdlistofEuipment.DataBind()
                LoadEquipDTL()
                grdLedger.DataSource = createdatatableledger(10)
                grdLedger.DataBind()
            Else
                loadEquipmentList()
                grdlistofEuipment.SelectedIndex = 0

                loadEquipmentInformation()
                loadEquipmentLedger()
            End If


        End If
        'Catch ex As Exception
        '    msgbox(ex.tostring)
        'End Try
    End Sub
    Protected Sub gvsearchRoadBridges_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If ddGlAccount.SelectedItem.Value = 1166 Or ddGlAccount.SelectedItem.Value = 1175 Or ddGlAccount.SelectedItem.Value = 1178 Then
                'TRANSPORTATION 
                If gvsearchproperty_without_Building.SelectedDataKey("Item_ID").ToString = "" Then
                    grdlistofMotors.DataSource = createdatatable4A(3)
                    grdlistofMotors.DataBind()
                    LoadMotorDtl()
                    grdLedger.DataSource = createdatatableledger(10)
                    grdLedger.DataBind()
                Else
                    loadMotorList()
                    grdlistofMotors.SelectedIndex = 0
                    loadMotorInformation()
                    loadMotorLedger()

                End If

            ElseIf ddGlAccount.SelectedItem.Value = 1127 Then
                'MACHINERIES
                If gvsearchproperty_without_Building.SelectedDataKey("Item_ID").ToString = "" Then
                    grdpropertyListofmachinery.DataSource = createdatatable4A(3)
                    grdpropertyListofmachinery.DataBind()
                    LoadMachineryDTL()
                    grdLedger.DataSource = createdatatableledger(10)
                    grdLedger.DataBind()
                Else
                    loadMachineryList()
                    grdpropertyListofmachinery.SelectedIndex = 0

                    loadMachineryInformation()
                    loadMachineryLedger()
                End If
            ElseIf ddGlAccount.SelectedItem.Value = 1118 Then
                'FRUNITURE AND FIXTURE
                If gvsearchproperty_without_Building.SelectedDataKey("Item_ID").ToString = "" Then
                    grdfurnitureandfixtures.DataSource = createdatatable4A(3)
                    grdfurnitureandfixtures.DataBind()
                    LoadFurnitureDTL()
                    grdLedger.DataSource = createdatatableledger(10)
                    grdLedger.DataBind()
                Else
                    loadFurnitureList()
                    grdfurnitureandfixtures.SelectedIndex = 0

                    loadFurnitureInformation()
                    loadFurnitureLedger()
                End If

            Else
                'Roads and Bridges
                If gvsearchRoadBridges.SelectedDataKey("Item_ID").ToString = "" Then
                    grdlistofEuipment.DataSource = createdatatable4A(3)
                    grdlistofEuipment.DataBind()
                    LoadRoadDtl()
                    grdLedger.DataSource = createdatatableledger(10)
                    grdLedger.DataBind()
                Else

                    loadInfrastructureInformation()
                    LoadInfrastructureLedger()
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Protected Sub gvsearchproperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If ddGlAccount.SelectedItem.Value = 1166 Then
                'TRANSPORTATION 
                If gvsearchproperty.SelectedDataKey("Item_ID").ToString = "" Then
                    grdlistofMotors.DataSource = createdatatable4A(3)
                    grdlistofMotors.DataBind()
                    LoadMotorDtl()
                    grdLedger.DataSource = createdatatableledger(10)
                    grdLedger.DataBind()
                Else
                    loadMotorList()
                    grdlistofMotors.SelectedIndex = 0

                    loadMotorInformation()
                    loadMotorLedger()
                End If
            ElseIf ddGlAccount.SelectedItem.Value = 1127 Then
                'MACHINERIES'
                If gvsearchproperty.SelectedDataKey("Item_ID").ToString = "" Then
                    grdpropertyListofmachinery.DataSource = createdatatable4A(3)
                    grdpropertyListofmachinery.DataBind()
                    LoadMachineryDTL()
                    grdLedger.DataSource = createdatatableledger(10)
                    grdLedger.DataBind()
                Else
                    loadMachineryList()
                    grdpropertyListofmachinery.SelectedIndex = 0

                    loadMachineryInformation()
                    loadMachineryLedger()
                End If
            ElseIf ddGlAccount.SelectedItem.Value = 1118 Then
                'FRUNITURE AND FIXTURE
                If gvsearchproperty.SelectedDataKey("Item_ID").ToString = "" Then
                    grdfurnitureandfixtures.DataSource = createdatatable4A(3)
                    grdfurnitureandfixtures.DataBind()
                    LoadFurnitureDTL()
                    grdLedger.DataSource = createdatatableledger(10)
                    grdLedger.DataBind()
                Else
                    loadFurnitureList()
                    grdfurnitureandfixtures.SelectedIndex = 0

                    loadFurnitureInformation()
                    loadFurnitureLedger()
                End If

            Else
                'ALL EQUIPMENTS
                If gvsearchproperty.SelectedDataKey("Item_ID").ToString = "" Then
                    grdlistofEuipment.DataSource = createdatatable4A(3)
                    grdlistofEuipment.DataBind()
                    LoadEquipDTL()
                    grdLedger.DataSource = createdatatableledger(10)
                    grdLedger.DataBind()
                Else
                    loadEquipmentList()
                    grdlistofEuipment.SelectedIndex = 0

                    loadEquipmentInformation()
                    loadEquipmentLedger()
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Protected Sub LoadRoadBridgesMainGrid()

        Me.mwProperty.SetActiveView(Me.vwgridsearchRoadBridges)
        dtAccount = objDerived.GetDataTable("EXEC [AMS].[sp_RecordsList_LandBldg] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
        '
        '  dtAccount = objDerived.GetDataTable("EXEC [dbo].[SMSS_ProtertyRecords] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)

        If dtAccount.Rows.Count = 0 Then
            gvsearchRoadBridges.DataSource = createdatatable2(3)
            gvsearchRoadBridges.DataBind()

            LoadLandDTL()

            grblgydocumentdetails.DataSource = createdatatable3(4)
            grblgydocumentdetails.DataBind()

            loadLandDocuAttch_IndexChanged()

        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable2(3 - dtAccount.Rows.Count))
            End If
            gvsearchRoadBridges.DataSource = dtAccount
            gvsearchRoadBridges.DataBind()
            gvsearchRoadBridges.SelectedIndex = -1

            'loadLandInformation()
            'LoadTechDesc()
            'loadLandDocuAttch()
            'loadLandDocuAttch_IndexChanged()
        End If
        loadMachineryLedger()
    End Sub
    ' MAIN DATA GRIDS
    Protected Sub LoadLandMainGrid()
        'for Land and Land Improvements
        Me.mwProperty.SetActiveView(Me.vwgridviewsearch)

        'dtAccount = objDerived.GetDataTable("Exec [dbo].[SMSS_ProtertyLANDBLDG] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("EXEC [AMS].[sp_RecordsList_LandBldg] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearch.DataSource = createdatatable2(3)
            gvsearch.DataBind()

            LoadLandDTL()

            grblgydocumentdetails.DataSource = createdatatable3(4)
            grblgydocumentdetails.DataBind()

            loadLandDocuAttch_IndexChanged()

        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable2(3 - dtAccount.Rows.Count))
            End If
            gvsearch.DataSource = dtAccount
            gvsearch.DataBind()
            gvsearch.SelectedIndex = -1

            'loadLandInformation()
            'LoadTechDesc()
            'loadLandDocuAttch()
            'loadLandDocuAttch_IndexChanged()
        End If
        loadMachineryLedger()
    End Sub
    'Protected Sub gvsearch_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
    '    dtAccount = objDerived.GetDataTable("EXEC [AMS].[sp_RecordsList_LandBldg] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
    '    gvsearch.PageIndex = e.NewPageIndex
    '    gvsearch.DataSource = dtAccount
    '    gvsearch.DataBind()
    'End Sub
    Protected Sub LoadBuildingMainGrid()
        'for Building
        Me.mwProperty.SetActiveView(Me.vwgridviewsearch)

        'dtAccount = objDerived.GetDataTable("Exec [dbo].[SMSS_ProtertyLANDBLDG] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("EXEC [AMS].[sp_RecordsList_LandBldg] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)

        If dtAccount.Rows.Count = 0 Then
            gvsearch.DataSource = createdatatable2(3)
            gvsearch.DataBind()

            LoadBldgDTL()
            LoadBldgConstruction()
            loadEquipmentLedger()
            grdlistofProfessional.DataSource = createdatatable6(9)
            grdlistofProfessional.DataBind()

        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable2(3 - dtAccount.Rows.Count))
            End If
            gvsearch.DataSource = dtAccount
            gvsearch.DataBind()
            'gvsearch.SelectedIndex = 0

            'loadBuildingDtl()
            'loadConstructionDtl()
        End If
        loadMachineryLedger()
    End Sub
        Protected Sub LoadEquipmentMainGrid()
        ' for Equipments
        Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)
        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Equipments] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_Equipment] '1082','" & ddGlAccount.SelectedValue & "'", CommandType.Text)

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
    Protected Sub loadMotorMainGrid()
        'for Motor Vehicle
        Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)
        Dim subclassification As String = objDerived.getValue("select SubClassificationName From " &
                                                                " dbo.tbl_SubClassification as c " &
                                                                " inner join tblclassmatrix as b on b.SubClassificationID = c.SubClassificationID" &
                                                                " where b.GA_ID = " & ddGlAccount.SelectedItem.Value, commandtype.text)


        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Motor] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty.DataSource = createdatatable15(3)
            gvsearchproperty.DataBind()

            gvsearchproperty_without_Building.DataSource = createdatatable15(3)
            gvsearchproperty_without_Building.DataBind()


            grdlistofMotors.DataSource = createdatatable4A(3)
            grdlistofMotors.DataBind()

            LoadMotorDtl()

            grdLedger.DataSource = createdatatableledger(10)
            grdLedger.DataBind()

        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

            gvsearchproperty_without_Building.DataSource = dtAccount
            gvsearchproperty_without_Building.DataBind()
            gvsearchproperty_without_Building.SelectedIndex = -1
            'hdnItemNo.value = gvsearchproperty_without_Building.SelectedIndex

            'loadMotorList()
            'loadMotorInformation()
            'loadMotorLedger()
        End If


        'If subclassification.Contains("Motor Vehicle") Then
        '    LoadMotorVehicleInformation()
        '    Me.mvVehicleInformation.SetActiveView(Me.vwMotorVehicleInformation)
        'ElseIf subclassification.Contains("Watercraft") Then
        '    Me.mvVehicleInformation.SetActiveView(Me.vwWatercrafInformation)
        'Else
        '    '  LoadMotorVehicleInformationDefault()
        '    Me.mvVehicleInformation.SetActiveView(Me.vwMotorVehicleInformationDefault)

        'End If
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
    Public Function createdatatableledgerIntan(ByVal row As Integer) As DataTable
        'Here 1
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
    Protected Sub loadMilitaryMainGrid()
        'for Motor Vehicle
        Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Motor] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)

        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty.DataSource = createdatatable15(3)
            gvsearchproperty.DataBind()

            gvsearchproperty_Military.DataSource = createdatatable15(3)
            gvsearchproperty_Military.DataBind()


            grdlistofMotors.DataSource = createdatatable4A(3)
            grdlistofMotors.DataBind()

            LoadMotorDtl()

            grdLedger.DataSource = createdatatableledger(10)
            grdLedger.DataBind()

        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

            gvsearchproperty_Military.DataSource = dtAccount
            gvsearchproperty_Military.DataBind()
            gvsearchproperty_Military.SelectedIndex = -1
            ' hdnItemNo.value = gvsearchproperty_without_Building.SelectedIndex

            'loadMotorList()
            ' LoadBooksInformation()
            loadBookLedger()
        End If
    End Sub
    Protected Sub loadBooksMainGrid()
        'for Motor Vehicle
        Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Motor] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty.DataSource = createdatatable15(3)
            gvsearchproperty.DataBind()

            gvsearchproperty_Books.DataSource = createdatatable15(3)
            gvsearchproperty_Books.DataBind()


            grdlistofMotors.DataSource = createdatatable4A(3)
            grdlistofMotors.DataBind()

            LoadMotorDtl()

            grdLedger.DataSource = createdatatableledger(10)
            grdLedger.DataBind()

        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

            gvsearchproperty_Books.DataSource = dtAccount
            gvsearchproperty_Books.DataBind()
            gvsearchproperty_Books.SelectedIndex = -1
            ' hdnItemNo.value = gvsearchproperty_without_Building.SelectedIndex

            'loadMotorList()
            ' LoadBooksInformation()
            loadBookLedger()
        End If
    End Sub
    Protected Sub loadMachineryMainGrid()
        ' for Machinery
        Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)
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
    Protected Sub loadFurnitureMainGrid()
        'for Furniture
        Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)
        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Furniture] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)

        ' dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords]  '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '1082'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_FURNIFURE] '1082'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty.DataSource = createdatatable15(3)
            gvsearchproperty.DataBind()

            grdfurnitureandfixtures.DataSource = createdatatable4A(3)
            grdfurnitureandfixtures.DataBind()

            LoadFurnitureDTL()

            grdLedger.DataSource = createdatatableledger(10)
            grdLedger.DataBind()

        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

            loadFurnitureList()
            loadFurnitureInformation()
            loadFurnitureLedger()
        End If
    End Sub
    Protected Sub LoadAmbulanceMainGrid()

        Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords]  '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty.DataSource = createdatatable15(3)
            gvsearchproperty.DataBind()

            grdListAmbulance.DataSource = createdatatable4A(3)
            grdListAmbulance.DataBind()

            LoadAmbulanceDtlClear()

            grdLedger.DataSource = createdatatableledger(10)
            grdLedger.DataBind()

        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

            LoadAmbulanceList()
            LoadAmbulanceDtl()
            LoadAmbulanceLedger()
        End If
    End Sub
    'PAGE INDEX CHANGING
    Protected Sub gvsearch_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If ddGlAccount.SelectedValue = 1062 Then
            '11102022
            'LAND AND LAND IMPROVEMENTS
            Me.mwProperty.SetActiveView(Me.vwgridviewsearch)

            dtAccount = objDerived.GetDataTable("EXEC [AMS].[sp_RecordsList_LandBldg] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable2(3 - dtAccount.Rows.Count))
            End If
            gvsearch.PageIndex = e.NewPageIndex
            gvsearch.DataSource = dtAccount
            gvsearch.DataBind()
            gvsearch.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 1082 Then
            ' BUILDINGS
            Me.mwProperty.SetActiveView(Me.vwgridviewsearch)

            dtAccount = objDerived.GetDataTable("EXEC [AMS].[sp_RecordsList_LandBldg] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable2(3 - dtAccount.Rows.Count))
            End If
            gvsearch.PageIndex = e.NewPageIndex
            gvsearch.DataSource = dtAccount
            gvsearch.DataBind()
            gvsearch.SelectedIndex = 0
        End If

    End Sub
    Protected Sub gvsearchproperty_without_Building_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If ddGlAccount.SelectedValue = 3 Then
            ' EQUIPMENTS           
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Equipments] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_without_Building.PageIndex = e.NewPageIndex
            gvsearchproperty_without_Building.DataSource = dtAccount
            gvsearchproperty_without_Building.DataBind()
            gvsearchproperty_without_Building.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedItem.Value = 1166 Or ddGlAccount.SelectedItem.Value = 1175 Or ddGlAccount.SelectedItem.Value = 1178 Then
            ' TRANSPORTATIONS
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '" & ddGlAccount.SelectedValue() & "' ", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_without_Building.PageIndex = e.NewPageIndex
            gvsearchproperty_without_Building.DataSource = dtAccount
            gvsearchproperty_without_Building.DataBind()
            gvsearchproperty_without_Building.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 5 Then
            ' MACHINERIES
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Machinery] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_without_Building.PageIndex = e.NewPageIndex
            gvsearchproperty_without_Building.DataSource = dtAccount
            gvsearchproperty_without_Building.DataBind()
            gvsearchproperty_without_Building.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 6 Then
            ' FURNITURE AND FIXTURES
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Furniture] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_without_Building.DataSource = dtAccount
            gvsearchproperty_without_Building.DataBind()
            gvsearchproperty_without_Building.SelectedIndex = 0
        End If
    End Sub
    Protected Sub gvsearchproperty_Military_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If ddGlAccount.SelectedValue = 3 Then
            ' EQUIPMENTS           
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Equipments] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_Military.PageIndex = e.NewPageIndex
            gvsearchproperty_Military.DataSource = dtAccount
            gvsearchproperty_Military.DataBind()
            gvsearchproperty_Military.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 4 Then
            ' TRANSPORTATIONS
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Motor] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_Military.PageIndex = e.NewPageIndex
            gvsearchproperty_Military.DataSource = dtAccount
            gvsearchproperty_Military.DataBind()
            gvsearchproperty_Military.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 5 Then
            ' MACHINERIES
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Machinery] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_Military.PageIndex = e.NewPageIndex
            gvsearchproperty_Military.DataSource = dtAccount
            gvsearchproperty_Military.DataBind()
            gvsearchproperty_Military.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 6 Then
            ' FURNITURE AND FIXTURES
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Furniture] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_Military.DataSource = dtAccount
            gvsearchproperty_Military.DataBind()
            gvsearchproperty_Military.SelectedIndex = 0
        End If
    End Sub
    Protected Sub gvsearchproperty_Books_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If ddGlAccount.SelectedValue = 3 Then
            ' EQUIPMENTS           
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Equipments] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_Books.PageIndex = e.NewPageIndex
            gvsearchproperty_Books.DataSource = dtAccount
            gvsearchproperty_Books.DataBind()
            gvsearchproperty_Books.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 4 Then
            ' TRANSPORTATIONS
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Motor] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_Books.PageIndex = e.NewPageIndex
            gvsearchproperty_Books.DataSource = dtAccount
            gvsearchproperty_Books.DataBind()
            gvsearchproperty_Books.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 5 Then
            ' MACHINERIES
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Machinery] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_Books.PageIndex = e.NewPageIndex
            gvsearchproperty_Books.DataSource = dtAccount
            gvsearchproperty_Books.DataBind()
            gvsearchproperty_Books.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 6 Then
            ' FURNITURE AND FIXTURES
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Furniture] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty_Books.DataSource = dtAccount
            gvsearchproperty_Books.DataBind()
            gvsearchproperty_Books.SelectedIndex = 0
        End If
    End Sub
    Protected Sub gvsearchproperty_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        'here 123
        If ddGlAccount.SelectedValue = "1139" Or ddGlAccount.SelectedValue = "1121" Or ddGlAccount.SelectedValue = "1115" Or ddGlAccount.SelectedValue = "1130" Or ddGlAccount.SelectedValue = "1142" Or ddGlAccount.SelectedValue = "1145" Or ddGlAccount.SelectedValue = "1148" Or ddGlAccount.SelectedValue = "1154" Or ddGlAccount.SelectedValue = "1157" Then
            ' EQUIPMENTS           
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            ' dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Equipments] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_Equipment] '1082'", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.PageIndex = e.NewPageIndex
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 4 Then
            ' TRANSPORTATIONS
            Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Motor] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.PageIndex = e.NewPageIndex
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 1127 Then
            dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_MACHINERY] '1082'", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.PageIndex = e.NewPageIndex
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0
        ElseIf ddGlAccount.SelectedValue = 1118 Then
            ' FURNITURE AND FIXTURES
            'Me.mwProperty.SetActiveView(Me.vwGridviewwithproperty)

            dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_FURNIFURE] '1082'", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.PageIndex = e.NewPageIndex
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

        End If
    End Sub
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
    Public Sub enableTrueLand()
        txtLguCode.Enabled = True
        txtDistrictCode.Enabled = True
        txtMunicipalCode.Enabled = True
        txtBrgyCode.Enabled = True
        txtSectionNo.Enabled = True
        txtParcelNo.Enabled = True
        txtSeriesNo.Enabled = True
        txtPin.Enabled = True
        txtArp.Enabled = True
        txtRevYear.Enabled = True
        txtRptin.Enabled = True
        txtTdn.Enabled = True
        txtDepRate.Enabled = True
        lblDepValue.Enabled = True
        txtLotNo.Enabled = True
        txtBlkNo.Enabled = True
        txtStreetName.Enabled = True
        txtSubdivision.Enabled = True
        txtPhaseNo.Enabled = True
        txtPurok.Enabled = True
        txtSitio.Enabled = True
        txtBrgy.Enabled = True
        txtDistrict.Enabled = True
        txtMunicipal.Enabled = True
        txtRegion.Enabled = True
        txtProvince.Enabled = True
        txtZipCode.Enabled = True
        txtClassification.Enabled = True
        txtSubClass.Enabled = True
        txtLandUse.Enabled = True
        txtStatus1.Enabled = True
        txtTaxable.Enabled = True
        txtArea.Enabled = True
        txtStatus2.Enabled = True
        txtAssessedValue.Enabled = True
        txtAVDate.Enabled = True
        txtMarketValue1.Enabled = True
        txtMVDate.Enabled = True
        txtUnitValue.Enabled = True
        txtUVDate.Enabled = True
        txtAVAmount.Enabled = True
        txtMVAmount.Enabled = True
        ddAssessmentLvl.Enabled = True
        ddAssessmentLvl.Enabled = True
        txtLocation.Enabled = True
        ddBrgy1.Enabled = True
        txtArea1.Enabled = True
        ddTaxDecNo.Enabled = True
        txtPrevOwner.Enabled = True
        txtEAcqDate.Enabled = True
        txtAcqCost.Enabled = True
        txtMarketValue.Enabled = True
        txtAcqMode.Enabled = True
    End Sub

    ' LAND MAIN INFORMATION & DETAILS
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

    ' Land and Land Improvements Tabs
    Protected Sub loadtecnicaldesc()
        'buttons hover'
        btntechnicaldescription.CssClass = "Clicked"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Initial"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Initial"
        'buttons hover'
        gvTechinicaldescription.DataSource = createdatatable1(4)
        gvTechinicaldescription.DataBind()
        Me.mvLand.SetActiveView(Me.vwTechnicalTechnicaldescription)

        Dim td As New DataTable
        td = objDerived.GetDataTable("Select * from [dbo].[View_LandTechnicalDescription] where property_Dtl_id = '" & gvsearch.SelectedDataKey("propertydetai_id") & "'", CommandType.Text)

        If td.Rows.Count = 0 Then
            lblOctNo.Text = ""
            lblTctNo.Text = ""
            lblTechDate.Text = ""
            lblDateReg.Text = ""
            lblCadastralNo.Text = ""
            lblNorth.Text = ""
            lblEast.Text = ""
            lblSouth.Text = ""
            lblWest.Text = ""
        Else
            lblOctNo.Text = td.Rows(0).Item("OctNo").ToString
            lblTctNo.Text = td.Rows(0).Item("TctNo").ToString
            lblTechDate.Text = td.Rows(0).Item("Date").ToString
            lblDateReg.Text = td.Rows(0).Item("DateRegistered").ToString
            lblCadastralNo.Text = td.Rows(0).Item("CadastralNo").ToString
            lblNorth.Text = td.Rows(0).Item("North").ToString
            lblEast.Text = td.Rows(0).Item("East").ToString
            lblSouth.Text = td.Rows(0).Item("South").ToString
            lblWest.Text = td.Rows(0).Item("West").ToString


            dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_LandTechnicalDescription] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable1(3 - dtAccount.Rows.Count))
            End If
            gvTechinicaldescription.DataSource = dtAccount
            gvTechinicaldescription.DataBind()
        End If

    End Sub
    Protected Sub btntechnicaldescription_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btntechnicaldescription.Click
        LoadTechDesc()
    End Sub
    Protected Sub LoadTechDesc()
        dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Land] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            btntechnicaldescription.CssClass = "Clicked"
            btnLandDocument.CssClass = "Initial"
            btnHistory.CssClass = "Initial"
            btnlandvalue.CssClass = "Initial"
            bntapproval.CssClass = "Initial"
            btnimprovements.CssClass = "Initial"
            btnmemoranda.CssClass = "Initial"
            bntDocumentAttach.CssClass = "Initial"

            Me.mvLand.SetActiveView(Me.vwTechnicalTechnicaldescription)

            lblOctNo.Text = ""
            lblTctNo.Text = ""
            lblTechDate.Text = ""
            lblDateReg.Text = ""
            lblCadastralNo.Text = ""
            lblNorth.Text = ""
            lblEast.Text = ""
            lblSouth.Text = ""
            lblWest.Text = ""

            gvTechinicaldescription.DataSource = createdatatable1(4)
            gvTechinicaldescription.DataBind()
        Else
            loadtecnicaldesc()
        End If
    End Sub

    Protected Sub btnLandDocument_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLandDocument.Click
        dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Land] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            btntechnicaldescription.CssClass = "Initial"
            btnLandDocument.CssClass = "Clicked"
            btnHistory.CssClass = "Initial"
            btnlandvalue.CssClass = "Initial"
            bntapproval.CssClass = "Initial"
            btnimprovements.CssClass = "Initial"
            btnmemoranda.CssClass = "Initial"
            bntDocumentAttach.CssClass = "Initial"

            grdlandDocument.DataSource = createdatatable12(4)
            grdlandDocument.DataBind()

            Me.mvLand.SetActiveView(Me.vwLandDocument)
        Else
            loadLandDocuments()
            grdlandDocument.SelectedIndex = 0
            loadlandDocument_IndexChanged()
        End If
    End Sub
    Protected Sub loadLandDocuments()
        'buttons hover'
        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Clicked"
        btnHistory.CssClass = "Initial"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Initial"
        'buttons hover'
        grdlandDocument.DataSource = createdatatable12(4)
        grdlandDocument.DataBind()
        Me.mvLand.SetActiveView(Me.vwLandDocument)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_LandDocument] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "' and ImageCategoryId = 3 ", CommandType.Text)
        If dtAccount.Rows.Count < 5 Then
            dtAccount.Merge(createdatatable12(4 - dtAccount.Rows.Count))
        End If
        grdlandDocument.DataSource = dtAccount
        grdlandDocument.DataBind()

    End Sub
    Protected Sub grdlandDocument_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdlandDocument.SelectedIndexChanged
        loadlandDocument_IndexChanged()
    End Sub
    Protected Sub loadlandDocument_IndexChanged()
        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Clicked"
        btnHistory.CssClass = "Initial"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Initial"

        Try
            Dim id As New Integer
            id = grdlandDocument.SelectedDataKey(0).ToString
            imgeLandocuments.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & id
        Catch ex As Exception
            imgeLandocuments.ImageUrl = "~/images/Blankimage.jpg"

        End Try
        mvLand.SetActiveView(Me.vwLandDocument)
    End Sub

    Protected Sub btnHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Land] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            btntechnicaldescription.CssClass = "Initial"
            btnLandDocument.CssClass = "Initial"
            btnHistory.CssClass = "Clicked"
            btnlandvalue.CssClass = "Initial"
            bntapproval.CssClass = "Initial"
            btnimprovements.CssClass = "Initial"
            btnmemoranda.CssClass = "Initial"
            bntDocumentAttach.CssClass = "Initial"

            gvownership.DataSource = createdatatable5(4)
            gvownership.DataBind()

            Me.mvLand.SetActiveView(vwHistoryofOwnership)
        Else
            loadLandOwner()
            gvownership.SelectedIndex = 0
            loadLandOwner_IndexChanged()
        End If
    End Sub
    Protected Sub loadLandOwner()
        'buttons hover'
        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Clicked"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Initial"
        'buttons hover'
        gvownership.DataSource = createdatatable5(4)
        gvownership.DataBind()
        Me.mvLand.SetActiveView(vwHistoryofOwnership)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_LandOwnerHistory] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable5(3 - dtAccount.Rows.Count))
        End If
        gvownership.DataSource = dtAccount
        gvownership.DataBind()
    End Sub
    Protected Sub gvownership_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvownership.SelectedIndexChanged
        loadLandOwner_IndexChanged()
    End Sub
    Protected Sub loadLandOwner_IndexChanged()
        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Clicked"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Initial"

        mvLand.SetActiveView(Me.vwHistoryofOwnership)

        Dim td As New DataTable
        td = objDerived.GetDataTable("Select * from [dbo].[View_LandOwnerHistory] where OwnershipId = '" & gvownership.SelectedDataKey(0) & "'", CommandType.Text)
        If td.Rows.Count = 0 Then
            lblCorpName.Text = ""
            lblAddress.Text = ""
            lblTelephone.Text = ""
            lblCellphone.Text = ""
            lblEmail.Text = ""
            lblChairman.Text = ""
            lblViceChairman.Text = ""
            lblPresident.Text = ""
            lblSeniorVP.Text = ""
            lblAdministrativeVP.Text = ""
            lblCorporateSec.Text = ""
        Else

            lblCorpName.Text = td.Rows(0).Item("CorporationName").ToString
            lblAddress.Text = td.Rows(0).Item("CorporationAddress").ToString
            lblTelephone.Text = td.Rows(0).Item("TelephoneNo").ToString
            lblCellphone.Text = td.Rows(0).Item("CellphoneNo").ToString
            lblEmail.Text = td.Rows(0).Item("EmailAddress").ToString
            lblChairman.Text = td.Rows(0).Item("Chairman").ToString
            lblViceChairman.Text = td.Rows(0).Item("ViceChairman").ToString
            lblPresident.Text = td.Rows(0).Item("President").ToString
            lblSeniorVP.Text = td.Rows(0).Item("SeniorVicePresident").ToString
            lblAdministrativeVP.Text = td.Rows(0).Item("AssistantVicePresident").ToString
            lblCorporateSec.Text = td.Rows(0).Item("CorporateSecretary").ToString
        End If
    End Sub

    Protected Sub btnlandvalue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlandvalue.Click
        'buttons hover'
        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Initial"
        btnlandvalue.CssClass = "Clicked"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Initial"
        'buttons hover'

        Me.mvLand.SetActiveView(Me.vwLandValutaion)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Land] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            grdlandEvaluation.DataSource = createdatatable13(9)
            grdlandEvaluation.DataBind()
        Else
            dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_LandValuation] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
            If dtAccount.Rows.Count < 8 Then
                dtAccount.Merge(createdatatable13(7 - dtAccount.Rows.Count))
            End If
            grdlandEvaluation.DataSource = dtAccount
            grdlandEvaluation.DataBind()
        End If
    End Sub
    Protected Sub bntapproval_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntapproval.Click
        'buttons hover'
        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Initial"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Clicked"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Initial"

        Me.mvLand.SetActiveView(Me.vwApprovalInformation)

    End Sub
    Protected Sub btnimprovements_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnimprovements.Click
        'buttons hover'
        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Initial"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Clicked"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Initial"
        'buttons hover'
        Me.mvLand.SetActiveView(Me.vwImprovements)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Land] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvLandInprovements.DataSource = createdatatable14(9)
            gvLandInprovements.DataBind()
        Else
            dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_LandImprovement] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
            If dtAccount.Rows.Count < 8 Then
                dtAccount.Merge(createdatatable14(7 - dtAccount.Rows.Count))
            End If
            gvLandInprovements.DataSource = dtAccount
            gvLandInprovements.DataBind()
        End If
    End Sub
    Protected Sub btnmemoranda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmemoranda.Click
        'buttons hover'
        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Initial"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Clicked"
        bntDocumentAttach.CssClass = "Initial"
        'buttons hover'
        Me.mvLand.SetActiveView(Me.vwmemoranda)
    End Sub

    Protected Sub bntDocumentAttach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntDocumentAttach.Click
        dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Land] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            btntechnicaldescription.CssClass = "Initial"
            btnLandDocument.CssClass = "Initial"
            btnHistory.CssClass = "Initial"
            btnlandvalue.CssClass = "Initial"
            bntapproval.CssClass = "Initial"
            btnimprovements.CssClass = "Initial"
            btnmemoranda.CssClass = "Initial"
            bntDocumentAttach.CssClass = "Clicked"

            grblgydocumentdetails.DataSource = createdatatable3(4)
            grblgydocumentdetails.DataBind()

            Me.mvLand.SetActiveView(Me.vwAttachedDocument)
        Else
            loadLandDocuAttch()
            grblgydocumentdetails.SelectedIndex = 0
            loadLandDocuAttch_IndexChanged()
        End If
    End Sub
    Protected Sub loadLandDocuAttch()
        'buttons hover'
        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Initial"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Clicked"
        'buttons hover'

        Me.mvLand.SetActiveView(Me.vwAttachedDocument)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_LandAttchDocument] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable3(3 - dtAccount.Rows.Count))
        End If
        grblgydocumentdetails.DataSource = dtAccount
        grblgydocumentdetails.DataBind()
        grblgydocumentdetails.SelectedIndex = 0

    End Sub
    Protected Sub grblgydocumentdetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grblgydocumentdetails.SelectedIndexChanged
        loadLandDocuAttch_IndexChanged()
    End Sub
    Protected Sub loadLandDocuAttch_IndexChanged()
        Try
            Dim id As New Integer
            id = grblgydocumentdetails.SelectedDataKey(0).ToString
            imgbuildingdoc.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & id
        Catch ex As Exception

            imgbuildingdoc.ImageUrl = "~/images/BlankImage.jpg"
        End Try
        Me.mvLand.SetActiveView(Me.vwAttachedDocument)

        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Initial"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Clicked"
    End Sub


    ' BUILDING MAIN INFORMATION & DETAILS
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

    ' Buildings Tabs
    Protected Sub loadConstructionDtl()
        'buttons hover'
        btnConstructionDetails.CssClass = "Clicked"
        btnBuildingInformation.CssClass = "Initial"
        btnOwnersInformation.CssClass = "Initial"
        btnOccupants.CssClass = "Initial"
        btnPermitApplicationHistory.CssClass = "Initial"
        btnInspectionHistory.CssClass = "Initial"
        btnPaymentHistory.CssClass = "Initial"
        btnbuildingDocumentAttach.CssClass = "Initial"
        'buttons hover'

        grdlistofProfessional.DataSource = createdatatable6(9)
        grdlistofProfessional.DataBind()
        Me.mvBLDG.SetActiveView(Me.vwConstructionDetails)

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("Select * from [View_BuildingConstructionDtl] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)

        If dt.Rows.Count = 0 Then
            LoadBldgConstruction()
        Else
            lblConstructionTyp.Text = dt.Rows(0).Item("ConstructionType").ToString
            lblDateStarted.Text = dt.Rows(0).Item("BuildingDateStarted").ToString
            lblDateCompletion.Text = dt.Rows(0).Item("BuildingDateCompletion").ToString
            lblProjectCost.Text = dt.Rows(0).Item("BuildingProjectCost").ToString
            lblBldgPermitNo.Text = dt.Rows(0).Item("BuildingPermitNo").ToString
            lblDateApplication.Text = dt.Rows(0).Item("DateApplication").ToString
            lblDateIssued.Text = dt.Rows(0).Item("BuildingDateIssued").ToString
            lblBldgRemarks.Text = dt.Rows(0).Item("BuildingRemarks").ToString

            dtAccount = objDerived.GetDataTable("Select * from [View_BuildingConstructionDtl] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
            If dtAccount.Rows.Count < 8 Then
                dtAccount.Merge(createdatatable6(7 - dtAccount.Rows.Count))
            End If
            grdlistofProfessional.DataSource = dtAccount
            grdlistofProfessional.DataBind()
            Me.mvBLDG.SetActiveView(Me.vwConstructionDetails)
        End If
    End Sub
    Protected Sub LoadBldgConstruction()
        lblConstructionTyp.Text = ""
        lblDateStarted.Text = ""
        lblDateCompletion.Text = ""
        lblProjectCost.Text = ""
        lblBldgPermitNo.Text = ""
        lblDateApplication.Text = ""
        lblDateIssued.Text = ""
        lblBldgRemarks.Text = ""
    End Sub
    Protected Sub btnConstructionDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConstructionDetails.Click
        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_Building] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            btnConstructionDetails.CssClass = "Clicked"
            btnBuildingInformation.CssClass = "Initial"
            btnOwnersInformation.CssClass = "Initial"
            btnOccupants.CssClass = "Initial"
            btnPermitApplicationHistory.CssClass = "Initial"
            btnInspectionHistory.CssClass = "Initial"
            btnPaymentHistory.CssClass = "Initial"
            btnbuildingDocumentAttach.CssClass = "Initial"

            grdlistofProfessional.DataSource = createdatatable6(9)
            grdlistofProfessional.DataBind()

            Me.mvBLDG.SetActiveView(Me.vwConstructionDetails)
        Else
            loadConstructionDtl()
        End If
    End Sub

    Protected Sub btnBuildingInformation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuildingInformation.Click
        'buttons hover'
        btnConstructionDetails.CssClass = "Initial"
        btnBuildingInformation.CssClass = "Clicked"
        btnOwnersInformation.CssClass = "Initial"
        btnOccupants.CssClass = "Initial"
        btnPermitApplicationHistory.CssClass = "Initial"
        btnInspectionHistory.CssClass = "Initial"
        btnPaymentHistory.CssClass = "Initial"
        btnbuildingDocumentAttach.CssClass = "Initial"

        Me.mvBLDG.SetActiveView(Me.vwbuildinginformation)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_Building] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            LoadBuildingInfoClear()
        Else
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from [dbo].[View_BuildingDtl] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
            If dt.Rows.Count = 0 Then
                LoadBuildingInfoClear()
            Else
                lblPropertyPin.Text = dt.Rows(0).Item("RealPropertyPin").ToString
                lblPropertyCode.Text = dt.Rows(0).Item("PropertyCode").ToString
                lblAccountCode.Text = dt.Rows(0).Item("AccountCode").ToString
                lblOccupancyCount.Text = dt.Rows(0).Item("OccupancyCount").ToString
                lblMaxBldgOccupancy.Text = dt.Rows(0).Item("MaxBldgOccupancy").ToString
                lblEfficiencyRate.Text = dt.Rows(0).Item("EfficiencyRate").ToString
                lblEntityHandle.Text = dt.Rows(0).Item("EntityHandleUniqueId").ToString
                lblRatio.Text = dt.Rows(0).Item("RuRatio").ToString
                lblComments.Text = dt.Rows(0).Item("Comments").ToString
                lblExtArea.Text = dt.Rows(0).Item("ExtGrossArea").ToString
                lblIntArea.Text = dt.Rows(0).Item("IntGrossArea").ToString
                lblWallArea.Text = dt.Rows(0).Item("ExtWallArea").ToString
                lblAvgPerEmp.Text = dt.Rows(0).Item("AvgAreaEmp").ToString
                lblUsableArea.Text = dt.Rows(0).Item("UsableArea").ToString
                lblRemArea.Text = dt.Rows(0).Item("RemainingArea").ToString
                lblRentArea.Text = dt.Rows(0).Item("RentableArea").ToString
                lblGroupArea.Text = dt.Rows(0).Item("GroupBldgCommonArea").ToString
                lblNonOccu.Text = dt.Rows(0).Item("NonOccuCommonArea").ToString
                lblOccuArea.Text = dt.Rows(0).Item("OccuBldgCommonArea").ToString
                lblRoomArea.Text = dt.Rows(0).Item("RoomBldgCommonArea").ToString
                lblSrvcBldgArea.Text = dt.Rows(0).Item("ServiceBldgCommonArea").ToString
                lblServiceArea.Text = dt.Rows(0).Item("ServiceArea").ToString
                lblSuiteArea.Text = dt.Rows(0).Item("SuiteArea").ToString
                lblTEmpArea.Text = dt.Rows(0).Item("TotalEmpDeptArea").ToString
                lblTGroupArea.Text = dt.Rows(0).Item("TotalGroupArea").ToString
                lblTGroupCom.Text = dt.Rows(0).Item("TotalGroupCommonArea").ToString
                lblTGroupDept.Text = dt.Rows(0).Item("TotalGroupDeptArea").ToString
                lblTLeaseArea.Text = dt.Rows(0).Item("TotalLeaseNegotiatedArea").ToString
                lblTNonOccu.Text = dt.Rows(0).Item("TotalNonOccupArea").ToString
                lblTNonOccuCom.Text = dt.Rows(0).Item("TotalNonOccupCommonArea").ToString
                lblTNonOccuDept.Text = dt.Rows(0).Item("TotalNonOccupDeptArea").ToString
                lblTOccuArea.Text = dt.Rows(0).Item("TotalOccupArea").ToString
                lblTOccuCom.Text = dt.Rows(0).Item("TotalOccupCommonArea").ToString
                lblTOccuDept.Text = dt.Rows(0).Item("TotalOccupDeptArea").ToString
                lblTRoomArea.Text = dt.Rows(0).Item("TotalRoomArea").ToString
                lblTRoomCom.Text = dt.Rows(0).Item("TotalRoomCommonArea").ToString
                lblTRoomDept.Text = dt.Rows(0).Item("TotalRoomDeptArea").ToString
                lblVertPenArea.Text = dt.Rows(0).Item("VertPenArea").ToString
                lblValueMarket.Text = dt.Rows(0).Item("ValueMarket").ToString
                lblValueBook.Text = dt.Rows(0).Item("ValueBook").ToString
                lblTotalIncome.Text = dt.Rows(0).Item("IncomeTotal").ToString
                lblOtherTotal.Text = dt.Rows(0).Item("ExpenseOtherTotal").ToString
                lblOpperTotal.Text = dt.Rows(0).Item("ExpenseOperTotal").ToString
                lblTaxTotal.Text = dt.Rows(0).Item("ExpenseTaxTotal").ToString
                lblUtilityTotal.Text = dt.Rows(0).Item("ExpenseUtilityTotal").ToString
            End If
        End If
    End Sub
    Protected Sub LoadBuildingInfoClear()
        lblPropertyPin.Text = ""
        lblPropertyCode.Text = ""
        lblAccountCode.Text = ""
        lblOccupancyCount.Text = ""
        lblMaxBldgOccupancy.Text = ""
        lblEfficiencyRate.Text = ""
        lblEntityHandle.Text = ""
        lblRatio.Text = ""
        lblComments.Text = ""
        lblExtArea.Text = ""
        lblIntArea.Text = ""
        lblWallArea.Text = ""
        lblAvgPerEmp.Text = ""
        lblUsableArea.Text = ""
        lblRemArea.Text = ""
        lblRentArea.Text = ""
        lblGroupArea.Text = ""
        lblNonOccu.Text = ""
        lblOccuArea.Text = ""
        lblRoomArea.Text = ""
        lblSrvcBldgArea.Text = ""
        lblServiceArea.Text = ""
        lblSuiteArea.Text = ""
        lblTEmpArea.Text = ""
        lblTGroupArea.Text = ""
        lblTGroupCom.Text = ""
        lblTGroupDept.Text = ""
        lblTLeaseArea.Text = ""
        lblTNonOccu.Text = ""
        lblTNonOccuCom.Text = ""
        lblTNonOccuDept.Text = ""
        lblTOccuArea.Text = ""
        lblTOccuCom.Text = ""
        lblTOccuDept.Text = ""
        lblTRoomArea.Text = ""
        lblTRoomCom.Text = ""
        lblTRoomDept.Text = ""
        lblVertPenArea.Text = ""
        lblValueMarket.Text = ""
        lblValueBook.Text = ""
        lblTotalIncome.Text = ""
        lblOtherTotal.Text = ""
        lblOpperTotal.Text = ""
        lblTaxTotal.Text = ""
        lblUtilityTotal.Text = ""
    End Sub
    Protected Sub btnOwnersInformation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOwnersInformation.Click
        'buttons hover'
        btnConstructionDetails.CssClass = "Initial"
        btnBuildingInformation.CssClass = "Initial"
        btnOwnersInformation.CssClass = "Clicked"
        btnOccupants.CssClass = "Initial"
        btnPermitApplicationHistory.CssClass = "Initial"
        btnInspectionHistory.CssClass = "Initial"
        btnPaymentHistory.CssClass = "Initial"
        btnbuildingDocumentAttach.CssClass = "Initial"

        Me.mvBLDG.SetActiveView(Me.vwOwnersInformation)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_Building] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            LoadOwnerInfoClear()
        Else
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from [dbo].[View_BuildingOwner] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
            If dt.Rows.Count = 0 Then
                LoadOwnerInfoClear()
            Else
                lblCorporationName.Text = dt.Rows(0).Item("CorporationName").ToString
                lblCorpAddress.Text = dt.Rows(0).Item("OwnerAddress").ToString
                lblCorpTelephone.Text = dt.Rows(0).Item("OwnerTeleNo").ToString
                lblCorpCellphone.Text = dt.Rows(0).Item("OwnerCellNo").ToString
                lblCorpEmail.Text = dt.Rows(0).Item("OwnerEmailAddress").ToString
                lblBldgChairman.Text = dt.Rows(0).Item("Chairman").ToString
                lblBldgViceChairman.Text = dt.Rows(0).Item("ViceChairman").ToString
                lblBldgPresident.Text = dt.Rows(0).Item("President").ToString
                lblBldgSeniorVP.Text = dt.Rows(0).Item("SeniorVicePresident").ToString
                lblBldgVicePresident.Text = dt.Rows(0).Item("VicePresident").ToString
                lblBldgAssistantVP.Text = dt.Rows(0).Item("AssistantVicePresident").ToString
                lblBldgCorporateSec.Text = dt.Rows(0).Item("CorporateSecretary").ToString

                lblBldgRep1.Text = dt.Rows(0).Item("Representative1").ToString
                lblBldgPosition1.Text = dt.Rows(0).Item("Rep1Position").ToString
                lblBldgAddress1.Text = dt.Rows(0).Item("Rep1Address").ToString
                lblBldgTelephone1.Text = dt.Rows(0).Item("Rep1TeleNo").ToString
                lblBldgCellphone1.Text = dt.Rows(0).Item("Rep1CellNo").ToString
                lblBldgEmail1.Text = dt.Rows(0).Item("Rep1EmailAddress").ToString
                lblRep1Bday.Text = dt.Rows(0).Item("Rep1BirthDate").ToString
                lblRep1Age.Text = dt.Rows(0).Item("Rep1Age").ToString
                lblRep1Address.Text = dt.Rows(0).Item("Rep1Address").ToString
                lblRep1Telephone.Text = dt.Rows(0).Item("Rep1TeleNo").ToString
                lblRep1Cellphone.Text = dt.Rows(0).Item("Rep1CellNo").ToString
                lblRep1Email.Text = dt.Rows(0).Item("Rep1EmailAddress").ToString
                lblRep1Name.Text = dt.Rows(0).Item("Representative1").ToString

                lblBldgRep2.Text = dt.Rows(0).Item("Represenstative2").ToString
                lblBldgPosition2.Text = dt.Rows(0).Item("Rep2Position").ToString
                lblBldgAddress2.Text = dt.Rows(0).Item("Rep2Address").ToString
                lblBldgTelephone2.Text = dt.Rows(0).Item("Rep2TeleNo").ToString
                lblBldgCellphone2.Text = dt.Rows(0).Item("Rep2CellNo").ToString
                lblBldgEmail2.Text = dt.Rows(0).Item("Rep2EmailAddress").ToString
                lblRep2Bday.Text = dt.Rows(0).Item("Rep2BirthDate").ToString
                lblRep2Age.Text = dt.Rows(0).Item("Rep2Age").ToString
                lblRep2Address.Text = dt.Rows(0).Item("Rep2Address").ToString
                lblRep2Telephone.Text = dt.Rows(0).Item("Rep2TeleNo").ToString
                lblRep2Cellphone.Text = dt.Rows(0).Item("Rep2CellNo").ToString
                lblRep2Email.Text = dt.Rows(0).Item("Rep2EmailAddress").ToString
                lblRep2Name.Text = dt.Rows(0).Item("Represenstative2").ToString
            End If
        End If
    End Sub
    Protected Sub LoadOwnerInfoClear()
        lblCorporationName.Text = ""
        lblCorpAddress.Text = ""
        lblCorpTelephone.Text = ""
        lblCorpCellphone.Text = ""
        lblCorpEmail.Text = ""
        lblBldgChairman.Text = ""
        lblBldgViceChairman.Text = ""
        lblBldgPresident.Text = ""
        lblBldgSeniorVP.Text = ""
        lblBldgVicePresident.Text = ""
        lblBldgAssistantVP.Text = ""
        lblBldgCorporateSec.Text = ""

        lblBldgRep1.Text = ""
        lblBldgPosition1.Text = ""
        lblBldgAddress1.Text = ""
        lblBldgTelephone1.Text = ""
        lblBldgCellphone1.Text = ""
        lblBldgEmail1.Text = ""
        lblRep1Bday.Text = ""
        lblRep1Age.Text = ""
        lblRep1Address.Text = ""
        lblRep1Telephone.Text = ""
        lblRep1Cellphone.Text = ""
        lblRep1Email.Text = ""
        lblRep1Name.Text = ""

        lblBldgRep2.Text = ""
        lblBldgPosition2.Text = ""
        lblBldgAddress2.Text = ""
        lblBldgTelephone2.Text = ""
        lblBldgCellphone2.Text = ""
        lblBldgEmail2.Text = ""
        lblRep2Bday.Text = ""
        lblRep2Age.Text = ""
        lblRep2Address.Text = ""
        lblRep2Telephone.Text = ""
        lblRep2Cellphone.Text = ""
        lblRep2Email.Text = ""
        lblRep2Name.Text = ""
    End Sub
    Protected Sub btnOccupants_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOccupants.Click
        'buttons hover'
        btnConstructionDetails.CssClass = "Initial"
        btnBuildingInformation.CssClass = "Initial"
        btnOwnersInformation.CssClass = "Initial"
        btnOccupants.CssClass = "Clicked"
        btnPermitApplicationHistory.CssClass = "Initial"
        btnInspectionHistory.CssClass = "Initial"
        btnPaymentHistory.CssClass = "Initial"
        btnbuildingDocumentAttach.CssClass = "Initial"

        Me.mvBLDG.SetActiveView(Me.vwOccupants)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_Building] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            grdlistofOccupants.DataSource = createdatatable7(8)
            grdlistofOccupants.DataBind()
        Else
            dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_BuildingOccupants] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
            If dtAccount.Rows.Count < 8 Then
                dtAccount.Merge(createdatatable7(7 - dtAccount.Rows.Count))
            End If
            grdlistofOccupants.DataSource = dtAccount
            grdlistofOccupants.DataBind()
        End If
    End Sub
    Protected Sub grdlistofOccupants_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdlistofOccupants.SelectedIndexChanged
        Try
            Dim id As New Integer
            id = grdlistofOccupants.SelectedDataKey(0).ToString
            imgbuildingsketch.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & id
        Catch ex As Exception

        End Try
        Me.mvBLDG.SetActiveView(Me.vwOccupants)
    End Sub
    Protected Sub btnPermitApplicationHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPermitApplicationHistory.Click
        'buttons hover'
        btnConstructionDetails.CssClass = "Initial"
        btnBuildingInformation.CssClass = "Initial"
        btnOwnersInformation.CssClass = "Initial"
        btnOccupants.CssClass = "Initial"
        btnPermitApplicationHistory.CssClass = "Clicked"
        btnInspectionHistory.CssClass = "Initial"
        btnPaymentHistory.CssClass = "Initial"
        btnbuildingDocumentAttach.CssClass = "Initial"

        Me.mvBLDG.SetActiveView(Me.vwpermitapplicationhistory)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_Building] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            grdpermitapplicationhistory.DataSource = createdatatable8(9)
            grdpermitapplicationhistory.DataBind()
        Else
            dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_BuildingPermit] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
            If dtAccount.Rows.Count < 8 Then
                dtAccount.Merge(createdatatable8(7 - dtAccount.Rows.Count))
            End If
            grdpermitapplicationhistory.DataSource = dtAccount
            grdpermitapplicationhistory.DataBind()
        End If
    End Sub
    Protected Sub btnInspectionHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInspectionHistory.Click
        'buttons hover'
        btnConstructionDetails.CssClass = "Initial"
        btnBuildingInformation.CssClass = "Initial"
        btnOwnersInformation.CssClass = "Initial"
        btnOccupants.CssClass = "Initial"
        btnPermitApplicationHistory.CssClass = "Initial"
        btnInspectionHistory.CssClass = "Clicked"
        btnPaymentHistory.CssClass = "Initial"
        btnbuildingDocumentAttach.CssClass = "Initial"

        Me.mvBLDG.SetActiveView(Me.vwInspectionHistory)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_Building] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            grdInspectionHistory.DataSource = createdatatable9(9)
            grdInspectionHistory.DataBind()
        Else
            dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_BuildingInspection] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
            If dtAccount.Rows.Count < 8 Then
                dtAccount.Merge(createdatatable9(7 - dtAccount.Rows.Count))
            End If
            grdInspectionHistory.DataSource = dtAccount
            grdInspectionHistory.DataBind()
        End If
    End Sub
    Protected Sub btnPaymentHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPaymentHistory.Click
        'buttons hover'
        btnConstructionDetails.CssClass = "Initial"
        btnBuildingInformation.CssClass = "Initial"
        btnOwnersInformation.CssClass = "Initial"
        btnOccupants.CssClass = "Initial"
        btnPermitApplicationHistory.CssClass = "Initial"
        btnInspectionHistory.CssClass = "Initial"
        btnPaymentHistory.CssClass = "Clicked"
        btnbuildingDocumentAttach.CssClass = "Initial"

        Me.mvBLDG.SetActiveView(Me.vwPaymentHistory)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_Building] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            grdPaymentHistory.DataSource = createdatatable10(9)
            grdPaymentHistory.DataBind()
        Else
            dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_BuildingPayment] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
            If dtAccount.Rows.Count < 8 Then
                dtAccount.Merge(createdatatable10(7 - dtAccount.Rows.Count))
            End If
            grdPaymentHistory.DataSource = dtAccount
            grdPaymentHistory.DataBind()
        End If
    End Sub

    Protected Sub btnbuildingDocumentAttach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuildingDocumentAttach.Click
        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_Building] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            btnConstructionDetails.CssClass = "Initial"
            btnBuildingInformation.CssClass = "Initial"
            btnOwnersInformation.CssClass = "Initial"
            btnOccupants.CssClass = "Initial"
            btnPermitApplicationHistory.CssClass = "Initial"
            btnInspectionHistory.CssClass = "Initial"
            btnPaymentHistory.CssClass = "Initial"
            btnbuildingDocumentAttach.CssClass = "Clicked"
            '
            grdocumentdetails.DataSource = createdatatable3(4)
            grdocumentdetails.DataBind()

            Me.mvBLDG.SetActiveView(Me.vwbuildingdocumentdetails)
        Else
            loadBuildingAttchDoc()
            grdocumentdetails.SelectedIndex = 0
            loadBldgDocuAttch_IndexChanged()
        End If
    End Sub
    Protected Sub loadBuildingAttchDoc()
        'buttons hover'
        btnConstructionDetails.CssClass = "Initial"
        btnBuildingInformation.CssClass = "Initial"
        btnOwnersInformation.CssClass = "Initial"
        btnOccupants.CssClass = "Initial"
        btnPermitApplicationHistory.CssClass = "Initial"
        btnInspectionHistory.CssClass = "Initial"
        btnPaymentHistory.CssClass = "Initial"
        btnbuildingDocumentAttach.CssClass = "Clicked"
        'buttons hover'
        grdocumentdetails.DataSource = createdatatable3(4)
        grdocumentdetails.DataBind()
        Me.mvBLDG.SetActiveView(vwbuildingdocumentdetails)

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_BuildingAttchDocument] where property_Dtl_id = '" & gvsearch.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable3(3 - dtAccount.Rows.Count))
        End If
        grdocumentdetails.DataSource = dtAccount
        grdocumentdetails.DataBind()
    End Sub
    Protected Sub grdocumentdetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdocumentdetails.SelectedIndexChanged
        loadBldgDocuAttch_IndexChanged()
    End Sub
    Protected Sub loadBldgDocuAttch_IndexChanged()
        Try
            Dim id As New Integer
            id = grdocumentdetails.SelectedDataKey(0).ToString
            ImgBuildingsacnnedDoc.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & id
        Catch ex As Exception
            ImgBuildingsacnnedDoc.ImageUrl = "~/images/Blankimage.jpg"

        End Try
        Me.mvBLDG.SetActiveView(Me.vwbuildingdocumentdetails)

        btnConstructionDetails.CssClass = "Initial"
        btnBuildingInformation.CssClass = "Initial"
        btnOwnersInformation.CssClass = "Initial"
        btnOccupants.CssClass = "Initial"
        btnPermitApplicationHistory.CssClass = "Initial"
        btnInspectionHistory.CssClass = "Initial"
        btnPaymentHistory.CssClass = "Initial"
        btnbuildingDocumentAttach.CssClass = "Clicked"

    End Sub


    ' EQUIPMENTS MAIN INFORMATION AND DETAILS 4428 5586
    Protected Sub loadEquipmentList() '[dbo].[SMSS_EquipmentList]
        '11232022
        ' dtEquipments = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        dtEquipments = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_11022022_EQUIPMENT] '" _
                                               & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" _
                                               & gvsearchproperty.SelectedDataKey("Item_ID") & "','" _
                                               & ddGlAccount.SelectedItem.Value & "','" _
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
    Protected Sub grdlistofEuipment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim gvRow As GridViewRow = Page.FindControl("grdlistofEuipment")
        gvRow = grdlistofEuipment.SelectedRow
        txtHideMe3.Text = gvRow.RowIndex.ToString

        loadEquipmentList()
        loadEquipmentInformation()
        loadEquipmentLedger()

        grdlistofEuipment.SelectedIndex = txtHideMe3.Text
        Session("Propertyno") = grdlistofEuipment.SelectedDataKey("PropertyNo")

        Try
            loadEquipmentInformation()
            loadEquipmentLedger()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub grdlistofEuipment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        'here 123
        'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_11022022_EQUIPMENT] '" _
                                            & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" _
                                            & gvsearchproperty.SelectedDataKey("Item_ID") & "','" _
                                            & ddGlAccount.SelectedItem.Value & "','" _
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

    ' Equipments Tabs
    Protected Sub btnEquipmentLedger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEquipmentLedger.Click
        loadEquipmentLedger()
    End Sub
    Protected Sub btnequipmentrepairs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnequipmentrepairs.Click
        loadEquipmentRepair()
    End Sub
    Protected Sub btnequipmentattachdoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnequipmentattachdoc.Click
        loadEquipmentAttchDocu()
        loadAttchDocuChangeIndex()
    End Sub

    Protected Sub loadEquipmentLedger()
        btnEquipmentLedger.CssClass = "Clicked"
        btnequipmentrepairs.CssClass = "Initial"
        btnequipmentattachdoc.CssClass = "Initial"
        Me.mvledger.SetActiveView(Me.vwledger)

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "' order by dDate", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If hdnItemNo.Value = "" Then
            'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)
        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        End If

        If dtAccount.Rows.Count > 1 Then
            btm_Edit_Office_Equipment.Enabled = False
            btn_Edit_Equipment.Enabled = False
        Else
            btm_Edit_Office_Equipment.Enabled = True
            btn_Edit_Equipment.Enabled = True
        End If

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If
        grdLedger.DataSource = dtAccount
        grdLedger.DataBind()

    End Sub


    Protected Sub LoadInfrastructureLedger()
        btnEquipmentLedger.CssClass = "Clicked"
        btnequipmentrepairs.CssClass = "Initial"
        btnequipmentattachdoc.CssClass = "Initial"
        Me.mvledger.SetActiveView(Me.vwledger)

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "' order by dDate", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If hdnItemNo.Value = "" Then
            'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)
        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        End If

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If
        grdLedger.DataSource = dtAccount
        grdLedger.DataBind()

    End Sub
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = lblHistoryDetails.Text
        cell.ColumnSpan = 3
        cell.BorderWidth = 2
        cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.Text = "DEBIT"
        cell.BorderWidth = 2
        cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        row.Controls.Add(cell)


        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.Text = "CREDIT"
        cell.BorderWidth = 2
        cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        row.Controls.Add(cell)


        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.Text = "BALANCE"
        cell.BorderWidth = 2
        cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        row.Controls.Add(cell)

        row.BackColor = ColorTranslator.FromHtml("WHITE")
        row.ForeColor = ColorTranslator.FromHtml("#12306b")

        grdLedger.HeaderRow.Parent.Controls.AddAt(0, row)
    End Sub

    Protected Sub loadEquipmentRepair()
        btnEquipmentLedger.CssClass = "Initial"
        btnequipmentrepairs.CssClass = "Clicked"
        btnequipmentattachdoc.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwrepairsandmaintenance) '[dbo].[View_EquipmentRepair]

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_RepairAndMaintenance] where PropertyNo = '" & grdlistofEuipment.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable11(7 - dtAccount.Rows.Count))
        End If
        grdrepairsandmaintenance.DataSource = dtAccount
        grdrepairsandmaintenance.DataBind()

    End Sub
    Protected Sub loadEquipmentAttchDocu()
        btnEquipmentLedger.CssClass = "Initial"
        btnequipmentrepairs.CssClass = "Initial"
        btnequipmentattachdoc.CssClass = "Clicked"
        Me.mvledger.SetActiveView(Me.vwdocumentattachment)

        dtAccount = objDerived.GetDataTable("Select *  from AMS.DocumentAttachment where IdentityNo = '" & grdlistofEuipment.SelectedDataKey("PODtl_ID") & "' and TableName = 'AIR_EquipAttchDocu'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable3(7 - dtAccount.Rows.Count))
        End If
        grdpropertydocdetails.DataSource = dtAccount
        grdpropertydocdetails.DataBind()
        grdpropertydocdetails.SelectedIndex = 0

        loadAttchDocuChangeIndex()
    End Sub


    ' TRANSPORTATION MAIN INFORMATION AND DETAILS
    Protected Sub loadMotorList()
        '  dtMotors = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        dtMotors = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_472022] '" _
                                           & gvsearchproperty_without_Building.SelectedDataKey("item_particular_id") & "','" _
                                           & gvsearchproperty_without_Building.SelectedDataKey("Item_ID") & "','" _
                                           & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
        If dtMotors.Rows.Count < 4 Then
            dtMotors.Merge(createdatatable4A(3 - dtMotors.Rows.Count))
        End If
        grdlistofMotors.DataSource = dtMotors
        grdlistofMotors.DataBind()
        grdlistofMotors.SelectedIndex = 0
    End Sub
    Protected Sub grdlistofMotors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            loadMotorInformation()
            loadMotorLedger()

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub grdlistofMotors_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
        End If
        grdlistofMotors.PageIndex = e.NewPageIndex
        grdlistofMotors.DataSource = dtAccount
        grdlistofMotors.DataBind()
        grdlistofMotors.SelectedIndex = 0

    End Sub

    Protected Sub loadMotorInformation()
        Dim itemid As Integer
        If gvsearchproperty_without_Building.SelectedIndex >= 0 Then
            itemid = gvsearchproperty_without_Building.SelectedDataKey("Item_ID")

            Dim subclassification As String = objDerived.GetValue("select SubClassificationName" &
                                                                   " From dbo.m_item as a " &
                                                                  " inner join tblclassmatrix as b on a.Item_ID = b.item_id " &
                                                                    " inner join tbl_SubClassification As c On b.SubClassificationID = c.SubClassificationID" &
                                                                   " where a.Item_ID = " & itemid, CommandType.Text)

            If subclassification.Contains("Motor Vehicle") Then
                LoadMotorVehicleInformation()
                Me.mvVehicleInformation.SetActiveView(Me.vwMotorVehicleInformation)
            ElseIf subclassification.Contains("Watercraft") Then
                LoadWaterCraftInformation()
                Me.mvVehicleInformation.SetActiveView(Me.vwWatercrafInformation)
            Else
                LoadMotorVehicleInformationDefault()
                Me.mvVehicleInformation.SetActiveView(Me.vwMotorVehicleInformationDefault)

            End If
        End If


    End Sub

    Public Sub LoadWaterCraftInformation()
        Dim dt As New DataTable
        '  dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where Property_Dtl_ID = '" & grdlistofMotors.SelectedDataKey("PropertyDetai_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where item_id = '" & gvsearchproperty_without_Building.SelectedDataKey("Item_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadMotorDtl()
        Else

            ' hdnItemNo.value = ""

            txtWatercraftName.Text = dt.Rows(0).Item("Name").ToString
            txtWatercraftPowerInput.Text = dt.Rows(0).Item("PowerInput").ToString
            txtWatercraftDescription.Text = dt.Rows(0).Item("VehicleDesc").ToString
            txtWatercraftWarranty.Text = dt.Rows(0).Item("Warranty").ToString
            txtWatercraftMake.Text = dt.Rows(0).Item("VehicleMake").ToString
            txtWatercraftQuantity.Text = dt.Rows(0).Item("Qty").ToString
            txtWatercraftType.Text = dt.Rows(0).Item("VehicleType").ToString
            txtWatercraftColor.Text = dt.Rows(0).Item("VehicleColor").ToString
            txtWatercraftAcqDate.Text = Convert.ToDateTime(dt.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
            txtWatercraftMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString
            txtWatercraftAcqCost.Text = dt.Rows(0).Item("Cost").ToString
            txtWatercraftNoYears.Text = dt.Rows(0).Item("NoofYears").ToString
            txtWatercraftDepRate.Text = dt.Rows(0).Item("DepRate").ToString
            txtWatercraftUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString
            txtWatercraftDepValue.Text = dt.Rows(0).Item("DepValue").ToString
            txtWatercraftSalvageValue.Text = dt.Rows(0).Item("SalvageValue").ToString
            txtWatercraftMMSI.Text = dt.Rows(0).Item("MMSI").ToString
            txtWatercraftCallSign.Text = dt.Rows(0).Item("CallSign").ToString
            txtWatercraftImoNo.Text = dt.Rows(0).Item("IMOno").ToString
            txtWatercraftHullMaterial.Text = dt.Rows(0).Item("HullMaterial").ToString
            txtWatercraftNoofMast.Text = dt.Rows(0).Item("NoofMast").ToString
            txtWatercraftNoofDecks.Text = dt.Rows(0).Item("NoofDecks").ToString
            txtWatercraftNoofEngine.Text = dt.Rows(0).Item("NoofEngine").ToString
            txtWatercraftMainEngine.Text = dt.Rows(0).Item("MainEngine").ToString

            txtWatercraftHorsePower.Text = dt.Rows(0).Item("HorsePower").ToString
            txtWaterCraftGRT.Text = dt.Rows(0).Item("Grt").ToString
            txtWatercraftNRT.Text = dt.Rows(0).Item("Nrt").ToString
            txtWatercraftLOA.Text = dt.Rows(0).Item("Loa").ToString
            txtWatercraftBreadth.Text = dt.Rows(0).Item("Breadth").ToString
            txtWaterCraftCarryingCapacity.Text = dt.Rows(0).Item("CarryingCapacity").ToString

            lbl_OV_Property_ID.Text = dt.Rows(0).Item("Property_ID").ToString
            lbl_OV_Motor_InfoId.Text = dt.Rows(0).Item("Motor_InfoId").ToString
            lbl_OV_MotorID.Text = dt.Rows(0).Item("MotorID").ToString
            lbl_OV_Item_ID.Text = dt.Rows(0).Item("Item_ID").ToString

            'lblvehicleplate.Text = grdlistofMotors.SelectedDataKey("Barcode")
            'lblvehiclemotorno.Text = dt.Rows(0).Item("MotorNo").ToString
            'txtVehiclemodel.Text = dt.Rows(0).Item("Model").ToString
            'lblvehiclechasisno.Text = dt.Rows(0).Item("ChasisNo").ToString
            ' txtVehiclecolor.Text = dt.Rows(0).Item("VehicleColor").ToString
            ' lblvehiclewheelcapacity.Text = dt.Rows(0).Item("WheelsCapacity").ToString
            'lblvehiclegrossweight.Text = dt.Rows(0).Item("GrossWeight").ToString
            'lblvehicleseat.Text = dt.Rows(0).Item("Seats").ToString
            'lblvehicleowner.Text = dt.Rows(0).Item("VehicleOwner").ToString
            'lblvehicledeclaredname.Text = dt.Rows(0).Item("DeclaredName").ToString
            'lblvehiclebeneficialuser.Text = dt.Rows(0).Item("BeneficialUser").ToString
            'lblvehiclewarranty.Text = dt.Rows(0).Item("Warranty").ToString
            'lblvehiclespecification.Text = dt.Rows(0).Item("VehicleSpecification").ToString
            'lblvehicledatetaken.Text = dt.Rows(0).Item("").ToString
            'lblvehicleuploadedby.Text = dt.Rows(0).Item("").ToString
            'lblvehicleposition.Text = dt.Rows(0).Item("").ToString
            hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString
        End If


    End Sub

    Public Sub LoadMilitaryInformation()
        Dim dt As New DataTable
        '  dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where Property_Dtl_ID = '" & grdlistofMotors.SelectedDataKey("PropertyDetai_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [dbo].[View_EquipmentInformation] where item_id = '" & gvsearchproperty_Military.SelectedDataKey("Item_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        LoadMilitaryDtl()
        If dt.Rows.Count = 0 Then
            LoadMilitaryDtl()
        Else
            Dim category As String = objDerived.GetValue("select description " &
                                                        " From dbo.m_item as a " &
                                                        "inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id " &
                                                        "Where Item_ID = " & gvsearchproperty_Military.SelectedDataKey("Item_ID"), CommandType.Text)
            If category.Contains("Gun") Then
                LoadGunInformation()
                Me.mvPropertyDetailed.SetActiveView(Me.vwGun)

            Else
                LoadMilitaryDefaultInformation()
                Me.mvPropertyDetailed.SetActiveView(Me.vwMilitaryDefault)
            End If

        End If


    End Sub


    Public Sub LoadMilitaryDefaultInformation()
        Dim dt As New DataTable
        '  dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where Property_Dtl_ID = '" & grdlistofMotors.SelectedDataKey("PropertyDetai_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [dbo].[View_EquipmentInformation] where item_id = '" & gvsearchproperty_Military.SelectedDataKey("Item_ID") & "' ORDER BY Date_Accepted", CommandType.Text)

        If dt.Rows.Count = 0 Then
            LoadMilitaryDtl()
        Else
            hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString
            txtMilitaryDefaultName.Text = dt.Rows(0).Item("Name").ToString
            txtMilitaryDefaultUnit.Text = dt.Rows(0).Item("Unit").ToString
            txtMilitaryDefaultQuantity.Text = dt.Rows(0).Item("Qty").ToString
            txtMilitaryDefaultDescription.Text = dt.Rows(0).Item("description").ToString
            txtMilitaryDefaultWarranty.Text = dt.Rows(0).Item("Warranty").ToString
            txtMilitaryDefaultPowerInput.Text = dt.Rows(0).Item("PowerInput").ToString
            txtMilitaryDefaultInstalled.Text = dt.Rows(0).Item("Frame").ToString
            txtMilitaryDefaultModel.Text = dt.Rows(0).Item("Model").ToString
            txtMilitaryDefaultDimension.Text = dt.Rows(0).Item("Dimension").ToString
            txtMilitaryDefaultContractor.Text = dt.Rows(0).Item("MaintenanceContractor").ToString
            txtMilitaryDefaultContactPerson.Text = dt.Rows(0).Item("MaintenanceContactPerson").ToString
            txtMilitaryDefaultCellphoneNo.Text = dt.Rows(0).Item("MaintenanceContactNo").ToString

            txtMilitaryDefaultAcqDate.Text = dt.Rows(0).Item("Received_Date").ToString
            txtMilitaryDefaultAcqCost.Text = dt.Rows(0).Item("Cost").ToString
            txtMilitaryDefaultMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString
            txtMilitaryDefaultNoofYears.Text = dt.Rows(0).Item("NoYears").ToString
            txtMilitaryDefaultUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString
            txttxtMilitaryDefaultSalvageValue.Text = dt.Rows(0).Item("SalvageValue").ToString
            txtMilitaryDefaultDepValue.Text = dt.Rows(0).Item("DepreciationValue").ToString
            txtMilitaryDefaultDepRate.Text = dt.Rows(0).Item("DepreciationRate").ToString

        End If

    End Sub


    Public Sub LoadGunInformation()
        Dim dt As New DataTable
        '  dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where Property_Dtl_ID = '" & grdlistofMotors.SelectedDataKey("PropertyDetai_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [dbo].[View_EquipmentInformation] where item_id = '" & gvsearchproperty_Military.SelectedDataKey("Item_ID") & "' ORDER BY Date_Accepted", CommandType.Text)

        If dt.Rows.Count = 0 Then
            LoadMilitaryDtl()
        Else
            hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString
            txtMilitaryEquipmentName.Text = dt.Rows(0).Item("Name").ToString
            txtMilitaryEquipmentUnit.Text = dt.Rows(0).Item("Unit").ToString
            txtMilitaryEquipmentQuantity.Text = dt.Rows(0).Item("Qty").ToString
            txtMilitaryEquipmentDescription.Text = dt.Rows(0).Item("description").ToString
            txtMilitaryEquipmentFrame.Text = dt.Rows(0).Item("Frame").ToString
            txtMilitaryEquipmentManufacturer.Text = dt.Rows(0).Item("Frame").ToString
            txtMilitaryEquipmentColor.Text = dt.Rows(0).Item("Frame").ToString
            txtMilitaryEquipmentCaliber.Text = dt.Rows(0).Item("Frame").ToString
            txtMilitaryEquipmentCapacityExtended.Text = dt.Rows(0).Item("Frame").ToString
            txtMilitaryEquipmentBarrel.Text = dt.Rows(0).Item("Frame").ToString
            txtMilitaryEquipmentSights.Text = dt.Rows(0).Item("Frame").ToString

            txtMilitaryEquipmentAcqDate.Text = dt.Rows(0).Item("Received_Date").ToString
            txtMilitaryEquipmentAcqCost.Text = dt.Rows(0).Item("Cost").ToString
            txtMilitaryEquipmentMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString
            txtMilitaryEquipmentNoYears.Text = dt.Rows(0).Item("NoYears").ToString
            txtMilitaryEquipmentUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString
            txtMilitaryEquipmentSalvageValue.Text = dt.Rows(0).Item("SalvageValue").ToString
            txtMilitaryEquipmentDepValue.Text = dt.Rows(0).Item("DepreciationValue").ToString
            txtMilitaryEquipmentDepRate.Text = dt.Rows(0).Item("DepreciationRate").ToString

        End If

    End Sub


    Public Sub LoadBooksInformation()
        Dim dt As New DataTable
        '  dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where Property_Dtl_ID = '" & grdlistofMotors.SelectedDataKey("PropertyDetai_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [AMS].[View_BookInformation] where item_id = '" & gvsearchproperty_Books.SelectedDataKey("Item_ID") & "' ORDER BY Date_Accepted", CommandType.Text)

        If dt.Rows.Count = 0 Then
            LoadBookDtl()
        Else
            hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString
            txtbookName.Text = dt.Rows(0).Item("Name").ToString
            drpbookUnit.SelectedValue = dt.Rows(0).Item("unit_id").ToString
            txtbookQuantity.Text = dt.Rows(0).Item("qty").ToString
            txtbookdesciption.Text = dt.Rows(0).Item("Description").ToString
            txtBookPrice.Text = dt.Rows(0).Item("bPrice").ToString
            txtBookISBN.Text = dt.Rows(0).Item("Isbn").ToString
            txtBookClassification.Text = dt.Rows(0).Item("Classification").ToString
            txtBookClassificationCode.Text = dt.Rows(0).Item("ClassificationCode").ToString
            txtbookTitle.Text = dt.Rows(0).Item("Title").ToString
            txtbookAuthor.Text = dt.Rows(0).Item("Author").ToString
            txtBookPublicationDate.Text = dt.Rows(0).Item("PublicationDate").ToString
            txtbookAcqDate.Text = Convert.ToDateTime(dt.Rows(0).Item("Date_Accepted").ToString).ToString("MM/dd/yyy")
            txtbookMarketValue.Text = CDec(dt.Rows(0).Item("MarketValue").ToString).ToString("N2")
            txtbookAcqCost.Text = CDec(dt.Rows(0).Item("Cost").ToString).ToString("N2")
            txtbookNoYears.Text = dt.Rows(0).Item("NoYears").ToString
            txtbookdepreciatedRate.Text = dt.Rows(0).Item("DepreciationRate").ToString
            txtbookUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString
            txtbookdepreciatedvalue.Text = CDec(dt.Rows(0).Item("DepreciationValue").ToString).ToString("N2")
            txtbookSalvageValue.Text = CDec(dt.Rows(0).Item("SalvageValue").ToString).ToString("N2")
            'txtbookBay.Text = dt.Rows(0).Item("Bay").ToString
            'txtbookColumn.Text = dt.Rows(0).Item("Column").ToString
            'txtbookFloor.Text = dt.Rows(0).Item("Floor").ToString
            ''txtbookRoom.Text = dt.Rows(0).Item("Room").ToString
            'txtbookShelves.Text = dt.Rows(0).Item("Shelves").ToString
            'txtbookRack.Text = dt.Rows(0).Item("Rack").ToString
            'txtbookBin.Text = dt.Rows(0).Item("Bin").ToString

            Dim location As String
            location = dt.Rows(0).Item("Location").ToString
            ''Dim locationsplit As String() = location.Split("-")
            'If location.Contains("Bay") Then
            '    txtbookBay.Text = locationsplit(1)
            'ElseIf location.Contains("Column") Then
            '    txtbookColumn.Text = locationsplit(1)
            'ElseIf location.Contains("Floor") Then
            '    txtbookFloor.Text = locationsplit(1)
            'ElseIf location.Contains("Room") Then
            '    txtbookRoom.Text = locationsplit(1)
            'ElseIf location.Contains("Shelves") Then
            '    txtbookShelves.Text = locationsplit(1)
            'ElseIf location.Contains("Rack") Then
            '    txtbookRack.Text = locationsplit(1)
            'ElseIf location.Contains("Bin") Then
            '    txtbookBin.Text = locationsplit(1)
            'End If

            Dim locationsplit As String() = location.Split(" ")
            If location.Contains("Bay") Then
                Dim a As String = locationsplit(0)
                Dim a1 As String() = a.Split("-")
                txtbookBay.Text = a1(1)
                On Error Resume Next
            Else
                txtbookBay.Text = ""
            End If
            If location.Contains("Column") Then
                Dim a As String = locationsplit(1)
                Dim a1 As String() = a.Split("-")
                txtbookColumn.Text = a1(1)
                On Error Resume Next
            Else
                txtbookColumn.Text = ""
            End If
            If location.Contains("Floor") Then
                Dim a As String = locationsplit(2)
                Dim a1 As String() = a.Split("-")
                txtbookFloor.Text = a1(1)
                On Error Resume Next
            Else
                txtbookFloor.Text = ""
            End If
            If location.Contains("Room") Then
                Dim a As String = locationsplit(3)
                Dim a1 As String() = a.Split("-")
                txtbookRoom.Text = a1(1)
                On Error Resume Next
            Else
                txtbookRoom.Text = ""
            End If
            If location.Contains("Shelves") Then
                Dim a As String = locationsplit(4)
                Dim a1 As String() = a.Split("-")
                txtbookShelves.Text = a1(1)
                On Error Resume Next
            Else
                txtbookShelves.Text = ""
            End If
            If location.Contains("Rack") Then

                Dim a As String = locationsplit(5)
                Dim a1 As String() = a.Split("-")
                txtbookRack.Text = a1(1)
                On Error Resume Next
            Else
                txtbookRack.Text = ""
            End If
            If location.Contains("Bin") Then
                Dim a As String = locationsplit(6)
                Dim a1 As String() = a.Split("-")
                txtbookBin.Text = a1(1)
                On Error Resume Next
            Else
                txtbookBin.Text = ""
            End If


            'lbl_book_EquipInfoId.Text = dt.Rows(0).Item("EquipInfoId").ToString
            lbl_book_Property_ID.Text = dt.Rows(0).Item("Property_dtl_ID").ToString
            'lbl_book_EquipmentId.Text = dt.Rows(0).Item("EquipmentId").ToString
            lbl_book_item_ID.Text = dt.Rows(0).Item("Item_ID").ToString


            Dim warehouse As String
            warehouse = dt.Rows(0).Item("warehouseid")
            drpbookWarehouse.SelectedValue = warehouse

        End If

    End Sub
    Public Sub loadwarehouse()
        Dim dt As New DataTable
        dt = obj.GetDataTable("Select warehouse_id, wname From ams.loc_warehouse", CommandType.Text)
        drpbookWarehouse.DataTextField = ("wname")
        drpbookWarehouse.DataValueField = ("warehouse_id")
        drpbookWarehouse.DataSource = dt
        drpbookWarehouse.DataBind()

    End Sub

    Public Sub LoadMotorVehicleInformation()
        Dim dt As New DataTable
        '  dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where Property_Dtl_ID = '" & grdlistofMotors.SelectedDataKey("PropertyDetai_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where item_id = '" & gvsearchproperty_without_Building.SelectedDataKey("Item_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadMotorDtl()
        Else

            hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString
            lblVechicles_Property_ID.Text = dt.Rows(0).Item("Property_ID").ToString
            lblVehicles_Info_ID.Text = dt.Rows(0).Item("Motor_InfoId").ToString
            lblVehicle_Dtl_ID.Text = dt.Rows(0).Item("MotorID").ToString

            txtVehicleName.Text = dt.Rows(0).Item("Name").ToString
            txtVehiclePowerInput.Text = dt.Rows(0).Item("PowerInput").ToString
            txtVehicleDesc.Text = dt.Rows(0).Item("VehicleDesc").ToString
            txtVehicleWarranty.Text = dt.Rows(0).Item("Warranty").ToString
            txtVehicleMake.Text = dt.Rows(0).Item("VehicleMake").ToString
            txtVehicleQuantity.Text = dt.Rows(0).Item("Qty").ToString
            txtVehicleType.Text = dt.Rows(0).Item("VehicleType").ToString
            txtVehicleColor.Text = dt.Rows(0).Item("VehicleColor").ToString
            txtVehicleAcqDate.Text = Convert.ToDateTime(dt.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
            txtVehicleMarketValue.Text = CDec(dt.Rows(0).Item("MarketValue").ToString).ToString("N2")
            txtVehicleAcqCost.Text = CDec(dt.Rows(0).Item("Cost").ToString).ToString("N2")
            txtVehicleNoYears.Text = dt.Rows(0).Item("NoofYears").ToString
            txtVehicleDepRate.Text = dt.Rows(0).Item("DepRate").ToString
            txtVehicleUsefullife.Text = dt.Rows(0).Item("UsefulLife").ToString
            txtVehicleDepValue.Text = CDec(dt.Rows(0).Item("DepValue").ToString).ToString("n2")
            txtVehicleSalvageValue.Text = CDec(dt.Rows(0).Item("SalvageValue").ToString).ToString("N2")

            lblVehicles_Item_ID.Text = dt.Rows(0).Item("Item_ID").ToString


            'lblvehicleplate.Text = grdlistofMotors.SelectedDataKey("Barcode")
            'lblvehiclemotorno.Text = dt.Rows(0).Item("MotorNo").ToString
            'txtVehiclemodel.Text = dt.Rows(0).Item("Model").ToString
            'lblvehiclechasisno.Text = dt.Rows(0).Item("ChasisNo").ToString
            ' txtVehiclecolor.Text = dt.Rows(0).Item("VehicleColor").ToString
            ' lblvehiclewheelcapacity.Text = dt.Rows(0).Item("WheelsCapacity").ToString
            'lblvehiclegrossweight.Text = dt.Rows(0).Item("GrossWeight").ToString
            'lblvehicleseat.Text = dt.Rows(0).Item("Seats").ToString
            'lblvehicleowner.Text = dt.Rows(0).Item("VehicleOwner").ToString
            'lblvehicledeclaredname.Text = dt.Rows(0).Item("DeclaredName").ToString
            'lblvehiclebeneficialuser.Text = dt.Rows(0).Item("BeneficialUser").ToString
            'lblvehiclewarranty.Text = dt.Rows(0).Item("Warranty").ToString
            'lblvehiclespecification.Text = dt.Rows(0).Item("VehicleSpecification").ToString
            'lblvehicledatetaken.Text = dt.Rows(0).Item("").ToString
            'lblvehicleuploadedby.Text = dt.Rows(0).Item("").ToString
            'lblvehicleposition.Text = dt.Rows(0).Item("").ToString

        End If


    End Sub


    Public Sub LoadBridgeInformation()
        Dim dt As New DataTable
        LoadRoadDtl()
        '  dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where Property_Dtl_ID = '" & grdlistofMotors.SelectedDataKey("PropertyDetai_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from  [ams].[View_InfrastructureInformation] where item_id = '" & gvsearchRoadBridges.SelectedDataKey("Item_ID") & "' ORDER BY Property_Date", CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadRoadDtl()
        Else
            hdnItemNo.Value = gvsearchRoadBridges.SelectedDataKey("Item_ID")
            lblRoadBridgeEquipInfoId.Text = dt.Rows(0).Item("EquipInfoId").ToString
            lblRoadBridgeEquipmentId.Text = dt.Rows(0).Item("EquipmentId").ToString
            lblRoadBridgeProperty_ID.Text = dt.Rows(0).Item("Property_ID").ToString

            txtBridgeProjectName.Text = dt.Rows(0).Item("ProjectName").ToString
            txtBridgeID.Text = dt.Rows(0).Item("InfrastructureID").ToString
            txtBridgeName.Text = dt.Rows(0).Item("InfrastructureName").ToString
            '   txtBridgeClassification.text = dt.Rows(0).Item("InfrastructureClassification").ToString
            txtBridgeType.Text = dt.Rows(0).Item("InfrastructureType").ToString
            ' txtBridgeFromStreet.text = dt.Rows(0).Item("InfrastructureFromStreet").ToString
            'txtBridgetoStreet.text = dt.Rows(0).Item("InfrastructureToStreet").ToString
            ' txtBridgeSegmentLock.text = dt.Rows(0).Item("InfrastructureSegmentLock").ToString
            txtBridgeLocation.Text = dt.Rows(0).Item("InfrastructureLocation").ToString
            'txtBridgeLength.text = dt.Rows(0).Item("InfrastructureLength").ToString
            txtNoofLane.Text = dt.Rows(0).Item("InfrastructureNoofLanes").ToString
            'txtBridgeWidth.text = dt.Rows(0).Item("InfrastructureWidth").ToString
            'txtBridgeLaneLength.text = dt.Rows(0).Item("InfrastructureLaneLength").ToString
            'txtBridgeLaneWidth.text = dt.Rows(0).Item("InfrastructureLaneWidth").ToString
            'txtBridgeTrafficDirection.text = dt.Rows(0).Item("InfrastructureTrafficDirection").ToString
            'txtBridgeTrafficVolume.text = dt.Rows(0).Item("InfrastructureTrafficVolume").ToString
            txtTrafficDate.Text = dt.Rows(0).Item("InfrastructureTrafficDate").ToString
            'txtBridgeSpeedLimit.text = dt.Rows(0).Item("InfrastructureSpeedLimit").ToString
            'txtBridgeElevation.text = dt.Rows(0).Item("InfrastructureElevation").ToString
            txtBridgeLfromAddress.Text = dt.Rows(0).Item("LeftLfromAddress").ToString
            txtBridgeLtoAddress.Text = dt.Rows(0).Item("LeftLtoAddress").ToString
            txtBridgeNorthWestWidth.Text = dt.Rows(0).Item("LeftNWshldrWidth").ToString
            txtBridgeRfromAddress.Text = dt.Rows(0).Item("RightRfromAddress").ToString
            txtBridgeRtoAddress.Text = dt.Rows(0).Item("RightRtoAddress").ToString

            txtBridgeStructureNo.Text = dt.Rows(0).Item("InfrastructureNumber").ToString
            txtBridgeRouteSignPrefix.Text = dt.Rows(0).Item("InfrastructureRoutseSignPrefix").ToString
            txtBridgeRouteNo.Text = dt.Rows(0).Item("InfrastructureRouteNo").ToString
            txtBridgeFeaturedIntersected.Text = dt.Rows(0).Item("InfrastructureFeaturedIntersection").ToString
            txtBridgeMilePoint.Text = dt.Rows(0).Item("InfrastructureMilePoint").ToString
            txtBridgeBorderStructNo.Text = dt.Rows(0).Item("InfrastructureBorderStructNo").ToString
            txtBridgeRoadNo.Text = dt.Rows(0).Item("InfrastructureRoadNo").ToString
            txtBridgeNameofRiver.Text = dt.Rows(0).Item("InfrastructureNameofRiver").ToString
            txtBridgeReferencePost.Text = dt.Rows(0).Item("InfrastructureReferencePost").ToString
            txtBridgeEndReferencePost.Text = dt.Rows(0).Item("InfrastructureEndReferencePost").ToString
            txtBridgeStartPosition.Text = dt.Rows(0).Item("InfrastructureStartPosition").ToString
            txtBridgeCurrentStation.Text = dt.Rows(0).Item("InfrastructureCurrentPosition").ToString

            txtBridgeContractor.Text = dt.Rows(0).Item("MaintenanceContractor").ToString
            txtBridgeContactPerson.Text = dt.Rows(0).Item("MaintenanceContactPerson").ToString
            txtBridgeCellphoneNo.Text = dt.Rows(0).Item("MaintenanceContactNo").ToString

            txtBridgeAcqDate.Text = Convert.ToDateTime(dt.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
            txtBridgeAcqCost.Text = dt.Rows(0).Item("Cost").ToString
            'txtRoadNoYears.Text = dt.Rows(0).Item("NoofYears").ToString
            txtBridgeDepRate.Text = dt.Rows(0).Item("DepreciationRate").ToString
            ' txtRoadUsefullife.Text = dt.Rows(0).Item("UsefulLife").ToString
            txtBridgeDepValue.Text = dt.Rows(0).Item("DepreciationValue").ToString
            txtBridgeSalvageValue.Text = dt.Rows(0).Item("SalvageValue").ToString
            txtBridgeMarketValue.Text = dt.Rows(0).Item("marketValue").ToString
            txtBridgeNoYears.Text = dt.Rows(0).Item("NoYears").ToString
            txtBridgeUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString
            txtBridgeSouthEastWidth.Text = dt.Rows(0).Item("RightSEshldrWidth").ToString

            lblRoadBridge_Item_ID.Text = dt.Rows(0).Item("Item_ID").ToString

        End If

    End Sub

    Public Sub LoadRoadInformation()
        Dim dt As New DataTable
        LoadRoadDtl()
        '  dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where Property_Dtl_ID = '" & grdlistofMotors.SelectedDataKey("PropertyDetai_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from  [ams].[View_InfrastructureInformation] where item_id = '" & gvsearchRoadBridges.SelectedDataKey("Item_ID") & "' ORDER BY Property_Date", CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadRoadDtl()
        Else
            hdnItemNo.Value = gvsearchRoadBridges.SelectedDataKey("Item_ID")
            txtRoadProjectName.Text = dt.Rows(0).Item("ProjectName").ToString
            txtRoadID.Text = dt.Rows(0).Item("InfrastructureID").ToString
            txtRoadName.Text = dt.Rows(0).Item("InfrastructureName").ToString
            txtRoadClassification.Text = dt.Rows(0).Item("InfrastructureClassification").ToString
            txtRoadType.Text = dt.Rows(0).Item("InfrastructureType").ToString
            txtRoadFromStreet.Text = dt.Rows(0).Item("InfrastructureFromStreet").ToString
            txtRoadtoStreet.Text = dt.Rows(0).Item("InfrastructureToStreet").ToString
            txtRoadSegmentLock.Text = dt.Rows(0).Item("InfrastructureSegmentLock").ToString
            txtRoadLocation.Text = dt.Rows(0).Item("InfrastructureLocation").ToString
            txtRoadLength.Text = dt.Rows(0).Item("InfrastructureLength").ToString
            txtNoofLane.Text = dt.Rows(0).Item("InfrastructureNoofLanes").ToString
            txtRoadWidth.Text = dt.Rows(0).Item("InfrastructureWidth").ToString
            txtRoadLaneLength.Text = dt.Rows(0).Item("InfrastructureLaneLength").ToString
            txtRoadLaneWidth.Text = dt.Rows(0).Item("InfrastructureLaneWidth").ToString
            txtRoadTrafficDirection.Text = dt.Rows(0).Item("InfrastructureTrafficDirection").ToString
            txtRoadTrafficVolume.Text = dt.Rows(0).Item("InfrastructureTrafficVolume").ToString
            txtTrafficDate.Text = dt.Rows(0).Item("InfrastructureTrafficDate").ToString
            txtRoadSpeedLimit.Text = dt.Rows(0).Item("InfrastructureSpeedLimit").ToString
            txtRoadElevation.Text = dt.Rows(0).Item("InfrastructureElevation").ToString
            txtRoadSurfaceType.Text = dt.Rows(0).Item("InfrastructureSurfaceType").ToString
            txtRoadSurfaceCondition.Text = dt.Rows(0).Item("InfrastructureSurfaceCondition").ToString
            txtRoadLfromAddress.Text = dt.Rows(0).Item("LeftLfromAddress").ToString
            txtRoadLtoAddress.Text = dt.Rows(0).Item("LeftLtoAddress").ToString
            txtRoadNorthWestWidth.Text = dt.Rows(0).Item("LeftNWshldrWidth").ToString
            txtRoadRfromAddress.Text = dt.Rows(0).Item("RightRfromAddress").ToString
            txtRoadRtoAddress.Text = dt.Rows(0).Item("RightRtoAddress").ToString

            txtRoadAcqDate.Text = Convert.ToDateTime(dt.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
            txtRoadAcqCost.Text = dt.Rows(0).Item("Cost").ToString
            txtRoadNoYears.Text = dt.Rows(0).Item("NoYears").ToString
            txtRoadequipmentdepreciatedRate.Text = dt.Rows(0).Item("DepreciationRate").ToString
            txtRoadUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString
            txtRoadequipmentdepreciatedvalue.Text = dt.Rows(0).Item("DepreciationValue").ToString
            txtRoadSalvageValue.Text = dt.Rows(0).Item("SalvageValue").ToString
            txtRoadMarketValue.Text = dt.Rows(0).Item("marketValue").ToString

            txtRoadSouthEastWidth.Text = dt.Rows(0).Item("RightSEshldrWidth").ToString
            txtRoadContractor.Text = dt.Rows(0).Item("MaintenanceContactNo").ToString
            txtRoadContactPerson.Text = dt.Rows(0).Item("MaintenanceContactPerson").ToString
            txtRoadCellphoneNo.Text = dt.Rows(0).Item("MaintenanceContractor").ToString

            lbl_Road_EquipInfoId.Text = dt.Rows(0).Item("EquipInfoId").ToString
            lbl_Road_EquipmentId.Text = dt.Rows(0).Item("EquipmentId").ToString
            lbl_Road_Property_ID.Text = dt.Rows(0).Item("Property_ID").ToString
            lbl_Road_Item_ID.Text = dt.Rows(0).Item("Item_ID").ToString

        End If


    End Sub

    Public Sub LoadMotorVehicleInformationDefault()
        Dim dt As New DataTable
        '  dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where Property_Dtl_ID = '" & grdlistofMotors.SelectedDataKey("PropertyDetai_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where item_id = '" & gvsearchproperty_without_Building.SelectedDataKey("Item_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadMotorDtl()
        Else
            lblvehiclename.Text = dt.Rows(0).Item("Name").ToString
            lblvehicleplate.Text = grdlistofMotors.SelectedDataKey("Barcode")
            lblvehiclemotorno.Text = dt.Rows(0).Item("MotorNo").ToString
            lblvehiclemodel.Text = dt.Rows(0).Item("Model").ToString
            lblvehiclechasisno.Text = dt.Rows(0).Item("ChasisNo").ToString
            lblvehiclecolor.Text = dt.Rows(0).Item("VehicleColor").ToString
            lblvehiclewheelcapacity.Text = dt.Rows(0).Item("WheelsCapacity").ToString
            lblvehiclegrossweight.Text = dt.Rows(0).Item("GrossWeight").ToString
            lblvehicleseat.Text = dt.Rows(0).Item("Seats").ToString
            lblvehicleowner.Text = dt.Rows(0).Item("VehicleOwner").ToString
            lblvehicledeclaredname.Text = dt.Rows(0).Item("DeclaredName").ToString
            lblvehiclebeneficialuser.Text = dt.Rows(0).Item("BeneficialUser").ToString
            lblvehiclewarranty.Text = dt.Rows(0).Item("Warranty").ToString
            lblvehiclespecification.Text = dt.Rows(0).Item("VehicleSpecification").ToString
            'lblvehicledatetaken.Text = dt.Rows(0).Item("").ToString
            'lblvehicleuploadedby.Text = dt.Rows(0).Item("").ToString
            'lblvehicleposition.Text = dt.Rows(0).Item("").ToString

        End If


    End Sub

    Protected Sub LoadMilitaryDtl()
        hdnItemNo.Value = ""
        txtMilitaryEquipmentName.Text = ""
        txtMilitaryEquipmentUnit.Text = ""
        txtMilitaryEquipmentQuantity.Text = ""
        txtMilitaryEquipmentDescription.Text = ""
        txtMilitaryEquipmentFrame.Text = ""
        txtMilitaryEquipmentManufacturer.Text = ""
        txtMilitaryEquipmentColor.Text = ""
        txtMilitaryEquipmentCaliber.Text = ""
        txtMilitaryEquipmentCapacityExtended.Text = ""
        txtMilitaryEquipmentBarrel.Text = ""
        txtMilitaryEquipmentSights.Text = ""

        txtMilitaryEquipmentAcqDate.Text = ""
        txtMilitaryEquipmentAcqCost.Text = ""
        txtMilitaryEquipmentMarketValue.Text = ""
        txtMilitaryEquipmentNoYears.Text = ""
        txtMilitaryEquipmentUsefulLife.Text = ""
        txtMilitaryEquipmentSalvageValue.Text = ""
        txtMilitaryEquipmentDepValue.Text = ""
        txtMilitaryEquipmentDepRate.Text = ""

    End Sub

    Protected Sub LoadBookDtl()
        txtbookName.Text = ""
        txtbookUnit.Text = ""
        txtbookQuantity.Text = ""
        txtbookdesciption.Text = ""
        txtBookPrice.Text = ""
        txtBookClassification.Text = ""
        txtBookClassificationCode.Text = ""
        txtbookTitle.Text = ""
        txtbookAuthor.Text = ""
        txtBookPublicationDate.Text = ""
        txtbookAcqDate.Text = ""
        txtbookMarketValue.Text = ""
        txtbookAcqCost.Text = ""
        txtbookNoYears.Text = ""
        txtbookdepreciatedRate.Text = ""
        txtbookUsefulLife.Text = ""
        txtbookdepreciatedvalue.Text = ""
        txtbookSalvageValue.Text = ""
        txtbookBay.Text = ""
        txtbookColumn.Text = ""
        txtbookRack.Text = ""
        txtbookFloor.Text = ""
        txtbookBin.Text = ""
        txtbookShelves.Text = ""
        txtbookRoom.Text = ""
        loadwarehouse()
    End Sub

    Protected Sub LoadMotorDtl()
        lblvehiclename.Text = ""
        lblvehicleplate.Text = ""
        lblvehiclemotorno.Text = ""
        lblvehiclemodel.Text = ""
        lblvehiclechasisno.Text = ""
        lblvehiclecolor.Text = ""
        lblvehiclewheelcapacity.Text = ""
        lblvehiclegrossweight.Text = ""
        lblvehicleseat.Text = ""
        lblvehicleowner.Text = ""
        lblvehicledeclaredname.Text = ""
        lblvehiclebeneficialuser.Text = ""
        lblvehiclewarranty.Text = ""
        lblvehiclespecification.Text = ""

        '--Watercrafts
        txtWatercraftName.Text = ""
        txtWatercraftDescription.Text = ""
        txtWatercraftPowerInput.Text = ""
        txtWatercraftPowerInput.Text = ""
        txtWatercraftWarranty.Text = ""
        txtWatercraftMake.Text = ""
        txtWatercraftQuantity.Text = ""
        txtWatercraftType.Text = ""
        txtWatercraftColor.Text = ""
        txtEAcqDate.Text = ""
        txtWatercraftMarketValue.Text = ""
        txtWatercraftAcqCost.Text = ""
        txtWatercraftNoYears.Text = ""
        txtWatercraftDepRate.Text = ""
        txtWatercraftUsefulLife.Text = ""
        txtWatercraftDepValue.Text = ""
        txtWatercraftSalvageValue.Text = ""
        txtWatercraftMMSI.Text = ""
        txtWatercraftCallSign.Text = ""
        txtWatercraftImoNo.Text = ""
        txtWatercraftHullMaterial.Text = ""
        txtWatercraftNoofMast.Text = ""
        txtWatercraftNoofDecks.Text = ""
        txtWatercraftNoofDecks.Text = ""
        txtWatercraftNoofEngine.Text = ""
        txtWatercraftMainEngine.Text = ""

        txtWatercraftHorsePower.Text = ""
        txtWaterCraftGRT.Text = ""
        txtWatercraftNRT.Text = ""
        txtWatercraftLOA.Text = ""
        txtWatercraftBreadth.Text = ""
        txtWaterCraftCarryingCapacity.Text = ""
    End Sub
    Protected Sub LoadRoadDtl()

        txtRoadProjectName.Text = ""
        txtRoadID.Text = ""
        txtRoadName.Text = ""
        txtRoadClassification.Text = ""
        txtRoadType.Text = ""
        txtRoadFromStreet.Text = ""
        txtRoadtoStreet.Text = ""
        txtRoadSegmentLock.Text = ""
        txtRoadLocation.Text = ""
        txtRoadLength.Text = ""
        txtNoofLane.Text = ""
        txtRoadWidth.Text = ""
        txtRoadLaneLength.Text = ""
        txtRoadLaneWidth.Text = ""
        txtRoadTrafficDirection.Text = ""
        txtRoadTrafficVolume.Text = ""
        txtTrafficDate.Text = ""
        txtRoadSpeedLimit.Text = ""
        txtRoadElevation.Text = ""
        txtRoadSurfaceType.Text = ""
        txtRoadSurfaceCondition.Text = ""
        txtRoadLfromAddress.Text = ""
        txtRoadLtoAddress.Text = ""
        txtRoadNorthWestWidth.Text = ""
        txtRoadRfromAddress.Text = ""
        txtRoadRtoAddress.Text = ""

        txtRoadAcqDate.Text = ""
        txtRoadAcqCost.Text = ""
        'txtRoadNoYears.Text = dt.Rows(0).Item("NoofYears").ToString
        txtRoadequipmentdepreciatedRate.Text = ""
        ' txtRoadUsefullife.Text = dt.Rows(0).Item("UsefulLife").ToString
        txtRoadequipmentdepreciatedvalue.Text = ""
        txtRoadSalvageValue.Text = ""
        txtRoadMarketValue.Text = ""


        'Bridge
        hdnItemNo.Value = ""
        txtBridgeProjectName.Text = ""
        txtBridgeID.Text = ""
        txtBridgeName.Text = ""
        '   txtBridgeClassification.text = dt.Rows(0).Item("InfrastructureClassification").ToString
        txtBridgeType.Text = ""
        ' txtBridgeFromStreet.text = dt.Rows(0).Item("InfrastructureFromStreet").ToString
        'txtBridgetoStreet.text = dt.Rows(0).Item("InfrastructureToStreet").ToString
        ' txtBridgeSegmentLock.text = dt.Rows(0).Item("InfrastructureSegmentLock").ToString
        txtBridgeLocation.Text = ""
        'txtBridgeLength.text = dt.Rows(0).Item("InfrastructureLength").ToString
        txtNoofLane.Text = ""
        'txtBridgeWidth.text = dt.Rows(0).Item("InfrastructureWidth").ToString
        'txtBridgeLaneLength.text = dt.Rows(0).Item("InfrastructureLaneLength").ToString
        'txtBridgeLaneWidth.text = dt.Rows(0).Item("InfrastructureLaneWidth").ToString
        'txtBridgeTrafficDirection.text = dt.Rows(0).Item("InfrastructureTrafficDirection").ToString
        'txtBridgeTrafficVolume.text = dt.Rows(0).Item("InfrastructureTrafficVolume").ToString
        txtTrafficDate.Text = ""
        'txtBridgeSpeedLimit.text = dt.Rows(0).Item("InfrastructureSpeedLimit").ToString
        'txtBridgeElevation.text = dt.Rows(0).Item("InfrastructureElevation").ToString
        txtBridgeLfromAddress.Text = ""
        txtBridgeLtoAddress.Text = ""
        txtBridgeNorthWestWidth.Text = ""
        txtBridgeRfromAddress.Text = ""
        txtBridgeRtoAddress.Text = ""

        txtBridgeStructureNo.Text = ""
        txtBridgeRouteSignPrefix.Text = ""
        txtBridgeRouteNo.Text = ""
        txtBridgeFeaturedIntersected.Text = ""
        txtBridgeMilePoint.Text = ""
        txtBridgeBorderStructNo.Text = ""
        txtBridgeRoadNo.Text = ""
        txtBridgeNameofRiver.Text = ""
        txtBridgeReferencePost.Text = ""
        txtBridgeEndReferencePost.Text = ""
        txtBridgeStartPosition.Text = ""
        txtBridgeCurrentStation.Text = ""

        txtBridgeContractor.Text = ""
        txtBridgeContactPerson.Text = ""
        txtBridgeCellphoneNo.Text = ""

        txtBridgeAcqDate.Text = ""
        txtBridgeAcqCost.Text = ""
        'txtRoadNoYears.Text = dt.Rows(0).Item("NoofYears").ToString
        txtBridgeDepRate.Text = ""
        ' txtRoadUsefullife.Text = dt.Rows(0).Item("UsefulLife").ToString
        txtBridgeDepValue.Text = ""
        txtBridgeSalvageValue.Text = ""
        txtBridgeMarketValue.Text = ""

    End Sub
    ' Transporation Tabs   
    Protected Sub btnvehicleledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnvehicleledger.Click
        loadMotorLedger()
    End Sub
    Protected Sub btnvehiclerepairs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnvehiclerepairs.Click
        loadMotorRepair()
    End Sub
    Protected Sub btnvehicledocattach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnvehicledocattach.Click
        loadMotorAttchDocu()
        loadAttchDocuChangeIndex()
    End Sub


    Protected Sub loadMilitaryLedger()
        lblHistoryDetails.Text = "Military, Police and Security Property"
        btnvehicleledger.CssClass = "Clicked"
        btnvehiclerepairs.CssClass = "Initial"
        btnvehicledocattach.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwledger)

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If hdnItemNo.Value = "" Then
            'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)
        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        End If

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If
        grdLedger.DataSource = dtAccount
        grdLedger.DataBind()
    End Sub
    Protected Sub loadIntangibleAssetLedger()
        'Here 1
        lblHistoryDetails.Text = "Intangible Asset"
        btnvehicleledger.CssClass = "Clicked"
        btnvehiclerepairs.CssClass = "Initial"
        btnvehicledocattach.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwledger)

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If hdnItemNo.Value = "" Then
            'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)
        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        End If


        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If
        grdLedger.DataSource = dtAccount
        grdLedger.DataBind()
    End Sub

    Protected Sub loadBookLedger()
        lblHistoryDetails.Text = "Book"
        btnvehicleledger.CssClass = "Clicked"
        btnvehiclerepairs.CssClass = "Initial"
        btnvehicledocattach.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwledger)

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If hdnItemNo.Value = "" Then
            'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)
        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        End If

        If dtAccount.Rows.Count > 1 Then
            btn_EditBooks.Enabled = False
        Else
            btn_EditBooks.Enabled = True
        End If

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If
        grdLedger.DataSource = dtAccount
        grdLedger.DataBind()
    End Sub

    Protected Sub loadMotorLedger()
        lblHistoryDetails.Text = "TRANSPORTATION"
        btnvehicleledger.CssClass = "Clicked"
        btnvehiclerepairs.CssClass = "Initial"
        btnvehicledocattach.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwledger)

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If hdnItemNo.Value = "" Then
            'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)
        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
        End If


        If dtAccount.Rows.Count > 1 Then
            btnEditVehicle.Enabled = False
            btn_edit_other_vehicles.Enabled = False
        Else
            btnEditVehicle.Enabled = True
            btn_edit_other_vehicles.Enabled = True
        End If
        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If
        grdLedger.DataSource = dtAccount
        grdLedger.DataBind()
    End Sub
    Protected Sub loadMotorRepair()
        btnvehicleledger.CssClass = "Initial"
        btnvehiclerepairs.CssClass = "Clicked"
        btnvehicledocattach.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwrepairsandmaintenance)

        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_MotorRepairMaintenance] where property_Dtl_id = '" & grdlistofMotors.SelectedDataKey(1) & "'", CommandType.Text)
        'If dtAccount.Rows.Count < 8 Then
        '    dtAccount.Merge(createdatatable11(7 - dtAccount.Rows.Count))
        'End If
        'grdrepairsandmaintenance.DataSource = dtAccount
        'grdrepairsandmaintenance.DataBind()


        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_RepairAndMaintenance] where PropertyNo = '" & grdlistofMotors.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable11(7 - dtAccount.Rows.Count))
        End If
        grdrepairsandmaintenance.DataSource = dtAccount
        grdrepairsandmaintenance.DataBind()

    End Sub
    Protected Sub loadMotorAttchDocu()
        btnvehicleledger.CssClass = "Initial"
        btnvehiclerepairs.CssClass = "Initial"
        btnvehicledocattach.CssClass = "Clicked"

        Me.mvledger.SetActiveView(Me.vwdocumentattachment)

        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_MotorDocuAttch] where property_Dtl_id = '" & grdlistofMotors.SelectedDataKey(1) & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("Select *  from AMS.DocumentAttachment where IdentityNo = '" & grdlistofMotors.SelectedDataKey("PODtl_ID") & "' and TableName = 'AIR_MotorAttchDocu'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable3(7 - dtAccount.Rows.Count))
        End If
        grdpropertydocdetails.DataSource = dtAccount
        grdpropertydocdetails.DataBind()

        grdpropertydocdetails.SelectedIndex = 0
        loadAttchDocuChangeIndex()
    End Sub


    ' MACHINERIES MAIN INFORMATION AND DETAILS
    Protected Sub loadMachineryList() '[dbo].[SMSS_MachineList]
        ' dtMachines = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        dtMachines = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_07182022_MACHINE] '" _
                                             & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" _
                                             & gvsearchproperty.SelectedDataKey("Item_ID") & "','" _
                                             & ddGlAccount.SelectedItem.Value & "','" _
                                             & gvsearchproperty.SelectedDataKey("DeclaredOwner") & "','" _
                                             & gvsearchproperty.SelectedDataKey("Barangay") & "'", CommandType.Text)
        If dtMachines.Rows.Count < 4 Then
            dtMachines.Merge(createdatatable4A(3 - dtMachines.Rows.Count))
        End If
        grdpropertyListofmachinery.DataSource = dtMachines
        grdpropertyListofmachinery.DataBind()
        grdpropertyListofmachinery.SelectedIndex = 0
    End Sub
    Protected Sub grdpropertyListofmachinery_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim gvRow As GridViewRow = Page.FindControl("grdpropertyListofmachinery")
        gvRow = grdpropertyListofmachinery.SelectedRow
        txtHideMe.Text = gvRow.RowIndex.ToString

        loadMachineryList()
        loadMachineryInformation()
        loadMachineryLedger()

        grdpropertyListofmachinery.SelectedIndex = txtHideMe.Text

        Session("Propertyno") = grdpropertyListofmachinery.SelectedDataKey("PropertyNo")


        Try
            loadMachineryInformation()
            'loadMachineryLedger()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub grdpropertyListofmachinery_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        ''dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_07182022_MACHINE] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "','" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
        dtMachines = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_07182022_MACHINE] '" _
                                             & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" _
                                             & gvsearchproperty.SelectedDataKey("Item_ID") & "','" _
                                             & ddGlAccount.SelectedItem.Value & "','" _
                                             & gvsearchproperty.SelectedDataKey("DeclaredOwner") & "','" _
                                             & gvsearchproperty.SelectedDataKey("Barangay") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 10 Then
            dtMachines.Merge(createdatatable4A(3 - dtMachines.Rows.Count))
        End If
        grdpropertyListofmachinery.PageIndex = e.NewPageIndex
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

    ' Machinery Tabs
    Protected Sub btnmachineryLedger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmachineryLedger.Click
        loadMachineryLedger()
    End Sub
    Protected Sub btnmachineryRepairs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmachineryRepairs.Click
        loadMachineryRepair()
    End Sub
    Protected Sub btnmachineryDocattach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmachineryDocattach.Click
        loadMachineryAttchDocu()
        loadAttchDocuChangeIndex()
    End Sub

    Protected Sub loadMachineryLedger()
        ''here 1
        lblHistoryDetails.Text = drpClassification.SelectedItem.Text
        btnmachineryLedger.CssClass = "Clicked"
        btnmachineryRepairs.CssClass = "Initial"
        btnmachineryDocattach.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwledger)

        If hdnItemNo.Value = "" Then
            'dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)
        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        End If
        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtAccount.Rows.Count > 1 Then
            btnLandEdit.Enabled = False
            btnBuildingEdit.Enabled = False
            btn_Edit_Road_and_Bridge.Enabled = False
            btnEdit_Mechinery.Enabled = False
            btn_Edit_Road.Enabled = False
        Else
            btnLandEdit.Enabled = True
            btnBuildingEdit.Enabled = True
            btn_Edit_Road_and_Bridge.Enabled = True
            btnEdit_Mechinery.Enabled = True
            btn_Edit_Road.Enabled = True

        End If


        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If
        grdLedger.DataSource = dtAccount
        grdLedger.DataBind()
    End Sub
    Protected Sub loadMachineryRepair()
        lblHistoryDetails.Text = "MACHINERY"
        btnmachineryLedger.CssClass = "Initial"
        btnmachineryRepairs.CssClass = "Clicked"
        btnmachineryDocattach.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwrepairsandmaintenance)

        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_MachineryRepairs] where property_Dtl_id = '" & grdpropertyListofmachinery.SelectedDataKey(1) & "'", CommandType.Text)
        'If dtAccount.Rows.Count < 8 Then
        '    dtAccount.Merge(createdatatable11(7 - dtAccount.Rows.Count))
        'End If
        'grdrepairsandmaintenance.DataSource = dtAccount
        'grdrepairsandmaintenance.DataBind()

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_RepairAndMaintenance] where PropertyNo = '" & grdpropertyListofmachinery.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable11(7 - dtAccount.Rows.Count))
        End If
        grdrepairsandmaintenance.DataSource = dtAccount
        grdrepairsandmaintenance.DataBind()

    End Sub
    Protected Sub loadMachineryAttchDocu()

        btnmachineryLedger.CssClass = "Initial"
        btnmachineryRepairs.CssClass = "Initial"
        btnmachineryDocattach.CssClass = "Clicked"
        Me.mvledger.SetActiveView(Me.vwdocumentattachment)

        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_MachineryDocuAttch] where property_Dtl_id = '" & grdpropertyListofmachinery.SelectedDataKey(1) & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("Select *  from AMS.DocumentAttachment where IdentityNo = '" & grdpropertyListofmachinery.SelectedDataKey("PODtl_ID") & "' and TableName = 'AIR_MachineAttchDocu'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable3(7 - dtAccount.Rows.Count))
        End If
        grdpropertydocdetails.DataSource = dtAccount
        grdpropertydocdetails.DataBind()

        grdpropertydocdetails.SelectedIndex = 0
        loadAttchDocuChangeIndex()
    End Sub


    'FURNITURES MAIN INFORMATION AND DETAILS
    Protected Sub loadFurnitureList() '[dbo].[FurnitureList]
        'dtFurnitures = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        dtFurnitures = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_10282022_FURNITURE_FIXES] '" _
                                               & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" _
                                               & gvsearchproperty.SelectedDataKey("Item_ID") & "','" _
                                               & ddGlAccount.SelectedItem.Value & "','" _
                                               & gvsearchproperty.SelectedDataKey("DeclaredOwner") & "','" _
                                               & gvsearchproperty.SelectedDataKey("Barangay") & "'", CommandType.Text)
        'dtFurnitures = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_07202022_FURNITURE_FIXES] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "','" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
        ''dtFurnitures = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_472022] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "','" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)

        If dtFurnitures.Rows.Count < 4 Then
            dtFurnitures.Merge(createdatatable4A(3 - dtFurnitures.Rows.Count))
        End If
        grdfurnitureandfixtures.DataSource = dtFurnitures
        grdfurnitureandfixtures.DataBind()
        grdfurnitureandfixtures.SelectedIndex = 0
    End Sub
    Protected Sub grdfurnitureandfixtures_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If hdnItemNo.Value = "" Then
        Else
            hdnItemNo.Value = grdfurnitureandfixtures.SelectedDataKey(2)

            Dim gvRow As GridViewRow = Page.FindControl("grdfurnitureandfixtures")
            gvRow = grdfurnitureandfixtures.SelectedRow
            txtHideMe2.Text = gvRow.RowIndex.ToString
            loadFurnitureList()
            loadFurnitureInformation()
            loadFurnitureLedger()

            grdfurnitureandfixtures.SelectedIndex = txtHideMe2.Text

            Session("Propertyno") = grdfurnitureandfixtures.SelectedDataKey("PropertyNo")
            Try
                loadFurnitureInformation()
            Catch ex As Exception
            End Try
        End If

    End Sub
    Protected Sub grdfurnitureandfixtures_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        '

        ' dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_472022] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "','" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
        dtFurnitures = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_10282022_FURNITURE_FIXES] '" _
                                               & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" _
                                               & gvsearchproperty.SelectedDataKey("Item_ID") & "','" _
                                               & ddGlAccount.SelectedItem.Value & "','" _
                                               & gvsearchproperty.SelectedDataKey("DeclaredOwner") & "','" _
                                               & gvsearchproperty.SelectedDataKey("Barangay") & "'", CommandType.Text)
        ''dtFurnitures = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_472022] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "','" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)

        If dtFurnitures.Rows.Count < 4 Then
            dtFurnitures.Merge(createdatatable4A(3 - dtFurnitures.Rows.Count))
        End If
        grdfurnitureandfixtures.PageIndex = e.NewPageIndex
        grdfurnitureandfixtures.DataSource = dtFurnitures
        grdfurnitureandfixtures.DataBind()
        grdfurnitureandfixtures.SelectedIndex = 0




        'dtFurnitures = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_v1_07202022_FURNITURE_FIXES] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "','" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
        'If dtAccount.Rows.Count < 4 Then
        '    dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
        'End If
        'grdfurnitureandfixtures.PageIndex = e.NewPageIndex
        'grdfurnitureandfixtures.DataSource = dtAccount
        'grdfurnitureandfixtures.DataBind()
        'grdfurnitureandfixtures.SelectedIndex = 0
    End Sub


    Protected Sub loadInfrastructureInformation()
        Dim itemid As Integer
        If gvsearchRoadBridges.SelectedIndex >= 0 Then
            itemid = gvsearchRoadBridges.SelectedDataKey("Item_ID")

            Dim subclassification As String = objDerived.GetValue("select SubClassificationName" &
                                                                   " From dbo.m_item as a " &
                                                                  " inner join tblclassmatrix as b on a.Item_ID = b.item_id " &
                                                                    " inner join tbl_SubClassification As c On b.SubClassificationID = c.SubClassificationID" &
                                                                   " where a.Item_ID = " & itemid, CommandType.Text)
            ''here kim
            If subclassification.Contains("Roads") Then
                LoadRoadInformation()
                Me.mvInfrastructures.SetActiveView(Me.vwRoad)

            ElseIf subclassification.Contains("Bridges") Then
                LoadBridgeInformation()
                Me.mvInfrastructures.SetActiveView(Me.vwBridge)

            Else
                '  LoadMotorVehicleInformationDefault()
                LoadRoadDtl()
                LoadRoadInformation()
            End If
        End If


    End Sub
    Protected Sub loadFurnitureInformation()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FurnitureInformation] WHERE Property_Dtl_ID = '" & grdfurnitureandfixtures.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        If dt.Rows.Count = 0 Then
            'Dim dt2 As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FurnitureInformation_None_Building] WHERE Property_Dtl_ID = '" & grdfurnitureandfixtures.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
            If dt.Rows.Count = 0 Then
                LoadFurnitureDTL()
            Else
                lblfurniturename.Text = dt.Rows(0).Item("Name").ToString
                lblfurnituredescription.Text = dt.Rows(0).Item("Description").ToString
                lblfurnituredimension.Text = dt.Rows(0).Item("Dimension").ToString
                lblfurnitureareacapacity.Text = dt.Rows(0).Item("AreaCapacity").ToString
                lblfurnituremodel.Text = dt.Rows(0).Item("Model").ToString
                lblfurniturewaranty.Text = dt.Rows(0).Item("Warranty").ToString
                lblfurniturespecification.Text = dt.Rows(0).Item("Specification").ToString
                lblfurnitureDateTaken.Text = dt.Rows(0).Item("DateTaken").ToString
                lblFurnitureUploadedBy.Text = dt.Rows(0).Item("UploadedBy").ToString
                lblFurniturePosition.Text = dt.Rows(0).Item("Position").ToString

                Dim DA As DateTime
                DA = grdfurnitureandfixtures.SelectedDataKey("Date_Accepted")
                lblFNoYears.Text = Year(Date.Today.ToString("MM/dd/yyyy")) - Year(DA) & " Year/s"



                lblFULife.Text = IIf(IsDBNull(dt.Rows(0)("useful_life")), 0, dt.Rows(0)("useful_life"))
                txtFSalValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

                If txtFSalValue.Text = 0 Then
                    lblfurnituredepreciatedrate.Text = 0
                    lblfurnituredepriatedvalue.Text = 0
                Else
                    lblfurnituredepreciatedrate.Text = FormatNumber(dt.Rows(0)("DepreciationRate"), 2)
                    lblfurnituredepriatedvalue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)

                End If

                Session("useful_life") = dt.Rows(0)("useful_life")

                txtName.Text = dt.Rows(0).Item("Name").ToString
                txtequipmentpowerinput.Text = dt.Rows(0).Item("PowerInput").ToString
                txtequipmentSerialNumber.Text = dt.Rows(0).Item("SerialNo").ToString


                ''txtFurnitureUnit.Text = objDerived.GetValue("select Description  From ams.m_Unit where Unit_ID = " & dt.Rows(0).Item("Unit_ID").ToString, CommandType.Text)
                drpFurnitureUnit.SelectedValue = dt.Rows(0).Item("Unit_ID").ToString

                txtQuantity.Text = dt.Rows(0).Item("Qty").ToString
                txtequipmentdesciption.Text = dt.Rows(0).Item("Description").ToString
                txtequipmentdimension.Text = dt.Rows(0).Item("Dimension").ToString
                txtequipmentpowerinput.Text = dt.Rows(0).Item("PowerInput").ToString
                txtequipmentmodel.Text = dt.Rows(0).Item("Model").ToString
                txtequipmentSerialNumber.Text = dt.Rows(0).Item("SerialNo").ToString
                txtequipmentwaranty.Text = dt.Rows(0).Item("Warranty").ToString
                txtPropertyNo.Text = dt.Rows(0).Item("Property_code").ToString

                ''txtFurnitureInstalledat.Text = objDerived.GetValue("select BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID where BuildingId =  " & dt.Rows(0).Item("BuildingId").ToString, CommandType.Text)
                'drpInstalledAtBuilding.SelectedValue = dt.Rows(0).Item("BuildingId").ToString

                ''txtDepartment.Text = objDerived.GetValue("SELECT DISTINCT UPPER(RC_Name) AS RC_Name FROM dbo.View_RespCenter_withFunctions where RC_ID = " & dt.Rows(0).Item("RC_ID").ToString, CommandType.Text)
                drpDepartmentFurnifure.SelectedValue = dt.Rows(0).Item("RC_ID").ToString


                txtAccountablePerson.Text = dt.Rows(0).Item("AccountablePerson").ToString
                txtFurnitureAcqDate.Text = grdfurnitureandfixtures.SelectedDataKey("Date_Accepted")
                txtFurnitureMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString
                txtFurnitureAcqCost.Text = dt.Rows(0).Item("Cost").ToString
                'txtFurnitureNoYears.Text = Year(Date.Today.ToString("MM/dd/yyyy")) - Year(DA) & " Year/s"
                txtFurnitureNoYears.Text = dt.Rows(0).Item("NoYears").ToString
                txtFurnitureDeprate.Text = FormatNumber(dt.Rows(0)("DepreciationRate"), 2)
                txtFurnitureUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString
                txtFurnitureDepValue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)
                txtFurnitureSalvageValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

                lbl_furniture_FurnitureId.Text = dt.Rows(0).Item("FurnitureId").ToString
                lbl_furniture_FurnitureInfoId.Text = dt.Rows(0).Item("FurnitureInfoId").ToString
                lbl_furniture_Item_ID.Text = dt.Rows(0).Item("Item_ID").ToString

                hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString
                'here 1
                lbl_Furniture_Property_ID.Text = dt.Rows(0).Item("Property_ID").ToString
                hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString
            End If

        Else
            lblfurniturename.Text = dt.Rows(0).Item("Name").ToString
            lblfurnituredescription.Text = dt.Rows(0).Item("Description").ToString
            lblfurnituredimension.Text = dt.Rows(0).Item("Dimension").ToString
            lblfurnitureareacapacity.Text = dt.Rows(0).Item("AreaCapacity").ToString
            lblfurnituremodel.Text = dt.Rows(0).Item("Model").ToString
            lblfurniturewaranty.Text = dt.Rows(0).Item("Warranty").ToString
            lblfurniturespecification.Text = dt.Rows(0).Item("Specification").ToString
            lblfurnitureDateTaken.Text = dt.Rows(0).Item("DateTaken").ToString
            lblFurnitureUploadedBy.Text = dt.Rows(0).Item("UploadedBy").ToString
            lblFurniturePosition.Text = dt.Rows(0).Item("Position").ToString

            Dim DA As DateTime
            DA = grdfurnitureandfixtures.SelectedDataKey("Date_Accepted")
            lblFNoYears.Text = Year(Date.Today.ToString("MM/dd/yyyy")) - Year(DA) & " Year/s"



            lblFULife.Text = IIf(IsDBNull(dt.Rows(0)("useful_life")), 0, dt.Rows(0)("useful_life"))
            txtFSalValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

            If txtFSalValue.Text = 0 Then
                lblfurnituredepreciatedrate.Text = 0
                lblfurnituredepriatedvalue.Text = 0
            Else
                lblfurnituredepreciatedrate.Text = FormatNumber(dt.Rows(0)("DepreciationRate"), 2)
                lblfurnituredepriatedvalue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)

            End If

            Session("useful_life") = dt.Rows(0)("useful_life")

            txtName.Text = dt.Rows(0).Item("Name").ToString
            txtequipmentpowerinput.Text = dt.Rows(0).Item("PowerInput").ToString
            txtequipmentSerialNumber.Text = dt.Rows(0).Item("SerialNo").ToString


            ''txtFurnitureUnit.Text = objDerived.GetValue("select Description  From ams.m_Unit where Unit_ID = " & dt.Rows(0).Item("Unit_ID").ToString, CommandType.Text)
            drpFurnitureUnit.SelectedValue = dt.Rows(0).Item("Unit_ID").ToString

            txtQuantity.Text = dt.Rows(0).Item("Qty").ToString
            txtequipmentdesciption.Text = dt.Rows(0).Item("Description").ToString
            txtequipmentdimension.Text = dt.Rows(0).Item("Dimension").ToString
            txtequipmentpowerinput.Text = dt.Rows(0).Item("PowerInput").ToString
            txtequipmentmodel.Text = dt.Rows(0).Item("Model").ToString
            txtequipmentSerialNumber.Text = dt.Rows(0).Item("SerialNo").ToString
            txtequipmentwaranty.Text = dt.Rows(0).Item("Warranty").ToString
            txtPropertyNo.Text = dt.Rows(0).Item("Property_code").ToString

            ''txtFurnitureInstalledat.Text = objDerived.GetValue("select BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID where BuildingId =  " & dt.Rows(0).Item("BuildingId").ToString, CommandType.Text)
            drpInstalledAtBuilding.SelectedValue = dt.Rows(0).Item("BuildingId").ToString

            ''txtDepartment.Text = objDerived.GetValue("SELECT DISTINCT UPPER(RC_Name) AS RC_Name FROM dbo.View_RespCenter_withFunctions where RC_ID = " & dt.Rows(0).Item("RC_ID").ToString, CommandType.Text)
            drpDepartmentFurnifure.SelectedValue = dt.Rows(0).Item("RC_ID").ToString


            txtAccountablePerson.Text = dt.Rows(0).Item("AccountablePerson").ToString
            txtFurnitureAcqDate.Text = grdfurnitureandfixtures.SelectedDataKey("Date_Accepted")
            txtFurnitureMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString
            txtFurnitureAcqCost.Text = dt.Rows(0).Item("Cost").ToString
            'txtFurnitureNoYears.Text = Year(Date.Today.ToString("MM/dd/yyyy")) - Year(DA) & " Year/s"
            txtFurnitureNoYears.Text = dt.Rows(0).Item("NoYears").ToString
            txtFurnitureDeprate.Text = FormatNumber(dt.Rows(0)("DepreciationRate"), 2)
            txtFurnitureUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString
            txtFurnitureDepValue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)
            txtFurnitureSalvageValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

            lbl_furniture_FurnitureId.Text = dt.Rows(0).Item("FurnitureId").ToString
            lbl_furniture_FurnitureInfoId.Text = dt.Rows(0).Item("FurnitureInfoId").ToString
            lbl_furniture_Item_ID.Text = dt.Rows(0).Item("Item_ID").ToString

            hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString
            'here 1
            lbl_Furniture_Property_ID.Text = dt.Rows(0).Item("Property_ID").ToString
            hdnItemNo.Value = dt.Rows(0).Item("Item_ID").ToString
        End If
    End Sub
    Protected Sub LoadFurnitureDTL()
        lblfurniturename.Text = ""
        lblfurnituredescription.Text = ""
        lblfurnituredimension.Text = ""
        lblfurnitureareacapacity.Text = ""
        lblfurnituremodel.Text = ""
        lblfurniturewaranty.Text = ""
        lblfurnituredepreciatedrate.Text = ""
        lblfurnituredepriatedvalue.Text = ""
        lblfurniturespecification.Text = ""
        lblfurnitureDateTaken.Text = ""
        lblFurnitureUploadedBy.Text = ""
        lblFurniturePosition.Text = ""

        lblFNoYears.Text = ""
        lblFULife.Text = ""
        txtFSalValue.Text = ""

    End Sub

    ' Furniture Tabs
    Protected Sub btnfurnitureledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfurnitureledger.Click
        loadFurnitureLedger()
    End Sub
    Protected Sub btnfurnitureRepairs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfurnitureRepairs.Click
        loadFurnitureRepairs()
    End Sub
    Protected Sub btnfurnitureAttachedDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfurnitureAttachedDoc.Click
        loadFurnitureAttchDocu()
        loadAttchDocuChangeIndex()
    End Sub



    Protected Sub loadFurnitureLedger()
        lblHistoryDetails.Text = "FURNITURE"
        btnfurnitureledger.CssClass = "Clicked"
        btnfurnitureRepairs.CssClass = "Initial"
        btnfurnitureAttachedDoc.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwledger)

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & grdfurnitureandfixtures.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If dtAccount.Rows.Count > 1 Then
            btn_Edit_Furniture_Fixes.Enabled = False
        Else
            btn_Edit_Furniture_Fixes.Enabled = True
        End If

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If
        grdLedger.DataSource = dtAccount
        grdLedger.DataBind()
    End Sub
    Protected Sub loadFurnitureRepairs()
        lblHistoryDetails.Text = "FURNITURE"
        btnfurnitureledger.CssClass = "Initial"
        btnfurnitureRepairs.CssClass = "Clicked"
        btnfurnitureAttachedDoc.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwrepairsandmaintenance)

        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_FurnitureRepairs] where property_Dtl_id = '" & grdfurnitureandfixtures.SelectedDataKey(1) & "'", CommandType.Text)
        'If dtAccount.Rows.Count < 8 Then
        '    dtAccount.Merge(createdatatable11(7 - dtAccount.Rows.Count))
        'End If
        'grdrepairsandmaintenance.DataSource = dtAccount
        'grdrepairsandmaintenance.DataBind()

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_RepairAndMaintenance] where PropertyNo = '" & grdfurnitureandfixtures.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable11(7 - dtAccount.Rows.Count))
        End If
        grdrepairsandmaintenance.DataSource = dtAccount
        grdrepairsandmaintenance.DataBind()
    End Sub
    Protected Sub loadFurnitureAttchDocu()
        lblHistoryDetails.Text = "FURNITURE"
        btnfurnitureledger.CssClass = "Initial"
        btnfurnitureRepairs.CssClass = "Initial"
        btnfurnitureAttachedDoc.CssClass = "Clicked"

        Me.mvledger.SetActiveView(Me.vwdocumentattachment)

        dtAccount = objDerived.GetDataTable("select *  from AMS.DocumentAttachment where IdentityNo = '" & grdfurnitureandfixtures.SelectedDataKey("PODtl_ID") & "' and TableName = 'AIR_FurAttchDocu'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable3(7 - dtAccount.Rows.Count))
        End If
        grdpropertydocdetails.DataSource = dtAccount
        grdpropertydocdetails.DataBind()

        grdpropertydocdetails.SelectedIndex = 0
        loadAttchDocuChangeIndex()
    End Sub


    ' Document Attachment: Equipments, Motors, Machinery and Furniture
    Protected Sub grdpropertydocdetails_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        loadAttchDocuChangeIndex()
    End Sub
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

    ' RowDataBound
    Protected Sub gvsearch_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvsearch.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearch, "Select$" + e.Row.RowIndex.ToString()))

        End If
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

    Protected Sub gvsearchproperty_without_Building_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearchproperty_without_Building, "Select$" + e.Row.RowIndex.ToString()))
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

    Protected Sub gvsearchproperty_Military_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearchproperty_Military, "Select$" + e.Row.RowIndex.ToString()))
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



    Protected Sub gvsearchproperty_Books_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearchproperty_Books, "Select$" + e.Row.RowIndex.ToString()))
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


    Protected Sub gvsearchRoadBridges_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearchRoadBridges, "Select$" + e.Row.RowIndex.ToString()))
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
    Protected Sub grdpropertydocdetails_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdpropertydocdetails, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdlandDocument_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdlandDocument.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdlandDocument, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub gvownership_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvownership.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvownership, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grblgydocumentdetails_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grblgydocumentdetails.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grblgydocumentdetails, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdocumentdetails_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdocumentdetails, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdlistofEuipment_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdlistofEuipment, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdlistofMotors_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdlistofMotors, "Select$" + e.Row.RowIndex.ToString()))
        End If
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
    Protected Sub grdfurnitureandfixtures_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdfurnitureandfixtures, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
#Region "Create table"
    ' DataGrid Table
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("startingpt", GetType(Integer))
        dt.Columns.Add("endingpt", GetType(Integer))
        dt.Columns.Add("ns", GetType(String))
        dt.Columns.Add("ns1", GetType(Integer))
        dt.Columns.Add("ns2", GetType(Integer))
        dt.Columns.Add("we", GetType(String))
        dt.Columns.Add("mDistance", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("startingpt") = DBNull.Value
            dr("endingpt") = DBNull.Value
            dr("ns") = DBNull.Value
            dr("ns1") = DBNull.Value
            dr("ns2") = DBNull.Value
            dr("we") = DBNull.Value
            dr("mDistance") = DBNull.Value
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
    Public Function createdatatable4(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("TypeService", GetType(String))
        dt.Columns.Add("PlateNo", GetType(String))
        dt.Columns.Add("DatePurchased", GetType(Date))
        dt.Columns.Add("acquisitioncost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("PODtl_ID", GetType(Long))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PropertyDetai_ID") = DBNull.Value
            dr("TypeService") = DBNull.Value
            dr("PlateNo") = DBNull.Value
            dr("DatePurchased") = DBNull.Value
            dr("acquisitioncost") = DBNull.Value
            dr("MarketValue") = DBNull.Value
            dr("Condition") = DBNull.Value
            dr("Location") = DBNull.Value
            dr("Status") = DBNull.Value
            dr("Property_ID") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("PODtl_ID") = DBNull.Value
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
    Public Function createdatatable5(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("year", GetType(String))
        dt.Columns.Add("ownername", GetType(String))
        dt.Columns.Add("ownertype", GetType(String))
        dt.Columns.Add("address", GetType(String))
        dt.Columns.Add("typeacquisition", GetType(String))
        dt.Columns.Add("OwnershipId", GetType(Long))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("year") = DBNull.Value
            dr("ownername") = DBNull.Value
            dr("ownertype") = DBNull.Value
            dr("address") = DBNull.Value
            dr("typeacquisition") = DBNull.Value
            dr("OwnershipId") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable6(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("ProfessionalContractor", GetType(String))
        dt.Columns.Add("ProfessionalName", GetType(String))
        dt.Columns.Add("ProfessionalAddress", GetType(String))
        dt.Columns.Add("ProfessionalTeleNo", GetType(String))
        dt.Columns.Add("ProfessionalCellNo", GetType(String))
        dt.Columns.Add("ProfessionalEmailAddress", GetType(String))
        dt.Columns.Add("ProfessionalPrcNo", GetType(String))
        dt.Columns.Add("ProfessionalPtrNo", GetType(String))
        dt.Columns.Add("ProfessionalValidity", GetType(String))
        dt.Columns.Add("ProfessionalDateIssued", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("ProfessionalContractor") = DBNull.Value
            dr("ProfessionalName") = DBNull.Value
            dr("ProfessionalAddress") = DBNull.Value
            dr("ProfessionalTeleNo") = DBNull.Value
            dr("ProfessionalCellNo") = DBNull.Value
            dr("ProfessionalEmailAddress") = DBNull.Value
            dr("ProfessionalPrcNo") = DBNull.Value
            dr("ProfessionalPtrNo") = DBNull.Value
            dr("ProfessionalValidity") = DBNull.Value
            dr("ProfessionalDateIssued") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable7(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("unitno", GetType(Integer))
        dt.Columns.Add("OccupantName", GetType(String))
        dt.Columns.Add("OccupBusinessName", GetType(String))
        dt.Columns.Add("OccupFloorArea", GetType(String))
        dt.Columns.Add("OccupOwnership", GetType(String))
        dt.Columns.Add("OccupCategory", GetType(String))
        dt.Columns.Add("OccupPermitType", GetType(String))
        dt.Columns.Add("OccupPermitNo", GetType(String))
        dt.Columns.Add("OccupDateApplication", GetType(String))
        dt.Columns.Add("OccupDatePermitIssuance", GetType(String))
        dt.Columns.Add("OccupRemarks", GetType(String))
        dt.Columns.Add("DocuId", GetType(Long))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("unitno") = DBNull.Value
            dr("OccupantName") = DBNull.Value
            dr("OccupBusinessName") = DBNull.Value
            dr("OccupFloorArea") = DBNull.Value
            dr("OccupOwnership") = DBNull.Value
            dr("OccupCategory") = DBNull.Value
            dr("OccupPermitNo") = DBNull.Value
            dr("OccupPermitNo") = DBNull.Value
            dr("OccupDateApplication") = DBNull.Value
            dr("OccupDatePermitIssuance") = DBNull.Value
            dr("OccupRemarks") = DBNull.Value
            dr("DocuId") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable8(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("AppPermitType", GetType(String))
        dt.Columns.Add("ApplicationDate", GetType(String))
        dt.Columns.Add("AppPermitNo", GetType(String))
        dt.Columns.Add("AppDatePermitIssuance", GetType(String))
        dt.Columns.Add("AppRemarks", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("AppPermitType") = DBNull.Value
            dr("ApplicationDate") = DBNull.Value
            dr("AppPermitNo") = DBNull.Value
            dr("AppDatePermitIssuance") = DBNull.Value
            dr("AppRemarks") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable9(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("InspectionDate", GetType(String))
        dt.Columns.Add("inspectiontype", GetType(String))
        dt.Columns.Add("missionorderno", GetType(String))
        dt.Columns.Add("inspector", GetType(String))
        dt.Columns.Add("violation", GetType(String))
        dt.Columns.Add("insremarks", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("InspectionDate") = DBNull.Value
            dr("inspectiontype") = DBNull.Value
            dr("missionorderno") = DBNull.Value
            dr("inspector") = DBNull.Value
            dr("violation") = DBNull.Value
            dr("insremarks") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable10(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("permittype", GetType(String))
        dt.Columns.Add("permitno", GetType(String))
        dt.Columns.Add("orno", GetType(String))
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("paymentdate", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("permittype") = DBNull.Value
            dr("permitno") = DBNull.Value
            dr("orno") = DBNull.Value
            dr("amount") = DBNull.Value
            dr("paymentdate") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
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
    Public Function createdatatable12(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("agency", GetType(String))
        dt.Columns.Add("documentname", GetType(String))
        dt.Columns.Add("documentno", GetType(String))
        dt.Columns.Add("validatedby", GetType(String))
        dt.Columns.Add("datevalidated", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        dt.Columns.Add("DocuId", GetType(Long))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("agency") = DBNull.Value
            dr("documentname") = DBNull.Value
            dr("documentno") = DBNull.Value
            dr("validatedby") = DBNull.Value
            dr("datevalidated") = DBNull.Value
            dr("remarks") = DBNull.Value
            dr("DocuId") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable13(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("classification", GetType(String))
        dt.Columns.Add("subclassification", GetType(String))
        dt.Columns.Add("area", GetType(String))
        dt.Columns.Add("unit", GetType(String))
        dt.Columns.Add("unitvalue", GetType(Integer))
        dt.Columns.Add("basemarketvalue", GetType(Decimal))
        dt.Columns.Add("taxable", GetType(String))
        dt.Columns.Add("adjustments", GetType(Decimal))
        dt.Columns.Add("adjustedmarketvalue", GetType(Decimal))
        dt.Columns.Add("strip", GetType(String))
        dt.Columns.Add("adjunitvalue", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("classification") = DBNull.Value
            dr("subclassification") = DBNull.Value
            dr("area") = DBNull.Value
            dr("unit") = DBNull.Value
            dr("unitvalue") = DBNull.Value
            dr("basemarketvalue") = DBNull.Value
            dr("taxable") = DBNull.Value
            dr("adjustments") = DBNull.Value
            dr("adjustedmarketvalue") = DBNull.Value
            dr("strip") = DBNull.Value
            dr("adjunitvalue") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable14(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("kind", GetType(String))
        dt.Columns.Add("quantity", GetType(String))
        dt.Columns.Add("unitvalue", GetType(String))
        dt.Columns.Add("basemarketvalue", GetType(String))
        dt.Columns.Add("taxable", GetType(Integer))
        dt.Columns.Add("Subclass", GetType(Decimal))
        dt.Columns.Add("type", GetType(String))
        dt.Columns.Add("asssessmentlevel", GetType(Decimal))
        dt.Columns.Add("actualuse", GetType(Decimal))
        dt.Columns.Add("landimprovements", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("kind") = DBNull.Value
            dr("quantity") = DBNull.Value
            dr("unitvalue") = DBNull.Value
            dr("basemarketvalue") = DBNull.Value
            dr("taxable") = DBNull.Value
            dr("Subclass") = DBNull.Value
            dr("type") = DBNull.Value
            dr("asssessmentlevel") = DBNull.Value
            dr("actualuse") = DBNull.Value
            dr("landimprovements") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

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
    Public Function createdatatableSearch(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("ItemDescription", GetType(String))
        dt.Columns.Add("unit", GetType(String))
        dt.Columns.Add("item_particular_id", GetType(Long))
        dt.Columns.Add("TD_ID", GetType(Long))
        dt.Columns.Add("ItemCount", GetType(Integer))
        dt.Columns.Add("Item_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Property_code") = DBNull.Value
            dr("ItemCount") = DBNull.Value
            dr("ItemDescription") = DBNull.Value
            dr("unit") = DBNull.Value
            dr("item_particular_id") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("TD_ID") = DBNull.Value
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
#End Region
    Protected Sub grdLedger_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    ' Search Options
    Protected Sub ItemSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadSearchMe()
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub LoadSearchMe()
        Dim dtSearch As New DataTable
        'here
        dtSearch = objDerived.GetDataTable("EXEC [dbo].[SMSS_ProtertyRecord_Search_02062023] '" & Session("GA_ID") & "', '" & txtAccountSearch.Text & "'", CommandType.Text)
        If dtSearch.Rows.Count < 5 Then
            dtSearch.Merge(createdatatable15(5 - dtSearch.Rows.Count))
        End If
        gvsearchproperty_without_Building.DataSource = dtSearch
        gvsearchproperty_without_Building.DataBind()
        gvsearchproperty_without_Building.SelectedIndex = -1


    End Sub
    Protected Sub btnSerialSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim myview As DataView
            myview = dtEquipments.DefaultView
            myview.RowFilter = "Barcode like '%" & replaceapostrophe(txtSerialSearch.Text.ToString) & "%'"
            grdlistofEuipment.DataSource = myview
            grdlistofEuipment.DataBind()
            grdlistofEuipment.SelectedIndex = 0


            'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_Search]  '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "','" & txtSerialSearch.Text & "'", CommandType.Text)
            'If dtAccount.Rows.Count < 4 Then
            '    dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
            '    Me.grdlistofEuipment.DataSource = dtAccount
            '    Me.grdlistofEuipment.DataBind()
            '    Me.grdlistofEuipment.SelectedIndex = 0
            'Else
            '    Me.grdlistofEuipment.DataSource = dtAccount
            '    Me.grdlistofEuipment.DataBind()
            '    Me.grdlistofEuipment.SelectedIndex = 0
            'End If

            loadEquipmentInformation()
            loadEquipmentLedger()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnMotorSerialSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim myview As DataView
            myview = dtMotors.DefaultView
            myview.RowFilter = "Barcode like '%" & replaceapostrophe(txtMotorSerialSearch.Text.ToString) & "%'"
            grdlistofMotors.DataSource = myview
            grdlistofMotors.DataBind()
            grdlistofMotors.SelectedIndex = 0

            'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_Search]  '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "', '" & txtMotorSerialSearch.Text & "'", CommandType.Text)
            'If dtAccount.Rows.Count < 4 Then
            '    dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
            '    Me.grdlistofMotors.DataSource = dtAccount
            '    Me.grdlistofMotors.DataBind()
            '    Me.grdlistofMotors.SelectedIndex = 0
            'Else
            '    Me.grdlistofMotors.DataSource = dtAccount 'objDerived.GetDataTable("SELECT * from [dbo].[View_MotorList]", CommandType.Text)
            '    Me.grdlistofMotors.DataBind()
            '    Me.grdlistofMotors.SelectedIndex = 0
            'End If


            loadMotorInformation()
            loadMotorLedger()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnMachinerySearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim myview As DataView
            myview = dtMachines.DefaultView
            myview.RowFilter = "Barcode like '%" & replaceapostrophe(txtMachinerySearch.Text.ToString) & "%'"
            grdpropertyListofmachinery.DataSource = myview
            grdpropertyListofmachinery.DataBind()
            grdpropertyListofmachinery.SelectedIndex = 0

            'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_Search]  '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "','" & txtMachinerySearch.Text & "'", CommandType.Text)
            'If dtAccount.Rows.Count < 4 Then
            '    dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
            '    Me.grdpropertyListofmachinery.DataSource = dtAccount
            '    Me.grdpropertyListofmachinery.DataBind()
            '    Me.grdpropertyListofmachinery.SelectedIndex = 0
            'Else
            '    Me.grdpropertyListofmachinery.DataSource = dtAccount 'objDerived.GetDataTable("SELECT * from [dbo].[View_MachineryList]", CommandType.Text)
            '    Me.grdpropertyListofmachinery.DataBind()
            '    Me.grdpropertyListofmachinery.SelectedIndex = 0
            'End If

            loadMachineryInformation()
            loadMachineryLedger()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim myview As DataView
            myview = dtFurnitures.DefaultView
            myview.RowFilter = "Barcode like '%" & replaceapostrophe(txtFurnitureSerialSearch.Text.ToString) & "%'"
            grdfurnitureandfixtures.DataSource = myview
            grdfurnitureandfixtures.DataBind()
            grdfurnitureandfixtures.SelectedIndex = 0

            'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList_Search]  '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "','" & txtFurnitureSerialSearch.Text & "'", CommandType.Text)
            'If dtAccount.Rows.Count < 4 Then
            '    dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
            '    Me.grdfurnitureandfixtures.DataSource = dtAccount
            '    Me.grdfurnitureandfixtures.DataBind()
            '    Me.grdfurnitureandfixtures.SelectedIndex = 0
            'Else
            '    Me.grdfurnitureandfixtures.DataSource = dtAccount 'objDerived.GetDataTable("SELECT * from [dbo].[View_FurnitureList]", CommandType.Text)
            '    Me.grdfurnitureandfixtures.DataBind()
            '    Me.grdfurnitureandfixtures.SelectedIndex = 0
            'End If

            loadFurnitureInformation()
            loadFurnitureLedger()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub LoadAmbulanceList()
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
        End If
        grdListAmbulance.DataSource = dtAccount
        grdListAmbulance.DataBind()
        grdListAmbulance.SelectedIndex = 0
    End Sub
    Protected Sub btnAmbulanceLedger_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadAmbulanceLedger()
    End Sub

    Protected Sub btnAmbulanceRepairs_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        lblHistoryDetails.Text = "AMBULANCE"
        btnAmbulanceLedger.CssClass = "Initial"
        btnAmbulanceRepairs.CssClass = "Clicked"
        btnAmbulanceDocuAttch.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwrepairsandmaintenance)
        Dim dtAmbu As New DataTable
        dtAmbu = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords]  '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        If dtAmbu.Rows.Count = 0 Then
            grdrepairsandmaintenance.DataSource = createdatatable11(4)
            grdrepairsandmaintenance.DataBind()
        Else
            'dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_AmbulanceRepair] where property_Dtl_id = '" & grdListAmbulance.SelectedDataKey(1) & "'", CommandType.Text)
            'If dtAccount.Rows.Count < 8 Then
            '    dtAccount.Merge(createdatatable11(7 - dtAccount.Rows.Count))
            'End If
            'grdrepairsandmaintenance.DataSource = dtAccount
            'grdrepairsandmaintenance.DataBind()

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_RepairAndMaintenance] where PropertyNo = '" & grdListAmbulance.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
            If dtAccount.Rows.Count < 8 Then
                dtAccount.Merge(createdatatable11(7 - dtAccount.Rows.Count))
            End If
            grdrepairsandmaintenance.DataSource = dtAccount
            grdrepairsandmaintenance.DataBind()
        End If
    End Sub
    Protected Sub btnAmbulanceDocuAttch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        lblHistoryDetails.Text = "AMBULANCE"
        btnAmbulanceLedger.CssClass = "Initial"
        btnAmbulanceRepairs.CssClass = "Initial"
        btnAmbulanceDocuAttch.CssClass = "Clicked"

        Me.mvledger.SetActiveView(Me.vwdocumentattachment)
        Dim dtAmbu As New DataTable
        dtAmbu = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords]  '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        If dtAmbu.Rows.Count = 0 Then
            grdpropertydocdetails.DataSource = createdatatable3(4)
            grdpropertydocdetails.DataBind()
        Else
            dtAccount = objDerived.GetDataTable("select *  from AMS.DocumentAttachment where IdentityNo = '" & grdfurnitureandfixtures.SelectedDataKey("PODtl_ID") & "' and TableName = 'AIR_FurAttchDocu'", CommandType.Text)
            If dtAccount.Rows.Count < 8 Then
                dtAccount.Merge(createdatatable3(7 - dtAccount.Rows.Count))
            End If
            grdpropertydocdetails.DataSource = dtAccount
            grdpropertydocdetails.DataBind()

            grdpropertydocdetails.SelectedIndex = 0
            loadAttchDocuChangeIndex()
        End If

    End Sub
    Protected Sub LoadAmbulanceLedger()
        lblHistoryDetails.Text = "AMBULANCE"
        btnAmbulanceLedger.CssClass = "Clicked"
        btnAmbulanceRepairs.CssClass = "Initial"
        btnAmbulanceDocuAttch.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwledger)

        Dim dtAmbu As New DataTable
        dtAmbu = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords]  '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        If dtAmbu.Rows.Count = 0 Then
            grdLedger.DataSource = createdatatableledger(10)
            grdLedger.DataBind()
        Else
            dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "' order by dDate", CommandType.Text)

            If dtAccount.Rows.Count < 10 Then
                dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
            End If
            grdLedger.DataSource = dtAccount
            grdLedger.DataBind()
        End If
    End Sub
    Protected Sub grdListAmbulance_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadAmbulanceDtl()
    End Sub
    Protected Sub LoadAmbulanceDtl()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("Select * from Ams.TbAmbulance_Info where Property_Dtl_ID = '" & grdListAmbulance.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadAmbulanceDtlClear()
        Else
            lblAmbulanceLoc.Text = dt.Rows(0).Item("Location").ToString
            lblAmublanceBrand.Text = dt.Rows(0).Item("Brand").ToString
            lblAmublanceModel.Text = dt.Rows(0).Item("Model").ToString
            lblAmublancePlate.Text = dt.Rows(0).Item("PlateNo").ToString
            lblAmublanceArea.Text = dt.Rows(0).Item("Area").ToString
            lblAmublanceSeat.Text = dt.Rows(0).Item("Seat").ToString
            lblAmublanceColor.Text = dt.Rows(0).Item("Color").ToString
            lblAmbulanceEquip.Text = dt.Rows(0).Item("Equipments").ToString
        End If

    End Sub

    Protected Sub LoadAmbulanceDtlClear()
        lblAmbulanceLoc.Text = ""
        lblAmublanceBrand.Text = ""
        lblAmublanceModel.Text = ""
        lblAmublancePlate.Text = ""
        lblAmublanceArea.Text = ""
        lblAmublanceSeat.Text = ""
        lblAmublanceColor.Text = ""
        lblAmbulanceEquip.Text = ""
    End Sub
    Protected Sub grdListAmbulance_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdListAmbulance, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdListAmbulance_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
        End If
        grdListAmbulance.SelectedIndex = e.NewPageIndex
        grdListAmbulance.DataSource = dtAccount
        grdListAmbulance.DataBind()
        grdListAmbulance.SelectedIndex = 0
    End Sub

    Protected Sub grdrepairsandmaintenance_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dtrepair As New DataTable
        dtrepair = objDerived.GetDataTable("Select * from dbo.View_Records_Repair_Details where RepairMaintenanceId = '" & grdrepairsandmaintenance.SelectedDataKey("RepairMaintenanceId") & "'", CommandType.Text)
        If dtrepair.Rows.Count = 0 Then
            ModalPopupExtender1.Hide()

        Else
            If dtrepair.Rows.Count < 5 Then
                dtrepair.Merge(createdatatableRepair(4 - dtrepair.Rows.Count))
                grdRepair.DataSource = dtrepair
                grdRepair.DataBind()
            Else
                grdRepair.DataSource = dtrepair
                grdRepair.DataBind()
            End If

            lblPropertyDesc.Text = dtrepair.Rows(0).Item("PropertyItems").ToString
            lblPropertyNo.Text = dtrepair.Rows(0).Item("PropertyNo").ToString

            ModalPopupExtender1.Show()
        End If

    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ModalPopupExtender1.Hide()

    End Sub

    Public Function createdatatableRepair(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("RepairMaintenanceId", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("RepairItems", GetType(String))
        dt.Columns.Add("qty", GetType(Integer))
        dt.Columns.Add("price", GetType(Decimal))
        dt.Columns.Add("PropertyItems", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("RepairMaintenanceId") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("RepairItems") = DBNull.Value
            dr("qty") = DBNull.Value
            dr("price") = DBNull.Value
            dr("PropertyItems") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub grdRepair_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtrepair As New DataTable
        dtrepair = objDerived.GetDataTable("Select * from dbo.View_Records_Repair_Details where RepairMaintenanceId = '" & grdrepairsandmaintenance.SelectedDataKey("RepairMaintenanceId") & "'", CommandType.Text)
        If dtrepair.Rows.Count < 5 Then
            dtrepair.Merge(createdatatableRepair(4 - dtrepair.Rows.Count))
            grdRepair.PageIndex = e.NewPageIndex
            grdRepair.DataSource = dtrepair
            grdRepair.DataBind()
        End If

    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'here 1
        Session("Item_ID") = hdnItemNo.Value
        Session("Donation_to_LGU") = "PropertyCard"
        Me.Page.Response.Redirect("~/Records/rpt_propertycard.aspx")

    End Sub

    Protected Sub lblequipmentdepreciatedRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadEquipDepreciation()
    End Sub

    Protected Sub txtSalvageValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadEquipDepreciation()
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

    Protected Sub lblmachiniriesdepreciatedrate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub txtMSalValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim Cost As Double
            Dim SalValue As Double
            Dim TDepValue As Double
            Dim AcquisitionYear As Date
            Dim NoYears As Integer
            Dim DepVRate As Double
            Dim DepPRate As Double
            Dim ULife As Integer

            AcquisitionYear = grdpropertyListofmachinery.SelectedDataKey("Date_Accepted")
            Cost = grdpropertyListofmachinery.SelectedDataKey("AcquisitionCost")
            ULife = Session("useful_life")
            SalValue = FormatNumber(CType(txtMSalValue.Text, Decimal), 2)
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

            objDerived.GetRecords("UPDATE AMS.TbMachinery_Information SET DepreciationRate = '" & DepPRate & "',DepreciationValue = '" & TDepValue & "',SalvageValue = '" & SalValue & "' WHERE Property_Dtl_ID = '" & grdpropertyListofmachinery.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)

            lblmachiniriesdepreciatedrate.Text = DepPRate
            lblmachiniriesdepriciatedvalue.Text = FormatNumber(TDepValue, 2)
            txtMSalValue.Text = FormatNumber(SalValue, 2)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub lblfurnituredepreciatedrate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub txtFSalValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim Cost As Double
            Dim SalValue As Double
            Dim TDepValue As Double
            Dim AcquisitionYear As Date
            Dim NoYears As Integer
            Dim DepVRate As Double
            Dim DepPRate As Double
            Dim ULife As Integer

            AcquisitionYear = grdfurnitureandfixtures.SelectedDataKey("Date_Accepted")
            Cost = grdfurnitureandfixtures.SelectedDataKey("AcquisitionCost")
            ULife = Session("useful_life")
            SalValue = FormatNumber(CType(txtFSalValue.Text, Decimal), 2)
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

            objDerived.GetRecords("UPDATE AMS.TbFurniture_Info SET DepreciationRate = '" & DepPRate & "',DepreciationValue = '" & TDepValue & "',SalvageValue = '" & SalValue & "' WHERE Property_Dtl_ID = '" & grdfurnitureandfixtures.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)

            lblfurnituredepriatedvalue.Text = FormatNumber(TDepValue, 2)
            lblfurnituredepreciatedrate.Text = FormatNumber(DepPRate, 2)
            txtFSalValue.Text = FormatNumber(SalValue, 2)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub LoadUpdateDepreciatedValue()
        '===== EQUIPMENTS
        Dim dtEquip As New DataTable
        dtEquip = objDerived.GetDataTable("SELECT * FROM dbo.View_EquipmentInformation", CommandType.Text)

        For i As Integer = 0 To dtEquip.Rows.Count - 1
            Dim Cost As Double
            Dim SalValue As Double
            Dim TDepValue As Double
            Dim AcquisitionYear As Date
            Dim NoYears As Integer
            Dim DepVRate As Double
            Dim ULife As Integer

            AcquisitionYear = dtEquip.Rows(i)("Date_Accepted")
            Cost = dtEquip.Rows(i)("Cost")
            ' ULife = IIF(ISDBNULL(dtEquip.Rows(i)("useful_life")), 0, dtEquip.Rows(i)("useful_life"))
            ULife = 10 'dtEquip.Rows(i)("useful_life")

            NoYears = (Year(Date.Today.ToString("MM/dd/yyyy")) - Year(AcquisitionYear))
            SalValue = IIf(dtEquip.Rows(i)("SalvageValue") = 0.00, dtEquip.Rows(i)("Cost") * 0.05, dtEquip.Rows(i)("SalvageValue"))

            '============================
            'DEPRECIATION RATE (AMOUNT) = (COST - SALVAGE) / USEFUL LIFE
            DepVRate = (NoYears / ULife) * 100 'per year to

            'TOTAL DEPRECIATION VALUE = COST - (DEP.VALUE * NO. YEARS)
            TDepValue = Cost - (((Cost - SalValue) / ULife) * NoYears) 'FormatNumber(Cost - (DepVRate * NoYears), 2)
            Depvalueperyear.Text = (Cost - SalValue) / ULife
            objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET DepreciationValue = '" & TDepValue & "', DepreciationRate = '" & DepVRate & "',SalvageValue = '" & SalValue & "' WHERE Property_Dtl_ID = '" & dtEquip.Rows(i)("Property_Dtl_ID") & "'", CommandType.Text)
        Next


        '===== MACHINERY
        Dim dtMach As New DataTable
        dtMach = objDerived.GetDataTable("SELECT * FROM dbo.View_MachineryInformation", CommandType.Text)

        For i As Integer = 0 To dtMach.Rows.Count - 1
            Dim Cost As Double
            Dim SalValue As Double
            Dim TDepValue As Double
            Dim AcquisitionYear As Date
            Dim NoYears As Integer
            Dim DepVRate As Double
            Dim ULife As Integer

            AcquisitionYear = dtMach.Rows(i)("Date_Accepted")
            Cost = dtMach.Rows(i)("Cost")
            ULife = 10 'dtMach.Rows(i)("useful_life") ', 0, dtMach.Rows(i)("useful_life")
            NoYears = (Year(Date.Today.ToString("MM/dd/yyyy")) - Year(AcquisitionYear))
            SalValue = dtMach.Rows(i)("SalvageValue") '5% ng acq 

            '============================
            'DEPRECIATION RATE (AMOUNT) = (COST - SALVAGE) / USEFUL LIFE
            DepVRate = ((Cost - SalValue) / ULife)

            'TOTAL DEPRECIATION VALUE = COST - (DEP.VALUE * NO. YEARS)
            TDepValue = FormatNumber(Cost - (DepVRate * NoYears), 2)

            objDerived.GetRecords("UPDATE AMS.TbMachinery_Information SET DepreciationValue = '" & TDepValue & "' WHERE Property_Dtl_ID = '" & dtMach.Rows(i)("Property_Dtl_ID") & "'", CommandType.Text)
        Next


        '===== FURNITURE AND FIXTURE
        Dim dtFurn As New DataTable
        dtFurn = objDerived.GetDataTable("SELECT * FROM dbo.View_FurnitureInformation", CommandType.Text)

        For i As Integer = 0 To dtFurn.Rows.Count - 1
            Dim Cost As Double
            Dim SalValue As Double
            Dim TDepValue As Double
            Dim AcquisitionYear As Date
            Dim NoYears As Integer
            Dim DepVRate As Double
            Dim ULife As Integer

            AcquisitionYear = dtFurn.Rows(i)("Date_Accepted")
            Cost = dtFurn.Rows(i)("Cost")
            ULife = IIf(IsDBNull(dtFurn.Rows(i)("useful_life")), 5, dtFurn.Rows(i)("useful_life"))
            NoYears = (Year(Date.Today.ToString("MM/dd/yyyy")) - Year(AcquisitionYear))
            SalValue = IIf(dtFurn.Rows(i)("SalvageValue") = 0 Or IsDBNull(dtFurn.Rows(i)("SalvageValue")), 1000, dtFurn.Rows(i)("SalvageValue"))

            '============================
            'DEPRECIATION RATE (AMOUNT) = (COST - SALVAGE) / USEFUL LIFE
            If ULife = 0 Then
                ULife = 1
            End If
            DepVRate = (((Cost - SalValue) / ULife) / Cost) * 100

            'TOTAL DEPRECIATION VALUE = COST - (DEP.VALUE * NO. YEARS)
            ' TDepValue = FormatNumber(Cost - (DepVRate * NoYears), 2)
            TDepValue = ((Cost - SalValue) / ULife)

            objDerived.GetRecords("UPDATE AMS.TbFurniture_Info SET DepreciationValue = '" & TDepValue & "', DepreciationRate = '" & DepVRate & "' WHERE Property_Dtl_ID = '" & dtFurn.Rows(i)("Property_Dtl_ID") & "'", CommandType.Text)
        Next

        '===== BUILDING
        Dim dtBldg As New DataTable
        dtBldg = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BuildingInformation_v2_04052022]", CommandType.Text)

        For i As Integer = 0 To dtBldg.Rows.Count - 1
            Dim Cost As Double
            Dim SalValue As Double
            Dim TDepValue As Double
            Dim AcquisitionYear As Date
            Dim NoYears As Integer
            Dim DepVRate As Double
            Dim ULife As Integer

            AcquisitionYear = dtBldg.Rows(i)("Property_Date")
            Cost = dtBldg.Rows(i)("Cost")
            ' ULife = IIF(ISDBNULL(dtEquip.Rows(i)("useful_life")), 0, dtEquip.Rows(i)("useful_life"))
            ULife = 30 ', 0, dtEquip.Rows(i)("useful_life"))

            NoYears = (Year(Date.Today.ToString("MM/dd/yyyy")) - Year(AcquisitionYear))
            SalValue = IIf(dtBldg.Rows(i)("SalvageValue") = 0 Or IsDBNull(dtBldg.Rows(i)("SalvageValue")), dtBldg.Rows(i)("Cost") * 0.05, dtBldg.Rows(i)("SalvageValue"))

            '============================
            'DEPRECIATION RATE (AMOUNT) = (COST - SALVAGE) / USEFUL LIFE
            DepVRate = (NoYears / ULife) * 100 'per year to DepVRate = (((Cost - SalValue) / ULife) / Cost) * 100

            'TOTAL DEPRECIATION VALUE = COST - (DEP.VALUE * NO. YEARS)
            'TDepValue = FormatNumber(Cost - (DepVRate * NoYears), 2)
            TDepValue = Cost - (((Cost - SalValue) / ULife) * NoYears) 'FormatNumber(Cost - (DepVRate * NoYears), 2)
            ' TDepValue = ((Cost - SalValue) / ULife)
            ''objDerived.GetRecords("UPDATE AMS.TbBuilding_DTL SET BuildingDepreciationValue = '" & TDepValue & "',BuildingDepreciationRate = '" & DepVRate & "',SalvageValue = '" & SalValue & "' WHERE Property_Dtl_ID = '" & dtBldg.Rows(i)("Property_Dtl_ID") & "'", CommandType.Text)
        Next


        '===== Motor Vehicle
        Dim dtMotoVechicle As New DataTable
        dtMotoVechicle = objDerived.GetDataTable("SELECT * FROM dbo.View_MotorInformation", CommandType.Text)

        For i As Integer = 0 To dtMotoVechicle.Rows.Count - 1
            Dim Cost As Double
            Dim SalValue As Double
            Dim TDepValue As Double
            Dim AcquisitionYear As Date
            Dim NoYears As Integer
            Dim DepVRate As Double
            Dim ULife As Integer

            AcquisitionYear = dtMotoVechicle.Rows(i)("Date_Accepted")
            Cost = dtMotoVechicle.Rows(i)("Cost")
            ' ULife = IIF(ISDBNULL(dtEquip.Rows(i)("useful_life")), 0, dtEquip.Rows(i)("useful_life"))
            ULife = 10 'dtEquip.Rows(i)("useful_life")

            NoYears = (Year(Date.Today.ToString("MM/dd/yyyy")) - Year(AcquisitionYear))
            SalValue = dtMotoVechicle.Rows(i)("SalvageValue")

            '============================
            'DEPRECIATION RATE (AMOUNT) = (COST - SALVAGE) / USEFUL LIFE
            DepVRate = ((Cost - SalValue) / ULife)

            'TOTAL DEPRECIATION VALUE = COST - (DEP.VALUE * NO. YEARS)
            TDepValue = FormatNumber(Cost - (DepVRate * NoYears), 2)

            'objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET DepValue = '" & TDepValue & "', DepRate = '" & DepVRate & "' WHERE Property_Dtl_ID = '" & dtMotoVechicle.Rows(i)("Property_Dtl_ID") & "'", CommandType.Text)

        Next

        '===== Infrastructure
        Dim dtInfrastructure As New DataTable
        dtInfrastructure = objDerived.GetDataTable("SELECT * FROM ams.View_InfrastructureInformation", CommandType.Text)

        For i As Integer = 0 To dtInfrastructure.Rows.Count - 1
            Dim Cost As Double
            Dim SalValue As Double
            Dim TDepValue As Double
            Dim AcquisitionYear As Date
            Dim NoYears As Integer
            Dim DepVRate As Double
            Dim ULife As Integer

            AcquisitionYear = dtInfrastructure.Rows(i)("Property_Date")
            Cost = dtInfrastructure.Rows(i)("Cost")
            ' ULife = IIF(ISDBNULL(dtEquip.Rows(i)("useful_life")), 0, dtEquip.Rows(i)("useful_life"))
            ULife = 10 'dtEquip.Rows(i)("useful_life")

            NoYears = (Year(Date.Today.ToString("MM/dd/yyyy")) - Year(AcquisitionYear))
            SalValue = dtInfrastructure.Rows(i)("Cost") * 0.05

            '============================
            'DEPRECIATION RATE (AMOUNT) = (COST - SALVAGE) / USEFUL LIFE
            DepVRate = (((Cost - SalValue) / ULife) / Cost) * 100

            'TOTAL DEPRECIATION VALUE = COST - (DEP.VALUE * NO. YEARS)
            TDepValue = FormatNumber((Cost - SalValue) / ULife, 2)

            objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET DepreciationValue = '" & TDepValue & "', DepreciationRate = '" & DepVRate & "' WHERE Property_Dtl_ID = '" & dtInfrastructure.Rows(i)("Property_Dtl_ID") & "'", CommandType.Text)
        Next

    End Sub

    Protected Sub btnViewPIR_Click(sender As Object, e As EventArgs)
        ' Me.Page.Response.Redirect("~/Records/rpt_PropertyCardInventory.aspx")
        'Dim url As String = "~/Records/rpt_PropertyCardInventory.aspx"
        ' Response.Write("<script> window.open('" + url + "','_blank'); </script>")
        'ClientScript.RegisterStartupScript(Me.Page.GetType(), "", "window.open('" & url & "','Graph','height=400,width=500');", True)

        Dim url As String = "~/Records/rpt_view_propertycard_v4.aspx"

        Dim popupScript As String = "<script language='javascript'>" + "window.open('Report.aspx', 'newWindow', 'left=2, top=2,location=no, width=1010, height=660, menubar=no, resizable=yes,statusbar=yes,scrollbars=yes');" + "</script>"
        Page.RegisterStartupScript("Google", popupScript)


    End Sub
#Region "New Update"
    Public Sub EditLand()
        Try
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            objDerived.cmd.Parameters.AddWithValue("@LandId", lblIntLandId.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", lblIntProperty_ID.Text)
            ''objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", IntProperty_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@LguCode ", txtLguCode.Text)
            objDerived.cmd.Parameters.AddWithValue("@SectionNo", txtSectionNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@PIN ", txtPin.Text)
            objDerived.cmd.Parameters.AddWithValue("@TDN ", txtTdn.Text)
            objDerived.cmd.Parameters.AddWithValue("@DistrictCode", txtDistrictCode.Text)
            objDerived.cmd.Parameters.AddWithValue("@ParcelNo ", txtParcelNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@ARP ", txtArp.Text)
            objDerived.cmd.Parameters.AddWithValue("@CityMunCode", txtMunicipalCode.Text)
            objDerived.cmd.Parameters.AddWithValue("@SeriesNo ", txtSeriesNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@RevYear", txtRevYear.Text)
            objDerived.cmd.Parameters.AddWithValue("@BarangayCode", txtBrgyCode.Text)
            objDerived.cmd.Parameters.AddWithValue("@RPTIN", txtRptin.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate ", txtDepRate.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", lblDepValue.Text)
            objDerived.cmd.Parameters.AddWithValue("@LotNo ", txtLotNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@BlkNo ", txtBlkNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@StreetName ", txtStreetName.Text)
            objDerived.cmd.Parameters.AddWithValue("@Subdivision ", txtSubdivision.Text)
            objDerived.cmd.Parameters.AddWithValue("@PhaseNo ", txtPhaseNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@Purok ", txtPurok.Text)
            objDerived.cmd.Parameters.AddWithValue("@Sitio", txtSitio.Text)
            objDerived.cmd.Parameters.AddWithValue("@Barangay ", txtBrgy.Text)
            objDerived.cmd.Parameters.AddWithValue("@District ", txtDistrict.Text)
            objDerived.cmd.Parameters.AddWithValue("@CityMunicipal ", txtMunicipal.Text)
            objDerived.cmd.Parameters.AddWithValue("@Province", txtProvince.Text)
            objDerived.cmd.Parameters.AddWithValue("@Region", txtRegion.Text)
            objDerived.cmd.Parameters.AddWithValue("@ZipCode", txtZipCode.Text)
            objDerived.cmd.Parameters.AddWithValue("@Classification ", txtClassification.Text)
            objDerived.cmd.Parameters.AddWithValue("@SubClass", txtSubClass.Text)
            objDerived.cmd.Parameters.AddWithValue("@LandUse ", txtLandUse.Text)
            objDerived.cmd.Parameters.AddWithValue("@Status_1 ", txtStatus1.Text)
            objDerived.cmd.Parameters.AddWithValue("@Taxable", txtTaxable.Text)
            objDerived.cmd.Parameters.AddWithValue("@Area", txtArea.Text)
            objDerived.cmd.Parameters.AddWithValue("@Status_2 ", txtStatus2.Text)
            objDerived.cmd.Parameters.AddWithValue("@AssessedValue", txtAssessedValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@AssessedDate ", txtAVDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue ", txtMarketValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@MarketDate", txtMVDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@UnitValue", txtUnitValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@UnitDate", txtUVDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@TaxDeclarationNo", ddTaxDecNo.SelectedItem.Text)
            objDerived.cmd.Parameters.AddWithValue("@AcqMode", txtAcqMode.Text)

            objDerived.cmd.Parameters.AddWithValue("@FullAddress", txtLocation.Text)
            objDerived.cmd.Parameters.AddWithValue("@Barangay1", ddBrgy1.SelectedItem.Text)
            objDerived.cmd.Parameters.AddWithValue("@area1", txtArea1.Text)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue1", txtMarketValue1.Text.Replace(",", ""))



            objDerived.cmd.Parameters.AddWithValue("@Cost", txtAcqCost.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@OwnerName", txtPrevOwner.Text)
            objDerived.cmd.Parameters.AddWithValue("@item_id", lblIntM_Item_ID.Text)


            objDerived.Execute("AMS.sp_Edit_TbLand_Dtl_OwnerHistory_Property", CommandType.StoredProcedure)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            Button12.Text = "Edit"
            lblClassForTrap.Text = ""
            enableFalseLand()

        Catch ex As Exception
            MsgBox(ex.Message)
            ''MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, ex.Message)
        End Try

    End Sub
    Public Sub Edit_OtherVehicles()
        Try
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            objDerived.cmd.Parameters.AddWithValue("@Motor_InfoId", lbl_OV_Motor_InfoId.Text)
            objDerived.cmd.Parameters.AddWithValue("@VehicleDesc", txtWatercraftDescription.Text)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", txtWatercraftWarranty.Text)
            objDerived.cmd.Parameters.AddWithValue("@VehicleMake", txtWatercraftMake.Text)
            objDerived.cmd.Parameters.AddWithValue("@VehicleType", txtWatercraftType.Text)
            objDerived.cmd.Parameters.AddWithValue("@VehicleColor", txtWatercraftColor.Text)
            objDerived.cmd.Parameters.AddWithValue("@NoofYears", txtWatercraftNoYears.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepRate", txtWatercraftDepRate.Text)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtWatercraftUsefulLife.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepValue", txtWatercraftDepValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtWatercraftSalvageValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@MMSI", txtWatercraftMMSI.Text)
            objDerived.cmd.Parameters.AddWithValue("@CallSign", txtWatercraftCallSign.Text)
            objDerived.cmd.Parameters.AddWithValue("@IMOno", txtWatercraftImoNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@HullMaterial", txtWatercraftHullMaterial.Text)
            objDerived.cmd.Parameters.AddWithValue("@NoofMast", txtWatercraftNoofMast.Text)
            objDerived.cmd.Parameters.AddWithValue("@NoofDecks", txtWatercraftNoofDecks.Text)
            objDerived.cmd.Parameters.AddWithValue("@NoofEngine", txtWatercraftNoofEngine.Text)
            objDerived.cmd.Parameters.AddWithValue("@MainEngine", txtWatercraftMainEngine.Text)
            objDerived.cmd.Parameters.AddWithValue("@HorsePower", txtWatercraftHorsePower.Text)
            objDerived.cmd.Parameters.AddWithValue("@Grt", txtWaterCraftGRT.Text)
            objDerived.cmd.Parameters.AddWithValue("@Nrt", txtWatercraftNRT.Text)
            objDerived.cmd.Parameters.AddWithValue("@Loa", txtWatercraftLOA.Text)
            objDerived.cmd.Parameters.AddWithValue("@Breadth", txtWatercraftBreadth.Text)
            objDerived.cmd.Parameters.AddWithValue("@CarryingCapacity", txtWaterCraftCarryingCapacity.Text)

            objDerived.cmd.Parameters.AddWithValue("@Property_ID", lbl_OV_Property_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Qty", txtWatercraftQuantity.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtWatercraftAcqDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@Cost", txtWatercraftAcqCost.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@MotorID", lbl_OV_MotorID.Text)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtWatercraftMarketValue.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@Item_ID", lbl_OV_Item_ID.Text)

            objDerived.Execute("AMS.sp_Edit_Other_Vehicles", CommandType.StoredProcedure)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btn_edit_other_vehicles.Text = "Edit"
            lblClassForTrap.Text = ""
            EnableFalseOV()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Public Sub EditBuilding()
        Try
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", lblBuilding_Get_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@BuildingControlNo", txtbuildingcontrolno.Text)
            objDerived.cmd.Parameters.AddWithValue("@BuildingCode", txtbuildingCode.Text)
            objDerived.cmd.Parameters.AddWithValue("@BuildingName", txtBuildingName.Text)
            objDerived.cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
            objDerived.cmd.Parameters.AddWithValue("@PostalCode", txtbuildingpostalcode.Text)
            objDerived.cmd.Parameters.AddWithValue("@BuildingDepreciationRate", txtBuildingDepRate.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@BuildingUse", txtbuildinguse.Text)
            objDerived.cmd.Parameters.AddWithValue("@BuildingOccupancy", txtbuildingoccupancy.Text)
            objDerived.cmd.Parameters.AddWithValue("@NumberFloors", txtbuildingnumberoffloors.Text)
            objDerived.cmd.Parameters.AddWithValue("@AvgAreaFloor", txtbuildingavgareaperfloor.Text)
            objDerived.cmd.Parameters.AddWithValue("@CostPerArea", txtbuildingcostperarea.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@BuildingDepreciationValue", txtBuildingdepreciatedvalue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtEMarketValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@Barangay", txtBuildingBrgy.Text)
            objDerived.cmd.Parameters.AddWithValue("@Area", txtBuildingArea.Text)
            objDerived.cmd.Parameters.AddWithValue("@TaxDeclarationNo", txtBuildingTaxDecNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@NoofYears", txtNoYears.Text)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtUsefulLife.Text)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtSalvageValueBuilding.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@CorporationName", txtPreviousOwner.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", lblBuildingProperty_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", lblBuildingitem_id.Text)
            objDerived.cmd.Parameters.AddWithValue("@Cost", txtEAcqCost.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtEAcqDateBuilding.Text)

            objDerived.Execute("AMS.sp_Edit_Building_Dtl", CommandType.StoredProcedure)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btnBuildingEdit.Text = "Edit"
            lblClassForTrap.Text = ""
            EnableFalseBuilding()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub EditVehicles()
        Try
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            objDerived.cmd.Parameters.AddWithValue("@Property_ID", lblVechicles_Property_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Motor_InfoId", lblVehicles_Info_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@MotorID", lblVehicle_Dtl_ID.Text)

            objDerived.cmd.Parameters.AddWithValue("@Name", txtVehicleName.Text)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", txtVehiclePowerInput.Text)
            objDerived.cmd.Parameters.AddWithValue("@VehicleDesc", txtVehicleDesc.Text)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", txtVehicleWarranty.Text)
            objDerived.cmd.Parameters.AddWithValue("@VehicleMake", txtVehicleMake.Text)
            objDerived.cmd.Parameters.AddWithValue("@Qty", txtVehicleQuantity.Text)
            objDerived.cmd.Parameters.AddWithValue("@VehicleType", txtVehicleType.Text)
            objDerived.cmd.Parameters.AddWithValue("@VehicleColor", txtVehicleColor.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtVehicleAcqDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtVehicleMarketValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@Cost", txtVehicleAcqCost.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@NoofYears", txtVehicleNoYears.Text)

            objDerived.cmd.Parameters.AddWithValue("@DepRate", txtVehicleDepRate.Text)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtVehicleUsefullife.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepValue", txtVehicleDepValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtVehicleSalvageValue.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@Item_ID", lblVehicles_Item_ID.Text)

            objDerived.Execute("AMS.spEdit_Vehicles_Info_Dtl", CommandType.StoredProcedure)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btnEditVehicle.Text = "Edit"
            lblClassForTrap.Text = ""
            EnableFalseBuilding()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub Edit_Road_Bridge()
        Try
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", lblRoadBridgeEquipInfoId.Text)
            objDerived.cmd.Parameters.AddWithValue("@ProjectName", txtBridgeProjectName.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureID", txtBridgeID.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureName", txtBridgeName.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureType", txtBridgeType.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLocation", txtBridgeLocation.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNoofLanes", txtNoofLane.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficDate", txtTrafficDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@LeftLfromAddress", txtBridgeLfromAddress.Text)
            objDerived.cmd.Parameters.AddWithValue("@LeftLtoAddress", txtBridgeLtoAddress.Text)
            objDerived.cmd.Parameters.AddWithValue("@LeftNWshldrWidth", txtBridgeNorthWestWidth.Text)
            objDerived.cmd.Parameters.AddWithValue("@RightRfromAddress", txtBridgeRfromAddress.Text)
            objDerived.cmd.Parameters.AddWithValue("@RightRtoAddress", txtBridgeRtoAddress.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNumber", txtBridgeStructureNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureRoutseSignPrefix", txtBridgeRouteSignPrefix.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureRouteNo", txtBridgeRouteNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureFeaturedIntersection", txtBridgeFeaturedIntersected.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureMilePoint", txtBridgeMilePoint.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureBorderStructNo", txtBridgeBorderStructNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureRoadNo", txtBridgeRoadNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNameofRiver", txtBridgeNameofRiver.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureReferencePost", txtBridgeReferencePost.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureEndReferencePost", txtBridgeEndReferencePost.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureStartPosition", txtBridgeStartPosition.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureCurrentPosition", txtBridgeCurrentStation.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", txtBridgeDepRate.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtBridgeDepValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtBridgeSalvageValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@NoYears", txtBridgeNoYears.Text)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtBridgeUsefulLife.Text)
            objDerived.cmd.Parameters.AddWithValue("@RightSEshldrWidth", txtBridgeSouthEastWidth.Text)
            objDerived.cmd.Parameters.AddWithValue("@EquipmentId", lblRoadBridgeEquipmentId.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", txtBridgeContractor.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", txtBridgeContactPerson.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", txtBridgeCellphoneNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@marketValue", txtBridgeMarketValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", lblRoadBridgeProperty_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtBridgeAcqDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@Cost", txtBridgeAcqCost.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@Item_ID", lblRoadBridge_Item_ID.Text)

            objDerived.Execute("AMS.sp_Edit_Raod_and_Bridge", CommandType.StoredProcedure)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btn_Edit_Road_and_Bridge.Text = "Edit"
            lblClassForTrap.Text = ""
            EnableFalseRoad_Bridge()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub Edit_Books()
        Try
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", lbl_book_EquipInfoId.Text)
            objDerived.cmd.Parameters.AddWithValue("@Name", txtbookName.Text)
            objDerived.cmd.Parameters.AddWithValue("@Description", txtbookdesciption.Text)
            objDerived.cmd.Parameters.AddWithValue("@ISBN", txtBookISBN.Text)
            objDerived.cmd.Parameters.AddWithValue("@Classification", txtBookClassification.Text)
            objDerived.cmd.Parameters.AddWithValue("@ClassificationCode", txtBookClassificationCode.Text)
            objDerived.cmd.Parameters.AddWithValue("@Title", txtbookTitle.Text)
            objDerived.cmd.Parameters.AddWithValue("@Author", txtbookAuthor.Text)
            objDerived.cmd.Parameters.AddWithValue("@PublicationDate", txtBookPublicationDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@NoYears", txtbookNoYears.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", txtbookdepreciatedRate.Text)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtbookUsefulLife.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtbookdepreciatedvalue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtbookSalvageValue.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@Item_ID", lbl_book_item_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Unit_ID", drpbookUnit.SelectedValue)

            objDerived.cmd.Parameters.AddWithValue("@Property_ID", lbl_book_Property_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtbookAcqDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@Qty", txtbookQuantity.Text)
            objDerived.cmd.Parameters.AddWithValue("@Cost", txtbookAcqCost.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@EquipmentId", lbl_book_EquipmentId.Text)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtbookMarketValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@Bay", txtbookBay.Text)
            objDerived.cmd.Parameters.AddWithValue("@Column", txtbookColumn.Text)
            objDerived.cmd.Parameters.AddWithValue("@Floor", txtbookBay.Text)
            objDerived.cmd.Parameters.AddWithValue("@Room", txtbookRoom.Text)
            objDerived.cmd.Parameters.AddWithValue("@Shelves", txtbookRoom.Text)
            objDerived.cmd.Parameters.AddWithValue("@Rack", txtbookRack.Text)
            objDerived.cmd.Parameters.AddWithValue("@Bin", txtbookRack.Text)
            objDerived.cmd.Parameters.AddWithValue("@warehouseid", drpbookWarehouse.SelectedValue)


            objDerived.Execute("AMS.sp_Edit_Books", CommandType.StoredProcedure)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btn_EditBooks.Text = "Edit"
            lblClassForTrap.Text = ""
            EnableFalseBook()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub Edit_Machine()
        Try
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            objDerived.cmd.Parameters.AddWithValue("@MachineryId", lbl_MachineryId.Text)
            objDerived.cmd.Parameters.AddWithValue("@MachineName", txtMachineryName.Text)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", txtMachineryPowerInput.Text)
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", drpMachineInstalledBuilding.SelectedItem.Value)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", txtContractor.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", txtContactPerson.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", txtCellphoneNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtMachineryMarketValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@NoYears", txtMachineryNoYears.Text)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtMachineryUsefulLife.Text)

            objDerived.cmd.Parameters.AddWithValue("@MachineryInfoId", lbl_MachineryInfoId.Text)
            objDerived.cmd.Parameters.AddWithValue("@MachineDesc", txtMachineryDescription.Text)
            objDerived.cmd.Parameters.AddWithValue("@BrandModel", txtMachineryModel.Text)
            objDerived.cmd.Parameters.AddWithValue("@CarDimensions", txtMachineryDimension.Text)
            objDerived.cmd.Parameters.AddWithValue("@AreaCapacity", txtMachineryAreaCapacity.Text)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", txtMachineryWarranty.Text)
            objDerived.cmd.Parameters.AddWithValue("@MachineLocation", txtMachineryFloorLocation.Text)
            objDerived.cmd.Parameters.AddWithValue("@ServiceFloors", txtMachineryRoom.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", txtMachineryDepRate.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtequipmentdepreciatedvalue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtMachinerySalvageValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@NoPassengers", lblmachiniriesnoofpassenger.Text)
            objDerived.cmd.Parameters.AddWithValue("@MachineUnitNo", lblmachiniriesunitno.Text)
            objDerived.cmd.Parameters.AddWithValue("@WorkingLoad", lblmachiniriesworkingload.Text)
            objDerived.cmd.Parameters.AddWithValue("@RatedSpeed", lblmachiniriesratedspeed.Text)
            objDerived.cmd.Parameters.AddWithValue("@MechinePermitNo", lblmachiniriesmechpermitno.Text)
            objDerived.cmd.Parameters.AddWithValue("@DateOperate", lblmachiniriesdatetooperate.Text)
            objDerived.cmd.Parameters.AddWithValue("@DateIssued", lblmachiniriesdateissued.Text)
            objDerived.cmd.Parameters.AddWithValue("@DateInspected", lblmachiniriesdateinspected.Text)
            objDerived.cmd.Parameters.AddWithValue("@InspectedBy", lblmachiniriesinspectedby.Text)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", lblmachiniriesremarks.Text)
            objDerived.cmd.Parameters.AddWithValue("@DateTaken", lblMchneDateTaken.Text)
            objDerived.cmd.Parameters.AddWithValue("@UploadedBy", lblMchneUploadedBy.Text)
            objDerived.cmd.Parameters.AddWithValue("@Position", lblMchnePosition.Text)

            objDerived.cmd.Parameters.AddWithValue("@Property_ID", lbl_machine_Property_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtMachineryAcqDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@Cost", txtMachineryAcqCost.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@Item_ID", lbl_Machine_Item_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Unit_ID", drpMachineUnit.SelectedItem.Value)



            objDerived.Execute("AMS.sp_Edit_Machine", CommandType.StoredProcedure)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btnEdit_Mechinery.Text = "Edit"
            lblClassForTrap.Text = ""
            EnableFalseMachine()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Edit_Furnitures()
        Try
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            objDerived.cmd.Parameters.AddWithValue("@FurnitureInfoId", lbl_furniture_FurnitureInfoId.Text)
            objDerived.cmd.Parameters.AddWithValue("@Name", txtName.Text)
            objDerived.cmd.Parameters.AddWithValue("@Description", txtequipmentdesciption.Text)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", txtequipmentSerialNumber.Text)
            objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", txtAccountablePerson.Text)
            objDerived.cmd.Parameters.AddWithValue("@Dimension", txtequipmentdimension.Text)
            objDerived.cmd.Parameters.AddWithValue("@Model", txtequipmentmodel.Text)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", txtequipmentwaranty.Text)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", drpDepartmentFurnifure.SelectedItem.Value) ''FOllow uo
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", txtFurnitureDeprate.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtFurnitureDepValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtFurnitureSalvageValue.Text.Replace(",", ""))


            objDerived.cmd.Parameters.AddWithValue("@Property_ID", lbl_Furniture_Property_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_code", txtPropertyNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@Qty", txtQuantity.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtFurnitureAcqDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@Cost", txtFurnitureAcqCost.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@FurnitureId", lbl_furniture_FurnitureId.Text)
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", drpInstalledAtBuilding.SelectedItem.Value) ''FOllow uo
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtFurnitureMarketValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtFurnitureUsefulLife.Text)


            objDerived.cmd.Parameters.AddWithValue("@Item_ID", lbl_furniture_Item_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Unit_ID", drpFurnitureUnit.SelectedItem.Value) ''FOllow uo



            objDerived.Execute("AMS.sp_Edit_Furnitures_Fixes_07212022", CommandType.StoredProcedure)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btn_Edit_Furniture_Fixes.Text = "Edit"
            lblClassForTrap.Text = ""
            EnableFalseFurniture()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Edit_Office_Equipment()
        Try
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", lbl_OfficeEquipment_EquipInfoId.Text)
            objDerived.cmd.Parameters.AddWithValue("@Name", txtOfficeEquipmentName.Text)
            objDerived.cmd.Parameters.AddWithValue("@Description", txtOfficeEquipmentDesc.Text)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", txtOfficeEquipmentPowerInput.Text)
            objDerived.cmd.Parameters.AddWithValue("@Dimension", txtOfficeEquipmentDimension.Text)
            objDerived.cmd.Parameters.AddWithValue("@Model", txtOfficeEquipmentModel.Text)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", txtOfficeEquipmentWarranty.Text)
            objDerived.cmd.Parameters.AddWithValue("@NoYears", txtOfficeEquipmentNoYears.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtOfficeEquipmentDepValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", txtOfficeEquipmentDepRate.Text)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtOfficeEquipmentUsefulLife.Text)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtOfficeEquipmentSalvageValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@AreaCapacity", txtequipmentareacapacity.Text)


            objDerived.cmd.Parameters.AddWithValue("@EquipmentId", lbl_OfficeEquipment_EquipmentId.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", txtOfficeEquipmentContractor.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", txtOfficeEquipmentContactPerson.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", txtOfficeEquipmentContactNo.Text)

            If drpOfficeEquipmentBuilding.SelectedItem.Value = "N/A" Then
                objDerived.cmd.Parameters.AddWithValue("@Buildingid", 0)
            Else
                objDerived.cmd.Parameters.AddWithValue("@Buildingid", drpOfficeEquipmentBuilding.SelectedItem.Value)
            End If



            objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtOfficeEquipmentMarketValue.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", lbl_OfficeEquipment_PropertyDetai_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", txtOfficeEquipmentSerialNo.Text)

            objDerived.cmd.Parameters.AddWithValue("@Property_ID", lbl_OfficeEquipment_Property_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtOfficeEquipmentAcqDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@Cost", txtOfficeEquipmentAcqCost.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@Qty", txtOfficeEquipmentQuantity.Text)


            objDerived.cmd.Parameters.AddWithValue("@Item_ID", lbl_OfficeEquipment_Item_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Unit_ID", drpOfficeEquipmentUnit.SelectedItem.Value)




            objDerived.Execute("AMS.sp_Edit_OfficeEquipment", CommandType.StoredProcedure)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btm_Edit_Office_Equipment.Text = "Edit"
            lblClassForTrap.Text = ""
            EnableFalseOffice_Equipment()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub Edit_Equipment()
        Try
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", lbl_Equipment_EquipInfoId.Text)
            objDerived.cmd.Parameters.AddWithValue("@Name", txtDefaultEquipmentName.Text)
            objDerived.cmd.Parameters.AddWithValue("@Description", txtDefaultEquipmentDescription.Text)
            objDerived.cmd.Parameters.AddWithValue("@PowerInput", txtDefaultEquipmentPowerInput.Text)
            objDerived.cmd.Parameters.AddWithValue("@Dimension", txtDefaultEquipmentDimension.Text)
            objDerived.cmd.Parameters.AddWithValue("@Model", txtDefaultEquipmentModel.Text)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", txtDefaultEquipmentWarranty.Text)
            objDerived.cmd.Parameters.AddWithValue("@NoYears", txtDefaultEquipmentNoYears.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtDefaultEquipmentDepValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", txtDefaultEquipmentDepRate.Text)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtDefaultEquipmentUsefulLife.Text)
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtDefaultEquipmentSalvageValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@Specification", txtDefaultEquipmentSpecifications.Text)
            ''objDerived.cmd.Parameters.AddWithValue("@AreaCapacity", txtequipmentareacapacity.Text)

            objDerived.cmd.Parameters.AddWithValue("@EquipmentId", lbl_Equipment_EquipmentId.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", txtDefaultEquipmentContractor.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", txtDefaultEquipmentContactPerson.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", txtDefaultEquipmentContactNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@Buildingid", drpEquipmentInstalledBuilding.SelectedItem.Value)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtDefaultEquipmentMarketValue.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", lbl_Equipment_PropertyDetai_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", txtDefaultEquipmentSerialNumber.Text)

            objDerived.cmd.Parameters.AddWithValue("@Property_ID", lbl_Equipment_Property_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtDefaultEquipmentAcquisitionDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@Cost", txtDefaultEquipmentAcquisitionCost.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@Qty", txtDefaultEquipmentQuantity.Text)

            objDerived.cmd.Parameters.AddWithValue("@Item_ID", lbl_Equipment_Item_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Unit_ID", drpEquipmentUnit.SelectedItem.Value)

            objDerived.Execute("AMS.sp_Edit_Equipment", CommandType.StoredProcedure)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btn_Edit_Equipment.Text = "Edit"
            lblClassForTrap.Text = ""
            EnableFalseEquipment()
        Catch ex As Exception
            ''MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnLandSave_Click(sender As Object, e As EventArgs) Handles btnLandEdit.Click

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
    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs) Handles btnProceedEdit.Click
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else
            If lblClassForTrap.Text = "LAND" Then
                Button12.Text = "UPDATE"
                enableTrueLand()
            ElseIf lblClassForTrap.Text = "BUILDING" Then
                btnBuildingEdit.Text = "UPDATE"
                EnableTrueBuilding()
            ElseIf lblClassForTrap.Text = "VEHICLES" Then
                btnEditVehicle.Text = "UPDATE"
                EnableTrueVehicles()
            ElseIf lblClassForTrap.Text = "ROADBRIDGE" Then
                btn_Edit_Road_and_Bridge.Text = "UPDATE"
                EnableTrueRoad_Bridge()
            ElseIf lblClassForTrap.Text = "BOOK" Then
                btn_EditBooks.Text = "UPDATE"
                EnableTrueBook()
            ElseIf lblClassForTrap.Text = "MACHINE" Then
                btnEdit_Mechinery.Text = "UPDATE"
                EnableTrueMachine()
            ElseIf lblClassForTrap.Text = "FURNITURE_FIXTURES" Then
                btn_Edit_Furniture_Fixes.Text = "UPDATE"
                EnableTrueFurniture()
            ElseIf lblClassForTrap.Text = "OFFICE_EQUIPMENT" Then
                btm_Edit_Office_Equipment.Text = "UPDATE"
                EnableTrueOffice_Equipment()
            ElseIf lblClassForTrap.Text = "EQUIPMENT" Then
                btn_Edit_Equipment.Text = "UPDATE"
                EnableTrueEquipment()
            ElseIf lblClassForTrap.Text = "ROAD" Then
                btn_Edit_Road.Text = "UPDATE"
                EnableTrueRoad()
            ElseIf lblClassForTrap.Text = "OTHER VEHICLES" Then
                btn_edit_other_vehicles.Text = "UPDATE"
                EnableTrueOV()
            ElseIf lblClassForTrap.Text = "INTANGIBLE ASSET" Then
                btnEdit_Intangible.Text = "UPDATE"
                EnableTrueIntangible()
            End If
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fields are now open for editing")
        End If
    End Sub
    Protected Sub btnAuthCancel_Click(sender As Object, e As EventArgs) Handles btnAuthCancel.Click
        ModalPopupExtender2.Hide()
    End Sub
    Protected Sub btnBuildingEdit_Click(sender As Object, e As EventArgs) Handles btnBuildingEdit.Click
        If btnBuildingEdit.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "BUILDING"
            ModalPopupExtender2.Show()
        Else
            EditBuilding()
        End If
    End Sub
    Public Sub EnableFalseBuilding()
        txtBuildingName.Enabled = False
        txtAddress.Enabled = False
        txtBuildingBrgy.Enabled = False
        txtBuildingArea.Enabled = False
        txtBuildingTaxDecNo.Enabled = False
        txtPreviousOwner.Enabled = False
        txtEAcqDateBuilding.Enabled = False
        txtEAcqCost.Enabled = False
        txtBuildingDepRate.Enabled = False
        txtBuildingdepreciatedvalue.Enabled = False
        txtEMarketValue.Enabled = False
        txtNoYears.Enabled = False
        txtUsefulLife.Enabled = False
        txtSalvageValueBuilding.Enabled = False
        txtBuildingDepreciatedValueNew.Enabled = False
        txtbuildingcontrolno.Enabled = False
        txtbuildingCode.Enabled = False
        txtbuildinguse.Enabled = False
        txtbuildingpostalcode.Enabled = False
        txtbuildingoccupancy.Enabled = False
        txtbuildingnumberoffloors.Enabled = False
        txtbuildingavgareaperfloor.Enabled = False
        txtbuildingcostperarea.Enabled = False
    End Sub
    Public Sub EnableTrueBook()
        txtbookName.Enabled = True
        txtbookUnit.Enabled = True
        txtbookQuantity.Enabled = True
        txtbookdesciption.Enabled = True
        txtBookPrice.Enabled = True
        txtBookISBN.Enabled = True
        txtBookClassification.Enabled = True
        txtBookClassificationCode.Enabled = True
        txtbookTitle.Enabled = True
        txtbookAuthor.Enabled = True
        txtBookPublicationDate.Enabled = True
        txtbookAcqDate.Enabled = True
        txtbookMarketValue.Enabled = True
        txtbookAcqCost.Enabled = True
        txtbookNoYears.Enabled = True
        txtbookdepreciatedRate.Enabled = True
        txtbookUsefulLife.Enabled = True
        txtbookdepreciatedvalue.Enabled = True
        txtbookSalvageValue.Enabled = True
        txtbookBay.Enabled = True
        txtbookColumn.Enabled = True
        txtbookFloor.Enabled = True
        txtbookRoom.Enabled = True
        txtbookShelves.Enabled = True
        txtbookRack.Enabled = True
        txtbookBin.Enabled = True
        lbl_book_EquipInfoId.Enabled = True
        lbl_book_Property_ID.Enabled = True
        lbl_book_EquipmentId.Enabled = True
        lbl_book_item_ID.Enabled = True
        drpbookWarehouse.Enabled = True
    End Sub
    Public Sub EnableFalseBook()
        txtbookName.Enabled = False
        txtbookUnit.Enabled = False
        txtbookQuantity.Enabled = False
        txtbookdesciption.Enabled = False
        txtBookPrice.Enabled = False
        txtBookISBN.Enabled = False
        txtBookClassification.Enabled = False
        txtBookClassificationCode.Enabled = False
        txtbookTitle.Enabled = False
        txtbookAuthor.Enabled = False
        txtBookPublicationDate.Enabled = False
        txtbookAcqDate.Enabled = False
        txtbookMarketValue.Enabled = False
        txtbookAcqCost.Enabled = False
        txtbookNoYears.Enabled = False
        txtbookdepreciatedRate.Enabled = False
        txtbookUsefulLife.Enabled = False
        txtbookdepreciatedvalue.Enabled = False
        txtbookSalvageValue.Enabled = False
        txtbookBay.Enabled = False
        txtbookColumn.Enabled = False
        txtbookFloor.Enabled = False
        txtbookRoom.Enabled = False
        txtbookShelves.Enabled = False
        txtbookRack.Enabled = False
        txtbookBin.Enabled = False
        lbl_book_EquipInfoId.Enabled = False
        lbl_book_Property_ID.Enabled = False
        lbl_book_EquipmentId.Enabled = False
        lbl_book_item_ID.Enabled = False
        drpbookWarehouse.Enabled = False
    End Sub
    Public Sub EnableTrueBuilding()
        txtBuildingName.Enabled = True
        txtAddress.Enabled = True
        txtBuildingBrgy.Enabled = True
        txtBuildingArea.Enabled = True
        txtBuildingTaxDecNo.Enabled = True
        txtPreviousOwner.Enabled = True
        txtEAcqDateBuilding.Enabled = True
        txtEAcqCost.Enabled = True
        txtBuildingDepRate.Enabled = True
        txtBuildingdepreciatedvalue.Enabled = True
        txtEMarketValue.Enabled = True
        txtNoYears.Enabled = True
        txtUsefulLife.Enabled = True
        txtSalvageValueBuilding.Enabled = True
        txtBuildingDepreciatedValueNew.Enabled = True
        txtbuildingcontrolno.Enabled = True
        txtbuildingCode.Enabled = True
        txtbuildinguse.Enabled = True
        txtbuildingpostalcode.Enabled = True
        txtbuildingoccupancy.Enabled = True
        txtbuildingnumberoffloors.Enabled = True
        txtbuildingavgareaperfloor.Enabled = True
        txtbuildingcostperarea.Enabled = True
    End Sub
    Public Sub EnableTrueVehicles()
        txtVehicleName.Enabled = True
        txtVehicleDesc.Enabled = True
        txtVehicleMake.Enabled = True
        txtVehicleType.Enabled = True
        txtVehiclePowerInput.Enabled = True
        txtVehicleWarranty.Enabled = True
        txtVehicleQuantity.Enabled = True
        txtVehicleColor.Enabled = True
        txtVehicleAcqDate.Enabled = True
        txtVehicleAcqCost.Enabled = True
        txtVehicleDepRate.Enabled = True
        txtVehicleDepValue.Enabled = True
        txtVehiclesDepreciatedValueNew.Enabled = True
        txtVehicleMarketValue.Enabled = True
        txtVehicleNoYears.Enabled = True
        txtVehicleUsefullife.Enabled = True
        txtVehicleSalvageValue.Enabled = True
    End Sub
    Public Sub EnableFalseVehicles()
        txtVehicleName.Enabled = False
        txtVehicleDesc.Enabled = False
        txtVehicleMake.Enabled = False
        txtVehicleType.Enabled = False
        txtVehiclePowerInput.Enabled = False
        txtVehicleWarranty.Enabled = False
        txtVehicleQuantity.Enabled = False
        txtVehicleColor.Enabled = False
        txtVehicleAcqDate.Enabled = False
        txtVehicleAcqCost.Enabled = False
        txtVehicleDepRate.Enabled = False
        txtVehicleDepValue.Enabled = False
        txtVehiclesDepreciatedValueNew.Enabled = False
        txtVehicleMarketValue.Enabled = False
        txtVehicleNoYears.Enabled = False
        txtVehicleUsefullife.Enabled = False
        txtVehicleSalvageValue.Enabled = False
    End Sub
    Protected Sub btnEditVehicle_Click(sender As Object, e As EventArgs) Handles btnEditVehicle.Click
        If btnEditVehicle.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "VEHICLES"
            ModalPopupExtender2.Show()
        Else
            EditVehicles()
        End If
    End Sub
    Public Sub EnableTrueRoad_Bridge()
        txtBridgeProjectName.Enabled = True
        txtBridgeID.Enabled = True
        txtBridgeName.Enabled = True
        txtBridgeType.Enabled = True
        txtBridgeLocation.Enabled = True
        txtTrafficDate.Enabled = True
        txtBridgeLfromAddress.Enabled = True
        txtBridgeLtoAddress.Enabled = True
        txtBridgeNorthWestWidth.Enabled = True
        txtBridgeRfromAddress.Enabled = True
        txtBridgeRtoAddress.Enabled = True
        txtBridgeStructureNo.Enabled = True
        txtBridgeRouteSignPrefix.Enabled = True
        txtBridgeRouteNo.Enabled = True
        txtBridgeFeaturedIntersected.Enabled = True
        txtBridgeMilePoint.Enabled = True
        txtBridgeBorderStructNo.Enabled = True
        txtBridgeRoadNo.Enabled = True
        txtBridgeNameofRiver.Enabled = True
        txtBridgeReferencePost.Enabled = True
        txtBridgeEndReferencePost.Enabled = True
        txtBridgeStartPosition.Enabled = True
        txtBridgeCurrentStation.Enabled = True
        txtBridgeContractor.Enabled = True
        txtBridgeContactPerson.Enabled = True
        txtBridgeCellphoneNo.Enabled = True
        txtBridgeAcqDate.Enabled = True
        txtBridgeAcqCost.Enabled = True
        txtBridgeDepRate.Enabled = True
        txtBridgeDepValue.Enabled = True
        txtBridgeSalvageValue.Enabled = True
        txtBridgeMarketValue.Enabled = True
        txtBridgeNoYears.Enabled = True
        txtBridgeUsefulLife.Enabled = True
        txtBridgeSouthEastWidth.Enabled = True
    End Sub
    Public Sub EnableFalseRoad_Bridge()
        txtBridgeProjectName.Enabled = False
        txtBridgeID.Enabled = False
        txtBridgeName.Enabled = False
        txtBridgeType.Enabled = False
        txtBridgeLocation.Enabled = False
        txtTrafficDate.Enabled = False
        txtBridgeLfromAddress.Enabled = False
        txtBridgeLtoAddress.Enabled = False
        txtBridgeNorthWestWidth.Enabled = False
        txtBridgeRfromAddress.Enabled = False
        txtBridgeRtoAddress.Enabled = False
        txtBridgeStructureNo.Enabled = False
        txtBridgeRouteSignPrefix.Enabled = False
        txtBridgeRouteNo.Enabled = False
        txtBridgeFeaturedIntersected.Enabled = False
        txtBridgeMilePoint.Enabled = False
        txtBridgeBorderStructNo.Enabled = False
        txtBridgeRoadNo.Enabled = False
        txtBridgeNameofRiver.Enabled = False
        txtBridgeReferencePost.Enabled = False
        txtBridgeEndReferencePost.Enabled = False
        txtBridgeStartPosition.Enabled = False
        txtBridgeCurrentStation.Enabled = False
        txtBridgeContractor.Enabled = False
        txtBridgeContactPerson.Enabled = False
        txtBridgeCellphoneNo.Enabled = False
        txtBridgeAcqDate.Enabled = False
        txtBridgeAcqCost.Enabled = False
        txtBridgeDepRate.Enabled = False
        txtBridgeDepValue.Enabled = False
        txtBridgeSalvageValue.Enabled = False
        txtBridgeMarketValue.Enabled = False
        txtBridgeNoYears.Enabled = False
        txtBridgeUsefulLife.Enabled = False
        txtBridgeSouthEastWidth.Enabled = False
    End Sub
    Protected Sub btn_Edit_Road_and_Bridge_Click(sender As Object, e As EventArgs) Handles btn_Edit_Road_and_Bridge.Click
        If btn_Edit_Road_and_Bridge.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "ROADBRIDGE"
            ModalPopupExtender2.Show()
        Else
            Edit_Road_Bridge()
        End If
    End Sub
    Protected Sub btn_EditBooks_Click(sender As Object, e As EventArgs) Handles btn_EditBooks.Click
        If btn_EditBooks.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "BOOK"
            ModalPopupExtender2.Show()
        Else
            Edit_Books()
        End If
    End Sub
    Protected Sub btnEdit_Mechinery_Click(sender As Object, e As EventArgs) Handles btnEdit_Mechinery.Click
        If btnEdit_Mechinery.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "MACHINE"
            ModalPopupExtender2.Show()
        Else
            Edit_Machine()
        End If
    End Sub
    Public Sub EnableTrueMachine()
        txtMachineryName.Enabled = True
        txtMachineryDescription.Enabled = True
        txtMachineryPowerInput.Enabled = True
        txtMachineryModel.Enabled = True

        ''txtInstalledAt.Text = objDerived.GetValue("select BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID where BuildingId ='" & dt.Rows(0).Item("BuildingId").ToString & "' order by BuildingName", CommandType.Text)
        drpMachineInstalledBuilding.Enabled = True

        ''txtMachineryUnit.Text = objDerived.GetValue("select Description  From ams.m_Unit as a where Unit_ID = '" & dt.Rows(0).Item("Unit_ID").ToString & "'order by Description", CommandType.Text)
        drpMachineUnit.Enabled = True

        txtMachineryDimension.Enabled = True
        txtMachineryAreaCapacity.Enabled = True
        txtMachineryWarranty.Enabled = True
        txtMachineryFloorLocation.Enabled = True
        txtMachineryRoom.Enabled = True
        txtContractor.Enabled = True
        txtContactPerson.Enabled = True
        txtCellphoneNo.Enabled = True
        txtMachineryAcqDate.Enabled = True
        txtMachineryMarketValue.Enabled = True
        txtMachineryAcqCost.Enabled = True
        txtMachineryNoYears.Enabled = True
        txtMachineryDepRate.Enabled = True
        txtMachineryUsefulLife.Enabled = True
        txtequipmentdepreciatedvalue.Enabled = True
        txtMachinerySalvageValue.Enabled = True

        lblmachiniriesbrandmodel.Enabled = True
        lblmachiniriesDesc.Enabled = True
        lblmachinirieslocation.Enabled = True
        lblmachiniriesnoofpassenger.Enabled = True
        lblmachiniriesservicefloor.Enabled = True
        lblmachiniriesunitno.Enabled = True
        lblmachiniriesworkingload.Enabled = True
        lblmachiniriesratedspeed.Enabled = True
        lblmachiniriescardimension.Enabled = True
        lblmachiniriesmechpermitno.Enabled = True
        lblmachiniriesdatetooperate.Enabled = True
        lblmachiniriesdateissued.Enabled = True
        lblmachiniriesdateinspected.Enabled = True
        lblmachiniriesinspectedby.Enabled = True
        lblmachiniriesremarks.Enabled = True
        lblMchneDateTaken.Enabled = True
        lblMchneUploadedBy.Enabled = True
        lblMchnePosition.Enabled = True


        Dim DA As DateTime
        DA = grdpropertyListofmachinery.SelectedDataKey("Date_Accepted")
        lblMNoYears.Enabled = True


        lblmachiniriesdepreciatedrate.Enabled = True
        lblmachiniriesdepriciatedvalue.Enabled = True

        lblMULife.Enabled = True
        txtMSalValue.Enabled = True

    End Sub
    Public Sub EnableFalseMachine()
        txtMachineryName.Enabled = False
        txtMachineryDescription.Enabled = False
        txtMachineryPowerInput.Enabled = False
        txtMachineryModel.Enabled = False

        ''txtInstalledAt.Text = objDerived.GetValue("select BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID where BuildingId ='" & dt.Rows(0).Item("BuildingId").ToString & "' order by BuildingName", CommandType.Text)
        drpMachineInstalledBuilding.Enabled = False

        ''txtMachineryUnit.Text = objDerived.GetValue("select Description  From ams.m_Unit as a where Unit_ID = '" & dt.Rows(0).Item("Unit_ID").ToString & "'order by Description", CommandType.Text)
        drpMachineUnit.Enabled = False

        txtMachineryDimension.Enabled = False
        txtMachineryAreaCapacity.Enabled = False
        txtMachineryWarranty.Enabled = False
        txtMachineryFloorLocation.Enabled = False
        txtMachineryRoom.Enabled = False
        txtContractor.Enabled = False
        txtContactPerson.Enabled = False
        txtCellphoneNo.Enabled = False
        txtMachineryAcqDate.Enabled = False
        txtMachineryMarketValue.Enabled = False
        txtMachineryAcqCost.Enabled = False
        txtMachineryNoYears.Enabled = False
        txtMachineryDepRate.Enabled = False
        txtMachineryUsefulLife.Enabled = False
        txtequipmentdepreciatedvalue.Enabled = False
        txtMachinerySalvageValue.Enabled = False

        lblmachiniriesbrandmodel.Enabled = False
        lblmachiniriesDesc.Enabled = False
        lblmachinirieslocation.Enabled = False
        lblmachiniriesnoofpassenger.Enabled = False
        lblmachiniriesservicefloor.Enabled = False
        lblmachiniriesunitno.Enabled = False
        lblmachiniriesworkingload.Enabled = False
        lblmachiniriesratedspeed.Enabled = False
        lblmachiniriescardimension.Enabled = False
        lblmachiniriesmechpermitno.Enabled = False
        lblmachiniriesdatetooperate.Enabled = False
        lblmachiniriesdateissued.Enabled = False
        lblmachiniriesdateinspected.Enabled = False
        lblmachiniriesinspectedby.Enabled = False
        lblmachiniriesremarks.Enabled = False
        lblMchneDateTaken.Enabled = False
        lblMchneUploadedBy.Enabled = False
        lblMchnePosition.Enabled = False


        Dim DA As DateTime
        DA = grdpropertyListofmachinery.SelectedDataKey("Date_Accepted")
        lblMNoYears.Enabled = False


        lblmachiniriesdepreciatedrate.Enabled = False
        lblmachiniriesdepriciatedvalue.Enabled = False

        lblMULife.Enabled = False
        txtMSalValue.Enabled = False

    End Sub
    Protected Sub btn_Edit_Furniture_Fixes_Click(sender As Object, e As EventArgs) Handles btn_Edit_Furniture_Fixes.Click
        If btn_Edit_Furniture_Fixes.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "FURNITURE_FIXTURES"
            ModalPopupExtender2.Show()
        Else
            Edit_Furnitures()
        End If
    End Sub
    Public Sub EnableTrueFurniture()
        txtName.Enabled = True
        txtequipmentdesciption.Enabled = True
        txtequipmentSerialNumber.Enabled = True
        txtPropertyNo.Enabled = True
        txtFurnitureInstalledat.Enabled = True
        txtAccountablePerson.Enabled = True
        txtFurnitureUnit.Enabled = True
        txtQuantity.Enabled = True
        txtequipmentdimension.Enabled = True
        txtequipmentmodel.Enabled = True
        txtequipmentwaranty.Enabled = True
        txtDepartment.Enabled = True
        txtFurnitureAcqDate.Enabled = True
        txtFurnitureAcqCost.Enabled = True
        txtFurnitureDeprate.Enabled = True
        txtFurnitureDepValue.Enabled = True
        txtFurnitureMarketValue.Enabled = True
        txtFurnitureNoYears.Enabled = True
        txtFurnitureUsefulLife.Enabled = True
        txtFurnitureSalvageValue.Enabled = True

        drpInstalledAtBuilding.Enabled = True
        drpDepartmentFurnifure.Enabled = True
        drpFurnitureUnit.Enabled = True
    End Sub
    Public Sub EnableFalseFurniture()
        txtName.Enabled = False
        txtequipmentdesciption.Enabled = False
        txtequipmentSerialNumber.Enabled = False
        txtPropertyNo.Enabled = False
        txtFurnitureInstalledat.Enabled = False
        txtAccountablePerson.Enabled = False
        txtFurnitureUnit.Enabled = False
        txtQuantity.Enabled = False
        txtequipmentdimension.Enabled = False
        txtequipmentmodel.Enabled = False
        txtequipmentwaranty.Enabled = False
        txtDepartment.Enabled = False
        txtFurnitureAcqDate.Enabled = False
        txtFurnitureAcqCost.Enabled = False
        txtFurnitureDeprate.Enabled = False
        txtFurnitureDepValue.Enabled = False
        txtFurnitureMarketValue.Enabled = False
        txtFurnitureNoYears.Enabled = False
        txtFurnitureUsefulLife.Enabled = False
        txtFurnitureSalvageValue.Enabled = False

        drpInstalledAtBuilding.Enabled = False
        drpDepartmentFurnifure.Enabled = False
        drpFurnitureUnit.Enabled = False
    End Sub
    Protected Sub btm_Edit_Office_Equipment_Click(sender As Object, e As EventArgs) Handles btm_Edit_Office_Equipment.Click
        If btm_Edit_Office_Equipment.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "OFFICE_EQUIPMENT"
            ModalPopupExtender2.Show()
        Else
            Edit_Office_Equipment()
        End If
    End Sub
    Public Sub EnableTrueOffice_Equipment()
        txtOfficeEquipmentName.Enabled = True
        txtOfficeEquipmentDesc.Enabled = True
        txtOfficeEquipmentPowerInput.Enabled = True
        txtOfficeEquipmentDimension.Enabled = True
        txtOfficeEquipmentModel.Enabled = True
        txtOfficeEquipmentWarranty.Enabled = True
        txtOfficeEquipmentContractor.Enabled = True
        txtOfficeEquipmentContactPerson.Enabled = True
        txtOfficeEquipmentContactNo.Enabled = True
        txtOfficeEquipmentSerialNo.Enabled = True

        drpOfficeEquipmentUnit.Enabled = True

        drpOfficeEquipmentBuilding.Enabled = True
        txtOfficeEquipmentMarketValue.Enabled = True

        txtOfficeEquipmentAcqDate.Enabled = True
        txtOfficeEquipmentAcqCost.Enabled = True

        txtOfficeEquipmentNoYears.Enabled = True
        txtOfficeEquipmentDepValue.Enabled = True
        txtOfficeEquipmentDepRate.Enabled = True
        txtOfficeEquipmentUsefulLife.Enabled = True
        txtOfficeEquipmentSalvageValue.Enabled = True

        txtequipmentareacapacity.Enabled = True
        txtOfficeEquipmentQuantity.Enabled = True
        txtSpecification.Enabled = True
    End Sub
    Public Sub EnableFalseOffice_Equipment()
        txtOfficeEquipmentName.Enabled = False
        txtOfficeEquipmentDesc.Enabled = False
        txtOfficeEquipmentPowerInput.Enabled = False
        txtOfficeEquipmentDimension.Enabled = False
        txtOfficeEquipmentModel.Enabled = False
        txtOfficeEquipmentWarranty.Enabled = False
        txtOfficeEquipmentContractor.Enabled = False
        txtOfficeEquipmentContactPerson.Enabled = False
        txtOfficeEquipmentContactNo.Enabled = False
        txtOfficeEquipmentSerialNo.Enabled = False

        drpOfficeEquipmentUnit.Enabled = False

        drpOfficeEquipmentBuilding.Enabled = False
        txtOfficeEquipmentMarketValue.Enabled = False

        txtOfficeEquipmentAcqDate.Enabled = False
        txtOfficeEquipmentAcqCost.Enabled = False

        txtOfficeEquipmentNoYears.Enabled = False
        txtOfficeEquipmentDepValue.Enabled = False
        txtOfficeEquipmentDepRate.Enabled = False
        txtOfficeEquipmentUsefulLife.Enabled = False
        txtOfficeEquipmentSalvageValue.Enabled = False

        txtequipmentareacapacity.Enabled = False
        txtOfficeEquipmentQuantity.Enabled = False
        txtSpecification.Enabled = False
    End Sub
    Protected Sub btn_Edit_Equipment_Click(sender As Object, e As EventArgs) Handles btn_Edit_Equipment.Click
        If btn_Edit_Equipment.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "EQUIPMENT"
            ModalPopupExtender2.Show()
        Else
            Edit_Equipment()
        End If
    End Sub
    Public Sub EnableTrueEquipment()
        txtDefaultEquipmentName.Enabled = True
        txtDefaultEquipmentDescription.Enabled = True
        txtDefaultEquipmentPowerInput.Enabled = True
        txtDefaultEquipmentModel.Enabled = True
        txtDefaultEquipmentSerialNumber.Enabled = True
        drpEquipmentUnit.Enabled = True
        txtDefaultEquipmentQuantity.Enabled = True
        txtDefaultEquipmentWarranty.Enabled = True
        drpEquipmentInstalledBuilding.Enabled = True
        txtDefaultEquipmentDimension.Enabled = True
        txtDefaultEquipmentSpecifications.Enabled = True
        txtDefaultEquipmentContractor.Enabled = True
        txtDefaultEquipmentContactPerson.Enabled = True
        txtDefaultEquipmentContactNo.Enabled = True

        txtDefaultEquipmentAcquisitionDate.Enabled = True
        txtDefaultEquipmentAcquisitionCost.Enabled = True
        txtDefaultEquipmentDepRate.Enabled = True
        txtDefaultEquipmentDepValue.Enabled = True
        txtDefaultEquipmentMarketValue.Enabled = True
        txtDefaultEquipmentNoYears.Enabled = True
        txtDefaultEquipmentUsefulLife.Enabled = True
        txtDefaultEquipmentSalvageValue.Enabled = True
    End Sub
    Public Sub EnableFalseEquipment()
        txtDefaultEquipmentName.Enabled = False
        txtDefaultEquipmentDescription.Enabled = False
        txtDefaultEquipmentPowerInput.Enabled = False
        txtDefaultEquipmentModel.Enabled = False
        txtDefaultEquipmentSerialNumber.Enabled = False
        drpEquipmentUnit.Enabled = False
        txtDefaultEquipmentQuantity.Enabled = False
        txtDefaultEquipmentWarranty.Enabled = False
        drpEquipmentInstalledBuilding.Enabled = False
        txtDefaultEquipmentDimension.Enabled = False
        txtDefaultEquipmentSpecifications.Enabled = False
        txtDefaultEquipmentContractor.Enabled = False
        txtDefaultEquipmentContactPerson.Enabled = False
        txtDefaultEquipmentContactNo.Enabled = False

        txtDefaultEquipmentAcquisitionDate.Enabled = False
        txtDefaultEquipmentAcquisitionCost.Enabled = False
        txtDefaultEquipmentDepRate.Enabled = False
        txtDefaultEquipmentDepValue.Enabled = False
        txtDefaultEquipmentMarketValue.Enabled = False
        txtDefaultEquipmentNoYears.Enabled = False
        txtDefaultEquipmentUsefulLife.Enabled = False
        txtDefaultEquipmentSalvageValue.Enabled = False
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
    Public Sub Edit_Road()
        Try

            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", lbl_Road_EquipInfoId.Text)
            objDerived.cmd.Parameters.AddWithValue("@ProjectName", txtRoadProjectName.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureID", txtRoadID.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureName", txtRoadName.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureClassification", txtRoadClassification.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureType", txtRoadType.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureFromStreet", txtRoadFromStreet.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureToStreet", txtRoadtoStreet.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSegmentLock", txtRoadSegmentLock.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLocation", txtRoadLocation.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLength", txtRoadLength.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureNoofLanes", txtNoofLane.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureWidth", txtRoadWidth.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLaneLength", txtRoadLaneLength.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureLaneWidth", txtRoadLaneWidth.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficDirection", txtRoadTrafficDirection.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficVolume", txtRoadTrafficVolume.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureTrafficDate", txtTrafficDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSpeedLimit", txtRoadSpeedLimit.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureElevation", txtRoadElevation.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSurfaceType", txtRoadSurfaceType.Text)
            objDerived.cmd.Parameters.AddWithValue("@InfrastructureSurfaceCondition", txtRoadSurfaceCondition.Text)
            objDerived.cmd.Parameters.AddWithValue("@LeftLfromAddress", txtRoadLfromAddress.Text)
            objDerived.cmd.Parameters.AddWithValue("@LeftLtoAddress", txtRoadLtoAddress.Text)
            objDerived.cmd.Parameters.AddWithValue("@LeftNWshldrWidth", txtRoadNorthWestWidth.Text)
            objDerived.cmd.Parameters.AddWithValue("@RightRfromAddress", txtRoadRfromAddress.Text)
            objDerived.cmd.Parameters.AddWithValue("@RightRtoAddress", txtRoadRtoAddress.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", txtRoadequipmentdepreciatedRate.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtRoadequipmentdepreciatedvalue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtRoadSalvageValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@NoYears", txtRoadNoYears.Text)
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtRoadUsefulLife.Text)

            objDerived.cmd.Parameters.AddWithValue("@Property_ID", lbl_Road_Property_ID.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtRoadAcqDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@Cost", txtRoadAcqCost.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@EquipmentId", lbl_Road_EquipmentId.Text)
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtRoadMarketValue.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", txtRoadContractor.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", txtRoadContactPerson.Text)
            objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", txtRoadCellphoneNo.Text)
            objDerived.cmd.Parameters.AddWithValue("@RightSEshldrWidth", txtRoadSouthEastWidth.Text)

            objDerived.cmd.Parameters.AddWithValue("@Item_ID", lbl_Road_Item_ID.Text)

            objDerived.Execute("AMS.sp_Edit_Road", CommandType.StoredProcedure)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btn_Edit_Road.Text = "Edit"
            lblClassForTrap.Text = ""
            EnableFalseRoad()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btn_Edit_Road_Click(sender As Object, e As EventArgs) Handles btn_Edit_Road.Click
        If btn_Edit_Road.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "ROAD"
            ModalPopupExtender2.Show()
        Else
            Edit_Road()
        End If
    End Sub
    Public Sub EnableTrueRoad()
        txtRoadProjectName.Enabled = True
        txtRoadClassification.Enabled = True
        txtRoadType.Enabled = True
        txtRoadFromStreet.Enabled = True
        txtRoadtoStreet.Enabled = True
        txtRoadSegmentLock.Enabled = True
        txtRoadLocation.Enabled = True
        txtRoadLength.Enabled = True
        txtNoofLane.Enabled = True
        txtRoadWidth.Enabled = True
        txtRoadLaneLength.Enabled = True
        txtRoadLaneWidth.Enabled = True
        txtRoadTrafficDirection.Enabled = True
        txtRoadTrafficVolume.Enabled = True
        txtTrafficDate.Enabled = True
        txtRoadSpeedLimit.Enabled = True
        txtRoadElevation.Enabled = True
        txtRoadSurfaceType.Enabled = True
        txtRoadSurfaceCondition.Enabled = True
        txtRoadLfromAddress.Enabled = True
        txtRoadLtoAddress.Enabled = True
        txtRoadNorthWestWidth.Enabled = True
        txtRoadRfromAddress.Enabled = True
        txtRoadRtoAddress.Enabled = True

        txtRoadAcqDate.Enabled = True
        txtRoadAcqCost.Enabled = True
        txtRoadNoYears.Enabled = True
        txtRoadequipmentdepreciatedRate.Enabled = True
        txtRoadUsefulLife.Enabled = True
        txtRoadequipmentdepreciatedvalue.Enabled = True
        txtRoadSalvageValue.Enabled = True
        txtRoadMarketValue.Enabled = True

        txtRoadSouthEastWidth.Enabled = True
        txtRoadContractor.Enabled = True
        txtRoadContactPerson.Enabled = True
        txtRoadCellphoneNo.Enabled = True
    End Sub
    Public Sub EnableFalseRoad()
        txtRoadProjectName.Enabled = False
        txtRoadClassification.Enabled = False
        txtRoadType.Enabled = False
        txtRoadFromStreet.Enabled = False
        txtRoadtoStreet.Enabled = False
        txtRoadSegmentLock.Enabled = False
        txtRoadLocation.Enabled = False
        txtRoadLength.Enabled = False
        txtNoofLane.Enabled = False
        txtRoadWidth.Enabled = False
        txtRoadLaneLength.Enabled = False
        txtRoadLaneWidth.Enabled = False
        txtRoadTrafficDirection.Enabled = False
        txtRoadTrafficVolume.Enabled = False
        txtTrafficDate.Enabled = False
        txtRoadSpeedLimit.Enabled = False
        txtRoadElevation.Enabled = False
        txtRoadSurfaceType.Enabled = False
        txtRoadSurfaceCondition.Enabled = False
        txtRoadLfromAddress.Enabled = False
        txtRoadLtoAddress.Enabled = False
        txtRoadNorthWestWidth.Enabled = False
        txtRoadRfromAddress.Enabled = False
        txtRoadRtoAddress.Enabled = False

        txtRoadAcqDate.Enabled = False
        txtRoadAcqCost.Enabled = False
        txtRoadNoYears.Enabled = False
        txtRoadequipmentdepreciatedRate.Enabled = False
        txtRoadUsefulLife.Enabled = False
        txtRoadequipmentdepreciatedvalue.Enabled = False
        txtRoadSalvageValue.Enabled = False
        txtRoadMarketValue.Enabled = False

        txtRoadSouthEastWidth.Enabled = False
        txtRoadContractor.Enabled = False
        txtRoadContactPerson.Enabled = False
        txtRoadCellphoneNo.Enabled = False
    End Sub
    Protected Sub btn_edit_other_vehicles_Click(sender As Object, e As EventArgs) Handles btn_edit_other_vehicles.Click
        If btn_edit_other_vehicles.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "OTHER VEHICLES"
            ModalPopupExtender2.Show()
        Else
            Edit_OtherVehicles()
        End If
    End Sub
    Public Sub EnableTrueOV()
        txtWatercraftName.Enabled = True
        txtWatercraftPowerInput.Enabled = True
        txtWatercraftDescription.Enabled = True
        txtWatercraftWarranty.Enabled = True
        txtWatercraftMake.Enabled = True
        txtWatercraftQuantity.Enabled = True
        txtWatercraftType.Enabled = True
        txtWatercraftColor.Enabled = True
        txtWatercraftAcqDate.Enabled = True
        txtWatercraftMarketValue.Enabled = True
        txtWatercraftAcqCost.Enabled = True
        txtWatercraftNoYears.Enabled = True
        txtWatercraftDepRate.Enabled = True
        txtWatercraftUsefulLife.Enabled = True
        txtWatercraftDepValue.Enabled = True
        txtWatercraftSalvageValue.Enabled = True
        txtWatercraftMMSI.Enabled = True
        txtWatercraftCallSign.Enabled = True
        txtWatercraftImoNo.Enabled = True
        txtWatercraftHullMaterial.Enabled = True
        txtWatercraftNoofMast.Enabled = True
        txtWatercraftNoofDecks.Enabled = True
        txtWatercraftNoofEngine.Enabled = True
        txtWatercraftMainEngine.Enabled = True

        txtWatercraftHorsePower.Enabled = True
        txtWaterCraftGRT.Enabled = True
        txtWatercraftNRT.Enabled = True
        txtWatercraftLOA.Enabled = True
        txtWatercraftBreadth.Enabled = True
        txtWaterCraftCarryingCapacity.Enabled = True
    End Sub
    Public Sub EnableFalseOV()
        txtWatercraftName.Enabled = False
        txtWatercraftPowerInput.Enabled = False
        txtWatercraftDescription.Enabled = False
        txtWatercraftWarranty.Enabled = False
        txtWatercraftMake.Enabled = False
        txtWatercraftQuantity.Enabled = False
        txtWatercraftType.Enabled = False
        txtWatercraftColor.Enabled = False
        txtWatercraftAcqDate.Enabled = False
        txtWatercraftMarketValue.Enabled = False
        txtWatercraftAcqCost.Enabled = False
        txtWatercraftNoYears.Enabled = False
        txtWatercraftDepRate.Enabled = False
        txtWatercraftUsefulLife.Enabled = False
        txtWatercraftDepValue.Enabled = False
        txtWatercraftSalvageValue.Enabled = False
        txtWatercraftMMSI.Enabled = False
        txtWatercraftCallSign.Enabled = False
        txtWatercraftImoNo.Enabled = False
        txtWatercraftHullMaterial.Enabled = False
        txtWatercraftNoofMast.Enabled = False
        txtWatercraftNoofDecks.Enabled = False
        txtWatercraftNoofEngine.Enabled = False
        txtWatercraftMainEngine.Enabled = False

        txtWatercraftHorsePower.Enabled = False
        txtWaterCraftGRT.Enabled = False
        txtWatercraftNRT.Enabled = False
        txtWatercraftLOA.Enabled = False
        txtWatercraftBreadth.Enabled = False
        txtWaterCraftCarryingCapacity.Enabled = False
    End Sub
    Public Sub EnableTrueIntangible()
        txtIntanTitle.Enabled = True
        txtIntanBrand.Enabled = True
        txtIntanSerialNo.Enabled = True
        txtIntanNoofdisc.Enabled = True
        txtIntanModel.Enabled = True
        txtIntanLicenceDuration.Enabled = True
        txtIntanAcquisitionDate.Enabled = True
        txtIntanAcquisitionCost.Enabled = True
        txtIntanDepreciatedRate.Enabled = True
        txtIntanDepreciatedValue.Enabled = True
        txtIntanMarketValue.Enabled = True
        txtIntanNoofYears.Enabled = True
        txtIntanUsefullife.Enabled = True
        txtIntanSalvageValue.Enabled = True
        drpIntanWarehouse.Enabled = True
        txtIntanBay.Enabled = True
        txtIntanColumn.Enabled = True
        txtIntanFloor.Enabled = True
        txtIntanRoom.Enabled = True
        txtIntanShelves.Enabled = True
        txtIntanRack.Enabled = True
        txtIntanBin.Enabled = True
    End Sub
    Public Sub EnableFalseIntagible()
        txtIntanTitle.Enabled = False
        txtIntanBrand.Enabled = False
        txtIntanSerialNo.Enabled = False
        txtIntanNoofdisc.Enabled = False
        txtIntanModel.Enabled = False
        txtIntanLicenceDuration.Enabled = False
        txtIntanAcquisitionDate.Enabled = False
        txtIntanAcquisitionCost.Enabled = False
        txtIntanDepreciatedRate.Enabled = False
        txtIntanDepreciatedValue.Enabled = False
        txtIntanMarketValue.Enabled = False
        txtIntanNoofYears.Enabled = False
        txtIntanUsefullife.Enabled = False
        txtIntanSalvageValue.Enabled = False
        drpIntanWarehouse.Enabled = False
        txtIntanBay.Enabled = False
        txtIntanColumn.Enabled = False
        txtIntanFloor.Enabled = False
        txtIntanRoom.Enabled = False
        txtIntanShelves.Enabled = False
        txtIntanRack.Enabled = False
        txtIntanBin.Enabled = False
    End Sub
#End Region
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
    Protected Sub btnEdit_Intangible_Click(sender As Object, e As EventArgs) Handles btnEdit_Intangible.Click
        If btnEdit_Intangible.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "INTANGIBLE ASSET"
            ModalPopupExtender2.Show()
        Else
            Edit_Intangible()
        End If
    End Sub
    Public Sub Edit_Intangible()
        Try
            With objIntangibleInfo
                .IntangibleAssetInfoId = grdPropertyIntangible.SelectedDataKey("IntangibleAssetInfoId")
                .Brand = txtIntanBrand.Text
                .Title = txtIntanTitle.Text
                .SerialNo = txtIntanSerialNo.Text
                .Noofdisc = txtIntanNoofdisc.Text
                .Model = txtIntanModel.Text
                .LicenceDuration = txtIntanLicenceDuration.Text
                .DepreciationRate = txtIntanDepreciatedRate.Text
                .NoofYears = txtIntanNoofYears.Text
                .Usefullife = txtIntanUsefullife.Text
            End With
            Dim Intan_info_id As Integer
            Intan_info_id = objIntangibleInfo.Update()


            With objIntangibleDtl
                .IntangibleAssetID = grdPropertyIntangible.SelectedDataKey("IntangibleAssetID")
                .AcqCost = txtIntanAcquisitionCost.Text.Replace(",", "")
                .DepreciatedValue = txtIntanDepreciatedValue.Text.Replace(",", "")
                .MarketValue = txtIntanMarketValue.Text.Replace(",", "")
                .SalvageValue = txtIntanSalvageValue.Text.Replace(",", "")
                .WarehouseID = drpIntanWarehouse.SelectedValue
                .Bay = txtIntanBay.Text
                .Column = txtIntanColumn.Text
                .Floor = txtIntanFloor.Text
                .Room = txtIntanRoom.Text
                .Shelves = txtIntanShelves.Text
                .Rack = txtIntanRack.Text
                .Bin = txtIntanBin.Text
            End With
            Dim Intan_dtl_id As Integer
            Intan_dtl_id = objIntangibleDtl.update()


            objDerived.GetRecords("UPDATE [AMS].[Property] SET Property_Date = '" & txtIntanAcquisitionDate.Text &
                                  "',Cost='" & txtIntanAcquisitionCost.Text.Replace(",", "") &
                                  "' WHERE Property_ID='" & grdPropertyIntangible.SelectedDataKey("Property_ID") & "' ", CommandType.Text)

            objDerived.GetRecords("UPDATE [AMS].[Property_Dtl] SET PropertyNo='" & txtIntanSerialNo.Text &
                                   "', Amount='" & txtIntanAcquisitionCost.Text.Replace(",", "") &
                                   "' WHERE PropertyDetai_ID='" & grdPropertyIntangible.SelectedDataKey("PropertyDetai_ID") & "' ", CommandType.Text)

            objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] SET SerialNo='" & txtIntanSerialNo.Text &
                                   "', DebitCost='" & txtIntanAcquisitionCost.Text.Replace(",", "") &
                                   "' WHERE Ledger_ID='" & grdPropertyIntangible.SelectedDataKey("Ledger_ID") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btnEdit_Intangible.Text = "Edit"
            lblClassForTrap.Text = ""
            EnableFalseIntagible()

        Catch ex As Exception
            ''MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub drpIntanSubClassification_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpIntanSubClassification.SelectedIndexChanged
        mwProperty.SetActiveView(Me.vwGridViewIntangible)
        LoadIntangible()
    End Sub
    Protected Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If Button12.Text = "Edit" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            lblClassForTrap.Text = "LAND"
            ModalPopupExtender2.Show()
        Else
            EditLand()
        End If
    End Sub
End Class







