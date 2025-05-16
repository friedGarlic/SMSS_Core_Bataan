Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class Reports_and_Query_Bac_CertificateReport
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


#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pBacCert = objDerived.GetDataTable("EXEC [AMS].[sp_rpt_BACCertification_report]", CommandType.Text)
        gvopen.DataSource = pBacCert
        gvopen.DataBind()
    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)

    End Sub
    Protected Sub gvopen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvopen.SelectedIndexChanged
        Session("obr_evaluation_hdr_id") = gvopen.SelectedDataKey("obr_evaluation_hdr_id")
        'txtDateFrom.Text = Date.Today.ToString("MM/dd/yyyy")
        'txtDateTo.Text = Date.Today.ToString("MM/dd/yyyy")
        'txtDateIssued.Text = Date.Today.ToString("MM/dd/yyyy")
        'ModalPopupExtendepopup.Show()

        Try
            'objDerived.GetRecords("UPDATE [AMS].[obr_evaluation_hdr] SET [BACCert_DateFrom] = '" & txtDateFrom.Text & "',[BACCert_DateTo] = '" & txtDateTo.Text & "',[BACCert_Issued] = '" & txtDateIssued.Text & "' WHERE [obr_evaluation_hdr_id] = '" & Session("obr_evaluation_hdr_id") & "'", CommandType.Text)

            Dim url As String = "rpt_BAC_Certification.aspx?"
            Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnBACCertSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            objDerived.GetRecords("UPDATE [AMS].[obr_evaluation_hdr] SET [BACCert_DateFrom] = '" & txtDateFrom.Text & "',[BACCert_DateTo] = '" & txtDateTo.Text & "',[BACCert_Issued] = '" & txtDateIssued.Text & "' WHERE [obr_evaluation_hdr_id] = '" & Session("obr_evaluation_hdr_id") & "'", CommandType.Text)

            Dim url As String = "rpt_BAC_Certification.aspx?"
            Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        Catch ex As Exception

        End Try
    End Sub

End Class
