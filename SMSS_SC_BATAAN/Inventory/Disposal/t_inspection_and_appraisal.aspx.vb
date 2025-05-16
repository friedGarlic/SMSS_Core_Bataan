Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class t_inspection_and_appraisal

    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim hdr As New Disposal_inspection_hdr
    Dim dtl As New Disposal_inspection_dtl
    Dim msg As New MsgeBox
    Dim obj As New AccessRule

#Region "property"

    Private Property pNew() As DataTable
        Get
            Return CType(Session("pNew"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pNew") = value
        End Set
    End Property

    Private Property pBody() As DataTable
        Get
            Return CType(Session("pBody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBody") = value
        End Set
    End Property

    Private Property pOPen() As DataTable
        Get
            Return CType(Session("pOPen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pOPen") = value
        End Set
    End Property


    Private Property dtSuppInfo() As DataTable
        Get
            Return CType(Session("dtSuppInfo"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSuppInfo") = value
        End Set
    End Property

    Private Property dtSignatories() As DataTable
        Get
            Return CType(Session("dtSignatories"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSignatories") = value
        End Set
    End Property


#End Region

    Public Function verify(ByVal str As String) As Boolean
        Dim myview As DataView
        myview = CType(pBody, DataTable).DefaultView
        myview.RowFilter = "PropertyNo ='" & str & "'"
        If myview.Count <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            pBody = Nothing
            gvbody.DataSource = pBody
            gvbody.DataBind()

            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")
            btnnew.Enabled = True
            btnopen.Enabled = True
            btnsave.Enabled = False
            btnpreview.Enabled = False

            pNew = objDerived.GetDataTable("SELECT IIRUPHdr_ID, IIRUP_Date  FROM AMS.IIRUP_Hdr Where IsInspectioned = 0 ORDER BY IIRUPHdr_ID DESC", CommandType.Text)
            gvNEW.DataSource = pNew
            gvNEW.DataBind()

            LoadSignatories()

            txtOpenDate.Text = Date.Today.ToString("MM/dd/yyyy")

            rbChoice.SelectedItem.Value = 1
            Me.mvCategory.SetActiveView(Me.vwProperty)

        End If
    End Sub

    Protected Sub LoadSignatories()
        'ALL EMPLOYEE OF GOVERNORS OFFICE AND GSO
        ddRequestedBy.DataSource = objDerived.GetDataTable("SELECT DISTINCT * FROM [HRMS].[view_signatory] WHERE [deptid] IN (1,7) AND [division_Key] = 86 ORDER BY [Full_Name]", CommandType.Text)
        ddRequestedBy.DataTextField = ("full_name")
        ddRequestedBy.DataValueField = ("empid")
        ddRequestedBy.DataBind()
        ddRequestedBy.Items.Insert(0, "Select")

        'ALL EMPLOYEE OF GOVERNORS OFFICE AND GSO
        ddInspectedby.DataSource = objDerived.GetDataTable("SELECT DISTINCT * FROM [HRMS].[view_signatory] WHERE [deptid] IN (1,7) AND [division_Key] = 86 ORDER BY [Full_Name]", CommandType.Text)
        ddInspectedby.DataTextField = ("full_name")
        ddInspectedby.DataValueField = ("empid")
        ddInspectedby.DataBind()
        ddInspectedby.Items.Insert(0, "Select")

        'HEAD: GOVERNORS OFFICE, GSO AND ACCOUNTING
        ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT DISTINCT * FROM [HRMS].[view_signatory] WHERE [deptid] IN (1,7,9) AND [division_Key] = 86 AND [isDeptHead] = 'Yes' ORDER BY [Full_Name]", CommandType.Text)
        ddApprovedBy.DataTextField = ("full_name")
        ddApprovedBy.DataValueField = ("empid")
        ddApprovedBy.DataBind()
        ddApprovedBy.Items.Insert(0, "Select")

        'ALL ACCOUNTING OFFICE EMPLOYEE
        ddWitnessBy.DataSource = objDerived.GetDataTable("SELECT DISTINCT * FROM [HRMS].[view_signatory] WHERE [deptid] = 9 AND [division_Key] = 86 ORDER BY [Full_Name]", CommandType.Text)
        ddWitnessBy.DataTextField = ("full_name")
        ddWitnessBy.DataValueField = ("empid")
        ddWitnessBy.DataBind()
        ddWitnessBy.Items.Insert(0, "Select")

    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub gvNEW_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvNEW.SelectedIndexChanged
        Try
            pBody = objDerived.GetDataTable("exec ams.iirup_dtl_report '" & gvNEW.SelectedDataKey(0) & "'", CommandType.Text)
            gvbody.DataSource = pBody
            gvbody.DataBind()

            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                CType(gvbody.Rows(i).FindControl("ddMD"), DropDownList).SelectedIndex = pBody.Rows(i)("MD")

                Dim txtqty As TextBox = CType(gvbody.Rows(i).FindControl("txtappraisedval"), TextBox)
                txtqty.Attributes.Add("onFocus", "this.select()")
                txtqty.Attributes.Add("onClick", "this.select()")
            Next

            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")

            Session("TransID") = gvNEW.SelectedDataKey(0)
            Session("IIRUPHdr_ID") = gvNEW.SelectedDataKey("IIRUPHdr_ID")

            ddInspectedby.Enabled = True
            btnnew.Enabled = True
            btnopen.Enabled = True
            btnpreview.Enabled = False

            btnsave.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddMD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddMD As DropDownList = TryCast(sender, DropDownList)
        Dim gvr As GridViewRow = TryCast(ddMD.NamingContainer, GridViewRow)

        pBody.Rows(gvr.RowIndex)("MD") = ddMD.SelectedItem.Value


        gvbody.DataSource = pBody
        gvbody.DataBind()
        For i As Integer = 0 To Me.pBody.Rows.Count - 1
            CType(gvbody.Rows(i).FindControl("ddMD"), DropDownList).SelectedIndex = pBody.Rows(i)("MD")
        Next

    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            If ddInspectedby.SelectedItem.Text = "Select" Or txtLocation.Text = "" Or ddRequestedBy.SelectedItem.Text = "Select" Or ddApprovedBy.SelectedItem.Text = "Select" Or ddWitnessBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill-up all information.")
                Exit Sub
            End If

            Dim certby As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE(deptid = 7) AND (division_key = 86) AND (isDeptHead LIKE 'Yes')", CommandType.Text)
            Dim certpos As String = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory WHERE(deptid = 7) AND (division_key = 86) AND (isDeptHead LIKE 'Yes')", CommandType.Text)
            Dim verby As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE(deptid = 9) AND (division_key = 86) AND (isDeptHead LIKE 'Yes')", CommandType.Text)
            Dim verpos As String = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory WHERE(deptid = 9) AND (division_key = 86) AND (isDeptHead LIKE 'Yes')", CommandType.Text)
            Dim appby As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE(deptid = 1) AND (division_key = 86) AND (isDeptHead LIKE 'Yes')", CommandType.Text)
            'optimize code
            Dim AccountableOfficer As Integer = objDerived.Execute("exec [AMS].[GetSignatoryEmployee]", CommandType.Text)
            'objDerived.GetValue("SELECT TOP(1) [EmpID] FROM [HRMS].[view_signatory] WHERE [deptid] = 1 AND [division_Key] = 86 AND [isDeptHead] = 'Yes' AND [isActive] = 1 ORDER BY [Full_Name]", CommandType.Text)

            If rbChoice.SelectedItem.Value = 1 Then
                '=-= Unserviceable Property
                If pBody Is Nothing Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No records to save.")
                    Exit Sub
                End If

                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    If CType(gvbody.Rows(i).FindControl("ddMD"), DropDownList).SelectedIndex = 0 Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select mode of disposal for each capital outlay.")
                        Exit Sub
                    End If
                Next

                For o As Integer = 0 To pBody.Rows.Count - 1
                    objDerived.GetRecords("Update AMS.IIRUP_Hdr set Inspected_by = '" & ddInspectedby.SelectedItem.Value & "' where IIRUPHdr_ID = '" & gvNEW.SelectedDataKey(0) & "'", CommandType.Text)
                    objDerived.GetRecords("Update AMS.IIRUP_Hdr set Certified = '" & replaceapostrophe(certby) & "', Cert_position ='" & replaceapostrophe(certpos) &
                                          "', Verified = '" & replaceapostrophe(verby) & "', Ver_position ='" & replaceapostrophe(verpos) & "',Approved = '" & replaceapostrophe(appby) &
                                          "',RC_ID=" & 7 & ",Function_ID=" & 86 & " where IIRUPHdr_ID = '" & gvNEW.SelectedDataKey(0) & "'", CommandType.Text)
                    objDerived.GetRecords("Update AMS.IIRUP_Dtl set AppraisedVal = '" & pBody.Rows(o)("AppraisedVal") & "', netval = " & pBody.Rows(o)("netval") & ", Disposal_id = '" & pBody.Rows(o)("MD") & "' where IIRUPHdr_ID = '" & gvNEW.SelectedDataKey(0) & "' and PropertyNo = '" & pBody.Rows(o)("PropertyNo") & "'", CommandType.Text)

                    '========= NEW UPDATE FOR SIGNATORIES ===========
                    objDerived.GetRecords("UPDATE [AMS].[IIRUP_Hdr] SET [RequestedBy] = '" & ddRequestedBy.SelectedItem.Value & "',[ApprovedBy] = '" & ddApprovedBy.SelectedItem.Value & "',[Inspected_By] = '" & ddInspectedby.SelectedItem.Value & "', " & _
                                 " [WitnessBy] = '" & ddWitnessBy.SelectedItem.Value & "', [AccountableOfficer] = '" & AccountableOfficer & "' WHERE IIRUPHdr_ID = '" & gvNEW.SelectedDataKey(0) & "'", CommandType.Text)

                    If pBody.Rows(o)("MD") = 5 Then
                        objDerived.GetRecords("Update ams.property_dtl set IsInspectionForDisposal=1, InspectionDate='" & Date.Today.ToString("MM/dd/yyyy") & "' where propertyno='" & pBody.Rows(o)("PropertyNo") & "'", CommandType.Text)
                    End If

                    objDerived.GetRecords("Update ams.property_dtl set IsInspectionForDisposal=1, InspectionDate='" & Date.Today.ToString("MM/dd/yyyy") & "' where propertyno='" & pBody.Rows(o)("PropertyNo") & "'", CommandType.Text)

                    gvbody.Rows(o).Cells(2).Enabled = False
                    gvbody.Rows(o).Cells(2).Enabled = False
                Next

                Dim tym As String
                tym = ddHour.SelectedItem.Text + ":" + ddMinute.SelectedItem.Text + " " + drpTime.SelectedItem.Text

                objDerived.GetRecords("Update AMS.IIRUP_Hdr set IsInspectioned = 1 where IIRUPHdr_ID=" & gvNEW.SelectedDataKey(0) & "", CommandType.Text)
                objDerived.GetRecords("Update AMS.IIRUP_Hdr set BidDate = '" & txtOpenDate.Text & "', BidTime = '" & tym & "', BidLocation = '" & txtLocation.Text & "' where IIRUPHdr_ID=" & gvNEW.SelectedDataKey(0) & "", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


                txtdate.ReadOnly = True

                btnnew.Enabled = True
                btnopen.Enabled = True
                btnsave.Enabled = False
                btnpreview.Enabled = True
                btnBidForm.Enabled = True
                btnNotice.Enabled = True
                ddInspectedby.Enabled = False

                pNew = objDerived.GetDataTable("SELECT  IIRUPHdr_ID, IIRUP_Date  FROM AMS.IIRUP_Hdr WHERE IsInspectioned = 0 ORDER BY IIRUPHdr_ID DESC", CommandType.Text)
                gvNEW.DataSource = pNew
                gvNEW.DataBind()

                gvbody.DataSource = Nothing
                gvbody.DataBind()

            ElseIf rbChoice.SelectedItem.Value = 2 Then
                '=-= Unserviceable Supply
                grdSupplyInfo.Columns(5).Visible = True

                If dtSuppInfo Is Nothing Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No records to save.")
                    Exit Sub
                Else

                    Dim IIRUS_ID As Long = grdSupply.SelectedDataKey("IIRUS_ID")
                    For i As Integer = 0 To grdSupplyInfo.Rows.Count - 1

                        Dim AppVal As Decimal = FormatNumber(CType(grdSupplyInfo.Rows(i).FindControl("txtappraisedval"), TextBox).Text)
                        Dim StckID As Integer = CType(grdSupplyInfo.Rows(i).FindControl("lblStockID"), Label).Text
                        Dim DisposeID As Integer = dtSuppInfo.Rows(i)("Disposed")

                        If DisposeID = 5 Then
                            '=-= Cancel
                            '=-= Update Stock
                            Dim qty1 As Integer = objDerived.GetValue("SELECT Qty FROM AMS.IIRUS_Dtl WHERE StockID = '" & StckID & "'", CommandType.Text)
                            Dim qty2 As Integer = objDerived.GetValue("SELECT Qty FROM AMS.Stock WHERE StockID = '" & StckID & "'", CommandType.Text)
                            Dim qty3 As Integer = objDerived.GetValue("SELECT Balance FROM AMS.Stock WHERE StockID = '" & StckID & "'", CommandType.Text)

                            Dim qty4 As Integer = qty1 + qty2
                            Dim qty5 As Integer = qty1 + qty3

                            objDerived.Execute("UPDATE AMS.Stock SET Balance = '" & qty5 & "' WHERE StockID = '" & StckID & "'", CommandType.Text)

                            '=-= Delete IIRUS
                            objDerived.GetRecords("DELETE FROM AMS.IIRUS_Dtl WHERE StockID = '" & StckID & "' AND IIRUS_ID = '" & grdSupply.SelectedDataKey("IIRUS_ID") & "'", CommandType.Text)

                        Else
                            '=-= UPDATE IIRUS HEADER
                            objDerived.GetRecords("UPDATE AMS.IIRUS_Hdr SET Inspectedby = '" & replaceapostrophe(ddInspectedby.SelectedItem.Text) & "', IsInspectioned = '" & True & "' WHERE IIRUS_ID = '" & IIRUS_ID & "'", CommandType.Text)
                            objDerived.GetRecords("UPDATE AMS.IIRUS_Hdr SET Certified = '" & replaceapostrophe(certby) & "', Cert_position ='" & replaceapostrophe(certpos) & "', Verified = '" & replaceapostrophe(verby) & "', Ver_position ='" & replaceapostrophe(verpos) & "',Approved = '" & replaceapostrophe(appby) & "' WHERE IIRUS_ID = '" & IIRUS_ID & "'", CommandType.Text)

                            '=-= UPDATE IIRUS DETAIL
                            objDerived.GetRecords("UPDATE AMS.IIRUS_Dtl SET AppraisedVal = '" & AppVal & "', Disposal_id = '" & DisposeID & "' WHERE IIRUS_ID = '" & IIRUS_ID & "' AND StockID = '" & StckID & "'", CommandType.Text)

                            ddInspectedby.Enabled = False
                            btnsave.Enabled = False
                            btnpreview.Enabled = True

                            grdSupplyInfo.Enabled = False

                            LoadSupply()
                        End If

                    Next

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                End If

                grdSupplyInfo.Columns(5).Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnnew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnew.Click

    End Sub

    Protected Sub txtappraisedval_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtcost As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtcost.NamingContainer, GridViewRow)
            If txtcost.Text = "" Then
                txtcost.Text = "0.00"
            End If


            pBody.Rows(gvr.RowIndex)("AppraisedVal") = FormatNumber(txtcost.Text, 2)
            CType(gvbody.Rows(gvr.RowIndex).FindControl("txtappraisedval"), TextBox).Text = FormatNumber(txtcost.Text, 2)

            Dim txtqty As TextBox = CType(gvbody.Rows(gvr.RowIndex + 1).FindControl("txtappraisedval"), TextBox)
            Me.Session("index") = gvr.RowIndex + 1

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtNetBookValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtcost As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtcost.NamingContainer, GridViewRow)
            If txtcost.Text = "" Then
                txtcost.Text = "0.00"
            End If


            pBody.Rows(gvr.RowIndex)("netval") = FormatNumber(txtcost.Text, 2)
            CType(gvbody.Rows(gvr.RowIndex).FindControl("txtNetBookValue"), TextBox).Text = FormatNumber(txtcost.Text, 2)

            Dim txtqty As TextBox = CType(gvbody.Rows(gvr.RowIndex + 1).FindControl("txtNetBookValue"), TextBox)
            Me.Session("index") = gvr.RowIndex + 1


        Catch ex As Exception

        End Try
    End Sub


    Protected Sub gvbody_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvbody.Load


    End Sub

    Protected Sub gvNEW_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvNEW.PageIndexChanging
        Me.gvNEW.DataSource = CType(pNew, DataTable)
        Me.gvNEW.DataBind()
        gvNEW.SelectedIndex = -1
    End Sub

    
    Protected Sub ddInspectedby_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'btnsave.Enabled = True
    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        gvbody.DataSource = Nothing
        gvbody.DataBind()

        If rbChoice.SelectedItem.Value = 1 Then
            Me.mvCategory.SetActiveView(Me.vwProperty)

            btnpreview.Visible = True
            btnBidForm.Visible = True
            btnNotice.Visible = True

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            Me.mvCategory.SetActiveView(Me.vwSupply)

            LoadSupply()

            grdSupplyInfo.DataSource = Nothing
            grdSupplyInfo.DataBind()

            btnpreview.Visible = False
            btnBidForm.Visible = False
            btnNotice.Visible = False
        End If
    End Sub

    Protected Sub LoadSupply()
        grdSupply.DataSource = Nothing
        grdSupply.DataBind()

        Dim dtSupp As New DataTable
        dtSupp = objDerived.GetDataTable("SELECT * FROM [AMS].[IIRUS_Hdr] WHERE IsInspectioned = 0 ORDER BY IIRUS_ID DESC", CommandType.Text)
        grdSupply.DataSource = dtSupp
        grdSupply.DataBind()
    End Sub

    Protected Sub grdSupply_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        grdSupplyInfo.Enabled = True
        dtSuppInfo = Nothing

        Session("IIRUS_ID") = grdSupply.SelectedDataKey("IIRUS_ID")

        dtSuppInfo = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Supply_Unserviceable_Info] WHERE IIRUS_ID = '" & Session("IIRUS_ID") & "'", CommandType.Text)
        grdSupplyInfo.DataSource = dtSuppInfo
        grdSupplyInfo.DataBind()

        grdSupplyInfo.Columns(5).Visible = False

        For i As Integer = 0 To Me.grdSupplyInfo.Rows.Count - 1
            CType(grdSupplyInfo.Rows(i).FindControl("ddDispose"), DropDownList).SelectedIndex = dtSuppInfo.Rows(i)("Disposed")
        Next

        ddInspectedby.Enabled = True
        btnsave.Enabled = True

    End Sub

    Protected Sub ddDispose_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddDispose As DropDownList = TryCast(sender, DropDownList)
        Dim gvr As GridViewRow = TryCast(ddDispose.NamingContainer, GridViewRow)

        dtSuppInfo.Rows(gvr.RowIndex)("Disposed") = ddDispose.SelectedItem.Value

        grdSupplyInfo.DataSource = dtSuppInfo
        grdSupplyInfo.DataBind()
        For i As Integer = 0 To Me.dtSuppInfo.Rows.Count - 1
            CType(grdSupplyInfo.Rows(i).FindControl("ddDispose"), DropDownList).SelectedIndex = dtSuppInfo.Rows(i)("Disposed")
        Next
    End Sub

    Protected Sub txtappraisedval_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtappraisedval As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtappraisedval.NamingContainer, GridViewRow)
        If txtappraisedval.Text = "" Then
            txtappraisedval.Text = "0.00"
        End If

        txtappraisedval.Text = FormatNumber(txtappraisedval.Text, 2)

    End Sub

    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        Session("Report") = "IIRUP"


        Dim url As String = "InspectionAppraisal_Reports.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        'Dim url As String = "rpt_IIRUP.aspx?"
        'Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        'ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub

    Protected Sub btnBidForm_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Report") = "Form"


        Dim url As String = "InspectionAppraisal_Reports.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        'Dim url As String = "rpt_Auction_BidForm.aspx?"
        'Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=0,scrollbars=1,width=850,height=700,left=250,top=100');"
        'ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub

    Protected Sub btnNotice_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Report") = "Notice"

        Dim url As String = "InspectionAppraisal_Reports.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        'Dim url As String = "rpt_NoticePublicBidding.aspx?"
        'Dim fullURL As String = "var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=0,scrollbars=1,width=830,height=550');"
        'ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub
End Class
