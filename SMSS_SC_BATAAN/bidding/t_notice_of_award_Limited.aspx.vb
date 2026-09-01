Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.DataTable
Imports System.Data.DataRow
Imports System.Data.DataRowCollection
Partial Class bidding_t_notice_of_award_Limited
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim Preview As String
    Private Bid As New Bid_information
    Dim AuditTrail As New Audit_Trail


#Region "Funtion"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("RefNumber", GetType(String))
        dt.Columns.Add("BidLocation", GetType(String))
        dt.Columns.Add("countSupplier", GetType(Integer))
        dt.Columns.Add("TotalABC", GetType(Decimal))
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("obr_evaluation_hdr_id", GetType(Long))
        dt.Columns.Add("isPublicInfra", GetType(Boolean))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("RefNumber") = DBNull.Value
            dr("BidLocation") = DBNull.Value
            dr("countSupplier") = DBNull.Value
            dr("TotalABC") = DBNull.Value
            dr("pre_procurement_hdr_id") = 0
            dr("obr_evaluation_hdr_id") = DBNull.Value
            dr("isPublicInfra") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
#End Region
#Region "property"

    Private Property dtNoticeAward() As DataTable
        Get
            Return CType(Session("dtNoticeAward"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtNoticeAward") = value
        End Set
    End Property

    Private Property dtApprovedby() As DataTable
        Get
            Return CType(Session("dtApprovedby"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtApprovedby") = value
        End Set
    End Property

    Private Property dtPreparedBy() As DataTable
        Get
            Return CType(Session("dtPreparedBy"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPreparedBy") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'obj.GetAccessRight(Me.Session("@UserName"), Page)
            'If obj.HasAccess = False Then
            '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            'End If

            txtAwardDate.Text = Date.Today.ToString("MM/dd/yyyy")

            dtNoticeAward = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeOfAward_Limited]", CommandType.Text)
            If dtNoticeAward.Rows.Count < 5 Then
                dtNoticeAward.Merge(CreateTable1(5 - dtNoticeAward.Rows.Count))
            End If
            grdNoticeAward.DataSource = dtNoticeAward
            grdNoticeAward.DataBind()

            dtApprovedby = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeOfAward_Signatory]", CommandType.Text)
            ddApprovedBy.DataSource = dtApprovedby
            ddApprovedBy.DataTextField = ("SignatoryName")
            ddApprovedBy.DataValueField = ("ID")
            ddApprovedBy.DataBind()
            ddApprovedBy.Items.Insert(0, "Select")

            dtPreparedBy = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, UPPER(Position_desc) AS Position_desc, empsig_id FROM dbo.View_BAC WHERE isPublicInfra ='Goods' ORDER BY Name", CommandType.Text)
            ddPreparedBy.DataSource = dtPreparedBy
            ddPreparedBy.DataTextField = ("Name")
            ddPreparedBy.DataValueField = ("empsig_id")
            ddPreparedBy.DataBind()
            ddPreparedBy.Items.Insert(0, "Select")

            grdItems.DataSource = Nothing
            grdItems.DataBind()

        End If
    End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not Page.IsPostBack Then
    '        ' Uncomment and implement access right checking when required
    '        ' CheckAccessRights(Me.Session("@UserName"), Page)

    '        ' Set the default award date to today
    '        SetDefaultAwardDate()

    '        ' Load and bind Notice of Award data
    '        LoadAndBindNoticeOfAward()

    '        ' Load and bind Approved By dropdown data
    '        LoadAndBindDropdown(ddApprovedBy, "EXEC [AMS].[sp_NoticeOfAward_Signatory]", "SignatoryName", "ID")

    '        ' Load and bind Prepared By dropdown data
    '        LoadAndBindDropdown(ddPreparedBy, "SELECT UPPER(Name) AS Name, UPPER(Position_desc) AS Position_desc, empsig_id FROM dbo.View_BAC WHERE isPublicInfra = 'Goods' ORDER BY Name", "Name", "empsig_id")

    '        ' Clear Items Grid since no data source is assigned
    '        ClearGrid(grdItems)
    '    End If
    'End Sub

    Private Sub CheckAccessRights(userName As String, currentPage As Page)
        obj.GetAccessRight(userName, currentPage)
        If Not obj.HasAccess Then
            currentPage.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If
    End Sub

    Private Sub SetDefaultAwardDate()
        txtAwardDate.Text = Date.Today.ToString("MM/dd/yyyy")
    End Sub

    Private Sub LoadAndBindNoticeOfAward()
        dtNoticeAward = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeOfAward_Limited]", CommandType.Text)
        If dtNoticeAward.Rows.Count < 5 Then
            dtNoticeAward.Merge(CreateTable1(5 - dtNoticeAward.Rows.Count))
        End If
        grdNoticeAward.DataSource = dtNoticeAward
        grdNoticeAward.DataBind()
    End Sub

    Private Sub LoadAndBindDropdown(ddl As DropDownList, query As String, textField As String, valueField As String)
        Dim dataTable As DataTable = objDerived.GetDataTable(query, CommandType.Text)
        With ddl
            .DataSource = dataTable
            .DataTextField = textField
            .DataValueField = valueField
            .DataBind()
            .Items.Insert(0, "Select")
        End With
    End Sub

    Private Sub ClearGrid(grid As GridView)
        grid.DataSource = Nothing
        grid.DataBind()
    End Sub

    Protected Sub grdNoticeAward_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtNoticeAward = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeOfAward_Limited]", CommandType.Text)
        If dtNoticeAward.Rows.Count < 5 Then
            dtNoticeAward.Merge(CreateTable1(5 - dtNoticeAward.Rows.Count))
        End If
        grdNoticeAward.PageIndex = e.NewPageIndex
        grdNoticeAward.DataSource = dtNoticeAward
        grdNoticeAward.DataBind()

    End Sub

    Protected Sub linkResolution_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Preview = "Resolution"
    End Sub

    Protected Sub linkNoticeAward_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Preview = "NoticeAward"
    End Sub

    Protected Sub grdNoticeAward_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("pre_procurement_hdr_id") = grdNoticeAward.SelectedDataKey("pre_procurement_hdr_id")
        Session("Supplier_Id") = grdNoticeAward.SelectedDataKey("Supplier_Id")
        Session("TotalBidAmount") = grdNoticeAward.SelectedDataKey("TotalBidAmount")
        Session("CountSupplier") = grdNoticeAward.SelectedDataKey("CountSupplier")

        If grdNoticeAward.SelectedDataKey("pre_procurement_hdr_id") = 0 Then
            txtPRNumber.Text = ""
            txtArticle.Text = ""

        Else
            If grdNoticeAward.SelectedDataKey("project_name") = "Consolidated Purchase Request" Then
                txtArticle.Text = "Consolidated Purchase Request"
            Else
                txtArticle.Text = grdNoticeAward.SelectedDataKey("project_name")
            End If

            Dim PR_No As String = objDerived.GetValue("EXEC [AMS].[sp_GetPRNumber] '" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)
            txtPRNumber.Text = PR_No

        End If

        If txtPRNumber.Text = "" Then
            txtArticle.Enabled = False
            ddApprovedBy.Enabled = False
            btnSave.Enabled = False
            btnReturn.Enabled = False
        Else
            txtArticle.Enabled = True
            ddApprovedBy.Enabled = True
            btnSave.Enabled = True
            btnReturn.Enabled = True
        End If


        Dim dt = objDerived.GetDataTable("EXEC [AMS].[sp_View_NOA_Items]'" & Session("Supplier_Id") & "','" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)
        grdItems.DataSource = dt
        grdItems.DataBind()

    End Sub
    'Protected Sub grdNoticeAward_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNoticeAward.SelectedIndexChanged
    '    UpdateSessionVariables()

    '    ConfigureArticleAndPRNumberFields()

    '    EnableDisableControlsBasedOnPRNumber()

    '    BindNOAItems()
    'End Sub

    Private Sub UpdateSessionVariables()
        With grdNoticeAward.SelectedDataKey
            Session("pre_procurement_hdr_id") = .Item("pre_procurement_hdr_id")
            Session("Supplier_Id") = .Item("Supplier_Id")
            Session("TotalBidAmount") = .Item("TotalBidAmount")
            Session("CountSupplier") = .Item("CountSupplier")
        End With
    End Sub

    Private Sub ConfigureArticleAndPRNumberFields()
        If Convert.ToInt32(Session("pre_procurement_hdr_id")) = 0 Then
            txtPRNumber.Text = ""
            txtArticle.Text = ""
        Else
            txtArticle.Text = If(grdNoticeAward.SelectedDataKey("project_name").ToString() = "Consolidated Purchase Request", "Consolidated Purchase Request", grdNoticeAward.SelectedDataKey("project_name").ToString())

            txtPRNumber.Text = objDerived.GetValue("EXEC [AMS].[sp_GetPRNumber] '" & Convert.ToString(Session("pre_procurement_hdr_id")) & "'", CommandType.Text)

        End If
    End Sub

    Private Sub EnableDisableControlsBasedOnPRNumber()
        Dim areControlsEnabled As Boolean = Not String.IsNullOrWhiteSpace(txtPRNumber.Text)
        txtArticle.Enabled = areControlsEnabled
        ddApprovedBy.Enabled = areControlsEnabled
        btnSave.Enabled = areControlsEnabled
        btnReturn.Enabled = areControlsEnabled
    End Sub

    Private Sub BindNOAItems()
        Dim dt As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_View_NOA_Items] '" & Convert.ToString(Session("Supplier_Id")) & "','" & Convert.ToString(Session("pre_procurement_hdr_id")) & "'", CommandType.Text)
        grdItems.DataSource = dt
        grdItems.DataBind()
    End Sub

    Protected Sub grdNoticeAward_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdNoticeAward, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub ddApproveBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Long = 0 To grdNoticeAward.Rows.Count - 1
            CType(grdNoticeAward.Rows(i).FindControl("linkNoticeAward"), LinkButton).Enabled = True
        Next

    End Sub

    Protected Sub ddApprovedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'ddApprovedBy.Text = ddApprovedBy.SelectedItem.Text
        lblPosition.Text = dtApprovedby.Rows(ddApprovedBy.SelectedIndex - 1)("SignatoryPosition") 'ddApprovedBy.SelectedItem.Value

    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        With Bid
            .pre_procurement_hdr_id = Session("pre_procurement_hdr_id")
            .Article = txtArticle.Text
            .Amount = Session("TotalBidAmount")
            .Supplier_ID = Session("Supplier_Id")
            .withNOA = True
            .NOA_Date = txtAwardDate.Text
            .NOA_ApprovedBy = replaceapostrophe(ddApprovedBy.SelectedItem.Text)
            .NOA_ApprovedBy_Position = replaceapostrophe(lblPosition.Text)
            .withPO = False
            .withNTP = False
            .NTP_Date = txtAwardDate.Text
            .NTP_ApprovedBy = ""
            .NTP_ApprovedBy_Position = ""
            .PR_No = txtPRNumber.Text
            .UserID = Session("@UserName")
        End With

        Dim bidID As Long = Bid.save()

        If grdNoticeAward.SelectedDataKey("project_name") <> txtArticle.Text Then
            '=-= AUDIT TRAIL 11-12-2015
            With AuditTrail
                .TableName = "AMS.Bid_Information"
                .RowId = bidID
                .Operation = "EDIT"
                .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                .PerformedBy = Session("@UserName")
                .FieldName = "Article"
                .OldValue = grdNoticeAward.SelectedDataKey("project_name")
                .NewValue = txtArticle.Text
                .save()
            End With
        End If

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PR_withWinner] WHERE pre_procurement_hdr_id = '" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)
        For x As Long = 0 To dt.Rows.Count - 1
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET withWinner = 1 WHERE prhdr_id = '" & dt.Rows(x)("prhdr_id") & "'", CommandType.Text)
        Next

        objDerived.GetRecords("UPDATE AMS.pre_procurement SET PreparedBy = '" & ddPreparedBy.SelectedItem.Text & "', PreparedPos = '" & replaceapostrophe(lblPreparedPos.Text) & "' WHERE pre_procurement_hdr_id = '" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


        dtNoticeAward = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeOfAward]", CommandType.Text)
        If dtNoticeAward.Rows.Count < 5 Then
            dtNoticeAward.Merge(CreateTable1(5 - dtNoticeAward.Rows.Count))
        End If
        grdNoticeAward.DataSource = dtNoticeAward
        grdNoticeAward.DataBind()

        grdItems.DataSource = Nothing
        grdItems.DataBind()


        txtArticle.Enabled = False
        ddApprovedBy.Enabled = False
        btnNOA.Enabled = True
        'btnResolution.Enabled = True
        btnSave.Enabled = False
        btnPreviewBACResolution.Enabled = True

        btnReturn.Enabled = False

    End Sub

    Protected Sub btnNOA_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "BID"

        Dim url As String = "rpt_NOA.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        'Me.Page.Response.Redirect("~/bidding/rpt_notice_of_award.aspx")
    End Sub

    Protected Sub btnPreviewBACResolution_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If grdNoticeAward.SelectedIndex >= 0 Then
            Dim pre_procurement_hdr_id As String = grdNoticeAward.SelectedDataKey("pre_procurement_hdr_id").ToString()
            Dim supplierId As String = grdNoticeAward.SelectedDataKey("Supplier_Id").ToString()
            Dim projectName As String = grdNoticeAward.SelectedDataKey("project_name").ToString()
            Dim totalBidAmount As String = grdNoticeAward.SelectedDataKey("TotalBidAmount").ToString()

            Dim url As String = String.Format("BACResolution_Report.aspx?pre_procurement_hdr_id={0}&supplierId={1}&projectName={2}&totalBidAmount={3}",
                                           pre_procurement_hdr_id, supplierId, projectName, totalBidAmount)

            Response.Redirect(url)
        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No record selected for preview.")
        End If
    End Sub



    'Protected Sub btnResolution_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim url As String = "rpt_BACResolution.aspx?"
    '    Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100');"
    '    ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    '    'Me.Page.Response.Redirect("~/bidding/rpt_resulotion_recommending_award.aspx")
    'End Sub

    Protected Sub ddPreparedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'ddPreparedBy.Text = ddPreparedBy.SelectedItem.Text
        lblPreparedPos.Text = dtPreparedBy.Rows(ddPreparedBy.SelectedIndex - 1)("Position_desc") 'ddPreparedBy.SelectedItem.Value 'Position_desc
    End Sub
    Protected Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Try
            objDerived.GetRecords("UPDATE [AMS].[pre_procurement] SET [resolution_number] = 0 WHERE pre_procurement_hdr_id = '" & grdNoticeAward.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully returned.")

            txtPRNumber.Text = ""
            txtArticle.Text = ""

            dtNoticeAward = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeOfAward]", CommandType.Text)
            If dtNoticeAward.Rows.Count < 5 Then
                dtNoticeAward.Merge(CreateTable1(5 - dtNoticeAward.Rows.Count))
            End If
            grdNoticeAward.DataSource = dtNoticeAward
            grdNoticeAward.DataBind()

            grdItems.DataSource = Nothing
            grdItems.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
        End Try
    End Sub
End Class
