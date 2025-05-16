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

Partial Class Records_PropertyCard
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim image As New Image
    Dim obj As New BaseClasses.Items
    Dim BuildingDocumentID As New Integer

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            'LoadUpdateDepreciatedValue()
            txtDate.text = Date.Now.ToString("MM-dd-yyyy")

            Dim Classification As New DataTable
            Classification = objDerived.GetDataTable("select [ClassificationId],[ClassificationName] From [dbo].[tbl_Classification] where [ClassificationName] like 'Equipment%'", CommandType.Text)
            ddClass.DataSource = CType(Classification, DataTable)
            Me.ddClass.DataTextField = ("ClassificationName")
            Me.ddClass.DataValueField = ("ClassificationId")
            Me.ddClass.DataBind()
            selectClassification()

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

                'gvAccount = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 3 & "'", CommandType.Text)
                'ddGlAccount.DataSource = CType(gvAccount, DataTable)
                'ddGlAccount.DataTextField = ("GA_Title")
                'ddGlAccount.DataValueField = ("GA_ID")
                'ddGlAccount.DataBind()
                selectClassification()
                Session("GLAccount") = GLAccnt
                multiviewselected()

                txtAccountSearch.Text = Session("ItemName")
                LoadSearchMe()

                Session("Records") = ""

            Else
                'gvAccount = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 3 & "'", CommandType.Text)
                'ddGlAccount.DataSource = CType(gvAccount, DataTable)
                'ddGlAccount.DataTextField = ("GA_Title")
                'ddGlAccount.DataValueField = ("GA_ID")
                'ddGlAccount.DataBind()
                selectClassification()

                dtMotors = Nothing
                dtEquipments = Nothing
                dtFurnitures = Nothing
                dtMachines = Nothing

                multiviewselected()

            End If
        End If

        txtAccountSearch.Attributes.Add("onkeypress", "return fun1(event,'" & ItemSearch.ClientID & "')")
        txtMotorSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnMotorSerialSearch.ClientID & "')")
        txtSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnEquipmentSerialSearch.ClientID & "')")
        txtMachinerySearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnMachinerySerial.ClientID & "')")
        txtFurnitureSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & Button3.ClientID & "')")
        loadEquipmentLedger()
    End Sub
    Protected Sub ddGlAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddGlAccount.SelectedIndexChanged
        Dim x As Integer
        x = ddGlAccount.SelectedValue()
        SelectGAaccount()
        Session("GA_ID") = ddGlAccount.SelectedValue()
        multiviewselected()
    End Sub

    Public Sub multiviewselected()
        If ddGlAccount.SelectedItem.Value = 1060 Or ddGlAccount.SelectedItem.Value = 1062 Or ddGlAccount.SelectedItem.Value = 1067 Then
            ' LAND AND LAND IMPROVEMENTS
            txtAccountSearch.Text = ""

            lblHistoryDetails.Text = "LAND"
            Me.mvPropertyInformation.SetActiveView(Me.vwLandDetails)

            LoadLandMainGrid()

        ElseIf ddGlAccount.SelectedItem.Value = 1082 Or ddGlAccount.SelectedItem.Value = 1085 Then
            ' BUILDINGS
            txtAccountSearch.Text = ""

            lblHistoryDetails.Text = "BUILDINGS"
            Me.mvPropertyInformation.SetActiveView(Me.vwBldgDetails)

            LoadBuildingMainGrid()

        ElseIf ddGlAccount.SelectedItem.Value = 1166 Then
            ' TRANSPORTATIONS
            txtAccountSearch.Text = ""
            txtMotorSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnMotorSerialSearch.ClientID & "')")

            lblHistoryDetails.Text = "TRANSPORTATION"
            Me.mvPropertyInformation.SetActiveView(Me.vwMotorVehicle)
            Me.mvledger.SetActiveView(Me.vwledger)
            'pnlhistoryledger.Visible = True

            loadMotorMainGrid()

            'loadMotorList()
            'loadMotorInformation()
            'loadMotorLedger()

        ElseIf ddGlAccount.SelectedItem.Value = 1127 Then
            ' MACHINERIES
            txtAccountSearch.Text = ""
            txtMachinerySearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnMachinerySerial.ClientID & "')")

            lblHistoryDetails.Text = "MACHINERIES"
            Me.mvPropertyInformation.SetActiveView(Me.vwmachineries)
            Me.mvledger.SetActiveView(Me.vwledger)

            'pnlhistoryledger.Visible = True

            loadMachineryMainGrid()

            'loadMachineryList()
            'loadMachineryInformation()
            'loadMachineryLedger()
        ElseIf ddGlAccount.SelectedItem.Value = 1118 Then
            ' FURNITURE AND FIXTURES
            txtAccountSearch.Text = ""
            txtFurnitureSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & Button3.ClientID & "')")

            lblHistoryDetails.Text = "FURNITURE AND FIXTURES HISTORY DETAILS"
            Me.mvPropertyInformation.SetActiveView(Me.vwfurnitureandfixtures)
            Me.mvledger.SetActiveView(Me.vwledger)
            'pnlhistoryledger.Visible = True

            loadFurnitureMainGrid()

        Else
            'ALL EQUIPMENTS
            txtAccountSearch.Text = ""
            txtSerialSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnEquipmentSerialSearch.ClientID & "')")

            lblHistoryDetails.Text = "EQUIPMENT"

            Me.mvPropertyInformation.SetActiveView(Me.vwEquipment)
            Me.mvledger.SetActiveView(Me.vwledger)
            'pnlhistoryledger.Visible = True

            LoadEquipmentMainGrid()


        End If

    End Sub

    Protected Sub gvsearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvsearch.SelectedIndexChanged
        If ddGlAccount.SelectedItem.Value = 1060 Or ddGlAccount.SelectedItem.Value = 1067 Or ddGlAccount.SelectedItem.Value = 1062 Then
            'LAND AND LAND IMPROVEMENTS
            loadLandInformation()

        ElseIf ddGlAccount.SelectedItem.Value = 1082 Or ddGlAccount.SelectedItem.Value = 1085 Then
            'BUILDING
            loadBuildingDtl()
        End If

    End Sub
    Protected Sub gvsearchproperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If ddGlAccount.SelectedItem.Value = 1166 Then
                'TRANSPORTATION 
                If gvsearchproperty.SelectedDataKey("Item_ID").ToString = "" Then
                    grdlistofMotors.DataSource = createdatatable4A(3)
                    grdlistofMotors.DataBind()
                    LoadMotorDtl()

                    grdLedger1.DataSource = createdatatableledger(10)
                    grdLedger1.DataBind()

                Else
                    loadMotorList()
                    grdlistofMotors.SelectedIndex = 0

                    loadMotorInformation()
                    loadMotorLedger()
                End If
            ElseIf ddGlAccount.SelectedItem.Value = 1127 Then
                'MACHINERIES
                If gvsearchproperty.SelectedDataKey("Item_ID").ToString = "" Then
                    grdpropertyListofmachinery.DataSource = createdatatable4A(3)
                    grdpropertyListofmachinery.DataBind()
                    LoadMachineryDTL()

                    grdLedger1.DataSource = createdatatableledger(10)
                    grdLedger1.DataBind()

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

                    grdLedger1.DataSource = createdatatableledger(10)
                    grdLedger1.DataBind()

                Else
                    loadFurnitureList()
                    grdfurnitureandfixtures.SelectedIndex = 0

                    loadFurnitureInformation()
                    loadFurnitureLedger()
                End If

            Else
                'ALL EQUIPMENTS
                hdnItemNo.value = gvsearchproperty.SelectedDataKey("Item_ID").ToString
                If gvsearchproperty.SelectedDataKey("Item_ID").ToString = "" Then
                    grdlistofEuipment.DataSource = createdatatable4A(3)
                    grdlistofEuipment.DataBind()
                    LoadEquipDTL()

                    grdLedger1.DataSource = createdatatableledger(10)
                    grdLedger1.DataBind()

                Else
                    loadEquipmentList()
                    grdlistofEuipment.SelectedIndex = 0

                    loadEquipmentInformation()
                    loadEquipmentLedger()
                End If


            End If
        Catch ex As Exception

        End Try
    End Sub


    ' MAIN DATA GRIDS
    Protected Sub LoadLandMainGrid()
        'for Land and Land Improvements
        Me.mwProperty.SetActiveView(Me.vwListLandBldg)

        'dtAccount = objDerived.GetDataTable("Exec [dbo].[SMSS_ProtertyLANDBLDG] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("EXEC [AMS].[sp_RecordsList_LandBldg] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearch.DataSource = createdatatable2(3)
            gvsearch.DataBind()

            LoadLandDTL()

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
    End Sub
    Protected Sub LoadBuildingMainGrid()
        'for Building
        Me.mwProperty.SetActiveView(Me.vwListLandBldg)

        dtAccount = objDerived.GetDataTable("Exec [dbo].[SMSS_ProtertyLANDBLDG] '" & ddGlAccount.SelectedItem.Value & "'", CommandType.Text)
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
            gvsearch.SelectedIndex = 0

            loadBuildingDtl()
        End If
    End Sub
    Protected Sub LoadEquipmentMainGrid()
        Dim Categoryid As Integer

        If ddCategory.text = "" Then
            Categoryid = 0
        Else
            Categoryid = ddCategory.selecteditem.value
        End If
        Dim subcategory As Integer


        If ddSubCategory.text = "" Then
            subcategory = 0
        Else
            subcategory = ddSubCategory.selecteditem.value
        End If


        ' for Equipments
        Me.mwProperty.SetActiveView(Me.vwListEquipements)
        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Equipments] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
        'dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_v1_02262022] '" & ddGlAccount.SelectedValue() & "','" & Categoryid & "','" & subcategory & "'", CommandType.Text)



        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty.DataSource = createdatatable15(3)
            gvsearchproperty.DataBind()

            grdlistofEuipment.DataSource = createdatatable4A(3)
            grdlistofEuipment.DataBind()

            LoadEquipDTL()

            grdLedger1.DataSource = createdatatableledger(10)
            grdLedger1.DataBind()

        Else
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
        Me.mwProperty.SetActiveView(Me.vwListEquipements)
        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Motor] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty.DataSource = createdatatable15(3)
            gvsearchproperty.DataBind()

            grdlistofMotors.DataSource = createdatatable4A(3)
            grdlistofMotors.DataBind()

            LoadMotorDtl()

            grdLedger1.DataSource = createdatatableledger(10)
            grdLedger1.DataBind()

        Else
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

            loadMotorList()
            loadMotorInformation()
            loadMotorLedger()
        End If
    End Sub
    Protected Sub loadMachineryMainGrid()
        ' for Machinery
        Me.mwProperty.SetActiveView(Me.vwListEquipements)
        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Machinery] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords] '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty.DataSource = createdatatable15(3)
            gvsearchproperty.DataBind()

            grdpropertyListofmachinery.DataSource = createdatatable4A(3)
            grdpropertyListofmachinery.DataBind()

            LoadMachineryDTL()

            grdLedger1.DataSource = createdatatableledger(10)
            grdLedger1.DataBind()

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
        Me.mwProperty.SetActiveView(Me.vwListEquipements)
        'dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Furniture] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)

        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords]  '" & ddGlAccount.SelectedValue() & "'", CommandType.Text)
        If dtAccount.Rows.Count = 0 Then
            gvsearchproperty.DataSource = createdatatable15(3)
            gvsearchproperty.DataBind()

            grdfurnitureandfixtures.DataSource = createdatatable4A(3)
            grdfurnitureandfixtures.DataBind()

            LoadFurnitureDTL()

            grdLedger1.DataSource = createdatatableledger(10)
            grdLedger1.DataBind()


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


    'PAGE INDEX CHANGING
    Protected Sub gvsearch_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If ddGlAccount.SelectedValue = 1 Then
            'LAND AND LAND IMPROVEMENTS
            Me.mwProperty.SetActiveView(Me.vwListLandBldg)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Land] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable2(3 - dtAccount.Rows.Count))
            End If
            gvsearch.PageIndex = e.NewPageIndex
            gvsearch.DataSource = dtAccount
            gvsearch.DataBind()
            gvsearch.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 2 Then
            ' BUILDINGS
            Me.mwProperty.SetActiveView(Me.vwListLandBldg)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_Building] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by date_purchased", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable2(3 - dtAccount.Rows.Count))
            End If
            gvsearch.PageIndex = e.NewPageIndex
            gvsearch.DataSource = dtAccount
            gvsearch.DataBind()
            gvsearch.SelectedIndex = 0
        End If

    End Sub
    Protected Sub gvsearchproperty_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If ddGlAccount.SelectedValue = 3 Then
            ' EQUIPMENTS           
            Me.mwProperty.SetActiveView(Me.vwListEquipements)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Equipments] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.PageIndex = e.NewPageIndex
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 4 Then
            ' TRANSPORTATIONS
            Me.mwProperty.SetActiveView(Me.vwListEquipements)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Motor] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.PageIndex = e.NewPageIndex
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 5 Then
            ' MACHINERIES
            Me.mwProperty.SetActiveView(Me.vwListEquipements)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Machinery] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.PageIndex = e.NewPageIndex
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0

        ElseIf ddGlAccount.SelectedValue = 6 Then
            ' FURNITURE AND FIXTURES
            Me.mwProperty.SetActiveView(Me.vwListEquipements)

            dtAccount = objDerived.GetDataTable("select *  from [dbo].[view_Furniture] where TD_ID = '" & ddGlAccount.SelectedValue() & "' order by  ItemDescription", CommandType.Text)
            If dtAccount.Rows.Count < 4 Then
                dtAccount.Merge(createdatatable15(3 - dtAccount.Rows.Count))
            End If
            gvsearchproperty.DataSource = dtAccount
            gvsearchproperty.DataBind()
            gvsearchproperty.SelectedIndex = 0
        End If
    End Sub


    ' LAND MAIN INFORMATION & DETAILS
    Protected Sub loadLandInformation()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("Select * from [dbo].[View_LandInformation] where Received_Dtl_ID = '" & gvsearch.SelectedDataKey("Received_Dtl_ID") & "'", CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadLandDTL()
        Else
            lblLguCode.Text = dt.Rows(0).Item("LguCode").ToString
            lblDistrictCode.Text = dt.Rows(0).Item("DistrictCode").ToString
            lblMunicipalCode.Text = dt.Rows(0).Item("CityMunCode").ToString
            lblBrgyCode.Text = dt.Rows(0).Item("BarangayCode").ToString
            lblSectionNo.Text = dt.Rows(0).Item("SectionNo").ToString
            lblParcelNo.Text = dt.Rows(0).Item("ParcelNo").ToString
            lblSeriesNo.Text = dt.Rows(0).Item("SeriesNo").ToString
            lblPin.Text = dt.Rows(0).Item("PIN").ToString
            lblArp.Text = dt.Rows(0).Item("ARP").ToString
            lblRevYear.Text = dt.Rows(0).Item("RevYear").ToString
            lblRptin.Text = dt.Rows(0).Item("RPTIN").ToString
            lblTdn.Text = dt.Rows(0).Item("TDN").ToString
            lblDepRate.Text = dt.Rows(0).Item("DepreciationRate").ToString
            lblDepValue.Text = dt.Rows(0).Item("DepreciationValue").ToString
            lblLotNo.Text = dt.Rows(0).Item("LotNo").ToString
            lblBlkNo.Text = dt.Rows(0).Item("BlkNo").ToString
            lblStreetName.Text = dt.Rows(0).Item("StreetName").ToString
            lblSubdivision.Text = dt.Rows(0).Item("Subdivision").ToString
            lblPhaseNo.Text = dt.Rows(0).Item("PhaseNo").ToString
            lblPurok.Text = dt.Rows(0).Item("Purok").ToString
            lblSitio.Text = dt.Rows(0).Item("Sitio").ToString
            lblBrgy.Text = dt.Rows(0).Item("Barangay").ToString
            lblDistrict.Text = dt.Rows(0).Item("District").ToString
            lblMunicipal.Text = dt.Rows(0).Item("CityMunicipal").ToString
            lblRegion.Text = dt.Rows(0).Item("Region").ToString
            lblProvince.Text = dt.Rows(0).Item("Province").ToString
            lblZipCode.Text = dt.Rows(0).Item("ZipCode").ToString
            lblClassification.Text = dt.Rows(0).Item("Classification").ToString
            lblSubClass.Text = dt.Rows(0).Item("SubClass").ToString
            lblLandUse.Text = dt.Rows(0).Item("LandUse").ToString
            lblStatus1.Text = dt.Rows(0).Item("Status_1").ToString
            lblTaxable.Text = dt.Rows(0).Item("Taxable").ToString
            lblArea.Text = dt.Rows(0).Item("Area").ToString
            lblStatus2.Text = dt.Rows(0).Item("Status_2").ToString
            lblAssessedValue.Text = dt.Rows(0).Item("AssessedValue").ToString
            lblAVDate.Text = dt.Rows(0).Item("AssessedDate").ToString
            lblMarketValue.Text = dt.Rows(0).Item("MarketValue").ToString
            lblMVDate.Text = dt.Rows(0).Item("MarketDate").ToString
            lblUnitValue.Text = dt.Rows(0).Item("UnitValue").ToString
            lblUVDate.Text = dt.Rows(0).Item("UnitDate").ToString
            lblAVAmount.Text = dt.Rows(0).Item("AVAmountWords").ToString
            lblMVAmount.Text = dt.Rows(0).Item("MVAmountWords").ToString
            ddAssessmentLvl.SelectedValue = dt.Rows(0).Item("AssessmentLevel").ToString
        End If
    End Sub
    Protected Sub LoadLandDTL()
        lblLguCode.Text = ""
        lblDistrictCode.Text = ""
        lblMunicipalCode.Text = ""
        lblBrgyCode.Text = ""
        lblSectionNo.Text = ""
        lblParcelNo.Text = ""
        lblSeriesNo.Text = ""
        lblPin.Text = ""
        lblArp.Text = ""
        lblRevYear.Text = ""
        lblRptin.Text = ""
        lblTdn.Text = ""
        lblDepRate.Text = ""
        lblDepValue.Text = ""
        lblLotNo.Text = ""
        lblBlkNo.Text = ""
        lblStreetName.Text = ""
        lblSubdivision.Text = ""
        lblPhaseNo.Text = ""
        lblPurok.Text = ""
        lblSitio.Text = ""
        lblBrgy.Text = ""
        lblDistrict.Text = ""
        lblMunicipal.Text = ""
        lblRegion.Text = ""
        lblProvince.Text = ""
        lblZipCode.Text = ""
        lblClassification.Text = ""
        lblSubClass.Text = ""
        lblLandUse.Text = ""
        lblStatus1.Text = ""
        lblTaxable.Text = ""
        lblArea.Text = ""
        lblStatus2.Text = ""
        lblAssessedValue.Text = ""
        lblAVDate.Text = ""
        lblMarketValue.Text = ""
        lblMVDate.Text = ""
        lblUnitValue.Text = ""
        lblUVDate.Text = ""
        lblAVAmount.Text = ""
        lblMVAmount.Text = ""
        ddAssessmentLvl.SelectedValue = ""
    End Sub


    ' BUILDING MAIN INFORMATION & DETAILS
    Protected Sub loadBuildingDtl()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("Select * from [dbo].[View_BuildingInformation] where Received_Dtl_ID = '" & gvsearch.SelectedDataKey("Received_Dtl_ID") & "'", CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadBldgDTL()
        Else
            lblbuildingcontrolno.Text = dt.Rows(0).Item("BuildingControlNo").ToString
            lblbuildingCode.Text = dt.Rows(0).Item("BuildingCode").ToString
            lblbuildingname.Text = dt.Rows(0).Item("BuildingName").ToString
            lblbuildingaddress.Text = dt.Rows(0).Item("BuildingAddress").ToString
            lblbuildingpostalcode.Text = dt.Rows(0).Item("PostalCode").ToString
            lblbuildingDepriciationrate.Text = dt.Rows(0).Item("BuildingDepreciationRate").ToString
            lblbuildinguse.Text = dt.Rows(0).Item("BuildingUse").ToString
            lblbuildingoccupancy.Text = dt.Rows(0).Item("BuildingOccupancy").ToString
            lblbuildingnumberoffloors.Text = dt.Rows(0).Item("NumberFloors").ToString
            lblbuildingavgareaperfloor.Text = dt.Rows(0).Item("AvgAreaFloor").ToString
            lblbuildingcostperarea.Text = dt.Rows(0).Item("CostPerArea").ToString
            lblbuildingdepreciatedvalue.Text = FormatNumber(dt.Rows(0).Item("BuildingDepreciationValue").ToString, 2)
            lblbuildingdatetaken.Text = dt.Rows(0).Item("DateTaken").ToString
            lblbuildinguploadedby.Text = dt.Rows(0).Item("UploadedBy").ToString
            lblbuildingposition.Text = dt.Rows(0).Item("Position").ToString
        End If
    End Sub
    Protected Sub LoadBldgDTL()
        lblbuildingcontrolno.Text = ""
        lblbuildingCode.Text = ""
        lblbuildingname.Text = ""
        lblbuildingaddress.Text = ""
        lblbuildingpostalcode.Text = ""
        lblbuildingDepriciationrate.Text = ""
        lblbuildinguse.Text = ""
        lblbuildingoccupancy.Text = ""
        lblbuildingnumberoffloors.Text = ""
        lblbuildingavgareaperfloor.Text = ""
        lblbuildingcostperarea.Text = ""
        lblbuildingdepreciatedvalue.Text = ""
        lblbuildingdatetaken.Text = ""
        lblbuildinguploadedby.Text = ""
        lblbuildingposition.Text = ""
    End Sub



    ' EQUIPMENTS MAIN INFORMATION AND DETAILS 4428 5586
    Protected Sub loadEquipmentList() '[dbo].[SMSS_EquipmentList]
        dtEquipments = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtEquipments.Rows.Count < 4 Then
            dtEquipments.Merge(createdatatable4A(3 - dtEquipments.Rows.Count))
        End If
        grdlistofEuipment.DataSource = dtEquipments
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
    Protected Sub grdlistofEuipment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
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
            lblUsefulLife.Text = iif(isdbnull(dt.Rows(0)("useful_life")), 0, dt.Rows(0)("useful_life"))
            txtSalvageValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

            Session("useful_life") = dt.Rows(0)("useful_life")

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

        If hdnItemNo.value = "" Then
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)

        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.value & "'", CommandType.Text)

        End If


        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()

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
        dtMotors = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
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
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("Select * from [dbo].[View_MotorInformation] where Property_Dtl_ID = '" & grdlistofMotors.SelectedDataKey("PropertyDetai_ID") & "' ORDER BY Date_Accepted", CommandType.Text)
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

    Protected Sub loadMotorLedger()
        lblHistoryDetails.Text = "TRANSPORTATION"
        btnvehicleledger.CssClass = "Clicked"
        btnvehiclerepairs.CssClass = "Initial"
        btnvehicledocattach.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwledger)

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()

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
        dtMachines = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtMachines.Rows.Count < 4 Then
            dtMachines.Merge(createdatatable4A(3 - dtMachines.Rows.Count))
        End If
        grdpropertyListofmachinery.DataSource = dtMachines
        grdpropertyListofmachinery.DataBind()
        grdpropertyListofmachinery.SelectedIndex = 0
    End Sub
    Protected Sub grdpropertyListofmachinery_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            loadMachineryInformation()
            'loadMachineryLedger()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub grdpropertyListofmachinery_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
        End If
        grdpropertyListofmachinery.PageIndex = e.NewPageIndex
        grdpropertyListofmachinery.DataSource = dtAccount
        grdpropertyListofmachinery.DataBind()
        grdpropertyListofmachinery.SelectedIndex = 0
    End Sub
    Protected Sub loadMachineryInformation()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("Select * from [dbo].[View_MachineryInformation] where Property_Dtl_ID = '" & grdpropertyListofmachinery.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadMachineryDTL()
        Else
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

            lblMULife.Text = dt.Rows(0)("useful_life")
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
        lblHistoryDetails.Text = "MACHINERY"
        btnmachineryLedger.CssClass = "Clicked"
        btnmachineryRepairs.CssClass = "Initial"
        btnmachineryDocattach.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwledger)

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()

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
        dtFurnitures = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtFurnitures.Rows.Count < 4 Then
            dtFurnitures.Merge(createdatatable4A(3 - dtFurnitures.Rows.Count))
        End If
        grdfurnitureandfixtures.DataSource = dtFurnitures
        grdfurnitureandfixtures.DataBind()
        grdfurnitureandfixtures.SelectedIndex = 0
    End Sub
    Protected Sub grdfurnitureandfixtures_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            loadFurnitureInformation()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub grdfurnitureandfixtures_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
        End If
        grdfurnitureandfixtures.PageIndex = e.NewPageIndex
        grdfurnitureandfixtures.DataSource = dtAccount
        grdfurnitureandfixtures.DataBind()
        grdfurnitureandfixtures.SelectedIndex = 0
    End Sub
    Protected Sub loadFurnitureInformation()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FurnitureInformation] WHERE Property_Dtl_ID = '" & grdfurnitureandfixtures.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
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



            lblFULife.Text = dt.Rows(0)("useful_life")
            txtFSalValue.Text = FormatNumber(dt.Rows(0)("SalvageValue"), 2)

            If txtFSalValue.Text = 0 Then
                lblfurnituredepreciatedrate.Text = 0
                lblfurnituredepriatedvalue.Text = 0
            Else
                lblfurnituredepreciatedrate.Text = FormatNumber(dt.Rows(0)("DepreciationRate"), 2)
                lblfurnituredepriatedvalue.Text = FormatNumber(dt.Rows(0)("DepreciationValue"), 2)

            End If

            Session("useful_life") = dt.Rows(0)("useful_life")

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
        dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()

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
        End If
    End Sub
    Protected Sub grdfurnitureandfixtures_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdfurnitureandfixtures, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

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
        dtSearch = objDerived.GetDataTable("EXEC [dbo].[SMSS_ProtertyRecords_Search] '" & Session("GA_ID") & "', '" & txtAccountSearch.Text & "'", CommandType.Text)
        If dtSearch.Rows.Count < 5 Then
            dtSearch.Merge(createdatatable15(5 - dtSearch.Rows.Count))
        End If
        gvsearchproperty.DataSource = dtSearch
        gvsearchproperty.DataBind()
        gvsearchproperty.SelectedIndex = -1


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
        Session("Item_ID") = gvsearchproperty.SelectedDataKey("Item_ID")
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
            Dim Cost As Decimal
            Dim SalValue As Decimal
            Dim TDepValue As Decimal
            Dim AcquisitionYear As Date
            Dim NoYears As Integer
            Dim DepVRate As Double
            Dim ULife As Integer

            AcquisitionYear = dtEquip.Rows(i)("Date_Accepted")
            Cost = CType(dtEquip.Rows(i)("Cost"), Decimal)
            ULife = dtEquip.Rows(i)("useful_life")
            NoYears = (Year(Date.Today.ToString("MM/dd/yyyy")) - Year(AcquisitionYear))
            SalValue = dtEquip.Rows(i)("SalvageValue")

            '============================
            'DEPRECIATION RATE (AMOUNT) = (COST - SALVAGE) / USEFUL LIFE
            DepVRate = ((Cost - SalValue) / ULife)

            'TOTAL DEPRECIATION VALUE = COST - (DEP.VALUE * NO. YEARS)
            TDepValue = FormatNumber(Cost - (DepVRate * NoYears), 2)

            objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET DepreciationValue = '" & TDepValue & "' WHERE Property_Dtl_ID = '" & dtEquip.Rows(i)("Property_Dtl_ID") & "'", CommandType.Text)
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
            ULife = dtMach.Rows(i)("useful_life")
            NoYears = (Year(Date.Today.ToString("MM/dd/yyyy")) - Year(AcquisitionYear))
            SalValue = dtMach.Rows(i)("SalvageValue")

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
            ULife = dtFurn.Rows(i)("useful_life")
            NoYears = (Year(Date.Today.ToString("MM/dd/yyyy")) - Year(AcquisitionYear))
            SalValue = dtFurn.Rows(i)("SalvageValue")

            '============================
            'DEPRECIATION RATE (AMOUNT) = (COST - SALVAGE) / USEFUL LIFE
            If ULife = 0 Then
                ULife = 1
            End If
            DepVRate = ((Cost - SalValue) / ULife)

            'TOTAL DEPRECIATION VALUE = COST - (DEP.VALUE * NO. YEARS)
            TDepValue = FormatNumber(Cost - (DepVRate * NoYears), 2)

            objDerived.GetRecords("UPDATE AMS.TbFurniture_Info SET DepreciationValue = '" & TDepValue & "' WHERE Property_Dtl_ID = '" & dtFurn.Rows(i)("Property_Dtl_ID") & "'", CommandType.Text)
        Next

    End Sub

    Public Function selectClassification()
        ' lblClass.text = ddClass.selecteditem.text
        ' lblClass1.text = ddClass.selecteditem.text
        Dim PListofGL As New DataTable
        PListofGL = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & ddClass.selecteditem.value & "'", CommandType.Text)
        Me.ddGlAccount.items.add("Select")
        Me.ddGlAccount.DataSource = CType(PListofGL, DataTable)
        Me.ddGlAccount.DataTextField = ("GA_Title")
        Me.ddGlAccount.DataValueField = ("GA_ID")
        Me.ddGlAccount.DataBind()
        Me.ddGlAccount.enabled = True
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
        dt = objDerived.GetDataTable("select item_particular_id,description From AMS.item_particular where GA_ID ='" & GLaccount & "'", CommandType.Text)
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
    Protected Sub ddSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        multiviewselected()
    End Sub
    Protected Sub ddCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectCatergory()

    End Sub
    Protected Sub txtEAcqDate_TextChanged(sender As Object, e As EventArgs)
        LoadEquipDepreciation()
    End Sub

    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "EQUIPMENTS"
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


End Class







