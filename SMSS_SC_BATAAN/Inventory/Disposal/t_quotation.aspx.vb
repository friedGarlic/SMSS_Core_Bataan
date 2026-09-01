Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class t_quotation
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal

    Private hdr As New Disposal_quotation_hdr
    Private dtl As New Disposal_quotation_dtl
    Private lot As New Disposal_quotation_Lot

    Dim DSupplies_Hdr As New Disposal_Supplies.Disposal_Supplies_Hdr
    Dim DSupplies_Dtl As New Disposal_Supplies.Disposal_Supplies_Dtl

    Private No As Integer


#Region "Property"
    Private Property pGoodsPerSupplier(ByVal supplier_id As String) As DataTable
        Get
            Return CType(Session(supplier_id), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session(supplier_id) = value
        End Set
    End Property

    Private Property pGoods() As DataTable
        Get
            Return CType(Session("pGoods"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pGoods") = value
        End Set
    End Property
    Private Property pTempSupplier() As DataTable
        Get
            Return CType(Session("pTempSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pTempSupplier") = value
        End Set
    End Property
    Private Property pSupplier() As DataTable
        Get
            Return CType(Session("pSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pSupplier") = value
        End Set
    End Property

    Private Property dtListBidders() As DataTable
        Get
            Return CType(Session("dtListBidders"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtListBidders") = value
        End Set
    End Property

    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property

    Private Property TotalAmount() As Decimal
        Get
            Return CType(Session("TotalAmount"), Decimal)
        End Get
        Set(ByVal value As Decimal)
            Session("TotalAmount") = value
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
    Private Property pPublicBidding() As DataTable
        Get
            Return CType(Session("pPublicBidding"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPublicBidding") = value
        End Set
    End Property

    Private Property dtSupply() As DataTable
        Get
            Return CType(Session("dtSupply"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSupply") = value
        End Set
    End Property

    Private Property dtBidder() As DataTable
        Get
            Return CType(Session("dtBidder"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtBidder") = value
        End Set
    End Property

    Private Property dtBidder2() As DataTable
        Get
            Return CType(Session("dtBidder2"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtBidder2") = value
        End Set
    End Property



#End Region
#Region "Function"
    Public Function CreateTableGoods(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("PropertyNo")
        dt.Columns.Add("Item_Desc")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Details")
        dt.Columns.Add("Property_ID", GetType(Integer))
        'dt.Columns.Add("Description")
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("enable", GetType(Boolean))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PropertyNo") = ""
            dr("Item_Desc") = ""
            dr("Unit") = ""
            dr("Details") = ""
            dr("Property_ID") = 0
            dr("Cost") = "0.00"
            'dr("total") = "0.00"
            dr("enable") = False
            dr("isVisible") = False

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("pr_no")
        dt.Columns.Add("IIRUPHdr_ID", GetType(Integer))
        dt.Columns.Add("IIRUP_Date", GetType(Date))
        dt.Columns.Add("Description")
        dt.Columns.Add("Disposal_id", GetType(Integer))
        dt.Columns.Add("status", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("PropertyNo")

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("IIRUPHdr_ID") = 0
            dr("IIRUP_Date") = "01/01/1900"
            dr("Description") = ""
            dr("Disposal_id") = 0
            dr("status") = 0
            dr("isVisible") = False
            dr("PropertyNo") = ""
            'dr("isClosed") = False
            'dr("isRebid") = False
            'dr("RC_ID") = 0
            'dr("Function_ID") = 0
            'dr("Project_ID") = 0
            'dr("Program_id") = 0
            'dr("rc_name") = ""

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatableSuppliers(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName")
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("date", GetType(Date))
        dt.Columns.Add("status", GetType(String))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("isOld", GetType(Boolean))
        dt.Columns.Add("lot", GetType(Decimal))
        dt.Columns.Add("quotation_hdr_id", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = DBNull.Value
            dr("Supplier_Id") = DBNull.Value
            dr("isVisible") = False
            dr("date") = CType("01/01/1900", Date)
            dr("status") = DBNull.Value
            dr("cost") = DBNull.Value
            dr("isOld") = False
            dr("lot") = DBNull.Value
            dr("quotation_hdr_id") = DBNull.Value
            'dr("SuppName") = DBNull.Value
            'dr("Supplier_Id") = DBNull.Value
            'dr("isVisible") = DBNull.Value
            'dr("date") = DBNull.Value
            'dr("status") = DBNull.Value
            'dr("isOld") = DBNull.Value
            'dr("quotation_hdr_id") = DBNull.Value
            'dr("cost") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then

                obj.GetAccessRight(Me.Session("@UserName"), Page)
                If obj.HasAccess = False Then
                    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
                End If

                rbChoice.SelectedItem.Value = 1
                LoadrbChoice()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "pr_no"
    End Sub
    Protected Sub lbApprove_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "close"
    End Sub
    Protected Sub lbSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "supplier"
    End Sub
    Protected Sub lbApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "close"
    End Sub
    Protected Sub lblAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "add"
    End Sub
    Protected Sub gvPublic_bidding_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadChecking()
        Me.Session("Status") = 1
        Me.Session("Biddate") = gvPublic_bidding.SelectedDataKey("BidDate")
        Me.Session("dis_id") = gvPublic_bidding.SelectedDataKey(2)
        Me.Session("IIRUPHdr_ID") = gvPublic_bidding.SelectedDataKey(0)
        If Lbtn = "pr_no" Then

            If gvPublic_bidding.SelectedDataKey("Description") = "" Then
                '    ddSupplier.Visible = False
                '    txtPrivateSale.Visible = True
                '    btnsupplier.Enabled = True
                '    lblNameDis.Text = "Name :"
            Else
                ddSupplier.Visible = True
                Dim HDRID As Integer = objDerived.getValue("Select TOP 1 quotation_hdr_id from ams.Disposal_quotation_hdr where IIRUPHDR_ID ='" & Session("IIRUPHdr_ID") & "'", CommandType.text)
                Me.Session("hdrid") = HDRID

                pSupplier = objDerived.GetDataTable("exec ams.sp_supplier_per_bid " & gvPublic_bidding.SelectedDataKey(0) & "," & gvPublic_bidding.SelectedDataKey(2) & "", CommandType.Text)

                pTempSupplier = objDerived.GetDataTable("exec ams.sp_supplier_per_bid " & gvPublic_bidding.SelectedDataKey(0) & "," & gvPublic_bidding.SelectedDataKey(2) & "", CommandType.Text)
                If pTempSupplier.Rows.Count < 5 Then
                    pTempSupplier.Merge(createdatatableSuppliers(4 - pTempSupplier.Rows.Count))
                End If

                If pSupplier.Rows.Count >= 1 Then
                    For i As Integer = 0 To pSupplier.Rows.Count - 1
                        pGoodsPerSupplier(pSupplier.Rows(i)("Supplier_Id").ToString) = objDerived.GetDataTable("exec ams.sp_goods_per_bid_existing " & gvPublic_bidding.SelectedDataKey(0) & "," & gvPublic_bidding.SelectedDataKey(2) & ", " & pSupplier.Rows(i)("Supplier_Id") & "", CommandType.Text)
                    Next
                End If

                gvsupplier.DataSource = pTempSupplier
                gvsupplier.DataBind()

                Me.Session("iirupid") = gvPublic_bidding.SelectedDataKey(0)

                Session("Disposal_id") = gvPublic_bidding.SelectedDataKey(2)
                Session("canvassdetail") = objDerived.GetDataTable("exec AMS.quotationdetail " & gvPublic_bidding.SelectedDataKey(2) & "," & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)

                'pGoods = objDerived.GetDataTable("exec AMS.quotationdetail " & gvPublic_bidding.SelectedDataKey(2) & "," & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
                'gvitems.DataSource = pGoods 'CType(Me.Session("canvassdetail"), DataTable)
                'gvitems.DataBind()


                For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                    Dim txtcost As TextBox = CType(Me.gvitems.Rows(i).FindControl("txtCost"), TextBox)
                    txtcost.ReadOnly = True
                Next
                ddSupplier.Items.Clear()
                ddSupplier.Items.Add("Select")

                ddSupplier.DataSource = objDerived.GetRecords("exec ams.sp_supplier_per_bid_default " & gvPublic_bidding.SelectedDataKey(0) & "," & gvPublic_bidding.SelectedDataKey(2) & "", CommandType.Text)
                ddSupplier.DataTextField = "SuppName"
                ddSupplier.DataValueField = "Supplier_Id"
                ddSupplier.DataBind()

                ddSupplier.Enabled = True
                btnsupplier.Enabled = True
                btnsubmit.Enabled = False
                RadioButtonList1.Enabled = True
            End If

        ElseIf Lbtn = "close" Then
            Try
                Me.Session("hdrid") = objDerived.GetValue("exec [AMS].[hdridses] " & gvPublic_bidding.SelectedDataKey(0) & "," & gvPublic_bidding.SelectedDataKey(2) & "", CommandType.Text)
                objDerived.GetRecords("Update AMS.Disposal_quotation_hdr set Iscomplete=1 where IIRUPHdr_ID ='" & gvPublic_bidding.SelectedDataKey(0) & "' and Disposal_ID = '" & gvPublic_bidding.SelectedDataKey(2) & "'", CommandType.Text)

                pPublicBidding = objDerived.GetDataTable("exec AMS.quotationnew", CommandType.Text)
                If pPublicBidding.Rows.Count < 8 Then
                    pPublicBidding.Merge(createdatatable(7 - pPublicBidding.Rows.Count))
                End If
                gvPublic_bidding.DataSource = pPublicBidding
                gvPublic_bidding.DataBind()
                gvPublic_bidding.SelectedIndex = -1

                ddSupplier.Items.Clear()
                ddSupplier.Enabled = False
                btnsupplier.Enabled = True

                pSupplier = Nothing
                pTempSupplier = Nothing

                gvsupplier.DataSource = (createdatatableSuppliers(7))
                gvsupplier.DataBind()

                pGoods = Nothing

                gvitems.DataSource = CreateTableGoods(7)
                gvitems.DataBind()

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Transaction has been successfully closed.")
            Catch ex As Exception

            End Try
        End If
        Dim NoOfBidders As Integer
        NoOfBidders = gvPublic_bidding.SelectedDataKey("Bidders")
        If NoOfBidders > 0 Then
            btnsupplier.Enabled = False
        Else
            btnsupplier.Enabled = True
        End If
    End Sub
    Protected Sub btnsupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Dim dt As New DataTable()
            'Dim dr As DataRow
            'Dim myDataColumn As DataColumn

            'myDataColumn = New DataColumn()
            'dt.Columns.Add("SuppName")
            'dt.Columns.Add("Supplier_Id", GetType(Long))
            'dt.Columns.Add("isVisible", GetType(Boolean))
            'dt.Columns.Add("date", GetType(Date))
            'dt.Columns.Add("status")
            'dt.Columns.Add("isOld", GetType(Boolean))
            'dt.Columns.Add("lot", GetType(Decimal))
            'dt.Columns.Add("quotation_hdr_id", GetType(Integer))

            'dr = dt.NewRow
            'dr("SuppName") = ddSupplier.SelectedItem.Text
            'dr("Supplier_Id") = ddSupplier.SelectedItem.Value
            'dr("isVisible") = True
            'dr("date") = Date.Today.ToString("MM/dd/yyyy")
            'dr("status") = ""
            'dr("isOld") = False
            'dr("lot") = "0.00"
            'dr("quotation_hdr_id") = 0
            'dt.Rows.Add(dr)

            'pSupplier.Merge(dt)
            'pTempSupplier = Nothing
            'pTempSupplier = pSupplier
            'gvsupplier.DataSource = pTempSupplier
            'gvsupplier.DataBind()

            'ddSupplier.Enabled = True
            'btnsupplier.Enabled = True

            'pGoodsPerSupplier(ddSupplier.SelectedItem.Value.ToString) = Me.Session("canvassdetail") ''objDerived.GetDataTable("exec ams.sp_goods_per_bid " & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
            'btnsubmit.Enabled = True

            'Dim row As Integer = pTempSupplier.Compute("count(Supplier_Id)", "Supplier_Id<>0")
            'gvsupplier.SelectedIndex = row - 1

            'Dim data As New DataTable
            'data = pGoodsPerSupplier(ddSupplier.SelectedItem.Value.ToString)
            'Dim a As String = ddSupplier.SelectedItem.Value.ToString
            'ddSupplier.SelectedIndex = 0

            'Refactor
            Dim dt As New DataTable()
            With dt.Columns
                .Add("SuppName")
                .Add("Supplier_Id", GetType(Long))
                .Add("isVisible", GetType(Boolean))
                .Add("date", GetType(Date))
                .Add("status")
                .Add("isOld", GetType(Boolean))
                .Add("lot", GetType(Decimal))
                .Add("quotation_hdr_id", GetType(Integer))
            End With

            ' Create a new row and set its values
            Dim dr As DataRow = dt.Rows.Add()
            With dr
                .Item("SuppName") = ddSupplier.SelectedItem.Text
                .Item("Supplier_Id") = ddSupplier.SelectedItem.Value
                .Item("isVisible") = True
                .Item("date") = Date.Today
                .Item("status") = ""
                .Item("isOld") = False
                .Item("lot") = 0D
                .Item("quotation_hdr_id") = 0
            End With

            ' Merge the new row into the existing data table
            pSupplier.Merge(dt)

            ' Bind the grid view to the data source
            gvsupplier.DataSource = pSupplier
            gvsupplier.DataBind()

            ' Enable controls as needed
            ddSupplier.Enabled = True
            btnsupplier.Enabled = True

            ' Set the data source for the goods per supplier drop-down
            pGoodsPerSupplier(ddSupplier.SelectedItem.Value.ToString) = Me.Session("canvassdetail")
            btnsubmit.Enabled = True


            ' Select the last row in the grid view
            Dim row As Integer = pSupplier.Compute("count(Supplier_Id)", "Supplier_Id<>0")
            gvsupplier.SelectedIndex = row - 1

            ' Reset the goods per supplier drop-down to its default value
            ddSupplier.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To Me.gvsupplier.Rows.Count - 1
            Dim a As Double = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(0)("cost")
        Next

        Dim Stats As Integer = objDerived.GetValue("Select Count(AMS.Disposal_quotation_dtl.Supplier_Id) As Expr1 From AMS.Disposal_quotation_hdr INNER Join  AMS.Disposal_quotation_dtl ON AMS.Disposal_quotation_hdr.quotation_hdr_id = AMS.Disposal_quotation_dtl.quotation_hdr_id Where AMS.Disposal_quotation_hdr.IIRUPHdr_ID ='" & Session("IIRUPHdr_ID") & "' And AMS.Disposal_quotation_hdr.Disposal_id = 2 ", CommandType.Text)
        ' Try
        Dim Supplier_id As TextBox
        If RadioButtonList1.SelectedItem.Value Is Nothing Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Please select if Per Lot or Per Item.")
        End If

        If Stats = 0 Then

            hdr.quotation_date = Session("Biddate")
            hdr.Iscomplete = False
            hdr.withBID = False
            hdr.Disposal_id = Session("dis_id")
            hdr.IIRUPHdr_ID = Session("IIRUPHdr_ID")
            Dim hdrid As Long = hdr.save
            Session("hdrid") = hdrid

        End If

        '=== NEW 041216 (CHECK TYPE OF AUCTION)
        If RadioButtonList1.SelectedItem.Value = 1 Then
            '=== PER ITEMS
            objDerived.GetRecords("UPDATE AMS.Disposal_quotation_hdr SET perItems = 1, perLOT = 0 WHERE quotation_hdr_id = '" & Session("hdrid") & "'", CommandType.Text)

            If gvsupplier.SelectedDataKey(1) = False Then
                If pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(cost)", "") = "0.00" Then
                    Me.Session("Compliance") = False
                Else
                    Me.Session("Compliance") = True
                End If

                For i As Integer = 0 To Me.gvsupplier.Rows.Count - 1
                    'objDerived.GetValue("Select Supplier_id from dbo.Supplier where suppname='" & pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(i)("SuppName") & "'", CommandType.Text)

                    dtl.quotation_hdr_id = Me.Session("hdrid")
                    dtl.Supplier_Id = Val(gvsupplier.Rows(i).Cells(1).Text)
                    dtl.PropertyNo = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(0)("PropertyNo")
                    dtl.cost = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(0)("cost")
                    dtl.Compliance = Me.Session("Compliance")
                    dtl.quotation_date_dtl = Date.Today.ToString("MM/dd/yyyy")
                    dtl.save()
                    CType(gvitems.Rows(0).FindControl("txtcost"), TextBox).ReadOnly = True
                    objDerived.GetRecords("Update AMS.IIRUP_Dtl set withQuote=1 where PropertyNo='" & pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(0)("PropertyNo") & "' and Disposal_id <> 5", CommandType.Text)
                Next

                For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                    Dim txtcost As TextBox = CType(Me.gvitems.Rows(i).FindControl("txtCost"), TextBox)
                    txtcost.ReadOnly = True
                Next

            Else
                For i As Integer = 0 To pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows.Count - 1
                    Dim x1 As Decimal
                    Dim propNo As String
                    Dim Supp As Integer
                    Dim idd As Integer

                    x1 = CType(Me.gvitems.Rows(i).Cells(3).FindControl("txtCost"), TextBox).Text
                    propNo = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(i)("PropertyNo")
                    Supp = gvsupplier.SelectedDataKey(0)
                    idd = gvsupplier.SelectedDataKey(2)

                    objDerived.GetRecords("Update AMS.Disposal_quotation_dtl set cost = '" & CType(x1, Decimal) & "' where PropertyNo = '" & pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(i)("PropertyNo") & "' and Supplier_Id = '" & gvsupplier.SelectedDataKey(0) & "' and quotation_hdr_id = '" & gvsupplier.SelectedDataKey(2) & "'", CommandType.Text)
                Next
            End If

        ElseIf RadioButtonList1.SelectedItem.Value = 2 Then
            '=== LOT
            objDerived.GetRecords("UPDATE AMS.Disposal_quotation_hdr SET perItems = 0, perLOT = 1 WHERE quotation_hdr_id = '" & Session("hdrid") & "'", CommandType.Text)

            Dim quotation_Lot_ID As Long
            quotation_Lot_ID = objDerived.GetValue("SELECT quotation_Lot_ID FROM AMS.Disposal_quotation_Lot WHERE quotation_hdr_id = '" & gvsupplier.SelectedDataKey(2) & "' AND Supplier_Id = '" & gvsupplier.SelectedDataKey(0) & "'", CommandType.Text)

            With lot
                .quotation_hdr_id = Session("hdrid")
                .Supplier_Id = gvsupplier.SelectedDataKey(0)
                If txtTotalAmount.Text = "" Then
                    txtTotalAmount.Text = 0
                End If
                .TotalAmount = txtTotalAmount.Text
                .Compliance = True
                .quotation_date_dtl = Date.Today.ToString("MM/dd/yyyy")
            End With

            If quotation_Lot_ID = 0 Then
                lot.save()
                objDerived.GetRecords("Update AMS.IIRUP_Dtl set withQuote = 1 where IIRUPHdr_ID = '" & Session("iirupid") & "'", CommandType.Text)
            Else
                lot.update()
            End If


        End If


        MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Transaction has been successfully saved.")

        pPublicBidding = objDerived.GetDataTable("exec AMS.quotationnew", CommandType.Text)
        If pPublicBidding.Rows.Count < 8 Then
            pPublicBidding.Merge(createdatatable(7 - pPublicBidding.Rows.Count))
        End If
        gvPublic_bidding.DataSource = pPublicBidding
        gvPublic_bidding.DataBind()
        gvPublic_bidding.SelectedIndex = -1

        pSupplier = Nothing
        pTempSupplier = Nothing

        gvsupplier.DataSource = (createdatatableSuppliers(7))
        gvsupplier.DataBind()
        gvsupplier.SelectedIndex = -1
        gvitems.DataSource = CreateTableGoods(7)
        gvitems.DataBind()

        'Catch ex As Exception
        'End Try
    End Sub
    Protected Sub gvsupplier_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvsupplier.PageIndexChanging
        Me.gvsupplier.PageIndex = e.NewPageIndex
        Me.gvsupplier.DataSource = CType(pSupplier, DataTable)
        Me.gvsupplier.DataBind()
    End Sub
    Protected Sub LoadChecking()
        Dim checkID As Integer
        checkID = objDerived.GetValue("SELECT quotation_hdr_id FROM AMS.Disposal_quotation_hdr WHERE IIRUPHdr_ID = '" & gvPublic_bidding.SelectedDataKey(0) & "'", CommandType.Text)
        If checkID = 0 Then
            'RadioButtonList1.Enabled = True
            'RadioButtonList1.SelectedIndex = -1
            gvitems.DataSource = Nothing
            gvitems.DataBind()
        Else
            Dim perItems As Boolean
            perItems = objDerived.GetValue("SELECT perItems FROM AMS.Disposal_quotation_hdr WHERE IIRUPHdr_ID = '" & gvPublic_bidding.SelectedDataKey(0) & "'", CommandType.Text)
            If perItems = True Then
                Me.mvType.SetActiveView(Me.vwPerItems)
                RadioButtonList1.SelectedIndex = 0

                pGoods = objDerived.GetDataTable("exec AMS.quotationdetail " & gvPublic_bidding.SelectedDataKey(2) & "," & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
                gvitems.DataSource = pGoods
                gvitems.DataBind()

                Session("Type") = "perItems"
            Else
                Me.mvType.SetActiveView(Me.vwPerLot)
                RadioButtonList1.SelectedIndex = 1

                pGoods = objDerived.GetDataTable("EXEC [AMS].[sp_Quotation_PerLot] " & gvPublic_bidding.SelectedDataKey(0) & "," & gvPublic_bidding.SelectedDataKey(2) & "", CommandType.Text)
                grdPerLot.DataSource = pGoods
                grdPerLot.DataBind()

                Session("Type") = "perLot"
            End If

            RadioButtonList1.Enabled = False
        End If
    End Sub


    Protected Sub gvsupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvsupplier.SelectedIndexChanged
        btnsubmit.Enabled = True

        '=== ADDED 04122016 CHECK WHAT TYPE OF AUCTION ====
        LoadChecking()
        '==================================================

        If Lbtn = "supplier" Then
            Dim data As New DataTable
            data = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString)
            gvitems.DataSource = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString)
            gvitems.DataBind()

            For i As Integer = 0 To pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows.Count - 1
                Dim txtcost As TextBox = CType(gvitems.Rows(i).FindControl("txtcost"), TextBox)
                txtcost.Enabled = True
                txtcost.Attributes.Add("onclick", "this.select()")
                txtcost.Attributes.Add("onFocus", "this.select()")
            Next

            If Session("Type") = "perItems" Then
                ScriptManager.GetCurrent(Me.Page).SetFocus(CType(Me.gvitems.Rows(0).Cells(3).FindControl("txtcost"), TextBox))

            Else
                Dim Total As Decimal
                Total = objDerived.GetValue("SELECT TotalAmount FROM AMS.Disposal_quotation_Lot WHERE Supplier_Id = '" & gvsupplier.SelectedDataKey(0) & "' AND quotation_hdr_id = '" & gvsupplier.SelectedDataKey(2) & "'", CommandType.Text)
                txtTotalAmount.Text = FormatNumber(Total, 2)
            End If

        End If
    End Sub
    Protected Sub txtCost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtCost As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtCost.NamingContainer, GridViewRow)
            If txtCost.Text = "" Then
                txtCost.Text = "0.00"
            End If
            txtCost.Text = FormatNumber(txtCost.Text, 2)
            Dim data As New DataTable
            data = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString)
            Me.Session("rowindex") = gvr.RowIndex
            pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("cost") = txtCost.Text
            Dim txt As TextBox = CType(Me.gvitems.Rows(gvr.RowIndex + 1).Cells(3).FindControl("txtCost"), TextBox)
            ScriptManager.GetCurrent(Me.Page).SetFocus(txt)

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSupplier.SelectedIndex = 0 Then
            btnsupplier.Enabled = False
        Else
            btnsupplier.Enabled = True
            'gvitems.DataSource = pGoods
            'gvitems.DataBind()
            'gvsupplier.SelectedIndex = -1

        End If

    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadrbChoice()
    End Sub

    Protected Sub LoadrbChoice()
        If rbChoice.SelectedItem.Value = 1 Then
            Me.mvCategory.SetActiveView(Me.vwProperty)

            pPublicBidding = objDerived.GetDataTable("exec AMS.quotationnew", CommandType.Text)
            If pPublicBidding.Rows.Count < 5 Then
                pPublicBidding.Merge(createdatatable(4 - pPublicBidding.Rows.Count))
            End If
            gvPublic_bidding.DataSource = pPublicBidding
            gvPublic_bidding.DataBind()

            pSupplier = Nothing
            pTempSupplier = Nothing

            gvsupplier.DataSource = createdatatableSuppliers(4)
            gvsupplier.DataBind()

            'gvitems.DataSource = CreateTableGoods(4)
            'gvitems.DataBind()

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            Me.mvCategory.SetActiveView(Me.vwSupply)
            LoadSupplies()

        End If

    End Sub

    Protected Sub LoadSupplies()
        Dim dtQuot As New DataTable
        dtQuot = objDerived.GetDataTable("SELECT * FROM [dbo].[View_IIRUS_Quotation] WHERE Disposal_id = 1 OR Disposal_id = 2 ORDER BY IIRUS_ID DESC", CommandType.Text)
        grdSuppList.DataSource = dtQuot
        grdSuppList.DataBind()

        grdItemList.DataSource = Nothing
        grdItemList.DataBind()

        grdBidders.DataSource = Nothing
        grdBidders.DataBind()
    End Sub

    Protected Sub grdSupply_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        dtBidder = Nothing

        'Session("Disposal_id") = grdSupply.SelectedDataKey("Disposal_id")
        'Session("IIRUS_Dtl_ID") = grdSupply.SelectedDataKey("IIRUS_Dtl_ID")

        ddSupplier2.DataSource = objDerived.GetRecords("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
        ddSupplier2.DataTextField = "SuppName"
        ddSupplier2.DataValueField = "Supplier_Id"
        ddSupplier2.DataBind()
        ddSupplier2.Items.Insert(0, "Select")

    End Sub

    Protected Sub grdSuppList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        ddSupplier2.DataSource = objDerived.GetRecords("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
        ddSupplier2.DataTextField = "SuppName"
        ddSupplier2.DataValueField = "Supplier_Id"
        ddSupplier2.DataBind()
        ddSupplier2.Items.Insert(0, "Select")

        dtSupply = objDerived.GetDataTable("EXEC [AMS].[sp_IIRUS_QuotationList] '" & grdSuppList.SelectedDataKey("IIRUS_ID") & "'", CommandType.Text)
        grdItemList.DataSource = dtSupply
        grdItemList.DataBind()

        Dim x As Decimal = 0
        For i As Integer = 0 To grdItemList.Rows.Count - 1
            Dim BidUnitPrice As TextBox = CType(grdItemList.Rows(i).FindControl("txtBidPrice"), TextBox)
            Dim Qty As Label = CType(grdItemList.Rows(i).FindControl("lblQty"), Label)

            Dim TAmount As Decimal = FormatNumber(BidUnitPrice.Text * Qty.Text, 2)
            CType(grdItemList.Rows(i).FindControl("lblTotal"), Label).Text = TAmount

            x = x + (BidUnitPrice.Text * Qty.Text)
        Next

        CType(grdItemList.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text = FormatNumber(x, 2)

        Session("TotalBidAmount") = CType(grdItemList.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text
        TotalAmount = CType(grdItemList.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text

        dtListBidders = objDerived.GetDataTable("SELECT * FROM [dbo].[View_DSupplies_BidderList] WHERE IIRUS_ID = '" & grdSuppList.SelectedDataKey("IIRUS_ID") & "' ORDER BY TotalAmount DESC", CommandType.Text)
        grdBidders.DataSource = dtListBidders
        grdBidders.DataBind()

        If dtListBidders.Rows.Count <> 0 Then
            btnSaveSupp.Enabled = True
        Else
            btnSaveSupp.Enabled = False
        End If

        dtListBidders = Nothing
        Session("IIRUS_ID") = grdSuppList.SelectedDataKey("IIRUS_ID")

    End Sub

    Protected Sub grdSuppList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtQuot As New DataTable
        dtQuot = objDerived.GetDataTable("SELECT * FROM [dbo].[View_IIRUS_Quotation] WHERE Disposal_id = 1 OR Disposal_id = 2 ORDER BY IIRUS_ID DESC", CommandType.Text)
        grdSuppList.PageIndex = e.NewPageIndex
        grdSuppList.DataSource = dtQuot
        grdSuppList.DataBind()

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim TAmount As Decimal = CType(grdItemList.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text
        If TAmount = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Zero Amount.")
        Else

            '=== SAVE AMS.Disposal_Supplies_Hdr
            With DSupplies_Hdr
                .Quotation_Date = Date.Today.ToString("MM/dd/yyyy")
                .Disposal_ID = grdSuppList.SelectedDataKey("Disposal_id")
                .IIRUS_ID = grdSuppList.SelectedDataKey("IIRUS_ID")
                .Supplier_ID = ddSupplier2.SelectedItem.Value
                .TotalAmount = CType(grdItemList.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text 'FormatNumber(CType(Session("TotalBidAmount"), Decimal), 2)
                .isComplete = False
                .UserID = Session("@UserName")
            End With

            Dim DSupplies_Hdr_ID As Long
            Dim dtHdr As New DataTable
            dtHdr = objDerived.GetDataTable("SELECT DSupplies_Hdr_ID FROM  AMS.Disposal_Supplies_Hdr WHERE Disposal_ID = '" & grdSuppList.SelectedDataKey("Disposal_id") & "' AND IIRUS_ID = '" & grdSuppList.SelectedDataKey("IIRUS_ID") & "' AND Supplier_ID = '" & ddSupplier2.SelectedItem.Value & "'", CommandType.Text)
            If dtHdr.Rows.Count = 0 Then
                DSupplies_Hdr_ID = DSupplies_Hdr.save
            Else
                DSupplies_Hdr_ID = dtHdr.Rows(0)("DSupplies_Hdr_ID")
                DSupplies_Hdr.DSupplies_Hdr_ID = DSupplies_Hdr_ID
                DSupplies_Hdr.update()
            End If

            '=== SAVE AMS.Disposal_Supplies_Dtl
            For i As Integer = 0 To grdItemList.Rows.Count - 1
                Dim BidUnitPrice As TextBox = CType(grdItemList.Rows(i).FindControl("txtBidPrice"), TextBox)

                With DSupplies_Dtl
                    .DSupplies_Hdr_ID = DSupplies_Hdr_ID
                    .Item_ID = dtSupply.Rows(i)("Item_ID")
                    .Qty = dtSupply.Rows(i)("Qty")
                    .BidUnit_Price = FormatNumber(CType(BidUnitPrice.Text, Decimal), 2)
                End With

                Dim dtDtl As New DataTable
                dtDtl = objDerived.GetDataTable("SELECT DSupplies_Dtl_ID FROM  AMS.Disposal_Supplies_Dtl WHERE DSupplies_Hdr_ID = '" & DSupplies_Hdr_ID & "' AND Item_ID = '" & dtSupply.Rows(i)("Item_ID") & "'", CommandType.Text)
                If dtDtl.Rows.Count = 0 Then
                    DSupplies_Dtl.save()
                Else
                    DSupplies_Dtl.DSupplies_Dtl_ID = dtDtl.Rows(0)("DSupplies_Dtl_ID")
                    DSupplies_Dtl.update()
                End If

            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Bidder has been successfully saved.")
            btnSaveSupp.Enabled = True


            dtListBidders = objDerived.GetDataTable("SELECT * FROM [dbo].[View_DSupplies_BidderList] WHERE IIRUS_ID = '" & grdSuppList.SelectedDataKey("IIRUS_ID") & "' ORDER BY TotalAmount DESC", CommandType.Text)
            grdBidders.DataSource = dtListBidders
            grdBidders.DataBind()

            If dtListBidders.Rows.Count <> 0 Then
                btnSaveSupp.Enabled = True
            Else
                btnSaveSupp.Enabled = False
            End If
        End If


    End Sub

    Protected Sub btnSaveSupp_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        objDerived.GetRecords("UPDATE AMS.IIRUS_Dtl SET withQuote=1 WHERE IIRUS_ID = '" & grdSuppList.SelectedDataKey("IIRUS_ID") & "'", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Transaction has been successfully closed.")
        btnSaveSupp.Enabled = False

        LoadSupplies()
    End Sub

    Protected Sub ddSupplier2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub txtAmountBid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'txtAmountBid.Text = FormatNumber(txtAmountBid.Text)

    End Sub

    Protected Sub txtBidPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtBidPrice As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtBidPrice.NamingContainer, GridViewRow)
        txtBidPrice.Text = FormatNumber(txtBidPrice.Text, 2)

        Dim x As Decimal = 0
        For i As Integer = 0 To grdItemList.Rows.Count - 1
            Dim BidUnitPrice As TextBox = CType(grdItemList.Rows(i).FindControl("txtBidPrice"), TextBox)
            Dim Qty As Label = CType(grdItemList.Rows(i).FindControl("lblQty"), Label)

            Dim TAmount As Decimal = FormatNumber(BidUnitPrice.Text * Qty.Text, 2)
            CType(grdItemList.Rows(i).FindControl("lblTotal"), Label).Text = FormatNumber(TAmount, 2)

            x = x + (BidUnitPrice.Text * Qty.Text)
        Next

        CType(grdItemList.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text = FormatNumber(x, 2)

        Session("TotalBidAmount") = CType(grdItemList.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text
    End Sub

    Protected Sub gvPublic_bidding_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pPublicBidding = objDerived.GetDataTable("exec AMS.quotationnew", CommandType.Text)
        If pPublicBidding.Rows.Count < 5 Then
            pPublicBidding.Merge(createdatatable(4 - pPublicBidding.Rows.Count))
        End If
        gvPublic_bidding.PageIndex = e.NewPageIndex
        gvPublic_bidding.DataSource = pPublicBidding
        gvPublic_bidding.DataBind()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If RadioButtonList1.SelectedItem.Value = 1 Then
            Me.mvType.SetActiveView(Me.vwPerItems)

            pGoods = objDerived.GetDataTable("exec AMS.quotationdetail " & gvPublic_bidding.SelectedDataKey(2) & "," & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
            gvitems.DataSource = pGoods
            gvitems.DataBind()

        ElseIf RadioButtonList1.SelectedItem.Value = 2 Then
            Me.mvType.SetActiveView(Me.vwPerLot)

            pGoods = objDerived.GetDataTable("EXEC [AMS].[sp_Quotation_PerLot] " & gvPublic_bidding.SelectedDataKey(0) & "," & gvPublic_bidding.SelectedDataKey(2) & "", CommandType.Text)
            grdPerLot.DataSource = pGoods
            grdPerLot.DataBind()

        End If
    End Sub

    Protected Sub txtTotalAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtTotalAmount.Text = FormatNumber(txtTotalAmount.Text, 2)
    End Sub
End Class