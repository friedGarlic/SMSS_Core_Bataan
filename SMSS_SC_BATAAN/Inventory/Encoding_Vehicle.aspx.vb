
Imports System.Data
Imports System.Drawing

Partial Class Inventory_Encoding_Vehicle
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Private objMotorInfo As New ConsolidatedPropertySaving.TbMotor_Info
    Dim counts As Integer = 0
    Private objMotorDtl As New ConsolidatedPropertySaving.TbMotor_Dtl

    Private Sub Inventory_Encoding_Vehicle_Load(sender As Object, e As EventArgs) Handles Me.Load
        'objx.GetAccessRight(Me.Session("@UserName"), Page)
        'If objx.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If
        If Not Page.IsPostBack Then
            '  txtDate.text = Date.Now.ToString("MM-dd-yyyy")

            'ddClass.DataSource = CType(Classification, DataTable)
            'Me.ddClass.DataTextField = ("ClassificationName")
            'Me.ddClass.DataValueField = ("ClassificationId")
            'Me.ddClass.DataBind()
            selectClassification()

            loadUnit()
            ' loadEquipmentLedger()
        End If


    End Sub
    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select Unit_ID,Description  From ams.m_Unit as a order by Description", CommandType.Text)
        ddVehicleUnit.DataSource = dt
        ddVehicleUnit.DataTextField = ("Description")
        ddVehicleUnit.DataValueField = ("Unit_ID")
        ddVehicleUnit.DataBind()
    End Sub
    Public Function selectClassification()
        Dim Classification As New Integer
        Classification = objDerived.GetValue("select [ClassificationId] From [dbo].[tbl_Classification] where [ClassificationName] like 'vehicle%'", CommandType.Text)

        ' lblClass.text = "Encoding of " & Classification
        ' lblClass1.text = ddClass.selecteditem.text


        Dim PListofGL As New DataTable
        PListofGL = objDerived.GetDataTable("select distinct c.SubClassificationID,c.SubClassificationName " &
                                            "	From tbl_SubClassification as c" &
                                            "        Left outer join tblclassmatrix as b on b.SubClassificationID = c.SubClassificationID" &
                                            "        inner join  tbl_Classification as a on a.ClassificationId = b.classificationid " &
                                            "        where b.classificationid ='" & Classification & "' order by c.SubClassificationName ", CommandType.Text)

        Me.drpSubClass.Items.Add("Select")
        Me.drpSubClass.DataSource = CType(PListofGL, DataTable)
        Me.drpSubClass.DataTextField = ("SubClassificationName")
        Me.drpSubClass.DataValueField = ("SubClassificationID")
        Me.drpSubClass.DataBind()





        Me.drpSubClass.enabled = True
        SelectSubClassification()

    End Function

    Protected Sub drpSubClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        SelectSubClassification()
    End Sub

    Public Function SelectSubClassification()
        Dim Classification As New Integer
        Classification = objDerived.GetValue("select [ClassificationId] From [dbo].[tbl_Classification] where [ClassificationName] like 'vehicle%'", CommandType.Text)
        lblSubClass.text = drpSubClass.SELECTEDITEM.TEXT.toupper & " INFORMATION"

        Dim PListofGL As New DataTable
        PListofGL = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & Classification & "','" & drpSubClass.selecteditem.value & "'", CommandType.Text)

        'MsgBox(PListofGL.Rows(0).Item("GA_ID").ToString)
        If PListofGL.rows.count <> 0 Then
            Dim dt As New DataTable

            'dt = objDerived.GetDataTable("select distinct item_particular_id,description From AMS.item_particular " &
            '                                " inner join tblclassmatrix as c on c.categoryid =  AMS.item_particular.item_particular_id" &
            '                                " where c.GA_ID ='" & PListofGL.Rows(0).Item("GA_ID").ToString & "'", CommandType.Text)


            dt = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & PListofGL.Rows(0).Item("GA_ID").ToString & "','" & 0 & "','" & 21 & "','" & drpSubClass.SelectedItem.Value & "'", CommandType.Text)

            ddCategory.datasource = dt
            ddCategory.DataTextField = ("description")
            ddCategory.DataValueField = ("item_particular_id")
            ddCategory.DataBind()
            ' selectCatergory()
            multiviewselected()

        End If

    End Function

    Protected Sub ddCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        multiviewselected()
    End Sub

    Protected Sub drpWatercraftName_SelectedIndexChanged(sender As Object, e As EventArgs)
        loadEquipmentInformation_from_drpName_Watercraft()
    End Sub

    Public Sub multiviewselected()
        Dim subcategory As Integer
        Dim dtAccount As New DataTable
        Dim PListofGL As New DataTable
        Dim Classification As New Integer
        Classification = objDerived.GetValue("select [ClassificationId] From [dbo].[tbl_Classification] where [ClassificationName] like 'vehicle%'", CommandType.Text)

        PListofGL = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category_v1_02152022 '" & 2 & "','" & Classification & "','" & drpSubClass.selecteditem.value & "'", CommandType.Text)

        '  dtAccount = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_v1_02262022] '" & PListofGL.Rows(0).Item("GA_ID").ToString & "','" & ddCategory.selectedItem.value & "'", CommandType.Text)

        Dim categoryid As Integer
        If ddCategory.text = "" Then
            categoryid = 0
        Else
            categoryid = ddCategory.selectedItem.value
        End If

        If drpSubClass.selecteditem.text.contains("Water") Then
            Me.mvVehicle.ActiveViewIndex = 1

            Dim itemdesc As New DataTable
            Dim dtitemdesc As New DataTable
            dtitemdesc = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_v2_03102022] " & Classification & ",'" & drpSubClass.selecteditem.value & "','" & categoryid & "'", CommandType.Text)
            DrpWatercraftName.datasource = dtitemdesc
            DrpWatercraftName.DataTextField = ("ItemDescription")
            DrpWatercraftName.DataValueField = ("Item_ID")
            DrpWatercraftName.DataBind()
            DrpWatercraftName.enabled = True
            loadEquipmentInformation_from_drpName_Watercraft()

        ElseIf drpSubClass.selecteditem.text.contains("Air") Then

        Else
            Me.mvVehicle.ActiveViewIndex = 0

            Dim itemdesc As New DataTable
            Dim dtitemdesc As New DataTable
            dtitemdesc = objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyRecords_v2_03102022] " & Classification & ",'" & drpSubClass.selecteditem.value & "','" & categoryid & "'", CommandType.Text)
            DrpVehicleName.datasource = dtitemdesc
            DrpVehicleName.DataTextField = ("ItemDescription")
            DrpVehicleName.DataValueField = ("Item_ID")
            DrpVehicleName.DataBind()
            DrpVehicleName.enabled = True
            loadEquipmentInformation_from_drpName()
            'loadEquipmentList()
            'loadEquipmentLedger()

        End If


    End Sub

    Protected Sub loadEquipmentInformation_from_drpName_Watercraft()
        Dim CYear As String = "CY" & Year(Date.Now.ToString)
        Dim itemid As String
        '   loadUnit()
        ' loadwarehouse()
        ' LoadBuildings()
        LoadEquipDTL()
        If DrpWatercraftName.text = "" Then

            itemid = "0"
        Else
            itemid = DrpWatercraftName.selectedvalue
            txtWatercraftName.Text = DrpWatercraftName.SelectedItem.text
            txtWatercraftDescription.Text = DrpWatercraftName.SelectedItem.text
        End If


        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID inner join ams.Property as c on a.Item_ID = c.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then

            '  txtWatercraftName.Text = DrpWatercraftName.SelectedItem.text
            hdnItemNo.value = itemid
            hdnGAId.value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

        Else

            hdnItemNo.value = itemid
            hdnGAId.value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & HDnItemNo.value, CommandType.Text)
            txtWatercraftName.Text = dt.Rows(0).Item("Name").ToString
            txtWatercraftDescription.Text = dt.Rows(0).Item("description").ToString
            txtWatercraftPowerInput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftPowerInput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftWarranty.Text = objDerived.GetValue("select e.Warranty from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftMake.Text = objDerived.GetValue("select e.VehicleMake from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftQuantity.Text = objDerived.GetValue("select count(e.VehicleMake) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftType.Text = objDerived.GetValue("select e.VehicleType from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftColor.Text = objDerived.GetValue("select e.VehicleColor from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtEAcqDate.Text = objDerived.GetValue("select convert(varchar,c.Property_Date,101) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftMarketValue.Text = objDerived.GetValue("select d.MarketValue from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftAcqCost.Text = objDerived.GetValue("select c.Cost from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftNoYears.Text = objDerived.GetValue("select e.NoofYears from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftDepRate.Text = objDerived.GetValue("select e.DepRate from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftUsefullife.Text = objDerived.GetValue("select e.UsefulLife from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftDepValue.Text = objDerived.GetValue("select e.DepValue from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftSalvageValue.Text = objDerived.GetValue("select e.SalvageValue from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftMMSI.Text = objDerived.GetValue("select e.MMSI from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftCallSign.Text = objDerived.GetValue("select e.CallSign from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftImoNo.Text = objDerived.GetValue("select e.ImoNo from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftHullMaterial.Text = objDerived.GetValue("select e.HullMaterial from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftNoofMast.Text = objDerived.GetValue("select e.NoofMast from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftNoofDecks.Text = objDerived.GetValue("select e.NoofDecks from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftNoofDecks.Text = objDerived.GetValue("select e.NoofDecks from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftNoofEngine.Text = objDerived.GetValue("select e.NoofEngine from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftMainEngine.Text = objDerived.GetValue("select e.MainEngine from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)


            txtWatercraftHorsePower.Text = objDerived.GetValue("select e.HorsePower from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftGRT.Text = objDerived.GetValue("select e.GRT from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftNRT.Text = objDerived.GetValue("select e.NRT from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftLOA.Text = objDerived.GetValue("select e.LOA from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtWatercraftBreadth.Text = objDerived.GetValue("select e.Breadth from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

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
        btnWatercraftsave.enabled = True
        loadEquipmentLedger()
    End Sub


    Protected Sub DrpVehicleName_SelectedIndexChanged(sender As Object, e As EventArgs)
        loadEquipmentInformation_from_drpName()
    End Sub
    Protected Sub loadEquipmentInformation_from_drpName()
        Dim CYear As String = "CY" & Year(Date.Now.ToString)
        Dim itemid As String
        '   loadUnit()
        ' loadwarehouse()
        ' LoadBuildings()
        LoadEquipDTL()

        If DrpVehicleName.text = "" Then

            itemid = "0"
        Else
            itemid = DrpVehicleName.selectedvalue
            txtVehicleName.Text = DrpVehicleName.SelectedItem.text
            txtVehicleDesc.Text = DrpVehicleName.SelectedItem.text

        End If

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select a.Item_ID,Item_Desc as name, Item_Desc as description,a.Brand,a.Color,a.Size,a.DepRate,a.DepYear," & CYear & ",Unit_ID from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID inner join ams.Property as c on a.Item_ID = c.Item_ID where a.Item_ID =" & itemid, CommandType.Text)
        If dt.Rows.Count = 0 Then
            hdnItemNo.value = itemid
            hdnGAId.value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

        Else
            On Error Resume Next
            hdnItemNo.value = itemid
            hdnGAId.value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & HDnItemNo.value, CommandType.Text)
            txtVehicleName.Text = dt.Rows(0).Item("Name").ToString
            txtVehicleDesc.Text = dt.Rows(0).Item("description").ToString
            txtVehiclePowerInput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtVehiclePowerInput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtVehicleWarranty.Text = objDerived.GetValue("select e.Warranty from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtVehicleMake.Text = objDerived.GetValue("select e.VehicleMake from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtVehicleQuantity.Text = objDerived.GetValue("select count(e.VehicleMake) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtVehicleType.Text = objDerived.GetValue("select e.VehicleType from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtVehicleColor.Text = objDerived.GetValue("select e.VehicleColor from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtEAcqDate.Text = objDerived.GetValue("select convert(varchar,c.Property_Date,101) from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

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
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtVehicleDepRate.Text = objDerived.GetValue("select e.DepRate from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtVehicleUsefullife.Text = objDerived.GetValue("select e.UsefulLife from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
                                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
                                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
                                                               "inner join ams.TbMotor_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
                                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

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
        btnSave.enabled = True
        loadEquipmentLedger()
    End Sub
    Protected Sub LoadEquipDTL()
        hdnItemNo.value = ""

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

        Dim vehicleTextBoxes() As TextBox = {txtVehicleName, txtVehiclePowerInput, txtVehicleDesc, txtVehicleWarranty, txtVehicleMake,
                                      txtVehicleQuantity, txtVehicleType, txtVehicleColor, txtEAcqDate, txtVehicleMarketValue,
                                      txtVehicleAcqCost, txtVehicleNoYears, txtVehicleDepRate, txtVehicleUsefullife, txtVehicleDepValue,
                                      txtVehicleSalvageValue}

        Dim watercraftTextBoxes() As TextBox = {txtWatercraftName, txtWatercraftDescription, txtWatercraftPowerInput, txtWatercraftPowerInput,
                                       txtWatercraftWarranty, txtWatercraftMake, txtWatercraftQuantity, txtWatercraftType, txtWatercraftColor,
                                       txtEAcqDate, txtWatercraftMarketValue, txtWatercraftAcqCost, txtWatercraftNoYears, txtWatercraftDepRate,
                                       txtWatercraftUsefullife, txtWatercraftDepValue, txtWatercraftSalvageValue, txtWatercraftMMSI,
                                       txtWatercraftCallSign, txtWatercraftImoNo, txtWatercraftHullMaterial, txtWatercraftNoofMast,
                                       txtWatercraftNoofDecks, txtWatercraftNoofDecks, txtWatercraftNoofEngine, txtWatercraftMainEngine,
                                       txtWatercraftHorsePower, txtWatercraftGRT, txtWatercraftNRT, txtWatercraftLOA, txtWatercraftBreadth,
                                       txtWatercraftCarryingCapacity}

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
        'If (e.Row.RowType = DataControlRowType.DataRow) Then

        '    Dim ddlCountries As DropDownList = CType(e.Row.FindControl("drpDepartment"), DropDownList)
        '    ddlCountries.DataSource = objDerived.GetDataTable("SELECT DISTINCT UPPER(RC_Name) AS RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
        '    ' ddlCountries.DataSource = dtDepartment
        '    ddlCountries.DataTextField = ("RC_Name")
        '    ddlCountries.DataValueField = ("RC_ID")
        '    ddlCountries.DataBind()

        '    'Add Default Item in the DropDownList
        '    ddlCountries.Items.Insert(0, New ListItem("Please select"))


        'End If
        'ViewState("Customers") = DirectCast(grdPropertyInfo.DataSource, DataTable)
        'If drpSubClass.selecteditem.text.contains("Water") Then
        '    e.Row.Cells(3).Visible = False
        '    e.Row.Cells(4).Visible = False
        '    e.Row.Cells(5).Visible = False
        '    e.Row.Cells(6).Visible = False
        'Else
        '    e.Row.Cells(3).Visible = True
        '    e.Row.Cells(4).Visible = True
        '    e.Row.Cells(5).Visible = True
        '    e.Row.Cells(6).Visible = True
        'End If



        If e.Row.RowType = DataControlRowType.DataRow Then



            Dim textPN As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
            Dim textSN As TextBox = CType(e.Row.FindControl("txtSerialNo"), TextBox)
            Dim textCN As TextBox = CType(e.Row.FindControl("txtChasisNo"), TextBox)
            Dim textLPN As TextBox = CType(e.Row.FindControl("txtLicensePlateNo"), TextBox)
            Dim textMFN As TextBox = CType(e.Row.FindControl("txtMVFileNo"), TextBox)
            Dim textCS As TextBox = CType(e.Row.FindControl("txtConSticker"), TextBox)

            Dim dt1 As DataTable = objDerived.GetDataTable("SELECT AMS.Property_Dtl.PropertyNo, AMS.Property_Dtl.SerialNo, AMS.TbMotor_Info.ChasisNo, AMS.TbMotor_Info.PlateNo, AMS.TbMotor_Info.MVfileNo, AMS.TbMotor_Info.ConSticker " &
                                                           " FROM AMS.Property " &
                                                           " JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID " &
                                                           " JOIN AMS.TbMotor_Info ON AMS.Property_Dtl.PropertyDetai_ID = AMS.TbMotor_Info.Property_Dtl_ID " &
                                                           " WHERE AMS.Property.Item_ID=" & hdnItemNo.Value, CommandType.Text)

            If counts <= dt1.Rows.Count - 1 Then
                If counts <= dt1.Rows.Count - 1 Then

                    textPN.Text = dt1.Rows(counts).Field(Of String)("PropertyNo")
                    textSN.Text = dt1.Rows(counts).Field(Of String)("SerialNo")
                    textCN.Text = dt1.Rows(counts).Field(Of String)("ChasisNo")
                    textLPN.Text = dt1.Rows(counts).Field(Of String)("PlateNo")
                    textMFN.Text = dt1.Rows(counts).Field(Of String)("MVfileNo")
                    textCS.Text = dt1.Rows(counts).Field(Of String)("ConSticker")

                End If

                counts += 1
            End If
        End If
        ViewState("Customers") = DirectCast(grdPropertyInfo.DataSource, DataTable)

    End Sub
    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        For Each row As GridViewRow In grdPropertyInfo.Rows

            Dim _str As String = TryCast(row.FindControl("txtPropertyNo"), TextBox).Text
            ' msgbox(_str)
        Next
    End Sub

    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)
        Dim dt As New DataTable()
        ' dt.Columns.AddRange(New DataColumn(1) {New DataColumn("Name"), New DataColumn("Country")})
        ' dt = ViewState("Customers")
        Dim quantity As Integer = 0

        If drpSubClass.selecteditem.text.contains("Water") Then
            quantity = val(txtWatercraftQuantity.text)
        ElseIf drpSubClass.selecteditem.text.contains("Air") Then
            quantity = val(txtWatercraftQuantity.text)
        Else
            quantity = val(txtVehicleQuantity.text)
        End If
        If quantity = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
        Else
            For i As Integer = 0 To quantity - 1
                dt.Rows.Add()
            Next
            ViewState("Customers") = dt
            Me.BindGrid()

            ModalPopupExtender2.show()
        End If


    End Sub
    Protected Sub BindGrid()
        grdPropertyInfo.DataSource = DirectCast(ViewState("Customers"), DataTable)
        grdPropertyInfo.DataBind()
    End Sub

    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "EQUIPMENT"
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
    End Sub
    Protected Sub grdLedger1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
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
        Me.mvledger.SetActiveView(Me.vwledger)

        Dim dtAccount As New DataTable
        Dim itemid As String
        'If 

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "' order by dDate", CommandType.Text)
        If hdnItemNo.value = "" Then
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)

        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.value & "'", CommandType.Text)

        End If
        ' dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If dtAccount.Rows.Count > 0 Then
            btnSave.Text = "EDIT"
            btnWatercraftsave.Text = "EDIT"
        Else
            btnSave.Text = "SAVE"
            btnWatercraftsave.Text = "SAVE"
        End If
        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
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

    Public Sub Add()
        'If txtVehicleName.Text = "" Or txtVehicleDesc.Text = "" Or txtVehicleUsefullife.Text = "" Or txtVehicleDepRate.Text = "" Or txtVehicleAcqCost.Text = "" Or txtVehicleDepValue.Text = "" Or txtVehicleSalvageValue.Text = "" Or txtVehicleMarketValue.Text = "" Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")

        'Else
        If Not IsNumeric(txtVehicleDepRate.Text) Or Not IsNumeric(txtVehicleAcqCost.Text) Or Not IsNumeric(txtVehicleDepValue.Text) Or Not IsNumeric(txtVehicleSalvageValue.Text) Or Not IsNumeric(txtVehicleMarketValue.Text) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
            Else
                Dim Prop_Hdr As New t_property_hdr
                With Prop_Hdr
                    '.Property_ID = Property_ID
                    .Property_Date = txtEAcqDate.Text
                    .Issuance = 0
                    .Remarks = "Manual Encoding of Old Properties"
                    .Emp_ID = 0
                    .F_ID = 1
                    .AIRDtl_ID = 0
                    .deptid = 0
                    .isDonated = False
                    .GA_ID = hdnGAId.Value
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

                    objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtVehicleMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)


                    Dim info_id As Integer
                    With objMotorInfo
                        .Motor_InfoId = 0
                        .AIRDtl_ID = 0
                        .IsAccepted = True
                        .Property_Dtl_ID = PropDtl_ID
                        .Name = txtVehicleName.Text
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
                        .DepRate = txtVehicleDepRate.Text
                        .DepValue = txtVehicleDepValue.Text
                        .NoofYears = txtVehicleNoYears.Text
                        .UsefulLife = txtVehicleUsefullife.Text
                        .SalvageValue = txtVehicleSalvageValue.Text
                        .CsNo = CType(grdPropertyInfo.Rows(i).FindControl("txtChasisNo"), TextBox).Text
                        .EngineNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNo"), TextBox).Text
                        .Displacement = ""
                    End With
                    Dim motor_info_id As Integer
                    motor_info_id = objMotorInfo.save()

                    objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Received_ID = 0, Received_Dtl_ID = 0 WHERE Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)

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

                    Dim Eqty As Integer
                    Dim Eqbalance As Decimal
                    Dim dtledger As New DataTable

                    dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                    If dtledger.Rows.Count = 0 Then
                        Eqty = 0
                        Eqbalance = 0.0
                    Else
                        Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                        Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                    End If
                    .BalanceQty = Eqty + txtVehicleQuantity.Text
                    .BalanceCost = (CType(txtVehicleAcqCost.Text, Decimal) * txtVehicleQuantity.Text) + CType(Eqbalance, Decimal)

                End With
                Prop_Ledger.save()



                btnSave.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                multiviewselected()
                ' loadEquipmentList()
                ' loadEquipmentInformation()
                loadEquipmentInformation_from_drpName()
                loadEquipmentLedger()
            End If
        ' End If
    End Sub
    Public Sub Edit()

        Try
            If txtVehicleName.Text = "" Or txtVehicleDesc.Text = "" Or txtVehicleUsefullife.Text = "" Or txtVehicleDepRate.Text = "" Or txtVehicleAcqCost.Text = "" Or txtVehicleDepValue.Text = "" Or txtVehicleSalvageValue.Text = "" Or txtVehicleMarketValue.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")

            Else
                If Not IsNumeric(txtVehicleDepRate.Text) Or Not IsNumeric(txtVehicleAcqCost.Text) Or Not IsNumeric(txtVehicleDepValue.Text) Or Not IsNumeric(txtVehicleSalvageValue.Text) Or Not IsNumeric(txtVehicleMarketValue.Text) Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
                Else
                    Dim objDerived As New DerivedDal
                    objDerived.conStr = objDerived.DbaseConnect()

                    objDerived.cmd.Parameters.AddWithValue("@Property_ID", lblProperty_ID.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Motor_InfoId", lblMotor_InfoId.Text)
                    objDerived.cmd.Parameters.AddWithValue("@MotorID", lblMotorID.Text)

                    objDerived.cmd.Parameters.AddWithValue("@Name", txtVehicleName.Text)
                    objDerived.cmd.Parameters.AddWithValue("@PowerInput", txtVehiclePowerInput.Text)
                    objDerived.cmd.Parameters.AddWithValue("@VehicleDesc", txtVehicleDesc.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Warranty", txtVehicleWarranty.Text)
                    objDerived.cmd.Parameters.AddWithValue("@VehicleMake", txtVehicleMake.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Qty", txtVehicleQuantity.Text)
                    objDerived.cmd.Parameters.AddWithValue("@VehicleType", txtVehicleType.Text)
                    objDerived.cmd.Parameters.AddWithValue("@VehicleColor", txtVehicleColor.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtEAcqDate.Text)
                    objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtVehicleMarketValue.Text.Replace(",", ""))
                    objDerived.cmd.Parameters.AddWithValue("@Cost", txtVehicleAcqCost.Text.Replace(",", ""))
                    objDerived.cmd.Parameters.AddWithValue("@NoofYears", txtVehicleNoYears.Text)

                    objDerived.cmd.Parameters.AddWithValue("@DepRate", txtVehicleDepRate.Text)
                    objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtVehicleUsefullife.Text)
                    objDerived.cmd.Parameters.AddWithValue("@DepValue", txtVehicleDepValue.Text.Replace(",", ""))
                    objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtVehicleSalvageValue.Text.Replace(",", ""))

                    objDerived.cmd.Parameters.AddWithValue("@Item_ID", lblItem_ID.Text)

                    objDerived.Execute("AMS.spEdit_Vehicles_Info_Dtl", CommandType.StoredProcedure)


                    Dim dt1 As New DataTable
                    dt1 = objDerived.GetDataTable("SELECT AMS.Property_Dtl.PropertyNo, AMS.Property_Dtl.SerialNo, AMS.TbMotor_Info.ChasisNo, AMS.TbMotor_Info.PlateNo, AMS.TbMotor_Info.MVfileNo, AMS.TbMotor_Info.ConSticker, AMS.Property.Property_ID, AMS.TbMotor_Info.Property_Dtl_ID " &
                                                   " FROM  AMS.Property INNER JOIN " &
                                                   " AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID INNER JOIN " &
                                                   " AMS.TbMotor_Info ON AMS.Property_Dtl.PropertyDetai_ID = AMS.TbMotor_Info.Property_Dtl_ID " &
                                                   " where AMS.Property.Item_ID=" & hdnItemNo.Value & "", CommandType.Text)
                    For i As Integer = 0 To dt1.Rows.Count - 1

                        objDerived.GetRecords("UPDATE AMS.Property_Dtl SET PropertyNo = '" _
                                                                                           & CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text &
                                                                            "',SerialNo='" & CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNo"), TextBox).Text &
                                                                            "' WHERE PropertyNo = '" & dt1.Rows(i).Item("PropertyNo").ToString & "'", CommandType.Text)


                        objDerived.GetRecords("UPDATE  AMS.TbMotor_Info SET ChasisNo='" & CType(grdPropertyInfo.Rows(i).FindControl("txtChasisNo"), TextBox).Text &
                                                                         "',PlateNo='" & CType(grdPropertyInfo.Rows(i).FindControl("txtLicensePlateNo"), TextBox).Text &
                                                                         "',MVfileNo='" & CType(grdPropertyInfo.Rows(i).FindControl("txtMVFileNo"), TextBox).Text &
                                                                         "',ConSticker='" & CType(grdPropertyInfo.Rows(i).FindControl("txtConSticker"), TextBox).Text &
                                                                         "' WHERE Property_Dtl_ID='" & dt1.Rows(i).Item("Property_Dtl_ID").ToString & "'", CommandType.Text)
                    Next







                    For i As Integer = dt1.Rows.Count To grdPropertyInfo.Rows.Count - 1



                        Dim Prop_Dtl As New t_property_dtl
                        With Prop_Dtl
                            .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                            .Property_ID = dt1.Rows(0).Item("Property_ID").ToString
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

                        objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtVehicleMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)


                        Dim info_id As Integer
                        With objMotorInfo
                            .Motor_InfoId = 0
                            .AIRDtl_ID = 0
                            .IsAccepted = True
                            .Property_Dtl_ID = PropDtl_ID
                            .Name = txtVehicleName.Text
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
                            .DepRate = txtVehicleDepRate.Text
                            .DepValue = txtVehicleDepValue.Text
                            .NoofYears = txtVehicleNoYears.Text
                            .UsefulLife = txtVehicleUsefullife.Text
                            .SalvageValue = txtVehicleSalvageValue.Text
                        End With
                        Dim motor_info_id As Integer
                        motor_info_id = objMotorInfo.save()

                        objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Received_ID = 0, Received_Dtl_ID = 0 WHERE Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)

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


                    Next



                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully Edit.")

                    btnWatercraftsave.Text = "EDIT"
                    btnSave.Text = "EDIT"




                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Dim a As String
        For i As Integer = 0 To grdPropertyInfo.rows.count - 1
            'msgbox(CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text)

            a = CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
        Next


        If a = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill up the Property Information")
        Else
            If btnSave.Text = "SAVE" Then
                Add()
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
            End If
        End If
    End Sub

    Public Sub WaterCraftAdd()
        If txtWatercraftName.Text = "" Or txtWatercraftDescription.Text = "" Or txtWatercraftUsefulLife.Text = "" Or txtWatercraftDepRate.Text = "" Or txtWatercraftAcqCost.Text = "" Or txtWatercraftDepValue.Text = "" Or txtWatercraftSalvageValue.Text = "" Or txtWatercraftMarketValue.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")

        Else
            If Not IsNumeric(txtWatercraftDepRate.Text) Or Not IsNumeric(txtWatercraftAcqCost.Text) Or Not IsNumeric(txtWatercraftDepValue.Text) Or Not IsNumeric(txtWatercraftSalvageValue.Text) Or Not IsNumeric(txtWatercraftMarketValue.Text) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
            Else
                Dim Prop_Hdr As New t_property_hdr
                With Prop_Hdr
                    '.Property_ID = Property_ID
                    .Property_Date = txtWatercraftAcqDate.Text
                    .Issuance = 0
                    .Remarks = "Manual Encoding of Old Properties"
                    .Emp_ID = 0
                    .F_ID = 1
                    .AIRDtl_ID = 0
                    .deptid = 0
                    .isDonated = False
                    .GA_ID = hdnGAId.Value
                    .DonationRemarks = ""
                    .Qty = txtWatercraftQuantity.Text
                    .Balance = txtWatercraftQuantity.Text
                    .Cost = CType(txtWatercraftAcqCost.Text, Decimal)
                    .Item_ID = hdnItemNo.Value
                    .Property_code = objDerived.GetValue("select ga_code2 from [AMS].[vw_item_master_list] where Item_ID ='" & hdnItemNo.Value & "' ", CommandType.Text)
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .Function_ID = 0
                    .TD_ID = 1
                    .Project_ID = 0
                    .Program_id = 0
                    .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                End With

                Dim PropHdr_ID As Integer = 0
                PropHdr_ID = Prop_Hdr.save()

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
                        .InspectionDate = txtWatercraftAcqDate.Text
                        .F_ID = 1
                        .SerialNo = CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNo"), TextBox).Text
                        .Barcode = " "
                        .Amount = CType(txtWatercraftAcqCost.Text, Decimal)
                        .Status = "Accepted"
                        .Details = "" 'txtSpecification.Text
                        .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                        .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                        .AccountablePerson = CType(grdPropertyInfo.Rows(i).FindControl("txtAccountablePerson"), TextBox).Text
                        .Function_ID = 86
                    End With

                    Dim PropDtl_ID As Integer
                    PropDtl_ID = Prop_Dtl.save()

                    objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtWatercraftMarketValue.Text, Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)


                    Dim info_id As Integer
                    With objMotorInfo
                        .Motor_InfoId = 0
                        .AIRDtl_ID = 0
                        .IsAccepted = True
                        .Property_Dtl_ID = PropDtl_ID
                        .Name = txtWatercraftName.Text
                        .PlateNo = CType(grdPropertyInfo.Rows(i).FindControl("txtLicensePlateNo"), TextBox).Text
                        .MotorNo = ""
                        .Model = ""
                        .ChasisNo = CType(grdPropertyInfo.Rows(i).FindControl("txtChasisNo"), TextBox).Text
                        .VehicleColor = txtWatercraftColor.Text
                        .WheelsCapacity = ""
                        .GrossWeight = ""
                        .Seats = ""
                        .Warranty = txtWatercraftWarranty.Text
                        .VehicleOwner = ""
                        .DeclaredName = ""
                        .BeneficialUser = ""
                        .VehicleSpecification = ""
                        .VehicleDesc = txtWatercraftDescription.Text
                        .VehicleMake = txtWatercraftMake.Text
                        .VehicleType = txtWatercraftType.Text
                        .PowerInput = txtWatercraftPowerInput.Text
                        .MVfileNo = CType(grdPropertyInfo.Rows(i).FindControl("txtMVFileNo"), TextBox).Text
                        .ConSticker = CType(grdPropertyInfo.Rows(i).FindControl("txtConSticker"), TextBox).Text
                        .DepRate = txtWatercraftDepRate.Text
                        .DepValue = txtWatercraftDepValue.Text
                        .NoofYears = txtWatercraftNoYears.Text
                        .UsefulLife = txtWatercraftUsefulLife.Text
                        .SalvageValue = txtWatercraftSalvageValue.Text
                        .MMSI = txtWatercraftMMSI.Text
                        .CallSign = txtWatercraftCallSign.Text
                        .IMOno = txtWatercraftImoNo.Text
                        .HullMaterial = txtWatercraftHullMaterial.Text
                        .NoofMast = txtWatercraftNoofMast.Text
                        .NoofDecks = txtWatercraftNoofDecks.Text
                        .NoofEngine = txtWatercraftNoofEngine.Text
                        .MainEngine = txtWatercraftMainEngine.Text
                        .HorsePower = txtWatercraftHorsePower.Text
                        .Grt = txtWaterCraftGRT.Text
                        .Nrt = txtWatercraftNRT.Text
                        .Loa = txtWatercraftLOA.Text
                        .Breadth = txtWatercraftBreadth.Text
                        .CarryingCapacity = txtWaterCraftCarryingCapacity.Text
                    End With
                    Dim motor_info_id As Integer
                    motor_info_id = objMotorInfo.save()

                    objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Received_ID = 0, Received_Dtl_ID = 0 WHERE Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)

                    With objMotorDtl
                        .MotorID = 0
                        .Motor_InfoId = motor_info_id
                        .Property_Dtl_ID = PropDtl_ID
                        .MarketValue = txtWatercraftMarketValue.Text
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
                    .dDate = txtWatercraftAcqDate.Text
                    .Ref = ""
                    .AccountablePerson = ""
                    .Department = 0
                    .Position = ""
                    .AcceptedBy = ""
                    .InspectedBy = ""
                    .Item_ID = hdnItemNo.Value
                    .DebitQty = txtWatercraftQuantity.Text
                    .DebitCost = (CType(txtWatercraftAcqCost.Text, Decimal) * txtWatercraftQuantity.Text)
                    .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)
                    .CreditQty = "0"
                    .CreditUnit = "-"
                    .CreditCost = "0.00"
                    .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)

                    Dim Eqty As Integer
                    Dim Eqbalance As Decimal
                    Dim dtledger As New DataTable

                    dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                    If dtledger.Rows.Count = 0 Then
                        Eqty = 0
                        Eqbalance = 0.0
                    Else
                        Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                        Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & hdnItemNo.Value & "'", CommandType.Text)
                    End If
                    .BalanceQty = Eqty + txtWatercraftQuantity.Text
                    .BalanceCost = (CType(txtWatercraftAcqCost.Text, Decimal) * txtWatercraftQuantity.Text) + CType(Eqbalance, Decimal)

                End With
                Prop_Ledger.save()



                btnWatercraftsave.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                multiviewselected()
                ' loadEquipmentList()
                ' loadEquipmentInformation()
                loadEquipmentInformation_from_drpName_Watercraft()
                loadEquipmentLedger()
            End If
        End If
    End Sub
    Public Sub EditWaterCraft()
        If txtWatercraftName.Text = "" Or txtWatercraftDescription.Text = "" Or txtWatercraftUsefulLife.Text = "" Or txtWatercraftDepRate.Text = "" Or txtWatercraftAcqCost.Text = "" Or txtWatercraftDepValue.Text = "" Or txtWatercraftSalvageValue.Text = "" Or txtWatercraftMarketValue.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Description / Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")

        Else
            If Not IsNumeric(txtWatercraftDepRate.Text) Or Not IsNumeric(txtWatercraftAcqCost.Text) Or Not IsNumeric(txtWatercraftDepValue.Text) Or Not IsNumeric(txtWatercraftSalvageValue.Text) Or Not IsNumeric(txtWatercraftMarketValue.Text) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
            Else



                Try

                    Dim objDerived As New DerivedDal
                    objDerived.conStr = objDerived.DbaseConnect()

                    objDerived.cmd.Parameters.AddWithValue("@Motor_InfoId", lblMotor_InfoId.Text)
                    objDerived.cmd.Parameters.AddWithValue("@VehicleDesc", txtWatercraftDescription.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Warranty", txtWatercraftWarranty.Text)
                    objDerived.cmd.Parameters.AddWithValue("@VehicleMake", txtWatercraftMake.Text)
                    objDerived.cmd.Parameters.AddWithValue("@VehicleType", txtWatercraftType.Text)
                    objDerived.cmd.Parameters.AddWithValue("@VehicleColor", txtWatercraftColor.Text)
                    objDerived.cmd.Parameters.AddWithValue("@NoofYears", txtWatercraftNoYears.Text)
                    objDerived.cmd.Parameters.AddWithValue("@DepRate", txtWatercraftDepRate.Text)
                    objDerived.cmd.Parameters.AddWithValue("@UsefulLife", txtWatercraftUsefulLife.Text)
                    objDerived.cmd.Parameters.AddWithValue("@DepValue", txtWatercraftDepValue.Text.Replace(",", ""))
                    objDerived.cmd.Parameters.AddWithValue("@SalvageValue", txtWatercraftSalvageValue.Text.Replace(",", ""))
                    objDerived.cmd.Parameters.AddWithValue("@MMSI", txtWatercraftMMSI.Text)
                    objDerived.cmd.Parameters.AddWithValue("@CallSign", txtWatercraftCallSign.Text)
                    objDerived.cmd.Parameters.AddWithValue("@IMOno", txtWatercraftImoNo.Text)
                    objDerived.cmd.Parameters.AddWithValue("@HullMaterial", txtWatercraftHullMaterial.Text)
                    objDerived.cmd.Parameters.AddWithValue("@NoofMast", txtWatercraftNoofMast.Text)
                    objDerived.cmd.Parameters.AddWithValue("@NoofDecks", txtWatercraftNoofDecks.Text)
                    objDerived.cmd.Parameters.AddWithValue("@NoofEngine", txtWatercraftNoofEngine.Text)
                    objDerived.cmd.Parameters.AddWithValue("@MainEngine", txtWatercraftMainEngine.Text)
                    objDerived.cmd.Parameters.AddWithValue("@HorsePower", txtWatercraftHorsePower.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Grt", txtWaterCraftGRT.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Nrt", txtWatercraftNRT.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Loa", txtWatercraftLOA.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Breadth", txtWatercraftBreadth.Text)
                    objDerived.cmd.Parameters.AddWithValue("@CarryingCapacity", txtWaterCraftCarryingCapacity.Text)

                    objDerived.cmd.Parameters.AddWithValue("@Property_ID", lblProperty_ID.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Qty", txtWatercraftQuantity.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Property_Date", txtWatercraftAcqDate.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Cost", txtWatercraftAcqCost.Text.Replace(",", ""))

                    objDerived.cmd.Parameters.AddWithValue("@MotorID", lblMotorID.Text)
                    objDerived.cmd.Parameters.AddWithValue("@MarketValue", txtWatercraftMarketValue.Text.Replace(",", ""))

                    objDerived.cmd.Parameters.AddWithValue("@Item_ID", lblItem_ID.Text)

                    objDerived.Execute("AMS.sp_Edit_Other_Vehicles", CommandType.StoredProcedure)

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                    btnWatercraftsave.Text = "EDIT"
                    btnSave.Text = "EDIT"
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
            End If

        End If
    End Sub
    Protected Sub btnWatercraftsave_Click(sender As Object, e As EventArgs)
        If btnWatercraftsave.Text = "EDIT" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataTextField = ("full_name")
            drpApprovedOfficer.DataValueField = ("approvalid")
            drpApprovedOfficer.DataSource = dt
            drpApprovedOfficer.DataBind()
            ModalPopupExtender1.Show()
        ElseIf btnWatercraftsave.Text = "UPDATE" Then
            EditWaterCraft()
        ElseIf btnWatercraftsave.Text = "SAVE" Then
            WaterCraftAdd()
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
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else
            btnSave.Text = "UPDATE"
            btnWatercraftsave.Text = "UPDATE"
            Button3.Enabled = True
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
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is already exist!")
                    text.Text = ""
                Else

                End If
            Next
        ElseIf btnSave.Text = "EDIT" Then
            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("SELECT AMS.Property_Dtl.PropertyNo, AMS.Property_Dtl.SerialNo, AMS.TbMotor_Info.ChasisNo, AMS.TbMotor_Info.PlateNo, AMS.TbMotor_Info.MVfileNo, AMS.TbMotor_Info.ConSticker, AMS.Property.Property_ID, AMS.TbMotor_Info.Property_Dtl_ID " &
                                                   " FROM  AMS.Property INNER JOIN " &
                                                   " AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID INNER JOIN " &
                                                   " AMS.TbMotor_Info ON AMS.Property_Dtl.PropertyDetai_ID = AMS.TbMotor_Info.Property_Dtl_ID " &
                                                   " where AMS.Property.Item_ID=" & hdnItemNo.Value & "", CommandType.Text)

            For i As Integer = dt1.Rows.Count To grdPropertyInfo.Rows.Count - 1
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPropertyNo"), TextBox)
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT a.Item_ID, b.PropertyNo FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID WHERE  (b.PropertyNo = '" & text.Text & "')", CommandType.Text)
                If dt.Rows.Count > 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is already exist!")
                    text.Text = ""
                Else

                End If
            Next
        End If



        ModalPopupExtender2.Show()
    End Sub
End Class
