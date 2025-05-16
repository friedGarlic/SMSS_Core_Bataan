Imports System.Data

Partial Class Inventory_Disposal_Disposal_Quotation
    Inherits System.Web.UI.Page
    Protected objDerived As New DerivedDal
    Dim obj As New AccessRule

    Public Function tempQuotation(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("IsspHdr_ID", GetType(Long))
        dt.Columns.Add("BidType", GetType(Integer))
        dt.Columns.Add("Issp_Date", GetType(Date))
        dt.Columns.Add("Issp_No", GetType(String))
        dt.Columns.Add("MinBid_Amt", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("IsspHdr_ID") = DBNull.Value
            dr("BidType") = DBNull.Value
            dr("Issp_Date") = DBNull.Value
            dr("Issp_No") = DBNull.Value
            dr("MinBid_Amt") = DBNull.Value
            dr("isVisible") = False

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Property BidType() As String
        Get
            Return CType(Session("BidType"), String)
        End Get
        Set(ByVal value As String)
            Session("BidType") = value
        End Set
    End Property

    Protected Property dtQuotation() As DataTable
        Get
            Return CType(Session("dtQuotation"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtQuotation") = value
        End Set
    End Property

    Protected Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
        End Set
    End Property

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub Inventory_Disposal_Disposal_Quotation_Load(sender As Object, e As EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        End If

        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToShortDateString

            LoadPage()

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
        drpBidder.Attributes.Add("onChange", "StartProgressBar();")
        drpBidBond.Attributes.Add("onChange", "StartProgressBar();")

    End Sub

    Protected Sub LoadPage()
        dtQuotation = objDerived.GetDataTable("SELECT IsspHdr_ID, Issp_Date, Issp_No, MinBid_Amt, ISNULL(BidType,0) AS BidType, 0 AS BidCnt, CONVERT(BIT, 1) AS isVisible FROM AMS.tbl_ISSP_hdr WHERE ISNULL(isClose,0) = 1 AND ISNULL(withQuotation,0) = 0 ORDER BY Issp_Date DESC, Issp_No DESC", CommandType.Text)
        If dtQuotation.Rows.Count < 5 Then
            dtQuotation.Merge(tempQuotation(4 - dtQuotation.Rows.Count))
        End If
        grdQuotation.DataSource = dtQuotation
        grdQuotation.DataBind()

        grdItems.DataSource = Nothing
        grdItems.DataBind()

        'drpBidType.SelectedValue = 0
        drpBidType.Enabled = False
        btnOK.Enabled = False
        drpBidder.Enabled = False

        grdBidders.DataSource = Nothing
        grdBidders.DataBind()



        txtBidBondAmt.Text = "0.00"
        txtTotalBidAmount.Text = "0.00"

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim myview As DataView
        myview = dtQuotation.DefaultView
        myview.RowFilter = "Issp_No like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        grdQuotation.DataSource = myview
        grdQuotation.DataBind()

    End Sub

    Protected Sub LoadItems()
        dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_Disposal_ForQuotationList] '" & grdQuotation.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)
        grdItems.DataSource = dtItems
        grdItems.DataBind()

        drpBidder.DataSource = objDerived.GetDataTable("SELECT A.Supplier_Id, B.SuppName, A.op1_Amt FROM AMS.tbl_ISSP_InterestedBidder AS A " &
                                        " INNER JOIN DBO.Supplier AS B ON A.Supplier_Id = B.Supplier_Id WHERE isPaid = 1 AND A.IsspHdr_ID = '" & Session("IsspHdr_ID") & "' ORDER BY B.SuppName", CommandType.Text)
        drpBidder.DataTextField = "SuppName"
        drpBidder.DataValueField = "Supplier_Id"
        drpBidder.DataBind()
        drpBidder.Items.Insert(0, "Select")
        drpBidder.Enabled = True

    End Sub

    Protected Sub grdQuotation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdQuotation.SelectedIndexChanged
        Try
            Session("IsspHdr_ID") = grdQuotation.SelectedDataKey("IsspHdr_ID")

            LoadItems()


            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT ROW_NUMBER() OVER(ORDER BY B.SuppName) AS ID, ISNULL(B.SuppName,'') AS SuppName, ISNULL(A.TotalBidAmt,0) AS TotalBidAmt, A.QuotationHdr_ID, ISNULL(A.Supplier_ID,0) AS Supplier_ID, CONVERT(BIT, 1) AS isVisible " &
                                    " FROM AMS.tbl_QuotationHdr AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id WHERE A.IsspHdr_ID = '" & grdQuotation.SelectedDataKey("IsspHdr_ID") & "' ORDER BY SuppName", CommandType.Text)

            grdBidders.DataSource = dt
            grdBidders.DataBind()

            If grdBidders.Rows.Count > 0 Then
                btnClose.Enabled = True
                btnpreviewBid.Enabled = True
            Else
                btnClose.Enabled = False
                btnpreviewBid.Enabled = False
            End If

            objDerived.Execute("UPDATE AMS.tbl_ISSP_hdr SET BidType = '" & drpBidType.SelectedItem.Value & "' WHERE IsspHdr_ID = '" & grdQuotation.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)

            Session("BidType") = drpBidType.SelectedItem.Value

            drpBidType.Enabled = False
            btnOK.Enabled = False


            btnSave.Enabled = True


            'drpBidType.SelectedValue = grdQuotation.SelectedDataKey("BidType")
            Session("BidType") = drpBidType.SelectedValue

            If drpBidType.SelectedItem.Text = "Select" Then
                drpBidType.Enabled = True
                btnOK.Enabled = True

                drpBidder.Items.Clear()
                drpBidder.Items.Insert(0, "Select")

                drpBidder.Enabled = False
            Else
                drpBidType.Enabled = False
                btnOK.Enabled = False

                drpBidder.Enabled = True
            End If

            If drpBidType.SelectedValue = 1 Then
                txtTotalBidAmount.Enabled = False

                For i As Integer = 0 To grdItems.Rows.Count - 1
                    CType(grdItems.Rows(i).Cells(5).FindControl("txtBidAmount"), TextBox).Enabled = True
                Next

            ElseIf drpBidType.SelectedValue = 2 Then

                txtTotalBidAmount.Enabled = True

            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Protected Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If drpBidType.SelectedItem.Value <> 0 Then
                objDerived.Execute("UPDATE AMS.tbl_ISSP_hdr SET BidType = '" & drpBidType.SelectedItem.Value & "' WHERE IsspHdr_ID = '" & grdQuotation.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)

                Session("BidType") = drpBidType.SelectedItem.Value

                drpBidType.Enabled = False
                btnOK.Enabled = False

                drpBidder.DataSource = objDerived.GetDataTable("SELECT Supplier_Id, SuppName FROM DBO.Supplier ORDER BY SuppName", CommandType.Text)
                drpBidder.DataTextField = "SuppName"
                drpBidder.DataValueField = "Supplier_Id"
                drpBidder.DataBind()
                drpBidder.Items.Insert(0, "Select")

                drpBidder.Enabled = True
                btnSave.Enabled = True

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Bid type has been successfully set.")
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select bid type from the dropdown.")

            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Protected Sub drpBidder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpBidder.SelectedIndexChanged
        Try

            If drpBidType.SelectedValue = 1 Then
                txtTotalBidAmount.Enabled = False

                For i As Integer = 0 To grdItems.Rows.Count - 1
                    CType(grdItems.Rows(i).Cells(5).FindControl("txtBidAmount"), TextBox).Enabled = True
                Next

            ElseIf drpBidType.SelectedValue = 2 Then
                txtTotalBidAmount.Enabled = True

            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")

            End If

            btnSave.Enabled = True
            drpBidBond.Enabled = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Protected Sub drpBidBond_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpBidBond.SelectedIndexChanged
        txtBidBondAmt.Text = FormatNumber((txtTotalBidAmount.Text * 0.1), 2)
    End Sub
    Protected Sub txtTotalBidAmount_TextChanged(sender As Object, e As EventArgs) Handles txtTotalBidAmount.TextChanged
        txtTotalBidAmount.Text = FormatNumber(txtTotalBidAmount.Text, 2)
        txtBidBondAmt.Text = FormatNumber((txtTotalBidAmount.Text * 0.1), 2)
    End Sub
    Protected Sub txtBidAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim total As Decimal = 0
        For i As Integer = 0 To grdItems.Rows.Count - 1
            CType(grdItems.Rows(i).Cells(5).FindControl("txtBidAmount"), TextBox).Text = FormatNumber(CType(grdItems.Rows(i).Cells(5).FindControl("txtBidAmount"), TextBox).Text, 2)
            total = total + CType(grdItems.Rows(i).Cells(5).FindControl("txtBidAmount"), TextBox).Text
        Next

        txtTotalBidAmount.Text = FormatNumber(total, 2)
        txtBidBondAmt.Text = FormatNumber(txtTotalBidAmount.Text * 0.1, 2)

    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If drpBidder.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select bidder.")
                Exit Sub

            ElseIf CType(txtTotalBidAmount.Text, Decimal) = 0 Then


            ElseIf CType(grdQuotation.SelectedDataKey("MinBid_Amt"), Decimal) > CType(txtTotalBidAmount.Text, Decimal) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Bid amount is lower than the minimum bid amount.")
                Exit Sub

            End If

            If drpBidType.SelectedValue = 1 Then
                For i As Integer = 0 To grdItems.Rows.Count - 1
                    If CType(grdItems.Rows(i).Cells(5).FindControl("txtBidAmount"), TextBox).Text = "0.00" Or CType(grdItems.Rows(i).Cells(5).FindControl("txtBidAmount"), TextBox).Text = "" Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Input all bid amount per item.")
                        Exit Sub
                    End If
                Next

            ElseIf drpBidType.SelectedValue = 2 Then
                If txtTotalBidAmount.Text = "" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Input total bid amount.")
                    Exit Sub
                End If
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
                Exit Sub
            End If

            Dim hdrid As Integer = objDerived.GetValue("SELECT QuotationHdr_ID FROM AMS.tbl_QuotationHdr WHERE IsspHdr_ID = '" & grdQuotation.SelectedDataKey("IsspHdr_ID") & "' AND Supplier_ID = '" & drpBidder.SelectedItem.Value & "'", CommandType.Text)
            If hdrid = 0 Then
                objDerived.Execute("INSERT INTO [AMS].[tbl_QuotationHdr] ([QuotationDate],[IsspHdr_ID],[Supplier_ID],[TotalBidAmt],[BidBond],[BidBondAmt],[isWinner],[UserID]) " &
                                   " VALUES ('" & txtDate.Text & "','" & grdQuotation.SelectedDataKey("IsspHdr_ID") & "','" & drpBidder.SelectedItem.Value & "','" & CType(txtTotalBidAmount.Text, Decimal) & "', " &
                                   " '" & drpBidBond.SelectedItem.Text & "','" & CType(txtBidBondAmt.Text, Decimal) & "', 0,'" & Session("@UserName") & "')", CommandType.Text)

                Session("hdrid") = objDerived.GetValue("SELECT TOP(1) QuotationHdr_ID FROM AMS.tbl_QuotationHdr ORDER BY QuotationHdr_ID DESC", CommandType.Text)

                For i As Integer = 0 To grdItems.Rows.Count - 1
                    objDerived.Execute("INSERT INTO [AMS].[tbl_QuotationDtl] ([QuotationHdr_ID],[IIRUPHdr_ID],[Item_ID],[Property_No],[BidAmt],[WMHdr_ID]) " &
                                    " VALUES('" & Session("hdrid") & "','" _
                                    & dtItems.Rows(i)("IIRUPHdr_ID") & "','" _
                                    & dtItems.Rows(i)("Item_ID") & "','" _
                                    & dtItems.Rows(i)("PropertyNo") & "','" _
                                    & CType(CType(grdItems.Rows(i).Cells(5).FindControl("txtBidAmount"), TextBox).Text, Decimal) & "','" _
                                    & dtItems.Rows(i)("WMHdr_ID") & "')", CommandType.Text)
                Next

            Else
                objDerived.Execute("UPDATE AMS.tbl_QuotationHdr SET TotalBidAmt='" & CType(txtTotalBidAmount.Text, Decimal) & "', BidBond = '" & drpBidBond.SelectedItem.Text & "', BidBondAmt = '" & CType(txtBidBondAmt.Text, Decimal) & "' WHERE QuotationHdr_ID = '" & hdrid & "'", CommandType.Text)

            End If

            Session("SuppName") = drpBidder.SelectedItem.Text
            Session("Amount") = txtBidBondAmt.Text

            btnpreviewBid.Enabled = True
            btnGenOP.Enabled = True

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT ROW_NUMBER() OVER(ORDER BY B.SuppName) AS ID, ISNULL(B.SuppName,'') AS SuppName, ISNULL(A.TotalBidAmt,0) AS TotalBidAmt, A.QuotationHdr_ID, ISNULL(A.Supplier_ID,0) AS Supplier_ID, CONVERT(BIT, 1) AS isVisible " &
                                    " FROM AMS.tbl_QuotationHdr AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id WHERE A.IsspHdr_ID = '" & grdQuotation.SelectedDataKey("IsspHdr_ID") & "' ORDER BY SuppName", CommandType.Text)

            grdBidders.DataSource = dt
            grdBidders.DataBind()


            txtBidBondAmt.Text = "0.00"
            txtTotalBidAmount.Text = "0.00"


            LoadItems()

            btnSave.Enabled = False
            btnClose.Enabled = True


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        objDerived.Execute("UPDATE AMS.tbl_ISSP_hdr SET withQuotation = 1 WHERE IsspHdr_ID = '" & grdQuotation.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully close.")
        LoadPage()

    End Sub
    Protected Sub btnpreviewBid_Click(sender As Object, e As EventArgs) Handles btnpreviewBid.Click
        Me.ModalPopupExtender99.Show()
        popupBidrpt.Visible = True
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Me.Page.Response.Redirect("~/Inventory/Disposal/rpt_BidderAttendance.aspx")

    End Sub

    Protected Sub btnGenOP_Click(sender As Object, e As EventArgs) Handles btnGenOP.Click
        Session("Page") = "Quotation"

        Dim url As String = "rpt_order_of_payment.aspx?"
        Dim fullURL As String = "var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        'Me.Page.Response.Redirect("~/Inventory/Disposal/rpt_order_of_payment.aspx")

    End Sub

    Protected Sub btnAddBid_Click(sender As Object, e As EventArgs) Handles btnAddBid.Click
        txtDateBid.Text = Date.Today.ToShortDateString
        LoadTextFields_Enable()
        btnSaveBid.Enabled = True
        ModalPopupExtenderz.Show()

    End Sub

    Protected Sub LoadTextFields_Enable()
        txtcompany.Enabled = True
        txtadd1.Enabled = True
        txtofficeno.Enabled = True
        txtfaxno.Enabled = True
        ddtax.Enabled = True
        txttin.Enabled = True
        txtPS.Enabled = True
        drpOwnershipType.Enabled = True

        txtRep1_Name.Enabled = True
        txtRep1_Position.Enabled = True
        txtRep1_Address.Enabled = True
        txtRep1_Contact.Enabled = True
        txtRep2_Name.Enabled = True
        txtRep2_Position.Enabled = True
        txtRep2_Address.Enabled = True
        txtRep2_Contact.Enabled = True
        txtRep3_Name.Enabled = True
        txtRep3_Position.Enabled = True
        txtRep3_Address.Enabled = True
        txtRep3_Contact.Enabled = True

        txtSupplierNo.Enabled = True
        txtYearNo.Enabled = True
        txtMOA.Enabled = True
        txtPermit.Enabled = True
        txtTaxClearance.Enabled = True
        txtPhilGeps.Enabled = True
        txtFDAAccreditation.Enabled = True
        txtPCAB.Enabled = True
        txtPCAB_Category.Enabled = True

        txtMOAExpiry.Enabled = True
        txtPermitExpiry.Enabled = True
        txtTaxClearanceExpiry.Enabled = True
        txtPhilGeps_Expiry.Enabled = True
        txtFDAAccreditationExpiry.Enabled = True

    End Sub

    Protected Sub btnSaveBid_Click(sender As Object, e As EventArgs) Handles btnSaveBid.Click

        'Try
        objDerived.Execute("INSERT INTO dbo.Supplier (SuppName,Address1,Officeno,Faxno,TaxType, " &
        "TIN,ProductService,ContactP,RepPosition,Address2, " &
        "contactno,Representative2,Representative2_Pos, Representative2_Address, Representative2_Contact, " &
        "Representative3, Representative3_Pos, Representative3_Address, Representative3_Contact, " &
        "SupplierNo, YearNo, MOA, Permit, TaxClearance, PhilGeps, FDAAccreditation, PCABLicense, PCAB_Category, MOA_Expiry, " &
        "Permit_Expiry, TaxClearance_Epiry, PhilGeps_Expiry, FDA_Expiry) " &
        "VALUES ( '" & txtcompany.Text & "','" & txtadd1.Text & "','" & txtofficeno.Text & "','" & txtfaxno.Text & "','" & ddtax.SelectedItem.Text & "', " &
        "'" & txttin.Text & "','" & txtPS.Text & "','" & txtRep1_Name.Text & "','" & txtRep1_Position.Text & "','" & txtRep1_Address.Text & "', " &
        "'" & txtRep1_Contact.Text & "','" & txtRep2_Name.Text & "','" & txtRep2_Position.Text & "','" & txtRep2_Address.Text & "','" & txtRep2_Contact.Text & "', " &
        "'" & txtRep3_Name.Text & "','" & txtRep3_Position.Text & "','" & txtRep3_Address.Text & "','" & txtRep3_Contact.Text & "','" & txtSupplierNo.Text & "', " &
             "'" & txtYearNo.Text & "','" & txtMOA.Text & "','" & txtPermit.Text & "','" & txtTaxClearance.Text & "','" & txtPhilGeps.Text & "', " &
             "'" & txtFDAAccreditation.Text & "','" & txtPCAB.Text & "','" & txtPCAB_Category.Text & "','" & IIf(txtMOAExpiry.Text = "", "01/01/1900", txtMOAExpiry.Text) & "', " &
             "'" & IIf(txtPermitExpiry.Text = "", "01/01/1900", txtPermitExpiry.Text) & "','" & IIf(txtTaxClearanceExpiry.Text = "", "01/01/1900", txtTaxClearanceExpiry.Text) & "', " &
             "'" & IIf(txtPhilGeps_Expiry.Text = "", "01/01/1900", txtPhilGeps_Expiry.Text) & "','" & IIf(txtFDAAccreditationExpiry.Text = "", "01/01/1900", txtFDAAccreditationExpiry.Text) & "')", CommandType.Text)

        Dim Supp_ID As Integer = objDerived.Execute("SELECT DISTINCT TOP 1 Supplier_Id FROM DBO.Supplier ORDER BY Supplier_Id DESC", CommandType.Text)

        objDerived.Execute("UPDATE DBO.Supplier SET OwnershipType = '" & drpOwnershipType.SelectedItem.Text & "' WHERE Supplier_Id = '" & Supp_ID & "'", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        'Catch ex As Exception

        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        'End Try
    End Sub

    Public Sub txtBidBondAmt_TextChanged(sender As Object, e As EventArgs) Handles txtBidBondAmt.TextChanged


        Dim BidBondTot = CType(txtTotalBidAmount.Text, Integer)
        Dim BidBondPer = CType(txtBidBondAmt.Text, Integer)

        If BidBondPer < (BidBondTot * 0.1) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Bid Bond amount encoded is below 10%.")
        End If

        txtBidBondAmt.Text = FormatNumber(txtBidBondAmt.Text)
    End Sub

End Class
