Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Text.RegularExpressions

Partial Class Records_PropertyCard_Rev_Others
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
            BindOthersGrid()
            BindEmptyOthersListGrid()
            BindEmptyOthersLedgerGrid()
            ClearOthersInformationForm()
        End If

    End Sub

    ' ============================
    ' REFRESH METHOD (same pattern)
    ' ============================
    Public Sub RefreshGridData()
        BindOthersGrid()

        Dim itemId As String =
        If(Session("Item_ID"), "0").ToString()

        If Not String.IsNullOrEmpty(itemId) AndAlso
        itemId <> "0" Then

            BindOthersListGrid()
            BindOthersLedgerGrid()
        Else
            grdListOfOthers.PageIndex = 0
            grdListOfOthers.SelectedIndex = -1

            txtOthersPropertySearch.Text = ""

            If ddlSearchCriteria.Items.Count > 0 Then
                ddlSearchCriteria.SelectedIndex = 0
            End If

            BindEmptyOthersListGrid()
            BindEmptyOthersLedgerGrid()
            ClearOthersInformationForm()
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

            grdListOfOthers.PageIndex = 0
            grdListOfOthers.SelectedIndex = -1

            txtOthersPropertySearch.Text = ""

            If ddlSearchCriteria.Items.Count > 0 Then
                ddlSearchCriteria.SelectedIndex = 0
            End If

            BindEmptyOthersListGrid()
            BindEmptyOthersLedgerGrid()
            ClearOthersInformationForm()

            Exit Sub
        End If

        Session("Item_ID") = itemId
        Session("Property_ID") = 0
        Session("PropertyDetai_ID") = 0

        ' Reset the previously selected Others property.
        grdListOfOthers.PageIndex = 0
        grdListOfOthers.SelectedIndex = -1

        ' Reset the search controls for the newly selected item.
        txtOthersPropertySearch.Text = ""

        If ddlSearchCriteria.Items.Count > 0 Then
            ddlSearchCriteria.SelectedIndex = 0
        End If

        ClearOthersInformationForm()

        AddTrace(
        "Others User Control Item_ID: " &
        itemId
    )

        BindOthersListGrid()
        BindOthersLedgerGrid()

    End Sub


    ' ============================
    ' LOCATION GRIDVIEW FUNCTIONS
    ' ============================
    Private Sub BindOthersGrid()
        Dim subClass As String = If(Session("SubClassificationID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim dt As DataTable = GetOthersLocationData(subClass, gaId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvOthersLocationList.DataSource = dt
            gvOthersLocationList.DataBind()
        Else
            BindEmptyOthersGrid()
        End If

        If gaId = 0 Then
            BindEmptyOthersGrid()
            Session("PropertyDetai_ID") = 0
        End If


    End Sub

    Private Function GetOthersLocationData(ByVal subClassId As String, ByVal gaId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("subClassId: " & subClassId)
            AddTrace("gaId: " & gaId)

            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Others_ListOfLocation] '" & subClassId & "', '" & gaId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading others locations: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyOthersGrid()
        Dim dt As DataTable = CreateOthersLocationSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        gvOthersLocationList.DataSource = dt
        gvOthersLocationList.DataBind()
    End Sub

    Private Function CreateOthersLocationSchema() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("item_particular_id", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("ItemDescription", GetType(String))
        dt.Columns.Add("Barangay", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Area", GetType(String))
        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        Return dt
    End Function

    ' LOCATION EVENTS
    Protected Sub gvOthersLocationList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvOthersLocationList.PageIndex = e.NewPageIndex
        BindOthersGrid()
    End Sub

    Protected Sub gvOthersLocationList_SelectedIndexChanged(
    sender As Object,
    e As EventArgs)

        If gvOthersLocationList.SelectedIndex >= 0 Then

            Dim selectedItemId As String =
            gvOthersLocationList.DataKeys(
                gvOthersLocationList.SelectedIndex
            ).Values("Item_ID").ToString()

            LoadSelectedItem(selectedItemId)

        End If

    End Sub

    Protected Sub btnOthersPropertySearch_Click(
    sender As Object,
    e As EventArgs)

        Dim searchText As String =
        txtOthersPropertySearch.Text.Trim()

        Dim searchBy As String =
        ddlSearchCriteria.SelectedValue

        If String.IsNullOrEmpty(searchText) Then
            AddTrace(
            "Others Search: empty, loading full list."
        )

            BindOthersListGrid()
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
            BindEmptyOthersListGrid()
            Exit Sub
        End If

        AddTrace(
        "Others Search: " & searchText &
        " | searchBy=" & searchBy &
        " | itemParticularId=" & itemParticularId &
        " | itemId=" & itemId &
        " | gaId=" & gaId &
        " | declaredOwner=" & declaredOwner &
        " | barangay=" & barangay
    )

        Dim dt As DataTable =
        GetOthersData(
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
            BindEmptyOthersListGrid()
            Exit Sub
        End If

        ' Only allow the two predefined search columns.
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
            grdListOfOthers.DataSource = dv
            grdListOfOthers.DataBind()
        Else
            BindEmptyOthersListGrid()
        End If

    End Sub
    ' ============================
    ' OTHERS LIST GRIDVIEW
    ' ============================
    'Protected Sub btnOthersPropertySearch_Click(sender As Object, e As EventArgs)
    '    Dim searchText As String = txtOthersPropertySearch.Text.Trim()

    '    ' If no search value → show full list using existing logic
    '    If String.IsNullOrEmpty(searchText) Then
    '        AddTrace("Others Search: empty, loading full list.")
    '        BindOthersListGrid()
    '        Exit Sub
    '    End If

    '    ' Replicate the same parameter logic used in BindOthersListGrid
    '    Dim itemId As String = If(Session("Item_ID"), "0")
    '    Dim gaId As String = If(Session("GA_ID"), "0")

    '    Dim itemParticularId As String = "0"
    '    Dim declaredOwner As String = ""
    '    Dim barangay As String = ""

    '    If gvOthersLocationList.SelectedIndex >= 0 Then
    '        itemParticularId = gvOthersLocationList.DataKeys(gvOthersLocationList.SelectedIndex).Values("item_particular_id").ToString()
    '        itemId = gvOthersLocationList.DataKeys(gvOthersLocationList.SelectedIndex).Values("Item_ID").ToString()
    '        'declaredOwner = gvOthersLocationList.DataKeys(gvOthersLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
    '        barangay = gvOthersLocationList.DataKeys(gvOthersLocationList.SelectedIndex).Values("Barangay").ToString()
    '    End If

    '    AddTrace("Others Search: " & searchText &
    '         " | itemParticularId=" & itemParticularId &
    '         " | itemId=" & itemId &
    '         " | gaId=" & gaId &
    '         " | declaredOwner=" & declaredOwner &
    '         " | barangay=" & barangay)

    '    ' Get the same dataset that BindOthersListGrid would bind
    '    Dim dt As DataTable = GetOthersData(itemParticularId, itemId, gaId, declaredOwner, barangay)

    '    If dt Is Nothing OrElse dt.Rows.Count = 0 Then
    '        BindEmptyOthersListGrid()
    '        Exit Sub
    '    End If

    '    ' Filter by PropertyNo LIKE '%txtOthersPropertySearch%'
    '    Dim dv As New DataView(dt)

    '    ' Escape special characters for RowFilter
    '    Dim safeSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("]", "]]")

    '    dv.RowFilter = "PropertyNo LIKE '%" & safeSearch & "%'"

    '    If dv.Count > 0 Then
    '        grdListOfOthers.DataSource = dv
    '        grdListOfOthers.DataBind()
    '    Else
    '        BindEmptyOthersListGrid()
    '    End If
    'End Sub

    'ADded by John
    Protected Sub gvOthersLocationList_RowDataBound(
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

            ' Only actual Others item rows are clickable.
            If Not String.IsNullOrEmpty(itemId) Then
                e.Row.Attributes("onclick") =
                Page.ClientScript.GetPostBackClientHyperlink(
                    gvOthersLocationList,
                    "Select$" & e.Row.RowIndex
                )

                e.Row.Style("cursor") = "pointer"
            End If

        End If

    End Sub

    Private Sub BindOthersListGrid()

        Dim itemId As String =
        If(Session("Item_ID"), "0").ToString()

        Dim gaId As String =
        If(Session("GA_ID"), "0").ToString()

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        AddTrace(
        "Others List -> itemParticularId: " &
        itemParticularId
    )

        AddTrace(
        "Others List -> itemId: " &
        itemId
    )

        AddTrace(
        "Others List -> gaId: " &
        gaId
    )

        AddTrace(
        "Others List -> declaredOwner: " &
        declaredOwner
    )

        AddTrace(
        "Others List -> barangay: " &
        barangay
    )

        If String.IsNullOrEmpty(itemId) OrElse itemId = "0" Then
            BindEmptyOthersListGrid()
            Exit Sub
        End If

        Dim dt As DataTable =
        GetOthersData(
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
            grdListOfOthers.DataSource = dt
            grdListOfOthers.DataBind()
        Else
            BindEmptyOthersListGrid()
        End If

    End Sub

    Private Function GetOthersData(ByVal itemParticularId As String, ByVal itemId As String, ByVal gaId As String,
                                   ByVal declaredOwner As String, ByVal barangay As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Others_ListOfOthers] '" & itemParticularId & "', '" & itemId & "', '" & gaId & "', '" & declaredOwner & "', '" & barangay & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading others list: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyOthersListGrid()
        Dim dt As DataTable = CreateOthersSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdListOfOthers.DataSource = dt
        grdListOfOthers.DataBind()
    End Sub

    Private Function CreateOthersSchema() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("ItemDescription", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("Category", GetType(String))
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

    ' OTHERS EVENTS
    Protected Sub grdListOfOthers_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdListOfOthers.PageIndex = e.NewPageIndex

        BindOthersListGrid()

    End Sub

    Protected Sub grdListOfOthers_SelectedIndexChanged(
    sender As Object,
    e As EventArgs)

        If grdListOfOthers.SelectedIndex >= 0 Then

            loadUnit()

            Dim selectedPropertyId As String =
            grdListOfOthers.DataKeys(
                grdListOfOthers.SelectedIndex
            ).Values("Property_ID").ToString()

            Session("Property_ID") =
            selectedPropertyId

            Dim propertyDtlId As String =
            grdListOfOthers.DataKeys(
                grdListOfOthers.SelectedIndex
            ).Values("PropertyDetai_ID").ToString()

            Session("PropertyDetai_ID") =
            propertyDtlId

            PopulateOthersInformation(
            propertyDtlId
        )

            ' Refresh only the item-level ledger.
            ' Do not rebind the selected property grid.
            BindOthersLedgerGrid()

        End If

    End Sub
    Protected Sub grdListOfOthers_RowDataBound(
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
                    grdListOfOthers,
                    "Select$" & e.Row.RowIndex
                )

                e.Row.Style("cursor") = "pointer"
            End If

        End If

    End Sub

    Protected Sub grdListOfOthers_OnDataBound(sender As Object, e As EventArgs)
        ' reserved for future binding logic
    End Sub

    ' ============================
    ' OTHERS INFORMATION
    ' ============================
    Private Function GetOthersInformationData(ByVal propertyDtlId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("propertyDtlId: " & propertyDtlId)
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Others_GetInformation] '" & propertyDtlId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading others information: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub PopulateOthersInformation(ByVal propertyDtlId As String)
        Dim dt As DataTable = GetOthersInformationData(propertyDtlId)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearOthersInformationForm()
            Return
        End If

        Dim r As DataRow = dt.Rows(0)

        If dt.Columns.Contains("Name") Then txtOthersName.Text = r("Name").ToString()
        If dt.Columns.Contains("Description") Then txtOthersDescription.Text = r("Description").ToString()
        If dt.Columns.Contains("Category") Then txtOthersCategory.Text = r("Category").ToString()
        If dt.Columns.Contains("Model") Then txtOthersModel.Text = r("Model").ToString()
        If dt.Columns.Contains("SerialNo") Then txtOthersSerialNumber.Text = r("SerialNo").ToString()

        If dt.Columns.Contains("Unit_ID") Then drpOthersUnit.SelectedValue = r("Unit_ID").ToString()
        If dt.Columns.Contains("Quantity") Then txtOthersQuantity.Text = r("Quantity").ToString()

        If dt.Columns.Contains("AcquisitionDate") AndAlso Not String.IsNullOrEmpty(r("AcquisitionDate").ToString()) Then
            txtOthersAcquisitionDate.Text = Convert.ToDateTime(r("AcquisitionDate")).ToString("MM/dd/yyyy")
        End If

        If dt.Columns.Contains("MarketValue") Then txtOthersMarketValue.Text = FormatNumber(r("MarketValue"), 2)
        If dt.Columns.Contains("AcquisitionCost") Then txtOthersAcquisitionCost.Text = FormatNumber(r("AcquisitionCost"), 2)
        If dt.Columns.Contains("NoYears") Then txtOthersNoYears.Text = r("NoYears").ToString()
        If dt.Columns.Contains("DepreciationRate") Then txtOthersDepRate.Text = FormatNumber(r("DepreciationRate"), 2)
        If dt.Columns.Contains("UsefulLife") Then txtOthersUsefulLife.Text = r("UsefulLife").ToString()
        If dt.Columns.Contains("DepreciationValue") Then txtOthersDepValue.Text = FormatNumber(r("DepreciationValue"), 2)
        If dt.Columns.Contains("SalvageValue") Then txtOthersSalvageValue.Text = FormatNumber(r("SalvageValue"), 2)
        If dt.Columns.Contains("DepreciatedValue") Then txtDepreciatedValueOthersNew.Text = FormatNumber(r("DepreciatedValue"), 2)

        If dt.Columns.Contains("useful_life") Then Session("useful_life") = r("useful_life").ToString()
    End Sub

    Private Sub ClearOthersInformationForm()
        txtOthersName.Text = ""
        txtOthersDescription.Text = ""
        txtOthersCategory.Text = ""
        txtOthersModel.Text = ""
        txtOthersSerialNumber.Text = ""

        drpOthersUnit.SelectedIndex = -1
        txtOthersQuantity.Text = ""

        txtOthersAcquisitionDate.Text = ""
        txtOthersMarketValue.Text = ""
        txtOthersAcquisitionCost.Text = ""
        txtOthersNoYears.Text = ""
        txtOthersDepRate.Text = ""
        txtOthersUsefulLife.Text = ""
        txtDepreciatedValueOthersNew.Text = ""
        txtOthersSalvageValue.Text = ""
        txtOthersDepValue.Text = ""
    End Sub

    'Loading of Unit
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpOthersUnit.DataSource = dt
        drpOthersUnit.DataTextField = ("Description")
        drpOthersUnit.DataValueField = ("Unit_ID")
        drpOthersUnit.DataBind()
    End Sub


    ' ============================
    ' LEDGER GRIDVIEW
    ' ============================
    Private Sub BindOthersLedgerGrid()

        Dim itemId As String =
        If(Session("Item_ID"), "0").ToString()

        If String.IsNullOrEmpty(itemId) OrElse itemId = "0" Then
            BindEmptyOthersLedgerGrid()
            Exit Sub
        End If

        Dim dt As DataTable =
        GetOthersLedgerData()

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            FormatOthersLedgerTransType(dt)

            grdOthersLedger.DataSource = dt
            grdOthersLedger.DataBind()
        Else
            BindEmptyOthersLedgerGrid()
        End If

    End Sub

    Private Function GetOthersLedgerData() As DataTable
        Dim dt As New DataTable()

        Try
            Dim itemId As String =
            If(Session("Item_ID"), "0").ToString()

            AddTrace(
            "Others Ledger Item_ID: " &
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
            "Error loading others ledger: " &
            ex.Message
        )

            Return Nothing
        End Try

        Return dt
    End Function
    Private Sub BindEmptyOthersLedgerGrid()
        Dim dt As DataTable = CreateOthersLedgerSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdOthersLedger.DataSource = dt
        grdOthersLedger.DataBind()
    End Sub

    Private Function CreateOthersLedgerSchema() As DataTable
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
    Protected Sub OnOthersLedgerDataBound(sender As Object, e As EventArgs)
        ' reserved
    End Sub

    Protected Sub btnOthersPreview_Click(sender As Object, e As EventArgs)
        ' reserved
    End Sub

    Private Sub FormatOthersLedgerTransType(ByVal dt As DataTable)

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
