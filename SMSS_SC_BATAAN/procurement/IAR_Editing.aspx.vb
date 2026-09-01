Imports System.Data

Partial Class procurement_IAR_Editing
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

    Private Property dtIAR() As DataTable
        Get
            Return CType(Session("dtIAR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtIAR") = value
        End Set
    End Property
    Private Property dtItemList() As DataTable
        Get
            Return CType(Session("dtItemList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItemList") = value
        End Set
    End Property

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'obj.GetAccessRight(Me.Session("@UserName"), Page)
            'If obj.HasAccess = False Then
            '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            'End If

            dtIAR = objDerived.GetDataTable("EXEC [AMS].[sp_Edit_IARList]", CommandType.Text)
            grdIAR.DataSource = dtIAR
            grdIAR.DataBind()

            grdIAR_Items.DataSource = Nothing
            grdIAR_Items.DataBind()

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
    End Sub

    Protected Sub grdIAR_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdIAR.PageIndexChanging
        grdIAR.PageIndex = e.NewPageIndex
        grdIAR.DataSource = dtIAR
        grdIAR.DataBind()
        grdIAR.SelectedIndex = -1
    End Sub


    Protected Sub grdIAR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdIAR.SelectedIndexChanged
        Try
            grdIAR.DataSource = dtIAR
            grdIAR.DataBind()

            For i As Integer = 0 To grdIAR.Rows.Count - 1
                CType(grdIAR.Rows(i).FindControl("txtInvoiceDate"), TextBox).Enabled = False
            Next

            CType(grdIAR.SelectedRow.FindControl("txtInvoiceDate"), TextBox).Enabled = True

            dtItemList = objDerived.GetDataTable("SELECT DISTINCT AMS.AIR_Hdr.AIRHdr_ID, AMS.AIR_Dtl.AIRDtl_ID, AMS.AIR_Dtl.Item_ID, dbo.m_item.Item_Desc, AMS.AIR_Dtl.Qty, " &
                                            " AMS.AIR_Dtl.Cost, AMS.m_Unit.Description AS Unit, AMS.AIR_Hdr.POHdr_ID, AMS.Stock.StockID, AMS.TbStock_Ledger.StockLedger_ID " &
                                            " From AMS.AIR_Dtl INNER Join dbo.m_item ON AMS.AIR_Dtl.Item_ID = dbo.m_item.Item_ID INNER Join " &
                                            " AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID INNER JOIN " &
                                            " AMS.AIR_Hdr On AMS.AIR_Dtl.AIRHdr_ID = AMS.AIR_Hdr.AIRHdr_ID INNER Join " &
                                            " AMS.Stock ON AMS.AIR_Hdr.POHdr_ID = AMS.Stock.POHdr_ID AND AMS.AIR_Dtl.Item_ID = AMS.Stock.Item_ID INNER JOIN " &
                                            " AMS.TbStock_Ledger ON AMS.Stock.StockID = AMS.TbStock_Ledger.StockID AND AMS.AIR_Dtl.Item_ID = AMS.TbStock_Ledger.Item_ID " &
                                            " WHERE	AMS.AIR_Hdr.AIRHdr_ID  = '" & grdIAR.SelectedDataKey("AIRHdr_ID") & "' ORDER BY dbo.m_item.Item_Desc", CommandType.Text)

            grdIAR_Items.DataSource = dtItemList
            grdIAR_Items.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtIAR.DefaultView
        myview.RowFilter = "Invoice_No like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%'"
        grdIAR.DataSource = myview
        grdIAR.DataBind()

    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            objDerived.Execute("UPDATE AMS.AIR_Hdr SET Invoice_date = '" & CType(grdIAR.SelectedRow.FindControl("txtInvoiceDate"), TextBox).Text & "' WHERE AIRHdr_ID = '" & grdIAR.SelectedDataKey("AIRHdr_ID") & "'", CommandType.Text)

            For i As Integer = 0 To grdIAR_Items.Rows.Count - 1
                Dim Qty As Decimal = CType(CType(grdIAR_Items.Rows(i).FindControl("txtQty"), TextBox).Text, Decimal)
                If Qty > CType(CType(grdIAR_Items.Rows(i).FindControl("lblQty"), Label).Text, Decimal) Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Qty exceed from delivered qty of an item.")
                    Exit Sub
                End If

                objDerived.Execute("UPDATE [AMS].[AIR_Dtl] SET [Qty] = '" & Qty & "' WHERE [ARDtl_ID] = '" & dtItemList.Rows(i)("AIRDtl_ID") & "'", CommandType.Text)
                objDerived.Execute("UPDATE [AMS].[Stock] SET [Qty] = '" & Qty & "',[Balance] = '" & Qty & "' WHERE [StockID] = '" & dtItemList.Rows(i)("StockID") & "'", CommandType.Text)
                objDerived.Execute("UPDATE [AMS].[TbStock_Ledger] SET [DebitQty] = '" & Qty & "' WHERE [StockLedger_ID] = '" & dtItemList.Rows(i)("StockLedger_ID") & "'", CommandType.Text)

            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, pls contact system admin.")

        End Try
    End Sub
End Class
