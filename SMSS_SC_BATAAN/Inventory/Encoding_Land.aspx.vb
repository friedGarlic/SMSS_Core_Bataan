
Imports System.Data
Imports System.Drawing

Partial Class Inventory_Encoding_Land
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Private Prop_Hdr As New t_property_hdr
    Dim item As New m_item
    Dim item_detail As New m_item_detail
    Private Prop_Dtl As New t_property_dtl
    Dim objLandDtl As New ConsolidatedPropertySaving.TBLand_Details
    Private Prop_Ledger As New t_PropertyLedger



    Private Sub Inventory_Encoding_Land_Load(sender As Object, e As EventArgs) Handles Me.Load
        objx.GetAccessRight(Me.Session("@UserName"), Page)
        If objx.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then

            Dim Classification As New DataTable
            Classification = objDerived.GetDataTable("SELECT TOP (1) PERCENT a.ClassificationId, a.ClassificationName " &
                                          "FROM dbo.tbl_Classification AS a LEFT JOIN " &
                                          "dbo.tblclassmatrix AS b ON a.ClassificationId = b.classificationid " &
                                          "WHERE a.isenable = 1 AND a.ClassificationName LIKE '%land' " &
                                          "GROUP BY a.ClassificationId, a.ClassificationName, a.SeqNo " &
                                          "ORDER BY a.SeqNo", CommandType.Text)


            ddClass.DataSource = CType(Classification, DataTable)
            ddClass.DataTextField = "ClassificationName"
            ddClass.DataValueField = "ClassificationId"
            ddClass.DataBind()

            If Classification IsNot Nothing AndAlso Classification.Rows.Count > 0 Then

                ddClass.SelectedIndex = 0
                Session("ClassificationID") = ddClass.SelectedValue

            Else

                Session("ClassificationID") = "0"

            End If

            selectClassification()
            BindGAAccounts()
            ClassAndSubText()

            ddBrgy1.DataSource = objDerived.GetDataTable("Select * from dbo.tbl_Brgy_Invent", CommandType.Text)
            ddBrgy1.DataTextField = ("Brgy_Name")
            ddBrgy1.DataValueField = ("Brgy_ID")
            ddBrgy1.DataBind()
            ddBrgy1.Items.Insert(0, "Select")

            btnLandSave.Text = "SAVE"

            loadLandLedger()

        End If

    End Sub


    ' === Helpers to bind the dropdowns ===
    Private Sub BindSubClassifications()
        If String.IsNullOrWhiteSpace(ddClass.SelectedValue) Then
            ddSubClass.Items.Clear()
            ddSubClass.Items.Insert(0, New ListItem("No Subclass", ""))
            Return
        End If

        Dim sql As String =
        "SELECT SubClassificationID, SubClassificationName, ClassificationID, GA_ID " &
        "FROM dbo.tbl_SubClassification " &
        "WHERE ClassificationID = @cid " &
        "ORDER BY SubClassificationName;"

        Dim dt As DataTable = objDerived.GetDataTable(
        sql.Replace("@cid", ddClass.SelectedValue), CommandType.Text) ' (ideally parameterize)

        ddSubClass.DataSource = dt
        ddSubClass.DataTextField = "SubClassificationName"
        ddSubClass.DataValueField = "SubClassificationID"   ' <-- unique value
        ddSubClass.DataBind()
        ddSubClass.Items.Insert(0, New ListItem("No Subclass", ""))

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ddSubClass.SelectedIndex = 1
        End If

        ' Keep a lookup for GA_ID by SubClassificationID to avoid requerying
        ViewState("SubClassTable") = dt
    End Sub

    Private Sub BindGAAccounts()

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
        "    GA_ID, " &
        "    GA_Title " &
        "FROM dbo.vw_AccountWithClass " &
        "WHERE ClassificationID = " & classificationID & " " &
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

    Public Sub ClassAndSubText()

        If ddClass.SelectedItem IsNot Nothing Then

            txtClassification.Text =
        ddClass.SelectedItem.Text

        Else

            txtClassification.Text = ""

        End If

        txtClassification.ReadOnly = True

        If ddSubClass.SelectedItem IsNot Nothing AndAlso
       ddSubClass.SelectedValue IsNot Nothing AndAlso
       ddSubClass.SelectedValue <> "" AndAlso
       ddSubClass.SelectedValue <> "0" Then

            txtSubClass.Text =
        ddSubClass.SelectedItem.Text

        Else

            txtSubClass.Text = ""

        End If

        txtSubClass.ReadOnly = True

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
    "    ga.GA_Title " &
    "FROM dbo.tbl_SubClassification AS sc " &
    "INNER JOIN dbo.view_Accntg_gen_accnt AS ga " &
    "    ON ga.GA_ID = sc.GA_ID " &
    "WHERE sc.ClassificationID = " & classificationID & " " &
    "ORDER BY ga.GA_Title"

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


    Private Sub LoadSubClassifications()

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
    Convert.ToString(ddGA.SelectedValue),
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

            ddSubClass.DataSource = dt
            ddSubClass.DataTextField = "SubClassificationName"
            ddSubClass.DataValueField = "SubClassificationID"
            ddSubClass.DataBind()

        Else

            ddSubClass.Items.Insert(
        0,
        New ListItem("No Subclass", "0")
    )

        End If

        ddSubClass.Enabled = True

    End Sub

    ' === Event wiring ===
    Protected Sub ddClass_SelectedIndexChanged(
        ByVal sender As Object,
        ByVal e As EventArgs
        ) Handles ddClass.SelectedIndexChanged

        selectClassification()

    End Sub



    Protected Sub ddSubClass_SelectedIndexChanged(
        ByVal sender As Object,
        ByVal e As EventArgs
        ) Handles ddSubClass.SelectedIndexChanged

        ClassAndSubText()
        loadLandLedger()

        AddTrace(
            "ddSubClass: " &
            Convert.ToString(ddSubClass.SelectedValue)
        )

    End Sub
    Protected Sub ddGA_SelectedIndexChanged(
        ByVal sender As Object,
        ByVal e As EventArgs
        ) Handles ddGA.SelectedIndexChanged

        hdnGAId.Value = If(
            ddGA.SelectedValue Is Nothing,
            "0",
            ddGA.SelectedValue
        )

        hdnItemNo.Value = "0"

        LoadSubClassifications()

        ClassAndSubText()
        loadLandLedger()

        AddTrace(
            "ddGA: " &
            Convert.ToString(ddGA.SelectedValue)
        )

    End Sub


    Public Sub selectClassification()

        If ddClass.SelectedValue Is Nothing OrElse
       ddClass.SelectedValue = "" Then

            Session("ClassificationID") = "0"

        Else

            Session("ClassificationID") = ddClass.SelectedValue

        End If

        LoadGLAccounts()

        ddSubClass.Items.Clear()
        ddSubClass.Items.Insert(
    0,
    New ListItem("No Subclass", "0")
)

        ddSubClass.Enabled = True

        hdnGAId.Value = "0"
        hdnItemNo.Value = "0"

        ClassAndSubText()
        loadLandLedger()

    End Sub

    'Protected Sub ddClass_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    selectClassification()
    'End Sub

    'Protected Sub OnDataBound(sender As Object, e As EventArgs)
    '    Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
    '    Dim cell As New TableHeaderCell()
    '    cell.Text = "LAND"
    '    cell.ColumnSpan = 4
    '    cell.BorderWidth = 2
    '    cell.BorderColor = ColorTranslator.FromHtml("#12306b")
    '    row.Controls.Add(cell)

    '    cell = New TableHeaderCell()
    '    cell.ColumnSpan = 1
    '    cell.Text = "DEBIT"
    '    cell.BorderWidth = 2
    '    cell.BorderColor = ColorTranslator.FromHtml("#12306b")
    '    row.Controls.Add(cell)


    '    cell = New TableHeaderCell()
    '    cell.ColumnSpan = 1
    '    cell.Text = "CREDIT"
    '    cell.BorderWidth = 2
    '    cell.BorderColor = ColorTranslator.FromHtml("#12306b")
    '    row.Controls.Add(cell)


    '    cell = New TableHeaderCell()
    '    cell.ColumnSpan = 1
    '    cell.Text = "BALANCE"
    '    cell.BorderWidth = 2
    '    cell.BorderColor = ColorTranslator.FromHtml("#12306b")
    '    row.Controls.Add(cell)

    '    row.BackColor = ColorTranslator.FromHtml("WHITE")
    '    row.ForeColor = ColorTranslator.FromHtml("#12306b")

    '    grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)
    'End Sub

    Public Sub loadLandLedger()

        Dim gaId As Long = 0

        Long.TryParse(
        Convert.ToString(ddGA.SelectedValue),
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
        ' ENSURE THE NEW STORED-PROCEDURE COLUMNS EXIST
        ' =====================================================
        If Not dtAccount.Columns.Contains("dDate") Then
            dtAccount.Columns.Add(
            "dDate",
            GetType(DateTime)
        )
        End If

        If Not dtAccount.Columns.Contains("Trans_Type") Then
            dtAccount.Columns.Add(
            "Trans_Type",
            GetType(String)
        )
        End If

        If Not dtAccount.Columns.Contains("Ref") Then
            dtAccount.Columns.Add(
            "Ref",
            GetType(String)
        )
        End If

        If Not dtAccount.Columns.Contains("Property_ID") Then
            dtAccount.Columns.Add(
            "Property_ID",
            GetType(Long)
        )
        End If

        If Not dtAccount.Columns.Contains("DebitQty") Then
            dtAccount.Columns.Add(
            "DebitQty",
            GetType(Integer)
        )
        End If

        If Not dtAccount.Columns.Contains("DebitCost") Then
            dtAccount.Columns.Add(
            "DebitCost",
            GetType(Decimal)
        )
        End If

        If Not dtAccount.Columns.Contains("CreditQty") Then
            dtAccount.Columns.Add(
            "CreditQty",
            GetType(Integer)
        )
        End If

        If Not dtAccount.Columns.Contains("CreditCost") Then
            dtAccount.Columns.Add(
            "CreditCost",
            GetType(Decimal)
        )
        End If

        If Not dtAccount.Columns.Contains("BalQty") Then
            dtAccount.Columns.Add(
            "BalQty",
            GetType(Integer)
        )
        End If

        If Not dtAccount.Columns.Contains("BalCost") Then
            dtAccount.Columns.Add(
            "BalCost",
            GetType(Decimal)
        )
        End If

        ' =====================================================
        ' COMPATIBILITY WITH THE EXISTING GRIDVIEW FIELD NAMES
        ' =====================================================
        If Not dtAccount.Columns.Contains("Property_Date") Then
            dtAccount.Columns.Add(
            "Property_Date",
            GetType(DateTime)
        )
        End If

        If Not dtAccount.Columns.Contains("Particulars") Then
            dtAccount.Columns.Add(
            "Particulars",
            GetType(String)
        )
        End If

        If Not dtAccount.Columns.Contains("PropertyNo") Then
            dtAccount.Columns.Add(
            "PropertyNo",
            GetType(String)
        )
        End If

        For Each ledgerRow As DataRow In dtAccount.Rows

            If Not ledgerRow.IsNull("dDate") Then
                ledgerRow("Property_Date") =
                ledgerRow("dDate")
            End If

            If Not ledgerRow.IsNull("Trans_Type") Then
                ledgerRow("Particulars") =
                ledgerRow("Trans_Type").ToString()
            End If

            If Not ledgerRow.IsNull("Ref") Then
                ledgerRow("PropertyNo") =
                ledgerRow("Ref").ToString()
            End If

        Next

        ' =====================================================
        ' PRESERVE THE EXISTING TEN-ROW GRID APPEARANCE
        ' =====================================================
        While dtAccount.Rows.Count < 10

            Dim blankRow As DataRow =
            dtAccount.NewRow()

            dtAccount.Rows.Add(blankRow)

        End While

        grdLedger1.DataSource =
        dtAccount

        grdLedger1.DataBind()

    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub


    Public Function createdatatableledger(ByVal row As Integer) As DataTable
        'Optimize Code
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add(New DataColumn("dDate", GetType(Date)))
        dt.Columns.Add(New DataColumn("Trans_Type", GetType(String)))
        dt.Columns.Add(New DataColumn("ref", GetType(String)))
        dt.Columns.Add(New DataColumn("AccountablePerson", GetType(String)))
        dt.Columns.Add(New DataColumn("Department", GetType(String)))
        dt.Columns.Add(New DataColumn("position", GetType(String)))
        dt.Columns.Add(New DataColumn("acceptedby", GetType(String)))
        dt.Columns.Add(New DataColumn("inspectedby", GetType(String)))
        dt.Columns.Add(New DataColumn("DebitQty", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DebitUnit", GetType(String)))
        dt.Columns.Add(New DataColumn("DebitCost", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("CreditQty", GetType(Integer)))
        dt.Columns.Add(New DataColumn("CreditUnit", GetType(String)))
        dt.Columns.Add(New DataColumn("CreditCost", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("BalQty", GetType(Integer)))
        dt.Columns.Add(New DataColumn("BalanceUnit", GetType(String)))
        dt.Columns.Add(New DataColumn("BalCost", GetType(Decimal)))

        dt.BeginLoadData()

        Dim values() As Object = {DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value}

        For i As Integer = 0 To row
            dr = dt.Rows.Add()
            dr.ItemArray = values
        Next

        dt.EndLoadData()

        Return dt
    End Function
    Public Sub SaveRecord()
        With item
            .Item_Code = ""
            .Item_Desc = txtLocation.Text
            .Unit_ID = objDerived.GetValue("select * From ams.m_Unit where Description like '%Square Meter%'", CommandType.Text)
            .ClassificationID = 7
        End With
        'item.save()
        Dim itemid As Integer

        If btnLandSave.Text = "SAVE" Then
            itemid = item.save()
        Else
            itemid = item.saveEditItem()

        End If

        objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & Val(txtAcqCost.Text) & "',null", CommandType.Text)

        'Dim classification As String = objDerived.GetValue("select  a.ClassificationId From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Land%'", CommandType.Text)
        'Dim gaid As Integer = objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Land%' ", CommandType.Text)

        ' Strongly type ids
        ' Safely parse dropdowns; default to 0 if Nothing, empty, or non-numeric
        Dim classificationId As Integer = 0
        Integer.TryParse(Convert.ToString(ddClass.SelectedValue), classificationId)

        Dim subclassificationId As Integer = 0
        Integer.TryParse(Convert.ToString(ddSubClass.SelectedValue), subclassificationId)

        Dim gaId As Integer = 0
        Integer.TryParse(Convert.ToString(ddGA.SelectedValue), gaId)


        ' item_particular_id is BIGINT -> use Long
        Dim category As Long = Convert.ToInt64(
            objDerived.GetValue(
                "SELECT a.item_particular_id " &
                "FROM dbo.m_item AS a " &
                "INNER JOIN AMS.item_particular AS b ON a.item_particular_id = b.item_particular_id " &
                "WHERE a.Item_ID = " & itemid,
                CommandType.Text
            )
        )

        ' FIXED: spacing + no quotes around INTs, schema prefix, and all spaces around ANDs
        Dim matrix As String = Convert.ToString(
            objDerived.GetValue(
                "SELECT id " &
                "FROM dbo.tblclassmatrix " &
                "WHERE classificationid = " & classificationId &
                " AND ga_id = " & gaId &
                " AND SubClassificationID = " & subclassificationId &
                " AND item_id = " & itemid,
                CommandType.Text
            )
        )

        If String.IsNullOrEmpty(matrix) Then
            objDerived.Execute(
        "INSERT INTO dbo.tblclassmatrix (classificationid, SubClassificationID, ga_id, item_id, categoryid, bga_id) " &
        "VALUES (" & classificationId & ", " & subclassificationId & ", " & gaId & ", " & itemid & ", " & category & ", 0)",
        CommandType.Text
    )
        End If


        With Prop_Hdr
            '.Property_ID = Property_ID
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
            '.GA_ID = objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Land%' ", CommandType.Text)
            .GA_ID = gaId
            .DonationRemarks = ""
            .Qty = 1
            .Balance = 1
            .Cost = If(String.IsNullOrWhiteSpace(txtAcqCost.Text),
               0D,
               CDec(txtAcqCost.Text.Replace(",", "")))
            .Item_ID = itemid
            .Property_code = objDerived.GetValue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Land%' ", CommandType.Text)
            .RC_ID = 0
            .Function_ID = 0
            .TD_ID = 1
            .Project_ID = 0
            .Program_id = 0
            .Particular = ""
        End With

        Dim PropHdr_ID As Integer

        If btnLandSave.Text = "SAVE" Then
            PropHdr_ID = Prop_Hdr.save()
        Else
            PropHdr_ID = Prop_Hdr.update()
        End If

        objDerived.GetRecords("UPDATE AMS.Property SET ClassificationID = '" & ddClass.SelectedValue & "',SubClassificationID = '" & ddSubClass.SelectedValue & "'  WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)




        Dim GaCode As String
        GaCode = objDerived.GetValue("select GA_Code  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationId = '" & classificationId & "' ", CommandType.Text)

        '==== SAVE PROPERTY DETAILS
        With Prop_Dtl
            '.PropertyDetai_ID = 0
            '.PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & txtEAcqDate.Text & "', '" & GaCode & "', '" & itemid & "')", CommandType.Text)
            .PropertyNo = txtPropertyNumber.Text
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
            .SerialNo = ""
            .Barcode = ""
            .Amount = If(String.IsNullOrWhiteSpace(txtAcqCost.Text),
             0D,
             CDec(txtAcqCost.Text.Replace(",", "")))

            .Status = "Accepted"
            .type = "Land"
        End With

        Dim PropDtl_ID As Integer

        If btnLandSave.Text = "SAVE" Then
            PropDtl_ID = Prop_Dtl.save()
        Else
            PropDtl_ID = Prop_Dtl.update()

        End If

        '==== SAVE LAND DETAILS
        With objLandDtl
            '.LandId = LandId
            .Property_Dtl_ID = PropDtl_ID
            .LguCode = txtLGUCode.Text
            .SectionNo = txtSectionNo.Text
            .PIN = txtPIN.Text
            .TDN = txtTDN.Text
            .DistrictCode = txtDistrictCode.Text
            .ParcelNo = txtParcelNo.Text
            .ARP = txtARP.Text
            .CityMunCode = txtCityCode.Text
            .SeriesNo = txtSeriesNo.Text
            .RevYear = txtRevYear.Text
            .BarangayCode = txtBrgyCode.Text
            .RPTIN = txtRPTIN.Text
            .DepreciationRate = IIf(txtDepRate.Text = "", 0, txtDepRate.Text)
            .DepreciationValue = IIf(txtDepValue.Text = "", 0, txtDepValue.Text)
            .LotNo = txtLotNo.Text
            .BlkNo = txtBlkNo.Text
            .StreetName = txtStreet.Text
            .Subdivision = txtSubdivision.Text
            .PhaseNo = txtPhaseNo.Text
            .Purok = txtPurok.Text
            .Sitio = txtSitio.Text
            .Barangay = txtBrgy.Text
            .District = txtDistrict.Text
            .CityMunicipal = txtCityMun.Text
            .Province = txtProvince.Text
            .Region = TxtRegion.Text
            .ZipCode = txtZipCode.Text
            .Classification = txtClassification.Text
            .SubClass = txtSubClass.Text
            .LandUse = txtLandUse.Text
            .Area = txtSubClassArea.Text
            '.AVAmountWords = txtLandAssessedAmount.Text
            '.MVAmountWords = txtMarketValue.Text
            .AssessmentLevel = TextBox3.Text
            .Status_1 = txtStatus.Text
            .Status_2 = TxtStatus1.Text
            .AssessedValue = IIf(txtAssessedValue.Text = "", 0, txtAssessedValue.Text.Replace(",", ""))
            .MarketValue = IIf(txtCharacteristicsMarketValue.Text = "", 0, txtCharacteristicsMarketValue.Text.Replace(",", ""))
            .UnitValue = IIf(txtUnitValue.Text = "", 0, txtUnitValue.Text.Replace(",", ""))
            .Taxable = txtTaxable.Text
            .AssessedDate = IIf(txtAssessedValueDate.Text = "", Date.Now, txtAssessedValueDate.Text)
            .MarketDate = IIf(txtMarketValueDate.Text = "", Date.Now, txtMarketValueDate.Text)
            .UnitDate = IIf(txtUnitValueDate.Text = "", Date.Now, txtUnitValueDate.Text.Replace(",", ""))
            '.Received_ID = rcvID
            .TaxDeclarationNo = ddTaxDecNo.SelectedItem.Text
            .AcqMode = txtAcqMode.Text
            .FullAddress = txtLocation.Text
            .Barangay1 = ddBrgy1.SelectedItem.Text
            .Area1 = txtArea.Text
            .MarketValue1 = IIf(txtMarketValue.Text.Replace(",", "") = "", 0, txtMarketValue.Text.Replace(",", ""))
            .AVAmount = IIf(txtAssessedValueAmount.Text = "", 0, txtAssessedValueAmount.Text.Replace(",", ""))
            .MVAmount = IIf(txtMarketValueAmount.Text = "", 0, txtMarketValueAmount.Text.Replace(",", ""))


        End With

        Dim LandDtl_ID As Integer
        If btnLandSave.Text = "SAVE" Then
            LandDtl_ID = objLandDtl.save()
        Else
            LandDtl_ID = objLandDtl.update()
        End If

        '==== UPDATE NEW GENERAL DETAILS COLUMNS
        Dim updateGeneralDetails As String =
        "UPDATE AMS.TbLand_Dtl SET " &
        "Description = '" & txtDescription.Text.Replace("'", "''") & "', " &
        "Property_No = '" & txtPropertyNumber.Text.Replace("'", "''") & "', " &
        "Unit = '" & txtUnit.Text.Replace("'", "''") & "', " &
        "Remarks = '" & txtRemarks.Text.Replace("'", "''") & "' " &
        "WHERE LandId = " & LandDtl_ID

        objDerived.GetRecords(updateGeneralDetails, CommandType.Text)



        Dim acqYear As Integer = If(String.IsNullOrWhiteSpace(txtEAcqDate.Text),
                            Date.Now.Year,
                            Year(CDate(txtEAcqDate.Text)))

        objDerived.GetRecords("INSERT INTO AMS.TbLand_OwnerHistory (LandId,OwnerName,Year) " &
                      "VALUES ('" & LandDtl_ID & "','" & txtPrevOwner.Text & "','" & acqYear & "')",
                      CommandType.Text)


        '==== SAVE PROPERTY LEDGER
        With Prop_Ledger
            .Ledger_ID = 0
            objDerived.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & txtEAcqDate.Text & "', '" & GaCode & "', '" & itemid & "')", CommandType.Text)
            .SerialNo = ""
            .Trans_Type = "Manual Entry"
            .dDate = If(String.IsNullOrWhiteSpace(txtEAcqDate.Text),
            Date.Now,
            CDate(txtEAcqDate.Text))
            .Property_ID = PropHdr_ID
            .Ref = ""
            .AccountablePerson = "" 'ddSupplier.SelectedItem.Text
            .Department = ""
            .Position = ""
            .AcceptedBy = "" 'ddacceptedby.SelectedItem.Text
            .InspectedBy = "" 'ddInspectedby.SelectedItem.Text
            .Item_ID = itemid
            .DebitQty = 1
            .DebitCost = If(String.IsNullOrWhiteSpace(txtAcqCost.Text),
                0D,
                CDec(txtAcqCost.Text.Replace(",", "")))

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
            .BalanceCost = If(String.IsNullOrWhiteSpace(txtAcqCost.Text),
                  0D,
                  CDec(txtAcqCost.Text.Replace(",", ""))) + CDec(Eqbalance)



        End With

        If btnLandSave.Text = "SAVE" Then
            Prop_Ledger.save()
        Else
            Prop_Ledger.update()
        End If



        btnLandSave.Enabled = False
        hdnItemNo.Value = itemid
        loadLandLedger()

        btnLandSave.Text = "SAVE"

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
    End Sub

    Public Sub UpdateRecord()

        Dim propID As Long = Convert.ToInt64(hdnPropertyID.Value)

        Dim landDtlID As Long = objDerived.GetValue("select td.LandId FROM AMS.Property p INNER JOIN AMS.Property_Dtl pd ON p.Property_ID = pd.Property_ID INNER JOIN AMS.TbLand_Dtl td ON pd.PropertyDetai_ID = td.Property_Dtl_ID where p.Property_ID = '" & propID & "'", CommandType.Text)

        objDerived.GetRecords(
                "UPDATE [AMS].[TbLand_Dtl] " &
                "SET FullAddress = '" & txtLocation.Text & "', " &
                    "TaxDeclarationNo = '" & ddTaxDecNo.SelectedValue() & "', " &
                    "Barangay1 = '" & If(ddBrgy1.SelectedItem IsNot Nothing, ddBrgy1.SelectedItem.Text.Replace("'", "''"), String.Empty) & "', " &
                    "Area1 = '" & txtArea.Text & "', " &
                    "UnitDate = '" & txtEAcqDate.Text & "', " &
                    "AcqMode = '" & txtAcqMode.Text & "', " &
                    "MarketValue1 = '" & txtMarketValue.Text & "', " &
                    "LguCode = '" & txtLGUCode.Text & "', " &
                    "DistrictCode = '" & txtDistrictCode.Text & "', " &
                    "CityMunCode = '" & txtCityCode.Text & "', " &
                    "BarangayCode = '" & txtBrgyCode.Text & "', " &
                    "SectionNo = '" & txtSectionNo.Text & "', " &
                    "ParcelNo = '" & txtParcelNo.Text & "', " &
                    "SeriesNo = '" & txtSeriesNo.Text & "', " &
                    "RPTIN = '" & txtRPTIN.Text & "', " &
                    "PIN = '" & txtPIN.Text & "', " &
                    "ARP = '" & txtARP.Text & "', " &
                    "TDN = '" & txtTDN.Text & "', " &
                    "RevYear = '" & txtRevYear.Text & "', " &
                    "DepreciationRate = '" & txtDepRate.Text & "', " &
                    "DepreciationValue = '" & txtDepValue.Text & "', " &
                    "LotNo = '" & txtLotNo.Text & "', " &
                    "StreetName = '" & txtStreet.Text & "', " &
                    "Purok = '" & txtPurok.Text & "', " &
                    "PhaseNo = '" & txtPhaseNo.Text & "', " &
                    "BlkNo = '" & txtBlkNo.Text & "', " &
                    "Sitio = '" & txtSitio.Text & "', " &
                    "Barangay = '" & txtBrgy.Text & "', " &
                    "CityMunicipal = '" & txtCityMun.Text & "', " &
                    "Region = '" & TxtRegion.Text & "', " &
                    "District = '" & txtDistrict.Text & "', " &
                    "Province = '" & txtProvince.Text & "', " &
                    "ZipCode = '" & txtZipCode.Text & "', " &
                    "Classification = '" & txtClassification.Text & "', " &
                    "SubClass = '" & txtSubClass.Text & "', " &
                    "LandUse = '" & txtLandUse.Text & "', " &
                    "Taxable = '" & txtTaxable.Text & "', " &
                    "Area = '" & txtSubClassArea.Text & "', " &
                    "AssessedValue = '" & txtAssessedValue.Text & "', " &
                    "MarketValue = '" & txtCharacteristicsMarketValue.Text & "', " &
                    "UnitValue = '" & txtUnitValue.Text & "', " &
                    "AssessedDate = '" & txtAssessedValueDate.Text & "', " &
                    "MarketDate = '" & txtMarketValueDate.Text & "', " &
                    "AVAmount = '" & txtAssessedValueAmount.Text & "', " &
                    "MVAmount = '" & txtMarketValueAmount.Text & "' " &
                "WHERE AMS.TbLand_Dtl.LandId = '" & landDtlID & "' ",
                CommandType.Text)


        '==== UPDATE NEW GENERAL DETAILS COLUMNS
        Dim updateGeneralDetails As String =
            "UPDATE AMS.TbLand_Dtl SET " &
            "Description = '" & txtDescription.Text.Replace("'", "''") & "', " &
            "Property_No = '" & txtPropertyNumber.Text.Replace("'", "''") & "', " &
            "Unit = '" & txtUnit.Text.Replace("'", "''") & "', " &
            "Remarks = '" & txtRemarks.Text.Replace("'", "''") & "' " &
            "WHERE LandId = " & landDtlID

        objDerived.GetRecords(updateGeneralDetails, CommandType.Text)


        objDerived.GetRecords("UPDATE [AMS].[TbLand_OwnerHistory] SET OwnerName ='" & txtPrevOwner.Text & "' where LandId = '" & landDtlID & "'", CommandType.Text)

        'DROPDOWNS
    End Sub

    Protected Sub btnLandSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If ddGA.SelectedIndex = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a General Account.")
            Exit Sub
        End If


        If txtLocation.Text Is Nothing Or txtLocation.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Address is required to be filled up")

            Exit Sub
        End If


        If txtEAcqDate.Text Is Nothing Or txtLocation.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Acquisition Date is required to be filled up")

            Exit Sub
        End If

        If txtAcqCost.Text Is Nothing Or txtLocation.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Acquisition Cost is required to be filled up")

            Exit Sub
        End If

        If txtDescription.Text Is Nothing Or txtDescription.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Description is required to be filled up")

            Exit Sub
        End If

        If txtUnit.Text Is Nothing Or txtUnit.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unit of Measurement is required to be filled up")

            Exit Sub
        End If

        If txtPropertyNumber.Text Is Nothing Or txtPropertyNumber.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property Number is required to be filled up")

            Exit Sub
        End If

        'If ddSubClass.SelectedIndex = 0 Or ddGA.SelectedIndex = 0 Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a Sub Classification and General Account.")

        '    Exit Sub
        'End If

        '=== Check if Property Number already exists ===
        If btnLandSave.Text = "SAVE" Then
            If txtPropertyNumber.Text.Trim() <> "" Then
                Dim existingCount As Integer = objDerived.GetValue("SELECT COUNT(*) FROM AMS.Property_Dtl WHERE PropertyNo = '" & txtPropertyNumber.Text.Replace("'", "''") & "'", CommandType.Text)

                If existingCount > 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property Number already exists.")
                    Exit Sub
                End If
            End If
        End If



        'If txtRemarks.Text Is Nothing Or txtRemarks.Text = "" Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Remarks are required to be filled up")

        '    Exit Sub
        'End If




        If btnLandSave.Text = "SAVE" Then
            Call SaveRecord() 'UPDATE FUNC IS INSDE
        ElseIf btnLandSave.Text = "UPDATE" Then
            UpdateRecord()


            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Land Property Details are Updated Successfully")
        ElseIf btnLandSave.Text = "EDIT" Then
            LoadApprovalOfficer()
            txtApprovedPass.Text = ""
            ModalPopupExtender1.Show()
            Exit Sub
        End If
        btnLandSave.Enabled = False
    End Sub



    Protected Sub txtArea_TextChanging(sender As Object, e As EventArgs)

    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)

    End Sub
    Protected Sub ddTaxDecNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddTaxDecNo.SelectedIndexChanged

    End Sub

    Protected Sub cbInspection_CheckedChanged(sender As Object, e As EventArgs)
        Dim cb1 As CheckBox

        ClearTextBox()

        Dim textBoxes() As TextBox = {txtArea, txtLocation, txtPrevOwner, txtEAcqDate, txtAcqCost, txtAcqMode, txtMarketValue, txtLGUCode, txtDistrictCode,
            txtCityCode, txtBrgyCode, txtSectionNo, txtParcelNo, txtSeriesNo, txtRPTIN, txtPIN, txtARP, txtTDN,
            txtRevYear, txtDepRate, txtDepValue, txtLotNo, txtStreet, txtPurok, txtPhaseNo, txtBlkNo, txtSitio, txtBrgy, txtCityMun, TxtRegion, txtDistrict, txtProvince, txtZipCode, txtClassification,
            txtSubClass, txtLandUse, txtTaxable, txtSubClassArea, txtAssessedValue, txtCharacteristicsMarketValue, txtUnitValue, txtAssessedValueDate, txtMarketValueDate, txtUnitValueDate, txtAssessedValueAmount, txtMarketValueAmount
        }

        For Each txtBox As TextBox In textBoxes
            txtBox.ReadOnly = False
        Next

        For i As Integer = 0 To grdLedger1.Rows.Count - 1
            cb1 = CType(Me.grdLedger1.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)

            If cb1.Visible AndAlso cb1.Checked Then
                btnLandSave.Enabled = True
                btnLandSave.Text = "EDIT"

                'TODO display textbox checked event fired on notepad ref.

                'Dim dt2 As DataTable = objDerived.GetDataTable("SELECT TOP (1) * FROM AMS.TBSupplies_Info AS a WHERE  (ItemId = '" & hdnItemNo.Value & "')  AND (StockID = '" & dt.Rows(xa).Item("StockID").ToString() & "') ", CommandType.Text)
                'grdLedger1.SelectedDataKey("Property_ID")
                'txtSizeMed.Text = dt2.Rows(0).Item("Size").ToString()

                Dim chk As CheckBox = CType(sender, CheckBox)
                Dim row As GridViewRow = CType(chk.NamingContainer, GridViewRow)

                ' Read DataKey directly
                Dim propID As Long = grdLedger1.DataKeys(row.RowIndex).Value
                AddTrace("propID: " & propID)
                hdnPropertyID.Value = grdLedger1.DataKeys(row.RowIndex).Value.ToString()

                Dim dt1 As DataTable = objDerived.GetDataTable(
                "SELECT (td.FullAddress + '-' + td.Barangay) AS Address, " &
                "td.TaxDeclarationNo, td.Area, oh.OwnerName, td.UnitDate, pd.Amount, td.AcqMode, td.MarketValue1, " &
                "td.LguCode, td.DistrictCode, td.CityMunCode, td.BarangayCode, td.SectionNo, " &
                "td.ParcelNo, td.SeriesNo, td.RPTIN, td.PIN, td.ARP, td.TDN, " &
                "td.RevYear, td.DepreciationRate, td.DepreciationValue, " &
                "td.LotNo, td.StreetName, td.Purok, td.PhaseNo, td.BlkNo, td.Sitio, td.Barangay, td.CityMunicipal, " &
                "td.Region, td.District, td.Province, td.ZipCode, td.Classification, td.SubClass, td.LandUse, td.Taxable, td.Area1, " &
                "td.AssessedValue, td.MarketValue, td.UnitValue, td.AssessedDate, td.MarketValue, td.MarketDate, td.UnitDate, " &
                "td.AVAmount, td.MVAmount, td.AssessmentLevel, td.Barangay1, " &
                "td.Description, td.Property_No, td.Unit, td.Remarks " &
                "FROM AMS.Property p " &
                "INNER JOIN AMS.Property_Dtl pd ON p.Property_ID = pd.Property_ID " &
                "INNER JOIN AMS.TbLand_Dtl td ON pd.PropertyDetai_ID = td.Property_Dtl_ID " &
                "INNER JOIN AMS.TbLand_OwnerHistory oh ON td.LandId = oh.LandId " &
                "INNER JOIN dbo.m_item i ON p.Item_ID = i.Item_ID " &
                "WHERE p.Property_ID = " & propID, CommandType.Text)


                txtLocation.Text = dt1.Rows(0).Item("Address").ToString()
                txtPrevOwner.Text = dt1.Rows(0).Item("OwnerName").ToString()
                txtEAcqDate.Text = dt1.Rows(0).Item("UnitDate").ToString()
                txtAcqCost.Text = dt1.Rows(0).Item("Amount").ToString()
                txtAcqMode.Text = dt1.Rows(0).Item("AcqMode").ToString()
                txtMarketValue.Text = dt1.Rows(0).Item("MarketValue1").ToString()

                'ddTaxDecNo.Text = dt1.Rows(0).Item("TaxDeclarationNo").ToString()
                Dim taxDecValue As String = dt1.Rows(0).Item("TaxDeclarationNo").ToString()

                If ddTaxDecNo.Items.FindByValue(taxDecValue) IsNot Nothing Then
                    ddTaxDecNo.SelectedValue = taxDecValue
                Else
                    ' Optional: select default or insert dynamically
                    ddTaxDecNo.ClearSelection()
                    ddTaxDecNo.Items.Insert(0, New ListItem(taxDecValue, taxDecValue))
                    ddTaxDecNo.SelectedIndex = 0
                End If



                ' Was: ddBrgy1.SelectedValue = dt1.Rows(0)("Barangay1").ToString()

                Dim brgyText As String = dt1.Rows(0)("Barangay1").ToString().Trim()

                Dim li As ListItem = ddBrgy1.Items.FindByText(brgyText)
                If li IsNot Nothing Then
                    ddBrgy1.ClearSelection()
                    li.Selected = True
                Else
                    ' optional: if not found, add it so it shows up
                    ddBrgy1.Items.Insert(0, New ListItem(brgyText, brgyText))
                    ddBrgy1.SelectedIndex = 0
                End If

                txtLGUCode.Text = dt1.Rows(0).Item("LguCode").ToString()
                txtDistrictCode.Text = dt1.Rows(0).Item("DistrictCode").ToString()
                txtCityCode.Text = dt1.Rows(0).Item("CityMunCode").ToString()
                txtBrgyCode.Text = dt1.Rows(0).Item("CityMunCode").ToString()
                txtSectionNo.Text = dt1.Rows(0).Item("SectionNo").ToString()
                txtParcelNo.Text = dt1.Rows(0).Item("ParcelNo").ToString()
                txtSeriesNo.Text = dt1.Rows(0).Item("SeriesNo").ToString()
                txtRPTIN.Text = dt1.Rows(0).Item("RPTIN").ToString()
                txtPIN.Text = dt1.Rows(0).Item("PIN").ToString()
                txtARP.Text = dt1.Rows(0).Item("ARP").ToString()
                txtTDN.Text = dt1.Rows(0).Item("TDN").ToString()
                txtRevYear.Text = dt1.Rows(0).Item("RevYear").ToString()
                txtDepRate.Text = dt1.Rows(0).Item("DepreciationRate").ToString()
                txtDepValue.Text = dt1.Rows(0).Item("DepreciationValue").ToString()

                txtLotNo.Text = dt1.Rows(0).Item("LotNo").ToString()
                txtStreet.Text = dt1.Rows(0).Item("StreetName").ToString()
                txtPurok.Text = dt1.Rows(0).Item("Purok").ToString()
                txtPhaseNo.Text = dt1.Rows(0).Item("PhaseNo").ToString()
                txtBlkNo.Text = dt1.Rows(0).Item("BlkNo").ToString()
                'txtSubdivision.Text = dt1.Rows(0).Item("LguCode").ToString()
                txtSitio.Text = dt1.Rows(0).Item("Sitio").ToString()
                txtBrgy.Text = dt1.Rows(0).Item("Barangay").ToString()
                txtCityMun.Text = dt1.Rows(0).Item("CityMunicipal").ToString()
                TxtRegion.Text = dt1.Rows(0).Item("Region").ToString()
                txtDistrict.Text = dt1.Rows(0).Item("District").ToString()
                txtProvince.Text = dt1.Rows(0).Item("Province").ToString()
                txtZipCode.Text = dt1.Rows(0).Item("ZipCode").ToString()

                txtClassification.Text = dt1.Rows(0).Item("Classification").ToString()
                txtSubClass.Text = dt1.Rows(0).Item("SubClass").ToString()
                txtLandUse.Text = dt1.Rows(0).Item("LandUse").ToString()
                txtTaxable.Text = dt1.Rows(0).Item("Taxable").ToString()
                txtSubClassArea.Text = dt1.Rows(0).Item("Area").ToString()
                txtArea.Text = dt1.Rows(0).Item("Area1").ToString()

                txtAssessedValue.Text = dt1.Rows(0).Item("AssessedValue").ToString()
                txtCharacteristicsMarketValue.Text = dt1.Rows(0).Item("MarketValue").ToString()
                txtUnitValue.Text = dt1.Rows(0).Item("UnitValue").ToString()
                txtAssessedValueDate.Text = dt1.Rows(0).Item("AssessedDate").ToString()
                txtMarketValueDate.Text = dt1.Rows(0).Item("MarketDate").ToString()
                txtUnitValueDate.Text = dt1.Rows(0).Item("UnitDate").ToString()
                txtAssessedValueAmount.Text = dt1.Rows(0).Item("AVAmount").ToString()
                txtMarketValueAmount.Text = dt1.Rows(0).Item("MVAmount").ToString()
                'TextBox3.Text = dt1.Rows(0).Item("AssessmentLevel").ToString()
                txtDescription.Text = dt1.Rows(0).Item("Description").ToString()
                txtPropertyNumber.Text = dt1.Rows(0).Item("Property_No").ToString()
                txtUnit.Text = dt1.Rows(0).Item("Unit").ToString()
                txtRemarks.Text = dt1.Rows(0).Item("Remarks").ToString()


                Dim textBoxes1() As TextBox = {txtArea, txtLocation, txtPrevOwner, txtEAcqDate, txtAcqCost, txtAcqMode, txtMarketValue, txtLGUCode, txtDistrictCode,
                    txtCityCode, txtBrgyCode, txtSectionNo, txtParcelNo, txtSeriesNo, txtRPTIN, txtPIN, txtARP, txtTDN,
                    txtRevYear, txtDepRate, txtDepValue, txtLotNo, txtStreet, txtPurok, txtPhaseNo, txtBlkNo, txtSitio, txtBrgy, txtCityMun, TxtRegion, txtDistrict, txtProvince, txtZipCode, txtClassification,
                    txtSubClass, txtLandUse, txtTaxable, txtSubClassArea, txtAssessedValue, txtCharacteristicsMarketValue, txtUnitValue, txtAssessedValueDate, txtMarketValueDate, txtUnitValueDate, txtAssessedValueAmount, txtMarketValueAmount,
                    txtPropertyNumber
                }

                For Each txtBox As TextBox In textBoxes1
                    txtBox.ReadOnly = True
                Next
            End If
        Next

        btnLandSave.Enabled = True

    End Sub

    Protected Sub ClearTextBox()

        txtLocation.Text = String.Empty
        txtPrevOwner.Text = String.Empty
        txtEAcqDate.Text = String.Empty
        txtAcqCost.Text = String.Empty
        txtAcqMode.Text = String.Empty
        txtMarketValue.Text = String.Empty

        txtLGUCode.Text = String.Empty
        txtDistrictCode.Text = String.Empty
        txtCityCode.Text = String.Empty
        txtBrgyCode.Text = String.Empty
        txtSectionNo.Text = String.Empty
        txtParcelNo.Text = String.Empty
        txtSeriesNo.Text = String.Empty
        txtRPTIN.Text = String.Empty
        txtPIN.Text = String.Empty
        txtARP.Text = String.Empty
        txtTDN.Text = String.Empty
        txtRevYear.Text = String.Empty
        txtDepRate.Text = String.Empty
        txtDepValue.Text = String.Empty

        txtLotNo.Text = String.Empty
        txtStreet.Text = String.Empty
        txtPurok.Text = String.Empty
        txtPhaseNo.Text = String.Empty
        txtBlkNo.Text = String.Empty
        'txtSubdivision.Text = dt1.Rows(0).Item("LguCode").ToString()
        txtSitio.Text = String.Empty
        txtBrgy.Text = String.Empty
        txtCityMun.Text = String.Empty
        TxtRegion.Text = String.Empty
        txtDistrict.Text = String.Empty
        txtProvince.Text = String.Empty
        txtZipCode.Text = String.Empty

        txtClassification.Text = String.Empty
        txtSubClass.Text = String.Empty
        txtLandUse.Text = String.Empty
        txtTaxable.Text = String.Empty
        txtSubClassArea.Text = String.Empty

        txtAssessedValue.Text = String.Empty
        txtCharacteristicsMarketValue.Text = String.Empty
        txtUnitValue.Text = String.Empty
        txtAssessedValueDate.Text = String.Empty
        txtMarketValueDate.Text = String.Empty
        txtUnitValueDate.Text = String.Empty
        txtAssessedValueAmount.Text = String.Empty
        txtMarketValueAmount.Text = String.Empty
        TextBox3.Text = String.Empty
    End Sub

    Protected Sub grdLedger1_RowCreated(
    sender As Object,
    e As GridViewRowEventArgs) Handles grdLedger1.RowCreated

        If grdLedger1.HeaderRow IsNot Nothing AndAlso
        grdLedger1.Rows.Count > 0 Then

            If grdLedger1.Controls.Count > 0 AndAlso
            grdLedger1.Controls(0).Controls.Count > 0 Then

                Dim headerAlreadyExists As Boolean = False

                For Each currentRow As GridViewRow In
                grdLedger1.Controls(0).Controls

                    If currentRow.RowType =
                    DataControlRowType.Header AndAlso
                    currentRow.Cells.Count > 0 AndAlso
                    currentRow.Cells(0).Text = "DETAILS" Then

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

                    cell.Text = "DETAILS"
                    cell.ColumnSpan = 4
                    cell.HorizontalAlign = HorizontalAlign.Center
                    row.Cells.Add(cell)

                    cell = New TableHeaderCell()
                    cell.Text = "DEBIT"
                    cell.ColumnSpan = 2
                    cell.HorizontalAlign = HorizontalAlign.Center
                    row.Cells.Add(cell)

                    cell = New TableHeaderCell()
                    cell.Text = "CREDIT"
                    cell.ColumnSpan = 2
                    cell.HorizontalAlign = HorizontalAlign.Center
                    row.Cells.Add(cell)

                    cell = New TableHeaderCell()
                    cell.Text = "BALANCE"
                    cell.ColumnSpan = 2
                    cell.HorizontalAlign = HorizontalAlign.Center
                    row.Cells.Add(cell)

                    row.BackColor = Color.White
                    row.ForeColor = Color.Black

                    grdLedger1.Controls(0).Controls.AddAt(
                    0,
                    row
                )

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


    Private Sub OpenLandFields()
        Dim textBoxes() As TextBox = {txtArea, txtLocation, txtPrevOwner, txtEAcqDate, txtAcqCost, txtAcqMode, txtMarketValue, txtLGUCode, txtDistrictCode,
            txtCityCode, txtBrgyCode, txtSectionNo, txtParcelNo, txtSeriesNo, txtRPTIN, txtPIN, txtARP, txtTDN,
            txtRevYear, txtDepRate, txtDepValue, txtLotNo, txtStreet, txtPurok, txtPhaseNo, txtBlkNo, txtSitio, txtBrgy, txtCityMun, TxtRegion, txtDistrict, txtProvince, txtZipCode, txtClassification,
            txtSubClass, txtLandUse, txtTaxable, txtSubClassArea, txtAssessedValue, txtCharacteristicsMarketValue, txtUnitValue, txtAssessedValueDate, txtMarketValueDate, txtUnitValueDate, txtAssessedValueAmount, txtMarketValueAmount,
            txtPropertyNumber, txtDescription, txtUnit, txtRemarks}

        For Each txtBox As TextBox In textBoxes
            txtBox.ReadOnly = False
        Next
    End Sub


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
            btnLandSave.Text = "UPDATE"
            txtApprovedPass.Text = ""
            OpenLandFields()
            ModalPopupExtender1.Hide()
            btnLandSave.Enabled = True
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fields are now open for editing")
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
        txtApprovedPass.Text = ""
        ModalPopupExtender1.Hide()
    End Sub

End Class
