Imports System.Data
Partial Class Inventory_Issuance_PRSApproval
    Inherits System.Web.UI.Page
    Dim objAccess As New AccessRule
    Dim objDerived As New DerivedDal

    Private objMREReturn As New MRE_Return
    Dim objDonationLedger As New ConsolidatedPropertySaving.TbDonation_Ledger
    Dim objLedger As New t_PropertyLedger
    Dim Return_Hdr As New Returned_History.ARE_Returned_History_Hdr
    Dim Return_Dtl As New Returned_History.ARE_Returned_History_Dtl
#Region "Property"
    Private Property dtDepartment() As DataTable
        Get
            Return CType(Session("dtDepartment"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDepartment") = value
        End Set
    End Property
    Private Property Ppropertylist() As DataTable
        Get
            Return CType(Session("propertylist"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("propertylist") = value
        End Set
    End Property
    Private Property dtissue2() As DataTable
        Get
            Return CType(Session("dtissue2"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtissue2") = value
        End Set
    End Property
#End Region
    Public Function CreatedatabalegrListOfProperty(ByVal row As Integer) As DataTable
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim mycolumn As New DataColumn
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("AcquiredDate", GetType(String))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("rc_name", GetType(String))
        dt.Columns.Add("fullname", GetType(String))
        dt.Columns.Add("DateIssued", GetType(Date))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("rc_id", GetType(Integer))
        dt.Columns.Add("function_id", GetType(Integer))
        dt.Columns.Add("MREHdr_ID", GetType(Integer))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("MREDtl_ID", GetType(Integer)) ''MRE_Hdr'
        dt.Columns.Add("MRE_Hdr", GetType(Integer))
        dt.Columns.Add("MRE_Date", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("Returned_ID", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("AcquiredDate") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("rc_name") = DBNull.Value
            dr("fullname") = DBNull.Value
            dr("DateIssued") = DBNull.Value
            dr("Status") = "  "
            dr("rc_id") = DBNull.Value
            dr("function_id") = DBNull.Value
            dr("MREHdr_ID") = DBNull.Value
            dr("Property_ID") = DBNull.Value
            dr("PropertyDetai_ID") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("MREDtl_ID") = DBNull.Value
            dr("MRE_Hdr") = DBNull.Value
            dr("MRE_Date") = DBNull.Value
            dr("SerialNo") = DBNull.Value
            dr("Returned_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function createdatatablependingPRS(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("PRSDate", GetType(String))
        dt.Columns.Add("ReturnedBy", GetType(String))
        dt.Columns.Add("Purpose", GetType(String))
        dt.Columns.Add("Remarks", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            'dr("Property_Dtl_ID") = DBNull.Value
            dr("Department") = DBNull.Value
            dr("PRSDate") = DBNull.Value
            dr("ReturnedBy") = DBNull.Value
            dr("Purpose") = DBNull.Value
            dr("Remarks") = DBNull.Value

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Sub loadPendingPRS()

        ' btnViewPending.CssClass = "Clicked"
        ' btnViewApproved.CssClass = "Initial"
        'btnViewDisApproved.CssClass = "Initial"
        'Me.mvPropertyReturnSlips.SetActiveView(Me.vwPending)

        Dim dtAccount As New DataTable
        dtAccount = objDerived.GetDataTable("exec AMS.sp_loadPRS '" & drpDepartment.SelectedItem.Value & "'", CommandType.Text)
        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatablependingPRS(9))
        End If
        grdPendingPRS.DataSource = dtAccount
        grdPendingPRS.DataBind()

    End Sub
    Protected Sub LoadPropertyList()
        grListOfProperty.DataSource = CreatedatabalegrListOfProperty(5)
        grListOfProperty.DataBind()

        For i As Integer = 0 To grListOfProperty.Rows.Count - 1
            grListOfProperty.Rows(i).Cells(0).Enabled = False
        Next

    End Sub
    Public Sub loadDepartments()
        dtDepartment = objDerived.GetDataTable("SELECT DISTINCT UPPER(RC_Name) AS RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
        drpDepartment.DataSource = dtDepartment
        drpDepartment.DataTextField = ("RC_Name")
        drpDepartment.DataValueField = ("RC_ID")
        drpDepartment.DataBind()
        '  drpDepartment.Items.Insert(0, "Select")
    End Sub


    Public Sub LoadwithOutProperty()
        Dim x As String = IIf(IsDBNull(grdPendingPRS.SelectedDataKey("prs_hdr_id")), "null", (grdPendingPRS.SelectedDataKey("prs_hdr_id")))
        If x = "null" Then
            LoadPropertyList()
            Exit Sub
        End If

        Ppropertylist = objDerived.GetDataTable("EXEC AMS.sp_loadPRSItem '" & grdPendingPRS.SelectedDataKey("prs_hdr_id") & "'", CommandType.Text)
        dtissue2 = Ppropertylist
        If Ppropertylist.Rows.Count = 0 Then
            LoadPropertyList()

        Else
            '  btnviewProperty.Enabled = True
            'Dim ItemId As New Integer
            'ItemId = Me.gvsearchProperty.SelectedDataKey("Item_id").ToString
            'Session("itemId") = ItemId

            'If Ppropertylist.Rows.Count < 5 Then
            '    Ppropertylist.Merge(CreatedatabalegrListOfProperty(4 - Ppropertylist.Rows.Count))
            'End If


            grListOfProperty.DataSource = Ppropertylist
            grListOfProperty.DataBind()

            For i As Integer = 0 To Ppropertylist.Rows.Count - 1
                If Ppropertylist.Rows(i)("status") = "Returned" Or Ppropertylist.Rows(i)("status") = " - " Or Ppropertylist.Rows(i)("status") = "On Hand" Then
                    If i < 10 Then
                        grListOfProperty.Rows(i).Cells(0).Enabled = True
                    End If
                Else
                    If i < 10 Then
                        grListOfProperty.Rows(i).Cells(0).Enabled = False
                    End If
                End If
            Next

        End If

        Dim isapproved As Boolean = objDerived.GetValue("select isApproved from ams.tbl_PRS_Hdr where prs_hdr_id  = '" & grdPendingPRS.SelectedDataKey("prs_hdr_id") & "'", CommandType.Text)

        If isapproved = True Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PRS already Approved")
            btnApprove.Enabled = True
            btnPreview.Enabled = True
            btnDisApprove.Enabled = False
        Else
            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            drpApprovedBy.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE deptid = 7 AND division_key = 86", CommandType.Text)
            drpApprovedBy.DataTextField = ("full_name")
            drpApprovedBy.DataValueField = ("empid")
            drpApprovedBy.DataBind()
            drpApprovedBy.Items.Insert(0, "Select")
            btnApprove.Enabled = True
            btnPreview.Enabled = False
            btnDisApprove.Enabled = True
        End If
    End Sub

    Private Sub Inventory_Issuance_PRSApproval_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadDepartments()
            loadPendingPRS()
            LoadPropertyList()

        End If
    End Sub

    Protected Sub drpDepartment_SelectedIndexChanged(sender As Object, e As EventArgs)
        loadPendingPRS()
    End Sub


    Protected Sub grdPendingPRS_SelectedIndexChanged(sender As Object, e As EventArgs)
        LoadwithOutProperty()

    End Sub



    Protected Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        '12022022
        'Me.Page.Response.Redirect("~/Inventory/t_rpt_return_slip.aspx")
        ' Response.Write("<script>window.open ('~/Inventory/t_rpt_return_slip.aspx','_blank');</script>")


        ' MsgBox(grdPendingPRS.SelectedDataKey("Returned_ID"))
        Session("Page") = "PRS_Approved"
        Me.Page.Response.Redirect("~/Inventory/t_rpt_return_slip.aspx")
    End Sub
    Protected Sub btnDisApprove_Click(sender As Object, e As EventArgs) Handles btnDisApprove.Click
        objDerived.Execute("Update ams.tbl_PRS_Hdr set isApproved = 0, isdisapproved = 1 where prs_hdr_id = '" & grdPendingPRS.SelectedDataKey("prs_hdr_id") & "'", CommandType.Text)
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property has been successfully returned.")
    End Sub


    Protected Sub drpSearch_SelectedIndexChanged(sender As Object, e As EventArgs)
        mvSearch.ActiveViewIndex = drpSearch.SelectedItem.Value
    End Sub


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)

        ' btnViewPending.CssClass = "Clicked"
        ' btnViewApproved.CssClass = "Initial"
        'btnViewDisApproved.CssClass = "Initial"
        'Me.mvPropertyReturnSlips.SetActiveView(Me.vwPending)

        Dim dtAccount As New DataTable
        If drpSearch.SelectedItem.Value = 0 Then
            dtAccount = objDerived.GetDataTable("exec AMS.sp_loadPRS_search '0','" & drpDepartment.SelectedItem.Value & "'", CommandType.Text)
        Else
            dtAccount = objDerived.GetDataTable("exec AMS.sp_loadPRS_search '1',null,null,'" & txtDateFrom.text & "','" & txtDateto.text & "'", CommandType.Text)
        End If
        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatablependingPRS(9))
        End If
        grdPendingPRS.DataSource = dtAccount
        grdPendingPRS.DataBind()

    End Sub
    Protected Sub grListOfProperty_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("Returned_ID") = grListOfProperty.SelectedDataKey("Returned_ID")
    End Sub
    Protected Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Try
            Dim MREHdr_ID As Integer
            For i As Integer = 0 To dtissue2.Rows.Count - 1
                With objMREReturn
                    .MRE_Dtl = dtissue2.Rows(i)("MREDtl_ID")
                    .PropertyNo = dtissue2.Rows(i)("PropertyNo")
                    .MRE_Date = Date.Now
                    .Status = "Returned"
                    .Remarks = dtissue2.Rows(i)("Remarks")
                    .Inspection = True
                    .deptid = dtissue2.Rows(i)("rc_id")

                    Dim dtMRet As New DataTable
                    dtMRet = objDerived.GetDataTable("Select * from AMS.MRE_Returns where PropertyNo ='" & dtissue2.Rows(i)("PropertyNo") & "' ", CommandType.Text)
                    If dtMRet.Rows.Count = 0 Then
                        .saveMREReturn()
                    Else
                        .MRE_ReturnID = objDerived.GetValue("Select MRE_ReturnID from AMS.MRE_Returns where PropertyNo ='" & dtissue2.Rows(i)("PropertyNo") & "' ", CommandType.Text)
                        .UpdateMREReturn()
                    End If
                End With

                Dim balance As Integer = Val(objDerived.GetValue("exec AMS.getbalance '" & dtissue2.Rows(i)("PropertyNo").ToString & "'", CommandType.Text))
                Dim issuance As Integer = Val(objDerived.GetValue("exec AMS.getIssuance '" & dtissue2.Rows(i)("PropertyNo").ToString & "'", CommandType.Text))
                Dim Property_ID As Integer = Val(objDerived.GetValue("exec AMS.getProperty_ID '" & dtissue2.Rows(i)("PropertyNo").ToString & "'", CommandType.Text))
                objDerived.GetRecords("Update AMS.Property set Balance='" & balance + 1 & "',Issuance='" & issuance - 1 & "' where  Property_ID='" & dtissue2.Rows(i)("Property_ID") & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.Property_Dtl SET Issued ='False' WHERE PropertyNo='" & dtissue2.Rows(i)("PropertyNo") & "'", CommandType.Text)

                Dim isdonated As Boolean = objDerived.GetValue("select a.isDonated From  ams.Property as a inner join ams.Property_Dtl as b on a.Property_ID = b.Property_ID where b.PropertyNo like '" & dtissue2.Rows(i)("PropertyNo").ToString & "'", CommandType.Text)

                If isdonated = 1 Or isdonated = True Then
                    '=== SAVE DONATION LEDGER
                    With objDonationLedger
                        .PropertyNo = dtissue2.Rows(i)("PropertyNo")
                        .SerialNo = ""
                        .Trans_Type = "Returned" '+ " " + dtissue2.Rows(i)("PropertyNo")
                        .Ref = ""
                        .AccountablePerson = ""
                        .Department = ""
                        .Position = ""
                        .AcceptedBy = drpApprovedBy.SelectedItem.Text
                        .InspectedBy = ""
                        .dDate = txtDate.Text
                        .Item_ID = dtissue2.Rows(i)("Item_ID")

                        .CreditQty = "0"
                        .CreditUnit = "-"
                        .CreditCost = "0.00"

                        .DebitQty = 1
                        .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM dbo.m_item INNER JOIN AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID where Item_ID ='" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)
                        .DebitCost = CType(dtissue2.Rows(i)("Cost"), Decimal)

                        .BalanceQty = 1
                        .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM dbo.m_item INNER JOIN AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID where Item_ID ='" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)
                        .BalanceCost = CType(dtissue2.Rows(i)("Cost"), Decimal)

                    End With
                    objDonationLedger.DonationLedger_ID = 0
                    objDonationLedger.save()
                Else
                    '==== SAVE PROPERTY LEDGER ====
                    With objLedger
                        .PropertyNo = dtissue2.Rows(i)("PropertyNo")
                        .SerialNo = dtissue2.Rows(i)("SerialNo").ToString
                        .dDate = txtDate.Text
                        .Trans_Type = "Returned" '+ " " + dtissue2.Rows(i)("PropertyNo")
                        .Ref = ""
                        .AccountablePerson = ""
                        .Department = ""
                        .Position = ""
                        .AcceptedBy = drpApprovedBy.SelectedItem.Text
                        .InspectedBy = ""
                        .Item_ID = dtissue2.Rows(i)("Item_ID")

                        .DebitQty = 1
                        .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)
                        .DebitCost = CType(dtissue2.Rows(i)("Cost"), Decimal)

                        .CreditQty = "0"
                        .CreditUnit = "-"
                        .CreditCost = "0.00"

                        .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)

                        Dim eQty As Integer
                        Dim eBalance As Decimal
                        Dim dtledger As New DataTable

                        dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & dtissue2.Rows(i)("Item_ID") & "'", CommandType.Text)
                        If dtledger.Rows.Count = 0 Then
                            eQty = 0
                            eBalance = 0.0
                        Else
                            eQty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & dtissue2.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                            eBalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & dtissue2.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                        End If

                        .BalanceQty = eQty + 1
                        .BalanceCost = CType(eBalance, Decimal) + CType(dtissue2.Rows(i)("Cost"), Decimal)
                    End With

                    objLedger.Ledger_ID = 0
                    objLedger.save()


                End If
                MREHdr_ID = dtissue2.Rows(i)("MREHdr_ID")
            Next
            '=== SAVE RETURNED HEADER HISTORY
            With Return_Hdr
                .Returned_To = drpApprovedBy.SelectedItem.Value
                .Returned_By = objDerived.GetValue("select MRto from AMS.MRE_Hdr where AMS.MRE_Hdr.MREHdr_ID = " & MREHdr_ID, CommandType.Text)
                .Returned_Date = txtDate.Text

                '=== CHECK IF ALL ITEMS BELONGS TO ONE OFFICE OR NOT
                Dim xRC As Integer = 0
                For i As Integer = 0 To dtissue2.Rows.Count - 1
                    If i = 0 Then
                        xRC = dtissue2.Rows(i)("rc_id")
                    Else
                        If dtissue2.Rows(i)("rc_id") = xRC Then
                            Session("VariousDept") = 0
                        Else
                            Session("VariousDept") = 1
                            Exit For
                        End If
                    End If
                Next

                If Session("VariousDept") = 0 Then
                    .RC_ID = dtissue2.Rows(0)("rc_id")
                    .Function_ID = dtissue2.Rows(0)("function_id")
                Else
                    .RC_ID = 0
                    .Function_ID = 0
                End If

                .Purpose = grdPendingPRS.SelectedDataKey("Purpose")
                '    .Remarks = txtRemarks.Text
            End With

            Dim ReturnHdr_ID As Long = Return_Hdr.save
            Session("Returned_ID") = ReturnHdr_ID

            '=== SAVE RETURN DETAILS
            For i As Integer = 0 To dtissue2.Rows.Count - 1
                With Return_Dtl
                    .Returned_ID = ReturnHdr_ID
                    .Acquired_Date = objDerived.GetValue("SELECT MRE_Date FROM AMS.MRE_Hdr WHERE MREHdr_ID = '" & dtissue2.Rows(i)("MREHdr_ID") & "'", CommandType.Text)
                    .Item_ID = dtissue2.Rows(i)("Item_ID")
                    .PropertyNo = dtissue2.Rows(i)("PropertyNo")
                    .save()
                End With
            Next

            Session("Returned_ID") = ReturnHdr_ID



            objDerived.Execute("Update ams.tbl_PRS_Hdr set isApproved = 1 where prs_hdr_id = '" & grdPendingPRS.SelectedDataKey("prs_hdr_id") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property has been successfully returned.")
            'loadPendingPRS()
            'LoadwithOutProperty()
            btnDisApprove.Enabled = False
            btnApprove.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        btnPreview.Enabled = True
    End Sub
End Class

