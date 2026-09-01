Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class t_public_bidding
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal
    Private objCanvas As New t_public_bidding_canvas

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
    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
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
#End Region
#Region "Function"
    Public Function CreateTableGoods(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("Item_Desc")
        dt.Columns.Add("Description")
        dt.Columns.Add("total", GetType(Decimal))
        dt.Columns.Add("enable", GetType(Boolean))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_ID") = 0
            dr("Qty") = 0
            dr("Cost") = "0.00"
            dr("Item_Desc") = ""
            dr("Description") = ""
            dr("total") = "0.00"
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
        dt.Columns.Add("pr_no")
        dt.Columns.Add("project_name")
        dt.Columns.Add("project_description")
        dt.Columns.Add("isClosed", GetType(Boolean))
        dt.Columns.Add("isRebid", GetType(Boolean))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Long))
        dt.Columns.Add("Project_ID", GetType(Long))
        dt.Columns.Add("Program_id", GetType(Long))
        dt.Columns.Add("rc_name")
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("status", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = ""
            dr("project_name") = ""
            dr("project_description") = ""
            dr("isClosed") = False
            dr("isRebid") = False
            dr("RC_ID") = 0
            dr("Function_ID") = 0
            dr("Project_ID") = 0
            dr("Program_id") = 0
            dr("rc_name") = ""
            dr("isVisible") = False
            dr("status") = 0
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
        dt.Columns.Add("status")
        dt.Columns.Add("isOld", GetType(Boolean))
        dt.Columns.Add("lot", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = ""
            dr("Supplier_Id") = 0
            dr("isVisible") = False
            dr("date") = CType("01/01/1900", Date)
            dr("status") = ""
            dr("isOld") = False
            dr("lot") = "0.00"
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

                pPublicBidding = objDerived.GetDataTable("select * from ams.vw_public_bidding", CommandType.Text)

                If pPublicBidding.Rows.Count < 8 Then
                    pPublicBidding.Merge(createdatatable(7 - pPublicBidding.Rows.Count))
                End If

                gvPublic_bidding.DataSource = pPublicBidding
                gvPublic_bidding.DataBind()

             
                pSupplier = Nothing
                pTempSupplier = Nothing

                gvsupplier.DataSource = (createdatatableSuppliers(7))
                gvsupplier.DataBind()
                gvitems.DataSource = CreateTableGoods(7)
                gvitems.DataBind()
                'btnsubmit.Enabled = False
            End If
        Catch ex As Exception

        End Try
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
            If CType(txtCost.Text, Decimal) > CType(pGoods.Rows(gvr.RowIndex)("cost"), Decimal) Then
                msg.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Quantity must not exceed " & pGoods.Rows(gvr.RowIndex)("cost") & "")
                txtCost.Text = CType(data.Rows(gvr.RowIndex)("total"), Decimal) / CType(data.Rows(gvr.RowIndex)("qty"), Decimal)
                pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("cost") = txtCost.Text
                Dim txt As TextBox = CType(Me.gvitems.Rows(gvr.RowIndex).Cells(3).FindControl("txtCost"), TextBox)
                ScriptManager.GetCurrent(Me.Page).SetFocus(txt)
            Else
                CType(gvitems.Rows(gvr.RowIndex).Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(CType(CType(Me.gvitems.Rows(gvr.RowIndex).Cells(2).FindControl("lblqty"), Label).Text, Integer) * CType(txtCost.Text, Decimal), 2)
                pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("total") = CType(gvitems.Rows(gvr.RowIndex).Cells(4).FindControl("lbltotal"), Label).Text
                pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("cost") = txtCost.Text
                CType(gvitems.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                Dim txt As TextBox = CType(Me.gvitems.Rows(gvr.RowIndex + 1).Cells(3).FindControl("txtCost"), TextBox)

                ScriptManager.GetCurrent(Me.Page).SetFocus(txt)
            End If
        Catch ex As Exception

        End Try
    End Sub



 
    'Protected Sub gvPublic_bidding_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvPublic_bidding.SelectedIndexChanged

    '    ' cpeEmployeeDetail.EnableViewState = True
    '    'CollapsiblePanelExtender1.AutoExpand = True

    '    'Me.cpeEmployeeList.Collapsed = True
    '    'Me.cpeEmployeeList.ClientState = True
    '    'Me.cpeEmployeeDetail.Collapsed = False
    '    'Me.cpeEmployeeDetail.ClientState = False


    'End Sub

    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Lbtn = "pr"
    'End Sub

    Protected Sub lbApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "close"
    End Sub

    Protected Sub lblAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "add"
    End Sub

  
  
    Protected Sub gvPublic_bidding_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If Lbtn = "pr_no" Then
            Me.cpe1.Collapsed = True
            Me.cpe1.ClientState = True
            Me.cpe2.Collapsed = False
            Me.cpe2.ClientState = False
            Me.cpe3.Collapsed = False
            Me.cpe3.ClientState = False
            pSupplier = objDerived.GetDataTable("exec ams.sp_supplier_per_bid " & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)

            pTempSupplier = objDerived.GetDataTable("exec ams.sp_supplier_per_bid " & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
            If pTempSupplier.Rows.Count < 8 Then
                pTempSupplier.Merge(createdatatableSuppliers(7 - pTempSupplier.Rows.Count))
            End If


            If pSupplier.Rows.Count >= 1 Then
                For i As Integer = 0 To pSupplier.Rows.Count - 1
                    pGoodsPerSupplier(pSupplier.Rows(i)("Supplier_Id").ToString) = objDerived.GetDataTable("exec ams.sp_goods_per_bid_existing " & gvPublic_bidding.SelectedDataKey(0) & ", " & pSupplier.Rows(i)("Supplier_Id") & "", CommandType.Text)
                Next
            End If
            gvsupplier.DataSource = pTempSupplier
            gvsupplier.DataBind()
            pGoods = objDerived.GetDataTable("exec ams.sp_goods_per_bid " & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
            gvitems.DataSource = pGoods
            gvitems.DataBind()
            CType(gvitems.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoods.Compute("sum(total)", ""), 2)
            ddSupplier.Items.Clear()
            ddSupplier.Items.Add("Select")

            ddSupplier.DataSource = objDerived.GetRecords("exec ams.sp_supplier_per_bid_default " & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
            ddSupplier.DataTextField = "SuppName"
            ddSupplier.DataValueField = "Supplier_Id"
            ddSupplier.DataBind()
            ddSupplier.Enabled = True
            btnsupplier.Enabled = False
            btnsubmit.Enabled = False
        ElseIf Lbtn = "close" Then
            objDerived.GetRecords("Update ams.bidding_hdr set isClosed=1 where bidding_hdr_id=" & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
            pPublicBidding = objDerived.GetDataTable("select * from ams.vw_public_bidding", CommandType.Text)
            If pPublicBidding.Rows.Count < 8 Then
                pPublicBidding.Merge(createdatatable(7 - pPublicBidding.Rows.Count))
            End If
            gvPublic_bidding.DataSource = pPublicBidding
            gvPublic_bidding.DataBind()
            gvPublic_bidding.SelectedIndex = -1
            Me.cpe1.Collapsed = False
            Me.cpe1.ClientState = False
            Me.cpe2.Collapsed = True
            Me.cpe2.ClientState = True
            Me.cpe3.Collapsed = True
            Me.cpe3.ClientState = True
            ddSupplier.Items.Clear()
            ddSupplier.Enabled = False
            btnsupplier.Enabled = False
            pSupplier = Nothing
            pTempSupplier = Nothing
            gvsupplier.DataSource = (createdatatableSuppliers(7))
            gvsupplier.DataBind()
            pGoods = Nothing
            gvitems.DataSource = CreateTableGoods(7)
            gvitems.DataBind()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Transaction has been succesfully closed.")
        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "pr_no"
    End Sub

    Protected Sub lbApprove_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "close"
    End Sub

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            If gvsupplier.SelectedDataKey(1) = False Then
                For i As Integer = 0 To pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows.Count - 1
                    objCanvas.bidding_hdr_id = gvPublic_bidding.SelectedDataKey(0)
                    objCanvas.Supplier_Id = gvsupplier.SelectedDataKey(0)
                    objCanvas.Item_ID = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(i)("Item_ID")
                    objCanvas.Qty = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(i)("Qty")
                    objCanvas.Cost = CType(Me.gvitems.Rows(i).Cells(3).FindControl("txtCost"), TextBox).Text
                    objCanvas.datecanvas = Date.Today.ToString("MM/dd/yyyy")
                    objCanvas.Compliance = True
                    objCanvas.isWinner = False
                    objCanvas.save()
                Next

            Else
                For i As Integer = 0 To pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows.Count - 1
                    objDerived.GetRecords("Update ams.canvas set cost=" & CType(Me.gvitems.Rows(i).Cells(3).FindControl("txtCost"), TextBox).Text & " where item_id=" & pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(i)("Item_ID") & " and Supplier_Id=" & gvsupplier.SelectedDataKey(0) & " and bidding_hdr_id=" & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
                Next
            End If
            pPublicBidding = objDerived.GetDataTable("select * from ams.vw_public_bidding", CommandType.Text)

            If pPublicBidding.Rows.Count < 8 Then
                pPublicBidding.Merge(createdatatable(7 - pPublicBidding.Rows.Count))
            End If

            gvPublic_bidding.DataSource = pPublicBidding
            gvPublic_bidding.DataBind()
            ' btnsubmit.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Transaction has been succesfully saved.")
        Catch ex As Exception

        End Try
    End Sub




    Protected Sub btnsupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            btnsubmit.Enabled = True

            Dim dt As New DataTable()
            Dim dr As DataRow
            Dim myDataColumn As DataColumn
            myDataColumn = New DataColumn()
            dt.Columns.Add("SuppName")
            dt.Columns.Add("Supplier_Id", GetType(Long))
            dt.Columns.Add("isVisible", GetType(Boolean))
            dt.Columns.Add("date", GetType(Date))
            dt.Columns.Add("status")
            dt.Columns.Add("isOld", GetType(Boolean))
            dt.Columns.Add("lot", GetType(Decimal))

            dr = dt.NewRow
            dr("SuppName") = ddSupplier.SelectedItem.Text
            dr("Supplier_Id") = ddSupplier.SelectedItem.Value
            dr("isVisible") = True
            dr("date") = Date.Today.ToString("MM/dd/yyyy")
            dr("status") = ""
            dr("isOld") = False
            dr("lot") = "0.00"
            dt.Rows.Add(dr)
            pSupplier.Merge(dt)
            pTempSupplier = Nothing
            pTempSupplier = pSupplier
            If pTempSupplier.Rows.Count < 8 Then
                pTempSupplier.Merge(createdatatableSuppliers(7 - pTempSupplier.Rows.Count))
            End If
            gvsupplier.DataSource = pTempSupplier
            gvsupplier.DataBind()
            ddSupplier.Enabled = False
            btnsupplier.Enabled = False
            pGoodsPerSupplier(ddSupplier.SelectedItem.Value.ToString) = objDerived.GetDataTable("exec ams.sp_goods_per_bid " & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
            Dim data As New DataTable
            data = pGoodsPerSupplier(ddSupplier.SelectedItem.Value.ToString)
            Dim a As String = ddSupplier.SelectedItem.Value.ToString
            ddSupplier.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvsupplier_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvsupplier.PageIndexChanging
        Me.gvsupplier.PageIndex = e.NewPageIndex
        Me.gvsupplier.DataSource = CType(pSupplier, DataTable)
        Me.gvsupplier.DataBind()
    End Sub
    Protected Sub gvsupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvsupplier.SelectedIndexChanged
        'btnsubmit.Enabled = True
        btnsubmit.Enabled = True
        If Lbtn = "supplier" Then
            Dim data As New DataTable
            data = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString)

            gvitems.DataSource = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString)
            gvitems.DataBind()
            CType(gvitems.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
            For i As Integer = 0 To pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows.Count - 1
                Dim txtcost As TextBox = CType(gvitems.Rows(i).FindControl("txtcost"), TextBox)
                txtcost.Enabled = True
                txtcost.Attributes.Add("onclick", "this.select()")
                txtcost.Attributes.Add("onFocus", "this.select()")

            Next


            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(Me.gvitems.Rows(0).Cells(3).FindControl("txtcost"), TextBox))
        End If


    End Sub

   

    Protected Sub lbSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "supplier"
    End Sub

    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSupplier.SelectedIndex = 0 Then
            btnsupplier.Enabled = False
        Else
            btnsupplier.Enabled = True
            gvitems.DataSource = pGoods
            gvitems.DataBind()
            gvsupplier.SelectedIndex = -1

        End If


    End Sub

   


End Class
