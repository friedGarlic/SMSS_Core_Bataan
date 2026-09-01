Imports System.Data
Imports System.Drawing


Partial Class Inventory_Encoding_Vehicle
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Private objMotorInfo As New ConsolidatedPropertySaving.TbMotor_Info
    Dim counts As Integer = 0
    Private objMotorDtl As New ConsolidatedPropertySaving.TbMotor_Dtl


    Private Class TempPropertyDetail
        Public Property PropertyNo As String
        Public Property SerialNo As String
        Public Property ChasisNo As String
        Public Property PlateNo As String
        Public Property MVfileNo As String
        Public Property MotorWeight As String

        Public Property ConSticker As String
        Public Property PropertyDtl_ID As String

    End Class

    Private Sub Inventory_Encoding_Vehicle_Load(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles Me.Load

        'objx.GetAccessRight(Me.Session("@UserName"), Page)
        'If objx.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If

        If Not Page.IsPostBack Then

            Dim classification As String = Convert.ToString(
            objDerived.GetValue(
                "SELECT ClassificationId " &
                "FROM dbo.tbl_Classification " &
                "WHERE ClassificationName LIKE 'Vehicle%'",
                CommandType.Text
            )
        )

            If String.IsNullOrWhiteSpace(classification) Then
                classification = "0"
            End If

            Session("ClassificationID") = classification
            Session("Item_ID") = 0

            selectClassification()
            loadEquipmentLedger()

            Session.Remove("TempPropertyList")

        End If
    End Sub
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT Unit_ID, Description FROM ams.m_Unit AS a ORDER BY CASE WHEN Description = '-' THEN 0 ELSE 1 END, Description;", CommandType.Text)
        ddVehicleUnit.DataSource = dt
        ddVehicleUnit.DataTextField = ("Description")
        ddVehicleUnit.DataValueField = ("Unit_ID")
        ddVehicleUnit.DataBind()

        Dim Unit_ID As Integer = objDerived.GetValue("SELECT Unit_ID FROM DBO.m_item WHERE Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        ddVehicleUnit.SelectedValue = Unit_ID

    End Sub


    Public Sub selectClassification()

        lblClass.Text = "Encoding of Vehicle"

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

        lblSubClass.Text = "VEHICLE INFORMATION"
        mvVehicle.ActiveViewIndex = 0

        hdnGAId.Value = "0"
        hdnItemNo.Value = "0"

        Session("Item_ID") = 0

    End Sub

    Protected Sub drpSubClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        hdnItemNo.Value = "0"
        Session("Item_ID") = 0

        SelectSubClassification()

        loadEquipmentLedger()
        LoadItemDesc()
        AddTrace(
        "drpSubClass: " &
        Convert.ToString(drpSubClass.SelectedValue)
    )

    End Sub

    Protected Sub ddGeneralAccount_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        hdnGAId.Value = If(
        String.IsNullOrWhiteSpace(ddGeneralAccount.SelectedValue),
        "0",
        ddGeneralAccount.SelectedValue
    )

        hdnItemNo.Value = "0"
        Session("Item_ID") = 0

        LoadSubClassifications()
        ClearItemDesc()

        ddCategory.Items.Clear()
        ddCategory.Items.Insert(
        0,
        New ListItem("Select", "0")
    )
        ddCategory.Enabled = True

        lblSubClass.Text = "VEHICLE INFORMATION"
        mvVehicle.ActiveViewIndex = 0

        LoadItemDesc()
        loadEquipmentLedger()

        AddTrace(
        "ddGeneralAccount: " &
        Convert.ToString(ddGeneralAccount.SelectedValue)
    )

    End Sub
    Public Sub SelectSubClassification()
        ddCategory.Items.Clear()

        If drpSubClass.SelectedValue Is Nothing OrElse
       drpSubClass.SelectedValue = "" OrElse
       drpSubClass.SelectedValue = "0" Then

            lblSubClass.Text = "VEHICLE INFORMATION"

            ddCategory.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            ddCategory.Enabled = True
            Exit Sub

        End If

        'If IsWatercraftSelected() Then
        '    mvVehicle.ActiveViewIndex = 1
        'Else
        '    mvVehicle.ActiveViewIndex = 0
        'End If

        mvVehicle.ActiveViewIndex = 0

        If drpSubClass.SelectedItem IsNot Nothing Then
            lblSubClass.Text =
            drpSubClass.SelectedItem.Text.ToUpper() &
            " INFORMATION"
        End If

        Dim classificationID As Integer = 0
        Dim gaID As Integer = 0
        Dim subClassificationID As Integer = 0

        Integer.TryParse(
        Convert.ToString(Session("ClassificationID")),
        classificationID
    )

        Integer.TryParse(
        Convert.ToString(ddGeneralAccount.SelectedValue),
        gaID
    )

        Integer.TryParse(
        Convert.ToString(drpSubClass.SelectedValue),
        subClassificationID
    )

        If classificationID = 0 OrElse
       gaID = 0 OrElse
       subClassificationID = 0 Then

            ddCategory.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            ddCategory.Enabled = True
            Exit Sub

        End If

        Dim sql As String =
        "SELECT DISTINCT " &
        "    ip.item_particular_id, " &
        "    ip.description " &
        "FROM AMS.item_particular AS ip " &
        "INNER JOIN dbo.tblclassmatrix AS cm " &
        "    ON cm.categoryid = ip.item_particular_id " &
        "WHERE cm.classificationid = " &
            classificationID & " " &
        "AND cm.GA_ID = " & gaID & " " &
        "AND cm.SubClassificationID = " &
            subClassificationID & " " &
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

        ddCategory.Enabled = True

    End Sub


    'load general account:
    Private Sub LoadGLAccounts()
        ddGeneralAccount.Items.Clear()

        Dim classificationID As Integer = 0

        Integer.TryParse(
        Convert.ToString(Session("ClassificationID")),
        classificationID
    )

        If classificationID = 0 Then

            ddGeneralAccount.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            ddGeneralAccount.Enabled = True
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

            ddGeneralAccount.DataSource = dt
            ddGeneralAccount.DataTextField = "GA_Title"
            ddGeneralAccount.DataValueField = "GA_ID"
            ddGeneralAccount.DataBind()

        Else

            ddGeneralAccount.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

        End If

        ddGeneralAccount.Enabled = True
    End Sub


    Private Sub LoadSubClassifications()
        drpSubClass.Items.Clear()

        If ddGeneralAccount.SelectedValue Is Nothing OrElse
       ddGeneralAccount.SelectedValue = "" OrElse
       ddGeneralAccount.SelectedValue = "0" Then

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
        ddGeneralAccount.SelectedValue,
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


    Private Function IsWatercraftSelected() As Boolean

        If drpSubClass.SelectedItem Is Nothing Then
            Return False
        End If

        Return drpSubClass.SelectedItem.Text.IndexOf(
        "Water",
        StringComparison.OrdinalIgnoreCase
    ) >= 0

    End Function

    Private Sub ClearItemDesc()

        DrpVehicleName.Items.Clear()
        DrpVehicleName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )
        DrpVehicleName.Enabled = True

        drpWatercraftName.Items.Clear()
        drpWatercraftName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )
        drpWatercraftName.Enabled = True

        hdnItemNo.Value = "0"
        Session("Item_ID") = 0

        If ddVehicleUnit.Items.Count > 0 Then
            ddVehicleUnit.SelectedIndex = 0
        End If



    End Sub


    Private Sub LoadItemDesc()

        ClearItemDesc()

        If ddGeneralAccount.SelectedValue Is Nothing OrElse
       ddGeneralAccount.SelectedValue = "" OrElse
       ddGeneralAccount.SelectedValue = "0" Then

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
        Convert.ToString(ddGeneralAccount.SelectedValue),
        gaID
    )

        Integer.TryParse(
        Convert.ToString(drpSubClass.SelectedValue),
        subClassificationID
    )

        If classificationID = 0 OrElse
       gaID = 0 Then

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

        Dim dtitemdesc As DataTable =
        objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        If dtitemdesc Is Nothing Then
            Exit Sub
        End If

        Dim dr As DataRow = dtitemdesc.NewRow()

        dr("Item_ID") = 0
        dr("ItemDescription") = "Select"

        dtitemdesc.Rows.InsertAt(dr, 0)

        DrpVehicleName.DataSource = dtitemdesc
        DrpVehicleName.DataTextField = "ItemDescription"
        DrpVehicleName.DataValueField = "Item_ID"
        DrpVehicleName.DataBind()
        DrpVehicleName.Enabled = True


        'If IsWatercraftSelected() Then

        '    ' mvVehicle.ActiveViewIndex = 1

        '    drpWatercraftName.DataSource = dtitemdesc
        '    drpWatercraftName.DataTextField = "ItemDescription"
        '    drpWatercraftName.DataValueField = "Item_ID"
        '    drpWatercraftName.DataBind()
        '    drpWatercraftName.Enabled = True

        'Else

        '    'mvVehicle.ActiveViewIndex = 0

        '    DrpVehicleName.DataSource = dtitemdesc
        '    DrpVehicleName.DataTextField = "ItemDescription"
        '    DrpVehicleName.DataValueField = "Item_ID"
        '    DrpVehicleName.DataBind()
        '    DrpVehicleName.Enabled = True

        'End If

        hdnGAId.Value = Convert.ToString(
        ddGeneralAccount.SelectedValue
    )

        hdnItemNo.Value = "0"
        Session("Item_ID") = 0

    End Sub


    Protected Sub ddCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        multiviewselected()
    End Sub

    Protected Sub drpWatercraftName_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If drpWatercraftName.SelectedValue Is Nothing OrElse
       drpWatercraftName.SelectedValue = "" OrElse
       drpWatercraftName.SelectedValue = "0" Then

            Session("Item_ID") = 0
            hdnItemNo.Value = "0"

            loadEquipmentLedger()
            Exit Sub

        End If

        Session("Item_ID") = drpWatercraftName.SelectedValue

        hdnItemNo.Value = drpWatercraftName.SelectedValue
        hdnGAId.Value = ddGeneralAccount.SelectedValue

        loadEquipmentInformation_from_drpName_Watercraft()

        'The Watercraft information function already
        'refreshes the equipment ledger.

    End Sub

    Public Sub multiviewselected()

        If drpSubClass.SelectedValue Is Nothing OrElse
       drpSubClass.SelectedValue = "" OrElse
       drpSubClass.SelectedValue = "0" Then

            mvVehicle.ActiveViewIndex = 0
            Exit Sub

        End If

        If IsWatercraftSelected() Then
            mvVehicle.ActiveViewIndex = 1
        Else
            mvVehicle.ActiveViewIndex = 0
        End If

        If ddGeneralAccount.SelectedValue IsNot Nothing AndAlso
       ddGeneralAccount.SelectedValue <> "" Then

            hdnGAId.Value = ddGeneralAccount.SelectedValue

        Else

            hdnGAId.Value = "0"

        End If

        If hdnItemNo.Value IsNot Nothing AndAlso
       hdnItemNo.Value <> "" AndAlso
       hdnItemNo.Value <> "0" Then

            loadEquipmentLedger()

        End If

    End Sub


    Protected Sub loadEquipmentInformation_from_drpName_Watercraft()
        Dim CYear As String = "CY" & Year(Date.Now.ToString)
        Dim itemid As String
        '   loadUnit()
        ' loadwarehouse()
        ' LoadBuildings()
        LoadEquipDTL()
        If drpWatercraftName.Text = "" Then

            itemid = "0"
        Else
            itemid = drpWatercraftName.SelectedValue
            txtWatercraftName.Text = drpWatercraftName.SelectedItem.Text
            txtWatercraftDescription.Text = drpWatercraftName.SelectedItem.Text
        End If


        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID inner join ams.Property as c on a.Item_ID = c.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then

            '  txtWatercraftName.Text = DrpWatercraftName.SelectedItem.text
            hdnItemNo.Value = itemid
            hdnGAId.Value = ddGeneralAccount.SelectedValue
        Else

            hdnItemNo.Value = itemid
            hdnGAId.Value = ddGeneralAccount.SelectedValue
            txtWatercraftName.Text = dt.Rows(0).Item("Name").ToString
            txtWatercraftDescription.Text = dt.Rows(0).Item("description").ToString
            txtWatercraftPowerInput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftPowerInput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftWarranty.Text = objDerived.GetValue("select e.Warranty from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftMake.Text = objDerived.GetValue("select e.VehicleMake from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftQuantity.Text = objDerived.GetValue("select count(e.VehicleMake) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftType.Text = objDerived.GetValue("select e.VehicleType from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftColor.Text = objDerived.GetValue("select e.VehicleColor from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtEAcqDate.Text = objDerived.GetValue("select convert(varchar,c.Property_Date,101) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftMarketValue.Text = objDerived.GetValue("select d.MarketValue from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftAcqCost.Text = objDerived.GetValue("select c.Cost from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftNoYears.Text = objDerived.GetValue("select e.NoofYears from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftDepRate.Text = objDerived.GetValue("select e.DepRate from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftUsefulLife.Text = objDerived.GetValue("select e.UsefulLife from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftDepValue.Text = objDerived.GetValue("select e.DepValue from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftSalvageValue.Text = objDerived.GetValue("select e.SalvageValue from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftMMSI.Text = objDerived.GetValue("select e.MMSI from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftCallSign.Text = objDerived.GetValue("select e.CallSign from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftImoNo.Text = objDerived.GetValue("select e.ImoNo from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftHullMaterial.Text = objDerived.GetValue("select e.HullMaterial from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftNoofMast.Text = objDerived.GetValue("select e.NoofMast from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftNoofDecks.Text = objDerived.GetValue("select e.NoofDecks from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftNoofDecks.Text = objDerived.GetValue("select e.NoofDecks from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftNoofEngine.Text = objDerived.GetValue("select e.NoofEngine from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftMainEngine.Text = objDerived.GetValue("select e.MainEngine from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)


            txtWatercraftHorsePower.Text = objDerived.GetValue("select e.HorsePower from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWaterCraftGRT.Text = objDerived.GetValue("select e.GRT from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftNRT.Text = objDerived.GetValue("select e.NRT from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftLOA.Text = objDerived.GetValue("select e.LOA from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftBreadth.Text = objDerived.GetValue("select e.Breadth from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWaterCraftCarryingCapacity.Text = objDerived.GetValue("select e.CarryingCapacity from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtWatercraftAcqDate.Text = objDerived.GetValue("SELECT AMS.Property.Property_Date FROM AMS.Property INNER JOIN " &
                                                             "dbo.m_item ON AMS.Property.Item_ID = dbo.m_item.Item_ID INNER JOIN " &
                                                             "AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID INNER JOIN " &
                                                             "AMS.TbMotor_Info ON AMS.Property_Dtl.PropertyDetai_ID = AMS.TbMotor_Info.Property_Dtl_ID " &
                                                             "WHERE dbo.m_item.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("[AMS].[sp_View_Encoding] 'Vehicle','" & itemid & "'", CommandType.Text)
            If dt1.Rows.Count > 0 Then
                lblItem_ID.Text = dt1.Rows(0).Item("item_ID").ToString
                lblProperty_ID.Text = dt1.Rows(0).Item("Property_ID").ToString
                lblPropertyDetai_ID.Text = dt1.Rows(0).Item("PropertyDetai_ID").ToString
                lblMotor_InfoId.Text = dt1.Rows(0).Item("Motor_InfoId").ToString
                lblMotorID.Text = dt1.Rows(0).Item("MotorID").ToString
            Else
                lblItem_ID.Text = ""
                lblProperty_ID.Text = ""
                lblPropertyDetai_ID.Text = ""
                lblMotor_InfoId.Text = ""
                lblMotorID.Text = ""
            End If

        End If
        btnWatercraftsave.Enabled = True
        loadEquipmentLedger()
    End Sub


    Protected Sub DrpVehicleName_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If DrpVehicleName.SelectedValue Is Nothing OrElse
       DrpVehicleName.SelectedValue = "" OrElse
       DrpVehicleName.SelectedValue = "0" Then

            Session("Item_ID") = 0
            hdnItemNo.Value = "0"

            If ddVehicleUnit.Items.Count > 0 Then
                ddVehicleUnit.SelectedIndex = 0
            End If

            loadEquipmentLedger()
            Exit Sub

        End If

        Session("Item_ID") = DrpVehicleName.SelectedValue
        AddTrace("Item_ID: " & Session("Item_ID"))
        hdnItemNo.Value = DrpVehicleName.SelectedValue
        hdnGAId.Value = ddGeneralAccount.SelectedValue

        loadEquipmentInformation_from_drpName()
        loadUnit()
        loadUsefulLife()
        'loadEquipmentInformation_from_drpName()
        'already refreshes the equipment ledger.

    End Sub


    Protected Sub loadEquipmentInformation_from_drpName()
        Dim CYear As String = "CY" & Year(Date.Now.ToString)
        Dim itemid As String
        '   loadUnit()
        ' loadwarehouse()
        ' LoadBuildings()
        LoadEquipDTL()

        If DrpVehicleName.Text = "" Then

            itemid = "0"
        Else
            itemid = DrpVehicleName.SelectedValue
            txtVehicleName.Text = DrpVehicleName.SelectedItem.Text
            txtVehicleDesc.Text = DrpVehicleName.SelectedItem.Text

        End If

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID inner join ams.Property as c on a.Item_ID = c.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then
            hdnItemNo.Value = itemid
            hdnGAId.Value = ddGeneralAccount.SelectedValue
        Else
            On Error Resume Next
            hdnItemNo.Value = itemid
            hdnGAId.Value = ddGeneralAccount.SelectedValue
            txtVehicleName.Text = dt.Rows(0).Item("Name").ToString
            txtVehicleDesc.Text = dt.Rows(0).Item("description").ToString
            txtVehiclePowerInput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtVehiclePowerInput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtVehicleWarranty.Text = objDerived.GetValue("select e.Warranty from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtVehicleMake.Text = objDerived.GetValue("select e.VehicleMake from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtVehicleQuantity.Text = objDerived.GetValue("select count(e.VehicleMake) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtVehicleType.Text = objDerived.GetValue("select e.VehicleType from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtVehicleColor.Text = objDerived.GetValue("select e.VehicleColor from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtEAcqDate.Text = objDerived.GetValue("select convert(varchar,c.Property_Date,101) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtVehicleMarketValue.Text = CDec(objDerived.GetValue("select d.MarketValue from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)).ToString("N2")

            txtVehicleAcqCost.Text = CDec(objDerived.GetValue("select c.Cost from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)).ToString("N2")

            txtVehicleNoYears.Text = objDerived.GetValue("select e.NoofYears from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtVehicleDepRate.Text = objDerived.GetValue("select e.DepRate from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtVehicleUsefullife.Text = objDerived.GetValue("select e.UsefulLife from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtVehicleDepValue.Text = CDec(objDerived.GetValue("select e.DepValue from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)).ToString("N2")

            txtVehicleSalvageValue.Text = CDec(objDerived.GetValue("select e.SalvageValue from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)).ToString("N2")




        End If

        Dim dt1 As New DataTable
        dt1 = objDerived.GetDataTable("[AMS].[sp_View_Encoding] 'Vehicle','" & itemid & "'", CommandType.Text)
        If dt1.Rows.Count > 0 Then
            lblItem_ID.Text = dt1.Rows(0).Item("item_ID").ToString
            lblProperty_ID.Text = dt1.Rows(0).Item("Property_ID").ToString
            lblPropertyDetai_ID.Text = dt1.Rows(0).Item("PropertyDetai_ID").ToString
            lblMotor_InfoId.Text = dt1.Rows(0).Item("Motor_InfoId").ToString
            lblMotorID.Text = dt1.Rows(0).Item("MotorID").ToString
        Else
            lblItem_ID.Text = ""
            lblProperty_ID.Text = ""
            lblPropertyDetai_ID.Text = ""
            lblMotor_InfoId.Text = ""
            lblMotorID.Text = ""
        End If
        btnSave.Enabled = True
        loadEquipmentLedger()
    End Sub
    Protected Sub LoadEquipDTL()
        hdnItemNo.Value = ""

        'txtVehicleName.Text = ""
        'txtVehiclePowerInput.Text = ""
        'txtVehicleDesc.Text = ""
        'txtVehicleWarranty.Text = ""
        'txtVehicleMake.Text = ""
        'txtVehicleQuantity.Text = ""
        'txtVehicleType.Text = ""
        'txtVehicleColor.Text = ""
        'txtEAcqDate.Text = ""
        'txtVehicleMarketValue.Text = ""
        'txtVehicleAcqCost.Text = ""
        'txtVehicleNoYears.Text = ""
        'txtVehicleDepRate.Text = ""
        'txtVehicleUsefullife.Text = ""
        'txtVehicleDepValue.Text = ""
        'txtVehicleSalvageValue.Text = ""

        ''----Watercrafts
        'hdnItemNo.value = ""
        'hdnGAId.value = ""
        'txtWatercraftName.Text = ""
        'txtWatercraftDescription.Text = ""
        'txtWatercraftPowerInput.Text = ""
        'txtWatercraftPowerInput.Text = ""
        'txtWatercraftWarranty.Text = ""
        'txtWatercraftMake.Text = ""
        'txtWatercraftQuantity.Text = ""
        'txtWatercraftType.Text = ""
        'txtWatercraftColor.Text = ""
        'txtEAcqDate.Text = ""
        'txtWatercraftMarketValue.Text = ""
        'txtWatercraftAcqCost.Text = ""
        'txtWatercraftNoYears.Text = ""
        'txtWatercraftDepRate.Text = ""
        'txtWatercraftUsefullife.Text = ""
        'txtWatercraftDepValue.Text = ""
        'txtWatercraftSalvageValue.Text = ""
        'txtWatercraftMMSI.Text = ""
        'txtWatercraftCallSign.Text = ""
        'txtWatercraftImoNo.Text = ""
        'txtWatercraftHullMaterial.Text = ""
        'txtWatercraftNoofMast.Text = ""
        'txtWatercraftNoofDecks.Text = ""
        'txtWatercraftNoofDecks.Text = ""
        'txtWatercraftNoofEngine.Text = ""
        'txtWatercraftMainEngine.Text = ""

        'txtWatercraftHorsePower.Text = ""
        'txtWatercraftGRT.Text = ""
        'txtWatercraftNRT.Text = ""
        'txtWatercraftLOA.Text = ""
        'txtWatercraftBreadth.Text = ""
        'txtWatercraftCarryingCapacity.Text = ""

        Dim vehicleTextBoxes() As TextBox = {txtVehicleName, txtVehiclePowerInput, txtVehicleDesc, txtVehicleWarranty, txtVehicleMake, txtBrand, txtSpecification,
                                      txtVehicleQuantity, txtVehicleType, txtVehicleColor, txtEAcqDate, txtVehicleMarketValue,
                                      txtVehicleAcqCost, txtVehicleNoYears, txtVehicleDepRate, txtVehicleUsefullife, txtVehicleDepValue,
                                      txtVehicleSalvageValue}

        Dim watercraftTextBoxes() As TextBox = {txtWatercraftName, txtWatercraftDescription, txtWatercraftPowerInput, txtWatercraftPowerInput,
                                       txtWatercraftWarranty, txtWatercraftMake, txtWatercraftQuantity, txtWatercraftType, txtWatercraftColor,
                                       txtEAcqDate, txtWatercraftMarketValue, txtWatercraftAcqCost, txtWatercraftNoYears, txtWatercraftDepRate,
                                       txtWatercraftUsefulLife, txtWatercraftDepValue, txtWatercraftSalvageValue, txtWatercraftMMSI,
                                       txtWatercraftCallSign, txtWatercraftImoNo, txtWatercraftHullMaterial, txtWatercraftNoofMast,
                                       txtWatercraftNoofDecks, txtWatercraftNoofDecks, txtWatercraftNoofEngine, txtWatercraftMainEngine,
                                       txtWatercraftHorsePower, txtWaterCraftGRT, txtWatercraftNRT, txtWatercraftLOA, txtWatercraftBreadth,
                                       txtWaterCraftCarryingCapacity}

        ' Clear text in vehicle text boxes
        For Each textBox As TextBox In vehicleTextBoxes
            textBox.Text = ""
        Next

        ' Clear text in watercraft text boxes
        For Each textBox As TextBox In watercraftTextBoxes
            textBox.Text = ""
        Next

        ' Clear hidden field values
        hdnItemNo.Value = ""
        hdnGAId.Value = ""


    End Sub


    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim textPN As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
            Dim textSN As TextBox = CType(e.Row.FindControl("txtSerialNo"), TextBox)
            Dim textCN As TextBox = CType(e.Row.FindControl("txtChasisNo"), TextBox)
            Dim textLPN As TextBox = CType(e.Row.FindControl("txtLicensePlateNo"), TextBox)
            Dim textMFN As TextBox = CType(e.Row.FindControl("txtMVFileNo"), TextBox)
            Dim textCS As TextBox = CType(e.Row.FindControl("txtConSticker"), TextBox)
            Dim textWeight As TextBox = CType(e.Row.FindControl("txtWeight"), TextBox)

            Dim dt As DataTable = Nothing

            If ViewState("Customers") IsNot Nothing Then
                dt = DirectCast(ViewState("Customers"), DataTable)
            End If

            If dt IsNot Nothing AndAlso e.Row.RowIndex < dt.Rows.Count Then
                textPN.Text = dt.Rows(e.Row.RowIndex)("PropertyNo").ToString()
                textSN.Text = dt.Rows(e.Row.RowIndex)("SerialNo").ToString()
                textCN.Text = dt.Rows(e.Row.RowIndex)("ChasisNo").ToString()
                textLPN.Text = dt.Rows(e.Row.RowIndex)("PlateNo").ToString()
                textMFN.Text = dt.Rows(e.Row.RowIndex)("MVfileNo").ToString()
                textCS.Text = dt.Rows(e.Row.RowIndex)("ConSticker").ToString()

                If dt.Columns.Contains("MotorWeight") Then
                    textWeight.Text = dt.Rows(e.Row.RowIndex)("MotorWeight").ToString()
                End If

                If btnSave.Text = "EDIT" OrElse btnSave.Text = "UPDATE" Then
                    textPN.Enabled = False
                End If

                counts += 1
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

        If Not dt.Columns.Contains("MotorWeight") Then
            dt.Columns.Add("MotorWeight", GetType(String))
        End If

        Dim tempList As List(Of TempPropertyDetail)

        If Session("TempPropertyList") IsNot Nothing Then
            tempList = CType(Session("TempPropertyList"), List(Of TempPropertyDetail))
        Else
            tempList = New List(Of TempPropertyDetail)()
        End If

        For Each row As GridViewRow In grdPropertyInfo.Rows
            Dim textPN As TextBox = CType(row.FindControl("txtPropertyNo"), TextBox)
            Dim textSN As TextBox = CType(row.FindControl("txtSerialNo"), TextBox)
            Dim textCN As TextBox = CType(row.FindControl("txtChasisNo"), TextBox)
            Dim textLPN As TextBox = CType(row.FindControl("txtLicensePlateNo"), TextBox)
            Dim textMFN As TextBox = CType(row.FindControl("txtMVFileNo"), TextBox)
            Dim textCS As TextBox = CType(row.FindControl("txtConSticker"), TextBox)
            Dim textWeight As TextBox = CType(row.FindControl("txtWeight"), TextBox)

            Dim propertyNo As String = textPN.Text
            Dim serialNo As String = textSN.Text
            Dim chasisNo As String = textCN.Text
            Dim plateNo As String = textLPN.Text
            Dim mvFileNo As String = textMFN.Text
            Dim conSticker As String = textCS.Text
            Dim motorWeight As String = textWeight.Text

            If propertyNo = "" AndAlso dt.Rows(row.RowIndex)("PropertyNo").ToString() <> "" Then
                propertyNo = dt.Rows(row.RowIndex)("PropertyNo").ToString()
            End If

            If motorWeight = "" AndAlso dt.Rows(row.RowIndex)("MotorWeight").ToString() <> "" Then
                motorWeight = dt.Rows(row.RowIndex)("MotorWeight").ToString()
            End If

            dt.Rows(row.RowIndex)("PropertyNo") = propertyNo
            dt.Rows(row.RowIndex)("SerialNo") = serialNo
            dt.Rows(row.RowIndex)("ChasisNo") = chasisNo
            dt.Rows(row.RowIndex)("PlateNo") = plateNo
            dt.Rows(row.RowIndex)("MVfileNo") = mvFileNo
            dt.Rows(row.RowIndex)("ConSticker") = conSticker
            dt.Rows(row.RowIndex)("MotorWeight") = motorWeight

            If row.RowIndex < tempList.Count Then
                tempList(row.RowIndex).PropertyNo = propertyNo
                tempList(row.RowIndex).SerialNo = serialNo
                tempList(row.RowIndex).ChasisNo = chasisNo
                tempList(row.RowIndex).PlateNo = plateNo
                tempList(row.RowIndex).MVfileNo = mvFileNo
                tempList(row.RowIndex).ConSticker = conSticker
                tempList(row.RowIndex).MotorWeight = motorWeight
            Else
                Dim newItem As New TempPropertyDetail With {
                .PropertyNo = propertyNo,
                .SerialNo = serialNo,
                .ChasisNo = chasisNo,
                .PlateNo = plateNo,
                .MVfileNo = mvFileNo,
                .ConSticker = conSticker,
                .MotorWeight = motorWeight
            }

                tempList.Add(newItem)
            End If
        Next

        Session("TempPropertyList") = tempList
        ViewState("Customers") = dt

        ModalPopupExtender2.Hide()

    End Sub


    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)

        Dim quantityTxtBox As TextBox = txtVehicleQuantity

        If quantityTxtBox.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
            Exit Sub
        End If

        Dim qty As Integer = 0
        If Not Integer.TryParse(quantityTxtBox.Text, qty) OrElse qty <= 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid Quantity.")
            Exit Sub
        End If

        Dim dt As DataTable

        If ViewState("Customers") IsNot Nothing Then
            dt = DirectCast(ViewState("Customers"), DataTable)
        Else
            dt = New DataTable()
        End If

        If Not dt.Columns.Contains("PropertyNo") Then dt.Columns.Add("PropertyNo", GetType(String))
        If Not dt.Columns.Contains("SerialNo") Then dt.Columns.Add("SerialNo", GetType(String))
        If Not dt.Columns.Contains("ChasisNo") Then dt.Columns.Add("ChasisNo", GetType(String))
        If Not dt.Columns.Contains("PlateNo") Then dt.Columns.Add("PlateNo", GetType(String))
        If Not dt.Columns.Contains("MVfileNo") Then dt.Columns.Add("MVfileNo", GetType(String))
        If Not dt.Columns.Contains("ConSticker") Then dt.Columns.Add("ConSticker", GetType(String))
        If Not dt.Columns.Contains("MotorWeight") Then dt.Columns.Add("MotorWeight", GetType(String))

        While dt.Rows.Count < qty
            dt.Rows.Add("", "", "", "", "", "", "")
        End While

        While dt.Rows.Count > qty
            dt.Rows.RemoveAt(dt.Rows.Count - 1)
        End While

        If (btnSave.Text = "EDIT" OrElse btnSave.Text = "UPDATE" OrElse ViewState("CheckboxEvent") = True) AndAlso lblProperty_ID.Text <> "" AndAlso lblProperty_ID.Text <> "Label" Then

            Dim dt1 As DataTable = objDerived.GetDataTable(
            "SELECT prop.PropertyNo, prop.SerialNo, eqinfo.ChasisNo, eqinfo.PlateNo, eqinfo.MVfileNo, eqinfo.ConSticker, eqinfo.MotorWeight, prop.PropertyDetai_ID " &
            "FROM AMS.Property_Dtl prop INNER JOIN AMS.TbMotor_Info eqinfo ON prop.PropertyDetai_ID = eqinfo.Property_Dtl_ID " &
            "WHERE prop.Property_ID = '" & lblProperty_ID.Text & "'",
            CommandType.Text)

            Dim tempList As New List(Of TempPropertyDetail)()

            If dt1.Rows.Count > 0 Then
                dt.Rows.Clear()

                For i As Integer = 0 To dt1.Rows.Count - 1
                    dt.Rows.Add(
                    dt1.Rows(i).Item("PropertyNo").ToString(),
                    dt1.Rows(i).Item("SerialNo").ToString(),
                    dt1.Rows(i).Item("ChasisNo").ToString(),
                    dt1.Rows(i).Item("PlateNo").ToString(),
                    dt1.Rows(i).Item("MVfileNo").ToString(),
                    dt1.Rows(i).Item("ConSticker").ToString(),
                    dt1.Rows(i).Item("MotorWeight").ToString()
                )

                    Dim temp As New TempPropertyDetail() With {
                    .PropertyNo = dt1.Rows(i).Item("PropertyNo").ToString(),
                    .SerialNo = dt1.Rows(i).Item("SerialNo").ToString(),
                    .ChasisNo = dt1.Rows(i).Item("ChasisNo").ToString(),
                    .PlateNo = dt1.Rows(i).Item("PlateNo").ToString(),
                    .MVfileNo = dt1.Rows(i).Item("MVfileNo").ToString(),
                    .ConSticker = dt1.Rows(i).Item("ConSticker").ToString(),
                    .MotorWeight = dt1.Rows(i).Item("MotorWeight").ToString(),
                    .PropertyDtl_ID = dt1.Rows(i).Item("PropertyDetai_ID").ToString()
                }

                    tempList.Add(temp)
                Next

                While dt.Rows.Count < qty
                    dt.Rows.Add("", "", "", "", "", "", "")
                End While

                While dt.Rows.Count > qty
                    dt.Rows.RemoveAt(dt.Rows.Count - 1)
                End While

                Session("TempPropertyList") = tempList
            End If

            ViewState("CheckboxEvent") = False

        ElseIf btnSave.Text = "SAVE" Then

            Try
                If String.IsNullOrEmpty(hdnGAId.Value) Then
                    hdnGAId.Value = ddGeneralAccount.SelectedValue
                End If

                If String.IsNullOrEmpty(hdnGAId.Value) Then
                    AddTrace("GA_ID is empty or null")
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Cannot generate property numbers: General Account information is missing. Please select a General Account first.")
                    Exit Sub
                End If

                Dim GA_ID As Integer
                If Not Integer.TryParse(hdnGAId.Value, GA_ID) Then
                    AddTrace("Invalid GA_ID format: " & hdnGAId.Value)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid General Account ID format. Please select a valid General Account.")
                    Exit Sub
                End If

                Dim RC_ID As String = "00"
                Dim currentYear As Integer = Year(Now)
                Dim rowCount As Integer = dt.Rows.Count

                AddTrace(String.Format("Generating {0} property numbers for GA_ID: {1}, RC_ID: {2}, Year: {3}", rowCount, GA_ID, RC_ID, currentYear))

                If rowCount > 0 Then
                    Dim sqlCommand As String = String.Format(
                    "EXEC AMS.sp_Generate_PropertyNo_Main {0}, {1}, '{2}', {3}",
                    currentYear, GA_ID, RC_ID, rowCount)

                    AddTrace("Executing SQL: " & sqlCommand)

                    Dim propertyNumbers As DataTable = objDerived.GetDataTable(sqlCommand, CommandType.Text)

                    If propertyNumbers Is Nothing Then
                        AddTrace("propertyNumbers is Nothing")
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error generating property numbers: No data returned from stored procedure.")
                        Exit Sub
                    End If

                    AddTrace("PropertyNumbers rows count: " & propertyNumbers.Rows.Count)

                    If propertyNumbers.Rows.Count >= rowCount Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            If i < propertyNumbers.Rows.Count Then
                                If propertyNumbers.Columns.Contains("PropertyNumber") Then
                                    dt.Rows(i)("PropertyNo") = propertyNumbers.Rows(i)("PropertyNumber").ToString()
                                    dt.Rows(i)("SerialNo") = ""
                                    dt.Rows(i)("ChasisNo") = ""
                                    dt.Rows(i)("PlateNo") = ""
                                    dt.Rows(i)("MVfileNo") = ""
                                    dt.Rows(i)("ConSticker") = ""
                                    dt.Rows(i)("MotorWeight") = ""
                                    AddTrace(String.Format("Row {0}: Assigned Property Number: {1}", i, dt.Rows(i)("PropertyNo").ToString()))
                                Else
                                    AddTrace("PropertyNumber column not found in result set")
                                End If
                            End If
                        Next

                        AddTrace("Successfully generated all property numbers")
                    Else
                        AddTrace(String.Format("Failed to generate property numbers - expected {0} rows but got {1}", rowCount, propertyNumbers.Rows.Count))

                        If propertyNumbers.Rows.Count = 0 Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No property numbers were generated. This might indicate that the GA_ID is not properly mapped in the system.")
                        Else
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, String.Format("Error generating property numbers: Expected {0} numbers but only got {1}. Please try again.", rowCount, propertyNumbers.Rows.Count))
                        End If
                    End If
                Else
                    AddTrace("No rows to generate property numbers for")
                End If

            Catch ex As Exception
                AddTrace("Error generating property numbers: " & ex.Message)
                AddTrace("Stack Trace: " & ex.StackTrace)

                If ex.Message.Contains("String") AndAlso ex.Message.Contains("format") Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Data format error. Please check that all required fields are properly selected.")
                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error generating property numbers. Please try again. Error: " & ex.Message)
                End If
            End Try

        End If

        ViewState("Customers") = dt
        BindGrid()

        ModalPopupExtender2.Show()

    End Sub


    Protected Sub BindGrid()
        grdPropertyInfo.DataSource = DirectCast(ViewState("Customers"), DataTable)
        grdPropertyInfo.DataBind()
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

    Public Sub loadEquipmentLedger()
        btnEquipmentLedger.CssClass = "Clicked"
        btnequipmentrepairs.CssClass = "Initial"
        btnequipmentattachdoc.CssClass = "Initial"

        mvledger.SetActiveView(vwledger)

        Dim itemID As Long = 0

        If Not String.IsNullOrWhiteSpace(hdnItemNo.Value) AndAlso
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
            "EXEC AMS.PropertyLedger '" & itemID & "'",
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

        btnSave.Text = "SAVE"
        btnWatercraftsave.Text = "SAVE"

        btnSave.Enabled = itemID > 0
        btnWatercraftsave.Enabled = itemID > 0

    End Sub

    Public Function createdatatableledger(
    ByVal row As Integer
) As DataTable

        Dim dt As New DataTable()

        dt.Columns.Add("Property_ID", GetType(Long))
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
            dt.Rows.Add(dt.NewRow())
        Next

        Return dt

    End Function
    Private Function GetNumericOrZero(input As String) As Decimal
        Dim val As Decimal
        Return If(Decimal.TryParse(input.Replace(",", "").Trim(), val), val, 0D)
    End Function

    Public Sub Add()


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



        If String.IsNullOrWhiteSpace(txtVehicleDesc.Text) Then
            missingFields.Add("Description")
        End If
        If ddVehicleUnit.SelectedIndex = 0 Then
            missingFields.Add("Unit")
        End If
        If String.IsNullOrWhiteSpace(txtVehicleQuantity.Text) Then
            missingFields.Add("Quantity")
        End If


        If String.IsNullOrWhiteSpace(txtEAcqDate.Text) Then
            missingFields.Add("Acquisition Date")
        End If
        If txtVehicleAcqCost.Text = "0.00" Or txtVehicleAcqCost.Text = "0" Or txtVehicleAcqCost.Text = "" Then
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
                .GA_ID = ddGeneralAccount.SelectedValue
                .DonationRemarks = ""
                .Qty = txtVehicleQuantity.Text
                .Balance = txtVehicleQuantity.Text
                .Cost = CType(txtVehicleAcqCost.Text, Decimal)
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

            Dim ClassificationID = objDerived.GetValue("select ClassificationId from t_ClassWithSubclass WHERE ClassificationName LIKE '%Vehicle'", CommandType.Text)

            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Property SET ClassificationID = '" & ClassificationID & "',SubClassificationID = '" & drpSubClass.SelectedValue & "'  WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)



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
                    .InspectionDate = txtEAcqDate.Text
                    .F_ID = 1
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNo"), TextBox).Text
                    .Barcode = " "
                    .Amount = CType(txtVehicleAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    .Details = "" 'txtSpecification.Text
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
                    .Function_ID = 86
                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = Prop_Dtl.save()

                objDerived.GetRecords(
                    "UPDATE AMS.Property_Dtl " &
                    "SET MarketValue = '" & GetNumericOrZero(txtVehicleMarketValue.Text) & "' " &
                    "WHERE PropertyDetai_ID = '" & PropDtl_ID & "'",
                    CommandType.Text)


                Dim info_id As Integer
                With objMotorInfo
                    .Motor_InfoId = 0
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = PropDtl_ID
                    '.Name = txtVehicleName.Text
                    .Name = DrpVehicleName.SelectedItem.Text
                    .PlateNo = CType(grdPropertyInfo.Rows(i).FindControl("txtLicensePlateNo"), TextBox).Text
                    .MotorNo = ""
                    .Model = ""
                    .ChasisNo = CType(grdPropertyInfo.Rows(i).FindControl("txtChasisNo"), TextBox).Text
                    .VehicleColor = txtVehicleColor.Text
                    .WheelsCapacity = ""
                    .GrossWeight = ""
                    .Seats = ""
                    .Warranty = txtVehicleWarranty.Text
                    .VehicleOwner = ""
                    .DeclaredName = ""
                    .BeneficialUser = ""
                    .VehicleSpecification = ""
                    .VehicleDesc = txtVehicleDesc.Text
                    .VehicleMake = txtVehicleMake.Text
                    .VehicleType = txtVehicleType.Text
                    .PowerInput = txtVehiclePowerInput.Text
                    .MVfileNo = CType(grdPropertyInfo.Rows(i).FindControl("txtMVFileNo"), TextBox).Text
                    .ConSticker = CType(grdPropertyInfo.Rows(i).FindControl("txtConSticker"), TextBox).Text
                    .DepRate = CDec(GetNumericOrZero(txtVehicleDepRate.Text)) ' or CInt(...) if it must be int

                    .DepValue = CDec(GetNumericOrZero(txtVehicleDepValue.Text)) ' or CInt(...) / CLng(...) if required

                    .NoofYears = txtVehicleNoYears.Text
                    .UsefulLife = CDec(GetNumericOrZero(txtVehicleUsefullife.Text))

                    .SalvageValue = txtVehicleSalvageValue.Text
                    .CsNo = CType(grdPropertyInfo.Rows(i).FindControl("txtChasisNo"), TextBox).Text
                    .EngineNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNo"), TextBox).Text
                    .Displacement = ""
                    .MotorWeight = CType(grdPropertyInfo.Rows(i).FindControl("txtWeight"), TextBox).Text
                End With
                Dim motor_info_id As Integer
                motor_info_id = objMotorInfo.save()

                objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Received_ID = 0, Received_Dtl_ID = 0 WHERE Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)
                objDerived.GetRecords(
                    "UPDATE AMS.TbMotor_Info SET " &
                    "Remarks = '" & txtRemarks.Text.Replace("'", "''") & "', " &
                    "Property_ID = '" & PropHdr_ID & "', " &
                    "Unit_ID = '" & ddVehicleUnit.SelectedValue & "', " &
                    "Brand = '" & txtBrand.Text.Replace("'", "''") & "', " &
                    "Specification = '" & txtSpecification.Text.Replace("'", "''") & "' " &
                    "WHERE Motor_InfoId = '" & motor_info_id & "'",
                    CommandType.Text)

                With objMotorDtl
                    .MotorID = 0
                    .Motor_InfoId = motor_info_id
                    .Property_Dtl_ID = PropDtl_ID
                    '.MarketValue = txtVehicleMarketValue.Text
                    .MarketValue = CDec(GetNumericOrZero(txtVehicleMarketValue.Text))
                    .Condition = ""
                    .Location = ""
                    .Status = "Accepted"
                End With
                objMotorDtl.save()


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
                .DebitQty = txtVehicleQuantity.Text
                .DebitCost = (CType(txtVehicleAcqCost.Text, Decimal) * txtVehicleQuantity.Text)
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
    Convert.ToInt32(txtVehicleQuantity.Text)

                Dim VehicleAcquisitionCost As Decimal =
    CType(txtVehicleAcqCost.Text.Replace(",", ""), Decimal)

                Dim NewEquipmentCost As Decimal =
    VehicleAcquisitionCost * NewEquipmentQty
                AddTrace("BalanceQty: " & Eqty + NewEquipmentQty)
                AddTrace("BalanceCost: " & Eqbalance + NewEquipmentCost)

                .BalanceQty = Eqty + NewEquipmentQty
                .BalanceCost = Eqbalance + NewEquipmentCost

                .Property_ID = PropHdr_ID
            End With
            Prop_Ledger.save()



            btnSave.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            'multiviewselected()
            ' loadEquipmentList()
            ' loadEquipmentInformation()
            'loadEquipmentInformation_from_drpName()
            loadEquipmentLedger()
        End If
        ' End If

        'REBALANCE FROM EDITED ROW ABOVE
        'objDerived.GetDataTable("Exec [AMS].[ReBalanceLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
    End Sub
    Public Sub Edit()

        If txtVehicleAcqCost.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up at least the required Fields: Acquisition Cost")

        Else
            If Not IsNumeric(txtVehicleAcqCost.Text) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
            Else
                Dim objDerived As New DerivedDal
                objDerived.conStr = objDerived.DbaseConnect()
                objDerived.cmd.Parameters.AddWithValue("@Property_ID", lblProperty_ID.Text)
                objDerived.cmd.Parameters.AddWithValue("@Motor_InfoId", lblMotor_InfoId.Text)
                objDerived.cmd.Parameters.AddWithValue("@MotorID", lblMotorID.Text)

                objDerived.cmd.Parameters.AddWithValue("@PropertyDtl_ID", lblPropertyDetai_ID.Text)

                objDerived.cmd.Parameters.AddWithValue("@Name", DrpVehicleName.SelectedItem.Text)
                objDerived.cmd.Parameters.AddWithValue("@PowerInput", txtVehiclePowerInput.Text)
                objDerived.cmd.Parameters.AddWithValue("@VehicleDesc", txtVehicleDesc.Text)
                objDerived.cmd.Parameters.AddWithValue("@Warranty", txtVehicleWarranty.Text)
                objDerived.cmd.Parameters.AddWithValue("@VehicleMake", txtVehicleMake.Text)
                objDerived.cmd.Parameters.AddWithValue("@Qty", txtVehicleQuantity.Text)
                objDerived.cmd.Parameters.AddWithValue("@VehicleType", txtVehicleType.Text)
                objDerived.cmd.Parameters.AddWithValue("@VehicleColor", txtVehicleColor.Text)

                objDerived.cmd.Parameters.AddWithValue("@Brand", txtBrand.Text)
                objDerived.cmd.Parameters.AddWithValue("@Specification", txtSpecification.Text)

                objDerived.cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text)

                objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtEAcqDate.Text)

                objDerived.cmd.Parameters.AddWithValue("@MarketValue", GetNumericOrZero(txtVehicleMarketValue.Text))
                objDerived.cmd.Parameters.AddWithValue("@Cost", GetNumericOrZero(txtVehicleAcqCost.Text))
                objDerived.cmd.Parameters.AddWithValue("@NoofYears", GetNumericOrZero(txtVehicleNoYears.Text))
                objDerived.cmd.Parameters.AddWithValue("@DepRate", GetNumericOrZero(txtVehicleDepRate.Text))
                objDerived.cmd.Parameters.AddWithValue("@UsefulLife", GetNumericOrZero(txtVehicleUsefullife.Text))
                objDerived.cmd.Parameters.AddWithValue("@DepValue", GetNumericOrZero(txtVehicleDepValue.Text))
                objDerived.cmd.Parameters.AddWithValue("@SalvageValue", GetNumericOrZero(txtVehicleSalvageValue.Text))

                objDerived.cmd.Parameters.AddWithValue("@Item_ID", lblItem_ID.Text)

                objDerived.Execute("AMS.spEdit_Vehicles_Info_Dtl", CommandType.StoredProcedure)

                Dim dtAccount As New DataTable
                Dim cb1 As CheckBox
                Dim LedgerID As Long
                Dim PropID As String
                Dim IsIssuance As String

                dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

                For i As Integer = 0 To dtAccount.Rows.Count - 1
                    cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                    If cb1.Visible AndAlso cb1.Checked Then

                        LedgerID = dtAccount.Rows(i).Item("Ledger_ID").ToString()
                        PropID = dtAccount.Rows(i).Item("Property_ID").ToString()
                        IsIssuance = dtAccount.Rows(i).Item("Trans_type").ToString()

                        If PropID = "" Or PropID = "0" Then

                            objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] " &
                                       "SET Property_ID = '" & lblProperty_ID.Text & "' " &
                                       "WHERE Ledger_ID = '" & LedgerID & "' ", CommandType.Text)

                        End If

                        If IsIssuance = "Issuance" Then

                            objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] " &
                                       "SET CreditQty = '" & txtVehicleQuantity.Text & "', " &
                                       "CreditCost = '" & (CType(txtVehicleAcqCost.Text, Decimal) * CType(txtVehicleQuantity.Text, Decimal)).ToString("F2") & "', " &
                                       "CreditUnit = '" & ddVehicleUnit.Text.Replace(",", "") & "', " &
                                       "dDate = '" & txtEAcqDate.Text & "', " &
                                       "BalanceQty = '" & txtVehicleQuantity.Text & "', " &
                                       "BalanceCost = '" & (CType(txtVehicleAcqCost.Text, Decimal) * CType(txtVehicleQuantity.Text, Decimal)).ToString("F2") & "', " &
                                       "BalanceUnit = '" & ddVehicleUnit.SelectedValue & "' " &
                                       "WHERE Ledger_ID = '" & LedgerID & "' ", CommandType.Text)
                        Else

                            objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] " &
                                       "SET DebitQty = '" & txtVehicleQuantity.Text & "', " &
                                       "DebitCost = '" & (CType(txtVehicleAcqCost.Text, Decimal) * CType(txtVehicleQuantity.Text, Decimal)).ToString("F2") & "', " &
                                       "DebitUnit = '" & ddVehicleUnit.Text.Replace(",", "") & "', " &
                                       "dDate = '" & txtEAcqDate.Text & "', " &
                                       "BalanceQty = '" & txtVehicleQuantity.Text & "', " &
                                       "BalanceCost = '" & (CType(txtVehicleAcqCost.Text, Decimal) * CType(txtVehicleQuantity.Text, Decimal)).ToString("F2") & "', " &
                                       "BalanceUnit = '" & ddVehicleUnit.SelectedValue & "' " &
                                       "WHERE Ledger_ID = '" & LedgerID & "' ", CommandType.Text)
                        End If

                    End If
                Next

                Dim tempTableDtlProperty As List(Of TempPropertyDetail)

                If Session("TempPropertyList") IsNot Nothing Then
                    tempTableDtlProperty = CType(Session("TempPropertyList"), List(Of TempPropertyDetail))
                Else
                    tempTableDtlProperty = New List(Of TempPropertyDetail)
                End If

                Try

                    Dim iterate As Integer = 0
                    For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1

                        Dim gvRow As GridViewRow = grdPropertyInfo.Rows(i)

                        Dim textPN As TextBox = CType(gvRow.FindControl("txtPropertyNo"), TextBox)
                        Dim textSN As TextBox = CType(gvRow.FindControl("txtSerialNo"), TextBox)
                        Dim textCN As TextBox = CType(gvRow.FindControl("txtChasisNo"), TextBox)
                        Dim textLPN As TextBox = CType(gvRow.FindControl("txtLicensePlateNo"), TextBox)
                        Dim textMFN As TextBox = CType(gvRow.FindControl("txtMVFileNo"), TextBox)
                        Dim textCS As TextBox = CType(gvRow.FindControl("txtConSticker"), TextBox)
                        Dim textWeight As TextBox = CType(gvRow.FindControl("txtWeight"), TextBox)

                        iterate += 1

                        Dim current As New TempPropertyDetail With {
                        .PropertyNo = textPN.Text,
                        .SerialNo = textSN.Text,
                        .ChasisNo = textCN.Text,
                        .PlateNo = textLPN.Text,
                        .MVfileNo = textMFN.Text,
                        .ConSticker = textCS.Text,
                        .MotorWeight = textWeight.Text
                    }

                        If i < tempTableDtlProperty.Count Then
                            Dim original As TempPropertyDetail = tempTableDtlProperty(i)

                            objDerived.GetRecords("UPDATE [AMS].[TbMotor_Info] " &
                                                   "SET ChasisNo = '" & current.ChasisNo & "', " &
                                                   "ConSticker = '" & current.ConSticker & "', " &
                                                   "VehicleDesc = '" & txtVehicleDesc.Text & "', " &
                                                   "Remarks = '" & txtRemarks.Text & "', " &
                                                   "EngineNo = '" & current.SerialNo & "', " &
                                                   "MVfileNo = '" & current.MVfileNo & "', " &
                                                   "PlateNo = '" & current.PlateNo & "', " &
                                                   "MotorWeight = '" & current.MotorWeight & "' " &
                                                   "WHERE Property_Dtl_ID = '" & original.PropertyDtl_ID & "' ", CommandType.Text)

                            objDerived.GetRecords("UPDATE [AMS].[TbEquipment_Dtl] " &
                                                   "SET MarketValue = '" & txtVehicleMarketValue.Text & "' " &
                                                   "WHERE Property_Dtl_ID = '" & original.PropertyDtl_ID & "' ", CommandType.Text)

                            objDerived.GetRecords("UPDATE [AMS].[Property_Dtl] " &
                                                   "SET PropertyNo = '" & current.PropertyNo & "', " &
                                                   "SerialNo = '" & current.SerialNo & "', " &
                                                   "MarketValue = '" & txtVehicleMarketValue.Text & "' " &
                                                   "WHERE PropertyDetai_ID = '" & original.PropertyDtl_ID & "' ", CommandType.Text)

                        Else

                            Dim Prop_Dtl As New t_property_dtl
                            With Prop_Dtl
                                .PropertyNo = textPN.Text
                                .Property_ID = lblProperty_ID.Text
                                .Issued = False
                                .Repair = False
                                .Dispose = False
                                .DisposeDate = "1/1/1900"
                                .IsInspectionForDisposal = False
                                .InspectionDate = txtEAcqDate.Text
                                .F_ID = 1
                                .SerialNo = textSN.Text
                                .Barcode = " "
                                .Amount = CType(txtVehicleAcqCost.Text, Decimal)
                                .Status = "Accepted"
                                .Details = ""
                                .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                                .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
                                .Function_ID = 86
                            End With

                            Dim PropDtl_ID As Integer
                            PropDtl_ID = Prop_Dtl.save()

                            objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtVehicleMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

                            Dim info_id As Integer
                            With objMotorInfo
                                .Motor_InfoId = 0
                                .AIRDtl_ID = 0
                                .IsAccepted = True
                                .Property_Dtl_ID = PropDtl_ID
                                .Name = txtVehicleName.Text
                                .PlateNo = textLPN.Text
                                .MotorNo = ""
                                .Model = ""
                                .ChasisNo = textCN.Text
                                .VehicleColor = txtVehicleColor.Text
                                .WheelsCapacity = ""
                                .GrossWeight = ""
                                .Seats = ""
                                .Warranty = txtVehicleWarranty.Text
                                .VehicleOwner = ""
                                .DeclaredName = ""
                                .BeneficialUser = ""
                                .VehicleSpecification = ""
                                .VehicleDesc = txtVehicleDesc.Text
                                .VehicleMake = txtVehicleMake.Text
                                .VehicleType = txtVehicleType.Text
                                .PowerInput = txtVehiclePowerInput.Text
                                .MVfileNo = textMFN.Text
                                .ConSticker = textCS.Text
                                .DepRate = txtVehicleDepRate.Text
                                .DepValue = txtVehicleDepValue.Text
                                .NoofYears = txtVehicleNoYears.Text
                                .UsefulLife = txtVehicleUsefullife.Text
                                .SalvageValue = txtVehicleSalvageValue.Text
                                .CsNo = textCN.Text
                                .EngineNo = textSN.Text
                                .Displacement = ""
                                .MotorWeight = textWeight.Text
                            End With

                            Dim motor_info_id As Integer
                            motor_info_id = objMotorInfo.save()

                            objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Received_ID = 0, Received_Dtl_ID = 0 WHERE Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)
                            objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Remarks = '" & txtRemarks.Text & "' WHERE Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)

                            With objMotorDtl
                                .MotorID = 0
                                .Motor_InfoId = motor_info_id
                                .Property_Dtl_ID = PropDtl_ID
                                .MarketValue = txtVehicleMarketValue.Text
                                .Condition = ""
                                .Location = ""
                                .Status = "Accepted"
                            End With
                            objMotorDtl.save()
                        End If

                    Next
                Catch ex As Exception

                End Try

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")

                btnWatercraftsave.Text = "EDIT"
                btnSave.Text = "EDIT"

            End If
        End If

    End Sub
    Protected Sub btnSave_Click(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If btnSave.Text = "SAVE" Then

            If Not ValidateVehicleSelections() Then
                Exit Sub
            End If

            hdnGAId.Value = ddGeneralAccount.SelectedValue

            hdnItemNo.Value = DrpVehicleName.SelectedValue
            Session("Item_ID") = DrpVehicleName.SelectedValue

            Add()
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

            If Not ValidateVehicleSelections() Then
                Exit Sub
            End If

            hdnGAId.Value = ddGeneralAccount.SelectedValue

            hdnItemNo.Value = DrpVehicleName.SelectedValue
            Session("Item_ID") = DrpVehicleName.SelectedValue

            Edit()

            Dim cb1 As CheckBox

            For i As Integer = 0 To grdLedger1.Rows.Count - 1

                cb1 = TryCast(
                grdLedger1.Rows(i).FindControl("cbInspection"),
                CheckBox
            )

                If cb1 IsNot Nothing AndAlso
               cb1.Checked AndAlso
               cb1.Visible Then

                    cb1.Checked = False

                End If

            Next

            ClearTextBoxes()
            IsEnabledTextBoxes(True)

            btnSave.Text = "SAVE"
            btnWatercraftsave.Text = "SAVE"
            btnSave.Enabled = True

            loadEquipmentLedger()

        End If

        btnSave.Enabled = False
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
    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else
            btnSave.Text = "UPDATE"
            btnWatercraftsave.Text = "UPDATE"
            Button3.Enabled = True

            IsEnabledTextBoxes(True)
            btnSave.Enabled = True
        End If
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ModalPopupExtender1.Hide()
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
            dt1 = objDerived.GetDataTable("SELECT AMS.Property_Dtl.PropertyNo, AMS.Property_Dtl.SerialNo, AMS.TbMotor_Info.ChasisNo, AMS.TbMotor_Info.PlateNo, AMS.TbMotor_Info.MVfileNo, AMS.TbMotor_Info.ConSticker,  AMS.TbMotor_Info.MotorWeight, AMS.Property.Property_ID, AMS.TbMotor_Info.Property_Dtl_ID " &
                                                   " FROM  AMS.Property INNER JOIN " &
                                                   " AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID INNER JOIN " &
                                                   " AMS.TbMotor_Info ON AMS.Property_Dtl.PropertyDetai_ID = AMS.TbMotor_Info.Property_Dtl_ID " &
                                                   " where AMS.Property.Item_ID=" & hdnItemNo.Value & "", CommandType.Text)

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

        IsEnabledTextBoxes(True)
        btnSave.Text = "SAVE"
        txtVehicleQuantity.Enabled = True
        btnWatercraftsave.Text = "SAVE"
        txtVehicleQuantity.Enabled = True

        btnSave.Enabled = True
        btnWatercraftsave.Enabled = True

        ViewState("CheckboxEvent") = True

        Dim cb As CheckBox = CType(sender, CheckBox)
        Dim row As GridViewRow = CType(cb.NamingContainer, GridViewRow)
        Dim propertyId As String = grdLedger1.DataKeys(row.RowIndex)("Property_ID").ToString()

        AddTrace("hdnItemNo.Value: " & hdnItemNo.Value)
        AddTrace("Property_ID: " & propertyId)

        ' Optional: uncheck all other checkboxes so only one row is active
        For Each gvr As GridViewRow In grdLedger1.Rows
            Dim otherCb As CheckBox = CType(gvr.FindControl("cbInspection"), CheckBox)
            If otherCb IsNot Nothing AndAlso gvr.RowIndex <> row.RowIndex Then
                otherCb.Checked = False
            End If
        Next

        ' If the clicked checkbox was unchecked, clear fields and exit
        If Not cb.Checked Then
            ClearTextBoxes()
            Exit Sub
        End If

        Dim dt1 As DataTable = objDerived.GetDataTable(
        "[AMS].[sp_View_Encoding_v2] 'Vehicle','" & hdnItemNo.Value & "', '" & propertyId & "' ",
        CommandType.Text)

        If dt1.Rows.Count = 0 Then
            dt1 = objDerived.GetDataTable("EXEC AMS.GetParentChildID '" & hdnItemNo.Value & "' ", CommandType.Text)
        End If

        If dt1.Rows.Count = 0 Then
            ClearTextBoxes()
            Exit Sub
        End If

        Dim dr As DataRow = dt1.Rows(0)

        IsEnabledTextBoxes(False)
        btnWatercraftsave.Text = "EDIT"

        txtVehicleQuantity.Enabled = False
        btnSave.Text = "EDIT"

        '-- LAND
        If drpSubClass.SelectedIndex > 0 Then
            txtVehicleDesc.Text = dr("VehicleDesc").ToString()
            txtVehiclePowerInput.Text = dr("PowerInput").ToString()
            txtVehicleWarranty.Text = dr("Warranty").ToString()
            txtVehicleMake.Text = dr("VehicleMake").ToString()
            txtVehicleQuantity.Text = dr("Qty").ToString()
            txtVehicleType.Text = dr("VehicleType").ToString()
            txtVehicleColor.Text = dr("VehicleColor").ToString()

            If dt1.Columns.Contains("Brand") Then
                txtBrand.Text = dr("Brand").ToString()
            Else
                txtBrand.Text = ""
            End If

            If dt1.Columns.Contains("Specification") Then
                txtSpecification.Text = dr("Specification").ToString()
            Else
                txtSpecification.Text = ""
            End If

            txtEAcqDate.Text = dr("dDate").ToString()
            txtVehicleMarketValue.Text = dr("MarketValue").ToString()
            txtVehicleAcqCost.Text = dr("Cost").ToString()
            txtVehicleNoYears.Text = dr("NoofYears").ToString()
            txtVehicleDepRate.Text = dr("DepRate").ToString()
            txtVehicleUsefullife.Text = dr("UsefulLife").ToString()
            txtVehicleDepValue.Text = dr("DepValue").ToString()
            txtVehicleSalvageValue.Text = dr("SalvageValue").ToString()
            txtRemarks.Text = dr("Remarks").ToString()

            'If dt1.Columns.Contains("Unit_ID") Then
            '    ddVehicleUnit.SelectedValue = dr("Unit_ID").ToString()
            'End If

            '-- WATER
        Else
            txtWatercraftDescription.Text = dr("VehicleDesc").ToString()
            txtWatercraftPowerInput.Text = dr("PowerInput").ToString()
            txtWatercraftWarranty.Text = dr("Warranty").ToString()
            txtWatercraftMake.Text = dr("VehicleMake").ToString()
            txtWatercraftQuantity.Text = dr("Qty").ToString()
            txtWatercraftType.Text = dr("VehicleType").ToString()
            txtWatercraftColor.Text = dr("VehicleColor").ToString()
            txtWatercraftAcqDate.Text = dr("dDate").ToString()
            txtWatercraftMarketValue.Text = dr("MarketValue").ToString()
            txtWatercraftAcqCost.Text = dr("Cost").ToString()
            txtWatercraftNoYears.Text = dr("NoofYears").ToString()
            txtWatercraftDepRate.Text = dr("DepRate").ToString()
            txtWatercraftUsefulLife.Text = dr("UsefulLife").ToString()
            txtWatercraftDepValue.Text = dr("DepValue").ToString()
            txtWatercraftSalvageValue.Text = dr("SalvageValue").ToString()

            txtWatercraftMMSI.Text = dr("MMSI").ToString()
            txtWatercraftCallSign.Text = dr("CallSign").ToString()
            txtWatercraftImoNo.Text = dr("IMOno").ToString()
            txtWatercraftHullMaterial.Text = dr("HullMaterial").ToString()
            txtWatercraftNoofMast.Text = dr("NoofMast").ToString()
            txtWatercraftNoofDecks.Text = dr("NoofDecks").ToString()
            txtWatercraftNoofEngine.Text = dr("NoofEngine").ToString()
            txtWatercraftMainEngine.Text = dr("MainEngine").ToString()
            txtWatercraftHorsePower.Text = dr("HorsePower").ToString()
            txtWaterCraftGRT.Text = dr("Grt").ToString()
            txtWatercraftNRT.Text = dr("Nrt").ToString()
            txtWatercraftLOA.Text = dr("Loa").ToString()
            txtWatercraftBreadth.Text = dr("Breadth").ToString()
            txtWaterCraftCarryingCapacity.Text = dr("CarryingCapacity").ToString()
        End If

        lblProperty_ID.Text = dr("Property_ID").ToString()
        lblMotor_InfoId.Text = dr("Motor_InfoId").ToString()
        lblMotorID.Text = dr("MotorID").ToString()
        lblItem_ID.Text = hdnItemNo.Value
        lblPropertyDetai_ID.Text = dr("PropertyDetai_ID").ToString()
        btnSave.Enabled = True
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub


    Protected Sub ClearTextBoxes()


        Dim ctxtBoxes As TextBox() = {txtVehicleName, txtVehiclePowerInput, txtVehiclePowerInput, txtVehicleWarranty, txtVehicleMake, txtVehicleQuantity, txtVehicleType, txtBrand, txtSpecification,
                            txtVehicleColor, txtEAcqDate, txtVehicleMarketValue, txtVehicleAcqCost, txtVehicleNoYears, txtVehicleDepRate, txtVehicleUsefullife, txtVehicleDepValue, txtVehicleSalvageValue,
                            txtRemarks, txtVehicleDesc}

        For Each txtBoxes As TextBox In ctxtBoxes
            txtBoxes.Text = String.Empty
        Next
        'ddVehicleUnit.SelectedIndex = 0

        Dim ctxtBoxes1 As TextBox() = {txtWatercraftDescription, txtWatercraftPowerInput, txtWatercraftWarranty, txtWatercraftMake, txtWatercraftQuantity, txtWatercraftType,
                txtWatercraftColor, txtWatercraftAcqDate, txtWatercraftMarketValue, txtWatercraftAcqCost, txtWatercraftNoYears, txtWatercraftDepRate,
                txtWatercraftUsefulLife, txtWatercraftDepValue, txtWatercraftSalvageValue, txtWatercraftMMSI, txtWatercraftCallSign, txtWatercraftImoNo,
                txtWatercraftHullMaterial, txtWatercraftNoofMast, txtWatercraftNoofDecks, txtWatercraftNoofEngine, txtWatercraftMainEngine,
                txtWatercraftHorsePower, txtWaterCraftGRT, txtWatercraftNRT, txtWatercraftLOA, txtWatercraftBreadth, txtWaterCraftCarryingCapacity}

        For Each txtBoxes As TextBox In ctxtBoxes1
            txtBoxes.Text = String.Empty
        Next
        'ddVehicleUnit.SelectedIndex = 0


    End Sub

    Protected Sub IsEnabledTextBoxes(isEnabled As Boolean)

        If drpSubClass.SelectedIndex = 0 Then
            Dim ctxtBoxes As TextBox() = {txtVehicleName, txtVehiclePowerInput, txtVehiclePowerInput, txtVehicleWarranty, txtVehicleMake, txtVehicleType, txtBrand, txtSpecification,
                        txtVehicleColor, txtEAcqDate, txtVehicleMarketValue, txtVehicleAcqCost, txtVehicleNoYears, txtVehicleDepRate, txtVehicleDepValue, txtVehicleSalvageValue}

            For Each txtBoxes As TextBox In ctxtBoxes
                txtBoxes.Enabled = isEnabled
            Next
        Else
            Dim ctxtBoxes1 As TextBox() = {txtWatercraftDescription, txtWatercraftPowerInput, txtWatercraftWarranty, txtWatercraftMake, txtWatercraftQuantity, txtWatercraftType,
            txtWatercraftColor, txtWatercraftAcqDate, txtWatercraftMarketValue, txtWatercraftAcqCost, txtWatercraftNoYears, txtWatercraftDepRate,
            txtWatercraftUsefulLife, txtWatercraftDepValue, txtWatercraftSalvageValue, txtWatercraftMMSI, txtWatercraftCallSign, txtWatercraftImoNo,
            txtWatercraftHullMaterial, txtWatercraftNoofMast, txtWatercraftNoofDecks, txtWatercraftNoofEngine, txtWatercraftMainEngine,
            txtWatercraftHorsePower, txtWaterCraftGRT, txtWatercraftNRT, txtWatercraftLOA, txtWatercraftBreadth, txtWaterCraftCarryingCapacity}

            For Each txtBoxes As TextBox In ctxtBoxes1
                txtBoxes.Enabled = isEnabled
            Next
        End If

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
                    cell.ColumnSpan = 5
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


    Private Function ValidateVehicleSelections() As Boolean

        If ddGeneralAccount.SelectedValue Is Nothing OrElse
           ddGeneralAccount.SelectedValue = "" OrElse
           ddGeneralAccount.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
                Me.UpdatePanel1,
                "Please select General Account."
            )

            Return False

        End If

        If DrpVehicleName.SelectedValue Is Nothing OrElse
               DrpVehicleName.SelectedValue = "" OrElse
               DrpVehicleName.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
                    Me.UpdatePanel1,
                    "Please select Name."
                )

            Return False

        End If


        'If IsWatercraftSelected() Then

        '    If drpWatercraftName.SelectedValue Is Nothing OrElse
        '       drpWatercraftName.SelectedValue = "" OrElse
        '       drpWatercraftName.SelectedValue = "0" Then

        '        MsgeBox.CreateMessageAlertInUpdatePanel(
        '            Me.UpdatePanel1,
        '            "Please select Name."
        '        )

        '        Return False

        '    End If

        'Else

        '    If DrpVehicleName.SelectedValue Is Nothing OrElse
        '       DrpVehicleName.SelectedValue = "" OrElse
        '       DrpVehicleName.SelectedValue = "0" Then

        '        MsgeBox.CreateMessageAlertInUpdatePanel(
        '            Me.UpdatePanel1,
        '            "Please select Name."
        '        )

        '        Return False

        '    End If

        'End If

        Return True
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
            txtVehicleUsefullife.Text = "0"
        Else
            txtVehicleUsefullife.Text = usefulLife
        End If


    End Sub

End Class