Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_t_bid_opening
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal
    Private hdr As New t_bid_opening_hdr
    Private dtl As New t_bid_opening_dtl

#Region "Property"
    Private Property pBidOpening() As DataTable
        Get
            Return CType(Session("pBidOpening"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBidOpening") = value
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
            dr("pre_procurement_hdr_id") = DBNull.Value
            dr("obr_evaluation_hdr_id") = DBNull.Value
            dr("isPublicInfra") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
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
        Return count
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                obj.GetAccessRight(Me.Session("@UserName"), Page)
                If obj.HasAccess = False Then
                    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
                End If

                pBidOpening = objDerived.GetDataTable("EXEC [AMS].[sp_BidOpening]", CommandType.Text)
                If pBidOpening.Rows.Count < 5 Then
                    pBidOpening.Merge(CreateTable1(5 - pBidOpening.Rows.Count))
                End If
                grdOpenBid.DataSource = pBidOpening
                grdOpenBid.DataBind()

                gvsupplier.DataSource = Nothing
                gvsupplier.DataBind()

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
    Protected Sub lbApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "close"
    End Sub
    Protected Sub lblAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "add"
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "project_reference_no"
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
                    sumObject = pSupplier.Compute("count(isVisible)", "isVisible=1")
                    pSupplier.Merge(createdatatableSuppliers(7 - sumObject))
                End If
            End If
            gvsupplier.DataSource = pSupplier
            gvsupplier.DataBind()

            For i As Integer = 0 To Me.gvsupplier.Rows.Count - 1
                Dim txt As TextBox = CType(gvsupplier.Rows(i).FindControl("txtamount"), TextBox)
                txt.Attributes.Add("onclick", "this.select()")
                txt.Attributes.Add("onFocus", "this.select()")

            Next
            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(gvsupplier.Rows(0).FindControl("txtamount"), TextBox))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvsupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub lbSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub txtamount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtCost As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtCost.NamingContainer, GridViewRow)
        If txtCost.Text = "" Then
            txtCost.Text = "0.00"
        End If
        txtCost.Text = FormatNumber(txtCost.Text, 2)
        pSupplier.Rows(gvr.RowIndex)("amount") = txtCost.Text


        'CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtBidSecurityAmount"), TextBox).Text = txtCost.Text
         Dim TotalABC = objDerived.GetValue("Select ABC from AMS.pre_procurement where pre_procurement_hdr_id = '" & grdOpenBid.SelectedDatakey("pre_procurement_hdr_id") & "'", CommandType.Text)
        Dim RequiredAmount As Decimal = CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtamount"), TextBox).Text
        Dim SecurityAmount As Decimal = txtCost.Text
        Dim RequiredBID As Decimal = CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtRequiredBid"), TextBox).Text
        'If RequiredAmount > TotalABC Then
        '    CType(gvsupplier.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Insufficient"
        'Else
        '    CType(gvsupplier.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Sufficient"
        'End If
        If RequiredBID > RequiredAmount Then
            CType(gvsupplier.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Insufficient"
        Else
            CType(gvsupplier.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Sufficient"
        End If

        btnsubmit.Enabled = True

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


            RequiredAmount = CType(grdOpenBid.SelectedDataKey("TotalABC"), Decimal) * CType(pBidsecurity.Rows(dd.SelectedIndex)("percentage"), Decimal)

            CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtRequiredBid"), TextBox).Text = FormatNumber(RequiredAmount, 2)
            CType(gvsupplier.Rows(gvr.RowIndex).FindControl("txtBidSecurityAmount"), TextBox).Text = FormatNumber(RequiredAmount, 2)

        Catch ex As Exception
        End Try
    End Sub


    Protected Sub grdOpenBid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        pSupplier = objDerived.GetDataTable("EXEC AMs.sp_post_qualification_dtl '" & grdOpenBid.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        gvsupplier.DataSource = pSupplier
        gvsupplier.DataBind()

        btnsubmit.Enabled = False
        btnReturn.Enabled = True

        If pSupplier.Rows.Count >= 1 Then
            For i As Integer = 0 To Me.gvsupplier.Rows.Count - 1
                Dim dd As DropDownList = CType(gvsupplier.Rows(i).Cells(0).FindControl("ddBid"), DropDownList)
                dd.DataSource = pBidsecurity
                dd.DataTextField = "Description"
                dd.DataValueField = "BidSecurity_id"
                dd.DataBind()
                dd.SelectedIndex = 0

                Dim RequiredAmount As Decimal
                RequiredAmount = CType(grdOpenBid.SelectedDataKey("TotalABC"), Decimal) * CType(pBidsecurity.Rows(dd.SelectedIndex)("percentage"), Decimal)
                CType(gvsupplier.Rows(i).FindControl("txtRequiredBid"), TextBox).Text = FormatNumber(RequiredAmount, 2)
                CType(gvsupplier.Rows(i).FindControl("txtBidSecurityAmount"), TextBox).Text = FormatNumber(RequiredAmount, 2)

                'CType(gvsupplier.Rows(i).FindControl("txtBankName"), TextBox).Attributes.Add("onclick", "this.select()")
                'CType(gvsupplier.Rows(i).FindControl("txtBankName"), TextBox).Attributes.Add("onFocus", "this.select()")
                'CType(gvsupplier.Rows(i).FindControl("txtNumber"), TextBox).Attributes.Add("onclick", "this.select()")
                'CType(gvsupplier.Rows(i).FindControl("txtNumber"), TextBox).Attributes.Add("onFocus", "this.select()")
                'CType(gvsupplier.Rows(i).FindControl("txtValidityPeriod"), TextBox).Attributes.Add("onclick", "this.select()")
                'CType(gvsupplier.Rows(i).FindControl("txtValidityPeriod"), TextBox).Attributes.Add("onFocus", "this.select()")
                'CType(gvsupplier.Rows(i).FindControl("txtBidSecurityAmount"), TextBox).Attributes.Add("onclick", "this.select()")
                'CType(gvsupplier.Rows(i).FindControl("txtBidSecurityAmount"), TextBox).Attributes.Add("onFocus", "this.select()")
                'CType(gvsupplier.Rows(i).FindControl("txtRemarks"), TextBox).Attributes.Add("onclick", "this.select()")
                'CType(gvsupplier.Rows(i).FindControl("txtRemarks"), TextBox).Attributes.Add("onFocus", "this.select()")
                'CType(gvsupplier.Rows(i).FindControl("txtamount"), TextBox).Attributes.Add("onclick", "this.select()")
                'CType(gvsupplier.Rows(i).FindControl("txtamount"), TextBox).Attributes.Add("onFocus", "this.select()")

                ' optimize code
                Dim textBoxes() As String = {"txtBankName", "txtNumber", "txtValidityPeriod", "txtBidSecurityAmount", "txtRemarks", "txtamount"}

                For Each txtBox In textBoxes
                    Dim txtControl As TextBox = CType(gvsupplier.Rows(i).FindControl(txtBox), TextBox)
                    txtControl.Attributes.Add("onclick", "this.select()")
                    txtControl.Attributes.Add("onFocus", "this.select()")
                Next

            Next
        End If
    End Sub

    Protected Sub grdOpenBid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdOpenBid.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdOpenBid, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdOpenBid_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pBidOpening = objDerived.GetDataTable("EXEC [AMS].[sp_BidOpening]", CommandType.Text)
        If pBidOpening.Rows.Count < 5 Then
            pBidOpening.Merge(CreateTable1(5 - pBidOpening.Rows.Count))
        End If
        grdOpenBid.PageIndex = e.NewPageIndex
        grdOpenBid.DataSource = pBidOpening
        grdOpenBid.DataBind()

    End Sub

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        'Try


        Dim test As Integer = 0

        For i As Integer = 0 To Me.gvsupplier.Rows.Count - 1
            Dim BID_ID As Integer = objDerived.GetValue("SELECT [bid_opening_hdr_id] FROM [AMS].[bid_opening_hdr] WHERE [pre_procurement_hdr_id] = '" & grdOpenBid.SelectedDataKey("pre_procurement_hdr_id") & "' AND [Supplier_Id] = '" & pSupplier.Rows(i)("Supplier_ID") & "'", CommandType.Text)
            Dim TotalABC = objDerived.GetValue("Select ABC from AMS.pre_procurement where pre_procurement_hdr_id = '" & grdOpenBid.SelectedDatakey("pre_procurement_hdr_id") & "'", CommandType.Text)
            'If pSupplier.Rows(i)("amount") > TotalABC Then

            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Total Bid Amount exceeds the value of Total ABC.")
            '    '=== SAVE BID OPENING
            'Else


            hndValue1.Value = CType(gvsupplier.Rows(i).FindControl("txtRequiredBid"), TextBox).Text
            hndValue2.Value = CType(gvsupplier.Rows(i).FindControl("txtamount"), TextBox).Text
            Dim A As Double = hndValue1.Value.Replace(",", "")
            Dim B As Double = hndValue2.Value.Replace(",", "")

            If A > B Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Total bid amount is lower than the request bid security!")
            Else
                hdr.pre_procurement_hdr_id = grdOpenBid.SelectedDataKey("pre_procurement_hdr_id")
                hdr.Supplier_Id = pSupplier.Rows(i)("Supplier_ID")
                hdr.amount = pSupplier.Rows(i)("amount")
                hdr.calculatedAmount = pSupplier.Rows(i)("amount")
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
                hdr.status = CType(gvsupplier.Rows(i).FindControl("lblStatus"), Label).Text
                hdr.withOR = False
                If CType(gvsupplier.Rows(i).FindControl("lblStatus"), Label).Text = "Sufficient" Then

                    test = test + 1
                    If BID_ID = 0 Then
                        hdr.save()
                    Else
                        hdr.bid_opening_hdr_id = BID_ID
                        hdr.update()
                    End If

                End If
            End If



            'End If
        Next
        If test = (Me.gvsupplier.Rows.Count) Then

            objDerived.GetRecords("UPDATE AMS.pre_procurement SET withBid =1 WHERE pre_procurement_hdr_id = '" & grdOpenBid.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully saved.")
            btnsubmit.Enabled = False
            pBidOpening = objDerived.GetDataTable("EXEC [AMS].[sp_BidOpening]", CommandType.Text)
            If pBidOpening.Rows.Count < 5 Then
                pBidOpening.Merge(CreateTable1(5 - pBidOpening.Rows.Count))
            End If

            grdOpenBid.DataSource = pBidOpening
            grdOpenBid.DataBind()

            gvsupplier.DataSource = Nothing
            gvsupplier.DataBind()
        End If
        'Catch ex As Exception
        'End Try


    End Sub
    Protected Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click

        objDerived.GetRecords("UPDATE [AMS].[pre_procurement] SET [obr_evaluation_hdr_id] = 0 WHERE [pre_procurement_hdr_id] = '" & grdOpenBid.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE [AMS].[pre_procurement_dtl] SET [obr_evaluation_dtl_id] = 0 WHERE [pre_procurement_hdr_id] = '" & grdOpenBid.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully returned.")


        pBidOpening = objDerived.GetDataTable("EXEC [AMS].[sp_BidOpening]", CommandType.Text)
        If pBidOpening.Rows.Count < 5 Then
            pBidOpening.Merge(CreateTable1(5 - pBidOpening.Rows.Count))
        End If
        grdOpenBid.DataSource = pBidOpening
        grdOpenBid.DataBind()

        gvsupplier.DataSource = Nothing
        gvsupplier.DataBind()

    End Sub
End Class
