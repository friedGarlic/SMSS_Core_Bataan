Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Reports_and_Query_t_purchase_request
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private prhdr As New t_purchase_request_hdr

#Region "Property"

    Private Property pPurchaseRequest() As DataTable
        Get
            Return CType(Session("pPurchaseRequest"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchaseRequest") = value
        End Set
    End Property

    Private Property popentrans() As DataTable
        Get
            Return CType(Session("popentrans"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("popentrans") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Me.drpTransType.DataSource = objDerived.GetRecords("SELECT TOP (100) PERCENT transaction_id, Description FROM AMS.Transaction_type ORDER BY Description", CommandType.Text)
            Me.drpTransType.DataTextField = "Description"
            Me.drpTransType.DataValueField = "transaction_id"
            Me.drpTransType.DataBind()


            pPurchaseRequest = objDerived.GetDataTable("EXEC [AMS].[sp_RQ_PRSearch]", CommandType.Text)
            gvopen.DataSource = pPurchaseRequest
            gvopen.DataBind()

            Me.txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
            Me.txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")

            RadioButtonList1.SelectedIndex = 0
            LoadrbChoice()

            txtPRNumber.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchPRNo.ClientID & "')")
            txtdatefrom.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")
            txtdateto.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")

        End If
    End Sub

    Private Sub gvopen_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvopen.PageIndexChanging
        gvopen.DataSource = pPurchaseRequest
        gvopen.PageIndex = e.NewPageIndex
        gvopen.DataBind()

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        LoadrbChoice()
    End Sub

    Protected Sub LoadrbChoice()
        If RadioButtonList1.SelectedIndex = 0 Then
            '======== PR Number ========
            Me.MultiView1.SetActiveView(Me.View1)
            txtPRNumber.Text = ""

        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            '======== Date Duration ========
            Me.MultiView1.SetActiveView(Me.View2)
            txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
            txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")

        ElseIf RadioButtonList1.SelectedIndex = 2 Then
            '======== Allotment Type ========
            Me.MultiView1.SetActiveView(Me.View3)


        End If
    End Sub

    Protected Sub btnSearchPRNo_Click(sender As Object, e As EventArgs) Handles btnSearchPRNo.Click

        Dim myview As DataView
        myview = pPurchaseRequest.DefaultView
        myview.RowFilter = "pr_no like '%" & txtPRNumber.Text & "%'"
        gvopen.DataSource = myview
        gvopen.DataBind()

    End Sub
    Protected Sub btnTransType_Click(sender As Object, e As EventArgs) Handles btnTransType.Click
        Dim myview As DataView
        myview = pPurchaseRequest.DefaultView
        myview.RowFilter = "Transaction_type = '" & drpTransType.SelectedItem.Value & "'"
        gvopen.DataSource = myview
        gvopen.DataBind()

    End Sub

    Protected Sub btnByDate_Click(sender As Object, e As EventArgs) Handles btnByDate.Click
        Dim myview As DataView
        myview = pPurchaseRequest.DefaultView
        myview.RowFilter = "PR_Date >= '" & (txtdatefrom.Text) & "' AND PR_Date <= '" & (txtdateto.Text) & "'"
        gvopen.DataSource = myview
        gvopen.DataBind()

    End Sub

    Protected Sub gvopen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvopen.SelectedIndexChanged
        Session("Page") = "RQ"
        Session("Report") = "PR"
        Session("prhdr_id") = gvopen.SelectedDataKey("prhdr_id")

        'Me.Page.Response.Redirect("~/procurement/rpt_purchase_request.aspx")
        Me.Page.Response.Redirect("~/MainReports/Procurement_Reports.aspx")
    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)

    End Sub


End Class
