
Imports System.Data

Partial Class Reports_and_Query_NoAIR
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal

    Private Property dtNoAIR() As DataTable
        Get
            Return CType(Session("dtNoAIR"), DataTable)
        End Get
        Set(value As DataTable)
            Session("dtNoAIR") = value
        End Set
    End Property



    Private Sub Reports_and_Query_NoAIR_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            dtNoAIR = objDerived.GetDataTable("EXEC [AMS].[sp_NoAIRList]", CommandType.Text)
            grdNoAIR.DataSource = dtNoAIR
            grdNoAIR.DataBind()

            txtSearch.Text = ""

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtNoAIR.DefaultView

        If ddSearchOption.SelectedIndex = 0 Then
            myview.RowFilter = "PO_No like '%" & txtSearch.Text & "%'"
        ElseIf ddSearchOption.SelectedIndex = 1 Then
            myview.RowFilter = "pr_no like '%" & txtSearch.Text & "%'"
        End If

        grdNoAIR.DataSource = myview
        grdNoAIR.DataBind()

    End Sub
    Protected Sub grdNoAIR_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdNoAIR.PageIndexChanging
        grdNoAIR.DataSource = dtNoAIR
        grdNoAIR.DataBind()
        grdNoAIR.PageIndex = e.NewPageIndex

    End Sub
End Class
