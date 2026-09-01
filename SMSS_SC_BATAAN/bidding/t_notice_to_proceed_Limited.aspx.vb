Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.DataTable
Imports System.Data.DataRow
Imports System.Data.DataRowCollection
Partial Class bidding_t_notice_to_proceed_Limited
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Dim hdr As New t_purchase_order_hdr
    Dim dtl As New t_purchase_order_dtl
    Dim msg As New MsgeBox


#Region "Funtion"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("project_reference_no", GetType(String))
        dt.Columns.Add("ProjectName", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("Amount", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("Bid_ID", GetType(Long))
        dt.Columns.Add("PR_No", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pre_procurement_hdr_id") = DBNull.Value
            dr("project_reference_no") = DBNull.Value
            dr("ProjectName") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("Supplier_Id") = DBNull.Value
            dr("Amount") = DBNull.Value
            dr("isVisible") = False
            dr("Bid_ID") = 0
            dr("PR_No") = ""
            dr("POHdr_ID") = DBNull.Value
            dt.Rows.Add(dr)

        Next
        Return dt

    End Function
#End Region
#Region "property"
    Private Property pProject() As DataTable
        Get
            Return CType(Session("pProject"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pProject") = value
        End Set
    End Property
    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If

        If Not Page.IsPostBack Then
            txtDateProceed.Text = Date.Today.ToString("MM/dd/yyyy")

            pProject = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeToProceed_Limited]", CommandType.Text)
            If pProject.Rows.Count < 5 Then
                pProject.Merge(CreateTable1(4 - pProject.Rows.Count))
            End If
            grdProceed.DataSource = pProject
            grdProceed.DataBind()

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeOfAward_Signatory]", CommandType.Text)
            ddApprovedBy.DataSource = dt
            ddApprovedBy.DataTextField = ("SignatoryName")
            ddApprovedBy.DataValueField = ("SignatoryPosition")
            ddApprovedBy.DataBind()
            ddApprovedBy.Items.Insert(0, "Select")
        End If
    End Sub

    Protected Sub grdProceed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Bid_ID") = grdProceed.SelectedDataKey("Bid_ID")
        Session("POHdr_ID") = grdProceed.SelectedDataKey("POHdr_ID")
        txtPRNumber.Text = grdProceed.SelectedDataKey("PR_No")

        If Session("Bid_ID") = 0 Then
            btnProceed.Enabled = False
            btnReturn.Enabled = False
        Else
            btnProceed.Enabled = True
            btnReturn.Enabled = True
        End If

    End Sub

    Protected Sub ddApprovedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        lblPosition.Text = ddApprovedBy.SelectedItem.Value
    End Sub

    Protected Sub grdProceed_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdProceed, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdProceed_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pProject = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeToProceed_Limited]", CommandType.Text)
        If pProject.Rows.Count < 5 Then
            pProject.Merge(CreateTable1(5 - pProject.Rows.Count))
        End If
        grdProceed.PageIndex = e.NewPageIndex
        grdProceed.DataSource = pProject
        grdProceed.DataBind()
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function


    Protected Sub btnProceed_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        objDerived.GetRecords("UPDATE AMS.Bid_Information SET withNTP = 1, NTP_Date = '" & txtDateProceed.Text & "', NTP_ApprovedBy = '" & ddApprovedBy.SelectedItem.Text & "', NTP_ApprovedBy_Position = '" & replaceapostrophe(ddApprovedBy.SelectedItem.Value) & "' WHERE Bid_ID = '" & Session("Bid_ID") & "'", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        btnProceed.Enabled = False
        btnPreview.Enabled = True
        btnReturn.Enabled = False
        pProject = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeToProceed_Limited]", CommandType.Text)
        If pProject.Rows.Count < 5 Then
            pProject.Merge(CreateTable1(5 - pProject.Rows.Count))
        End If
        grdProceed.DataSource = pProject
        grdProceed.DataBind()
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "BID"
        Me.Page.Response.Redirect("~/bidding/rpt_notice_to_proceed.aspx")
    End Sub
    Protected Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Try
            objDerived.GetRecords("UPDATE AMS.PO_Hdr SET isApproved = 0 WHERE POHdr_ID = '" & Session("POHdr_ID") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully return.")
            btnProceed.Enabled = False
            btnPreview.Enabled = True

            pProject = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeToProceed_Limited]", CommandType.Text)
            If pProject.Rows.Count < 5 Then
                pProject.Merge(CreateTable1(5 - pProject.Rows.Count))
            End If
            grdProceed.DataSource = pProject
            grdProceed.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
        End Try
    End Sub
End Class
