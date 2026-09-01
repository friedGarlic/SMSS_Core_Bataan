Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_Bidding_Infra_t_Infra_Notices
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private Bid As New Bid_information

#Region "property"
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
#End Region
#Region "DataTable"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("ITB", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("project_name", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("Total_Amount", GetType(Decimal))
        dt.Columns.Add("IsVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = DBNull.Value
            dr("ITB") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("project_name") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("Total_Amount") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            btnNOA.CssClass = "Clicked"
            btnNTP.CssClass = "Initial"

            LoadActiveView()
        End If

        txtSearch_NOA.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_NOA.ClientID & "')")
        txtSearch_NTP.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch_NTP.ClientID & "')")
    End Sub

    Protected Sub LoadActiveView()
        txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

        If btnNOA.CssClass = "Clicked" Then
            Me.mvNotice.SetActiveView(Me.vwNOA)

            dtNOA = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Notice] 0,0,0", CommandType.Text)
            If dtNOA.Rows.Count < 10 Then
                dtNOA.Merge(CreateTable1(10 - dtNOA.Rows.Count))
            End If
            grdNOA.DataSource = dtNOA
            grdNOA.DataBind()

            ddApprovedBy_NOA.DataSource = objDerived.GetDataTable("SELECT DISTINCT empid, UPPER(full_name) AS full_name, UPPER(position_desc) AS position_desc FROM HRMS.view_signatory WHERE deptid IN (1, 3, 8, 104) AND division_key = 86 AND isDeptHead = 'yes' ORDER BY full_name", CommandType.Text)
            ddApprovedBy_NOA.DataTextField = ("full_name")
            ddApprovedBy_NOA.DataValueField = ("empid")
            ddApprovedBy_NOA.DataBind()
            ddApprovedBy_NOA.Items.Insert(0, "Select")

            btnSave_NOA.Enabled = False
            btnPreview_NOA.Enabled = False

        ElseIf btnNTP.CssClass = "Clicked" Then
            Me.mvNotice.SetActiveView(Me.vwNTP)

            dtNTP = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Notice] 1,1,0", CommandType.Text)
            If dtNTP.Rows.Count < 10 Then
                dtNTP.Merge(CreateTable1(10 - dtNTP.Rows.Count))
            End If
            grdNTP.DataSource = dtNTP
            grdNTP.DataBind()

            ddApprovedBy_NTP.DataSource = objDerived.GetDataTable("SELECT DISTINCT empid, UPPER(full_name) AS full_name, UPPER(position_desc) AS position_desc FROM HRMS.view_signatory WHERE deptid IN (1, 3, 8, 104) AND division_key = 86 AND isDeptHead = 'yes' ORDER BY full_name", CommandType.Text)
            ddApprovedBy_NTP.DataTextField = ("full_name")
            ddApprovedBy_NTP.DataValueField = ("empid")
            ddApprovedBy_NTP.DataBind()
            ddApprovedBy_NTP.Items.Insert(0, "Select")

        End If

    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnNOA_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnNOA.CssClass = "Clicked"
        btnNTP.CssClass = "Initial"

        LoadActiveView()
    End Sub

    Protected Sub btnNTP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnNOA.CssClass = "Initial"
        btnNTP.CssClass = "Clicked"

        LoadActiveView()
    End Sub

    Protected Sub grdNOA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Infra_Hdr_ID") = grdNOA.SelectedDataKey("Infra_Hdr_ID")
        btnSave_NOA.Enabled = True
    End Sub

    Protected Sub grdNOA_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdNOA.DataSource = dtNOA
        grdNOA.SelectedIndex = e.NewPageIndex
        grdNOA.DataBind()

    End Sub

    Protected Sub btnSearch_NOA_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtNOA.DefaultView

        If ddSearch_NOA.SelectedItem.Text = "PR Number" Then
            myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearch_NOA.Text) & "%'"
        ElseIf ddSearch_NOA.SelectedItem.Text = "Project Name" Then
            myview.RowFilter = "project_name like '%" & replaceapostrophe(txtSearch_NOA.Text) & "%'"
        ElseIf ddSearch_NOA.SelectedItem.Text = "ITB Number" Then
            myview.RowFilter = "ITBNumb like '%" & replaceapostrophe(txtSearch_NOA.Text) & "%'"
        End If

        grdNOA.DataSource = myview
        grdNOA.DataBind()
    End Sub

    Protected Sub btnSave_NOA_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If ddApprovedBy_NOA.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select approved by signatory.")
            Else

                With Bid
                    .pre_procurement_hdr_id = grdNOA.SelectedDataKey("pre_procurement_hdr_id")
                    .Article = grdNOA.SelectedDataKey("project_name")
                    .Amount = grdNOA.SelectedDataKey("Total_Amount")
                    .Supplier_ID = grdNOA.SelectedDataKey("Supplier_ID")
                    .withNOA = True
                    .NOA_Date = txtDate.Text
                    .NOA_ApprovedBy = ddApprovedBy_NOA.SelectedItem.Text
                    .NOA_ApprovedBy_Position = objDerived.GetValue("SELECT DISTINCT UPPER(position_desc) AS position_desc FROM HRMS.view_signatory WHERE empid = '" & ddApprovedBy_NOA.SelectedItem.Value & "'", CommandType.Text)
                    .withPO = False
                    .withNTP = False
                    .NTP_Date = "1/1/1900"
                    .NTP_ApprovedBy = ""
                    .NTP_ApprovedBy_Position = ""
                    .PR_No = grdNOA.SelectedDataKey("pr_no")
                    .UserID = Session("@UserName")
                    .save()
                End With

                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET withWinner = 1 WHERE prhdr_id = '" & grdNOA.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.pre_procurement SET withNOA = 1, dateNOA = '" & txtDate.Text & "', NOA_Approveby = '" & ddApprovedBy_NOA.SelectedItem.Text & "' WHERE pre_procurement_hdr_id = '" & grdNOA.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.tb_Infra_Hdr SET withNOA = 1, NOA_ApprovedBy = '" & ddApprovedBy_NOA.SelectedItem.Value & "', NOA_Date = '" & txtDate.Text & "' WHERE Infra_Hdr_ID = '" & grdNOA.SelectedDataKey("Infra_Hdr_ID") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                LoadActiveView()

                btnPreview_NOA.Enabled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPreview_NOA_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Notice") = "NOA"
        Me.Page.Response.Redirect("~/bidding/Bidding_Infra/rpt_Infra_Notice.aspx")
    End Sub

    Protected Sub btnSearch_NTP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtNTP.DefaultView

        If ddSearch_NTP.SelectedItem.Text = "PR Number" Then
            myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearch_NTP.Text) & "%'"
        ElseIf ddSearch_NTP.SelectedItem.Text = "Project Name" Then
            myview.RowFilter = "project_name like '%" & replaceapostrophe(txtSearch_NTP.Text) & "%'"
        ElseIf ddSearch_NTP.SelectedItem.Text = "ITB Number" Then
            myview.RowFilter = "ITBNumb like '%" & replaceapostrophe(txtSearch_NTP.Text) & "%'"
        End If

        grdNTP.DataSource = myview
        grdNTP.DataBind()
    End Sub

    Protected Sub grdNTP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Infra_Hdr_ID") = grdNTP.SelectedDataKey("Infra_Hdr_ID")
        btnSave_NTP.Enabled = True
    End Sub

    Protected Sub btnSave_NTP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddApprovedBy_NTP.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select approved by signatory.")

        Else
            Try
                objDerived.GetRecords("UPDATE AMS.tb_Infra_Hdr SET withNTP = 1, NTP_ApprovedBy = '" & ddApprovedBy_NTP.SelectedItem.Value & "', NTP_Date = '" & txtDate.Text & "' WHERE Infra_Hdr_ID = '" & grdNTP.SelectedDataKey("Infra_Hdr_ID") & "'", CommandType.Text)

                Dim Position As String = objDerived.GetValue("SELECT DISTINCT UPPER(position_desc) AS position_desc FROM HRMS.view_signatory WHERE empid = '" & ddApprovedBy_NTP.SelectedItem.Value & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.Bid_Information SET withNTP = 1, NTP_Date = '" & txtDate.Text & "', NTP_ApprovedBy = '" & ddApprovedBy_NTP.SelectedItem.Text & "', NTP_ApprovedBy_Position = '" & replaceapostrophe(Position) & "' WHERE pre_procurement_hdr_id = '" & grdNTP.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                btnPreview_NTP.Enabled = True
                btnSave_NTP.Enabled = False

                LoadActiveView()

            Catch ex As Exception
            End Try
        End If

    End Sub

    Protected Sub btnPreview_NTP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Notice") = "NTP"
        Me.Page.Response.Redirect("~/bidding/Bidding_Infra/rpt_Infra_Notice.aspx")
    End Sub

End Class
