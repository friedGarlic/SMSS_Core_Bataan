Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class Reports_and_Query_rpt_Disposal_Invitation
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule
    Private Property dtISSP() As DataTable
        Get
            Return CType(Session("dtISSP"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtISSP") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        grdISSP.Columns(7).Visible = True

        dtISSP = objDerived.GetDataTable("EXEC [AMS].[sp_for_ISSP_Report]", CommandType.Text)
        grdISSP.DataSource = dtISSP
        grdISSP.DataBind()

        grdISSP.Columns(7).Visible = False
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim lb As LinkButton = CType(sender, LinkButton)
        Dim isspHdrId As String = lb.CommandArgument.ToString()

        If Not String.IsNullOrEmpty(isspHdrId) Then
            Session("IsspHdr_ID") = isspHdrId
            Dim url As String = "rpt_ISSP_EditContent.aspx?"
            Dim fullURL As String = "var win = window.open('" & url & "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
        Else
            MsgBox("No data selected")
        End If
    End Sub
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lb As LinkButton = CType(sender, LinkButton)
        Dim IIRUPHdr_ID As String = lb.CommandArgument.ToString()

        If Not String.IsNullOrEmpty(IIRUPHdr_ID) Then
            Session("IIRUPHdr_ID") = IIRUPHdr_ID
            Dim url As String = "rpt_Auction_BidForm.aspx?"
            Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
        Else
            MsgBox("No data selected")
        End If
    End Sub
    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lb As LinkButton = CType(sender, LinkButton)
        Dim IIRUPHdr_ID As String = lb.CommandArgument.ToString()

        If Not String.IsNullOrEmpty(IIRUPHdr_ID) Then
            Session("IIRUPHdr_ID") = IIRUPHdr_ID
            Dim url As String = "rpt_NoticePublicBidding.aspx?"
            Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
        Else
            MsgBox("No data selected")
        End If
    End Sub
End Class
