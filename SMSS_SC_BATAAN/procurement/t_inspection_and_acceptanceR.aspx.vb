Imports System.Data

Partial Class Procurement_t_inspection_and_acceptance
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

#Region "Property"

    Private Property dtAIR() As DataTable
        Get
            Return CType(Session("dtAIR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAIR") = value
        End Set
    End Property

    Private Property SelectedCommand() As String
        Get
            Return CType(Session("SelectedCommand"), String)
        End Get
        Set(ByVal value As String)
            Session("SelectedCommand") = value
        End Set
    End Property

    Private Property dtIAR() As DataTable
        Get
            Return CType(Session("dtIAR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtIAR") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            LoadRBChoice()

            dtAIR = objDerived.GetDataTable("EXEC [AMS].[sp_RQ_AIR]", CommandType.Text)
            grdAIR.DataSource = dtAIR
            grdAIR.DataBind()

            txtPONumber.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchPO.ClientID & "')")
            txtdatefrom.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")
            txtdateto.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")
        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        LoadRBChoice()
    End Sub

    Protected Sub LoadRBChoice()
        Select Case (RadioButtonList1.SelectedIndex)
            Case 0
                MultiView1.SetActiveView(View1)
                txtPONumber.Text = ""

            Case 1
                MultiView1.SetActiveView(View3)
                ddDepartment.DataSource = objDerived.GetDataTable("SELECT DISTINCT RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
                ddDepartment.DataTextField = ("RC_Name")
                ddDepartment.DataValueField = ("RC_ID")
                ddDepartment.DataBind()
                ddDepartment.Items.Insert(0, "Select")

                ddFunction.Items.Insert(0, "Select")

            Case 2
                MultiView1.SetActiveView(View4)
                txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
                txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")

        End Select
    End Sub

    Protected Sub LoadSearching()
        Dim myview As DataView
        myview = dtAIR.DefaultView

        If RadioButtonList1.SelectedItem.Value = 1 Then
            myview.RowFilter = "PO_No like '%" & txtPONumber.Text & "%'"
        ElseIf RadioButtonList1.SelectedItem.Value = 2 Then
            myview.RowFilter = "RC_ID = " & ddDepartment.SelectedItem.Value & " AND Function_ID = " & ddFunction.SelectedItem.Value & " "
        ElseIf RadioButtonList1.SelectedItem.Value = 3 Then
            myview.RowFilter = "Date_Accepted >= '" & txtdatefrom.Text & "' AND Date_Accepted <= '" & txtdateto.Text & "'"
        End If

        grdAIR.DataSource = myview
        grdAIR.DataBind()

    End Sub

    Protected Sub btnSearchPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchPO.Click
        LoadSearching()

    End Sub

    Protected Sub btnSearchRC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchRC.Click
        LoadSearching()

    End Sub

    Protected Sub btnByDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnByDate.Click
        LoadSearching()

    End Sub

    Protected Sub grdAIR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAIR.SelectedIndexChanged
        Session("Page") = "RQ"
        Session("AIRHdr_ID") = grdAIR.SelectedDataKey("AIRHdr_ID")

        'Try
        If SelectedCommand = "Preview" Then
                Me.Page.Response.Redirect("~/MainReports/IAR_Reports.aspx")
                'Me.Page.Response.Redirect("~/Procurement/rpt_inspection_and_acceptance.aspx")

            ElseIf SelectedCommand = "Return" Then
                dtIAR = objDerived.GetDataTable("EXEC [AMS].[sp_Edit_IARList] '" & grdAIR.SelectedDataKey("AIRHdr_ID") & "'", CommandType.Text)

                If grdAIR.SelectedDataKey("AllotmentClass_ID") = 2 Then
                    If dtIAR.Rows.Count = 0 Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Items already been issued, IAR cannot be return.")
                    Else
                        Dim dt As New DataTable
                        dt = objDerived.GetDataTable("SELECT DISTINCT AMS.AIR_Hdr.AIRHdr_ID, AMS.AIR_Dtl.AIRDtl_ID, AMS.AIR_Dtl.Item_ID, AMS.AIR_Dtl.Qty, AMS.AIR_Dtl.Cost, AMS.AIR_Hdr.POHdr_ID, " &
                                        " AMS.Stock.StockID, AMS.TbStock_Ledger.StockLedger_ID  FROM AMS.AIR_Dtl INNER JOIN AMS.AIR_Hdr ON AMS.AIR_Dtl.AIRHdr_ID = AMS.AIR_Hdr.AIRHdr_ID INNER JOIN " &
                                        " AMS.Stock ON AMS.AIR_Hdr.POHdr_ID = AMS.Stock.POHdr_ID AND AMS.AIR_Dtl.Item_ID = AMS.Stock.Item_ID INNER JOIN " &
                                        " AMS.TbStock_Ledger ON AMS.Stock.StockID = AMS.TbStock_Ledger.StockID AND AMS.AIR_Dtl.Item_ID = AMS.TbStock_Ledger.Item_ID " &
                                        " WHERE AMS.AIR_Hdr.AIRHdr_ID = '" & grdAIR.SelectedDataKey("AIRHdr_ID") & "'", CommandType.Text)

                        For i As Integer = 0 To dt.Rows.Count - 1
                            objDerived.Execute("DELETE From [AMS].[TbStock_Ledger] Where [StockLedger_ID] = '" & dt.Rows(i)("StockLedger_ID") & "'", CommandType.Text)
                            objDerived.Execute("DELETE From [AMS].[Stock] Where [StockID] = '" & dt.Rows(i)("StockID") & "'", CommandType.Text)
                        Next

                        objDerived.Execute("DELETE From [AMS].[AIR_Hdr] Where [AIRHdr_ID] = '" & grdAIR.SelectedDataKey("AIRHdr_ID") & "'", CommandType.Text)
                        objDerived.Execute("DELETE From [AMS].[AIR_Dtl] Where [AIRHdr_ID] = '" & grdAIR.SelectedDataKey("AIRHdr_ID") & "'", CommandType.Text)

                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "IAR has been successfully returned.")
                    End If

                ElseIf grdAIR.SelectedDataKey("AllotmentClass_ID") = 3 Then
                    'If dtIAR.Rows.Count = 0 Then
                    '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Items already been issued, IAR cannot be return.")
                    'Else
                    '    Dim dt As New DataTable
                    '    dt = objDerived.GetDataTable("SELECT AMS.Property.Property_ID, AMS.Property_Dtl.PropertyDetai_ID, AMS.TbProperty_Ledger.Ledger_ID, AMS.Property_Dtl.PropertyNo, AMS.AIR_Hdr.AIRHdr_ID " &
                    '                    " FROM AMS.Property INNER JOIN  AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID INNER JOIN " &
                    '                    " AMS.TbProperty_Ledger ON AMS.Property_Dtl.PropertyNo = AMS.TbProperty_Ledger.PropertyNo INNER JOIN " &
                    '                    " AMS.AIR_Hdr ON AMS.Property.POHdr_ID = AMS.AIR_Hdr.POHdr_ID " &
                    '                    " WHERE AMS.AIR_Hdr.AIRHdr_ID = '" & grdAIR.SelectedDataKey("AIRHdr_ID") & "'", CommandType.Text)
                    '    For i As Integer = 0 To dt.Rows.Count - 1
                    '        objDerived.Execute("DELETE From [AMS].[TbStock_Ledger] Where [StockLedger_ID] = '" & dt.Rows(i)("StockLedger_ID") & "'", CommandType.Text)
                    '        objDerived.Execute("DELETE From [AMS].[Stock] Where [StockID] = '" & dt.Rows(i)("StockID") & "'", CommandType.Text)
                    '    Next
                    'End If

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "IAR under capital outlay is still in progress.")
                End If

            End If
        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, pls contact system admin.")
        'End Try
    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddDepartment.SelectedIndexChanged


        btnSearchRC.Enabled = False

        ddFunction.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & ddDepartment.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")

    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddFunction.SelectedIndexChanged
        btnSearchRC.Enabled = True
    End Sub

    Protected Sub grdAIR_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdAIR.DataSource = dtAIR
        grdAIR.PageIndex = e.NewPageIndex
        grdAIR.DataBind()
    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)
        SelectedCommand = "Preview"
    End Sub
    Protected Sub lnkReturn_Click(sender As Object, e As EventArgs)
        SelectedCommand = "Return"
    End Sub
End Class
