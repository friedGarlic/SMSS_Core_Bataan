Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing



Partial Class Inventory_Encoding_Furnitures
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim objx As New AccessRule
    Dim counts As Integer = 0
    Private objFurnitureInfo As New ConsolidatedPropertySaving.TbFurniture_Info
    Private objFurnitureDtl As New ConsolidatedPropertySaving.TbFurniture_Dtl


    Protected Sub Inventory_Encoding_Furnitures_Load(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles Me.Load

        If Not Page.IsPostBack Then

            If String.IsNullOrWhiteSpace(txtDate.Text) Then
                txtDate.Text = DateTime.Now.ToString("MM-dd-yyyy")
            End If

            Try

                Dim sqlClass As String =
                "SELECT " &
                "    a.ClassificationId, " &
                "    a.ClassificationName " &
                "FROM dbo.tbl_Classification AS a " &
                "INNER JOIN dbo.tblclassmatrix AS b " &
                "    ON a.ClassificationId = b.classificationid " &
                "WHERE a.isenable = 1 " &
                "AND a.ClassificationName LIKE '%Fixtures' " &
                "GROUP BY " &
                "    a.ClassificationId, " &
                "    a.ClassificationName, " &
                "    a.SeqNo " &
                "ORDER BY a.SeqNo"

                Dim dtClass As DataTable = objDerived.GetDataTable(
                sqlClass,
                CommandType.Text
            )

                ddClass.DataSource = dtClass
                ddClass.DataTextField = "ClassificationName"
                ddClass.DataValueField = "ClassificationId"
                ddClass.DataBind()

                If dtClass IsNot Nothing AndAlso
               dtClass.Rows.Count > 0 Then

                    ddClass.SelectedIndex = 0
                    Session("ClassificationID") =
                    ddClass.SelectedValue

                Else

                    Session("ClassificationID") = "0"

                End If

                ddClass.AutoPostBack = True
                ddGA.AutoPostBack = True
                ddSubClass.AutoPostBack = True
                drpName.AutoPostBack = True

                Session("Item_ID") = 0

                loadFurnitureFixture()

            Catch ex As Exception

                Session("ClassificationID") = "0"
                Session("Item_ID") = 0

                ddGA.Items.Clear()
                ddGA.Items.Insert(
                0,
                New ListItem("Select", "0")
            )
                ddGA.Enabled = True

                ddSubClass.Items.Clear()
                ddSubClass.Items.Insert(
                0,
                New ListItem("No Subclass", "0")
            )
                ddSubClass.Enabled = True

                ClearItemDesc()

                AddTrace(
                "Furniture dropdown initialization error: " &
                ex.Message
            )

            End Try

            BindGrid()

            Session.Remove("TempPropertyList")

            AddTrace(
            "ClassificationID: " &
            Convert.ToString(Session("ClassificationID"))
        )

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

    ' === Helpers for Furniture & Fixtures cascade ===
    Private Sub BindSubClassifications_FF()
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
        ddGA.SelectedValue,
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

    End Sub

    Private Sub BindGAAccounts_FF()
        ddGA.Items.Clear()

        Dim classificationID As Integer = 0

        Integer.TryParse(
        Convert.ToString(Session("ClassificationID")),
        classificationID
    )

        If classificationID = 0 AndAlso
       ddClass.SelectedValue IsNot Nothing AndAlso
       ddClass.SelectedValue <> "" Then

            Integer.TryParse(
            ddClass.SelectedValue,
            classificationID
        )

            Session("ClassificationID") =
            classificationID.ToString()

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

        AddTrace(
        "BindGAAccounts_FF ClassificationID: " &
        classificationID.ToString()
    )

    End Sub
    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub


    ' === Events for Furniture & Fixtures dropdown cascade ===
    Protected Sub ddClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles ddClass.SelectedIndexChanged

        If ddClass.SelectedValue Is Nothing OrElse
       ddClass.SelectedValue = "" Then

            Session("ClassificationID") = "0"

        Else

            Session("ClassificationID") =
            ddClass.SelectedValue

        End If

        BindGAAccounts_FF()

        ddSubClass.Items.Clear()
        ddSubClass.Items.Insert(
        0,
        New ListItem("No Subclass", "0")
    )
        ddSubClass.Enabled = True

        ClearItemDesc()

        hdnGAId.Value = "0"

        ViewState("PropertyInfoDT") = Nothing
        BindGrid()

        loadEquipmentLedger()

        AddTrace(
        "ddClass: " &
        Convert.ToString(ddClass.SelectedValue)
    )

    End Sub

    Protected Sub ddSubClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles ddSubClass.SelectedIndexChanged

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"

        drpNamePopulate()

        ViewState("PropertyInfoDT") = Nothing
        BindGrid()

        loadEquipmentLedger()

        AddTrace(
        "ddSubClass: " &
        Convert.ToString(ddSubClass.SelectedValue)
    )

    End Sub

    Protected Sub ddGA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddGA.SelectedIndexChanged
        ' Keep your hidden field in sync (does not remove your original hdnGAId assignment elsewhere)
        If Not String.IsNullOrWhiteSpace(ddGA.SelectedValue) Then
            hdnGAId.Value = ddGA.SelectedValue
        End If
        AddTrace("ddGA: " & ddGA.SelectedValue)
        BindSubClassifications_FF()

        ' If GA affects the ledger/details, refresh them here:
        loadEquipmentLedger()
        drpNamePopulate()
    End Sub




    Private Class TempPropertyDetail
        Public Property PropertyNo As String
        Public Property SerialNo As String
        Public Property FloorLocation As String
        Public Property RoomLocation As String
        Public Property PropertyDtl_ID As String
    End Class

    Public Sub loadFurnitureFixture()

        BindGAAccounts_FF()

        ddSubClass.Items.Clear()
        ddSubClass.Items.Insert(
        0,
        New ListItem("No Subclass", "0")
    )
        ddSubClass.Enabled = True

        ClearItemDesc()

        LoadBuildings()
        loadwarehouse()

        hdnGAId.Value = "0"
        hdnItemNo.Value = "0"

        Session("Item_ID") = 0

        loadEquipmentLedger()

    End Sub

    Public Sub drpNamePopulate()

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
        ddGA.SelectedValue,
        gaID
    )

        Integer.TryParse(
        ddSubClass.SelectedValue,
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

        drpName.DataSource = dtItemDesc
        drpName.DataTextField = "ItemDescription"
        drpName.DataValueField = "Item_ID"
        drpName.DataBind()

        drpName.Enabled = True

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"
        hdnGAId.Value = ddGA.SelectedValue

    End Sub

    Protected Sub drpInstalledAtFurNiture_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each r As GridViewRow In grdPropertyInfo.Rows
            Dim drp As DropDownList = CType(r.FindControl("drpInstalledAtFurNiture"), DropDownList)
            Dim txtLoc As TextBox = CType(r.FindControl("txtPIFloorLocation"), TextBox)

            If drp.SelectedItem Is Nothing Then Continue For

            If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                txtLoc.Enabled = True
                txtLoc.Text = ""
            Else
                txtLoc.Enabled = False
                Dim sql = "SELECT CONCAT_WS(', ', COALESCE(Address,''), COALESCE(Barangay,''), COALESCE(Area1,'')) AS Address FROM AMS.TbBuilding_Dtl WHERE BuildingId=" & drp.SelectedValue
                Dim dt = objDerived.GetDataTable(sql, CommandType.Text)
                txtLoc.Text = If(dt.Rows.Count > 0, dt.Rows(0)(0).ToString(), "")
            End If
        Next
        ModalPopupExtender2.Show()
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

            ViewState("PropertyInfoDT") = Nothing
            BindGrid()

            loadEquipmentLedger()
            Exit Sub

        End If

        Session("Item_ID") = drpName.SelectedValue

        hdnItemNo.Value = drpName.SelectedValue
        hdnGAId.Value = ddGA.SelectedValue

        LoadBuildings()
        loadwarehouse()

        loadEquipmentLedger()

        ViewState("PropertyInfoDT") = Nothing
        BindGrid()

        loadUnit()
        loadUsefulLife()

        AddTrace(
        "drpName Item_ID: " &
        drpName.SelectedValue
    )

    End Sub


    Private Function ValidateFurnitureSelections() As Boolean

        If ddGA.SelectedValue Is Nothing OrElse
       ddGA.SelectedValue = "" OrElse
       ddGA.SelectedValue = "0" Then

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

    Protected Sub loadEquipmentInformation_from_drpName()
        Dim CYear As String = "CY" & Year(txtDate.Text)
        Dim itemid As String


        LoadBuildings()
        loadwarehouse()
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
            hdnGAId.Value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
            txtName.Text = dt.Rows(0).Item("Name").ToString
            txtequipmentdesciption.Text = dt.Rows(0).Item("description").ToString
            txtequipmentpowerinput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtequipmentdimension.Text = objDerived.GetValue("select e.Dimension from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            'txtequipmentareacapacity.Text = objDerived.GetValue("select e.AreaCapacity from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtequipmentmodel.Text = objDerived.GetValue("select e.Model from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtequipmentwaranty.Text = objDerived.GetValue("select e.Warranty from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtSpecification.Text = objDerived.GetValue("select e.Specification from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtEAcqDate.Text = objDerived.GetValue("select c.Property_Date from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtEAcqCost.Text = objDerived.GetValue("select c.Cost from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

            txtEMarketValue.Text = dt.Rows(0).Item(CYear).ToString
            'Dim DA As DateTime
            'DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")

            txtNoYears.Text = " "
            txtequipmentdepreciatedvalue.Text = FormatNumber(0, 2)
            lblequipmentdepreciatedRate.Text = " "
            lblequipmentdepreciatedRate.ReadOnly = False



            '''--------------------location
            Dim location As String
            location = objDerived.GetValue("select Location from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Dtl  as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
            If location IsNot Nothing Then
                Dim locationsplit As String() = location.Split("-")
                If location.Contains("Bay") Then
                    txtEquipmentBay.Text = locationsplit(1)
                ElseIf location.Contains("Column") Then
                    txtEquipmentColumn.Text = locationsplit(1)
                ElseIf location.Contains("Floor") Then
                    txtEquipmentFloor.Text = locationsplit(1)
                ElseIf location.Contains("Room") Then
                    txtEquipmentRoom.Text = locationsplit(1)
                ElseIf location.Contains("Shelves") Then
                    txtEquipmentShelves.Text = locationsplit(1)
                ElseIf location.Contains("Rack") Then
                    txtEquipmentRack.Text = locationsplit(1)
                ElseIf location.Contains("Bin") Then
                    txtEquipmentBin.Text = locationsplit(1)
                End If

                Dim warehouse As String
                warehouse = objDerived.GetValue("select warehouseid from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbEquipment_Dtl  as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)

                drpEquipmentWarehouse.SelectedValue = warehouse


                Dim dt1 As New DataTable
                dt1 = objDerived.GetDataTable("[AMS].[sp_View_Encoding_v2] 'Furnitures','" & itemid & "'", CommandType.Text)
                If dt1.Rows.Count > 0 Then
                    txtequipmentdesciption.Text = dt1.Rows(0).Item("Description").ToString
                    txtequipmentSerialNumber.Text = dt1.Rows(0).Item("SerialNo").ToString
                    drpInstalledAtBuilding.SelectedValue = dt1.Rows(0).Item("BuildingId").ToString
                    'drpUnit.SelectedValue = dt1.Rows(0).Item("Unit_ID").ToString
                    txtQuantity.Text = dt1.Rows(0).Item("DebitQty").ToString
                    txtequipmentdimension.Text = dt1.Rows(0).Item("Dimension").ToString
                    txtequipmentmodel.Text = dt1.Rows(0).Item("Model").ToString
                    txtSpecification.Text = dt1.Rows(0).Item("Specification").ToString
                    txtequipmentwaranty.Text = dt1.Rows(0).Item("Warranty").ToString
                    txtBrand.Text = dt1.Rows(0).Item("Brand").ToString
                    txtEAcqDate.Text = dt1.Rows(0).Item("Property_Date").ToString
                    txtEAcqCost.Text = dt1.Rows(0).Item("Cost").ToString
                    lblequipmentdepreciatedRate.Text = dt1.Rows(0).Item("DepreciationRate").ToString
                    txtequipmentdepreciatedvalue.Text = dt1.Rows(0).Item("DepreciationValue").ToString
                    txtEMarketValue.Text = dt1.Rows(0).Item("MarketValue").ToString
                    txtNoYears.Text = dt1.Rows(0).Item("NoYears").ToString
                    txtUsefulLife.Text = dt1.Rows(0).Item("UsefulLife").ToString
                    txtSalvageValue.Text = dt1.Rows(0).Item("SalvageValue").ToString


                    hf_FurInfoId.Value = dt1.Rows(0).Item("FurnitureInfoId").ToString
                    hf_FurId.Value = dt1.Rows(0).Item("FurnitureId").ToString
                    hf_PropertyDetai_ID.Value = dt1.Rows(0).Item("PropertyDetai_ID").ToString
                    hf_Property_ID.Value = dt1.Rows(0).Item("Property_ID").ToString
                    hf_Item_ID.Value = dt1.Rows(0).Item("Item_ID").ToString
                End If




                drpUnit.Items.FindByValue(dt.Rows(0).Item(9)).Selected = True
                btnSave.Enabled = True
                btnCancel.Enabled = True

            End If
        End If
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

    Public Sub LoadBuildings()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        drpInstalledAtBuilding.DataSource = dt
        drpInstalledAtBuilding.DataTextField = ("Name")
        drpInstalledAtBuilding.DataValueField = ("BuildingId")
        drpInstalledAtBuilding.DataBind()
        drpInstalledAtBuilding.Items.Insert(0, New ListItem("N/A"))
    End Sub

    Protected Sub LoadEquipDTL()

        For Each control As Control In Me.Controls
            If TypeOf control Is TextBox Then
                DirectCast(control, TextBox).Text = String.Empty
            ElseIf TypeOf control Is DropDownList Then
                DirectCast(control, DropDownList).ClearSelection()
            End If
        Next

    End Sub

    Protected Sub OnDataBound(sender As Object, e As EventArgs)

    End Sub
    Protected Sub grdLedger1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtAccount As New DataTable
        If hdnItemNo.Value = "" Then
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & Session("Item_ID") & "' ", CommandType.Text)

        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
        End If
        grdLedger1.PageIndex = e.NewPageIndex
        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
    End Sub
    Protected Sub grdLedger1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType <> DataControlRowType.DataRow Then Exit Sub

        Dim TransType As String = ""

        If e.Row.DataItem IsNot Nothing Then
            TransType = DataBinder.Eval(e.Row.DataItem, "Trans_Type").ToString().Trim()
        End If

        Dim cbInspection As CheckBox = TryCast(e.Row.FindControl("cbInspection"), CheckBox)

        If cbInspection IsNot Nothing Then
            If TransType = "Starting Inventory" Then
                cbInspection.Enabled = True
            Else
                cbInspection.Checked = False
                cbInspection.Enabled = False
            End If
        End If

        Dim blankIfZero As Action(Of Integer, String) =
    Sub(idx As Integer, zero As String)
        If idx < e.Row.Cells.Count AndAlso e.Row.Cells(idx).Text = zero Then
            e.Row.Cells(idx).Text = " "
        End If
    End Sub

        blankIfZero(9, "0")
        blankIfZero(10, "0.00")
        blankIfZero(11, "0")
        blankIfZero(12, "0.00")

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
        If hdnItemNo.Value = "" Then
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)

        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
        End If

        btnSave.Text = "SAVE"

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))

        Else

        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
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

    Public Sub SAVE()

        Dim a1 As String
        Dim gaId As Integer = 0
        Integer.TryParse(Convert.ToString(ddGA.SelectedValue), gaId)



        ' 2) Check each row in memory for valid property info
        Dim dt As DataTable = TryCast(ViewState("PropertyInfoDT"), DataTable)




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

        If String.IsNullOrWhiteSpace(txtQuantity.Text) Then
            missingFields.Add("Quantity")
        End If

        'If String.IsNullOrWhiteSpace(txtRemarks.Text) Then
        '    missingFields.Add("Remarks")
        'End If
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
            objDerived.Execute("Update dbo.m_item set unit_id = " & drpUnit.SelectedItem.Value & " where item_id = " & hdnItemNo.Value, CommandType.Text)

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
                .GA_ID = gaId
                .DonationRemarks = ""
                .Qty = txtQuantity.Text
                .Balance = txtQuantity.Text
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

            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Property SET ClassificationID = '" & ddClass.SelectedValue & "',SubClassificationID = '" & ddSubClass.SelectedValue & "'  WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

            For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1

                ' Get per-row controls we need
                Dim ddlInstalled As DropDownList = TryCast(grdPropertyInfo.Rows(i).FindControl("drpInstalledAtFurNiture"), DropDownList)
                Dim tbLocation As TextBox = TryCast(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox)


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
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                    .Barcode = " "
                    .Amount = CType(txtEAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    .Details = txtSpecification.Text
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                    Session("dep") = CType(grdPropertyInfo.Rows(i).FindControl("drpDepartment"), DropDownList).Text

                    ' === NEW: align with reference (Intangible) ===
                    .MarketValue = CDec(If(String.IsNullOrWhiteSpace(txtEMarketValue.Text), "0", txtEMarketValue.Text.Replace(",", "")))
                    .InstalledAt = If(ddlInstalled IsNot Nothing AndAlso ddlInstalled.SelectedItem IsNot Nothing, ddlInstalled.SelectedItem.Text, String.Empty)
                    .Location = If(tbLocation IsNot Nothing, tbLocation.Text, String.Empty)

                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = Prop_Dtl.save()


                Dim info_id As Integer

                With objFurnitureInfo
                    .FurnitureInfoId = 0
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = PropDtl_ID
                    .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text ' txtequipmentSerialNumber.Text 
                    .Name = txtName.Text
                    .Description = txtequipmentdesciption.Text
                    .DepreciationRate = lblequipmentdepreciatedRate.Text
                    .Dimension = txtequipmentdimension.Text
                    .AreaCapacity = ""
                    .Model = txtequipmentmodel.Text
                    .Warranty = txtequipmentwaranty.Text
                    .DepreciationValue = txtequipmentdepreciatedvalue.Text
                    .Specification = txtSpecification.Text
                    .FloorLocation = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text 'txtMachineryFloorLocation.Text
                    .RoomLocation = ""
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .SalvalgeValue = txtSalvageValue.Text
                    .AccountablePerson = ""


                End With

                Dim furn_info_id As Integer
                furn_info_id = objFurnitureInfo.save()

                objDerived.GetRecords("UPDATE AMS.TbFurniture_Info SET Received_ID = 0, Received_Dtl_ID = 0 WHERE FurnitureInfoId = '" & furn_info_id & "'", CommandType.Text)
                objDerived.GetRecords(
                    "UPDATE AMS.TbFurniture_Info SET " &
                    "Remarks = '" & txtRemarks.Text.Replace("'", "''") & "', " &
                    "Property_ID = " & PropHdr_ID & ", " &
                    "Unit_ID = " & drpUnit.SelectedValue & ", " &
                    "Specification = CAST('" & txtSpecification.Text.Replace("'", "''") & "' AS VARCHAR(MAX)), " &
                    "Brand = '" & txtBrand.Text.Replace("'", "''") & "' " &
                    "WHERE FurnitureInfoId = " & furn_info_id,
                    CommandType.Text
                )

                With objFurnitureDtl
                    .FurnitureId = 0
                    .FurnitureInfoId = furn_info_id
                    .Property_Dtl_ID = PropDtl_ID
                    .Condition = ""
                    .MarketValue = If(String.IsNullOrWhiteSpace(txtEMarketValue.Text), 0D, CType(txtEMarketValue.Text, Decimal))

                    .Location = CType(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox).Text
                    .Status = "Accepted"
                    .PowerInput = txtequipmentpowerinput.Text
                    Dim drp As DropDownList
                    drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtFurNiture"), DropDownList)

                    If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                        .BuildingId = 0
                    Else
                        .BuildingId = drp.SelectedValue
                    End If

                    .MaintenanceContractor = ""
                    .MaintenanceContactPerson = ""
                    .MaintenanceContactNo = ""
                    .NoYears = txtNoYears.Text
                    .UsefulLife = If(String.IsNullOrWhiteSpace(txtUsefulLife.Text), 0, CLng(txtUsefulLife.Text))

                End With
                objFurnitureDtl.save()


            Next

            Dim Prop_Ledger As New t_PropertyLedger

            With Prop_Ledger
                .Ledger_ID = 0
                .PropertyNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                .SerialNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                .Trans_Type = "Manual Entry"
                .dDate = txtEAcqDate.Text
                .Ref = ""
                .AccountablePerson = ""
                .Department = 0
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = hdnItemNo.Value
                .DebitQty = txtQuantity.Text
                .DebitCost = txtQuantity.Text * CType(txtEAcqCost.Text, Decimal)
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
                Convert.ToInt32(txtQuantity.Text)

                Dim EquipmentAcquisitionCost As Decimal =
                CType(txtEAcqCost.Text.Replace(",", ""), Decimal)

                Dim NewEquipmentCost As Decimal =
                EquipmentAcquisitionCost * NewEquipmentQty

                .BalanceQty = Eqty + NewEquipmentQty
                .BalanceCost = Eqbalance + NewEquipmentCost


                .Property_ID = PropHdr_ID
            End With
            Prop_Ledger.save()



            ''btnSave.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            '  multiviewselected()
            ' loadEquipmentList()
            '  loadEquipmentInformation()



            'loadEquipmentInformation_from_drpName()
            loadEquipmentLedger()
        End If


        'REBALANCE FROM EDITED ROW ABOVE
        'objDerived.GetDataTable("Exec [AMS].[ReBalanceLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
    End Sub

    Private Function GetNumericOrZero(input As String) As Decimal
        Dim val As Decimal
        Return If(Decimal.TryParse(input.Replace(",", "").Trim(), val), val, 0D)
    End Function



    Protected Sub btnSave_Click(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If btnSave.Text = "SAVE" Then

            If Not ValidateFurnitureSelections() Then
                Exit Sub
            End If

            hdnGAId.Value = ddGA.SelectedValue
            hdnItemNo.Value = drpName.SelectedValue
            Session("Item_ID") = drpName.SelectedValue

            SAVE()

            loadEquipmentLedger()

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

            IsEnabledTextBox(True)

        ElseIf btnSave.Text = "UPDATE" Then

            If Not ValidateFurnitureSelections() Then
                Exit Sub
            End If

            hdnGAId.Value = ddGA.SelectedValue
            hdnItemNo.Value = drpName.SelectedValue
            Session("Item_ID") = drpName.SelectedValue

            UPDATE()

            btnSave.Text = "SAVE"

            ClearTextBoxes()
            IsEnabledTextBox(True)

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

            loadEquipmentLedger()

        End If
        btnSave.Enabled = False
    End Sub

    Public Sub UPDATE()
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
            Dim ddlInstalled As DropDownList = TryCast(r.FindControl("drpInstalledAtFurNiture"), DropDownList)
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
        Dim ledger_Id As Long = 0
        If Session("Ledger_ID") IsNot Nothing Then
            Long.TryParse(Session("Ledger_ID").ToString(), ledger_Id)
        End If

        Dim property_Id As Long = 0
        If Session("Property_ID") IsNot Nothing Then
            Long.TryParse(Session("Property_ID").ToString(), property_Id)
        End If
        AddTrace("Property_ID: " & Session("Property_ID"))
        AddTrace("property_Id: " & property_Id)
        AddTrace("ledger_Id: " & ledger_Id)

        Dim buildingId As Long = 0
        If Not String.IsNullOrEmpty(firstRowBuildingId) Then
            Long.TryParse(firstRowBuildingId, buildingId)
        Else
            Long.TryParse(drpInstalledAtBuilding.SelectedValue, buildingId)
        End If

        Dim unitId As Long = 0
        Long.TryParse(drpUnit.SelectedValue, unitId)

        objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", DBNull.Value)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", DBNull.Value)
        objDerived.cmd.Parameters.AddWithValue("@FurnitureInfoId", hf_FurInfoId.Value)
        objDerived.cmd.Parameters.AddWithValue("@Name", drpName.SelectedItem.Text)
        objDerived.cmd.Parameters.AddWithValue("@Description", txtequipmentdesciption.Text)
        objDerived.cmd.Parameters.AddWithValue("@Specification", txtSpecification.Text)
        objDerived.cmd.Parameters.AddWithValue("@SerialNo", txtequipmentSerialNumber.Text)
        objDerived.cmd.Parameters.AddWithValue("@Dimension", txtequipmentdimension.Text)
        objDerived.cmd.Parameters.AddWithValue("@Model", txtequipmentmodel.Text)
        objDerived.cmd.Parameters.AddWithValue("@Warranty", txtequipmentwaranty.Text)
        objDerived.cmd.Parameters.AddWithValue("@DepreciationRate", lblequipmentdepreciatedRate.Text)

        objDerived.cmd.Parameters.AddWithValue("@DepreciationValue", GetNumericOrZero(txtequipmentdepreciatedvalue.Text))
        objDerived.cmd.Parameters.AddWithValue("@SalvageValue", GetNumericOrZero(txtSalvageValue.Text))


        objDerived.cmd.Parameters.AddWithValue("@Property_ID", property_Id)
        objDerived.cmd.Parameters.AddWithValue("@Property_code", txtequipmentSerialNumber.Text)
        objDerived.cmd.Parameters.AddWithValue("@Qty", txtQuantity.Text)

        objDerived.cmd.Parameters.AddWithValue("@Property_Date", CDate(txtEAcqDate.Text))

        objDerived.cmd.Parameters.AddWithValue("@Cost", GetNumericOrZero(txtEAcqCost.Text))

        objDerived.cmd.Parameters.AddWithValue("@FurnitureId", hf_FurId.Value)
        ' Convert BuildingId to Long (bigint)

        If Not String.IsNullOrEmpty(drpInstalledAtBuilding.SelectedItem.Value) Then
            Long.TryParse(drpInstalledAtBuilding.SelectedItem.Value, buildingId)
        End If
        objDerived.cmd.Parameters.AddWithValue("@BuildingId", buildingId)

        objDerived.cmd.Parameters.AddWithValue("@MarketValue", GetNumericOrZero(txtEMarketValue.Text))
        objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtUsefulLife.Text)

        objDerived.cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text)


        objDerived.cmd.Parameters.AddWithValue("@Item_ID", hf_Item_ID.Value)
        objDerived.cmd.Parameters.AddWithValue("@Unit_ID", unitId)

        For Each param As SqlParameter In objDerived.cmd.Parameters
            System.Diagnostics.Debug.WriteLine("Param: " & param.ParameterName & ", Value: " & Convert.ToString(param.Value) & ", Type: " & If(param.Value IsNot Nothing, param.Value.GetType().ToString(), "NULL"))
        Next


        objDerived.Execute("AMS.sp_Edit_Furnitures_Fixes_07212022", CommandType.StoredProcedure)
        ''here 11
        'MsgBox(hdnItemNo.Value)

        Dim dtAccount As New DataTable
        Dim cb1 As CheckBox
        Dim LedgerID As Long
        Dim PropertyID As String
        Dim IsIssuance As String

        dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        For i As Integer = 0 To dtAccount.Rows.Count - 1
            cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

            LedgerID = dtAccount.Rows(i).Item("Ledger_ID").ToString()
            PropertyID = dtAccount.Rows(i).Item("Property_ID").ToString()
            IsIssuance = dtAccount.Rows(i).Item("Trans_type").ToString()

            If cb1.Visible AndAlso cb1.Checked Then

                If IsIssuance = "Issuance" Then

                    objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] " &
                                                   "SET CreditCost = '" & txtEAcqCost.Text.Replace(",", "") & "', " &
                                                   "CreditUnit = '" & drpUnit.SelectedValue & "', " &
                                                   "BalanceUnit = '" & drpUnit.SelectedValue & "', " &
                                                   "dDate = '" & txtEAcqDate.Text & "' " &
                                                   "WHERE Ledger_ID = '" & LedgerID & "' ", CommandType.Text)
                Else

                    Dim unitCost As Decimal = Convert.ToDecimal(txtEAcqCost.Text.Replace(",", ""))
                    Dim quantity As Integer = Convert.ToInt32(txtQuantity.Text)

                    ' Calculate debit cost
                    Dim debitCost As Decimal = unitCost * quantity
                    Dim Unit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)
                    objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] " &
                      "SET DebitQty = '" & txtQuantity.Text & "', " &
                      "DebitCost = '" & debitCost & "', " &
                      "DebitUnit = '" & Unit & "', " &
                      "BalanceQty = '" & txtQuantity.Text & "', " &
                      "BalanceCost = '" & debitCost & "', " &
                      "BalanceUnit = '" & Unit & "', " &
                      "dDate = '" & txtEAcqDate.Text & "' " &
                      "WHERE Ledger_ID = '" & LedgerID & "' ", CommandType.Text)
                End If


            End If
        Next




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
                Dim ddlInstalled As DropDownList = TryCast(row.FindControl("drpInstalledAtFurNiture"), DropDownList)
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


        'REBALANCE FROM EDITED ROW ABOVE
        'objDerived.GetDataTable("Exec [AMS].[ReBalanceLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

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


    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtQuantity.Text) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
            Exit Sub
        End If

        Dim qty As Integer
        If Not Integer.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must be a positive number.")
            Exit Sub
        End If

        ' EDIT flow: reuse cached grid or repopulate from DB
        If ViewState("IsEditMode") IsNot Nothing AndAlso CBool(ViewState("IsEditMode")) Then
            If ViewState("PropertyInfoDT") Is Nothing AndAlso Session("Ledger_ID") IsNot Nothing Then
                PopulatePropertyInfoFromLedger(CLng(Session("Ledger_ID")))
            End If
        End If

        EnsurePropertyInfoTable(qty)

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
                            Dim txtSerialNumber As TextBox = CType(row1.FindControl("txtSerialNumber"), TextBox)
                            Dim txtPIFloorLocation As TextBox = CType(row1.FindControl("txtPIFloorLocation"), TextBox)
                            Dim drpInstalledAtFurNiture As DropDownList = CType(row1.FindControl("drpInstalledAtFurNiture"), DropDownList)

                            ' Clear other fields (check if controls exist)
                            If txtSerialNumber IsNot Nothing Then txtSerialNumber.Text = String.Empty
                            If txtPIFloorLocation IsNot Nothing Then txtPIFloorLocation.Text = String.Empty
                            If drpInstalledAtFurNiture IsNot Nothing Then
                                drpInstalledAtFurNiture.ClearSelection()
                                ' Set default to N/A
                                Dim naItem As ListItem = drpInstalledAtFurNiture.Items.FindByText("N/A")
                                If naItem IsNot Nothing Then
                                    drpInstalledAtFurNiture.SelectedValue = naItem.Value
                                End If
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

        TogglePropertyNoEnabled()
        ModalPopupExtender2.Show()
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



    ' Call this when you need to create or resize the grid’s in-memory data
    Private Sub EnsurePropertyInfoTable(rowCount As Integer)
        Dim dt As DataTable = TryCast(ViewState("PropertyInfoDT"), DataTable)
        If dt Is Nothing Then
            dt = New DataTable()
            dt.Columns.Add("PropertyDetai_ID", GetType(Long))
            dt.Columns.Add("PropertyNo", GetType(String))
            dt.Columns.Add("SerialNo", GetType(String))
            dt.Columns.Add("InstalledAt", GetType(String))   ' BuildingId
            dt.Columns.Add("FloorLocation", GetType(String))
        End If

        ' Grow/shrink rows to match Quantity
        While dt.Rows.Count < rowCount
            dt.Rows.Add(0, "", "", "", "")
        End While
        While dt.Rows.Count > rowCount
            dt.Rows.RemoveAt(dt.Rows.Count - 1)
        End While

        ViewState("PropertyInfoDT") = dt
        BindPropertyInfoGrid()
    End Sub

    Private Sub BindPropertyInfoGrid()
        Dim dt = TryCast(ViewState("PropertyInfoDT"), DataTable)
        grdPropertyInfo.DataSource = dt
        grdPropertyInfo.DataBind()
    End Sub



    Protected Sub BindGrid()
        Dim dt As DataTable = TryCast(ViewState("PropertyInfoDT"), DataTable)
        grdPropertyInfo.DataSource = dt
        grdPropertyInfo.DataBind()
    End Sub

    Protected Sub Insert(sender As Object, e As EventArgs)

    End Sub



    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType <> DataControlRowType.DataRow Then Exit Sub

        Dim drp As DropDownList = CType(e.Row.FindControl("drpInstalledAtFurNiture"), DropDownList)
        Dim txtLoc As TextBox = CType(e.Row.FindControl("txtPIFloorLocation"), TextBox)
        Dim txtPN As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
        Dim txtSN As TextBox = CType(e.Row.FindControl("txtSerialNumber"), TextBox)

        ' Bind buildings
        Dim sql = "SELECT BuildingId, BuildingName + ' - ' + ISNULL(Address,'') AS Name FROM ams.TbBuilding_Dtl a INNER JOIN ams.Property_Dtl b ON a.Property_Dtl_ID = b.PropertyDetai_ID ORDER BY BuildingName"
        drp.DataSource = objDerived.GetDataTable(sql, CommandType.Text)
        drp.DataTextField = "Name"
        drp.DataValueField = "BuildingId"
        drp.DataBind()
        drp.Items.Insert(0, New ListItem("N/A", "0"))
        drp.Items.Insert(1, New ListItem("Field", "-1"))




        ' Restore values from ViewState
        Dim dt = TryCast(ViewState("PropertyInfoDT"), DataTable)
        If dt IsNot Nothing AndAlso e.Row.RowIndex < dt.Rows.Count Then
            Dim r = dt.Rows(e.Row.RowIndex)
            ' In grdPropertyInfo_RowDataBound
            Dim installedAtText As String = r("InstalledAt").ToString()

            ' Find by text instead of value
            Dim selectedItem As ListItem = drp.Items.FindByText(installedAtText)
            If selectedItem IsNot Nothing Then
                drp.SelectedValue = selectedItem.Value
            Else
                ' If not found, try to select by value as fallback
                If drp.Items.FindByValue(installedAtText) IsNot Nothing Then
                    drp.SelectedValue = installedAtText
                End If
            End If
            txtLoc.Text = r("FloorLocation").ToString()
            txtPN.Text = r("PropertyNo").ToString()
            txtSN.Text = r("SerialNo").ToString()
        End If

        ' In EDIT mode, lock PropertyNo
        If ViewState("IsEditMode") IsNot Nothing AndAlso CBool(ViewState("IsEditMode")) Then
            txtPN.Enabled = False
        End If
    End Sub

    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        Dim dt As DataTable = TryCast(ViewState("PropertyInfoDT"), DataTable)
        If dt Is Nothing Then Exit Sub

        For Each row As GridViewRow In grdPropertyInfo.Rows
            Dim txtPN As TextBox = CType(row.FindControl("txtPropertyNo"), TextBox)
            Dim txtSN As TextBox = CType(row.FindControl("txtSerialNumber"), TextBox)
            Dim drp As DropDownList = CType(row.FindControl("drpInstalledAtFurNiture"), DropDownList)
            Dim txtLoc As TextBox = CType(row.FindControl("txtPIFloorLocation"), TextBox)

            dt.Rows(row.RowIndex)("PropertyNo") = txtPN.Text
            dt.Rows(row.RowIndex)("SerialNo") = txtSN.Text
            dt.Rows(row.RowIndex)("InstalledAt") = drp.SelectedValue
            dt.Rows(row.RowIndex)("FloorLocation") = txtLoc.Text

            If String.IsNullOrWhiteSpace(drp.SelectedValue) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select a Location where the property is installed at.")
                ModalPopupExtender2.Show()
                Exit Sub
            End If
        Next

        ViewState("PropertyInfoDT") = dt
        ModalPopupExtender2.Hide()
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
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        For Each row As GridViewRow In grdPropertyInfo.Rows

            Dim _str As String = TryCast(row.FindControl("txtPropertyNo"), TextBox).Text
            ' msgbox(_str)
        Next
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
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ModalPopupExtender1.Hide()
    End Sub
    Protected Sub drpInstalledAtMac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim drp As DropDownList
        Dim text As TextBox
        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtFurNiture"), DropDownList)
            If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = True
                text.Text = ""
            Else
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = False

                Dim drp1 As DropDownList
                drp1 = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtFurNiture"), DropDownList)

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

    Private Sub LoadExistingPropertyRowsIntoViewState()
        ' 1) Determine the item ID
        Dim itemId As String = hdnItemNo.Value
        If String.IsNullOrEmpty(itemId) Then
            itemId = "0"
        End If

        ' 2) Query the DB for existing property rows
        '    (Properties that belong to this item)
        Dim dtFromDB As DataTable = objDerived.GetDataTable(
        "SELECT " & vbCrLf &
        "   AMS.Property_Dtl.PropertyNo, " & vbCrLf &
        "   AMS.Property_Dtl.SerialNo, " & vbCrLf &
        "   AMS.TbFurniture_Dtl.BuildingId, " & vbCrLf &
        "   AMS.TbFurniture_Dtl.Location, " & vbCrLf &
        "   AMS.Property.Property_ID " & vbCrLf &
        "FROM AMS.Property " & vbCrLf &
        "INNER JOIN AMS.Property_Dtl " & vbCrLf &
        "   ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID " & vbCrLf &
        "INNER JOIN AMS.TbFurniture_Info " & vbCrLf &
        "   ON AMS.Property_Dtl.PropertyDetai_ID = AMS.TbFurniture_Info.Property_Dtl_ID " & vbCrLf &
        "INNER JOIN AMS.TbFurniture_Dtl " & vbCrLf &
        "   ON AMS.TbFurniture_Info.FurnitureInfoId = AMS.TbFurniture_Dtl.FurnitureInfoId " & vbCrLf &
        "WHERE AMS.Property.Item_ID = " & itemId, CommandType.Text)


        ' 3) Create a new in-memory DataTable for your Grid
        Dim dtMemory As New DataTable()
        dtMemory.Columns.Add("PropertyNo", GetType(String))
        dtMemory.Columns.Add("SerialNo", GetType(String))
        dtMemory.Columns.Add("BuildingId", GetType(Integer))
        dtMemory.Columns.Add("Location", GetType(String))
        ' Add more columns if needed (e.g. Department, FloorLocation, etc.)

        ' 4) Copy DB rows into dtMemory
        For Each dbRow As DataRow In dtFromDB.Rows
            Dim newRow As DataRow = dtMemory.NewRow()
            newRow("PropertyNo") = dbRow("PropertyNo").ToString()
            newRow("SerialNo") = dbRow("SerialNo").ToString()
            newRow("BuildingId") = If(IsDBNull(dbRow("BuildingId")), 0, dbRow("BuildingId"))
            newRow("Location") = dbRow("Location").ToString()
            dtMemory.Rows.Add(newRow)
        Next

        ' 5) Store dtMemory in ViewState
        ViewState("PropertyInfoDT") = dtMemory
    End Sub


    Protected Sub cbInspection_CheckedChanged(sender As Object, e As EventArgs)

        btnSave.Text = "SAVE"
        btnSave.Enabled = True
        txtQuantity.Enabled = True

        IsEnabledTextBox(True)
        ClearTextBoxes()
        ViewState("CheckboxEvent") = True

        Dim cb As CheckBox = TryCast(sender, CheckBox)
        If cb Is Nothing Then Exit Sub

        Dim row As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
        If row Is Nothing Then Exit Sub

        ' Keep only one selected checkbox
        For Each gr As GridViewRow In grdLedger1.Rows
            If gr.RowType = DataControlRowType.DataRow AndAlso gr.RowIndex <> row.RowIndex Then
                Dim otherCb As CheckBox = TryCast(gr.FindControl("cbInspection"), CheckBox)
                If otherCb IsNot Nothing Then otherCb.Checked = False
            End If
        Next

        ' If unchecked, just clear and exit
        If Not cb.Checked Then
            ClearTextBoxes()
            Exit Sub
        End If

        Dim ledgerId As Long = 0
        Dim propertyId As Long = 0

        If grdLedger1.DataKeys Is Nothing OrElse row.RowIndex < 0 OrElse row.RowIndex >= grdLedger1.DataKeys.Count Then
            Exit Sub
        End If

        Long.TryParse(grdLedger1.DataKeys(row.RowIndex)("Ledger_ID").ToString(), ledgerId)
        Long.TryParse(grdLedger1.DataKeys(row.RowIndex)("Property_ID").ToString(), propertyId)

        If ledgerId = 0 OrElse propertyId = 0 Then Exit Sub

        AddTrace("hdnItemNo.Value: " & hdnItemNo.Value)
        AddTrace("Ledger_ID: " & ledgerId.ToString())
        AddTrace("Property_ID: " & propertyId.ToString())
        Session("Property_ID") = propertyId.ToString()

        Dim dtAll As DataTable = objDerived.GetDataTable(
        "[AMS].[sp_View_Encoding_v2] 'Furnitures','" & hdnItemNo.Value & "','" & propertyId & "'",
        CommandType.Text)

        If dtAll Is Nothing OrElse dtAll.Rows.Count = 0 Then
            ClearTextBoxes()
            Exit Sub
        End If

        Dim rows() As DataRow = dtAll.Select("Ledger_ID = " & ledgerId)

        Dim r0 As DataRow = Nothing
        If rows IsNot Nothing AndAlso rows.Length > 0 Then
            r0 = rows(0)
        Else
            ' fallback in case SP only returns one row or Ledger_ID does not match exactly
            r0 = dtAll.Rows(0)
        End If

        btnSave.Text = "EDIT"
        txtQuantity.Enabled = False
        btnSave.Enabled = True
        IsEnabledTextBox(False)

        txtequipmentdesciption.Text = r0("Description").ToString()
        txtequipmentSerialNumber.Text = r0("SerialNo").ToString()
        txtQuantity.Text = r0("DebitQty").ToString()
        txtequipmentdimension.Text = r0("Dimension").ToString()
        txtequipmentmodel.Text = r0("Model").ToString()
        txtSpecification.Text = r0("Specification").ToString()

        If dtAll.Columns.Contains("Brand") Then
            txtBrand.Text = r0("Brand").ToString()
        Else
            txtBrand.Text = ""
        End If

        txtequipmentwaranty.Text = r0("Warranty").ToString()

        If dtAll.Columns.Contains("Property_Date") Then
            txtEAcqDate.Text = r0("Property_Date").ToString()
        ElseIf dtAll.Columns.Contains("dDate") Then
            txtEAcqDate.Text = r0("dDate").ToString()
        Else
            txtEAcqDate.Text = ""
        End If

        txtEAcqCost.Text = r0("Cost").ToString()
        lblequipmentdepreciatedRate.Text = r0("DepreciationRate").ToString()
        txtequipmentdepreciatedvalue.Text = r0("DepreciationValue").ToString()
        txtEMarketValue.Text = r0("MarketValue").ToString()
        txtNoYears.Text = r0("NoYears").ToString()
        txtUsefulLife.Text = r0("UsefulLife").ToString()
        txtSalvageValue.Text = r0("SalvageValue").ToString()

        If dtAll.Columns.Contains("Remarks") Then
            txtRemarks.Text = r0("Remarks").ToString()
        Else
            txtRemarks.Text = ""
        End If

        If drpInstalledAtBuilding.Items.FindByValue(r0("BuildingId").ToString()) IsNot Nothing Then
            drpInstalledAtBuilding.SelectedValue = r0("BuildingId").ToString()
        End If

        If dtAll.Columns.Contains("Unit_ID") Then
            If drpUnit.Items.FindByValue(r0("Unit_ID").ToString()) IsNot Nothing Then
                'drpUnit.SelectedValue = r0("Unit_ID").ToString()
            End If
        End If

        Session("Ledger_ID") = ledgerId.ToString()
        ViewState("IsEditMode") = True

        AddTrace("Session(Ledger_ID): " & Session("Ledger_ID").ToString())

        PopulatePropertyInfoFromLedger(ledgerId)

        btnSave.Enabled = True
    End Sub

    Private Sub PopulatePropertyInfoFromLedger(ledgerId As Long)
        ' Make a Furniture-specific SP that returns PropertyDetai_ID, PropertyNo, SerialNo,
        ' InstalledAt(BuildingId), Location(FloorLocation) for the given Ledger_ID
        Dim dt As DataTable = objDerived.GetDataTable(
        "EXEC AMS.sp_GetPropertyDtl_ByLedger " & ledgerId, CommandType.Text)

        Dim dtBind As New DataTable()
        dtBind.Columns.Add("PropertyDetai_ID", GetType(Long))
        dtBind.Columns.Add("PropertyNo", GetType(String))
        dtBind.Columns.Add("SerialNo", GetType(String))
        dtBind.Columns.Add("FloorLocation", GetType(String))
        dtBind.Columns.Add("InstalledAt", GetType(String))

        If dt IsNot Nothing Then
            For Each r As DataRow In dt.Rows
                dtBind.Rows.Add(
                If(r.Table.Columns.Contains("PropertyDetai_ID") AndAlso Not IsDBNull(r("PropertyDetai_ID")), CLng(r("PropertyDetai_ID")), 0),
                r("PropertyNo").ToString(),
                r("SerialNo").ToString(),
                If(r.Table.Columns.Contains("Location"), r("Location").ToString(), ""),
                If(r.Table.Columns.Contains("InstalledAt"), r("InstalledAt").ToString(), "")
            )
            Next
        End If

        ViewState("PropertyInfoDT") = dtBind
        BindPropertyInfoGrid()
    End Sub




    Protected Sub IsEnabledTextBox(IsEnabled As Boolean)

        Dim ctxtBoxes As TextBox() = {
        txtequipmentSerialNumber, txtequipmentdimension, txtDepreciationValue, txtBrand, txtRemarks, txtequipmentdesciption, txtSpecification,
        txtequipmentmodel, txtequipmentwaranty, txtEAcqDate, txtEAcqCost, lblequipmentdepreciatedRate, txtequipmentdepreciatedvalue, txtEMarketValue, txtNoYears, txtSalvageValue}

        For Each textboxes In ctxtBoxes
            textboxes.Enabled = IsEnabled
        Next

    End Sub

    Protected Sub ClearTextBoxes()

        Dim ctxtBoxes As TextBox() = {
        txtequipmentdesciption, txtequipmentSerialNumber, txtQuantity, txtequipmentdimension, txtDepreciationValue, txtBrand, txtRemarks, txtequipmentdesciption, txtSpecification,
        txtequipmentmodel, txtequipmentwaranty, txtEAcqDate, txtEAcqCost, lblequipmentdepreciatedRate, txtequipmentdepreciatedvalue, txtEMarketValue, txtNoYears, txtUsefulLife, txtSalvageValue, txtRemarks}

        For Each textboxes In ctxtBoxes
            textboxes.Text = String.Empty
        Next

    End Sub

    Protected Sub grdLedger1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles grdLedger1.RowCreated

        If grdLedger1.HeaderRow IsNot Nothing AndAlso grdLedger1.Rows.Count > 0 Then
            If grdLedger1.Controls.Count > 0 AndAlso grdLedger1.Controls(0).Controls.Count > 0 Then
                ' Prevent duplicate custom header rows
                Dim headerAlreadyExists As Boolean = False
                For Each row As GridViewRow In grdLedger1.Controls(0).Controls
                    If row.RowType = DataControlRowType.Header AndAlso row.Cells(0).Text = "FURNITURE & FIXTURES" Then
                        headerAlreadyExists = True
                        Exit For
                    End If
                Next

                If Not headerAlreadyExists Then

                    Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
                    Dim cell As New TableHeaderCell()
                    cell.Text = "FURNITURE & FIXTURES"
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
        ModalPopupExtender2.Hide()
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
            Dim tb As TextBox = TryCast(row.FindControl("txtSerialNumber"), TextBox) ' Fixed: Changed to txtSerialNumber
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
