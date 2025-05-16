Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_t_Agency2Agency
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Private hdr As New t_canvass_hdr
    Private dtl As New t_canvass_dtl
    Dim hdr2 As New t_obr_evaluation_hdr
    Dim dtl2 As New t_obr_evaluation_dtl
    Dim pohdr As New t_purchase_order_hdr
    Dim podtl As New t_purchase_order_dtl

    Private cnvss_hdr As New Consolidated_Canvass.m_Canvass_Hdr
    Private cnvss_dtl1 As New Consolidated_Canvass.m_Canvass_Dtl1
    Private cnvss_dtl2 As New Consolidated_Canvass.m_Canvass_Dtl2
    Private cnvss_PR1 As New Consolidated_Canvass.m_Canvass_Dtl_PR1
    Private cnvss_PR2 As New Consolidated_Canvass.m_Canvass_Dtl_PR2


#Region "property"
    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
        End Set
    End Property
    Private Property pProjectReference() As DataTable
        Get
            Return CType(Session("pProjectReference"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pProjectReference") = value
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
    Private Property pGoodsPerSupplier(ByVal supplier_id As String) As DataTable
        Get
            Return CType(Session(supplier_id), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session(supplier_id) = value
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
    Private Property pTempSupplier() As DataTable
        Get
            Return CType(Session("pTempSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pTempSupplier") = value
        End Set
    End Property
    Private Property pPurchase_Order_detail() As DataTable
        Get
            Return CType(Session("pPurchase_Order_detail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order_detail") = value
        End Set
    End Property
    Private Property pShopping() As DataTable
        Get
            Return CType(Session("pShopping"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pShopping") = value
        End Set
    End Property
#End Region
#Region "Functions"

    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("Function_Desc", GetType(String))
        dt.Columns.Add("DateApproved", GetType(Date))
        dt.Columns.Add("prhdr_id", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("Function_Desc") = DBNull.Value
            dr("DateApproved") = DBNull.Value
            dr("prhdr_id") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassList_Agency]", CommandType.Text)
            If pShopping.Rows.Count < 8 Then
                pShopping.Merge(createdatatable1(7 - pShopping.Rows.Count))
            End If
            grdAgency.DataSource = pShopping
            grdAgency.DataBind()

            grdAItems.DataSource = Nothing
            grdAItems.DataBind()

            Session("page") = "Agency"
        End If
    End Sub

    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnviewAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub grdDirectContract_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        dtItems = objDerived.GetDataTable("SELECT * FROM [dbo].[View_DC_ItemList] WHERE prhdr_id = '" & grdAgency.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        grdAItems.DataSource = dtItems
        grdAItems.DataBind()

        Dim cb As CheckBox
        For i As Long = 0 To Me.grdAItems.Rows.Count - 1
            cb = CType(Me.grdAItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            cb.Checked = True
        Next

        LoadtxtCostItems()

        ddSupplier.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
        ddSupplier.DataTextField = ("SuppName")
        ddSupplier.DataValueField = ("Supplier_Id")
        ddSupplier.DataBind()
        ddSupplier.Items.Insert(0, "Select")

        ddSupplier.Enabled = True

    End Sub

    Protected Sub txtCost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtCost As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtCost.NamingContainer, GridViewRow)
        If txtCost.Text = "" Then
            txtCost.Text = 0
        End If
        txtCost.Text = FormatNumber(txtCost.Text, 2)

        LoadtxtCostItems()
    End Sub

    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnsupplier.Enabled = True
    End Sub

    Protected Sub btnsupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox

        '=-= SAVE HEADER "AMS.m_Canvass_Hdr"
        With cnvss_hdr
            .Hdr_ID = 0
            .Canvass_Date = txtDate.Text
            .PR_Hdr_ID = grdAgency.SelectedDataKey("prhdr_id")
            .withWinner = True
            .isDBM = False
        End With

        Dim Hdr_ID As Long
        Hdr_ID = objDerived.GetValue("SELECT Hdr_ID FROM AMS.m_Canvass_Hdr WHERE PR_Hdr_ID = '" & grdAgency.SelectedDataKey("prhdr_id") & "' AND isDBM = 0", CommandType.Text)

        If Hdr_ID = 0 Then
            Session("Hdr_ID") = cnvss_hdr.save()
        Else
            Session("Hdr_ID") = Hdr_ID
        End If

        objDerived.Execute("UPDATE AMS.m_Canvass_Hdr SET isApproved = 1, DateApproved = '" & txtDate.Text & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)


        '=-= SAVE DETAIL "AMS.m_Canvass_Dtl_PR1" 
        With cnvss_PR1
            .Dtl_ID_PR1 = 0
            .Hdr_ID = Session("Hdr_ID")
            .Supplier_ID = ddSupplier.SelectedItem.Value
            .isWinner = True
        End With

        Dim Dtl_ID_PR1 As Long = cnvss_PR1.save()
        Session("Dtl_ID_PR1") = Dtl_ID_PR1
        objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl_PR1 SET withPO = 0 WHERE Dtl_ID_PR1 = '" & Session("Dtl_ID_PR1") & "'", CommandType.Text)

        '=-= SAVE DETAIL "AMS.m_Canvass_Dtl_PR2" 
        For i As Integer = 0 To grdAItems.Rows.Count - 1
            cb = CType(Me.grdAItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If cb.Checked = True Then
                Dim CanvassPrice As Decimal = CType(CType(grdAItems.Rows(i).FindControl("txtCost"), TextBox).Text, Decimal)
                Dim CanvassQty As Integer = CType(CType(grdAItems.Rows(i).FindControl("lblqty"), Label).Text, Integer)

                With cnvss_PR2
                    .Dtl_ID_PR2 = 0
                    .Dtl_ID_PR1 = Session("Dtl_ID_PR1")
                    .Item_ID = dtItems.Rows(i)("Item_ID")
                    .UnitPrice = CanvassPrice
                    .Quantity = CanvassQty
                    .save()
                End With
            End If
        Next

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been successfully saved.")

        txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

        pShopping = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassList_Direct]", CommandType.Text)
        If pShopping.Rows.Count < 8 Then
            pShopping.Merge(createdatatable1(7 - pShopping.Rows.Count))
        End If
        grdAgency.DataSource = pShopping
        grdAgency.DataBind()

        grdAItems.DataSource = Nothing
        grdAItems.DataBind()
    End Sub

    Protected Sub cbALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadtxtCostItems()
    End Sub
    Protected Sub LoadtxtCostItems()
        Dim x As Decimal
        Dim cb As CheckBox

        For i As Integer = 0 To grdAItems.Rows.Count - 1
            cb = CType(Me.grdAItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If cb.Checked = True Then
                Dim txtCost As TextBox = CType(grdAItems.Rows(i).FindControl("txtcost"), TextBox)
                Dim lblqty As Label = CType(grdAItems.Rows(i).FindControl("lblqty"), Label)

                Dim Tcost As Decimal = FormatNumber(txtCost.Text * lblqty.Text, 2)

                CType(grdAItems.Rows(i).FindControl("lbltotalx"), Label).Text = FormatNumber(Tcost, 2)
                x = x + (txtCost.Text * lblqty.Text)
            Else
                CType(grdAItems.Rows(i).FindControl("lbltotalx"), Label).Text = "0.00"
            End If
        Next

        CType(grdAItems.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(x, 2)

    End Sub
End Class
