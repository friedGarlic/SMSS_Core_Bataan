
Imports System.Data
Imports System.Drawing

Partial Class Inventory_Encoding_Land
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Private Prop_Hdr As New t_property_hdr
    Dim item As New m_item
    Dim item_detail As New m_item_detail
    Private Prop_Dtl As New t_property_dtl
    Dim objLandDtl As New ConsolidatedPropertySaving.TBLand_Details
    Private Prop_Ledger As New t_PropertyLedger



    Private Sub Inventory_Encoding_Land_Load(sender As Object, e As EventArgs) Handles Me.Load
        objx.GetAccessRight(Me.Session("@UserName"), Page)
        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then

            Dim Classification As New DataTable
            Classification = objDerived.GetDataTable("SELECT TOP (100) PERCENT a.ClassificationId, a.ClassificationName " &
                                                    " FROM dbo.tbl_Classification AS a INNER JOIN " &
                                                    "  dbo.tblclassmatrix AS b ON a.ClassificationId = b.classificationid " &
                                                    "  WHERE(a.isenable = 1) " &
                                                    "  Group BY a.ClassificationId, a.ClassificationName, a.SeqNo " &
                                                    "  ORDER BY a.SeqNo", CommandType.Text)
            ddClass.DataSource = CType(Classification, DataTable)
            Me.ddClass.DataTextField = ("ClassificationName")
            Me.ddClass.DataValueField = ("ClassificationId")
            Me.ddClass.DataBind()
            selectClassification()

            ddBrgy1.DataSource = objDerived.GetDataTable("Select * from dbo.tbl_Brgy_Invent", CommandType.Text)
            ddBrgy1.DataTextField = ("Brgy_Name")
            ddBrgy1.DataValueField = ("Brgy_ID")
            ddBrgy1.DataBind()
            ddBrgy1.Items.Insert(0, "Select")

        End If

        loadLandLedger()
    End Sub
    Public Function selectClassification()
        '  lblClass.text = ddClass.selecteditem.text
        ' lblClass1.text = ddClass.selecteditem.text
        'Dim PListofGL As New DataTable
        'PListofGL = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & ddClass.selecteditem.value & "'", CommandType.Text)
        'Me.ddGlAccount.items.add("Select")
        'Me.ddGlAccount.DataSource = CType(PListofGL, DataTable)
        'Me.ddGlAccount.DataTextField = ("GA_Title")
        'Me.ddGlAccount.DataValueField = ("GA_ID")
        'Me.ddGlAccount.DataBind()
        'Me.ddGlAccount.enabled = True
        'SelectGAaccount()
    End Function

    Protected Sub ddClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectClassification()
    End Sub
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "LAND"
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

        grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)
    End Sub
    Public Sub loadLandLedger()
        ' btnEquipmentLedger.CssClass = "Clicked"
        'btnequipmentrepairs.CssClass = "Initial"
        ' btnequipmentattachdoc.CssClass = "Initial"
        ' Me.mvledger.SetActiveView(Me.vwledger)

        Dim dtAccount As New DataTable
        Dim itemid As String
        'If 

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "' order by dDate", CommandType.Text)

        dtAccount = objDerived.GetDataTable("Exec [AMS].[sp_LandPropertyLedger]", CommandType.Text)

        ' dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
    End Sub
    Public Function createdatatableledger(ByVal row As Integer) As DataTable
        'Dim dt As New DataTable()
        'Dim dr As DataRow
        'Dim myDataColumn As DataColumn
        'myDataColumn = New DataColumn()
        ''dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        'dt.Columns.Add("dDate", GetType(Date))
        'dt.Columns.Add("Trans_Type", GetType(String))
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
        'For i As Integer = 0 To row
        '    dr = dt.NewRow
        '    'dr("Property_Dtl_ID") = DBNull.Value
        '    dr("dDate") = DBNull.Value
        '    dr("Trans_Type") = DBNull.Value
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
        'Optimize Code
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add(New DataColumn("dDate", GetType(Date)))
        dt.Columns.Add(New DataColumn("Trans_Type", GetType(String)))
        dt.Columns.Add(New DataColumn("ref", GetType(String)))
        dt.Columns.Add(New DataColumn("AccountablePerson", GetType(String)))
        dt.Columns.Add(New DataColumn("Department", GetType(String)))
        dt.Columns.Add(New DataColumn("position", GetType(String)))
        dt.Columns.Add(New DataColumn("acceptedby", GetType(String)))
        dt.Columns.Add(New DataColumn("inspectedby", GetType(String)))
        dt.Columns.Add(New DataColumn("DebitQty", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DebitUnit", GetType(String)))
        dt.Columns.Add(New DataColumn("DebitCost", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("CreditQty", GetType(Integer)))
        dt.Columns.Add(New DataColumn("CreditUnit", GetType(String)))
        dt.Columns.Add(New DataColumn("CreditCost", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("BalQty", GetType(Integer)))
        dt.Columns.Add(New DataColumn("BalanceUnit", GetType(String)))
        dt.Columns.Add(New DataColumn("BalCost", GetType(Decimal)))

        dt.BeginLoadData()

        Dim values() As Object = {DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value}

        For i As Integer = 0 To row
            dr = dt.Rows.Add()
            dr.ItemArray = values
        Next

        dt.EndLoadData()

        Return dt
    End Function
    Public Sub SaveRecord()
        With item
            .Item_Code = ""
            .Item_Desc = txtLocation.Text
            .Unit_ID = objDerived.GetValue("select * From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
        End With
        'item.save()
        Dim itemid As Integer
        itemid = item.save()
        objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & Val(txtAcqCost.Text) & "',null", CommandType.Text)

        Dim classification As String = objDerived.GetValue("select  a.ClassificationId From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Land%'", CommandType.Text)
        Dim category As Integer = objDerived.GetValue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & itemid, CommandType.Text)
        Dim gaid As Integer = objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Land%' ", CommandType.Text)
        Dim matrix As String = objDerived.GetValue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & gaid & " and item_id = " & itemid & "", CommandType.Text)

        If matrix = "" Then
            objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id) values('" & classification & "','" & gaid & "','" & itemid & "','" & category & "','0')", CommandType.Text)
        End If

        With Prop_Hdr
            '.Property_ID = Property_ID
            .Property_Date = txtEAcqDate.Text
            .Issuance = 0
            .Remarks = "Manual Encoding of Land Properties"
            .Emp_ID = 0
            .F_ID = 1
            .AIRDtl_ID = 0
            .deptid = 0
            .isDonated = False
            .GA_ID = objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Land%' ", CommandType.Text)
            .DonationRemarks = ""
            .Qty = 1
            .Balance = 1
            .Cost = CType(txtAcqCost.Text, Decimal)
            .Item_ID = itemid
            .Property_code = objDerived.GetValue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Land%' ", CommandType.Text)
            .RC_ID = 0
            .Function_ID = 0
            .TD_ID = 1
            .Project_ID = 0
            .Program_id = 0
            .Particular = ""
        End With

        Dim PropHdr_ID As Integer
        PropHdr_ID = Prop_Hdr.save()

        Dim GaCode As String
        GaCode = objDerived.GetValue("select GA_Code  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Land%' ", CommandType.Text)

        '==== SAVE PROPERTY DETAILS
        With Prop_Dtl
            '.PropertyDetai_ID = 0
            .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & txtEAcqDate.Text & "', '" & GaCode & "', '" & itemid & "')", CommandType.Text)
            .Property_ID = PropHdr_ID
            .Issued = False
            .Repair = False
            .Dispose = False
            .DisposeDate = "1/1/1900"
            .IsInspectionForDisposal = False
            .InspectionDate = txtEAcqDate.Text
            .F_ID = 1
            .SerialNo = ""
            .Barcode = ""
            .Amount = CType(txtAcqCost.Text, Decimal)
            .Status = "Accepted"
            .type = "Land"
        End With

        Dim PropDtl_ID As Integer
        PropDtl_ID = Prop_Dtl.save()

        '==== SAVE LAND DETAILS
        With objLandDtl
            '.LandId = LandId
            .Property_Dtl_ID = PropDtl_ID
            .LguCode = txtLGUCode.Text
            .SectionNo = txtSectionNo.Text
            .PIN = txtPIN.Text
            .TDN = txtTDN.Text
            .DistrictCode = txtDistrictCode.Text
            .ParcelNo = txtParcelNo.Text
            .ARP = txtARP.Text
            .CityMunCode = txtCityCode.Text
            .SeriesNo = txtSeriesNo.Text
            .RevYear = txtRevYear.Text
            .BarangayCode = txtBrgyCode.Text
            .RPTIN = txtRPTIN.Text
            .DepreciationRate = IIf(txtDepRate.Text = "", 0, txtDepRate.Text)
            .DepreciationValue = IIf(txtDepValue.Text = "", 0, txtDepValue.Text)
            .LotNo = txtLotNo.Text
            .BlkNo = txtBlkNo.Text
            .StreetName = txtStreet.Text
            .Subdivision = txtSubdivision.Text
            .PhaseNo = txtPhaseNo.Text
            .Purok = txtPurok.Text
            .Sitio = txtSitio.Text
            .Barangay = txtBrgy.Text
            .District = txtDistrict.Text
            .CityMunicipal = txtCityMun.Text
            .Province = txtProvince.Text
            .Region = TxtRegion.Text
            .ZipCode = txtZipCode.Text
            .Classification = txtClassification.Text
            .SubClass = txtSubClass.Text
            .LandUse = txtLandUse.Text
            .Area = txtSubClassArea.Text
            '.AVAmountWords = txtLandAssessedAmount.Text
            '.MVAmountWords = txtMarketValue.Text
            .AssessmentLevel = TextBox3.Text
            .Status_1 = txtStatus.Text
            .Status_2 = TxtStatus1.Text
            .AssessedValue = IIf(txtAssessedValue.Text = "", 0, txtAssessedValue.Text.Replace(",", ""))
            .MarketValue = IIf(txtCharacteristicsMarketValue.Text = "", 0, txtCharacteristicsMarketValue.Text.Replace(",", ""))
            .UnitValue = IIf(txtUnitValue.Text = "", 0, txtUnitValue.Text.Replace(",", ""))
            .Taxable = txtTaxable.Text
            .AssessedDate = IIf(txtAssessedValueDate.Text = "", Date.Now, txtAssessedValueDate.Text)
            .MarketDate = IIf(txtMarketValueDate.Text = "", Date.Now, txtMarketValueDate.Text)
            .UnitDate = IIf(txtUnitValueDate.Text = "", Date.Now, txtUnitValueDate.Text.Replace(",", ""))
            '.Received_ID = rcvID
            .TaxDeclarationNo = ddTaxDecNo.SelectedItem.Text
            .AcqMode = txtAcqMode.Text
            .FullAddress = txtLocation.Text
            .Barangay1 = ddBrgy1.SelectedItem.Text
            .Area1 = txtArea.Text
            .MarketValue1 = IIf(txtMarketValue.Text.Replace(",", "") = "", 0, txtMarketValue.Text.Replace(",", ""))
            .AVAmount = IIf(txtAssessedValueAmount.Text = "", 0, txtAssessedValueAmount.Text.Replace(",", ""))
            .MVAmount = IIf(txtMarketValueAmount.Text = "", 0, txtMarketValueAmount.Text.Replace(",", ""))


        End With

        Dim LandDtl_ID As Integer
        LandDtl_ID = objLandDtl.save()

        objDerived.GetRecords("INSERT INTO AMS.TbLand_OwnerHistory (LandId,OwnerName,Year) VALUES ('" & LandDtl_ID & "','" & txtPrevOwner.Text & "','" & Year(txtEAcqDate.Text) & "')", CommandType.Text)


        '==== SAVE PROPERTY LEDGER
        With Prop_Ledger
            .Ledger_ID = 0
            objDerived.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & txtEAcqDate.Text & "', '" & GaCode & "', '" & itemid & "')", CommandType.Text)
            .SerialNo = ""
            .Trans_Type = "Manual Entry"
            .dDate = txtEAcqDate.Text
            .Ref = ""
            .AccountablePerson = "" 'ddSupplier.SelectedItem.Text
            .Department = ""
            .Position = ""
            .AcceptedBy = "" 'ddacceptedby.SelectedItem.Text
            .InspectedBy = "" 'ddInspectedby.SelectedItem.Text
            .Item_ID = itemid
            .DebitQty = 1
            .DebitCost = CType(txtAcqCost.Text.Replace(",", ""), Decimal)
            .DebitUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            .BalanceUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)

            Dim Eqty As Integer
            Dim Eqbalance As Decimal
            Dim dtledger As New DataTable

            dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
            If dtledger.Rows.Count = 0 Then
                Eqty = 0
                Eqbalance = 0.0
            Else
                Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
                Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
            End If

            .BalanceQty = Eqty + 1
            .BalanceCost = CType(txtAcqCost.Text, Decimal) + CType(Eqbalance, Decimal)

        End With
        Prop_Ledger.save()

        btnLandSave.Enabled = False
        hdnItemNo.Value = itemid
        loadLandLedger()
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
    End Sub
    Protected Sub btnLandSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ''Dim itemdesc As String = objDerived.GetValue("select * From dbo.m_item where Item_Desc like '%" & txtBuildingName.text & "%'", CommandType.Text)
        ''If itemdesc <> "" Then
        ''    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Building Already Exists")
        ''    Exit Sub
        ''End If
        'Dim dt As New DataTable
        'dt = objDerived.GetDataTable("select * from AMS.TbLand_Dtl  where ParcelNo='" & txtParcelNo.Text & "'", CommandType.Text)

        'If dt.Rows.Count > 1 Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Parcel No. Already Exists")
        'Else

        If btnLandSave.Text = "SAVE" Then


            Call SaveRecord()
        Else

        End If
        ' End If
    End Sub
    Protected Sub txtArea_TextChanging(sender As Object, e As EventArgs)

    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)

    End Sub
    Protected Sub ddTaxDecNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddTaxDecNo.SelectedIndexChanged

    End Sub
End Class
