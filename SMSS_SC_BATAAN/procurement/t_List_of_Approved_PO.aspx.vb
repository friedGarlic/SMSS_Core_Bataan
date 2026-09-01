Imports System.Data
Partial Class procurement_t_List_of_Approved_PO
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
#Region "Property"
    Private Property pPurchase_Order() As DataTable
        Get
            Return CType(Session("pPurchase_Order"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order") = value
        End Set
    End Property
#End Region
#Region "Function"
    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("Supplier", GetType(String))
        dt.Columns.Add("Amount", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("DeliveryDate", GetType(String))
        dt.Columns.Add("ExtensionDate", GetType(String))
        dt.Columns.Add("Status", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = DBNull.Value
            dr("Supplier") = DBNull.Value
            dr("Amount") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("DeliveryDate") = DBNull.Value
            dr("ExtensionDate") = DBNull.Value
            dr("Status") = DBNull.Value

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadRecord()
        End If
    End Sub
    'Protected Sub LoadRecord()
    '    pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_List_of_Approved_PR]", CommandType.Text)

    '    ' Check if rows are fewer than 10 and merge empty rows if necessary
    '    If pPurchase_Order.Rows.Count < 10 Then
    '        pPurchase_Order.Merge(createdatatable(9 - pPurchase_Order.Rows.Count))
    '    End If

    '    ' Set the correct DataKeyNames to match the column from the stored procedure
    '    gvPurchase_Order.DataSource = pPurchase_Order
    '    gvPurchase_Order.DataKeyNames = New String() {"pr_no", "pr_hrd_no", "Supplier_ID"}  ' Change POHdr_ID to pr_hrd_no
    '    gvPurchase_Order.DataBind()
    'End Sub

    Protected Sub LoadRecord(Optional ByVal searchOption As Integer = 1, Optional ByVal searchValue As String = "")
        Dim query As String
        If searchOption = 1 AndAlso String.IsNullOrEmpty(searchValue) Then
            query = "EXEC [AMS].[sp_Search_Approved_PR] " & searchOption & ", '" & searchValue.Replace("'", "''") & "'"
        Else
            query = "EXEC [AMS].[sp_Search_Approved_PR] " & searchOption & ", '" & searchValue.Replace("'", "''") & "'"
        End If

        ' Log the SQL query before executing
        System.Diagnostics.Debug.WriteLine("Executing Query: " & query)

        pPurchase_Order = objDerived.GetDataTable(query, CommandType.Text)

        ' Check if pPurchase_Order is Nothing before accessing .Rows.Count
        If pPurchase_Order Is Nothing Then
            Throw New Exception("Error: The stored procedure returned Nothing.")
        End If

        ' If the DataTable is empty, initialize it instead of throwing an error
        If pPurchase_Order.Rows.Count < 10 Then
            pPurchase_Order.Merge(createdatatable(9 - pPurchase_Order.Rows.Count))
        End If

        gvPurchase_Order.DataSource = pPurchase_Order
        gvPurchase_Order.DataKeyNames = New String() {"pr_no", "pr_hrd_no", "Supplier_ID"}
        gvPurchase_Order.DataBind()
    End Sub


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim searchOption As Integer = Convert.ToInt32(ddSearchOption.SelectedValue)
        Dim searchValue As String = ""

        Select Case searchOption
            Case 1 ' ALL
                LoadRecord(1, "")

            Case 2 ' PO Number
                searchValue = txtPO.Text.Trim()
                LoadRecord(2, searchValue)

            Case 3 ' Delivery Date
                searchValue = txtDeliveryDate.Text.Trim()
                LoadRecord(3, searchValue)

                ' Extend with more Cases if you add more filter fields:
                ' Case 4: Supplier
                ' Case 5: Department
                ' Case 6: Status
                ' Case 7: Trust Fund

            Case Else
                ' Default to ALL if an unexpected option is chosen
                LoadRecord(1, "")
        End Select

    End Sub

    Protected Sub ddSearchOption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSearchOption.SelectedIndex = 0 Then
            txtPO.visible = False
            txtDeliveryDate.visible = False
            btnSearch.visible = False
        ElseIf ddSearchOption.SelectedIndex = 1 Then
            txtPO.visible = True
            btnSearch.visible = True
            txtDeliveryDate.visible = False
        ElseIf ddSearchOption.SelectedIndex = 2 Then
            txtDeliveryDate.visible = True
            btnSearch.visible = True
            txtPO.Visible = False


        End If

        Dim searchOption As Integer = Convert.ToInt32(ddSearchOption.SelectedValue)
        Dim searchValue As String = ""

        Select Case searchOption
            Case 1 ' ALL
                LoadRecord(1, "")


        End Select


    End Sub
    Protected Sub gvPurchase_Order_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvPurchase_Order, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub gvPurchase_Order_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Retrieve the correct key for PO Header ID (use 'pr_hrd_no' instead of 'POHdr_ID')
        Dim prNo As Object = gvPurchase_Order.SelectedDataKey("pr_no")
        Dim poHdrID As Object = gvPurchase_Order.SelectedDataKey("pr_hrd_no") ' Corrected key reference

        ' Check if POHdr_ID is available
        If poHdrID Is Nothing OrElse IsDBNull(poHdrID) OrElse String.IsNullOrEmpty(poHdrID.ToString()) Then
            ' If POHdr_ID is invalid or missing, fall back to using PO_No instead
            poHdrID = gvPurchase_Order.SelectedDataKey("pr_no") ' Use pr_no as fallback for POHdr_ID
        End If

        ' Now, check if pr_no or poHdrID is still missing
        If prNo Is Nothing OrElse IsDBNull(prNo) OrElse String.IsNullOrEmpty(prNo.ToString()) OrElse poHdrID Is Nothing OrElse String.IsNullOrEmpty(poHdrID.ToString()) Then
            ' Handle the case when PO Header ID or PR Number is invalid or missing
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PO Header ID or PR Number is invalid or missing.")
            btnSave.Enabled = False
            btnPReview.Enabled = False
            btnPreviewPO.Enabled = False
            btnReturnPo.Enabled = False
            btnCancelPO.Enabled = False
        Else
            ' Handle the case when both PO Header ID and PR Number are valid
            btnSave.Enabled = True
            btnPreviewPO.Enabled = True
            btnPReview.Enabled = True
            btnReturnPo.Enabled = True
            btnCancelPO.Enabled = True
        End If
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        If txtExtension.text = "" Then
        Else
            objDerived.GetRecords("UPDATE AMS.PO_Hdr SET ExtensionDate = '" & txtExtension.text & "' WHERE PO_No = '" & gvPurchase_Order.SelectedDataKey("pr_no") & "' ", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            LoadRecord()
            btnSave.Enabled = False
        End If
    End Sub
    Protected Sub btnReturnPo_Click(sender As Object, e As EventArgs)

        objDerived.GetRecords("UPDATE AMS.PO_Hdr SET PO_No = '', isApproved = 0, DateApproved = '' WHERE POHdr_ID = '" & gvPurchase_Order.SelectedDataKey("pr_hrd_no") & "'", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase Order has been successfully Returned.")
        LoadRecord()

    End Sub
    Protected Sub btnCancelPO_Click(sender As Object, e As EventArgs)
        Try
            ' Fetch Selected Keys using the proper DataKeyNames
            Dim prNo As Object = gvPurchase_Order.SelectedDataKey("pr_no")
            Dim supplierID As Object = gvPurchase_Order.SelectedDataKey("Supplier_ID")
            Dim poHdrID As Object = gvPurchase_Order.SelectedDataKey("pr_hrd_no") ' Use pr_hrd_no for PO Header ID

            ' Validate the values
            If prNo Is Nothing OrElse IsDBNull(prNo) OrElse String.IsNullOrEmpty(prNo.ToString()) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('PR Number is invalid or missing.');", True)
                Return
            End If

            If supplierID Is Nothing OrElse IsDBNull(supplierID) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Supplier ID is invalid or missing.');", True)
                Return
            End If

            If poHdrID Is Nothing OrElse IsDBNull(poHdrID) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('PO Header ID is invalid or missing.');", True)
                Return
            End If

            ' Update PO_Hdr table (removed pre_procurement_hdr_id update to avoid the invalid column error)
            objDerived.GetRecords("UPDATE [AMS].[PO_Hdr] SET " &
                              " [isApproved] = 1, " &
                              " [isCancelled] = 1, " &
                              " [DateCancelled] = '" & Date.Today.ToString("MM/dd/yyyy") & "', " &
                              " [RC_ID] = 0, " &
                              " [PR_No] = '(CANCELLED) ' + [PR_No], " &
                              " [ProjectName] = '(CANCELLED) ' + [ProjectName] " &
                              "WHERE [POHdr_ID] = '" & poHdrID.ToString() & "'", CommandType.Text)

            ' Execute the stored procedure for cancellation
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("EXEC [AMS].[sp_PO_Cancellation] '" & prNo.ToString() & "','" & supplierID.ToString() & "'", CommandType.Text)

            ' If the stored procedure returns no rows, update related tables
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                objDerived.GetRecords("UPDATE AMS.Bid_Information SET withPO = 0, withNTP = 0 WHERE pre_procurement_hdr_id = 0 AND Supplier_ID = '" & supplierID.ToString() & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.tb_Infra_Hdr SET withPO = 0, withNTP = 0 WHERE pre_procurement_hdr_id = 0", CommandType.Text)
            Else
                ' Process the returned data
                Dim mode As String = dt.Rows(0)("mode").ToString()
                If mode = "DCN" Then
                    objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl_PR1 SET withPO = 0 WHERE Hdr_ID = '" & dt.Rows(0)("Hdr_ID").ToString() & "' AND Supplier_ID = '" & dt.Rows(0)("Supplier_ID").ToString() & "'", CommandType.Text)
                ElseIf mode = "Canvass" Then
                    For x As Integer = 0 To dt.Rows.Count - 1
                        objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 SET withPO = 0 WHERE Dtl_ID2 = '" & dt.Rows(x)("ID").ToString() & "' AND Supplier_ID = '" & dt.Rows(x)("Supplier_ID").ToString() & "'", CommandType.Text)
                    Next
                End If
            End If

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Purchase Order has been successfully Cancelled.');", True)
            LoadRecord()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Error: " & ex.Message.Replace("'", "\'") & "');", True)
        End Try
    End Sub

    Protected Sub btnPreviewPO_Click(sender As Object, e As EventArgs) Handles btnPreviewPO.Click
        Session("Page") = "RQ"

        Session("POHdr_ID") = gvPurchase_Order.SelectedDataKey("pr_hrd_no")

        Me.Page.Response.Redirect("~/Procurement/rpt_purchase_order.aspx")
    End Sub
    Protected Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Session("Page") = "RQ"

        Session("pohdr_id") = gvPurchase_Order.SelectedDataKey("pr_hrd_no")

        Me.Page.Response.Redirect("~/Procurement/rpt_POcontract.aspx")
    End Sub





End Class
