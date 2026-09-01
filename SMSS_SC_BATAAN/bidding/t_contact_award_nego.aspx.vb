Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_t_contact_award_nego
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private Bid As New Bid_information
    Dim obj As New AccessRule

#Region "Property"
    Private Property dtAbstract() As DataTable
        Get
            Return CType(Session("dtAbstract"), DataTable)
        End Get
        Set(value As DataTable)
            Session("dtAbstract") = value
        End Set
    End Property

    Private Property dtResolution() As DataTable
        Get
            Return CType(Session("dtResolution"), DataTable)
        End Get
        Set(value As DataTable)
            Session("dtResolution") = value
        End Set
    End Property

    Private Property dtNTP() As DataTable
        Get
            Return CType(Session("dtNTP"), DataTable)
        End Get
        Set(value As DataTable)
            Session("dtNTP") = value
        End Set
    End Property
#End Region

#Region "Functions"
    Public Function DataTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("Total_Amt", GetType(Decimal))
        dt.Columns.Add("Hdr_ID", GetType(Integer))
        dt.Columns.Add("prhdr_id", GetType(Integer))
        dt.Columns.Add("Supplier_Id", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("Total_Amt") = DBNull.Value
            dr("Hdr_ID") = DBNull.Value
            dr("prhdr_id") = DBNull.Value
            dr("Supplier_Id") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function DataTable_NTP(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("Canvass_Date", GetType(Date))
        dt.Columns.Add("MOP", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("Supp_ABC", GetType(Decimal))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("CanvassAward_ID", GetType(Integer))
        dt.Columns.Add("PO_Date", GetType(Date))
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Canvass_Date") = DBNull.Value
            dr("MOP") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("Supp_ABC") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("CanvassAward_ID") = DBNull.Value
            dr("PO_No") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function dtTemp_NTP(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("CanvassAward_ID", GetType(Long))
        'dt.Columns.Add("rfq_no", GetType(String))
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("Supp_ABC", GetType(Decimal))
        dt.Columns.Add("ProjectName", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Canvassaward_ID") = DBNull.Value
            'dr("rfq_no") = DBNull.Value
            dr("PO_No") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("Supp_ABC") = DBNull.Value
            dr("ProjectName") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function dtROA(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("Hdr_ID", GetType(Integer))
        dt.Columns.Add("prhdr_id", GetType(Integer))
        dt.Columns.Add("Supplier_Id", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("Hdr_ID") = DBNull.Value
            dr("prhdr_id") = DBNull.Value
            dr("Supplier_Id") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

#End Region

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToShortDateString
            LoadTabs()
        End If

        txtSearch_Resolution.Attributes.Add("onkeypress", "return fun1(event, '" & btnSearch_Resolution.ClientID & "')")
        txtSearch_NOA.Attributes.Add("onkeypress", "return fun1(event, '" & btnSearch_NOA.ClientID & "')")

    End Sub

    Private Sub btnTab1_Click(sender As Object, e As EventArgs) Handles btnTab1.Click
        btnTab1.CssClass = "TabButton_Active"
        btnTab2.CssClass = "TabButton_InActive"
        btnTab3.CssClass = "TabButton_InActive"
        LoadTabs()
    End Sub

    Private Sub btnTab2_Click(sender As Object, e As EventArgs) Handles btnTab2.Click
        btnTab1.CssClass = "TabButton_InActive"
        btnTab2.CssClass = "TabButton_Active"
        btnTab3.CssClass = "TabButton_InActive"
        LoadTabs()
    End Sub

    Private Sub btnTab3_Click(sender As Object, e As EventArgs) Handles btnTab3.Click
        btnTab1.CssClass = "TabButton_InActive"
        btnTab2.CssClass = "TabButton_InActive"
        btnTab3.CssClass = "TabButton_Active"
        LoadTabs()
    End Sub

    Protected Sub LoadTabs()
        Try
            If btnTab1.CssClass = "TabButton_Active" And btnTab2.CssClass = "TabButton_InActive" And btnTab3.CssClass = "TabButton_InActive" Then
                dtResolution = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Nego] '" & 1 & "'", CommandType.Text)
                If dtResolution.Rows.Count < 10 Then
                    dtResolution.Merge(dtROA(10 - (dtResolution.Rows.Count)))
                End If
                grdResolution.DataSource = dtResolution
                grdResolution.DataBind()

                mvTabs.SetActiveView(Me.vwROA)

            ElseIf btnTab1.CssClass = "TabButton_InActive" And btnTab2.CssClass = "TabButton_Active" And btnTab3.CssClass = "TabButton_InActive" Then
                dtAbstract = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Nego] '" & 2 & "'", CommandType.Text)
                If dtAbstract.Rows.Count < 10 Then
                    dtAbstract.Merge(DataTable1(9 - (dtAbstract.Rows.Count)))
                End If
                grdAbstract.DataSource = dtAbstract
                grdAbstract.DataBind()

                mvTabs.SetActiveView(Me.vwNOA1)

            ElseIf btnTab1.CssClass = "TabButton_InActive" And btnTab2.CssClass = "TabButton_InActive" And btnTab3.CssClass = "TabButton_Active" Then
                dtNTP = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Nego] '" & 3 & "'", CommandType.Text)
                If dtNTP.Rows.Count < 5 Then
                    dtNTP.Merge(dtTemp_NTP(4 - (dtNTP.Rows.Count)))
                End If
                grdNTP.DataSource = dtNTP
                grdNTP.DataBind()

                drpNTP_ApprovedBy.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE deptid = 1 AND division_Key = 86 AND isDeptHead = 'Yes' AND isActive = 1", CommandType.Text)
                drpNTP_ApprovedBy.DataTextField = "Full_Name"
                drpNTP_ApprovedBy.DataValueField = "EmpID"
                drpNTP_ApprovedBy.DataBind()

                mvTabs.SetActiveView(Me.vwNTP)
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Resolution_Click(sender As Object, e As EventArgs) Handles btnSearch_Resolution.Click
        Try
            Dim myview As DataView
            myview = dtResolution.DefaultView
            myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearch_Resolution.Text) & "%'"
            grdResolution.DataSource = myview
            grdResolution.DataBind()
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin")
        End Try
    End Sub

    Protected Sub lnkViewReso_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub lnkView_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub grdResolution_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdResolution.PageIndexChanging
        grdResolution.DataSource = dtResolution
        grdResolution.PageIndex = e.NewPageIndex
        grdResolution.DataBind()
    End Sub

    Private Sub grdResolution_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdResolution.SelectedIndexChanged
        Try
            Session("Hdr_ID") = grdResolution.SelectedDataKey("Hdr_ID")
            Session("prhdr_id") = grdResolution.SelectedDataKey("prhdr_id")
            Session("Award") = "RRA"
            Session("Page") = "BID"

            Dim ResolutionDate As Date = CType(CType(grdResolution.Rows(grdResolution.SelectedIndex).FindControl("txtResolutionDate"), TextBox).Text, Date)
            Dim ResolvedDate As Date = CType(CType(grdResolution.Rows(grdResolution.SelectedIndex).FindControl("txtResolveDate"), TextBox).Text, Date)
            Dim QuotationDate As Date = CType(CType(grdResolution.Rows(grdResolution.SelectedIndex).FindControl("txtQuotationDate"), TextBox).Text, Date)
            Dim ResolutionNo As String = CType(grdResolution.Rows(grdResolution.SelectedIndex).FindControl("txtResoNo"), TextBox).Text

            If ResolutionNo = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Resolution Number is required to proceed.")
                Exit Sub
            End If

            Dim BACC As Integer = objDerived.GetValue("SELECT TOP(1) empsig_id FROM [dbo].[View_BAC] WHERE [BAC_PostionID] = 1 AND [isDefault] = 1", CommandType.Text)
            Dim BACVC As Integer = objDerived.GetValue("SELECT TOP(1) empsig_id FROM [dbo].[View_BAC] WHERE [BAC_PostionID] = 2 AND [isDefault] = 1", CommandType.Text)
            Dim BAC1 As Integer = objDerived.GetValue("SELECT TOP(1) empsig_id FROM [dbo].[View_BAC] WHERE [BAC_PostionID] = 3 AND [isDefault] = 1", CommandType.Text)
            Dim BAC2 As Integer = objDerived.GetValue("SELECT TOP(1) empsig_id FROM [dbo].[View_BAC] WHERE [BAC_PostionID] = 4 AND [isDefault] = 1", CommandType.Text)
            Dim BAC3 As Integer = objDerived.GetValue("SELECT TOP(1) empsig_id FROM [dbo].[View_BAC] WHERE [BAC_PostionID] = 5 AND [isDefault] = 1", CommandType.Text)
            Dim ApprovedBy As Long = objDerived.GetValue("SELECT TOP(1) [EmpID] FROM [HRMS].[view_signatory] WHERE [deptid] = 1 AND [division_Key] = 86 AND [isDeptHead] = 'Yes' AND [isActive] = 1", CommandType.Text)

            If BACC = 0 Or BACVC = 0 Or BAC1 = 0 Or BAC2 = 0 Or BAC3 = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set default BAC signatories in File Maintenance.")
                Exit Sub
            End If

            objDerived.GetRecords("INSERT INTO [AMS].[m_CanvassResolution] " &
                                  "([Hdr_ID], [Resolution_No], [Reso_Date], [Resolved_Date], [QuotationDate_Rcv], [BACC], [BACVC], [BAC1], [BAC2], [BAC3], [ApprovedBy]) " &
                                  "VALUES ('" & Session("Hdr_ID") & "', '" & ResolutionNo & "', '" & ResolutionDate &
                                  "', '" & ResolvedDate & "', '" & QuotationDate &
                                  "', '" & BACC & "', '" & BACVC & "', '" & BAC1 & "', '" & BAC2 & "', '" & BAC3 &
                                  "', '" & ApprovedBy & "')", CommandType.Text)

            Session("CanvassReso_ID") = objDerived.GetValue("SELECT TOP(1) CanvassReso_ID FROM [AMS].[m_CanvassResolution] ORDER BY CanvassReso_ID DESC", CommandType.Text)

            Me.Page.Response.Redirect("../bidding/CanvassResolution_ReportEdit_Nego.aspx")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Contact system administrator")
        End Try
    End Sub

    Private Sub btnSearch_NOA_Click(sender As Object, e As EventArgs) Handles btnSearch_NOA.Click
        Try
            Dim myview As DataView
            myview = dtAbstract.DefaultView
            If drpSearch_NOA.SelectedItem.Value = 1 Then
                myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearch_NOA.Text) & "%'"
            ElseIf drpSearch_NOA.SelectedItem.Value = 2 Then
                myview.RowFilter = "SuppName like '%" & replaceapostrophe(txtSearch_NOA.Text) & "%'"
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select search option")
            End If

            grdAbstract.DataSource = myview
            grdAbstract.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub grdAbstract_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdAbstract.PageIndexChanging
        grdAbstract.DataSource = dtAbstract
        grdAbstract.PageIndex = e.NewPageIndex
        grdAbstract.DataBind()
    End Sub


    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub


    Private Sub grdAbstract_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdAbstract.SelectedIndexChanged
        Try
            Session("Award") = "NOA"
            Session("Page") = "BID"


            Session("Hdr_ID") = grdAbstract.SelectedDataKey("Hdr_ID")
            Session("prhdr_id") = grdAbstract.SelectedDataKey("prhdr_id")
            Session("Supplier_ID") = grdAbstract.SelectedDataKey("Supplier_ID")

            Dim prNo As String = objDerived.GetValue("SELECT pr_no FROM ams.pr_hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)

            Dim totalAmt As Decimal = grdAbstract.SelectedDataKey("Total_Amt")

            Dim result As Object = objDerived.GetValue("SELECT mode_of_procurement_id FROM ams.mode_of_procurement WHERE mode_description LIKE '%Negotiated Procurement%'", CommandType.Text)
            Dim mode_of_procurement_id As Integer = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToInt32(result), 0)


            'Add some  mode of procurement = nego

            Session("Hdr_ID") = Session("Hdr_ID")
            Session("prhdr_id") = Session("prhdr_id")
            Session("Supplier_ID") = Session("Supplier_ID")

            AddTrace("Hdr_ID" & Session("Hdr_ID"))
            AddTrace("prhdr_id" & Session("prhdr_id"))
            AddTrace("Supplier_ID" & Session("Supplier_ID"))
            AddTrace("prNo" & prNo)
            AddTrace("totalAmt" & totalAmt)
            AddTrace("mode_of_procurement_id" & mode_of_procurement_id)



            Dim ApprovedBy As Long = objDerived.GetValue("SELECT TOP(1) [EmpID] FROM [HRMS].[view_signatory] WHERE [deptid] = 1 AND [division_Key] = 86 AND [isDeptHead] = 'Yes' AND [isActive] = 1", CommandType.Text)
            'Dim NOA_Date As String = CType(grdNOA.Rows(grdNOA.SelectedIndex).FindControl("txtNOADate"), TextBox).Text
            Dim NOA_Date As String = CType(grdAbstract.Rows(grdAbstract.SelectedIndex).FindControl("txtNOADate"), TextBox).Text
            Dim parsedNOADate As DateTime

            ' Add validation for NOA_Date
            If Not DateTime.TryParse(NOA_Date, parsedNOADate) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid NOA Date format. Please enter a valid date.")
                Exit Sub
            End If

            ' Ensure date is within SQL Server range
            If parsedNOADate < New DateTime(1753, 1, 1) Or parsedNOADate > New DateTime(9999, 12, 31) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "NOA Date must be between 1/1/1753 and 12/31/9999.")
                Exit Sub
            End If


            With Bid
                .pre_procurement_hdr_id = mode_of_procurement_id
                .Article = "Negotiated"
                .Amount = totalAmt
                .Supplier_ID = Session("Supplier_ID")
                .withNOA = True
                .NOA_Date = NOA_Date
                .NOA_ApprovedBy = ApprovedBy
                .NOA_ApprovedBy_Position = replaceapostrophe("")
                .withPO = False
                .withNTP = False
                .NTP_Date = "2024-12-05 00:00:00.000"
                .NTP_ApprovedBy = Nothing
                .NTP_ApprovedBy_Position = Nothing
                .PR_No = prNo
                .UserID = Session("@UserName")
            End With

            Dim bidID As Long = Bid.save()

            Session("Bid_ID") = bidID


            AddTrace("Bid ID: " & Session("Bid_ID"))




            'Session("Hdr_ID") = grdAbstract.SelectedDataKey("Hdr_ID")
            'Session("prhdr_id") = grdAbstract.SelectedDataKey("prhdr_id")
            'Session("Supplier_ID") = grdAbstract.SelectedDataKey("Supplier_ID")

            'Dim ApprovedBy As Long = objDerived.GetValue("SELECT TOP(1) [EmpID] FROM [HRMS].[view_signatory] WHERE [deptid] = 1 AND [division_Key] = 86 AND [isDeptHead] = 'Yes' AND [isActive] = 1", CommandType.Text)
            'Dim NOA_Date As String = CType(grdAbstract.Rows(grdAbstract.SelectedIndex).FindControl("txtNOADate"), TextBox).Text

            Dim NOADate As Date = CType(CType(grdAbstract.Rows(grdAbstract.SelectedIndex).FindControl("txtNOADate"), TextBox).Text, Date)

            objDerived.GetRecords("INSERT INTO [AMS].[m_CanvassAwards] ([Hdr_ID],[Supplier_ID],[PR_No],[Supp_ABC],[withNOA],[NOA_Date],[NOA_ApprovedBy],[withNTP]) " &
                                  "VALUES ('" & grdAbstract.SelectedDataKey("Hdr_ID") &
                                  "', '" & grdAbstract.SelectedDataKey("Supplier_ID") &
                                  "', '" & grdAbstract.SelectedDataKey("PR_No") &
                                  "', '" & grdAbstract.SelectedDataKey("Total_Amt") &
                                  "', 1, '" & NOA_Date &
                                  "', '" & ApprovedBy & "', 0)", CommandType.Text)

            Session("CanvassAward_ID") = objDerived.GetValue("SELECT CanvassAward_ID FROM AMS.m_CanvassAwards WHERE Hdr_ID = '" & grdAbstract.SelectedDataKey("Hdr_ID") & "' AND Supplier_ID = '" & grdAbstract.SelectedDataKey("Supplier_ID") & "'", CommandType.Text)

            Me.Page.Response.Redirect("../bidding/rpt_CanvassAwards_Nego.aspx")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Contact system administrator.")
        End Try
    End Sub

    Private Sub btnSearchNTP_Click(sender As Object, e As EventArgs) Handles btnSearchNTP.Click
        Try
            Dim myview As DataView
            myview = dtNTP.DefaultView
            If drpSearchNTP.SelectedItem.Value = 1 Then
                myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearchNTP.Text) & "%'"
            ElseIf drpSearchNTP.SelectedItem.Value = 2 Then
                myview.RowFilter = "SuppName like '%" & replaceapostrophe(txtSearchNTP.Text) & "%'"
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select search option.")
            End If

            grdNTP.DataSource = myview
            grdNTP.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went worng, please contact system admin.")
        End Try
    End Sub

    Private Sub grdNTP_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdNTP.PageIndexChanging
        grdNTP.DataSource = dtNTP
        grdNTP.PageIndex = e.NewPageIndex
        grdNTP.DataBind()
    End Sub

    Private Sub grdNTP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdNTP.SelectedIndexChanged
        Try
            txtNTP_Date.Text = Date.Today.ToShortDateString
            txtNTP_Content.Text = "The attached Purchase Order for the " & grdNTP.SelectedDataKey("ProjectName") & " under PO Number " & grdNTP.SelectedDataKey("PO_No") & " in the amount of Php " & FormatNumber(CType(grdNTP.SelectedDataKey("Supp_ABC"), Decimal), 2) & " having been approved, notice is hereby given to " & grdNTP.SelectedDataKey("SuppName") & " that work may commence on the aforementioned project with Sixty (60) days upon receipt hereof." & vbCrLf & vbCrLf & "As such, you are hereby directed to submit your schedule of deliveries And should be responsible in performing the services under the terms And conditions of the Agreement indicated in the relative Purchase Order."

            btnNTP_Save.Enabled = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnNTP_Save_Click(sender As Object, e As EventArgs) Handles btnNTP_Save.Click
        Try
            Session("Page") = "Nego"

            Session("CanvassAward_ID") = grdNTP.SelectedDataKey("CanvassAward_ID")
            objDerived.Execute("UPDATE AMS.m_CanvassAwards SET NTP_Content = '" & replaceapostrophe(txtNTP_Content.Text) & "', withNTP = 1, NTP_Date = '" & CType(txtNTP_Date.Text, Date) & "', NTP_Approvedby = '" & drpNTP_ApprovedBy.SelectedItem.Value & "' WHERE CanvassAward_ID = '" & grdNTP.SelectedDataKey("CanvassAward_ID") & "'", CommandType.Text)

            'Updates the Bid Information of NTP
            objDerived.Execute("UPDATE AMS.Bid_Information SET withNTP = 1, NTP_Date = '" & CType(txtNTP_Date.Text, Date) & "', NTP_Approvedby = '" & drpNTP_ApprovedBy.SelectedItem.Value & "' WHERE Bid_ID = '" & Session("Bid_ID") & "'", CommandType.Text)

            Me.Page.Response.Redirect("~/bidding/rpt_notice_to_proceed.aspx")

            'Me.Page.Response.Redirect("~/bidding/rpt_CanvassAwards_Nego.aspx")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

End Class
