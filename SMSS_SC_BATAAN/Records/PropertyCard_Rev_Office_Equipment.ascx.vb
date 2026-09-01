Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_PropertyCard_Rev_Office_Equipment
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
            BindOfficeEquipmentGrid()
            BindOfficeEquipmentsGrid()
            BindOfficeEquipmentLedgerGrid()

            Session("GA_ID") = 0
            Session("SubClassificationID") = 0
        Else
            BindOfficeEquipmentGrid()
            BindOfficeEquipmentsGrid()
        End If
    End Sub

    ' ============================
    ' REFRESH METHOD (same pattern)
    ' ============================
    Public Sub RefreshGridData()
        BindOfficeEquipmentGrid()

        If gvOfficeEquipmentLocationList.SelectedIndex >= 0 Then
            BindOfficeEquipmentsGrid()
        Else
            BindEmptyOfficeEquipmentsGrid()
        End If

        BindOfficeEquipmentLedgerGrid()
    End Sub

    ' ============================
    ' LOCATION GRIDVIEW FUNCTIONS
    ' ============================
    Private Sub BindOfficeEquipmentGrid()
        Dim subClass As String = If(Session("SubClassificationID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim dt As DataTable = GetOfficeEquipmentLocationData(subClass, gaId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvOfficeEquipmentLocationList.DataSource = dt
            gvOfficeEquipmentLocationList.DataBind()
        Else
            BindEmptyOfficeEquipmentGrid()
        End If
    End Sub

    Private Function GetOfficeEquipmentLocationData(ByVal subClassId As String, ByVal gaId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("subClassId: " & subClassId)
            AddTrace("gaId: " & gaId)

            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_OfficeEquipment_ListOfLocation] '" & subClassId & "', '" & gaId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading office equipment locations: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyOfficeEquipmentGrid()
        Dim dt As DataTable = CreateOfficeEquipmentLocationSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        gvOfficeEquipmentLocationList.DataSource = dt
        gvOfficeEquipmentLocationList.DataBind()
    End Sub

    Private Function CreateOfficeEquipmentLocationSchema() As DataTable
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
    Protected Sub gvOfficeEquipmentLocationList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvOfficeEquipmentLocationList.PageIndex = e.NewPageIndex
        BindOfficeEquipmentGrid()
    End Sub

    Protected Sub gvOfficeEquipmentLocationList_SelectedIndexChanged(sender As Object, e As EventArgs)
        If gvOfficeEquipmentLocationList.SelectedIndex >= 0 Then
            Dim selectedItemId As String = gvOfficeEquipmentLocationList.SelectedDataKey("Item_ID")
            Session("Item_ID") = selectedItemId
            BindOfficeEquipmentsGrid()

            Dim dt As DataTable = GetOfficeEquipmentLedgerData(Nothing)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                FormatOfficeLedgerTransType(dt)

                grdOfficeEquipmentLedger.DataSource = dt
                grdOfficeEquipmentLedger.DataBind()
            Else
                BindEmptyOfficeEquipmentLedgerGrid()
            End If
        End If
    End Sub


    Private Sub FormatOfficeLedgerTransType(ByVal dt As DataTable)

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

    Protected Sub gvOfficeEquipmentLocationList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvOfficeEquipmentLocationList, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    ' ============================
    ' OFFICE EQUIPMENTS LIST GRIDVIEW
    ' ============================
    Protected Sub btnOfficeEquipmentPropSearch_Click(sender As Object, e As EventArgs)
        Dim searchText As String = txtOfficeEquipmentPropSearch.Text.Trim()

        ' If no search value → show full list using existing logic
        If String.IsNullOrEmpty(searchText) Then
            AddTrace("Office Equipment Search: empty, loading full list.")
            BindOfficeEquipmentsGrid()
            Exit Sub
        End If

        ' Replicate the same parameter logic used in BindOfficeEquipmentsGrid
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        If gvOfficeEquipmentLocationList.SelectedIndex >= 0 Then
            itemParticularId = gvOfficeEquipmentLocationList.DataKeys(gvOfficeEquipmentLocationList.SelectedIndex).Values("item_particular_id").ToString()
            itemId = gvOfficeEquipmentLocationList.DataKeys(gvOfficeEquipmentLocationList.SelectedIndex).Values("Item_ID").ToString()
            declaredOwner = gvOfficeEquipmentLocationList.DataKeys(gvOfficeEquipmentLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
            barangay = gvOfficeEquipmentLocationList.DataKeys(gvOfficeEquipmentLocationList.SelectedIndex).Values("Barangay").ToString()
        End If

        AddTrace("Office Equipment Search: " & searchText &
             " | itemParticularId=" & itemParticularId &
             " | itemId=" & itemId &
             " | gaId=" & gaId &
             " | declaredOwner=" & declaredOwner &
             " | barangay=" & barangay)

        ' Get the same dataset that BindOfficeEquipmentsGrid would bind
        Dim dt As DataTable = GetOfficeEquipmentsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BindEmptyOfficeEquipmentsGrid()
            Exit Sub
        End If

        ' Filter by PropertyNo LIKE '%txtOfficeEquipmentPropSearch%'
        Dim dv As New DataView(dt)

        ' Escape special characters for RowFilter
        Dim safeSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("]", "]]")

        dv.RowFilter = "PropertyNo LIKE '%" & safeSearch & "%'"

        If dv.Count > 0 Then
            grdListOfOfficeEquipments.DataSource = dv
            grdListOfOfficeEquipments.DataBind()
        Else
            BindEmptyOfficeEquipmentsGrid()
        End If
    End Sub


    Private Sub BindOfficeEquipmentsGrid()
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        Try
            If gvOfficeEquipmentLocationList.SelectedIndex >= 0 Then
                itemParticularId = gvOfficeEquipmentLocationList.DataKeys(gvOfficeEquipmentLocationList.SelectedIndex).Values("item_particular_id").ToString()
                itemId = gvOfficeEquipmentLocationList.DataKeys(gvOfficeEquipmentLocationList.SelectedIndex).Values("Item_ID").ToString()
                declaredOwner = gvOfficeEquipmentLocationList.DataKeys(gvOfficeEquipmentLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
                barangay = gvOfficeEquipmentLocationList.DataKeys(gvOfficeEquipmentLocationList.SelectedIndex).Values("Barangay").ToString()
            End If

            AddTrace("itemParticularId: " & itemParticularId)
            AddTrace("itemId: " & itemId)
            AddTrace("gaId: " & gaId)
            AddTrace("declaredOwner: " & declaredOwner)
            AddTrace("barangay: " & barangay)

            Dim dt As DataTable = GetOfficeEquipmentsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                grdListOfOfficeEquipments.DataSource = dt
                grdListOfOfficeEquipments.DataBind()
            Else
                BindEmptyOfficeEquipmentsGrid()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function GetOfficeEquipmentsData(ByVal itemParticularId As String, ByVal itemId As String, ByVal gaId As String, ByVal declaredOwner As String, ByVal barangay As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_OfficeEquipment_ListOfOfficeEquipments] '" & itemParticularId & "', '" & itemId & "', '" & gaId & "', '" & declaredOwner & "', '" & barangay & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading office equipments: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyOfficeEquipmentsGrid()
        Dim dt As DataTable = CreateOfficeEquipmentsSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdListOfOfficeEquipments.DataSource = dt
        grdListOfOfficeEquipments.DataBind()
    End Sub

    Private Function CreateOfficeEquipmentsSchema() As DataTable
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

    ' OFFICE EQUIPMENTS EVENTS
    Protected Sub grdListOfOfficeEquipments_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdListOfOfficeEquipments.PageIndex = e.NewPageIndex
        BindOfficeEquipmentsGrid()
    End Sub

    Protected Sub grdListOfOfficeEquipments_SelectedIndexChanged(sender As Object, e As EventArgs)
        If grdListOfOfficeEquipments.SelectedIndex >= 0 Then
            loadUnit()

            Dim selectedPropertyId As String = grdListOfOfficeEquipments.SelectedDataKey("Property_ID")
            Session("Property_ID") = selectedPropertyId

            Dim propertyDtlId As String = grdListOfOfficeEquipments.DataKeys(grdListOfOfficeEquipments.SelectedIndex).Values("PropertyDetai_ID").ToString()
            PopulateOfficeEquipmentInformation(propertyDtlId)

            RefreshGridData()
        End If
    End Sub

    Protected Sub grdListOfOfficeEquipments_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdListOfOfficeEquipments, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    Protected Sub grdListOfOfficeEquipments_OnDataBound(sender As Object, e As EventArgs)
        ' reserved for future binding logic
    End Sub

    ' ============================
    ' OFFICE EQUIPMENT INFORMATION
    ' ============================
    Private Function GetOfficeEquipmentInformationData(ByVal propertyDtlId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("propertyDtlId: " & propertyDtlId)
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_OfficeEquipment_GetInformation] '" & propertyDtlId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading office equipment information: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub PopulateOfficeEquipmentInformation(ByVal propertyDtlId As String)
        Dim dt As DataTable = GetOfficeEquipmentInformationData(propertyDtlId)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearOfficeEquipmentInformationForm()
            Return
        End If

        Dim r As DataRow = dt.Rows(0)

        If dt.Columns.Contains("Name") Then txtOfficeEquipmentName.Text = r("Name").ToString()
        If dt.Columns.Contains("Description") Then txtOfficeEquipmentDesc.Text = r("Description").ToString()
        If dt.Columns.Contains("Warranty") Then txtOfficeEquipmentWarranty.Text = r("Warranty").ToString()
        If dt.Columns.Contains("PowerInput") Then txtOfficeEquipmentPowerInput.Text = r("PowerInput").ToString()
        If dt.Columns.Contains("Model") Then txtOfficeEquipmentModel.Text = r("Model").ToString()
        If dt.Columns.Contains("Dimension") Then txtOfficeEquipmentDimension.Text = r("Dimension").ToString()
        If dt.Columns.Contains("SerialNo") Then txtOfficeEquipmentSerialNo.Text = r("SerialNo").ToString()

        If dt.Columns.Contains("Unit_ID") Then drpOfficeEquipmentUnit.SelectedValue = r("Unit_ID").ToString()
        If dt.Columns.Contains("Quantity") Then txtOfficeEquipmentQuantity.Text = r("Quantity").ToString()
        If dt.Columns.Contains("Remarks") Then txtOfficeEquipmentRemarks.Text = r("Remarks").ToString()


        If dt.Columns.Contains("Contractor") Then txtOfficeEquipmentContractor.Text = r("Contractor").ToString()
        If dt.Columns.Contains("ContactPerson") Then txtOfficeEquipmentContactPerson.Text = r("ContactPerson").ToString()
        If dt.Columns.Contains("ContactNo") Then txtOfficeEquipmentContactNo.Text = r("ContactNo").ToString()

        If dt.Columns.Contains("AcquisitionDate") AndAlso Not String.IsNullOrEmpty(r("AcquisitionDate").ToString()) Then
            txtOfficeEquipmentAcqDate.Text = Convert.ToDateTime(r("AcquisitionDate")).ToString("MM/dd/yyyy")
        End If

        If dt.Columns.Contains("MarketValue") Then txtOfficeEquipmentMarketValue.Text = FormatNumber(r("MarketValue"), 2)
        If dt.Columns.Contains("AcquisitionCost") Then txtOfficeEquipmentAcqCost.Text = FormatNumber(r("AcquisitionCost"), 2)
        If dt.Columns.Contains("NoYears") Then txtOfficeEquipmentNoYears.Text = r("NoYears").ToString()
        If dt.Columns.Contains("DepreciationRate") Then txtOfficeEquipmentDepRate.Text = FormatNumber(r("DepreciationRate"), 2)
        If dt.Columns.Contains("UsefulLife") Then txtOfficeEquipmentUsefulLife.Text = r("UsefulLife").ToString()
        If dt.Columns.Contains("DepreciationValue") Then txtOfficeEquipmentDepValue.Text = FormatNumber(r("DepreciationValue"), 2)
        If dt.Columns.Contains("SalvageValue") Then txtOfficeEquipmentSalvageValue.Text = FormatNumber(r("SalvageValue"), 2)
        If dt.Columns.Contains("DepreciatedValue") Then txtDepreciatedValueOfficeEquipmentNew.Text = FormatNumber(r("DepreciatedValue"), 2)

        If dt.Columns.Contains("useful_life") Then Session("useful_life") = r("useful_life").ToString()
    End Sub

    Private Sub ClearOfficeEquipmentInformationForm()
        txtOfficeEquipmentName.Text = ""
        txtOfficeEquipmentDesc.Text = ""
        txtOfficeEquipmentWarranty.Text = ""
        txtOfficeEquipmentPowerInput.Text = ""
        txtOfficeEquipmentModel.Text = ""
        txtOfficeEquipmentDimension.Text = ""
        txtOfficeEquipmentSerialNo.Text = ""

        drpOfficeEquipmentUnit.SelectedIndex = -1
        txtOfficeEquipmentQuantity.Text = ""

        txtOfficeEquipmentRemarks.Text = ""

        txtOfficeEquipmentContractor.Text = ""
        txtOfficeEquipmentContactPerson.Text = ""
        txtOfficeEquipmentContactNo.Text = ""

        txtOfficeEquipmentAcqDate.Text = ""
        txtOfficeEquipmentMarketValue.Text = ""
        txtOfficeEquipmentAcqCost.Text = ""
        txtOfficeEquipmentNoYears.Text = ""
        txtOfficeEquipmentDepRate.Text = ""
        txtOfficeEquipmentUsefulLife.Text = ""
        txtDepreciatedValueOfficeEquipmentNew.Text = ""
        txtOfficeEquipmentSalvageValue.Text = ""
        txtOfficeEquipmentDepValue.Text = ""
    End Sub

    'Loading of Unit
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpOfficeEquipmentUnit.DataSource = dt
        drpOfficeEquipmentUnit.DataTextField = ("Description")
        drpOfficeEquipmentUnit.DataValueField = ("Unit_ID")
        drpOfficeEquipmentUnit.DataBind()
    End Sub



    ' ============================
    ' LEDGER GRIDVIEW
    ' ============================
    Private Sub BindOfficeEquipmentLedgerGrid()
        Dim classificationId As String = If(Session("ClassificationID"), "0")

        Dim dt As DataTable = GetOfficeEquipmentLedgerData(classificationId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdOfficeEquipmentLedger.DataSource = dt
            grdOfficeEquipmentLedger.DataBind()
        Else
            BindEmptyOfficeEquipmentLedgerGrid()
        End If
    End Sub

    Private Function GetOfficeEquipmentLedgerData(ByVal classificationId As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Ledger_v2] '" & Session("Item_ID") & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading office equipment ledger: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyOfficeEquipmentLedgerGrid()
        Dim dt As DataTable = CreateOfficeEquipmentLedgerSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdOfficeEquipmentLedger.DataSource = dt
        grdOfficeEquipmentLedger.DataBind()
    End Sub

    Private Function CreateOfficeEquipmentLedgerSchema() As DataTable
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
    Protected Sub OnOfficeEquipmentLedgerDataBound(sender As Object, e As EventArgs)
        ' reserved
    End Sub

    Protected Sub btnOfficeEquipmentPreview_Click(sender As Object, e As EventArgs)
        ' reserved
    End Sub

End Class
