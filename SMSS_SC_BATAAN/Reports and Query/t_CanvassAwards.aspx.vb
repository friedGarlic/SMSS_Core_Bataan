Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Reports_and_Query_t_CanvassAwards
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule

    Private Property dtAbstract() As DataTable
        Get
            Return CType(Session("dtAbstract"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAbstract") = value
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'obj.GetAccessRight(Me.Session("@UserName"), Page)
            'If obj.HasAccess = False Then
            '    Me.Page.Response.Redirect("../UnauthorizedAccess.aspx")
            'End If

            '================ DEFAULT VIEW ================
            btnTab1.CssClass = "TabButton_Active"
            btnTab2.CssClass = "TabButton_InActive"

            dtResolution = objDerived.GetDataTable("EXEC [AMS].[sp_RQ_CanvassAwards] '" & 2 & "'", CommandType.Text)
            grdResolution.DataSource = dtResolution
            grdResolution.DataBind()

            Me.mvTabs.SetActiveView(Me.vwTab1)

        End If

        txtSearchNOA.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchNOA.ClientID & "')")
        txtSearchResolution.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchResolution.ClientID & "')")

    End Sub


    Private Sub btnTab1_Click(sender As Object, e As EventArgs) Handles btnTab1.Click
        btnTab1.CssClass = "TabButton_Active"
        btnTab2.CssClass = "TabButton_InActive"

        dtResolution = objDerived.GetDataTable("EXEC [AMS].[sp_RQ_CanvassAwards] '" & 2 & "'", CommandType.Text)
        grdResolution.DataSource = dtResolution
        grdResolution.DataBind()

        Me.mvTabs.SetActiveView(Me.vwTab1)
    End Sub

    Private Sub btnTab2_Click(sender As Object, e As EventArgs) Handles btnTab2.Click
        btnTab1.CssClass = "TabButton_InActive"
        btnTab2.CssClass = "TabButton_Active"

        dtAbstract = objDerived.GetDataTable("EXEC [AMS].[sp_RQ_CanvassAwards] '" & 1 & "'", CommandType.Text)
        grdAbstract.DataSource = dtAbstract
        grdAbstract.DataBind()

        Me.mvTabs.SetActiveView(Me.vwTab2)
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnSearchNOA_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtAbstract.DefaultView

        If ddSearchNOA.SelectedValue = 1 Then
            myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearchNOA.Text.ToString) & "%'"
        Else
            myview.RowFilter = "SuppName like '%" & replaceapostrophe(txtSearchNOA.Text.ToString) & "%'"
        End If

        grdAbstract.DataSource = myview
        grdAbstract.DataBind()

    End Sub

    Protected Sub btnSearchResolution_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtResolution.DefaultView

        If ddSearchResolution.SelectedValue = 1 Then
            myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearchResolution.Text) & "%'"
        Else
            myview.RowFilter = "SuppName like '%" & replaceapostrophe(txtSearchResolution.Text) & "%'"
        End If

        grdResolution.DataSource = myview
        grdResolution.DataBind()
    End Sub

    Protected Sub grdAbstract_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

        grdAbstract.DataSource = dtAbstract
        grdAbstract.PageIndex = e.NewPageIndex
        grdAbstract.DataBind()

    End Sub

    Protected Sub lnkView_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub grdAbstract_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Session("Hdr_ID") = grdAbstract.SelectedDataKey("Hdr_ID")
            Session("prhdr_id") = grdAbstract.SelectedDataKey("prhdr_id")
            Session("Supplier_ID") = grdAbstract.SelectedDataKey("Supplier_ID")
            Session("Award") = "NOA"
            Session("Page") = "RQ"

            Me.Page.Response.Redirect("../bidding/rpt_CanvassAwards.aspx")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Contact system administrator.")
        End Try

    End Sub


    'Protected Sub btnNOA_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btnNOA.CssClass = "Clicked"
    '    btnResolution.CssClass = "Initial"

    '    dtAbstract = objDerived.GetDataTable("EXEC [AMS].[sp_RQ_CanvassAwards] '" & 1 & "'", CommandType.Text)
    '    If dtAbstract.Rows.Count < 10 Then
    '        dtAbstract.Merge(DataTable1(10 - (dtAbstract.Rows.Count)))
    '    End If
    '    grdAbstract.DataSource = dtAbstract
    '    grdAbstract.DataBind()

    '    Me.mvAwards.SetActiveView(Me.vwNOA)
    'End Sub

    'Protected Sub btnResolution_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btnNOA.CssClass = "Initial"
    '    btnResolution.CssClass = "Clicked"

    '    dtResolution = objDerived.GetDataTable("EXEC [AMS].[sp_RQ_CanvassAwards] '" & 2 & "'", CommandType.Text)
    '    grdResolution.DataSource = dtResolution
    '    grdResolution.DataBind()

    '    Me.mvAwards.SetActiveView(Me.vwResolution)
    'End Sub

    Protected Sub grdResolution_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdResolution.DataSource = dtResolution
        grdResolution.SelectedIndex = e.NewPageIndex
        grdResolution.DataBind()

    End Sub

    Protected Sub lnkViewReso_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub grdResolution_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Session("Hdr_ID") = grdResolution.SelectedDataKey("Hdr_ID")
            Session("prhdr_id") = grdResolution.SelectedDataKey("prhdr_id")
            Session("Award") = "RRA"
            Session("Page") = "RQ"

            Me.Page.Response.Redirect("../bidding/rpt_CanvassAwards.aspx")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Contact system administrator.")
        End Try

    End Sub

    Public Function DataTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("Total_Amt", GetType(Decimal))
        dt.Columns.Add("Hdr_ID", GetType(Long))
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("Supplier_Id", GetType(Long))
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

    Protected Sub btnBACCert_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

End Class

