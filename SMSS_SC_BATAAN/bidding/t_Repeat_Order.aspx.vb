Imports System.Data
Partial Class bidding_t_Repeat_Order
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim objDerived As New DerivedDal
    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl
    Private CAA_hdr As New t_purchase_request_obr_hdr
    Private CAA_dtl As New t_purchase_request_obr_dtl

    Private Property pPO() As DataTable
        Get
            Return CType(Session("pPO"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPO") = value
        End Set

    End Property
    Private Property pRequestedby() As DataTable
        Get
            Return CType(Session("pRequestedby"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRequestedby") = value
        End Set

    End Property
    Private Property pAccounts() As DataTable
        Get
            Return CType(Session("pAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAccounts") = value
        End Set

    End Property
    Private Property pPR() As DataTable
        Get
            Return CType(Session("pPR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPR") = value
        End Set
    End Property
    Private Property pPurchase_Order_Item_Body() As DataTable
        Get
            Return CType(Session("pPurchase_Order_Item_Body"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order_Item_Body") = value
        End Set
    End Property

    Private Property pPurchase_Order_Item() As DataTable
        Get
            Return CType(Session("pPurchase_Order_Item"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order_Item") = value
        End Set
    End Property

    Private Property pPurchase_Order() As DataTable
        Get
            Return CType(Session("pPurchase_Order"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order") = value
        End Set
    End Property
    Private Property pFunction() As DataTable
        Get
            Return CType(Session("pFunction"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pFunction") = value
        End Set
    End Property
    Private Property PAPS() As DataTable
        Get
            Return CType(Session("PAPS"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PAPS") = value
        End Set
    End Property
    Public Function CreateTable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        ' Add columns for pr_no, DateApproved, ABC, remarks, and OBR_No
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("DateApproved", GetType(DateTime))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("remarks", GetType(String))
        dt.Columns.Add("OBR_No", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = DBNull.Value
            dr("DateApproved") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("remarks") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("pr_no", GetType(String))
        'dt.Columns.Add("ReqDept", GetType(String))
        'dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("ItemCompleteDesc", GetType(String))
        dt.Columns.Add("qty", GetType(Decimal))
        dt.Columns.Add("cost", GetType(Decimal))


        For i As Integer = 0 To row
            dr = dt.NewRow
            'dr("pr_no") = DBNull.Value
            'dr("ReqDept") = DBNull.Value
            'dr("OBR_No") = DBNull.Value
            dr("POHdr_ID") = DBNull.Value
            dr("ItemCompleteDesc") = DBNull.Value
            dr("qty") = DBNull.Value
            dr("cost") = DBNull.Value

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Private Sub bidding_t_Repeat_Order_Load(sender As Object, e As EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then
            LoadRO() ' Load Repeat Order data
            LoadSupplier() ' Load supplier list
            ViewState("TotalAmount") = 0.0
        End If


    End Sub

    Protected Sub drpSupllier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Check if a valid supplier is selected
        If drpSupllier.SelectedItem.Value <> "0" Then
            ' Fetch supplier details (e.g., address)
            Dim supplierAddress As String = objDerived.GetValue("SELECT Address1 FROM dbo.Supplier WHERE Supplier_Id = '" & drpSupllier.SelectedItem.Value & "'", CommandType.Text)

            ' Display supplier address (if you have a textbox for it)
            txtSupplierAddress.Text = supplierAddress
        Else
            ' Clear supplier details if "Select" is chosen
            txtSupplierAddress.Text = ""
        End If
    End Sub



    Public Sub LoadSupplier()
        ' Fetch suppliers from the database
        drpSupllier.DataSource = objDerived.GetDataTable("SELECT Supplier_Id, SuppName FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)

        ' Set the text and value fields for the dropdown
        drpSupllier.DataTextField = "SuppName"
        drpSupllier.DataValueField = "Supplier_Id"

        ' Bind the data to the dropdown
        drpSupllier.DataBind()

        ' Add a default "Select" option at the top
        drpSupllier.Items.Insert(0, New ListItem("Select", "0"))
    End Sub


    Public Sub LoadDepartment()
        drpDepartment.DataSource = objDerived.GetDataTable("SELECT DISTINCT RC_Name,RC_ID FROM dbo.View_RespCenter_withFunctions where RC_ID = '" & pPR.Rows(0)("RC_ID") & "' ORDER BY RC_Name", CommandType.Text)
        drpDepartment.DataTextField = ("RC_Name")
        drpDepartment.DataValueField = ("RC_ID")
        drpDepartment.DataBind()


        LoadFunction()
        PPA()
        drpNature.SelectedValue = pPR.Rows(0)("Transaction_type")
        LoadAccoutittle()
        LoadRequestBy()
        LoadApprovedBy()
        'LoadSupplier()
        'txtSupplierAddress.Text = objDerived.GetValue("select Address1 from dbo.Supplier where Supplier_Id = '" & pPO.Rows(0)("Supplier_ID") & "'", CommandType.Text)

        Dim GA_ID As Integer
        Dim BGA_ID As Integer
        GA_ID = objDerived.GetValue("Select GA_ID from AMS.View_AccountList where GA_Code2 ='" & drpAccounts.SelectedValue & "'", CommandType.Text)
        BGA_ID = objDerived.GetValue("Select BGA_ID from AMS.View_AccountList where GA_Code2 ='" & drpAccounts.SelectedValue & "'", CommandType.Text)
        Session("GA_ID") = GA_ID
        Session("BGA_ID") = BGA_ID
    End Sub
    Public Sub LoadFunction()
        pFunction = objDerived.GetDataTable("EXEC [dbo].[sp_function_systemManager] '" & Session("RoleName") & "','" & pPR.Rows(0)("RC_ID") & "'", CommandType.Text)
        drpFunction.DataSource = pFunction
        drpFunction.DataTextField = ("Function_Desc")
        drpFunction.DataValueField = ("Function_ID")
        drpFunction.DataBind()
    End Sub

    Public Sub PPA()
        ' Extract values from pPR.Rows(0)
        Dim rcID As String = Convert.ToString(pPR.Rows(0)("RC_ID"))
        Dim functionID As String = Convert.ToString(pPR.Rows(0)("Function_ID"))
        Dim fID As String = Convert.ToString(pPR.Rows(0)("F_ID"))
        Dim currentYear As String = Year(Date.Today).ToString()

        ' Trace the values
        AddTrace("RC_ID: " & rcID)
        AddTrace("Function_ID: " & functionID)
        AddTrace("F_ID: " & fID)
        AddTrace("Year: " & currentYear)

        ' Construct the SQL query
        Dim query As String = "exec ams.sp_Programs_Activities_Project_With_OOE " & rcID & ",'" & currentYear & "'," & functionID & ",0," & fID
        AddTrace("SQL Query: " & query) ' Log the final SQL query

        ' Execute query
        PAPS = objDerived.GetDataTable(query, CommandType.Text)

        ' Check if PAPS contains data
        If PAPS Is Nothing OrElse PAPS.Rows.Count = 0 Then
            AddTrace("Error: No data returned from stored procedure.")
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No valid Programs/Activities/Projects found.")
            Exit Sub
        End If

        ' Bind to dropdown
        drpPPA.DataSource = PAPS
        drpPPA.DataTextField = "description"
        drpPPA.DataValueField = "Project_ID"
        drpPPA.DataBind()

        ' Ensure selectedProjectID exists before setting it
        Dim selectedProjectID As String = Convert.ToString(pPR.Rows(0)("Project_ID"))
        Dim projectExists As Boolean = PAPS.AsEnumerable().Any(Function(row) Convert.ToString(row.Field(Of Object)("Project_ID")) = selectedProjectID)



        If drpPPA.Items.FindByValue(pPR.Rows(0)("Project_ID").ToString()) IsNot Nothing Then
            drpPPA.SelectedValue = pPR.Rows(0)("Project_ID").ToString()
            AddTrace("Selected Project_ID retained: " & pPR.Rows(0)("Project_ID").ToString())
        Else
            AddTrace("Warning: Project_ID not found in dropdown.")
        End If


        If projectExists Then
            drpPPA.SelectedValue = selectedProjectID
            AddTrace("Project_ID successfully set: " & selectedProjectID)
        Else
            AddTrace("Warning: Selected Project_ID does not exist in PAPS.")
        End If
    End Sub



    'Public Sub PPA()
    '    PAPS = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project_With_OOE " & pPR.Rows(0)("RC_ID") & ",'" & Year(CDate(Date.Today)) & "'," & pPR.Rows(0)("Function_ID") & ",0," & pPR.Rows(0)("F_ID") & "", CommandType.Text)

    '    drpPPA.DataSource = PAPS
    '    drpPPA.DataTextField = ("description")
    '    drpPPA.DataValueField = ("Project_ID")
    '    drpPPA.DataBind()
    '    drpPPA.SelectedValue = pPR.Rows(0)("Project_ID")

    'End Sub

    Protected Sub LoadRO()
        ' Fetch data from the stored procedure
        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List_RO]", CommandType.Text)

        ' Ensure the DataTable has at least 5 rows
        If pPurchase_Order.Rows.Count < 5 Then
            pPurchase_Order.Merge(CreateTable(5 - pPurchase_Order.Rows.Count))
        End If

        ' Bind the data to the GridView
        grdRO.DataSource = pPurchase_Order
        grdRO.DataBind()
    End Sub
    Protected Sub LoadAccoutittle()
        pAccounts = objDerived.GetDataTable("SELECT DISTINCT GA_Title, CONVERT(VARCHAR(20),GA_CODE2) AS GA_CODE2,GA_ID  from AMS.vw_Ga_Title where AllotmentClass_ID = '" & drpNature.SelectedValue.ToString & "' and RC_ID = '" & drpDepartment.SelectedItem.Value & "' and Function_ID = '" & drpFunction.SelectedItem.Value & "' and Project_ID = '" & pPR.Rows(0)("Project_ID") & "' and Program_id = '" & pPR.Rows(0)("Program_id") & "' and CYear = '" & Year(CDate(Date.Today)) & "'", CommandType.Text)
        drpAccounts.DataSource = pAccounts
        drpAccounts.DataTextField = ("GA_Title")
        drpAccounts.DataValueField = ("GA_CODE2")
        drpAccounts.DataBind()

    End Sub
    Protected Sub LoadRequestBy()
        pRequestedby = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & pPR.Rows(0)("RC_ID") & "' AND division_key = '" & pPR.Rows(0)("Function_ID") & "'", CommandType.Text)
        drpRequestingPerson.DataSource = pRequestedby
        drpRequestingPerson.DataTextField = ("full_name")
        drpRequestingPerson.DataValueField = ("empid")
        drpRequestingPerson.DataBind()
    End Sub
    Protected Sub LoadApprovedBy()
        drpApprovedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE  division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' AND office_name in ('OFFICE OF THE PROVINCIAL GOVERNOR','OFFICE OF THE PROVINCIAL ADMINISTRATOR') ORDER BY deptid", CommandType.Text)

        drpApprovedBy.DataTextField = ("full_name")
        drpApprovedBy.DataValueField = ("empid")
        drpApprovedBy.DataBind()

    End Sub
    'Protected Sub LoadSupplier()
    '    If pPO IsNot Nothing AndAlso pPO.Rows.Count > 0 Then
    '        drpSupllier.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier WHERE Supplier_Id = '" & pPO.Rows(0)("Supplier_ID") & "' ORDER BY SuppName", CommandType.Text)
    '        drpSupllier.DataTextField = "SuppName"
    '        drpSupllier.DataValueField = "Supplier_Id"
    '        drpSupllier.DataBind()
    '    Else
    '        ' Optionally log or display a message that no supplier was found.
    '        drpSupllier.DataSource = Nothing
    '        drpSupllier.DataBind()
    '    End If
    'End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'HERE
        Dim item As String

        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Val(txtHiddenReceiveQty.Value) - 1
                item = Me.grdListofItem.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdListofItem.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                    ' btnActSave.Enabled = True
                    ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = True
                    'pInspection_detail.Rows(Me.grdInspection.Rows(i).Cells(4).Text)("isChecked") = True

                End If
            Next
        Else
            For i As Integer = 0 To Val(txtHiddenReceiveQty.Value) - 1
                item = Me.grdListofItem.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdListofItem.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                s.Checked = False
                ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = False
                ' pInspection_detail.Rows(Me.grdInspection.Rows(i).Cells(4).Text)("isChecked") = False
            Next
        End If


    End Sub
    Protected Sub grdRO_SelectedIndexChanged(sender As Object, e As EventArgs)

        pPurchase_Order_Item = objDerived.GetDataTable("EXEC [AMS].[sp_RO_Items] '" & grdRO.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        pPurchase_Order_Item_Body = objDerived.GetDataTable("EXEC [AMS].[sp_RO_Items] '" & grdRO.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

        txtHiddenReceiveQty.Value = pPurchase_Order_Item.Rows.Count
        If pPurchase_Order_Item.Rows.Count < 5 Then
            pPurchase_Order_Item.Merge(CreateTable1(5 - pPurchase_Order_Item.Rows.Count))
        End If
        grdListofItem.DataSource = pPurchase_Order_Item
        grdListofItem.DataBind()

        pPR = objDerived.GetDataTable("select * from AMS.PR_Hdr WHERE pr_no = '" & grdRO.SelectedDataKey("pr_no") & "' ", CommandType.Text)

        'pPO = objDerived.GetDataTable("select * from AMS.PO_Hdr WHERE POHdr_ID = '" & grdRO.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

        txtPurpose.Text = pPR.Rows(0)("remarks")
        LoadDepartment()
        txtPR_No.Text = grdRO.SelectedDataKey("pr_no")

    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        ' Trace the start of btnSave_Click execution
        AddTrace("Starting btnSave_Click execution.")


        If String.IsNullOrEmpty(drpPPA.SelectedValue) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No valid selection in drpPPA.")
            Exit Sub
        End If






        ' Capture the values of variables
        Dim department As String = Me.drpDepartment.SelectedItem.Value
        Dim functionValue As String = drpFunction.SelectedItem.Value
        Dim nature As String = drpNature.SelectedItem.Value
        Dim projectID As String = pPR.Rows(0)("Project_ID").ToString()
        Dim programID As String = pPR.Rows(0)("Program_ID").ToString()

        Dim currentYear As String = Year(CDate(Date.Today)).ToString()
        Dim isContinuing As String = pPR.Rows(0)("isContinuing").ToString()
        Dim gaID As String = Session("GA_ID").ToString()
        Dim bgaID As String = Session("BGA_ID").ToString()

        ' Log the values before calling the procedure
        AddTrace("Department: " & department)
        AddTrace("Function: " & functionValue)
        AddTrace("Nature: " & nature)
        AddTrace("Project ID: " & projectID)
        AddTrace("Program ID: " & programID)
        AddTrace("Current Year: " & currentYear)
        AddTrace("Is Continuing: " & isContinuing)
        AddTrace("GA_ID: " & gaID)
        AddTrace("BGA_ID: " & bgaID)

        ' Execute the stored procedure with traced values
        Dim query As String = "EXEC [AMS].[sp_BudgetCheck_ForPR] '" & department & "','" & functionValue & "','" & nature & "','" & projectID & "','" & programID & "','" & currentYear & "','" & isContinuing & "','" & gaID & "','" & bgaID & "'"
        Dim budget As Decimal = objDerived.GetValue(query, CommandType.Text)

        ' Log the final fetched budget
        AddTrace("Budget fetched: " & budget.ToString())


        Dim lblTotalAmount As Label = TryCast(grdListofItem.FooterRow.FindControl("lblTotalAmount"), Label)
        Dim ABC As Decimal = lblTotalAmount.Text
        AddTrace("Total Amount: " & ABC.ToString())

        If budget < ABC Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR amount exceeds from the available budget.")
            AddTrace("Condition met: Budget < Total Amount. Exiting btnSave_Click.")
            Exit Sub
        End If

        Dim prhdrID As Long
        AddTrace("Proceeding to save PR_Hdr.")

        '=-= Saving PR_Hdr (Goods)
        prhdr.PR_Year = Year(Date.Today.ToString("MM/dd/yyyy"))
        prhdr.PR_Date = "01/01/1900"
        prhdr.RC_ID = drpDepartment.SelectedItem.Value
        prhdr.Function_ID = drpFunction.SelectedItem.Value
        prhdr.remarks = txtPurpose.Text
        prhdr.Transaction_type = drpNature.SelectedItem.Value
        prhdr.Project_ID = pPR.Rows(0)("Project_ID")
        prhdr.Program_id = pPR.Rows(0)("Program_ID")

        prhdr.ABC = lblTotalAmount.Text
        prhdr.Requestedby = drpRequestingPerson.SelectedItem.Value
        prhdr.Approvedby = drpApprovedBy.SelectedItem.Value
        prhdr.Date_Submitted = Date.Today
        prhdr.Date_gso_rcv = "01/01/1900"
        prhdr.IsCancelled = False
        prhdr.IsApproved = False
        prhdr.isOnBid = False
        prhdr.POHdr_ID = 0
        prhdr.withWinner = False
        prhdr.withPO = False
        prhdr.declarationDate = "01/01/1900"
        prhdr.rcv_date = "01/01/1900"
        prhdr.isPublicInfra = False
        prhdr.isStraight = False
        prhdr.DateApproved_PR_Mayor = "01/01/1900"
        prhdr.DateReceived_PR_Mayor = "01/01/1900"
        prhdr.isApproved_PR_Mayor = False
        prhdr.isReceived_PR_Mayor = False
        prhdr.DateDisApprove = "01/01/1900"
        prhdr.isGasoline = False
        prhdr.pr_period_key_id = 0
        prhdr.pr_invoice_hdr_id = 0
        prhdr.isReimbursement = False
        prhdr.isContract = False
        prhdr.isEditable = True
        prhdr.RequestingOfficer = pPR.Rows(0)("RequestingOfficer")
        prhdr.Position = pPR.Rows(0)("Position")
        prhdr.isContinuing = pPR.Rows(0)("isContinuing")
        prhdr.mode_of_procurement_id = 0
        prhdr.isTrustFund = False
        prhdr.CheckBy = 0
        prhdr.NotedBy = 0
        prhdr.GA_ID = Session("GA_ID")
        prhdr.UserID = Session("@UserName")
        prhdrID = prhdr.save
        AddTrace("PR_Hdr saved. PRHdr_ID: " & prhdrID.ToString())

        Session("PRNo") = prhdrID
        Session("prhdr_id") = prhdrID




        Dim CTO As Integer
        CTO = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
        AddTrace("CTO fetched: " & CTO.ToString())

        objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = '" & pPR.Rows(0)("F_ID") & "', CityTreasurer = '" & pPR.Rows(0)("CityTreasurer") & "', comment = '" & pPR.Rows(0)("comment") & "', Address = '" & pPR.Rows(0)("Address") & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)

        objDerived.GetRecords("Update ams.PR_Hdr set rcv_date='" & Date.Today & "', isEditable = 0 where prhdr_id=" & prhdrID & "", CommandType.Text)

        '=-= Saving PR_Dtl
        AddTrace("Starting to save PR_Dtl.")
        Dim minRowCount As Integer = Math.Min(grdListofItem.Rows.Count, pPurchase_Order_Item_Body.Rows.Count)

        For i As Integer = 0 To minRowCount - 1
            If CType(Me.grdListofItem.Rows(i).Cells(3).FindControl("txtRepeatOrderQty"), TextBox).Text <> "0" Then
                prdtl.PRHdr_ID = prhdrID
                prdtl.Item_ID = pPurchase_Order_Item_Body.Rows(i)("Item_ID")
                prdtl.Project_title = txtPurpose.Text
                prdtl.PR_ItemSpecs = ""
                prdtl.Qty = CType(grdListofItem.Rows(i).FindControl("txtRepeatOrderQty"), TextBox).Text
                prdtl.Cost = CType(grdListofItem.Rows(i).FindControl("lblPrice"), Label).Text

                ' Check if ppmp_dtl_id exists before accessing
                If pPurchase_Order_Item_Body.Columns.Contains("ppmp_dtl_id") Then
                    prdtl.ppmp_dtl_id = pPurchase_Order_Item_Body.Rows(i)("ppmp_dtl_id")
                Else
                    AddTrace("Warning: 'ppmp_dtl_id' column is missing.")
                End If

                ' ✅ Safe database query
                Dim iQty As Decimal = objDerived.GetValue("SELECT ISNULL(Qty, 0) FROM AMS.PR_Dtl WHERE PRHdr_ID = '" & prhdrID & "' AND Item_ID = '" & pPurchase_Order_Item_Body.Rows(i)("Item_ID") & "'", CommandType.Text)

                If iQty = 0 Then
                    prdtl.save()
                    AddTrace("New PR_Dtl record saved for Item ID: " & pPurchase_Order_Item_Body.Rows(i)("Item_ID").ToString())
                Else
                    Dim NewQTY As Decimal = iQty + CType(grdListofItem.Rows(i).FindControl("txtRepeatOrderQty"), TextBox).Text
                    Dim PRdtl_ID As Long = objDerived.GetValue("SELECT PRDtlID FROM AMS.PR_Dtl WHERE PRHdr_ID = '" & prhdrID & "' AND Item_ID = '" & pPurchase_Order_Item_Body.Rows(i)("Item_ID") & "'", CommandType.Text)

                    objDerived.Execute("UPDATE AMS.PR_Dtl SET Qty = '" & NewQTY & "' WHERE PRDtlID = '" & PRdtl_ID & "'", CommandType.Text)
                    AddTrace("Updated PR_Dtl for Item ID: " & pPurchase_Order_Item_Body.Rows(i)("Item_ID").ToString() & " with new Qty: " & NewQTY.ToString())
                End If
            End If
        Next


        '=-= Saving CAA_Hdr
        AddTrace("Starting to save CAA_Hdr.")
        CAA_hdr.TempOBR_No = ""
        Dim obj As New BaseClassesint.AccountClassAcounts
        Dim func_per_office As String = objDerived.GetValue("SELECT Func_per_Office_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office WHERE Office_ID = '" & drpDepartment.SelectedItem.Value & "' AND Function_ID = '" & drpFunction.SelectedItem.Value & "'", CommandType.Text)
        AddTrace("Func_per_Office_ID fetched: " & func_per_office)

        Dim str As String
        If pPR.Rows(0)("F_ID") = 1 Then
            str = "100"
        Else
            str = "200"
        End If

        Dim d As Date = Date.Today
        Dim selectedIndex As Integer = Math.Max(0, drpPPA.SelectedIndex - 1)
        Dim FundSourceID As Integer = objDerived.GetValue("SELECT TOP(1) F_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Program AS m_Program WHERE Program_ID = '" & PAPS.Rows(selectedIndex)("Program_id") & "'", CommandType.Text)
        AddTrace("FundSourceID fetched: " & FundSourceID.ToString())

        If FundSourceID = 14 Then
            CAA_hdr.OBR_No = str & "(18)" & "-" & d.ToString("yy") & "-"
        Else
            CAA_hdr.OBR_No = str & "-" & d.ToString("yy") & "-"
        End If

        CAA_hdr.F_ID_Accntg = pPR.Rows(0)("F_ID")
        CAA_hdr.Period_key = 0
        CAA_hdr.PRHdr_ID = prhdrID
        CAA_hdr.OBR_Date = Date.Today
        CAA_hdr.OBR_Title = txtOBR_No.Text
        CAA_hdr.Budget_Year = Year(Date.Today)
        CAA_hdr.Supplier_ID = 0
        CAA_hdr.Payee = txtPayee.Text
        CAA_hdr.Func_per_Office_ID = func_per_office
        CAA_hdr.Address = txtSupplierAddress.Text
        CAA_hdr.Remarks = ""
        CAA_hdr.isPayroll = False
        CAA_hdr.isApprovedMayor = False
        CAA_hdr.isApproved = True
        CAA_hdr.isCancelled = False
        CAA_hdr.DateSigned1 = Date.Today
        CAA_hdr.DateSigned2 = Date.Today
        CAA_hdr.isPayroll = False
        CAA_hdr.Signatory1_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_EmployeeSignatories WHERE dept_id = '" & drpDepartment.SelectedItem.Value & "' AND func_id = '" & drpFunction.SelectedItem.Value & "' AND isDeptHead = 1", CommandType.Text)
        AddTrace("Signatory1_ID fetched: " & CAA_hdr.Signatory1_ID.ToString())

        CAA_hdr.Signatory2_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_CityBudgetOfficer", CommandType.Text)
        AddTrace("Signatory2_ID fetched: " & CAA_hdr.Signatory2_ID.ToString())
        CAA_hdr.Status = "Pending"
        CAA_hdr.isAdjusted = False
        CAA_hdr.isAddForDisbursement = False
        CAA_hdr.isPayrollATM = False
        CAA_hdr.isGasoline = False
        CAA_hdr.pr_period_key_id = 0
        CAA_hdr.pr_invoice_hdr_id = 0
        CAA_hdr.DateDisapprovedMayor = "01/01/1900"
        CAA_hdr.DateApprovedMayor = "01/01/1900"
        CAA_hdr.DateReceivedMayor = "01/01/1900"
        CAA_hdr.isReceivedBO = False
        CAA_hdr.PayeeOffice = ""

        Dim obr_hdr_id As Long = CAA_hdr.save()
        AddTrace("CAA_Hdr saved. OBR_Hdr_ID: " & obr_hdr_id.ToString())

        Session("obr_id") = obr_hdr_id

        objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_CAA_Hdr SET forContinuing = '" & pPR.Rows(0)("isContinuing") & "' WHERE OBR_Hdr_ID = " & obr_hdr_id, CommandType.Text)

        '=-= Saving CAA_dtl 
        AddTrace("Starting to save CAA_dtl.")
        CAA_dtl.OBR_Hdr_ID = obr_hdr_id
        CAA_dtl.particulars = ""
        CAA_dtl.BGA_ID = Session("BGA_ID")
        CAA_dtl.RC_ID = drpDepartment.SelectedItem.Value
        CAA_dtl.Function_ID = drpFunction.SelectedItem.Value
        CAA_dtl.Program_ID = pPR.Rows(0)("Program_ID")
        CAA_dtl.Project_ID = pPR.Rows(0)("Project_ID")

        CAA_dtl.GA_ID = Session("GA_ID")
        CAA_dtl.Amount = lblTotalAmount.Text
        CAA_dtl.AllotmentClass_ID = drpNature.SelectedItem.Value
        CAA_dtl.save()
        AddTrace("CAA_dtl saved.")

        Dim amount As Decimal
        amount = CAA_dtl.Amount

        ''PURCHASE REQUEST RECEIVING
        objDerived.GetRecords("Update ams.PR_Hdr set rcv_date='" & Date.Today & "', isEditable = 0 where prhdr_id=" & Session("prhdr_id") & "", CommandType.Text)

        ''PURCHASE REQUEST APPROVAL
        Dim isWithPR As DataTable

        Dim pr_no As String
        pr_no = objDerived.GetValue("select [AMS].[func_GeneratePR_Bataan]('" & Date.Today & "','" & Session("prhdr_id") & "')", CommandType.Text)

        Dim value1 As New DataTable
        value1 = objDerived.GetDataTable("select Rc_Id, Function_id,PR_year,Project_id,Program_id from Ams.Pr_hdr where prhdr_id=" & Session("prhdr_id") & " ", CommandType.Text)

        objDerived.GetRecords("UPDATE AMS.pr_hdr SET pr_no = '" & pr_no & "', isApproved= 1, isReceived_PR_Mayor = 1, isApproved_PR_Mayor = 1, " &
                                        " pr_date = '" & Date.Today & "', " &
                                        " DateApproved_PR_Mayor = '" & Date.Today & "', " &
                                        " Date_gso_rcv = '" & Date.Today & "' " &
                                        " WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)



        ' Update the saved pr_no to set isForROApproval = 1
        Dim updateQuery As String = "UPDATE AMS.PR_Hdr SET isForROApproval = 1 WHERE pr_no = '" & grdRO.SelectedDataKey("pr_no") & "'"

        objDerived.GetRecords(updateQuery, CommandType.Text)
        'AddTrace("PR_Hdr updated: isForROApproval set to 1 for pr_no: '" & grdRO.SelectedDataKey("pr_no") & "'"



        AddTrace("Purchase Request saved and approved.")
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        LoadRO()
    End Sub


    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)

    End Sub



    'Protected Sub btnSave_Click(sender As Object, e As EventArgs)
    '    Dim budget As Decimal = objDerived.GetValue("EXEC [AMS].[sp_BudgetCheck_ForPR] '" & Me.drpDepartment.SelectedItem.Value & "','" & drpFunction.SelectedItem.Value & "','" & drpNature.SelectedItem.Value & "','" & PAPS.Rows(drpPPA.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(drpPPA.SelectedIndex - 1)("Program_id") & "','" & Year(CDate(Date.Today)) & "','" & pPR.Rows(0)("isContinuing") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "'", CommandType.Text)
    '    Dim lblTotalAmount As Label = TryCast(grdListofItem.FooterRow.FindControl("lblTotalAmount"), Label)
    '    Dim ABC As Decimal = lblTotalAmount.Text
    '    If budget < ABC Then
    '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR amount exceeds from the available budget.")
    '        Exit Sub
    '    End If
    '    Dim prhdrID As Long

    '    '=-= Saving PR_Hdr (Goods)
    '    prhdr.PR_Year = Year(Date.Today.ToString("MM/dd/yyyy")) 'Year(CDate(txtprdate.Text)) 
    '    prhdr.PR_Date = "01/01/1900"
    '    prhdr.RC_ID = drpDepartment.SelectedItem.Value
    '    prhdr.Function_ID = drpFunction.SelectedItem.Value
    '    prhdr.remarks = txtPurpose.Text
    '    prhdr.Transaction_type = drpNature.SelectedItem.Value
    '    prhdr.Project_ID = PAPS.Rows(drpPPA.SelectedIndex - 1)("Project_ID")
    '    prhdr.Program_id = PAPS.Rows(drpPPA.SelectedIndex - 1)("Program_id")
    '    prhdr.ABC = lblTotalAmount.Text
    '    prhdr.Requestedby = drpRequestingPerson.SelectedItem.Value
    '    prhdr.Approvedby = drpApprovedBy.SelectedItem.Value
    '    prhdr.Date_Submitted = Date.Today
    '    prhdr.Date_gso_rcv = "01/01/1900"
    '    prhdr.IsCancelled = False
    '    prhdr.IsApproved = False
    '    prhdr.isOnBid = False
    '    prhdr.POHdr_ID = 0
    '    prhdr.withWinner = False
    '    prhdr.withPO = False
    '    prhdr.declarationDate = "01/01/1900"
    '    prhdr.rcv_date = "01/01/1900"
    '    prhdr.isPublicInfra = False
    '    prhdr.isStraight = False
    '    prhdr.DateApproved_PR_Mayor = "01/01/1900"
    '    prhdr.DateReceived_PR_Mayor = "01/01/1900"
    '    prhdr.isApproved_PR_Mayor = False
    '    prhdr.isReceived_PR_Mayor = False
    '    prhdr.DateDisApprove = "01/01/1900"
    '    prhdr.isGasoline = False
    '    prhdr.pr_period_key_id = 0
    '    prhdr.pr_invoice_hdr_id = 0
    '    prhdr.isReimbursement = False
    '    prhdr.isContract = False
    '    prhdr.isEditable = True
    '    prhdr.RequestingOfficer = pPR.Rows(0)("RequestingOfficer")
    '    prhdr.Position = pPR.Rows(0)("Position")
    '    prhdr.isContinuing = pPR.Rows(0)("isContinuing")
    '    prhdr.mode_of_procurement_id = 0
    '    prhdr.isTrustFund = False
    '    prhdr.CheckBy = 0
    '    prhdr.NotedBy = 0
    '    prhdr.GA_ID = Session("GA_ID")
    '    prhdr.UserID = Session("@UserName")
    '    prhdrID = prhdr.save

    '    Session("PRNo") = prhdrID
    '    Session("prhdr_id") = prhdrID

    '    Dim CTO As Integer
    '    CTO = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
    '    objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = '" & pPR.Rows(0)("F_ID") & "', CityTreasurer = '" & pPR.Rows(0)("CityTreasurer") & "', comment = '" & pPR.Rows(0)("comment") & "', Address = '" & pPR.Rows(0)("Address") & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)

    '    objDerived.GetRecords("Update ams.PR_Hdr set rcv_date='" & Date.Today & "', isEditable = 0 where prhdr_id=" & prhdrID & "", CommandType.Text)


    '    '=-= Saving PR_Dtl
    '    For i As Integer = 0 To Me.grdListofItem.Rows.Count - 1
    '        If CType(Me.grdListofItem.Rows(i).Cells(3).FindControl("txtRepeatOrderQty"), Label).Text <> "0" Then
    '            prdtl.PRHdr_ID = prhdrID
    '            prdtl.Item_ID = pPurchase_Order_Item_Body.Rows(i)("Item_ID")
    '            'If CType(gvbody.Rows(i).FindControl("txtMemo"), TextBox).Text <> "" Then
    '            prdtl.Project_title = txtPurpose.Text
    '            ' Else
    '            'prdtl.Project_title = ""
    '            'End If

    '            prdtl.PR_ItemSpecs = ""

    '            prdtl.Qty = CType(grdListofItem.Rows(i).FindControl("txtRepeatOrderQty"), TextBox).Text 'CType(gvbody.Rows(i).FindControl("lblBalance"), Label).Text() 
    '            prdtl.Cost = CType(grdListofItem.Rows(i).FindControl("lblPrice"), Label).Text
    '            prdtl.ppmp_dtl_id = pPurchase_Order_Item_Body.Rows(i)("ppmp_dtl_id")
    '            'prdtl.Userid = Me.Session("@UserName").ToString 

    '            Dim iQty As Decimal
    '            iQty = objDerived.GetValue("SELECT AMS.PR_Dtl.Qty FROM AMS.PR_Hdr INNER JOIN AMS.PR_Dtl ON AMS.PR_Hdr.prhdr_id = AMS.PR_Dtl.PRHdr_ID WHERE AMS.PR_Hdr.prhdr_id = '" & prhdrID & "' AND AMS.PR_Dtl.Item_ID = '" & pPurchase_Order_Item_Body.Rows(i)("Item_ID") & "'", CommandType.Text)
    '            If iQty = 0 Then
    '                prdtl.save()
    '            Else
    '                Dim NewQTY As Decimal
    '                NewQTY = CType(iQty + CType(grdListofItem.Rows(i).FindControl("txtRepeatOrderQty"), TextBox).Text, Decimal)

    '                Dim PRdtl_ID As Long
    '                PRdtl_ID = objDerived.GetValue("SELECT AMS.PR_Dtl.PRDtlID FROM AMS.PR_Hdr INNER JOIN AMS.PR_Dtl ON AMS.PR_Hdr.prhdr_id = AMS.PR_Dtl.PRHdr_ID WHERE AMS.PR_Hdr.prhdr_id = '" & prhdrID & "' AND AMS.PR_Dtl.Item_ID = '" & pPurchase_Order_Item_Body.Rows(i)("Item_ID") & "'", CommandType.Text)

    '                objDerived.Execute("UPDATE AMS.PR_Dtl SET Qty = '" & NewQTY & "' WHERE PRDtlID = '" & PRdtl_ID & "'", CommandType.Text)
    '            End If

    '        End If
    '        CType(grdListofItem.Rows(i).FindControl("txtRepeatOrderQty"), TextBox).ReadOnly = True
    '    Next

    '    '=-= Saving CAA_Hdr
    '    CAA_hdr.TempOBR_No = ""
    '    Dim obj As New BaseClassesint.AccountClassAcounts
    '    Dim func_per_office As String = objDerived.GetValue("SELECT Func_per_Office_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office WHERE Office_ID = '" & drpDepartment.SelectedItem.Value & "' AND Function_ID = '" & drpFunction.SelectedItem.Value & "'", CommandType.Text)

    '    Dim str As String
    '    If pPR.Rows(0)("F_ID") = 1 Then
    '        str = "100"
    '    Else
    '        str = "200"
    '    End If

    '    Dim d As Date = Date.Today
    '    Dim FundSourceID As Integer = objDerived.GetValue("SELECT TOP(1) F_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Program AS m_Program WHERE Program_ID = '" & PAPS.Rows(drpPPA.SelectedIndex - 1)("Program_id") & "'", CommandType.Text)

    '    If FundSourceID = 14 Then
    '        CAA_hdr.OBR_No = str & "(18)" & "-" & d.ToString("yy") & "-"
    '    Else
    '        CAA_hdr.OBR_No = str & "-" & d.ToString("yy") & "-"
    '    End If

    '    CAA_hdr.F_ID_Accntg = pPR.Rows(0)("F_ID")
    '    CAA_hdr.Period_key = 0
    '    CAA_hdr.PRHdr_ID = prhdrID
    '    CAA_hdr.OBR_Date = Date.Today
    '    CAA_hdr.OBR_Title = txtOBR_No.Text
    '    CAA_hdr.Budget_Year = Year(Date.Today)
    '    CAA_hdr.Supplier_ID = 0
    '    CAA_hdr.Payee = txtPayee.Text
    '    CAA_hdr.Func_per_Office_ID = func_per_office
    '    CAA_hdr.Address = txtSupplierAddress.Text
    '    CAA_hdr.Remarks = ""
    '    CAA_hdr.isPayroll = False
    '    CAA_hdr.isApprovedMayor = False
    '    CAA_hdr.isApproved = True
    '    CAA_hdr.isCancelled = False
    '    CAA_hdr.DateSigned1 = Date.Today
    '    CAA_hdr.DateSigned2 = Date.Today
    '    CAA_hdr.isPayroll = False
    '    CAA_hdr.Signatory1_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_EmployeeSignatories WHERE dept_id = '" & drpDepartment.SelectedItem.Value & "' AND func_id = '" & drpFunction.SelectedItem.Value & "' AND isDeptHead = 1", CommandType.Text)
    '    CAA_hdr.Signatory2_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_CityBudgetOfficer", CommandType.Text)
    '    CAA_hdr.Status = "Pending"
    '    CAA_hdr.isAdjusted = False
    '    CAA_hdr.isAddForDisbursement = False
    '    CAA_hdr.isPayrollATM = False
    '    CAA_hdr.isGasoline = False
    '    CAA_hdr.pr_period_key_id = 0
    '    CAA_hdr.pr_invoice_hdr_id = 0
    '    CAA_hdr.DateDisapprovedMayor = "01/01/1900"
    '    CAA_hdr.DateApprovedMayor = "01/01/1900"
    '    CAA_hdr.DateReceivedMayor = "01/01/1900"
    '    CAA_hdr.isReceivedBO = False
    '    CAA_hdr.PayeeOffice = ""

    '    Dim obr_hdr_id As Long = CAA_hdr.save()
    '    Session("obr_id") = obr_hdr_id

    '    objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_CAA_Hdr SET forContinuing = '" & pPR.Rows(0)("isContinuing") & "' WHERE OBR_Hdr_ID = " & obr_hdr_id, CommandType.Text)


    '    '=-= Saving CAA_dtl 
    '    CAA_dtl.OBR_Hdr_ID = obr_hdr_id
    '    CAA_dtl.particulars = ""
    '    CAA_dtl.BGA_ID = Session("BGA_ID")
    '    CAA_dtl.RC_ID = drpDepartment.SelectedItem.Value
    '    CAA_dtl.Function_ID = drpFunction.SelectedItem.Value
    '    CAA_dtl.Program_ID = PAPS.Rows(drpPPA.SelectedIndex - 1)("Program_id")
    '    CAA_dtl.Project_ID = PAPS.Rows(drpPPA.SelectedIndex - 1)("Project_ID")
    '    CAA_dtl.GA_ID = Session("GA_ID")
    '    CAA_dtl.Amount = lblTotalAmount.Text
    '    CAA_dtl.AllotmentClass_ID = drpNature.SelectedItem.Value
    '    CAA_dtl.save()

    '    Dim amount As Decimal
    '    amount = CAA_dtl.Amount


    '    ''PURCHASE REQUEST RECEIVING
    '    objDerived.GetRecords("Update ams.PR_Hdr set rcv_date='" & Date.Today & "', isEditable = 0 where prhdr_id=" & Session("prhdr_id") & "", CommandType.Text)


    '    ''PURCHASE REQUEST APPROVAL
    '    Dim isWithPR As DataTable

    '    Dim pr_no As String
    '    pr_no = objDerived.GetValue("select [AMS].[func_GeneratePR_Bataan]('" & Date.Today & "','" & Session("prhdr_id") & "')", CommandType.Text)

    '    Dim value1 As New DataTable
    '    value1 = objDerived.GetDataTable("select Rc_Id, Function_id,PR_year,Project_id,Program_id from Ams.Pr_hdr where prhdr_id=" & Session("prhdr_id") & " ", CommandType.Text)

    '    objDerived.GetRecords("UPDATE AMS.pr_hdr SET pr_no = '" & pr_no & "', isApproved= 1, isReceived_PR_Mayor = 1, isApproved_PR_Mayor = 1, " &
    '                                    " pr_date = '" & Date.Today & "', " &
    '                                    " DateApproved_PR_Mayor = '" & Date.Today & "', " &
    '                                    " Date_gso_rcv = '" & Date.Today & "' " &
    '                                    " WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)


    '    'objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_CAA_Hdr SET isCancelled = 1, dateCancelled = '" & Date.Today.ToString("MM/dd/yyyy") & "', ReasonForCancellation ='" & txtremarks.text & "', Status = 'Cancelled' WHERE OBR_Hdr_ID = '" & Session("obr_id") & "'", CommandType.Text)


    '    'pBudgetInfo = objDerived.GetDataTable("exec ams.sp_budget_release_complete  " & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & ddnature.SelectedItem.Value & "," & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "," & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & ",'" & Year(CDate(txtprdate.Text)) & "',0", CommandType.Text)
    '    'pBudgetInfo = objDerived.GetDataTable("EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
    '    'gvBudgetInfo2.DataSource = pBudgetInfo
    '    'gvBudgetInfo2.DataBind()

    'End Sub





    'Protected Sub grdListofItem_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdListofItem.RowDataBound
    '    Static totalAmount As Decimal = 0 ' Keep track of the total amount

    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        ' Access the price and repeat order qty values
    '        Dim cost As Decimal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "cost"))
    '        Dim repeatQty As Decimal = Convert.ToDecimal(CType(e.Row.FindControl("txtRepeatOrderQty"), TextBox).Text)

    '        ' Calculate subtotal for the current row
    '        totalAmount += cost * repeatQty
    '    ElseIf e.Row.RowType = DataControlRowType.Footer Then
    '        ' Set the calculated total to the footer under the "Price" column
    '        Dim lblTotalAmount As Label = CType(e.Row.FindControl("lblTotalAmount"), Label)
    '        lblTotalAmount.Text = String.Format("{0:N2}", totalAmount)
    '    End If
    'End Sub
    Protected Sub grdListofItem_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdListofItem.RowDataBound
        Static totalAmount As Decimal = 0 ' Keep track of the total amount

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Find controls
            Dim txtRepeatOrderQty As TextBox = CType(e.Row.FindControl("txtRepeatOrderQty"), TextBox)
            Dim lblPrice As Label = CType(e.Row.FindControl("lblPrice"), Label)
            Dim cbInspection As CheckBox = CType(e.Row.FindControl("cbInspection"), CheckBox) ' Find the checkbox

            ' Ensure lblPrice exists before accessing it
            Dim cost As Decimal = 0
            If lblPrice IsNot Nothing AndAlso Not String.IsNullOrEmpty(lblPrice.Text) Then
                cost = Convert.ToDecimal(lblPrice.Text)
            End If

            ' Ensure txtRepeatOrderQty and cbInspection exist before modifying visibility
            If txtRepeatOrderQty IsNot Nothing AndAlso cbInspection IsNot Nothing Then
                ' If the row is empty (i.e., no valid data), hide the text box and checkbox
                If String.IsNullOrEmpty(e.Row.Cells(1).Text.Trim()) OrElse e.Row.Cells(1).Text.Trim() = "&nbsp;" Then
                    txtRepeatOrderQty.Visible = False
                    cbInspection.Visible = False ' Hide the checkbox
                End If
            End If

            ' Calculate subtotal for the current row
            Dim repeatQty As Decimal = 0
            If txtRepeatOrderQty IsNot Nothing AndAlso Not String.IsNullOrEmpty(txtRepeatOrderQty.Text) Then
                repeatQty = Convert.ToDecimal(txtRepeatOrderQty.Text)
            End If

            totalAmount += cost * repeatQty

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            ' Set the calculated total to the footer under the "Price" column
            Dim lblTotalAmount As Label = CType(e.Row.FindControl("lblTotalAmount"), Label)
            If lblTotalAmount IsNot Nothing Then
                lblTotalAmount.Text = String.Format("{0:N2}", totalAmount)
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)


    End Sub
End Class
