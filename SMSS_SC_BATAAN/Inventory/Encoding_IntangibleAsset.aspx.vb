Imports System.Data
Imports System.Drawing
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Threading ' <-- Added for Thread.Sleep

Partial Class Inventory_Encoding_IntangibleAsset
    Inherits System.Web.UI.Page

    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Private Prop_Ledger As New t_PropertyLedger
    Dim item As New m_item
    Dim Prop_Hdr As New t_property_hdr
    Dim Prop_Dtl As New t_property_dtl
    Dim objIntangibleDtl As New ConsolidatedPropertySaving.TBIntangibleAsset_Dtl
    Dim objIntangibleInfo As New ConsolidatedPropertySaving.TBIntangibleAsset_Info

    Private Sub Inventory_Encoding_IntangibleAsset_Load(sender As Object, e As EventArgs) Handles Me.Load
        'objx.GetAccessRight(Me.Session("@UserName"), Page)
        'If objx.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If
        If Not Page.IsPostBack Then
            loadwarehouse()
            loadSubClassification()
            loadEquipmentLedger()
        Else
            loadEquipmentLedger()
        End If
        ''loadEquipmentLedger()
    End Sub

    Public Sub loadEquipmentLedger()
        Dim dtAccount As New DataTable
        Dim query As String = ""  ' Initialize to empty just in case

        If String.IsNullOrEmpty(hdnItemNo.Value) Then
            ' Return ALL rows with ALIASES for your columns
            query = "SELECT " & vbCrLf &
                "    Ledger_ID, " & vbCrLf &
                "    PropertyNo, " & vbCrLf &
                "    SerialNo, " & vbCrLf &
                "    Item_ID, " & vbCrLf &
                "    dDate, " & vbCrLf &
                "    Trans_Type, " & vbCrLf &
                "    Ref, " & vbCrLf &
                "    AccountablePerson, " & vbCrLf &
                "    Department, " & vbCrLf &
                "    Position, " & vbCrLf &
                "    AcceptedBy, " & vbCrLf &
                "    InspectedBy, " & vbCrLf &
                "    DebitQty, " & vbCrLf &
                "    DebitUnit, " & vbCrLf &
                "    DebitCost, " & vbCrLf &
                "    CreditQty, " & vbCrLf &
                "    CreditUnit, " & vbCrLf &
                "    CreditCost, " & vbCrLf &
                "    BalanceQty AS BalQty, " & vbCrLf &
                "    BalanceUnit, " & vbCrLf &
                "    BalanceCost AS BalCost " & vbCrLf &
                "FROM AMS.TbProperty_Ledger " & vbCrLf &
                "ORDER BY Ledger_ID DESC"
        Else
            ' Return ONLY rows for that item, with ALIASES
            query = "SELECT " & vbCrLf &
                "    Ledger_ID, " & vbCrLf &
                "    PropertyNo, " & vbCrLf &
                "    SerialNo, " & vbCrLf &
                "    Item_ID, " & vbCrLf &
                "    dDate, " & vbCrLf &
                "    Trans_Type, " & vbCrLf &
                "    Ref, " & vbCrLf &
                "    AccountablePerson, " & vbCrLf &
                "    Department, " & vbCrLf &
                "    Position, " & vbCrLf &
                "    AcceptedBy, " & vbCrLf &
                "    InspectedBy, " & vbCrLf &
                "    DebitQty, " & vbCrLf &
                "    DebitUnit, " & vbCrLf &
                "    DebitCost, " & vbCrLf &
                "    CreditQty, " & vbCrLf &
                "    CreditUnit, " & vbCrLf &
                "    CreditCost, " & vbCrLf &
                "    BalanceQty AS BalQty, " & vbCrLf &
                "    BalanceUnit, " & vbCrLf &
                "    BalanceCost AS BalCost " & vbCrLf &
                "FROM AMS.TbProperty_Ledger " & vbCrLf &
                "WHERE Item_ID = " & hdnItemNo.Value & vbCrLf &
                "ORDER BY Ledger_ID DESC"
        End If

        ' Now pass the properly built query
        dtAccount = objDerived.GetDataTable(query, CommandType.Text)

        ' Ensure at least 10 rows
        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        ' Clear old data, then bind
        grdLedger1.DataSource = Nothing
        grdLedger1.DataBind()
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
        'Optimize code
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
        dt.Columns.Add("BalanceUnit", GetType(String))
        dt.Columns.Add("BalCost", GetType(Decimal))

        For i As Integer = 0 To row
            dt.Rows.Add(dt.NewRow())
        Next

        Return dt
    End Function

    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        ' --- ADDITION #2: Check if HeaderRow is Nothing to avoid errors
        If grdLedger1.HeaderRow Is Nothing Then
            ' If the grid is empty or no header is generated, just exit
            Return
        End If

        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "Intangible Asset"
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

    Public Sub loadSubClassification()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("Select SubClassificationID, SubclassificationName from dbo.tbl_SubClassification where ClassificationID = '13'", CommandType.Text)
        drpSubClassification.DataSource = dt
        drpSubClassification.DataTextField = "SubClassificationName"
        drpSubClassification.DataValueField = "SubClassificationID"
        drpSubClassification.Items.Clear()
        drpSubClassification.DataBind()
        drpSubClassification.Items.Insert(0, "Select")
    End Sub

    Public Sub loadwarehouse()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("select warehouse_id,wname From ams.loc_warehouse", CommandType.Text)
        drpWarehouse.DataTextField = ("wname")
        drpWarehouse.DataValueField = ("warehouse_id")
        drpWarehouse.DataSource = dt
        drpWarehouse.DataBind()
    End Sub

    Public Sub Save()
        ' Debug Start
        System.Diagnostics.Debug.WriteLine("=== START of Save() function ===")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceStart", "console.log('=== START of Save() function ===');", True)

        'If txtTitle.Text <> "" And txtBrand.Text <> "" And txtSerialNo.Text <> "" And txtNoofdisc.Text <> "" And txtModel.Text <> "" And txtLicenceDuration.Text <> "" Then
        If Not IsNumeric(txtDepreciatedRate.Text) Or Not IsNumeric(txtAcquisitionCost.Text) Or Not IsNumeric(txtDepreciatedValue.Text) Or Not IsNumeric(txtSalvageValue.Text) Or Not IsNumeric(txtMarketValue.Text) Then

            System.Diagnostics.Debug.WriteLine("Validation Failed: One or more fields are not numeric.")
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceValidation",
            "console.log('Validation Failed: One or more fields are not numeric.');", True)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: \n Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
        Else
            System.Diagnostics.Debug.WriteLine("Validation Passed: All required fields are numeric.")
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceValidationPassed",
            "console.log('Validation Passed: Numeric checks passed.');", True)

            ' -- Item Creation
            With item
                .Item_Code = ""
                .Item_Desc = txtTitle.Text
            End With

            Dim itemid As Integer = item.save()
            System.Diagnostics.Debug.WriteLine("Item Save Completed -> New Item_ID: " & itemid)
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceItemSaved",
            "console.log('Item Saved: Item_ID=" & itemid & "');", True)

            ' -- Property Header
            With Prop_Hdr
                '.Property_ID = Property_ID
                .Property_Date = txtAcquisitionDate.Text
                .Issuance = 0
                .Remarks = "Manual Encoding of Old Properties"
                .Emp_ID = 0
                .F_ID = 1
                .AIRDtl_ID = 0
                .deptid = 0
                .isDonated = False

                Dim gaIDQuery As String = "select b.GA_ID  From dbo.tbl_Classification as a " &
                                      "inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid " &
                                      "inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID " &
                                      "where a.ClassificationName  like '%Intangible%' "
                System.Diagnostics.Debug.WriteLine("GA_ID Query: " & gaIDQuery)
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceGAIDQuery",
                "console.log('GA_ID Query: " & gaIDQuery & "');", True)

                .GA_ID = objDerived.GetValue(gaIDQuery, CommandType.Text)

                .DonationRemarks = ""
                .Qty = 1
                .Balance = 1
                .Cost = CType(txtAcquisitionCost.Text, Decimal)
                .Item_ID = itemid

                Dim propCodeQuery As String = "select ga_code  From dbo.tbl_Classification as a " &
                                          "inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid " &
                                          "inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID " &
                                          "where a.ClassificationName  like '%Intangible%' "
                System.Diagnostics.Debug.WriteLine("Prop_Code Query: " & propCodeQuery)
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "tracePropCodeQuery",
                "console.log('Prop_Code Query: " & propCodeQuery & "');", True)

                .Property_code = objDerived.GetValue(propCodeQuery, CommandType.Text)

                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .Function_ID = 86
                .TD_ID = 1
                .Project_ID = 0
                .Program_id = 0

                Dim partQuery As String = "SELECT AMS.item_particular.description " &
                                      "FROM dbo.m_item INNER JOIN AMS.item_particular ON " &
                                      "dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id " &
                                      "where Item_ID = '" & itemid & "' "
                System.Diagnostics.Debug.WriteLine("Particular Query: " & partQuery)
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceParticularQuery",
                "console.log('Particular Query: " & partQuery & "');", True)

                .Particular = objDerived.GetValue(partQuery, CommandType.Text)
            End With

            Dim PropHdr_ID As Integer = Prop_Hdr.save()
            System.Diagnostics.Debug.WriteLine("Property Header Saved -> PropHdr_ID: " & PropHdr_ID)
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "tracePropHdrSaved",
            "console.log('Property Header Saved: PropHdr_ID=" & PropHdr_ID & "');", True)

            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

            ' -- Property Detail
            With Prop_Dtl
                .PropertyNo = txtSerialNo.Text
                .Property_ID = PropHdr_ID
                .Issued = False
                .Repair = False
                .Dispose = False
                .DisposeDate = "1/1/1900"
                .IsInspectionForDisposal = False
                .InspectionDate = txtAcquisitionDate.Text
                .F_ID = 1
                .SerialNo = " "
                .Barcode = " "
                .Amount = CType(txtAcquisitionCost.Text, Decimal)
                .Status = "Accepted"
                .type = "Machinery"
                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .Function_ID = 86
                .AccountablePerson = ""
            End With

            Dim PropDtl_ID As Integer = Prop_Dtl.save()
            System.Diagnostics.Debug.WriteLine("Property Dtl Saved -> PropDtl_ID: " & PropDtl_ID)
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "tracePropDtlSaved",
            "console.log('Property Detail Saved: PropDtl_ID=" & PropDtl_ID & "');", True)

            objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtMarketValue.Text.Replace(",", ""), Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)
            System.Diagnostics.Debug.WriteLine("Updated AMS.Property_Dtl with MarketValue: " & txtMarketValue.Text)
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "tracePropDtlMarketValue",
            "console.log('Updated AMS.Property_Dtl with MarketValue=" & txtMarketValue.Text & "');", True)

            ' -- Intangible Info
            With objIntangibleInfo
                .AIRDtl_ID = 0
                .IsAccepted = True
                .Property_Dtl_ID = PropDtl_ID
                .Received_ID = 0
                .Received_Dtl_ID = 0
                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .Brand = txtBrand.Text
                .Title = txtTitle.Text
                .SerialNo = txtSerialNo.Text
                .Noofdisc = txtNoofdisc.Text
                .Model = txtModel.Text
                .LicenceDuration = txtLicenceDuration.Text
                .DepreciationRate = txtDepreciatedRate.Text
                .NoofYears = txtNoofYears.Text
                .Usefullife = txtUsefullife.Text
                .SubClassificationID = drpSubClassification.SelectedValue
            End With

            Dim Intan_info_id As Integer = objIntangibleInfo.save()
            System.Diagnostics.Debug.WriteLine("TBIntangibleAsset_Info Saved -> Intan_info_id: " & Intan_info_id)
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceIntangibleInfoSaved",
            "console.log('Intangible Info Saved: Intan_info_id=" & Intan_info_id & "');", True)

            objDerived.GetRecords("UPDATE AMS.TBIntangibleAsset_Info SET Received_ID = 0, Received_Dtl_ID = 0 WHERE IntangibleAssetInfoId = '" & Intan_info_id & "'", CommandType.Text)

            ' -- Intangible Detail
            With objIntangibleDtl
                .IntangibleAssetInfoId = Intan_info_id
                .Property_Dtl_ID = PropDtl_ID
                .AcqCost = txtAcquisitionCost.Text.Replace(",", "")
                .DepreciatedValue = txtDepreciatedValue.Text.Replace(",", "")
                .MarketValue = txtMarketValue.Text.Replace(",", "")
                .SalvageValue = txtSalvageValue.Text.Replace(",", "")
                .WarehouseID = drpWarehouse.SelectedValue
                .Bay = txtBay.Text
                .Column = txtColumn.Text
                .Floor = txtFloor.Text
                .Room = txtRoom.Text
                .Shelves = txtShelves.Text
                .Rack = txtRack.Text
                .Bin = txtBin.Text
                .Status = "Accepted"
            End With

            Dim Intan_dtl_id As Integer = objIntangibleDtl.save()
            System.Diagnostics.Debug.WriteLine("TBIntangibleAsset_Dtl Saved -> Intan_dtl_id: " & Intan_dtl_id)
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceIntangibleDtlSaved",
            "console.log('Intangible Dtl Saved: Intan_dtl_id=" & Intan_dtl_id & "');", True)

            ' -- Ledger
            With Prop_Ledger
                .Ledger_ID = 0
                .PropertyNo = ""
                .SerialNo = txtSerialNo.Text
                .Trans_Type = "Manual Entry"
                .dDate = txtAcquisitionDate.Text
                .Ref = ""
                .AccountablePerson = ""
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = itemid
                .DebitQty = 1
                .DebitCost = CType(txtAcquisitionCost.Text, Decimal) 'CType(txtEAcqCost.Text, Decimal)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & itemid & "'", CommandType.Text)
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & itemid & "'", CommandType.Text)

                Dim Eqty As Integer
                Dim Eqbalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
                System.Diagnostics.Debug.WriteLine("Existing AMS.TbProperty_Ledger rows: " & dtledger.Rows.Count)
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceExistingLedgerCount",
                "console.log('Existing TbProperty_Ledger rows for item " & itemid & ": " & dtledger.Rows.Count & "');", True)

                If dtledger.Rows.Count = 0 Then
                    Eqty = 0
                    Eqbalance = 0.0
                Else
                    Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
                    Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
                End If

                .BalanceQty = 1
                .BalanceCost = CType(txtAcquisitionCost.Text, Decimal) + CType(Eqbalance, Decimal)

                System.Diagnostics.Debug.WriteLine("Prop_Ledger -> DebitQty=1, DebitCost=" & .DebitCost & "  |  PrevBalance=" & Eqbalance & " => NewBalanceCost=" & .BalanceCost)
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceLedgerComputed",
                "console.log('Prop_Ledger -> DebitQty=1, DebitCost=" & .DebitCost & ", PrevBalance=" & Eqbalance & ", NewBalanceCost=" & .BalanceCost & "');", True)
            End With

            Prop_Ledger.save()
            System.Diagnostics.Debug.WriteLine("Property Ledger Saved for Item_ID=" & itemid)
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceLedgerSaved",
            "console.log('Property Ledger Saved: Item_ID=" & itemid & "');", True)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            System.Diagnostics.Debug.WriteLine("Transaction has been successfully saved.")
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceTransactionSaved",
            "console.log('Transaction has been successfully saved.');", True)

            ' (Optional) small delay if needed
            Thread.Sleep(1000)

            hdnItemNo.Value = itemid
        End If

        loadEquipmentLedger()
        ' Debug End
        System.Diagnostics.Debug.WriteLine("=== END of Save() function ===")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "traceEnd", "console.log('=== END of Save() function ===');", True)
        'Else
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill Up the Required Fields : \n Title, Brand, Serial No., No. of Disc, Model, License Duration ")
        'End If
    End Sub


    Protected Sub grdLedger1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        ' 1) Set the new page index
        grdLedger1.PageIndex = e.NewPageIndex

        ' 2) Re-bind the grid data
        loadEquipmentLedger()
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "SAVE" Then
            Save()
        End If
    End Sub
End Class
