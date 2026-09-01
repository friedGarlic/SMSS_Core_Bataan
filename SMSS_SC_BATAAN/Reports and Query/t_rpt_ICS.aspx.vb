Imports System.Data

Partial Class Reports_and_Query_t_rpt_ICS
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

    Private Property dtICS() As DataTable
        Get
            Return CType(Session("dtICS"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtICS") = value
        End Set
    End Property

    Private Sub Reports_and_Query_t_rpt_ICS_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            dtICS = objDerived.GetDataTable("SELECT DISTINCT AMS.ICS_Hdr.ICSHdr_ID, AMS.ICS_Hdr.ICS_No, AMS.ICS_Hdr.Date_Acquired, AMS.ICS_Hdr.RIS_No, AMS.ICS_Hdr.IssuedBy, AMS.ICS_Hdr.IssuedTo " &
                                             " FROM	AMS.ICS_Hdr ORDER BY  AMS.ICS_Hdr.Date_Acquired DESC, AMS.ICS_Hdr.RIS_No DESC", CommandType.Text)
            grdICS.DataSource = dtICS
            grdICS.DataBind()

            LoadSearch()

        End If

        txtICSNo.Attributes.Add("onkeypress", "Return fun1(Event,'" & btnSearchICS.ClientID & "')")
        txtRISNo.Attributes.Add("onkeypress", "Return fun1(Event,'" & btnSearchRIS.ClientID & "')")
        txtDateFrom.Attributes.Add("onkeypress", "Return fun1(Event,'" & btnSearchDate.ClientID & "')")
        txtDateTo.Attributes.Add("onkeypress", "Return fun1(Event,'" & btnSearchDate.ClientID & "')")

    End Sub

    Protected Sub LoadSearch()
        If rdSearchCriteria.SelectedItem.Value = 1 Then
            txtICSNo.Text = ""
            Me.mvSearch.SetActiveView(Me.vwICSNo)

        ElseIf rdSearchCriteria.SelectedItem.Value = 2 Then
            txtRISNo.Text = ""
            Me.mvSearch.SetActiveView(Me.vwRISNo)

        ElseIf rdSearchCriteria.SelectedItem.Value = 3 Then
            txtDateFrom.Text = Date.Today.ToString("MM/dd/yyyy")
            txtDateTo.Text = Date.Today.ToString("MM/dd/yyyy")
            Me.mvSearch.SetActiveView(Me.vwDate)

        End If
    End Sub

    Private Sub rdSearchCriteria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdSearchCriteria.SelectedIndexChanged
        LoadSearch()
    End Sub

    Private Sub grdICS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdICS.SelectedIndexChanged
        Session("ICSHdr_ID") = grdICS.SelectedDataKey("ICSHdr_ID")
        Session("Page") = "RQ"
        Session("Report") = "ICS"
        Me.Page.Response.Redirect("~/MainReports/Inventory_Reports.aspx")
    End Sub

    Private Sub grdICS_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdICS.PageIndexChanging
        grdICS.DataSource = dtICS
        grdICS.DataBind()
        grdICS.PageIndex = e.NewPageIndex
    End Sub

    Private Sub btnSearchICS_Click(sender As Object, e As EventArgs) Handles btnSearchICS.Click
        Dim myview As DataView
        myview = dtICS.DefaultView
        myview.RowFilter = "ICS_No like '%" & txtICSNo.Text & "%'"
        grdICS.DataSource = myview
        grdICS.DataBind()
    End Sub

    Private Sub btnSearchRIS_Click(sender As Object, e As EventArgs) Handles btnSearchRIS.Click
        Dim myview As DataView
        myview = dtICS.DefaultView
        myview.RowFilter = "RIS_No like '%" & txtRISNo.Text & "%'"
        grdICS.DataSource = myview
        grdICS.DataBind()
    End Sub

    Private Sub btnSearchDate_Click(sender As Object, e As EventArgs) Handles btnSearchDate.Click
        Dim myview As DataView
        myview = dtICS.DefaultView
        myview.RowFilter = "Date_Acquired >= '" & txtDateFrom.Text & "' AND Date_Acquired <= '" & txtDateTo.Text & "'"
        grdICS.DataSource = myview
        grdICS.DataBind()
    End Sub
End Class
