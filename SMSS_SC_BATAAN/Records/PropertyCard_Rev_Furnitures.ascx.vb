Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_PropertyCard_Rev_Furnitures
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
            BindFurnitureLocationGrid()
            BindFurnituresGrid()
            BindFurnitureLedgerGrid()

            ' match reference behavior
            Session("GA_ID") = 0
            Session("SubClassificationID") = 0
        Else
            BindFurnitureLocationGrid()
            BindFurnituresGrid()
        End If
    End Sub

    ' ============================
    ' REFRESH METHOD (called by main page)
    ' ============================
    Public Sub RefreshGridData()
        BindFurnitureLocationGrid()

        If gvFurnitureLocationList.SelectedIndex >= 0 Then
            BindFurnituresGrid()
        Else
            BindEmptyFurnituresGrid()
        End If

        BindFurnitureLedgerGrid()
        'ClearFurnitureInformationForm()
    End Sub


    ' =========================================================
    ' LIST OF LOCATION (FURNITURES AND FIXTURES)
    ' =========================================================
    Private Sub BindFurnitureLocationGrid()
        Dim subClassId As String = If(Session("SubClassificationID"), "0").ToString()
        Dim gaId As String = If(Session("GA_ID"), "0").ToString()

        Dim dt As DataTable = GetFurnitureLocationData(subClassId, gaId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvFurnitureLocationList.DataSource = dt
            gvFurnitureLocationList.DataBind()
        Else
            BindEmptyFurnitureLocationGrid()
        End If
    End Sub

    Private Function GetFurnitureLocationData(ByVal subClassId As String, ByVal gaId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("FURNITURE Location -> subClassId: " & subClassId)
            AddTrace("FURNITURE Location -> gaId: " & gaId)

            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Furnitures_ListOfLocation] '" & subClassId & "', '" & gaId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading furniture locations: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyFurnitureLocationGrid()
        Dim dt As DataTable = CreateFurnitureLocationSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        gvFurnitureLocationList.DataSource = dt
        gvFurnitureLocationList.DataBind()
    End Sub

    Private Function CreateFurnitureLocationSchema() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("item_particular_id", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("DeclaredOwner", GetType(String))
        dt.Columns.Add("Barangay", GetType(String))

        dt.Columns.Add("ItemCode", GetType(String))
        dt.Columns.Add("ItemDescription", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Room", GetType(String))
        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        Return dt
    End Function

    ' LOCATION EVENTS
    Protected Sub gvFurnitureLocationList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvFurnitureLocationList.PageIndex = e.NewPageIndex
        BindFurnitureLocationGrid()
    End Sub

    Protected Sub gvFurnitureLocationList_SelectedIndexChanged(sender As Object, e As EventArgs)
        If gvFurnitureLocationList.SelectedIndex >= 0 Then
            Dim selectedItemId As String = gvFurnitureLocationList.SelectedDataKey("Item_ID")
            Session("Item_ID") = selectedItemId
            BindFurnituresGrid()


            Dim dt As DataTable = GetFurnitureLedgerData(Nothing)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                'FormatBuildingLedgerTransType(dt)

                grdFurnitureLedger.DataSource = dt
                grdFurnitureLedger.DataBind()
            Else
                BindEmptyFurnitureLedgerGrid()
            End If


        End If
    End Sub

    Protected Sub gvFurnitureLocationList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvFurnitureLocationList, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub


    ' =========================================================
    ' LIST OF FURNITURES AND FIXTURES (child grid)
    ' =========================================================
    Protected Sub btnFurniturePropSearch_Click(sender As Object, e As EventArgs)
        Dim searchText As String = txtFurniturePropSearch.Text.Trim()

        ' If no search value → show full list using existing logic
        If String.IsNullOrEmpty(searchText) Then
            AddTrace("Furniture Search: empty, loading full list.")
            BindFurnituresGrid()
            Exit Sub
        End If

        ' Replicate the same parameter logic used in BindFurnituresGrid
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        ' Adjust gvFurnitureLocationList to your actual location grid ID if different
        If gvFurnitureLocationList.SelectedIndex >= 0 Then
            itemParticularId = gvFurnitureLocationList.DataKeys(gvFurnitureLocationList.SelectedIndex).Values("item_particular_id").ToString()
            itemId = gvFurnitureLocationList.DataKeys(gvFurnitureLocationList.SelectedIndex).Values("Item_ID").ToString()
            declaredOwner = gvFurnitureLocationList.DataKeys(gvFurnitureLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
            barangay = gvFurnitureLocationList.DataKeys(gvFurnitureLocationList.SelectedIndex).Values("Barangay").ToString()
        End If

        AddTrace("Furniture Search: " & searchText &
             " | itemParticularId=" & itemParticularId &
             " | itemId=" & itemId &
             " | gaId=" & gaId &
             " | declaredOwner=" & declaredOwner &
             " | barangay=" & barangay)

        ' Get the same dataset that BindFurnituresGrid would bind
        Dim dt As DataTable = GetFurnituresData(itemParticularId, itemId, gaId, declaredOwner, barangay)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BindEmptyFurnituresGrid()
            Exit Sub
        End If

        ' Filter by PropertyNo LIKE '%txtFurniturePropSearch%'
        Dim dv As New DataView(dt)

        ' Escape special characters for RowFilter
        Dim safeSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("]", "]]")

        dv.RowFilter = "PropertyNo LIKE '%" & safeSearch & "%'"

        If dv.Count > 0 Then
            grdListOfFurnitures.DataSource = dv
            grdListOfFurnitures.DataBind()
        Else
            BindEmptyFurnituresGrid()
        End If
    End Sub


    Private Sub BindFurnituresGrid()
        Dim itemId As String = If(Session("Item_ID"), "0").ToString()
        Dim gaId As String = If(Session("GA_ID"), "0").ToString()

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        Try

            If gvFurnitureLocationList.SelectedIndex >= 0 Then
                itemParticularId = gvFurnitureLocationList.DataKeys(gvFurnitureLocationList.SelectedIndex).Values("item_particular_id").ToString()
                itemId = gvFurnitureLocationList.DataKeys(gvFurnitureLocationList.SelectedIndex).Values("Item_ID").ToString()
                declaredOwner = gvFurnitureLocationList.DataKeys(gvFurnitureLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
                barangay = gvFurnitureLocationList.DataKeys(gvFurnitureLocationList.SelectedIndex).Values("Barangay").ToString()
            End If

            AddTrace("FURNITURE List -> itemParticularId: " & itemParticularId)
            AddTrace("FURNITURE List -> itemId: " & itemId)
            AddTrace("FURNITURE List -> gaId: " & gaId)
            AddTrace("FURNITURE List -> declaredOwner: " & declaredOwner)
            AddTrace("FURNITURE List -> barangay: " & barangay)


            Dim dt As DataTable = GetFurnituresData(itemParticularId, itemId, gaId, declaredOwner, barangay)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                grdListOfFurnitures.DataSource = dt
                grdListOfFurnitures.DataBind()
            Else
                BindEmptyFurnituresGrid()
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Function GetFurnituresData(ByVal itemParticularId As String, ByVal itemId As String, ByVal gaId As String,
                                       ByVal declaredOwner As String, ByVal barangay As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String =
                "Exec [AMS].[PropertyCard_Rev_Furnitures_ListOfFurnitures] '" & itemParticularId & "', '" & itemId & "', '" & gaId & "', '" & declaredOwner & "', '" & barangay & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading furnitures list: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyFurnituresGrid()
        Dim dt As DataTable = CreateFurnituresSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdListOfFurnitures.DataSource = dt
        grdListOfFurnitures.DataBind()
    End Sub

    Private Function CreateFurnituresSchema() As DataTable
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

    ' FURNITURES EVENTS
    Protected Sub grdListOfFurnitures_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdListOfFurnitures.PageIndex = e.NewPageIndex
        BindFurnituresGrid()
    End Sub

    Protected Sub grdListOfFurnitures_SelectedIndexChanged(sender As Object, e As EventArgs)
        If grdListOfFurnitures.SelectedIndex >= 0 Then
            loadUnit()

            Dim selectedPropertyId As String = grdListOfFurnitures.SelectedDataKey("Property_ID")
            Session("Property_ID") = selectedPropertyId

            Dim propertyDtlId As String =
                grdListOfFurnitures.DataKeys(grdListOfFurnitures.SelectedIndex).Values("PropertyDetai_ID").ToString()

            PopulateFurnitureInformation(propertyDtlId)

            RefreshGridData()
        End If
    End Sub

    Protected Sub grdListOfFurnitures_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdListOfFurnitures, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    Protected Sub grdListOfFurnitures_OnDataBound(sender As Object, e As EventArgs)
        ' reserved for future binding logic
    End Sub


    ' =========================================================
    ' FURNITURE INFORMATION
    ' =========================================================
    Private Function GetFurnitureInformationData(ByVal propertyDtlId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("FURNITURE Info -> propertyDtlId: " & propertyDtlId)
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Furnitures_GetInformation] '" & propertyDtlId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading furniture information: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub PopulateFurnitureInformation(ByVal propertyDtlId As String)
        Dim dt As DataTable = GetFurnitureInformationData(propertyDtlId)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearFurnitureInformationForm()
            Return
        End If

        Dim r As DataRow = dt.Rows(0)

        If dt.Columns.Contains("Name") Then txtFurnitureName.Text = r("Name").ToString()
        If dt.Columns.Contains("Description") Then txtFurnitureDescription.Text = r("Description").ToString()
        If dt.Columns.Contains("Warranty") Then txtFurnitureWarranty.Text = r("Warranty").ToString()
        If dt.Columns.Contains("Model") Then txtFurnitureModel.Text = r("Model").ToString()
        If dt.Columns.Contains("Dimension") Then txtFurnitureDimension.Text = r("Dimension").ToString()
        If dt.Columns.Contains("SerialNo") Then txtFurnitureSerialNumber.Text = r("SerialNo").ToString()

        If dt.Columns.Contains("PropertyNo") Then txtFurniturePropertyNo.Text = r("PropertyNo").ToString()

        If dt.Columns.Contains("Unit_ID") Then drpFurnitureUnit.SelectedValue = r("Unit_ID").ToString()
        If dt.Columns.Contains("Quantity") Then txtFurnitureQuantity.Text = r("Quantity").ToString()


        If dt.Columns.Contains("AcquisitionDate") AndAlso Not String.IsNullOrEmpty(r("AcquisitionDate").ToString()) Then
            txtFurnitureAcqDate.Text = Convert.ToDateTime(r("AcquisitionDate")).ToString("MM/dd/yyyy")
        End If

        If dt.Columns.Contains("MarketValue") Then txtFurnitureMarketValue.Text = FormatNumber(r("MarketValue"), 2)
        If dt.Columns.Contains("AcquisitionCost") Then txtFurnitureAcqCost.Text = FormatNumber(r("AcquisitionCost"), 2)
        If dt.Columns.Contains("NoYears") Then txtFurnitureNoYears.Text = r("NoYears").ToString()
        If dt.Columns.Contains("DepreciationRate") Then txtFurnitureDeprate.Text = FormatNumber(r("DepreciationRate"), 2)
        If dt.Columns.Contains("UsefulLife") Then txtFurnitureUsefulLife.Text = r("UsefulLife").ToString()
        If dt.Columns.Contains("DepreciationValue") Then txtFurnitureDepValue.Text = FormatNumber(r("DepreciationValue"), 2)
        If dt.Columns.Contains("SalvageValue") Then txtFurnitureSalvageValue.Text = FormatNumber(r("SalvageValue"), 2)
        If dt.Columns.Contains("DepreciatedValue") Then txtDepreciatedValueFurnitureNew.Text = FormatNumber(r("DepreciatedValue"), 2)

        If dt.Columns.Contains("useful_life") Then Session("useful_life") = r("useful_life").ToString()
    End Sub

    Private Sub ClearFurnitureInformationForm()
        txtFurnitureName.Text = ""
        txtFurnitureDescription.Text = ""
        txtFurnitureWarranty.Text = ""
        txtFurnitureModel.Text = ""
        txtFurnitureDimension.Text = ""
        txtFurnitureSerialNumber.Text = ""
        txtFurniturePropertyNo.Text = ""

        drpFurnitureUnit.SelectedIndex = -1
        txtFurnitureQuantity.Text = ""



        txtFurnitureAcqDate.Text = ""
        txtFurnitureMarketValue.Text = ""
        txtFurnitureAcqCost.Text = ""
        txtFurnitureNoYears.Text = ""
        txtFurnitureDeprate.Text = ""
        txtFurnitureUsefulLife.Text = ""
        txtFurnitureDepValue.Text = ""
        txtFurnitureSalvageValue.Text = ""
        txtDepreciatedValueFurnitureNew.Text = ""
    End Sub


    ' =========================================================
    ' LEDGER GRIDVIEW (same SP as reference)
    ' =========================================================
    Private Sub BindFurnitureLedgerGrid()
        Dim classificationId As String = If(Session("ClassificationID"), "0").ToString()

        Dim dt As DataTable = GetFurnitureLedgerData(classificationId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdFurnitureLedger.DataSource = dt
            grdFurnitureLedger.DataBind()
        Else
            BindEmptyFurnitureLedgerGrid()
        End If
    End Sub

    Private Function GetFurnitureLedgerData(ByVal classificationId As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Ledger_v2] '" & Session("Item_ID") & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading furniture ledger: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyFurnitureLedgerGrid()
        Dim dt As DataTable = CreateFurnitureLedgerSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdFurnitureLedger.DataSource = dt
        grdFurnitureLedger.DataBind()
    End Sub

    Private Function CreateFurnitureLedgerSchema() As DataTable
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
    Protected Sub OnFurnitureLedgerDataBound(sender As Object, e As EventArgs)
        ' reserved
    End Sub

    Protected Sub btnFurniturePreview_Click(sender As Object, e As EventArgs)
        ' reserved
    End Sub


    'Loading of Unit
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpFurnitureUnit.DataSource = dt
        drpFurnitureUnit.DataTextField = ("Description")
        drpFurnitureUnit.DataValueField = ("Unit_ID")
        drpFurnitureUnit.DataBind()
    End Sub

End Class
