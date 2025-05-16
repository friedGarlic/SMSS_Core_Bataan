Imports System.Data


Partial Class Inventory_t_PPE_Encoding
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private Prop_Hdr As New t_property_hdr
    Private Prop_Dtl As New t_property_dtl
    Private Prop_Ledger As New t_PropertyLedger

    Private objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info
    Private objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details

    Private objMachineInfo As New ConsolidatedPropertySaving.TbMachinery_Information
    Private objMachineDtl As New ConsolidatedPropertySaving.TbMachinery_Dtl

    Private objMotorInfo As New ConsolidatedPropertySaving.TbMotor_Info
    Private objMotorDtl As New ConsolidatedPropertySaving.TbMotor_Dtl

    Private objFurnitureInfo As New ConsolidatedPropertySaving.TbFurniture_Info
    Private objFurnitureDtl As New ConsolidatedPropertySaving.TbFurniture_Dtl

    Dim objLandDtl As New ConsolidatedPropertySaving.TBLand_Details

    Private Property dtProperties() As DataTable
        Get
            Return CType(Session("dtProperties"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtProperties") = value
        End Set
    End Property

    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
        End Set
    End Property


#Region "DataTables"
    Public Function temp_dtItems(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Code", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Price", GetType(Decimal))
        dt.Columns.Add("GA_Code", GetType(String))
        dt.Columns.Add("Item_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Code") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("Price") = DBNull.Value
            dr("GA_Code") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function temp_dtProps(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("Amount", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("RC_ID", GetType(Long))
        dt.Columns.Add("Function_ID", GetType(Long))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Qty", GetType(Decimal))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Property_Date", GetType(Date))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("RC_name") = DBNull.Value
            dr("Amount") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("Property_ID") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("Property_Date") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            Session("CYear") = "CY" + CType(Year(Date.Today.ToString("MM/dd/yyyy")), String)

            ddAllotment.DataSource = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 3 & "'", CommandType.Text)
            ddAllotment.DataTextField = ("GA_Title")
            ddAllotment.DataValueField = ("GA_ID")
            ddAllotment.DataBind()
            ddAllotment.Items.Insert(0, "Select")

            grdItemList.DataSource = temp_dtItems(5)
            grdItemList.DataBind()

            Me.mvPPE.SetActiveView(Me.vwEquipments)

            grdProperties.DataSource = temp_dtProps(5)
            grdProperties.DataBind()

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchItem.ClientID & "')")
        txtSearchYear.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchYear.ClientID & "')")
    End Sub


    Protected Sub ddAllotment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("GA_ID") = ddAllotment.SelectedItem.Value
        Try
            If ddAllotment.SelectedItem.Value = 1060 Or ddAllotment.SelectedItem.Value = 1062 Or ddAllotment.SelectedItem.Value = 1067 Then
                '==== LANDS
                txtAcqDate.Text = Date.Today.ToString("MM/dd/yyyy")
                Me.mvPPE.SetActiveView(Me.vwLand)

            Else
                txtEAcqDate.Text = Date.Today.ToString("MM/dd/yyyy")
                Me.mvPPE.SetActiveView(Me.vwEquipments)

            End If
            dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_PPEEncoding_Items] '" & ddAllotment.SelectedItem.Value & "', '" & Session("CYear") & "'", CommandType.Text)
            grdItemList.DataSource = dtItems
            grdItemList.DataBind()

            Load_EncodedProperties()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub grdItemList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdItemList, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub btnSearchItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dtItems As New DataTable
        dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_loadOld_Inventories] '" & ddAllotment.SelectedItem.Value & "', '" & Session("CYear") & "'", CommandType.Text)

        Dim myview As DataView
        myview = dtItems.DefaultView

        If ddSearch.SelectedItem.Value = 2 Then
            myview.RowFilter = "Item_Code like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%'"
        Else
            myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%'"
        End If

        grdItemList.DataSource = myview
        grdItemList.DataBind()

    End Sub

    Public Function createDatatableBarcode(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("no", GetType(Integer))
        dt.Columns.Add("barcode")
        dt.Columns.Add("PropertyNo")
        For i As Integer = 1 To row
            dr = dt.NewRow
            dr("no") = i
            dr("barcode") = ""
            dr("PropertyNo") = ""
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub grdItemList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddAllotment.SelectedItem.Value = 1060 Or ddAllotment.SelectedItem.Value = 1062 Or ddAllotment.SelectedItem.Value = 1067 Then
            'LANDS
            ddLandDepartment.DataSource = objDerived.GetDataTable("SELECT DISTINCT RC_Name,RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
            ddLandDepartment.DataTextField = ("RC_Name")
            ddLandDepartment.DataValueField = ("RC_ID")
            ddLandDepartment.DataBind()
            ddLandDepartment.Items.Insert(0, "Select")

        Else
            'EQUIPMENTS AND OTHERS PROPERTIES
            ddEquipDepartment.DataSource = objDerived.GetDataTable("SELECT DISTINCT RC_Name,RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
            ddEquipDepartment.DataTextField = ("RC_Name")
            ddEquipDepartment.DataValueField = ("RC_ID")
            ddEquipDepartment.DataBind()
            ddEquipDepartment.Items.Insert(0, "Select")

            btnSubmit.Enabled = True
        End If
    End Sub
    Protected Sub ddEquipDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddEquipFunction.DataSource = objDerived.GetDataTable("SELECT DISTINCT Function_ID, Function_Desc FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & ddEquipDepartment.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        ddEquipFunction.DataTextField = ("Function_Desc")
        ddEquipFunction.DataValueField = ("Function_ID")
        ddEquipFunction.DataBind()
        ddEquipFunction.Items.Insert(0, "Select")
    End Sub

    Protected Sub txtEAcqCost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEAcqCost.TextChanged
        txtEAcqCost.Text = FormatNumber(txtEAcqCost.Text, 2)
    End Sub

    Protected Sub txtEMarketValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEMarketValue.TextChanged
        txtEMarketValue.Text = FormatNumber(txtEMarketValue.Text, 2)
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtEAcqCost.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Acquisition cost of an item is required.")
        Else
            grdSerial.DataSource = createDatatableBarcode(CType(txtEQty.Text, Integer))
            grdSerial.DataBind()

            ModalPopupExtender1.Show()

        End If
    End Sub
    Protected Sub ddLandDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddLandFunction.DataSource = objDerived.GetDataTable("SELECT DISTINCT Function_ID, Function_Desc FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & ddLandDepartment.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        ddLandFunction.DataTextField = ("Function_Desc")
        ddLandFunction.DataValueField = ("Function_ID")
        ddLandFunction.DataBind()
        ddLandFunction.Items.Insert(0, "Select")
    End Sub

    Protected Sub txtAcqCost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtAcqCost.Text = FormatNumber(txtAcqCost.Text, 2)
    End Sub

    Protected Sub txtMarketValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtMarketValue.Text = FormatNumber(txtMarketValue.Text, 2)
    End Sub

    Protected Sub btnLandSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '==== SAVE PROPERTY HEADER
        With Prop_Hdr
            '.Property_ID = Property_ID
            .Property_Date = txtAcqDate.Text
            .Issuance = 0
            .Remarks = "Manual Encoding of Land Properties"
            .Emp_ID = 0
            .F_ID = 1
            .AIRDtl_ID = 0
            .deptid = ddLandDepartment.SelectedItem.Value
            .isDonated = False
            .GA_ID = Session("GA_ID")
            .DonationRemarks = ""
            .Qty = 1
            .Balance = 1
            .Cost = CType(txtAcqCost.Text, Decimal)
            .Item_ID = grdItemList.SelectedDataKey("Item_ID")
            .Property_code = grdItemList.SelectedDataKey("GA_Code")
            .RC_ID = ddLandDepartment.SelectedItem.Value
            .Function_ID = ddLandFunction.SelectedItem.Value
            .TD_ID = 1
            .Project_ID = 0
            .Program_id = 0
            .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & grdItemList.SelectedDataKey("Item_ID") & "' ", CommandType.Text)
        End With

        Dim PropHdr_ID As Integer
        PropHdr_ID = Prop_Hdr.save()

        '==== SAVE PROPERTY DETAILS
        With Prop_Dtl
            '.PropertyDetai_ID = 0
            .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtAcqDate.Text & "', '" & grdItemList.SelectedDataKey("GA_Code") & "', '" & ddLandDepartment.SelectedItem.Value & "','" & ddLandFunction.SelectedItem.Value & "')", CommandType.Text)
            .Property_ID = PropHdr_ID
            .Issued = False
            .Repair = False
            .Dispose = False
            .DisposeDate = "1/1/1900"
            .IsInspectionForDisposal = False
            .InspectionDate = txtAcqDate.Text
            .F_ID = 1
            .SerialNo = ""
            .Barcode = ""
            .Amount = CType(txtAcqCost.Text, Decimal)
            .Status = "Accepted"
            .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & grdItemList.SelectedDataKey("Item_ID") & "' ", CommandType.Text)
        End With

        Dim PropDtl_ID As Integer
        PropDtl_ID = Prop_Dtl.save()

        '==== SAVE LAND DETAILS
        With objLandDtl
            '.LandId = LandId
            .Property_Dtl_ID = PropDtl_ID
            '.LguCode = txtLandlgucode.Text
            '.SectionNo = txtLandSectionno.Text
            '.PIN = txtLandPIN.Text
            '.TDN = txtLandTdn.Text
            '.DistrictCode = txtLanddistrictcode.Text
            '.ParcelNo = txtLandParcelno.Text
            '.ARP = txtLandARP.Text
            '.CityMunCode = txtLandcitymunicipality1.Text
            '.SeriesNo = txtLandSeriesno.Text
            '.RevYear = txtLandrevyear.Text
            .BarangayCode = txtBrgyCode.Text
            '.RPTIN = txtLandRPTIN.Text
            '.DepreciationRate = txtLandDepriciationRate.Text
            '.DepreciationValue = txtLandDepreciatedValue.Text
            '.LotNo = txtLandlocationLot.Text
            '.BlkNo = txtLandlocationblkno.Text
            '.StreetName = txtLandlocationstreetname.Text
            '.Subdivision = txtLandlocationsubdivisionvillage.Text
            '.PhaseNo = txtLandlocationphaseno.Text
            '.Purok = txtLandlocationpurok.Text
            '.Sitio = txtLandlocationsitio.Text
            .Barangay = txtLocation.Text
            '.District = txtLandDistrict.Text
            '.CityMunicipal = txtLandCitymunicipality.Text
            .Province = "Cebu"
            '.Region = txtLandRegion.Text
            '.ZipCode = txtLandzipcode.Text
            '.Classification = txtLandClassification.Text
            '.SubClass = txtLandSubClass.Text
            '.LandUse = txtLandUse.Text
            .Area = txtArea.Text
            '.AVAmountWords = txtLandAssessedAmount.Text
            '.MVAmountWords = txtMarketValue.Text
            '.AssessmentLevel = dpLandAssessmentLvl.SelectedValue
            '.Status_1 = txtLandStatus1.Text
            '.Status_2 = txtLandStatus2.Text
            '.AssessedValue = txtLandAssessedValue.Text
            .MarketValue = txtMarketValue.Text
            '.UnitValue = txtLandUnitValue.Text
            '.Taxable = ddwnLandTaxable.SelectedItem.Text
            .AssessedDate = "01/01/1900"
            .MarketDate = "01/01/1900"
            .UnitDate = "01/01/1900"
            '.Received_ID = rcvID
            .TaxDeclarationNo = txtTaxDec.Text
            .AcqMode = txtAcqMode.Text
        End With

        Dim LandDtl_ID As Integer
        LandDtl_ID = objLandDtl.save()

        objDerived.GetRecords("INSERT INTO AMS.TbLand_OwnerHistory (LandId,OwnerName,Year) VALUES ('" & LandDtl_ID & "','" & txtPreviousOwner.Text & "','" & Year(txtAcqDate.Text) & "')", CommandType.Text)

        '==== SAVE PROPERTY LEDGER
        With Prop_Ledger
            .Ledger_ID = 0
            .PropertyNo = ""
            .SerialNo = ""
            .Trans_Type = "Manual Entry"
            .dDate = txtAcqDate.Text
            .Ref = ""
            .AccountablePerson = "" 'ddSupplier.SelectedItem.Text
            .Department = ddLandDepartment.SelectedItem.Text
            .Position = ""
            .AcceptedBy = "" 'ddacceptedby.SelectedItem.Text
            .InspectedBy = "" 'ddInspectedby.SelectedItem.Text
            .Item_ID = grdItemList.SelectedDataKey("Item_ID")
            .DebitQty = 1
            .DebitCost = CType(txtAcqCost.Text, Decimal)
            .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdItemList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdItemList.SelectedDataKey("Item_ID") & "'", CommandType.Text)

            Dim Eqty As Integer
            Dim Eqbalance As Decimal
            Dim dtledger As New DataTable

            dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & grdItemList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            If dtledger.Rows.Count = 0 Then
                Eqty = 0
                Eqbalance = 0.0
            Else
                Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & grdItemList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & grdItemList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            End If

            .BalanceQty = Eqty + 1
            .BalanceCost = CType(txtAcqCost.Text, Decimal) + CType(Eqbalance, Decimal)

        End With
        Prop_Ledger.save()

        btnLandSave.Enabled = False
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtLocation.Text = ""
        txtArea.Text = ""
        txtTaxDec.Text = ""
        txtPreviousOwner.Text = ""
        txtBrgyCode.Text = ""
        txtAcqCost.Text = ""
        txtAcqDate.Text = Date.Today.ToString("MM/dd/yyyy")
        txtAcqMode.Text = ""
        txtMarketValue.Text = ""
    End Sub

    Protected Sub btnSavePPE_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'SAVE EQUIPMENTS

        Try
            For i As Integer = 0 To grdSerial.Rows.Count - 1
                '==== CHECK IF PROPERTY NUMBER IS EXISTING : IT SHOULD BE UNIQUE
                Dim ID As Integer
                ID = objDerived.GetValue("SELECT TOP(1)[PropertyDetai_ID] FROM [AMS].[Property_Dtl] WHERE [PropertyNo] = '" & CType(grdSerial.Rows(i).FindControl("txtPropNo"), TextBox).Text & "'", CommandType.Text)
                If ID <> 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property Number already exists, it should be unique.")
                    ModalPopupExtender1.Show()
                    Exit Sub
                End If
            Next

            '==== SAVE PROPERTY HEADER
            With Prop_Hdr
                '.Property_ID = Property_ID
                .Property_Date = txtEAcqDate.Text
                .Issuance = 0
                .Remarks = "Manual Encoding of Old Properties"
                .Emp_ID = 0
                .F_ID = 1
                .AIRDtl_ID = 0
                .deptid = ddEquipDepartment.SelectedItem.Value
                .isDonated = False
                .GA_ID = ddAllotment.SelectedItem.Value
                .DonationRemarks = ""
                .Qty = txtEQty.Text
                .Balance = txtEQty.Text
                .Cost = CType(txtEAcqCost.Text, Decimal)
                .Item_ID = grdItemList.SelectedDataKey("Item_ID")
                .Property_code = grdItemList.SelectedDataKey("GA_Code")
                .RC_ID = ddEquipDepartment.SelectedItem.Value
                .Function_ID = ddEquipFunction.SelectedItem.Value
                .TD_ID = 1
                .Project_ID = 0
                .Program_id = 0
                .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & grdItemList.SelectedDataKey("Item_ID") & "' ", CommandType.Text)
            End With

            Dim PropHdr_ID As Integer = 0
            PropHdr_ID = Prop_Hdr.save()


            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

            '==== SAVE PROPERTY DETAILS
            For i As Integer = 0 To grdSerial.Rows.Count - 1

                With Prop_Dtl
                    '.PropertyDetai_ID = 0  
                    If CType(grdSerial.Rows(i).FindControl("txtPropNo"), TextBox).Text = "" Then
                        .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtEAcqDate.Text & "', '" & grdItemList.SelectedDataKey("GA_Code") & "','" & ddEquipDepartment.SelectedItem.Value & "','" & ddEquipFunction.SelectedItem.Value & "')", CommandType.Text)
                    Else
                        .PropertyNo = CType(grdSerial.Rows(i).FindControl("txtPropNo"), TextBox).Text
                    End If

                    .Property_ID = PropHdr_ID
                    .Issued = False
                    .Repair = False
                    .Dispose = False
                    .DisposeDate = "1/1/1900"
                    .IsInspectionForDisposal = False
                    .InspectionDate = txtEAcqDate.Text
                    .F_ID = 1
                    .SerialNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                    .Barcode = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                    .Amount = CType(txtEAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    .Details = txtESpecs.Text
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & grdItemList.SelectedDataKey("Item_ID") & "' ", CommandType.Text)
                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = Prop_Dtl.save()

                objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtEMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

                If Session("GA_ID") = 1118 Then
                    'Furniture and Fixtures

                    With objFurnitureInfo
                        .FurnitureInfoId = 0
                        .AIRDtl_ID = 0
                        .IsAccepted = True
                        .Property_Dtl_ID = PropDtl_ID
                        .SerialNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                        .Name = grdItemList.SelectedDataKey("Item_Desc")
                        .Description = grdItemList.SelectedDataKey("Item_Desc")
                        .DepreciationRate = "0.00"
                        .Dimension = ""
                        .AreaCapacity = ""
                        .Model = ""
                        .Warranty = ""
                        .DepreciationValue = "0.00"
                        .Specification = txtESpecs.Text
                    End With

                    Dim furn_info_id As Integer
                    furn_info_id = objFurnitureInfo.save()

                    objDerived.GetRecords("UPDATE AMS.TbFurniture_Info SET Received_ID = 0, Received_Dtl_ID = 0 WHERE FurnitureInfoId = '" & furn_info_id & "'", CommandType.Text)

                    With objFurnitureDtl
                        .FurnitureId = 0
                        .FurnitureInfoId = furn_info_id
                        .Property_Dtl_ID = PropDtl_ID
                        .Condition = ""
                        .MarketValue = txtEMarketValue.Text
                        .Location = ""
                        .Status = "Accepted"
                    End With
                    objFurnitureDtl.save()

                ElseIf Session("GA_ID") = 1127 Then
                    'Machineries

                    With objMachineInfo
                        .MachineryInfoId = 0
                        .AIRDtl_ID = 0
                        .IsAccepted = True
                        .Property_Dtl_ID = PropDtl_ID
                        .SerialNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                        .BrandModel = ""
                        .MachineDesc = grdItemList.SelectedDataKey("Item_Desc")
                        .MachineLocation = ""
                        .NoPassengers = ""
                        .ServiceFloors = ""
                        .MachineUnitNo = ""
                        .WorkingLoad = ""
                        .RatedSpeed = ""
                        .CarDimensions = ""
                        .DepreciationRate = "0.00"
                        .DepreciationValue = "0.00"
                        .MechinePermitNo = ""
                        .DateOperate = "1/1/1900"
                        .DateIssued = "1/1/1900"
                        .DateInspected = txtEAcqDate.Text
                        .InspectedBy = ""
                        .Remarks = txtESpecs.Text
                    End With
                    Dim mac_info_id As Integer
                    mac_info_id = objMachineInfo.save()

                    objDerived.GetRecords("UPDATE AMS.TbMachinery_Information SET Received_ID = 0, Received_Dtl_ID = 0 WHERE MachineryInfoId = '" & mac_info_id & "'", CommandType.Text)

                    With objMachineDtl
                        .MachineryId = 0
                        .MachineryInfoId = mac_info_id
                        .Property_Dtl_ID = PropDtl_ID
                        .MarketValue = txtEMarketValue.Text
                        .Condition = ""
                        .Location = ""
                        .Status = "Accepted"
                    End With
                    objMachineDtl.save()

                ElseIf Session("GA_ID") = 1166 Then
                    'Motor Vehicles

                    With objMotorInfo
                        .Motor_InfoId = 0
                        .AIRDtl_ID = 0
                        .IsAccepted = True
                        .Property_Dtl_ID = PropDtl_ID
                        .Name = grdItemList.SelectedDataKey("Item_Desc")
                        .PlateNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                        .MotorNo = ""
                        .Model = ""
                        .ChasisNo = ""
                        .VehicleColor = ""
                        .WheelsCapacity = ""
                        .GrossWeight = ""
                        .Seats = ""
                        .Warranty = ""
                        .VehicleOwner = ""
                        .DeclaredName = ""
                        .BeneficialUser = ""
                        .VehicleSpecification = txtESpecs.Text
                    End With
                    Dim motor_info_id As Integer
                    motor_info_id = objMotorInfo.save()

                    objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Received_ID = 0, Received_Dtl_ID = 0 WHERE Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)

                    With objMotorDtl
                        .MotorID = 0
                        .Motor_InfoId = motor_info_id
                        .Property_Dtl_ID = PropDtl_ID
                        .MarketValue = txtEMarketValue.Text
                        .Condition = ""
                        .Location = ""
                        .Status = "Accepted"
                    End With
                    objMotorDtl.save()
                Else
                    'ALL Equipments

                    Dim info_id As Integer
                    With objEquipInfo
                        .EquipInfoId = 0
                        .AIRDtl_ID = 0
                        .IsAccepted = True
                        .Property_Dtl_ID = PropDtl_ID
                        .SerialNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                        .Name = grdItemList.SelectedDataKey("Item_Desc")
                        .Description = grdItemList.SelectedDataKey("Item_Desc")
                        .PowerInput = ""
                        .Dimension = ""
                        .AreaCapacity = ""
                        .Model = ""
                        .Warranty = ""
                        .Specification = txtESpecs.Text
                        .DepreciationRate = "0"
                        .DepreciationValue = "0.00"
                    End With

                    info_id = objEquipInfo.save()
                    objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

                    With objEquipDtl
                        .EquipmentId = 0
                        .EquipInfoId = info_id
                        .Property_Dtl_ID = PropDtl_ID
                        .MarketValue = txtEMarketValue.Text
                        .Condition = ""
                        .Location = ""
                        .Status = "Accepted"
                    End With
                    objEquipDtl.save()

                End If
            Next

            '==== SAVE PROPERTY LEDGER
            With Prop_Ledger
                .Ledger_ID = 0
                .PropertyNo = ""
                .SerialNo = ""
                .Trans_Type = "Manual Entry"
                .dDate = txtEAcqDate.Text
                .Ref = ""
                .AccountablePerson = ""
                .Department = ddEquipDepartment.SelectedItem.Text
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = grdItemList.SelectedDataKey("Item_ID")
                .DebitQty = txtEQty.Text
                .DebitCost = txtEQty.Text * CType(txtEAcqCost.Text, Decimal)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdItemList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grdItemList.SelectedDataKey("Item_ID") & "'", CommandType.Text)

                Dim Eqty As Integer
                Dim Eqbalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & grdItemList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    Eqty = 0
                    Eqbalance = 0.0
                Else
                    Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & grdItemList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                    Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & grdItemList.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                End If

                .BalanceQty = Eqty + txtEQty.Text
                .BalanceCost = CType(txtEAcqCost.Text, Decimal) + CType(Eqbalance, Decimal)

            End With
            Prop_Ledger.save()

            btnSubmit.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            Load_EncodedProperties()
        Catch ex As Exception
        End Try

    End Sub


    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


    Protected Sub grdItemList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdItemList.DataSource = dtItems
        grdItemList.DataBind()
        grdItemList.PageIndex = e.NewPageIndex

    End Sub

 
    Protected Sub btnSearchProp_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


    Protected Sub Load_EncodedProperties()
        dtProperties = objDerived.GetDataTable("EXEC [AMS].[sp_EncodedProperty_List] '" & Session("GA_ID") & "'", CommandType.Text)
        grdProperties.DataSource = dtProperties
        grdProperties.DataBind()

        ddDepartment.ClearSelection()
        'ddDepartment.DataSource = Nothing
        'ddDepartment.DataBind()
        ddDepartment.Items.Insert(0, "Select")

        'ddFunction.DataSource = Nothing
        'ddFunction.DataBind()
        ddFunction.ClearSelection()
        ddFunction.Items.Insert(0, "Select")

        txtAmount.Text = "0.00"

    End Sub

    Protected Sub grdProperties_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

        grdProperties.DataSource = dtProperties
        grdProperties.PageIndex = e.NewPageIndex
        grdProperties.DataBind()

    End Sub

    Protected Sub txtAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtAmount.Text = FormatNumber(txtAmount.Text, 2)
    End Sub


    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddFunction.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & grdProperties.SelectedDataKey("RC_ID") & "' ORDER BY FUNCTION_DESC", CommandType.Text)
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
    End Sub


    Protected Sub grdProperties_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddDepartment.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_NAME", CommandType.Text)
        ddDepartment.DataTextField = ("RC_Name")
        ddDepartment.DataValueField = ("RC_ID")
        ddDepartment.DataBind()
        ddDepartment.SelectedValue = grdProperties.SelectedDataKey("RC_ID")

        ddFunction.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & grdProperties.SelectedDataKey("RC_ID") & "' ORDER BY FUNCTION_DESC", CommandType.Text)
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.SelectedValue = grdProperties.SelectedDataKey("Function_ID")

        txtAmount.Text = FormatNumber(grdProperties.SelectedDataKey("Amount"), 2)

        btnSaveProp.Enabled = True
        btnCancelProp.Enabled = True
        btnDelete.Enabled = True

    End Sub

    Protected Sub grdProperties_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdProperties, "Select$" + e.Row.RowIndex.ToString()))

        End If
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub btnSaveProp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim result As Integer
            result = objDerived.GetValue("EXEC [AMS].[sp_Update_Properties] '" & grdProperties.SelectedDataKey("Property_ID") & "','" & grdProperties.SelectedDataKey("Item_ID") & "','" & grdProperties.SelectedDataKey("Property_Date") & "', " & _
                        " '" & grdProperties.SelectedDataKey("Amount") & "','" & grdProperties.SelectedDataKey("RC_ID") & "','" & grdProperties.SelectedDataKey("Function_ID") & "','" & grdProperties.SelectedDataKey("RC_Name") & "', " & _
                        " '" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & replaceapostrophe(ddDepartment.SelectedItem.Text) & "','" & CType(txtAmount.Text, Decimal) & "'", CommandType.Text)

            If result = 1 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                Load_EncodedProperties()
                btnSaveProp.Enabled = False
                btnCancelProp.Enabled = False
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No update has been made, property already been issued.")
            End If
            
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error occured, contact system admin.")
        End Try
    End Sub

    Protected Sub btnCancelProp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Load_EncodedProperties()
    End Sub

    Protected Sub btnSearchYear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtProperties.DefaultView
        myview.RowFilter = "Property_Year = " & txtSearchYear.Text & ""
        grdProperties.DataSource = myview
        grdProperties.DataBind()
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            objDerived.Execute("EXEC [AMS].[sp_DeleteEncodedProperties] '" & grdProperties.SelectedDataKey("Property_ID") & "','" & Session("GA_ID") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property has been successfully deleted.")
            Load_EncodedProperties()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error occured, contact system admin.")

        End Try

    End Sub


End Class
