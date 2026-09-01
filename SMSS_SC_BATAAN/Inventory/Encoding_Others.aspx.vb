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


Partial Class Inventory_Encoding_Others
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim counts As Integer = 0
    Dim objDerived As New DerivedDal


    Private Class TempPropertyDetail
        Public Property PropertyNo As String
        Public Property SerialNo As String
        Public Property FloorLocation As String
        Public Property RoomLocation As String
        Public Property PropertyDtl_ID As String
    End Class

    Private Function IsVehicleSubClass() As Boolean

        If drpSubClass.SelectedItem Is Nothing Then
            Return False
        End If

        Return drpSubClass.SelectedItem.Text.
        IndexOf(
            "Vehicle",
            StringComparison.OrdinalIgnoreCase
        ) >= 0

    End Function


    Private Function IsMilitarySubClass() As Boolean

        If drpSubClass.SelectedItem Is Nothing Then
            Return False
        End If

        Return drpSubClass.SelectedItem.Text.
        IndexOf(
            "Military",
            StringComparison.OrdinalIgnoreCase
        ) >= 0

    End Function


    Private Function IsGunCategory() As Boolean

        If ddCategory.SelectedItem Is Nothing Then
            Return False
        End If

        Return ddCategory.SelectedItem.Text.
        IndexOf(
            "Gun",
            StringComparison.OrdinalIgnoreCase
        ) >= 0

    End Function

    Private Sub Inventory_Encoding_Equipment_Load(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles Me.Load

        objx.GetAccessRight(
        Me.Session("@UserName"),
        Page
    )

        If objx.HasAccess = False Then
            Me.Page.Response.Redirect(
            "~/UnauthorizedAccess.aspx"
        )
        End If

        If Not Page.IsPostBack Then

            txtDate.Text =
            Date.Now.ToString("MM-dd-yyyy")

            Dim Classification As DataTable =
            objDerived.GetDataTable(
                "SELECT " &
                "    ClassificationId, " &
                "    ClassificationName " &
                "FROM dbo.tbl_Classification " &
                "WHERE ClassificationName LIKE 'Others%' " &
                "ORDER BY ClassificationName",
                CommandType.Text
            )

            ddClass.DataSource = Classification
            ddClass.DataTextField =
            "ClassificationName"
            ddClass.DataValueField =
            "ClassificationId"
            ddClass.DataBind()

            If Classification IsNot Nothing AndAlso
           Classification.Rows.Count > 0 Then

                ddClass.SelectedIndex = 0

                Session("ClassificationID") =
                ddClass.SelectedValue

            Else

                Session("ClassificationID") = "0"

            End If

            ddClass.AutoPostBack = True
            ddGlAccount.AutoPostBack = True
            drpSubClass.AutoPostBack = True
            drpName.AutoPostBack = True
            DrpVehicleName.AutoPostBack = True
            drpMilitaryEquipmentName.AutoPostBack = True

            Session("Item_ID") = 0

            lblClass.Text = "OTHERS"
            lblSubClass.Text = "INFORMATION"

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
            ddCategory.Enabled = True

            ddSubCategory.Items.Clear()
            ddSubCategory.Items.Insert(
            0,
            New ListItem("Select", "0")
        )
            ddSubCategory.Enabled = True

            hdnGAId.Value = "0"
            hdnItemNo.Value = "0"

            mvEquipment.ActiveViewIndex = 0

            loadEquipmentLedger()

            Session.Remove("TempPropertyList")

            AddTrace(
            "ClassificationID: " &
            Convert.ToString(
                Session("ClassificationID")
            )
        )

            AddTrace(
            "ddClass: " &
            Convert.ToString(
                ddClass.SelectedValue
            )
        )

        End If

    End Sub


    Public Function selectClassification()

        lblClass.Text = "OTHERS"

        If ddClass.SelectedValue Is Nothing OrElse
       ddClass.SelectedValue = "" Then

            Session("ClassificationID") = "0"

        Else

            Session("ClassificationID") =
            ddClass.SelectedValue

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
        ddCategory.Enabled = True

        ddSubCategory.Items.Clear()
        ddSubCategory.Items.Insert(
        0,
        New ListItem("Select", "0")
    )
        ddSubCategory.Enabled = True

        lblSubClass.Text = "INFORMATION"
        mvEquipment.ActiveViewIndex = 0

        hdnGAId.Value = "0"
        hdnItemNo.Value = "0"
        Session("Item_ID") = 0

        loadEquipmentLedger()

    End Function


    Private Sub LoadGLAccounts()

        ddGlAccount.Items.Clear()

        Dim classificationID As Integer = 0

        Integer.TryParse(
        Convert.ToString(
            Session("ClassificationID")
        ),
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

        Dim dtGA As DataTable =
        objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        If dtGA IsNot Nothing Then

            Dim dr As DataRow = dtGA.NewRow()

            dr("GA_ID") = 0
            dr("GA_Title") = "Select"

            dtGA.Rows.InsertAt(dr, 0)

            ddGlAccount.DataSource = dtGA
            ddGlAccount.DataTextField =
            "GA_Title"
            ddGlAccount.DataValueField =
            "GA_ID"
            ddGlAccount.DataBind()

        Else

            ddGlAccount.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

        End If

        ddGlAccount.Enabled = True


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
        Convert.ToString(
            Session("ClassificationID")
        ),
        classificationID
    )

        Integer.TryParse(
        Convert.ToString(
            ddGlAccount.SelectedValue
        ),
        gaID
    )

        If classificationID = 0 OrElse
       gaID = 0 Then

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

            Dim dr As DataRow =
            dtSubClass.NewRow()

            dr("SubClassificationID") = 0
            dr("SubClassificationName") =
            "No Subclass"

            dtSubClass.Rows.InsertAt(dr, 0)

            drpSubClass.DataSource =
            dtSubClass

            drpSubClass.DataTextField =
            "SubClassificationName"

            drpSubClass.DataValueField =
            "SubClassificationID"

            drpSubClass.DataBind()

        Else

            drpSubClass.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )

        End If

        drpSubClass.Enabled = True

    End Sub


    Public Function SelectSubClassification()

        If drpSubClass.SelectedValue Is Nothing OrElse
       drpSubClass.SelectedValue = "" OrElse
       drpSubClass.SelectedValue = "0" Then

            lblSubClass.Text = "INFORMATION"
            mvEquipment.ActiveViewIndex = 0

            Exit Function

        End If

        If drpSubClass.SelectedItem IsNot Nothing Then

            lblSubClass.Text =
            drpSubClass.SelectedItem.Text.
                ToUpper() &
            " INFORMATION"

        Else

            lblSubClass.Text = "INFORMATION"

        End If

        If IsVehicleSubClass() Then

            mvEquipment.ActiveViewIndex = 1

        ElseIf IsMilitarySubClass() AndAlso
           IsGunCategory() Then

            mvEquipment.ActiveViewIndex = 2

        Else

            mvEquipment.ActiveViewIndex = 0

        End If

    End Function


    Public Function SelectGAaccount()

        ddCategory.Items.Clear()

        Dim classificationID As Integer = 0
        Dim gaID As Integer = 0
        Dim subClassificationID As Integer = 0

        Integer.TryParse(
        Convert.ToString(
            Session("ClassificationID")
        ),
        classificationID
    )

        Integer.TryParse(
        Convert.ToString(
            ddGlAccount.SelectedValue
        ),
        gaID
    )

        Integer.TryParse(
        Convert.ToString(
            drpSubClass.SelectedValue
        ),
        subClassificationID
    )

        If classificationID = 0 OrElse
       gaID = 0 Then

            ddCategory.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            ddCategory.Enabled = True

            ddSubCategory.Items.Clear()
            ddSubCategory.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            ddSubCategory.Enabled = True

            Exit Function

        End If

        Dim sql As String =
        "SELECT DISTINCT " &
        "    ip.item_particular_id, " &
        "    ip.description " &
        "FROM AMS.item_particular AS ip " &
        "INNER JOIN dbo.tblclassmatrix AS cm " &
        "    ON cm.categoryid = ip.item_particular_id " &
        "WHERE cm.ClassificationID = " & classificationID & " " &
        "AND cm.GA_ID = " & gaID & " " &
        "AND cm.SubClassificationID = " & subClassificationID & " " &
        "ORDER BY ip.description"

        AddTrace(sql)

        Dim dt As DataTable =
        objDerived.GetDataTable(
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

        ddCategory.Enabled = True

        selectCatergory()

    End Function


    Public Function selectCatergory()

        ddSubCategory.Items.Clear()

        Dim categoryID As Integer = 0

        Integer.TryParse(
        Convert.ToString(
            ddCategory.SelectedValue
        ),
        categoryID
    )

        If categoryID = 0 Then

            ddSubCategory.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            ddSubCategory.Enabled = True
            Exit Function

        End If

        Dim subcategory As DataTable =
        objDerived.GetDataTable(
            "SELECT " &
            "    SubCategoryID, " &
            "    SubCat_Desc " &
            "FROM dbo.tbl_SubCategory " &
            "WHERE item_particular_id = " &
                categoryID & " " &
            "ORDER BY SubCat_Desc",
            CommandType.Text
        )

        If subcategory IsNot Nothing Then

            ddSubCategory.DataSource =
            subcategory

            ddSubCategory.DataTextField =
            "SubCat_Desc"

            ddSubCategory.DataValueField =
            "SubCategoryID"

            ddSubCategory.DataBind()

        End If

        ddSubCategory.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        ddSubCategory.Enabled = True

    End Function

    Private Sub ClearItemDesc()

        drpName.Items.Clear()
        drpName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )
        drpName.Enabled = True

        DrpVehicleName.Items.Clear()
        DrpVehicleName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )
        DrpVehicleName.Enabled = True

        drpMilitaryEquipmentName.Items.Clear()
        drpMilitaryEquipmentName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )
        drpMilitaryEquipmentName.Enabled = True

        Session("Item_ID") = 0

        hdnItemNo.Value = "0"

        If drpUnit.Items.Count > 0 Then
            drpUnit.SelectedIndex = 0
        End If

        If drpMilitaryEquipmentUnit.Items.Count > 0 Then
            drpMilitaryEquipmentUnit.SelectedIndex = 0
        End If

        btnSave.Enabled = False
        Button2.Enabled = False
        btnMilitaryEquipmentSave.Enabled = False

    End Sub



    Private Sub BindNameDropDown(
    ByVal targetDropDown As DropDownList,
    ByVal sourceTable As DataTable
)

        targetDropDown.Items.Clear()

        If sourceTable Is Nothing Then

            targetDropDown.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            targetDropDown.Enabled = True
            Exit Sub

        End If

        targetDropDown.DataSource =
        sourceTable.Copy()

        targetDropDown.DataTextField =
        "ItemDescription"

        targetDropDown.DataValueField =
        "Item_ID"

        targetDropDown.DataBind()

        targetDropDown.Enabled = True

    End Sub


    Private Sub LoadItemDesc()

        If ddGlAccount.SelectedValue Is Nothing OrElse
       ddGlAccount.SelectedValue = "" OrElse
       ddGlAccount.SelectedValue = "0" Then

            ClearItemDesc()
            Exit Sub

        End If

        If drpSubClass.SelectedValue Is Nothing OrElse
       drpSubClass.SelectedValue = "" OrElse
       drpSubClass.SelectedValue = "0" Then

            ClearItemDesc()
            Exit Sub

        End If

        Dim classificationID As Integer = 0
        Dim gaID As Integer = 0
        Dim subClassificationID As Integer = 0

        Integer.TryParse(
        Convert.ToString(
            Session("ClassificationID")
        ),
        classificationID
    )

        Integer.TryParse(
        Convert.ToString(
            ddGlAccount.SelectedValue
        ),
        gaID
    )

        Integer.TryParse(
        Convert.ToString(
            drpSubClass.SelectedValue
        ),
        subClassificationID
    )

        If classificationID = 0 OrElse
       gaID = 0 OrElse
       subClassificationID = 0 Then

            ClearItemDesc()
            Exit Sub

        End If

        Dim sql As String =
        "SELECT DISTINCT " &
        "    i.Item_ID, " &
        "    i.ItemCompleteDesc AS ItemDescription " &
        "FROM dbo.tbl_SubClassification AS sc " &
        "INNER JOIN dbo.m_item AS i " &
        "    ON sc.SubClassificationID = " &
             "i.SubClassificationID " &
        "INNER JOIN dbo.m_item_detail AS mid " &
        "    ON i.Item_ID = mid.Item_ID " &
        "WHERE sc.ClassificationID = " &
            classificationID & " " &
        "AND sc.GA_ID = " & gaID & " " &
        "AND sc.SubClassificationID = " &
            subClassificationID & " " &
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

        dtItemDesc.Rows.InsertAt(dr, 0)

        BindNameDropDown(
        drpName,
        dtItemDesc
    )

        BindNameDropDown(
        DrpVehicleName,
        dtItemDesc
    )

        BindNameDropDown(
        drpMilitaryEquipmentName,
        dtItemDesc
    )

        Session("Item_ID") = 0

        hdnItemNo.Value = "0"
        hdnGAId.Value =
        ddGlAccount.SelectedValue

        btnSave.Enabled = False
        Button2.Enabled = False
        btnMilitaryEquipmentSave.Enabled = False

        SelectSubClassification()

        AddTrace(
        "SubClassificationID: " &
        drpSubClass.SelectedValue
    )

    End Sub

    Protected Sub ddGlAccount_SelectedIndexChanged(
    sender As Object,
    e As EventArgs
)

        SelectGAaccount()
        LoadSubClassifications()
        multiviewselected()

    End Sub
    Public Sub multiviewselected()

        SelectSubClassification()

        drpNamePopulate()

        loadEquipmentLedger()

    End Sub
    Public Sub drpNamePopulate()

        ClearItemDesc()

        If ddGlAccount.SelectedValue Is Nothing OrElse
       ddGlAccount.SelectedValue = "" OrElse
       ddGlAccount.SelectedValue = "0" Then

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

        Dim dr As DataRow = dtItemDesc.NewRow()

        dr("Item_ID") = 0
        dr("ItemDescription") = "Select"

        dtItemDesc.Rows.InsertAt(dr, 0)

        BindNameDropDown(
        drpName,
        dtItemDesc
    )

        BindNameDropDown(
        DrpVehicleName,
        dtItemDesc
    )

        BindNameDropDown(
        drpMilitaryEquipmentName,
        dtItemDesc
    )

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"
        hdnGAId.Value = ddGlAccount.SelectedValue

        btnSave.Enabled = False
        Button2.Enabled = False
        btnMilitaryEquipmentSave.Enabled = False

        AddTrace(
        "drpNamePopulate ClassificationID: " &
        classificationID
    )

        AddTrace(
        "drpNamePopulate GA_ID: " &
        gaID
    )

        AddTrace(
        "drpNamePopulate SubClassificationID: " &
        subClassificationID
    )

        AddTrace(
        "drpNamePopulate Item Count: " &
        Math.Max(dtItemDesc.Rows.Count - 1, 0)
    )

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

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Sub loadEquipmentList()
        Dim dtEquipments As New DataTable
        dtEquipments = objDerived.GetDataTable("exec [dbo].[SMSS_PropertyList] '" & gvsearchproperty.SelectedDataKey("item_particular_id") & "','" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        If dtEquipments.Rows.Count < 4 Then
            dtEquipments.Merge(createdatatable4A(3 - dtEquipments.Rows.Count))
        End If
        grdlistofEuipment.DataSource = dtEquipments
        grdlistofEuipment.DataBind()
        grdlistofEuipment.SelectedIndex = 0

    End Sub

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
        Me.mvledger.SetActiveView(Me.vwledger)

        Dim dtAccount As New DataTable
        hdnItemNo.Value = drpName.SelectedValue
        'If en

        If hdnItemNo.Value = "" Then
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & Session("Item_ID") & "' ", CommandType.Text)
        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
        End If

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()


        btnSave.Text = "SAVE"
        btnSave.Enabled = True


        hdnGAId.Value = ddGlAccount.SelectedValue
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
        Try
            loadEquipmentInformation()
            loadEquipmentLedger()
        Catch ex As Exception
        End Try
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
        loadEquipmentList()

        grdlistofEuipment.SelectedIndex = 0
        loadEquipmentInformation()
        loadEquipmentLedger()

    End Sub
    Protected Sub gvsearchproperty_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearchproperty, "Select$" + e.Row.RowIndex.ToString()))
        End If




    End Sub


    Protected Sub loadEquipmentInformation()
        Dim CYear As String = "CY" & Year(txtDate.Text)
        Dim itemid As String
        If gvsearchproperty.SelectedDataKey("Item_ID") Is Nothing Or IsDBNull(gvsearchproperty.SelectedDataKey("Item_ID")) Then

            itemid = "0"
        Else
            itemid = gvsearchproperty.SelectedDataKey("Item_ID")
        End If
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & " from dbo.m_item as a inner join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadEquipDTL()
        Else
            txtName.Text = dt.Rows(0).Item("Name").ToString
            txtothersdesciption.Text = dt.Rows(0).Item("description").ToString
            txtotherspowerinput.Text = ""
            txtothersdimension.Text = ""
            txtothersareacapacity.Text = ""
            txtothersmodel.Text = ""
            txtothersBrand.Text = ""
            txtSpecification.Text = ""
            txtotherswaranty.Text = ""
            txtSpecification.Text = ""
            txtEAcqDate.Text = Date.Now.ToString("MM/dd/yyyy")
            txtEAcqCost.Text = dt.Rows(0).Item(CYear).ToString
            txtEMarketValue.Text = dt.Rows(0).Item(CYear).ToString
            'Dim DA As DateTime
            'DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")
            txtNoYears.Text = "0"
            txtothersdepreciatedvalue.Text = FormatNumber(0, 2)
            lblequipmentdepreciatedRate.Text = "0"
            lblequipmentdepreciatedRate.ReadOnly = False

            txtUsefulLife.Text = ""
            txtSalvageValue.Text = FormatNumber(0, 2)
            Session("useful_life") = 0

        End If
    End Sub
    Protected Sub LoadEquipDTL()

        Dim textboxes As TextBox() = New TextBox() _
{
txtotherspowerinput, txtothersmodel, txtothersSerialNo, txtothersQuantity, txtothersBrand, txtSpecification,
txtotherswaranty, txtothersdimension, txtContractor, txtContactPerson,
txtCellphoneNo, txtEAcqDate, txtEAcqCost, txtDepreciatedRate, txtothersdepreciatedvalue,
txtEMarketValue, txtNoYears, txtUsefulLife, txtSalvageValue, txtSpecification
}

        ' Iterate through the array and clear the text in each textbox
        For Each textbox As TextBox In textboxes
            textbox.Text = ""
        Next


    End Sub


    Protected Sub LoadMilitaryEquipDTL()
        hdnItemNo.Value = ""
        hdnGAId.Value = ""

        'Optimize code
        Dim txtBoxes As TextBox() = {txtMilitaryEquipmentDescription, txtMilitaryEquipmentFrame, txtMilitaryEquipmentManufacturer, txtMilitaryEquipmentColor, txtMilitaryEquipmentCaliber, txtMilitaryEquipmentCapacityExtended, txtMilitaryEquipmentBarrel, txtMilitaryEquipmentSights}

        For Each txtBox As TextBox In txtBoxes
            txtBox.Text = ""
        Next

    End Sub

    Protected Sub drpSubClass_SelectedIndexChanged(
    sender As Object,
    e As EventArgs
)

        multiviewselected()

    End Sub
    Protected Sub ddCategory_SelectedIndexChanged(
    sender As Object,
    e As EventArgs
)

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


    Protected Sub btnMilitaryEquipmentSave_Click(sender As Object, e As EventArgs)


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



        If Not IsNumeric(txtMilitaryEquipmentDepRate.Text) Or Not IsNumeric(txtMilitaryEquipmentAcqCost.Text) Or Not IsNumeric(txtMilitaryEquipmentDepValue.Text) Or Not IsNumeric(txtMilitaryEquipmentSalvageValue.Text) Or Not IsNumeric(txtMilitaryEquipmentMarketValue.Text) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
        Else
            Dim Prop_Hdr As New t_property_hdr
            With Prop_Hdr
                '.Property_ID = Property_ID
                .Property_Date = txtMilitaryEquipmentAcqDate.Text
                .Issuance = 0
                .Remarks = txtRemarks.Text
                .Emp_ID = 0
                .F_ID = 1
                .AIRDtl_ID = 0
                .deptid = 0
                .isDonated = False
                .GA_ID = ddGlAccount.SelectedValue
                .DonationRemarks = ""
                .Qty = txtMilitaryEquipmentQuantity.Text
                .Balance = txtMilitaryEquipmentQuantity.Text
                .Cost = CType(txtMilitaryEquipmentAcqCost.Text, Decimal)
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
                    .InspectionDate = txtMilitaryEquipmentAcqDate.Text
                    .F_ID = 1
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                    .Barcode = " "
                    .Amount = CType(txtMilitaryEquipmentAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    .Details = ""
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .AccountablePerson = ""
                    .Function_ID = 86
                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = Prop_Dtl.save()

                objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtMilitaryEquipmentMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)



                Dim info_id As Integer
                Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info

                With objEquipInfo
                    .EquipInfoId = 0
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = PropDtl_ID
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                    .Name = drpMilitaryEquipmentName.SelectedItem.Text
                    .Description = txtMilitaryEquipmentDescription.Text
                    .manufacturer = txtMilitaryEquipmentManufacturer.Text
                    .caliber = txtMilitaryEquipmentCaliber.Text
                    .barrel = txtMilitaryEquipmentBarrel.Text
                    .frame = txtMilitaryEquipmentFrame.Text
                    .color = txtMilitaryEquipmentColor.Text
                    .capacity = txtMilitaryEquipmentCapacityExtended.Text
                    .sights = txtMilitaryEquipmentSights.Text
                    .DepreciationRate = 0
                    .DepreciationValue = 0
                    .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                    .RoomLocation = ""
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    'CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).SelectedItem.value
                    .AccountablePerson = ""
                    .SalvageValue = txtMilitaryEquipmentSalvageValue.Text
                    .Property_ID = PropHdr_ID
                End With
                AddTrace("TbEquipment_Info PropHdr_ID: " & PropHdr_ID)


                info_id = objEquipInfo.save()
                objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

                Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details
                With objEquipDtl
                    .EquipmentId = 0
                    .EquipInfoId = info_id
                    .Property_Dtl_ID = PropDtl_ID
                    .MarketValue = txtMilitaryEquipmentMarketValue.Text
                    .Condition = ""
                    .Status = "Accepted"
                    .Property_ID = PropHdr_ID
                    ' .WarehouseID = drpEquipmentWarehouse.selectedvalue
                    Dim drp As DropDownList
                    drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtMac"), DropDownList)
                    .BuildingId = drp.SelectedValue

                End With
                AddTrace("TbEquipment_Details PropHdr_ID: " & PropHdr_ID)

                objEquipDtl.save()


                Dim Prop_Ledger As New t_PropertyLedger

                With Prop_Ledger
                    .Ledger_ID = 0
                    .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                    .Trans_Type = "Manual Entry"
                    .dDate = txtMilitaryEquipmentAcqDate.Text
                    .Ref = ""
                    .AccountablePerson = ""
                    .Department = 0
                    .Position = ""
                    .AcceptedBy = ""
                    .InspectedBy = ""
                    .Item_ID = hdnItemNo.Value
                    .DebitQty = txtMilitaryEquipmentQuantity.Text
                    .DebitCost = CType(txtMilitaryEquipmentAcqCost.Text, Decimal) * txtMilitaryEquipmentQuantity.Text
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
                Convert.ToInt32(txtothersQuantity.Text)

                    Dim EquipmentAcquisitionCost As Decimal =
                CType(txtEAcqCost.Text.Replace(",", ""), Decimal)

                    Dim NewEquipmentCost As Decimal =
                EquipmentAcquisitionCost * NewEquipmentQty

                    .BalanceQty = Eqty + NewEquipmentQty
                    .BalanceCost = Eqbalance + NewEquipmentCost

                    .Property_ID = PropHdr_ID
                End With
                AddTrace("TbEquipment_Details PropHdr_ID: " & PropHdr_ID)

                Prop_Ledger.save()
            Next





            btnMilitaryEquipmentSave.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            multiviewselected()
            'loadEquipmentList()
            'loadEquipmentInformation()
            loadEquipmentInformation_from_drpMilitaryName()
            loadEquipmentLedger()
        End If
        'End If


    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        If btnSave.Text = "SAVE" Then
            SAVE()

            loadEquipmentLedger()
        ElseIf btnSave.Text = "EDIT" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            ModalPopupExtender1.Show()
        ElseIf btnSave.Text = "UPDATE" Then
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



        If String.IsNullOrWhiteSpace(txtothersdesciption.Text) Then
            missingFields.Add("Description")
        End If

        If String.IsNullOrWhiteSpace(txtothersQuantity.Text) Then
            missingFields.Add("Quantity")
        End If

        If String.IsNullOrWhiteSpace(txtRemarks.Text) Then
            missingFields.Add("Remarks")
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
                .GA_ID = ddGlAccount.SelectedValue
                .DonationRemarks = ""
                .Qty = txtothersQuantity.Text
                .Balance = txtothersQuantity.Text
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

                Dim tbLocation As TextBox = TryCast(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox)
                Dim ddlInstalled As DropDownList = TryCast(grdPropertyInfo.Rows(i).FindControl("drpInstalledAtEquip"), DropDownList)
                ' installed-at text (fall back to value if needed)
                Dim installedAtText As String = ""
                If ddlInstalled IsNot Nothing Then
                    installedAtText = If(ddlInstalled.SelectedItem IsNot Nothing, ddlInstalled.SelectedItem.Text, ddlInstalled.SelectedValue)
                End If

                ' market value (safe parse, default 0)
                Dim marketValue As Decimal = 0D
                Dim mvRaw As String = If(txtEMarketValue IsNot Nothing, txtEMarketValue.Text, String.Empty)
                If Not String.IsNullOrWhiteSpace(mvRaw) Then Decimal.TryParse(mvRaw.Replace(",", ""), marketValue)

                Dim Prop_Dtl As New t_property_dtl
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
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                    .Barcode = " "
                    .Amount = CType(txtEAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    .Details = txtSpecification.Text
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .AccountablePerson = ""
                    .Function_ID = 86
                    .InstalledAt = installedAtText
                    .Location = If(tbLocation IsNot Nothing, tbLocation.Text.Trim(), "")
                    .MarketValue = marketValue
                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = Prop_Dtl.save()

                ' --- BEGIN: use TbOthers_Info / TbOthers_Dtl instead of Equipment ---
                Dim info_id As Integer
                Dim objOthersInfo As New ConsolidatedPropertySaving.TbOthers_Info

                With objOthersInfo
                    .OthersInfoId = 0
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = PropDtl_ID
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
                    .Name = txtName.Text
                    .Description = txtothersdesciption.Text
                    .PowerInput = txtotherspowerinput.Text
                    .Dimension = txtothersdimension.Text
                    .AreaCapacity = txtothersareacapacity.Text
                    .Model = txtothersmodel.Text
                    .Warranty = txtotherswaranty.Text
                    .Specification = txtSpecification.Text
                    .DepreciationRate = txtDepreciatedRate.Text
                    Dim depreciatedValue As Decimal = 0D
                    If Not String.IsNullOrWhiteSpace(txtothersdepreciatedvalue.Text) Then
                        Decimal.TryParse(txtothersdepreciatedvalue.Text.Replace(",", ""), depreciatedValue)
                    End If
                    .DepreciationValue = depreciatedValue

                    .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text
                    .RoomLocation = CType(grdPropertyInfo.Rows(i).FindControl("drpInstalledAtEquip"), DropDownList).SelectedItem.Text
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .AccountablePerson = ""
                    .SalvageValue = txtSalvageValue.Text


                    Dim usefulLife As Long = 0
                    If Not String.IsNullOrEmpty(txtUsefulLife.Text) AndAlso Not Long.TryParse(txtUsefulLife.Text, usefulLife) Then
                        usefulLife = 0
                    End If
                    .UsefulLife = usefulLife
                    .Property_ID = PropHdr_ID
                End With
                AddTrace("TbOthers_Info PropHdr_ID: " & PropHdr_ID)

                info_id = objOthersInfo.save()
                objDerived.GetRecords("UPDATE AMS.TbOthers_Info SET Received_ID = 0, Received_Dtl_ID = 0, Item_ID = '" & hdnItemNo.Value & "'  WHERE OthersInfoId = '" & info_id & "'", CommandType.Text)
                objDerived.GetRecords(
                    "UPDATE AMS.TbOthers_Info SET " &
                    "Remarks = '" & txtRemarks.Text.Replace("'", "''") & "', " &
                    "Unit_ID = " & drpUnit.SelectedValue & ", " &
                    "Specification = CAST('" & txtSpecification.Text.Replace("'", "''") & "' AS VARCHAR(MAX)), " &
                    "Brand = '" & txtothersBrand.Text.Replace("'", "''") & "' " &
                    "WHERE OthersInfoId = " & info_id,
                    CommandType.Text
                )

                Dim objOthersDtl As New ConsolidatedPropertySaving.TbOthers_Details
                With objOthersDtl
                    .OthersId = 0
                    .OthersInfoId = info_id
                    .Property_Dtl_ID = PropDtl_ID

                    Dim marketValue1 As Decimal = 0
                    If Not String.IsNullOrEmpty(txtEMarketValue.Text) AndAlso Not Decimal.TryParse(txtEMarketValue.Text, marketValue1) Then
                        marketValue1 = 0
                    End If
                    .MarketValue = marketValue1
                    .Condition = ""

                    Dim location As String
                    If String.IsNullOrEmpty(txtothersColumn.Text) AndAlso String.IsNullOrEmpty(txtothersFloor.Text) AndAlso String.IsNullOrEmpty(txtothersRoom.Text) AndAlso String.IsNullOrEmpty(txtothersShelves.Text) AndAlso String.IsNullOrEmpty(txtothersRack.Text) AndAlso String.IsNullOrEmpty(txtothersBin.Text) Then
                        location = "Bay-" & txtothersBay.Text
                    ElseIf String.IsNullOrEmpty(txtothersBay.Text) AndAlso String.IsNullOrEmpty(txtothersFloor.Text) AndAlso String.IsNullOrEmpty(txtothersRoom.Text) AndAlso String.IsNullOrEmpty(txtothersShelves.Text) AndAlso String.IsNullOrEmpty(txtothersRack.Text) AndAlso String.IsNullOrEmpty(txtothersBin.Text) Then
                        location = "Column-" & txtothersColumn.Text
                    ElseIf String.IsNullOrEmpty(txtothersBay.Text) AndAlso String.IsNullOrEmpty(txtothersColumn.Text) AndAlso String.IsNullOrEmpty(txtothersRoom.Text) AndAlso String.IsNullOrEmpty(txtothersShelves.Text) AndAlso String.IsNullOrEmpty(txtothersRack.Text) AndAlso String.IsNullOrEmpty(txtothersBin.Text) Then
                        location = "Floor-" & txtothersFloor.Text
                    ElseIf String.IsNullOrEmpty(txtothersBay.Text) AndAlso String.IsNullOrEmpty(txtothersColumn.Text) AndAlso String.IsNullOrEmpty(txtothersFloor.Text) AndAlso String.IsNullOrEmpty(txtothersShelves.Text) AndAlso String.IsNullOrEmpty(txtothersRack.Text) AndAlso String.IsNullOrEmpty(txtothersBin.Text) Then
                        location = "Room-" & txtothersRoom.Text
                    ElseIf String.IsNullOrEmpty(txtothersBay.Text) AndAlso String.IsNullOrEmpty(txtothersColumn.Text) AndAlso String.IsNullOrEmpty(txtothersFloor.Text) AndAlso String.IsNullOrEmpty(txtothersRoom.Text) AndAlso String.IsNullOrEmpty(txtothersRack.Text) AndAlso String.IsNullOrEmpty(txtothersBin.Text) Then
                        location = "Shelves-" & txtothersShelves.Text
                    ElseIf String.IsNullOrEmpty(txtothersBay.Text) AndAlso String.IsNullOrEmpty(txtothersColumn.Text) AndAlso String.IsNullOrEmpty(txtothersFloor.Text) AndAlso String.IsNullOrEmpty(txtothersRoom.Text) AndAlso String.IsNullOrEmpty(txtothersShelves.Text) AndAlso String.IsNullOrEmpty(txtothersBin.Text) Then
                        location = "Rack-" & txtothersRack.Text
                    ElseIf String.IsNullOrEmpty(txtothersBay.Text) AndAlso String.IsNullOrEmpty(txtothersColumn.Text) AndAlso String.IsNullOrEmpty(txtothersFloor.Text) AndAlso String.IsNullOrEmpty(txtothersRoom.Text) AndAlso String.IsNullOrEmpty(txtothersShelves.Text) AndAlso String.IsNullOrEmpty(txtothersRack.Text) Then
                        location = "Bin-" & txtothersBin.Text
                    End If

                    .Location = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text
                    .Status = "Accepted"

                    Dim drp As DropDownList = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtEquip"), DropDownList)
                    If drp.SelectedItem.Text = "N/A" OrElse drp.SelectedItem.Text = "Field" Then
                        .BuildingId = 0
                    Else
                        .BuildingId = drp.SelectedValue
                    End If

                    .MaintenanceContactNo = txtContractor.Text
                    .MaintenanceContactPerson = txtContactPerson.Text
                    .MaintenanceContractor = txtCellphoneNo.Text
                    .Property_ID = PropHdr_ID

                End With
                AddTrace("TbOthers_Details PropHdr_ID: " & PropHdr_ID)
                objOthersDtl.save()



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
                .DebitQty = txtothersQuantity.Text
                .DebitCost = CType(txtEAcqCost.Text, Decimal) * txtothersQuantity.Text
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
                Convert.ToInt32(txtothersQuantity.Text)

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
        If txtothersdesciption.Text = "" Or txtUsefulLife.Text = "" Or txtDepreciatedRate.Text = "" Or txtEAcqCost.Text = "" Or txtothersdepreciatedvalue.Text = "" Or txtSalvageValue.Text = "" Or txtEMarketValue.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")

        Else
            If Not IsNumeric(txtDepreciatedRate.Text) Or Not IsNumeric(txtEAcqCost.Text) Or Not IsNumeric(txtothersdepreciatedvalue.Text) Or Not IsNumeric(txtSalvageValue.Text) Or Not IsNumeric(txtEMarketValue.Text) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
            Else

                AddTrace("Property_ID: " & Session("Property_ID"))
                AddTrace("OthersInfoId: " & Session("OthersInfoId"))

                'Try
                Dim objDerived As New DerivedDal
                objDerived.conStr = objDerived.DbaseConnect()

                objDerived.cmd.Parameters.AddWithValue("@OthersInfoId    ", hf_EquipInfoId.Value)
                objDerived.cmd.Parameters.AddWithValue("@PowerInput", txtotherspowerinput.Text)
                objDerived.cmd.Parameters.AddWithValue("@Dimension", txtothersdimension.Text)
                objDerived.cmd.Parameters.AddWithValue("@Model", txtothersmodel.Text)
                objDerived.cmd.Parameters.AddWithValue("@Brand", txtothersBrand.Text)
                objDerived.cmd.Parameters.AddWithValue("@Warranty", txtotherswaranty.Text)
                objDerived.cmd.Parameters.AddWithValue("@NoYears", txtNoYears.Text)
                objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", txtothersdepreciatedvalue.Text.Replace(",", ""))
                objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", txtDepreciatedRate.Text)
                objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtUsefulLife.Text)
                objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtSalvageValue.Text.Replace(",", ""))
                objDerived.cmd.Parameters.AddWithValue("@Specification", txtSpecification.Text)

                'objDerived.cmd.Parameters.AddWithValue("@EquipmentId", hf_EquipmentId.Value)
                objDerived.cmd.Parameters.AddWithValue("@MaintenanceContractor", txtContractor.Text)
                objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactPerson", txtContactPerson.Text)
                objDerived.cmd.Parameters.AddWithValue("@MaintenanceContactNo", txtCellphoneNo.Text)
                'objDerived.cmd.Parameters.AddWithValue("@Buildingid", drpInstalledAtBuilding.SelectedItem.Value)
                objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtEMarketValue.Text.Replace(",", ""))

                objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", hf_PropertyDetai_ID.Value)
                objDerived.cmd.Parameters.AddWithValue("@SerialNo", txtothersSerialNo.Text)

                objDerived.cmd.Parameters.AddWithValue("@Property_ID", Session("Property_ID"))
                objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtEAcqDate.Text)
                objDerived.cmd.Parameters.AddWithValue("@Cost", txtEAcqCost.Text.Replace(",", ""))
                objDerived.cmd.Parameters.AddWithValue("@Qty", txtothersQuantity.Text)

                objDerived.cmd.Parameters.AddWithValue("@Item_ID", hf_Item_ID.Value)
                objDerived.cmd.Parameters.AddWithValue("@Unit_ID", drpUnit.SelectedItem.Value)

                objDerived.Execute("AMS.sp_Edit_Others_Encoding", CommandType.StoredProcedure)

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
                        Dim quantity As Integer = Convert.ToInt32(txtothersQuantity.Text)
                        Dim Unit As String = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hf_Item_ID.Value & "'", CommandType.Text)
                        Dim overallDebitCost As Decimal = acquisitionCost * quantity

                        objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] " &
                      "SET DebitQty = '" & quantity & "', " &
                      "DebitCost = '" & overallDebitCost & "', " &
                      "DebitUnit = '" & Unit & "', " &
                      "BalanceQty = '" & quantity & "', " &
                      "BalanceCost = '" & overallDebitCost & "', " &
                      "BalanceUnit = '" & Unit & "' " &
                      "WHERE Ledger_ID = '" & LedgerID & "' ", CommandType.Text)


                    End If
                Next


                'Session("TempPropertyList")

                Dim tempTableDtlProperty As List(Of TempPropertyDetail) = CType(Session("TempPropertyList"), List(Of TempPropertyDetail))


                'SEPARATE SAVING FROM PROPERTY INFORMATION POPOUT GRID VIEW ONLY
                Dim iterate As Integer = 0
                For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1

                    Dim gvRow As GridViewRow = grdPropertyInfo.Rows(i)

                    Dim txtPropertyNo As TextBox = CType(gvRow.FindControl("txtPropertyNo"), TextBox)
                    Dim txtSerialNo As TextBox = CType(gvRow.FindControl("txtSerialNoOfEquip"), TextBox)
                    Dim txtPIFloorLocation As TextBox = CType(gvRow.FindControl("txtPIFloorLocation"), TextBox)
                    Dim drpInstalledAtEquip As DropDownList = CType(gvRow.FindControl("drpInstalledAtEquip"), DropDownList)

                    iterate += 1

                    Dim current As New TempPropertyDetail With {
                    .PropertyNo = txtPropertyNo.Text,
                    .SerialNo = txtSerialNo.Text,
                    .FloorLocation = If(txtPIFloorLocation IsNot Nothing, txtPIFloorLocation.Text, ""),
                    .RoomLocation = drpInstalledAtEquip.SelectedItem.Text
                }

                    If i < tempTableDtlProperty.Count Then
                        Dim original As TempPropertyDetail = tempTableDtlProperty(i)

                        '---------------================UPDATE ROW IF DIFFERENT FROM BEFORE=====---------------
                        objDerived.GetRecords("UPDATE [AMS].[TbOthers_Info] " &
                                                       "SET SerialNo = '" & current.SerialNo & "', " &
                                                       "FloorLocation = '" & current.FloorLocation & "', " &
                                                       "RoomLocation = '" & current.RoomLocation & "', " &
                                                       "Remarks = '" & txtRemarks.Text & "' " &
                                                       "WHERE Property_Dtl_ID = '" & original.PropertyDtl_ID & "' ", CommandType.Text)

                        objDerived.GetRecords("UPDATE [AMS].[TbOthers_Dtl] " &
                                                   "SET Location = '" & current.FloorLocation & "', " &
                                                   "MarketValue = '" & txtEMarketValue.Text & "' " &
                                                   "WHERE Property_Dtl_ID = '" & original.PropertyDtl_ID & "' ", CommandType.Text)

                        objDerived.GetRecords("UPDATE [AMS].[Property_Dtl] " &
                                                   "SET PropertyNo = '" & current.PropertyNo & "', " &
                                                   "SerialNo = '" & current.SerialNo & "', " &
                                                   "Amount = '" & CType(txtEAcqCost.Text, Decimal) & "', " &
                                                   "MarketValue = '" & txtEMarketValue.Text & "' " &
                                                   "WHERE PropertyDetai_ID = '" & original.PropertyDtl_ID & "' ", CommandType.Text)


                    Else '---------=============SAVING/INSERTING NEW ROW OF PROPERTY NO=========---------------

                        Dim Prop_Dtl As New t_property_dtl
                        With Prop_Dtl
                            .PropertyNo = txtPropertyNo.Text
                            .Property_ID = Session("Property_ID")
                            .Issued = False
                            .Repair = False
                            .Dispose = False
                            .DisposeDate = "1/1/1900"
                            .IsInspectionForDisposal = False
                            .InspectionDate = txtEAcqDate.Text
                            .F_ID = 1
                            .SerialNo = CType(grdPropertyInfo.Rows(iterate).FindControl("txtSerialNoOfEquip"), TextBox).Text
                            .Barcode = " "
                            .Amount = CType(txtEAcqCost.Text, Decimal)
                            .Status = "Manual Encode"
                            .Details = txtSpecification.Text
                            .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                            .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                            .AccountablePerson = ""
                            .Function_ID = 86
                        End With

                        Dim PropDtl_ID As Integer
                        PropDtl_ID = Prop_Dtl.save()

                        Dim info_id As Integer
                        Dim objOthersInfo As New ConsolidatedPropertySaving.TbOthers_Info

                        With objOthersInfo
                            .OthersInfoId = 0
                            .AIRDtl_ID = 0
                            .IsAccepted = True
                            .Property_Dtl_ID = PropDtl_ID
                            .SerialNo = txtSerialNo.Text
                            .Name = txtName.Text
                            .Description = txtothersdesciption.Text
                            .PowerInput = txtotherspowerinput.Text
                            .Dimension = txtothersdimension.Text
                            .AreaCapacity = txtothersareacapacity.Text
                            .Model = txtothersmodel.Text
                            .Warranty = txtotherswaranty.Text
                            .Specification = txtSpecification.Text
                            .DepreciationRate = txtDepreciatedRate.Text
                            Dim depreciatedValue As Decimal = 0D
                            If Not String.IsNullOrWhiteSpace(txtothersdepreciatedvalue.Text) Then
                                Decimal.TryParse(txtothersdepreciatedvalue.Text.Replace(",", ""), depreciatedValue)
                            End If
                            .DepreciationValue = depreciatedValue

                            .FloorLocation = txtPIFloorLocation.Text
                            .RoomLocation = drpInstalledAtEquip.SelectedItem.Text
                            .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                            .AccountablePerson = ""
                            .SalvageValue = txtSalvageValue.Text
                            .UsefulLife = txtUsefulLife.Text
                            .Property_ID = Session("Property_ID")
                        End With

                        info_id = objOthersInfo.save()

                        Dim objOthersDtl As New ConsolidatedPropertySaving.TbOthers_Details
                        With objOthersDtl
                            .OthersId = 0
                            .OthersInfoId = info_id
                            .Property_Dtl_ID = PropDtl_ID
                            .MarketValue = txtEMarketValue.Text
                            .Condition = ""
                            .Location = txtPIFloorLocation.Text
                            .Status = "Accepted"

                            If drpInstalledAtEquip.SelectedItem.Text = "N/A" Or drpInstalledAtEquip.SelectedItem.Text = "Field" Then
                                .BuildingId = 0
                            Else
                                .BuildingId = drpInstalledAtEquip.SelectedValue
                            End If

                            .MaintenanceContactNo = txtContractor.Text
                            .MaintenanceContactPerson = txtContactPerson.Text
                            .MaintenanceContractor = txtCellphoneNo.Text
                            .Property_ID = Session("Property_ID")
                        End With
                        objOthersDtl.save()

                    End If

                Next

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


    Protected Sub drpName_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("Item_ID") = drpName.SelectedValue

        loadEquipmentInformation_from_drpName()
        loadEquipmentLedger()
        loadUnit()
        loadUsefulLife()
    End Sub

    Protected Sub drpMilitaryEquipmentName_SelectedIndexChanged(sender As Object, e As EventArgs)
        loadEquipmentInformation_from_drpMilitaryName()
        loadEquipmentLedger()

    End Sub


    Protected Sub loadEquipmentInformation_from_drpMilitaryName()
        Dim CYear As String = "CY" & Year(txtDate.Text)
        Dim itemid As String

        loadwarehouse()
        LoadBuildings()
        LoadMilitaryEquipDTL()
        If drpMilitaryEquipmentName.Text = "" Then

            itemid = "0"
        Else
            itemid = drpMilitaryEquipmentName.SelectedValue
        End If

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadEquipDTL()
        Else

            hdnItemNo.Value = itemid
            hdnGAId.Value = ddGlAccount.SelectedValue
            txtMilitaryEquipmentDescription.Text = dt.Rows(0).Item("description").ToString
            txtMilitaryEquipmentFrame.Text = objDerived.GetValue("select e.Frame from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                           "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                           "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                           "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                           "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentManufacturer.Text = objDerived.GetValue("select e.Manufacturer from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                           "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                           "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                           "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                           "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentColor.Text = objDerived.GetValue("select e.Color from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                           "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                           "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                           "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                           "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentCaliber.Text = objDerived.GetValue("select e.Caliber from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                           "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                           "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                           "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                           "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentCapacityExtended.Text = objDerived.GetValue("select e.Capacity from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                           "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                           "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                           "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                           "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentBarrel.Text = objDerived.GetValue("select e.Barrel from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                           "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                           "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                           "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                           "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtMilitaryEquipmentSights.Text = objDerived.GetValue("select e.Sights from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                           "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                           "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                           "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                           "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)


            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("[AMS].[sp_View_Encoding] 'OfficeEquipment','" & itemid & "'", CommandType.Text)
            If dt1.Rows.Count > 0 Then

            End If



            drpUnit.Items.FindByValue(dt.Rows(0).Item(9)).Selected = True
            btnMilitaryEquipmentSave.Enabled = True
            btnMilitaryEquipmentCancel.Enabled = True

        End If
    End Sub


    Protected Sub loadEquipmentInformation_from_drpName()
        Dim CYear As String = "CY" & Year(txtDate.Text)
        Dim itemid As String

        loadwarehouse()
        LoadBuildings()

        If drpName.Text = "" Then

            itemid = "0"
        Else
            itemid = drpName.SelectedValue
        End If

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then
            LoadEquipDTL()
        Else

            hdnItemNo.Value = itemid
            hdnGAId.Value = ddGlAccount.SelectedValue
            txtName.Text = dt.Rows(0).Item("Name").ToString
            txtothersdesciption.Text = dt.Rows(0).Item("description").ToString

            txtEMarketValue.Text = dt.Rows(0).Item(CYear).ToString




            '    txtUsefulLife.Text = ""
            'txtSalvageValue.Text = FormatNumber(0, 2)
            'txtSalvageValue.Text = ""
            'Session("useful_life") = 0


            btnSave.Enabled = True
            btnCancel.Enabled = True
        End If
    End Sub

    Protected Sub OnDataBound(sender As Object, e As EventArgs)
    End Sub

    Protected Sub grdLedger1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType <> DataControlRowType.DataRow Then Exit Sub

        ' NEVER loop all rows here; operate only on the current row’s data item
        Dim drv = TryCast(e.Row.DataItem, DataRowView)
        If drv Is Nothing Then Exit Sub

        Dim cb As CheckBox = TryCast(e.Row.FindControl("cbInspection"), CheckBox)
        If cb Is Nothing Then Exit Sub

        Dim transType As String = Convert.ToString(drv("Trans_Type"))
        Dim firstWord As String = If(transType, "").Split(" "c)(0)

        If transType = "Purchase Order Delivered" OrElse firstWord = "Issuance" Then
            cb.Enabled = False
        End If

        ' optional: cosmetic zero→blank for this row only
        Dim zeroToBlankCols As Integer() = {9, 10, 11, 12} ' adjust if your column order differs
        For Each ix In zeroToBlankCols
            If ix < e.Row.Cells.Count Then
                If e.Row.Cells(ix).Text = "0" OrElse e.Row.Cells(ix).Text = "0.00" Then
                    e.Row.Cells(ix).Text = " "
                End If
            End If
        Next
    End Sub



    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        Dim dt As DataTable
        If ViewState("Customers") IsNot Nothing Then
            dt = DirectCast(ViewState("Customers"), DataTable)
        Else
            Exit Sub
        End If

        Dim tempList As List(Of TempPropertyDetail) = GetTempPropertyList()
        If Session("TempPropertyList") IsNot Nothing Then
            Session("TempPropertyList") = tempList
        Else
            tempList = New List(Of TempPropertyDetail)()
        End If

        For Each row As GridViewRow In grdPropertyInfo.Rows
            Dim txtPropertyNo As TextBox = CType(row.FindControl("txtPropertyNo"), TextBox)
            Dim txtSerialNumber As TextBox = CType(row.FindControl("txtSerialNoOfEquip"), TextBox)
            Dim drpInstalledAtMac As DropDownList = CType(row.FindControl("drpInstalledAtEquip"), DropDownList)
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

            If drpInstalledAtMac.SelectedValue Is Nothing Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select a Location where the property is installed at.")
                Exit Sub
            End If

            Dim newItem As New TempPropertyDetail With {
            .PropertyNo = txtPropertyNo.Text,
            .SerialNo = txtSerialNumber.Text,
            .FloorLocation = If(txtPIFloorLocation IsNot Nothing, txtPIFloorLocation.Text, ""),
            .RoomLocation = drpInstalledAtMac.SelectedItem.Text
        }

            tempList.Add(newItem)
        Next

        Session("TempPropertyList") = tempList
        ViewState("Customers") = dt
        ModalPopupExtender2.Hide()
    End Sub



    Protected Sub btnMilitaryEquipmentaddpropertyinfo_Click(sender As Object, e As EventArgs)
        Dim dt As New DataTable()
        ' dt.Columns.AddRange(New DataColumn(1) {New DataColumn("Name"), New DataColumn("Country")})
        ' dt = ViewState("Customers")
        If txtMilitaryEquipmentQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
        Else
            For i As Integer = 0 To txtMilitaryEquipmentQuantity.Text - 1
                dt.Rows.Add()
            Next
            ViewState("Customers") = dt
            Me.BindGrid()

            ModalPopupExtender2.Show()
        End If


    End Sub

    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drpInstalledAt As DropDownList = CType(e.Row.FindControl("drpInstalledAtEquip"), DropDownList)
            Dim txtPIFloorLocation As TextBox = CType(e.Row.FindControl("txtPIFloorLocation"), TextBox)
            Dim txtPropertyNo As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
            Dim txtSerial As TextBox = CType(e.Row.FindControl("txtSerialNoOfEquip"), TextBox)

            If drpInstalledAt IsNot Nothing Then
                ' Get buildings from database
                Dim query As String =
                "SELECT a.BuildingId, a.BuildingName + ' - ' + ISNULL(a.Address, '') AS Name " &
                "FROM ams.TbBuilding_Dtl AS a " &
                "INNER JOIN ams.Property_Dtl AS b ON a.Property_Dtl_ID = b.PropertyDetai_ID " &
                "ORDER BY a.BuildingName"

                drpInstalledAt.DataSource = objDerived.GetDataTable(query, CommandType.Text)
                drpInstalledAt.DataTextField = "Name"
                drpInstalledAt.DataValueField = "BuildingId"
                drpInstalledAt.DataBind()

                ' Add special non-database options
                drpInstalledAt.Items.Insert(0, New ListItem("Field", "0"))
                drpInstalledAt.Items.Insert(1, New ListItem("N/A", "-1"))

                ' Get current values from the DataItem
                Dim drv As DataRowView = TryCast(e.Row.DataItem, DataRowView)
                If drv IsNot Nothing Then
                    Dim installedAtText As String = ""
                    Dim buildingId As String = ""

                    ' Try to get InstalledAt text
                    If drv.DataView.Table.Columns.Contains("InstalledAt") AndAlso Not IsDBNull(drv("InstalledAt")) Then
                        installedAtText = Convert.ToString(drv("InstalledAt"))
                    End If

                    ' Try to get BuildingId
                    If drv.DataView.Table.Columns.Contains("BuildingId") AndAlso Not IsDBNull(drv("BuildingId")) Then
                        buildingId = Convert.ToString(drv("BuildingId"))
                    End If

                    ' Select the appropriate item
                    drpInstalledAt.ClearSelection()

                    If Not String.IsNullOrEmpty(installedAtText) Then
                        ' First try to select by text (for "Field" and "N/A")
                        Dim liByText As ListItem = drpInstalledAt.Items.FindByText(installedAtText)
                        If liByText IsNot Nothing Then
                            liByText.Selected = True
                        ElseIf Not String.IsNullOrEmpty(buildingId) AndAlso buildingId <> "0" AndAlso buildingId <> "-1" Then
                            ' Then try by BuildingId value
                            Dim liByVal As ListItem = drpInstalledAt.Items.FindByValue(buildingId)
                            If liByVal IsNot Nothing Then
                                liByVal.Selected = True
                            End If
                        End If
                    End If

                    ' Set Location text from FloorLocation
                    If drv.DataView.Table.Columns.Contains("FloorLocation") AndAlso Not IsDBNull(drv("FloorLocation")) Then
                        If txtPIFloorLocation IsNot Nothing Then
                            txtPIFloorLocation.Text = Convert.ToString(drv("FloorLocation"))
                        End If
                    End If

                    ' Set PropertyNo and SerialNo
                    If drv.DataView.Table.Columns.Contains("PropertyNo") AndAlso Not IsDBNull(drv("PropertyNo")) Then
                        If txtPropertyNo IsNot Nothing Then txtPropertyNo.Text = Convert.ToString(drv("PropertyNo"))
                    End If

                    If drv.DataView.Table.Columns.Contains("SerialNo") AndAlso Not IsDBNull(drv("SerialNo")) Then
                        If txtSerial IsNot Nothing Then txtSerial.Text = Convert.ToString(drv("SerialNo"))
                    End If
                End If
            End If

            ' If in EDIT mode, lock PropertyNo
            If String.Equals(btnSave.Text, "EDIT", StringComparison.OrdinalIgnoreCase) Then
                If txtPropertyNo IsNot Nothing Then txtPropertyNo.Enabled = False
            End If
        End If
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
        ' Are we editing existing?
        Dim isEdit As Boolean =
    String.Equals(Convert.ToString(btnSave.Text), "EDIT", StringComparison.OrdinalIgnoreCase) OrElse
    String.Equals(Convert.ToString(btnSave.Text), "UPDATE", StringComparison.OrdinalIgnoreCase)

        If isEdit Then
            ' Reuse what PopulatePropertyInfoFromLedger already cached
            If ViewState("Customers") Is Nothing Then
                ' Safety: if missing (rare), repopulate from ledger
                Dim ledId As Long
                If Long.TryParse(Convert.ToString(Session("Ledger_ID")), ledId) Then
                    PopulatePropertyInfoFromLedger(ledId)
                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Could not determine the selected ledger.")
                    Exit Sub
                End If
            End If

            ' Rebind (if needed) and disable PropertyNo during EDIT/UPDATE
            BindGrid()
            For Each row As GridViewRow In grdPropertyInfo.Rows
                Dim tb As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)
                If tb IsNot Nothing Then tb.Enabled = False
            Next

            ModalPopupExtender2.Show()
            Exit Sub
        End If

        ' NEW entry (SAVE): validate Quantity then create empty rows
        Dim n As Integer
        If Not Integer.TryParse(txtothersQuantity.Text, n) OrElse n <= 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid Quantity.")
            Exit Sub
        End If

        BindPropertyInfoGrid(n)

        ' ========================
        ' GENERATE PROPERTY NUMBERS USING STORED PROCEDURE
        ' ========================
        Try
            ' Ensure GA_ID is set
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

                        ' Clear other fields (check if controls exist)
                        If txtSerialNumber IsNot Nothing Then txtSerialNumber.Text = String.Empty
                        If txtPIFloorLocation IsNot Nothing Then txtPIFloorLocation.Text = String.Empty
                        If drpInstalledAtEquip IsNot Nothing Then
                            drpInstalledAtEquip.ClearSelection()
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

        ' In NEW mode, allow editing PropertyNo (though they're now pre-filled)
        For Each row As GridViewRow In grdPropertyInfo.Rows
            Dim tb As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)
            If tb IsNot Nothing Then
                tb.Enabled = True  ' Keep enabled so user can modify if needed
            End If
        Next

        ModalPopupExtender2.Show()
    End Sub

    Protected Sub BindGrid()
        grdPropertyInfo.DataSource = DirectCast(ViewState("Customers"), DataTable)
        grdPropertyInfo.DataBind()
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
    Protected Sub drpInstalledAtMac_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim dd As DropDownList = TryCast(sender, DropDownList)
        If dd Is Nothing Then Exit Sub
        Dim row As GridViewRow = TryCast(dd.NamingContainer, GridViewRow)
        If row Is Nothing Then Exit Sub

        Dim txtLoc As TextBox = CType(row.FindControl("txtPIFloorLocation"), TextBox)
        Dim selectedText As String = dd.SelectedItem.Text

        If selectedText = "N/A" OrElse selectedText = "Field" Then
            ' Enable manual location input
            If txtLoc IsNot Nothing Then
                txtLoc.Enabled = True
                txtLoc.Text = ""
            End If
        Else
            ' Disable manual input and auto-populate address from selected building
            If txtLoc IsNot Nothing Then
                txtLoc.Enabled = False

                ' Get building address
                Dim buildingId As Integer = CInt(dd.SelectedValue)
                If buildingId > 0 Then
                    Dim dt As DataTable = objDerived.GetDataTable(
                    "SELECT (ISNULL(Address,'') + " _
                    & " ISNULL(', ' + Barangay,'') + " _
                    & " ISNULL(', ' + Area1,'')) AS Address " _
                    & "FROM AMS.TbBuilding_Dtl WHERE BuildingId = " & buildingId,
                    CommandType.Text)

                    If dt.Rows.Count > 0 Then
                        txtLoc.Text = Convert.ToString(dt.Rows(0)("Address"))
                    Else
                        txtLoc.Text = ""
                    End If
                End If
            End If
        End If

        ModalPopupExtender2.Show()
    End Sub


    Protected Sub txtPropertyNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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

            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("SELECT b.SerialNo, b.PropertyNo, AMS.TbEquipment_Dtl.Buildingid, AMS.TbEquipment_Dtl.Location, AMS.TbEquipment_Dtl.EquipmentId " &
                                            " FROM AMS.Property as a INNER JOIN " &
                                            " AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID INNER JOIN " &
                                            " AMS.TbEquipment_Dtl INNER JOIN " &
                                            " AMS.TbEquipment_Info as c ON AMS.TbEquipment_Dtl.EquipInfoId = c.EquipInfoId ON b.SerialNo = c.SerialNo " &
                                            " where a.Item_ID=" & hdnItemNo.Value & "", CommandType.Text)

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

    ' Use the same SP as your reference and adapt the result into the
    ' ViewState("Customers") schema that grdPropertyInfo expects.
    Private Sub PopulatePropertyInfoFromLedger(ledgerId As Long)
        AddTrace("ledgerId: " & ledgerId)
        Dim dt As DataTable = objDerived.GetDataTable(
    "EXEC AMS.sp_GetPropertyDtl_ByLedger " & ledgerId, CommandType.Text)

        Dim dtMem As New DataTable()
        dtMem.Columns.Add("PropertyNo", GetType(String))
        dtMem.Columns.Add("SerialNo", GetType(String))
        dtMem.Columns.Add("InstalledAt", GetType(String))
        dtMem.Columns.Add("FloorLocation", GetType(String))
        dtMem.Columns.Add("BuildingId", GetType(Integer))  ' ADD THIS COLUMN

        Dim tempList As New List(Of TempPropertyDetail)()

        If dt IsNot Nothing Then
            For Each r As DataRow In dt.Rows
                Dim propertyDtlId As String =
            If(r.Table.Columns.Contains("PropertyDetai_ID") AndAlso Not IsDBNull(r("PropertyDetai_ID")),
               Convert.ToString(r("PropertyDetai_ID")), "")

                Dim propNo As String =
            If(r.Table.Columns.Contains("PropertyNo") AndAlso Not IsDBNull(r("PropertyNo")),
               Convert.ToString(r("PropertyNo")), "")

                Dim serial As String =
            If(r.Table.Columns.Contains("SerialNo") AndAlso Not IsDBNull(r("SerialNo")),
               Convert.ToString(r("SerialNo")), "")

                ' Get BuildingId (numeric)
                Dim buildingId As Integer = 0
                If r.Table.Columns.Contains("BuildingId") AndAlso Not IsDBNull(r("BuildingId")) Then
                    Integer.TryParse(Convert.ToString(r("BuildingId")), buildingId)
                End If

                ' Get InstalledAt text
                Dim installedAtText As String = ""
                If r.Table.Columns.Contains("InstalledAt") AndAlso Not IsDBNull(r("InstalledAt")) Then
                    installedAtText = Convert.ToString(r("InstalledAt"))
                End If

                Dim loc As String =
            If(r.Table.Columns.Contains("Location") AndAlso Not IsDBNull(r("Location")),
               Convert.ToString(r("Location")), "")

                Dim nr = dtMem.NewRow()
                nr("PropertyNo") = propNo
                nr("SerialNo") = serial
                nr("InstalledAt") = installedAtText  ' Store the text
                nr("FloorLocation") = loc
                nr("BuildingId") = buildingId        ' Store the ID
                dtMem.Rows.Add(nr)

                tempList.Add(New TempPropertyDetail With {
                .PropertyNo = propNo,
                .SerialNo = serial,
                .FloorLocation = loc,
                .RoomLocation = installedAtText,
                .PropertyDtl_ID = propertyDtlId
            })
            Next
        End If

        ViewState("Customers") = dtMem
        BindGrid()
        Session("TempPropertyList") = tempList
        ViewState("PropertyInfoDT") = dt
    End Sub


    Private Sub BindPropertyInfoGrid(rowCount As Integer)
        Dim dt As New DataTable()
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("InstalledAt", GetType(String))
        dt.Columns.Add("FloorLocation", GetType(String))
        dt.Columns.Add("BuildingId", GetType(Integer))  ' ADD THIS COLUMN

        For i As Integer = 1 To rowCount
            dt.Rows.Add("", "", "", "", 0)  ' Added 0 for BuildingId
        Next

        ViewState("Customers") = dt
        BindGrid()
    End Sub

    Protected Sub cbInspection_CheckedChanged(sender As Object, e As EventArgs)


        ' Identify the row that fired the event
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        If cb Is Nothing Then Exit Sub

        Dim row As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
        If row Is Nothing OrElse row.RowIndex < 0 Then Exit Sub

        ' Keep only one selected (avoid name clash with DataRow later)
        For Each gvRow As GridViewRow In grdLedger1.Rows
            If gvRow.RowType = DataControlRowType.DataRow AndAlso Not Object.ReferenceEquals(gvRow, row) Then
                Dim other = TryCast(gvRow.FindControl("cbInspection"), CheckBox)
                If other IsNot Nothing Then other.Checked = False
            End If
        Next

        ' --- Get keys safely (prefer DataKeys, fallback to hidden fields) ---
        Dim ledgerId As Long = 0
        Dim propertyId As Long = 0

        If grdLedger1.DataKeys IsNot Nothing AndAlso grdLedger1.DataKeys.Count > row.RowIndex Then
            Dim dk As DataKey = grdLedger1.DataKeys(row.RowIndex)
            Dim tmp As Long
            If dk IsNot Nothing Then
                If Long.TryParse(Convert.ToString(dk("Ledger_ID")), tmp) Then ledgerId = tmp
                If Long.TryParse(Convert.ToString(dk("Property_ID")), tmp) Then propertyId = tmp
            End If
        End If

        If ledgerId = 0 OrElse propertyId = 0 Then
            Dim hfL As HiddenField = TryCast(row.FindControl("hfLedgerId"), HiddenField)
            Dim hfP As HiddenField = TryCast(row.FindControl("hfPropertyId"), HiddenField)
            Dim tmp As Long
            If hfL IsNot Nothing AndAlso Long.TryParse(hfL.Value, tmp) Then ledgerId = tmp
            If hfL IsNot Nothing Then
                Dim tmp1 As Long
                If Long.TryParse(hfL.Value, tmp1) Then
                    ledgerId = tmp
                End If
            End If

            If hfP IsNot Nothing Then
                Dim tmp1 As Long
                If Long.TryParse(hfP.Value, tmp1) Then
                    propertyId = tmp
                End If
            End If

        End If

        If ledgerId = 0 Then Exit Sub
        Session("Ledger_ID") = ledgerId.ToString()


        ' Get the property ID from DataKeys
        Dim propertyId1 As String = grdLedger1.DataKeys(row.RowIndex)("Property_ID").ToString()
        AddTrace("Property_ID: " & propertyId1)

        ' --- Load the full record for this row ---
        AddTrace("EXEC [AMS].[sp_View_Encoding_v2] 'Others','" & hdnItemNo.Value & "','" & propertyId1 & "'")
        Dim dt As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_View_Encoding_v2] 'Others','" & hdnItemNo.Value & "','" & propertyId1 & "'", CommandType.Text)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Exit Sub
        Dim dr As DataRow = dt.Rows(0)

        ' --- Enter EDIT mode and map fields ---
        btnSave.Text = "EDIT"
        txtothersQuantity.Enabled = False
        IsEnabledTextBoxes(True)

        txtothersQuantity.Text = Convert.ToString(dr("DebitQty"))
        txtothersdesciption.Text = Convert.ToString(dr("Item_Desc"))
        txtotherswaranty.Text = Convert.ToString(dr("Warranty"))
        txtotherspowerinput.Text = Convert.ToString(dr("PowerInput"))
        txtothersdimension.Text = Convert.ToString(dr("Dimension"))
        txtothersmodel.Text = Convert.ToString(dr("Model"))
        txtothersBrand.Text = Convert.ToString(dr("Brand"))

        txtSpecification.Text = Convert.ToString(dr("Specification"))

        txtContractor.Text = Convert.ToString(dr("MaintenanceContractor"))
        txtContactPerson.Text = Convert.ToString(dr("MaintenanceContactPerson"))
        txtCellphoneNo.Text = Convert.ToString(dr("MaintenanceContactNo"))

        txtEAcqDate.Text = Convert.ToString(dr("Property_Date"))
        txtEMarketValue.Text = Convert.ToString(dr("MarketValue"))
        txtEAcqCost.Text = Convert.ToString(dr("Cost"))
        txtNoYears.Text = Convert.ToString(dr("NoYears"))
        txtDepreciatedRate.Text = Convert.ToString(dr("DepreciationRate"))
        txtUsefulLife.Text = Convert.ToString(dr("UsefulLife"))
        txtothersdepreciatedvalue.Text = Convert.ToString(dr("DepreciationValue"))
        txtSalvageValue.Text = Convert.ToString(dr("SalvageValue"))
        txtSpecification.Text = Convert.ToString(dr("Specification"))
        txtRemarks.Text = Convert.ToString(dr("Remarks"))
        'drpUnit.SelectedValue = Convert.ToString(dr("Unit_ID"))

        ' Hidden ids
        hf_EquipInfoId.Value = Convert.ToString(dr("OthersInfoId"))
        hf_EquipmentId.Value = Convert.ToString(dr("EquipmentId"))
        hf_PropertyDetai_ID.Value = Convert.ToString(dr("Property_Dtl_ID"))
        hf_Property_ID.Value = Convert.ToString(dr("Property_ID"))
        hf_Item_ID.Value = Convert.ToString(dr("Item_ID"))

        AddTrace("propertyId: " & propertyId)
        AddTrace("ledgerId: " & ledgerId)
        Session("Property_ID") = propertyId
        Session("OthersInfoId") = hf_EquipInfoId.Value
        ' Prefill the property-info modal rows
        PopulatePropertyInfoFromLedger(ledgerId)


        If cb IsNot Nothing AndAlso cb.Checked = False Then
            ' Reset UI to default "new" state
            ClearTextboxes()
            IsEnabledTextBoxes(True)
            btnSave.Text = "SAVE"
            txtothersQuantity.Enabled = True
            ViewState("CheckboxEvent") = True
        End If

        btnSave.Enabled = True
    End Sub

    Protected Sub ClearTextboxes()
        Dim ctxtBoxes As TextBox() = {txtothersQuantity, txtothersdesciption, txtotherswaranty, txtotherspowerinput, txtothersdimension, txtothersmodel, txtothersBrand, txtSpecification,
        txtContractor, txtContactPerson, txtCellphoneNo, txtEAcqDate, txtEMarketValue, txtEAcqCost, txtNoYears, txtDepreciatedRate, txtUsefulLife,
        txtothersdepreciatedvalue, txtSalvageValue, txtDepreciationValue, txtSpecification, txtRemarks}

        For Each txtBoxes As TextBox In ctxtBoxes
            txtBoxes.Text = String.Empty
        Next
        'drpUnit.SelectedIndex = 0
    End Sub

    Protected Sub IsEnabledTextBoxes(isEnabled As Boolean)

        Dim ctxtBoxes As TextBox() = {txtothersQuantity, txtothersdesciption, txtotherswaranty, txtotherspowerinput, txtothersdimension, txtothersmodel, txtothersBrand, txtSpecification,
                                txtContractor, txtContactPerson, txtCellphoneNo, txtEAcqDate, txtEMarketValue, txtEAcqCost, txtNoYears, txtDepreciatedRate,
                                txtothersdepreciatedvalue, txtSalvageValue, txtDepreciationValue, txtSpecification, txtRemarks}

        For Each txtBoxes As TextBox In ctxtBoxes
            txtBoxes.Enabled = isEnabled
        Next

        ' Change this line to respect the isEnabled parameter
        drpUnit.Enabled = isEnabled  ' <-- CHANGE THIS (was drpUnit.Enabled = False)
    End Sub

    Protected Sub grdLedger1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles grdLedger1.RowCreated

        If grdLedger1.HeaderRow IsNot Nothing AndAlso grdLedger1.Rows.Count > 0 Then
            If grdLedger1.Controls.Count > 0 AndAlso grdLedger1.Controls(0).Controls.Count > 0 Then
                ' Prevent duplicate custom header rows
                Dim headerAlreadyExists As Boolean = False
                For Each row As GridViewRow In grdLedger1.Controls(0).Controls
                    If row.RowType = DataControlRowType.Header AndAlso row.Cells(0).Text = "OTHERS" Then
                        headerAlreadyExists = True
                        Exit For
                    End If
                Next

                If Not headerAlreadyExists Then

                    Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
                    Dim cell As New TableHeaderCell()
                    cell.Text = "OTHERS"
                    cell.ColumnSpan = 4
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

        ' Loop through GridView rows and save the data
        For Each row As GridViewRow In grdPropertyInfo.Rows
            Dim txtPropertyNo As TextBox = CType(row.FindControl("txtPropertyNo"), TextBox)
            Dim txtSerialNumber As TextBox = CType(row.FindControl("txtSerialNoOfEquip"), TextBox)
            Dim drpInstalledAtMac As DropDownList = CType(row.FindControl("drpInstalledAtEquip"), DropDownList)
            Dim txtPIFloorLocation As TextBox = CType(row.FindControl("txtPIFloorLocation"), TextBox)


            ' Update DataTable with new values
            dt.Rows(row.RowIndex)("PropertyNo") = txtPropertyNo.Text
            dt.Rows(row.RowIndex)("SerialNo") = txtSerialNumber.Text
            dt.Rows(row.RowIndex)("InstalledAt") = drpInstalledAtMac.SelectedValue
            dt.Rows(row.RowIndex)("FloorLocation") = txtPIFloorLocation.Text
        Next

        ' Save back to ViewState
        ViewState("Customers") = dt


        ModalPopupExtender2.Hide()

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
