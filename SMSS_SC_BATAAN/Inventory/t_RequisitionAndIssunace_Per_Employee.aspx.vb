
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Drawing


Partial Class Inventory_RIS
    Inherits System.Web.UI.Page
    Dim gvItemsRow As Integer
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private dtl As New RISDtl
    Private hdr As New RISHdr
    Private objPropertyDtl As New t_property_dtl
    Private objMREHdr As New MREHdr
    Private objMREDtl As New MREDtl
    Private objMREReturn As New MRE_Return
    Dim msg As New MsgeBox
    Dim image As New Image
    Private objMenuCntrl As New ManageButtons

    Dim objLedger As New t_PropertyLedger
    Dim Ledger_ID As New Integer
    Dim dtPropLedger As New DataTable

    Dim objStockLedger As New t_StockLedger
    Dim StockLedger_ID As New Integer
    Dim dtStockLedger As New DataTable

    Dim objDonationLedger As New ConsolidatedPropertySaving.TbDonation_Ledger
    Dim DonationLedger_ID As New Integer
    Dim dtDonationLedger As New DataTable

    Dim ICS_hdr As New ICSHdr
    Dim ICS_Dtl As New ICSDtl

    Dim Return_Hdr As New Returned_History.ARE_Returned_History_Hdr
    Dim Return_Dtl As New Returned_History.ARE_Returned_History_Dtl

    Dim Barcode1 As String
    Dim MRE_ID As String


#Region "Property"
    Private Property dtGenAccount() As DataTable
        Get
            Return CType(Session("dtGenAccount"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtGenAccount") = value
        End Set
    End Property
    Private Property dtSupplies() As DataTable
        Get
            Return CType(Session("dtSupplies"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSupplies") = value
        End Set
    End Property

    Private Property Ppropertylist() As DataTable
        Get
            Return CType(Session("propertylist"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("propertylist") = value
        End Set
    End Property

    Private Property PdepartmentPersonnel() As DataTable
        Get
            Return CType(Session("departmentPersonnel"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("departmentPersonnel") = value
        End Set
    End Property

    Private Property pemployee() As DataTable
        Get
            Return CType(Session("pemployee"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pemployee") = value
        End Set
    End Property

    Private Property pItems() As DataTable
        Get
            Return CType(Session("pItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItems") = value
        End Set
    End Property

    Private Property pbody() As DataTable
        Get
            Return CType(Session("pbody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pbody") = value
        End Set
    End Property
    Private Property pnew() As DataTable
        Get
            Return CType(Session("pnew"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pnew") = value
        End Set
    End Property
    Private Property popen() As DataTable
        Get
            Return CType(Session("popen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("popen") = value
        End Set
    End Property

    Private Property pRC() As DataTable
        Get
            Return CType(Session("pRC"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRC") = value
        End Set
    End Property

    Private Property pFunction() As DataTable
        Get
            Return CType(Session("pFunction"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pFunction") = value
        End Set
    End Property

    Private Property dtissue() As DataTable
        Get
            Return CType(Session("dtissue"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtissue") = value
        End Set
    End Property

    Private Property dtissue2() As DataTable
        Get
            Return CType(Session("dtissue2"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtissue2") = value
        End Set
    End Property
#End Region
#Region "Datatables"
    Public Function CreateDataTable_Supplies(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mycolumn As New DataColumn
        dt.Columns.Add("Item_Code", GetType(String))
        dt.Columns.Add("ItemDesc", GetType(String))
        dt.Columns.Add("UnitDesc", GetType(String))
        dt.Columns.Add("Balance", GetType(Decimal))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Long))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Long))
        dt.Columns.Add("StockID", GetType(Long))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("wLocation", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("isChecked", GetType(Boolean))
        dt.Columns.Add("Barcode_Supplies", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow

            dr("Item_Code") = DBNull.Value
            dr("ItemDesc") = DBNull.Value
            dr("UnitDesc") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("ID") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("StockID") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("wLocation") = DBNull.Value
            dr("isVisible") = False
            dr("isChecked") = False
            dr("Barcode_Supplies") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function CreateDataTable_StockLedgerPerEmployee(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mycolumn As New DataColumn
        dt.Columns.Add("dDate", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("ReceivedBy", GetType(String))
        dt.Columns.Add("Ref_No", GetType(String))
        dt.Columns.Add("Issued_Qty", GetType(Integer))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("Total", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("dDate") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("ReceivedBy") = DBNull.Value
            dr("Ref_No") = DBNull.Value
            dr("Issued_Qty") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("Total") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function Createdatabalegvsearch(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("ItemParticular", GetType(String))
        dt.Columns.Add("isDonated", GetType(Boolean))
        dt.Columns.Add("Qty", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("ItemParticular") = DBNull.Value
            dr("isDonated") = DBNull.Value
            dr("Qty") = DBNull.Value
            dt.Rows.Add(dr)

        Next
        Return dt
    End Function

    Public Function CreatedatabalegrListOfProperty(ByVal row As Integer) As DataTable
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim mycolumn As New DataColumn
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("AcquiredDate", GetType(String))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("rc_name", GetType(String))
        dt.Columns.Add("fullname", GetType(String))
        dt.Columns.Add("DateIssued", GetType(Date))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("rc_id", GetType(Integer))
        dt.Columns.Add("function_id", GetType(Integer))
        dt.Columns.Add("MREHdr_ID", GetType(Integer))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("MREDtl_ID", GetType(Integer)) ''MRE_Hdr'
        dt.Columns.Add("MRE_Hdr", GetType(Integer))
        dt.Columns.Add("MRE_Date", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("AcquiredDate") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("rc_name") = DBNull.Value
            dr("fullname") = DBNull.Value
            dr("DateIssued") = DBNull.Value
            dr("Status") = "  "
            dr("rc_id") = DBNull.Value
            dr("function_id") = DBNull.Value
            dr("MREHdr_ID") = DBNull.Value
            dr("Property_ID") = DBNull.Value
            dr("PropertyDetai_ID") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("MREDtl_ID") = DBNull.Value
            dr("MRE_Hdr") = DBNull.Value
            dr("MRE_Date") = DBNull.Value
            dr("SerialNo") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function CreatedatatableScannedDoc(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mycolumn As New DataColumn
        dt.Columns.Add("DocumentName", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("ValidatedBy", GetType(String))
        dt.Columns.Add("DateValidated", GetType(Date))
        dt.Columns.Add("DocuID", GetType(Long))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("DocumentName") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("ValidatedBy") = DBNull.Value
            dr("DateValidated") = DBNull.Value
            dr("DocuID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function temp_dtSupplies(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mycolumn As New DataColumn
        dt.Columns.Add("RC_ID", GetType(String))
        dt.Columns.Add("GA_ID", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Integer))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("total", GetType(Decimal))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("RC_ID") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("total") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function CreatedatatableSupplist(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mycolumn As New DataColumn
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Long))
        dt.Columns.Add("Item_Code", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("Item_Code") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If

        grListOfProperty.Columns(10).Visible = False

        If Not Page.IsPostBack Then
            Dim dProperty As New DataTable

            dProperty = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 3 & "'", CommandType.Text)
            ddProperty.DataSource = CType(dProperty, DataTable)
            ddProperty.DataTextField = ("GA_Title")
            ddProperty.DataValueField = ("GA_ID")
            ddProperty.DataBind()
            ddProperty.Items.Insert(0, "Select")

            gvsearchProperty.DataSource = Createdatabalegvsearch(5)
            gvsearchProperty.DataBind()

            gvSupplyList.DataSource = CreateDataTable_Supplies(5)
            gvSupplyList.DataBind()
            gvSupplyList.SelectedIndex = -1

            LoadPropertyList()

            grdIssueItems.DataSource = Nothing
            grdIssueItems.DataBind()

            If gvDocumentAdded.Rows.Count < 4 Then
                gvDocumentAdded.DataSource = CreatedatatableScannedDoc(4)
                gvDocumentAdded.DataBind()
            End If

            '=== for scanned documents
            tbleScanDoc.Visible = True

            '=-= DEFAULT VIEW (RIS)
            LoadRIS_Tab()




            pRC = Nothing
            pRC = objDerived.GetDataTable("SELECT DISTINCT [RC_id],UPPER([RC_Name]) AS RC_Name FROM [dbo].[View_RespCenter_withFunctions] ORDER BY [RC_Name]", CommandType.Text)
            drpSearh_Department.DataSource = CType(pRC, DataTable)
            drpSearh_Department.DataTextField = ("RC_Name")
            drpSearh_Department.DataValueField = ("RC_ID")
            drpSearh_Department.DataBind()
            drpSearh_Department.Items.Insert(0, "Select")


            CheckBox3.Enabled = False
            btnsave.Enabled = False



            pItems = Nothing
            pbody = Nothing
            gvbody.DataSource = pbody
            gvbody.DataBind()

            Session("Page") = "INV"
            If Session("TabSelection") = "PARE" Then
                Me.mvIssuance.SetActiveView(Me.vwARE)
                btnRIS.CssClass = "Initial"
                btnARE.CssClass = "Clicked"
            Else
                LoadRIS_Tab()
            End If
        End If


        txtSupplySearch1.Attributes.Add("onkeypress", "return fun1(event,'" & btnSupplySearch.ClientID & "')")
        txtsearchitems.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
        txtSearchProperty.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchProperty.ClientID & "')")

    End Sub
    Protected Sub LoadMainRIS()




    End Sub

    Protected Sub ddProperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddProperty.SelectedIndexChanged
        Session("GA_ID") = ddProperty.SelectedItem.Value
        Session("PropSearch") = 0
        txtSearchProperty.Text = ""
        LoadPropertyDropDown()
    End Sub
    Protected Sub LoadPropertyDropDown()
        Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v2] '" & Session("GA_ID") & "'", CommandType.Text)
        If Ppropertylist.Rows.Count < 10 Then
            Ppropertylist.Merge(Createdatabalegvsearch(9 - Ppropertylist.Rows.Count))
            gvsearchProperty.DataSource = Ppropertylist
            gvsearchProperty.DataBind()
        Else
            gvsearchProperty.DataSource = Ppropertylist
            gvsearchProperty.DataBind()
        End If

        LoadPropertyList()

    End Sub
    'ARE 
    Protected Sub btnSearchProperty_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddProperty.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Select property.")
        Else
            'Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_Search] '" & Session("GA_ID") & "','" & txtSearchProperty.Text & "'", CommandType.Text)
            'If Ppropertylist.Rows.Count < 10 Then
            '    Ppropertylist.Merge(Createdatabalegvsearch(9 - Ppropertylist.Rows.Count))
            'End If
            'gvsearchProperty.DataSource = Ppropertylist
            'gvsearchProperty.DataBind()

            Dim myview As DataView
            myview = Ppropertylist.DefaultView
            myview.RowFilter = "Item_desc like '%" & txtSearchProperty.Text & "%'"
            gvsearchProperty.DataSource = myview
            gvsearchProperty.DataBind()


            Session("PropSearch") = 1
        End If

    End Sub
    Protected Sub gvsearchProperty_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvsearchProperty.PageIndexChanging
        If Session("PropSearch") = 1 Then
            Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_Search] '" & Session("GA_ID") & "','" & txtSearchProperty.Text & "'", CommandType.Text)
            If Ppropertylist.Rows.Count < 10 Then
                Ppropertylist.Merge(Createdatabalegvsearch(9 - Ppropertylist.Rows.Count))
            End If
            gvsearchProperty.PageIndex = e.NewPageIndex
            gvsearchProperty.DataSource = Ppropertylist
            gvsearchProperty.DataBind()

        ElseIf Session("PropSearch") = 0 Then

            Ppropertylist = objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v2] '" & Session("GA_ID") & "'", CommandType.Text)
            If Ppropertylist.Rows.Count < 10 Then
                Ppropertylist.Merge(Createdatabalegvsearch(9 - Ppropertylist.Rows.Count))
            End If
            gvsearchProperty.PageIndex = e.NewPageIndex
            gvsearchProperty.DataSource = Ppropertylist
            gvsearchProperty.DataBind()

        End If


    End Sub
    Protected Sub gvsearchProperty_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvsearchProperty.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearchProperty, "Select$" + e.Row.RowIndex.ToString()))
        End If

    End Sub
    Protected Sub gvsearchProperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvsearchProperty.SelectedIndexChanged
        btnsavedoc.Enabled = False
        btncancelDoc.Enabled = False
        btnpreviewAreDoc.Enabled = False

        Dim dt As New DataTable
        grListOfProperty.DataSource = dt
        grListOfProperty.DataBind()

        LoadwithOutProperty()

    End Sub
    Protected Sub LoadPropertyList()
        grListOfProperty.DataSource = CreatedatabalegrListOfProperty(5)
        grListOfProperty.DataBind()

        For i As Integer = 0 To grListOfProperty.Rows.Count - 1
            grListOfProperty.Rows(i).Cells(0).Enabled = False
        Next

    End Sub

    Public Sub LoadwithOutProperty()
        Dim x As String = IIf(IsDBNull(gvsearchProperty.SelectedDataKey("Item_id")), 0, (gvsearchProperty.SelectedDataKey("Item_id")))
        If x = 0 Then
            LoadPropertyList()
            Exit Sub
        End If

        '   Ppropertylist = Me.objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyToIssue_v2] '" & gvsearchProperty.SelectedDataKey("Item_id") & "', '" & gvsearchProperty.SelectedDataKey("isDonated") & "'", CommandType.Text)



        Ppropertylist = objDerived.GetDataTable("EXEC [AMS].[sp_Inventory_ItemList] '" & gvsearchProperty.SelectedDataKey("Item_id") & "', '" & gvsearchProperty.SelectedDataKey("isDonated") & "'", CommandType.Text)

        If Ppropertylist.Rows.Count = 0 Then
            LoadPropertyList()

        Else
            btnviewProperty.Enabled = True
            Dim ItemId As New Integer
            ItemId = Me.gvsearchProperty.SelectedDataKey("Item_id").ToString
            Session("itemId") = ItemId

            If Ppropertylist.Rows.Count < 5 Then
                Ppropertylist.Merge(CreatedatabalegrListOfProperty(4 - Ppropertylist.Rows.Count))
            End If
            grListOfProperty.DataSource = Ppropertylist
            grListOfProperty.DataBind()

            For i As Integer = 0 To Ppropertylist.Rows.Count - 1
                If Ppropertylist.Rows(i)("status") = "Returned" Or Ppropertylist.Rows(i)("status") = " - " Or Ppropertylist.Rows(i)("status") = "On Hand" Then
                    If i < 10 Then
                        grListOfProperty.Rows(i).Cells(0).Enabled = True
                    End If
                Else
                    If i < 10 Then
                        grListOfProperty.Rows(i).Cells(0).Enabled = False
                    End If
                End If
            Next

        End If
    End Sub

    'Protected Sub grListOfProperty_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
    '    If (e.Row.RowType = DataControlRowType.DataRow) Then
    '        e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffffcc' cssclass='text'")
    '        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White' cssclass='text' ")

    '        e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
    '        e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
    '        e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grListOfProperty, "Select$" + e.Row.RowIndex.ToString()))
    '    End If
    'End Sub
    Protected Sub grListOfProperty_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grListOfProperty.PageIndexChanging
        'Ppropertylist = Me.objDerived.GetDataTable("Select * from dbo.View_PropertyToIssue where item_id = '" & gvsearchProperty.SelectedDataKey("Item_id") & "'", CommandType.Text)
        'If Ppropertylist.Rows.Count < 5 Then
        '    Ppropertylist.Merge(CreatedatabalegrListOfProperty(4 - Ppropertylist.Rows.Count))
        '    grListOfProperty.PageIndex = e.NewPageIndex
        '    grListOfProperty.DataSource = Ppropertylist
        '    grListOfProperty.DataBind()
        '    grListOfProperty.SelectedIndex = 0
        'Else
        '    grListOfProperty.PageIndex = e.NewPageIndex
        '    grListOfProperty.DataSource = Ppropertylist
        '    grListOfProperty.DataBind()
        '    grListOfProperty.SelectedIndex = 0
        'End If

        'Ppropertylist = Me.objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyToIssue_v2] '" & gvsearchProperty.SelectedDataKey("Item_id") & "', '" & gvsearchProperty.SelectedDataKey("isDonated") & "'", CommandType.Text)
        'If Ppropertylist.Rows.Count < 5 Then
        '    Ppropertylist.Merge(CreatedatabalegrListOfProperty(4 - Ppropertylist.Rows.Count))
        'End If

        ''Session("MREHdr_ID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
        Ppropertylist = objDerived.GetDataTable("EXEC [AMS].[sp_Inventory_ItemList] '" & gvsearchProperty.SelectedDataKey("Item_id") & "', '" & gvsearchProperty.SelectedDataKey("isDonated") & "'", CommandType.Text)
        grListOfProperty.DataSource = Ppropertylist
        grListOfProperty.PageIndex = e.NewPageIndex
        grListOfProperty.DataBind()
        grListOfProperty.SelectedIndex = 0

        'LoadPropertyListChangeIndex()
        'LoadAttchDocu()
    End Sub
    Protected Sub grListOfProperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadPropertyListChangeIndex()
    End Sub
    Protected Sub LoadPropertyListChangeIndex()
        Me.HiddenField1.Value = grListOfProperty.SelectedDataKey("status").ToString


        If HiddenField1.Value = "Returned" Then 'Or HiddenField1.Value = " - " Then 'HiddenField1.Value = "" Or
            Session("Status") = "Returned"
            Session("MRE_Return") = objDerived.GetValue("Select MRE_ReturnID from AMS.MRE_Returns where PropertyNo = '" & grListOfProperty.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
            Session("MREHdr_ID") = objDerived.GetValue("SELECT AMS.MRE_Hdr.MREHdr_ID FROM AMS.MRE_Hdr INNER JOIN AMS.MRE_Dtl ON AMS.MRE_Hdr.MREHdr_ID = AMS.MRE_Dtl.MREHdr_ID INNER JOIN AMS.MRE_Returns ON AMS.MRE_Dtl.MREDtl_ID = AMS.MRE_Returns.MRE_Dtl where AMS.MRE_Returns.PropertyNo = '" & grListOfProperty.SelectedDataKey("PropertyNo") & "'", CommandType.Text)

            btnIssue.Enabled = True
            btnviewProperty.Enabled = True

            'btnpreviewAreDoc.Text = "PREVIEW PRS"

            btnsavedoc.Enabled = False
            btncancelDoc.Enabled = False
            btnpreviewAreDoc.Enabled = False
            Session("MREID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
            txtDateReturn.Text = Date.Today.ToString("MM/dd/yyyy")
            btnReturnProperty.Enabled = False
            LoadNoAttchment()

            txtMRE.Text = ""

        ElseIf HiddenField1.Value = "Disposed" Then
            Session("Status") = "Disposed"
            Session("MRE_Return") = objDerived.GetValue("Select MRE_ReturnID from AMS.MRE_Returns where PropertyNo = '" & grListOfProperty.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
            Session("MREHdr_ID") = objDerived.GetValue("SELECT AMS.MRE_Hdr.MREHdr_ID FROM AMS.MRE_Hdr INNER JOIN AMS.MRE_Dtl ON AMS.MRE_Hdr.MREHdr_ID = AMS.MRE_Dtl.MREHdr_ID INNER JOIN AMS.MRE_Returns ON AMS.MRE_Dtl.MREDtl_ID = AMS.MRE_Returns.MRE_Dtl where AMS.MRE_Returns.PropertyNo = '" & grListOfProperty.SelectedDataKey("PropertyNo") & "'", CommandType.Text)

            btnIssue.Enabled = False
            btnviewProperty.Enabled = True

            btnsavedoc.Enabled = False
            btncancelDoc.Enabled = False
            btnpreviewAreDoc.Enabled = False

        ElseIf HiddenField1.Value = "On Hand" Then
            Session("Status") = "On Hand"
            Session("MRE_Return") = objDerived.GetValue("Select MRE_ReturnID from AMS.MRE_Returns where PropertyNo = '" & grListOfProperty.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
            Session("MREHdr_ID") = objDerived.GetValue("SELECT AMS.MRE_Hdr.MREHdr_ID FROM AMS.MRE_Hdr INNER JOIN AMS.MRE_Dtl ON AMS.MRE_Hdr.MREHdr_ID = AMS.MRE_Dtl.MREHdr_ID INNER JOIN AMS.MRE_Returns ON AMS.MRE_Dtl.MREDtl_ID = AMS.MRE_Returns.MRE_Dtl where AMS.MRE_Returns.PropertyNo = '" & grListOfProperty.SelectedDataKey("PropertyNo") & "'", CommandType.Text)

            Dim dtMRE As New DataTable
            dtMRE = objDerived.GetDataTable("Select * from  dbo.view_MRE where PropertyNo = '" & grListOfProperty.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
            If dtMRE.Rows.Count = 0 Then

            Else
                txtMRE.Text = dtMRE.Rows(0).Item("MRENumber").ToString
            End If

            Session("PropertyDetai_ID") = grListOfProperty.SelectedDataKey("PropertyDetai_ID")
            Dim RISHdr_ID As Long = objDerived.GetValue("SELECT TOP(1)RISHdr_ID FROM dbo.View_PropertyRIS WHERE PropertyDetai_ID = '" & Session("PropertyDetai_ID") & "' ORDER BY RISHdr_ID DESC", CommandType.Text)

            Dim dtRIS As String
            dtRIS = objDerived.GetValue("Select RIS_No from [dbo].[View_PropertyRIS] where RISHdr_ID ='" & RISHdr_ID & "'", CommandType.Text)
            Session("ris_no") = dtRIS

            btnIssue.Enabled = False
            btnviewProperty.Enabled = True

            btnpreviewAreDoc.Text = "PREVIEW PARE"
            btnPreviewRIS.Enabled = True

            btnsavedoc.Enabled = False
            btncancelDoc.Enabled = False
            btnpreviewAreDoc.Enabled = True
            Session("MREID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
            txtDateReturn.Text = Date.Today.ToString("MM/dd/yyyy")
            btnReturnProperty.Enabled = True
            LoadAttchDocu()

        ElseIf HiddenField1.Value = " - " Then
            btnIssue.Enabled = True
            btnviewProperty.Enabled = True

            btnsavedoc.Enabled = False
            btncancelDoc.Enabled = False
            btnpreviewAreDoc.Enabled = False
            Session("MREID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
            txtDateReturn.Text = Date.Today.ToString("MM/dd/yyyy")
            btnReturnProperty.Enabled = False
            LoadNoAttchment()

            txtMRE.Text = ""

        Else
            btnIssue.Enabled = False
            btnviewProperty.Enabled = False

            btnsavedoc.Enabled = False
            btncancelDoc.Enabled = False
            btnpreviewAreDoc.Enabled = False

            txtMRE.Text = ""

        End If

    End Sub

    Protected Sub btnIssue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIssue.Click
        Dim DepartmentHead As New DataTable
        Dim DepartmentPersonnel As New DataTable

        Dim txtAREDate As String
        txtAREDate = Date.Today.ToString("MM/dd/yyyy")
        CheckBox3.Checked = False
        CheckBox3.Enabled = True
        txtMRE.ReadOnly = True

        ddFromDepartment.Items.Clear()
        ddFromDepartment.DataSource = objDerived.GetDataTable("Select * from dbo.View_RespCenter_withFunctions where RC_ID = 7", CommandType.Text)
        ddFromDepartment.DataTextField = ("RC_Name")
        ddFromDepartment.DataValueField = ("RC_ID")
        ddFromDepartment.DataBind()
        'ddFromDepartment.Items.Insert(0, "Select")

        ddFromProperty.Items.Clear()
        ddFromProperty.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = 7", CommandType.Text)
        ddFromProperty.DataTextField = ("full_name")
        ddFromProperty.DataValueField = ("empid")
        ddFromProperty.DataBind()
        ddFromProperty.Items.Insert(0, "Select")

        ddByDepartment.Items.Clear()
        'ddByDepartment.DataSource = objDerived.GetDataTable("Select * from AMS.Respcenter where ", CommandType.Text)
        ddByDepartment.DataSource = objDerived.GetDataTable("Select * from  dbo.View_RespCenter_withFunctions where Function_ID = 86 order by RC_Name", CommandType.Text)
        ddByDepartment.DataTextField = ("RC_Name")
        ddByDepartment.DataValueField = ("RC_Id")
        ddByDepartment.DataBind()
        ddByDepartment.Items.Insert(0, "Select")

        ddByAcknowledgement.Enabled = True
        ddByDepartment.Enabled = True
        ddFromDepartment.Enabled = True
        ddFromProperty.Enabled = True


        btnIssue.Enabled = False

    End Sub
    Protected Sub btnviewProperty_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If gvsearchProperty.SelectedDataKey("isDonated") = "True" Then
            Session("Donated") = "Search"
            Session("PropertyNo") = grListOfProperty.SelectedDataKey("PropertyNo")
            ' Me.Page.Response.Redirect("~/Records/t_DonationList.aspx")


            Dim url As String = ResolveUrl("~/Records/t_DonationList.aspx")
            Dim script As String = "window.open('" & url & "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)


        Else
            Session("Records") = "Search"
            Session("ItemName") = gvsearchProperty.SelectedDataKey("ItemParticular")
            Session("GL_Account") = gvsearchProperty.SelectedDataKey("GA_ID")
            ' Me.Page.Response.Redirect("~/Records/PropertyCard_v3.aspx")

            Dim url As String = ResolveUrl("~/Records/PropertyCard_v3.aspx")
            Dim script As String = "window.open('" & url & "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)

        End If
    End Sub
    Protected Sub btnReturnPro_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddPurpose.SelectedItem.Value = 0 Or ddReturnedTo.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Select from the purpose.")
            ModalPopupExtender3.Show()
            Exit Sub
        ElseIf ddPurpose.SelectedItem.Value = 1 Then
            objMREReturn.Dispose = False
            objMREReturn.Repair = False
        ElseIf ddPurpose.SelectedItem.Value = 2 Then
            objMREReturn.Dispose = True
            objMREReturn.Repair = False
        ElseIf ddPurpose.SelectedItem.Value = 3 Then
            objMREReturn.Dispose = False
            objMREReturn.Repair = True
        End If

        For i As Integer = 0 To dtissue2.Rows.Count - 1
            With objMREReturn
                .MRE_Dtl = dtissue2.Rows(i)("MREDtl_ID")
                .PropertyNo = dtissue2.Rows(i)("PropertyNo")
                .MRE_Date = txtDateReturn.Text
                .Status = "Returned"
                .Remarks = txtReturnRemarks.Text
                .Inspection = True
                .deptid = dtissue2.Rows(i)("rc_id")

                Dim dtMRet As New DataTable
                dtMRet = objDerived.GetDataTable("Select * from AMS.MRE_Returns where PropertyNo ='" & dtissue2.Rows(i)("PropertyNo") & "' ", CommandType.Text)
                If dtMRet.Rows.Count = 0 Then
                    .saveMREReturn()
                Else
                    .MRE_ReturnID = objDerived.GetValue("Select MRE_ReturnID from AMS.MRE_Returns where PropertyNo ='" & dtissue2.Rows(i)("PropertyNo") & "' ", CommandType.Text)
                    .UpdateMREReturn()
                End If
            End With

            Dim balance As Integer = Val(objDerived.GetValue("exec AMS.getbalance '" & dtissue2.Rows(i)("PropertyNo").ToString & "'", CommandType.Text))
            Dim issuance As Integer = Val(objDerived.GetValue("exec AMS.getIssuance '" & dtissue2.Rows(i)("PropertyNo").ToString & "'", CommandType.Text))
            Dim Property_ID As Integer = Val(objDerived.GetValue("exec AMS.getProperty_ID '" & dtissue2.Rows(i)("PropertyNo").ToString & "'", CommandType.Text))
            objDerived.GetRecords("Update AMS.Property set Balance='" & balance + 1 & "',Issuance='" & issuance - 1 & "' where  Property_ID='" & dtissue2.Rows(i)("Property_ID") & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Property_Dtl SET Issued ='False' WHERE PropertyNo='" & dtissue2.Rows(i)("PropertyNo") & "'", CommandType.Text)


            If dtissue2.Rows(i)("isDonated") = 1 Or dtissue2.Rows(i)("isDonated") = True Then
                '=== SAVE DONATION LEDGER
                With objDonationLedger
                    .PropertyNo = dtissue2.Rows(i)("PropertyNo")
                    .SerialNo = ""
                    .Trans_Type = "Returned" '+ " " + dtissue2.Rows(i)("PropertyNo")
                    .Ref = ""
                    .AccountablePerson = ""
                    .Department = ""
                    .Position = ""
                    .AcceptedBy = ddReturnedTo.SelectedItem.Text
                    .InspectedBy = ""
                    .dDate = txtDateReturn.Text
                    .Item_ID = dtissue2.Rows(i)("Item_ID")

                    .CreditQty = "0"
                    .CreditUnit = "-"
                    .CreditCost = "0.00"

                    .DebitQty = 1
                    .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM dbo.m_item INNER JOIN AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID where Item_ID ='" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)
                    .DebitCost = CType(dtissue2.Rows(i)("Cost"), Decimal)

                    .BalanceQty = 1
                    .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM dbo.m_item INNER JOIN AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID where Item_ID ='" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)
                    .BalanceCost = CType(dtissue2.Rows(i)("Cost"), Decimal)

                End With
                objDonationLedger.DonationLedger_ID = 0
                objDonationLedger.save()

            Else
                '==== SAVE PROPERTY LEDGER ====
                With objLedger
                    .PropertyNo = dtissue2.Rows(i)("PropertyNo")
                    .SerialNo = dtissue2.Rows(i)("SerialNo")
                    .dDate = txtDateReturn.Text
                    .Trans_Type = "Returned" '+ " " + dtissue2.Rows(i)("PropertyNo")
                    .Ref = ""
                    .AccountablePerson = ""
                    .Department = ""
                    .Position = ""
                    .AcceptedBy = ddReturnedTo.SelectedItem.Text
                    .InspectedBy = ""
                    .Item_ID = dtissue2.Rows(i)("Item_ID")

                    .DebitQty = 1
                    .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)
                    .DebitCost = CType(dtissue2.Rows(i)("Cost"), Decimal)

                    .CreditQty = "0"
                    .CreditUnit = "-"
                    .CreditCost = "0.00"

                    .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)

                    Dim eQty As Integer
                    Dim eBalance As Decimal
                    Dim dtledger As New DataTable

                    dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)
                    If dtledger.Rows.Count = 0 Then
                        eQty = 0
                        eBalance = 0.0
                    Else
                        eQty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & dtissue2.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                        eBalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & dtissue2.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                    End If

                    .BalanceQty = eQty + 1
                    .BalanceCost = CType(eBalance, Decimal) + CType(dtissue2.Rows(i)("Cost"), Decimal)
                End With

                objLedger.Ledger_ID = 0
                objLedger.save()
            End If

        Next

        '=== SAVE RETURNED HEADER HISTORY
        With Return_Hdr
            .Returned_To = ddReturnedTo.SelectedItem.Value
            .Returned_By = Session("ReturnBy")
            .Returned_Date = txtDateReturn.Text

            '=== CHECK IF ALL ITEMS BELONGS TO ONE OFFICE OR NOT
            Dim xRC As Integer = 0
            For i As Integer = 0 To dtissue2.Rows.Count - 1
                If i = 0 Then
                    xRC = dtissue2.Rows(i)("rc_id")
                Else
                    If dtissue2.Rows(i)("rc_id") = xRC Then
                        Session("VariousDept") = 0
                    Else
                        Session("VariousDept") = 1
                        Exit For
                    End If
                End If
            Next

            If Session("VariousDept") = 0 Then
                .RC_ID = dtissue2.Rows(0)("rc_id")
                .Function_ID = dtissue2.Rows(0)("function_id")
            Else
                .RC_ID = 0
                .Function_ID = 0
            End If

            .Purpose = ddPurpose.SelectedItem.Text
            .Remarks = txtReturnRemarks.Text
        End With

        Dim ReturnHdr_ID As Long = Return_Hdr.save

        '=== SAVE RETURN DETAILS
        For i As Integer = 0 To dtissue2.Rows.Count - 1
            With Return_Dtl
                .Returned_ID = ReturnHdr_ID
                .Acquired_Date = objDerived.GetValue("SELECT MRE_Date FROM AMS.MRE_Hdr WHERE MREHdr_ID = '" & dtissue2.Rows(i)("MREHdr_ID") & "'", CommandType.Text)
                .Item_ID = dtissue2.Rows(i)("Item_ID")
                .PropertyNo = dtissue2.Rows(i)("PropertyNo")
                .save()
            End With
        Next

        Session("Returned_ID") = ReturnHdr_ID

        btnpreviewAreDoc.Text = "PREVIEW PRS"
        btnpreviewAreDoc.Enabled = True

        LoadPropertyDropDown()
        LoadwithOutProperty()

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Property has been successfully returned.")

    End Sub

    Protected Sub btnsavedoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim AREnumber As Long
        AREnumber = objDerived.GetValue("Select MREHdr_ID from AMS.MRE_Hdr where MRENumber = '" & txtMRE.Text & "'", CommandType.Text)
        If AREnumber <> 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "PARE Number already exist.")
            Exit Sub
        End If

        If txtDateReceivedFrom.Text = "" Or txtDateReceivedBy.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Date are required fields.")
        Else

            '=== SAVE MRE HEADER
            With objMREHdr
                .MRE_Date = txtDateReceivedFrom.Text
                .MRE_Date_Recieve = txtDateReceivedBy.Text
                .Received_from = ddFromProperty.SelectedValue.ToString
                .MRto = ddByAcknowledgement.SelectedValue.ToString
                .Cancelled = False
                .MRENumber = txtMRE.Text

                '=== CHECK IF ALL ITEMS BELONGS TO ONE OFFICE OR NOT
                Dim xRC As Integer = 0
                For i As Integer = 0 To dtissue2.Rows.Count - 1
                    If i = 0 Then
                        xRC = dtissue2.Rows(i)("rc_id")
                    Else
                        If dtissue2.Rows(i)("rc_id") = xRC Then
                            Session("VariousDept") = 0
                        Else
                            Session("VariousDept") = 1
                            Exit For
                        End If
                    End If

                Next

                If Session("VariousDept") = 0 Then
                    .RC_ID = ddByDepartment.SelectedValue 'dtissue2.Rows(0)("rc_id")
                    .Func_ID = dtissue2.Rows(0)("function_id")
                Else
                    .RC_ID = 0
                    .Func_ID = 0
                End If
            End With

            Dim MREHDR As Long = objMREHdr.saveMREHdr()
            Session("MREHdr_ID") = MREHDR
            MRE_ID = MREHDR
            Session("Property_id") = MREHDR
            Session("MREHdr_ID_1") = MREHDR


            objDerived.GetRecords("UPDATE [AMS].[MRE_Hdr] SET [Remarks] = '" & txtARE_Remarks.Text & "' WHERE [MREHdr_ID] = '" & Session("MREHdr_ID") & "'", CommandType.Text)

            '==== SAVE RIS HEADER
            Dim RIS_Series As String
            RIS_Series = objDerived.GetValue("select AMS.func_GenerateRIS('" & txtDateReceivedFrom.Text & "')", CommandType.Text)
            Session("ris_no") = "PPE-" & RIS_Series
            hdr.RIS_No = Session("ris_no")
            hdr.RISDate = txtDateReceivedFrom.Text
            hdr.Purpose = ""
            hdr.Issued_By = objDerived.GetValue("SELECT Distinct full_name FROM HRMS.view_signatory WHERE empid = '" & ddFromProperty.SelectedValue.ToString & "'", CommandType.Text)
            'hdr.Requested_By = objDerived.GetValue("SELECT Distinct full_name FROM HRMS.view_signatory WHERE empid = '" & ddByAcknowledgement.SelectedValue.ToString & "'", CommandType.Text)
            hdr.Requested_By = objDerived.GetValue("SELECT Distinct full_name FROM HRMS.view_signatory WHERE deptid = " & ddByDepartment.SelectedItem.Value & " and division_key = 86 and isDeptHead = 'Yes'", CommandType.Text)
            hdr.Received_By = objDerived.GetValue("SELECT Distinct full_name FROM HRMS.view_signatory WHERE empid = '" & ddByAcknowledgement.SelectedValue.ToString & "'", CommandType.Text)
            hdr.withICS = False

            If CheckBox3.Checked = True Then
                hdr.Approved_By = Session("ApprovedBy")
            Else
                hdr.Approved_By = objDerived.GetValue("SELECT Distinct full_name FROM HRMS.view_signatory WHERE deptid = 7 and division_key = 86 and isDeptHead = 'Yes'", CommandType.Text)
            End If

            '=== CHECK IF ALL ITEMS BELONGS TO ONE OFFICE OR NOT
            Dim oRC As Integer = 0
            For i As Integer = 0 To dtissue2.Rows.Count - 1
                If i = 0 Then
                    oRC = dtissue2.Rows(i)("rc_id")
                Else
                    If dtissue2.Rows(i)("rc_id") = oRC Then
                        Session("VariousDept") = 0
                    Else
                        Session("VariousDept") = 1
                        Exit For
                    End If
                End If
            Next

            If Session("VariousDept") = 0 Then
                hdr.RC_ID = dtissue2.Rows(0)("rc_id")
                hdr.Func_ID = dtissue2.Rows(0)("function_id")
            Else
                hdr.RC_ID = 0
                hdr.Func_ID = 0
            End If

            Dim hdrid As Long = hdr.saveRISHdr()


            For i As Integer = 0 To dtissue2.Rows.Count - 1
                '==== SAVE MRE DETAILS ====
                objMREDtl.MREHdr_ID = MREHDR
                objMREDtl.PropertyNo = dtissue2.Rows(i)("PropertyNo")
                Dim MREDtlID As Long = objMREDtl.saveMREDtl()


                '=== SAVE MRE RETURNS

                With objMREReturn
                    .MRE_Dtl = MREDtlID
                    .PropertyNo = dtissue2.Rows(i)("PropertyNo")
                    .MRE_Date = txtDateReceivedBy.Text
                    .Status = "On Hand"
                    .Remarks = "Issued"
                    .Dispose = False
                    .Repair = False
                    .Inspection = False
                    .deptid = ddByDepartment.SelectedValue
                    .UserID = Session("@UserName")

                    Dim dtReturn As New DataTable
                    dtReturn = objDerived.GetDataTable("Select * from AMS.MRE_Returns where PropertyNo ='" & dtissue2.Rows(i)("PropertyNo") & "'", CommandType.Text)
                    If dtReturn.Rows.Count = 0 Then
                        .saveMREReturn()
                    Else
                        .MRE_ReturnID = objDerived.GetValue("Select MRE_ReturnID from AMS.MRE_Returns where PropertyNo ='" & dtissue2.Rows(i)("PropertyNo") & "'", CommandType.Text)
                        .UpdateMREReturn()
                    End If

                End With

                '=== SAVE RIS DETAILS
                dtl.RISHdr_ID = hdrid
                dtl.Item_ID = dtissue2.Rows(i)("Item_ID")
                dtl.AvailableQty = 1
                dtl.ApprovedQty = 1
                dtl.Cost = CType(dtissue2.Rows(i)("Cost"), Decimal)
                dtl.Remarks = ""
                dtl.saveRISDtl()

                Dim dtlID As Long = objDerived.GetValue("SELECT MAX(RISDtl_ID) FROM AMS.RIS_Dtl", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.RIS_Dtl SET PropertyDetai_ID = '" & dtissue2.Rows(i)("PropertyDetai_ID") & "' WHERE RISDtl_ID = '" & dtlID & "'", CommandType.Text)


                '=== UPDATE PROPERTY TABLES (HDR AND DTL)
                Dim balance As Integer = Val(objDerived.GetValue("exec AMS.getbalance '" & dtissue2.Rows(i)("PropertyNo") & "'", CommandType.Text))
                Dim issuance As Integer = Val(objDerived.GetValue("exec AMS.getIssuance '" & dtissue2.Rows(i)("PropertyNo") & "'", CommandType.Text))
                Dim Property_ID As Integer = Val(objDerived.GetValue("exec AMS.getProperty_ID '" & dtissue2.Rows(i)("PropertyNo") & "'", CommandType.Text))
                objDerived.GetRecords("Update AMS.Property set Balance='" & balance - 1 & "',Issuance='" & issuance + 1 & "' where  Property_ID='" & Property_ID & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.Property_Dtl SET Issued ='True' WHERE PropertyNo='" & dtissue2.Rows(i)("PropertyNo").ToString & "'", CommandType.Text)

                If dtissue2.Rows(i)("isDonated") = 1 Or dtissue2.Rows(i)("isDonated") = True Then
                    '===== DONATION LEDGER
                    dtDonationLedger = objDonationLedger.GetDataTable("Select DonationLedger_ID from AMS.TbDonation_Ledger", CommandType.Text)
                    With objDonationLedger
                        '.DonationLedger_ID = DonationLedger_ID
                        .PropertyNo = dtissue2.Rows(i)("PropertyNo")
                        .SerialNo = ""
                        .Trans_Type = "Issuance"
                        .Ref = txtMRE.Text
                        .AccountablePerson = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory where empid ='" & ddByAcknowledgement.SelectedValue & "'", CommandType.Text)
                        .Department = ddByDepartment.SelectedItem.Text
                        .Position = ""
                        .AcceptedBy = ""
                        .InspectedBy = ""
                        .Item_ID = dtissue2.Rows(i)("Item_ID")

                        .DebitQty = "0"
                        .DebitUnit = "-"
                        .DebitCost = "0.00"

                        .CreditQty = 1
                        .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM dbo.m_item INNER JOIN AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID where Item_ID ='" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)
                        .CreditCost = CType(dtissue2.Rows(i)("Cost"), Decimal)

                        .BalanceQty = 0
                        .BalanceUnit = "-"
                        .BalanceCost = CType(0, Decimal)
                        .dDate = txtDateReceivedFrom.Text


                    End With
                    objDonationLedger.DonationLedger_ID = 0
                    objDonationLedger.save()

                Else
                    '==== PROPERTY LEDGER
                    dtPropLedger = objLedger.GetDataTable("Select Ledger_ID from AMS.TbProperty_Ledger", CommandType.Text)
                    With objLedger
                        '.Ledger_ID = Ledger_ID
                        .PropertyNo = dtissue2.Rows(i)("PropertyNo")
                        .SerialNo = dtissue2.Rows(i)("SerialNo").ToString
                        .dDate = txtDateReceivedFrom.Text
                        .Trans_Type = "Issuance"
                        .Ref = txtMRE.Text
                        .Item_ID = dtissue2.Rows(i)("Item_ID")
                        .AccountablePerson = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory where empid ='" & ddByAcknowledgement.SelectedValue & "'", CommandType.Text)
                        .Department = ddByDepartment.SelectedItem.Text
                        .Position = ""
                        .AcceptedBy = ""
                        .InspectedBy = ""

                        .DebitQty = "0"
                        .DebitUnit = "-"
                        .DebitCost = "0.00"

                        .CreditQty = 1
                        .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)
                        .CreditCost = CType(dtissue2.Rows(i)("Cost"), Decimal)

                        .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)

                        Dim eQty As Integer
                        Dim eBalance As Decimal
                        Dim dtledger As New DataTable

                        dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)
                        If dtledger.Rows.Count = 0 Then
                            eQty = 0
                            eBalance = 0.0
                        Else
                            eQty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & dtissue2.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                            eBalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & dtissue2.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                        End If

                        .BalanceQty = eQty - 1
                        .BalanceCost = CType(eBalance, Decimal) - CType(dtissue2.Rows(i)("Cost"), Decimal)
                    End With

                    objLedger.Ledger_ID = 0
                    objLedger.save()
                End If

            Next


            btnsavedoc.Enabled = False
            btnADD.Enabled = False
            btnpreview.Enabled = True
            btnPreviewRIS.Enabled = True

            btnpreviewAreDoc.Enabled = True

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Transaction has been successfully saved.")

            'LoadPropertyDropDown()
            'LoadwithOutProperty()

        End If
    End Sub
    Protected Sub btncancelDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Page.Response.Redirect("~/etc/body.aspx")
        Me.Page.Response.Redirect("~/Inventory/t_RequisitionAndIssunace.aspx")

    End Sub
    Protected Sub btnpreviewAreDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnpreviewAreDoc.Text = "PREVIEW PRS" Then
            'Me.Page.Response.Redirect("~/Inventory/t_rpt_return_slip.aspx")

            Dim url As String = "t_rpt_return_slip.aspx?"
            Dim fullURL As String = "window.open('" & url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        ElseIf btnpreviewAreDoc.Text = "PREVIEW PARE" Then
            ' Session("MREHdr_ID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
            'Session("MREHdr_ID") = MRE_ID
            'Dim a As String = grListOfProperty.SelectedDataKey("MREHdr_ID")
            ''Me.Page.Response.Redirect("~/Inventory/t_rpt_acknowledgement_receipt.aspx")
            'Session("MREHdr_ID") = MRE_ID
            Dim url As String = "t_rpt_acknowledgement_receipt.aspx?"
            Dim fullURL As String = "window.open('" & url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        End If


    End Sub
    Protected Sub btnAddDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim filePath As String = hdfinspection.Value
        Dim filename As String = Path.GetFileName(filePath)
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
        br.Close()
        fs.Close()
        If Me.hdfinspection.Value <> "" Then
            'image.Issuance_ID = Issuance_ID
            image.DocuID = grListOfProperty.SelectedDataKey("PropertyDetai_ID")
            image.Item_ID = grListOfProperty.SelectedDataKey("Item_ID")
            image.Property_ID = grListOfProperty.SelectedDataKey("Property_ID")
            image.ImageFile = bytes
            image.DocumentName = txtdocname.Text
            image.PropertyNo = txtPropertyNo.Text
            image.ValidatedBy = txtValidatedBy.Text
            If txtDatevalidated.Text = "" Then
                image.DateValidated = Date.Today.ToString("MM/dd/yyyy")
            Else
                image.DateValidated = txtDatevalidated.Text
            End If
            image.TableName = "Issuance"

            Dim Id As Long = image.SaveImage()
            imgDocPreview.ImageUrl = "~/Handler/ShowImage.ashx?id=" & Id
        End If

        'btnADD.Enabled = False
        'Dim DocumentDta As New DataTable
        'Try
        '    DocumentDta = objDerived.GetDataTable("Select DocumentName,PropertyName,ValidateBy,convert(varchar(20),DateValidated,101) as DateValidated,convert(int , BuildingDocumentID) as BuildingDocumentID from BPAS.BuildingDocument where BldgID=" & Session("itemId") & "  ", CommandType.Text)
        'Catch ex As Exception
        'End Try
        'If DocumentDta.Rows.Count < 4 Then
        '    DocumentDta.Merge(CreatedatatableScannedDoc(4))
        '    gvDocumentAdded.DataSource = DocumentDta
        '    gvDocumentAdded.DataBind()
        'Else
        '    gvDocumentAdded.DataSource = DocumentDta
        '    gvDocumentAdded.DataBind()
        'End If
        LoadAttchDocu()
    End Sub
    Protected Sub btndoccancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/Inventory/t_RequisitionAndIssunace.aspx")
    End Sub
    Protected Sub LoadAttchDocu()
        Dim dtAttchDoc As New DataTable
        dtAttchDoc = objDerived.GetDataTable("Select * from AMS.TbIssuanceAttch where DocuID = '" & grListOfProperty.SelectedDataKey("PropertyDetai_ID") & "' and TableName = 'Issuance'", CommandType.Text)
        Dim rows As New Integer
        rows = dtAttchDoc.Rows.Count
        dtAttchDoc.Merge(CreatedatatableScannedDoc(4 - rows))
        gvDocumentAdded.DataSource = dtAttchDoc
        gvDocumentAdded.DataBind()
        gvDocumentAdded.SelectedIndex = 0
        LoadAttchSelectedIndex()
    End Sub
    Protected Sub LoadNoAttchment()
        gvDocumentAdded.DataSource = CreatedatatableScannedDoc(4)
        gvDocumentAdded.DataBind()

        imgDocPreview.ImageUrl = "~/images/Blankimage.jpg"
    End Sub
    Protected Sub gvDocumentAdded_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadAttchSelectedIndex()
    End Sub
    Protected Sub LoadAttchSelectedIndex()
        Try
            Dim id As New Integer
            id = gvDocumentAdded.SelectedDataKey("DocuID").ToString
            imgDocPreview.ImageUrl = "~/Handler/ShowIssuanceAttchment.ashx?id=" & id
        Catch ex As Exception
            imgDocPreview.ImageUrl = "~/images/Blankimage.jpg"
        End Try
    End Sub
    Protected Sub gvDocumentAdded_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvDocumentAdded, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub


    'RIS



    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnSearch_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True

            Dim myview As DataView
            myview = pItems.DefaultView
            myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtsearchitems.Text.ToString) & "%' and isUsed = 'False'"
            gvitems.DataSource = myview
            gvitems.DataBind()
            gvitems.PageIndex = 0

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False



            btnADD.Enabled = True
            ModalPopupExtender1.Show()
        Catch ex As Exception

        End Try

    End Sub



    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb2 As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb2.NamingContainer, GridViewRow)

        If cb2.Checked = True Then
            pItems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text)("isChecked") = True

        Else
            pItems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text)("isChecked") = False

        End If

    End Sub


    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                    pItems.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isChecked") = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
                pItems.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isChecked") = False
            Next
        End If

        ModalPopupExtender1.Show()
    End Sub


    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvitems.PageIndexChanging
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.PageIndex = e.NewPageIndex
        gvitems.DataSource = CType(pItems, DataTable)
        gvitems.DataBind()
        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.SelectedIndex = -1

        ModalPopupExtender1.Show()

    End Sub
    Protected Sub btnload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnload.Click
        Try
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(7).Visible = True

            Dim dt As New DataTable
            Dim dr As DataRow
            Dim cb As CheckBox

            dt.Columns.Add("Item_Desc", GetType(String))
            dt.Columns.Add("Description", GetType(String))
            dt.Columns.Add("Item_ID")
            dt.Columns.Add("qty", GetType(Integer))
            dt.Columns.Add("qty2", GetType(Integer))
            dt.Columns.Add("cost", GetType(Decimal))
            dt.Columns.Add("total", GetType(Decimal))
            dt.Columns.Add("stockID")

            For i As Integer = 0 To Me.pItems.Rows.Count - 1
                If pItems.Rows(i)("isChecked") = True Then
                    Dim dta As DataTable
                    dta = pItems
                    If pbody Is Nothing Then
                        dr = dt.NewRow()
                        dr("Item_Desc") = pItems.Rows(i)("Item_Desc")
                        dr("Description") = pItems.Rows(i)("Description")
                        dr("Item_ID") = pItems.Rows(i)("Item_ID")
                        dr("qty") = pItems.Rows(i)("balance")
                        dr("qty2") = 0
                        dr("cost") = pItems.Rows(i)("cost")
                        dr("total") = "0.00"
                        dr("stockID") = pItems.Rows(i)("stockID")
                        dt.Rows.Add(dr)

                        pItems.Rows(i)("isUsed") = True
                        pItems.Rows(i)("isChecked") = False

                        pbody = dt

                    Else
                        dt = pbody
                        dr = dt.NewRow()
                        dr("Item_Desc") = pItems.Rows(i)("Item_Desc")
                        dr("Description") = pItems.Rows(i)("Description")
                        dr("Item_ID") = pItems.Rows(i)("Item_ID")
                        dr("qty") = pItems.Rows(i)("balance")
                        dr("qty2") = 0
                        dr("cost") = pItems.Rows(i)("cost")
                        dr("total") = "0.00"
                        dr("stockID") = pItems.Rows(i)("stockID")
                        dt.Rows.Add(dr)

                        pItems.Rows(i)("isUsed") = True
                        pItems.Rows(i)("isChecked") = False

                        pbody = dt
                    End If
                End If
            Next

            Dim myview As DataView
            myview = pItems.DefaultView
            myview.RowFilter = "isUsed = false"
            gvitems.DataSource = myview
            gvitems.DataBind()

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False

            gvbody.DataSource = pbody
            gvbody.DataBind()
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                Dim qty As TextBox = CType(Me.gvbody.Rows(i).FindControl("txtQty"), TextBox)
                qty.Attributes.Add("onFocus", "this.select()")
                qty.Attributes.Add("onClick", "this.select()")
                If i = 0 Then
                    qty.Focus()
                End If
            Next
            If pbody.Compute("sum(total)", "") = 0 Then
                gvbody.FooterRow.Cells(6).Text = "0.00"
            Else
                gvbody.FooterRow.Cells(6).Text = FormatNumber(pbody.Compute("sum(total)", ""), 2)
            End If

            btnADD.Enabled = True
            btnsave.Enabled = True


            ModalPopupExtender1.Show()

        Catch ex As Exception

        End Try
        'Refactor


        'Try
        '    ' Show columns in grid view
        '    gvitems.Columns(3).Visible = True
        '    gvitems.Columns(4).Visible = True
        '    gvitems.Columns(7).Visible = True

        '    ' Create data table and add columns
        '    Dim dt As New DataTable
        '    With dt.Columns
        '        .Add("Item_Desc", GetType(String))
        '        .Add("Description", GetType(String))
        '        .Add("Item_ID", GetType(Integer))
        '        .Add("qty", GetType(Integer))
        '        .Add("qty2", GetType(Integer))
        '        .Add("cost", GetType(Decimal))
        '        .Add("total", GetType(Decimal))
        '        .Add("stockID", GetType(Integer))
        '    End With

        '    ' Loop through rows in pItems datatable
        '    For Each row As DataRow In pItems.Rows
        '        ' Check if row is selected
        '        If row("isChecked") = True Then
        '            ' Add row to data table
        '            Dim newRow As DataRow = dt.NewRow()
        '            With newRow
        '                .Item("Item_Desc") = row("Item_Desc")
        '                .Item("Description") = row("Description")
        '                .Item("Item_ID") = row("Item_ID")
        '                .Item("qty") = row("balance")
        '                .Item("qty2") = 0
        '                .Item("cost") = row("cost")
        '                .Item("total") = "0.00"
        '                .Item("stockID") = row("stockID")
        '            End With
        '            dt.Rows.Add(newRow)

        '            ' Update pItems row values
        '            row("isUsed") = True
        '            row("isChecked") = False
        '        End If
        '    Next

        '    ' Filter pItems datatable and bind to grid view
        '    Dim myview As DataView = pItems.DefaultView
        '    myview.RowFilter = "isUsed = false"
        '    gvitems.DataSource = myview
        '    gvitems.DataBind()

        '    ' Hide/show columns in grid view
        '    gvitems.Columns(3).Visible = False
        '    gvitems.Columns(4).Visible = False
        '    gvitems.Columns(5).Visible = True
        '    gvitems.Columns(6).Visible = False
        '    gvitems.Columns(7).Visible = False

        '    ' Bind data table to grid view
        '    gvbody.DataSource = dt
        '    gvbody.DataBind()

        '    ' Add onFocus and onClick attributes to quantity textboxes
        '    For Each row As GridViewRow In gvbody.Rows
        '        Dim qty As TextBox = CType(row.FindControl("txtQty"), TextBox)
        '        qty.Attributes.Add("onFocus", "this.select()")
        '        qty.Attributes.Add("onClick", "this.select()")
        '        If row.RowIndex = 0 Then
        '            qty.Focus()
        '        End If
        '    Next

        '    ' Calculate and display total in footer row
        '    Dim total As Decimal = dt.Compute("sum(total)", "")
        '    gvbody.FooterRow.Cells(6).Text = If(total = 0, "0.00", FormatNumber(total, 2))

        '    ' Enable buttons and show modal popup
        '    btnADD.Enabled = True
        '    btnsave.Enabled = True
        '    ModalPopupExtender1.Show()

        'Catch ex As Exception
        '    ' Handle exceptions here
        'End Try

    End Sub




    Public Sub gridEnable()
        Dim cb, cbheader As CheckBox
        Dim itemid As String
        Dim txt As Integer
        Dim gv As New GridView
        gv.DataSource = pbody
        gv.DataBind()
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        Dim countE As Integer = 0
        For i As Integer = 0 To Me.gvitems.Rows.Count - 1

            itemid = Me.gvitems.Rows(i).Cells(3).Text
            cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            For o As Integer = 0 To gv.Rows.Count - 1
                txt = CType(gv.Rows(o).Cells(2).Text, Integer)

                If txt = CType(itemid.ToString, Integer) Then
                    cb.Checked = False
                    cb.Enabled = False
                    countE = countE + 1
                End If
            Next
        Next

        If countE = 10 Then
            CType(Me.gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Checked = False
        Else
            CType(Me.gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Checked = True
        End If
        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False


    End Sub
    Protected Sub txtqty_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtqty As TextBox = TryCast(sender, TextBox)
            If txtqty.Text = "" Then
                txtqty.Text = "0"
            End If

            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            Dim data As DataTable = pbody

            If CType(pbody.Rows(gvr.RowIndex)("Balance"), Integer) >= CType(txtqty.Text, Integer) Then

                pbody.Rows(gvr.RowIndex)("Issuance") = txtqty.Text
                pbody.Rows(gvr.RowIndex)("total") = pbody.Rows(gvr.RowIndex)("Cost") * txtqty.Text
                gvbody.Rows(gvr.RowIndex).Cells(6).Text = FormatNumber(pbody.Rows(gvr.RowIndex)("total"), 2)
                gvbody.FooterRow.Cells(6).Text = FormatNumber(pbody.Compute("sum(total)", ""), 2)

            Else

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Quantity must not exceed to the available quantity.")
                txtqty.Text = 0

                pbody.Rows(gvr.RowIndex)("total") = txtqty.Text * CType(pbody.Rows(gvr.RowIndex)("cost"), Decimal)
                gvbody.Rows(gvr.RowIndex).Cells(6).Text = FormatNumber(txtqty.Text * CType(pbody.Rows(gvr.RowIndex)("cost"), Decimal), 2)
                gvbody.FooterRow.Cells(6).Text = FormatNumber(pbody.Compute("sum(total)", ""), 2)

            End If

            btnADD.Enabled = True
            btnsave.Enabled = True

        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnCopyValues_Click(sender As Object, e As EventArgs) Handles btnCopyValues.Click
        Try
            For i As Integer = 0 To gvbody.Rows.Count - 1
                CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text = pbody.Rows(i)("Balance")

                pbody.Rows(i)("Issuance") = pbody.Rows(i)("Balance")
                pbody.Rows(i)("total") = pbody.Rows(i)("Cost") * pbody.Rows(i)("Balance")

                gvbody.Rows(i).Cells(6).Text = FormatNumber(pbody.Rows(i)("total"), 2)
                gvbody.FooterRow.Cells(6).Text = FormatNumber(pbody.Compute("sum(total)", ""), 2)
            Next

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnnew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnew.Click

    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtReceivedBy.Text <> "" And txtremarks.Text <> "" And txtdate.Text <> "" Then
            objDerived.Execute("INSERT INTO AMS.EISHDR (RISHdr_ID,RIS_No,RISDate,Purpose,Approved_By,Issued_By,Received_By,RC_ID,Func_ID,F_ID,GA_ID)values('" _
                                & 0 & "','" & 0 & "','" & txtdate.Text & "','" _
                                & txtremarks.Text & "','" & drpApprovedBy.SelectedItem.Text & "','" & ddIssuedby.SelectedItem.Text & "','" _
                               & txtReceivedBy.Text & "','" & drpSearh_Department.SelectedItem.Value & "','86','0','" & dtGenAccount.Rows(ddSupplies.SelectedIndex - 1)("GA_ID") & "')", CommandType.Text)
            Dim EISHdr_ID As Integer
            EISHdr_ID = objDerived.GetValue("select max(EISHdr_ID) from AMS.EISHDR", CommandType.Text)

            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                If pbody.Rows(i)("Issuance") <> "0" Then
                    objDerived.Execute("INSERT INTO AMS.EISDTL (ApprovedQty,Item_ID,RISHdr_ID,EISHdr_ID,Cost,StockID,Remarks)VALUES('" _
                                       & pbody.Rows(i)("Issuance") & "','" & pbody.Rows(i)("item_id") & "','0','" _
                                       & EISHdr_ID & "','" & pbody.Rows(i)("Cost") & "','" _
                                       & pbody.Rows(i)("StockID") & "','" & CType(gvbody.Rows(i).FindControl("txtRemarks"), TextBox).Text & "')", CommandType.Text)



                    objDerived.Execute("INSERT INTO AMS.TbStock_Ledger_Per_Employee (StockID,Item_ID,Trans_Type,Ref_No,Accountable_Person,Department,ReceivedBy,Issued_Qty,Cost,RC_ID,GA_ID,tDate)values('" _
                                       & pbody.Rows(i)("StockID") & "','" & pbody.Rows(i)("item_id") & "','Issuance','" & txtRIS.Text & "','" _
                                       & drpApprovedBy.SelectedItem.Text & "','" & drpSearh_Department.SelectedItem.Text & "','" _
                                       & txtReceivedBy.Text & "','" & pbody.Rows(i)("Issuance") & "','" _
                                       & pbody.Rows(i)("Cost") & "','" & drpSearh_Department.SelectedItem.Value & "','" _
                                       & dtGenAccount.Rows(ddSupplies.SelectedIndex - 1)("GA_ID") & "','" & txtdate.Text & "')", CommandType.Text)
                Else

                End If
            Next



            btnpreview.Enabled = True
            btnPreviewICS.Enabled = True

            btnsave.Enabled = False

            txtremarks.ReadOnly = True

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Transaction has been successfully saved.")

            btnADD.Enabled = False

            'LoadMainRIS()
            LoadItemList()
            LoadLeadger()

        End If
    End Sub

    Protected Sub DropDownList11_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub gvopen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        Session("Page") = "INV"
        Session("Report") = "RIS"
        'Me.Page.Response.Redirect("~/MainReports/Inventory_Reports.aspx")

        Dim url As String = "Inventory_Reports.aspx"
        Dim fullURL As String = "window.open('" & url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
    Protected Sub txtsearchitems_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try


            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            Me.gvitems.DataSource = objDerived.Search(pItems, "Item_Desc", txtsearchitems.Text)
            Me.gvitems.DataBind()
            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False

            gvitems.SelectedIndex = -1
            gvitems.PageIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddFromDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub txtDateReceivedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Convert.ToDateTime(Me.txtDateReceivedFrom.Text) > Convert.ToDateTime(Me.txtDateReceivedBy.Text) Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Date Not be less than the Date Receive")
        'End If
    End Sub
    Protected Sub txtDateReceivedBy_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateReceivedBy.Unload

    End Sub
    Protected Sub btninspectionBrowse_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnReturnProperty_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub ddSupplies_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddSupplies.SelectedIndexChanged


    End Sub

    Protected Sub btnADD_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ModalPopupExtender1.Show()
    End Sub
    Protected Sub gvitems_SelectedIndexChanged3(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub gvSupplyList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        'If ddSupplies.SelectedItem.Value = 1427 Then
        '    '=== 5-02-03-010  Office Supplies Expenses
        '    txtCategoryCode.Text = "OS"

        'ElseIf ddSupplies.SelectedItem.Value = 1443 Then
        '    '=== 5-02-03-990 Other Supplies and Materials Expenses
        '    txtCategoryCode.Text = "JS"

        'ElseIf ddSupplies.SelectedItem.Value = 1433 Then
        '    '=== 5-02-03-080 Medical, Dental and Laboratory Supplies Expenses
        '    txtCategoryCode.Text = "MDLS"

        'ElseIf ddSupplies.SelectedItem.Value = 1432 Then
        '    '=== 5-02-03-070 Drugs and Medicines Expenses
        '    txtCategoryCode.Text = "MDS"
        'Else
        '    txtCategoryCode.Text = "OTS"
        'End If










        txtremarks.Text = ""
        txtdate.Text = Date.Today.ToString("MM/dd/yyyy")

        pbody = Nothing
        gvbody.DataSource = pbody
        gvbody.DataBind()

    End Sub

    Protected Sub gvSupplyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvSupplyList, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub txtdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'txtRIS.Text = objDerived.GetValue("select AMS.func_GenerateRIS('" & txtdate.Text & "')", CommandType.Text)
    End Sub



    Protected Sub ddByDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles ddByDepartment.SelectedIndexChanged

        Dim x As String = ddByDepartment.SelectedItem.Text
        ddByAcknowledgement.Items.Clear()

        ddByAcknowledgement.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE deptid = '" & ddByDepartment.SelectedValue & "'", CommandType.Text)
        ddByAcknowledgement.Items.Add("Select")
        ddByAcknowledgement.DataTextField = ("full_name")
        ddByAcknowledgement.DataValueField = ("empid")
        ddByAcknowledgement.DataBind()
    End Sub

    Protected Sub gvSupplyList_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If Session("SuppliesSearch") = 0 Then
            gvSupplyList.DataSource = dtSupplies
            gvSupplyList.PageIndex = e.NewPageIndex
            gvSupplyList.DataBind()
            gvSupplyList.SelectedIndex = -1

        ElseIf Session("SuppliesSearch") = 1 Then
            Dim myview As DataView
            myview = dtSupplies.DefaultView

            If ddSuppliesSearch.SelectedItem.Value = 2 Then
                myview.RowFilter = "Item_Code like '%" & replaceapostrophe(txtSupplySearch1.Text) & "%'"
            Else
                myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtSupplySearch1.Text) & "%'"
            End If

            gvSupplyList.DataSource = myview
            gvSupplyList.DataBind()
            gvSupplyList.SelectedIndex = -1
        End If

        gvSupplyList.Columns(5).Visible = False
    End Sub

    Protected Sub btnReturnProperty_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        txtReturnRemarks.Text = ""
    End Sub

    Protected Sub btnSupplySearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If ddSupplies.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Select specific general account.")
        Else
            Dim myview As DataView
            myview = dtSupplies.DefaultView

            If ddSuppliesSearch.SelectedItem.Value = 2 Then
                myview.RowFilter = "Item_Code like '%" & replaceapostrophe(txtSupplySearch1.Text) & "%'"
            Else
                myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtSupplySearch1.Text) & "%'"
            End If

            gvSupplyList.DataSource = myview
            gvSupplyList.DataBind()

            Session("SuppliesSearch") = 1
            gvSupplyList.Columns(5).Visible = False
        End If


    End Sub

    Protected Sub btnReturnProperty_Click2(ByVal sender As Object, ByVal e As System.EventArgs)
        txtDateReturn.Text = Date.Today.ToString("MM/dd/yyyy")

        ddReturnedTo.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE deptid = 7 AND division_key = 86", CommandType.Text)
        ddReturnedTo.DataTextField = ("full_name")
        ddReturnedTo.DataValueField = ("empid")
        ddReturnedTo.DataBind()
        ddReturnedTo.Items.Insert(0, "Select")

        Session("MREHdr_ID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
        ModalPopupExtender3.Show()

        ddPurpose.SelectedItem.Value = 0
    End Sub

    Protected Sub ddPurpose_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ModalPopupExtender3.Show()
    End Sub

    Protected Sub ddIssuedby_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'ddIssuedby.Enabled = False
        btnADD.Enabled = True
    End Sub



    Protected Sub btnPreviewICS_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Page.Response.Redirect("~/Inventory/t_rpt_InventoryCustodianSlip.aspx")
        ''Here 1
        'Session("Page") = "ICS"
        'Dim url As String = "../MainReports/Inventory_Reports.aspx"
        'Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        'ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)


        Session("Page") = "INV"
        Session("Report") = "ICS"
        'Me.Page.Response.Redirect("~/MainReports/Inventory_Reports.aspx")

        Dim url As String = "Inventory_Reports.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub

    Protected Sub btnPreviewRIS_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Page.Response.Redirect("~/Inventory/t_rpt_requisition_and_issuance.aspx")
        Session("Page") = "INV"
        Session("Report") = "RIS"
        Me.Page.Response.Redirect("~/MainReports/Inventory_Reports.aspx")
    End Sub

    Protected Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Session("OLDInventory") = True
        Dim Governor As String = "DEPARTMENT HEAD"
        ''ddPrevMayor.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE deptid = 1 AND division_key = 86 AND position_desc like '%" & Governor & "%'", CommandType.Text)

        ddPrevMayor.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE RC_Name = 'PROVINCIAL GENERAL SERVICES OFFICE' ", CommandType.Text)


        ddPrevMayor.DataTextField = ("full_name")
        ddPrevMayor.DataValueField = ("empid")
        ddPrevMayor.DataBind()
        ddPrevMayor.Items.Insert(0, "Select")

        If CheckBox3.Checked = True Then
            ModalPopupExtender2.Show()
        End If

        txtMRE.ReadOnly = False
    End Sub

    Protected Sub btnRIS_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadRIS_Tab()
    End Sub

    Protected Sub LoadRIS_Tab()
        Me.mvIssuance.SetActiveView(Me.vwRIS)
        btnRIS.CssClass = "Clicked"
        btnARE.CssClass = "Initial"

        gvSupplyList.DataSource = CreateDataTable_Supplies(5)
        gvSupplyList.DataBind()
        gvSupplyList.SelectedIndex = -1

        gvSupplyList.Columns(5).Visible = False
    End Sub

    Protected Sub btnARE_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.mvIssuance.SetActiveView(Me.vwARE)
        btnRIS.CssClass = "Initial"
        btnARE.CssClass = "Clicked"
    End Sub

    Protected Sub ddReturnedTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ModalPopupExtender3.Show()
    End Sub

    Protected Sub txtDateReceivedFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CheckBox3.Checked = False Then
            txtMRE.Text = objDerived.GetValue("select AMS.func_GenerateMRE('" & txtDateReceivedFrom.Text & "')", CommandType.Text)
        End If
        btnsavedoc.Enabled = True
        btncancelDoc.Enabled = True
    End Sub

    Protected Sub ddPrevMayor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("ApprovedBy") = ddPrevMayor.SelectedItem.Text
        ModalPopupExtender2.Show()

    End Sub

    Protected Sub LoadBarcode()
        Dim barcode As New OnBarcode.Barcode.Linear
        Barcode1 = grListOfProperty.SelectedDataKey("PropertyNo")
        Session("PropertyNo") = Barcode1
        barcode.Type = OnBarcode.Barcode.BarcodeType.CODE128A
        barcode.Data = Barcode1

        Dim conStr As String = ConfigurationManager.ConnectionStrings("constr").ToString
        Dim con As New SqlConnection(conStr)

        Dim strPath As String = AppDomain.CurrentDomain.BaseDirectory & "BarcodeImages\"

        Dim strdirectory As String = strPath
        barcode.drawBarcode(strPath & Barcode1 & ".png")
        imgBarcode.ImageUrl = "~\BarcodeImages\" & Barcode1 & ".png"

        Dim fName As String

        fName = strPath & Barcode1 & ".png" 'AppDomain.CurrentDomain.BaseDirectory & imgBarcode.ImageUrl '"~\BarcodeImages\" & Barcode1 & ".png"
        If File.Exists(fName) Then
            Dim content As Byte() = ImageToStream(fName)
            con.Open()

            Dim dtpropertyno As DataTable
            dtpropertyno = objDerived.GetDataTable("Select PropertyNo from dbo.Property_Barcode where PropertyNo like '" & Barcode1 & "'", CommandType.Text)
            If dtpropertyno.Rows.Count = 0 Then
                Dim cmd As New SqlCommand("insert into Property_Barcode values ( @id,@img)", con)
                cmd.Parameters.AddWithValue("@id", Barcode1)
                cmd.Parameters.AddWithValue("@img", content)
                cmd.ExecuteNonQuery()
            End If
            con.Close()
            'MsgBox("Image inserted")
        Else
            'MsgBox(fName & " not found ")
        End If
        mpeBarcode.Show()
    End Sub
    Private Function ImageToStream(ByVal fileName As String) As Byte()
        Dim stream As New MemoryStream()

        Try
            Dim image As New Bitmap(fileName)
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception

        End Try

        Return stream.ToArray()
    End Function

    Protected Sub btnBarcode_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadBarcode()
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim url As String = "Barcode_Popup.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=0,scrollbars=0,width=450,height=200,left=400,top=200');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub

    Protected Sub btnADD_Item_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dttemp As New DataTable
        Try
            If grdIssueItems.Rows.Count <= 0 Then
                dtissue2 = Nothing
                Dim dt As New DataTable
                Dim dr As DataRow

                dt.Columns.Add("Item_Desc", GetType(String))
                dt.Columns.Add("PropertyNo", GetType(String))
                dt.Columns.Add("PropertyDate", GetType(String))
                dt.Columns.Add("Cost", GetType(Decimal))
                dt.Columns.Add("rc_name", GetType(String))
                dt.Columns.Add("Status", GetType(String))
                dt.Columns.Add("Item_ID", GetType(Long))
                dt.Columns.Add("PropertyDetai_ID", GetType(Long))
                dt.Columns.Add("rc_id", GetType(Long))
                dt.Columns.Add("function_id", GetType(Long))
                dt.Columns.Add("Property_ID", GetType(Long))
                dt.Columns.Add("isDonated", GetType(Boolean))
                dt.Columns.Add("SerialNo", GetType(String))
                dt.Columns.Add("status", GetType(String))
                dt.Columns.Add("MREDtl_ID", GetType(Long))
                dt.Columns.Add("MREHdr_ID", GetType(Long))

                dr = dt.NewRow
                dr("Item_Desc") = grListOfProperty.SelectedDataKey("Item_Desc")
                dr("PropertyNo") = grListOfProperty.SelectedDataKey("PropertyNo")
                dr("PropertyDate") = grListOfProperty.SelectedDataKey("PropertyDate")
                dr("Cost") = grListOfProperty.SelectedDataKey("Cost")
                dr("rc_name") = grListOfProperty.SelectedDataKey("Rc_name")
                dr("Status") = grListOfProperty.SelectedDataKey("status")
                dr("Item_ID") = grListOfProperty.SelectedDataKey("Item_ID")
                dr("PropertyDetai_ID") = grListOfProperty.SelectedDataKey("PropertyDetai_ID")
                dr("rc_id") = grListOfProperty.SelectedDataKey("rc_id")
                dr("function_id") = grListOfProperty.SelectedDataKey("function_id")
                dr("Property_ID") = grListOfProperty.SelectedDataKey("Property_ID")
                dr("isDonated") = gvsearchProperty.SelectedDataKey("isDonated")
                dr("SerialNo") = grListOfProperty.SelectedDataKey("SerialNo")
                dr("status") = grListOfProperty.SelectedDataKey("status")
                dr("MREDtl_ID") = grListOfProperty.SelectedDataKey("MREDtl_ID")
                dr("MREHdr_ID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
                dt.Rows.Add(dr)

                Session("MREHdr_ID") = grListOfProperty.SelectedDataKey("MREHdr_ID")



                dtissue2 = dt
                dtissue = Nothing

                If grListOfProperty.SelectedDataKey("status") = "On Hand" Then
                    lblMODE.Text = "RETURN"
                    btnIssue.Enabled = False
                    btnReturnProperty.Enabled = True
                Else
                    lblMODE.Text = "ISSUE"
                    btnIssue.Enabled = True
                    btnReturnProperty.Enabled = False
                End If

                Dim ReturnBy2 As Long = objDerived.GetValue("SELECT MRto FROM AMS.MRE_Hdr WHERE MREHdr_ID = '" & dtissue2.Rows(0)("MREHdr_ID") & "'", CommandType.Text)
                Session("ReturnBy") = ReturnBy2

                'Dim dt As New DataTable()
                'With dt.Columns
                '    .Add("Item_Desc", GetType(String))
                '    .Add("PropertyNo", GetType(String))
                '    .Add("PropertyDate", GetType(String))
                '    .Add("Cost", GetType(Decimal))
                '    .Add("rc_name", GetType(String))
                '    .Add("Status", GetType(String))
                '    .Add("Item_ID", GetType(Long))
                '    .Add("PropertyDetai_ID", GetType(Long))
                '    .Add("rc_id", GetType(Long))
                '    .Add("function_id", GetType(Long))
                '    .Add("Property_ID", GetType(Long))
                '    .Add("isDonated", GetType(Boolean))
                '    .Add("SerialNo", GetType(String))
                '    .Add("status", GetType(String))
                '    .Add("MREDtl_ID", GetType(Long))
                '    .Add("MREHdr_ID", GetType(Long))
                'End With

                'Dim selectedDataKey = grListOfProperty.SelectedDataKey
                'Dim dr As DataRow = dt.NewRow()
                'With dr
                '    .Item("Item_Desc") = selectedDataKey("Item_Desc")
                '    .Item("PropertyNo") = selectedDataKey("PropertyNo")
                '    .Item("PropertyDate") = selectedDataKey("PropertyDate")
                '    .Item("Cost") = selectedDataKey("Cost")
                '    .Item("rc_name") = selectedDataKey("Rc_name")
                '    .Item("Status") = selectedDataKey("status")
                '    .Item("Item_ID") = selectedDataKey("Item_ID")
                '    .Item("PropertyDetai_ID") = selectedDataKey("PropertyDetai_ID")
                '    .Item("rc_id") = selectedDataKey("rc_id")
                '    .Item("function_id") = selectedDataKey("function_id")
                '    .Item("Property_ID") = selectedDataKey("Property_ID")
                '    .Item("isDonated") = gvsearchProperty.SelectedDataKey("isDonated")
                '    .Item("SerialNo") = selectedDataKey("SerialNo")
                '    .Item("status") = selectedDataKey("status")
                '    .Item("MREDtl_ID") = selectedDataKey("MREDtl_ID")
                '    .Item("MREHdr_ID") = selectedDataKey("MREHdr_ID")
                'End With

                'dt.Rows.Add(dr)

                'Session("MREHdr_ID") = selectedDataKey("MREHdr_ID")

                'Dim status As String = selectedDataKey("status")
                'If status = "On Hand" Then
                '    lblMODE.Text = "RETURN"
                '    btnIssue.Enabled = False
                '    btnReturnProperty.Enabled = True
                'Else
                '    lblMODE.Text = "ISSUE"
                '    btnIssue.Enabled = True
                '    btnReturnProperty.Enabled = False
                'End If

                'Dim ReturnBy2 As Long = objDerived.GetValue("SELECT MRto FROM AMS.MRE_Hdr WHERE MREHdr_ID = '" & dt.Rows(0)("MREHdr_ID") & "'", CommandType.Text)
                'Session("ReturnBy") = ReturnBy2

                'Dim dtissue2 As DataTable = dt

            Else
                Dim dt2 As New DataTable
                Dim dr2 As DataRow

                dt2.Columns.Add("Item_Desc", GetType(String))
                dt2.Columns.Add("PropertyNo", GetType(String))
                dt2.Columns.Add("PropertyDate", GetType(String))
                dt2.Columns.Add("Cost", GetType(Decimal))
                dt2.Columns.Add("Rc_name", GetType(String))
                dt2.Columns.Add("Item_ID", GetType(Long))
                dt2.Columns.Add("PropertyDetai_ID", GetType(Long))
                dt2.Columns.Add("rc_id", GetType(Long))
                dt2.Columns.Add("function_id", GetType(Long))
                dt2.Columns.Add("Property_ID", GetType(Long))
                dt2.Columns.Add("isDonated", GetType(Boolean))
                dt2.Columns.Add("SerialNo", GetType(String))
                dt2.Columns.Add("status", GetType(String))
                dt2.Columns.Add("MREDtl_ID", GetType(Long))
                dt2.Columns.Add("MREHdr_ID", GetType(Long))

                For i As Integer = 0 To dtissue2.Rows.Count - 1
                    If dtissue2.Rows(i)("PropertyNo") = grListOfProperty.SelectedDataKey("PropertyNo") Then
                        '=== CHECK IF ITEM ALREADY EXIST
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Item already in the list.")
                        Exit Sub

                    ElseIf dtissue2.Rows(i)("status") <> grListOfProperty.SelectedDataKey("status") Then
                        '=== CHECK IF ALL ITEMS HAS SAME STATUS
                        If dtissue2.Rows(i)("status") = "Returned" Then
                            If grListOfProperty.SelectedDataKey("status") = "Returned" Or grListOfProperty.SelectedDataKey("status") = " - " Then
                                btnIssue.Enabled = True
                            Else
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Status did not match.")
                                Exit Sub
                            End If

                        ElseIf dtissue2.Rows(i)("status") = " - " Then
                            If grListOfProperty.SelectedDataKey("status") = "Returned" Or grListOfProperty.SelectedDataKey("status") = " - " Then
                                btnIssue.Enabled = True
                            Else
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Status did not match.")
                                Exit Sub
                            End If

                        ElseIf dtissue2.Rows(i)("status") = "On Hand" Then
                            If grListOfProperty.SelectedDataKey("status") = "On Hand" Then
                                btnReturnProperty.Enabled = True
                            Else
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Status did not match.")
                                Exit Sub
                            End If

                        End If

                    ElseIf grListOfProperty.SelectedDataKey("MREHdr_ID") <> Session("MRE_ID") Then
                        '=== CHECK IF ITEMS ISSUE TO 1 PERSONEL ONLY
                        Dim ReturnBy1 As Long = objDerived.GetValue("SELECT MRto FROM AMS.MRE_Hdr WHERE MREHdr_ID = '" & Session("MREHdr_ID") & "'", CommandType.Text)
                        Dim ReturnBy2 As Long = objDerived.GetValue("SELECT MRto FROM AMS.MRE_Hdr WHERE MREHdr_ID = '" & dtissue2.Rows(i)("MREHdr_ID") & "'", CommandType.Text)

                        If ReturnBy1 <> ReturnBy2 Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Item has different accountable personel.")
                            Exit Sub
                        Else
                            Session("ReturnBy") = ReturnBy2
                        End If

                    End If

                Next

                dt2 = dtissue2
                dr2 = dt2.NewRow
                dr2("Item_Desc") = grListOfProperty.SelectedDataKey("Item_Desc")
                dr2("PropertyNo") = grListOfProperty.SelectedDataKey("PropertyNo")
                dr2("PropertyDate") = grListOfProperty.SelectedDataKey("PropertyDate")
                dr2("Cost") = grListOfProperty.SelectedDataKey("Cost")
                dr2("rc_name") = grListOfProperty.SelectedDataKey("Rc_name")
                dr2("Item_ID") = grListOfProperty.SelectedDataKey("Item_ID")
                dr2("PropertyDetai_ID") = grListOfProperty.SelectedDataKey("PropertyDetai_ID")
                dr2("rc_id") = grListOfProperty.SelectedDataKey("rc_id")
                dr2("function_id") = grListOfProperty.SelectedDataKey("function_id")
                dr2("Property_ID") = grListOfProperty.SelectedDataKey("Property_ID")
                dr2("isDonated") = gvsearchProperty.SelectedDataKey("isDonated")
                dr2("SerialNo") = grListOfProperty.SelectedDataKey("SerialNo")
                dr2("status") = grListOfProperty.SelectedDataKey("status")
                dr2("MREDtl_ID") = grListOfProperty.SelectedDataKey("MREDtl_ID")
                dr2("MREHdr_ID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
                dt2.Rows.Add(dr2)
                dtissue2 = dt2


            End If

            grdIssueItems.DataSource = dtissue2
            grdIssueItems.DataBind()



        Catch ex As Exception
        End Try
    End Sub

    Protected Sub gvitems_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        'gvitems.DeleteRow(gvItemsRow)
    End Sub

    Protected Sub btnPerPO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/Inventory/t_Issuance_PerPO.aspx")
    End Sub

    Protected Sub btnPropNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtPropNo.Text = grListOfProperty.SelectedDataKey("PropertyNo")
        ModalPopupExtender4.Show()
    End Sub

    Protected Sub btnSaveProp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '==== CHECK IF PROPERTY NUMBER IS ALREADY EXISTS
            Dim PROP_NO As String
            PROP_NO = objDerived.GetValue("SELECT TOP(1)[PropertyDetai_ID] FROM [AMS].[Property_Dtl] WHERE [PropertyNo] = '" & txtPropNo.Text & "'", CommandType.Text)
            If PROP_NO = 0 Then
                objDerived.GetRecords("UPDATE [AMS].[Property_Dtl] SET [PropertyNo] = '" & txtPropNo.Text & "' WHERE [PropertyDetai_ID] = '" & grListOfProperty.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Property Number has been successfully updated.")
                LoadwithOutProperty()
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Property Number already exists, it should be unique.")
                txtPropNo.Text = grListOfProperty.SelectedDataKey("PropertyNo")
                ModalPopupExtender4.Show()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub drpSearh_Department_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Requsition adn Issuance / dbo.TbSupply_Type
        'Dim dSupply As New DataTable
        'dSupply = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 2 & "'", CommandType.Text)
        'ddSupplies.DataSource = CType(dSupply, DataTable)
        'ddSupplies.DataTextField = ("GA_Title")
        'ddSupplies.DataValueField = ("GA_ID")
        'ddSupplies.DataBind()
        'ddSupplies.Items.Insert(0, "Select")

        'dtGenAccount = objDerived.GetDataTable("EXEC [AMS].[sp_Supplies_AccountInventories] '" & drpSearh_Department.SelectedItem.Value & "'", CommandType.Text)
        'ddSupplies.DataSource = dtGenAccount
        'ddSupplies.DataTextField = ("GenAccount")
        'ddSupplies.DataValueField = ("GA_ID")
        'ddSupplies.DataBind()
        'ddSupplies.Items.Insert(0, "Select")

        dtGenAccount = objDerived.GetDataTable("EXEC [AMS].[sp_Supplies_AccountInventories] '" & drpSearh_Department.SelectedItem.Value & "'", CommandType.Text)
        ddSupplies.DataSource = dtGenAccount
        ddSupplies.DataTextField = ("GenAccount")
        ddSupplies.DataValueField = ("GA_Code2")
        ddSupplies.DataBind()
        ddSupplies.Items.Insert(0, "Select")
    End Sub

    Protected Sub btnView_Supplies_Click(sender As Object, e As EventArgs) Handles btnView_Supplies.Click
        LoadItemList()

        'dtSupplies = objDerived.GetDataTable("EXEC [AMS].[sp_IssuanceStock_List] '" & ddSupplies.SelectedItem.Value & "'", CommandType.Text)
        'If dtSupplies.Rows.Count = 0 Then
        '    gvSupplyList.DataSource = CreateDataTable_Supplies(5)
        '    gvSupplyList.DataBind()
        '    gvSupplyList.SelectedIndex = -1
        'Else
        '    If dtSupplies.Rows.Count < 8 Then
        '        dtSupplies.Merge(CreateDataTable_Supplies(5 - dtSupplies.Rows.Count))
        '    End If
        '    gvSupplyList.DataSource = dtSupplies
        '    gvSupplyList.DataBind()
        '    gvSupplyList.SelectedIndex = -1
        'End If

        'gvSupplyList.Columns(5).Visible = False

    End Sub


    Protected Sub LoadItemList()
        'Try
        If ddSupplies.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Select general account to view the list of items.")
        Else
            gvSupplyList.Columns(6).Visible = True
            dtSupplies = objDerived.GetDataTable("EXEC [AMS].[sp_SupplyList_ForRIS_Per_Employee] '" & drpSearh_Department.SelectedItem.Value & "','" & dtGenAccount.Rows(ddSupplies.SelectedIndex - 1)("GA_ID") & "'", CommandType.Text)
            If dtSupplies.Rows.Count < 5 Then
                dtSupplies.Merge(CreateDataTable_Supplies(5 - dtSupplies.Rows.Count))
            End If
            gvSupplyList.DataSource = dtSupplies
            gvSupplyList.DataBind()




            ddIssuedby.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE division_key = 86 and deptid = 7 ORDER BY isDeptHead DESC, full_name", CommandType.Text)
            ddIssuedby.DataTextField = ("full_name")
            ddIssuedby.DataValueField = ("empid")
            ddIssuedby.DataBind()

            drpApprovedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid ='" & drpSearh_Department.SelectedItem.Value & "' AND division_key = 86 ORDER BY isDeptHead DESC, full_name", CommandType.Text)
            drpApprovedBy.DataTextField = ("full_name")
            drpApprovedBy.DataValueField = ("empid")
            drpApprovedBy.DataBind()

            gvSupplyList.Columns(6).Visible = False
            LoadLeadger()
        End If
        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Something went wrong, pls contact system admin.")
        '    'MsgBox(ex.Message)
        'End Try
    End Sub
    Protected Sub cbRISItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            Dim cb As CheckBox = TryCast(sender, CheckBox)
            Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
            Dim dt As New DataTable
            Dim dr As DataRow

            Dim dt2 As New DataTable
            Dim dr2 As DataRow

            gvSupplyList.Columns(6).Visible = True


            If cb.Checked = True Then



                dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("isChecked") = True


                dt.Columns.Add("Item_Desc", GetType(String))
                dt.Columns.Add("UnitDesc", GetType(String))
                dt.Columns.Add("Balance", GetType(Decimal))
                dt.Columns.Add("Issuance", GetType(Decimal))
                dt.Columns.Add("cost", GetType(Decimal))
                dt.Columns.Add("total", GetType(Decimal))
                dt.Columns.Add("Item_ID", GetType(Integer))
                dt.Columns.Add("RC_ID", GetType(Integer))
                dt.Columns.Add("Function_ID", GetType(Integer))
                dt.Columns.Add("StockID", GetType(Integer))

                If pbody Is Nothing Then
                    dr = dt.NewRow()
                    dr("Item_Desc") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("ItemDesc")
                    dr("UnitDesc") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("UnitDesc")
                    dr("Balance") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Balance")
                    dr("Issuance") = 0
                    dr("cost") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Cost")
                    dr("total") = (dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Balance") * dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Cost"))
                    dr("Item_ID") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Item_ID")
                    dr("RC_ID") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("RC_ID")
                    dr("Function_ID") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Function_ID")
                    dr("StockID") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("StockID")

                    dt.Rows.Add(dr)

                    pbody = dt

                Else
                    If cb.Checked = True Then
                        dt2 = pbody
                        dr2 = dt2.NewRow()
                        Dim isExisting As Boolean = False

                        For i As Integer = 0 To pbody.Rows.Count - 1
                            If pbody.Rows(i)("Item_ID") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Item_ID") Then
                                isExisting = True
                                Exit For
                            End If
                        Next

                        If isExisting = False Then
                            dr2("Item_Desc") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("ItemDesc")
                            dr2("UnitDesc") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("UnitDesc")
                            dr2("Balance") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Balance")
                            dr2("Issuance") = 0
                            dr2("cost") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Cost")
                            dr2("total") = (dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Balance") * dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Cost"))
                            dr2("Item_ID") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Item_ID")
                            dr2("RC_ID") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("RC_ID")
                            dr2("Function_ID") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Function_ID")
                            dr2("StockID") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("StockID")
                            dt2.Rows.Add(dr2)

                            pbody = dt2
                        End If
                    End If
                End If

                gvbody.DataSource = pbody
                gvbody.DataBind()

                btnsave.Enabled = True

            Else
                'dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("isUsed") = False
                dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("isChecked") = False

                For i As Integer = 0 To Me.pbody.Rows.Count - 1
                    If pbody.Rows(i).Item("Item_ID") = 0 Then

                    ElseIf pbody.Rows(i).Item("Item_ID") = dtSupplies.Rows(gvSupplyList.Rows(gvr.RowIndex).Cells(6).Text)("Item_ID") Then
                        pbody.Rows.Remove(pbody.Rows(i))
                        Exit For
                    End If
                Next

                Dim dt3 As DataTable
                dt3 = pbody

                pbody = Nothing
                pbody = dt3
                gvbody.DataSource = pbody
                gvbody.DataBind()

            End If

            gvSupplyList.Columns(6).Visible = False


        Catch ex As Exception
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Something went wrong, pls contact system admin.")
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub LoadDetails_Dropdowns()





        drpApprovedBy.Items.Clear()
        drpApprovedBy.Items.Insert(0, "Select")

        ddIssuedby.Items.Clear()
        ddIssuedby.Items.Insert(0, "Select")

        txtremarks.Text = ""

    End Sub
    Protected Sub LoadLeadger()
        Dim dtLedger As New DataTable
        dtLedger = objDerived.GetDataTable("EXEC [AMS].[sp_StockLedger_PerEmployee] '" & drpSearh_Department.SelectedItem.Value & "','" & dtGenAccount.Rows(ddSupplies.SelectedIndex - 1)("GA_ID") & "'", CommandType.Text)
        If dtLedger.Rows.Count < 5 Then
            dtLedger.Merge(CreateDataTable_StockLedgerPerEmployee(5 - dtLedger.Rows.Count))
        End If
        grdLedger.DataSource = dtLedger
        grdLedger.DataBind()

    End Sub


End Class
