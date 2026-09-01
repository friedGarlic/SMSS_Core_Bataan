Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing
Partial Class Inventory_Encoding_OfficeEquipment
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Dim counts As Integer = 0
    Private Shared headerRow As GridViewRow
    Private Shared ReadOnly headerRowLock As New Object()

    Private Sub Inventory_Encoding_Equipment_Load(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles Me.Load

        'objx.GetAccessRight(Me.Session("@UserName"), Page)
        'If objx.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If

        If Not Page.IsPostBack Then

            txtDate.Text = Date.Now.ToString("MM-dd-yyyy")
            Session("Item_ID") = 0

            Dim Classification As DataTable = objDerived.GetDataTable(
            "SELECT " &
            "    ClassificationId, " &
            "    ClassificationName " &
            "FROM dbo.tbl_Classification " &
            "WHERE ClassificationName LIKE 'Office equipment%' " &
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

            selectClassification()
            ClrText()

            AddTrace("ddClass: " & ddClass.SelectedValue)
            AddTrace("Session ClassificationID: " & Convert.ToString(Session("ClassificationID")))
            AddTrace("drpSubClass: " & drpSubClass.SelectedValue)
            AddTrace("ddGlAccount: " & ddGlAccount.SelectedValue)

            txtUsefulLife.Text = "0"

        End If
    End Sub
    Public Sub selectClassification()

        If ddClass.SelectedValue Is Nothing OrElse
       ddClass.SelectedValue = "" Then

            Session("ClassificationID") = "0"

        Else

            Session("ClassificationID") = ddClass.SelectedValue

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

        Dim gaID As Integer = 0

        Integer.TryParse(
        Convert.ToString(ddGlAccount.SelectedValue),
        gaID
    )

        If gaID = 0 Then

            ddCategory.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            ddSubCategory.Items.Clear()
            ddSubCategory.Items.Insert(
            0,
            New ListItem("Select", "0")
        )

            Exit Sub

        End If

        Dim dt As DataTable = objDerived.GetDataTable(
        "SELECT " &
        "    item_particular_id, " &
        "    description " &
        "FROM AMS.item_particular " &
        "WHERE GA_ID = " & gaID & " " &
        "ORDER BY description",
        CommandType.Text
    )

        ddCategory.DataSource = dt
        ddCategory.DataTextField = "description"
        ddCategory.DataValueField = "item_particular_id"
        ddCategory.DataBind()

        ddCategory.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        selectCatergory()

    End Sub
    Public Sub selectCatergory()
        ddSubCategory.Items.Clear()

        Dim categoryID As Integer = 0

        If ddCategory.SelectedValue IsNot Nothing AndAlso
       ddCategory.SelectedValue <> "" Then

            Integer.TryParse(
            ddCategory.SelectedValue,
            categoryID
        )

        End If

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

        ddSubCategory.DataSource = subcategory
        ddSubCategory.DataTextField = "SubCat_Desc"
        ddSubCategory.DataValueField = "SubCategoryID"
        ddSubCategory.DataBind()

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

            ClrText()
            loadEquipmentLedger()
            Exit Sub

        End If

        Session("Item_ID") = drpName.SelectedValue
        hdnItemNo.Value = drpName.SelectedValue
        hdnGAId.Value = ddGlAccount.SelectedValue

        loadEquipmentInformation_from_drpName()
        loadEquipmentLedger()
        loadUnit()
        ClrText()
        loadUsefulLife()

    End Sub

    Protected Sub txtEAcqDate_TextChanged(sender As Object, e As EventArgs)
        'LoadEquipDepreciation()
    End Sub
    Protected Sub lblequipmentdepreciatedRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'LoadEquipDepreciation()
    End Sub
    Protected Sub txtSalvageValue_TextChanged(sender As Object, e As EventArgs)
        'LoadEquipDepreciation()
    End Sub

    Public Sub Save()


        'If Not IsNumeric(lblequipmentdepreciatedRate.Text) Or Not IsNumeric(txtEAcqCost.Text) Or Not IsNumeric(txtequipmentdepreciatedvalue.Text) Or Not IsNumeric(txtSalvageValue.Text) Or Not IsNumeric(txtEMarketValue.Text) Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please Check: Useful Life / Dep. Rate / Acquisition Cost / Dep. Value / Salvage Value / Market Value")
        'Else
        Dim missingFields As New List(Of String)

        'If drpName.SelectedIndex = 0 Then
        '    missingFields.Add("Name")
        'End If

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


        If missingFields.Count > 0 Then
            Dim message As String = "Please fill up the required field(s):" &
                            "\n - " & String.Join("\n - ", missingFields)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, message)
            Exit Sub
        Else

            If drpInstalledAtBuilding.SelectedItem.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Input Please select the Building where the property is located.")
            Else


                Dim propertyinfo As Integer
                For a As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                    If CType(grdPropertyInfo.Rows(a).FindControl("txtPropertyNo"), TextBox).Text = "" Then
                        propertyinfo += 1
                    End If
                Next


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
                    '.GA_ID = hdnGAId.Value
                    .GA_ID = ddGlAccount.SelectedValue
                    .DonationRemarks = ""
                    .Qty = txtEquipmentQuantity.Text
                    .Balance = txtEquipmentQuantity.Text
                    .Cost = CType(txtEAcqCost.Text, Decimal)
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
                objDerived.GetRecords("UPDATE AMS.Property SET ClassificationID = '" & ddClass.SelectedValue & "',SubClassificationID = '" & drpSubClass.SelectedValue & "'  WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)



                ' ===== Save one Property_Dtl + Equipment Info/Detail per popup row =====
                For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
                    Dim tbPropNo As TextBox = TryCast(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox)
                    Dim tbSerial As TextBox = TryCast(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox)
                    Dim ddlInstalled As DropDownList = TryCast(grdPropertyInfo.Rows(i).FindControl("drpInstalledAtOfEquip"), DropDownList)
                    Dim tbLocation As TextBox = TryCast(grdPropertyInfo.Rows(i).FindControl("txtPIFloorLocation"), TextBox)

                    If tbPropNo Is Nothing OrElse tbSerial Is Nothing OrElse ddlInstalled Is Nothing OrElse tbLocation Is Nothing Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unable to read Property Information controls. Please reopen the popup and try again.")
                        Exit Sub
                    End If

                    ' Parse Market Value once; default to 0 if blank/invalid
                    Dim marketValue As Decimal = 0D
                    Dim mvRaw As String = If(txtEMarketValue IsNot Nothing, txtEMarketValue.Text, String.Empty)
                    If Not String.IsNullOrWhiteSpace(mvRaw) Then
                        Decimal.TryParse(mvRaw.Replace(",", ""), marketValue)
                    End If

                    Dim installedAtText As String = If(ddlInstalled.SelectedItem IsNot Nothing, ddlInstalled.SelectedItem.Text, ddlInstalled.SelectedValue)

                    ' ---- Property_Dtl
                    Dim Prop_Dtl As New t_property_dtl
                    With Prop_Dtl
                        .PropertyNo = tbPropNo.Text.Trim()
                        .Property_ID = PropHdr_ID
                        .Issued = False
                        .Repair = False
                        .Dispose = False
                        .DisposeDate = "1/1/1900"
                        .IsInspectionForDisposal = False
                        .InspectionDate = txtEAcqDate.Text
                        .F_ID = 1
                        .SerialNo = tbSerial.Text.Trim()
                        .Barcode = " "
                        .Amount = CType(txtEAcqCost.Text, Decimal)
                        .Status = "Accepted"
                        .Details = txtSpecification.Text
                        .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id WHERE Item_ID = '" & hdnItemNo.Value & "' ", CommandType.Text)
                        .RC_ID = objDerived.GetValue("SELECT RC_ID FROM [dbo].[View_RespCenter_withFunctions] WHERE RC_Name LIKE '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                        .AccountablePerson = ""
                        .Function_ID = 86

                        ' per reference
                        .InstalledAt = installedAtText
                        .Location = tbLocation.Text.Trim()
                        .MarketValue = marketValue
                    End With

                    Dim PropDtl_ID As Integer = Prop_Dtl.save()

                    ' ---- TbEquipment_Info (per row)
                    Dim info_id As Integer
                    Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info
                    With objEquipInfo
                        .EquipInfoId = 0
                        .AIRDtl_ID = 0
                        .IsAccepted = True
                        .Property_Dtl_ID = PropDtl_ID
                        .SerialNo = tbSerial.Text.Trim()
                        .Name = txtName.Text
                        .Description = txtequipmentdesciption.Text
                        .PowerInput = txtequipmentpowerinput.Text
                        .Dimension = txtequipmentdimension.Text
                        .AreaCapacity = txtequipmentareacapacity.Text
                        .Model = txtequipmentmodel.Text
                        .Warranty = txtequipmentwaranty.Text
                        .Specification = txtSpecification.Text
                        .DepreciationRate = lblequipmentdepreciatedRate.Text
                        .DepreciationValue = txtequipmentdepreciatedvalue.Text
                        .FloorLocation = tbLocation.Text.Trim()
                        .RoomLocation = ""
                        .RC_ID = objDerived.GetValue("SELECT RC_ID FROM [dbo].[View_RespCenter_withFunctions] WHERE RC_Name LIKE '%GENERAL SERVICES OFFICE%'", CommandType.Text)
                        .AccountablePerson = ""
                        .SalvageValue = txtSalvageValue.Text
                        .UsefulLife = If(String.IsNullOrWhiteSpace(txtUsefulLife.Text), 0, CLng(txtUsefulLife.Text))
                        .NoYears = txtNoYears.Text
                        .Property_ID = PropHdr_ID
                    End With

                    info_id = objEquipInfo.save()
                    objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0 WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)
                    objDerived.GetRecords(
                        "UPDATE AMS.TbEquipment_Info SET " &
                        "Remarks = '" & txtRemarks.Text.Replace("'", "''") & "', " &
                        "Unit_ID = " & drpUnit.SelectedValue & ", " &
                        "Specification = CAST('" & txtSpecification.Text.Replace("'", "''") & "' AS VARCHAR(MAX)), " &
                        "Brand = N'" & txtequipmentbrand.Text.Replace("'", "''") & "' " &
                        "WHERE EquipInfoId = " & info_id,
                        CommandType.Text
                    )
                    ' ---- TbEquipment_Details (per row)

                    '-- TODO: ERROR
                    Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details
                    With objEquipDtl
                        .EquipmentId = 0
                        .EquipInfoId = info_id
                        .Property_Dtl_ID = PropDtl_ID

                        ' Market value again (safe default)
                        Dim mvDtl As Decimal = 0D
                        If Not String.IsNullOrWhiteSpace(mvRaw) Then Decimal.TryParse(mvRaw.Replace(",", ""), mvDtl)
                        .MarketValue = mvDtl

                        .Condition = ""
                        .Location = tbLocation.Text.Trim()
                        .Status = "Accepted"
                        '.WarehouseID = drpEquipmentWarehouse.SelectedValue

                        Dim drpInstalled As DropDownList = TryCast(grdPropertyInfo.Rows(i).FindControl("drpInstalledAtOfEquip"), DropDownList)
                        If drpInstalled IsNot Nothing AndAlso drpInstalled.SelectedItem IsNot Nothing AndAlso
                        (drpInstalled.SelectedItem.Text = "N/A" OrElse drpInstalled.SelectedItem.Text = "Field") Then
                            .BuildingId = 0
                        Else
                            .BuildingId = If(drpInstalled IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(drpInstalled.SelectedValue),
                             Convert.ToInt32(drpInstalled.SelectedValue), 0)
                        End If

                        .MaintenanceContactNo = txtCellphoneNo.Text
                        .MaintenanceContactPerson = txtContactPerson.Text
                        .MaintenanceContractor = txtContractor.Text
                        .Property_ID = PropHdr_ID
                    End With
                    objEquipDtl.save()
                Next






                Dim Prop_Ledger As New t_PropertyLedger

                With Prop_Ledger
                    .Ledger_ID = 0
                    .PropertyNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                    .SerialNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNoOfEquip"), TextBox).Text
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
                Prop_Ledger.save()






                btnSave.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                'multiviewselected()
                'loadEquipmentList()
                'loadEquipmentInformation()
                'loadEquipmentInformation_from_drpName()
                loadEquipmentLedger()
            End If

        End If
        ''End If

    End Sub

    Protected Sub btnSave_Click(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If btnSave.Text = "SAVE" Then

            If Not ValidateOfficeEquipmentSelections() Then
                Exit Sub
            End If

            hdnGAId.Value = ddGlAccount.SelectedValue
            hdnItemNo.Value = drpName.SelectedValue
            Session("Item_ID") = drpName.SelectedValue

            Save()

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

            If Not ValidateOfficeEquipmentSelections() Then
                Exit Sub
            End If

            hdnGAId.Value = ddGlAccount.SelectedValue
            hdnItemNo.Value = drpName.SelectedValue
            Session("Item_ID") = drpName.SelectedValue

            Edit()

            btnSave.Text = "EDIT"

            ReadonlyTextBox(True)

            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Property Fields are Updated Successfully."
        )

        End If

        btnSave.Enabled = False
    End Sub

    Public Sub Edit()


        'hf_EquipInfoId.Value = dt1.Rows(0).Item("EquipInfoId").ToString
        'hf_EquipmentId.Value = dt1.Rows(0).Item("EquipmentId").ToString
        'hf_PropertyDetai_ID.Value = dt1.Rows(0).Item("PropertyDetai_ID").ToString
        'hf_Property_ID.Value = dt1.Rows(0).Item("Property_ID").ToString
        'hf_Item_ID.Value = dt1.Rows(0).Item("Item_ID").ToString

        Dim costValue As String = txtEAcqCost.Text.Replace(",", "")

        objDerived.GetRecords("UPDATE [AMS].Property SET Property_Date = '" & txtEAcqDate.Text & "', Cost = " & costValue & " WHERE Property_ID = '" & hf_Property_ID.Value & "'", CommandType.Text)

        ' Handle DepreciationValue
        Dim depreciationValue As Decimal = 0
        Decimal.TryParse(txtequipmentdepreciatedvalue.Text.Replace(",", ""), depreciationValue)

        ' Handle SalvageValue
        Dim salvageValue As Decimal = 0
        Decimal.TryParse(txtSalvageValue.Text.Replace(",", ""), salvageValue)

        'objDerived.GetRecords("UPDATE [AMS].[TbEquipment_Info] SET " &
        '              "PowerInput = '" & txtequipmentpowerinput.Text & "', " &
        '              "Model = '" & txtequipmentmodel.Text & "', " &
        '              "Warranty = '" & txtequipmentwaranty.Text & "', " &
        '              "Dimension = '" & txtequipmentdimension.Text & "', " &
        '              "DepreciationRate = '" & lblequipmentdepreciatedRate.Text & "', " &
        '              "DepreciationValue = " & depreciationValue.ToString() & ", " &
        '              "NoYears = '" & txtNoYears.Text & "', " &
        '              "UsefulLife = '" & txtUsefulLife.Text & "', " &
        '              "SalvageValue = " & salvageValue.ToString() & ", " &
        '              "Description = '" & txtequipmentdesciption.Text & "' " &
        '              "WHERE Property_Dtl_ID = '" & hf_PropertyDetai_ID.Value & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE [AMS].[TbEquipment_Info] SET " &
                     "PowerInput = '" & txtequipmentpowerinput.Text & "', " &
                     "Model = '" & txtequipmentmodel.Text & "', " &
                     "Specification = '" & txtSpecification.Text & "', " &
                     "Warranty = '" & txtequipmentwaranty.Text & "', " &
                     "Dimension = '" & txtequipmentdimension.Text & "', " &
                     "Brand = '" & txtequipmentbrand.Text & "', " &
                     "DepreciationRate = '" & lblequipmentdepreciatedRate.Text & "', " &
                     "DepreciationValue = " & depreciationValue.ToString() & ", " &
                     "NoYears = '" & txtNoYears.Text & "', " &
                     "UsefulLife = '" & txtUsefulLife.Text & "', " &
                     "SalvageValue = " & salvageValue.ToString() & ", " &
                     "Unit_ID = " & drpUnit.SelectedValue & ", " &
                     "Remarks = '" & txtRemarks.Text & "', " &
                     "Description = '" & txtequipmentdesciption.Text & "' " &
                     "WHERE Property_ID = '" & hf_Property_ID.Value & "'", CommandType.Text)

        objDerived.GetRecords("UPDATE [AMS].[TbEquipment_Dtl] SET " &
                     "MarketValue = '" & CType(txtEMarketValue.Text, Decimal) & "', " &
                     "MaintenanceContractor = '" & txtContractor.Text & "', " &
                     "MaintenanceContactPerson = '" & txtContactPerson.Text & "', " &
                     "MaintenanceContactNo = '" & txtCellphoneNo.Text & "'" &
                     "WHERE Property_ID = '" & hf_Property_ID.Value & "'", CommandType.Text)


        Dim BalanceUnit As String = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & hdnItemNo.Value & "'", CommandType.Text)

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
        Dim BalanceQty As Integer = Eqty + txtEquipmentQuantity.Text
        Dim BalanceCost As Decimal = (CType(txtEAcqCost.Text, Decimal) * txtEquipmentQuantity.Text) + CType(Eqbalance, Decimal)

        objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] SET " &
                     "DebitQty = '" & txtEquipmentQuantity.Text & "', " &
                     "DebitUnit = '" & drpUnit.Text & "', " &
                     "DebitCost = '" & (CType(txtEAcqCost.Text, Decimal) * CType(txtEquipmentQuantity.Text, Decimal)).ToString("F2") & "', " &
                     "BalanceQty = '" & txtEquipmentQuantity.Text & "', " &
                     "BalanceUnit = '" & drpUnit.Text & "', " &
                     "BalanceCost = '" & (CType(txtEAcqCost.Text, Decimal) * CType(txtEquipmentQuantity.Text, Decimal)).ToString("F2") & "' " &
                     "WHERE Property_ID = '" & hf_Property_ID.Value & "'", CommandType.Text)


        ' Update each Property_Dtl row using the GridView DataKeys (PropertyDetai_ID)
        For xa As Integer = 0 To grdPropertyInfo.Rows.Count - 1  ' xa = row index
            Dim row As GridViewRow = grdPropertyInfo.Rows(xa)

            Dim tbPropNo As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)
            Dim tbSerial As TextBox = TryCast(row.FindControl("txtSerialNoOfEquip"), TextBox)
            Dim tbLocation As TextBox = TryCast(row.FindControl("txtPIFloorLocation"), TextBox)
            Dim ddlInstalled As DropDownList = TryCast(row.FindControl("drpInstalledAtOfEquip"), DropDownList)

            AddTrace("PropertyDetai_ID: " & grdPropertyInfo.DataKeys(xa).Values("PropertyDetai_ID"))
            AddTrace("Property_ID: " & grdPropertyInfo.DataKeys(xa).Values("Property_ID"))
            ' Get PropertyDetai_ID from DataKeys for this row
            Dim propDtlObj As Object = Nothing
            If grdPropertyInfo.DataKeys IsNot Nothing AndAlso
               grdPropertyInfo.DataKeys.Count > xa AndAlso
               grdPropertyInfo.DataKeys(xa) IsNot Nothing AndAlso
               grdPropertyInfo.DataKeys(xa).Values IsNot Nothing AndAlso
               grdPropertyInfo.DataKeys(xa).Values.Contains("PropertyDetai_ID") Then

                propDtlObj = grdPropertyInfo.DataKeys(xa).Values("PropertyDetai_ID")
            End If

            If propDtlObj Is Nothing OrElse IsDBNull(propDtlObj) Then
                ' No key for this row; skip
                Continue For
            End If

            Dim propDetaiId As String = propDtlObj.ToString()

            ' Collect values (NULL if blank)
            Dim vPropNo As String = If(tbPropNo Is Nothing, "", tbPropNo.Text.Trim())
            Dim vSerial As String = If(tbSerial Is Nothing, "", tbSerial.Text.Trim())
            Dim vInstalledAt As String = ""
            If ddlInstalled IsNot Nothing Then
                ' Stored proc expects text (e.g., "N/A", "Field", or BuildingName if that’s what you want)
                vInstalledAt = If(ddlInstalled.SelectedItem IsNot Nothing, ddlInstalled.SelectedItem.Text.Trim(), ddlInstalled.SelectedValue.Trim())
            End If
            Dim vLocation As String = If(tbLocation Is Nothing, "", tbLocation.Text.Trim())

            ' Build EXEC with NULL for blanks (keep your DAL style)
            Dim sql As String = "EXEC [AMS].[sp_Update_PropertyDtl_Row] " & propDetaiId & ", " &
                        If(String.IsNullOrEmpty(vPropNo), "NULL", "'" & vPropNo.Replace("'", "''") & "'") & ", " &
                        If(String.IsNullOrEmpty(vSerial), "NULL", "'" & vSerial.Replace("'", "''") & "'") & ", " &
                        If(String.IsNullOrEmpty(vInstalledAt), "NULL", "'" & vInstalledAt.Replace("'", "''") & "'") & ", " &
                        If(String.IsNullOrEmpty(vLocation), "NULL", "'" & vLocation.Replace("'", "''") & "'")

            objDerived.GetRecords(sql, CommandType.Text)
        Next

        ' Get Item_ID
        'Dim ItemID As Long = CLng(objDerived.GetValue("SELECT Item_ID FROM AMS.TbProperty_Ledger WHERE Ledger_ID = '" & LedgerID & "'", CommandType.Text))

        ' REBALANCE FROM EDITED ROW ABOVE
        'objDerived.Execute("EXEC [AMS].[ReBalanceLedger] " & hdnItemNo.Value, CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        loadEquipmentLedger()
    End Sub

    Protected Sub loadEquipmentInformation_from_drpName()
        Dim CYear As String = "CY" & Year(txtDate.Text)
        Dim itemid As String

        'loadwarehouse()
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
            ClrText()
        Else

            hdnItemNo.Value = itemid
            hdnGAId.Value = objDerived.GetValue("select GA_ID From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & hdnItemNo.Value, CommandType.Text)
            txtName.Text = dt.Rows(0).Item("Name").ToString
            txtequipmentdesciption.Text = dt.Rows(0).Item("description").ToString
            'txtequipmentpowerinput.Text = objDerived.GetValue("select e.PowerInput from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtequipmentdimension.Text = objDerived.GetValue("select e.Dimension from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtequipmentareacapacity.Text = objDerived.GetValue("select e.AreaCapacity from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtequipmentmodel.Text = objDerived.GetValue("select e.Model from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtequipmentwaranty.Text = objDerived.GetValue("select e.Warranty from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtSpecification.Text = objDerived.GetValue("select e.Specification from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtEAcqDate.text = objDerived.GetValue("select c.Property_Date from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            'txtEAcqCost.text = objDerived.GetValue("select c.Cost from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                                   "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                                   "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                                   "inner join ams.TbEquipment_Info as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                                   "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)

            txtEMarketValue.Text = dt.Rows(0).Item(CYear).ToString
            'Dim DA As DateTime
            'DA = grdlistofEuipment.SelectedDataKey("Date_Accepted")
            txtNoYears.Text = " "
            txtequipmentdepreciatedvalue.Text = FormatNumber(0, 2)
            lblequipmentdepreciatedRate.Text = " "
            lblequipmentdepreciatedRate.ReadOnly = False


            '''--------------------location
            'Optimize code
            Dim location As String
            location = objDerived.Execute("Exec [AMS].[GetLocationForItem] '" & hdnItemNo.Value & "'", CommandType.Text)
            ''objDerived.GetValue("select Location from dbo.m_item as a left outer join dbo.m_item_detail as b on a.Item_ID = b.Item_ID " &
            '                                               "inner join ams.Property as c on a.Item_ID = c.Item_ID " &
            '                                               "inner join ams.Property_Dtl as d on c.Property_ID = d.Property_ID " &
            '                                               "inner join ams.TbEquipment_Dtl  as e on d.PropertyDetai_ID  = e.Property_Dtl_ID " &
            '                                               "where a.Item_ID =" & HDnItemNo.value, CommandType.Text)
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
                dt1 = objDerived.GetDataTable("[AMS].[sp_View_Encoding] 'OfficeEquipment','" & itemid & "'", CommandType.Text)
                If dt1.Rows.Count > 0 Then
                    ''txtequipmentdesciption.Text = dt1.Rows(0).Item("Description").ToString
                    txtequipmentpowerinput.Text = dt1.Rows(0).Item("PowerInput").ToString
                    txtequipmentmodel.Text = dt1.Rows(0).Item("Model").ToString
                    txtSpecification.Text = dt1.Rows(0).Item("Specification").ToString
                    txtequipmentSerialNo.Text = dt1.Rows(0).Item("SerialNo").ToString
                    drpUnit.SelectedValue = dt1.Rows(0).Item("Unit_ID").ToString
                    txtEquipmentQuantity.Text = dt1.Rows(0).Item("DebitQty").ToString
                    txtequipmentwaranty.Text = dt1.Rows(0).Item("Warranty").ToString
                    'drpInstalledAtBuilding.SelectedValue = dt1.Rows(0).Item("Buildingid").ToString
                    txtequipmentdimension.Text = dt1.Rows(0).Item("Dimension").ToString
                    txtequipmentbrand.Text = dt1.Rows(0).Item("Brand").ToString
                    txtContractor.Text = dt1.Rows(0).Item("MaintenanceContractor").ToString
                    txtContactPerson.Text = dt1.Rows(0).Item("MaintenanceContactPerson").ToString
                    txtCellphoneNo.Text = dt1.Rows(0).Item("MaintenanceContactNo").ToString
                    txtEAcqDate.Text = Convert.ToDateTime(dt1.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
                    txtEAcqCost.Text = Val(dt1.Rows(0).Item("Cost").ToString).ToString("n2")
                    lblequipmentdepreciatedRate.Text = dt1.Rows(0).Item("DepreciationRate").ToString
                    txtequipmentdepreciatedvalue.Text = Val(dt1.Rows(0).Item("DepreciationValue").ToString).ToString("n2")
                    txtEMarketValue.Text = Val(dt1.Rows(0).Item("MarketValue").ToString).ToString("n2")
                    txtNoYears.Text = dt1.Rows(0).Item("NoYears").ToString
                    txtUsefulLife.Text = dt1.Rows(0).Item("UsefulLife").ToString
                    txtSalvageValue.Text = Val(dt1.Rows(0).Item("SalvageValue").ToString).ToString("n2")

                    hf_EquipInfoId.Value = dt1.Rows(0).Item("EquipInfoId").ToString
                    hf_EquipmentId.Value = dt1.Rows(0).Item("EquipmentId").ToString
                    hf_PropertyDetai_ID.Value = dt1.Rows(0).Item("PropertyDetai_ID").ToString
                    hf_Property_ID.Value = dt1.Rows(0).Item("Property_ID").ToString
                    hf_Item_ID.Value = dt1.Rows(0).Item("Item_ID").ToString
                End If
            End If


            'txtUsefulLife.Text = ""
            'txtSalvageValue.Text = FormatNumber(0, 2)
            'txtSalvageValue.Text = ""
            Session("useful_life") = 0

            'drpUnit.Items.FindByValue(dt.Rows(0).Item(9)).Selected = True
            btnSave.Enabled = True
            btnCancel.Enabled = True
            hdnItemNo.Value = itemid
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
        If hdnItemNo.Value = "" Then
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)

        Else
            AddTrace("Executing Stored Procedure: Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'")

            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)

        End If
        ' dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If dtAccount.Rows.Count > 0 Then
            btnSave.Text = "EDIT"

        Else
            btnSave.Text = "SAVE"
            ClrText()

        End If

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
    End Sub

    Protected Sub LoadEquipDepreciation()
        Try
            Dim Cost As Double
            Dim SalValue As Double
            Dim TDepValue As Double
            Dim AcquisitionYear As Date
            Dim NoYears As Integer
            Dim DepVRate As Double
            Dim DepPRate As Double
            Dim ULife As Integer

            AcquisitionYear = txtEAcqDate.Text
            Cost = txtEAcqCost.Text
            ULife = txtUsefulLife.Text
            SalValue = FormatNumber(CType(txtSalvageValue.Text, Decimal), 2)
            NoYears = (Year(txtDate.Text) - Year(AcquisitionYear))

            'FORMULA USE: 
            'LET:
            'DV = DEPRECIATED VALUE
            'LFE = USEFUL LIFE
            'AC = ACQUISITION COST
            'NY = NUMBER OF YEARS FROM DATE ITEM ACQUIRED
            'DR = DEPRECIATION RATE
            'SalValue = SALVAGE VALUE
            'DepVRate = DEPRECIATION RATE AMOUNT PER YEAR
            'DepPRate = DEPRECIATION RATE PERCENT PER YEAR

            '============================
            'DEPRECIATION RATE (AMOUNT) = (COST - SALVAGE) / USEFUL LIFE
            DepVRate = ((Cost - SalValue) / ULife)

            'DEPRECIATION RATE (PERCENT) = (SALVAGE / COST) * 100
            DepPRate = FormatNumber(((DepVRate / Cost) * 100), 2)

            'TOTAL DEPRECIATION VALUE = COST - (DEP.VALUE * NO. YEARS)
            TDepValue = FormatNumber(Cost - (DepVRate * NoYears), 2)

            'objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET DepreciationRate = '" & DepPRate & "',DepreciationValue = '" & TDepValue & "',SalvageValue = '" & SalValue & "' WHERE Property_Dtl_ID = '" & grdlistofEuipment.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)

            lblequipmentdepreciatedRate.Text = DepPRate
            If FormatNumber(TDepValue, 2) = 0.00 Then
                txtequipmentdepreciatedvalue.Text = " "
            Else
                txtequipmentdepreciatedvalue.Text = FormatNumber(TDepValue, 2)

            End If
            If FormatNumber(SalValue, 2) = 0.00 Then
                txtSalvageValue.Text = " "
            Else
                txtSalvageValue.Text = FormatNumber(SalValue, 2)

            End If

            txtEMarketValue.Text = FormatNumber(Cost - TDepValue, 2)

        Catch ex As Exception
        End Try
    End Sub
    Public Sub multiviewselected()
        Dim subcategoryID As Integer = 0
        Dim categoryID As Integer = 0
        Dim gaID As Integer = 0

        If ddSubCategory.SelectedValue IsNot Nothing AndAlso
       ddSubCategory.SelectedValue <> "" Then

            Integer.TryParse(
            ddSubCategory.SelectedValue,
            subcategoryID
        )

        End If

        If ddCategory.SelectedValue IsNot Nothing AndAlso
       ddCategory.SelectedValue <> "" Then

            Integer.TryParse(
            ddCategory.SelectedValue,
            categoryID
        )

        End If

        If ddGlAccount.SelectedValue IsNot Nothing AndAlso
       ddGlAccount.SelectedValue <> "" Then

            Integer.TryParse(
            ddGlAccount.SelectedValue,
            gaID
        )

        End If

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

        If ddGlAccount.SelectedValue Is Nothing OrElse
       ddGlAccount.SelectedValue = "" OrElse
       ddGlAccount.SelectedValue = "0" OrElse
       drpSubClass.SelectedValue Is Nothing OrElse
       drpSubClass.SelectedValue = "" OrElse
       drpSubClass.SelectedValue = "0" Then

            ClearItemDesc()
            loadEquipmentLedger()
            btnSave.Text = "SAVE"
            Exit Sub

        End If

        LoadItemDesc()
        loadEquipmentLedger()

        btnSave.Text = "SAVE"
    End Sub

    Private Function ValidateOfficeEquipmentSelections() As Boolean

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

    Protected Sub LoadEquipDTL()
        'txtName.Text = ""
        'txtequipmentdesciption.Text = ""
        'txtequipmentpowerinput.Text = ""
        'txtequipmentdimension.Text = ""
        'txtequipmentareacapacity.Text = ""
        'txtequipmentmodel.Text = ""
        'txtequipmentwaranty.Text = ""
        'txtSpecification.Text = ""
        'txtSalvageValue.Text = ""
        'optimize code
        Dim textboxes As TextBox() = {txtName, txtequipmentdesciption, txtequipmentpowerinput, txtequipmentdimension, txtequipmentareacapacity, txtequipmentmodel, txtequipmentwaranty, txtSpecification, txtSalvageValue}

        For Each textbox As TextBox In textboxes
            textbox.Text = String.Empty
        Next

        lblequipmentdepreciatedvalue.Text = ""
        lblequipmentdepreciatedRate.Text = ""
    End Sub

    Protected Sub btnEquipmentLedger_Click(sender As Object, e As EventArgs)
        loadEquipmentLedger()
    End Sub

    Protected Sub btnequipmentrepairs_Click(sender As Object, e As EventArgs)
        loadEquipmentRepair()
    End Sub
    Protected Sub btnequipmentattachdoc_Click(sender As Object, e As EventArgs)
        loadEquipmentAttchDocu()
        loadAttchDocuChangeIndex()
    End Sub
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        'Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        'Dim cell As New TableHeaderCell()
        'cell.Text = "OFFICE EQUIPMENT"
        'cell.ColumnSpan = 3
        'row.Controls.Add(cell)

        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 2
        'cell.Text = "DEBIT"
        'row.Controls.Add(cell)


        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 2
        'cell.Text = "CREDIT"
        'row.Controls.Add(cell)


        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 2
        'cell.Text = "BALANCE"
        'row.Controls.Add(cell)

        'row.BackColor = ColorTranslator.FromHtml("WHITE")
        'row.ForeColor = ColorTranslator.FromHtml("BLACK")
        'grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)

        'DONT UNCOMMENT, BUGGED OUT WHEN CHECKED CHECKBOX(NEWLY ADDED)
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
    Public Function createdatatableledger(ByVal row As Integer) As DataTable
        'Dim dt As New DataTable()
        'Dim dr As DataRow
        'Dim myDataColumn As DataColumn
        'myDataColumn = New DataColumn()
        ''dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        'dt.Columns.Add("dDate", GetType(Date))
        'dt.Columns.Add("Trans_Type", GetType(String))
        'dt.Columns.Add("ref", GetType(String))
        'dt.Columns.Add("AccountablePerson", GetType(String))
        'dt.Columns.Add("Department", GetType(String))
        'dt.Columns.Add("position", GetType(String))
        'dt.Columns.Add("acceptedby", GetType(String))
        'dt.Columns.Add("inspectedby", GetType(String))
        'dt.Columns.Add("DebitQty", GetType(Integer))
        'dt.Columns.Add("DebitUnit", GetType(String))
        'dt.Columns.Add("DebitCost", GetType(Decimal))
        'dt.Columns.Add("CreditQty", GetType(Integer))
        'dt.Columns.Add("CreditUnit", GetType(String))
        'dt.Columns.Add("CreditCost", GetType(Decimal))
        'dt.Columns.Add("BalQty", GetType(Integer))
        'dt.Columns.Add("BalanceUnit", GetType(String))
        'dt.Columns.Add("BalCost", GetType(Decimal))
        'For i As Integer = 0 To row
        '    dr = dt.NewRow
        '    'dr("Property_Dtl_ID") = DBNull.Value
        '    dr("dDate") = DBNull.Value
        '    dr("Trans_Type") = DBNull.Value
        '    dr("ref") = DBNull.Value
        '    dr("AccountablePerson") = DBNull.Value
        '    dr("Department") = DBNull.Value
        '    dr("position") = DBNull.Value
        '    dr("acceptedby") = DBNull.Value
        '    dr("inspectedby") = DBNull.Value
        '    dr("DebitQty") = DBNull.Value
        '    dr("DebitUnit") = DBNull.Value
        '    dr("DebitCost") = DBNull.Value
        '    dr("CreditQty") = DBNull.Value
        '    dr("CreditUnit") = DBNull.Value
        '    dr("CreditCost") = DBNull.Value
        '    dr("BalQty") = DBNull.Value
        '    dr("BalanceUnit") = DBNull.Value
        '    dr("BalCost") = DBNull.Value
        '    dt.Rows.Add(dr)
        'Next
        'Return dt
        ''Optimize  
        Dim dt As New DataTable()
        dt.Columns.AddRange({
            New DataColumn("dDate", GetType(Date)) With {.DefaultValue = DBNull.Value},
            New DataColumn("Trans_Type", GetType(String)) With {.DefaultValue = DBNull.Value},
            New DataColumn("ref", GetType(String)) With {.DefaultValue = DBNull.Value},
            New DataColumn("AccountablePerson", GetType(String)) With {.DefaultValue = DBNull.Value},
            New DataColumn("Department", GetType(String)) With {.DefaultValue = DBNull.Value},
            New DataColumn("position", GetType(String)) With {.DefaultValue = DBNull.Value},
            New DataColumn("acceptedby", GetType(String)) With {.DefaultValue = DBNull.Value},
            New DataColumn("inspectedby", GetType(String)) With {.DefaultValue = DBNull.Value},
            New DataColumn("DebitQty", GetType(Integer)) With {.DefaultValue = DBNull.Value},
            New DataColumn("DebitUnit", GetType(String)) With {.DefaultValue = DBNull.Value},
            New DataColumn("DebitCost", GetType(Decimal)) With {.DefaultValue = DBNull.Value},
            New DataColumn("CreditQty", GetType(Integer)) With {.DefaultValue = DBNull.Value},
            New DataColumn("CreditUnit", GetType(String)) With {.DefaultValue = DBNull.Value},
            New DataColumn("CreditCost", GetType(Decimal)) With {.DefaultValue = DBNull.Value},
            New DataColumn("BalQty", GetType(Integer)) With {.DefaultValue = DBNull.Value},
            New DataColumn("BalanceUnit", GetType(String)) With {.DefaultValue = DBNull.Value},
            New DataColumn("BalCost", GetType(Decimal)) With {.DefaultValue = DBNull.Value}
        })
        For i As Integer = 0 To row
            dt.Rows.Add(dt.NewRow())
        Next
        Return dt
    End Function
    Protected Sub drpSubClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"

        LoadItemDesc()

        ClrText()
        loadEquipmentLedger()

        AddTrace(
        "drpSubClass: " &
        drpSubClass.SelectedValue
    )
    End Sub
    Protected Sub ddCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        selectCatergory()

    End Sub
    Protected Sub ddGlAccount_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        Session("Item_ID") = 0

        hdnGAId.Value = If(
        ddGlAccount.SelectedValue Is Nothing,
        "0",
        ddGlAccount.SelectedValue
    )

        hdnItemNo.Value = "0"

        LoadSubClassifications()
        ClearItemDesc()

        SelectGAaccount()

        ClrText()
        LoadItemDesc()

        loadEquipmentLedger()

        AddTrace(
        "ddGlAccount: " &
        ddGlAccount.SelectedValue
    )
    End Sub
    Protected Sub ddSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        multiviewselected()
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

    Protected Sub gvsearchproperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSave.Enabled = True
        btnCancel.Enabled = True
        ' loadEquipmentList()

        grdlistofEuipment.SelectedIndex = 0
        ' loadEquipmentInformation()
        loadEquipmentLedger()

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
            ' loadEquipmentInformation()
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

    Protected Sub btnaddpropertyinfo_Click(sender As Object, e As EventArgs)
        If btnSave.Text = "SAVE" Then

            If txtEquipmentQuantity.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
                Exit Sub
            End If

            ' Validate quantity is a positive number
            Dim qty As Integer = 0
            If Not Integer.TryParse(txtEquipmentQuantity.Text, qty) OrElse qty <= 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid Quantity.")
                Exit Sub
            End If

            ' Create empty rows for property information
            Dim dtEmpty As DataTable = CreatePropertyInfoTable(qty) ' has the key columns
            ViewState("Customers") = dtEmpty
            BindGrid()

            ' ========================
            ' GENERATE PROPERTY NUMBERS USING STORED PROCEDURE
            ' ========================
            Try
                ' Get GA_ID from the hidden field or dropdown
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
                            Dim drpInstalledAtOfEquip As DropDownList = CType(row1.FindControl("drpInstalledAtOfEquip"), DropDownList)

                            ' Clear other fields (check if controls exist)
                            If txtSerialNumber IsNot Nothing Then txtSerialNumber.Text = String.Empty
                            If txtPIFloorLocation IsNot Nothing Then txtPIFloorLocation.Text = String.Empty
                            If drpInstalledAtOfEquip IsNot Nothing Then
                                drpInstalledAtOfEquip.ClearSelection()
                                drpInstalledAtOfEquip.SelectedValue = "N/A" ' Set default to N/A
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

            EnableGridInputs()
            ModalPopupExtender2.Show()

        ElseIf btnSave.Text = "EDIT" Or btnSave.Text = "UPDATE" Then

            counts = 0
            If txtEquipmentQuantity.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
            Else

                Dim qty As Integer = 0
                Integer.TryParse(txtEquipmentQuantity.Text, qty)
                ' Get rows to edit (must include Property_ID and PropertyDetai_ID)
                Dim dt1 As DataTable = objDerived.GetDataTable("EXEC [AMS].[OfficeEquipmentLedgerList] '" & Session("Ledger_ID") & "'", CommandType.Text)

                ' --- normalize column names to match DataKeyNames ---
                If Not dt1.Columns.Contains("Property_ID") Then
                    ' some procs use PropertyId / PropertyID etc. Map them if needed:
                    If dt1.Columns.Contains("PropertyID") Then dt1.Columns("PropertyID").ColumnName = "Property_ID"
                    If dt1.Columns.Contains("PropertyId") Then dt1.Columns("PropertyId").ColumnName = "Property_ID"
                End If

                If Not dt1.Columns.Contains("PropertyDetai_ID") Then
                    ' often named Property_Dtl_ID / PropertyDetaiId / PropertyDetail_ID
                    If dt1.Columns.Contains("Property_Dtl_ID") Then dt1.Columns("Property_Dtl_ID").ColumnName = "PropertyDetai_ID"
                    If dt1.Columns.Contains("PropertyDetaiId") Then dt1.Columns("PropertyDetaiId").ColumnName = "PropertyDetai_ID"
                End If

                ' IMPORTANT: the grid must bind to the table that has the keys
                ViewState("Customers") = dt1
                BindGrid()
                ModalPopupExtender2.Show()

                ' Loop through the rows of the GridView and assign the corresponding values from dt1
                For xa As Integer = 0 To grdPropertyInfo.Rows.Count - 1

                    ' Safety check in case dt1 has fewer rows than the grid
                    If xa >= dt1.Rows.Count Then Exit For

                    Dim row1 As GridViewRow = grdPropertyInfo.Rows(xa)

                    Dim tbPropertyNo As TextBox = TryCast(row1.FindControl("txtPropertyNo"), TextBox)
                    Dim tbSerial As TextBox = TryCast(row1.FindControl("txtSerialNoOfEquip"), TextBox)
                    Dim tbLocation As TextBox = TryCast(row1.FindControl("txtPIFloorLocation"), TextBox)
                    Dim ddlInstalled As DropDownList = TryCast(row1.FindControl("drpInstalledAtOfEquip"), DropDownList)

                    AddTrace("PropertyDetai_ID: " & grdPropertyInfo.DataKeys(xa).Values("PropertyDetai_ID"))
                    AddTrace("Property_ID: " & grdPropertyInfo.DataKeys(xa).Values("Property_ID"))

                    ' Property No (readonly)
                    If tbPropertyNo IsNot Nothing Then
                        tbPropertyNo.Text = If(IsDBNull(dt1.Rows(xa)("PropertyNo")), "", dt1.Rows(xa)("PropertyNo").ToString())
                        tbPropertyNo.ReadOnly = True
                        tbPropertyNo.Enabled = False
                    End If

                    ' Serial No from Property_Dtl
                    If tbSerial IsNot Nothing Then
                        tbSerial.Text = If(IsDBNull(dt1.Rows(xa)("SerialNo")), "", dt1.Rows(xa)("SerialNo").ToString())

                    End If

                    ' Location from Property_Dtl (replaces FloorLocation)
                    If tbLocation IsNot Nothing Then
                        tbLocation.Text = If(IsDBNull(dt1.Rows(xa)("Location")), "", dt1.Rows(xa)("Location").ToString())

                    End If

                    ' Installed At dropdown: Property_Dtl first, then Buildingid if InstalledAt is null/empty
                    If ddlInstalled IsNot Nothing Then
                        ' --- try InstalledAt (Property_Dtl) first ---
                        Dim installedAt As String = ""
                        If dt1.Columns.Contains("InstalledAt") AndAlso Not IsDBNull(dt1.Rows(xa)("InstalledAt")) Then
                            installedAt = dt1.Rows(xa)("InstalledAt").ToString().Trim()
                        End If

                        If installedAt <> "" Then
                            ' match by Text (handles "N/A", "Field")
                            Dim liMatch As ListItem = ddlInstalled.Items.FindByText(installedAt)
                            If liMatch IsNot Nothing Then
                                ddlInstalled.ClearSelection()
                                liMatch.Selected = True
                            Else
                                ' try as Value
                                Try
                                    ddlInstalled.SelectedValue = installedAt
                                Catch
                                    ' ignore if not found
                                End Try
                            End If
                        End If

                        ' --- fallback to Buildingid if nothing selected ---
                        If ddlInstalled.SelectedIndex = -1 Then
                            Dim buildingId As String = ""
                            If dt1.Columns.Contains("Buildingid") AndAlso Not IsDBNull(dt1.Rows(xa)("Buildingid")) Then
                                buildingId = dt1.Rows(xa)("Buildingid").ToString()
                            End If

                            If buildingId <> "" Then
                                Try
                                    ddlInstalled.SelectedValue = buildingId
                                Catch
                                    ' ignore if value not in list
                                End Try
                            End If
                        End If
                    End If
                Next
            End If

            If btnSave.Text = "EDIT" Then
                DisableGridInputs()
            End If
            If btnSave.Text = "UPDATE" Then
                EnableGridInputs()
            End If
        End If
    End Sub


    Public Sub LoadBuildings()
        On Error Resume Next
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("select BuildingId,BuildingName+' - '+Address as Name From ams.TbBuilding_Dtl as a inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID order by BuildingName", CommandType.Text)
        drpInstalledAtBuilding.DataSource = dt
        drpInstalledAtBuilding.DataTextField = ("Name")
        drpInstalledAtBuilding.DataValueField = ("BuildingId")
        drpInstalledAtBuilding.DataBind()
        drpInstalledAtBuilding.Items.Insert(0, New ListItem("N/A"))
    End Sub

    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Get the dropdown and textboxes
            Dim ddlCountries As DropDownList = CType(e.Row.FindControl("drpInstalledAtOfEquip"), DropDownList)

            ' Only bind dropdown if it's not already bound (avoid multiple binding)
            If ddlCountries IsNot Nothing AndAlso ddlCountries.Items.Count = 0 Then
                Dim dtBuildings As DataTable = objDerived.GetDataTable(
                "select BuildingId, BuildingName + ' - ' + ISNULL(Address, '') as Name " &
                "From ams.TbBuilding_Dtl as a " &
                "inner join ams.Property_Dtl as b on a.Property_Dtl_ID = b.PropertyDetai_ID " &
                "order by BuildingName", CommandType.Text)

                If dtBuildings IsNot Nothing Then
                    ddlCountries.DataSource = dtBuildings
                    ddlCountries.DataTextField = "Name"
                    ddlCountries.DataValueField = "BuildingId"
                    ddlCountries.DataBind()

                    'Add Default Items in the DropDownList
                    ddlCountries.Items.Insert(0, New ListItem("Field", "Field"))
                    ddlCountries.Items.Insert(0, New ListItem("N/A", "N/A"))
                End If
            End If

            Dim drp As DropDownList = CType(e.Row.FindControl("drpInstalledAtOfEquip"), DropDownList)
            Dim textPN As TextBox = CType(e.Row.FindControl("txtPropertyNo"), TextBox)
            Dim textSN As TextBox = CType(e.Row.FindControl("txtSerialNoOfEquip"), TextBox)
            Dim textL As TextBox = CType(e.Row.FindControl("txtPIFloorLocation"), TextBox)

            ' Only try to populate from database if we're in EDIT/UPDATE mode and we have a valid Item_ID
            If (btnSave.Text = "EDIT" Or btnSave.Text = "UPDATE") AndAlso Not String.IsNullOrEmpty(hdnItemNo.Value) Then
                Dim dt1 As DataTable = Nothing
                Try
                    dt1 = objDerived.GetDataTable(
                    "SELECT b.SerialNo, b.PropertyNo, AMS.TbEquipment_Dtl.Buildingid, " &
                    "AMS.TbEquipment_Dtl.Location, AMS.TbEquipment_Dtl.EquipmentId " &
                    "FROM AMS.Property as a " &
                    "INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID " &
                    "INNER JOIN AMS.TbEquipment_Dtl ON b.PropertyDetai_ID = AMS.TbEquipment_Dtl.Property_Dtl_ID " &
                    "INNER JOIN AMS.TbEquipment_Info as c ON AMS.TbEquipment_Dtl.EquipInfoId = c.EquipInfoId " &
                    "WHERE a.Item_ID = " & hdnItemNo.Value, CommandType.Text)
                Catch ex As Exception
                    AddTrace("Error loading property data: " & ex.Message)
                    dt1 = Nothing
                End Try

                If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 AndAlso counts < dt1.Rows.Count Then
                    ' Set Serial Number
                    If textSN IsNot Nothing AndAlso Not IsDBNull(dt1.Rows(counts)("SerialNo")) Then
                        textSN.Text = dt1.Rows(counts)("SerialNo").ToString()
                    End If

                    ' Set Property Number (readonly in EDIT mode)
                    If textPN IsNot Nothing AndAlso Not IsDBNull(dt1.Rows(counts)("PropertyNo")) Then
                        textPN.Text = dt1.Rows(counts)("PropertyNo").ToString()
                        textPN.ReadOnly = True
                        textPN.Enabled = False
                    End If

                    ' Set Building dropdown
                    If drp IsNot Nothing AndAlso Not IsDBNull(dt1.Rows(counts)("Buildingid")) Then
                        Dim buildingId As String = dt1.Rows(counts)("Buildingid").ToString()
                        If Not String.IsNullOrEmpty(buildingId) Then
                            Try
                                drp.SelectedValue = buildingId
                            Catch ex As Exception
                                ' If building ID not found in dropdown, set to N/A
                                drp.SelectedValue = "N/A"
                            End Try
                        End If
                    End If

                    ' Set Location
                    If textL IsNot Nothing AndAlso Not IsDBNull(dt1.Rows(counts)("Location")) Then
                        textL.Text = dt1.Rows(counts)("Location").ToString()
                    End If
                End If
            End If

            ' Increment counter for next row
            counts += 1
        End If

        ' Store the data source in ViewState for later use
        If grdPropertyInfo.DataSource IsNot Nothing Then
            ViewState("Customers") = grdPropertyInfo.DataSource
        End If
    End Sub
    Protected Sub btnProceedEdit_Click(sender As Object, e As EventArgs)
        Dim text As TextBox
        Dim propertyNo As String = ""

        ' Check if the PropertyNo textbox exists in the GridView
        For Each row As GridViewRow In grdPropertyInfo.Rows
            text = CType(row.FindControl("txtPropertyNo"), TextBox)
            propertyNo = text.Text.Trim()

            '' Check if PropertyNo is not empty
            'If Not String.IsNullOrEmpty(propertyNo) Then
            '    ' Query to check if the PropertyNo already exists in the AMS.Property_Dtl table
            '    Dim dt As New DataTable
            '    dt = objDerived.GetDataTable("SELECT PropertyNo FROM AMS.Property_Dtl WHERE PropertyNo = '" & propertyNo & "'", CommandType.Text)

            '    ' If PropertyNo exists, show message and exit
            '    If dt.Rows.Count > 0 Then
            '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property number already exists.")
            '        'Exit Sub
            '    Else
            '        ModalPopupExtender2.Hide()
            '    End If
            'End If
        Next

        ' If no duplicate found, hide the modal popup

    End Sub


    Private Function CreatePropertyInfoTable(rowCount As Integer) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Property_ID", GetType(Long))     ' <-- required by DataKeyNames
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("InstalledAt", GetType(String))
        dt.Columns.Add("Location", GetType(String))

        For i As Integer = 1 To rowCount
            Dim r = dt.NewRow()
            r("Property_ID") = DBNull.Value   ' or 0L
            r("PropertyNo") = DBNull.Value
            r("PropertyDetai_ID") = DBNull.Value
            r("SerialNo") = DBNull.Value
            r("InstalledAt") = DBNull.Value
            r("Location") = DBNull.Value
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
    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & drpApprovedOfficer.SelectedValue() & "' and npassword = '" & DecryptEncrypt(txtApprovedPass.Text) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")
        Else
            btnSave.Text = "UPDATE"
            btnSave.Enabled = True
        End If
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ModalPopupExtender1.Hide()
    End Sub

    Public Sub ClrText()

        txtequipmentdepreciatedvalue.Text = "0.00"
        txtEAcqCost.Text = "0.00"
        'drpUnit.SelectedIndex = 0
        Dim textboxes As TextBox() = {txtName, txtequipmentdesciption, txtequipmentpowerinput, txtequipmentdimension, txtequipmentareacapacity, txtContractor, txtContactPerson, txtCellphoneNo, txtequipmentbrand, txtSpecification,
            txtequipmentmodel, txtequipmentwaranty, txtSpecification, txtSalvageValue, txtEquipmentQuantity, txtEMarketValue, txtNoYears, lblequipmentdepreciatedRate, txtEAcqDate, txtRemarks, txtUsefulLife, txtNoYears}

        For Each textbox As TextBox In textboxes
            textbox.Text = String.Empty
        Next
        btnSave.Text = "SAVE"

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



    Protected Sub drpInstalledAtMac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim drp As DropDownList
        Dim text As TextBox
        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            drp = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtOfEquip"), DropDownList)
            If drp.SelectedItem.Text = "N/A" Or drp.SelectedItem.Text = "Field" Then
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = True
                If text.Text <> "" Then
                Else
                    text.Text = ""
                End If

            Else
                text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtPIFloorLocation"), TextBox)
                text.Enabled = False

                Dim drp1 As DropDownList
                drp1 = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("drpInstalledAtOfEquip"), DropDownList)

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

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        ClrText()

        btnSave.Text = "SAVE"
        btnSave.Enabled = True
        txtEquipmentQuantity.Enabled = True

        ReadonlyTextBox(False)

        Dim cb1 As CheckBox

        ' Declare the checkbox and get the row
        Dim cb As CheckBox = CType(sender, CheckBox)
        Dim row As GridViewRow = CType(cb.NamingContainer, GridViewRow)
        ' Get the index of the row where the checkbox was clicked
        Dim rowIndex As Integer = row.RowIndex

        ' Safely get the Property_ID from the DataKeys collection
        Dim propertyId As String = "0"
        If grdLedger1.DataKeys IsNot Nothing AndAlso grdLedger1.DataKeys.Count > rowIndex AndAlso grdLedger1.DataKeys(rowIndex)("Property_ID") IsNot Nothing Then
            propertyId = grdLedger1.DataKeys(rowIndex)("Property_ID").ToString()
            Session("Ledger_ID") = grdLedger1.DataKeys(rowIndex)("Ledger_ID").ToString()
            AddTrace("Ledger_ID" & Session("Ledger_ID"))
        End If

        AddTrace("Executing Stored Procedure: EXEC [AMS].[sp_View_Encoding_v2] 'OfficeEquipment','" & hdnItemNo.Value & "','" & propertyId & "'")

        ' Build and execute the stored procedure call
        Dim dt1 As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_View_Encoding_v2] 'OfficeEquipment','" & hdnItemNo.Value & "','" & propertyId & "'", CommandType.Text)

        'Dim dt1 As DataTable = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & hdnItemNo.Value & "'", CommandType.Text)
        For i As Integer = 0 To grdLedger1.Rows.Count - 1
            cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

            If cb1.Checked AndAlso cb1.Visible Then

                btnSave.Text = "EDIT"

                'Dim dt2 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TBSupplies_Info AS a WHERE  (ItemId = '" & drpItemDesc1.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)
                'Dim dt3 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.Stock AS a WHERE  (Item_ID = '" & drpItemDesc1.SelectedItem.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)


                If dt1.Rows.Count > 0 Then
                    txtequipmentdesciption.Text = dt1.Rows(0).Item("Description").ToString
                    txtequipmentpowerinput.Text = dt1.Rows(0).Item("PowerInput").ToString
                    txtequipmentmodel.Text = dt1.Rows(0).Item("Model").ToString
                    txtSpecification.Text = dt1.Rows(0).Item("Specification").ToString
                    txtequipmentSerialNo.Text = dt1.Rows(0).Item("SerialNo").ToString
                    'drpUnit.SelectedValue = dt1.Rows(0).Item("Unit_ID").ToString
                    txtEquipmentQuantity.Text = dt1.Rows(0).Item("DebitQty").ToString
                    txtEquipmentQuantity.Enabled = False
                    txtequipmentwaranty.Text = dt1.Rows(0).Item("Warranty").ToString
                    txtRemarks.Text = dt1.Rows(0).Item("Remarks").ToString
                    'drpInstalledAtBuilding.SelectedValue = dt1.Rows(0).Item("Buildingid").ToString
                    txtequipmentdimension.Text = dt1.Rows(0).Item("Dimension").ToString
                    txtequipmentbrand.Text = dt1.Rows(0).Item("Brand").ToString
                    txtContractor.Text = dt1.Rows(0).Item("MaintenanceContractor").ToString
                    txtContactPerson.Text = dt1.Rows(0).Item("MaintenanceContactPerson").ToString
                    txtCellphoneNo.Text = dt1.Rows(0).Item("MaintenanceContactNo").ToString
                    txtEAcqDate.Text = Convert.ToDateTime(dt1.Rows(0).Item("Property_Date").ToString).ToString("MM/dd/yyyy")
                    txtEAcqCost.Text = Val(dt1.Rows(0).Item("Cost").ToString).ToString("n2")
                    lblequipmentdepreciatedRate.Text = dt1.Rows(0).Item("DepreciationRate").ToString
                    txtequipmentdepreciatedvalue.Text = Val(dt1.Rows(0).Item("DepreciationValue").ToString).ToString("n2")
                    txtEMarketValue.Text = Val(dt1.Rows(0).Item("MarketValue").ToString).ToString("n2")
                    If Not IsDBNull(dt1.Rows(0)("NoYears")) Then
                        txtNoYears.Text = Convert.ToInt32(dt1.Rows(0)("NoYears")).ToString()
                    Else
                        txtNoYears.Text = ""
                    End If


                    txtUsefulLife.Text = dt1.Rows(0).Item("UsefulLife").ToString
                    txtSalvageValue.Text = Val(dt1.Rows(0).Item("SalvageValue").ToString).ToString("n2")


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


                'ReadonlyTextBox(True)
            End If
        Next


    End Sub



    Protected Sub grdLedger1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles grdLedger1.RowCreated

        If grdLedger1.HeaderRow IsNot Nothing AndAlso grdLedger1.Rows.Count > 0 Then
            If grdLedger1.Controls.Count > 0 AndAlso grdLedger1.Controls(0).Controls.Count > 0 Then
                ' Prevent duplicate custom header rows
                Dim headerAlreadyExists As Boolean = False
                For Each row As GridViewRow In grdLedger1.Controls(0).Controls
                    If row.RowType = DataControlRowType.Header AndAlso row.Cells(0).Text = "OFFICE EQUIPMENT" Then
                        headerAlreadyExists = True
                        Exit For
                    End If
                Next

                If Not headerAlreadyExists Then

                    Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
                    Dim cell As New TableHeaderCell()
                    cell.Text = "OFFICE EQUIPMENT"
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

    Protected Sub ReadonlyTextBox(isReadonly As Boolean)

        txtequipmentdepreciatedvalue.ReadOnly = isReadonly
        txtEAcqCost.ReadOnly = isReadonly
        Dim textboxes As TextBox() = {txtName, txtequipmentdesciption, txtequipmentpowerinput, txtequipmentdimension, txtequipmentareacapacity, txtequipmentbrand, txtSpecification,
            txtequipmentmodel, txtequipmentwaranty, txtSpecification, txtSalvageValue, txtEMarketValue, txtNoYears, lblequipmentdepreciatedRate, txtEAcqDate}

        For Each textbox As TextBox In textboxes
            textbox.ReadOnly = isReadonly
        Next
    End Sub


    Public Sub EnableGridInputs()
        For Each row As GridViewRow In grdPropertyInfo.Rows
            If row.RowType = DataControlRowType.DataRow Then


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
                Dim ddlInstalled As DropDownList = TryCast(row.FindControl("drpInstalledAtOfEquip"), DropDownList)
                If ddlInstalled IsNot Nothing Then
                    ddlInstalled.Enabled = True
                End If
            End If
        Next
    End Sub

    Public Sub DisableGridInputs()
        For Each row As GridViewRow In grdPropertyInfo.Rows
            If row.RowType = DataControlRowType.DataRow Then

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
                Dim ddlInstalled As DropDownList = TryCast(row.FindControl("drpInstalledAtOfEquip"), DropDownList)
                If ddlInstalled IsNot Nothing Then
                    ddlInstalled.Enabled = False
                End If

            End If
        Next
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
