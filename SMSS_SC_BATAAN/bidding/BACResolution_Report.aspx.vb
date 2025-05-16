Imports System.Data

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
        If Not IsPostBack Then
            ' Retrieve query string parameters
            Dim pre_procurement_hdr_id As String = Request.QueryString("pre_procurement_hdr_id")
            Dim supplierId As String = Request.QueryString("supplierId")
            Dim projectName As String = Request.QueryString("projectName")
            Dim totalBidAmount As String = Request.QueryString("totalBidAmount")

            ' Ensure the parameters are not null or empty before proceeding
            If Not String.IsNullOrEmpty(pre_procurement_hdr_id) Then
                ' Use the values to load the data or display in the labels
                LoadBACResolutionReport(pre_procurement_hdr_id, supplierId, projectName, totalBidAmount)
            Else
                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid parameters.")
            End If
        End If
    End Sub

    Private Sub LoadBACResolutionReport(pre_procurement_hdr_id As String, supplierId As String, projectName As String, totalBidAmount As String)
        ' Your logic to load the report data or bind it to the controls
        txtProjectName.Text = projectName

        ' Fetch and bind data based on the pre_procurement_hdr_id and supplierId
        ' Example:
        Dim dtReso As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_rpt_BACResolution_NEW] " & pre_procurement_hdr_id, CommandType.Text)
        ' Bind the data to the controls (e.g., labels, grids)
    End Sub

    Private Sub bidding_BACResolution_Report_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Session("pre_procurement_hdr_id") = 20053

            dtReso = objDerived.GetDataTable("EXEC [AMS].[sp_rpt_BACResolution_NEW] " & Session("pre_procurement_hdr_id") & "", CommandType.Text)

            Dim x As String = dtReso.Rows(0)("project_name")
            txtProjectName.Text = x
            lblResoNumb.Text = dtReso.Rows(0)("resolution_number")

            Dim BidderCount As String = dtReso.Rows(0)("Cnt")
            Dim BidderList As String = dtReso.Rows(0)("SuppName_List")

            Dim DateOpen As String = dtReso.Rows(0)("opening_date") & " at " & dtReso.Rows(0)("opening_time")
            Dim BidConductedDate As Date = dtReso.Rows(0)("BidConducted_Date")
            Dim resolutionDate As Date = dtReso.Rows(0)("resolution_number_date")
            Dim SuppName As String = dtReso.Rows(0)("SuppName")
            Dim Venue As String = dtReso.Rows(0)("opening_venue")
            Dim Amt1 As Decimal = dtReso.Rows(0)("Amount")
            Dim ApproveBy As String = dtReso.Rows(0)("ApprovedBy")
            Dim ApproveByPosition As String = dtReso.Rows(0)("ApprovedBy_Pos")


            txtContent_P1.Text = "WHEREAS, the Provincial Bids and Awards Committee - Goods and Services (PBAC-GS), through PBAC-GS Resolution No. 008-1, S-2024 dated April 19, 2024, recommended the award of the contract / project: " & x & " to the bidder, " & SuppName & " ;"
            txtContent_P2.Text = "WHEREAS, in examining the documents submitted comprising the technical component thereof, the COMMITTEE found out that the bidders: " & BidderList & " were ELIGIBLE and QUALIFIED to Bid;"
            txtContent_P3.Text = "WHEREAS, after having determined the Lowest Calculated Bid, and subsequently having conducted a post-qualification thereon, " & SuppName & " is found to be the Lowest Calculated and Responsive Bid, and the same was considered the most advantageous offer in favor of the Provincial Government of Cagayan;"
            txtContent_P4.Text = "WHEREAS, the Abstract of Bids, which reflects the bid prices as read and the corresponding Calculated Bid Prices of the qualified participating bidders, the Post-Qualification Report, Technical Working Group Report, and Bid Evaluation Report, are attached and made integral parts of this resolution;"
            txtContent_P7.Text = "NOW, THEREFORE, on motion duly seconded:"

            'If dtReso.Rows.Count > 1 Then
            '    Dim bidder1 As String = dtReso.Rows(0)("SuppName")
            '    Dim bidder2 As String = dtReso.Rows(1)("SuppName")

            '    Dim Amt1 As Decimal = dtReso.Rows(0)("ABC")
            '    Dim Amt2 As Decimal = dtReso.Rows(1)("ABC")

            '    txtContent_P8.Text = "To declare " & bidder1 & " as the LOWEST CALCULATED RESPONSIVE BIDDER for the " & x & " amounting to " & FormatNumber(Amt1, 2) & " PESOS."
            '    txtContent_P9.Text = "To declare " & bidder2 & " as the LOWEST CALCULATED RESPONSIVE BIDDER for the " & x & " amounting to " & FormatNumber(Amt2, 2) & " PESOS."
            '    div1.Visible = True

            'Else
            '    Dim bidder1 As String = dtReso.Rows(0)("SuppName")
            '    Dim Amt1 As Decimal = dtReso.Rows(0)("ABC")

            '    txtContent_P8.Text = "To declare " & bidder1 & "  as the LOWEST CALCULATED RESPONSIVE BIDDER for the " & x & " amounting to " & Amt1 & " PESOS."
            '    txtContent_P9.Text = ""
            '    div1.Visible = False

            'End If
            txtContent_P8.Text = "RESOLVE, as it is hereby RESOLVED, to recommend AWARD of the project/contract " & x & " to the bidder " & SuppName & " for a total contract price of " & FormatNumber(Amt1, 2) & " PESOS only;"

            txtContent_P10.Text = "RESOLVED FURTHER to furnish copies of this resolution to the Honorable " & ApproveBy & ", " & ApproveByPosition & ", and subsequently to all concerned for their information; "
            txtContent_P11.Text = "Done this " & Day(resolutionDate.ToLongDateString) & " day of " & MonthName(Month(resolutionDate.ToLongDateString)) & " , " & Year(resolutionDate.ToLongDateString) & ", at the " & Venue & ", Capitol Hills, Tuguegarao City, Cagayan."

            'dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_rpt_BACResolution_Dtl] " & Session("pre_procurement_hdr_id") & "", CommandType.Text)

            'grdAsRead.DataSource = dtItems
            'grdAsRead.DataBind()

            'CType(grdAsRead.HeaderRow.FindControl("lblFirst"), Label).Text = dtItems.Rows(0)("Bidder_A")
            'CType(grdAsRead.HeaderRow.FindControl("lblSecond"), Label).Text = dtItems.Rows(0)("Bidder_B")

            'grdAsCalculated.DataSource = dtItems
            'grdAsCalculated.DataBind()

            'CType(grdAsCalculated.HeaderRow.FindControl("lblFirst_B"), Label).Text = dtItems.Rows(0)("Bidder_A")
            'CType(grdAsCalculated.HeaderRow.FindControl("lblSecond_B"), Label).Text = dtItems.Rows(0)("Bidder_B")



            drpBAC1.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 3 or BAC_PostionID = 4 or BAC_PostionID = 5 ", CommandType.Text)
            drpBAC1.DataTextField = ("Name")
            drpBAC1.DataValueField = ("empsig_id")
            drpBAC1.DataBind()

            drpBAC2.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 3 or BAC_PostionID = 4 or BAC_PostionID = 5", CommandType.Text)
            drpBAC2.DataTextField = ("Name")
            drpBAC2.DataValueField = ("empsig_id")
            drpBAC2.DataBind()

            drpBAC3.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 3 or BAC_PostionID = 4 or BAC_PostionID = 5", CommandType.Text)
            drpBAC3.DataTextField = ("Name")
            drpBAC3.DataValueField = ("empsig_id")
            drpBAC3.DataBind()

            drpBAC4.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 3 or BAC_PostionID = 4 or BAC_PostionID = 5", CommandType.Text)
            drpBAC4.DataTextField = ("Name")
            drpBAC4.DataValueField = ("empsig_id")
            drpBAC4.DataBind()

            drpBAC5.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 3 or BAC_PostionID = 4 or BAC_PostionID = 5", CommandType.Text)
            drpBAC5.DataTextField = ("Name")
            drpBAC5.DataValueField = ("empsig_id")
            drpBAC5.DataBind()

            drpBACVC.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 2", CommandType.Text)
            drpBACVC.DataTextField = ("Name")
            drpBACVC.DataValueField = ("empsig_id")
            drpBACVC.DataBind()

            drpBACC.DataSource = objDerived.GetDataTable("Select * From DBO.View_BACMembers Where isActive = 1 And isDefault = 1 And BAC_PostionID = 1", CommandType.Text)
            drpBACC.DataTextField = ("Name")
            drpBACC.DataValueField = ("empsig_id")
            drpBACC.DataBind()

            drpApprovedBy.DataSource = objDerived.GetDataTable("SELECT  * FROM HRMS.view_signatory WHERE deptid IN (1,7) AND division_Key = 86 AND isActive = 1 AND isDeptHead = 'Yes' ORDER BY Full_Name", CommandType.Text)
            drpApprovedBy.DataTextField = ("Full_Name")
            drpApprovedBy.DataValueField = ("EmpID")
            drpApprovedBy.DataBind()

        End If
    End Sub

    Private Sub btnSaveBacReso_Click(sender As Object, e As EventArgs) Handles btnSaveBacReso.Click
        '-Commented out as the report format is different, don't remove might be useful next time

        'With BACResolution
        '    'BACResolution_ID,
        '    .pre_procurement_hdr_id = Session("pre_procurement_hdr_id")
        '    .Resolution_No = lblResoNumb.Text
        '    .ProjectName = txtProjectName.Text
        '    .txtContent_1 = txtContent_P1.Text
        '    .txtContent_2 = txtContent_P2.Text
        '    .txtContent_3 = txtContent_P3.Text
        '    .txtContent_4 = txtContent_P4.Text
        '    .txtContent_7 = txtContent_P7.Text
        '    .txtContent_8 = txtContent_P8.Text
        '    .txtContent_10 = txtContent_P10.Text
        '    .txtContent_11 = txtContent_P11.Text
        '    .BAC1 = drpBAC1.SelectedItem.Value
        '    .BAC2 = drpBAC2.SelectedItem.Value
        '    .BAC3 = drpBAC3.SelectedItem.Value
        '    .BACVC = drpBACVC.SelectedItem.Value
        '    .BACC = drpBACC.SelectedItem.Value
        '    .ApprovedBy = drpApprovedBy.SelectedItem.Value
        '    .save()
        'End With

        Session("b1") = drpBAC1.SelectedItem.Text
        Session("b2") = drpBAC2.SelectedItem.Text
        Session("b3") = drpBAC3.SelectedItem.Text
        If selectionDD.SelectedValue = 7 Then
            Session("b4") = drpBAC4.SelectedItem.Text
            Session("b5") = drpBAC5.SelectedItem.Text
            Session("txtBox") = "BAC Member"
        ElseIf selectionDD.SelectedValue = 5 Then
            Session("b4") = ""
            Session("b5") = ""
            Session("txtBox") = ""
        End If
        Session("bvc") = drpBACVC.SelectedItem.Text
        Session("bc") = drpBACC.SelectedItem.Text
        Session("bApprove") = drpApprovedBy.SelectedItem.Text

        Session("Page") = "RQ"
        Session("Report") = "BACReso"
        Me.Page.Response.Redirect("~/MainReports/Bidding_Reports.aspx")

    End Sub

    Protected Sub selectionDD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles selectionDD.SelectedIndexChanged
        If selectionDD.SelectedValue = 7 Then
            drpBAC4.Enabled = True
            drpBAC5.Enabled = True
        ElseIf selectionDD.SelectedValue = 5 Then
            drpBAC4.Enabled = False
            drpBAC5.Enabled = False
        End If
    End Sub
End Class
