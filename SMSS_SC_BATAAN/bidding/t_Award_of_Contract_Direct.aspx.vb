Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class t_Award_of_Contract_Direct
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private Bid As New Bid_information
    Private Property dtNOA() As DataTable
        Get
            Return CType(Session("dtNOA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtNOA") = value
        End Set
    End Property
    Private Property dtContract() As DataTable
        Get
            Return CType(Session("dtContract"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtContract") = value
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

    Private Property dtResolution() As DataTable
        Get
            Return CType(Session("dtResolution"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtResolution") = value
        End Set
    End Property


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
        dt.Columns.Add("isVisible", GetType(Boolean)) 'QuotationDate

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
    ' Property for Hdr_ID
    Private Property SelectedHdrID() As Integer
        Get
            Return If(Session("SelectedHdrID") IsNot Nothing, CType(Session("SelectedHdrID"), Integer), 0)
        End Get
        Set(ByVal value As Integer)
            Session("SelectedHdrID") = value
        End Set
    End Property

    ' Property for Supplier_ID
    Private Property SelectedSupplierID() As Integer
        Get
            Return If(Session("SelectedSupplierID") IsNot Nothing, CType(Session("SelectedSupplierID"), Integer), 0)
        End Get
        Set(ByVal value As Integer)
            Session("SelectedSupplierID") = value
        End Set
    End Property

    ' Property for prhdr_id
    Private Property SelectedPRHdrID() As Integer
        Get
            Return If(Session("SelectedPRHdrID") IsNot Nothing, CType(Session("SelectedPRHdrID"), Integer), 0)
        End Get
        Set(ByVal value As Integer)
            Session("SelectedPRHdrID") = value
        End Set
    End Property


    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@username"), Page)
            'If obj.HasAccess = False Then
            '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
            'End If

            txtNTP_Date.Text = DateTime.Now.ToString("MM/dd/yyyy")
            LoadTabs()

        End If



    End Sub




    Public Function dtTemp_Notice(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("Infra_BidPrep_ID", GetType(Integer))
        dt.Columns.Add("ITB_No", GetType(String))
        dt.Columns.Add("PPA", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("Supplier_ID", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("MOP", GetType(String))
        dt.Columns.Add("NOA_Date", GetType(Date)) ' Add this column

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Infra_BidPrep_ID") = DBNull.Value
            dr("ITB_No") = DBNull.Value
            dr("PPA") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("Supplier_ID") = DBNull.Value
            dr("isVisible") = True
            dr("MOP") = DBNull.Value
            dr("NOA_Date") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Protected Sub lnkViewReso_Click(sender As Object, e As EventArgs)
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Resolution of Award View Clicked.")
    End Sub



    Protected Sub btnTab1_ROA_Click(sender As Object, e As EventArgs) Handles btnTab1_ROA.Click
        btnTab1_ROA.CssClass = "TabButton_Active"
        btnTab2_NOA.CssClass = "TabButton_InActive"
        btnTab3_Contract.CssClass = "TabButton_InActive"
        btnTab4_NTP.CssClass = "TabButton_InActive"
        mvTabs.SetActiveView(vwROA) ' Show the Resolution of Award View
    End Sub





    Private Sub btnTab2_NOA_Click(sender As Object, e As EventArgs) Handles btnTab2_NOA.Click
        btnTab1_ROA.CssClass = "TabButton_InActive"
        btnTab2_NOA.CssClass = "TabButton_Active"
        btnTab3_Contract.CssClass = "TabButton_InActive"
        btnTab4_NTP.CssClass = "TabButton_InActive"

        LoadTabs()
    End Sub
    Private Sub btnTab3_Contract_Click(sender As Object, e As EventArgs) Handles btnTab3_Contract.Click
        btnTab1_ROA.CssClass = "TabButton_InActive"
        btnTab2_NOA.CssClass = "TabButton_InActive"
        btnTab3_Contract.CssClass = "TabButton_Active"
        btnTab4_NTP.CssClass = "TabButton_InActive"

        LoadTabs()
    End Sub
    Private Sub btnTab4_NTP_Click(sender As Object, e As EventArgs) Handles btnTab4_NTP.Click
        btnTab1_ROA.CssClass = "TabButton_InActive"
        btnTab2_NOA.CssClass = "TabButton_InActive"
        btnTab3_Contract.CssClass = "TabButton_InActive"
        btnTab4_NTP.CssClass = "TabButton_Active"

        LoadTabs()
    End Sub



    Private Sub LoadTabs()
        Try
            If btnTab1_ROA.CssClass = "TabButton_Active" AndAlso btnTab2_NOA.CssClass = "TabButton_InActive" AndAlso btnTab3_Contract.CssClass = "TabButton_InActive" AndAlso btnTab4_NTP.CssClass = "TabButton_InActive" Then
                ' Load Resolution of Award (ROA) data
                dtResolution = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Direct] '" & 1 & "'", CommandType.Text)
                If dtResolution.Rows.Count < 10 Then
                    dtResolution.Merge(dtTemp_Notice(10 - dtResolution.Rows.Count)) ' Fill empty rows if less than 10
                End If
                grdResolution.DataSource = dtResolution
                grdResolution.DataBind()

                mvTabs.SetActiveView(vwROA)

            ElseIf btnTab1_ROA.CssClass = "TabButton_InActive" AndAlso btnTab2_NOA.CssClass = "TabButton_Active" AndAlso btnTab3_Contract.CssClass = "TabButton_InActive" AndAlso btnTab4_NTP.CssClass = "TabButton_InActive" Then
                ' Load Notice of Award (NOA) data
                dtNOA = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Direct] '" & 2 & "'", CommandType.Text)
                If dtNOA.Rows.Count < 10 Then
                    dtNOA.Merge(dtTemp_Notice(10 - dtNOA.Rows.Count)) ' Fill empty rows if less than 10
                End If
                grdNOA.DataSource = dtNOA
                grdNOA.DataBind()

                mvTabs.SetActiveView(vwTab2_NOA)

            ElseIf btnTab1_ROA.CssClass = "TabButton_InActive" AndAlso btnTab2_NOA.CssClass = "TabButton_InActive" AndAlso btnTab3_Contract.CssClass = "TabButton_Active" AndAlso btnTab4_NTP.CssClass = "TabButton_InActive" Then
                ' Load Contract data
                dtContract = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Direct] '" & 3 & "'", CommandType.Text)
                If dtContract.Rows.Count < 10 Then
                    dtContract.Merge(dtTemp_Notice(10 - dtContract.Rows.Count)) ' Fill empty rows if less than 10
                End If
                grdContract.DataSource = dtContract
                grdContract.DataBind()

                mvTabs.SetActiveView(vwTab3_Contract)

            ElseIf btnTab1_ROA.CssClass = "TabButton_InActive" AndAlso btnTab2_NOA.CssClass = "TabButton_InActive" AndAlso btnTab3_Contract.CssClass = "TabButton_InActive" AndAlso btnTab4_NTP.CssClass = "TabButton_Active" Then
                ' Load Notice to Proceed (NTP) data
                dtNTP = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Direct] '" & 4 & "'", CommandType.Text)
                If dtNTP.Rows.Count < 10 Then
                    dtNTP.Merge(dtTemp_Notice(10 - dtNTP.Rows.Count)) ' Fill empty rows if less than 10
                End If
                grdNTP.DataSource = dtNTP
                grdNTP.DataBind()

                mvTabs.SetActiveView(vwTab4_NTP)

            Else
                ' If no condition matches, display an error message
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
            End If
        Catch ex As Exception
            ' Log the error if any occurs
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error: " & ex.Message)
        End Try
    End Sub


    Private Sub grdNTP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdNTP.SelectedIndexChanged


        Try

            drpNTP_Approvedby.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE deptid = 1 AND division_Key = 86 AND isDeptHead = 'Yes' AND isActive = 1", CommandType.Text)
            drpNTP_Approvedby.DataTextField = "Full_Name"
            drpNTP_Approvedby.DataValueField = "EmpID"
            drpNTP_Approvedby.DataBind()



            txtNTP_Date.Text = Date.Today.ToShortDateString
            txtNTP_Content.Text = "The attached Purchase Order for the “ & grdNTP.SelectedDataKey("ProjectName") & ” under PO Number " & grdNTP.SelectedDataKey("PO_No") & " in the amount of Php " & FormatNumber(CType(grdNTP.SelectedDataKey("Supp_ABC"), Decimal), 2) & " having been approved, notice is hereby given to " & grdNTP.SelectedDataKey("SuppName") & " that work may commence on the aforementioned project with Sixty (60) days upon receipt hereof." & vbCrLf & vbCrLf &
                                    "As such, you are hereby directed to submit your schedule of deliveries And should be responsible in performing the services under the terms And conditions of the Agreement indicated in the relative Purchase Order."

            btnNTP_Save.Enabled = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try


    End Sub

    Private Sub btnNTP_Save_Click(sender As Object, e As EventArgs) Handles btnNTP_Save.Click
        Try
            ' Set the session variables first
            Session("Award") = "NTP"
            Session("Page") = "Direct"
            Session("CanvassAward_ID") = grdNTP.SelectedDataKey("CanvassAward_ID")
            Session("Hdr_ID") = grdNTP.SelectedDataKey("Hdr_ID")
            Session("PR_Hdr_ID") = grdNTP.SelectedDataKey("PR_Hdr_ID")
            Session("Supplier_ID") = grdNTP.SelectedDataKey("Supplier_ID") ' Make sure this is in your DataKeyNames

            Session("pr_hdr_id") = Session("PR_Hdr_ID")

            Dim dtPR As DataTable = objDerived.GetDataTable("SELECT pr_no FROM [AMS].[PR_Hdr] WHERE prhdr_id = '" & Session("pr_hdr_id") & "'", CommandType.Text)
            Dim PR_NO As String = dtPR.Rows(0)("pr_no").ToString()

            Dim dtBid As DataTable = objDerived.GetDataTable("SELECT Bid_ID FROM [AMS].[Bid_Information] WHERE PR_No = '" & PR_NO & "'", CommandType.Text)
            Dim BidID As String = dtBid.Rows(0)("Bid_ID").ToString()

            Session("Bid_ID") = BidID

            ' Add trace for session variables and values
            AddTrace("Session('Award'): " & Session("Award"))
            AddTrace("Session('Page'): " & Session("Page"))
            AddTrace("Session('CanvassAward_ID'): " & Session("CanvassAward_ID"))
            AddTrace("Session('Hdr_ID'): " & Session("Hdr_ID"))
            AddTrace("Session('PR_Hdr_ID'): " & Session("pr_hdr_id"))
            AddTrace("Session('Supplier_ID'): " & Session("Supplier_ID"))
            AddTrace("txtNTP_Content.Text: " & replaceapostrophe(txtNTP_Content.Text))
            AddTrace("txtNTP_Date.Text: " & txtNTP_Date.Text)
            AddTrace("drpNTP_Approvedby.SelectedItem.Value: " & drpNTP_Approvedby.SelectedItem.Value)

            ' Update the m_CanvassAwards
            objDerived.Execute("UPDATE AMS.m_CanvassAwards SET NTP_Content = '" & replaceapostrophe(txtNTP_Content.Text) & "', withNTP = 1, NTP_Date = '" & CType(txtNTP_Date.Text, Date) & "', NTP_Approvedby = '" & drpNTP_Approvedby.SelectedItem.Value & "' WHERE CanvassAward_ID = '" & grdNTP.SelectedDataKey("CanvassAward_ID") & "'", CommandType.Text)

            'Updates the Bid Information of NTP
            objDerived.Execute("UPDATE AMS.Bid_Information SET withNTP = 1, NTP_Date = '" & CType(txtNTP_Date.Text, Date) & "', NTP_Approvedby = '" & drpNTP_Approvedby.SelectedItem.Value & "' WHERE Bid_ID = '" & Session("Bid_ID") & "'", CommandType.Text)

            ' Redirect to the report page
            'Me.Page.Response.Redirect("~/bidding/rpt_CanvassAwards.aspx")


            Session("Page") = "Direct"
            Me.Page.Response.Redirect("~/bidding/rpt_notice_to_proceed.aspx")


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin. Error: " & ex.Message)
        End Try
    End Sub


    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub





    Private Sub LoadNOA()
        Try
            dtNOA = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Direct] '" & 2 & "'", CommandType.Text)

            ' Ensure NOA_Date column exists
            If Not dtNOA.Columns.Contains("NOA_Date") Then
                dtNOA.Columns.Add("NOA_Date", GetType(Date))
            End If

            ' Set default value for empty rows
            If dtNOA.Rows.Count < 10 Then
                Dim emptyRows As DataTable = dtTemp_Notice(10 - dtNOA.Rows.Count)
                dtNOA.Merge(emptyRows)
            End If

            grdNOA.DataSource = dtNOA
            grdNOA.DataBind()
            grdNOA.SelectedIndex = -1



        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub




    Private Sub grdNOA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdNOA.SelectedIndexChanged
        Try
            Session("Award") = "NOA"
            Session("Page") = "Direct"

            ' Get values directly from DataKeys
            Dim hdrID As Integer = Convert.ToInt32(grdNOA.DataKeys(grdNOA.SelectedIndex).Values("Hdr_ID"))
            Dim prhdrID As Integer = Convert.ToInt32(grdNOA.DataKeys(grdNOA.SelectedIndex).Values("prhdr_id"))
            Dim supplierID As Integer = Convert.ToInt32(grdNOA.DataKeys(grdNOA.SelectedIndex).Values("Supplier_ID"))
            Dim prNo As String = grdNOA.DataKeys(grdNOA.SelectedIndex).Values("pr_no").ToString()
            Dim totalAmt As Decimal = Convert.ToDecimal(grdNOA.DataKeys(grdNOA.SelectedIndex).Values("Total_Amt"))

            Dim mode_of_procurement_id As Integer = Convert.ToInt32(grdNOA.DataKeys(grdNOA.SelectedIndex).Values("mode_of_procurement_id"))

            Session("Hdr_ID") = hdrID
            Session("prhdr_id") = prhdrID
            Session("Supplier_ID") = supplierID





            Dim ApprovedBy As Long = objDerived.GetValue("SELECT TOP(1) [EmpID] FROM [HRMS].[view_signatory] WHERE [deptid] = 1 AND [division_Key] = 86 AND [isDeptHead] = 'Yes' AND [isActive] = 1", CommandType.Text)
            'Dim NOA_Date As String = CType(grdNOA.Rows(grdNOA.SelectedIndex).FindControl("txtNOADate"), TextBox).Text
            Dim NOA_Date As String = CType(grdNOA.Rows(grdNOA.SelectedIndex).FindControl("txtNOADate"), TextBox).Text
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
                .Article = "Direct Contracting"
                .Amount = totalAmt
                .Supplier_ID = supplierID
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


            ' Insert record
            objDerived.GetRecords("INSERT INTO [AMS].[m_CanvassAwards] ([Hdr_ID],[Supplier_ID],[PR_No],[Supp_ABC],[withNOA],[NOA_Date],[NOA_Approvedby],[withNTP]) " &
                          "VALUES ('" & hdrID & "','" & supplierID & "','" & prNo & "','" & totalAmt & "',1,'" & NOA_Date & "','" & ApprovedBy & "',0)", CommandType.Text)

            ' Get the new ID
            Session("CanvassAward_ID") = objDerived.GetValue("SELECT CanvassAward_ID FROM AMS.m_CanvassAwards WHERE Hdr_ID = '" & hdrID & "' And Supplier_ID = '" & supplierID & "'", CommandType.Text)





            Me.Page.Response.Redirect("../bidding/rpt_CanvassAwards.aspx")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Contact system administrator. Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadContract()
        Try

            dtContract = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Notices] 'Contract'", CommandType.Text)
            If dtContract.Rows.Count < 5 Then
                dtContract.Merge(dtTemp_Notice(4 - dtContract.Rows.Count))
            End If
            grdContract.DataSource = dtContract
            grdContract.DataBind()
            grdContract.SelectedIndex = -1

            drpContract_Aprpovedby.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE deptid = 1 AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            drpContract_Aprpovedby.DataTextField = "Full_Name"
            drpContract_Aprpovedby.DataValueField = "EmpID"
            drpContract_Aprpovedby.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub LoadNTP()
        Try

            dtNTP = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Notices] 'NTP'", CommandType.Text)
            If dtNTP.Rows.Count < 5 Then
                dtNTP.Merge(dtTemp_Notice(4 - dtNTP.Rows.Count))
            End If
            grdNTP.DataSource = dtNTP
            grdNTP.DataBind()
            grdNTP.SelectedIndex = -1

            drpNTP_Approvedby.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE deptid = 1 AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            drpNTP_Approvedby.DataTextField = "Full_Name"
            drpNTP_Approvedby.DataValueField = "EmpID"
            drpNTP_Approvedby.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub LoadROA()
        Try
            ' Call the modified stored procedure for Direct Contracting
            Dim query As String = "EXEC [AMS].[sp_rpt_BACResolution_DirectContracting]"

            ' Get the result set
            Dim dtROA As DataTable = objDerived.GetDataTable(query, CommandType.Text)

            ' Check if the result set has fewer than 5 rows, fill with placeholders if necessary
            If dtROA.Rows.Count < 5 Then
                dtROA.Merge(dtTemp_Notice(5 - dtROA.Rows.Count))
            End If

            ' Bind the result set to the GridView
            grdResolution.DataSource = dtROA
            grdResolution.DataBind()

        Catch ex As Exception
            ' Handle any errors that occur during data loading
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error loading data: " & ex.Message)
        End Try
    End Sub

    Protected Sub btnSearch_Resolution_Click(sender As Object, e As EventArgs) Handles btnSearch_Resolution.Click
        Try
            ' Get the search criteria and search text
            Dim searchBy As String = drpSearch_ROA.SelectedValue
            Dim searchText As String = txtSearch_Resolution.Text.Trim()

            ' Validate search text
            If String.IsNullOrEmpty(searchText) Then
                ' Load Resolution of Award (ROA) data
                dtResolution = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Direct] '" & 1 & "'", CommandType.Text)
                If dtResolution.Rows.Count < 10 Then
                    dtResolution.Merge(dtTemp_Notice(10 - dtResolution.Rows.Count)) ' Fill empty rows if less than 10
                End If
                grdResolution.DataSource = dtResolution
                grdResolution.DataBind()
            End If

            ' Get the data table from session
            If dtResolution Is Nothing Then
                dtResolution = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Direct] '" & 1 & "'", CommandType.Text)
            End If

            ' Determine which column to search based on dropdown selection
            Dim searchColumn As String = ""
            Select Case searchBy
                Case "1" ' PR Number
                    searchColumn = "pr_no"
                    ' Add other cases if more search options are added
            End Select

            ' Apply the filter using the Search function
            Dim filteredView As DataView = Search(dtResolution, searchColumn, searchText)

            ' Bind the filtered data to the grid
            grdResolution.DataSource = filteredView
            grdResolution.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error during search: " & ex.Message)
        End Try
    End Sub

    Protected Sub btnNOA_Search_Click(sender As Object, e As EventArgs) Handles btnNOA_Search.Click
        Try
            ' Get the search criteria and search text
            Dim searchBy As String = drpNOA_Search.SelectedValue
            Dim searchText As String = txtNOA_Search.Text.Trim()

            ' Validate search text
            If String.IsNullOrEmpty(searchText) Then
                dtNOA = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Direct] '" & 2 & "'", CommandType.Text)
                If dtNOA.Rows.Count < 10 Then
                    dtNOA.Merge(dtTemp_Notice(10 - dtNOA.Rows.Count)) ' Fill empty rows if less than 10
                End If
                grdNOA.DataSource = dtNOA
                grdNOA.DataBind()
            End If

            ' Get the data table from session
            If dtNOA Is Nothing Then
                dtNOA = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Direct] '" & 2 & "'", CommandType.Text)
            End If

            ' Determine which column to search based on dropdown selection
            Dim searchColumn As String = ""
            Select Case searchBy
                Case "1" ' PR Number
                    searchColumn = "pr_no"
                Case "2" ' Supplier Name
                    searchColumn = "SuppName"

            End Select


            Dim filteredView As DataView = Search(dtNOA, searchColumn, searchText)

            ' Bind the filtered data to the grid
            grdNOA.DataSource = filteredView
            grdNOA.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error during search: " & ex.Message)
        End Try
    End Sub

    Protected Sub btnNTP_Search_Click(sender As Object, e As EventArgs) Handles btnNTP_Search.Click
        Try
            ' Get the search criteria and search text
            Dim searchBy As String = drpNTP_Search.SelectedValue
            Dim searchText As String = txtNTP_Search.Text.Trim()

            ' Validate search text - if empty, reload original data
            If String.IsNullOrEmpty(searchText) Then
                dtNTP = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Direct] '" & 4 & "'", CommandType.Text)
                If dtNTP.Rows.Count < 10 Then
                    dtNTP.Merge(dtTemp_Notice(10 - dtNTP.Rows.Count))
                End If
                grdNTP.DataSource = dtNTP
                grdNTP.DataBind()
                Return
            End If

            ' Get the data table from session
            If dtNTP Is Nothing Then
                dtNTP = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassAwards_Direct] '" & 4 & "'", CommandType.Text)
            End If

            ' Determine which column to search based on dropdown selection
            Dim searchColumn As String = ""
            Select Case searchBy
                Case "1" ' PO Number
                    searchColumn = "PO_No"
                Case "2" ' Supplier
                    searchColumn = "SuppName"
            End Select

            ' Apply the filter using the Search function
            Dim filteredView As DataView = Search(dtNTP, searchColumn, searchText)

            ' Bind the filtered data to the grid
            grdNTP.DataSource = filteredView
            grdNTP.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error during search: " & ex.Message)
        End Try
    End Sub


    ' Reuse your existing Search function
    Public Function Search(ByVal data As DataTable, ByVal searchby As String, ByVal SearchString As Object) As DataView
        Dim ds As New DataSet
        Dim dt As DataTable = data
        Dim myview As DataView = dt.DefaultView

        If TypeOf SearchString Is Date Then
            If SearchString = CType("01/01/1901", Date) Then
                myview = dt.DefaultView
            Else
                myview.RowFilter = " " & searchby & "=#" & SearchString & "#"
            End If
        Else
            ' Using Search2 logic with % on both sides for contains search
            myview.RowFilter = " " & searchby & " Like '%" & SearchString.ToString & "%'"
        End If

        Return myview
    End Function


    ' Pagination handling for GridView
    Private Sub grdResolution_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdResolution.PageIndexChanging
        grdResolution.PageIndex = e.NewPageIndex
        LoadROA() ' Reload the data when paging changes
    End Sub



    Private Sub grdResolution_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdResolution.SelectedIndexChanged
        Try
            Session("Hdr_ID") = grdResolution.SelectedDataKey("Hdr_ID")
            Session("prhdr_id") = grdResolution.SelectedDataKey("prhdr_id")
            Session("Award") = "RRA"
            Session("Page") = "Direct"

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
                                    " ([Hdr_ID], [Resolution_No], [Reso_Date], [Resolved_Date], [QuotationDate_Rcv], [BACC], [BACVC], [BAC1], [BAC2], [BAC3],[ApprovedBy])  " &
                                    " VALUES ('" & Session("Hdr_ID") & "','" & ResolutionNo & "','" & ResolutionDate & "','" & ResolvedDate & "', '" & QuotationDate & "', " &
                                    " '" & BACC & "','" & BACVC & "','" & BAC1 & "','" & BAC2 & "','" & BAC3 & "','" & ApprovedBy & "')", CommandType.Text)

            Session("CanvassReso_ID") = objDerived.GetValue("SELECT TOP(1) CanvassReso_ID FROM [AMS].[m_CanvassResolution] ORDER BY CanvassReso_ID DESC", CommandType.Text)

            Me.Page.Response.Redirect("../bidding/CanvassResolution_ReportEdit.aspx")
            'Me.Page.Response.Redirect("../bidding/rpt_CanvassAwards.aspx")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Contact system administrator.")
        End Try

    End Sub




    Private Sub t_Award_of_Contract_Direct_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadTabs()

        End If
    End Sub
End Class
