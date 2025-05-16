Imports System.Data

Partial Class bidding_eligibility_Limited
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private hdr As New t_bid_opening_hdr
    Private dtl As New t_bid_opening_dtl


#Region "Datatables"
    Private Property dtProjects() As DataTable
        Get
            Return CType(Session("dtProjects"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtProjects") = value
        End Set
    End Property
    Private Property dtProjectRequirements() As DataTable
        Get
            Return CType(Session("dtProjectRequirements"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtProjectRequirements") = value
        End Set
    End Property
    Private Property dtEqligibility() As DataTable
        Get
            Return CType(Session("dtEqligibility"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtEqligibility") = value
        End Set
    End Property

    Private Property dtBidderList() As DataTable
        Get
            Return CType(Session("dtBidderList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtBidderList") = value
        End Set
    End Property

    Private Property dtFormBidSecurity1() As DataTable
        Get
            Return CType(Session("dtFormBidSecurity1"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtFormBidSecurity1") = value
        End Set
    End Property

    Private Property dtFormBidSecurity2() As DataTable
        Get
            Return CType(Session("dtFormBidSecurity2"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtFormBidSecurity2") = value
        End Set
    End Property
    Private Property dtSummary() As DataTable
        Get
            Return CType(Session("dtSummary"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSummary") = value
        End Set
    End Property

    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn() '
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("project_reference_no", GetType(String))
        dt.Columns.Add("project_name", GetType(String))
        dt.Columns.Add("BidOpening_Place", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("FundDesc", GetType(String))
        dt.Columns.Add("BidCategory", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pre_procurement_hdr_id") = 0
            dr("project_reference_no") = DBNull.Value
            dr("project_name") = DBNull.Value
            dr("BidOpening_Place") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("FundDesc") = DBNull.Value
            dr("BidCategory") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function CreateTable2(ByVal row As Integer) As DataTable
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

    Public Function CreateTable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("reqID", GetType(Long))
        dt.Columns.Add("Criteria", GetType(String))
        dt.Columns.Add("SupplierNo1", GetType(String))
        dt.Columns.Add("SupplierNo2", GetType(String))
        dt.Columns.Add("SupplierNo3", GetType(String))
        dt.Columns.Add("SupplierNo4", GetType(String))
        dt.Columns.Add("SupplierNo5", GetType(String))
        dt.Columns.Add("Supp1_isPass", GetType(Boolean))
        dt.Columns.Add("Supp2_isPass", GetType(Boolean))
        dt.Columns.Add("Supp3_isPass", GetType(Boolean))
        dt.Columns.Add("Supp4_isPass", GetType(Boolean))
        dt.Columns.Add("Supp5_isPass", GetType(Boolean))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("reqID") = 0
            dr("Criteria") = DBNull.Value
            dr("SupplierNo1") = DBNull.Value
            dr("SupplierNo2") = DBNull.Value
            dr("SupplierNo3") = DBNull.Value
            dr("SupplierNo4") = DBNull.Value
            dr("SupplierNo5") = DBNull.Value
            dr("Supp1_isPass") = False
            dr("Supp2_isPass") = False
            dr("Supp3_isPass") = False
            dr("Supp4_isPass") = False
            dr("Supp5_isPass") = False
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function CreateTable4(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("Supplier_ID", GetType(Integer))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("calculatedAmount", GetType(Decimal))
        dt.Columns.Add("isPass", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pre_procurement_hdr_id") = 0
            dr("Supplier_ID") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("calculatedAmount") = DBNull.Value
            dr("isPass") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

#End Region

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub bidding_Eligibility_Load(sender As Object, e As EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@username"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then
            LoadPage()
        End If

    End Sub

    'Protected Sub LoadPage()
    '    dtProjects = objDerived.GetDataTable("SELECT DISTINCT A.pre_procurement_hdr_id, A.project_reference_no, A.project_name, E.BidOpening_Place, A.ABC                                               " &
    '                            " , CASE WHEN A.F_ID = 1 THEN 'General Fund' WHEN A.F_ID = 2 THEN 'Sepecial Educational Fund' ELSE 'Trust Fund' END AS FundDesc                                         " &
    '                            " , CASE WHEN A.isStraight = 0 THEN 'Goods\Services' ELSE 'Consultancy' END AS BidCategory, CONVERT(BIT,1) AS isVisible FROM AMS.pre_procurement AS A                   " &
    '                            " INNER JOIN AMS.pre_procurement_dtl AS B ON A.pre_procurement_hdr_id = B.pre_procurement_hdr_id                                                                        " &
    '                            " INNER JOIN AMS.obr_evaluation_dtl AS C ON B.obr_evaluation_dtl_id = C.obr_evaluation_dtl_id INNER JOIN AMS.ITB_Dtl_Limited AS D ON C.prhdr_id = D.prhdr_id                    " &
    '                            " INNER JOIN AMS.ITB_Hdr_Limited AS E ON D.ITB_Hdr_ID = E.ITB_Hdr_ID WHERE A.isPublicInfra = 0 AND A.withBid = 0 AND A.pre_procurement_hdr_id NOT IN (SELECT DISTINCT X.pre_procurement_hdr_id FROM AMS.bid_opening_hdr AS X WHERE X.isPass = 1) " &
    '                            " ORDER BY A.pre_procurement_hdr_id DESC ", CommandType.Text)
    '    If dtProjects.Rows.Count < 4 Then
    '        dtProjects.Merge(CreateTable1(3 - dtProjects.Rows.Count))
    '    End If
    '    grdProjects.DataSource = dtProjects
    '    grdProjects.DataBind()


    '    '=== DEFAULT TAB ===
    '    btnTab1_Eligibility.CssClass = "TabButton_Active"
    '    btnTab2_Technical.CssClass = "TabButton_InActive"
    '    btnTab3_Summary.CssClass = "TabButton_InActive"

    '    grdEqligibility.DataSource = CreateTable2(2)
    '    grdEqligibility.DataBind()

    '    mvTabs.SetActiveView(Me.vwTab1_Eligibility)
    'End Sub
    Protected Sub LoadPage()
        ' Fetch project data from the database
        dtProjects = objDerived.GetDataTable("SELECT DISTINCT A.pre_procurement_hdr_id, A.project_reference_no, A.project_name, " &
                                         "E.BidOpening_Place, A.ABC, CASE WHEN A.F_ID = 1 THEN 'General Fund' " &
                                         "WHEN A.F_ID = 2 THEN 'Special Educational Fund' ELSE 'Trust Fund' END AS FundDesc, " &
                                         "CASE WHEN A.isStraight = 0 THEN 'Goods\Services' ELSE 'Consultancy' END AS BidCategory, " &
                                         "CONVERT(BIT,1) AS isVisible " &
                                         "FROM AMS.pre_procurement AS A INNER JOIN AMS.pre_procurement_dtl AS B " &
                                         "ON A.pre_procurement_hdr_id = B.pre_procurement_hdr_id " &
                                         "INNER JOIN AMS.obr_evaluation_dtl AS C ON B.obr_evaluation_dtl_id = C.obr_evaluation_dtl_id " &
                                         "INNER JOIN AMS.ITB_Dtl_Limited AS D ON C.prhdr_id = D.prhdr_id " &
                                         "INNER JOIN AMS.ITB_Hdr_Limited AS E ON D.ITB_Hdr_ID = E.ITB_Hdr_ID " &
                                         "WHERE A.isPublicInfra = 0 AND A.withBid = 0 AND A.pre_procurement_hdr_id NOT IN " &
                                         "(SELECT DISTINCT X.pre_procurement_hdr_id FROM AMS.bid_opening_hdr AS X WHERE X.isPass = 1) " &
                                         "ORDER BY A.pre_procurement_hdr_id DESC", CommandType.Text)

        ' Ensure there are always at least four rows in the datatable
        If dtProjects.Rows.Count < 4 Then
            dtProjects.Merge(CreateTable1(4 - dtProjects.Rows.Count))
        End If
        grdProjects.DataSource = dtProjects
        grdProjects.DataBind()

        ' Set default tab settings
        SetDefaultTab()

        ' Bind data for Eligibility grid
        BindEligibilityGrid()
    End Sub

    Private Sub SetDefaultTab()
        btnTab1_Eligibility.CssClass = "TabButton_Active"
        btnTab2_Technical.CssClass = "TabButton_InActive"
        btnTab3_Summary.CssClass = "TabButton_InActive"
        mvTabs.SetActiveView(vwTab1_Eligibility)
    End Sub

    Private Sub BindEligibilityGrid()
        grdEqligibility.DataSource = CreateTable2(2) ' Ensure this method returns a DataTable
        grdEqligibility.DataBind()
    End Sub

    Protected Sub grdProjects_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdProjects.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdProjects, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Private Sub grdProjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdProjects.SelectedIndexChanged
        Try
            Session("pre_procurement_hdr_id") = grdProjects.SelectedDataKey("pre_procurement_hdr_id")
            LoadTabs()

        Catch ex As Exception
            btnSaveEligibility.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    'Private Sub btnTab1_Eligibility_Click(sender As Object, e As EventArgs) Handles btnTab1_Eligibility.Click
    '    btnTab1_Eligibility.CssClass = "TabButton_Active"
    '    btnTab2_Technical.CssClass = "TabButton_InActive"
    '    btnTab3_Summary.CssClass = "TabButton_InActive"

    '    LoadTabs()

    'End Sub
    'Private Sub btnTab2_Technical_Click(sender As Object, e As EventArgs) Handles btnTab2_Technical.Click
    '    btnTab1_Eligibility.CssClass = "TabButton_InActive"
    '    btnTab2_Technical.CssClass = "TabButton_Active"
    '    btnTab3_Summary.CssClass = "TabButton_InActive"

    '    LoadTabs()

    'End Sub
    'Private Sub btnTab3_Summary_Click(sender As Object, e As EventArgs) Handles btnTab3_Summary.Click
    '    btnTab1_Eligibility.CssClass = "TabButton_InActive"
    '    btnTab2_Technical.CssClass = "TabButton_InActive"
    '    btnTab3_Summary.CssClass = "TabButton_Active"

    '    LoadTabs()
    'End Sub
    Private Sub SetActiveTab(activeTab As Integer)
        ' Reset all tabs to inactive
        btnTab1_Eligibility.CssClass = "TabButton_InActive"
        btnTab2_Technical.CssClass = "TabButton_InActive"
        btnTab3_Summary.CssClass = "TabButton_InActive"

        ' Activate the selected tab
        Select Case activeTab
            Case 1
                btnTab1_Eligibility.CssClass = "TabButton_Active"
                mvTabs.SetActiveView(vwTab1_Eligibility)
            Case 2
                btnTab2_Technical.CssClass = "TabButton_Active"
                mvTabs.SetActiveView(vwTab2_Technical)
            Case 3
                btnTab3_Summary.CssClass = "TabButton_Active"
                mvTabs.SetActiveView(vwTab3_Summary)
        End Select

        ' Load the common tabs content
        LoadTabs()
    End Sub

    Private Sub btnTab1_Eligibility_Click(sender As Object, e As EventArgs) Handles btnTab1_Eligibility.Click
        SetActiveTab(1)
    End Sub

    Private Sub btnTab2_Technical_Click(sender As Object, e As EventArgs) Handles btnTab2_Technical.Click
        SetActiveTab(2)
    End Sub

    Private Sub btnTab3_Summary_Click(sender As Object, e As EventArgs) Handles btnTab3_Summary.Click
        SetActiveTab(3)
    End Sub
    Protected Sub LoadTabs()
        Try
            If Session("pre_procurement_hdr_id") = 0 Then
                If btnTab1_Eligibility.CssClass = "TabButton_Active" And btnTab2_Technical.CssClass = "TabButton_InActive" And btnTab3_Summary.CssClass = "TabButton_InActive" Then

                    grdEqligibility.DataSource = CreateTable2(2)
                    grdEqligibility.DataBind()

                    btnSaveEligibility.Enabled = False
                    mvTabs.SetActiveView(Me.vwTab1_Eligibility)

                ElseIf btnTab1_Eligibility.CssClass = "TabButton_InActive" And btnTab2_Technical.CssClass = "TabButton_Active" And btnTab3_Summary.CssClass = "TabButton_InActive" Then

                    dtBidderList = Nothing
                    grdBidderList.DataSource = dtBidderList
                    grdBidderList.DataBind()

                    grdProjectRequirements.DataSource = CreateTable3(9)
                    grdProjectRequirements.DataBind()

                    grdOtherCriteria.DataSource = Nothing
                    grdOtherCriteria.DataBind()

                    btnSaveTechDocs.Enabled = False
                    mvTabs.SetActiveView(Me.vwTab2_Technical)

                ElseIf btnTab1_Eligibility.CssClass = "TabButton_InActive" And btnTab2_Technical.CssClass = "TabButton_InActive" And btnTab3_Summary.CssClass = "TabButton_Active" Then

                    grdSummary.DataSource = CreateTable4(1)
                    grdSummary.DataBind()

                    btnSaveSummary.Enabled = False
                    mvTabs.SetActiveView(Me.vwTab3_Summary)
                End If



            Else
                If btnTab1_Eligibility.CssClass = "TabButton_Active" And btnTab2_Technical.CssClass = "TabButton_InActive" And btnTab3_Summary.CssClass = "TabButton_InActive" Then
                    LoadEligibility()

                    btnSaveEligibility.Enabled = True
                    mvTabs.SetActiveView(Me.vwTab1_Eligibility)

                ElseIf btnTab1_Eligibility.CssClass = "TabButton_InActive" And btnTab2_Technical.CssClass = "TabButton_Active" And btnTab3_Summary.CssClass = "TabButton_InActive" Then
                    LoadTechnicalDocs()

                    btnSaveTechDocs.Enabled = True
                    mvTabs.SetActiveView(Me.vwTab2_Technical)

                ElseIf btnTab1_Eligibility.CssClass = "TabButton_InActive" And btnTab2_Technical.CssClass = "TabButton_InActive" And btnTab3_Summary.CssClass = "TabButton_Active" Then

                    LoadSummary()
                    btnSaveSummary.Enabled = True
                    mvTabs.SetActiveView(Me.vwTab3_Summary)
                End If

            End If

        Catch ex As Exception
            grdEqligibility.Columns(6).Visible = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub grdProjectRequirements_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdProjectRequirements.RowDataBound
        If Session("pre_procurement_hdr_id") <> 0 Then
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(1).Text = dtProjectRequirements.Rows(0)("SupplierNo1")
                e.Row.Cells(2).Text = dtProjectRequirements.Rows(0)("SupplierNo2")
                e.Row.Cells(3).Text = dtProjectRequirements.Rows(0)("SupplierNo3")
                e.Row.Cells(4).Text = dtProjectRequirements.Rows(0)("SupplierNo4")
                e.Row.Cells(5).Text = dtProjectRequirements.Rows(0)("SupplierNo5")

            End If
        End If

    End Sub






    '====================================================
    Protected Sub LoadEligibility()
        grdEqligibility.Columns(6).Visible = True

        dtEqligibility = objDerived.GetDataTable("SELECT DISTINCT A.Transaction_ID AS pre_procurement_hdr_id,A.Supplier_ID, B.SuppName, ISNULL(C.Philgeps,0) AS Philgeps, ISNULL(C.isOngoing,0) AS isOngoing                           " &
                                                " , ISNULL(C.OngoingContracts,'') AS OngoingContracts, ISNULL(C.isSLCC,0) AS isSLCC, ISNULL(C.SLCC,'') AS SLCC, ISNULL(C.isNFCC,0) AS isNFCC                " &
                                                " , ISNULL(C.NFCC,'') AS NFCC, ISNULL(C.isJVA,0) AS isJVA , ISNULL(C.JVA,'') AS JVA FROM DBO.tbl_integrated_collections_table AS A                          " &
                                                " INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id LEFT OUTER JOIN AMS.bid_opening_hdr AS C ON A.Transaction_ID = C.pre_procurement_hdr_id     " &
                                                " AND A.Supplier_ID = C.Supplier_Id WHERE A.Transaction_ID = '" & Session("pre_procurement_hdr_id") & "' ORDER BY B.SuppName", CommandType.Text)

        grdEqligibility.DataSource = dtEqligibility
        grdEqligibility.DataBind()

        grdEqligibility.Columns(6).Visible = False
    End Sub
    Private Sub btnSaveEligibility_Click(sender As Object, e As EventArgs) Handles btnSaveEligibility.Click
        Try
            grdEqligibility.Columns(6).Visible = True

            For i As Integer = 0 To grdEqligibility.Rows.Count - 1
                Dim SuppID As Integer = CType(grdEqligibility.Rows(i).FindControl("lblSupplier_ID"), Label).Text

                Dim bidID As Integer = objDerived.GetValue("SELECT bid_opening_hdr_id FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id = '" & Session("pre_procurement_hdr_id") & "' AND Supplier_Id = '" & SuppID & "'", CommandType.Text)
                If bidID = 0 Then
                    objDerived.Execute("INSERT INTO [AMS].[bid_opening_hdr] ([pre_procurement_hdr_id],[Supplier_Id],[amount],[isWinner],[Philgeps],[isOngoing],[OngoingContracts],[isSLCC],[SLCC],[isNFCC],[NFCC],[isJVA],[JVA])          " &
                              "  VALUES ('" & Session("pre_procurement_hdr_id") & "','" & SuppID & "',0,'False','" & CType(grdEqligibility.Rows(i).FindControl("cbPhilgeps"), CheckBox).Checked & "','" & CType(grdEqligibility.Rows(i).FindControl("cbOngoing"), CheckBox).Checked & "'    " &
                              " ,'" & CType(grdEqligibility.Rows(i).FindControl("txtOngoing"), TextBox).Text & "','" & CType(grdEqligibility.Rows(i).FindControl("cbSLCC"), CheckBox).Checked & "','" & CType(grdEqligibility.Rows(i).FindControl("txtSLCC"), TextBox).Text & "'           " &
                              " ,'" & CType(grdEqligibility.Rows(i).FindControl("cbNFCC"), CheckBox).Checked & "','" & CType(grdEqligibility.Rows(i).FindControl("txtNFCC"), TextBox).Text & "','" & CType(grdEqligibility.Rows(i).FindControl("cbJVA"), CheckBox).Checked & "'         " &
                              " ,'" & CType(grdEqligibility.Rows(i).FindControl("txtJVA"), TextBox).Text & "')", CommandType.Text)

                Else
                    objDerived.Execute("UPDATE AMS.bid_opening_hdr SET Philgeps = '" & CType(grdEqligibility.Rows(i).FindControl("cbPhilgeps"), CheckBox).Checked & "', isOngoing = '" & CType(grdEqligibility.Rows(i).FindControl("cbOngoing"), CheckBox).Checked & "', OngoingContracts = '" & CType(grdEqligibility.Rows(i).FindControl("txtOngoing"), TextBox).Text & "'   " &
                                    "  , isSLCC = '" & CType(grdEqligibility.Rows(i).FindControl("cbSLCC"), CheckBox).Checked & "', SLCC = '" & CType(grdEqligibility.Rows(i).FindControl("txtSLCC"), TextBox).Text & "', isNFCC = '" & CType(grdEqligibility.Rows(i).FindControl("cbNFCC"), CheckBox).Checked & "', NFCC = '" & CType(grdEqligibility.Rows(i).FindControl("txtNFCC"), TextBox).Text & "'  " &
                                    "  , isJVA = '" & CType(grdEqligibility.Rows(i).FindControl("cbJVA"), CheckBox).Checked & "', JVA = '" & CType(grdEqligibility.Rows(i).FindControl("txtJVA"), TextBox).Text & "'     " &
                                    "  WHERE pre_procurement_hdr_id = '" & Session("pre_procurement_hdr_id") & "' AND Supplier_Id = '" & SuppID & "'", CommandType.Text)

                End If
            Next


            grdEqligibility.Columns(6).Visible = False

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Eligibility documents has been successfully saved.")
            LoadEligibility()

        Catch ex As Exception
            grdEqligibility.Columns(6).Visible = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
        btnSaveEligibility.Enabled = False
    End Sub




    '====================================================
    Protected Sub LoadTechnicalDocs()
        Try
            dtFormBidSecurity1 = objDerived.GetDataTable("SELECT * FROM AMS.BidSecurity ORDER BY BidSecurity_id", CommandType.Text)
            dtFormBidSecurity2 = objDerived.GetDataTable("SELECT * FROM AMS.BidSecurity ORDER BY BidSecurity_id", CommandType.Text)

            dtBidderList = objDerived.GetDataTable("EXEC AMs.sp_post_qualification_dtl '" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)
            grdBidderList.DataSource = dtBidderList
            grdBidderList.DataBind()

            grdBidderList.Enabled = True

            If dtBidderList.Rows.Count >= 1 Then
                For i As Integer = 0 To Me.grdBidderList.Rows.Count - 1
                    Dim dd1 As DropDownList = CType(grdBidderList.Rows(i).Cells(0).FindControl("drpForm1"), DropDownList)
                    dd1.DataSource = dtFormBidSecurity1
                    dd1.DataTextField = "Description"
                    dd1.DataValueField = "BidSecurity_id"
                    dd1.DataBind()

                    Dim dd2 As DropDownList = CType(grdBidderList.Rows(i).Cells(1).FindControl("drpForm2"), DropDownList)
                    dd2.DataSource = dtFormBidSecurity2
                    dd2.DataTextField = "Description"
                    dd2.DataValueField = "BidSecurity_id"
                    dd2.DataBind()


                    Dim dtBiddersInfo As New DataTable
                    dtBiddersInfo = objDerived.GetDataTable("SELECT * FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id = '" & Session("pre_procurement_hdr_id") & "' AND Supplier_Id = '" & dtBidderList.Rows(i)("Supplier_ID") & "'", CommandType.Text)
                    If dtBiddersInfo.Rows.Count = 0 Then
                        dd1.SelectedIndex = 0
                        dd2.Items.Insert(0, "Select")

                        Dim RequiredAmount1 As Decimal
                        RequiredAmount1 = CType(grdProjects.SelectedDataKey("ABC"), Decimal) * CType(dtFormBidSecurity1.Rows(dd1.SelectedIndex)("percentage"), Decimal)
                        hndBid_security.Value = CType(grdProjects.SelectedDataKey("ABC"), Decimal) * CType(dtFormBidSecurity1.Rows(dd1.SelectedIndex)("percentage"), Decimal)

                        CType(grdBidderList.Rows(i).FindControl("txtBidSecAmt_1"), TextBox).Text = FormatNumber(RequiredAmount1, 2)
                        CType(grdBidderList.Rows(i).FindControl("txtReqBidSec_1"), TextBox).Text = FormatNumber(RequiredAmount1, 2)

                        CType(grdBidderList.Rows(i).FindControl("txtBidSecAmt_2"), TextBox).Text = 0
                        CType(grdBidderList.Rows(i).FindControl("txtReqBidSec_2"), TextBox).Text = 0

                        CType(grdBidderList.Rows(i).FindControl("txtBankName_1"), TextBox).Text = ""
                        CType(grdBidderList.Rows(i).FindControl("txtNumber_1"), TextBox).Text = ""
                        CType(grdBidderList.Rows(i).FindControl("txtValidityPeriod1"), TextBox).Text = ""

                        CType(grdBidderList.Rows(i).FindControl("txtBankName_2"), TextBox).Text = ""
                        CType(grdBidderList.Rows(i).FindControl("txtNumber_2"), TextBox).Text = ""
                        CType(grdBidderList.Rows(i).FindControl("txtValidityPeriod2"), TextBox).Text = ""

                    Else
                        Dim id2 As Integer = IIf(IsDBNull(dtBiddersInfo.Rows(0)("BidSecurity_id2")), 0, dtBiddersInfo.Rows(0)("BidSecurity_id2"))
                        dd1.SelectedValue = IIf(IsDBNull(dtBiddersInfo.Rows(0)("BidSecurity_id")), 0, dtBiddersInfo.Rows(0)("BidSecurity_id"))
                        If id2 = 0 Then
                            dd2.Items.Insert(0, "Select")
                        Else
                            dd2.SelectedValue = id2
                        End If

                        Dim RequiredAmount1 As Decimal
                        RequiredAmount1 = CType(grdProjects.SelectedDataKey("ABC"), Decimal) * CType(dtFormBidSecurity1.Rows(dd1.SelectedIndex)("percentage"), Decimal)

                        Dim A As String = IIf(IsDBNull(dtBiddersInfo.Rows(0)("BidSecurityAmount")), RequiredAmount1, dtBiddersInfo.Rows(0)("BidSecurityAmount"))

                        CType(grdBidderList.Rows(i).FindControl("txtBidSecAmt_1"), TextBox).Text = FormatNumber(IIf(IsDBNull(dtBiddersInfo.Rows(0)("BidSecurityAmount")), RequiredAmount1, dtBiddersInfo.Rows(0)("BidSecurityAmount")), 2)
                        CType(grdBidderList.Rows(i).FindControl("txtReqBidSec_1"), TextBox).Text = FormatNumber(IIf(IsDBNull(dtBiddersInfo.Rows(0)("amount")), RequiredAmount1, dtBiddersInfo.Rows(0)("amount")), 2)

                        CType(grdBidderList.Rows(i).FindControl("txtBidSecAmt_2"), TextBox).Text = FormatNumber(IIf(IsDBNull(dtBiddersInfo.Rows(0)("BidSecurityAmount2")), 0, dtBiddersInfo.Rows(0)("BidSecurityAmount2")), 2)
                        CType(grdBidderList.Rows(i).FindControl("txtReqBidSec_2"), TextBox).Text = FormatNumber(IIf(IsDBNull(dtBiddersInfo.Rows(0)("BidSecurityAmount2")), 0, dtBiddersInfo.Rows(0)("BidSecurityAmount2")), 2)

                        CType(grdBidderList.Rows(i).FindControl("txtBankName_1"), TextBox).Text = IIf(IsDBNull(dtBiddersInfo.Rows(0)("BankName")), "", dtBiddersInfo.Rows(0)("BankName"))
                        CType(grdBidderList.Rows(i).FindControl("txtNumber_1"), TextBox).Text = IIf(IsDBNull(dtBiddersInfo.Rows(0)("Number")), "", dtBiddersInfo.Rows(0)("Number"))
                        CType(grdBidderList.Rows(i).FindControl("txtValidityPeriod1"), TextBox).Text = IIf(IsDBNull(dtBiddersInfo.Rows(0)("ValidityPeriod")), "", dtBiddersInfo.Rows(0)("ValidityPeriod"))

                        CType(grdBidderList.Rows(i).FindControl("txtBankName_2"), TextBox).Text = IIf(IsDBNull(dtBiddersInfo.Rows(0)("BankName2")), "", dtBiddersInfo.Rows(0)("BankName2"))
                        CType(grdBidderList.Rows(i).FindControl("txtNumber_2"), TextBox).Text = IIf(IsDBNull(dtBiddersInfo.Rows(0)("Number2")), "", dtBiddersInfo.Rows(0)("Number2"))
                        CType(grdBidderList.Rows(i).FindControl("txtValidityPeriod2"), TextBox).Text = IIf(IsDBNull(dtBiddersInfo.Rows(0)("ValidityPeriod2")), "", dtBiddersInfo.Rows(0)("ValidityPeriod2"))

                    End If

                Next

            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
        End Try

        dtProjectRequirements = objDerived.GetDataTable("[AMS].[sp_ProjectRequirement] '" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)
        grdProjectRequirements.DataSource = dtProjectRequirements
        grdProjectRequirements.DataBind()

        grdOtherCriteria.DataSource = objDerived.GetDataTable("SELECT DISTINCT A.Transaction_ID AS pre_procurement_hdr_id,A.Supplier_ID, B.SuppName, ISNULL(C.omnibus,'False') AS omnibus, ISNULL(C.authorized_rep,'False') AS authorized_rep                            " &
                                                        " FROM DBO.tbl_integrated_collections_table AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id LEFT OUTER JOIN AMS.bid_opening_hdr AS C ON A.Transaction_ID = C.pre_procurement_hdr_id  " &
                                                        " AND A.Supplier_ID = C.Supplier_Id WHERE A.Transaction_ID = '" & Session("pre_procurement_hdr_id") & "' ORDER BY B.SuppName", CommandType.Text)
        grdOtherCriteria.DataBind()
    End Sub
    Protected Sub drpForm1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim dd1 As DropDownList = TryCast(sender, DropDownList)
            Dim gvr As GridViewRow = TryCast(dd1.NamingContainer, GridViewRow)

            Dim TenPercent As Decimal = FormatNumber(CType(grdProjects.SelectedDataKey("ABC"), Decimal) * 0.1, 2)

            Dim RequiredAmount1 As Decimal
            RequiredAmount1 = CType(grdProjects.SelectedDataKey("ABC"), Decimal) * CType(dtFormBidSecurity2.Rows(dd1.SelectedIndex)("percentage"), Decimal)

            CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtBidSecAmt_1"), TextBox).Text = FormatNumber(RequiredAmount1, 2)
            CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtReqBidSec_1"), TextBox).Text = FormatNumber(RequiredAmount1, 2)

            If CType(grdBidderList.Rows(gvr.RowIndex).FindControl("drpForm1"), DropDownList).SelectedItem.Value = 6 Then
                CType(grdBidderList.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Sufficient"

            ElseIf CType(grdBidderList.Rows(gvr.RowIndex).FindControl("drpForm2"), DropDownList).SelectedItem.Text = "Select" Then
                If CType(CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtReqBidSec_1"), TextBox).Text, Decimal) < TenPercent Then
                    CType(grdBidderList.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Insufficient"
                Else
                    CType(grdBidderList.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Sufficient"
                End If

            Else
                If (CType(CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtReqBidSec_1"), TextBox).Text, Decimal) + CType(CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtReqBidSec_2"), TextBox).Text, Decimal)) < TenPercent Then
                    CType(grdBidderList.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Insufficient"
                Else
                    CType(grdBidderList.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Sufficient"
                End If

            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
        End Try
    End Sub
    Protected Sub drpForm2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim dd2 As DropDownList = TryCast(sender, DropDownList)
            Dim gvr As GridViewRow = TryCast(dd2.NamingContainer, GridViewRow)

            Dim TenPercent As Decimal = FormatNumber(CType(grdProjects.SelectedDataKey("ABC"), Decimal) * 0.1, 2)


            If dd2.SelectedItem.Text = "Select" Then
                CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtBidSecAmt_2"), TextBox).Text = "0.00"
                CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtReqBidSec_2"), TextBox).Text = "0.00"

            Else
                Dim RequiredAmount2 As Decimal
                RequiredAmount2 = CType(grdProjects.SelectedDataKey("ABC"), Decimal) * CType(dtFormBidSecurity2.Rows(dd2.SelectedIndex - 1)("percentage"), Decimal)

                CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtBidSecAmt_2"), TextBox).Text = FormatNumber(RequiredAmount2, 2)
                CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtReqBidSec_2"), TextBox).Text = FormatNumber(RequiredAmount2, 2)

            End If


            If CType(grdBidderList.Rows(gvr.RowIndex).FindControl("drpForm2"), DropDownList).SelectedItem.Value = 6 Then
                CType(grdBidderList.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Sufficient"

            ElseIf CType(grdBidderList.Rows(gvr.RowIndex).FindControl("drpForm2"), DropDownList).SelectedItem.Text = "Select" Then
                If CType(CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtReqBidSec_1"), TextBox).Text, Decimal) < TenPercent Then
                    CType(grdBidderList.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Insufficient"
                Else
                    CType(grdBidderList.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Sufficient"
                End If

            Else
                If (CType(CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtReqBidSec_1"), TextBox).Text, Decimal) + CType(CType(grdBidderList.Rows(gvr.RowIndex).FindControl("txtReqBidSec_2"), TextBox).Text, Decimal)) < TenPercent Then
                    CType(grdBidderList.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Insufficient"
                Else
                    CType(grdBidderList.Rows(gvr.RowIndex).FindControl("lblStatus"), Label).Text = "Sufficient"
                End If

            End If



        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
        End Try
    End Sub
    Private Sub btnAddCriteria_Click(sender As Object, e As EventArgs) Handles btnAddCriteria.Click
        Try

            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_hdr] ([pre_procurement_hdr_id],[criteria]) " &
                                " VALUES ('" & Session("pre_procurement_hdr_id") & "','" & replaceapostrophe(txtCriteria.Text) & "') ", CommandType.Text)

            dtProjectRequirements = objDerived.GetDataTable("[AMS].[sp_ProjectRequirement] '" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)
            grdProjectRequirements.DataSource = dtProjectRequirements
            grdProjectRequirements.DataBind()

            txtCriteria.Text = ""

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try


    End Sub
    Private Sub btnSaveTechDocs_Click(sender As Object, e As EventArgs) Handles btnSaveTechDocs.Click
        Try

            For i As Integer = 0 To Me.grdBidderList.Rows.Count - 1
                Dim ID As Integer

                With hdr
                    .pre_procurement_hdr_id = Session("pre_procurement_hdr_id")
                    .Supplier_Id = dtBidderList.Rows(i)("Supplier_ID")
                    .amount = CType(grdBidderList.Rows(i).FindControl("txtReqBidSec_1"), TextBox).Text.replace(",", "")
                    .calculatedAmount = 0

                    .examination_bid = False
                    .ceiling_price = False
                    .isPostQualification = False
                    .isWinner = False
                    .isCalculated = False

                    .BidSecurity_id = CType(grdBidderList.Rows(i).FindControl("drpForm1"), DropDownList).SelectedItem.Value
                    .BidSecurityAmount = FormatCurrency(CType(grdBidderList.Rows(i).FindControl("txtBidSecAmt_1"), TextBox).Text, 2)

                    .BankName = CType(grdBidderList.Rows(i).FindControl("txtBankName_1"), TextBox).Text
                    .Number = CType(grdBidderList.Rows(i).FindControl("txtNumber_1"), TextBox).Text
                    .ValidityPeriod = IIf(CType(grdBidderList.Rows(i).FindControl("txtValidityPeriod1"), TextBox).Text = "", 0, CType(grdBidderList.Rows(i).FindControl("txtValidityPeriod1"), TextBox).Text)

                    .remarks = CType(grdBidderList.Rows(i).FindControl("txtRemarks"), TextBox).Text
                    .status = CType(grdBidderList.Rows(i).FindControl("lblStatus"), Label).Text
                    .withOR = False

                    Dim bidID As Integer = objDerived.GetValue("SELECT bid_opening_hdr_id FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id = '" & Session("pre_procurement_hdr_id") & "' AND Supplier_Id = '" & dtBidderList.Rows(i)("Supplier_ID") & "'", CommandType.Text)
                    If bidID = 0 Then
                        ID = hdr.save()
                    Else
                        ID = bidID
                        .bid_opening_hdr_id = bidID
                        .update()
                    End If

                    objDerived.Execute("UPDATE AMS.bid_opening_hdr SET omnibus = '" & CType(grdOtherCriteria.Rows(i).FindControl("cbOmnibus"), CheckBox).Checked & "', authorized_rep = '" & CType(grdOtherCriteria.Rows(i).FindControl("cbauthorized"), CheckBox).Checked & "' WHERE bid_opening_hdr_id = '" & ID & "'", CommandType.Text)

                    If CType(grdBidderList.Rows(i).FindControl("drpForm2"), DropDownList).SelectedItem.Text <> "Select" Then
                        objDerived.Execute("UPDATE AMS.bid_opening_hdr SET BidSecurity_id2 = '" & CType(grdBidderList.Rows(i).FindControl("drpForm2"), DropDownList).SelectedItem.Value & "', BidSecurityAmount2 = '" & CType(CType(grdBidderList.Rows(i).FindControl("txtReqBidSec_2"), TextBox).Text, Decimal) & "' " &
                                                 " , BankName2 = '" & CType(grdBidderList.Rows(i).FindControl("txtBankName_2"), TextBox).Text & "', Number2 = '" & CType(grdBidderList.Rows(i).FindControl("txtNumber_2"), TextBox).Text & "', ValidityPeriod2 = '" & CType(grdBidderList.Rows(i).FindControl("txtValidityPeriod2"), TextBox).Text & "' WHERE bid_opening_hdr_id = '" & ID & "'", CommandType.Text)

                    End If

                End With

            Next

            'dtProjectRequirements = objDerived.GetDataTable("[AMS].[sp_ProjectRequirement] '" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)
            'grdProjectRequirements.DataSource = dtProjectRequirements
            'grdProjectRequirements.DataBind()

            'Dim dtHdr As New DataTable
            'dtHdr = objDerived.GetDataTable("SELECT * FROM AMS.bidopening_req_hdr WHERE pre_procurement_hdr_id = '" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)
            If dtProjectRequirements.Rows.Count <> 0 Then
                For x As Integer = 0 To dtProjectRequirements.Rows.Count - 1
                    Dim dtlID As Integer = objDerived.GetValue("SELECT reqdtl_id FROM AMS.bidopening_req_dtl WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "'", CommandType.Text)
                    If dtlID = 0 Then

                        If dtProjectRequirements.Rows(x)("SupplierNo2_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo3_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo4_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo5_ID") <> 0 Then
                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo1_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbA"), CheckBox).Checked & "')", CommandType.Text)

                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo2_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbB"), CheckBox).Checked & "')", CommandType.Text)

                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo3_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbC"), CheckBox).Checked & "')", CommandType.Text)

                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo4_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbD"), CheckBox).Checked & "')", CommandType.Text)

                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo5_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbE"), CheckBox).Checked & "')", CommandType.Text)


                        ElseIf dtProjectRequirements.Rows(x)("SupplierNo2_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo3_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo4_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo5_ID") = 0 Then
                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo1_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbA"), CheckBox).Checked & "')", CommandType.Text)

                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo2_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbB"), CheckBox).Checked & "')", CommandType.Text)

                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo3_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbC"), CheckBox).Checked & "')", CommandType.Text)

                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo4_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbD"), CheckBox).Checked & "')", CommandType.Text)

                        ElseIf dtProjectRequirements.Rows(x)("SupplierNo2_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo3_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo4_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo5_ID") = 0 Then
                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo1_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbA"), CheckBox).Checked & "')", CommandType.Text)

                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo2_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbB"), CheckBox).Checked & "')", CommandType.Text)

                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo3_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbC"), CheckBox).Checked & "')", CommandType.Text)

                        ElseIf dtProjectRequirements.Rows(x)("SupplierNo2_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo3_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo4_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo5_ID") = 0 Then
                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo1_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbA"), CheckBox).Checked & "')", CommandType.Text)

                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo2_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbB"), CheckBox).Checked & "')", CommandType.Text)


                        ElseIf dtProjectRequirements.Rows(x)("SupplierNo2_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo3_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo4_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo5_ID") = 0 Then
                            objDerived.Execute("INSERT INTO [AMS].[bidopening_req_dtl] ([reqID],[Supplier_ID],[isPass])     " &
                                           " VALUES ('" & dtProjectRequirements.Rows(x)("reqID") & "','" & dtProjectRequirements.Rows(x)("SupplierNo1_ID") & "','" & CType(grdProjectRequirements.Rows(x).FindControl("cbA"), CheckBox).Checked & "')", CommandType.Text)

                        End If

                    Else

                        If dtProjectRequirements.Rows(x)("SupplierNo2_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo3_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo4_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo5_ID") <> 0 Then
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbA"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo1_ID") & "'", CommandType.Text)
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbB"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo2_ID") & "'", CommandType.Text)
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbC"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo3_ID") & "'", CommandType.Text)
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbD"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo4_ID") & "'", CommandType.Text)
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbE"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo5_ID") & "'", CommandType.Text)

                        ElseIf dtProjectRequirements.Rows(x)("SupplierNo2_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo3_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo4_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo5_ID") = 0 Then
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbA"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo1_ID") & "'", CommandType.Text)
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbB"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo2_ID") & "'", CommandType.Text)
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbC"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo3_ID") & "'", CommandType.Text)
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbD"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo4_ID") & "'", CommandType.Text)

                        ElseIf dtProjectRequirements.Rows(x)("SupplierNo2_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo3_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo4_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo5_ID") = 0 Then
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbA"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo1_ID") & "'", CommandType.Text)
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbB"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo2_ID") & "'", CommandType.Text)
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbC"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo3_ID") & "'", CommandType.Text)

                        ElseIf dtProjectRequirements.Rows(x)("SupplierNo2_ID") <> 0 And dtProjectRequirements.Rows(x)("SupplierNo3_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo4_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo5_ID") = 0 Then
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbA"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo1_ID") & "'", CommandType.Text)
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbB"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo2_ID") & "'", CommandType.Text)

                        ElseIf dtProjectRequirements.Rows(x)("SupplierNo2_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo3_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo4_ID") = 0 And dtProjectRequirements.Rows(x)("SupplierNo5_ID") = 0 Then
                            objDerived.Execute("UPDATE AMS.bidopening_req_dtl SET isPass = '" & CType(grdProjectRequirements.Rows(x).FindControl("cbA"), CheckBox).Checked & "' WHERE reqID = '" & dtProjectRequirements.Rows(x)("reqID") & "' AND Supplier_ID = '" & dtProjectRequirements.Rows(x)("SupplierNo1_ID") & "'", CommandType.Text)

                        End If

                    End If
                Next
            End If


            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Technical documents has been successfully saved.")
            LoadTechnicalDocs()
            btnSaveTechDocs.Enabled = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub




    '====================================================
    Protected Sub LoadSummary()
        grdSummary.Columns(3).Visible = True

        dtSummary = objDerived.GetDataTable("SELECT DISTINCT A.Transaction_ID AS pre_procurement_hdr_id,A.Supplier_ID, B.SuppName, ISNULL(C.calculatedAmount,0) AS calculatedAmount         " &
                                               " , ISNULL(C.isPass,0) AS isPass FROM DBO.tbl_integrated_collections_table AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id       " &
                                               " LEFT OUTER JOIN AMS.bid_opening_hdr AS C ON A.Transaction_ID = C.pre_procurement_hdr_id AND A.Supplier_ID = C.Supplier_Id                         " &
                                               " WHERE A.Transaction_ID = '" & Session("pre_procurement_hdr_id") & "' ORDER BY B.SuppName", CommandType.Text)
        grdSummary.DataSource = dtSummary
        grdSummary.DataBind()

        For i As Integer = 0 To dtSummary.Rows.Count - 1
            CType(grdSummary.Rows(i).FindControl("txtTotalAmt"), TextBox).Text = FormatNumber(CType(grdBidderList.Rows(i).FindControl("txtReqBidSec_1"), TextBox).Text, 2)
        Next


        grdSummary.Columns(3).Visible = False
    End Sub
    Protected Sub txtTotalAmt_OnTextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtAmount As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtAmount.NamingContainer, GridViewRow)
        Dim rw = gvr.DataItemIndex

        CType(Me.grdSummary.Rows(rw).FindControl("txtTotalAmt"), TextBox).Text = FormatNumber(txtAmount.Text, 2)

    End Sub
    Private Sub btnSaveSummary_Click(sender As Object, e As EventArgs) Handles btnSaveSummary.Click
        Try
            grdSummary.Columns(3).Visible = True

            Dim Status As Boolean = False

            For i As Integer = 0 To dtSummary.Rows.Count - 1
                Dim bidID As Integer = objDerived.GetValue("SELECT bid_opening_hdr_id FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id = '" & Session("pre_procurement_hdr_id") & "' AND Supplier_Id = '" & dtSummary.Rows(i)("Supplier_ID") & "'", CommandType.Text)
                If bidID = 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "complete the eligibility and technical documents first before saving the summary.")
                    Exit Sub

                Else

                    Dim pass As Boolean = CType(grdSummary.Rows(i).FindControl("cbRemarks"), CheckBox).Checked
                    objDerived.Execute("UPDATE AMS.bid_opening_hdr SET calculatedAmount = '" & CType(CType(grdSummary.Rows(i).FindControl("txtTotalAmt"), TextBox).Text, Decimal) & "', examination_bid = '" & pass & "', ceiling_price = '" & pass & "', isPostQualification = '" & pass & "', isPass = '" & pass & "',amount='" & CType(Me.grdSummary.Rows(i).FindControl("txtTotalAmt"), TextBox).Text.replace(",", "") & "' WHERE bid_opening_hdr_id = '" & bidID & "' AND Supplier_Id = '" & CType(grdSummary.Rows(i).FindControl("lblSupplier_ID"), Label).Text & "'", CommandType.Text)

                    If pass = True Then
                        Status = True
                    End If
                End If
            Next

            If Status = True Then
                objDerived.Execute("UPDATE AMS.pre_procurement SET withBid = 1 WHERE pre_procurement_hdr_id = '" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)

            End If

            grdSummary.Columns(3).Visible = False

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Summary has been successfully saved.")
            LoadPage()
            'LoadSummary()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
        btnSaveSummary.Enabled = False
    End Sub
End Class
