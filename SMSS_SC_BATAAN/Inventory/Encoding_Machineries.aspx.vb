
Imports System.Data
Imports System.Drawing

Partial Class Inventory_Encoding_Machineries
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Dim item As New m_item
    Private Prop_Ledger As New t_PropertyLedger
    Dim Prop_Hdr As New t_property_hdr
    Dim Prop_Dtl As New t_property_dtl
    Dim objMachineInfo As New ConsolidatedPropertySaving.TbMachinery_Information
    Dim objMachineDtl As New ConsolidatedPropertySaving.TbMachinery_Dtl
    Dim idholder As String = ""

    Protected Sub btnEquipmentLedger_Click(sender As Object, e As EventArgs)
        'loadEquipmentLedger()
    End Sub
    Protected Sub btnequipmentrepairs_Click(sender As Object, e As EventArgs)
        ' loadEquipmentRepair()
    End Sub
    Protected Sub btnequipmentattachdoc_Click(sender As Object, e As EventArgs)
        ' loadEquipmentAttchDocu()
        ' loadAttchDocuChangeIndex()
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

        'Optimize Code
        'Dim headerInfo() As String = {"EQUIPMENT", "DEBIT", "DEBIT", "CREDIT", "CREDIT", "BALANCE", "BALANCE"}
        'Dim colSpans() As Integer = {4, 2, 2, 2, 2, 2, 2}

        'Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)

        'For i As Integer = 0 To headerInfo.Length - 1
        '    Dim cell As New TableHeaderCell()
        '    cell.ColumnSpan = colSpans(i)
        '    cell.Text = headerInfo(i)
        '    cell.BorderWidth = 2
        '    cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        '    row.Controls.Add(cell)
        'Next

        'row.BackColor = ColorTranslator.FromHtml("WHITE")
        'row.ForeColor = ColorTranslator.FromHtml("BLACK")
        'grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)
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
    Protected Sub grdLedger1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtAccount As New DataTable
        If idholder = "" Then

            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedgerList]", CommandType.Text)

        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & idholder & "'", CommandType.Text)

        End If
        grdLedger1.PageIndex = e.NewPageIndex
        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
    End Sub
    Private Sub Inventory_Encoding_Machineries_Load(sender As Object, e As EventArgs) Handles Me.Load
        objx.GetAccessRight(Me.Session("@UserName"), Page)
        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            loadUnit()
            LoadBuildings()
        End If
        loadEquipmentLedger()
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
        If idholder = "" Then

            dtAccount = objDerived.GetDataTable("Exec [AMS].[MachineryLedgerList]", CommandType.Text)

        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[MachineryLedgerList]", CommandType.Text)

        End If
        ''dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

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

    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpMachineryUnit.DataSource = dt
        drpMachineryUnit.DataTextField = ("Description")
        drpMachineryUnit.DataValueField = ("Unit_ID")
        drpMachineryUnit.DataBind()
    End Sub
    Protected Sub drpMachineryUnit_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Public Sub LoadBuildings()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        drpInstalledAtBuilding.DataSource = dt
        drpInstalledAtBuilding.DataTextField = ("Name")
        drpInstalledAtBuilding.DataValueField = ("BuildingId")
        drpInstalledAtBuilding.DataBind()
        drpInstalledAtBuilding.Items.Insert(0, New ListItem("N/A"))
    End Sub

    'TODO See if it still duplicates, as ms Ally saw it duplicating.
    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Dim a As String
        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            'msgbox(CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text)

            If CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text = "" Then
                a = ""
            Else
                a = 1
            End If
        Next

        If a = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill Up the Property Information Fields")
            Exit Sub
        End If

        'If txtMachineryName.Text = "" Or txtMachineryDescription.Text = "" Or txtEAcqDate.Text = "" Or txtEAcqCost.Text = "" Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill Up the Required Fields : \n Name , Description , Installed at , Acquisition Date , Acquisition Cost")
        'Else
        If Not IsNumeric(lblequipmentdepreciatedRate.Text) Or Not IsNumeric(txtEAcqCost.Text) Or Not IsNumeric(txtequipmentdepreciatedvalue.Text) Or Not IsNumeric(txtSalvageValue.Text) Or Not IsNumeric(txtEMarketValue.Text) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: \n Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
        Else
            'Dim AValue As Integer
            'AValue = objDerived.getvalue("select * from dbo.m_item where Item_Desc = '" & txtMachineryName.Text & "'", CommandType.Text)
            'If AValue > 0 Then
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Machine name is already exist!")
            'Else
            With item
                .Item_Code = ""
                .Item_Desc = txtMachineryName.Text
                .Unit_ID = drpMachineryUnit.SelectedItem.Value
            End With

            Dim itemid As Integer
            itemid = item.save()
            objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & txtEAcqCost.Text.Replace(",", "") & "',null", CommandType.Text)

            Dim classification As String = objDerived.GetValue("EXEC [dbo].[usp_GetClassificationIdByClassificationName] ", CommandType.Text)

            'objDerived.GetValue("select  a.ClassificationId From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%'", CommandType.Text)
            Dim category As Integer = objDerived.GetValue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & itemid, CommandType.Text)
            Dim gaid As Integer = objDerived.GetValue("EXEC [AMS].[GetMachineryGA_ID] ", CommandType.Text)
            'objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%' ", CommandType.Text)
            Dim matrix As String = objDerived.GetValue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & gaid & " and item_id = " & itemid & "", CommandType.Text)

            If matrix = "" Then
                objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id) values('" & classification & "','" & gaid & "','" & itemid & "','" & category & "','0')", CommandType.Text)
            End If



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
                .GA_ID = objDerived.GetValue("EXEC [AMS].[GetMachineryGA_ID] ", CommandType.Text)
                'objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%' ", CommandType.Text)

                .DonationRemarks = ""
                .Qty = 1
                .Balance = txtMachineryQuantity.Text
                .Cost = CType(txtEAcqCost.Text, Decimal)
                .Item_ID = itemid
                .Property_code = objDerived.GetValue("EXEC [AMS].[GetMachineryGACodes] ", CommandType.Text)
                'objDerived.GetValue("select ga_code  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%' ", CommandType.Text)
                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .Function_ID = 86
                .TD_ID = 1
                .Project_ID = 0
                .Program_id = 0
                .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & itemid & "' ", CommandType.Text)
            End With
            Dim PropHdr_ID As Integer = 0
            PropHdr_ID = Prop_Hdr.save()

            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

            For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                'msgbox(CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text)


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
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                    .Barcode = " "
                    .Amount = CType(txtEAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    .type = "Machinery"
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .Function_ID = 86
                    .AccountablePerson = ""
                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = Prop_Dtl.save()

                objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtEMarketValue.Text.Replace(",", ""), Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)



                '==saving Machine
                With objMachineInfo
                    .MachineryInfoId = 0
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = PropDtl_ID
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                    .BrandModel = txtMachineryModel.Text
                    .MachineDesc = txtMachineryDescription.Text
                    .MachineLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text
                    .NoPassengers = ""
                    .ServiceFloors = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text
                    .MachineUnitNo = ""
                    .WorkingLoad = ""
                    .RatedSpeed = ""
                    .CarDimensions = txtMachineryDimension.Text
                    .DepreciationRate = lblequipmentdepreciatedRate.Text
                    .DepreciationValue = txtequipmentdepreciatedvalue.Text
                    .MechinePermitNo = ""
                    .DateOperate = "1/1/1900"
                    .DateIssued = "1/1/1900"
                    .DateInspected = txtEAcqDate.Text
                    .InspectedBy = ""
                    .Remarks = ""
                    .AreaCapacity = txtMachineryAreaCapacity.Text
                    .Warranty = txtMachineryWarranty.Text
                    .SalvageValue = txtSalvageValue.Text.Replace(",", "")
                    .Item_ID = itemid

                End With
                Dim mac_info_id As Integer
                mac_info_id = objMachineInfo.save()

                objDerived.GetRecords("UPDATE AMS.TbMachinery_Information SET Received_ID = 0, Received_Dtl_ID = 0 WHERE MachineryInfoId = '" & mac_info_id & "'", CommandType.Text)

                With objMachineDtl
                    .MachineryId = 0
                    .MachineryInfoId = mac_info_id
                    .Property_Dtl_ID = PropDtl_ID
                    .MarketValue = txtEMarketValue.Text.Replace(",", "")
                    .Condition = ""
                    .Location = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text
                    .Status = "Accepted"
                    .MachineName = txtMachineryName.Text
                    .PowerInput = txtMachineryPowerInput.Text
                    Dim drp As DropDownList
                    drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtMac"), DropDownList)
                    'here
                    If drp.SelectedItem.Text = "N/A" Then
                        .buildingid = 0
                    ElseIf drp.SelectedItem.Text = "Field" Then
                        .buildingid = 0
                    Else
                        .buildingid = drp.SelectedValue
                    End If

                    .MaintenanceContractor = txtContractor.Text
                    .MaintenanceContactPerson = txtContactPerson.Text
                    .MaintenanceContactNo = txtCellphoneNo.Text
                    .NoYears = txtNoYears.Text
                    .UsefulLife = txtUsefulLife.Text

                End With
                objMachineDtl.save()

            Next
            '==== SAVE PROPERTY LEDGER
            With Prop_Ledger
                .Ledger_ID = 0
                .PropertyNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                .SerialNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                .Trans_Type = "Manual Entry"
                .dDate = txtEAcqDate.Text
                .Ref = ""
                .AccountablePerson = ""
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = itemid
                .DebitQty = txtMachineryQuantity.Text
                .DebitCost = txtMachineryQuantity.Text * CType(txtEAcqCost.Text, Decimal) 'CType(txtEAcqCost.Text, Decimal)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & itemid & "'", CommandType.Text)
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & itemid & "'", CommandType.Text)

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

                .BalanceQty = Eqty + txtMachineryQuantity.Text
                .BalanceCost = CType(txtEAcqCost.Text, Decimal) + CType(Eqbalance, Decimal)

            End With
            Prop_Ledger.save()


            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            idholder = itemid
            loadEquipmentLedger()
            'End If
            btnSave.Enabled = False
            btnCancel.Enabled = False


        End If

        'End If
    End Sub



    Protected Sub BindGrid()
        If ViewState("Customers") IsNot Nothing Then
            grdPropertyInfo.DataSource = DirectCast(ViewState("Customers"), DataTable)
            grdPropertyInfo.DataBind()
        End If
    End Sub

    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drpInstalledAtMac As DropDownList = CType(e.Row.FindControl("drpInstalledAtMac"), DropDownList)
            Dim txtPIFloorLocation As TextBox = CType(e.Row.FindControl("txtPIFloorLocation"), TextBox)
            Dim txtPropertyNo As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
            Dim txtSerialNumber As TextBox = CType(e.Row.FindControl("txtSerialNumber"), TextBox)

            ' Load the dropdown with building names
            Dim query As String = "SELECT a.BuildingId, a.BuildingName + ' - ' + ISNULL(a.Address, '') AS Name " &
                              "FROM ams.TbBuilding_Dtl AS a " &
                              "INNER JOIN ams.Property_Dtl AS b ON a.Property_Dtl_ID = b.PropertyDetai_ID " &
                              "ORDER BY a.BuildingName"

            drpInstalledAtMac.DataSource = objDerived.GetDataTable(query, CommandType.Text)
            drpInstalledAtMac.DataTextField = "Name"
            drpInstalledAtMac.DataValueField = "BuildingId"
            drpInstalledAtMac.DataBind()

            ' Restore previously selected value if available
            Dim dt As DataTable = DirectCast(ViewState("Customers"), DataTable)
            If dt IsNot Nothing AndAlso e.Row.RowIndex < dt.Rows.Count Then
                drpInstalledAtMac.SelectedValue = dt.Rows(e.Row.RowIndex)("InstalledAt").ToString()
                txtPIFloorLocation.Text = dt.Rows(e.Row.RowIndex)("FloorLocation").ToString()
                txtPropertyNo.Text = dt.Rows(e.Row.RowIndex)("PropertyNo").ToString()
                txtSerialNumber.Text = dt.Rows(e.Row.RowIndex)("SerialNo").ToString()
            End If
        End If
    End Sub



    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)
        If txtMachineryQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
        Else
            Dim dt As DataTable
            ' Check if there is already data in ViewState
            If ViewState("Customers") IsNot Nothing Then
                dt = DirectCast(ViewState("Customers"), DataTable)
            Else
                dt = New DataTable()
                dt.Columns.Add("PropertyNo", GetType(String))
                dt.Columns.Add("SerialNo", GetType(String))
                dt.Columns.Add("InstalledAt", GetType(String))
                dt.Columns.Add("FloorLocation", GetType(String))
            End If

            ' Add new empty rows if necessary
            While dt.Rows.Count < Convert.ToInt32(txtMachineryQuantity.Text)
                dt.Rows.Add("", "", "", "")
            End While

            ' Save back to ViewState
            ViewState("Customers") = dt
            BindGrid()

            ' Show the modal
            ModalPopupExtender2.Show()
        End If
    End Sub






    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        Dim dt As DataTable
        If ViewState("Customers") IsNot Nothing Then
            dt = DirectCast(ViewState("Customers"), DataTable)
        Else
            Exit Sub
        End If

        ' Loop through GridView rows and save the data
        For Each row As GridViewRow In grdPropertyInfo.Rows
            Dim txtPropertyNo As TextBox = CType(row.FindControl("txtPropertyNo"), TextBox)
            Dim txtSerialNumber As TextBox = CType(row.FindControl("txtSerialNumber"), TextBox)
            Dim drpInstalledAtMac As DropDownList = CType(row.FindControl("drpInstalledAtMac"), DropDownList)
            Dim txtPIFloorLocation As TextBox = CType(row.FindControl("txtPIFloorLocation"), TextBox)


            ' Update DataTable with new values
            dt.Rows(row.RowIndex)("PropertyNo") = txtPropertyNo.Text
            dt.Rows(row.RowIndex)("SerialNo") = txtSerialNumber.Text
            dt.Rows(row.RowIndex)("InstalledAt") = drpInstalledAtMac.SelectedValue
            dt.Rows(row.RowIndex)("FloorLocation") = txtPIFloorLocation.Text
        Next

        ' Save back to ViewState
        ViewState("Customers") = dt

        ' Close the modal
        ModalPopupExtender2.Hide()
    End Sub





    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)


        'OPTIMIZE CODE
        Dim textBoxes() As TextBox = {txtMachineryName, txtMachineryDescription, txtMachineryPowerInput, txtMachineryModel, txtMachineryQuantity, txtMachineryDimension, txtMachineryAreaCapacity, txtMachineryWarranty, txtContractor, txtContactPerson, txtCellphoneNo, txtEAcqDate, txtEMarketValue, txtEAcqCost, txtNoYears, txtUsefulLife, txtSalvageValue}

        For Each textBox As TextBox In textBoxes
            textBox.Text = ""
        Next

        LoadBuildings()
        loadUnit()
    End Sub

    Protected Sub drpInstalledAtBuilding_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpInstalledAtBuilding.SelectedIndexChanged

    End Sub

    Protected Sub grdPropertyInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPropertyInfo.SelectedIndexChanged

    End Sub
    Protected Sub drpInstalledAtMac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim drp As DropDownList
        Dim text As TextBox
        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtMac"), DropDownList)
            If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = True
                text.Text = ""
            Else
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = False

                Dim drp1 As DropDownList
                drp1 = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtMac"), DropDownList)

                'Optimize code

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT CONCAT_WS(', ', " &
                                 " COALESCE(Address, ''), " &
                                 " COALESCE(Barangay, ''), " &
                                 " COALESCE(Area1, '')) AS Address " &
                                 " From AMS.TbBuilding_Dtl " &
                                 " WHERE BuildingId=" & drp1.SelectedValue & "", CommandType.Text)

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

        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPropertyNo"), TextBox)
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT a.Item_ID, b.PropertyNo FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID WHERE  (b.PropertyNo = '" & text.Text & "')", CommandType.Text)

            If dt.Rows.Count > 0 Then
                ShowAlert("Property No. is already exist!") ' Call the new ShowAlert function
                text.Text = "" ' Clear the input field
            End If
        Next

        ' Keep the modal popup open
        ModalPopupExtender2.Show()
    End Sub


    Private Sub ShowAlert(message As String)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('" & message.Replace("'", "\'") & "');", True)
    End Sub



End Class
