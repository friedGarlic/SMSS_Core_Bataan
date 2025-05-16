Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class t_pre_procurement_public_bidding
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim hdr As New t_pre_procurement_hdr
    Dim dtl As New t_pre_procurement_dtl
    'Private getprofile As New ProfileCommon

#Region "property"
    Private Property dtPreProcurement() As DataTable
        Get
            Return CType(Session("dtPreProcurement"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPreProcurement") = value
        End Set
    End Property
    Private Property project() As DataTable
        Get
            Return CType(Session("project"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("project") = value
        End Set
    End Property
    Private Property pPreProcurementDetail() As DataTable
        Get
            Return CType(Session("pPreProcurementDetail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPreProcurementDetail") = value
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
    Private Property pDays() As DataTable
        Get
            Return CType(Session("pDays"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pDays") = value
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

    Private Property ProjectName() As String
        Get
            Return CType(Session("ProjectName"), String)
        End Get
        Set(ByVal value As String)
            Session("ProjectName") = value
        End Set
    End Property

    Private Property LbtnTransactionValue() As Integer
        Get
            Return CType(Session("LbtnTransactionValue"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("LbtnTransactionValue") = value
        End Set
    End Property
#End Region
#Region "Functions"
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("DateEvaluated", GetType(Date))
        dt.Columns.Add("GA_Title", GetType(String))
        dt.Columns.Add("PRCount", GetType(Integer))
        dt.Columns.Add("TotalABC", GetType(Decimal))
        dt.Columns.Add("obr_evaluation_hdr_id", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("DateEvaluated") = DBNull.Value
            dr("GA_Title") = DBNull.Value
            dr("PRCount") = DBNull.Value
            dr("TotalABC") = DBNull.Value
            dr("obr_evaluation_hdr_id") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("rc_name", GetType(String))
        dt.Columns.Add("Function_Desc", GetType(String))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("PR_Date", GetType(Date))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Long))
        dt.Columns.Add("Project_ID", GetType(Long))
        dt.Columns.Add("Program_id", GetType(Long))
        dt.Columns.Add("Transaction_type", GetType(Integer))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("F_ID", GetType(Integer))
        dt.Columns.Add("isPublicInfra", GetType(Boolean))
        dt.Columns.Add("isStraight", GetType(Boolean))
        dt.Columns.Add("remarks", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("rc_name") = DBNull.Value
            dr("Function_Desc") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("PR_Date") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("Project_ID") = DBNull.Value
            dr("Program_id") = DBNull.Value
            dr("Transaction_type") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("F_ID") = DBNull.Value
            dr("isPublicInfra") = False
            dr("isStraight") = False
            dr("remarks") = DBNull.Value
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

            dtPreProcurement = objDerived.GetDataTable("EXEC [AMS].[sp_PreProcurement]", CommandType.Text)
            If dtPreProcurement.Rows.Count < 5 Then
                dtPreProcurement.Merge(createdatatable1(5 - dtPreProcurement.Rows.Count))
            End If
            grdPreProcurement.DataSource = dtPreProcurement
            grdPreProcurement.DataBind()

            gvIncomingPR.DataSource = createdatatable(5)
            gvIncomingPR.DataBind()

            Me.MultiView1.SetActiveView(Me.View1)
        End If
    End Sub

    Protected Sub grdPreProcurement_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If Session("Action") = "Account" Then
            pIncomingPR = objDerived.GetDataTable("EXEC [AMS].[sp_PreProcurement_PRList] '" & grdPreProcurement.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)
            gvIncomingPR.DataSource = pIncomingPR
            gvIncomingPR.DataBind()

            ProjectName = objDerived.GetValue("EXEC [AMS].[sp_Consolidated_ProjectName] '" & grdPreProcurement.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)

            If pIncomingPR.Rows.Count <> 0 Then
                Dim x As Decimal = 0
                For i As Integer = 0 To pIncomingPR.Rows.Count - 1
                    x = x + CType(gvIncomingPR.Rows(i).FindControl("lblABC"), Label).Text
                Next

                CType(gvIncomingPR.FooterRow.Cells(5).FindControl("lblTotalABC"), Label).Text = FormatNumber(x, 2)

                'Optimize code
                Dim totalABC As Double = grdPreProcurement.SelectedDataKey("TotalABC")
                Dim bidDocAmount As Double

                Select Case totalABC
                    Case Is < 500000
                        bidDocAmount = 500
                    Case 500001 To 1000000
                        bidDocAmount = 1000
                    Case 1000001 To 5000000
                        bidDocAmount = 5000
                    Case 5000001 To 10000000
                        bidDocAmount = 10000
                    Case 10000001 To 50000000
                        bidDocAmount = 25000
                    Case 50000001 To 500000000
                        bidDocAmount = 50000
                    Case Else
                        bidDocAmount = 75000
                End Select

                txtBidDoc.Text = FormatNumber(bidDocAmount, 2)


                'old code
                'If grdPreProcurement.SelectedDataKey("TotalABC") < 500000 Then
                '    txtBidDoc.Text = FormatNumber(500, 2)
                'ElseIf grdPreProcurement.SelectedDataKey("TotalABC") > 500001 And grdPreProcurement.SelectedDataKey("TotalABC") < 1000000 Then
                '    txtBidDoc.Text = FormatNumber(1000, 2)
                'ElseIf grdPreProcurement.SelectedDataKey("TotalABC") > 1000001 And grdPreProcurement.SelectedDataKey("TotalABC") < 5000000 Then
                '    txtBidDoc.Text = FormatNumber(5000, 2)
                'ElseIf grdPreProcurement.SelectedDataKey("TotalABC") > 5000001 And grdPreProcurement.SelectedDataKey("TotalABC") < 10000000 Then
                '    txtBidDoc.Text = FormatNumber(10000, 2)
                'ElseIf grdPreProcurement.SelectedDataKey("TotalABC") > 10000001 And grdPreProcurement.SelectedDataKey("TotalABC") < 50000000 Then
                '    txtBidDoc.Text = FormatNumber(25000, 2)
                'ElseIf grdPreProcurement.SelectedDataKey("TotalABC") > 50000001 And grdPreProcurement.SelectedDataKey("TotalABC") < 500000000 Then
                '    txtBidDoc.Text = FormatNumber(50000, 2)
                'ElseIf grdPreProcurement.SelectedDataKey("TotalABC") > 500000001 Then
                '    txtBidDoc.Text = FormatNumber(75000, 2)
                'End If


                txtDateReceive.Text = Date.Today.ToString("MM/dd/yyyy")
                txtContractName.Text = ProjectName

                btnsave.Enabled = True
                txtProjectReferenceNumber2.Enabled = True
                txtITBNumber.Enabled = True
                txtDateReceive.Enabled = True
                txtTime.Enabled = True
                ddTime.Enabled = True
                txtOpeningVenue.Enabled = True
                txtProjectLocation.Enabled = True
                txtContractName.Enabled = True

            Else
                txtProjectReferenceNumber2.Enabled = False
                txtITBNumber.Enabled = False
                txtDateReceive.Enabled = False
                txtTime.Enabled = False
                ddTime.Enabled = False
                txtOpeningVenue.Enabled = False
                txtProjectLocation.Enabled = False

            End If

        ElseIf Session("Action") = "Cancel" Then
            Try
                Dim dt As New DataTable
                dt = objDerived.GetDataTable("Select * FROM [dbo].[View_Return_Canvass] WHERE obr_evaluation_hdr_id = '" & grdPreProcurement.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)

                For i As Integer = 0 To dt.Rows.Count - 1
                        '======= UPDATE AMS.PR_Hdr (mode_of_procurement_id)
                        objDerived.GetRecords("UPDATE AMS.PR_Hdr SET mode_of_procurement_id = 0,isOnBid = 0 WHERE prhdr_id = '" & dt.Rows(i)("prhdr_id") & "'", CommandType.Text)
                    Next

                    '======= DELETE RECORDS IN AMS.obr_evaluation_hdr
                    objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_hdr WHERE obr_evaluation_hdr_id = '" & dt.Rows(0)("obr_evaluation_hdr_id") & "'", CommandType.Text)
                    objDerived.GetRecords("DELETE FROM AMS.obr_evaluation_dtl WHERE obr_evaluation_hdr_id = '" & dt.Rows(0)("obr_evaluation_hdr_id") & "'", CommandType.Text)

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "PR has been successfully returned to OBR Evaluation.")

                    dtPreProcurement = objDerived.GetDataTable("EXEC [AMS].[sp_PreProcurement]", CommandType.Text)
                    If dtPreProcurement.Rows.Count < 5 Then
                        dtPreProcurement.Merge(createdatatable1(5 - dtPreProcurement.Rows.Count))
                    End If
                    grdPreProcurement.DataSource = dtPreProcurement
                    grdPreProcurement.DataBind()

                    gvIncomingPR.DataSource = createdatatable(5)
                    gvIncomingPR.DataBind()

                    txtBidDoc.Text = ""
                    txtContractName.Text = ""
                    txtProjectReferenceNumber2.Text = ""
                    txtOpeningVenue.Text = ""
                    txtProjectLocation.Text = ""

                    Catch ex As Exception
                    End Try
                End If
    End Sub

    Protected Sub gvIncomingPR_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pIncomingPR = objDerived.GetDataTable("EXEC [AMS].[sp_PreProcurement_PRList] '" & grdPreProcurement.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)
        If pIncomingPR.Rows.Count < 5 Then
            pIncomingPR.Merge(createdatatable(5 - pIncomingPR.Rows.Count))
        End If
        gvIncomingPR.PageIndex = e.NewPageIndex
        gvIncomingPR.DataSource = pIncomingPR
        gvIncomingPR.DataBind()

    End Sub

    Protected Sub grdPreProcurement_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdPreProcurement, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdPreProcurement_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtPreProcurement = objDerived.GetDataTable("EXEC [AMS].[sp_PreProcurement]", CommandType.Text)
        If dtPreProcurement.Rows.Count < 5 Then
            dtPreProcurement.Merge(createdatatable1(5 - dtPreProcurement.Rows.Count))
        End If
        grdPreProcurement.PageIndex = e.NewPageIndex
        grdPreProcurement.DataSource = dtPreProcurement
        grdPreProcurement.DataBind()
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If txtProjectReferenceNumber2.Text = "" Or txtOpeningVenue.Text = "" Or txtITBNumber.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Fill up all fields.")
            Exit Sub
        End If

        ' Try
        If RadioButtonList1.SelectedIndex = 0 Then 'Goods
                Dim time As String = txtTime.Text & "  " & ddTime.SelectedItem.Text

            hdr.obr_evaluation_hdr_id = grdPreProcurement.SelectedDataKey("obr_evaluation_hdr_id")
            Dim a As String
            If txtBidDoc.Text = "" Then
                a = 0
            Else
                a = txtBidDoc.Text
            End If
            hdr.bid_docs = a
            'hdr.bid_security = txtBidSecurity.Text
            hdr.mode_of_procurement_id = 1
                hdr.project_name = txtContractName.Text
                hdr.project_location = txtProjectLocation.Text
                hdr.project_reference_no = txtProjectReferenceNumber2.Text
                'hdr.ITB_Number = txtITBNumber.Text
                hdr.ABC = grdPreProcurement.SelectedDataKey("TotalABC")
                hdr.opening_venue = txtOpeningVenue.Text
                If txtDateReceive.Text <= Date.Today Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Enter a valid date")
                Else
                    hdr.opening_date = txtDateReceive.Text
                End If
                hdr.opening_time = time
                    hdr.withBid = False
                    hdr.isRebid = False
                    hdr.withWinner = False
                    hdr.withPO = False
                    hdr.BACC = ""
                    hdr.BACVC = ""
                    hdr.BAC1 = ""
                    hdr.BAC2 = ""
                    hdr.BAC3 = ""
                    hdr.TWGH = ""
                    hdr.TWGM = ""
                    hdr.ENDUSER = ""
                    hdr.Transaction_type = grdPreProcurement.SelectedDataKey("Transaction_type")
                    hdr.F_ID = 1
                    hdr.resolution_number_date = "01/01/1900"
                    hdr.declarationDate = "01/01/1900"
                    hdr.transaction_date = txtDateReceive.Text
                    hdr.withNOA = False
                    hdr.withNTP = False
                    hdr.dateNTP = "01/01/1900"
                    hdr.dateNOA = "01/01/1900"
                    'hdr.isStraight = grdPreProcurement.SelectedDataKey("isStraight")
                    If rdisInfra.SelectedItem.Value = 1 Then
                        hdr.isPublicInfra = True
                    ElseIf rdisInfra.SelectedItem.Value = 0 Then
                        hdr.isPublicInfra = False
                    End If

                    Dim hdrid As Long = hdr.save()
                    Session("pre_procurement_hdr_id") = hdrid

                    For i As Integer = 0 To gvIncomingPR.Rows.Count - 1
                        dtl.pre_procurement_hdr_id = hdrid
                        dtl.obr_evaluation_dtl_id = pIncomingPR.Rows(i)("obr_evaluation_dtl_id")
                        dtl.ABC = pIncomingPR.Rows(i)("ABC")
                        dtl.save()
                    Next

                    objDerived.GetRecords("UPDATE AMS.obr_evaluation_hdr SET withPreProcurement = 1 WHERE obr_evaluation_hdr_id = '" & grdPreProcurement.SelectedDataKey("obr_evaluation_hdr_id") & "'", CommandType.Text)

                    dtPreProcurement = objDerived.GetDataTable("EXEC [AMS].[sp_PreProcurement]", CommandType.Text)
                    If dtPreProcurement.Rows.Count < 5 Then
                        dtPreProcurement.Merge(createdatatable1(5 - dtPreProcurement.Rows.Count))
                    End If
                    grdPreProcurement.DataSource = dtPreProcurement
                    grdPreProcurement.DataBind()

                    'gvIncomingPR.DataSource = createdatatable(5)
                    'gvIncomingPR.DataBind()

                    Me.MultiView1.SetActiveView(Me.View1)


                Else '=-= Public Infra
                    hdr.obr_evaluation_hdr_id = gvIncomingPR_infra.SelectedDataKey(1)
                hdr.bid_docs = txtBidDoc.Text
                'hdr.bid_security = txtBidSecurity.Text
                hdr.mode_of_procurement_id = 1
                hdr.project_location = txtProjectLocation.Text
                hdr.project_reference_no = txtProjectReferenceNumber2.Text
                hdr.project_name = ""
                hdr.ABC = gvIncomingPR_infra.SelectedDataKey(5)
                hdr.opening_venue = txtOpeningVenue.Text
                hdr.opening_date = txtDateReceive.Text
                hdr.withBid = False
                hdr.isRebid = False
                hdr.withWinner = False
                hdr.withPO = False
                hdr.BACC = objDerived.GetValue("Select Name from dbo.view_BAC where BAC_PostionID = 1 ", CommandType.Text)
                hdr.BACVC = objDerived.GetValue("Select Name from dbo.view_BAC where BAC_PostionID = 2 ", CommandType.Text)
                hdr.BAC1 = objDerived.GetValue("Select Name from dbo.view_BAC where BAC_PostionID = 3 ", CommandType.Text)
                hdr.BAC2 = objDerived.GetValue("Select Name from dbo.view_BAC where BAC_PostionID = 4 ", CommandType.Text)
                hdr.BAC3 = objDerived.GetValue("Select Name from dbo.view_BAC where BAC_PostionID = 5", CommandType.Text)
                hdr.TWGH = ""
                hdr.TWGM = ""
                hdr.ENDUSER = ""
                hdr.Representative1 = ""
                hdr.Representative2 = ""
                hdr.Transaction_type = LbtnTransactionValue
                hdr.F_ID = Me.Session("F_ID")
                hdr.resolution_number_date = "01/01/1900"
                hdr.declarationDate = "01/01/1900"
                hdr.transaction_date = Date.Today.ToString("MM/dd/yyyy")
                hdr.withNOA = False
                hdr.withNTP = False
                hdr.dateNTP = "01/01/1900"
                hdr.dateNOA = "01/01/1900"
                hdr.isPublicInfra = gvIncomingPR_infra.SelectedDataKey(9)
                hdr.isStraight = gvIncomingPR_infra.SelectedDataKey(10)
                Dim hdrid As Long = hdr.save()
                Me.Session("pre_procurement_hdr_id") = hdrid
                dtl.pre_procurement_hdr_id = hdrid
                dtl.obr_evaluation_dtl_id = gvIncomingPR_infra.SelectedDataKey(7) ''pIncomingPR.Rows(i)("obr_evaluation_dtl_id")
                dtl.ABC = gvIncomingPR_infra.SelectedDataKey(5)
                dtl.save()
                objDerived.GetRecords("Update AMS.obr_evaluation_dtl set withPreProcurement=1 where prhdr_id=" & gvIncomingPR_infra.SelectedDataKey(0) & "", CommandType.Text)
                pIncomingPR = Nothing
                pIncomingPR = objDerived.GetDataTable("select * from  ams.vw_pre_procurement_public_bidding_Public_infra", CommandType.Text)
                If pIncomingPR.Rows.Count < 8 Then
                    pIncomingPR.Merge(createdatatable(7 - pIncomingPR.Rows.Count))
                End If
                gvIncomingPR_infra.DataSource = pIncomingPR
                gvIncomingPR_infra.DataBind()
                MultiView1.SetActiveView(View2)
            End If

            txtProjectReferenceNumber2.Text = ""
            txtProjectLocation.Text = ""
            txtContractName.Text = ""
            txtBidDoc.Text = "0.00"
            txtDateReceive.Text = ""
            txtOpeningVenue.Text = ""

            btnsave.Enabled = False

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been succesfully saved.")

            ddTime.SelectedIndex = 0
            btnprintOP.Enabled = True
            btnBidForm.Enabled = True
        'Catch ex As Exception
        'End Try
    End Sub

    Protected Sub txtBidDoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtBidDoc.Text = "" Then
            txtBidDoc.Text = "0.00"
        End If
        txtBidDoc.Text = FormatNumber(CType(txtBidDoc.Text, Decimal), 2)

    End Sub

    Protected Sub txtProjectName2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ScriptManager.GetCurrent(Me.Page).SetFocus(txtProjectReferenceNumber2)
    End Sub

    Protected Sub txtProjectReferenceNumber2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ScriptManager.GetCurrent(Me.Page).SetFocus(txtProjectLocation)
    End Sub

    'Protected Sub txtProjectLocation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ScriptManager.GetCurrent(Me.Page).SetFocus(txtBidDoc)
    'End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "cb"
    End Sub

    Protected Sub btnprintOP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "BID"

        Dim url As String = "rpt_OP.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        'Me.Page.Response.Redirect("~/bidding/rpt_order_of_payment.aspx")
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        pIncomingPR = Nothing
        If RadioButtonList1.SelectedIndex = 0 Then
            Session("isPublicInfra") = 0
            pIncomingPR = objDerived.GetDataTable("select * from ams.vw_pre_procurement_public_bidding_goods", CommandType.Text)
            If pIncomingPR.Rows.Count < 8 Then
                pIncomingPR.Merge(createdatatable(7 - pIncomingPR.Rows.Count))
            End If
            gvIncomingPR.DataSource = pIncomingPR
            gvIncomingPR.DataBind()
            Me.MultiView1.SetActiveView(Me.View1)

        Else
            Session("isPublicInfra") = 1
            pIncomingPR = objDerived.GetDataTable("select * from ams.vw_pre_procurement_public_bidding_Public_infra", CommandType.Text)
            If pIncomingPR.Rows.Count < 8 Then
                pIncomingPR.Merge(createdatatable(7 - pIncomingPR.Rows.Count))
            End If
            gvIncomingPR_infra.DataSource = pIncomingPR
            gvIncomingPR_infra.DataBind()
            Me.MultiView1.SetActiveView(Me.View2)

        End If

        btnsave.Enabled = False
        btnprintOP.Enabled = False

        project = Nothing

        txtBidDoc.Text = "0.00"
    End Sub

    Protected Sub gvIncomingPR_infra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("F_ID") = gvIncomingPR_infra.SelectedDataKey(8)

        pIncomingPR.Rows(gvIncomingPR_infra.SelectedIndex)("isChecked") = True
        LbtnTransactionValue = CType(gvIncomingPR_infra.SelectedDataKey(6), Integer)
        txtBidDoc.Text = FormatNumber(CType(gvIncomingPR_infra.SelectedDataKey(5), Decimal) * 0.001, 2)

        btnprintOP.Enabled = False
        btnsave.Enabled = True

    End Sub

    Protected Sub btnBidForm_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim url As String = "rpt_BidForm.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub

    Protected Sub gvIncomingPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("prhdr_id") = gvIncomingPR.SelectedDataKey("prhdr_id")
    End Sub

    Protected Sub gvIncomingPR_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvIncomingPR, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub lbAccount_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Action") = "Account"
    End Sub

    Protected Sub lbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Action") = "Cancel"
    End Sub
End Class
