Imports System.Data
Partial Class bidding_Bidding_Infra_Infra_PreProcurement
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

#Region "Variables"
    Private Property dtPreProc() As DataTable
        Get
            Return CType(Session("dtPreProc"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPreProc") = value
        End Set
    End Property
    Private Property dtITB() As DataTable
        Get
            Return CType(Session("dtITB"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtITB") = value
        End Set
    End Property
    Private Property dtPBD() As DataTable
        Get
            Return CType(Session("dtPBD"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPBD") = value
        End Set
    End Property
    Private Property dtOpening() As DataTable
        Get
            Return CType(Session("dtOpening"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtOpening") = value
        End Set
    End Property
    Private Property Action() As String
        Get
            Return CType(Session("Action"), String)
        End Get
        Set(ByVal value As String)
            Session("Action") = value
        End Set
    End Property
    Public Function dtTemp_PreProc(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Bid_ID", GetType(Integer))
        dt.Columns.Add("OBR_Hdr_ID", GetType(Long))
        dt.Columns.Add("RC_ID", GetType(Long))
        dt.Columns.Add("Function_ID", GetType(Long))
        dt.Columns.Add("Program_ID", GetType(Long))
        dt.Columns.Add("Project_ID", GetType(Long))
        dt.Columns.Add("ITB_No", GetType(String))
        dt.Columns.Add("OBR_Date", GetType(Date))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("PPA", GetType(String))
        dt.Columns.Add("Amount", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Bid_ID") = DBNull.Value
            dr("OBR_Hdr_ID") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("Program_ID") = DBNull.Value
            dr("Project_ID") = DBNull.Value
            dr("ITB_No") = DBNull.Value
            dr("OBR_Date") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("PPA") = DBNull.Value
            dr("Amount") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function dtTemp_Eligibility(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("Philgeps", GetType(Boolean))
        dt.Columns.Add("isOngoing", GetType(Boolean))
        dt.Columns.Add("isSLCC", GetType(Boolean))
        dt.Columns.Add("isNFCC", GetType(Boolean))
        dt.Columns.Add("isJVA", GetType(Boolean))
        dt.Columns.Add("OngoingContracts", GetType(String))
        dt.Columns.Add("SLCC", GetType(String))
        dt.Columns.Add("NFCC", GetType(String))
        dt.Columns.Add("JVA", GetType(String))
        dt.Columns.Add("Supplier_ID", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = DBNull.Value
            dr("Philgeps") = False
            dr("isOngoing") = False
            dr("isSLCC") = False
            dr("isNFCC") = False
            dr("isJVA") = False
            dr("OngoingContracts") = DBNull.Value
            dr("SLCC") = DBNull.Value
            dr("NFCC") = DBNull.Value
            dr("JVA") = DBNull.Value
            dr("Supplier_ID") = 0
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
#End Region


    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Private Sub bidding_Bidding_Infra_Infra_PreProcurement_Load(sender As Object, e As EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@username"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then

            '--- DEFAULT DISPLAY - PRE PROCUREMENT
            txtDate_PreProc.Text = Date.Today.ToShortDateString

            dtPreProc = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_BidPreparation] 'PreProc'", CommandType.Text)
            If dtPreProc.Rows.Count < 5 Then
                dtPreProc.Merge(dtTemp_PreProc(4 - dtPreProc.Rows.Count))
            End If
            grdPreProc.DataSource = dtPreProc
            grdPreProc.DataBind()

            btnTab1_PreProcurement.CssClass = "TabButton_Active"
            btnTab2_ITB.CssClass = "TabButton_InActive"
            btnTab3_PBD.CssClass = "TabButton_InActive"

            Me.mvTabs.SetActiveView(Me.vwTab1_PreProc)


        End If

        txtSearch_PreProc.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_PreProc.ClientID & "')")
        txtSearch_ITB.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_ITB.ClientID & "')")

    End Sub

    Private Sub btnTab1_PreProcurement_Click(sender As Object, e As EventArgs) Handles btnTab1_PreProcurement.Click
        Try
            txtDate_PreProc.Text = Date.Today.ToShortDateString

            dtPreProc = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_BidPreparation] 'PreProc'", CommandType.Text)
            If dtPreProc.Rows.Count < 5 Then
                dtPreProc.Merge(dtTemp_PreProc(4 - dtPreProc.Rows.Count))
            End If
            grdPreProc.DataSource = dtPreProc
            grdPreProc.DataBind()
            grdPreProc.SelectedIndex = -1

            btnTab1_PreProcurement.CssClass = "TabButton_Active"
            btnTab2_ITB.CssClass = "TabButton_InActive"
            btnTab3_PBD.CssClass = "TabButton_InActive"
            btnTab4_Opening.CssClass = "TabButton_InActive"

            Me.mvTabs.SetActiveView(Me.vwTab1_PreProc)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Private Sub btnTab2_ITB_Click(sender As Object, e As EventArgs) Handles btnTab2_ITB.Click
        Try
            dtITB = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_BidPreparation] 'ITB'", CommandType.Text)
            If dtITB.Rows.Count < 5 Then
                dtITB.Merge(dtTemp_PreProc(4 - dtITB.Rows.Count))
            End If
            grdITB.DataSource = dtITB
            grdITB.DataBind()
            grdITB.SelectedIndex = -1

            btnTab1_PreProcurement.CssClass = "TabButton_InActive"
            btnTab2_ITB.CssClass = "TabButton_Active"
            btnTab3_PBD.CssClass = "TabButton_InActive"
            btnTab4_Opening.CssClass = "TabButton_InActive"

            Me.mvTabs.SetActiveView(Me.vwTab2_ITB)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnTab3_PBD_Click(sender As Object, e As EventArgs) Handles btnTab3_PBD.Click
        Try


            dtPBD = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_BidPreparation] 'PBD'", CommandType.Text)
            If dtPBD.Rows.Count < 5 Then
                dtPBD.Merge(dtTemp_PreProc(4 - dtPBD.Rows.Count))
            End If
            grdPBD.DataSource = dtPBD
            grdPBD.DataBind()
            grdPBD.SelectedIndex = -1

            btnTab1_PreProcurement.CssClass = "TabButton_InActive"
            btnTab2_ITB.CssClass = "TabButton_InActive"
            btnTab3_PBD.CssClass = "TabButton_Active"
            btnTab4_Opening.CssClass = "TabButton_InActive"

            Me.mvTabs.SetActiveView(Me.vwTab3_PBD)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnTab4_Opening_Click(sender As Object, e As EventArgs) Handles btnTab4_Opening.Click
        Try
            dtOpening = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_BidPreparation] 'OPENING'", CommandType.Text)
            If dtOpening.Rows.Count < 5 Then
                dtOpening.Merge(dtTemp_PreProc(4 - dtOpening.Rows.Count))
            End If
            grdOpening.DataSource = dtOpening
            grdOpening.DataBind()
            grdOpening.SelectedIndex = -1

            drpAddBidder.DataSource = objDerived.GetDataTable("SELECT SuppName, Supplier_Id FROM DBO.Supplier ORDER BY SuppName", CommandType.Text)
            drpAddBidder.DataTextField = "SuppName"
            drpAddBidder.DataValueField = "Supplier_Id"
            drpAddBidder.DataBind()
            drpAddBidder.Items.Insert(0, "Select")

            btnAddBidder.Enabled = False
            grdBidders.DataSource = Nothing
            grdBidders.DataBind()

            btnTab1_PreProcurement.CssClass = "TabButton_InActive"
            btnTab2_ITB.CssClass = "TabButton_InActive"
            btnTab3_PBD.CssClass = "TabButton_InActive"
            btnTab4_Opening.CssClass = "TabButton_Active"

            Me.mvTabs.SetActiveView(Me.vwTab4_Opening)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub





    '----- PRE PROCUREMENT
    Private Sub btnSearch_PreProc_Click(sender As Object, e As EventArgs) Handles btnSearch_PreProc.Click
        Try

            Dim myview As DataView
            myview = dtPreProc.DefaultView

            If drpSearch_PreProc.SelectedItem.Value = 1 Then
                myview.RowFilter = "OBR_No like '%" & replaceapostrophe(txtSearch_PreProc.Text) & "%'"
            Else
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtSearch_PreProc.Text) & "%'"
            End If

            grdPreProc.DataSource = myview
            grdPreProc.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdPreProc_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdPreProc.PageIndexChanging
        grdPreProc.DataSource = dtPreProc
        grdPreProc.PageIndex = e.NewPageIndex
        grdPreProc.DataBind()
    End Sub
    Private Sub grdPreProc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPreProc.SelectedIndexChanged
        Try

            drpMOP.DataSource = objDerived.GetDataTable("SELECT mode_of_procurement_id, mode_description FROM AMS.mode_of_procurement ORDER BY mode_of_procurement_id", CommandType.Text)
            drpMOP.DataTextField = "mode_description"
            drpMOP.DataValueField = "mode_of_procurement_id"
            drpMOP.DataBind()
            drpMOP.SelectedValue = 1


            Dim dtBAC As New DataTable
            dtBAC = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, empsig_id, UPPER(Position_desc) as Position_desc  FROM dbo.View_BAC ORDER BY Name", CommandType.Text)
            drpBAC1.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 3", CommandType.Text)
            drpBAC1.DataTextField = ("Name")
            drpBAC1.DataValueField = ("empsig_id")
            drpBAC1.DataBind()

            drpBAC2.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 4", CommandType.Text)
            drpBAC2.DataTextField = ("Name")
            drpBAC2.DataValueField = ("empsig_id")
            drpBAC2.DataBind()

            drpBAC3.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 5", CommandType.Text)
            drpBAC3.DataTextField = ("Name")
            drpBAC3.DataValueField = ("empsig_id")
            drpBAC3.DataBind()

            drpBACVC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 2", CommandType.Text)
            drpBACVC.DataTextField = ("Name")
            drpBACVC.DataValueField = ("empsig_id")
            drpBACVC.DataBind()

            drpBACC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 1", CommandType.Text)
            drpBACC.DataTextField = ("Name")
            drpBACC.DataValueField = ("empsig_id")
            drpBACC.DataBind()

            drpApprovedBy.DataSource = objDerived.GetDataTable("SELECT empid, UPPER(full_name) AS full_name FROM HRMS.view_signatory WHERE deptid IN (1,2,3,8,13,104) AND division_key = 86 AND isDeptHead = 'Yes' ORDER BY full_name", CommandType.Text)
            drpApprovedBy.DataTextField = ("full_name")
            drpApprovedBy.DataValueField = ("empid")
            drpApprovedBy.DataBind()
            drpApprovedBy.Items.Insert(0, "Select")

            btnSave_PreProc.Enabled = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSave_PreProc_Click(sender As Object, e As EventArgs) Handles btnSave_PreProc.Click
        Try
            If drpApprovedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select approved by signatory.")

            Else
                objDerived.Execute("INSERT INTO [AMS].[tbl_Infra_BidPreparation] ([OBR_Hdr_ID],[RC_ID],[Function_ID],[Program_ID],[Project_ID],[ProjectName],[Amount],[withPreProc],[MOP],[PreProc_Date],[PreProc_Remarks],[BAC1],[BAC2],[BAC3],[BACVC],[BACC],[ApprovedBy],[UserID]) " &
                                 "  VALUES                                                     " &
                                 "  ('" & grdPreProc.SelectedDataKey("OBR_Hdr_ID") & "'        " &
                                 "  ,'" & grdPreProc.SelectedDataKey("RC_ID") & "'              " &
                                 "  ,'" & grdPreProc.SelectedDataKey("Function_ID") & "'        " &
                                 "  ,'" & grdPreProc.SelectedDataKey("Program_ID") & "'        " &
                                 "  ,'" & grdPreProc.SelectedDataKey("Project_ID") & "'        " &
                                 "  ,'" & grdPreProc.SelectedDataKey("PPA") & "'               " &
                                 "  ,'" & grdPreProc.SelectedDataKey("Amount") & "'            " &
                                 "  ,1                                                         " &
                                 "  ,'" & drpMOP.SelectedItem.Value & "'                       " &
                                 "  ,'" & CType(txtDate_PreProc.Text, Date) & "'               " &
                                 "  ,'" & replaceapostrophe(txtRemarks_PreProc.Text) & "'      " &
                                 "  ,'" & drpBAC1.SelectedItem.Value & "'                      " &
                                 "  ,'" & drpBAC2.SelectedItem.Value & "'                      " &
                                 "  ,'" & drpBAC3.SelectedItem.Value & "'                      " &
                                 "  ,'" & drpBACVC.SelectedItem.Value & "'                     " &
                                 "  ,'" & drpBACC.SelectedItem.Value & "'                      " &
                                 "  ,'" & drpApprovedBy.SelectedItem.Value & "'                " &
                                 "  ,'" & Session("@username") & "')", CommandType.Text)


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                btnSave_PreProc.Enabled = False

                txtDate_PreProc.Text = Date.Today.ToShortDateString
                txtRemarks_PreProc.Text = ""

                dtPreProc = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_BidPreparation] 'PreProc'", CommandType.Text)
                If dtPreProc.Rows.Count < 5 Then
                    dtPreProc.Merge(dtTemp_PreProc(4 - dtPreProc.Rows.Count))
                End If
                grdPreProc.DataSource = dtPreProc
                grdPreProc.DataBind()
            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub




    '----- INVITATION TO BID
    Private Sub btnSearch_ITB_Click(sender As Object, e As EventArgs) Handles btnSearch_ITB.Click
        Try

            Dim myview As DataView
            myview = dtITB.DefaultView

            If drpSearch_PreProc.SelectedItem.Value = 1 Then
                myview.RowFilter = "OBR_No like '%" & replaceapostrophe(txtSearch_ITB.Text) & "%'"
            Else
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtSearch_ITB.Text) & "%'"
            End If

            grdITB.DataSource = myview
            grdITB.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdITB_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdITB.PageIndexChanging
        grdITB.DataSource = dtITB
        grdITB.PageIndex = e.NewPageIndex
        grdITB.DataBind()
    End Sub
    Private Sub grdITB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdITB.SelectedIndexChanged
        Try
            txtITB_Date.Text = Date.Today.ToShortDateString
            txtITB_No.Text = "ITB" & CType(txtITB_Date.Text, Date).ToString("yy") & "-" & CType(txtITB_Date.Text, Date).ToString("MM") & "-"
            txtPhilGeps_DateFrom.Text = Date.Today.ToShortDateString
            txtPhilGeps_DateTo.Text = Date.Today.ToShortDateString
            txtBidForm_AvailDate.Text = Date.Today.ToShortDateString

            txtPreBid_ConferenceDate.Text = Date.Today.ToShortDateString
            txtPreBid_ConferenceTime.Text = "1:00"
            txtPreBid_ConferencePlace.Text = ""

            txtBidOpening_Date.Text = Date.Today.ToShortDateString
            txtBidOpening_Time.Text = "1:00"
            txtBidOpening_Place.Text = ""

            btnSave_ITB.Enabled = True


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub cbPreBidConference_CheckedChanged(sender As Object, e As EventArgs) Handles cbPreBidConference.CheckedChanged
        If cbPreBidConference.Checked = True Then
            txtPreBid_ConferenceDate.Enabled = False
            txtPreBid_ConferenceTime.Enabled = False
            drpPreBid_ConferenceTime.Enabled = False
            txtPreBid_ConferencePlace.Enabled = False

        Else
            txtPreBid_ConferenceDate.Enabled = True
            txtPreBid_ConferenceTime.Enabled = True
            drpPreBid_ConferenceTime.Enabled = True
            txtPreBid_ConferencePlace.Enabled = True

        End If
    End Sub
    Private Sub btnSave_ITB_Click(sender As Object, e As EventArgs) Handles btnSave_ITB.Click
        Try
            If txtBidOpening_Place.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Place of bid opening is required.")
            Else
                Dim ITB As String = objDerived.GetValue("SELECT [AMS].[func_Generate_ITBNo] ('" & CType(txtITB_Date.Text, Date) & "')", CommandType.Text)

                objDerived.Execute("EXEC [AMS].[sp_Save_Infra_ITB] '" & grdITB.SelectedDataKey("Bid_ID") & "','" & txtITB_Date.Text & "','" & ITB & "','" & txtPhilGeps_DateFrom.Text & "','" & txtPhilGeps_DateTo.Text & "' " &
                                   " ,'" & txtBidForm_AvailDate.Text & "','" & cbPreBidConference.Checked & "','" & txtPreBid_ConferenceDate.Text & "','" & txtPreBid_ConferenceTime.Text + " " + drpPreBid_ConferenceTime.SelectedItem.Text & "' " &
                                   " ,'" & replaceapostrophe(txtPreBid_ConferencePlace.Text) & "','" & txtBidOpening_Date.Text & "','" & txtBidOpening_Time.Text + " " + drpBidOpening_Time.SelectedItem.Text & "' " &
                                   " ,'" & replaceapostrophe(txtBidOpening_Place.Text) & "','" & grdITB.SelectedDataKey("OBR_No") & "','" & grdITB.SelectedDataKey("PPA") & "','" & grdITB.SelectedDataKey("Amount") & "'", CommandType.Text)

                Session("ITB_Hdr_ID") = objDerived.GetValue("SELECT TOP(1) ITB_Hdr_ID FROM AMS.ITB_Hdr ORDER BY ITB_Hdr_ID DESC", CommandType.Text)
                Session("Infra_BidPrep_ID") = grdITB.SelectedDataKey("Bid_ID")
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                txtITB_Date.Text = Date.Today.ToShortDateString
                txtITB_No.Text = ""
                txtPhilGeps_DateFrom.Text = Date.Today.ToShortDateString
                txtPhilGeps_DateTo.Text = Date.Today.ToShortDateString
                txtBidForm_AvailDate.Text = Date.Today.ToShortDateString

                txtPreBid_ConferenceDate.Text = Date.Today.ToShortDateString
                txtPreBid_ConferenceTime.Text = "1:00"
                txtPreBid_ConferencePlace.Text = ""

                txtBidOpening_Date.Text = Date.Today.ToShortDateString
                txtBidOpening_Time.Text = "1:00"
                txtBidOpening_Place.Text = ""


                btnSave_ITB.Enabled = False
                btnPreview_ITB.Enabled = True
                btnPreview_Cert.Enabled = True


                dtITB = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_BidPreparation] 'ITB'", CommandType.Text)
                If dtITB.Rows.Count < 5 Then
                    dtITB.Merge(dtTemp_PreProc(4 - dtITB.Rows.Count))
                End If
                grdITB.DataSource = dtITB
                grdITB.DataBind()
                grdITB.SelectedIndex = -1

                'txtDisplay_ITBNo.Text = ITB
                'ModalPopupExtender1.Show()

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnPreview_ITB_Click(sender As Object, e As EventArgs) Handles btnPreview_ITB.Click
        Session("Report") = "ITB"
        Session("Page") = "Infra_Prep"

        Dim url As String = "../../MainReports/rpt_Infra_Reports.aspx"
        Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)

    End Sub
    Private Sub btnPreview_Cert_Click(sender As Object, e As EventArgs) Handles btnPreview_Cert.Click
        Session("Report") = "BAC_Cert"
        Session("Page") = "Infra_Prep"

        Dim url As String = "../../MainReports/rpt_Infra_Reports.aspx"
        Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)
    End Sub




    '----- PRE BID OPENING
    Private Sub btnSearch_PBD_Click(sender As Object, e As EventArgs) Handles btnSearch_PBD.Click
        Try

            Dim myview As DataView
            myview = dtPBD.DefaultView

            If drpSearch_PreProc.SelectedItem.Value = 1 Then
                myview.RowFilter = "ITB_No like '%" & replaceapostrophe(txtSearch_PBD.Text) & "%'"

            ElseIf drpSearch_PreProc.SelectedItem.Value = 2 Then
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtSearch_PBD.Text) & "%'"

            Else
                myview.RowFilter = "OBR_No like '%" & replaceapostrophe(txtSearch_PBD.Text) & "%'"
            End If

            grdPBD.DataSource = myview
            grdPBD.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdPBD_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdPBD.PageIndexChanging
        grdPBD.DataSource = dtPBD
        grdPBD.PageIndex = e.NewPageIndex
        grdPBD.DataBind()
    End Sub
    Private Sub grdPBD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPBD.SelectedIndexChanged
        Try
            Session("PPA") = grdPBD.SelectedDataKey("PPA")
            txtBidDoc_Amt.Text = "0.00"
            btnSave_PBD.Enabled = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSave_PBD_Click(sender As Object, e As EventArgs) Handles btnSave_PBD.Click
        Try
            If txtBidDoc_Amt.Text = "0.00" Or txtProjectLocation.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "All fields are required.")

            Else
                objDerived.Execute("UPDATE AMS.tbl_Infra_BidPreparation SET withPBD = 1, withAddendum = '" & cbwithAddendum.Checked & "', BidDoc_Amt = '" & CType(txtBidDoc_Amt.Text, Decimal) & "', Project_Loc = '" & replaceapostrophe(txtProjectLocation.Text) & "' WHERE Infra_BidPrep_ID = '" & grdPBD.SelectedDataKey("Bid_ID") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                Session("Infra_BidPrep_ID") = grdPBD.SelectedDataKey("Bid_ID")

                btnSave_PBD.Enabled = False
                btnPreview_OP.Enabled = True
                btnPreview_BidForm.Enabled = True

                txtBidDoc_Amt.Text = "0.00"
                txtProjectLocation.Text = ""
                cbwithAddendum.Checked = False

                dtPBD = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_BidPreparation] 'PBD'", CommandType.Text)
                If dtPBD.Rows.Count < 5 Then
                    dtPBD.Merge(dtTemp_PreProc(4 - dtPBD.Rows.Count))
                End If
                grdPBD.DataSource = dtPBD
                grdPBD.DataBind()
                grdPBD.SelectedIndex = -1

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnPreview_OP_Click(sender As Object, e As EventArgs) Handles btnPreview_OP.Click
        Session("Report") = "OP"
        Session("Page") = "Infra_Prep"
        Session("Bidder") = " "

        Dim url As String = "../../MainReports/rpt_Infra_Reports.aspx"
        Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)
    End Sub
    Private Sub btnPreview_BidForm_Click(sender As Object, e As EventArgs) Handles btnPreview_BidForm.Click
        Session("Report") = "BidForm"

        Dim url As String = "Infra_ReportEncoding.aspx"
        Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)
    End Sub





    '----- BID OPENING
    Private Sub btnSearch_Opening_Click(sender As Object, e As EventArgs) Handles btnSearch_Opening.Click
        Try

            Dim myview As DataView
            myview = dtOpening.DefaultView

            If drpSearch_Opening.SelectedItem.Value = 1 Then
                myview.RowFilter = "ITB_No like '%" & replaceapostrophe(txtSearch_Opening.Text) & "%'"

            ElseIf drpSearch_Opening.SelectedItem.Value = 2 Then
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtSearch_Opening.Text) & "%'"

            Else
                myview.RowFilter = "OBR_No like '%" & replaceapostrophe(txtSearch_Opening.Text) & "%'"
            End If

            grdOpening.DataSource = myview
            grdOpening.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdOpening_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdOpening.PageIndexChanging
        grdOpening.DataSource = dtOpening
        grdOpening.PageIndex = e.NewPageIndex
        grdOpening.DataBind()
        grdOpening.SelectedIndex = -1
    End Sub
    Private Sub grdOpening_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdOpening.SelectedIndexChanged
        Try
            Session("Infra_BidPrep_ID") = grdOpening.SelectedDataKey("Bid_ID")
            btnAddBidder.Enabled = True
            LoadBidders()

            If grdBidders.Rows.Count <> 0 Then
                btnSave_Opening.Enabled = True
            Else
                btnSave_Opening.Enabled = False
            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnAddBidder_Click(sender As Object, e As EventArgs) Handles btnAddBidder.Click
        Try
            Dim id As Integer = objDerived.GetValue("SELECT Infra_Bidders_ID FROM [AMS].[tbl_Infra_InterestedBidders] WHERE Infra_BidPrep_ID = '" & grdOpening.SelectedDataKey("Bid_ID") & "' AND Supplier_ID = '" & drpAddBidder.SelectedItem.Value & "'", CommandType.Text)
            If id = 0 Then
                objDerived.Execute("INSERT INTO [AMS].[tbl_Infra_InterestedBidders] ([Infra_BidPrep_ID],[Supplier_ID]) VALUES('" & grdOpening.SelectedDataKey("Bid_ID") & "','" & drpAddBidder.SelectedItem.Value & "')", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Bidder has been successfully added.")
                LoadBidders()

            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Bidder already in the list.")

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub LoadBidders()
        grdBidders.DataSource = objDerived.GetDataTable("SELECT A.Infra_Bidders_ID, A.Infra_BidPrep_ID, A.Supplier_ID, B.SuppName FROM [AMS].[tbl_Infra_InterestedBidders] AS A  " &
                                    " INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id WHERE A.Infra_BidPrep_ID = '" & grdOpening.SelectedDataKey("Bid_ID") & "' ORDER BY B.SuppName", CommandType.Text)
        grdBidders.DataBind()
        grdBidders.SelectedIndex = -1

    End Sub

    Protected Sub lnkSelect_Bidder_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Action = "Select"
    End Sub
    Protected Sub lnkRemove_Bidder_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Action = "Remove"
    End Sub


    Private Sub grdBidders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdBidders.SelectedIndexChanged
        Try
            If Action = "Select" Then
                Session("Report") = "OP"
                Session("Page") = "Infra_Prep"
                Session("Bidder") = grdBidders.SelectedDataKey("SuppName")

                Dim url As String = "../../MainReports/rpt_Infra_Reports.aspx"
                Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
                ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)

            ElseIf Action = "Remove" Then
                objDerived.Execute("DELETE FROM [AMS].[tbl_Infra_InterestedBidders] WHERE Infra_Bidders_ID = '" & grdBidders.SelectedDataKey("Infra_Bidders_ID") & "'", CommandType.Text)
                LoadBidders()
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected bidder has been successfully removed.")

            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Session timeout, pls refresh the page to continue.")
            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnSave_Opening_Click(sender As Object, e As EventArgs) Handles btnSave_Opening.Click
        Try
            objDerived.Execute("UPDATE AMS.tbl_Infra_BidPreparation SET withOpening = 1 WHERE Infra_BidPrep_ID = '" & grdOpening.SelectedDataKey("Bid_ID") & "'", CommandType.Text)

            dtOpening = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_BidPreparation] 'OPENING'", CommandType.Text)
            If dtOpening.Rows.Count < 5 Then
                dtOpening.Merge(dtTemp_PreProc(4 - dtOpening.Rows.Count))
            End If
            grdOpening.DataSource = dtOpening
            grdOpening.DataBind()
            grdOpening.SelectedIndex = -1

            drpAddBidder.DataSource = objDerived.GetDataTable("SELECT SuppName, Supplier_Id FROM DBO.Supplier ORDER BY SuppName", CommandType.Text)
            drpAddBidder.DataTextField = "SuppName"
            drpAddBidder.DataValueField = "Supplier_Id"
            drpAddBidder.DataBind()
            drpAddBidder.Items.Insert(0, "Select")

            btnAddBidder.Enabled = False
            grdBidders.DataSource = Nothing
            grdBidders.DataBind()

            btnSave_Opening.Enabled = False

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfullY saved.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
End Class
