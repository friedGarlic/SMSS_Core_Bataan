Imports System.Data

Partial Class Records_PropertyCard_Rev_Books
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
            BindBooksGrid()
            BindBooksListGrid()
            BindLedgerGrid()

            Session("GA_ID") = 0
            Session("SubClassificationID") = 0
        Else
            BindBooksGrid()
            BindBooksListGrid()
        End If
    End Sub

    ' ============================
    ' REFRESH METHOD
    ' ============================
    Public Sub RefreshGridData()
        BindBooksGrid()

        If gvBooksLocationList.SelectedIndex >= 0 Then
            BindBooksListGrid()
        Else
            BindEmptyBooksListGrid()
        End If

        ' Always refresh ledger grid
        BindLedgerGrid()
    End Sub

    ' ============================
    ' BOOKS LOCATION GRIDVIEW FUNCTIONS
    ' ============================
    Private Sub BindBooksGrid()
        ' Get parameters from Session
        Dim subClass As String = If(Session("SubClassificationID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        ' Try to get data from stored procedure
        Dim dt As DataTable = GetBooksData(subClass, gaId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ' Bind actual data
            gvBooksLocationList.DataSource = dt
            gvBooksLocationList.DataBind()
        Else
            ' Bind empty grid if no data
            BindEmptyBooksGrid()
        End If
    End Sub

    Private Function GetBooksData(ByVal subClassId As String, ByVal gaId As String) As DataTable
        Dim dt As New DataTable()

        Try
            ' Use stored procedure for books data
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Books_ListOfLocation] '" & subClassId & "', '" & gaId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading books data: " & ex.Message)
            Return Nothing
        End Try

        Return dt
    End Function

    Private Sub BindEmptyBooksGrid()
        Dim dt As DataTable = CreateBooksTableSchema()

        ' Add 4 empty rows
        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        gvBooksLocationList.DataSource = dt
        gvBooksLocationList.DataBind()
    End Sub

    Private Function CreateBooksTableSchema() As DataTable
        Dim dt As New DataTable()
        ' Core columns from books gridview
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

        ' Additional books columns
        dt.Columns.Add("ItemDescription", GetType(String))
        dt.Columns.Add("Title", GetType(String))
        dt.Columns.Add("Author", GetType(String))
        dt.Columns.Add("Unit", GetType(String))

        Return dt
    End Function

    ' ============================
    ' BOOKS LOCATION GRIDVIEW EVENT HANDLERS
    ' ============================
    Protected Sub gvBooksLocationList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvBooksLocationList.PageIndex = e.NewPageIndex
        BindBooksGrid()
    End Sub

    Protected Sub gvBooksLocationList_SelectedIndexChanged(sender As Object, e As EventArgs)
        If gvBooksLocationList.SelectedIndex >= 0 Then
            Dim selectedItemId As String = gvBooksLocationList.SelectedDataKey("Item_ID")
            Session("Item_ID") = selectedItemId

            ' Refresh books list grid when a row is selected in the main grid
            BindBooksListGrid()


            Dim dt As DataTable = GetLedgerData(Nothing)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                'FormatOfficeLedgerTransType(dt)

                grdLedger.DataSource = dt
                grdLedger.DataBind()
            Else
                BindEmptyLedgerGrid()
            End If


        End If
    End Sub

    Protected Sub gvBooksLocationList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        ' Make rows clickable for selection
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvBooksLocationList, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    ' ============================
    ' BOOKS LIST GRIDVIEW FUNCTIONS
    ' ============================
    Protected Sub btnBooksPropSearch_Click(sender As Object, e As EventArgs)
        Dim searchText As String = txtBooksPropSearch.Text.Trim()

        ' If no search value → show full list using existing logic
        If String.IsNullOrEmpty(searchText) Then
            AddTrace("Books Search: empty, loading full list.")
            BindBooksListGrid()
            Exit Sub
        End If

        ' Replicate the same parameter logic used in BindBooksListGrid
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        If gvBooksLocationList.SelectedIndex >= 0 Then
            itemParticularId = gvBooksLocationList.DataKeys(gvBooksLocationList.SelectedIndex).Values("item_particular_id").ToString()
            itemId = gvBooksLocationList.DataKeys(gvBooksLocationList.SelectedIndex).Values("Item_ID").ToString()
            declaredOwner = gvBooksLocationList.DataKeys(gvBooksLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
            barangay = gvBooksLocationList.DataKeys(gvBooksLocationList.SelectedIndex).Values("Barangay").ToString()
        End If

        AddTrace("Books Search: " & searchText &
             " | itemParticularId=" & itemParticularId &
             " | itemId=" & itemId &
             " | gaId=" & gaId &
             " | declaredOwner=" & declaredOwner &
             " | barangay=" & barangay)

        ' Get the same dataset BindBooksListGrid would bind
        Dim dt As DataTable = GetBooksListData(itemParticularId, itemId, gaId, declaredOwner, barangay)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BindEmptyBooksListGrid()
            Exit Sub
        End If

        ' Filter by PropertyNo LIKE '%txtBooksPropSearch%'
        Dim dv As New DataView(dt)

        ' Escape special chars for DataView RowFilter
        Dim safeSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("]", "]]")

        dv.RowFilter = "PropertyNo LIKE '%" & safeSearch & "%'"

        If dv.Count > 0 Then
            grdlistofBooks.DataSource = dv
            grdlistofBooks.DataBind()
        Else
            BindEmptyBooksListGrid()
        End If
    End Sub


    Private Sub BindBooksListGrid()
        ' Get parameters from Session - use Item_ID from selected row in the first grid
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        ' Get additional parameters from the first grid's selected row if available
        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        Try

            If gvBooksLocationList.SelectedIndex >= 0 Then
                itemParticularId = gvBooksLocationList.DataKeys(gvBooksLocationList.SelectedIndex).Values("item_particular_id").ToString()
                itemId = gvBooksLocationList.DataKeys(gvBooksLocationList.SelectedIndex).Values("Item_ID").ToString()
                declaredOwner = gvBooksLocationList.DataKeys(gvBooksLocationList.SelectedIndex).Values("DeclaredOwner").ToString()
                barangay = gvBooksLocationList.DataKeys(gvBooksLocationList.SelectedIndex).Values("Barangay").ToString()
            End If

            AddTrace("itemParticularId: " & itemParticularId)
            AddTrace("itemId: " & itemId)
            AddTrace("gaId: " & gaId)
            AddTrace("declaredOwner: " & declaredOwner)
            AddTrace("barangay: " & barangay)

            ' Try to get data from stored procedure
            Dim dt As DataTable = GetBooksListData(itemParticularId, itemId, gaId, declaredOwner, barangay)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ' Bind actual data
                grdlistofBooks.DataSource = dt
                grdlistofBooks.DataBind()
            Else
                ' Bind empty grid if no data
                BindEmptyBooksListGrid()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function GetBooksListData(ByVal itemParticularId As String, ByVal itemId As String, ByVal gaId As String, ByVal declaredOwner As String, ByVal barangay As String) As DataTable
        Dim dt As New DataTable()

        Try
            ' Use stored procedure for books list data
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Books_ListOfBooks] '" & itemParticularId & "', '" & itemId & "', '" & gaId & "', '" & declaredOwner & "', '" & barangay & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading books list data: " & ex.Message)
            Return Nothing
        End Try

        Return dt
    End Function

    Private Sub BindEmptyBooksListGrid()
        Dim dt As DataTable = CreateBooksListTableSchema()

        ' Add 4 empty rows
        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdlistofBooks.DataSource = dt
        grdlistofBooks.DataBind()
    End Sub

    Private Function CreateBooksListTableSchema() As DataTable
        Dim dt As New DataTable()
        ' Columns from the books list gridview
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("ItemDescription", GetType(String))
        dt.Columns.Add("Title", GetType(String))
        dt.Columns.Add("Author", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))

        ' DataKeyNames columns
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

    ' ============================
    ' BOOKS LIST GRIDVIEW EVENT HANDLERS
    ' ============================
    Protected Sub grdlistofBooks_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdlistofBooks.PageIndex = e.NewPageIndex
        BindBooksListGrid()
    End Sub

    Protected Sub grdlistofBooks_SelectedIndexChanged(sender As Object, e As EventArgs)
        If grdlistofBooks.SelectedIndex >= 0 Then
            loadUnit()
            Dim selectedPropertyId As String = grdlistofBooks.SelectedDataKey("Property_ID")
            Session("Property_ID") = selectedPropertyId

            Dim propertyDtlId As String = grdlistofBooks.DataKeys(grdlistofBooks.SelectedIndex).Values("PropertyDetai_ID").ToString()
            PopulateBooksInformation(propertyDtlId)

            ' Refresh the current view when book is selected
            RefreshGridData()
        End If
    End Sub

    Protected Sub grdlistofBooks_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        ' Make rows clickable for selection
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdlistofBooks, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    Protected Sub grdlistofBooks_ondatabound(sender As Object, e As EventArgs)
        ' DataBound event handler - add any data binding logic here if needed
    End Sub

    ' ============================
    ' BOOKS INFORMATION FUNCTIONS
    ' ============================
    Private Function GetBooksInformationData(ByVal propertyDtlId As String) As DataTable
        Dim dt As New DataTable()

        Try
            ' Use stored procedure to get books information
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Books_GetInformation] '" & propertyDtlId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading books information data: " & ex.Message)
            Return Nothing
        End Try

        Return dt
    End Function

    Private Sub PopulateBooksInformation(ByVal propertyDtlId As String)
        Dim dt As DataTable = GetBooksInformationData(propertyDtlId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ' Populate the form fields with data
            txtbookName.Text = dt.Rows(0).Item("Name").ToString()
            txtbookdesciption.Text = dt.Rows(0).Item("Description").ToString()
            txtBookPrice.Text = FormatNumber(dt.Rows(0).Item("Price").ToString(), 2)
            txtBookClassification.Text = dt.Rows(0).Item("Classification").ToString()
            txtBookClassificationCode.Text = dt.Rows(0).Item("ClassificationCode").ToString()
            txtBookISBN.Text = dt.Rows(0).Item("ISBN").ToString()
            txtbookTitle.Text = dt.Rows(0).Item("Title").ToString()
            txtbookAuthor.Text = dt.Rows(0).Item("Author").ToString()

            ' Unit dropdown
            drpbookUnit.SelectedValue = dt.Rows(0).Item("Unit_ID").ToString()
            txtbookQuantity.Text = dt.Rows(0).Item("Quantity").ToString()

            ' Publication Date
            If Not String.IsNullOrEmpty(dt.Rows(0).Item("PublicationDate").ToString()) Then
                txtBookPublicationDate.Text = Convert.ToDateTime(dt.Rows(0).Item("PublicationDate").ToString()).ToString("MM/dd/yyyy")
            End If

            ' Acquisition section
            If Not String.IsNullOrEmpty(dt.Rows(0).Item("AcquisitionDate").ToString()) Then
                txtbookAcqDate.Text = Convert.ToDateTime(dt.Rows(0).Item("AcquisitionDate").ToString()).ToString("MM/dd/yyyy")
            End If

            txtbookMarketValue.Text = FormatNumber(dt.Rows(0).Item("MarketValue").ToString(), 2)
            txtbookAcqCost.Text = FormatNumber(dt.Rows(0).Item("AcquisitionCost").ToString(), 2)
            txtbookNoYears.Text = dt.Rows(0).Item("NoYears").ToString()

            If Not String.IsNullOrEmpty(dt.Rows(0).Item("DepreciationRate").ToString()) Then
                txtbookdepreciatedRate.Text = FormatNumber(dt.Rows(0).Item("DepreciationRate").ToString(), 2)
            End If

            txtbookUsefulLife.Text = dt.Rows(0).Item("UsefulLife").ToString()

            If Not String.IsNullOrEmpty(dt.Rows(0).Item("DepreciationValue").ToString()) Then
                txtbookdepreciatedvalue.Text = FormatNumber(dt.Rows(0).Item("DepreciationValue").ToString(), 2)
            End If

            If Not String.IsNullOrEmpty(dt.Rows(0).Item("SalvageValue").ToString()) Then
                txtbookSalvageValue.Text = FormatNumber(dt.Rows(0).Item("SalvageValue").ToString(), 2)
            End If

            ' Location section
            drpbookWarehouse.SelectedValue = dt.Rows(0).Item("Warehouse_ID").ToString()
            txtbookBay.Text = dt.Rows(0).Item("Bay").ToString()
            txtbookColumn.Text = dt.Rows(0).Item("Column").ToString()
            txtbookFloor.Text = dt.Rows(0).Item("Floor").ToString()
            txtbookRoom.Text = dt.Rows(0).Item("Room").ToString()
            txtbookShelves.Text = dt.Rows(0).Item("Shelves").ToString()
            txtbookRack.Text = dt.Rows(0).Item("Rack").ToString()
            txtbookBin.Text = dt.Rows(0).Item("Bin").ToString()

            ' Store useful_life in session if needed
            Session("useful_life") = dt.Rows(0).Item("useful_life").ToString()

        Else
            ' Clear form if no data found
            ClearBooksInformationForm()
        End If
    End Sub

    Private Sub ClearBooksInformationForm()
        ' Clear all form fields
        txtbookName.Text = ""
        txtbookdesciption.Text = ""
        txtBookPrice.Text = ""
        txtBookClassification.Text = ""
        txtBookClassificationCode.Text = ""
        txtBookISBN.Text = ""
        txtbookTitle.Text = ""
        txtbookAuthor.Text = ""
        drpbookUnit.SelectedIndex = -1
        txtbookQuantity.Text = ""
        txtBookPublicationDate.Text = ""
        txtbookAcqDate.Text = ""
        txtbookMarketValue.Text = ""
        txtbookAcqCost.Text = ""
        txtbookNoYears.Text = ""
        txtbookdepreciatedRate.Text = ""
        txtbookUsefulLife.Text = ""
        txtbookdepreciatedvalue.Text = ""
        txtbookSalvageValue.Text = ""
        drpbookWarehouse.SelectedIndex = -1
        txtbookBay.Text = ""
        txtbookColumn.Text = ""
        txtbookFloor.Text = ""
        txtbookRoom.Text = ""
        txtbookShelves.Text = ""
        txtbookRack.Text = ""
        txtbookBin.Text = ""
    End Sub

    'Loading of Unit
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        drpbookUnit.DataSource = dt
        drpbookUnit.DataTextField = ("Description")
        drpbookUnit.DataValueField = ("Unit_ID")
        drpbookUnit.DataBind()
    End Sub

    ' ============================
    ' LEDGER GRIDVIEW FUNCTIONS
    ' ============================
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



    Private Function GetLedgerData(ByVal classificationId As String) As DataTable
        Dim dt As New DataTable()

        Try
            ' Use the stored procedure for ledger data
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Ledger_v2] '" & Session("Item_ID") & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading ledger data: " & ex.Message)
            Return Nothing
        End Try

        Return dt
    End Function

    Private Sub BindEmptyLedgerGrid()
        Dim dt As DataTable = CreateLedgerTableSchema()

        ' Add 4 empty rows
        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdLedger.DataSource = dt
        grdLedger.DataBind()
    End Sub

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

    ' ============================
    ' EVENT HANDLERS
    ' ============================
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        ' DataBound event handler for ledger grid
    End Sub

    Protected Sub btnPreview_Click(sender As Object, e As EventArgs)

    End Sub



End Class