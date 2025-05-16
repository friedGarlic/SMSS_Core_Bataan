Imports System
Imports System.Data
Partial Class bidding_Pre_Procurement_Limited
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim objDerived As New DerivedDal
    Dim hdr As New t_pre_procurement_hdr
    Dim dtl As New t_pre_procurement_dtl

    Private Property dtITB() As DataTable
        Get
            Return CType(Session("dtITB"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtITB") = value
        End Set
    End Property
    Private Property dtPreProcurement() As DataTable
        Get
            Return CType(Session("dtPreProcurement"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPreProcurement") = value
        End Set
    End Property
    Public Function ITB_Table(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("EvalDate", GetType(Date))
        dt.Columns.Add("GA_Code", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("PR_No", GetType(String))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("EvalDate") = DBNull.Value
            dr("GA_Code") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("PR_No") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("remarks") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function PreProc_Table(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("ITB_No", GetType(String))
        dt.Columns.Add("ProjectName", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("ITB_No") = DBNull.Value
            dr("ProjectName") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Private Sub bidding_Pre_Procurement_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            'obj.GetAccessRight(Me.Session("@username"), Page)
            'If obj.HasAccess = False Then
            '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
            'End If


            btnTab1.CssClass = "TabButton_Active"
            btnTab2.CssClass = "TabButton_InActive"

            LoadTab()

        End If
    End Sub
    Private Sub btnTab1_Click(sender As Object, e As EventArgs) Handles btnTab1.Click
        btnTab1.CssClass = "TabButton_Active"
        btnTab2.CssClass = "TabButton_InActive"

        LoadTab()
    End Sub
    Private Sub btnTab2_Click(sender As Object, e As EventArgs) Handles btnTab2.Click
        btnTab1.CssClass = "TabButton_InActive"
        btnTab2.CssClass = "TabButton_Active"

        LoadTab()
    End Sub
    Protected Sub LoadTab()
        Try
            If btnTab1.CssClass = "TabButton_Active" And btnTab2.CssClass = "TabButton_InActive" Then

                lblPageTitle.Text = "INVITATION TO BID"

                dtITB = objDerived.GetDataTable("EXEC [AMS].[sp_PreProcurement_ITB_limited]", CommandType.Text)
                If dtITB.Rows.Count < 5 Then
                    dtITB.Merge(ITB_Table(5 - (dtITB.Rows.Count)))
                End If
                grdITB.DataSource = dtITB
                grdITB.DataBind()


                LoadClearITB()

                txtITB_No.Text = objDerived.GetValue("SELECT [AMS].[func_Generate_ITBNo] ('" & Date.Today.ToShortDateString & "')", CommandType.Text)

                Session("Report") = "ITB with PreBid"

                Me.mvTabs.SetActiveView(Me.vwITB)

            ElseIf btnTab1.CssClass = "TabButton_InActive" And btnTab2.CssClass = "TabButton_Active" Then
                lblPageTitle.Text = "PRE-BID OPENING"

                loadPreprocurement()

                Me.mvTabs.SetActiveView(Me.vwPRE)

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub LoadClearITB()
        txtITB_Date.Text = Date.Today.ToShortDateString
        txtPhilGeps_DateFrom.Text = Date.Today.ToShortDateString
        txtPhilGeps_DateTo.Text = Date.Today.ToShortDateString
        txtBidForm_AvailDate.Text = Date.Today.ToShortDateString

        txtPreBid_ConferenceDate.Text = Date.Today.ToShortDateString
        txtBidOpening_Date.Text = Date.Today.ToShortDateString

        txtITB_No.Text = ""
        txtPreBid_ConferenceTime.Text = "2:00"
        txtPreBid_ConferencePlace.Text = ""
        txtBidOpening_Time.Text = "2:00"
        txtBidOpening_Place.Text = ""
        txtProjectName_new.Text = ""
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Private Sub btnSaveITB_Click(sender As Object, e As EventArgs) Handles btnSaveITB.Click

        '==== CHECK IF THERE'S CHECKBOX THAT HAS BEEN SELECTED
        Dim x As Integer = 0
        For i As Integer = 0 To grdITB.Rows.Count - 1
            If CType(grdITB.Rows(i).FindControl("cb1"), CheckBox).Visible = True Then
                If CType(grdITB.Rows(i).FindControl("cb1"), CheckBox).Checked = True Then
                    x = 1
                    Exit For
                End If
            End If
        Next

        If x = 1 Then
            Try
                Dim CheckITB As Integer = objDerived.GetValue("SELECT ITB_Hdr_ID FROM AMS.ITB_Hdr_Limited WHERE ITB_No = '" & txtITB_No.Text & "'", CommandType.Text)

                Dim ID As Object = objDerived.GetValue("SELECT ITB_Hdr_ID FROM AMS.ITB_Hdr_Limited WHERE ITB_No = '" & txtITB_No.Text & "'", CommandType.Text)

                If ID = 0 Then
                    '====== SAVE ITB HEADER
                    objDerived.Execute("INSERT INTO [AMS].[ITB_Hdr_Limited] ([ITB_No],[ITB_Date],[PhilGeps_DateFrom],[PhilGeps_DateTo],[BidForm_AvailabilityDate],[withPreBidConference]    " &
                                          "  ,[PreBid_Date],[PreBid_Time],[PreBid_Place],[BidOpening_Date],[BidOpening_Time],[BidOpening_Place],[Project_name])                                       " &
                                          "   VALUES ('" & txtITB_No.Text & "','" & txtITB_Date.Text & "','" & txtPhilGeps_DateFrom.Text & "','" & txtPhilGeps_DateTo.Text & "',    " &
                                          "  '" & txtBidForm_AvailDate.Text & "','" & cbPreBidConference.Checked & "','" & txtPreBid_ConferenceDate.Text & "','" & txtPreBid_ConferenceTime.Text + " " + drpPreBid_ConferenceTime.SelectedItem.Text & "', " &
                                          "  '" & replaceapostrophe(txtPreBid_ConferencePlace.Text) & "','" & txtBidOpening_Date.Text & "','" & txtBidOpening_Time.Text + " " + drpBidOpening_Time.SelectedItem.Text & "','" & replaceapostrophe(txtBidOpening_Place.Text) & "','" & txtProjectName_new.Text & "')", CommandType.Text)

                    Dim hdr_id As Long = objDerived.GetValue("SELECT TOP(1) ITB_Hdr_ID FROM AMS.ITB_Hdr_Limited ORDER BY ITB_Hdr_ID DESC", CommandType.Text)
                    Session("ITB_Hdr_ID_Limited") = hdr_id



                    Dim Sub_No As Char = "@"
                    For i As Integer = 0 To grdITB.Rows.Count - 1
                        If CType(grdITB.Rows(i).FindControl("cb1"), CheckBox).Visible = True Then
                            If CType(grdITB.Rows(i).FindControl("cb1"), CheckBox).Checked = True Then

                                If Sub_No = "@" Then
                                    Sub_No = "a"
                                ElseIf Sub_No = "z" Then
                                    Sub_No = "1"
                                Else
                                    Sub_No = Chr(Asc(Sub_No) + 1)
                                End If

                                Dim ITB_Sub As String = txtITB_No.Text + Sub_No

                                objDerived.Execute("INSERT INTO [AMS].[ITB_Dtl_Limited] ([ITB_Hdr_ID],[OBR_No],[prhdr_id],[ProjectName],[ABC],[Sub_ITBNumb]) " &
                                                      " VALUES(" & hdr_id & ",'" & dtITB.Rows(i)("OBR_No") & "','" & dtITB.Rows(i)("prhdr_id") & "','" & CType(grdITB.Rows(i).FindControl("txtProjectName"), TextBox).Text & "' " &
                                                      " ,'" & dtITB.Rows(i)("ABC") & "', '" & ITB_Sub & "')", CommandType.Text)
                            End If
                        End If
                    Next

                    'Dim Hdr_ID_trap As Integer

                    'Hdr_ID_trap = objDerived.GetValue("select Hdr_ID ams.m_Canvass_Hdr_Limited where PR_Hdr_ID = '" & grdITB.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                    'objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr_Limited SET withWinner = 1 WHERE PR_Hdr_ID = '" & grdITB.SelectedDataKey("prhdr_id") & "' AND Hdr_ID = '" & Hdr_ID_trap & "'", CommandType.Text)
                    'objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr_Limited SET withWinner = 1 WHERE PR_Hdr_ID = '" & grdITB.SelectedDataKey("prhdr_id") & "' AND isDBM = 1", CommandType.Text)


                    'Dim PR_ID As Integer
                    'Dim DTL_ID1 As Integer
                    'DTL_ID1 = objDerived.GetValue("select Dtl_ID1 from [AMS].[m_Canvass_Dtl1_Limited] where Hdr_ID = '" & Hdr_ID_trap & "'", CommandType.Text)


                    'objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 SET isWinner = 1 WHERE Dtl_ID1 = '" & DTL_ID1 & "' AND Supplier_Id = '" & ID & "'", CommandType.Text)
                    'objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl1 SET withWinner = 1 WHERE Dtl_ID1 = '" & DTL_ID1 & "'", CommandType.Text)







                    dtITB = objDerived.GetDataTable("EXEC [AMS].[sp_PreProcurement_ITB_limited]", CommandType.Text)
                    If dtITB.Rows.Count < 5 Then
                        dtITB.Merge(ITB_Table(5 - (dtITB.Rows.Count)))
                    End If
                    grdITB.DataSource = dtITB
                    grdITB.DataBind()

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                    btnSaveITB.Enabled = False
                    btnPreviewITB.Enabled = True
                    btnPreview_FA.Enabled = True

                Else
                    'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "ITB Number already exist.")


                    '====== UPDATE DETAIL
                    objDerived.Execute("UPDATE [AMS].[ITB_Hdr_Limited] SET [ITB_Date]='" & txtITB_Date.Text &
                                       "', [PhilGeps_DateFrom]='" & txtPhilGeps_DateFrom.Text &
                                       "', [PhilGeps_DateTo]='" & txtPhilGeps_DateTo.Text &
                                       "', [BidForm_AvailabilityDate]='" & txtBidForm_AvailDate.Text &
                                       "', [withPreBidConference]='" & cbPreBidConference.Checked &
                                       "', [PreBid_Date]='" & txtPreBid_ConferenceDate.Text &
                                       "', [PreBid_Time]='" & txtPreBid_ConferenceTime.Text &
                                       "', [PreBid_Place]='" & replaceapostrophe(txtPreBid_ConferencePlace.Text) &
                                       "', [BidOpening_Date]='" & txtBidOpening_Date.Text &
                                       "', [BidOpening_Time]='" & txtBidOpening_Time.Text &
                                       "', [BidOpening_Place]='" & replaceapostrophe(txtBidOpening_Place.Text) &
                                       "', [Project_name]='" & txtProjectName_new.Text &
                                       "' WHERE ITB_Hdr_ID='" & ID & "'", CommandType.Text)

                    Session("ITB_Hdr_ID") = ID
                    AddTrace("on  ID2: ITB_Hdr_ID_Limited: " & Session("ITB_Hdr_ID"))


                    Dim Sub_No As Char = "@"
                    For i As Integer = 0 To grdITB.Rows.Count - 1
                        If CType(grdITB.Rows(i).FindControl("cb1"), CheckBox).Visible = True Then
                            If CType(grdITB.Rows(i).FindControl("cb1"), CheckBox).Checked = True Then
                                If Sub_No = "@" Then
                                    Sub_No = "a"
                                ElseIf Sub_No = "z" Then
                                    Sub_No = "1"
                                Else
                                    Sub_No = Chr(Asc(Sub_No) + 1)
                                End If

                                Dim ITB_Sub As String = txtITB_No.Text + Sub_No

                                objDerived.Execute("UPDATE [AMS].[ITB_Dtl_Limited] SET [ProjectName]='" &
                                    CType(grdITB.Rows(i).FindControl("txtProjectName"), TextBox).Text &
                                    "', [Sub_ITBNumb]='" & ITB_Sub &
                                    "' WHERE ITB_Hdr_ID='" & ID & "'", CommandType.Text)
                            End If
                        End If
                    Next

                    dtITB = objDerived.GetDataTable("EXEC [AMS].[sp_PreProcurement_ITB_limited]", CommandType.Text)
                    If dtITB.Rows.Count < 5 Then
                        dtITB.Merge(ITB_Table(5 - (dtITB.Rows.Count)))
                    End If
                    grdITB.DataSource = dtITB
                    grdITB.DataBind()

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                    btnSaveITB.Enabled = False
                    btnPreviewITB.Enabled = True
                    btnPreview_FA.Enabled = True


                End If


            Catch ex As Exception
                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
                msgbox(ex.Message)
            End Try

        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No purchase request has been selected.")
        End If

    End Sub




    Protected Sub CheckITB(sender As Object, e As EventArgs)
        Dim cb As CheckBox = DirectCast(sender, CheckBox)
        Dim row As GridViewRow = DirectCast(cb.NamingContainer, GridViewRow)

        If cb.Checked = True Then
            Dim obr_no As String = grdITB.DataKeys(row.RowIndex).Values("OBR_No").ToString()
            Dim prhdr_id As String = grdITB.DataKeys(row.RowIndex).Values("prhdr_id").ToString()
            Dim ID As Integer = objDerived.GetValue("SELECT ITB_Hdr_ID FROM AMS.ITB_Dtl_Limited WHERE OBR_No = '" & obr_no & "' AND prhdr_id = '" & prhdr_id & "'", CommandType.Text)

            'Uncheck other checkboxes
            For Each gvr As GridViewRow In grdITB.Rows
                If gvr.RowIndex <> row.RowIndex Then
                    Dim othercb As CheckBox = DirectCast(gvr.FindControl("cb1"), CheckBox)
                    If othercb IsNot Nothing Then
                        othercb.Checked = False
                    End If
                End If
            Next

            If ID <> 0 Then
                Dim tbl1 As New DataTable()
                tbl1 = objDerived.GetDataTable("SELECT * FROM [AMS].[ITB_Hdr_Limited] WHERE ITB_Hdr_ID='" & ID & "'", CommandType.Text)

                For i As Integer = 0 To tbl1.Rows.Count - 1
                    txtITB_Date.Text = tbl1.Rows(i)("ITB_Date")
                    txtITB_No.Text = tbl1.Rows(i)("ITB_No")
                    txtPhilGeps_DateFrom.Text = tbl1.Rows(i)("PhilGeps_DateFrom")
                    txtPhilGeps_DateTo.Text = tbl1.Rows(i)("PhilGeps_DateTo")
                    txtBidForm_AvailDate.Text = tbl1.Rows(i)("BidForm_AvailabilityDate")
                    If tbl1.Rows(i)("withPreBidConference") = 0 Then
                        cbPreBidConference.Checked = False
                        txtPreBid_ConferenceDate.Enabled = True
                        txtPreBid_ConferenceTime.Enabled = True
                        txtPreBid_ConferencePlace.Enabled = True
                    ElseIf tbl1.Rows(i)("withPreBidConference") = 1 Then
                        cbPreBidConference.Checked = True
                        txtPreBid_ConferenceDate.Enabled = False
                        txtPreBid_ConferenceTime.Enabled = False
                        txtPreBid_ConferencePlace.Enabled = False
                    End If
                    txtPreBid_ConferenceDate.Text = tbl1.Rows(i)("PreBid_Date")
                    txtPreBid_ConferenceTime.Text = tbl1.Rows(i)("PreBid_Time")
                    txtPreBid_ConferencePlace.Text = tbl1.Rows(i)("PreBid_Place")
                    txtBidOpening_Date.Text = tbl1.Rows(i)("BidOpening_Date")
                    txtBidOpening_Time.Text = tbl1.Rows(i)("BidOpening_Time")
                    txtBidOpening_Place.Text = tbl1.Rows(i)("BidOpening_Place")
                    txtProjectName_new.Text = If(IsDBNull(tbl1.Rows(i)("Project_name")), String.Empty, tbl1.Rows(i)("Project_name").ToString())
                Next
                Session("ITB_Hdr_ID") = ID

                AddTrace("on  ID: ITB_Hdr_ID: " & Session("ITB_Hdr_ID"))
                btnSaveITB.Text = "UPDATE"
            ElseIf ID = 0 Then
                LoadClearITB()
                txtITB_No.Text = objDerived.GetValue("SELECT [AMS].[func_Generate_ITBNo] ('" & Date.Today.ToShortDateString & "')", CommandType.Text)
                btnSaveITB.Text = "SAVE"
            End If
        ElseIf cb.Checked = False Then
            LoadClearITB()
            txtITB_No.Text = objDerived.GetValue("SELECT [AMS].[func_Generate_ITBNo] ('" & Date.Today.ToShortDateString & "')", CommandType.Text)
            btnSaveITB.Text = "SAVE"
        End If
    End Sub


    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)

    End Sub



    Private Sub grdITB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdITB.SelectedIndexChanged
        Try

            objDerived.Execute("DELETE FROM AMS.obr_evaluation_hdr WHERE obr_evaluation_hdr_id = '" & grdITB.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)
            objDerived.Execute("DELETE FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id = '" & grdITB.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)
            objDerived.Execute("UPDATE AMS.PR_Hdr SET mode_of_procurement_id = 0, isOnBid = 0 WHERE prhdr_id = '" & grdITB.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected purchase request has been successfully returned.")

            LoadTab()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")

        End Try

    End Sub
    Private Sub cbPreBidConference_CheckedChanged(sender As Object, e As EventArgs) Handles cbPreBidConference.CheckedChanged
        If cbPreBidConference.Checked = True Then
            txtPreBid_ConferenceDate.Enabled = False
            txtPreBid_ConferenceTime.Enabled = False
            drpPreBid_ConferenceTime.Enabled = False
            txtPreBid_ConferencePlace.Enabled = False

            Session("Report") = "ITB w/o PreBid"

        Else
            txtPreBid_ConferenceDate.Enabled = True
            txtPreBid_ConferenceTime.Enabled = True
            drpPreBid_ConferenceTime.Enabled = True
            txtPreBid_ConferencePlace.Enabled = True

            Session("Report") = "ITB with PreBid"


        End If


    End Sub
    Private Sub txtITB_Date_TextChanged(sender As Object, e As EventArgs) Handles txtITB_Date.TextChanged
        txtITB_No.Text = objDerived.GetValue("SELECT [AMS].[func_Generate_ITBNo] ('" & CType(txtITB_Date.Text, Date) & "')", CommandType.Text)
    End Sub
    Private Sub btnPreviewITB_Click(sender As Object, e As EventArgs) Handles btnPreviewITB.Click
        Session("Page") = "ITB"
        Session("Back") = "Bidding"
        Session("ITB") = "Limited"
        'Me.Page.Response.Redirect("~/MainReports/BiddingReports.aspx")

        Dim url As String = "BiddingReports.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)




    End Sub
    Private Sub btnPreview_FA_Click(sender As Object, e As EventArgs) Handles btnPreview_FA.Click
        Dim url As String = "../MainReports/FrameworkAgreement.aspx"
        Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)

    End Sub
    Protected Sub loadPreprocurement()
        dtPreProcurement = objDerived.GetDataTable(
    "SELECT DISTINCT " &
      "A.ITB_Date,  " &
      "CASE WHEN (SELECT COUNT(X.ITB_Dtl_ID) " &
      "           FROM AMS.ITB_Dtl AS X " &
      "          WHERE X.ITB_Hdr_ID = A.ITB_Hdr_ID) = 1 " &
      "     THEN A.ITB_No ELSE E.Sub_ITBNumb END AS ITB_No,  " &
      "B.ProjectName, B.ABC, A.BidOpening_Date, A.BidOpening_Time, A.BidOpening_Place,  " &
      "C.obr_evaluation_hdr_id, C.obr_evaluation_dtl_id,  " &
      "A.ITB_Hdr_ID, B.ITB_Dtl_ID, D.Transaction_type, CONVERT(BIT, 1) AS isVisible  " &
    "FROM AMS.ITB_Hdr_Limited AS A  " &
    "INNER JOIN AMS.ITB_Dtl_Limited AS B  ON A.ITB_Hdr_ID = B.ITB_Hdr_ID  " &
    "INNER JOIN AMS.obr_evaluation_dtl AS C ON B.prhdr_id = C.prhdr_id  " &
    "INNER JOIN AMS.PR_Hdr AS D         ON B.prhdr_id = D.prhdr_id  " &
    "INNER JOIN AMS.ITB_Dtl_Limited AS E ON A.ITB_Hdr_ID = E.ITB_Hdr_ID  " &
    "                                    AND D.prhdr_id = E.prhdr_id  " &
    "WHERE NOT EXISTS (  " &
    "      SELECT 1  " &
    "        FROM AMS.pre_procurement pp  " &
    "       WHERE pp.obr_evaluation_hdr_id = C.obr_evaluation_hdr_id  " &
    "         AND pp.BAC1 IS NOT NULL  " &
    "         AND pp.BAC2 IS NOT NULL  " &
    "         AND pp.BAC3 IS NOT NULL  " &
    "         AND (pp.declarationDate IS NULL  " &
    "              OR pp.declarationDate <> '1900-01-01 00:00:00.000')  " &
    " )  " &
    "ORDER BY A.ITB_Date DESC, ITB_No, B.ProjectName",
    CommandType.Text)


        If dtPreProcurement.Rows.Count < 5 Then
            dtPreProcurement.Merge(PreProc_Table(5 - dtPreProcurement.Rows.Count))
        End If
        grdPreProcurement.DataSource = dtPreProcurement
        grdPreProcurement.DataBind()
    End Sub
    Private Sub btnSavePreProc_Click(sender As Object, e As EventArgs) Handles btnSavePreProc.Click
        Try
            Dim MOP As Integer = objDerived.GetValue("Select mode_of_procurement_id from ams.mode_of_procurement where mode_description='Limited Source'", CommandType.Text)
            With hdr
                .obr_evaluation_hdr_id = grdPreProcurement.SelectedDataKey("obr_evaluation_hdr_id")
                .bid_docs = txtBidDoc_Amt.Text
                .mode_of_procurement_id = MOP
                .project_name = grdPreProcurement.SelectedDataKey("ProjectName")
                .project_location = txtProjectLocation.Text
                .project_reference_no = grdPreProcurement.SelectedDataKey("ITB_No")
                .ABC = grdPreProcurement.SelectedDataKey("ABC")
                .opening_venue = grdPreProcurement.SelectedDataKey("BidOpening_Place")
                .opening_date = grdPreProcurement.SelectedDataKey("BidOpening_Date")
                .opening_time = grdPreProcurement.SelectedDataKey("BidOpening_Time")
                .Transaction_type = grdPreProcurement.SelectedDataKey("Transaction_type")
                .transaction_date = grdPreProcurement.SelectedDataKey("BidOpening_Date")
                .withBid = False
                .isRebid = False
                .withWinner = False
                .withPO = False
                .BACC = ""
                .BACVC = ""
                .BAC1 = ""
                .BAC2 = ""
                .BAC3 = ""
                .TWGH = ""
                .TWGM = ""
                .ENDUSER = ""
                .F_ID = 1
                .resolution_number_date = "01/01/1900"
                .declarationDate = "01/01/1900"
                .withNOA = False
                .withNTP = False
                .dateNTP = "01/01/1900"
                .dateNOA = "01/01/1900"

                If rbBidCategory.SelectedItem.Value = 1 Then
                    .isPublicInfra = False
                ElseIf rbBidCategory.SelectedItem.Value = 2 Then
                    .isPublicInfra = True
                End If

            End With


            Dim hdrid As Long = hdr.save()
            Session("pre_procurement_hdr_id") = hdrid

            With dtl
                .pre_procurement_hdr_id = hdrid
                .obr_evaluation_dtl_id = grdPreProcurement.SelectedDataKey("obr_evaluation_dtl_id")
                .ABC = grdPreProcurement.SelectedDataKey("ABC")
                .save()
            End With

            objDerived.GetRecords("UPDATE AMS.obr_evaluation_hdr SET withPreProcurement = 1 WHERE obr_evaluation_hdr_id = '" & grdPreProcurement.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)
            loadPreprocurement()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            btnPreviewBidForm.Enabled = True
            btnPreviewOP.Enabled = True
            btnSavePreProc.Enabled = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")

        End Try
    End Sub
    Private Sub grdPreProcurement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPreProcurement.SelectedIndexChanged

        'If CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) <= 500000 Then
        '    txtBidDoc_Amt.Text = FormatNumber(500, 2)
        'ElseIf CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) > 500000 And CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) <= 1000000 Then
        '    txtBidDoc_Amt.Text = FormatNumber(1000, 2)
        'ElseIf CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) > 1000000 And CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) <= 5000000 Then
        '    txtBidDoc_Amt.Text = FormatNumber(5000, 2)
        'ElseIf CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) > 5000000 And CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) <= 10000000 Then
        '    txtBidDoc_Amt.Text = FormatNumber(10000, 2)
        'ElseIf CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) > 10000000 And CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) <= 50000000 Then
        '    txtBidDoc_Amt.Text = FormatNumber(25000, 2)
        'ElseIf CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) > 50000000 And CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) <= 500000000 Then
        '    txtBidDoc_Amt.Text = FormatNumber(50000, 2)
        'ElseIf CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal) > 500000000 Then
        '    txtBidDoc_Amt.Text = FormatNumber(75000, 2)
        'End If

        'txtBidDoc_Amt.ReadOnly = True

        ''Optimize
        Dim abcValue As Decimal = CType(grdPreProcurement.SelectedDataKey("ABC"), Decimal)
        Dim bidDocAmount As Decimal

        Select Case abcValue
            Case <= 500000
                bidDocAmount = 500
            Case <= 1000000
                bidDocAmount = 1000
            Case <= 5000000
                bidDocAmount = 5000
            Case <= 10000000
                bidDocAmount = 10000
            Case <= 50000000
                bidDocAmount = 25000
            Case <= 500000000
                bidDocAmount = 50000
            Case Else
                bidDocAmount = 75000
        End Select

        txtBidDoc_Amt.Text = FormatNumber(bidDocAmount, 2)
        txtBidDoc_Amt.ReadOnly = True

    End Sub
    Private Sub btnPreviewBidForm_Click(sender As Object, e As EventArgs) Handles btnPreviewBidForm.Click
        Session("Page") = "PreProc"
        Session("Report") = "BidForm"
        Me.Page.Response.Redirect("~/MainReports/BiddingReports.aspx")
    End Sub
    Private Sub btnPreviewOP_Click(sender As Object, e As EventArgs) Handles btnPreviewOP.Click
        Session("Page") = "PreProc"
        Session("Report") = "OP"
        'Me.Page.Response.Redirect("~/MainReports/BiddingReports.aspx")

        Dim url As String = "BiddingReports.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)




    End Sub
End Class
