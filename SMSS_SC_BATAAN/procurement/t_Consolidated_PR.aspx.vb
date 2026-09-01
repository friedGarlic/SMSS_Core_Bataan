Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control


Partial Class procurement_t_Consolidated_PR
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule
    Dim dtl As New t_obr_evaluation_dtl
    Dim prdtl As New t_purchase_request_dtl

#Region "VARIABLES"
    Private Property dtPRList() As DataTable
        Get
            Return CType(Session("dtPRList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPRList") = value
        End Set
    End Property

    Private Property dtConsolidatedPR() As DataTable
        Get
            Return CType(Session("dtConsolidatedPR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtConsolidatedPR") = value
        End Set
    End Property

    Public Function cdt_PRApproval(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Date_Submitted", GetType(Date))
        dt.Columns.Add("GA_Title", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Long))
        dt.Columns.Add("BGA_ID", GetType(Long))
        dt.Columns.Add("Cnt", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Date_Submitted") = DBNull.Value
            dr("GA_Title") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("prhdr_id") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("BGA_ID") = DBNull.Value
            dr("Cnt") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function cdt_PRList(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("GA_ID", GetType(Long))
        dt.Columns.Add("DateApproved", GetType(Date))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("Project_ID", GetType(Long))
        dt.Columns.Add("Program_id", GetType(Long))
        dt.Columns.Add("isOnBid", GetType(Boolean))
        dt.Columns.Add("isChecked", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("DateApproved") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("Project_ID") = DBNull.Value
            dr("Program_id") = DBNull.Value
            dr("isOnBid") = DBNull.Value
            dr("isChecked") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function cdt_ApprovedPR(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("pr_date", GetType(Date))
        dt.Columns.Add("GA_Title", GetType(String))
        dt.Columns.Add("Cnt", GetType(Integer))
        dt.Columns.Add("ABC", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = DBNull.Value
            dr("pr_date") = DBNull.Value
            dr("GA_Title") = DBNull.Value
            dr("Cnt") = DBNull.Value
            dr("ABC") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            LoadGridData()

            '=== DEFAULT TAB ===
            btnTab1.CssClass = "TabButton_Active"
            btnTab2.CssClass = "TabButton_InActive"
            Me.mvTabs.SetActiveView(Me.vwTab1)

        End If

    End Sub

    Protected Sub btnTab1_Click(sender As Object, e As EventArgs) Handles btnTab1.Click
        btnTab1.CssClass = "TabButton_Active"
        btnTab2.CssClass = "TabButton_InActive"
        Me.mvTabs.SetActiveView(Me.vwTab1)

    End Sub

    Protected Sub btnTab2_Click(sender As Object, e As EventArgs) Handles btnTab2.Click
        btnTab1.CssClass = "TabButton_InActive"
        btnTab2.CssClass = "TabButton_Active"
        Me.mvTabs.SetActiveView(Me.vwTab2)

    End Sub

    Protected Sub LoadGridData()
        '=========== DISPLAY ALL CONSOLIDATED PR FOR APPROVAL ===========
        dtConsolidatedPR = objDerived.GetDataTable("EXEC [AMS].[sp_Consolidated_PR]", CommandType.Text)
        If dtConsolidatedPR.Rows.Count < 5 Then
            dtConsolidatedPR.Merge(cdt_PRApproval(5 - dtConsolidatedPR.Rows.Count))
        End If
        grdPurchaseRequest.DataSource = dtConsolidatedPR
        grdPurchaseRequest.DataBind()

        '=========== DISPLAY ALL PR FOR OBR EVALUATION ===========
        grdPRList.DataSource = cdt_PRList(5)
        grdPRList.DataBind()

        '=========== DISPLAY ALL APPROVED PR ===========
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("EXEC [AMS].[sp_ApprovedConsolidatedPR]", CommandType.Text)
        If dt.Rows.Count < 5 Then
            dt.Merge(cdt_ApprovedPR(5 - dt.Rows.Count))
        End If
        grdApproved_PR.DataSource = dt
        grdApproved_PR.DataBind()

    End Sub

    Protected Sub grdPurchaseRequest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            dtPRList = objDerived.GetDataTable("EXEC [AMS].[sp_PRConsolidationList] '" & grdPurchaseRequest.SelectedDataKey("prhdr_id") & "','" & grdPurchaseRequest.SelectedDataKey("GA_ID") & "'", CommandType.Text)
            grdPRList.DataSource = dtPRList
            grdPRList.DataBind()

            For i As Integer = 0 To grdPRList.Rows.Count - 1
                CType(Me.grdPRList.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox).Enabled = True
            Next

            btnUpdate.Enabled = True
            btnApproved.Enabled = True
            btnCancel.Enabled = True

            Session("PR_ConsoID") = grdPurchaseRequest.SelectedDataKey("prhdr_id")

            Session("OBREval_ID") = objDerived.GetValue("SELECT TOP(1) AMS.obr_evaluation_dtl.obr_evaluation_hdr_id FROM AMS.PR_Hdr INNER JOIN " &
                                                             " AMS.obr_evaluation_dtl ON AMS.PR_Hdr.prhdr_id = AMS.obr_evaluation_dtl.prhdr_id " &
                                                             " WHERE AMS.PR_Hdr.PR_ConsoID = '" & Session("PR_ConsoID") & "'", CommandType.Text)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error occured, pls contact system admin.")
        End Try
    End Sub

    Protected Sub lnkSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=========== CHECK IF THERE ARE SELECTED PR TO ADD ===========
        Dim checkbox As Integer = 0
        For i As Integer = 0 To Me.grdPRList.Rows.Count - 1
            If CType(grdPRList.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True Then
                checkbox = 1
                Exit For
            End If
        Next

        If checkbox = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No selected purchase request to update.")
        Else
            Try
                Dim MOP_ID As Integer = objDerived.GetValue("SELECT TOP(1) mode_of_procurement_id FROM AMS.PR_Hdr WHERE PR_ConsoID = '" & Session("PR_ConsoID") & "'", CommandType.Text)
                For i As Integer = 0 To Me.grdPRList.Rows.Count - 1
                    If CType(grdPRList.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True Then

                        objDerived.GetRecords("INSERT INTO [SMSS_Premium].[AMS].[obr_evaluation_dtl] " & _
                                                " ([obr_evaluation_hdr_id] " & _
                                                " ,[withPreProcurement] " & _
                                                " ,[prhdr_id] " & _
                                                " ,[Supplier_ID]) " & _
                                                " Values " & _
                                                " ('" & Session("OBREval_ID") & "' " & _
                                                " ,0 " & _
                                                " ,'" & dtPRList.Rows(i)("prhdr_id") & "' " & _
                                                " ,0)", CommandType.Text)

                        objDerived.GetRecords("EXEC [AMS].[sp_UpdatePR_Dtl] '" & Session("PR_ConsoID") & "','" & dtPRList.Rows(i)("prhdr_id") & "'", CommandType.Text)
                        objDerived.GetRecords("UPDATE AMS.PR_Hdr SET PR_ConsoID = '" & Session("PR_ConsoID") & "', isOnBid = 1, mode_of_procurement_id = '" & MOP_ID & "' WHERE prhdr_id = '" & dtPRList.Rows(i)("prhdr_id") & "'", CommandType.Text)

                    End If
                Next

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                LoadGridData()

            Catch ex As Exception
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong in the process, pls contact system admin.")
            End Try
        End If


    End Sub

    Protected Sub btnApproved_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim pr_no As String
            pr_no = objDerived.GetValue("SELECT [AMS].[func_GeneratePR_Bataan] ('" & txtDate.Text & "','" & Session("PR_ConsoID") & "')", CommandType.Text)
            objDerived.GetRecords("UPDATE ams.pr_hdr set isApproved = 1, isApproved_PR_Mayor =1, withOBR = 1, pr_no ='" & pr_no & "', pr_date = '" & txtDate.Text & "', " & _
                                     " DateApproved_PR_Mayor = '" & txtDate.Text & "' WHERE ams.pr_hdr.prhdr_id = '" & Session("PR_ConsoID") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully saved.")

            txtPRNumber.Text = pr_no
            ModalPopupExtender1.Show()

            LoadGridData()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong in the process, pls contact system admin.")
        End Try
 

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '=========== CANCEL CONSOLIDATED PR, AND UPDATE INDIVIDUAL PR INVOLVE ===========
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET IsCancelled = 1 WHERE prhdr_id = '" & Session("PR_ConsoID") & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET mode_of_procurement_id = 0, isOnBid = 0, PR_ConsoID = 0 WHERE PR_ConsoID = '" & Session("PR_ConsoID") & "' ", CommandType.Text)

            '=========== DELETE OBR EVALUATION TRANSACTION ===========
            objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_hdr WHERE obr_evaluation_hdr_id = '" & Session("OBREval_ID") & "'", CommandType.Text)
            objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id = '" & Session("OBREval_ID") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Consolidated PR has been succesfully cancelled.")
            LoadGridData()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong in the process, pls contact system admin.")
        End Try
    End Sub


End Class
