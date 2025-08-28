Imports System.Data

Imports System.Data.SqlClient
Partial Class Inventory_NoticeOfDelivery
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private obj As New AccessRule



    Private Property dtPO() As DataTable
        Get
            Return CType(Session("dtPO"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPO") = value
        End Set
    End Property

    Public Function TempTable_POList(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("PO_Date", GetType(Date))
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("POHdr_ID") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("PO_No") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)

        Next
        Return dt

    End Function

    Private Sub procurement_NoticeofDelivery_Load(sender As Object, e As EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then

            dtPO = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeOfDelivery] ", CommandType.Text)
            If dtPO.Rows.Count < 5 Then
                dtPO.Merge(TempTable_POList(4 - dtPO.Rows.Count))
            End If
            grdNOD.DataSource = dtPO
            grdNOD.DataBind()

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)
    End Sub

    Protected Sub grdNOD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If grdNOD.SelectedDataKey("POHdr_ID") = 0 Then

            btnSave.Enabled = False
            btnReturn.Enabled = False
        Else

            Try
                btnReturn.Enabled = True

                ' Get the selected POHdr_ID from the GridView
                Dim poHdrId As Long = Convert.ToInt64(grdNOD.SelectedDataKey("POHdr_ID"))

                ' Check if a Delivery Receipt No. already exists in t_Notice_Of_Delivery
                Dim objReceiptNo As Object = objDerived.GetValue("SELECT TOP 1 DReceiptNo FROM AMS.t_Notice_Of_Delivery WHERE POHdr_ID = '" & poHdrId & "'", CommandType.Text)
                Dim existingReceiptNo As String = If(objReceiptNo IsNot Nothing, objReceiptNo.ToString(), "")

                Dim drNo As String
                If String.IsNullOrEmpty(existingReceiptNo) OrElse existingReceiptNo = "0" Then
                    ' Generate a new Delivery Receipt No using the stored procedure
                    drNo = objDerived.GetValue("EXEC [AMS].[sp_Generate_UniqueDeliveryReceiptNo]", CommandType.Text).ToString()
                Else
                    ' Use existing receipt number
                    drNo = existingReceiptNo
                End If

                AddTrace("Generated or existing DR No: " & drNo)

                ' Assign the Delivery Receipt No. to the textbox
                txtReceiptNo.Text = drNo
                AddTrace("txtReceiptNo: " & txtReceiptNo.Text)




                drpSignatory.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name, position_desc FROM HRMS.view_signatory WHERE deptid = 7 AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                drpSignatory.DataTextField = "Full_Name"
                drpSignatory.DataValueField = "EmpID"
                drpSignatory.DataBind()

                txtDeliveryDate.Text = CType(Date.Today.ToShortDateString, String)

                btnSave.Enabled = True

            Catch ex As Exception
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
            End Try
        End If

    End Sub

    Protected Sub grdNOD_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdNOD, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdNOD_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdNOD.DataSource = dtPO
        grdNOD.PageIndex = e.NewPageIndex
        grdNOD.DataBind()
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtPO.DefaultView

        If drpSearch.SelectedItem.Value = 1 Then
            myview.RowFilter = "PO_No like '%" & replaceapostrophe(txtSearch.Text) & "%'"

        ElseIf drpSearch.SelectedItem.Value = 2 Then
            myview.RowFilter = "SuppName like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        Else

        End If

        grdNOD.DataSource = myview
        grdNOD.DataBind()

    End Sub

    Private Sub DeleteReceivingIfNoDetails()
        Try
            ' Get all orphaned Received_IDs from Tb_Receiving (those not present in Tb_Receiving_Dtl)
            Dim dtOrphaned As DataTable = objDerived.GetDataTable(" SELECT Received_ID FROM AMS.Tb_Receiving WHERE Received_ID NOT IN ( SELECT DISTINCT Received_ID FROM AMS.Tb_Receiving_Dtl WHERE Received_ID IS NOT NULL ) ", CommandType.Text)

            If dtOrphaned.Rows.Count = 0 Then
                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No orphaned Receiving records found.")
                Exit Sub
            End If

            For Each row As DataRow In dtOrphaned.Rows
                Dim orphanID As Long = CLng(row("Received_ID"))
                Dim deleteSql As String = "DELETE FROM AMS.Tb_Receiving WHERE Received_ID = " & orphanID

                ' Execute and confirm rows affected
                Dim rowsAffected As Integer = objDerived.Execute("SET NOCOUNT OFF; " & deleteSql, CommandType.Text)

                If rowsAffected = 0 Then
                    ' log or notify per ID if it failed
                    AddTrace("Failed to delete Received_ID: " & orphanID)
                End If
            Next

            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, dtOrphaned.Rows.Count & " orphaned Receiving record(s) deleted.")

        Catch ex As Exception
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error deleting orphaned Receiving rows: " & ex.Message)
        End Try
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtReceiptNo.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Delivery Receipt No. is required.")
                Return
            End If

            ' Step 1: Insert Notice of Delivery
            Dim insertNOD As String = "INSERT INTO [AMS].[t_Notice_Of_Delivery] " &
            "([POHdr_ID], [DReceiptNo], [DeliveryDate], [ReceivedBy], [isComplete], [SuppName], [RC_Name]) " &
            "VALUES (" &
            grdNOD.SelectedDataKey("POHdr_ID") & ", '" &
            replaceapostrophe(txtReceiptNo.Text) & "', '" &
            txtDeliveryDate.Text & "', '" &
            replaceapostrophe(drpSignatory.SelectedItem.Text) & "', '" &
            drpCompelete.SelectedItem.Value & "', '" &
            replaceapostrophe(grdNOD.SelectedDataKey("SuppName").ToString()) & "', '" &
            replaceapostrophe(grdNOD.SelectedDataKey("RC_Name").ToString()) & "'); " &
            "SELECT CAST(SCOPE_IDENTITY() AS INT);"

            Dim newNOD_ID As Integer = objDerived.GetValue(insertNOD, CommandType.Text)
            Session("NOD_ID") = newNOD_ID

            ' Step 2: Update PO status
            objDerived.Execute("UPDATE [AMS].[PO_Hdr] SET IsNoticeForDelivery = 1 WHERE POHdr_ID = " & grdNOD.SelectedDataKey("POHdr_ID"), CommandType.Text)

            ' Step 3: Create receiving records if delivery is complete
            If drpCompelete.SelectedValue = "1" Then
                ' Insert into Tb_Receiving
                Dim insertReceiving As String = "INSERT INTO AMS.Tb_Receiving " &
                "(Received_Date, ReceivedBY, POHdr_ID, PO_No, Supplier_ID, Status, UserID, TableName) " &
                "VALUES ('" &
                txtDeliveryDate.Text & "', " &
                drpSignatory.SelectedValue & ", " &
                grdNOD.SelectedDataKey("POHdr_ID") & ", '" &
                grdNOD.SelectedDataKey("PO_No") & "', " &
                grdNOD.SelectedDataKey("Supplier_Id") & ", 1, '" &
                Session("@UserName") & "', 'NoticeOfDelivery'); " &
                "SELECT CAST(SCOPE_IDENTITY() AS BIGINT);"

                Dim received_ID As Long = objDerived.GetValue(insertReceiving, CommandType.Text)

                ' Insert into Tb_Receiving_Dtl for each PO item
                Dim dtItems As DataTable = objDerived.GetDataTable(
                "SELECT PODtl_ID, Item_ID, qty, cost FROM AMS.PO_Dtl WHERE POHdr_ID = " & grdNOD.SelectedDataKey("POHdr_ID"),
                CommandType.Text)

                For Each row As DataRow In dtItems.Rows
                    objDerived.Execute(
                    "INSERT INTO AMS.Tb_Receiving_Dtl " &
                    "(Received_ID, Item_ID, PO_Qty, Qty_Received, Qty_Inspecting, Cost, Status, IsDisplayReport, tempReportQuantity) " &
                    "VALUES (" & received_ID & ", " & row("Item_ID") & ", " &
                    row("qty") & ", " & row("qty") & ", " & row("qty") & ", " &
                    row("cost") & ", 1, 1, " & row("qty") & ")",
                    CommandType.Text)
                Next
            End If

            ' Refresh data
            dtPO = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeOfDelivery] ", CommandType.Text)
            If dtPO.Rows.Count < 5 Then dtPO.Merge(TempTable_POList(4 - dtPO.Rows.Count))
            grdNOD.DataSource = dtPO
            grdNOD.DataBind()

            btnPreview.Enabled = True
            btnSave.Enabled = False
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            grdNOD.SelectedIndex = -1

            DeleteReceivingIfNoDetails()
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error: " & ex.Message)
        End Try
    End Sub

    Protected Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click


        'Session("nod_id") = objDerived.GetValue("SELECT TOP(1) nod_id FROM AMS.tbl_rpt_nod ORDER BY nod_id DESC", CommandType.Text)
        'Session("Report") = "NOD"
        'Me.Page.Response.Redirect("~/MainReports/rpt_Deliveries.aspx")

        ' 2) (Optional) Set this so the back link on t_rpt_receiving can come back here
        'Session("Report") = "NOD"

        ' 3) Redirect (open in new tab) to your new receiving report page

        'Session("NOD_ID")

        Dim url As String = ResolveUrl("~/MainReports/rpt_NoticeOfDelivery.aspx")
        Dim script As String = "window.open('" & url & "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)
    End Sub

    Protected Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Try
            ' Validate if a PO is selected
            If grdNOD.SelectedIndex = -1 Then
                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a PO first.")
                Return
            End If

            ' Get the selected PO ID
            Dim poHdrId As Long = Convert.ToInt64(grdNOD.SelectedDataKey("POHdr_ID"))

            ' Reset approval flags
            Dim updateQuery As String = "UPDATE AMS.PO_Hdr SET " &
                                   "isApproved = 0, " &
                                   "isApproved_PO_Mayor = 0, " &
                                   "DateApproved = NULL, " &
                                   "DateApproved_PO_Mayor = NULL, " &
                                   "ApprovedBy = NULL " &
                                   "WHERE POHdr_ID = " & poHdrId

            ' Execute the update
            objDerived.Execute(updateQuery, CommandType.Text)

            ' Refresh the grid
            dtPO = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeOfDelivery] ", CommandType.Text)
            If dtPO.Rows.Count < 5 Then
                dtPO.Merge(TempTable_POList(4 - dtPO.Rows.Count))
            End If
            grdNOD.DataSource = dtPO
            grdNOD.DataBind()

            ' Clear selection and show success message
            grdNOD.SelectedIndex = -1
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PO approval status has been reset successfully.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error resetting PO: " & ex.Message)
        End Try
    End Sub


    Protected Sub txtReceiptNo_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtReceiptNo.Text) Then
            ' Generate new invoice number if empty
            txtReceiptNo.Text = objDerived.GetValue("EXEC [AMS].[sp_Generate_UniqueDeliveryReceiptNo]", CommandType.Text).ToString()
        Else
            Dim txtReceiptNoCheck As String = txtReceiptNo.Text
            Dim txtReceiptNoExist As String = objDerived.GetValue("Select AMS.t_Notice_Of_Delivery.DReceiptNo from AMS.t_Notice_Of_Delivery where AMS.t_Notice_Of_Delivery.DReceiptNo = '" & txtReceiptNoCheck & "' ", CommandType.Text)

            If txtReceiptNoExist IsNot Nothing AndAlso txtReceiptNoExist <> "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "This Delivery Receipt number already exists.")
                btnSave.Enabled = False
            End If
        End If
    End Sub


End Class
