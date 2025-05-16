Imports System
Imports System.Data

Partial Class Inventory_Disposal_rpt_ISSP_EditContent
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule


    Public Function dttemp_IIRUP(ByVal row As Integer) As DataTable
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim mycolumn As New DataColumn
        dt.Columns.Add("IIRUP_No", GetType(String))
        dt.Columns.Add("Particular", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("MinBidAmt", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("IIRUP_No") = DBNull.Value
            dr("Particular") = DBNull.Value
            dr("Location") = DBNull.Value
            dr("MinBidAmt") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub Inventory_Disposal_rpt_ISSP_EditContent_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            grdIIRUP.DataSource = objDerived.GetDataTable("SELECT B.IIRUP_No, B.Particulars, B.Location, (SELECT SUM(X.AppraiseAmnt) FROM AMS.tbl_ISSP_Dtl AS X WHERE X.IsspHdr_ID = A.IsspHdr_ID) AS MinBidAmt " &
                                                               " FROM AMS.tbl_ISSP_hdr AS A INNER JOIN AMS.tbl_ISSP_Dtl AS B ON A.IsspHdr_ID = B.IsspHdr_ID " &
                                                               " WHERE A.IsspHdr_ID = '" & Session("IsspHdr_ID") & "' ORDER BY B.IIRUP_No", CommandType.Text)
            grdIIRUP.DataBind()

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT 'Sealed proposal shall be submitted to the Chairman, Disposal Committee c/o Atty. Dennis Bernard N. Acorda, City Administrator. Please attach certified true copy of valid Business Permit, DTI Registration/SEC Registration and Special Power of Attorney (SPA)/Secretary Certificate for authorized representative, " &
                                      "if applicable. Deadline for the submission of sealed proposal and opening thereof shall be on ' + FORMAT(A.Submission_Deadline,'MMMM dd, yyyy') + ', ' + A.Deadline_Time + ' at the ' + A.Submission_Loc + '. All bids must be accompanied by a Bidder''s Bond equivalent to 10% of the total amount of the bid offer and the difference thereof shall be paid in full in the form of cash, " &
                                      "cashier''s check, or manager''s check issued by reputable bank within 3 working days upon receipt of the Notice of Award.' AS P2_A " &
                                      ", 'Claims shall be made after the bid price is fully paid as evidenced by an Official Receipt and shall be made during official government working hours with representative from the General Services Office within three (3) working days upon receipt of the Notice of Proceed.' AS P2_B " &
                                      ", 'Bid documents may be obtained starting on ' + FORMAT(A.BidDocs_Date,'MMMM dd, yyyy') + ' at General Services Office, Room 105, GF, Pasay City Hall from 8:00 am to 5:00 pm, upon payment of a fee of 40.00 Pesos per City Ordinance No. 1614, Series of 1999, Section 55, Chapter 17 of Pasay Revenue Code.' AS P2_C " &
                                      ", 'Inspection of the properties for auction is schedules on ' + CASE WHEN ISNULL(A.Inspection_Date2,'01/01/1900') = '01/01/1900' THEN FORMAT(A.Inspection_Date,'MMMM dd, yyyy') ELSE FORMAT(A.Inspection_Date,'MMMM dd, yyyy') + ' and ' + FORMAT(A.Inspection_Date2,'MMMM dd, yyyy') END + ' at ' + A.Inspection_Time + ' only with representatives from General Services Office.' AS P2_D " &
                                      ", 'The Committee serves the right to cancel or postpone the date of auction without offering any reasons thereof for the advantage of the City Government.' AS P2_E " &
                                      ", CASE WHEN ISNULL(A.Publication_Date2,'01/01/1900') = '01/01/1900' AND ISNULL(A.Publication_Date3,'01/01/1900') = '01/01/1900' THEN FORMAT(A.Publication_Date1,'MMMM dd, yyyy') " &
                                      "WHEN ISNULL(A.Publication_Date3,'01/01/1900') = '01/01/1900' THEN FORMAT(A.Publication_Date1,'MMMM dd, yyyy') + ' and ' + FORMAT(A.Publication_Date2,'MMMM dd, yyyy') " &
                                      "ELSE FORMAT(A.Publication_Date1,'MMMM dd, yyyy') + ', ' + FORMAT(A.Publication_Date2,'MMMM dd, yyyy') + ' and ' + FORMAT(A.Publication_Date3,'MMMM dd, yyyy') " &
                                      "END AS PUBLISHED, C.Full_Name, C.position_desc " &
                                      "FROM AMS.tbl_ISSP_hdr AS A " &
                                      "INNER JOIN AMS.tbl_ISSP_Dtl AS B ON A.IsspHdr_ID = B.IsspHdr_ID " &
                                      "INNER JOIN AMS.View_All_Signatories AS C ON A.Signatory_ID = C.EmpID " &
                                      "WHERE A.IsspHdr_ID = '" & Session("IsspHdr_ID") & "'", CommandType.Text)

            txtP1.Text = "The City Government of Cagayan through its Disposal Committee invites interested parties to submit sealed proposal for the auction of the following unserviceable properties as indicated in the approved Inventory and Inspection Report of Unserviceable Property (IIRUP):"
            txtP2.Text = dt.Rows(0)("P2_A") & Environment.NewLine & Environment.NewLine & dt.Rows(0)("P2_B") & Environment.NewLine & Environment.NewLine & dt.Rows(0)("P2_C") & Environment.NewLine & Environment.NewLine & dt.Rows(0)("P2_D") & Environment.NewLine & Environment.NewLine & dt.Rows(0)("P2_E")
            lblSignedBy.Text = dt.Rows(0)("Full_Name")
            lblSignedBy_Pos.Text = dt.Rows(0)("position_desc")
            lblPublishedDate.Text = "Newspaper Publication: " & dt.Rows(0)("PUBLISHED")


        End If
    End Sub

    Private Sub btnSavePreview_Click(sender As Object, e As EventArgs) Handles btnSavePreview.Click
        Try

            objDerived.Execute("INSERT INTO [AMS].[tbl_rpt_ISSP] ([IsspHdr_ID],[P1],[P2],[Published],[SignedBy],[SignedBy_Pos]) " &
                                  "  VALUES                     " &
                                  "  ('" & Session("IsspHdr_ID") & "' " &
                                  "  ,'" & replaceapostrophe(txtP1.Text) & "' " &
                                  "  ,'" & replaceapostrophe(txtP2.Text) & "' " &
                                  "  ,'" & lblPublishedDate.Text & "'" &
                                  "  ,'" & lblSignedBy.Text & "' " &
                                  "  ,'" & lblSignedBy_Pos.Text & "')", CommandType.Text)

            Session("Page") = "Disposal"
            Me.Page.Response.Redirect("~/Inventory/Disposal/rpt_ISSP.aspx")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")

        End Try
    End Sub
End Class
