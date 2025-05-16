Imports System.Data
Imports System.IO
Partial Class filemaintenance_fm_Mun
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

    Private Property pGvMunicipal() As DataTable
        Get
            Return CType(Session("GvMunicipal"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("GvMunicipal") = value
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
        pGvMunicipal = objDerived.GetDataTable("Select * from dbo.tbl_municipality Order by Municipal_name asc", CommandType.Text)
        GvMunicipal.DataSource = pGvMunicipal
        GvMunicipal.DataBind()


        txtDate.Text = Date.Today

    End Sub
    Protected Sub btnadd_Click(sender As Object, e As EventArgs)
        If btnadd.Text = "Update" Then
            objDerived.GetRecords("Update dbo.tbl_Municipality set Municipal_Name='" & TxtMunicipalName.Text & "'  where Municipal_ID='" & GvMunicipal.SelectedDataKey("Municipal_ID") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            pGvMunicipal = objDerived.GetDataTable("Select * from dbo.tbl_municipality Order by Municipal_name asc", CommandType.Text)
            GvMunicipal.DataSource = pGvMunicipal
            GvMunicipal.DataBind()

            TxtMunicipalName.Text = ""

            btnadd.Text = "Save"
        Else
            Me.objDerived.Execute("Insert into dbo.tbl_Municipality (Municipal_Name)Values('" & TxtMunicipalName.Text & "')", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


            pGvMunicipal = objDerived.GetDataTable("Select * from dbo.tbl_municipality Order by Municipal_name asc", CommandType.Text)
            GvMunicipal.DataSource = pGvMunicipal
            GvMunicipal.DataBind()

            TxtMunicipalName.Text = ""

            btnadd.Text = "Save"
        End If


    End Sub
    Protected Sub btncancel_Click(sender As Object, e As EventArgs)
        TxtMunicipalName.Text = ""
        TxtAddress.Text = ""
        TxtCode.Text = ""

        btnadd.Text = "Save"
    End Sub
    Protected Sub btnsearch_Click(sender As Object, e As EventArgs)

        Dim myview As DataView
        pstock = objDerived.GetDataTable("Select * from tbl_Municipality Order by Municipal_name asc", CommandType.Text)
        myview = pstock.DefaultView

        If ddSearch.SelectedItem.Value = 1 Then
            myview.RowFilter = "Municipal_Name Like '%" & replaceapostrophe(Me.txtsearchMunicipal.Text.ToString) & "%'"
        Else ddSearch.SelectedItem.Value = 2

            myview.RowFilter = "Municipal_Name like '%" & replaceapostrophe(Me.txtsearchMunicipal.Text.ToString) & "%'"
        End If

        GvMunicipal.DataSource = myview
        GvMunicipal.DataBind()
        GvMunicipal.PageIndex = 0
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub GvMunicipal_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim B As String = " "

        TxtMunicipalName.Text = GvMunicipal.SelectedDataKey(1)


        btnadd.Text = "Update"
    End Sub
    Protected Sub GvMunicipal_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtAccount As New DataTable

        dtAccount = objDerived.GetDataTable("Select * from dbo.tbl_municipality Order by Municipal_name asc", CommandType.Text)

        GvMunicipal.PageIndex = e.NewPageIndex
        GvMunicipal.DataSource = dtAccount
        GvMunicipal.DataBind()
    End Sub
End Class
