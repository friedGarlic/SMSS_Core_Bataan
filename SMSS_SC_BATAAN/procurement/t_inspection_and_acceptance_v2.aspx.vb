Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Web.UI.Page
Imports System.Web.UI
Imports System.Web.UI.Control

Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports OnBarcode
Imports System.Drawing

'Imports Barcode
Partial Class t_inspection_and_acceptance_v2
    Inherits System.Web.UI.Page
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal
    Private pojectdetail As New ProjectDtl
    Dim obj As New AccessRule
    Dim myview As DataView
    Dim total As Decimal = 0
    Dim ImageDocument As New ImageDocument
    Private supplies As New t_supplies_hdr
    Public dinNo As String

#Region "BaseDAL"
    Dim objhdr As New t_inspection_and_acceptance_hdr
    Dim objdtl As New t_inspection_and_acceptance_dtl
    Dim AIRHdr_ID As Integer
    Dim AIRDtl_ID As Integer
    Dim dtAirHdrid As New DataTable
    Dim dtAIRDtlID As New DataTable

    Dim objPropHdr As New t_property_hdr
    Dim objPropDtl As New t_property_dtl
    Dim Property_ID As Integer
    Dim PropertyDetai_ID As Integer
    Dim dtPropHdr As New DataTable
    Dim dtPropDtl As New DataTable

    Dim objLandDtl As New ConsolidatedPropertySaving.TBLand_Details
    Dim LandId As New Integer
    Dim dtLandDtl As New DataTable

    Dim objLandTech As New ConsolidatedPropertySaving.TB_Landdescription
    Dim TechDescriptionId As New Integer
    Dim dtLandTech As New DataTable

    Dim LandDocument As New ConsolidatedPropertySaving.TbLand_LandDocu
    Dim LandDocuId As New Integer
    Dim dtLandDocu As New DataTable

    Dim objLandOwner As New ConsolidatedPropertySaving.TbLand_OwnerHistory
    Dim OwnershipId As New Integer
    Dim dtLandOwner As New DataTable

    Dim objLandValuation As New ConsolidatedPropertySaving.TbLand_Valuation
    Dim ValuationId As New Integer
    Dim dtLandValuation As New DataTable

    Dim objLandImprovement As New ConsolidatedPropertySaving.TbLand_Improvements
    Dim ImprovementId As New Integer
    Dim dtLandImprovement As New DataTable

    Dim objLandPropHis As New ConsolidatedPropertySaving.TbLand_PropertyHistory
    Dim PropertyHistoryId As New Integer
    Dim dtLandPropHis As New DataTable

    Dim objBldgInfo As New ConsolidatedPropertySaving.TBBuilding_Details
    Dim BuildingId As New Integer
    Dim dtBldgInfo As New DataTable

    Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info
    Dim EquipInfoId As New Integer
    Dim dtEquipInfo As New DataTable

    Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details
    Dim EquipmentId As New Integer
    Dim dtEquipDtl As New DataTable

    Dim objFurnitureInfo As New ConsolidatedPropertySaving.TbFurniture_Info
    Dim FurnitureInfoId As New Integer
    Dim dtFurnitureInfo As New DataTable

    Dim objFurnitureDtl As New ConsolidatedPropertySaving.TbFurniture_Dtl
    Dim FurnitureId As New Integer
    Dim dtFurnitureDtl As New DataTable

    Dim objMachineInfo As New ConsolidatedPropertySaving.TbMachinery_Information
    Dim MachineryInfoId As New Integer
    Dim dtMachineInfo As New DataTable

    Dim objMachineDtl As New ConsolidatedPropertySaving.TbMachinery_Dtl
    Dim MachineryId As New Integer
    Dim dtMachineDtl As New DataTable

    Dim objMotorInfo As New ConsolidatedPropertySaving.TbMotor_Info
    Dim Motor_InfoId As New Integer
    Dim dtMotorInfo As New DataTable

    Dim objMotorDtl As New ConsolidatedPropertySaving.TbMotor_Dtl
    Dim MotorID As New Integer
    Dim dtMotorDtl As New DataTable

    Dim objAmbulanceInfo As New ConsolidatedPropertySaving.TbAmbulance_Info
    Dim Ambulance_InfoId As New Integer
    Dim dtAmbulanceInfo As New DataTable

    Dim objAmbulanceDtl As New ConsolidatedPropertySaving.TbAmbulance_Dtl
    Dim Ambulance_ID As New Integer
    Dim dtAmbulanceDtl As New DataTable

    Dim objPropSerial As New ConsolidatedPropertySaving.PropSerial
    Dim Item_Serial_ID As New Integer
    Dim dtPropSerial As New DataTable


    Dim objStock As New Supplies_Stock
    Dim StockID As New Integer
    Dim dtStock As New DataTable

    Dim objOfficeSup As New SupplieINFO
    Dim SuppliesId As New Integer
    Dim dtOSupply As New DataTable

    Dim objMedDtl As New ConsolidatedMedicineSaving.TBMedicine_DTl
    Dim MedicineDtl As New Integer
    Dim dtMedDtl As New DataTable

    Dim objMedInfo As New ConsolidatedMedicineSaving.TBMedicine_Info
    Dim MedicineId As New Integer
    Dim dtMedInfo As New DataTable

    Dim objBlood As New ConsolidatedMedicineSaving.TbBlood
    Dim Blood_ID As New Integer
    Dim dtBlood As New DataTable

    Dim objNonFood As New ConsolidatedMedicineSaving.TbNonFood
    Dim NonFood_ID As New Integer
    Dim dtNonFood As New DataTable

    Dim objFood As New ConsolidatedMedicineSaving.TbFood
    Dim Food_ID As New Integer
    Dim dtFood As New DataTable

    Dim objWater As New ConsolidatedMedicineSaving.TbWater
    Dim Water_ID As New Integer
    Dim dtWater As New DataTable

    Dim objAR As New t_Acknowledgement
    Dim Acknowledment_ID As New Integer
    Dim dtAR As New DataTable

    Dim objLedger As New t_PropertyLedger
    Dim Ledger_ID As New Integer
    Dim dtPropLedger As New DataTable

    Dim objStockLedger As New t_StockLedger
    Dim StockLedger_ID As New Integer
    Dim dtStockLedger As New DataTable
#End Region
#Region "property"
    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property
    Private Property pPurchase_Order() As DataTable
        Get
            Return CType(Session("pPurchase_Order"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order") = value
        End Set
    End Property
    Private Property pPurchase_Order_detail() As DataTable
        Get
            Return CType(Session("pPurchase_Order_detail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order_detail") = value
        End Set
    End Property
    Private Property pInspection_detail() As DataTable
        Get
            Return CType(Session("pInspection_detail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pInspection_detail") = value
        End Set
    End Property

    Private Property pGoodsPerSupplier(ByVal supplier_id As String) As DataTable
        Get
            Return CType(Session(supplier_id), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session(supplier_id) = value
        End Set
    End Property

    Private Property pTempSupplier() As DataTable
        Get
            Return CType(Session("pTempSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pTempSupplier") = value
        End Set
    End Property

    Private Property DefaultId() As Integer
        Get
            Return CType(Session("DefaultId"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("DefaultId") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        obj.GetAccessRight(Me.Session("@UserName"), Page)

        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            LoadSignatory()

            Drpsearch.SelectedValue = 4
            loadcat()

            Dim dtcat As New DataTable
            Session("Allotment_type") = 3

            dtcat = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & Session("Allotment_type") & "'", CommandType.Text)
            ddCategories.DataSource = CType(dtcat, DataTable)
            ddCategories.DataTextField = ("GA_Title")
            ddCategories.DataValueField = ("GA_ID")
            ddCategories.DataBind()
            ddCategories.Items.Insert(0, "Select")
         
        End If
        txtPOsearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchPO.ClientID & "')")
        txtInspectedDate.Text = Date.Today.ToString("MM/dd/yyyy")

        'pnlhistoryledger.Visible = False
    End Sub
    Protected Sub LoadPageLoad()
        Dim dtInspect As New DataTable
        dtInspect = objDerived.GetDataTable("Select * from [dbo].[View_InspectionAcceptance] order BY PO_Date desc", CommandType.Text)
        If dtInspect.Rows.Count < 8 Then
            dtInspect.Merge(createdatatable1(7 - dtInspect.Rows.Count))
        End If
        grdInspection.DataSource = dtInspect
        grdInspection.DataBind()
        grdInspection.SelectedIndex = 0

        MutiviewSelected()
        ddinspector1.Enabled = True
        ddinspector2.Enabled = True
        ddacceptance.Enabled = True
        LoadSignatory()

        If Me.Drpsearch.Text = 1 Then
            lblSearch.Text = "Search :"
            txtPOsearch.Enabled = False
            txtPOsearch.Text = " -- ALL -- "
        End If
    End Sub
    Protected Sub LoadAIRnum()
        lblairno.Text = supplies.GetValue("select [AMS].[func_GenerateAIR]( '" & Date.Today.ToString("MM/dd/yyyy") & "')", CommandType.Text)
    End Sub
    Protected Sub LoadPropertyNo()
        PropNo.Text = supplies.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & Date.Today.ToString("MM/dd/yyyy") & "', '" & objPropHdr.Property_code & "')", CommandType.Text)
    End Sub
    Protected Sub MutiviewSelected()
        LoadGA_IDSelection()
    End Sub
    Protected Sub grdInspection_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdInspection.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdInspection, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdInspection_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdInspection.SelectedIndexChanged
        Dim allot As Integer = objDerived.GetValue("Select AllotmentClass_ID from dbo.View_GenAccnt_BOS where GA_ID = '" & grdInspection.SelectedDataKey("GA_ID") & "'", CommandType.Text)
        Session("Allotment_type") = allot

        txtInvoiceDate.Text = Date.Today.ToString("MM/dd/yyyy")
        LoadGA_IDSelection()

        Session("POHdr_ID") = grdInspection.SelectedDataKey("POHdr_ID")
    End Sub
    Protected Sub LoadGA_IDSelection()

        txtInspectedDate.Enabled = True
        ddinspector1.Enabled = True
        ddinspector2.Enabled = True
        ddacceptance.Enabled = True

        btninspectedsave.Visible = True
        btnInspectUpdate.Visible = False

        btnacceptancesave.Visible = True
        btnAccptUpdate.Visible = False

        If txtInspectedDate.Text = "" Then
            txtInspectedDate.Text = Date.Today.ToString("MM/dd/yyyy")
        End If

        rbStatus.Enabled = False

        If Session("Allotment_type") = 3 Then '==== CO
            If grdInspection.SelectedDataKey(0) = 520 Or grdInspection.SelectedDataKey(0) = 521 Then
                ' LAND
                LoadClearText()
                LoadExpiryDetails2()
                Me.mvPurchasedetailedInfo.Visible = True
                Me.mvPurchasedetailedInfo.SetActiveView(Me.vwland)
                Me.mvAttachments.Visible = False
                Loadlandgoods()

            ElseIf grdInspection.SelectedDataKey(0) = 525 Then
                ' BUILDING
                LoadClearText()
                LoadExpiryDetails2()
                Me.mvPurchasedetailedInfo.Visible = True
                Me.mvPurchasedetailedInfo.SetActiveView(Me.vwBuilding)
                Me.mvAttachments.Visible = False
                LoadBuildingGoods()


            ElseIf grdInspection.SelectedDataKey(0) = 534 Then
                ' FURNITURE AND FIXTURES
                LoadClearText()
                LoadExpiryDetails2()
                Me.mvPurchasedetailedInfo.Visible = True
                Me.mvPurchasedetailedInfo.SetActiveView(Me.vwfurnitureandfixtures)
                Me.mvAttachments.Visible = True
                LoadFurnitureGoods()
                'LoadAttchDoc()

            ElseIf grdInspection.SelectedDataKey(0) = 537 Then
                ' MACHINERIES
                LoadClearText()
                LoadExpiryDetails2()
                Me.mvPurchasedetailedInfo.Visible = True
                Me.mvPurchasedetailedInfo.SetActiveView(Me.vwmachiniries)
                Me.mvAttachments.Visible = True
                LoadMachineryGoods()
                'LoadAttchDoc()

            ElseIf grdInspection.SelectedDataKey(0) = 549 Then ' tbleTranspo
                ' MOTORS
                LoadClearText()
                LoadExpiryDetails2()
                Me.mvPurchasedetailedInfo.Visible = True
                Me.mvPurchasedetailedInfo.SetActiveView(Me.vwMotorVehicle)
                tbleTranspo.Visible = True
                tblambulance.Visible = False

                Me.mvAttachments.Visible = True
                LoadMotorGoods()
                'LoadAttchDoc()

            ElseIf grdInspection.SelectedDataKey(0) = 580 Then
                'Ambulance
                LoadClearText()
                LoadExpiryDetails2()
                Me.mvPurchasedetailedInfo.Visible = True
                Me.mvPurchasedetailedInfo.SetActiveView(Me.vwMotorVehicle)
                tbleTranspo.Visible = False
                tblambulance.Visible = True
                Me.mvAttachments.Visible = True
                LoadMotorGoods()

            Else 'If grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Or grdInspection.SelectedDataKey(0) = 543 Or grdInspection.SelectedDataKey(0) = 540 Or grdInspection.SelectedDataKey(0) = 542 Or grdInspection.SelectedDataKey(0) = 544 Or grdInspection.SelectedDataKey(0) = 545 Or grdInspection.SelectedDataKey(0) = 548 Or grdInspection.SelectedDataKey(0) = 546 Or grdInspection.SelectedDataKey(0) = 94 Then
                ' EQUIPMENTS
                LoadClearText()
                LoadExpiryDetails2()
                Me.mvPurchasedetailedInfo.Visible = True
                Me.mvPurchasedetailedInfo.SetActiveView(Me.vwEquipment)
                Me.mvAttachments.Visible = True
                LoadEquipmentGoods()
                'LoadAttchDoc()
            End If



        ElseIf Session("Allotment_type") = 2 Then '===== MOOE
            If grdInspection.SelectedDataKey(0) = 788 Then
                ' OFFICE SUPPLIES
                LoadClearText()
                LoadExpiryDetails2()
                Me.mvPurchasedetailedInfo.Visible = True
                Me.mvPurchasedetailedInfo.SetActiveView(Me.vwofficesupplies)
                Me.mvAttachments.Visible = True
                LoadOfficeSupply()
                LoadAttchDoc()

            ElseIf grdInspection.SelectedDataKey(0) = 793 Or grdInspection.SelectedDataKey(0) = 792 Then
                ' MEDICINES
                LoadClearText()
                LoadExpiryDetails1()
                Me.mvPurchasedetailedInfo.Visible = True
                Me.mvPurchasedetailedInfo.SetActiveView(Me.vwMedicalSupplies)
                Me.mvAttachments.Visible = True
                LoadMedicineSupply()
                LoadAttchDoc()

            Else 'If grdInspection.SelectedDataKey(0) = 791 Or grdInspection.SelectedDataKey(0) = 799 Or grdInspection.SelectedDataKey(0) = 798 Or grdInspection.SelectedDataKey(0) = 927 Or grdInspection.SelectedDataKey(0) = 795 Or grdInspection.SelectedDataKey(0) = 790 Then
                'Supplies
                LoadClearText()
                LoadExpiryDetails1()
                Me.mvPurchasedetailedInfo.Visible = True
                Me.mvPurchasedetailedInfo.SetActiveView(Me.vwSupply)
                Me.mvAttachments.Visible = True
                ImgSupp.ImageUrl = "~/images/Blankimage.jpg"

                lblName.Text = "Brand Name:"
                LoadSupplies()
                LoadAttchDoc()
            End If
        End If


            If grdInspection.SelectedDataKey(0) = 0 Then
                ' NONE
                Try
                    LoadClearText()
                    LoadExpiryDetails2()
                    Me.mvPurchasedetailedInfo.Visible = True
                    Me.mvAttachments.Visible = True

                    'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No Item Selected")
                    Me.mvPurchasedetailedInfo.Visible = False
                    Me.mvAttachments.Visible = True
                Catch ex As Exception
                End Try
                btninspectedsave.Enabled = False
            'Else
            '    LoadNoDisplay()
            End If

            LoadAttchDoc()
    End Sub
    Protected Sub grdInspection_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If Me.Drpsearch.Text = 1 Then
            Dim GA As Integer
            GA = ddCategories.SelectedItem.Value
            'If ddCategories.SelectedItem.Text = "Equipments" Then
            '    GA = 535
            'ElseIf ddCategories.SelectedItem.Text = "Ambulance" Then
            '    GA = 580
            'ElseIf ddCategories.SelectedItem.Text = "Machineries" Then
            '    GA = 537
            'ElseIf ddCategories.SelectedItem.Text = "Land" Then
            '    GA = 520
            'ElseIf ddCategories.SelectedItem.Text = "Buildings" Then
            '    GA = 525
            'ElseIf ddCategories.SelectedItem.Text = "Furniture and Fixtures" Then
            '    GA = 534
            'ElseIf ddCategories.SelectedItem.Text = "Transportation" Then
            '    GA = 549
            'ElseIf ddCategories.SelectedItem.Text = "Drugs and Medicines" Then
            '    GA = 792
            'ElseIf ddCategories.SelectedItem.Text = "Medical Supplies" Then
            '    GA = 793
            'ElseIf ddCategories.SelectedItem.Text = "Food" Then
            '    ImgSupp.ImageUrl = "~/images/Food.jpg"
            '    GA = 791
            'ElseIf ddCategories.SelectedItem.Text = "Water" Then
            '    ImgSupp.ImageUrl = "~/images/water.jpg"
            '    GA = 799
            'ElseIf ddCategories.SelectedItem.Text = "Blood" Then
            '    ImgSupp.ImageUrl = "~/images/Blood.jpg"
            '    GA = 798
            'ElseIf ddCategories.SelectedItem.Text = "Non-Food Items" Then
            '    ImgSupp.ImageUrl = "~/images/Blankimage.jpg"
            '    GA = 927
            'ElseIf ddCategories.SelectedItem.Text = "Office Supplies" Then
            '    GA = 788

            'End If

            Dim dtInspect As New DataTable
            dtInspect = objDerived.GetDataTable("Exec [dbo].[sp_InspectionAcceptance_v2] '" & GA & "', '" & 0 & "'", CommandType.Text)
            If dtInspect.Rows.Count < 8 Then
                dtInspect.Merge(createdatatable1(7 - dtInspect.Rows.Count))
            End If
            grdInspection.PageIndex = e.NewPageIndex
            grdInspection.DataSource = dtInspect
            grdInspection.DataBind()
            grdInspection.SelectedIndex = 0
            LoadGA_IDSelection()

        ElseIf Me.Drpsearch.Text = 4 Then
            Dim dtInspect As New DataTable
            dtInspect = objDerived.GetDataTable("Exec [dbo].[sp_InspectionAcceptance_v2] '" & 0 & "', '" & 1 & "'", CommandType.Text)
            If dtInspect.Rows.Count < 8 Then
                dtInspect.Merge(createdatatable1(7 - dtInspect.Rows.Count))
            End If
            grdInspection.PageIndex = e.NewPageIndex
            grdInspection.DataSource = dtInspect
            grdInspection.DataBind()
            grdInspection.SelectedIndex = 0
            LoadGA_IDSelection()
        End If

    End Sub

    ' LAND INSPECTION AND ACCEPTANCE
    Protected Sub Loadlandgoods()
        ' DataGrid - Goods
        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            LoadAIRnum()

            Dim dtLand As New DataTable
            dtLand = objDerived.GetDataTable("Select * from [dbo].[View_InspectionAcceptance] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            txtsupplier.Text = IIf(IsDBNull(dtLand.Rows(0)("SuppName").ToString), 0, (dtLand.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dtLand.Rows(0)("PO_No").ToString), 0, (dtLand.Rows(0)("PO_No").ToString))
            txtdepartment.Text = IIf(IsDBNull(dtLand.Rows(0)("ReqDept").ToString), 0, (dtLand.Rows(0)("ReqDept").ToString))
            txtpoDate.Text = IIf(IsDBNull(dtLand.Rows(0)("PO_Date").ToString), 0, (dtLand.Rows(0)("PO_Date").ToString))

            Dim dtlandgoods As New DataTable
            dtlandgoods = objDerived.GetDataTable("Select * from dbo.View_InspectionLandBldg where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtlandgoods.Rows.Count < 4 Then
                dtlandgoods.Merge(createdatatableGoods(3 - dtlandgoods.Rows.Count))
            End If
            grdLandGoods.DataSource = dtlandgoods
            grdLandGoods.DataBind()
            grdLandGoods.SelectedIndex = 0
            LoadLandDetails()

        Else
            Dim dtLandAIR As New DataTable
            dtLandAIR = objDerived.GetDataTable("Select * from [dbo].[View_LandStatus] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtLandAIR.Rows.Count < 4 Then
                dtLandAIR.Merge(createdatatableGoods(3 - dtLandAIR.Rows.Count))
            End If
            grdLandGoods.DataSource = dtLandAIR
            grdLandGoods.DataBind()
            grdLandGoods.SelectedIndex = 0
            LoadLandDetails()

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from [dbo].[View_Inspected] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            txtsupplier.Text = IIf(IsDBNull(dt.Rows(0)("SuppName").ToString), 0, (dt.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dt.Rows(0)("PO_No").ToString), 0, (dt.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dt.Rows(0)("DatePurchased").ToString), 0, (dt.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = dtLandAIR.Rows(0).Item("RespCenter").ToString
            lblairno.Text = IIf(IsDBNull(dt.Rows(0)("AIR_No").ToString), 0, (dt.Rows(0)("AIR_No").ToString))
            txtInvoiceDate.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_date").ToString), 0, (dt.Rows(0)("Invoice_date").ToString))
            txtinvoiceNo.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_No").ToString), 0, (dt.Rows(0)("Invoice_No").ToString))
            txtremaks.Text = IIf(IsDBNull(dt.Rows(0)("remarks").ToString), 0, (dt.Rows(0)("remarks").ToString))
            txtInspectedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Inspect").ToString), 0, (dt.Rows(0)("Date_Inspect").ToString))
            ddinspector1.Text = IIf(IsDBNull(dt.Rows(0)("Signatory1").ToString), 0, (dt.Rows(0)("Signatory1").ToString))
            ddinspector2.Text = IIf(IsDBNull(dt.Rows(0)("Signatory2").ToString), 0, (dt.Rows(0)("Signatory2").ToString))
            txtAcceptedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Received").ToString), 0, (dt.Rows(0)("Date_Received").ToString))
            PropNo.Text = dtLandAIR.Rows(0)("PropertyNo").ToString

            If dt.Rows(0)("Signatory3").ToString = "" Then
                ddacceptance.DataSource = objDerived.GetDataTable("Select 'Select' as full_name, 1 as rowno union SELECT full_name  as full_name,empid " & _
                                                                  "from [dbo].[view_signatory1] where deptid = 7 and division_key = 86 order BY rowno", CommandType.Text)
                ddacceptance.DataBind()
                ddacceptance.DataTextField = ("full_name")
            Else
                ddacceptance.Text = IIf(IsDBNull(dt.Rows(0)("Signatory3").ToString), 0, (dt.Rows(0)("Signatory3").ToString))
            End If

            Session("AIRHdr_ID") = dt.Rows(0)("AIRHdr_ID").ToString
            Session("POHdr_ID") = grdInspection.SelectedDataKey("POHdr_ID")

            txtInspectedDate.Enabled = False
            ddinspector1.Enabled = False
            ddinspector2.Enabled = False

            If dtLandAIR.Rows(0)("Status_AIR").ToString = "Accepted" Then
                'isComplete
                If dt.Rows(0)(16) = True Then
                    rbStatus.SelectedValue = 1
                    btnacceptancepreview.Enabled = True
                    btninspectedsave.Enabled = False
                    btnInspectedPreview.Enabled = False
                    btnAccptUpdate.Enabled = False
                    btnacceptancesave.Enabled = False
                Else
                    rbStatus.SelectedValue = 0
                    btninspectedsave.Enabled = False
                    btnInspectedPreview.Enabled = True
                    btnacceptancesave.Enabled = True
                    btnacceptancepreview.Enabled = True
                End If

            Else
                btnacceptancesave.Enabled = True
                btninspectedsave.Enabled = True
                btnInspectedPreview.Enabled = True
                btnacceptancepreview.Enabled = False
            End If
        End If
        Loadtechndescription()
    End Sub
    Protected Sub LoadLandDetails()
        Dim dtLandDtls As New DataTable
        dtLandDtls = objDerived.GetDataTable("Select * from [dbo].[View_AIR_LandDtl] where PropertyDetai_ID = '" & grdLandGoods.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        If dtLandDtls.Rows.Count = 0 Then
            LoadPropertyNo()
            txtLandlgucode.Text = ""
            txtLandSectionno.Text = ""
            txtLandPIN.Text = ""
            txtLandTdn.Text = ""
            txtLanddistrictcode.Text = ""
            txtLandParcelno.Text = ""
            txtLandARP.Text = ""
            txtLandcitymunicipality1.Text = ""
            txtLandSeriesno.Text = ""
            txtLandrevyear.Text = ""
            txtLandbrgycode.Text = ""
            txtLandRPTIN.Text = ""
            txtLandDepriciationRate.Text = ""
            txtLandDepreciatedValue.Text = "0.00"
            txtLandlocationLot.Text = ""
            txtLandlocationblkno.Text = ""
            txtLandlocationstreetname.Text = ""
            txtLandlocationsubdivisionvillage.Text = ""
            txtLandlocationphaseno.Text = ""
            txtLandlocationpurok.Text = ""
            txtLandlocationsitio.Text = ""
            txtLandbarangay.Text = ""
            txtLandDistrict.Text = ""
            txtLandCitymunicipality.Text = ""
            txtLandprovince.Text = ""
            txtLandRegion.Text = ""
            txtLandzipcode.Text = ""
            txtLandClassification.Text = ""
            txtLandSubClass.Text = ""
            txtLandUse.Text = ""
            txtLandStatus1.Text = ""
            ddwnLandTaxable.SelectedValue = "Select"
            txtLandArea.Text = ""
            txtLandStatus2.Text = ""
            txtLandAssessedValue.Text = "0.00"
            txtLandAssessedDate.Text = ""
            txtLandAssessedAmount.Text = ""
            txtLandMarketValue.Text = "0.00"
            txtLandMarketDate.Text = ""
            txtLandMarketAmount.Text = ""
            txtLandUnitValue.Text = "0.00"
            txtLandUnitDate.Text = ""
            'dpLandAssessmentLvl.SelectedValue = ""

            LoadButtonDisable()
            btnInspectUpdate.Visible = False
            btninspectedsave.Visible = True

        Else
            txtLandlgucode.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("LguCode").ToString), 0, (dtLandDtls.Rows(0)("LguCode").ToString))
            txtLandSectionno.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("SectionNo").ToString), 0, (dtLandDtls.Rows(0)("SectionNo").ToString))
            txtLandPIN.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("PIN").ToString), 0, (dtLandDtls.Rows(0)("PIN").ToString))
            txtLandTdn.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("TDN").ToString), 0, (dtLandDtls.Rows(0)("TDN").ToString))
            txtLanddistrictcode.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("DistrictCode").ToString), 0, (dtLandDtls.Rows(0)("DistrictCode").ToString))
            txtLandParcelno.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("ParcelNo").ToString), 0, (dtLandDtls.Rows(0)("ParcelNo").ToString))
            txtLandARP.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("ARP").ToString), 0, (dtLandDtls.Rows(0)("ARP").ToString))
            txtLandcitymunicipality1.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("CityMunCode").ToString), 0, (dtLandDtls.Rows(0)("CityMunCode").ToString))
            txtLandSeriesno.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("SeriesNo").ToString), 0, (dtLandDtls.Rows(0)("SeriesNo").ToString))
            txtLandrevyear.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("RevYear").ToString), 0, (dtLandDtls.Rows(0)("RevYear").ToString))
            txtLandbrgycode.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("BarangayCode").ToString), 0, (dtLandDtls.Rows(0)("BarangayCode").ToString))
            txtLandRPTIN.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("RPTIN").ToString), 0, (dtLandDtls.Rows(0)("RPTIN").ToString))
            txtLandDepriciationRate.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("DepreciationRate").ToString), 0, (dtLandDtls.Rows(0)("DepreciationRate").ToString))
            txtLandDepreciatedValue.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("DepreciationValue").ToString), 0, (dtLandDtls.Rows(0)("DepreciationValue").ToString))
            txtLandlocationLot.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("LotNo").ToString), 0, (dtLandDtls.Rows(0)("LotNo").ToString))
            txtLandlocationblkno.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("BlkNo").ToString), 0, (dtLandDtls.Rows(0)("BlkNo").ToString))
            txtLandlocationstreetname.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("StreetName").ToString), 0, (dtLandDtls.Rows(0)("StreetName").ToString))
            txtLandlocationsubdivisionvillage.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("Subdivision").ToString), 0, (dtLandDtls.Rows(0)("Subdivision").ToString))
            txtLandlocationphaseno.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("PhaseNo").ToString), 0, (dtLandDtls.Rows(0)("PhaseNo").ToString))
            txtLandlocationpurok.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("Purok").ToString), 0, (dtLandDtls.Rows(0)("Purok").ToString))
            txtLandlocationsitio.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("Sitio").ToString), 0, (dtLandDtls.Rows(0)("Sitio").ToString))
            txtLandbarangay.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("Barangay").ToString), 0, (dtLandDtls.Rows(0)("Barangay").ToString))
            txtLandDistrict.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("District").ToString), 0, (dtLandDtls.Rows(0)("District").ToString))
            txtLandCitymunicipality.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("CityMunicipal").ToString), 0, (dtLandDtls.Rows(0)("CityMunicipal").ToString))
            txtLandprovince.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("Province").ToString), 0, (dtLandDtls.Rows(0)("Province").ToString))
            txtLandRegion.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("Region").ToString), 0, (dtLandDtls.Rows(0)("Region").ToString))
            txtLandzipcode.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("ZipCode").ToString), 0, (dtLandDtls.Rows(0)("ZipCode").ToString))
            txtLandClassification.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("Classification").ToString), 0, (dtLandDtls.Rows(0)("Classification").ToString))
            txtLandSubClass.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("SubClass").ToString), 0, (dtLandDtls.Rows(0)("SubClass").ToString))
            txtLandUse.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("LandUse").ToString), 0, (dtLandDtls.Rows(0)("LandUse").ToString))
            txtLandStatus1.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("Status_1").ToString), 0, (dtLandDtls.Rows(0)("Status_1").ToString))
            txtLandArea.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("Area").ToString), 0, (dtLandDtls.Rows(0)("Area").ToString))
            txtLandStatus2.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("Status_2").ToString), 0, (dtLandDtls.Rows(0)("Status_2").ToString))
            txtLandAssessedValue.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("AssessedValue").ToString), 0, (dtLandDtls.Rows(0)("AssessedValue").ToString))
            txtLandAssessedDate.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("AssessedDate").ToString), 0, (dtLandDtls.Rows(0)("AssessedDate").ToString))
            txtLandAssessedAmount.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("AVAmountWords").ToString), 0, (dtLandDtls.Rows(0)("AVAmountWords").ToString))
            txtLandMarketValue.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("MarketValue").ToString), 0, (dtLandDtls.Rows(0)("MarketValue").ToString))
            txtLandMarketDate.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("MarketDate").ToString), 0, (dtLandDtls.Rows(0)("MarketDate").ToString))
            txtLandMarketAmount.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("MVAmountWords").ToString), 0, (dtLandDtls.Rows(0)("MVAmountWords").ToString))
            txtLandUnitValue.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("UnitValue").ToString), 0, (dtLandDtls.Rows(0)("UnitValue").ToString))
            txtLandUnitDate.Text = IIf(IsDBNull(dtLandDtls.Rows(0)("UnitDate").ToString), 0, (dtLandDtls.Rows(0)("UnitDate").ToString))
            dpLandAssessmentLvl.SelectedValue = IIf(IsDBNull(dtLandDtls.Rows(0)("AssessmentLevel").ToString), 0, (dtLandDtls.Rows(0)("AssessmentLevel").ToString))
            PropNo.Text = objDerived.GetValue("Select PropertyNo from AMS.Property_Dtl where PropertyNo = '" & grdLandGoods.SelectedDataKey("PropertyNo") & "'", CommandType.Text)

            If dtLandDtls.Rows(0)("Taxable").ToString = "" Then
                ddwnLandTaxable.SelectedValue = "Select"
            Else
                ddwnLandTaxable.SelectedValue = dtLandDtls.Rows(0)("Taxable").ToString
            End If

            If dtLandDtls.Rows(0)(17) = True Then
                rbStatus.SelectedValue = 1
                LoadButtonEnable()
                btnacceptancepreview.Enabled = True
                btnacknowledgementpost.Enabled = True
            Else
                rbStatus.SelectedValue = 0
                LoadButtonEnable()
                btnacceptancepreview.Enabled = False
                btnacknowledgementpost.Enabled = False
            End If


            If dtLandDtls.Rows(0)("Status_AIR").ToString = "Inspected" Then
                btnInspectedPreview.Enabled = True
                btnacceptancesave.Visible = True
                btnAccptUpdate.Visible = False
                btnacceptancepreview.Enabled = False
                txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")
                btnInspectUpdate.Visible = True
                btninspectedsave.Visible = False
                btnInspectUpdate.Enabled = True

            ElseIf dtLandDtls.Rows(0)("Status_AIR").ToString = "Accepted" Then
                ddacceptance.Enabled = False
                btninspectedsave.Enabled = False
                btnInspectUpdate.Enabled = False
                btnInspectedPreview.Enabled = False
                btnacceptancesave.Visible = False
                btnAccptUpdate.Visible = True
                btnacceptancepreview.Enabled = True

                LoadIFCompleted()
            End If

        End If
    End Sub
    Protected Sub grdLandGoods_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdLandGoods, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdLandGoods_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadLandDetails()
        Loadtechndescription()
    End Sub
    ' Land TABS
    Protected Sub Loadtechndescription()
        btntechnicaldescription.CssClass = "Clicked"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Initial"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Initial"

        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwTechnicalTechnicaldescription)

        Dim dtLandTechD As New DataTable
        dtLandTechD = objDerived.GetDataTable("Select * from [dbo].[View_AIR_LandTech] where PODtl_ID = '" & grdLandGoods.SelectedDataKey("PODtl_ID") & "'", CommandType.Text)
        If dtLandTechD.Rows.Count = 0 Then
            txttechnicaloctno.Text = ""
            txttechnicaltctno.Text = ""
            txttechnicalDate.Text = ""
            txttechnicaldateregistered.Text = ""
            txttechnicalcadastralno.Text = ""
            txtLandBBM.Text = ""
            txttechnicalNorth.Text = ""
            txttechnicalEast.Text = ""
            txttechnicalSouth.Text = ""
            txttechnicalwest.Text = ""

        Else
            txttechnicaloctno.Text = IIf(IsDBNull(dtLandTechD.Rows(0)("OctNo").ToString), 0, (dtLandTechD.Rows(0)("OctNo").ToString))
            txttechnicaltctno.Text = IIf(IsDBNull(dtLandTechD.Rows(0)("TctNo").ToString), 0, (dtLandTechD.Rows(0)("TctNo").ToString))
            txttechnicalDate.Text = IIf(IsDBNull(dtLandTechD.Rows(0)("iDate").ToString), 0, (dtLandTechD.Rows(0)("iDate").ToString))
            txttechnicaldateregistered.Text = IIf(IsDBNull(dtLandTechD.Rows(0)("DateRegistered").ToString), 0, (dtLandTechD.Rows(0)("DateRegistered").ToString))
            txttechnicalcadastralno.Text = IIf(IsDBNull(dtLandTechD.Rows(0)("CadastralNo").ToString), 0, (dtLandTechD.Rows(0)("CadastralNo").ToString))
            txtLandBBM.Text = IIf(IsDBNull(dtLandTechD.Rows(0)("BrgyBounderyMonu").ToString), 0, (dtLandTechD.Rows(0)("BrgyBounderyMonu").ToString))
            txttechnicalNorth.Text = IIf(IsDBNull(dtLandTechD.Rows(0)("North").ToString), 0, (dtLandTechD.Rows(0)("North").ToString))
            txttechnicalEast.Text = IIf(IsDBNull(dtLandTechD.Rows(0)("East").ToString), 0, (dtLandTechD.Rows(0)("East").ToString))
            txttechnicalSouth.Text = IIf(IsDBNull(dtLandTechD.Rows(0)("South").ToString), 0, (dtLandTechD.Rows(0)("South").ToString))
            txttechnicalwest.Text = IIf(IsDBNull(dtLandTechD.Rows(0)("West").ToString), 0, (dtLandTechD.Rows(0)("West").ToString))

        End If
        Dim dttechtable As New DataTable
        dttechtable = objDerived.GetDataTable("Select * from [dbo].[View_AIR_LandTech] where Item_ID = '" & grdLandGoods.SelectedDataKey(0) & "'", CommandType.Text)
        If dttechtable.Rows.Count < 4 Then
            dttechtable.Merge(createdatatable15(3 - dttechtable.Rows.Count))
        End If
        grdLandTechDesc.DataSource = dttechtable
        grdLandTechDesc.DataBind()
        'CType(grdLandTechDesc.Rows(0).FindControl("txtStartingPT"), TextBox).Text
        'CType(grdLandTechDesc.Rows(1).FindControl("txtEndingPT"), TextBox).Text = ""
        'CType(grdLandTechDesc.Rows(2).FindControl("txtNS"), TextBox).Text = ""
        'CType(grdLandTechDesc.Rows(3).FindControl("txtns1"), TextBox).Text = ""
        'CType(grdLandTechDesc.Rows(4).FindControl("txtns2"), TextBox).Text = ""
        'CType(grdLandTechDesc.Rows(5).FindControl("txtwe"), TextBox).Text = ""
        'CType(grdLandTechDesc.Rows(6).FindControl("txtm"), TextBox).Text = ""
    End Sub
    Protected Sub btntechnicaldescription_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btntechnicaldescription.Click
        Loadtechndescription()
    End Sub
    Protected Sub btnLandDocument_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLandDocument.Click
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
        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwLandDocument)

        Dim LandDocument As New DataTable
        LandDocument = objDerived.GetDataTable("Select * from AMS.TbLand_LandDocu where IdentityNo = '" & grdLandGoods.SelectedDataKey("PODtl_ID") & "' and TableName='AIR_LandDocu'", CommandType.Text)
        If LandDocument.Rows.Count < 4 Then
            LandDocument.Merge(createdatatable12(4 - LandDocument.Rows.Count))
        End If
        grdLandDocu.DataSource = LandDocument
        grdLandDocu.DataBind()
        grdLandDocu.SelectedIndex = 0

        LoadLandDocu_ChangeIndex()
    End Sub
    Protected Sub btnHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Clicked"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Initial"

        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwHistoryofOwnership)
        grdOwnership.Visible = True
        grdAddOwnership.Visible = False

        grdOwnership.DataSource = createdatatable5(4)
        grdOwnership.DataBind()

        btnAddOwner.Visible = True
        btnSaveOwner.Visible = False
        btnCancelOwner.Visible = False
    End Sub
    Protected Sub btnAddOwner_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwHistoryofOwnership)
        grdOwnership.Visible = False
        grdAddOwnership.Visible = True

        grdAddOwnership.DataSource = createdatatable5(4)
        grdAddOwnership.DataBind()

        btnAddOwner.Visible = False
        btnSaveOwner.Visible = True
        btnCancelOwner.Visible = True
    End Sub
    Protected Sub btnSaveOwner_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub btnCancelOwner_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwHistoryofOwnership)
        grdOwnership.Visible = True
        grdAddOwnership.Visible = False

        grdOwnership.DataSource = createdatatable5(4)
        grdOwnership.DataBind()

        btnAddOwner.Visible = True
        btnSaveOwner.Visible = False
        btnCancelOwner.Visible = False
    End Sub
    Protected Sub grdOwnership_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub grdOwnership_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

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
        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwLandValutaion)
        Dim dtLandValuation As New DataTable
        dtLandValuation = objDerived.GetDataTable("Select * from [dbo].[View_LandValuation] where PODtl_ID = '" & grdLandGoods.SelectedDataKey("PODtl_ID") & "'", CommandType.Text)
        If dtLandValuation.Rows.Count = 0 Then
            txtLandValClass.Text = ""
            txtLandValSubClass.Text = ""
            txtLandValArea.Text = ""
            txtLandValUnit.Text = ""
            txtLandValUnitValue.Text = ""
            txtLandValBMV.Text = ""
            txtLandValTaxable.Text = ""
            txtLandValAdjustment.Text = ""
            txtLandValAMV.Text = ""
            txtLandValStrip.Text = ""
            txtLandValAUV.Text = ""
        Else
            txtLandValClass.Text = IIf(IsDBNull(dtLandValuation.Rows(0)("Classification").ToString), 0, (dtLandValuation.Rows(0)("Classification").ToString))
            txtLandValSubClass.Text = IIf(IsDBNull(dtLandValuation.Rows(0)("SubClassification").ToString), 0, (dtLandValuation.Rows(0)("SubClassification").ToString))
            txtLandValArea.Text = IIf(IsDBNull(dtLandValuation.Rows(0)("Area").ToString), 0, (dtLandValuation.Rows(0)("Area").ToString))
            txtLandValUnit.Text = IIf(IsDBNull(dtLandValuation.Rows(0)("Unit").ToString), 0, (dtLandValuation.Rows(0)("Unit").ToString))
            txtLandValUnitValue.Text = IIf(IsDBNull(dtLandValuation.Rows(0)("UnitValue").ToString), 0, (dtLandValuation.Rows(0)("UnitValue").ToString))
            txtLandValBMV.Text = IIf(IsDBNull(dtLandValuation.Rows(0)("BaseMarketValue").ToString), 0, (dtLandValuation.Rows(0)("BaseMarketValue").ToString))
            txtLandValTaxable.Text = IIf(IsDBNull(dtLandValuation.Rows(0)("Taxable").ToString), 0, (dtLandValuation.Rows(0)("Taxable").ToString))
            txtLandValAdjustment.Text = IIf(IsDBNull(dtLandValuation.Rows(0)("Adjustments").ToString), 0, (dtLandValuation.Rows(0)("Adjustments").ToString))
            txtLandValAMV.Text = IIf(IsDBNull(dtLandValuation.Rows(0)("AdjustedMarketValue").ToString), 0, (dtLandValuation.Rows(0)("AdjustedMarketValue").ToString))
            txtLandValStrip.Text = IIf(IsDBNull(dtLandValuation.Rows(0)("Strip").ToString), 0, (dtLandValuation.Rows(0)("Strip").ToString))
            txtLandValAUV.Text = IIf(IsDBNull(dtLandValuation.Rows(0)("AdjUnitValue").ToString), 0, (dtLandValuation.Rows(0)("AdjUnitValue").ToString))
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

        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwApprovalInformation)
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
        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwImprovements)
        'grdLandInprovements.DataSource = createdatatable14(9)
        'grdLandInprovements.DataBind()
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
        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwmemoranda)
    End Sub
    Protected Sub bntDocumentAttach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntDocumentAttach.Click
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
        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwAttachedDocument)
        Dim AttachDocument As New DataTable
        AttachDocument = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = " & grdLandGoods.SelectedDataKey("PODtl_ID") & "and TableName='AIR_LandAttchDocu'", CommandType.Text)
        If AttachDocument.Rows.Count < 4 Then
            AttachDocument.Merge(createdatatableAttch(4 - AttachDocument.Rows.Count))
        End If
        grdLandAttachdoc.DataSource = AttachDocument
        grdLandAttachdoc.DataBind()
        grdLandAttachdoc.SelectedIndex = 0

        LoadLandAttch_ChangeIndex()
    End Sub
    Protected Sub grdownership_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdownership, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdownership_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    ' BUILDING INSPECTION AND ACCEPTANCE 
    Protected Sub LoadBuildingGoods()
        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            LoadAIRnum()

            Dim dtBldg As New DataTable
            dtBldg = objDerived.GetDataTable("Select * from [dbo].[View_InspectionAcceptance] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            txtsupplier.Text = IIf(IsDBNull(dtBldg.Rows(0)("SuppName").ToString), 0, (dtBldg.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dtBldg.Rows(0)("PO_No").ToString), 0, (dtBldg.Rows(0)("PO_No").ToString))
            txtdepartment.Text = IIf(IsDBNull(dtBldg.Rows(0)("ReqDept").ToString), 0, (dtBldg.Rows(0)("ReqDept").ToString))
            txtpoDate.Text = IIf(IsDBNull(dtBldg.Rows(0)("PO_Date").ToString), 0, (dtBldg.Rows(0)("PO_Date").ToString))

            Dim dtBuilding As New DataTable
            dtBuilding = objDerived.GetDataTable("Select * from dbo.View_InspectionLandBldg where  POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtBuilding.Rows.Count < 4 Then
                dtBuilding.Merge(createdatatableGoods(3 - dtBuilding.Rows.Count))
            End If
            grdBuildingGoods.DataSource = dtBuilding
            grdBuildingGoods.DataBind()
            grdBuildingGoods.SelectedIndex = 0
            LoadBldgInformation()

        Else
            Dim dtBldgAIR As New DataTable
            dtBldgAIR = objDerived.GetDataTable("Select * from [dbo].[View_BuildingStatus] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtBldgAIR.Rows.Count < 4 Then
                dtBldgAIR.Merge(createdatatableGoods(3 - dtBldgAIR.Rows.Count))
            End If
            grdBuildingGoods.DataSource = dtBldgAIR
            grdBuildingGoods.DataBind()
            grdBuildingGoods.SelectedIndex = 0
            LoadBldgInformation()

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from [dbo].[View_Inspected] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            txtsupplier.Text = IIf(IsDBNull(dt.Rows(0)("SuppName").ToString), 0, (dt.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dt.Rows(0)("PO_No").ToString), 0, (dt.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dt.Rows(0)("DatePurchased").ToString), 0, (dt.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = IIf(IsDBNull(dtBldgAIR.Rows(0)("RespCenter").ToString), 0, (dtBldgAIR.Rows(0)("RespCenter").ToString)) 'dtBuilding.Rows(0).Item("RespCenter").ToString
            lblairno.Text = IIf(IsDBNull(dt.Rows(0)("AIR_No").ToString), 0, (dt.Rows(0)("AIR_No").ToString))
            txtInvoiceDate.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_date").ToString), 0, (dt.Rows(0)("Invoice_date").ToString))
            txtinvoiceNo.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_No").ToString), 0, (dt.Rows(0)("Invoice_No").ToString))
            txtremaks.Text = IIf(IsDBNull(dt.Rows(0)("remarks").ToString), 0, (dt.Rows(0)("remarks").ToString))
            txtInspectedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Inspect").ToString), 0, (dt.Rows(0)("Date_Inspect").ToString))
            ddinspector1.Text = IIf(IsDBNull(dt.Rows(0)("Signatory1").ToString), 0, (dt.Rows(0)("Signatory1").ToString))
            ddinspector2.Text = IIf(IsDBNull(dt.Rows(0)("Signatory2").ToString), 0, (dt.Rows(0)("Signatory2").ToString))
            txtAcceptedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Received").ToString), 0, (dt.Rows(0)("Date_Received").ToString))
            PropNo.Text = dtBldgAIR.Rows(0)("PropertyNo").ToString

            If dt.Rows(0)("Signatory3").ToString = "" Then
                ddacceptance.DataSource = objDerived.GetDataTable("Select 'Select' as full_name, 1 as rowno union SELECT full_name  as full_name,empid " & _
                                                                  "from [dbo].[view_signatory1] where deptid = 7 and division_key = 86 order BY rowno", CommandType.Text)
                ddacceptance.DataBind()
                ddacceptance.DataTextField = ("full_name")
            Else
                ddacceptance.Text = IIf(IsDBNull(dt.Rows(0)("Signatory3").ToString), 0, (dt.Rows(0)("Signatory3").ToString))
            End If

            Session("AIRHdr_ID") = dt.Rows(0)("AIRHdr_ID").ToString
            Session("POHdr_ID") = grdInspection.SelectedDataKey("POHdr_ID")

            txtInspectedDate.Enabled = False
            ddinspector1.Enabled = False
            ddinspector2.Enabled = False

            If dtBldgAIR.Rows(0)("Status_AIR").ToString = "Accepted" Then
                'isComplete
                If dt.Rows(0)(16) = True Then
                    rbStatus.SelectedValue = 1
                    btnacceptancepreview.Enabled = True
                    btninspectedsave.Enabled = False
                    btnInspectedPreview.Enabled = False
                    btnAccptUpdate.Enabled = False
                    btnacceptancesave.Enabled = False
                Else
                    rbStatus.SelectedValue = 0
                    btninspectedsave.Enabled = False
                    btnInspectedPreview.Enabled = True
                    btnacceptancesave.Enabled = True
                    btnacceptancepreview.Enabled = True
                End If

            Else
                btnacceptancesave.Enabled = True
                btninspectedsave.Enabled = True
                btnInspectedPreview.Enabled = True
                btnacceptancepreview.Enabled = False
            End If
        End If
        LoadbuildingConstruction()
    End Sub
    Protected Sub LoadBldgInformation()
        Dim dtBldgInfo As New DataTable
        dtBldgInfo = objDerived.GetDataTable("Select * from [dbo].[View_AIR_BldgInfo] where PropertyDetai_ID = '" & grdBuildingGoods.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        If dtBldgInfo.Rows.Count = 0 Then
            txtbuildingcontolno.Text = ""
            txtbuildingcode.Text = ""
            txtbuildingname.Text = ""
            txtbuildingaddress.Text = ""
            txtbuildingpostalcode.Text = ""
            txtbuildingdepreciationrate.Text = ""
            txtbuildinguse.Text = ""
            txtbuildingoccupancy.Text = ""
            txtbuildingnumberoffloors.Text = ""
            txtbuildingavgareaperfloor.Text = ""
            txtbuildingcostperarea.Text = ""
            txtbuildingdepreciationvalue.Text = ""
            LoadButtonDisable()

            btnInspectUpdate.Visible = False
            btninspectedsave.Visible = True
        Else
            txtbuildingcontolno.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("BuildingControlNo").ToString), 0, (dtBldgInfo.Rows(0)("BuildingControlNo").ToString))
            txtbuildingcode.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("BuildingCode").ToString), 0, (dtBldgInfo.Rows(0)("BuildingCode").ToString))
            txtbuildingname.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("BuildingName").ToString), 0, (dtBldgInfo.Rows(0)("BuildingName").ToString))
            txtbuildingaddress.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("Address").ToString), 0, (dtBldgInfo.Rows(0)("Address").ToString))
            txtbuildingpostalcode.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("PostalCode").ToString), 0, (dtBldgInfo.Rows(0)("PostalCode").ToString))
            txtbuildingdepreciationrate.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("BuildingDepreciationRate").ToString), 0, (dtBldgInfo.Rows(0)("BuildingDepreciationRate").ToString))
            txtbuildinguse.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("BuildingUse").ToString), 0, (dtBldgInfo.Rows(0)("BuildingUse").ToString))
            txtbuildingoccupancy.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("BuildingOccupancy").ToString), 0, (dtBldgInfo.Rows(0)("BuildingOccupancy").ToString))
            txtbuildingnumberoffloors.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("NumberFloors").ToString), 0, (dtBldgInfo.Rows(0)("NumberFloors").ToString))
            txtbuildingavgareaperfloor.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("AvgAreaFloor").ToString), 0, (dtBldgInfo.Rows(0)("AvgAreaFloor").ToString))
            txtbuildingcostperarea.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("CostPerArea").ToString), 0, (dtBldgInfo.Rows(0)("CostPerArea").ToString))
            txtbuildingdepreciationvalue.Text = IIf(IsDBNull(dtBldgInfo.Rows(0)("BuildingDepreciationValue").ToString), 0, (dtBldgInfo.Rows(0)("BuildingDepreciationValue").ToString))
            PropNo.Text = grdBuildingGoods.SelectedDataKey("PropertyNo")
            'If dtBldgInfo.Rows(0)(16) = True Then
            '    rbStatus.SelectedValue = 1
            '    LoadButtonEnable()
            '    btnacceptancepreview.Enabled = True
            '    btnacknowledgementpost.Enabled = True
            'Else
            '    rbStatus.SelectedValue = 0
            '    LoadButtonEnable()
            '    btnacceptancepreview.Enabled = False
            '    btnacknowledgementpost.Enabled = False
            'End If
            'btnInspectUpdate.Visible = True
            'btninspectedsave.Visible = False

            If dtBldgInfo.Rows(0)(16) = True Then
                rbStatus.SelectedValue = 1
                LoadButtonEnable()
                btnacceptancepreview.Enabled = True
                btnacknowledgementpost.Enabled = True
            Else
                rbStatus.SelectedValue = 0
                LoadButtonEnable()
                btnacceptancepreview.Enabled = False
                btnacknowledgementpost.Enabled = False
            End If


            If dtBldgInfo.Rows(0)("Status_AIR").ToString = "Inspected" Then
                btnInspectedPreview.Enabled = True
                btnacceptancesave.Visible = True
                btnAccptUpdate.Visible = False
                btnacceptancepreview.Enabled = False
                txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")
                btnInspectUpdate.Visible = True
                btninspectedsave.Visible = False
                btnInspectUpdate.Enabled = True

            ElseIf dtBldgInfo.Rows(0)("Status_AIR").ToString = "Accepted" Then
                ddacceptance.Enabled = False
                btninspectedsave.Enabled = False
                btnInspectUpdate.Enabled = False
                btnInspectedPreview.Enabled = False
                btnacceptancesave.Visible = False
                btnAccptUpdate.Visible = True
                btnacceptancepreview.Enabled = True

                LoadIFCompleted()
            End If
        End If
    End Sub
    Protected Sub LoadBuildingDetailsSaving()
        dtBldgInfo = objBldgInfo.GetDataTable("select BuildingId from AMS.TbBuilding_Dtl where Property_Dtl_ID = '" & PropertyDetai_ID & "' ", CommandType.Text)
        With objBldgInfo
            '.BuildingId = BuildingId
            .Property_Dtl_ID = PropertyDetai_ID
            .BuildingControlNo = txtbuildingcontolno.Text
            .BuildingCode = txtbuildingcode.Text
            .BuildingName = txtbuildingname.Text
            .Address = txtbuildingaddress.Text
            .PostalCode = txtbuildingpostalcode.Text
            If txtbuildingdepreciationrate.Text = "" Then
                .BuildingDepreciationRate = "0.00"
            Else
                .BuildingDepreciationRate = txtbuildingdepreciationrate.Text
            End If
            .BuildingUse = txtbuildinguse.Text
            .BuildingOccupancy = txtbuildingoccupancy.Text
            .NumberFloors = txtbuildingnumberoffloors.Text
            .AvgAreaFloor = txtbuildingavgareaperfloor.Text
            .CostPerArea = txtbuildingcostperarea.Text
            '.Status_AIR = ""

            If txtbuildingdepreciationvalue.Text = "" Then
                .BuildingDepreciationValue = "0.00"
            Else
                .BuildingDepreciationValue = txtbuildingdepreciationvalue.Text
            End If

            '.DateTaken = ""
            '.UploadedBy = ""
            '.MarketValue = ""
        End With

        If dtBldgInfo.Rows.Count = 0 Then
            objBldgInfo.BuildingId = 0
            objBldgInfo.save()
            BuildingId = objBldgInfo.GetValue("Select max(BuildingId) from AMS.TbBuilding_Dtl ", CommandType.Text)
        Else
            BuildingId = objBldgInfo.GetValue("select BuildingId from AMS.TbBuilding_Dtl where Property_Dtl_ID like '" & PropertyDetai_ID & "' ", CommandType.Text)
            objBldgInfo.BuildingId = BuildingId
            objBldgInfo.update()
        End If

    End Sub
    Protected Sub grdBuildingGoods_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadBldgInformation()
    End Sub
    Protected Sub grdBuildingGoods_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdBuildingGoods, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    ' Building TABS
    Protected Sub btnConstructionDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConstructionDetails.Click
        LoadbuildingConstruction()
    End Sub
    Protected Sub btnBuildingInformation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuildingInformation.Click
        LoadBuildingInfo()
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

        'buttons hover'
        Me.mvBuilding.SetActiveView(Me.vwOwnersInformation)
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

        'buttons hover'
        Me.mvBuilding.SetActiveView(Me.vwOccupants)
        grdlistofOccupants.DataSource = createdatatable7(5)
        grdlistofOccupants.DataBind()
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

        'buttons hover'
        Me.mvBuilding.SetActiveView(Me.vwpermitapplicationhistory)
        grdpermitapplicationhistory.DataSource = createdatatable8(4)
        grdpermitapplicationhistory.DataBind()
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

        'buttons hover'
        Me.mvBuilding.SetActiveView(Me.vwInspectionHistory)
        grdInspectionHistory.DataSource = createdatatable9(4)
        grdInspectionHistory.DataBind()
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

        'buttons hover'
        grdPaymentHistory.DataSource = createdatatable10(4)
        grdPaymentHistory.DataBind()
        Me.mvBuilding.SetActiveView(Me.vwPaymentHistory)
    End Sub
    Protected Sub btnbuildingDocumentAttach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuildingDocumentAttach.Click
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
        Me.mvBuilding.SetActiveView(Me.vwbuildingdocumentdetails)
    End Sub
    Protected Sub LoadbuildingConstruction()
        btnConstructionDetails.CssClass = "Clicked"
        btnBuildingInformation.CssClass = "Initial"
        btnOwnersInformation.CssClass = "Initial"
        btnOccupants.CssClass = "Initial"
        btnPermitApplicationHistory.CssClass = "Initial"
        btnInspectionHistory.CssClass = "Initial"
        btnPaymentHistory.CssClass = "Initial"
        btnbuildingDocumentAttach.CssClass = "Initial"

        Me.mvBuilding.SetActiveView(Me.vwConstructionDetails)
        grdlistofProfessional.DataSource = createdatatable6(4)
        grdlistofProfessional.DataBind()
    End Sub
    Protected Sub LoadBuildingInfo()
        'buttons hover'
        btnConstructionDetails.CssClass = "Initial"
        btnBuildingInformation.CssClass = "Clicked"
        btnOwnersInformation.CssClass = "Initial"
        btnOccupants.CssClass = "Initial"
        btnPermitApplicationHistory.CssClass = "Initial"
        btnInspectionHistory.CssClass = "Initial"
        btnPaymentHistory.CssClass = "Initial"
        btnbuildingDocumentAttach.CssClass = "Initial"

        'buttons hover'
        Me.mvBuilding.SetActiveView(Me.vwbuildinginformation)
    End Sub

    ' EQUIPMENT INSPECTION AND ACCEPTANCE 
    Protected Sub LoadEquipmentGoods()
        Dim dtEquip As New DataTable
        dtEquip = objDerived.GetDataTable("Select * from AMS.TbPropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtEquip.Rows.Count = 0 Then
            LoadEquipment()
        Else
            LoadEquipSerial()
        End If
    End Sub
    Protected Sub LoadEquipment()
        grdEuipment.Visible = True
        grdEuipment_Serial.Visible = False
        Me.mvAttachments.Visible = False

        LoadAIRnum()

        Dim dtEquipment As New DataTable
        dtEquipment = objDerived.GetDataTable("exec dbo.load_goods_for_serial  '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtEquipment.Rows.Count < 8 Then
            dtEquipment.Merge(createdatatableGoods(7 - dtEquipment.Rows.Count))
        End If
        grdEuipment.DataSource = dtEquipment
        grdEuipment.DataBind()

        grdEuipment.Columns(9).Visible = False

        txtsupplier.Text = IIf(IsDBNull(dtEquipment.Rows(0)("SuppName").ToString), 0, (dtEquipment.Rows(0)("SuppName").ToString))
        txtPOnum.Text = IIf(IsDBNull(dtEquipment.Rows(0)("PO_No").ToString), 0, (dtEquipment.Rows(0)("PO_No").ToString))
        txtpoDate.Text = IIf(IsDBNull(dtEquipment.Rows(0)("DatePurchased").ToString), 0, (dtEquipment.Rows(0)("DatePurchased").ToString))
        txtdepartment.Text = dtEquipment.Rows(0).Item("RespCenter").ToString
        rbStatus.SelectedValue = 0

        LoadClearEquipText()
        LoadDisableEquipText()

        btninspectedsave.Enabled = False
        btnAccptUpdate.Visible = False
        LoadButtonDisable()

        btnSaveSerial.Visible = True
        btnUpdateEquip.Visible = False
        btnEditEquip.Visible = False
    End Sub
    Protected Sub LoadEquipSerial()
        grdEuipment.Visible = False
        grdEuipment_Serial.Visible = True
        Me.mvAttachments.Visible = True
        grdEuipment_Serial.Columns(9).Visible = True

        Dim dtEquipSerial As New DataTable
        dtEquipSerial = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtEquipSerial.Rows.Count = 0 Then
            grdEuipment_Serial.DataSource = createdatatableGoods2(8)
            grdEuipment_Serial.DataBind()
            Session("eq") = 1
        Else
            If dtEquipSerial.Rows.Count < 8 Then
                dtEquipSerial.Merge(createdatatableGoods2(7 - dtEquipSerial.Rows.Count))
            End If
            grdEuipment_Serial.DataSource = dtEquipSerial
            grdEuipment_Serial.DataBind()
            grdEuipment_Serial.SelectedIndex = 0

            Session("eq") = 0
            rbStatus.Enabled = False
        End If
        LoadAIRnum()

        grdEuipment_Serial.Columns(9).Visible = False

        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            txtsupplier.Text = IIf(IsDBNull(dtEquipSerial.Rows(0)("SuppName").ToString), 0, (dtEquipSerial.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dtEquipSerial.Rows(0)("PO_No").ToString), 0, (dtEquipSerial.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dtEquipSerial.Rows(0)("DatePurchased").ToString), 0, (dtEquipSerial.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = dtEquipSerial.Rows(0).Item("RespCenter").ToString
            rbStatus.SelectedValue = 0
            btnInspectedPreview.Enabled = False
            btnEditEquip.Enabled = True
        Else

            txtInvoiceDate.ReadOnly = True
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from [dbo].[View_Inspected] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            txtsupplier.Text = IIf(IsDBNull(dt.Rows(0)("SuppName").ToString), 0, (dt.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dt.Rows(0)("PO_No").ToString), 0, (dt.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dt.Rows(0)("DatePurchased").ToString), 0, (dt.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = IIf(IsDBNull(dt.Rows(0)("RespCenter").ToString), 0, (dt.Rows(0)("RespCenter").ToString))
            txtEquipmentDescription.Text = dt.Rows(0).Item("Item_Desc").ToString
            lblairno.Text = IIf(IsDBNull(dt.Rows(0)("AIR_No").ToString), 0, (dt.Rows(0)("AIR_No").ToString))
            txtInvoiceDate.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_date").ToString), 0, (dt.Rows(0)("Invoice_date").ToString))
            txtinvoiceNo.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_No").ToString), 0, (dt.Rows(0)("Invoice_No").ToString))
            txtremaks.Text = IIf(IsDBNull(dt.Rows(0)("remarks").ToString), 0, (dt.Rows(0)("remarks").ToString))
            txtInspectedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Inspect").ToString), 0, (dt.Rows(0)("Date_Inspect").ToString))
            ddinspector1.Text = IIf(IsDBNull(dt.Rows(0)("Signatory1").ToString), 0, (dt.Rows(0)("Signatory1").ToString))
            ddinspector2.Text = IIf(IsDBNull(dt.Rows(0)("Signatory2").ToString), 0, (dt.Rows(0)("Signatory2").ToString))
            txtAcceptedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Received").ToString), 0, (dt.Rows(0)("Date_Received").ToString))

            If dt.Rows(0)("Signatory3").ToString = "" Then
                ddacceptance.DataSource = objDerived.GetDataTable("Select 'Select' as full_name, 1 as rowno union SELECT full_name  as full_name,empid " & _
                                                                  "from [dbo].[view_signatory1] where deptid = 7 and division_key = 86 order BY rowno", CommandType.Text)
                ddacceptance.DataBind()
                ddacceptance.DataTextField = ("full_name")
            Else
                ddacceptance.Text = IIf(IsDBNull(dt.Rows(0)("Signatory3").ToString), 0, (dt.Rows(0)("Signatory3").ToString))
                ddacceptance.Enabled = False
            End If

            If dt.Rows(0)(16) = True Then
                rbStatus.SelectedValue = 1
                btnacceptancepreview.Enabled = True

            Else
                rbStatus.SelectedValue = 0
                btnacceptancepreview.Enabled = False
            End If

            Session("AIRHdr_ID") = dt.Rows(0)("AIRHdr_ID").ToString
            Session("POHdr_ID") = grdInspection.SelectedDataKey("POHdr_ID")

            txtInspectedDate.Enabled = False
            ddinspector1.Enabled = False
            ddinspector2.Enabled = False

            btninspectedsave.Enabled = True
            btnInspectedPreview.Enabled = True
            btnEditEquip.Enabled = False


        End If
        btnacceptancesave.Visible = True
        btnAccptUpdate.Visible = False



        btnSaveSerial.Visible = False
        btnUpdateEquip.Visible = False
        btnEditEquip.Visible = True
        btnEditEquip.Enabled = True

        For i As Integer = 0 To grdEuipment_Serial.Rows.Count - 1
            If grdEuipment_Serial.Rows(i).Cells(8).Text = "Inspected" Then
                grdEuipment_Serial.Rows(i).Cells(0).Enabled = True
            Else
                grdEuipment_Serial.Rows(i).Cells(0).Enabled = False
            End If
        Next

        If Session("eq") = 1 Then
            rbStatus.Enabled = True
            btnacceptancepreview.Enabled = True
            btnInspectedPreview.Enabled = False

            btninspectedsave.Enabled = False
            btnAccptUpdate.Visible = True
            btnAccptUpdate.Enabled = True

            btnacceptancesave.Visible = False
            btnEditEquip.Enabled = False

            ddacceptance.Enabled = False
        Else
            LoadEquipmentDtl()
        End If
    End Sub
    Protected Sub LoadEquipmentDtl()
        Dim dtSerial As New DataTable
        dtSerial = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where Item_Serial_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_Serial_ID") & "'", CommandType.Text)
        If dtSerial.Rows.Count = 0 Then
            LoadClearEquipText()
            LoadDisableEquipText()
            LoadButtonDisable()
            btninspectedsave.Enabled = False
            btnacceptancesave.Visible = True
            btnAccptUpdate.Visible = False

        ElseIf grdEuipment_Serial.SelectedDataKey("SerialNo") = "" Or grdEuipment_Serial.SelectedDataKey("SerialNo") = Nothing Then
            LoadDisableEquipText()
            LoadButtonDisable()
            btninspectedsave.Enabled = False
            btnacceptancesave.Visible = True
            btnAccptUpdate.Visible = False
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Serial Number is Required")
        Else

            btninspectedsave.Enabled = True
            LoadEnableEquiptext()

            Dim dtEquipDtl As New DataTable
            dtEquipDtl = objDerived.GetDataTable("Select * from [dbo].[View_AIR_EquipmentInfo] where Item_ID = '" & grdEuipment_Serial.SelectedDataKey(0) & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey(9) & "' ", CommandType.Text)
            If dtEquipDtl.Rows.Count = 0 Then
                PropNo.Text = ""
                LoadClearEquipText()
                LoadButtonDisable()
                btnacceptancesave.Visible = True
                btnAccptUpdate.Visible = False
                txtEquipmentDescription.Text = objDerived.GetValue("Select Item_Desc from [dbo].[View_InspectionAcceptanceGoods] where PODtl_ID = '" & grdEuipment_Serial.SelectedDataKey(3) & "'", CommandType.Text)

            Else
                Dim dtEquipAccpt As New DataTable
                dtEquipAccpt = objDerived.GetDataTable("Select * from [dbo].[View_GetPropertyNoEquipment] where Item_ID = '" & grdEuipment_Serial.SelectedDataKey(0) & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                If dtEquipAccpt.Rows.Count = 0 Then
                    txtEquipmentName.Text = IIf(IsDBNull(dtEquipDtl.Rows(0)("Name").ToString), 0, (dtEquipDtl.Rows(0)("Name").ToString))
                    txtEquipmentDescription.Text = IIf(IsDBNull(dtEquipDtl.Rows(0)("Description").ToString), 0, (dtEquipDtl.Rows(0)("Description").ToString))
                    txtEquipmentpowerinput.Text = IIf(IsDBNull(dtEquipDtl.Rows(0)("PowerInput").ToString), 0, (dtEquipDtl.Rows(0)("PowerInput").ToString))
                    txtEquipmentDepreciatedRate.Text = IIf(IsDBNull(dtEquipDtl.Rows(0)("DepreciationRate").ToString), 0, (dtEquipDtl.Rows(0)("DepreciationRate").ToString))
                    txtEquipmentDimension.Text = IIf(IsDBNull(dtEquipDtl.Rows(0)("Dimension").ToString), 0, (dtEquipDtl.Rows(0)("Dimension").ToString))
                    txtEquipmentAreaCapacity.Text = IIf(IsDBNull(dtEquipDtl.Rows(0)("AreaCapacity").ToString), 0, (dtEquipDtl.Rows(0)("AreaCapacity").ToString))
                    txtEquipmentModel.Text = IIf(IsDBNull(dtEquipDtl.Rows(0)("Model").ToString), 0, (dtEquipDtl.Rows(0)("Model").ToString))
                    txtEquipmentWarranty.Text = IIf(IsDBNull(dtEquipDtl.Rows(0)("Warranty").ToString), 0, (dtEquipDtl.Rows(0)("Warranty").ToString))
                    txtEquipmentDepreciatedValue.Text = IIf(IsDBNull(dtEquipDtl.Rows(0)("DepreciationValue").ToString), 0, (dtEquipDtl.Rows(0)("DepreciationValue").ToString))
                    txtEquipmentSpecification.Text = IIf(IsDBNull(dtEquipDtl.Rows(0)("Specification").ToString), 0, (dtEquipDtl.Rows(0)("Specification").ToString))
                    PropNo.Text = ""
                    LoadButtonEnable()
                    LoadButtonEnable2()
                    btnacceptancesave.Visible = True
                    btnAccptUpdate.Visible = False
                Else
                    txtEquipmentName.Text = IIf(IsDBNull(dtEquipAccpt.Rows(0)("Name").ToString), 0, (dtEquipAccpt.Rows(0)("Name").ToString))
                    txtEquipmentDescription.Text = IIf(IsDBNull(dtEquipAccpt.Rows(0)("Description").ToString), 0, (dtEquipAccpt.Rows(0)("Description").ToString))
                    txtEquipmentpowerinput.Text = IIf(IsDBNull(dtEquipAccpt.Rows(0)("PowerInput").ToString), 0, (dtEquipAccpt.Rows(0)("PowerInput").ToString))
                    txtEquipmentDepreciatedRate.Text = IIf(IsDBNull(dtEquipAccpt.Rows(0)("DepreciationRate").ToString), 0, (dtEquipAccpt.Rows(0)("DepreciationRate").ToString))
                    txtEquipmentDimension.Text = IIf(IsDBNull(dtEquipAccpt.Rows(0)("Dimension").ToString), 0, (dtEquipAccpt.Rows(0)("Dimension").ToString))
                    txtEquipmentAreaCapacity.Text = IIf(IsDBNull(dtEquipAccpt.Rows(0)("AreaCapacity").ToString), 0, (dtEquipAccpt.Rows(0)("AreaCapacity").ToString))
                    txtEquipmentModel.Text = IIf(IsDBNull(dtEquipAccpt.Rows(0)("Model").ToString), 0, (dtEquipAccpt.Rows(0)("Model").ToString))
                    txtEquipmentWarranty.Text = IIf(IsDBNull(dtEquipAccpt.Rows(0)("Warranty").ToString), 0, (dtEquipAccpt.Rows(0)("Warranty").ToString))
                    txtEquipmentDepreciatedValue.Text = IIf(IsDBNull(dtEquipAccpt.Rows(0)("DepreciationValue").ToString), 0, (dtEquipAccpt.Rows(0)("DepreciationValue").ToString))
                    txtEquipmentSpecification.Text = IIf(IsDBNull(dtEquipAccpt.Rows(0)("Specification").ToString), 0, (dtEquipAccpt.Rows(0)("Specification").ToString))
                    PropNo.Text = IIf(IsDBNull(dtEquipAccpt.Rows(0)("PropertyNo").ToString), 0, (dtEquipAccpt.Rows(0)("PropertyNo").ToString))

                    LoadButtonEnable()
                    LoadButtonEnable2()


                    If dtEquipAccpt.Rows(0)("Status").ToString = "Inspected" Then
                        btninspectedsave.Enabled = True
                        btnInspectedPreview.Enabled = True
                        btnacceptancesave.Visible = True
                        btnAccptUpdate.Visible = False
                        btnacceptancepreview.Enabled = False
                        txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")

                    ElseIf dtEquipAccpt.Rows(0)("Status").ToString = "Accepted" Then
                        ddacceptance.Enabled = False
                        btninspectedsave.Enabled = False
                        btnInspectUpdate.Enabled = False
                        btnInspectedPreview.Enabled = False
                        btnacceptancesave.Visible = False
                        btnAccptUpdate.Visible = True
                        btnacceptancepreview.Enabled = True
                    End If
                End If
            End If
        End If

    End Sub

    Protected Sub btnSaveSerial_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSaveSerial.OnClientClick = "StartProgressBar();"

        Dim cnt As Integer
        For cnt = 0 To grdEuipment.Rows.Count - 1
            With objPropSerial
                Dim hasAmount As Boolean = False
                .POHdr_ID = Session("POHdr_ID") 'objDerived.GetValue("Select POHdr_ID from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .Qty = 1

                If grdEuipment.Rows(cnt).Cells(7).Text = "&nbsp;" Then
                    grdEuipment.Rows(cnt).Cells(7).Text = grdEuipment.Rows(cnt).Cells(7).Text.Replace("&nbsp;", "")
                End If
                .Status = grdEuipment.Rows(cnt).Cells(7).Text
                .Property_Dtl_ID = 0

                If CType(grdEuipment.Rows(cnt).FindControl("lblItemCode"), Label).Text = "" Then
                    Exit For
                Else
                    .Item_ID = CType(grdEuipment.Rows(cnt).FindControl("lblItemCode"), Label).Text
                End If

                Dim txtSerial As TextBox
                txtSerial = CType(grdEuipment.Rows(cnt).FindControl("txtEquipSerialNo"), TextBox)
                .SerialNo = CType(txtSerial.Text, String)

                Dim txtCondition As TextBox
                txtCondition = CType(grdEuipment.Rows(cnt).FindControl("txtEquipCondition"), TextBox)
                .Condition = CType(txtCondition.Text, String)

                Dim txtMarketValue As TextBox
                txtMarketValue = CType(grdEuipment.Rows(cnt).FindControl("txtEquipMV"), TextBox)
                If CType(txtMarketValue.Text, String) = "" Then
                    .MarketValue = "0.00"
                Else
                    .MarketValue = CType(txtMarketValue.Text, String)
                End If


                Dim txtLocation As TextBox
                txtLocation = CType(grdEuipment.Rows(cnt).FindControl("txtEquipLoc"), TextBox)
                .Location = CType(txtLocation.Text, String)

                objPropSerial.Item_Serial_ID = 0
                objPropSerial.save()
                Item_Serial_ID = objPropSerial.GetValue("Select max(Item_Serial_ID) from AMS.TbPropertySerial ", CommandType.Text)
            End With
        Next
        btnCancel2.Visible = False
        btnEditEquip.Visible = False
        LoadEquipSerial()
    End Sub
    Protected Sub btnUpdateEquip_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnUpdateEquip.OnClientClick = "StartProgressBar();"

        grdEuipment.Columns(9).Visible = True

        Dim cnt As Integer
        For cnt = 0 To grdEuipment.Rows.Count - 1
            With objPropSerial
                Dim hasAmount As Boolean = False
                .POHdr_ID = objDerived.GetValue("Select POHdr_ID from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .Qty = 1


                If CType(grdEuipment.Rows(cnt).FindControl("lblItemCode"), Label).Text = "" Then
                    Exit For
                Else
                    .Item_ID = CType(grdEuipment.Rows(cnt).FindControl("lblItemCode"), Label).Text
                End If

                Dim txtSerial As TextBox
                txtSerial = CType(grdEuipment.Rows(cnt).FindControl("txtEquipSerialNo"), TextBox)
                .SerialNo = CType(txtSerial.Text, String)

                grdEuipment.Columns(9).Visible = True
                Dim lbl As Label
                lbl = CType(grdEuipment.Rows(cnt).FindControl("lblEquip"), Label)
                .Property_Dtl_ID = lbl.Text

                If grdEuipment.Rows(cnt).Cells(7).Text = "&nbsp;" Then
                    grdEuipment.Rows(cnt).Cells(7).Text = grdEuipment.Rows(cnt).Cells(8).Text.Replace("&nbsp;", "")
                ElseIf grdEuipment.Rows(cnt).Cells(7).Text = "Inspected" Then
                    objDerived.GetRecords("Update AMS.Property_Dtl set Barcode ='" & CType(txtSerial.Text, String) & "', SerialNo = '" & CType(txtSerial.Text, String) & "' where PropertyDetai_ID ='" & lbl.Text & "'", CommandType.Text)
                    objDerived.GetRecords("Update AMS.TbEquipment_Info set SerialNo ='" & CType(txtSerial.Text, String) & "' where Property_Dtl_ID ='" & lbl.Text & "'", CommandType.Text)
                End If
                .Status = grdEuipment.Rows(cnt).Cells(7).Text

                Dim txtCondition As TextBox
                txtCondition = CType(grdEuipment.Rows(cnt).FindControl("txtEquipCondition"), TextBox)
                .Condition = CType(txtCondition.Text, String)

                Dim txtMarketValue As TextBox
                txtMarketValue = CType(grdEuipment.Rows(cnt).FindControl("txtEquipMV"), TextBox)
                '.MarketValue = CType(txtMarketValue.Text, String)
                If CType(txtMarketValue.Text, String) = "" Then
                    .MarketValue = "0.00"
                Else
                    .MarketValue = CType(txtMarketValue.Text, String)
                End If

                Dim txtLocation As TextBox
                txtLocation = CType(grdEuipment.Rows(cnt).FindControl("txtEquipLoc"), TextBox)
                .Location = CType(txtLocation.Text, String)

                Item_Serial_ID = objPropSerial.GetValue("Select Item_Serial_ID from AMS.TbPropertySerial where Item_ID = '" & CType(grdEuipment.Rows(cnt).FindControl("lblItemCode"), Label).Text & "' and SerialNo = '" & txtSerial.Text & "' ", CommandType.Text)
                objPropSerial.Item_Serial_ID = grdEuipment_Serial.DataKeys(cnt).Item("Item_Serial_ID").ToString 'Item_Serial_ID
                objPropSerial.update()
            End With
        Next

        btnCancel2.Visible = False
        LoadEquipSerial()
    End Sub
    Protected Sub btnEditEquip_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        grdEuipment.Visible = True
        grdEuipment_Serial.Visible = False
        Me.mvAttachments.Visible = False

        grdEuipment.Columns(9).Visible = True

        LoadAIRnum()

        Dim dtEquipment As New DataTable
        dtEquipment = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtEquipment.Rows.Count < 4 Then
            dtEquipment.Merge(createdatatableGoods(3 - dtEquipment.Rows.Count))
        End If
        grdEuipment.DataSource = dtEquipment
        grdEuipment.DataBind()



        Dim cnt As Integer
        For cnt = 0 To grdEuipment.Rows.Count - 1

            Dim hasAmount As Boolean = False
            Dim SerialText As TextBox
            SerialText = CType(grdEuipment.Rows(cnt).FindControl("txtEquipSerialNo"), TextBox)
            SerialText.Text = grdEuipment_Serial.Rows(cnt).Cells(2).Text.ToString
            If SerialText.Text = "&nbsp;" Then
                SerialText.Text = grdEuipment.Rows(cnt).Cells(1).Text.Replace("&nbsp;", "")
            End If

            Dim ConditionText As TextBox
            ConditionText = CType(grdEuipment.Rows(cnt).FindControl("txtEquipCondition"), TextBox)
            ConditionText.Text = grdEuipment_Serial.Rows(cnt).Cells(6).Text.ToString
            If ConditionText.Text = "&nbsp;" Then
                ConditionText.Text = grdEuipment.Rows(cnt).Cells(5).Text.Replace("&nbsp;", "")
            End If

            Dim MarketValuetxt As TextBox
            MarketValuetxt = CType(grdEuipment.Rows(cnt).FindControl("txtEquipMV"), TextBox)
            MarketValuetxt.Text = grdEuipment_Serial.Rows(cnt).Cells(5).Text.ToString
            If MarketValuetxt.Text = "&nbsp;" Then
                MarketValuetxt.Text = grdEuipment.Rows(cnt).Cells(4).Text.Replace("&nbsp;", "")
            End If

            Dim Locationtxt As TextBox
            Locationtxt = CType(grdEuipment.Rows(cnt).FindControl("txtEquipLoc"), TextBox)
            Locationtxt.Text = grdEuipment_Serial.Rows(cnt).Cells(7).Text.ToString
            If Locationtxt.Text = "&nbsp;" Then
                Locationtxt.Text = grdEuipment.Rows(cnt).Cells(6).Text.Replace("&nbsp;", "")
            End If

            Dim lbl As Label
            lbl = CType(grdEuipment.Rows(cnt).FindControl("lblEquip"), Label)
            lbl.Text = grdEuipment_Serial.Rows(cnt).Cells(9).Text.ToString
            If lbl.Text = "&nbsp;" Then
                lbl.Text = grdEuipment.Rows(cnt).Cells(9).Text.Replace("&nbsp;", "")
            End If

        Next

        grdEuipment.Columns(9).Visible = False

        LoadClearEquipText()
        LoadDisableEquipText()

        btninspectedsave.Enabled = False
        LoadButtonDisable()
        btnSaveSerial.Visible = False
        btnCancel2.Visible = True
        btnUpdateEquip.Visible = True
        btnEditEquip.Visible = False
    End Sub
    Protected Sub btnCancel2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnCancel2.Visible = False
        LoadEquipSerial()
    End Sub

    Protected Sub LoadEuipInfoSave()
        dtEquipInfo = objEquipInfo.GetDataTable("select EquipInfoId from AMS.TbEquipment_Info where AIRDtl_ID like '" & AIRDtl_ID & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "' ", CommandType.Text)
        With objEquipInfo
            '.EquipInfoId = EquipInfoId
            .AIRDtl_ID = AIRDtl_ID
            '.IsAccepted = ""
            .Property_Dtl_ID = PropertyDetai_ID
            .SerialNo = grdEuipment_Serial.SelectedDataKey("SerialNo")
            .Name = txtEquipmentName.Text
            .Description = txtEquipmentDescription.Text
            .PowerInput = txtEquipmentpowerinput.Text
            .DepreciationRate = txtEquipmentDepreciatedRate.Text
            .Dimension = txtEquipmentDimension.Text
            .AreaCapacity = txtEquipmentAreaCapacity.Text
            .Model = txtEquipmentModel.Text
            .Warranty = txtEquipmentWarranty.Text
            .Specification = txtEquipmentSpecification.Text

            If txtEquipmentDepreciatedValue.Text = "" Then
                .DepreciationValue = "0.00"
            Else
                .DepreciationValue = txtEquipmentDepreciatedValue.Text
            End If
        End With

        If dtEquipInfo.Rows.Count = 0 Then
            objEquipInfo.EquipInfoId = 0
            objEquipInfo.save()
            EquipInfoId = objEquipInfo.GetValue("Select max(EquipInfoId) from AMS.TbEquipment_Info ", CommandType.Text)
        Else
            EquipInfoId = objEquipInfo.GetValue("Select EquipInfoId from AMS.TbEquipment_Info where AIRDtl_ID like '" & AIRDtl_ID & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            objEquipInfo.EquipInfoId = EquipInfoId
            objEquipInfo.update()
        End If
    End Sub
    Protected Sub LoadEquipDtlSave()
        dtEquipDtl = objEquipDtl.GetDataTable("select EquipmentId from AMS.TbEquipment_Dtl where EquipInfoId like '" & EquipInfoId & "' ", CommandType.Text)
        With objEquipDtl
            '  .EquipmentId = EquipmentId
            .EquipInfoId = EquipInfoId
            .Property_Dtl_ID = PropertyDetai_ID
            .MarketValue = grdEuipment_Serial.SelectedDataKey("MarketValue")
            .Condition = grdEuipment_Serial.SelectedDataKey("Condition")
            .Location = grdEuipment_Serial.SelectedDataKey("Location")
            .Status = objDerived.GetValue("Select Status from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
        End With

        If dtEquipDtl.Rows.Count = 0 Then
            objEquipDtl.EquipmentId = 0
            objEquipDtl.save()
            EquipmentId = objEquipDtl.GetValue("Select max(EquipmentId) from AMS.TbEquipment_Dtl ", CommandType.Text)
        Else
            EquipmentId = objEquipDtl.GetValue("Select EquipmentId from AMS.TbEquipment_Dtl where EquipInfoId like '" & EquipInfoId & "' ", CommandType.Text)
            objEquipDtl.EquipmentId = EquipmentId
            objEquipDtl.update()
        End If
        loadBarcode()
        LoadEquipSerial()

    End Sub

    Protected Sub grdEuipment_Serial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadEquipmentDtl()
    End Sub
    Protected Sub grdEuipment_Serial_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdEuipment_Serial, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub LoadClearEquipText()
        txtEquipmentName.Text = ""
        txtEquipmentDescription.Text = ""
        txtEquipmentpowerinput.Text = ""
        txtEquipmentDepreciatedRate.Text = ""
        txtEquipmentDimension.Text = ""
        txtEquipmentAreaCapacity.Text = ""
        txtEquipmentModel.Text = ""
        txtEquipmentWarranty.Text = ""
        txtEquipmentDepreciatedValue.Text = ""
        txtEquipmentSpecification.Text = ""
    End Sub
    Protected Sub LoadEnableEquipText()
        txtEquipmentName.Enabled = True
        txtEquipmentDescription.Enabled = True
        txtEquipmentpowerinput.Enabled = True
        txtEquipmentDepreciatedRate.Enabled = True
        txtEquipmentDimension.Enabled = True
        txtEquipmentAreaCapacity.Enabled = True
        txtEquipmentModel.Enabled = True
        txtEquipmentWarranty.Enabled = True
        txtEquipmentDepreciatedValue.Enabled = True
        txtEquipmentSpecification.Enabled = True
    End Sub
    Protected Sub LoadDisableEquipText()
        txtEquipmentName.Enabled = False
        txtEquipmentDescription.Enabled = False
        txtEquipmentpowerinput.Enabled = False
        txtEquipmentDepreciatedRate.Enabled = False
        txtEquipmentDimension.Enabled = False
        txtEquipmentAreaCapacity.Enabled = False
        txtEquipmentModel.Enabled = False
        txtEquipmentWarranty.Enabled = False
        txtEquipmentDepreciatedValue.Enabled = False
        txtEquipmentSpecification.Enabled = False
    End Sub

    ' MACHINERIES INSPECTION AND ACCEPTANCE 
    Protected Sub LoadMachineryGoods()
        Dim dtMachine As New DataTable
        dtMachine = objDerived.GetDataTable("Select * from AMS.TbPropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtMachine.Rows.Count = 0 Then
            LoadMachinery()
        Else
            LoadMachineSerial()
        End If
    End Sub
    Protected Sub LoadMachinery()
        grdMachineries.Visible = True
        grdMachineries_Serial.Visible = False
        Me.mvAttachments.Visible = False

        LoadAIRnum()

        Dim dtMachineries As New DataTable
        dtMachineries = objDerived.GetDataTable("exec dbo.load_goods_for_serial  '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtMachineries.Rows.Count < 8 Then
            dtMachineries.Merge(createdatatableGoods(7 - dtMachineries.Rows.Count))
        End If
        grdMachineries.DataSource = dtMachineries
        grdMachineries.DataBind()

        txtsupplier.Text = IIf(IsDBNull(dtMachineries.Rows(0)("SuppName").ToString), 0, (dtMachineries.Rows(0)("SuppName").ToString))
        txtPOnum.Text = IIf(IsDBNull(dtMachineries.Rows(0)("PO_No").ToString), 0, (dtMachineries.Rows(0)("PO_No").ToString))
        txtpoDate.Text = IIf(IsDBNull(dtMachineries.Rows(0)("DatePurchased").ToString), 0, (dtMachineries.Rows(0)("DatePurchased").ToString))
        txtdepartment.Text = dtMachineries.Rows(0).Item("RespCenter").ToString
        rbStatus.SelectedValue = 0

        LoadClearMachinetext()
        LoadDisableMachineText()

        btninspectedsave.Enabled = False
        btnAccptUpdate.Visible = False
        LoadButtonDisable()

        btnSaveSerialMac.Visible = True
        btnUpdateMac.Visible = False
        btnEditMachine.Visible = False

    End Sub
    Protected Sub LoadMachineSerial()
        grdMachineries.Visible = False
        grdMachineries_Serial.Visible = True
        Me.mvAttachments.Visible = True

        grdMachineries_Serial.Columns(9).Visible = True

        Dim dtMachineSerial As New DataTable
        dtMachineSerial = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtMachineSerial.Rows.Count = 0 Then
            grdMachineries_Serial.DataSource = createdatatableGoods2(8)
            grdMachineries_Serial.DataBind()
            Session("mach") = 1

        Else
            If dtMachineSerial.Rows.Count < 8 Then
                dtMachineSerial.Merge(createdatatableGoods2(7 - dtMachineSerial.Rows.Count))
            End If
            grdMachineries_Serial.DataSource = dtMachineSerial
            grdMachineries_Serial.DataBind()
            grdMachineries_Serial.SelectedIndex = 0

            Session("mach") = 0
            rbStatus.Enabled = False
        End If

        grdMachineries_Serial.Columns(9).Visible = False

        LoadAIRnum()

        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            txtsupplier.Text = IIf(IsDBNull(dtMachineSerial.Rows(0)("SuppName").ToString), 0, (dtMachineSerial.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dtMachineSerial.Rows(0)("PO_No").ToString), 0, (dtMachineSerial.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dtMachineSerial.Rows(0)("DatePurchased").ToString), 0, (dtMachineSerial.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = dtMachineSerial.Rows(0).Item("RespCenter").ToString
            rbStatus.SelectedValue = 0
            btnEditMachine.Enabled = True
        Else
            txtInvoiceDate.ReadOnly = True
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from [dbo].[View_Inspected] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            txtsupplier.Text = IIf(IsDBNull(dt.Rows(0)("SuppName").ToString), 0, (dt.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dt.Rows(0)("PO_No").ToString), 0, (dt.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dt.Rows(0)("DatePurchased").ToString), 0, (dt.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = dtMachineSerial.Rows(0).Item("RespCenter").ToString
            txtMachiniriesDesc.Text = dtMachineSerial.Rows(0).Item("Item_Desc").ToString
            lblairno.Text = IIf(IsDBNull(dt.Rows(0)("AIR_No").ToString), 0, (dt.Rows(0)("AIR_No").ToString))
            txtInvoiceDate.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_date").ToString), 0, (dt.Rows(0)("Invoice_date").ToString))
            txtinvoiceNo.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_No").ToString), 0, (dt.Rows(0)("Invoice_No").ToString))
            txtremaks.Text = IIf(IsDBNull(dt.Rows(0)("remarks").ToString), 0, (dt.Rows(0)("remarks").ToString))
            txtInspectedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Inspect").ToString), 0, (dt.Rows(0)("Date_Inspect").ToString))
            ddinspector1.Text = IIf(IsDBNull(dt.Rows(0)("Signatory1").ToString), 0, (dt.Rows(0)("Signatory1").ToString))
            ddinspector2.Text = IIf(IsDBNull(dt.Rows(0)("Signatory2").ToString), 0, (dt.Rows(0)("Signatory2").ToString))
            txtAcceptedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Received").ToString), 0, (dt.Rows(0)("Date_Received").ToString))

            If dt.Rows(0)("Signatory3").ToString = "" Then
                ddacceptance.DataSource = objDerived.GetDataTable("Select 'Select' as full_name, 1 as rowno union SELECT full_name  as full_name,empid " & _
                                                                  "from [dbo].[view_signatory1] where deptid = 7 and division_key = 86 order BY rowno", CommandType.Text)
                ddacceptance.DataBind()
                ddacceptance.DataTextField = ("full_name")
            Else
                ddacceptance.Text = IIf(IsDBNull(dt.Rows(0)("Signatory3").ToString), 0, (dt.Rows(0)("Signatory3").ToString))
                ddacceptance.Enabled = False
            End If

            If dt.Rows(0)(16) = True Then
                rbStatus.SelectedValue = 1
                btnacceptancepreview.Enabled = True
            Else
                rbStatus.SelectedValue = 0
                btnacceptancepreview.Enabled = False
            End If

            Session("AIRHdr_ID") = dt.Rows(0)("AIRHdr_ID").ToString
            Session("POHdr_ID") = grdInspection.SelectedDataKey("POHdr_ID")

            txtInspectedDate.Enabled = False
            ddinspector1.Enabled = False
            ddinspector2.Enabled = False

            btninspectedsave.Enabled = True
            btnInspectedPreview.Enabled = True
            btnEditMachine.Enabled = False
        End If
        btnacceptancesave.Visible = True
        btnAccptUpdate.Visible = False



        Dim i As Integer
        For i = 0 To grdMachineries_Serial.Rows.Count - 1
            If grdMachineries_Serial.Rows(i).Cells(8).Text = "Inspected" Then
                grdMachineries_Serial.Rows(i).Cells(0).Enabled = True
            Else
                grdMachineries_Serial.Rows(i).Cells(0).Enabled = False
            End If
        Next

        btnSaveSerialMac.Visible = False
        btnUpdateMac.Visible = False
        btnEditMachine.Visible = True
        btnEditMachine.Enabled = True

        If Session("mach") = 1 Then
            rbStatus.Enabled = True
            btnacceptancepreview.Enabled = True
            btnInspectedPreview.Enabled = False

            btninspectedsave.Enabled = False
            btnAccptUpdate.Visible = True
            btnAccptUpdate.Enabled = True

            btnacceptancesave.Visible = False
            btnEditMachine.Enabled = False
        Else
            LoadMachineryInfo()
        End If
    End Sub
    Protected Sub LoadMachineryInfo()
        Dim dtSerial As New DataTable
        dtSerial = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where Item_Serial_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_Serial_ID") & "'", CommandType.Text)
        If dtSerial.Rows.Count = 0 Then
            PropNo.Text = ""
            LoadClearMachinetext()
            LoadButtonDisable()
            LoadDisableMachineText()
            btninspectedsave.Enabled = False
            btnacceptancesave.Visible = True
            btnAccptUpdate.Visible = False

        ElseIf grdMachineries_Serial.SelectedDataKey("SerialNo") = "" Or grdMachineries_Serial.SelectedDataKey("SerialNo") = Nothing Then
            PropNo.Text = ""
            LoadClearMachinetext()
            LoadDisableMachineText()
            LoadButtonDisable()
            btninspectedsave.Enabled = False
            btnacceptancesave.Visible = True
            btnAccptUpdate.Visible = False
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Serial Number is Required")

        Else
            btninspectedsave.Enabled = True
            LoadEnableMachinetext()

            Dim dtMachineInfo As New DataTable
            dtMachineInfo = objDerived.GetDataTable("Select * from [dbo].[View_AIR_MachineInfo] where Item_ID = '" & grdMachineries_Serial.SelectedDataKey(0) & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            If dtMachineInfo.Rows.Count = 0 Then
                PropNo.Text = ""
                LoadClearMachinetext()
                LoadButtonDisable()
                btnacceptancesave.Visible = True
                btnAccptUpdate.Visible = False
                txtMachiniriesDesc.Text = objDerived.GetValue("Select Item_Desc from [dbo].[View_InspectionAcceptanceGoods] where PODtl_ID = '" & grdMachineries_Serial.SelectedDataKey(3) & "'", CommandType.Text)

            Else
                Dim MachineAccpt As New DataTable
                MachineAccpt = objDerived.GetDataTable("Select * from [dbo].[View_GetPropertyNoMachine] where Item_ID = '" & grdMachineries_Serial.SelectedDataKey(0) & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                If MachineAccpt.Rows.Count = 0 Then
                    txtMachiniriesBrandmodel.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("BrandModel").ToString), 0, (dtMachineInfo.Rows(0)("BrandModel").ToString))
                    txtMachiniriesDesc.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("MachineDesc").ToString), 0, (dtMachineInfo.Rows(0)("MachineDesc").ToString))
                    txtMachiniriesLocation.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("MachineLocation").ToString), 0, (dtMachineInfo.Rows(0)("MachineLocation").ToString))
                    txtMachiniriesNoofPassengers.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("NoPassengers").ToString), 0, (dtMachineInfo.Rows(0)("NoPassengers").ToString))
                    txtMachiniriesServiceFloor.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("ServiceFloors").ToString), 0, (dtMachineInfo.Rows(0)("ServiceFloors").ToString))
                    txtMachiniriesDeprecitedRate.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("DepreciationRate").ToString), 0, (dtMachineInfo.Rows(0)("DepreciationRate").ToString))
                    txtMachiniriesUnitNo.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("MachineUnitNo").ToString), 0, (dtMachineInfo.Rows(0)("MachineUnitNo").ToString))
                    txtMachiniriesWorkingLoad.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("WorkingLoad").ToString), 0, (dtMachineInfo.Rows(0)("WorkingLoad").ToString))
                    txtMachiniriesRatedSpeed.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("RatedSpeed").ToString), 0, (dtMachineInfo.Rows(0)("RatedSpeed").ToString))
                    txtMachiniriescardimension.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("CarDimensions").ToString), 0, (dtMachineInfo.Rows(0)("CarDimensions").ToString))
                    txtMachiniriesDepreciatedValue.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("DepreciationValue").ToString), 0, (dtMachineInfo.Rows(0)("DepreciationValue").ToString))
                    txtMachiniriesMechpermitno.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("MechinePermitNo").ToString), 0, (dtMachineInfo.Rows(0)("MechinePermitNo").ToString))
                    txtMachiniriesDatetoOperate.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("DateOperate").ToString), 0, (dtMachineInfo.Rows(0)("DateOperate").ToString))
                    txtMachiniriesDateissued.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("DateIssued").ToString), 0, (dtMachineInfo.Rows(0)("DateIssued").ToString))
                    txtMachiniriesDateInspected.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("DateInspected").ToString), 0, (dtMachineInfo.Rows(0)("DateInspected").ToString))
                    txtMachiniriesInspectedBy.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("InspectedBy").ToString), 0, (dtMachineInfo.Rows(0)("InspectedBy").ToString))
                    txtMachiniriesRemarks.Text = IIf(IsDBNull(dtMachineInfo.Rows(0)("Remarks").ToString), 0, (dtMachineInfo.Rows(0)("Remarks").ToString))
                    PropNo.Text = ""
                    LoadButtonEnable()
                    LoadButtonEnable2()
                    btnacceptancesave.Visible = True
                    btnAccptUpdate.Visible = False
                Else
                    txtMachiniriesBrandmodel.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("BrandModel").ToString), 0, (MachineAccpt.Rows(0)("BrandModel").ToString))
                    txtMachiniriesDesc.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("MachineDesc").ToString), 0, (MachineAccpt.Rows(0)("MachineDesc").ToString))
                    txtMachiniriesLocation.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("MachineLocation").ToString), 0, (MachineAccpt.Rows(0)("MachineLocation").ToString))
                    txtMachiniriesNoofPassengers.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("NoPassengers").ToString), 0, (MachineAccpt.Rows(0)("NoPassengers").ToString))
                    txtMachiniriesServiceFloor.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("ServiceFloors").ToString), 0, (MachineAccpt.Rows(0)("ServiceFloors").ToString))
                    txtMachiniriesDeprecitedRate.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("DepreciationRate").ToString), 0, (MachineAccpt.Rows(0)("DepreciationRate").ToString))
                    txtMachiniriesUnitNo.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("MachineUnitNo").ToString), 0, (MachineAccpt.Rows(0)("MachineUnitNo").ToString))
                    txtMachiniriesWorkingLoad.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("WorkingLoad").ToString), 0, (MachineAccpt.Rows(0)("WorkingLoad").ToString))
                    txtMachiniriesRatedSpeed.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("RatedSpeed").ToString), 0, (MachineAccpt.Rows(0)("RatedSpeed").ToString))
                    txtMachiniriescardimension.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("CarDimensions").ToString), 0, (MachineAccpt.Rows(0)("CarDimensions").ToString))
                    txtMachiniriesDepreciatedValue.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("DepreciationValue").ToString), 0, (MachineAccpt.Rows(0)("DepreciationValue").ToString))
                    txtMachiniriesMechpermitno.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("MechinePermitNo").ToString), 0, (MachineAccpt.Rows(0)("MechinePermitNo").ToString))
                    txtMachiniriesDatetoOperate.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("DateOperate").ToString), 0, (MachineAccpt.Rows(0)("DateOperate").ToString))
                    txtMachiniriesDateissued.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("DateIssued").ToString), 0, (MachineAccpt.Rows(0)("DateIssued").ToString))
                    txtMachiniriesDateInspected.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("DateInspected").ToString), 0, (MachineAccpt.Rows(0)("DateInspected").ToString))
                    txtMachiniriesInspectedBy.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("InspectedBy").ToString), 0, (MachineAccpt.Rows(0)("InspectedBy").ToString))
                    txtMachiniriesRemarks.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("Remarks").ToString), 0, (MachineAccpt.Rows(0)("Remarks").ToString))
                    PropNo.Text = IIf(IsDBNull(MachineAccpt.Rows(0)("PropertyNo").ToString), 0, (MachineAccpt.Rows(0)("PropertyNo").ToString))

                    LoadButtonEnable()
                    LoadButtonEnable2()


                    If MachineAccpt.Rows(0)("Status").ToString = "Inspected" Then
                        btnInspectedPreview.Enabled = True
                        btnacceptancesave.Visible = True
                        btnAccptUpdate.Visible = False
                        btnacceptancepreview.Enabled = False
                        txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")

                    ElseIf MachineAccpt.Rows(0)("Status").ToString = "Accepted" Then
                        ddacceptance.Enabled = False
                        btninspectedsave.Enabled = False
                        btnInspectUpdate.Enabled = False
                        btnInspectedPreview.Enabled = False
                        btnacceptancesave.Visible = False
                        btnAccptUpdate.Visible = True
                        btnacceptancepreview.Enabled = True

                        LoadIFCompleted()
                    End If

                End If
            End If
        End If
        LoadAttchDoc()
    End Sub

    Protected Sub btnSaveSerialMac_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSaveSerialMac.OnClientClick = "StartProgressBar();"

        Dim cnt As Integer
        For cnt = 0 To grdMachineries.Rows.Count - 1
            With objPropSerial
                Dim hasAmount As Boolean = False
                .POHdr_ID = Session("POHdr_ID") 'objDerived.GetValue("Select POHdr_ID from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .Qty = 1

                If grdMachineries.Rows(cnt).Cells(7).Text = "&nbsp;" Then
                    grdMachineries.Rows(cnt).Cells(7).Text = grdMachineries.Rows(cnt).Cells(7).Text.Replace("&nbsp;", "")
                End If
                .Status = grdMachineries.Rows(cnt).Cells(7).Text


                If CType(grdMachineries.Rows(cnt).FindControl("lblMacItemID"), Label).Text = "" Then
                    Exit For
                Else
                    .Item_ID = CType(grdMachineries.Rows(cnt).FindControl("lblMacItemID"), Label).Text
                End If

                Dim txtSerial As TextBox
                txtSerial = CType(grdMachineries.Rows(cnt).FindControl("txtMachineSerial"), TextBox)
                .SerialNo = CType(txtSerial.Text, String)

                Dim txtCondition As TextBox
                txtCondition = CType(grdMachineries.Rows(cnt).FindControl("txtMachineCondition"), TextBox)
                .Condition = CType(txtCondition.Text, String)

                Dim txtMarketValue As TextBox
                txtMarketValue = CType(grdMachineries.Rows(cnt).FindControl("txtMachineMV"), TextBox)
                '.MarketValue = CType(txtMarketValue.Text, String)
                If CType(txtMarketValue.Text, String) = "" Then
                    .MarketValue = "0.00"
                Else
                    .MarketValue = CType(txtMarketValue.Text, String)
                End If

                Dim txtLocation As TextBox
                txtLocation = CType(grdMachineries.Rows(cnt).FindControl("txtMachineLoc"), TextBox)
                .Location = CType(txtLocation.Text, String)

                objPropSerial.Item_Serial_ID = 0
                objPropSerial.save()
                Item_Serial_ID = objPropSerial.GetValue("Select max(Item_Serial_ID) from AMS.TbPropertySerial ", CommandType.Text)

            End With
        Next
        btnCancelMac.Visible = False
        LoadMachineSerial()
    End Sub
    Protected Sub btnUpdateMac_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnUpdateMac.OnClientClick = "StartProgressBar();"

        grdMachineries.Columns(9).Visible = True

        Dim cnt As Integer
        For cnt = 0 To grdMachineries.Rows.Count - 1
            With objPropSerial
                Dim hasAmount As Boolean = False
                .POHdr_ID = objDerived.GetValue("Select POHdr_ID from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .Qty = 1

                If CType(grdMachineries.Rows(cnt).FindControl("lblMacItemID"), Label).Text = "" Then
                    Exit For
                Else
                    .Item_ID = CType(grdMachineries.Rows(cnt).FindControl("lblMacItemID"), Label).Text
                End If

                Dim txtSerial As TextBox
                txtSerial = CType(grdMachineries.Rows(cnt).FindControl("txtMachineSerial"), TextBox)
                .SerialNo = CType(txtSerial.Text, String)

                Dim lbl As Label
                lbl = CType(grdMachineries.Rows(cnt).FindControl("lblMach"), Label)
                .Property_Dtl_ID = lbl.Text

                If grdMachineries.Rows(cnt).Cells(7).Text = "&nbsp;" Then
                    grdMachineries.Rows(cnt).Cells(7).Text = grdMachineries.Rows(cnt).Cells(7).Text.Replace("&nbsp;", "")
                ElseIf grdMachineries.Rows(cnt).Cells(7).Text = "Inspected" Then
                    objDerived.GetRecords("Update AMS.Property_Dtl set Barcode ='" & CType(txtSerial.Text, String) & "', SerialNo = '" & CType(txtSerial.Text, String) & "' where PropertyDetai_ID ='" & lbl.Text & "'", CommandType.Text)
                    objDerived.GetRecords("Update AMS.TbMachinery_Information set SerialNo ='" & CType(txtSerial.Text, String) & "' where Property_Dtl_ID ='" & lbl.Text & "'", CommandType.Text)
                End If
                .Status = grdMachineries.Rows(cnt).Cells(7).Text

                Dim txtCondition As TextBox
                txtCondition = CType(grdMachineries.Rows(cnt).FindControl("txtMachineCondition"), TextBox)
                .Condition = CType(txtCondition.Text, String)

                Dim txtMarketValue As TextBox
                txtMarketValue = CType(grdMachineries.Rows(cnt).FindControl("txtMachineMV"), TextBox)
                '.MarketValue = CType(txtMarketValue.Text, String)
                If CType(txtMarketValue.Text, String) = "" Then
                    .MarketValue = "0.00"
                Else
                    .MarketValue = CType(txtMarketValue.Text, String)
                End If

                Dim txtLocation As TextBox
                txtLocation = CType(grdMachineries.Rows(cnt).FindControl("txtMachineLoc"), TextBox)
                .Location = CType(txtLocation.Text, String)


                objPropSerial.Item_Serial_ID = grdMachineries_Serial.DataKeys(cnt).Item("Item_Serial_ID").ToString
                objPropSerial.update()
            End With
        Next
        btnCancelMac.Visible = False
        LoadMachineSerial()
    End Sub
    Protected Sub btnEditMachine_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        grdMachineries.Visible = True
        grdMachineries_Serial.Visible = False
        Me.mvAttachments.Visible = False

        grdMachineries.Columns(9).Visible = True

        LoadAIRnum()

        Dim dtMachine As New DataTable
        dtMachine = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtMachine.Rows.Count < 4 Then
            dtMachine.Merge(createdatatableGoods2(3 - dtMachine.Rows.Count))
        End If
        grdMachineries.DataSource = dtMachine
        grdMachineries.DataBind()

        Dim cnt As Integer
        For cnt = 0 To grdMachineries.Rows.Count - 1

            Dim hasAmount As Boolean = False
            Dim SerialText As TextBox
            SerialText = CType(grdMachineries.Rows(cnt).FindControl("txtMachineSerial"), TextBox)
            SerialText.Text = grdMachineries_Serial.Rows(cnt).Cells(2).Text.ToString
            If SerialText.Text = "&nbsp;" Then
                SerialText.Text = grdMachineries.Rows(cnt).Cells(1).Text.Replace("&nbsp;", "")
            End If

            Dim MarketValuetxt As TextBox
            MarketValuetxt = CType(grdMachineries.Rows(cnt).FindControl("txtMachineMV"), TextBox)
            MarketValuetxt.Text = grdMachineries_Serial.Rows(cnt).Cells(5).Text.ToString
            If MarketValuetxt.Text = "&nbsp;" Then
                MarketValuetxt.Text = grdMachineries.Rows(cnt).Cells(4).Text.Replace("&nbsp;", "")
            End If

            Dim ConditionText As TextBox
            ConditionText = CType(grdMachineries.Rows(cnt).FindControl("txtMachineCondition"), TextBox)
            ConditionText.Text = grdMachineries_Serial.Rows(cnt).Cells(6).Text.ToString
            If ConditionText.Text = "&nbsp;" Then
                ConditionText.Text = grdMachineries.Rows(cnt).Cells(5).Text.Replace("&nbsp;", "")
            End If

            Dim Locationtxt As TextBox
            Locationtxt = CType(grdMachineries.Rows(cnt).FindControl("txtMachineLoc"), TextBox)
            Locationtxt.Text = grdMachineries_Serial.Rows(cnt).Cells(7).Text.ToString
            If Locationtxt.Text = "&nbsp;" Then
                Locationtxt.Text = grdMachineries.Rows(cnt).Cells(6).Text.Replace("&nbsp;", "")
            End If

            Dim lbl As Label
            lbl = CType(grdMachineries.Rows(cnt).FindControl("lblMach"), Label)
            lbl.Text = grdMachineries_Serial.Rows(cnt).Cells(9).Text.ToString
            If lbl.Text = "&nbsp;" Then
                lbl.Text = grdMachineries.Rows(cnt).Cells(9).Text.Replace("&nbsp;", "")
            End If

        Next

        grdMachineries.Columns(9).Visible = False

        LoadClearMachinetext()
        LoadDisableMachineText()

        btninspectedsave.Enabled = False
        LoadButtonDisable()
        btnSaveSerialMac.Visible = False
        btnEditMachine.Visible = False
        btnUpdateMac.Visible = True
        btnCancelMac.Visible = True
    End Sub
    Protected Sub btnCancelMac_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnCancelMac.Visible = False
        LoadMachineSerial()
    End Sub

    Protected Sub LoadMachineInfoSave()
        dtMachineInfo = objMachineInfo.GetDataTable("select MachineryInfoId from AMS.TbMachinery_Information where AIRDtl_ID like '" & AIRDtl_ID & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
        With objMachineInfo
            '  .MachineryInfoId = MachineryInfoId
            .AIRDtl_ID = AIRDtl_ID
            ' .IsAccepted = ""
            .Property_Dtl_ID = PropertyDetai_ID
            .SerialNo = grdMachineries_Serial.SelectedDataKey("SerialNo")
            .BrandModel = txtMachiniriesBrandmodel.Text
            .MachineDesc = txtMachiniriesDesc.Text
            .MachineLocation = txtMachiniriesLocation.Text
            .NoPassengers = txtMachiniriesNoofPassengers.Text
            .ServiceFloors = txtMachiniriesServiceFloor.Text
            .MachineUnitNo = txtMachiniriesUnitNo.Text
            .WorkingLoad = txtMachiniriesWorkingLoad.Text
            .RatedSpeed = txtMachiniriesRatedSpeed.Text
            .CarDimensions = txtMachiniriescardimension.Text
            .DepreciationRate = txtMachiniriesDeprecitedRate.Text
            .DepreciationValue = txtMachiniriesDepreciatedValue.Text
            .MechinePermitNo = txtMachiniriesMechpermitno.Text
            If txtMachiniriesDatetoOperate.Text = "" Then
                .DateOperate = Date.Today.ToString("MM/dd/yyyy")
            Else
                .DateOperate = txtMachiniriesDatetoOperate.Text
            End If

            If txtMachiniriesDateissued.Text = "" Then
                .DateIssued = Date.Today.ToString("MM/dd/yyyy")
            Else
                .DateIssued = txtMachiniriesDateissued.Text
            End If

            If txtMachiniriesDateInspected.Text = "" Then
                .DateInspected = Date.Today.ToString("MM/dd/yyyy")
            Else
                .DateInspected = txtMachiniriesDateInspected.Text
            End If

            .InspectedBy = txtMachiniriesInspectedBy.Text
            .Remarks = txtMachiniriesRemarks.Text
            'objMachineInfo.DateTaken = ""
            'objMachineInfo.UploadedBy = ""
        End With

        If dtMachineInfo.Rows.Count = 0 Then
            objMachineInfo.MachineryInfoId = 0
            objMachineInfo.save()
            MachineryInfoId = objMachineInfo.GetValue("Select max(MachineryInfoId) from AMS.TbMachinery_Information ", CommandType.Text)
        Else
            MachineryInfoId = objMachineInfo.GetValue("Select MachineryInfoId from AMS.TbMachinery_Information where AIRDtl_ID like '" & AIRDtl_ID & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            objMachineInfo.MachineryInfoId = MachineryInfoId
            objMachineInfo.update()
        End If
    End Sub
    Protected Sub LoadMachineDtlSave()
        dtMachineDtl = objMachineDtl.GetDataTable("select MachineryId from AMS.TbMachinery_Dtl where MachineryInfoId = '" & MachineryInfoId & "' ", CommandType.Text)
        With objMachineDtl
            '.MachineryId = MachineryId
            .MachineryInfoId = MachineryInfoId
            .Property_Dtl_ID = PropertyDetai_ID
            .MarketValue = grdMachineries_Serial.SelectedDataKey("MarketValue")
            .Condition = grdMachineries_Serial.SelectedDataKey("Condition")
            .Location = grdMachineries_Serial.SelectedDataKey("Location")
            .Status = objDerived.GetValue("Select Status from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
        End With

        If dtMachineDtl.Rows.Count = 0 Then
            objMachineDtl.MachineryId = 0
            objMachineDtl.save()
            EquipmentId = objMachineDtl.GetValue("Select max(MachineryId) from AMS.TbMachinery_Dtl ", CommandType.Text)
        Else
            MachineryId = objMachineDtl.GetValue("Select MachineryId from AMS.TbMachinery_Dtl where MachineryInfoId = '" & MachineryInfoId & "' ", CommandType.Text)
            objMachineDtl.MachineryId = MachineryId
            objMachineDtl.update()
        End If
        loadBarcode()
        LoadMachineSerial()
    End Sub

    Protected Sub grdMachineries_Serial_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdMachineries_Serial, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdMachineries_Serial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadMachineryInfo()
    End Sub
    Protected Sub LoadClearMachinetext()
        txtMachiniriesBrandmodel.Text = ""
        txtMachiniriesDesc.Text = ""
        txtMachiniriesLocation.Text = ""
        txtMachiniriesNoofPassengers.Text = ""
        txtMachiniriesServiceFloor.Text = ""
        txtMachiniriesDeprecitedRate.Text = ""
        txtMachiniriesUnitNo.Text = ""
        txtMachiniriesWorkingLoad.Text = ""
        txtMachiniriesRatedSpeed.Text = ""
        txtMachiniriescardimension.Text = ""
        txtMachiniriesDepreciatedValue.Text = ""
        txtMachiniriesMechpermitno.Text = ""
        txtMachiniriesDatetoOperate.Text = ""
        txtMachiniriesDateissued.Text = ""
        txtMachiniriesDateInspected.Text = ""
        txtMachiniriesInspectedBy.Text = ""
        txtMachiniriesRemarks.Text = ""
    End Sub
    Protected Sub LoadEnableMachinetext()
        txtMachiniriesBrandmodel.Enabled = True
        txtMachiniriesDesc.Enabled = True
        txtMachiniriesLocation.Enabled = True
        txtMachiniriesNoofPassengers.Enabled = True
        txtMachiniriesServiceFloor.Enabled = True
        txtMachiniriesDeprecitedRate.Enabled = True
        txtMachiniriesUnitNo.Enabled = True
        txtMachiniriesWorkingLoad.Enabled = True
        txtMachiniriesRatedSpeed.Enabled = True
        txtMachiniriescardimension.Enabled = True
        txtMachiniriesDepreciatedValue.Enabled = True
        txtMachiniriesMechpermitno.Enabled = True
        txtMachiniriesDatetoOperate.Enabled = True
        txtMachiniriesDateissued.Enabled = True
        txtMachiniriesDateInspected.Enabled = True
        txtMachiniriesInspectedBy.Enabled = True
        txtMachiniriesRemarks.Enabled = True
    End Sub
    Protected Sub LoadDisableMachineText()
        txtMachiniriesBrandmodel.Enabled = False
        txtMachiniriesDesc.Enabled = False
        txtMachiniriesLocation.Enabled = False
        txtMachiniriesNoofPassengers.Enabled = False
        txtMachiniriesServiceFloor.Enabled = False
        txtMachiniriesDeprecitedRate.Enabled = False
        txtMachiniriesUnitNo.Enabled = False
        txtMachiniriesWorkingLoad.Enabled = False
        txtMachiniriesRatedSpeed.Enabled = False
        txtMachiniriescardimension.Enabled = False
        txtMachiniriesDepreciatedValue.Enabled = False
        txtMachiniriesMechpermitno.Enabled = False
        txtMachiniriesDatetoOperate.Enabled = False
        txtMachiniriesDateissued.Enabled = False
        txtMachiniriesDateInspected.Enabled = False
        txtMachiniriesInspectedBy.Enabled = False
        txtMachiniriesRemarks.Enabled = False
    End Sub

    'MOTOR INSPECTION AND ACCEPTANCE 
    Protected Sub LoadMotorGoods()
        Dim dtMotor As New DataTable
        dtMotor = objDerived.GetDataTable("Select * from AMS.TbPropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtMotor.Rows.Count = 0 Then
            LoadMotor()
        Else
            LoadMotorSerial()
        End If
    End Sub
    Protected Sub LoadMotor()
        grdMotor.Visible = True
        grdMotor_Serial.Visible = False
        Me.mvAttachments.Visible = False

        LoadAIRnum()

        Dim dtMotors As New DataTable
        dtMotors = objDerived.GetDataTable("exec dbo.load_goods_for_serial  '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtMotors.Rows.Count < 8 Then
            dtMotors.Merge(createdatatableGoods(7 - dtMotors.Rows.Count))
        End If
        grdMotor.DataSource = dtMotors
        grdMotor.DataBind()

        txtsupplier.Text = IIf(IsDBNull(dtMotors.Rows(0)("SuppName").ToString), 0, (dtMotors.Rows(0)("SuppName").ToString))
        txtPOnum.Text = IIf(IsDBNull(dtMotors.Rows(0)("PO_No").ToString), 0, (dtMotors.Rows(0)("PO_No").ToString))
        txtpoDate.Text = IIf(IsDBNull(dtMotors.Rows(0)("DatePurchased").ToString), 0, (dtMotors.Rows(0)("DatePurchased").ToString))
        txtdepartment.Text = dtMotors.Rows(0).Item("RespCenter").ToString
        rbStatus.SelectedValue = 0

        LoadClearMotorText()
        LoadDisableMotorText()

        btninspectedsave.Enabled = False
        btnAccptUpdate.Visible = False
        LoadButtonDisable()

        btnSaveMotor.Visible = True
        btnUpdateMotor.Visible = False
        btnEditMotor.Visible = False
    End Sub
    Protected Sub LoadMotorSerial()
        grdMotor.Visible = False
        grdMotor_Serial.Visible = True
        Me.mvAttachments.Visible = True

        grdMotor_Serial.Columns(9).Visible = True

        Dim dtMotorSerial As New DataTable
        dtMotorSerial = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtMotorSerial.Rows.Count = 0 Then
            grdMotor_Serial.DataSource = createdatatableGoods2(8)
            grdMotor_Serial.DataBind()

            Session("trans") = 1
        Else
            If dtMotorSerial.Rows.Count < 8 Then
                dtMotorSerial.Merge(createdatatableGoods2(7 - dtMotorSerial.Rows.Count))
            End If
            grdMotor_Serial.DataSource = dtMotorSerial
            grdMotor_Serial.DataBind()
            grdMotor_Serial.SelectedIndex = 0

            Session("trans") = 0
            rbStatus.Enabled = False
        End If

        grdMotor_Serial.Columns(9).Visible = False

        LoadAIRnum()

        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            txtsupplier.Text = IIf(IsDBNull(dtMotorSerial.Rows(0)("SuppName").ToString), 0, (dtMotorSerial.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dtMotorSerial.Rows(0)("PO_No").ToString), 0, (dtMotorSerial.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dtMotorSerial.Rows(0)("DatePurchased").ToString), 0, (dtMotorSerial.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = dtMotorSerial.Rows(0).Item("RespCenter").ToString
            rbStatus.SelectedValue = 0
            btnEditMotor.Enabled = True
        Else
            txtInvoiceDate.ReadOnly = True
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from [dbo].[View_Inspected] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            txtsupplier.Text = IIf(IsDBNull(dt.Rows(0)("SuppName").ToString), 0, (dt.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dt.Rows(0)("PO_No").ToString), 0, (dt.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dt.Rows(0)("DatePurchased").ToString), 0, (dt.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = dtMotorSerial.Rows(0).Item("RespCenter").ToString
            lblairno.Text = IIf(IsDBNull(dt.Rows(0)("AIR_No").ToString), 0, (dt.Rows(0)("AIR_No").ToString))
            txtInvoiceDate.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_date").ToString), 0, (dt.Rows(0)("Invoice_date").ToString))
            txtinvoiceNo.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_No").ToString), 0, (dt.Rows(0)("Invoice_No").ToString))
            txtremaks.Text = IIf(IsDBNull(dt.Rows(0)("remarks").ToString), 0, (dt.Rows(0)("remarks").ToString))
            txtInspectedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Inspect").ToString), 0, (dt.Rows(0)("Date_Inspect").ToString))
            ddinspector1.Text = IIf(IsDBNull(dt.Rows(0)("Signatory1").ToString), 0, (dt.Rows(0)("Signatory1").ToString))
            ddinspector2.Text = IIf(IsDBNull(dt.Rows(0)("Signatory2").ToString), 0, (dt.Rows(0)("Signatory2").ToString))
            txtAcceptedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Received").ToString), 0, (dt.Rows(0)("Date_Received").ToString))

            If dt.Rows(0)("Signatory3").ToString = "" Then
                ddacceptance.DataSource = objDerived.GetDataTable("Select 'Select' as full_name, 1 as rowno union SELECT full_name  as full_name,empid " & _
                                                                  "from [dbo].[view_signatory1] where deptid = 7 and division_key = 86 order BY rowno", CommandType.Text)
                ddacceptance.DataBind()
                ddacceptance.DataTextField = ("full_name")
            Else
                ddacceptance.Text = IIf(IsDBNull(dt.Rows(0)("Signatory3").ToString), 0, (dt.Rows(0)("Signatory3").ToString))
                ddacceptance.Enabled = False
            End If

            If dt.Rows(0)(16) = True Then
                rbStatus.SelectedValue = 1
                btnacceptancepreview.Enabled = True
            Else
                rbStatus.SelectedValue = 0
                btnacceptancepreview.Enabled = False
            End If

            Session("AIRHdr_ID") = dt.Rows(0)("AIRHdr_ID").ToString
            Session("POHdr_ID") = grdInspection.SelectedDataKey("POHdr_ID")

            txtInspectedDate.Enabled = False
            ddinspector1.Enabled = False
            ddinspector2.Enabled = False

            btninspectedsave.Enabled = True
            LoadButtonEnable()
            btnInspectedPreview.Enabled = True
            btnEditMotor.Enabled = False

        End If

        btnacceptancesave.Visible = True
        btnAccptUpdate.Visible = False


        Dim i As Integer
        For i = 0 To grdMotor_Serial.Rows.Count - 1
            If grdMotor_Serial.Rows(i).Cells(8).Text = "Inspected" Then
                grdMotor_Serial.Rows(i).Cells(0).Enabled = True
            Else
                grdMotor_Serial.Rows(i).Cells(0).Enabled = False
            End If
        Next

        btnSaveMotor.Visible = False
        btnUpdateMotor.Visible = False
        btnEditMotor.Visible = True
        btnEditMotor.Enabled = True

        If Session("trans") = 1 Then
            rbStatus.Enabled = True
            btnacceptancepreview.Enabled = True
            btnInspectedPreview.Enabled = False

            btninspectedsave.Enabled = False
            btnAccptUpdate.Visible = True
            btnAccptUpdate.Enabled = True

            btnacceptancesave.Visible = False
            btnEditMotor.Enabled = False
        Else
            If tbleTranspo.Visible = True Then
                LoadMotorInfo()
            ElseIf tblambulance.Visible = True Then
                LoadAmbulanceDTL()
            End If
        End If
    End Sub
    Protected Sub LoadMotorInfo()
        Dim dtSerial As New DataTable
        dtSerial = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where Item_Serial_ID = '" & grdMotor_Serial.SelectedDataKey("Item_Serial_ID") & "'", CommandType.Text)
        If dtSerial.Rows.Count = 0 Then
            PropNo.Text = ""
            LoadClearMotorText()
            LoadDisableMotorText()
            LoadButtonDisable()
            btninspectedsave.Enabled = False
            btnacceptancesave.Visible = True
            btnAccptUpdate.Visible = False

        ElseIf grdMotor_Serial.SelectedDataKey("SerialNo") = "" Or grdMotor_Serial.SelectedDataKey("SerialNo") = Nothing Then
            PropNo.Text = ""
            LoadClearMotorText()
            LoadDisableMotorText()
            LoadButtonDisable()
            btninspectedsave.Enabled = False
            btnacceptancesave.Visible = True
            btnAccptUpdate.Visible = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Plate Number is required.")

        Else
            btninspectedsave.Enabled = True
            LoadEnableMotorText()

            Dim dtMotorInfo As New DataTable
            dtMotorInfo = objDerived.GetDataTable("Select * from [dbo].[View_AIR_MotorInfo] where Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "' and PlateNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            If dtMotorInfo.Rows.Count = 0 Then
                PropNo.Text = ""
                LoadClearMotorText()
                LoadButtonDisable()
                btnacceptancesave.Visible = True
                btnAccptUpdate.Visible = False
                txtMotorVehiclePalte.Text = grdMotor_Serial.SelectedDataKey("SerialNo")

            Else
                Dim MotorAccpt As New DataTable
                MotorAccpt = objDerived.GetDataTable("Select * from [dbo].[View_GetPropertyNoMotor] where Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "' and PlateNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                If MotorAccpt.Rows.Count = 0 Then
                    txtMotorVehicleName.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("Name").ToString), 0, (dtMotorInfo.Rows(0)("Name").ToString))
                    txtMotorVehiclePalte.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("PlateNo").ToString), 0, (dtMotorInfo.Rows(0)("PlateNo").ToString))
                    txtMotorVehicleMotorNo.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("MotorNo").ToString), 0, (dtMotorInfo.Rows(0)("MotorNo").ToString))
                    txtMotorVehicleModel.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("Model").ToString), 0, (dtMotorInfo.Rows(0)("Model").ToString))
                    txtMotorVehicleChasisno.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("ChasisNo").ToString), 0, (dtMotorInfo.Rows(0)("ChasisNo").ToString))
                    txtMotorVehicleColor.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("VehicleColor").ToString), 0, (dtMotorInfo.Rows(0)("VehicleColor").ToString))
                    txtMotorVehicleCapacity.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("WheelsCapacity").ToString), 0, (dtMotorInfo.Rows(0)("WheelsCapacity").ToString))
                    txtMotorVehicleGrossWeight.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("GrossWeight").ToString), 0, (dtMotorInfo.Rows(0)("GrossWeight").ToString))
                    txtMotorVehicleSeat.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("Seats").ToString), 0, (dtMotorInfo.Rows(0)("Seats").ToString))
                    txtMotorVehicleWarranty.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("Warranty").ToString), 0, (dtMotorInfo.Rows(0)("Warranty").ToString))
                    txtMotorVehicleSpecification.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("VehicleSpecification").ToString), 0, (dtMotorInfo.Rows(0)("VehicleSpecification").ToString))
                    txtMotorVehicleOwner.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("VehicleOwner").ToString), 0, (dtMotorInfo.Rows(0)("VehicleOwner").ToString))
                    txtMotorVehicleDeclaredname.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("DeclaredName").ToString), 0, (dtMotorInfo.Rows(0)("DeclaredName").ToString))
                    txtMotorVehicleBeneficialUser.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("BeneficialUser").ToString), 0, (dtMotorInfo.Rows(0)("BeneficialUser").ToString))
                    PropNo.Text = ""
                    LoadButtonEnable()
                    LoadButtonEnable2()
                    btnacceptancesave.Visible = True
                    btnAccptUpdate.Visible = False
                Else
                    txtMotorVehicleName.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("Name").ToString), 0, (MotorAccpt.Rows(0)("Name").ToString))
                    txtMotorVehiclePalte.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("PlateNo").ToString), 0, (MotorAccpt.Rows(0)("PlateNo").ToString))
                    txtMotorVehicleMotorNo.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("MotorNo").ToString), 0, (MotorAccpt.Rows(0)("MotorNo").ToString))
                    txtMotorVehicleModel.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("Model").ToString), 0, (MotorAccpt.Rows(0)("Model").ToString))
                    txtMotorVehicleChasisno.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("ChasisNo").ToString), 0, (MotorAccpt.Rows(0)("ChasisNo").ToString))
                    txtMotorVehicleColor.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("VehicleColor").ToString), 0, (MotorAccpt.Rows(0)("VehicleColor").ToString))
                    txtMotorVehicleCapacity.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("WheelsCapacity").ToString), 0, (MotorAccpt.Rows(0)("WheelsCapacity").ToString))
                    txtMotorVehicleGrossWeight.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("GrossWeight").ToString), 0, (MotorAccpt.Rows(0)("GrossWeight").ToString))
                    txtMotorVehicleSeat.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("Seats").ToString), 0, (MotorAccpt.Rows(0)("Seats").ToString))
                    txtMotorVehicleWarranty.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("Warranty").ToString), 0, (MotorAccpt.Rows(0)("Warranty").ToString))
                    txtMotorVehicleSpecification.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("VehicleSpecification").ToString), 0, (MotorAccpt.Rows(0)("VehicleSpecification").ToString))
                    txtMotorVehicleOwner.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("VehicleOwner").ToString), 0, (MotorAccpt.Rows(0)("VehicleOwner").ToString))
                    txtMotorVehicleDeclaredname.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("DeclaredName").ToString), 0, (MotorAccpt.Rows(0)("DeclaredName").ToString))
                    txtMotorVehicleBeneficialUser.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("BeneficialUser").ToString), 0, (MotorAccpt.Rows(0)("BeneficialUser").ToString))
                    PropNo.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("PropertyNo").ToString), 0, (MotorAccpt.Rows(0)("PropertyNo").ToString))

                    LoadButtonEnable()
                    LoadButtonEnable2()

                    If MotorAccpt.Rows(0)("Status").ToString = "Inspected" Then
                        btninspectedsave.Enabled = True
                        btnInspectedPreview.Enabled = True
                        btnacceptancesave.Visible = True
                        btnAccptUpdate.Visible = False
                        btnacceptancepreview.Enabled = False
                        txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")

                    ElseIf MotorAccpt.Rows(0)("Status").ToString = "Accepted" Then
                        ddacceptance.Enabled = False
                        btninspectedsave.Enabled = False
                        btnInspectUpdate.Enabled = False
                        btnInspectedPreview.Enabled = False
                        btnacceptancesave.Visible = False
                        btnAccptUpdate.Visible = True
                        btnacceptancepreview.Enabled = True

                        LoadIFCompleted()
                    End If
                End If
            End If
        End If
        LoadAttchDoc()
    End Sub

    Protected Sub btnSaveMotor_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSaveMotor.OnClientClick = "StartProgressBar();"

        Dim cnt As Integer
        For cnt = 0 To grdMotor.Rows.Count - 1
            With objPropSerial
                Dim hasAmount As Boolean = False
                .POHdr_ID = Session("POHdr_ID") 'objDerived.GetValue("Select POHdr_ID from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .Qty = 1

                If grdMotor.Rows(cnt).Cells(7).Text = "&nbsp;" Then
                    grdMotor.Rows(cnt).Cells(7).Text = grdMotor.Rows(cnt).Cells(7).Text.Replace("&nbsp;", "")
                End If

                .Status = grdMotor.Rows(cnt).Cells(7).Text

                If CType(grdMotor.Rows(cnt).FindControl("lblItemID"), Label).Text = "" Then
                    Exit For
                Else
                    .Item_ID = CType(grdMotor.Rows(cnt).FindControl("lblItemID"), Label).Text
                End If

                Dim txtSerial As TextBox
                txtSerial = CType(grdMotor.Rows(cnt).FindControl("txtMotorPlateNo"), TextBox)
                .SerialNo = CType(txtSerial.Text, String)

                Dim txtCondition As TextBox
                txtCondition = CType(grdMotor.Rows(cnt).FindControl("txtMotorCondition"), TextBox)
                .Condition = CType(txtCondition.Text, String)

                Dim txtMarketValue As TextBox
                txtMarketValue = CType(grdMotor.Rows(cnt).FindControl("txtMotorMV"), TextBox)
                '.MarketValue = CType(txtMarketValue.Text, String)
                If CType(txtMarketValue.Text, String) = "" Then
                    .MarketValue = "0.00"
                Else
                    .MarketValue = CType(txtMarketValue.Text, String)
                End If

                Dim txtLocation As TextBox
                txtLocation = CType(grdMotor.Rows(cnt).FindControl("txtMotorLoc"), TextBox)
                .Location = CType(txtLocation.Text, String)

                objPropSerial.Item_Serial_ID = 0
                objPropSerial.save()
                Item_Serial_ID = objPropSerial.GetValue("Select max(Item_Serial_ID) from AMS.TbPropertySerial ", CommandType.Text)

            End With
        Next
        btnCancelMotor.Visible = False
        LoadMotorSerial()
    End Sub
    Protected Sub btnUpdateMotor_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnUpdateMotor.OnClientClick = "StartProgressBar();"

        grdMotor.Columns(9).Visible = True

        Dim cnt As Integer
        For cnt = 0 To grdMotor.Rows.Count - 1
            With objPropSerial
                Dim hasAmount As Boolean = False
                .POHdr_ID = objDerived.GetValue("Select POHdr_ID from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .Qty = 1


                If CType(grdMotor.Rows(cnt).FindControl("lblItemID"), Label).Text = "" Then
                    Exit For
                Else
                    .Item_ID = CType(grdMotor.Rows(cnt).FindControl("lblItemID"), Label).Text
                End If

                Dim txtSerial As TextBox
                txtSerial = CType(grdMotor.Rows(cnt).FindControl("txtMotorPlateNo"), TextBox)
                .SerialNo = CType(txtSerial.Text, String)


                Dim lbl As Label
                lbl = CType(grdMotor.Rows(cnt).FindControl("lblTrans"), Label)
                .Property_Dtl_ID = lbl.Text

                If grdMotor.Rows(cnt).Cells(7).Text = "&nbsp;" Then
                    grdMotor.Rows(cnt).Cells(7).Text = grdMotor.Rows(cnt).Cells(7).Text.Replace("&nbsp;", "")
                ElseIf grdMotor.Rows(cnt).Cells(7).Text = "Inspected" Then
                    objDerived.GetRecords("Update AMS.Property_Dtl set Barcode ='" & CType(txtSerial.Text, String) & "', SerialNo = '" & CType(txtSerial.Text, String) & "' where PropertyDetai_ID ='" & lbl.Text & "'", CommandType.Text)

                    If grdInspection.SelectedDataKey(0) = 580 Then
                        objDerived.GetRecords("Update AMS.TbAmbulance_Info set PlateNo ='" & CType(txtSerial.Text, String) & "' where Property_Dtl_ID ='" & lbl.Text & "'", CommandType.Text)
                    Else
                        objDerived.GetRecords("Update AMS.TbMotor_Info set PlateNo ='" & CType(txtSerial.Text, String) & "' where Property_Dtl_ID ='" & lbl.Text & "'", CommandType.Text)
                    End If
                End If
                .Status = grdMotor.Rows(cnt).Cells(7).Text

                Dim txtCondition As TextBox
                txtCondition = CType(grdMotor.Rows(cnt).FindControl("txtMotorCondition"), TextBox)
                .Condition = CType(txtCondition.Text, String)

                Dim txtMarketValue As TextBox
                txtMarketValue = CType(grdMotor.Rows(cnt).FindControl("txtMotorMV"), TextBox)
                '.MarketValue = CType(txtMarketValue.Text, String)
                If CType(txtMarketValue.Text, String) = "" Then
                    .MarketValue = "0.00"
                Else
                    .MarketValue = CType(txtMarketValue.Text, String)
                End If

                Dim txtLocation As TextBox
                txtLocation = CType(grdMotor.Rows(cnt).FindControl("txtMotorLoc"), TextBox)
                .Location = CType(txtLocation.Text, String)

                objPropSerial.Item_Serial_ID = grdMotor_Serial.DataKeys(cnt).Item("Item_Serial_ID").ToString 'Item_Serial_ID
                objPropSerial.update()
            End With
        Next
        btnCancelMotor.Visible = False
        LoadMotorSerial()

    End Sub
    Protected Sub btnEditMotor_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        grdMotor.Visible = True
        grdMotor_Serial.Visible = False
        Me.mvAttachments.Visible = False

        grdMotor.Columns(9).Visible = True

        LoadAIRnum()

        Dim dtMotor As New DataTable
        dtMotor = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtMotor.Rows.Count < 4 Then
            dtMotor.Merge(createdatatableGoods2(3 - dtMotor.Rows.Count))
        End If
        grdMotor.DataSource = dtMotor
        grdMotor.DataBind()

        Dim cnt As Integer
        For cnt = 0 To grdMotor.Rows.Count - 1

            Dim hasAmount As Boolean = False
            Dim SerialText As TextBox
            SerialText = CType(grdMotor.Rows(cnt).FindControl("txtMotorPlateNo"), TextBox)
            SerialText.Text = grdMotor_Serial.Rows(cnt).Cells(2).Text.ToString
            If SerialText.Text = "&nbsp;" Then
                SerialText.Text = grdMotor.Rows(cnt).Cells(1).Text.Replace("&nbsp;", "")
            End If

            Dim MarketValuetxt As TextBox
            MarketValuetxt = CType(grdMotor.Rows(cnt).FindControl("txtMotorMV"), TextBox)
            MarketValuetxt.Text = grdMotor_Serial.Rows(cnt).Cells(5).Text.ToString
            If MarketValuetxt.Text = "&nbsp;" Then
                MarketValuetxt.Text = grdMotor.Rows(cnt).Cells(4).Text.Replace("&nbsp;", "")
            End If

            Dim ConditionText As TextBox
            ConditionText = CType(grdMotor.Rows(cnt).FindControl("txtMotorCondition"), TextBox)
            ConditionText.Text = grdMotor_Serial.Rows(cnt).Cells(6).Text.ToString
            If ConditionText.Text = "&nbsp;" Then
                ConditionText.Text = grdMotor.Rows(cnt).Cells(5).Text.Replace("&nbsp;", "")
            End If

            Dim Locationtxt As TextBox
            Locationtxt = CType(grdMotor.Rows(cnt).FindControl("txtMotorLoc"), TextBox)
            Locationtxt.Text = grdMotor_Serial.Rows(cnt).Cells(7).Text.ToString
            If Locationtxt.Text = "&nbsp;" Then
                Locationtxt.Text = grdMotor.Rows(cnt).Cells(6).Text.Replace("&nbsp;", "")
            End If

            Dim lbl As Label
            lbl = CType(grdMotor.Rows(cnt).FindControl("lblTrans"), Label)
            lbl.Text = grdMotor_Serial.Rows(cnt).Cells(9).Text.ToString
            If lbl.Text = "&nbsp;" Then
                lbl.Text = grdMotor.Rows(cnt).Cells(9).Text.Replace("&nbsp;", "")
            End If
        Next

        grdMotor.Columns(9).Visible = False

        LoadClearMotorText()
        LoadDisableMotorText()

        btninspectedsave.Enabled = False
        LoadButtonDisable()
        btnSaveMotor.Visible = False
        btnEditMotor.Visible = False
        btnUpdateMotor.Visible = True
        btnCancelMotor.Visible = True
    End Sub
    Protected Sub btnCancelMotor_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnCancelMotor.Visible = False
        LoadMotorSerial()
    End Sub

    Protected Sub LoadMotorInfoSave()
        dtMotorInfo = objMotorInfo.GetDataTable("select Motor_InfoId from AMS.TbMotor_Info where AIRDtl_ID like '" & AIRDtl_ID & "' and PlateNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
        With objMotorInfo
            '  .Motor_InfoId = Motor_InfoId
            .AIRDtl_ID = AIRDtl_ID
            ' .IsAccepted = ""
            .Property_Dtl_ID = PropertyDetai_ID
            .Name = txtMotorVehicleName.Text
            .PlateNo = txtMotorVehiclePalte.Text
            .MotorNo = txtMotorVehicleMotorNo.Text
            .Model = txtMotorVehicleModel.Text
            .ChasisNo = txtMotorVehicleChasisno.Text
            .VehicleColor = txtMotorVehicleColor.Text
            .WheelsCapacity = txtMotorVehicleCapacity.Text
            .GrossWeight = txtMotorVehicleGrossWeight.Text
            .Seats = txtMotorVehicleSeat.Text
            .Warranty = txtMotorVehicleWarranty.Text
            .VehicleOwner = txtMotorVehicleOwner.Text
            .DeclaredName = txtMotorVehicleDeclaredname.Text
            .BeneficialUser = txtMotorVehicleBeneficialUser.Text
            .VehicleSpecification = txtMotorVehicleSpecification.Text
        End With

        If dtMotorInfo.Rows.Count = 0 Then
            objMotorInfo.Motor_InfoId = 0
            objMotorInfo.save()
            Motor_InfoId = objMotorInfo.GetValue("Select max(Motor_InfoId) from AMS.TbMotor_Info ", CommandType.Text)
        Else
            Motor_InfoId = objMotorInfo.GetValue("Select Motor_InfoId from AMS.TbMotor_Info where AIRDtl_ID like '" & AIRDtl_ID & "' and PlateNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            objMotorInfo.Motor_InfoId = Motor_InfoId
            objMotorInfo.update()
        End If
    End Sub
    Protected Sub LoadMotorDtlSave()
        dtMotorDtl = objMotorDtl.GetDataTable("select MotorID from AMS.TbMotor_Dtl where Motor_InfoId like '" & Motor_InfoId & "' ", CommandType.Text)
        With objMotorDtl
            '.MotorID = MotorID
            .Motor_InfoId = Motor_InfoId
            .Property_Dtl_ID = PropertyDetai_ID
            .MarketValue = grdMotor_Serial.SelectedDataKey("MarketValue")
            .Condition = grdMotor_Serial.SelectedDataKey("Condition")
            .Location = grdMotor_Serial.SelectedDataKey("Location")
            .Status = objDerived.GetValue("Select Status from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
        End With

        If dtMotorDtl.Rows.Count = 0 Then
            objMotorDtl.MotorID = 0
            objMotorDtl.save()
            MotorID = objMotorDtl.GetValue("Select max(MotorID) from AMS.TbMotor_Dtl ", CommandType.Text)
        Else
            MotorID = objMotorDtl.GetValue("Select MotorID from AMS.TbMotor_Dtl where Motor_InfoId like '" & Motor_InfoId & "' ", CommandType.Text)
            objMotorDtl.MotorID = MotorID
            objMotorDtl.update()
        End If
        loadBarcode()
        LoadMotorSerial()
    End Sub

    Protected Sub grdMotor_Serial_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdMotor_Serial, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdMotor_Serial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If grdInspection.SelectedDataKey(0) = 580 Then
            LoadAmbulanceDTL()
        ElseIf grdInspection.SelectedDataKey(0) = 549 Then
            LoadMotorInfo()
        End If
    End Sub
    Protected Sub LoadClearMotorText()
        txtMotorVehicleName.Text = ""
        txtMotorVehiclePalte.Text = ""
        txtMotorVehicleMotorNo.Text = ""
        txtMotorVehicleModel.Text = ""
        txtMotorVehicleChasisno.Text = ""
        txtMotorVehicleColor.Text = ""
        txtMotorVehicleCapacity.Text = ""
        txtMotorVehicleGrossWeight.Text = ""
        txtMotorVehicleSeat.Text = ""
        txtMotorVehicleWarranty.Text = ""
        txtMotorVehicleSpecification.Text = ""
        txtMotorVehicleOwner.Text = ""
        txtMotorVehicleDeclaredname.Text = ""
        txtMotorVehicleBeneficialUser.Text = ""
    End Sub
    Protected Sub LoadEnableMotorText()
        txtMotorVehicleName.Enabled = True
        txtMotorVehiclePalte.Enabled = True
        txtMotorVehicleMotorNo.Enabled = True
        txtMotorVehicleModel.Enabled = True
        txtMotorVehicleChasisno.Enabled = True
        txtMotorVehicleColor.Enabled = True
        txtMotorVehicleCapacity.Enabled = True
        txtMotorVehicleGrossWeight.Enabled = True
        txtMotorVehicleSeat.Enabled = True
        txtMotorVehicleWarranty.Enabled = True
        txtMotorVehicleSpecification.Enabled = True
        txtMotorVehicleOwner.Enabled = True
        txtMotorVehicleDeclaredname.Enabled = True
        txtMotorVehicleBeneficialUser.Enabled = True
    End Sub
    Protected Sub LoadDisableMotorText()
        txtMotorVehicleName.Enabled = False
        txtMotorVehiclePalte.Enabled = False
        txtMotorVehicleMotorNo.Enabled = False
        txtMotorVehicleModel.Enabled = False
        txtMotorVehicleChasisno.Enabled = False
        txtMotorVehicleColor.Enabled = False
        txtMotorVehicleCapacity.Enabled = False
        txtMotorVehicleGrossWeight.Enabled = False
        txtMotorVehicleSeat.Enabled = False
        txtMotorVehicleWarranty.Enabled = False
        txtMotorVehicleSpecification.Enabled = False
        txtMotorVehicleOwner.Enabled = False
        txtMotorVehicleDeclaredname.Enabled = False
        txtMotorVehicleBeneficialUser.Enabled = False
    End Sub
    Protected Sub LoadClearAmbulanceTEXT()
        txtAmbulanceLoc.Text = ""
        txtAmbulanceBrand.Text = ""
        txtAmbulanceModel.Text = ""
        txtAmbulanceSeat.Text = ""
        txtAmbulanceColor.Text = ""
        txtAmbulanceEquip.Text = ""
        txtAmbulancePlate.Text = ""
        txtAmbulanceArea.Text = ""
    End Sub
    Protected Sub LoadEnableAmbulanceTEXT()
        txtAmbulanceLoc.Enabled = True
        txtAmbulanceBrand.Enabled = True
        txtAmbulanceModel.Enabled = True
        txtAmbulanceSeat.Enabled = True
        txtAmbulanceColor.Enabled = True
        txtAmbulanceEquip.Enabled = True
        txtAmbulancePlate.Enabled = True
        txtAmbulanceArea.Enabled = True
    End Sub
    Protected Sub LoadDisableAmbulanceTEXT()
        txtAmbulanceLoc.Enabled = False
        txtAmbulanceBrand.Enabled = False
        txtAmbulanceModel.Enabled = False
        txtAmbulanceSeat.Enabled = False
        txtAmbulanceColor.Enabled = False
        txtAmbulanceEquip.Enabled = False
        txtAmbulancePlate.Enabled = False
        txtAmbulanceArea.Enabled = False
    End Sub

    'FURNITURE INSPECTION AND ACCEPTANCE 
    Protected Sub LoadFurnitureGoods()
        Dim dtFurniture As New DataTable
        dtFurniture = objDerived.GetDataTable("Select * from AMS.TbPropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtFurniture.Rows.Count = 0 Then
            LoadFurniture()
        Else
            LoadFurnitureSerial()
        End If
    End Sub
    Protected Sub LoadFurniture()
        grdfurnitureandfixtures.Visible = True
        grdFurniture_Serial.Visible = False
        Me.mvAttachments.Visible = False

        LoadAIRnum()

        Dim dtFurniture As New DataTable
        dtFurniture = objDerived.GetDataTable("Exec dbo.load_goods_for_serial  '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtFurniture.Rows.Count < 8 Then
            dtFurniture.Merge(createdatatableGoods(7 - dtFurniture.Rows.Count))
        End If
        grdfurnitureandfixtures.DataSource = dtFurniture
        grdfurnitureandfixtures.DataBind()

        txtsupplier.Text = IIf(IsDBNull(dtFurniture.Rows(0)("SuppName").ToString), 0, (dtFurniture.Rows(0)("SuppName").ToString))
        txtPOnum.Text = IIf(IsDBNull(dtFurniture.Rows(0)("PO_No").ToString), 0, (dtFurniture.Rows(0)("PO_No").ToString))
        txtpoDate.Text = IIf(IsDBNull(dtFurniture.Rows(0)("DatePurchased").ToString), 0, (dtFurniture.Rows(0)("DatePurchased").ToString))
        txtdepartment.Text = dtFurniture.Rows(0).Item("RespCenter").ToString
        rbStatus.SelectedValue = 0

        LoadFurnitureClearText()
        LoadDisableFurnitureText()

        btninspectedsave.Enabled = False
        btnAccptUpdate.Visible = False
        LoadButtonDisable()

        btnSaveFurn.Visible = True
        btnUpdateFurn.Visible = False
        btnEditFur.Visible = False
    End Sub
    Protected Sub LoadFurnitureSerial()
        grdfurnitureandfixtures.Visible = False
        grdFurniture_Serial.Visible = True
        Me.mvAttachments.Visible = True

        grdFurniture_Serial.Columns(9).Visible = True

        Dim dtFurnitureSerial As New DataTable
        dtFurnitureSerial = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        If dtFurnitureSerial.Rows.Count = 0 Then
            grdFurniture_Serial.DataSource = createdatatableGoods2(8)
            grdFurniture_Serial.DataBind()
            Session("fur") = 1
        Else
            If dtFurnitureSerial.Rows.Count < 8 Then
                dtFurnitureSerial.Merge(createdatatableGoods2(7 - dtFurnitureSerial.Rows.Count))
            End If
            grdFurniture_Serial.DataSource = dtFurnitureSerial
            grdFurniture_Serial.DataBind()
            grdFurniture_Serial.SelectedIndex = 0
            Session("fur") = 0
            rbStatus.Enabled = False
        End If

        grdFurniture_Serial.Columns(9).Visible = False

        LoadAIRnum()

        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            txtsupplier.Text = IIf(IsDBNull(dtFurnitureSerial.Rows(0)("SuppName").ToString), 0, (dtFurnitureSerial.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dtFurnitureSerial.Rows(0)("PO_No").ToString), 0, (dtFurnitureSerial.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dtFurnitureSerial.Rows(0)("DatePurchased").ToString), 0, (dtFurnitureSerial.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = dtFurnitureSerial.Rows(0).Item("RespCenter").ToString
            rbStatus.SelectedValue = 0
            btnEditFur.Enabled = True
        Else
            txtInvoiceDate.ReadOnly = True
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from [dbo].[View_Inspected] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            txtsupplier.Text = IIf(IsDBNull(dt.Rows(0)("SuppName").ToString), 0, (dt.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dt.Rows(0)("PO_No").ToString), 0, (dt.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dt.Rows(0)("DatePurchased").ToString), 0, (dt.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = IIf(IsDBNull(dt.Rows(0)("RespCenter").ToString), 0, (dt.Rows(0)("RespCenter").ToString))
            txtFurnitureDescription.Text = IIf(IsDBNull(dt.Rows(0)("Item_Desc").ToString), 0, (dt.Rows(0)("Item_Desc").ToString))
            lblairno.Text = IIf(IsDBNull(dt.Rows(0)("AIR_No").ToString), 0, (dt.Rows(0)("AIR_No").ToString))
            txtInvoiceDate.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_date").ToString), 0, (dt.Rows(0)("Invoice_date").ToString))
            txtinvoiceNo.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_No").ToString), 0, (dt.Rows(0)("Invoice_No").ToString))
            txtremaks.Text = IIf(IsDBNull(dt.Rows(0)("remarks").ToString), 0, (dt.Rows(0)("remarks").ToString))
            txtInspectedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Inspect").ToString), 0, (dt.Rows(0)("Date_Inspect").ToString))
            ddinspector1.Text = IIf(IsDBNull(dt.Rows(0)("Signatory1").ToString), 0, (dt.Rows(0)("Signatory1").ToString))
            ddinspector2.Text = IIf(IsDBNull(dt.Rows(0)("Signatory2").ToString), 0, (dt.Rows(0)("Signatory2").ToString))
            txtAcceptedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Received").ToString), 0, (dt.Rows(0)("Date_Received").ToString))

            If dt.Rows(0)("Signatory3").ToString = "" Then
                ddacceptance.DataSource = objDerived.GetDataTable("Select 'Select' as full_name, 1 as rowno union SELECT full_name  as full_name,empid " & _
                                                                  "from [dbo].[view_signatory1] where deptid = 7 and division_key = 86 order BY rowno", CommandType.Text)
                ddacceptance.DataBind()
                ddacceptance.DataTextField = ("full_name")
            Else
                ddacceptance.Text = IIf(IsDBNull(dt.Rows(0)("Signatory3").ToString), 0, (dt.Rows(0)("Signatory3").ToString))
                ddacceptance.Enabled = False
            End If

            If dt.Rows(0)(16) = True Then
                rbStatus.SelectedValue = 1
                btnacceptancepreview.Enabled = True
            Else
                rbStatus.SelectedValue = 0
                btnacceptancepreview.Enabled = False
            End If

            Session("AIRHdr_ID") = dt.Rows(0)("AIRHdr_ID").ToString
            Session("POHdr_ID") = grdInspection.SelectedDataKey("POHdr_ID")

            txtInspectedDate.Enabled = False
            ddinspector1.Enabled = False
            ddinspector2.Enabled = False

            btninspectedsave.Enabled = True
            LoadButtonEnable()
            btnInspectedPreview.Enabled = True
            btnEditFur.Enabled = False

        End If
        btnacceptancesave.Visible = True
        btnAccptUpdate.Visible = False



        Dim i As Integer
        For i = 0 To grdFurniture_Serial.Rows.Count - 1
            If grdFurniture_Serial.Rows(i).Cells(8).Text = "Inspected" Then
                grdFurniture_Serial.Rows(i).Cells(0).Enabled = True
            Else
                grdFurniture_Serial.Rows(i).Cells(0).Enabled = False
            End If
        Next

        btnSaveFurn.Visible = False
        btnUpdateFurn.Visible = False
        btnEditFur.Visible = True
        btnEditFur.Enabled = True

        If Session("fur") = 1 Then
            rbStatus.Enabled = True
            btnacceptancepreview.Enabled = True
            btnInspectedPreview.Enabled = False

            btninspectedsave.Enabled = False
            btnAccptUpdate.Visible = True
            btnAccptUpdate.Enabled = True

            btnacceptancesave.Visible = False
            btnEditFur.Enabled = False
        Else
            LoadFurnitureDetail()
        End If
    End Sub
    Protected Sub LoadFurnitureDetail()
        Dim x As Integer = grdFurniture_Serial.SelectedDataKey("Property_Dtl_ID")

        Dim dtSerial As New DataTable
        dtSerial = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where Item_Serial_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_Serial_ID") & "'", CommandType.Text)
        If dtSerial.Rows.Count = 0 Then
            PropNo.Text = ""
            LoadFurnitureClearText()
            LoadButtonDisable()
            LoadDisableFurnitureText()
            btninspectedsave.Enabled = False
            btnacceptancesave.Visible = True
            btnAccptUpdate.Visible = False

        ElseIf grdFurniture_Serial.SelectedDataKey("SerialNo") = "" Or grdFurniture_Serial.SelectedDataKey("SerialNo") = Nothing Then
            PropNo.Text = ""
            LoadFurnitureClearText()
            LoadDisableFurnitureText()
            LoadButtonDisable()
            btninspectedsave.Enabled = False
            btnacceptancesave.Visible = True
            btnAccptUpdate.Visible = False
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Serial Number is Required")

        Else
            btninspectedsave.Enabled = True
            LoadEnableFurnituretext()

            Dim dtFurnitureDtl As New DataTable
            dtFurnitureDtl = objDerived.GetDataTable("Select * from [dbo].[View_AIR_FurnitureInfo] where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            If dtFurnitureDtl.Rows.Count = 0 Then
                PropNo.Text = ""
                LoadFurnitureClearText()
                LoadButtonDisable()
                btnInspectedPreview.Enabled = False
                btnacceptancesave.Visible = True
                btnAccptUpdate.Visible = False
                txtFurnitureDescription.Text = objDerived.GetValue("Select Item_Desc from [dbo].[View_InspectionAcceptanceGoods] where PODtl_ID = '" & grdFurniture_Serial.SelectedDataKey("PODtl_ID") & "'", CommandType.Text)

            Else
                Dim dtFurnitureAccpt As New DataTable
                dtFurnitureAccpt = objDerived.GetDataTable("Select * from [dbo].[View_GetPropertyNoFurniture] where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                If dtFurnitureAccpt.Rows.Count = 0 Then
                    txtFurnitureName.Text = IIf(IsDBNull(dtFurnitureDtl.Rows(0)("Name").ToString), 0, (dtFurnitureDtl.Rows(0)("Name").ToString))
                    txtFurnitureDescription.Text = IIf(IsDBNull(dtFurnitureDtl.Rows(0)("Description").ToString), 0, (dtFurnitureDtl.Rows(0)("Description").ToString))
                    txtFurnitureDepreciatedRate.Text = IIf(IsDBNull(dtFurnitureDtl.Rows(0)("DepreciationRate").ToString), 0, (dtFurnitureDtl.Rows(0)("DepreciationRate").ToString))
                    txtFurnitureDimension.Text = IIf(IsDBNull(dtFurnitureDtl.Rows(0)("Dimension").ToString), 0, (dtFurnitureDtl.Rows(0)("Dimension").ToString))
                    txtFurnitureAreaCapacity.Text = IIf(IsDBNull(dtFurnitureDtl.Rows(0)("AreaCapacity").ToString), 0, (dtFurnitureDtl.Rows(0)("AreaCapacity").ToString))
                    txtFurnitureModel.Text = IIf(IsDBNull(dtFurnitureDtl.Rows(0)("Model").ToString), 0, (dtFurnitureDtl.Rows(0)("Model").ToString))
                    txtFurnitureWarranty.Text = IIf(IsDBNull(dtFurnitureDtl.Rows(0)("Warranty").ToString), 0, (dtFurnitureDtl.Rows(0)("Warranty").ToString))
                    txtFurnitureDepreciatedValue.Text = IIf(IsDBNull(dtFurnitureDtl.Rows(0)("DepreciationValue").ToString), 0, (dtFurnitureDtl.Rows(0)("DepreciationValue").ToString))
                    txtFurnitureSpecification.Text = IIf(IsDBNull(dtFurnitureDtl.Rows(0)("Specification").ToString), 0, (dtFurnitureDtl.Rows(0)("Specification").ToString))
                    PropNo.Text = ""
                    LoadButtonEnable()
                    LoadButtonEnable2()
                    btnacceptancesave.Visible = True
                    btnAccptUpdate.Visible = False
                Else
                    txtFurnitureName.Text = IIf(IsDBNull(dtFurnitureAccpt.Rows(0)("Name").ToString), 0, (dtFurnitureAccpt.Rows(0)("Name").ToString))
                    txtFurnitureDescription.Text = IIf(IsDBNull(dtFurnitureAccpt.Rows(0)("Description").ToString), 0, (dtFurnitureAccpt.Rows(0)("Description").ToString))
                    txtFurnitureDepreciatedRate.Text = IIf(IsDBNull(dtFurnitureAccpt.Rows(0)("DepreciationRate").ToString), 0, (dtFurnitureAccpt.Rows(0)("DepreciationRate").ToString))
                    txtFurnitureDimension.Text = IIf(IsDBNull(dtFurnitureAccpt.Rows(0)("Dimension").ToString), 0, (dtFurnitureAccpt.Rows(0)("Dimension").ToString))
                    txtFurnitureAreaCapacity.Text = IIf(IsDBNull(dtFurnitureAccpt.Rows(0)("AreaCapacity").ToString), 0, (dtFurnitureAccpt.Rows(0)("AreaCapacity").ToString))
                    txtFurnitureModel.Text = IIf(IsDBNull(dtFurnitureAccpt.Rows(0)("Model").ToString), 0, (dtFurnitureAccpt.Rows(0)("Model").ToString))
                    txtFurnitureWarranty.Text = IIf(IsDBNull(dtFurnitureAccpt.Rows(0)("Warranty").ToString), 0, (dtFurnitureAccpt.Rows(0)("Warranty").ToString))
                    txtFurnitureDepreciatedValue.Text = IIf(IsDBNull(dtFurnitureAccpt.Rows(0)("DepreciationValue").ToString), 0, (dtFurnitureAccpt.Rows(0)("DepreciationValue").ToString))
                    txtFurnitureSpecification.Text = IIf(IsDBNull(dtFurnitureAccpt.Rows(0)("Specification").ToString), 0, (dtFurnitureAccpt.Rows(0)("Specification").ToString))
                    PropNo.Text = IIf(IsDBNull(dtFurnitureAccpt.Rows(0)("PropertyNo").ToString), 0, (dtFurnitureAccpt.Rows(0)("PropertyNo").ToString))

                    LoadButtonEnable()
                    LoadButtonEnable2()

                    txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")
                    If dtFurnitureAccpt.Rows(0)("Status").ToString = "Inspected" Then
                        btnInspectedPreview.Enabled = True
                        btnacceptancesave.Visible = True
                        btnAccptUpdate.Visible = False
                        btnacceptancepreview.Enabled = False
                        txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")

                    ElseIf dtFurnitureAccpt.Rows(0)("Status").ToString = "Accepted" Then
                        ddacceptance.Enabled = False
                        btninspectedsave.Enabled = False
                        btnInspectUpdate.Enabled = False
                        btnInspectedPreview.Enabled = False
                        btnacceptancesave.Visible = False
                        btnAccptUpdate.Visible = True
                        btnacceptancepreview.Enabled = True

                        LoadIFCompleted()
                    End If

                End If
            End If
        End If
        LoadAttchDoc()
    End Sub

    Protected Sub btnSaveFurn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSaveFurn.OnClientClick = "StartProgressBar();"

        Dim cnt As Integer
        For cnt = 0 To grdfurnitureandfixtures.Rows.Count - 1
            With objPropSerial
                Dim hasAmount As Boolean = False
                .POHdr_ID = Session("POHdr_ID") 'objDerived.GetValue("Select POHdr_ID from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .Qty = 1

                If grdfurnitureandfixtures.Rows(cnt).Cells(7).Text = "&nbsp;" Then
                    grdfurnitureandfixtures.Rows(cnt).Cells(7).Text = grdfurnitureandfixtures.Rows(cnt).Cells(7).Text.Replace("&nbsp;", "")
                End If
                .Status = grdfurnitureandfixtures.Rows(cnt).Cells(7).Text


                If CType(grdfurnitureandfixtures.Rows(cnt).FindControl("lblItemID"), Label).Text = "" Then
                    Exit For
                Else
                    .Item_ID = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("lblItemID"), Label).Text
                End If

                Dim txtSerial As TextBox
                txtSerial = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureSerial"), TextBox)
                .SerialNo = CType(txtSerial.Text, String)

                Dim txtCondition As TextBox
                txtCondition = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureCondition"), TextBox)
                .Condition = CType(txtCondition.Text, String)

                Dim txtMarketValue As TextBox
                txtMarketValue = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureMV"), TextBox)
                '.MarketValue = CType(txtMarketValue.Text, String)
                If CType(txtMarketValue.Text, String) = "" Then
                    .MarketValue = "0.00"
                Else
                    .MarketValue = CType(txtMarketValue.Text, String)
                End If

                Dim txtLocation As TextBox
                txtLocation = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureLoc"), TextBox)
                .Location = CType(txtLocation.Text, String)

                objPropSerial.Item_Serial_ID = 0
                objPropSerial.save()
                Item_Serial_ID = objPropSerial.GetValue("Select max(Item_Serial_ID) from AMS.TbPropertySerial ", CommandType.Text)
            End With
        Next
        btnCancelFur.Visible = False
        LoadFurnitureSerial()
    End Sub
    Protected Sub btnUpdateFurn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnUpdateFurn.OnClientClick = "StartProgressBar();"

        grdfurnitureandfixtures.Columns(9).Visible = True

        Dim cnt As Integer
        For cnt = 0 To grdfurnitureandfixtures.Rows.Count - 1
            With objPropSerial
                Dim hasAmount As Boolean = False
                .POHdr_ID = objDerived.GetValue("Select POHdr_ID from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from View_InspectionAcceptanceGoods where PO_No like '" & txtPOnum.Text & "'", CommandType.Text)
                .Qty = 1

                If CType(grdfurnitureandfixtures.Rows(cnt).FindControl("lblItemID"), Label).Text = "" Then
                    Exit For
                Else
                    .Item_ID = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("lblItemID"), Label).Text
                End If

                Dim txtSerial As TextBox
                txtSerial = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureSerial"), TextBox)
                .SerialNo = CType(txtSerial.Text, String)

                If grdfurnitureandfixtures.Rows(cnt).Cells(7).Text = "&nbsp;" Then
                    grdfurnitureandfixtures.Rows(cnt).Cells(7).Text = grdfurnitureandfixtures.Rows(cnt).Cells(7).Text.Replace("&nbsp;", "")
                End If

                Dim lbl As Label
                lbl = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("lblPropertyDtl"), Label)
                .Property_Dtl_ID = lbl.Text

                If grdfurnitureandfixtures.Rows(cnt).Cells(7).Text = "Inspected" Then
                    objDerived.GetRecords("Update AMS.Property_Dtl set Barcode ='" & CType(txtSerial.Text, String) & "', SerialNo = '" & CType(txtSerial.Text, String) & "' where PropertyDetai_ID ='" & lbl.Text & "'", CommandType.Text)
                    objDerived.GetRecords("Update AMS.TbFurniture_Info set SerialNo ='" & CType(txtSerial.Text, String) & "' where Property_Dtl_ID ='" & lbl.Text & "'", CommandType.Text)
                End If
                .Status = grdfurnitureandfixtures.Rows(cnt).Cells(7).Text


                Dim txtCondition As TextBox
                txtCondition = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureCondition"), TextBox)
                .Condition = CType(txtCondition.Text, String)

                Dim txtMarketValue As TextBox
                txtMarketValue = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureMV"), TextBox)
                '.MarketValue = CType(txtMarketValue.Text, String)
                If CType(txtMarketValue.Text, String) = "" Then
                    .MarketValue = "0.00"
                Else
                    .MarketValue = CType(txtMarketValue.Text, String)
                End If

                Dim txtLocation As TextBox
                txtLocation = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureLoc"), TextBox)
                .Location = CType(txtLocation.Text, String)


                objPropSerial.Item_Serial_ID = grdFurniture_Serial.DataKeys(cnt).Item("Item_Serial_ID").ToString
                objPropSerial.update()
            End With
        Next
        btnCancelFur.Visible = False
        LoadFurnitureSerial()
    End Sub
    Protected Sub btnEditFur_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        grdfurnitureandfixtures.Visible = True
        grdFurniture_Serial.Visible = False
        Me.mvAttachments.Visible = False

        grdfurnitureandfixtures.Columns(9).Visible = True

        LoadAIRnum()

        Dim dtFurniture As New DataTable
        dtFurniture = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtFurniture.Rows.Count < 4 Then
            dtFurniture.Merge(createdatatableGoods2(3 - dtFurniture.Rows.Count))
        End If
        grdfurnitureandfixtures.DataSource = dtFurniture
        grdfurnitureandfixtures.DataBind()

        Dim cnt As Integer
        For cnt = 0 To grdfurnitureandfixtures.Rows.Count - 1

            Dim hasAmount As Boolean = False
            Dim SerialText As TextBox
            SerialText = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureSerial"), TextBox)
            SerialText.Text = grdFurniture_Serial.Rows(cnt).Cells(2).Text.ToString
            If SerialText.Text = "&nbsp;" Then
                SerialText.Text = grdfurnitureandfixtures.Rows(cnt).Cells(1).Text.Replace("&nbsp;", "")
            End If

            Dim MarketValuetxt As TextBox
            MarketValuetxt = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureMV"), TextBox)
            MarketValuetxt.Text = grdFurniture_Serial.Rows(cnt).Cells(5).Text.ToString
            If MarketValuetxt.Text = "&nbsp;" Then
                MarketValuetxt.Text = grdfurnitureandfixtures.Rows(cnt).Cells(4).Text.Replace("&nbsp;", "")
            End If

            Dim ConditionText As TextBox
            ConditionText = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureCondition"), TextBox)
            ConditionText.Text = grdFurniture_Serial.Rows(cnt).Cells(6).Text.ToString
            If ConditionText.Text = "&nbsp;" Then
                ConditionText.Text = grdfurnitureandfixtures.Rows(cnt).Cells(5).Text.Replace("&nbsp;", "")
            End If

            Dim Locationtxt As TextBox
            Locationtxt = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("txtFurnitureLoc"), TextBox)
            Locationtxt.Text = grdFurniture_Serial.Rows(cnt).Cells(7).Text.ToString
            If Locationtxt.Text = "&nbsp;" Then
                Locationtxt.Text = grdfurnitureandfixtures.Rows(cnt).Cells(6).Text.Replace("&nbsp;", "")
            End If
            ''lblPropertyDtl

            Dim lbl As Label
            lbl = CType(grdfurnitureandfixtures.Rows(cnt).FindControl("lblPropertyDtl"), Label)
            lbl.Text = grdFurniture_Serial.Rows(cnt).Cells(9).Text.ToString
            If lbl.Text = "&nbsp;" Then
                lbl.Text = grdfurnitureandfixtures.Rows(cnt).Cells(9).Text.Replace("&nbsp;", "")
            End If


        Next

        grdfurnitureandfixtures.Columns(9).Visible = False

        LoadFurnitureClearText()
        LoadDisableFurnitureText()

        btninspectedsave.Enabled = False
        LoadButtonDisable()
        btnSaveFurn.Visible = False
        btnEditFur.Visible = False
        btnUpdateFurn.Visible = True
        btnCancelFur.Visible = True
    End Sub
    Protected Sub btnCancelFur_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnCancelFur.Visible = False
        LoadFurnitureSerial()
    End Sub

    Protected Sub LoadFurnitureInfoSave()
        dtFurnitureInfo = objFurnitureInfo.GetDataTable("select FurnitureInfoId from AMS.TbFurniture_Info where AIRDtl_ID like '" & AIRDtl_ID & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
        With objFurnitureInfo
            '  .FurnitureInfoId = FurnitureInfoId
            .AIRDtl_ID = AIRDtl_ID
            ' .IsAccepted = ""
            .Property_Dtl_ID = PropertyDetai_ID
            .SerialNo = grdFurniture_Serial.SelectedDataKey("SerialNo")
            .Name = txtFurnitureName.Text
            .Description = txtFurnitureDescription.Text
            .DepreciationRate = txtFurnitureDepreciatedRate.Text
            .Dimension = txtFurnitureDimension.Text
            .AreaCapacity = txtFurnitureAreaCapacity.Text
            .Model = txtFurnitureModel.Text
            .Warranty = txtFurnitureWarranty.Text

            If txtFurnitureDepreciatedValue.Text = "" Then
                objFurnitureInfo.DepreciationValue = "0.00"
            Else
                objFurnitureInfo.DepreciationValue = txtFurnitureDepreciatedValue.Text
            End If
            objFurnitureInfo.Specification = txtFurnitureSpecification.Text
        End With

        If dtFurnitureInfo.Rows.Count = 0 Then
            objFurnitureInfo.FurnitureInfoId = 0
            objFurnitureInfo.save()
            FurnitureInfoId = objFurnitureInfo.GetValue("Select max(FurnitureInfoId) from AMS.TbFurniture_Info ", CommandType.Text)
        Else
            FurnitureInfoId = objFurnitureInfo.GetValue("Select FurnitureInfoId from AMS.TbFurniture_Info where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
            objFurnitureInfo.FurnitureInfoId = FurnitureInfoId
            objFurnitureInfo.update()
        End If
    End Sub
    Protected Sub LoadFurnitureDtlSave()
        dtFurnitureDtl = objFurnitureDtl.GetDataTable("select FurnitureId from AMS.TbFurniture_Dtl where FurnitureInfoId like '" & FurnitureInfoId & "' ", CommandType.Text)
        With objFurnitureDtl
            ' objFurnitureDtl.FurnitureId = FurnitureId
            objFurnitureDtl.FurnitureInfoId = FurnitureInfoId
            objFurnitureDtl.Property_Dtl_ID = PropertyDetai_ID
            .Condition = objDerived.GetValue("Select Condition from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            .MarketValue = objDerived.GetValue("Select MarketValue from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            .Location = objDerived.GetValue("Select Location from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            'objFurnitureDtl.Status = ""
        End With

        If dtFurnitureDtl.Rows.Count = 0 Then
            objFurnitureDtl.FurnitureId = 0
            objFurnitureDtl.save()
            FurnitureId = objFurnitureDtl.GetValue("Select max(FurnitureId) from AMS.TbFurniture_Dtl ", CommandType.Text)
        Else
            FurnitureId = objFurnitureDtl.GetValue("Select FurnitureId from AMS.TbFurniture_Dtl where FurnitureInfoId like '" & FurnitureInfoId & "' ", CommandType.Text)
            objFurnitureDtl.FurnitureId = FurnitureId
            objFurnitureDtl.update()
        End If
        loadBarcode()

        LoadFurnitureSerial()
    End Sub

    Protected Sub grdFurniture_Serial_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdFurniture_Serial, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdFurniture_Serial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadFurnitureDetail()
    End Sub
    Protected Sub LoadFurnitureClearText()
        txtFurnitureName.Text = ""
        txtFurnitureDescription.Text = ""
        txtFurnitureDepreciatedRate.Text = ""
        txtFurnitureDimension.Text = ""
        txtFurnitureAreaCapacity.Text = ""
        txtFurnitureModel.Text = ""
        txtFurnitureWarranty.Text = ""
        txtFurnitureDepreciatedValue.Text = ""
        txtFurnitureSpecification.Text = ""
    End Sub
    Protected Sub LoadDisableFurnitureText()
        txtFurnitureName.Enabled = False
        txtFurnitureDescription.Enabled = False
        txtFurnitureDepreciatedRate.Enabled = False
        txtFurnitureDimension.Enabled = False
        txtFurnitureAreaCapacity.Enabled = False
        txtFurnitureModel.Enabled = False
        txtFurnitureWarranty.Enabled = False
        txtFurnitureDepreciatedValue.Enabled = False
        txtFurnitureSpecification.Enabled = False
    End Sub
    Protected Sub LoadEnableFurnituretext()
        txtFurnitureName.Enabled = True
        txtFurnitureDescription.Enabled = True
        txtFurnitureDepreciatedRate.Enabled = True
        txtFurnitureDimension.Enabled = True
        txtFurnitureAreaCapacity.Enabled = True
        txtFurnitureModel.Enabled = True
        txtFurnitureWarranty.Enabled = True
        txtFurnitureDepreciatedValue.Enabled = True
        txtFurnitureSpecification.Enabled = True
    End Sub

    'OFFICE SUPPLIES 
    Protected Sub LoadOfficeSaving()
        dtOSupply = objOfficeSup.GetDataTable("select SuppliesId from AMS.TBSupplies_Info where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
        With objOfficeSup
            '  .SuppliesId = SuppliesId
            .StockID = StockID
            .AIRDtl_ID = AIRDtl_ID
            .ItemId = grdOfficeSupp.SelectedDataKey(0)
            .Description = txtOfficeItemDesc.Text
            .BrandName = txtOfficeBrandName.Text
            .SupplierId = grdOfficeSupp.SelectedDataKey(5)
            .Size = txtOfficeSize.Text
            .Color = txtOfficeColor.Text
            .Category = txtOfficeCategory.Text
            .Length = txtOfficeLength.Text
            .Width = txtOfficeWidth.Text
            .Height = txtOfficeHeight.Text
            .Weight = txtOfficeWeight.Text
            .DepreciatedValue = txtOfficeDepValue.Text
            .DepreciatedRate = txtOfficeDepRate.Text
            '.Status = ""
        End With

        If dtOSupply.Rows.Count = 0 Then
            objOfficeSup.SuppliesId = 0
            objOfficeSup.save()
            SuppliesId = objOfficeSup.GetValue("Select max(SuppliesId) from AMS.TBSupplies_Info ", CommandType.Text)
        Else
            SuppliesId = objOfficeSup.GetValue("select SuppliesId from AMS.TBSupplies_Info where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
            objOfficeSup.SuppliesId = SuppliesId
            objOfficeSup.update()
        End If


    End Sub
    Protected Sub LoadOfficeSupply()
        grdOfficeSupp.Columns(11).Visible = True
        grdOfficeSupp.Columns(12).Visible = True
        grdOfficeSupp.Columns(13).Visible = True

        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("Select * from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            LoadAIRnum()

            Dim dtOfficeSup As New DataTable
            dtOfficeSup = objDerived.GetDataTable("Select * from [dbo].[View_SuppliesGoods] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtOfficeSup.Rows.Count < 4 Then
                dtOfficeSup.Merge(createdatatableOfficeSupp(3 - dtOfficeSup.Rows.Count))
            End If
            grdOfficeSupp.DataSource = dtOfficeSup
            grdOfficeSupp.DataBind()
            grdOfficeSupp.SelectedIndex = 0
            LoadOffiePageIndex()

            txtsupplier.Text = IIf(IsDBNull(dtOfficeSup.Rows(0)("SuppName").ToString), 0, (dtOfficeSup.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dtOfficeSup.Rows(0)("PO_No").ToString), 0, (dtOfficeSup.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dtOfficeSup.Rows(0)("DatePurchased").ToString), 0, (dtOfficeSup.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = dtOfficeSup.Rows(0).Item("RespCenter").ToString
            txtOfficeItemDesc.Text = dtOfficeSup.Rows(0).Item("Item_Desc").ToString
            txtOfficeSupplier.Text = grdInspection.SelectedDataKey(3)


            LoadIFCompleted()
        Else ' With AIR
            txtInvoiceDate.ReadOnly = True
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from [dbo].[View_Inspected] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            txtsupplier.Text = IIf(IsDBNull(dt.Rows(0)("SuppName").ToString), 0, (dt.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dt.Rows(0)("PO_No").ToString), 0, (dt.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dt.Rows(0)("DatePurchased").ToString), 0, (dt.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = IIf(IsDBNull(dt.Rows(0)("RespCenter").ToString), 0, (dt.Rows(0)("RespCenter").ToString))
            txtOfficeItemDesc.Text = dt.Rows(0).Item("Item_Desc").ToString
            lblairno.Text = IIf(IsDBNull(dt.Rows(0)("AIR_No").ToString), 0, (dt.Rows(0)("AIR_No").ToString))
            txtInvoiceDate.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_date").ToString), 0, (dt.Rows(0)("Invoice_date").ToString))
            txtinvoiceNo.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_No").ToString), 0, (dt.Rows(0)("Invoice_No").ToString))
            txtremaks.Text = IIf(IsDBNull(dt.Rows(0)("remarks").ToString), 0, (dt.Rows(0)("remarks").ToString))
            txtInspectedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Inspect").ToString), 0, (dt.Rows(0)("Date_Inspect").ToString))
            ddinspector1.Text = IIf(IsDBNull(dt.Rows(0)("Signatory1").ToString), 0, (dt.Rows(0)("Signatory1").ToString))
            ddinspector2.Text = IIf(IsDBNull(dt.Rows(0)("Signatory2").ToString), 0, (dt.Rows(0)("Signatory2").ToString))
            txtAcceptedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Received").ToString), 0, (dt.Rows(0)("Date_Received").ToString))

            If dt.Rows(0)("Signatory3").ToString = "" Then
                ddacceptance.DataSource = objDerived.GetDataTable("Select 'Select' as full_name, 1 as rowno union SELECT full_name  as full_name,empid " & _
                                                                  "from [dbo].[view_signatory1] where deptid = 7 and division_key = 86 order BY rowno", CommandType.Text)
                ddacceptance.DataBind()
                ddacceptance.DataTextField = ("full_name")
                btninspectedsave.Enabled = True
            Else
                ddacceptance.Text = IIf(IsDBNull(dt.Rows(0)("Signatory3").ToString), 0, (dt.Rows(0)("Signatory3").ToString))
                btninspectedsave.Enabled = False
                ddacceptance.Enabled = False
            End If

            If dt.Rows(0)(16) = True Then
                rbStatus.SelectedValue = 1
                btnacceptancepreview.Enabled = True
            Else
                rbStatus.SelectedValue = 0
                btnacceptancepreview.Enabled = False
            End If

            Session("AIRHdr_ID") = dtAIR.Rows(0)("AIRHdr_ID")
            Session("POHdr_ID") = grdInspection.SelectedDataKey("POHdr_ID")

            txtInspectedDate.Enabled = False
            ddinspector1.Enabled = False
            ddinspector2.Enabled = False
            btnInspectedPreview.Enabled = True

            Dim dtOfficeAIR As New DataTable
            dtOfficeAIR = objDerived.GetDataTable("Exec [dbo].[sp_SuppliesList] '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            If dtOfficeAIR.Rows.Count = 0 Then
                grdOfficeSupp.DataSource = createdatatableOfficeSupp(4)
                grdOfficeSupp.DataBind()

                rbStatus.Enabled = True
                btnacceptancepreview.Enabled = True
                btnInspectedPreview.Enabled = False

                btnAccptUpdate.Visible = True
                btnAccptUpdate.Enabled = True

                btnacceptancesave.Visible = False


                txtOfficeItemDesc.Text = ""
                txtOfficeBrandName.Text = ""
                txtOfficeSupplier.Text = ""
                txtOfficeSize.Text = ""
                txtOfficeColor.Text = ""
                txtOfficeCategory.Text = ""
                txtOfficeLength.Text = ""
                txtOfficeWidth.Text = ""
                txtOfficeHeight.Text = ""
                txtOfficeWeight.Text = ""
                txtOfficeDepValue.Text = ""
                txtOfficeDepRate.Text = ""

            Else
                If dtOfficeAIR.Rows.Count < 4 Then
                    dtOfficeAIR.Merge(createdatatableOfficeSupp(3 - dtOfficeAIR.Rows.Count))
                End If
                grdOfficeSupp.DataSource = dtOfficeAIR
                grdOfficeSupp.DataBind()
                grdOfficeSupp.SelectedIndex = 0

                rbStatus.Enabled = False
                rbStatus.SelectedValue = 0
                LoadOffiePageIndex()
            End If
        End If

        grdOfficeSupp.Columns(11).Visible = False
        grdOfficeSupp.Columns(12).Visible = False
        grdOfficeSupp.Columns(13).Visible = False
    End Sub
    Protected Sub LoadOffiePageIndex()
        Dim dtOfficeAIR As New DataTable
        dtOfficeAIR = objDerived.GetDataTable("Select * from [dbo].[View_InspectionAcceptanceGoods] where Item_ID = '" & grdOfficeSupp.SelectedDataKey("Item_ID") & "' and POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtOfficeAIR.Rows.Count = 0 Then
            txtOfficeItemDesc.Text = ""
            txtOfficeBrandName.Text = ""
            txtOfficeSupplier.Text = ""
            txtOfficeSize.Text = ""
            txtOfficeColor.Text = ""
            txtOfficeCategory.Text = ""
            txtOfficeLength.Text = ""
            txtOfficeWidth.Text = ""
            txtOfficeHeight.Text = ""
            txtOfficeWeight.Text = ""
            txtOfficeDepValue.Text = ""
            txtOfficeDepRate.Text = ""

            btninspectedsave.Enabled = False
            btnInspectedPreview.Enabled = False
            btnacceptancesave.Enabled = False
            btnacceptancepreview.Enabled = False
            btnacknowledgementpost.Enabled = False
            btnacknowledgementpreview.Enabled = False
            btnAccptUpdate.Enabled = False
        Else
            Dim dtSupply As New DataTable
            dtSupply = objDerived.GetDataTable("Select * from [dbo].[View_AIR_OfficeSupp] where Item_ID = '" & grdOfficeSupp.SelectedDataKey("Item_ID") & "' and POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtSupply.Rows.Count = 0 Then
                txtOfficeItemDesc.Text = objDerived.GetValue("Select Item_Desc from [dbo].[View_InspectionAcceptanceGoods] where Item_ID = '" & grdOfficeSupp.SelectedDataKey(0) & "'", CommandType.Text)
                txtOfficeBrandName.Text = ""
                txtOfficeSupplier.Text = objDerived.GetValue("Select SuppName from [dbo].[View_InspectionAcceptanceGoods] where Item_ID = '" & grdOfficeSupp.SelectedDataKey(0) & "'", CommandType.Text)
                txtOfficeSize.Text = ""
                txtOfficeColor.Text = ""
                txtOfficeCategory.Text = ""
                txtOfficeLength.Text = ""
                txtOfficeWidth.Text = ""
                txtOfficeHeight.Text = ""
                txtOfficeWeight.Text = ""
                txtOfficeDepValue.Text = ""
                txtOfficeDepRate.Text = ""

                btninspectedsave.Enabled = True
                btnInspectedPreview.Enabled = False
                btnacceptancesave.Enabled = False
                btnacceptancepreview.Enabled = False
                btnacknowledgementpost.Enabled = False
                btnacknowledgementpreview.Enabled = False
                btnAccptUpdate.Enabled = False

            Else
                txtOfficeItemDesc.Text = IIf(IsDBNull(dtSupply.Rows(0)("Item_Desc").ToString), 0, (dtSupply.Rows(0)("Item_Desc").ToString))
                txtOfficeBrandName.Text = IIf(IsDBNull(dtSupply.Rows(0)("BrandName").ToString), 0, (dtSupply.Rows(0)("BrandName").ToString))
                txtOfficeSupplier.Text = IIf(IsDBNull(dtSupply.Rows(0)("SuppName").ToString), 0, (dtSupply.Rows(0)("SuppName").ToString))
                txtOfficeSize.Text = IIf(IsDBNull(dtSupply.Rows(0)("Size").ToString), 0, (dtSupply.Rows(0)("Size").ToString))
                txtOfficeColor.Text = IIf(IsDBNull(dtSupply.Rows(0)("Color").ToString), 0, (dtSupply.Rows(0)("Color").ToString))
                txtOfficeCategory.Text = IIf(IsDBNull(dtSupply.Rows(0)("Category").ToString), 0, (dtSupply.Rows(0)("Category").ToString))
                txtOfficeLength.Text = IIf(IsDBNull(dtSupply.Rows(0)("Length").ToString), 0, (dtSupply.Rows(0)("Length").ToString))
                txtOfficeWidth.Text = IIf(IsDBNull(dtSupply.Rows(0)("Width").ToString), 0, (dtSupply.Rows(0)("Width").ToString))
                txtOfficeHeight.Text = IIf(IsDBNull(dtSupply.Rows(0)("Height").ToString), 0, (dtSupply.Rows(0)("Height").ToString))
                txtOfficeWeight.Text = IIf(IsDBNull(dtSupply.Rows(0)("Weight").ToString), 0, (dtSupply.Rows(0)("Weight").ToString))
                txtOfficeDepValue.Text = IIf(IsDBNull(dtSupply.Rows(0)("DepreciatedValue").ToString), 0, (dtSupply.Rows(0)("DepreciatedValue").ToString))
                txtOfficeDepRate.Text = IIf(IsDBNull(dtSupply.Rows(0)("DepreciatedRate").ToString), 0, (dtSupply.Rows(0)("DepreciatedRate").ToString))
                LoadButtonEnable()
                LoadButtonEnable2()

                If dtSupply.Rows(0)("Status").ToString = "Accepted" Then
                    ddacceptance.Enabled = False

                    btninspectedsave.Enabled = False
                    btninspectedsave.Visible = True
                    btnInspectUpdate.Enabled = False
                    btnInspectUpdate.Visible = False
                    btnInspectedPreview.Enabled = False

                    btnacceptancesave.Enabled = False
                    btnacceptancesave.Visible = False
                    btnAccptUpdate.Enabled = True
                    btnAccptUpdate.Visible = True
                    btnacceptancepreview.Enabled = True

                ElseIf dtSupply.Rows(0)("Status").ToString = "Inspected" Then
                    btnacceptancesave.Enabled = True
                    btninspectedsave.Enabled = True
                    btnInspectUpdate.Enabled = False
                    btnInspectUpdate.Visible = False
                    btnInspectedPreview.Enabled = True

                    btnacceptancesave.Visible = True
                    btnAccptUpdate.Visible = False
                    btnacceptancepreview.Enabled = False
                    txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")
                Else
                    ddacceptance.Enabled = False
                    btninspectedsave.Enabled = True
                    btnInspectUpdate.Enabled = False
                    btnInspectedPreview.Enabled = False
                    btnacceptancesave.Visible = True
                    btnacceptancesave.Enabled = False
                    btnAccptUpdate.Visible = False
                    btnacceptancepreview.Enabled = False
                End If

            End If
        End If
        LoadAttchDoc()
    End Sub
    Protected Sub grdOfficeSupp_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdOfficeSupp, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdOfficeSupp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadOffiePageIndex()
    End Sub

    'MEDICINE SUPPLIES
    Protected Sub LoadMedInfoSaving()
        dtMedInfo = objMedInfo.GetDataTable("select MedicineId from AMS.TBMedicine_Info where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
        With objMedInfo
            '.MedicineId = MedicineId
            .StockId = StockID
            .AIRDtl_ID = AIRDtl_ID
            .Item_ID = grdmedicalsupplies.SelectedDataKey(0)
            .Description = grdmedicalsupplies.SelectedDataKey(3)
            .DrugName = txtOfficeMedicalDrugname.Text
            .BrandName = txtMedicalBrandName.Text
            .SupplierId = grdmedicalsupplies.SelectedDataKey(5)
            .Dose = txtMedDose.Text
            .Location = txtLocation.Text
            '.Status = ""

            If txtMedDeliveryDate.Text = "" Then
                .DeliveryDate = Date.Today.ToString("MM/dd/yyyy")
            Else
                .DeliveryDate = txtMedDeliveryDate.Text
            End If

            If txtOfficeMedicalDepreciatedRate.Text = "" Then
                .Depreciatedrate = 0
            Else
                .Depreciatedrate = txtOfficeMedicalDepreciatedRate.Text
            End If

            If txtOfficeMedicalDepreciationValue.Text = "" Then
                .Depreciatedvalue = 0
            Else
                .Depreciatedvalue = txtOfficeMedicalDepreciationValue.Text
            End If

        End With

        If dtMedInfo.Rows.Count = 0 Then
            objMedInfo.MedicineId = 0
            objMedInfo.save()
            MedicineId = objMedInfo.GetValue("Select max(MedicineId) from AMS.TBMedicine_Info ", CommandType.Text)
        Else
            MedicineId = objMedInfo.GetValue("select MedicineId from AMS.TBMedicine_Info where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
            objMedInfo.MedicineId = MedicineId
            objMedInfo.update()
        End If
    End Sub
    Protected Sub LoadMedDtlSaving()
        dtMedDtl = objMedDtl.GetDataTable("select MedicineDtl from AMS.TBMedicine_DTl where MedicineId like '" & MedicineId & "' ", CommandType.Text)
        With objMedDtl
            ' objMedDtl.MedicineDtl = MedicineDtl
            objMedDtl.MedicineID = MedicineId
            objMedDtl.StockId = StockID
            objMedDtl.Item_ID = grdmedicalsupplies.SelectedDataKey(0)
            objMedDtl.Form = txtMedForm.Text
            objMedDtl.OTCRx = txtMedOTCRX.Text
            If txtMedMftgdate.Text = "" Then
                'objMedDtl.Mftgdate = "01/01/2000"
                txtMedMftgdate.Text = DateTime.Today.AddDays(-30).ToShortDateString()
                objMedDtl.Mftgdate = txtMedMftgdate.Text
            Else
                objMedDtl.Mftgdate = txtMedMftgdate.Text
            End If

            If txtMedAlertDate.Text = "" Then
                objMedDtl.Alert = "01/01/2000"
            Else
                objMedDtl.Alert = txtMedAlertDate.Text
            End If

            objMedDtl.Batch = txtMedBatch.Text
            objMedDtl.Lot = txtMedLot.Text
            objMedDtl.ActualPrice = grdmedicalsupplies.SelectedDataKey("price")
            If txtMedExpiredDate.Text = "" Then
                objMedDtl.EpiryDate = DateTime.Today.AddDays(365).ToShortDateString()
            Else
                objMedDtl.EpiryDate = txtMedExpiredDate.Text
            End If

            lblrequiredfield.Visible = False

        End With

        If dtMedDtl.Rows.Count = 0 Then
            objMedDtl.MedicineDtl = 0
            objMedDtl.save()
            MedicineDtl = objMedDtl.GetValue("Select max(MedicineDtl) from AMS.TBMedicine_DTl ", CommandType.Text)
        Else
            MedicineDtl = objMedDtl.GetValue("select MedicineDtl from AMS.TBMedicine_DTl where MedicineId like '" & MedicineId & "' ", CommandType.Text)
            objMedDtl.MedicineDtl = MedicineDtl
            objMedDtl.update()
        End If



    End Sub
    Protected Sub LoadMedicineSupply()
        grdmedicalsupplies.Columns(11).Visible = True
        grdmedicalsupplies.Columns(12).Visible = True
        grdmedicalsupplies.Columns(13).Visible = True

        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("Select * from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            LoadAIRnum()

            Dim dtMedSup As New DataTable
            dtMedSup = objDerived.GetDataTable("Select * from [dbo].[View_SuppliesGoods] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtMedSup.Rows.Count < 4 Then
                dtMedSup.Merge(createdatatableOfficeSupp(3 - dtMedSup.Rows.Count))
            End If
            grdmedicalsupplies.DataSource = dtMedSup
            grdmedicalsupplies.DataBind()
            grdmedicalsupplies.SelectedIndex = 0
            LoadMedPageIndex()

            txtsupplier.Text = IIf(IsDBNull(dtMedSup.Rows(0)("SuppName").ToString), 0, (dtMedSup.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dtMedSup.Rows(0)("PO_No").ToString), 0, (dtMedSup.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dtMedSup.Rows(0)("DatePurchased").ToString), 0, (dtMedSup.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = dtMedSup.Rows(0).Item("RespCenter").ToString
            txtOfficeItemDesc.Text = dtMedSup.Rows(0).Item("Item_Desc").ToString
            txtOfficeSupplier.Text = grdInspection.SelectedDataKey(3)
            rbStatus.SelectedValue = 0

            LoadButtonDisable()
            btninspectedsave.Enabled = True

        Else
            txtInvoiceDate.ReadOnly = True
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from [dbo].[View_Inspected] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            txtsupplier.Text = IIf(IsDBNull(dt.Rows(0)("SuppName").ToString), 0, (dt.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dt.Rows(0)("PO_No").ToString), 0, (dt.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dt.Rows(0)("DatePurchased").ToString), 0, (dt.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = IIf(IsDBNull(dt.Rows(0)("RespCenter").ToString), 0, (dt.Rows(0)("RespCenter").ToString)) 'dt.Rows(0).Item("RespCenter").ToString
            txtOfficeItemDesc.Text = dt.Rows(0).Item("Item_Desc").ToString
            lblairno.Text = IIf(IsDBNull(dt.Rows(0)("AIR_No").ToString), 0, (dt.Rows(0)("AIR_No").ToString))
            txtInvoiceDate.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_date").ToString), 0, (dt.Rows(0)("Invoice_date").ToString))
            txtinvoiceNo.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_No").ToString), 0, (dt.Rows(0)("Invoice_No").ToString))
            txtremaks.Text = IIf(IsDBNull(dt.Rows(0)("remarks").ToString), 0, (dt.Rows(0)("remarks").ToString))
            txtInspectedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Inspect").ToString), 0, (dt.Rows(0)("Date_Inspect").ToString))
            ddinspector1.Text = IIf(IsDBNull(dt.Rows(0)("Signatory1").ToString), 0, (dt.Rows(0)("Signatory1").ToString))
            ddinspector2.Text = IIf(IsDBNull(dt.Rows(0)("Signatory2").ToString), 0, (dt.Rows(0)("Signatory2").ToString))
            txtAcceptedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Received").ToString), 0, (dt.Rows(0)("Date_Received").ToString))

            'ddacceptance.Text = IIf(IsDBNull(dt.Rows(0)("Signatory3").ToString), 0, (dt.Rows(0)("Signatory3").ToString))
            If dt.Rows(0)("Signatory3").ToString = "" Then
                ddacceptance.DataSource = objDerived.GetDataTable("Select 'Select' as full_name, 1 as rowno union SELECT full_name  as full_name,empid " & _
                                                                  "from [dbo].[view_signatory1] where deptid = 7 and division_key = 86 order BY rowno", CommandType.Text)
                ddacceptance.DataBind()
                ddacceptance.DataTextField = ("full_name")
                btninspectedsave.Enabled = True
            Else
                ddacceptance.Text = IIf(IsDBNull(dt.Rows(0)("Signatory3").ToString), 0, (dt.Rows(0)("Signatory3").ToString))
                btninspectedsave.Enabled = False
                ddacceptance.Enabled = False
            End If

            If dt.Rows(0)(16) = True Then
                rbStatus.SelectedValue = 1
            Else
                rbStatus.SelectedValue = 0
            End If

            Session("AIRHdr_ID") = dt.Rows(0)("AIRHdr_ID").ToString
            Session("POHdr_ID") = grdInspection.SelectedDataKey("POHdr_ID")

            txtInspectedDate.Enabled = False
            ddinspector1.Enabled = False
            ddinspector2.Enabled = False

            LoadButtonEnable()
            btnInspectedPreview.Enabled = True


            Dim dtMedAIR As New DataTable
            dtMedAIR = objDerived.GetDataTable("Exec dbo.sp_MedicineList '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtMedAIR.Rows.Count = 0 Then
                grdmedicalsupplies.DataSource = createdatatableOfficeSupp(4)
                grdmedicalsupplies.DataBind()

                rbStatus.Enabled = True
                btnacceptancepreview.Enabled = True
                btnInspectedPreview.Enabled = False

                btnAccptUpdate.Visible = True
                btnAccptUpdate.Enabled = True

                btnacceptancesave.Visible = False

                txtOfficeMedicalItemDescription.Text = ""
                txtOfficeMedicalDrugname.Text = ""
                txtMedicalBrandName.Text = ""
                txtMedicalSupplier.Text = ""
                txtMedDeliveryDate.Text = ""
                txtOfficeMedicalDepreciatedRate.Text = ""
                txtOfficeMedicalDepreciationValue.Text = ""
                txtLocation.Text = ""

                txtMedName.Text = ""
                txtMedDose.Text = ""
                txtMedForm.Text = ""
                txtMedOTCRX.Text = ""
                txtMedExpiredDate.Text = ""
                txtMedMftgdate.Text = ""
                txtMedBatch.Text = ""
                txtMedLot.Text = ""
                txtMedAlertDate.Text = ""

            Else
                If dtMedAIR.Rows.Count < 4 Then
                    dtMedAIR.Merge(createdatatableOfficeSupp(3 - dtMedAIR.Rows.Count))
                End If
                grdmedicalsupplies.DataSource = dtMedAIR
                grdmedicalsupplies.DataBind()
                grdmedicalsupplies.SelectedIndex = 0
                LoadMedPageIndex()

                rbStatus.Enabled = False
                rbStatus.SelectedValue = 0

                Dim dtstatus As New DataTable
                dtstatus = objDerived.GetDataTable("Select * from View_StockMedicineAIR_v2 where PODtl_ID = '" & grdmedicalsupplies.SelectedDataKey("PODtl_ID") & "'", CommandType.Text)
                If dtstatus.Rows(0)("Status").ToString = "Accepted" Then
                    ddacceptance.Enabled = False
                    btninspectedsave.Enabled = False
                    btnInspectUpdate.Enabled = False
                    btnInspectedPreview.Enabled = False
                    btnacceptancesave.Visible = False
                    btnAccptUpdate.Visible = True
                    btnacceptancepreview.Enabled = True

                ElseIf dtstatus.Rows(0)("Status").ToString = "Inspected" Then
                    btnInspectedPreview.Enabled = True
                    btnacceptancesave.Visible = True
                    btnAccptUpdate.Visible = False
                    btnacceptancepreview.Enabled = False
                    txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")
                Else
                    ddacceptance.Enabled = False
                    btninspectedsave.Enabled = True
                    btnInspectUpdate.Enabled = False
                    btnInspectedPreview.Enabled = False
                    btnacceptancesave.Visible = True
                    btnacceptancesave.Enabled = False
                    btnAccptUpdate.Visible = False
                    btnacceptancepreview.Enabled = False
                End If
            End If
        End If
        grdmedicalsupplies.Columns(11).Visible = False
        grdmedicalsupplies.Columns(12).Visible = False
        grdmedicalsupplies.Columns(13).Visible = False
    End Sub
    Protected Sub LoadMedPageIndex()
        Dim dtSupply As New DataTable
        dtSupply = objDerived.GetDataTable("Select * from [dbo].[View_AIR_MedSupply] where PODtl_ID = '" & grdmedicalsupplies.SelectedDataKey(1) & "'", CommandType.Text)
        If dtSupply.Rows.Count = 0 Then
            txtOfficeMedicalItemDescription.Text = ""
            txtOfficeMedicalDrugname.Text = ""
            txtMedicalBrandName.Text = ""
            txtMedicalSupplier.Text = ""
            txtMedDeliveryDate.Text = ""
            txtOfficeMedicalDepreciatedRate.Text = ""
            txtOfficeMedicalDepreciationValue.Text = ""
            txtLocation.Text = ""

            txtMedName.Text = ""
            txtMedDose.Text = ""
            txtMedForm.Text = ""
            txtMedOTCRX.Text = ""
            txtMedExpiredDate.Text = ""
            txtMedMftgdate.Text = ""
            txtMedBatch.Text = ""
            txtMedLot.Text = ""
            txtMedAlertDate.Text = ""

            btninspectedsave.Enabled = True
            btnInspectedPreview.Enabled = False
            btnacceptancesave.Enabled = False
            btnacceptancesave.Visible = True
            btnacceptancepreview.Enabled = False
            btnacknowledgementpost.Enabled = False
            btnacknowledgementpreview.Enabled = False

        Else
            txtOfficeMedicalItemDescription.Text = IIf(IsDBNull(dtSupply.Rows(0)("Item_Desc").ToString), grdmedicalsupplies.SelectedDataKey(3), (dtSupply.Rows(0)("Item_Desc").ToString))
            txtOfficeMedicalDrugname.Text = IIf(IsDBNull(dtSupply.Rows(0)("Drugname").ToString), 0, (dtSupply.Rows(0)("Drugname").ToString))
            txtMedicalBrandName.Text = IIf(IsDBNull(dtSupply.Rows(0)("BrandName").ToString), 0, (dtSupply.Rows(0)("BrandName").ToString))
            txtMedicalSupplier.Text = IIf(IsDBNull(dtSupply.Rows(0)("SuppName").ToString), grdmedicalsupplies.SelectedDataKey(4), (dtSupply.Rows(0)("SuppName").ToString))
            txtMedDeliveryDate.Text = IIf(IsDBNull(dtSupply.Rows(0)("DeliveryDate").ToString), 0, (dtSupply.Rows(0)("DeliveryDate").ToString))
            txtOfficeMedicalDepreciatedRate.Text = IIf(IsDBNull(dtSupply.Rows(0)("Depreciatedrate").ToString), 0, (dtSupply.Rows(0)("Depreciatedrate").ToString))
            txtOfficeMedicalDepreciationValue.Text = IIf(IsDBNull(dtSupply.Rows(0)("Depreciatedvalue").ToString), 0, (dtSupply.Rows(0)("Depreciatedvalue").ToString))

            txtMedName.Text = IIf(IsDBNull(dtSupply.Rows(0)("Item_Desc").ToString), 0, (dtSupply.Rows(0)("Item_Desc").ToString))
            txtMedDose.Text = IIf(IsDBNull(dtSupply.Rows(0)("Dose").ToString), 0, (dtSupply.Rows(0)("Dose").ToString))
            txtMedForm.Text = IIf(IsDBNull(dtSupply.Rows(0)("Form").ToString), 0, (dtSupply.Rows(0)("Form").ToString))
            txtMedOTCRX.Text = IIf(IsDBNull(dtSupply.Rows(0)("OTCRx").ToString), 0, (dtSupply.Rows(0)("OTCRx").ToString))
            txtMedExpiredDate.Text = IIf(IsDBNull(dtSupply.Rows(0)("EpiryDate").ToString), 0, (dtSupply.Rows(0)("EpiryDate").ToString))
            txtMedMftgdate.Text = IIf(IsDBNull(dtSupply.Rows(0)("Mftgdate").ToString), 0, (dtSupply.Rows(0)("Mftgdate").ToString))
            txtMedBatch.Text = IIf(IsDBNull(dtSupply.Rows(0)("Batch").ToString), 0, (dtSupply.Rows(0)("Batch").ToString))
            txtMedLot.Text = IIf(IsDBNull(dtSupply.Rows(0)("Lot").ToString), 0, (dtSupply.Rows(0)("Lot").ToString))
            txtMedAlertDate.Text = IIf(IsDBNull(dtSupply.Rows(0)("Alert").ToString), 0, (dtSupply.Rows(0)("Alert").ToString))
            txtLocation.Text = IIf(IsDBNull(dtSupply.Rows(0)("Location").ToString), 0, (dtSupply.Rows(0)("Location").ToString))

            LoadButtonEnable()


            Dim dtstatus As New DataTable
            dtstatus = objDerived.GetDataTable("Select * from View_StockMedicineAIR_v2 where PODtl_ID = '" & grdmedicalsupplies.SelectedDataKey("PODtl_ID") & "'", CommandType.Text)
            If dtstatus.Rows.Count = 0 Then
                ddacceptance.Enabled = False
                btninspectedsave.Enabled = False
                btnInspectUpdate.Enabled = False
                btnInspectedPreview.Enabled = False
                btnacceptancesave.Visible = True
                btnacceptancesave.Enabled = False
                btnAccptUpdate.Visible = False
                btnacceptancepreview.Enabled = False
            Else
                If dtstatus.Rows(0)("Status").ToString = "Accepted" Then
                    ddacceptance.Enabled = False
                    btninspectedsave.Enabled = False
                    btnInspectUpdate.Enabled = False
                    btnInspectedPreview.Enabled = False
                    btnacceptancesave.Visible = False
                    btnAccptUpdate.Visible = True
                    btnacceptancepreview.Enabled = True

                ElseIf dtstatus.Rows(0)("Status").ToString = "Inspected" Then
                    btninspectedsave.Enabled = True
                    btnInspectedPreview.Enabled = True
                    btnacceptancesave.Visible = True
                    btnacceptancesave.Enabled = True
                    btnAccptUpdate.Visible = False
                    btnacceptancepreview.Enabled = False
                    txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")
                Else
                    ddacceptance.Enabled = False
                    btninspectedsave.Enabled = True
                    btnInspectUpdate.Enabled = False
                    btnInspectedPreview.Enabled = False
                    btnacceptancesave.Visible = True
                    btnacceptancesave.Enabled = False
                    btnAccptUpdate.Visible = False
                    btnacceptancepreview.Enabled = False
                End If
            End If
        End If

        If txtOfficeMedicalItemDescription.Text = "" Or txtMedicalSupplier.Text = "" Then
            Dim dtable As New DataTable
            dtable = objDerived.GetDataTable("Select * from [dbo].[View_InspectionAcceptanceGoods] where PODtl_ID = '" & grdmedicalsupplies.SelectedDataKey(1) & "'", CommandType.Text)
            If dtable.Rows.Count = 0 Then
                txtOfficeMedicalItemDescription.Text = ""
                txtMedicalSupplier.Text = ""
            Else
                txtOfficeMedicalItemDescription.Text = grdmedicalsupplies.SelectedDataKey(3)
                txtMedicalSupplier.Text = grdmedicalsupplies.SelectedDataKey(4)
            End If
        End If
        LoadAttchDoc()


       
    End Sub
    Protected Sub LoadMedSelectedIndex()

    End Sub
    Protected Sub grdmedicalsupplies_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadMedPageIndex()
    End Sub
    Protected Sub grdmedicalsupplies_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdmedicalsupplies, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    ' *** INSPECTION AND ACCEPTANCE BUTTON 
    Protected Sub btninspectedsave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btninspectedsave.OnClientClick = "StartProgressBar();"


        If ddinspector1.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select inspector officer.")
            Exit Sub
        End If

        Session("Accept") = False
        Session("PropUpdate") = False

        'SET THE SUPPLIES STATUS
        If Session("Allotment_type") = 2 Then
            If grdInspection.SelectedDataKey(0) = 788 Then
                ' OFFICE SUPPLIES
                objOfficeSup.Status = "Inspected"

            ElseIf grdInspection.SelectedDataKey(0) = 793 Or grdInspection.SelectedDataKey(0) = 792 Then
                lblrequiredfield.Visible = False
                lblBatch.Visible = False
                lblLoc.Visible = False
                objMedInfo.Status = "Inspected"


            ElseIf grdInspection.SelectedDataKey(0) = 791 Or grdInspection.SelectedDataKey(0) = 799 Or grdInspection.SelectedDataKey(0) = 798 Then
                'Supplies
                lblSuppStorage.Visible = False
                lblSuppBatch.Visible = False
                lblSuppExpire.Visible = False

                objBlood.Status = "Inspected"
                objFood.Status = "Inspected"
                objWater.Status = "Inspected"

            Else
                lblSuppStorage.Visible = False
                lblSuppBatch.Visible = False
                lblSuppExpire.Visible = False

                objNonFood.Status = "Inspected"
            End If
        End If

        'SAVE AIR DETAILS
        Dim sig3 As String
        sig3 = objDerived.GetValue("Select Signatory3 from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        If sig3 = "" Then
            objhdr.Signatory3 = ""
        Else
            objhdr.Signatory3 = ddacceptance.SelectedItem.Text
        End If

        LoadAirSaving()

        If Session("Allotment_type") = 3 Then

            'SET THE PROPERTY STATUS
            If grdInspection.SelectedDataKey(0) = 520 Or grdInspection.SelectedDataKey(0) = 521 Then 'LAND
                objLandDtl.Status_AIR = "Inspected"
                objPropDtl.Status = "Inspected"
                LoadPropertySaving()
                Loadlandgoods()

            ElseIf grdInspection.SelectedDataKey(0) = 525 Then 'BUILDING
                objBldgInfo.Status_AIR = "Inspected"
                objPropDtl.Status = "Inspected"
                LoadPropertySaving()
                loadBarcode()
                LoadBuildingGoods()

            ElseIf grdInspection.SelectedDataKey(0) = 537 Then ' MACHINERIES
                dtPropSerial = objPropSerial.GetDataTable("Select Item_Serial_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                With objPropSerial
                    .POHdr_ID = objDerived.GetValue("Select POHdr_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .DatePurchased = objDerived.GetValue("Select DatePurchased from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Qty = 1
                    .Item_ID = grdMachineries_Serial.SelectedDataKey("Item_ID")
                    .SerialNo = grdMachineries_Serial.SelectedDataKey("SerialNo")
                    .Condition = objDerived.GetValue("Select Condition from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .MarketValue = objDerived.GetValue("Select MarketValue from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Location = objDerived.GetValue("Select Location from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Status = "Inspected"
                End With
                Item_Serial_ID = objPropSerial.GetValue("Select Item_Serial_ID from AMS.TbPropertySerial where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                objPropSerial.Item_Serial_ID = Item_Serial_ID
                objPropSerial.update()

                objMachineInfo.IsAccepted = False
                objPropDtl.Status = "Inspected"

                Dim dtPropDtl As New DataTable
                dtPropDtl = objDerived.GetDataTable("Select PropertyDetai_ID from AMS.Property_Dtl where SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                If dtPropDtl.Rows.Count = 0 Then
                    LoadPropertySaving()
                Else
                    LoadPropertySave()
                    LoadPropertyDetailSave()
                End If

            ElseIf grdInspection.SelectedDataKey(0) = 534 Then ' FURNITURE AND FIXTURES
                dtPropSerial = objPropSerial.GetDataTable("Select Item_Serial_ID from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                With objPropSerial
                    .POHdr_ID = objDerived.GetValue("Select POHdr_ID from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .DatePurchased = objDerived.GetValue("Select DatePurchased from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Qty = 1
                    .Item_ID = grdFurniture_Serial.SelectedDataKey("Item_ID")
                    .SerialNo = grdFurniture_Serial.SelectedDataKey("SerialNo")
                    .Condition = objDerived.GetValue("Select Condition from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .MarketValue = objDerived.GetValue("Select MarketValue from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Location = objDerived.GetValue("Select Location from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Status = "Inspected"
                    '.Property_Dtl_ID = objPropDtl.PropertyDetai_ID
                End With
                Item_Serial_ID = objPropSerial.GetValue("Select Item_Serial_ID from AMS.TbPropertySerial where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                objPropSerial.Item_Serial_ID = Item_Serial_ID
                objPropSerial.update()

                objFurnitureInfo.IsAccepted = False
                objFurnitureDtl.Status = "Inspected"
                objPropDtl.Status = "Inspected"

                Dim dtPropDtl As New DataTable
                dtPropDtl = objDerived.GetDataTable("Select PropertyDetai_ID from AMS.Property_Dtl where SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                If dtPropDtl.Rows.Count = 0 Then
                    LoadPropertySaving()
                Else
                    LoadPropertySave()
                    LoadPropertyDetailSave()
                End If


            ElseIf grdInspection.SelectedDataKey(0) = 549 Then  ' MOTORS
                dtPropSerial = objPropSerial.GetDataTable("Select Item_Serial_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                With objPropSerial
                    .POHdr_ID = objDerived.GetValue("Select POHdr_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .DatePurchased = objDerived.GetValue("Select DatePurchased from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Qty = 1
                    .Item_ID = grdMotor_Serial.SelectedDataKey("Item_ID")
                    .SerialNo = grdMotor_Serial.SelectedDataKey("SerialNo")
                    .Condition = objDerived.GetValue("Select Condition from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .MarketValue = objDerived.GetValue("Select MarketValue from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Location = objDerived.GetValue("Select Location from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Status = "Inspected"
                End With
                Item_Serial_ID = objPropSerial.GetValue("Select Item_Serial_ID from AMS.TbPropertySerial where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                objPropSerial.Item_Serial_ID = Item_Serial_ID
                objPropSerial.update()

                objEquipInfo.IsAccepted = False
                objPropDtl.Status = "Inspected"

                Dim dtPropDtl As New DataTable
                dtPropDtl = objDerived.GetDataTable("Select PropertyDetai_ID from AMS.Property_Dtl where SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                If dtPropDtl.Rows.Count = 0 Then
                    LoadPropertySaving()
                Else
                    LoadPropertySave()
                    LoadPropertyDetailSave()
                End If

            ElseIf grdInspection.SelectedDataKey(0) = 580 Then  ' AMBULANCE
                dtPropSerial = objPropSerial.GetDataTable("Select Item_Serial_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                With objPropSerial
                    .POHdr_ID = objDerived.GetValue("Select POHdr_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .DatePurchased = objDerived.GetValue("Select DatePurchased from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Qty = 1
                    .Item_ID = grdMotor_Serial.SelectedDataKey("Item_ID")
                    .SerialNo = grdMotor_Serial.SelectedDataKey("SerialNo")
                    .Condition = objDerived.GetValue("Select Condition from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .MarketValue = objDerived.GetValue("Select MarketValue from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Location = objDerived.GetValue("Select Location from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Status = "Inspected"
                End With
                Item_Serial_ID = objPropSerial.GetValue("Select Item_Serial_ID from AMS.TbPropertySerial where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                objPropSerial.Item_Serial_ID = Item_Serial_ID
                objPropSerial.update()

                objAmbulanceInfo.IsAccepted = False
                objAmbulanceDtl.Status = "Inspected"
                objPropDtl.Status = "Inspected"

                Dim dtPropDtl As New DataTable
                dtPropDtl = objDerived.GetDataTable("Select PropertyDetai_ID from AMS.Property_Dtl where SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                If dtPropDtl.Rows.Count = 0 Then
                    LoadPropertySaving()
                Else
                    LoadPropertySave()
                    LoadPropertyDetailSave()
                End If


            Else 'If grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Or grdInspection.SelectedDataKey(0) = 543 Or grdInspection.SelectedDataKey(0) = 540 Or grdInspection.SelectedDataKey(0) = 542 Or grdInspection.SelectedDataKey(0) = 544 Or grdInspection.SelectedDataKey(0) = 545 Or grdInspection.SelectedDataKey(0) = 548 Or grdInspection.SelectedDataKey(0) = 546 Or grdInspection.SelectedDataKey(0) = 94 Then
                'ALL Equipments
                dtPropSerial = objPropSerial.GetDataTable("Select Item_Serial_ID from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                With objPropSerial
                    .POHdr_ID = objDerived.GetValue("Select POHdr_ID from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .DatePurchased = objDerived.GetValue("Select DatePurchased from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Qty = 1
                    .Item_ID = grdEuipment_Serial.SelectedDataKey("Item_ID")
                    .SerialNo = grdEuipment_Serial.SelectedDataKey("SerialNo")
                    .Condition = objDerived.GetValue("Select Condition from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .MarketValue = objDerived.GetValue("Select MarketValue from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Location = objDerived.GetValue("Select Location from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                    .Status = "Inspected"
                End With
                Item_Serial_ID = objPropSerial.GetValue("Select Item_Serial_ID from AMS.TbPropertySerial where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                objPropSerial.Item_Serial_ID = Item_Serial_ID
                objPropSerial.update()

                objEquipInfo.IsAccepted = False
                objPropDtl.Status = "Inspected"

                Dim dtPropDtl As New DataTable
                dtPropDtl = objDerived.GetDataTable("Select PropertyDetai_ID from AMS.Property_Dtl where SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                If dtPropDtl.Rows.Count = 0 Then
                    LoadPropertySaving()
                Else
                    LoadPropertySave()
                    LoadPropertyDetailSave()
                End If
            End If

        End If 'Session("Allotment_type") = 3

        If Session("Allotment_type") = 2 Then
            If grdInspection.SelectedDataKey(0) = 788 Then ' OFFICE SUPPLIES          
                LoadOfficeSupply()
            ElseIf grdInspection.SelectedDataKey(0) = 793 Or grdInspection.SelectedDataKey(0) = 792 Then ' MEDICINES
                LoadMedicineSupply()
            Else 'If grdInspection.SelectedDataKey(0) = 791 Or grdInspection.SelectedDataKey(0) = 799 Or grdInspection.SelectedDataKey(0) = 798 Or grdInspection.SelectedDataKey(0) = 927 Or grdInspection.SelectedDataKey(0) = 795 Or grdInspection.SelectedDataKey(0) = 790 Then
                'SUPPLIES
                LoadSupplies()
            End If
        End If


        btnInspectedPreview.Enabled = True
        btnacceptancesave.Enabled = True

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        '  loadBarcode()


    End Sub
    Protected Sub loadBarcode()
        Dim barcode As New OnBarcode.Barcode.Linear
        dinNo = PropNo.Text
        Session("PropertyNo") = dinNo
        barcode.Type = OnBarcode.Barcode.BarcodeType.CODE128A
        barcode.Data = dinNo
        Dim conStr As String = ConfigurationManager.ConnectionStrings("constr").ToString
        Dim con As New SqlConnection(conStr)

        Dim strPath As String = AppDomain.CurrentDomain.BaseDirectory & "BarcodeImages\"

        Dim strdirectory As String = strPath
        barcode.drawBarcode(strPath & dinNo & ".png")
        imgBarcode.ImageUrl = "~\BarcodeImages\" & dinNo & ".png"

        Dim fName As String

        fName = strPath & dinNo & ".png" 'AppDomain.CurrentDomain.BaseDirectory & imgBarcode.ImageUrl '"~\BarcodeImages\" & dinNo & ".png"
        If File.Exists(fName) Then
            Dim content As Byte() = ImageToStream(fName)
            con.Open()

            Dim dtpropertyno As DataTable
            dtpropertyno = objDerived.GetDataTable("Select PropertyNo from dbo.Property_Barcode where PropertyNo like '" & dinNo & "'", CommandType.Text)
            If dtpropertyno.Rows.Count = 0 Then
                Dim cmd As New SqlCommand("insert into Property_Barcode values ( @id,@img)", con)
                cmd.Parameters.AddWithValue("@id", dinNo)
                cmd.Parameters.AddWithValue("@img", content)
                cmd.ExecuteNonQuery()
            End If
            con.Close()
            'MsgBox("Image inserted")
        Else
            'MsgBox(fName & " not found ")
        End If
        mpeBarcode.Show()
    End Sub
    Private Function ImageToStream(ByVal fileName As String) As Byte()
        Dim stream As New MemoryStream()

        Try
            Dim image As New Bitmap(fileName)
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            '  GoTo tryagain
        End Try

        Return Stream.ToArray()
    End Function
    Protected Sub LoadSavePropLEDGER()
        dtPropLedger = objLedger.GetDataTable("Select Ledger_ID from AMS.TbProperty_Ledger", CommandType.Text)
        With objLedger
            '.Ledger_ID = Ledger_ID
            .PropertyNo = "" 'PropNo.Text
            .SerialNo = ""
            .Trans_Type = "Delivery"
            .Ref = lblairno.Text
            .AccountablePerson = objDerived.GetValue("SELECT dbo.Supplier.SuppName FROM dbo.Supplier INNER JOIN AMS.PO_Hdr ON dbo.Supplier.Supplier_Id = AMS.PO_Hdr.Supplier_ID where POHdr_ID = '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            .Department = ""
            .Position = ""
            If Session("Accept") = True Then
                .AcceptedBy = ddacceptance.SelectedItem.Text
            Else
                .AcceptedBy = ""
            End If
            .InspectedBy = ddinspector1.SelectedItem.Text
            '.DebitQty = ""
            '.DebitUnit = ""
            '.DebitCost = ""
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            '.BalanceQty = ""
            '.BalanceUnit = ""
            '.BalanceCost = ""


            If txtAcceptedDate.Text = "" Then
                .dDate = Date.Today.ToString("MM/dd/yyyy")
            Else
                .dDate = txtAcceptedDate.Text
            End If

            If grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Or grdInspection.SelectedDataKey(0) = 543 Or grdInspection.SelectedDataKey(0) = 540 Or grdInspection.SelectedDataKey(0) = 542 Or grdInspection.SelectedDataKey(0) = 544 Or grdInspection.SelectedDataKey(0) = 545 Or grdInspection.SelectedDataKey(0) = 548 Or grdInspection.SelectedDataKey(0) = 546 Or grdInspection.SelectedDataKey(0) = 94 Then
                'ALL Equipments
                .Item_ID = grdEuipment_Serial.SelectedDataKey(0)

                .DebitQty = grdEuipment_Serial.SelectedDataKey(1)
                .DebitCost = CType(grdEuipment_Serial.SelectedDataKey(1) * grdEuipment_Serial.SelectedDataKey(2), Decimal)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdEuipment_Serial.SelectedDataKey(0) & "'", CommandType.Text)

                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdEuipment_Serial.SelectedDataKey(0) & "'", CommandType.Text)

                Dim Eqty As Integer
                Dim Eqbalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & grdEuipment_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    Eqty = 0
                    Eqbalance = 0.0
                Else
                    Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & grdEuipment_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                    Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & grdEuipment_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                End If

                .BalanceQty = grdEuipment_Serial.SelectedDataKey(1) + Eqty
                .BalanceCost = CType(grdEuipment_Serial.SelectedDataKey(1) * grdEuipment_Serial.SelectedDataKey(2), Decimal) + CType(Eqbalance, Decimal)

            ElseIf grdInspection.SelectedDataKey(0) = 549 Then ' MOTORS
                .Item_ID = grdMotor_Serial.SelectedDataKey(0)

                .DebitQty = grdMotor_Serial.SelectedDataKey(1)
                .DebitCost = CType(grdMotor_Serial.SelectedDataKey(1) * grdMotor_Serial.SelectedDataKey(2), Decimal)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdMotor_Serial.SelectedDataKey(0) & "'", CommandType.Text)

                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdMotor_Serial.SelectedDataKey(0) & "'", CommandType.Text)

                Dim MVqty As Integer
                Dim MVbalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    MVqty = 0
                    MVbalance = 0.0
                Else
                    MVqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                    MVbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                End If

                .BalanceQty = grdMotor_Serial.SelectedDataKey(1) + MVqty
                .BalanceCost = CType(grdMotor_Serial.SelectedDataKey(1) * grdMotor_Serial.SelectedDataKey(2), Decimal) + CType(MVbalance, Decimal)


            ElseIf grdInspection.SelectedDataKey(0) = 580 Then ' AMBULANCE
                .Item_ID = grdMotor_Serial.SelectedDataKey(0)

                .DebitQty = grdMotor_Serial.SelectedDataKey(1)
                .DebitCost = CType(grdMotor_Serial.SelectedDataKey(1) * grdMotor_Serial.SelectedDataKey(2), Decimal)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdMotor_Serial.SelectedDataKey(0) & "'", CommandType.Text)

                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdMotor_Serial.SelectedDataKey(0) & "'", CommandType.Text)

                Dim MVqty As Integer
                Dim MVbalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    MVqty = 0
                    MVbalance = 0.0
                Else
                    MVqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                    MVbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                End If

                .BalanceQty = grdMotor_Serial.SelectedDataKey(1) + MVqty
                .BalanceCost = CType(grdMotor_Serial.SelectedDataKey(1) * grdMotor_Serial.SelectedDataKey(2), Decimal) + CType(MVbalance, Decimal)


            ElseIf grdInspection.SelectedDataKey(0) = 537 Then 'MACHINERY
                .Item_ID = grdMachineries_Serial.SelectedDataKey(0)

                .DebitQty = grdMachineries_Serial.SelectedDataKey(1)
                .DebitCost = CType(grdMachineries_Serial.SelectedDataKey(1) * grdMachineries_Serial.SelectedDataKey(2), Decimal)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdMachineries_Serial.SelectedDataKey(0) & "'", CommandType.Text)

                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdMachineries_Serial.SelectedDataKey(0) & "'", CommandType.Text)

                Dim Macqty As Integer
                Dim Macbalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & grdMachineries_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    Macqty = 0
                    Macbalance = 0.0
                Else
                    Macqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & grdMachineries_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                    Macbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & grdMachineries_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                End If


                .BalanceQty = grdMachineries_Serial.SelectedDataKey(1) + Macqty
                .BalanceCost = CType(grdMachineries_Serial.SelectedDataKey(1) * grdMachineries_Serial.SelectedDataKey(2), Decimal) + CType(Macbalance, Decimal)

            ElseIf grdInspection.SelectedDataKey(0) = 534 Then 'FURNITURE AND FIXTURES
                .Item_ID = grdFurniture_Serial.SelectedDataKey(0)

                .DebitQty = grdFurniture_Serial.SelectedDataKey(1)
                .DebitCost = CType(grdFurniture_Serial.SelectedDataKey(1) * grdFurniture_Serial.SelectedDataKey(2), Decimal)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdFurniture_Serial.SelectedDataKey(0) & "'", CommandType.Text)

                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdFurniture_Serial.SelectedDataKey(0) & "'", CommandType.Text)

                Dim FurQty As Integer
                Dim FurBalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & grdFurniture_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    FurQty = 0
                    FurBalance = 0.0
                Else
                    FurQty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & grdFurniture_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                    FurBalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & grdFurniture_Serial.SelectedDataKey(0) & "'", CommandType.Text)
                End If

                .BalanceQty = grdFurniture_Serial.SelectedDataKey(1) + FurQty
                .BalanceCost = CType(grdFurniture_Serial.SelectedDataKey(1) * grdFurniture_Serial.SelectedDataKey(2), Decimal) + CType(FurBalance, Decimal)
            End If
        End With

        objLedger.Ledger_ID = 0
        objLedger.save()

    End Sub
    Protected Sub LoadStockLEDGER()
        dtStockLedger = objStockLedger.GetDataTable("Select StockLedger_ID from AMS.TbStock_Ledger", CommandType.Text)
        With objStockLedger
            '.StockLedger_ID = StockLedger_ID
            .StockID = StockID
            .Trans_Type = "Delivery"
            .Ref = lblairno.Text
            .AccountablePerson = objDerived.GetValue("SELECT dbo.Supplier.SuppName FROM dbo.Supplier INNER JOIN AMS.PO_Hdr ON dbo.Supplier.Supplier_Id = AMS.PO_Hdr.Supplier_ID where POHdr_ID = '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            .Department = ""
            .Position = ""
            .AcceptedBy = ddacceptance.SelectedItem.Text
            .InspectedBy = ddinspector1.SelectedItem.Text
            '.DebitQty = ""
            '.DebitUnit = ""
            '.DebitCost = ""
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            '.BalanceQty = ""
            '.BalanceUnit = ""
            '.BalanceCost = ""

            If txtAcceptedDate.Text = "" Then
                .dDate = Date.Today.ToString("MM/dd/yyyy")
            Else
                .dDate = txtAcceptedDate.Text
            End If

            If grdInspection.SelectedDataKey(0) = 788 Then
                .Item_ID = grdOfficeSupp.SelectedDataKey("Item_ID")

                .DebitQty = grdOfficeSupp.SelectedDataKey("qty")
                .DebitCost = grdOfficeSupp.SelectedDataKey("AcquisitionCost")
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & grdOfficeSupp.SelectedDataKey("Item_ID") & "'", CommandType.Text)

                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & grdOfficeSupp.SelectedDataKey("Item_ID") & "'", CommandType.Text)

                Dim Officeqty As Integer
                Dim Officebalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbStock_Ledger where Item_ID = '" & grdOfficeSupp.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    Officeqty = 0
                    Officebalance = 0.0
                Else
                    Officeqty = objDerived.GetValue("Select BalanceQty from AMS.TbStock_Ledger where Item_ID = '" & grdOfficeSupp.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                    Officebalance = objDerived.GetValue("Select BalanceCost from AMS.TbStock_Ledger where Item_ID = '" & grdOfficeSupp.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                End If

                .BalanceQty = grdOfficeSupp.SelectedDataKey("qty") + Officeqty
                .BalanceCost = CType(grdOfficeSupp.SelectedDataKey("AcquisitionCost"), Decimal) + CType(Officebalance, Decimal)

            ElseIf grdInspection.SelectedDataKey(0) = 793 Or grdInspection.SelectedDataKey(0) = 792 Then 'MEDICINE
                .Item_ID = grdmedicalsupplies.SelectedDataKey("Item_ID")

                .DebitQty = grdmedicalsupplies.SelectedDataKey("qty")
                .DebitCost = grdmedicalsupplies.SelectedDataKey("AcquisitionCost")
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & grdmedicalsupplies.SelectedDataKey("Item_ID") & "'", CommandType.Text)

                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & grdmedicalsupplies.SelectedDataKey("Item_ID") & "'", CommandType.Text)

                Dim Officeqty As Integer
                Dim Officebalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbStock_Ledger where Item_ID = '" & grdmedicalsupplies.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    Officeqty = 0
                    Officebalance = 0.0
                Else
                    Officeqty = objDerived.GetValue("Select BalanceQty from AMS.TbStock_Ledger where Item_ID = '" & grdmedicalsupplies.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                    Officebalance = objDerived.GetValue("Select BalanceCost from AMS.TbStock_Ledger where Item_ID = '" & grdmedicalsupplies.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                End If

                .BalanceQty = grdmedicalsupplies.SelectedDataKey("qty") + Officeqty
                .BalanceCost = CType(grdmedicalsupplies.SelectedDataKey("AcquisitionCost"), Decimal) + CType(Officebalance, Decimal)

            ElseIf grdInspection.SelectedDataKey(0) = 791 Or grdInspection.SelectedDataKey(0) = 799 Or grdInspection.SelectedDataKey(0) = 798 Or grdInspection.SelectedDataKey(0) = 927 Then
                .Item_ID = grdSupply.SelectedDataKey("Item_ID")

                .DebitQty = grdSupply.SelectedDataKey("qty")
                .DebitCost = grdSupply.SelectedDataKey("AcquisitionCost")
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & grdSupply.SelectedDataKey("Item_ID") & "'", CommandType.Text)

                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & grdSupply.SelectedDataKey("Item_ID") & "'", CommandType.Text)

                Dim Suppqty As Integer
                Dim Suppbalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbStock_Ledger where Item_ID = '" & grdSupply.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    Suppqty = 0
                    Suppbalance = 0.0
                Else
                    Suppqty = objDerived.GetValue("Select BalanceQty from AMS.TbStock_Ledger where Item_ID = '" & grdSupply.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                    Suppbalance = objDerived.GetValue("Select BalanceCost from AMS.TbStock_Ledger where Item_ID = '" & grdSupply.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                End If

                .BalanceQty = grdSupply.SelectedDataKey("qty") + Suppqty
                .BalanceCost = CType(grdSupply.SelectedDataKey("AcquisitionCost"), Decimal) + CType(Suppbalance, Decimal)



            End If

        End With
        objStockLedger.StockLedger_ID = 0
        objStockLedger.save()

    End Sub

    Protected Sub btnInspectUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnInspectUpdate.OnClientClick = "StartProgressBar();"

        Session("Accept") = False
        Session("PropUpdate") = False

        Dim sig3 As String
        sig3 = objDerived.GetValue("Select Signatory3 from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        If sig3 = "" Then
            objhdr.Signatory3 = ""
        Else
            objhdr.Signatory3 = ddacceptance.SelectedItem.Text
        End If

        LoadAirSaving()
        objPropDtl.Status = "Inspected"

        If grdInspection.SelectedDataKey(0) = 520 Then 'LAND
            objLandDtl.Status_AIR = "Inspected"
            LoadPropertySave()
            LoadPropertyDetailSave()
        ElseIf grdInspection.SelectedDataKey(0) = 525 Then 'BUILDING
            objBldgInfo.Status_AIR = "Inspected"
            LoadPropertySave()
            LoadPropertyDetailSave()
        End If

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")
    End Sub
    Protected Sub btnacceptancesave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnacceptancesave.OnClientClick = "StartProgressBar();"

        objDerived.GetRecords("Update AMS.AIR_Hdr set Signatory3 ='" & ddacceptance.SelectedItem.Text & "' where POHdr_ID = '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

        If Session("Allotment_type") = 3 Then
            If grdInspection.SelectedDataKey(0) = 537 Then 'MACHINERY
                Session("chckbox") = 0
                For i As Integer = 0 To Me.grdMachineries_Serial.Rows.Count - 1
                    Dim c As CheckBox = CType(Me.grdMachineries_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If c.Checked = True Then
                        Session("chckbox") = 1
                        Dim x As Integer = grdMachineries_Serial.Rows(i).Cells(9).Text
                        objDerived.GetRecords("Update AMS.Property_Dtl set Status='Accepted' where PropertyDetai_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbPropertySerial set Status='Accepted' where Property_Dtl_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbMachinery_Information set isAccepted='true' where Property_Dtl_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbMachinery_Dtl set Status='Accepted' where Property_Dtl_ID = '" & x & "'", CommandType.Text)

                        Dim Air_Dtl As Integer = objDerived.GetValue("Select AMS.Property.AIRDtl_ID FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID  WHERE AMS.Property_Dtl.PropertyDetai_ID ='" & x & "'", CommandType.Text)
                        Dim Bal As Integer = objDerived.GetValue("Select AMS.Property.Balance FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID  WHERE AMS.Property_Dtl.PropertyDetai_ID ='" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.Property set Balance='" & Bal + 1 & "' where AIRDtl_ID = '" & Air_Dtl & "'", CommandType.Text)

                    End If
                Next

                If Session("chckbox") = 1 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Properties has been successfully accepted.")
                    LoadMachineSerial()
                    Exit Sub
                End If

            ElseIf grdInspection.SelectedDataKey(0) = 549 Or grdInspection.SelectedDataKey(0) = 580 Then ' MOTORS and AMBULANCE
                Session("chckbox") = 0
                For i As Integer = 0 To Me.grdMotor_Serial.Rows.Count - 1
                    Dim c As CheckBox = CType(Me.grdMotor_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If c.Checked = True Then
                        Session("chckbox") = 1
                        Dim x As Integer = grdMotor_Serial.Rows(i).Cells(9).Text
                        objDerived.GetRecords("Update AMS.Property_Dtl set Status='Accepted' where PropertyDetai_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbPropertySerial set Status='Accepted' where Property_Dtl_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbMotor_Info set isAccepted='true' where Property_Dtl_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbMotor_Dtl set Status='Accepted' where Property_Dtl_ID = '" & x & "'", CommandType.Text)

                        If grdInspection.SelectedDataKey(0) = 549 Then 'Motor
                            objDerived.GetRecords("Update AMS.TbMotor_Info set isAccepted='true' where Property_Dtl_ID = '" & x & "'", CommandType.Text)

                        ElseIf grdInspection.SelectedDataKey(0) = 580 Then 'Ambulance
                            objDerived.GetRecords("Update AMS.TbAmbulance_Info set isAccepted='true' where Property_Dtl_ID = '" & x & "'", CommandType.Text)
                        End If

                        Dim Air_Dtl As Integer = objDerived.GetValue("Select AMS.Property.AIRDtl_ID FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID  WHERE AMS.Property_Dtl.PropertyDetai_ID ='" & x & "'", CommandType.Text)
                        Dim Bal As Integer = objDerived.GetValue("Select AMS.Property.Balance FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID  WHERE AMS.Property_Dtl.PropertyDetai_ID ='" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.Property set Balance='" & Bal + 1 & "' where AIRDtl_ID = '" & Air_Dtl & "'", CommandType.Text)

                    End If
                Next

                If Session("chckbox") = 1 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Properties has been successfully accepted.")
                    LoadMotorSerial()
                    Exit Sub
                End If

            ElseIf grdInspection.SelectedDataKey(0) = 534 Then 'FURNITURE AND FIXTURES
                Session("chckbox") = 0
                For i As Integer = 0 To Me.grdFurniture_Serial.Rows.Count - 1
                    Dim c As CheckBox = CType(Me.grdFurniture_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If c.Checked = True Then
                        Session("chckbox") = 1
                        Dim x As Integer = grdFurniture_Serial.Rows(i).Cells(9).Text
                        objDerived.GetRecords("Update AMS.Property_Dtl set Status='Accepted' where PropertyDetai_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbPropertySerial set Status='Accepted' where Property_Dtl_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbFurniture_Info set isAccepted='true' where Property_Dtl_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbFurniture_Dtl set Status='Accepted' where Property_Dtl_ID = '" & x & "'", CommandType.Text)

                        Dim Air_Dtl As Integer = objDerived.GetValue("Select AMS.Property.AIRDtl_ID FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID  WHERE AMS.Property_Dtl.PropertyDetai_ID ='" & x & "'", CommandType.Text)
                        Dim Bal As Integer = objDerived.GetValue("Select AMS.Property.Balance FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID  WHERE AMS.Property_Dtl.PropertyDetai_ID ='" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.Property set Balance='" & Bal + 1 & "' where AIRDtl_ID = '" & Air_Dtl & "'", CommandType.Text)

                    End If
                Next

                If Session("chckbox") = 1 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Properties has been successfully accepted.")
                    LoadFurnitureSerial()
                    Exit Sub
                End If

            Else 'If grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Or grdInspection.SelectedDataKey(0) = 543 Or grdInspection.SelectedDataKey(0) = 540 Or grdInspection.SelectedDataKey(0) = 542 Or grdInspection.SelectedDataKey(0) = 544 Or grdInspection.SelectedDataKey(0) = 545 Or grdInspection.SelectedDataKey(0) = 548 Or grdInspection.SelectedDataKey(0) = 546 Or grdInspection.SelectedDataKey(0) = 94 Then
                'ALL Equipments
                Session("chckbox") = 0
                For i As Integer = 0 To Me.grdEuipment_Serial.Rows.Count - 1
                    Dim c As CheckBox = CType(Me.grdEuipment_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If c.Checked = True Then
                        Session("chckbox") = 1
                        Dim x As Integer = grdEuipment_Serial.Rows(i).Cells(9).Text
                        objDerived.GetRecords("Update AMS.Property_Dtl set Status='Accepted' where PropertyDetai_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbPropertySerial set Status='Accepted' where Property_Dtl_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbEquipment_Info set isAccepted='true' where Property_Dtl_ID = '" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.TbEquipment_Dtl set Status='Accepted' where Property_Dtl_ID = '" & x & "'", CommandType.Text)

                        Dim Air_Dtl As Integer = objDerived.GetValue("Select AMS.Property.AIRDtl_ID FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID  WHERE AMS.Property_Dtl.PropertyDetai_ID ='" & x & "'", CommandType.Text)
                        Dim Bal As Integer = objDerived.GetValue("Select AMS.Property.Balance FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID  WHERE AMS.Property_Dtl.PropertyDetai_ID ='" & x & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.Property set Balance='" & Bal + 1 & "' where AIRDtl_ID = '" & Air_Dtl & "'", CommandType.Text)
                    End If
                Next

                If Session("chckbox") = 1 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Properties has been successfully accepted.")
                    LoadEquipSerial()
                    Exit Sub
                End If

            End If

        End If

        If ddacceptance.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select approving officer.")
            Exit Sub
        End If

        Session("Accept") = True
        Session("PropUpdate") = False

        objhdr.AIR_Date = txtAcceptedDate.Text
        objhdr.isComplete = rbStatus.SelectedValue
        objhdr.Signatory3 = ddacceptance.SelectedItem.Text

        LoadAirSaving()

        If Session("Allotment_type") = 2 Then
            If grdInspection.SelectedDataKey(0) = 788 Then 'OFFICE SUPPLIES
                objOfficeSup.Status = "Accepted"

                Session("chckbx") = 0
                For i As Integer = 0 To Me.grdOfficeSupp.Rows.Count - 1
                    Dim s As CheckBox = CType(Me.grdOfficeSupp.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If s.Checked = True Then
                        Session("chckbx") = 1
                        Exit For
                    End If
                Next

                If Session("chckbx") = 1 Then
                    For i As Integer = 0 To Me.grdOfficeSupp.Rows.Count - 1
                        Dim item As String = grdOfficeSupp.Rows(i).Cells(1).Text
                        If item = "" Or item = "&nbsp;" Then
                            Exit For
                        End If


                        Dim id As Integer = grdOfficeSupp.Rows(i).Cells(11).Text
                        Dim AIR_Dtl As Integer = objDerived.GetValue("Select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & id & "' ", CommandType.Text)

                        Dim s As CheckBox = CType(Me.grdOfficeSupp.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                        If s.Checked = True Then
                            If grdOfficeSupp.Rows(i).Cells(10).Text = "Inspected" Then
                                dtStock = objStock.GetDataTable("select StockID from AMS.Stock where AIRDtl_ID = '" & AIR_Dtl & "' ", CommandType.Text)
                                With objStock
                                    'objStock.StockID = StockID
                                    objStock.StockDate = txtAcceptedDate.Text
                                    objStock.Item_ID = id
                                    objStock.Qty = grdOfficeSupp.Rows(i).Cells(2).Text
                                    objStock.Balance = grdOfficeSupp.Rows(i).Cells(2).Text
                                    objStock.Location = txtLocation.Text
                                    objStock.Expiration_Date = "1/1/1900"
                                    objStock.Cost = grdOfficeSupp.Rows(i).Cells(12).Text
                                    objStock.Issuance = 0
                                    objStock.RC_ID = grdInspection.SelectedDataKey("RC_ID")
                                    objStock.Function_ID = grdInspection.SelectedDataKey("Function_ID")
                                    objStock.Project_ID = 0
                                    objStock.Program_id = 0
                                    'objStock.F_ID = ""
                                    objStock.AIRDtl_ID = AIR_Dtl
                                    objStock.GA_ID = grdInspection.SelectedDataKey(0)
                                    objStock.mab = CType(grdOfficeSupp.Rows(i).Cells(2).Text * grdOfficeSupp.Rows(i).Cells(12).Text, Decimal)

                                    If dtStock.Rows.Count = 0 Then
                                        objStock.StockID = 0
                                        objStock.save()
                                        StockID = objStock.GetValue("Select max(StockID) from AMS.Stock ", CommandType.Text)

                                        '====== save ledger ========
                                        With objStockLedger
                                            '.StockLedger_ID = StockLedger_ID
                                            .StockID = StockID
                                            .Trans_Type = "Delivery"
                                            .Ref = lblairno.Text
                                            .AccountablePerson = objDerived.GetValue("SELECT dbo.Supplier.SuppName FROM dbo.Supplier INNER JOIN AMS.PO_Hdr ON dbo.Supplier.Supplier_Id = AMS.PO_Hdr.Supplier_ID where POHdr_ID = '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
                                            .Department = ""
                                            .Position = ""
                                            .AcceptedBy = ddacceptance.SelectedItem.Text
                                            .InspectedBy = ddinspector1.SelectedItem.Text
                                            .CreditQty = "0"
                                            .CreditUnit = "-"
                                            .CreditCost = "0.00"

                                            If txtAcceptedDate.Text = "" Then
                                                .dDate = Date.Today.ToString("MM/dd/yyyy")
                                            Else
                                                .dDate = txtAcceptedDate.Text
                                            End If

                                            .Item_ID = id
                                            .DebitQty = grdOfficeSupp.Rows(i).Cells(2).Text
                                            .DebitCost = grdOfficeSupp.Rows(i).Cells(8).Text
                                            .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & id & "'", CommandType.Text)

                                            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & id & "'", CommandType.Text)

                                            Dim Officeqty As Integer
                                            Dim Officebalance As Decimal
                                            Dim dtledger As New DataTable

                                            dtledger = objDerived.GetDataTable("Select * from AMS.TbStock_Ledger where Item_ID = '" & id & "'", CommandType.Text)
                                            If dtledger.Rows.Count = 0 Then
                                                Officeqty = 0
                                                Officebalance = 0.0
                                            Else
                                                Officeqty = objDerived.GetValue("Select BalanceQty from AMS.TbStock_Ledger where Item_ID = '" & id & "' order by StockLedger_ID desc", CommandType.Text)
                                                Officebalance = objDerived.GetValue("Select BalanceCost from AMS.TbStock_Ledger where Item_ID = '" & id & "' order by StockLedger_ID desc", CommandType.Text)
                                            End If
                                            .BalanceQty = CType(grdOfficeSupp.Rows(i).Cells(2).Text, Integer) + Officeqty
                                            .BalanceCost = CType(grdOfficeSupp.Rows(i).Cells(8).Text, Decimal) + CType(Officebalance, Decimal)

                                            'objStockLedger.StockLedger_ID = 0
                                            objStockLedger.save()
                                        End With


                                    Else
                                        StockID = objStock.GetValue("select StockID from AMS.Stock where AIRDtl_ID like '" & AIR_Dtl & "' ", CommandType.Text)
                                        objStock.StockID = StockID
                                        objStock.update()
                                    End If

                                End With

                                objDerived.GetRecords("Update AMS.TBSupplies_Info set Status ='Accepted', StockID ='" & StockID & "' where AIRDtl_ID ='" & AIR_Dtl & "'", CommandType.Text)


                            End If
                        End If
                    Next

                ElseIf Session("chckbx") = 0 Then
                    LoadStockSaving()
                End If

                LoadOfficeSupply()


            ElseIf grdInspection.SelectedDataKey(0) = 793 Or grdInspection.SelectedDataKey(0) = 792 Then 'MEDICINE
                objMedInfo.Status = "Accepted"

                Session("chckbx") = 0
                For i As Integer = 0 To Me.grdmedicalsupplies.Rows.Count - 1
                    Dim s As CheckBox = CType(Me.grdmedicalsupplies.Rows(i).Cells(0).FindControl("CheckBox4"), CheckBox)
                    If s.Checked = True Then
                        Session("chckbx") = 1
                        Exit For
                    End If
                Next

                If Session("chckbx") = 1 Then
                    For i As Integer = 0 To Me.grdmedicalsupplies.Rows.Count - 1
                        Dim item As String = grdmedicalsupplies.Rows(i).Cells(1).Text
                        If item = "" Or item = "&nbsp;" Then
                            Exit For
                        End If


                        Dim id As Integer = grdmedicalsupplies.Rows(i).Cells(11).Text
                        Dim AIR_Dtl As Integer = objDerived.GetValue("Select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & id & "' ", CommandType.Text)

                        Dim s As CheckBox = CType(Me.grdmedicalsupplies.Rows(i).Cells(0).FindControl("CheckBox4"), CheckBox)
                        If s.Checked = True Then
                            If grdmedicalsupplies.Rows(i).Cells(10).Text = "Inspected" Then
                                dtStock = objStock.GetDataTable("select StockID from AMS.Stock where AIRDtl_ID = '" & AIR_Dtl & "' ", CommandType.Text)
                                With objStock
                                    'objStock.StockID = StockID
                                    objStock.StockDate = txtAcceptedDate.Text
                                    objStock.Item_ID = id
                                    objStock.Qty = grdmedicalsupplies.Rows(i).Cells(2).Text
                                    objStock.Balance = grdmedicalsupplies.Rows(i).Cells(2).Text
                                    objStock.Location = txtLocation.Text
                                    objStock.Expiration_Date = "1/1/1900"
                                    objStock.Cost = grdmedicalsupplies.Rows(i).Cells(12).Text
                                    objStock.Issuance = 0
                                    objStock.RC_ID = grdInspection.SelectedDataKey("RC_ID")
                                    objStock.Function_ID = grdInspection.SelectedDataKey("Function_ID")
                                    objStock.Project_ID = 0
                                    objStock.Program_id = 0
                                    'objStock.F_ID = ""
                                    objStock.AIRDtl_ID = AIR_Dtl
                                    objStock.GA_ID = grdInspection.SelectedDataKey(0)
                                    objStock.mab = CType(grdmedicalsupplies.Rows(i).Cells(2).Text * grdmedicalsupplies.Rows(i).Cells(12).Text, Decimal)


                                    If dtStock.Rows.Count = 0 Then
                                        objStock.StockID = 0
                                        objStock.save()
                                        StockID = objStock.GetValue("Select max(StockID) from AMS.Stock ", CommandType.Text)

                                        '====== save ledger ========
                                        With objStockLedger
                                            '.StockLedger_ID = StockLedger_ID
                                            .StockID = StockID
                                            .Trans_Type = "Delivery"
                                            .Ref = lblairno.Text
                                            .AccountablePerson = objDerived.GetValue("SELECT dbo.Supplier.SuppName FROM dbo.Supplier INNER JOIN AMS.PO_Hdr ON dbo.Supplier.Supplier_Id = AMS.PO_Hdr.Supplier_ID where POHdr_ID = '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
                                            .Department = ""
                                            .Position = ""
                                            .AcceptedBy = ddacceptance.SelectedItem.Text
                                            .InspectedBy = ddinspector1.SelectedItem.Text
                                            .CreditQty = "0"
                                            .CreditUnit = "-"
                                            .CreditCost = "0.00"

                                            If txtAcceptedDate.Text = "" Then
                                                .dDate = Date.Today.ToString("MM/dd/yyyy")
                                            Else
                                                .dDate = txtAcceptedDate.Text
                                            End If

                                            .Item_ID = id
                                            .DebitQty = grdmedicalsupplies.Rows(i).Cells(2).Text
                                            .DebitCost = grdmedicalsupplies.Rows(i).Cells(8).Text
                                            .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & id & "'", CommandType.Text)

                                            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & id & "'", CommandType.Text)

                                            Dim Officeqty As Integer
                                            Dim Officebalance As Decimal
                                            Dim dtledger As New DataTable

                                            dtledger = objDerived.GetDataTable("Select * from AMS.TbStock_Ledger where Item_ID = '" & id & "'", CommandType.Text)
                                            If dtledger.Rows.Count = 0 Then
                                                Officeqty = 0
                                                Officebalance = 0.0
                                            Else
                                                Officeqty = objDerived.GetValue("Select BalanceQty from AMS.TbStock_Ledger where Item_ID = '" & id & "' order by StockLedger_ID desc", CommandType.Text)
                                                Officebalance = objDerived.GetValue("Select BalanceCost from AMS.TbStock_Ledger where Item_ID = '" & id & "' order by StockLedger_ID desc", CommandType.Text)
                                            End If
                                            .BalanceQty = CType(grdmedicalsupplies.Rows(i).Cells(2).Text, Integer) + Officeqty
                                            .BalanceCost = CType(grdmedicalsupplies.Rows(i).Cells(8).Text, Decimal) + CType(Officebalance, Decimal)

                                            'objStockLedger.StockLedger_ID = 0
                                            objStockLedger.save()
                                        End With

                                    Else
                                        StockID = objStock.GetValue("select StockID from AMS.Stock where AIRDtl_ID like '" & AIR_Dtl & "' ", CommandType.Text)
                                        objStock.StockID = StockID
                                        objStock.update()
                                    End If

                                End With

                                objDerived.GetRecords("Update AMS.TBMedicine_Info set Status ='Accepted', StockID ='" & StockID & "' where AIRDtl_ID ='" & AIR_Dtl & "'", CommandType.Text)

                            End If
                        End If
                    Next

                ElseIf Session("chckbx") = 0 Then
                    LoadStockSaving()
                End If
                LoadMedicineSupply()


            Else 'If grdInspection.SelectedDataKey(0) = 791 Or grdInspection.SelectedDataKey(0) = 799 Or grdInspection.SelectedDataKey(0) = 798 Or grdInspection.SelectedDataKey(0) = 927 Or grdInspection.SelectedDataKey(0) = 795 Or grdInspection.SelectedDataKey(0) = 790 Then

                Session("chckbx") = 0
                For i As Integer = 0 To Me.grdSupply.Rows.Count - 1
                    Dim s As CheckBox = CType(Me.grdSupply.Rows(i).Cells(0).FindControl("CheckBox2"), CheckBox)
                    If s.Checked = True Then
                        Session("chckbx") = 1
                        Exit For
                    End If
                Next

                If Session("chckbx") = 1 Then
                    For i As Integer = 0 To Me.grdSupply.Rows.Count - 1
                        Dim item As String = grdSupply.Rows(i).Cells(1).Text
                        If item = "" Or item = "&nbsp;" Then
                            Exit For
                        End If

                        Dim id As Integer = grdSupply.Rows(i).Cells(11).Text
                        Dim AIR_Dtl As Integer = objDerived.GetValue("Select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & id & "' ", CommandType.Text)

                        Dim s As CheckBox = CType(Me.grdSupply.Rows(i).Cells(0).FindControl("CheckBox2"), CheckBox)
                        If s.Checked = True Then
                            If grdSupply.Rows(i).Cells(10).Text = "Inspected" Then
                                dtStock = objStock.GetDataTable("select StockID from AMS.Stock where AIRDtl_ID = '" & AIR_Dtl & "' ", CommandType.Text)
                                With objStock
                                    'objStock.StockID = StockID
                                    objStock.StockDate = txtAcceptedDate.Text
                                    objStock.Item_ID = id
                                    objStock.Qty = grdSupply.Rows(i).Cells(2).Text
                                    objStock.Balance = grdSupply.Rows(i).Cells(2).Text
                                    objStock.Location = txtLocation.Text
                                    objStock.Expiration_Date = "1/1/1900"
                                    objStock.Cost = grdSupply.Rows(i).Cells(12).Text
                                    objStock.Issuance = 0
                                    objStock.RC_ID = grdInspection.SelectedDataKey("RC_ID")
                                    objStock.Function_ID = grdInspection.SelectedDataKey("Function_ID")
                                    objStock.Project_ID = 0
                                    objStock.Program_id = 0
                                    'objStock.F_ID = ""
                                    objStock.AIRDtl_ID = AIR_Dtl
                                    objStock.GA_ID = grdInspection.SelectedDataKey(0)
                                    objStock.mab = CType(grdSupply.Rows(i).Cells(2).Text * grdSupply.Rows(i).Cells(12).Text, Decimal)


                                    If dtStock.Rows.Count = 0 Then
                                        objStock.StockID = 0
                                        objStock.save()
                                        StockID = objStock.GetValue("Select max(StockID) from AMS.Stock ", CommandType.Text)

                                        '====== save ledger ========
                                        With objStockLedger
                                            '.StockLedger_ID = StockLedger_ID
                                            .StockID = StockID
                                            .Trans_Type = "Delivery"
                                            .Ref = lblairno.Text
                                            .AccountablePerson = objDerived.GetValue("SELECT dbo.Supplier.SuppName FROM dbo.Supplier INNER JOIN AMS.PO_Hdr ON dbo.Supplier.Supplier_Id = AMS.PO_Hdr.Supplier_ID where POHdr_ID = '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
                                            .Department = ""
                                            .Position = ""
                                            .AcceptedBy = ddacceptance.SelectedItem.Text
                                            .InspectedBy = ddinspector1.SelectedItem.Text
                                            .CreditQty = "0"
                                            .CreditUnit = "-"
                                            .CreditCost = "0.00"

                                            If txtAcceptedDate.Text = "" Then
                                                .dDate = Date.Today.ToString("MM/dd/yyyy")
                                            Else
                                                .dDate = txtAcceptedDate.Text
                                            End If

                                            .Item_ID = id
                                            .DebitQty = grdSupply.Rows(i).Cells(2).Text
                                            .DebitCost = grdSupply.Rows(i).Cells(8).Text
                                            .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & id & "'", CommandType.Text)

                                            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & id & "'", CommandType.Text)

                                            Dim Officeqty As Integer
                                            Dim Officebalance As Decimal
                                            Dim dtledger As New DataTable

                                            dtledger = objDerived.GetDataTable("Select * from AMS.TbStock_Ledger where Item_ID = '" & id & "'", CommandType.Text)
                                            If dtledger.Rows.Count = 0 Then
                                                Officeqty = 0
                                                Officebalance = 0.0
                                            Else
                                                Officeqty = objDerived.GetValue("Select BalanceQty from AMS.TbStock_Ledger where Item_ID = '" & id & "' order by StockLedger_ID desc", CommandType.Text)
                                                Officebalance = objDerived.GetValue("Select BalanceCost from AMS.TbStock_Ledger where Item_ID = '" & id & "' order by StockLedger_ID desc", CommandType.Text)
                                            End If
                                            .BalanceQty = CType(grdSupply.Rows(i).Cells(2).Text, Integer) + Officeqty
                                            .BalanceCost = CType(grdSupply.Rows(i).Cells(8).Text, Decimal) + CType(Officebalance, Decimal)

                                            objStockLedger.StockLedger_ID = 0
                                            objStockLedger.save()
                                        End With

                                    Else
                                        StockID = objStock.GetValue("select StockID from AMS.Stock where AIRDtl_ID like '" & AIR_Dtl & "' ", CommandType.Text)
                                        objStock.StockID = StockID
                                        objStock.update()
                                    End If

                                End With

                                If grdInspection.SelectedDataKey(0) = 791 Then  ' Food
                                    objDerived.GetRecords("Update AMS.TbFood set Status ='Accepted', StockID ='" & StockID & "' where AIRDtl_ID ='" & AIR_Dtl & "'", CommandType.Text)
                                ElseIf grdInspection.SelectedDataKey(0) = 799 Then ' Water
                                    objDerived.GetRecords("Update AMS.TbWater set Status ='Accepted', StockID ='" & StockID & "' where AIRDtl_ID ='" & AIR_Dtl & "'", CommandType.Text)
                                ElseIf grdInspection.SelectedDataKey(0) = 798 Then ' Blood
                                    objDerived.GetRecords("Update AMS.TbBlood set Status ='Accepted', StockID ='" & StockID & "' where AIRDtl_ID ='" & AIR_Dtl & "'", CommandType.Text)
                                Else 'If grdInspection.SelectedDataKey(0) = 927 Or grdInspection.SelectedDataKey(0) = 790 Or grdInspection.SelectedDataKey(0) = 795 Then ' Non-Food
                                    objDerived.GetRecords("Update AMS.TbNonFood set Status ='Accepted', StockID ='" & StockID & "' where AIRDtl_ID ='" & AIR_Dtl & "'", CommandType.Text)
                                End If
                            End If
                        End If
                    Next

                ElseIf Session("chckbx") = 0 Then
                    LoadStockSaving()
                End If

                LoadSupplies()
            End If
        End If

        If Session("Allotment_type") = 3 Then
            If Session("chckbox") = 0 Then
                If grdInspection.SelectedDataKey(0) = 520 Then 'LAND
                    objPropDtl.Status = "Accepted"
                    objLandDtl.Status_AIR = "Accepted"
                    LoadPropertySave()
                    LoadPropertyDetailSave()
                    Loadlandgoods()

                ElseIf grdInspection.SelectedDataKey(0) = 525 Then 'BUILDING
                    objPropDtl.Status = "Accepted"
                    objBldgInfo.Status_AIR = "Accepted"
                    LoadPropertySave()
                    LoadPropertyDetailSave()
                    LoadBuildingGoods()

                Else
                    objPropDtl.Status = "Accepted"
                    LoadPropertySave()

                    objEquipInfo.IsAccepted = True
                    objMachineInfo.IsAccepted = True
                    objMotorInfo.IsAccepted = True
                    objFurnitureInfo.IsAccepted = True
                    objAmbulanceInfo.IsAccepted = True

                    objFurnitureDtl.Status = "Accepted"
                    objMotorDtl.Status = "Accepted"
                    objEquipDtl.Status = "Accepted"
                    objMachineDtl.Status = "Accepted"
                    objAmbulanceDtl.Status = "Accepted"
                    objPropSerial.Status = "Accepted"

                    LoadPropertyDetailSave()
                End If
            End If
        End If


        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

    End Sub
    Protected Sub btnAccptUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnAccptUpdate.OnClientClick = "StartProgressBar();"

        If rbStatus.Enabled = True Then
            If rbStatus.SelectedValue = 1 Then
                objDerived.GetRecords("Update AMS.AIR_Hdr set isComplete = 1 where POHdr_ID = '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully completed.")

                If ddCategories.Enabled = False Then
                    Dim dtInspect As New DataTable
                    'dtInspect = objDerived.GetDataTable("Exec [dbo].[sp_InspectionAcceptance] '" & 0 & "', '" & 1 & "'", CommandType.Text)
                    dtInspect = objDerived.GetDataTable("Exec [dbo].[sp_InspectionAcceptance_v2] '" & 0 & "', '" & 1 & "'", CommandType.Text)
                    If dtInspect.Rows.Count < 8 Then
                        dtInspect.Merge(createdatatable1(7 - dtInspect.Rows.Count))
                    End If
                    grdInspection.DataSource = dtInspect
                    grdInspection.DataBind()
                Else
                    LoadCategories()
                End If

            End If
        Else
            Session("PropUpdate") = True
            objPropDtl.Status = "Accepted"
            objPropSerial.Status = "Accepted"
            objLandDtl.Status_AIR = "Accepted"
            objBldgInfo.Status_AIR = "Accepted"

            objhdr.Signatory3 = ddacceptance.SelectedItem.Text
            LoadAirSaving()
            LoadPropertySave()
            LoadPropertyDetailSave()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            LoadIFCompleted()
        End If
    End Sub
    Protected Sub LoadIFCompleted()
        If rbStatus.SelectedValue = 1 Then
            btnacknowledgementpost.Enabled = True

            btnacceptancepreview.Enabled = True
            btnInspectedPreview.Enabled = False
            btninspectedsave.Enabled = False
            btnInspectUpdate.Enabled = False
            btnAccptUpdate.Enabled = False
            btnacceptancesave.Enabled = False
        Else
            btnacknowledgementpost.Enabled = False
        End If
    End Sub
    Protected Sub btnacknowledgementpost_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnacknowledgementpost.OnClientClick = "StartProgressBar();"

        objDerived.GetRecords("UPDATE AMS.PO_Hdr set isDelivered = 1  WHERE PO_No like '" & txtPOnum.Text & "'", CommandType.Text)

        Dim dtAR As New DataTable
        dtAR = objDerived.GetDataTable("Select Acknowledment_ID from AMS.TbAcknowledgement_Reciept where POHdr_ID = '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        With objAR
            '.Acknowledment_ID = ""
            .POHdr_ID = grdInspection.SelectedDataKey("POHdr_ID")
            .aDate = txtAcknowledgementDate.Text
            .Items = ddItems.SelectedItem.Text
            .Acknowledgement_to = ddAcknowledgement.SelectedValue
            .Officer = txtAcknowledgementOfficer.Text
            .Position = txtAcknowledgementposition.Text
        End With
        objAR.Acknowledment_ID = 0
        objAR.save()
        Acknowledment_ID = objAR.GetValue("select max(Acknowledment_ID) from AMS.TbAcknowledgement_Reciept ", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        LoadPageLoad()

        txtAcknowledgementDate.Text = ""
        ddItems.SelectedItem.Text = "Select"
        ddAcknowledgement.SelectedValue = "Select"
        txtAcknowledgementOfficer.Text = ""
        txtAcknowledgementposition.Text = ""
    End Sub

    Protected Sub LoadAirSaving()
        ' ==== AIR HEADER SAVING ====
        dtAirHdrid = objhdr.GetDataTable("select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID ='" & Session("POHdr_ID") & "'", CommandType.Text)
        With objhdr
            'obj.AIRHdr_ID = AIRHdr_ID
            objhdr.AIR_No = lblairno.Text

            If txtInspectedDate.Text = "" Then
                objhdr.AIR_Date = Date.Today.ToString("MM/dd/yyyy")
                objhdr.Date_Inspect = Date.Today.ToString("MM/dd/yyyy")
                objhdr.Date_Received = Date.Today.ToString("MM/dd/yyyy")
            Else
                objhdr.AIR_Date = txtInspectedDate.Text
                objhdr.Date_Inspect = txtInspectedDate.Text
                objhdr.Date_Received = txtInspectedDate.Text
            End If

            objhdr.Invoice_No = txtinvoiceNo.Text

            If txtInvoiceDate.Text = "" Then
                objhdr.Invoice_date = Date.Today.ToString("MM/dd/yyyy")
            Else
                objhdr.Invoice_date = txtInvoiceDate.Text
            End If

            objhdr.PO_No = txtPOnum.Text

            objhdr.Signatory1 = ddinspector1.SelectedItem.Text
            objhdr.Signatory2 = ddinspector2.SelectedItem.Text
            'objhdr.Signatory3 = ddacceptance.SelectedItem.Text
            objhdr.isComplete = CType(rbStatus.SelectedItem.Value, Boolean)
            objhdr.POHdr_ID = grdInspection.SelectedDataKey(1)
            objhdr.remarks = txtremaks.Text
        End With
        If dtAirHdrid.Rows.Count = 0 Then
            objhdr.AIRHdr_ID = 0
            objhdr.save()
            AIRHdr_ID = objhdr.GetValue("select max(AIRHdr_ID) from AMS.AIR_Hdr ", CommandType.Text)

            objDerived.GetRecords("Update AMS.PO_Hdr set isDelivered = 1 where POHdr_ID ='" & Session("POHdr_ID") & "'", CommandType.Text)
        Else
            AIRHdr_ID = objhdr.GetValue("select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID ='" & Session("POHdr_ID") & "' ", CommandType.Text)
            objhdr.AIRHdr_ID = AIRHdr_ID
            objhdr.update()

        End If
        Session("AIRHdr_ID") = AIRHdr_ID

        ' ==== AIR DETAILS SAVING ====
        If Session("Allotment_type") = 3 Then
            If grdInspection.SelectedDataKey(0) = 520 Then ' LAND
                dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdLandGoods.SelectedDataKey("Item_ID") & "' ", CommandType.Text)
                With objdtl
                    objdtl.Item_ID = grdLandGoods.SelectedDataKey("Item_ID")
                    objdtl.Qty = grdLandGoods.SelectedDataKey("Qty")
                    objdtl.Cost = grdInspection.SelectedDataKey("PO_Amount")
                    objdtl.AIRHdr_ID = AIRHdr_ID
                    objdtl.GA_ID = grdInspection.SelectedDataKey("GA_ID")
                End With
                If dtAIRDtlID.Rows.Count = 0 Then
                    objdtl.AIRDtl_ID = 0
                    objdtl.save()
                    AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                Else
                    AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdLandGoods.SelectedDataKey("Item_ID") & "' ", CommandType.Text)
                    objdtl.AIRDtl_ID = AIRDtl_ID
                    objdtl.update()
                End If

            ElseIf grdInspection.SelectedDataKey(0) = 525 Then ' BUILDING
                dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdBuildingGoods.SelectedDataKey("Item_ID") & "' ", CommandType.Text)
                With objdtl
                    objdtl.Item_ID = grdBuildingGoods.SelectedDataKey("Item_ID")
                    objdtl.Qty = 1
                    objdtl.Cost = grdInspection.SelectedDataKey("PO_Amount")
                    objdtl.AIRHdr_ID = AIRHdr_ID
                    objdtl.GA_ID = grdInspection.SelectedDataKey(0)
                End With
                If dtAIRDtlID.Rows.Count = 0 Then
                    objdtl.AIRDtl_ID = 0
                    objdtl.save()
                    AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                Else
                    AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdBuildingGoods.SelectedDataKey("Item_ID") & "' ", CommandType.Text)
                    objdtl.AIRDtl_ID = AIRDtl_ID
                    objdtl.update()
                End If


            ElseIf grdInspection.SelectedDataKey(0) = 534 Then ' FURNITURE AND FIXTURES
                dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdFurniture_Serial.SelectedDataKey(0) & "' ", CommandType.Text)
                With objdtl
                    objdtl.Item_ID = grdFurniture_Serial.SelectedDataKey(0)
                    objdtl.Qty = grdFurniture_Serial.SelectedDataKey(1)
                    objdtl.Cost = grdFurniture_Serial.SelectedDataKey(2)
                    objdtl.AIRHdr_ID = AIRHdr_ID
                    objdtl.GA_ID = grdInspection.SelectedDataKey(0)
                End With

                If dtAIRDtlID.Rows.Count = 0 Then
                    objdtl.AIRDtl_ID = 0
                    objdtl.save()
                    AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                Else
                    AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdFurniture_Serial.SelectedDataKey(0) & "' ", CommandType.Text)
                    objdtl.AIRDtl_ID = AIRDtl_ID
                    objdtl.update()
                End If

            ElseIf grdInspection.SelectedDataKey(0) = 537 Then ' MACHINERIES
                dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdMachineries_Serial.SelectedDataKey(0) & "' ", CommandType.Text)
                With objdtl
                    objdtl.Item_ID = grdMachineries_Serial.SelectedDataKey(0)
                    objdtl.Qty = grdMachineries_Serial.SelectedDataKey(1)
                    objdtl.Cost = grdMachineries_Serial.SelectedDataKey(2)
                    objdtl.AIRHdr_ID = AIRHdr_ID
                    objdtl.GA_ID = grdInspection.SelectedDataKey(0)
                End With
                If dtAIRDtlID.Rows.Count = 0 Then
                    objdtl.AIRDtl_ID = 0
                    objdtl.save()
                    AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                Else
                    AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdMachineries_Serial.SelectedDataKey(0) & "' ", CommandType.Text)
                    objdtl.AIRDtl_ID = AIRDtl_ID
                    objdtl.update()
                End If

            ElseIf grdInspection.SelectedDataKey(0) = 549 Then  ' MOTORS
                dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "' ", CommandType.Text)
                With objdtl
                    objdtl.Item_ID = grdMotor_Serial.SelectedDataKey(0)
                    objdtl.Qty = grdMotor_Serial.SelectedDataKey(1)
                    objdtl.Cost = grdMotor_Serial.SelectedDataKey(2)
                    objdtl.AIRHdr_ID = AIRHdr_ID
                    objdtl.GA_ID = grdInspection.SelectedDataKey(0)
                End With
                If dtAIRDtlID.Rows.Count = 0 Then
                    objdtl.AIRDtl_ID = 0
                    objdtl.save()
                    AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                Else
                    AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "' ", CommandType.Text)
                    objdtl.AIRDtl_ID = AIRDtl_ID
                    objdtl.update()
                End If

            ElseIf grdInspection.SelectedDataKey(0) = 580 Then  ' AMBULANCE
                dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "' ", CommandType.Text)
                With objdtl
                    objdtl.Item_ID = grdMotor_Serial.SelectedDataKey(0)
                    objdtl.Qty = grdMotor_Serial.SelectedDataKey(1)
                    objdtl.Cost = grdMotor_Serial.SelectedDataKey(2)
                    objdtl.AIRHdr_ID = AIRHdr_ID
                    objdtl.GA_ID = grdInspection.SelectedDataKey(0)
                End With
                If dtAIRDtlID.Rows.Count = 0 Then
                    objdtl.AIRDtl_ID = 0
                    objdtl.save()
                    AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                Else
                    AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "' ", CommandType.Text)
                    objdtl.AIRDtl_ID = AIRDtl_ID
                    objdtl.update()
                End If

            Else 'If grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Or grdInspection.SelectedDataKey(0) = 543 Or grdInspection.SelectedDataKey(0) = 540 Or grdInspection.SelectedDataKey(0) = 542 Or grdInspection.SelectedDataKey(0) = 544 Or grdInspection.SelectedDataKey(0) = 545 Or grdInspection.SelectedDataKey(0) = 548 Or grdInspection.SelectedDataKey(0) = 546 Or grdInspection.SelectedDataKey(0) = 94 Then
                'ALL Equipments
                dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdEuipment_Serial.SelectedDataKey(0) & "' ", CommandType.Text)
                With objdtl
                    objdtl.Item_ID = grdEuipment_Serial.SelectedDataKey(0)
                    objdtl.Qty = grdEuipment_Serial.SelectedDataKey(1)
                    objdtl.Cost = grdEuipment_Serial.SelectedDataKey(2)
                    objdtl.AIRHdr_ID = AIRHdr_ID
                    objdtl.GA_ID = grdInspection.SelectedDataKey(0)

                End With
                If dtAIRDtlID.Rows.Count = 0 Then
                    objdtl.AIRDtl_ID = 0
                    objdtl.save()
                    AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                Else
                    AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdEuipment_Serial.SelectedDataKey(0) & "' ", CommandType.Text)
                    objdtl.AIRDtl_ID = AIRDtl_ID
                    objdtl.update()
                End If
            End If

        ElseIf Session("Allotment_type") = 2 Then
            If grdInspection.SelectedDataKey(0) = 788 Then ' OFFICE SUPPLIES
                grdOfficeSupp.Columns(11).Visible = True
                grdOfficeSupp.Columns(12).Visible = True
                grdOfficeSupp.Columns(13).Visible = True

                Session("Chkbox") = 0
                For i As Integer = 0 To Me.grdOfficeSupp.Rows.Count - 1
                    Dim s As CheckBox = CType(Me.grdOfficeSupp.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If s.Checked = True Then
                        Session("Chkbox") = 1
                        Exit For
                    End If
                Next


                If Session("Chkbox") = 1 Then
                    For i As Integer = 0 To Me.grdOfficeSupp.Rows.Count - 1
                        Dim item As String = grdOfficeSupp.Rows(i).Cells(1).Text
                        If item = "" Or item = "&nbsp;" Then
                            Exit For
                        End If

                        Dim id As Integer = grdOfficeSupp.Rows(i).Cells(11).Text
                        dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & id & "' ", CommandType.Text)

                        Dim s As CheckBox = CType(Me.grdOfficeSupp.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                        If s.Checked = True Then
                            With objdtl
                                objdtl.Item_ID = grdOfficeSupp.Rows(i).Cells(11).Text
                                objdtl.Qty = grdOfficeSupp.Rows(i).Cells(2).Text
                                objdtl.Cost = grdOfficeSupp.Rows(i).Cells(12).Text
                                objdtl.AIRHdr_ID = AIRHdr_ID
                                objdtl.GA_ID = grdInspection.SelectedDataKey(0)
                            End With
                            If dtAIRDtlID.Rows.Count = 0 Then
                                objdtl.AIRDtl_ID = 0
                                objdtl.save()
                                AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                            Else
                                AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & id & "' ", CommandType.Text)
                                objdtl.AIRDtl_ID = AIRDtl_ID
                                objdtl.update()
                            End If

                            '======= LoadOfficeSaving()======
                            dtOSupply = objOfficeSup.GetDataTable("select SuppliesId from AMS.TBSupplies_Info where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
                            With objOfficeSup
                                '  .SuppliesId = SuppliesId
                                .StockID = StockID
                                .AIRDtl_ID = AIRDtl_ID
                                .ItemId = id
                                .Description = grdOfficeSupp.Rows(i).Cells(5).Text
                                .BrandName = ""
                                .SupplierId = grdOfficeSupp.Rows(i).Cells(13).Text
                                .Size = ""
                                .Color = ""
                                .Category = ""
                                .Length = ""
                                .Width = ""
                                .Height = ""
                                .Weight = ""
                                .DepreciatedValue = 0.0
                                .DepreciatedRate = 0.0
                                '.Status = ""
                            End With

                            If dtOSupply.Rows.Count = 0 Then
                                objOfficeSup.SuppliesId = 0
                                objOfficeSup.save()
                                SuppliesId = objOfficeSup.GetValue("Select max(SuppliesId) from AMS.TBSupplies_Info ", CommandType.Text)
                            Else
                                SuppliesId = objOfficeSup.GetValue("select SuppliesId from AMS.TBSupplies_Info where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
                                objOfficeSup.SuppliesId = SuppliesId
                                objOfficeSup.update()
                            End If
                        End If
                    Next

                ElseIf Session("Chkbox") = 0 Then
                    dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdOfficeSupp.SelectedDataKey(0) & "' ", CommandType.Text)
                    With objdtl
                        objdtl.Item_ID = grdOfficeSupp.SelectedDataKey(0)
                        objdtl.Qty = grdOfficeSupp.SelectedDataKey(2)
                        objdtl.Cost = grdOfficeSupp.SelectedDataKey(6)
                        objdtl.AIRHdr_ID = AIRHdr_ID
                        objdtl.GA_ID = grdInspection.SelectedDataKey(0)
                    End With
                    If dtAIRDtlID.Rows.Count = 0 Then
                        objdtl.AIRDtl_ID = 0
                        objdtl.save()
                        AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                    Else
                        AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdOfficeSupp.SelectedDataKey(0) & "' ", CommandType.Text)
                        objdtl.AIRDtl_ID = AIRDtl_ID
                        objdtl.update()
                    End If
                    LoadOfficeSaving()
                End If

                grdOfficeSupp.Columns(11).Visible = False
                grdOfficeSupp.Columns(12).Visible = False
                grdOfficeSupp.Columns(13).Visible = False

                '======================================================================
            ElseIf grdInspection.SelectedDataKey(0) = 793 Or grdInspection.SelectedDataKey(0) = 792 Then ' MEDICINES
                grdmedicalsupplies.Columns(11).Visible = True
                grdmedicalsupplies.Columns(12).Visible = True
                grdmedicalsupplies.Columns(13).Visible = True

                Session("Chkbox") = 0
                For i As Integer = 0 To Me.grdmedicalsupplies.Rows.Count - 1
                    Dim s As CheckBox = CType(Me.grdmedicalsupplies.Rows(i).Cells(0).FindControl("CheckBox4"), CheckBox)
                    If s.Checked = True Then
                        Session("Chkbox") = 1
                        Exit For
                    End If
                Next

                If Session("Chkbox") = 1 Then
                    For i As Integer = 0 To Me.grdmedicalsupplies.Rows.Count - 1
                        Dim item As String = grdmedicalsupplies.Rows(i).Cells(1).Text
                        If item = "" Or item = "&nbsp;" Then
                            Exit For
                        End If


                        Dim id As Integer = grdmedicalsupplies.Rows(i).Cells(11).Text
                        dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & id & "' ", CommandType.Text)

                        Dim s As CheckBox = CType(Me.grdmedicalsupplies.Rows(i).Cells(0).FindControl("CheckBox4"), CheckBox)
                        If s.Checked = True Then
                            With objdtl
                                objdtl.Item_ID = id
                                objdtl.Qty = grdmedicalsupplies.Rows(i).Cells(2).Text
                                objdtl.Cost = grdmedicalsupplies.Rows(i).Cells(12).Text
                                objdtl.AIRHdr_ID = AIRHdr_ID
                                objdtl.GA_ID = grdInspection.SelectedDataKey(0)
                            End With
                            If dtAIRDtlID.Rows.Count = 0 Then
                                objdtl.AIRDtl_ID = 0
                                objdtl.save()
                                AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                            Else
                                AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & id & "' ", CommandType.Text)
                                objdtl.AIRDtl_ID = AIRDtl_ID
                                objdtl.update()
                            End If

                            '========= LoadMedInfoSaving() ========= 
                            dtMedInfo = objMedInfo.GetDataTable("select MedicineId from AMS.TBMedicine_Info where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
                            With objMedInfo
                                '.MedicineId = MedicineId
                                .StockId = StockID
                                .AIRDtl_ID = AIRDtl_ID
                                .Item_ID = id
                                .Description = grdmedicalsupplies.Rows(i).Cells(5).Text
                                .DrugName = ""
                                .BrandName = ""
                                .SupplierId = grdmedicalsupplies.Rows(i).Cells(13).Text
                                .Dose = ""
                                .Location = ""
                                '.Status = ""
                                .DeliveryDate = Date.Today.ToString("MM/dd/yyyy")
                                .Depreciatedrate = 0
                                .Depreciatedvalue = 0
                            End With

                            If dtMedInfo.Rows.Count = 0 Then
                                objMedInfo.MedicineId = 0
                                objMedInfo.save()
                                MedicineId = objMedInfo.GetValue("Select max(MedicineId) from AMS.TBMedicine_Info ", CommandType.Text)
                            Else
                                MedicineId = objMedInfo.GetValue("select MedicineId from AMS.TBMedicine_Info where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)
                                objMedInfo.MedicineId = MedicineId
                                objMedInfo.update()
                            End If

                            '========= LoadMedDtlSaving() ========= 
                            dtMedDtl = objMedDtl.GetDataTable("select MedicineDtl from AMS.TBMedicine_DTl where MedicineId = '" & MedicineId & "' ", CommandType.Text)
                            With objMedDtl
                                ' objMedDtl.MedicineDtl = MedicineDtl
                                objMedDtl.MedicineID = MedicineId
                                objMedDtl.StockId = StockID
                                objMedDtl.Item_ID = id
                                objMedDtl.Form = ""
                                objMedDtl.OTCRx = ""
                                objMedDtl.Mftgdate = DateTime.Today.AddDays(-30).ToShortDateString()
                                objMedDtl.Alert = "01/01/2000"
                                objMedDtl.Batch = ""
                                objMedDtl.Lot = ""
                                objMedDtl.ActualPrice = 0.0
                                objMedDtl.EpiryDate = DateTime.Today.AddDays(365).ToShortDateString()
                                lblrequiredfield.Visible = False
                            End With

                            If dtMedDtl.Rows.Count = 0 Then
                                objMedDtl.MedicineDtl = 0
                                objMedDtl.save()
                                MedicineDtl = objMedDtl.GetValue("Select max(MedicineDtl) from AMS.TBMedicine_DTl ", CommandType.Text)
                            Else
                                MedicineDtl = objMedDtl.GetValue("select MedicineDtl from AMS.TBMedicine_DTl where MedicineId = '" & MedicineId & "' ", CommandType.Text)
                                objMedDtl.MedicineDtl = MedicineDtl
                                objMedDtl.update()
                            End If
                        End If
                    Next

                ElseIf Session("Chkbox") = 0 Then
                    dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdmedicalsupplies.SelectedDataKey(0) & "' ", CommandType.Text)

                    With objdtl
                        objdtl.Item_ID = grdmedicalsupplies.SelectedDataKey(0)
                        objdtl.Qty = grdmedicalsupplies.SelectedDataKey(2)
                        objdtl.Cost = grdmedicalsupplies.SelectedDataKey(6)
                        objdtl.AIRHdr_ID = AIRHdr_ID
                        objdtl.GA_ID = grdInspection.SelectedDataKey(0)
                    End With
                    If dtAIRDtlID.Rows.Count = 0 Then
                        objdtl.AIRDtl_ID = 0
                        objdtl.save()
                        AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                    Else
                        AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdmedicalsupplies.SelectedDataKey(0) & "' ", CommandType.Text)
                        objdtl.AIRDtl_ID = AIRDtl_ID
                        objdtl.update()
                    End If
                    LoadMedInfoSaving()
                    LoadMedDtlSaving()
                End If


                grdmedicalsupplies.Columns(11).Visible = False
                grdmedicalsupplies.Columns(12).Visible = False
                grdmedicalsupplies.Columns(13).Visible = False

            Else 'If grdInspection.SelectedDataKey(0) = 791 Or grdInspection.SelectedDataKey(0) = 799 Or grdInspection.SelectedDataKey(0) = 798 Or grdInspection.SelectedDataKey(0) = 927 Or grdInspection.SelectedDataKey(0) = 795 Or grdInspection.SelectedDataKey(0) = 790 Then
                'Supplies
                grdSupply.Columns(11).Visible = True
                grdSupply.Columns(12).Visible = True
                grdSupply.Columns(13).Visible = True

                Session("Chkbox") = 0
                For i As Integer = 0 To Me.grdSupply.Rows.Count - 1
                    Dim s As CheckBox = CType(Me.grdSupply.Rows(i).Cells(0).FindControl("CheckBox2"), CheckBox)
                    If s.Checked = True Then
                        Session("Chkbox") = 1
                        Exit For
                    End If
                Next

                If Session("Chkbox") = 1 Then
                    For i As Integer = 0 To Me.grdSupply.Rows.Count - 1
                        Dim item As String = grdSupply.Rows(i).Cells(1).Text
                        If item = "" Or item = "&nbsp;" Then
                            Exit For
                        End If


                        Dim id As Integer = grdSupply.Rows(i).Cells(11).Text
                        dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & id & "' ", CommandType.Text)

                        Dim s As CheckBox = CType(Me.grdSupply.Rows(i).Cells(0).FindControl("CheckBox2"), CheckBox)
                        If s.Checked = True Then
                            With objdtl
                                objdtl.Item_ID = id
                                objdtl.Qty = grdSupply.Rows(i).Cells(2).Text
                                objdtl.Cost = grdSupply.Rows(i).Cells(12).Text
                                objdtl.AIRHdr_ID = AIRHdr_ID
                                objdtl.GA_ID = grdInspection.SelectedDataKey(0)
                            End With
                            If dtAIRDtlID.Rows.Count = 0 Then
                                objdtl.AIRDtl_ID = 0
                                objdtl.save()
                                AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                            Else
                                AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & id & "' ", CommandType.Text)
                                objdtl.AIRDtl_ID = AIRDtl_ID
                                objdtl.update()
                            End If


                            '======= LoadSuppliesSAVE() ========
                            If grdInspection.SelectedDataKey(0) = 791 Then
                                'FOOD
                                dtFood = objFood.GetDataTable("select Food_ID from AMS.TbFood where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)
                                With objFood
                                    '.Food_ID = Food_ID
                                    .StockId = StockID
                                    .AIRDtl_ID = AIRDtl_ID
                                    .Item_ID = id
                                    .ActualPrice = objDerived.GetValue("SELECT price from m_item_detail where Item_ID = '" & id & "'", CommandType.Text)
                                    .ItemDesc = grdSupply.Rows(i).Cells(5).Text
                                    .BrandName = ""
                                    .Supplier_Id = grdSupply.Rows(i).Cells(13).Text
                                    .Form = txtSuppForm.Text
                                    .OTCRx = txtSuppQTC.Text
                                    .Batch = txtSuppBatch.Text
                                    .Lot = txtSuppLot.Text
                                    .Storage = txtSuppStorage.Text
                                    '.Status = ""

                                    If txtInvoiceDate.Text = "" Then
                                        .DeliveryDate = Date.Today.ToString("MM/dd/yyyy")
                                    Else
                                        .DeliveryDate = txtInvoiceDate.Text
                                    End If

                                    If txtSuppMftg.Text = "" Then
                                        .Mftgdate = "01/01/1900"
                                    Else
                                        .Mftgdate = txtSuppMftg.Text
                                    End If

                                    If txtSuppExpire.Text = "" Then
                                        .EpiryDate = "01/01/1900"
                                    Else
                                        .EpiryDate = txtSuppExpire.Text
                                    End If

                                    If txtSuppAlert.Text = "" Then
                                        .Alert = "01/01/1900"
                                    Else
                                        .Alert = txtSuppAlert.Text
                                    End If

                                    If txtSuppDepRate.Text = "" Then
                                        .Depreciationrate = 0.0
                                    Else
                                        .Depreciationrate = txtSuppDepRate.Text
                                    End If

                                    If txtSuppDepValue.Text = "" Then
                                        .Depreciationvalue = 0.0
                                    Else
                                        .Depreciationvalue = txtSuppDepValue.Text
                                    End If
                                End With

                                If dtFood.Rows.Count = 0 Then
                                    objFood.Food_ID = 0
                                    objFood.save()
                                    Food_ID = objFood.GetValue("Select max(Food_ID) from AMS.TbFood ", CommandType.Text)
                                Else
                                    Food_ID = objFood.GetValue("select Food_ID from AMS.TbFood where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
                                    objFood.Food_ID = Food_ID
                                    objFood.update()
                                End If

                            ElseIf grdInspection.SelectedDataKey(0) = 799 Then
                                'WATER
                                dtWater = objWater.GetDataTable("select Water_ID from AMS.TbWater where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)
                                With objWater
                                    '.Water_ID = Water_ID
                                    .StockId = StockID
                                    .AIRDtl_ID = AIRDtl_ID
                                    .Item_ID = id
                                    .ActualPrice = objDerived.GetValue("SELECT price from m_item_detail where Item_ID = '" & id & "'", CommandType.Text)
                                    .ItemDesc = grdSupply.Rows(i).Cells(5).Text
                                    .BrandName = ""
                                    .Supplier_Id = grdSupply.Rows(i).Cells(13).Text
                                    .Form = txtSuppForm.Text
                                    .OTCRx = txtSuppQTC.Text
                                    .Batch = txtSuppBatch.Text
                                    .Lot = txtSuppLot.Text
                                    .Storage = txtSuppStorage.Text
                                    '.Status = ""

                                    If txtInvoiceDate.Text = "" Then
                                        .DeliveryDate = Date.Today.ToString("MM/dd/yyyy")
                                    Else
                                        .DeliveryDate = txtInvoiceDate.Text
                                    End If

                                    If txtSuppMftg.Text = "" Then
                                        .Mftgdate = "01/01/1900"
                                    Else
                                        .Mftgdate = txtSuppMftg.Text
                                    End If

                                    If txtSuppExpire.Text = "" Then
                                        .EpiryDate = "01/01/1900"
                                    Else
                                        .EpiryDate = txtSuppExpire.Text
                                    End If

                                    If txtSuppAlert.Text = "" Then
                                        .Alert = "01/01/1900"
                                    Else
                                        .Alert = txtSuppAlert.Text
                                    End If

                                    If txtSuppDepRate.Text = "" Then
                                        .Depreciationrate = 0.0
                                    Else
                                        .Depreciationrate = txtSuppDepRate.Text
                                    End If

                                    If txtSuppDepValue.Text = "" Then
                                        .Depreciationvalue = 0.0
                                    Else
                                        .Depreciationvalue = txtSuppDepValue.Text
                                    End If
                                End With

                                If dtWater.Rows.Count = 0 Then
                                    objWater.Water_ID = 0
                                    objWater.save()
                                    Water_ID = objWater.GetValue("Select max(Water_ID) from AMS.TbWater ", CommandType.Text)
                                Else
                                    Water_ID = objWater.GetValue("select Water_ID from AMS.TbWater where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)
                                    objWater.Water_ID = Water_ID
                                    objWater.update()
                                End If

                            ElseIf grdInspection.SelectedDataKey(0) = 798 Then
                                'BLOOD
                                dtBlood = objBlood.GetDataTable("select Blood_ID from AMS.TbBlood where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)
                                With objBlood
                                    '.Blood_ID = Blood_ID
                                    .StockId = StockID
                                    .AIRDtl_ID = AIRDtl_ID
                                    .Item_ID = id
                                    .ActualPrice = objDerived.GetValue("SELECT price from m_item_detail where Item_ID = '" & id & "'", CommandType.Text)
                                    .ItemDesc = grdSupply.Rows(i).Cells(5).Text
                                    .BloodType = grdSupply.Rows(i).Cells(5).Text
                                    .Supplier_Id = grdSupply.Rows(i).Cells(13).Text
                                    .Form = txtSuppForm.Text
                                    .OTCRx = txtSuppQTC.Text
                                    .Batch = txtSuppBatch.Text
                                    .Lot = txtSuppLot.Text
                                    .Storage = txtSuppStorage.Text
                                    '.Status = ""

                                    If txtInvoiceDate.Text = "" Then
                                        .DeliveryDate = Date.Today.ToString("MM/dd/yyyy")
                                    Else
                                        .DeliveryDate = txtInvoiceDate.Text
                                    End If

                                    If txtSuppMftg.Text = "" Then
                                        .Mftgdate = "01/01/1900"
                                    Else
                                        .Mftgdate = txtSuppMftg.Text
                                    End If

                                    If txtSuppExpire.Text = "" Then
                                        .EpiryDate = "01/01/1900"
                                    Else
                                        .EpiryDate = txtSuppExpire.Text
                                    End If

                                    If txtSuppAlert.Text = "" Then
                                        .Alert = "01/01/1900"
                                    Else
                                        .Alert = txtSuppAlert.Text
                                    End If

                                    If txtSuppDepRate.Text = "" Then
                                        .Depreciationrate = 0.0
                                    Else
                                        .Depreciationrate = txtSuppDepRate.Text
                                    End If

                                    If txtSuppDepValue.Text = "" Then
                                        .Depreciationvalue = 0.0
                                    Else
                                        .Depreciationvalue = txtSuppDepValue.Text
                                    End If
                                End With

                                If dtBlood.Rows.Count = 0 Then
                                    objBlood.Blood_ID = 0
                                    objBlood.save()
                                    Blood_ID = objBlood.GetValue("Select max(Blood_ID) from AMS.TbBlood ", CommandType.Text)
                                Else
                                    Blood_ID = objBlood.GetValue("select Blood_ID from AMS.TbBlood where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)
                                    objBlood.Blood_ID = Blood_ID
                                    objBlood.update()
                                End If

                            Else 'If grdInspection.SelectedDataKey(0) = 927 Or grdInspection.SelectedDataKey(0) = 790 Or grdInspection.SelectedDataKey(0) = 795 Then
                                'NON-FOOD
                                dtNonFood = objNonFood.GetDataTable("select NonFood_ID from AMS.TbNonFood where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)
                                With objNonFood
                                    '.NonFood_ID = NonFood_ID
                                    .StockId = StockID
                                    .AIRDtl_ID = AIRDtl_ID
                                    .Item_ID = id
                                    .ActualPrice = objDerived.GetValue("SELECT price from m_item_detail where Item_ID = '" & id & "'", CommandType.Text)
                                    .ItemDesc = grdSupply.Rows(i).Cells(5).Text
                                    .BrandName = ""
                                    .Supplier_Id = grdSupply.Rows(i).Cells(13).Text
                                    .Form = txtSuppForm.Text
                                    .OTCRx = txtSuppQTC.Text
                                    .Batch = txtSuppBatch.Text
                                    .Lot = txtSuppLot.Text
                                    .Storage = txtSuppStorage.Text
                                    '.Status = ""

                                    If txtSuppMftg.Text = "" Then
                                        .Mftgdate = "01/01/1900"
                                    Else
                                        .Mftgdate = txtSuppMftg.Text
                                    End If

                                    If txtSuppExpire.Text = "" Then
                                        .EpiryDate = "01/01/1900"
                                    Else
                                        .EpiryDate = txtSuppExpire.Text
                                    End If

                                    If txtSuppAlert.Text = "" Then
                                        .Alert = "01/01/1900"
                                    Else
                                        .Alert = txtSuppAlert.Text
                                    End If

                                    If txtInvoiceDate.Text = "" Then
                                        .DeliveryDate = Date.Today.ToString("MM/dd/yyyy")
                                    Else
                                        .DeliveryDate = txtInvoiceDate.Text
                                    End If

                                    If txtSuppDepRate.Text = "" Then
                                        .Depreciationrate = 0.0
                                    Else
                                        .Depreciationrate = txtSuppDepRate.Text
                                    End If

                                    If txtSuppDepValue.Text = "" Then
                                        .Depreciationvalue = 0.0
                                    Else
                                        .Depreciationvalue = txtSuppDepValue.Text
                                    End If
                                End With

                                If dtNonFood.Rows.Count = 0 Then
                                    objNonFood.NonFood_ID = 0
                                    objNonFood.save()
                                    NonFood_ID = objNonFood.GetValue("Select max(NonFood_ID) from AMS.TbNonFood ", CommandType.Text)
                                Else
                                    NonFood_ID = objNonFood.GetValue("select NonFood_ID from AMS.TbNonFood where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)
                                    objNonFood.NonFood_ID = NonFood_ID
                                    objNonFood.update()
                                End If
                            End If

                        End If
                    Next



                ElseIf Session("Chkbox") = 0 Then
                    dtAIRDtlID = objdtl.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdSupply.SelectedDataKey("Item_ID") & "' ", CommandType.Text)
                    With objdtl
                        objdtl.Item_ID = grdSupply.SelectedDataKey(0)
                        objdtl.Qty = grdSupply.SelectedDataKey(2)
                        objdtl.Cost = grdSupply.SelectedDataKey(6)
                        objdtl.AIRHdr_ID = AIRHdr_ID
                        objdtl.GA_ID = grdInspection.SelectedDataKey(0)
                    End With
                    If dtAIRDtlID.Rows.Count = 0 Then
                        objdtl.AIRDtl_ID = 0
                        objdtl.save()
                        AIRDtl_ID = objdtl.GetValue("select max(AIRDtl_ID) from AMS.AIR_Dtl", CommandType.Text)
                    Else
                        AIRDtl_ID = objdtl.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & AIRHdr_ID & "' and Item_ID = '" & grdSupply.SelectedDataKey("Item_ID") & "' ", CommandType.Text)
                        objdtl.AIRDtl_ID = AIRDtl_ID
                        objdtl.update()
                    End If
                    LoadSuppliesSAVE()
                End If

                grdSupply.Columns(11).Visible = False
                grdSupply.Columns(12).Visible = False
                grdSupply.Columns(13).Visible = False
            End If
        End If

    End Sub
    Protected Sub LoadStockSaving()
        dtStock = objStock.GetDataTable("select StockID from AMS.Stock where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
        With objStock
            'objStock.StockID = StockID
            If txtAcceptedDate.Text = "" Then
                objStock.StockDate = Date.Today.ToString("MM/dd/yyyy")
            Else
                objStock.StockDate = txtAcceptedDate.Text
            End If

            If grdInspection.SelectedDataKey(0) = 788 Then ' OFFICE
                objStock.Item_ID = grdOfficeSupp.SelectedDataKey(0)
                objStock.Qty = grdOfficeSupp.SelectedDataKey(2)
                objStock.Balance = grdOfficeSupp.SelectedDataKey(2)
                objStock.Location = txtLocation.Text
                objStock.Expiration_Date = "1/1/1900"

                Dim dt2 As New DataTable
                dt2 = objStock.GetDataTable("select * from AMS.PO_Dtl where PODtl_ID like '" & grdOfficeSupp.SelectedDataKey(1) & "' ", CommandType.Text)
                objStock.Cost = dt2.Rows(0).Item(3)

            ElseIf grdInspection.SelectedDataKey(0) = 793 Or grdInspection.SelectedDataKey(0) = 792 Then ' MEDICINE
                objStock.Item_ID = grdmedicalsupplies.SelectedDataKey(0)
                objStock.Qty = grdmedicalsupplies.SelectedDataKey(2)
                objStock.Balance = grdmedicalsupplies.SelectedDataKey(2)
                objStock.Location = txtLocation.Text
                objStock.Batch = txtMedBatch.Text
                objStock.Expiration_Date = txtMedExpiredDate.Text

                objStock.Cost = objDerived.GetValue("select cost from AMS.PO_Dtl where PODtl_ID like '" & grdmedicalsupplies.SelectedDataKey(1) & "' ", CommandType.Text)


            Else 'If grdInspection.SelectedDataKey(0) = 791 Or grdInspection.SelectedDataKey(0) = 799 Or grdInspection.SelectedDataKey(0) = 798 Or grdInspection.SelectedDataKey(0) = 927 Then
                'Supplies
                objStock.Item_ID = grdSupply.SelectedDataKey(0)
                objStock.Qty = grdSupply.SelectedDataKey(2)
                objStock.Balance = grdSupply.SelectedDataKey(2)
                objStock.Location = txtSuppStorage.Text
                objStock.Expiration_Date = txtSuppExpire.Text
                objStock.Batch = txtSuppBatch.Text

                objStock.Cost = objDerived.GetValue("select cost from AMS.PO_Dtl where PODtl_ID like '" & grdSupply.SelectedDataKey("PODtl_ID") & "' ", CommandType.Text)
            End If

            objStock.Issuance = 0
            objStock.RC_ID = grdInspection.SelectedDataKey("RC_ID")
            objStock.Function_ID = 86
            objStock.Project_ID = 0
            objStock.Program_id = 0
            'objStock.F_ID = ""
            objStock.AIRDtl_ID = AIRDtl_ID
            objStock.GA_ID = grdInspection.SelectedDataKey(0)
            'objStock.mab = ""

        End With

        If dtStock.Rows.Count = 0 Then
            objStock.StockID = 0
            objStock.save()
            StockID = objStock.GetValue("Select max(StockID) from AMS.Stock ", CommandType.Text)

            LoadStockLEDGER()
        Else
            StockID = objStock.GetValue("select StockID from AMS.Stock where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
            objStock.StockID = StockID
            objStock.update()
        End If


        If grdInspection.SelectedDataKey(0) = 788 Then ' Office Supply
            objOfficeSup.Status = "Accepted"
            LoadOfficeSaving()

        ElseIf grdInspection.SelectedDataKey(0) = 793 Or grdInspection.SelectedDataKey(0) = 792 Then ' Medicince
            objMedInfo.Status = "Accepted"
            LoadMedInfoSaving()
            LoadMedDtlSaving()

        ElseIf grdInspection.SelectedDataKey(0) = 791 Then 'FOOD
            objFood.Status = "Accepted"
            LoadSuppliesSAVE()

        ElseIf grdInspection.SelectedDataKey(0) = 799 Then 'WATER
            objWater.Status = "Accepted"
            LoadSuppliesSAVE()

        ElseIf grdInspection.SelectedDataKey(0) = 798 Then 'BLOOD
            objBlood.Status = "Accepted"
            LoadSuppliesSAVE()

        Else 'If grdInspection.SelectedDataKey(0) = 927 Then 'NON-FOOD
            objNonFood.Status = "Accepted"
            LoadSuppliesSAVE()
        End If
    End Sub
    Protected Sub LoadPropertySaving()
        LoadPropertySave()
        LoadPropertyNo()
        LoadPropertyDetailSave()
    End Sub
    Protected Sub LoadPropertySave()
        dtPropHdr = objPropHdr.GetDataTable("select Property_ID from AMS.Property where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)
        With objPropHdr
            '.Property_ID = Property_ID
            If txtAcceptedDate.Text = "" Then
                .Property_Date = Date.Today.ToString("MM/dd/yyyy")
            Else
                .Property_Date = txtAcceptedDate.Text
            End If


            '.Issuance = 0
            .Remarks = txtremaks.Text
            .Emp_ID = 0
            .F_ID = 4
            .AIRDtl_ID = AIRDtl_ID
            .deptid = 1
            .isDonated = False
            .GA_ID = grdInspection.SelectedDataKey(0)
            .DonationRemarks = ""
            .Balance = 0

            Dim Bal As Integer
            Bal = objDerived.GetValue("Select Balance from AMS.Property where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)

            If Session("PropUpdate") = True Then
                objPropHdr.Balance = Bal

            ElseIf Session("PropUpdate") = False Then
                If Session("Accept") = True Then
                    objPropHdr.Balance = Bal + 1

                ElseIf Session("Accept") = False Then
                    objPropHdr.Balance = Bal
                End If
            End If



            If grdInspection.SelectedDataKey(0) = 520 Or grdInspection.SelectedDataKey(0) = 521 Then ' LAND
                objPropHdr.Cost = grdLandGoods.SelectedDataKey("AcquisitionCost")
                'objPropHdr.Qty = grdLandGoods.SelectedDataKey("Qty")
                'objPropHdr.Balance = grdLandGoods.SelectedDataKey("Qty")
                objPropHdr.Item_ID = grdLandGoods.SelectedDataKey("Item_ID")
                objPropHdr.Property_code = 201
                objPropHdr.RC_ID = grdLandGoods.SelectedDataKey("RC_ID")
                objPropHdr.Function_ID = grdLandGoods.SelectedDataKey("Function_ID")
                objPropHdr.TD_ID = 1
                objPropHdr.Project_ID = grdLandGoods.SelectedDataKey("Project_ID")
                objPropHdr.Program_id = grdLandGoods.SelectedDataKey("Program_id")
                objPropHdr.Particular = grdLandGoods.SelectedDataKey("Item_Desc")

                objPropDtl.type = grdLandGoods.SelectedDataKey("type")

            ElseIf grdInspection.SelectedDataKey(0) = 525 Then ' BUILDING
                LoadBldgPropSaving()
                objPropHdr.Property_code = 211
            ElseIf grdInspection.SelectedDataKey(0) = 526 Then ' BUILDING
                LoadBldgPropSaving()
                objPropHdr.Property_code = 212

                'ElseIf grdInspection.SelectedDataKey(0) = 533 Then ' EQUIPMENTS
                '    LoadEquipmentPropSaving()
                '    objPropHdr.Property_code = 221

                'ElseIf grdInspection.SelectedDataKey(0) = 535 Then
                '    LoadEquipmentPropSaving()
                '    objPropHdr.Property_code = 223

                'ElseIf grdInspection.SelectedDataKey(0) = 540 Then
                '    LoadEquipmentPropSaving()
                '    objPropHdr.Property_code = 229

                'ElseIf grdInspection.SelectedDataKey(0) = 543 Then
                '    LoadEquipmentPropSaving()
                '    objPropHdr.Property_code = 232

                'ElseIf grdInspection.SelectedDataKey(0) = 542 Then
                '    LoadEquipmentPropSaving()
                '    objPropHdr.Property_code = 231

                'ElseIf grdInspection.SelectedDataKey(0) = 544 Then
                '    LoadEquipmentPropSaving()
                '    objPropHdr.Property_code = 233

                'ElseIf grdInspection.SelectedDataKey(0) = 545 Then
                '    LoadEquipmentPropSaving()
                '    objPropHdr.Property_code = 234

                'ElseIf grdInspection.SelectedDataKey(0) = 548 Then
                '    LoadEquipmentPropSaving()
                '    objPropHdr.Property_code = 240

                'ElseIf grdInspection.SelectedDataKey(0) = 546 Then
                '    LoadEquipmentPropSaving()
                '    objPropHdr.Property_code = 235

                'ElseIf grdInspection.SelectedDataKey(0) = 94 Then
                '    LoadEquipmentPropSaving()
                '    objPropHdr.Property_code = 225


            ElseIf grdInspection.SelectedDataKey(0) = 549 Then ' MOTORS
                objPropHdr.Cost = grdMotor_Serial.SelectedDataKey(2)
                'objPropHdr.Qty = grdMotor_Serial.SelectedDataKey(1)
                'objPropHdr.Balance = grdMotor_Serial.SelectedDataKey(1)
                objPropHdr.Item_ID = grdMotor_Serial.SelectedDataKey(0)
                objPropHdr.Property_code = 241
                objPropHdr.RC_ID = grdMotor_Serial.SelectedDataKey(5)
                objPropHdr.Function_ID = grdMotor_Serial.SelectedDataKey(6)
                objPropHdr.TD_ID = 4
                objPropHdr.Project_ID = grdMotor_Serial.SelectedDataKey(7)
                objPropHdr.Program_id = grdMotor_Serial.SelectedDataKey(8)
                objPropHdr.Particular = grdMotor_Serial.SelectedDataKey("Item_Desc")

                objPropDtl.type = grdMotor_Serial.SelectedDataKey(4)
                objPropDtl.SerialNo = grdMotor_Serial.SelectedDataKey("SerialNo")

            ElseIf grdInspection.SelectedDataKey(0) = 580 Then ' AMBULANCE
                objPropHdr.Cost = grdMotor_Serial.SelectedDataKey(2)
                'objPropHdr.Qty = grdMotor_Serial.SelectedDataKey(1)
                'objPropHdr.Balance = grdMotor_Serial.SelectedDataKey(1)
                objPropHdr.Item_ID = grdMotor_Serial.SelectedDataKey(0)
                objPropHdr.Property_code = 290
                objPropHdr.RC_ID = grdMotor_Serial.SelectedDataKey(5)
                objPropHdr.Function_ID = grdMotor_Serial.SelectedDataKey(6)
                objPropHdr.TD_ID = 7
                objPropHdr.Project_ID = grdMotor_Serial.SelectedDataKey(7)
                objPropHdr.Program_id = grdMotor_Serial.SelectedDataKey(8)
                objPropHdr.Particular = grdMotor_Serial.SelectedDataKey("Item_Desc")

                objPropDtl.type = grdMotor_Serial.SelectedDataKey(4)
                objPropDtl.SerialNo = grdMotor_Serial.SelectedDataKey("SerialNo")

            ElseIf grdInspection.SelectedDataKey(0) = 537 Then 'MACHINERY
                objPropHdr.Cost = grdMachineries_Serial.SelectedDataKey(2)
                'objPropHdr.Qty = grdMachineries_Serial.SelectedDataKey(1)
                'objPropHdr.Balance = grdMachineries_Serial.SelectedDataKey(1)
                objPropHdr.Item_ID = grdMachineries_Serial.SelectedDataKey(0)
                objPropHdr.Property_code = 226
                objPropHdr.RC_ID = grdMachineries_Serial.SelectedDataKey(5)
                objPropHdr.Function_ID = grdMachineries_Serial.SelectedDataKey(6)
                objPropHdr.TD_ID = 5
                objPropHdr.Project_ID = grdMachineries_Serial.SelectedDataKey(7)
                objPropHdr.Program_id = grdMachineries_Serial.SelectedDataKey(8)
                objPropHdr.Particular = grdMachineries_Serial.SelectedDataKey("Item_Desc")

                objPropDtl.type = grdMachineries_Serial.SelectedDataKey(4)
                objPropDtl.SerialNo = grdMachineries_Serial.SelectedDataKey("SerialNo")

            ElseIf grdInspection.SelectedDataKey(0) = 534 Then 'FURNITURE AND FIXTURES
                objPropHdr.Cost = grdFurniture_Serial.SelectedDataKey(2)
                'objPropHdr.Qty = grdFurniture_Serial.SelectedDataKey(1)
                'objPropHdr.Balance = grdFurniture_Serial.SelectedDataKey(1)
                objPropHdr.Item_ID = grdFurniture_Serial.SelectedDataKey(0)
                objPropHdr.Property_code = 222
                objPropHdr.RC_ID = grdFurniture_Serial.SelectedDataKey(5)
                objPropHdr.Function_ID = grdFurniture_Serial.SelectedDataKey(6)
                objPropHdr.TD_ID = 6
                objPropHdr.Project_ID = grdFurniture_Serial.SelectedDataKey(7)
                objPropHdr.Program_id = grdFurniture_Serial.SelectedDataKey(8)
                objPropHdr.Particular = grdFurniture_Serial.SelectedDataKey("Item_Desc")

                objPropDtl.type = grdFurniture_Serial.SelectedDataKey(4)
                objPropDtl.SerialNo = grdFurniture_Serial.SelectedDataKey("SerialNo")

            Else 'others
                LoadEquipmentPropSaving()
                Dim code As Integer
                code = objDerived.GetValue("Select GA_Code from LnkdSrvrBOSS.GEOBOS.BOS.m_GenAccnt AS m_GenAccnt WHERE m_GenAccnt.GA_ID = '" & grdInspection.SelectedDataKey(0) & "'", CommandType.Text)
                objPropHdr.Property_code = code
            End If

        End With
        If dtPropHdr.Rows.Count = 0 Then
            objPropHdr.Issuance = 0

            If grdInspection.SelectedDataKey(0) = 520 Or grdInspection.SelectedDataKey(0) = 521 Then ' LAND
                objPropHdr.Qty = grdLandGoods.SelectedDataKey("Qty")
            ElseIf grdInspection.SelectedDataKey(0) = 525 Or grdInspection.SelectedDataKey(0) = 526 Then ' BUILDING
                objPropHdr.Qty = grdBuildingGoods.SelectedDataKey("Qty")
            ElseIf grdInspection.SelectedDataKey(0) = 549 Then ' MOTORS
                objPropHdr.Qty = grdMotor_Serial.SelectedDataKey(1)
            ElseIf grdInspection.SelectedDataKey(0) = 580 Then ' AMBULANCE
                objPropHdr.Qty = grdMotor_Serial.SelectedDataKey(1)
            ElseIf grdInspection.SelectedDataKey(0) = 537 Then 'MACHINERY
                objPropHdr.Qty = grdMachineries_Serial.SelectedDataKey(1)
            ElseIf grdInspection.SelectedDataKey(0) = 534 Then 'FURNITURE AND FIXTURES
                objPropHdr.Qty = grdFurniture_Serial.SelectedDataKey(1)
            Else 'If grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Or grdInspection.SelectedDataKey(0) = 543 Or grdInspection.SelectedDataKey(0) = 540 Or grdInspection.SelectedDataKey(0) = 542 Or grdInspection.SelectedDataKey(0) = 544 Or grdInspection.SelectedDataKey(0) = 545 Or grdInspection.SelectedDataKey(0) = 548 Or grdInspection.SelectedDataKey(0) = 546 Or grdInspection.SelectedDataKey(0) = 94 Then
                'ALL Equipments
                objPropHdr.Qty = grdEuipment_Serial.SelectedDataKey(1)
            End If

            objPropHdr.Property_ID = 0
            objPropHdr.save()
            Property_ID = objPropHdr.GetValue("Select max(Property_ID) from AMS.Property ", CommandType.Text)

            '=== Save LEDGER ===
            LoadSavePropLEDGER()
        Else
            Property_ID = objPropHdr.GetValue("Select Property_ID from AMS.Property where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)

            objPropHdr.Qty = objDerived.GetValue("Select Qty from AMS.Property where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)
            objPropHdr.Issuance = objDerived.GetValue("Select Issuance from AMS.Property where AIRDtl_ID = '" & AIRDtl_ID & "' ", CommandType.Text)

            objPropHdr.Property_ID = Property_ID
            objPropHdr.update()

        End If
    End Sub
    Protected Sub LoadPropertyDetailSave()
        If grdInspection.SelectedDataKey(0) = 520 Or grdInspection.SelectedDataKey(0) = 521 Then 'LAND
            dtPropDtl = objPropDtl.GetDataTable("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and PropertyNo = '" & PropNo.Text & "' ", CommandType.Text)

        ElseIf grdInspection.SelectedDataKey(0) = 525 Then 'BUILDING
            dtPropDtl = objPropDtl.GetDataTable("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and PropertyNo = '" & PropNo.Text & "' ", CommandType.Text)

        ElseIf grdInspection.SelectedDataKey(0) = 537 Then 'MACHINERY
            dtPropDtl = objPropDtl.GetDataTable("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "' and PropertyNo = '" & PropNo.Text & "'", CommandType.Text)

        ElseIf grdInspection.SelectedDataKey(0) = 549 Or grdInspection.SelectedDataKey(0) = 580 Then ' MOTORS and AMBULANCE
            dtPropDtl = objPropDtl.GetDataTable("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and SerialNo ='" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'  and PropertyNo = '" & PropNo.Text & "'", CommandType.Text)

        ElseIf grdInspection.SelectedDataKey(0) = 534 Then 'FURNITURE AND FIXTURES
            dtPropDtl = objPropDtl.GetDataTable("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and SerialNo ='" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'  and PropertyNo = '" & PropNo.Text & "'", CommandType.Text)

        Else 'If grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Or grdInspection.SelectedDataKey(0) = 543 Or grdInspection.SelectedDataKey(0) = 540 Or grdInspection.SelectedDataKey(0) = 542 Or grdInspection.SelectedDataKey(0) = 544 Or grdInspection.SelectedDataKey(0) = 545 Or grdInspection.SelectedDataKey(0) = 548 Or grdInspection.SelectedDataKey(0) = 546 Or grdInspection.SelectedDataKey(0) = 94 Then
            'ALL Equipments
            dtPropDtl = objPropDtl.GetDataTable("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "' and PropertyNo = '" & PropNo.Text & "' ", CommandType.Text)
        End If

        With objPropDtl
            .PropertyNo = PropNo.Text
            .Property_ID = Property_ID
            '.Status = True
            .Issued = False
            .Repair = False
            '.Details = ""
            .Dispose = False
            .DisposeDate = "1/1/1900"
            .IsInspectionForDisposal = False
            .InspectionDate = "1/1/1900"
            .F_ID = 4
            .Barcode = objPropDtl.SerialNo
            .Amount = objPropHdr.Cost

        End With
        If dtPropDtl.Rows.Count = 0 Then
            objPropDtl.PropertyDetai_ID = 0
            objPropDtl.save()
            PropertyDetai_ID = objPropDtl.GetValue("Select max(PropertyDetai_ID) from AMS.Property_Dtl ", CommandType.Text)
            Session("PropertyDtl_ID") = PropertyDetai_ID

        Else
            If grdInspection.SelectedDataKey(0) = 520 Or grdInspection.SelectedDataKey(0) = 521 Then
                PropertyDetai_ID = objPropDtl.GetValue("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and PropertyNo = '" & PropNo.Text & "' ", CommandType.Text)

            ElseIf grdInspection.SelectedDataKey(0) = 525 Then 'BUILDING
                PropertyDetai_ID = objPropDtl.GetValue("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and PropertyNo = '" & PropNo.Text & "' ", CommandType.Text)

            ElseIf grdInspection.SelectedDataKey(0) = 537 Then 'MACHINERY
                PropertyDetai_ID = objPropDtl.GetValue("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and SerialNo ='" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'  and PropertyNo = '" & PropNo.Text & "'", CommandType.Text)

            ElseIf grdInspection.SelectedDataKey(0) = 549 Or grdInspection.SelectedDataKey(0) = 580 Then ' MOTORS and AMBULANCE
                PropertyDetai_ID = objPropDtl.GetValue("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and SerialNo ='" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'  and PropertyNo = '" & PropNo.Text & "'", CommandType.Text)

            ElseIf grdInspection.SelectedDataKey(0) = 534 Then 'FURNITURE AND FIXTURES
                PropertyDetai_ID = objPropDtl.GetValue("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and SerialNo ='" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'  and PropertyNo = '" & PropNo.Text & "'", CommandType.Text)

            Else 'If grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Or grdInspection.SelectedDataKey(0) = 543 Or grdInspection.SelectedDataKey(0) = 540 Or grdInspection.SelectedDataKey(0) = 542 Or grdInspection.SelectedDataKey(0) = 544 Or grdInspection.SelectedDataKey(0) = 545 Or grdInspection.SelectedDataKey(0) = 548 Or grdInspection.SelectedDataKey(0) = 546 Or grdInspection.SelectedDataKey(0) = 94 Then
                'ALL Equipments
                PropertyDetai_ID = objPropDtl.GetValue("Select PropertyDetai_ID from AMS.Property_Dtl where Property_ID = '" & Property_ID & "' and SerialNo ='" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "' and PropertyNo = '" & PropNo.Text & "'", CommandType.Text)

            End If

            objPropDtl.PropertyDetai_ID = PropertyDetai_ID
            objPropDtl.update()

        End If

        If grdInspection.SelectedDataKey(0) = 520 Or grdInspection.SelectedDataKey(0) = 521 Then 'LAND
            LoadLandDetailsSaving()
            'LoadLandTechDescSaving()
            'LoadLandDocumentSaving()
            'LoadLandOwnerHistorySaving()
            'LoadLandValuationSaving()
        ElseIf grdInspection.SelectedDataKey(0) = 525 Then 'BUILDING
            LoadBuildingDetailsSaving()

        ElseIf grdInspection.SelectedDataKey(0) = 537 Then 'MACHINERY
            dtPropSerial = objPropSerial.GetDataTable("Select Item_Serial_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            With objPropSerial
                .POHdr_ID = objDerived.GetValue("Select POHdr_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .Qty = 1
                .Item_ID = grdMachineries_Serial.SelectedDataKey("Item_ID")
                .SerialNo = grdMachineries_Serial.SelectedDataKey("SerialNo")
                .Condition = objDerived.GetValue("Select Condition from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .MarketValue = objDerived.GetValue("Select MarketValue from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .Location = objDerived.GetValue("Select Location from AMS.TbPropertySerial  where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                '.Status = "Accepted"
                .Property_Dtl_ID = PropertyDetai_ID
            End With
            Item_Serial_ID = objPropSerial.GetValue("Select Item_Serial_ID from AMS.TbPropertySerial where Item_ID = '" & grdMachineries_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMachineries_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            objPropSerial.Item_Serial_ID = Item_Serial_ID
            objPropSerial.update()

            LoadMachineInfoSave()
            LoadMachineDtlSave()

        ElseIf grdInspection.SelectedDataKey(0) = 549 Then ' MOTORS
            dtPropSerial = objPropSerial.GetDataTable("Select Item_Serial_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            With objPropSerial
                .POHdr_ID = objDerived.GetValue("Select POHdr_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .Qty = 1
                .Item_ID = grdMotor_Serial.SelectedDataKey("Item_ID")
                .SerialNo = grdMotor_Serial.SelectedDataKey("SerialNo")
                .Condition = objDerived.GetValue("Select Condition from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .MarketValue = objDerived.GetValue("Select MarketValue from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .Location = objDerived.GetValue("Select Location from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                '.Status = "Accepted"
                .Property_Dtl_ID = PropertyDetai_ID
            End With
            Item_Serial_ID = objPropSerial.GetValue("Select Item_Serial_ID from AMS.TbPropertySerial where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            objPropSerial.Item_Serial_ID = Item_Serial_ID
            objPropSerial.update()

            LoadMotorInfoSave()
            LoadMotorDtlSave()

        ElseIf grdInspection.SelectedDataKey(0) = 580 Then ' AMBULANCE
            dtPropSerial = objPropSerial.GetDataTable("Select Item_Serial_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            With objPropSerial
                .POHdr_ID = objDerived.GetValue("Select POHdr_ID from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .Qty = 1
                .Item_ID = grdMotor_Serial.SelectedDataKey("Item_ID")
                .SerialNo = grdMotor_Serial.SelectedDataKey("SerialNo")
                .Condition = objDerived.GetValue("Select Condition from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .MarketValue = objDerived.GetValue("Select MarketValue from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .Location = objDerived.GetValue("Select Location from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                '.Status = "Accepted"
                .Property_Dtl_ID = PropertyDetai_ID
            End With
            Item_Serial_ID = objPropSerial.GetValue("Select Item_Serial_ID from AMS.TbPropertySerial where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            objPropSerial.Item_Serial_ID = Item_Serial_ID
            objPropSerial.update()

            LoadAmbulanceInfoSave()
            LoadAmbulanceDtlSave()

        ElseIf grdInspection.SelectedDataKey(0) = 534 Then 'FURNITURE AND FIXTURES
            dtPropSerial = objPropSerial.GetDataTable("Select Item_Serial_ID from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            With objPropSerial
                .POHdr_ID = objDerived.GetValue("Select POHdr_ID from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .Qty = 1
                .Item_ID = grdFurniture_Serial.SelectedDataKey("Item_ID")
                .SerialNo = grdFurniture_Serial.SelectedDataKey("SerialNo")
                .Condition = objDerived.GetValue("Select Condition from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .MarketValue = objDerived.GetValue("Select MarketValue from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .Location = objDerived.GetValue("Select Location from AMS.TbPropertySerial  where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                '.Status = "Accepted"
                .Property_Dtl_ID = PropertyDetai_ID
            End With
            Item_Serial_ID = objPropSerial.GetValue("Select Item_Serial_ID from AMS.TbPropertySerial where Item_ID = '" & grdFurniture_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdFurniture_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            objPropSerial.Item_Serial_ID = Item_Serial_ID
            objPropSerial.update()

            LoadFurnitureInfoSave()
            LoadFurnitureDtlSave()

        Else 'If grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Or grdInspection.SelectedDataKey(0) = 543 Or grdInspection.SelectedDataKey(0) = 540 Or grdInspection.SelectedDataKey(0) = 542 Or grdInspection.SelectedDataKey(0) = 544 Or grdInspection.SelectedDataKey(0) = 545 Or grdInspection.SelectedDataKey(0) = 548 Or grdInspection.SelectedDataKey(0) = 546 Or grdInspection.SelectedDataKey(0) = 94 Then
            'ALL Equipments
            dtPropSerial = objPropSerial.GetDataTable("Select Item_Serial_ID from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            With objPropSerial
                .POHdr_ID = objDerived.GetValue("Select POHdr_ID from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .DatePurchased = objDerived.GetValue("Select DatePurchased from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .Qty = 1
                .Item_ID = grdEuipment_Serial.SelectedDataKey("Item_ID")
                .SerialNo = grdEuipment_Serial.SelectedDataKey("SerialNo")
                .Condition = objDerived.GetValue("Select Condition from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .MarketValue = objDerived.GetValue("Select MarketValue from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                .Location = objDerived.GetValue("Select Location from AMS.TbPropertySerial  where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                '.Status = "Accepted"
                .Property_Dtl_ID = PropertyDetai_ID
            End With
            Item_Serial_ID = objPropSerial.GetValue("Select Item_Serial_ID from AMS.TbPropertySerial where Item_ID = '" & grdEuipment_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdEuipment_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            objPropSerial.Item_Serial_ID = Item_Serial_ID
            objPropSerial.update()

            LoadEuipInfoSave()
            LoadEquipDtlSave()
        End If
    End Sub

    Protected Sub LoadEquipmentPropSaving()
        objPropHdr.Item_ID = grdEuipment_Serial.SelectedDataKey(0)
        'objPropHdr.Balance = grdEuipment_Serial.SelectedDataKey("1")
        objPropHdr.Cost = grdEuipment_Serial.SelectedDataKey(2)
        objPropHdr.RC_ID = grdEuipment_Serial.SelectedDataKey(5)
        objPropHdr.Function_ID = grdEuipment_Serial.SelectedDataKey(6)
        objPropHdr.TD_ID = 3
        objPropHdr.Project_ID = grdEuipment_Serial.SelectedDataKey(7)
        objPropHdr.Program_id = grdEuipment_Serial.SelectedDataKey(8)
        objPropHdr.Particular = grdEuipment_Serial.SelectedDataKey("Item_Desc")

        objPropDtl.type = grdEuipment_Serial.SelectedDataKey(4)
        objPropDtl.SerialNo = grdEuipment_Serial.SelectedDataKey("SerialNo")
    End Sub
    Protected Sub LoadBldgPropSaving()
        objPropHdr.Cost = grdBuildingGoods.SelectedDataKey("AcquisitionCost")
        'objPropHdr.Qty = grdBuildingGoods.SelectedDataKey("Qty")
        'objPropHdr.Balance = grdBuildingGoods.SelectedDataKey("Qty")
        objPropHdr.Item_ID = grdBuildingGoods.SelectedDataKey("Item_ID")
        objPropHdr.RC_ID = grdBuildingGoods.SelectedDataKey("RC_ID")
        objPropHdr.Function_ID = grdBuildingGoods.SelectedDataKey("Function_ID")
        objPropHdr.TD_ID = 2
        objPropHdr.Project_ID = grdBuildingGoods.SelectedDataKey("Project_ID")
        objPropHdr.Program_id = grdBuildingGoods.SelectedDataKey("Program_id")
        objPropHdr.Particular = grdBuildingGoods.SelectedDataKey("Item_Desc")

        objPropDtl.type = grdBuildingGoods.SelectedDataKey("type")
    End Sub

    'LAND SAVING 
    Protected Sub LoadLandDetailsSaving()
        dtLandDtl = objLandDtl.GetDataTable("select LandId from AMS.TbLand_Dtl where Property_Dtl_ID like '" & PropertyDetai_ID & "' ", CommandType.Text)
        With objLandDtl
            '.LandId = LandId
            .Property_Dtl_ID = PropertyDetai_ID
            .LguCode = txtLandlgucode.Text
            .SectionNo = txtLandSectionno.Text
            .PIN = txtLandPIN.Text
            .TDN = txtLandTdn.Text
            .DistrictCode = txtLanddistrictcode.Text
            .ParcelNo = txtLandParcelno.Text
            .ARP = txtLandARP.Text
            .CityMunCode = txtLandcitymunicipality1.Text
            .SeriesNo = txtLandSeriesno.Text
            .RevYear = txtLandrevyear.Text
            .BarangayCode = txtLandbrgycode.Text
            .RPTIN = txtLandRPTIN.Text
            .DepreciationRate = txtLandDepriciationRate.Text
            .DepreciationValue = txtLandDepreciatedValue.Text
            .LotNo = txtLandlocationLot.Text
            .BlkNo = txtLandlocationblkno.Text
            .StreetName = txtLandlocationstreetname.Text
            .Subdivision = txtLandlocationsubdivisionvillage.Text
            .PhaseNo = txtLandlocationphaseno.Text
            .Purok = txtLandlocationpurok.Text
            .Sitio = txtLandlocationsitio.Text
            .Barangay = txtLandbarangay.Text
            .District = txtLandDistrict.Text
            .CityMunicipal = txtLandCitymunicipality.Text
            .Province = txtLandprovince.Text
            .Region = txtLandRegion.Text
            .ZipCode = txtLandzipcode.Text
            .Classification = txtLandClassification.Text
            .SubClass = txtLandSubClass.Text
            .LandUse = txtLandUse.Text
            .Area = txtLandArea.Text
            .AVAmountWords = txtLandAssessedAmount.Text
            .MVAmountWords = txtLandMarketAmount.Text
            .AssessmentLevel = dpLandAssessmentLvl.SelectedValue
            .Status_1 = txtLandStatus1.Text
            .Status_2 = txtLandStatus2.Text
            '.Status_AIR = ""

            .AssessedValue = txtLandAssessedValue.Text
            .MarketValue = txtLandMarketValue.Text
            .UnitValue = txtLandUnitValue.Text

            If ddwnLandTaxable.SelectedValue = "Select" Then
                .Taxable = ""
            Else
                .Taxable = ddwnLandTaxable.SelectedValue
            End If

            If txtLandAssessedDate.Text = "" Then
                .AssessedDate = "01/01/1900"
            Else
                .AssessedDate = txtLandAssessedDate.Text
            End If

            If txtLandMarketDate.Text = "" Then
                .MarketDate = "01/01/1900"
            Else
                .MarketDate = txtLandMarketDate.Text
            End If

            If txtLandUnitDate.Text = "" Then
                .UnitDate = "01/01/1900"
            Else
                .UnitDate = txtLandUnitDate.Text
            End If

        End With

        If dtLandDtl.Rows.Count = 0 Then
            objLandDtl.LandId = 0
            objLandDtl.save()
            LandId = objLandDtl.GetValue("Select max(LandId) from AMS.TbLand_Dtl ", CommandType.Text)
        Else
            LandId = objLandDtl.GetValue("select LandId from AMS.TbLand_Dtl where Property_Dtl_ID like '" & PropertyDetai_ID & "' ", CommandType.Text)
            objLandDtl.LandId = LandId
            objLandDtl.update()
        End If
    End Sub
    Protected Sub LoadLandTechDescSaving()
        dtLandTech = objLandTech.GetDataTable("select top 1 TechDescriptionId from AMS.TbLand_TechDescription where LandId like '" & LandId & "' ", CommandType.Text)
        With objLandTech
            'objLandTech.TechDescriptionId = TechDescriptionId
            objLandTech.LandId = LandId
            objLandTech.OctNo = txttechnicaloctno.Text
            objLandTech.TctNo = txttechnicaltctno.Text
            objLandTech.iDate = txttechnicalDate.Text
            objLandTech.DateRegistered = txttechnicaldateregistered.Text
            objLandTech.CadastralNo = txttechnicalcadastralno.Text
            objLandTech.BrgyBounderyMonu = txtLandBBM.Text
            objLandTech.North = txttechnicalNorth.Text
            objLandTech.East = txttechnicalEast.Text
            objLandTech.South = txttechnicalSouth.Text
            objLandTech.West = txttechnicalwest.Text
            'objLandTech.StartingPt = ""
            'objLandTech.EndingPt = ""
            'objLandTech.NS = ""
            'objLandTech.NS1 = ""
            'objLandTech.NS2 = ""
            'objLandTech.WE = ""
            'objLandTech.mDistance = ""
            If dtLandTech.Rows.Count = 0 Then
                objLandTech.TechDescriptionId = 0
                objLandTech.save()
                TechDescriptionId = objLandTech.GetValue("Select max(TechDescriptionId) from AMS.TbLand_TechDescription ", CommandType.Text)
            Else
                TechDescriptionId = dtLandTech.Rows(0)(0) 'objLandTech.GetValue("Select TechDescriptionId from AMS.TbLand_TechDescription where LandId like '" & LandId & "' ", CommandType.Text)
                objLandTech.TechDescriptionId = TechDescriptionId
                objLandTech.update()
            End If

            objLandTech.Execute("Delete from AMS.TbLand_TechDescriptionTable where TechDescriptionId = '" & TechDescriptionId & "'", CommandType.Text)
            For i As Integer = 0 To grdLandTechDesc.Rows.Count - 1
                If CType(grdLandTechDesc.Rows(i).FindControl("txtStartingPT"), TextBox).Text = "" Or CType(grdLandTechDesc.Rows(i).FindControl("txtEndingPT"), TextBox).Text = "" Then
                    ' Nothing
                Else
                    objLandTech.TechDescriptionId = TechDescriptionId
                    objLandTech.StartingPt = CType(grdLandTechDesc.Rows(i).FindControl("txtStartingPT"), TextBox).Text
                    objLandTech.EndingPt = CType(grdLandTechDesc.Rows(i).FindControl("txtEndingPT"), TextBox).Text
                    objLandTech.NS = CType(grdLandTechDesc.Rows(i).FindControl("txtNS"), TextBox).Text
                    objLandTech.NS1 = CType(grdLandTechDesc.Rows(i).FindControl("txtns1"), TextBox).Text
                    objLandTech.NS2 = CType(grdLandTechDesc.Rows(i).FindControl("txtns2"), TextBox).Text
                    objLandTech.WE = CType(grdLandTechDesc.Rows(i).FindControl("txtwe"), TextBox).Text
                    objLandTech.mDistance = CType(grdLandTechDesc.Rows(i).FindControl("txtm"), TextBox).Text
                    objLandTech.Execute("Insert into AMS.TbLand_TechDescriptionTable values ('" & objLandTech.TechDescriptionId & "','" & objLandTech.StartingPt & "', '" & objLandTech.EndingPt & "', '" & objLandTech.NS & "', '" & objLandTech.NS1 & "', '" & objLandTech.NS2 & "', '" & objLandTech.WE & "', '" & objLandTech.mDistance & "')", CommandType.Text)
                End If
            Next
        End With
    End Sub
    Protected Sub grdLandTechDesc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub LoadLandOwnerHistorySaving()
        dtLandOwner = objLandOwner.GetDataTable("Select OwnershipId from AMS.TbLand_TechDescription where LandId like '" & LandId & "' ", CommandType.Text)
        With objLandOwner
            objLandOwner.LandId = LandId
            objLandOwner.CorporationName = txthistoryownershipcorporationname.Text
            objLandOwner.CorporationAddress = txthistoryownershipAddress.Text
            objLandOwner.TelephoneNo = txthistoryownershiptelephoneno.Text
            objLandOwner.CellphoneNo = txthistoryownershipcellphone.Text
            objLandOwner.EmailAddress = txthistoryownershipemailaddress.Text
            objLandOwner.Chairman = txthistoryownershipchairman.Text
            objLandOwner.ViceChairman = txthistoryownershipvicechairman.Text
            objLandOwner.President = txthistoryownershippresident.Text
            objLandOwner.SeniorVicePresident = txthistoryownershipseniorvicepresident.Text
            objLandOwner.ViceChairman = txthistoryownershipadminvicepresident.Text
            'objLandOwner.AssistantVicePresident = ""
            objLandOwner.CorporateSecretary = txthistoryownershipcorporatesecretary.Text
        End With

        If dtLandOwner.Rows.Count = 0 Then
            objLandOwner.OwnershipId = 0
            objLandOwner.save()
            TechDescriptionId = objLandOwner.GetValue("Select max(OwnershipId) from AMS.TbLand_OwnerHistory ", CommandType.Text)
        Else
            OwnershipId = objLandOwner.GetValue("Select OwnershipId from AMS.TbLand_OwnerHistory where LandId like '" & LandId & "' ", CommandType.Text)
            objLandOwner.OwnershipId = OwnershipId
            objLandOwner.update()
        End If


        'objLandOwner.Execute("Delete from AMS.TbLand_OwnerHistory where LandId = '" & LandId & "'", CommandType.Text)
        'For i As Integer = 0 To grdownership.Rows.Count - 1
        '    If CType(grdownership.Rows(i).FindControl("txtStartingPT"), TextBox).Text = "" Or CType(grdownership.Rows(i).FindControl("txtEndingPT"), TextBox).Text = "" Then
        '        ' Nothing
        '    Else
        '        objLandOwner.LandId = LandId
        '        objLandOwner.StartingPt = CType(grdownership.Rows(i).FindControl("txtStartingPT"), TextBox).Text
        '        objLandOwner.EndingPt = CType(grdownership.Rows(i).FindControl("txtEndingPT"), TextBox).Text
        '        objLandOwner.NS = CType(grdownership.Rows(i).FindControl("txtNS"), TextBox).Text
        '        objLandOwner.NS1 = CType(grdownership.Rows(i).FindControl("txtns1"), TextBox).Text
        '        objLandOwner.NS2 = CType(grdownership.Rows(i).FindControl("txtns2"), TextBox).Text
        '        objLandOwner.WE = CType(grdownership.Rows(i).FindControl("txtwe"), TextBox).Text
        '        objLandOwner.mDistance = CType(grdownership.Rows(i).FindControl("txtm"), TextBox).Text
        '        objLandOwner.Execute("Insert into AMS.TbLand_OwnerHistory values ('" & objLandTech.TechDescriptionId & "','" & objLandTech.StartingPt & "', '" & objLandTech.EndingPt & "', '" & objLandTech.NS & "', '" & objLandTech.NS1 & "', '" & objLandTech.NS2 & "', '" & objLandTech.WE & "', '" & objLandTech.mDistance & "')", CommandType.Text)
        '    End If
        'Next


    End Sub
    Protected Sub LoadLandValuationSaving()
        dtLandValuation = objLandValuation.GetDataTable("select top 1 ValuationId from AMS.TbLand_Valuation where LandId = '" & LandId & "' ", CommandType.Text)
        With objLandValuation
            'objLandTech.ValuationId = ValuationId
            objLandValuation.LandId = LandId
            objLandValuation.Classification = txtLandValClass.Text
            objLandValuation.SubClassification = txtLandValSubClass.Text
            objLandValuation.Area = txtLandValArea.Text
            objLandValuation.Unit = txtLandValUnit.Text
            objLandValuation.UnitValue = txtLandValUnitValue.Text
            objLandValuation.BaseMarketValue = txtLandValBMV.Text
            objLandValuation.Taxable = txtLandValTaxable.Text
            objLandValuation.Adjustments = txtLandValAdjustment.Text
            objLandValuation.AdjustedMarketValue = txtLandValAMV.Text
            objLandValuation.Strip = txtLandValStrip.Text
            objLandValuation.AdjUnitValue = txtLandValAUV.Text
        End With
        If dtLandValuation.Rows.Count = 0 Then
            objLandValuation.ValuationId = 0
            objLandValuation.save()
            TechDescriptionId = objLandValuation.GetValue("Select max(ValuationId) from AMS.TbLand_Valuation ", CommandType.Text)
        Else
            ValuationId = dtLandValuation.Rows(0)(0) 'objLandTech.GetValue("Select TechDescriptionId from AMS.TbLand_TechDescription where LandId like '" & LandId & "' ", CommandType.Text)
            objLandValuation.ValuationId = ValuationId
            objLandValuation.update()
        End If
    End Sub

    'LAND DOCUMENT ATTACHMENT SAVING 
    Protected Sub btnAttachdoc2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim filePath As String = hdfAttachDoc2.Value
        Dim filename As String = Path.GetFileName(filePath)
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
        br.Close()
        fs.Close()
        If Me.hdfAttachDoc2.Value <> "" Then
            ImageDocument.IdentityNo = grdLandGoods.SelectedDataKey(1)
            ImageDocument.Imagefile = bytes
            ImageDocument.DocumentName = txtattachdocumentname.Text
            ImageDocument.DocumentNo = txtattachDocumentNo.Text
            ImageDocument.ValidatedBy = txtattachvalidatedby.Text

            If txtattachdatevaidated.Text = "" Then
                ImageDocument.DateValidated = Date.Today.ToString("MM/dd/yyyy")
            Else
                ImageDocument.DateValidated = txtattachdatevaidated.Text
            End If
            ImageDocument.Remarks = txtattachremarks.Text
            ImageDocument.TableName = "AIR_LandAttchDocu"
            Dim Id As Long = ImageDocument.SaveImage()
            imgattach.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & Id

        End If
        'Clear TextBox
        txtattachdocumentname.Text = ""
        txtattachDocumentNo.Text = ""
        txtattachvalidatedby.Text = ""
        txtattachdatevaidated.Text = ""
        txtattachremarks.Text = ""
        'Clear TextBox
        Dim AttachDocument As New DataTable
        AttachDocument = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = " & grdLandGoods.SelectedDataKey(1) & "and TableName='AIR_LandAttchDocu'", CommandType.Text)
        Dim rows As New Integer
        rows = AttachDocument.Rows.Count
        AttachDocument.Merge(createdatatableAttch(4 - rows))
        Me.grdLandAttachdoc.DataSource = AttachDocument
        grdLandAttachdoc.DataBind()
    End Sub
    Protected Sub grdLandAttachdoc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadLandAttch_ChangeIndex()
    End Sub
    Protected Sub LoadLandAttch_ChangeIndex()
        btntechnicaldescription.CssClass = "Initial"
        btnLandDocument.CssClass = "Initial"
        btnHistory.CssClass = "Initial"
        btnlandvalue.CssClass = "Initial"
        bntapproval.CssClass = "Initial"
        btnimprovements.CssClass = "Initial"
        btnmemoranda.CssClass = "Initial"
        bntDocumentAttach.CssClass = "Clicked"

        Try
            Dim id As New Integer
            id = grdLandAttachdoc.SelectedDataKey(1).ToString
            imgattach.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & id
        Catch ex As Exception
            imgattach.ImageUrl = "~/images/Blankimage.jpg"
        End Try
        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwAttachedDocument)
    End Sub
    Protected Sub grdLandAttachdoc_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdLandAttachdoc, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    'LAND DOCUMENT SAVING 
    Protected Sub btnAddlist_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim filePath As String = hdfAttachDoc1.Value
        Dim filename As String = Path.GetFileName(filePath)
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
        br.Close()
        fs.Close()

        If Me.hdfAttachDoc1.Value <> "" Then
            Dim dtland As New DataTable
            dtland = objDerived.GetDataTable("select * from dbo.View_AIR_LandDocu where PODtl_ID like '" & grdLandGoods.SelectedDataKey(1) & "' ", CommandType.Text)
            LandDocument.LandId = dtland.Rows(0).Item(0)

            LandDocument.IdentityNo = grdLandGoods.SelectedDataKey(1)
            LandDocument.Imagefile = bytes
            LandDocument.Agency = txtLandAgency.Text
            LandDocument.DocumentName = txtDocumentname.Text
            LandDocument.DocumentNo = txtdocumentno.Text
            LandDocument.ValidatedBy = txtvalidatedby.Text

            If txtdatevalidated.Text = "" Then
                LandDocument.DateValidated = Date.Today.ToString("MM/dd/yyyy")
            Else
                LandDocument.DateValidated = txtdatevalidated.Text
            End If

            LandDocument.Remarks = txtdocremarks.Text
            LandDocument.TableName = "AIR_LandDocu"
            Dim Id As Long = LandDocument.SaveImage()
            imgLandDoc.ImageUrl = "~/Handler/ShowLandDocument.ashx?id=" & Id

            'If dtLandDocu.Rows.Count = 0 Then
            '    LandDocument.LandDocuId = 0
            '    Dim Id As Long = LandDocument.SaveImage()
            '    imgLandDoc.ImageUrl = "~/Handler/ShowLandDocument.ashx?id=" & Id
            'Else
            '    LandDocument.LandDocuId = LandDocuId
            '    Dim Id As Long = LandDocument.UpdateImage()
            '    imgLandDoc.ImageUrl = "~/Handler/ShowLandDocument.ashx?id=" & Id
            'End If

        End If
        txtLandAgency.Text = ""
        txtDocumentname.Text = ""
        txtdocumentno.Text = ""
        txtvalidatedby.Text = ""
        txtdatevalidated.Text = ""
        txtdocremarks.Text = ""

        Dim AttachDocument As New DataTable
        AttachDocument = objDerived.GetDataTable("Select * from AMS.TbLand_LandDocu where IdentityNo = " & grdLandGoods.SelectedDataKey(1) & "  and TableName='AIR_LandDocu'", CommandType.Text)
        Dim rows As New Integer
        rows = AttachDocument.Rows.Count
        AttachDocument.Merge(createdatatable12(4 - rows))
        grdLandDocu.DataSource = AttachDocument
        grdLandDocu.DataBind()
        grdLandDocu.SelectedIndex = 0
    End Sub
    Protected Sub btnBuildingBrowse_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub grdLandDocu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadLandDocu_ChangeIndex()
    End Sub
    Protected Sub LoadLandDocu_ChangeIndex()
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
            id = grdLandDocu.SelectedDataKey(1).ToString
            imgLandDoc.ImageUrl = "~/Handler/ShowLandDocument.ashx?id=" & id
        Catch ex As Exception
            imgLandDoc.ImageUrl = "~/images/Blankimage.jpg"
        End Try
        Me.MvLandInspectionAccptnce.SetActiveView(Me.vwLandDocument)
    End Sub
    Protected Sub grdLandDocu_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdLandDocu, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub hdfAttachDoc1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    ' *** Document Attachment 
    Protected Sub btnOfficeAttchDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim filePath As String = hdfbuilding.Value
        Dim filename As String = Path.GetFileName(filePath)
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
        br.Close()
        fs.Close()
        If Me.hdfbuilding.Value <> "" Then
            ImageDocument.PropertyDetai_ID = PropertyDetai_ID
            ImageDocument.Imagefile = bytes
            ImageDocument.DocumentName = txtOfficeDocName.Text
            ImageDocument.DocumentNo = txtOfficeDocNo.Text
            ImageDocument.ValidatedBy = txtOfficeValidatedBy.Text

            If txtOfficeDateValidated.Text = "" Then
                ImageDocument.DateValidated = Date.Today.ToString("MM/dd/yyyy")
            Else
                ImageDocument.DateValidated = txtOfficeDateValidated.Text
            End If
            ImageDocument.Remarks = txtOfficeRemarks.Text
            ImageDocument.IdentityNo = grdInspection.SelectedDataKey("POHdr_ID")

            If grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Then ' EQUIPMENTS  
                ImageDocument.TableName = "AIR_EquipAttchDocu"
            ElseIf grdInspection.SelectedDataKey(0) = 534 Then ' FURNITURE AND FIXTURES
                ImageDocument.TableName = "AIR_FurAttchDocu"
            ElseIf grdInspection.SelectedDataKey(0) = 537 Then ' MACHINERIES
                ImageDocument.TableName = "AIR_MachineAttchDocu"
            ElseIf grdInspection.SelectedDataKey(0) = 549 Then ' MOTORS
                ImageDocument.TableName = "AIR_MotorAttchDocu"
            ElseIf grdInspection.SelectedDataKey(0) = 788 Then ' OFFICE SUPPLIES
                ImageDocument.TableName = "AIR_OfficeAttchDocu"
            ElseIf grdInspection.SelectedDataKey(0) = 793 Or grdInspection.SelectedDataKey(0) = 792 Then ' MEDICINES
                ImageDocument.TableName = "AIR_MedAttchDocu"
            ElseIf grdInspection.SelectedDataKey(0) = 791 Or grdInspection.SelectedDataKey(0) = 799 Or grdInspection.SelectedDataKey(0) = 798 Or grdInspection.SelectedDataKey(0) = 927 Then
                ImageDocument.TableName = "AIR_SupplyAttchDocu"
            End If

            Dim Id As Long = ImageDocument.SaveImage()
            imgOfficeSupp.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & Id

        End If
        'Clear TextBox
        txtOfficeDocName.Text = ""
        txtOfficeDocNo.Text = ""
        txtOfficeValidatedBy.Text = ""
        txtOfficeDateValidated.Text = ""
        txtOfficeRemarks.Text = ""

        LoadAttchDoc()
    End Sub
    Protected Sub grdSuppAttchDoc_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdSuppAttchDoc, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdSuppAttchDoc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadAttachDoc_IndexChange()
    End Sub
    Protected Sub LoadAttachDoc_IndexChange()
        Try
            Dim id As New Integer
            id = grdSuppAttchDoc.SelectedDataKey(1).ToString
            imgOfficeSupp.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & id
        Catch ex As Exception
            imgOfficeSupp.ImageUrl = "~/images/Blankimage.jpg"
        End Try
    End Sub
    Protected Sub LoadAttchDoc()
        Me.mvAttachments.SetActiveView(Me.vwAttchDoc)

        Dim dtAttchDoc As New DataTable
        Dim dt As New DataTable
        If grdInspection.SelectedDataKey(0) = 788 Then ' OFFICE SUPPLIES  
            dtAttchDoc = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = '" & grdInspection.SelectedDataKey("POHdr_ID") & "' and TableName='AIR_OfficeAttchDocu'", CommandType.Text)
        ElseIf grdInspection.SelectedDataKey(0) = 793 Or grdInspection.SelectedDataKey(0) = 792 Then ' MEDICINES
            dtAttchDoc = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = '" & grdInspection.SelectedDataKey("POHdr_ID") & "' and TableName='AIR_MedAttchDocu'", CommandType.Text)
        ElseIf grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Or grdInspection.SelectedDataKey(0) = 540 Or grdInspection.SelectedDataKey(0) = 543 Then 'EQUIPMENTS  
            dtAttchDoc = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = '" & grdInspection.SelectedDataKey("POHdr_ID") & "' and TableName='AIR_EquipAttchDocu'", CommandType.Text)
        ElseIf grdInspection.SelectedDataKey(0) = 534 Then 'FURNITURE AND FIXTURES
            dtAttchDoc = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = '" & grdInspection.SelectedDataKey("POHdr_ID") & "' and TableName='AIR_FurAttchDocu'", CommandType.Text)
        ElseIf grdInspection.SelectedDataKey(0) = 537 Then 'MACHINERIES
            dtAttchDoc = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = '" & grdInspection.SelectedDataKey("POHdr_ID") & "' and TableName='AIR_MachineAttchDocu'", CommandType.Text)
        ElseIf grdInspection.SelectedDataKey(0) = 549 Then ' MOTORS
            dtAttchDoc = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = '" & grdInspection.SelectedDataKey("POHdr_ID") & "' and TableName='AIR_MotorAttchDocu'", CommandType.Text)
        ElseIf grdInspection.SelectedDataKey(0) = 791 Or grdInspection.SelectedDataKey(0) = 799 Or grdInspection.SelectedDataKey(0) = 798 Or grdInspection.SelectedDataKey(0) = 927 Then
            dtAttchDoc = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = '" & grdInspection.SelectedDataKey("POHdr_ID") & "' and TableName='AIR_SupplyAttchDocu'", CommandType.Text)
        End If

        Dim rows As New Integer
        rows = dtAttchDoc.Rows.Count
        dtAttchDoc.Merge(createdatatableAttch(4 - rows))
        grdSuppAttchDoc.DataSource = dtAttchDoc
        grdSuppAttchDoc.DataBind()
        grdSuppAttchDoc.SelectedIndex = 0

        LoadAttachDoc_IndexChange()
    End Sub

    ' *** CLEAR TEXT / BUTTON OPTIONS 
    Protected Sub LoadClearText()
        txtsupplier.Text = ""
        txtPOnum.Text = ""
        txtpoDate.Text = ""
        txtdepartment.Text = ""
        lblairno.Text = ""
        txtInvoiceDate.Text = ""
        txtinvoiceNo.Text = ""
        txtremaks.Text = ""
        txtInspectedDate.Text = ""
        txtAcceptedDate.Text = ""
        'rbStatus.SelectedValue = ""

        LoadSignatory()
        btninspectedsave.Enabled = True
        btnInspectedPreview.Enabled = False
        btnacceptancesave.Enabled = False
        btnacceptancepreview.Enabled = False
        btnacknowledgementpost.Enabled = False
        btnacknowledgementpreview.Enabled = False
    End Sub
    Protected Sub LoadSignatory()
        Dim dtsignatory As New DataTable
        dtsignatory = objDerived.GetDataTable("Select 'Select' as full_name, 1 as rowno union SELECT full_name  as full_name,empid  " & _
                                              "from [dbo].[view_signatory1] where deptid = 7 and division_key = 86 order BY rowno", CommandType.Text)
        ddinspector1.DataSource = dtsignatory
        'ddinspector1.Items.Add("Select")
        ddinspector1.DataTextField = ("full_name")
        'ddinspector1.DataValueField = ("Signatory_ID")
        ddinspector1.DataBind()

        ddinspector2.DataSource = dtsignatory
        'ddinspector2.Items.Add("Select")
        ddinspector2.DataTextField = ("full_name")
        'ddinspector2.DataValueField = ("Signatory_ID")
        ddinspector2.DataBind()

        ddacceptance.DataSource = dtsignatory
        'ddacceptance.Items.Add("Select")
        ddacceptance.DataTextField = ("full_name")
        'ddacceptance.DataValueField = ("Signatory_ID")
        ddacceptance.DataBind()

        ddAcknowledgement.DataSource = dtsignatory
        'ddAcknowledgement.Items.Add("Select")
        ddAcknowledgement.DataTextField = ("full_name")
        'ddacceptance.DataValueField = ("Signatory_ID")
        ddAcknowledgement.DataBind()

    End Sub
    Protected Sub LoadNoDisplay()
        txtsupplier.Text = ""
        txtPOnum.Text = ""
        txtpoDate.Text = ""
        txtdepartment.Text = ""
        lblairno.Text = ""
        Me.mvPurchasedetailedInfo.Visible = False

        btninspectedsave.Enabled = False
        btnInspectedPreview.Enabled = False
        btnacknowledgementpost.Enabled = False
        btnacknowledgementpreview.Enabled = False
    End Sub
    Protected Sub LoadButtonEnable()
        btnInspectedPreview.Enabled = True
        btnacceptancesave.Enabled = True
    End Sub
    Protected Sub LoadButtonEnable2()
        Dim dtstock1 As New DataTable
        If grdInspection.SelectedDataKey(0) = 533 Or grdInspection.SelectedDataKey(0) = 535 Then ' EQUIPMENTS
            dtstock1 = objDerived.GetDataTable("select Property_ID from AMS.Property where Item_ID = '" & grdEuipment_Serial.SelectedDataKey(0) & "' ", CommandType.Text)

        ElseIf grdInspection.SelectedDataKey(0) = 549 Then ' MOTORS
            dtstock1 = objDerived.GetDataTable("select Property_ID from AMS.Property where Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "' ", CommandType.Text)

        ElseIf grdInspection.SelectedDataKey(0) = 537 Then ' MACHINERIES
            dtstock1 = objDerived.GetDataTable("select Property_ID from AMS.Property where Item_ID = '" & grdMachineries_Serial.SelectedDataKey(0) & "' ", CommandType.Text)

        ElseIf grdInspection.SelectedDataKey(0) = 534 Then ' FURNITURE AND FIXTURES
            dtstock1 = objDerived.GetDataTable("select Property_ID from AMS.Property where Item_ID = '" & grdFurniture_Serial.SelectedDataKey(0) & "' ", CommandType.Text)

        ElseIf grdInspection.SelectedDataKey(0) = 788 Then ' OFFICE SUPPLIES
            dtstock1 = objDerived.GetDataTable("select StockId from AMS.Stock where Item_ID = '" & grdOfficeSupp.SelectedDataKey(0) & "' ", CommandType.Text)

        ElseIf grdInspection.SelectedDataKey(0) = 793 Or grdInspection.SelectedDataKey(0) = 792 Then ' MEDICINE
            dtstock1 = objDerived.GetDataTable("select StockId from AMS.Stock where Item_ID = '" & grdmedicalsupplies.SelectedDataKey(0) & "' ", CommandType.Text)
        End If

        If dtstock1.Rows.Count = 0 Then
            btnacceptancepreview.Enabled = False
            btnacknowledgementpost.Enabled = False
            btnacknowledgementpreview.Enabled = False
        Else
            btnInspectedPreview.Enabled = True
            btnacceptancesave.Enabled = True
            'If rbStatus.SelectedValue = 0 Then
            '    btnacceptancepreview.Enabled = False
            'Else
            '    btnacceptancepreview.Enabled = True
            '    btnacknowledgementpost.Enabled = True
            'End If
        End If

    End Sub
    Protected Sub LoadButtonDisable()
        btnInspectedPreview.Enabled = False
        btnacceptancesave.Enabled = False
        btnacceptancepreview.Enabled = False
        btnacknowledgementpost.Enabled = False
        btnacknowledgementpreview.Enabled = False
    End Sub
    Protected Sub LoadExpiryDetails1()
        txtMedName.Enabled = True
        txtMedDose.Enabled = True
        txtMedForm.Enabled = True
        txtMedExpiredDate.Enabled = True
        txtMedMftgdate.Enabled = True
        txtMedBatch.Enabled = True
        txtMedLot.Enabled = True
        txtMedAlertDate.Enabled = True
        txtMedOTCRX.Enabled = True

        txtMedName.Text = ""
        txtMedDose.Text = ""
        txtMedForm.Text = ""
        txtMedOTCRX.Text = ""
        txtMedExpiredDate.Text = ""
        txtMedMftgdate.Text = ""
        txtMedBatch.Text = ""
        txtMedLot.Text = ""
        txtMedAlertDate.Text = ""
    End Sub
    Protected Sub LoadExpiryDetails2()
        txtMedName.Enabled = False
        txtMedDose.Enabled = False
        txtMedForm.Enabled = False
        txtMedExpiredDate.Enabled = False
        txtMedMftgdate.Enabled = False
        txtMedBatch.Enabled = False
        txtMedLot.Enabled = False
        txtMedAlertDate.Enabled = False
        txtMedOTCRX.Enabled = False

        txtMedOTCRX.Text = " - NA -"
        txtMedName.Text = " - NA -"
        txtMedDose.Text = " - NA -"
        txtMedForm.Text = " - NA -"
        txtMedExpiredDate.Text = " - NA -"
        txtMedMftgdate.Text = " - NA -"
        txtMedBatch.Text = " - NA -"
        txtMedLot.Text = " - NA -"
        txtMedAlertDate.Text = " - NA -"
    End Sub

    'SEARCH OPTIONS
    Protected Sub btnSearchPO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dtsearch As New DataTable

        'If Drpsearch.Text = 1 Then
        '    Dim dtInspect As New DataTable
        '    dtInspect = objDerived.GetDataTable("Select * from [dbo].[View_InspectionAcceptance] order BY PO_Date desc", CommandType.Text)
        '    If dtInspect.Rows.Count < 8 Then
        '        dtInspect.Merge(createdatatable1(7 - dtInspect.Rows.Count))
        '    End If
        '    grdInspection.DataSource = dtInspect
        '    grdInspection.DataBind()
        '    grdInspection.SelectedIndex = 0

        '    MutiviewSelected()
        '    LoadSignatory()

        'Else


        Try
            If txtPOsearch.Text = "" Then
                txtPOsearch.Text = "0000"
            ElseIf txtPOsearch.Text.Length = 2 Then
                txtPOsearch.Text = "00" + txtPOsearch.Text
            ElseIf txtPOsearch.Text.Length = 1 Then
                txtPOsearch.Text = "000" + txtPOsearch.Text
            ElseIf txtPOsearch.Text.Length = 3 Then
                txtPOsearch.Text = "0" + txtPOsearch.Text
            Else
                txtPOsearch.Text = txtPOsearch.Text

            End If
        Catch ex As Exception
        End Try


        If Drpsearch.Text = 2 Then
            If txtPOsearch.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please input purchase order number.")
            Else
                dtsearch = objDerived.GetDataTable("Exec [dbo].[sp_InspectionAcceptance] '" & txtPOsearch.Text & "','" & 1 & "'", CommandType.Text)
                If dtsearch.Rows.Count < 8 Then
                    dtsearch.Merge(createdatatable1(7 - dtsearch.Rows.Count))
                End If
                grdInspection.DataSource = dtsearch
                grdInspection.DataBind()
                grdInspection.SelectedIndex = 0
                'Else
                '    grdInspection.DataSource = objDerived.GetDataTable("Select * from [dbo].[View_InspectionAcceptance] order BY PO_Date desc", CommandType.Text)
                '    grdInspection.DataBind()
                '    grdInspection.SelectedIndex = 0
                'End If
                MutiviewSelected()
                LoadSignatory()
            End If
        ElseIf Drpsearch.Text = 3 Then
            If txtPOsearch.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please input purchase number number.")
            Else
                dtsearch = objDerived.GetDataTable("Exec [dbo].[sp_InspectionAcceptance] '" & txtPOsearch.Text & "','" & 0 & "'", CommandType.Text)
                If dtsearch.Rows.Count < 8 Then
                    dtsearch.Merge(createdatatable1(7 - dtsearch.Rows.Count))
                End If
                grdInspection.DataSource = dtsearch
                grdInspection.DataBind()
                grdInspection.SelectedIndex = 0
                'Else
                '    grdInspection.DataSource = objDerived.GetDataTable("Select * from [dbo].[View_InspectionAcceptance] order BY PO_Date desc", CommandType.Text)
                '    grdInspection.DataBind()
                '    grdInspection.SelectedIndex = 0
                'End If
                MutiviewSelected()
                LoadSignatory()
            End If
        End If
    End Sub
    Protected Sub Drpsearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        loadcat()
    End Sub
    Protected Sub loadcat()
        If Me.Drpsearch.Text = 1 Then
            lblSearch.Text = "Search :"
            txtPOsearch.Enabled = False
            txtPOsearch.Text = "Category"
            ddCategories.Enabled = True
            txtPOsearch.Enabled = False
            RadioButtonList3.Enabled = True

            LoadCategories()

        ElseIf Me.Drpsearch.Text = 2 Then
            lblSearch.Text = "Purchase Order No. :"
            txtPOsearch.Enabled = True
            txtPOsearch.Text = ""
            ddCategories.Enabled = False
            RadioButtonList3.Enabled = False

        ElseIf Me.Drpsearch.Text = 3 Then
            lblSearch.Text = "Purchase Request No:"
            txtPOsearch.Enabled = True
            txtPOsearch.Text = ""
            ddCategories.Enabled = False
            RadioButtonList3.Enabled = False

        ElseIf Me.Drpsearch.Text = 4 Then
            lblSearch.Text = "Search :"
            txtPOsearch.Text = "ALL"
            ddCategories.Enabled = False
            txtPOsearch.Enabled = False
            RadioButtonList3.Enabled = False

            Dim dtInspect As New DataTable
            dtInspect = objDerived.GetDataTable("Exec [dbo].[sp_InspectionAcceptance_v2] '" & 0 & "', '" & 1 & "'", CommandType.Text)
            If dtInspect.Rows.Count < 8 Then
                dtInspect.Merge(createdatatable1(7 - dtInspect.Rows.Count))
            End If
            grdInspection.DataSource = dtInspect
            grdInspection.DataBind()
            grdInspection.SelectedIndex = 0

            LoadGA_IDSelection()

        End If
    End Sub

    'CreateDataTable 
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("ReqDept", GetType(String))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("ProjectName", GetType(String))
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("PO_Date", GetType(String))
        dt.Columns.Add("PO_Amount", GetType(Decimal))
        dt.Columns.Add("dvno", GetType(String))
        dt.Columns.Add("checkno", GetType(String))
        dt.Columns.Add("amountpaid", GetType(Decimal))
        dt.Columns.Add("jevno", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = DBNull.Value
            dr("ReqDept") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("ProjectName") = DBNull.Value
            dr("PO_No") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("PO_Amount") = DBNull.Value
            dr("dvno") = DBNull.Value
            dr("checkno") = DBNull.Value
            dr("amountpaid") = DBNull.Value
            dr("jevno") = DBNull.Value
            dr("POHdr_ID") = 0
            dr("GA_ID") = 0
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("typeofservice", GetType(String))
        dt.Columns.Add("plateno", GetType(String))
        dt.Columns.Add("datepurchased", GetType(String))
        dt.Columns.Add("acquisitioncost", GetType(Decimal))
        dt.Columns.Add("marketvalue", GetType(Decimal))
        dt.Columns.Add("condition", GetType(String))
        dt.Columns.Add("location", GetType(String))
        dt.Columns.Add("status", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("typeofservice") = DBNull.Value
            dr("plateno") = DBNull.Value
            dr("datepurchased") = DBNull.Value
            dr("acquisitioncost") = DBNull.Value
            dr("marketvalue") = DBNull.Value
            dr("condition") = DBNull.Value
            dr("location") = DBNull.Value
            dr("status") = DBNull.Value

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("documentname", GetType(String))
        dt.Columns.Add("documentno", GetType(String))
        dt.Columns.Add("validatedby", GetType(String))
        dt.Columns.Add("datevalidated", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("documentname") = DBNull.Value
            dr("documentno") = DBNull.Value
            dr("validatedby") = DBNull.Value
            dr("datevalidated") = DBNull.Value
            dr("remarks") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable4(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("typeofservice", GetType(String))
        dt.Columns.Add("plateno", GetType(String))
        dt.Columns.Add("datepurchased", GetType(String))
        dt.Columns.Add("acquisitioncost", GetType(Decimal))
        dt.Columns.Add("marketvalue", GetType(Decimal))
        dt.Columns.Add("condition", GetType(String))
        dt.Columns.Add("location", GetType(String))
        dt.Columns.Add("status", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("typeofservice") = DBNull.Value
            dr("plateno") = DBNull.Value
            dr("datepurchased") = DBNull.Value
            dr("acquisitioncost") = DBNull.Value
            dr("marketvalue") = DBNull.Value
            dr("condition") = DBNull.Value
            dr("location") = DBNull.Value
            dr("status") = DBNull.Value

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
        dt.Columns.Add("ownershiptype", GetType(String))
        dt.Columns.Add("address", GetType(String))
        dt.Columns.Add("typeofacquisition", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("year") = DBNull.Value
            dr("ownername") = DBNull.Value
            dr("ownershiptype") = DBNull.Value
            dr("address") = DBNull.Value
            dr("typeofacquisition") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable6(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("profeesionalcontractor", GetType(String))
        dt.Columns.Add("name", GetType(String))
        dt.Columns.Add("address", GetType(String))
        dt.Columns.Add("telephoneno", GetType(String))
        dt.Columns.Add("cellphoneno", GetType(String))
        dt.Columns.Add("emailaddress", GetType(String))
        dt.Columns.Add("prcno", GetType(String))
        dt.Columns.Add("pirno", GetType(String))
        dt.Columns.Add("validity", GetType(String))
        dt.Columns.Add("dateissued", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("profeesionalcontractor") = DBNull.Value
            dr("name") = DBNull.Value
            dr("address") = DBNull.Value
            dr("telephoneno") = DBNull.Value
            dr("cellphoneno") = DBNull.Value
            dr("emailaddress") = DBNull.Value
            dr("prcno") = DBNull.Value
            dr("pirno") = DBNull.Value
            dr("validity") = DBNull.Value
            dr("dateissued") = DBNull.Value
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
        dt.Columns.Add("occupantname", GetType(String))
        dt.Columns.Add("businessname", GetType(String))
        dt.Columns.Add("floorarea", GetType(String))
        dt.Columns.Add("ownership", GetType(String))
        dt.Columns.Add("category", GetType(String))
        dt.Columns.Add("permittype", GetType(String))
        dt.Columns.Add("permitno", GetType(String))
        dt.Columns.Add("dateofapplication", GetType(String))
        dt.Columns.Add("dateofpermitissuance", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("unitno") = DBNull.Value
            dr("occupantname") = DBNull.Value
            dr("businessname") = DBNull.Value
            dr("floorarea") = DBNull.Value
            dr("ownership") = DBNull.Value
            dr("category") = DBNull.Value
            dr("permittype") = DBNull.Value
            dr("permitno") = DBNull.Value
            dr("dateofapplication") = DBNull.Value
            dr("dateofpermitissuance") = DBNull.Value
            dr("remarks") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable8(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("permittype", GetType(String))
        dt.Columns.Add("dateofapplication", GetType(String))
        dt.Columns.Add("permitno", GetType(String))
        dt.Columns.Add("dateofpermitissuance", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("permittype") = DBNull.Value
            dr("dateofapplication") = DBNull.Value
            dr("permitno") = DBNull.Value
            dr("dateofpermitissuance") = DBNull.Value
            dr("remarks") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable9(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("dateinspection", GetType(String))
        dt.Columns.Add("inspectiontype", GetType(String))
        dt.Columns.Add("missionorderno", GetType(String))
        dt.Columns.Add("inspector", GetType(String))
        dt.Columns.Add("violation", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("dateinspection") = DBNull.Value
            dr("inspectiontype") = DBNull.Value
            dr("missionorderno") = DBNull.Value
            dr("inspector") = DBNull.Value
            dr("violation") = DBNull.Value
            dr("remarks") = DBNull.Value
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
        dt.Columns.Add("date", GetType(String))
        dt.Columns.Add("serviceprovider", GetType(String))
        dt.Columns.Add("natureofrepairs", GetType(String))
        dt.Columns.Add("invoiceno", GetType(String))
        dt.Columns.Add("amount", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("date") = DBNull.Value
            dr("serviceprovider") = DBNull.Value
            dr("natureofrepairs") = DBNull.Value
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
        dt.Columns.Add("LandDocuId", GetType(Long))
        dt.Columns.Add("IdentityNo", GetType(Long))
        dt.Columns.Add("agency", GetType(String))
        dt.Columns.Add("documentname", GetType(String))
        dt.Columns.Add("documentno", GetType(String))
        dt.Columns.Add("validatedby", GetType(String))
        dt.Columns.Add("datevalidated", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("LandDocuId") = DBNull.Value
            dr("IdentityNo") = DBNull.Value
            dr("agency") = DBNull.Value
            dr("documentname") = DBNull.Value
            dr("documentno") = DBNull.Value
            dr("validatedby") = DBNull.Value
            dr("datevalidated") = DBNull.Value
            dr("remarks") = DBNull.Value
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
        dt.Columns.Add("startingpt", GetType(Integer))
        dt.Columns.Add("endingpt", GetType(Integer))
        dt.Columns.Add("ns", GetType(String))
        dt.Columns.Add("ns1", GetType(Integer))
        dt.Columns.Add("ns2", GetType(Integer))
        dt.Columns.Add("we", GetType(String))
        dt.Columns.Add("m", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("startingpt") = DBNull.Value
            dr("endingpt") = DBNull.Value
            dr("ns") = DBNull.Value
            dr("ns1") = DBNull.Value
            dr("ns2") = DBNull.Value
            dr("we") = DBNull.Value
            dr("m") = DBNull.Value

            dt.Rows.Add(dr)

        Next
        Return dt

    End Function
    Public Function createdatatableGoods(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("type", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("DatePurchased", GetType(String))
        dt.Columns.Add("AcquisitionCost", GetType(Decimal))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Status_AIR", GetType(String))
        'dt.Columns.Add("RespCenter", GetType(String))
        'dt.Columns.Add("Location", GetType(String))
        'dt.Columns.Add("MarketValue", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("type") = DBNull.Value
            dr("SerialNo") = DBNull.Value
            dr("DatePurchased") = DBNull.Value
            dr("AcquisitionCost") = DBNull.Value
            dr("Condition") = DBNull.Value
            dr("Status_AIR") = DBNull.Value
            'dr("RespCenter") = DBNull.Value
            'dr("MarketValue") = DBNull.Value
            'dr("Location") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatableGoods2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("type", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("DatePurchased", GetType(String))
        dt.Columns.Add("AcquisitionCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Integer))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("RespCenter", GetType(String))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("Cost", GetType(Decimal))

        dt.Columns.Add("PODtl_ID", GetType(Long))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Long))
        dt.Columns.Add("Project_ID", GetType(Long))
        dt.Columns.Add("Program_id", GetType(Long))
        dt.Columns.Add("Item_Serial_ID", GetType(Long))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Property_Dtl_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("type") = DBNull.Value
            dr("SerialNo") = DBNull.Value
            dr("DatePurchased") = DBNull.Value
            dr("AcquisitionCost") = DBNull.Value
            dr("MarketValue") = DBNull.Value
            dr("Condition") = DBNull.Value
            dr("Location") = DBNull.Value
            dr("Status") = DBNull.Value
            dr("RespCenter") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("PODtl_ID") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("Project_ID") = DBNull.Value
            dr("Program_id") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("Item_Serial_ID") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Property_Dtl_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatableledger(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        dt.Columns.Add("date", GetType(String))
        dt.Columns.Add("transtype", GetType(String))
        dt.Columns.Add("ref", GetType(String))
        dt.Columns.Add("accountableperson", GetType(String))
        dt.Columns.Add("dept_office", GetType(String))
        dt.Columns.Add("position", GetType(String))
        dt.Columns.Add("acceptedby", GetType(String))
        dt.Columns.Add("inspectedby", GetType(String))
        dt.Columns.Add("DebitQty", GetType(Decimal))
        dt.Columns.Add("DebitUnit", GetType(Decimal))
        dt.Columns.Add("DebitCost", GetType(Decimal))
        dt.Columns.Add("CreditQty", GetType(Decimal))
        dt.Columns.Add("CreditUnit", GetType(Decimal))
        dt.Columns.Add("CreditCost", GetType(Decimal))
        dt.Columns.Add("BalQty", GetType(Decimal))
        dt.Columns.Add("BalUnit", GetType(Decimal))
        dt.Columns.Add("BalCost", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Property_Dtl_ID") = DBNull.Value
            dr("date") = DBNull.Value
            dr("transtype") = DBNull.Value
            dr("ref") = DBNull.Value
            dr("accountableperson") = DBNull.Value
            dr("dept_office") = DBNull.Value
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
            dr("BalUnit") = DBNull.Value
            dr("BalCost") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatableAttch(ByVal row As Integer) As DataTable
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
        dt.Columns.Add("remarks", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow

            dr("DocuId") = DBNull.Value
            dr("IdentityNo") = DBNull.Value
            dr("documentname") = DBNull.Value
            dr("documentno") = DBNull.Value
            dr("validatedby") = DBNull.Value
            dr("datevalidated") = DBNull.Value
            dr("remarks") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatableOfficeSupp(ByVal row As Integer) As DataTable
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
        dt.Columns.Add("item_id", GetType(Long))
        dt.Columns.Add("PODtl_ID", GetType(Long))
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("DatePurchased", GetType(String))


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
            dr("item_id") = DBNull.Value
            dr("PODtl_ID") = DBNull.Value
            dr("Supplier_Id") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("DatePurchased") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Protected Sub btnBrowseAttachDoc2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub btnInspectedPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("type") = "receive"
        Session("Status") = "Inspected"
        Session("query") = 0
        Session("PO_No") = 0
        Me.Page.Response.Redirect("~/Procurement/rpt_inspection_and_acceptance.aspx")
    End Sub
    Protected Sub btnacceptancepreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("type") = "ARE"
        Session("Status") = "Accepted"
        Session("query") = 0
        Session("PO_No") = 0
        Me.Page.Response.Redirect("~/Procurement/rpt_inspection_and_acceptance.aspx")
    End Sub

    'Protected Sub grdMotor_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
    '    Dim dtMotors As New DataTable
    '    dtMotors = objDerived.GetDataTable("exec dbo.load_goods_for_serial  '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
    '    If dtMotors.Rows.Count < 4 Then
    '        dtMotors.Merge(createdatatableGoods(3 - dtMotors.Rows.Count))
    '    End If
    '    grdMotor.PageIndex = e.NewPageIndex
    '    grdMotor.DataSource = dtMotors
    '    grdMotor.DataBind()

    '    LoadClearMotorText()
    '    LoadDisableMotorText()

    '    btninspectedsave.Enabled = False
    '    btnAccptUpdate.Visible = False
    '    LoadButtonDisable()

    '    btnSaveMotor.Visible = True
    '    btnUpdateMotor.Visible = False
    '    btnEditMotor.Visible = False
    'End Sub

    'Protected Sub grdEuipment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
    '    Dim dtEquipment As New DataTable
    '    dtEquipment = objDerived.GetDataTable("exec dbo.load_goods_for_serial  '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
    '    If dtEquipment.Rows.Count < 4 Then
    '        dtEquipment.Merge(createdatatableGoods(3 - dtEquipment.Rows.Count))
    '    End If
    '    grdEuipment.PageIndex = e.NewPageIndex
    '    grdEuipment.DataSource = dtEquipment
    '    grdEuipment.DataBind()

    '    LoadClearEquipText()
    '    LoadDisableEquipText()

    '    btninspectedsave.Enabled = False
    '    btnAccptUpdate.Visible = False
    '    LoadButtonDisable()

    '    btnSaveSerial.Visible = True
    '    btnUpdateEquip.Visible = False
    '    btnEditEquip.Visible = False
    'End Sub

    'Protected Sub grdMachineries_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
    '    Dim dtMachineries As New DataTable
    '    dtMachineries = objDerived.GetDataTable("exec dbo.load_goods_for_serial  '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
    '    If dtMachineries.Rows.Count < 4 Then
    '        dtMachineries.Merge(createdatatableGoods(3 - dtMachineries.Rows.Count))
    '    End If
    '    grdMachineries.PageIndex = e.NewPageIndex
    '    grdMachineries.DataSource = dtMachineries
    '    grdMachineries.DataBind()

    '    LoadClearMachinetext()
    '    LoadDisableMachineText()

    '    btninspectedsave.Enabled = False
    '    btnAccptUpdate.Visible = False
    '    LoadButtonDisable()

    '    btnSaveSerialMac.Visible = True
    '    btnUpdateMac.Visible = False
    '    btnEditMachine.Visible = False
    'End Sub

    'Protected Sub grdfurnitureandfixtures_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
    '    Dim dtFurniture As New DataTable
    '    dtFurniture = objDerived.GetDataTable("Exec dbo.load_goods_for_serial  '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
    '    If dtFurniture.Rows.Count < 8 Then
    '        dtFurniture.Merge(createdatatableGoods(7 - dtFurniture.Rows.Count))
    '    End If
    '    grdfurnitureandfixtures.PageIndex = e.NewPageIndex
    '    grdfurnitureandfixtures.DataSource = dtFurniture
    '    grdfurnitureandfixtures.DataBind()

    '    LoadFurnitureClearText()
    '    LoadDisableFurnitureText()

    '    btninspectedsave.Enabled = False
    '    btnAccptUpdate.Visible = False
    '    LoadButtonDisable()

    '    btnSaveFurn.Visible = True
    '    btnUpdateFurn.Visible = False
    '    btnEditFur.Visible = False
    'End Sub

    Protected Sub ddCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadCategories()
    End Sub
    Protected Sub LoadCategories()
        Dim GA As Integer
        If ddCategories.SelectedItem.Text = "Select" Then
            GA = 0
        Else
            GA = ddCategories.SelectedItem.Value
        End If

        Dim dtInspect As New DataTable
       dtInspect = objDerived.GetDataTable("Exec [dbo].[sp_InspectionAcceptance_v2] '" & GA & "', '" & 0 & "'", CommandType.Text)
        If dtInspect.Rows.Count < 8 Then
            dtInspect.Merge(createdatatable1(7 - dtInspect.Rows.Count))
        End If
        grdInspection.DataSource = dtInspect
        grdInspection.DataBind()
        grdInspection.SelectedIndex = 0
        LoadGA_IDSelection()
    End Sub
    Protected Sub LoadAmbulanceInfoSave()
        dtAmbulanceInfo = objAmbulanceInfo.GetDataTable("select Ambulance_InfoId from AMS.TbAmbulance_Info where AIRDtl_ID like '" & AIRDtl_ID & "' and PlateNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
        With objAmbulanceInfo
            '.Ambulance_InfoId = Ambulance_InfoId
            .AIRDtl_ID = AIRDtl_ID
            .Property_Dtl_ID = PropertyDetai_ID
            '.IsAccepted = ""
            .Location = txtAmbulanceLoc.Text
            .Brand = txtAmbulanceBrand.Text
            .Model = txtAmbulanceModel.Text
            .Area = txtAmbulanceArea.Text
            .PlateNo = txtAmbulancePlate.Text
            If txtAmbulanceSeat.Text = "" Then
                .seat = 2
            Else
                .seat = txtAmbulanceSeat.Text
            End If
            .Color = txtAmbulanceColor.Text
            .Equipments = txtAmbulanceEquip.Text
        End With

        If dtAmbulanceInfo.Rows.Count = 0 Then
            objAmbulanceInfo.Ambulance_InfoId = 0
            objAmbulanceInfo.save()
            Ambulance_InfoId = objAmbulanceInfo.GetValue("Select max(Ambulance_InfoId) from AMS.TbAmbulance_Info ", CommandType.Text)
        Else
            Ambulance_InfoId = objAmbulanceInfo.GetValue("Select Ambulance_InfoId from AMS.TbAmbulance_Info where AIRDtl_ID like '" & AIRDtl_ID & "' and PlateNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            objAmbulanceInfo.Ambulance_InfoId = Ambulance_InfoId
            objAmbulanceInfo.update()
        End If
    End Sub
    Protected Sub LoadAmbulanceDtlSave()
        dtAmbulanceDtl = objAmbulanceDtl.GetDataTable("select Ambulance_ID from AMS.TbAmbulance_Dtl where Ambulance_InfoId like '" & Ambulance_InfoId & "'", CommandType.Text)
        With objAmbulanceDtl
            '.Ambulance_ID = Ambulance_ID
            .Ambulance_InfoId = Ambulance_InfoId
            .Property_Dtl_ID = PropertyDetai_ID
            .MarketValue = grdMotor_Serial.SelectedDataKey("MarketValue")
            .Condition = grdMotor_Serial.SelectedDataKey("Condition")
            .Location = txtAmbulanceLoc.Text
            '.Status = objDerived.GetValue("Select Status from AMS.TbPropertySerial  where Item_ID = '" & grdMotor_Serial.SelectedDataKey("Item_ID") & "' and SerialNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)

        End With

        If dtAmbulanceDtl.Rows.Count = 0 Then
            objAmbulanceDtl.Ambulance_ID = 0
            objAmbulanceDtl.save()
            Ambulance_ID = objAmbulanceDtl.GetValue("Select max(Ambulance_ID) from AMS.TbAmbulance_Dtl ", CommandType.Text)
        Else
            Ambulance_ID = objAmbulanceDtl.GetValue("Select Ambulance_ID from AMS.TbAmbulance_Dtl where Ambulance_InfoId like '" & Ambulance_InfoId & "'", CommandType.Text)
            objAmbulanceDtl.Ambulance_ID = Ambulance_ID
            objAmbulanceDtl.update()
        End If
        loadBarcode()

        LoadMotorSerial()
    End Sub
    Protected Sub LoadAmbulanceDTL()
        Dim dtSerial As New DataTable
        dtSerial = objDerived.GetDataTable("Select * from dbo.View_PropertySerial where Item_Serial_ID = '" & grdMotor_Serial.SelectedDataKey("Item_Serial_ID") & "'", CommandType.Text)
        If dtSerial.Rows.Count = 0 Then
            PropNo.Text = ""
            LoadClearAmbulanceTEXT()
            LoadDisableAmbulanceTEXT()
            LoadButtonDisable()
            btninspectedsave.Enabled = False
            btnacceptancesave.Visible = True
            btnAccptUpdate.Visible = False

        ElseIf grdMotor_Serial.SelectedDataKey("SerialNo") = "" Or grdMotor_Serial.SelectedDataKey("SerialNo") = Nothing Then
            PropNo.Text = ""
            LoadClearAmbulanceTEXT()
            LoadDisableAmbulanceTEXT()
            LoadButtonDisable()
            btninspectedsave.Enabled = False
            btnacceptancesave.Visible = True
            btnAccptUpdate.Visible = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Plate Number is required.")

        Else
            btninspectedsave.Enabled = True
            LoadEnableAmbulanceTEXT()

            Dim dtMotorInfo As New DataTable
            dtMotorInfo = objDerived.GetDataTable("Select * from [dbo].[View_AIR_Ambulance] where Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "' and PlateNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
            If dtMotorInfo.Rows.Count = 0 Then
                PropNo.Text = ""
                LoadClearAmbulanceTEXT()
                LoadButtonDisable()
                btnacceptancesave.Visible = True
                btnAccptUpdate.Visible = False
                txtAmbulancePlate.Text = grdMotor_Serial.SelectedDataKey("SerialNo")

            Else
                Dim MotorAccpt As New DataTable
                MotorAccpt = objDerived.GetDataTable("Select * from [dbo].[View_GetPropertyNoAmbulance] where Item_ID = '" & grdMotor_Serial.SelectedDataKey(0) & "' and PlateNo = '" & grdMotor_Serial.SelectedDataKey("SerialNo") & "'", CommandType.Text)
                If MotorAccpt.Rows.Count = 0 Then
                    txtAmbulanceLoc.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("Location").ToString), 0, (dtMotorInfo.Rows(0)("Location").ToString))
                    txtAmbulanceBrand.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("Brand").ToString), 0, (dtMotorInfo.Rows(0)("Brand").ToString))
                    txtAmbulanceModel.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("Model").ToString), 0, (dtMotorInfo.Rows(0)("Model").ToString))
                    txtAmbulanceSeat.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("Seat").ToString), 0, (dtMotorInfo.Rows(0)("Seat").ToString))
                    txtAmbulanceColor.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("Color").ToString), 0, (dtMotorInfo.Rows(0)("Color").ToString))
                    txtAmbulanceEquip.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("Equipment").ToString), 0, (dtMotorInfo.Rows(0)("Equipment").ToString))
                    txtAmbulancePlate.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("PlateNo").ToString), 0, (dtMotorInfo.Rows(0)("PlateNo").ToString))
                    txtAmbulanceArea.Text = IIf(IsDBNull(dtMotorInfo.Rows(0)("Area").ToString), 0, (dtMotorInfo.Rows(0)("Area").ToString))

                    PropNo.Text = ""
                    LoadButtonEnable()
                    LoadButtonEnable2()
                    btnacceptancesave.Visible = True
                    btnAccptUpdate.Visible = False
                Else
                    txtAmbulanceLoc.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("Location").ToString), 0, (MotorAccpt.Rows(0)("Location").ToString))
                    txtAmbulanceBrand.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("Brand").ToString), 0, (MotorAccpt.Rows(0)("Brand").ToString))
                    txtAmbulanceModel.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("Model").ToString), 0, (MotorAccpt.Rows(0)("Model").ToString))
                    txtAmbulanceSeat.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("Seat").ToString), 0, (MotorAccpt.Rows(0)("Seat").ToString))
                    txtAmbulanceColor.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("Color").ToString), 0, (MotorAccpt.Rows(0)("Color").ToString))
                    txtAmbulanceEquip.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("Equipments").ToString), 0, (MotorAccpt.Rows(0)("Equipments").ToString))
                    txtAmbulancePlate.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("PlateNo").ToString), 0, (MotorAccpt.Rows(0)("PlateNo").ToString))
                    txtAmbulanceArea.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("Area").ToString), 0, (MotorAccpt.Rows(0)("Area").ToString))


                    PropNo.Text = IIf(IsDBNull(MotorAccpt.Rows(0)("PropertyNo").ToString), 0, (MotorAccpt.Rows(0)("PropertyNo").ToString))

                    LoadButtonEnable()
                    LoadButtonEnable2()

                    If MotorAccpt.Rows(0)("Status").ToString = "Inspected" Then
                        btninspectedsave.Enabled = True
                        btnInspectedPreview.Enabled = True
                        btnacceptancesave.Visible = True
                        btnAccptUpdate.Visible = False
                        btnacceptancepreview.Enabled = False
                        txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")

                    ElseIf MotorAccpt.Rows(0)("Status").ToString = "Accepted" Then
                        ddacceptance.Enabled = False
                        btninspectedsave.Enabled = False
                        btnInspectUpdate.Enabled = False
                        btnInspectedPreview.Enabled = False
                        btnacceptancesave.Visible = False
                        btnAccptUpdate.Visible = True
                        btnacceptancepreview.Enabled = True

                        LoadIFCompleted()
                    End If
                End If
            End If
        End If
        LoadAttchDoc()
    End Sub

    Protected Sub LoadSupplies()
        grdSupply.Columns(11).Visible = True
        grdSupply.Columns(12).Visible = True
        grdSupply.Columns(13).Visible = True

        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("Select * from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            LoadAIRnum()

            Dim dtSupp As New DataTable
            dtSupp = objDerived.GetDataTable("Select * from [dbo].[View_SuppliesGoods] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtSupp.Rows.Count < 4 Then
                dtSupp.Merge(createdatatableOfficeSupp(3 - dtSupp.Rows.Count))
            End If
            grdSupply.DataSource = dtSupp
            grdSupply.DataBind()
            grdSupply.SelectedIndex = 0
            LoadSupplyInfo()

            txtsupplier.Text = IIf(IsDBNull(dtSupp.Rows(0)("SuppName").ToString), 0, (dtSupp.Rows(0)("SuppName").ToString))
            txtPOnum.Text = IIf(IsDBNull(dtSupp.Rows(0)("PO_No").ToString), 0, (dtSupp.Rows(0)("PO_No").ToString))
            txtpoDate.Text = IIf(IsDBNull(dtSupp.Rows(0)("DatePurchased").ToString), 0, (dtSupp.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = dtSupp.Rows(0).Item("RespCenter").ToString

            txtSuppDesc.Text = dtSupp.Rows(0).Item("Item_Desc").ToString
            txtSuppSupplier.Text = grdInspection.SelectedDataKey(3)

            rbStatus.SelectedValue = 0
        Else
            txtInvoiceDate.ReadOnly = True
            'dtSuppAIR = objDerived.GetDataTable("Exec  dbo.sp_MedicineList '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from [dbo].[View_Inspected] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            txtPOnum.Text = IIf(IsDBNull(dt.Rows(0)("PO_No").ToString), 0, (dt.Rows(0)("PO_No").ToString))
            txtsupplier.Text = IIf(IsDBNull(dt.Rows(0)("SuppName").ToString), 0, (dt.Rows(0)("SuppName").ToString))
            txtpoDate.Text = IIf(IsDBNull(dt.Rows(0)("DatePurchased").ToString), 0, (dt.Rows(0)("DatePurchased").ToString))
            txtdepartment.Text = IIf(IsDBNull(dt.Rows(0)("RespCenter").ToString), 0, (dt.Rows(0)("RespCenter").ToString)) 'dt.Rows(0).Item("RespCenter").ToString
            txtOfficeItemDesc.Text = dt.Rows(0).Item("Item_Desc").ToString
            lblairno.Text = IIf(IsDBNull(dt.Rows(0)("AIR_No").ToString), 0, (dt.Rows(0)("AIR_No").ToString))
            txtInvoiceDate.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_date").ToString), 0, (dt.Rows(0)("Invoice_date").ToString))
            txtinvoiceNo.Text = IIf(IsDBNull(dt.Rows(0)("Invoice_No").ToString), 0, (dt.Rows(0)("Invoice_No").ToString))
            txtremaks.Text = IIf(IsDBNull(dt.Rows(0)("remarks").ToString), 0, (dt.Rows(0)("remarks").ToString))
            txtInspectedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Inspect").ToString), 0, (dt.Rows(0)("Date_Inspect").ToString))
            ddinspector1.Text = IIf(IsDBNull(dt.Rows(0)("Signatory1").ToString), 0, (dt.Rows(0)("Signatory1").ToString))
            ddinspector2.Text = IIf(IsDBNull(dt.Rows(0)("Signatory2").ToString), 0, (dt.Rows(0)("Signatory2").ToString))
            txtAcceptedDate.Text = IIf(IsDBNull(dt.Rows(0)("Date_Received").ToString), 0, (dt.Rows(0)("Date_Received").ToString))

            If dt.Rows(0)("Signatory3").ToString = "" Then
                ddacceptance.DataSource = objDerived.GetDataTable("Select 'Select' as full_name, 1 as rowno union SELECT full_name  as full_name,empid " & _
                                                                  "from [dbo].[view_signatory1] where deptid = 7 and division_key = 86 order BY rowno", CommandType.Text)
                ddacceptance.DataBind()
                ddacceptance.DataTextField = ("full_name")
                btninspectedsave.Enabled = True
            Else
                ddacceptance.Text = IIf(IsDBNull(dt.Rows(0)("Signatory3").ToString), 0, (dt.Rows(0)("Signatory3").ToString))
                btninspectedsave.Enabled = False
                ddacceptance.Enabled = False
            End If

            If dt.Rows(0)(16) = True Then
                rbStatus.SelectedValue = 1
            Else
                rbStatus.SelectedValue = 0
            End If

            Session("AIRHdr_ID") = dt.Rows(0)("AIRHdr_ID").ToString
            Session("POHdr_ID") = grdInspection.SelectedDataKey("POHdr_ID")

            txtInspectedDate.Enabled = False
            ddinspector1.Enabled = False
            ddinspector2.Enabled = False

            Dim dtSuppAIR As New DataTable
            dtSuppAIR = objDerived.GetDataTable("Exec [AMS].[sp_SupplyList] '" & grdInspection.SelectedDataKey(0) & "','" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtSuppAIR.Rows.Count = 0 Then
                grdSupply.DataSource = createdatatableOfficeSupp(4)
                grdSupply.DataBind()

                rbStatus.Enabled = True
                btnacceptancepreview.Enabled = True
                btnInspectedPreview.Enabled = False

                btnAccptUpdate.Visible = True
                btnAccptUpdate.Enabled = True

                btnacceptancesave.Visible = False

                LoadToCompleteSupply()
            Else
                If dtSuppAIR.Rows.Count < 4 Then
                    dtSuppAIR.Merge(createdatatableOfficeSupp(3 - dtSuppAIR.Rows.Count))
                End If
                grdSupply.DataSource = dtSuppAIR
                grdSupply.DataBind()
                grdSupply.SelectedIndex = 0

                rbStatus.Enabled = False
                rbStatus.SelectedValue = 0

                LoadSupplyInfo()

            End If
        End If

        grdSupply.Columns(11).Visible = False
        grdSupply.Columns(12).Visible = False
        grdSupply.Columns(13).Visible = False
    End Sub
    Protected Sub LoadSupplyInfo()
        Dim dtSuppAIR As New DataTable
        'dtSuppAIR = objDerived.GetDataTable("Exec [AMS].[sp_SupplyListClear] '" & grdInspection.SelectedDataKey(0) & "','" & grdInspection.SelectedDataKey(1) & "','" & grdSupply.SelectedDataKey("PODtl_ID") & "'", CommandType.Text)
        dtSuppAIR = objDerived.GetDataTable("Select * From dbo.view_SupplyNoAIR where PODtl_ID = '" & grdSupply.SelectedDataKey("PODtl_ID") & "'", CommandType.Text)
        If dtSuppAIR.Rows.Count = 0 Then
            txtSuppDesc.Text = ""
            txtSuppSupplier.Text = ""
            btninspectedsave.Enabled = False

            LoadClearSupply()
        Else
            Dim dtSupply As New DataTable
            dtSupply = objDerived.GetDataTable("Exec [AMS].[sp_InspectionAccptanceSupply] '" & grdInspection.SelectedDataKey("GA_ID") & "', '" & grdSupply.SelectedDataKey("PODtl_ID") & "'", CommandType.Text)
            If dtSupply.Rows.Count = 0 Then
                txtSuppDesc.Text = grdSupply.SelectedDataKey("Item_Desc")
                txtSuppSupplier.Text = grdInspection.SelectedDataKey(3)
                btninspectedsave.Enabled = True

                LoadClearSupply()
            Else
                txtSuppDesc.Text = IIf(IsDBNull(dtSupply.Rows(0)("Item_Desc").ToString), grdSupply.SelectedDataKey(3), (dtSupply.Rows(0)("Item_Desc").ToString))
                txtSuppB.Text = IIf(IsDBNull(dtSupply.Rows(0)("BrandName").ToString), 0, (dtSupply.Rows(0)("BrandName").ToString))
                txtSuppSupplier.Text = IIf(IsDBNull(dtSupply.Rows(0)("SuppName").ToString), 0, (dtSupply.Rows(0)("SuppName").ToString))
                txtSuppStorage.Text = IIf(IsDBNull(dtSupply.Rows(0)("Storage").ToString), 0, (dtSupply.Rows(0)("Storage").ToString))
                txtSuppDepRate.Text = IIf(IsDBNull(dtSupply.Rows(0)("DepreciationRate").ToString), 0, (dtSupply.Rows(0)("DepreciationRate").ToString))
                txtSuppDepValue.Text = IIf(IsDBNull(dtSupply.Rows(0)("DepreciationValue").ToString), 0, (dtSupply.Rows(0)("DepreciationValue").ToString))

                txtSuppForm.Text = IIf(IsDBNull(dtSupply.Rows(0)("Form").ToString), 0, (dtSupply.Rows(0)("Form").ToString))
                txtSuppQTC.Text = IIf(IsDBNull(dtSupply.Rows(0)("OTCRx").ToString), 0, (dtSupply.Rows(0)("OTCRx").ToString))
                txtSuppMftg.Text = CType(IIf(IsDBNull(dtSupply.Rows(0)("Mftgdate").ToString), 0, (dtSupply.Rows(0)("Mftgdate").ToString)), Date)
                txtSuppBatch.Text = IIf(IsDBNull(dtSupply.Rows(0)("Batch").ToString), 0, (dtSupply.Rows(0)("Batch").ToString))
                txtSuppLot.Text = IIf(IsDBNull(dtSupply.Rows(0)("Lot").ToString), 0, (dtSupply.Rows(0)("Lot").ToString))
                txtSuppExpire.Text = CType(IIf(IsDBNull(dtSupply.Rows(0)("EpiryDate").ToString), 0, (dtSupply.Rows(0)("EpiryDate").ToString)), Date)
                txtSuppAlert.Text = CType(IIf(IsDBNull(dtSupply.Rows(0)("Alert").ToString), 0, (dtSupply.Rows(0)("Alert").ToString)), Date)

                If dtSupply.Rows(0)("Status").ToString = "Accepted" Then
                    ddacceptance.Enabled = False

                    btninspectedsave.Enabled = False
                    btninspectedsave.Visible = True
                    btnInspectUpdate.Enabled = False
                    btnInspectUpdate.Visible = False
                    btnInspectedPreview.Enabled = False

                    btnacceptancesave.Enabled = False
                    btnacceptancesave.Visible = False
                    btnAccptUpdate.Enabled = True
                    btnAccptUpdate.Visible = True
                    btnacceptancepreview.Enabled = True

                ElseIf dtSupply.Rows(0)("Status").ToString = "Inspected" Then
                    btnacceptancesave.Enabled = True
                    btninspectedsave.Enabled = True
                    btnInspectUpdate.Enabled = False
                    btnInspectUpdate.Visible = False
                    btnInspectedPreview.Enabled = True

                    btnacceptancesave.Visible = True
                    btnAccptUpdate.Visible = False
                    btnacceptancepreview.Enabled = False
                    txtAcceptedDate.Text = Date.Today.ToString("MM/dd/yyyy")
                Else
                    ddacceptance.Enabled = False
                    btninspectedsave.Enabled = True
                    btnInspectUpdate.Enabled = False
                    btnInspectedPreview.Enabled = False
                    btnacceptancesave.Visible = True
                    btnacceptancesave.Enabled = False
                    btnAccptUpdate.Visible = False
                    btnacceptancepreview.Enabled = False
                End If
            End If

        End If

        LoadAttchDoc()
    End Sub
    Protected Sub LoadClearSupply()
        txtSuppB.Text = ""
        txtSuppStorage.Text = ""
        txtSuppDepRate.Text = ""
        txtSuppDepValue.Text = ""

        txtSuppForm.Text = ""
        txtSuppQTC.Text = ""
        txtSuppMftg.Text = ""
        txtSuppBatch.Text = ""
        txtSuppLot.Text = ""
        txtSuppExpire.Text = ""
        txtSuppAlert.Text = ""

        txtMedName.Text = ""
        txtMedDose.Text = ""
        txtMedForm.Text = ""
        txtMedOTCRX.Text = ""
        txtMedExpiredDate.Text = ""
        txtMedMftgdate.Text = ""
        txtMedBatch.Text = ""
        txtMedLot.Text = ""
        txtMedAlertDate.Text = ""


        btnInspectedPreview.Enabled = False
        btnacceptancesave.Enabled = False
        btnacceptancesave.Visible = True
        btnAccptUpdate.Enabled = False
        btnAccptUpdate.Visible = False
        btnacceptancepreview.Enabled = False
        btnacknowledgementpost.Enabled = False
        btnacknowledgementpreview.Enabled = False

    End Sub
    Protected Sub LoadToCompleteSupply()
        txtSuppB.Text = ""
        txtSuppDesc.Text = ""
        txtSuppStorage.Text = ""
        txtSuppDepRate.Text = ""
        txtSuppDepValue.Text = ""
        txtSuppSupplier.Text = ""

        txtSuppForm.Text = ""
        txtSuppQTC.Text = ""
        txtSuppMftg.Text = ""
        txtSuppBatch.Text = ""
        txtSuppLot.Text = ""
        txtSuppExpire.Text = ""
        txtSuppAlert.Text = ""

        txtMedName.Text = ""
        txtMedDose.Text = ""
        txtMedForm.Text = ""
        txtMedOTCRX.Text = ""
        txtMedExpiredDate.Text = ""
        txtMedMftgdate.Text = ""
        txtMedBatch.Text = ""
        txtMedLot.Text = ""
        txtMedAlertDate.Text = ""
    End Sub

    Protected Sub grdSupply_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdSupply, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdSupply_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadSupplyInfo()

    End Sub

    Protected Sub grdSupply_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("Select * from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            Dim dtSupp As New DataTable
            dtSupp = objDerived.GetDataTable("Select * from [dbo].[View_SuppliesGoods] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtSupp.Rows.Count < 4 Then
                dtSupp.Merge(createdatatableOfficeSupp(3 - dtSupp.Rows.Count))
            End If
            grdSupply.PageIndex = e.NewPageIndex
            grdSupply.DataSource = dtSupp
            grdSupply.DataBind()
            grdSupply.SelectedIndex = 0
            LoadSupplyInfo()
        Else

            Dim dtSuppAIR As New DataTable
            dtSuppAIR = objDerived.GetDataTable("Exec [AMS].[sp_SupplyList] '" & grdInspection.SelectedDataKey(0) & "','" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtSuppAIR.Rows.Count < 4 Then
                dtSuppAIR.Merge(createdatatableOfficeSupp(3 - dtSuppAIR.Rows.Count))
            End If
            grdSupply.PageIndex = e.NewPageIndex
            grdSupply.DataSource = dtSuppAIR
            grdSupply.DataBind()
            grdSupply.SelectedIndex = 0
            LoadSupplyInfo()
        End If

    End Sub

    Protected Sub LoadSuppliesSAVE()
        If grdInspection.SelectedDataKey(0) = 791 Then
            'FOOD
            dtFood = objFood.GetDataTable("select Food_ID from AMS.TbFood where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
            With objFood
                '.Food_ID = Food_ID
                .StockId = StockID
                .AIRDtl_ID = AIRDtl_ID
                .Item_ID = grdSupply.SelectedDataKey("Item_ID")
                .ActualPrice = objDerived.GetValue("SELECT price from m_item_detail where Item_ID = '" & grdSupply.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                .ItemDesc = txtSuppDesc.Text
                .BrandName = txtSuppB.Text
                .Supplier_Id = grdSupply.SelectedDataKey("Supplier_Id")
                .DeliveryDate = txtInvoiceDate.Text
                .Form = txtSuppForm.Text
                .OTCRx = txtSuppQTC.Text
                .Batch = txtSuppBatch.Text
                .Lot = txtSuppLot.Text
                .EpiryDate = txtSuppExpire.Text
                .Alert = txtSuppAlert.Text
                .Storage = txtSuppStorage.Text
                '.Status = ""

                If txtSuppMftg.Text = "" Then
                    txtMedMftgdate.Text = DateTime.Today.AddDays(-30).ToShortDateString()
                    .Mftgdate = txtMedMftgdate.Text
                Else
                    .Mftgdate = txtSuppMftg.Text
                End If

                If txtSuppDepRate.Text = "" Then
                    .Depreciationrate = 0.0
                Else
                    .Depreciationrate = txtSuppDepRate.Text
                End If

                If txtSuppDepValue.Text = "" Then
                    .Depreciationvalue = 0.0
                Else
                    .Depreciationvalue = txtSuppDepValue.Text
                End If
            End With

            If dtFood.Rows.Count = 0 Then
                objFood.Food_ID = 0
                objFood.save()
                Food_ID = objFood.GetValue("Select max(Food_ID) from AMS.TbFood ", CommandType.Text)
            Else
                Food_ID = objFood.GetValue("select Food_ID from AMS.TbFood where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
                objFood.Food_ID = Food_ID
                objFood.update()
            End If

        ElseIf grdInspection.SelectedDataKey(0) = 799 Then
            'WATER
            dtWater = objWater.GetDataTable("select Water_ID from AMS.TbWater where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
            With objWater
                '.Water_ID = Water_ID
                .StockId = StockID
                .AIRDtl_ID = AIRDtl_ID
                .Item_ID = grdSupply.SelectedDataKey("Item_ID")
                .ActualPrice = objDerived.GetValue("SELECT price from m_item_detail where Item_ID = '" & grdSupply.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                .ItemDesc = txtSuppDesc.Text
                .BrandName = txtSuppB.Text
                .Supplier_Id = grdSupply.SelectedDataKey("Supplier_Id")
                .DeliveryDate = txtInvoiceDate.Text
                .Form = txtSuppForm.Text
                .OTCRx = txtSuppQTC.Text
                .Batch = txtSuppBatch.Text
                .Lot = txtSuppLot.Text
                .EpiryDate = txtSuppExpire.Text
                .Alert = txtSuppAlert.Text
                .Storage = txtSuppStorage.Text
                '.Status = ""

                If txtSuppMftg.Text = "" Then
                    txtMedMftgdate.Text = DateTime.Today.AddDays(-60).ToShortDateString()
                    .Mftgdate = txtMedMftgdate.Text
                Else
                    .Mftgdate = txtSuppMftg.Text
                End If

                If txtSuppDepRate.Text = "" Then
                    .Depreciationrate = 0.0
                Else
                    .Depreciationrate = txtSuppDepRate.Text
                End If

                If txtSuppDepValue.Text = "" Then
                    .Depreciationvalue = 0.0
                Else
                    .Depreciationvalue = txtSuppDepValue.Text
                End If
            End With

            If dtWater.Rows.Count = 0 Then
                objWater.Water_ID = 0
                objWater.save()
                Water_ID = objWater.GetValue("Select max(Water_ID) from AMS.TbWater ", CommandType.Text)
            Else
                Water_ID = objWater.GetValue("select Water_ID from AMS.TbWater where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
                objWater.Water_ID = Water_ID
                objWater.update()
            End If

        ElseIf grdInspection.SelectedDataKey(0) = 798 Then
            'BLOOD
            dtBlood = objBlood.GetDataTable("select Blood_ID from AMS.TbBlood where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
            With objBlood
                '.Blood_ID = Blood_ID
                .StockId = StockID
                .AIRDtl_ID = AIRDtl_ID
                .Item_ID = grdSupply.SelectedDataKey("Item_ID")
                .ActualPrice = objDerived.GetValue("SELECT price from m_item_detail where Item_ID = '" & grdSupply.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                .ItemDesc = txtSuppDesc.Text
                .BloodType = txtSuppB.Text
                .Supplier_Id = grdSupply.SelectedDataKey("Supplier_Id")
                .DeliveryDate = txtInvoiceDate.Text
                .Form = txtSuppForm.Text
                .OTCRx = txtSuppQTC.Text
                .Batch = txtSuppBatch.Text
                .Lot = txtSuppLot.Text
                .EpiryDate = txtSuppExpire.Text
                .Alert = txtSuppAlert.Text
                .Storage = txtSuppStorage.Text
                '.Status = ""

                If txtSuppMftg.Text = "" Then
                    txtMedMftgdate.Text = DateTime.Today.AddDays(-30).ToShortDateString()
                    .Mftgdate = txtMedMftgdate.Text
                Else
                    .Mftgdate = txtSuppMftg.Text
                End If

                If txtSuppDepRate.Text = "" Then
                    .Depreciationrate = 0.0
                Else
                    .Depreciationrate = txtSuppDepRate.Text
                End If

                If txtSuppDepValue.Text = "" Then
                    .Depreciationvalue = 0.0
                Else
                    .Depreciationvalue = txtSuppDepValue.Text
                End If
            End With

            If dtBlood.Rows.Count = 0 Then
                objBlood.Blood_ID = 0
                objBlood.save()
                Blood_ID = objBlood.GetValue("Select max(Blood_ID) from AMS.TbBlood ", CommandType.Text)
            Else
                Blood_ID = objBlood.GetValue("select Blood_ID from AMS.TbBlood where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
                objBlood.Blood_ID = Blood_ID
                objBlood.update()
            End If

        ElseIf grdInspection.SelectedDataKey(0) = 927 Then
            'NON-FOOD
            dtNonFood = objNonFood.GetDataTable("select NonFood_ID from AMS.TbNonFood where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
            With objNonFood
                '.NonFood_ID = NonFood_ID
                .StockId = StockID
                .AIRDtl_ID = AIRDtl_ID
                .Item_ID = grdSupply.SelectedDataKey("Item_ID")
                .ActualPrice = objDerived.GetValue("SELECT price from m_item_detail where Item_ID = '" & grdSupply.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                .ItemDesc = txtSuppDesc.Text
                .BrandName = txtSuppB.Text
                .Supplier_Id = grdSupply.SelectedDataKey("Supplier_Id")
                .Form = txtSuppForm.Text
                .OTCRx = txtSuppQTC.Text
                .Batch = txtSuppBatch.Text
                .Lot = txtSuppLot.Text
                .Storage = txtSuppStorage.Text
                '.Status = ""

                If txtInvoiceDate.Text = "" Then
                    .DeliveryDate = Date.Today.ToString("MM/dd/yyyy")
                Else
                    .DeliveryDate = txtInvoiceDate.Text
                End If

                If txtSuppExpire.Text = "" Then
                    .EpiryDate = "1/1/1900"
                Else
                    .EpiryDate = txtSuppExpire.Text
                End If

                If txtSuppAlert.Text = "" Then
                    .Alert = "1/1/1900"
                Else
                    .Alert = txtSuppAlert.Text
                End If

                If txtSuppMftg.Text = "" Then
                    txtMedMftgdate.Text = DateTime.Today.AddDays(-60).ToShortDateString()
                    .Mftgdate = txtMedMftgdate.Text
                Else
                    .Mftgdate = txtSuppMftg.Text
                End If

                If txtSuppDepRate.Text = "" Then
                    .Depreciationrate = 0.0
                Else
                    .Depreciationrate = txtSuppDepRate.Text
                End If

                If txtSuppDepValue.Text = "" Then
                    .Depreciationvalue = 0.0
                Else
                    .Depreciationvalue = txtSuppDepValue.Text
                End If
            End With

            If dtNonFood.Rows.Count = 0 Then
                objNonFood.NonFood_ID = 0
                objNonFood.save()
                NonFood_ID = objNonFood.GetValue("Select max(NonFood_ID) from AMS.TbNonFood ", CommandType.Text)
            Else
                NonFood_ID = objNonFood.GetValue("select NonFood_ID from AMS.TbNonFood where AIRDtl_ID like '" & AIRDtl_ID & "' ", CommandType.Text)
                objNonFood.NonFood_ID = NonFood_ID
                objNonFood.update()
            End If
        End If
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdSupply.Rows.Count - 1
                item = grdSupply.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdSupply.Rows(i).Cells(0).FindControl("CheckBox2"), CheckBox)
                If item = "" Or item = "&nbsp;" Then
                    s.Checked = False
                Else
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.grdSupply.Rows.Count - 1
                item = Me.grdSupply.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdSupply.Rows(i).Cells(0).FindControl("CheckBox2"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub
    Protected Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdEuipment_Serial.Rows.Count - 1
                item = grdEuipment_Serial.Rows(i).Cells(1).Text
                Dim c As CheckBox = CType(Me.grdEuipment_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If grdEuipment_Serial.Rows(i).Cells(0).Enabled = True Then
                    c.Checked = True
                Else
                    c.Checked = False
                End If
            Next
        Else
            For i As Integer = 0 To Me.grdEuipment_Serial.Rows.Count - 1
                item = Me.grdEuipment_Serial.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdEuipment_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub

    Protected Sub chckbxmachine_ALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdMachineries_Serial.Rows.Count - 1
                item = grdMachineries_Serial.Rows(i).Cells(1).Text
                Dim c As CheckBox = CType(Me.grdMachineries_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If grdMachineries_Serial.Rows(i).Cells(0).Enabled = True Then
                    c.Checked = True
                Else
                    c.Checked = False
                End If
            Next
        Else
            For i As Integer = 0 To Me.grdMachineries_Serial.Rows.Count - 1
                item = Me.grdMachineries_Serial.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdMachineries_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub

    Protected Sub chckbxFurn_ALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdFurniture_Serial.Rows.Count - 1
                item = grdFurniture_Serial.Rows(i).Cells(1).Text
                Dim c As CheckBox = CType(Me.grdFurniture_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If grdFurniture_Serial.Rows(i).Cells(0).Enabled = True Then
                    c.Checked = True
                Else
                    c.Checked = False
                End If
            Next
        Else
            For i As Integer = 0 To Me.grdFurniture_Serial.Rows.Count - 1
                item = Me.grdFurniture_Serial.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdFurniture_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub

    Protected Sub chckbxTrans_ALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdMotor_Serial.Rows.Count - 1
                item = grdMotor_Serial.Rows(i).Cells(1).Text
                Dim c As CheckBox = CType(Me.grdMotor_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If grdMotor_Serial.Rows(i).Cells(0).Enabled = True Then
                    c.Checked = True
                Else
                    c.Checked = False
                End If
            Next
        Else
            For i As Integer = 0 To Me.grdMotor_Serial.Rows.Count - 1
                item = Me.grdMotor_Serial.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdMotor_Serial.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub

    Protected Sub chckbxMed_ALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdmedicalsupplies.Rows.Count - 1
                item = grdmedicalsupplies.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdmedicalsupplies.Rows(i).Cells(0).FindControl("CheckBox4"), CheckBox)
                If item = "" Or item = "&nbsp;" Then
                    s.Checked = False
                Else
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.grdmedicalsupplies.Rows.Count - 1
                item = Me.grdmedicalsupplies.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdmedicalsupplies.Rows(i).Cells(0).FindControl("CheckBox4"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub

    Protected Sub grdOfficeSupp_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("Select * from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            Dim dtOfficeSup As New DataTable
            dtOfficeSup = objDerived.GetDataTable("Select * from [dbo].[View_SuppliesGoods] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtOfficeSup.Rows.Count < 4 Then
                dtOfficeSup.Merge(createdatatableOfficeSupp(3 - dtOfficeSup.Rows.Count))
            End If
            grdOfficeSupp.PageIndex = e.NewPageIndex
            grdOfficeSupp.DataSource = dtOfficeSup
            grdOfficeSupp.DataBind()
            grdOfficeSupp.SelectedIndex = 0
            LoadOffiePageIndex()
        Else
            Dim dtOfficeAIR As New DataTable
            dtOfficeAIR = objDerived.GetDataTable("Exec [dbo].[sp_SuppliesList] '" & grdInspection.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            If dtOfficeAIR.Rows.Count < 4 Then
                dtOfficeAIR.Merge(createdatatableOfficeSupp(3 - dtOfficeAIR.Rows.Count))
            End If
            grdOfficeSupp.PageIndex = e.NewPageIndex
            grdOfficeSupp.DataSource = dtOfficeAIR
            grdOfficeSupp.DataBind()
            grdOfficeSupp.SelectedIndex = 0
        End If

    End Sub

    Protected Sub chckbxOffice_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdOfficeSupp.Rows.Count - 1
                item = grdOfficeSupp.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdOfficeSupp.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If item = "" Or item = "&nbsp;" Then
                    s.Checked = False
                Else
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.grdOfficeSupp.Rows.Count - 1
                item = Me.grdOfficeSupp.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdOfficeSupp.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim url As String = "Barcode_Popup.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=0,scrollbars=1,width=330,height=350,left=240,top=100');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub

    Protected Sub grdmedicalsupplies_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdmedicalsupplies.Columns(11).Visible = True
        grdmedicalsupplies.Columns(12).Visible = True
        grdmedicalsupplies.Columns(13).Visible = True

        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("Select * from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            Dim dtMedSup As New DataTable
            dtMedSup = objDerived.GetDataTable("Select * from [dbo].[View_SuppliesGoods] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtMedSup.Rows.Count < 4 Then
                dtMedSup.Merge(createdatatableOfficeSupp(3 - dtMedSup.Rows.Count))
            End If
            grdmedicalsupplies.PageIndex = e.NewPageIndex
            grdmedicalsupplies.DataSource = dtMedSup
            grdmedicalsupplies.DataBind()
            grdmedicalsupplies.SelectedIndex = 0
            LoadMedPageIndex()

        Else
            Dim dtMedAIR As New DataTable
            dtMedAIR = objDerived.GetDataTable("Exec dbo.sp_MedicineList '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)

            If dtMedAIR.Rows.Count < 4 Then
                dtMedAIR.Merge(createdatatableOfficeSupp(3 - dtMedAIR.Rows.Count))
            End If
            grdmedicalsupplies.PageIndex = e.NewPageIndex
            grdmedicalsupplies.DataSource = dtMedAIR
            grdmedicalsupplies.DataBind()
            grdmedicalsupplies.SelectedIndex = 0
            LoadMedPageIndex()

        End If
        grdmedicalsupplies.Columns(11).Visible = False
        grdmedicalsupplies.Columns(12).Visible = False
        grdmedicalsupplies.Columns(13).Visible = False

    End Sub

    Protected Sub grdmedicalsupplies_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdmedicalsupplies.Columns(11).Visible = True
        grdmedicalsupplies.Columns(12).Visible = True
        grdmedicalsupplies.Columns(13).Visible = True

        Dim dtAIR As New DataTable
        dtAIR = objDerived.GetDataTable("Select * from AMS.AIR_Hdr where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
        If dtAIR.Rows.Count = 0 Then
            Dim dtMedSup As New DataTable
            dtMedSup = objDerived.GetDataTable("Select * from [dbo].[View_SuppliesGoods] where POHdr_ID = '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)
            If dtMedSup.Rows.Count < 4 Then
                dtMedSup.Merge(createdatatableOfficeSupp(3 - dtMedSup.Rows.Count))
            End If
            grdmedicalsupplies.PageIndex = e.NewPageIndex
            grdmedicalsupplies.DataSource = dtMedSup
            grdmedicalsupplies.DataBind()
            grdmedicalsupplies.SelectedIndex = 0
            LoadMedPageIndex()

        Else
            Dim dtMedAIR As New DataTable
            dtMedAIR = objDerived.GetDataTable("Exec dbo.sp_MedicineList '" & grdInspection.SelectedDataKey(1) & "'", CommandType.Text)

            If dtMedAIR.Rows.Count < 4 Then
                dtMedAIR.Merge(createdatatableOfficeSupp(3 - dtMedAIR.Rows.Count))
            End If
            grdmedicalsupplies.PageIndex = e.NewPageIndex
            grdmedicalsupplies.DataSource = dtMedAIR
            grdmedicalsupplies.DataBind()
            grdmedicalsupplies.SelectedIndex = 0
            LoadMedPageIndex()

        End If
        grdmedicalsupplies.Columns(11).Visible = False
        grdmedicalsupplies.Columns(12).Visible = False
        grdmedicalsupplies.Columns(13).Visible = False
    End Sub

    Protected Sub RadioButtonList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Allotment_type") = RadioButtonList3.SelectedItem.Value

        Dim dtcat As New DataTable
        dtcat = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & Session("Allotment_type") & "'", CommandType.Text)
        ddCategories.DataSource = CType(dtcat, DataTable)
        ddCategories.DataTextField = ("GA_Title")
        ddCategories.DataValueField = ("GA_ID")
        ddCategories.DataBind()
        ddCategories.Items.Insert(0, "Select")
    End Sub
End Class
