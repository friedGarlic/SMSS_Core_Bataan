Imports System.Data
Imports System.IO
Partial Class filemaintenance_fm_Brgy
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

    Private Property pGvBrgy() As DataTable
        Get
            Return CType(Session("GvBrgy"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("GvBrgy") = value
        End Set
    End Property
    Private Property Brg() As DataTable
        Get
            Return CType(Session("Brg"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("Brg") = value
        End Set
    End Property
    Private Property pMun() As DataTable
        Get
            Return CType(Session("Mun"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("Mun") = value
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
        pGvBrgy = objDerived.GetDataTable("Select * from dbo.tbl_Brgy_invent Order by Brgy_name asc", CommandType.Text)
        GvBrgy.DataSource = pGvBrgy
        GvBrgy.DataBind()


        txtDate.Text = Date.Today
        pMun = objDerived.GetDataTable("Select * from dbo.tbl_Municipality Order by Municipal_name asc", CommandType.Text)
        DDMunicipal.DataSource = pMun
        DDMunicipal.DataTextField = "Municipal_Name"
        DDMunicipal.DataValueField = "Municipal_ID"
        DDMunicipal.DataBind()
    End Sub
    Protected Sub btnadd_Click(sender As Object, e As EventArgs)
        Dim MunID As Integer = DDMunicipal.SelectedItem.Value
        Dim MunName As String = DDMunicipal.SelectedItem.text
        Dim BrgyName As String = TxtBrgyName.Text
        If btnadd.Text = "Update" Then

            objDerived.GetRecords("Update dbo.tbl_Brgy_invent set Brgy_Name='" & TxtBrgyName.Text & "'  where Brgy_ID='" & GvBrgy.SelectedDataKey(0) & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            pGvBrgy = objDerived.GetDataTable("Select * from dbo.tbl_Brgy_invent Order by Brgy_name asc", CommandType.Text)
            GvBrgy.DataSource = pGvBrgy
            GvBrgy.DataBind()

            TxtBrgyName.Text = ""

            btnadd.Text = "Save"
        Else
            Me.objDerived.Execute("Insert into dbo.tbl_Brgy_invent (Brgy_Name,Municipal_id,Municipal_Name)Values('" & BrgyName & "','" & MunID & "','" & MunName & "')", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            pGvBrgy = objDerived.GetDataTable("Select * from dbo.tbl_Brgy_invent Order by Brgy_name asc", CommandType.Text)
            GvBrgy.DataSource = pGvBrgy
            GvBrgy.DataBind()

            TxtBrgyName.Text = ""

            btnadd.Text = "Save"
        End If


    End Sub
    Protected Sub btncancel_Click(sender As Object, e As EventArgs)
        TxtBrgyName.Text = ""


        btnadd.Text = "Save"
    End Sub
    Protected Sub btnsearch_Click(sender As Object, e As EventArgs)

        Dim myview As DataView
        pstock = objDerived.GetDataTable("Select * from tbl_Brgy_Invent Order by Brgy_name asc", CommandType.Text)
        myview = pstock.DefaultView

        If ddSearch.SelectedItem.Value = 1 Then
            myview.RowFilter = "Brgy_Name Like '%" & replaceapostrophe(Me.txtsearchBrgy.Text.ToString) & "%'"
        Else ddSearch.SelectedItem.Value = 2

            myview.RowFilter = "Municipal_name like '%" & replaceapostrophe(Me.txtsearchBrgy.Text.ToString) & "%'"
        End If

        GvBrgy.DataSource = myview
        GvBrgy.DataBind()
        GvBrgy.PageIndex = 0
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub GvBrgy_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim B As String = " "

        TxtBrgyName.Text = GvBrgy.SelectedDataKey(1)
        Brg = objDerived.GetDataTable("Select * from tbl_brgy_invent where brgy_id = '" & GvBrgy.SelectedDatakey(0) & "'", CommandType.Text)
        DDMunicipal.DataSource = Brg
        DDMunicipal.DataTextField = "Municipal_Name"
        DDMunicipal.DataValueField = "Municipal_ID"
        DDMunicipal.DataBind()
        DDMunicipal.enabled = False

        btnadd.Text = "Update"
    End Sub

    Protected Sub GvBrgy_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtAccount As New DataTable

        dtAccount = objDerived.GetDataTable("Select * from dbo.tbl_Brgy_invent Order by Brgy_name asc", CommandType.Text)

        GvBrgy.PageIndex = e.NewPageIndex
        GvBrgy.DataSource = dtAccount
        GvBrgy.DataBind()
    End Sub
End Class
