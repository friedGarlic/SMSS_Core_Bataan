Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class procurement_t_PR_Tracking
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal

    Private Property dtPR() As DataTable
        Get
            Return CType(Session("dtPR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPR") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            dtPR = objDerived.GetDataTable("EXEC [AMS].[sp_PR_Tracking]", CommandType.Text)
            grdPurchaseRequest.DataSource = dtPR
            grdPurchaseRequest.DataBind()
        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

    End Sub

    Protected Sub grdPurchaseRequest_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdPurchaseRequest.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_PR_Tracking]", CommandType.Text)
        grdPurchaseRequest.PageIndex = e.NewPageIndex
        grdPurchaseRequest.DataBind()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtPR.DefaultView
        myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        grdPurchaseRequest.DataSource = myview
        grdPurchaseRequest.DataBind()
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub drpStatus_SelectedIndexChanged(sender As Object, e As EventArgs)
        dtPR = objDerived.GetDataTable("EXEC [AMS].[sp_PR_Tracking_Search] '" & drpStatus.SelectedItem.Text & "'", CommandType.Text)
        grdPurchaseRequest.DataSource = dtPR
        grdPurchaseRequest.DataBind()
    End Sub
End Class
