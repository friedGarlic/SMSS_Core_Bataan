
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class Reports_and_Query_t_bid_form_report
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
#Region "Property"

    Private Property pBacCert() As DataTable
        Get
            Return CType(Session("pBacCert"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBacCert") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pBacCert = objDerived.GetDataTable("SELECT pre_procurement_hdr_id, project_location, project_reference_no, project_name, ABC, opening_date FROM AMS.pre_procurement", CommandType.Text)
        gvopen.DataSource = pBacCert
        gvopen.DataBind()
    End Sub
    Protected Sub gvopen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvopen.SelectedIndexChanged
        Session("pre_procurement_hdr_id") = gvopen.SelectedDataKey("pre_procurement_hdr_id")
        Dim url As String = "rpt_BidForm.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub

#End Region
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
