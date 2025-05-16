Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Drawing
Partial Class Records_SupplierCard
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim myview As DataView
    Dim total As Decimal = 0

#Region "property"

    Private Property dtAccount() As DataTable
        Get
            Return CType(Session("dtAccount"), DataTable)

        End Get
        Set(ByVal value As DataTable)
            Session("dtAccount") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'txtSuppname.Text = ""
            If Session("Action") = "Search" Then
                txtSuppname.Text = Session("SupplierName")
                loadsearch()
                Session("Action") = ""

            Else
                ' Display the Supplier
                Dim Suppliertable As New DataTable
                Suppliertable = objDerived.GetDataTable("SELECT * from [AMS].[viewlistofSupplier] ORDER BY SuppName", CommandType.Text)
                If Suppliertable.Rows.Count < 10 Then
                    Suppliertable.Merge(createdatatablePO(9 - Suppliertable.Rows.Count))
                End If
                grdcompany.DataSource = Suppliertable
                grdcompany.DataBind()
                'grdcompany.SelectedIndex = 0
                '=== Display the Purchased Order
                'loadgrdcompnayIndex()
                'loadGrdPOorders()

                '=== Display the List of Goods
                'loadListofGoods()

                grpoorder.DataSource = createdatatablePO(4)
                grpoorder.DataBind()

                grdlistofgoods.DataSource = createdatatablePOwithItem(4)
                grdlistofgoods.DataBind()

                mvTabs.SetActiveView(vwTab1_Ledger)

                preview.Enabled = False
            End If

            txtSuppname.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

        Else

        End If
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        loadsearch()
    End Sub
    Protected Sub loadsearch()

        Dim Suppliertable As New DataTable
        Suppliertable = objDerived.GetDataTable("SELECT * from [AMS].[viewlistofSupplier] WHERE SuppName LIKE '%" & txtSuppname.Text & "%'ORDER BY SuppName", CommandType.Text)
        If Suppliertable.Rows.Count < 10 Then
            Suppliertable.Merge(createdatatablePO(9 - Suppliertable.Rows.Count))
        End If
        grdcompany.DataSource = Suppliertable
        grdcompany.DataBind()

        grpoorder.DataSource = createdatatablePO(4)
        grpoorder.DataBind()

        grdlistofgoods.DataSource = createdatatablePOwithItem(4)
        grdlistofgoods.DataBind()


        'Dim Suppliertable As New DataTable
        'Try
        '    Suppliertable = objDerived.GetDataTable("SELECT * from [AMS].[viewlistofSupplier]where SuppName like '%" & txtSuppname.Text & "%'", CommandType.Text)
        '    If Suppliertable.Rows.Count < 9 Then
        '        Suppliertable.Merge(createdatatableSupplier(9 - Suppliertable.Rows.Count))
        '        grdcompany.DataSource = Suppliertable
        '        grdcompany.DataBind()
        '        grdcompany.SelectedIndex = 0
        '    Else
        '        grdcompany.DataSource = objDerived.GetDataTable("SELECT * from [AMS].[viewlistofSupplier]", CommandType.Text)
        '        grdcompany.DataBind()
        '        grdcompany.SelectedIndex = 0
        '    End If
        '    loadGrdPOorders()
        '    loadgrdcompnayIndex()
        'Catch ex As Exception

        'End Try
    End Sub

    ' ==== MAIN DATAGRID ====
    Protected Sub grdcompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdcompany.SelectedIndexChanged
        Try
            loadgrdcompnayIndex()
            preview.Enabled = True


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.updatepanel1, "something went wrong, please contact system admin.")
        End Try

    End Sub
    Protected Sub loadgrdcompnayIndex()
        Dim SupplierInfoTable As New DataTable
        'SupplierInfoTable = objDerived.GetDataTable("SELECT * from [AMS].[viewSupplierInfor] where Supplier_Id = '" & grdcompany.SelectedDataKey(0) & "'", CommandType.Text)
        SupplierInfoTable = objDerived.GetDataTable("SELECT * FROM [dbo].[View_SuppliersInfo] where Supplier_Id = '" & grdcompany.SelectedDataKey(0) & "'", CommandType.Text)

        If SupplierInfoTable.Rows.Count = 0 Then
            '=== COMPANY INFORMATION
            lblcompanyname.Text = ""
            lblProduct.Text = ""
            lblSuppAddress.Text = ""
            lblEmailaddress.Text = ""


            '=== OWNER INFORMATION
            lblname.Text = ""
            lblPosition.Text = ""
            lbladdress.Text = ""
            lblContact.Text = ""
            lblemail.Text = ""
            lblBday.Text = ""
            lblage.Text = ""
            lblgender.Text = ""
            lblnationality.Text = ""




        Else
            Dim Company As String = objDerived.GetValue("select AttachedFile from dbo.Supplier where Supplier_Id = '" & grdcompany.SelectedDataKey(0) & "'", CommandType.Text)
            Dim Contact As String = objDerived.GetValue("select CPAttachedFile from dbo.Supplier where Supplier_Id = '" & grdcompany.SelectedDataKey(0) & "'", CommandType.Text)


            '=== COMPANY INFORMATION
            lblcompanyname.Text = IIf(IsDBNull(SupplierInfoTable.Rows(0)("SuppName").ToString), 0, (SupplierInfoTable.Rows(0)("SuppName").ToString))
            lblProduct.Text = SupplierInfoTable.Rows(0)("ProductService").ToString
            lblSuppAddress.Text = IIf(IsDBNull(SupplierInfoTable.Rows(0)("Address1").ToString), 0, (SupplierInfoTable.Rows(0)("Address1").ToString))
            Image1.ImageUrl = "~/images/" & Company


            '=== OWNER PROFILE
            lblname.Text = IIf(IsDBNull(SupplierInfoTable.Rows(0)("ContactP").ToString), 0, (SupplierInfoTable.Rows(0)("ContactP").ToString))
            lblPosition.Text = IIf(IsDBNull(SupplierInfoTable.Rows(0)("Position").ToString), 0, (SupplierInfoTable.Rows(0)("Position").ToString))
            lbladdress.Text = IIf(IsDBNull(SupplierInfoTable.Rows(0)("Address2").ToString), 0, (SupplierInfoTable.Rows(0)("Address2").ToString))
            lblContact.Text = IIf(IsDBNull(SupplierInfoTable.Rows(0)("contactno").ToString), 0, (SupplierInfoTable.Rows(0)("contactno").ToString))
            lblemail.Text = IIf(IsDBNull(SupplierInfoTable.Rows(0)("EmailAddress").ToString), 0, (SupplierInfoTable.Rows(0)("EmailAddress").ToString))
            lblBday.Text = IIf(IsDBNull(SupplierInfoTable.Rows(0)("CBdate").ToString), 0, (SupplierInfoTable.Rows(0)("CBdate").ToString))
            lblage.Text = IIf(IsDBNull(SupplierInfoTable.Rows(0)("CAge").ToString), 0, (SupplierInfoTable.Rows(0)("CAge").ToString))
            lblgender.Text = IIf(IsDBNull(SupplierInfoTable.Rows(0)("Cgender").ToString), 0, (SupplierInfoTable.Rows(0)("Cgender").ToString))
            lblnationality.Text = IIf(IsDBNull(SupplierInfoTable.Rows(0)("CNationality").ToString), 0, (SupplierInfoTable.Rows(0)("CNationality").ToString))
            Image2.ImageUrl = "~/images/" & Contact

        End If

        loadGrdPOorders()
        loadListofGoods()
    End Sub
    Protected Sub grdcompany_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdcompany.PageIndexChanging
        Dim Suppliertable As New DataTable
        Suppliertable = objDerived.GetDataTable("SELECT * from [AMS].[viewlistofSupplier] ORDER BY SuppName", CommandType.Text)
        grdcompany.SelectedIndex = 1
        grdcompany.PageIndex = e.NewPageIndex
        grdcompany.DataSource = Suppliertable
        grdcompany.DataBind()
    End Sub

    ' RowDataBound
    Protected Sub grdcompany_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdcompany.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdcompany, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grpoorder_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grpoorder.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grpoorder, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    ' ==== PURCHASED ORDER ==== 
    Protected Sub loadGrdPOorders()
        dtAccount = objDerived.GetDataTable("EXEC [AMS].[sp_SupplierPO_List] '" & grdcompany.SelectedDataKey(0) & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatablePO(3 - dtAccount.Rows.Count))
        End If
        grpoorder.DataSource = dtAccount
        grpoorder.DataBind()

        'grpoorder.SelectedIndex = 0
        'loadListofGoods()

        ' =================== ORIGINAL CODE BY LENARD =================
        'dtAccount = objDerived.GetDataTable("EXEC [dbo].[spListofSupplierwithPO] " & grdcompany.SelectedDataKey(0) & "", CommandType.Text)
        'If dtAccount.Rows.Count < 4 Then
        '    dtAccount.Merge(createdatatablePO(3 - dtAccount.Rows.Count))
        'End If
        'grpoorder.DataSource = dtAccount
        'grpoorder.DataBind()
        'grpoorder.SelectedIndex = 0
        ' =============================================================
    End Sub
    Protected Sub grpoorder_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grpoorder.SelectedIndexChanged
        loadListofGoods()
        preview.Enabled = True
    End Sub
    Protected Sub grpoorder_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grpoorder.PageIndexChanging
        dtAccount = objDerived.GetDataTable("EXEC [AMS].[sp_SupplierPO_List] '" & grdcompany.SelectedDataKey(0) & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatablePO(3 - dtAccount.Rows.Count))
        End If
        grpoorder.PageIndex = e.NewPageIndex
        grpoorder.DataSource = dtAccount
        grpoorder.DataBind()
    End Sub

    ' ==== LIST OF GOODS ====
    Protected Sub loadListofGoods()
        dtAccount = objDerived.GetDataTable("exec [AMS].[SupplierLedgerCard]'" & grdcompany.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
        If dtAccount.Rows.Count < 4 Then
            dtAccount.Merge(createdatatablePOwithItem(3 - dtAccount.Rows.Count))
        End If
        grdlistofgoods.DataSource = dtAccount
        grdlistofgoods.DataBind()


    End Sub
    Protected Sub grdlistofgoods_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdlistofgoods.PageIndexChanging
        Dim PoWithPRTable As New DataTable
        PoWithPRTable = objDerived.GetDataTable("exec [AMS].[SupplierLedgerCard]'" & grdcompany.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
        grdlistofgoods.SelectedIndex = 1
        grdlistofgoods.PageIndex = e.NewPageIndex
        grdlistofgoods.DataSource = PoWithPRTable
        grdlistofgoods.DataBind()

    End Sub

    ' ==== CreateDataTables ====
    Public Function createdatatableSupplier(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("ProductService", GetType(String))
        dt.Columns.Add("Address1", GetType(String))
        dt.Columns.Add("Officeno", GetType(String))
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("ContactP", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = ""
            dr("ProductService") = ""
            dr("Address1") = ""
            dr("Officeno") = ""
            dr("Supplier_Id") = DBNull.Value ' "0"
            dr("ContactP") = ""
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatablePO(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("PO_Date", GetType(Date))
        dt.Columns.Add("ContractPrice", GetType(Decimal))
        dt.Columns.Add("Supplier_ID", GetType(Long))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("Function_Desc", GetType(String))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("ProjectName", GetType(String))
        dt.Columns.Add("DV_No", GetType(String))
        dt.Columns.Add("Check_No", GetType(String))
        dt.Columns.Add("AmountPaid", GetType(String))
        dt.Columns.Add("JEV_No", GetType(String))
        dt.Columns.Add("POHdr_id", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PO_No") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("ContractPrice") = DBNull.Value
            dr("Supplier_ID") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("Function_Desc") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("ProjectName") = DBNull.Value
            dr("DV_No") = DBNull.Value
            dr("Check_No") = DBNull.Value
            dr("AmountPaid") = DBNull.Value
            dr("JEV_No") = DBNull.Value
            dr("POHdr_id") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatablePOwithItem(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("POHdr_Id", GetType(Integer))
        dt.Columns.Add("PO_Date", GetType(Date))
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("Particular", GetType(String))
        dt.Columns.Add("REF_No", GetType(String))
        dt.Columns.Add("Debit", GetType(Decimal))
        dt.Columns.Add("Credit", GetType(Decimal))
        dt.Columns.Add("Bal", GetType(Decimal))
        dt.Columns.Add("Remarks", GetType(String))

        'dt.Columns.Add("itemissued", GetType(Integer))
        'dt.Columns.Add("dateissued", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow

            dr("POHdr_Id") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("PO_No") = DBNull.Value
            dr("Particular") = DBNull.Value
            dr("REF_No") = DBNull.Value
            dr("Debit") = DBNull.Value
            dr("Credit") = DBNull.Value
            dr("Bal") = DBNull.Value
            dr("Remarks") = DBNull.Value

            'dr("itemissued") = DBNull.Value
            'dr("dateissued") = ""
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Private Sub btnTab1_Ledger_Click(sender As Object, e As EventArgs) Handles btnTab1_Ledger.Click
        btnTab1_Ledger.CssClass = "TabButton_Active"
        btnTab2_Product.CssClass = "TabButton_InActive"
        btnTab3_Documents.CssClass = "TabButton_InActive"

        mvTabs.SetActiveView(vwTab1_Ledger)
    End Sub

    Private Sub btnTab3_Documents_Click(sender As Object, e As EventArgs) Handles btnTab3_Documents.Click
        btnTab1_Ledger.CssClass = "TabButton_InActive"
        btnTab2_Product.CssClass = "TabButton_InActive"
        btnTab3_Documents.CssClass = "TabButton_Active"

        mvTabs.SetActiveView(vwTab2_Documents)
    End Sub

    Private Sub btnTab2_Product_Click(sender As Object, e As EventArgs) Handles btnTab2_Product.Click
        btnTab1_Ledger.CssClass = "TabButton_InActive"
        btnTab2_Product.CssClass = "TabButton_Active"
        btnTab3_Documents.CssClass = "TabButton_InActive"

        Dim dt As System.Data.DataTable = New System.Data.DataTable()
        dt.Columns.AddRange(New System.Data.DataColumn() {
                                New System.Data.DataColumn("ProductID", GetType(Integer)),
                                New System.Data.DataColumn("ProductName", GetType(String)),
                                New System.Data.DataColumn("image", GetType(String)),
                                New System.Data.DataColumn("Price", GetType(String))})
        dt.Rows.Add(1, "Product 1", "~/Images/22.png", "100Php")
        dt.Rows.Add(2, "Product 2", "~/Images/Ambulance.jpg", "150Php")
        dt.Rows.Add(3, "Product 3", "~/Images/attendance.jpg", "200Php")
        dt.Rows.Add(4, "Product 4", "~/Images/blankImage.jpg", "250Php")
        dt.Rows.Add(5, "Product 5", "~/Images/blankImage.jpg", "350Php")
        dt.Rows.Add(6, "Product 1", "~/Images/22.png", "100Php")
        dt.Rows.Add(7, "Product 2", "~/Images/Ambulance.jpg", "150Php")
        dt.Rows.Add(8, "Product 3", "~/Images/attendance.jpg", "200Php")
        dt.Rows.Add(9, "Product 4", "~/Images/blankImage.jpg", "250Php")
        dt.Rows.Add(10, "Product 5", "~/Images/blankImage.jpg", "350Php")
        ListView1.DataSource = dt
        ListView1.DataBind()

        mvTabs.SetActiveView(SupplierItems)
    End Sub

    Protected Sub preview_Click(sender As Object, e As EventArgs)
        Try
            Session("Supplier_id") = grdcompany.SelectedDataKey("Supplier_Id")
            Me.Page.Response.Redirect("~/MainReports/rpt_SupplierLedger.aspx")


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.updatepanel1, "something went wrong, please contact system admin.")
        End Try
    End Sub

    Protected Sub btnDTI_Click(sender As Object, e As EventArgs)
        Try
            ModalPopupExtender5.show()
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.updatepanel1, "something went wrong, please contact system admin.")
        End Try
    End Sub


    Protected Sub BtnTax_Click(sender As Object, e As EventArgs)
        ModalPopupExtender5.show()
    End Sub

    Protected Sub BtnSEC_Click(sender As Object, e As EventArgs)
        ModalPopupExtender5.show()
    End Sub
End Class

