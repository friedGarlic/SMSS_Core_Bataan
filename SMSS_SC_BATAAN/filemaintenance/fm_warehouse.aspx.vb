Imports System.Data
Imports System.IO
Partial Class filemaintenance_fm_warehouse
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl
    Private pr_obr As New PR_OBR
    Private obr_hdr As New t_purchase_request_obr_hdr
    Private obr_dtl As New t_purchase_request_obr_dtl
    Private obr_Adjsutment_hdr As New t_purchase_request_obr_adjustment_hdr
    Private obr_Adjsutment_dtl As New t_purchase_request_obr_adjustment_dtl
    Private disbursement As New t_Purchase_request_disbursement

    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim image As New Image
    Dim ImageDocument As New ImageDocument
    Dim dtRep As New DataTable

    Dim objRep_Dtl As New t_RepairAndMaintenance.TbRepair_Dtl
    Private getprofile As New ProfileCommon

#Region "property"

    Private Property pGvWarehouse() As DataTable
        Get
            Return CType(Session("GvWarehouse"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("GvWarehouse") = value
        End Set
    End Property
    Private Property pstock() As DataTable
        Get
            Return CType(Session("pstock"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pstock") = value
        End Set
    End Property
#End Region
#Region "function"

#End Region


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Load_GvWarehouse()
        End If

        txtDate.Text = Date.Today

    End Sub
    Protected Sub btnadd_Click(sender As Object, e As EventArgs)
        If btnadd.Text = "Update" Then
            objDerived.GetRecords(
                "UPDATE AMS.Loc_Warehouse " &
                "SET wName = '" & replaceapostrophe(TxtWareHouse.Text) & "', " &
                "    wCode = '" & replaceapostrophe(TxtCode.Text) & "', " &
                "    wAddress = '" & replaceapostrophe(TxtAddress.Text) & "' " &
                "WHERE Warehouse_ID = " & GvWarehouse.SelectedDataKey(0),
                CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            Load_GvWarehouse()

            TxtWareHouse.Text = ""
            TxtAddress.Text = ""
            TxtCode.Text = ""
            btnadd.Text = "Save"
        Else
            Me.objDerived.Execute(
                "INSERT INTO AMS.Loc_Warehouse (wName, wCode, wAddress, isUsed) " &
                "VALUES ('" & replaceapostrophe(TxtWareHouse.Text) & "', " &
                "'" & replaceapostrophe(TxtCode.Text) & "', " &
                "'" & replaceapostrophe(TxtAddress.Text) & "', 1)",
                CommandType.Text)


            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            Load_GvWarehouse()

            TxtWareHouse.Text = ""
            TxtAddress.Text = ""
            TxtCode.Text = ""
            btnadd.Text = "Save"
        End If


    End Sub
    Protected Sub btncancel_Click(sender As Object, e As EventArgs)
        TxtWareHouse.Text = ""
        TxtAddress.Text = ""
        TxtCode.Text = ""
        btnadd.Text = "Save"

    End Sub
    Public Sub Load_GvWarehouse()

        If GvWarehouse.DataSource = "" Then
            pGvWarehouse = objDerived.GetDataTable("Select * from AMS.Loc_Warehouse order by wName", CommandType.Text)
            GvWarehouse.DataSource = pGvWarehouse
            GvWarehouse.DataBind()

        Else
            txtDate.Text = Date.Today
        End If
    End Sub
    Protected Sub btnsearch_Click(sender As Object, e As EventArgs)
        Dim dt As DataTable = objDerived.GetDataTable("Select * from AMS.Loc_Warehouse", CommandType.Text)
        Dim myview As DataView = dt.DefaultView
        myview.RowFilter = "wName Like '%" & replaceapostrophe(Me.txtsearchWarehouse.Text.ToString) & "%'"

        'store filtered results for paging
        pGvWarehouse = myview.ToTable()

        GvWarehouse.PageIndex = 0
        GvWarehouse.DataSource = pGvWarehouse
        GvWarehouse.DataBind()
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub GvWarehouse_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim B As String = " "
        If IsDBNull(GvWarehouse.SelectedDataKey("wCode")) Then
            B = " "
        Else
            B = GvWarehouse.SelectedDataKey("wCode")

        End If

        Dim A As String = " "
        If IsDBNull(GvWarehouse.SelectedDataKey("wAddress")) Then
            A = " "
        Else
            A = GvWarehouse.SelectedDataKey("wAddress")

        End If
        TxtWareHouse.Text = GvWarehouse.SelectedDataKey("wName")
        TxtCode.Text = B
        TxtAddress.Text = A

        btnadd.Text = "Update"
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)


        Dim chk As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(chk.NamingContainer, GridViewRow)

        Dim newIsUsed As Integer = If(chk.Checked, 0, 1) 'checked means visible => isUsed=0
        objDerived.GetRecords(
            "UPDATE AMS.Loc_Warehouse SET isUsed = " & newIsUsed &
            " WHERE Warehouse_ID = " & Me.GvWarehouse.DataKeys(gvr.RowIndex).Item(0),
            CommandType.Text)

        If chk.Checked Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected items has been successfully hidden.")
        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected items has been successfully set as visible.")
        End If

    End Sub


    Protected Sub GvWarehouse_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GvWarehouse.PageIndex = e.NewPageIndex

        'Rebind data (use your session table if available)
        If pGvWarehouse IsNot Nothing Then
            GvWarehouse.DataSource = pGvWarehouse
            GvWarehouse.DataBind()
        Else
            Load_GvWarehouse()
        End If
    End Sub


End Class
