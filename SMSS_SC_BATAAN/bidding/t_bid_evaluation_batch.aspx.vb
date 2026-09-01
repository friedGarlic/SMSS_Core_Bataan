Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class t_bid_evaluation
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal
    Private hdr As New t_bid_opening_hdr
    Private dtl As New t_bid_opening_dtl

#Region "Property"

    Private Property cb1Count() As Integer
        Get
            Return CType(Session("cb1Count"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("cb1Count") = value
        End Set
    End Property
    Private Property cb2Count() As Integer
        Get
            Return CType(Session("cb2Count"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("cb2Count") = value
        End Set
    End Property
    Private Property cb3Count() As Integer
        Get
            Return CType(Session("cb3Count"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("cb3Count") = value
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
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("obr_evaluation_hdr_id", GetType(Long))
        dt.Columns.Add("project_reference_no")
        dt.Columns.Add("project_name")
        dt.Columns.Add("project_description")
        dt.Columns.Add("project_location")
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("bid_docs", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("CountSupplier", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pre_procurement_hdr_id") = 0
            dr("obr_evaluation_hdr_id") = 0
            dr("project_reference_no") = ""
            dr("project_name") = ""
            dr("project_description") = ""
            dr("project_location") = ""
            dr("ABC") = "0.00"
            dr("bid_docs") = "0.00"
            dr("isVisible") = False
            dr("CountSupplier") = 0
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatableSuppliers(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("indexNo", GetType(Long))
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("SuppName")
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("examination_bid", GetType(Boolean))
        dt.Columns.Add("ceiling_price", GetType(Boolean))
        dt.Columns.Add("isWinner", GetType(Boolean))
        dt.Columns.Add("isPostQualification", GetType(Boolean))
        dt.Columns.Add("bid_opening_hdr_id", GetType(Long))

        dt.Columns.Add("BidSecurity_id", GetType(Long))
        dt.Columns.Add("BankName")
        dt.Columns.Add("Number")
        dt.Columns.Add("ValidityPeriod", GetType(Integer))
        dt.Columns.Add("BidSecurityAmount", GetType(Decimal))
        dt.Columns.Add("remarks")
        dt.Columns.Add("status")
        dt.Columns.Add("withOR", GetType(Boolean))
        dt.Columns.Add("orstatus")
        dt.Columns.Add("enable", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("indexNo") = 0
            dr("Supplier_Id") = 0
            dr("SuppName") = ""
            dr("amount") = "0.00"
            dr("isVisible") = False
            dr("examination_bid") = True
            dr("ceiling_price") = True
            dr("isWinner") = True
            dr("isPostQualification") = True
            dr("bid_opening_hdr_id") = 0
            dr("BidSecurity_id") = 0
            dr("BankName") = ""
            dr("Number") = ""
            dr("ValidityPeriod") = 0
            dr("BidSecurityAmount") = "0.00"
            dr("remarks") = ""
            dr("status") = ""
            dr("withOR") = False
            dr("orstatus") = ""
            dr("enable") = False
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

                LoadMain()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub LoadMain()
        pPublicBidding = objDerived.GetDataTable("select * from ams.vw_bid_evaluation", CommandType.Text)
        If pPublicBidding.Rows.Count < 8 Then
            pPublicBidding.Merge(createdatatable(7 - pPublicBidding.Rows.Count))
        End If

        gvPublic_bidding.DataSource = pPublicBidding
        gvPublic_bidding.DataBind()

        pSupplier = Nothing
        pTempSupplier = Nothing

        btnFail.Enabled = False
        lbllStatus.Text = "PRELIMINARY EXAMINATION OF BIDS"

        For i As Integer = 0 To gvPublic_bidding.Rows.Count - 1
            If gvPublic_bidding.Rows(i).Cells(2).Text = "0" Then
                gvPublic_bidding.Rows(i).Cells(2).Text = ""
            End If
        Next

        Me.MultiView1.SetActiveView(Me.View1)
        gvsupplier.DataSource = createdatatableSuppliers(7)
        gvsupplier.DataBind()

    End Sub
    Protected Sub btnFail_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            objDerived.GetRecords("Delete  from  AMS.pre_procurement where pre_procurement_hdr_id =  " & gvPublic_bidding.SelectedDataKey("pre_procurement_hdr_id") & "", CommandType.Text)
            objDerived.GetRecords("Delete  from  AMS.pre_procurement_dtl where pre_procurement_hdr_id =  " & gvPublic_bidding.SelectedDataKey("pre_procurement_hdr_id") & "", CommandType.Text)
            objDerived.GetRecords("Delete  from  dbo.tbl_integrated_collections_table where Transaction_ID =  " & gvPublic_bidding.SelectedDataKey("pre_procurement_hdr_id") & "", CommandType.Text)
            objDerived.GetRecords("Update AMS.obr_evaluation_dtl set withPreProcurement=0 where obr_evaluation_hdr_id =  " & gvPublic_bidding.SelectedDataKey("obr_evaluation_hdr_id") & "", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Failure of bidding confirmed.")

            LoadMain()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lbApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "close"
    End Sub
    Protected Sub lblAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "add"
    End Sub
    Protected Sub gvPublic_bidding_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Lbtn = "project_reference_no" Then

            Me.Session("project_reference_no") = gvPublic_bidding.SelectedDataKey(0)
            btnNext.Text = "NEXT"

            pSupplier = objDerived.GetDataTable("exec ams.sp_bid_evaluation_dtl " & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
            If pSupplier.Rows.Count < 8 Then
                pSupplier.Merge(createdatatableSuppliers(7 - pSupplier.Rows.Count))
            End If

            If pSupplier.Compute("count(examination_bid)", "examination_bid=1 and Supplier_Id<>0") = 0 Then
                gvsupplier.DataSource = pSupplier
                gvsupplier.DataBind()
                lbllStatus.Text = "PRELIMINARY EXAMINATION OF BIDS"
                btnFail.Enabled = True
                btnNext.Enabled = False
                cb1Count = pSupplier.Compute("count(examination_bid)", "examination_bid=1 and Supplier_Id<>0")
                MultiView1.SetActiveView(View1)
                btnback.Enabled = False
                Exit Sub
                btnNext.Text = "NEXT"

            ElseIf pSupplier.Compute("count(ceiling_price)", "ceiling_price=1 and Supplier_Id<>0") = 0 Then
                cb2Count = pSupplier.Compute("count(ceiling_price)", "ceiling_price=1 and Supplier_Id<>0")
                Dim dt As DataTable
                dt = pSupplier
                dt.DefaultView.RowFilter = "examination_bid=true"
                gvCeiling.DataSource = dt
                gvCeiling.DataBind()

                Me.MultiView1.SetActiveView(Me.View2)

                lbllStatus.Text = "CEILING FOR BIDS PRICES"
                btnback.Enabled = True
               
                If cb2Count = 0 Then
                    btnFail.Enabled = True
                    btnNext.Enabled = False
                Else
                    btnFail.Enabled = False
                    btnNext.Enabled = True
                End If
                Exit Sub
                btnNext.Text = "NEXT"

            ElseIf pSupplier.Compute("count(isPostQualification)", "isPostQualification=1 and Supplier_Id<>0") = 0 Then
                cb3Count = pSupplier.Compute("count(isPostQualification)", "isPostQualification=1 and Supplier_Id<>0")
                Dim dt As DataTable
                dt = pSupplier
                dt.DefaultView.RowFilter = "ceiling_price=true"
                gvPostQualification.DataSource = dt
                gvPostQualification.DataBind()
                MultiView1.SetActiveView(View3)

                lbllStatus.Text = "BID EVALUATION"
                If cb3Count = 0 Then
                    btnback.Enabled = True
                    btnNext.Enabled = False
                    btnFail.Enabled = True
                Else
                    btnback.Enabled = True
                    btnFail.Enabled = False
                    btnNext.Enabled = True
                End If

                Dim cb As CheckBox
                For i As Integer = 0 To gvPostQualification.Rows.Count - 1
                    cb = CType(gvPostQualification.Rows(i).FindControl("cb3"), CheckBox)
                    If cb3Count = 0 Then
                        cb.Enabled = True
                    Else
                        If cb.Checked = True Then
                            cb.Enabled = True
                        Else
                            cb.Checked = False
                        End If
                    End If

                Next
                Exit Sub
                btnNext.Text = "NEXT"
            Else
                Dim dt As DataTable
                dt = pSupplier
                dt.DefaultView.RowFilter = "isWinner=true or isPostQualification = true"
                gvPost.DataSource = dt
                gvPost.DataBind()
                MultiView1.SetActiveView(View4)
                'dt.DefaultView.RowFilter = "examination_bid=true or examination_bid=false"
                lbllStatus.Text = "POST QUALIFICATION"

                If pSupplier.Rows(0)("isWinner") = False Then
                    btnback.Enabled = True
                    btnNext.Enabled = False
                    btnFail.Enabled = True
                Else
                    btnback.Enabled = False
                    btnFail.Enabled = False
                    btnNext.Enabled = False
                End If
                btnNext.Text = "SAVE"

            End If
        End If
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "project_reference_no"
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
            dt.Columns.Add("date", GetType(Date))
            dt.Columns.Add("status")
            dt.Columns.Add("isOld", GetType(Boolean))
            dt.Columns.Add("amount", GetType(Decimal))
            If pSupplier.Rows.Count <= 0 Then
                dr = dt.NewRow
                '   dr("SuppName") = ddSupplier.SelectedItem.Text
                ' dr("Supplier_Id") = ddSupplier.SelectedItem.Value
                dr("isVisible") = True
                dr("date") = Date.Today.ToString("MM/dd/yyyy")
                dr("status") = ""
                dr("isOld") = False
                dr("amount") = "0.00"
                dt.Rows.Add(dr)
                pSupplier.Merge(dt)
                If pSupplier.Rows.Count < 8 Then
                    pSupplier.Merge(createdatatableSuppliers(7 - pSupplier.Rows.Count))
                End If
            Else
                Dim sumObject As Integer = pSupplier.Compute("count(isVisible)", "isVisible=1")
                dr = dt.NewRow
                '  dr("SuppName") = ddSupplier.SelectedItem.Text
                '  dr("Supplier_Id") = ddSupplier.SelectedItem.Value
                dr("isVisible") = True
                dr("date") = Date.Today.ToString("MM/dd/yyyy")
                dr("status") = ""
                dr("isOld") = False
                dr("amount") = "0.00"
                dt.Rows.Add(dr)
                pSupplier.Merge(dt)


                If sumObject <= 7 Then
                    For i As Integer = 0 To 8
                        If sumObject + i < 8 Then
                            pSupplier.Rows(7 - i).Delete()
                        Else
                            Exit For
                        End If
                    Next
                    'sumObject = 0
                    sumObject = pSupplier.Compute("count(isVisible)", "isVisible=1")
                    pSupplier.Merge(createdatatableSuppliers(7 - sumObject))
                End If
            End If
            gvsupplier.DataSource = pSupplier
            gvsupplier.DataBind()
            ' ddSupplier.Items.RemoveAt(ddSupplier.SelectedIndex)
            '  ddSupplier.SelectedIndex = 0

            For i As Integer = 0 To Me.gvsupplier.Rows.Count - 1
                Dim txt As TextBox = CType(gvsupplier.Rows(i).FindControl("txtamount"), TextBox)
                txt.Attributes.Add("onclick", "this.select()")
                txt.Attributes.Add("onFocus", "this.select()")

            Next
            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(gvsupplier.Rows(0).FindControl("txtamount"), TextBox))
        Catch ex As Exception

        End Try
    End Sub


    'Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If ddSupplier.SelectedIndex = 0 Then
    '        btnsupplier.Enabled = False
    '    Else
    '        btnsupplier.Enabled = True
    '        gvsupplier.SelectedIndex = -1
    '    End If
    'End Sub





    Protected Sub gvsupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        pSupplier.Rows(gvCeiling.SelectedDataKey(1))("ceiling_price") = True
        pSupplier.Rows(gvCeiling.SelectedDataKey(1))("ceiling_price") = True
    End Sub

    Protected Sub lbSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub



    Protected Sub txtamount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim txtCost As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtCost.NamingContainer, GridViewRow)
            If txtCost.Text = "" Then
                txtCost.Text = "0.00"
            End If
            txtCost.Text = FormatNumber(txtCost.Text, 2)

            pSupplier.Rows(gvr.RowIndex)("amount") = txtCost.Text
            If CType(txtCost.Text, Decimal) > CType(gvPublic_bidding.SelectedDataKey(1), Decimal) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Amount have exceed " & FormatNumber(gvPublic_bidding.SelectedDataKey(1), 2) & ".")
            End If
            Dim txt As TextBox = CType(gvsupplier.Rows(gvr.RowIndex + 1).FindControl("txtamount"), TextBox)
            If pSupplier.Compute("SUM(amount)", "") = "0.00" Then
                ' btnsubmit.Enabled = False
            Else
                '  btnsubmit.Enabled = True
            End If
            txt.Attributes.Add("onclick", "this.select()")
            txt.Attributes.Add("onFocus", "this.select()")
            ScriptManager.GetCurrent(Me.Page).SetFocus(txt)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dt As DataTable
        If MultiView1.ActiveViewIndex = 0 Then
            For i As Integer = 0 To gvsupplier.Rows.Count - 1
                If pSupplier.Rows(i)("Supplier_Id") <> 0 Then

                    Dim cb As CheckBox = CType(gvsupplier.Rows(i).FindControl("cb1"), CheckBox)
                    If cb.Checked = True Then
                        pSupplier.Rows(i)("examination_bid") = True
                    Else
                        pSupplier.Rows(i)("examination_bid") = False
                    End If

                    hdr.bid_opening_hdr_id = pSupplier.Rows(i)("bid_opening_hdr_id")
                    hdr.pre_procurement_hdr_id = gvPublic_bidding.SelectedDataKey(0)
                    hdr.Supplier_Id = pSupplier.Rows(i)("Supplier_Id")
                    hdr.amount = pSupplier.Rows(i)("amount")
                    hdr.calculatedAmount = "0.00"
                    hdr.examination_bid = pSupplier.Rows(i)("examination_bid")
                    hdr.ceiling_price = pSupplier.Rows(i)("ceiling_price")
                    hdr.isPostQualification = pSupplier.Rows(i)("isPostQualification")
                    hdr.isWinner = pSupplier.Rows(i)("isWinner")
                    hdr.isCalculated = False
                    hdr.BidSecurity_id = pSupplier.Rows(i)("BidSecurity_id")
                    hdr.BankName = pSupplier.Rows(i)("BankName")
                    hdr.Number = pSupplier.Rows(i)("Number")
                    hdr.ValidityPeriod = pSupplier.Rows(i)("ValidityPeriod")
                    hdr.BidSecurityAmount = pSupplier.Rows(i)("BidSecurityAmount")
                    hdr.remarks = pSupplier.Rows(i)("remarks")
                    hdr.status = pSupplier.Rows(i)("status")
                    hdr.update()
                End If
            Next
            dt = pSupplier
            dt.DefaultView.RowFilter = "examination_bid=true"
            gvCeiling.DataSource = dt
            gvCeiling.DataBind()

            Me.MultiView1.SetActiveView(Me.View2)
            dt.DefaultView.RowFilter = "examination_bid=true or examination_bid=false"
            lbllStatus.Text = "CEILING FOR BIDS PRICES"

            If cb2Count = 0 Then
                btnFail.Enabled = True
                btnNext.Enabled = False
            Else
                btnFail.Enabled = False
                btnNext.Enabled = True
            End If

            btnback.Enabled = True
        ElseIf MultiView1.ActiveViewIndex = 1 Then

            dt = pSupplier
            dt.DefaultView.RowFilter = ""
            For i As Integer = 0 To pSupplier.Rows.Count - 1
                If pSupplier.Rows(i)("Supplier_Id") <> 0 Then
                    hdr.bid_opening_hdr_id = pSupplier.Rows(i)("bid_opening_hdr_id")
                    hdr.pre_procurement_hdr_id = gvPublic_bidding.SelectedDataKey(0)
                    hdr.Supplier_Id = pSupplier.Rows(i)("Supplier_Id")
                    hdr.amount = pSupplier.Rows(i)("amount")
                    hdr.calculatedAmount = "0.00"
                    hdr.examination_bid = pSupplier.Rows(i)("examination_bid")
                    hdr.ceiling_price = pSupplier.Rows(i)("ceiling_price")
                    hdr.isPostQualification = pSupplier.Rows(i)("isPostQualification")
                    hdr.isWinner = pSupplier.Rows(i)("isWinner")
                    hdr.isCalculated = False
                    hdr.BidSecurity_id = pSupplier.Rows(i)("BidSecurity_id")
                    hdr.BankName = pSupplier.Rows(i)("BankName")
                    hdr.Number = pSupplier.Rows(i)("Number")
                    hdr.ValidityPeriod = pSupplier.Rows(i)("ValidityPeriod")
                    hdr.BidSecurityAmount = pSupplier.Rows(i)("BidSecurityAmount")
                    hdr.remarks = pSupplier.Rows(i)("remarks")
                    hdr.status = pSupplier.Rows(i)("status")
                    hdr.update()
                End If
            Next
            MultiView1.SetActiveView(View3)
            dt = pSupplier
            dt.DefaultView.RowFilter = "ceiling_price=true"
            gvPostQualification.DataSource = dt
            gvPostQualification.DataBind()
            lbllStatus.Text = "BID EVALUATION"
            cb3Count = pSupplier.Compute("count(isPostQualification)", "isPostQualification=1 and Supplier_Id<>0")
            If cb3Count = 0 Then
                btnback.Enabled = True
                btnNext.Enabled = False
                btnFail.Enabled = True
            Else
                btnback.Enabled = False
                btnNext.Enabled = True
                btnFail.Enabled = False

            End If

            '  pSupplier.Rows(pSupplier.Rows(index)("indexNo"))("isPostQualification") = True
            Dim cb As CheckBox
            For i As Integer = 0 To gvPostQualification.Rows.Count - 1
                cb = CType(gvPostQualification.Rows(i).FindControl("cb3"), CheckBox)
                If cb3Count = 0 Then
                    cb.Enabled = True
                Else
                    If cb.Checked = True Then
                        cb.Enabled = True
                    Else
                        cb.Checked = False
                    End If
                End If
            Next
            'btnback.Enabled = True
            'btnFail.Enabled = True
            'btnNext.Enabled = False
        ElseIf MultiView1.ActiveViewIndex = 2 Then
            dt = pSupplier
            dt.DefaultView.RowFilter = ""
            For i As Integer = 0 To pSupplier.Rows.Count - 1
                '' If pSupplier.Rows(i)("isWinner") = 1 And pSupplier.Rows(i)("Supplier_Id") <> 0 Then
                If pSupplier.Rows(i)("Supplier_Id") <> 0 Then
                    hdr.bid_opening_hdr_id = pSupplier.Rows(i)("bid_opening_hdr_id")
                    hdr.pre_procurement_hdr_id = gvPublic_bidding.SelectedDataKey(0)
                    hdr.Supplier_Id = pSupplier.Rows(i)("Supplier_Id")
                    hdr.amount = pSupplier.Rows(i)("amount")
                    hdr.calculatedAmount = "0.00"
                    hdr.examination_bid = pSupplier.Rows(i)("examination_bid")
                    hdr.ceiling_price = pSupplier.Rows(i)("ceiling_price")
                    hdr.isPostQualification = pSupplier.Rows(i)("isPostQualification")
                    hdr.isWinner = pSupplier.Rows(i)("isWinner")
                    hdr.isCalculated = False
                    hdr.BidSecurity_id = pSupplier.Rows(i)("BidSecurity_id")
                    hdr.BankName = pSupplier.Rows(i)("BankName")
                    hdr.Number = pSupplier.Rows(i)("Number")
                    hdr.ValidityPeriod = pSupplier.Rows(i)("ValidityPeriod")
                    hdr.BidSecurityAmount = pSupplier.Rows(i)("BidSecurityAmount")
                    hdr.remarks = pSupplier.Rows(i)("remarks")
                    hdr.status = pSupplier.Rows(i)("status")
                    hdr.update()
                End If
            Next
            dt = pSupplier
            dt.DefaultView.RowFilter = "isPostQualification=true"
            gvPost.DataSource = dt
            gvPost.DataBind()
            MultiView1.SetActiveView(View4)
            lbllStatus.Text = "POST QUALIFICATION"
            ' ModalPopupExtender1.Show()

            btnback.Enabled = True
            btnNext.Enabled = False
            btnFail.Enabled = True
            btnNext.Text = "SAVE"

        ElseIf MultiView1.ActiveViewIndex = 3 Then
            dt = pSupplier
            dt.DefaultView.RowFilter = ""
            For i As Integer = 0 To pSupplier.Rows.Count - 1
                If pSupplier.Rows(i)("Supplier_Id") <> 0 Then
                    hdr.bid_opening_hdr_id = pSupplier.Rows(i)("bid_opening_hdr_id")
                    hdr.pre_procurement_hdr_id = gvPublic_bidding.SelectedDataKey(0)
                    hdr.Supplier_Id = pSupplier.Rows(i)("Supplier_Id")
                    hdr.amount = pSupplier.Rows(i)("amount")
                    hdr.calculatedAmount = "0.00"
                    hdr.examination_bid = pSupplier.Rows(i)("examination_bid")
                    hdr.ceiling_price = pSupplier.Rows(i)("ceiling_price")
                    hdr.isPostQualification = pSupplier.Rows(i)("isPostQualification")
                    hdr.isWinner = pSupplier.Rows(i)("isWinner")
                    hdr.isCalculated = False
                    hdr.BidSecurity_id = pSupplier.Rows(i)("BidSecurity_id")
                    hdr.BankName = pSupplier.Rows(i)("BankName")
                    hdr.Number = pSupplier.Rows(i)("Number")
                    hdr.ValidityPeriod = pSupplier.Rows(i)("ValidityPeriod")
                    hdr.BidSecurityAmount = pSupplier.Rows(i)("BidSecurityAmount")
                    hdr.remarks = pSupplier.Rows(i)("remarks")
                    hdr.status = pSupplier.Rows(i)("status")
                    hdr.update()
                End If
            Next

            ' objDerived.GetRecords("Update ams.pre_procurement set withWinner =1 where pre_procurement_hdr_id=" & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
            MultiView1.SetActiveView(View4)
            btnFail.Enabled = False
            btnNext.Enabled = False
            btnback.Enabled = False
            ''Modified 01/21/2014
            pPublicBidding = objDerived.GetDataTable("select * from ams.vw_bid_evaluation", CommandType.Text)
            If pPublicBidding.Rows.Count < 8 Then
                pPublicBidding.Merge(createdatatable(7 - pPublicBidding.Rows.Count))
            End If
            gvPublic_bidding.DataSource = pPublicBidding
            gvPublic_bidding.DataBind()
            ''Modified 01/21/2014

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Transaction has been succesfully closed.")
            '' Added 01/21/2014
            pSupplier.Rows.Clear()
            pSupplier.Merge(createdatatableSuppliers(7))
            gvPost.DataSource = pSupplier
            gvPost.DataBind()

        End If
    End Sub
    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dt As New DataTable
        dt = pSupplier
        dt.DefaultView.RowFilter = ""
        If MultiView1.ActiveViewIndex = 1 Then

            dt.DefaultView.RowFilter = "examination_bid=true or examination_bid=false or ceiling_price=true or ceiling_price=false"
            MultiView1.SetActiveView(View1)
            gvsupplier.DataSource = dt
            gvsupplier.DataBind()
            lbllStatus.Text = "PRELIMINARY EXAMINATION OF BIDS"
            btnback.Enabled = False
            btnNext.Enabled = True
            btnFail.Enabled = False
        ElseIf MultiView1.ActiveViewIndex = 2 Then
            MultiView1.SetActiveView(View2)
            'dt.DefaultView.RowFilter = "ceiling_price=true"
            dt.DefaultView.RowFilter = "ceiling_price=true"
            gvCeiling.DataSource = dt
            gvCeiling.DataBind()
            lbllStatus.Text = "CEILING FOR BID PRICES"
            btnback.Enabled = False
            btnNext.Enabled = True
            btnFail.Enabled = False
        ElseIf MultiView1.ActiveViewIndex = 3 Then
            MultiView1.SetActiveView(View3)
            'dt.DefaultView.RowFilter = "ceiling_price=true"
            dt.DefaultView.RowFilter = "ceiling_price=true"
            gvPostQualification.DataSource = pSupplier
            gvPostQualification.DataBind()

            For i As Integer = 0 To gvPostQualification.Rows.Count - 1
                If CType(gvPostQualification.Rows(i).FindControl("cb3"), CheckBox).Checked = True Then
                    CType(gvPostQualification.Rows(i).FindControl("cb3"), CheckBox).Enabled = True
                Else
                    CType(gvPostQualification.Rows(i).FindControl("cb3"), CheckBox).Enabled = False
                End If
            Next
            lbllStatus.Text = "BID EVALUATION"
            btnback.Enabled = False
            btnNext.Enabled = True
            btnFail.Enabled = False
            btnNext.Text = "NEXT"
        End If
    End Sub
    Protected Sub cb1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
        If cb.Checked = True Then
            cb1Count = cb1Count + 1
        Else
            cb1Count = cb1Count - 1
        End If

        If cb1Count = 0 Then
            btnFail.Enabled = True
            btnNext.Enabled = False
        Else
            btnFail.Enabled = False
            btnNext.Enabled = True
        End If
    End Sub
    Protected Sub cb2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
        Dim dt As DataTable
        dt = pSupplier
        dt.DefaultView.RowFilter = ""
        cb2Count = pSupplier.Compute("count(ceiling_price)", "ceiling_price=1 and Supplier_Id<>0")

        Dim index As Integer = gvCeiling.DataKeys(gvr.RowIndex).Value
        If cb.Checked = True Then
            cb2Count = cb2Count + 1
            pSupplier.Rows(pSupplier.Rows(index)("indexNo"))("ceiling_price") = True
        Else
            cb2Count = cb2Count - 1
            pSupplier.Rows(pSupplier.Rows(index)("indexNo"))("ceiling_price") = False
        End If
        If cb2Count = 0 Then
            btnback.Enabled = True
            btnFail.Enabled = True
            btnNext.Enabled = False
        Else
            btnback.Enabled = False
            btnFail.Enabled = False
            btnNext.Enabled = True
        End If
    End Sub
    Protected Sub cb3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
        Dim dt As DataTable
        dt = pSupplier
        dt.DefaultView.RowFilter = ""

        Dim index As Integer = gvPostQualification.DataKeys(gvr.RowIndex).Value
        Me.Session("indexPost") = index

        For i As Integer = 0 To gvPostQualification.Rows.Count - 1
            If cb.Checked = True Then
                pSupplier.Rows(pSupplier.Rows(index)("indexNo"))("isPostQualification") = True
                CType(gvPostQualification.Rows(i).FindControl("cb3"), CheckBox).Enabled = False
                CType(gvPostQualification.Rows(gvr.RowIndex).FindControl("cb3"), CheckBox).Enabled = True
                btnNext.Enabled = True
                btnFail.Enabled = False
            Else
                pSupplier.Rows(pSupplier.Rows(index)("indexNo"))("isPostQualification") = False
                CType(gvPostQualification.Rows(i).FindControl("cb3"), CheckBox).Enabled = True
                CType(gvPostQualification.Rows(gvr.RowIndex).FindControl("cb3"), CheckBox).Enabled = True
                btnNext.Enabled = False
                btnFail.Enabled = True
            End If
        Next
        For i As Integer = 0 To gvPostQualification.Rows.Count - 1
            If cb.Checked = True Then
                btnback.Enabled = False
                Exit Sub
            Else
                btnback.Enabled = True
            End If
        Next
    End Sub
    Protected Sub cb4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)
        Dim dt As DataTable
        dt = pSupplier
        dt.DefaultView.RowFilter = ""

        Dim index As Integer = gvPost.DataKeys(gvr.RowIndex).Value

        If pSupplier.Rows(pSupplier.Rows(index)("indexNo"))("BidSecurity_id") = 2 And pSupplier.Rows(pSupplier.Rows(index)("indexNo"))("withOR") = True Then
            btnNext.Enabled = True
        ElseIf pSupplier.Rows(pSupplier.Rows(index)("indexNo"))("BidSecurity_id") = 2 And pSupplier.Rows(pSupplier.Rows(index)("indexNo"))("withOR") = False Then
            btnNext.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Transaction has been succesfully closed.")
        Else
            btnNext.Enabled = True
        End If

        If cb.Checked = True Then
            'Dim a As Integer = pSupplier.Rows(gvr.RowIndex)("indexNo")
            pSupplier.Rows(pSupplier.Rows(index)("indexNo"))("isWinner") = True
            btnback.Enabled = False
            btnNext.Enabled = True
            btnFail.Enabled = False
        Else
            pSupplier.Rows(pSupplier.Rows(index)("indexNo"))("isWinner") = False
            btnback.Enabled = True
            btnNext.Enabled = False
            btnFail.Enabled = True
        End If
    End Sub
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            For i As Integer = 0 To gvPostQualification.Rows.Count - 1
                If CType(gvPostQualification.Rows(i).FindControl("cb3"), CheckBox).Checked = True Then
                    hdr.bid_opening_hdr_id = pSupplier.Rows(i)("bid_opening_hdr_id")
                    hdr.pre_procurement_hdr_id = gvPublic_bidding.SelectedDataKey(0)
                    hdr.Supplier_Id = pSupplier.Rows(i)("Supplier_Id")
                    hdr.amount = pSupplier.Rows(i)("amount")
                    hdr.calculatedAmount = pSupplier.Rows(i)("amount")
                    hdr.examination_bid = pSupplier.Rows(i)("examination_bid")
                    hdr.ceiling_price = pSupplier.Rows(i)("ceiling_price")
                    hdr.isWinner = True
                    hdr.isCalculated = False
                    hdr.update()
                    Exit For
                End If
            Next
            pPublicBidding = Nothing
            pPublicBidding = objDerived.GetDataTable("select * from ams.vw_bid_evaluation", CommandType.Text)
            If pPublicBidding.Rows.Count < 8 Then
                pPublicBidding.Merge(createdatatable(7 - pPublicBidding.Rows.Count))
            End If
            gvPublic_bidding.DataSource = pPublicBidding
            gvPublic_bidding.DataBind()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Transaction has been succesfully closed.")
            objDerived.GetRecords("Update ams.pre_procurement set withWinner =1,resolution_number='" & txtResolutionNumber.Text & "' where pre_procurement_hdr_id=" & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
        Catch ex As Exception

        End Try
    End Sub

End Class
