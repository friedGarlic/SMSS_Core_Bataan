

Imports System.Data
Imports System.Drawing

Partial Class Inventory_Encoding_CIP

    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim idholder As String = ""
    Protected Sub OnDataBound(sender As Object, e As EventArgs)

        ''Optimize code using chat gpt

    End Sub

    Protected Sub grdLedger1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        Dim dt As DataTable
        Dim cb1 As CheckBox
        Dim subclassID As Integer

        If drpSubClass.SelectedItem.Text.Contains("Roads") Then
            subclassID = 1075
        ElseIf drpSubClass.SelectedItem.Text.Contains("Bridges") Then
            subclassID = 1074
        Else
            subclassID = 0 ' Default (show all)
        End If

        Dim query As String = "SELECT L.Ledger_ID, " &
                          "L.Ref, L.SerialNo, L.Item_ID, L.dDate, L.Trans_Type, " &
                          "L.AccountablePerson, L.Department, L.Position, L.AcceptedBy, L.InspectedBy, " &
                          "L.DebitQty, L.DebitUnit, L.DebitCost, L.CreditQty, L.CreditUnit, L.CreditCost, " &
                          "L.BalanceQty, L.BalanceUnit, L.BalanceCost AS BalCost " &
                          "FROM AMS.TbProperty_Ledger L " &
                          "INNER JOIN dbo.tblclassmatrix C ON L.Item_ID = C.item_id " &
                          "WHERE C.SubClassificationID = " & subclassID & " " &
                          "ORDER BY L.Ledger_ID DESC"

        dt = objDerived.GetDataTable(query, CommandType.Text)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim maxCount As Integer = Math.Min(dt.Rows.Count, grdLedger1.Rows.Count)

            For xa As Integer = 0 To maxCount - 1
                cb1 = CType(Me.grdLedger1.Rows(xa).Cells(0).FindControl("cbInspection"), CheckBox)

                Dim transType As String = dt.Rows(xa).Item("Trans_Type").ToString()
                Dim firstWord As String = transType.Split(" "c)(0)

                If transType = "Purchase Order Delivered" Or firstWord = "Issuance" Then
                    cb1.Enabled = False
                End If
            Next

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
            Dim classificationid As Integer = objDerived.GetValue("Select classificationid From tbl_classification where classificationname like '%Roads and Bridges%'", CommandType.Text)

            Dim PListofGL As New DataTable
            PListofGL = objDerived.GetDataTable("select distinct c.SubClassificationID,c.SubClassificationName " &
                                                "	From tbl_SubClassification as c" &
                                                "        Left outer join tblclassmatrix as b on b.SubClassificationID = c.SubClassificationID" &
                                                "        inner join  tbl_Classification as a on a.ClassificationId = b.classificationid " &
                                                "        where b.classificationid ='" & classificationid & "' order by c.SubClassificationName ", CommandType.Text)

            Me.drpSubClass.Items.Add("Select")
            Me.drpSubClass.DataSource = CType(PListofGL, DataTable)
            Me.drpSubClass.DataTextField = ("SubClassificationName")
            Me.drpSubClass.DataValueField = ("SubClassificationID")
            Me.drpSubClass.DataBind()
            Me.drpSubClass.Enabled = True
            selectSubClass()


            If Session("SavedItemID") IsNot Nothing Then
                idholder = Session("SavedItemID").ToString()
            End If
            loadEquipmentLedger()


            Session.Remove("TempPropertyList")
        End If


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


    Private Function GetNumericOrZero(input As String) As Decimal
        Dim val As Decimal
        Return If(Decimal.TryParse(input.Replace(",", "").Trim(), val), val, 0D)
    End Function

    Protected Sub btnRoadSave_Click(sender As Object, e As EventArgs)
        If btnRoadSave.Text = "SAVE" Then
            Dim missingFields As New List(Of String)

            If String.IsNullOrWhiteSpace(txtRoadID.Text) Then
                missingFields.Add("Property Number")
            End If

            Dim existingCount As Integer = objDerived.GetValue("SELECT COUNT(*) FROM AMS.Property_Dtl WHERE PropertyNo = '" & txtRoadID.Text & "'", CommandType.Text)
            If existingCount > 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property number already existing.")
                Exit Sub
            End If



            If String.IsNullOrWhiteSpace(txtDescriptionRoads.Text) Then
                missingFields.Add("Description")
            End If
            'If drpbookUnit.SelectedIndex = 0 Then
            '    missingFields.Add("Unit")
            'End If
            'If String.IsNullOrWhiteSpace(txtbookQuantity.Text) Then
            '    missingFields.Add("Quantity")
            'End If

            If String.IsNullOrWhiteSpace(txtRemarksRoads.Text) Then
                missingFields.Add("Remarks")
            End If
            If String.IsNullOrWhiteSpace(txtRoadAcqDate.Text) Then
                missingFields.Add("Acquisition Date")
            End If
            If String.IsNullOrWhiteSpace(txtRoadAcqCost.Text) Or txtRoadAcqCost.Text = "0.00" Or txtRoadAcqCost.Text = "0" Then
                missingFields.Add("Acquisition Cost")
            End If

            If missingFields.Count > 0 Then
                Dim message As String = "Please fill up the required field(s):" &
                                "\n - " & String.Join("\n - ", missingFields)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, message)
                Exit Sub
            Else
                CreateRoad()
                loadEquipmentLedger()
            End If


        ElseIf btnRoadSave.Text = "EDIT" Then

            btnRoadSave.Text = "UPDATE"
            IsEnabledTextBox(True)

            txtRoadID.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Textboxes are now enabled to Edit!")

        Else 'IF UPDATE
            UpdateRoadsAndBridges()

            'RESET
            Dim cb1 As CheckBox
            For i As Integer = 0 To grdLedger1.Rows.Count - 1
                cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Checked AndAlso cb1.Visible Then
                    cb1.Checked = False
                End If
            Next


            ClearTextBoxes()
            IsEnabledTextBox(True)
            btnRoadSave.Text = "SAVE"
            btnRoadSave.Enabled = True

            loadEquipmentLedger()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        End If
    End Sub

    Protected Sub CreateRoad()

        With item
            .Item_Code = ""
            .Item_Desc = txtRoadName.Text
            .Unit_ID = objDerived.GetValue("select * From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
        End With

        Dim itemid As Integer
        itemid = item.save()
        objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & txtRoadAcqCost.Text.Replace(",", "") & "',null", CommandType.Text)

        Dim classification As String = objDerived.GetValue("select  a.ClassificationId From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%'", CommandType.Text)
        Dim category As Integer = objDerived.GetValue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & itemid, CommandType.Text)
        Dim gaid As Integer = objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
        Dim matrix As String = objDerived.GetValue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & gaid & " and item_id = " & itemid & "", CommandType.Text)

        If matrix = "" Then
            objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id,SubClassificationID) values('" & classification & "','" & gaid & "','" & itemid & "','" & category & "','0','" & drpSubClass.SelectedItem.Value & "')", CommandType.Text)
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
            .GA_ID = objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
            .DonationRemarks = ""
            .Qty = 1
            .Balance = 1
            .Cost = txtRoadAcqCost.Text.Replace(",", "")
            .Item_ID = itemid
            .Property_code = objDerived.GetValue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
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

        Dim gacode As String = objDerived.GetValue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
        Dim rcid As Integer = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
        Dim Function_ID As Integer = 86


        With Prop_Dtl
            '.PropertyDetai_ID = 0  
            'If txtRoadID.Text = "" Then
            '    .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtRoadAcqDate.Text & "', '" & gacode & "','" & rcid & "','" & Function_ID & "')", CommandType.Text)
            'Else
            '    .PropertyNo = txtRoadID.Text
            'End If
            .PropertyNo = txtRoadID.Text
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

        'objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & txtRoadMarketValue.Text.Replace(",", "") & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = " & If(String.IsNullOrWhiteSpace(txtRoadMarketValue.Text), 0D, CType(txtRoadMarketValue.Text.Replace(",", ""), Decimal)) & " WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

        Dim info_id As Integer
        With objEquipInfo
            .EquipInfoId = 0
            .AIRDtl_ID = 0
            .IsAccepted = True
            .Property_Dtl_ID = PropDtl_ID
            .SerialNo = txtRoadID.Text
            .Name = txtRoadName.Text
            .Description = txtRoadName.Text
            .PowerInput = ""
            .Dimension = ""
            .AreaCapacity = ""
            .Model = ""
            .Warranty = ""
            .Specification = ""
            .DepreciationRate = "0"
            .DepreciationValue = "0.00"
            .SalvageValue = txtRoadSalvageValue.Text.Replace(",", "")
            .ProjectName = txtRoadProjectName.Text
            .InfrastructureID = txtRoadID.Text
            .InfrastructureName = txtRoadName.Text
            .InfrastructureClassification = txtRoadClassification.Text
            .InfrastructureType = txtRoadType.Text
            .InfrastructureFromStreet = txtRoadFromStreet.Text
            .InfrastructureToStreet = txtRoadtoStreet.Text
            .InfrastructureSegmentLock = txtRoadSegmentLock.Text
            .InfrastructureLocation = txtRoadLocation.Text
            .InfrastructureLength = txtRoadLength.Text
            .InfrastructureNoofLanes = txtNoofLane.Text
            .InfrastructureWidth = txtRoadWidth.Text
            .InfrastructureLaneLength = txtRoadLaneLength.Text
            .InfrastructureLaneWidth = txtRoadLaneWidth.Text
            .InfrastructureTrafficDirection = txtRoadTrafficDirection.Text
            .InfrastructureTrafficVolume = txtRoadTrafficVolume.Text
            .InfrastructureTrafficDate = txtTrafficDate.Text
            .InfrastructureSpeedLimit = txtRoadSpeedLimit.Text
            .InfrastructureElevation = txtRoadElevation.Text
            .InfrastructureSurfaceType = txtRoadSurfaceType.Text
            .InfrastructureSurfaceCondition = txtRoadSurfaceCondition.Text
            .LeftLfromAddress = txtRoadLfromAddress.Text
            .LeftLtoAddress = txtRoadLtoAddress.Text
            .LeftNWshldrWidth = txtRoadNorthWestWidth.Text
            .RightRfromAddress = txtRoadRfromAddress.Text
            .RightRtoAddress = txtRoadRtoAddress.Text
            .RightSEshldrWidth = txtRoadSouthEastWidth.Text
            .NoYears = txtRoadNoYears.Text
            .UsefulLife = If(String.IsNullOrWhiteSpace(txtBridgeUsefulLife.Text), 0L, CLng(txtBridgeUsefulLife.Text))
            .Property_ID = PropHdr_ID
        End With

        info_id = objEquipInfo.save()
        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Description = '" & txtDescriptionRoads.Text & "', Remarks = '" & txtRemarksRoads.Text & "'  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

        With objEquipDtl
            .EquipmentId = 0
            .EquipInfoId = info_id
            .Property_Dtl_ID = PropDtl_ID
            .MarketValue = If(String.IsNullOrWhiteSpace(txtBridgeMarketValue.Text), 0D, CDec(txtBridgeMarketValue.Text.Replace(",", "")))

            .Condition = ""
            .Location = ""
            .Status = "Accepted"
            .MaintenanceContactNo = txtRoadContractor.Text
            .MaintenanceContactPerson = txtRoadContactPerson.Text
            .MaintenanceContractor = txtRoadCellphoneNo.Text
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
            .DebitUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            .DebitUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)

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
            .Property_ID = PropHdr_ID

        End With
        Prop_Ledger.save()

        btnRoadSave.Enabled = True
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

    End Sub

    Protected Sub UpdateRoadsAndBridges()

        Dim subclassID As Integer
        If drpSubClass.SelectedItem.Text.Contains("Roads") Then
            subclassID = 1075
        ElseIf drpSubClass.SelectedItem.Text.Contains("Bridges") Then
            subclassID = 1074
        Else
            subclassID = 0 ' Default (show all)
        End If

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        If drpSubClass.SelectedItem.Text.Contains("Roads") Then
            With objDerived.cmd.Parameters
                .AddWithValue("@ProjectName", txtRoadProjectName.Text)
                .AddWithValue("@RoadOrBridgeID", txtRoadID.Text)
                .AddWithValue("@Name", txtRoadName.Text)
                .AddWithValue("@InfrastructureClassification", txtRoadClassification.Text)
                .AddWithValue("@RoadOrBridgeType", txtRoadType.Text)
                .AddWithValue("@InfrastructureFromStreet", txtRoadFromStreet.Text)
                .AddWithValue("@InfrastructureToStreet", txtRoadtoStreet.Text)
                .AddWithValue("@InfrastructureSegmentLock", txtRoadSegmentLock.Text)
                .AddWithValue("@InfrastructureLocation", txtRoadLocation.Text)
                .AddWithValue("@InfrastructureLength", txtRoadLength.Text)
                .AddWithValue("@InfrastructureNoofLanes", txtNoofLane.Text)
                .AddWithValue("@InfrastructureWidth", txtRoadWidth.Text)
                .AddWithValue("@InfrastructureLaneLength", txtRoadLaneLength.Text)
                .AddWithValue("@InfrastructureLaneWidth", txtRoadLaneWidth.Text)
                .AddWithValue("@InfrastructureTrafficDirection", txtRoadTrafficDirection.Text)
                .AddWithValue("@InfrastructureTrafficVolume", txtRoadTrafficVolume.Text)
                .AddWithValue("@InfrastructureTrafficDate", txtTrafficDate.Text)
                .AddWithValue("@InfrastructureSpeedLimit", txtRoadSpeedLimit.Text)
                .AddWithValue("@InfrastructureElevation", txtRoadElevation.Text)
                .AddWithValue("@InfrastructureSurfaceType", txtRoadSurfaceType.Text)
                .AddWithValue("@InfrastructureSurfaceCondition", txtRoadSurfaceCondition.Text)

                .AddWithValue("@LeftLfromAddress", txtRoadLfromAddress.Text)
                .AddWithValue("@LeftLtoAddress", txtRoadLtoAddress.Text)
                .AddWithValue("@LeftNWshldrWidth", txtRoadNorthWestWidth.Text)
                .AddWithValue("@RightRfromAddress", txtRoadRfromAddress.Text)
                .AddWithValue("@RightRtoAddress", txtRoadRtoAddress.Text)
                .AddWithValue("@RightSEshldrWidth", DBNull.Value) ' Not used in Roads

                .AddWithValue("@dDate", txtRoadAcqDate.Text)
                .AddWithValue("@DebitCost", GetNumericOrZero(txtRoadAcqCost.Text))
                .AddWithValue("@DepreciationRate", txtRoadequipmentdepreciatedRate.Text)
                .AddWithValue("@DepreciationValue", GetNumericOrZero(txtRoadequipmentdepreciatedvalue.Text))
                .AddWithValue("@SalvageValue", GetNumericOrZero(txtRoadSalvageValue.Text))
                .AddWithValue("@MarketValue", GetNumericOrZero(txtRoadMarketValue.Text))

                .AddWithValue("@InfrastructureRoutseSignPrefix", DBNull.Value)
                .AddWithValue("@InfrastructureRouteNo", DBNull.Value)
                .AddWithValue("@InfrastructureFeaturedIntersection", DBNull.Value)
                .AddWithValue("@InfrastructureMilePoint", DBNull.Value)
                .AddWithValue("@InfrastructureBorderStructNo", DBNull.Value)
                .AddWithValue("@InfrastructureRoadNo", DBNull.Value)
                .AddWithValue("@InfrastructureNameofRiver", DBNull.Value)
                .AddWithValue("@InfrastructureReferencePost", DBNull.Value)
                .AddWithValue("@InfrastructureEndReferencePost", DBNull.Value)
                .AddWithValue("@InfrastructureStartPosition", DBNull.Value)
                .AddWithValue("@InfrastructureCurrentPosition", DBNull.Value)
                .AddWithValue("@MaintenanceContractor", DBNull.Value)
                .AddWithValue("@MaintenanceContactPerson", DBNull.Value)
                .AddWithValue("@MaintenanceContactNo", DBNull.Value)

                .AddWithValue("@EquipmentInfoID", hf_EquipInfoId.Value)
                .AddWithValue("@EquipmentDtlID", hf_EquipmentId.Value)
                .AddWithValue("@Property_Dtl_ID", hf_PropertyDetai_ID.Value)
                .AddWithValue("@Ledger_ID", hf_Item_ID.Value)
                .AddWithValue("@Property_ID", hf_Property_ID.Value)
                .AddWithValue("@Description", txtDescriptionRoads.Text)
                .AddWithValue("@Remarks", txtRemarksRoads.Text)

            End With

        ElseIf drpSubClass.SelectedItem.Text.Contains("Bridges") Then
            With objDerived.cmd.Parameters
                .AddWithValue("@ProjectName", txtBridgeProjectName.Text)
                .AddWithValue("@RoadOrBridgeID", txtBridgeID.Text)
                .AddWithValue("@Name", txtBridgeName.Text)
                .AddWithValue("@InfrastructureClassification", DBNull.Value)
                .AddWithValue("@RoadOrBridgeType", txtBridgeType.Text)
                .AddWithValue("@InfrastructureFromStreet", DBNull.Value)
                .AddWithValue("@InfrastructureToStreet", DBNull.Value)
                .AddWithValue("@InfrastructureSegmentLock", DBNull.Value)
                .AddWithValue("@InfrastructureLocation", txtBridgeLocation.Text)
                .AddWithValue("@InfrastructureLength", DBNull.Value)
                .AddWithValue("@InfrastructureNoofLanes", txtNoofLane.Text)
                .AddWithValue("@InfrastructureWidth", DBNull.Value)
                .AddWithValue("@InfrastructureLaneLength", DBNull.Value)
                .AddWithValue("@InfrastructureLaneWidth", DBNull.Value)
                .AddWithValue("@InfrastructureTrafficDirection", DBNull.Value)
                .AddWithValue("@InfrastructureTrafficVolume", DBNull.Value)
                .AddWithValue("@InfrastructureTrafficDate", txtTrafficDate.Text)
                .AddWithValue("@InfrastructureSpeedLimit", DBNull.Value)
                .AddWithValue("@InfrastructureElevation", DBNull.Value)
                .AddWithValue("@InfrastructureSurfaceType", DBNull.Value)
                .AddWithValue("@InfrastructureSurfaceCondition", DBNull.Value)

                .AddWithValue("@LeftLfromAddress", txtBridgeLfromAddress.Text)
                .AddWithValue("@LeftLtoAddress", txtBridgeLtoAddress.Text)
                .AddWithValue("@LeftNWshldrWidth", txtBridgeNorthWestWidth.Text)
                .AddWithValue("@RightRfromAddress", txtBridgeRfromAddress.Text)
                .AddWithValue("@RightRtoAddress", txtBridgeRtoAddress.Text)
                .AddWithValue("@RightSEshldrWidth", txtBridgeStructureNo.Text)

                .AddWithValue("@dDate", txtBridgeAcqDate.Text)
                .AddWithValue("@DebitCost", GetNumericOrZero(txtBridgeAcqCost.Text))
                .AddWithValue("@DepreciationRate", txtBridgeDepRate.Text)
                .AddWithValue("@DepreciationValue", GetNumericOrZero(txtBridgeDepValue.Text))
                .AddWithValue("@SalvageValue", GetNumericOrZero(txtBridgeSalvageValue.Text))
                .AddWithValue("@MarketValue", GetNumericOrZero(txtBridgeMarketValue.Text))

                .AddWithValue("@InfrastructureRoutseSignPrefix", txtBridgeRouteSignPrefix.Text)
                .AddWithValue("@InfrastructureRouteNo", txtBridgeRouteNo.Text)
                .AddWithValue("@InfrastructureFeaturedIntersection", txtBridgeFeaturedIntersected.Text)
                .AddWithValue("@InfrastructureMilePoint", txtBridgeMilePoint.Text)
                .AddWithValue("@InfrastructureBorderStructNo", txtBridgeBorderStructNo.Text)
                .AddWithValue("@InfrastructureRoadNo", txtBridgeRoadNo.Text)
                .AddWithValue("@InfrastructureNameofRiver", txtBridgeNameofRiver.Text)
                .AddWithValue("@InfrastructureReferencePost", txtBridgeReferencePost.Text)
                .AddWithValue("@InfrastructureEndReferencePost", txtBridgeEndReferencePost.Text)
                .AddWithValue("@InfrastructureStartPosition", txtBridgeStartPosition.Text)
                .AddWithValue("@InfrastructureCurrentPosition", txtBridgeCurrentStation.Text)
                .AddWithValue("@MaintenanceContractor", txtBridgeContractor.Text)
                .AddWithValue("@MaintenanceContactPerson", txtBridgeContactPerson.Text)
                .AddWithValue("@MaintenanceContactNo", txtBridgeCellphoneNo.Text)

                .AddWithValue("@EquipmentInfoID", hf_EquipInfoId.Value)
                .AddWithValue("@EquipmentDtlID", hf_EquipmentId.Value)
                .AddWithValue("@Property_Dtl_ID", hf_PropertyDetai_ID.Value)
                .AddWithValue("@Property_ID", hf_Property_ID.Value)
                .AddWithValue("@Ledger_ID", hf_Item_ID.Value)
                .AddWithValue("@Description", txtDescription.Text)
                .AddWithValue("@Remarks", txtRemarks.Text)

            End With

        End If

        objDerived.Execute("AMS.sp_Edit_RoadBridges", CommandType.StoredProcedure)


        ''REBALANCE FROM EDITED ROW ABOVE
        'objDerived.GetDataTable("Exec [AMS].[ReBalanceLedger] null, '" & subclassID & "'", CommandType.Text)
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
        If btnBridgesave.Text = "SAVE" Then


            Dim missingFields As New List(Of String)

            If String.IsNullOrWhiteSpace(txtBridgeID.Text) Then
                missingFields.Add("Property Number")
            End If

            Dim existingCount As Integer = objDerived.GetValue("SELECT COUNT(*) FROM AMS.Property_Dtl WHERE PropertyNo = '" & txtBridgeID.Text & "'", CommandType.Text)
            If existingCount > 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property number already existing.")
                Exit Sub
            End If



            If String.IsNullOrWhiteSpace(txtDescription.Text) Then
                missingFields.Add("Description")
            End If
            'If drpbookUnit.SelectedIndex = 0 Then
            '    missingFields.Add("Unit")
            'End If
            'If String.IsNullOrWhiteSpace(txtbookQuantity.Text) Then
            '    missingFields.Add("Quantity")
            'End If

            If String.IsNullOrWhiteSpace(txtRemarks.Text) Then
                missingFields.Add("Remarks")
            End If
            If String.IsNullOrWhiteSpace(txtBridgeAcqDate.Text) Then
                missingFields.Add("Acquisition Date")
            End If
            If String.IsNullOrWhiteSpace(txtBridgeAcqCost.Text) Or txtBridgeAcqCost.Text = "0.00" Or txtBridgeAcqCost.Text = "0" Then
                missingFields.Add("Acquisition Cost")
            End If

            If missingFields.Count > 0 Then
                Dim message As String = "Please fill up the required field(s):" &
                                "\n - " & String.Join("\n - ", missingFields)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, message)
                Exit Sub
            Else
                CreateBridge()
                loadEquipmentLedger()
            End If




        ElseIf btnBridgesave.Text = "EDIT" Then

            IsEnabledTextBox(True)

            btnBridgesave.Text = "UPDATE"
            txtBridgeID.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Textboxes are now enabled to Edit!")

        Else 'IF UPDATE
            UpdateRoadsAndBridges()

            'RESET
            Dim cb1 As CheckBox
            For i As Integer = 0 To grdLedger1.Rows.Count - 1
                cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Checked AndAlso cb1.Visible Then
                    cb1.Checked = False
                End If
            Next


            ClearTextBoxes()
            IsEnabledTextBox(True)
            btnBridgesave.Text = "SAVE"
            btnBridgesave.Enabled = True

            loadEquipmentLedger()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        End If

    End Sub

    Protected Sub CreateBridge()

        With item
            .Item_Code = ""
            .Item_Desc = txtBridgeName.Text
            .Unit_ID = objDerived.GetValue("select * From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
        End With

        Dim itemid As Integer
        itemid = item.save()
        objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & txtBridgeAcqCost.Text.Replace(",", "") & "',null", CommandType.Text)

        Dim classification As String = objDerived.GetValue("select  a.ClassificationId From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%'", CommandType.Text)
        Dim category As Integer = objDerived.GetValue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & itemid, CommandType.Text)
        Dim gaid As Integer = objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
        Dim matrix As String = objDerived.GetValue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & gaid & " and item_id = " & itemid & "", CommandType.Text)

        If matrix = "" Then
            objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id,SubClassificationID) values('" & classification & "','" & gaid & "','" & itemid & "','" & category & "','0','" & drpSubClass.SelectedItem.Value & "')", CommandType.Text)
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
            .GA_ID = objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
            .DonationRemarks = ""
            .Qty = 1
            .Balance = 1
            .Cost = CType(txtBridgeAcqCost.Text.Replace(",", ""), Decimal)
            .Item_ID = itemid
            .Property_code = objDerived.GetValue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
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

        Dim gacode As String = objDerived.GetValue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
        Dim rcid As Integer = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
        Dim Function_ID As Integer = 86


        With Prop_Dtl
            '.PropertyDetai_ID = 0  
            'If txtBridgeID.Text = "" Then
            '    .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtBridgeAcqDate.Text & "', '" & gacode & "','" & rcid & "','" & Function_ID & "')", CommandType.Text)
            'Else
            '    .PropertyNo = txtBridgeID.Text
            'End If
            .PropertyNo = txtBridgeID.Text
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

        'objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtBridgeMarketValue.Text.Replace(",", ""), Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & If(String.IsNullOrWhiteSpace(txtBridgeMarketValue.Text), 0D, CType(txtBridgeMarketValue.Text.Replace(",", ""), Decimal)) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)


        Dim info_id As Integer
        With objEquipInfo
            .EquipInfoId = 0
            .AIRDtl_ID = 0
            .IsAccepted = True
            .Property_Dtl_ID = PropDtl_ID
            .SerialNo = txtBridgeID.Text
            .Name = txtBridgeName.Text
            .Description = txtBridgeName.Text
            .PowerInput = ""
            .Dimension = ""
            .AreaCapacity = ""
            .Model = ""
            .Warranty = ""
            .Specification = ""
            .DepreciationRate = "0"
            .DepreciationValue = "0.00"
            .SalvageValue = txtBridgeSalvageValue.Text
            .ProjectName = txtBridgeProjectName.Text
            .InfrastructureID = txtBridgeID.Text
            .InfrastructureName = txtBridgeName.Text
            '.InfrastructureClassification = txtBridgeClassification.text
            .InfrastructureType = txtBridgeType.Text
            '            .InfrastructureFromStreet = txtBridgeFromStreet.text
            '            .InfrastructureToStreet = txtBridgetoStreet.text
            '            .InfrastructureSegmentLock = txtBridgeSegmentLock.text
            .InfrastructureLocation = txtBridgeLocation.Text
            '            .InfrastructureLength = txtBridgeLength.text
            .InfrastructureNoofLanes = txtNoofLane.Text
            '            .InfrastructureWidth = txtBridgeWidth.text
            '            .InfrastructureLaneLength = txtBridgeLaneLength.text
            '            .InfrastructureLaneWidth = txtBridgeLaneWidth.text
            '            .InfrastructureTrafficDirection = txtBridgeTrafficDirection.text
            '            .InfrastructureTrafficVolume = txtBridgeTrafficVolume.text
            .InfrastructureTrafficDate = txtTrafficDate.Text
            '            .InfrastructureSpeedLimit = txtBridgeSpeedLimit.text
            '            .InfrastructureElevation = txtBridgeElevation.text
            '            .InfrastructureSurfaceType = ""
            '            .InfrastructureSurfaceCondition = ""
            .LeftLfromAddress = txtBridgeLfromAddress.Text
            .LeftLtoAddress = txtBridgeLtoAddress.Text
            .LeftNWshldrWidth = txtBridgeNorthWestWidth.Text
            .RightRfromAddress = txtBridgeRfromAddress.Text
            .RightRtoAddress = txtBridgeRtoAddress.Text
            .RightSEshldrWidth = txtBridgeSouthEastWidth.Text
            .InfrastructureNumber = txtBridgeStructureNo.Text
            .InfrastructureRoutseSignPrefix = txtBridgeRouteSignPrefix.Text
            .InfrastructureRouteNo = txtBridgeRouteNo.Text
            .InfrastructureFeaturedIntersection = txtBridgeFeaturedIntersected.Text
            .InfrastructureMilePoint = txtBridgeMilePoint.Text
            .InfrastructureBorderStructNo = txtBridgeBorderStructNo.Text
            .InfrastructureRoadNo = txtBridgeRoadNo.Text
            .InfrastructureNameofRiver = txtBridgeNameofRiver.Text
            .InfrastructureReferencePost = txtBridgeReferencePost.Text
            .InfrastructureEndReferencePost = txtBridgeEndReferencePost.Text
            .InfrastructureStartPosition = txtBridgeStartPosition.Text
            .InfrastructureCurrentPosition = txtBridgeCurrentStation.Text
            .NoYears = txtBridgeNoYears.Text
            .UsefulLife = If(String.IsNullOrWhiteSpace(txtBridgeUsefulLife.Text), 0L, CLng(txtBridgeUsefulLife.Text))

            .Property_ID = PropHdr_ID
        End With

        info_id = objEquipInfo.save()
        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Description = '" & txtDescription.Text & "', Remarks = '" & txtRemarks.Text & "'  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)


        With objEquipDtl
            .EquipmentId = 0
            .EquipInfoId = info_id
            .Property_Dtl_ID = PropDtl_ID
            .MarketValue = If(String.IsNullOrWhiteSpace(txtBridgeMarketValue.Text), 0D, CDec(txtBridgeMarketValue.Text.Replace(",", "")))

            .Condition = ""
            .Location = ""
            .Status = "Accepted"
            .MaintenanceContractor = txtBridgeContractor.Text
            .MaintenanceContactPerson = txtBridgeContactPerson.Text
            .MaintenanceContactNo = txtBridgeCellphoneNo.Text
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
            .DebitUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            .DebitUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)

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
            .Property_ID = PropHdr_ID
        End With
        Prop_Ledger.save()

        '' btnBridgeSave.Enabled = False
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        'Load_EncodedProperties()
        idholder = itemid
    End Sub

    Protected Sub btnCancelBridge_Click(sender As Object, e As EventArgs)
        txtBridgeProjectName.Text = ""
        txtBridgeID.Text = ""
        txtBridgeName.Text = ""
        txtBridgeType.Text = ""
        txtBridgeStructureNo.Text = ""
        txtBridgeRouteSignPrefix.Text = ""
        txtBridgeLocation.Text = ""
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
        txtBridgeLfromAddress.Text = ""
        txtBridgeRfromAddress.Text = ""
        txtBridgeLtoAddress.Text = ""
        txtBridgeRtoAddress.Text = ""
        txtBridgeNorthWestWidth.Text = ""
        txtBridgeSouthEastWidth.Text = ""
        txtBridgeAcqDate.Text = ""
        txtBridgeAcqCost.Text = ""
        txtBridgeDepRate.Text = ""
        txtBridgeDepValue.Text = ""
        txtDepreciationValue.Text = ""
        txtBridgeMarketValue.Text = ""
        txtBridgeNoYears.Text = ""
        txtBridgeUsefulLife.Text = ""
        txtBridgeSalvageValue.Text = ""
        txtBridgeContractor.Text = ""
        txtBridgeContactPerson.Text = ""
        txtBridgeCellphoneNo.Text = ""
    End Sub

    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim subclassID As Integer

        ' Determine subclass based on dropdown selection
        If drpSubClass.SelectedItem.Text.Contains("Roads") Then
            subclassID = 1075
        ElseIf drpSubClass.SelectedItem.Text.Contains("Bridges") Then
            subclassID = 1074
        Else
            subclassID = 0 ' Default (show all)
        End If

        btnBridgesave.Text = "SAVE"
        btnBridgesave.Enabled = True

        IsEnabledTextBox(True)
        ClearTextBoxes()

        ViewState("CheckboxEvent") = True

        Dim cb1 As CheckBox

        AddTrace("subclassID: " & subclassID)
        Dim dt1 As DataTable = objDerived.GetDataTable("[AMS].[sp_View_Encoding_RoadBridge] '" & subclassID & "'", CommandType.Text)

        For i As Integer = 0 To dt1.Rows.Count - 1
            cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

            If cb1.Checked AndAlso cb1.Visible Then

                IsEnabledTextBox(False)
                btnBridgesave.Text = "EDIT"
                btnRoadSave.Text = "EDIT"


                If drpSubClass.SelectedItem.Text.Contains("Roads") Then

                    txtRoadProjectName.Text = dt1.Rows(i).Item("ProjectName").ToString
                    txtRoadID.Text = dt1.Rows(i).Item("RoadOrBridgeID").ToString
                    txtRoadName.Text = dt1.Rows(i).Item("Name").ToString
                    txtRoadClassification.Text = dt1.Rows(i).Item("InfrastructureClassification").ToString
                    txtRoadType.Text = dt1.Rows(i).Item("RoadOrBridgeType").ToString
                    txtRoadFromStreet.Text = dt1.Rows(i).Item("InfrastructureFromStreet").ToString
                    txtRoadtoStreet.Text = dt1.Rows(i).Item("InfrastructureToStreet").ToString
                    txtRoadSegmentLock.Text = dt1.Rows(i).Item("InfrastructureSegmentLock").ToString

                    txtRoadLocation.Text = dt1.Rows(i).Item("InfrastructureLocation").ToString
                    txtRoadLength.Text = dt1.Rows(i).Item("InfrastructureLength").ToString
                    txtNoofLane.Text = dt1.Rows(i).Item("InfrastructureNoofLanes").ToString
                    txtRoadWidth.Text = dt1.Rows(i).Item("InfrastructureWidth").ToString
                    txtRoadLaneLength.Text = dt1.Rows(i).Item("InfrastructureLaneLength").ToString

                    txtRoadLaneWidth.Text = dt1.Rows(i).Item("InfrastructureLaneWidth").ToString
                    txtRoadTrafficDirection.Text = dt1.Rows(i).Item("InfrastructureTrafficDirection").ToString
                    txtRoadTrafficVolume.Text = dt1.Rows(i).Item("InfrastructureTrafficVolume").ToString
                    txtTrafficDate.Text = dt1.Rows(i).Item("InfrastructureTrafficDate").ToString

                    txtRoadSpeedLimit.Text = dt1.Rows(i).Item("InfrastructureSpeedLimit").ToString
                    txtRoadElevation.Text = dt1.Rows(i).Item("InfrastructureElevation").ToString
                    txtRoadSurfaceType.Text = dt1.Rows(i).Item("InfrastructureSurfaceType").ToString
                    txtRoadSurfaceCondition.Text = dt1.Rows(i).Item("InfrastructureSurfaceCondition").ToString

                    txtRoadLfromAddress.Text = dt1.Rows(i).Item("LeftLfromAddress").ToString
                    txtRoadLtoAddress.Text = dt1.Rows(i).Item("LeftLtoAddress").ToString
                    txtRoadNorthWestWidth.Text = dt1.Rows(i).Item("LeftNWshldrWidth").ToString
                    txtRoadRfromAddress.Text = dt1.Rows(i).Item("RightRfromAddress").ToString
                    txtRoadRtoAddress.Text = dt1.Rows(i).Item("RightRtoAddress").ToString

                    txtRoadAcqDate.Text = dt1.Rows(i).Item("dDate").ToString
                    txtRoadAcqCost.Text = dt1.Rows(i).Item("DebitCost").ToString
                    txtRoadequipmentdepreciatedRate.Text = dt1.Rows(i).Item("DepreciationRate").ToString

                    txtRoadequipmentdepreciatedvalue.Text = dt1.Rows(i).Item("DepreciationValue").ToString
                    txtRoadSalvageValue.Text = dt1.Rows(i).Item("SalvageValue").ToString
                    txtRoadMarketValue.Text = dt1.Rows(i).Item("MarketValue").ToString
                    txtDescriptionRoads.Text = dt1.Rows(i).Item("Description").ToString
                    txtRemarksRoads.Text = dt1.Rows(i).Item("Remarks").ToString

                ElseIf drpSubClass.SelectedItem.Text.Contains("Bridges") Then

                    txtBridgeProjectName.Text = dt1.Rows(i).Item("ProjectName").ToString
                    txtBridgeID.Text = dt1.Rows(i).Item("RoadOrBridgeID").ToString
                    txtBridgeName.Text = dt1.Rows(i).Item("InfrastructureName").ToString
                    txtBridgeType.Text = dt1.Rows(i).Item("RoadOrBridgeType").ToString

                    txtBridgeLocation.Text = dt1.Rows(i).Item("InfrastructureLocation").ToString
                    txtNoofLane.Text = dt1.Rows(i).Item("InfrastructureNoofLanes").ToString
                    txtTrafficDate.Text = dt1.Rows(i).Item("InfrastructureTrafficDate").ToString
                    txtBridgeLfromAddress.Text = dt1.Rows(i).Item("LeftLfromAddress").ToString

                    txtBridgeLtoAddress.Text = dt1.Rows(i).Item("LeftLtoAddress").ToString
                    txtBridgeNorthWestWidth.Text = dt1.Rows(i).Item("LeftNWshldrWidth").ToString
                    txtBridgeRfromAddress.Text = dt1.Rows(i).Item("RightRfromAddress").ToString

                    txtBridgeRtoAddress.Text = dt1.Rows(i).Item("RightRtoAddress").ToString
                    txtBridgeStructureNo.Text = dt1.Rows(i).Item("RightSEshldrWidth").ToString
                    txtBridgeRouteSignPrefix.Text = dt1.Rows(i).Item("InfrastructureRoutseSignPrefix").ToString

                    txtBridgeRouteNo.Text = dt1.Rows(i).Item("InfrastructureRouteNo").ToString
                    txtBridgeFeaturedIntersected.Text = dt1.Rows(i).Item("InfrastructureFeaturedIntersection").ToString
                    txtBridgeMilePoint.Text = dt1.Rows(i).Item("InfrastructureMilePoint").ToString

                    txtBridgeBorderStructNo.Text = dt1.Rows(i).Item("InfrastructureBorderStructNo").ToString
                    txtBridgeRoadNo.Text = dt1.Rows(i).Item("InfrastructureRoadNo").ToString
                    txtBridgeNameofRiver.Text = dt1.Rows(i).Item("InfrastructureNameofRiver").ToString

                    txtBridgeReferencePost.Text = dt1.Rows(i).Item("InfrastructureReferencePost").ToString
                    txtBridgeEndReferencePost.Text = dt1.Rows(i).Item("InfrastructureEndReferencePost").ToString
                    txtBridgeStartPosition.Text = dt1.Rows(i).Item("InfrastructureStartPosition").ToString
                    txtBridgeCurrentStation.Text = dt1.Rows(i).Item("InfrastructureCurrentPosition").ToString

                    txtBridgeContractor.Text = dt1.Rows(i).Item("MaintenanceContractor").ToString
                    txtBridgeContactPerson.Text = dt1.Rows(i).Item("MaintenanceContactPerson").ToString
                    txtBridgeCellphoneNo.Text = dt1.Rows(i).Item("MaintenanceContactNo").ToString

                    txtBridgeAcqDate.Text = dt1.Rows(i).Item("dDate").ToString
                    txtBridgeAcqCost.Text = dt1.Rows(i).Item("DebitCost").ToString
                    txtBridgeDepRate.Text = dt1.Rows(i).Item("DepreciationRate").ToString

                    txtBridgeDepValue.Text = dt1.Rows(i).Item("DepreciationValue").ToString
                    txtBridgeSalvageValue.Text = dt1.Rows(i).Item("SalvageValue").ToString
                    txtBridgeMarketValue.Text = dt1.Rows(i).Item("MarketValue").ToString
                    txtDescription.Text = dt1.Rows(i).Item("Description").ToString
                    txtRemarks.Text = dt1.Rows(i).Item("Remarks").ToString

                End If

                hf_EquipInfoId.Value = dt1.Rows(i).Item("EquipInfoId").ToString
                hf_EquipmentId.Value = dt1.Rows(i).Item("EquipmentId").ToString
                hf_PropertyDetai_ID.Value = dt1.Rows(i).Item("PropertyDetai_ID").ToString
                hf_Property_ID.Value = dt1.Rows(i).Item("Property_ID").ToString
                hf_Item_ID.Value = dt1.Rows(i).Item("Ledger_ID").ToString
            End If
        Next
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub


    Protected Sub IsEnabledTextBox(IsEnabled As Boolean)


        If drpSubClass.SelectedItem.Text.Contains("Roads") Then

            Dim roadTextBoxes() As TextBox = {
                txtRoadProjectName, txtRoadID, txtRoadName, txtRoadClassification,
                txtRoadType, txtRoadFromStreet, txtRoadtoStreet, txtRoadSegmentLock,
                txtRoadLocation, txtRoadLength, txtNoofLane, txtRoadWidth, txtRoadLaneLength,
                txtRoadLaneWidth, txtRoadTrafficDirection, txtRoadTrafficVolume, txtTrafficDate,
                txtRoadSpeedLimit, txtRoadElevation, txtRoadSurfaceType, txtRoadSurfaceCondition,
                txtRoadLfromAddress, txtRoadLtoAddress, txtRoadNorthWestWidth, txtRoadRfromAddress,
                txtRoadRtoAddress, txtRoadAcqDate, txtRoadAcqCost, txtRoadequipmentdepreciatedRate,
                txtRoadequipmentdepreciatedvalue, txtRoadSalvageValue, txtRoadMarketValue, txtRemarksRoads, txtDescriptionRoads
            }

            For Each txtBox In roadTextBoxes
                txtBox.Enabled = IsEnabled
            Next

        ElseIf drpSubClass.SelectedItem.Text.Contains("Bridges") Then

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
                txtBridgeDepValue, txtBridgeSalvageValue, txtBridgeMarketValue, txtRemarks, txtDescription
            }


            For Each txtBox In bridgeTextBoxes
                txtBox.Enabled = IsEnabled
            Next

        End If

    End Sub

    Protected Sub ClearTextBoxes()


        If drpSubClass.SelectedItem.Text.Contains("Roads") Then

            Dim roadTextBoxes() As TextBox = {
                txtRoadProjectName, txtRoadID, txtRoadName, txtRoadClassification,
                txtRoadType, txtRoadFromStreet, txtRoadtoStreet, txtRoadSegmentLock,
                txtRoadLocation, txtRoadLength, txtNoofLane, txtRoadWidth, txtRoadLaneLength,
                txtRoadLaneWidth, txtRoadTrafficDirection, txtRoadTrafficVolume, txtTrafficDate,
                txtRoadSpeedLimit, txtRoadElevation, txtRoadSurfaceType, txtRoadSurfaceCondition,
                txtRoadLfromAddress, txtRoadLtoAddress, txtRoadNorthWestWidth, txtRoadRfromAddress,
                txtRoadRtoAddress, txtRoadAcqDate, txtRoadAcqCost, txtRoadequipmentdepreciatedRate,
                txtRoadequipmentdepreciatedvalue, txtRoadSalvageValue, txtRoadMarketValue, txtDescriptionRoads, txtRemarksRoads
            }

            For Each txtBox In roadTextBoxes
                txtBox.Text = String.Empty
            Next

        ElseIf drpSubClass.SelectedItem.Text.Contains("Bridges") Then

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
                txtBridgeDepValue, txtBridgeSalvageValue, txtBridgeMarketValue, txtRemarks, txtDescription
            }


            For Each txtBox In bridgeTextBoxes
                txtBox.Text = String.Empty
            Next

        End If

    End Sub

    Protected Sub grdLedger1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles grdLedger1.RowCreated

        If grdLedger1.HeaderRow IsNot Nothing AndAlso grdLedger1.Rows.Count > 0 Then
            If grdLedger1.Controls.Count > 0 AndAlso grdLedger1.Controls(0).Controls.Count > 0 Then
                ' Prevent duplicate custom header rows
                Dim headerAlreadyExists As Boolean = False
                For Each row As GridViewRow In grdLedger1.Controls(0).Controls
                    If row.RowType = DataControlRowType.Header AndAlso row.Cells(0).Text = "ROADS AND BRIDGES CONSTRUCTION" Then
                        headerAlreadyExists = True
                        Exit For
                    End If
                Next

                If Not headerAlreadyExists Then

                    Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
                    row.BackColor = Color.White
                    row.ForeColor = Color.Black

                    Dim cell As TableHeaderCell

                    cell = New TableHeaderCell()
                    cell.Text = "ROADS AND BRIDGES CONSTRUCTION"
                    cell.ColumnSpan = 4
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
                End If
            End If
        End If
    End Sub
End Class

