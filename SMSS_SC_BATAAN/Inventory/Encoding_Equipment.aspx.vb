Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Drawing


Partial Class Inventory_Encoding_Equipment
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim counts As Integer = 0
    Dim objDerived As New DerivedDal


    Public Class TempPropertyDetail
        Public Property PropertyNo As String
        Public Property SerialNo As String
        Public Property FloorLocation As String
        Public Property RoomLocation As String
        Public Property PropertyDtl_ID As String
        Public Property ChassisNo As String
        Public Property EngineNo As String

    End Class

    Private Sub Inventory_Encoding_Equipment_Load(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles Me.Load

        objx.GetAccessRight(Me.Session("@UserName"), Page)

        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then

            txtDate.Text = Date.Now.ToString("MM-dd-yyyy")
            Session("Item_ID") = 0

            Dim Classification As DataTable = objDerived.GetDataTable(
            "SELECT " &
            "    ClassificationId, " &
            "    ClassificationName " &
            "FROM dbo.tbl_Classification " &
            "WHERE ClassificationName LIKE 'Equipment%' " &
            "ORDER BY ClassificationName",
            CommandType.Text
        )

            ddClass.DataSource = Classification
            ddClass.DataTextField = "ClassificationName"
            ddClass.DataValueField = "ClassificationId"
            ddClass.DataBind()

            If Classification IsNot Nothing AndAlso
           Classification.Rows.Count > 0 Then

                ddClass.SelectedIndex = 0
                Session("ClassificationID") = ddClass.SelectedValue

            Else

                Session("ClassificationID") = "0"

            End If

            AddTrace(
            "Classification: " &
            Convert.ToString(Session("ClassificationID"))
        )

            selectClassification()

            If chkHeavyEquipment IsNot Nothing Then
                chkHeavyEquipment.Checked = False
            End If

        End If
    End Sub


    Public Sub selectClassification()

        If ddClass.SelectedItem IsNot Nothing Then
            lblClass.Text = "Encoding of " & ddClass.SelectedItem.Text
            Session("ClassificationID") = ddClass.SelectedValue
        Else
            lblClass.Text = "Encoding of Equipment"
            Session("ClassificationID") = "0"
        End If

        LoadGLAccounts()

        drpSubClass.Items.Clear()
        drpSubClass.Items.Insert(
        0,
        New ListItem("No Subclass", "0")
    )
        drpSubClass.Enabled = True

        ClearItemDesc()

        ddCategory.Items.Clear()
        ddCategory.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        ddSubCategory.Items.Clear()
        ddSubCategory.Items.Insert(
        0,
        New ListItem("Select", "0")
    )
        ddSubCategory.Enabled = True

        lblSubClass.Text = "EQUIPMENT INFORMATION"

        hdnGAId.Value = "0"
        hdnItemNo.Value = "0"
        Session("Item_ID") = 0

        loadEquipmentLedger()

    End Sub

    Private Sub LoadGLAccounts()
        ddGlAccount.Items.Clear()

        Dim classificationID As Integer = 0

        Integer.TryParse(
        Convert.ToString(Session("ClassificationID")),
        classificationID
    )

        If classificationID = 0 Then

            ddGlAccount.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            ddGlAccount.Enabled = True
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

        Dim dt As DataTable = objDerived.GetDataTable(
        sql,
        CommandType.Text
    )

        If dt IsNot Nothing Then

            Dim dr As DataRow = dt.NewRow()
            dr("GA_ID") = 0
            dr("GA_Title") = "Select"
            dt.Rows.InsertAt(dr, 0)

            ddGlAccount.DataSource = dt
            ddGlAccount.DataTextField = "GA_Title"
            ddGlAccount.DataValueField = "GA_ID"
            ddGlAccount.DataBind()

        Else

            ddGlAccount.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

        End If

        ddGlAccount.Enabled = True
    End Sub


    Public Sub SelectSubClassification()
        LoadSubClassifications()
    End Sub


    Private Sub LoadSubClassifications()
        drpSubClass.Items.Clear()

        If ddGlAccount.SelectedValue Is Nothing OrElse
       ddGlAccount.SelectedValue = "" OrElse
       ddGlAccount.SelectedValue = "0" Then

            drpSubClass.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

            drpSubClass.Enabled = True
            Exit Sub

        End If

        Dim classificationID As Integer = 0
        Dim gaID As Integer = 0

        Integer.TryParse(
        Convert.ToString(Session("ClassificationID")),
        classificationID
    )

        Integer.TryParse(
        ddGlAccount.SelectedValue,
        gaID
    )

        If classificationID = 0 OrElse gaID = 0 Then

            drpSubClass.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

            drpSubClass.Enabled = True
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
            dr("SubClassificationName") = "No Subclass"
            dt.Rows.InsertAt(dr, 0)

            drpSubClass.DataSource = dt
            drpSubClass.DataTextField = "SubClassificationName"
            drpSubClass.DataValueField = "SubClassificationID"
            drpSubClass.DataBind()

        Else

            drpSubClass.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

        End If

        drpSubClass.Enabled = True
    End Sub

    Public Sub SelectGAaccount()
        ddCategory.Items.Clear()

        Dim classificationID As Integer = 0
        Dim gaID As Integer = 0
        Dim subClassificationID As Integer = 0

        Integer.TryParse(
        Convert.ToString(Session("ClassificationID")),
        classificationID
    )

        Integer.TryParse(
        Convert.ToString(ddGlAccount.SelectedValue),
        gaID
    )

        Integer.TryParse(
        Convert.ToString(drpSubClass.SelectedValue),
        subClassificationID
    )

        If classificationID = 0 OrElse gaID = 0 Then

            ddCategory.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            ddSubCategory.Items.Clear()
            ddSubCategory.Items.Insert(
            0,
            New ListItem("Select", "0")
        )
            ddSubCategory.Enabled = True

            Exit Sub

        End If

        Dim sql As String =
        "SELECT DISTINCT " &
        "    ip.item_particular_id, " &
        "    ip.description " &
        "FROM AMS.item_particular AS ip " &
        "INNER JOIN dbo.tblclassmatrix AS c " &
        "    ON c.categoryid = ip.item_particular_id " &
        "WHERE c.classificationid = " & classificationID & " " &
        "AND c.GA_ID = " & gaID & " " &
        "AND (" & subClassificationID & " = 0 " &
        "     OR c.SubClassificationID = " &
                     subClassificationID & ") " &
        "ORDER BY ip.description"

        AddTrace(sql)

        Dim dt As DataTable = objDerived.GetDataTable(
        sql,
        CommandType.Text
    )

        If dt IsNot Nothing Then

            ddCategory.DataSource = dt
            ddCategory.DataTextField = "description"
            ddCategory.DataValueField = "item_particular_id"
            ddCategory.DataBind()

        End If

        ddCategory.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        selectCatergory()

    End Sub
    Public Sub selectCatergory()
        ddSubCategory.Items.Clear()

        Dim categoryID As Integer = 0

        Integer.TryParse(
        Convert.ToString(ddCategory.SelectedValue),
        categoryID
    )

        If categoryID = 0 Then

            ddSubCategory.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            ddSubCategory.Enabled = True
            Exit Sub

        End If

        Dim subcategory As DataTable = objDerived.GetDataTable(
        "SELECT " &
        "    SubCategoryID, " &
        "    SubCat_Desc " &
        "FROM dbo.tbl_SubCategory " &
        "WHERE item_particular_id = " & categoryID & " " &
        "ORDER BY SubCat_Desc",
        CommandType.Text
    )

        If subcategory IsNot Nothing Then

            ddSubCategory.DataSource = subcategory
            ddSubCategory.DataTextField = "SubCat_Desc"
            ddSubCategory.DataValueField = "SubCategoryID"
            ddSubCategory.DataBind()

        End If

        ddSubCategory.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        ddSubCategory.Enabled = True
    End Sub


    Private Sub ClearItemDesc()
        drpName.Items.Clear()

        drpName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        drpName.Enabled = True

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"

        If drpUnit.Items.Count > 0 Then
            drpUnit.SelectedIndex = 0
        End If

        btnSave.Enabled = False
    End Sub


    Private Sub LoadItemDesc()

        If ddGlAccount.SelectedValue Is Nothing OrElse
       ddGlAccount.SelectedValue = "" OrElse
       ddGlAccount.SelectedValue = "0" Then

            ClearItemDesc()
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
        Convert.ToString(ddGlAccount.SelectedValue),
        gaID
    )

        Integer.TryParse(
        Convert.ToString(drpSubClass.SelectedValue),
        subClassificationID
    )

        If classificationID = 0 OrElse
       gaID = 0 Then

            ClearItemDesc()
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

        If dt Is Nothing Then
            ClearItemDesc()
            Exit Sub
        End If

        Dim dr As DataRow = dt.NewRow()

        dr("Item_ID") = 0
        dr("ItemDescription") = "Select"

        dt.Rows.InsertAt(dr, 0)

        drpName.DataSource = dt
        drpName.DataTextField = "ItemDescription"
        drpName.DataValueField = "Item_ID"
        drpName.DataBind()

        drpName.Enabled = True

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"
        hdnGAId.Value = Convert.ToString(ddGlAccount.SelectedValue)

        btnSave.Enabled = False

    End Sub

    Protected Sub ddGlAccount_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"

        If ddGlAccount.SelectedValue Is Nothing OrElse
       ddGlAccount.SelectedValue = "" Then

            hdnGAId.Value = "0"

        Else

            hdnGAId.Value = ddGlAccount.SelectedValue

        End If

        LoadSubClassifications()
        ClearItemDesc()

        SelectGAaccount()
        LoadItemDesc()
        loadEquipmentLedger()

        AddTrace(
        "ddGlAccount: " &
        Convert.ToString(ddGlAccount.SelectedValue)
    )

    End Sub

    Public Sub multiviewselected()
        Dim subcategoryID As Integer = 0
        Dim categoryID As Integer = 0
        Dim gaID As Integer = 0

        Integer.TryParse(
        Convert.ToString(ddSubCategory.SelectedValue),
        subcategoryID
    )

        Integer.TryParse(
        Convert.ToString(ddCategory.SelectedValue),
        categoryID
    )

        Integer.TryParse(
        Convert.ToString(ddGlAccount.SelectedValue),
        gaID
    )

        AddTrace("ddGlAccount: " & gaID)
        AddTrace("Categoryid: " & categoryID)
        AddTrace("subcategory: " & subcategoryID)

        Dim dtAccount As DataTable = objDerived.GetDataTable(
        "EXEC dbo.SMSS_ProtertyRecords_v1_02262022 " &
        "'" & gaID & "'," &
        "'" & categoryID & "'," &
        "'" & subcategoryID & "'",
        CommandType.Text
    )

        If dtAccount Is Nothing Then

            dtAccount = createdatatable15(3)

        ElseIf dtAccount.Rows.Count < 4 Then

            dtAccount.Merge(
            createdatatable15(
                3 - dtAccount.Rows.Count
            )
        )

        End If

        gvsearchproperty.DataSource = dtAccount
        gvsearchproperty.DataBind()

        If gvsearchproperty.Rows.Count > 0 Then
            gvsearchproperty.SelectedIndex = 0
        Else
            gvsearchproperty.SelectedIndex = -1
        End If

        mvEquipment.ActiveViewIndex = 0

        Dim canLoadEquipmentList As Boolean = False

        If gvsearchproperty.SelectedDataKey IsNot Nothing Then

            Dim categoryObject As Object =
            gvsearchproperty.SelectedDataKey.Values(
                "item_particular_id"
            )

            Dim itemObject As Object =
            gvsearchproperty.SelectedDataKey.Values(
                "Item_ID"
            )

            Dim selectedCategoryID As Long = 0
            Dim selectedItemID As Long = 0

            If categoryObject IsNot Nothing AndAlso
           Not IsDBNull(categoryObject) Then

                Long.TryParse(
                categoryObject.ToString(),
                selectedCategoryID
            )

            End If

            If itemObject IsNot Nothing AndAlso
           Not IsDBNull(itemObject) Then

                Long.TryParse(
                itemObject.ToString(),
                selectedItemID
            )

            End If

            canLoadEquipmentList =
            selectedCategoryID > 0 AndAlso
            selectedItemID > 0

        End If

        If canLoadEquipmentList Then
            'loadEquipmentList()
        End If

        loadEquipmentLedger()

    End Sub


    Public Function createdatatable15(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("ItemDescription", GetType(String))
        dt.Columns.Add("unit", GetType(String))
        dt.Columns.Add("item_particular_id", GetType(Long))
        dt.Columns.Add("TD_ID", GetType(Integer))
        dt.Columns.Add("ItemCount", GetType(Integer))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("reorderpt", GetType(Integer))
        'dt.Columns.Add("Balance", GetType(Integer))
        'dt.Columns.Add("orders", GetType(String))
        'dt.Columns.Add("minqty", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Property_code") = DBNull.Value
            dr("ItemCount") = DBNull.Value
            dr("ItemDescription") = DBNull.Value
            dr("unit") = DBNull.Value
            dr("reorderpt") = DBNull.Value
            dr("item_particular_id") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("TD_ID") = DBNull.Value
            'dr("Balance") = DBNull.Value
            'dr("orders") = DBNull.Value
            'dr("minqty") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function


    Public Function createdatatable4A(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Type", GetType(String))
        dt.Columns.Add("serialno", GetType(String))
        dt.Columns.Add("datepurchased", GetType(String))
        dt.Columns.Add("acquisitioncost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("status", GetType(String))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("PODtl_ID", GetType(Long))
        dt.Columns.Add("Barcode", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Received_ID", GetType(Long))
        dt.Columns.Add("Received_Date", GetType(Date))
        dt.Columns.Add("Date_Accepted", GetType(Date))
        dt.Columns.Add("useful_life", GetType(Integer))
        dt.Columns.Add("Received_Dtl_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Type") = DBNull.Value
            dr("serialno") = DBNull.Value
            dr("datepurchased") = DBNull.Value
            dr("acquisitioncost") = DBNull.Value
            dr("MarketValue") = DBNull.Value
            dr("Condition") = DBNull.Value
            dr("Location") = DBNull.Value
            dr("status") = DBNull.Value
            dr("Property_ID") = DBNull.Value
            dr("PropertyDetai_ID") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("PODtl_ID") = DBNull.Value
            dr("Barcode") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("Received_ID") = DBNull.Value
            dr("Received_Date") = DBNull.Value
            dr("Date_Accepted") = DBNull.Value
            dr("useful_life") = DBNull.Value
            dr("Received_Dtl_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Sub loadEquipmentLedger()
        btnEquipmentLedger.CssClass = "Clicked"
        btnequipmentrepairs.CssClass = "Initial"
        btnequipmentattachdoc.CssClass = "Initial"

        mvledger.SetActiveView(vwledger)

        Dim itemID As Long = 0

        If drpName.SelectedValue IsNot Nothing AndAlso
       drpName.SelectedValue <> "" AndAlso
       drpName.SelectedValue <> "0" Then

            Long.TryParse(
            drpName.SelectedValue,
            itemID
        )

        End If

        If itemID = 0 AndAlso
       Not String.IsNullOrWhiteSpace(hdnItemNo.Value) Then

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

            AddTrace(
            "Executing: EXEC AMS.PropertyLedger " &
            itemID
        )

            dtAccount = objDerived.GetDataTable(
            "EXEC AMS.PropertyLedger '" & itemID & "'",
            CommandType.Text
        )

        Else

            hdnItemNo.Value = "0"
            Session("Item_ID") = 0

            dtAccount = objDerived.GetDataTable(
            "EXEC AMS.PropertyLedger NULL",
            CommandType.Text
        )

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

        If ddGlAccount.SelectedValue IsNot Nothing AndAlso
       ddGlAccount.SelectedValue <> "" AndAlso
       ddGlAccount.SelectedValue <> "0" Then

            hdnGAId.Value = ddGlAccount.SelectedValue

        ElseIf itemID > 0 Then

            hdnGAId.Value = Convert.ToString(
            objDerived.GetValue(
                "SELECT TOP 1 ip.GA_ID " &
                "FROM dbo.m_item AS i " &
                "INNER JOIN AMS.item_particular AS ip " &
                "    ON i.item_particular_id = " &
                     "ip.item_particular_id " &
                "WHERE i.Item_ID = " & itemID,
                CommandType.Text
            )
        )

        Else

            hdnGAId.Value = "0"

        End If

        btnSave.Text = "SAVE"
        btnSave.Enabled = itemID > 0

    End Sub

    Public Function createdatatableledger(
    ByVal row As Integer
) As DataTable

        Dim dt As New DataTable()

        dt.Columns.Add("Ledger_ID", GetType(Long))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("dDate", GetType(Date))
        dt.Columns.Add("Trans_Type", GetType(String))
        dt.Columns.Add("ref", GetType(String))
        dt.Columns.Add("AccountablePerson", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("position", GetType(String))
        dt.Columns.Add("acceptedby", GetType(String))
        dt.Columns.Add("inspectedby", GetType(String))
        dt.Columns.Add("BalanceUnit", GetType(String))
        dt.Columns.Add("Cost", GetType(Decimal))
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

    Protected Sub btnequipmentrepairs_Click(sender As Object, e As EventArgs)
        loadEquipmentRepair()
    End Sub

    Protected Sub loadEquipmentRepair()
        btnEquipmentLedger.CssClass = "Initial"
        btnequipmentrepairs.CssClass = "Clicked"
        btnequipmentattachdoc.CssClass = "Initial"

        Me.mvledger.SetActiveView(Me.vwrepairsandmaintenance) '[dbo].[View_EquipmentRepair]
        Dim dtAccount As New DataTable

        dtAccount = objDerived.GetDataTable("select *  from [dbo].[View_RepairAndMaintenance] where PropertyNo = '" & grdlistofEuipment.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable11(7 - dtAccount.Rows.Count))
        End If
        grdrepairsandmaintenance.DataSource = dtAccount
        grdrepairsandmaintenance.DataBind()

    End Sub
    Public Function createdatatable11(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        dt.Columns.Add("Date", GetType(String))
        dt.Columns.Add("serviceprovider", GetType(String))
        dt.Columns.Add("NatureRepair", GetType(String))
        dt.Columns.Add("invoiceno", GetType(String))
        dt.Columns.Add("Amount", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Property_Dtl_ID") = DBNull.Value
            dr("Date") = DBNull.Value
            dr("serviceprovider") = DBNull.Value
            dr("NatureRepair") = DBNull.Value
            dr("invoiceno") = DBNull.Value
            dr("amount") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Protected Sub btnEquipmentLedger_Click(sender As Object, e As EventArgs)
        loadEquipmentLedger()
    End Sub
    Protected Sub btnequipmentattachdoc_Click(sender As Object, e As EventArgs)
        loadEquipmentAttchDocu()
        loadAttchDocuChangeIndex()
    End Sub
    Protected Sub loadEquipmentAttchDocu()
        btnEquipmentLedger.CssClass = "Initial"
        btnequipmentrepairs.CssClass = "Initial"
        btnequipmentattachdoc.CssClass = "Clicked"
        Me.mvledger.SetActiveView(Me.vwdocumentattachment)

        Dim dtAccount As New DataTable
        dtAccount = objDerived.GetDataTable("Select *  from AMS.DocumentAttachment where IdentityNo = '" & grdlistofEuipment.SelectedDataKey("PODtl_ID") & "' and TableName = 'AIR_EquipAttchDocu'", CommandType.Text)
        If dtAccount.Rows.Count < 8 Then
            dtAccount.Merge(createdatatable3(7 - dtAccount.Rows.Count))
        End If
        grdpropertydocdetails.DataSource = dtAccount
        grdpropertydocdetails.DataBind()
        grdpropertydocdetails.SelectedIndex = 0

        loadAttchDocuChangeIndex()
    End Sub

    Public Function createdatatable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("DocuId", GetType(Long))
        dt.Columns.Add("IdentityNo", GetType(Long))
        dt.Columns.Add("documentname", GetType(String))
        dt.Columns.Add("documentno", GetType(String))
        dt.Columns.Add("validatedby", GetType(String))
        dt.Columns.Add("datevalidated", GetType(String))
        dt.Columns.Add("Remarks", GetType(String))
        dt.Columns.Add("TableName", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("DocuId") = DBNull.Value
            dr("IdentityNo") = DBNull.Value
            dr("documentname") = DBNull.Value
            dr("documentno") = DBNull.Value
            dr("validatedby") = DBNull.Value
            dr("datevalidated") = DBNull.Value
            dr("Remarks") = DBNull.Value
            dr("TableName") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub loadAttchDocuChangeIndex()
        Try
            Dim id As New Integer
            id = grdpropertydocdetails.SelectedDataKey(0).ToString
            imgpropertydocs.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & id
        Catch ex As Exception
            imgpropertydocs.ImageUrl = "~/images/BlankImage.jpg"
        End Try

        Me.mvledger.SetActiveView(Me.vwdocumentattachment)
    End Sub

    Protected Sub grdlistofEuipment_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")

            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdlistofEuipment, "Select$" + e.Row.RowIndex.ToString()))
            ' e.Row.Cells(0).Visible = False

        End If



    End Sub
    Protected Sub grdlistofEuipment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'loadEquipmentInformation()
        loadEquipmentLedger()
    End Sub

    Protected Sub grdlistofEuipment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtAccount As New DataTable
        dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatable4A(3 - dtAccount.Rows.Count))
        End If

        grdlistofEuipment.PageIndex = e.NewPageIndex
        grdlistofEuipment.DataSource = dtAccount
        grdlistofEuipment.DataBind()
        grdlistofEuipment.SelectedIndex = 0
    End Sub

    Protected Sub gvsearchproperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSave.Enabled = True
        btnCancel.Enabled = True
        'loadEquipmentList()

        grdlistofEuipment.SelectedIndex = 0
        'loadEquipmentInformation()
        loadEquipmentLedger()

    End Sub
    Protected Sub gvsearchproperty_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearchproperty, "Select$" + e.Row.RowIndex.ToString()))
        End If

        '=-= Notify if Balance reach re-order point
        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    If e.Row.Cells(7).Text = "&nbsp;" Then
        '        Exit Sub
        '    Else
        '        If CInt(e.Row.Cells(4).Text) <= CInt(e.Row.Cells(7).Text) Then  'e.Row.Cells(4).Text <= e.Row.Cells(3).Text Then
        '            e.Row.BackColor = Drawing.Color.OrangeRed
        '        End If
        '    End If
        'End If


    End Sub



    Protected Sub LoadEquipDTL()

        Dim textboxes As TextBox() = New TextBox() _
{
    txtequipmentpowerinput, txtequipmentmodel, lblequipmentbrand, txtequipmentSerialNo, txtEquipmentQuantity,
    txtequipmentwaranty, txtequipmentdimension, txtContractor, txtContactPerson,
    txtCellphoneNo, txtEAcqDate, txtEAcqCost, txtDepreciatedRate, txtequipmentdepreciatedvalue,
    txtEMarketValue, txtNoYears, txtUsefulLife, txtSalvageValue, txtSpecification
}

        ' Iterate through the array and clear the text in each textbox
        For Each textbox As TextBox In textboxes
            textbox.Text = ""
        Next


    End Sub


    Protected Sub drpSubClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"

        If drpSubClass.SelectedItem IsNot Nothing AndAlso
       drpSubClass.SelectedValue <> "0" Then

            lblSubClass.Text =
            drpSubClass.SelectedItem.Text.ToUpper() &
            " INFORMATION"

        Else

            lblSubClass.Text = "EQUIPMENT INFORMATION"

        End If

        SelectGAaccount()
        LoadItemDesc()
        loadEquipmentLedger()

        AddTrace(
        "drpSubClass: " &
        Convert.ToString(drpSubClass.SelectedValue)
    )

    End Sub
    Protected Sub ddCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectCatergory()

        multiviewselected()
    End Sub


    Protected Sub lblequipmentdepreciatedRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' LoadEquipDepreciation()
    End Sub

    Protected Sub txtEAcqDate_TextChanged(sender As Object, e As EventArgs)
        'LoadEquipDepreciation()
    End Sub

    Protected Sub txtSalvageValue_TextChanged(sender As Object, e As EventArgs)
        ' LoadEquipDepreciation()
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub



    Protected Sub btnSave_Click(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If btnSave.Text = "SAVE" Then

            If Not ValidateEquipmentSelections() Then
                Exit Sub
            End If

            hdnGAId.Value = ddGlAccount.SelectedValue
            hdnItemNo.Value = drpName.SelectedValue
            Session("Item_ID") = drpName.SelectedValue

            SAVE()
            loadEquipmentLedger()

        ElseIf btnSave.Text = "EDIT" Then

            Dim dt As DataTable = objDerived.GetDataTable(
            "SELECT approvalid, full_name " &
            "FROM ams.tbl_approval " &
            "ORDER BY full_name",
            CommandType.Text
        )

            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = "full_name"
            drpApprovedOfficer.DataValueField = "approvalid"
            drpApprovedOfficer.DataBind()

            ModalPopupExtender1.Show()

        ElseIf btnSave.Text = "UPDATE" Then

            If Not ValidateEquipmentSelections() Then
                Exit Sub
            End If

            hdnGAId.Value = ddGlAccount.SelectedValue
            hdnItemNo.Value = drpName.SelectedValue
            Session("Item_ID") = drpName.SelectedValue

            Edit()
            loadEquipmentLedger()

        End If

        btnSave.Enabled = False
    End Sub
    Public Sub SAVE()

        'hdnGAId.Value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
        hdnGAId.Value = ddGlAccount.SelectedValue




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



        If String.IsNullOrWhiteSpace(txtequipmentdesciption.Text) Then
            missingFields.Add("Description")
        End If

        If String.IsNullOrWhiteSpace(txtEquipmentQuantity.Text) Then
            missingFields.Add("Quantity")
        End If


        If String.IsNullOrWhiteSpace(txtEAcqDate.Text) Then
            missingFields.Add("Acquisition Date")
        End If
        If String.IsNullOrWhiteSpace(txtEAcqCost.Text) Or txtEAcqCost.Text = "0.00" Or txtEAcqCost.Text = "0" Then
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
                .Property_Date = txtEAcqDate.Text
                .Issuance = 0
                .Remarks = txtRemarks.Text
                .Emp_ID = 0
                .F_ID = 1
                .AIRDtl_ID = 0
                .deptid = 0
                .isDonated = False
                .GA_ID = hdnGAId.Value
                .DonationRemarks = ""
                .Qty = txtEquipmentQuantity.Text
                .Balance = txtEquipmentQuantity.Text
                .Cost = CType(txtEAcqCost.Text, Decimal)
                .Item_ID = hdnItemNo.Value
                .Property_code = objDerived.GetValue("select ga_code2 from [AMS].[vw_item_master_list] where Item_ID ='" & hdnItemNo.Value & "' ", CommandType.Text)
                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .Function_ID = 86
                .TD_ID = 1
                .Project_ID = 0
                .Program_id = 0
                .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
            End With

            Dim PropHdr_ID As Integer = 0
            PropHdr_ID = Prop_Hdr.save()
            AddTrace("t_property_hdr PropHdr_ID: " & PropHdr_ID)

            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Property SET ClassificationID = '" & ddClass.SelectedValue & "',SubClassificationID = '" & drpSubClass.SelectedValue & "'  WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)


            For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                ' --- get row controls ---
                Dim tbPropNo As TextBox = TryCast(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox)
                Dim tbSerial As TextBox = TryCast(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox)
                Dim tbLocation As TextBox = TryCast(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox)
                Dim ddlInstalled As DropDownList = TryCast(grdPropertyInfo.Rows(i).FindControl("drpInstalledAtEquip"), DropDownList)

                ' NEW: heavy equipment fields (note: column may be hidden, so these can be Nothing)
                Dim tbChassis As TextBox = TryCast(grdPropertyInfo.Rows(i).FindControl("txtChassisNumber"), TextBox)
                Dim tbEngine As TextBox = TryCast(grdPropertyInfo.Rows(i).FindControl("txtEngineNumber"), TextBox)

                ' installed-at text (fall back to value if needed)
                Dim installedAtText As String = ""
                If ddlInstalled IsNot Nothing Then
                    installedAtText = If(ddlInstalled.SelectedItem IsNot Nothing, ddlInstalled.SelectedItem.Text, ddlInstalled.SelectedValue)
                End If

                ' market value (safe parse, default 0)
                Dim marketValue As Decimal = 0D
                Dim mvRaw As String = If(txtEMarketValue IsNot Nothing, txtEMarketValue.Text, String.Empty)
                If Not String.IsNullOrWhiteSpace(mvRaw) Then Decimal.TryParse(mvRaw.Replace(",", ""), marketValue)

                ' ---- Property_Dtl (per row) ----
                Dim Prop_Dtl As New t_property_dtl
                With Prop_Dtl
                    .PropertyNo = If(tbPropNo IsNot Nothing, tbPropNo.Text, "")
                    .Property_ID = PropHdr_ID
                    .Issued = False
                    .Repair = False
                    .Dispose = False
                    .DisposeDate = "1/1/1900"
                    .IsInspectionForDisposal = False
                    .InspectionDate = txtEAcqDate.Text
                    .F_ID = 1
                    .SerialNo = If(tbSerial IsNot Nothing, tbSerial.Text, "")
                    .Barcode = " "
                    .Amount = CType(txtEAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    .Details = txtSpecification.Text
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id WHERE Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                    .RC_ID = objDerived.GetValue("SELECT RC_ID FROM [dbo].[View_RespCenter_withFunctions] WHERE RC_Name LIKE '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .AccountablePerson = ""
                    .Function_ID = 86

                    ' --- per reference: save to Prop_Dtl directly ---
                    .InstalledAt = installedAtText
                    .Location = If(tbLocation IsNot Nothing, tbLocation.Text.Trim(), "")
                    .MarketValue = marketValue

                    ' NEW: assign chassis/engine (String.Empty or Nothing will flow to NULL via your DAL)
                    .ChassisNo = If(tbChassis IsNot Nothing, tbChassis.Text.Trim(), Nothing)
                    .EngineNo = If(tbEngine IsNot Nothing, tbEngine.Text.Trim(), Nothing)

                End With

                Dim PropDtl_ID As Integer = Prop_Dtl.save()



                Dim info_id As Integer
                Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info

                With objEquipInfo
                    .EquipInfoId = 0
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = PropDtl_ID
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                    .Name = txtName.Text
                    .Description = txtequipmentdesciption.Text
                    .PowerInput = txtequipmentpowerinput.Text
                    .Dimension = txtequipmentdimension.Text
                    .AreaCapacity = txtequipmentareacapacity.Text
                    .Model = txtequipmentmodel.Text
                    .Warranty = txtequipmentwaranty.Text
                    .Specification = txtSpecification.Text
                    .DepreciationRate = txtDepreciatedRate.Text
                    .DepreciationValue = txtequipmentdepreciatedvalue.Text
                    .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                    .RoomLocation = CType(grdPropertyInfo.Rows(i).FindControl("drpInstalledAtEquip"), DropDownList).SelectedItem.Text
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    'CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).SelectedItem.value
                    .AccountablePerson = ""
                    .SalvageValue = txtSalvageValue.Text
                    .NoYears = txtNoYears.Text
                    Dim usefulLife As Long = 0
                    If Not String.IsNullOrEmpty(txtUsefulLife.Text) AndAlso Not Long.TryParse(txtUsefulLife.Text, usefulLife) Then
                        usefulLife = 0 ' Set to 0 if input is invalid
                    End If
                    .UsefulLife = usefulLife
                    .Property_ID = PropHdr_ID

                End With
                AddTrace("TbEquipment_Info PropHdr_ID: " & PropHdr_ID)

                info_id = objEquipInfo.save()
                objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)
                'objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Remarks = '" & txtRemarks.Text & "'  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)
                objDerived.GetRecords(
                    "UPDATE AMS.TbEquipment_Info SET " &
                    "Remarks = '" & txtRemarks.Text.Replace("'", "''") & "', " &
                    "Unit_ID = " & drpUnit.SelectedValue & ", " &
                    "Specification = CAST('" & txtSpecification.Text.Replace("'", "''") & "' AS VARCHAR(MAX)), " &
                    "Brand = N'" & lblequipmentbrand.Text.Replace("'", "''") & "' " &
                    "WHERE EquipInfoId = " & info_id,
                    CommandType.Text
                )

                Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details
                With objEquipDtl
                    .EquipmentId = 0
                    .EquipInfoId = info_id
                    .Property_Dtl_ID = PropDtl_ID
                    Dim marketValue1 As Decimal = 0
                    If Not String.IsNullOrEmpty(txtEMarketValue.Text) AndAlso Not Decimal.TryParse(txtEMarketValue.Text, marketValue1) Then
                        marketValue1 = 0 ' Set to 0 if input is invalid
                    End If
                    .MarketValue = marketValue1
                    .Condition = ""

                    Dim location As String

                    If String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        location = "Bay-" & txtEquipmentBay.Text
                    ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        location = "Column-" & txtEquipmentColumn.Text
                    ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        location = "Floor-" & txtEquipmentFloor.Text
                    ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        location = "Room-" & txtEquipmentRoom.Text
                    ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        location = "Shelves-" & txtEquipmentShelves.Text
                    ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentBin.Text) Then
                        location = "Rack-" & txtEquipmentRack.Text
                    ElseIf String.IsNullOrEmpty(txtEquipmentBay.Text) And String.IsNullOrEmpty(txtEquipmentColumn.Text) And String.IsNullOrEmpty(txtEquipmentFloor.Text) And String.IsNullOrEmpty(txtEquipmentRoom.Text) And String.IsNullOrEmpty(txtEquipmentShelves.Text) And String.IsNullOrEmpty(txtEquipmentRack.Text) Then
                        location = "Bin-" & txtEquipmentBin.Text
                    End If
                    .Location = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                    .Status = "Accepted"
                    '.WarehouseID = drpEquipmentWarehouse.SelectedValue
                    Dim drp As DropDownList
                    drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtEquip"), DropDownList)

                    If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                        .BuildingId = 0
                    Else
                        .BuildingId = drp.SelectedValue
                    End If

                    .MaintenanceContactNo = txtContractor.Text
                    .MaintenanceContactPerson = txtContactPerson.Text
                    .MaintenanceContractor = txtCellphoneNo.Text
                    .Property_ID = PropHdr_ID
                End With
                AddTrace("TbEquipment_Details PropHdr_ID: " & PropHdr_ID)
                objEquipDtl.save()



            Next

            Dim Prop_Ledger As New t_PropertyLedger

            With Prop_Ledger
                .Ledger_ID = 0
                .PropertyNo = ""
                .SerialNo = ""
                .Trans_Type = "Manual Entry"
                .dDate = txtEAcqDate.Text
                .Ref = ""
                .AccountablePerson = ""
                .Department = 0
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = hdnItemNo.Value
                .DebitQty = txtEquipmentQuantity.Text
                .DebitCost = CType(txtEAcqCost.Text, Decimal) * txtEquipmentQuantity.Text
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)

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
                Convert.ToInt32(txtEquipmentQuantity.Text)

                Dim EquipmentAcquisitionCost As Decimal =
                CType(txtEAcqCost.Text.Replace(",", ""), Decimal)

                Dim NewEquipmentCost As Decimal =
                EquipmentAcquisitionCost * NewEquipmentQty

                .BalanceQty = Eqty + NewEquipmentQty
                .BalanceCost = Eqbalance + NewEquipmentCost


                .Property_ID = PropHdr_ID
            End With
            AddTrace("t_PropertyLedger PropHdr_ID: " & PropHdr_ID)
            Prop_Ledger.save()



            btnSave.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            'loadEquipmentList()
            'loadEquipmentInformation()
            loadEquipmentLedger()
        End If
        'End If
    End Sub


    Public Sub Edit()
        If txtEAcqCost.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")

        Else
            If Not IsNumeric(txtEAcqCost.Text) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
            Else


                AddTrace("hf_EquipInfoId.Value:" & hf_EquipInfoId.Value)
                AddTrace("hf_EquipmentId.Value:" & hf_EquipmentId.Value)
                AddTrace("hf_PropertyDetai_ID.Value:" & hf_PropertyDetai_ID.Value)
                'Try
                Dim objDerived As New DerivedDal
                objDerived.conStr = objDerived.DbaseConnect()

                objDerived.cmd.Parameters.AddWithValue("@EquipInfoId", hf_EquipInfoId.Value)
                objDerived.cmd.Parameters.AddWithValue("@PowerInput", txtequipmentpowerinput.Text)
                objDerived.cmd.Parameters.AddWithValue("@Dimension", txtequipmentdimension.Text)
                objDerived.cmd.Parameters.AddWithValue("@Model", txtequipmentmodel.Text)
                objDerived.cmd.Parameters.AddWithValue("@Brand", lblequipmentbrand.Text)
                objDerived.cmd.Parameters.AddWithValue("@Warranty", txtequipmentwaranty.Text)
                objDerived.cmd.Parameters.AddWithValue("@NoYears", txtNoYears.Text)
                objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtequipmentdepreciatedvalue.Text.Replace(",", ""))
                objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", txtDepreciatedRate.Text)
                objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtUsefulLife.Text)
                objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtSalvageValue.Text.Replace(",", ""))
                objDerived.cmd.Parameters.AddWithValue("@Specification", txtSpecification.Text)
                objDerived.cmd.Parameters.AddWithValue("@Description", txtequipmentdesciption.Text)
                objDerived.cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text)

                objDerived.cmd.Parameters.AddWithValue("@EquipmentId", hf_EquipmentId.Value)
                objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", txtContractor.Text)
                objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", txtContactPerson.Text)
                objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", txtCellphoneNo.Text)
                'objDerived.cmd.Parameters.AddWithValue("@Buildingid", drpInstalledAtBuilding.SelectedItem.Value)
                objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtEMarketValue.Text.Replace(",", ""))

                objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", hf_PropertyDetai_ID.Value)
                objDerived.cmd.Parameters.AddWithValue("@SerialNo", txtequipmentSerialNo.Text)

                objDerived.cmd.Parameters.AddWithValue("@Property_ID", hf_Property_ID.Value)
                objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtEAcqDate.Text)
                objDerived.cmd.Parameters.AddWithValue("@Cost", txtEAcqCost.Text.Replace(",", ""))
                objDerived.cmd.Parameters.AddWithValue("@Qty", txtEquipmentQuantity.Text)

                objDerived.cmd.Parameters.AddWithValue("@Item_ID", hf_Item_ID.Value)
                objDerived.cmd.Parameters.AddWithValue("@Unit_ID", drpUnit.SelectedItem.Value)

                objDerived.Execute("AMS.sp_Edit_Equipment_Encoding", CommandType.StoredProcedure)

                Dim dtAccount As New DataTable
                Dim cb1 As CheckBox
                Dim LedgerID As Long

                dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

                For i As Integer = 0 To grdLedger1.Rows.Count - 1
                    cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                    If cb1.Visible AndAlso cb1.Checked Then

                        LedgerID = dtAccount.Rows(i).Item("Ledger_ID").ToString()

                        Dim totalBalanceCostQuery As String = "SELECT SUM(BalanceCost) AS TotalBalanceCost " &
                            "FROM AMS.TbProperty_Ledger " &
                            "WHERE Ledger_ID = '" & LedgerID & "' "

                        Dim totalBalanceCost As Decimal = 0
                        Dim dt2 = objDerived.GetDataTable(totalBalanceCostQuery, CommandType.Text)

                        If dt2.Rows.Count > 0 AndAlso Not IsDBNull(dt2.Rows(0)("TotalBalanceCost")) Then
                            totalBalanceCost = Convert.ToDecimal(dt2.Rows(0)("TotalBalanceCost"))
                        End If

                        Dim balanceCost As Decimal = totalBalanceCost + CDec(txtEAcqCost.Text)

                        Dim acquisitionCost As Decimal = Convert.ToDecimal(txtEAcqCost.Text.Replace(",", ""))
                        Dim quantity As Integer = Convert.ToInt32(txtEquipmentQuantity.Text)

                        Dim overallDebitCost As Decimal = acquisitionCost * quantity

                        objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] " &
                      "SET DebitQty = '" & quantity & "', " &
                      "DebitCost = '" & overallDebitCost & "', " &
                      "DebitUnit = '" & drpUnit.Text & "', " &
                      "BalanceQty = '" & quantity & "', " &
                      "BalanceUnit = '" & drpUnit.Text & "', " &
                      "BalanceCost = '" & overallDebitCost & "' " &
                      "WHERE Ledger_ID = '" & LedgerID & "' ", CommandType.Text)


                    End If
                Next


                Dim tempTableDtlProperty As List(Of TempPropertyDetail) = TryCast(Session("TempPropertyList"), List(Of TempPropertyDetail))
                If tempTableDtlProperty Is Nothing Then
                    ' Build it from DB so Edit() can run even if btnaddpropertyinfo_Click was never called
                    tempTableDtlProperty = New List(Of TempPropertyDetail)()

                    Dim dt1 As DataTable = objDerived.GetDataTable(
                        "SELECT prop.PropertyNo, prop.SerialNo, prop.ChassisNo, prop.EngineNo, " &
                        "       eqinfo.FloorLocation, eqinfo.RoomLocation, prop.PropertyDetai_ID " &
                        "FROM AMS.Property_Dtl prop " &
                        "INNER JOIN AMS.TbEquipment_Info eqinfo ON prop.PropertyDetai_ID = eqinfo.Property_Dtl_ID " &
                        "WHERE prop.Property_ID = '" & hf_Property_ID.Value & "'", CommandType.Text)


                    For Each r As DataRow In dt1.Rows
                        tempTableDtlProperty.Add(New TempPropertyDetail With {
                            .PropertyNo = r("PropertyNo").ToString(),
                            .SerialNo = r("SerialNo").ToString(),
                            .ChassisNo = If(dt1.Columns.Contains("ChassisNo") AndAlso Not IsDBNull(r("ChassisNo")), r("ChassisNo").ToString(), ""),
                            .EngineNo = If(dt1.Columns.Contains("EngineNo") AndAlso Not IsDBNull(r("EngineNo")), r("EngineNo").ToString(), ""),
                            .FloorLocation = r("FloorLocation").ToString(),
                            .RoomLocation = r("RoomLocation").ToString(),
                            .PropertyDtl_ID = r("PropertyDetai_ID").ToString()
                        })
                    Next

                    Session("TempPropertyList") = tempTableDtlProperty
                End If




                'SEPARATE SAVING FROM PROPERTY INFORMATION POPOUT GRID VIEW ONLY
                Dim iterate As Integer = 0

                If grdPropertyInfo.Rows.Count > 0 Then
                    ' --- Normal path: update using values typed in the popup grid ---
                    For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                        Dim gvRow As GridViewRow = grdPropertyInfo.Rows(i)

                        Dim txtPropertyNo As TextBox = CType(gvRow.FindControl("txtPropertyNo"), TextBox)
                        Dim txtSerialNo As TextBox = CType(gvRow.FindControl("txtSerialNoOfEquip"), TextBox)
                        Dim txtPIFloorLocation As TextBox = CType(gvRow.FindControl("txtPIFloorLocation"), TextBox)
                        Dim drpInstalledAtEquip As DropDownList = CType(gvRow.FindControl("drpInstalledAtEquip"), DropDownList)

                        ' NEW: get chassis/engine inputs
                        Dim txtChassisNumber As TextBox = CType(gvRow.FindControl("txtChassisNumber"), TextBox)
                        Dim txtEngineNumber As TextBox = CType(gvRow.FindControl("txtEngineNumber"), TextBox)


                        iterate += 1

                        ' collect current values
                        Dim current As New TempPropertyDetail With {
                            .PropertyNo = If(txtPropertyNo IsNot Nothing, txtPropertyNo.Text.Trim(), ""),
                            .SerialNo = If(txtSerialNo IsNot Nothing, txtSerialNo.Text.Trim(), ""),
                             .ChassisNo = If(txtChassisNumber IsNot Nothing, txtChassisNumber.Text.Trim(), ""),
                            .EngineNo = If(txtEngineNumber IsNot Nothing, txtEngineNumber.Text.Trim(), ""),
                            .FloorLocation = If(txtPIFloorLocation IsNot Nothing, txtPIFloorLocation.Text.Trim(), ""),
                            .RoomLocation = If(drpInstalledAtEquip IsNot Nothing AndAlso drpInstalledAtEquip.SelectedItem IsNot Nothing,
                                               drpInstalledAtEquip.SelectedItem.Text.Trim(), "")
                        }

                        ' figure out PropertyDetai_ID for this row
                        Dim propDetaiId As String = ""
                        If tempTableDtlProperty IsNot Nothing AndAlso i < tempTableDtlProperty.Count Then
                            propDetaiId = Convert.ToString(tempTableDtlProperty(i).PropertyDtl_ID)
                        End If
                        If String.IsNullOrEmpty(propDetaiId) AndAlso
                           grdPropertyInfo.DataKeys IsNot Nothing AndAlso
                           grdPropertyInfo.DataKeys.Count > i AndAlso
                           grdPropertyInfo.DataKeys(i) IsNot Nothing AndAlso
                           grdPropertyInfo.DataKeys(i).Values IsNot Nothing AndAlso
                           grdPropertyInfo.DataKeys(i).Values.Contains("PropertyDetai_ID") Then

                            propDetaiId = Convert.ToString(grdPropertyInfo.DataKeys(i).Values("PropertyDetai_ID"))
                        End If
                        If String.IsNullOrEmpty(propDetaiId) Then
                            AddTrace("Edit(): skip row " & i & " — missing PropertyDetai_ID")
                            Continue For
                        End If

                        ' ---- call SP to update Property_Dtl for this row ----
                        Dim pNo As String = If(String.IsNullOrEmpty(current.PropertyNo), "NULL", "'" & current.PropertyNo.Replace("'", "''") & "'")
                        Dim sNo As String = If(String.IsNullOrEmpty(current.SerialNo), "NULL", "'" & current.SerialNo.Replace("'", "''") & "'")
                        Dim instAt As String = If(String.IsNullOrEmpty(current.RoomLocation), "NULL", "'" & current.RoomLocation.Replace("'", "''") & "'")
                        Dim loc As String = If(String.IsNullOrEmpty(current.FloorLocation), "NULL", "'" & current.FloorLocation.Replace("'", "''") & "'")

                        Dim sqlUpdDtl As String =
                        "EXEC [AMS].[sp_Update_PropertyDtl_Row] " & propDetaiId & ", " & pNo & ", " & sNo & ", " & instAt & ", " & loc
                        objDerived.GetRecords(sqlUpdDtl, CommandType.Text)

                        ' NEW: update chassis & engine on Property_Dtl (NULL-safe)
                        Dim chNo As String = If(String.IsNullOrEmpty(current.ChassisNo), "NULL", "'" & current.ChassisNo.Replace("'", "''") & "'")
                        Dim enNo As String = If(String.IsNullOrEmpty(current.EngineNo), "NULL", "'" & current.EngineNo.Replace("'", "''") & "'")

                        Dim sqlUpdChEng As String =
                            "UPDATE AMS.Property_Dtl SET " &
                            "ChassisNo = " & chNo & ", " &
                            "EngineNo = " & enNo & " " &
                            "WHERE PropertyDetai_ID = " & propDetaiId

                        objDerived.GetRecords(sqlUpdChEng, CommandType.Text)



                        ' ---- keep your Info/Dtl updates (tie to this Property_Dtl row) ----
                        objDerived.GetRecords("UPDATE [AMS].[TbEquipment_Info] " &
                      "SET SerialNo = '" & current.SerialNo.Replace("'", "''") & "', " &
                          "FloorLocation = '" & current.FloorLocation.Replace("'", "''") & "', " &
                          "RoomLocation = '" & current.RoomLocation.Replace("'", "''") & "', " &
                          "Unit_ID = '" & drpUnit.SelectedValue & "', " &
                          "Remarks = '" & txtRemarks.Text.Replace("'", "''") & "', " &
                          "Brand = '" & lblequipmentbrand.Text.Replace("'", "''") & "' " &
                      "WHERE Property_Dtl_ID = '" & propDetaiId & "' ", CommandType.Text)

                        objDerived.GetRecords("UPDATE [AMS].[TbEquipment_Dtl] " &
                              "SET Location = '" & current.FloorLocation.Replace("'", "''") & "', " &
                                  "MarketValue = '" & txtEMarketValue.Text.Replace(",", "") & "' " &
                              "WHERE Property_Dtl_ID = '" & propDetaiId & "' ", CommandType.Text)
                    Next

                ElseIf tempTableDtlProperty IsNot Nothing AndAlso tempTableDtlProperty.Count > 0 Then
                    ' --- Fallback path: grid has 0 rows. Update using the DB-loaded session list ---
                    For i As Integer = 0 To tempTableDtlProperty.Count - 1
                        Dim original As TempPropertyDetail = tempTableDtlProperty(i)
                        Dim propDetaiId As String = Convert.ToString(original.PropertyDtl_ID)
                        If String.IsNullOrEmpty(propDetaiId) Then Continue For

                        Dim pNo As String = If(String.IsNullOrEmpty(original.PropertyNo), "NULL", "'" & original.PropertyNo.Replace("'", "''") & "'")
                        Dim sNo As String = If(String.IsNullOrEmpty(original.SerialNo), "NULL", "'" & original.SerialNo.Replace("'", "''") & "'")
                        Dim instAt As String = If(String.IsNullOrEmpty(original.RoomLocation), "NULL", "'" & original.RoomLocation.Replace("'", "''") & "'")
                        Dim loc As String = If(String.IsNullOrEmpty(original.FloorLocation), "NULL", "'" & original.FloorLocation.Replace("'", "''") & "'")

                        ' SP for Property_Dtl
                        Dim sqlUpdDtl As String = "EXEC [AMS].[sp_Update_PropertyDtl_Row] " & propDetaiId & ", " & pNo & ", " & sNo & ", " & instAt & ", " & loc
                        objDerived.GetRecords(sqlUpdDtl, CommandType.Text)


                        ' NEW: chassis/engine from fallback list
                        Dim chNo As String = If(String.IsNullOrEmpty(original.ChassisNo), "NULL", "'" & original.ChassisNo.Replace("'", "''") & "'")
                        Dim enNo As String = If(String.IsNullOrEmpty(original.EngineNo), "NULL", "'" & original.EngineNo.Replace("'", "''") & "'")

                        Dim sqlUpdChEng As String =
                            "UPDATE AMS.Property_Dtl SET " &
                            "ChassisNo = " & chNo & ", " &
                            "EngineNo = " & enNo & " " &
                            "WHERE PropertyDetai_ID = " & propDetaiId

                        objDerived.GetRecords(sqlUpdChEng, CommandType.Text)



                        ' Info / Dtl keep in sync
                        objDerived.GetRecords("UPDATE [AMS].[TbEquipment_Info] " &
                      "SET SerialNo = '" & original.SerialNo.Replace("'", "''") & "', " &
                          "FloorLocation = '" & original.FloorLocation.Replace("'", "''") & "', " &
                          "RoomLocation = '" & original.RoomLocation.Replace("'", "''") & "', " &
                          "Unit_ID = '" & drpUnit.SelectedValue & "', " &
                          "Remarks = '" & txtRemarks.Text.Replace("'", "''") & "', " &
                          "Brand = '" & lblequipmentbrand.Text.Replace("'", "''") & "' " &
                      "WHERE Property_Dtl_ID = '" & propDetaiId & "' ", CommandType.Text)

                        objDerived.GetRecords("UPDATE [AMS].[TbEquipment_Dtl] " &
                              "SET Location = '" & original.FloorLocation.Replace("'", "''") & "', " &
                                  "MarketValue = '" & txtEMarketValue.Text.Replace(",", "") & "' " &
                              "WHERE Property_Dtl_ID = '" & propDetaiId & "' ", CommandType.Text)
                    Next

                Else
                    ' --- Last-resort: nothing in grid and nothing in session — at least set Unit/Remarks for the selected detail ---
                    If Not String.IsNullOrEmpty(hf_PropertyDetai_ID.Value) Then
                        objDerived.GetRecords("UPDATE [AMS].[TbEquipment_Info] " &
                          "SET Unit_ID = '" & drpUnit.SelectedValue & "', " &
                              "Remarks = '" & txtRemarks.Text.Replace("'", "''") & "', " &
                              "Brand = '" & lblequipmentbrand.Text.Replace("'", "''") & "' " &
                          "WHERE Property_Dtl_ID = '" & hf_PropertyDetai_ID.Value & "' ", CommandType.Text)
                    End If
                End If


                ' Get Item_ID
                Dim ItemID As Long = CLng(objDerived.GetValue("SELECT Item_ID FROM AMS.TbProperty_Ledger WHERE Ledger_ID = '" & LedgerID & "'", CommandType.Text))

                ' REBALANCE FROM EDITED ROW ABOVE
                'objDerived.Execute("EXEC [AMS].[ReBalanceLedger] " & ItemID, CommandType.Text)



                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                btnSave.Text = "EDIT"
                'End If

            End If
        End If

    End Sub


    Protected Sub ddSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        multiviewselected()
    End Sub
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT Unit_ID, Description FROM ams.m_Unit AS a ORDER BY CASE WHEN Description = '-' THEN 0 ELSE 1 END, Description;", CommandType.Text)
        drpUnit.DataSource = dt
        drpUnit.DataTextField = ("Description")
        drpUnit.DataValueField = ("Unit_ID")
        drpUnit.DataBind()
        AddTrace("Item_ID: " & Session("Item_ID"))
        Dim Unit_ID As Integer = objDerived.GetValue("SELECT Unit_ID FROM DBO.m_item WHERE Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        drpUnit.SelectedValue = Unit_ID

    End Sub

    Public Sub loadwarehouse()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("select warehouse_id,wname From ams.loc_warehouse", CommandType.Text)
        drpEquipmentWarehouse.DataTextField = ("wname")
        drpEquipmentWarehouse.DataValueField = ("warehouse_id")
        drpEquipmentWarehouse.DataSource = dt
        drpEquipmentWarehouse.DataBind()

    End Sub


    Protected Sub drpName_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If drpName.SelectedValue Is Nothing OrElse
       drpName.SelectedValue = "" OrElse
       drpName.SelectedValue = "0" Then

            Session("Item_ID") = 0
            hdnItemNo.Value = "0"

            If drpUnit.Items.Count > 0 Then
                drpUnit.SelectedIndex = 0
            End If

            loadEquipmentLedger()
            Exit Sub

        End If

        Session("Item_ID") = drpName.SelectedValue
        hdnItemNo.Value = drpName.SelectedValue
        hdnGAId.Value = ddGlAccount.SelectedValue

        loadEquipmentLedger()
        loadUnit()
        loadUsefulLife()

    End Sub


    Private Function ValidateEquipmentSelections() As Boolean

        If ddGlAccount.SelectedValue Is Nothing OrElse
       ddGlAccount.SelectedValue = "" OrElse
       ddGlAccount.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Please select General Account."
        )

            Return False

        End If



        If drpName.SelectedValue Is Nothing OrElse
       drpName.SelectedValue = "" OrElse
       drpName.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Please select Name."
        )

            Return False

        End If

        Return True

    End Function

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

        End If
    End Sub





    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        Dim dt As DataTable
        If ViewState("Customers") IsNot Nothing Then
            dt = DirectCast(ViewState("Customers"), DataTable)
        Else
            Exit Sub
        End If

        ' Get temp list; keep / init it
        Dim tempList As List(Of TempPropertyDetail) = GetTempPropertyList()
        If tempList Is Nothing Then tempList = New List(Of TempPropertyDetail)()

        ' Ensure table has at least as many rows as the grid (defensive)
        While dt.Rows.Count < grdPropertyInfo.Rows.Count
            dt.Rows.Add(dt.NewRow())
        End While

        ' Loop through GridView rows and save the data
        For Each row As GridViewRow In grdPropertyInfo.Rows
            If row.RowType <> DataControlRowType.DataRow Then Continue For

            Dim idx As Integer = row.RowIndex

            Dim txtPropertyNo As TextBox = CType(row.FindControl("txtPropertyNo"), TextBox)
            Dim txtSerialNumber As TextBox = CType(row.FindControl("txtSerialNoOfEquip"), TextBox)
            Dim drpInstalledAtMac As DropDownList = CType(row.FindControl("drpInstalledAtEquip"), DropDownList)
            Dim txtPIFloorLocation As TextBox = CType(row.FindControl("txtPIFloorLocation"), TextBox)

            ' PropertyNo
            If dt.Columns.Contains("PropertyNo") AndAlso txtPropertyNo IsNot Nothing Then
                dt.Rows(idx)("PropertyNo") = txtPropertyNo.Text
            End If

            ' SerialNo
            If dt.Columns.Contains("SerialNo") AndAlso txtSerialNumber IsNot Nothing Then
                dt.Rows(idx)("SerialNo") = txtSerialNumber.Text
            End If

            ' InstalledAt (text) + Buildingid (value)
            Dim installedText As String = If(drpInstalledAtMac IsNot Nothing AndAlso drpInstalledAtMac.SelectedItem IsNot Nothing, drpInstalledAtMac.SelectedItem.Text, "")
            Dim installedVal As String = If(drpInstalledAtMac IsNot Nothing, drpInstalledAtMac.SelectedValue, "")

            If String.IsNullOrEmpty(installedText) AndAlso String.IsNullOrEmpty(installedVal) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select a location where the property is installed.")
                Exit Sub
            End If

            If dt.Columns.Contains("InstalledAt") Then
                dt.Rows(idx)("InstalledAt") = installedText
            End If

            If dt.Columns.Contains("Buildingid") Then
                Dim buildingId As Long
                If Long.TryParse(installedVal, buildingId) Then
                    dt.Rows(idx)("Buildingid") = buildingId
                Else
                    dt.Rows(idx)("Buildingid") = DBNull.Value   ' <-- avoid FormatException
                End If
            End If

            ' Location vs FloorLocation (use whichever column exists)
            Dim loc As String = If(txtPIFloorLocation IsNot Nothing, txtPIFloorLocation.Text, String.Empty)
            If dt.Columns.Contains("FloorLocation") Then
                dt.Rows(idx)("FloorLocation") = loc
            ElseIf dt.Columns.Contains("Location") Then
                dt.Rows(idx)("Location") = loc
            End If

            ' Update session temp list
            Dim newItem As New TempPropertyDetail With {
            .PropertyNo = If(txtPropertyNo IsNot Nothing, txtPropertyNo.Text, ""),
            .SerialNo = If(txtSerialNumber IsNot Nothing, txtSerialNumber.Text, ""),
            .FloorLocation = loc,
            .RoomLocation = installedText
        }
            tempList.Add(newItem)
        Next

        Session("TempPropertyList") = tempList
        ViewState("Customers") = dt

        ' Close the modal
        ModalPopupExtender2.Hide()
    End Sub


    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drpInstalledAt As DropDownList = CType(e.Row.FindControl("drpInstalledAtEquip"), DropDownList)
            Dim txtPIFloorLocation As TextBox = CType(e.Row.FindControl("txtPIFloorLocation"), TextBox)
            Dim txtPropertyNo As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
            Dim txtSerialNumber As TextBox = CType(e.Row.FindControl("txtSerialNoOfEquip"), TextBox)

            ' NEW: Chassis & Engine controls
            Dim txtChassisNumber As TextBox = CType(e.Row.FindControl("txtChassisNumber"), TextBox)
            Dim txtEngineNumber As TextBox = CType(e.Row.FindControl("txtEngineNumber"), TextBox)

            ' 1) Bind Installed-At dropdown
            Dim query As String =
            "SELECT a.BuildingId, a.BuildingName + ' - ' + ISNULL(a.Address, '') AS Name " &
            "FROM ams.TbBuilding_Dtl AS a " &
            "INNER JOIN ams.Property_Dtl AS b ON a.Property_Dtl_ID = b.PropertyDetai_ID " &
            "ORDER BY a.BuildingName"

            drpInstalledAt.DataSource = objDerived.GetDataTable(query, CommandType.Text)
            drpInstalledAt.DataTextField = "Name"
            drpInstalledAt.DataValueField = "BuildingId"
            drpInstalledAt.DataBind()

            ' Add convenience items (text-only)
            drpInstalledAt.Items.Insert(0, New ListItem("Field"))
            drpInstalledAt.Items.Insert(1, New ListItem("N/A"))

            ' 2) Read the currently bound row values safely
            Dim drv As DataRowView = TryCast(e.Row.DataItem, DataRowView)
            If drv IsNot Nothing Then
                Dim cols As DataColumnCollection = drv.DataView.Table.Columns

                ' PropertyNo
                If cols.Contains("PropertyNo") AndAlso Not Convert.IsDBNull(drv("PropertyNo")) Then
                    If txtPropertyNo IsNot Nothing Then txtPropertyNo.Text = drv("PropertyNo").ToString()
                End If

                ' SerialNo
                If cols.Contains("SerialNo") AndAlso Not Convert.IsDBNull(drv("SerialNo")) Then
                    If txtSerialNumber IsNot Nothing Then txtSerialNumber.Text = drv("SerialNo").ToString()
                End If

                ' Location / FloorLocation (handle either)
                Dim locText As String = ""
                If cols.Contains("FloorLocation") AndAlso Not Convert.IsDBNull(drv("FloorLocation")) Then
                    locText = drv("FloorLocation").ToString()
                ElseIf cols.Contains("Location") AndAlso Not Convert.IsDBNull(drv("Location")) Then
                    locText = drv("Location").ToString()
                End If
                If txtPIFloorLocation IsNot Nothing Then
                    txtPIFloorLocation.Text = locText
                End If

                ' NEW: ChassisNo
                If cols.Contains("ChassisNo") AndAlso Not Convert.IsDBNull(drv("ChassisNo")) Then
                    If txtChassisNumber IsNot Nothing Then txtChassisNumber.Text = drv("ChassisNo").ToString()
                End If

                ' NEW: EngineNo
                If cols.Contains("EngineNo") AndAlso Not Convert.IsDBNull(drv("EngineNo")) Then
                    If txtEngineNumber IsNot Nothing Then txtEngineNumber.Text = drv("EngineNo").ToString()
                End If

                ' InstalledAt selection: prefer by Text, then fallback to Buildingid value
                Dim installedAtText As String = ""
                If cols.Contains("InstalledAt") AndAlso Not Convert.IsDBNull(drv("InstalledAt")) Then
                    installedAtText = drv("InstalledAt").ToString().Trim()
                End If

                Dim buildingId As String = ""
                If cols.Contains("Buildingid") AndAlso Not Convert.IsDBNull(drv("Buildingid")) Then
                    buildingId = drv("Buildingid").ToString().Trim()
                End If

                drpInstalledAt.ClearSelection()
                Dim liByText As ListItem = Nothing
                If installedAtText <> "" Then
                    liByText = drpInstalledAt.Items.FindByText(installedAtText)
                End If
                If liByText IsNot Nothing Then
                    liByText.Selected = True
                ElseIf buildingId <> "" Then
                    Dim liByVal As ListItem = drpInstalledAt.Items.FindByValue(buildingId)
                    If liByVal IsNot Nothing Then liByVal.Selected = True
                End If
            End If

            ' 3) When editing, disable Property No in this row
            If String.Equals(btnSave.Text, "EDIT", StringComparison.OrdinalIgnoreCase) Then
                If txtPropertyNo IsNot Nothing Then txtPropertyNo.Enabled = False
            End If
        End If

        ' Do NOT overwrite ViewState("Customers") here from DataSource.
    End Sub


    Private Function GetTempPropertyList() As List(Of TempPropertyDetail)
        Dim obj = Session("TempPropertyList")
        Dim list = TryCast(obj, List(Of TempPropertyDetail))
        If list Is Nothing Then
            ' could be first run or stale type from an old dynamic assembly — start fresh
            list = New List(Of TempPropertyDetail)()
            Session("TempPropertyList") = list
        End If
        Return list
    End Function


    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)

        'hf_EquipInfoId.Value
        'hf_EquipmentId.Value
        'hf_PropertyDetai_ID.Value
        'hf_Property_ID.Value
        'hf_Item_ID.Value

        If txtEquipmentQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
            Exit Sub
        End If

        Dim dt As DataTable
        ' Check if there is already data in ViewState
        If ViewState("Customers") IsNot Nothing Then
            dt = DirectCast(ViewState("Customers"), DataTable)
        Else
            ' ensure the table has Property_ID / PropertyDetai_ID columns expected by DataKeyNames
            dt = CreatePropertyInfoTable(0)
        End If

        ' Add new empty rows if necessary (use NewRow so all required columns exist)
        While dt.Rows.Count < Convert.ToInt32(txtEquipmentQuantity.Text)
            Dim r = dt.NewRow()
            r("Property_ID") = DBNull.Value
            r("PropertyNo") = DBNull.Value
            r("PropertyDetai_ID") = DBNull.Value
            r("SerialNo") = DBNull.Value
            r("InstalledAt") = DBNull.Value
            r("Location") = DBNull.Value
            dt.Rows.Add(r)
        End While

        While dt.Rows.Count > Convert.ToInt32(txtEquipmentQuantity.Text)
            dt.Rows.RemoveAt(dt.Rows.Count - 1)
        End While

        ' Save back to ViewState
        ViewState("Customers") = dt
        BindGrid()


        If ViewState("CheckboxEvent") = True Then

            '========================
            ' EDIT: use the SP result
            '========================
            If btnSave.Text = "EDIT" Then
                ' Pull rows for this ledger via SP (has Property_ID & PropertyDetai_ID, SerialNo, Location, InstalledAt, Buildingid)
                Dim dt1 As DataTable = objDerived.GetDataTable("EXEC [AMS].[OfficeEquipmentLedgerList] '" & Session("Ledger_ID") & "'", CommandType.Text)

                ' Re-bind the grid to the SP result so the row count matches and the key cols exist in the datasource
                ViewState("Customers") = dt1
                grdPropertyInfo.DataSource = dt1
                grdPropertyInfo.DataBind()


                Dim showChassis As Boolean = dt1.AsEnumerable().Any(Function(r) Not IsDBNull(r("ChassisNo")) AndAlso Not String.IsNullOrWhiteSpace(r("ChassisNo").ToString()))
                Dim showEngine As Boolean = dt1.AsEnumerable().Any(Function(r) Not IsDBNull(r("EngineNo")) AndAlso Not String.IsNullOrWhiteSpace(r("EngineNo").ToString()))

                Dim chassisCol As DataControlField = grdPropertyInfo.Columns.Cast(Of DataControlField)().FirstOrDefault(Function(c) c.AccessibleHeaderText = "ChassisNumber")
                Dim engineCol As DataControlField = grdPropertyInfo.Columns.Cast(Of DataControlField)().FirstOrDefault(Function(c) c.AccessibleHeaderText = "EngineNumber")

                If chassisCol IsNot Nothing Then chassisCol.Visible = showChassis
                If engineCol IsNot Nothing Then engineCol.Visible = showEngine


                ' === NEW: keep checkbox in sync ===
                If chkHeavyEquipment IsNot Nothing Then
                    chkHeavyEquipment.Checked = (showChassis OrElse showEngine)
                End If


                ' Push values from dt1 into the row controls
                For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                    If i >= dt1.Rows.Count Then Exit For

                    Dim row1 As GridViewRow = grdPropertyInfo.Rows(i)

                    Dim txtPropertyNo As TextBox = CType(row1.FindControl("txtPropertyNo"), TextBox)
                    Dim txtSerialNumber As TextBox = CType(row1.FindControl("txtSerialNoOfEquip"), TextBox)
                    Dim txtPIFloorLocation As TextBox = CType(row1.FindControl("txtPIFloorLocation"), TextBox)
                    Dim drpInstalledAtEquip As DropDownList = CType(row1.FindControl("drpInstalledAtEquip"), DropDownList)


                    ' ===== Chassis & Engine TEXTBOXES =====
                    Dim txtChassisNumber As TextBox = CType(row1.FindControl("txtChassisNumber"), TextBox)
                    Dim txtEngineNumber As TextBox = CType(row1.FindControl("txtEngineNumber"), TextBox)

                    Dim chassisNo As String = If(dt1.Columns.Contains("ChassisNo") AndAlso Not IsDBNull(dt1.Rows(i)("ChassisNo")), dt1.Rows(i)("ChassisNo").ToString(), "")
                    Dim engineNo As String = If(dt1.Columns.Contains("EngineNo") AndAlso Not IsDBNull(dt1.Rows(i)("EngineNo")), dt1.Rows(i)("EngineNo").ToString(), "")

                    If txtChassisNumber IsNot Nothing Then txtChassisNumber.Text = chassisNo
                    If txtEngineNumber IsNot Nothing Then txtEngineNumber.Text = engineNo



                    ' Values from SP columns
                    Dim propNo As String = If(dt1.Columns.Contains("PropertyNo") AndAlso Not IsDBNull(dt1.Rows(i)("PropertyNo")), dt1.Rows(i)("PropertyNo").ToString(), "")
                    Dim serialNo As String = If(dt1.Columns.Contains("SerialNo") AndAlso Not IsDBNull(dt1.Rows(i)("SerialNo")), dt1.Rows(i)("SerialNo").ToString(), "")
                    Dim loc As String = If(dt1.Columns.Contains("Location") AndAlso Not IsDBNull(dt1.Rows(i)("Location")), dt1.Rows(i)("Location").ToString(), "")
                    Dim installedAt As String = If(dt1.Columns.Contains("InstalledAt") AndAlso Not IsDBNull(dt1.Rows(i)("InstalledAt")), dt1.Rows(i)("InstalledAt").ToString().Trim(), "")
                    Dim buildingId As String = If(dt1.Columns.Contains("Buildingid") AndAlso Not IsDBNull(dt1.Rows(i)("Buildingid")), dt1.Rows(i)("Buildingid").ToString().Trim(), "")

                    If txtPropertyNo IsNot Nothing Then txtPropertyNo.Text = propNo
                    If txtSerialNumber IsNot Nothing Then txtSerialNumber.Text = serialNo
                    If txtPIFloorLocation IsNot Nothing Then txtPIFloorLocation.Text = loc

                    ' Installed At: try select by Text first (handles "N/A"/"Field"), then fallback to Value (Buildingid)
                    If drpInstalledAtEquip IsNot Nothing Then
                        drpInstalledAtEquip.ClearSelection()

                        Dim liByText As ListItem = Nothing
                        If installedAt <> "" Then liByText = drpInstalledAtEquip.Items.FindByText(installedAt)
                        If liByText IsNot Nothing Then
                            liByText.Selected = True
                        ElseIf buildingId <> "" Then
                            Dim liByVal As ListItem = drpInstalledAtEquip.Items.FindByValue(buildingId)
                            If liByVal IsNot Nothing Then liByVal.Selected = True
                        End If
                    End If
                Next
            End If






            'reset flag
            ViewState("CheckboxEvent") = False
        End If


        '========================
        ' SAVE: Generate property numbers using stored procedure
        '========================
        If btnSave.Text = "SAVE" Then
            Try
                If String.IsNullOrEmpty(hdnGAId.Value) Then
                    hdnGAId.Value = ddGlAccount.SelectedValue
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
                            Dim txtSerialNumber As TextBox = CType(row1.FindControl("txtSerialNoOfEquip"), TextBox)
                            Dim txtPIFloorLocation As TextBox = CType(row1.FindControl("txtPIFloorLocation"), TextBox)
                            Dim drpInstalledAtEquip As DropDownList = CType(row1.FindControl("drpInstalledAtEquip"), DropDownList)
                            Dim txtChassisNumber As TextBox = CType(row1.FindControl("txtChassisNumber"), TextBox)
                            Dim txtEngineNumber As TextBox = CType(row1.FindControl("txtEngineNumber"), TextBox)

                            ' Clear other fields (check if controls exist)
                            If txtSerialNumber IsNot Nothing Then txtSerialNumber.Text = String.Empty
                            If txtPIFloorLocation IsNot Nothing Then txtPIFloorLocation.Text = String.Empty
                            If drpInstalledAtEquip IsNot Nothing Then
                                drpInstalledAtEquip.ClearSelection()
                            End If
                            If txtChassisNumber IsNot Nothing Then txtChassisNumber.Text = String.Empty
                            If txtEngineNumber IsNot Nothing Then txtEngineNumber.Text = String.Empty

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

                        ' Optional: Show success message
                        ' MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, 
                        '     "Property numbers generated successfully.")
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
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1,
                "Please enter a quantity greater than 0.")
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


        If btnSave.Text = "EDIT" Then
            DisableGridInputs()
        End If

        If btnSave.Text = "UPDATE" Then
            EnableGridInputs()
        End If
        ModalPopupExtender2.Show()

    End Sub



    Private Function CreatePropertyInfoTable(rowCount As Integer) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Property_ID", GetType(Long))     ' <-- required by DataKeyNames
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("InstalledAt", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("ChassisNo", GetType(String))   ' NEW
        dt.Columns.Add("EngineNo", GetType(String))    ' NEW

        For i As Integer = 1 To rowCount
            Dim r = dt.NewRow()
            r("Property_ID") = DBNull.Value   ' or 0L
            r("PropertyNo") = DBNull.Value
            r("PropertyDetai_ID") = DBNull.Value
            r("SerialNo") = DBNull.Value
            r("InstalledAt") = DBNull.Value
            r("Location") = DBNull.Value
            r("ChassisNo") = DBNull.Value     ' NEW
            r("EngineNo") = DBNull.Value      ' NEW
            dt.Rows.Add(r)
        Next
        Return dt
    End Function



    Protected Sub BindGrid()
        Dim src As DataTable = TryCast(ViewState("Customers"), DataTable)
        If src Is Nothing Then
            src = CreatePropertyInfoTable(0)
            ViewState("Customers") = src
        End If

        grdPropertyInfo.DataSource = src
        grdPropertyInfo.DataBind()

        ' === Check for chassis & engine values ===
        Dim showChassis As Boolean = src.AsEnumerable().Any(Function(r) Not IsDBNull(r("ChassisNo")) AndAlso Not String.IsNullOrWhiteSpace(r("ChassisNo").ToString()))
        Dim showEngine As Boolean = src.AsEnumerable().Any(Function(r) Not IsDBNull(r("EngineNo")) AndAlso Not String.IsNullOrWhiteSpace(r("EngineNo").ToString()))

        ' Find column by header or index
        Dim chassisCol As DataControlField = grdPropertyInfo.Columns.Cast(Of DataControlField)().FirstOrDefault(Function(c) c.AccessibleHeaderText = "ChassisNumber")
        Dim engineCol As DataControlField = grdPropertyInfo.Columns.Cast(Of DataControlField)().FirstOrDefault(Function(c) c.AccessibleHeaderText = "EngineNumber")

        If chassisCol IsNot Nothing Then chassisCol.Visible = showChassis
        If engineCol IsNot Nothing Then engineCol.Visible = showEngine

        ' Reflect column visibility to the checkbox (checked if any heavy-equipment fields are present)
        If chkHeavyEquipment IsNot Nothing Then
            chkHeavyEquipment.Checked = (showChassis OrElse showEngine)
        End If


    End Sub



    Protected Sub chkHeavyEquipment_CheckedChanged(sender As Object, e As EventArgs) Handles chkHeavyEquipment.CheckedChanged
        ' Locate the chassis & engine columns
        Dim chassisCol As DataControlField = grdPropertyInfo.Columns.Cast(Of DataControlField)().FirstOrDefault(Function(c) c.AccessibleHeaderText = "ChassisNumber")
        Dim engineCol As DataControlField = grdPropertyInfo.Columns.Cast(Of DataControlField)().FirstOrDefault(Function(c) c.AccessibleHeaderText = "EngineNumber")

        If chassisCol IsNot Nothing Then chassisCol.Visible = chkHeavyEquipment.Checked
        If engineCol IsNot Nothing Then engineCol.Visible = chkHeavyEquipment.Checked

        ' Keep modal open on postback
        ModalPopupExtender2.Show()
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
    Protected Sub txtEMarketValue_TextChanged(sender As Object, e As EventArgs) Handles txtEMarketValue.TextChanged

    End Sub
    Protected Sub drpInstalledAtBuilding_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpInstalledAtBuilding.SelectedIndexChanged

    End Sub
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ModalPopupExtender1.Hide()
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs)
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else

            IsEnabledTextBoxes(True)
            btnSave.Text = "UPDATE"
            btnSave.Enabled = True
        End If
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
    Protected Sub drpInstalledAtMac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim drp As DropDownList
        Dim text As TextBox
        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtEquip"), DropDownList)
            If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = True
                text.Text = ""
            Else
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = False

                Dim drp1 As DropDownList
                drp1 = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtEquip"), DropDownList)

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("select (case when Address IS NULL then '' else Address end) + " _
                                             & " (case when Barangay IS NULL then  '' else ', ' + Barangay end) + " _
                                             & "  (case when Area1 IS NULL then  '' else  ', ' + Area1 end) " _
                                             & "  as Adress from AMS.TbBuilding_Dtl where BuildingId=" & drp1.SelectedValue & "", CommandType.Text)
                If dt.Rows.Count > 0 Then
                    text.Text = dt.Rows(0).Item(0)
                Else
                    text.Text = ""
                End If
            End If
        Next
        ModalPopupExtender2.Show()
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


    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        ' Declare the checkbox and get the row
        Dim cb1 As CheckBox = CType(sender, CheckBox)
        Dim row As GridViewRow = CType(cb1.NamingContainer, GridViewRow)

        ' Get the index of the row where the checkbox was clicked
        Dim rowIndex As Integer = row.RowIndex

        ' Check if no checkbox is checked
        Dim noCheckboxChecked As Boolean = True ' Assume no checkbox is checked initially

        ' Iterate over all rows in the GridView to check if any checkbox is checked
        For Each row1 As GridViewRow In grdLedger1.Rows
            Dim cb2 As CheckBox = CType(row1.Cells(0).FindControl("cbInspection"), CheckBox)
            If cb2.Checked Then
                noCheckboxChecked = False
                Exit For ' Exit the loop once we find a checked checkbox
            End If
        Next

        ' If no checkbox is checked, call ClearTextboxes() and exit the method
        If noCheckboxChecked Then
            ClearTextboxes()
            btnSave.Text = "SAVE"
            txtEquipmentQuantity.Enabled = True
            Return ' Exit the method if no checkbox is checked
        End If

        ' If a checkbox is checked, proceed with the rest of the logic
        ClearTextboxes()
        IsEnabledTextBoxes(True)
        btnSave.Text = "EDIT"
        txtEquipmentQuantity.Enabled = False
        ViewState("CheckboxEvent") = True



        ' Get the Property_ID from the DataKeys collection
        Dim propertyId As String = "0"
        If grdLedger1.DataKeys IsNot Nothing AndAlso grdLedger1.DataKeys.Count > rowIndex Then
            ' Safely get Property_ID from the DataKeys collection
            If grdLedger1.DataKeys(rowIndex)("Property_ID") IsNot Nothing Then
                propertyId = grdLedger1.DataKeys(rowIndex)("Property_ID").ToString()
                Session("Ledger_ID") = grdLedger1.DataKeys(rowIndex)("Ledger_ID").ToString()
                AddTrace("Ledger_ID: " & Session("Ledger_ID"))
            End If
        End If

        ' Log the retrieved propertyId for debugging purposes
        AddTrace("Property_ID: " & propertyId)

        ' Now proceed to execute the stored procedure with the correct propertyId
        AddTrace("Executing Stored Procedure: EXEC [AMS].[sp_View_Encoding_v2] 'OfficeEquipment','" & hdnItemNo.Value & "','" & propertyId & "'")

        ' Get the data from the stored procedure
        Dim dt1 As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_View_Encoding_v2] 'OfficeEquipment','" & hdnItemNo.Value & "','" & propertyId & "'", CommandType.Text)

        ' Use the specific row index and not a loop
        If dt1.Rows.Count > 0 Then
            ' Fetch the data for the clicked row
            txtEquipmentQuantity.Text = dt1.Rows(0).Item("DebitQty").ToString
            txtequipmentdesciption.Text = dt1.Rows(0).Item("Description").ToString
            txtequipmentwaranty.Text = dt1.Rows(0).Item("Warranty").ToString
            txtequipmentpowerinput.Text = dt1.Rows(0).Item("PowerInput").ToString
            txtequipmentdimension.Text = dt1.Rows(0).Item("Dimension").ToString
            txtequipmentmodel.Text = dt1.Rows(0).Item("Model").ToString
            lblequipmentbrand.Text = dt1.Rows(0).Item("Brand").ToString

            txtContractor.Text = dt1.Rows(0).Item("MaintenanceContractor").ToString
            txtContactPerson.Text = dt1.Rows(0).Item("MaintenanceContactPerson").ToString
            txtCellphoneNo.Text = dt1.Rows(0).Item("MaintenanceContactNo").ToString
            txtEAcqDate.Text = dt1.Rows(0).Item("Property_Date").ToString
            txtEMarketValue.Text = dt1.Rows(0).Item("MarketValue").ToString
            txtEAcqCost.Text = dt1.Rows(0).Item("Cost").ToString
            txtNoYears.Text = dt1.Rows(0).Item("NoYears").ToString
            txtDepreciatedRate.Text = dt1.Rows(0).Item("DepreciationRate").ToString
            txtUsefulLife.Text = dt1.Rows(0).Item("UsefulLife").ToString

            txtequipmentdepreciatedvalue.Text = dt1.Rows(0).Item("DepreciationValue").ToString
            txtSalvageValue.Text = dt1.Rows(0).Item("SalvageValue").ToString
            txtSpecification.Text = dt1.Rows(0).Item("Specification").ToString
            txtRemarks.Text = dt1.Rows(0).Item("Remarks").ToString

            ' Corrected this block to use dt1.Rows(0) since we're fetching only one row
            If IsDBNull(dt1.Rows(0).Item("Unit_ID")) Then
                'drpUnit.SelectedIndex = 0
            Else
                'drpUnit.SelectedValue = dt1.Rows(0).Item("Unit_ID").ToString()
            End If

            hf_EquipInfoId.Value = dt1.Rows(0).Item("EquipInfoId").ToString
            hf_EquipmentId.Value = dt1.Rows(0).Item("EquipmentId").ToString
            hf_PropertyDetai_ID.Value = dt1.Rows(0).Item("Property_Dtl_ID").ToString
            hf_Property_ID.Value = dt1.Rows(0).Item("Property_ID").ToString
            hf_Item_ID.Value = dt1.Rows(0).Item("Item_ID").ToString
        End If

        btnSave.Enabled = True
    End Sub

    Protected Sub ClearTextboxes()
        'drpUnit.SelectedIndex = 0
        Dim ctxtBoxes As TextBox() = {txtEquipmentQuantity, txtequipmentdesciption, txtequipmentwaranty, txtequipmentpowerinput, txtequipmentdimension, txtequipmentmodel, lblequipmentbrand,
            txtContractor, txtContactPerson, txtCellphoneNo, txtEAcqDate, txtEMarketValue, txtEAcqCost, txtNoYears, txtDepreciatedRate, txtUsefulLife,
            txtequipmentdepreciatedvalue, txtSalvageValue, txtDepreciationValue, txtSpecification, txtRemarks}

        For Each txtBoxes As TextBox In ctxtBoxes
            txtBoxes.Text = String.Empty
        Next

    End Sub

    Protected Sub IsEnabledTextBoxes(isEnabled As Boolean)

        Dim ctxtBoxes As TextBox() = {txtequipmentdesciption, txtequipmentwaranty, txtequipmentpowerinput, txtequipmentdimension, txtequipmentmodel, txtequipmentmodel,
                                        txtContractor, txtContactPerson, txtCellphoneNo, txtEAcqDate, txtEMarketValue, txtEAcqCost, txtNoYears, txtDepreciatedRate,
                                        txtequipmentdepreciatedvalue, txtSalvageValue, txtDepreciationValue, txtSpecification}

        For Each txtBoxes As TextBox In ctxtBoxes
            txtBoxes.Enabled = isEnabled
        Next

    End Sub

    Protected Sub grdLedger1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles grdLedger1.RowCreated

        If grdLedger1.HeaderRow IsNot Nothing AndAlso grdLedger1.Rows.Count > 0 Then
            If grdLedger1.Controls.Count > 0 AndAlso grdLedger1.Controls(0).Controls.Count > 0 Then
                ' Prevent duplicate custom header rows
                Dim headerAlreadyExists As Boolean = False
                For Each row As GridViewRow In grdLedger1.Controls(0).Controls
                    If row.RowType = DataControlRowType.Header AndAlso row.Cells(0).Text = "EQUIPMENT" Then
                        headerAlreadyExists = True
                        Exit For
                    End If
                Next

                If Not headerAlreadyExists Then

                    Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
                    Dim cell As New TableHeaderCell()
                    cell.Text = "EQUIPMENT"
                    cell.ColumnSpan = 6
                    row.Controls.Add(cell)

                    cell = New TableHeaderCell()
                    cell.ColumnSpan = 2
                    cell.Text = "DEBIT"
                    row.Controls.Add(cell)


                    cell = New TableHeaderCell()
                    cell.ColumnSpan = 2
                    cell.Text = "CREDIT"
                    row.Controls.Add(cell)


                    cell = New TableHeaderCell()
                    cell.ColumnSpan = 2
                    cell.Text = "BALANCE"
                    row.Controls.Add(cell)

                    row.BackColor = ColorTranslator.FromHtml("WHITE")
                    row.ForeColor = ColorTranslator.FromHtml("BLACK")
                    grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)
                End If
            End If
        End If
    End Sub

    Protected Sub btnAuthCancel_Click(sender As Object, e As EventArgs) Handles btnAuthCancel.Click
        Dim dt As DataTable
        If ViewState("Customers") IsNot Nothing Then
            dt = DirectCast(ViewState("Customers"), DataTable)
        Else
            Exit Sub
        End If

        ' Ensure the table has enough rows to match the grid (defensive)
        While dt.Rows.Count < grdPropertyInfo.Rows.Count
            dt.Rows.Add(dt.NewRow())
        End While

        For Each row As GridViewRow In grdPropertyInfo.Rows
            If row.RowType <> DataControlRowType.DataRow Then Continue For

            Dim idx As Integer = row.RowIndex
            If idx < 0 OrElse idx >= dt.Rows.Count Then Continue For

            Dim txtPropertyNo As TextBox = CType(row.FindControl("txtPropertyNo"), TextBox)
            Dim txtSerialNumber As TextBox = CType(row.FindControl("txtSerialNoOfEquip"), TextBox)
            Dim drpInstalledAt As DropDownList = CType(row.FindControl("drpInstalledAtEquip"), DropDownList)
            Dim txtPIFloorLocation As TextBox = CType(row.FindControl("txtPIFloorLocation"), TextBox)

            ' PropertyNo
            If dt.Columns.Contains("PropertyNo") AndAlso txtPropertyNo IsNot Nothing Then
                dt.Rows(idx)("PropertyNo") = txtPropertyNo.Text
            End If

            ' SerialNo
            If dt.Columns.Contains("SerialNo") AndAlso txtSerialNumber IsNot Nothing Then
                dt.Rows(idx)("SerialNo") = txtSerialNumber.Text
            End If

            ' InstalledAt (store the human-readable text if that column exists)
            If drpInstalledAt IsNot Nothing AndAlso drpInstalledAt.SelectedItem IsNot Nothing Then
                If dt.Columns.Contains("InstalledAt") Then
                    dt.Rows(idx)("InstalledAt") = drpInstalledAt.SelectedItem.Text
                End If
                ' Also store Buildingid when present (value)
                If dt.Columns.Contains("Buildingid") Then
                    Dim buildingId As Long
                    If Long.TryParse(drpInstalledAt.SelectedValue, buildingId) Then
                        dt.Rows(idx)("Buildingid") = buildingId
                    Else
                        ' If parsing fails, you can store DBNull instead of crashing
                        dt.Rows(idx)("Buildingid") = DBNull.Value
                    End If
                End If

            End If

            ' Location vs FloorLocation (use whichever column exists)
            Dim loc As String = If(txtPIFloorLocation IsNot Nothing, txtPIFloorLocation.Text, String.Empty)
            If dt.Columns.Contains("FloorLocation") Then
                dt.Rows(idx)("FloorLocation") = loc
            ElseIf dt.Columns.Contains("Location") Then
                dt.Rows(idx)("Location") = loc
            End If
        Next

        ViewState("Customers") = dt
        ModalPopupExtender2.Hide()
    End Sub



    Public Sub EnableGridInputs()
        For Each row As GridViewRow In grdPropertyInfo.Rows
            If row.RowType = DataControlRowType.DataRow Then

                Dim tbProperty As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)
                If tbProperty IsNot Nothing Then
                    tbProperty.ReadOnly = True
                    tbProperty.Enabled = False
                End If

                ' Serial No
                Dim tbSerial As TextBox = TryCast(row.FindControl("txtSerialNoOfEquip"), TextBox)
                If tbSerial IsNot Nothing Then
                    tbSerial.ReadOnly = False
                    tbSerial.Enabled = True
                End If

                ' Location
                Dim tbLocation As TextBox = TryCast(row.FindControl("txtPIFloorLocation"), TextBox)
                If tbLocation IsNot Nothing Then
                    tbLocation.ReadOnly = False
                    tbLocation.Enabled = True
                End If

                ' Installed At (dropdown)
                Dim ddlInstalled As DropDownList = TryCast(row.FindControl("drpInstalledAtEquip"), DropDownList)
                If ddlInstalled IsNot Nothing Then
                    ddlInstalled.Enabled = True
                End If
            End If
        Next
    End Sub

    Public Sub DisableGridInputs()
        For Each row As GridViewRow In grdPropertyInfo.Rows
            If row.RowType = DataControlRowType.DataRow Then


                Dim tbProperty As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)
                If tbProperty IsNot Nothing Then
                    tbProperty.ReadOnly = True
                    tbProperty.Enabled = False
                End If

                ' Serial No
                Dim tbSerial As TextBox = TryCast(row.FindControl("txtSerialNoOfEquip"), TextBox)
                If tbSerial IsNot Nothing Then
                    tbSerial.ReadOnly = True
                    tbSerial.Enabled = False
                End If

                ' Location
                Dim tbLocation As TextBox = TryCast(row.FindControl("txtPIFloorLocation"), TextBox)
                If tbLocation IsNot Nothing Then
                    tbLocation.ReadOnly = True
                    tbLocation.Enabled = False
                End If

                ' Installed At (dropdown)
                Dim ddlInstalled As DropDownList = TryCast(row.FindControl("drpInstalledAtEquip"), DropDownList)
                If ddlInstalled IsNot Nothing Then
                    ddlInstalled.Enabled = False
                End If

            End If
        Next
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
