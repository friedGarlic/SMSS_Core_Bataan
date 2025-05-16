Imports System.Data

Partial Class bidding_t_ITB_report
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal

    Private Property dtITB() As DataTable
        Get
            Return CType(Session("dtITB"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtITB") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            dtITB = objDerived.GetDataTable("SELECT * FROM [AMS].[ITB_Hdr] A INNER JOIN [AMS].[ITB_Dtl] B ON A.ITB_Hdr_ID = B.ITB_Hdr_ID ORDER BY withPreBidConference", CommandType.Text)
            grdITB.DataSource = dtITB
            grdITB.DataBind()
        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event, '" & btnSearch.ClientID & "')")
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Try
            Dim myview As DataView
            myview = dtITB.DefaultView

            If drpSearch.SelectedItem.Value = 1 Then
                myview.RowFilter = "ITB_No like '%" & txtSearch.Text & "%'"
            ElseIf drpSearch.SelectedItem.Value = 2 Then
                myview.RowFilter = "Project_name like '%" & txtSearch.Text & "%'"
            End If

            grdITB.DataSource = myview
            grdITB.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdITB_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdITB.SelectedIndexChanged
        Session("Page") = "ITB"
        Session("Back") = "Report-ITB"

        If grdITB.SelectedDataKey("withPreBidConference") = 0 Then
            Session("Report") = "ITB w/o PreBid"
        ElseIf grdITB.SelectedDataKey("withPreBidConference") = 1 Then
            Session("Report") = "ITB with PreBid"
        End If

        Session("ITB_Hdr_ID") = grdITB.SelectedDataKey("ITB_Hdr_ID")

        Dim url As String = "BiddingReports.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub

    Protected Sub grdITB_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles grdITB.PageIndexChanging
        grdITB.PageIndex = e.NewPageIndex
        grdITB.DataSource = dtITB
        grdITB.DataBind()
    End Sub

End Class
