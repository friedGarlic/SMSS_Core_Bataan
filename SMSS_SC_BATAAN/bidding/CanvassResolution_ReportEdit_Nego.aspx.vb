Imports System.Data
Imports System.Drawing

Partial Class bidding_CanvassResolution_ReportEdit_Nego
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

    Private Property dtitems() As DataTable
        Get
            Return CType(Session("dtitems"), DataTable)
        End Get
        Set(value As DataTable)
            Session("dtitems") = value
        End Set
    End Property

    Private Sub bidding_CanvassResolution_ReportEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("EXEC [AMS].[sp_CanvassResolution_ReportEdit] '" & Session("Hdr_ID") & "'", CommandType.Text)

        lblProjectName.Text = dt.Rows(0)("ProjectName")
        lblResolutionNo.Text = dt.Rows(0)("Resolution_No") & ", S-" & dt.Rows(0)("Series")
        lblProjectName2.Text = dt.Rows(0)("ProjectName")

        txtPart1.Text = dt.Rows(0)("WhereAs1") & vbCrLf & vbCrLf & dt.Rows(0)("WhereAs2") & vbCrLf & vbCrLf & dt.Rows(0)("WhereAs3") & vbCrLf & vbCrLf & dt.Rows(0)("WhereAs4") & vbCrLf & vbCrLf & dt.Rows(0)("WhereAs5")

        Dim MOP As Integer = objDerived.GetValue("SELECT B.mode_of_procurement_id FROM [AMS].[m_Canvass_Hdr] AS A INNER JOIN [AMS].[PR_Hdr] AS B ON A.PR_Hdr_ID = B.prhdr_id WHERE A.Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)
        If MOP = 3 Or MOP = 4 Then
            dtitems = objDerived.GetDataTable("EXEC [AMS].[sp_rpt_Abstract_Canvass_Dtl_PR_v2] '" & Session("prhdr_id") & "', '" & Session("Hdr_ID") & "'", CommandType.Text)
            grdAlternative.DataSource = dtitems
            grdAlternative.DataBind()

            mvMOP.SetActiveView(Me.vwAlternative)
        End If

        txtPart2.Text = dt.Rows(0)("WhereAs6") & vbCrLf & vbCrLf & dt.Rows(0)("WhereAs7") & vbCrLf & vbCrLf & dt.Rows(0)("WhereAs8") & vbCrLf & vbCrLf & dt.Rows(0)("WhereAs9") & vbCrLf & vbCrLf & dt.Rows(0)("WhereAs10")

    End Sub

    Private Sub grdItems_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdItems.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(3).Text = dtitems.Rows(0)("Supplier1")
            e.Row.Cells(4).Text = dtitems.Rows(0)("Supplier2")
            e.Row.Cells(5).Text = dtitems.Rows(0)("Supplier3")
        End If
    End Sub

    Private Sub grdAlternative_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdAlternative.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(4).Text = dtitems.Rows(0)("Supplier1")
        End If
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Try
            objDerived.Execute("UPDATE AMS.m_CanvassResolution SET WhereAs1 = '" & replaceapostrophe(txtPart1.Text) & "', WhereAs2 = '" & replaceapostrophe(txtPart2.Text) & "' WHERE CanvassReso_ID = '" & Session("CanvassReso_ID") & "' AND Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)

            Me.Page.Response.Redirect("../bidding/rpt_CanvassAwards_Nego.aspx")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

End Class
