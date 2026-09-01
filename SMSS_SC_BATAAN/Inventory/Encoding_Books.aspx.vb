
Imports System.Data
Imports System.Drawing


Partial Class Inventory_Encoding_Books
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Dim dbAcquisitionCost As Double
    Dim counts As Integer = 0

    Private Class TempPropertyDetail
        Public Property PropertyNo As String
        Public Property PropertyDtl_ID As String
    End Class

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
    "TraceKey" & Guid.NewGuid().ToString("N"),
    "console.log('" & safeMessage & "');",
    True)
    End Sub

    ' =========  DROPDOWN CASCADE FOR CLASS / SUBCLASS / GA (BOOKS)  =========




    Private Sub LoadSubClassifications()

        ddSubClass.Items.Clear()

        If ddGA.SelectedValue Is Nothing OrElse
       ddGA.SelectedValue = "" OrElse
       ddGA.SelectedValue = "0" Then

            ddSubClass.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

            ddSubClass.Enabled = True
            Exit Sub

        End If

        Dim classificationID As Integer = 0
        Dim gaID As Integer = 0

        Integer.TryParse(
        Convert.ToString(Session("ClassificationID")),
        classificationID
    )

        Integer.TryParse(
        Convert.ToString(ddGA.SelectedValue),
        gaID
    )

        If classificationID = 0 OrElse gaID = 0 Then

            ddSubClass.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

            ddSubClass.Enabled = True
            Exit Sub

        End If

        Dim sql As String =
        "SELECT DISTINCT " &
        "    SubClassificationID, " &
        "    SubClassificationName " &
        "FROM dbo.tbl_SubClassification " &
        "WHERE ClassificationID = " &
            classificationID & " " &
        "AND GA_ID = " & gaID & " " &
        "ORDER BY SubClassificationName"

        AddTrace(sql)

        Dim dtSubClass As DataTable =
        objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        If dtSubClass IsNot Nothing Then

            Dim dr As DataRow = dtSubClass.NewRow()

            dr("SubClassificationID") = 0
            dr("SubClassificationName") = "No Subclass"

            dtSubClass.Rows.InsertAt(dr, 0)

            ddSubClass.DataSource = dtSubClass
            ddSubClass.DataTextField =
            "SubClassificationName"
            ddSubClass.DataValueField =
            "SubClassificationID"
            ddSubClass.DataBind()

        Else

            ddSubClass.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

        End If

        ddSubClass.Enabled = True

    End Sub

    Private Sub ClearItemDesc()

        drpbookName.Items.Clear()

        drpbookName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        drpbookName.Enabled = True

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"

        If drpbookUnit.Items.Count > 0 Then
            drpbookUnit.SelectedIndex = 0
        End If

    End Sub


    Private Sub LoadItemDesc()

        ClearItemDesc()

        If ddGA.SelectedValue Is Nothing OrElse
       ddGA.SelectedValue = "" OrElse
       ddGA.SelectedValue = "0" Then

            Exit Sub

        End If



        Dim classificationID As Integer = 0
        Dim gaID As Integer = 0
        Dim subClassificationID As Integer = 0

        Integer.TryParse(
        Convert.ToString(Session("ClassificationID")),
        classificationID
    )

        Integer.TryParse(
        Convert.ToString(ddGA.SelectedValue),
        gaID
    )

        Integer.TryParse(
        Convert.ToString(ddSubClass.SelectedValue),
        subClassificationID
    )



        Dim sql As String =
        "SELECT DISTINCT " &
        "    i.Item_ID, " &
        "    i.ItemCompleteDesc AS ItemDescription, " &
        "    COALESCE( " &
        "        cm.SubClassificationID, " &
        "        i.SubClassificationID, " &
        "        sc.SubClassificationID " &
        "    ) AS SubClassificationID " &
        "FROM dbo.m_item AS i " &
        "INNER JOIN dbo.m_item_detail AS mid " &
        "    ON mid.Item_ID = i.Item_ID " &
        "LEFT JOIN dbo.tbl_SubClassification AS sc " &
        "    ON sc.SubClassificationID = i.SubClassificationID " &
        "    AND sc.ClassificationID = " & classificationID & " " &
        "    AND sc.GA_ID = " & gaID & " " &
        "    AND sc.SubClassificationID = " &
             subClassificationID & " " &
        "LEFT JOIN dbo.tblclassmatrix AS cm " &
        "    ON cm.Item_ID = i.Item_ID " &
        "    AND cm.ClassificationID = " &
             classificationID & " " &
        "    AND cm.GA_ID = " & gaID & " " &
        "    AND cm.SubClassificationID = " &
             subClassificationID & " " &
        "WHERE sc.SubClassificationID IS NOT NULL " &
        "   OR cm.Item_ID IS NOT NULL " &
        "ORDER BY i.ItemCompleteDesc"

        AddTrace(sql)

        Dim dtItemDesc As DataTable =
        objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        If dtItemDesc Is Nothing Then

            ClearItemDesc()
            Exit Sub

        End If

        Dim dr As DataRow =
        dtItemDesc.NewRow()

        dr("Item_ID") = 0
        dr("ItemDescription") = "Select"
        dr("SubClassificationID") = 0

        dtItemDesc.Rows.InsertAt(dr, 0)

        drpbookName.DataSource = dtItemDesc
        drpbookName.DataTextField = "ItemDescription"
        drpbookName.DataValueField = "Item_ID"
        drpbookName.DataBind()

        drpbookName.Enabled = True

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"
        hdnGAId.Value = ddGA.SelectedValue

        AddTrace(
        "Book ClassificationID: " &
        classificationID
    )

        AddTrace(
        "Book GA_ID: " &
        gaID
    )

        AddTrace(
        "Book SubClassificationID: " &
        subClassificationID
    )

        AddTrace(
        "Book Item Count: " &
        Math.Max(dtItemDesc.Rows.Count - 1, 0)
    )

    End Sub


    Private Sub LoadGLAccounts()

        ddGA.Items.Clear()

        Dim classificationID As Integer = 0

        Integer.TryParse(
        Convert.ToString(Session("ClassificationID")),
        classificationID
    )

        If classificationID = 0 Then

            ddGA.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            ddGA.Enabled = True
            Exit Sub

        End If

        Dim sql As String =
            "SELECT DISTINCT " &
            "    ga.GA_ID, " &
            "    ga.GA_Title, " &
            "    cm.ga_id AS Matrix_GA_ID " &
            "FROM dbo.tbl_SubClassification AS sc " &
            "INNER JOIN dbo.view_Accntg_gen_accnt AS ga " &
            "    ON ga.GA_ID = sc.GA_ID " &
            "LEFT JOIN dbo.tblclassmatrix AS cm " &
            "    ON cm.classificationid = sc.ClassificationID " &
            "    AND cm.ga_id = sc.GA_ID " &
            "WHERE sc.ClassificationID = " & classificationID & " " &
            "UNION " &
            "SELECT DISTINCT " &
            "    ga.GA_ID, " &
            "    ga.GA_Title, " &
            "    cm.ga_id AS Matrix_GA_ID " &
            "FROM dbo.tblclassmatrix AS cm " &
            "INNER JOIN dbo.view_Accntg_gen_accnt AS ga " &
            "    ON ga.GA_ID = cm.ga_id " &
            "WHERE cm.classificationid = " & classificationID & " " &
            "ORDER BY GA_Title;"

        AddTrace(sql)

        Dim dtGA As DataTable = objDerived.GetDataTable(
        sql,
        CommandType.Text
    )

        If dtGA IsNot Nothing Then

            Dim dr As DataRow = dtGA.NewRow()

            dr("GA_ID") = 0
            dr("GA_Title") = "Select"

            dtGA.Rows.InsertAt(dr, 0)

            ddGA.DataSource = dtGA
            ddGA.DataTextField = "GA_Title"
            ddGA.DataValueField = "GA_ID"
            ddGA.DataBind()

        Else

            ddGA.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

        End If

        ddGA.Enabled = True

    End Sub


    ' Optional: mirror the selected texts to read-only textboxes if you have them
    Private Sub ClassAndSubText()
        If FindControl("txtClassification") IsNot Nothing Then
            Dim t1 = TryCast(FindControl("txtClassification"), TextBox)
            If t1 IsNot Nothing Then
                t1.Text = If(ddClass.SelectedItem IsNot Nothing, ddClass.SelectedItem.Text, "")
                t1.ReadOnly = True
            End If
        End If
        If FindControl("txtSubClass") IsNot Nothing Then
            Dim t2 = TryCast(FindControl("txtSubClass"), TextBox)
            If t2 IsNot Nothing Then
                t2.Text = If(ddSubClass.SelectedItem IsNot Nothing, ddSubClass.SelectedItem.Text, "")
                t2.ReadOnly = True
            End If
        End If
    End Sub

    ' =====================  EVENTS  =====================

    Protected Sub ddClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If ddClass.SelectedValue Is Nothing OrElse
       ddClass.SelectedValue = "" Then

            Session("ClassificationID") = "0"

        Else

            Session("ClassificationID") =
            ddClass.SelectedValue

        End If

        LoadGLAccounts()

        ddSubClass.Items.Clear()
        ddSubClass.Items.Insert(
        0,
        New ListItem("No Subclass", "0")
    )
        ddSubClass.Enabled = True

        ClearItemDesc()

        hdnGAId.Value = "0"

        ClassAndSubText()

        ViewState("Customers") = Nothing
        BindGrid()

        loadBookLedger()

        AddTrace(
        "ddClass: " &
        Convert.ToString(ddClass.SelectedValue)
    )

    End Sub

    Protected Sub ddSubClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"

        ClassAndSubText()

        LoadItemDesc()

        ViewState("Customers") = Nothing
        BindGrid()

        loadBookLedger()

        AddTrace(
        "ddSubClass: " &
        Convert.ToString(ddSubClass.SelectedValue)
    )

    End Sub


    Protected Sub ddGA_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If ddGA.SelectedValue Is Nothing OrElse
       ddGA.SelectedValue = "" Then

            hdnGAId.Value = "0"

        Else

            hdnGAId.Value = ddGA.SelectedValue

        End If

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"

        LoadSubClassifications()
        ClearItemDesc()

        ClassAndSubText()

        ViewState("Customers") = Nothing
        BindGrid()

        LoadItemDesc()
        loadBookLedger()

        AddTrace(
        "ddGA: " &
        Convert.ToString(ddGA.SelectedValue)
    )

    End Sub

    ' =====================  PAGE LOAD (single)  =====================

    Protected Sub Page_Load(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles Me.Load

        If Not Page.IsPostBack Then

            BindClassifications()

            Session("Item_ID") = 0

            LoadGLAccounts()

            ddSubClass.Items.Clear()
            ddSubClass.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )
            ddSubClass.Enabled = True

            ClearItemDesc()

            hdnGAId.Value = "0"
            hdnItemNo.Value = "0"

            ClassAndSubText()

            loadwarehouse()
            loadBookLedger()

            ViewState("Customers") = Nothing
            LoadExistingPropertyRowsIntoViewState()
            BindGrid()

            btnSave.Text = "SAVE"
            btnSave.Enabled = True

            Session.Remove("TempPropertyList")

            AddTrace(
            "ddClass: " &
            Convert.ToString(ddClass.SelectedValue)
        )

            AddTrace(
            "ddGA: " &
            Convert.ToString(ddGA.SelectedValue)
        )

            AddTrace(
            "ddSubClass: " &
            Convert.ToString(ddSubClass.SelectedValue)
        )

        End If

    End Sub


    Private Sub BindClassifications()

        Dim sql As String =
        "SELECT " &
        "    ClassificationId, " &
        "    ClassificationName " &
        "FROM dbo.tbl_Classification " &
        "WHERE isenable = 1 " &
        "AND ClassificationName LIKE 'Book%' " &
        "ORDER BY SeqNo"

        AddTrace(sql)

        Dim dt As DataTable = objDerived.GetDataTable(
        sql,
        CommandType.Text
    )

        ddClass.Items.Clear()

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

            ddClass.DataSource = dt
            ddClass.DataTextField = "ClassificationName"
            ddClass.DataValueField = "ClassificationId"
            ddClass.DataBind()

            ddClass.SelectedIndex = 0

            Session("ClassificationID") =
            ddClass.SelectedValue

        Else

            Session("ClassificationID") = "0"

        End If

        AddTrace(
        "ClassificationID: " &
        Convert.ToString(Session("ClassificationID"))
    )

    End Sub



    Private Sub LoadExistingPropertyRowsIntoViewState()
        ' 1) If there's an existing item or item_id
        Dim itemId As String = hdnItemNo.Value
        If String.IsNullOrEmpty(itemId) Then
            itemId = "0"
        End If

        ' 2) Query the DB for existing property rows for this item
        Dim dtFromDB As DataTable = objDerived.GetDataTable(
        "SELECT b.PropertyNo, " &
        "       a.Property_ID, " &
        "       b.PropertyDetai_ID, " &
        "       b.AccountablePerson " &
        "FROM AMS.Property AS a " &
        "INNER JOIN AMS.Property_Dtl AS b ON a.Property_ID = b.Property_ID " &
        "WHERE a.Item_ID = " & itemId, CommandType.Text)

        ' 3) Create a memory DataTable matching your grid columns
        Dim dtMemory As New DataTable()
        dtMemory.Columns.Add("PropertyNo", GetType(String))
        dtMemory.Columns.Add("AccountablePerson", GetType(String))
        ' Add more columns if needed (FloorLocation, Room, etc.)

        ' 4) Copy rows from dtFromDB into dtMemory
        For Each dbRow As DataRow In dtFromDB.Rows
            Dim newRow As DataRow = dtMemory.NewRow()
            newRow("PropertyNo") = dbRow("PropertyNo").ToString()
            newRow("AccountablePerson") = dbRow("AccountablePerson").ToString()
            ' ...
            dtMemory.Rows.Add(newRow)
        Next

        ' 5) Store dtMemory into ViewState
        ViewState("Customers") = dtMemory
    End Sub



    Protected Sub Inventory_Encoding_Books_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            multiviewselected()

            hdnItemNo.Value = drpbookName.SelectedValue
            'hdnGAId.Value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
            If Not String.IsNullOrEmpty(hdnItemNo.Value) Then
                hdnGAId.Value = objDerived.GetValue(
                    "select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID = " & hdnItemNo.Value,
                    CommandType.Text
                )
            End If


            loadBookLedger()
            ' Initialize ViewState("Customers") if necessary
            ViewState("Customers") = Nothing

            btnSave.Text = "SAVE"
            btnSave.Enabled = True

            Session.Remove("TempPropertyList")
        End If

    End Sub

    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT Unit_ID, Description FROM ams.m_Unit AS a ORDER BY CASE WHEN Description = '-' THEN 0 ELSE 1 END, Description;", CommandType.Text)
        drpbookUnit.DataSource = dt
        drpbookUnit.DataTextField = ("Description")
        drpbookUnit.DataValueField = ("Unit_ID")
        drpbookUnit.DataBind()

        Dim Unit_ID As Integer = objDerived.GetValue("SELECT Unit_ID FROM DBO.m_item WHERE Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        drpbookUnit.SelectedValue = Unit_ID

    End Sub



    Public Sub loadwarehouse()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("select warehouse_id,wname From ams.loc_warehouse", CommandType.Text)
        drpbookWarehouse.DataTextField = ("wname")
        drpbookWarehouse.DataValueField = ("warehouse_id")
        drpbookWarehouse.DataSource = dt
        drpbookWarehouse.DataBind()

    End Sub

    Public Sub multiviewselected()

        LoadItemDesc()

    End Sub

    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)

        If txtbookQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
            Exit Sub
        End If

        ' Validate quantity is a positive number
        Dim qty As Integer
        If Not Integer.TryParse(txtbookQuantity.Text, qty) OrElse qty <= 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must be a positive number.")
            Exit Sub
        End If

        Dim dt As DataTable
        ' Check if there is already data in ViewState
        If ViewState("Customers") IsNot Nothing Then
            dt = DirectCast(ViewState("Customers"), DataTable)
        Else
            dt = New DataTable()
            dt.Columns.Add("PropertyNo", GetType(String))
        End If

        ' Add new empty rows if necessary
        While dt.Rows.Count < qty
            dt.Rows.Add("")
        End While

        While dt.Rows.Count > qty
            dt.Rows.RemoveAt(dt.Rows.Count - 1)
        End While

        ' Save back to ViewState
        ViewState("Customers") = dt
        BindGrid()

        ' ========================
        ' GENERATE PROPERTY NUMBERS USING STORED PROCEDURE
        ' ========================
        If btnSave.Text = "SAVE" Then
            Try
                ' Get GA_ID from hidden field or dropdown
                If String.IsNullOrEmpty(hdnGAId.Value) Then
                    hdnGAId.Value = ddGA.SelectedValue
                End If

                ' Validate GA_ID first
                If String.IsNullOrEmpty(hdnGAId.Value) Then
                    AddTrace("GA_ID is empty or null")
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                    "Cannot generate property numbers: General Account information is missing. Please select a General Account first.")
                    Exit Sub
                End If

                ' Try to parse GA_ID safely
                Dim GA_ID As Integer
                If Not Integer.TryParse(hdnGAId.Value, GA_ID) Then
                    AddTrace("Invalid GA_ID format: " & hdnGAId.Value)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                    "Invalid General Account ID format. Please select a valid General Account.")
                    Exit Sub
                End If

                ' Use default RC_ID = "00"
                Dim RC_ID As String = "00"

                ' Get the current year
                Dim currentYear As Integer = Year(Now)

                ' Get the number of rows needed
                Dim rowCount As Integer = grdPropertyInfo.Rows.Count

                AddTrace(String.Format("Generating {0} property numbers for GA_ID: {1}, RC_ID: {2}, Year: {3}",
                          rowCount, GA_ID, RC_ID, currentYear))

                ' Only proceed if we have rows to generate
                If rowCount > 0 Then
                    ' Build the SQL command safely
                    Dim sqlCommand As String = String.Format(
                    "EXEC AMS.sp_Generate_PropertyNo_Main {0}, {1}, '{2}', {3}",
                    currentYear, GA_ID, RC_ID, rowCount)

                    AddTrace("Executing SQL: " & sqlCommand)

                    ' Create a DataTable to store the results
                    Dim propertyNumbers As DataTable = objDerived.GetDataTable(sqlCommand, CommandType.Text)

                    ' Check if we got results
                    If propertyNumbers Is Nothing Then
                        AddTrace("propertyNumbers is Nothing")
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                        "Error generating property numbers: No data returned from stored procedure.")
                        Exit Sub
                    End If

                    AddTrace("PropertyNumbers rows count: " & propertyNumbers.Rows.Count)

                    ' Check if we got the expected number of results
                    If propertyNumbers.Rows.Count >= rowCount Then
                        ' Loop through each row in the grid and assign property numbers
                        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                            Dim row1 As GridViewRow = grdPropertyInfo.Rows(i)

                            ' Check if row exists
                            If row1 Is Nothing Then
                                AddTrace("Row " & i & " is Nothing")
                                Continue For
                            End If

                            Dim txtPropertyNo As TextBox = CType(row1.FindControl("txtPropertyNo"), TextBox)

                            ' Note: Books page doesn't have Serial No, Floor Location, etc. in the popup grid
                            ' Only Property Number field exists

                            ' Clear property number field (check if control exists)
                            If txtPropertyNo IsNot Nothing Then
                                txtPropertyNo.Text = String.Empty
                            End If

                            ' Assign the generated property number from the results
                            If txtPropertyNo IsNot Nothing Then
                                If i < propertyNumbers.Rows.Count Then
                                    ' Check if the column exists
                                    If propertyNumbers.Columns.Contains("PropertyNumber") Then
                                        Dim propertyNo As String = propertyNumbers.Rows(i)("PropertyNumber").ToString()
                                        txtPropertyNo.Text = propertyNo
                                        AddTrace(String.Format("Row {0}: Assigned Property Number: {1}", i, propertyNo))
                                    Else
                                        AddTrace("PropertyNumber column not found in result set")
                                        txtPropertyNo.Text = String.Empty
                                    End If
                                Else
                                    AddTrace("Index " & i & " is out of range for propertyNumbers rows")
                                    txtPropertyNo.Text = String.Empty
                                End If
                            Else
                                AddTrace("txtPropertyNo control not found in row " & i)
                            End If
                        Next

                        AddTrace("Successfully generated all property numbers")
                    Else
                        AddTrace(String.Format("Failed to generate property numbers - expected {0} rows but got {1}",
                                  rowCount, propertyNumbers.Rows.Count))

                        ' Show more detailed error
                        If propertyNumbers.Rows.Count = 0 Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                            "No property numbers were generated. This might indicate that the GA_ID is not properly mapped in the system.")
                        Else
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                            String.Format("Error generating property numbers: Expected {0} numbers but only got {1}. Please try again.",
                                         rowCount, propertyNumbers.Rows.Count))
                        End If
                    End If
                Else
                    AddTrace("No rows to generate property numbers for")
                End If
            Catch ex As Exception
                AddTrace("Error generating property numbers: " & ex.Message)
                AddTrace("Stack Trace: " & ex.StackTrace)

                ' More specific error handling
                If ex.Message.Contains("String") AndAlso ex.Message.Contains("format") Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                    "Data format error. Please check that all required fields are properly selected.")
                Else
                    ' Handle error - show message to user
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                    "Error generating property numbers. Please try again. Error: " & ex.Message)
                End If
            End Try
        End If

        If ViewState("CheckboxEvent") = True Then
            Dim dt1 As DataTable = objDerived.GetDataTable(
                                    "SELECT prop.PropertyNo, prop.PropertyDetai_ID " &
                                    "FROM AMS.Property_Dtl prop " &
                                    "WHERE prop.Property_ID = '" & hf_Property_ID.Value & "'", CommandType.Text)

            Dim tempList As New List(Of TempPropertyDetail)()

            Dim iterate As Integer = 0

            If btnSave.Text = "EDIT" Then
                For Each row1 As GridViewRow In grdPropertyInfo.Rows
                    If iterate < dt1.Rows.Count Then
                        Dim txtPropertyNo As TextBox = CType(row1.FindControl("txtPropertyNo"), TextBox)

                        ' Only assign if controls are found
                        txtPropertyNo.Text = dt1.Rows(iterate).Item("PropertyNo").ToString()

                        Dim temp As New TempPropertyDetail() With {
                        .PropertyNo = txtPropertyNo.Text,
                        .PropertyDtl_ID = dt1.Rows(iterate).Item("PropertyDetai_ID")
                    }

                        tempList.Add(temp)
                        Session("TempPropertyList") = tempList
                        iterate += 1
                    End If
                Next
            End If

            If btnSave.Text = "SAVE" Then
                For Each row1 As GridViewRow In grdPropertyInfo.Rows
                    Dim txtPropertyNo As TextBox = CType(row1.FindControl("txtPropertyNo"), TextBox)

                    ' Only assign if controls are found
                    txtPropertyNo.Text = String.Empty
                Next
            End If

            'reset flag
            ViewState("CheckboxEvent") = False
        End If

        ModalPopupExtender2.Show()
    End Sub
    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs) Handles btnProceedEdit.Click

        Dim dt As DataTable
        If ViewState("Customers") IsNot Nothing Then
            dt = DirectCast(ViewState("Customers"), DataTable)
        Else
            Exit Sub
        End If

        'GET THE LIST FOR PROPERTY FROM btnaddpropertyinfo_Click event
        Dim tempList As List(Of TempPropertyDetail)

        If Session("TempPropertyList") IsNot Nothing Then
            tempList = CType(Session("TempPropertyList"), List(Of TempPropertyDetail))
        Else
            tempList = New List(Of TempPropertyDetail)()
        End If

        For Each row As GridViewRow In grdPropertyInfo.Rows
            Dim txtPropertyNo As TextBox = CType(row.FindControl("txtPropertyNo"), TextBox)

            dt.Rows(row.RowIndex)("PropertyNo") = txtPropertyNo.Text

            Dim newItem As New TempPropertyDetail With {
                .PropertyNo = txtPropertyNo.Text
            }

            tempList.Add(newItem)
        Next
        Session("TempPropertyList") = tempList
        ' Save back to ViewState
        ViewState("Customers") = dt

        ' Close the modal
        ModalPopupExtender2.Hide()
    End Sub

    Protected Sub BindGrid()
        Dim dt As DataTable = TryCast(ViewState("Customers"), DataTable)
        grdPropertyInfo.DataSource = dt
        grdPropertyInfo.DataBind()
    End Sub
    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim txtPropertyNo As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)

            ' Restore previously selected value if available
            Dim dt As DataTable = DirectCast(ViewState("Customers"), DataTable)
            'If dt IsNot Nothing AndAlso e.Row.RowIndex < dt.Rows.Count Then
            '    txtPropertyNo.Text = dt.Rows(e.Row.RowIndex)("PropertyNo").ToString()
            'End If
        End If

        ViewState("Customers") = DirectCast(grdPropertyInfo.DataSource, DataTable)


        If btnSave.Text = "EDIT" Then
            For Each gvRow As GridViewRow In grdPropertyInfo.Rows
                Dim txtPropertyNo As TextBox = CType(gvRow.FindControl("txtPropertyNo"), TextBox)
                If txtPropertyNo IsNot Nothing Then
                    txtPropertyNo.Enabled = False
                End If
            Next
        End If


    End Sub
    Protected Sub btnSave_Click(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If btnSave.Text = "SAVE" Then

            If Not ValidateBookSelections() Then
                Exit Sub
            End If

            hdnGAId.Value = ddGA.SelectedValue
            hdnItemNo.Value = drpbookName.SelectedValue
            Session("Item_ID") = drpbookName.SelectedValue

            SAVE()

            loadBookLedger()

        ElseIf btnSave.Text = "EDIT" Then

            Dim dt As DataTable =
            objDerived.GetDataTable(
                "SELECT approvalid, full_name " &
                "FROM ams.tbl_approval " &
                "ORDER BY full_name",
                CommandType.Text
            )

            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField =
            "full_name"
            drpApprovedOfficer.DataValueField =
            "approvalid"
            drpApprovedOfficer.DataBind()

            ModalPopupExtender1.Show()

            btnSave.Text = "UPDATE"

            IsEnabledTextBoxes(True)

        ElseIf btnSave.Text = "UPDATE" Then

            If Not ValidateBookSelections() Then
                Exit Sub
            End If

            hdnGAId.Value = ddGA.SelectedValue
            hdnItemNo.Value = drpbookName.SelectedValue
            Session("Item_ID") = drpbookName.SelectedValue

            EDIT()

            btnSave.Text = "SAVE"

            ClearTextBoxes()
            IsEnabledTextBoxes(True)

            For i As Integer = 0 To grdLedger1.Rows.Count - 1

                Dim cb1 As CheckBox = TryCast(
                grdLedger1.Rows(i).
                    FindControl("cbInspection"),
                CheckBox
            )

                If cb1 IsNot Nothing AndAlso
               cb1.Checked AndAlso
               cb1.Visible Then

                    cb1.Checked = False

                End If

            Next

            loadBookLedger()

        End If
        btnSave.Enabled = False
    End Sub


    Public Sub EDIT()
        If txtbookAcqCost.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
        Else
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            ' ---- IDs / Integers (BIGINT) ----
            objDerived.cmd.Parameters.Add("@EquipInfoId", SqlDbType.BigInt).Value = If(Long.TryParse(hf_EquipInfoId.Value, Nothing), CLng(hf_EquipInfoId.Value), 0L)
            objDerived.cmd.Parameters.Add("@NoYears", SqlDbType.BigInt).Value = If(Long.TryParse(txtNoYears.Text, Nothing), CLng(txtNoYears.Text), 0L)
            objDerived.cmd.Parameters.Add("@DepreciationRate", SqlDbType.BigInt).Value = If(Long.TryParse(txtbookdepreciatedRate.Text, Nothing), CLng(txtbookdepreciatedRate.Text), 0L)
            objDerived.cmd.Parameters.Add("@UsefulLife", SqlDbType.BigInt).Value = If(Long.TryParse(txtbookUsefulLife.Text, Nothing), CLng(txtbookUsefulLife.Text), 0L)

            objDerived.cmd.Parameters.Add("@Item_ID", SqlDbType.BigInt).Value = If(Long.TryParse(hf_Item_ID.Value, Nothing), CLng(hf_Item_ID.Value), 0L)
            objDerived.cmd.Parameters.Add("@Unit_ID", SqlDbType.BigInt).Value = If(Long.TryParse(drpbookUnit.SelectedValue, Nothing), CLng(drpbookUnit.SelectedValue), 0L)

            objDerived.cmd.Parameters.Add("@Property_ID", SqlDbType.BigInt).Value = If(Long.TryParse(hf_Property_ID.Value, Nothing), CLng(hf_Property_ID.Value), 0L)
            objDerived.cmd.Parameters.Add("@Qty", SqlDbType.BigInt).Value = If(Long.TryParse(txtbookQuantity.Text, Nothing), CLng(txtbookQuantity.Text), 0L)

            objDerived.cmd.Parameters.Add("@EquipmentId", SqlDbType.BigInt).Value = If(Long.TryParse(hf_EquipmentId.Value, Nothing), CLng(hf_EquipmentId.Value), 0L)
            objDerived.cmd.Parameters.Add("@warehouseid", SqlDbType.BigInt).Value = If(Long.TryParse(drpbookWarehouse.SelectedValue, Nothing), CLng(drpbookWarehouse.SelectedValue), 0L)

            ' ---- Decimals ----
            Dim d As Decimal
            objDerived.cmd.Parameters.Add("@DepreciationValue", SqlDbType.Decimal).Value = If(Decimal.TryParse(txtbookdepreciatedvalue.Text.Replace(",", ""), d), d, 0D)
            objDerived.cmd.Parameters.Add("@SalvageValue", SqlDbType.Decimal).Value = If(Decimal.TryParse(txtbookSalvageValue.Text.Replace(",", ""), d), d, 0D)
            objDerived.cmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = If(Decimal.TryParse(txtbookAcqCost.Text.Replace(",", ""), d), d, 0D)
            objDerived.cmd.Parameters.Add("@MarketValue", SqlDbType.Decimal).Value = If(Decimal.TryParse(txtbookMarketValue.Text.Replace(",", ""), d), d, 0D)

            ' ---- Strings (keep as varchar) ----
            objDerived.cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = txtbookName.Text
            objDerived.cmd.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = txtbookdesciption.Text
            objDerived.cmd.Parameters.Add("@ISBN", SqlDbType.VarChar, 50).Value = txtBookISBN.Text
            objDerived.cmd.Parameters.Add("@Classification", SqlDbType.VarChar, 50).Value = txtBookClassification.Text
            objDerived.cmd.Parameters.Add("@ClassificationCode", SqlDbType.VarChar, 50).Value = txtBookClassificationCode.Text
            objDerived.cmd.Parameters.Add("@Title", SqlDbType.VarChar, 50).Value = txtbookTitle.Text
            objDerived.cmd.Parameters.Add("@Author", SqlDbType.VarChar, 50).Value = txtbookAuthor.Text
            objDerived.cmd.Parameters.Add("@PublicationDate", SqlDbType.VarChar, 50).Value = txtBookPublicationDate.Text
            objDerived.cmd.Parameters.Add("@Property_Date", SqlDbType.VarChar, 50).Value = txtbookAcqDate.Text

            objDerived.cmd.Parameters.Add("@Bay", SqlDbType.VarChar, 50).Value = txtbookBay.Text
            objDerived.cmd.Parameters.Add("@Column", SqlDbType.VarChar, 50).Value = txtbookColumn.Text
            objDerived.cmd.Parameters.Add("@Floor", SqlDbType.VarChar, 50).Value = txtbookFloor.Text
            objDerived.cmd.Parameters.Add("@Room", SqlDbType.VarChar, 50).Value = txtbookRoom.Text
            objDerived.cmd.Parameters.Add("@Shelves", SqlDbType.VarChar, 50).Value = txtbookShelves.Text
            objDerived.cmd.Parameters.Add("@Rack", SqlDbType.VarChar, 50).Value = txtbookRack.Text
            objDerived.cmd.Parameters.Add("@Bin", SqlDbType.VarChar, 50).Value = txtbookBin.Text

            'objDerived.cmd.Parameters.AddWithValue("@warehouseid", drpbookWarehouse.SelectedValue)
            objDerived.cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 255).Value = txtRemarks.Text




            objDerived.Execute("AMS.sp_Edit_Books", CommandType.StoredProcedure)


            Dim dtAccount As New DataTable
            Dim cb1 As CheckBox
            Dim LedgerID As Long
            Dim IsIssuance As String

            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

            For i As Integer = 0 To dtAccount.Rows.Count - 1
                cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                LedgerID = dtAccount.Rows(i).Item("Ledger_ID").ToString()
                IsIssuance = dtAccount.Rows(i).Item("Trans_type").ToString()

                If cb1.Visible AndAlso cb1.Checked Then


                    If IsIssuance = "Issuance" Then
                        objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] " &
                                           "SET CreditCost = '" & txtbookAcqCost.Text.Replace(",", "") & "', " &
                                           "CreditUnit = '" & drpbookUnit.Text.Replace(",", "") & "', " &
                                           "dDate = '" & txtbookAcqDate.Text & "', " &
                                           "BalanceUnit = '" & drpbookUnit.SelectedValue & "' " &
                                           "WHERE Ledger_ID = '" & LedgerID & "' ", CommandType.Text)

                    Else
                        Dim unitCost As Decimal = Convert.ToDecimal(txtbookAcqCost.Text.Replace(",", ""))
                        Dim quantity As Integer = Convert.ToInt32(txtbookQuantity.Text)

                        ' Calculate debit cost
                        Dim debitCost As Decimal = unitCost * quantity

                        Dim Unit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)

                        objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] " &
                      "SET DebitQty = '" & quantity & "', " &
                      "DebitCost = '" & debitCost & "', " &
                      "DebitUnit = '" & Unit & "', " &
                      "BalanceQty = '" & quantity & "', " &
                      "BalanceCost = '" & debitCost & "', " &
                      "BalanceUnit = '" & Unit & "', " &
                      "dDate = '" & txtbookAcqDate.Text & "' " &
                      "WHERE Ledger_ID = '" & LedgerID & "' ", CommandType.Text)
                    End If

                End If
            Next

            'REBALANCE FROM EDITED ROW ABOVE
            'objDerived.GetDataTable("Exec [AMS].[ReBalanceLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

            Dim tempTableDtlProperty As List(Of TempPropertyDetail) = CType(Session("TempPropertyList"), List(Of TempPropertyDetail))

            'SEPARATE SAVING FROM PROPERTY INFORMATION POPOUT GRID VIEW ONLY
            Try

                Dim iterate As Integer = 0
                For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1

                    Dim gvRow As GridViewRow = grdPropertyInfo.Rows(i)

                    Dim textPN As TextBox = CType(gvRow.FindControl("txtPropertyNo"), TextBox)

                    iterate += 1

                    Dim current As New TempPropertyDetail With {
                    .PropertyNo = textPN.Text
                    }

                    If i < tempTableDtlProperty.Count Then
                        Dim original As TempPropertyDetail = tempTableDtlProperty(i)

                        '---------------================UPDATE ROW IF DIFFERENT FROM BEFORE=====---------------
                        objDerived.GetRecords("UPDATE [AMS].[Property_Dtl] " &
                                                       "SET PropertyNo = '" & current.PropertyNo & "', " &
                                                       "MarketValue = '" & txtbookMarketValue.Text & "' " &
                                                       "WHERE PropertyDetai_ID = '" & original.PropertyDtl_ID & "' ", CommandType.Text)


                    Else '---------=============SAVING/INSERTING NEW ROW OF PROPERTY NO=========---------------

                        Dim locations As String = ""

                        Dim Prop_Dtl As New t_property_dtl
                        With Prop_Dtl
                            .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                            .Property_ID = hf_Property_ID.Value
                            .Issued = False
                            .Repair = False
                            .Dispose = False
                            .DisposeDate = "1/1/1900"
                            .IsInspectionForDisposal = False
                            .InspectionDate = txtbookAcqDate.Text
                            .F_ID = 1
                            ' .SerialNo = txtbookSerialNo.text
                            .Barcode = " "
                            .Amount = CType(txtbookAcqCost.Text, Decimal)
                            .Status = "Accepted"
                            '.Details = txtbookSpecification.Text
                            .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                            .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                            .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
                            .Function_ID = 86
                        End With

                        Dim PropDtl_ID As Integer
                        PropDtl_ID = Prop_Dtl.save()

                        Dim info_id As Integer
                        Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info

                        With objEquipInfo
                            .EquipInfoId = 0
                            .AIRDtl_ID = 0
                            .IsAccepted = True
                            .Property_Dtl_ID = PropDtl_ID
                            ' .SerialNo = txtbookSerialNo.text
                            .Name = txtbookName.Text
                            .Description = txtbookdesciption.Text
                            ' .PowerInput = txtbookpowerinput.text
                            '                        .Dimension = txtbookdimension.text
                            .AreaCapacity = txtbookareacapacity.Text
                            '.Model = txtbookmodel.text
                            '.Warranty = txtbookwaranty.text
                            '.Specification = txtbookSpecification.Text
                            .DepreciationRate = txtbookdepreciatedRate.Text
                            .DepreciationValue = txtbookdepreciatedvalue.Text
                            .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                            .RoomLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIRoom"), TextBox).Text
                            .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                            'CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).SelectedItem.value
                            .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
                            .SalvageValue = txtbookSalvageValue.Text
                            .Classification = txtBookClassification.Text
                            .ClassificationCode = txtBookClassificationCode.Text
                            .Title = txtbookTitle.Text
                            .PublicationDate = txtBookPublicationDate.Text
                            .bPrice = txtBookPrice.Text
                            .ISBN = txtBookISBN.Text
                            .Author = txtbookAuthor.Text
                            .NoYears = txtNoYears.Text
                            .UsefulLife = txtbookUsefulLife.Text


                        End With

                        info_id = objEquipInfo.save()
                        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

                        Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details
                        With objEquipDtl
                            .EquipmentId = 0
                            .EquipInfoId = info_id
                            .Property_Dtl_ID = PropDtl_ID
                            .MarketValue = txtbookMarketValue.Text
                            .Condition = ""


                            'Optimize code
                            'Dim locations As String = ""
                            Dim prefix As String = ""
                            If Not String.IsNullOrEmpty(txtbookBay.Text) Then
                                locations += "Bay-" & txtbookBay.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookColumn.Text) Then
                                locations += prefix & "Column-" & txtbookColumn.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookFloor.Text) Then
                                locations += prefix & "Floor-" & txtbookFloor.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookRoom.Text) Then
                                locations += prefix & "Room-" & txtbookRoom.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookShelves.Text) Then
                                locations += prefix & "Shelves-" & txtbookShelves.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookRack.Text) Then
                                locations += prefix & "Rack-" & txtbookRack.Text
                                prefix = " "
                            End If

                            If Not String.IsNullOrEmpty(txtbookBin.Text) Then
                                locations += prefix & "Bin-" & txtbookBin.Text
                            End If

                            .Location = locations

                            .Bay = txtbookBay.Text
                            .Column = txtbookColumn.Text
                            .Floor = txtbookFloor.Text
                            .Room = txtbookRoom.Text
                            .Shelves = txtbookShelves.Text
                            .Rack = txtbookRack.Text
                            .Bin = txtbookBin.Text


                            .Status = "Accepted"
                            If drpbookWarehouse.SelectedValue = "" Then
                                .WarehouseID = 0
                            Else

                                .WarehouseID = drpbookWarehouse.SelectedValue
                            End If
                            '   .BuildingId = drpInstalledAtBuilding.selecteditem.value
                            '                        .MaintenanceContactNo = txtContractor.text
                            ' .MaintenanceContactPerson = txtContactPerson.text
                            '.MaintenanceContractor = txtCellphoneNo.text


                        End With
                        objEquipDtl.save()

                    End If
                Next
            Catch ex As Exception

            End Try


            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        End If

        Session.Remove("TempPropertyList")

    End Sub
    Public Sub SAVE()

        Dim a1 As String

        Dim missingFields As New List(Of String)

        ' ===== VALIDATE ALL ROWS IN grdPropertyInfo =====
        ' Check if grid has rows
        If grdPropertyInfo.Rows.Count > 0 Then
            For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                Dim row As GridViewRow = grdPropertyInfo.Rows(i)

                ' Find the Property Number TextBox in this row
                Dim txtPropertyNo As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)

                ' Validate Property Number is not empty
                If txtPropertyNo IsNot Nothing Then
                    If String.IsNullOrWhiteSpace(txtPropertyNo.Text) Then
                        missingFields.Add(String.Format("Property Number (Row {0})", i + 1))
                    End If
                Else
                    missingFields.Add(String.Format("Property Number control not found (Row {0})", i + 1))
                End If

                ' Optional: Also validate Serial Number if required
                'Dim txtSerialNo As TextBox = TryCast(row.FindControl("txtSerialNoOfEquip"), TextBox)
                'If txtSerialNo IsNot Nothing Then
                '    If String.IsNullOrWhiteSpace(txtSerialNo.Text) Then
                '        missingFields.Add(String.Format("Serial Number (Row {0})", i + 1))
                '    End If
                'End If


            Next
        Else
            missingFields.Add("Property Information - No rows found. Please add property information first.")
        End If
        ' ===== END OF GRID VALIDATION =====


        If String.IsNullOrWhiteSpace(txtbookdesciption.Text) Then
            missingFields.Add("Description")
        End If
        If drpbookUnit.SelectedIndex = 0 Then
            missingFields.Add("Unit")
        End If
        If String.IsNullOrWhiteSpace(txtbookQuantity.Text) Then
            missingFields.Add("Quantity")
        End If

        'If String.IsNullOrWhiteSpace(txtRemarks.Text) Then
        '    missingFields.Add("Remarks")
        'End If
        If String.IsNullOrWhiteSpace(txtbookAcqDate.Text) Then
            missingFields.Add("Acquisition Date")
        End If
        If String.IsNullOrWhiteSpace(txtbookAcqCost.Text) Or txtbookAcqCost.Text = "0.00" Or txtbookAcqCost.Text = "0" Then
            missingFields.Add("Acquisition Cost")
        End If

        If missingFields.Count > 0 Then
            Dim message As String = "Please fill up the required field(s):" &
                            "\n - " & String.Join("\n - ", missingFields)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, message)
            Exit Sub

        Else
            Dim Prop_Hdr As New t_property_hdr
            With Prop_Hdr
                '.Property_ID = Property_ID
                .Property_Date = txtbookAcqDate.Text
                .Issuance = 0
                .Remarks = txtRemarks.Text
                .Emp_ID = 0
                .F_ID = 1
                .AIRDtl_ID = 0
                .deptid = 0
                .isDonated = False
                .GA_ID = ddGA.SelectedValue
                .DonationRemarks = ""
                .Qty = txtbookQuantity.Text
                .Balance = txtbookQuantity.Text
                .Cost = CType(txtbookAcqCost.Text, Decimal)
                .Item_ID = hdnItemNo.Value
                .Property_code = objDerived.GetValue("select ga_code2 from [AMS].[vw_item_master_list] where Item_ID ='" & hdnItemNo.Value & "' ", CommandType.Text)
                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .Function_ID = objDerived.GetValue("select Function_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .TD_ID = 1
                .Project_ID = 0
                .Program_id = 0
                .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
            End With

            Dim PropHdr_ID As Integer = 0
            PropHdr_ID = Prop_Hdr.save()


            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Property SET ClassificationID = '" & ddClass.SelectedValue & "',SubClassificationID = '" & ddSubClass.SelectedValue & "'  WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)


            Dim locations As String = ""
            For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1

                Dim Prop_Dtl As New t_property_dtl
                With Prop_Dtl
                    .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                    .Property_ID = PropHdr_ID
                    .Issued = False
                    .Repair = False
                    .Dispose = False
                    .DisposeDate = "1/1/1900"
                    .IsInspectionForDisposal = False
                    .InspectionDate = txtbookAcqDate.Text
                    .F_ID = 1
                    ' .SerialNo = txtbookSerialNo.text
                    .Barcode = " "
                    .Amount = CType(txtbookAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    '.Details = txtbookSpecification.Text
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
                    .Function_ID = 86
                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = Prop_Dtl.save()

                '  objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtbookMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)


                Dim info_id As Integer
                Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info

                With objEquipInfo
                    .EquipInfoId = 0
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = PropDtl_ID
                    ' .SerialNo = txtbookSerialNo.text
                    .Name = txtbookName.Text
                    .Description = txtbookdesciption.Text
                    ' .PowerInput = txtbookpowerinput.text
                    '                        .Dimension = txtbookdimension.text
                    .AreaCapacity = txtbookareacapacity.Text
                    '                        .Model = txtbookmodel.text
                    '                        .Warranty = txtbookwaranty.text
                    '                        .Specification = txtbookSpecification.Text
                    .DepreciationRate = txtbookdepreciatedRate.Text
                    .DepreciationValue = txtbookdepreciatedvalue.Text
                    .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                    .RoomLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIRoom"), TextBox).Text
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    'CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).SelectedItem.value
                    .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
                    .SalvageValue = txtbookSalvageValue.Text
                    .Classification = txtBookClassification.Text
                    .ClassificationCode = txtBookClassificationCode.Text
                    .Title = txtbookTitle.Text
                    .PublicationDate = txtBookPublicationDate.Text
                    .bPrice = txtBookPrice.Text
                    .ISBN = txtBookISBN.Text
                    .Author = txtbookAuthor.Text
                    .NoYears = If(String.IsNullOrWhiteSpace(txtNoYears.Text), 0, Convert.ToInt32(txtNoYears.Text))

                    .UsefulLife = If(String.IsNullOrWhiteSpace(txtbookUsefulLife.Text), 0, Convert.ToInt32(txtbookUsefulLife.Text))
                    .Property_ID = PropHdr_ID


                End With

                info_id = objEquipInfo.save()
                objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Remarks = '" & txtRemarks.Text.Replace("'", "''") & "', Unit_ID = " & drpbookUnit.SelectedValue & " WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)


                Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details
                With objEquipDtl
                    .EquipmentId = 0
                    .EquipInfoId = info_id
                    .Property_Dtl_ID = PropDtl_ID
                    .MarketValue = If(String.IsNullOrWhiteSpace(txtbookMarketValue.Text), 0D, Convert.ToDecimal(txtbookMarketValue.Text))

                    .Condition = ""

                    'If txtbookBay.Text <> "" Then
                    '    locations = "Bay-" & txtbookBay.Text
                    'End If

                    'If txtbookColumn.Text <> "" Then
                    '    locations = locations + " " + "Column-" & txtbookColumn.Text
                    'End If

                    'If txtbookFloor.Text <> "" Then
                    '    locations = locations + " " + "Floor-" & txtbookFloor.Text
                    'End If

                    'If txtbookRoom.Text <> "" Then
                    '    locations = locations + " " + "Room-" & txtbookRoom.Text
                    'End If

                    'If txtbookShelves.Text <> "" Then
                    '    locations = locations + " " + "Shelves-" & txtbookShelves.Text
                    'End If

                    'If txtbookRack.Text <> "" Then
                    '    locations = locations + " " + "Rack-" & txtbookRack.Text
                    'End If

                    'If txtbookBin.Text <> "" Then
                    '    locations = locations + " " + "Bin-" & txtbookBin.Text
                    'End If

                    'If String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Bay-" & txtbookBay.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Column-" & txtbookColumn.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Floor-" & txtbookFloor.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Room-" & txtbookRoom.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookRack.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Shelves-" & txtbookShelves.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookBin.Text) Then
                    '    locations = "Rack-" & txtbookRack.Text
                    'ElseIf String.IsNullOrEmpty(txtbookBay.Text) And String.IsNullOrEmpty(txtbookColumn.Text) And String.IsNullOrEmpty(txtbookFloor.Text) And String.IsNullOrEmpty(txtbookRoom.Text) And String.IsNullOrEmpty(txtbookShelves.Text) And String.IsNullOrEmpty(txtbookRack.Text) Then
                    '    locations = "Bin-" & txtbookBin.Text
                    'End If

                    'Optimize code
                    'Dim locations As String = ""
                    Dim prefix As String = ""
                    If Not String.IsNullOrEmpty(txtbookBay.Text) Then
                        locations += "Bay-" & txtbookBay.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookColumn.Text) Then
                        locations += prefix & "Column-" & txtbookColumn.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookFloor.Text) Then
                        locations += prefix & "Floor-" & txtbookFloor.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookRoom.Text) Then
                        locations += prefix & "Room-" & txtbookRoom.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookShelves.Text) Then
                        locations += prefix & "Shelves-" & txtbookShelves.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookRack.Text) Then
                        locations += prefix & "Rack-" & txtbookRack.Text
                        prefix = " "
                    End If

                    If Not String.IsNullOrEmpty(txtbookBin.Text) Then
                        locations += prefix & "Bin-" & txtbookBin.Text
                    End If

                    .Location = locations

                    .Bay = txtbookBay.Text
                    .Column = txtbookColumn.Text
                    .Floor = txtbookFloor.Text
                    .Room = txtbookRoom.Text
                    .Shelves = txtbookShelves.Text
                    .Rack = txtbookRack.Text
                    .Bin = txtbookBin.Text


                    .Status = "Accepted"
                    If drpbookWarehouse.SelectedValue = "" Then
                        .WarehouseID = 0
                    Else

                        .WarehouseID = drpbookWarehouse.SelectedValue
                    End If
                    '   .BuildingId = drpInstalledAtBuilding.selecteditem.value
                    '                        .MaintenanceContactNo = txtContractor.text
                    ' .MaintenanceContactPerson = txtContactPerson.text
                    '.MaintenanceContractor = txtCellphoneNo.text

                    .Property_ID = PropHdr_ID

                End With
                objEquipDtl.save()

            Next

            Dim Prop_Ledger As New t_PropertyLedger

            With Prop_Ledger
                .Ledger_ID = 0
                .PropertyNo = ""
                .SerialNo = ""
                .Trans_Type = "Manual Entry"
                .dDate = txtbookAcqDate.Text
                .Ref = ""
                .AccountablePerson = ""
                .Department = 0
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = hdnItemNo.Value
                .DebitQty = txtbookQuantity.Text
                .DebitCost = CType(txtbookAcqCost.Text, Decimal) * txtbookQuantity.Text
                .DebitUnit = drpbookUnit.SelectedValue
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .BalanceUnit = drpbookUnit.SelectedValue
                .Property_ID = PropHdr_ID

                Dim Eqty As Integer = 0
                Dim Eqbalance As Decimal = 0D
                Dim CurrentItemID As Long = 0
                Dim dtledger As New DataTable

                Long.TryParse(
                    Convert.ToString(Session("Item_ID")),
                    CurrentItemID
                )

                dtledger = objDerived.GetDataTable(
                    "SELECT TOP 1 " &
                    "    ISNULL(BalanceQty, 0) AS BalanceQty, " &
                    "    ISNULL(BalanceCost, 0) AS BalanceCost " &
                    "FROM AMS.TbProperty_Ledger " &
                    "WHERE Item_ID = '" & CurrentItemID & "' " &
                    "ORDER BY dDate DESC, Ledger_ID DESC",
                    CommandType.Text
                )

                If dtledger IsNot Nothing AndAlso dtledger.Rows.Count > 0 Then
                    If Not IsDBNull(dtledger.Rows(0)("BalanceQty")) Then
                        Eqty = Convert.ToInt32(dtledger.Rows(0)("BalanceQty"))
                    End If

                    If Not IsDBNull(dtledger.Rows(0)("BalanceCost")) Then
                        Eqbalance = Convert.ToDecimal(dtledger.Rows(0)("BalanceCost"))
                    End If
                End If

                Dim NewEquipmentQty As Integer =
                        Convert.ToInt32(txtbookQuantity.Text)

                Dim EquipmentAcquisitionCost As Decimal =
                CType(txtbookAcqCost.Text.Replace(",", ""), Decimal)

                Dim NewEquipmentCost As Decimal =
                EquipmentAcquisitionCost * NewEquipmentQty

                .BalanceQty = Eqty + NewEquipmentQty
                .BalanceCost = Eqbalance + NewEquipmentCost


            End With
            Prop_Ledger.save()

            btnSave.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            ' multiviewselected()
        End If

        'REBALANCE FROM EDITED ROW ABOVE
        'objDerived.GetDataTable("Exec [AMS].[ReBalanceLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
        loadBookLedger()
        'End If
    End Sub
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
    End Sub

    Protected Sub grdLedger1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim cbInspection As CheckBox = TryCast(e.Row.FindControl("cbInspection"), CheckBox)
            Dim TransType As String = ""

            If e.Row.DataItem IsNot Nothing Then
                TransType = DataBinder.Eval(e.Row.DataItem, "Trans_Type").ToString().Trim()
            End If

            If cbInspection IsNot Nothing Then
                If TransType = "Starting Inventory" Then
                    cbInspection.Enabled = True
                Else
                    cbInspection.Checked = False
                    cbInspection.Enabled = False
                End If
            End If

            If e.Row.Cells(9).Text = "0" Then
                e.Row.Cells(9).Text = " "
            End If
            If e.Row.Cells(10).Text = "0.00" Then
                e.Row.Cells(10).Text = " "
            End If
            If e.Row.Cells(11).Text = "0" Then
                e.Row.Cells(11).Text = " "
            End If
            If e.Row.Cells(12).Text = "0.00" Then
                e.Row.Cells(12).Text = " "
            End If

        End If
    End Sub
    Public Function createdatatableledger(
    ByVal row As Integer
) As DataTable

        Dim dt As New DataTable()

        dt.Columns.Add("dDate", GetType(Date))
        dt.Columns.Add("Trans_Type", GetType(String))
        dt.Columns.Add("ref", GetType(String))
        dt.Columns.Add("AccountablePerson", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("position", GetType(String))
        dt.Columns.Add("acceptedby", GetType(String))
        dt.Columns.Add("inspectedby", GetType(String))
        dt.Columns.Add("BalanceUnit", GetType(String))
        dt.Columns.Add("UnitPrice", GetType(Decimal))
        dt.Columns.Add("DebitQty", GetType(Integer))
        dt.Columns.Add("DebitUnit", GetType(String))
        dt.Columns.Add("DebitCost", GetType(Decimal))
        dt.Columns.Add("CreditQty", GetType(Integer))
        dt.Columns.Add("CreditUnit", GetType(String))
        dt.Columns.Add("CreditCost", GetType(Decimal))
        dt.Columns.Add("BalQty", GetType(Integer))
        dt.Columns.Add("BalCost", GetType(Decimal))

        For i As Integer = 0 To row
            dt.Rows.Add(dt.NewRow())
        Next

        Return dt

    End Function

    Public Sub loadBookLedger()

        Dim itemID As Long = 0

        If drpbookName.SelectedValue IsNot Nothing AndAlso
       drpbookName.SelectedValue <> "" AndAlso
       drpbookName.SelectedValue <> "0" Then

            Long.TryParse(
            drpbookName.SelectedValue,
            itemID
        )

        End If

        If itemID = 0 AndAlso
       Not String.IsNullOrWhiteSpace(hdnItemNo.Value) AndAlso
       hdnItemNo.Value <> "0" Then

            Long.TryParse(
            hdnItemNo.Value,
            itemID
        )

        End If

        If itemID = 0 AndAlso
       Session("Item_ID") IsNot Nothing Then

            Long.TryParse(
            Convert.ToString(Session("Item_ID")),
            itemID
        )

        End If

        Dim dtAccount As DataTable

        If itemID > 0 Then

            hdnItemNo.Value = itemID.ToString()
            Session("Item_ID") = itemID

            dtAccount = objDerived.GetDataTable(
            "EXEC [AMS].[PropertyLedger] '" &
            itemID & "'",
            CommandType.Text
        )

        Else

            hdnItemNo.Value = "0"
            Session("Item_ID") = 0

            dtAccount = createdatatableledger(9)

        End If

        If dtAccount Is Nothing Then

            dtAccount = createdatatableledger(9)

        ElseIf dtAccount.Rows.Count < 10 Then

            dtAccount.Merge(
            createdatatableledger(
                9 - dtAccount.Rows.Count
            )
        )

        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()

    End Sub

    Private Function ValidateBookSelections() As Boolean

        If ddGA.SelectedValue Is Nothing OrElse
       ddGA.SelectedValue = "" OrElse
       ddGA.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Please select General Account."
        )

            Return False

        End If



        If drpbookName.SelectedValue Is Nothing OrElse
       drpbookName.SelectedValue = "" OrElse
       drpbookName.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Please select Name."
        )

            Return False

        End If

        Return True

    End Function


    Protected Sub drpbookName_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If drpbookName.SelectedValue Is Nothing OrElse
       drpbookName.SelectedValue = "" OrElse
       drpbookName.SelectedValue = "0" Then

            Session("Item_ID") = 0
            hdnItemNo.Value = "0"

            If drpbookUnit.Items.Count > 0 Then
                drpbookUnit.SelectedIndex = 0
            End If

            ViewState("Customers") = Nothing
            BindGrid()

            loadBookLedger()
            Exit Sub

        End If

        Session("Item_ID") =
        drpbookName.SelectedValue

        hdnItemNo.Value =
        drpbookName.SelectedValue

        hdnGAId.Value =
        ddGA.SelectedValue

        ViewState("Customers") = Nothing

        loadBookLedger()
        loadUnit()
        loadUsefulLife()
        AddTrace(
        "Book Item_ID: " &
        drpbookName.SelectedValue
    )

    End Sub

    Function Depreciation() As Double
        dbAcquisitionCost = txtbookAcqCost.Text
        Dim dbSalvageValue As Double
        dbSalvageValue = dbAcquisitionCost * 0.05
        txtbookSalvageValue.Text = dbSalvageValue.ToString("n2")

        If txtbookAcqCost.Text <> "" And txtbookUsefulLife.Text <> "" Then
            'Depreciation
            Dim dbDepreciation As Double
            dbDepreciation = Val(dbAcquisitionCost - dbSalvageValue) / Val(txtbookUsefulLife.Text)
            txtBookDepreciation.Text = dbDepreciation.ToString("n2")
            'End Depreciation

            'Depreciated
            Dim dbDepreciated As Double
            dbDepreciated = dbAcquisitionCost - (dbDepreciation * Val(txtNoYears.Text))
            txtbookdepreciatedvalue.Text = dbDepreciated.ToString("n2")
            'end Depreciated
        Else

        End If
        Return True
    End Function
    Protected Sub txtbookAcqCost_TextChanged(sender As Object, e As EventArgs) Handles txtbookAcqCost.TextChanged

    End Sub
    Protected Sub txtbookAcqDate_TextChanged(sender As Object, e As EventArgs) Handles txtbookAcqDate.TextChanged

    End Sub
    Protected Sub txtbookUsefulLife_TextChanged(sender As Object, e As EventArgs) Handles txtbookUsefulLife.TextChanged

    End Sub
    Protected Sub txtbookSalvageValue_TextChanged(sender As Object, e As EventArgs) Handles txtbookSalvageValue.TextChanged

    End Sub
    Private Function DecryptEncrypt(ByVal TheText As String) As String
        Dim tempChar As String = Nothing
        Dim i As Integer = 0
        For i = 1 To TheText.Length
            If Convert.ToInt32(TheText.Chars(i - 1)) < 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) + 100)
            ElseIf Convert.ToInt32(TheText.Chars(i - 1)) > 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) - 100)
            End If
            TheText = TheText.Remove(i - 1, 1).Insert(i - 1, (CChar(ChrW(tempChar))).ToString())
        Next i
        Return TheText

    End Function
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ModalPopupExtender1.Hide()
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs)
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else
            btnSave.Text = "UPDATE"
            btnSave.Enabled = True
        End If
    End Sub
    Protected Sub txtPropertyNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim text As TextBox

        'For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
        '    text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPropertyNo"), TextBox)
        '    Dim dt As New DataTable
        '    dt = objDerived.GetDataTable("SELECT a.Item_ID, b.PropertyNo FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID WHERE  (b.PropertyNo = '" & text.Text & "')", CommandType.Text)
        '    If dt.Rows.Count > 0 Then
        '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is already exist!")
        '        text.Text = ""
        '    Else

        '    End If
        'Next
        'ModalPopupExtender2.Show()

        Dim text As TextBox
        If btnSave.Text = "SAVE" Then

            For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPropertyNo"), TextBox)
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT a.Item_ID, b.PropertyNo FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID WHERE  (b.PropertyNo = '" & text.Text & "')", CommandType.Text)
                If dt.Rows.Count > 0 Then
                    If text.Text = "" Then
                    Else
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is already exist!")
                    End If

                    text.Text = ""
                Else

                End If
            Next
        ElseIf btnSave.Text = "EDIT" Then

            Dim dt1 As DataTable = objDerived.GetDataTable("SELECT b.PropertyNo,a.Property_ID,b.PropertyDetai_ID FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            For i As Integer = dt1.Rows.Count To grdPropertyInfo.Rows.Count - 1
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPropertyNo"), TextBox)
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT a.Item_ID, b.PropertyNo FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID WHERE  (b.PropertyNo = '" & text.Text & "')", CommandType.Text)
                If dt.Rows.Count > 0 Then
                    If text.Text = "" Then
                    Else
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is already exist!")
                    End If

                    text.Text = ""
                Else

                End If
            Next
        End If
        ModalPopupExtender2.Show()
    End Sub


    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSave.Text = "SAVE"
        btnSave.Enabled = True
        txtbookQuantity.Enabled = True

        ClearTextBoxes()
        IsEnabledTextBoxes(True)

        ViewState("CheckboxEvent") = True

        Dim cb1 As CheckBox

        Dim dt1 As DataTable = objDerived.GetDataTable("[AMS].[sp_View_Encoding] 'Books','" & hdnItemNo.Value & "'", CommandType.Text)

        For i As Integer = 0 To dt1.Rows.Count - 1
            cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

            If cb1.Checked AndAlso cb1.Visible Then

                btnSave.Text = "EDIT"
                IsEnabledTextBoxes(False)
                txtbookQuantity.Enabled = False
                txtBookClassification.Text = dt1.Rows(i).Item("Classification").ToString
                txtBookClassificationCode.Text = dt1.Rows(i).Item("ClassificationCode").ToString
                txtbookTitle.Text = dt1.Rows(i).Item("Title").ToString
                txtBookPublicationDate.Text = dt1.Rows(i).Item("PublicationDate").ToString
                Try
                    'drpbookUnit.SelectedValue = dt1.Rows(i).Item("DebitUnit").ToString
                Catch ex As Exception
                    ' drpbookUnit.SelectedValue = 175
                End Try
                txtbookQuantity.Text = dt1.Rows(i).Item("DebitQty").ToString
                txtBookPrice.Text = dt1.Rows(i).Item("bPrice").ToString
                txtBookISBN.Text = dt1.Rows(i).Item("ISBN").ToString
                txtbookAuthor.Text = dt1.Rows(i).Item("Author").ToString
                txtbookAcqDate.Text = Convert.ToDateTime(dt1.Rows(i).Item("dDate").ToString).ToString("MM/dd/yyyy")
                txtbookAcqCost.Text = dt1.Rows(i).Item("bPrice").ToString
                txtbookdepreciatedRate.Text = dt1.Rows(i).Item("DepreciationRate").ToString
                txtbookdepreciatedvalue.Text = dt1.Rows(i).Item("DepreciationValue").ToString
                txtbookMarketValue.Text = dt1.Rows(i).Item("MarketValue").ToString
                txtNoYears.Text = dt1.Rows(i).Item("NoYears").ToString
                txtbookUsefulLife.Text = dt1.Rows(i).Item("UsefulLife").ToString
                txtbookSalvageValue.Text = dt1.Rows(i).Item("SalvageValue").ToString
                drpbookWarehouse.Text = dt1.Rows(i).Item("warehouseid").ToString
                txtbookRoom.Text = dt1.Rows(i).Item("Room").ToString
                txtbookBay.Text = dt1.Rows(i).Item("Bay").ToString
                txtbookShelves.Text = dt1.Rows(i).Item("Shelves").ToString
                txtbookColumn.Text = dt1.Rows(i).Item("Column").ToString
                txtbookRack.Text = dt1.Rows(i).Item("Rack").ToString
                txtbookFloor.Text = dt1.Rows(i).Item("Floor").ToString
                txtbookBin.Text = dt1.Rows(i).Item("Bin").ToString
                txtRemarks.Text = dt1.Rows(i).Item("Remarks").ToString
                txtbookdesciption.Text = dt1.Rows(i).Item("Description").ToString
                txtbookAcqCost.Text = dt1.Rows(i).Item("Cost").ToString

                'drpbookUnit.SelectedValue = dt1.Rows(i).Item("Unit_ID").ToString

                hf_EquipInfoId.Value = dt1.Rows(i).Item("EquipInfoId").ToString
                hf_EquipmentId.Value = dt1.Rows(i).Item("EquipmentId").ToString
                hf_PropertyDetai_ID.Value = dt1.Rows(i).Item("PropertyDetai_ID").ToString
                hf_Property_ID.Value = dt1.Rows(i).Item("Property_ID").ToString
            End If

        Next

        btnSave.Enabled = True
    End Sub

    Protected Sub ClearTextBoxes()
        Dim ctxtBoxes As TextBox() = {txtbookAuthor, txtBookISBN, txtBookPrice, txtbookQuantity, txtbookAcqDate, txtBookClassification, txtBookClassificationCode, txtbookTitle, txtBookPublicationDate, txtbookAcqCost, txtbookdepreciatedRate, txtbookdepreciatedvalue, txtbookMarketValue,
            txtNoYears, txtbookUsefulLife, txtbookSalvageValue, txtbookRoom, txtbookBay, txtbookShelves, txtbookColumn, txtbookRack, txtbookFloor, txtbookBin, txtRemarks, txtbookdesciption
        }

        For Each textboxes In ctxtBoxes
            textboxes.Text = String.Empty
        Next

    End Sub

    Protected Sub IsEnabledTextBoxes(isEnabled As Boolean)
        Dim ctxtBoxes As TextBox() = {txtbookAuthor, txtBookISBN, txtBookPrice, txtbookAcqDate, txtBookClassification, txtBookClassificationCode, txtbookTitle, txtBookPublicationDate, txtbookAcqCost, txtbookdepreciatedRate, txtbookdepreciatedvalue, txtbookMarketValue,
            txtNoYears, txtbookSalvageValue, txtbookRoom, txtbookBay, txtbookShelves, txtbookColumn, txtbookRack, txtbookFloor, txtbookBin
        }

        For Each textboxes In ctxtBoxes
            textboxes.Enabled = isEnabled
        Next
    End Sub

    Protected Sub grdLedger1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles grdLedger1.RowCreated

        If grdLedger1.HeaderRow IsNot Nothing AndAlso grdLedger1.Rows.Count > 0 Then
            If grdLedger1.Controls.Count > 0 AndAlso grdLedger1.Controls(0).Controls.Count > 0 Then
                ' Prevent duplicate custom header rows
                Dim headerAlreadyExists As Boolean = False
                For Each row As GridViewRow In grdLedger1.Controls(0).Controls
                    If row.RowType = DataControlRowType.Header AndAlso row.Cells(0).Text = "BOOK" Then
                        headerAlreadyExists = True
                        Exit For
                    End If
                Next

                If Not headerAlreadyExists Then

                    Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
                    Dim cell As New TableHeaderCell()
                    cell.Text = "BOOK"
                    cell.ColumnSpan = 4
                    row.Controls.Add(cell)

                    cell = New TableHeaderCell()
                    cell.ColumnSpan = 1
                    cell.Text = "DEBIT"
                    row.Controls.Add(cell)

                    cell = New TableHeaderCell()
                    cell.ColumnSpan = 1
                    cell.Text = "CREDIT"
                    row.Controls.Add(cell)


                    cell = New TableHeaderCell()
                    cell.ColumnSpan = 1
                    cell.Text = "BALANCE"
                    row.Controls.Add(cell)

                    row.BackColor = ColorTranslator.FromHtml("WHITE")
                    row.ForeColor = ColorTranslator.FromHtml("BLACK")
                    grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)
                End If
            End If
        End If
    End Sub

    Public Sub loadUsefulLife()

        Dim usefulLife As String =
            objDerived.GetValue(
                "SELECT TOP 1 ISNULL(useful_life, 0) " &
                "FROM AMS.item_particular " &
                "WHERE item_particular_id = (" &
                "    SELECT TOP 1 item_particular_id " &
                "    FROM dbo.m_item " &
                "    WHERE Item_ID = '" & Session("Item_ID") & "'" &
                ")",
                CommandType.Text
            )

        If String.IsNullOrWhiteSpace(usefulLife) Then
            txtbookUsefulLife.Text = "0"
        Else
            txtbookUsefulLife.Text = usefulLife
        End If


    End Sub

End Class
