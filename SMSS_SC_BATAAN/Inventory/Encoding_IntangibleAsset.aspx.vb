Imports System.Data
Imports System.Drawing
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Threading ' <-- Added for Thread.Sleep

Partial Class Inventory_Encoding_IntangibleAsset
    Inherits System.Web.UI.Page

    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Private Prop_Ledger As New t_PropertyLedger
    Dim item As New m_item
    Dim Prop_Hdr As New t_property_hdr
    Dim Prop_Dtl As New t_property_dtl
    Dim objIntangibleDtl As New ConsolidatedPropertySaving.TBIntangibleAsset_Dtl
    Dim objIntangibleInfo As New ConsolidatedPropertySaving.TBIntangibleAsset_Info

    Private Sub Inventory_Encoding_IntangibleAsset_Load(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles Me.Load

        'objx.GetAccessRight(Me.Session("@UserName"), Page)
        'If objx.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If

        If Not Page.IsPostBack Then

            BindClassification_Intangible()

            If ddClass.SelectedValue IsNot Nothing AndAlso
           ddClass.SelectedValue <> "" Then

                Session("ClassificationID") =
                ddClass.SelectedValue

            Else

                Session("ClassificationID") = "0"

            End If

            ddClass.AutoPostBack = True
            ddGA.AutoPostBack = True
            drpSubClassification.AutoPostBack = True
            ddName.AutoPostBack = True

            Session("Item_ID") = 0

            LoadGLAccounts()

            drpSubClassification.Items.Clear()
            drpSubClassification.Items.Insert(
            0,
            New ListItem("No Subclass", "0")
        )
            drpSubClassification.Enabled = True

            ClearItemDesc()

            hdnGAId.Value = "0"
            hdnItemNo.Value = "0"

            loadwarehouse()
            loadEquipmentLedger()

            Session.Remove("TempPropertyList")

            BindPropertyInfoGrid(0)

            btnSave.Text = "SAVE"
            btnSave.Enabled = False

            AddTrace(
            "ClassificationID: " &
            Convert.ToString(Session("ClassificationID"))
        )

            AddTrace(
            "ddClass: " &
            Convert.ToString(ddClass.SelectedValue)
        )

        End If

    End Sub

    ' === ADD: Helpers to bind the dropdowns (Intangible Asset) ===

    Private Sub BindClassification_Intangible()

        Dim db As New BaseClasses.Items

        Dim sql As String =
        "SELECT " &
        "    ClassificationId, " &
        "    ClassificationName " &
        "FROM dbo.tbl_Classification " &
        "WHERE isenable = 1 " &
        "AND ClassificationName LIKE '%Intangible Assets%' " &
        "ORDER BY SeqNo"

        AddTrace(sql)

        Dim dt As DataTable = db.GetDataTable(
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

    End Sub


    Private Sub ClearItemDesc()

        ddName.Items.Clear()

        ddName.Items.Insert(
        0,
        New ListItem("Select", "0")
    )

        ddName.Enabled = True

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"

        If txtUnit.Items.Count > 0 Then
            txtUnit.SelectedIndex = 0
        End If

        btnSave.Enabled = False

    End Sub


    Private Sub LoadSubClassifications()

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
        Convert.ToString(ddGA.SelectedValue),
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

            drpSubClassification.DataSource =
            dtSubClass

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



    Public Sub loadEquipmentLedger()

        Dim itemID As Long = 0

        If ddName.SelectedValue IsNot Nothing AndAlso
       ddName.SelectedValue <> "" AndAlso
       ddName.SelectedValue <> "0" Then

            Long.TryParse(
            ddName.SelectedValue,
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

            Session("Item_ID") = itemID
            hdnItemNo.Value = itemID.ToString()

            AddTrace(
            "Executing SQL: EXEC AMS.PropertyLedger '" &
            itemID & "'"
        )

            dtAccount = objDerived.GetDataTable(
            "EXEC AMS.PropertyLedger '" &
            itemID & "'",
            CommandType.Text
        )

        Else

            Session("Item_ID") = 0
            hdnItemNo.Value = "0"

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

    Private Function ValidateIntangibleSelections() As Boolean

        If ddGA.SelectedValue Is Nothing OrElse
       ddGA.SelectedValue = "" OrElse
       ddGA.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Please select General Account."
        )

            Return False

        End If



        If ddName.SelectedValue Is Nothing OrElse
       ddName.SelectedValue = "" OrElse
       ddName.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Please select Name."
        )

            Return False

        End If

        Return True

    End Function




    Public Function createdatatableledger(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()

        ' Match the exact column names from your main query
        dt.Columns.Add("dDate", GetType(Date))
        dt.Columns.Add("Trans_Type", GetType(String))
        dt.Columns.Add("Ref", GetType(String))
        dt.Columns.Add("AccountablePerson", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("Position", GetType(String))
        dt.Columns.Add("AcceptedBy", GetType(String))
        dt.Columns.Add("InspectedBy", GetType(String))
        dt.Columns.Add("DebitQty", GetType(Integer))
        dt.Columns.Add("DebitUnit", GetType(String))
        dt.Columns.Add("DebitCost", GetType(Decimal))
        dt.Columns.Add("CreditQty", GetType(Integer))
        dt.Columns.Add("CreditUnit", GetType(String))
        dt.Columns.Add("CreditCost", GetType(Decimal))
        dt.Columns.Add("BalQty", GetType(Integer))        ' Changed from BalanceQty to BalQty
        dt.Columns.Add("BalanceUnit", GetType(String))
        dt.Columns.Add("BalCost", GetType(Decimal))      ' Changed from BalanceCost to BalCost
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("Ledger_ID", GetType(Long))

        For i As Integer = 0 To row
            dt.Rows.Add(dt.NewRow())
        Next

        Return dt
    End Function
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
    End Sub

    Public Sub loadSubClassification()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("Select SubClassificationID, SubclassificationName from dbo.tbl_SubClassification where ClassificationID = '13'", CommandType.Text)
        drpSubClassification.DataSource = dt
        drpSubClassification.DataTextField = "SubClassificationName"
        drpSubClassification.DataValueField = "SubClassificationID"
        drpSubClassification.Items.Clear()
        drpSubClassification.DataBind()
        drpSubClassification.Items.Insert(0, "No Subclass")

        drpSubClassification.SelectedIndex = 1
    End Sub


    Private Function GetNumericOrZero(input As String) As Decimal
        Dim val As Decimal
        Return If(Decimal.TryParse(input.Replace(",", "").Trim(), val), val, 0D)
    End Function

    Public Sub loadwarehouse()
        Dim dt As New DataTable
        Dim obj As New BaseClasses.Items
        dt = obj.GetDataTable("select warehouse_id,wname From ams.loc_warehouse", CommandType.Text)
        drpWarehouse.DataTextField = ("wname")
        drpWarehouse.DataValueField = ("warehouse_id")
        drpWarehouse.DataSource = dt
        drpWarehouse.DataBind()
    End Sub

    Public Sub Save()
        'If txtTitle.Text <> "" And txtBrand.Text <> "" And txtSerialNo.Text <> "" And txtNoOfDisc.Text <> "" And txtModel.Text <> "" And txtLicenceDuration.Text <> "" Then

        If Not Integer.TryParse(txtNoOfDisc.Text, Nothing) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter valid value for No of Disc")
            Exit Sub
        End If


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


        If ddName.SelectedValue = "" Or ddName.SelectedValue = "0" Then
            missingFields.Add("Name")
        End If





        'If String.IsNullOrWhiteSpace(txtbookQuantity.Text) Then
        '    missingFields.Add("Quantity")
        'End If

        'If String.IsNullOrWhiteSpace(txtRemarks.Text) Then
        '    missingFields.Add("Remarks")
        'End If
        If String.IsNullOrWhiteSpace(txtAcquisitionDate.Text) Then
            missingFields.Add("Acquisition Date")
        End If
        If String.IsNullOrWhiteSpace(txtAcquisitionCost.Text) Or txtAcquisitionCost.Text = "0.00" Or txtAcquisitionCost.Text = "0" Then
            missingFields.Add("Acquisition Cost")
        End If

        If missingFields.Count > 0 Then
            Dim message As String = "Please fill up the required field(s):" &
                            "\n - " & String.Join("\n - ", missingFields)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, message)
            Exit Sub
        Else

            ' -- Item Creation
            Dim classId As Integer = 0
            Dim subClassId As Integer = 0
            Integer.TryParse(ddClass.SelectedValue, classId)
            Integer.TryParse(drpSubClassification.SelectedValue, subClassId)

            'With item
            '    .Item_Code = ""
            '    .Item_Desc = txtTitle.Text
            '    .ClassificationID = classId              ' <-- from ddClass
            '    .SubClassificationId = subClassId        ' <-- from drpSubClassification
            'End With

            'Dim itemid As Integer = CInt(item.save())

            Dim itemid As Integer = 0
            Integer.TryParse(ddName.SelectedValue, itemid)


            ' -- Property Header
            With Prop_Hdr
                '.Property_ID = Property_ID
                .Property_Date = txtAcquisitionDate.Text
                .Issuance = 0
                .Remarks = "Manual Encoding of Old Properties"
                .Emp_ID = 0
                .F_ID = 1
                .AIRDtl_ID = 0
                .deptid = 0
                .isDonated = False

                .GA_ID = ddGA.SelectedValue

                .DonationRemarks = ""
                .Qty = 1
                .Balance = 1
                .Cost = CType(txtAcquisitionCost.Text, Decimal)
                .Item_ID = itemid

                Dim propCodeQuery As String = "select ga_code  From dbo.tbl_Classification as a " &
                              "inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid " &
                              "inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID " &
                              "where a.ClassificationId = " & ddClass.SelectedValue & " "

                .Property_code = objDerived.GetValue(propCodeQuery, CommandType.Text)

                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .Function_ID = 86
                .TD_ID = 1
                .Project_ID = 0
                .Program_id = 0

                Dim partQuery As String = "SELECT AMS.item_particular.description " &
                                      "FROM dbo.m_item INNER JOIN AMS.item_particular ON " &
                                      "dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id " &
                                      "where Item_ID = '" & itemid & "' "

                .Particular = objDerived.GetValue(partQuery, CommandType.Text)
            End With

            Dim PropHdr_ID As Integer = Prop_Hdr.save()

            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Property SET ClassificationID = '" & ddClass.SelectedValue & "',SubClassificationID = '" & drpSubClassification.SelectedValue & "'  WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)





            ' ===== Save one Property_Dtl per popup row =====
            If grdPropertyInfo.Rows.Count = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please add at least one Property Information row.")
                Exit Sub
            End If

            ' Optional: ensure the number of rows matches the declared No. of Disc
            Dim expected As Integer
            If Integer.TryParse(txtNoOfDisc.Text, expected) Then
                If grdPropertyInfo.Rows.Count <> expected Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The number of rows in Property Information must match No. of Disc.")
                    Exit Sub
                End If
            End If

            ' Validate per-row PropertyNo uniqueness (in-UI and DB)
            Dim seen As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
            For Each r As GridViewRow In grdPropertyInfo.Rows
                Dim tbPropertyNo As TextBox = TryCast(r.FindControl("txtPropertyNo"), TextBox)
                If tbPropertyNo Is Nothing OrElse String.IsNullOrWhiteSpace(tbPropertyNo.Text) Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is required on each row.")
                    Exit Sub
                End If
                If Not seen.Add(tbPropertyNo.Text.Trim()) Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Duplicate Property No. inside the popup: " & tbPropertyNo.Text)
                    Exit Sub
                End If
                ' DB dup check per row
                Dim dup As Integer = objDerived.GetValue(
                "SELECT COUNT(1) FROM AMS.Property_Dtl WHERE PropertyNo = '" &
                tbPropertyNo.Text.Replace("'", "''") & "'", CommandType.Text)
                If dup > 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. already exists: " & tbPropertyNo.Text)
                    Exit Sub
                End If
            Next

            ' Save all details; keep the first ID to link to Info/Dtl later
            Dim propDtlIds As New List(Of Integer)()

            For Each r As GridViewRow In grdPropertyInfo.Rows
                Dim tbPropertyNo As TextBox = TryCast(r.FindControl("txtPropertyNo"), TextBox)
                Dim tbSerial As TextBox = TryCast(r.FindControl("txtSerialNoIntangAsset"), TextBox)
                Dim ddlInstalled As DropDownList = TryCast(r.FindControl("drpInstalledIntangAsset"), DropDownList)
                Dim tbLocation As TextBox = TryCast(r.FindControl("txtPIFloorLocation"), TextBox)

                If tbPropertyNo Is Nothing OrElse tbSerial Is Nothing OrElse ddlInstalled Is Nothing OrElse tbLocation Is Nothing Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unable to read Property Information controls. Please reopen the popup and try again.")
                    Exit Sub
                End If

                With Prop_Dtl
                    .PropertyNo = tbPropertyNo.Text
                    .Property_ID = PropHdr_ID
                    .Issued = False
                    .Repair = False
                    .Dispose = False
                    .DisposeDate = "1/1/1900"
                    .IsInspectionForDisposal = False
                    .InspectionDate = txtAcquisitionDate.Text
                    .F_ID = 1
                    .SerialNo = tbSerial.Text
                    .Barcode = " "
                    .Amount = CType(txtAcquisitionCost.Text, Decimal)
                    .Status = "Accepted"
                    .type = "Software"
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .Function_ID = 86
                    .AccountablePerson = ""

                    .MarketValue = CDec(If(String.IsNullOrWhiteSpace(txtMarketValue.Text), "0", txtMarketValue.Text.Replace(",", "")))
                    .InstalledAt = If(ddlInstalled.SelectedItem IsNot Nothing, ddlInstalled.SelectedItem.Text, String.Empty)
                    .Location = tbLocation.Text
                End With

                Dim newId As Integer = Prop_Dtl.save()
                propDtlIds.Add(newId)



                ' -- Intangible Info
                With objIntangibleInfo
                    .AIRDtl_ID = 0
                    .IsAccepted = True
                    .Property_Dtl_ID = newId
                    .Received_ID = 0
                    .Received_Dtl_ID = 0
                    .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    .Brand = txtBrand.Text
                    .Title = txtTitle.Text
                    .SerialNo = ""
                    .Noofdisc = txtNoOfDisc.Text
                    .Model = txtModel.Text
                    .LicenceDuration = txtLicenceDuration.Text
                    .DepreciationRate = txtDepreciatedRate.Text
                    .NoofYears = txtNoofYears.Text
                    .Usefullife = txtUsefullife.Text
                    .SubClassificationID = drpSubClassification.SelectedValue
                    .Property_ID = PropHdr_ID
                    .Unit_ID = txtUnit.SelectedValue
                    .Remarks = txtRemarks.Text
                    .Description = txtDescription.Text

                End With

                Dim Intan_info_id As Integer = objIntangibleInfo.save()
                objDerived.GetRecords(
                    "UPDATE AMS.TBIntangibleAsset_Info SET " &
                    "Received_ID = 0, " &
                    "Unit_ID = " & txtUnit.SelectedValue & ", " &
                    "Specification = CAST('" & txtSpecification.Text.Replace("'", "''") & "' AS VARCHAR(MAX)), " &
                    "Received_Dtl_ID = 0, " &
                    "DiscNo = '" & txtNoOfDisc.Text.Replace("'", "''") & "', " &
                    "DepreciationValue = '" & txtDepreciationValue.Text.Replace(",", "") & "', " &
                    "Item_ID = " & ddName.SelectedValue & ", " &
                    "Property_ID = " & PropHdr_ID & " " &
                    "WHERE IntangibleAssetInfoId = " & Intan_info_id,
                    CommandType.Text
                )

                'objDerived.GetRecords("UPDATE AMS.TBIntangibleAsset_Info SET Received_ID = 0, Received_Dtl_ID = 0, DiscNo = '" & txtNoOfDisc.Text & "' WHERE IntangibleAssetInfoId = '" & Intan_info_id & "'", CommandType.Text)

                ' -- Intangible Detail
                With objIntangibleDtl
                    .IntangibleAssetInfoId = Intan_info_id
                    .Property_Dtl_ID = newId
                    .AcqCost = txtAcquisitionCost.Text.Replace(",", "")
                    .DepreciatedValue = txtDepreciatedValue.Text.Replace(",", "")
                    .MarketValue = If(String.IsNullOrWhiteSpace(txtMarketValue.Text), "0", txtMarketValue.Text.Replace(",", ""))

                    .SalvageValue = txtSalvageValue.Text.Replace(",", "")
                    .WarehouseID = drpWarehouse.SelectedValue
                    .Bay = txtBay.Text
                    .Column = txtColumn.Text
                    .Floor = txtFloor.Text
                    .Room = txtRoom.Text
                    .Shelves = txtShelves.Text
                    .Rack = txtRack.Text
                    .Bin = txtBin.Text
                    .Status = "Accepted"
                End With

                Dim Intan_dtl_id As Integer = objIntangibleDtl.save()

            Next

            If propDtlIds.Count = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No Property Detail rows were saved.")
                Exit Sub
            End If

            Dim firstPropDtlId As Integer = propDtlIds(0)







            ' -- Ledger
            With Prop_Ledger
                .Ledger_ID = 0
                .PropertyNo = ""
                .SerialNo = ""
                .Trans_Type = "Manual Entry"
                .dDate = txtAcquisitionDate.Text
                .Ref = ""
                .AccountablePerson = ""
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = itemid
                .DebitQty = txtNoOfDisc.Text
                .DebitCost = CType(txtAcquisitionCost.Text, Decimal) * txtNoOfDisc.Text
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & itemid & "'", CommandType.Text)
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & itemid & "'", CommandType.Text)

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
                Convert.ToInt32(txtNoOfDisc.Text)

                Dim EquipmentAcquisitionCost As Decimal =
                CType(txtAcquisitionCost.Text.Replace(",", ""), Decimal)

                Dim NewEquipmentCost As Decimal =
                EquipmentAcquisitionCost * NewEquipmentQty

                .BalanceQty = Eqty + NewEquipmentQty
                .BalanceCost = Eqbalance + NewEquipmentCost

                .Property_ID = PropHdr_ID
            End With

            Prop_Ledger.save()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            loadEquipmentLedger()

            hdnItemNo.Value = itemid
        End If


        'Else
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill Up the Required Fields : \n Title, Brand, Serial No., No. of Disc, Model, License Duration ")
        'End If
    End Sub

    Public Sub UPDATE()



        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        With objDerived.cmd.Parameters

            .AddWithValue("@Ledger_ID", hf_Ledger_ID.Value)
            .AddWithValue("@Property_Dtl_ID", hf_PropertyDetai_ID.Value)
            .AddWithValue("@Property_ID", hf_Property_ID.Value)
            .AddWithValue("@WarehouseID", drpWarehouse.SelectedValue)

            ' Main Property Info
            .AddWithValue("@Title", txtTitle.Text)
            .AddWithValue("@NoofDisc", txtNoOfDisc.Text)
            .AddWithValue("@Brand", txtBrand.Text)
            .AddWithValue("@Specification", txtSpecification.Text)
            .AddWithValue("@Model", txtModel.Text)
            '.AddWithValue("@SerialNo", txtSerialNo.Text)
            .AddWithValue("@LicenseDuration", txtLicenceDuration.Text)

            ' Financial Info
            .AddWithValue("@AcquisitionDate", txtAcquisitionDate.Text)

            .AddWithValue("@MarketValue", GetNumericOrZero(txtMarketValue.Text))
            .AddWithValue("@Cost", GetNumericOrZero(txtAcquisitionCost.Text))
            .AddWithValue("@NoofYears", txtNoofYears.Text)
            .AddWithValue("@DepreciatedRate", txtDepreciatedRate.Text)
            .AddWithValue("@UsefulLife", txtUsefullife.Text)

            .AddWithValue("@DepreciatedValue", GetNumericOrZero(txtDepreciatedValue.Text))
            .AddWithValue("@SalvageValue", GetNumericOrZero(txtSalvageValue.Text))

            ' Location Info
            .AddWithValue("@Bay", txtBay.Text)
            .AddWithValue("@Column", txtColumn.Text)
            .AddWithValue("@Floor", txtFloor.Text)
            .AddWithValue("@Room", txtRoom.Text)
            .AddWithValue("@Shelves", txtShelves.Text)
            .AddWithValue("@Rack", txtRack.Text)
            .AddWithValue("@Bin", txtBin.Text)
            .AddWithValue("@Remarks", txtRemarks.Text)
            .AddWithValue("@Description", txtDescription.Text)
            .AddWithValue("@Unit_ID", txtUnit.SelectedValue)
            .AddWithValue("@DiscNo", txtNoOfDisc.Text)
        End With

        ' Call stored procedure
        objDerived.Execute("AMS.sp_Edit_IntangibleAssets", CommandType.StoredProcedure)

        ' ---- NEW: per-row details from the modal ----
        For Each row As GridViewRow In grdPropertyInfo.Rows
            If row.RowType <> DataControlRowType.DataRow Then Continue For

            Dim propDtlId As Long = 0
            If grdPropertyInfo.DataKeys IsNot Nothing AndAlso grdPropertyInfo.DataKeys.Count > row.RowIndex Then
                Dim keyObj = grdPropertyInfo.DataKeys(row.RowIndex).Value
                If keyObj IsNot Nothing Then
                    Long.TryParse(keyObj.ToString(), propDtlId)
                End If
            End If

            ' If 0, it’s a brand-new property detail row (inserted on Save(), which you already handle).
            ' For UPDATE, we only issue updates when an ID exists.
            If propDtlId > 0 Then
                Dim tbPropNo As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)
                Dim tbSerial As TextBox = TryCast(row.FindControl("txtSerialNoIntangAsset"), TextBox)
                Dim ddlInstalled As DropDownList = TryCast(row.FindControl("drpInstalledIntangAsset"), DropDownList)
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

                ' Execute per-row update
                objDerived.cmd.Parameters.Clear()
                objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", propDtlId)
                objDerived.cmd.Parameters.AddWithValue("@PropertyNo", propNo)
                objDerived.cmd.Parameters.AddWithValue("@SerialNo", serial)
                objDerived.cmd.Parameters.AddWithValue("@InstalledAt", installedAt)
                objDerived.cmd.Parameters.AddWithValue("@Location", loc)

                objDerived.Execute("AMS.sp_Update_PropertyDtl_Row", CommandType.StoredProcedure)
            End If
        Next

        ' ' Get Item_ID
        Dim ItemID As Long = CLng(objDerived.GetValue("SELECT Item_ID FROM AMS.TbProperty_Ledger WHERE Ledger_ID = '" & hf_Ledger_ID.Value & "'", CommandType.Text))

        ' Get the unit for DebitUnit and BalanceUnit
        Dim Unit As String = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & ItemID & "'", CommandType.Text)

        ' Calculate the values for the ledger update
        Dim quantity As String = txtNoOfDisc.Text
        Dim debitCost As Decimal = GetNumericOrZero(txtAcquisitionCost.Text) * Convert.ToInt32(quantity)

        ' Update the TbProperty_Ledger
        objDerived.GetRecords("UPDATE [AMS].[TbProperty_Ledger] " &
                          "SET DebitQty = '" & quantity & "', " &
                          "DebitCost = '" & debitCost.ToString("F2") & "', " &
                          "DebitUnit = '" & Unit & "', " &
                          "BalanceQty = '" & quantity & "', " &
                          "BalanceCost = '" & debitCost.ToString("F2") & "', " &
                          "BalanceUnit = '" & Unit & "', " &
                          "dDate = '" & txtAcquisitionDate.Text & "' " &
                          "WHERE Ledger_ID = '" & hf_Ledger_ID.Value & "'", CommandType.Text)

        ' REBALANCE FROM EDITED ROW ABOVE
        'objDerived.Execute("EXEC [AMS].[ReBalanceLedger] " & ItemID, CommandType.Text)

    End Sub

    Protected Sub grdLedger1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        ' 1) Set the new page index
        grdLedger1.PageIndex = e.NewPageIndex

        ' 2) Re-bind the grid data
        loadEquipmentLedger()
    End Sub

    Public Sub loadUnit()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT Unit_ID, Description FROM ams.m_Unit AS a ORDER BY CASE WHEN Description = '-' THEN 0 ELSE 1 END, Description;", CommandType.Text)
        txtUnit.DataSource = dt
        txtUnit.DataTextField = ("Description")
        txtUnit.DataValueField = ("Unit_ID")
        txtUnit.DataBind()

        Dim Unit_ID As Integer = objDerived.GetValue("SELECT Unit_ID FROM DBO.m_item WHERE Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        txtUnit.SelectedValue = Unit_ID

    End Sub


    Protected Sub btnSave_Click(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles btnSave.Click

        If btnSave.Text = "SAVE" Then

            If Not ValidateIntangibleSelections() Then
                Exit Sub
            End If

            hdnGAId.Value = ddGA.SelectedValue
            hdnItemNo.Value = ddName.SelectedValue
            Session("Item_ID") = ddName.SelectedValue

            Save()

            loadEquipmentLedger()

        ElseIf btnSave.Text = "EDIT" Then

            LoadApprovingOfficers()
            ModalPopupExtender_Approval.Show()

        Else

            If Not ValidateIntangibleSelections() Then
                Exit Sub
            End If

            If Not Integer.TryParse(
            txtNoOfDisc.Text,
            Nothing
        ) Then

                MsgeBox.CreateMessageAlertInUpdatePanel(
                Me.UpdatePanel1,
                "Please enter valid value for No of Disc"
            )

                Exit Sub

            End If

            hdnGAId.Value = ddGA.SelectedValue
            hdnItemNo.Value = ddName.SelectedValue
            Session("Item_ID") = ddName.SelectedValue

            UPDATE()

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

            ClearTextBoxes()
            IsEnabledTextBox(True)

            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Property Information is Updated Successfully."
        )

            btnSave.Text = "SAVE"

            loadEquipmentLedger()

        End If
        btnSave.Enabled = False

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
        btnSave.Text = "SAVE"
        txtNoOfDisc.Enabled = True
        btnSave.Enabled = True

        IsEnabledTextBox(False)
        ClearTextBoxes()

        ViewState("CheckboxEvent") = True

        Dim cbCurrent As CheckBox = TryCast(sender, CheckBox)
        If cbCurrent Is Nothing Then
            Exit Sub
        End If

        Dim row As GridViewRow = TryCast(cbCurrent.NamingContainer, GridViewRow)
        If row Is Nothing Then
            Exit Sub
        End If

        If Not cbCurrent.Checked Then
            Exit Sub
        End If

        ' Uncheck other rows
        For i As Integer = 0 To grdLedger1.Rows.Count - 1
            Dim cb1 As CheckBox = TryCast(grdLedger1.Rows(i).FindControl("cbInspection"), CheckBox)
            If cb1 IsNot Nothing AndAlso i <> row.RowIndex Then
                cb1.Checked = False
            End If
        Next

        Dim Item_ID As String = "0"

        If grdLedger1.DataKeys IsNot Nothing AndAlso grdLedger1.DataKeys.Count > row.RowIndex Then
            If grdLedger1.DataKeys(row.RowIndex).Values("Item_ID") IsNot Nothing Then
                Item_ID = grdLedger1.DataKeys(row.RowIndex).Values("Item_ID").ToString()
            End If
        End If

        If Item_ID = "" Or Item_ID = "0" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unable to get Item ID from selected row.")
            Exit Sub
        End If

        AddTrace("Executing SQL: EXEC [AMS].[sp_View_Encoding] 'Intangible','" & Item_ID & "'")

        Dim dt1 As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_View_Encoding] 'Intangible','" & Item_ID & "'", CommandType.Text)

        If dt1 Is Nothing OrElse dt1.Rows.Count = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No record found for selected item.")
            Exit Sub
        End If

        btnSave.Text = "EDIT"
        txtNoOfDisc.Enabled = False
        IsEnabledTextBox(False)

        txtTitle.Text = dt1.Rows(0).Item("Title").ToString
        txtNoOfDisc.Text = dt1.Rows(0).Item("Noofdisc").ToString
        txtBrand.Text = dt1.Rows(0).Item("Brand").ToString
        txtSpecification.Text = dt1.Rows(0).Item("Specification").ToString
        txtModel.Text = dt1.Rows(0).Item("Model").ToString
        txtLicenceDuration.Text = dt1.Rows(0).Item("LicenceDuration").ToString

        txtAcquisitionDate.Text = dt1.Rows(0).Item("dDate").ToString
        txtMarketValue.Text = dt1.Rows(0).Item("MarketValue").ToString
        txtAcquisitionCost.Text = dt1.Rows(0).Item("DebitCost").ToString

        txtNoofYears.Text = dt1.Rows(0).Item("NoofYears").ToString
        txtDepreciatedRate.Text = dt1.Rows(0).Item("DepreciationRate").ToString
        txtUsefullife.Text = dt1.Rows(0).Item("Usefullife").ToString
        txtDepreciatedValue.Text = dt1.Rows(0).Item("DepreciatedValue").ToString
        txtSalvageValue.Text = dt1.Rows(0).Item("SalvageValue").ToString
        txtDepreciationValue.Text = dt1.Rows(0).Item("DepreciationValue").ToString

        drpWarehouse.SelectedValue = dt1.Rows(0).Item("WarehouseID").ToString
        txtBay.Text = dt1.Rows(0).Item("Bay").ToString
        txtColumn.Text = dt1.Rows(0).Item("Column").ToString
        txtFloor.Text = dt1.Rows(0).Item("Floor").ToString
        txtRoom.Text = dt1.Rows(0).Item("Room").ToString
        txtShelves.Text = dt1.Rows(0).Item("Shelves").ToString
        txtRack.Text = dt1.Rows(0).Item("Rack").ToString
        txtBin.Text = dt1.Rows(0).Item("Bin").ToString

        Dim unitId As String = dt1.Rows(0).Item("Unit_ID").ToString
        If String.IsNullOrEmpty(unitId) OrElse unitId = "0" OrElse txtUnit.Items.FindByValue(unitId) Is Nothing Then
            txtUnit.SelectedIndex = 0
        Else
            txtUnit.SelectedValue = unitId
        End If

        If ddName.Items.FindByValue(Item_ID) IsNot Nothing Then
            ddName.SelectedValue = Item_ID
        End If

        txtDescription.Text = dt1.Rows(0).Item("Description").ToString
        txtRemarks.Text = dt1.Rows(0).Item("Remarks").ToString

        hf_PropertyDetai_ID.Value = dt1.Rows(0).Item("PropertyDetai_ID").ToString
        hf_Property_ID.Value = dt1.Rows(0).Item("Property_ID").ToString
        hf_Ledger_ID.Value = dt1.Rows(0).Item("Ledger_ID").ToString
        hdnItemNo.Value = Item_ID

        AddTrace("Ledger_ID: " & hf_Ledger_ID.Value)

        ViewState("IsEditMode") = True

        Dim ledId As Long
        If Long.TryParse(hf_Ledger_ID.Value, ledId) Then
            PopulatePropertyInfoFromLedger(ledId)
        End If

        btnSave.Enabled = True
    End Sub

    Protected Sub IsEnabledTextBox(IsEnabled As Boolean)

        Dim textBoxes() As TextBox = {txtTitle, txtBrand, txtModel, txtLicenceDuration, txtSpecification,
                txtAcquisitionDate, txtMarketValue, txtAcquisitionCost, txtNoofYears, txtDepreciatedRate,
                txtDepreciatedValue, txtSalvageValue, txtDepreciationValue, txtBay, txtColumn, txtFloor,
                txtRoom, txtShelves, txtRack, txtBin, txtDescription, txtRemarks
        }



        For Each txtBox In textBoxes
            txtBox.Enabled = IsEnabled
        Next


    End Sub

    Protected Sub ClearTextBoxes()

        Dim textBoxes() As TextBox = {txtTitle, txtNoOfDisc, txtBrand, txtModel, txtLicenceDuration, txtSpecification,
                txtAcquisitionDate, txtMarketValue, txtAcquisitionCost, txtNoofYears, txtDepreciatedRate, txtUsefullife,
                txtDepreciatedValue, txtSalvageValue, txtDepreciationValue, txtBay, txtColumn, txtFloor,
                txtRoom, txtShelves, txtRack, txtBin, txtDescription, txtRemarks
        }

        For Each txtBox In textBoxes
            txtBox.Text = String.Empty
        Next

    End Sub

    Protected Sub grdLedger1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles grdLedger1.RowCreated

        If grdLedger1.HeaderRow IsNot Nothing AndAlso grdLedger1.Rows.Count > 0 Then
            If grdLedger1.Controls.Count > 0 AndAlso grdLedger1.Controls(0).Controls.Count > 0 Then
                ' Prevent duplicate custom header rows
                Dim headerAlreadyExists As Boolean = False
                For Each row As GridViewRow In grdLedger1.Controls(0).Controls
                    If row.RowType = DataControlRowType.Header AndAlso row.Cells(0).Text = "Intangible Asset" Then
                        headerAlreadyExists = True
                        Exit For
                    End If
                Next

                If Not headerAlreadyExists Then

                    Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
                    Dim cell As New TableHeaderCell()
                    cell.Text = "Intangible Asset"
                    cell.ColumnSpan = 4
                    cell.BorderWidth = 2
                    cell.BorderColor = ColorTranslator.FromHtml("#12306b")
                    row.Controls.Add(cell)

                    cell = New TableHeaderCell()
                    cell.ColumnSpan = 1
                    cell.Text = "DEBIT"
                    cell.BorderWidth = 2
                    cell.BorderColor = ColorTranslator.FromHtml("#12306b")
                    row.Controls.Add(cell)

                    cell = New TableHeaderCell()
                    cell.ColumnSpan = 1
                    cell.Text = "CREDIT"
                    cell.BorderWidth = 2
                    cell.BorderColor = ColorTranslator.FromHtml("#12306b")
                    row.Controls.Add(cell)

                    cell = New TableHeaderCell()
                    cell.ColumnSpan = 1
                    cell.Text = "BALANCE"
                    cell.BorderWidth = 2
                    cell.BorderColor = ColorTranslator.FromHtml("#12306b")
                    row.Controls.Add(cell)

                    row.BackColor = ColorTranslator.FromHtml("WHITE")
                    row.ForeColor = ColorTranslator.FromHtml("#12306b")

                    grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)
                End If
            End If
        End If
    End Sub

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

        LoadGLAccounts()

        drpSubClassification.Items.Clear()
        drpSubClassification.Items.Insert(
        0,
        New ListItem("No Subclass", "0")
    )
        drpSubClassification.Enabled = True

        ClearItemDesc()

        hdnGAId.Value = "0"

        ViewState("PropertyInfoDT") = Nothing
        BindPropertyInfoGrid(0)

        loadEquipmentLedger()

        AddTrace(
        "ddClass: " &
        Convert.ToString(ddClass.SelectedValue)
    )

    End Sub
    Protected Sub drpSubClassification_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles drpSubClassification.SelectedIndexChanged

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"

        LoadItemDesc()

        ViewState("PropertyInfoDT") = Nothing
        BindPropertyInfoGrid(0)

        loadEquipmentLedger()

        AddTrace(
        "drpSubClassification: " &
        Convert.ToString(
            drpSubClassification.SelectedValue
        )
    )

    End Sub


    Protected Sub ddGA_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
) Handles ddGA.SelectedIndexChanged

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

        ViewState("PropertyInfoDT") = Nothing
        BindPropertyInfoGrid(0)
        LoadItemDesc()
        loadEquipmentLedger()

        AddTrace(
        "ddGA: " &
        Convert.ToString(ddGA.SelectedValue)
    )

    End Sub

    Protected Sub ddName_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
)

        If ddName.SelectedValue Is Nothing OrElse
       ddName.SelectedValue = "" OrElse
       ddName.SelectedValue = "0" Then

            Session("Item_ID") = 0
            hdnItemNo.Value = "0"

            If txtUnit.Items.Count > 0 Then
                txtUnit.SelectedIndex = 0
            End If

            btnSave.Enabled = False

            ViewState("PropertyInfoDT") = Nothing
            BindPropertyInfoGrid(0)

            loadEquipmentLedger()
            Exit Sub

        End If

        Session("Item_ID") =
        ddName.SelectedValue

        hdnItemNo.Value =
        ddName.SelectedValue

        hdnGAId.Value =
        ddGA.SelectedValue

        ViewState("PropertyInfoDT") = Nothing
        BindPropertyInfoGrid(0)

        loadUnit()
        loadEquipmentLedger()
        loadUsefulLife()

        btnSave.Enabled = True

        AddTrace(
        "Item_ID: " &
        ddName.SelectedValue
    )

    End Sub

    Protected Sub grdLedger1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdLedger1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim cbInspection As CheckBox = TryCast(e.Row.FindControl("cbInspection"), CheckBox)
            Dim TransType As String = ""

            If e.Row.DataItem IsNot Nothing Then
                TransType = DataBinder.Eval(e.Row.DataItem, "Trans_Type").ToString().Trim()
            End If

            If cbInspection IsNot Nothing Then
                If TransType = "Starting Inventory" Or TransType = "Manual Entry" Then
                    cbInspection.Enabled = True
                Else
                    cbInspection.Checked = False
                    cbInspection.Enabled = False
                End If
            End If

        End If

    End Sub




    Private Sub BindPropertyInfoGrid(rowCount As Integer)
        Dim dt As New DataTable()
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("InstalledAt", GetType(String))
        dt.Columns.Add("FloorLocation", GetType(String))
        dt.Columns.Add("BuildingId", GetType(Integer))  ' ADD THIS LINE

        For i As Integer = 1 To rowCount
            dt.Rows.Add(0, "", "", "", "", 0)  ' Added 0 for BuildingId
        Next

        ViewState("PropertyInfoDT") = dt
        grdPropertyInfo.DataSource = dt
        grdPropertyInfo.DataBind()
    End Sub
    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drp As DropDownList = TryCast(e.Row.FindControl("drpInstalledIntangAsset"), DropDownList)
            If drp IsNot Nothing Then
                ' Get data source with BuildingId as value and Name as display
                Dim src As DataTable = GetInstalledAtSource()

                drp.DataSource = src
                drp.DataTextField = "Name"
                drp.DataValueField = "BuildingId"  ' Use BuildingId as value
                drp.DataBind()

                ' Try to select the appropriate item
                Dim installedAtText As String = ""
                Dim buildingId As String = ""

                ' Safely get InstalledAt text
                Try
                    installedAtText = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "InstalledAt"))
                Catch ex As Exception
                    installedAtText = ""
                End Try

                ' Safely get BuildingId (check if column exists in the data source)
                Try
                    ' Check if the DataItem has a BuildingId property/column
                    Dim dataItem As Object = e.Row.DataItem
                    If dataItem IsNot Nothing Then
                        ' Try to get BuildingId from the DataRowView
                        Dim drv As DataRowView = TryCast(dataItem, DataRowView)
                        If drv IsNot Nothing AndAlso drv.DataView.Table.Columns.Contains("BuildingId") Then
                            buildingId = Convert.ToString(drv("BuildingId"))
                        End If
                    End If
                Catch ex As Exception
                    buildingId = ""
                End Try

                drp.ClearSelection()

                If Not String.IsNullOrEmpty(installedAtText) Then
                    ' First try to select by text (for "Field" and "N/A")
                    Dim liByText As ListItem = drp.Items.FindByText(installedAtText)
                    If liByText IsNot Nothing Then
                        liByText.Selected = True
                    ElseIf Not String.IsNullOrEmpty(buildingId) Then
                        ' Then try by BuildingId value
                        Dim liByVal As ListItem = drp.Items.FindByValue(buildingId)
                        If liByVal IsNot Nothing Then
                            liByVal.Selected = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Function GetInstalledAtSource() As DataTable
        ' This matches the Equipment page pattern
        Dim query As String =
        "SELECT a.BuildingId, a.BuildingName + ' - ' + ISNULL(a.Address, '') AS Name " &
        "FROM ams.TbBuilding_Dtl AS a " &
        "INNER JOIN ams.Property_Dtl AS b ON a.Property_Dtl_ID = b.PropertyDetai_ID " &
        "ORDER BY a.BuildingName"

        Dim dt As DataTable = objDerived.GetDataTable(query, CommandType.Text)

        ' Add the special non-database options
        dt.Rows.InsertAt(dt.NewRow(), 0)
        dt.Rows(0)("Name") = "Field"
        dt.Rows(0)("BuildingId") = 0

        dt.Rows.InsertAt(dt.NewRow(), 1)
        dt.Rows(1)("Name") = "N/A"
        dt.Rows(1)("BuildingId") = -1

        Return dt
    End Function

    Protected Sub lnkAddPropertyNumber_Click(sender As Object, e As EventArgs) Handles lnkAddPropertyNumber.Click
        ' If we are editing an existing ledger item, reuse the populated data.
        If ViewState("IsEditMode") IsNot Nothing AndAlso CBool(ViewState("IsEditMode")) Then
            Dim dtBind As DataTable = TryCast(ViewState("PropertyInfoDT"), DataTable)
            If dtBind IsNot Nothing Then
                grdPropertyInfo.DataSource = dtBind
                grdPropertyInfo.DataBind()
            Else
                ' Safety net: if cache is empty, repopulate from DB using Ledger_ID
                Dim ledId As Long
                If Long.TryParse(hf_Ledger_ID.Value, ledId) Then
                    PopulatePropertyInfoFromLedger(ledId)
                End If
            End If

            ' Disable or enable the PropertyNo textbox based on Save button text
            If btnSave.Text.Equals("EDIT", StringComparison.OrdinalIgnoreCase) OrElse
            btnSave.Text.Equals("UPDATE", StringComparison.OrdinalIgnoreCase) Then

                For Each row As GridViewRow In grdPropertyInfo.Rows
                    Dim tb As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)
                    If tb IsNot Nothing Then
                        tb.Enabled = False
                    End If
                Next
            Else
                For Each row As GridViewRow In grdPropertyInfo.Rows
                    Dim tb As TextBox = TryCast(row.FindControl("txtPropertyNo"), TextBox)
                    If tb IsNot Nothing Then
                        tb.Enabled = True
                    End If
                Next
            End If

            ModalPopup_PropertyInfo.Show()
            Return
        End If

        ' New entry (not edit mode): build empty rows based on No. of Disc
        Dim n As Integer
        If Not Integer.TryParse(txtNoOfDisc.Text, n) OrElse n <= 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a valid Quantity for No of Disc")
            Exit Sub
        End If

        BindPropertyInfoGrid(n)

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
                            Dim txtSerialNumber As TextBox = CType(row1.FindControl("txtSerialNoIntangAsset"), TextBox)
                            Dim txtPIFloorLocation As TextBox = CType(row1.FindControl("txtPIFloorLocation"), TextBox)
                            Dim drpInstalledIntangAsset As DropDownList = CType(row1.FindControl("drpInstalledIntangAsset"), DropDownList)

                            ' Clear other fields (check if controls exist)
                            If txtSerialNumber IsNot Nothing Then txtSerialNumber.Text = String.Empty
                            If txtPIFloorLocation IsNot Nothing Then txtPIFloorLocation.Text = String.Empty
                            If drpInstalledIntangAsset IsNot Nothing Then
                                drpInstalledIntangAsset.ClearSelection()
                                ' Set default to N/A if available
                                Dim naItem As ListItem = drpInstalledIntangAsset.Items.FindByText("N/A")
                                If naItem IsNot Nothing Then
                                    drpInstalledIntangAsset.SelectedValue = naItem.Value
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

        ModalPopup_PropertyInfo.Show()
    End Sub

    Private Sub PopulatePropertyInfoFromLedger(ledgerId As Long)
        ' Update the stored procedure or query to return both InstalledAt and BuildingId
        Dim dt As DataTable = objDerived.GetDataTable("EXEC AMS.sp_GetPropertyDtl_ByLedger " & ledgerId, CommandType.Text)

        Dim dtBind As New DataTable()
        dtBind.Columns.Add("PropertyDetai_ID", GetType(Long))
        dtBind.Columns.Add("PropertyNo", GetType(String))
        dtBind.Columns.Add("SerialNo", GetType(String))
        dtBind.Columns.Add("FloorLocation", GetType(String))
        dtBind.Columns.Add("InstalledAt", GetType(String))
        dtBind.Columns.Add("BuildingId", GetType(Integer))  ' NEW COLUMN

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
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

        ' If no rows were added from DB (shouldn't happen, but just in case)
        If dtBind.Rows.Count = 0 Then
            ' Add at least one empty row
            dtBind.Rows.Add(0, "", "", "", "", 0)
        End If

        grdPropertyInfo.DataSource = dtBind
        grdPropertyInfo.DataBind()

        ' Cache for later
        ViewState("PropertyInfoDT") = dtBind
    End Sub

    Protected Sub txtSerialNoIntangAsset_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim current As TextBox = TryCast(sender, TextBox)
        If current Is Nothing Then
            ModalPopup_PropertyInfo.Show()
            Exit Sub
        End If

        Dim currentSerialRaw As String = (current.Text & "").Trim()
        If currentSerialRaw = "" Then
            ModalPopup_PropertyInfo.Show()
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
                ModalPopup_PropertyInfo.Show()
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
            ModalPopup_PropertyInfo.Show()
            Exit Sub
        End If

        ' keep the modal open after postback
        ModalPopup_PropertyInfo.Show()
    End Sub


    Protected Sub txtPropertyNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim current As TextBox = TryCast(sender, TextBox)
        If current Is Nothing Then
            ModalPopup_PropertyInfo.Show()
            Exit Sub
        End If

        Dim currentPropRaw As String = (current.Text & "").Trim()
        If currentPropRaw = "" Then
            ModalPopup_PropertyInfo.Show()
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
                ModalPopup_PropertyInfo.Show()
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
            ModalPopup_PropertyInfo.Show()
            Exit Sub
        End If

        ' keep the modal open after postback
        ModalPopup_PropertyInfo.Show()
    End Sub

    Protected Sub drpInstalledIntangAsset_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim drp As DropDownList = CType(sender, DropDownList)
        Dim row As GridViewRow = CType(drp.NamingContainer, GridViewRow)
        Dim txtLocation As TextBox = CType(row.FindControl("txtPIFloorLocation"), TextBox)

        ' Get the selected text (could be "N/A", "Field", or a building name)
        Dim selectedText As String = drp.SelectedItem.Text

        If selectedText = "N/A" Or selectedText = "Field" Then
            ' Enable manual location input
            If txtLocation IsNot Nothing Then
                txtLocation.Enabled = True
                txtLocation.Text = ""
            End If
        Else
            ' Disable manual input and auto-populate address from selected building
            If txtLocation IsNot Nothing Then
                txtLocation.Enabled = False

                ' Get building address
                Dim buildingId As Integer = CInt(drp.SelectedValue)
                Dim dt As New DataTable
                dt = objDerived.GetDataTable(
                    "SELECT (case when Address IS NULL then '' else Address end) + " _
                    & " (case when Barangay IS NULL then '' else ', ' + Barangay end) + " _
                    & " (case when Area1 IS NULL then '' else ', ' + Area1 end) " _
                    & " as Address FROM AMS.TbBuilding_Dtl WHERE BuildingId=" & buildingId & "",
                    CommandType.Text)

                If dt.Rows.Count > 0 Then
                    txtLocation.Text = dt.Rows(0).Item(0).ToString()
                Else
                    txtLocation.Text = ""
                End If
            End If
        End If

        ' Keep modal open after postback
        ModalPopup_PropertyInfo.Show()
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
                drpApprovedOfficer.Items.Insert(0, New ListItem("SELECT", ""))
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

            ' Enable editing - CHANGE False to True
            btnSave.Text = "UPDATE"
            IsEnabledTextBox(True)   ' <-- CHANGE THIS TO TRUE to enable textboxes!
            btnSave.Enabled = True


            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Approval successful. You can now edit the information.")
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
        Convert.ToString(
            drpSubClassification.SelectedValue
        ),
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
        "    AND sc.ClassificationID = " &
             classificationID & " " &
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

        ddName.DataSource = dtItemDesc
        ddName.DataTextField = "ItemDescription"
        ddName.DataValueField = "Item_ID"
        ddName.DataBind()

        ddName.Enabled = True

        Session("Item_ID") = 0
        hdnItemNo.Value = "0"
        hdnGAId.Value = ddGA.SelectedValue

        btnSave.Enabled = False

        AddTrace(
        "ClassificationID: " &
        classificationID
    )

        AddTrace(
        "GA_ID: " &
        gaID
    )

        AddTrace(
        "SubClassificationID: " &
        subClassificationID
    )

        AddTrace(
        "Item Count: " &
        Math.Max(
            dtItemDesc.Rows.Count - 1,
            0
        )
    )

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
            txtUsefullife.Text = "0"
        Else
            txtUsefullife.Text = usefulLife
        End If


    End Sub


End Class
