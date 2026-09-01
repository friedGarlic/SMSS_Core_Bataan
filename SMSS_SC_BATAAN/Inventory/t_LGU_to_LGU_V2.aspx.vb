
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Drawing


Partial Class t_LGU_to_LGU_V2
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


#Region "Property"

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

    Private Property dtissue3() As DataTable
        Get
            Return CType(Session("dtissue2"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtissue2") = value
        End Set
    End Property
#End Region
#Region "Datatables"
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
        dt.Columns.Add("isVisible", GetType(Boolean))
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
            dr("isVisible") = False
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

        'grListOfProperty.Columns(11).Visible = False

        'grdIssueItems.Columns(4).Visible = False
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

            gvSupplyList.DataSource = CreatedatatableSupplist(5)
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

            'Requsition adn Issuance / dbo.TbSupply_Type
            Dim dSupply As New DataTable
            dSupply = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 2 & "'", CommandType.Text)
            ddSupplies.DataSource = CType(dSupply, DataTable)
            ddSupplies.DataTextField = ("GA_Title")
            ddSupplies.DataValueField = ("GA_ID")
            ddSupplies.DataBind()
            ddSupplies.Items.Insert(0, "Select")

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
        dtSupplies = objDerived.GetDataTable("EXEC [AMS].[sp_IssuanceStock_List] '" & ddSupplies.SelectedItem.Value & "'", CommandType.Text)
        If dtSupplies.Rows.Count = 0 Then
            gvSupplyList.DataSource = CreatedatatableSupplist(5)
            gvSupplyList.DataBind()
            gvSupplyList.SelectedIndex = -1
        Else
            If dtSupplies.Rows.Count < 8 Then
                dtSupplies.Merge(CreatedatatableSupplist(5 - dtSupplies.Rows.Count))
            End If
            gvSupplyList.DataSource = dtSupplies
            gvSupplyList.DataBind()
            gvSupplyList.SelectedIndex = -1
        End If

        gvSupplyList.Columns(5).Visible = False

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
        Call load_Department()
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



        Ppropertylist = objDerived.GetDataTable("EXEC [AMS].[sp_Inventory_ItemList_V1_03012023] '" & gvsearchProperty.SelectedDataKey("Item_id") & "', '" & gvsearchProperty.SelectedDataKey("isDonated") & "'", CommandType.Text)
        txtHiddenReceiveQty.value = Ppropertylist.rows.count
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
        ' grListOfProperty.Columns(11).Visible = False
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
        'here

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
        'Session("MREHdr_ID") = grListOfProperty.SelectedDataKey("MREHdr_ID")

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
    Public Sub load_Department()
        ddFromDepartment.Items.Clear()
        ddFromDepartment.DataSource = objDerived.GetDataTable("Select * from dbo.View_RespCenter_withFunctions where RC_ID = 7", CommandType.Text)
        ddFromDepartment.DataTextField = ("RC_Name")
        ddFromDepartment.DataValueField = ("RC_ID")
        ddFromDepartment.DataBind()


        ddFromProperty.Items.Clear()
        ddFromProperty.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = 7", CommandType.Text)
        ddFromProperty.DataTextField = ("full_name")
        ddFromProperty.DataValueField = ("empid")
        ddFromProperty.DataBind()
        ddFromProperty.Items.Insert(0, "Select")

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
            Me.Page.Response.Redirect("~/Records/t_DonationList.aspx")
        Else
            Session("Records") = "Search"
            Session("ItemName") = gvsearchProperty.SelectedDataKey("ItemParticular")
            Session("GL_Account") = gvsearchProperty.SelectedDataKey("GA_ID")
            Me.Page.Response.Redirect("~/Records/PropertyCard_v3.aspx")
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

        '0306
        Dim DonationLguToLgu As New DonationgLguToLgu
        With DonationLguToLgu
            .Item_ID = gvsearchProperty.SelectedDataKey("Item_id")
            .Item_Description = gvsearchProperty.SelectedDataKey("Item_Desc")
            .LGU_Department = txtDepartment.Text
            .Receivedby = txtIssueTo.Text
            .Receivedby_position = txtReceivedPostion.Text
            .Date_Received = txtDateReceivedBy.Text
            .ReceivedFrom_Dep_ID = ddFromDepartment.SelectedValue
            .IssuedBy_ID = ddFromProperty.SelectedValue
            .Date_Issued = txtDateReceivedFrom.Text
            .Remarks = txtARE_Remarks.Text
        End With
        Dim DonationgLGUtoLGU_Hrd_ID As Integer = 0
        DonationgLGUtoLGU_Hrd_ID = DonationLguToLgu.saveDonation_LGU_TO_LGU()
        hndLGUHrd_ID.Value = DonationgLGUtoLGU_Hrd_ID

        For i As Integer = 0 To grdIssueItems.Rows.Count - 1
            Dim donationLGUtoLGU_Dtl As New DonationLguToLgu_Dtl
            With donationLGUtoLGU_Dtl
                .DonationLGUtoLGU_ID = DonationgLGUtoLGU_Hrd_ID
                .Item_Description = grdIssueItems.Rows(i).Cells(0).Text
                .PropertyNo = grdIssueItems.Rows(i).Cells(1).Text
                .Cost = grdIssueItems.Rows(i).Cells(2).Text.Replace(",", "")
                .status = "Donated"
                '.Property_Dtl_ID = Val(grdIssueItems.Rows(i).Cells(4).Text)
                .Property_Dtl_ID = Convert.ToInt32(grdIssueItems.DataKeys(i)("PropertyDetai_ID"))

            End With
            Dim DonationgLGUtoLGU_Dtl As Integer = 0
            DonationgLGUtoLGU_Dtl = donationLGUtoLGU_Dtl.saveDonation_LGU_TO_LGU_Dtl()

            Dim balance As Integer = Val(objDerived.GetValue("exec AMS.getbalance '" & grdIssueItems.Rows(i).Cells(1).Text & "'", CommandType.Text))
            Dim issuance As Integer = Val(objDerived.GetValue("exec AMS.getIssuance '" & grdIssueItems.Rows(i).Cells(1).Text & "'", CommandType.Text))
            Dim Property_ID As Integer = Val(objDerived.GetValue("exec AMS.getProperty_ID '" & grdIssueItems.Rows(i).Cells(1).Text & "'", CommandType.Text))
            objDerived.GetRecords("Update AMS.Property set Balance='" & balance - 1 & "'  where  Property_ID='" & Property_ID & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Property_Dtl SET Donation ='True' WHERE PropertyNo='" & grdIssueItems.Rows(i).Cells(1).Text & "'", CommandType.Text)

            dtPropLedger = objLedger.GetDataTable("Select Ledger_ID from AMS.TbProperty_Ledger", CommandType.Text)
            With objLedger
                '.Ledger_ID = Ledger_ID
                .PropertyNo = grdIssueItems.Rows(i).Cells(1).Text
                .SerialNo = ""
                .dDate = txtDateReceivedFrom.Text
                .Trans_Type = "Donation to LGU"
                .Ref = ""
                .Item_ID = gvsearchProperty.SelectedDataKey("Item_id")
                .AccountablePerson = txtIssueTo.Text
                .Department = txtDepartment.Text
                .Position = txtReceivedPostion.Text
                .AcceptedBy = txtIssueTo.Text
                .InspectedBy = ""

                .DebitQty = "0"
                .DebitUnit = "-"
                .DebitCost = "0.00"

                .CreditQty = 1
                .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & gvsearchProperty.SelectedDataKey("Item_id") & "'", CommandType.Text)
                .CreditCost = grdIssueItems.Rows(i).Cells(2).Text.Replace(",", "")

                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & gvsearchProperty.SelectedDataKey("Item_id") & "'", CommandType.Text)

                Dim eQty As Integer
                Dim eBalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & gvsearchProperty.SelectedDataKey("Item_id") & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    eQty = 0
                    eBalance = 0.0
                Else
                    eQty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & gvsearchProperty.SelectedDataKey("Item_id") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                    eBalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & gvsearchProperty.SelectedDataKey("Item_id") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                End If

                .BalanceQty = eQty - 1
                .BalanceCost = CType(eBalance, Decimal) - grdIssueItems.Rows(i).Cells(2).Text.Replace(",", "")
            End With

            objLedger.Ledger_ID = 0
            objLedger.save()
        Next

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Transaction has been successfully saved.")
        btnsavedoc.Enabled = False
        LoadPropertyDropDown()
        LoadwithOutProperty()
        btnpreviewAreDoc.Enabled = True
    End Sub
    Protected Sub btncancelDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Page.Response.Redirect("~/etc/body.aspx")
        Me.Page.Response.Redirect("~/Inventory/t_RequisitionAndIssunace.aspx")
    End Sub
    Protected Sub btnpreviewAreDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Session("LGUToLGU_HRD_ID") = hndLGUHrd_ID.Value
        'Dim url As String = "r_Donation_LGUToLGU.aspx?"
        'Dim fullURL As String = "window.open('" & url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100');"
        'ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        Dim url As String = "r_Donation_LGUToLGU.aspx"
        Dim options As String = "status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100"
        Dim fullURL As String = String.Format("window.open('{0}', '_blank', '{1}');", url, options)
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

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
    Protected Sub drpdept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpdept.SelectedIndexChanged
        Try
            drpFunction.Items.Clear()
            'pFunction = objDerived.GetDataTable("exec ams.m_function " & drpdept.SelectedItem.Value & "", CommandType.Text)

            pFunction = objDerived.GetDataTable("SELECT DISTINCT [RC_id],[Function_ID],UPPER([Function_Desc]) AS Function_Desc FROM [dbo].[View_RespCenter_withFunctions] WHERE RC_ID = '" & drpdept.SelectedItem.Value & "' ORDER BY [Function_Desc]", CommandType.Text)
            drpFunction.DataSource = pFunction
            drpFunction.DataTextField = ("Function_Desc")
            drpFunction.DataValueField = ("Function_ID")
            drpFunction.DataBind()
            drpFunction.Items.Insert(0, "Select")
            drpFunction.Enabled = True

            pbody = Nothing
            gvbody.DataSource = pbody
            gvbody.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub drpFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpFunction.SelectedIndexChanged
        Try
            pemployee = Nothing
            ddmr.DataSource = pemployee
            ddmr.DataBind()

            pemployee = objDerived.GetDataTable("Select * From HRMS.view_signatory where division_key = '" & Me.drpFunction.SelectedItem.Value & "' and deptid ='" & drpdept.SelectedItem.Value & "'", CommandType.Text)
            ddmr.DataSource = pemployee
            ddmr.DataTextField = ("full_name")
            ddmr.DataValueField = ("empid")
            ddmr.DataBind()
            ddmr.Items.Insert(0, "Select")
            ddmr.Enabled = True

            ddReceive.DataSource = objDerived.GetDataTable("Select * From HRMS.view_signatory where division_key = '" & Me.drpFunction.SelectedItem.Value & "' and deptid ='" & drpdept.SelectedItem.Value & "'", CommandType.Text)
            ddReceive.DataTextField = ("full_name")
            ddReceive.DataValueField = ("empid")
            ddReceive.DataBind()
            ddReceive.Items.Insert(0, "Select")
            ddReceive.Enabled = True

            ddIssuedby.DataSource = objDerived.GetDataTable("Select * From HRMS.view_signatory where division_key = 86 and deptid = 7 ", CommandType.Text)
            ddIssuedby.DataTextField = ("full_name")
            ddIssuedby.DataValueField = ("empid")
            ddIssuedby.DataBind()
            ddIssuedby.Items.Insert(0, "Select")
            ddIssuedby.Enabled = True

            pItems = objDerived.GetDataTable("exec ams.LoadStocklist '" & gvSupplyList.SelectedDataKey("RC_ID") & "','" & gvSupplyList.SelectedDataKey("Function_ID") & "','" & gvSupplyList.SelectedDataKey("GA_ID") & "'", CommandType.Text)
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.DataSource = pItems
            gvitems.DataBind()

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(7).Visible = False

            pbody = Nothing
            gvbody.DataSource = pbody
            gvbody.DataBind()

            txtsearchitems.Text = gvSupplyList.SelectedDataKey("Item_Desc")
            btnADD.Enabled = True

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ddmr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddmr.SelectedIndexChanged
        Session("empid") = ddmr.SelectedItem.Value

    End Sub
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

            If CType(pbody.Rows(gvr.RowIndex)("qty"), Integer) >= CType(txtqty.Text, Integer) Then

                pbody.Rows(gvr.RowIndex)("qty2") = txtqty.Text
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
                CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text = pbody.Rows(i)("qty")

                pbody.Rows(i)("qty2") = pbody.Rows(i)("qty")
                pbody.Rows(i)("total") = pbody.Rows(i)("Cost") * pbody.Rows(i)("qty")

                gvbody.Rows(i).Cells(6).Text = FormatNumber(pbody.Rows(i)("total"), 2)
                gvbody.FooterRow.Cells(6).Text = FormatNumber(pbody.Compute("sum(total)", ""), 2)
            Next

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnnew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnew.Click
        pItems = objDerived.GetDataTable("exec ams.LoadStocklist " & Me.drpdept.SelectedItem.Value & ",'" & Date.Today.ToString("MM/dd/yyyy") & "'," & Me.drpFunction.SelectedItem.Value & "", CommandType.Text)
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.DataSource = pItems
        gvitems.DataBind()
        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        btnpreview.Enabled = False
        btnsave.Enabled = False
        Dim obj1 As Object
        obj1 = True

        ddmr.DataSource = objDerived.Search(pemployee, "Status", obj1)
        ddmr.DataTextField = ("Fullname")
        ddmr.DataValueField = ("id")
        ddmr.DataBind()
        ddmr.SelectedIndex = 0
        ddmr.Enabled = True
        txtdate.Text = Date.Today.ToString("MM/dd/yyyy")
        txtRIS.Text = objDerived.GetValue("select AMS.func_GenerateRIS('" & txtdate.Text & "')", CommandType.Text)
        txtremarks.ReadOnly = False
        pbody = Nothing
        gvbody.DataSource = pbody
        gvbody.DataBind()
        txtremarks.Text = ""
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        'Here 1
        Try
            If pbody.Compute("sum(qty2)", "") = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Atleast one supply must have a quantity.")

            Else
                Dim RIS As Integer
                RIS = objDerived.GetValue("SELECT [RISHdr_ID] FROM [AMS].[RIS_Hdr] WHERE [RIS_No] = '" & txtRIS.Text & "'", CommandType.Text)
                If RIS <> 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "RIS already exist.")
                    Exit Sub
                End If

                Session("ris_no") = drpCategoryCode.SelectedItem.Text & "-" & txtRIS.Text

                hdr.RIS_No = drpCategoryCode.SelectedItem.Text & "-" & txtRIS.Text
                hdr.RISDate = txtdate.Text
                hdr.RC_ID = Me.drpdept.SelectedItem.Value
                hdr.Func_ID = Me.drpFunction.SelectedItem.Value
                hdr.Purpose = txtremarks.Text
                hdr.Issued_By = IIf((ddIssuedby.SelectedItem.Text = "Select"), "", (ddIssuedby.SelectedItem.Text))
                hdr.Requested_By = IIf((ddmr.SelectedItem.Text = "Select"), "", (ddmr.SelectedItem.Text))
                hdr.Received_By = IIf((ddReceive.SelectedItem.Text = "Select"), "", (ddReceive.SelectedItem.Text))
                hdr.withICS = False
                hdr.Approved_By = objDerived.GetValue("SELECT TOP (1) [Full_Name] FROM [HRMS].[view_signatory] WHERE [deptid] = 7 AND [division_Key] = 86 AND [isDeptHead] = 'Yes'", CommandType.Text)
                Dim hdrid As Long = hdr.saveRISHdr()

                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    If pbody.Rows(i)("qty2") <> "0" Then
                        'Dim NewMAB As Decimal = CType(mab.Rows(0)("mab"), Decimal) - CType(pbody.Rows(i)("total"), Decimal)
                        'Dim data As DataTable = objDerived.GetDataTable("exec AMS.updatestock '" & pbody.Rows(i)("item_id") & "'," & Me.drpdept.SelectedItem.Value & "," & Me.drpFunction.SelectedItem.Value & ",'" & pbody.Rows(i)("qty2") & "'", CommandType.Text)
                        'msgbox(pbody.Rows(i)("item_id"))
                        Dim mab As DataTable = objDerived.GetDataTable("SELECT mab  FROM AMS.Stock WHERE stockID ='" & pbody.Rows(i)("StockID") & "'", CommandType.Text)
                        Dim NewMAB As Decimal = CType(mab.Rows(0)("mab"), Decimal) - CType(pbody.Rows(i)("total"), Decimal)

                        dtl.RISHdr_ID = hdrid
                        dtl.Item_ID = pbody.Rows(i)("item_id")
                        dtl.AvailableQty = pbody.Rows(i)("qty")
                        dtl.ApprovedQty = pbody.Rows(i)("qty2")
                        dtl.Cost = pbody.Rows(i)("Cost")
                        dtl.StockID = pbody.Rows(i)("StockID")
                        dtl.Remarks = CType(gvbody.Rows(i).FindControl("txtRemarks"), TextBox).Text

                        dtl.saveRISDtl()

                        Dim balance As Decimal = objDerived.GetValue("Select Balance from AMS.Stock where stockID ='" & pbody.Rows(i)("StockID") & "'", CommandType.Text)
                        Dim issuance As Decimal = objDerived.GetValue("Select Issuance from AMS.Stock where stockID ='" & pbody.Rows(i)("StockID") & "'", CommandType.Text)

                        objDerived.GetRecords("update ams.stock set mab='" & NewMAB & "',Balance='" & balance - pbody.Rows(i)("qty2") & "',Issuance='" & issuance + pbody.Rows(i)("qty2") & "' where stockID =" & pbody.Rows(i)("StockID") & "", CommandType.Text)
                        'objDerived.GetRecords("update ams.stock set mab='" & NewMAB & "' where stockID =" & pbody.Rows(i)("StockID") & "", CommandType.Text)


                        '==== SAVE Stock Ledger ====
                        dtStockLedger = objStockLedger.GetDataTable("Select StockLedger_ID from AMS.TbStock_Ledger", CommandType.Text)
                        With objStockLedger
                            '.StockLedger_ID = StockLedger_ID
                            .StockID = "0" 'objDerived.GetValue("Select StockID FROM AMS.Stock where Item_ID = '" & pbody.Rows(i)("item_id") & "'", CommandType.Text)
                            .Trans_Type = "Issuance"
                            .Ref = Session("ris_no")
                            .AccountablePerson = ddmr.SelectedItem.Text 'objDerived.GetValue("Select fullname FROM AMS.employee where id = '" & ddmr.SelectedItem.Text & "'", CommandType.Text) 'ddmr.SelectedItem.Text
                            .Department = drpdept.SelectedItem.Text
                            .Position = ""
                            .AcceptedBy = ddReceive.SelectedItem.Text
                            .InspectedBy = ""
                            .DebitQty = "0"
                            .DebitUnit = "-"
                            .DebitCost = "0.00"
                            '.CreditQty = ""
                            '.CreditUnit = ""
                            '.CreditCost = ""
                            '.BalanceQty = ""
                            '.BalanceUnit = ""
                            '.BalanceCost = ""

                            .dDate = txtdate.Text
                            .Item_ID = pbody.Rows(i)("item_id")

                            .CreditQty = pbody.Rows(i)("qty2")
                            .CreditCost = pbody.Rows(i)("total")
                            .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & pbody.Rows(i)("item_id") & "'", CommandType.Text)

                            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & pbody.Rows(i)("item_id") & "'", CommandType.Text)

                            Dim SuppQty As Decimal
                            Dim SuppBalance As Decimal
                            Dim dtledger As New DataTable

                            dtledger = objDerived.GetDataTable("Select * from AMS.TbStock_Ledger where Item_ID = '" & pbody.Rows(i)("item_id") & "'", CommandType.Text)
                            If dtledger.Rows.Count = 0 Then
                                SuppQty = 0
                                SuppBalance = 0.0
                            Else
                                SuppQty = objDerived.GetValue("Select BalanceQty from AMS.TbStock_Ledger where Item_ID = '" & pbody.Rows(i)("item_id") & "'  ORDER BY StockLedger_ID desc", CommandType.Text)
                                SuppBalance = objDerived.GetValue("Select BalanceCost from AMS.TbStock_Ledger where Item_ID = '" & pbody.Rows(i)("item_id") & "'  ORDER BY StockLedger_ID desc", CommandType.Text)
                            End If

                            .BalanceQty = SuppQty - CType(pbody.Rows(i)("qty2"), Integer)
                            .BalanceCost = CType(SuppBalance, Decimal) - CType(pbody.Rows(i)("total"), Decimal)
                        End With
                        'objStockLedger.StockLedger_ID = 0
                        objStockLedger.save()

                    End If
                Next

                gvbody.DataSource = objDerived.GetRecords("exec AMS.loadRISdetail '" & Me.Session("ris_no") & "','" & drpdept.SelectedItem.Value & "','" & drpFunction.SelectedItem.Value & "'", CommandType.Text)
                gvbody.DataBind()


                '========================== CHECK AND SAVE CUSTODIAN ITEMS - AMS.ICS_Hdr ===========================
                Session("withICS") = False

                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    Dim ULife As Integer = Val(objDerived.GetValue("SELECT case when (AMS.item_particular.useful_life) is null then '0' else (AMS.item_particular.useful_life) end as useful_life FROM AMS.item_particular INNER JOIN dbo.m_item ON AMS.item_particular.item_particular_id = dbo.m_item.item_particular_id WHERE dbo.m_item.Item_ID = '" & pbody.Rows(i)("item_id") & "'", CommandType.Text))
                    If ULife <> 0 Then
                        Session("withICS") = True
                        Exit For
                    End If

                Next

                '=-= UPDATE AMS.RIS_Hdr "withICS"
                objDerived.GetRecords("UPDATE AMS.RIS_Hdr set withICS = '" & Session("withICS") & "' WHERE RISHdr_ID = '" & hdrid & "'", CommandType.Text)

                For i As Integer = 0 To gvbody.Rows.Count - 1
                    CType(gvbody.Rows(i).Cells(2).FindControl("txtqty"), TextBox).ReadOnly = True
                Next
                If Session("withICS") = True Then
                    'ICS_hdr
                    With ICS_hdr
                        .ICS_No = objDerived.GetValue("select [AMS].[func_GenerateICS]('" & txtdate.Text & "','" & drpdept.SelectedItem.Value & "')", CommandType.Text)
                        .Date_Acquired = txtdate.Text
                        .RIS_no = Me.Session("ris_no")
                        .RC_ID = drpdept.SelectedItem.Value
                        .Function_ID = drpFunction.SelectedItem.Value
                        .IssuedBy = IIf((ddIssuedby.SelectedItem.Text = "Select"), "", (ddIssuedby.SelectedItem.Text))
                        .IssuedTo = IIf((ddReceive.SelectedItem.Text = "Select"), "", (ddReceive.SelectedItem.Text))
                        .IssuedBy_Pos = objDerived.GetValue("Select position_desc From HRMS.view_signatory where EmpID =" & ddIssuedby.SelectedItem.Value, CommandType.Text)
                        .IssuedTo_Pos = objDerived.GetValue("Select position_desc From HRMS.view_signatory where EmpID =" & ddReceive.SelectedItem.Value, CommandType.Text)
                        .AccountablePerson = ddmr.SelectedItem.Text
                        .AccountablePerson_Pos = objDerived.GetValue("Select position_desc From HRMS.view_signatory where EmpID =" & ddmr.SelectedItem.Value, CommandType.Text)
                    End With
                    Dim icshdrid As Long = ICS_hdr.saveICSHdr
                    Session("ICSHdr_ID") = icshdrid
                    For i As Integer = 0 To gvbody.Rows.Count - 1
                        With ICS_Dtl
                            .ICSHdr_ID = icshdrid
                            .Item_ID = pbody.Rows(i)("item_id")
                            .Qty = pbody.Rows(i)("qty2")
                            .Cost = pbody.Rows(i)("total")
                            .Status = ""
                            .Remarks = txtremarks.Text
                        End With
                        ICS_Dtl.saveICSDtl()

                    Next
                End If

                btnpreview.Enabled = True
                btnPreviewICS.Enabled = True

                btnsave.Enabled = False
                ddmr.Enabled = False
                txtremarks.ReadOnly = True

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Transaction has been successfully saved.")

                Me.drpdept.Enabled = False
                Me.drpFunction.Enabled = False
                btnADD.Enabled = False

                LoadMainRIS()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
        txtSupplySearch1.Text = ""


        drpdept.Enabled = True
        drpFunction.Enabled = True
        ddmr.Enabled = True

        drpdept.Items.Clear()
        pRC = Nothing
        drpdept.DataSource = pRC
        drpdept.Items.Add("Select")
        drpdept.DataBind()

        drpFunction.Items.Clear()
        pFunction = Nothing
        drpFunction.DataSource = pFunction
        drpFunction.Items.Add("Select")
        drpFunction.DataBind()

        ddmr.Items.Clear()
        pemployee = Nothing
        ddmr.DataSource = pemployee
        ddmr.Items.Add("Select")
        ddmr.DataBind()

        Session("SuppliesSearch") = 0

        LoadMainRIS()

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


        drpdept.Enabled = True
        drpdept.Items.Clear()

        pRC = Nothing
        pRC = objDerived.GetDataTable("SELECT DISTINCT [RC_id],UPPER([RC_Name]) AS RC_Name FROM [dbo].[View_RespCenter_withFunctions] ORDER BY [RC_Name]", CommandType.Text)
        drpdept.DataSource = CType(pRC, DataTable)
        drpdept.DataTextField = ("RC_Name")
        drpdept.DataValueField = ("RC_ID")
        drpdept.DataBind()
        drpdept.Items.Insert(0, "Select")


        pFunction = Nothing
        drpFunction.Items.Clear()
        drpFunction.DataSource = pFunction
        drpFunction.DataBind()
        drpFunction.Items.Insert(0, "Select")


        pemployee = Nothing
        ddmr.Items.Clear()
        ddmr.DataSource = pemployee
        ddmr.DataBind()
        ddmr.Items.Insert(0, "Select")

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
        txtRIS.Text = objDerived.GetValue("select AMS.func_GenerateRIS('" & txtdate.Text & "')", CommandType.Text)
    End Sub


    'Protected Sub gvSupplyList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
    '    drpdept.Enabled = True                                                                                    

    '    Dim GaId As Integer
    '    If ddSupplies.SelectedValue = 1 Then
    '        GaId = 792 ' Drugs and Medicine
    '    ElseIf ddSupplies.SelectedValue = 2 Then
    '        GaId = 793 ' Medical Supplies
    '    ElseIf ddSupplies.SelectedValue = 3 Then
    '        GaId = 791 'Food
    '    ElseIf ddSupplies.SelectedValue = 4 Then
    '        GaId = 799 ' Water
    '    ElseIf ddSupplies.SelectedValue = 5 Then
    '        GaId = 798 ' Blood
    '    ElseIf ddSupplies.SelectedValue = 6 Then
    '        GaId = 927 ' Non-Food
    '    ElseIf ddSupplies.SelectedValue = 7 Then
    '        GaId = 788 ' Office Supplies
    '    End If

    '    Dim dtsuppFilter As New DataTable
    '    dtsuppFilter = objDerived.GetDataTable("Select * From dbo.View_StockIssuance where GA_ID = '" & GaId & "'", CommandType.Text)
    '    If dtsuppFilter.Rows.Count < 5 Then
    '        dtsuppFilter.Merge(CreatedatatableSupplist(5 - dtsuppFilter.Rows.Count))
    '        gvSupplyList.PageIndex = e.NewPageIndex
    '        gvSupplyList.DataSource = dtsuppFilter
    '        gvSupplyList.DataBind()
    '    Else
    '        gvSupplyList.DataSource = dtsuppFilter
    '        gvSupplyList.DataBind()

    '    End If
    '    gvSupplyList.Columns(3).Visible = False
    'End Sub

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

    Protected Sub ddReceive_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'ddReceive.Enabled = False
        'btnADD.Enabled = True
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
        Dim Governor As String = "Governor"
        ddPrevMayor.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE deptid = 1 AND division_key = 86 AND position_desc like '%" & Governor & "%'", CommandType.Text)
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
        Me.mvIssuance.SetActiveView(Me.vwARE)
        btnRIS.CssClass = "Clicked"
        btnARE.CssClass = "Initial"

        gvSupplyList.DataSource = CreatedatatableSupplist(5)
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
        dtissue2 = Nothing
        Try
            If grdIssueItems.Rows.Count <= 0 Then
                'Dim cb As CheckBox
                'For x As Integer = 0 To grListOfProperty.Rows.Count - 1
                '    cb = CType(Me.grListOfProperty.Rows(x).Cells(0).FindControl("cbInspection"), CheckBox)
                '    If cb.Checked = True Then

                '        Dim dt As New DataTable
                '        Dim dr As DataRow

                '        dt.Columns.Add("Item_Desc", GetType(String))
                '        dt.Columns.Add("PropertyNo", GetType(String))
                '        dt.Columns.Add("PropertyDate", GetType(String))
                '        dt.Columns.Add("Cost", GetType(String))
                '        dt.Columns.Add("rc_name", GetType(String))
                '        dt.Columns.Add("Status", GetType(String))
                '        dt.Columns.Add("Item_ID", GetType(String))
                '        dt.Columns.Add("PropertyDetai_ID", GetType(String))
                '        dt.Columns.Add("rc_id", GetType(String))
                '        dt.Columns.Add("function_id", GetType(String))
                '        dt.Columns.Add("Property_ID", GetType(String))
                '        dt.Columns.Add("isDonated", GetType(Boolean))
                '        dt.Columns.Add("SerialNo", GetType(String))
                '        dt.Columns.Add("status", GetType(String))
                '        dt.Columns.Add("MREDtl_ID", GetType(String))
                '        dt.Columns.Add("MREHdr_ID", GetType(String))

                '        dr = dt.NewRow
                '        dr("Item_Desc") = grListOfProperty.Rows(x).Cells(1).Text
                '        dr("PropertyNo") = grListOfProperty.Rows(x).Cells(2).Text
                '        dr("PropertyDate") = grListOfProperty.Rows(x).Cells(3).Text
                '        dr("Cost") = grListOfProperty.Rows(x).Cells(4).Text
                '        dr("rc_name") = grListOfProperty.Rows(x).Cells(5).Text
                '        dr("Status") = grListOfProperty.Rows(x).Cells(9).Text

                '        dr("Item_ID") = 0
                '        dr("PropertyDetai_ID") = 0
                '        dr("rc_id") = 0
                '        dr("function_id") = 0
                '        dr("Property_ID") = 0
                '        dr("isDonated") = 0
                '        dr("SerialNo") = 0
                '        dr("status") = 0
                '        dr("MREDtl_ID") = 0

                '        dr("MREHdr_ID") = grListOfProperty.Rows(x).Cells(10).Text
                '        dt.Rows.Add(dr)

                '        dtissue2 = dt
                '        ' dtissue = Nothing


                '        grdIssueItems.DataSource = dtissue2
                '        grdIssueItems.DataBind()
                '    End If
                'Next


                Dim dt As New DataTable
                dt.Columns.Add("Item_Desc", GetType(String))
                dt.Columns.Add("PropertyNo", GetType(String))
                dt.Columns.Add("PropertyDate", GetType(String))
                dt.Columns.Add("Cost", GetType(String))
                dt.Columns.Add("rc_name", GetType(String))
                dt.Columns.Add("Status", GetType(String))
                dt.Columns.Add("Item_ID", GetType(String))
                dt.Columns.Add("PropertyDetai_ID", GetType(String))
                dt.Columns.Add("rc_id", GetType(String))
                dt.Columns.Add("function_id", GetType(String))
                dt.Columns.Add("Property_ID", GetType(String))
                dt.Columns.Add("isDonated", GetType(Boolean))
                dt.Columns.Add("SerialNo", GetType(String))
                dt.Columns.Add("status", GetType(String))
                dt.Columns.Add("MREDtl_ID", GetType(String))
                dt.Columns.Add("MREHdr_ID", GetType(String))

                For Each row As GridViewRow In grListOfProperty.Rows
                    Dim cb As CheckBox = CType(row.FindControl("cbInspection"), CheckBox)
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        Dim dr As DataRow = dt.NewRow()
                        dr("Item_Desc") = row.Cells(1).Text
                        dr("PropertyNo") = row.Cells(2).Text
                        dr("PropertyDate") = row.Cells(3).Text
                        dr("Cost") = row.Cells(4).Text
                        dr("rc_name") = row.Cells(5).Text
                        dr("Status") = row.Cells(9).Text
                        dr("Item_ID") = gvsearchProperty.SelectedDataKey("Item_id")
                        dr("PropertyDetai_ID") = Convert.ToInt32(grListOfProperty.DataKeys(row.RowIndex)("PropertyDetai_ID"))
                        dr("rc_id") = gvsearchProperty.SelectedDataKey("RC_ID")
                        dr("function_id") = gvsearchProperty.SelectedDataKey("Function_ID ")
                        dr("Property_ID") = 0
                        dr("isDonated") = False
                        dr("SerialNo") = 0
                        dr("status") = 0
                        dr("MREDtl_ID") = 0
                        dr("MREHdr_ID") = row.Cells(10).Text
                        dt.Rows.Add(dr)
                    End If
                Next
                dtissue3 = dt
                grdIssueItems.DataSource = dtissue3
                grdIssueItems.DataBind()
                btnsavedoc.Enabled = True
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

                grdIssueItems.DataSource = dtissue2
                grdIssueItems.DataBind()
            End If



            'For i As Integer = 0 To dtissue2.Rows.Count - 1
            '    If dtissue2.Rows(i)("status") = "Returned" Then
            '        If grListOfProperty.SelectedDataKey("status") = "Returned" Or grListOfProperty.SelectedDataKey("status") = " - " Then
            '            btnIssue.Enabled = True
            '        Else
            '            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Status did not match.")
            '            Exit Sub
            '        End If

            '    ElseIf dtissue2.Rows(i)("status") = "On Hand" Then
            '        If grListOfProperty.SelectedDataKey("status") = "On Hand" Then
            '            btnReturnProperty.Enabled = True
            '        Else
            '            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Status did not match.")
            '            Exit Sub
            '        End If

            '    End If
            'Next

        Catch ex As Exception
            ' MsgBox(ex.Message)
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

    Protected Sub CheckBox21_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'HERE
        Dim item As String

        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Val(txtHiddenReceiveQty.Value) - 1
                item = Me.grListOfProperty.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grListOfProperty.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                    'btnActSave.Enabled = True
                    ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = True
                    'pInspection_detail.Rows(Me.grdInspection.Rows(i).Cells(4).Text)("isChecked") = True


                End If
            Next
        Else
            For i As Integer = 0 To Val(txtHiddenReceiveQty.Value) - 1
                item = Me.grListOfProperty.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grListOfProperty.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                s.Checked = False
                ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = False
                ' pInspection_detail.Rows(Me.grdInspection.Rows(i).Cells(4).Text)("isChecked") = False
            Next
        End If


    End Sub
    Protected Sub cbInspection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


End Class
