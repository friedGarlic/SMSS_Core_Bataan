Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class t_bid_opening
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal
    Private hdr As New t_bid_opening_hdr
    Private dtl As New t_bid_opening_dtl

#Region "Property"


    Private Property pGoodsPerSupplier(ByVal supplier_id As String) As DataTable
        Get
            Return CType(Session(supplier_id), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session(supplier_id) = value
        End Set
    End Property
    Private Property pBidsecurity() As DataTable
        Get
            Return CType(Session("pBidsecurity"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBidsecurity") = value
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
        dt.Columns.Add("Supplier_ID", GetType(Long))
        dt.Columns.Add("SuppName")
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        dt.Columns.Add("bank")
        dt.Columns.Add("number")
        dt.Columns.Add("validityPeriod", GetType(Integer))
        dt.Columns.Add("requiredBid_security", GetType(Decimal))
        dt.Columns.Add("Bid_security", GetType(Decimal))
        dt.Columns.Add("status")
        dt.Columns.Add("remarks")


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Supplier_ID") = 0
            dr("SuppName") = ""
            dr("amount") = "0.00"
            dr("isVisible") = False

            dr("bank") = ""
            dr("number") = ""
            dr("validityPeriod") = 0
            dr("requiredBid_security") = "0.00"
            dr("Bid_security") = "0.00"
            dr("status") = ""
            dr("remarks") = ""


            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region
    Public Function countSupplier() As Integer
        Dim count As Integer
        For i As Integer = 0 To Me.gvsupplier.Rows.Count - 1
            If CType(gvsupplier.Rows(i).FindControl("txtamount"), TextBox).Text = "0.00" Then
                count = count + 1
            End If
        Next
        'ConfirmButtonExtender1.ConfirmText = "their are"
        Return count
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                obj.GetAccessRight(Me.Session("@UserName"), Page)
                If obj.HasAccess = False Then
                    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
                End If
                pPublicBidding = objDerived.GetDataTable("select * from ams.vw_bid_opening", CommandType.Text)
                If pPublicBidding.Rows.Count < 8 Then
                    pPublicBidding.Merge(createdatatable(7 - pPublicBidding.Rows.Count))
                End If
                gvPublic_bidding.DataSource = pPublicBidding
                gvPublic_bidding.DataBind()

                pSupplier = Nothing
                pTempSupplier = Nothing
                btnFail.Enabled = False
                For i As Integer = 0 To gvPublic_bidding.Rows.Count - 1
                    If gvPublic_bidding.Rows(i).Cells(2).Text = "0" Then
                        gvPublic_bidding.Rows(i).Cells(2).Text = ""
                    End If
                Next
                pBidsecurity = objDerived.GetDataTable("select * from ams.BidSecurity", CommandType.Text)
            Else
                If countSupplier() = 0 Then
                    ConfirmButtonExtender1.ConfirmText = "Are you sure you want to save this transaction?"
                Else
                    ConfirmButtonExtender1.ConfirmText = countSupplier.ToString & "  Bidder(s) has no bid amount." & vbCrLf & " This Bidder(s) will not be included on the preliminary examination." & vbCrLf & "Are you sure you want to save this transaction?"
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnFail_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Failure of bidding has been confirmed.")

        Session("isPublicInfra") = gvPublic_bidding.SelectedDataKey("isPublicInfra")
        Session("pre_procurement_hdr_id") = gvPublic_bidding.SelectedDataKey("pre_procurement_hdr_id")
        Me.Page.Response.Redirect("~/bidding/rpt_failure_bidding.aspx")


        objDerived.GetRecords("Delete  from  AMS.pre_procurement where pre_procurement_hdr_id =  " & gvPublic_bidding.SelectedDataKey("pre_procurement_hdr_id") & "", CommandType.Text)
        objDerived.GetRecords("Delete  from  AMS.pre_procurement_dtl where pre_procurement_hdr_id =  " & gvPublic_bidding.SelectedDataKey("pre_procurement_hdr_id") & "", CommandType.Text)
        objDerived.GetRecords("Update AMS.obr_evaluation_dtl set withPreProcurement=0 where obr_evaluation_hdr_id =  " & gvPublic_bidding.SelectedDataKey("obr_evaluation_hdr_id") & "", CommandType.Text)

        'pPublicBidding = objDerived.GetDataTable("select * from ams.vw_bid_opening", CommandType.Text)
        'If pPublicBidding.Rows.Count < 8 Then
        '    pPublicBidding.Merge(createdatatable(7 - pPublicBidding.Rows.Count))
        'End If
        'gvPublic_bidding.DataSource = pPublicBidding
        'gvPublic_bidding.DataBind()
    End Sub
    Protected Sub lbApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "close"
    End Sub
    Protected Sub lblAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "add"
    End Sub
    Protected Sub gvPublic_bidding_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If Lbtn = "project_reference_no" Then
            ''Disable 01/21/2014 
            'Me.cpe1.Collapsed = True
            'Me.cpe1.ClientState = True
            'Me.cpe2.Collapsed = False
            'Me.cpe2.ClientState = False

            pSupplier = objDerived.GetDataTable("exec ams.sp_post_qualification_dtl " & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)

            'pTempSupplier = objDerived.GetDataTable("exec ams.sp_supplier_per_bid " & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
            'If pSupplier.Rows.Count < 8 Then
            '    pSupplier.Merge(createdatatableSuppliers(7 - pSupplier.Rows.Count))
            'End If
            gvsupplier.DataSource = pSupplier
            gvsupplier.DataBind()

            btnsubmit.Enabled = False
            If gvPublic_bidding.SelectedDataKey(2) = 0 Then
                btnFail.Enabled = True
            Else
                btnFail.Enabled = False
            End If

            If pSupplier.Rows.Count >= 1 Then
                For i As Integer = 0 To Me.gvsupplier.Rows.Count - 1

                    Dim dd As DropDownList = CType(gvsupplier.Rows(i).Cells(0).FindControl("ddBid"), DropDownList)
                    dd.DataSource = pBidsecurity
                    dd.DataTextField = "Description"
                    dd.DataValueField = "BidSecurity_id"
                    dd.DataBind()
                    dd.SelectedIndex = 0
                    Dim RequiredAmount As Decimal
                    RequiredAmount = CType(gvPublic_bidding.SelectedDataKey(1), Decimal) * CType(pBidsecurity.Rows(dd.SelectedIndex)("percentage"), Decimal)
                    CType(gvsupplier.Rows(i).FindControl("txtRequiredBid"), TextBox).Text = FormatNumber(RequiredAmount, 2)

                    CType(gvsupplier.Rows(i).FindControl("txtBankName"), TextBox).Attributes.Add("onclick", "this.select()")
                    CType(gvsupplier.Rows(i).FindControl("txtBankName"), TextBox).Attributes.Add("onFocus", "this.select()")
                    CType(gvsupplier.Rows(i).FindControl("txtNumber"), TextBox).Attributes.Add("onclick", "this.select()")
                    CType(gvsupplier.Rows(i).FindControl("txtNumber"), TextBox).Attributes.Add("onFocus", "this.select()")
                    CType(gvsupplier.Rows(i).FindControl("txtValidityPeriod"), TextBox).Attributes.Add("onclick", "this.select()")
                    CType(gvsupplier.Rows(i).FindControl("txtValidityPeriod"), TextBox).Attributes.Add("onFocus", "this.select()")
                    CType(gvsupplier.Rows(i).FindControl("txtBidSecurityAmount"), TextBox).Attributes.Add("onclick", "this.select()")
                    CType(gvsupplier.Rows(i).FindControl("txtBidSecurityAmount"), TextBox).Attributes.Add("onFocus", "this.select()")
                    CType(gvsupplier.Rows(i).FindControl("txtRemarks"), TextBox).Attributes.Add("onclick", "this.select()")
                    CType(gvsupplier.Rows(i).FindControl("txtRemarks"), TextBox).Attributes.Add("onFocus", "this.select()")
                    CType(gvsupplier.Rows(i).FindControl("txtamount"), TextBox).Attributes.Add("onclick", "this.select()")
                    CType(gvsupplier.Rows(i).FindControl("txtamount"), TextBox).Attributes.Add("onFocus", "this.select()")
                Next
                '     ScriptManager.GetCurrent(Me.Page).SetFocus(CType(gvsupplier.Rows(0).FindControl("txtBankName"), TextBox))
            End If
        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "project_reference_no"
    End Sub
    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            '  MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, countSupplier().ToString)
            For i As Integer = 0 To Me.gvsupplier.Rows.Count - 1
                If pSupplier.Rows(i)("Supplier_ID") <> 0 Or pSupplier.Rows(i)("amount") <> "0.00" Then
                    hdr.pre_procurement_hdr_id = gvPublic_bidding.SelectedDataKey(0)
                    hdr.Supplier_Id = pSupplier.Rows(i)("Supplier_Id")
                    hdr.amount = pSupplier.Rows(i)("amount")
                    ' hdr.calculatedAmount = pSupplier.Rows(i)("amount")
                    hdr.examination_bid = False
                    hdr.ceiling_price = False
                    hdr.isPostQualification = False
                    hdr.isWinner = False
                    hdr.isCalculated = False
                    hdr.BidSecurity_id = CType(gvsupplier.Rows(i).FindControl("ddBid"), DropDownList).SelectedItem.Value
                    hdr.BankName = CType(gvsupplier.Rows(i).FindControl("txtBankName"), TextBox).Text
                    hdr.Number = CType(gvsupplier.Rows(i).FindControl("txtNumber"), TextBox).Text
                    hdr.ValidityPeriod = CType(gvsupplier.Rows(i).FindControl("txtValidityPeriod"), TextBox).Text
                    hdr.BidSecurityAmount = FormatCurrency(CType(gvsupplier.Rows(i).FindControl("txtBidSecurityAmount"), TextBox).Text, 2)
                    hdr.remarks = CType(gvsupplier.Rows(i).FindControl("txtRemarks"), TextBox).Text
                    hdr.status = gvsupplier.Rows(i).Cells(2).Text
                    hdr.withOR = False
                    'hdr.ORI
                    hdr.save()
                End If

            Next



            objDerived.GetRecords("Update ams.pre_procurement set withBid =1 where pre_procurement_hdr_id=" & gvPublic_bidding.SelectedDataKey(0) & "", CommandType.Text)
            pPublicBidding = objDerived.GetDataTable("select * from ams.vw_bid_opening", CommandType.Text)
            If pPublicBidding.Rows.Count < 8 Then
                pPublicBidding.Merge(createdatatable(7 - pPublicBidding.Rows.Count))
            End If
            gvPublic_bidding.DataSource = pPublicBidding
            gvPublic_bidding.DataBind()
            gvPublic_bidding.SelectedIndex = -1

            ''Disable 01/21/2014
            'Me.cpe1.Collapsed = False
            'Me.cpe1.ClientState = False
            'Me.cpe2.Collapsed = True
            'Me.cpe2.ClientState = True

            'ddSupplier.Items.Clear()
            'ddSupplier.Enabled = False
            'btnsupplier.Enabled = False
            pSupplier = Nothing
            pTempSupplier = Nothing
            gvsupplier.DataSource = Nothing
            gvsupplier.DataBind()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, "Transaction has been succesfully saved.")
            btnsubmit.Enabled = False

            For i As Integer = 0 To gvPublic_bidding.Rows.Count - 1
                If gvPublic_bidding.Rows(i).Cells(2).Text = "0" Then
                    gvPublic_bidding.Rows(i).Cells(2).Text = ""
                End If
            Next
        Catch ex As Exception

        End Try
        btnsubmit.Enabled = False
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
            Dim txt As TextBox = CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtamount"), TextBox)
            If pSupplier.Compute("SUM(amount)", "") = "0.00" Then
                btnsubmit.Enabled = False
            Else
                btnsubmit.Enabled = True
            End If
            txt.Attributes.Add("onclick", "this.select()")
            txt.Attributes.Add("onFocus", "this.select()")
            'ScriptManager.GetCurrent(Me.Page).SetFocus(txt)

            '[ ConfirmButtonExtender1.ConfirmText = countSupplier.ToString & "  Bidder(s) has no bid amount." & vbCrLf & " This Bidder(s) will not be included on the preliminary examination." & vbCrLf & "Are you sure you want to save this transaction?"
            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtRemarks"), TextBox))



        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtBidSecurityAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtCost As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtCost.NamingContainer, GridViewRow)
            If txtCost.Text = "" Then
                txtCost.Text = "0.00"
            End If
            txtCost.Text = FormatNumber(txtCost.Text, 2)

            If CType(txtCost.Text, Decimal) >= CType(CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtRequiredBid"), TextBox).Text, Decimal) Then
                gvsupplier.Rows(gvr.RowIndex).Cells(2).Text = "Sufficient"
                gvsupplier.Rows(gvr.RowIndex).Cells(2).ForeColor = Drawing.Color.Black
            Else
                gvsupplier.Rows(gvr.RowIndex).Cells(2).Text = "Insufficient"
                gvsupplier.Rows(gvr.RowIndex).Cells(2).ForeColor = Drawing.Color.Red
            End If


            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtamount"), TextBox))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtBankName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtBankName As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtBankName.NamingContainer, GridViewRow)
            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtNumber"), TextBox))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtBankName As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtBankName.NamingContainer, GridViewRow)
            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtValidityPeriod"), TextBox))

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub txtValidityPeriod_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtBankName As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtBankName.NamingContainer, GridViewRow)
            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtBidSecurityAmount"), TextBox))

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub txtRemarks_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtBankName As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtBankName.NamingContainer, GridViewRow)
            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(gvsupplier.Rows(gvr.RowIndex + 1).FindControl("txtBankName"), TextBox))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddBid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim dd As DropDownList = TryCast(sender, DropDownList)
           
            Dim gvr As GridViewRow = TryCast(dd.NamingContainer, GridViewRow)
            Dim a As Integer = gvr.RowIndex
            Dim RequiredAmount As Decimal
            RequiredAmount = CType(gvPublic_bidding.SelectedDataKey(1), Decimal) * CType(pBidsecurity.Rows(dd.SelectedIndex)("percentage"), Decimal)
            CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtRequiredBid"), TextBox).Text = FormatNumber(RequiredAmount, 2)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnResolutionNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Evaluation_Hdr") = gvPublic_bidding.SelectedDataKey("obr_evaluation_hdr_id")

        If txtResolutionNumber.Text = "" Then
            lblrequiredField.Visible = True
        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Failure of bidding has been confirmed.")

            Session("ResolutionNumber") = txtResolutionNumber.Text
            Session("isPublicInfra") = gvPublic_bidding.SelectedDataKey("isPublicInfra")
            Session("pre_procurement_hdr_id") = gvPublic_bidding.SelectedDataKey("pre_procurement_hdr_id")
            Me.Page.Response.Redirect("~/bidding/rpt_failure_bidding.aspx")

        End If
        ModalPopupExtender3.Show()
    End Sub
End Class
