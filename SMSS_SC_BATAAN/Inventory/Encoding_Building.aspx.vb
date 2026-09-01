
Imports System.Data
Imports System.Drawing

Partial Class Inventory_Encoding_Building
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Dim item As New m_item
    Dim objBldgInfo As New ConsolidatedPropertySaving.TBBuilding_Details
    Private Prop_Ledger As New t_PropertyLedger


    Private Sub Inventory_Encoding_Building_Load(
    sender As Object,
    e As EventArgs) Handles Me.Load

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

            Dim classification As DataTable =
            objDerived.GetDataTable(
                "SELECT TOP (1) " &
                "    ClassificationId, " &
                "    ClassificationName " &
                "FROM dbo.tbl_Classification " &
                "WHERE isenable = 1 " &
                "AND ClassificationName LIKE '%Building%' " &
                "ORDER BY SeqNo",
                CommandType.Text
            )

            ddClass.DataSource = classification
            ddClass.DataTextField =
            "ClassificationName"

            ddClass.DataValueField =
            "ClassificationId"

            ddClass.DataBind()

            If classification IsNot Nothing AndAlso
            classification.Rows.Count > 0 Then

                ddClass.SelectedIndex = 0

                Session("ClassificationID") =
                ddClass.SelectedValue
            Else
                Session("ClassificationID") = "0"
            End If

            hdnGAId.Value = "0"
            hdnItemNo.Value = "0"

            btnSave.Text = "SAVE"

            selectClassification()

        End If

    End Sub

    Private Sub LoadGLAccounts()

        ddGA.Items.Clear()

        Dim classificationID As Integer = 0

        Integer.TryParse(
        Convert.ToString(
            Session("ClassificationID")
        ),
        classificationID
    )

        If classificationID = 0 Then

            ddGA.Items.Insert(
            0,
            New ListItem(
                "Select",
                "0"
            )
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

            ddGA.DataSource = dt
            ddGA.DataTextField =
            "GA_Title"

            ddGA.DataValueField =
            "GA_ID"

            ddGA.DataBind()

        Else

            ddGA.Items.Insert(
            0,
            New ListItem(
                "Select",
                "0"
            )
        )

        End If

        ddGA.Enabled = True

    End Sub


    Private Sub LoadSubClassifications()

        ddSubClass.Items.Clear()

        If ddGA.SelectedValue Is Nothing OrElse
        ddGA.SelectedValue = "" OrElse
        ddGA.SelectedValue = "0" Then

            ddSubClass.Items.Insert(
            0,
            New ListItem(
                "No Subclass",
                "0"
            )
        )

            ddSubClass.Enabled = True
            Exit Sub

        End If

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
            ddGA.SelectedValue
        ),
        gaID
    )

        If classificationID = 0 OrElse
        gaID = 0 Then

            ddSubClass.Items.Insert(
            0,
            New ListItem(
                "No Subclass",
                "0"
            )
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

            ddSubClass.DataSource = dt

            ddSubClass.DataTextField =
            "SubClassificationName"

            ddSubClass.DataValueField =
            "SubClassificationID"

            ddSubClass.DataBind()

        Else

            ddSubClass.Items.Insert(
            0,
            New ListItem(
                "No Subclass",
                "0"
            )
        )

        End If

        ddSubClass.Enabled = True

    End Sub

    Public Sub selectClassification()

        If ddClass.SelectedValue Is Nothing OrElse
        ddClass.SelectedValue = "" Then

            Session("ClassificationID") =
            "0"
        Else
            Session("ClassificationID") =
            ddClass.SelectedValue
        End If

        LoadGLAccounts()

        ddSubClass.Items.Clear()

        ddSubClass.Items.Insert(
        0,
        New ListItem(
            "No Subclass",
            "0"
        )
    )

        ddSubClass.Enabled = True

        hdnGAId.Value = "0"
        hdnItemNo.Value = "0"

        loadEquipmentLedger()

    End Sub


    Private Sub BindSubClassifications()
        ' Ensure ddClass has a value
        If String.IsNullOrWhiteSpace(ddClass.SelectedValue) Then
            ddSubClass.Items.Clear()
            ddSubClass.Items.Insert(0, New ListItem("-", ""))
            Return
        End If

        ' Pull sub classifications for the selected ClassificationID
        Dim sql As String =
        "SELECT SubClassificationID, SubClassificationName, ClassificationID, GA_ID " &
        "FROM dbo.tbl_SubClassification " &
        "WHERE ClassificationID = @cid " &
        "ORDER BY SubClassificationName;"

        ' (kept same style as your reference; ideally parameterize)
        Dim dt As DataTable = objDerived.GetDataTable(
        sql.Replace("@cid", ddClass.SelectedValue), CommandType.Text)

        ddSubClass.DataSource = dt
        ddSubClass.DataTextField = "SubClassificationName"
        ddSubClass.DataValueField = "SubClassificationID"  ' use unique value
        ddSubClass.DataBind()
        ddSubClass.Items.Insert(0, New ListItem("-", ""))

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ddSubClass.SelectedIndex = 1
        End If

        ' Cache for GA lookup by SubClassificationID (separate key for Building page)
        ViewState("SubClassTable_Building") = dt
    End Sub

    Private Sub BindGAAccounts()
        ' Ensure ddSubClass has a selection
        If String.IsNullOrWhiteSpace(ddSubClass.SelectedValue) Then
            ddGA.Items.Clear()
            ddGA.Items.Insert(0, New ListItem("Select", ""))
            Return
        End If

        ' Retrieve GA_ID for the selected SubClassificationID from cached table
        Dim dt As DataTable = TryCast(ViewState("SubClassTable_Building"), DataTable)
        Dim gaId As String = Nothing

        If dt IsNot Nothing Then
            Dim rows = dt.Select("SubClassificationID = " & ddSubClass.SelectedValue)
            If rows IsNot Nothing AndAlso rows.Length > 0 Then
                gaId = rows(0)("GA_ID").ToString()
            End If
        End If

        If String.IsNullOrWhiteSpace(gaId) Then
            ddGA.Items.Clear()
            ddGA.Items.Insert(0, New ListItem("Select", ""))
            Return
        End If

        ' Query GA accounts for that GA_ID
        Dim sql As String =
        "SELECT GA_ID, GA_Title " &
        "FROM geobos.dbo.view_allotmentclassaccounts " &
        "WHERE GA_ID = " & gaId & " " &
        "ORDER BY GA_Title;"

        AddTrace("gaId: " & gaId)

        Dim dtGA As DataTable = objDerived.GetDataTable(sql, CommandType.Text)

        ddGA.DataSource = dtGA
        ddGA.DataTextField = "GA_Title"
        ddGA.DataValueField = "GA_ID"
        ddGA.DataBind()
        ddGA.Items.Insert(0, New ListItem("Select", ""))

        If dtGA IsNot Nothing AndAlso dtGA.Rows.Count > 0 Then
            ddGA.SelectedIndex = 1
        End If
    End Sub


    Public Sub loadEquipmentLedger()

        Dim gaId As Long = 0

        Long.TryParse(
        Convert.ToString(
            ddGA.SelectedValue
        ),
        gaId
    )

        Dim sql As String =
        "EXEC [AMS].[PropertyLedger_GA] " &
        "    @GA_ID = " & gaId

        AddTrace(sql)

        Dim dtAccount As DataTable =
        objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        If dtAccount Is Nothing Then
            dtAccount = New DataTable()
        End If

        ' =====================================================
        ' ENSURE STORED-PROCEDURE COLUMNS
        ' =====================================================
        If Not dtAccount.Columns.Contains(
        "dDate") Then

            dtAccount.Columns.Add(
            "dDate",
            GetType(DateTime)
        )
        End If

        If Not dtAccount.Columns.Contains(
        "Trans_Type") Then

            dtAccount.Columns.Add(
            "Trans_Type",
            GetType(String)
        )
        End If

        If Not dtAccount.Columns.Contains(
        "Ref") Then

            dtAccount.Columns.Add(
            "Ref",
            GetType(String)
        )
        End If

        If Not dtAccount.Columns.Contains(
        "Property_ID") Then

            dtAccount.Columns.Add(
            "Property_ID",
            GetType(Long)
        )
        End If

        If Not dtAccount.Columns.Contains(
        "DebitQty") Then

            dtAccount.Columns.Add(
            "DebitQty",
            GetType(Integer)
        )
        End If

        If Not dtAccount.Columns.Contains(
        "DebitCost") Then

            dtAccount.Columns.Add(
            "DebitCost",
            GetType(Decimal)
        )
        End If

        If Not dtAccount.Columns.Contains(
        "CreditQty") Then

            dtAccount.Columns.Add(
            "CreditQty",
            GetType(Integer)
        )
        End If

        If Not dtAccount.Columns.Contains(
        "CreditCost") Then

            dtAccount.Columns.Add(
            "CreditCost",
            GetType(Decimal)
        )
        End If

        If Not dtAccount.Columns.Contains(
        "BalQty") Then

            dtAccount.Columns.Add(
            "BalQty",
            GetType(Integer)
        )
        End If

        If Not dtAccount.Columns.Contains(
        "BalCost") Then

            dtAccount.Columns.Add(
            "BalCost",
            GetType(Decimal)
        )
        End If

        ' =====================================================
        ' COMPATIBILITY WITH CURRENT BUILDING GRID FIELDS
        ' =====================================================
        If Not dtAccount.Columns.Contains(
        "Property_Date") Then

            dtAccount.Columns.Add(
            "Property_Date",
            GetType(DateTime)
        )
        End If

        If Not dtAccount.Columns.Contains(
        "Particulars") Then

            dtAccount.Columns.Add(
            "Particulars",
            GetType(String)
        )
        End If

        If Not dtAccount.Columns.Contains(
        "PropertyNo") Then

            dtAccount.Columns.Add(
            "PropertyNo",
            GetType(String)
        )
        End If

        For Each ledgerRow As DataRow In
        dtAccount.Rows

            If Not ledgerRow.IsNull(
            "dDate") Then

                ledgerRow("Property_Date") =
                ledgerRow("dDate")
            End If

            If Not ledgerRow.IsNull(
            "Trans_Type") Then

                ledgerRow("Particulars") =
                ledgerRow(
                    "Trans_Type"
                ).ToString()
            End If

            If Not ledgerRow.IsNull(
            "Ref") Then

                ledgerRow("PropertyNo") =
                ledgerRow(
                    "Ref"
                ).ToString()
            End If

        Next

        ' Preserve ten-row appearance.
        While dtAccount.Rows.Count < 10

            dtAccount.Rows.Add(
            dtAccount.NewRow()
        )

        End While

        grdLedger1.DataSource =
        dtAccount

        grdLedger1.DataBind()

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
        'dt.Columns.Add("SerialNo", GetType(String))
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
        '    dr("SerialNo") = DBNull.Value
        '    dr("BalCost") = DBNull.Value
        '    dt.Rows.Add(dr)
        'Next
        'Return dt


        ''Optimize code
        Dim dt As New DataTable()
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
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("BalCost", GetType(Decimal))

        For i As Integer = 0 To row
            dt.Rows.Add(dt.NewRow())
        Next

        Return dt
    End Function

    Protected Sub OnDataBound(sender As Object, e As EventArgs)

        ''Optime code
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)

        If ddGA.SelectedIndex = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a General Account.")
            Exit Sub
        End If
        If txtBuildingName.Text = "" Or txtAddress.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill up the required Fields: Name / Address")
            Exit Sub

        ElseIf btnSave.Text = "EDIT" Then
            LoadApprovalOfficer()
            txtApprovedPass.Text = ""
            ModalPopupExtender1.Show()
            DisableTextboxes(False)
            Exit Sub

        ElseIf btnSave.Text = "UPDATE" Then
            UpdateBuilding()
            btnSave.Enabled = True
            btnSave.Text = "SAVE"
            loadEquipmentLedger()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property Details are Updated Successfully")
            Exit Sub

        ElseIf btnSave.Text = "SAVE" Then

            ' Escape single quotes in text fields
            Dim escapedBuildingName As String = txtBuildingName.Text.Replace("'", "''")
            Dim escapedDescription As String = txtDescription.Text.Replace("'", "''")
            Dim escapedUnit As String = txtUnit.Text.Replace("'", "''")
            Dim escapedRemarks As String = txtRemarks.Text.Replace("'", "''")
            Dim escapedAddress As String = txtAddress.Text.Replace("'", "''")
            Dim escapedBrgy As String = txtBrgy.Text.Replace("'", "''")
            Dim escapedPropertyNo As String = txtPropertyNo.Text.Replace("'", "''")
            Dim escapedArea As String = txtArea.Text.Replace("'", "''")
            Dim escapedTaxDecNo As String = txtTaxDecNo.Text.Replace("'", "''")
            Dim escapedPrevOwner As String = txtPrevOwner.Text.Replace("'", "''")
            Dim escapedBuildingControlNo As String = txtBuildingControlNo.Text.Replace("'", "''")
            Dim escapedBuildingCode As String = txtBuildingCode.Text.Replace("'", "''")
            Dim escapedBuildingUse As String = txtBuildingUse.Text.Replace("'", "''")
            Dim escapedPostalCode As String = txtPostalCode.Text.Replace("'", "''")
            Dim escapedBuildingOccupancy As String = txtBuildingOccupancy.Text.Replace("'", "''")
            Dim escapedAvgAreaperFloor As String = txtAvgAreaperFloor.Text.Replace("'", "''")
            Dim escapedCostperArea As String = txtCostperArea.Text.Replace("'", "''")

            If txtDescription.Text Is Nothing Or txtDescription.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Description is required to be filled up")
                Exit Sub
            End If

            If txtUnit.Text Is Nothing Or txtUnit.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unit of Measurement is required to be filled up")
                Exit Sub
            End If

            If txtPropertyNo.Text Is Nothing Or txtPropertyNo.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property Number is required to be filled up")
                Exit Sub
            End If

            '=== Check if Property Number already exists ===
            If txtPropertyNo.Text.Trim() <> "" Then
                Dim existingCount As Integer = objDerived.GetValue("SELECT COUNT(*) FROM AMS.Property_Dtl WHERE PropertyNo = '" & escapedPropertyNo & "'", CommandType.Text)

                If existingCount > 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property Number already exists.")
                    Exit Sub
                End If
            End If

            ' Check if building already exists - use escaped name
            'Dim itemdesc As String = objDerived.GetValue("select * From dbo.m_item where Item_Desc = '" & escapedBuildingName & "'", CommandType.Text)
            'If itemdesc <> "" Then
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Building Already Exists")
            '    itemdesc = ""
            '    Exit Sub
            'End If

            Dim acqcost As Decimal = If(String.IsNullOrWhiteSpace(txtEAcqCost.Text),
                        0D,
                        CDec(txtEAcqCost.Text.Replace(",", "")))

            With item
                .Item_Code = ""
                .Item_Desc = txtBuildingName.Text  ' This will be handled by your DAL which should escape properly
                .Unit_ID = objDerived.GetValue("select * From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
            End With

            Dim itemid As Integer
            itemid = item.save()
            objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & acqcost & "',null", CommandType.Text)

            Dim classId As Integer = If(String.IsNullOrWhiteSpace(ddClass.SelectedValue), 0, CInt(ddClass.SelectedValue))
            Dim subClassId As Integer = If(String.IsNullOrWhiteSpace(ddSubClass.SelectedValue), 0, CInt(ddSubClass.SelectedValue))
            Dim gaid As Integer = If(String.IsNullOrWhiteSpace(ddGA.SelectedValue), 0, CInt(ddGA.SelectedValue))

            ' --- Get category (item_particular_id) for the new item ---
            Dim category As Long = Convert.ToInt64(
        objDerived.GetValue(
            "SELECT a.item_particular_id " &
            "FROM dbo.m_item AS a " &
            "INNER JOIN AMS.item_particular AS b ON a.item_particular_id = b.item_particular_id " &
            "WHERE a.Item_ID = " & itemid, CommandType.Text))

            ' --- Check if matrix row exists (now includes SubClassificationID) ---
            Dim matrix As String = Convert.ToString(
        objDerived.GetValue(
            "SELECT id FROM dbo.tblclassmatrix " &
            "WHERE classificationid = " & classId &
            " AND SubClassificationID = " & subClassId &
            " AND ga_id = " & gaid &
            " AND item_id = " & itemid, CommandType.Text))

            ' --- Insert if missing (now includes SubClassificationID) ---
            If String.IsNullOrEmpty(matrix) Then
                objDerived.Execute(
            "INSERT INTO dbo.tblclassmatrix (classificationid, SubClassificationID, ga_id, item_id, categoryid, bga_id) " &
            "VALUES (" & classId & ", " & subClassId & ", " & gaid & ", " & itemid & ", " & category & ", 0)", CommandType.Text)
            End If

            Dim Prop_Hdr As New t_property_hdr
            With Prop_Hdr
                .Property_Date = If(String.IsNullOrWhiteSpace(txtEAcqDate.Text),
                Date.Now,
                CDate(txtEAcqDate.Text))
                .Issuance = 0
                .Remarks = txtRemarks.Text
                .Emp_ID = 0
                .F_ID = 1
                .AIRDtl_ID = 0
                .deptid = 0
                .isDonated = False
                .GA_ID = gaid
                .DonationRemarks = ""
                .Qty = 1
                .Balance = 1
                .Cost = acqcost
                .Item_ID = itemid
                .Property_code = objDerived.GetValue(
                "SELECT b.GA_Code " &
                "FROM dbo.tbl_Classification AS a " &
                "INNER JOIN dbo.tblclassmatrix AS c ON a.ClassificationId = c.classificationid " &
                "INNER JOIN geobos.dbo.view_allotmentclassaccounts AS b ON c.ga_id = b.GA_ID " &
                "WHERE a.ClassificationId = " & classId, CommandType.Text)
                .RC_ID = 0
                .Function_ID = 0
                .TD_ID = 1
                .Project_ID = 0
                .Program_id = 0
                .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & itemid & "' ", CommandType.Text)
            End With

            Dim PropHdr_ID As Integer = 0
            PropHdr_ID = Prop_Hdr.save()
            Session("PropHdr_ID") = PropHdr_ID

            objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Property SET ClassificationID = '" & ddClass.SelectedValue & "',SubClassificationID = '" & ddSubClass.SelectedValue & "'  WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

            Dim Prop_Dtl As New t_property_dtl
            With Prop_Dtl
                .PropertyNo = txtPropertyNo.Text
                .Property_ID = PropHdr_ID
                .Issued = False
                .Repair = False
                .Dispose = False
                .DisposeDate = "1/1/1900"
                .IsInspectionForDisposal = False
                .InspectionDate = If(String.IsNullOrWhiteSpace(txtEAcqDate.Text),
                 Date.Now,
                 CDate(txtEAcqDate.Text))
                .F_ID = 1
                .SerialNo = " "
                .Barcode = " "
                .Amount = acqcost
                .Status = "Accepted"
                .type = "Building"
            End With

            Dim PropDtl_ID As Integer
            PropDtl_ID = Prop_Dtl.save()

            Dim marketValue As Decimal = 0D
            If Decimal.TryParse(txtEMarketValue.Text, marketValue) = False Then
                marketValue = 0D
            End If

            objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & marketValue & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

            '==== SAVE Building DETAILS - Use escaped values for text fields
            With objBldgInfo
                .BuildingId = 0
                .Property_Dtl_ID = PropDtl_ID
                .BuildingControlNo = escapedBuildingControlNo
                .BuildingCode = escapedBuildingCode
                .BuildingName = txtBuildingName.Text  ' DAL should handle escaping
                .Address = txtAddress.Text
                .PostalCode = escapedPostalCode
                Dim depRate As Decimal = 0D
                If Decimal.TryParse(lblequipmentdepreciatedRate.Text, depRate) Then
                    .BuildingDepreciationRate = depRate
                Else
                    .BuildingDepreciationRate = 0D
                End If

                .BuildingUse = escapedBuildingUse
                .BuildingOccupancy = escapedBuildingOccupancy
                .NumberFloors = txtNoofFloors.Text
                .AvgAreaFloor = escapedAvgAreaperFloor
                .CostPerArea = escapedCostperArea
                .Status_AIR = "Accepted"
                .Barangay = escapedBrgy
                .Area = escapedArea
                .TaxDeclarationNo = escapedTaxDecNo
                Dim noOfYearsVal As Long = 0
                If Long.TryParse(txtNoYears.Text, noOfYearsVal) Then
                    .NoofYears = noOfYearsVal
                Else
                    .NoofYears = 0
                End If

                Dim usefulLifeVal As Long = 0
                If Long.TryParse(txtUsefulLife.Text, usefulLifeVal) Then
                    .UsefulLife = usefulLifeVal
                Else
                    .UsefulLife = 0
                End If

                .SalvageValue = txtSalvageValue.Text
                Dim marketVal As Decimal = 0D
                If Decimal.TryParse(txtEMarketValue.Text, marketVal) Then
                    .MarketValue = marketVal
                Else
                    .MarketValue = 0D
                End If

                .BuildingDepreciationValue = If(String.IsNullOrWhiteSpace(txtequipmentdepreciatedvalue.Text),
                            0D,
                            CDec(txtequipmentdepreciatedvalue.Text.Replace(",", "")))
            End With

            Dim BuildingID As Integer
            BuildingID = objBldgInfo.save()

            ' Use escaped values for these UPDATE statements
            objDerived.GetRecords("UPDATE AMS.TbBuilding_Dtl " &
                  "SET Description = '" & escapedDescription & "', " &
                  "Unit = '" & escapedUnit & "', " &
                  "Remarks = '" & escapedRemarks & "' " &
                  "WHERE BuildingId = '" & BuildingID & "'", CommandType.Text)

            ' Escape previous owner name
            Dim escapedOwner As String = txtPrevOwner.Text.Replace("'", "''")
            objDerived.GetRecords("INSERT INTO AMS.TbBuilding_OwnerInformation (buldingid,CorporationName) VALUES ('" & BuildingID & "','" & escapedOwner & "')", CommandType.Text)

            Dim GaCode As String
            GaCode = objDerived.GetValue(
            "SELECT b.GA_Code " &
            "FROM dbo.tbl_Classification AS a " &
            "INNER JOIN dbo.tblclassmatrix AS c ON a.ClassificationId = c.classificationid " &
            "INNER JOIN geobos.dbo.view_allotmentclassaccounts AS b ON c.ga_id = b.GA_ID " &
            "WHERE a.ClassificationId = " & classId, CommandType.Text)

            '==== SAVE PROPERTY LEDGER
            With Prop_Ledger
                .Ledger_ID = 0
                objDerived.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & txtEAcqDate.Text & "', '" & GaCode & "', '" & itemid & "')", CommandType.Text)
                .SerialNo = escapedBuildingCode
                .Trans_Type = "Manual Entry"
                .dDate = If(String.IsNullOrWhiteSpace(txtEAcqDate.Text),
                Date.Now,
                CDate(txtEAcqDate.Text))
                .Ref = ""
                .AccountablePerson = ""
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = itemid
                .DebitQty = 1
                .DebitCost = acqcost
                .DebitUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .BalanceUnit = objDerived.GetValue("select AMS.m_Unit.Description From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)

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
                .BalanceCost = acqcost + CDec(Eqbalance)
                .PropertyNo = txtPropertyNo.Text
            End With

            Prop_Ledger.save()

            ' Get the Ledger_ID of the row we just inserted
            Dim ledgerId As Integer = objDerived.GetValue(
            "SELECT TOP 1 Ledger_ID FROM AMS.TbProperty_Ledger " &
            "WHERE PropertyNo = '" & escapedPropertyNo & "' " &
            "ORDER BY Ledger_ID DESC", CommandType.Text)

            AddTrace("ledgerId: " & ledgerId)
            AddTrace("PropHdr_ID: " & PropHdr_ID)

            ' Update Property_ID for the inserted Ledger_ID
            objDerived.GetRecords("UPDATE AMS.TbProperty_Ledger " &
                  "SET Property_ID = '" & PropHdr_ID & "' " &
                  "WHERE Ledger_ID = '" & ledgerId & "'", CommandType.Text)

            btnSave.Enabled = True
            btnSave.Text = "SAVE"
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            hdnItemNo.Value = itemid
            loadEquipmentLedger()
            DisableTextboxes(False)

            'ElseIf btnSave.Text = "EDIT" Or btnSave.Text = "UPDATE" Then
            '    Dim dt As New DataTable
            '    dt = objDerived.GetDataTable("SELECT approvalid,full_name  FROM ams.tbl_approval", CommandType.Text)
            '    drpApprovedOfficer.DataSource = dt
            '    drpApprovedOfficer.DataTextField = ("full_name")
            '    drpApprovedOfficer.DataValueField = ("approvalid")
            '    drpApprovedOfficer.DataSource = dt
            '    drpApprovedOfficer.DataBind()
            '    ModalPopupExtender1.Show()
            '    DisableTextboxes(False)
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
    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim officerID As String = Convert.ToString(Request.Form(drpApprovedOfficer.UniqueID))
        Dim officerPass As String = Convert.ToString(Request.Form(txtApprovedPass.UniqueID))

        If officerID = "" OrElse officerPass.Trim() = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select Approving Officer and enter Password.")
            LoadApprovalOfficer()

            If officerID <> "" AndAlso drpApprovedOfficer.Items.FindByValue(officerID) IsNot Nothing Then
                drpApprovedOfficer.SelectedValue = officerID
            End If

            ModalPopupExtender1.Show()
            Exit Sub
        End If

        Dim approved As String
        approved = objDerived.GetValue("select approvalid from ams.tbl_approval where approvalid='" & officerID & "' and npassword = '" & DecryptEncrypt(officerPass) & "'", CommandType.Text)

        If approved = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid Approving Officer / Password")

            LoadApprovalOfficer()
            If officerID <> "" AndAlso drpApprovedOfficer.Items.FindByValue(officerID) IsNot Nothing Then
                drpApprovedOfficer.SelectedValue = officerID
            End If

            ModalPopupExtender1.Show()
        Else
            btnSave.Text = "UPDATE"
            btnSave.Enabled = True
            txtApprovedPass.Text = ""
            ModalPopupExtender1.Hide()
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtApprovedPass.Text = ""
        ModalPopupExtender1.Hide()
    End Sub
    Protected Sub UpdateBuilding()

        Dim bldngID As Long = Convert.ToInt64(hdnPropertyID.Value)

        Dim propID As Long = objDerived.GetValue("Select p.Property_ID from AMS.TbBuilding_Dtl tbd INNER JOIN AMS.Property_Dtl pd On tbd.Property_Dtl_ID = pd.PropertyDetai_ID INNER JOIN AMS.Property p On p.Property_ID = pd.Property_ID where tbd.BuildingId = '" & bldngID & "' ", CommandType.Text)

        Dim propDtlID As Long = objDerived.GetValue("select PropertyDetai_ID from AMS.Property_Dtl Where Property_ID = '" & propID & "' ", CommandType.Text)

        Dim marketValue As Decimal
        Dim noOfYears As Integer
        Dim buildingDepreciationRate As Decimal
        Dim buildingDepreciationValue As Decimal
        Dim salvageValue As Decimal
        Dim costPerArea As Decimal

        ' Try parsing the numeric fields
        If Not Decimal.TryParse(txtEMarketValue.Text, marketValue) Then marketValue = 0
        If Not Integer.TryParse(txtNoYears.Text, noOfYears) Then noOfYears = 0
        If Not Decimal.TryParse(lblequipmentdepreciatedRate.Text, buildingDepreciationRate) Then buildingDepreciationRate = 0
        If Not Decimal.TryParse(txtequipmentdepreciatedvalue.Text, buildingDepreciationValue) Then buildingDepreciationValue = 0
        If Not Decimal.TryParse(txtSalvageValue.Text, salvageValue) Then salvageValue = 0
        If Not Decimal.TryParse(txtCostperArea.Text, costPerArea) Then costPerArea = 0

        ' Escape single quotes in text fields
        Dim buildingName As String = Replace(txtBuildingName.Text, "'", "''")
        Dim address As String = Replace(txtAddress.Text, "'", "''")
        Dim barangay As String = Replace(txtBrgy.Text, "'", "''")
        Dim area As String = Replace(txtArea.Text, "'", "''")
        Dim taxDecNo As String = Replace(txtTaxDecNo.Text, "'", "''")
        Dim usefulLife As String = Replace(txtUsefulLife.Text, "'", "''")
        Dim buildingControlNo As String = Replace(txtBuildingControlNo.Text, "'", "''")
        Dim buildingCode As String = Replace(txtBuildingCode.Text, "'", "''")
        Dim buildingUse As String = Replace(txtBuildingUse.Text, "'", "''")
        Dim postalCode As String = Replace(txtPostalCode.Text, "'", "''")
        Dim buildingOccupancy As String = Replace(txtBuildingOccupancy.Text, "'", "''")
        Dim numberFloors As String = Replace(txtNoofFloors.Text, "'", "''")
        Dim avgAreaFloor As String = Replace(txtAvgAreaperFloor.Text, "'", "''")
        Dim description As String = Replace(txtDescription.Text, "'", "''")
        Dim unit As String = Replace(txtUnit.Text, "'", "''")
        Dim remarks As String = Replace(txtRemarks.Text, "'", "''")
        Dim propertyNo As String = Replace(txtPropertyNo.Text, "'", "''")
        Dim prevOwner As String = Replace(txtPrevOwner.Text, "'", "''")

        ' Now update the query with the escaped values
        objDerived.GetRecords("UPDATE [AMS].[TbBuilding_Dtl] " &
                  "SET BuildingName = '" & buildingName & "', " &
                  "Address = '" & address & "', " &
                  "Barangay = '" & barangay & "', " &
                  "Area1 = '" & area & "', " &
                  "TaxDeclarationNo = '" & taxDecNo & "', " &
                  "MarketValue = " & marketValue.ToString() & ", " &
                  "NoofYears = " & noOfYears.ToString() & ", " &
                  "BuildingDepreciationRate = " & buildingDepreciationRate.ToString() & ", " &
                  "UsefuleLife = '" & usefulLife & "', " &
                  "BuildingDepreciationValue = " & buildingDepreciationValue.ToString() & ", " &
                  "SalvageValue = " & salvageValue.ToString() & ", " &
                  "BuildingControlNo = '" & buildingControlNo & "', " &
                  "BuildingCode = '" & buildingCode & "', " &
                  "BuildingUse = '" & buildingUse & "', " &
                  "PostalCode = '" & postalCode & "', " &
                  "BuildingOccupancy = '" & buildingOccupancy & "', " &
                  "NumberFloors = '" & numberFloors & "', " &
                  "AvgAreaFloor = '" & avgAreaFloor & "', " &
                  "CostPerArea = " & costPerArea.ToString() & ", " &
                  "Description = '" & description & "', " &
                  "Unit = '" & unit & "', " &
                  "Remarks = '" & remarks & "' " &
                  "WHERE BuildingId = '" & bldngID & "'", CommandType.Text)

        Dim AcqCost As Decimal

        ' Try parsing the numeric fields
        If Not Decimal.TryParse(txtEAcqCost.Text, AcqCost) Then AcqCost = 0

        ' Escape date and property number
        Dim acqDate As String = Replace(txtEAcqDate.Text, "'", "''")

        objDerived.GetRecords("Update AMS.Property Set Cost = " & AcqCost.ToString() & ", Property_Date = '" & acqDate & "' Where Property_ID = '" & propID & "'", CommandType.Text)

        objDerived.GetRecords("Update AMS.Property_Dtl Set PropertyNo = '" & propertyNo & "', Amount = " & AcqCost.ToString() & " Where Property_ID = '" & propID & "'", CommandType.Text)

        objDerived.GetRecords("Update AMS.TbBuilding_OwnerInformation Set CorporationName = '" & prevOwner & "' Where BuldingId = '" & bldngID & "'", CommandType.Text)

    End Sub

    Protected Sub cbInspection_CheckedChanged(
    ByVal sender As Object,
    ByVal e As System.EventArgs)

        ClearTextBoxes()
        DisableTextboxes(False)

        btnSave.Text = "SAVE"

        Dim selectedCheckBox As CheckBox =
        TryCast(
            sender,
            CheckBox
        )

        If selectedCheckBox Is Nothing Then
            Exit Sub
        End If

        Dim selectedRow As GridViewRow =
        TryCast(
            selectedCheckBox.NamingContainer,
            GridViewRow
        )

        If selectedRow Is Nothing Then
            Exit Sub
        End If

        ' Keep only one checked Building record.
        For Each currentRow As GridViewRow In
        grdLedger1.Rows

            Dim currentCheckBox As CheckBox =
            TryCast(
                currentRow.FindControl(
                    "cbInspection"
                ),
                CheckBox
            )

            If currentCheckBox IsNot Nothing AndAlso
            currentRow.RowIndex <>
            selectedRow.RowIndex Then

                currentCheckBox.Checked = False
            End If

        Next

        If Not selectedCheckBox.Checked Then
            hdnPropertyID.Value = ""
            Exit Sub
        End If

        Dim propertyId As Long = 0

        Long.TryParse(
        Convert.ToString(
            grdLedger1.DataKeys(
                selectedRow.RowIndex
            ).Value
        ),
        propertyId
    )

        If propertyId = 0 Then
            selectedCheckBox.Checked = False
            Exit Sub
        End If

        AddTrace(
        "Building Property_ID: " &
        propertyId
    )

        Dim sql As String =
        "SELECT TOP (1) " &
        "    bd.BuildingId, " &
        "    bd.BuildingName, " &
        "    bd.Address, " &
        "    bd.Barangay, " &
        "    pd.PropertyNo, " &
        "    bd.Description, " &
        "    bd.Unit, " &
        "    bd.Remarks, " &
        "    bd.Area1, " &
        "    bd.TaxDeclarationNo, " &
        "    oi.CorporationName, " &
        "    p.Property_Date, " &
        "    bd.MarketValue, " &
        "    p.Cost, " &
        "    bd.NoofYears, " &
        "    bd.BuildingDepreciationRate, " &
        "    bd.UsefuleLife, " &
        "    bd.BuildingDepreciationValue, " &
        "    bd.SalvageValue, " &
        "    bd.BuildingControlNo, " &
        "    bd.BuildingCode, " &
        "    bd.BuildingUse, " &
        "    bd.PostalCode, " &
        "    bd.BuildingOccupancy, " &
        "    bd.NumberFloors, " &
        "    bd.AvgAreaFloor, " &
        "    bd.CostPerArea " &
        "FROM AMS.Property AS p " &
        "INNER JOIN AMS.Property_Dtl AS pd " &
        "    ON pd.Property_ID = p.Property_ID " &
        "INNER JOIN AMS.TbBuilding_Dtl AS bd " &
        "    ON bd.Property_Dtl_ID = " &
        "       pd.PropertyDetai_ID " &
        "LEFT JOIN AMS.TbBuilding_OwnerInformation AS oi " &
        "    ON oi.BuldingId = bd.BuildingId " &
        "WHERE p.Property_ID = " &
        propertyId & " " &
        "ORDER BY " &
        "    pd.PropertyDetai_ID, " &
        "    bd.BuildingId"

        AddTrace(sql)

        Dim dt As DataTable =
        objDerived.GetDataTable(
            sql,
            CommandType.Text
        )

        If dt Is Nothing OrElse
        dt.Rows.Count = 0 Then

            selectedCheckBox.Checked = False
            Exit Sub
        End If

        Dim dataRow As DataRow =
        dt.Rows(0)

        ' Preserve UpdateBuilding(), which currently expects BuildingId.
        hdnPropertyID.Value =
        dataRow(
            "BuildingId"
        ).ToString()

        btnSave.Enabled = True
        btnSave.Text = "EDIT"

        txtBuildingName.Text =
        dataRow("BuildingName").ToString()

        txtAddress.Text =
        dataRow("Address").ToString()

        txtBrgy.Text =
        dataRow("Barangay").ToString()

        txtPropertyNo.Text =
        dataRow("PropertyNo").ToString()

        txtDescription.Text =
        dataRow("Description").ToString()

        txtUnit.Text =
        dataRow("Unit").ToString()

        txtRemarks.Text =
        dataRow("Remarks").ToString()

        txtArea.Text =
        dataRow("Area1").ToString()

        txtTaxDecNo.Text =
        dataRow(
            "TaxDeclarationNo"
        ).ToString()

        txtPrevOwner.Text =
        dataRow(
            "CorporationName"
        ).ToString()

        txtEAcqDate.Text =
        dataRow(
            "Property_Date"
        ).ToString()

        txtEMarketValue.Text =
        dataRow(
            "MarketValue"
        ).ToString()

        txtEAcqCost.Text =
        dataRow("Cost").ToString()

        txtNoYears.Text =
        dataRow(
            "NoofYears"
        ).ToString()

        lblequipmentdepreciatedRate.Text =
        dataRow(
            "BuildingDepreciationRate"
        ).ToString()

        txtUsefulLife.Text =
        dataRow(
            "UsefuleLife"
        ).ToString()

        txtequipmentdepreciatedvalue.Text =
        dataRow(
            "BuildingDepreciationValue"
        ).ToString()

        txtSalvageValue.Text =
        dataRow(
            "SalvageValue"
        ).ToString()

        txtDepreciationValue.Text =
        dataRow(
            "BuildingDepreciationValue"
        ).ToString()

        txtBuildingControlNo.Text =
        dataRow(
            "BuildingControlNo"
        ).ToString()

        txtBuildingCode.Text =
        dataRow(
            "BuildingCode"
        ).ToString()

        txtBuildingUse.Text =
        dataRow(
            "BuildingUse"
        ).ToString()

        txtPostalCode.Text =
        dataRow(
            "PostalCode"
        ).ToString()

        txtBuildingOccupancy.Text =
        dataRow(
            "BuildingOccupancy"
        ).ToString()

        txtNoofFloors.Text =
        dataRow(
            "NumberFloors"
        ).ToString()

        txtAvgAreaperFloor.Text =
        dataRow(
            "AvgAreaFloor"
        ).ToString()

        txtCostperArea.Text =
        dataRow(
            "CostPerArea"
        ).ToString()

        btnSave.Enabled = True
    End Sub
    Protected Sub ClearTextBoxes()

        txtBuildingName.Text = String.Empty
        txtAddress.Text = String.Empty
        txtBrgy.Text = String.Empty
        txtPropertyNo.Text = String.Empty

        txtArea.Text = String.Empty
        txtTaxDecNo.Text = String.Empty
        txtPrevOwner.Text = String.Empty

        txtEAcqDate.Text = String.Empty
        txtEMarketValue.Text = String.Empty
        txtEAcqCost.Text = String.Empty
        txtNoYears.Text = String.Empty
        lblequipmentdepreciatedRate.Text = String.Empty
        txtUsefulLife.Text = String.Empty
        txtequipmentdepreciatedvalue.Text = String.Empty
        txtSalvageValue.Text = String.Empty
        txtDepreciationValue.Text = String.Empty

        txtBuildingControlNo.Text = String.Empty
        txtBuildingCode.Text = String.Empty
        txtBuildingUse.Text = String.Empty
        txtPostalCode.Text = String.Empty

        txtBuildingOccupancy.Text = String.Empty
        txtNoofFloors.Text = String.Empty
        txtAvgAreaperFloor.Text = String.Empty
        txtCostperArea.Text = String.Empty
        txtDescription.Text = String.Empty
        txtUnit.Text = String.Empty
        txtRemarks.Text = String.Empty

    End Sub

    Protected Sub DisableTextboxes(boxReadOnly As Boolean)
        Dim textBoxes() As TextBox = {txtBuildingName, txtAddress, txtBrgy, txtPropertyNo, txtArea, txtTaxDecNo, txtPrevOwner, txtEAcqDate, txtEMarketValue,
            txtEAcqCost, txtNoYears, lblequipmentdepreciatedRate, txtUsefulLife, txtequipmentdepreciatedvalue, txtSalvageValue, txtDepreciationValue, txtBuildingControlNo, txtBuildingCode,
            txtBuildingUse, txtPostalCode, txtBuildingOccupancy, txtNoofFloors, txtAvgAreaperFloor, txtCostperArea, txtPropertyNo
        }

        For Each txtBox As TextBox In textBoxes
            txtBox.ReadOnly = boxReadOnly
        Next
    End Sub

    Protected Sub grdLedger1_RowCreated(
    sender As Object,
    e As GridViewRowEventArgs
    ) Handles grdLedger1.RowCreated

        If grdLedger1.HeaderRow IsNot Nothing AndAlso
        grdLedger1.Rows.Count > 0 Then

            If grdLedger1.Controls.Count > 0 AndAlso
            grdLedger1.Controls(0).
            Controls.Count > 0 Then

                Dim headerAlreadyExists As Boolean =
                False

                For Each currentRow As GridViewRow In
                grdLedger1.Controls(0).Controls

                    If currentRow.RowType =
                    DataControlRowType.Header AndAlso
                    currentRow.Cells.Count > 0 AndAlso
                    currentRow.Cells(0).Text =
                    "BUILDING" Then

                        headerAlreadyExists = True
                        Exit For
                    End If

                Next

                If Not headerAlreadyExists Then

                    Dim row As New GridViewRow(
                    0,
                    0,
                    DataControlRowType.Header,
                    DataControlRowState.Normal
                )

                    Dim cell As New TableHeaderCell()

                    cell.Text = "BUILDING"
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

                End If

            End If

        End If

    End Sub

    Protected Sub grdLedger1_RowDataBound(
    sender As Object,
    e As GridViewRowEventArgs)

        If e.Row.RowType =
        DataControlRowType.DataRow Then

            Dim propertyIdObject As Object =
            DataBinder.Eval(
                e.Row.DataItem,
                "Property_ID"
            )

            Dim propertyId As Long = 0

            If propertyIdObject IsNot Nothing AndAlso
            Not Convert.IsDBNull(
                propertyIdObject
            ) Then

                Long.TryParse(
                propertyIdObject.ToString(),
                propertyId
            )

            End If

            If propertyId = 0 Then

                Dim cbInspection As CheckBox =
                TryCast(
                    e.Row.FindControl(
                        "cbInspection"
                    ),
                    CheckBox
                )

                If cbInspection IsNot Nothing Then
                    cbInspection.Enabled = False
                End If

            End If

        End If

    End Sub


    Private Sub LoadApprovalOfficer()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT approvalid, full_name FROM ams.tbl_approval", CommandType.Text)

        drpApprovedOfficer.DataSource = dt
        drpApprovedOfficer.DataTextField = ("full_name")
        drpApprovedOfficer.DataValueField = ("approvalid")
        drpApprovedOfficer.DataBind()
    End Sub



    Protected Sub ddClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
    ) Handles ddClass.SelectedIndexChanged

        selectClassification()

    End Sub


    Protected Sub ddGA_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
    ) Handles ddGA.SelectedIndexChanged

        hdnGAId.Value =
            If(
                ddGA.SelectedValue Is Nothing,
                "0",
                ddGA.SelectedValue
            )

        hdnItemNo.Value = "0"

        LoadSubClassifications()

        loadEquipmentLedger()

        AddTrace(
            "Building ddGA: " &
            Convert.ToString(
                ddGA.SelectedValue
            )
        )

    End Sub


    Protected Sub ddSubClass_SelectedIndexChanged(
    ByVal sender As Object,
    ByVal e As EventArgs
    ) Handles ddSubClass.SelectedIndexChanged

        loadEquipmentLedger()

        AddTrace(
            "Building ddSubClass: " &
            Convert.ToString(
                ddSubClass.SelectedValue
            )
        )

    End Sub



End Class
