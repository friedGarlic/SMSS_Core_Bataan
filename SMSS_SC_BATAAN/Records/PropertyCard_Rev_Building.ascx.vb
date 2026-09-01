Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_PropertyCard_Rev_Building
    Inherits System.Web.UI.UserControl

    Private objDerived As New DerivedDal

    ' ============================
    ' TRACE HELPER (same as reference)
    ' ============================
    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindBuildingLocationGrid()
            BindBuildingsGrid()
            BindBuildingLedgerGrid()

            ' match reference behavior
            Session("GA_ID") = 0
            Session("SubClassificationID") = 0
        Else
            BindBuildingLocationGrid()
            BindBuildingsGrid()
        End If
    End Sub

    ' ============================
    ' REFRESH METHOD (called by main page)
    ' ============================
    Public Sub RefreshGridData()
        BindBuildingLocationGrid()

        If gvBuildingLocationList.SelectedIndex >= 0 Then
            BindBuildingsGrid()
        Else
            BindEmptyBuildingsGrid()
        End If

        BindBuildingLedgerGrid()
    End Sub

    ' ============================
    ' LIST OF LOCATION (BUILDINGS)
    ' ============================
    Private Sub BindBuildingLocationGrid()
        Dim subClassId As String = If(Session("SubClassificationID"), "0").ToString()
        Dim gaId As String = If(Session("GA_ID"), "0").ToString()

        Dim dt As DataTable = GetBuildingLocationData(subClassId, gaId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvBuildingLocationList.DataSource = dt
            gvBuildingLocationList.DataBind()
        Else
            BindEmptyBuildingLocationGrid()
        End If
    End Sub

    Private Function GetBuildingLocationData(ByVal subClassId As String, ByVal gaId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("BUILDING Location -> subClassId: " & subClassId)
            AddTrace("BUILDING Location -> gaId: " & gaId)

            ' same sql interaction pattern as reference
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Building_ListOfLocation] '" & subClassId & "', '" & gaId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading building locations: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyBuildingLocationGrid()
        Dim dt As DataTable = CreateBuildingLocationSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        gvBuildingLocationList.DataSource = dt
        gvBuildingLocationList.DataBind()
    End Sub

    Private Function CreateBuildingLocationSchema() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("item_particular_id", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("DeclaredOwner", GetType(String))
        dt.Columns.Add("Barangay", GetType(String))

        dt.Columns.Add("BuildingNo", GetType(String))
        dt.Columns.Add("BuildingName", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("FloorArea", GetType(String))
        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        Return dt
    End Function

    ' LOCATION EVENTS
    Protected Sub gvBuildingLocationList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvBuildingLocationList.PageIndex = e.NewPageIndex
        BindBuildingLocationGrid()
    End Sub

    Protected Sub gvBuildingLocationList_SelectedIndexChanged(sender As Object, e As EventArgs)
        If gvBuildingLocationList.SelectedIndex >= 0 Then
            Dim selectedItemId As String = gvBuildingLocationList.SelectedDataKey("Item_ID")
            Session("Item_ID") = selectedItemId
            BindBuildingsGrid()


            Dim dt As DataTable = GetBuildingLedgerData(Nothing)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                FormatBuildingLedgerTransType(dt)

                grdBuildingLedger.DataSource = dt
                grdBuildingLedger.DataBind()
            Else
                BindEmptyBuildingLedgerGrid()
            End If


        End If
    End Sub


    Private Sub FormatBuildingLedgerTransType(ByVal dt As DataTable)

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

    Protected Sub gvBuildingLocationList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvBuildingLocationList, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    ' ============================
    ' LIST OF BUILDINGS (child grid)
    ' ============================
    Protected Sub btnBuildingPropSearch_Click(sender As Object, e As EventArgs)
        Dim searchText As String = txtBuildingPropSearch.Text.Trim()

        ' If no search value → show full list using existing logic
        If String.IsNullOrEmpty(searchText) Then
            AddTrace("Building Search: empty, loading full list.")
            BindBuildingsGrid()
            Exit Sub
        End If

        ' Replicate the same parameter logic used in BindBuildingsGrid
        Dim itemId As String = If(Session("Item_ID"), "0").ToString()
        Dim gaId As String = If(Session("GA_ID"), "0").ToString()

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        If gvBuildingLocationList.SelectedIndex >= 0 Then
            itemParticularId = gvBuildingLocationList.DataKeys(gvBuildingLocationList.SelectedIndex).Values("item_particular_id").ToString()
            itemId = gvBuildingLocationList.DataKeys(gvBuildingLocationList.SelectedIndex).Values("Item_ID").ToString()
            declaredOwner = gvBuildingLocationList.DataKeys(gvBuildingLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
            barangay = gvBuildingLocationList.DataKeys(gvBuildingLocationList.SelectedIndex).Values("Barangay").ToString()
        End If

        AddTrace("Building Search: " & searchText &
             " | itemParticularId=" & itemParticularId &
             " | itemId=" & itemId &
             " | gaId=" & gaId &
             " | declaredOwner=" & declaredOwner &
             " | barangay=" & barangay)

        ' Get the same dataset BindBuildingsGrid would bind
        Dim dt As DataTable = GetBuildingsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BindEmptyBuildingsGrid()
            Exit Sub
        End If

        ' Filter by PropertyNo LIKE '%txtBuildingPropSearch%'
        Dim dv As New DataView(dt)

        ' Escape special chars for DataView RowFilter
        Dim safeSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("]", "]]")

        dv.RowFilter = "PropertyNo LIKE '%" & safeSearch & "%'"

        If dv.Count > 0 Then
            grdListOfBuildings.DataSource = dv
            grdListOfBuildings.DataBind()
        Else
            BindEmptyBuildingsGrid()
        End If
    End Sub


    Private Sub BindBuildingsGrid()
        Dim itemId As String = If(Session("Item_ID"), "0").ToString()
        Dim gaId As String = If(Session("GA_ID"), "0").ToString()

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        Try
            If gvBuildingLocationList.SelectedIndex >= 0 Then
                itemParticularId = gvBuildingLocationList.DataKeys(gvBuildingLocationList.SelectedIndex).Values("item_particular_id").ToString()
                itemId = gvBuildingLocationList.DataKeys(gvBuildingLocationList.SelectedIndex).Values("Item_ID").ToString()
                declaredOwner = gvBuildingLocationList.DataKeys(gvBuildingLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
                barangay = gvBuildingLocationList.DataKeys(gvBuildingLocationList.SelectedIndex).Values("Barangay").ToString()
            End If

            AddTrace("BUILDING List -> itemParticularId: " & itemParticularId)
            AddTrace("BUILDING List -> itemId: " & itemId)
            AddTrace("BUILDING List -> gaId: " & gaId)
            AddTrace("BUILDING List -> declaredOwner: " & declaredOwner)
            AddTrace("BUILDING List -> barangay: " & barangay)

            Dim dt As DataTable = GetBuildingsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                grdListOfBuildings.DataSource = dt
                grdListOfBuildings.DataBind()
            Else
                BindEmptyBuildingsGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetBuildingsData(ByVal itemParticularId As String, ByVal itemId As String, ByVal gaId As String,
                                      ByVal declaredOwner As String, ByVal barangay As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String =
                "Exec [AMS].[PropertyCard_Rev_Building_ListOfBuildings] '" & itemParticularId & "', '" & itemId & "', '" & gaId & "', '" & declaredOwner & "', '" & barangay & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading buildings list: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyBuildingsGrid()
        Dim dt As DataTable = CreateBuildingsSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdListOfBuildings.DataSource = dt
        grdListOfBuildings.DataBind()
    End Sub

    Private Function CreateBuildingsSchema() As DataTable
        Dim dt As New DataTable()

        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("ItemDescription", GetType(String))
        dt.Columns.Add("Title", GetType(String))
        dt.Columns.Add("Author", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
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

    ' BUILDINGS EVENTS
    Protected Sub grdListOfBuildings_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdListOfBuildings.PageIndex = e.NewPageIndex
        BindBuildingsGrid()
    End Sub

    Protected Sub grdListOfBuildings_SelectedIndexChanged(sender As Object, e As EventArgs)
        If grdListOfBuildings.SelectedIndex >= 0 Then
            Dim selectedPropertyId As String = grdListOfBuildings.SelectedDataKey("Property_ID")
            Session("Property_ID") = selectedPropertyId

            Dim propertyDtlId As String =
                grdListOfBuildings.DataKeys(grdListOfBuildings.SelectedIndex).Values("PropertyDetai_ID").ToString()

            PopulateBuildingInformation(propertyDtlId)

            RefreshGridData()
        End If
    End Sub

    Protected Sub grdListOfBuildings_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdListOfBuildings, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    Protected Sub grdListOfBuildings_OnDataBound(sender As Object, e As EventArgs)
        ' reserved for future binding logic
    End Sub


    ' ============================
    ' BUILDING INFORMATION
    ' ============================
    Private Function GetBuildingInformationData(ByVal propertyDtlId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("BUILDING Info -> propertyDtlId: " & propertyDtlId)
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Building_GetInformation] '" & propertyDtlId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading building information: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub PopulateBuildingInformation(ByVal propertyDtlId As String)
        Dim dt As DataTable = GetBuildingInformationData(propertyDtlId)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearBuildingInformationForm()
            Return
        End If

        Dim r As DataRow = dt.Rows(0)

        ' ============================
        ' BASIC BUILDING INFO
        ' ============================
        If dt.Columns.Contains("BuildingName") Then txtBuildingName.Text = r("BuildingName").ToString()
        If dt.Columns.Contains("Address") Then txtAddress.Text = r("Address").ToString()
        If dt.Columns.Contains("Barangay") Then txtBrgy.Text = r("Barangay").ToString()
        If dt.Columns.Contains("Description") Then txtDescription.Text = r("Description").ToString()
        If dt.Columns.Contains("Unit") Then txtUnit.Text = r("Unit").ToString()

        If dt.Columns.Contains("Area") Then txtArea.Text = r("Area").ToString()
        If dt.Columns.Contains("TaxDecNo") Then txtTaxDecNo.Text = r("TaxDecNo").ToString()
        If dt.Columns.Contains("PrevOwner") Then txtPrevOwner.Text = r("PrevOwner").ToString()
        If dt.Columns.Contains("PropertyNo") Then txtPropertyNo.Text = r("PropertyNo").ToString()
        If dt.Columns.Contains("Remarks") Then txtRemarks.Text = r("Remarks").ToString()

        ' ============================
        ' ACQUISITION / FINANCIAL
        ' ============================
        If dt.Columns.Contains("AcquisitionDate") AndAlso Not String.IsNullOrEmpty(r("AcquisitionDate").ToString()) Then
            txtEAcqDate.Text = Convert.ToDateTime(r("AcquisitionDate")).ToString("MM/dd/yyyy")
        End If

        If dt.Columns.Contains("MarketValue") Then txtEMarketValue.Text = FormatNumber(r("MarketValue"), 2)
        If dt.Columns.Contains("AcquisitionCost") Then txtEAcqCost.Text = FormatNumber(r("AcquisitionCost"), 2)
        If dt.Columns.Contains("NoYears") Then txtNoYears.Text = r("NoYears").ToString()

        If dt.Columns.Contains("DepreciationRate") Then
            lblequipmentdepreciatedRate.Text = FormatNumber(r("DepreciationRate"), 2)
        End If

        If dt.Columns.Contains("UsefulLife") Then txtUsefulLife.Text = r("UsefulLife").ToString()
        If dt.Columns.Contains("DepreciatedValue") Then
            txtequipmentdepreciatedvalue.Text = FormatNumber(r("DepreciatedValue"), 2)
        End If

        If dt.Columns.Contains("SalvageValue") Then
            txtSalvageValue.Text = FormatNumber(r("SalvageValue"), 2)
        End If

        If dt.Columns.Contains("DepreciationValue") Then
            txtDepreciationValue.Text = FormatNumber(r("DepreciationValue"), 2)
        End If

        ' ============================
        ' OTHER BUILDING DETAILS
        ' ============================
        If dt.Columns.Contains("BuildingControlNo") Then txtBuildingControlNo.Text = r("BuildingControlNo").ToString()
        If dt.Columns.Contains("BuildingCode") Then txtBuildingCode.Text = r("BuildingCode").ToString()
        If dt.Columns.Contains("BuildingUse") Then txtBuildingUse.Text = r("BuildingUse").ToString()
        If dt.Columns.Contains("PostalCode") Then txtPostalCode.Text = r("PostalCode").ToString()
        If dt.Columns.Contains("BuildingOccupancy") Then txtBuildingOccupancy.Text = r("BuildingOccupancy").ToString()
        If dt.Columns.Contains("NoofFloors") Then txtNoofFloors.Text = r("NoofFloors").ToString()
        If dt.Columns.Contains("AvgAreaperFloor") Then txtAvgAreaperFloor.Text = r("AvgAreaperFloor").ToString()
        If dt.Columns.Contains("CostperArea") Then txtCostperArea.Text = r("CostperArea").ToString()

        ' ============================
        ' SUPPORTING FIELD
        ' ============================
        If dt.Columns.Contains("useful_life") Then
            Session("useful_life") = r("useful_life").ToString()
        End If
    End Sub

    Private Sub ClearBuildingInformationForm()
        ' BASIC
        txtBuildingName.Text = ""
        txtAddress.Text = ""
        txtBrgy.Text = ""
        txtDescription.Text = ""
        txtUnit.Text = ""
        txtArea.Text = ""
        txtTaxDecNo.Text = ""
        txtPrevOwner.Text = ""
        txtPropertyNo.Text = ""
        txtRemarks.Text = ""

        ' ACQUISITION / FINANCIAL
        txtEAcqDate.Text = ""
        txtEMarketValue.Text = ""
        txtEAcqCost.Text = ""
        txtNoYears.Text = ""
        lblequipmentdepreciatedRate.Text = ""
        txtUsefulLife.Text = ""
        txtequipmentdepreciatedvalue.Text = ""
        txtSalvageValue.Text = ""
        txtDepreciationValue.Text = ""

        ' OTHER BUILDING DETAILS
        txtBuildingControlNo.Text = ""
        txtBuildingCode.Text = ""
        txtBuildingUse.Text = ""
        txtPostalCode.Text = ""
        txtBuildingOccupancy.Text = ""
        txtNoofFloors.Text = ""
        txtAvgAreaperFloor.Text = ""
        txtCostperArea.Text = ""
    End Sub


    ' ============================
    ' TRANSACTIONS / LEDGER
    ' (uses same SP as reference)
    ' ============================
    Private Sub BindBuildingLedgerGrid()
        Dim classificationId As String = If(Session("ClassificationID"), "0").ToString()

        Dim dt As DataTable = GetBuildingLedgerData(classificationId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdBuildingLedger.DataSource = dt
            grdBuildingLedger.DataBind()
        Else
            BindEmptyBuildingLedgerGrid()
        End If
    End Sub

    Private Function GetBuildingLedgerData(ByVal classificationId As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Ledger_v2] '" & Session("Item_ID") & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading building ledger: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyBuildingLedgerGrid()
        Dim dt As DataTable = CreateBuildingLedgerSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdBuildingLedger.DataSource = dt
        grdBuildingLedger.DataBind()
    End Sub

    Private Function CreateBuildingLedgerSchema() As DataTable
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
    Protected Sub OnBuildingLedgerDataBound(sender As Object, e As EventArgs)
        ' reserved
    End Sub

    Protected Sub btnBuildingPreview_Click(sender As Object, e As EventArgs)
        ' reserved
    End Sub

End Class
