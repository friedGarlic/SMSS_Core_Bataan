Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class filemaintenance_Scrollbar
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions ORDER BY RC_NAME", CommandType.Text)
        grdSB.DataSource = dt
        grdSB.DataBind()
    End Sub

    Protected Sub grdBAC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSB.SelectedIndexChanged
        Try
            Label1.Text = grdSB.SelectedDataKey("RC_Name")
            grdSB.SelectedRow.Focus()

        Catch ex As Exception
        End Try




    End Sub
End Class
