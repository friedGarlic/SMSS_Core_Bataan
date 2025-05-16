Imports System.Data

Partial Class bidding_RFQ
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal

    Private Property dtRFQ As DataTable
        Get
            Return CType(Session("dtRFQ"), DataTable)
        End Get
        Set(value As DataTable)
            Session("dtRFQ") = value
        End Set
    End Property

    Private Sub Reports_and_Query_RFQ_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            dtRFQ = objDerived.GetDataTable("EXEC [AMS].[sp_RFQ]", CommandType.Text)
            grdRFQ.DataSource = dtRFQ
            grdRFQ.DataBind()
        End If

        txtSearchPR.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
    End Sub

    Protected Sub grdRFQ_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdRFQ.PageIndexChanging
        grdRFQ.DataSource = dtRFQ
        grdRFQ.PageIndex = e.NewPageIndex
        grdRFQ.DataBind()


    End Sub


    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs)

    End Sub
    Protected Sub grdRFQ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdRFQ.SelectedIndexChanged
        Session("prhdr_id") = grdRFQ.SelectedDataKey("prhdr_id")
        Session("isRecanvass") = grdRFQ.SelectedDataKey("isRecanvass")
        Session("Page") = "RQ"
        Session("Report") = "RFQ"

        'Me.Page.Response.Redirect("~/Reports and Query/rpt_RFQ.aspx")
        Me.Page.Response.Redirect("~/MainReports/Canvass_Reports.aspx")
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim myview As DataView
        myview = dtRFQ.DefaultView
        myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearchPR.Text) & "%'"
        grdRFQ.DataSource = myview
        grdRFQ.DataBind()

    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
End Class
