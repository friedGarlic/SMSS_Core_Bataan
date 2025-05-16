Imports System.Data

Partial Class Reports_and_Query_DisposalReports
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule

#Region "temp"
    Public Function tempAOA(ByVal row As Integer) As DataTable
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
    Public Function tempAbstract(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Disposal_Bid_hdr", GetType(Integer))
        dt.Columns.Add("BidDate", GetType(Date))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Disposal_Bid_hdr") = DBNull.Value
            dr("BidDate") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function temp_dtAppraisal(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("IIRUPHdr_ID", GetType(Integer))
        dt.Columns.Add("WMHdr_ID", GetType(Integer))
        dt.Columns.Add("IIRUP_Date", GetType(Date))
        dt.Columns.Add("IIRUP_No", GetType(String))
        dt.Columns.Add("particulars", GetType(String))
        dt.Columns.Add("AppraisedVal", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("IIRUPHdr_ID") = DBNull.Value
            dr("WMHdr_ID") = DBNull.Value
            dr("IIRUP_Date") = DBNull.Value
            dr("IIRUP_No") = DBNull.Value
            dr("particulars") = DBNull.Value
            dr("AppraisedVal") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function tempNOA(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("QuotationHdr_ID", GetType(Long))
        dt.Columns.Add("Supplier_ID", GetType(Integer))
        dt.Columns.Add("IsspHdr_ID", GetType(Long))
        dt.Columns.Add("Issp_No", GetType(String))
        dt.Columns.Add("Abstract_Date", GetType(Date))
        dt.Columns.Add("Issp_Date", GetType(Date))
        dt.Columns.Add("TotalBidAmt", GetType(Decimal))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("BidType", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("QuotationHdr_ID") = DBNull.Value
            dr("Supplier_ID") = DBNull.Value
            dr("IsspHdr_ID") = DBNull.Value
            dr("Issp_No") = DBNull.Value
            dr("Abstract_Date") = DBNull.Value
            dr("Issp_Date") = DBNull.Value
            dr("TotalBidAmt") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("BidType") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function tempDonation(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("IIRUPHdr_ID", GetType(Integer))
        dt.Columns.Add("IIRUP_Date", GetType(Date))
        dt.Columns.Add("IIRUP_No", GetType(String))
        dt.Columns.Add("Disposa_date", GetType(Date))
        dt.Columns.Add("AuthorizedBy", GetType(String))
        dt.Columns.Add("Agency_Receipt", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("IIRUPHdr_ID") = DBNull.Value
            dr("IIRUP_Date") = DBNull.Value
            dr("IIRUP_No") = DBNull.Value
            dr("Disposa_date") = DBNull.Value
            dr("AuthorizedBy") = DBNull.Value
            dr("Agency_Receipt") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
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
#End Region
#Region "Datatables"
    Private Property dtIIRUP() As DataTable
        Get
            Return CType(Session("dtIIRUP"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtIIRUP") = value
        End Set
    End Property

    Private Property dtISSP() As DataTable
        Get
            Return CType(Session("dtISSP"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtISSP") = value
        End Set
    End Property

    Private Property dtAppraisal() As DataTable
        Get
            Return CType(Session("dtAppraisal"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAppraisal") = value
        End Set
    End Property

    Private Property dtAbstract() As DataTable
        Get
            Return CType(Session("dtAbstract"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAbstract") = value
        End Set
    End Property
    Private Property dtNOA() As DataTable
        Get
            Return CType(Session("dtNOA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtNOA") = value
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
    Private Property dtDonation() As DataTable
        Get
            Return CType(Session("dtDonation"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDonation") = value
        End Set
    End Property

    Private Property dtDFA() As DataTable
        Get
            Return CType(Session("dtDFA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDFA") = value
        End Set
    End Property
    Private Property dtAOA() As DataTable
        Get
            Return CType(Session("dtAOA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAOA") = value
        End Set
    End Property
#End Region


    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub Reports_and_Query_DisposalReports_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            '=== DEFAULT TAB IIRUP ===
            LoadTab1()

        End If

        drpSearch_IIRUP.Attributes.Add("onChange", "StartProgressBar();")
        txtSearch_IIRUP.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_IIRUP.ClientID & "')")
        txtDateFrom_IITUP.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_IIRUPDate.ClientID & "')")
        txtDateTo_IITUP.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_IIRUPDate.ClientID & "')")


        drpSearch_ISSP.Attributes.Add("onChange", "StartProgressBar();")
        txtSearch_ISSP.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_ISSP.ClientID & "')")
        txtDateFrom_ISSP.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchDate_ISSP.ClientID & "')")
        txtDateTo_ISSP.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchDate_ISSP.ClientID & "')")


        drpSearch_Abstract.Attributes.Add("onChange", "StartProgressBar();")
        txtSearch_Abstract.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_Abstract.ClientID & "')")
        txtSearchDateFrom_Abstract.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchDate_Abstract.ClientID & "')")
        txtSearchDateTo_Abstract.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchDate_Abstract.ClientID & "')")


        drpSearch_NOA.Attributes.Add("onChange", "StartProgressBar();")
        txtSearch_NOA.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_NOA.ClientID & "')")
        txtSearchDateFrom_NOA.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchDate_NOA.ClientID & "')")
        txtSearchDateTo_NOA.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchDate_NOA.ClientID & "')")
        txtNTP_Search.Attributes.Add("onkeypress", "return fun1(event,'" & btnNTP_Search.ClientID & "')")

    End Sub

    Protected Sub LoadTab1()
        btnTab1_IIRUP.CssClass = "TabButton_Active"
        btnTab7_Appraisal.CssClass = "TabButton_InActive"
        btnTab2_ISSP.CssClass = "TabButton_InActive"
        btnTab3_Abstract.CssClass = "TabButton_InActive"
        btnTab4_NOA.CssClass = "TabButton_InActive"
        btnTab5_NTP.CssClass = "TabButton_InActive"
        btnTab6_Donation.CssClass = "TabButton_InActive"
        btnTab8_DFA.CssClass = "TabButton_InActive"
        btnTab9_AOA.CssClass = "TabButton_InActive"

        pnlDateSearch_IIRUP1.Visible = True
        pnlDateSearch_IIRUP2.Visible = False

        'dtIIRUP = objDerived.GetDataTable("SELECT DISTINCT A.IIRUPHdr_ID, A.IIRUP_Date, A.IIRUP_No, A.particulars, SUM(B.AppraisedVal) AS TotalAppraisedValue, CASE WHEN A.Function_ID = 86 THEN C.RC_Name ELSE C.Function_Desc END AS RC_Name  " &
        '                                    " FROM AMS.IIRUP_Hdr AS A INNER JOIN AMS.IIRUP_Dtl AS B ON A.IIRUPHdr_ID = B.IIRUPHdr_ID INNER JOIN DBO.View_RespCenter_withFunctions AS C ON A.RC_ID = C.RC_ID AND A.Function_ID = C.Function_ID   " &
        '                                    " GROUP BY A.IIRUPHdr_ID, A.IIRUP_Date, A.IIRUP_No, A.particulars, A.Function_ID, C.RC_Name, C.Function_Desc ORDER BY A.IIRUP_Date DESC, A.IIRUP_No DESC", CommandType.Text)

        dtIIRUP = objDerived.GetDataTable("EXEC AMS.sp_GetIIRUPDetails", CommandType.Text)
        grdIIRUP.DataSource = dtIIRUP
        grdIIRUP.DataBind()

        mvTabs.SetActiveView(Me.vwTab1_IIRUP)
    End Sub

    Private Sub btnTab1_IIRUP_Click(sender As Object, e As EventArgs) Handles btnTab1_IIRUP.Click
        LoadTab1()
    End Sub



    Private Sub btnTab2_ISSP_Click(sender As Object, e As EventArgs) Handles btnTab2_ISSP.Click
        btnTab1_IIRUP.CssClass = "TabButton_InActive"
        btnTab7_Appraisal.CssClass = "TabButton_InActive"
        btnTab2_ISSP.CssClass = "TabButton_Active"
        btnTab3_Abstract.CssClass = "TabButton_InActive"
        btnTab4_NOA.CssClass = "TabButton_InActive"
        btnTab5_NTP.CssClass = "TabButton_InActive"
        btnTab6_Donation.CssClass = "TabButton_InActive"
        btnTab8_DFA.CssClass = "TabButton_InActive"
        btnTab9_AOA.CssClass = "TabButton_InActive"

        pnl_ISSP1.Visible = True
        pnl_ISSP2.Visible = False
        txtSearch_ISSP.Text = ""

        dtISSP = objDerived.GetDataTable("SELECT IsspHdr_ID, Issp_Date, Issp_No, MinBid_Amt, CASE WHEN BidType = 1 THEN 'Per Item' ELSE 'Per Lot' END AS BidType, CONVERT(BIT, 1) AS isVisible FROM AMS.tbl_ISSP_hdr ORDER BY Issp_Date DESC, Issp_No DESC", CommandType.Text)
        If dtISSP.Rows.Count < 5 Then
            dtISSP.Merge(tempISSP(4 - dtISSP.Rows.Count))
        End If
        grdISSP.DataSource = dtISSP
        grdISSP.DataBind()

        mvTabs.SetActiveView(Me.vwTab2_ISSP)
    End Sub
    Protected Sub btnTab7_Appraisal_Click(sender As Object, e As EventArgs)
        btnTab1_IIRUP.CssClass = "TabButton_InActive"
        btnTab7_Appraisal.CssClass = "TabButton_Active"
        btnTab2_ISSP.CssClass = "TabButton_InActive"
        btnTab3_Abstract.CssClass = "TabButton_InActive"
        btnTab4_NOA.CssClass = "TabButton_InActive"
        btnTab5_NTP.CssClass = "TabButton_InActive"
        btnTab6_Donation.CssClass = "TabButton_InActive"
        btnTab8_DFA.CssClass = "TabButton_InActive"
        btnTab9_AOA.CssClass = "TabButton_InActive"

        pn_Apprailsal1.visible = True
        pn_Apprailsal2.visible = False
        txtSearchApprailsal.text = ""

        dtAppraisal = objDerived.GetDataTable("EXEC [AMS].[sp_ListForAppraisal_report]", CommandType.Text)

        If dtAppraisal.Rows.Count <= 5 Then
            dtAppraisal.Merge(temp_dtAppraisal(4 - dtAppraisal.Rows.Count))
        End If
        grdDisposalAppraisal.DataSource = dtAppraisal
        grdDisposalAppraisal.DataBind()

        mvTabs.SetActiveView(Me.vwTab7_Appraisal)
    End Sub
    Private Sub btnTab3_Abstract_Click(sender As Object, e As EventArgs) Handles btnTab3_Abstract.Click
        btnTab1_IIRUP.CssClass = "TabButton_InActive"
        btnTab7_Appraisal.CssClass = "TabButton_InActive"
        btnTab2_ISSP.CssClass = "TabButton_InActive"
        btnTab3_Abstract.CssClass = "TabButton_Active"
        btnTab4_NOA.CssClass = "TabButton_InActive"
        btnTab5_NTP.CssClass = "TabButton_InActive"
        btnTab6_Donation.CssClass = "TabButton_InActive"
        btnTab8_DFA.CssClass = "TabButton_InActive"
        btnTab9_AOA.CssClass = "TabButton_InActive"

        pnl_Abstract1.Visible = True
        pnl_Abstract2.Visible = False
        txtSearch_Abstract.Text = ""

        dtAbstract = objDerived.GetDataTable("SELECT  DBH.Disposal_Bid_hdr_id,DBH.BidDate,DT.Description,S.SuppName FROM " &
                                           " AMS.Disposal_Bid_hdr AS DBH INNER JOIN " &
                                           " AMS.Disposal_Bid_dtl AS DBD ON DBH.Disposal_Bid_hdr_id = DBD.Disposal_Bid_hdr_id INNER JOIN " &
                                           " AMS.Disposal_type AS DT ON DBH.Disposal_id = DT.Disposal_id INNER JOIN " &
                                           " dbo.Supplier AS S ON DBD.Supplier_ID = S.Supplier_Id", CommandType.Text)

        If dtAbstract.Rows.Count < 5 Then
            dtAbstract.Merge(tempAbstract(4 - dtAbstract.Rows.Count))
        End If
        grdAbstract.DataSource = dtAbstract
        grdAbstract.DataBind()

        mvTabs.SetActiveView(Me.vwTab3_Abstract)

    End Sub

    Private Sub btnTab4_NOA_Click(sender As Object, e As EventArgs) Handles btnTab4_NOA.Click
        btnTab1_IIRUP.CssClass = "TabButton_InActive"
        btnTab7_Appraisal.CssClass = "TabButton_InActive"
        btnTab2_ISSP.CssClass = "TabButton_InActive"
        btnTab3_Abstract.CssClass = "TabButton_InActive"
        btnTab4_NOA.CssClass = "TabButton_Active"
        btnTab5_NTP.CssClass = "TabButton_InActive"
        btnTab6_Donation.CssClass = "TabButton_InActive"
        btnTab8_DFA.CssClass = "TabButton_InActive"
        btnTab9_AOA.CssClass = "TabButton_InActive"

        pnl_NOA1.Visible = True
        pnl_NOA2.Visible = False
        txtSearch_NOA.Text = ""

        dtNOA = objDerived.GetDataTable("SELECT DISTINCT A.IsspHdr_ID, a.NOA_Date, a.Issp_No, CASE WHEN A.BidType = 1 THEN 'Per Item' ELSE 'Per Lot' END AS BidType             " &
                                        " ,  C.SuppName, B.TotalBidAmt, B.Supplier_ID, B.QuotationHdr_ID, CONVERT(BIT, 1) AS isVisible FROM AMS.tbl_ISSP_hdr AS A               " &
                                        " INNER JOIN AMS.tbl_QuotationHdr AS B ON A.IsspHdr_ID = B.IsspHdr_ID INNER JOIN DBO.Supplier AS C ON B.Supplier_ID = C.Supplier_Id     " &
                                        " WHERE ISNULL(A.isClose,0) = 1 AND ISNULL(A.withWinner,0) = 1 AND ISNULL(B.isWinner,0) = 1 AND ISNULL(A.withNOA,0) = 1                 " &
                                        " ORDER BY A.NOA_Date DESC, A.Issp_No DESC", CommandType.Text)

        If dtNOA.Rows.Count < 5 Then
            dtNOA.Merge(tempNOA(4 - dtNOA.Rows.Count))
        End If
        grdNOA.DataSource = dtNOA
        grdNOA.DataBind()

        mvTabs.SetActiveView(Me.vwTab4_NOA)

    End Sub

    Private Sub btnTab5_NTP_Click(sender As Object, e As EventArgs) Handles btnTab5_NTP.Click
        btnTab1_IIRUP.CssClass = "TabButton_InActive"
        btnTab7_Appraisal.CssClass = "TabButton_InActive"
        btnTab2_ISSP.CssClass = "TabButton_InActive"
        btnTab3_Abstract.CssClass = "TabButton_InActive"
        btnTab4_NOA.CssClass = "TabButton_InActive"
        btnTab5_NTP.CssClass = "TabButton_Active"
        btnTab6_Donation.CssClass = "TabButton_InActive"
        btnTab8_DFA.CssClass = "TabButton_InActive"
        btnTab9_AOA.CssClass = "TabButton_InActive"

        dtNTP = objDerived.GetDataTable("SELECT DISTINCT A.IsspHdr_ID, A.NTP_Date, A.Issp_No, CASE WHEN A.BidType = 1 THEN 'Per Item' ELSE 'Per Lot' END AS BidType             " &
                                        " ,  C.SuppName, B.TotalBidAmt, B.Supplier_ID, B.QuotationHdr_ID, CONVERT(BIT, 1) AS isVisible FROM AMS.tbl_ISSP_hdr AS A               " &
                                        " INNER JOIN AMS.tbl_QuotationHdr AS B ON A.IsspHdr_ID = B.IsspHdr_ID INNER JOIN DBO.Supplier AS C ON B.Supplier_ID = C.Supplier_Id     " &
                                        " WHERE ISNULL(A.isClose,0) = 1 AND ISNULL(A.withWinner,0) = 1 AND ISNULL(B.isWinner,0) = 1 AND ISNULL(A.withNOA,0) = 1 AND ISNULL(A.withNTP,0) = 1                  " &
                                        " ORDER BY A.NTP_Date DESC, A.Issp_No DESC", CommandType.Text)

        If dtNTP.Rows.Count < 5 Then
            dtNTP.Merge(tempNOA(4 - dtNTP.Rows.Count))
        End If
        grdNTP.DataSource = dtNTP
        grdNTP.DataBind()

        mvTabs.SetActiveView(Me.vwTab5_NTP)

    End Sub

    Private Sub btnTab6_Donation_Click(sender As Object, e As EventArgs) Handles btnTab6_Donation.Click
        btnTab1_IIRUP.CssClass = "TabButton_InActive"
        btnTab7_Appraisal.CssClass = "TabButton_InActive"
        btnTab2_ISSP.CssClass = "TabButton_InActive"
        btnTab3_Abstract.CssClass = "TabButton_InActive"
        btnTab4_NOA.CssClass = "TabButton_InActive"
        btnTab5_NTP.CssClass = "TabButton_InActive"
        btnTab6_Donation.CssClass = "TabButton_Active"
        btnTab8_DFA.CssClass = "TabButton_InActive"
        btnTab9_AOA.CssClass = "TabButton_InActive"

        pnl_Donation1.Visible = True
        pnl_Donation2.Visible = False
        txtSearch_Donation.Text = ""

        dtDonation = objDerived.GetDataTable("SELECT A.Disposal_Donation_hdr_id, A.IIRUPHdr_ID, B.IIRUP_Date, B.IIRUP_No, A.Disposa_date, A.AuthorizedBy, A.Agency_Receipt, CONVERT(BIT, 1) AS isVisible,A.TransTo FROM AMS.Disposal_Donation_hdr AS A INNER JOIN AMS.IIRUP_Hdr AS B ON A.IIRUPHdr_ID = B.IIRUPHdr_ID ORDER BY A.Disposa_date DESC", CommandType.Text)
        If dtDonation.Rows.Count < 5 Then
            dtDonation.Merge(tempDonation(4 - dtDonation.Rows.Count))
        End If
        grdDonation.DataSource = dtDonation
        grdDonation.DataBind()

        mvTabs.SetActiveView(Me.vwTab6_Donation)
    End Sub

    Protected Sub btnTab8_DFA_Click(sender As Object, e As EventArgs)

        'btnTab1_IIRUP.CssClass = "TabButton_InActive"
        'btnTab7_Appraisal.CssClass = "TabButton_InActive"
        'btnTab2_ISSP.CssClass = "TabButton_InActive"
        'btnTab3_Abstract.CssClass = "TabButton_InActive"
        'btnTab4_NOA.CssClass = "TabButton_InActive"
        'btnTab5_NTP.CssClass = "TabButton_InActive"
        'btnTab6_Donation.CssClass = "TabButton_InActive"
        'btnTab8_DFA.CssClass = "TabButton_Active"

        'dtDFA = objDerived.GetDataTable("SELECT DISTINCT A.Issp_Date, A.Issp_No, A.MinBid_Amt, A.AuctionDate, A.IsspHdr_ID, CONVERT(BIT,1) AS isVisible FROM AMS.tbl_ISSP_hdr AS A WHERE ISNULL(A.isClose,1) = 1 ORDER BY A.Issp_Date DESC, A.Issp_No DESC", CommandType.Text)
        'If dtDFA.Rows.Count < 5 Then
        '    dtDFA.Merge(dtTemp_ISSP(4 - dtDFA.Rows.Count))
        'End If
        'grdDFA.DataSource = dtDFA
        'grdDFA.DataBind()
        'mvTabs.SetActiveView(Me.vwTab8_DFA)

        ''OPtimize
        ' Consolidate CSS Class Assignment

        Dim tabButtons As Button() = {btnTab1_IIRUP, btnTab7_Appraisal, btnTab2_ISSP, btnTab3_Abstract, btnTab4_NOA, btnTab5_NTP, btnTab6_Donation, btnTab8_DFA}
        For Each btn In tabButtons
            btn.CssClass = If(btn Is btnTab8_DFA, "TabButton_Active", "TabButton_InActive")
        Next

        ' Database Operation
        Try
            dtDFA = objDerived.GetDataTable("SELECT DISTINCT A.Issp_Date, A.Issp_No, A.MinBid_Amt, A.AuctionDate, A.IsspHdr_ID, CONVERT(BIT,1) AS isVisible FROM AMS.tbl_ISSP_hdr AS A WHERE ISNULL(A.isClose,1) = 1 ORDER BY A.Issp_Date DESC, A.Issp_No DESC", CommandType.Text)
            If dtDFA.Rows.Count < 5 Then
                ' Assuming dtTemp_ISSP is another DataTable already fetched
                dtDFA.Merge(dtTemp_ISSP(4 - dtDFA.Rows.Count))
            End If
            grdDFA.DataSource = dtDFA
            grdDFA.DataBind()
        Catch ex As Exception
            ' Handle or log the exception
        End Try

        ' Set Active View
        mvTabs.SetActiveView(Me.vwTab8_DFA)
    End Sub
    Protected Sub btnTab9_AOA_Click(sender As Object, e As EventArgs)
        'btnTab1_IIRUP.CssClass = "TabButton_InActive"
        'btnTab7_Appraisal.CssClass = "TabButton_InActive"
        'btnTab2_ISSP.CssClass = "TabButton_InActive"
        'btnTab3_Abstract.CssClass = "TabButton_InActive"
        'btnTab4_NOA.CssClass = "TabButton_InActive"
        'btnTab5_NTP.CssClass = "TabButton_InActive"
        'btnTab6_Donation.CssClass = "TabButton_InActive"
        'btnTab8_DFA.CssClass = "TabButton_InActive"
        'btnTab9_AOA.CssClass = "TabButton_Active"

        'dtAOA = objDerived.GetDataTable("SELECT IsspHdr_ID, Issp_Date, Issp_No, MinBid_Amt, CASE WHEN BidType = 1 THEN 'Per Item' ELSE 'Per Lot' END AS BidType, 0 AS BidCnt, CONVERT(BIT, 1) AS isVisible FROM AMS.tbl_ISSP_hdr WHERE ISNULL(isClose,0) = 1 AND ISNULL(withQuotation,0) = 1 AND ISNULL(withWinner,0) = 0 ORDER BY Issp_Date DESC, Issp_No DESC", CommandType.Text)
        'If dtAOA.Rows.Count < 5 Then
        '    dtAOA.Merge(tempAOA(4 - dtAOA.Rows.Count))
        'End If
        'grdAOA.DataSource = dtAOA
        'grdAOA.DataBind()
        'mvTabs.SetActiveView(Me.vwTab9_AOA)
        ''Optimize


        ' Consolidate CSS Class Assignment
        Dim tabButtons As Dictionary(Of Button, String) = New Dictionary(Of Button, String) From {
            {btnTab1_IIRUP, "TabButton_InActive"},
            {btnTab7_Appraisal, "TabButton_InActive"},
            {btnTab2_ISSP, "TabButton_InActive"},
            {btnTab3_Abstract, "TabButton_InActive"},
            {btnTab4_NOA, "TabButton_InActive"},
            {btnTab5_NTP, "TabButton_InActive"},
            {btnTab6_Donation, "TabButton_InActive"},
            {btnTab8_DFA, "TabButton_InActive"},
            {btnTab9_AOA, "TabButton_Active"}
        }

        For Each kvp As KeyValuePair(Of Button, String) In tabButtons
            kvp.Key.CssClass = kvp.Value
        Next

        ' Database Operation
        Try
            dtAOA = objDerived.GetDataTable("SELECT IsspHdr_ID, Issp_Date, Issp_No, MinBid_Amt, CASE WHEN BidType = 1 THEN 'Per Item' ELSE 'Per Lot' END AS BidType, 0 AS BidCnt, CONVERT(BIT, 1) AS isVisible FROM AMS.tbl_ISSP_hdr WHERE ISNULL(isClose,0) = 1 AND ISNULL(withQuotation,0) = 1 AND ISNULL(withWinner,1) = 1 ORDER BY Issp_Date DESC, Issp_No DESC", CommandType.Text)
            If dtAOA.Rows.Count < 5 Then
                dtAOA.Merge(tempAOA(4 - dtAOA.Rows.Count))
            End If
            grdAOA.DataSource = dtAOA
            grdAOA.DataBind()
        Catch ex As Exception
            ' Handle or log the exception
        End Try

        ' Set Active View
        mvTabs.SetActiveView(Me.vwTab9_AOA)
    End Sub

    '============ IIRUP ============
    Private Sub btnSearch_IIRUP_Click(sender As Object, e As EventArgs) Handles btnSearch_IIRUP.Click
        Dim myview As DataView
        myview = dtIIRUP.DefaultView

        If drpSearch_IIRUP.SelectedItem.Value = 1 Then
            myview.RowFilter = "IIRUP_No like '%" & replaceapostrophe(txtSearch_IIRUP.Text) & "%'"

        ElseIf drpSearch_IIRUP.SelectedItem.Value = 2 Then
            myview.RowFilter = "RC_Name like '%" & replaceapostrophe(txtSearch_IIRUP.Text) & "%'"

        End If

        grdIIRUP.DataSource = myview
        grdIIRUP.DataBind()
    End Sub
    Private Sub btnSearch_IIRUPDate_Click(sender As Object, e As EventArgs) Handles btnSearch_IIRUPDate.Click
        Dim myview As DataView
        myview = dtIIRUP.DefaultView
        myview.RowFilter = "IIRUP_Date >= '" & txtDateFrom_IITUP.Text & "' AND IIRUP_Date <= '" & txtDateTo_IITUP.Text & "'"
        grdIIRUP.DataSource = myview
        grdIIRUP.DataBind()
    End Sub
    Private Sub drpSearch_IIRUP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpSearch_IIRUP.SelectedIndexChanged
        Try
            If drpSearch_IIRUP.SelectedItem.Value = 1 Then
                txtSearch_IIRUP.Text = ""

                pnlDateSearch_IIRUP1.Visible = True
                pnlDateSearch_IIRUP2.Visible = False

            ElseIf drpSearch_IIRUP.SelectedItem.Value = 2 Then
                txtSearch_IIRUP.Text = ""

                pnlDateSearch_IIRUP1.Visible = True
                pnlDateSearch_IIRUP2.Visible = False

            ElseIf drpSearch_IIRUP.SelectedItem.Value = 3 Then
                txtDateFrom_IITUP.Text = Date.Today.ToShortDateString
                txtDateTo_IITUP.Text = Date.Today.ToShortDateString

                pnlDateSearch_IIRUP1.Visible = False
                pnlDateSearch_IIRUP2.Visible = True

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdIIRUP_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdIIRUP.PageIndexChanging
        grdIIRUP.DataSource = dtIIRUP
        grdIIRUP.PageIndex = e.NewPageIndex
        grdIIRUP.DataBind()
    End Sub
    Private Sub grdIIRUP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdIIRUP.SelectedIndexChanged
        Session("IIRUPHdr_ID") = grdIIRUP.SelectedDataKey("IIRUPHdr_ID")
        Session("TransID") = grdIIRUP.SelectedDataKey("IIRUPHdr_ID")
        Session("Page") = "RQ"
        Me.Page.Response.Redirect("~/Inventory/Disposal/rpt_IIRUP.aspx")

    End Sub



    Protected Sub grdDisposalAppraisal_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("Appraisal_rpt_id") = objDerived.GetValue("SELECT TOP(1) [Appraisal_rpt_id] FROM [AMS].[tbl_AppraisalReport] ORDER BY [Appraisal_rpt_id] DESC", CommandType.Text)
        Session("Report") = "AppraisalRpt"

        Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")
    End Sub


    '============ ISSP ============
    Private Sub drpSearch_ISSP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpSearch_ISSP.SelectedIndexChanged
        Try
            If drpSearch_ISSP.SelectedItem.Value = 1 Then
                txtSearch_ISSP.Text = ""

                pnl_ISSP1.Visible = True
                pnl_ISSP2.Visible = False

            ElseIf drpSearch_ISSP.SelectedItem.Value = 2 Then
                txtSearch_ISSP.Text = ""

                pnl_ISSP1.Visible = True
                pnl_ISSP2.Visible = False

            ElseIf drpSearch_ISSP.SelectedItem.Value = 3 Then
                txtDateFrom_ISSP.Text = Date.Today.ToShortDateString
                txtDateTo_ISSP.Text = Date.Today.ToShortDateString

                pnl_ISSP1.Visible = False
                pnl_ISSP2.Visible = True

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSearch_ISSP_Click(sender As Object, e As EventArgs) Handles btnSearch_ISSP.Click
        Dim myview As DataView
        myview = dtISSP.DefaultView

        If drpSearch_ISSP.SelectedItem.Value = 1 Then
            myview.RowFilter = "Issp_No like '%" & replaceapostrophe(txtSearch_ISSP.Text) & "%'"

        ElseIf drpSearch_ISSP.SelectedItem.Value = 2 Then
            myview.RowFilter = "Submission_Loc like '%" & replaceapostrophe(txtSearch_ISSP.Text) & "%'"

        End If

        grdISSP.DataSource = myview
        grdISSP.DataBind()
    End Sub
    Private Sub btnSearchDate_ISSP_Click(sender As Object, e As EventArgs) Handles btnSearchDate_ISSP.Click
        Dim myview As DataView
        myview = dtISSP.DefaultView
        myview.RowFilter = "Issp_Date >= '" & txtDateFrom_ISSP.Text & "' AND Issp_Date <= '" & txtDateTo_ISSP.Text & "'"
        grdISSP.DataSource = myview
        grdISSP.DataBind()
    End Sub
    Private Sub grdISSP_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdISSP.PageIndexChanging
        grdISSP.DataSource = dtISSP
        grdISSP.PageIndex = e.NewPageIndex
        grdISSP.DataBind()
    End Sub
    Private Sub grdISSP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdISSP.SelectedIndexChanged
        Session("IsspHdr_ID") = grdISSP.SelectedDataKey("IsspHdr_ID")
        Session("Page") = "RQ"
        Me.Page.Response.Redirect("~/Inventory/Disposal/rpt_ISSP.aspx")
    End Sub

    '============ ABSTRACT ============
    Private Sub drpSearch_Abstract_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpSearch_Abstract.SelectedIndexChanged
        Try
            If drpSearch_Abstract.SelectedItem.Value = 1 Then
                pnl_Abstract1.Visible = True
                pnl_Abstract2.Visible = False

                txtSearch_Abstract.Text = ""

            ElseIf drpSearch_Abstract.SelectedItem.Value = 2 Then
                pnl_Abstract1.Visible = True
                pnl_Abstract2.Visible = False

                txtSearch_Abstract.Text = ""

            ElseIf drpSearch_Abstract.SelectedItem.Value = 3 Then
                txtSearchDateFrom_Abstract.Text = Date.Today.ToShortDateString
                txtSearchDateTo_Abstract.Text = Date.Today.ToShortDateString

                pnl_Abstract1.Visible = False
                pnl_Abstract2.Visible = True

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSearch_Abstract_Click(sender As Object, e As EventArgs) Handles btnSearch_Abstract.Click
        Dim myview As DataView
        myview = dtAbstract.DefaultView

        If drpSearch_Abstract.SelectedItem.Value = 1 Then
            myview.RowFilter = "Issp_No like '%" & replaceapostrophe(txtSearch_Abstract.Text) & "%'"

        ElseIf drpSearch_Abstract.SelectedItem.Value = 2 Then
            myview.RowFilter = "SuppName like '%" & replaceapostrophe(txtSearch_Abstract.Text) & "%'"

        End If

        grdAbstract.DataSource = myview
        grdAbstract.DataBind()
    End Sub
    Private Sub btnSearchDate_Abstract_Click(sender As Object, e As EventArgs) Handles btnSearchDate_Abstract.Click
        Dim myview As DataView
        myview = dtAbstract.DefaultView
        myview.RowFilter = "Abstract_Date >= '" & txtSearchDateFrom_Abstract.Text & "' AND Abstract_Date <= '" & txtSearchDateTo_Abstract.Text & "'"
        grdAbstract.DataSource = myview
        grdAbstract.DataBind()

    End Sub
    Private Sub grdAbstract_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdAbstract.PageIndexChanging
        grdAbstract.DataSource = dtAbstract
        grdAbstract.PageIndex = e.NewPageIndex
        grdAbstract.DataBind()
    End Sub
    Private Sub grdAbstract_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdAbstract.SelectedIndexChanged


        Session("Disposal_ID") = grdAbstract.SelectedDataKey("Disposal_Bid_hdr_id")
        Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_abstract_of_bids.aspx")


    End Sub


    '============ NOA ============
    Private Sub drpSearch_NOA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpSearch_NOA.SelectedIndexChanged
        Try
            If drpSearch_NOA.SelectedItem.Value = 1 Then
                pnl_NOA1.Visible = True
                pnl_NOA2.Visible = False

                txtSearch_NOA.Text = ""

            ElseIf drpSearch_NOA.SelectedItem.Value = 2 Then
                pnl_NOA1.Visible = True
                pnl_NOA1.Visible = False

                txtSearch_Abstract.Text = ""

            ElseIf drpSearch_NOA.SelectedItem.Value = 3 Then
                txtSearchDateFrom_NOA.Text = Date.Today.ToShortDateString
                txtSearchDateTo_NOA.Text = Date.Today.ToShortDateString

                pnl_NOA1.Visible = False
                pnl_NOA2.Visible = True

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSearch_NOA_Click(sender As Object, e As EventArgs) Handles btnSearch_NOA.Click
        Dim myview As DataView
        myview = dtNOA.DefaultView

        If drpSearch_NOA.SelectedItem.Value = 1 Then
            myview.RowFilter = "Issp_No like '%" & replaceapostrophe(txtSearch_NOA.Text) & "%'"

        ElseIf drpSearch_NOA.SelectedItem.Value = 2 Then
            myview.RowFilter = "SuppName like '%" & replaceapostrophe(txtSearch_NOA.Text) & "%'"

        End If

        grdNOA.DataSource = myview
        grdNOA.DataBind()
    End Sub
    Private Sub btnSearchDate_NOA_Click(sender As Object, e As EventArgs) Handles btnSearchDate_NOA.Click
        Dim myview As DataView
        myview = dtNOA.DefaultView
        myview.RowFilter = "NOA_Date >= '" & txtSearchDateFrom_NOA.Text & "' AND NOA_Date <= '" & txtSearchDateTo_NOA.Text & "'"
        grdNOA.DataSource = myview
        grdNOA.DataBind()
    End Sub
    Private Sub grdNOA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdNOA.PageIndexChanging
        grdNOA.DataSource = dtNOA
        grdNOA.PageIndex = e.NewPageIndex
        grdNOA.DataBind()
    End Sub
    Private Sub grdNOA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdNOA.SelectedIndexChanged
        Session("IsspHdr_ID") = grdNOA.SelectedDataKey("IsspHdr_ID")
        'Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_notice_of_award.aspx")

        Session("Report") = "RQ_NOA"
        Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")

    End Sub




    '============ NTP ============
    Private Sub btnNTP_Search_Click(sender As Object, e As EventArgs) Handles btnNTP_Search.Click
        Dim myview As DataView
        myview = dtNTP.DefaultView
        myview.RowFilter = "Issp_No like '%" & replaceapostrophe(txtNTP_Search.Text) & "%'"
        grdNTP.DataSource = myview
        grdNTP.DataBind()
    End Sub
    Private Sub grdNTP_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdNTP.PageIndexChanging
        grdNTP.DataSource = dtNTP
        grdNTP.PageIndex = e.NewPageIndex
        grdNTP.DataBind()
    End Sub

    Private Sub grdNTP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdNTP.SelectedIndexChanged
        Session("IsspHdr_ID") = grdNTP.SelectedDataKey("IsspHdr_ID")
        Session("Report") = "RQ_NTP"

        Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")

    End Sub



    '============ DONATION ============
    Private Sub drpSearch_Donation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpSearch_Donation.SelectedIndexChanged
        Try
            If drpSearch_Donation.SelectedItem.Value = 1 Then
                pnl_Donation1.Visible = True
                pnl_Donation2.Visible = False

                txtSearch_Donation.Text = ""

            ElseIf drpSearch_Donation.SelectedItem.Value = 2 Then
                pnl_Donation1.Visible = True
                pnl_Donation2.Visible = False

                txtSearch_Donation.Text = ""

            ElseIf drpSearch_Donation.SelectedItem.Value = 3 Then
                txtSearchDateFrom_Donation.Text = Date.Today.ToShortDateString
                txtSearchDateTo_Donation.Text = Date.Today.ToShortDateString

                pnl_Donation1.Visible = False
                pnl_Donation2.Visible = True

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSearch_Donation_Click(sender As Object, e As EventArgs) Handles btnSearch_Donation.Click
        Dim myview As DataView
        myview = dtDonation.DefaultView

        If drpSearch_Donation.SelectedItem.Value = 1 Then
            myview.RowFilter = "IIRUP_No like '%" & replaceapostrophe(txtSearch_Donation.Text) & "%'"

        ElseIf drpSearch_Donation.SelectedItem.Value = 2 Then
            myview.RowFilter = "AuthorizedBy like '%" & replaceapostrophe(txtSearch_Donation.Text) & "%'"

        End If

        grdDonation.DataSource = myview
        grdDonation.DataBind()
    End Sub
    Private Sub btnSearchDate_Donation_Click(sender As Object, e As EventArgs) Handles btnSearchDate_Donation.Click
        Dim myview As DataView
        myview = dtDonation.DefaultView
        myview.RowFilter = "Disposa_date >= '" & txtSearchDateFrom_Donation.Text & "' AND Disposa_date <= '" & txtSearchDateTo_Donation.Text & "'"
        grdDonation.DataSource = myview
        grdDonation.DataBind()
    End Sub
    Private Sub grdDonation_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdDonation.PageIndexChanging
        grdDonation.DataSource = dtDonation
        grdDonation.PageIndex = e.NewPageIndex
        grdDonation.DataBind()
    End Sub
    Private Sub grdDonation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdDonation.SelectedIndexChanged
        Session("Disposal_Donation_hdr_id") = grdDonation.SelectedDataKey("Disposal_Donation_hdr_id")
        Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_donation.aspx")
    End Sub
    Protected Sub grdDFA_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdDFA, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdDFA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

    End Sub
    Protected Sub grdDFA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdDFA.SelectedIndexChanged
        btnPreview_InterestedBidder.Enabled = True
        btnPreview_Abstract.Enabled = True
        btnNotice_COA.Enabled = True
        btnNotice_Conspicuous.Enabled = True

    End Sub
    Protected Sub btnPreview_InterestedBidder_Click(sender As Object, e As EventArgs)
        Session("IsspHdr_ID") = grdDFA.SelectedDataKey("IsspHdr_ID")
        Dim url As String = "rpt_BidderAttendance.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
    Protected Sub btnPreview_Abstract_Click(sender As Object, e As EventArgs)
        Session("Page") = "ISSP_List"
        Session("IsspHdr_ID") = grdDFA.SelectedDataKey("IsspHdr_ID")

        'Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_abstract_of_bids.aspx")


        Dim url As String = "t_rpt_abstract_of_bids.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub
    Protected Sub btnNotice_COA_Click(sender As Object, e As EventArgs)
        Session("Report") = "Notice_COA"
        Session("IsspHdr_ID") = grdDFA.SelectedDataKey("IsspHdr_ID")

        'Me.Page.Response.Redirect("~/Inventory/Disposal/Disposal_ReportEncoding.aspx")

        Dim url As String = "Disposal_ReportEncoding.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
    Protected Sub btnNotice_Conspicuous_Click(sender As Object, e As EventArgs)
        Session("IsspHdr_ID") = grdDFA.SelectedDataKey("IsspHdr_ID")
        Session("Report") = "Notice_Conspicuous"
        Session("Date") = Date.Today.ToShortDateString
        'Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")

        Dim url As String = "Disposal_Notices.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
    Protected Sub grdAOA_SelectedIndexChanged(sender As Object, e As EventArgs)
        btnPreview.Enabled = True
        btnPreview_OP.Enabled = True
    End Sub
    Protected Sub grdAOA_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdAOA, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub btnPreview_Click(sender As Object, e As EventArgs)
        'Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_abstract_of_bids.aspx")
        Session("IsspHdr_ID") = grdAOA.SelectedDataKey("IsspHdr_ID")
        Session("Page") = "Abstract"
        Dim url As String = "t_rpt_abstract_of_bids.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
    Protected Sub btnPreview_OP_Click(sender As Object, e As EventArgs)
        Session("IsspHdr_ID") = grdAOA.SelectedDataKey("IsspHdr_ID")
        Session("Page") = "Auction"
        Session("SuppName") = objDerived.getvalue("SELECT dbo.Supplier.SuppName FROM AMS.tbl_ISSP_InterestedBidder INNER JOIN dbo.Supplier ON AMS.tbl_ISSP_InterestedBidder.Supplier_Id = dbo.Supplier.Supplier_Id where AMS.tbl_ISSP_InterestedBidder.IsspHdr_ID = '" & grdAOA.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)
        Session("Amount") = objDerived.getvalue("SELECT AMS.tbl_ISSP_InterestedBidder.op2_Amt FROM AMS.tbl_ISSP_InterestedBidder INNER JOIN dbo.Supplier ON AMS.tbl_ISSP_InterestedBidder.Supplier_Id = dbo.Supplier.Supplier_Id where AMS.tbl_ISSP_InterestedBidder.IsspHdr_ID = '" & grdAOA.SelectedDataKey("IsspHdr_ID") & "'", CommandType.Text)

        Dim url As String = "rpt_order_of_payment.aspx?"
        Dim fullURL As String = "var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
End Class
