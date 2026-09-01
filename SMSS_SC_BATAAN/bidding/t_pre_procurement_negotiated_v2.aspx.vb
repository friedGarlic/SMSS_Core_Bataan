Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_t_pre_procurement_negotiated_v2
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Private hdr As New t_canvass_hdr
    Private dtl As New t_canvass_dtl
    Dim pohdr As New t_purchase_order_hdr
    Dim podtl As New t_purchase_order_dtl
    Dim phdr As New t_pre_procurement_hdr
    Dim pdtl As New t_pre_procurement_dtl

#Region "property"

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
    Private Property pGoodsPerSupplier2() As DataTable
        Get
            Return CType(Session("supplier_id"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("supplier_id") = value
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

    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("rc_name")
        dt.Columns.Add("Function_Desc")
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("pr_no")
        dt.Columns.Add("PR_Date", GetType(Date))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Long))
        dt.Columns.Add("OBR_No")
        dt.Columns.Add("isReimbursement", GetType(Boolean))
        dt.Columns.Add("isDC", GetType(Boolean))
        dt.Columns.Add("isPublicInfra", GetType(Boolean))
        dt.Columns.Add("isStraight", GetType(Boolean))
        dt.Columns.Add("FundClassno", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("rc_name") = ""
            dr("Function_Desc") = ""
            dr("isVisible") = False
            dr("prhdr_id") = 0
            dr("pr_no") = ""
            dr("PR_Date") = CType("01/01/1900", Date)
            dr("ABC") = "0.00"
            dr("RC_ID") = 0
            dr("Function_ID") = 0
            dr("OBR_No") = ""
            dr("isReimbursement") = False
            dr("isDC") = False
            dr("isPublicInfra") = False
            dr("isStraight") = False
            dr("FundClassno") = 0
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
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("status")
        dt.Columns.Add("isOld", GetType(Boolean))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = ""
            dr("Supplier_Id") = 0
            dr("isVisible") = False
            dr("amount") = "0.00"
            dr("status") = ""
            dr("isOld") = False

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
            pShopping = objDerived.GetDataTable("select * from ams.vw_pre_procurement_negotiated_goods order by pr_no", CommandType.Text)
            If pShopping.Rows.Count < 8 Then
                pShopping.Merge(createdatatable(8 - pShopping.Rows.Count))
            End If
            gvIncomingPR.DataSource = pShopping
            gvIncomingPR.DataBind()

            btnPreview.Enabled = False
            btnsave.Enabled = False
            gvsupplier.DataSource = createdatatable1(2)
            gvsupplier.DataBind()
            gvbody.DataSource = createdatatable2(4)
            gvbody.DataBind()
            Me.Session("page") = "canvass"

            btnPreview.Enabled = False

        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub gvIncomingPR_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvIncomingPR.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvIncomingPR, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub gvIncomingPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            btnPreview.Enabled = False
            Session("prhdr_id") = gvIncomingPR.SelectedDataKey("prhdr_id")

            call_laod_supplier_per_project()
        Catch ex As Exception

        End Try
    End Sub


    Public Sub call_laod_supplier_per_project()
        pPurchase_Order_detail = objDerived.GetDataTable("exec ams.sp_canvass_form_detail_vb " & gvIncomingPR.SelectedDataKey(0) & "", CommandType.Text)
        If pPurchase_Order_detail.Rows.Count < 5 Then
            pPurchase_Order_detail.Merge(createdatatable2(4 - pPurchase_Order_detail.Rows.Count))
        End If
        gvbody.DataSource = pPurchase_Order_detail
        gvbody.DataBind()

        'For i As Integer = 0 To gvbody.Rows.Count - 1
        '    Dim txtcost As TextBox = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox)
        '    Dim txtqty As TextBox = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox)
        '    'Dim lbl As Label = CType(gvbody.Rows(i).FindControl("lbltotal"), Label)

        '    'CType(gvbody.Rows(i).FindControl("lbltotal"), Label).Text = txtqty.Text * txtcost.Text

        '    Dim lbl As Decimal = CType(gvbody.Rows(i).FindControl("lbltotal"), Label).Text
        '    lbl = txtqty.Text * txtcost.Text
        '    CType(gvbody.Rows(i).FindControl("lbltotal"), Label).Text = CType(lbl, Decimal)
        'Next

        Panel2.GroupingText = "Goods ABC(" + FormatNumber(gvIncomingPR.SelectedDataKey(2), 2) + ")"
        'txtABC.Text = FormatNumber(pProjectReference.Rows(ddProjectReference.SelectedIndex)("ABC"), 2)
        Session("pre_procurement_hdr_id") = gvIncomingPR.SelectedDataKey(0)
        pTempSupplier = Nothing
        pSupplier = objDerived.GetDataTable("exec ams.sp_supplier_per_canvass " & gvIncomingPR.SelectedDataKey(0) & "," & True & "", CommandType.Text)
        pTempSupplier = objDerived.GetDataTable("exec ams.sp_supplier_per_canvass " & gvIncomingPR.SelectedDataKey(0) & "," & True & "", CommandType.Text)
        If pTempSupplier.Rows.Count < 8 Then
            pTempSupplier.Merge(createdatatableSuppliers(7 - pTempSupplier.Rows.Count))
        End If

        If pSupplier.Rows.Count >= 1 Then
            For i As Integer = 0 To pSupplier.Rows.Count - 1
                Dim a As Integer = gvIncomingPR.SelectedDataKey(0)
                Dim b As Integer = pSupplier.Rows(i)("Supplier_Id")
                Dim data As DataTable = objDerived.GetDataTable("exec ams.sp_canvass_form_detail_vb_existing " & gvIncomingPR.SelectedDataKey(0) & ", " & pSupplier.Rows(i)("Supplier_Id") & "," & True & "", CommandType.Text)
                pGoodsPerSupplier(pSupplier.Rows(i)("Supplier_Id").ToString) = objDerived.GetDataTable("exec ams.sp_canvass_form_detail_vb_existing " & gvIncomingPR.SelectedDataKey(0) & ", " & pSupplier.Rows(i)("Supplier_Id") & "," & True & "", CommandType.Text)
            Next
        End If

        gvsupplier.DataSource = pTempSupplier
        gvsupplier.DataBind()
        gvsupplier.SelectedIndex = -1
        ddSupplier.DataSource = objDerived.GetRecords("exec ams.sp_supplier_per_canvass_default " & gvIncomingPR.SelectedDataKey(0) & "", CommandType.Text)
        ddSupplier.DataTextField = "SuppName"
        ddSupplier.DataValueField = "Supplier_Id"
        ddSupplier.DataBind()
        If gvIncomingPR.SelectedDataKey(3) = True Then
            ddSupplier.Enabled = False
            btnsupplier.Enabled = False
            btnsave.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "The selected purchase request has a winner.")

        ElseIf gvIncomingPR.SelectedDataKey(4) = True Then
            ddSupplier.Enabled = True
            btnsupplier.Enabled = True
            btnsave.Enabled = False
        Else

            ddSupplier.Enabled = True
            btnsupplier.Enabled = True
            btnsave.Enabled = False
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Session("page") = "negotiated"
            Me.Page.Response.Redirect("~/bidding/rpt_canvass_persupplier.aspx")
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub lbSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "supplier"
    End Sub

    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If ddSupplier.SelectedIndex = 0 Then
        '    btnsupplier.Enabled = False
        'Else
        '    btnsupplier.Enabled = True

        'End If
    End Sub

    Protected Sub btnsupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim dt As New DataTable()
            Dim dr As DataRow
            Dim myDataColumn As DataColumn
            myDataColumn = New DataColumn()
            dt.Columns.Add("SuppName")
            dt.Columns.Add("Supplier_Id", GetType(Long))
            dt.Columns.Add("isVisible", GetType(Boolean))
            dt.Columns.Add("amount", GetType(Decimal))
            dt.Columns.Add("status")
            dt.Columns.Add("isOld", GetType(Boolean))
            dt.Columns.Add("canvass_hdr_id", GetType(Long))

            dr = dt.NewRow
            dr("SuppName") = ddSupplier.SelectedItem.Text
            dr("Supplier_Id") = ddSupplier.SelectedItem.Value
            dr("isVisible") = True
            dr("amount") = CType("0.00", Decimal)
            dr("status") = ""
            dr("isOld") = False
            dr("canvass_hdr_id") = 0
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

            pGoodsPerSupplier(ddSupplier.SelectedItem.Value.ToString) = objDerived.GetDataTable("exec ams.sp_canvass_form_detail_vb " & gvIncomingPR.SelectedDataKey(0) & "", CommandType.Text)
            btnsave.Enabled = True

            Dim row As Integer = pTempSupplier.Compute("count(Supplier_Id)", "Supplier_Id<>0")
            gvsupplier.SelectedIndex = row - 1
            CType(Me.gvsupplier.Rows(gvsupplier.SelectedIndex).Cells(1).FindControl("txtCost"), TextBox).Attributes.Add("onclick", "this.select()")
            CType(Me.gvsupplier.Rows(gvsupplier.SelectedIndex).Cells(1).FindControl("txtCost"), TextBox).Attributes.Add("onFocus", "this.select()")

            ''-----------load data per supplier
            '.merge(createdatatable2(4))
            pGoodsPerSupplier2 = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString)
            pGoodsPerSupplier2.Merge(createdatatable2(4))
            gvbody.DataSource = pGoodsPerSupplier2
            gvbody.DataBind()
            For i As Integer = 0 To pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows.Count - 1
                Dim txtcost As TextBox = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox)
                Dim txtqty As TextBox = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox)
                txtcost.Enabled = True
                txtcost.Attributes.Add("onclick", "this.select()")
                txtcost.Attributes.Add("onFocus", "this.select()")
                txtqty.Enabled = True
                txtqty.Attributes.Add("onclick", "this.select()")
                txtqty.Attributes.Add("onFocus", "this.select()")

                Dim total As Decimal = CType(txtqty.Text, Decimal) * CType(txtcost.Text, Decimal)
                CType(gvbody.Rows(i).FindControl("lbltotal"), Label).Text = total

                Dim gvr As GridViewRow = TryCast(txtcost.NamingContainer, GridViewRow)
                pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("cost") = CType(txtcost.Text, Decimal)
                pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("total") = CType(txtcost.Text * pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("qty"), Decimal)
                CType(Me.gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("total"), 2)

                CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)

            Next

            'CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
            'CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(gvbody.Columns(4)).Compute("sum(total)", ""), 2)

            ''end load
            ''set to 1st txtbox for amount
            btnsave.Enabled = False
            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(Me.gvbody.Rows(0).FindControl("txtcost"), TextBox))

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvsupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Supplier_ID") = gvsupplier.SelectedDataKey("Supplier_Id")

        Try
            btnPreview.Enabled = True
            If Lbtn = "supplier" Then
                Dim data As New DataTable
                data = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString)

                gvbody.DataSource = data 'pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString)
                gvbody.DataBind()

                CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)

                For i As Integer = 0 To pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows.Count - 1
                    Dim txtcost As TextBox = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox)
                    Dim txtqty As TextBox = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox)
                    txtcost.Enabled = True
                    txtcost.Attributes.Add("onclick", "this.select()")
                    txtcost.Attributes.Add("onFocus", "this.select()")
                    txtqty.Enabled = True
                    txtqty.Attributes.Add("onclick", "this.select()")
                    txtqty.Attributes.Add("onFocus", "this.select()")

                Next

                If gvIncomingPR.SelectedDataKey(3) = True Then
                    ddSupplier.Enabled = False
                    btnsupplier.Enabled = False
                    btnsave.Enabled = False
                Else

                    ddSupplier.Enabled = True
                    btnsupplier.Enabled = True
                    btnsave.Enabled = False
                End If

                ScriptManager.GetCurrent(Me.Page).SetFocus(CType(Me.gvbody.Rows(0).FindControl("txtqty"), TextBox))
                btnDeclareWinner.Enabled = True

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
            '  Dim data As New DataTable
            ' data = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString)
            Me.Session("rowindex") = gvr.RowIndex
            pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("cost") = CType(txtCost.Text, Decimal)
            pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("total") = CType(txtCost.Text * pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("qty"), Decimal)
            CType(Me.gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("total"), 2)

            If CType(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), Decimal) <= CType(gvIncomingPR.SelectedDataKey(2), Decimal) Then
                CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                callEnableButton()
                CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Enabled = False
                pTempSupplier.Rows(gvsupplier.SelectedIndex)("amount") = CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Text
                Dim txt As TextBox = CType(Me.gvbody.Rows(gvr.RowIndex + 1).Cells(2).FindControl("txtcost"), TextBox)
                ScriptManager.GetCurrent(Me.Page).SetFocus(txt)
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Total amount exceed the ABC(" & FormatNumber(gvIncomingPR.SelectedDataKey(2), 2) & ")")
                CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                callEnableButton()
                Me.btnsave.Enabled = False
                CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Enabled = False
                pTempSupplier.Rows(gvsupplier.SelectedIndex)("amount") = CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Text
                Dim txt As TextBox = CType(Me.gvbody.Rows(gvr.RowIndex + 1).Cells(2).FindControl("txtcost"), TextBox)
                'txtCost.Text = CType("0.00", Decimal)
                'pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("cost") = CType(txtCost.Text, Decimal)
                'pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("total") = CType("0.00", Decimal)
                'CType(Me.gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(CType("0.00", Decimal), 2)
                'CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                'Dim txt As TextBox = CType(Me.gvbody.Rows(gvr.RowIndex).Cells(3).FindControl("txtCost"), TextBox)
                'ScriptManager.GetCurrent(Me.Page).SetFocus(txt)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Public Sub callEnableButton()

        If CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = "0.00" Then
            btnsave.Enabled = False
        Else
            btnsave.Enabled = True
        End If
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            For i As Integer = 0 To Me.gvsupplier.Rows.Count - 1
                If pTempSupplier.Rows(i)("Supplier_ID") <> 0 And pTempSupplier.Rows(i)("isOld") <> True Then
                    hdr.prhdr_id = gvIncomingPR.SelectedDataKey(0)
                    hdr.Supplier_Id = gvsupplier.SelectedDataKey(0)
                    hdr.dateT = Date.Today.ToString("MM/dd/yyyy")
                    hdr.amount = CType(gvsupplier.Rows(i).FindControl("txtcost"), TextBox).Text ''FormatNumber(pGoodsPerSupplier(pTempSupplier.Rows(i)("Supplier_ID").ToString).Compute("sum(total)", ""), 2)
                    hdr.isWinner = False
                    Dim hdrID As Long = hdr.save()

                    Try
                        For dtlrow As Integer = 0 To gvbody.Rows.Count - 1
                            dtl.canvass_hdr_id = hdrID
                            dtl.item_id = pGoodsPerSupplier(pTempSupplier.Rows(i)("Supplier_ID").ToString).Rows(dtlrow)("item_id")
                            dtl.qty = pGoodsPerSupplier(pTempSupplier.Rows(i)("Supplier_ID").ToString).Rows(dtlrow)("qty")
                            dtl.Cost = pGoodsPerSupplier(pTempSupplier.Rows(i)("Supplier_ID").ToString).Rows(dtlrow)("cost")
                            dtl.save()
                        Next
                    Catch ex As Exception
                    End Try


                ElseIf pTempSupplier.Rows(i)("Supplier_ID") <> 0 And pTempSupplier.Rows(i)("isOld") = True Then
                    'objDerived.GetRecords("Update ams.canvass_hdr set amount=" & pGoodsPerSupplier(pTempSupplier.Rows(i)("Supplier_ID").ToString).Compute("sum(total)", "") & " where canvass_hdr_id=" & pTempSupplier.Rows(i)("canvass_hdr_id") & "", CommandType.Text)
                    objDerived.GetRecords("Update ams.canvass_hdr set amount=" & pTempSupplier.Rows(i)("amount") & " where canvass_hdr_id=" & pTempSupplier.Rows(i)("canvass_hdr_id") & "", CommandType.Text)

                    Try
                        For dtlrow As Integer = 0 To gvbody.Rows.Count - 1
                            dtl.canvass_dtl_id = pGoodsPerSupplier(pTempSupplier.Rows(i)("Supplier_ID").ToString).Rows(dtlrow)("canvass_dtl_id")
                            dtl.canvass_hdr_id = pTempSupplier.Rows(i)("canvass_hdr_id")
                            dtl.item_id = pGoodsPerSupplier(pTempSupplier.Rows(i)("Supplier_ID").ToString).Rows(dtlrow)("item_id")
                            dtl.qty = pGoodsPerSupplier(pTempSupplier.Rows(i)("Supplier_ID").ToString).Rows(dtlrow)("qty")
                            dtl.Cost = pGoodsPerSupplier(pTempSupplier.Rows(i)("Supplier_ID").ToString).Rows(dtlrow)("cost")
                            dtl.update()
                        Next
                    Catch ex As Exception

                    End Try

                End If
            Next
            'objDerived.GetRecords("Update ams.pre_procurement set withBid=1 where pre_procurement_hdr_id=" & ddProjectReference.SelectedItem.Value & "", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been succesfully saved.")
            call_laod_supplier_per_project()
            btnsave.Enabled = False
            btnPreview.Enabled = False


        Catch ex As Exception

        End Try


    End Sub

    Protected Sub txtqty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtqty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            If txtqty.Text = "" Then
                txtqty.Text = "0"
            End If
            ' txtCost.Text = FormatNumber(txtCost.Text, 2)
            '  Dim data As New DataTable
            ' data = pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString)
            Me.Session("rowindex") = gvr.RowIndex
            'pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("cost") = CType(txtCost.Text, Decimal)
            pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("qty") = CType(txtqty.Text, Integer)
            pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("total") = CType(txtqty.Text * pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("cost"), Decimal)
            CType(Me.gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("total"), 2)
            If CType(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), Decimal) <= CType(gvIncomingPR.SelectedDataKey(2), Decimal) Then


                CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                callEnableButton()
                CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Enabled = False
                pTempSupplier.Rows(gvsupplier.SelectedIndex)("amount") = CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Text
                Dim txt As TextBox = CType(Me.gvbody.Rows(gvr.RowIndex).Cells(3).FindControl("txtCost"), TextBox)
                ScriptManager.GetCurrent(Me.Page).SetFocus(txt)
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Total amount exceed the ABC(" & FormatNumber(gvIncomingPR.SelectedDataKey(2), 2) & ")")
                CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                callEnableButton()
                CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Enabled = False
                pTempSupplier.Rows(gvsupplier.SelectedIndex)("amount") = CType(gvsupplier.Rows(gvsupplier.SelectedIndex).FindControl("txtcost"), TextBox).Text
                Dim txt As TextBox = CType(Me.gvbody.Rows(gvr.RowIndex).Cells(3).FindControl("txtCost"), TextBox)
                'txtCost.Text = CType("0.00", Decimal)
                'pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("cost") = CType(txtCost.Text, Decimal)
                'pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Rows(gvr.RowIndex)("total") = CType("0.00", Decimal)
                'CType(Me.gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(CType("0.00", Decimal), 2)
                'CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                'Dim txt As TextBox = CType(Me.gvbody.Rows(gvr.RowIndex).Cells(3).FindControl("txtCost"), TextBox)
                'ScriptManager.GetCurrent(Me.Page).SetFocus(txt)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)


        If Me.txtcanvassearch.Text.Length = 1 Then
            Me.txtcanvassearch.Text = "000" + Me.txtcanvassearch.Text

        ElseIf Me.txtcanvassearch.Text.Length = 2 Then
            Me.txtcanvassearch.Text = "00" + Me.txtcanvassearch.Text

        ElseIf Me.txtcanvassearch.Text.Length <= 3 Then
            Me.txtcanvassearch.Text = "0" + Me.txtcanvassearch.Text


        End If

        Dim str As String = Me.txtcanvassearch.Text

        str.Substring(0, str.Length - 3)

        Me.gvIncomingPR.DataSource = objDerived.GetRecords("Exec [dbo].[sp_SearchPrno_negotiated] '" & Me.txtcanvassearch.Text & "'", Data.CommandType.Text)
        Me.gvIncomingPR.DataBind()
        'Me.gvIncomingPR.DataSource = objDerived.Search(pShopping, "pr_no", "PR" + "-" + txtcanvassearch.Text)
        'Me.gvIncomingPR.DataBind()


        'Me.gvIncomingPR.DataSource = objDerived.Search(pShopping, "pr_no", "PR" + "-" + txtcanvassearch.Text)
        'Me.gvIncomingPR.DataBind()
    End Sub

    Protected Sub btnviewAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pShopping = objDerived.GetDataTable("select * from ams.vw_canvass_goods", CommandType.Text)
        If pShopping.Rows.Count < 8 Then
            pShopping.Merge(createdatatable(7 - pShopping.Rows.Count))
        End If
        gvIncomingPR.DataSource = pShopping
        gvIncomingPR.DataBind()
        btnPreview.Enabled = False
        btnsave.Enabled = False

        Me.txtcanvassearch.Text = ""

    End Sub

    Protected Sub txtcost_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtCost As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtCost.NamingContainer, GridViewRow)
            If txtCost.Text = "" Then
                txtCost.Text = "0.00"
            End If
            txtCost.Text = FormatNumber(txtCost.Text, 2)
            pTempSupplier.Rows(gvsupplier.SelectedIndex)("amount") = txtCost.Text
            btnsave.Enabled = True
            Dim txt As TextBox = CType(Me.gvsupplier.Rows(gvr.RowIndex).Cells(1).FindControl("txtCost"), TextBox)
            ScriptManager.GetCurrent(Me.Page).SetFocus(txt)
            'gvsupplier.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub

    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("Supplier_Id", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("status", GetType(String))
        dt.Columns.Add("isOld", GetType(Boolean))
        dt.Columns.Add("canvass_hdr_id", GetType(Integer))
        dt.Columns.Add("prhdr_id", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = DBNull.Value
            dr("Supplier_Id") = DBNull.Value
            dr("isVisible") = True
            dr("amount") = DBNull.Value
            dr("status") = DBNull.Value
            dr("isOld") = False
            dr("canvass_hdr_id") = DBNull.Value
            dr("prhdr_id") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_no", GetType(Integer))
        dt.Columns.Add("Item_ID", GetType(Integer))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("total", GetType(Decimal))
        dt.Columns.Add("item_desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("BGA_ID", GetType(Integer))
        dt.Columns.Add("isEnable", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_no") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("qty") = DBNull.Value
            dr("cost") = DBNull.Value
            dr("total") = DBNull.Value
            dr("item_desc") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("remarks") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("BGA_ID") = DBNull.Value
            dr("isEnable") = True


            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub gvbody_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub gvbody_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvbody.RowDataBound
        'Dim gvr As GridViewRow = e.Row
        'Dim TOTALcost As Decimal

        ''CType(gvbody.Rows(i).FindControl("lbltotal"), Label).Text()

        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim lbl As Label
        '    lbl = CType(e.Row.FindControl("lbltotal"), Label)

        '    lbl.Text = CType(lbl.Text, Decimal).ToString("###,###,###,###,##0.00")
        '    TOTALcost += CType(lbl.Text, Decimal) 'CType(gvr.Cells(4).Text, Double)

        'ElseIf e.Row.RowType = DataControlRowType.Footer Then
        '    'e.Row.Cells(4).Text = "Total Cost (All Programs)"
        '    'e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Left
        '    e.Row.Cells(4).Text = TOTALcost.ToString("###,###,###,###,##0.00")
        '    e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
        'End If

        'Dim total As Decimal
        'Dim lbltotal As Decimal = CType(e.Row.FindControl("lbltotal"), Label)
        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "lbltotal"))

        'ElseIf (e.Row.RowType = DataControlRowType.Footer) Then
        '    ' e.Row.Cells(4).Text = e.Row.FindControl("lbltotal")
        '    e.Row.Cells(4).Text = total.ToString()
        'End If

    End Sub

    Protected Sub gvIncomingPR_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pShopping = objDerived.GetDataTable("select * from ams.vw_pre_procurement_negotiated_goods order by pr_no", CommandType.Text)
        If pShopping.Rows.Count < 8 Then
            pShopping.Merge(createdatatable(8 - pShopping.Rows.Count))
        End If
        gvIncomingPR.PageIndex = e.NewPageIndex
        gvIncomingPR.DataSource = pShopping
        gvIncomingPR.DataBind()
    End Sub

    Protected Sub btnDeclareWinner_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        lblreq.Visible = False
        lbl1.Visible = False
        lbl2.Visible = False

        txtProjectRefNo.Text = ""
        txtResolutionNo.Text = ""

        ModalPopupExtender1.Show()
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If txtProjectRefNo.Text = "" Or txtResolutionNo.Text = "" Then
            lblreq.Text = "Fill up required fields."
            lblreq.Visible = True
            lbl1.Visible = True
            lbl2.Visible = True
            ModalPopupExtender1.Show()
        Else
            lblreq.Visible = False
            lbl1.Visible = False
            lbl2.Visible = False
            Try
                '======================= Pre Procurement =======================
                With phdr
                    .obr_evaluation_hdr_id = gvIncomingPR.SelectedDataKey("obr_evaluation_hdr_id")
                    .bid_docs = "0.00"
                    '.bid_security = txtBidSecurity.Text
                    .mode_of_procurement_id = 4
                    .project_location = ""
                    .project_reference_no = txtProjectRefNo.Text
                    .project_name = gvIncomingPR.SelectedDataKey("remarks")
                    .ABC = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                    .opening_venue = ""
                    .opening_date = "01/01/1900"
                    .withBid = True
                    .isRebid = False
                    .withWinner = True
                    .withPO = False
                    .BACC = "LAURA A. SY"
                    .BACVC = "NENITA B. CARTAGENA"
                    .BAC1 = "ROMULO M. CATINDIG"
                    .BAC2 = "ERLINDA C. CREENCIA"
                    .BAC3 = "CELSO C. CATINDIG, JR."
                    .TWGH = "NELIA F. CARVAJAL"
                    .TWGM = ""
                    .ENDUSER = ""
                    .Representative1 = ""
                    .Representative2 = ""
                    .Transaction_type = gvIncomingPR.SelectedDataKey("Transaction_type")
                    .F_ID = Me.Session("F_ID")
                    .resolution_number_date = Date.Today.ToString("MM/dd/yyyy")
                    .declarationDate = "01/01/1900"
                    .transaction_date = Date.Today.ToString("MM/dd/yyyy")
                    .withNOA = False
                    .withNTP = False
                    .dateNTP = "01/01/1900"
                    .dateNOA = "01/01/1900"
                    .isPublicInfra = gvIncomingPR.SelectedDataKey("isPublicInfra")
                    .isStraight = gvIncomingPR.SelectedDataKey("isStraight")
                    '.resolution_number = txtResolutionNo.Text

                End With

                Dim hdrid As Long = phdr.save()
                Me.Session("pre_procurement_hdr_id") = hdrid

                objDerived.GetRecords("Update ams.pre_procurement set resolution_number='" & txtResolutionNo.Text & "' where pre_procurement_hdr_id='" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)

                pdtl.pre_procurement_hdr_id = hdrid
                pdtl.obr_evaluation_dtl_id = gvIncomingPR.SelectedDataKey("obr_evaluation_dtl_id")
                pdtl.ABC = FormatNumber(pGoodsPerSupplier(gvsupplier.SelectedDataKey(0).ToString).Compute("sum(total)", ""), 2)
                pdtl.save()

                objDerived.GetRecords("Update AMS.obr_evaluation_dtl set withPreProcurement=1 where prhdr_id=" & gvIncomingPR.SelectedDataKey("prhdr_id") & "", CommandType.Text)

                '==================== Declare The Winner =========================

                objDerived.GetRecords("Update ams.PR_Hdr set withWinner=1,isOnBid =1,declarationDate='" & Date.Today.ToString("MM/dd/yyyy") & "' where prhdr_id='" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                objDerived.GetRecords("Update ams.canvass_hdr set isWinner=1  where prhdr_id='" & gvIncomingPR.SelectedDataKey("prhdr_id") & "' and Supplier_ID ='" & gvsupplier.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been succesfully closed.")
                call_laod_supplier_per_project()

                btnsave.Enabled = False

                pShopping = objDerived.GetDataTable("select * from ams.vw_pre_procurement_negotiated_goods order by pr_no", CommandType.Text)
                If pShopping.Rows.Count < 8 Then
                    pShopping.Merge(createdatatable(8 - pShopping.Rows.Count))
                End If
                gvIncomingPR.DataSource = pShopping
                gvIncomingPR.DataBind()


                gvsupplier.DataSource = createdatatable1(2)
                gvsupplier.DataBind()

                gvbody.DataSource = createdatatable2(4)
                gvbody.DataBind()

            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
