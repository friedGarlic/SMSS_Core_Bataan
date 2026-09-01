Imports System.Data

Partial Class Records_PropertyCard_Rev_Machinery
    Inherits System.Web.UI.UserControl

    Private objDerived As New DerivedDal ' Add this line to match your main page pattern

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindMachineryGrid()
            BindEquipmentGrid()
            ' Initialize with ledger view - this will now use stored procedure
            loadMachineryLedger()

            Session("GA_ID") = 0
            Session("SubClassificationID") = 0
        Else
            BindMachineryGrid()
            BindEquipmentGrid()
        End If
    End Sub


    ' ============================
    ' UPDATE REFRESH METHOD TO INCLUDE EQUIPMENT GRID
    ' ============================
    Public Sub RefreshGridData()
        BindMachineryGrid()

        If gvMachineryLocationList.SelectedIndex >= 0 Then
            BindEquipmentGrid()
        Else
            BindEmptyEquipmentGrid()
        End If

        ' Refresh the current view based on active tab
        If mvledger.GetActiveView().ID = "vwledger" Then
            BindLedgerGrid() ' This will now use the stored procedure
        ElseIf mvledger.GetActiveView().ID = "vwrepairsandmaintenance" Then
            BindRepairsGrid()
        ElseIf mvledger.GetActiveView().ID = "vwdocumentattachment" Then
            BindDocumentsGrid()
        End If
    End Sub

    Private Sub BindMachineryGrid()
        ' Get parameters from Session
        Dim subClass As String = If(Session("SubClassificationID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        ' Try to get data from stored procedure
        Dim dt As DataTable = GetMachineryData(subClass, gaId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ' Bind actual data
            gvMachineryLocationList.DataSource = dt
            gvMachineryLocationList.DataBind()
        Else
            ' Bind empty grid if no data
            BindEmptyMachineryGrid()
        End If
    End Sub

    Private Function GetMachineryData(ByVal subClassId As String, ByVal gaId As String) As DataTable
        Dim dt As New DataTable()

        Try
            ' Use the same pattern as your reference code
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_MAchinery_ListOfLocation] '" & subClassId & "', '" & gaId & "'"

            dt = objDerived.GetDataTable(sql, CommandType.Text)

        Catch ex As Exception
            ' Log error if needed - matching your reference pattern
            System.Diagnostics.Debug.WriteLine("Error loading machinery data: " & ex.Message)
            Return Nothing
        End Try

        Return dt
    End Function

    Private Sub BindEmptyMachineryGrid()
        Dim dt As DataTable = CreateMachineryTableSchema()

        ' Add 4 empty rows
        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        gvMachineryLocationList.DataSource = dt
        gvMachineryLocationList.DataBind()
    End Sub

    Private Function CreateMachineryTableSchema() As DataTable
        Dim dt As New DataTable()
        ' Core columns from reference gridview
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("item_particular_id", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("DeclaredOwner", GetType(String))
        dt.Columns.Add("Barangay", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Area", GetType(String))
        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))

        ' Original machinery columns (kept for future use)
        dt.Columns.Add("ItemDescription", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("Capacity", GetType(String))

        Return dt
    End Function

    ' ============================
    ' GRIDVIEW EVENT HANDLERS
    ' ============================

    Protected Sub gvMachineryLocationList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvMachineryLocationList.PageIndex = e.NewPageIndex
        ' Rebind with actual data on paging
        BindMachineryGrid()
    End Sub

    Protected Sub gvMachineryLocationList_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Handle row selection
        If gvMachineryLocationList.SelectedIndex >= 0 Then
            Dim selectedItemId As String = gvMachineryLocationList.SelectedDataKey("Item_ID")
            Session("Item_ID") = selectedItemId

            ' Refresh equipment grid when a row is selected in the main grid
            BindEquipmentGrid()


            Dim dt As DataTable = GetLedgerData(Nothing)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                'FormatBuildingLedgerTransType(dt)

                grdLedger.DataSource = dt
                grdLedger.DataBind()
            Else
                BindEmptyLedgerGrid()
            End If

        End If
    End Sub
    Protected Sub gvMachineryLocationList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        ' Make rows clickable for selection
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvMachineryLocationList, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub




    ' =================================== LIST OF MACHINERY ============================================================




    ' ============================
    ' EQUIPMENT LIST GRIDVIEW FUNCTIONS
    ' ============================

    Protected Sub btnMachineryPropSearch_Click(sender As Object, e As EventArgs)
        Dim searchText As String = txtMachineryPropSearch.Text.Trim()

        ' If no search value → show full list using existing logic
        If String.IsNullOrEmpty(searchText) Then
            AddTrace("Machinery Search: empty, loading full list.")
            BindEquipmentGrid()
            Exit Sub
        End If

        ' Replicate the same parameter logic used in BindEquipmentGrid
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        ' NOTE: adjust gvMachineryLocationList to your actual location grid ID if different
        If gvMachineryLocationList.SelectedIndex >= 0 Then
            itemParticularId = gvMachineryLocationList.DataKeys(gvMachineryLocationList.SelectedIndex).Values("item_particular_id").ToString()
            itemId = gvMachineryLocationList.DataKeys(gvMachineryLocationList.SelectedIndex).Values("Item_ID").ToString()
            declaredOwner = gvMachineryLocationList.DataKeys(gvMachineryLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
            barangay = gvMachineryLocationList.DataKeys(gvMachineryLocationList.SelectedIndex).Values("Barangay").ToString()
        End If

        AddTrace("Machinery Search: " & searchText &
             " | itemParticularId=" & itemParticularId &
             " | itemId=" & itemId &
             " | gaId=" & gaId &
             " | declaredOwner=" & declaredOwner &
             " | barangay=" & barangay)

        ' Get the same dataset that BindEquipmentGrid would bind
        Dim dt As DataTable = GetEquipmentData(itemParticularId, itemId, gaId, declaredOwner, barangay)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ' No data at all → show empty schema
            Dim emptyDt As DataTable = CreateEquipmentTableSchema() ' or your existing empty-bind helper
            grdlistofMachinery.DataSource = emptyDt
            grdlistofMachinery.DataBind()
            Exit Sub
        End If

        ' Filter by PropertyNo LIKE '%txtMachineryPropSearch%'
        Dim dv As New DataView(dt)

        ' Escape special characters for RowFilter
        Dim safeSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("]", "]]")

        dv.RowFilter = "PropertyNo LIKE '%" & safeSearch & "%'"

        If dv.Count > 0 Then
            grdlistofMachinery.DataSource = dv
            grdlistofMachinery.DataBind()
        Else
            ' If nothing matches the filter, bind empty grid
            Dim emptyDt As DataTable = CreateEquipmentTableSchema() ' same schema used by BindEmptyEquipmentGrid
            grdlistofMachinery.DataSource = emptyDt
            grdlistofMachinery.DataBind()
        End If
    End Sub


    Private Sub BindEquipmentGrid()
        ' Get parameters from Session - use Item_ID from selected row in the first grid
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        ' Get additional parameters from the first grid's selected row if available
        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        Try
            If gvMachineryLocationList.SelectedIndex >= 0 Then
                itemParticularId = gvMachineryLocationList.DataKeys(gvMachineryLocationList.SelectedIndex).Values("item_particular_id").ToString()
                itemId = gvMachineryLocationList.DataKeys(gvMachineryLocationList.SelectedIndex).Values("Item_ID").ToString()
                declaredOwner = gvMachineryLocationList.DataKeys(gvMachineryLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
                barangay = gvMachineryLocationList.DataKeys(gvMachineryLocationList.SelectedIndex).Values("Barangay").ToString()
            End If

            AddTrace("itemParticularId: " & itemParticularId)
            AddTrace("itemId: " & itemId)
            AddTrace("declaredOwner: " & declaredOwner)
            AddTrace("barangay: " & barangay)

            ' Try to get data from stored procedure
            Dim dt As DataTable = GetEquipmentData(itemParticularId, itemId, gaId, declaredOwner, barangay)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ' Bind actual data
                grdlistofMachinery.DataSource = dt
                grdlistofMachinery.DataBind()
            Else
                ' Bind empty grid if no data
                BindEmptyEquipmentGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetEquipmentData(ByVal itemParticularId As String, ByVal itemId As String, ByVal gaId As String, ByVal declaredOwner As String, ByVal barangay As String) As DataTable
        Dim dt As New DataTable()

        Try
            ' Use the same pattern as your reference code
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Machinery_ListOfEquipment] '" & itemParticularId & "', '" & itemId & "', '" & gaId & "', '" & declaredOwner & "', '" & barangay & "'"

            dt = objDerived.GetDataTable(sql, CommandType.Text)

        Catch ex As Exception
            ' Log error if needed - matching your reference pattern
            System.Diagnostics.Debug.WriteLine("Error loading equipment data: " & ex.Message)
            Return Nothing
        End Try

        Return dt
    End Function

    Private Sub BindEmptyEquipmentGrid()
        Dim dt As DataTable = CreateEquipmentTableSchema()

        ' Add 4 empty rows
        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdlistofMachinery.DataSource = dt
        grdlistofMachinery.DataBind()
    End Sub



    Private Function CreateEquipmentTableSchema() As DataTable
        Dim dt As New DataTable()
        ' Columns from the reference gridview
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Type", GetType(String))
        dt.Columns.Add("ServiceFloors", GetType(String))
        dt.Columns.Add("MachineLocation", GetType(String))
        dt.Columns.Add("acquisitioncost", GetType(Decimal))
        dt.Columns.Add("MaintenanceContractor", GetType(String))
        dt.Columns.Add("MaintenanceContactPerson", GetType(String))
        dt.Columns.Add("MaintenanceContactNo", GetType(String))

        ' DataKeyNames columns
        dt.Columns.Add("Property_ID", GetType(String))
        dt.Columns.Add("PropertyDetai_ID", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        'dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Received_ID", GetType(String))
        dt.Columns.Add("AcquisitionCost", GetType(Decimal))
        dt.Columns.Add("Received_Date", GetType(DateTime))
        dt.Columns.Add("Date_Accepted", GetType(DateTime))
        dt.Columns.Add("useful_life", GetType(String))
        dt.Columns.Add("Received_Dtl_ID", GetType(String))

        Return dt
    End Function


    ' ============================
    ' EQUIPMENT GRIDVIEW EVENT HANDLERS
    ' ============================

    Protected Sub grdlistofMachinery_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdlistofMachinery.PageIndex = e.NewPageIndex
        BindEquipmentGrid()
    End Sub

    Protected Sub grdlistofMachinery_SelectedIndexChanged(sender As Object, e As EventArgs)
        If grdlistofMachinery.SelectedIndex >= 0 Then
            loadUnit()

            Dim selectedPropertyId As String = grdlistofMachinery.SelectedDataKey("Property_ID")
            Session("Property_ID") = selectedPropertyId

            Dim propertyDtlId As String = grdlistofMachinery.DataKeys(grdlistofMachinery.SelectedIndex).Values("PropertyDetai_ID").ToString()
            PopulateMachineryInformation(propertyDtlId)

            ' Refresh the current view when equipment is selected
            RefreshGridData()
        End If
    End Sub


    Protected Sub grdlistofMachinery_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        ' Make rows clickable for selection
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdlistofMachinery, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    Protected Sub grdlistofMachinery_ondatabound(sender As Object, e As EventArgs)
        ' DataBound event handler - add any data binding logic here if needed
    End Sub






    ' =================================== MACHINERY INFORMATION ============================================================



    Private Function GetMachineryInformationData(ByVal propertyDtlId As String) As DataTable
        Dim dt As New DataTable()

        Try
            ' Use the stored procedure to get machinery information
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Machinery_GetInformation] '" & propertyDtlId & "'"

            dt = objDerived.GetDataTable(sql, CommandType.Text)

        Catch ex As Exception
            ' Log error if needed
            System.Diagnostics.Debug.WriteLine("Error loading machinery information data: " & ex.Message)
            Return Nothing
        End Try

        Return dt
    End Function

    Private Sub PopulateMachineryInformation(ByVal propertyDtlId As String)
        Dim dt As DataTable = GetMachineryInformationData(propertyDtlId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ' Populate the form fields with data
            txtMachineryName.Text = dt.Rows(0).Item("MachineName").ToString()
            txtMachineryDescription.Text = dt.Rows(0).Item("MachineDesc").ToString()
            txtMachineryPowerInput.Text = dt.Rows(0).Item("PowerInput").ToString()
            txtMachineryModel.Text = dt.Rows(0).Item("BrandModel").ToString()

            ' Unit dropdown
            drpMachineUnit.SelectedValue = dt.Rows(0).Item("Unit_ID").ToString()

            txtMachineryDimension.Text = dt.Rows(0).Item("CarDimensions").ToString()
            txtMachineryAreaCapacity.Text = dt.Rows(0).Item("AreaCapacity").ToString()
            txtMachineryWarranty.Text = dt.Rows(0).Item("Warranty").ToString()
            txtMachineryFloorLocation.Text = dt.Rows(0).Item("MachineLocation").ToString()
            txtMachineryRoom.Text = dt.Rows(0).Item("ServiceFloors").ToString()

            ' Maintenance section
            txtContractor.Text = dt.Rows(0).Item("MaintenanceContractor").ToString()
            txtContactPerson.Text = dt.Rows(0).Item("MaintenanceContactPerson").ToString()
            txtCellphoneNo.Text = dt.Rows(0).Item("MaintenanceContactNo").ToString()

            ' Acquisition section
            If Not String.IsNullOrEmpty(dt.Rows(0).Item("Property_Date").ToString()) Then
                txtMachineryAcqDate.Text = Convert.ToDateTime(dt.Rows(0).Item("Property_Date").ToString()).ToString("MM/dd/yyyy")
            End If

            txtMachineryMarketValue.Text = FormatNumber(dt.Rows(0).Item("MarketValue").ToString(), 2)
            txtMachineryAcqCost.Text = FormatNumber(dt.Rows(0).Item("Cost").ToString(), 2)
            txtMachineryNoYears.Text = dt.Rows(0).Item("NoYears").ToString()

            If Not String.IsNullOrEmpty(dt.Rows(0).Item("DepreciationRate").ToString()) Then
                txtMachineryDepRate.Text = FormatNumber(dt.Rows(0).Item("DepreciationRate").ToString(), 2)
            End If

            txtMachineryUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString()

            If Not String.IsNullOrEmpty(dt.Rows(0).Item("DepreciationValue").ToString()) Then
                txtequipmentdepreciatedvalue.Text = FormatNumber(dt.Rows(0).Item("DepreciationValue").ToString(), 2)
            End If

            If Not String.IsNullOrEmpty(dt.Rows(0).Item("SalvageValue").ToString()) Then
                txtMachinerySalvageValue.Text = FormatNumber(dt.Rows(0).Item("SalvageValue").ToString(), 2)
            End If

            ' Store useful_life in session if needed
            Session("useful_life") = dt.Rows(0).Item("useful_life").ToString()

        Else
            ' Clear form if no data found
            ClearMachineryInformationForm()
        End If
    End Sub

    Private Sub ClearMachineryInformationForm()
        ' Clear all form fields
        txtMachineryName.Text = ""
        txtMachineryDescription.Text = ""
        txtMachineryPowerInput.Text = ""
        txtMachineryModel.Text = ""
        drpMachineUnit.SelectedIndex = -1
        txtMachineryDimension.Text = ""
        txtMachineryAreaCapacity.Text = ""
        txtMachineryWarranty.Text = ""
        txtMachineryFloorLocation.Text = ""
        txtMachineryRoom.Text = ""
        txtContractor.Text = ""
        txtContactPerson.Text = ""
        txtCellphoneNo.Text = ""
        txtMachineryAcqDate.Text = ""
        txtMachineryMarketValue.Text = ""
        txtMachineryAcqCost.Text = ""
        txtMachineryNoYears.Text = ""
        txtMachineryDepRate.Text = ""
        txtMachineryUsefulLife.Text = ""
        txtequipmentdepreciatedvalue.Text = ""
        txtMachinerySalvageValue.Text = ""
    End Sub

    'Loading of Unit
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpMachineUnit.DataSource = dt
        drpMachineUnit.DataTextField = ("Description")
        drpMachineUnit.DataValueField = ("Unit_ID")
        drpMachineUnit.DataBind()
    End Sub




    ' =================================== LEDGER GRIDVIEW FUNCTIONS ============================================================
    ' =================================== MULTIVIEW AND TAB FUNCTIONS ===================================

    Protected Sub btnmachineryLedger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmachineryLedger.Click
        loadMachineryLedger()
    End Sub

    Protected Sub btnmachineryRepairs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmachineryRepairs.Click
        loadMachineryRepair()
    End Sub

    Protected Sub btnmachineryDocattach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmachineryDocattach.Click
        loadMachineryAttchDocu()
    End Sub

    Protected Sub loadMachineryLedger()
        btnmachineryLedger.CssClass = "Clicked"
        btnmachineryRepairs.CssClass = "Initial"
        btnmachineryDocattach.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwledger)
        BindLedgerGrid() ' This will now use the stored procedure
    End Sub

    Protected Sub loadMachineryRepair()
        btnmachineryLedger.CssClass = "Initial"
        btnmachineryRepairs.CssClass = "Clicked"
        btnmachineryDocattach.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwrepairsandmaintenance)
        BindRepairsGrid()
    End Sub

    Protected Sub loadMachineryAttchDocu()
        btnmachineryLedger.CssClass = "Initial"
        btnmachineryRepairs.CssClass = "Initial"
        btnmachineryDocattach.CssClass = "Clicked"

        Me.mvledger.SetActiveView(Me.vwdocumentattachment)
        BindDocumentsGrid()
    End Sub

    ' =================================== GRID BINDING FUNCTIONS ===================================

    Private Sub BindLedgerGrid()
        ' Get parameters from Session
        Dim classificationId As String = If(Session("ClassificationID"), "0")

        ' Try to get data from stored procedure
        Dim dt As DataTable = GetLedgerData(classificationId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ' Bind actual data
            grdLedger.DataSource = dt
            grdLedger.DataBind()
        Else
            ' Bind empty grid if no data
            BindEmptyLedgerGrid()
        End If
    End Sub

    Private Sub BindEmptyLedgerGrid()
        Dim dt As DataTable = CreateLedgerTableSchema()

        ' Add 4 empty rows
        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdLedger.DataSource = dt
        grdLedger.DataBind()
    End Sub


    Private Function GetLedgerData(ByVal classificationId As String) As DataTable
        Dim dt As New DataTable()

        Try

            ' Use the stored procedure for ledger data
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Ledger_v2] '" & Session("Item_ID") & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)

        Catch ex As Exception
            ' Log error if needed
            System.Diagnostics.Debug.WriteLine("Error loading ledger data: " & ex.Message)
            Return Nothing
        End Try

        Return dt
    End Function


    Private Sub BindRepairsGrid()
        Dim dt As DataTable = CreateRepairsTableSchema()

        ' Add 4 empty rows
        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdrepairsandmaintenance.DataSource = dt
        grdrepairsandmaintenance.DataBind()
    End Sub

    Private Sub BindDocumentsGrid()
        Dim dt As DataTable = CreateDocumentsTableSchema()

        ' Add 4 empty rows
        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdpropertydocdetails.DataSource = dt
        grdpropertydocdetails.DataBind()
    End Sub

    ' =================================== TABLE SCHEMA FUNCTIONS ===================================

    Private Function CreateLedgerTableSchema() As DataTable
        Dim dt As New DataTable()
        ' Columns from the ledger gridview
        dt.Columns.Add("dDate", GetType(DateTime))
        dt.Columns.Add("Trans_Type", GetType(String))
        dt.Columns.Add("ref", GetType(String))
        dt.Columns.Add("AccountablePerson", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("position", GetType(String))
        dt.Columns.Add("acceptedby", GetType(String))
        dt.Columns.Add("inspectedby", GetType(String))
        dt.Columns.Add("DebitQty", GetType(Decimal))
        dt.Columns.Add("DebitUnit", GetType(String))
        dt.Columns.Add("DebitCost", GetType(Decimal))
        dt.Columns.Add("CreditQty", GetType(Decimal))
        dt.Columns.Add("CreditUnit", GetType(String))
        dt.Columns.Add("CreditCost", GetType(Decimal))
        dt.Columns.Add("BalQty", GetType(Decimal))
        dt.Columns.Add("BalanceUnit", GetType(String))
        dt.Columns.Add("BalCost", GetType(Decimal))

        Return dt
    End Function
    Private Function CreateRepairsTableSchema() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Property_Dtl_ID", GetType(Integer))
        dt.Columns.Add("RepairMaintenanceId", GetType(Integer))
        dt.Columns.Add("dDate", GetType(DateTime))
        dt.Columns.Add("ServiceProvider", GetType(String))
        dt.Columns.Add("NatureRepair", GetType(String))
        dt.Columns.Add("InvoiceNo", GetType(String))
        dt.Columns.Add("Total", GetType(Decimal))

        Return dt
    End Function

    Private Function CreateDocumentsTableSchema() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("DocuId", GetType(Integer))
        dt.Columns.Add("DocumentName", GetType(String))
        dt.Columns.Add("DocumentNo", GetType(String))
        dt.Columns.Add("ValidatedBy", GetType(String))
        dt.Columns.Add("DateValidated", GetType(DateTime))
        dt.Columns.Add("Remarks", GetType(String))

        Return dt
    End Function

    ' =================================== EVENT HANDLERS ===================================

    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        ' DataBound event handler for ledger grid
    End Sub

    Protected Sub btnPreview_Click(sender As Object, e As EventArgs)
        ' Preview button functionality
    End Sub

    Protected Sub grdrepairsandmaintenance_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Handle repairs grid selection
    End Sub

    Protected Sub grdpropertydocdetails_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        ' Handle document grid row data binding
    End Sub

    Protected Sub grdpropertydocdetails_SelectedIndexChanged1(sender As Object, e As EventArgs)
        ' Handle document grid selection
        loadAttchDocuChangeIndex()
    End Sub

    Protected Sub loadAttchDocuChangeIndex()
        Try
            If grdpropertydocdetails.SelectedIndex >= 0 Then
                Dim id As Integer = CInt(grdpropertydocdetails.SelectedDataKey(0).ToString())
                imgpropertydocs.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & id
            Else
                imgpropertydocs.ImageUrl = "~/images/BlankImage.jpg"
            End If
        Catch ex As Exception
            imgpropertydocs.ImageUrl = "~/images/BlankImage.jpg"
        End Try
    End Sub



End Class