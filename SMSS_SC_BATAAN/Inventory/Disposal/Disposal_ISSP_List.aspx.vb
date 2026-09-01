Imports System
Imports System.Data
Partial Class Inventory_Disposal_Disposal_ISSP_List
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule

    Private Property dtISSP() As DataTable
        Get
            Return CType(Session("dtISSP"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtISSP") = value
        End Set
    End Property
    Private Property strBidders() As String
        Get
            Return CType(Session("strBidders"), String)
        End Get
        Set(ByVal value As String)
            Session("strBidders") = value
        End Set
    End Property
    Private Property str_grdBidders() As String
        Get
            Return CType(Session("str_grdBidders"), String)
        End Get
        Set(ByVal value As String)
            Session("str_grdBidders") = value
        End Set
    End Property

    Private Property str_Action() As String
        Get
            Return CType(Session("str_Action"), String)
        End Get
        Set(ByVal value As String)
            Session("str_Action") = value
        End Set
    End Property

    Private Property dtBidders() As DataTable
        Get
            Return CType(Session("dtBidders"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtBidders") = value
        End Set
    End Property
    Public Function dtTemp_ISSP(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("IsspHdr_ID", GetType(Long))
        dt.Columns.Add("ISSP_Date", GetType(Date))
        dt.Columns.Add("ISSP_No", GetType(String))
        dt.Columns.Add("MinBid_Amt", GetType(Decimal))
        dt.Columns.Add("AuctionDate", GetType(Date))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("IsspHdr_ID") = DBNull.Value
            dr("ISSP_Date") = DBNull.Value
            dr("ISSP_No") = DBNull.Value
            dr("MinBid_Amt") = DBNull.Value
            dr("AuctionDate") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function dtTemp_Bidder(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("ID", GetType(Long))
        dt.Columns.Add("Supplier_Id", GetType(Integer))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("op1_Amt", GetType(Decimal))
        dt.Columns.Add("isPaid", GetType(Boolean))
        dt.Columns.Add("isAttend", GetType(Boolean))
        dt.Columns.Add("OR_No", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("ID") = DBNull.Value
            dr("Supplier_Id") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("op1_Amt") = DBNull.Value
            dr("isPaid") = False
            dr("isAttend") = False
            dr("OR_No") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub Inventory_Disposal_Disposal_ISSP_List_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToShortDateString

            LoadPage()

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
    End Sub

    Protected Sub LoadPage()

        dtISSP = objDerived.GetDataTable("SELECT DISTINCT A.Issp_Date, A.Issp_No, A.MinBid_Amt, A.AuctionDate, A.IsspHdr_ID, CONVERT(BIT,1) AS isVisible FROM AMS.tbl_ISSP_hdr AS A WHERE ISNULL(A.isClose,0) = 0 ORDER BY A.Issp_Date DESC, A.Issp_No DESC", CommandType.Text)
        If dtISSP.Rows.Count < 5 Then
            dtISSP.Merge(dtTemp_ISSP(4 - dtISSP.Rows.Count))
        End If
        grdISSP.DataSource = dtISSP
        grdISSP.DataBind()
        grdISSP.SelectedIndex = -1

        grdBidders.DataSource = dtTemp_Bidder(4)
        grdBidders.DataBind()

    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtISSP.DefaultView
        myview.RowFilter = "Issp_No like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        grdISSP.DataSource = myview
        grdISSP.DataBind()
    End Sub

    Private Sub grdISSP_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdISSP.PageIndexChanging
        grdISSP.DataSource = dtISSP
        grdISSP.PageIndex = e.NewPageIndex
        grdISSP.DataBind()
    End Sub
    Protected Sub lnkSelect_Click(sender As Object, e As EventArgs)
        str_Action = "Select"

    End Sub
    Protected Sub lnkClose_Click(sender As Object, e As EventArgs)
        str_Action = "Close"

    End Sub
    Private Sub grdISSP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdISSP.SelectedIndexChanged
        Try
            Session("IsspHdr_ID") = grdISSP.SelectedDataKey("IsspHdr_ID")

            If str_Action = "Select" Then
                LoadBidders()

                txtOP_Amt.Text = "0.00"
                If grdISSP.SelectedDataKey("AuctionDate") < Date.Today.ToShortDateString Then
                    btnAddBidder.Enabled = False
                Else
                    btnAddBidder.Enabled = True
                End If

                btnPreview_Abstract.Enabled = True
                btnPreview_InterestedBidder.Enabled = True
                btnNotice_COA.Enabled = True
                btnNotice_Conspicuous.Enabled = True

            ElseIf str_Action = "Close" Then
                objDerived.Execute("UPDATE [AMS].[tbl_ISSP_hdr] SET [isClose] = 1 WHERE [IsspHdr_ID] = '" & grdISSP.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected ISSP has been successfully close.")
                LoadPage()

            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Session time out, refresh the page and try again.")
            End If




        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub



    Protected Sub LoadBidders()
        drpSuppliers.DataSource = objDerived.GetDataTable("SELECT SuppName, Supplier_Id FROM DBO.Supplier ORDER BY SuppName", CommandType.Text)
        drpSuppliers.DataTextField = "SuppName"
        drpSuppliers.DataValueField = "Supplier_Id"
        drpSuppliers.DataBind()
        drpSuppliers.Items.Insert(0, "Select")

        dtBidders = objDerived.GetDataTable("SELECT ROW_NUMBER() OVER (ORDER BY B.SuppName) AS ID, B.SuppName, A.op1_Amt, A.isPaid, A.isAttend, A.op1_OR AS OR_No " &
                              "  , A.interestedBidder_id, A.Supplier_Id, CONVERT(BIT,1) AS isVisible       " &
                              "  FROM AMS.tbl_ISSP_InterestedBidder AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_Id = B.Supplier_Id      " &
                              "  WHERE IsspHdr_ID = '" & grdISSP.SelectedDataKey("IsspHdr_ID") & "' ORDER BY B.SuppName", CommandType.Text)
        If dtBidders.Rows.Count = 0 Then
            strBidders = "No_Bidders"
            btnUpdateBidders.Enabled = False
        Else
            strBidders = "With_Bidders"
            btnUpdateBidders.Enabled = True
        End If


        If dtBidders.Rows.Count < 5 Then
            dtBidders.Merge(dtTemp_Bidder(4 - dtBidders.Rows.Count))
        End If
        grdBidders.DataSource = dtBidders
        grdBidders.DataBind()

        txtOP_Amt.Text = "0.00"

    End Sub
    Private Sub btnAddBidder_Click(sender As Object, e As EventArgs) Handles btnAddBidder.Click
        Try

            If drpSuppliers.SelectedItem.Text = "Select" Or txtOP_Amt.Text = "" Or txtOP_Amt.Text = "0.00" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select bidder and input amount.")

            Else

                Dim id As Integer = objDerived.GetValue("SELECT [interestedBidder_id] FROM [AMS].[tbl_ISSP_InterestedBidder] WHERE [IsspHdr_ID] = '" & grdISSP.SelectedDataKey("IsspHdr_ID") & "' AND [Supplier_Id] = '" & drpSuppliers.SelectedItem.Value & "'", CommandType.Text)
                If id = 0 Then
                    objDerived.Execute("INSERT INTO [AMS].[tbl_ISSP_InterestedBidder] ([IsspHdr_ID],[Supplier_Id],[op1_Amt],[isPaid],[isAttend],[op1_OR]) " &
                            "  VALUES                                               " &
                            "  ('" & grdISSP.SelectedDataKey("IsspHdr_ID") & "'     " &
                            "  ,'" & drpSuppliers.SelectedItem.Value & "'           " &
                            "  ,'" & CType(txtOP_Amt.Text, Decimal) & "'            " &
                            "  ,0                                                   " &
                            "  ,0                                                   " &
                            "  ,'')", CommandType.Text)
                Else
                    objDerived.Execute("UPDATE [AMS].[tbl_ISSP_InterestedBidder] SET [op1_Amt] = '" & CType(txtOP_Amt.Text, Decimal) & "' WHERE [interestedBidder_id] = '" & id & "'", CommandType.Text)

                End If


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                LoadBidders()

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub


    Private Sub grdBidders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdBidders.SelectedIndexChanged
        Session("Page") = "ISSP_List"
        Session("SuppName") = grdBidders.SelectedDataKey("SuppName")
        Session("op1_Amt") = grdBidders.SelectedDataKey("op1_Amt")

        Me.Page.Response.Redirect("~/Inventory/disposal/rpt_order_of_payment.aspx")

    End Sub
    Private Sub btnPreview_InterestedBidder_Click(sender As Object, e As EventArgs) Handles btnPreview_InterestedBidder.Click
        If strBidders = "No_Bidders" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No Bidders to Preview.")
        Else

            'Me.Page.Response.Redirect("~/Inventory/Disposal/rpt_BidderAttendance.aspx")



            Dim url As String = "rpt_BidderAttendance.aspx?"
            Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
        End If


    End Sub

    Private Sub btnPreview_Abstract_Click(sender As Object, e As EventArgs) Handles btnPreview_Abstract.Click
        Session("Page") = "ISSP_List"
        If strBidders = "No_Bidders" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No Bidders to Preview.")
        Else
            'Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_abstract_of_bids.aspx")


            Dim url As String = "t_rpt_abstract_of_bids.aspx?"
            Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        End If
    End Sub

    Private Sub btnNotice_COA_Click(sender As Object, e As EventArgs) Handles btnNotice_COA.Click
        'txtCOA_Date.Text = Date.Today.ToShortDateString
        'ModalPopupExtender1.Show()

        Session("Report") = "Notice_COA"


        'Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_ReportEncoding.aspx")

        Dim url As String = "Disposal_ReportEncoding.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub

    Private Sub btnPreviewCOA_Click(sender As Object, e As EventArgs) Handles btnPreviewCOA.Click
        Session("Report") = "Notice_COA"
        Session("Notice_COA_Date") = CType(txtCOA_Date.Text, Date)
        Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")

        'Me.Page.Response.Redirect("~/Disposal/Disposal_ReportEncoding.aspx")

    End Sub

    Private Sub btnNotice_Conspicuous_Click(sender As Object, e As EventArgs) Handles btnNotice_Conspicuous.Click

        Session("Report") = "Notice_Conspicuous"
        Session("Date") = Date.Today.ToShortDateString
        'Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")

        Dim url As String = "Disposal_Notices.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)


    End Sub

    Private Sub btnUpdateBidders_Click(sender As Object, e As EventArgs) Handles btnUpdateBidders.Click
        Try

            For i As Integer = 0 To grdBidders.Rows.Count - 1
                objDerived.Execute("UPDATE AMS.tbl_ISSP_InterestedBidder SET isPaid = '" & CType(grdBidders.Rows(i).FindControl("cbPaid"), CheckBox).Checked & "', isAttend = '" & CType(grdBidders.Rows(i).FindControl("cbAttend"), CheckBox).Checked & "', op1_OR = '" & CType(grdBidders.Rows(i).FindControl("txtOR"), TextBox).Text & "' WHERE interestedBidder_id = '" & dtBidders.Rows(i)("interestedBidder_id") & "'", CommandType.Text)
            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "List of bidders has been successfully updated.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
End Class
