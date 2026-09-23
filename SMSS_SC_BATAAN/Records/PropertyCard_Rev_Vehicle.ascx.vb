Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Text.RegularExpressions

Partial Class Records_PropertyCard_Rev_Vehicle
    Inherits System.Web.UI.UserControl

    Private objDerived As New DerivedDal

    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Protected Sub Page_Load(
    ByVal sender As Object,
    ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            BindVehicleGrid()
            BindEmptyVehiclesGrid()
            BindEmptyVehicleLedgerGrid()
            ClearVehicleInformationForm()
        End If

    End Sub

    ' ============================
    ' REFRESH METHOD
    ' ============================
    Public Sub RefreshGridData()
        BindVehicleGrid()

        Dim itemId As String =
        If(Session("Item_ID"), "0").ToString()

        If Not String.IsNullOrEmpty(itemId) AndAlso
        itemId <> "0" Then

            BindVehiclesGrid()
            BindVehicleLedgerGrid()
        Else
            grdListOfVehicles.PageIndex = 0
            grdListOfVehicles.SelectedIndex = -1

            txtVehiclePropSearch.Text = ""

            If ddlVehicleSearchCriteria.Items.Count > 0 Then
                ddlVehicleSearchCriteria.SelectedIndex = 0
            End If

            BindEmptyVehiclesGrid()
            BindEmptyVehicleLedgerGrid()
            ClearVehicleInformationForm()
        End If

    End Sub

    ' ============================
    ' LOAD ITEM FROM MAIN PAGE
    ' ============================
    Public Sub LoadSelectedItem(ByVal itemId As String)

        If String.IsNullOrEmpty(itemId) OrElse itemId = "0" Then
            Session("Item_ID") = 0
            Session("Property_ID") = 0
            Session("PropertyDetai_ID") = 0

            grdListOfVehicles.PageIndex = 0
            grdListOfVehicles.SelectedIndex = -1

            txtVehiclePropSearch.Text = ""

            If ddlVehicleSearchCriteria.Items.Count > 0 Then
                ddlVehicleSearchCriteria.SelectedIndex = 0
            End If

            BindEmptyVehiclesGrid()
            BindEmptyVehicleLedgerGrid()
            ClearVehicleInformationForm()

            Exit Sub
        End If

        Session("Item_ID") = itemId
        Session("Property_ID") = 0
        Session("PropertyDetai_ID") = 0

        ' Reset the previously selected Vehicle property.
        grdListOfVehicles.PageIndex = 0
        grdListOfVehicles.SelectedIndex = -1

        ' Reset the search controls for the newly selected item.
        txtVehiclePropSearch.Text = ""

        If ddlVehicleSearchCriteria.Items.Count > 0 Then
            ddlVehicleSearchCriteria.SelectedIndex = 0
        End If

        ClearVehicleInformationForm()

        AddTrace(
        "Vehicle User Control Item_ID: " &
        itemId
    )

        BindVehiclesGrid()
        BindVehicleLedgerGrid()

    End Sub


    ' ============================
    ' LOCATION GRIDVIEW (VEHICLE)
    ' ============================
    Private Sub BindVehicleGrid()
        Dim subClass As String = If(Session("SubClassificationID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim dt As DataTable = GetVehicleLocationData(subClass, gaId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvVehicleLocationList.DataSource = dt
            gvVehicleLocationList.DataBind()
        Else
            BindEmptyVehicleGrid()
        End If

        If gaId = 0 Then
            BindEmptyVehicleGrid()
            Session("PropertyDetai_ID") = 0
        End If
    End Sub

    Private Function GetVehicleLocationData(ByVal subClassId As String, ByVal gaId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("subClassId: " & subClassId)
            AddTrace("gaId: " & gaId)

            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Vehicle_ListOfLocation] '" & subClassId & "', '" & gaId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading vehicle locations: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyVehicleGrid()
        Dim dt As DataTable = CreateVehicleLocationSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        gvVehicleLocationList.DataSource = dt
        gvVehicleLocationList.DataBind()
    End Sub

    Private Function CreateVehicleLocationSchema() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("item_particular_id", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("DeclaredOwner", GetType(String))
        dt.Columns.Add("Barangay", GetType(String))

        dt.Columns.Add("PlateNo", GetType(String))
        dt.Columns.Add("MakeModel", GetType(String))
        dt.Columns.Add("EngineNo", GetType(String))
        dt.Columns.Add("ChassisNo", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        Return dt
    End Function

    ' LOCATION EVENTS
    Protected Sub gvVehicleLocationList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvVehicleLocationList.PageIndex = e.NewPageIndex
        BindVehicleGrid()
    End Sub

    Protected Sub gvVehicleLocationList_SelectedIndexChanged(
    sender As Object,
    e As EventArgs)

        If gvVehicleLocationList.SelectedIndex >= 0 Then

            Dim selectedItemId As String =
            gvVehicleLocationList.DataKeys(
                gvVehicleLocationList.SelectedIndex
            ).Values("Item_ID").ToString()

            LoadSelectedItem(selectedItemId)

        End If

    End Sub

    Protected Sub gvVehicleLocationList_RowDataBound(
    sender As Object,
    e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim itemIdObject As Object =
            DataBinder.Eval(
                e.Row.DataItem,
                "Item_ID"
            )

            Dim itemId As String = ""

            If itemIdObject IsNot Nothing AndAlso
            Not Convert.IsDBNull(itemIdObject) Then

                itemId = itemIdObject.ToString()
            End If

            ' Only actual Vehicle item rows are clickable.
            If Not String.IsNullOrEmpty(itemId) Then
                e.Row.Attributes("onclick") =
                Page.ClientScript.GetPostBackClientHyperlink(
                    gvVehicleLocationList,
                    "Select$" & e.Row.RowIndex
                )

                e.Row.Style("cursor") = "pointer"
            End If

        End If

    End Sub

    ' ============================
    ' VEHICLES LIST GRIDVIEW
    ' ============================
    'Protected Sub btnVehiclePropSearch_Click(sender As Object, e As EventArgs)
    '    Dim searchText As String = txtVehiclePropSearch.Text.Trim()

    '    ' If no search value → show full list using existing logic
    '    If String.IsNullOrEmpty(searchText) Then
    '        AddTrace("Vehicle Search: empty, loading full list.")
    '        BindVehiclesGrid()
    '        Exit Sub
    '    End If

    '    ' Replicate the same parameter logic used in BindVehiclesGrid
    '    Dim itemId As String = If(Session("Item_ID"), "0")
    '    Dim gaId As String = If(Session("GA_ID"), "0")

    '    Dim itemParticularId As String = "0"
    '    Dim declaredOwner As String = ""
    '    Dim barangay As String = ""

    '    ' Adjust gvVehicleLocationList/DataKeys names if needed to match your actual code
    '    If gvVehicleLocationList.SelectedIndex >= 0 Then
    '        itemParticularId = gvVehicleLocationList.DataKeys(gvVehicleLocationList.SelectedIndex).Values("item_particular_id").ToString()
    '        itemId = gvVehicleLocationList.DataKeys(gvVehicleLocationList.SelectedIndex).Values("Item_ID").ToString()
    '        'declaredOwner = gvVehicleLocationList.DataKeys(gvVehicleLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
    '        barangay = gvVehicleLocationList.DataKeys(gvVehicleLocationList.SelectedIndex).Values("Barangay").ToString()
    '    End If

    '    AddTrace("Vehicle Search: " & searchText &
    '         " | itemParticularId=" & itemParticularId &
    '         " | itemId=" & itemId &
    '         " | gaId=" & gaId &
    '         " | declaredOwner=" & declaredOwner &
    '         " | barangay=" & barangay)

    '    ' Get the same dataset that BindVehiclesGrid would bind
    '    Dim dt As DataTable = GetVehiclesData(itemParticularId, itemId, gaId, declaredOwner, barangay)

    '    If dt Is Nothing OrElse dt.Rows.Count = 0 Then
    '        ' No data from SP → bind an empty table
    '        Dim emptyDt As DataTable
    '        If dt Is Nothing Then
    '            emptyDt = New DataTable()
    '        Else
    '            emptyDt = dt.Clone()
    '        End If

    '        grdListOfVehicles.DataSource = emptyDt
    '        grdListOfVehicles.DataBind()
    '        Exit Sub
    '    End If

    '    ' Filter by PropertyNo LIKE '%txtVehiclePlateSearch%'
    '    Dim dv As New DataView(dt)

    '    ' Escape special characters for RowFilter
    '    Dim safeSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("]", "]]")

    '    dv.RowFilter = "PropertyNo LIKE '%" & safeSearch & "%'"

    '    If dv.Count > 0 Then
    '        grdListOfVehicles.DataSource = dv
    '        grdListOfVehicles.DataBind()
    '    Else
    '        ' No matches after filter → bind an empty schema
    '        Dim emptyDt As DataTable = dt.Clone()
    '        grdListOfVehicles.DataSource = emptyDt
    '        grdListOfVehicles.DataBind()
    '    End If
    'End Sub

    'Added By JOhn
    Protected Sub btnVehiclePropSearch_Click(
    sender As Object,
    e As EventArgs)

        Dim searchText As String =
        txtVehiclePropSearch.Text.Trim()

        Dim searchBy As String =
        ddlVehicleSearchCriteria.SelectedValue

        If String.IsNullOrEmpty(searchText) Then
            AddTrace(
            "Vehicle Search: empty, loading full list."
        )

            BindVehiclesGrid()
            Exit Sub
        End If

        Dim itemId As String =
        If(Session("Item_ID"), "0").ToString()

        Dim gaId As String =
        If(Session("GA_ID"), "0").ToString()

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        If String.IsNullOrEmpty(itemId) OrElse itemId = "0" Then
            BindEmptyVehiclesGrid()
            Exit Sub
        End If

        AddTrace(
        "Vehicle Search: " & searchText &
        " | searchBy=" & searchBy &
        " | itemParticularId=" & itemParticularId &
        " | itemId=" & itemId &
        " | gaId=" & gaId &
        " | declaredOwner=" & declaredOwner &
        " | barangay=" & barangay
    )

        Dim dt As DataTable =
        GetVehiclesData(
            itemParticularId,
            itemId,
            gaId,
            declaredOwner,
            barangay
        )

        If dt IsNot Nothing Then

            If Not dt.Columns.Contains("SerialNo") Then
                dt.Columns.Add(
                "SerialNo",
                GetType(String)
            )

                If dt.Columns.Contains("Barcode") Then
                    For Each row As DataRow In dt.Rows
                        row("SerialNo") =
                        row("Barcode").ToString()
                    Next
                End If
            End If

        End If

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BindEmptyVehiclesGrid()
            Exit Sub
        End If

        ' Only allow the predefined search columns.
        If searchBy <> "PropertyNo" AndAlso
        searchBy <> "SerialNo" Then

            searchBy = "PropertyNo"
        End If

        Dim safeSearch As String =
        searchText.Replace("'", "''").
        Replace("[", "[[]").
        Replace("]", "]]")

        Dim dv As New DataView(dt)

        dv.RowFilter =
        searchBy &
        " LIKE '%" &
        safeSearch &
        "%'"

        If dv.Count > 0 Then
            grdListOfVehicles.DataSource = dv
            grdListOfVehicles.DataBind()
        Else
            BindEmptyVehiclesGrid()
        End If

    End Sub
    Private Sub BindVehiclesGrid()

        Dim itemId As String =
        If(Session("Item_ID"), "0").ToString()

        Dim gaId As String =
        If(Session("GA_ID"), "0").ToString()

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        AddTrace(
        "Vehicle List -> itemParticularId: " &
        itemParticularId
    )

        AddTrace(
        "Vehicle List -> itemId: " &
        itemId
    )

        AddTrace(
        "Vehicle List -> gaId: " &
        gaId
    )

        AddTrace(
        "Vehicle List -> declaredOwner: " &
        declaredOwner
    )

        AddTrace(
        "Vehicle List -> barangay: " &
        barangay
    )

        If String.IsNullOrEmpty(itemId) OrElse itemId = "0" Then
            BindEmptyVehiclesGrid()
            Exit Sub
        End If

        Dim dt As DataTable =
        GetVehiclesData(
            itemParticularId,
            itemId,
            gaId,
            declaredOwner,
            barangay
        )

        ' Preserve support for stored procedures that return
        ' the serial number through Barcode.
        If dt IsNot Nothing Then

            If Not dt.Columns.Contains("SerialNo") Then
                dt.Columns.Add(
                "SerialNo",
                GetType(String)
            )

                If dt.Columns.Contains("Barcode") Then
                    For Each row As DataRow In dt.Rows
                        row("SerialNo") =
                        row("Barcode").ToString()
                    Next
                End If
            End If

        End If

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdListOfVehicles.DataSource = dt
            grdListOfVehicles.DataBind()
        Else
            BindEmptyVehiclesGrid()
        End If

    End Sub

    Private Function GetVehiclesData(ByVal itemParticularId As String, ByVal itemId As String, ByVal gaId As String,
                                     ByVal declaredOwner As String, ByVal barangay As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Vehicle_ListOfVehicles] '" & itemParticularId & "', '" & itemId & "', '" & gaId & "', '" & declaredOwner & "', '" & barangay & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading vehicles list: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyVehiclesGrid()
        Dim dt As DataTable = CreateVehiclesSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdListOfVehicles.DataSource = dt
        grdListOfVehicles.DataBind()
    End Sub

    Private Function CreateVehiclesSchema() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Property_code", GetType(String))

        dt.Columns.Add("PlateNo", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("MakeModel", GetType(String))
        dt.Columns.Add("EngineNo", GetType(String))
        dt.Columns.Add("ChassisNo", GetType(String))

        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))

        dt.Columns.Add("Property_ID", GetType(String))
        dt.Columns.Add("PropertyDetai_ID", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("Received_ID", GetType(String))
        dt.Columns.Add("AcquisitionCost", GetType(Decimal))
        dt.Columns.Add("Received_Date", GetType(DateTime))
        dt.Columns.Add("Date_Accepted", GetType(DateTime))
        dt.Columns.Add("useful_life", GetType(String))
        dt.Columns.Add("Received_Dtl_ID", GetType(String))

        Return dt
    End Function

    ' VEHICLES EVENTS
    Protected Sub grdListOfVehicles_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdListOfVehicles.PageIndex = e.NewPageIndex
        BindVehiclesGrid()

    End Sub

    Protected Sub grdListOfVehicles_SelectedIndexChanged(
    sender As Object,
    e As EventArgs)

        If grdListOfVehicles.SelectedIndex >= 0 Then

            loadUnit()

            Dim selectedPropertyId As String =
            grdListOfVehicles.DataKeys(
                grdListOfVehicles.SelectedIndex
            ).Values("Property_ID").ToString()

            Session("Property_ID") =
            selectedPropertyId

            Dim propertyDtlId As String =
            grdListOfVehicles.DataKeys(
                grdListOfVehicles.SelectedIndex
            ).Values("PropertyDetai_ID").ToString()

            Session("PropertyDetai_ID") =
            propertyDtlId

            PopulateVehicleInformation(
            propertyDtlId
        )

            ' Refresh only the item-level ledger.
            ' Do not rebind the selected Vehicle property grid.
            BindVehicleLedgerGrid()

        End If

    End Sub

    Protected Sub grdListOfVehicles_RowDataBound(
    sender As Object,
    e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim propertyIdObject As Object =
            DataBinder.Eval(
                e.Row.DataItem,
                "Property_ID"
            )

            Dim propertyId As String = ""

            If propertyIdObject IsNot Nothing AndAlso
            Not Convert.IsDBNull(propertyIdObject) Then

                propertyId = propertyIdObject.ToString()
            End If

            ' Keep the four blank placeholder rows inactive.
            If Not String.IsNullOrEmpty(propertyId) Then
                e.Row.Attributes("onclick") =
                Page.ClientScript.GetPostBackClientHyperlink(
                    grdListOfVehicles,
                    "Select$" & e.Row.RowIndex
                )

                e.Row.Style("cursor") = "pointer"
            End If

        End If

    End Sub

    Protected Sub grdListOfVehicles_OnDataBound(sender As Object, e As EventArgs)
        ' reserved for future binding logic
    End Sub

    ' ============================
    ' VEHICLE INFORMATION
    ' ============================
    Private Function GetVehicleInformationData(ByVal propertyDtlId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("propertyDtlId: " & propertyDtlId)
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Vehicle_GetInformation] '" & propertyDtlId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading vehicle information: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub PopulateVehicleInformation(ByVal propertyDtlId As String)
        Dim dt As DataTable = GetVehicleInformationData(propertyDtlId)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearVehicleInformationForm()
            Return
        End If

        Dim r As DataRow = dt.Rows(0)

        If dt.Columns.Contains("PlateNo") Then txtVehiclePlateNo.Text = r("PlateNo").ToString()
        If dt.Columns.Contains("MakeModel") Then txtVehicleMakeModel.Text = r("MakeModel").ToString()
        If dt.Columns.Contains("EngineNo") Then txtVehicleEngineNo.Text = r("EngineNo").ToString()
        If dt.Columns.Contains("ChassisNo") Then txtVehicleChassisNo.Text = r("ChassisNo").ToString()
        If dt.Columns.Contains("LocationUser") Then txtVehicleLocationUser.Text = r("LocationUser").ToString()
        If dt.Columns.Contains("Category") Then txtVehicleCategory.Text = r("Category").ToString()

        If dt.Columns.Contains("AcquisitionDate") AndAlso Not String.IsNullOrEmpty(r("AcquisitionDate").ToString()) Then
            txtVehicleAcquisitionDate.Text = Convert.ToDateTime(r("AcquisitionDate")).ToString("MM/dd/yyyy")
        End If

        If dt.Columns.Contains("MarketValue") Then txtVehicleMarketValue.Text = FormatNumber(r("MarketValue"), 2)
        If dt.Columns.Contains("AcquisitionCost") Then txtVehicleAcquisitionCost.Text = FormatNumber(r("AcquisitionCost"), 2)
        If dt.Columns.Contains("NoYears") Then txtVehicleNoYears.Text = r("NoYears").ToString()
        If dt.Columns.Contains("DepreciationRate") Then txtVehicleDepRate.Text = FormatNumber(r("DepreciationRate"), 2)
        If dt.Columns.Contains("UsefulLife") Then txtVehicleUsefulLife.Text = r("UsefulLife").ToString()
        If dt.Columns.Contains("DepreciationValue") Then txtVehicleDepValue.Text = FormatNumber(r("DepreciationValue"), 2)
        If dt.Columns.Contains("SalvageValue") Then txtVehicleSalvageValue.Text = FormatNumber(r("SalvageValue"), 2)
        If dt.Columns.Contains("DepreciatedValue") Then txtDepreciatedValueVehicleNew.Text = FormatNumber(r("DepreciatedValue"), 2)
        If dt.Columns.Contains("Unit_ID") Then
            If ddVehicleUnit.Items.Count > 0 Then
                If ddVehicleUnit.Items.FindByValue(r("Unit_ID").ToString()) IsNot Nothing Then
                    ddVehicleUnit.SelectedValue = r("Unit_ID").ToString()
                End If
            End If
        End If

        If dt.Columns.Contains("useful_life") Then Session("useful_life") = r("useful_life").ToString()
    End Sub

    Private Sub ClearVehicleInformationForm()
        txtVehiclePlateNo.Text = ""
        txtVehicleMakeModel.Text = ""
        txtVehicleEngineNo.Text = ""
        txtVehicleChassisNo.Text = ""
        txtVehicleLocationUser.Text = ""
        txtVehicleCategory.Text = ""

        If ddVehicleUnit.Items.Count > 0 Then
            ddVehicleUnit.SelectedIndex = -1
        End If

        txtVehicleAcquisitionDate.Text = ""
        txtVehicleMarketValue.Text = ""
        txtVehicleAcquisitionCost.Text = ""
        txtVehicleNoYears.Text = ""
        txtVehicleDepRate.Text = ""
        txtVehicleUsefulLife.Text = ""
        txtDepreciatedValueVehicleNew.Text = ""
        txtVehicleSalvageValue.Text = ""
        txtVehicleDepValue.Text = ""
    End Sub

    'Loading of Unit
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        ddVehicleUnit.DataSource = dt
        ddVehicleUnit.DataTextField = ("Description")
        ddVehicleUnit.DataValueField = ("Unit_ID")
        ddVehicleUnit.DataBind()
    End Sub




    ' ============================
    ' LEDGER GRIDVIEW
    Private Sub BindVehicleLedgerGrid()

        Dim itemId As String =
        If(Session("Item_ID"), "0").ToString()

        If String.IsNullOrEmpty(itemId) OrElse itemId = "0" Then
            BindEmptyVehicleLedgerGrid()
            Exit Sub
        End If

        Dim dt As DataTable =
        GetVehicleLedgerData()

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            FormatVehicleLedgerTransType(dt)

            grdVehicleLedger.DataSource = dt
            grdVehicleLedger.DataBind()
        Else
            BindEmptyVehicleLedgerGrid()
        End If

    End Sub

    Private Function GetVehicleLedgerData() As DataTable
        Dim dt As New DataTable()

        Try
            Dim itemId As String =
            If(Session("Item_ID"), "0").ToString()

            AddTrace(
            "Vehicle Ledger Item_ID: " &
            itemId
        )

            Dim sql As String =
            "Exec [AMS].[PropertyCard_Rev_Ledger_v2] '" &
            itemId &
            "'"

            dt = objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(
            "Error loading vehicle ledger: " &
            ex.Message
        )

            Return Nothing
        End Try

        Return dt
    End Function
    Private Sub BindEmptyVehicleLedgerGrid()
        Dim dt As DataTable = CreateVehicleLedgerSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdVehicleLedger.DataSource = dt
        grdVehicleLedger.DataBind()
    End Sub

    Private Function CreateVehicleLedgerSchema() As DataTable
        Dim dt As New DataTable()
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

    ' LEDGER EVENTS
    Protected Sub OnVehicleLedgerDataBound(sender As Object, e As EventArgs)
        ' reserved
    End Sub

    Protected Sub btnVehiclePreview_Click(sender As Object, e As EventArgs)
        ' reserved
    End Sub

    Private Sub FormatVehicleLedgerTransType(ByVal dt As DataTable)

        If dt Is Nothing Then
            Exit Sub
        End If

        If Not dt.Columns.Contains("Trans_Type") Then
            Exit Sub
        End If

        For Each row As DataRow In dt.Rows

            If row.IsNull("Trans_Type") Then
                Continue For
            End If

            Dim transType As String = row("Trans_Type").ToString().Trim()

            If String.IsNullOrEmpty(transType) Then
                Continue For
            End If

            ' Normalize all line-break formats first.
            transType = transType.Replace(vbCrLf, vbLf)
            transType = transType.Replace(vbCr, vbLf)

            ' Print "Originally issued to" on the next line with a dash.
            transType = Regex.Replace(
                transType,
                "\s*-?\s*(Originally issued to)",
                vbLf & "- $1",
                RegexOptions.IgnoreCase
            )

            ' Print "Transferred from" on the next line with a dash.
            transType = Regex.Replace(
                transType,
                "\s*-?\s*(Transferred from)",
                vbLf & "- $1",
                RegexOptions.IgnoreCase
            )

            ' Remove accidental blank lines.
            Do While transType.Contains(vbLf & vbLf)
                transType = transType.Replace(vbLf & vbLf, vbLf)
            Loop

            row("Trans_Type") = transType.Trim()

        Next

    End Sub


End Class
