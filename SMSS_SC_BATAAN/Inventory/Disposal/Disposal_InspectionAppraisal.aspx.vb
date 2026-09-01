Imports System.Data
Partial Class Inventory_Disposal_Disposal_InspectionAppraisal
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim objDerived As New DerivedDal
    Dim hdr As New Disposal_inspection_hdr
    Dim dtl As New Disposal_inspection_dtl


#Region "Variables"
    Public Function temo_dtInspection(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("IIRUPHdr_ID", GetType(Integer))
        dt.Columns.Add("IIRUP_Date", GetType(Date))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("IIRUPHdr_ID") = DBNull.Value
            dr("IIRUP_Date") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function temo_dtInspection_Items(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Property_ID", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("propertyNo", GetType(String))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Property_ID") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("propertyNo") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function temp_dtAppraisal(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("IIRUPHdr_ID", GetType(Integer))
        dt.Columns.Add("WMHdr_ID", GetType(Integer))
        dt.Columns.Add("IIRUP_Date", GetType(Date))
        dt.Columns.Add("IIRUP_No", GetType(String))
        dt.Columns.Add("particulars", GetType(String))
        dt.Columns.Add("AppraisedVal", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("IIRUPHdr_ID") = DBNull.Value
            dr("WMHdr_ID") = DBNull.Value
            dr("IIRUP_Date") = DBNull.Value
            dr("IIRUP_No") = DBNull.Value
            dr("particulars") = DBNull.Value
            dr("AppraisedVal") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function temp_dtAppraisal_Items(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("IIRUPDtl_ID", GetType(Integer))
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("IIRUPDtl_ID") = DBNull.Value
            dr("ID") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Private Property dtInspections() As DataTable
        Get
            Return CType(Session("dtInspections"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtInspections") = value
        End Set
    End Property

    Private Property dtInspections_Items() As DataTable
        Get
            Return CType(Session("dtInspections_Items"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtInspections_Items") = value
        End Set
    End Property

    Private Property dtAppraisal() As DataTable
        Get
            Return CType(Session("dtAppraisal"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAppraisal") = value
        End Set
    End Property
    Private Property dtAppraisal_Items() As DataTable
        Get
            Return CType(Session("dtAppraisal_Items"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAppraisal_Items") = value
        End Set
    End Property
#End Region

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function


    Private Sub Inventory_Disposal_Disposal_InspectionAppraisal_Load(sender As Object, e As EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@username"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/etc/unauthorizedpage.aspx")
        End If

        If Not Page.IsPostBack Then
            loadPage()

        End If


    End Sub

    Protected Sub loadPage()
        If btnTab1_Inspection.CssClass = "TabButton_Active" And btnTab2_Appraisal.CssClass = "TabButton_InActive" Then
            dtInspections = objDerived.GetDataTable("SELECT A.IIRUPHdr_ID, A.IIRUP_Date, CASE WHEN A.Function_ID = 86 THEN B.RC_Name ELSE B.Function_Desc END AS RC_Name, CONVERT(BIT,1) AS isVisible     " &
                                                " FROM AMS.IIRUP_Hdr AS A INNER JOIN DBO.View_RespCenter_withFunctions AS B ON A.RC_ID = B.RC_ID                    " &
                                                " AND A.Function_ID = B.Function_ID WHERE A.IsInspectioned = 0 ORDER BY A.IIRUPHdr_ID DESC", CommandType.Text)
            If dtInspections.Rows.Count < 5 Then
                dtInspections.Merge(temo_dtInspection(4 - dtInspections.Rows.Count))
            End If
            grdInspection.DataSource = dtInspections
            grdInspection.DataBind()

            grdInspection_Items.DataSource = temo_dtInspection_Items(5)
            grdInspection_Items.DataBind()

            mvTabs.SetActiveView(Me.vwTab1_Inspection)
            mvCategory.SetActiveView(Me.vwProperty)

        ElseIf btnTab1_Inspection.CssClass = "TabButton_InActive" And btnTab2_Appraisal.CssClass = "TabButton_Active" Then

            dtAppraisal = objDerived.GetDataTable("EXEC [AMS].[sp_ListForAppraisal]", CommandType.Text)
            If dtAppraisal.Rows.Count <= 5 Then
                dtAppraisal.Merge(temp_dtAppraisal(4 - dtAppraisal.Rows.Count))
            End If
            grdDisposalAppraisal.DataSource = dtAppraisal
            grdDisposalAppraisal.DataBind()

            'grdAppraisal_Items.DataSource = temp_dtAppraisal_Items(2)
            'grdAppraisal_Items.DataBind()

            txtSubject.Text = "Appraisal of various properties intended for disposal as listed under attached documents page/s. Inventory and Inspection Report of Unserviceable Property (I&I Report) dated " & CType(Date.Today.ToLongDateString, String)
            txtFindings.Text = "1. The subject properties were all kept inside a guarded bodega and systematically arranged in accordance with the listings indicated under I & I Report." & Environment.NewLine & "2. " & Environment.NewLine & "3. "
            txtValuation.Text = "1. The condition of the above-subject properties has been assessed thru ocular inspection" & Environment.NewLine & "2. The vehicle was appraised on the basis of the available Current Market Value (CMV) taken from advertised price of the " & Environment.NewLine & "3. Determination of the appraised value is based on the COA Revised Guidelines on APpraisal of Property other than Real Estate, Antique Property and Works of Art." & Environment.NewLine & "4. " & Environment.NewLine & "5. "

            mvTabs.SetActiveView(Me.vwTab2_Appraisal)

        End If
    End Sub

    Private Sub btnTab1_Inspection_Click(sender As Object, e As EventArgs) Handles btnTab1_Inspection.Click
        btnTab1_Inspection.CssClass = "TabButton_Active"
        btnTab2_Appraisal.CssClass = "TabButton_InActive"

        loadPage()
    End Sub
    Private Sub btnTab2_Appraisal_Click(sender As Object, e As EventArgs) Handles btnTab2_Appraisal.Click
        btnTab1_Inspection.CssClass = "TabButton_InActive"
        btnTab2_Appraisal.CssClass = "TabButton_Active"

        loadPage()
    End Sub









    '=========================================================================================
    Private Sub grdInspection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdInspection.SelectedIndexChanged
        Try
            dtInspections_Items = objDerived.GetDataTable("EXEC [AMS].[sp_Disposal_Inspection_ItemList]  '" & grdInspection.SelectedDataKey("IIRUPHdr_ID") & "'", CommandType.Text)
            grdInspection_Items.DataSource = dtInspections_Items
            grdInspection_Items.DataBind()

            Dim propnum As String = dtInspections_Items.Rows(0)("PropertyNo")
            Dim GAID As String = dtInspections_Items.Rows(0)("GA_ID")

            For i As Integer = 0 To Me.grdInspection_Items.Rows.Count - 1
                CType(grdInspection_Items.Rows(i).FindControl("ddMD"), DropDownList).SelectedIndex = dtInspections_Items.Rows(i)("MD")
                Dim txtqty As TextBox = CType(grdInspection_Items.Rows(i).FindControl("txtappraisedval"), TextBox)
                Dim txtweight As TextBox = CType(grdInspection_Items.Rows(i).FindControl("txtWeight"), TextBox)
                Dim txtcuramnt As TextBox = CType(grdInspection_Items.Rows(i).FindControl("txtCurAmnt"), TextBox)

                If GAID = "1166" Then
                    txtqty.Enabled = True
                    txtweight.Enabled = False
                    txtcuramnt.Enabled = False
                Else
                    txtqty.Enabled = False
                    txtweight.Enabled = True
                    txtcuramnt.Enabled = True
                End If
            Next


            Session("TransID") = grdInspection.SelectedDataKey(0)
            Session("IIRUPHdr_ID") = grdInspection.SelectedDataKey("IIRUPHdr_ID")

            txtOpenDate.Text = Date.Today.ToString("MM/dd/yyyy")
            txtIIRUP_No.Text = objDerived.GetValue("SELECT [dbo].[func_Generate_IIRUP_No] ('" & CType(txtOpenDate.Text, Date) & "')", CommandType.Text)

            ddRequestedBy.DataSource = objDerived.GetDataTable("SELECT * FROM [AMS].[ARE_Returned_History_Hdr] AS A INNER JOIN [AMS].[ARE_Returned_History_Dtl] AS B ON A.Returned_ID = b.Returned_ID" &
                            " RIGHT OUTER JOIN AMS.View_All_Signatories AS C On A.RC_ID = C.deptid And A.Function_ID = C.division_Key WHERE C.isActive = 1 ", CommandType.Text)
            ddRequestedBy.DataTextField = ("Full_Name")
            ddRequestedBy.DataValueField = ("EmpID")
            ddRequestedBy.DataBind()

            LoadSignatories()

            btnSave_Inspection.Enabled = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub txtOpenDate_TextChanged(sender As Object, e As EventArgs) Handles txtOpenDate.TextChanged
        txtIIRUP_No.Text = objDerived.GetValue("SELECT [dbo].[func_Generate_IIRUP_No] ('" & CType(txtOpenDate.Text, Date) & "')", CommandType.Text)

    End Sub
    Protected Sub LoadSignatories()

        'ALL EMPLOYEE OF GOVERNORS OFFICE AND GSO
        ddInspectedby.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE [deptid] IN (1,7) AND [division_Key] = 86 ORDER BY [Full_Name]", CommandType.Text)
        ddInspectedby.DataTextField = ("full_name")
        ddInspectedby.DataValueField = ("empid")
        ddInspectedby.DataBind()
        ddInspectedby.Items.Insert(0, " ")

        'HEAD: GOVERNORS OFFICE, GSO AND ACCOUNTING
        ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE [deptid] IN (1,7,9) AND [division_Key] = 86 AND [isDeptHead] = 'Yes' ORDER BY [Full_Name]", CommandType.Text)
        ddApprovedBy.DataTextField = ("full_name")
        ddApprovedBy.DataValueField = ("empid")
        ddApprovedBy.DataBind()
        ddApprovedBy.Items.Insert(0, "Select")

        'ALL ACCOUNTING OFFICE EMPLOYEE
        ddWitnessBy.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE [deptid] = 9 AND [division_Key] = 86 ORDER BY [Full_Name]", CommandType.Text)
        ddWitnessBy.DataTextField = ("full_name")
        ddWitnessBy.DataValueField = ("empid")
        ddWitnessBy.DataBind()
        ddWitnessBy.Items.Insert(0, " ")

    End Sub
    Protected Sub ddMD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim ddMD As DropDownList = TryCast(sender, DropDownList)
        Dim gvr As GridViewRow = TryCast(ddMD.NamingContainer, GridViewRow)

        dtInspections_Items.Rows(gvr.RowIndex)("MD") = ddMD.SelectedItem.Value

        For i As Integer = 0 To Me.dtInspections_Items.Rows.Count - 1
            CType(grdInspection_Items.Rows(i).FindControl("ddMD"), DropDownList).SelectedIndex = dtInspections_Items.Rows(i)("MD")
            If dtInspections_Items.Rows(i)("GA_ID") = 1166 Then
                CType(grdInspection_Items.Rows(i).FindControl("txtWeight"), TextBox).Enabled = False
                CType(grdInspection_Items.Rows(i).FindControl("txtCurAmnt"), TextBox).Enabled = False

                CType(grdInspection_Items.Rows(i).FindControl("txtappraisedval"), TextBox).Enabled = True
            End If

            If CType(grdInspection_Items.Rows(i).FindControl("ddMD"), DropDownList).SelectedIndex = 3 Then
                CType(grdInspection_Items.Rows(i).FindControl("txtWeight"), TextBox).Text = "0"
                CType(grdInspection_Items.Rows(i).FindControl("txtWeight"), TextBox).Enabled = False

                CType(grdInspection_Items.Rows(i).FindControl("txtCurAmnt"), TextBox).Text = "0.00"
                CType(grdInspection_Items.Rows(i).FindControl("txtCurAmnt"), TextBox).Enabled = False

                CType(grdInspection_Items.Rows(i).FindControl("txtappraisedval"), TextBox).Text = "0.00"
                CType(grdInspection_Items.Rows(i).FindControl("txtappraisedval"), TextBox).Enabled = False

                grdInspection_Items.Rows(i).Cells(4).Text = "0.00"

            Else
                CType(grdInspection_Items.Rows(i).FindControl("txtWeight"), TextBox).Text = "0"
                CType(grdInspection_Items.Rows(i).FindControl("txtWeight"), TextBox).Enabled = True

                CType(grdInspection_Items.Rows(i).FindControl("txtCurAmnt"), TextBox).Text = "0.00"
                CType(grdInspection_Items.Rows(i).FindControl("txtCurAmnt"), TextBox).Enabled = True

                CType(grdInspection_Items.Rows(i).FindControl("txtappraisedval"), TextBox).Text = "0.00"
                CType(grdInspection_Items.Rows(i).FindControl("txtappraisedval"), TextBox).Enabled = True

                grdInspection_Items.Rows(i).Cells(4).Text = "0.00"
            End If
        Next

    End Sub
    Protected Sub txtappraisedval_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtcost As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtcost.NamingContainer, GridViewRow)
            Dim rw = gvr.DataItemIndex

            If txtcost.Text = "" Then
                txtcost.Text = "0.00"
            End If

            CType(Me.grdInspection_Items.Rows(rw).FindControl("txtappraisedval"), TextBox).Text = FormatNumber(txtcost.Text, 2)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Protected Sub txtWeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtWeight As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtWeight.NamingContainer, GridViewRow)
            Dim rw = gvr.DataItemIndex


            If txtWeight.Text = "" Then
                txtWeight.Text = 0
            Else
                CType(Me.grdInspection_Items.Rows(rw).FindControl("txtWeight"), TextBox).Text = FormatNumber(txtWeight.Text, 2)
            End If

            If CType(Me.grdInspection_Items.Rows(rw).FindControl("txtCurAmnt"), TextBox).Text = "" Then
                CType(Me.grdInspection_Items.Rows(rw).FindControl("txtCurAmnt"), TextBox).Text = "0.00"
            End If

            CType(Me.grdInspection_Items.Rows(rw).FindControl("txtappraisedval"), TextBox).Text = FormatNumber(txtWeight.Text * CType(Me.grdInspection_Items.Rows(rw).FindControl("txtCurAmnt"), TextBox).Text, 2)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Protected Sub txtCurAmnt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtcuramnt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtcuramnt.NamingContainer, GridViewRow)
            Dim rw = gvr.DataItemIndex

            If txtcuramnt.Text = "" Then
                txtcuramnt.Text = 0
            Else
                CType(Me.grdInspection_Items.Rows(rw).FindControl("txtCurAmnt"), TextBox).Text = FormatNumber(txtcuramnt.Text, 2)
            End If

            If CType(Me.grdInspection_Items.Rows(rw).FindControl("txtWeight"), TextBox).Text = "" Then
                CType(Me.grdInspection_Items.Rows(rw).FindControl("txtWeight"), TextBox).Text = "0.00"
            End If

            CType(Me.grdInspection_Items.Rows(rw).FindControl("txtappraisedval"), TextBox).Text = FormatNumber(txtcuramnt.Text * CType(Me.grdInspection_Items.Rows(rw).FindControl("txtWeight"), TextBox).Text, 2)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSave_Inspection_Click(sender As Object, e As EventArgs) Handles btnSave_Inspection.Click
        Try

            Dim ID As Integer = objDerived.GetValue("SELECT IIRUPHdr_ID FROM AMS.IIRUP_Hdr WHERE IIRUP_No = '" & txtIIRUP_No.Text & "'", CommandType.Text)
            If ID <> 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "IIRUP Number is already exist.")
                Exit Sub
            End If

            If ddInspectedby.SelectedItem.Text = "Select" Or ddRequestedBy.SelectedItem.Text = "Select" Or ddApprovedBy.SelectedItem.Text = "Select" Or ddWitnessBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill-up all information.")
                Exit Sub
            End If

            Dim RC_ID As String = objDerived.GetValue("Select ISNULL(RC_ID, 0) As RC_ID FROM AMS.IIRUP_Hdr WHERE IIRUPHdr_ID = " & grdInspection.SelectedDataKey(0) & "", CommandType.Text)
            Dim Function_ID As String = objDerived.GetValue("Select ISNULL(Function_ID,0) As Function_ID FROM AMS.IIRUP_Hdr WHERE IIRUPHdr_ID = " & grdInspection.SelectedDataKey(0) & "", CommandType.Text)
            Dim AccountableOfficer As Integer = objDerived.GetValue("Select TOP(1) [EmpID] FROM [HRMS].[view_signatory] WHERE [deptid] = " & RC_ID & " And [division_Key] = " & Function_ID & " And [isDeptHead] = 'Yes' AND [isActive] = 1 ORDER BY [Full_Name]", CommandType.Text)

            Dim CertifiedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE(deptid = 7) AND (division_key = 86) AND (isDeptHead LIKE 'Yes')", CommandType.Text)
            Dim CertifiedBy_Pos As String = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory WHERE(deptid = 7) AND (division_key = 86) AND (isDeptHead LIKE 'Yes')", CommandType.Text)
            Dim VerifiedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE(deptid = 9) AND (division_key = 86) AND (isDeptHead LIKE 'Yes')", CommandType.Text)
            Dim VerifiedBy_Pos As String = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory WHERE(deptid = 9) AND (division_key = 86) AND (isDeptHead LIKE 'Yes')", CommandType.Text)



            If rbChoice.SelectedItem.Value = 1 Then
                '=-= Unserviceable Property
                For i As Integer = 0 To Me.grdInspection_Items.Rows.Count - 1
                    If CType(grdInspection_Items.Rows(i).FindControl("ddMD"), DropDownList).SelectedIndex = 0 Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select mode of disposal for each capital outlay.")
                        Exit Sub
                    End If
                Next

                For o As Integer = 0 To dtInspections_Items.Rows.Count - 1
                    Dim appraisedval As Decimal = CType(Me.grdInspection_Items.Rows(o).FindControl("txtappraisedval"), TextBox).Text

                    objDerived.GetRecords("UPDATE AMS.IIRUP_Dtl SET AppraisedVal = '" & appraisedval & "', Disposal_id = '" & dtInspections_Items.Rows(o)("MD") & "' WHERE IIRUPHdr_ID = '" & grdInspection.SelectedDataKey(0) & "' and PropertyNo = '" & dtInspections_Items.Rows(o)("PropertyNo") & "'", CommandType.Text)
                    objDerived.GetRecords("UPDATE ams.property_dtl SET IsInspectionForDisposal=1, InspectionDate='" & Date.Today.ToString("MM/dd/yyyy") & "' WHERE propertyno ='" & dtInspections_Items.Rows(o)("PropertyNo") & "'", CommandType.Text)

                    grdInspection_Items.Rows(o).Cells(2).Enabled = False
                    grdInspection_Items.Rows(o).Cells(2).Enabled = False

                Next

                objDerived.Execute("UPDATE AMS.IIRUP_Hdr SET IIRUP_Date = '" & txtOpenDate.Text & "', Certified = '" & CertifiedBy & "', Cert_position = '" & CertifiedBy_Pos & "', Verified = '" & VerifiedBy & "', Ver_position = '" & VerifiedBy_Pos & "', Inspected_by = '" & ddInspectedby.SelectedItem.value & "' " &
                                    " , ApprovedBy = '" & ddApprovedBy.SelectedItem.Value & "', RequestedBy = '" & ddRequestedBy.SelectedItem.Value & "', WitnessBy = '" & IIf(ddWitnessBy.SelectedItem.Text = " ", 0, ddWitnessBy.SelectedItem.Value) & "', AccountableOfficer = '" & AccountableOfficer & "' " &
                                    " , IsInspectioned = 1, IIRUP_No = '" & txtIIRUP_No.Text & "' , particulars = '" & replaceapostrophe(txtParticulars.Text) & "' , location = '" & replaceapostrophe(txtWrhseLocation.Text) & "', HRUnserviceable = '" & replaceapostrophe(txtHRUnserviceable.Text) & "' " &
                                    " , BidDate = '" & txtOpenDate.Text & "', BidTime = '', BidLocation = '' WHERE IIRUPHdr_ID = '" & grdInspection.SelectedDataKey("IIRUPHdr_ID") & "'", CommandType.Text)


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                loadPage()

                btnSave_Inspection.Enabled = False
                btnPreview_IIRUP.Enabled = True


            ElseIf rbChoice.SelectedItem.Value = 2 Then
                ''=-= Unserviceable Supply
                'grdSupplyInfo.Columns(5).Visible = True

                'If dtSuppInfo Is Nothing Then
                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No records to save.")
                '    Exit Sub
                'Else

                '    Dim IIRUS_ID As Long = grdSupply.SelectedDataKey("IIRUS_ID")
                '    For i As Integer = 0 To grdSupplyInfo.Rows.Count - 1

                '        Dim AppVal As Decimal = FormatNumber(CType(grdSupplyInfo.Rows(i).FindControl("txtappraisedval"), TextBox).Text)
                '        Dim StckID As Integer = CType(grdSupplyInfo.Rows(i).FindControl("lblStockID"), Label).Text
                '        Dim DisposeID As Integer = dtSuppInfo.Rows(i)("Disposed")

                '        If DisposeID = 5 Then
                '            '=-= Cancel
                '            '=-= Update Stock
                '            Dim qty1 As Integer = objDerived.GetValue("SELECT Qty FROM AMS.IIRUS_Dtl WHERE StockID = '" & StckID & "'", CommandType.Text)
                '            Dim qty2 As Integer = objDerived.GetValue("SELECT Qty FROM AMS.Stock WHERE StockID = '" & StckID & "'", CommandType.Text)
                '            Dim qty3 As Integer = objDerived.GetValue("SELECT Balance FROM AMS.Stock WHERE StockID = '" & StckID & "'", CommandType.Text)

                '            Dim qty4 As Integer = qty1 + qty2
                '            Dim qty5 As Integer = qty1 + qty3

                '            objDerived.Execute("UPDATE AMS.Stock SET Balance = '" & qty5 & "' WHERE StockID = '" & StckID & "'", CommandType.Text)

                '            '=-= Delete IIRUS
                '            objDerived.GetRecords("DELETE FROM AMS.IIRUS_Dtl WHERE StockID = '" & StckID & "' AND IIRUS_ID = '" & grdSupply.SelectedDataKey("IIRUS_ID") & "'", CommandType.Text)

                '        Else
                '            '=-= UPDATE IIRUS HEADER
                '            objDerived.GetRecords("UPDATE AMS.IIRUS_Hdr SET Inspectedby = '" & replaceapostrophe(ddInspectedby.SelectedItem.Text) & "', IsInspectioned = '" & True & "' WHERE IIRUS_ID = '" & IIRUS_ID & "'", CommandType.Text)
                '            objDerived.GetRecords("UPDATE AMS.IIRUS_Hdr SET Certified = '" & replaceapostrophe(CertifiedBy) & "', Cert_position ='" & replaceapostrophe(CertifiedBy_Pos) & "', Verified = '" & replaceapostrophe(VerifiedBy) & "', Ver_position ='" & replaceapostrophe(VerifiedBy_Pos) & "',Approved = '" & replaceapostrophe(ddApprovedBy.SelectedItem.Text) & "' WHERE IIRUS_ID = '" & IIRUS_ID & "'", CommandType.Text)

                '            '=-= UPDATE IIRUS DETAIL
                '            objDerived.GetRecords("UPDATE AMS.IIRUS_Dtl SET AppraisedVal = '" & AppVal & "', Disposal_id = '" & DisposeID & "' WHERE IIRUS_ID = '" & IIRUS_ID & "' AND StockID = '" & StckID & "'", CommandType.Text)

                '            ddInspectedby.Enabled = False
                '            btnsave.Enabled = False
                '            btnpreview.Enabled = True
                '            ''btnISSP.Enabled = True
                '            grdSupplyInfo.Enabled = False

                '            LoadSupply()
                '        End If

                '    Next

                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                'End If

                'grdSupplyInfo.Columns(5).Visible = False
            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnPreview_IIRUP_Click(sender As Object, e As EventArgs) Handles btnPreview_IIRUP.Click
        Dim url As String = "rpt_IIRUP.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub















    '==================================================================================================
    Private Sub grdDisposalAppraisal_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdDisposalAppraisal.PageIndexChanging
        grdDisposalAppraisal.DataSource = dtAppraisal
        grdDisposalAppraisal.PageIndex = e.NewPageIndex
        grdDisposalAppraisal.DataBind()
    End Sub
    Private Sub grdDisposalAppraisal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdDisposalAppraisal.SelectedIndexChanged
        Try
            txtAppraisalDate.Text = Date.Today.ToShortDateString
            btnSave_Appraisal.Enabled = True

            'dtAppraisal_Items = objDerived.GetDataTable("SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY D.Item_Desc) AS ID, B.PropertyNo                                                    " &
            '                                            "   , (D.Item_Desc + ',' + E.SerialNo + ',' + C.Remarks) AS Item_Desc, B.IIRUPDtl_ID,CONVERT(BIT,1) AS isVisible                " &
            '                                            "   FROM AMS.IIRUP_Hdr AS A INNER JOIN AMS.IIRUP_Dtl AS B ON A.IIRUPHdr_ID = B.IIRUPHdr_ID                                      " &
            '                                            "   INNER JOIN AMS.Property AS C ON B.Property_ID = C.Property_ID INNER JOIN AMS.View_ItemList AS D ON C.Item_ID = D.Item_ID    " &
            '                                            "   INNER JOIN AMS.Property_Dtl AS E ON C.Property_ID = B.Property_ID AND B.PropertyNo = E.PropertyNo                           " &
            '                                            "  WHERE A.IIRUPHdr_ID = '" & grdDisposalAppraisal.SelectedDataKey("IIRUPHdr_ID") & "' ORDER BY Item_Desc", CommandType.Text)
            'grdAppraisal_Items.DataSource = dtAppraisal_Items
            'grdAppraisal_Items.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Protected Sub txtAppraisedValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtAppraisal As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtAppraisal.NamingContainer, GridViewRow)
            Dim rw = gvr.DataItemIndex

            If txtAppraisal.Text = "" Then
                txtAppraisal.Text = 0
            Else
                CType(Me.grdAppraisal_Items.Rows(rw).FindControl("txtAppraisedValue"), TextBox).Text = FormatNumber(txtAppraisal.Text, 2)
            End If

            Dim x As Decimal = 0
            For i As Integer = 0 To grdAppraisal_Items.Rows.Count - 1
                x = x + CType(Me.grdAppraisal_Items.Rows(rw).FindControl("txtAppraisedValue"), TextBox).Text
            Next

            CType(grdAppraisal_Items.FooterRow.Cells(2).FindControl("lblTotalAppraisedValue"), Label).Text = FormatNumber(x, 2)

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSave_Appraisal_Click(sender As Object, e As EventArgs) Handles btnSave_Appraisal.Click
        Try

            'For i As Integer = 0 To grdAppraisal_Items.Rows.Count - 1
            '    objDerived.Execute("UPDATE [AMS].[IIRUP_Dtl] SET [AppraisedVal] = '" & CType(CType(Me.grdAppraisal_Items.Rows(i).FindControl("txtAppraisedValue"), TextBox).Text, Decimal) & "' WHERE [IIRUPDtl_ID] = '" & dtAppraisal_Items.Rows(i)("IIRUPDtl_ID") & "'", CommandType.Text)
            'Next

            objDerived.Execute("INSERT INTO [AMS].[tbl_AppraisalReport] ([Appraisal_Date],[Appraisal_No],[IIRUPHdr_ID],[subject],[findings],[valuation],[PreparedBy],[PreparedBy_Pos],[PreparedBy_2],[PreparedBy_Pos2],[PreparedBy_3],[PreparedBy_Pos3],[WMHdr_ID]) " &
                                 "   VALUES ('" & txtAppraisalDate.Text & "'                             " &
                                 "   ,''          " &
                                 "   ,'" & grdDisposalAppraisal.SelectedDataKey("IIRUPHdr_ID") & "'      " &
                                 "   ,'" & replaceapostrophe(txtSubject.Text) & "'                       " &
                                 "   ,'" & replaceapostrophe(txtFindings.Text) & "'                      " &
                                 "   ,'" & replaceapostrophe(txtValuation.Text) & "'                     " &
                                 "   ,'" & replaceapostrophe(txtAppraise_PreparedBy.Text) & "'           " &
                                 "   ,'" & replaceapostrophe(txtAppraise_PreparedByPos.Text) & "'        " &
                                 "   ,'" & replaceapostrophe(txtAppraise_PreparedBy2.Text) & "'          " &
                                 "   ,'" & replaceapostrophe(txtAppraise_PreparedByPos2.Text) & "'       " &
                                 "   ,'" & replaceapostrophe(txtAppraise_PreparedBy3.Text) & "'          " &
                                 "   ,'" & replaceapostrophe(txtAppraise_PreparedByPos3.Text) & "'       " &
                                 "   ,'" & grdDisposalAppraisal.SelectedDataKey("WMHdr_ID") & "')", CommandType.Text)

            If grdDisposalAppraisal.SelectedDataKey("IIRUPHdr_ID") <> 0 Then
                objDerived.Execute("UPDATE [AMS].[IIRUP_Hdr] Set [withAppraisal] = 1 WHERE [IIRUPHdr_ID] = '" & grdDisposalAppraisal.SelectedDataKey("IIRUPHdr_ID") & "'", CommandType.Text)
            End If

            Session("Appraisal_rpt_id") = objDerived.GetValue("SELECT TOP(1) [Appraisal_rpt_id] FROM [AMS].[tbl_AppraisalReport] ORDER BY [Appraisal_rpt_id] DESC", CommandType.Text)
            Session("Report") = "AppraisalRpt"

            ' Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")

            Dim url As String = ResolveUrl("~/MainReports/Disposal_Notices.aspx")
            Dim script As String = "window.open('" & url & "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)

            loadPage()

        Catch ex As Exception
            ' MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
            msgbox(ex.message)
        End Try
    End Sub



End Class
