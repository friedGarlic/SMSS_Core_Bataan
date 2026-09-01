Imports System.Data

Partial Class Inventory_Disposal_Disposal_Abstract
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule

    Public Function tempISSP(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("IsspHdr_ID", GetType(Long))
        dt.Columns.Add("Issp_No", GetType(String))
        dt.Columns.Add("Issp_Date", GetType(Date))
        dt.Columns.Add("MinBid_Amt", GetType(Decimal))
        dt.Columns.Add("BidType", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("IsspHdr_ID") = DBNull.Value
            dr("Issp_No") = DBNull.Value
            dr("Issp_Date") = DBNull.Value
            dr("MinBid_Amt") = DBNull.Value
            dr("BidType") = DBNull.Value
            dr("isVisible") = False

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Private Property dtAbstract() As DataTable
        Get
            Return CType(Session("dtAbstract"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAbstract") = value
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
    Private Property dtBidderInfo() As DataTable
        Get
            Return CType(Session("dtBidderInfo"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtBidderInfo") = value
        End Set
    End Property

    Private Sub Inventory_Disposal_Disposal_Abstract_Load(sender As Object, e As EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToShortDateString

            LoadPage()

        End If

        drpBidder.Attributes.Add("onChange", "StartProgressBar();")

    End Sub

    Protected Sub LoadPage()

        dtAbstract = objDerived.GetDataTable("SELECT IsspHdr_ID, Issp_Date, Issp_No, MinBid_Amt, CASE WHEN BidType = 1 THEN 'Per Item' ELSE 'Per Lot' END AS BidType, 0 AS BidCnt, CONVERT(BIT, 1) AS isVisible FROM AMS.tbl_ISSP_hdr WHERE ISNULL(isClose,0) = 1 AND ISNULL(withQuotation,0) = 1 AND ISNULL(withWinner,0) = 0 ORDER BY Issp_Date DESC, Issp_No DESC", CommandType.Text)
        If dtAbstract.Rows.Count < 5 Then
            dtAbstract.Merge(tempISSP(4 - dtAbstract.Rows.Count))
        End If
        grdAbstract.DataSource = dtAbstract
        grdAbstract.DataBind()
        grdAbstract.SelectedIndex = -1

        grdItems.DataSource = Nothing
        grdItems.DataBind()

        drpBidder.Items.Clear()

        txtMode.Text = ""
        txtISSPNo.Text = ""
        txtTotalBidAmt.Text = "0.00"
        txtBidBond.Text = ""
        txtBidBondAmt.Text = "0.00"

        lblBidderBondNote.Text = ""
        lblBidderBondNote.Visible = False


        LoadSignatories()

    End Sub
    Private Sub grdAbstract_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdAbstract.PageIndexChanging
        grdAbstract.DataSource = dtAbstract
        grdAbstract.PageIndex = e.NewPageIndex
        grdAbstract.DataBind()

    End Sub
    Private Sub grdAbstract_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdAbstract.SelectedIndexChanged
        Try
            Session("IsspHdr_ID") = grdAbstract.SelectedDataKey("IsspHdr_ID")

            txtMode.Text = "Public Auction"
            txtISSPNo.Text = grdAbstract.SelectedDataKey("Issp_No")

            dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_Diposal_AbstractItemList] '" & grdAbstract.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)
            grdItems.DataSource = dtItems
            grdItems.DataBind()

            drpBidder.DataSource = objDerived.GetDataTable("SELECT A.QuotationHdr_ID, A.Supplier_ID, A.TotalBidAmt, B.SuppName FROM AMS.tbl_QuotationHdr AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id " &
                                                            " WHERE A.IsspHdr_ID = '" & grdAbstract.SelectedDataKey("IsspHdr_ID") & "' ORDER BY A.TotalBidAmt DESC", CommandType.Text)
            drpBidder.DataTextField = "SuppName"
            drpBidder.DataValueField = "Supplier_ID"
            drpBidder.DataBind()
            drpBidder.Items.Insert(0, "Select")

            txtTotalBidAmt.Text = "0.00"
            txtBidBond.Text = ""
            txtBidBondAmt.Text = "0.00"

            lblBidderBondNote.Text = ""
            lblBidderBondNote.Visible = False

            LoadSignatories()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub UpdateBidderBondNote()
        If drpBidder.SelectedItem Is Nothing OrElse drpBidder.SelectedItem.Text = "Select" Then
            lblBidderBondNote.Text = ""
            lblBidderBondNote.Visible = False
        Else
            lblBidderBondNote.Text = "in payment of bidder’s bond with the amount of " & txtBidBondAmt.Text
            lblBidderBondNote.Visible = True
        End If
    End Sub

    Private Sub drpBidder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpBidder.SelectedIndexChanged
        Try
            If drpBidder.SelectedItem.Text = "Select" Then
                txtTotalBidAmt.Text = "0.00"
                txtBidBond.Text = ""
                txtBidBondAmt.Text = "0.00"

                lblBidderBondNote.Text = ""
                lblBidderBondNote.Visible = False

                btnSave.Enabled = False

            Else

                dtBidderInfo = objDerived.GetDataTable("SELECT DISTINCT A.TotalBidAmt, A.BidBond, A.BidBondAmt, A.Supplier_ID, A.QuotationHdr_ID FROM AMS.tbl_QuotationHdr AS A  " &
                                                 " WHERE  A.IsspHdr_ID = '" & grdAbstract.SelectedDataKey("IsspHdr_ID") & "' AND A.Supplier_ID = '" & drpBidder.SelectedItem.Value & "'", CommandType.Text)

                txtTotalBidAmt.Text = FormatNumber(dtBidderInfo.Rows(0)("TotalBidAmt"), 2)
                txtBidBond.Text = dtBidderInfo.Rows(0)("BidBond")
                txtBidBondAmt.Text = FormatNumber(dtBidderInfo.Rows(0)("BidBondAmt"), 2)

                UpdateBidderBondNote()

                btnSave.Enabled = True

            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub


    Protected Sub txtBidBondAmt_TextChanged(sender As Object, e As EventArgs)
        Try
            If txtBidBondAmt.Text.Trim = "" Then
                txtBidBondAmt.Text = "0.00"
            End If

            UpdateBidderBondNote()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub



    Protected Sub LoadSignatories()
        drpMember1.DataSource = objDerived.GetDataTable("SELECT A.DC_ID, B.Full_Name, B.position_desc, B.EmpID FROM AMS.TbDisposal_Committee_Members AS A RIGHT OUTER JOIN " &
                                                        " HRMS.view_signatory AS B ON A.empsig_id = B.EmpID WHERE (B.isActive = 1) ORDER BY B.Full_Name", CommandType.Text)
        drpMember1.DataTextField = "Full_Name"
        drpMember1.DataValueField = "EmpID"
        drpMember1.DataBind()
        drpMember1.Items.Insert(0, "Select")

        drpMember2.DataSource = objDerived.GetDataTable("SELECT A.DC_ID, B.Full_Name, B.position_desc, B.EmpID FROM AMS.TbDisposal_Committee_Members AS A RIGHT OUTER JOIN " &
                                                        " HRMS.view_signatory AS B ON A.empsig_id = B.EmpID WHERE (B.isActive = 1) ORDER BY B.Full_Name", CommandType.Text)
        drpMember2.DataTextField = "Full_Name"
        drpMember2.DataValueField = "EmpID"
        drpMember2.DataBind()
        drpMember2.Items.Insert(0, "Select")

        drpMember3.DataSource = objDerived.GetDataTable("SELECT A.DC_ID, B.Full_Name, B.position_desc, B.EmpID FROM AMS.TbDisposal_Committee_Members AS A RIGHT OUTER JOIN " &
                                                        " HRMS.view_signatory AS B ON A.empsig_id = B.EmpID WHERE (B.isActive = 1) ORDER BY B.Full_Name", CommandType.Text)
        drpMember3.DataTextField = "Full_Name"
        drpMember3.DataValueField = "EmpID"
        drpMember3.DataBind()
        drpMember3.Items.Insert(0, "Select")

        drpMember4.DataSource = objDerived.GetDataTable("SELECT A.DC_ID, B.Full_Name, B.position_desc, B.EmpID FROM AMS.TbDisposal_Committee_Members AS A RIGHT OUTER JOIN " &
                                                        " HRMS.view_signatory AS B ON A.empsig_id = B.EmpID WHERE (B.isActive = 1) ORDER BY B.Full_Name", CommandType.Text)
        drpMember4.DataTextField = "Full_Name"
        drpMember4.DataValueField = "EmpID"
        drpMember4.DataBind()
        drpMember4.Items.Insert(0, "Select")

        drpMember5.DataSource = objDerived.GetDataTable("SELECT A.DC_ID, B.Full_Name, B.position_desc, B.EmpID FROM AMS.TbDisposal_Committee_Members AS A RIGHT OUTER JOIN " &
                                                        " HRMS.view_signatory AS B ON A.empsig_id = B.EmpID WHERE (B.isActive = 1) ORDER BY B.Full_Name", CommandType.Text)
        drpMember5.DataTextField = "Full_Name"
        drpMember5.DataValueField = "EmpID"
        drpMember5.DataBind()
        drpMember5.Items.Insert(0, "Select")

        drpChairman.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = 1 AND division_Key = 86 AND isActive = 1 ORDER BY Full_Name", CommandType.Text)
        drpChairman.DataTextField = "Full_Name"
        drpChairman.DataValueField = "EmpID"
        drpChairman.DataBind()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If drpMember1.SelectedItem.Text = "Select" Or drpMember2.SelectedItem.Text = "Select" Or drpMember3.SelectedItem.Text = "Select" Or drpMember4.SelectedItem.Text = "Select" Or drpMember5.SelectedItem.Text = "Select" Or drpChairman.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Signatories are required.")
                Exit Sub
            End If

            objDerived.Execute("UPDATE AMS.tbl_QuotationHdr SET isWinner = 1, BidBondAmt = '" & CType(txtBidBondAmt.Text, Decimal) & "', Abstract_Date = '" & txtDate.Text & "' ,member1 = '" & drpMember1.SelectedItem.Value & "',member2 = '" & drpMember2.SelectedItem.Value & "',member3 = '" & drpMember3.SelectedItem.Value & "' " &
                                    " ,member4 = '" & drpMember4.SelectedItem.Value & "', member5 = '" & drpMember5.SelectedItem.Value & "',chairman = '" & drpChairman.SelectedItem.Value & "'  WHERE QuotationHdr_ID = '" & dtBidderInfo.Rows(0)("QuotationHdr_ID") & "' AND Supplier_ID = '" & drpBidder.SelectedItem.Value & "'", CommandType.Text)

            objDerived.Execute("UPDATE AMS.tbl_ISSP_hdr SET withWinner = 1, Abstract_Date = '" & txtDate.Text & "' WHERE IsspHdr_ID = '" & grdAbstract.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)
            objDerived.Execute("UPDATE AMS.tbl_ISSP_InterestedBidder SET op2_Amt = '" & CType(txtBidBondAmt.Text, Decimal) & "' WHERE IsspHdr_ID = '" & grdAbstract.SelectedDataKey("IsspHdr_ID") & "' AND Supplier_Id = '" & drpBidder.SelectedItem.Value & "'", CommandType.Text)

            Session("IsspHdr_ID") = grdAbstract.SelectedDataKey("IsspHdr_ID")
            Session("SuppName") = drpBidder.SelectedItem.Text
            Session("Amount") = CType(txtBidBondAmt.Text, Decimal)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected bidder has been successfully declared as winner.")

            LoadPage()

            btnSave.Enabled = False
            btnPreview.Enabled = True
            btnPreview_OP.Enabled = True

        Catch ex As Exception
            objDerived.Execute("UPDATE AMS.tbl_QuotationHdr SET isWinner = 0 WHERE QuotationHdr_ID = '" & dtItems.Rows(0)("QuotationHdr_ID") & "' AND Supplier_ID = '" & drpBidder.SelectedItem.Value & "'", CommandType.Text)
            objDerived.Execute("UPDATE AMS.tbl_ISSP_hdr SET withWinner = 0 WHERE IsspHdr_ID = '" & grdAbstract.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")

        End Try
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        'Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_abstract_of_bids.aspx")
        Session("Page") = "Abstract"
        Dim url As String = "t_rpt_abstract_of_bids.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub

    Private Sub btnPreview_OP_Click(sender As Object, e As EventArgs) Handles btnPreview_OP.Click
        Session("Page") = "Auction"

        Dim url As String = "rpt_order_of_payment.aspx?"
        Dim fullURL As String = "var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
End Class
