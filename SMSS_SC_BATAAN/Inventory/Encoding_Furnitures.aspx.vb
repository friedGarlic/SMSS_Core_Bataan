Imports System.Data
Imports System.Drawing
Partial Class Inventory_Encoding_Furnitures
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim objx As New AccessRule
    Dim counts As Integer = 0
    Private objFurnitureInfo As New ConsolidatedPropertySaving.TbFurniture_Info
    Private objFurnitureDtl As New ConsolidatedPropertySaving.TbFurniture_Dtl
    Protected Sub Inventory_Encoding_Furnitures_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' If txtDate is empty, set a default
            If String.IsNullOrWhiteSpace(txtDate.Text) Then
                txtDate.Text = DateTime.Now.ToString("MM-dd-yyyy")
            End If

            ' Then call your existing logic
            If drpName.Text = "" Then
                loadFurnitureFixture()
            End If

            LoadExistingPropertyRowsIntoViewState()
            BindGrid()
        End If
    End Sub


    Public Sub loadFurnitureFixture()
        Dim Classification As String
        Classification = objDerived.GetValue("select [ClassificationId] From [dbo].[tbl_Classification] where [ClassificationName] like 'Furniture%'", CommandType.Text)

        Dim itemdesc As New DataTable
        Dim dtitemdesc As New DataTable
        dtitemdesc = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_v2.1_03302023] " & Classification, CommandType.Text)
        drpName.datasource = dtitemdesc
        drpName.DataTextField = ("ItemDescription")
        drpName.DataValueField = ("Item_ID")
        drpName.DataBind()
        drpName.enabled = True
        loadEquipmentInformation_from_drpName()
        '  loadEquipmentList()
        loadEquipmentLedger()
    End Sub
    Protected Sub drpName_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' 1) Load data from your existing logic
        loadNames()       ' sets hdnItemNo.Value, etc.
        loadEquipmentLedger()

        ' 2) Reset memory table & re-load from DB
        ViewState("Customers") = Nothing
        LoadExistingPropertyRowsIntoViewState()
        BindGrid()
    End Sub


    Private Sub UpdateGridDataFromUserInput()
        If grdPropertyInfo.Rows.Count = 0 Then Exit Sub

        Dim dt As DataTable = TryCast(ViewState("Customers"), DataTable)
        If dt Is Nothing Then Exit Sub

        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            Dim row As GridViewRow = grdPropertyInfo.Rows(i)
            If row.RowType = DataControlRowType.DataRow Then
                Dim txtPropNo As TextBox = CType(row.FindControl("txtPropertyNo"), TextBox)
                Dim txtSerial As TextBox = CType(row.FindControl("txtSerialNumber"), TextBox)
                Dim drpBuilding As DropDownList = CType(row.FindControl("drpInstalledAtFurNiture"), DropDownList)
                Dim txtLocation As TextBox = CType(row.FindControl("txtPIFloorLocation"), TextBox)

                ' Store the user input back into dt
                If i < dt.Rows.Count Then
                    dt.Rows(i)("PropertyNo") = txtPropNo.Text.Trim()
                    dt.Rows(i)("SerialNo") = txtSerial.Text.Trim()
                    dt.Rows(i)("BuildingId") = If(drpBuilding.SelectedItem.Text = "N/A" OrElse drpBuilding.SelectedItem.Text = "Field", 0, CInt(drpBuilding.SelectedValue))
                    dt.Rows(i)("Location") = txtLocation.Text.Trim()
                End If
            End If
        Next
        ViewState("Customers") = dt
    End Sub




    Protected Sub loadNames()
        Dim CYear As String = "CY" & Year(txtDate.Text)
        Dim itemid As String
        If drpName.Text = "" Then
            itemid = "0"
        Else
            itemid = drpName.SelectedValue
        End If
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadEquipDTL()
        Else
            txtequipmentdesciption.Text = dt.Rows(0).Item("description").ToString
            hdnItemNo.Value = itemid

            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("[AMS].[sp_View_Encoding] 'Furnitures','" & itemid & "'", CommandType.Text)
            If dt1.Rows.Count > 0 Then
                txtequipmentdesciption.Text = dt1.Rows(0).Item("Description").ToString
                txtequipmentSerialNumber.Text = dt1.Rows(0).Item("SerialNo").ToString
                drpInstalledAtBuilding.SelectedValue = dt1.Rows(0).Item("BuildingId").ToString
                drpUnit.SelectedValue = dt1.Rows(0).Item("Unit_ID").ToString
                txtQuantity.Text = dt1.Rows(0).Item("DebitQty").ToString
                txtequipmentdimension.Text = dt1.Rows(0).Item("Dimension").ToString
                txtequipmentmodel.Text = dt1.Rows(0).Item("Model").ToString
                txtequipmentwaranty.Text = dt1.Rows(0).Item("Warranty").ToString
                txtEAcqDate.Text = Convert.ToDateTime(dt1.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
                txtEAcqCost.Text = CDec(dt1.Rows(0).Item("Cost").ToString).ToString("N2")
                lblequipmentdepreciatedRate.Text = dt1.Rows(0).Item("DepreciationRate").ToString
                txtequipmentdepreciatedvalue.Text = CDec(dt1.Rows(0).Item("DepreciationValue").ToString).ToString("N2")
                txtEMarketValue.Text = CDec(dt1.Rows(0).Item("MarketValue").ToString).ToString("N2")
                txtNoYears.Text = dt1.Rows(0).Item("NoYears").ToString
                txtUsefulLife.Text = dt1.Rows(0).Item("UsefulLife").ToString
                txtSalvageValue.Text = Val(dt1.Rows(0).Item("SalvageValue").ToString).ToString("N2")


                hf_FurInfoId.Value = dt1.Rows(0).Item("FurnitureInfoId").ToString
                hf_FurId.Value = dt1.Rows(0).Item("FurnitureId").ToString
                hf_PropertyDetai_ID.Value = dt1.Rows(0).Item("PropertyDetai_ID").ToString
                hf_Property_ID.Value = dt1.Rows(0).Item("Property_ID").ToString
                hf_Item_ID.Value = dt1.Rows(0).Item("Item_ID").ToString
            Else

                Dim textBoxList As New List(Of TextBox) From {
                         txtequipmentdesciption,
                        txtequipmentSerialNumber,
                        txtQuantity,
                        txtequipmentdimension,
                        txtequipmentmodel,
                        txtequipmentwaranty,
                        txtEAcqDate,
                        txtEAcqCost,
                        lblequipmentdepreciatedRate,
                        txtequipmentdepreciatedvalue,
                        txtEMarketValue,
                        txtNoYears,
                        txtUsefulLife,
                        txtSalvageValue
                    }

                For Each textBox As TextBox In textBoxList
                    textBox.Text = ""
                Next

            End If


        End If
        btnSave.Enabled = True
        btnCancel.Enabled = True


        Dim dt12 As New datatable
        dt12 = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & itemid, CommandType.Text)

        If dt.Rows.Count = 0 Then
            LoadEquipDTL()
        Else
            txtequipmentdesciption.Text = dt12.Rows(0).Item("description").ToString
        End If


    End Sub
    Protected Sub loadEquipmentInformation_from_drpName()
        Dim CYear As String = "CY" & Year(txtDate.Text)
        Dim itemid As String

        loadUnit()
        LoadBuildings()
        loadwarehouse()
        If drpName.Text = "" Then
            itemid = "0"
        Else
            itemid = drpName.SelectedValue
        End If

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & itemid, CommandType.Text)

        If dt.Rows.Count = 0 Then
            LoadEquipDTL()
        Else
            hdnItemNo.Value = itemid
            hdnGAId.Value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
            txtName.Text = dt.Rows(0).Item("Name").ToString
            txtequipmentdesciption.Text = dt.Rows(0).Item("description").ToString
            txtequipmentpowerinput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtequipmentdimension.Text = objDerived.GetValue("select e.Dimension from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            'txtequipmentareacapacity.Text = objDerived.GetValue("select e.AreaCapacity from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtequipmentmodel.Text = objDerived.GetValue("select e.Model from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtequipmentwaranty.Text = objDerived.GetValue("select e.Warranty from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtSpecification.Text = objDerived.GetValue("select e.Specification from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtEAcqDate.Text = objDerived.GetValue("select c.Property_Date from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtEAcqCost.Text = objDerived.GetValue("select c.Cost from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtEMarketValue.Text = dt.Rows(0).Item(CYear).ToString
            'Dim DA As DateTime
            'DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")

            txtNoYears.Text = " "
            txtequipmentdepreciatedvalue.Text = FormatNumber(0, 2)
            lblequipmentdepreciatedRate.Text = " "
            lblequipmentdepreciatedRate.ReadOnly = False



            '''--------------------location
            Dim location As String
            location = objDerived.GetValue("select Location from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Dtl  as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
            If location IsNot Nothing Then
                Dim locationsplit As String() = location.Split("-")
                If location.Contains("Bay") Then
                    txtEquipmentBay.Text = locationsplit(1)
                ElseIf location.Contains("Column") Then
                    txtEquipmentColumn.Text = locationsplit(1)
                ElseIf location.Contains("Floor") Then
                    txtEquipmentFloor.Text = locationsplit(1)
                ElseIf location.Contains("Room") Then
                    txtEquipmentRoom.Text = locationsplit(1)
                ElseIf location.Contains("Shelves") Then
                    txtEquipmentShelves.Text = locationsplit(1)
                ElseIf location.Contains("Rack") Then
                    txtEquipmentRack.Text = locationsplit(1)
                ElseIf location.Contains("Bin") Then
                    txtEquipmentBin.Text = locationsplit(1)
                End If

                Dim warehouse As String
                warehouse = objDerived.GetValue("select warehouseid from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Dtl  as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

                drpEquipmentWarehouse.SelectedValue = warehouse


                Dim dt1 As New DataTable
                dt1 = objDerived.GetDataTable("[AMS].[sp_View_Encoding] 'Furnitures','" & itemid & "'", CommandType.Text)
                If dt1.Rows.Count > 0 Then
                    txtequipmentdesciption.Text = dt1.Rows(0).Item("Description").ToString
                    txtequipmentSerialNumber.Text = dt1.Rows(0).Item("SerialNo").ToString
                    drpInstalledAtBuilding.SelectedValue = dt1.Rows(0).Item("BuildingId").ToString
                    drpUnit.SelectedValue = dt1.Rows(0).Item("Unit_ID").ToString
                    txtQuantity.Text = dt1.Rows(0).Item("DebitQty").ToString
                    txtequipmentdimension.Text = dt1.Rows(0).Item("Dimension").ToString
                    txtequipmentmodel.Text = dt1.Rows(0).Item("Model").ToString
                    txtequipmentwaranty.Text = dt1.Rows(0).Item("Warranty").ToString
                    txtEAcqDate.Text = dt1.Rows(0).Item("Property_Date").ToString
                    txtEAcqCost.Text = dt1.Rows(0).Item("Cost").ToString
                    lblequipmentdepreciatedRate.Text = dt1.Rows(0).Item("DepreciationRate").ToString
                    txtequipmentdepreciatedvalue.Text = dt1.Rows(0).Item("DepreciationValue").ToString
                    txtEMarketValue.Text = dt1.Rows(0).Item("MarketValue").ToString
                    txtNoYears.Text = dt1.Rows(0).Item("NoYears").ToString
                    txtUsefulLife.Text = dt1.Rows(0).Item("UsefulLife").ToString
                    txtSalvageValue.Text = dt1.Rows(0).Item("SalvageValue").ToString


                    hf_FurInfoId.Value = dt1.Rows(0).Item("FurnitureInfoId").ToString
                    hf_FurId.Value = dt1.Rows(0).Item("FurnitureId").ToString
                    hf_PropertyDetai_ID.Value = dt1.Rows(0).Item("PropertyDetai_ID").ToString
                    hf_Property_ID.Value = dt1.Rows(0).Item("Property_ID").ToString
                    hf_Item_ID.Value = dt1.Rows(0).Item("Item_ID").ToString
                End If




                drpUnit.Items.FindByValue(dt.Rows(0).Item(9)).Selected = True
                btnSave.Enabled = True
                btnCancel.Enabled = True

            End If
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

    Public Sub LoadBuildings()
        Dim dt As New datatable
        dt = objDerived.getdatatable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", commandtype.text)
        drpInstalledAtBuilding.datasource = dt
        drpInstalledAtBuilding.DataTextField = ("Name")
        drpInstalledAtBuilding.DataValueField = ("BuildingId")
        drpInstalledAtBuilding.DataBind()
        drpInstalledAtBuilding.Items.Insert(0, New ListItem("N/A"))
    End Sub

    Protected Sub LoadEquipDTL()

        For Each control As Control In Me.Controls
            If TypeOf control Is TextBox Then
                DirectCast(control, TextBox).Text = String.Empty
            ElseIf TypeOf control Is DropDownList Then
                DirectCast(control, DropDownList).ClearSelection()
            End If
        Next

    End Sub



    Protected Sub OnDataBound(sender As Object, e As EventArgs)


        'Optimize code using chat gpt
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        row.BackColor = Color.White
        row.ForeColor = Color.Black

        Dim cell As TableHeaderCell

        cell = New TableHeaderCell()
        cell.Text = "FURNITURE & FIXTURES"
        cell.ColumnSpan = 3
        row.Cells.Add(cell)

        For i As Integer = 1 To 3
            cell = New TableHeaderCell()
            cell.ColumnSpan = 2
            cell.Text = If(i = 1, "DEBIT", If(i = 2, "CREDIT", "BALANCE"))
            row.Cells.Add(cell)
        Next

        grdLedger1.Controls(0).Controls.AddAt(0, row)
    End Sub
    Protected Sub grdLedger1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtAccount As New DataTable
        If hdnItemNo.value = "" Then
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)

        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
        End If
        grdLedger1.PageIndex = e.NewPageIndex
        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
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
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
        End If
        ' dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)


        If dtAccount.Rows.Count > 0 Then
            btnSave.Text = "EDIT"
        Else
            btnSave.Text = "SAVE"
        End If

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))

        Else

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

    Public Sub SAVE()

        UpdateGridDataFromUserInput()
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

        ' 2) Check each row in memory for valid property info
        Dim dt As DataTable = TryCast(ViewState("Customers"), DataTable)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No property records found!")
            Return
        End If

        For Each row As DataRow In dt.Rows
            If String.IsNullOrEmpty(row("PropertyNo").ToString()) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill Up the PropertyNo fields")
                Return
            End If

        Next

        'If txtName.Text = "" Or txtequipmentdesciption.Text = "" Or txtUsefulLife.Text = "" Or lblequipmentdepreciatedRate.Text = "" Or txtEAcqCost.Text = "" Or txtequipmentdepreciatedvalue.Text = "" Or txtSalvageValue.Text = "" Or txtEMarketValue.Text = "" Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
        'Else
        If Not IsNumeric(lblequipmentdepreciatedRate.Text) Or Not IsNumeric(txtEAcqCost.Text) Or Not IsNumeric(txtequipmentdepreciatedvalue.Text) Or Not IsNumeric(txtSalvageValue.Text) Or Not IsNumeric(txtEMarketValue.Text) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
        Else
            objDerived.Execute("Update dbo.m_item set unit_id = " & drpUnit.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)





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
                .Qty = txtQuantity.Text
                .Balance = txtQuantity.Text
                .Cost = CType(txtEAcqCost.Text, Decimal)
                .Item_ID = hdnItemNo.Value
                .Property_code = objDerived.GetValue("select ga_code2 from [AMS].[vw_item_master_list] where Item_ID ='" & hdnItemNo.Value & "' ", CommandType.Text)
                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .Function_ID = 86
                .TD_ID = 1
                .Project_ID = 0
                .Program_id = 0
                .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
            End With

            Dim PropHdr_ID As Integer = 0
            PropHdr_ID = Prop_Hdr.save()

            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

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
                    .InspectionDate = txtEAcqDate.Text
                    .F_ID = 1
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                    .Barcode = " "
                    .Amount = CType(txtEAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    .Details = txtSpecification.Text
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                    Session("dep") = CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).Text

                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = Prop_Dtl.save()

                objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtEMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

                Dim info_id As Integer

                With objFurnitureInfo
                    .FurnitureInfoId = 0
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = PropDtl_ID
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text ' txtequipmentSerialNumber.Text 
                    .Name = txtName.Text
                    .Description = txtequipmentdesciption.Text
                    .DepreciationRate = lblequipmentdepreciatedRate.Text
                    .Dimension = txtequipmentdimension.Text
                    .AreaCapacity = ""
                    .Model = txtequipmentmodel.Text
                    .Warranty = txtequipmentwaranty.Text
                    .DepreciationValue = txtequipmentdepreciatedvalue.Text
                    .Specification = txtSpecification.Text
                    .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                    .RoomLocation = ""
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .SalvalgeValue = txtSalvageValue.Text
                    .AccountablePerson = ""

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
                    .Location = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text
                    .Status = "Accepted"
                    .PowerInput = txtequipmentpowerinput.Text
                    Dim drp As DropDownList
                    drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtFurNiture"), DropDownList)
                    If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                        .BuildingId = 0
                    Else
                        .BuildingId = drp.SelectedValue
                    End If

                    .MaintenanceContractor = ""
                    .MaintenanceContactPerson = ""
                    .MaintenanceContactNo = ""
                    .NoYears = txtNoYears.Text
                    .UsefulLife = txtUsefulLife.Text
                End With
                objFurnitureDtl.save()


            Next

            Dim Prop_Ledger As New t_PropertyLedger

            With Prop_Ledger
                .Ledger_ID = 0
                .PropertyNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                .SerialNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                .Trans_Type = "Manual Entry"
                .dDate = txtEAcqDate.Text
                .Ref = ""
                .AccountablePerson = ""
                .Department = 0
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = hdnItemNo.Value
                .DebitQty = txtQuantity.Text
                .DebitCost = txtQuantity.Text * CType(txtEAcqCost.Text, Decimal)
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
                ' .BalanceQty = Eqty + txtQuantity.Text
                .BalanceQty = txtQuantity.Text
                .BalanceCost = CType(txtEAcqCost.Text, Decimal) + CType(Eqbalance, Decimal)
            End With
            Prop_Ledger.save()



            ''btnSave.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            '  multiviewselected()
            ' loadEquipmentList()
            '  loadEquipmentInformation()
            loadEquipmentInformation_from_drpName()
            loadEquipmentLedger()
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
            UPDATE()
        End If

    End Sub
    Public Sub UPDATE()
        Try
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            objDerived.cmd.Parameters.AddWithValue("@FurnitureInfoId", hf_FurInfoId.Value)
            objDerived.cmd.Parameters.AddWithValue("@Name", txtName.Text)
            objDerived.cmd.Parameters.AddWithValue("@Description", txtequipmentdesciption.Text)
            objDerived.cmd.Parameters.AddWithValue("@SerialNo", txtequipmentSerialNumber.Text)
            objDerived.cmd.Parameters.AddWithValue("@Dimension", txtequipmentdimension.Text)
            objDerived.cmd.Parameters.AddWithValue("@Model", txtequipmentmodel.Text)
            objDerived.cmd.Parameters.AddWithValue("@Warranty", txtequipmentwaranty.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", lblequipmentdepreciatedRate.Text)
            objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtequipmentdepreciatedvalue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtSalvageValue.Text.Replace(",", ""))


            objDerived.cmd.Parameters.AddWithValue("@Property_ID", hf_Property_ID.Value)
            objDerived.cmd.Parameters.AddWithValue("@Property_code", txtequipmentSerialNumber.Text)
            objDerived.cmd.Parameters.AddWithValue("@Qty", txtQuantity.Text)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtEAcqDate.Text)
            objDerived.cmd.Parameters.AddWithValue("@Cost", txtEAcqCost.Text.Replace(",", ""))

            objDerived.cmd.Parameters.AddWithValue("@FurnitureId", hf_FurId.Value)
            objDerived.cmd.Parameters.AddWithValue("@BuildingId", drpInstalledAtBuilding.SelectedItem.Value) ''FOllow uo
            objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtEMarketValue.Text.Replace(",", ""))
            objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtUsefulLife.Text)


            objDerived.cmd.Parameters.AddWithValue("@Item_ID", hf_Item_ID.Value)
            objDerived.cmd.Parameters.AddWithValue("@Unit_ID", drpUnit.SelectedItem.Value) ''FOllow uo

            objDerived.Execute("AMS.sp_Edit_Furnitures_Fixes_07212022", CommandType.StoredProcedure)
            ''here 11
            'MsgBox(hdnItemNo.Value)
            Dim dt1 As DataTable = objDerived.GetDataTable("SELECT AMS.Property_Dtl.PropertyNo, AMS.Property_Dtl.SerialNo, AMS.TbFurniture_Dtl.BuildingId, AMS.TbFurniture_Dtl.Location, AMS.Property.Property_ID,AMS.Property_Dtl.PropertyDetai_ID " &
                                                           " FROM  AMS.Property INNER JOIN  " &
                                                           " AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID INNER JOIN  " &
                                                           " AMS.TbFurniture_Info ON AMS.Property_Dtl.PropertyDetai_ID = AMS.TbFurniture_Info.Property_Dtl_ID INNER JOIN  " &
                                                           " AMS.TbFurniture_Dtl ON AMS.TbFurniture_Info.FurnitureInfoId = AMS.TbFurniture_Dtl.FurnitureInfoId  " &
                                                           " where ams.property.Item_ID =" & hdnItemNo.Value, CommandType.Text)



            For i As Integer = 0 To dt1.Rows.Count - 1
                objDerived.GetRecords("UPDATE AMS.Property_Dtl SET PropertyNo = '" _
                                                                                            & CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text &
                                                                             "',SerialNo='" & CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text &
                                                                             "' WHERE PropertyNo = '" & dt1.Rows(i).Item("PropertyNo").ToString & "'", CommandType.Text)







                Dim drp As DropDownList
                Dim drpval As Integer

                drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtFurNiture"), DropDownList)

                If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                    drpval = 0
                Else
                    drpval = drp.SelectedValue
                End If

                objDerived.GetRecords("UPDATE AMS.TbFurniture_Dtl SET BuildingId = '" & drpval & "', Location='" & CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text & "' WHERE Property_Dtl_ID = '" & dt1.Rows(i).Item("PropertyDetai_ID").ToString & "'", CommandType.Text)

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
                    .InspectionDate = txtEAcqDate.Text
                    .F_ID = 1
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                    .Barcode = " "
                    .Amount = CType(txtEAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    .Details = txtSpecification.Text
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                    Session("dep") = CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).Text

                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = Prop_Dtl.save()

                objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtEMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

                Dim info_id As Integer

                With objFurnitureInfo
                    .FurnitureInfoId = 0
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = PropDtl_ID
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text ' txtequipmentSerialNumber.Text 
                    .Name = txtName.Text
                    .Description = txtequipmentdesciption.Text
                    .DepreciationRate = lblequipmentdepreciatedRate.Text
                    .Dimension = txtequipmentdimension.Text
                    .AreaCapacity = ""
                    .Model = txtequipmentmodel.Text
                    .Warranty = txtequipmentwaranty.Text
                    .DepreciationValue = txtequipmentdepreciatedvalue.Text
                    .Specification = txtSpecification.Text
                    .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                    .RoomLocation = ""
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .SalvalgeValue = txtSalvageValue.Text
                    .AccountablePerson = ""

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
                    .Location = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text
                    .Status = "Accepted"
                    .PowerInput = txtequipmentpowerinput.Text
                    Dim drp As DropDownList
                    drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtFurNiture"), DropDownList)
                    If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                        .BuildingId = 0
                    Else
                        .BuildingId = drp.SelectedValue
                    End If

                    .MaintenanceContractor = ""
                    .MaintenanceContactPerson = ""
                    .MaintenanceContactNo = ""
                    .NoYears = txtNoYears.Text
                    .UsefulLife = txtUsefulLife.Text
                End With
                objFurnitureDtl.save()


            Next



            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub loadwarehouse()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("select warehouse_id,wname From ams.loc_warehouse", CommandType.Text)
        drpEquipmentWarehouse.DataTextField = ("wname")
        drpEquipmentWarehouse.DataValueField = ("warehouse_id")
        drpEquipmentWarehouse.datasource = dt
        drpEquipmentWarehouse.databind()

    End Sub


    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)
        ' 1) Harvest current typed data
        UpdateGridDataFromUserInput()

        ' 2) Retrieve or create the DataTable
        Dim dt As DataTable
        If ViewState("Customers") IsNot Nothing Then
            dt = DirectCast(ViewState("Customers"), DataTable)
        Else
            dt = New DataTable()
            dt.Columns.Add("PropertyNo", GetType(String))
            dt.Columns.Add("SerialNo", GetType(String))
            dt.Columns.Add("BuildingId", GetType(Integer))
            dt.Columns.Add("Location", GetType(String))
        End If

        ' 3) Check user input for Quantity
        If String.IsNullOrWhiteSpace(txtQuantity.Text) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
            Return
        End If

        Dim desiredQty As Integer
        If Not Integer.TryParse(txtQuantity.Text.Trim(), desiredQty) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Quantity.")
            Return
        End If

        ' 4) If user wants more rows than we have, add blank
        While dt.Rows.Count < desiredQty
            Dim newRow As DataRow = dt.NewRow()
            newRow("PropertyNo") = ""
            newRow("SerialNo") = ""
            newRow("BuildingId") = 0
            newRow("Location") = ""
            dt.Rows.Add(newRow)
        End While

        ' (Optional) If user wants fewer rows, remove extras
        While dt.Rows.Count > desiredQty
            dt.Rows.RemoveAt(dt.Rows.Count - 1)
        End While

        ' 5) Save dt back to ViewState
        ViewState("Customers") = dt

        ' 6) Re-bind
        BindGrid()

        ' 7) Show modal
        ModalPopupExtender2.Show()
    End Sub

    Protected Sub BindGrid()
        Dim dt As DataTable = TryCast(ViewState("Customers"), DataTable)
        grdPropertyInfo.DataSource = dt
        grdPropertyInfo.DataBind()
    End Sub

    Protected Sub Insert(sender As Object, e As EventArgs)

    End Sub

    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Populate your drpInstalledAtFurNiture from DB
            Dim drpBuilding As DropDownList = CType(e.Row.FindControl("drpInstalledAtFurNiture"), DropDownList)
            drpBuilding.DataSource = objDerived.GetDataTable(
            "SELECT BuildingId, BuildingName + ' - ' + Address as Name " &
            "FROM ams.TbBuilding_Dtl " &
            "ORDER BY BuildingName", CommandType.Text)

            drpBuilding.DataTextField = "Name"
            drpBuilding.DataValueField = "BuildingId"
            drpBuilding.DataBind()

            drpBuilding.Items.Insert(0, New ListItem("Field"))
            drpBuilding.Items.Insert(1, New ListItem("N/A"))

            ' Now fill from memory:
            Dim dtMemory As DataTable = TryCast(grdPropertyInfo.DataSource, DataTable)
            If dtMemory IsNot Nothing AndAlso e.Row.RowIndex < dtMemory.Rows.Count Then
                Dim rowData As DataRow = dtMemory.Rows(e.Row.RowIndex)

                Dim txtPropNo As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
                Dim txtSerial As TextBox = CType(e.Row.FindControl("txtSerialNumber"), TextBox)
                Dim txtLoc As TextBox = CType(e.Row.FindControl("txtPIFloorLocation"), TextBox)

                txtPropNo.Text = rowData("PropertyNo").ToString()
                txtSerial.Text = rowData("SerialNo").ToString()
                txtLoc.Text = rowData("Location").ToString()

                Dim buildingIdStr As String = rowData("BuildingId").ToString()
                If Not String.IsNullOrEmpty(buildingIdStr) AndAlso buildingIdStr <> "0" Then
                    ' Attempt to select the building
                    If drpBuilding.Items.FindByValue(buildingIdStr) IsNot Nothing Then
                        drpBuilding.SelectedValue = buildingIdStr
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        ' 1) Harvest typed changes
        UpdateGridDataFromUserInput()

        ' 2) Optionally re-bind to confirm changes
        BindGrid()

        ' 3) Hide the modal
        ModalPopupExtender2.Hide()
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
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        For Each row As GridViewRow In grdPropertyInfo.Rows

            Dim _str As String = TryCast(row.FindControl("txtPropertyNo"), textbox).Text
            ' msgbox(_str)
        Next
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
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ModalPopupExtender1.Hide()
    End Sub
    Protected Sub drpInstalledAtMac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim drp As DropDownList
        Dim text As TextBox
        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtFurNiture"), DropDownList)
            If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = True
                text.Text = ""
            Else
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = False

                Dim drp1 As DropDownList
                drp1 = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtFurNiture"), DropDownList)

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("select (case when Address IS NULL then '' else Address end) + " _
                                             & " (case when Barangay IS NULL then  '' else ', ' + Barangay end) + " _
                                             & "  (case when Area1 IS NULL then  '' else  ', ' + Area1 end) " _
                                             & "  as Adress from AMS.TbBuilding_Dtl where BuildingId=" & drp1.SelectedValue & "", CommandType.Text)
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

            Dim dt1 As DataTable = objDerived.GetDataTable("SELECT AMS.Property_Dtl.PropertyNo, AMS.Property_Dtl.SerialNo, AMS.TbFurniture_Dtl.BuildingId, AMS.TbFurniture_Dtl.Location, AMS.Property.Property_ID " &
                                                           " FROM  AMS.Property INNER JOIN  " &
                                                           " AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID INNER JOIN  " &
                                                           " AMS.TbFurniture_Info ON AMS.Property_Dtl.PropertyDetai_ID = AMS.TbFurniture_Info.Property_Dtl_ID INNER JOIN  " &
                                                           " AMS.TbFurniture_Dtl ON AMS.TbFurniture_Info.FurnitureInfoId = AMS.TbFurniture_Dtl.FurnitureInfoId  " &
                                                           " where ams.property.Item_ID =" & hdnItemNo.Value, CommandType.Text)

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

    Private Sub LoadExistingPropertyRowsIntoViewState()
        ' 1) Determine the item ID
        Dim itemId As String = hdnItemNo.Value
        If String.IsNullOrEmpty(itemId) Then
            itemId = "0"
        End If

        ' 2) Query the DB for existing property rows
        '    (Properties that belong to this item)
        Dim dtFromDB As DataTable = objDerived.GetDataTable(
        "SELECT " & vbCrLf &
        "   AMS.Property_Dtl.PropertyNo, " & vbCrLf &
        "   AMS.Property_Dtl.SerialNo, " & vbCrLf &
        "   AMS.TbFurniture_Dtl.BuildingId, " & vbCrLf &
        "   AMS.TbFurniture_Dtl.Location, " & vbCrLf &
        "   AMS.Property.Property_ID " & vbCrLf &
        "FROM AMS.Property " & vbCrLf &
        "INNER JOIN AMS.Property_Dtl " & vbCrLf &
        "   ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID " & vbCrLf &
        "INNER JOIN AMS.TbFurniture_Info " & vbCrLf &
        "   ON AMS.Property_Dtl.PropertyDetai_ID = AMS.TbFurniture_Info.Property_Dtl_ID " & vbCrLf &
        "INNER JOIN AMS.TbFurniture_Dtl " & vbCrLf &
        "   ON AMS.TbFurniture_Info.FurnitureInfoId = AMS.TbFurniture_Dtl.FurnitureInfoId " & vbCrLf &
        "WHERE AMS.Property.Item_ID = " & itemId, CommandType.Text)


        ' 3) Create a new in-memory DataTable for your Grid
        Dim dtMemory As New DataTable()
        dtMemory.Columns.Add("PropertyNo", GetType(String))
        dtMemory.Columns.Add("SerialNo", GetType(String))
        dtMemory.Columns.Add("BuildingId", GetType(Integer))
        dtMemory.Columns.Add("Location", GetType(String))
        ' Add more columns if needed (e.g. Department, FloorLocation, etc.)

        ' 4) Copy DB rows into dtMemory
        For Each dbRow As DataRow In dtFromDB.Rows
            Dim newRow As DataRow = dtMemory.NewRow()
            newRow("PropertyNo") = dbRow("PropertyNo").ToString()
            newRow("SerialNo") = dbRow("SerialNo").ToString()
            newRow("BuildingId") = If(IsDBNull(dbRow("BuildingId")), 0, dbRow("BuildingId"))
            newRow("Location") = dbRow("Location").ToString()
            dtMemory.Rows.Add(newRow)
        Next

        ' 5) Store dtMemory in ViewState
        ViewState("Customers") = dtMemory
    End Sub



End Class
