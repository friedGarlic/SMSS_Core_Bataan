Imports System.Data
Partial Class Inventory_Disposal_Disposal_Notice
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule

    Dim DonationLedger As New ConsolidatedPropertySaving.TbDonation_Ledger
    Dim PropertyLedger As New t_PropertyLedger

    Public Function CreatedatatableORList(ByVal row As Integer) As DataTable
        Dim dtx As New DataTable
        Dim drx As DataRow
        Dim mycolumn As New DataColumn

        dtx.Columns.Add("ReceiptNum", GetType(String))
        dtx.Columns.Add("RcptAmnt", GetType(Decimal))


        For i As Integer = 0 To row
            drx = dtx.NewRow
            drx("ReceiptNum") = DBNull.Value
            drx("RcptAmnt") = DBNull.Value
            dtx.Rows.Add(drx)
        Next
        Return dtx
        pORItems = dtx
    End Function
    Public Function tempNOA(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("QuotationHdr_ID", GetType(Long))
        dt.Columns.Add("Supplier_ID", GetType(Integer))
        dt.Columns.Add("IsspHdr_ID", GetType(Long))
        dt.Columns.Add("Issp_No", GetType(String))
        dt.Columns.Add("Abstract_Date", GetType(Date))
        dt.Columns.Add("Issp_Date", GetType(Date))
        dt.Columns.Add("TotalBidAmt", GetType(Decimal))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("BidType", GetType(String))
        dt.Columns.Add("BalanceAmt", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("QuotationHdr_ID") = DBNull.Value
            dr("Supplier_ID") = DBNull.Value
            dr("IsspHdr_ID") = DBNull.Value
            dr("Issp_No") = DBNull.Value
            dr("Abstract_Date") = DBNull.Value
            dr("Issp_Date") = DBNull.Value
            dr("TotalBidAmt") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("BidType") = DBNull.Value
            dr("BalanceAmt") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Private Property pORItems() As DataTable
        Get
            Return CType(Session("pORItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pORItems") = value
        End Set
    End Property

    Private Property dtNOA() As DataTable
        Get
            Return CType(Session("dtNOA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtNOA") = value
        End Set
    End Property
    Private Property dtNTP() As DataTable
        Get
            Return CType(Session("dtNTP"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtNTP") = value
        End Set
    End Property

    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
        End Set
    End Property

    Private Property dtJEV() As DataTable
        Get
            Return CType(Session("dtJEV"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtJEV") = value
        End Set
    End Property

    Private Sub Inventory_Disposal_Disposal_Notice_Load(sender As Object, e As EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        End If

        If Not Page.IsPostBack Then
            txtDate_NOA.Text = Date.Today.ToShortDateString

            LoadPage()

        End If

    End Sub

    Protected Sub LoadPage()

        If btnTab1.CssClass = "TabButton_Active" And btnTab2.CssClass = "TabButton_InActive" And btnTab3.CssClass = "TabButton_InActive" Then
            dtNOA = objDerived.GetDataTable("SELECT DISTINCT A.IsspHdr_ID, A.Issp_Date, A.Issp_No, A.Abstract_Date, CASE WHEN A.BidType = 1 THEN 'Per Item' ELSE 'Per Lot' END AS BidType                                               " &
                                               " , C.SuppName, B.Supplier_ID, B.QuotationHdr_ID, B.TotalBidAmt, B.BidBondAmt, (B.TotalBidAmt - B.BidBondAmt) AS BalanceAmt, CONVERT(BIT, 1) AS isVisible                               " &
                                               " FROM AMS.tbl_ISSP_hdr AS A INNER JOIN AMS.tbl_QuotationHdr AS B ON A.IsspHdr_ID = B.IsspHdr_ID INNER JOIN DBO.Supplier AS C ON B.Supplier_ID = C.Supplier_Id                          " &
                                               " WHERE ISNULL(A.isClose,0) = 1 AND ISNULL(A.withWinner,0) = 1 AND ISNULL(A.withNOA,0) = 0 AND ISNULL(B.isWinner,0) = 1  ORDER BY A.Abstract_Date DESC, A.Issp_No DESC", CommandType.Text)
            If dtNOA.Rows.Count < 5 Then
                dtNOA.Merge(tempNOA(4 - dtNOA.Rows.Count))
            End If
            grdNOA.DataSource = dtNOA
            grdNOA.DataBind()

            drpSignatory_NOA.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE deptid IN (1,78) AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            drpSignatory_NOA.DataTextField = "Full_Name"
            drpSignatory_NOA.DataValueField = "EmpID"
            drpSignatory_NOA.DataBind()
            drpSignatory_NOA.Items.Insert(0, "Select")

            mvTabs.SetActiveView(Me.vwTab1_NOA)

        ElseIf btnTab1.CssClass = "TabButton_InActive" And btnTab2.CssClass = "TabButton_Active" And btnTab3.CssClass = "TabButton_InActive" Then
            dtNTP = objDerived.GetDataTable("SELECT DISTINCT A.IsspHdr_ID, A.Issp_Date, A.Issp_No, A.Abstract_Date, CASE WHEN A.BidType = 1 THEN 'Per Item' ELSE 'Per Lot' END AS BidType                                               " &
                                               " , B.TotalBidAmt, C.SuppName, B.Supplier_ID, B.QuotationHdr_ID, CONVERT(BIT, 1) AS isVisible                                                                                           " &
                                               " FROM AMS.tbl_ISSP_hdr AS A INNER JOIN AMS.tbl_QuotationHdr AS B ON A.IsspHdr_ID = B.IsspHdr_ID INNER JOIN DBO.Supplier AS C ON B.Supplier_ID = C.Supplier_Id                          " &
                                               " WHERE ISNULL(A.isClose,0) = 1 AND ISNULL(A.withWinner,0) = 1 AND ISNULL(A.withNOA,0) = 1 AND ISNULL(A.withNTP,0) = 0 AND ISNULL(B.isWinner,0) = 1  ORDER BY A.Abstract_Date DESC, A.Issp_No DESC", CommandType.Text)
            If dtNTP.Rows.Count < 5 Then
                dtNTP.Merge(tempNOA(4 - dtNTP.Rows.Count))
            End If
            grdNTP.DataSource = dtNTP
            grdNTP.DataBind()

            txtNTP_Date.Text = Date.Today.ToShortDateString

            grdReceipt.DataSource = Nothing
            grdReceipt.DataBind()

            drpApproved_NTP.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE deptid IN (1,78) AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            drpApproved_NTP.DataTextField = "Full_Name"
            drpApproved_NTP.DataValueField = "EmpID"
            drpApproved_NTP.DataBind()
            drpApproved_NTP.Items.Insert(0, "Select")

            mvTabs.SetActiveView(Me.vwTab2_NTP)

        ElseIf btnTab1.CssClass = "TabButton_InActive" And btnTab2.CssClass = "TabButton_InActive" And btnTab3.CssClass = "TabButton_Active" Then
            dtJEV = objDerived.GetDataTable("SELECT DISTINCT A.IsspHdr_ID, A.Issp_Date, A.Issp_No, A.Abstract_Date, CASE WHEN A.BidType = 1 THEN 'Per Item' ELSE 'Per Lot' END AS BidType                                               " &
                                               " , B.TotalBidAmt, C.SuppName, B.Supplier_ID, B.QuotationHdr_ID, CONVERT(BIT, 1) AS isVisible                                                                                           " &
                                               " FROM AMS.tbl_ISSP_hdr AS A INNER JOIN AMS.tbl_QuotationHdr AS B ON A.IsspHdr_ID = B.IsspHdr_ID INNER JOIN DBO.Supplier AS C ON B.Supplier_ID = C.Supplier_Id                          " &
                                               " WHERE ISNULL(A.isClose,0) = 1 AND ISNULL(A.withWinner,0) = 1 AND ISNULL(A.withNOA,0) = 1 AND ISNULL(A.withNTP,0) = 1 AND ISNULL(B.isWinner,0) = 1 AND ISNULL(A.withJEV,0) = 0  ORDER BY A.Abstract_Date DESC, A.Issp_No DESC", CommandType.Text)
            If dtJEV.Rows.Count < 5 Then
                dtJEV.Merge(tempNOA(4 - dtJEV.Rows.Count))
            End If
            grdJEV.DataSource = dtJEV
            grdJEV.DataBind()

            txtJevdate.Text = Date.Today.ToShortDateString
            txtjev_no.Text = ""

            mvTabs.SetActiveView(Me.vwTab3_Jev)
        End If

    End Sub
    Private Sub btnTab1_Click(sender As Object, e As EventArgs) Handles btnTab1.Click
        btnTab1.CssClass = "TabButton_Active"
        btnTab2.CssClass = "TabButton_InActive"
        btnTab3.CssClass = "TabButton_InActive"

        LoadPage()
    End Sub
    Private Sub btnTab2_Click(sender As Object, e As EventArgs) Handles btnTab2.Click
        btnTab1.CssClass = "TabButton_InActive"
        btnTab2.CssClass = "TabButton_Active"
        btnTab3.CssClass = "TabButton_InActive"

        LoadPage()
    End Sub
    Private Sub btnTab3_Click(sender As Object, e As EventArgs) Handles btnTab3.Click
        btnTab1.CssClass = "TabButton_InActive"
        btnTab2.CssClass = "TabButton_InActive"
        btnTab3.CssClass = "TabButton_Active"

        LoadPage()
    End Sub






    '====================================================
    ' NOTICE OF AWARD
    '====================================================
    Private Sub grdNOA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdNOA.PageIndexChanging
        grdNOA.DataSource = dtNOA
        grdNOA.PageIndex = e.NewPageIndex
        grdNOA.DataBind()
    End Sub
    Private Sub grdNOA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdNOA.SelectedIndexChanged
        Try
            Session("IsspHdr_ID") = grdNOA.SelectedDataKey("IsspHdr_ID")
            Session("SuppName") = grdNOA.SelectedDataKey("SuppName")
            Session("Amount") = grdNOA.SelectedDataKey("BalanceAmt")

            btnSave_NOA.Enabled = True
            btnPreview_OP.Enabled = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSave_NOA_Click(sender As Object, e As EventArgs) Handles btnSave_NOA.Click
        Try
            If drpSignatory_NOA.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory.")
            Else

                Dim NOATime = txtNOAtime.Text + " " + drpNOAtime.SelectedValue

                objDerived.Execute("UPDATE AMS.tbl_ISSP_hdr SET withNOA = 1, NOA_Date = '" & txtDate_NOA.Text & "', NOA_Signatory = '" & drpSignatory_NOA.SelectedItem.Value & "', NOA_Time = '" & NOATime & "' WHERE IsspHdr_ID = '" & grdNOA.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)
                objDerived.Execute("UPDATE AMS.tbl_ISSP_InterestedBidder SET op3_Amt = '" & CType(Session("Amount"), Decimal) & "' WHERE IsspHdr_ID = '" & grdNOA.SelectedDataKey("IsspHdr_ID") & "' AND Supplier_Id = '" & grdNOA.SelectedDataKey("Supplier_ID") & "'", CommandType.Text)

                Session("NOA_Date") = CType(txtDate_NOA.Text, Date)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                LoadPage()

                btnSave_NOA.Enabled = False
                btnPreview_NOA.Enabled = True

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnPreview_OP_Click(sender As Object, e As EventArgs) Handles btnPreview_OP.Click
        Session("Page") = "NOA"

        Dim url As String = "rpt_order_of_payment.aspx?"
        Dim fullURL As String = "var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
    Private Sub btnPreview_NOA_Click(sender As Object, e As EventArgs) Handles btnPreview_NOA.Click

        'Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_Notice_NOA.aspx")

        Dim url As String = "Disposal_Notice_NOA.aspx?"
        Dim fullURL As String = "var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub





    '====================================================
    ' NOTICE TO PROCEED
    '====================================================
    Private Sub grdNTP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdNTP.SelectedIndexChanged
        Try
            Session("IsspHdr_ID") = grdNTP.SelectedDataKey("IsspHdr_ID")

            btnSave.Enabled = True

            grdReceipt.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_ISSP_rcpt] '" & Session("IsspHdr_ID") & "','" & grdNTP.SelectedDataKey("Supplier_ID") & "'", CommandType.Text)
            grdReceipt.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If drpApproved_NTP.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory.")

            Else


                For i As Integer = 0 To grdReceipt.Rows.Count - 1
                    If CType(grdReceipt.Rows(i).FindControl("txtORNumb"), TextBox).Text = "" Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "OR number is required.")
                        Exit Sub
                    End If
                Next

                For i As Integer = 0 To grdReceipt.Rows.Count - 1

                    objDerived.Execute("INSERT INTO [AMS].[tbl_ISSP_Rcpt] ([IsspHdr_ID],[Supplier_Id],[rcpt_no],[or_date],[rcpt_amt])     " &
                                          "  VALUES                                                                                         " &
                                          "  ('" & Session("IsspHdr_ID") & "'                                                               " &
                                          "  ,'" & grdNTP.SelectedDataKey("Supplier_ID") & "'                                               " &
                                          "  ,'" & CType(grdReceipt.Rows(i).FindControl("txtORNumb"), TextBox).Text & "'                    " &
                                          "  ,'" & txtNTP_Date.text & "'        " &
                                          "  ,'" & CType(CType(grdReceipt.Rows(i).FindControl("lblOPAmt"), Label).Text, Decimal) & "')", CommandType.Text)


                Next

                objDerived.Execute("UPDATE AMS.tbl_ISSP_hdr SET withNTP = 1, NTP_Date = '" & CType(txtNTP_Date.Text, Date) & "', NTP_Signatory = '" & drpApproved_NTP.SelectedItem.Value & "' WHERE IsspHdr_ID = '" & grdNTP.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                btnSave.Enabled = False
                btnPreview_NTP.Enabled = True
                btnNoticePrev.Enabled = True

            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Private Sub btnPreview_NTP_Click(sender As Object, e As EventArgs) Handles btnPreview_NTP.Click
        Session("Report") = "NTP"
        btnPreview_NTP.Enabled = False
        'Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_ReportEncoding.aspx")

        Dim url As String = "Disposal_ReportEncoding.aspx?"
        Dim fullURL As String = "var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub
    Private Sub btnNoticePrev_Click(sender As Object, e As EventArgs) Handles btnNoticePrev.Click
        Session("Report") = "Accntg"
        btnNoticePrev.Enabled = False
        'Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")

        Dim url As String = "Disposal_ReportEncoding.aspx?"
        Dim fullURL As String = "var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)


    End Sub





    '====================================================
    Private Sub grdJEV_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdJEV.PageIndexChanging
        grdJEV.DataSource = dtJEV
        grdJEV.PageIndex = e.NewPageIndex
        grdJEV.DataBind()
    End Sub

    Private Sub grdJEV_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdJEV.SelectedIndexChanged
        Try
            dtItems = objDerived.GetDataTable("SELECT DISTINCT A.IsspHdr_ID, A.QuotationHdr_ID, B.IIRUPHdr_ID, B.Property_No, B.BidAmt, D.isDonated, D.Item_ID, " &
                                         "ISNULL(C.SerialNo, '') AS SerialNo " &
                                         "FROM AMS.tbl_QuotationHdr AS A INNER JOIN AMS.tbl_QuotationDtl AS B ON A.QuotationHdr_ID = B.QuotationHdr_ID " &
                                         "INNER JOIN AMS.Property_Dtl AS C ON B.Property_No = C.PropertyNo " &
                                         "INNER JOIN AMS.Property AS D ON C.Property_ID = D.Property_ID " &
                                         "WHERE A.isWinner = 1 AND A.IsspHdr_ID = '" & grdJEV.SelectedDataKey("IsspHdr_ID") & "' " &
                                         "AND A.QuotationHdr_ID = '" & grdJEV.SelectedDataKey("QuotationHdr_ID") & "' " &
                                         "AND A.Supplier_ID = '" & grdJEV.SelectedDataKey("Supplier_ID") & "' " &
                                         "ORDER BY B.Property_No", CommandType.Text)

            btnSaveJev.Enabled = True
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSaveJev_Click(sender As Object, e As EventArgs) Handles btnSaveJev.Click
        Try
            If txtjev_no.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please encode the JEV Number.")
            Else

                For i As Integer = 0 To dtItems.Rows.Count - 1
                    objDerived.Execute("INSERT INTO [AMS].[MRE_Returns] ([MRE_Dtl],[PropertyNo],[Status],[Remarks],[MRE_Date],[Dispose],[Repair],[deptid],[Inspection],[UserID]) " &
                                                 " VALUES(0,'" & dtItems.Rows(i)("Property_No") & "','Disposed','Public Auction','" & txtJevdate.Text & "',1,0,0,0,'" & Session("@UserName") & "')", CommandType.Text)

                    objDerived.Execute("UPDATE AMS.Property_Dtl SET Status = 'Dispose', Dispose = 1, Issued = 0, DisposeDate='" & txtJevdate.Text & "' WHERE  PropertyNo ='" & dtItems.Rows(i)("Property_No") & "'", CommandType.Text)

                    Dim prop_id As Integer = objDerived.GetValue("SELECT Property_ID FROM AMS.Property_Dtl WHERE PropertyNo = '" & dtItems.Rows(i)("Property_No") & "'", CommandType.Text)
                    objDerived.Execute("UPDATE AMS.Property SET Balance = (Balance - 1), Issuance = (Issuance + 1)  WHERE Property_ID = '" & prop_id & "'", CommandType.Text)

                    Dim unitDesc As String
                    unitDesc = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & dtItems.Rows(i)("Item_ID") & "'", CommandType.Text)

                    If dtItems.Rows(i)("isDonated") = True Or dtItems.Rows(i)("isDonated") = 1 Then
                        With DonationLedger
                            .PropertyNo = dtItems.Rows(i)("Property_No")
                            .SerialNo = dtItems.Rows(i)("SerialNo")
                            .Trans_Type = "Disposed as Public Auction"
                            .Ref = grdJEV.SelectedDataKey("Issp_No")
                            .AccountablePerson = ""
                            .Department = ""
                            .Position = ""
                            .AcceptedBy = ""
                            .InspectedBy = ""
                            .Item_ID = dtItems.Rows(i)("Item_ID")

                            .DebitQty = "0"
                            .DebitUnit = "-"
                            .DebitCost = "0.00"

                            .CreditQty = 1
                            .CreditUnit = unitDesc
                            .CreditCost = dtItems.Rows(i)("BidAmt")

                            .BalanceQty = "0"
                            .BalanceUnit = unitDesc
                            .BalanceCost = "0.00"
                            .dDate = txtJevdate.Text

                            .save()

                        End With

                    Else

                        With PropertyLedger
                            .PropertyNo = dtItems.Rows(i)("Property_No")
                            .SerialNo = dtItems.Rows(i)("SerialNo")
                            .dDate = txtJevdate.Text
                            .Trans_Type = "Disposed as Public Auction"
                            .Ref = grdJEV.SelectedDataKey("Issp_No")
                            .Item_ID = dtItems.Rows(i)("Item_ID")
                            .AccountablePerson = ""
                            .Department = ""
                            .Position = ""
                            .AcceptedBy = ""
                            .InspectedBy = ""

                            .DebitQty = "0"
                            .DebitUnit = "-"
                            .DebitCost = "0.00"

                            .CreditQty = 1
                            .CreditUnit = unitDesc
                            .CreditCost = dtItems.Rows(i)("BidAmt")

                            .BalanceQty = "0"
                            .BalanceUnit = unitDesc
                            .BalanceCost = "0.00"
                            .save()
                        End With

                    End If


                Next

                objDerived.Execute("UPDATE AMS.tbl_ISSP_hdr SET withReceipt = 1, withJEV = 1, jev_date = '" & txtJevdate.Text & "', jev_no = '" & txtjev_no.Text & "' WHERE IsspHdr_ID = '" & grdJEV.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


                dtJEV = objDerived.GetDataTable("SELECT DISTINCT A.IsspHdr_ID, A.Issp_Date, A.Issp_No, A.Abstract_Date, CASE WHEN A.BidType = 1 THEN 'Per Item' ELSE 'Per Lot' END AS BidType                                               " &
                                               " , B.TotalBidAmt, C.SuppName, B.Supplier_ID, B.QuotationHdr_ID, CONVERT(BIT, 1) AS isVisible                                                                                           " &
                                               " FROM AMS.tbl_ISSP_hdr AS A INNER JOIN AMS.tbl_QuotationHdr AS B ON A.IsspHdr_ID = B.IsspHdr_ID INNER JOIN DBO.Supplier AS C ON B.Supplier_ID = C.Supplier_Id                          " &
                                               " WHERE ISNULL(A.isClose,0) = 1 AND ISNULL(A.withWinner,0) = 1 AND ISNULL(A.withNOA,0) = 1 AND ISNULL(A.withNTP,0) = 1 AND ISNULL(B.isWinner,0) = 1 AND ISNULL(A.withJEV,0) = 0  ORDER BY A.Abstract_Date DESC, A.Issp_No DESC", CommandType.Text)
                If dtJEV.Rows.Count < 5 Then
                    dtJEV.Merge(tempNOA(4 - dtJEV.Rows.Count))
                End If
                grdJEV.DataSource = dtJEV
                grdJEV.DataBind()


                txtJevdate.Text = Date.Today.ToShortDateString
                txtjev_no.Text = ""


            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub



End Class
