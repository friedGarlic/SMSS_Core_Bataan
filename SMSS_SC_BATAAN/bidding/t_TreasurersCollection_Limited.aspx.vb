Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Partial Class bidding_t_TreasurersCollection_Limited
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim TosTable As New tbl_integrated_collections_table
    Dim msg As New MsgeBox
    Private save As New Supplier
    Dim objAccess As New AccessRule


#Region "Property"
    Private pListOfBid As DataTable
    Public Property ListOfBid() As DataTable
        Get
            Return pListOfBid
        End Get
        Set(ByVal value As DataTable)
            pListOfBid = value
        End Set
    End Property
    Private pSupplier As DataTable
    Public Property Supplier() As DataTable
        Get
            Return pSupplier
        End Get
        Set(ByVal value As DataTable)
            pSupplier = value
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
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'If Session("@UserName") = "" Then
            '    Response.Redirect("~/SessionExpired.aspx")
            'End If

            'objAccess.GetAccessRight(Session("@UserName"), Page)

            'If objAccess.HasAccess = False Then
            '    Response.Redirect("~/UnauthorizedAccess.aspx")
            'End If

            Dim MOP As Integer = objDerived.GetValue("Select mode_of_procurement_id from ams.mode_of_procurement where mode_description='Limited Source'", CommandType.Text)


            pListOfBid = objDerived.GetDataTable("EXEC [AMS].[sp_BidOpening] '" & MOP & "'", CommandType.Text)
            If pListOfBid.Rows.Count < 5 Then
                pListOfBid.Merge(CreateTable1(5 - pListOfBid.Rows.Count))
            End If
            grdListOfTransaction.DataSource = pListOfBid
            grdListOfTransaction.DataBind()

            tbSelectBidder.Visible = True
            tbNewBidder.Visible = False

            grdListOfSupplier.DataSource = Nothing
            grdListOfSupplier.DataBind()

            btnsupplier.Enabled = False
            drpSupplierList.Enabled = False

        End If
    End Sub
    Protected Sub grdListOfTransaction_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim MOP As Integer = objDerived.GetValue("Select mode_of_procurement_id from ams.mode_of_procurement where mode_description='Limited Source'", CommandType.Text)


        pListOfBid = objDerived.GetDataTable("EXEC [AMS].[sp_BidOpening] '" & MOP & "'", CommandType.Text)
        If pListOfBid.Rows.Count < 5 Then
            pListOfBid.Merge(CreateTable1(5 - pListOfBid.Rows.Count))
        End If
        grdListOfTransaction.PageIndex = e.NewPageIndex
        grdListOfTransaction.DataSource = pListOfBid
        grdListOfTransaction.DataBind()

    End Sub

    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("RefNumber", GetType(String))
        dt.Columns.Add("BidLocation", GetType(String))
        dt.Columns.Add("countSupplier", GetType(Integer))
        dt.Columns.Add("TotalABC", GetType(Decimal))
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("obr_evaluation_hdr_id", GetType(Long))
        dt.Columns.Add("isPublicInfra", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("RefNumber") = DBNull.Value
            dr("BidLocation") = DBNull.Value
            dr("countSupplier") = DBNull.Value
            dr("TotalABC") = DBNull.Value
            dr("pre_procurement_hdr_id") = 0
            dr("obr_evaluation_hdr_id") = DBNull.Value
            dr("isPublicInfra") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("suppname", GetType(String))
        dt.Columns.Add("Supplier_ID", GetType(Long))
        dt.Columns.Add("Transaction_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("suppname") = ""
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function


    Protected Sub grdListOfTransaction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdListOfTransaction.SelectedIndexChanged
        Session("Transaction_ID") = grdListOfTransaction.SelectedDataKey("pre_procurement_hdr_id")

        If grdListOfTransaction.SelectedDataKey("pre_procurement_hdr_id") = 0 Then
            btnNew.Enabled = False

            lblProjectName.Text = ""
            lbllocation.Text = ""
            lblBiddocument.Text = ""

            Dim dt As New DataTable
            drpSupplierList.DataSource = dt
            drpSupplierList.DataBind()
            drpSupplierList.Items.Insert(0, "Select")

            grdListOfSupplier.DataSource = createdatatable1(2)
            grdListOfSupplier.DataBind()

        Else
            lblProjectName.Text = grdListOfTransaction.SelectedDataKey("project_name")
            lbllocation.Text = grdListOfTransaction.SelectedDataKey("BidLocation")
            lblBiddocument.Text = FormatNumber(grdListOfTransaction.SelectedDataKey("bid_docs"), 2)

            drpSupplierList.DataSource = objDerived.GetDataTable("exec [AMS].[pre_procurement_bidders]  '" & grdListOfTransaction.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
            'drpSupplierList.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.vw_SupplierCollection where Transaction_ID = '" & grdListOfTransaction.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
            drpSupplierList.DataTextField = "SuppName"
            drpSupplierList.DataValueField = "Supplier_id"
            drpSupplierList.DataBind()
            drpSupplierList.Items.Insert(0, "Select")

            drpSupplierList.Enabled = True
            btnNew.Enabled = True

            LoadBidders()
        End If

    End Sub
    Protected Sub btnsupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsupplier.Click
        Dim Supp As Integer = objDerived.GetValue("Select count(*) from dbo.vw_SupplierCollection where Supplier_ID = '" & drpSupplierList.SelectedItem.Value & "' and Transaction_ID='" & grdListOfTransaction.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        If Supp = 0 Then

            If drpSupplierList.SelectedValue = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select a supplier.")
            Else

                TosTable.Transaction_ID = grdListOfTransaction.SelectedDataKey("pre_procurement_hdr_id")
                TosTable.SystemDBase = "SMS"
                TosTable.collectionID = 0
                TosTable.GA_Code = 0

                TosTable.Supplier_ID = drpSupplierList.SelectedItem.Value

                TosTable.save()

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Supplier has been successfully added.")

                drpSupplierList.DataSource = objDerived.GetDataTable("exec [AMS].[pre_procurement_bidders]  '" & grdListOfTransaction.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
                drpSupplierList.DataTextField = "SuppName"
                drpSupplierList.DataValueField = "Supplier_id"
                drpSupplierList.DataBind()
                drpSupplierList.Items.Insert(0, "Select")

                drpSupplierList.Enabled = True

                tbSelectBidder.Visible = True
                tbNewBidder.Visible = False
            End If
        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Bidder already exist.")
        End If
        LoadBidders()
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        btnNew.Text = "ADD NEW BIDDER"
        drpSupplierList.Visible = True
        txtSuppName.Visible = False

        tbSelectBidder.Visible = True
        tbNewBidder.Visible = False
        btnCancel.Visible = False
        btnCancel.Enabled = False

        LoadBidders()

    End Sub
    ' Protected Sub LoadBidders()

    'Dim dtSupp As New DataTable
    'dtSupp = objDerived.GetDataTable("Select * from dbo.vw_SupplierCollection where Transaction_ID = '" & grdListOfTransaction.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

    'If dtSupp.Rows.Count = 0 Then
    '    grdListOfSupplier.DataSource = createdatatable1(2)
    '    grdListOfSupplier.DataBind()
    'Else
    '    If dtSupp.Rows.Count < 2 Then
    '        dtSupp.Merge(createdatatable1(2 - dtSupp.Rows.Count))
    '    End If
    '    grdListOfSupplier.DataSource = dtSupp
    '    grdListOfSupplier.DataBind()
    'End If
    Protected Sub LoadBidders()
        ' Initialize a new DataTable
        Dim dtSupp As New DataTable

        ' Construct the query with direct concatenation (note: this is not best practice for production due to SQL injection risks)
        Dim transactionId As String = grdListOfTransaction.SelectedDataKey("pre_procurement_hdr_id").ToString()
        Dim query As String = "SELECT * FROM dbo.vw_SupplierCollection WHERE Transaction_ID = '" & transactionId & "'"

        ' Retrieve data using the constructed query
        dtSupp = objDerived.GetDataTable(query, CommandType.Text)

        ' Ensure there are at least two rows for display
        If dtSupp.Rows.Count < 2 Then
            ' Merge with a DataTable with the necessary number of empty rows
            dtSupp.Merge(createdatatable1(2 - dtSupp.Rows.Count))
        End If

        ' Bind the DataTable to the GridView
        grdListOfSupplier.DataSource = dtSupp
        grdListOfSupplier.DataBind()

    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If txtTraps.Value = "Yes" Then
            Lbtn = "Remove"
        Else
            Lbtn = "Cancel"
        End If

    End Sub

    Protected Sub grdListOfSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdListOfSupplier.SelectedIndexChanged
        If Lbtn = "Remove" Then
            objDerived.GetRecords("DELETE FROM dbo.tbl_integrated_collections_table WHERE Transaction_ID= '" & Session("Transaction_ID") & "' and Supplier_ID =  '" & grdListOfSupplier.SelectedDataKey("Supplier_ID") & "'", CommandType.Text)
            LoadBidders()
        End If
    End Sub

    Protected Sub drpSupplierList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnsupplier.Enabled = True
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnNew.Text = "ADD NEW BIDDER" Then
            btnNew.Text = "SAVE NEW BIDDER"
            drpSupplierList.Visible = False
            txtSuppName.Visible = True

            tbSelectBidder.Visible = False
            tbNewBidder.Visible = True
            btnCancel.Visible = True
            btnCancel.Enabled = True

        ElseIf btnNew.Text = "SAVE NEW BIDDER" Then
            Dim Empty As String = " "

            Dim dtSupplier As New DataTable
            dtSupplier = objDerived.GetDataTable("SELECT DISTINCT SuppName FROM dbo.Supplier", CommandType.Text)

            For i As Integer = 0 To dtSupplier.Rows.Count - 1
                If txtSuppName.Text = dtSupplier.Rows(i)("SuppName") Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Bidder already exist.")
                    Exit Sub
                End If
            Next

            objDerived.GetRecords("INSERT INTO dbo.Supplier (SuppName,Address1,ContactP,Officeno) VALUES ('" & txtSuppName.Text & "', '" & txtAddress.Text & "', '" & txtCPerson.Text & "', '" & txtCNumber.Text & "')", CommandType.Text)
            Dim id As Long = objDerived.GetValue("Select MAX(Supplier_ID) FROM dbo.Supplier", CommandType.Text)

            TosTable.Transaction_ID = grdListOfTransaction.SelectedDataKey("pre_procurement_hdr_id")
            TosTable.SystemDBase = "SMS"
            TosTable.collectionID = 0
            TosTable.GA_Code = 0
            TosTable.Supplier_ID = objDerived.GetValue("Select MAX(Supplier_ID) FROM dbo.Supplier", CommandType.Text)
            TosTable.save()

            btnNew.Text = "Add New Bidder"
            drpSupplierList.Visible = True
            txtSuppName.Visible = False

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Supplier has been successfully added.")

            drpSupplierList.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
            drpSupplierList.DataTextField = "SuppName"
            drpSupplierList.DataValueField = "Supplier_id"
            drpSupplierList.DataBind()
            drpSupplierList.Items.Insert(0, "Select")

            drpSupplierList.Enabled = True

            tbSelectBidder.Visible = True
            tbNewBidder.Visible = False



            LoadBidders()

            btnCancel.Visible = False
            txtSuppName.text = ""
            txtAddress.text = ""
            txtCNumber.text = ""
            txtCPerson.text = ""
        End If

    End Sub
End Class
