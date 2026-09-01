Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class procurement_t_PO_Approval
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule

#Region "Property"
    Private Property dtPOApproval() As DataTable
        Get
            Return CType(Session("dtPOApproval"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPOApproval") = value
        End Set
    End Property
#End Region
#Region "Tables"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("po_no", GetType(String))
        dt.Columns.Add("PO_Date", GetType(Date))
        dt.Columns.Add("ContractPrice", GetType(Decimal))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("ProjectName", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("isApproved", GetType(Boolean))
        dt.Columns.Add("RCName", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = DBNull.Value
            dr("po_no") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("ContractPrice") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("ProjectName") = DBNull.Value
            dr("POHdr_ID") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("isApproved") = DBNull.Value
            dr("RCName") = DBNull.Value
            dr("isVisible") = False

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function CreateTable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("ITEM", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("qty", GetType(Decimal))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("TotalAmount", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("POHdr_ID") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("ITEM") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("qty") = DBNull.Value
            dr("cost") = DBNull.Value
            dr("TotalAmount") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            Me.MultiView1.SetActiveView(Me.View4)
            Session("SearchPO") = "PONumber"
            LoadGrids()

            txtPONo.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchPONumb.ClientID & "')")

        End If
    End Sub

    Protected Sub LoadGrids()

        dtPOApproval = objDerived.GetDataTable("EXEC [AMS].[sp_PO_Approval]", CommandType.Text)
        If dtPOApproval.Rows.Count < 8 Then
            dtPOApproval.Merge(CreateTable1(8 - dtPOApproval.Rows.Count))
        End If
        grdPOApproval.DataSource = dtPOApproval
        grdPOApproval.DataBind()

        grdItemList.DataSource = CreateTable2(5)
        grdItemList.DataBind()

    End Sub

    Protected Sub grdPOApproval_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("EXEC [AMS].[sp_PO_Approval_Items] '" & grdPOApproval.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        If dt.Rows.Count < 5 Then
            dt.Merge(CreateTable2(5 - dt.Rows.Count))
        End If
        grdItemList.DataSource = dt
        grdItemList.DataBind()

        btnApproved.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Protected Sub grdPOApproval_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtPOApproval = objDerived.GetDataTable("EXEC [AMS].[sp_PO_Approval]", CommandType.Text)
        If dtPOApproval.Rows.Count < 10 Then
            dtPOApproval.Merge(CreateTable1(10 - dtPOApproval.Rows.Count))
        End If
        grdPOApproval.PageIndex = e.NewPageIndex
        grdPOApproval.DataSource = dtPOApproval
        grdPOApproval.DataBind()

        grdItemList.DataSource = CreateTable2(5)
        grdItemList.DataBind()
    End Sub

    Protected Sub btnApproved_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim PO_Numb As String = objDerived.GetValue("SELECT [AMS].[func_GeneratePO_Bataan] ('" & txtDate.Text & "')", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.PO_Hdr SET PO_No = '" & PO_Numb & "', isApproved = 1, DateApproved = '" & txtDate.Text & "' WHERE POHdr_ID = '" & grdPOApproval.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase Order has been successfully approved.")
        LoadGrids()
        btnCancel.Enabled = False
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ''MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Are you sure you want to return this P.O?")
            objDerived.GetRecords("UPDATE [AMS].[PO_Hdr] SET [isApproved] = 1, [isCancelled] = 1, [DateCancelled] = '" & Date.Today.ToString("MM/dd/yyyy") & "', " &
                                  " [RC_ID] = 0, [PR_No] = '(CANCELLED) ' + [PR_No], [ProjectName] = '(CANCELLED) ' + [ProjectName], [pre_procurement_hdr_id] = 0 WHERE [POHdr_ID] = '" & grdPOApproval.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

            'objDerived.GetRecords("DELETE FROM AMS.PO_Hdr WHERE POHdr_ID = '" & grdPOApproval.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            'objDerived.GetRecords("DELETE FROM AMS.PO_Dtl WHERE POHdr_ID = '" & grdPOApproval.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("EXEC [AMS].[sp_PO_Cancellation] '" & grdPOApproval.SelectedDataKey("pr_no") & "','" & grdPOApproval.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

            If dt.Rows.Count = 0 Then
                '========== UPDATE PUBLIC BIDDING
                objDerived.GetRecords("UPDATE AMS.Bid_Information SET withPO = 0, withNTP = 0 WHERE pre_procurement_hdr_id = '" & grdPOApproval.SelectedDataKey("pre_procurement_hdr_id") & "' AND Supplier_ID = '" & grdPOApproval.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

                'commented until infra functions are implemented.
                'objDerived.GetRecords("UPDATE AMS.tb_Infra_Hdr SET withPO = 0, withNTP = 0 WHERE pre_procurement_hdr_id = '" & grdPOApproval.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

            Else
                If dt.Rows(0)("mode") = "DCN" Then
                    '========== UPDATE DIRECT CONTRACTING / NEGOTIATED
                    objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl_PR1 SET withPO = 0 WHERE Hdr_ID = '" & dt.Rows(0)("Hdr_ID") & "' AND Supplier_ID = '" & dt.Rows(0)("Supplier_ID") & "'", CommandType.Text)

                ElseIf dt.Rows(0)("mode") = "Canvass" Then
                    '========== UPDATE CANVASS GOODS
                    For x As Integer = 0 To dt.Rows.Count - 1
                        objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 SET withPO = 0 WHERE Dtl_ID2 = '" & dt.Rows(x)("ID") & "' AND Supplier_ID = '" & dt.Rows(x)("Supplier_ID") & "'", CommandType.Text)
                    Next
                End If

            End If

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase Order has been successfully Returned.")

            LoadGrids()

        Catch ex As Exception
            AddTrace("Exception in Button3_Click: " & ex.Message)
        End Try
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub



    Protected Sub ddSearchPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSearchPR.SelectedItem.Value = 1 Then
            Me.MultiView1.SetActiveView(Me.View1)
            Session("SearchPR") = "PRNumber"

        ElseIf ddSearchPR.SelectedItem.Value = 2 Then
            Me.MultiView1.SetActiveView(Me.View2)
            Session("SearchPO") = "Department"

            ddDept.DataSource = objDerived.GetDataTable("exec dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)
            ddDept.DataTextField = ("rc_name")
            ddDept.DataValueField = ("rc_id")
            ddDept.DataBind()
            ddDept.Items.Insert(0, "Select")

        ElseIf ddSearchPR.SelectedItem.Value = 3 Then
            Me.MultiView1.SetActiveView(Me.View3)
            Session("SearchPO") = "Supplier"

            ddSupplier.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
            ddSupplier.DataTextField = ("SuppName")
            ddSupplier.DataValueField = ("Supplier_Id")
            ddSupplier.DataBind()
            ddSupplier.Items.Insert(0, "Select")

        ElseIf ddSearchPR.SelectedItem.Value = 4 Then
            Me.MultiView1.SetActiveView(Me.View4)
            Session("SearchPO") = "PONumber"



            ddSupplier.Items.Insert(0, "Select")

        End If
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnSearchPRNumb_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtPOApproval.DefaultView
        myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtPRNo.Text) & "%'"

        grdPOApproval.DataSource = myview
        grdPOApproval.DataBind()


        'dtPOApproval.Clear()

        'dtPOApproval = objDerived.GetDataTable("EXEC [AMS].[sp_PO_Approval_Search] '" & Session("SearchPO") & "','" & txtPRNo.Text & "','" & 0 & "','" & 0 & "'", CommandType.Text)
        'If dtPOApproval.Rows.Count < 8 Then
        '    dtPOApproval.Merge(CreateTable1(8 - dtPOApproval.Rows.Count))
        'End If
        'grdPOApproval.DataSource = dtPOApproval
        'grdPOApproval.DataBind()

        'grdItemList.DataSource = CreateTable2(5)
        'grdItemList.DataBind()

        Session("OtherPage") = "PRNumber"
    End Sub

    Protected Sub btnSearchPONumb_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtPOApproval.DefaultView
        myview.RowFilter = "po_no like '%" & replaceapostrophe(txtPONo.Text) & "%'"

        grdPOApproval.DataSource = myview
        grdPOApproval.DataBind()


        'dtPOApproval.Clear()

        'dtPOApproval = objDerived.GetDataTable("EXEC [AMS].[sp_PO_Approval_Search] '" & Session("SearchPO") & "','" & txtPRNo.Text & "','" & 0 & "','" & 0 & "'", CommandType.Text)
        'If dtPOApproval.Rows.Count < 8 Then
        '    dtPOApproval.Merge(CreateTable1(8 - dtPOApproval.Rows.Count))
        'End If
        'grdPOApproval.DataSource = dtPOApproval
        'grdPOApproval.DataBind()

        'grdItemList.DataSource = CreateTable2(5)
        'grdItemList.DataBind()

        Session("OtherPage") = "PONumber"
    End Sub


    Protected Sub btnSearchDept_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtPOApproval.DefaultView
        myview.RowFilter = "RCName = '" & ddDept.SelectedItem.Text & "'"
        grdPOApproval.DataSource = myview
        grdPOApproval.DataBind()

        'dtPOApproval.Clear()

        'dtPOApproval = objDerived.GetDataTable("EXEC [AMS].[sp_PO_Approval_Search] '" & Session("SearchPO") & "','" & txtPRNo.Text & "','" & ddDept.SelectedItem.Value & "','" & 0 & "'", CommandType.Text)
        'If dtPOApproval.Rows.Count < 8 Then
        '    dtPOApproval.Merge(CreateTable1(8 - dtPOApproval.Rows.Count))
        'End If
        'grdPOApproval.DataSource = dtPOApproval
        'grdPOApproval.DataBind()

        'grdItemList.DataSource = CreateTable2(5)
        'grdItemList.DataBind()

        Session("OtherPage") = "Department"
    End Sub

    Protected Sub btnSearchSupp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtPOApproval.DefaultView
        myview.RowFilter = "Supplier_Id = '" & ddSupplier.SelectedItem.Value & "'"
        grdPOApproval.DataSource = myview
        grdPOApproval.DataBind()

        'dtPOApproval.Clear()

        'dtPOApproval = objDerived.GetDataTable("EXEC [AMS].[sp_PO_Approval_Search] '" & Session("SearchPO") & "','" & txtPRNo.Text & "','" & 0 & "','" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
        'If dtPOApproval.Rows.Count < 8 Then
        '    dtPOApproval.Merge(CreateTable1(8 - dtPOApproval.Rows.Count))
        'End If
        'grdPOApproval.DataSource = dtPOApproval
        'grdPOApproval.DataBind()

        'grdItemList.DataSource = CreateTable2(5)
        'grdItemList.DataBind()

        Session("OtherPage") = "Supplier"
    End Sub

End Class
