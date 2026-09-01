Imports System.Data
Imports System.Data.SqlClient

Partial Class bidding_BACResolution_Report
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private BACResolution As New Namespace_Bidding.BACResolution

    Private Property dtReso() As DataTable
        Get
            Return CType(Session("dtReso"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtReso") = value
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


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Check if pr_no is in the query string
        If Not String.IsNullOrEmpty(Request.QueryString("pr_no")) Then
            Dim pr_no As String = Request.QueryString("pr_no")
            DisplayResolutionReport(pr_no)
        Else
            ' Handle case when no pr_no is passed
            txtContent_P8.Text = "No PR Number provided."
        End If
    End Sub

    ' Method to display the resolution report
    Private Sub DisplayResolutionReport(ByVal pr_no As String)
        Try
            ' Define the query to fetch the data based on pr_no
            Dim query As String = "SELECT SuppName, ABC FROM AMS.PR_Hdr " &
                                  "INNER JOIN AMS.m_Canvass_Hdr ON AMS.PR_Hdr.prhdr_id = AMS.m_Canvass_Hdr.PR_Hdr_ID " &
                                  "INNER JOIN dbo.Supplier ON AMS.m_Canvass_Hdr.Supplier_Id = dbo.Supplier.Supplier_Id " &
                                  "WHERE AMS.PR_Hdr.pr_no = @pr_no"

            ' Set up connection and command objects
            Using conn As New SqlConnection("your_connection_string_here")
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@pr_no", pr_no)
                    conn.Open()

                    ' Execute the query and load the results into a DataTable
                    Dim dtReso As New DataTable()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dtReso)

                    ' Check if data is returned
                    If dtReso.Rows.Count > 0 Then
                        ' Display the data on the report page
                        txtContent_P8.Text = "Supplier: " & dtReso.Rows(0)("SuppName").ToString() & ", " &
                                             "Approved Budget: " & FormatNumber(dtReso.Rows(0)("ABC"), 2)
                    Else
                        ' Handle no data found for the PR Number
                        txtContent_P8.Text = "No data found for PR Number: " & pr_no
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle any errors during the process
            txtContent_P8.Text = "Error loading data: " & ex.Message
        End Try
    End Sub


    Private Sub LoadBACResolutionReportByPRNo(pr_no As String)
        Try
            ' Query the stored procedure using the PR Number
            dtReso = objDerived.GetDataTable("EXEC [AMS].[sp_rpt_BACResolution_DirectContracting] @pr_no", CommandType.Text,
                             New SqlParameter() {New SqlParameter("@pr_no", pr_no)})

            ' Check if rows are returned and process the data (similar to your current logic)
            If dtReso.Rows.Count > 0 Then
                ' Set project name and other relevant fields
                txtProjectName.Text = dtReso.Rows(0)("project_name").ToString()
                lblResoNumb.Text = dtReso.Rows(0)("resolution_number").ToString()

                ' Display Supplier Name and Approved Budget (ABC)
                txtContent_P8.Text = "Supplier: " & dtReso.Rows(0)("SuppName").ToString() & ", Approved Budget: " & FormatNumber(dtReso.Rows(0)("ABC"), 2)
                ' Set other fields as needed


            Else
                ' Handle no data found case
                txtProjectName.Text = "No data found for the provided PR Number."
            End If


        Catch ex As Exception
            ' Handle exceptions and display error message
            txtProjectName.Text = "Error loading report: " & ex.Message
        End Try
    End Sub




    'Private Sub LoadBACResolutionReport(pre_procurement_hdr_id As String)
    '    Try
    '        ' Execute the stored procedure with the provided procurement header ID
    '        dtReso = objDerived.GetDataTable("EXEC [AMS].[sp_rpt_BACResolution_DirectContracting] @pre_procurement_hdr_id", CommandType.Text,
    '                         New SqlParameter() {New SqlParameter("@pre_procurement_hdr_id", pre_procurement_hdr_id)})

    '        ' Check if any rows are returned
    '        If dtReso.Rows.Count > 0 Then
    '            ' Set project name (with default fallback to "Project")
    '            Dim projectName As String = If(String.IsNullOrEmpty(dtReso.Rows(0)("project_name").ToString()), "Project", dtReso.Rows(0)("project_name").ToString())
    '            txtProjectName.Text = projectName

    '            ' Set resolution number (from session or stored procedure result)
    '            lblResoNumb.Text = If(Session("resolution_number") IsNot Nothing, Session("resolution_number").ToString(), dtReso.Rows(0)("resolution_number").ToString())

    '            ' Set bidder count and bidder list (with fallback to default values)
    '            Dim BidderCount As String = If(String.IsNullOrEmpty(dtReso.Rows(0)("Cnt").ToString()), "1", dtReso.Rows(0)("Cnt").ToString())
    '            Dim BidderList As String = dtReso.Rows(0)("SuppName_List").ToString()

    '            ' Set opening date and time (with default values)
    '            Dim DateOpen As String = If(String.IsNullOrEmpty(dtReso.Rows(0)("opening_date").ToString()), DateTime.Now.ToString("MM/dd/yyyy"), Convert.ToDateTime(dtReso.Rows(0)("opening_date")).ToString("MM/dd/yyyy"))
    '            Dim OpeningTime As String = If(String.IsNullOrEmpty(dtReso.Rows(0)("opening_time").ToString()), "12:00 PM", dtReso.Rows(0)("opening_time").ToString())

    '            ' Set Bid Conducted Date and Resolution Number Date (with default values)
    '            Dim BidConductedDate As Date = If(dtReso.Rows(0)("BidConducted_Date") Is DBNull.Value, DateTime.Now, Convert.ToDateTime(dtReso.Rows(0)("BidConducted_Date")))
    '            Dim ResolutionDate As Date = If(dtReso.Rows(0)("resolution_number_date") Is DBNull.Value, DateTime.Now, Convert.ToDateTime(dtReso.Rows(0)("resolution_number_date")))

    '            ' Set the text content based on retrieved data
    '            txtContent_P1.Text = "WHEREAS, The Provincial Government of Cagayan advertised the Invitation to Bid for the " & projectName & ", and posted the same in the Provincial Government of Cagayan website, the PhilGEPS, and in a conspicuous place at the premises within the Provincial Government of Cagayan continuously for seven (7) days."
    '            txtContent_P2.Text = "WHEREAS, in response to the said advertisements, " & BidderCount & " prospective bidders purchased bid documents namely " & BidderList & " but the latter failed to submit its bid proposal which was opened on " & DateOpen & " at " & OpeningTime & "."
    '            txtContent_P3.Text = "WHEREAS, remaining bidders passed the preliminary examination of bids and subject for bid evaluation and post-qualification of bid;"
    '            txtContent_P4.Text = "WHEREAS, the bid proposal of the remaining bidders were found to be substantially complying;"
    '            txtContent_P5.Text = "WHEREAS, the detailed evaluation of bid conducted on " & BidConductedDate.ToLongDateString() & " resulted in the following;"
    '            txtContent_P6.Text = "WHEREAS, upon careful examination, validation and verification of all the eligibility, technical and financial requirements submitted by the LOWEST CALCULATED BIDDER for every items, its bid has been found to be responsive;"
    '            txtContent_P7.Text = "NOW, THEREFORE, We, the Members of the Bids and Awards Committee, hereby RESOLVE as it is hereby RESOLVED;"


    '            ' Display information based on how many bidders are present
    '            If dtReso.Rows.Count > 1 Then
    '                Dim bidder1 As String = dtReso.Rows(0)("SuppName").ToString()
    '                Dim bidder2 As String = dtReso.Rows(1)("SuppName").ToString()

    '                Dim Amt1 As Decimal = Convert.ToDecimal(dtReso.Rows(0)("ABC"))
    '                Dim Amt2 As Decimal = Convert.ToDecimal(dtReso.Rows(1)("ABC"))

    '                txtContent_P8.Text = "To declare " & bidder1 & " as the LOWEST CALCULATED RESPONSIVE BIDDER for the " & projectName & " amounting to " & FormatNumber(Amt1, 2) & " PESOS."
    '                txtContent_P9.Text = "To declare " & bidder2 & " as the LOWEST CALCULATED RESPONSIVE BIDDER for the " & projectName & " amounting to " & FormatNumber(Amt2, 2) & " PESOS."
    '                div1.Visible = True
    '            Else
    '                Dim bidder1 As String = dtReso.Rows(0)("SuppName").ToString()
    '                Dim Amt1 As Decimal = Convert.ToDecimal(dtReso.Rows(0)("ABC"))

    '                txtContent_P8.Text = "To declare " & bidder1 & " as the LOWEST CALCULATED RESPONSIVE BIDDER for the " & projectName & " amounting to " & FormatNumber(Amt1, 2) & " PESOS."
    '                txtContent_P9.Text = String.Empty
    '                div1.Visible = False
    '            End If

    '            ' Final content for the report
    '            txtContent_P10.Text = "To recommend for approval by the Provincial Governor of the Provincial Government of Cagayan the foregoing findings."
    '            txtContent_P11.Text = "RESOLVED at BAC Office, Capitol Hills, Tuguegarao City this " & ResolutionDate.ToString("dd") & " day of " & MonthName(ResolutionDate.Month) & ", " & ResolutionDate.Year & "."

    '            ' Load related items (details)
    '            dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_rpt_BACResolution_Dtl] " & pre_procurement_hdr_id, CommandType.Text)
    '            grdAsRead.DataSource = dtItems
    '            grdAsRead.DataBind()

    '            ' Set grid headers dynamically
    '            CType(grdAsRead.HeaderRow.FindControl("lblFirst"), Label).Text = dtItems.Rows(0)("Bidder_A").ToString()
    '            CType(grdAsRead.HeaderRow.FindControl("lblSecond"), Label).Text = dtItems.Rows(0)("Bidder_B").ToString()

    '            grdAsCalculated.DataSource = dtItems
    '            grdAsCalculated.DataBind()

    '            CType(grdAsCalculated.HeaderRow.FindControl("lblFirst_B"), Label).Text = dtItems.Rows(0)("Bidder_A").ToString()
    '            CType(grdAsCalculated.HeaderRow.FindControl("lblSecond_B"), Label).Text = dtItems.Rows(0)("Bidder_B").ToString()

    '        Else
    '            ' If no data is found, display a message
    '            txtProjectName.Text = "No data found for the provided procurement header ID."
    '        End If


    '        drpBAC1.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 3 or BAC_PostionID = 4 or BAC_PostionID = 5 ", CommandType.Text)
    '        drpBAC1.DataTextField = ("Name")
    '        drpBAC1.DataValueField = ("empsig_id")
    '        drpBAC1.DataBind()

    '        drpBAC2.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 3 or BAC_PostionID = 4 or BAC_PostionID = 5", CommandType.Text)
    '        drpBAC2.DataTextField = ("Name")
    '        drpBAC2.DataValueField = ("empsig_id")
    '        drpBAC2.DataBind()

    '        drpBAC3.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 3 or BAC_PostionID = 4 or BAC_PostionID = 5", CommandType.Text)
    '        drpBAC3.DataTextField = ("Name")
    '        drpBAC3.DataValueField = ("empsig_id")
    '        drpBAC3.DataBind()

    '        drpBACVC.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 2", CommandType.Text)
    '        drpBACVC.DataTextField = ("Name")
    '        drpBACVC.DataValueField = ("empsig_id")
    '        drpBACVC.DataBind()

    '        drpBACC.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 1", CommandType.Text)
    '        drpBACC.DataTextField = ("Name")
    '        drpBACC.DataValueField = ("empsig_id")
    '        drpBACC.DataBind()

    '        drpApprovedBy.DataSource = objDerived.GetDataTable("SELECT  * FROM HRMS.view_signatory WHERE deptid IN (1,7) AND division_Key = 86 AND isActive = 1 AND isDeptHead = 'Yes' ORDER BY Full_Name", CommandType.Text)
    '        drpApprovedBy.DataTextField = ("Full_Name")
    '        drpApprovedBy.DataValueField = ("EmpID")
    '        drpApprovedBy.DataBind()



    '    Catch ex As Exception
    '        ' Handle any exceptions and display an error message
    '        txtProjectName.Text = "Error loading report: " & ex.Message
    '    End Try
    'End Sub


    'Private Sub bidding_BACResolution_Report_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    If Not Page.IsPostBack Then
    '        ' Retrieve pre_procurement_hdr_id from QueryString instead of Session
    '        Dim pre_procurement_hdr_id As String = Request.QueryString("pre_procurement_hdr_id")

    '        ' Check if pre_procurement_hdr_id is provided
    '        If Not String.IsNullOrEmpty(pre_procurement_hdr_id) Then
    '            ' Call the report load method with pre_procurement_hdr_id from query string
    '            LoadBACResolutionReport(pre_procurement_hdr_id)
    '        Else
    '            ' Handle the case where the query string parameter is missing
    '            txtProjectName.Text = "No procurement header ID provided in the query string."
    '        End If
    '    End If
    'End Sub



    'Private Sub bidding_BACResolution_Report_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    If Not Page.IsPostBack Then
    '        'Session("pre_procurement_hdr_id") = 20053

    '        Dim pre_procurement_hdr_id As String = String.Empty

    '        If Session("pre_procurement_hdr_id") IsNot Nothing Then
    '            pre_procurement_hdr_id = Session("pre_procurement_hdr_id").ToString()
    '        Else
    '            ' Handle the case when the session variable is null
    '            Throw New Exception("pre_procurement_hdr_id is not set in session.")
    '        End If

    '        dtReso = objDerived.GetDataTable("EXEC [AMS].[sp_rpt_BACResolution_NEW] @pre_procurement_hdr_id", CommandType.Text,
    '                             New SqlParameter() {New SqlParameter("@pre_procurement_hdr_id", pre_procurement_hdr_id)})


    '        Dim x As String = dtReso.Rows(0)("project_name")
    '        txtProjectName.Text = x
    '        lblResoNumb.Text = dtReso.Rows(0)("resolution_number")


    '        Dim BidderCount As String = dtReso.Rows(0)("Cnt")
    '        Dim BidderList As String = dtReso.Rows(0)("SuppName_List")
    '        Dim DateOpen As String = dtReso.Rows(0)("opening_date") & " at " & dtReso.Rows(0)("opening_time")
    '        Dim BidConductedDate As Date = dtReso.Rows(0)("BidConducted_Date")
    '        Dim resolutionDate As Date = dtReso.Rows(0)("resolution_number_date")

    '        txtContent_P1.Text = "WHEREAS, The Provincial Government of Cagayan advertised the Invitation to Bid for the " & x & ", and posted the same in the Provincial Government of Cagayan website, the PhilGEPS and in a conspicuous place at the premises within the Provincial Government of Cagayan continuously for seven (7) days;"
    '        txtContent_P2.Text = "WHEREAS, in response to the said advertisements, " & BidderCount & " prospective bidders purchased bid documents namely " & BidderList & " but the latter failed to submit its bid proposal which was opened on " & DateOpen & "."
    '        txtContent_P3.Text = "WHEREAS, remaining bidders passed the preliminary examination of bids and subject for bid evaluation and post-qualification of bid;"
    '        txtContent_P4.Text = "WHEREAS, the bid proposal of the remaining bidders were found to be substantially complying;"
    '        txtContent_P5.Text = "WHEREAS, the detailed evaluation of bid conducted on " & BidConductedDate.ToLongDateString & " resulted the following;"
    '        txtContent_P6.Text = "WHEREAS, upon careful examination, validation and verification of all the eligibility, technical and financial requirements submitted by the LOWEST CALCULATED BIDDER for every items, its bid has been found to be responsive;"
    '        txtContent_P7.Text = "NOW, THEREFORE, We, the Members of the Bids and Awards Committee, hereby RESOLVE as it is hereby RESOLVED;"

    '        If dtReso.Rows.Count > 1 Then
    '            Dim bidder1 As String = dtReso.Rows(0)("SuppName")
    '            Dim bidder2 As String = dtReso.Rows(1)("SuppName")

    '            Dim Amt1 As Decimal = dtReso.Rows(0)("ABC")
    '            Dim Amt2 As Decimal = dtReso.Rows(1)("ABC")

    '            txtContent_P8.Text = "To declare " & bidder1 & " as the LOWEST CALCULATED RESPONSIVE BIDDER for the " & x & " amounting to " & FormatNumber(Amt1, 2) & " PESOS."
    '            txtContent_P9.Text = "To declare " & bidder2 & " as the LOWEST CALCULATED RESPONSIVE BIDDER for the " & x & " amounting to " & FormatNumber(Amt2, 2) & " PESOS."
    '            div1.Visible = True

    '        Else
    '            Dim bidder1 As String = dtReso.Rows(0)("SuppName")
    '            Dim Amt1 As Decimal = dtReso.Rows(0)("ABC")

    '            txtContent_P8.Text = "To declare " & bidder1 & "  as the LOWEST CALCULATED RESPONSIVE BIDDER for the " & x & " amounting to " & Amt1 & " PESOS."
    '            txtContent_P9.Text = ""
    '            div1.Visible = False

    '        End If

    '        txtContent_P10.Text = "To recommend for approval by the Provincial Governor of the Provincial Government of Cagayan the foregoing findings."
    '        txtContent_P11.Text = "RESOLVED at BAC Office, Capitol Hills, Tuguegarao City this " & Day(resolutionDate.ToLongDateString) & " day of " & MonthName(Month(resolutionDate.ToLongDateString)) & " , " & Year(resolutionDate.ToLongDateString) & ""

    '        dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_rpt_BACResolution_Dtl] " & Session("pre_procurement_hdr_id") & "", CommandType.Text)
    '        grdAsRead.DataSource = dtItems
    '        grdAsRead.DataBind()



    '        CType(grdAsRead.HeaderRow.FindControl("lblFirst"), Label).Text = dtItems.Rows(0)("Bidder_A")
    '        CType(grdAsRead.HeaderRow.FindControl("lblSecond"), Label).Text = dtItems.Rows(0)("Bidder_B")

    '        grdAsCalculated.DataSource = dtItems
    '        grdAsCalculated.DataBind()

    '        CType(grdAsCalculated.HeaderRow.FindControl("lblFirst_B"), Label).Text = dtItems.Rows(0)("Bidder_A")
    '        CType(grdAsCalculated.HeaderRow.FindControl("lblSecond_B"), Label).Text = dtItems.Rows(0)("Bidder_B")


    '        drpBAC1.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 3 or BAC_PostionID = 4 or BAC_PostionID = 5 ", CommandType.Text)
    '        drpBAC1.DataTextField = ("Name")
    '        drpBAC1.DataValueField = ("empsig_id")
    '        drpBAC1.DataBind()

    '        drpBAC2.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 3 or BAC_PostionID = 4 or BAC_PostionID = 5", CommandType.Text)
    '        drpBAC2.DataTextField = ("Name")
    '        drpBAC2.DataValueField = ("empsig_id")
    '        drpBAC2.DataBind()

    '        drpBAC3.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 3 or BAC_PostionID = 4 or BAC_PostionID = 5", CommandType.Text)
    '        drpBAC3.DataTextField = ("Name")
    '        drpBAC3.DataValueField = ("empsig_id")
    '        drpBAC3.DataBind()

    '        drpBACVC.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 2", CommandType.Text)
    '        drpBACVC.DataTextField = ("Name")
    '        drpBACVC.DataValueField = ("empsig_id")
    '        drpBACVC.DataBind()

    '        drpBACC.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 1", CommandType.Text)
    '        drpBACC.DataTextField = ("Name")
    '        drpBACC.DataValueField = ("empsig_id")
    '        drpBACC.DataBind()

    '        drpApprovedBy.DataSource = objDerived.GetDataTable("SELECT  * FROM HRMS.view_signatory WHERE deptid IN (1,7) AND division_Key = 86 AND isActive = 1 AND isDeptHead = 'Yes' ORDER BY Full_Name", CommandType.Text)
    '        drpApprovedBy.DataTextField = ("Full_Name")
    '        drpApprovedBy.DataValueField = ("EmpID")
    '        drpApprovedBy.DataBind()

    '    End If
    'End Sub

    Private Sub btnSaveBacReso_Click(sender As Object, e As EventArgs) Handles btnSaveBacReso.Click
        With BACResolution
            'BACResolution_ID,
            .pre_procurement_hdr_id = Session("pre_procurement_hdr_id")
            .Resolution_No = lblResoNumb.Text
            .ProjectName = txtProjectName.Text
            .txtContent_1 = txtContent_P1.Text
            .txtContent_2 = txtContent_P2.Text
            .txtContent_3 = txtContent_P3.Text
            .txtContent_4 = txtContent_P4.Text
            .txtContent_5 = txtContent_P5.Text
            .txtContent_6 = txtContent_P6.Text
            .txtContent_7 = txtContent_P7.Text
            .txtContent_8 = txtContent_P8.Text
            .txtContent_9 = txtContent_P9.Text
            .txtContent_10 = txtContent_P10.Text
            .txtContent_11 = txtContent_P11.Text
            .BAC1 = drpBAC1.SelectedItem.Value
            .BAC2 = drpBAC2.SelectedItem.Value
            .BAC3 = drpBAC3.SelectedItem.Value
            .BACVC = drpBACVC.SelectedItem.Value
            .BACC = drpBACC.SelectedItem.Value
            .ApprovedBy = drpApprovedBy.SelectedItem.Value
            .save()
        End With

        Session("Page") = "RQ"
        Session("Report") = "BACReso"
        Me.Page.Response.Redirect("~/MainReports/Bidding_Reports.aspx")

    End Sub

End Class
