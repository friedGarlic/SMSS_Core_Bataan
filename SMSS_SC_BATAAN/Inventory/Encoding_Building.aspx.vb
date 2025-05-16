
Imports System.Data
Imports System.Drawing

Partial Class Inventory_Encoding_Building
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Dim item As New m_item
    Dim objBldgInfo As New ConsolidatedPropertySaving.TBBuilding_Details
    Private Prop_Ledger As New t_PropertyLedger


    Private Sub Inventory_Encoding_Building_Load(sender As Object, e As EventArgs) Handles Me.Load
        objx.GetAccessRight(Me.Session("@UserName"), Page)
        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then

        End If
        loadEquipmentLedger()
    End Sub
    Public Sub loadEquipmentLedger()
        ' btnEquipmentLedger.CssClass = "Clicked"
        'btnequipmentrepairs.CssClass = "Initial"
        ' btnequipmentattachdoc.CssClass = "Initial"
        ' Me.mvledger.SetActiveView(Me.vwledger)

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
        'dt.Columns.Add("SerialNo", GetType(String))
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
        '    dr("SerialNo") = DBNull.Value
        '    dr("BalCost") = DBNull.Value
        '    dt.Rows.Add(dr)
        'Next
        'Return dt


        ''Optimize code
        Dim dt As New DataTable()
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
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("BalCost", GetType(Decimal))

        For i As Integer = 0 To row
            dt.Rows.Add(dt.NewRow())
        Next

        Return dt
    End Function


    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        'Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        'Dim cell As New TableHeaderCell()
        'cell.Text = "BUILDING"
        'cell.ColumnSpan = 3
        'cell.BorderWidth = 2
        'cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        'row.Controls.Add(cell)

        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 1
        'cell.Text = "DEBIT"
        'cell.BorderWidth = 2
        'cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        'row.Controls.Add(cell)


        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 1
        'cell.Text = "CREDIT"
        'cell.BorderWidth = 2
        'cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        'row.Controls.Add(cell)


        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 1
        'cell.Text = "BALANCE"
        'cell.BorderWidth = 2
        'cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        'row.Controls.Add(cell)

        'row.BackColor = ColorTranslator.FromHtml("WHITE")
        'row.ForeColor = ColorTranslator.FromHtml("#12306b")

        'grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)
        ''Optime code
        Dim headers() As String = {"BUILDING", "", "", "DEBIT", "CREDIT", "BALANCE"}

        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)

        For Each header As String In headers
            Dim cell As New TableHeaderCell()
            cell.ColumnSpan = 1
            cell.Text = header
            cell.BorderWidth = 2
            cell.BorderColor = ColorTranslator.FromHtml("#12306b")
            row.Controls.Add(cell)
        Next

        row.BackColor = ColorTranslator.FromHtml("WHITE")
        row.ForeColor = ColorTranslator.FromHtml("#12306b")

        grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)


        If txtBuildingName.text = "" Or txtAddress.text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Address")

        Else

            'If Not IsNumeric(lblequipmentdepreciatedRate.text) Or Not IsNumeric(txtEAcqCost.text) Or Not IsNumeric(txtequipmentdepreciatedvalue.text) Or Not IsNumeric(txtSalvageValue.text) Or Not IsNumeric(txtEMarketValue.text) Then
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
            'Else
            Dim itemdesc As String = objDerived.GetValue("select * From dbo.m_item where Item_Desc = '" & txtBuildingName.Text & "'", CommandType.Text)
                If itemdesc <> "" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Building Already Exists")
                    itemdesc = ""
                    Exit Sub
                End If
                Dim acqcost As Decimal
                acqcost = txtEAcqCost.text

                With item
                    .Item_Code = ""
                    .Item_Desc = txtBuildingName.text
                    .Unit_ID = objDerived.getvalue("select * From ams.m_Unit where Description like '%Square Meter%'", commandtype.text)
                End With
                'item.save()

                Dim itemid As Integer
                itemid = item.save()
                objDerived.execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & acqcost & "',null", commandtype.text)



                Dim classification As String = objDerived.Execute("exec [AMS].[GetBuildingClassificationIds] ", CommandType.Text)

                'objDerived.getvalue("select  a.ClassificationId From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Building%'", commandtype.text)
                'Dim category As Integer = objDerived.Execute("exec [AMS].[GetItemParticularID] '" & itemid & "'", CommandType.Text)
                Dim category As Integer = objDerived.GetValue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & itemid, CommandType.Text)

                'Dim gaid As Integer = objDerived.Execute("exec [AMS].[get_building_ga_ids]", CommandType.Text)
                Dim gaid As Integer = objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Building%' ", CommandType.Text)

                Dim matrix As String = objDerived.GetValue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & gaid & " and item_id = " & itemid & "", CommandType.Text)

                If matrix = "" Then
                    objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id) values('" & classification & "','" & gaid & "','" & itemid & "','" & category & "','0')", commandtype.text)
                End If



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
                    .GA_ID = objDerived.getvalue("select distinct a.GA_ID  From ams.View_AccountList as a inner join dbo.tblclassmatrix as c on a.GA_ID = c.ga_id and a.BGA_ID = c.BGA_ID inner join dbo.tbl_Classification as b on c.classificationid = b.ClassificationId  where b.ClassificationName  like '%Building%'", commandtype.text)
                    .DonationRemarks = ""
                    .Qty = 1
                    .Balance = 1
                    .Cost = CType(acqcost, Decimal)
                    .Item_ID = itemid
                    .Property_code = objDerived.getvalue("select distinct a.GA_Code  From ams.View_AccountList as a inner join dbo.tblclassmatrix as c on a.GA_ID = c.ga_id and a.BGA_ID = c.BGA_ID inner join dbo.tbl_Classification as b on c.classificationid = b.ClassificationId  where b.ClassificationName  like '%Building%' ", commandtype.text)
                    .RC_ID = 0
                    .Function_ID = 0
                    .TD_ID = 1
                    .Project_ID = 0
                    .Program_id = 0
                    .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & itemid & "' ", CommandType.Text)
                End With
                Dim PropHdr_ID As Integer = 0
                PropHdr_ID = Prop_Hdr.save()


                objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)


                Dim Prop_Dtl As New t_property_dtl
                With Prop_Dtl
                    .PropertyNo = txtPropertyNo.Text
                    .Property_ID = PropHdr_ID
                    .Issued = False
                    .Repair = False
                    .Dispose = False
                    .DisposeDate = "1/1/1900"
                    .IsInspectionForDisposal = False
                    .InspectionDate = txtEAcqDate.Text
                    .F_ID = 1
                    .SerialNo = " "
                    .Barcode = " "
                    .Amount = CType(acqcost, Decimal)
                    .Status = "Accepted"
                    .type = "Building"
                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = Prop_Dtl.save()

                objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtEMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

                '==== SAVE Building DETAILS
                With objBldgInfo
                    .BuildingId = 0
                    .Property_Dtl_ID = PropDtl_ID
                    .BuildingControlNo = txtBuildingControlNo.text
                    .BuildingCode = txtBuildingCode.text
                    .BuildingName = txtBuildingName.Text
                    .Address = txtAddress.Text
                    .PostalCode = txtPostalCode.Text
                    .BuildingDepreciationRate = lblequipmentdepreciatedRate.Text
                    .BuildingUse = txtBuildingUse.text
                    .BuildingOccupancy = txtBuildingOccupancy.text
                    .NumberFloors = txtNoofFloors.text
                    .AvgAreaFloor = txtAvgAreaperFloor.text
                    .CostPerArea = txtCostperArea.text
                    .Status_AIR = "Accepted"
                    .Barangay = txtBrgy.text
                    .Area = txtArea.text
                    .TaxDeclarationNo = txtTaxDecNo.text
                    .NoofYears = txtNoYears.text
                    .UsefulLife = txtUsefulLife.text
                    .SalvageValue = txtSalvageValue.Text
                    '.DateTaken = ""
                    '.UploadedBy = ""
                    .MarketValue = txtEMarketValue.Text
                    .BuildingDepreciationValue = txtequipmentdepreciatedvalue.Text.Replace(",", "")
                End With

                Dim LandDtl_ID As Integer
                LandDtl_ID = objBldgInfo.save()

                objDerived.GetRecords("INSERT INTO AMS.TbBuilding_OwnerInformation (buldingid,CorporationName) VALUES ('" & LandDtl_ID & "','" & txtPrevOwner.Text & "')", CommandType.Text)

                Dim GaCode As String
                'GaCode = objDerived.GetValue("exec [AMS].[GetDistinctGACodesForBuilding]", CommandType.Text)
                GaCode = objDerived.GetValue("select distinct a.GA_Code  From ams.View_AccountList as a inner join dbo.tblclassmatrix as c on a.GA_ID = c.ga_id and a.BGA_ID = c.BGA_ID inner join dbo.tbl_Classification as b on c.classificationid = b.ClassificationId  where b.ClassificationName  like '%Building%'  ", CommandType.Text)

                '==== SAVE PROPERTY LEDGER
                With Prop_Ledger
                    .Ledger_ID = 0
                    objDerived.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & txtEAcqDate.Text & "', '" & GaCode & "', '" & itemid & "')", CommandType.Text)
                    .SerialNo = txtBuildingCode.Text
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
                    .DebitCost = CType(acqcost, Decimal)
                    .DebitUnit = objDerived.getvalue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", commandtype.text)
                    .CreditQty = "0"
                    .CreditUnit = "-"
                    .CreditCost = "0.00"
                    .BalanceUnit = objDerived.getvalue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", commandtype.text)

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
                    .BalanceCost = CType(acqcost, Decimal) + CType(Eqbalance, Decimal)

                End With
                Prop_Ledger.save()

                btnSave.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                hdnItemNo.value = itemid
                loadEquipmentLedger()
            End If

        'End If

    End Sub

End Class
