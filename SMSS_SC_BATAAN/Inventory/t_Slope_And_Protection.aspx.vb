Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Drawing
Partial Class Inventory_t_Slope_And_Protection
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim idholder As String = ""
    Private Property pMaterial() As DataTable
        Get
            Return CType(Session("pMaterial"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pMaterial") = value
        End Set
    End Property
    Private Property pPLA() As DataTable
        Get
            Return CType(Session("pPLA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPLA") = value
        End Set
    End Property
    Private Property pMM() As DataTable
        Get
            Return CType(Session("pMM"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pMM") = value
        End Set
    End Property
    Private Property pSE() As DataTable
        Get
            Return CType(Session("pSE"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pSE") = value
        End Set
    End Property
    Private Property pAFN() As DataTable
        Get
            Return CType(Session("pAFN"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAFN") = value
        End Set
    End Property
#Region "Design"
    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Material", GetType(String))
        dt.Columns.Add("Quantity", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Material") = DBNull.Value
            dr("Quantity") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Permit_License_Description", GetType(String))
        dt.Columns.Add("Permit_License_No", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Permit_License_Description") = DBNull.Value
            dr("Permit_License_No") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("MMP_Description", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("MMP_Description") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SE_Description", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SE_Description") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable4(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("AFN", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("AFN") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region
#Region "Function"
    Public Sub LoadMaterial()
        pMaterial = objDerived.GetDataTable("select * from AMS.Slop_Protection_Material where Property_No='" & txtProperty_No.text & "'", CommandType.Text)
        If pMaterial.Rows.Count < 5 Then
            pMaterial.Merge(createdatatable(5 - pMaterial.Rows.Count))
        End If
        grdMaterial.DataSource = pMaterial
        grdMaterial.DataBind()
    End Sub
    Public Sub LoadPLA()
        pPLA = objDerived.GetDataTable("select * from AMS.Permit_License where Property_No='" & txtProperty_No.text & "'", CommandType.Text)
        If pPLA.Rows.Count < 5 Then
            pPLA.Merge(createdatatable1(5 - pPLA.Rows.Count))
        End If
        grdPLA.DataSource = pPLA
        grdPLA.DataBind()
    End Sub
    Public Sub LoadMM()
        pMM = objDerived.GetDataTable("select * from AMS.MMP", CommandType.Text)
        If pMM.Rows.Count < 5 Then
            pMM.Merge(createdatatable2(5 - pMM.Rows.Count))
        End If
        grdMM.DataSource = pMM
        grdMM.DataBind()
    End Sub
    Public Sub LoadSE()
        pSE = objDerived.GetDataTable("select * from AMS.Stakeholder_Engagement", CommandType.Text)
        If pSE.Rows.Count < 5 Then
            pSE.Merge(createdatatable2(5 - pSE.Rows.Count))
        End If
        grdSE.DataSource = pSE
        grdSE.DataBind()
    End Sub
    Public Sub LoadAFN()
        pAFN = objDerived.GetDataTable("select * from AMS.Slope_Protection_AFN", CommandType.Text)
        If pAFN.Rows.Count < 5 Then
            pAFN.Merge(createdatatable2(5 - pAFN.Rows.Count))
        End If
        grdAFN.DataSource = pAFN
        grdAFN.DataBind()
    End Sub
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            drpSubClassification.datasource = objDerived.GetDataTable("Select * from dbo.tbl_SubClassification where ClassificationID = 17", CommandType.Text)
            drpSubClassification.DataTextField = ("SubClassificationName")
            drpSubClassification.DataValueField = ("SubClassificationID")
            drpSubClassification.DataBind()
            drpSubClassification.Items.Insert(0, "Select")

            LoadProjectStatus()
            LoadMaterial()
            LoadPLA()
            LoadMM()
            LoadSE()
            LoadAFN()
            LoadTypeofSlopAndProtection()




            loadEquipmentLedger()

        End If
    End Sub
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        'Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        'Dim cell As New TableHeaderCell()
        'cell.Text = "ROADS AND BRIDGES CONSTRUCTION"
        'cell.ColumnSpan = 3
        'row.Controls.Add(cell)

        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 1
        'cell.Text = "DEBIT"
        'row.Controls.Add(cell)


        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 1
        'cell.Text = "CREDIT"
        'row.Controls.Add(cell)


        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 1
        'cell.Text = "BALANCE"
        'row.Controls.Add(cell)

        'row.BackColor = ColorTranslator.FromHtml("WHITE")
        'row.ForeColor = ColorTranslator.FromHtml("BLACK")
        'grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)


        ''Optimize code using chat gpt

        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        row.BackColor = Color.White
        row.ForeColor = Color.Black

        Dim cell As TableHeaderCell

        cell = New TableHeaderCell()
        cell.Text = "ROADS AND BRIDGES CONSTRUCTION"
        cell.ColumnSpan = 3
        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "DEBIT"
        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "CREDIT"
        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "BALANCE"
        row.Cells.Add(cell)

        grdLedger1.Controls(0).Controls.AddAt(0, row)
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
        Dim dtAccount As New DataTable
        Dim itemid As String
        'If 

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "' order by dDate", CommandType.Text)
        If idholder = "" Then
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)

        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & idholder & "'", CommandType.Text)

        End If
        ' dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

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
    Protected Sub btnAddMaterial_Click(sender As Object, e As EventArgs)
        objDerived.Execute("insert into AMS.Slop_Protection_Material(Property_No,Material,Quantity)VALUES('" & txtProperty_No.text & "','" & txtMaterial.text & "','" & txtMaterialQuantity.text & "')", CommandType.Text)

        LoadMaterial()
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Saved.")
    End Sub
    Protected Sub btnAddPLA_Click(sender As Object, e As EventArgs)
        objDerived.Execute("insert into AMS.Permit_License(Property_No,Permit_License_Description,Permit_License_No)VALUES('" & txtProperty_No.text & "','" & txtPLADescription.text & "','" & txtPLAPermitLicenseNo.text & "')", CommandType.Text)

        LoadPLA()
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Saved.")
    End Sub

    Protected Sub btnADDMM_Click(sender As Object, e As EventArgs)
        objDerived.Execute("insert into AMS.MMP(Property_No,MMP_Description)VALUES('" & txtProperty_No.text & "','" & txtMMDescription.text & "')", CommandType.Text)

        LoadMM()
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Saved.")
    End Sub
    Protected Sub btnSEAdd_Click(sender As Object, e As EventArgs)
        objDerived.Execute("insert into AMS.Stakeholder_Engagement (Property_No,SE_Description)VALUES('" & txtProperty_No.text & "','" & txtSEDescription.TEXT & "')", CommandType.Text)

        LoadSE()
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Saved.")
    End Sub

    Protected Sub txtProperty_No_TextChanged(sender As Object, e As EventArgs)
        Dim count As Integer
        count = objDerived.GetValue("select count(*) from SlopProtectionInfo where Property_No = '" & txtProperty_No.text & "'", CommandType.Text)
        If count > 0 Then

        Else
            LoadMaterial()
            LoadPLA()
            LoadMM()
            LoadSE()
            LoadAFN()
        End If
    End Sub
    Protected Sub btnTypeOfSlopeAndProtection_Click(sender As Object, e As EventArgs)
        Select Case btnTypeOfSlopeAndProtection.TEXT
            Case "Add New"
                drpTypeofSlopeAndProtection.visible = False
                txtTypeofSlopAndProtection.visible = True

                btnTypeOfSlopeAndProtection.TEXT = "SAVE"

            Case "SAVE"
                drpTypeofSlopeAndProtection.visible = True
                txtTypeofSlopAndProtection.visible = False
                objDerived.Execute("insert into AMS.TypeofSlopandProtection(Description)VALUES('" & txtTypeofSlopAndProtection.text & "')", CommandType.Text)
                LoadTypeofSlopAndProtection()
                btnTypeOfSlopeAndProtection.TEXT = "Add New"
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Saved.")
        End Select
    End Sub
    Public Sub LoadTypeofSlopAndProtection()
        drpTypeofSlopeAndProtection.datasource = objDerived.GetDataTable("Select * from AMS.TypeofSlopandProtection", CommandType.Text)
        drpTypeofSlopeAndProtection.DataTextField = ("Description")
        drpTypeofSlopeAndProtection.DataValueField = ("TypeofSlopandProtection_ID")
        drpTypeofSlopeAndProtection.DataBind()
        drpTypeofSlopeAndProtection.Items.Insert(0, "Select")
    End Sub
    Public Sub LoadProjectStatus()
        drpProjectStatus.datasource = objDerived.GetDataTable("Select * from AMS.Project_Status", CommandType.Text)
        drpProjectStatus.DataTextField = ("Description")
        drpProjectStatus.DataValueField = ("Project_Status_ID")
        drpProjectStatus.DataBind()
        drpProjectStatus.Items.Insert(0, "Select")
    End Sub
    Protected Sub btnSaveAFN_Click(sender As Object, e As EventArgs)
        'With Item
        '    .Item_Code = ""
        '    .Item_Desc = txtProjectName.text
        '    .Unit_ID = 0
        'End With

        'Dim itemid As Integer
        'itemid = Item.save()
        'objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & txtConstructionCost.Text.Replace(",", "") & "',null", CommandType.Text)

        'Dim classification As String = objDerived.getvalue("select  a.ClassificationId From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%'", commandtype.text)
        'Dim category As Integer = objDerived.getvalue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & itemid, commandtype.text)
        'Dim gaid As Integer = objDerived.getvalue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
        'Dim matrix As String = objDerived.getvalue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & gaid & " and item_id = " & itemid & "", commandtype.text)

        'If matrix = "" Then
        '    objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id,SubClassificationID) values('" & classification & "','" & gaid & "','" & itemid & "','" & category & "','0','" & drpSubClass.SelectedItem.Value & "')", commandtype.text)
        'End If

        'With Prop_Hdr
        '    '.Property_ID = Property_ID
        '    .Property_Date = txtRoadAcqDate.Text
        '    .Issuance = 0
        '    .Remarks = "Manual Encoding of Land Properties"
        '    .Emp_ID = 0
        '    .F_ID = 1
        '    .AIRDtl_ID = 0
        '    .deptid = 0
        '    .isDonated = False
        '    .GA_ID = objDerived.getvalue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
        '    .DonationRemarks = ""
        '    .Qty = 1
        '    .Balance = 1
        '    .Cost = txtRoadAcqCost.Text.Replace(",", "")
        '    .Item_ID = itemid
        '    .Property_code = objDerived.getvalue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
        '    .RC_ID = 0
        '    .Function_ID = 0+
        '    .TD_ID = 1
        '    .Project_ID = 0
        '    .Program_id = 0
        '    .Particular = ""
        'End With
        'Dim PropHdr_ID As Integer = 0
        'PropHdr_ID = Prop_Hdr.save()


        'objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

        'Dim gacode As String = objDerived.getvalue("select GA_Code From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Road%' ", commandtype.text)
        'Dim rcid As Integer = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
        'Dim Function_ID As Integer = 86


        'With Prop_Dtl
        '    '.PropertyDetai_ID = 0  
        '    If txtRoadID.Text = "" Then
        '        .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo_BATAAN]( '" & txtRoadAcqDate.Text & "', '" & gacode & "','" & rcid & "','" & Function_ID & "')", CommandType.Text)
        '    Else
        '        .PropertyNo = txtRoadID.Text
        '    End If

        '    .Property_ID = PropHdr_ID
        '    .Issued = False
        '    .Repair = False
        '    .Dispose = False
        '    .DisposeDate = "1/1/1900"
        '    .IsInspectionForDisposal = False
        '    .InspectionDate = txtRoadAcqDate.Text
        '    .F_ID = 1
        '    .SerialNo = txtRoadID.Text
        '    .Barcode = txtRoadID.Text
        '    .Amount = CType(txtRoadAcqCost.Text, Decimal)
        '    .Status = "Accepted"
        '    .Details = ""
        '    .type = drpSubClass.SelectedItem.Text
        'End With

        'Dim PropDtl_ID As Integer
        'PropDtl_ID = Prop_Dtl.save()

        'objDerived.GetRecords("UPDATE AMS.Property_Dtl SET MarketValue = '" & txtRoadMarketValue.Text.Replace(",", "") & "' WHERE PropertyDetai_ID = '" & PropDtl_ID & "'", CommandType.Text)

    End Sub
End Class
