Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing

Partial Class Inventory_Encoding_Machineries
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Dim item As New m_item
    Private Prop_Ledger As New t_PropertyLedger
    Dim Prop_Hdr As New t_property_hdr
    Dim Prop_Dtl As New t_property_dtl
    Dim objMachineInfo As New ConsolidatedPropertySaving.TbMachinery_Information
    Dim objMachineDtl As New ConsolidatedPropertySaving.TbMachinery_Dtl
    Dim idholder As String = ""

    Private Sub Inventory_Encoding_Machineries_Load(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles Me.Load

        objx.GetAccessRight(Me.Session("@UserName"), Page)

        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then

            Session("Item_ID") = 0

            BindClassification_Machinery()

            ddClass.AutoPostBack = True
            ddGA.AutoPostBack = True
            drpSubClassification.AutoPostBack = True
            txtMachineryName.AutoPostBack = True

            BindGAAccounts_Machinery()

            drpSubClassification.Items.Clear()
            drpSubClassification.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )
            drpSubClassification.Enabled = True

            ClearMachineryItems()

            LoadBuildings()

            loadEquipmentLedger()

        End If
    End Sub


    Protected Sub grdLedger1_RowDataBound(
    sender As Object,
    e As GridViewRowEventArgs
)

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim cbInspection As CheckBox =
            TryCast(e.Row.FindControl("cbInspection"), CheckBox)

            Dim TransType As String = ""

            If e.Row.DataItem IsNot Nothing Then
                TransType = Convert.ToString(
                DataBinder.Eval(e.Row.DataItem, "Trans_Type")
            ).Trim()
            End If

            If cbInspection IsNot Nothing Then
                If TransType = "Starting Inventory" OrElse
               TransType = "Manual Entry" Then

                    cbInspection.Enabled = True
                Else
                    cbInspection.Checked = False
                    cbInspection.Enabled = False
                End If
            End If

            Dim zeroToBlank =
            Sub(cellIdx As Integer)

                If cellIdx >= e.Row.Cells.Count Then
                    Exit Sub
                End If

                Dim raw As String =
                    HttpUtility.HtmlDecode(
                        e.Row.Cells(cellIdx).Text
                    ).Trim()

                Dim val As Decimal

                If Decimal.TryParse(raw, val) AndAlso val = 0D Then
                    e.Row.Cells(cellIdx).Text = " "
                End If

            End Sub

            zeroToBlank(9)
            zeroToBlank(10)
            zeroToBlank(11)

            'CreditQty is cell 12.
            'Do not convert zero CreditQty into blank.
            'zeroToBlank(12)

        End If

    End Sub
    Protected Sub grdLedger1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtAccount As New DataTable
        If idholder = "" Then

            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & Session("Item_ID") & "'  ", CommandType.Text)
            AddTrace("drpSubClassification: " & drpSubClassification.SelectedValue)
            AddTrace("ddGA: " & ddGA.SelectedValue)
            AddTrace("txtMachineryName: " & txtMachineryName.SelectedValue)
            AddTrace("Item_ID: " & Session("Item_ID"))


        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & Session("Item_ID") & "'  ", CommandType.Text)
            AddTrace("drpSubClassification: " & drpSubClassification.SelectedValue)
            AddTrace("ddGA: " & ddGA.SelectedValue)
            AddTrace("txtMachineryName: " & txtMachineryName.SelectedValue)
            AddTrace("Item_ID: " & Session("Item_ID"))

        End If
        grdLedger1.PageIndex = e.NewPageIndex
        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
    End Sub


    ' === MACHINERY: Bind classification (hidden ddClass) ===
    Private Sub BindClassification_Machinery()
        Dim db As New BaseClasses.Items

        Dim sql As String =
        "SELECT " &
        "    ClassificationId, " &
        "    ClassificationName " &
        "FROM dbo.tbl_Classification " &
        "WHERE isenable = 1 " &
        "AND ClassificationName LIKE '%Machinery%' " &
        "ORDER BY SeqNo"

        Dim dt As DataTable = db.GetDataTable(
        sql,
        CommandType.Text
    )

        ddClass.DataSource = dt
        ddClass.DataTextField = "ClassificationName"
        ddClass.DataValueField = "ClassificationId"
        ddClass.DataBind()

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ddClass.SelectedIndex = 0
            Session("ClassificationID") = ddClass.SelectedValue
        Else
            Session("ClassificationID") = "0"
        End If

        AddTrace(
        "ClassificationID: " &
        Convert.ToString(Session("ClassificationID"))
    )
    End Sub


    ' === MACHINERY: Bind SubClassifications (drpSubClassification) ===
    Private Sub BindSubClassifications_Machinery()
        drpSubClassification.Items.Clear()

        If ddGA.SelectedValue Is Nothing OrElse
       ddGA.SelectedValue = "" OrElse
       ddGA.SelectedValue = "0" Then

            drpSubClassification.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

            drpSubClassification.Enabled = True
            Exit Sub
        End If

        Dim classificationID As Integer = 0
        Dim gaID As Integer = 0

        Integer.TryParse(
        Convert.ToString(Session("ClassificationID")),
        classificationID
    )

        Integer.TryParse(
        ddGA.SelectedValue,
        gaID
    )

        If classificationID = 0 OrElse gaID = 0 Then

            drpSubClassification.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

            drpSubClassification.Enabled = True
            Exit Sub
        End If

        Dim sql As String =
        "SELECT DISTINCT " &
        "    SubClassificationID, " &
        "    SubClassificationName " &
        "FROM dbo.tbl_SubClassification " &
        "WHERE ClassificationID = " & classificationID & " " &
        "AND GA_ID = " & gaID & " " &
        "ORDER BY SubClassificationName"

        AddTrace(sql)

        Dim dt As DataTable = objDerived.GetDataTable(
        sql,
        CommandType.Text
    )

        If dt IsNot Nothing Then

            Dim dr As DataRow = dt.NewRow()
            dr("SubClassificationID") = 0
            dr("SubClassificationName") = "Select"
            dt.Rows.InsertAt(dr, 0)

            drpSubClassification.DataSource = dt
            drpSubClassification.DataTextField =
            "SubClassificationName"
            drpSubClassification.DataValueField =
            "SubClassificationID"
            drpSubClassification.DataBind()

        Else

            drpSubClassification.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

        End If

        drpSubClassification.Enabled = True
    End Sub


    Private Sub ClearMachineryItems()
        txtMachineryName.Items.Clear()

        txtMachineryName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        txtMachineryName.Enabled = True
        Session("Item_ID") = 0
    End Sub

    ' === MACHINERY: Bind GA (ddGA) based on selected SubClassification ===
    Private Sub BindGAAccounts_Machinery()
        ddGA.Items.Clear()

        Dim classificationID As Integer = 0

        If Session("ClassificationID") IsNot Nothing Then
            Integer.TryParse(
            Convert.ToString(Session("ClassificationID")),
            classificationID
        )
        End If

        If classificationID = 0 AndAlso
       ddClass IsNot Nothing AndAlso
       Not String.IsNullOrWhiteSpace(ddClass.SelectedValue) Then

            Integer.TryParse(
            ddClass.SelectedValue,
            classificationID
        )

            Session("ClassificationID") = classificationID
        End If

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
        "ORDER BY GA_Title"

        AddTrace(sql)

        Dim dt As DataTable = objDerived.GetDataTable(
        sql,
        CommandType.Text
    )

        If dt IsNot Nothing Then

            Dim dr As DataRow = dt.NewRow()
            dr("GA_ID") = 0
            dr("GA_Title") = "Select"
            dt.Rows.InsertAt(dr, 0)

            ddGA.DataSource = dt
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



    ' When the (hidden) classification changes, rebuild everything downstream
    Protected Sub ddClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles ddClass.SelectedIndexChanged

        Session("ClassificationID") = ddClass.SelectedValue
        Session("Item_ID") = 0

        BindGAAccounts_Machinery()

        drpSubClassification.Items.Clear()
        drpSubClassification.Items.Insert(
        0,
        New ListItem("No Subclass", "0")
    )
        drpSubClassification.Enabled = True

        ClearMachineryItems()
        loadEquipmentLedger()

    End Sub

    ' When subclass changes, rebuild GA and reload ledger
    Protected Sub drpSubClassification_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles drpSubClassification.SelectedIndexChanged

        Session("Item_ID") = 0

        BindMachineryItems()
        loadEquipmentLedger()

        AddTrace(
        "drpSubClassification: " &
        drpSubClassification.SelectedValue
    )
    End Sub

    ' If GA matters to your ledger filters, reload here too
    Protected Sub ddGA_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles ddGA.SelectedIndexChanged

        Session("Item_ID") = 0

        BindSubClassifications_Machinery()
        ClearMachineryItems()
        BindMachineryItems()
        loadEquipmentLedger()

        AddTrace(
        "ddGA: " &
        ddGA.SelectedValue
    )
    End Sub



    Public Sub loadEquipmentLedger()
        btnEquipmentLedger.CssClass = "Clicked"
        btnequipmentrepairs.CssClass = "Initial"
        btnequipmentattachdoc.CssClass = "Initial"
        Me.mvledger.SetActiveView(Me.vwledger)

        Dim dtAccount As New DataTable
        Dim itemid As String
        'If 

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "' order by dDate", CommandType.Text)

        dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & Session("Item_ID") & "'  ", CommandType.Text)
        AddTrace("drpSubClassification: " & drpSubClassification.SelectedValue)
        AddTrace("ddGA: " & ddGA.SelectedValue)
        AddTrace("txtMachineryName: " & txtMachineryName.SelectedValue)

        ''dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        'If dtAccount.Rows.Count < 10 Then
        '    dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        'End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
    End Sub


    Protected Sub txtMachineryName_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles txtMachineryName.SelectedIndexChanged

        If txtMachineryName.SelectedValue Is Nothing OrElse
       txtMachineryName.SelectedValue = "" OrElse
       txtMachineryName.SelectedValue = "0" Then

            Session("Item_ID") = 0

            If drpMachineryUnit.Items.Count > 0 Then
                drpMachineryUnit.SelectedIndex = 0
            End If

            loadEquipmentLedger()
            Exit Sub
        End If

        Session("Item_ID") = txtMachineryName.SelectedValue

        loadUnit()
        loadUsefulLife()
        loadEquipmentLedger()

    End Sub

    Private Function ValidateMachinerySelections() As Boolean

        If ddGA.SelectedValue Is Nothing OrElse
       ddGA.SelectedValue = "" OrElse
       ddGA.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Please select General Account."
        )

            Return False
        End If



        If txtMachineryName.SelectedValue Is Nothing OrElse
       txtMachineryName.SelectedValue = "" OrElse
       txtMachineryName.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Please select Name."
        )

            Return False
        End If

        Return True
    End Function

    ' === MACHINERY: Bind Items (txtMachineryName) from AMS.sp_ItemName_Encoding ===
    Public Sub BindMachineryItems()

        If ddGA.SelectedValue Is Nothing OrElse
       ddGA.SelectedValue = "" OrElse
       ddGA.SelectedValue = "0" Then

            ClearMachineryItems()
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
        Convert.ToString(drpSubClassification.SelectedValue),
        subClassificationID
    )

        If classificationID = 0 OrElse
       gaID = 0 Then

            ClearMachineryItems()
            Exit Sub

        End If

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
        "INNER JOIN dbo.m_item_detail AS id " &
        "    ON id.Item_ID = i.Item_ID " &
        "LEFT JOIN dbo.tbl_SubClassification AS sc " &
        "    ON sc.SubClassificationID = i.SubClassificationID " &
        "    AND sc.ClassificationID = " & classificationID & " " &
        "    AND sc.GA_ID = " & gaID & " " &
        "    AND sc.SubClassificationID = " & subClassificationID & " " &
        "LEFT JOIN dbo.tblclassmatrix AS cm " &
        "    ON cm.Item_ID = i.Item_ID " &
        "    AND cm.ClassificationID = " & classificationID & " " &
        "    AND cm.GA_ID = " & gaID & " " &
        "    AND cm.SubClassificationID = " & subClassificationID & " " &
        "WHERE sc.SubClassificationID IS NOT NULL " &
        "    OR cm.Item_ID IS NOT NULL " &
        "ORDER BY i.ItemCompleteDesc"

        AddTrace(sql)

        Dim dt As DataTable =
        objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        txtMachineryName.Items.Clear()

        If dt IsNot Nothing Then

            Dim dr As DataRow = dt.NewRow()

            dr("Item_ID") = 0
            dr("ItemDescription") = "Select"

            dt.Rows.InsertAt(dr, 0)

            txtMachineryName.DataSource = dt
            txtMachineryName.DataTextField = "ItemDescription"
            txtMachineryName.DataValueField = "Item_ID"
            txtMachineryName.DataBind()

        Else

            txtMachineryName.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

        End If

        txtMachineryName.Enabled = True
        Session("Item_ID") = 0

    End Sub


    Public Function createdatatableledger(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        dt.Columns.Add("dDate", GetType(Date))
        dt.Columns.Add("Trans_Type", GetType(String))
        dt.Columns.Add("ref", GetType(String))
        dt.Columns.Add("AccountablePerson", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("position", GetType(String))
        dt.Columns.Add("acceptedby", GetType(String))
        dt.Columns.Add("inspectedby", GetType(String))
        dt.Columns.Add("DebitQty", GetType(Integer))
        dt.Columns.Add("DebitUnit", GetType(String))
        dt.Columns.Add("DebitCost", GetType(Decimal))
        dt.Columns.Add("CreditQty", GetType(Integer))
        dt.Columns.Add("CreditUnit", GetType(String))
        dt.Columns.Add("CreditCost", GetType(Decimal))
        dt.Columns.Add("BalQty", GetType(Integer))
        dt.Columns.Add("BalanceUnit", GetType(String))
        dt.Columns.Add("BalCost", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            'dr("Property_Dtl_ID") = DBNull.Value
            dr("dDate") = DBNull.Value
            dr("Trans_Type") = DBNull.Value
            dr("ref") = DBNull.Value
            dr("AccountablePerson") = DBNull.Value
            dr("Department") = DBNull.Value
            dr("position") = DBNull.Value
            dr("acceptedby") = DBNull.Value
            dr("inspectedby") = DBNull.Value
            dr("DebitQty") = DBNull.Value
            dr("DebitUnit") = DBNull.Value
            dr("DebitCost") = DBNull.Value
            dr("CreditQty") = DBNull.Value
            dr("CreditUnit") = DBNull.Value
            dr("CreditCost") = DBNull.Value
            dr("BalQty") = DBNull.Value
            dr("BalanceUnit") = DBNull.Value
            dr("BalCost") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function


    Protected Sub btnEquipmentLedger_Click(sender As Object, e As EventArgs)
        'loadEquipmentLedger()
    End Sub
    Protected Sub btnequipmentrepairs_Click(sender As Object, e As EventArgs)
        ' loadEquipmentRepair()
    End Sub
    Protected Sub btnequipmentattachdoc_Click(sender As Object, e As EventArgs)
        ' loadEquipmentAttchDocu()
        ' loadAttchDocuChangeIndex()
    End Sub
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        If grdLedger1.HeaderRow Is Nothing Then Exit Sub

        ' Only add the custom header row once, not on every postback
        If grdLedger1.Rows.Count > 0 AndAlso grdLedger1.HeaderRow.Parent.Controls(0).Controls.OfType(Of GridViewRow)().
        Any(Function(r) r.RowType = DataControlRowType.Header AndAlso r.Cells.Count > 0 AndAlso r.Cells(0).Text = "EQUIPMENT") Then
            Exit Sub
        End If

        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)

        Dim cell As New TableHeaderCell() With {.Text = "EQUIPMENT", .ColumnSpan = 4}
        row.Cells.Add(cell)

        cell = New TableHeaderCell() With {.Text = "DEBIT", .ColumnSpan = 2}
        row.Cells.Add(cell)

        cell = New TableHeaderCell() With {.Text = "CREDIT", .ColumnSpan = 2}
        row.Cells.Add(cell)

        cell = New TableHeaderCell() With {.Text = "BALANCE", .ColumnSpan = 2}
        row.Cells.Add(cell)

        row.BackColor = Color.White
        row.ForeColor = Color.Black

        ' Insert only if not already there
        grdLedger1.Controls(0).Controls.AddAt(0, row)
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub


    Protected Sub cbInspection_CheckedChanged(sender As Object, e As EventArgs)
        btnSave.Text = "SAVE"
        btnSave.Enabled = True
        txtMachineryQuantity.Enabled = True

        'drpUnit.SelectedIndex = 0

        IsEnabledTextBox(True)
        ClearTextBoxes()

        ViewState("CheckboxEvent") = True


        AddTrace("drpSubClassification: " & drpSubClassification.SelectedValue)
        Dim dt1 As DataTable = objDerived.GetDataTable("[AMS].[sp_ViewEncoding_Machinery] '" & drpSubClassification.SelectedValue & "'", CommandType.Text)

        ' Get the checkbox and its row
        Dim cb1 As CheckBox = TryCast(sender, CheckBox)
        If cb1 Is Nothing Then Exit Sub

        Dim row As GridViewRow = TryCast(cb1.NamingContainer, GridViewRow)
        If row Is Nothing Then Exit Sub

        ' Get the Ledger_ID of this row (GridView must have DataKeyNames="Ledger_ID")
        Dim ledgerId As Long = 0
        If grdLedger1.DataKeys IsNot Nothing AndAlso row.RowIndex >= 0 AndAlso row.RowIndex < grdLedger1.DataKeys.Count Then
            Long.TryParse(grdLedger1.DataKeys(row.RowIndex).Value.ToString(), ledgerId)
        End If

        If ledgerId = 0 Then
            AddTrace("No Ledger_ID resolved from DataKeys.")
            Exit Sub
        End If

        ' Optional: uncheck other rows’ checkboxes to keep only one active selection
        For Each r As GridViewRow In grdLedger1.Rows
            If r.RowType = DataControlRowType.DataRow AndAlso Not r.Equals(row) Then
                Dim otherCb As CheckBox = TryCast(r.FindControl("cbInspection"), CheckBox)
                If otherCb IsNot Nothing Then otherCb.Checked = False
            End If
        Next

        ' Fetch the data for THIS ledger row.
        ' If you have a specific SP by ledger, prefer it:
        '   Dim dt1 As DataTable = objDerived.GetDataTable("EXEC AMS.sp_ViewEncoding_Machinery_ByLedger " & ledgerId, CommandType.Text)
        ' Otherwise reuse your existing SP and pick the matching row by Ledger_ID:
        Dim dtAll As DataTable = objDerived.GetDataTable("[AMS].[sp_ViewEncoding_Machinery] '" & drpSubClassification.SelectedValue & "'", CommandType.Text)
        Dim rows() As DataRow = If(dtAll Is Nothing, Nothing, dtAll.Select("Ledger_ID = " & ledgerId))
        If rows Is Nothing OrElse rows.Length = 0 Then
            AddTrace("No matching row in sp_ViewEncoding_Machinery for Ledger_ID=" & ledgerId)
            Exit Sub
        End If
        Dim r0 As DataRow = rows(0)

        ' We’re in edit mode now
        btnSave.Text = "EDIT"
        btnSave.Enabled = True
        txtMachineryQuantity.Enabled = False
        IsEnabledTextBox(False)

        ' === Map database values to your front-end textboxes ===
        Dim itemText As String = r0("MachineName").ToString()
        Dim li As ListItem = txtMachineryName.Items.FindByText(itemText)
        If li IsNot Nothing Then
            txtMachineryName.ClearSelection()
            li.Selected = True
        End If


        txtMachineryDescription.Text = r0("MachineDesc").ToString()
        txtMachineryPowerInput.Text = r0("PowerInput").ToString()
        txtMachineryModel.Text = r0("BrandModel").ToString()
        txtRemarks.Text = r0("Remarks").ToString()
        txtSpecification.Text = r0("Specification").ToString()

        txtMachineryBrand.Text = r0("Brand").ToString()

        txtMachineryDimension.Text = r0("CarDimensions").ToString()
        txtMachineryAreaCapacity.Text = r0("AreaCapacity").ToString()
        txtMachineryWarranty.Text = r0("Warranty").ToString()

        txtContractor.Text = r0("Condition").ToString()
        txtContactPerson.Text = r0("InspectedBy").ToString()
        txtCellphoneNo.Text = ""   ' no matching column

        txtEAcqDate.Text = r0("dDate").ToString()
        txtEMarketValue.Text = r0("PropertyDtlMarketValue").ToString()
        txtEAcqCost.Text = r0("Cost").ToString()

        txtNoYears.Text = r0("NoYears").ToString()
        lblequipmentdepreciatedRate.Text = r0("DepreciationRate").ToString()
        txtUsefulLife.Text = r0("Useful Life").ToString()
        txtequipmentdepreciatedvalue.Text = r0("DepreciationValue").ToString()
        txtSalvageValue.Text = r0("SalvageValue").ToString()
        txtDepreciationValue.Text = r0("DepreciationValue").ToString()
        txtMachineryQuantity.Text = r0("Qty").ToString()

        ' DropDowns
        If Not IsDBNull(r0("BuildingId")) Then
            Dim b As String = r0("BuildingId").ToString()
            If drpInstalledAtBuilding.Items.FindByValue(b) IsNot Nothing Then
                drpInstalledAtBuilding.SelectedValue = b
            End If
        End If
        If drpMachineryUnit.Items.FindByValue(r0("Unit_ID").ToString()) IsNot Nothing Then
            'drpMachineryUnit.SelectedValue = r0("Unit_ID").ToString()
        End If

        ' Set edit-mode and cache ledger id (used later by the modal)
        Session("Ledger_ID") = ledgerId.ToString()
        AddTrace("Ledger_ID: " & Session("Ledger_ID"))

        Session("Property_ID") = r0("Property_ID").ToString()
        AddTrace("Property_ID: " & Session("Property_ID"))

        ViewState("IsEditMode") = True

        ' Prefill the property-info rows and cache them
        PopulatePropertyInfoFromLedger(ledgerId)
        AddTrace("grdPropertyInfo: " & grdPropertyInfo.DataKeys.Count)

        If cb1 IsNot Nothing AndAlso cb1.Checked = False Then
            ClearTextBoxes()
            IsEnabledTextBox(True)
            btnSave.Text = "SAVE"
            btnSave.Enabled = True
        End If

    End Sub



    Protected Sub IsEnabledTextBox(IsEnabled As Boolean)

        txtMachineryName.Enabled = IsEnabled
        Dim textBoxes() As TextBox = {
        txtMachineryDescription,
        txtMachineryPowerInput,
        txtMachineryModel,
        txtRemarks,
        txtSpecification,
        txtMachineryDimension,
        txtMachineryAreaCapacity,
        txtMachineryWarranty,
        txtContractor,
        txtContactPerson,
        txtCellphoneNo,
        txtEAcqDate,
        txtEMarketValue,
        txtEAcqCost,
        txtNoYears,
        lblequipmentdepreciatedRate,
        txtequipmentdepreciatedvalue,
        txtSalvageValue,
        txtDepreciationValue,
        txtMachineryBrand
    }

        For Each txtBox In textBoxes
            txtBox.Enabled = IsEnabled
        Next

        ' Dropdowns
        drpMachineryUnit.Enabled = IsEnabled
        drpInstalledAtBuilding.Enabled = IsEnabled
    End Sub

    Protected Sub ClearTextBoxes()

        'txtMachineryName.SelectedIndex = 0
        Dim textBoxes() As TextBox = {
        txtMachineryDescription,
        txtMachineryPowerInput,
        txtMachineryModel,
        txtRemarks,
        txtSpecification,
        txtMachineryQuantity,
        txtMachineryDimension,
        txtMachineryAreaCapacity,
        txtMachineryWarranty,
        txtContractor,
        txtContactPerson,
        txtCellphoneNo,
        txtEAcqDate,
        txtEMarketValue,
        txtEAcqCost,
        txtNoYears,
        lblequipmentdepreciatedRate,
        txtUsefulLife,
        txtequipmentdepreciatedvalue,
        txtSalvageValue,
        txtDepreciationValue,
        txtMachineryBrand,
        txtRemarks,
        txtSpecification
    }

        For Each txtBox In textBoxes
            txtBox.Text = String.Empty
        Next

        ' Reset dropdowns
        'drpMachineryUnit.SelectedIndex = 0
        drpInstalledAtBuilding.SelectedIndex = 0
    End Sub


    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT Unit_ID, Description FROM ams.m_Unit AS a ORDER BY CASE WHEN Description = '-' THEN 0 ELSE 1 END, Description;", CommandType.Text)
        drpMachineryUnit.DataSource = dt
        drpMachineryUnit.DataTextField = ("Description")
        drpMachineryUnit.DataValueField = ("Unit_ID")
        drpMachineryUnit.DataBind()

        Dim Unit_ID As Integer = objDerived.GetValue("SELECT Unit_ID FROM DBO.m_item WHERE Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        drpMachineryUnit.SelectedValue = Unit_ID

    End Sub


    Protected Sub drpMachineryUnit_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Public Sub LoadBuildings()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        drpInstalledAtBuilding.DataSource = dt
        drpInstalledAtBuilding.DataTextField = ("Name")
        drpInstalledAtBuilding.DataValueField = ("BuildingId")
        drpInstalledAtBuilding.DataBind()
        drpInstalledAtBuilding.Items.Insert(0, New ListItem("N/A"))
    End Sub

    'TODO See if it still duplicates, as ms Ally saw it duplicating.
    Protected Sub btnSave_Click(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If btnSave.Text = "SAVE" Then

            If Not ValidateMachinerySelections() Then
                Exit Sub
            End If

            Save()

        ElseIf btnSave.Text = "EDIT" Then

            LoadApprovingOfficers()
            ModalPopupExtender_Approval.Show()

        Else

            If Not ValidateMachinerySelections() Then
                Exit Sub
            End If

            Dim quantity As Integer = 0

            If Not Integer.TryParse(
            txtMachineryQuantity.Text,
            quantity
        ) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(
                Me.UpdatePanel1,
                "Please enter a valid Quantity."
            )

                Exit Sub
            End If

            Update()

            Dim cb1 As CheckBox

            For i As Integer = 0 To grdLedger1.Rows.Count - 1

                cb1 = CType(
                Me.grdLedger1.Rows(i).Cells(0).
                    FindControl("cbInspection"),
                CheckBox
            )

                If cb1 IsNot Nothing AndAlso
               cb1.Checked AndAlso
               cb1.Visible Then

                    cb1.Checked = False
                End If

            Next

            ClearTextBoxes()
            IsEnabledTextBox(True)

            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Property Information is Updated Successfully."
        )

            btnSave.Text = "SAVE"
            loadEquipmentLedger()

        End If

        btnSave.Enabled = True
    End Sub

    Public Sub Update()

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        ' --- Gather some row-sourced values we’ll also use for the header proc ---
        Dim firstRowSerial As String = Nothing
        Dim firstRowInstalledAtText As String = Nothing
        Dim firstRowLocation As String = Nothing
        Dim firstRowBuildingId As String = Nothing

        If grdPropertyInfo.Rows IsNot Nothing AndAlso grdPropertyInfo.Rows.Count > 0 Then
            Dim r As GridViewRow = grdPropertyInfo.Rows(0)
            Dim tbSerial As TextBox = TryCast(r.FindControl("txtSerialNumber"), TextBox)
            Dim ddlInstalled As DropDownList = TryCast(r.FindControl("drpInstalledAtMac"), DropDownList)
            Dim tbLoc As TextBox = TryCast(r.FindControl("txtPIFloorLocation"), TextBox)

            If tbSerial IsNot Nothing Then firstRowSerial = tbSerial.Text.Trim()
            If ddlInstalled IsNot Nothing Then
                firstRowInstalledAtText = If(ddlInstalled.SelectedItem IsNot Nothing,
                                         ddlInstalled.SelectedItem.Text,
                                         ddlInstalled.SelectedValue)
                firstRowBuildingId = ddlInstalled.SelectedValue
            End If
            'If tbLoc Is Not Nothing Then firstRowLocation = tbLoc.Text.Trim()
        End If



        ' --- MAIN UPDATE via AMS.sp_Edit_Machinery ---
        ' Convert Session values and dropdown values to Long (bigint)
        Dim ledgerId As Long = 0
        Long.TryParse(Session("Ledger_ID").ToString(), ledgerId)

        Dim propertyId As Long = 0
        Long.TryParse(Session("Property_ID").ToString(), propertyId)

        Dim buildingId As Long = 0
        If Not String.IsNullOrEmpty(firstRowBuildingId) Then
            Long.TryParse(firstRowBuildingId, buildingId)
        Else
            Long.TryParse(drpInstalledAtBuilding.SelectedValue, buildingId)
        End If

        Dim unitId As Long = 0
        Long.TryParse(drpMachineryUnit.SelectedValue, unitId)


        With objDerived.cmd.Parameters
            .Clear()

            ' Keys / IDs
            .AddWithValue("@Ledger_ID", ledgerId)
            .AddWithValue("@Property_ID", propertyId)
            .AddWithValue("@BuildingId", buildingId)

            ' Machinery information
            .AddWithValue("@MachineName", txtMachineryName.SelectedItem.Text)
            .AddWithValue("@MachineDesc", txtMachineryDescription.Text)
            .AddWithValue("@BrandModel", txtMachineryModel.Text)
            .AddWithValue("@Brand", txtMachineryBrand.Text)
            .AddWithValue("@PowerInput", txtMachineryPowerInput.Text)

            ' Use the first grid row’s Serial No so we don’t blank it out
            .AddWithValue("@SerialNo", If(firstRowSerial, String.Empty))

            ' Financials - Clean the numeric values
            .AddWithValue("@AcquisitionDate", txtEAcqDate.Text)
            '.AddWithValue("@MarketValue", GetNumericOrZero(txtEMarketValue.Text))
            .AddWithValue("@Cost", CleanNumericString(txtEAcqCost.Text))  ' Clean the cost value
            .AddWithValue("@NoofYears", CleanNumericString(txtNoYears.Text))
            .AddWithValue("@DepreciatedRate", lblequipmentdepreciatedRate.Text)
            .AddWithValue("@UsefulLife", CleanNumericString(txtUsefulLife.Text))

            ' Total depreciated value (your UI label: “Depreciated Value”)
            '.AddWithValue("@DepreciatedValue", GetNumericOrZero(txtequipmentdepreciatedvalue.Text))
            '.AddWithValue("@SalvageValue", GetNumericOrZero(txtSalvageValue.Text))

            ' Specs / misc
            .AddWithValue("@AreaCapacity", txtMachineryAreaCapacity.Text)
            .AddWithValue("@CarDimensions", txtMachineryDimension.Text)
            .AddWithValue("@Warranty", txtMachineryWarranty.Text)

            ' InstalledAt + Location (use first row so header doesn’t go blank)
            .AddWithValue("@InstalledAt", If(firstRowInstalledAtText, String.Empty))
            .AddWithValue("@Location", If(firstRowLocation, String.Empty))

            ' Maintenance
            .AddWithValue("@MaintenanceContractor", txtContractor.Text)
            .AddWithValue("@MaintenanceContactPerson", txtContactPerson.Text)
            .AddWithValue("@MaintenanceContactNo", txtCellphoneNo.Text)

            ' Long description goes to Specification in SP (you don’t have a separate “txtDescription” here)
            .AddWithValue("@Description", txtSpecification.Text)

            .AddWithValue("@Remarks", txtRemarks.Text)
            .AddWithValue("@Unit_ID", unitId)
        End With

        objDerived.Execute("AMS.sp_Edit_Machinery", CommandType.StoredProcedure)




        ' ---- PER-ROW updates for Property_Dtl (keep exactly like your reference, with your control IDs) ----
        For Each row As GridViewRow In grdPropertyInfo.Rows
            If row.RowType <> DataControlRowType.DataRow Then Continue For

            Dim propDtlId As Long = 0
            If grdPropertyInfo.DataKeys IsNot Nothing AndAlso grdPropertyInfo.DataKeys.Count > row.RowIndex Then
                Dim keyObj = grdPropertyInfo.DataKeys(row.RowIndex).Value
                If keyObj IsNot Nothing Then
                    Long.TryParse(keyObj.ToString(), propDtlId)
                End If
            End If



            If propDtlId > 0 Then
                Dim tbPropNo As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)
                Dim tbSerial As TextBox = TryCast(row.FindControl("txtSerialNumber"), TextBox)
                Dim ddlInstalled As DropDownList = TryCast(row.FindControl("drpInstalledAtMac"), DropDownList)
                Dim tbLoc As TextBox = TryCast(row.FindControl("txtPIFloorLocation"), TextBox)

                Dim propNo As String = If(tbPropNo IsNot Nothing, tbPropNo.Text.Trim(), "")
                Dim serial As String = If(tbSerial IsNot Nothing, tbSerial.Text.Trim(), "")
                Dim installedAt As String = ""
                If ddlInstalled IsNot Nothing Then
                    installedAt = If(ddlInstalled.SelectedItem IsNot Nothing,
                                 ddlInstalled.SelectedItem.Text,
                                 ddlInstalled.SelectedValue)
                End If
                Dim loc As String = If(tbLoc IsNot Nothing, tbLoc.Text.Trim(), "")

                AddTrace("PropertyDetai_ID: " & propDtlId)
                objDerived.cmd.Parameters.Clear()
                objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", propDtlId)
                objDerived.cmd.Parameters.AddWithValue("@PropertyNo", propNo)
                objDerived.cmd.Parameters.AddWithValue("@SerialNo", serial)
                objDerived.cmd.Parameters.AddWithValue("@InstalledAt", installedAt)
                objDerived.cmd.Parameters.AddWithValue("@Location", loc)

                objDerived.Execute("AMS.sp_Update_PropertyDtl_Row", CommandType.StoredProcedure)
            End If
        Next

        ' ---- Rebalance ledger (same as your reference) ----
        Dim ItemID As Long = CLng(objDerived.GetValue(
        "SELECT Item_ID FROM AMS.TbProperty_Ledger WHERE Ledger_ID = '" & Session("Ledger_ID") & "'",
        CommandType.Text))

        ' Get the unit for DebitUnit and BalanceUnit
        Dim Unit As String = objDerived.GetValue(
            "SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID " &
            "INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID WHERE AMS.Property.Item_ID ='" & ItemID & "'",
            CommandType.Text)

        ' Calculate the values for the ledger update
        Dim quantity As String = txtMachineryQuantity.Text
        Dim debitCost As Decimal = CDec(txtEAcqCost.Text.Replace(",", "")) * CDec(quantity)

        ' Update the TbProperty_Ledger
        objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] " &
                      "SET DebitQty = '" & quantity & "', " &
                      "DebitCost = '" & debitCost.ToString("F2") & "', " &
                      "DebitUnit = '" & Unit & "', " &
                      "BalanceQty = '" & quantity & "', " &
                      "BalanceCost = '" & debitCost.ToString("F2") & "', " &
                      "BalanceUnit = '" & Unit & "', " &
                      "dDate = '" & txtEAcqDate.Text & "' " &
                      "WHERE Ledger_ID = '" & ledgerId & "'", CommandType.Text)

        'objDerived.Execute("EXEC [AMS].[ReBalanceLedger] " & ItemID, CommandType.Text)

    End Sub


    Public Sub Save()

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


        If String.IsNullOrWhiteSpace(txtMachineryName.SelectedValue) OrElse txtMachineryName.SelectedValue = "0" Then
            missingFields.Add("Name")
        End If

        If String.IsNullOrWhiteSpace(txtMachineryDescription.Text) Then
            missingFields.Add("Description")
        End If
        If drpMachineryUnit.SelectedIndex = 0 Then
            missingFields.Add("Unit")
        End If
        If String.IsNullOrWhiteSpace(txtMachineryQuantity.Text) Then
            missingFields.Add("Quantity")
        End If
        If String.IsNullOrWhiteSpace(txtRemarks.Text) Then
            missingFields.Add("Remarks")
        End If
        If String.IsNullOrWhiteSpace(txtEAcqDate.Text) Then
            missingFields.Add("Acquisition Date")
        End If
        If String.IsNullOrWhiteSpace(txtEAcqCost.Text) Then
            missingFields.Add("Acquisition Cost")
        End If

        If missingFields.Count > 0 Then
            Dim message As String = "Please fill up the required field(s):" &
                            "\n - " & String.Join("\n - ", missingFields)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, message)
            Exit Sub
        Else

            'Dim AValue As Integer
            'AValue = objDerived.getvalue("select * from dbo.m_item where Item_Desc = '" & txtMachineryName.Text & "'", CommandType.Text)
            'If AValue > 0 Then
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Machine name is already exist!")
            'Else
            ' -- Item Creation
            Dim classId As Integer = 0
            Dim subClassId As Integer = 0
            Integer.TryParse(ddClass.SelectedValue, classId)
            Integer.TryParse(drpSubClassification.SelectedValue, subClassId)

            'With item
            '    .Item_Code = ""
            '    .Item_Desc = txtMachineryName.SelectedItem.Text
            '    .Unit_ID = drpMachineryUnit.SelectedItem.Value
            '    .ClassificationID = classId
            '    .SubClassificationId = subClassId
            'End With

            Dim itemid As Integer
            itemid = txtMachineryName.SelectedValue
            'itemid = item.save()
            'objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & txtEAcqCost.Text.Replace(",", "") & "',null", CommandType.Text)

            Dim classification As String = objDerived.GetValue("EXEC [dbo].[usp_GetClassificationIdByClassificationName] ", CommandType.Text)

            'objDerived.GetValue("select  a.ClassificationId From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%'", CommandType.Text)
            Dim category As Integer = objDerived.GetValue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & itemid, CommandType.Text)
            Dim gaid As Integer = ddGA.SelectedValue
            'objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%' ", CommandType.Text)
            Dim matrix As String = objDerived.GetValue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & gaid & " and item_id = " & itemid & "", CommandType.Text)

            If matrix = "" Then
                objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id) values('" & classification & "','" & gaid & "','" & itemid & "','" & category & "','0')", CommandType.Text)
            End If



            With Prop_Hdr
                '.Property_ID = Property_ID
                .Property_Date = txtEAcqDate.Text
                .Issuance = 0
                .Remarks = txtRemarks.Text
                .Emp_ID = 0
                .F_ID = 1
                .AIRDtl_ID = 0
                .deptid = 0
                .isDonated = False
                .GA_ID = gaid
                'objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%' ", CommandType.Text)

                .DonationRemarks = ""
                .Qty = txtMachineryQuantity.Text
                .Balance = txtMachineryQuantity.Text
                .Cost = CType(txtEAcqCost.Text, Decimal)
                .Item_ID = itemid
                .Property_code = objDerived.GetValue("EXEC [AMS].[GetMachineryGACodes] ", CommandType.Text)
                'objDerived.GetValue("select ga_code  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%' ", CommandType.Text)
                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .Function_ID = 86
                .TD_ID = 1
                .Project_ID = 0
                .Program_id = 0
                .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & itemid & "' ", CommandType.Text)
            End With
            Dim PropHdr_ID As Integer = 0
            PropHdr_ID = Prop_Hdr.save()

            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Property SET ClassificationID = '" & ddClass.SelectedValue & "',SubClassificationID = '" & drpSubClassification.SelectedValue & "'  WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)


            For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                'msgbox(CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text)


                ' Get per-row controls we need
                Dim ddlInstalled As DropDownList = TryCast(grdPropertyInfo.Rows(i).FindControl("drpInstalledAtMac"), DropDownList)
                Dim tbLocation As TextBox = TryCast(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox)

                With Prop_Dtl
                    .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                    .Property_ID = PropHdr_ID
                    .Issued = False
                    .Repair = False
                    .Dispose = False
                    .DisposeDate = "1/1/1900"
                    .IsInspectionForDisposal = False
                    .InspectionDate = txtEAcqDate.Text
                    .F_ID = 1
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                    .Barcode = " "
                    .Amount = CType(txtEAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    .type = "Machinery"
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .Function_ID = 86
                    .AccountablePerson = ""

                    ' === NEW: align with reference (Intangible) ===
                    .MarketValue = CDec(If(String.IsNullOrWhiteSpace(txtEMarketValue.Text), "0", txtEMarketValue.Text.Replace(",", "")))
                    .InstalledAt = If(ddlInstalled IsNot Nothing AndAlso ddlInstalled.SelectedItem IsNot Nothing, ddlInstalled.SelectedItem.Text, String.Empty)
                    .Location = If(tbLocation IsNot Nothing, tbLocation.Text, String.Empty)
                End With

                Dim PropDtl_ID As Integer = Prop_Dtl.save()


                '==saving Machine
                With objMachineInfo
                    .MachineryInfoId = 0
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = PropDtl_ID
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                    .BrandModel = txtMachineryModel.Text
                    .MachineDesc = txtMachineryDescription.Text
                    .MachineLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text
                    .NoPassengers = ""
                    .ServiceFloors = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text
                    .MachineUnitNo = ""
                    .WorkingLoad = ""
                    .RatedSpeed = ""
                    .CarDimensions = txtMachineryDimension.Text
                    .DepreciationRate = lblequipmentdepreciatedRate.Text
                    .DepreciationValue = txtequipmentdepreciatedvalue.Text
                    .MechinePermitNo = ""
                    .DateOperate = "1/1/1900"
                    .DateIssued = "1/1/1900"
                    .DateInspected = txtEAcqDate.Text
                    .InspectedBy = ""
                    .Remarks = ""
                    .AreaCapacity = txtMachineryAreaCapacity.Text
                    .Warranty = txtMachineryWarranty.Text
                    .SalvageValue = txtSalvageValue.Text.Replace(",", "")
                    .Item_ID = itemid

                End With
                Dim mac_info_id As Integer
                mac_info_id = objMachineInfo.save()

                objDerived.GetRecords(
                    "UPDATE AMS.TbMachinery_Information SET " &
                    "Received_ID = 0, " &
                    "Received_Dtl_ID = 0, " &
                    "Brand = N'" & txtMachineryBrand.Text.Replace("'", "''") & "' " &
                    "WHERE MachineryInfoId = " & mac_info_id,
                    CommandType.Text
                )
                objDerived.GetRecords(
                    "UPDATE AMS.TbMachinery_Information SET " &
                    "Remarks = '" & txtRemarks.Text.Replace("'", "''") & "', " &
                    "Specification = CAST('" & txtSpecification.Text.Replace("'", "''") & "' AS VARCHAR(MAX)), " &
                    "Property_ID = " & PropHdr_ID & ", " &
                    "Unit_ID = " & drpMachineryUnit.SelectedValue & " " &
                    "WHERE MachineryInfoId = " & mac_info_id,
                    CommandType.Text
                )

                With objMachineDtl
                    .MachineryId = 0
                    .MachineryInfoId = mac_info_id
                    .Property_Dtl_ID = PropDtl_ID
                    '.MarketValue = txtEMarketValue.Text.Replace(",", "")
                    Dim marketValue1 As Decimal = 0D
                    If Not String.IsNullOrWhiteSpace(txtEMarketValue.Text) Then
                        Decimal.TryParse(txtEMarketValue.Text.Replace(",", ""), marketValue1)
                    End If

                    objMachineDtl.MarketValue = CDec(If(String.IsNullOrWhiteSpace(txtEMarketValue.Text), "0", txtEMarketValue.Text.Replace(",", "")))

                    .Condition = ""
                    .Location = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text
                    .Status = "Accepted"
                    .MachineName = txtMachineryName.SelectedItem.Text
                    .PowerInput = txtMachineryPowerInput.Text
                    Dim drp As DropDownList
                    drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtMac"), DropDownList)
                    'here
                    If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                        .buildingid = 0
                    Else
                        .buildingid = drp.SelectedValue
                    End If

                    .MaintenanceContractor = txtContractor.Text
                    .MaintenanceContactPerson = txtContactPerson.Text
                    .MaintenanceContactNo = txtCellphoneNo.Text
                    .NoYears = txtNoYears.Text
                    .UsefulLife = If(String.IsNullOrWhiteSpace(txtUsefulLife.Text), 0, CLng(txtUsefulLife.Text))


                End With
                objMachineDtl.save()

            Next
            '==== SAVE PROPERTY LEDGER
            With Prop_Ledger
                '.Ledger_ID = 0
                .PropertyNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                .SerialNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                .Trans_Type = "Manual Entry"
                .dDate = txtEAcqDate.Text
                .Ref = ""
                .AccountablePerson = ""
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = itemid
                .DebitQty = txtMachineryQuantity.Text
                .DebitCost = txtMachineryQuantity.Text * CType(txtEAcqCost.Text, Decimal) 'CType(txtEAcqCost.Text, Decimal)
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & itemid & "'", CommandType.Text)
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & itemid & "'", CommandType.Text)
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
                Convert.ToInt32(txtMachineryQuantity.Text)

                Dim EquipmentAcquisitionCost As Decimal =
                CType(txtEAcqCost.Text.Replace(",", ""), Decimal)

                Dim NewEquipmentCost As Decimal =
                EquipmentAcquisitionCost * NewEquipmentQty

                .BalanceQty = Eqty + NewEquipmentQty
                .BalanceCost = Eqbalance + NewEquipmentCost


            End With
            Prop_Ledger.save()



            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            idholder = itemid
            loadEquipmentLedger()
            'End If
            btnSave.Enabled = False
            btnCancel.Enabled = False


        End If
    End Sub


    Protected Sub BindGrid()
        If ViewState("PropertyInfoDT") IsNot Nothing Then
            grdPropertyInfo.DataSource = DirectCast(ViewState("PropertyInfoDT"), DataTable)
            grdPropertyInfo.DataBind()
        End If
    End Sub


    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType <> DataControlRowType.DataRow Then Exit Sub

        Dim drpInstalledAtMac As DropDownList = CType(e.Row.FindControl("drpInstalledAtMac"), DropDownList)
        Dim txtPIFloorLocation As TextBox = CType(e.Row.FindControl("txtPIFloorLocation"), TextBox)
        Dim txtPropertyNo As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
        Dim txtSerialNumber As TextBox = CType(e.Row.FindControl("txtSerialNumber"), TextBox)

        If drpInstalledAtMac IsNot Nothing Then
            ' Get buildings from database
            Dim query As String =
            "SELECT a.BuildingId, a.BuildingName + ' - ' + ISNULL(a.Address, '') AS Name " &
            "FROM ams.TbBuilding_Dtl AS a " &
            "INNER JOIN ams.Property_Dtl AS b ON a.Property_Dtl_ID = b.PropertyDetai_ID " &
            "ORDER BY a.BuildingName"

            drpInstalledAtMac.DataSource = objDerived.GetDataTable(query, CommandType.Text)
            drpInstalledAtMac.DataTextField = "Name"
            drpInstalledAtMac.DataValueField = "BuildingId"
            drpInstalledAtMac.DataBind()

            ' Add special non-database options
            drpInstalledAtMac.Items.Insert(0, New ListItem("Field", "0"))
            drpInstalledAtMac.Items.Insert(1, New ListItem("N/A", "-1"))

            ' Get the row snapshot from the cached DT
            Dim dt As DataTable = TryCast(ViewState("PropertyInfoDT"), DataTable)

            Dim installedAtText As String = ""
            Dim buildingId As String = ""
            Dim floorLoc As String = ""
            Dim propNo As String = ""
            Dim serialNo As String = ""

            If dt IsNot Nothing AndAlso e.Row.RowIndex < dt.Rows.Count Then
                ' Try to get InstalledAt text (for "Field"/"N/A")
                If dt.Columns.Contains("InstalledAt") Then
                    installedAtText = dt.Rows(e.Row.RowIndex)("InstalledAt").ToString()
                End If

                ' Try to get BuildingId
                If dt.Columns.Contains("BuildingId") Then
                    buildingId = dt.Rows(e.Row.RowIndex)("BuildingId").ToString()
                End If

                floorLoc = If(dt.Columns.Contains("FloorLocation"), dt.Rows(e.Row.RowIndex)("FloorLocation").ToString(), "")
                propNo = If(dt.Columns.Contains("PropertyNo"), dt.Rows(e.Row.RowIndex)("PropertyNo").ToString(), "")
                serialNo = If(dt.Columns.Contains("SerialNo"), dt.Rows(e.Row.RowIndex)("SerialNo").ToString(), "")
            End If

            ' Select the appropriate item
            drpInstalledAtMac.ClearSelection()

            If Not String.IsNullOrEmpty(installedAtText) Then
                ' First try to select by text (for "Field" and "N/A")
                Dim liByText As ListItem = drpInstalledAtMac.Items.FindByText(installedAtText)
                If liByText IsNot Nothing Then
                    liByText.Selected = True
                ElseIf Not String.IsNullOrEmpty(buildingId) AndAlso buildingId <> "0" AndAlso buildingId <> "-1" Then
                    ' Then try by BuildingId value
                    Dim liByVal As ListItem = drpInstalledAtMac.Items.FindByValue(buildingId)
                    If liByVal IsNot Nothing Then
                        liByVal.Selected = True
                    End If
                End If
            End If

            ' Set the rest
            txtPIFloorLocation.Text = floorLoc
            txtPropertyNo.Text = propNo
            txtSerialNumber.Text = serialNo
        End If
    End Sub


    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)
        ' === Edit Mode branch: reuse cached DT or repopulate from DB ===
        If ViewState("IsEditMode") IsNot Nothing AndAlso CBool(ViewState("IsEditMode")) Then
            Dim dtBind As DataTable = TryCast(ViewState("PropertyInfoDT"), DataTable)

            If dtBind IsNot Nothing Then
                grdPropertyInfo.DataSource = dtBind
                grdPropertyInfo.DataBind()
            Else
                ' Safety net: if cache empty, repopulate using Ledger_ID captured earlier
                Dim ledId As Long
                If Session("Ledger_ID") IsNot Nothing AndAlso Long.TryParse(Session("Ledger_ID").ToString(), ledId) Then
                    PopulatePropertyInfoFromLedger(ledId)
                End If
            End If

            TogglePropertyNoEnabled()
            ModalPopupExtender2.Show()
            Exit Sub
        End If

        If txtMachineryQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
            Exit Sub
        End If

        ' Validate quantity is a positive number
        Dim n As Integer
        If Not Integer.TryParse(txtMachineryQuantity.Text, n) OrElse n <= 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid Quantity.")
            Exit Sub
        End If

        ' Create empty rows for property information
        Dim dt As DataTable
        ' Check if there is already data in ViewState
        If ViewState("PropertyInfoDT") IsNot Nothing Then
            dt = DirectCast(ViewState("PropertyInfoDT"), DataTable)
        Else
            dt = New DataTable()
            dt.Columns.Add("PropertyDetai_ID", GetType(Long))
            dt.Columns.Add("PropertyNo", GetType(String))
            dt.Columns.Add("SerialNo", GetType(String))
            dt.Columns.Add("InstalledAt", GetType(String))
            dt.Columns.Add("FloorLocation", GetType(String))
            dt.Columns.Add("BuildingId", GetType(Integer))  ' ADD THIS COLUMN
        End If

        ' Adjust rows to match quantity
        While dt.Rows.Count < n
            dt.Rows.Add(0, "", "", "", "", 0)  ' Added 0 for BuildingId
        End While

        While dt.Rows.Count > n
            dt.Rows.RemoveAt(dt.Rows.Count - 1)
        End While

        ViewState("PropertyInfoDT") = dt
        BindGrid()

        ' ========================
        ' GENERATE PROPERTY NUMBERS USING STORED PROCEDURE
        ' ========================
        Try
            ' Get GA_ID from the dropdown
            Dim GA_ID As Integer
            If String.IsNullOrEmpty(ddGA.SelectedValue) OrElse ddGA.SelectedValue = "0" Then
                AddTrace("GA_ID is empty or null")
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                "Cannot generate property numbers: General Account information is missing. Please select a General Account first.")
                Exit Sub
            End If

            If Not Integer.TryParse(ddGA.SelectedValue, GA_ID) Then
                AddTrace("Invalid GA_ID format: " & ddGA.SelectedValue)
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
                        Dim txtSerialNumber As TextBox = CType(row1.FindControl("txtSerialNumber"), TextBox)
                        Dim txtPIFloorLocation As TextBox = CType(row1.FindControl("txtPIFloorLocation"), TextBox)
                        Dim drpInstalledAtMac As DropDownList = CType(row1.FindControl("drpInstalledAtMac"), DropDownList)

                        ' Clear other fields (check if controls exist)
                        If txtSerialNumber IsNot Nothing Then txtSerialNumber.Text = String.Empty
                        If txtPIFloorLocation IsNot Nothing Then txtPIFloorLocation.Text = String.Empty
                        If drpInstalledAtMac IsNot Nothing Then
                            drpInstalledAtMac.ClearSelection()
                            drpInstalledAtMac.SelectedValue = "N/A" ' Set default to N/A
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

        TogglePropertyNoEnabled()
        ModalPopupExtender2.Show()
    End Sub


    Private Sub PopulatePropertyInfoFromLedger(ledgerId As Long)
        Dim dt As DataTable = objDerived.GetDataTable("EXEC AMS.sp_GetPropertyDtl_ByLedger " & ledgerId, CommandType.Text)

        Dim dtBind As New DataTable()
        dtBind.Columns.Add("PropertyDetai_ID", GetType(Long))
        dtBind.Columns.Add("PropertyNo", GetType(String))
        dtBind.Columns.Add("SerialNo", GetType(String))
        dtBind.Columns.Add("FloorLocation", GetType(String))
        dtBind.Columns.Add("InstalledAt", GetType(String))
        dtBind.Columns.Add("BuildingId", GetType(Integer))  ' ADD THIS COLUMN

        If dt IsNot Nothing Then
            For Each r As DataRow In dt.Rows
                Dim id As Long = If(r.Table.Columns.Contains("PropertyDetai_ID") AndAlso Not IsDBNull(r("PropertyDetai_ID")), CLng(r("PropertyDetai_ID")), 0)
                Dim propNo As String = If(r.Table.Columns.Contains("PropertyNo"), r("PropertyNo").ToString(), "")
                Dim serial As String = If(r.Table.Columns.Contains("SerialNo"), r("SerialNo").ToString(), "")
                Dim installedAt As String = If(r.Table.Columns.Contains("InstalledAt"), r("InstalledAt").ToString(), "")
                Dim buildingId As Integer = If(r.Table.Columns.Contains("BuildingId") AndAlso Not IsDBNull(r("BuildingId")), CInt(r("BuildingId")), 0)
                Dim loc As String = If(r.Table.Columns.Contains("Location"), r("Location").ToString(), "")

                dtBind.Rows.Add(id, propNo, serial, loc, installedAt, buildingId)
            Next
        End If

        grdPropertyInfo.DataSource = dtBind
        grdPropertyInfo.DataBind()

        ' Cache for later re-use when reopening the modal
        ViewState("PropertyInfoDT") = dtBind
    End Sub


    Private Sub BindPropertyInfoGrid(rowCount As Integer)
        Dim dt As New DataTable()
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("InstalledAt", GetType(String))
        dt.Columns.Add("FloorLocation", GetType(String))
        dt.Columns.Add("BuildingId", GetType(Integer))  ' ADD THIS COLUMN

        For i As Integer = 1 To rowCount
            dt.Rows.Add(0, "", "", "", "", 0)  ' Added 0 for BuildingId
        Next

        ViewState("PropertyInfoDT") = dt
        grdPropertyInfo.DataSource = dt
        grdPropertyInfo.DataBind()
    End Sub


    Private Sub TogglePropertyNoEnabled()
        Dim disablePropNo As Boolean =
        btnSave.Text.Equals("EDIT", StringComparison.OrdinalIgnoreCase) OrElse
        btnSave.Text.Equals("UPDATE", StringComparison.OrdinalIgnoreCase)

        For Each row As GridViewRow In grdPropertyInfo.Rows
            Dim tb As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)
            If tb IsNot Nothing Then tb.Enabled = Not disablePropNo
        Next
    End Sub



    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        Dim dt As DataTable
        If ViewState("PropertyInfoDT") IsNot Nothing Then
            dt = DirectCast(ViewState("PropertyInfoDT"), DataTable)
        Else
            Exit Sub
        End If

        ' Loop through GridView rows and save the data
        For Each row As GridViewRow In grdPropertyInfo.Rows
            Dim txtPropertyNo As TextBox = CType(row.FindControl("txtPropertyNo"), TextBox)
            Dim txtSerialNumber As TextBox = CType(row.FindControl("txtSerialNumber"), TextBox)
            Dim drpInstalledAtMac As DropDownList = CType(row.FindControl("drpInstalledAtMac"), DropDownList)
            Dim txtPIFloorLocation As TextBox = CType(row.FindControl("txtPIFloorLocation"), TextBox)

            ' Update DataTable with new values
            If dt.Columns.Contains("PropertyNo") Then
                dt.Rows(row.RowIndex)("PropertyNo") = txtPropertyNo.Text
            End If

            If dt.Columns.Contains("SerialNo") Then
                dt.Rows(row.RowIndex)("SerialNo") = txtSerialNumber.Text
            End If

            ' Store both the text and the BuildingId
            If dt.Columns.Contains("InstalledAt") Then
                dt.Rows(row.RowIndex)("InstalledAt") = drpInstalledAtMac.SelectedItem.Text
            End If

            If dt.Columns.Contains("BuildingId") Then
                dt.Rows(row.RowIndex)("BuildingId") = drpInstalledAtMac.SelectedValue
            End If

            If dt.Columns.Contains("FloorLocation") Then
                dt.Rows(row.RowIndex)("FloorLocation") = txtPIFloorLocation.Text
            End If
        Next

        ' Save back to ViewState
        ViewState("PropertyInfoDT") = dt

        ' Close the modal
        ModalPopupExtender2.Hide()
    End Sub



    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)


        'OPTIMIZE CODE
        txtMachineryName.SelectedIndex = 0
        Dim textBoxes() As TextBox = {txtMachineryDescription, txtMachineryPowerInput, txtMachineryModel, txtMachineryQuantity, txtMachineryDimension, txtMachineryAreaCapacity, txtMachineryWarranty, txtContractor, txtContactPerson, txtCellphoneNo, txtEAcqDate, txtEMarketValue, txtEAcqCost, txtNoYears, txtUsefulLife, txtSalvageValue, txtRemarks, txtSpecification}

        For Each textBox As TextBox In textBoxes
            textBox.Text = ""
        Next

        LoadBuildings()

    End Sub

    Protected Sub drpInstalledAtBuilding_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpInstalledAtBuilding.SelectedIndexChanged

    End Sub

    Protected Sub grdPropertyInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPropertyInfo.SelectedIndexChanged

    End Sub
    Protected Sub drpInstalledAtMac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim drp As DropDownList = TryCast(sender, DropDownList)
        If drp Is Nothing Then Exit Sub

        Dim row As GridViewRow = TryCast(drp.NamingContainer, GridViewRow)
        If row Is Nothing Then Exit Sub

        Dim txtLocation As TextBox = CType(row.FindControl("txtPIFloorLocation"), TextBox)
        Dim selectedText As String = drp.SelectedItem.Text
        Dim selectedValue As String = drp.SelectedValue

        If selectedText = "N/A" OrElse selectedText = "Field" Then
            ' Enable manual location input
            If txtLocation IsNot Nothing Then
                txtLocation.Enabled = True
                txtLocation.Text = ""
            End If
        Else
            ' Disable manual input and auto-populate address from selected building
            If txtLocation IsNot Nothing Then
                txtLocation.Enabled = False

                ' Get building address - handle both numeric and string IDs
                Dim buildingId As Integer = 0
                If Integer.TryParse(selectedValue, buildingId) AndAlso buildingId > 0 Then
                    Dim dt As DataTable = objDerived.GetDataTable(
                    "SELECT CONCAT_WS(', ', " &
                    " COALESCE(Address, ''), " &
                    " COALESCE(Barangay, ''), " &
                    " COALESCE(Area1, '')) AS Address " &
                    " FROM AMS.TbBuilding_Dtl " &
                    " WHERE BuildingId = " & buildingId,
                    CommandType.Text)

                    If dt.Rows.Count > 0 Then
                        txtLocation.Text = dt.Rows(0)("Address").ToString()
                    Else
                        txtLocation.Text = ""
                    End If
                End If
            End If
        End If

        ' Keep modal open after postback
        ModalPopupExtender2.Show()
    End Sub



    Private Sub ShowAlert(message As String)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('" & message.Replace("'", "\'") & "');", True)
    End Sub


    Protected Sub txtPropertyNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim current As TextBox = TryCast(sender, TextBox)
        If current Is Nothing Then
            ModalPopupExtender2.Show()
            Exit Sub
        End If

        Dim currentPropRaw As String = (current.Text & "").Trim()
        If currentPropRaw = "" Then
            ModalPopupExtender2.Show()
            Exit Sub
        End If

        ' 1) In-grid duplicate check (compare only against other rows, case-insensitive)
        For Each row As GridViewRow In grdPropertyInfo.Rows
            If row.RowType <> DataControlRowType.DataRow Then Continue For
            Dim tb As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)
            If tb Is Nothing OrElse Object.ReferenceEquals(tb, current) Then Continue For

            Dim otherVal As String = (tb.Text & "").Trim()
            If otherVal <> "" AndAlso String.Equals(otherVal, currentPropRaw, StringComparison.OrdinalIgnoreCase) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Duplicated Property number")
                current.Text = ""
                ModalPopupExtender2.Show()
                Exit Sub
            End If
        Next

        ' 2) Database uniqueness check (only for the current value)
        Dim propSql As String = currentPropRaw.Replace("'", "''")
        Dim dt As DataTable = objDerived.GetDataTable(
        "SELECT TOP 1 PropertyNo FROM AMS.Property_Dtl WHERE PropertyNo = '" & propSql & "'",
        CommandType.Text)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. already exists!")
            current.Text = ""
            ModalPopupExtender2.Show()
            Exit Sub
        End If

        ' keep the modal open after postback
        ModalPopupExtender2.Show()
    End Sub


    Protected Sub txtSerialNoOfEquip_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim current As TextBox = TryCast(sender, TextBox)
        If current Is Nothing Then
            ModalPopupExtender2.Show()
            Exit Sub
        End If

        Dim currentSerialRaw As String = (current.Text & "").Trim()
        If currentSerialRaw = "" Then
            ModalPopupExtender2.Show()
            Exit Sub
        End If

        ' 1) In-grid duplicate check (compare only against other rows, case-insensitive)
        For Each row As GridViewRow In grdPropertyInfo.Rows
            If row.RowType <> DataControlRowType.DataRow Then Continue For
            Dim tb As TextBox = TryCast(row.FindControl("txtSerialNoOfEquip"), TextBox)
            If tb Is Nothing OrElse Object.ReferenceEquals(tb, current) Then Continue For

            Dim otherVal As String = (tb.Text & "").Trim()
            If otherVal <> "" AndAlso String.Equals(otherVal, currentSerialRaw, StringComparison.OrdinalIgnoreCase) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Duplicated Serial number")
                current.Text = ""
                ModalPopupExtender2.Show()
                Exit Sub
            End If
        Next

        ' 2) Database uniqueness check (only for the current value)
        Dim serialSql As String = currentSerialRaw.Replace("'", "''")
        Dim dt As DataTable = objDerived.GetDataTable(
        "SELECT TOP 1 SerialNo FROM AMS.Property_Dtl WHERE SerialNo = '" & serialSql & "'",
        CommandType.Text)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Serial No. already exists!")
            current.Text = ""
            ModalPopupExtender2.Show()
            Exit Sub
        End If

        ' keep the modal open after postback
        ModalPopupExtender2.Show()
    End Sub



    Private Sub LoadApprovingOfficers()
        Try
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid, full_name FROM ams.tbl_approval", CommandType.Text)

            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = "full_name"
            drpApprovedOfficer.DataValueField = "approvalid"
            drpApprovedOfficer.DataBind()

            If dt.Rows.Count > 0 Then
                drpApprovedOfficer.Items.Insert(0, New ListItem("-- Select Approving Officer --", ""))
            End If
        Catch ex As Exception
            AddTrace("Error loading approving officers: " & ex.Message)
        End Try
    End Sub


    Private Function DecryptEncrypt(ByVal TheText As String) As String
        If String.IsNullOrEmpty(TheText) Then Return ""

        Dim tempChar As String = Nothing
        Dim i As Integer = 0
        Dim result As String = TheText

        For i = 1 To TheText.Length
            If Convert.ToInt32(TheText.Chars(i - 1)) < 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) + 100)
            ElseIf Convert.ToInt32(TheText.Chars(i - 1)) > 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) - 100)
            End If
            result = result.Remove(i - 1, 1).Insert(i - 1, (CChar(ChrW(tempChar))).ToString())
        Next i
        Return result
    End Function

    Protected Sub btnProceedApproval_Click(sender As Object, e As EventArgs) Handles btnProceedApproval.Click
        ' Validate selection
        If String.IsNullOrEmpty(drpApprovedOfficer.SelectedValue) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select an Approving Officer.")
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtApprovedPass.Text) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter the password.")
            Exit Sub
        End If

        ' Validate credentials
        Dim approved As String
        approved = objDerived.GetValue(
            "SELECT approvalid FROM ams.tbl_approval WHERE approvalid = '" &
            drpApprovedOfficer.SelectedValue() &
            "' AND npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'",
            CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
            txtApprovedPass.Text = ""
            ' Keep modal open - don't hide it
        Else
            ' Success - close modal and proceed with edit
            ModalPopupExtender_Approval.Hide()

            ' Enable editing
            btnSave.Text = "UPDATE"
            IsEnabledTextBox(True)   ' True = enable textboxes for editing


            btnSave.Enabled = True
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Approval successful. You can now edit the information.")
        End If
    End Sub

    Protected Sub btnCancelApproval_Click(sender As Object, e As EventArgs) Handles btnCancelApproval.Click
        ModalPopupExtender_Approval.Hide()
        txtApprovedPass.Text = ""
    End Sub

    Private Function CleanNumericString(ByVal input As String) As String
        If String.IsNullOrEmpty(input) Then Return String.Empty

        ' Remove commas, currency symbols, spaces, and any non-numeric characters except decimal point
        Dim cleaned As String = input.Replace(",", "")  ' Remove commas
        cleaned = cleaned.Replace("$", "")              ' Remove dollar signs
        cleaned = cleaned.Replace("₱", "")              ' Remove peso signs
        cleaned = cleaned.Trim()                        ' Remove leading/trailing spaces

        Return cleaned
    End Function


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
            txtUsefulLife.Text = "0"
        Else
            txtUsefulLife.Text = usefulLife
        End If


    End Sub
End Class
