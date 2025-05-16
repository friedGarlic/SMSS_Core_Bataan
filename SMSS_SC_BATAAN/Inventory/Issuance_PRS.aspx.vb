
Imports System.Data

Partial Class Inventory_Issuance_PRS
    Inherits System.Web.UI.Page
    Dim objAccess As New AccessRule
    Dim objDerived As New DerivedDal
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


    Private Property dtissue() As DataTable
        Get
            Return CType(Session("dtissue"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtissue") = value
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

    Public Function Createdatabalegvsearch(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("ItemParticular", GetType(String))
        dt.Columns.Add("isDonated", GetType(Boolean))
        dt.Columns.Add("Qty", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("ItemParticular") = DBNull.Value
            dr("isDonated") = DBNull.Value
            dr("Qty") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
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
        dt.Columns.Add("PRSDate", GetType(String))
        dt.Columns.Add("ReturnedBy", GetType(String))
        dt.Columns.Add("Returnedto", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            'dr("Property_Dtl_ID") = DBNull.Value
            dr("PRSDate") = DBNull.Value
            dr("ReturnedBy") = DBNull.Value
            dr("Returnedto") = DBNull.Value

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Sub loadDepartments()
        'dtDepartment = objDerived.GetDataTable("SELECT DISTINCT UPPER(RC_Name) AS RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
        'drpDepartment.DataSource = ""
        dtDepartment = objDerived.GetDataTable("[AMS].[sp_VIEW_Departments] '" & Session("@UserID") & "'", CommandType.Text)
        drpDepartment.DataSource = dtDepartment
        drpDepartment.DataTextField = ("RC_Name")
        drpDepartment.DataValueField = ("RC_ID")
        drpDepartment.DataBind()
        '  drpDepartment.Items.Insert(0, "Select")
    End Sub
    Public Sub loadFunction()
        drpFunction.DataSource = objDerived.GetDataTable("SELECT UPPER(Function_desc) AS Function_desc, Function_ID FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & drpDepartment.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        drpFunction.DataTextField = ("Function_desc")
        drpFunction.DataValueField = ("Function_ID")
        drpFunction.DataBind()
        '  drpFunction.Items.Insert(0, "Select")
    End Sub
    Public Sub loadFund()
        drpFund.DataSource = objDerived.GetDataTable("select * from ACCNTG.Funds", CommandType.Text)
        drpFund.DataTextField = ("Description")
        drpFund.DataValueField = ("F_ID")
        drpFund.DataBind()
        '  drpFunction.Items.Insert(0, "Select")
    End Sub
    Public Sub loadGAccounts()
        Dim dProperty As New DataTable

        dProperty = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 3 & "'", CommandType.Text)
        drpGenAccnt.DataSource = CType(dProperty, DataTable)
        drpGenAccnt.DataTextField = ("GA_Title")
        drpGenAccnt.DataValueField = ("GA_ID")
        drpGenAccnt.DataBind()
        '   ddProperty.Items.Insert(0, "Select")
    End Sub
    Protected Sub LoadPropertyDropDown()
        Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v3_12022022] '" & Session("GA_ID") & "','" & drpDepartment.SelectedItem.Text & "'", CommandType.Text)
        If Ppropertylist.Rows.Count < 10 Then
            Ppropertylist.Merge(Createdatabalegvsearch(9 - Ppropertylist.Rows.Count))
            gvsearchProperty.DataSource = Ppropertylist
            gvsearchProperty.DataBind()
        Else
            gvsearchProperty.DataSource = Ppropertylist
            gvsearchProperty.DataBind()
        End If

        LoadPropertyList()

    End Sub
    Protected Sub LoadPropertyList()
        grListOfProperty.DataSource = CreatedatabalegrListOfProperty(5)
        grListOfProperty.DataBind()

        For i As Integer = 0 To grListOfProperty.Rows.Count - 1
            grListOfProperty.Rows(i).Cells(0).Enabled = False
        Next

    End Sub
    Private Sub Inventory_Issuance_PRS_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            loadDepartments()
            loadFunction()
            loadGAccounts()
            gvsearchProperty.DataSource = Createdatabalegvsearch(5)
            gvsearchProperty.DataBind()
            LoadPropertyList()
            grdIssueItems.DataSource = Nothing
            grdIssueItems.DataBind()
            loadPendingPRS()
            loadFund()
            btnSave.enabled = False
        End If

    End Sub

    Public Sub LoadwithOutProperty()
        Dim x As String = IIf(IsDBNull(gvsearchProperty.SelectedDataKey("Item_id")), 0, (gvsearchProperty.SelectedDataKey("Item_id")))
        If x = 0 Then
            LoadPropertyList()
            Exit Sub
        End If

        'Ppropertylist = Me.objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyToIssue_v2] '" & gvsearchProperty.SelectedDataKey("Item_id") & "', '" & gvsearchProperty.SelectedDataKey("isDonated") & "'", CommandType.Text)



        Ppropertylist = objDerived.GetDataTable("EXEC [AMS].[sp_Inventory_PRS] '" & gvsearchProperty.SelectedDataKey("Item_id") & "', '" & gvsearchProperty.SelectedDataKey("isDonated") & "','" & drpDepartment.SelectedItem.Value & "','" & drpFunction.SelectedItem.Value & "'", CommandType.Text)
        If Ppropertylist.Rows.Count = 0 Then
            LoadPropertyList()

        Else
            '  btnviewProperty.Enabled = True
            Dim ItemId As New Integer
            ItemId = Me.gvsearchProperty.SelectedDataKey("Item_id").ToString
            Session("itemId") = ItemId

            If Ppropertylist.Rows.Count < 5 Then
                Ppropertylist.Merge(CreatedatabalegrListOfProperty(4 - Ppropertylist.Rows.Count))
            End If
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
    End Sub


    Protected Sub gvsearchProperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvsearchProperty.SelectedIndexChanged
        'btnsavedoc.Enabled = False
        'btncancelDoc.Enabled = False
        'btnpreviewAreDoc.Enabled = False

        Dim dt As New DataTable
        grListOfProperty.DataSource = dt
        grListOfProperty.DataBind()

        LoadwithOutProperty()

    End Sub
    Protected Sub drpGenAccnt_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Public Sub loadPendingPRS()

        btnViewPending.CssClass = "Clicked"
        btnViewApproved.CssClass = "Initial"
        btnViewDisApproved.CssClass = "Initial"
        Me.mvPropertyReturnSlips.SetActiveView(Me.vwPending)

        Dim dtAccount As New DataTable
        dtAccount = objDerived.getdatatable("exec AMS.sp_loadPRS '" & drpDepartment.SelectedItem.Value & "','Pending'", commandtype.text)
        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatablependingPRS(9))
        End If
        grdPendingPRS.DataSource = dtAccount
        grdPendingPRS.DataBind()

    End Sub
    Public Sub loadApprovedPRS()

        btnViewApproved.CssClass = "Clicked"
        btnViewPending.CssClass = "Initial"
        btnViewDisApproved.CssClass = "Initial"
        'Me.mvledger.SetActiveView(Me.vwledger)

        Me.mvPropertyReturnSlips.SetActiveView(Me.vwApproved)
        Dim dtAccount As New DataTable
        dtAccount = objDerived.GetDataTable("exec AMS.sp_loadPRS '" & drpDepartment.SelectedItem.Value & "','Approved'", CommandType.Text)
        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatablependingPRS(9))
        End If
        grdApprovedPRS.DataSource = dtAccount
        grdApprovedPRS.DataBind()

    End Sub

    Public Sub loadDisApprovedPRS()
        btnViewDisApproved.CssClass = "Clicked"
        btnViewPending.CssClass = "Initial"
        btnViewApproved.CssClass = "Initial"
        'Me.mvledger.SetActiveView(Me.vwledger)
        Me.mvPropertyReturnSlips.SetActiveView(Me.vwDisapproved)

        Dim dtAccount As New DataTable
        dtAccount = Nothing
        ' If dtAccount.Rows.Count < 10 Then
        '  dtAccount.Merge(createdatatablependingPRS(9))
        ' End If
        grdDisApprovedPRS.DataSource = createdatatablependingPRS(9)
        grdDisApprovedPRS.DataBind()

    End Sub

    Protected Sub btnViewPending_Click(sender As Object, e As EventArgs)
        loadPendingPRS()
    End Sub
    Protected Sub btnViewApproved_Click(sender As Object, e As EventArgs)
        loadApprovedPRS()
    End Sub


    Protected Sub btnViewDisApproved_Click(sender As Object, e As EventArgs)
        loadDisApprovedPRS()

    End Sub


    Protected Sub btnViewProp_Click(sender As Object, e As EventArgs)
        Session("GA_ID") = drpGenAccnt.SelectedItem.Value
        Session("PropSearch") = 0
        '  txtSearchProperty.Text = ""
        Try
            LoadPropertyDropDown()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub btnADD_Item_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dttemp As New DataTable
        Try
            If grdIssueItems.Rows.Count <= 0 Then
                dtissue2 = Nothing
                Dim dt As New DataTable
                Dim dr As DataRow

                dt.Columns.Add("Item_Desc", GetType(String))
                dt.Columns.Add("PropertyNo", GetType(String))
                dt.Columns.Add("PropertyDate", GetType(String))
                dt.Columns.Add("Cost", GetType(Decimal))
                dt.Columns.Add("rc_name", GetType(String))
                dt.Columns.Add("Status", GetType(String))
                dt.Columns.Add("Item_ID", GetType(Long))
                dt.Columns.Add("PropertyDetai_ID", GetType(Long))
                dt.Columns.Add("rc_id", GetType(Long))
                dt.Columns.Add("function_id", GetType(Long))
                dt.Columns.Add("Property_ID", GetType(Long))
                dt.Columns.Add("isDonated", GetType(Boolean))
                dt.Columns.Add("SerialNo", GetType(String))
                dt.Columns.Add("status", GetType(String))
                dt.Columns.Add("MREDtl_ID", GetType(Long))
                dt.Columns.Add("MREHdr_ID", GetType(Long))

                dr = dt.NewRow
                dr("Item_Desc") = grListOfProperty.SelectedDataKey("Item_Desc")
                dr("PropertyNo") = grListOfProperty.SelectedDataKey("PropertyNo")
                dr("PropertyDate") = grListOfProperty.SelectedDataKey("PropertyDate")
                dr("Cost") = grListOfProperty.SelectedDataKey("Cost")
                dr("rc_name") = grListOfProperty.SelectedDataKey("Rc_name")
                dr("Status") = grListOfProperty.SelectedDataKey("status")
                dr("Item_ID") = grListOfProperty.SelectedDataKey("Item_ID")
                dr("PropertyDetai_ID") = grListOfProperty.SelectedDataKey("PropertyDetai_ID")
                dr("rc_id") = grListOfProperty.SelectedDataKey("rc_id")
                dr("function_id") = grListOfProperty.SelectedDataKey("function_id")
                dr("Property_ID") = grListOfProperty.SelectedDataKey("Property_ID")
                dr("isDonated") = gvsearchProperty.SelectedDataKey("isDonated")
                dr("SerialNo") = grListOfProperty.SelectedDataKey("SerialNo")
                dr("status") = grListOfProperty.SelectedDataKey("status")
                dr("MREDtl_ID") = grListOfProperty.SelectedDataKey("MREDtl_ID")
                dr("MREHdr_ID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
                dt.Rows.Add(dr)

                Session("MREHdr_ID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
                dtissue2 = dt
                dtissue = Nothing

                If grListOfProperty.SelectedDataKey("status") = "On Hand" Then

                Else

                End If

                Dim ReturnBy2 As Long = objDerived.GetValue("SELECT MRto FROM AMS.MRE_Hdr WHERE MREHdr_ID = '" & dtissue2.Rows(0)("MREHdr_ID") & "'", CommandType.Text)
                Session("ReturnBy") = ReturnBy2

                ''dtissue2 = Nothing
                'Dim dt As New DataTable()
                'With dt.Columns
                '    .Add("Item_Desc", GetType(String))
                '    .Add("PropertyNo", GetType(String))
                '    .Add("PropertyDate", GetType(String))
                '    .Add("Cost", GetType(Decimal))
                '    .Add("rc_name", GetType(String))
                '    .Add("Status", GetType(String))
                '    .Add("Item_ID", GetType(Long))
                '    .Add("PropertyDetai_ID", GetType(Long))
                '    .Add("rc_id", GetType(Long))
                '    .Add("function_id", GetType(Long))
                '    .Add("Property_ID", GetType(Long))
                '    .Add("isDonated", GetType(Boolean))
                '    .Add("SerialNo", GetType(String))
                '    .Add("status", GetType(String))
                '    .Add("MREDtl_ID", GetType(Long))
                '    .Add("MREHdr_ID", GetType(Long))
                'End With

                'Dim dr As DataRow = dt.NewRow
                'Dim selectedDataKey = grListOfProperty.SelectedDataKey

                'With dr
                '    .Item("Item_Desc") = selectedDataKey("Item_Desc")
                '    .Item("PropertyNo") = selectedDataKey("PropertyNo")
                '    .Item("PropertyDate") = selectedDataKey("PropertyDate")
                '    .Item("Cost") = selectedDataKey("Cost")
                '    .Item("rc_name") = selectedDataKey("Rc_name")
                '    .Item("Status") = selectedDataKey("status")
                '    .Item("Item_ID") = selectedDataKey("Item_ID")
                '    .Item("PropertyDetai_ID") = selectedDataKey("PropertyDetai_ID")
                '    .Item("rc_id") = selectedDataKey("rc_id")
                '    .Item("function_id") = selectedDataKey("function_id")
                '    .Item("Property_ID") = selectedDataKey("Property_ID")
                '    .Item("isDonated") = gvsearchProperty.SelectedDataKey("isDonated")
                '    .Item("SerialNo") = selectedDataKey("SerialNo")
                '    .Item("status") = selectedDataKey("status")
                '    .Item("MREDtl_ID") = selectedDataKey("MREDtl_ID")
                '    .Item("MREHdr_ID") = selectedDataKey("MREHdr_ID")
                'End With

                'Dim status As String = selectedDataKey("status")
                'Dim mreHdrId As Long = selectedDataKey("MREHdr_ID")

                'If status = "On Hand" Then

                'End If

                'Dim dtissue2 As DataTable = dt
                'Session("MREHdr_ID") = mreHdrId
                'dtissue = Nothing

                'Dim ReturnBy2 As Long = objDerived.GetValue("SELECT MRto FROM AMS.MRE_Hdr WHERE MREHdr_ID = '" & dtissue2.Rows(0)("MREHdr_ID") & "'", CommandType.Text)
                'Session("ReturnBy") = ReturnBy2
            Else
                Dim dt2 As New DataTable
                Dim dr2 As DataRow

                dt2.Columns.Add("Item_Desc", GetType(String))
                dt2.Columns.Add("PropertyNo", GetType(String))
                dt2.Columns.Add("PropertyDate", GetType(String))
                dt2.Columns.Add("Cost", GetType(Decimal))
                dt2.Columns.Add("Rc_name", GetType(String))
                dt2.Columns.Add("Item_ID", GetType(Long))
                dt2.Columns.Add("PropertyDetai_ID", GetType(Long))
                dt2.Columns.Add("rc_id", GetType(Long))
                dt2.Columns.Add("function_id", GetType(Long))
                dt2.Columns.Add("Property_ID", GetType(Long))
                dt2.Columns.Add("isDonated", GetType(Boolean))
                dt2.Columns.Add("SerialNo", GetType(String))
                dt2.Columns.Add("status", GetType(String))
                dt2.Columns.Add("MREDtl_ID", GetType(Long))
                dt2.Columns.Add("MREHdr_ID", GetType(Long))

                For i As Integer = 0 To dtissue2.Rows.Count - 1
                    If dtissue2.Rows(i)("PropertyNo") = grListOfProperty.SelectedDataKey("PropertyNo") Then
                        '=== CHECK IF ITEM ALREADY EXIST
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Item already in the list.")
                        Exit Sub

                    ElseIf dtissue2.Rows(i)("status") <> grListOfProperty.SelectedDataKey("status") Then
                        '=== CHECK IF ALL ITEMS HAS SAME STATUS
                        If dtissue2.Rows(i)("status") = "Returned" Then
                            If grListOfProperty.SelectedDataKey("status") = "Returned" Or grListOfProperty.SelectedDataKey("status") = " - " Then
                                ' btnIssue.Enabled = True
                            Else
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Status did not match.")
                                Exit Sub
                            End If

                        ElseIf dtissue2.Rows(i)("status") = " - " Then
                            If grListOfProperty.SelectedDataKey("status") = "Returned" Or grListOfProperty.SelectedDataKey("status") = " - " Then
                                '  btnIssue.Enabled = True
                            Else
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Status did not match.")
                                Exit Sub
                            End If

                        ElseIf dtissue2.Rows(i)("status") = "On Hand" Then
                            If grListOfProperty.SelectedDataKey("status") = "On Hand" Then
                                ' btnReturnProperty.Enabled = True
                            Else
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Status did not match.")
                                Exit Sub
                            End If

                        End If

                    ElseIf grListOfProperty.SelectedDataKey("MREHdr_ID") <> Session("MRE_ID") Then
                        '=== CHECK IF ITEMS ISSUE TO 1 PERSONEL ONLY
                        Dim ReturnBy1 As Long = objDerived.GetValue("SELECT MRto FROM AMS.MRE_Hdr WHERE MREHdr_ID = '" & Session("MREHdr_ID") & "'", CommandType.Text)
                        Dim ReturnBy2 As Long = objDerived.GetValue("SELECT MRto FROM AMS.MRE_Hdr WHERE MREHdr_ID = '" & dtissue2.Rows(i)("MREHdr_ID") & "'", CommandType.Text)

                        If ReturnBy1 <> ReturnBy2 Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Item has different accountable personel.")
                            Exit Sub
                        Else
                            Session("ReturnBy") = ReturnBy2
                        End If

                    End If

                Next

                dt2 = dtissue2
                dr2 = dt2.NewRow
                dr2("Item_Desc") = grListOfProperty.SelectedDataKey("Item_Desc")
                dr2("PropertyNo") = grListOfProperty.SelectedDataKey("PropertyNo")
                dr2("PropertyDate") = grListOfProperty.SelectedDataKey("PropertyDate")
                dr2("Cost") = grListOfProperty.SelectedDataKey("Cost")
                dr2("rc_name") = grListOfProperty.SelectedDataKey("Rc_name")
                dr2("Item_ID") = grListOfProperty.SelectedDataKey("Item_ID")
                dr2("PropertyDetai_ID") = grListOfProperty.SelectedDataKey("PropertyDetai_ID")
                dr2("rc_id") = grListOfProperty.SelectedDataKey("rc_id")
                dr2("function_id") = grListOfProperty.SelectedDataKey("function_id")
                dr2("Property_ID") = grListOfProperty.SelectedDataKey("Property_ID")
                dr2("isDonated") = gvsearchProperty.SelectedDataKey("isDonated")
                dr2("SerialNo") = grListOfProperty.SelectedDataKey("SerialNo")
                dr2("status") = grListOfProperty.SelectedDataKey("status")
                dr2("MREDtl_ID") = grListOfProperty.SelectedDataKey("MREDtl_ID")
                dr2("MREHdr_ID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
                dt2.Rows.Add(dr2)
                dtissue2 = dt2

            End If

            grdIssueItems.DataSource = dtissue2
            grdIssueItems.DataBind()

            'For i As Integer = 0 To dtissue2.Rows.Count - 1
            '    If dtissue2.Rows(i)("status") = "Returned" Then
            '        If grListOfProperty.SelectedDataKey("status") = "Returned" Or grListOfProperty.SelectedDataKey("status") = " - " Then
            '            btnIssue.Enabled = True
            '        Else
            '            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Status did not match.")
            '            Exit Sub
            '        End If

            '    ElseIf dtissue2.Rows(i)("status") = "On Hand" Then
            '        If grListOfProperty.SelectedDataKey("status") = "On Hand" Then
            '            btnReturnProperty.Enabled = True
            '        Else
            '            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Status did not match.")
            '            Exit Sub
            '        End If

            '    End If
            'Next

            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            drpReturnedto.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE deptid = 7 AND division_key = 86", CommandType.Text)
            drpReturnedto.DataTextField = ("full_name")
            drpReturnedto.DataValueField = ("empid")
            drpReturnedto.DataBind()
            drpReturnedto.Items.Insert(0, "Select")

            drpDesignationby.DataSource = objDerived.GetDataTable("SELECT Signatory_ID,position_desc FROM [HRMS].[view_signatory]  WHERE Signatory_ID =" & Session("ReturnBy"), CommandType.Text)
            drpDesignationby.DataTextField = ("position_desc")
            drpDesignationby.DataValueField = ("Signatory_ID")
            drpDesignationby.DataBind()
            'drpDesignationby.Items.Insert(0, "Select")


            drpReturnedby.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE Signatory_ID =" & Session("ReturnBy"), CommandType.Text)
            drpReturnedby.DataTextField = ("full_name")
            drpReturnedby.DataValueField = ("empid")
            drpReturnedby.DataBind()
            drpReturnedby.Items.Insert(0, "Select")

            drpDesignationto.DataSource = objDerived.GetDataTable("SELECT Signatory_ID,position_desc FROM [HRMS].[view_signatory] WHERE deptid = 7 AND division_key = 86", CommandType.Text)
            drpDesignationto.DataTextField = ("position_desc")
            drpDesignationto.DataValueField = ("Signatory_ID")
            drpDesignationto.DataBind()


            Session("MREHdr_ID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
            '  ModalPopupExtender3.Show()

            drpPurpose.SelectedItem.Value = 0
            btnSave.enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private objMREReturn As New MRE_Return
    Dim objDonationLedger As New ConsolidatedPropertySaving.TbDonation_Ledger
    Dim objLedger As New t_PropertyLedger
    Dim Return_Hdr As New Returned_History.ARE_Returned_History_Hdr
    Dim Return_Dtl As New Returned_History.ARE_Returned_History_Dtl



    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        If drpPurpose.SelectedItem.Value = 0 Or drpReturnedto.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select from the purpose.")
            ' ModalPopupExtender3.Show()
            Exit Sub
        ElseIf drpPurpose.SelectedItem.Value = 1 Then
            objMREReturn.Dispose = False
            objMREReturn.Repair = False
        ElseIf drpPurpose.SelectedItem.Value = 2 Then
            objMREReturn.Dispose = True
            objMREReturn.Repair = False
        ElseIf drpPurpose.SelectedItem.Value = 3 Then
            objMREReturn.Dispose = False
            objMREReturn.Repair = True
        End If

        objDerived.Execute("INSERT INTO [AMS].[tbl_PRS_Hdr]" &
                                                           "([Returned_Date]" &
                                                           ",[RC_ID]" &
                                                           ",[Function_ID]" &
                                                           ",[F_ID]" &
                                                           ",[Purpose]" &
                                                           ",[Remarks]" &
                                                           ",[ReturnedBy]" &
                                                           ",[ReturnedTo]" &
                                                           ",[ReturnedBy_Pos]" &
                                                           ",[ReturnedTo_Pos]" &
                                                           ",[isApproved]" &
                                                           ",[isDisapproved]" &
                                                           ",[UserID])" &
                                                     "VALUES" &
                                                           "('" & txtDate.Text & "'" &
                                                           ",'" & drpDepartment.SelectedItem.Value & "'" &
                                                           ",'" & drpFunction.SelectedItem.Value & "'" &
                                                           ",'1'" &
                                                           ",'" & drpPurpose.SelectedItem.Text & "'" &
                                                           ",'" & txtRemarks.Text & "'" &
                                                           ",'" & drpReturnedby.SelectedItem.Text & "'" &
                                                           ",'" & drpReturnedto.SelectedItem.Text & "'" &
                                                           ",'" & drpDesignationby.SelectedItem.Text.Replace("'", "") & "'" &
                                                           ",'" & drpDesignationto.SelectedItem.Text.Replace("'", "") & "'" &
                                                           ",'0'" &
                                                           ",'0'" &
                                                           ",'" & Session("@UserName") & "')", CommandType.Text)
        Dim prs_hdr_id As Integer = objDerived.GetValue("select max(prs_hdr_id) from [AMS].[tbl_PRS_Hdr]", CommandType.Text)
        Session("prs_hdr_id") = prs_hdr_id
        For i As Integer = 0 To dtissue2.Rows.Count - 1
            Dim PropertyDetai_ID As Integer = Val(objDerived.GetValue("SELECT AMS.Property_Dtl.PropertyDetai_ID FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID WHERE (AMS.Property_Dtl.PropertyNo ='" & dtissue2.Rows(i)("PropertyNo").ToString & "')", CommandType.Text))
            Dim PAR_No As String = objDerived.GetValue("select MRENumber From ams.MRE_Hdr where MREHdr_ID = '" & dtissue2.Rows(i)("MREHdr_ID").ToString & "'", CommandType.Text)
            Dim issuedate As String = objDerived.GetValue("select MRE_Date From ams.MRE_Hdr where MREHdr_ID = '" & dtissue2.Rows(i)("MREHdr_ID").ToString & "'", CommandType.Text)
            Dim issuedto As Integer = Val(objDerived.GetValue("select MRE_Date From ams.MRE_Hdr where MREHdr_ID = '" & dtissue2.Rows(i)("MREHdr_ID").ToString & "'", CommandType.Text))

            objDerived.Execute("INSERT INTO [AMS].[tbl_PRS_Dtl]" &
                                                           "([prs_hdr_id]" &
                                                           ",[PropertyDetai_ID]" &
                                                           ",[PAR_No]" &
                                                           ",[IssuedDate]" &
                                                           ",[IssuedTo])" &
                                                     "VALUES" &
                                                           "('" & prs_hdr_id & "'" &
                                                           ",'" & PropertyDetai_ID & "'" &
                                                           ",'" & PAR_No & "'" &
                                                           ",'" & issuedate & "'" &
                                                           ",'" & issuedto & "')", CommandType.Text)
        Next


        LoadPropertyDropDown()
        LoadwithOutProperty()
        grdIssueItems.DataSource = Nothing
        grdIssueItems.DataBind()
        loadPendingPRS()
        btnSave.enabled = False

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PRS submitted and for approval")

    End Sub
    Protected Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Session("Report") = "PRS_EndUser"
        Session("Page") = "PRS_EndUser"
        Me.Page.Response.Redirect("~/Inventory/t_rpt_return_slip.aspx")
    End Sub
End Class
