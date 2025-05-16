
Imports System.Data
Imports System.Drawing

Partial Class Inventory_Encoding_Books
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Dim dbAcquisitionCost As Double
    Dim counts As Integer = 0


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            multiviewselected()    ' Existing code that loads the item dropdown, etc.
            loadBookLedger()       ' Existing code for ledger

            ' 1) Initialize the property rows in memory for the selected item
            LoadExistingPropertyRowsIntoViewState()
        End If
    End Sub

    Private Sub LoadExistingPropertyRowsIntoViewState()
        ' 1) If there's an existing item or item_id
        Dim itemId As String = hdnItemNo.Value
        If String.IsNullOrEmpty(itemId) Then
            itemId = "0"
        End If

        ' 2) Query the DB for existing property rows for this item
        Dim dtFromDB As DataTable = objDerived.GetDataTable(
        "SELECT b.PropertyNo, " &
        "       a.Property_ID, " &
        "       b.PropertyDetai_ID, " &
        "       b.AccountablePerson " &
        "FROM AMS.Property AS a " &
        "INNER JOIN AMS.Property_Dtl AS b ON a.Property_ID = b.Property_ID " &
        "WHERE a.Item_ID = " & itemId, CommandType.Text)

        ' 3) Create a memory DataTable matching your grid columns
        Dim dtMemory As New DataTable()
        dtMemory.Columns.Add("PropertyNo", GetType(String))
        dtMemory.Columns.Add("AccountablePerson", GetType(String))
        ' Add more columns if needed (FloorLocation, Room, etc.)

        ' 4) Copy rows from dtFromDB into dtMemory
        For Each dbRow As DataRow In dtFromDB.Rows
            Dim newRow As DataRow = dtMemory.NewRow()
            newRow("PropertyNo") = dbRow("PropertyNo").ToString()
            newRow("AccountablePerson") = dbRow("AccountablePerson").ToString()
            ' ...
            dtMemory.Rows.Add(newRow)
        Next

        ' 5) Store dtMemory into ViewState
        ViewState("Customers") = dtMemory
    End Sub



    Protected Sub Inventory_Encoding_Books_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            multiviewselected()
            loadBookLedger()
            ' Initialize ViewState("Customers") if necessary
            ViewState("Customers") = Nothing
        End If
    End Sub

    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpbookUnit.DataSource = dt
        drpbookUnit.DataTextField = ("Description")
        drpbookUnit.DataValueField = ("Unit_ID")
        drpbookUnit.DataBind()
    End Sub

    Public Sub loadwarehouse()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("select warehouse_id,wname From ams.loc_warehouse", CommandType.Text)
        drpbookWarehouse.DataTextField = ("wname")
        drpbookWarehouse.DataValueField = ("warehouse_id")
        drpbookWarehouse.DataSource = dt
        drpbookWarehouse.DataBind()

    End Sub

    Protected Sub loadInformation_from_drpName()
        ' Dim CYear As String = "CY" & Year(txtdate.text)
        Dim itemid As String
        loadUnit()
        loadwarehouse()

        If drpbookName.Text = "" Then

            itemid = "0"
        Else
            itemid = drpbookName.SelectedValue
        End If

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear,Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then
            'LoadEquipDTL()
            btnSave.Enabled = False
            btnCancel.Enabled = False
        Else
            hdnItemNo.Value = itemid
            hdnGAId.Value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
            txtbookName.Text = dt.Rows(0).Item("Name").ToString
            txtbookdesciption.Text = dt.Rows(0).Item("Name").ToString




            btnSave.Enabled = True
            btnCancel.Enabled = True

            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("[AMS].[sp_View_Encoding] 'Books','" & itemid & "'", CommandType.Text)
            If dt1.Rows.Count > 0 Then
                txtBookClassification.Text = dt1.Rows(0).Item("Classification").ToString
                txtBookClassificationCode.Text = dt1.Rows(0).Item("ClassificationCode").ToString
                txtbookTitle.Text = dt1.Rows(0).Item("Title").ToString
                txtBookPublicationDate.Text = dt1.Rows(0).Item("PublicationDate").ToString
                drpbookUnit.Text = dt1.Rows(0).Item("Unit_ID").ToString
                txtbookQuantity.Text = dt1.Rows(0).Item("DebitQty").ToString
                txtBookPrice.Text = dt1.Rows(0).Item("bPrice").ToString
                txtBookISBN.Text = dt1.Rows(0).Item("ISBN").ToString
                txtbookAuthor.Text = dt1.Rows(0).Item("Author").ToString
                txtbookAcqDate.Text = Convert.ToDateTime(dt1.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
                txtbookAcqCost.Text = dt1.Rows(0).Item("Cost").ToString
                txtbookdepreciatedRate.Text = dt1.Rows(0).Item("DepreciationRate").ToString
                txtbookdepreciatedvalue.Text = dt1.Rows(0).Item("DepreciationValue").ToString
                txtbookMarketValue.Text = dt1.Rows(0).Item("MarketValue").ToString
                txtNoYears.Text = dt1.Rows(0).Item("NoYears").ToString
                txtbookUsefulLife.Text = dt1.Rows(0).Item("UsefulLife").ToString
                txtbookSalvageValue.Text = dt1.Rows(0).Item("SalvageValue").ToString
                drpbookWarehouse.Text = dt1.Rows(0).Item("warehouseid").ToString
                txtbookRoom.Text = dt1.Rows(0).Item("Room").ToString
                txtbookBay.Text = dt1.Rows(0).Item("Bay").ToString
                txtbookShelves.Text = dt1.Rows(0).Item("Shelves").ToString
                txtbookColumn.Text = dt1.Rows(0).Item("Column").ToString
                txtbookRack.Text = dt1.Rows(0).Item("Rack").ToString
                txtbookFloor.Text = dt1.Rows(0).Item("Floor").ToString
                txtbookBin.Text = dt1.Rows(0).Item("Bin").ToString


                hf_EquipInfoId.Value = dt1.Rows(0).Item("EquipInfoId").ToString
                hf_EquipmentId.Value = dt1.Rows(0).Item("EquipmentId").ToString
                hf_PropertyDetai_ID.Value = dt1.Rows(0).Item("PropertyDetai_ID").ToString
                hf_Property_ID.Value = dt1.Rows(0).Item("Property_ID").ToString
                hf_Item_ID.Value = dt1.Rows(0).Item("Item_ID").ToString
            End If


        End If



    End Sub


    Public Sub multiviewselected()
        Dim Classification As Integer
        Classification = objDerived.GetValue("select [ClassificationId] From [dbo].[tbl_Classification] where [ClassificationName] like 'Book%'", CommandType.Text)

        Dim itemdesc As New DataTable
        Dim dtitemdesc As New DataTable
        dtitemdesc = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_v2.1_03302023] " & Classification, CommandType.Text)
        drpbookName.DataSource = dtitemdesc
        drpbookName.DataTextField = ("ItemDescription")
        drpbookName.DataValueField = ("Item_ID")
        drpbookName.DataBind()
        drpbookName.Enabled = True
        loadInformation_from_drpName()
    End Sub


    Private Sub UpdateGridDataFromUserInput()
        If grdPropertyInfo.Rows.Count = 0 Then Exit Sub

        Dim dt As DataTable = TryCast(ViewState("Customers"), DataTable)
        If dt Is Nothing Then Exit Sub

        ' Ensure row count matches
        If grdPropertyInfo.Rows.Count > dt.Rows.Count Then
            ' Potential mismatch if quantity changed, but for simplicity we skip
            ' or you can expand dt as needed
        End If

        ' Loop each row in the GridView
        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            Dim row As GridViewRow = grdPropertyInfo.Rows(i)
            If row.RowType = DataControlRowType.DataRow Then
                Dim txtPropNo As TextBox = CType(row.FindControl("txtPropertyNo"), TextBox)
                Dim txtAccPerson As TextBox = CType(row.FindControl("txtAccountablePerson"), TextBox)
                ' Add more fields if your columns are bigger

                ' Store the user input back into dt
                If i < dt.Rows.Count Then
                    dt.Rows(i)("PropertyNo") = txtPropNo.Text.Trim()
                    dt.Rows(i)("AccountablePerson") = txtAccPerson.Text.Trim()
                End If
            End If
        Next

        ViewState("Customers") = dt
    End Sub



    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)
        ' 1) Always first retrieve or create the DataTable from ViewState
        UpdateGridDataFromUserInput()  ' Harvest current typed data

        Dim dt As DataTable
        If ViewState("Customers") IsNot Nothing Then
            dt = DirectCast(ViewState("Customers"), DataTable)
        Else
            ' If no table yet in ViewState, create one that matches the structure
            dt = New DataTable()
            dt.Columns.Add("PropertyNo", GetType(String))
            dt.Columns.Add("AccountablePerson", GetType(String))
            ' Add columns if needed
        End If

        ' 2) Check user input for quantity
        If String.IsNullOrWhiteSpace(txtbookQuantity.Text) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
            Return
        End If

        Dim desiredQty As Integer
        If Not Integer.TryParse(txtbookQuantity.Text.Trim(), desiredQty) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Quantity.")
            Return
        End If

        ' 3) If the user wants more rows than we currently have, add blank rows
        While dt.Rows.Count < desiredQty
            Dim newRow As DataRow = dt.NewRow()
            newRow("PropertyNo") = ""             ' blank
            newRow("AccountablePerson") = ""      ' blank
            dt.Rows.Add(newRow)
        End While

        ' (Optional) If user typed a smaller quantity, we can remove extra rows
        While dt.Rows.Count > desiredQty
            dt.Rows.RemoveAt(dt.Rows.Count - 1)
        End While

        ' 4) Store the updated DataTable back in ViewState
        ViewState("Customers") = dt

        ' 5) Re-bind the grid from memory
        BindGrid()

        ' 6) Show the modal
        ModalPopupExtender2.Show()
    End Sub


    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs) Handles btnProceedEdit.Click
        ' 1) Save user entries from the current GridView to the DataTable
        UpdateGridDataFromUserInput()

        ' 2) Re-bind if you want to see changes in the background
        BindGrid()

        ' 3) Hide the modal if that is the intended user experience
        ModalPopupExtender2.Hide()
    End Sub



    Protected Sub BindGrid()
        Dim dt As DataTable = TryCast(ViewState("Customers"), DataTable)
        grdPropertyInfo.DataSource = dt
        grdPropertyInfo.DataBind()
    End Sub


    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim dtMemory As DataTable = TryCast(grdPropertyInfo.DataSource, DataTable)
            ' or TryCast(ViewState("Customers"), DataTable)

            If dtMemory IsNot Nothing AndAlso e.Row.RowIndex < dtMemory.Rows.Count Then
                Dim dr As DataRow = dtMemory.Rows(e.Row.RowIndex)
                Dim txtPN As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
                Dim txtAcc As TextBox = CType(e.Row.FindControl("txtAccountablePerson"), TextBox)

                txtPN.Text = dr("PropertyNo").ToString()
                txtAcc.Text = dr("AccountablePerson").ToString()
                ' etc...
            End If
        End If
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)


        If btnSave.Text = "SAVE" Then
            SAVE()
        ElseIf btnSave.Text = "EDIT" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            ModalPopupExtender1.Show()
        ElseIf btnSave.Text = "UPDATE" Then
            EDIT()
        End If

    End Sub
    Public Sub EDIT()
        If txtbookName.Text = "" Or txtbookdesciption.Text = "" Or
            txtbookUsefulLife.Text = "" Or txtbookdepreciatedRate.Text = "" Or
            txtbookAcqCost.Text = "" Or txtbookdepreciatedvalue.Text = "" Or
            txtbookSalvageValue.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
        Else
            If Not IsNumeric(txtbookdepreciatedRate.Text) Or Not IsNumeric(txtbookAcqCost.Text) Or Not IsNumeric(txtbookdepreciatedvalue.Text) Or Not IsNumeric(txtbookSalvageValue.Text) Then
            Else
                Try
                    Dim objDerived As New DerivedDal
                    objDerived.conStr = objDerived.DbaseConnect()

                    objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", hf_EquipInfoId.Value)
                    objDerived.cmd.Parameters.AddWithValue("@Name", txtbookName.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Description", txtbookdesciption.Text)
                    objDerived.cmd.Parameters.AddWithValue("@ISBN", txtBookISBN.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Classification", txtBookClassification.Text)
                    objDerived.cmd.Parameters.AddWithValue("@ClassificationCode", txtBookClassificationCode.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Title", txtbookTitle.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Author", txtbookAuthor.Text)
                    objDerived.cmd.Parameters.AddWithValue("@PublicationDate", txtBookPublicationDate.Text)
                    objDerived.cmd.Parameters.AddWithValue("@NoYears", txtNoYears.Text)
                    objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", txtbookdepreciatedRate.Text)
                    objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtbookUsefulLife.Text)
                    objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtbookdepreciatedvalue.Text.Replace(",", ""))
                    objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtbookSalvageValue.Text.Replace(",", ""))

                    objDerived.cmd.Parameters.AddWithValue("@Item_ID", hf_Item_ID.Value)
                    objDerived.cmd.Parameters.AddWithValue("@Unit_ID", drpbookUnit.SelectedValue)

                    objDerived.cmd.Parameters.AddWithValue("@Property_ID", hf_Property_ID.Value)
                    objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtbookAcqDate.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Qty", txtbookQuantity.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Cost", txtbookAcqCost.Text.Replace(",", ""))

                    objDerived.cmd.Parameters.AddWithValue("@EquipmentId", hf_EquipmentId.Value)
                    objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtbookMarketValue.Text.Replace(",", ""))

                    objDerived.cmd.Parameters.AddWithValue("@Bay", txtbookBay.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Column", txtbookColumn.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Floor", txtbookFloor.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Room", txtbookRoom.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Shelves", txtbookShelves.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Rack", txtbookRack.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Bin", txtbookBin.Text)
                    objDerived.cmd.Parameters.AddWithValue("@warehouseid", drpbookWarehouse.SelectedValue)



                    objDerived.Execute("AMS.sp_Edit_Books", CommandType.StoredProcedure)

                    Dim dt1 As DataTable = objDerived.GetDataTable("SELECT b.PropertyNo,a.Property_ID,b.PropertyDetai_ID FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        objDerived.GetRecords("UPDATE AMS.Property_Dtl SET PropertyNo = '" _
                                                                                            & CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text &
                                                                             "' WHERE PropertyNo = '" & dt1.Rows(i).Item("PropertyNo").ToString & "'", CommandType.Text)





                    Next

                    For i As Integer = dt1.Rows.Count To grdPropertyInfo.Rows.Count - 1

                        Dim Prop_Dtl As New t_property_dtl
                        With Prop_Dtl
                            .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                            .Property_ID = dt1.Rows(0).Item("Property_ID").ToString
                            .Issued = False
                            .Repair = False
                            .Dispose = False
                            .DisposeDate = "1/1/1900"
                            .IsInspectionForDisposal = False
                            .InspectionDate = txtbookAcqDate.Text
                            .F_ID = 1
                            ' .SerialNo = txtbookSerialNo.text
                            .Barcode = " "
                            .Amount = CType(txtbookAcqCost.Text, Decimal)
                            .Status = "Accepted"
                            '.Details = txtbookSpecification.Text
                            .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                            .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                            .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
                            .Function_ID = 86
                        End With

                        Dim PropDtl_ID As Integer
                        PropDtl_ID = Prop_Dtl.save()

                        '  objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtbookMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)


                        Dim info_id As Integer
                        Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info

                        With objEquipInfo
                            .EquipInfoId = 0
                            .AIRDtl_ID = 0
                            .IsAccepted = True
                            .Property_Dtl_ID = PropDtl_ID
                            ' .SerialNo = txtbookSerialNo.text
                            .Name = txtbookName.Text
                            .Description = txtbookdesciption.Text
                            ' .PowerInput = txtbookpowerinput.text
                            '                        .Dimension = txtbookdimension.text
                            .AreaCapacity = txtbookareacapacity.Text
                            '                        .Model = txtbookmodel.text
                            '                        .Warranty = txtbookwaranty.text
                            '                        .Specification = txtbookSpecification.Text
                            .DepreciationRate = txtbookdepreciatedRate.Text
                            .DepreciationValue = txtbookdepreciatedvalue.Text
                            .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                            .RoomLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIRoom"), TextBox).Text
                            .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                            'CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).SelectedItem.value
                            .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
                            .SalvageValue = txtbookSalvageValue.Text
                            .Classification = txtBookClassification.Text
                            .ClassificationCode = txtBookClassificationCode.Text
                            .Title = txtbookTitle.Text
                            .PublicationDate = txtBookPublicationDate.Text
                            .bPrice = txtBookPrice.Text
                            .ISBN = txtBookISBN.Text
                            .Author = txtbookAuthor.Text
                            .NoYears = txtNoYears.Text
                            .UsefulLife = txtbookUsefulLife.Text


                        End With

                        info_id = objEquipInfo.save()
                        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

                        Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details
                        With objEquipDtl
                            .EquipmentId = 0
                            .EquipInfoId = info_id
                            .Property_Dtl_ID = PropDtl_ID
                            .MarketValue = txtbookMarketValue.Text
                            .Condition = ""

                            'If txtbookBay.Text <> "" Then
                            '    locations = "Bay-" & txtbookBay.Text
                            'End If

                            'If txtbookColumn.Text <> "" Then
                            '    locations = locations + " " + "Column-" & txtbookColumn.Text
                            'End If

                            'If txtbookFloor.Text <> "" Then
                            '    locations = locations + " " + "Floor-" & txtbookFloor.Text
                            'End If

                            'If txtbookRoom.Text <> "" Then
                            '    locations = locations + " " + "Room-" & txtbookRoom.Text
                            'End If

                            'If txtbookShelves.Text <> "" Then
                            '    locations = locations + " " + "Shelves-" & txtbookShelves.Text
                            'End If

                            'If txtbookRack.Text <> "" Then
                            '    locations = locations + " " + "Rack-" & txtbookRack.Text
                            'End If

                            'If txtbookBin.Text <> "" Then
                            '    locations = locations + " " + "Bin-" & txtbookBin.Text
                            'End If
                            'If String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                            '    locations = "Bay-" & txtbookBay.Text
                            'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                            '    locations = "Column-" & txtbookColumn.Text
                            'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                            '    locations = "Floor-" & txtbookFloor.Text
                            'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                            '    locations = "Room-" & txtbookRoom.Text
                            'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                            '    locations = "Shelves-" & txtbookShelves.Text
                            'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                            '    locations = "Rack-" & txtbookRack.Text
                            'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) Then
                            '    locations = "Bin-" & txtbookBin.Text
                            'End If

                            'Optimize code
                            Dim locations As String = ""
                            Dim prefix As String = ""
                            If Not String.IsNullOrEmpty(txtbookBay.Text) Then
                                locations += "Bay-" & txtbookBay.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookColumn.Text) Then
                                locations += prefix & "Column-" & txtbookColumn.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookFloor.Text) Then
                                locations += prefix & "Floor-" & txtbookFloor.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookRoom.Text) Then
                                locations += prefix & "Room-" & txtbookRoom.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookShelves.Text) Then
                                locations += prefix & "Shelves-" & txtbookShelves.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookRack.Text) Then
                                locations += prefix & "Rack-" & txtbookRack.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookBin.Text) Then
                                locations += prefix & "Bin-" & txtbookBin.Text
                            End If

                            .Location = locations

                            .Bay = txtbookBay.Text
                            .Column = txtbookColumn.Text
                            .Floor = txtbookFloor.Text
                            .Room = txtbookRoom.Text
                            .Shelves = txtbookShelves.Text
                            .Rack = txtbookRack.Text
                            .Bin = txtbookBin.Text


                            .Status = "Accepted"
                            .WarehouseID = drpbookWarehouse.SelectedValue
                            '   .BuildingId = drpInstalledAtBuilding.selecteditem.value
                            '                        .MaintenanceContactNo = txtContractor.text
                            ' .MaintenanceContactPerson = txtContactPerson.text
                            '.MaintenanceContractor = txtCellphoneNo.text


                        End With
                        objEquipDtl.save()

                    Next



                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
    Public Sub SAVE()
        Dim a1 As String
        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            'msgbox(CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text)

            If CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text = "" Then
                a1 = ""
            Else
                a1 = 1
            End If
        Next

        If a1 = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill Up the Property Information Fields")
            Exit Sub
        End If

        'If txtbookName.Text = "" Or txtbookdesciption.Text = "" Or
        '    txtbookUsefulLife.Text = "" Or txtbookdepreciatedRate.Text = "" Or
        '    txtbookAcqCost.Text = "" Or txtbookdepreciatedvalue.Text = "" Or
        '    txtbookSalvageValue.Text = "" Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
        'Else
        If Not IsNumeric(txtbookdepreciatedRate.Text) Or Not IsNumeric(txtbookAcqCost.Text) Or Not IsNumeric(txtbookdepreciatedvalue.Text) Or Not IsNumeric(txtbookSalvageValue.Text) Then
        Else
            Dim Prop_Hdr As New t_property_hdr
            With Prop_Hdr
                '.Property_ID = Property_ID
                .Property_Date = txtbookAcqDate.Text
                .Issuance = 0
                .Remarks = "Manual Encoding of Old Properties"
                .Emp_ID = 0
                .F_ID = 1
                .AIRDtl_ID = 0
                .deptid = 0
                .isDonated = False
                .GA_ID = hdnGAId.Value
                .DonationRemarks = ""
                .Qty = txtbookQuantity.Text
                .Balance = txtbookQuantity.Text
                .Cost = CType(txtbookAcqCost.Text, Decimal)
                .Item_ID = hdnItemNo.Value
                .Property_code = objDerived.GetValue("select ga_code2 from [AMS].[vw_item_master_list] where Item_ID ='" & hdnItemNo.Value & "' ", CommandType.Text)
                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .Function_ID = objDerived.GetValue("select Function_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .TD_ID = 1
                .Project_ID = 0
                .Program_id = 0
                .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
            End With

            Dim PropHdr_ID As Integer = 0
            PropHdr_ID = Prop_Hdr.save()


            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

            Dim locations As String = ""
            For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1

                Dim Prop_Dtl As New t_property_dtl
                With Prop_Dtl
                    .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                    .Property_ID = PropHdr_ID
                    .Issued = False
                    .Repair = False
                    .Dispose = False
                    .DisposeDate = "1/1/1900"
                    .IsInspectionForDisposal = False
                    .InspectionDate = txtbookAcqDate.Text
                    .F_ID = 1
                    ' .SerialNo = txtbookSerialNo.text
                    .Barcode = " "
                    .Amount = CType(txtbookAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    '.Details = txtbookSpecification.Text
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
                    .Function_ID = 86
                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = Prop_Dtl.save()

                '  objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtbookMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)


                Dim info_id As Integer
                Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info

                With objEquipInfo
                    .EquipInfoId = 0
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = PropDtl_ID
                    ' .SerialNo = txtbookSerialNo.text
                    .Name = txtbookName.Text
                    .Description = txtbookdesciption.Text
                    ' .PowerInput = txtbookpowerinput.text
                    '                        .Dimension = txtbookdimension.text
                    .AreaCapacity = txtbookareacapacity.Text
                    '                        .Model = txtbookmodel.text
                    '                        .Warranty = txtbookwaranty.text
                    '                        .Specification = txtbookSpecification.Text
                    .DepreciationRate = txtbookdepreciatedRate.Text
                    .DepreciationValue = txtbookdepreciatedvalue.Text
                    .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                    .RoomLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIRoom"), TextBox).Text
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    'CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).SelectedItem.value
                    .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
                    .SalvageValue = txtbookSalvageValue.Text
                    .Classification = txtBookClassification.Text
                    .ClassificationCode = txtBookClassificationCode.Text
                    .Title = txtbookTitle.Text
                    .PublicationDate = txtBookPublicationDate.Text
                    .bPrice = txtBookPrice.Text
                    .ISBN = txtBookISBN.Text
                    .Author = txtbookAuthor.Text
                    .NoYears = txtNoYears.Text
                    .UsefulLife = txtbookUsefulLife.Text


                End With

                info_id = objEquipInfo.save()
                objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

                Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details
                With objEquipDtl
                    .EquipmentId = 0
                    .EquipInfoId = info_id
                    .Property_Dtl_ID = PropDtl_ID
                    .MarketValue = txtbookMarketValue.Text
                    .Condition = ""

                    'If txtbookBay.Text <> "" Then
                    '    locations = "Bay-" & txtbookBay.Text
                    'End If

                    'If txtbookColumn.Text <> "" Then
                    '    locations = locations + " " + "Column-" & txtbookColumn.Text
                    'End If

                    'If txtbookFloor.Text <> "" Then
                    '    locations = locations + " " + "Floor-" & txtbookFloor.Text
                    'End If

                    'If txtbookRoom.Text <> "" Then
                    '    locations = locations + " " + "Room-" & txtbookRoom.Text
                    'End If

                    'If txtbookShelves.Text <> "" Then
                    '    locations = locations + " " + "Shelves-" & txtbookShelves.Text
                    'End If

                    'If txtbookRack.Text <> "" Then
                    '    locations = locations + " " + "Rack-" & txtbookRack.Text
                    'End If

                    'If txtbookBin.Text <> "" Then
                    '    locations = locations + " " + "Bin-" & txtbookBin.Text
                    'End If

                    'If String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Bay-" & txtbookBay.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Column-" & txtbookColumn.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Floor-" & txtbookFloor.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Room-" & txtbookRoom.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Shelves-" & txtbookShelves.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Rack-" & txtbookRack.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) Then
                    '    locations = "Bin-" & txtbookBin.Text
                    'End If

                    'Optimize code
                    'Dim locations As String = ""
                    Dim prefix As String = ""
                    If Not String.IsNullOrEmpty(txtbookBay.Text) Then
                        locations += "Bay-" & txtbookBay.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookColumn.Text) Then
                        locations += prefix & "Column-" & txtbookColumn.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookFloor.Text) Then
                        locations += prefix & "Floor-" & txtbookFloor.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookRoom.Text) Then
                        locations += prefix & "Room-" & txtbookRoom.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookShelves.Text) Then
                        locations += prefix & "Shelves-" & txtbookShelves.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookRack.Text) Then
                        locations += prefix & "Rack-" & txtbookRack.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookBin.Text) Then
                        locations += prefix & "Bin-" & txtbookBin.Text
                    End If

                    .Location = locations

                    .Bay = txtbookBay.Text
                    .Column = txtbookColumn.Text
                    .Floor = txtbookFloor.Text
                    .Room = txtbookRoom.Text
                    .Shelves = txtbookShelves.Text
                    .Rack = txtbookRack.Text
                    .Bin = txtbookBin.Text


                    .Status = "Accepted"
                    .WarehouseID = drpbookWarehouse.SelectedValue
                    '   .BuildingId = drpInstalledAtBuilding.selecteditem.value
                    '                        .MaintenanceContactNo = txtContractor.text
                    ' .MaintenanceContactPerson = txtContactPerson.text
                    '.MaintenanceContractor = txtCellphoneNo.text


                End With
                objEquipDtl.save()

            Next

            Dim Prop_Ledger As New t_PropertyLedger

            With Prop_Ledger
                .Ledger_ID = 0
                .PropertyNo = ""
                .SerialNo = ""
                .Trans_Type = "Manual Entry"
                .dDate = txtbookAcqDate.Text
                .Ref = ""
                .AccountablePerson = ""
                .Department = 0
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = hdnItemNo.Value
                .DebitQty = txtbookQuantity.Text
                .DebitCost = CType(txtbookAcqCost.Text, Decimal) * txtbookQuantity.Text
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)

                Dim Eqty As Integer
                Dim Eqbalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    Eqty = 0
                    Eqbalance = 0.0
                Else
                    Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                    Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                End If
                .BalanceQty = Eqty + txtbookQuantity.Text
                .BalanceCost = (CType(txtbookAcqCost.Text, Decimal) * txtbookQuantity.Text) + CType(Eqbalance, Decimal)
            End With
            Prop_Ledger.save()

            btnSave.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            ' multiviewselected()
        End If

        loadBookLedger()
        'End If
    End Sub
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "BOOK"
        cell.ColumnSpan = 3
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.Text = "DEBIT"
        row.Controls.Add(cell)


        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.Text = "CREDIT"
        row.Controls.Add(cell)


        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.Text = "BALANCE"
        row.Controls.Add(cell)

        row.BackColor = ColorTranslator.FromHtml("WHITE")
        row.ForeColor = ColorTranslator.FromHtml("BLACK")
        grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)
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

    Public Sub loadBookLedger()
        'btnEquipmentLedger.CssClass = "Clicked"
        'btnequipmentrepairs.CssClass = "Initial"
        'btnequipmentattachdoc.CssClass = "Initial"
        'Me.mvledger.SetActiveView(Me.vwledger)

        Dim dtAccount As New DataTable
        Dim itemid As String
        'If 

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "' order by dDate", CommandType.Text)
        If hdnItemNo.Value = "" Then
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)
        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
        End If
        ' dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If dtAccount.Rows.Count > 0 Then
            btnSave.Text = "EDIT"
        Else
            btnSave.Text = "SAVE"
            ClearInformation()
        End If


        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
    End Sub
    Public Sub ClearInformation()
        txtBookClassification.Text = ""
        txtBookClassificationCode.Text = ""
        txtbookTitle.Text = ""
        txtBookPublicationDate.Text = ""

        txtbookQuantity.Text = ""
        txtBookPrice.Text = ""
        txtBookISBN.Text = ""
        txtbookAuthor.Text = ""
        txtbookAcqDate.Text = ""
        txtbookAcqCost.Text = ""
        txtbookdepreciatedRate.Text = ""
        txtbookdepreciatedvalue.Text = ""
        txtbookMarketValue.Text = ""
        txtNoYears.Text = ""
        txtbookUsefulLife.Text = ""
        txtbookSalvageValue.Text = ""
        txtbookRoom.Text = ""
        txtbookBay.Text = ""
        txtbookShelves.Text = ""
        txtbookColumn.Text = ""
        txtbookRack.Text = ""
        txtbookFloor.Text = ""
        txtbookBin.Text = ""
        For Each tb As TextBox In Me.Controls.OfType(Of TextBox)()
            tb.Text = ""
        Next


    End Sub

    Protected Sub drpbookName_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' 1) Discard old in-memory table so we don’t mix with the new item
        ViewState("Customers") = Nothing

        ' 2) Load item-specific info (e.g. book details) into text fields
        loadInformation_from_drpName()

        ' 3) Load ledger for this newly selected item
        loadBookLedger()

        ' 4) Now re-load DB property rows for the newly selected item
        LoadExistingPropertyRowsIntoViewState()

        ' 5) Finally, bind the grid to show what’s in memory (old DB data, if any)
        BindGrid()
    End Sub

    Function Depreciation() As Double
        dbAcquisitionCost = txtbookAcqCost.Text
        Dim dbSalvageValue As Double
        dbSalvageValue = dbAcquisitionCost * 0.05
        txtbookSalvageValue.Text = dbSalvageValue.ToString("n2")

        If txtbookAcqCost.Text <> "" And txtbookUsefulLife.Text <> "" Then
            'Depreciation
            Dim dbDepreciation As Double
            dbDepreciation = Val(dbAcquisitionCost - dbSalvageValue) / Val(txtbookUsefulLife.Text)
            txtBookDepreciation.Text = dbDepreciation.ToString("n2")
            'End Depreciation

            'Depreciated
            Dim dbDepreciated As Double
            dbDepreciated = dbAcquisitionCost - (dbDepreciation * Val(txtNoYears.Text))
            txtbookdepreciatedvalue.Text = dbDepreciated.ToString("n2")
            'end Depreciated
        Else

        End If
        Return True
    End Function
    Protected Sub txtbookAcqCost_TextChanged(sender As Object, e As EventArgs) Handles txtbookAcqCost.TextChanged

    End Sub
    Protected Sub txtbookAcqDate_TextChanged(sender As Object, e As EventArgs) Handles txtbookAcqDate.TextChanged

    End Sub
    Protected Sub txtbookUsefulLife_TextChanged(sender As Object, e As EventArgs) Handles txtbookUsefulLife.TextChanged

    End Sub
    Protected Sub txtbookSalvageValue_TextChanged(sender As Object, e As EventArgs) Handles txtbookSalvageValue.TextChanged

    End Sub
    Private Function DecryptEncrypt(ByVal TheText As String) As String
        Dim tempChar As String = Nothing
        Dim i As Integer = 0
        For i = 1 To TheText.Length
            If Convert.ToInt32(TheText.Chars(i - 1)) < 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) + 100)
            ElseIf Convert.ToInt32(TheText.Chars(i - 1)) > 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) - 100)
            End If
            TheText = TheText.Remove(i - 1, 1).Insert(i - 1, (CChar(ChrW(tempChar))).ToString())
        Next i
        Return TheText

    End Function
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ModalPopupExtender1.Hide()
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else
            btnSave.Text = "UPDATE"
        End If
    End Sub



    Protected Sub txtPropertyNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim text As TextBox

        'For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
        '    text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPropertyNo"), TextBox)
        '    Dim dt As New DataTable
        '    dt = objDerived.GetDataTable("SELECT a.Item_ID, b.PropertyNo FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID WHERE  (b.PropertyNo = '" & text.Text & "')", CommandType.Text)
        '    If dt.Rows.Count > 0 Then
        '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is already exist!")
        '        text.Text = ""
        '    Else

        '    End If
        'Next
        'ModalPopupExtender2.Show()

        Dim text As TextBox
        If btnSave.Text = "SAVE" Then

            For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPropertyNo"), TextBox)
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT a.Item_ID, b.PropertyNo FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID WHERE  (b.PropertyNo = '" & text.Text & "')", CommandType.Text)
                If dt.Rows.Count > 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is already exist!")
                    text.Text = ""
                Else

                End If
            Next
        ElseIf btnSave.Text = "EDIT" Then

            Dim dt1 As DataTable = objDerived.GetDataTable("SELECT b.PropertyNo,a.Property_ID,b.PropertyDetai_ID FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            For i As Integer = dt1.Rows.Count To grdPropertyInfo.Rows.Count - 1
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPropertyNo"), TextBox)
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT a.Item_ID, b.PropertyNo FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID WHERE  (b.PropertyNo = '" & text.Text & "')", CommandType.Text)
                If dt.Rows.Count > 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is already exist!")
                    text.Text = ""
                Else

                End If
            Next
        End If
        ModalPopupExtender2.Show()
    End Sub
End Class
