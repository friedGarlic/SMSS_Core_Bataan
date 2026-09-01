Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_PropertyCard_Rev_Intangible
    Inherits System.Web.UI.UserControl

    Private objDerived As New DerivedDal

    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindIntangibleLocationGrid()
            BindIntangibleAssetsGrid()
            BindIntangibleLedgerGrid()
            ClearIntangibleInformationForm()

            Session("GA_ID") = 0
            Session("SubClassificationID") = 0
        Else
            BindIntangibleLocationGrid()
            BindIntangibleAssetsGrid()
        End If
    End Sub

    ' ============================
    ' REFRESH METHOD
    ' ============================
    Public Sub RefreshGridData()
        BindIntangibleLocationGrid()

        If gvIntangibleLocationList.SelectedIndex >= 0 Then
            BindIntangibleAssetsGrid()
        Else
            BindEmptyIntangibleAssetsGrid()
        End If

        BindIntangibleLedgerGrid()
        ClearIntangibleInformationForm()
    End Sub

    ' ============================
    ' LOCATION GRIDVIEW FUNCTIONS
    ' ============================
    Private Sub BindIntangibleLocationGrid()
        Dim subClass As String = If(Session("SubClassificationID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim dt As DataTable = GetIntangibleLocationData(subClass, gaId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvIntangibleLocationList.DataSource = dt
            gvIntangibleLocationList.DataBind()
        Else
            BindEmptyIntangibleLocationGrid()
        End If
    End Sub

    Private Function GetIntangibleLocationData(ByVal subClassId As String, ByVal gaId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("subClassId: " & subClassId)
            AddTrace("gaId: " & gaId)

            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Intangible_ListOfLocation] '" & subClassId & "', '" & gaId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading intangible locations: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyIntangibleLocationGrid()
        Dim dt As DataTable = CreateIntangibleLocationSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        gvIntangibleLocationList.DataSource = dt
        gvIntangibleLocationList.DataBind()
    End Sub

    Private Function CreateIntangibleLocationSchema() As DataTable
        Dim dt As New DataTable()
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
        Return dt
    End Function

    ' LOCATION EVENTS
    Protected Sub gvIntangibleLocationList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvIntangibleLocationList.PageIndex = e.NewPageIndex
        BindIntangibleLocationGrid()
    End Sub

    Protected Sub gvIntangibleLocationList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try

            If gvIntangibleLocationList.SelectedIndex >= 0 Then
                Dim selectedItemId As String = gvIntangibleLocationList.SelectedDataKey("Item_ID")
                Session("Item_ID") = selectedItemId
                BindIntangibleAssetsGrid()


                Dim dt As DataTable = GetIntangibleLedgerData(Nothing)

                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    'FormatBuildingLedgerTransType(dt)

                    grdIntangibleLedger.DataSource = dt
                    grdIntangibleLedger.DataBind()
                Else
                    BindEmptyIntangibleLedgerGrid()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvIntangibleLocationList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvIntangibleLocationList, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    ' ============================
    ' INTANGIBLE ASSETS LIST GRIDVIEW
    ' ============================
    Private Sub BindIntangibleAssetsGrid()
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        Try
            If gvIntangibleLocationList.SelectedIndex >= 0 Then
                itemParticularId = gvIntangibleLocationList.DataKeys(gvIntangibleLocationList.SelectedIndex).Values("item_particular_id").ToString()
                itemId = gvIntangibleLocationList.DataKeys(gvIntangibleLocationList.SelectedIndex).Values("Item_ID").ToString()
                declaredOwner = gvIntangibleLocationList.DataKeys(gvIntangibleLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
                barangay = gvIntangibleLocationList.DataKeys(gvIntangibleLocationList.SelectedIndex).Values("Barangay").ToString()
            End If

            AddTrace("itemParticularId: " & itemParticularId)
            AddTrace("itemId: " & itemId)

            AddTrace("gaId: " & gaId)
            AddTrace("declaredOwner: " & declaredOwner)
            AddTrace("barangay: " & barangay)

            Dim dt As DataTable = GetIntangibleAssetsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                grdListOfIntangibleAssets.DataSource = dt
                grdListOfIntangibleAssets.DataBind()
            Else
                BindEmptyIntangibleAssetsGrid()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function GetIntangibleAssetsData(ByVal itemParticularId As String, ByVal itemId As String, ByVal gaId As String,
                                            ByVal declaredOwner As String, ByVal barangay As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Intangible_ListOfIntangibleAssets] '" &
                                itemParticularId & "', '" & itemId & "', '" & gaId & "', '" & declaredOwner & "', '" & barangay & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading intangible assets list: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyIntangibleAssetsGrid()
        Dim dt As DataTable = CreateIntangibleAssetsSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdListOfIntangibleAssets.DataSource = dt
        grdListOfIntangibleAssets.DataBind()
    End Sub

    Private Function CreateIntangibleAssetsSchema() As DataTable
        Dim dt As New DataTable()

        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("AssetName", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("LicenseNo", GetType(String))
        dt.Columns.Add("Validity", GetType(String))
        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))

        dt.Columns.Add("Property_ID", GetType(String))
        dt.Columns.Add("PropertyDetai_ID", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))

        Return dt
    End Function

    ' ASSETS EVENTS
    Protected Sub grdListOfIntangibleAssets_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdListOfIntangibleAssets.PageIndex = e.NewPageIndex
        BindIntangibleAssetsGrid()
    End Sub

    Protected Sub grdListOfIntangibleAssets_SelectedIndexChanged(sender As Object, e As EventArgs)
        If grdListOfIntangibleAssets.SelectedIndex >= 0 Then
            loadUnit()

            Dim selectedPropertyId As String = grdListOfIntangibleAssets.SelectedDataKey("Property_ID")
            Session("Property_ID") = selectedPropertyId

            Dim propertyDtlId As String = grdListOfIntangibleAssets.DataKeys(grdListOfIntangibleAssets.SelectedIndex).Values("PropertyDetai_ID").ToString()
            'Dim itemId As String = grdListOfIntangibleAssets.DataKeys(grdListOfIntangibleAssets.SelectedIndex).Values("Item_ID").ToString()
            'Session("Item_ID") = itemId

            PopulateIntangibleInformation(propertyDtlId)
            BindIntangibleLedgerGrid()
        End If
    End Sub

    Protected Sub grdListOfIntangibleAssets_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdListOfIntangibleAssets, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    ' SEARCH BY PROPERTY NUMBER (INTANGIBLE)
    Protected Sub btnIntangiblePropSearch_Click(sender As Object, e As EventArgs)
        Dim searchText As String = txtIntangiblePropSearch.Text.Trim()

        ' If no search value → show full list using existing logic
        If String.IsNullOrEmpty(searchText) Then
            AddTrace("Intangible Search: empty, loading full list.")
            BindIntangibleAssetsGrid()
            Exit Sub
        End If

        ' Replicate the same parameter logic used in BindIntangibleAssetsGrid
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        If gvIntangibleLocationList.SelectedIndex >= 0 Then
            itemParticularId = gvIntangibleLocationList.DataKeys(gvIntangibleLocationList.SelectedIndex).Values("item_particular_id").ToString()
            itemId = gvIntangibleLocationList.DataKeys(gvIntangibleLocationList.SelectedIndex).Values("Item_ID").ToString()
            declaredOwner = gvIntangibleLocationList.DataKeys(gvIntangibleLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
            barangay = gvIntangibleLocationList.DataKeys(gvIntangibleLocationList.SelectedIndex).Values("Barangay").ToString()
        End If

        AddTrace("Intangible Search: " & searchText &
             " | itemParticularId=" & itemParticularId &
             " | itemId=" & itemId &
             " | gaId=" & gaId &
             " | declaredOwner=" & declaredOwner &
             " | barangay=" & barangay)

        ' Get the same dataset that BindIntangibleAssetsGrid would bind
        Dim dt As DataTable = GetIntangibleAssetsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BindEmptyIntangibleAssetsGrid()
            Exit Sub
        End If

        ' Filter by PropertyNo LIKE '%txtIntangiblePropSearch%'
        Dim dv As New DataView(dt)

        ' Escape special characters for RowFilter
        Dim safeSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("]", "]]")

        dv.RowFilter = "PropertyNo LIKE '%" & safeSearch & "%'"

        If dv.Count > 0 Then
            grdListOfIntangibleAssets.DataSource = dv
            grdListOfIntangibleAssets.DataBind()
        Else
            BindEmptyIntangibleAssetsGrid()
        End If
    End Sub



    ' ============================
    ' INTANGIBLE INFORMATION
    ' ============================
    Private Function GetIntangibleInformationData(ByVal propertyDtlId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("propertyDtlId: " & propertyDtlId)
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Intangible_GetInformation] '" & propertyDtlId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading intangible information: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub PopulateIntangibleInformation(ByVal propertyDtlId As String)
        Dim dt As DataTable = GetIntangibleInformationData(propertyDtlId)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearIntangibleInformationForm()
            Return
        End If

        Dim r As DataRow = dt.Rows(0)

        If dt.Columns.Contains("Name") Then txtIntangibleName.Text = r("Name").ToString()
        If dt.Columns.Contains("Description") Then txtIntangibleDescription.Text = r("Description").ToString()
        If dt.Columns.Contains("Warranty") Then txtIntangibleWarranty.Text = r("Warranty").ToString()
        If dt.Columns.Contains("PowerInput") Then txtIntangiblePowerInput.Text = r("PowerInput").ToString()
        If dt.Columns.Contains("Model") Then txtIntangibleModel.Text = r("Model").ToString()
        If dt.Columns.Contains("Dimension") Then txtIntangibleDimension.Text = r("Dimension").ToString()

        If dt.Columns.Contains("LicenseNo") Then txtIntangibleLicenseNo.Text = r("LicenseNo").ToString()
        If dt.Columns.Contains("Validity") Then txtIntangibleValidity.Text = r("Validity").ToString()

        If dt.Columns.Contains("Unit_ID") Then drpIntangibleUnit.SelectedValue = r("Unit_ID").ToString()
        If dt.Columns.Contains("Quantity") Then txtIntangibleQuantity.Text = r("Quantity").ToString()

        If dt.Columns.Contains("InstalledBuilding_ID") Then drpIntangibleInstalledBuilding.SelectedValue = r("InstalledBuilding_ID").ToString()

        If dt.Columns.Contains("Contractor") Then txtIntangibleContractor.Text = r("Contractor").ToString()
        If dt.Columns.Contains("ContactPerson") Then txtIntangibleContactPerson.Text = r("ContactPerson").ToString()
        If dt.Columns.Contains("ContactNo") Then txtIntangibleContactNo.Text = r("ContactNo").ToString()

        If dt.Columns.Contains("AcquisitionDate") AndAlso Not String.IsNullOrEmpty(r("AcquisitionDate").ToString()) Then
            txtIntangibleAcqDate.Text = Convert.ToDateTime(r("AcquisitionDate")).ToString("MM/dd/yyyy")
        End If

        If dt.Columns.Contains("MarketValue") Then txtIntangibleMarketValue.Text = FormatNumber(r("MarketValue"), 2)
        If dt.Columns.Contains("AcquisitionCost") Then txtIntangibleAcqCost.Text = FormatNumber(r("AcquisitionCost"), 2)
        If dt.Columns.Contains("NoYears") Then txtIntangibleNoYears.Text = r("NoYears").ToString()
        If dt.Columns.Contains("DepreciationRate") Then txtIntangibleDepRate.Text = FormatNumber(r("DepreciationRate"), 2)
        If dt.Columns.Contains("UsefulLife") Then txtIntangibleUsefulLife.Text = r("UsefulLife").ToString()
        If dt.Columns.Contains("DepreciationValue") Then txtIntangibleDepValue.Text = FormatNumber(r("DepreciationValue"), 2)
        If dt.Columns.Contains("SalvageValue") Then txtIntangibleSalvageValue.Text = FormatNumber(r("SalvageValue"), 2)
        If dt.Columns.Contains("DepreciatedValue") Then txtDepreciatedValueIntangibleNew.Text = FormatNumber(r("DepreciatedValue"), 2)

        If dt.Columns.Contains("Specifications") Then txtIntangibleSpecifications.Text = r("Specifications").ToString()

        If dt.Columns.Contains("InfoId") Then lbl_Intangible_InfoId.Text = r("InfoId").ToString()
        If dt.Columns.Contains("AssetId") Then lbl_Intangible_AssetId.Text = r("AssetId").ToString()
        lbl_Intangible_PropertyDetai_ID.Text = propertyDtlId
        If dt.Columns.Contains("Property_ID") Then lbl_Intangible_Property_ID.Text = r("Property_ID").ToString()
        If dt.Columns.Contains("Item_ID") Then lbl_Intangible_Item_ID.Text = r("Item_ID").ToString()

        If dt.Columns.Contains("useful_life") Then Session("useful_life") = r("useful_life").ToString()
    End Sub

    Private Sub ClearIntangibleInformationForm()
        txtIntangibleName.Text = ""
        txtIntangibleDescription.Text = ""
        txtIntangibleWarranty.Text = ""
        txtIntangiblePowerInput.Text = ""
        txtIntangibleModel.Text = ""
        txtIntangibleDimension.Text = ""
        txtIntangibleLicenseNo.Text = ""
        txtIntangibleValidity.Text = ""

        drpIntangibleUnit.SelectedIndex = -1
        txtIntangibleQuantity.Text = ""

        drpIntangibleInstalledBuilding.SelectedIndex = -1

        txtIntangibleContractor.Text = ""
        txtIntangibleContactPerson.Text = ""
        txtIntangibleContactNo.Text = ""

        txtIntangibleAcqDate.Text = ""
        txtIntangibleMarketValue.Text = ""
        txtIntangibleAcqCost.Text = ""
        txtIntangibleNoYears.Text = ""
        txtIntangibleDepRate.Text = ""
        txtIntangibleUsefulLife.Text = ""
        txtDepreciatedValueIntangibleNew.Text = ""
        txtIntangibleSalvageValue.Text = ""
        txtIntangibleDepValue.Text = ""
        txtIntangibleSpecifications.Text = ""

        lbl_Intangible_InfoId.Text = ""
        lbl_Intangible_AssetId.Text = ""
        lbl_Intangible_PropertyDetai_ID.Text = ""
        lbl_Intangible_Property_ID.Text = ""
        lbl_Intangible_Item_ID.Text = ""
    End Sub

    'Loading of Unit
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpIntangibleUnit.DataSource = dt
        drpIntangibleUnit.DataTextField = ("Description")
        drpIntangibleUnit.DataValueField = ("Unit_ID")
        drpIntangibleUnit.DataBind()
    End Sub

    ' ============================
    ' LEDGER GRIDVIEW (UNCHANGED)
    ' ============================
    Private Sub BindIntangibleLedgerGrid()
        Dim classificationId As String = If(Session("ClassificationID"), "0")
        Dim dt As DataTable = GetIntangibleLedgerData(classificationId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdIntangibleLedger.DataSource = dt
            grdIntangibleLedger.DataBind()
        Else
            BindEmptyIntangibleLedgerGrid()
        End If
    End Sub

    Private Function GetIntangibleLedgerData(ByVal classificationId As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Ledger_v2] '" & Session("Item_ID") & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading intangible ledger: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyIntangibleLedgerGrid()
        Dim dt As DataTable = CreateIntangibleLedgerSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdIntangibleLedger.DataSource = dt
        grdIntangibleLedger.DataBind()
    End Sub

    Private Function CreateIntangibleLedgerSchema() As DataTable
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

    Protected Sub OnIntangibleLedgerDataBound(sender As Object, e As EventArgs) Handles grdIntangibleLedger.DataBound
        ' reserved
    End Sub

    Protected Sub btnIntangiblePreview_Click(sender As Object, e As EventArgs) Handles btnIntangiblePreview.Click
        ' reserved
    End Sub

End Class
