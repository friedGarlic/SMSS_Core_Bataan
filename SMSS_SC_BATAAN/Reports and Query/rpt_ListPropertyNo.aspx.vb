Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
'Imports System.Collections.Hashtable
'Imports System.Collections.DictionaryEntrys
'Imports System.Windows.Forms.Control

Partial Class Reports_and_Query_rpt_ListPropertyNo
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private objDerived_rpt As New connectionreport


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ddYear.DataSource = objDerived.GetRecords("SELECT * FROM [AMS].[APP] WHERE STATUS <> 3 ORDER BY [year] DESC ", CommandType.Text)
            ddYear.DataTextField = "year"
            ddYear.DataValueField = "year"
            ddYear.DataBind()

            drpRC.DataSource = objDerived.GetRecords("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
            drpRC.DataTextField = "RC_Name"
            drpRC.DataValueField = "RC_ID"
            drpRC.DataBind()
            drpRC.Items.Insert(0, "Select")

            drpFunction.Items.Clear()
            drpFunction.Items.Insert(0, "Select")

        End If
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Report") = "HexProperty"
        Session("YEAR") = ddYear.SelectedItem.Text
        Session("RC_ID") = drpRC.SelectedItem.Value
        Session("Function_ID") = drpFunction.SelectedItem.Value
        Me.Page.Response.Redirect("~/Reports and Query/rpt_RreportViewer.aspx")
    End Sub

    Private Sub drpRC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpRC.SelectedIndexChanged
        drpFunction.DataSource = objDerived.GetRecords("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & drpRC.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        drpFunction.DataTextField = "Function_Desc"
        drpFunction.DataValueField = "Function_ID"
        drpFunction.DataBind()
        drpFunction.Items.Insert(0, "Select")
    End Sub
End Class
