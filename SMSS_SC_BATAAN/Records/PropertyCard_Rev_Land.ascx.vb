Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_PropertyCard_Rev_Land
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
            BindLandLocationGrid()
            BindLandsGrid()
            BindLandLedgerGrid()

            ' match reference behavior
            Session("GA_ID") = 0
            Session("SubClassificationID") = 0

            ddBrgy1.DataSource = objDerived.GetDataTable("Select * from dbo.tbl_Brgy_Invent", CommandType.Text)
            ddBrgy1.DataTextField = ("Brgy_Name")
            ddBrgy1.DataValueField = ("Brgy_ID")
            ddBrgy1.DataBind()

            ddBrgy1.Items.Insert(0, "Select")
        Else
            BindLandLocationGrid()
            BindLandsGrid()
        End If
    End Sub

    ' ============================
    ' REFRESH METHOD (called by main page)
    ' ============================
    Public Sub RefreshGridData()
        BindLandLocationGrid()

        If gvLandLocationList.SelectedIndex >= 0 Then
            BindLandsGrid()
        Else
            BindEmptyLandsGrid()
        End If

        BindLandLedgerGrid()
    End Sub

    ' ============================
    ' LIST OF LOCATION (LAND)
    ' ============================
    Private Sub BindLandLocationGrid()
        Dim subClassId As String = If(Session("SubClassificationID"), "0").ToString()
        Dim gaId As String = If(Session("GA_ID"), "0").ToString()

        Dim dt As DataTable = GetLandLocationData(subClassId, gaId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvLandLocationList.DataSource = dt
            gvLandLocationList.DataBind()
        Else
            BindEmptyLandLocationGrid()
        End If
    End Sub

    Private Function GetLandLocationData(ByVal subClassId As String, ByVal gaId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("LAND Location -> subClassId: " & subClassId)
            AddTrace("LAND Location -> gaId: " & gaId)

            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Land_ListOfLocation] '" & subClassId & "', '" & gaId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading land locations: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyLandLocationGrid()
        Dim dt As DataTable = CreateLandLocationSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        gvLandLocationList.DataSource = dt
        gvLandLocationList.DataBind()
    End Sub

    Private Function CreateLandLocationSchema() As DataTable
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
    Protected Sub gvLandLocationList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvLandLocationList.PageIndex = e.NewPageIndex
        BindLandLocationGrid()
    End Sub

    Protected Sub gvLandLocationList_SelectedIndexChanged(sender As Object, e As EventArgs)
        If gvLandLocationList.SelectedIndex >= 0 Then
            Dim selectedItemId As String = gvLandLocationList.SelectedDataKey("Item_ID")
            Session("Item_ID") = selectedItemId
            BindLandsGrid()
        End If
    End Sub

    Protected Sub gvLandLocationList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvLandLocationList, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub


    ' ============================
    ' LIST OF LANDS (child grid)
    ' ============================
    Protected Sub btnLandPropSearch_Click(sender As Object, e As EventArgs)
        Dim searchText As String = txtLandPropSearch.Text.Trim()

        ' If no search value → show full list using existing logic
        If String.IsNullOrEmpty(searchText) Then
            AddTrace("Land Search: empty, loading full list.")
            BindLandsGrid()
            Exit Sub
        End If

        ' Replicate the same parameter logic used in BindLandsGrid
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        ' Adjust gvLandLocationList to your actual location grid ID if different
        If gvLandLocationList.SelectedIndex >= 0 Then
            itemParticularId = gvLandLocationList.DataKeys(gvLandLocationList.SelectedIndex).Values("item_particular_id").ToString()
            itemId = gvLandLocationList.DataKeys(gvLandLocationList.SelectedIndex).Values("Item_ID").ToString()
            declaredOwner = gvLandLocationList.DataKeys(gvLandLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
            barangay = gvLandLocationList.DataKeys(gvLandLocationList.SelectedIndex).Values("Barangay").ToString()
        End If

        AddTrace("Land Search: " & searchText &
             " | itemParticularId=" & itemParticularId &
             " | itemId=" & itemId &
             " | gaId=" & gaId &
             " | declaredOwner=" & declaredOwner &
             " | barangay=" & barangay)

        ' Get the same dataset that BindLandsGrid would bind
        Dim dt As DataTable = GetLandsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BindEmptyLandsGrid()
            Exit Sub
        End If

        ' Filter by PropertyNo LIKE '%txtLandPropSearch%'
        Dim dv As New DataView(dt)

        ' Escape special characters for RowFilter
        Dim safeSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("]", "]]")

        dv.RowFilter = "PropertyNo LIKE '%" & safeSearch & "%'"

        If dv.Count > 0 Then
            grdListOfLands.DataSource = dv
            grdListOfLands.DataBind()
        Else
            BindEmptyLandsGrid()
        End If
    End Sub


    Private Sub BindLandsGrid()
        Dim itemId As String = If(Session("Item_ID"), "0").ToString()
        Dim gaId As String = If(Session("GA_ID"), "0").ToString()

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        Try

            If gvLandLocationList.SelectedIndex >= 0 Then
                itemParticularId = gvLandLocationList.DataKeys(gvLandLocationList.SelectedIndex).Values("item_particular_id").ToString()
                itemId = gvLandLocationList.DataKeys(gvLandLocationList.SelectedIndex).Values("Item_ID").ToString()
                declaredOwner = gvLandLocationList.DataKeys(gvLandLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
                barangay = gvLandLocationList.DataKeys(gvLandLocationList.SelectedIndex).Values("Barangay").ToString()
            End If

            AddTrace("LAND List -> itemParticularId: " & itemParticularId)
            AddTrace("LAND List -> itemId: " & itemId)
            AddTrace("LAND List -> gaId: " & gaId)
            AddTrace("LAND List -> declaredOwner: " & declaredOwner)
            AddTrace("LAND List -> barangay: " & barangay)

            Dim dt As DataTable = GetLandsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                grdListOfLands.DataSource = dt
                grdListOfLands.DataBind()
            Else
                BindEmptyLandsGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetLandsData(ByVal itemParticularId As String, ByVal itemId As String, ByVal gaId As String,
                                  ByVal declaredOwner As String, ByVal barangay As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String =
                "Exec [AMS].[PropertyCard_Rev_Land_ListOfLands] '" & itemParticularId & "', '" & itemId & "', '" & gaId & "', '" & declaredOwner & "', '" & barangay & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading lands list: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyLandsGrid()
        Dim dt As DataTable = CreateLandsSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdListOfLands.DataSource = dt
        grdListOfLands.DataBind()
    End Sub

    Private Function CreateLandsSchema() As DataTable
        Dim dt As New DataTable()

        ' === Columns shown in the grid ===
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("ItemType", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Barangay", GetType(String))
        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))

        ' === Columns used as DataKeys / backend ===
        dt.Columns.Add("Property_ID", GetType(String))
        dt.Columns.Add("PropertyDetai_ID", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("Received_ID", GetType(String))
        dt.Columns.Add("AcquisitionCost", GetType(Decimal))
        dt.Columns.Add("Received_Date", GetType(DateTime))
        dt.Columns.Add("Date_Accepted", GetType(DateTime))
        dt.Columns.Add("Received_Dtl_ID", GetType(String))

        Return dt
    End Function


    ' LANDS EVENTS
    Protected Sub grdListOfLands_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdListOfLands.PageIndex = e.NewPageIndex
        BindLandsGrid()
    End Sub

    Protected Sub grdListOfLands_SelectedIndexChanged(sender As Object, e As EventArgs)
        If grdListOfLands.SelectedIndex >= 0 Then
            LoadBarangay()

            Dim selectedPropertyId As String = grdListOfLands.SelectedDataKey("Property_ID")
            Session("Property_ID") = selectedPropertyId

            Dim propertyDtlId As String =
                grdListOfLands.DataKeys(grdListOfLands.SelectedIndex).Values("PropertyDetai_ID").ToString()

            PopulateLandInformation(propertyDtlId)

            RefreshGridData()
        End If
    End Sub

    Protected Sub grdListOfLands_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdListOfLands, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    Protected Sub grdListOfLands_OnDataBound(sender As Object, e As EventArgs)
        ' reserved for future binding logic
    End Sub


    ' ============================
    ' LAND INFORMATION
    ' ============================
    Private Function GetLandInformationData(ByVal propertyDtlId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("LAND Info -> propertyDtlId: " & propertyDtlId)
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Land_GetInformation] '" & propertyDtlId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading land information: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub PopulateLandInformation(ByVal propertyDtlId As String)
        Dim dt As DataTable = GetLandInformationData(propertyDtlId)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearLandInformationForm()
            Return
        End If

        Dim r As DataRow = dt.Rows(0)

        ' =======================
        ' MAIN LAND INFORMATION
        ' =======================



        If dt.Columns.Contains("FullAddress") Then
            txtLocation.Text = r("FullAddress").ToString()
        Else
            txtLocation.Text = ""
        End If

        ' Brgy (dropdown) – use ID from SP as SelectedValue
        ddBrgy1.ClearSelection()

        Dim brgyId As String = ""
        Dim brgyName As String = ""

        If dt.Columns.Contains("Barangay") Then
            brgyId = r("Barangay").ToString()
        End If
        If dt.Columns.Contains("Barangay1") Then
            brgyName = r("Barangay1").ToString()
        End If

        ' 1st priority: use Brgy_ID from SP (Barangay)
        If Not String.IsNullOrEmpty(brgyId) Then
            Dim liByValue = ddBrgy1.Items.FindByValue(brgyId)
            If liByValue IsNot Nothing Then
                liByValue.Selected = True
            End If
            ' if ID not found, keep dropdown as-is (Select)
        ElseIf Not String.IsNullOrEmpty(brgyName) Then
            ' Fallback: try match by barangay name
            Dim liByText = ddBrgy1.Items.FindByText(brgyName)
            If liByText IsNot Nothing Then
                liByText.Selected = True
            End If
        End If


        ' Area (sqm)
        If dt.Columns.Contains("AreaUnit") Then
            txtArea.Text = r("AreaUnit").ToString()
        Else
            txtArea.Text = ""
        End If

        ' Certificate of ownership (Titled / Tax Declaration)
        ' Assumes SP returns some descriptive field; map loosely.
        Dim certType As String = ""
        If dt.Columns.Contains("CertificateOfOwnership") Then
            certType = r("CertificateOfOwnership").ToString()
        ElseIf dt.Columns.Contains("CertificateType") Then
            certType = r("CertificateType").ToString()
        ElseIf dt.Columns.Contains("TaxDeclarationNo") Then
            certType = r("TaxDeclarationNo").ToString()
        End If

        ddTaxDecNo.SelectedValue = "0" ' default: Select
        If certType <> "" Then
            Dim upperCert = certType.ToUpperInvariant()
            If upperCert.Contains("TITLE") OrElse upperCert.Contains("TCT") OrElse upperCert.Contains("OCT") Then
                ddTaxDecNo.SelectedValue = "1"   ' Titled
            ElseIf upperCert.Contains("TAX") Then
                ddTaxDecNo.SelectedValue = "2"   ' Tax Declaration
            End If
        End If

        ' Present Owner
        If dt.Columns.Contains("PresentOwner") Then
            txtPrevOwner.Text = r("PresentOwner").ToString()
        ElseIf dt.Columns.Contains("OwnerName") Then
            txtPrevOwner.Text = r("OwnerName").ToString()
        ElseIf dt.Columns.Contains("CorporationName") Then
            txtPrevOwner.Text = r("CorporationName").ToString()
        Else
            txtPrevOwner.Text = ""
        End If

        ' Description
        If dt.Columns.Contains("Description") Then
            txtDescription.Text = r("Description").ToString()
        ElseIf dt.Columns.Contains("ItemType") Then
            txtDescription.Text = r("ItemType").ToString()
        Else
            txtDescription.Text = ""
        End If

        ' Unit of measurement
        If dt.Columns.Contains("AreaUnit") Then
            txtUnit.Text = r("AreaUnit").ToString()
        ElseIf dt.Columns.Contains("Unit") Then
            txtUnit.Text = r("Unit").ToString()
        Else
            txtUnit.Text = ""
        End If

        ' =======================
        ' ACQUISITION
        ' =======================

        ' Acquisition Date
        txtEAcqDate.Text = ""
        If dt.Columns.Contains("AcquisitionDate") AndAlso Not IsDBNull(r("AcquisitionDate")) AndAlso r("AcquisitionDate").ToString() <> "" Then
            txtEAcqDate.Text = Convert.ToDateTime(r("AcquisitionDate")).ToString("MM/dd/yyyy")
        ElseIf dt.Columns.Contains("DatePurchased") AndAlso Not IsDBNull(r("DatePurchased")) AndAlso r("DatePurchased").ToString() <> "" Then
            txtEAcqDate.Text = Convert.ToDateTime(r("DatePurchased")).ToString("MM/dd/yyyy")
        ElseIf dt.Columns.Contains("AcqDate") Then
            txtEAcqDate.Text = r("AcqDate").ToString()
        End If

        ' Acquisition Cost
        txtAcqCost.Text = ""
        If dt.Columns.Contains("AcquisitionCost") Then
            If Not IsDBNull(r("AcquisitionCost")) Then
                Dim v As Decimal
                If Decimal.TryParse(r("AcquisitionCost").ToString(), v) Then
                    txtAcqCost.Text = FormatNumber(v, 2)
                Else
                    txtAcqCost.Text = r("AcquisitionCost").ToString()
                End If
            End If
        ElseIf dt.Columns.Contains("AcqCost") Then
            txtAcqCost.Text = r("AcqCost").ToString()
        End If

        ' Acquisition Mode
        txtAcqMode.Text = ""
        If dt.Columns.Contains("TypeAcquisition") Then
            txtAcqMode.Text = r("TypeAcquisition").ToString()
        ElseIf dt.Columns.Contains("AcquisitionMode") Then
            txtAcqMode.Text = r("AcquisitionMode").ToString()
        End If

        ' Market Value (main)
        txtMarketValue.Text = ""

        If dt.Columns.Contains("MarketValue") Then
            Dim rawMarketValue As String = ""

            If Not IsDBNull(r("MarketValue")) Then
                rawMarketValue = r("MarketValue").ToString().Trim()
            End If

            AddTrace("Raw MarketValue from dt: [" & rawMarketValue & "]")

            Dim v As Decimal
            If rawMarketValue <> "" AndAlso Decimal.TryParse(rawMarketValue, v) Then
                txtMarketValue.Text = FormatNumber(v, 2)
                AddTrace("Formatted MarketValue: " & txtMarketValue.Text)
            Else
                txtMarketValue.Text = "0.00"
                AddTrace("Formatted MarketValue defaulted to: 0.00")
            End If
        Else
            txtMarketValue.Text = "0.00"
            AddTrace("MarketValue column not found. Defaulted to: 0.00")
        End If
        ' Property Number
        txtPropertyNumber.Text = ""
        If dt.Columns.Contains("PropertyNo") Then
            txtPropertyNumber.Text = r("PropertyNo").ToString()
        End If

        ' Remarks
        txtRemarks.Text = ""
        If dt.Columns.Contains("Remarks") Then
            txtRemarks.Text = r("Remarks").ToString()
        End If

        ' =======================
        ' PROPERTY IDENTIFICATION
        ' =======================

        If dt.Columns.Contains("LGUCode") Then txtLGUCode.Text = r("LGUCode").ToString() Else txtLGUCode.Text = ""
        If dt.Columns.Contains("DistrictCode") Then txtDistrictCode.Text = r("DistrictCode").ToString() Else txtDistrictCode.Text = ""
        If dt.Columns.Contains("CityMunCode") Then txtCityCode.Text = r("CityMunCode").ToString() Else txtCityCode.Text = ""
        If dt.Columns.Contains("BrgyCode") Then txtBrgyCode.Text = r("BrgyCode").ToString() Else txtBrgyCode.Text = ""

        If dt.Columns.Contains("SectionNo") Then txtSectionNo.Text = r("SectionNo").ToString() Else txtSectionNo.Text = ""
        If dt.Columns.Contains("ParcelNo") Then txtParcelNo.Text = r("ParcelNo").ToString() Else txtParcelNo.Text = ""
        If dt.Columns.Contains("SeriesNo") Then txtSeriesNo.Text = r("SeriesNo").ToString() Else txtSeriesNo.Text = ""
        If dt.Columns.Contains("RPTIN") Then txtRPTIN.Text = r("RPTIN").ToString() Else txtRPTIN.Text = ""
        If dt.Columns.Contains("PIN") Then txtPIN.Text = r("PIN").ToString() Else txtPIN.Text = ""
        If dt.Columns.Contains("ARP") Then txtARP.Text = r("ARP").ToString() Else txtARP.Text = ""
        If dt.Columns.Contains("TDN") Then txtTDN.Text = r("TDN").ToString() Else txtTDN.Text = ""
        If dt.Columns.Contains("RevYear") Then txtRevYear.Text = r("RevYear").ToString() Else txtRevYear.Text = ""

        ' =======================
        ' LOCATION DETAILS
        ' =======================
        If dt.Columns.Contains("LotNo") Then txtLotNo.Text = r("LotNo").ToString() Else txtLotNo.Text = ""
        If dt.Columns.Contains("Street") Then txtStreet.Text = r("Street").ToString() Else txtStreet.Text = ""
        If dt.Columns.Contains("Purok") Then txtPurok.Text = r("Purok").ToString() Else txtPurok.Text = ""
        If dt.Columns.Contains("PhaseNo") Then txtPhaseNo.Text = r("PhaseNo").ToString() Else txtPhaseNo.Text = ""
        If dt.Columns.Contains("BlkNo") Then txtBlkNo.Text = r("BlkNo").ToString() Else txtBlkNo.Text = ""
        If dt.Columns.Contains("Subdivision") Then txtSubdivision.Text = r("Subdivision").ToString() Else txtSubdivision.Text = ""
        If dt.Columns.Contains("Sitio") Then txtSitio.Text = r("Sitio").ToString() Else txtSitio.Text = ""

        If dt.Columns.Contains("Barangay") Then txtBrgy.Text = r("Barangay").ToString() Else txtBrgy.Text = ""
        If dt.Columns.Contains("CityMunicipal") Then txtCityMun.Text = r("CityMunicipal").ToString() Else txtCityMun.Text = ""
        If dt.Columns.Contains("Region") Then TxtRegion.Text = r("Region").ToString() Else TxtRegion.Text = ""
        If dt.Columns.Contains("District") Then txtDistrict.Text = r("District").ToString() Else txtDistrict.Text = ""
        If dt.Columns.Contains("Province") Then txtProvince.Text = r("Province").ToString() Else txtProvince.Text = ""
        If dt.Columns.Contains("ZipCode") Then txtZipCode.Text = r("ZipCode").ToString() Else txtZipCode.Text = ""

        ' =======================
        ' CHARACTERISTICS
        ' =======================
        If dt.Columns.Contains("LandClassification") Then
            txtClassification.Text = r("LandClassification").ToString()
        ElseIf dt.Columns.Contains("Classification") Then
            txtClassification.Text = r("Classification").ToString()
        Else
            txtClassification.Text = ""
        End If

        If dt.Columns.Contains("SubClass") Then
            txtSubClass.Text = r("SubClass").ToString()
        Else
            txtSubClass.Text = ""
        End If

        If dt.Columns.Contains("LandUse") Then
            txtLandUse.Text = r("LandUse").ToString()
        Else
            txtLandUse.Text = ""
        End If

        If dt.Columns.Contains("Taxable") Then
            txtTaxable.Text = r("Taxable").ToString()
        Else
            txtTaxable.Text = ""
        End If

        If dt.Columns.Contains("SubClassArea") Then
            txtSubClassArea.Text = r("SubClassArea").ToString()
        Else
            txtSubClassArea.Text = ""
        End If

        ' Assessed / Market / Unit values (characteristics block)
        txtAssessedValue.Text = ""
        If dt.Columns.Contains("AssessedValue") Then
            If Not IsDBNull(r("AssessedValue")) Then
                Dim v As Decimal
                If Decimal.TryParse(r("AssessedValue").ToString(), v) Then
                    txtAssessedValue.Text = FormatNumber(v, 2)
                Else
                    txtAssessedValue.Text = r("AssessedValue").ToString()
                End If
            End If
        End If

        txtCharacteristicsMarketValue.Text = ""
        If dt.Columns.Contains("CharacteristicsMarketValue") Then
            Dim v As Decimal
            If Decimal.TryParse(r("CharacteristicsMarketValue").ToString(), v) Then
                txtCharacteristicsMarketValue.Text = FormatNumber(v, 2)
            Else
                txtCharacteristicsMarketValue.Text = r("CharacteristicsMarketValue").ToString()
            End If
        ElseIf txtCharacteristicsMarketValue.Text = "" AndAlso txtMarketValue.Text <> "" Then
            ' fallback: use main market value
            txtCharacteristicsMarketValue.Text = txtMarketValue.Text
        End If

        txtUnitValue.Text = ""
        If dt.Columns.Contains("UnitValue") Then
            Dim v As Decimal
            If Decimal.TryParse(r("UnitValue").ToString(), v) Then
                txtUnitValue.Text = FormatNumber(v, 2)
            Else
                txtUnitValue.Text = r("UnitValue").ToString()
            End If
        End If

        ' Dates in characteristics
        txtAssessedValueDate.Text = ""
        If dt.Columns.Contains("AssessedDate") AndAlso Not IsDBNull(r("AssessedDate")) AndAlso r("AssessedDate").ToString() <> "" Then
            txtAssessedValueDate.Text = Convert.ToDateTime(r("AssessedDate")).ToString("MM/dd/yyyy")
        ElseIf dt.Columns.Contains("AssessedValueDate") AndAlso Not IsDBNull(r("AssessedValueDate")) AndAlso r("AssessedValueDate").ToString() <> "" Then
            txtAssessedValueDate.Text = Convert.ToDateTime(r("AssessedValueDate")).ToString("MM/dd/yyyy")
        End If

        txtMarketValueDate.Text = ""
        If dt.Columns.Contains("MarketValueDate") AndAlso Not IsDBNull(r("MarketValueDate")) AndAlso r("MarketValueDate").ToString() <> "" Then
            txtMarketValueDate.Text = Convert.ToDateTime(r("MarketValueDate")).ToString("MM/dd/yyyy")
        End If

        txtUnitValueDate.Text = ""
        If dt.Columns.Contains("UnitValueDate") AndAlso Not IsDBNull(r("UnitValueDate")) AndAlso r("UnitValueDate").ToString() <> "" Then
            txtUnitValueDate.Text = Convert.ToDateTime(r("UnitValueDate")).ToString("MM/dd/yyyy")
        End If

        ' Amounts
        If dt.Columns.Contains("AssessedValueAmount") Then
            txtAssessedValueAmount.Text = r("AssessedValueAmount").ToString()
        Else
            txtAssessedValueAmount.Text = ""
        End If

        If dt.Columns.Contains("MarketValueAmount") Then
            txtMarketValueAmount.Text = r("MarketValueAmount").ToString()
        Else
            txtMarketValueAmount.Text = ""
        End If

        ' Assessment / remarks (last textbox)
        If dt.Columns.Contains("Assessment") Then
            TextBox3.Text = r("Assessment").ToString()
        Else
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub ClearLandInformationForm()
        ' Main info
        txtLocation.Text = ""
        If ddBrgy1.Items.Count > 0 Then ddBrgy1.ClearSelection()
        txtArea.Text = ""
        Label1.Text = ""
        ddTaxDecNo.SelectedValue = "0"
        txtPrevOwner.Text = ""
        txtDescription.Text = ""
        txtUnit.Text = ""

        ' Acquisition
        txtEAcqDate.Text = ""
        txtAcqCost.Text = ""
        txtAcqMode.Text = ""
        txtMarketValue.Text = ""
        txtPropertyNumber.Text = ""
        txtRemarks.Text = ""

        ' Property identification
        txtLGUCode.Text = ""
        txtDistrictCode.Text = ""
        txtCityCode.Text = ""
        txtBrgyCode.Text = ""
        txtSectionNo.Text = ""
        txtParcelNo.Text = ""
        txtSeriesNo.Text = ""
        txtRPTIN.Text = ""
        txtPIN.Text = ""
        txtARP.Text = ""
        txtTDN.Text = ""
        txtRevYear.Text = ""

        ' Location details
        txtLotNo.Text = ""
        txtStreet.Text = ""
        txtPurok.Text = ""
        txtPhaseNo.Text = ""
        txtBlkNo.Text = ""
        txtSubdivision.Text = ""
        txtSitio.Text = ""
        txtBrgy.Text = ""
        txtCityMun.Text = ""
        TxtRegion.Text = ""
        txtDistrict.Text = ""
        txtProvince.Text = ""
        txtZipCode.Text = ""

        ' Characteristics
        txtClassification.Text = ""
        txtSubClass.Text = ""
        txtLandUse.Text = ""
        txtTaxable.Text = ""
        txtSubClassArea.Text = ""

        txtAssessedValue.Text = ""
        txtCharacteristicsMarketValue.Text = ""
        txtUnitValue.Text = ""
        txtAssessedValueDate.Text = ""
        txtMarketValueDate.Text = ""
        txtUnitValueDate.Text = ""
        txtAssessedValueAmount.Text = ""
        txtMarketValueAmount.Text = ""
        TextBox3.Text = ""

        ' Image / upload (keep disabled, just reset image)
        imgpropertydocs.ImageUrl = "~/images/blankImage.jpg"
    End Sub


    Public Sub LoadBarangay()
        ddBrgy1.DataSource = objDerived.GetDataTable("Select * from dbo.tbl_Brgy_Invent", CommandType.Text)
        ddBrgy1.DataTextField = ("Brgy_Name")
        ddBrgy1.DataValueField = ("Brgy_ID")
        ddBrgy1.DataBind()
        ddBrgy1.Items.Insert(0, "Select")
    End Sub

    ' ============================
    ' TRANSACTIONS / LEDGER
    ' (uses same SP as reference)
    ' ============================
    Private Sub BindLandLedgerGrid()
        Dim classificationId As String = If(Session("ClassificationID"), "0").ToString()

        Dim dt As DataTable = GetLandLedgerData(classificationId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdLandLedger.DataSource = dt
            grdLandLedger.DataBind()
        Else
            BindEmptyLandLedgerGrid()
        End If
    End Sub

    Private Function GetLandLedgerData(ByVal classificationId As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Ledger] '" & classificationId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading land ledger: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyLandLedgerGrid()
        Dim dt As DataTable = CreateLandLedgerSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdLandLedger.DataSource = dt
        grdLandLedger.DataBind()
    End Sub

    Private Function CreateLandLedgerSchema() As DataTable
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
    Protected Sub OnLandLedgerDataBound(sender As Object, e As EventArgs)
        ' reserved
    End Sub

    Protected Sub btnLandPreview_Click(sender As Object, e As EventArgs)
        ' reserved
    End Sub

End Class
