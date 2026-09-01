Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class t_purchase_request_Approval
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl
    Private pr_obr As New PR_OBR
    Private obr_hdr As New t_purchase_request_obr_hdr
    Private obr_dtl As New t_purchase_request_obr_dtl
    Private obr_Adjsutment_hdr As New t_purchase_request_obr_adjustment_hdr
    Private obr_Adjsutment_dtl As New t_purchase_request_obr_adjustment_dtl
    Private disbursement As New t_Purchase_request_disbursement
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Private getprofile As New ProfileCommon

#Region "property"
    Private Property pRoleName() As DataTable
        Get
            Return CType(Session("pRoleName"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRoleName") = value
        End Set
    End Property

    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property

    Private Property pIncomingPR() As DataTable
        Get
            Return CType(Session("pIncomingPR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pIncomingPR") = value
        End Set
    End Property

    Private Property pApprovedPR() As DataTable
        Get
            Return CType(Session("pApprovedPR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pApprovedPR") = value
        End Set
    End Property

    Private Property dtApprovedPR_SEF() As DataTable
        Get
            Return CType(Session("dtApprovedPR_SEF"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtApprovedPR_SEF") = value
        End Set
    End Property

    Private Property dtTrustFund() As DataTable
        Get
            Return CType(Session("dtTrustFund"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtTrustFund") = value
        End Set

    End Property
#End Region
#Region "function"
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("InputQty", GetType(Integer))
        dt.Columns.Add("qty")
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("total", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("ReadOnly", GetType(Boolean))
        dt.Columns.Add("GA_ID", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("id") = 0
            dr("Item_Desc") = ""
            dr("Description") = ""
            dr("InputQty") = 0
            dr("qty") = 0
            dr("cost") = "0.00"
            dr("total") = "0.00"
            dr("Item_ID") = 0
            dr("isVisible") = False
            dr("ReadOnly") = True
            dr("GA_ID") = 0

            dt.Rows.Add(dr)

        Next
        Return dt

    End Function


    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("rc_name")
        dt.Columns.Add("Function_Desc")
        dt.Columns.Add("Date_Submitted", GetType(Date))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("pr_no")
        dt.Columns.Add("PR_Date", GetType(Date))
        dt.Columns.Add("status")
        dt.Columns.Add("isReimbursement", GetType(Boolean))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("rc_name") = ""
            dr("Function_Desc") = ""
            dr("Date_Submitted") = CType("01/01/1900", Date)
            dr("isVisible") = False
            dr("pr_no") = ""
            dr("PR_Date") = CType("01/01/1900", Date)
            dr("status") = ""
            dr("isReimbursement") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function CreateTable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("Function_Desc", GetType(String))
        dt.Columns.Add("Date_Submitted", GetType(Date))
        dt.Columns.Add("DateApproved_PR_Mayor", GetType(Date))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("status", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("Function_Desc") = DBNull.Value
            dr("Date_Submitted") = DBNull.Value
            dr("DateApproved_PR_Mayor") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("isVisible") = False
            dr("status") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
            Dim role() As String = Roles.GetRolesForUser(usr.UserName)
            Dim rolename As String = role(0)


            pApprovedPR = objDerived.GetDataTable("EXEC [AMS].[sp_ApprovedPR] '" & 1 & "'", CommandType.Text)
            If pApprovedPR.Rows.Count < 10 Then
                pApprovedPR.Merge(createdatatable(10 - pApprovedPR.Rows.Count))
            End If
            gvApprovedPR.DataSource = pApprovedPR
            gvApprovedPR.DataBind()

            dtApprovedPR_SEF = objDerived.GetDataTable("EXEC [AMS].[sp_ApprovedPR] '" & 2 & "'", CommandType.Text)
            If dtApprovedPR_SEF.Rows.Count < 10 Then
                dtApprovedPR_SEF.Merge(CreateTable2(10 - dtApprovedPR_SEF.Rows.Count))
            End If
            grdApprovedSEF.DataSource = dtApprovedPR_SEF
            grdApprovedSEF.DataBind()


            dtTrustFund = objDerived.GetDataTable("EXEC [AMS].[sp_ApprovedPR] '" & 3 & "'", CommandType.Text)
            If dtTrustFund.Rows.Count < 10 Then
                dtTrustFund.Merge(CreateTable2(10 - dtTrustFund.Rows.Count))
            End If
            grdApprovedTF.DataSource = dtTrustFund
            grdApprovedTF.DataBind()


            TabContainer1.ActiveTabIndex = 0
            LoadActiveTAB()


        End If

        txtPRNo.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchPRNumb.ClientID & "')")
        txtFrom.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchDate.ClientID & "')")
        txtTo.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchDate.ClientID & "')")

    End Sub

    Protected Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadActiveTAB()
    End Sub

    Protected Sub LoadActiveTAB()
        If TabContainer1.ActiveTabIndex = 0 Then
            pIncomingPR = objDerived.GetDataTable("EXEC [AMS].[sp_PRList_forApproval]", CommandType.Text)
            If pIncomingPR.Rows.Count < 10 Then
                pIncomingPR.Merge(createdatatable(10 - pIncomingPR.Rows.Count))
            End If
            gvIncomingPR.DataSource = pIncomingPR
            gvIncomingPR.DataBind()

            ddDepartment.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RespCenter_withFunctions] WHERE [Function_ID] = 86 ORDER BY RC_Name", CommandType.Text)
            ddDepartment.DataTextField = ("RC_Name")
            ddDepartment.DataValueField = ("RC_ID")
            ddDepartment.DataBind()
            ddDepartment.Items.Insert(0, "All")

        ElseIf TabContainer1.ActiveTabIndex = 1 Then
            pApprovedPR = objDerived.GetDataTable("EXEC [AMS].[sp_ApprovedPR] '" & 1 & "'", CommandType.Text)
            If pApprovedPR.Rows.Count < 10 Then
                pApprovedPR.Merge(createdatatable(10 - pApprovedPR.Rows.Count))
            End If
            gvApprovedPR.DataSource = pApprovedPR
            gvApprovedPR.DataBind()

            Load_GFSearch()

        ElseIf TabContainer1.ActiveTabIndex = 2 Then
            dtApprovedPR_SEF = objDerived.GetDataTable("EXEC [AMS].[sp_ApprovedPR] '" & 2 & "'", CommandType.Text)
            If dtApprovedPR_SEF.Rows.Count < 10 Then
                dtApprovedPR_SEF.Merge(CreateTable2(10 - dtApprovedPR_SEF.Rows.Count))
            End If
            grdApprovedSEF.DataSource = dtApprovedPR_SEF
            grdApprovedSEF.DataBind()

        ElseIf TabContainer1.ActiveTabIndex = 3 Then
            dtTrustFund = objDerived.GetDataTable("EXEC [AMS].[sp_ApprovedPR] '" & 3 & "'", CommandType.Text)
            If dtTrustFund.Rows.Count < 10 Then
                dtTrustFund.Merge(CreateTable2(10 - dtTrustFund.Rows.Count))
            End If
            grdApprovedTF.DataSource = dtTrustFund
            grdApprovedTF.DataBind()

        End If
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    '================ FOR RECEIVING ================
    Protected Sub lnkview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "print"
    End Sub
    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "Approve"
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "return"
    End Sub
    Protected Sub gvIncomingPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvIncomingPR.SelectedIndexChanged
        Dim isWithPR As DataTable
        Try
            If Lbtn = "Approve" Then
                Dim isManual As Boolean
                isManual = objDerived.GetValue("select isManual from ams.PR_STATUS", CommandType.Text)
                isWithPR = objDerived.GetDataTable("SELECT CASE WHEN pr_no IS NULL THEN 0 ELSE 1 END AS status FROM AMS.PR_Hdr WHERE  prhdr_id = " & gvIncomingPR.SelectedDataKey(0) & "", CommandType.Text)

                If isWithPR.Rows(0)("status") = False Then
                    If isManual = False Then
                        Dim pr_no As String
                        pr_no = objDerived.GetValue("select [AMS].[func_GeneratePR_Bataan]('" & CType(gvIncomingPR.Rows(gvIncomingPR.SelectedIndex).FindControl("txtApproveDate"), TextBox).Text & "','" & gvIncomingPR.SelectedDataKey("prhdr_id") & "')", CommandType.Text)

                        Dim value1 As New DataTable
                        value1 = objDerived.GetDataTable("select Rc_Id, Function_id,PR_year,Project_id,Program_id from Ams.Pr_hdr where prhdr_id=" & gvIncomingPR.SelectedDataKey(0) & " ", CommandType.Text)

                        objDerived.GetRecords("UPDATE AMS.pr_hdr SET pr_no = '" & pr_no & "', isApproved= 1, isReceived_PR_Mayor = 1, isApproved_PR_Mayor = 1, " &
                                        " pr_date = '" & CType(gvIncomingPR.Rows(gvIncomingPR.SelectedIndex).FindControl("txtApproveDate"), TextBox).Text & "', " &
                                        " DateApproved_PR_Mayor = '" & CType(gvIncomingPR.Rows(gvIncomingPR.SelectedIndex).FindControl("txtApproveDate"), TextBox).Text & "', " &
                                        " Date_gso_rcv = '" & CType(gvIncomingPR.Rows(gvIncomingPR.SelectedIndex).FindControl("txtApproveDate"), TextBox).Text & "' " &
                                        " WHERE prhdr_id = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction succesfully saved." & vbCrLf & "Purchase Request Number :" & pr_no)
                        txtPRNumber.Text = pr_no
                        ModalPopupExtender1.Show()

                    Else

                    End If
                Else
                    objDerived.GetRecords("UPDATE AMS.pr_hdr SET isApproved = 1 WHERE prhdr_id = '" & gvIncomingPR.SelectedDataKey(0) & "'", CommandType.Text)

                    pIncomingPR = objDerived.GetDataTable("select * from ams.vw_incoming_pr_for_approval_goods", CommandType.Text)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                End If
                Dim OBR_Numb As String = objDerived.GetValue("SELECT [dbo].[func_Generate_OBR_Num] ('101','" & CType(gvIncomingPR.Rows(gvIncomingPR.SelectedIndex).FindControl("txtApproveDate"), TextBox).Text & "')", CommandType.Text)
                objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_CAA_Hdr SET OBR_No = '" & OBR_Numb & "', IsApproved = 1, isApprovedMayor = 1,isReceivedBO = 1, Status = 'Approved', DateApprovedMayor = '" & CType(gvIncomingPR.Rows(gvIncomingPR.SelectedIndex).FindControl("txtApproveDate"), TextBox).Text & "',DateReceivedMayor = '" & CType(gvIncomingPR.Rows(gvIncomingPR.SelectedIndex).FindControl("txtApproveDate"), TextBox).Text & "' WHERE PRHdr_ID = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

            ElseIf Lbtn = "print" Then
                Session("prhdr_id") = gvIncomingPR.SelectedDataKey("prhdr_id")

                'Me.Page.Response.Redirect("~/procurement/rpt_purchase_request.aspx")


                Dim url As String = "rpt_purchase_request.aspx?"
                Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
                ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)


            ElseIf Lbtn = "return" Then
                ModalPopupExtender123.Show()
                'objDerived.GetRecords("UPDATE [AMS].[PR_Hdr] SET [isEditable] = 1,[isFinal] = 0 WHERE [prhdr_id] = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR has been successfully returned.")

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
        End Try

        TabContainer1.ActiveTabIndex = 0
        LoadActiveTAB()

    End Sub
    Protected Sub gvIncomingPR_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvIncomingPR.PageIndexChanging
        If pIncomingPR.Rows.Count < 8 Then
            pIncomingPR.Merge(createdatatable(7 - pIncomingPR.Rows.Count))
        End If
        gvIncomingPR.DataSource = pIncomingPR
        gvIncomingPR.SelectedIndex = e.NewPageIndex
        gvIncomingPR.DataBind()
    End Sub
    Protected Sub btnRcvSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If ddDepartment.SelectedItem.Text = "All" Then
                pIncomingPR = objDerived.GetDataTable("EXEC [AMS].[sp_PRList_forApproval]", CommandType.Text)
                If pIncomingPR.Rows.Count < 10 Then
                    pIncomingPR.Merge(createdatatable(10 - pIncomingPR.Rows.Count))
                End If
                gvIncomingPR.DataSource = pIncomingPR
                gvIncomingPR.DataBind()
            Else
                Dim myview As DataView
                myview = pIncomingPR.DefaultView
                myview.RowFilter = "RC_ID = '" & ddDepartment.SelectedItem.Value & "'"
                gvIncomingPR.DataSource = myview
                gvIncomingPR.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub



    '================ APPROVED GENERAL FUND ================
    Protected Sub lnkview2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "printGF"
    End Sub
    Protected Sub lnkCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "CancelGF"
    End Sub
    Protected Sub lnkReturnGF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "ReturnGF"
    End Sub

    Protected Sub lnkEditGF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "EditGF"
    End Sub


    Protected Sub gvApprovedPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvApprovedPR.SelectedIndexChanged
        'Try
        session("OBR_Hdr_ID") = gvApprovedPR.SelectedDatakey("OBR_Hdr_ID")
        If Lbtn = "printGF" Then
            Session("prhdr_id") = gvApprovedPR.SelectedDataKey("prhdr_id")

            Session("Page") = "PR_Approval"
            Session("Report") = "PR"

            '' Me.Page.Response.Redirect("~/MainReports/Procurement_Reports.aspx")

            Dim url As String = "/MainReports/Procurement_Reports.aspx?"
            Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)


            'Dim url As String = "rpt_purchase_request_pop_up.aspx?"
            'Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
            'ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)




        ElseIf Lbtn = "ReturnGF" Then
            Try
                '====== TEMPORARILY DISABLE FOR VERIFICATION
                Dim x As Integer = gvApprovedPR.SelectedDataKey("prhdr_id")
                Dim OBR_Rcv As Boolean
                OBR_Rcv = objDerived.GetValue("SELECT DISTINCT ISNULL(T_OBR_Hdr.isReceivedBO,0) FROM AMS.PR_Hdr INNER JOIN	LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Hdr AS T_OBR_Hdr ON AMS.PR_Hdr.prhdr_id = T_OBR_Hdr.PRHdr_ID " &
                                            " WHERE AMS.PR_Hdr.prhdr_id = '" & gvApprovedPR.SelectedDataKey("prhdr_id") & "' ", CommandType.Text)

                If OBR_Rcv = 0 Then
                    '====== CHECK IF PURCHASE REQUEST IS ON BID
                    Dim CheckID As Integer
                    CheckID = objDerived.GetValue("SELECT [mode_of_procurement_id] FROM [AMS].[PR_Hdr] WHERE [prhdr_id] = '" & gvApprovedPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                    If CheckID = 0 Then
                        '====== RETURN FOR EDITING
                        objDerived.GetRecords("UPDATE [AMS].[PR_Hdr] SET [isFinal] = 0, [isEditable] = 1, [IsApproved] = 0 WHERE [prhdr_id] = '" & gvApprovedPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase request has been successfully return for editing.")
                    Else
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase request is already on bid.")
                    End If

                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "OBR was already recieved, transaction is not permitted.")

                End If

            Catch ex As Exception

            End Try

        ElseIf Lbtn = "CancelGF" Then

            Dim dtTrap As New DataTable
            dtTrap = objDerived.GetDataTable("SELECT * FROM [AMS].[PR_Hdr] WHERE prhdr_id = '" & gvApprovedPR.SelectedDataKey("prhdr_id") & "' and mode_of_procurement_id = 0 ", CommandType.Text)

            If dtTrap.Rows.Count > 0 Then
                Dim dt As New DataTable
                Dim x As Integer = gvApprovedPR.SelectedDataKey("prhdr_id")
                dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PR_OBR_ApprovedCancellation1] WHERE prhdr_id = '" & gvApprovedPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                'If dt.Rows(0)("isApproved") = True Then
                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "OBR has been approved, contact Budget Officer.")
                'Else
                '====== CANCEL APPROVED PURCHASE REQUEST
                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET IsCancelled = 1 WHERE prhdr_id = '" & gvApprovedPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                Dim a As Integer = dt.Rows(0)("OBR_Hdr_ID")
                '====== CANCEL OBR (NOT APPROVED)
                Session("CAA") = a
                ' objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_CAA_Hdr SET isCancelled = 1, dateCancelled = '" & Date.Today.ToString("MM/dd/yyyy") & "', ReasonForCancellation = 'PR Cancellation', Status = 'Cancelled' WHERE OBR_Hdr_ID = '" & dt.Rows(0)("OBR_Hdr_ID") & "'", CommandType.Text)
                ModalPopupExtender2.Show()
                'End If
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR cannot be canceled")
            End If





        ElseIf Lbtn = "EditGF" Then



        End If

        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
        'End Try

        TabContainer1.ActiveTabIndex = 1
        LoadActiveTAB()
    End Sub
    Protected Sub gvApprovedPR_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvApprovedPR.PageIndexChanging
        gvApprovedPR.DataSource = pApprovedPR
        gvApprovedPR.PageIndex = e.NewPageIndex
        gvApprovedPR.DataBind()
    End Sub
    Protected Sub ddSearchGF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Load_GFSearch()
    End Sub
    Protected Sub Load_GFSearch()
        If ddSearchGF.SelectedItem.Value = 1 Then
            Me.MultiView1.SetActiveView(Me.View1)
            Session("SearchBy") = "PRNumber"

        ElseIf ddSearchGF.SelectedItem.Value = 2 Then
            ddDept.DataSource = objDerived.GetDataTable("exec dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)
            ddDept.DataTextField = ("rc_name")
            ddDept.DataValueField = ("rc_id")
            ddDept.DataBind()
            ddDept.Items.Insert(0, "Select")

            Session("SearchBy") = "Department"
            Me.MultiView1.SetActiveView(Me.View2)

        ElseIf ddSearchGF.SelectedItem.Value = 3 Then
            txtFrom.Text = Date.Today.ToString("MM/dd/yyyy")
            txtTo.Text = Date.Today.ToString("MM/dd/yyyy")

            Session("SearchBy") = "DateApproved"
            Me.MultiView1.SetActiveView(Me.View3)
        End If
    End Sub
    Protected Sub btnSearchPRNumb_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = pApprovedPR.DefaultView
        myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtPRNo.Text) & "%'"
        gvApprovedPR.DataSource = myview
        gvApprovedPR.DataBind()

    End Sub
    Protected Sub btnSearchDept_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = pApprovedPR.DefaultView
        myview.RowFilter = "rc_id = '" & ddDept.SelectedItem.Value & "'"
        gvApprovedPR.DataSource = myview
        gvApprovedPR.DataBind()

    End Sub
    Protected Sub btnSearchDate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = pApprovedPR.DefaultView
        myview.RowFilter = "PR_Date >= '" & txtFrom.Text & "' AND PR_Date <= '" & txtTo.Text & "'"
        gvApprovedPR.DataSource = myview
        gvApprovedPR.DataBind()
    End Sub

    

    '================ APPROVED SPECIAL EDUCATION FUND ================
    Protected Sub lnkViewSEF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "printSEF"
    End Sub
    Protected Sub lnkCancelSEF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "CancelSEF"
    End Sub
    Protected Sub lnkReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "ReturnSEF"
    End Sub
    Protected Sub grdApprovedSEF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Lbtn = "printSEF" Then
                Session("prhdr_id") = grdApprovedSEF.SelectedDataKey("prhdr_id")
                Dim url As String = "rpt_purchase_request_pop_up.aspx?"
                Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
                ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

            ElseIf Lbtn = "CancelSEF" Then
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PR_OBR_ApprovedCancellation] WHERE prhdr_id = '" & grdApprovedSEF.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                If dt.Rows(0)("isApproved") = True Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "OBR has been approved, contact Budget Officer.")
                Else
                    '====== CANCEL APPROVED PURCHASE REQUEST
                    objDerived.GetRecords("UPDATE AMS.PR_Hdr SET IsCancelled = 1 WHERE prhdr_id = '" & grdApprovedSEF.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                    '====== CANCEL OBR (NOT APPROVED)
                    objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Hdr SET isCancelled = 1, dateCancelled = '" & Date.Today.ToString("MM/dd/yyyy") & "', ReasonForCancellation = 'PR Cancellation', Status = 'Cancelled' WHERE OBR_Hdr_ID = '" & dt.Rows(0)("OBR_Hdr_ID") & "'", CommandType.Text)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Approved PR and its OBR has been successfully cancelled.")
                End If

            ElseIf Lbtn = "ReturnSEF" Then

                '====== TEMPORARILY DISABLE FOR VERIFICATION
                Dim OBR_Rcv As Boolean
                OBR_Rcv = objDerived.GetValue("SELECT DISTINCT ISNULL(T_OBR_Hdr.isReceivedBO,0) FROM AMS.PR_Hdr INNER JOIN	LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Hdr AS T_OBR_Hdr ON AMS.PR_Hdr.prhdr_id = T_OBR_Hdr.PRHdr_ID " &
                                        " WHERE AMS.PR_Hdr.prhdr_id = '" & grdApprovedSEF.SelectedDataKey("prhdr_id") & "' ", CommandType.Text)

                If OBR_Rcv = 0 Then
                    Dim CheckID As Integer
                    CheckID = objDerived.GetValue("SELECT [mode_of_procurement_id] FROM [AMS].[PR_Hdr] WHERE [prhdr_id] = '" & grdApprovedSEF.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                    If CheckID = 0 Then
                        '====== RETURN FOR EDITING
                        objDerived.GetRecords("UPDATE [AMS].[PR_Hdr] SET [isFinal] = 0, [isEditable] = 1, [IsApproved] = 0 WHERE [prhdr_id] = '" & grdApprovedSEF.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase request has been successfully return for editing.")
                    Else
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase request is already on bid.")
                    End If

                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "OBR was already recieved, transaction is not permitted.")
                End If

            End If

        Catch ex As Exception

        End Try

        TabContainer1.ActiveTabIndex = 2
        LoadActiveTAB()

    End Sub
    Protected Sub grdApprovedSEF_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdApprovedSEF.DataSource = dtApprovedPR_SEF
        grdApprovedSEF.PageIndex = e.NewPageIndex
        grdApprovedSEF.DataBind()
    End Sub



    '================ APPROVED TRUST FUND ================
    Protected Sub lnkViewTF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "printTF"
    End Sub
    Protected Sub lnkCancelTF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "cancelTF"
    End Sub
    Protected Sub lnkReturnTF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "returnTF"
    End Sub
    Protected Sub grdApprovedTF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("prhdr_id") = grdApprovedTF.SelectedDataKey("prhdr_id")
        Try
            If Lbtn = "printTF" Then
                Dim url As String = "rpt_purchase_request_pop_up.aspx?"
                Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
                ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

            ElseIf Lbtn = "cancelTF" Then
                Dim CheckID As Integer
                CheckID = objDerived.GetValue("SELECT [mode_of_procurement_id] FROM [AMS].[PR_Hdr] WHERE [prhdr_id] = '" & grdApprovedTF.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                If CheckID = 0 Then
                    objDerived.GetRecords("UPDATE AMS.PR_Hdr SET IsCancelled = 1 WHERE prhdr_id = '" & grdApprovedTF.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase request has been successfully cancelled.")
                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Failed to cancel, purchase request is already on bid.")
                End If

            ElseIf Lbtn = "returnTF" Then
                Dim CheckID As Integer
                CheckID = objDerived.GetValue("SELECT [mode_of_procurement_id] FROM [AMS].[PR_Hdr] WHERE [prhdr_id] = '" & grdApprovedTF.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                If CheckID = 0 Then
                    '====== RETURN FOR EDITING
                    objDerived.GetRecords("UPDATE [AMS].[PR_Hdr] SET [isFinal] = 0, [isEditable] = 1, [IsApproved] = 0 WHERE [prhdr_id] = '" & grdApprovedTF.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase request has been successfully return for editing.")
                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase request is already on bid.")
                End If
            End If
        Catch ex As Exception

        End Try

        TabContainer1.ActiveTabIndex = 3
        LoadActiveTAB()
    End Sub
    Protected Sub grdApprovedTF_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdApprovedTF.DataSource = dtTrustFund
        grdApprovedTF.PageIndex = e.NewPageIndex
        grdApprovedTF.DataBind()

    End Sub
    Protected Sub btnOK1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK1.click

        objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_CAA_Hdr SET isCancelled = 1, dateCancelled = '" & Date.Today.ToString("MM/dd/yyyy") & "', ReasonForCancellation ='" & txtremarks.text & "', Status = 'Cancelled' WHERE OBR_Hdr_ID = '" & Session("CAA") & "'", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Approved PR and its CAA has been successfully cancelled.")

    End Sub
    Protected Sub btnReceiveDoc_Click(sender As Object, e As EventArgs)
        If txtReturn_remarks.text <> "" Then
            objDerived.GetRecords("UPDATE [AMS].[PR_Hdr] SET [isEditable] = 1,[isFinal] = 0 WHERE [prhdr_id] = '" & gvIncomingPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR has been successfully returned.")

        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill up the remarks.")
            ModalPopupExtender123.Show()
        End If
        LoadActiveTAB()

    End Sub

    Protected Function GetPRType(ByVal isNonPPMP As Object, ByVal prhdr_id As Object) As String
        ' Check if the row is empty (no ID or DBNull for prhdr_id)
        If prhdr_id Is DBNull.Value OrElse prhdr_id Is Nothing Then
            Return ""  ' Display nothing for empty rows with no ID

            ' Check if the value is DBNull or nothing for isNonPPMP
        ElseIf isNonPPMP Is DBNull.Value OrElse isNonPPMP Is Nothing Then
            ' If isNonPPMP is NULL, return "PPMP-Based"
            Return "PPMP-Based"

            ' Check if the value is 0 or NULL (treated as "PPMP-Based")
        ElseIf Convert.ToInt32(isNonPPMP) = 0 Then
            Return "PPMP-Based"

            ' Check if the value is 1 or True (treated as "Non-PPMP")
        ElseIf Convert.ToInt32(isNonPPMP) = 1 Then
            Return "Non-PPMP"
        End If

        ' Default case if none of the conditions are met (optional)
        Return ""
    End Function



End Class
