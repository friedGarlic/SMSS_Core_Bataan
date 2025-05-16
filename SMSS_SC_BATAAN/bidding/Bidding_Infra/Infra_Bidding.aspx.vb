Imports System.Data
Partial Class bidding_Bidding_Infra_Infra_Bidding
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal


#Region "Variable"
    Private Property dtBidOpen() As DataTable
        Get
            Return CType(Session("dtBidOpen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtBidOpen") = value
        End Set
    End Property
    Private Property dtBidders() As DataTable
        Get
            Return CType(Session("dtBidders"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtBidders") = value
        End Set
    End Property
    Private Property dtEligibility() As DataTable
        Get
            Return CType(Session("dtEligibility"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtEligibility") = value
        End Set
    End Property
    Private Property strOpening() As String
        Get
            Return CType(Session("strOpening"), String)
        End Get
        Set(ByVal value As String)
            Session("strOpening") = value
        End Set
    End Property
    Private Property strBidders() As String
        Get
            Return CType(Session("strBidders"), String)
        End Get
        Set(ByVal value As String)
            Session("strBidders") = value
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
    Private Property dtAbstract_Bidders() As DataTable
        Get
            Return CType(Session("dtAbstract_Bidders"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAbstract_Bidders") = value
        End Set
    End Property
    Private Property strAbstract() As String
        Get
            Return CType(Session("strAbstract"), String)
        End Get
        Set(ByVal value As String)
            Session("strAbstract") = value
        End Set
    End Property

    Private Property dtEvaluation() As DataTable
        Get
            Return CType(Session("dtEvaluation"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtEvaluation") = value
        End Set
    End Property

    Private Property strEvaluation() As String
        Get
            Return CType(Session("strEvaluation"), String)
        End Get
        Set(ByVal value As String)
            Session("strEvaluation") = value
        End Set
    End Property


    Private Property dtPostQua() As DataTable
        Get
            Return CType(Session("dtPostQua"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPostQua") = value
        End Set
    End Property

    Public Function dtTemp_Table(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Infra_BidPrep_ID", GetType(Integer))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Integer))
        dt.Columns.Add("BidOpen_Date", GetType(Date))
        dt.Columns.Add("ITB_No", GetType(String))
        dt.Columns.Add("PPA", GetType(String))
        dt.Columns.Add("Amount", GetType(Decimal))
        dt.Columns.Add("BidDoc_Amt", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Infra_BidPrep_ID") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("BidOpen_Date") = DBNull.Value
            dr("ITB_No") = DBNull.Value
            dr("PPA") = DBNull.Value
            dr("Amount") = DBNull.Value
            dr("BidDoc_Amt") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function dtTemp_Bidder(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Infra_Bidders_ID", GetType(Integer))
        dt.Columns.Add("Suppier_ID", GetType(Integer))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("Address1", GetType(String))
        dt.Columns.Add("ContactP", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Infra_Bidders_ID") = DBNull.Value
            dr("Suppier_ID") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("Address1") = DBNull.Value
            dr("ContactP") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function dtTemp_AbstractBidder(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Supplier_ID", GetType(Integer))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("BidAmount", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Supplier_ID") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("BidAmount") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function dtTemp_Eval(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("BidAmount", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = DBNull.Value
            dr("BidAmount") = DBNull.Value
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
        dt.Columns.Add("PhilGEPS_Cert", GetType(Boolean))
        dt.Columns.Add("OnGoing", GetType(Boolean))
        dt.Columns.Add("SLCC", GetType(Boolean))
        dt.Columns.Add("NFCC", GetType(Boolean))
        dt.Columns.Add("JVA", GetType(Boolean))
        dt.Columns.Add("OnGoing_Remarks", GetType(String))
        dt.Columns.Add("SLCC_Remakrs", GetType(String))
        dt.Columns.Add("NFCC_Remarks", GetType(String))
        dt.Columns.Add("JVA_Remarks", GetType(String))
        dt.Columns.Add("Supplier_ID", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = DBNull.Value
            dr("PhilGEPS_Cert") = False
            dr("OnGoing") = False
            dr("SLCC") = False
            dr("NFCC") = False
            dr("JVA") = False
            dr("OnGoing_Remarks") = DBNull.Value
            dr("SLCC_Remakrs") = DBNull.Value
            dr("NFCC_Remarks") = DBNull.Value
            dr("JVA_Remarks") = DBNull.Value
            dr("Supplier_ID") = 0
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
#End Region


    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub bidding_Bidding_Infra_Infra_Bidding_Load(sender As Object, e As EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@username"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then
            btnTab1_Opening.CssClass = "TabButton_InActive"
            btnTab2_Abstract.CssClass = "TabButton_InActive"
            btnTab3_Evaluation.CssClass = "TabButton_InActive"
            btnTab4_PostQua.CssClass = "TabButton_Active"
            LoadTabs()

        End If


        txtSearch_Opening.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_Opening.ClientID & "')")
        txtEval_Search.Attributes.Add("onkeypress", "return fun1(event,'" & btnEval_Search.ClientID & "')")

    End Sub

    Private Sub btnTab1_Opening_Click(sender As Object, e As EventArgs) Handles btnTab1_Opening.Click
        btnTab1_Opening.CssClass = "TabButton_Active"
        btnTab2_Abstract.CssClass = "TabButton_InActive"
        btnTab3_Evaluation.CssClass = "TabButton_InActive"
        btnTab4_PostQua.CssClass = "TabButton_InActive"

        LoadTabs()
    End Sub

    Private Sub btnTab2_Abstract_Click(sender As Object, e As EventArgs) Handles btnTab2_Abstract.Click
        btnTab1_Opening.CssClass = "TabButton_InActive"
        btnTab2_Abstract.CssClass = "TabButton_Active"
        btnTab3_Evaluation.CssClass = "TabButton_InActive"
        btnTab4_PostQua.CssClass = "TabButton_InActive"

        LoadTabs()
    End Sub
    Private Sub btnTab3_Evaluation_Click(sender As Object, e As EventArgs) Handles btnTab3_Evaluation.Click
        btnTab1_Opening.CssClass = "TabButton_InActive"
        btnTab2_Abstract.CssClass = "TabButton_InActive"
        btnTab3_Evaluation.CssClass = "TabButton_Active"
        btnTab4_PostQua.CssClass = "TabButton_InActive"

        LoadTabs()
    End Sub
    Private Sub btnTab4_PostQua_Click(sender As Object, e As EventArgs) Handles btnTab4_PostQua.Click
        btnTab1_Opening.CssClass = "TabButton_InActive"
        btnTab2_Abstract.CssClass = "TabButton_InActive"
        btnTab3_Evaluation.CssClass = "TabButton_InActive"
        btnTab4_PostQua.CssClass = "TabButton_Active"

        LoadTabs()
    End Sub
    Private Sub LoadTabs()
        Try
            If btnTab1_Opening.CssClass = "TabButton_Active" And btnTab2_Abstract.CssClass = "TabButton_InActive" And btnTab3_Evaluation.CssClass = "TabButton_InActive" And btnTab4_PostQua.CssClass = "TabButton_InActive" Then
                dtBidOpen = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Bidding] 'BidOpening'", CommandType.Text)
                If dtBidOpen.Rows.Count < 5 Then
                    dtBidOpen.Merge(dtTemp_Table(4 - dtBidOpen.Rows.Count))
                End If
                grdOpening.DataSource = dtBidOpen
                grdOpening.DataBind()

                drpSupplier.Items.Clear()
                drpSupplier.Items.Insert(0, "Select")

                drpBidSecurity1.DataSource = objDerived.GetDataTable("SELECT BidSecurity_id, Description, percentage FROM AMS.BidSecurity ORDER BY BidSecurity_id", CommandType.Text)
                drpBidSecurity1.DataTextField = "Description"
                drpBidSecurity1.DataValueField = "percentage"
                drpBidSecurity1.DataBind()
                drpBidSecurity1.Items.Insert(0, "Select")

                drpBidSecurity2.DataSource = objDerived.GetDataTable("SELECT BidSecurity_id, Description, percentage FROM AMS.BidSecurity ORDER BY BidSecurity_id", CommandType.Text)
                drpBidSecurity2.DataTextField = "Description"
                drpBidSecurity2.DataValueField = "percentage"
                drpBidSecurity2.DataBind()
                drpBidSecurity2.Items.Insert(0, "Select")

                grdBidders.DataSource = dtTemp_Bidder(4)
                grdBidders.DataBind()

                grdEqligibility.DataSource = dtTemp_Eligibility(3)
                grdEqligibility.DataBind()


                mvTabs.SetActiveView(Me.vwTab1_Opening)

            ElseIf btnTab1_Opening.CssClass = "TabButton_InActive" And btnTab2_Abstract.CssClass = "TabButton_Active" And btnTab3_Evaluation.CssClass = "TabButton_InActive" And btnTab4_PostQua.CssClass = "TabButton_InActive" Then

                LoadAbstract()

                drpBACVC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 2", CommandType.Text)
                drpBACVC.DataTextField = ("Name")
                drpBACVC.DataValueField = ("empsig_id")
                drpBACVC.DataBind()

                drpBACC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 1", CommandType.Text)
                drpBACC.DataTextField = ("Name")
                drpBACC.DataValueField = ("empsig_id")
                drpBACC.DataBind()

                drpGSO.DataSource = objDerived.GetDataTable("SELECT TOP(1) Full_Name, EmpID, position_desc FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 7 AND division_Key = 86 ", CommandType.Text)
                drpGSO.DataTextField = ("Full_Name")
                drpGSO.DataValueField = ("EmpID")
                drpGSO.DataBind()

                drpCBO.DataSource = objDerived.GetDataTable("SELECT TOP(1) Full_Name, EmpID, position_desc FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 8 AND division_Key = 86 ", CommandType.Text)
                drpCBO.DataTextField = ("Full_Name")
                drpCBO.DataValueField = ("EmpID")
                drpCBO.DataBind()

                drpCEO.DataSource = objDerived.GetDataTable("SELECT TOP(1) Full_Name, EmpID, position_desc FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 27 AND division_Key = 86 ", CommandType.Text)
                drpCEO.DataTextField = ("Full_Name")
                drpCEO.DataValueField = ("EmpID")
                drpCEO.DataBind()

                mvTabs.SetActiveView(Me.vwTab2_Abstract)

            ElseIf btnTab1_Opening.CssClass = "TabButton_InActive" And btnTab2_Abstract.CssClass = "TabButton_InActive" And btnTab3_Evaluation.CssClass = "TabButton_Active" And btnTab4_PostQua.CssClass = "TabButton_InActive" Then

                LoadEvaluation()
                mvTabs.SetActiveView(Me.vwTab3_Evaluation)

            ElseIf btnTab1_Opening.CssClass = "TabButton_InActive" And btnTab2_Abstract.CssClass = "TabButton_InActive" And btnTab3_Evaluation.CssClass = "TabButton_InActive" And btnTab4_PostQua.CssClass = "TabButton_Active" Then


                LoadPostQualification()
                mvTabs.SetActiveView(Me.vwTab4_PostQua)

            Else

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub

    Private Sub LoadAbstract()
        dtAbstract = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Bidding] 'Abstract'", CommandType.Text)
        If dtAbstract.Rows.Count < 5 Then
            dtAbstract.Merge(dtTemp_Table(4 - dtAbstract.Rows.Count))
        End If
        grdAbstract.DataSource = dtAbstract
        grdAbstract.DataBind()
        grdAbstract.SelectedIndex = -1

        grdAbstract_Bidders.DataSource = dtTemp_AbstractBidder(4)
        grdAbstract_Bidders.DataBind()

    End Sub




    '----- INTERESTED BIDDERS
    Private Sub btnSearch_Opening_Click(sender As Object, e As EventArgs) Handles btnSearch_Opening.Click
        Dim myview As DataView
        myview = dtBidOpen.DefaultView

        If drpSearch_Opening.SelectedItem.Value = 1 Then
            myview.RowFilter = "ITB_No like '%" & replaceapostrophe(txtSearch_Opening.Text) & "%'"
        ElseIf drpSearch_Opening.SelectedItem.Value = 2 Then
            myview.RowFilter = "PPA like '%" & replaceapostrophe(txtSearch_Opening.Text) & "%'"
        End If

        grdOpening.DataSource = myview
        grdOpening.DataBind()



    End Sub
    Private Sub grdOpening_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdOpening.PageIndexChanging
        grdOpening.DataSource = dtBidOpen
        grdOpening.PageIndex = e.NewPageIndex
        grdOpening.DataBind()
    End Sub
    Protected Sub lnkSelect_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        strOpening = "Select"
    End Sub
    Protected Sub lnkDone_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        strOpening = "Done"
    End Sub
    Private Sub grdOpening_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdOpening.SelectedIndexChanged
        Try

            Session("Infra_BidPrep_ID") = grdOpening.SelectedDataKey("Infra_BidPrep_ID")

            If strOpening = "Select" Then
                drpSupplier.DataSource = objDerived.GetDataTable("SELECT B.Supplier_Id, B.SuppName FROM AMS.tbl_Infra_InterestedBidders AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id WHERE A.Infra_BidPrep_ID = '" & Session("Infra_BidPrep_ID") & "' ORDER BY SuppName", CommandType.Text)
                drpSupplier.DataTextField = "SuppName"
                drpSupplier.DataValueField = "Supplier_Id"
                drpSupplier.DataBind()
                drpSupplier.Items.Insert(0, "Select")

                LoadBidders()
                btnAdd_Supplier.Enabled = True

            ElseIf strOpening = "Done" Then
                objDerived.Execute("UPDATE [AMS].[tbl_Infra_BidPreparation] SET [isDone_Bidders] = 1 WHERE [Infra_BidPrep_ID] = '" & Session("Infra_BidPrep_ID") & "'", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")

                dtBidOpen = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Bidding] 'BidOpening'", CommandType.Text)
                If dtBidOpen.Rows.Count < 5 Then
                    dtBidOpen.Merge(dtTemp_Table(4 - dtBidOpen.Rows.Count))
                End If
                grdOpening.DataSource = dtBidOpen
                grdOpening.DataBind()
                'grdOpening.PageIndex = -1

                grdBidders.DataSource = dtTemp_Bidder(4)
                grdBidders.DataBind()

            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Session timeout, refresh the page.")
            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Private Sub LoadBidders()
        dtBidders = objDerived.GetDataTable("SELECT A.Infra_Bidders_ID, A.Supplier_ID, B.SuppName, B.ContactP, B.Address1, CONVERT(BIT,1) AS isVisible  FROM AMS.tbl_Infra_Bidding AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id " &
                                        " WHERE A.Infra_BidPrep_ID = '" & grdOpening.SelectedDataKey("Infra_BidPrep_ID") & "' ORDER BY B.SuppName", CommandType.Text)
        If dtBidders.Rows.Count < 5 Then
            dtBidders.Merge(dtTemp_Bidder(4 - dtBidders.Rows.Count))
        End If
        grdBidders.DataSource = dtBidders
        grdBidders.DataBind()
        grdBidders.SelectedIndex = -1


        dtEligibility = objDerived.GetDataTable("SELECT A.Infra_Bidders_ID, A.Supplier_ID, B.SuppName, A.PhilGEPS_Cert, A.OnGoing, A.OnGoing_Remarks, A.SLCC, A.SLCC_Remakrs, A.NFCC, A.NFCC_Remarks, A.JVA, A.JVA_Remarks " &
                                            " FROM AMS.tbl_Infra_Bidding AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id WHERE A.Infra_BidPrep_ID = '" & grdOpening.SelectedDataKey("Infra_BidPrep_ID") & "' ORDER BY B.SuppName", CommandType.Text)
        grdEqligibility.DataSource = dtEligibility
        grdEqligibility.DataBind()

        If grdEqligibility.Rows.Count <> 0 Then
            btnSave_Eligibility.Enabled = True
        Else
            btnSave_Eligibility.Enabled = False
        End If


    End Sub
    Private Sub btnAdd_Supplier_Click(sender As Object, e As EventArgs) Handles btnAdd_Supplier.Click
        Try
            If drpSupplier.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select bidder.")

            Else
                objDerived.Execute("INSERT INTO [AMS].[tbl_Infra_Bidding] ([Infra_BidPrep_ID],[Supplier_ID],[BidSec_Form1],[BidSec_Form2],[Company],[Number],[OR_No]    " &
                              "  ,[ValidityPeriod],[BidSec_Amt1],[BidSec_Amt2],[BidSec_Req1],[BidSec_Req2],[Sufficient],[Remarks],[BidDocs_Amt],[Omnibus_Sworn],[withAuthorize_Sig])                        " &
                              "  VALUES                                                     " &
                              "  ('" & grdOpening.SelectedDataKey("Infra_BidPrep_ID") & "' " &
                              "  ,'" & drpSupplier.SelectedItem.Value & "'                  " &
                              "  ,'" & drpBidSecurity1.SelectedItem.Text & "'               " &
                              "  ,'" & drpBidSecurity2.SelectedItem.Text & "'               " &
                              "  ,'" & txtCompany.Text & "'                                 " &
                              "  ,'" & txtNumber.Text & "'                                  " &
                              "  ,'" & txtOR.Text & "'                                      " &
                              "  ,'" & txtValidity.Text & "'                                " &
                              "  ,'" & CType(txtBidSec_Amt1.Text, Decimal) & "'             " &
                              "  ,'" & CType(txtBidSec_Amt2.Text, Decimal) & "'             " &
                              "  ,'" & CType(txtBidSec_Req1.Text, Decimal) & "'             " &
                              "  ,'" & CType(txtBidSec_Req2.Text, Decimal) & "'             " &
                              "  ,'" & txtSufficient.Text & "'                              " &
                              "  ,'" & replaceapostrophe(txtRemarks.Text) & "'              " &
                              "  ,'" & grdOpening.SelectedDataKey("BidDoc_Amt") & "'        " &
                              "  ,'" & cbOmnibus.Checked & "'                               " &
                              "  ,'" & cbAuthorized.Checked & "')", CommandType.Text)


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected bidders has been successfully saved.")
                LoadBidders()

                drpSupplier.DataSource = objDerived.GetDataTable("SELECT B.Supplier_Id, B.SuppName FROM AMS.tbl_Infra_InterestedBidders AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id WHERE A.Infra_BidPrep_ID = '" & Session("Infra_BidPrep_ID") & "' ORDER BY SuppName", CommandType.Text)
                drpSupplier.DataTextField = "SuppName"
                drpSupplier.DataValueField = "Supplier_Id"
                drpSupplier.DataBind()
                drpSupplier.Items.Insert(0, "Select")

                drpBidSecurity1.DataSource = objDerived.GetDataTable("SELECT BidSecurity_id, Description, percentage FROM AMS.BidSecurity ORDER BY BidSecurity_id", CommandType.Text)
                drpBidSecurity1.DataTextField = "Description"
                drpBidSecurity1.DataValueField = "percentage"
                drpBidSecurity1.DataBind()
                drpBidSecurity1.Items.Insert(0, "Select")

                drpBidSecurity2.DataSource = objDerived.GetDataTable("SELECT BidSecurity_id, Description, percentage FROM AMS.BidSecurity ORDER BY BidSecurity_id", CommandType.Text)
                drpBidSecurity2.DataTextField = "Description"
                drpBidSecurity2.DataValueField = "percentage"
                drpBidSecurity2.DataBind()
                drpBidSecurity2.Items.Insert(0, "Select")

                txtCompany.Text = ""
                txtNumber.Text = ""
                txtOR.Text = ""
                txtValidity.Text = ""
                txtBidSec_Amt1.Text = "0.00"
                txtBidSec_Amt2.Text = "0.00"
                txtBidSec_Req1.Text = "0.00"
                txtBidSec_Req2.Text = "0.00"
                txtSufficient.Text = "Sufficient"
                txtRemarks.Text = ""

            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Protected Sub lnkPreview_OP_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        strBidders = "Preview"
    End Sub
    Protected Sub lnkRemove_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        strBidders = "Remove"
    End Sub
    Private Sub grdBidders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdBidders.SelectedIndexChanged
        Try

            If strBidders = "Preview" Then
                Session("Report") = "OP"
                Session("Page") = "Infra_Bid"
                Session("Bidder") = grdBidders.SelectedDataKey("SuppName")

                Dim url As String = "../../MainReports/rpt_Infra_Reports.aspx"
                Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
                ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)

            ElseIf strBidders = "Remove" Then
                objDerived.Execute("DELETE FROM [AMS].[tbl_Infra_Bidding] WHERE [Infra_Bidders_ID] = '" & grdBidders.SelectedDataKey("Infra_Bidders_ID") & "'", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected bidder has been successfully removed.")

                LoadBidders()
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Session timeout, refresh the page.")
            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSave_Eligibility_Click(sender As Object, e As EventArgs) Handles btnSave_Eligibility.Click
        Try

            For i As Integer = 0 To grdEqligibility.Rows.Count - 1
                objDerived.Execute("UPDATE [AMS].[tbl_Infra_Bidding]                                                                    " &
                             "  SET [PhilGEPS_Cert] = '" & CType(grdEqligibility.Rows(i).FindControl("cbPhilgeps"), CheckBox).Checked & "'        " &
                             "  ,[OnGoing] = '" & CType(grdEqligibility.Rows(i).FindControl("cbOngoing"), CheckBox).Checked & "'                 " &
                             "  ,[OnGoing_Remarks] = '" & CType(grdEqligibility.Rows(i).FindControl("txtOngoing"), TextBox).Text & "'             " &
                             "  ,[SLCC] = '" & CType(grdEqligibility.Rows(i).FindControl("cbSLCC"), CheckBox).Checked & "'                    " &
                             "  ,[SLCC_Remakrs] = '" & CType(grdEqligibility.Rows(i).FindControl("txtSLCC"), TextBox).Text & "'                " &
                             "  ,[NFCC] = '" & CType(grdEqligibility.Rows(i).FindControl("cbNFCC"), CheckBox).Checked & "'                    " &
                             "  ,[NFCC_Remarks] = '" & CType(grdEqligibility.Rows(i).FindControl("txtNFCC"), TextBox).Text & "'                " &
                             "  ,[JVA] = '" & CType(grdEqligibility.Rows(i).FindControl("cbJVA"), CheckBox).Checked & "'                     " &
                             "  ,[JVA_Remarks] = '" & CType(grdEqligibility.Rows(i).FindControl("txtJVA"), TextBox).Text & "'                 " &
                             "  WHERE [Infra_Bidders_ID] = '" & dtEligibility.Rows(i)("Infra_Bidders_ID") & "'", CommandType.Text)
            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Eligibility has beed successfulle saved.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub


    '----- ABSTRACT 
    Private Sub grdAbstract_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdAbstract.PageIndexChanging
        grdAbstract.DataSource = dtAbstract
        grdAbstract.PageIndex = e.NewPageIndex
        grdAbstract.DataBind()
    End Sub
    Protected Sub lnkAbstract_Select_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        strAbstract = "Select"
    End Sub
    Protected Sub lnkAbstract_Back_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        strAbstract = "Back"
    End Sub
    Private Sub grdAbstract_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdAbstract.SelectedIndexChanged
        Try

            If strAbstract = "Select" Then
                txtAbstract_Date.Text = Date.Today.ToShortDateString

                drpEndUser.DataSource = objDerived.GetDataTable("SELECT Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = '" & grdAbstract.SelectedDataKey("RC_ID") & "' AND division_Key = '" & grdAbstract.SelectedDataKey("Function_ID") & "' ORDER BY isDeptHead DESC, Full_Name", CommandType.Text)
                drpEndUser.DataTextField = ("Full_Name")
                drpEndUser.DataValueField = ("EmpID")
                drpEndUser.DataBind()

                dtAbstract_Bidders = objDerived.GetDataTable("SELECT A.Infra_Bidders_ID, A.Supplier_ID, B.SuppName, ISNULL(A.BidAmount,0) AS BidAmount, CONVERT(BIT,1) AS isVisible " &
                                            " FROM AMS.tbl_Infra_Bidding AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id WHERE A.Infra_BidPrep_ID = '" & grdAbstract.SelectedDataKey("Infra_BidPrep_ID") & "' ORDER BY B.SuppName", CommandType.Text)
                grdAbstract_Bidders.DataSource = dtAbstract_Bidders
                grdAbstract_Bidders.DataBind()


                btnAbstract_Save.Enabled = True
                btnAbstract_Preview.Enabled = False

            ElseIf strAbstract = "Back" Then
                objDerived.Execute("UPDATE [AMS].[tbl_Infra_BidPreparation] SET [isDone_Bidders] = 0 WHERE Infra_BidPrep_ID = '" & grdAbstract.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully returned.")
                LoadAbstract()

            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Session timeout, refresh the page.")
            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Protected Sub txtBidAmount_OnTextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtBidAmount As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtBidAmount.NamingContainer, GridViewRow)

            If txtBidAmount.Text = "" Then
                txtBidAmount.Text = "0"
            End If

            txtBidAmount.Text = FormatNumber(txtBidAmount.Text, 2)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnAbstract_Save_Click(sender As Object, e As EventArgs) Handles btnAbstract_Save.Click
        Try
            Dim withBid As String = "None"
            For i As Integer = 0 To grdAbstract_Bidders.Rows.Count - 1
                If CType(grdAbstract_Bidders.Rows(i).FindControl("txtBidAmount"), TextBox).Text = "" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Total bid amount is required.")
                    Exit Sub

                ElseIf CType(grdAbstract_Bidders.Rows(i).FindControl("txtBidAmount"), TextBox).Text <> "0.00" Then
                    withBid = "WithBid"
                End If
            Next

            If withBid = "None" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Total bid amount is required.")

            Else
                For i As Integer = 0 To grdAbstract_Bidders.Rows.Count - 1
                    objDerived.Execute("UPDATE [AMS].[tbl_Infra_Bidding] SET BidAmount = '" & CType(CType(grdAbstract_Bidders.Rows(i).FindControl("txtBidAmount"), TextBox).Text, Decimal) & "' WHERE Infra_Bidders_ID = '" & dtAbstract_Bidders.Rows(i)("Infra_Bidders_ID") & "' AND Supplier_ID = '" & dtAbstract_Bidders.Rows(i)("Supplier_ID") & "'", CommandType.Text)
                Next

                objDerived.Execute("UPDATE [AMS].[tbl_Infra_BidPreparation] SET withAbstract = 1, [Abstract_Date] = '" & CType(txtAbstract_Date.Text, Date) & "', [Abstract_Time] = '" & txtAbstract_Time.Text + " " + drpAbstract_Time.SelectedItem.Text & "', [Asbtract_BACC] = '" & drpBACC.SelectedItem.Value & "' " &
                                    " , [Abstract_BACVC] = '" & drpBACVC.SelectedItem.Value & "', [GSO] = '" & drpGSO.SelectedItem.Value & "', [CBO] = '" & drpCBO.SelectedItem.Value & "', [CEO] = '" & drpCEO.SelectedItem.Value & "', [EndUser] = '" & drpEndUser.SelectedItem.Value & "' WHERE Infra_BidPrep_ID = '" & grdAbstract.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)

                Session("Infra_BidPrep_ID") = grdAbstract.SelectedDataKey("Infra_BidPrep_ID")

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                LoadAbstract()

                btnAbstract_Save.Enabled = False
                btnAbstract_Preview.Enabled = True

            End If



        Catch ex As Exception
            objDerived.Execute("UPDATE [AMS].[tbl_Infra_Bidding] SET BidAmount = 0 WHERE Infra_BidPrep_ID = '" & grdAbstract.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)
            objDerived.Execute("UPDATE [AMS].[tbl_Infra_BidPreparation] SET withAbstract = 0 WHERE Infra_BidPrep_ID = '" & grdAbstract.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnAbstract_Preview_Click(sender As Object, e As EventArgs) Handles btnAbstract_Preview.Click

        Session("Report") = "Abstract"
        Session("Page") = "Infra_Bid"

        Dim url As String = "../../MainReports/rpt_Infra_Reports.aspx"
        Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)


    End Sub




    '----- EVALUATION
    Private Sub LoadEvaluation()
        dtEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Bidding] 'Evaluation'", CommandType.Text)
        If dtEvaluation.Rows.Count < 5 Then
            dtEvaluation.Merge(dtTemp_Table(4 - dtEvaluation.Rows.Count))
        End If
        grdEvaluation.DataSource = dtEvaluation
        grdEvaluation.DataBind()
        grdEvaluation.SelectedIndex = -1

        lblEval_ITB1.Text = "ITB-00-000"
        lblEval_ITB2.Text = "ITB-00-000"
        lblEval_ITB3.Text = "ITB-00-000"
        lblEval_ITB4.Text = "ITB-00-000"

        grdEval_Read.DataSource = dtTemp_Eval(2)
        grdEval_Read.DataBind()

        grdEval_Calculated.DataSource = dtTemp_Eval(2)
        grdEval_Calculated.DataBind()

        drpTWGChairman.DataSource = objDerived.GetDataTable("SELECT Name, empsig_id FROM DBO.View_BAC WHERE isActive = 1 AND isDefault = 1 AND BAC_PostionID = 12", CommandType.Text)
        drpTWGChairman.DataTextField = "Name"
        drpTWGChairman.DataValueField = "empsig_id"
        drpTWGChairman.DataBind()


        drpBACSecretariat.DataSource = objDerived.GetDataTable("SELECT Name, empsig_id FROM DBO.View_BAC WHERE isActive = 1 AND isDefault = 1 AND BAC_PostionID = 7", CommandType.Text)
        drpBACSecretariat.DataTextField = "Name"
        drpBACSecretariat.DataValueField = "empsig_id"
        drpBACSecretariat.DataBind()

        drpEval_BACC.DataSource = objDerived.GetDataTable("SELECT Name, empsig_id FROM DBO.View_BAC WHERE isActive = 1 AND isDefault = 1 AND BAC_PostionID = 1", CommandType.Text)
        drpEval_BACC.DataTextField = "Name"
        drpEval_BACC.DataValueField = "empsig_id"
        drpEval_BACC.DataBind()



    End Sub
    Private Sub btnEval_Search_Click(sender As Object, e As EventArgs) Handles btnEval_Search.Click
        Try
            Dim myview As DataView
            myview = dtEvaluation.DefaultView

            If drpEval_Search.SelectedItem.Value = 1 Then
                myview.RowFilter = "ITB_No like '%" & replaceapostrophe(txtEval_Search.Text) & "%'"
            ElseIf drpEval_Search.SelectedItem.Value = 2 Then
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtEval_Search.Text) & "%'"
            End If

            grdEvaluation.DataSource = myview
            grdEvaluation.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdEvaluation_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdEvaluation.PageIndexChanging
        grdEvaluation.DataSource = dtEvaluation
        grdEvaluation.PageIndex = e.NewPageIndex
        grdEvaluation.DataBind()
    End Sub
    Private Sub grdEvaluation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdEvaluation.SelectedIndexChanged
        Try

            lblEval_ITB1.Text = grdEvaluation.SelectedDataKey("ITB_No")
            lblEval_ITB2.Text = grdEvaluation.SelectedDataKey("ITB_No")
            lblEval_ITB3.Text = grdEvaluation.SelectedDataKey("ITB_No")
            lblEval_ITB4.Text = grdEvaluation.SelectedDataKey("ITB_No")

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_BidEvaluation] '" & grdEvaluation.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)

            txtEval_1.Text = dt.Rows(0)("EVAL1")
            txtEval_2.Text = dt.Rows(0)("EVAL2")
            txtEval_2B.Text = dt.Rows(0)("EVAL2B")
            txtEval_3.Text = dt.Rows(0)("EVAL3")
            txtEval_4.Text = dt.Rows(0)("EVAL4")
            txtEval_Footer.Text = dt.Rows(0)("Footer")

            txt1_Name.Text = "Local Government Unit of Pasay"
            txt1_Address.Text = "F.B. Harrison St., Pasay City"
            txt1_ProjectName.Text = dt.Rows(0)("ProjectName")
            txt1_ProjectLoc.Text = dt.Rows(0)("Project_Loc")
            txt1_ABC.Text = FormatNumber(CType(dt.Rows(0)("Amount"), Decimal), 2)
            txt1_MOP.Text = "Competitive Bidding"

            txt2_DateConf.Text = dt.Rows(0)("PreBid_Date")
            txt2_DatePub.Text = dt.Rows(0)("Posting")
            txt2_Website.Text = "PhilGEPs"
            txt2_DateConf2.Text = dt.Rows(0)("PreBid_Date")

            txt3_OriginalDate.Text = dt.Rows(0)("BidOpen_Date")
            txt3_DateOpen.Text = dt.Rows(0)("BidOpen_Date")

            grdEval_Read.DataSource = dt
            grdEval_Read.DataBind()

            grdEval_Calculated.DataSource = dt
            grdEval_Calculated.DataBind()

            txtEval_Date.Text = Date.Today.ToShortDateString
            btnSave_BidEval.Enabled = True
            btnPreview_BidEval.Enabled = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSave_BidEval_Click(sender As Object, e As EventArgs) Handles btnSave_BidEval.Click
        Try
            Session("Infra_BidPrep_ID") = grdEvaluation.SelectedDataKey("Infra_BidPrep_ID")

            objDerived.Execute("INSERT INTO [AMS].[tbl_Infra_Evaluation] ([Infra_BidPrep_ID],[eval_Date],[eval_1],[tbl1_Name],[tbl1_Address],[tbl1_ProjectName],[tbl1_ProjectLoc],[tbl1_ABC],[tbl1_MOP],[eval_2] " &
                          "  ,[eval_2B],[tbl2_DateConf],[tbl2_DatePub],[tbl2_Website],[tbl2_DateEligibility],[tbl2_EligibilityNo],[tbl2_DateNotice],[tbl2_Motions],[tbl2_Period],[tbl2_BicDocsNo] " &
                          "  ,[tbl2_IssueDates],[tbl2_DateConf2],[tbl2_DateMinutes],[eval_3],[tbl3_DateOrig],[tbl3_Extension],[tbl3_DateBidOpen],[tbl3_Minutes],[tbl3_Numbers],[tbl3_OriginalSpec] " &
                          "  ,[tbl3_Revisions],[eval_4],[TWG],[BACSec],[BACC],[Eval_Footer]) VALUES  " &
                          "  ('" & grdEvaluation.SelectedDataKey("Infra_BidPrep_ID") & "'              " &
                          "  ,'" & CType(txtEval_Date.Text, Date) & "'                " &
                          "  ,'" & replaceapostrophe(txtEval_1.Text) & "'               " &
                          "  ,'" & replaceapostrophe(txt1_Name.Text) & "'           " &
                          "  ,'" & replaceapostrophe(txt1_Address.Text) & "'        " &
                          "  ,'" & replaceapostrophe(txt1_ProjectName.Text) & "'    " &
                          "  ,'" & replaceapostrophe(txt1_ProjectLoc.Text) & "'      " &
                          "  ,'" & CType(txt1_ABC.Text, Decimal) & "'           " &
                          "  ,'" & replaceapostrophe(txt1_MOP.Text) & "'            " &
                          "  ,'" & replaceapostrophe(txtEval_2.Text) & "'               " &
                          "  ,'" & replaceapostrophe(txtEval_2B.Text) & "'              " &
                          "  ,'" & replaceapostrophe(txt2_DateConf.Text) & "'        " &
                          "  ,'" & replaceapostrophe(txt2_DatePub.Text) & "'         " &
                          "  ,'" & replaceapostrophe(txt2_Website.Text) & "'         " &
                          "  ,'" & replaceapostrophe(txt2_DateEligible.Text) & "' " &
                          "  ,'" & replaceapostrophe(txt2_Envelop.Text) & "'   " &
                          "  ,'" & replaceapostrophe(txt2_DateNotice.Text) & "'      " &
                          "  ,'" & replaceapostrophe(txt2_Motion.Text) & "'        " &
                          "  ,'" & replaceapostrophe(txt2_Period.Text) & "'          " &
                          "  ,'" & replaceapostrophe(txt2_BidDocsIssued.Text) & "'       " &
                          "  ,'" & replaceapostrophe(txt2_ListDate.Text) & "'      " &
                          "  ,'" & replaceapostrophe(txt2_DateConf2.Text) & "'       " &
                          "  ,'" & replaceapostrophe(txt2_DateMinutes.Text) & "'    " &
                          "  ,'" & replaceapostrophe(txtEval_3.Text) & "'              " &
                          "  ,'" & replaceapostrophe(txt3_OriginalDate.Text) & "'        " &
                          "  ,'" & replaceapostrophe(txt3_Extension.Text) & "'       " &
                          "  ,'" & replaceapostrophe(txt3_DateOpen.Text) & "'     " &
                          "  ,'" & replaceapostrophe(txt3_Minutes.Text) & "'         " &
                          "  ,'" & replaceapostrophe(txt3_BidSubmitted.Text) & "'        " &
                          "  ,'" & replaceapostrophe(txt3_OriginallySpec.Text) & "'    " &
                          "  ,'" & replaceapostrophe(txt3_Revisions.Text) & "'       " &
                          "  ,'" & replaceapostrophe(txtEval_4.Text) & "'               " &
                          "  ,'" & drpTWGChairman.SelectedItem.Value & "'                           " &
                          "  ,'" & drpBACSecretariat.SelectedItem.Value & "'                        " &
                          "  ,'" & drpEval_BACC.SelectedItem.Value & "'                         " &
                          "  ,'" & replaceapostrophe(txtEval_Footer.Text) & "')", CommandType.Text)


            objDerived.Execute("UPDATE [AMS].[tbl_Infra_BidPreparation] SET withEvaluation = 1 WHERE Infra_BidPrep_ID = '" & Session("Infra_BidPrep_ID") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Bid Evaluation has been successfully saved.")
            LoadEvaluation()

            btnSave_BidEval.Enabled = False
            btnPreview_BidEval.Enabled = True

        Catch ex As Exception
            objDerived.Execute("DELETE FROM [AMS].[tbl_Infra_Evaluation] WHERE Infra_BidPrep_ID = '" & Session("Infra_BidPrep_ID") & "'", CommandType.Text)
            objDerived.Execute("UPDATE [AMS].[tbl_Infra_BidPreparation] SET withEvaluation = 0 WHERE Infra_BidPrep_ID = '" & Session("Infra_BidPrep_ID") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnPreview_BidEval_Click(sender As Object, e As EventArgs) Handles btnPreview_BidEval.Click
        Session("Report") = "Evaluation"
        Session("Page") = "Infra_Bid"

        Dim url As String = "../../MainReports/rpt_Infra_Reports.aspx"
        Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)


    End Sub




    '------ POST QUALIFICATION
    Private Sub LoadPostQualification()
        Try
            dtPostQua = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Bidding] 'PostQua'", CommandType.Text)
            If dtPostQua.Rows.Count < 5 Then
                dtPostQua.Merge(dtTemp_Table(4 - dtPostQua.Rows.Count))
            End If
            grdPostQua.DataSource = dtPostQua
            grdPostQua.DataBind()
            grdPostQua.SelectedIndex = -1

            grdPostQua_Bidders.DataSource = Nothing
            grdPostQua_Bidders.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnPostQua_Search_Click(sender As Object, e As EventArgs) Handles btnPostQua_Search.Click
        Try
            Dim myview As DataView
            myview = dtPostQua.DefaultView

            If drpPostQua_Search.SelectedItem.Value = 1 Then
                myview.RowFilter = "ITB_No like '%" & replaceapostrophe(txtPostQua_Search.Text) & "%'"
            ElseIf drpPostQua_Search.SelectedItem.Value = 2 Then
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtPostQua_Search.Text) & "%'"
            End If

            grdPostQua.DataSource = myview
            grdPostQua.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub


End Class
