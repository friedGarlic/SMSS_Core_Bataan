
Imports System.Data
Imports System.Drawing

Partial Class Inventory_Encoding_RoadsBridges
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim idholder As String = ""
    Protected Sub OnDataBound(sender As Object, e As EventArgs)

        ''Optimize code using chat gpt

        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        row.BackColor = Color.White
        row.ForeColor = Color.Black

        Dim cell As TableHeaderCell

        cell = New TableHeaderCell()
        cell.Text = "ROADS AND BRIDGES CONSTRUCTION"
        cell.ColumnSpan = 3
        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "DEBIT"
        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "CREDIT"
        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "BALANCE"
        row.Cells.Add(cell)

        grdLedger1.Controls(0).Controls.AddAt(0, row)
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


    Private Sub Inventory_Encoding_RoadsBridges_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim classificationid As Integer = objDerived.getValue("Select classificationid From tbl_classification where classificationname like '%Roads and Bridges%'", commandtype.text)
            Dim PListofGL As New DataTable
            PListofGL = objDerived.GetDataTable("select distinct c.SubClassificationID,c.SubClassificationName " &
                                                "	From tbl_SubClassification as c" &
                                                "        Left outer join tblclassmatrix as b on b.SubClassificationID = c.SubClassificationID" &
                                                "        inner join  tbl_Classification as a on a.ClassificationId = b.classificationid " &
                                                "        where b.classificationid ='" & classificationid & "' order by c.SubClassificationName ", CommandType.Text)

            Me.drpSubClass.items.add("Select")
            Me.drpSubClass.DataSource = CType(PListofGL, DataTable)
            Me.drpSubClass.DataTextField = ("SubClassificationName")
            Me.drpSubClass.DataValueField = ("SubClassificationID")
            Me.drpSubClass.DataBind()
            Me.drpSubClass.enabled = True
            selectSubClass()


            If Session("SavedItemID") IsNot Nothing Then
                idholder = Session("SavedItemID").ToString()
            End If
            loadEquipmentLedger()



        End If
        loadEquipmentLedger()

    End Sub

    Public Sub loadEquipmentLedger()
        ' Highlight the Transactions tab
        btnEquipmentLedger.CssClass = "Clicked"
        btnequipmentrepairs.CssClass = "Initial"
        btnequipmentattachdoc.CssClass = "Initial"
        Me.mvledger.SetActiveView(Me.vwledger)

        Dim dtAccount As New DataTable
        Dim subclassID As Integer

        ' Determine subclass based on dropdown selection
        If drpSubClass.SelectedItem.Text.Contains("Roads") Then
            subclassID = 1075
        ElseIf drpSubClass.SelectedItem.Text.Contains("Bridges") Then
            subclassID = 1074
        Else
            subclassID = 0 ' Default (show all)
        End If

        ' Build SQL query with JOIN to tblclassmatrix
        Dim query As String = "SELECT L.Ledger_ID, " &
                          "L.Ref, L.SerialNo, L.Item_ID, L.dDate, L.Trans_Type, " &
                          "L.AccountablePerson, L.Department, L.Position, L.AcceptedBy, L.InspectedBy, " &
                          "L.DebitQty, L.DebitUnit, L.DebitCost, L.CreditQty, L.CreditUnit, L.CreditCost, " &
                          "L.BalanceQty, L.BalanceUnit, L.BalanceCost AS BalCost " &
                          "FROM AMS.TbProperty_Ledger L " &
                          "INNER JOIN dbo.tblclassmatrix C ON L.Item_ID = C.item_id " &
                          "WHERE C.SubClassificationID = " & subclassID & " " &
                          "ORDER BY L.Ledger_ID DESC"

        ' Execute the query only if a valid subclass is selected
        If subclassID <> 0 Then
            dtAccount = objDerived.GetDataTable(query, CommandType.Text)
        Else
            ' If no subclass is selected, load all data
            dtAccount = objDerived.GetDataTable("SELECT L.Ledger_ID, " &
                                        "L.Ref, L.SerialNo, L.Item_ID, L.dDate, L.Trans_Type, " &
                                        "L.AccountablePerson, L.Department, L.Position, L.AcceptedBy, L.InspectedBy, " &
                                        "L.DebitQty, L.DebitUnit, L.DebitCost, L.CreditQty, L.CreditUnit, L.CreditCost, " &
                                        "L.BalanceQty, L.BalanceUnit, L.BalanceCost AS BalCost " &
                                        "FROM AMS.TbProperty_Ledger L " &
                                        "ORDER BY L.Ledger_ID DESC", CommandType.Text)
        End If

        ' Ensure at least 10 rows in the UI
        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        ' Bind the data
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


    Public Sub selectSubClass()
        ' Update active view based on selection
        If drpSubClass.SelectedItem.Text.Contains("Roads") Then
            mvSubClass.ActiveViewIndex = 0
        ElseIf drpSubClass.SelectedItem.Text.Contains("Bridges") Then
            mvSubClass.SetActiveView(Me.vwBridge)
        End If

        ' Refresh the grid after selection change
        loadEquipmentLedger()
    End Sub


    Protected Sub drpSubClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectSubClass()
    End Sub



    Dim item As New m_item
    Dim item_detail As New m_item_detail


    Private Prop_Hdr As New t_property_hdr
    Private Prop_Dtl As New t_property_dtl
    Private Prop_Ledger As New t_PropertyLedger


    Private objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info
    Private objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details

    Protected Sub btnRoadSave_Click(sender As Object, e As EventArgs)
        With item
            .Item_Code = ""
            .Item_Desc = txtRoadName.text
            .Unit_ID = objDerived.getvalue("select * From ams.m_Unit where Description like '%Square Meter%'", commandtype.text)
        End With

        Dim itemid As Integer
        itemid = item.save()
        objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & txtRoadAcqCost.Text.Replace(",", "") & "',null", CommandType.Text)

        Dim classification As String = objDerived.getvalue("select  a.ClassificationId From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%'", commandtype.text)
        Dim category As Integer = objDerived.getvalue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & itemid, commandtype.text)
        Dim gaid As Integer = objDerived.getvalue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
        Dim matrix As String = objDerived.getvalue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & gaid & " and item_id = " & itemid & "", commandtype.text)

        If matrix = "" Then
            objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id,SubClassificationID) values('" & classification & "','" & gaid & "','" & itemid & "','" & category & "','0','" & drpSubClass.SelectedItem.Value & "')", commandtype.text)
        End If

        With Prop_Hdr
            '.Property_ID = Property_ID
            .Property_Date = txtRoadAcqDate.Text
            .Issuance = 0
            .Remarks = "Manual Encoding of Land Properties"
            .Emp_ID = 0
            .F_ID = 1
            .AIRDtl_ID = 0
            .deptid = 0
            .isDonated = False
            .GA_ID = objDerived.getvalue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
            .DonationRemarks = ""
            .Qty = 1
            .Balance = 1
            .Cost = txtRoadAcqCost.Text.Replace(",", "")
            .Item_ID = itemid
            .Property_code = objDerived.getvalue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
            .RC_ID = 0
            .Function_ID = 0
            .TD_ID = 1
            .Project_ID = 0
            .Program_id = 0
            .Particular = ""
        End With
        Dim PropHdr_ID As Integer = 0
        PropHdr_ID = Prop_Hdr.save()


        objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

        Dim gacode As String = objDerived.getvalue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
        Dim rcid As Integer = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
        Dim Function_ID As Integer = 86


        With Prop_Dtl
            '.PropertyDetai_ID = 0  
            If txtRoadID.Text = "" Then
                .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtRoadAcqDate.Text & "', '" & gacode & "','" & rcid & "','" & Function_ID & "')", CommandType.Text)
            Else
                .PropertyNo = txtRoadID.Text
            End If

            .Property_ID = PropHdr_ID
            .Issued = False
            .Repair = False
            .Dispose = False
            .DisposeDate = "1/1/1900"
            .IsInspectionForDisposal = False
            .InspectionDate = txtRoadAcqDate.Text
            .F_ID = 1
            .SerialNo = txtRoadID.Text
            .Barcode = txtRoadID.Text
            .Amount = CType(txtRoadAcqCost.Text, Decimal)
            .Status = "Accepted"
            .Details = ""
            .type = drpSubClass.SelectedItem.Text
        End With

        Dim PropDtl_ID As Integer
        PropDtl_ID = Prop_Dtl.save()

        objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & txtRoadMarketValue.Text.Replace(",", "") & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)


        Dim info_id As Integer
        With objEquipInfo
            .EquipInfoId = 0
            .AIRDtl_ID = 0
            .IsAccepted = True
            .Property_Dtl_ID = PropDtl_ID
            .SerialNo = txtRoadid.text
            .Name = txtRoadName.text
            .Description = txtRoadName.text
            .PowerInput = ""
            .Dimension = ""
            .AreaCapacity = ""
            .Model = ""
            .Warranty = ""
            .Specification = ""
            .DepreciationRate = "0"
            .DepreciationValue = "0.00"
            .SalvageValue = txtRoadSalvageValue.Text.Replace(",", "")
            .ProjectName = txtRoadProjectName.text
            .InfrastructureID = txtRoadID.text
            .InfrastructureName = txtRoadName.text
            .InfrastructureClassification = txtRoadClassification.text
            .InfrastructureType = txtRoadType.text
            .InfrastructureFromStreet = txtRoadFromStreet.text
            .InfrastructureToStreet = txtRoadtoStreet.text
            .InfrastructureSegmentLock = txtRoadSegmentLock.text
            .InfrastructureLocation = txtRoadLocation.text
            .InfrastructureLength = txtRoadLength.text
            .InfrastructureNoofLanes = txtNoofLane.text
            .InfrastructureWidth = txtRoadWidth.text
            .InfrastructureLaneLength = txtRoadLaneLength.text
            .InfrastructureLaneWidth = txtRoadLaneWidth.text
            .InfrastructureTrafficDirection = txtRoadTrafficDirection.text
            .InfrastructureTrafficVolume = txtRoadTrafficVolume.text
            .InfrastructureTrafficDate = txtTrafficDate.text
            .InfrastructureSpeedLimit = txtRoadSpeedLimit.text
            .InfrastructureElevation = txtRoadElevation.text
            .InfrastructureSurfaceType = txtRoadSurfaceType.text
            .InfrastructureSurfaceCondition = txtRoadSurfaceCondition.text
            .LeftLfromAddress = txtRoadLfromAddress.text
            .LeftLtoAddress = txtRoadLtoAddress.text
            .LeftNWshldrWidth = txtRoadNorthWestWidth.text
            .RightRfromAddress = txtRoadRfromAddress.text
            .RightRtoAddress = txtRoadRtoAddress.Text
            .RightSEshldrWidth = txtRoadSouthEastWidth.Text
            .NoYears = txtRoadNoYears.Text
            .UsefulLife = txtRoadUsefulLife.Text
        End With

        info_id = objEquipInfo.save()
        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

        With objEquipDtl
            .EquipmentId = 0
            .EquipInfoId = info_id
            .Property_Dtl_ID = PropDtl_ID
            .MarketValue = txtRoadMarketValue.Text.Replace(",", "")
            .Condition = ""
            .Location = ""
            .Status = "Accepted"
            .MaintenanceContactNo = txtRoadContractor.text
            .MaintenanceContactPerson = txtRoadContactPerson.text
            .MaintenanceContractor = txtRoadCellphoneNo.text
        End With
        objEquipDtl.save()

        'item.save()
        '==== SAVE PROPERTY LEDGER
        With Prop_Ledger
            .Ledger_ID = 0
            .PropertyNo = ""
            .SerialNo = ""
            .Trans_Type = "Manual Entry"
            .dDate = txtRoadAcqDate.Text
            .Ref = ""
            .AccountablePerson = ""
            .Department = ""
            .Position = ""
            .AcceptedBy = ""
            .InspectedBy = ""
            .Item_ID = itemid
            .DebitQty = 1
            .DebitCost = CType(txtRoadAcqCost.Text, Decimal)
            .DebitUnit = objDerived.getvalue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", commandtype.text)
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            .DebitUnit = objDerived.getvalue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", commandtype.text)

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
            .BalanceCost = CType(txtRoadAcqCost.Text, Decimal) + CType(Eqbalance, Decimal)

        End With
        Prop_Ledger.save()

        btnRoadSave.Enabled = True
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        'Load_EncodedProperties()
        idholder = itemid
        loadEquipmentLedger()
        btnRoadSave.Text = "Edit"
    End Sub

    Protected Sub btnRoadCancel_Click(sender As Object, e As EventArgs)


        'Optimize code
        Dim roadTextBoxes() As TextBox = {
    txtRoadProjectName, txtRoadID, txtRoadName, txtRoadClassification,
    txtRoadType, txtRoadFromStreet, txtRoadtoStreet, txtRoadSegmentLock,
    txtRoadLocation, txtRoadLength, txtNoofLane, txtRoadWidth, txtRoadLaneLength,
    txtRoadLaneWidth, txtRoadTrafficDirection, txtRoadTrafficVolume, txtTrafficDate,
    txtRoadSpeedLimit, txtRoadElevation, txtRoadSurfaceType, txtRoadSurfaceCondition,
    txtRoadLfromAddress, txtRoadLtoAddress, txtRoadNorthWestWidth, txtRoadRfromAddress,
    txtRoadRtoAddress, txtRoadAcqDate, txtRoadAcqCost, txtRoadequipmentdepreciatedRate,
    txtRoadequipmentdepreciatedvalue, txtRoadSalvageValue, txtRoadMarketValue
}

        Dim bridgeTextBoxes() As TextBox = {
    txtBridgeProjectName, txtBridgeID, txtBridgeName, txtBridgeType,
    txtBridgeLocation, txtNoofLane, txtTrafficDate, txtBridgeLfromAddress,
    txtBridgeLtoAddress, txtBridgeNorthWestWidth, txtBridgeRfromAddress,
    txtBridgeRtoAddress, txtBridgeStructureNo, txtBridgeRouteSignPrefix,
    txtBridgeRouteNo, txtBridgeFeaturedIntersected, txtBridgeMilePoint,
    txtBridgeBorderStructNo, txtBridgeRoadNo, txtBridgeNameofRiver,
    txtBridgeReferencePost, txtBridgeEndReferencePost, txtBridgeStartPosition,
    txtBridgeCurrentStation, txtBridgeContractor, txtBridgeContactPerson,
    txtBridgeCellphoneNo, txtBridgeAcqDate, txtBridgeAcqCost, txtBridgeDepRate,
    txtBridgeDepValue, txtBridgeSalvageValue, txtBridgeMarketValue
}

        For Each txtBox In roadTextBoxes
            txtBox.Text = ""
        Next

        For Each txtBox In bridgeTextBoxes
            txtBox.Text = ""
        Next


    End Sub


    Protected Sub btnBridgesave_Click(sender As Object, e As EventArgs)
        With item
            .Item_Code = ""
            .Item_Desc = txtBridgeName.Text
            .Unit_ID = objDerived.GetValue("select * From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
        End With

        Dim itemid As Integer
        itemid = item.save()
        objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & txtBridgeAcqCost.Text.Replace(",", "") & "',null", CommandType.Text)

        Dim classification As String = objDerived.getvalue("select  a.ClassificationId From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%'", commandtype.text)
        Dim category As Integer = objDerived.getvalue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & itemid, commandtype.text)
        Dim gaid As Integer = objDerived.getvalue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
        Dim matrix As String = objDerived.getvalue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & gaid & " and item_id = " & itemid & "", commandtype.text)

        If matrix = "" Then
            objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id,SubClassificationID) values('" & classification & "','" & gaid & "','" & itemid & "','" & category & "','0','" & drpSubClass.SelectedItem.Value & "')", commandtype.text)
        End If

        With Prop_Hdr
            '.Property_ID = Property_ID
            .Property_Date = txtBridgeAcqDate.Text
            .Issuance = 0
            .Remarks = "Manual Encoding of Land Properties"
            .Emp_ID = 0
            .F_ID = 1
            .AIRDtl_ID = 0
            .deptid = 0
            .isDonated = False
            .GA_ID = objDerived.getvalue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
            .DonationRemarks = ""
            .Qty = 1
            .Balance = 1
            .Cost = CType(txtBridgeAcqCost.Text.Replace(",", ""), Decimal)
            .Item_ID = itemid
            .Property_code = objDerived.getvalue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
            .RC_ID = 0
            .Function_ID = 0
            .TD_ID = 1
            .Project_ID = 0
            .Program_id = 0
            .Particular = ""
        End With
        Dim PropHdr_ID As Integer = 0
        PropHdr_ID = Prop_Hdr.save()


        objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

        Dim gacode As String = objDerived.getvalue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
        Dim rcid As Integer = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
        Dim Function_ID As Integer = 86


        With Prop_Dtl
            '.PropertyDetai_ID = 0  
            If txtBridgeID.Text = "" Then
                .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtBridgeAcqDate.Text & "', '" & gacode & "','" & rcid & "','" & Function_ID & "')", CommandType.Text)
            Else
                .PropertyNo = txtBridgeID.Text
            End If

            .Property_ID = PropHdr_ID
            .Issued = False
            .Repair = False
            .Dispose = False
            .DisposeDate = "1/1/1900"
            .IsInspectionForDisposal = False
            .InspectionDate = txtBridgeAcqDate.Text
            .F_ID = 1
            .SerialNo = txtBridgeID.Text
            .Barcode = txtBridgeID.Text
            .Amount = CType(txtBridgeAcqCost.Text.Replace(",", ""), Decimal)
            .Status = "Accepted"
            .Details = ""
            .type = drpSubClass.SelectedItem.Text
        End With

        Dim PropDtl_ID As Integer
        PropDtl_ID = Prop_Dtl.save()

        objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtBridgeMarketValue.Text.Replace(",", ""), Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)


        Dim info_id As Integer
        With objEquipInfo
            .EquipInfoId = 0
            .AIRDtl_ID = 0
            .IsAccepted = True
            .Property_Dtl_ID = PropDtl_ID
            .SerialNo = txtBridgeid.text
            .Name = txtBridgeName.text
            .Description = txtBridgeName.text
            .PowerInput = ""
            .Dimension = ""
            .AreaCapacity = ""
            .Model = ""
            .Warranty = ""
            .Specification = ""
            .DepreciationRate = "0"
            .DepreciationValue = "0.00"
            .SalvageValue = txtBridgeSalvageValue.text
            .ProjectName = txtBridgeProjectName.text
            .InfrastructureID = txtBridgeID.text
            .InfrastructureName = txtBridgeName.text
            '.InfrastructureClassification = txtBridgeClassification.text
            .InfrastructureType = txtBridgeType.text
            '            .InfrastructureFromStreet = txtBridgeFromStreet.text
            '            .InfrastructureToStreet = txtBridgetoStreet.text
            '            .InfrastructureSegmentLock = txtBridgeSegmentLock.text
            .InfrastructureLocation = txtBridgeLocation.text
            '            .InfrastructureLength = txtBridgeLength.text
            .InfrastructureNoofLanes = txtNoofLane.text
            '            .InfrastructureWidth = txtBridgeWidth.text
            '            .InfrastructureLaneLength = txtBridgeLaneLength.text
            '            .InfrastructureLaneWidth = txtBridgeLaneWidth.text
            '            .InfrastructureTrafficDirection = txtBridgeTrafficDirection.text
            '            .InfrastructureTrafficVolume = txtBridgeTrafficVolume.text
            .InfrastructureTrafficDate = txtTrafficDate.text
            '            .InfrastructureSpeedLimit = txtBridgeSpeedLimit.text
            '            .InfrastructureElevation = txtBridgeElevation.text
            '            .InfrastructureSurfaceType = ""
            '            .InfrastructureSurfaceCondition = ""
            .LeftLfromAddress = txtBridgeLfromAddress.text
            .LeftLtoAddress = txtBridgeLtoAddress.text
            .LeftNWshldrWidth = txtBridgeNorthWestWidth.text
            .RightRfromAddress = txtBridgeRfromAddress.text
            .RightRtoAddress = txtBridgeRtoAddress.text
            .RightSEshldrWidth = txtBridgeSouthEastWidth.text
            .InfrastructureNumber = txtBridgeStructureNo.text
            .InfrastructureRoutseSignPrefix = txtBridgeRouteSignPrefix.text
            .InfrastructureRouteNo = txtBridgeRouteNo.text
            .InfrastructureFeaturedIntersection = txtBridgeFeaturedIntersected.text
            .InfrastructureMilePoint = txtBridgeMilePoint.text
            .InfrastructureBorderStructNo = txtBridgeBorderStructNo.text
            .InfrastructureRoadNo = txtBridgeRoadNo.text
            .InfrastructureNameofRiver = txtBridgeNameofRiver.text
            .InfrastructureReferencePost = txtBridgeReferencePost.text
            .InfrastructureEndReferencePost = txtBridgeEndReferencePost.text
            .InfrastructureStartPosition = txtBridgeStartPosition.text
            .InfrastructureCurrentPosition = txtBridgeCurrentStation.Text
            .NoYears = txtBridgeNoYears.Text
            .UsefulLife = txtBridgeUsefulLife.Text
        End With

        info_id = objEquipInfo.save()
        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

        With objEquipDtl
            .EquipmentId = 0
            .EquipInfoId = info_id
            .Property_Dtl_ID = PropDtl_ID
            .MarketValue = txtBridgeMarketValue.Text.Replace(",", "")
            .Condition = ""
            .Location = ""
            .Status = "Accepted"
            .MaintenanceContractor = txtBridgeContractor.text
            .MaintenanceContactPerson = txtBridgeContactPerson.text
            .MaintenanceContactNo = txtBridgeCellphoneNo.text
        End With
        objEquipDtl.save()

        'item.save()
        '==== SAVE PROPERTY LEDGER
        With Prop_Ledger
            .Ledger_ID = 0
            .PropertyNo = ""
            .SerialNo = ""
            .Trans_Type = "Manual Entry"
            .dDate = txtBridgeAcqDate.Text
            .Ref = ""
            .AccountablePerson = ""
            .Department = ""
            .Position = ""
            .AcceptedBy = ""
            .InspectedBy = ""
            .Item_ID = itemid
            .DebitQty = 1
            .DebitCost = CType(txtBridgeAcqCost.Text.Replace(",", ""), Decimal)
            .DebitUnit = objDerived.getvalue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", commandtype.text)
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            .DebitUnit = objDerived.getvalue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", commandtype.text)

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
            .BalanceCost = CType(txtBridgeAcqCost.Text.Replace(",", ""), Decimal) + CType(Eqbalance, Decimal)

        End With
        Prop_Ledger.save()

        '' btnBridgeSave.Enabled = False
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        'Load_EncodedProperties()
        idholder = itemid
        loadEquipmentLedger()
        btnBridgesave.Text = "Edit"
    End Sub
    Protected Sub btnCancelBridge_Click(sender As Object, e As EventArgs)
        txtBridgeProjectName.text = ""
        txtBridgeID.text = ""
        txtBridgeName.text = ""
        txtBridgeType.text = ""
        txtBridgeStructureNo.text = ""
        txtBridgeRouteSignPrefix.text = ""
        txtBridgeLocation.text = ""
        txtBridgeRouteNo.text = ""
        txtBridgeFeaturedIntersected.text = ""
        txtBridgeMilePoint.text = ""
        txtBridgeBorderStructNo.text = ""
        txtBridgeRoadNo.text = ""
        txtBridgeNameofRiver.text = ""
        txtBridgeReferencePost.text = ""
        txtBridgeEndReferencePost.text = ""
        txtBridgeStartPosition.text = ""
        txtBridgeCurrentStation.text = ""
        txtBridgeLfromAddress.text = ""
        txtBridgeRfromAddress.text = ""
        txtBridgeLtoAddress.text = ""
        txtBridgeRtoAddress.text = ""
        txtBridgeNorthWestWidth.text = ""
        txtBridgeSouthEastWidth.text = ""
        txtBridgeAcqDate.text = ""
        txtBridgeAcqCost.text = ""
        txtBridgeDepRate.text = ""
        txtBridgeDepValue.text = ""
        txtDepreciationValue.text = ""
        txtBridgeMarketValue.text = ""
        txtBridgeNoYears.text = ""
        txtBridgeUsefulLife.text = ""
        txtBridgeSalvageValue.text = ""
        txtBridgeContractor.text = ""
        txtBridgeContactPerson.text = ""
        txtBridgeCellphoneNo.text = ""
    End Sub
End Class
