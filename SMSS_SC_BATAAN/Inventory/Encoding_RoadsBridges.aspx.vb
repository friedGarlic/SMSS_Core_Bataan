
Imports System.Data
Imports System.Drawing

Partial Class Inventory_Encoding_RoadsBridges
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim idholder As String = ""
    Protected Sub OnDataBound(sender As Object, e As EventArgs)

        ''Optimize code using chat gpt

    End Sub

    Protected Sub grdLedger1_RowDataBound(
    sender As Object,
    e As GridViewRowEventArgs)

        If e.Row.RowType <>
        DataControlRowType.DataRow Then

            Exit Sub
        End If

        Dim cbInspection As CheckBox =
        TryCast(
            e.Row.FindControl(
                "cbInspection"
            ),
            CheckBox
        )

        Dim propertyID As Long = 0

        Long.TryParse(
        Convert.ToString(
            DataBinder.Eval(
                e.Row.DataItem,
                "Property_ID"
            )
        ),
        propertyID
    )

        Dim transType As String =
        Convert.ToString(
            DataBinder.Eval(
                e.Row.DataItem,
                "Trans_Type"
            )
        ).Trim()

        If cbInspection IsNot Nothing Then

            If propertyID = 0 Then
                cbInspection.Enabled = False

            ElseIf transType.Equals(
            "Purchase Order Delivered",
            StringComparison.OrdinalIgnoreCase
            ) Then

                cbInspection.Enabled = False

            ElseIf transType.StartsWith(
            "Issuance",
            StringComparison.OrdinalIgnoreCase
            ) Then

                cbInspection.Enabled = False

            Else
                cbInspection.Enabled = True
            End If

        End If

        ClearZeroLedgerCell(
        e.Row,
        4
    )

        ClearZeroLedgerCell(
        e.Row,
        5
    )

        'Do not clear CreditQty.
        'Cell 6 must display 0.
        'ClearZeroLedgerCell(e.Row, 6)

        'Do not clear CreditCost.
        'Cell 7 must display 0.00.
        'ClearZeroLedgerCell(e.Row, 7)

        ClearZeroLedgerCell(
        e.Row,
        8
    )

        ClearZeroLedgerCell(
        e.Row,
        9
    )

    End Sub

    Private Sub ClearZeroLedgerCell(
    ByVal row As GridViewRow,
    ByVal cellIndex As Integer)

        If row Is Nothing OrElse
        cellIndex < 0 OrElse
        cellIndex >= row.Cells.Count Then

            Exit Sub
        End If

        Dim cellText As String =
        row.Cells(cellIndex).Text.
        Replace("&nbsp;", "").
        Replace(",", "").
        Trim()

        Dim value As Decimal = 0D

        If Decimal.TryParse(
        cellText,
        value
        ) AndAlso value = 0D Then

            row.Cells(cellIndex).Text =
            "&nbsp;"
        End If

    End Sub


    Private Sub Inventory_Encoding_RoadsBridges_Load(
    sender As Object,
    e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim classificationID As Integer = 0

            Integer.TryParse(
            Convert.ToString(
                objDerived.GetValue(
                    "SELECT TOP 1 ClassificationID " &
                    "FROM dbo.tbl_Classification " &
                    "WHERE isenable = 1 " &
                    "AND ClassificationName = " &
                    "'Construction in Progress' " &
                    "ORDER BY SeqNo",
                    CommandType.Text
                )
            ),
            classificationID
        )

            Session("ClassificationID") =
            classificationID

            AddTrace(
            "ClassificationID: " &
            classificationID
        )

            Session.Remove(
            "TempPropertyList"
        )

            If Session("SavedItemID") IsNot Nothing Then
                idholder =
                Session(
                    "SavedItemID"
                ).ToString()
            End If

            mvSubClass.SetActiveView(
            vwBridge
        )

            LoadGLAccounts()

            drpSubClass.Items.Clear()
            drpSubClass.Items.Insert(
            0,
            New ListItem(
                "No Subclass",
                "0"
            )
        )

            drpSubClass.Enabled = True

            loadEquipmentLedger()

        End If

    End Sub

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
            New ListItem(
                "Select",
                "0"
            )
        )

            ddGlAccount.Enabled = True
            Exit Sub

        End If

        Dim sql As String =
        "SELECT DISTINCT " &
        "    ga.GA_ID, " &
        "    ga.GA_Title " &
        "FROM dbo.tbl_SubClassification AS sc " &
        "INNER JOIN dbo.view_Accntg_gen_accnt AS ga " &
        "    ON ga.GA_ID = sc.GA_ID " &
        "WHERE sc.ClassificationID = " &
        classificationID & " " &
        "ORDER BY ga.GA_Title"

        AddTrace(sql)

        Dim dt As DataTable =
        objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        If dt IsNot Nothing Then

            Dim dr As DataRow =
            dt.NewRow()

            dr("GA_ID") = 0
            dr("GA_Title") = "Select"

            dt.Rows.InsertAt(
            dr,
            0
        )

            ddGlAccount.DataSource = dt
            ddGlAccount.DataTextField =
            "GA_Title"

            ddGlAccount.DataValueField =
            "GA_ID"

            ddGlAccount.DataBind()

        Else

            ddGlAccount.Items.Insert(
            0,
            New ListItem(
                "Select",
                "0"
            )
        )

        End If

        ddGlAccount.Enabled = True

    End Sub


    Private Sub LoadSubClassifications()

        drpSubClass.Items.Clear()

        Dim classificationID As Integer = 0
        Dim gaID As Long = 0

        Integer.TryParse(
        Convert.ToString(
            Session("ClassificationID")
        ),
        classificationID
    )

        Long.TryParse(
        Convert.ToString(
            ddGlAccount.SelectedValue
        ),
        gaID
    )

        If classificationID = 0 OrElse
        gaID = 0 Then

            drpSubClass.Items.Insert(
            0,
            New ListItem(
                "No Subclass",
                "0"
            )
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
        "AND GA_ID = " &
        gaID & " " &
        "ORDER BY SubClassificationName"

        AddTrace(sql)

        Dim dt As DataTable =
        objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        If dt IsNot Nothing Then

            Dim dr As DataRow =
            dt.NewRow()

            dr("SubClassificationID") = 0

            dr("SubClassificationName") =
            "No Subclass"

            dt.Rows.InsertAt(
            dr,
            0
        )

            drpSubClass.DataSource = dt

            drpSubClass.DataTextField =
            "SubClassificationName"

            drpSubClass.DataValueField =
            "SubClassificationID"

            drpSubClass.DataBind()

        Else

            drpSubClass.Items.Insert(
            0,
            New ListItem(
                "No Subclass",
                "0"
            )
        )

        End If

        drpSubClass.Enabled = True

    End Sub




    Public Sub loadEquipmentLedger()

        btnEquipmentLedger.CssClass =
        "Clicked"

        btnequipmentrepairs.CssClass =
        "Initial"

        btnequipmentattachdoc.CssClass =
        "Initial"

        mvledger.SetActiveView(
        vwledger
    )

        Dim gaID As Long = 0

        Long.TryParse(
        Convert.ToString(
            ddGlAccount.SelectedValue
        ),
        gaID
    )

        If gaID = 0 Then

            grdLedger1.DataSource =
            createdatatableledger(9)

            grdLedger1.DataBind()
            Exit Sub

        End If

        Dim sql As String =
        "EXEC [AMS].[PropertyLedger_GA] " &
        "    @GA_ID = " &
        gaID

        AddTrace(sql)

        Dim dtAccount As DataTable =
        objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        If dtAccount Is Nothing Then
            dtAccount =
            createdatatableledger(9)

            grdLedger1.DataSource =
            dtAccount

            grdLedger1.DataBind()
            Exit Sub
        End If

        EnsureLedgerColumns(
        dtAccount
    )

        While dtAccount.Rows.Count < 10
            dtAccount.Rows.Add(
            dtAccount.NewRow()
        )
        End While

        grdLedger1.DataSource =
        dtAccount

        grdLedger1.DataBind()

    End Sub


    Private Sub EnsureLedgerColumns(
    ByVal dt As DataTable)

        If Not dt.Columns.Contains(
        "Ledger_ID") Then

            dt.Columns.Add(
            "Ledger_ID",
            GetType(Long)
        )
        End If

        If Not dt.Columns.Contains(
        "Item_ID") Then

            dt.Columns.Add(
            "Item_ID",
            GetType(Long)
        )
        End If

        If Not dt.Columns.Contains(
        "Property_ID") Then

            dt.Columns.Add(
            "Property_ID",
            GetType(Long)
        )
        End If

        If Not dt.Columns.Contains(
        "dDate") Then

            dt.Columns.Add(
            "dDate",
            GetType(DateTime)
        )
        End If

        If Not dt.Columns.Contains(
        "Trans_Type") Then

            dt.Columns.Add(
            "Trans_Type",
            GetType(String)
        )
        End If

        If Not dt.Columns.Contains(
        "Ref") Then

            dt.Columns.Add(
            "Ref",
            GetType(String)
        )
        End If

        If Not dt.Columns.Contains(
        "DebitQty") Then

            dt.Columns.Add(
            "DebitQty",
            GetType(Integer)
        )
        End If

        If Not dt.Columns.Contains(
        "DebitCost") Then

            dt.Columns.Add(
            "DebitCost",
            GetType(Decimal)
        )
        End If

        If Not dt.Columns.Contains(
        "CreditQty") Then

            dt.Columns.Add(
            "CreditQty",
            GetType(Integer)
        )
        End If

        If Not dt.Columns.Contains(
        "CreditCost") Then

            dt.Columns.Add(
            "CreditCost",
            GetType(Decimal)
        )
        End If

        If Not dt.Columns.Contains(
        "BalQty") Then

            dt.Columns.Add(
            "BalQty",
            GetType(Integer)
        )
        End If

        If Not dt.Columns.Contains(
        "BalCost") Then

            dt.Columns.Add(
            "BalCost",
            GetType(Decimal)
        )
        End If

    End Sub



    Public Function createdatatableledger(
    ByVal row As Integer) As DataTable

        Dim dt As New DataTable()

        dt.Columns.Add(
        "Ledger_ID",
        GetType(Long)
    )

        dt.Columns.Add(
        "Item_ID",
        GetType(Long)
    )

        dt.Columns.Add(
        "Property_ID",
        GetType(Long)
    )

        dt.Columns.Add(
        "dDate",
        GetType(DateTime)
    )

        dt.Columns.Add(
        "Trans_Type",
        GetType(String)
    )

        dt.Columns.Add(
        "Ref",
        GetType(String)
    )

        dt.Columns.Add(
        "DebitQty",
        GetType(Integer)
    )

        dt.Columns.Add(
        "DebitCost",
        GetType(Decimal)
    )

        dt.Columns.Add(
        "CreditQty",
        GetType(Integer)
    )

        dt.Columns.Add(
        "CreditCost",
        GetType(Decimal)
    )

        dt.Columns.Add(
        "BalQty",
        GetType(Integer)
    )

        dt.Columns.Add(
        "BalCost",
        GetType(Decimal)
    )

        For i As Integer = 0 To row
            dt.Rows.Add(
            dt.NewRow()
        )
        Next

        Return dt

    End Function


    Protected Sub drpSubClass_SelectedIndexChanged(
    sender As Object,
    e As EventArgs)

        selectSubClass()

    End Sub

    Public Sub selectSubClass()
        Dim subclassID As Integer = 0
        Integer.TryParse(drpSubClass.SelectedValue, subclassID)

        Dim name As String = If(drpSubClass.SelectedItem IsNot Nothing, drpSubClass.SelectedItem.Text.Trim(), "")
        Dim n As String = name.ToUpperInvariant()

        ' --- ROAD-style subclasses (vwRoad) ---
        Dim roadKeys As String() = {
        "ROAD", "ROAD AND DRAINAGE", "ROAD/SLOPE",
        "PAVEMENT",
        "WALKWAYS",
        "PARKING AREA",
        "DRAINAGE", "DRAINAGE/CULVERT", "BOX CULVERT",
        "RETAINING WALL",
        "SLOPE PROTECTION"
    }

        ' --- BRIDGE/BUILDING/UTILITY-style subclasses (vwBridge) ---
        Dim bridgeKeys As String() = {
        "BRIDGE",
        "BUILDING",
        "CARPENTRY SHOP",
        "SEWAGE TREATMENT",
        "SEPTIC TANK",
        "WATER SYSTEM",
        "FENCE", "FENCING", "FENCE AND RAILING",
        "FITNESS ROOM",
        "GUARD HOUSE",
        "ILLUMINATION",
        "POOL & BLEACHERS",
        "SCOUR PROTECTION"
    }

        ' Decide which view to show
        If bridgeKeys.Any(Function(k) n.Contains(k)) Then
            mvSubClass.SetActiveView(Me.vwBridge)
        ElseIf roadKeys.Any(Function(k) n.Contains(k)) Then
            mvSubClass.ActiveViewIndex = 0   ' vwRoad
        Else
            ' Default to road-style layout if nothing matched
            mvSubClass.ActiveViewIndex = 0
        End If

        loadEquipmentLedger()
    End Sub




    Private Sub LoadGeneralAccounts()
        ' Read current class + subclass
        Dim classId As Integer = 0
        Dim subClassId As Integer = 0
        If Session("ClassificationID") IsNot Nothing Then
            Integer.TryParse(Session("ClassificationID").ToString(), classId)
        End If
        Integer.TryParse(drpSubClass.SelectedValue, subClassId)

        ' If nothing selected, clear & disable GA
        If classId = 0 Then
            ddGlAccount.Items.Clear()
            ddGlAccount.Items.Insert(0, New ListItem("Select", "0"))
            'ddGlAccount.Enabled = False
            Exit Sub
        End If

        ' Same source you use on the other page
        Dim sql As String = "Exec dbo.sp_Accounts_Category_v1_02152022 '2','" & classId & "','" & subClassId & "'"
        Dim dt As DataTable = objDerived.GetDataTable(sql, CommandType.Text)

        ddGlAccount.Items.Clear()
        ddGlAccount.DataSource = dt
        ddGlAccount.DataTextField = "GA_Title"
        ddGlAccount.DataValueField = "GA_ID"
        ddGlAccount.DataBind()

        ' Insert a real "Select" option
        If ddGlAccount.Items.FindByValue("0") Is Nothing Then
            ddGlAccount.Items.Insert(0, New ListItem("Select", "0"))
        End If

        ddGlAccount.Enabled = True





    End Sub


    Protected Sub ddGlAccount_SelectedIndexChanged(
    sender As Object,
    e As EventArgs)

        LoadSubClassifications()

        ClearTextBoxes()

        btnRoadSave.Text = "SAVE"
        btnBridgesave.Text = "SAVE"

        hf_EquipInfoId.Value = ""
        hf_EquipmentId.Value = ""
        hf_PropertyDetai_ID.Value = ""
        hf_Property_ID.Value = ""
        hf_Item_ID.Value = ""

        loadEquipmentLedger()

        AddTrace(
        "ddGlAccount: " &
        Convert.ToString(
            ddGlAccount.SelectedValue
        )
    )

    End Sub

    Dim item As New m_item
    Dim item_detail As New m_item_detail


    Private Prop_Hdr As New t_property_hdr
    Private Prop_Dtl As New t_property_dtl
    Private Prop_Ledger As New t_PropertyLedger

    Private objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info
    Private objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details


    Private Function GetNumericOrZero(input As String) As Decimal
        Dim val As Decimal
        Return If(Decimal.TryParse(input.Replace(",", "").Trim(), val), val, 0D)
    End Function



    Protected Sub btnRoadSave_Click(sender As Object, e As EventArgs)

        If ddGlAccount.SelectedValue Is Nothing OrElse
    ddGlAccount.SelectedValue = "" OrElse
    ddGlAccount.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
        UpdatePanel1,
        "Please select a General Account."
    )

            Exit Sub
        End If




        If btnRoadSave.Text = "SAVE" Then
            Dim missingFields As New List(Of String)

            If String.IsNullOrWhiteSpace(txtRoadID.Text) Then
                missingFields.Add("Property Number")
            End If

            Dim existingCount As Integer = objDerived.GetValue("SELECT COUNT(*) FROM AMS.Property_Dtl WHERE PropertyNo = '" & txtRoadID.Text & "'", CommandType.Text)
            If existingCount > 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property number already existing.")
                Exit Sub
            End If



            If String.IsNullOrWhiteSpace(txtDescriptionRoads.Text) Then
                missingFields.Add("Description")
            End If
            'If drpbookUnit.SelectedIndex = 0 Then
            '    missingFields.Add("Unit")
            'End If
            'If String.IsNullOrWhiteSpace(txtbookQuantity.Text) Then
            '    missingFields.Add("Quantity")
            'End If

            If String.IsNullOrWhiteSpace(txtRemarksRoads.Text) Then
                missingFields.Add("Remarks")
            End If
            If String.IsNullOrWhiteSpace(txtRoadAcqDate.Text) Then
                missingFields.Add("Acquisition Date")
            End If
            If String.IsNullOrWhiteSpace(txtRoadAcqCost.Text) Or txtRoadAcqCost.Text = "0.00" Or txtRoadAcqCost.Text = "0" Then
                missingFields.Add("Acquisition Cost")
            End If

            If missingFields.Count > 0 Then
                Dim message As String = "Please fill up the required field(s):" &
                                "\n - " & String.Join("\n - ", missingFields)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, message)
                Exit Sub
            Else
                CreateRoad()
                loadEquipmentLedger()
            End If


        ElseIf btnRoadSave.Text = "EDIT" Then

            btnRoadSave.Text = "UPDATE"
            IsEnabledTextBox(True)

            txtRoadID.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Textboxes are now enabled to Edit!")

        Else 'IF UPDATE
            UpdateRoadsAndBridges()

            'RESET
            Dim cb1 As CheckBox
            For i As Integer = 0 To grdLedger1.Rows.Count - 1
                cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Checked AndAlso cb1.Visible Then
                    cb1.Checked = False
                End If
            Next


            ClearTextBoxes()
            IsEnabledTextBox(True)
            btnRoadSave.Text = "SAVE"
            btnRoadSave.Enabled = True

            loadEquipmentLedger()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        End If

        btnRoadSave.Enabled = False
        btnBridgesave.Enabled = False
    End Sub

    Protected Sub CreateRoad()

        With item
            .Item_Code = ""
            .Item_Desc = txtRoadName.Text
            .Unit_ID = objDerived.GetValue("select * From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
            .ClassificationID = 22
        End With

        Dim itemid As Integer
        itemid = item.save()
        objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & txtRoadAcqCost.Text.Replace(",", "") & "',null", CommandType.Text)

        Dim classificationID As Integer = 0
        Dim subClassificationID As Integer = 0
        Dim gaID As Long = 0

        Integer.TryParse(
                Convert.ToString(
                    Session("ClassificationID")
                ),
                classificationID
            )

        Integer.TryParse(
                Convert.ToString(
                    drpSubClass.SelectedValue
                ),
                subClassificationID
            )

        Long.TryParse(
                Convert.ToString(
                    ddGlAccount.SelectedValue
                ),
                gaID
            )

        Dim category As Long = 0

        Long.TryParse(
                Convert.ToString(
                    objDerived.GetValue(
                        "SELECT item_particular_id " &
                        "FROM dbo.m_item " &
                        "WHERE Item_ID = " &
                        itemid,
                        CommandType.Text
                    )
                ),
                category
            )

        Dim matrix As String =
                Convert.ToString(
                    objDerived.GetValue(
                        "SELECT id " &
                        "FROM dbo.tblclassmatrix " &
                        "WHERE classificationid = " &
                        classificationID & " " &
                        "AND SubClassificationID = " &
                        subClassificationID & " " &
                        "AND ga_id = " &
                        gaID & " " &
                        "AND item_id = " &
                        itemid,
                        CommandType.Text
                    )
                )

        If String.IsNullOrEmpty(
                matrix
                ) Then

            objDerived.Execute(
                    "INSERT INTO dbo.tblclassmatrix " &
                    "(classificationid, " &
                    " SubClassificationID, " &
                    " ga_id, item_id, " &
                    " categoryid, bga_id) " &
                    "VALUES (" &
                    classificationID & ", " &
                    subClassificationID & ", " &
                    gaID & ", " &
                    itemid & ", " &
                    category & ", 0)",
                    CommandType.Text
                )

        End If

        Dim gaCode As String =
                Convert.ToString(
                    objDerived.GetValue(
                        "SELECT TOP 1 GA_Code " &
                        "FROM geobos.dbo." &
                        "view_allotmentclassaccounts " &
                        "WHERE GA_ID = " &
                        gaID,
                        CommandType.Text
                    )
                )
        If matrix = "" Then
            objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id,SubClassificationID) values('" & Session("ClassificationID") & "','" & gaID & "','" & itemid & "','" & category & "','0','" & drpSubClass.SelectedItem.Value & "')", CommandType.Text)
        End If

        With Prop_Hdr
            '.Property_ID = Property_ID
            .Property_Date = txtRoadAcqDate.Text
            .Issuance = 0
            .Remarks = txtRemarks.Text
            .Emp_ID = 0
            .F_ID = 1
            .AIRDtl_ID = 0
            .deptid = 0
            .isDonated = False
            .GA_ID = gaID
            .DonationRemarks = ""
            .Qty = 1
            .Balance = 1
            .Cost = txtRoadAcqCost.Text.Replace(",", "")
            .Item_ID = itemid
            .Property_code = objDerived.GetValue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
            .RC_ID = 0
            .Function_ID = 0
            .TD_ID = 1
            .Project_ID = 0
            .Program_id = 0
            .Particular = ""
        End With
        Dim PropHdr_ID As Integer = 0
        PropHdr_ID = Prop_Hdr.save()


        objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.Property SET ClassificationID = '" & Session("ClassificationID") & "',SubClassificationID = '" & drpSubClass.SelectedValue & "'  WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)


        'Dim gacode As String = objDerived.GetValue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
        Dim rcid As Integer = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
        Dim Function_ID As Integer = 86


        With Prop_Dtl
            '.PropertyDetai_ID = 0  
            'If txtRoadID.Text = "" Then
            '    .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtRoadAcqDate.Text & "', '" & gacode & "','" & rcid & "','" & Function_ID & "')", CommandType.Text)
            'Else
            '    .PropertyNo = txtRoadID.Text
            'End If
            .PropertyNo = txtRoadID.Text
            .Property_ID = PropHdr_ID
            .Issued = False
            .Repair = False
            .Dispose = False
            .DisposeDate = "1/1/1900"
            .IsInspectionForDisposal = False
            .InspectionDate = txtRoadAcqDate.Text
            .F_ID = 1
            .SerialNo = txtRoadID.Text
            .Barcode = txtRoadID.Text
            .Amount = CType(txtRoadAcqCost.Text, Decimal)
            .Status = "Accepted"
            .Details = ""
            .type = drpSubClass.SelectedItem.Text
        End With

        Dim PropDtl_ID As Integer
        PropDtl_ID = Prop_Dtl.save()

        'objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & txtRoadMarketValue.Text.Replace(",", "") & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = " & If(String.IsNullOrWhiteSpace(txtRoadMarketValue.Text), 0D, CType(txtRoadMarketValue.Text.Replace(",", ""), Decimal)) & " WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

        Dim info_id As Integer
        With objEquipInfo
            .EquipInfoId = 0
            .AIRDtl_ID = 0
            .IsAccepted = True
            .Property_Dtl_ID = PropDtl_ID
            .SerialNo = txtRoadID.Text
            .Name = txtRoadName.Text
            .Description = txtRoadName.Text
            .PowerInput = ""
            .Dimension = ""
            .AreaCapacity = ""
            .Model = ""
            .Warranty = ""
            .Specification = ""
            .DepreciationRate = "0"
            .DepreciationValue = "0.00"
            .SalvageValue = txtRoadSalvageValue.Text.Replace(",", "")
            .ProjectName = txtRoadProjectName.Text
            .InfrastructureID = txtRoadID.Text
            .InfrastructureName = txtRoadName.Text
            .InfrastructureClassification = txtRoadClassification.Text
            .InfrastructureType = txtRoadType.Text
            .InfrastructureFromStreet = txtRoadFromStreet.Text
            .InfrastructureToStreet = txtRoadtoStreet.Text
            .InfrastructureSegmentLock = txtRoadSegmentLock.Text
            .InfrastructureLocation = txtRoadLocation.Text
            .InfrastructureLength = txtRoadLength.Text
            .InfrastructureNoofLanes = txtNoofLane.Text
            .InfrastructureWidth = txtRoadWidth.Text
            .InfrastructureLaneLength = txtRoadLaneLength.Text
            .InfrastructureLaneWidth = txtRoadLaneWidth.Text
            .InfrastructureTrafficDirection = txtRoadTrafficDirection.Text
            .InfrastructureTrafficVolume = txtRoadTrafficVolume.Text
            .InfrastructureTrafficDate = txtTrafficDate.Text
            .InfrastructureSpeedLimit = txtRoadSpeedLimit.Text
            .InfrastructureElevation = txtRoadElevation.Text
            .InfrastructureSurfaceType = txtRoadSurfaceType.Text
            .InfrastructureSurfaceCondition = txtRoadSurfaceCondition.Text
            .LeftLfromAddress = txtRoadLfromAddress.Text
            .LeftLtoAddress = txtRoadLtoAddress.Text
            .LeftNWshldrWidth = txtRoadNorthWestWidth.Text
            .RightRfromAddress = txtRoadRfromAddress.Text
            .RightRtoAddress = txtRoadRtoAddress.Text
            .RightSEshldrWidth = txtRoadSouthEastWidth.Text
            .NoYears = txtRoadNoYears.Text
            .UsefulLife = If(String.IsNullOrWhiteSpace(txtBridgeUsefulLife.Text), 0L, CLng(txtBridgeUsefulLife.Text))
            .Property_ID = PropHdr_ID
        End With

        info_id = objEquipInfo.save()
        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Description = '" & txtDescriptionRoads.Text & "', Remarks = '" & txtRemarksRoads.Text & "'  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

        With objEquipDtl
            .EquipmentId = 0
            .EquipInfoId = info_id
            .Property_Dtl_ID = PropDtl_ID
            .MarketValue = If(String.IsNullOrWhiteSpace(txtBridgeMarketValue.Text), 0D, CDec(txtBridgeMarketValue.Text.Replace(",", "")))

            .Condition = ""
            .Location = ""
            .Status = "Accepted"
            .MaintenanceContactNo = txtRoadContractor.Text
            .MaintenanceContactPerson = txtRoadContactPerson.Text
            .MaintenanceContractor = txtRoadCellphoneNo.Text
        End With
        objEquipDtl.save()

        'item.save()
        '==== SAVE PROPERTY LEDGER
        With Prop_Ledger
            .Ledger_ID = 0
            .PropertyNo = ""
            .SerialNo = ""
            .Trans_Type = "Manual Entry"
            .dDate = txtRoadAcqDate.Text
            .Ref = ""
            .AccountablePerson = ""
            .Department = ""
            .Position = ""
            .AcceptedBy = ""
            .InspectedBy = ""
            .Item_ID = itemid
            .DebitQty = 1
            .DebitCost = CType(txtRoadAcqCost.Text, Decimal)
            .DebitUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            .DebitUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)

            Dim Eqty As Integer
            Dim Eqbalance As Decimal
            Dim dtledger As New DataTable

            dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
            If dtledger.Rows.Count = 0 Then
                Eqty = 0
                Eqbalance = 0.0
            Else
                Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
                Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
            End If

            .BalanceQty = Eqty + 1
            .BalanceCost = CType(txtRoadAcqCost.Text, Decimal) + CType(Eqbalance, Decimal)
            .Property_ID = PropHdr_ID

        End With
        Prop_Ledger.save()

        btnRoadSave.Enabled = True
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        loadEquipmentLedger()

    End Sub

    Protected Sub UpdateRoadsAndBridges()

        Dim subclassID As Integer
        'If drpSubClass.SelectedItem.Text.Contains("Roads") Then
        '    subclassID = 1075
        'ElseIf drpSubClass.SelectedItem.Text.Contains("Bridges") Then
        '    subclassID = 1074
        'Else
        '    subclassID = 0 ' Default (show all)
        'End If
        subclassID = drpSubClass.SelectedValue

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        If (New String() {"ROAD", "ROAD AND DRAINAGE", "ROAD/SLOPE", "PAVEMENT", "WALKWAYS",
                   "PARKING AREA", "DRAINAGE", "DRAINAGE/CULVERT", "BOX CULVERT",
                   "RETAINING WALL", "SLOPE PROTECTION"}).
            Any(Function(k) drpSubClass.SelectedItem.Text.ToUpperInvariant().Contains(k)) Then

            With objDerived.cmd.Parameters
                .AddWithValue("@ProjectName", txtRoadProjectName.Text)
                .AddWithValue("@RoadOrBridgeID", txtRoadID.Text)
                .AddWithValue("@Name", txtRoadName.Text)
                .AddWithValue("@InfrastructureClassification", txtRoadClassification.Text)
                .AddWithValue("@RoadOrBridgeType", txtRoadType.Text)
                .AddWithValue("@InfrastructureFromStreet", txtRoadFromStreet.Text)
                .AddWithValue("@InfrastructureToStreet", txtRoadtoStreet.Text)
                .AddWithValue("@InfrastructureSegmentLock", txtRoadSegmentLock.Text)
                .AddWithValue("@InfrastructureLocation", txtRoadLocation.Text)
                .AddWithValue("@InfrastructureLength", txtRoadLength.Text)
                .AddWithValue("@InfrastructureNoofLanes", txtNoofLane.Text)
                .AddWithValue("@InfrastructureWidth", txtRoadWidth.Text)
                .AddWithValue("@InfrastructureLaneLength", txtRoadLaneLength.Text)
                .AddWithValue("@InfrastructureLaneWidth", txtRoadLaneWidth.Text)
                .AddWithValue("@InfrastructureTrafficDirection", txtRoadTrafficDirection.Text)
                .AddWithValue("@InfrastructureTrafficVolume", txtRoadTrafficVolume.Text)
                .AddWithValue("@InfrastructureTrafficDate", txtTrafficDate.Text)
                .AddWithValue("@InfrastructureSpeedLimit", txtRoadSpeedLimit.Text)
                .AddWithValue("@InfrastructureElevation", txtRoadElevation.Text)
                .AddWithValue("@InfrastructureSurfaceType", txtRoadSurfaceType.Text)
                .AddWithValue("@InfrastructureSurfaceCondition", txtRoadSurfaceCondition.Text)

                .AddWithValue("@LeftLfromAddress", txtRoadLfromAddress.Text)
                .AddWithValue("@LeftLtoAddress", txtRoadLtoAddress.Text)
                .AddWithValue("@LeftNWshldrWidth", txtRoadNorthWestWidth.Text)
                .AddWithValue("@RightRfromAddress", txtRoadRfromAddress.Text)
                .AddWithValue("@RightRtoAddress", txtRoadRtoAddress.Text)
                .AddWithValue("@RightSEshldrWidth", DBNull.Value) ' Not used in Roads

                .AddWithValue("@dDate", txtRoadAcqDate.Text)
                .AddWithValue("@DebitCost", GetNumericOrZero(txtRoadAcqCost.Text))
                .AddWithValue("@DepreciationRate", txtRoadequipmentdepreciatedRate.Text)
                .AddWithValue("@DepreciationValue", GetNumericOrZero(txtRoadequipmentdepreciatedvalue.Text))
                .AddWithValue("@SalvageValue", GetNumericOrZero(txtRoadSalvageValue.Text))
                .AddWithValue("@MarketValue", GetNumericOrZero(txtRoadMarketValue.Text))

                .AddWithValue("@InfrastructureRoutseSignPrefix", DBNull.Value)
                .AddWithValue("@InfrastructureRouteNo", DBNull.Value)
                .AddWithValue("@InfrastructureFeaturedIntersection", DBNull.Value)
                .AddWithValue("@InfrastructureMilePoint", DBNull.Value)
                .AddWithValue("@InfrastructureBorderStructNo", DBNull.Value)
                .AddWithValue("@InfrastructureRoadNo", DBNull.Value)
                .AddWithValue("@InfrastructureNameofRiver", DBNull.Value)
                .AddWithValue("@InfrastructureReferencePost", DBNull.Value)
                .AddWithValue("@InfrastructureEndReferencePost", DBNull.Value)
                .AddWithValue("@InfrastructureStartPosition", DBNull.Value)
                .AddWithValue("@InfrastructureCurrentPosition", DBNull.Value)
                .AddWithValue("@MaintenanceContractor", DBNull.Value)
                .AddWithValue("@MaintenanceContactPerson", DBNull.Value)
                .AddWithValue("@MaintenanceContactNo", DBNull.Value)

                .AddWithValue("@EquipmentInfoID", hf_EquipInfoId.Value)
                .AddWithValue("@EquipmentDtlID", hf_EquipmentId.Value)
                .AddWithValue("@Property_Dtl_ID", hf_PropertyDetai_ID.Value)
                .AddWithValue("@Ledger_ID", hf_Item_ID.Value)
                .AddWithValue("@Property_ID", hf_Property_ID.Value)
                .AddWithValue("@Description", txtDescriptionRoads.Text)
                .AddWithValue("@Remarks", txtRemarksRoads.Text)

            End With

        ElseIf (New String() {"BRIDGE", "BUILDING", "CARPENTRY SHOP", "SEWAGE TREATMENT", "SEPTIC TANK",
                       "WATER SYSTEM", "FENCE", "FENCING", "FENCE AND RAILING", "FITNESS ROOM",
                       "GUARD HOUSE", "ILLUMINATION", "POOL & BLEACHERS", "SCOUR PROTECTION"}).
                        Any(Function(k) drpSubClass.SelectedItem.Text.ToUpperInvariant().Contains(k)) Then

            With objDerived.cmd.Parameters
                .AddWithValue("@ProjectName", txtBridgeProjectName.Text)
                .AddWithValue("@RoadOrBridgeID", txtBridgeID.Text)
                .AddWithValue("@Name", txtBridgeName.Text)
                .AddWithValue("@InfrastructureClassification", DBNull.Value)
                .AddWithValue("@RoadOrBridgeType", txtBridgeType.Text)
                .AddWithValue("@InfrastructureFromStreet", DBNull.Value)
                .AddWithValue("@InfrastructureToStreet", DBNull.Value)
                .AddWithValue("@InfrastructureSegmentLock", DBNull.Value)
                .AddWithValue("@InfrastructureLocation", txtBridgeLocation.Text)
                .AddWithValue("@InfrastructureLength", DBNull.Value)
                .AddWithValue("@InfrastructureNoofLanes", txtNoofLane.Text)
                .AddWithValue("@InfrastructureWidth", DBNull.Value)
                .AddWithValue("@InfrastructureLaneLength", DBNull.Value)
                .AddWithValue("@InfrastructureLaneWidth", DBNull.Value)
                .AddWithValue("@InfrastructureTrafficDirection", DBNull.Value)
                .AddWithValue("@InfrastructureTrafficVolume", DBNull.Value)
                .AddWithValue("@InfrastructureTrafficDate", txtTrafficDate.Text)
                .AddWithValue("@InfrastructureSpeedLimit", DBNull.Value)
                .AddWithValue("@InfrastructureElevation", DBNull.Value)
                .AddWithValue("@InfrastructureSurfaceType", DBNull.Value)
                .AddWithValue("@InfrastructureSurfaceCondition", DBNull.Value)

                .AddWithValue("@LeftLfromAddress", txtBridgeLfromAddress.Text)
                .AddWithValue("@LeftLtoAddress", txtBridgeLtoAddress.Text)
                .AddWithValue("@LeftNWshldrWidth", txtBridgeNorthWestWidth.Text)
                .AddWithValue("@RightRfromAddress", txtBridgeRfromAddress.Text)
                .AddWithValue("@RightRtoAddress", txtBridgeRtoAddress.Text)
                .AddWithValue("@RightSEshldrWidth", txtBridgeStructureNo.Text)

                .AddWithValue("@dDate", txtBridgeAcqDate.Text)
                .AddWithValue("@DebitCost", GetNumericOrZero(txtBridgeAcqCost.Text))
                .AddWithValue("@DepreciationRate", txtBridgeDepRate.Text)
                .AddWithValue("@DepreciationValue", GetNumericOrZero(txtBridgeDepValue.Text))
                .AddWithValue("@SalvageValue", GetNumericOrZero(txtBridgeSalvageValue.Text))
                .AddWithValue("@MarketValue", GetNumericOrZero(txtBridgeMarketValue.Text))

                .AddWithValue("@InfrastructureRoutseSignPrefix", txtBridgeRouteSignPrefix.Text)
                .AddWithValue("@InfrastructureRouteNo", txtBridgeRouteNo.Text)
                .AddWithValue("@InfrastructureFeaturedIntersection", txtBridgeFeaturedIntersected.Text)
                .AddWithValue("@InfrastructureMilePoint", txtBridgeMilePoint.Text)
                .AddWithValue("@InfrastructureBorderStructNo", txtBridgeBorderStructNo.Text)
                .AddWithValue("@InfrastructureRoadNo", txtBridgeRoadNo.Text)
                .AddWithValue("@InfrastructureNameofRiver", txtBridgeNameofRiver.Text)
                .AddWithValue("@InfrastructureReferencePost", txtBridgeReferencePost.Text)
                .AddWithValue("@InfrastructureEndReferencePost", txtBridgeEndReferencePost.Text)
                .AddWithValue("@InfrastructureStartPosition", txtBridgeStartPosition.Text)
                .AddWithValue("@InfrastructureCurrentPosition", txtBridgeCurrentStation.Text)
                .AddWithValue("@MaintenanceContractor", txtBridgeContractor.Text)
                .AddWithValue("@MaintenanceContactPerson", txtBridgeContactPerson.Text)
                .AddWithValue("@MaintenanceContactNo", txtBridgeCellphoneNo.Text)

                .AddWithValue("@EquipmentInfoID", hf_EquipInfoId.Value)
                .AddWithValue("@EquipmentDtlID", hf_EquipmentId.Value)
                .AddWithValue("@Property_Dtl_ID", hf_PropertyDetai_ID.Value)
                .AddWithValue("@Property_ID", hf_Property_ID.Value)
                .AddWithValue("@Ledger_ID", hf_Item_ID.Value)
                .AddWithValue("@Description", txtDescription.Text)
                .AddWithValue("@Remarks", txtRemarks.Text)

            End With

        End If

        objDerived.Execute("AMS.sp_Edit_RoadBridges", CommandType.StoredProcedure)


        ''REBALANCE FROM EDITED ROW ABOVE
        'objDerived.GetDataTable("Exec [AMS].[ReBalanceLedger] null, '" & subclassID & "'", CommandType.Text)
    End Sub

    Protected Sub btnRoadCancel_Click(sender As Object, e As EventArgs)


        'Optimize code
        Dim roadTextBoxes() As TextBox = {
            txtRoadProjectName, txtRoadID, txtRoadName, txtRoadClassification,
            txtRoadType, txtRoadFromStreet, txtRoadtoStreet, txtRoadSegmentLock,
            txtRoadLocation, txtRoadLength, txtNoofLane, txtRoadWidth, txtRoadLaneLength,
            txtRoadLaneWidth, txtRoadTrafficDirection, txtRoadTrafficVolume, txtTrafficDate,
            txtRoadSpeedLimit, txtRoadElevation, txtRoadSurfaceType, txtRoadSurfaceCondition,
            txtRoadLfromAddress, txtRoadLtoAddress, txtRoadNorthWestWidth, txtRoadRfromAddress,
            txtRoadRtoAddress, txtRoadAcqDate, txtRoadAcqCost, txtRoadequipmentdepreciatedRate,
            txtRoadequipmentdepreciatedvalue, txtRoadSalvageValue, txtRoadMarketValue
        }

        Dim bridgeTextBoxes() As TextBox = {
            txtBridgeProjectName, txtBridgeID, txtBridgeName, txtBridgeType,
            txtBridgeLocation, txtNoofLane, txtTrafficDate, txtBridgeLfromAddress,
            txtBridgeLtoAddress, txtBridgeNorthWestWidth, txtBridgeRfromAddress,
            txtBridgeRtoAddress, txtBridgeStructureNo, txtBridgeRouteSignPrefix,
            txtBridgeRouteNo, txtBridgeFeaturedIntersected, txtBridgeMilePoint,
            txtBridgeBorderStructNo, txtBridgeRoadNo, txtBridgeNameofRiver,
            txtBridgeReferencePost, txtBridgeEndReferencePost, txtBridgeStartPosition,
            txtBridgeCurrentStation, txtBridgeContractor, txtBridgeContactPerson,
            txtBridgeCellphoneNo, txtBridgeAcqDate, txtBridgeAcqCost, txtBridgeDepRate,
            txtBridgeDepValue, txtBridgeSalvageValue, txtBridgeMarketValue
        }

        For Each txtBox In roadTextBoxes
            txtBox.Text = ""
        Next

        For Each txtBox In bridgeTextBoxes
            txtBox.Text = ""
        Next


    End Sub

    Protected Sub btnBridgesave_Click(sender As Object, e As EventArgs)

        If ddGlAccount.SelectedValue Is Nothing OrElse
    ddGlAccount.SelectedValue = "" OrElse
    ddGlAccount.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(
        UpdatePanel1,
        "Please select a General Account."
    )

            Exit Sub
        End If



        If btnBridgesave.Text = "SAVE" Then


            Dim missingFields As New List(Of String)

            If String.IsNullOrWhiteSpace(txtBridgeID.Text) Then
                missingFields.Add("Property Number")
            End If

            Dim existingCount As Integer = objDerived.GetValue("SELECT COUNT(*) FROM AMS.Property_Dtl WHERE PropertyNo = '" & txtBridgeID.Text & "'", CommandType.Text)
            If existingCount > 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property number already existing.")
                Exit Sub
            End If



            If String.IsNullOrWhiteSpace(txtDescription.Text) Then
                missingFields.Add("Description")
            End If
            'If drpbookUnit.SelectedIndex = 0 Then
            '    missingFields.Add("Unit")
            'End If
            'If String.IsNullOrWhiteSpace(txtbookQuantity.Text) Then
            '    missingFields.Add("Quantity")
            'End If

            If String.IsNullOrWhiteSpace(txtRemarks.Text) Then
                missingFields.Add("Remarks")
            End If
            If String.IsNullOrWhiteSpace(txtBridgeAcqDate.Text) Then
                missingFields.Add("Acquisition Date")
            End If
            If String.IsNullOrWhiteSpace(txtBridgeAcqCost.Text) Or txtBridgeAcqCost.Text = "0.00" Or txtBridgeAcqCost.Text = "0" Then
                missingFields.Add("Acquisition Cost")
            End If

            If missingFields.Count > 0 Then
                Dim message As String = "Please fill up the required field(s):" &
                                "\n - " & String.Join("\n - ", missingFields)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, message)
                Exit Sub
            Else
                CreateBridge()
                loadEquipmentLedger()
            End If




        ElseIf btnBridgesave.Text = "EDIT" Then

            IsEnabledTextBox(True)

            btnBridgesave.Text = "UPDATE"
            txtBridgeID.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Textboxes are now enabled to Edit!")

        Else 'IF UPDATE
            UpdateRoadsAndBridges()

            'RESET
            Dim cb1 As CheckBox
            For i As Integer = 0 To grdLedger1.Rows.Count - 1
                cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

                If cb1.Checked AndAlso cb1.Visible Then
                    cb1.Checked = False
                End If
            Next


            ClearTextBoxes()
            IsEnabledTextBox(True)
            btnBridgesave.Text = "SAVE"
            btnBridgesave.Enabled = True

            loadEquipmentLedger()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        End If

    End Sub

    Protected Sub CreateBridge()

        With item
            .Item_Code = ""
            .Item_Desc = txtBridgeName.Text
            .Unit_ID = objDerived.GetValue("select * From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
            .ClassificationID = 22
        End With

        Dim itemid As Integer
        itemid = item.save()
        objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & txtBridgeAcqCost.Text.Replace(",", "") & "',null", CommandType.Text)

        Dim classificationID As Integer = 0
        Dim subClassificationID As Integer = 0
        Dim gaID As Long = 0

        Integer.TryParse(
            Convert.ToString(
                Session("ClassificationID")
            ),
            classificationID
        )

        Integer.TryParse(
            Convert.ToString(
                drpSubClass.SelectedValue
            ),
            subClassificationID
        )

        Long.TryParse(
            Convert.ToString(
                ddGlAccount.SelectedValue
            ),
            gaID
        )

        Dim category As Long = 0

        Long.TryParse(
            Convert.ToString(
                objDerived.GetValue(
                    "SELECT item_particular_id " &
                    "FROM dbo.m_item " &
                    "WHERE Item_ID = " &
                    itemid,
                    CommandType.Text
                )
            ),
            category
        )

        Dim matrix As String =
            Convert.ToString(
                objDerived.GetValue(
                    "SELECT id " &
                    "FROM dbo.tblclassmatrix " &
                    "WHERE classificationid = " &
                    classificationID & " " &
                    "AND SubClassificationID = " &
                    subClassificationID & " " &
                    "AND ga_id = " &
                    gaID & " " &
                    "AND item_id = " &
                    itemid,
                    CommandType.Text
                )
            )

        If String.IsNullOrEmpty(
            matrix
            ) Then

            objDerived.Execute(
                "INSERT INTO dbo.tblclassmatrix " &
                "(classificationid, " &
                " SubClassificationID, " &
                " ga_id, item_id, " &
                " categoryid, bga_id) " &
                "VALUES (" &
                classificationID & ", " &
                subClassificationID & ", " &
                gaID & ", " &
                itemid & ", " &
                category & ", 0)",
                CommandType.Text
            )

        End If

        Dim gaCode As String =
            Convert.ToString(
                objDerived.GetValue(
                    "SELECT TOP 1 GA_Code " &
                    "FROM geobos.dbo." &
                    "view_allotmentclassaccounts " &
                    "WHERE GA_ID = " &
                    gaID,
                    CommandType.Text
                )
            )



        With Prop_Hdr
            '.Property_ID = Property_ID
            .Property_Date = txtBridgeAcqDate.Text
            .Issuance = 0
            .Remarks = txtRemarks.Text
            .Emp_ID = 0
            .F_ID = 1
            .AIRDtl_ID = 0
            .deptid = 0
            .isDonated = False
            .GA_ID = gaID
            .DonationRemarks = ""
            .Qty = 1
            .Balance = 1
            .Cost = CType(txtBridgeAcqCost.Text.Replace(",", ""), Decimal)
            .Item_ID = itemid
            .Property_code = objDerived.GetValue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
            .RC_ID = 0
            .Function_ID = 0
            .TD_ID = 1
            .Project_ID = 0
            .Program_id = 0
            .Particular = ""
        End With
        Dim PropHdr_ID As Integer = 0
        PropHdr_ID = Prop_Hdr.save()


        objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.Property SET ClassificationID = '" & Session("ClassificationID") & "',SubClassificationID = '" & drpSubClass.SelectedValue & "'  WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

        'Dim gacode As String = objDerived.GetValue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", CommandType.Text)
        Dim rcid As Integer = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
        Dim Function_ID As Integer = 86


        With Prop_Dtl
            '.PropertyDetai_ID = 0  
            'If txtBridgeID.Text = "" Then
            '    .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtBridgeAcqDate.Text & "', '" & gacode & "','" & rcid & "','" & Function_ID & "')", CommandType.Text)
            'Else
            '    .PropertyNo = txtBridgeID.Text
            'End If
            .PropertyNo = txtBridgeID.Text
            .Property_ID = PropHdr_ID
            .Issued = False
            .Repair = False
            .Dispose = False
            .DisposeDate = "1/1/1900"
            .IsInspectionForDisposal = False
            .InspectionDate = txtBridgeAcqDate.Text
            .F_ID = 1
            .SerialNo = txtBridgeID.Text
            .Barcode = txtBridgeID.Text
            .Amount = CType(txtBridgeAcqCost.Text.Replace(",", ""), Decimal)
            .Status = "Accepted"
            .Details = ""
            .type = drpSubClass.SelectedItem.Text
        End With

        Dim PropDtl_ID As Integer
        PropDtl_ID = Prop_Dtl.save()

        'objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & CType(txtBridgeMarketValue.Text.Replace(",", ""), Decimal) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & If(String.IsNullOrWhiteSpace(txtBridgeMarketValue.Text), 0D, CType(txtBridgeMarketValue.Text.Replace(",", ""), Decimal)) & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)


        Dim info_id As Integer
        With objEquipInfo
            .EquipInfoId = 0
            .AIRDtl_ID = 0
            .IsAccepted = True
            .Property_Dtl_ID = PropDtl_ID
            .SerialNo = txtBridgeID.Text
            .Name = txtBridgeName.Text
            .Description = txtBridgeName.Text
            .PowerInput = ""
            .Dimension = ""
            .AreaCapacity = ""
            .Model = ""
            .Warranty = ""
            .Specification = ""
            .DepreciationRate = "0"
            .DepreciationValue = "0.00"
            .SalvageValue = txtBridgeSalvageValue.Text
            .ProjectName = txtBridgeProjectName.Text
            .InfrastructureID = txtBridgeID.Text
            .InfrastructureName = txtBridgeName.Text
            '.InfrastructureClassification = txtBridgeClassification.text
            .InfrastructureType = txtBridgeType.Text
            '            .InfrastructureFromStreet = txtBridgeFromStreet.text
            '            .InfrastructureToStreet = txtBridgetoStreet.text
            '            .InfrastructureSegmentLock = txtBridgeSegmentLock.text
            .InfrastructureLocation = txtBridgeLocation.Text
            '            .InfrastructureLength = txtBridgeLength.text
            .InfrastructureNoofLanes = txtNoofLane.Text
            '            .InfrastructureWidth = txtBridgeWidth.text
            '            .InfrastructureLaneLength = txtBridgeLaneLength.text
            '            .InfrastructureLaneWidth = txtBridgeLaneWidth.text
            '            .InfrastructureTrafficDirection = txtBridgeTrafficDirection.text
            '            .InfrastructureTrafficVolume = txtBridgeTrafficVolume.text
            .InfrastructureTrafficDate = txtTrafficDate.Text
            '            .InfrastructureSpeedLimit = txtBridgeSpeedLimit.text
            '            .InfrastructureElevation = txtBridgeElevation.text
            '            .InfrastructureSurfaceType = ""
            '            .InfrastructureSurfaceCondition = ""
            .LeftLfromAddress = txtBridgeLfromAddress.Text
            .LeftLtoAddress = txtBridgeLtoAddress.Text
            .LeftNWshldrWidth = txtBridgeNorthWestWidth.Text
            .RightRfromAddress = txtBridgeRfromAddress.Text
            .RightRtoAddress = txtBridgeRtoAddress.Text
            .RightSEshldrWidth = txtBridgeSouthEastWidth.Text
            .InfrastructureNumber = txtBridgeStructureNo.Text
            .InfrastructureRoutseSignPrefix = txtBridgeRouteSignPrefix.Text
            .InfrastructureRouteNo = txtBridgeRouteNo.Text
            .InfrastructureFeaturedIntersection = txtBridgeFeaturedIntersected.Text
            .InfrastructureMilePoint = txtBridgeMilePoint.Text
            .InfrastructureBorderStructNo = txtBridgeBorderStructNo.Text
            .InfrastructureRoadNo = txtBridgeRoadNo.Text
            .InfrastructureNameofRiver = txtBridgeNameofRiver.Text
            .InfrastructureReferencePost = txtBridgeReferencePost.Text
            .InfrastructureEndReferencePost = txtBridgeEndReferencePost.Text
            .InfrastructureStartPosition = txtBridgeStartPosition.Text
            .InfrastructureCurrentPosition = txtBridgeCurrentStation.Text
            .NoYears = txtBridgeNoYears.Text
            .UsefulLife = If(String.IsNullOrWhiteSpace(txtBridgeUsefulLife.Text), 0L, CLng(txtBridgeUsefulLife.Text))

            .Property_ID = PropHdr_ID
        End With

        info_id = objEquipInfo.save()
        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = 0, Received_Dtl_ID = 0  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Description = '" & txtDescription.Text & "', Remarks = '" & txtRemarks.Text & "'  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)


        With objEquipDtl
            .EquipmentId = 0
            .EquipInfoId = info_id
            .Property_Dtl_ID = PropDtl_ID
            .MarketValue = If(String.IsNullOrWhiteSpace(txtBridgeMarketValue.Text), 0D, CDec(txtBridgeMarketValue.Text.Replace(",", "")))

            .Condition = ""
            .Location = ""
            .Status = "Accepted"
            .MaintenanceContractor = txtBridgeContractor.Text
            .MaintenanceContactPerson = txtBridgeContactPerson.Text
            .MaintenanceContactNo = txtBridgeCellphoneNo.Text
        End With
        objEquipDtl.save()

        'item.save()
        '==== SAVE PROPERTY LEDGER
        With Prop_Ledger
            .Ledger_ID = 0
            .PropertyNo = ""
            .SerialNo = ""
            .Trans_Type = "Manual Entry"
            .dDate = txtBridgeAcqDate.Text
            .Ref = ""
            .AccountablePerson = ""
            .Department = ""
            .Position = ""
            .AcceptedBy = ""
            .InspectedBy = ""
            .Item_ID = itemid
            .DebitQty = 1
            .DebitCost = CType(txtBridgeAcqCost.Text.Replace(",", ""), Decimal)
            .DebitUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            .DebitUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)

            Dim Eqty As Integer
            Dim Eqbalance As Decimal
            Dim dtledger As New DataTable

            dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
            If dtledger.Rows.Count = 0 Then
                Eqty = 0
                Eqbalance = 0.0
            Else
                Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
                Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
            End If

            .BalanceQty = Eqty + 1
            .BalanceCost = CType(txtBridgeAcqCost.Text.Replace(",", ""), Decimal) + CType(Eqbalance, Decimal)
            .Property_ID = PropHdr_ID
        End With
        Prop_Ledger.save()

        '' btnBridgeSave.Enabled = False
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        'Load_EncodedProperties()
        idholder = itemid
    End Sub

    Protected Sub btnCancelBridge_Click(sender As Object, e As EventArgs)
        txtBridgeProjectName.Text = ""
        txtBridgeID.Text = ""
        txtBridgeName.Text = ""
        txtBridgeType.Text = ""
        txtBridgeStructureNo.Text = ""
        txtBridgeRouteSignPrefix.Text = ""
        txtBridgeLocation.Text = ""
        txtBridgeRouteNo.Text = ""
        txtBridgeFeaturedIntersected.Text = ""
        txtBridgeMilePoint.Text = ""
        txtBridgeBorderStructNo.Text = ""
        txtBridgeRoadNo.Text = ""
        txtBridgeNameofRiver.Text = ""
        txtBridgeReferencePost.Text = ""
        txtBridgeEndReferencePost.Text = ""
        txtBridgeStartPosition.Text = ""
        txtBridgeCurrentStation.Text = ""
        txtBridgeLfromAddress.Text = ""
        txtBridgeRfromAddress.Text = ""
        txtBridgeLtoAddress.Text = ""
        txtBridgeRtoAddress.Text = ""
        txtBridgeNorthWestWidth.Text = ""
        txtBridgeSouthEastWidth.Text = ""
        txtBridgeAcqDate.Text = ""
        txtBridgeAcqCost.Text = ""
        txtBridgeDepRate.Text = ""
        txtBridgeDepValue.Text = ""
        txtDepreciationValue.Text = ""
        txtBridgeMarketValue.Text = ""
        txtBridgeNoYears.Text = ""
        txtBridgeUsefulLife.Text = ""
        txtBridgeSalvageValue.Text = ""
        txtBridgeContractor.Text = ""
        txtBridgeContactPerson.Text = ""
        txtBridgeCellphoneNo.Text = ""
    End Sub

    Protected Sub cbInspection_CheckedChanged(
    ByVal sender As Object,
    ByVal e As System.EventArgs)

        Dim selectedCheckBox As CheckBox =
        TryCast(
            sender,
            CheckBox
        )

        If selectedCheckBox Is Nothing Then
            Exit Sub
        End If

        Dim selectedGridRow As GridViewRow =
        TryCast(
            selectedCheckBox.NamingContainer,
            GridViewRow
        )

        If selectedGridRow Is Nothing Then
            Exit Sub
        End If

        ViewState("CheckboxEvent") = True

        ' =====================================================
        ' ALLOW ONLY ONE CHECKED LEDGER ROW
        ' =====================================================
        For Each currentGridRow As GridViewRow In
        grdLedger1.Rows

            Dim currentCheckBox As CheckBox =
            TryCast(
                currentGridRow.FindControl(
                    "cbInspection"
                ),
                CheckBox
            )

            If currentCheckBox IsNot Nothing AndAlso
            currentGridRow.RowIndex <>
            selectedGridRow.RowIndex Then

                currentCheckBox.Checked = False
            End If

        Next

        ' Reset record IDs before loading another record.
        hf_EquipInfoId.Value = ""
        hf_EquipmentId.Value = ""
        hf_PropertyDetai_ID.Value = ""
        hf_Property_ID.Value = ""
        hf_Item_ID.Value = ""

        btnRoadSave.Text = "SAVE"
        btnRoadSave.Enabled = True

        btnBridgesave.Text = "SAVE"
        btnBridgesave.Enabled = True

        ' When the current checkbox is unchecked,
        ' return the page to a new-entry state.
        If Not selectedCheckBox.Checked Then

            ClearTextBoxes()
            IsEnabledTextBox(True)

            Exit Sub
        End If

        ' =====================================================
        ' READ THE SELECTED LEDGER DATAKEYS
        ' =====================================================
        Dim propertyID As Long = 0
        Dim ledgerID As Long = 0
        Dim itemID As Long = 0

        Long.TryParse(
        Convert.ToString(
            grdLedger1.DataKeys(
                selectedGridRow.RowIndex
            ).Values("Property_ID")
        ),
        propertyID
    )

        Long.TryParse(
        Convert.ToString(
            grdLedger1.DataKeys(
                selectedGridRow.RowIndex
            ).Values("Ledger_ID")
        ),
        ledgerID
    )

        Long.TryParse(
        Convert.ToString(
            grdLedger1.DataKeys(
                selectedGridRow.RowIndex
            ).Values("Item_ID")
        ),
        itemID
    )

        AddTrace(
        "Selected Property_ID: " &
        propertyID
    )

        AddTrace(
        "Selected Ledger_ID: " &
        ledgerID
    )

        AddTrace(
        "Selected Item_ID: " &
        itemID
    )

        If propertyID = 0 Then

            selectedCheckBox.Checked = False

            ClearTextBoxes()
            IsEnabledTextBox(True)

            Exit Sub
        End If

        Dim subclassID As Integer = 0

        Integer.TryParse(
        Convert.ToString(
            drpSubClass.SelectedValue
        ),
        subclassID
    )



        ' =====================================================
        ' DETERMINE WHETHER THE SUBCLASS USES ROAD OR BRIDGE VIEW
        ' =====================================================
        Dim subclassName As String =
        If(
            drpSubClass.SelectedItem Is Nothing,
            "",
            drpSubClass.SelectedItem.Text.Trim()
        )

        Dim normalizedSubclass As String =
        subclassName.ToUpperInvariant()

        Dim roadKeys As String() = {
        "ROAD",
        "ROAD AND DRAINAGE",
        "ROAD/SLOPE",
        "PAVEMENT",
        "WALKWAYS",
        "PARKING AREA",
        "DRAINAGE",
        "DRAINAGE/CULVERT",
        "BOX CULVERT",
        "RETAINING WALL",
        "SLOPE PROTECTION"
    }

        Dim bridgeKeys As String() = {
        "BRIDGE",
        "BUILDING",
        "CARPENTRY SHOP",
        "SEWAGE TREATMENT",
        "SEPTIC TANK",
        "WATER SYSTEM",
        "FENCE",
        "FENCING",
        "FENCE AND RAILING",
        "FITNESS ROOM",
        "GUARD HOUSE",
        "ILLUMINATION",
        "POOL & BLEACHERS",
        "SCOUR PROTECTION"
    }

        Dim isRoad As Boolean =
        roadKeys.Any(
            Function(key)
                Return normalizedSubclass.Contains(key)
            End Function
        )

        Dim isBridge As Boolean =
        bridgeKeys.Any(
            Function(key)
                Return normalizedSubclass.Contains(key)
            End Function
        )

        If isBridge Then
            mvSubClass.SetActiveView(
            vwBridge
        )
        Else
            mvSubClass.SetActiveView(
            vwRoad
        )

            isRoad = True
        End If

        ClearTextBoxes()
        IsEnabledTextBox(True)

        ' =====================================================
        ' LOAD DETAILS FOR THE SELECTED SUBCLASS
        ' =====================================================
        Dim sql As String =
        "EXEC [AMS].[sp_View_Encoding_RoadBridge] '" &
        subclassID &
        "'"

        AddTrace(sql)

        Dim dtDetails As DataTable =
        objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        If dtDetails Is Nothing OrElse
        dtDetails.Rows.Count = 0 Then

            selectedCheckBox.Checked = False

            MsgeBox.CreateMessageAlertInUpdatePanel(
            UpdatePanel1,
            "No Road or Bridge information was found."
        )

            Exit Sub
        End If

        If Not dtDetails.Columns.Contains(
        "Property_ID") Then

            selectedCheckBox.Checked = False

            MsgeBox.CreateMessageAlertInUpdatePanel(
            UpdatePanel1,
            "Property_ID was not returned by the detail procedure."
        )

            Exit Sub
        End If

        ' =====================================================
        ' FIND THE DETAIL RECORD USING PROPERTY_ID
        ' =====================================================
        Dim selectedDataRow As DataRow =
        Nothing

        For Each currentDataRow As DataRow In
        dtDetails.Rows

            Dim currentPropertyID As Long = 0

            Long.TryParse(
            Convert.ToString(
                currentDataRow(
                    "Property_ID"
                )
            ),
            currentPropertyID
        )

            If currentPropertyID = propertyID Then
                selectedDataRow = currentDataRow
                Exit For
            End If

        Next

        If selectedDataRow Is Nothing Then

            selectedCheckBox.Checked = False

            ClearTextBoxes()
            IsEnabledTextBox(True)

            MsgeBox.CreateMessageAlertInUpdatePanel(
            UpdatePanel1,
            "The selected property information could not be found."
        )

            Exit Sub
        End If

        ' =====================================================
        ' POPULATE BRIDGE-STYLE INFORMATION
        ' =====================================================
        If isBridge Then

            txtBridgeProjectName.Text =
            selectedDataRow(
                "ProjectName"
            ).ToString()

            txtBridgeID.Text =
            selectedDataRow(
                "RoadOrBridgeID"
            ).ToString()

            txtBridgeName.Text =
            selectedDataRow(
                "InfrastructureName"
            ).ToString()

            txtBridgeType.Text =
            selectedDataRow(
                "RoadOrBridgeType"
            ).ToString()

            txtBridgeLocation.Text =
            selectedDataRow(
                "InfrastructureLocation"
            ).ToString()

            txtNoofLane.Text =
            selectedDataRow(
                "InfrastructureNoofLanes"
            ).ToString()

            txtTrafficDate.Text =
            selectedDataRow(
                "InfrastructureTrafficDate"
            ).ToString()

            txtBridgeLfromAddress.Text =
            selectedDataRow(
                "LeftLfromAddress"
            ).ToString()

            txtBridgeLtoAddress.Text =
            selectedDataRow(
                "LeftLtoAddress"
            ).ToString()

            txtBridgeNorthWestWidth.Text =
            selectedDataRow(
                "LeftNWshldrWidth"
            ).ToString()

            txtBridgeRfromAddress.Text =
            selectedDataRow(
                "RightRfromAddress"
            ).ToString()

            txtBridgeRtoAddress.Text =
            selectedDataRow(
                "RightRtoAddress"
            ).ToString()

            txtBridgeSouthEastWidth.Text =
            selectedDataRow(
                "RightSEshldrWidth"
            ).ToString()

            If dtDetails.Columns.Contains(
            "InfrastructureNumber") Then

                txtBridgeStructureNo.Text =
                selectedDataRow(
                    "InfrastructureNumber"
                ).ToString()
            Else
                txtBridgeStructureNo.Text = ""
            End If

            txtBridgeRouteSignPrefix.Text =
            selectedDataRow(
                "InfrastructureRoutseSignPrefix"
            ).ToString()

            txtBridgeRouteNo.Text =
            selectedDataRow(
                "InfrastructureRouteNo"
            ).ToString()

            txtBridgeFeaturedIntersected.Text =
            selectedDataRow(
                "InfrastructureFeaturedIntersection"
            ).ToString()

            txtBridgeMilePoint.Text =
            selectedDataRow(
                "InfrastructureMilePoint"
            ).ToString()

            txtBridgeBorderStructNo.Text =
            selectedDataRow(
                "InfrastructureBorderStructNo"
            ).ToString()

            txtBridgeRoadNo.Text =
            selectedDataRow(
                "InfrastructureRoadNo"
            ).ToString()

            txtBridgeNameofRiver.Text =
            selectedDataRow(
                "InfrastructureNameofRiver"
            ).ToString()

            txtBridgeReferencePost.Text =
            selectedDataRow(
                "InfrastructureReferencePost"
            ).ToString()

            txtBridgeEndReferencePost.Text =
            selectedDataRow(
                "InfrastructureEndReferencePost"
            ).ToString()

            txtBridgeStartPosition.Text =
            selectedDataRow(
                "InfrastructureStartPosition"
            ).ToString()

            txtBridgeCurrentStation.Text =
            selectedDataRow(
                "InfrastructureCurrentPosition"
            ).ToString()

            txtBridgeContractor.Text =
            selectedDataRow(
                "MaintenanceContractor"
            ).ToString()

            txtBridgeContactPerson.Text =
            selectedDataRow(
                "MaintenanceContactPerson"
            ).ToString()

            txtBridgeCellphoneNo.Text =
            selectedDataRow(
                "MaintenanceContactNo"
            ).ToString()

            txtBridgeAcqDate.Text =
            selectedDataRow(
                "dDate"
            ).ToString()

            txtBridgeAcqCost.Text =
            selectedDataRow(
                "DebitCost"
            ).ToString()

            txtBridgeDepRate.Text =
            selectedDataRow(
                "DepreciationRate"
            ).ToString()

            txtBridgeDepValue.Text =
            selectedDataRow(
                "DepreciationValue"
            ).ToString()

            txtBridgeSalvageValue.Text =
            selectedDataRow(
                "SalvageValue"
            ).ToString()

            txtBridgeMarketValue.Text =
            selectedDataRow(
                "MarketValue"
            ).ToString()

            txtDescription.Text =
            selectedDataRow(
                "Description"
            ).ToString()

            txtRemarks.Text =
            selectedDataRow(
                "Remarks"
            ).ToString()

        ElseIf isRoad Then

            ' =====================================================
            ' POPULATE ROAD-STYLE INFORMATION
            ' =====================================================
            txtRoadProjectName.Text =
            selectedDataRow(
                "ProjectName"
            ).ToString()

            txtRoadID.Text =
            selectedDataRow(
                "RoadOrBridgeID"
            ).ToString()

            txtRoadName.Text =
            selectedDataRow(
                "Name"
            ).ToString()

            txtRoadClassification.Text =
            selectedDataRow(
                "InfrastructureClassification"
            ).ToString()

            txtRoadType.Text =
            selectedDataRow(
                "RoadOrBridgeType"
            ).ToString()

            txtRoadFromStreet.Text =
            selectedDataRow(
                "InfrastructureFromStreet"
            ).ToString()

            txtRoadtoStreet.Text =
            selectedDataRow(
                "InfrastructureToStreet"
            ).ToString()

            txtRoadSegmentLock.Text =
            selectedDataRow(
                "InfrastructureSegmentLock"
            ).ToString()

            txtRoadLocation.Text =
            selectedDataRow(
                "InfrastructureLocation"
            ).ToString()

            txtRoadLength.Text =
            selectedDataRow(
                "InfrastructureLength"
            ).ToString()

            txtNoofLane.Text =
            selectedDataRow(
                "InfrastructureNoofLanes"
            ).ToString()

            txtRoadWidth.Text =
            selectedDataRow(
                "InfrastructureWidth"
            ).ToString()

            txtRoadLaneLength.Text =
            selectedDataRow(
                "InfrastructureLaneLength"
            ).ToString()

            txtRoadLaneWidth.Text =
            selectedDataRow(
                "InfrastructureLaneWidth"
            ).ToString()

            txtRoadTrafficDirection.Text =
            selectedDataRow(
                "InfrastructureTrafficDirection"
            ).ToString()

            txtRoadTrafficVolume.Text =
            selectedDataRow(
                "InfrastructureTrafficVolume"
            ).ToString()

            txtTrafficDate.Text =
            selectedDataRow(
                "InfrastructureTrafficDate"
            ).ToString()

            txtRoadSpeedLimit.Text =
            selectedDataRow(
                "InfrastructureSpeedLimit"
            ).ToString()

            txtRoadElevation.Text =
            selectedDataRow(
                "InfrastructureElevation"
            ).ToString()

            txtRoadSurfaceType.Text =
            selectedDataRow(
                "InfrastructureSurfaceType"
            ).ToString()

            txtRoadSurfaceCondition.Text =
            selectedDataRow(
                "InfrastructureSurfaceCondition"
            ).ToString()

            txtRoadLfromAddress.Text =
            selectedDataRow(
                "LeftLfromAddress"
            ).ToString()

            txtRoadLtoAddress.Text =
            selectedDataRow(
                "LeftLtoAddress"
            ).ToString()

            txtRoadNorthWestWidth.Text =
            selectedDataRow(
                "LeftNWshldrWidth"
            ).ToString()

            txtRoadRfromAddress.Text =
            selectedDataRow(
                "RightRfromAddress"
            ).ToString()

            txtRoadRtoAddress.Text =
            selectedDataRow(
                "RightRtoAddress"
            ).ToString()

            txtRoadSouthEastWidth.Text =
            selectedDataRow(
                "RightSEshldrWidth"
            ).ToString()

            txtRoadAcqDate.Text =
            selectedDataRow(
                "dDate"
            ).ToString()

            txtRoadAcqCost.Text =
            selectedDataRow(
                "DebitCost"
            ).ToString()

            txtRoadequipmentdepreciatedRate.Text =
            selectedDataRow(
                "DepreciationRate"
            ).ToString()

            txtRoadequipmentdepreciatedvalue.Text =
            selectedDataRow(
                "DepreciationValue"
            ).ToString()

            txtRoadSalvageValue.Text =
            selectedDataRow(
                "SalvageValue"
            ).ToString()

            txtRoadMarketValue.Text =
            selectedDataRow(
                "MarketValue"
            ).ToString()

            txtRoadContractor.Text =
            selectedDataRow(
                "MaintenanceContractor"
            ).ToString()

            txtRoadContactPerson.Text =
            selectedDataRow(
                "MaintenanceContactPerson"
            ).ToString()

            txtRoadCellphoneNo.Text =
            selectedDataRow(
                "MaintenanceContactNo"
            ).ToString()

            txtDescriptionRoads.Text =
            selectedDataRow(
                "Description"
            ).ToString()

            txtRemarksRoads.Text =
            selectedDataRow(
                "Remarks"
            ).ToString()

        End If

        ' =====================================================
        ' STORE IDS USED BY UpdateRoadsAndBridges()
        ' =====================================================
        hf_EquipInfoId.Value =
        selectedDataRow(
            "EquipInfoId"
        ).ToString()

        hf_EquipmentId.Value =
        selectedDataRow(
            "EquipmentId"
        ).ToString()

        hf_PropertyDetai_ID.Value =
        selectedDataRow(
            "PropertyDetai_ID"
        ).ToString()

        hf_Property_ID.Value =
        propertyID.ToString()

        hf_Item_ID.Value =
        ledgerID.ToString()

        ' Make the selected property read-only until EDIT is clicked.
        IsEnabledTextBox(False)

        btnRoadSave.Text = "EDIT"
        btnRoadSave.Enabled = True

        btnBridgesave.Text = "EDIT"
        btnBridgesave.Enabled = True

    End Sub


    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub


    Protected Sub IsEnabledTextBox(IsEnabled As Boolean)

        ' Normalize selected subclass text
        Dim name As String = If(drpSubClass.SelectedItem IsNot Nothing, drpSubClass.SelectedItem.Text.Trim(), "")
        Dim n As String = name.ToUpperInvariant()

        ' Same buckets used in selectSubClass / cbInspection_CheckedChanged
        Dim roadKeys As String() = {
        "ROAD", "ROAD AND DRAINAGE", "ROAD/SLOPE",
        "PAVEMENT",
        "WALKWAYS",
        "PARKING AREA",
        "DRAINAGE", "DRAINAGE/CULVERT", "BOX CULVERT",
        "RETAINING WALL",
        "SLOPE PROTECTION"
    }

        Dim bridgeKeys As String() = {
        "BRIDGE",
        "BUILDING",
        "CARPENTRY SHOP",
        "SEWAGE TREATMENT",
        "SEPTIC TANK",
        "WATER SYSTEM",
        "FENCE", "FENCING", "FENCE AND RAILING",
        "FITNESS ROOM",
        "GUARD HOUSE",
        "ILLUMINATION",
        "POOL & BLEACHERS",
        "SCOUR PROTECTION"
    }

        Dim isRoad As Boolean = roadKeys.Any(Function(k) n.Contains(k))
        Dim isBridge As Boolean = bridgeKeys.Any(Function(k) n.Contains(k))

        If isRoad Then
            Dim roadTextBoxes() As TextBox = {
            txtRoadProjectName, txtRoadID, txtRoadName, txtRoadClassification,
            txtRoadType, txtRoadFromStreet, txtRoadtoStreet, txtRoadSegmentLock,
            txtRoadLocation, txtRoadLength, txtNoofLane, txtRoadWidth, txtRoadLaneLength,
            txtRoadLaneWidth, txtRoadTrafficDirection, txtRoadTrafficVolume, txtTrafficDate,
            txtRoadSpeedLimit, txtRoadElevation, txtRoadSurfaceType, txtRoadSurfaceCondition,
            txtRoadLfromAddress, txtRoadLtoAddress, txtRoadNorthWestWidth, txtRoadRfromAddress,
            txtRoadRtoAddress, txtRoadAcqDate, txtRoadAcqCost, txtRoadequipmentdepreciatedRate,
            txtRoadequipmentdepreciatedvalue, txtRoadSalvageValue, txtRoadMarketValue,
            txtRemarksRoads, txtDescriptionRoads
        }
            For Each txtBox As TextBox In roadTextBoxes
                txtBox.Enabled = IsEnabled
            Next

        ElseIf isBridge Then
            Dim bridgeTextBoxes() As TextBox = {
            txtBridgeProjectName, txtBridgeID, txtBridgeName, txtBridgeType,
            txtBridgeLocation, txtNoofLane, txtTrafficDate, txtBridgeLfromAddress,
            txtBridgeLtoAddress, txtBridgeNorthWestWidth, txtBridgeRfromAddress,
            txtBridgeRtoAddress, txtBridgeStructureNo, txtBridgeRouteSignPrefix,
            txtBridgeRouteNo, txtBridgeFeaturedIntersected, txtBridgeMilePoint,
            txtBridgeBorderStructNo, txtBridgeRoadNo, txtBridgeNameofRiver,
            txtBridgeReferencePost, txtBridgeEndReferencePost, txtBridgeStartPosition,
            txtBridgeCurrentStation, txtBridgeContractor, txtBridgeContactPerson,
            txtBridgeCellphoneNo, txtBridgeAcqDate, txtBridgeAcqCost, txtBridgeDepRate,
            txtBridgeDepValue, txtBridgeSalvageValue, txtBridgeMarketValue,
            txtRemarks, txtDescription
        }
            For Each txtBox As TextBox In bridgeTextBoxes
                txtBox.Enabled = IsEnabled
            Next
        End If

    End Sub


    Protected Sub ClearTextBoxes()

        Dim name As String = If(drpSubClass.SelectedItem IsNot Nothing, drpSubClass.SelectedItem.Text.Trim(), "")
        Dim n As String = name.ToUpperInvariant()

        Dim roadKeys As String() = {
        "ROAD", "ROAD AND DRAINAGE", "ROAD/SLOPE",
        "PAVEMENT",
        "WALKWAYS",
        "PARKING AREA",
        "DRAINAGE", "DRAINAGE/CULVERT", "BOX CULVERT",
        "RETAINING WALL",
        "SLOPE PROTECTION"
    }

        Dim bridgeKeys As String() = {
        "BRIDGE",
        "BUILDING",
        "CARPENTRY SHOP",
        "SEWAGE TREATMENT",
        "SEPTIC TANK",
        "WATER SYSTEM",
        "FENCE", "FENCING", "FENCE AND RAILING",
        "FITNESS ROOM",
        "GUARD HOUSE",
        "ILLUMINATION",
        "POOL & BLEACHERS",
        "SCOUR PROTECTION"
    }

        Dim isRoad As Boolean = roadKeys.Any(Function(k) n.Contains(k))
        Dim isBridge As Boolean = bridgeKeys.Any(Function(k) n.Contains(k))

        If isRoad Then
            Dim roadTextBoxes() As TextBox = {
            txtRoadProjectName, txtRoadID, txtRoadName, txtRoadClassification,
            txtRoadType, txtRoadFromStreet, txtRoadtoStreet, txtRoadSegmentLock,
            txtRoadLocation, txtRoadLength, txtNoofLane, txtRoadWidth, txtRoadLaneLength,
            txtRoadLaneWidth, txtRoadTrafficDirection, txtRoadTrafficVolume, txtTrafficDate,
            txtRoadSpeedLimit, txtRoadElevation, txtRoadSurfaceType, txtRoadSurfaceCondition,
            txtRoadLfromAddress, txtRoadLtoAddress, txtRoadNorthWestWidth, txtRoadRfromAddress,
            txtRoadRtoAddress, txtRoadAcqDate, txtRoadAcqCost, txtRoadequipmentdepreciatedRate,
            txtRoadequipmentdepreciatedvalue, txtRoadSalvageValue, txtRoadMarketValue,
            txtDescriptionRoads, txtRemarksRoads
        }
            For Each txtBox As TextBox In roadTextBoxes
                txtBox.Text = String.Empty
            Next

        ElseIf isBridge Then
            Dim bridgeTextBoxes() As TextBox = {
            txtBridgeProjectName, txtBridgeID, txtBridgeName, txtBridgeType,
            txtBridgeLocation, txtNoofLane, txtTrafficDate, txtBridgeLfromAddress,
            txtBridgeLtoAddress, txtBridgeNorthWestWidth, txtBridgeRfromAddress,
            txtBridgeRtoAddress, txtBridgeStructureNo, txtBridgeRouteSignPrefix,
            txtBridgeRouteNo, txtBridgeFeaturedIntersected, txtBridgeMilePoint,
            txtBridgeBorderStructNo, txtBridgeRoadNo, txtBridgeNameofRiver,
            txtBridgeReferencePost, txtBridgeEndReferencePost, txtBridgeStartPosition,
            txtBridgeCurrentStation, txtBridgeContractor, txtBridgeContactPerson,
            txtBridgeCellphoneNo, txtBridgeAcqDate, txtBridgeAcqCost, txtBridgeDepRate,
            txtBridgeDepValue, txtBridgeSalvageValue, txtBridgeMarketValue,
            txtRemarks, txtDescription
        }
            For Each txtBox As TextBox In bridgeTextBoxes
                txtBox.Text = String.Empty
            Next
        End If

    End Sub

    Protected Sub grdLedger1_RowCreated(
        sender As Object,
        e As GridViewRowEventArgs
        ) Handles grdLedger1.RowCreated

        If grdLedger1.HeaderRow Is Nothing OrElse
            grdLedger1.Rows.Count = 0 Then

            Exit Sub
        End If

        If grdLedger1.Controls.Count = 0 OrElse
            grdLedger1.Controls(0).
            Controls.Count = 0 Then

            Exit Sub
        End If

        Dim headerAlreadyExists As Boolean =
            False

        For Each currentRow As GridViewRow In
            grdLedger1.Controls(0).Controls

            If currentRow.RowType =
                DataControlRowType.Header AndAlso
                currentRow.Cells.Count > 0 AndAlso
                currentRow.Cells(0).Text =
                "CONSTRUCTION IN PROGRESS" Then

                headerAlreadyExists = True
                Exit For
            End If

        Next

        If headerAlreadyExists Then
            Exit Sub
        End If

        Dim row As New GridViewRow(
            0,
            0,
            DataControlRowType.Header,
            DataControlRowState.Normal
        )

        Dim cell As New TableHeaderCell()

        cell.Text =
            "CONSTRUCTION IN PROGRESS"

        cell.ColumnSpan = 4

        cell.HorizontalAlign =
            HorizontalAlign.Center

        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "DEBIT"
        cell.ColumnSpan = 2

        cell.HorizontalAlign =
            HorizontalAlign.Center

        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "CREDIT"
        cell.ColumnSpan = 2

        cell.HorizontalAlign =
            HorizontalAlign.Center

        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "BALANCE"
        cell.ColumnSpan = 2

        cell.HorizontalAlign =
            HorizontalAlign.Center

        row.Cells.Add(cell)

        row.BackColor = Color.White
        row.ForeColor = Color.Black

        grdLedger1.Controls(0).
            Controls.AddAt(
                0,
                row
            )

    End Sub
End Class
