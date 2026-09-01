Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_PropertyCard_Rev_Equipment
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
            BindEquipmentGrid()
            BindEquipmentsGrid()
            BindEquipmentLedgerGrid()

            Session("GA_ID") = 0
            Session("SubClassificationID") = 0
        Else
            BindEquipmentGrid()
            BindEquipmentsGrid()
        End If
    End Sub

    ' ============================
    ' REFRESH METHOD
    ' ============================
    Public Sub RefreshGridData()
        BindEquipmentGrid()

        If gvEquipmentLocationList.SelectedIndex >= 0 Then
            BindEquipmentsGrid()
        Else
            BindEmptyEquipmentsGrid()
        End If

        BindEquipmentLedgerGrid()
    End Sub

    ' ============================
    ' LOCATION GRIDVIEW FUNCTIONS
    ' ============================
    Private Sub BindEquipmentGrid()
        Dim subClass As String = If(Session("SubClassificationID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim dt As DataTable = GetEquipmentLocationData(subClass, gaId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvEquipmentLocationList.DataSource = dt
            gvEquipmentLocationList.DataBind()
        Else
            BindEmptyEquipmentGrid()
        End If
    End Sub

    Private Function GetEquipmentLocationData(ByVal subClassId As String, ByVal gaId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("PropertyCard_Rev_Equipment_ListOfLocation: subClassId: " & subClassId)
            AddTrace("PropertyCard_Rev_Equipment_ListOfLocation: gaId: " & gaId)

            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Equipment_ListOfLocation] '" & subClassId & "', '" & gaId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading equipment locations: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyEquipmentGrid()
        Dim dt As DataTable = CreateEquipmentLocationSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        gvEquipmentLocationList.DataSource = dt
        gvEquipmentLocationList.DataBind()
    End Sub

    Private Function CreateEquipmentLocationSchema() As DataTable
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
    Protected Sub gvEquipmentLocationList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvEquipmentLocationList.PageIndex = e.NewPageIndex
        BindEquipmentGrid()
    End Sub

    Protected Sub gvEquipmentLocationList_SelectedIndexChanged(sender As Object, e As EventArgs)
        If gvEquipmentLocationList.SelectedIndex >= 0 Then
            Dim selectedItemId As String = gvEquipmentLocationList.SelectedDataKey("Item_ID")
            Session("Item_ID") = selectedItemId
            BindEquipmentsGrid()


            Dim dt As DataTable = GetEquipmentLedgerData(Nothing)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                FormatEquipmentLedgerTransType(dt)

                grdEquipmentLedger.DataSource = dt
                grdEquipmentLedger.DataBind()
            Else
                BindEmptyEquipmentLedgerGrid()
            End If


        End If
    End Sub


    Private Sub FormatEquipmentLedgerTransType(ByVal dt As DataTable)

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


    Protected Sub gvEquipmentLocationList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvEquipmentLocationList, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    ' ============================
    ' EQUIPMENTS LIST GRIDVIEW
    ' ============================
    Protected Sub btnEquipmentPropSearch_Click(sender As Object, e As EventArgs)
        Dim searchText As String = txtEquipmentPropSearch.Text.Trim()

        ' If no search value → show full list using existing logic
        If String.IsNullOrEmpty(searchText) Then
            AddTrace("Equipment Search: empty, loading full list.")
            BindEquipmentsGrid()
            Exit Sub
        End If

        ' Replicate the same parameter logic used in BindEquipmentsGrid
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        If gvEquipmentLocationList.SelectedIndex >= 0 Then
            itemParticularId = gvEquipmentLocationList.DataKeys(gvEquipmentLocationList.SelectedIndex).Values("item_particular_id").ToString()
            itemId = gvEquipmentLocationList.DataKeys(gvEquipmentLocationList.SelectedIndex).Values("Item_ID").ToString()
            declaredOwner = gvEquipmentLocationList.DataKeys(gvEquipmentLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
            barangay = gvEquipmentLocationList.DataKeys(gvEquipmentLocationList.SelectedIndex).Values("Barangay").ToString()
        End If

        AddTrace("Equipment Search: " & searchText &
             " | itemParticularId=" & itemParticularId &
             " | itemId=" & itemId &
             " | gaId=" & gaId &
             " | declaredOwner=" & declaredOwner &
             " | barangay=" & barangay)

        ' Get the same dataset that BindEquipmentsGrid would bind
        Dim dt As DataTable = GetEquipmentsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BindEmptyEquipmentsGrid()
            Exit Sub
        End If

        ' Filter by PropertyNo LIKE '%txtEquipmentPropSearch%'
        Dim dv As New DataView(dt)

        ' Escape special characters for RowFilter
        Dim safeSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("]", "]]")

        dv.RowFilter = "PropertyNo LIKE '%" & safeSearch & "%'"

        If dv.Count > 0 Then
            grdListOfEquipments.DataSource = dv
            grdListOfEquipments.DataBind()
        Else
            BindEmptyEquipmentsGrid()
        End If
    End Sub


    Private Sub BindEquipmentsGrid()
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""
        Try

            If gvEquipmentLocationList.SelectedIndex >= 0 Then
                itemParticularId = gvEquipmentLocationList.DataKeys(gvEquipmentLocationList.SelectedIndex).Values("item_particular_id").ToString()
                itemId = gvEquipmentLocationList.DataKeys(gvEquipmentLocationList.SelectedIndex).Values("Item_ID").ToString()
                declaredOwner = gvEquipmentLocationList.DataKeys(gvEquipmentLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
                barangay = gvEquipmentLocationList.DataKeys(gvEquipmentLocationList.SelectedIndex).Values("Barangay").ToString()
            End If

            AddTrace("itemParticularId: " & itemParticularId)
            AddTrace("itemId: " & itemId)
            AddTrace("gaId: " & gaId)
            AddTrace("declaredOwner: " & declaredOwner)
            AddTrace("barangay: " & barangay)

            Dim dt As DataTable = GetEquipmentsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                grdListOfEquipments.DataSource = dt
                grdListOfEquipments.DataBind()
            Else
                BindEmptyEquipmentsGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetEquipmentsData(ByVal itemParticularId As String, ByVal itemId As String, ByVal gaId As String,
                                       ByVal declaredOwner As String, ByVal barangay As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Equipment_ListOfEquipments] '" & itemParticularId & "', '" & itemId & "', '" & gaId & "', '" & declaredOwner & "', '" & barangay & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading equipments list: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyEquipmentsGrid()
        Dim dt As DataTable = CreateEquipmentsSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdListOfEquipments.DataSource = dt
        grdListOfEquipments.DataBind()
    End Sub

    Private Function CreateEquipmentsSchema() As DataTable
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

    ' EQUIPMENTS EVENTS
    Protected Sub grdListOfEquipments_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdListOfEquipments.PageIndex = e.NewPageIndex
        BindEquipmentsGrid()
    End Sub

    Protected Sub grdListOfEquipments_SelectedIndexChanged(sender As Object, e As EventArgs)
        If grdListOfEquipments.SelectedIndex >= 0 Then
            loadUnit()

            Dim selectedPropertyId As String = grdListOfEquipments.SelectedDataKey("Property_ID")
            Session("Property_ID") = selectedPropertyId

            Dim propertyDtlId As String = grdListOfEquipments.DataKeys(grdListOfEquipments.SelectedIndex).Values("PropertyDetai_ID").ToString()
            PopulateEquipmentInformation(propertyDtlId)

            RefreshGridData()
        End If
    End Sub

    Protected Sub grdListOfEquipments_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdListOfEquipments, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    Protected Sub grdListOfEquipments_OnDataBound(sender As Object, e As EventArgs)
        ' reserved for future binding logic
    End Sub

    ' ============================
    ' EQUIPMENT INFORMATION
    ' ============================
    Private Function GetEquipmentInformationData(ByVal propertyDtlId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("propertyDtlId: " & propertyDtlId)
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Equipment_GetInformation] '" & propertyDtlId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading equipment information: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub PopulateEquipmentInformation(ByVal propertyDtlId As String)
        Dim dt As DataTable = GetEquipmentInformationData(propertyDtlId)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearEquipmentInformationForm()
            Return
        End If

        Dim r As DataRow = dt.Rows(0)

        If dt.Columns.Contains("Name") Then txtEquipmentName.Text = r("Name").ToString()
        If dt.Columns.Contains("Description") Then txtEquipmentDescription.Text = r("Description").ToString()
        If dt.Columns.Contains("Warranty") Then txtEquipmentWarranty.Text = r("Warranty").ToString()
        If dt.Columns.Contains("PowerInput") Then txtEquipmentPowerInput.Text = r("PowerInput").ToString()
        If dt.Columns.Contains("Model") Then txtEquipmentModel.Text = r("Model").ToString()
        If dt.Columns.Contains("Dimension") Then txtEquipmentDimension.Text = r("Dimension").ToString()
        If dt.Columns.Contains("SerialNo") Then txtEquipmentSerialNumber.Text = r("SerialNo").ToString()

        If dt.Columns.Contains("Unit_ID") Then drpEquipmentUnit.SelectedValue = r("Unit_ID").ToString()
        If dt.Columns.Contains("Quantity") Then txtEquipmentQuantity.Text = r("Quantity").ToString()
        If dt.Columns.Contains("Remarks") Then txtEquipmentRemarks.Text = r("Remarks").ToString()



        If dt.Columns.Contains("Contractor") Then txtEquipmentContractor.Text = r("Contractor").ToString()
        If dt.Columns.Contains("ContactPerson") Then txtEquipmentContactPerson.Text = r("ContactPerson").ToString()
        If dt.Columns.Contains("ContactNo") Then txtEquipmentContactNo.Text = r("ContactNo").ToString()

        If dt.Columns.Contains("AcquisitionDate") AndAlso Not String.IsNullOrEmpty(r("AcquisitionDate").ToString()) Then
            txtEquipmentAcquisitionDate.Text = Convert.ToDateTime(r("AcquisitionDate")).ToString("MM/dd/yyyy")
        End If

        If dt.Columns.Contains("MarketValue") Then txtEquipmentMarketValue.Text = FormatNumber(r("MarketValue"), 2)
        If dt.Columns.Contains("AcquisitionCost") Then txtEquipmentAcquisitionCost.Text = FormatNumber(r("AcquisitionCost"), 2)
        If dt.Columns.Contains("NoYears") Then txtEquipmentNoYears.Text = r("NoYears").ToString()
        If dt.Columns.Contains("DepreciationRate") Then txtEquipmentDepRate.Text = FormatNumber(r("DepreciationRate"), 2)
        If dt.Columns.Contains("UsefulLife") Then txtEquipmentUsefulLife.Text = r("UsefulLife").ToString()
        If dt.Columns.Contains("DepreciationValue") Then txtEquipmentDepValue.Text = FormatNumber(r("DepreciationValue"), 2)
        If dt.Columns.Contains("SalvageValue") Then txtEquipmentSalvageValue.Text = FormatNumber(r("SalvageValue"), 2)
        If dt.Columns.Contains("DepreciatedValue") Then txtDepreciatedValueEquipmentNew.Text = FormatNumber(r("DepreciatedValue"), 2)

        If dt.Columns.Contains("useful_life") Then Session("useful_life") = r("useful_life").ToString()
    End Sub

    Private Sub ClearEquipmentInformationForm()
        txtEquipmentName.Text = ""
        txtEquipmentDescription.Text = ""
        txtEquipmentWarranty.Text = ""
        txtEquipmentPowerInput.Text = ""
        txtEquipmentModel.Text = ""
        txtEquipmentDimension.Text = ""
        txtEquipmentSerialNumber.Text = ""

        drpEquipmentUnit.SelectedIndex = -1
        txtEquipmentQuantity.Text = ""

        txtEquipmentRemarks.Text = ""

        txtEquipmentContractor.Text = ""
        txtEquipmentContactPerson.Text = ""
        txtEquipmentContactNo.Text = ""

        txtEquipmentAcquisitionDate.Text = ""
        txtEquipmentMarketValue.Text = ""
        txtEquipmentAcquisitionCost.Text = ""
        txtEquipmentNoYears.Text = ""
        txtEquipmentDepRate.Text = ""
        txtEquipmentUsefulLife.Text = ""
        txtDepreciatedValueEquipmentNew.Text = ""
        txtEquipmentSalvageValue.Text = ""
        txtEquipmentDepValue.Text = ""
    End Sub

    'Loading of Unit
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpEquipmentUnit.DataSource = dt
        drpEquipmentUnit.DataTextField = ("Description")
        drpEquipmentUnit.DataValueField = ("Unit_ID")
        drpEquipmentUnit.DataBind()
    End Sub


    ' ============================
    ' LEDGER GRIDVIEW
    ' ============================
    Private Sub BindEquipmentLedgerGrid()
        Dim classificationId As String = If(Session("ClassificationID"), "0")

        Dim dt As DataTable = GetEquipmentLedgerData(classificationId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdEquipmentLedger.DataSource = dt
            grdEquipmentLedger.DataBind()
        Else
            BindEmptyEquipmentLedgerGrid()
        End If
    End Sub

    Private Function GetEquipmentLedgerData(ByVal classificationId As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Ledger_v2] '" & Session("Item_ID") & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading equipment ledger: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyEquipmentLedgerGrid()
        Dim dt As DataTable = CreateEquipmentLedgerSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdEquipmentLedger.DataSource = dt
        grdEquipmentLedger.DataBind()
    End Sub

    Private Function CreateEquipmentLedgerSchema() As DataTable
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
    Protected Sub OnEquipmentLedgerDataBound(sender As Object, e As EventArgs)
        ' reserved
    End Sub

    Protected Sub btnEquipmentPreview_Click(sender As Object, e As EventArgs)
        ' reserved
    End Sub

End Class
