Imports System.Data
Partial Class Inventory_Disposal_Disposal_ISSP
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

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub Inventory_Disposal_Disposal_ISSP_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToShortDateString

            LoadPage()

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

    End Sub

    Protected Sub LoadPage()
        Try
            grdISSP.Columns(7).Visible = True

            dtISSP = objDerived.GetDataTable("EXEC [AMS].[sp_for_ISSP]", CommandType.Text)
            grdISSP.DataSource = dtISSP
            grdISSP.DataBind()

            grdISSP.Columns(7).Visible = False

            txtDeadlineSub.Text = Date.Today.ToShortDateString
            txtBidDate.Text = Date.Today.ToShortDateString

            txtInspectionDate.Text = Date.Today.ToShortDateString
            txtInspectionTime.Text = "8:00AM"

            'txtInspectionDate2.Text = Date.Today.ToShortDateString
            'txtInspectionTime2.Text = "8:00"
            'drpInspectionTime2.SelectedIndex = 0

            txtSubmissionLocation.Text = ""

            txtAuctionDate.Text = Date.Today.ToShortDateString
            txtAuctionTime.Text = "8:00"

            txtPublication_Date1.Text = Date.Today.ToShortDateString
            'txtPublication_Date2.Text = Date.Today.ToShortDateString
            'txtPublication_Date3.Text = Date.Today.ToShortDateString

            drpSignatory.DataSource = objDerived.GetDataTable("SELECT * FROM [AMS].[ARE_Returned_History_Hdr] AS A INNER JOIN [AMS].[ARE_Returned_History_Dtl] AS B ON A.Returned_ID = b.Returned_ID" &
                            " RIGHT OUTER JOIN AMS.View_All_Signatories AS C On A.RC_ID = C.deptid And A.Function_ID = C.division_Key WHERE C.isActive = 1", CommandType.Text)
            drpSignatory.DataTextField = "Full_Name"
            drpSignatory.DataValueField = "EmpID"
            drpSignatory.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            grdISSP.Columns(7).Visible = True

            Dim myview As DataView
            myview = dtISSP.DefaultView
            myview.RowFilter = "IIRUP_No like '%" & replaceapostrophe(txtSearch.Text) & "%'"
            grdISSP.DataSource = myview
            grdISSP.DataBind()

            grdISSP.Columns(7).Visible = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Protected Sub cbItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)

        If cb.Checked = True Then
            dtISSP.Rows(grdISSP.Rows(gvr.RowIndex).Cells(7).Text)("isChecked") = True
        Else
            dtISSP.Rows(grdISSP.Rows(gvr.RowIndex).Cells(7).Text)("isChecked") = False
        End If

        For I As Integer = 0 To dtISSP.Rows.Count - 1
            If dtISSP.Rows(I)("isChecked") = True Then
                btnSave.Enabled = True
                Exit For
            Else
                btnSave.Enabled = False
            End If
        Next

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            If txtSubmissionLocation.Text = "" Or txtInspectionTime.Text = "" Or txtBidDate.Text = "" Or txtInspectionTime.Text = "" Or txtDeadlineSub.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "All fields are required.")

            ElseIf txtAuctionDate.Text = "" Or txtAuctionTime.Text = "" Or txtAuctionLoc.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "All fields are required.")

            Else

                Dim ISSPNo As String = objDerived.GetValue("SELECT [dbo].[func_Generate_ISSP_No] ('" & txtDate.Text & "')", CommandType.Text)
                Dim deadline_Time As String = txtDeadlineTime.Text & " " & drpDeadlineTime.SelectedItem.Text
                Dim Auction_Time As String = txtAuctionTime.Text & " " & drpAuctionTime.SelectedItem.Text

                objDerived.Execute("INSERT INTO [AMS].[tbl_ISSP_hdr] ([Issp_Date],[Issp_No],[Signatory_ID],[Submission_Deadline],[Deadline_Time],[Submission_Loc],[BidDocs_Date],[Inspection_Date],[Inspection_Time],[AuctionDate],[AuctionTime],[AuctionLocation],[Inspection_Date2],[Publication_Date1],[Publication_Date2],[Publication_Date3]) " &
                                    " VALUES ('" & txtDate.Text & "','" & ISSPNo & "','" & drpSignatory.SelectedItem.Value & "','" & txtDeadlineSub.Text & "','" & deadline_Time & "', " &
                                    " '" & replaceapostrophe(txtSubmissionLocation.Text) & "','" & txtBidDate.Text & "','" & txtInspectionDate.Text & "','" & txtInspectionTime.Text & "', " &
                                    " '" & txtAuctionDate.Text & "','" & Auction_Time & "','" & replaceapostrophe(txtAuctionLoc.Text) & "','" & IIf(txtInspectionDate2.Text = "", "01/01/1900", txtInspectionDate2.Text) & "', " &
                                    " '" & txtPublication_Date1.Text & "','" & IIf(txtPublication_Date2.Text = "", "01/01/1900", txtPublication_Date2.Text) & "','" & IIf(txtPublication_Date3.Text = "", "01/01/1900", txtPublication_Date3.Text) & "')", CommandType.Text)

                Session("IsspHdr_ID") = objDerived.GetValue("SELECT TOP(1) IsspHdr_ID FROM AMS.tbl_ISSP_hdr ORDER BY IsspHdr_ID DESC", CommandType.Text)

                For i As Integer = 0 To dtISSP.Rows.Count - 1
                    If dtISSP.Rows(i)("isChecked") = True Then
                        objDerived.Execute("INSERT INTO [AMS].[tbl_ISSP_Dtl] ([IsspHdr_ID],[IIRUPHdr_ID],[IIRUP_No],[Particulars],[Location],[AppraiseAmnt],[isWMR]) " &
                                            " VALUES ('" & Session("IsspHdr_ID") & "','" & dtISSP.Rows(i)("IIRUPHdr_ID") & "','" & dtISSP.Rows(i)("IIRUP_No") & "','" & replaceapostrophe(dtISSP.Rows(i)("particulars")) & "','" & replaceapostrophe(dtISSP.Rows(i)("location")) & "','" & dtISSP.Rows(i)("TotalAppraisedValue") & "','" & dtISSP.Rows(i)("isWMR") & "')", CommandType.Text)

                    End If
                Next

                Dim MinBidAmount As Decimal = objDerived.GetValue("SELECT SUM(AppraiseAmnt) FROM AMS.tbl_ISSP_Dtl WHERE IsspHdr_ID = '" & Session("IsspHdr_ID") & "' GROUP BY IsspHdr_ID", CommandType.Text)
                objDerived.Execute("UPDATE AMS.tbl_ISSP_hdr SET MinBid_Amt = '" & MinBidAmount & "' WHERE IsspHdr_ID = '" & Session("IsspHdr_ID") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                btnSave.Enabled = False
                btnPreview.Enabled = True
                btnNotice.Enabled = True
                btnBidForm.Enabled = True
                btnOP.Enabled = True

                LoadPage()

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Dim url As String = "rpt_ISSP_EditContent.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub

    Protected Sub btnBidForm_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim url As String = "rpt_Auction_BidForm.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub
    Protected Sub btnNotice_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim url As String = "rpt_NoticePublicBidding.aspx?"
        Dim fullURL As String = "var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub

    Private Sub btnOP_Click(sender As Object, e As EventArgs) Handles btnOP.Click
        Session("Page") = "ISSP"

        Dim url As String = "rpt_order_of_payment.aspx?"
        Dim fullURL As String = "var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
End Class
