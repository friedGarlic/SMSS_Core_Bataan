Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data

Partial Class filemaintenance_frm_TreasurersCollection
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim TosTable As New tbl_integrated_collections_table
    Dim msg As New MsgeBox
    Private save As New Supplier
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
            Dim objAccess As New AccessRule
            If Session("@UserName") = "" Then
                Response.Redirect("~/SessionExpired.aspx")
            End If
            objAccess.GetAccessRight(Session("@UserName"), Page)
            If objAccess.HasAccess = False Then
                Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            pListOfBid = objDerived.GetDataTable("EXEC [AMS].[sp_BidOpening]", CommandType.Text)
            If pListOfBid.Rows.Count < 5 Then
                pListOfBid.Merge(CreateTable1(5 - pListOfBid.Rows.Count))
            End If
            grdListOfTransaction.DataSource = pListOfBid
            grdListOfTransaction.DataBind()

            grdListOfSupplier.DataSource = Nothing
            grdListOfSupplier.DataBind()

            btnsupplier.Enabled = False
            drpSupplierList.Enabled = False

        End If

    End Sub

    Protected Sub grdListOfTransaction_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pListOfBid = objDerived.GetDataTable("EXEC [AMS].[sp_BidOpening]", CommandType.Text)
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
          
        Else
            lblProjectName.Text = grdListOfTransaction.SelectedDataKey("project_name")
            lbllocation.Text = grdListOfTransaction.SelectedDataKey("BidLocation")
            lblBiddocument.Text = grdListOfTransaction.SelectedDataKey("bid_docs")

            drpSupplierList.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
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

            drpSupplierList.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
            drpSupplierList.DataTextField = "SuppName"
            drpSupplierList.DataValueField = "Supplier_id"
            drpSupplierList.DataBind()
            drpSupplierList.Items.Insert(0, "Select")

            drpSupplierList.Enabled = True
        End If

        LoadBidders()
    End Sub

    Protected Sub LoadBidders()

        Dim dtSupp As New DataTable
        dtSupp = objDerived.GetDataTable("Select * from dbo.vw_SupplierCollection where Transaction_ID = '" & grdListOfTransaction.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        If dtSupp.Rows.Count = 0 Then
            grdListOfSupplier.DataSource = createdatatable1(2)
            grdListOfSupplier.DataBind()
        Else
            If dtSupp.Rows.Count < 2 Then
                dtSupp.Merge(createdatatable1(2 - dtSupp.Rows.Count))
            End If
            grdListOfSupplier.DataSource = dtSupp
            grdListOfSupplier.DataBind()
        End If
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "Remove"
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
        If btnNew.Text = "Add New Bidder" Then
            btnNew.Text = "SAVE"
            drpSupplierList.Visible = False
            txtSuppName.Visible = True

        ElseIf btnNew.Text = "SAVE" Then
            Dim Empty As String = " "
            objDerived.GetRecords("INSERT INTO dbo.Supplier (SuppName,Address1,ContactP,Officeno) VALUES ('" & txtSuppName.Text & "', '" & Empty & "', '" & Empty & "', '" & Empty & "')", CommandType.Text)
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

            LoadBidders()

        End If
     
    End Sub
End Class
