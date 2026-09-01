
Imports System.Data

Partial Class Inventory_Encoding_MedicalEquipment
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal

    Private Sub Inventory_Encoding_MedicalEquipment_Load(sender As Object, e As EventArgs) Handles Me.Load
        'objx.GetAccessRight(Me.Session("@UserName"), Page)
        'If objx.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If
        If Not Page.IsPostBack Then
            txtDate.text = Date.Now.ToString("MM-dd-yyyy")

            Dim Classification As New DataTable
            Classification = objDerived.GetDataTable("select [ClassificationId],[ClassificationName] From [dbo].[tbl_Classification] where [ClassificationName] like 'Medical equipment%'", CommandType.Text)
            loadMedicalSupplies()
            loadEquipmentLedger()
            'ddClass.DataSource = CType(Classification, DataTable)
            'Me.ddClass.DataTextField = ("ClassificationName")
            'Me.ddClass.DataValueField = ("ClassificationId")
            'Me.ddClass.DataBind()
            'selectClassification()


        End If
        'loadEquipmentLedger()
    End Sub

    Public Sub loadMedicalSupplies()
        Dim Classification As String
        Classification = objDerived.GetValue("select [ClassificationId] From [dbo].[tbl_Classification] where [ClassificationName] like 'Medical equipment%'", CommandType.Text)

        Dim itemdesc As New DataTable
        Dim dtitemdesc As New DataTable
        dtitemdesc = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_v2_03102022] " & Classification, CommandType.Text)
        drpName.datasource = dtitemdesc
        drpName.DataTextField = ("ItemDescription")
        drpName.DataValueField = ("Item_ID")
        drpName.DataBind()
        drpName.enabled = True

        loadEquipmentInformation_from_drpName()
        'loadEquipmentList()
        loadEquipmentLedger()
    End Sub
    Protected Sub loadEquipmentInformation_from_drpName()
        Dim CYear As String = "CY" & Year(txtdate.text)
        Dim itemid As String
        loadUnit()
        ' loadwarehouse()
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
            hdnGAId.value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & HDnItemNo.value, CommandType.Text)
            txtName.Text = dt.Rows(0).Item("Name").ToString
            txtequipmentdesciption.Text = dt.Rows(0).Item("description").ToString
            txtequipmentpowerinput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtequipmentdimension.Text = objDerived.GetValue("select e.Dimension from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtequipmentareacapacity.Text = objDerived.GetValue("select e.AreaCapacity from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtequipmentmodel.Text = objDerived.GetValue("select e.Model from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtequipmentwaranty.Text = objDerived.GetValue("select e.Warranty from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtSpecification.Text = objDerived.GetValue("select e.Specification from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtEAcqDate.text = objDerived.GetValue("select c.Property_Date from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtEAcqCost.text = objDerived.GetValue("select c.Cost from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtEMarketValue.text = dt.Rows(0).Item(CYear).ToString
            'Dim DA As DateTime
            'DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")
            txtNoYears.Text = " "
            txtequipmentdepreciatedvalue.Text = FormatNumber(0, 2)
            lblequipmentdepreciatedRate.Text = " "
            lblequipmentdepreciatedRate.readonly = False


            '''--------------------location
            Dim location As String
            location = objDerived.GetValue("select Location from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Dtl  as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)
            'If location IsNot Nothing Then
            '    Dim locationsplit As String() = location.Split("-")
            '    If location.Contains("Bay") Then
            '        txtEquipmentBay.text = locationsplit(1)
            '    ElseIf location.Contains("Column") Then
            '        txtEquipmentColumn.text = locationsplit(1)
            '    ElseIf location.Contains("Floor") Then
            '        txtEquipmentFloor.text = locationsplit(1)
            '    ElseIf location.Contains("Room") Then
            '        txtEquipmentRoom.text = locationsplit(1)
            '    ElseIf location.Contains("Shelves") Then
            '        txtEquipmentShelves.text = locationsplit(1)
            '    ElseIf location.Contains("Rack") Then
            '        txtEquipmentRack.text = locationsplit(1)
            '    ElseIf location.Contains("Bin") Then
            '        txtEquipmentBin.text = locationsplit(1)
            '    End If

            '    Dim warehouse As String
            '    warehouse = objDerived.GetValue("select warehouseid from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Dtl  as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            '    drpEquipmentWarehouse.selectedvalue = warehouse

            'End If


            txtUsefulLife.Text = ""
            txtSalvageValue.Text = FormatNumber(0, 2)
            txtSalvageValue.Text = ""
            Session("useful_life") = 0

            drpUnit.items.FindByValue(dt.Rows(0).Item(9)).Selected = True
            btnSave.enabled = True
            btnCancel.enabled = True

        End If
    End Sub

    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpUnit.datasource = dt
        drpUnit.DataTextField = ("Description")
        drpUnit.DataValueField = ("Unit_ID")
        drpUnit.DataBind()
    End Sub

    Protected Sub LoadEquipDTL()
        txtName.Text = ""
        txtequipmentdesciption.Text = ""
        txtequipmentpowerinput.Text = ""
        lblequipmentdepreciatedRate.Text = ""
        txtequipmentdimension.Text = ""
        txtequipmentareacapacity.Text = ""
        txtequipmentmodel.Text = ""
        txtequipmentwaranty.Text = ""
        lblequipmentdepreciatedvalue.Text = ""
        'txtSpecification.Text = ""
        txtSalvageValue.Text = ""
    End Sub

    Protected Sub btnEquipmentLedger_Click(sender As Object, e As EventArgs)
        loadEquipmentLedger()
    End Sub
    Protected Sub btnequipmentrepairs_Click(sender As Object, e As EventArgs)
        loadEquipmentRepair()
    End Sub

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

    Protected Sub loadEquipmentRepair()
        btnEquipmentLedger.CssClass = "Initial"
        btnequipmentrepairs.CssClass = "Clicked"
        btnequipmentattachdoc.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwrepairsandmaintenance) '[dbo].[View_EquipmentRepair]
        Dim dtAccount As New DataTable

        '        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_RepairAndMaintenance] where PropertyNo = '" & grdlistofEuipment.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_RepairAndMaintenance] where PropertyNo = null", CommandType.Text)
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
        '  dtAccount = objDerived.GetDataTable("Select *  from AMS.DocumentAttachment where IdentityNo = '" & grdlistofEuipment.SelectedDataKey("PODtl_ID") & "' and TableName = 'AIR_EquipAttchDocu'", CommandType.Text)
        dtAccount = objDerived.GetDataTable("Select *  from AMS.DocumentAttachment where IdentityNo = null and TableName = 'AIR_EquipAttchDocu'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable3(7 - dtAccount.Rows.Count))
        End If
        grdpropertydocdetails.DataSource = dtAccount
        grdpropertydocdetails.DataBind()
        grdpropertydocdetails.SelectedIndex = 0

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
    Public Sub LoadBuildings()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        drpInstalledAtBuilding.datasource = dt
        drpInstalledAtBuilding.DataTextField = ("Name")
        drpInstalledAtBuilding.DataValueField = ("BuildingId")
        drpInstalledAtBuilding.DataBind()
        drpInstalledAtBuilding.Items.Insert(0, New ListItem("Please select"))
    End Sub

    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim ddlCountries As DropDownList = CType(e.Row.FindControl("drpDepartment"), DropDownList)
            ddlCountries.DataSource = objDerived.GetDataTable("SELECT DISTINCT UPPER(RC_Name) AS RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
            ' ddlCountries.DataSource = dtDepartment
            ddlCountries.DataTextField = ("RC_Name")
            ddlCountries.DataValueField = ("RC_ID")
            ddlCountries.DataBind()

            'Add Default Item in the DropDownList
            ddlCountries.Items.Insert(0, New ListItem("Please select"))


        End If
        ViewState("Customers") = DirectCast(grdPropertyInfo.DataSource, DataTable)

    End Sub
    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        'For Each row As GridViewRow In grdPropertyInfo.Rows

        '    Dim _str As String = TryCast(row.FindControl("txtPropertyNo"), textbox).Text
        '    msgbox(_str)
        'Next

        ModalPopupExtender2.hide()
    End Sub
    Protected Sub BindGrid()
        grdPropertyInfo.DataSource = DirectCast(ViewState("Customers"), DataTable)
        grdPropertyInfo.DataBind()
    End Sub
    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)
        If txtEquipmentQuantity.text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
        Else
            Dim dt As New DataTable()
            ' dt.Columns.AddRange(New DataColumn(1) {New DataColumn("Name"), New DataColumn("Country")})
            ' dt = ViewState("Customers")
            For i As Integer = 0 To txtEquipmentQuantity.text - 1
                dt.Rows.Add()
            Next

            ViewState("Customers") = dt
            Me.BindGrid()

            ModalPopupExtender2.show()
        End If

    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        If txtName.text = "" Or txtequipmentdesciption.text = "" Or txtUsefulLife.text = "" Or lblequipmentdepreciatedRate.text = "" Or txtEAcqCost.text = "" Or txtequipmentdepreciatedvalue.text = "" Or txtSalvageValue.text = "" Or txtEMarketValue.text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")

        Else
            If Not IsNumeric(lblequipmentdepreciatedRate.text) Or Not IsNumeric(txtEAcqCost.text) Or Not IsNumeric(txtequipmentdepreciatedvalue.text) Or Not IsNumeric(txtSalvageValue.text) Or Not IsNumeric(txtEMarketValue.text) Then
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
                    .Qty = txtEquipmentQuantity.text
                    .Balance = txtEquipmentQuantity.text
                    .Cost = CType(txtEAcqCost.Text, Decimal)
                    .Item_ID = hdnItemNo.value
                    .Property_code = objDerived.GetValue("select ga_code2 from [AMS].[vw_item_master_list] where Item_ID ='" & hdnItemNo.value & "' ", CommandType.Text)
                    .RC_ID = 0
                    .Function_ID = 0
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
                        .InspectionDate = txtEAcqDate.Text
                        .F_ID = 1
                        .SerialNo = txtequipmentSerialNo.text
                        .Barcode = " "
                        .Amount = CType(txtEAcqCost.Text, Decimal)
                        .Status = "Accepted"
                        .Details = "" 'txtSpecification.Text
                        .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.value & "' ", CommandType.Text)
                        .RC_ID = CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).SelectedItem.value
                        .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
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
                        .SerialNo = txtequipmentSerialNo.text
                        .Name = txtName.text
                        .Description = txtequipmentdesciption.text
                        .PowerInput = txtequipmentpowerinput.text
                        .Dimension = txtequipmentdimension.text
                        .AreaCapacity = txtequipmentareacapacity.text
                        .Model = txtequipmentmodel.text
                        .Warranty = txtequipmentwaranty.text
                        .Specification = "" 'txtSpecification.Text
                        .DepreciationRate = lblequipmentdepreciatedRate.text
                        .DepreciationValue = txtequipmentdepreciatedvalue.text
                        .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                        .RoomLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIRoom"), TextBox).Text
                        .RC_ID = CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).SelectedItem.value
                        .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text


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

                        'If String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        '    location = "Bay-" & txtEquipmentBay.text
                        'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        '    location = "Column-" & txtEquipmentColumn.text
                        'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        '    location = "Floor-" & txtEquipmentFloor.text
                        'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        '    location = "Room-" & txtEquipmentRoom.text
                        'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        '    location = "Shelves-" & txtEquipmentShelves.text
                        'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        '    location = "Rack-" & txtEquipmentRack.text
                        'ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) Then
                        '    location = "Bin-" & txtEquipmentBin.text
                        'End If
                        .Location = location
                        .Status = "Accepted"
                        .WarehouseID = 1 'drpEquipmentWarehouse.selectedvalue
                        .BuildingId = drpInstalledAtBuilding.selecteditem.value
                        .MaintenanceContactNo = txtContractor.text
                        .MaintenanceContactPerson = txtContactPerson.text
                        .MaintenanceContractor = txtCellphoneNo.text

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
                    .Item_ID = hdnItemNo.value
                    .DebitQty = txtEquipmentQuantity.text
                    .DebitCost = CType(txtEAcqCost.Text, Decimal) * txtEquipmentQuantity.text
                    .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.value & "'", CommandType.Text)
                    .CreditQty = "0"
                    .CreditUnit = "-"
                    .CreditCost = "0.00"
                    .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.value & "'", CommandType.Text)

                    Dim Eqty As Integer
                    Dim Eqbalance As Decimal
                    Dim dtledger As New DataTable

                    dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.value & "'", CommandType.Text)
                    If dtledger.Rows.Count = 0 Then
                        Eqty = 0
                        Eqbalance = 0.0
                    Else
                        Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.value & "'", CommandType.Text)
                        Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.value & "'", CommandType.Text)
                    End If
                    .BalanceQty = Eqty + txtEquipmentQuantity.text
                    .BalanceCost = (CType(txtEAcqCost.Text, Decimal) * txtEquipmentQuantity.text) + CType(Eqbalance, Decimal)
                End With
                Prop_Ledger.save()



                btnsave.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                'multiviewselected()
                'loadEquipmentList()
                'loadEquipmentInformation()
                loadEquipmentInformation_from_drpName()
                loadEquipmentLedger()
            End If
        End If


    End Sub
End Class
