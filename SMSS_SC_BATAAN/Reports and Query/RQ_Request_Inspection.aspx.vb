Imports System.Data


Partial Class Reports_and_Query_RQ_Request_Inspection
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal

    Private Property dtPurchaseOrder() As DataTable
        Get
            Return CType(Session("dtPurchaseOrder"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPurchaseOrder") = value
        End Set
    End Property

    Private Sub Reports_and_Query_RQ_Request_Inspection_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadPage()
        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
    End Sub

    Protected Sub loadPage()
        dtPurchaseOrder = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RequestInspection] ORDER BY PO_Date DESC, PO_No DESC", CommandType.Text)
        grdPO.DataSource = dtPurchaseOrder
        grdPO.DataBind()

        For i As Integer = 0 To grdPO.Rows.Count - 1
            If CType(grdPO.Rows(i).FindControl("txtParticular"), TextBox).Text = "" Then
                CType(grdPO.Rows(i).FindControl("txtParticular"), TextBox).Enabled = True
            Else
                CType(grdPO.Rows(i).FindControl("txtParticular"), TextBox).Enabled = False
            End If
        Next
    End Sub

    Protected Sub grdPO_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdPO.PageIndexChanging
        grdPO.DataSource = dtPurchaseOrder
        grdPO.PageIndex = e.NewPageIndex
        grdPO.DataBind()
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtPurchaseOrder.DefaultView

        If ddSearchBy.SelectedIndex = 0 Then
            myview.RowFilter = "PO_No like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%'"
        ElseIf ddSearchBy.SelectedIndex = 1 Then
            myview.RowFilter = "SuppName like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%'"
        End If

        grdPO.DataSource = myview
        grdPO.DataBind()

        For i As Integer = 0 To grdPO.Rows.Count - 1
            If CType(grdPO.Rows(i).FindControl("txtParticular"), TextBox).Text = "" Then
                CType(grdPO.Rows(i).FindControl("txtParticular"), TextBox).Enabled = True
            Else
                CType(grdPO.Rows(i).FindControl("txtParticular"), TextBox).Enabled = False
            End If
        Next
    End Sub

    Protected Sub grdPO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPO.SelectedIndexChanged
        'Try
        '    Session("POHdr_ID") = grdPO.SelectedDataKey("POHdr_ID")
        '    Session("AIRHdr_ID") = grdPO.SelectedDataKey("AIRHdr_ID")
        '    If CType(grdPO.Rows(grdPO.SelectedIndex).FindControl("txtParticular"), TextBox).Enabled = False Then
        '        Me.Page.Response.Redirect("~/Reports and Query/rpt_RequestInspection.aspx")
        '    Else
        '        Dim Particulars As String = CType(grdPO.Rows(grdPO.SelectedIndex).FindControl("txtParticular"), TextBox).Text
        '        If Particulars = "" Then
        '            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Required: encode particular.")
        '        Else
        '            objDerived.GetRecords("UPDATE [AMS].[PO_Hdr] SET [RI_Particulars] = '" & Particulars & "' WHERE [POHdr_ID] = '" & Session("POHdr_ID") & "'", CommandType.Text)
        '            Me.Page.Response.Redirect("~/Reports and Query/rpt_RequestInspection.aspx")
        '        End If
        '    End If

        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
        'End Try
        'Refactor
        Try
            Session("POHdr_ID") = grdPO.SelectedDataKey("POHdr_ID")
            Session("AIRHdr_ID") = grdPO.SelectedDataKey("AIRHdr_ID")

            Dim txtParticularControl As TextBox = CType(grdPO.Rows(grdPO.SelectedIndex).FindControl("txtParticular"), TextBox)

            If Not txtParticularControl.Enabled Then
                Response.Redirect("~/Reports and Query/rpt_RequestInspection.aspx")
            Else
                Dim Particulars As String = txtParticularControl.Text

                If String.IsNullOrEmpty(Particulars) Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Required: encode particular.")
                Else
                    Dim query As String = "UPDATE [AMS].[PO_Hdr] SET [RI_Particulars] = '" & Particulars & "' WHERE [POHdr_ID] = '" & Session("POHdr_ID") & "'"
                    objDerived.GetRecords(query, CommandType.Text)
                    Response.Redirect("~/Reports and Query/rpt_RequestInspection.aspx")
                End If
            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(UpdatePanel1, "Something went wrong during the process, please contact system admin.")
        End Try
    End Sub
End Class
