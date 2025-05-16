Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class planning_t_PPMP_Supplemental
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim hdr As New t_ppmp_hdr
    Dim dtl As New t_ppmp_dtl
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim savestatus As Boolean


#Region "Property"
    Private Property dtPPMP() As DataTable
        Get
            Return CType(Session("dtPPMP"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPPMP") = value
        End Set
    End Property

    Private Property dtPPA() As DataTable
        Get
            Return CType(Session("dtPPA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPPA") = value
        End Set
    End Property

    Private Property dtAccounts() As DataTable
        Get
            Return CType(Session("dtAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAccounts") = value
        End Set
    End Property

    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
        End Set
    End Property

    Private Property pItems() As DataTable
        Get
            Return CType(Session("pItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItems") = value
        End Set
    End Property

    Property pTempEmpAccount_tbl2() As DataTable
        Get
            Return CType(Session("pTempEmpAccount2"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pTempEmpAccount2") = value
        End Set
    End Property

    Private Property pLbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property

    Private Property pCanEdit() As Boolean
        Get
            Return CType(Session("pCanEdit"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("pCanEdit") = value
        End Set
    End Property

    Private Property saved() As Boolean
        Get
            Return CType(Session("saved"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("saved") = value
        End Set
    End Property

    Private Property rolename() As String
        Get
            Return CType(Session("rolename"), String)
        End Get
        Set(ByVal value As String)
            Session("rolename") = value
        End Set
    End Property

    Private Property pInputQuantity() As Boolean
        Get
            Return CType(Session("pInputQuantity"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("pInputQuantity") = value
        End Set
    End Property
#End Region
#Region "Tables"
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("qty", GetType(Integer))
        dt.Columns.Add("price", GetType(Decimal))
        dt.Columns.Add("total", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("ppmp_dtl_id", GetType(Long))
        dt.Columns.Add("recall", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("id") = 0
            dr("Item_Desc") = ""
            dr("Description") = ""
            dr("qty") = 0
            dr("price") = "0.00"
            dr("total") = "0.00"
            dr("Item_ID") = 0
            dr("ppmp_dtl_id") = 0
            dr("recall") = 0
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("qty1", GetType(Integer))
        dt.Columns.Add("qty2", GetType(Integer))
        dt.Columns.Add("qty3", GetType(Integer))
        dt.Columns.Add("qty4", GetType(Integer))
        dt.Columns.Add("price1", GetType(Decimal))
        dt.Columns.Add("price2", GetType(Decimal))
        dt.Columns.Add("price3", GetType(Decimal))
        dt.Columns.Add("price4", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("qty1") = 0
            dr("qty2") = 0
            dr("qty3") = 0
            dr("qty4") = 0
            dr("price1") = "0.00"
            dr("price2") = "0.00"
            dr("price3") = "0.00"
            dr("price4") = "0.00"
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function createdatatable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("qty", GetType(Integer))
        dt.Columns.Add("price", GetType(Decimal))
        dt.Columns.Add("total", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Integer))
        dt.Columns.Add("ppmp_dtl_id", GetType(Integer))
        dt.Columns.Add("recall", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("id") = 0
            dr("Item_Desc") = ""
            dr("Description") = ""
            dr("qty") = 0
            dr("price") = "0.00"
            dr("total") = "0.00"
            dr("Item_ID") = 0
            dr("ppmp_dtl_id") = 0
            dr("recall") = 0
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function createPPA(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("GA_CODE2", GetType(Integer))
        dt.Columns.Add("GA_TITLE", GetType(String))
        dt.Columns.Add("PPA", GetType(Integer))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("BGA_ID", GetType(Decimal))
        dt.Columns.Add("Program_ID", GetType(Decimal))
        dt.Columns.Add("Project_ID", GetType(Decimal))
        dt.Columns.Add("Amount", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("GA_CODE2") = DBNull.Value
            dr("GA_TITLE") = DBNull.Value
            dr("PPA") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("BGA_ID") = DBNull.Value
            dr("Program_ID") = DBNull.Value
            dr("Project_ID") = DBNull.Value
            dr("Amount") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
            Dim role() As String = Roles.GetRolesForUser(usr.UserName)
            rolename = role(0)
            Session("RoleName") = rolename

            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            ddSuppBudget.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_APP_Supplemental] '" & Year(txtDate.Text) & "'", CommandType.Text)
            ddSuppBudget.DataTextField = ("AppropriationSource_Desc")
            ddSuppBudget.DataValueField = ("AppropriationSource_ID")
            ddSuppBudget.DataBind()
            ddSuppBudget.Items.Insert(0, "Select")

            ddDepartment.Items.Insert(0, "Select")
            ddFunction.Items.Insert(0, "Select")
            ddPPA.Items.Insert(0, "Select")
            ddAccounts.Items.Insert(0, "Select")
            ddPreparedBy.Items.Insert(0, "Select")
            ddModeProcurement.Items.Insert(0, "Select")

            pItems = Nothing
           
            LoadResetGrid()

            '====
            pCanEdit = True
            Session("Issubmited") = False
            saved = False

            SearchBut.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

        End If

    End Sub

    Protected Sub LoadResetGrid()
        gvbody.DataSource = createdatatable1(15)
        gvbody.DataBind()

        gvquarters.DataSource = pTempEmpAccount_tbl2
        gvquarters.DataBind()
    End Sub

    Protected Sub LoadResetPPPMP()
        gvPPA.DataSource = Nothing
        gvPPA.DataBind()

        gvppmp.DataSource = Nothing
        gvppmp.DataBind()
    End Sub


    Protected Sub ddSuppBudget_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddDepartment.DataSource = objDerived.GetDataTable("exec dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)
        ddDepartment.DataTextField = ("rc_name")
        ddDepartment.DataValueField = ("rc_id")
        ddDepartment.DataBind()
        ddDepartment.Items.Insert(0, "Select")

        ddDepartment.Enabled = True

        LoadResetGrid()
        LoadResetPPPMP()

    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("rc") = ddDepartment.SelectedItem.Value

        ddFunction.DataSource = objDerived.GetDataTable("EXEC [dbo].[sp_function_systemManager] '" & Session("RoleName") & "','" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")

        ddFunction.Enabled = True

        LoadResetGrid()
        LoadResetPPPMP()

    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Function_ID") = ddFunction.SelectedValue

        dtPPA = objDerived.GetDataTable("EXEC [AMS].[sp_PPA_Supplemental] '" & Year(txtDate.Text) & "','" & ddSuppBudget.SelectedItem.Value & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedValue & "'", CommandType.Text)
        ddPPA.DataSource = dtPPA
        ddPPA.DataTextField = ("Project_Name")
        ddPPA.DataValueField = ("Project_Name")
        ddPPA.DataBind()
        ddPPA.Items.Insert(0, "Select")

        ddPPA.Enabled = True


        gvPPA.DataSource = objDerived.GetRecords("EXEC [AMS].[sp_PPMPSupplemental_List] '" & Year(txtDate.Text) & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "',1,'" & ddSuppBudget.SelectedItem.Value & "'", CommandType.Text)
        gvPPA.DataBind()

        gvppmp.DataSource = objDerived.GetRecords("EXEC [AMS].[sp_PPMPSupplemental_List] '" & Year(txtDate.Text) & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "',0,'" & ddSuppBudget.SelectedItem.Value & "'", CommandType.Text)
        gvppmp.DataBind()

        LoadResetGrid()

    End Sub

    Protected Sub ddPPA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddAllotmentType.Enabled = True

        '==== SET VALUE
        Session("Project_ID") = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Project_ID")
        Session("Program_ID") = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Program_ID")

        LoadResetGrid()
    End Sub

    Protected Sub ddAllotmentType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddAllotmentType.SelectedItem.Value = 1 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select allotment type.")

            ddAccounts.Enabled = False

        Else
            dtAccounts = objDerived.GetDataTable("EXEC [AMS].[sp_Accounts_Supplemental] '" & Year(txtDate.Text) & "','" & ddSuppBudget.SelectedItem.Value & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & ddAllotmentType.SelectedItem.Value & "','" & dtPPA.Rows(ddPPA.SelectedIndex - 1)("Program_ID") & "','" & dtPPA.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & "'", CommandType.Text)
            ddAccounts.DataSource = dtAccounts
            ddAccounts.DataTextField = ("GA_Title2")
            ddAccounts.DataValueField = ("GA_ID")
            ddAccounts.DataBind()
            ddAccounts.Items.Insert(0, "Select")

            ddAccounts.Enabled = True
        End If

        LoadResetGrid()
    End Sub

    Protected Sub ddAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddAccounts.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select account title.")
            lnkListGoods.Enabled = False

        Else
            lnkListGoods.Enabled = True

            '==== GET APPROPRAITE SUPPLEMENTAL BUDGET FROM SELECTED ACCOUNT
            Dim ApprovedBudget As Decimal = dtAccounts.Rows(ddAccounts.SelectedIndex - 1)("ApprovedFinal")
            txtAppropraiteBudget.Text = FormatNumber(ApprovedBudget, 2)

            '==== LOAD LIST OF ITEMS FROM SELECTED ACCOUNTS
            Session("CYear") = "CY" & Year(txtDate.Text)

            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True

            dtItems = objDerived.GetDataTable("EXEC AMS.sp_goods_per_account_withPrice '" & ddAccounts.SelectedItem.Value & "','" & dtAccounts.Rows(ddAccounts.SelectedIndex - 1)("BGA_ID") & "','" & Session("CYear") & "'", CommandType.Text)
            gvitems.DataSource = dtItems
            gvitems.DataBind()

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False

            '==== CHECK IF ANY SAVED DATA
            pItems = objDerived.GetDataTable("EXEC [AMS].[sp_PPMPSaved_Supplemental] '" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & dtPPA.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & "','" & dtPPA.Rows(ddPPA.SelectedIndex - 1)("Program_ID") & "','" & ddAccounts.SelectedItem.Value & "','" & dtAccounts.Rows(ddAccounts.SelectedIndex - 1)("BGA_ID") & "','" & Year(txtDate.Text) & "', 0, 1", CommandType.Text)
            If pItems.Rows.Count = 0 Then
                gvbody.DataSource = createdatatable1(15)
                gvbody.DataBind()
                Session("LoadPrevPPMP") = False
                Session("withSaveData") = False

            Else
                gvbody.DataSource = pItems
                gvbody.DataBind()

                CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(Total)", ""), 2)
                txtAvailableBudget.Text = FormatNumber(CType(txtAppropraiteBudget.Text, Decimal) - CType(pItems.Compute("sum(Total)", ""), Decimal), 2)

                Session("PrevRow") = pItems.Rows.Count
                Session("LoadPrevPPMP") = True
                Session("withSaveData") = True


                '=== QUARTERS
                For i As Integer = 0 To gvbody.Rows.Count - 1
                    Dim id As String = pItems.Rows(i)("Item_ID")
                    Me.Session(id) = objDerived.GetDataTable("exec AMS.loadppmpitemdetail " & pItems.Rows(i)("ppmp_dtl_id") & "", CommandType.Text)
                Next

                btnPreview.Enabled = True
            End If

            '==== SET VALUE
            Session("GA_ID") = ddAccounts.SelectedItem.Value
            Session("BGA_ID") = dtAccounts.Rows(ddAccounts.SelectedIndex - 1)("BGA_ID")

            '=== LOAD PREPARED BY AND MODE OF PROCUREMENT
            ddPreparedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
            ddPreparedBy.DataTextField = ("full_name")
            ddPreparedBy.DataValueField = ("empid")
            ddPreparedBy.DataBind()
            ddPreparedBy.Items.Insert(0, "Select")

            ddModeProcurement.DataSource = objDerived.GetDataTable("Select * from ams.mode_of_procurement", CommandType.Text)
            ddModeProcurement.DataTextField = ("mode_description")
            ddModeProcurement.DataValueField = ("mode_of_procurement_id")
            ddModeProcurement.DataBind()
            ddModeProcurement.Items.Insert(0, "Select")

            ddPreparedBy.Enabled = True
            ddModeProcurement.Enabled = True
        End If

    End Sub

    Protected Sub lnkListGoods_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True

        dtItems = objDerived.GetDataTable("EXEC AMS.sp_goods_per_account_withPrice '" & ddAccounts.SelectedItem.Value & "','" & dtAccounts.Rows(ddAccounts.SelectedIndex - 1)("BGA_ID") & "','" & Session("CYear") & "'", CommandType.Text)
        gvitems.PageIndex = e.NewPageIndex
        gvitems.DataSource = dtItems
        gvitems.DataBind()

        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False

        ModalPopupExtender1.Show()
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True

            Dim cb As CheckBox = TryCast(sender, CheckBox)
            Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)

            If cb.Checked = True Then
                dtItems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text)("isChecked") = True
            Else
                dtItems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text)("isChecked") = False
            End If

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False

            ModalPopupExtender1.Show()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String

        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True

        If CType(sender, CheckBox).Checked = True Then

            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)

                If s.Enabled = True Then
                    s.Checked = True
                    dtItems.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isChecked") = True
                End If

            Next
        Else
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
                dtItems.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isChecked") = False
            Next
        End If

        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False

        ModalPopupExtender1.Show()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True

            If SearchBut.Text = "" Then
                SearchBut.Text = ""
            End If

            Dim myview As DataView
            myview = dtItems.DefaultView
            myview.RowFilter = "Item_desc like '%" & replaceapostrophe(SearchBut.Text.ToString) & "%' and isUsed = false"
            gvitems.DataSource = myview
            gvitems.DataBind()
            gvitems.SelectedIndex = -1
            gvitems.PageIndex = 0

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False

            ModalPopupExtender1.Show()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, " ")
        End Try
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim pItems1 As New DataTable

        Try
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True

            Dim dt As New DataTable
            Dim sumObject As Integer
            Dim dr As DataRow
            Dim cb As Boolean
            Dim drQ As DataRow
            Dim dtQ As New DataTable

            dtQ.Columns.Add("qty1")
            dtQ.Columns.Add("price1")
            dtQ.Columns.Add("qty2")
            dtQ.Columns.Add("price2")
            dtQ.Columns.Add("qty3")
            dtQ.Columns.Add("price3")
            dtQ.Columns.Add("qty4")
            dtQ.Columns.Add("price4")
            drQ = dtQ.NewRow
            drQ.Item(0) = "0"
            drQ.Item(1) = "0.00"
            drQ.Item(2) = "0"
            drQ.Item(3) = "0.00"
            drQ.Item(4) = "0"
            drQ.Item(5) = "0.00"
            drQ.Item(6) = "0"
            drQ.Item(7) = "0.00"
            dtQ.Rows.Add(drQ)

            Dim cyear As String = Session("CYear")

            If pItems.Rows.Count <= 0 Then
                dt.Columns.Add("id", GetType(Integer))
                dt.Columns.Add("Item_Desc", GetType(String))
                dt.Columns.Add("Description", GetType(String))
                dt.Columns.Add("qty", GetType(Integer))
                dt.Columns.Add("price", GetType(Decimal))
                dt.Columns.Add("total", GetType(Decimal))
                dt.Columns.Add("Item_ID", GetType(Long))
                dt.Columns.Add("ppmp_dtl_id", GetType(Long))
                Session("LoadPrevPPMP") = False

                For i As Integer = 0 To Me.dtItems.Rows.Count - 1
                    Dim pListitem2 As New DataTable
                    pListitem2 = dtItems

                    If dtItems.Rows(i)("isChecked") = True Then
                        dr = dt.NewRow
                        dr("id") = 1
                        dr("Item_Desc") = dtItems.Rows(i)("Item_Desc")
                        dr("Description") = dtItems.Rows(i)("Description")
                        dr("qty") = 0
                        dr("price") = FormatNumber(objDerived.GetValue("exec AMS.itemprice_withprice '" & dtItems.Rows(i)("Item_ID") & "','" & cyear & "'", CommandType.Text), 2)
                        dr("total") = "0.00"
                        dr("Item_ID") = dtItems.Rows(i)("Item_ID")
                        dr("ppmp_dtl_id") = 0
                        dt.Rows.Add(dr)
                        dtItems.Rows(i)("isUsed") = True
                        dtItems.Rows(i)("isChecked") = False
                        Session(CType(dtItems.Rows(i)("Item_ID"), String)) = dtQ
                    End If
                Next

                pItems = dt

                'sumObject = pItems.Compute("count(id)", "id=1")
                'If sumObject <= 15 Then
                '    pItems.Merge(createdatatable1(15 - sumObject))
                'End If

            Else
                sumObject = pItems.Compute("count(id)", "id=1")
                If Session("LoadPrevPPMP") = False Then
                    For i As Integer = 0 To dtItems.Rows.Count - 1
                        If dtItems.Rows(i)("isChecked") = True Then
                            dt = pItems
                            dr = dt.NewRow
                            dr("id") = 1
                            dr("Item_Desc") = dtItems.Rows(i)("Item_Desc")
                            dr("Description") = dtItems.Rows(i)("Description")
                            dr("qty") = 0
                            dr("price") = FormatNumber(objDerived.GetValue("exec AMS.itemprice_withprice '" & dtItems.Rows(i)("Item_ID") & "','" & cyear & "'", CommandType.Text), 2)
                            dr("total") = "0.00"
                            dr("Item_ID") = dtItems.Rows(i)("Item_ID")
                            dr("ppmp_dtl_id") = 0
                            dt.Rows.Add(dr)
                            pItems = dt
                            dtItems.Rows(i)("isUsed") = True
                            dtItems.Rows(i)("isChecked") = False
                            Me.Session(CType(dtItems.Rows(i)("Item_ID"), String)) = dtQ
                        End If
                    Next

                    'If sumObject <= 15 Then
                    '    For i As Integer = 0 To 16
                    '        If sumObject + i < 16 Then
                    '            pItems.Rows(15 - i).Delete()
                    '        Else
                    '            Exit For
                    '        End If
                    '    Next
                    '    sumObject = pItems.Compute("count(id)", "id=1")
                    '    Me.Session("CurrentRowCount") = sumObject
                    '    pItems.Merge(createdatatable1(15 - sumObject))
                    'End If


                Else
                    Dim dt2 As New DataTable
                    Dim dr2 As DataRow
                    dt2.Columns.Add("id", GetType(Integer))
                    dt2.Columns.Add("Item_Desc", GetType(String))
                    dt2.Columns.Add("Description", GetType(String))
                    dt2.Columns.Add("qty", GetType(Integer))
                    dt2.Columns.Add("price", GetType(Decimal))
                    dt2.Columns.Add("total", GetType(Decimal))
                    dt2.Columns.Add("Item_ID", GetType(Integer))
                    dt2.Columns.Add("ppmp_dtl_id", GetType(Integer))
                    For i As Integer = 0 To Me.dtItems.Rows.Count - 1
                        If dtItems.Rows(i)("isChecked") = True Then

                            dt2 = pItems
                            dr2 = dt2.NewRow
                            dr2("id") = 1
                            dr2("Item_Desc") = dtItems.Rows(i)("Item_Desc")
                            dr2("Description") = dtItems.Rows(i)("Description")
                            dr2("qty") = 0
                            dr2("price") = FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & dtItems.Rows(i)("Item_ID") & "','" & cyear & "'", CommandType.Text), 2)
                            dr2("total") = "0.00"
                            dr2("Item_ID") = dtItems.Rows(i)("Item_ID")
                            dr2("ppmp_dtl_id") = 0
                            dt2.Rows.Add(dr2)
                            pItems = dt2
                            dtItems.Rows(i)("isUsed") = True
                            dtItems.Rows(i)("isChecked") = False
                            Me.Session(CType(dtItems.Rows(i)("Item_ID"), String)) = dtQ
                        End If
                    Next

                    'If sumObject <= 15 Then
                    '    For i As Integer = 0 To 16
                    '        If sumObject + i < 16 Then
                    '            pItems.Rows(15 - i).Delete()
                    '        Else
                    '            Exit For
                    '        End If
                    '    Next
                    '    sumObject = pItems.Compute("count(id)", "id=1")
                    '    Me.Session("CurrentRowCount") = sumObject
                    '    pItems.Merge(createdatatable3(15 - sumObject))
                    'End If

                End If

            End If

            gvbody.DataSource = pItems
            gvbody.DataBind()
            Dim data As DataTable
            data = dtItems


            Dim myview As DataView
            myview = dtItems.DefaultView
            myview.RowFilter = "isUsed = false"
            gvitems.DataSource = myview
            gvitems.DataBind()

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False

            If pItems.Compute("sum(total)", "") = "0.00" Then
                CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = "0.00"
            Else
                CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            End If


            ModalPopupExtender1.Show()
        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub

    Protected Sub gvbody_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If pLbtn = "Recall" Then
            Dim RecallPrice As Decimal
            RecallPrice = objDerived.GetValue("select price from dbo.m_item_detail where Item_ID=" & pItems.Rows(Me.gvbody.SelectedIndex)("Item_ID") & " ", CommandType.Text)
            Dim index As Integer
            Dim dt2 As New DataTable
            dt2.Columns.Add("price", GetType(Decimal))
            dt2.Columns.Add("recall", GetType(Boolean))
            For i As Integer = index To index + 1
                index = Me.gvbody.SelectedIndex.ToString
                dt2 = pItems
                pItems.Rows(index).Item("price") = RecallPrice
                pItems.Rows(index).Item("recall") = False
                pItems = dt2
                Session("dt2") = dt2
            Next
            Me.gvbody.DataSource = pItems
            Me.gvbody.DataBind()
        End If

        Session("1") = gvbody.SelectedDataKey(0)
        Session("0") = gvbody.SelectedDataKey(1)


        If Session("0") <> 0 Then '=== WITH PPMP
            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("EXEC [AMS].[sp_PPMPSupplemental_ItemDetails] '" & Session("0") & "'", CommandType.Text)
            gvquarters.DataSource = dt1
            gvquarters.DataBind()

            '=== CHECK IF IT HAS ALREADY PURCHASE REQUEST
            Dim Month As Integer = objDerived.GetValue("SELECT DATEPART(m, getdate())", CommandType.Text)
            Dim x1 As Integer
            Dim x2 As Integer

            If Month = 1 Or Month = 2 Or Month = 3 Then '=== 1ST QUARTER
                Session("Quarter") = 1
                CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox).ReadOnly = False
                CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox).ReadOnly = False
                CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox).ReadOnly = False

                x1 = objDerived.GetValue("SELECT firstqty FROM AMS.ppmp_dtl WHERE ppmp_dtl_id = '" & gvbody.SelectedDataKey(1) & "'", CommandType.Text)
                x2 = objDerived.GetValue("SELECT firstqtybal FROM AMS.ppmp_dtl WHERE ppmp_dtl_id = '" & gvbody.SelectedDataKey(1) & "'", CommandType.Text)

                If x1 <> x2 Then
                    pCanEdit = False
                    CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox).ReadOnly = True
                Else
                    pCanEdit = True
                    CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox).ReadOnly = False
                End If

            ElseIf Month = 4 Or Month = 5 Or Month = 6 Then '=== 2ND QUARTER
                Session("Quarter") = 2
                CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox).ReadOnly = True
                CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox).ReadOnly = False
                CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox).ReadOnly = False


                x1 = objDerived.GetValue("SELECT secondqty FROM AMS.ppmp_dtl WHERE ppmp_dtl_id = '" & gvbody.SelectedDataKey(1) & "'", CommandType.Text)
                x2 = objDerived.GetValue("SELECT secondqtybal FROM AMS.ppmp_dtl WHERE ppmp_dtl_id = '" & gvbody.SelectedDataKey(1) & "'", CommandType.Text)

                If x1 <> x2 Then
                    pCanEdit = False
                    CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox).ReadOnly = True
                Else
                    pCanEdit = True
                    CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox).ReadOnly = False
                End If

            ElseIf Month = 7 Or Month = 8 Or Month = 9 Then '=== 3RD QUARTER
                Session("Quarter") = 3
                CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox).ReadOnly = True
                CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox).ReadOnly = True
                CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox).ReadOnly = False

                x1 = objDerived.GetValue("SELECT thirdqty FROM AMS.ppmp_dtl WHERE ppmp_dtl_id = '" & gvbody.SelectedDataKey(1) & "'", CommandType.Text)
                x2 = objDerived.GetValue("SELECT thirdqtybal FROM AMS.ppmp_dtl WHERE ppmp_dtl_id = '" & gvbody.SelectedDataKey(1) & "'", CommandType.Text)

                If x1 <> x2 Then
                    pCanEdit = False
                    CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox).ReadOnly = True
                Else
                    pCanEdit = True
                    CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox).ReadOnly = False
                End If

            ElseIf Month = 10 Or Month = 11 Or Month = 12 Then '=== 4TH QUARTER
                Session("Quarter") = 4
                CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox).ReadOnly = True
                CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox).ReadOnly = True
                CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox).ReadOnly = True

                x1 = objDerived.GetValue("SELECT fourthqty FROM AMS.ppmp_dtl WHERE ppmp_dtl_id = '" & gvbody.SelectedDataKey(1) & "'", CommandType.Text)
                x2 = objDerived.GetValue("SELECT fourthqtybal FROM AMS.ppmp_dtl WHERE ppmp_dtl_id = '" & gvbody.SelectedDataKey(1) & "'", CommandType.Text)

                If x1 <> x2 Then
                    pCanEdit = False
                    CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox).ReadOnly = True
                Else
                    pCanEdit = True
                    CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox).ReadOnly = False
                End If

            End If


        Else '=== NEW PPMP
            gvquarters.DataSource = createdatatable2(0)
            gvquarters.DataBind()

            CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox).ReadOnly = False
            CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox).ReadOnly = False
            CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox).ReadOnly = False
            CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox).ReadOnly = False
        End If

        'Dim qty As TextBox = CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox)
        'Dim quarter1 As TextBox = CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox)
        'Dim quarter2 As TextBox = CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox)
        'Dim quarter3 As TextBox = CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox)
        'Dim quarter4 As TextBox = CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox)
        'quarter1.Attributes.Add("onFocus", "this.select()")
        'quarter1.Attributes.Add("onClick", "this.select()")


    End Sub

    Protected Sub txtqty1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            savestatus = False

            Dim id As String = gvbody.SelectedDataKey(0)
            Dim txtqty As TextBox = TryCast(sender, TextBox)

            Dim verify As Boolean
            If txtqty.Text = "" Then
                txtqty.Text = "0"
            End If
            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            Dim qty2 As TextBox = CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox)

            If Me.Session("Edit") = True Then
                Try
                    verify = CType(objDerived.GetValue("SELECT TOP (1) firstqtr as firstqtr FROM AMS.ppmp_hdr WHERE Cyear ='" & Year(txtDate.Text) & "' ", CommandType.Text), Boolean)
                Catch ex As Exception
                    verify = False
                End Try

                If verify = True Then
                    msg.UserMsgBox("Editing data for first qurater is not allowed.", Me, False)
                    Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                    Me.gvquarters.DataBind()
                    Exit Sub

                Else

                    pInputQuantity = True

                    Dim balancetotal As DataTable
                    balancetotal = objDerived.GetDataTable("exec ams.PPMPcheckBalance " & gvbody.SelectedDataKey(1) & "", CommandType.Text)
                    If balancetotal.Rows.Count >= 1 Then
                        If CType(txtqty.Text, Integer) < (CType(balancetotal.Rows(0)("firstqty"), Integer) - CType(balancetotal.Rows(0)("firstqtybal"), Integer)) Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must not lower than '" & CType(balancetotal.Rows(0)("firstqty"), Integer) - CType(balancetotal.Rows(0)("firstqtybal"), Integer) & "'. The said quantity has already been purchased!.")
                            Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                            Me.gvquarters.DataBind()
                            Exit Sub
                        End If
                    End If
                End If
            End If

            Dim price As Decimal = CType(gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(Me.gvquarters.Rows(gvr.RowIndex).Cells(0).FindControl("lblprice1"), Label).Text = FormatNumber(price * CType(txtqty.Text, Integer), 2)

            qty2.Attributes.Add("onFocus", "this.select()")
            qty2.Attributes.Add("onClick", "this.select()")
            qty2.Focus()
            Dim qty3 As TextBox = CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox)
            Dim qty4 As TextBox = CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox)
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("qty1")
            dt.Columns.Add("price1")
            dt.Columns.Add("qty2")
            dt.Columns.Add("price2")
            dt.Columns.Add("qty3")
            dt.Columns.Add("price3")
            dt.Columns.Add("qty4")
            dt.Columns.Add("price4")
            dr = dt.NewRow

            dr.Item(0) = CType(CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox).Text, Integer)
            dr.Item(1) = CType(gvquarters.Rows(0).Cells(0).FindControl("lblprice1"), Label).Text
            dr.Item(2) = CType(qty2.Text, Integer)
            dr.Item(3) = CType(gvquarters.Rows(0).Cells(1).FindControl("lblprice2"), Label).Text
            dr.Item(4) = CType(qty3.Text, Integer)
            dr.Item(5) = CType(gvquarters.Rows(0).Cells(2).FindControl("lblprice3"), Label).Text
            dr.Item(6) = CType(qty4.Text, Integer)
            dr.Item(7) = CType(gvquarters.Rows(0).Cells(3).FindControl("lblprice4"), Label).Text
            dt.Rows.Add(dr)

            Me.Session(id) = dt
            pItems.Rows(gvbody.SelectedIndex)("qty") = CType(Val(txtqty.Text) + Val(qty2.Text) + Val(qty3.Text) + Val(qty4.Text), Integer)

            pItems.Rows(gvbody.SelectedIndex)("total") = CType(pItems.Rows(gvbody.SelectedIndex)("qty") * price, Decimal)
            gvbody.DataSource = pItems
            gvbody.DataBind()

            CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            'RemainingBalance()

            LoadEnableSaving()
            LoadAvailableBudget()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select a supply first.")
        End Try
    End Sub

    Protected Sub txtqty2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        savestatus = False
        Try
            Dim txtqty As TextBox = TryCast(sender, TextBox)

            If txtqty.Text = "" Then
                txtqty.Text = "0"
            End If
            Dim verify As Boolean
            If Me.Session("Edit") = True Then
                Try
                    verify = CType(objDerived.GetValue("SELECT TOP (1) secondqrt FROM AMS.ppmp_hdr WHERE Cyear ='" & Year(txtDate.Text) & "' ", CommandType.Text), Boolean)
                Catch ex As Exception
                    verify = False
                End Try

                If verify = True Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Editing data for second qurater is not allowed.")
                    Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                    Me.gvquarters.DataBind()
                    Exit Sub

                Else

                    pInputQuantity = True
                    Dim balancetotal As DataTable
                    balancetotal = objDerived.GetDataTable("exec ams.PPMPcheckBalance " & gvbody.SelectedDataKey(1) & "", CommandType.Text)

                    If balancetotal.Rows.Count >= 1 Then
                        If CType(txtqty.Text, Integer) < (CType(balancetotal.Rows(0)("secondqty"), Integer) - CType(balancetotal.Rows(0)("secondqtybal"), Integer)) Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must not lower than '" & CType(balancetotal.Rows(0)("secondqty"), Integer) - CType(balancetotal.Rows(0)("secondqtybal"), Integer) & "'. The said quantity has already been purchased!.")
                            Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                            Me.gvquarters.DataBind()
                            Exit Sub
                        End If
                    End If
                End If
            End If

            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            Dim price As Decimal = CType(gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(Me.gvquarters.Rows(gvr.RowIndex).Cells(1).FindControl("lblprice2"), Label).Text = FormatNumber(price * CType(txtqty.Text, Integer), 2)

            Dim qty1 As TextBox = CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox)
            Dim qty3 As TextBox = CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox)
            qty3.Attributes.Add("onFocus", "this.select()")
            qty3.Attributes.Add("onClick", "this.select()")
            qty3.Focus()

            Dim qty4 As TextBox = CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox)
            Dim dr As DataRow
            Dim dt As New DataTable
            objDerived.conStr = objDerived.DbaseConnect()

            dt.Columns.Add("qty1")
            dt.Columns.Add("price1")
            dt.Columns.Add("qty2")
            dt.Columns.Add("price2")
            dt.Columns.Add("qty3")
            dt.Columns.Add("price3")
            dt.Columns.Add("qty4")
            dt.Columns.Add("price4")
            dr = dt.NewRow
            dr.Item(0) = CType(qty1.Text, Integer)
            dr.Item(1) = CType(gvquarters.Rows(0).Cells(0).FindControl("lblprice1"), Label).Text
            dr.Item(2) = CType(CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox).Text, Integer)
            dr.Item(3) = CType(gvquarters.Rows(0).Cells(1).FindControl("lblprice2"), Label).Text
            dr.Item(4) = CType(qty3.Text, Integer)
            dr.Item(5) = CType(gvquarters.Rows(0).Cells(2).FindControl("lblprice3"), Label).Text
            dr.Item(6) = CType(qty4.Text, Integer)
            dr.Item(7) = CType(gvquarters.Rows(0).Cells(3).FindControl("lblprice4"), Label).Text
            dt.Rows.Add(dr)

            Dim id As String = gvbody.SelectedDataKey(0)
            Me.Session(id) = dt

            pItems.Rows(gvbody.SelectedIndex)("qty") = CType(Val(txtqty.Text) + Val(qty1.Text) + Val(qty3.Text) + Val(qty4.Text), Integer)
            pItems.Rows(gvbody.SelectedIndex)("total") = CType(pItems.Rows(gvbody.SelectedIndex)("qty") * price, Decimal)
            gvbody.DataSource = pItems
            gvbody.DataBind()


            CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            'RemainingBalance()

            LoadEnableSaving()
            LoadAvailableBudget()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select a supply first.")
        End Try
    End Sub

    Protected Sub txtqty3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        savestatus = False
        Try
            Dim txtqty As TextBox = TryCast(sender, TextBox)
            If txtqty.Text = "" Then
                txtqty.Text = "0"
            End If
            Dim verify As Boolean
            If Me.Session("Edit") = True Then
                Try
                    verify = CType(objDerived.GetValue("SELECT     TOP (1) thirdqtr FROM AMS.ppmp_hdr WHERE Cyear ='" & Year(txtDate.Text) & "' ", CommandType.Text), Boolean)
                Catch ex As Exception
                    verify = False
                End Try

                If verify = True Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Editing data for third qurater is not allowed.")
                    Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                    Me.gvquarters.DataBind()
                    Exit Sub

                Else

                    pInputQuantity = True
                    Dim balancetotal As DataTable
                    balancetotal = objDerived.GetDataTable("exec ams.PPMPcheckBalance " & gvbody.SelectedDataKey(1) & "", CommandType.Text)
                    If balancetotal.Rows.Count >= 1 Then
                        If CType(txtqty.Text, Integer) < (CType(balancetotal.Rows(0)("thirdqty"), Integer) - CType(balancetotal.Rows(0)("thirdqtybal"), Integer)) Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must not lower than '" & CType(balancetotal.Rows(0)("thirdqty"), Integer) - CType(balancetotal.Rows(0)("thirdqtybal"), Integer) & "'. The said quantity has already been purchased!.")
                            Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                            Me.gvquarters.DataBind()
                            Exit Sub
                        End If
                    End If
                End If
            End If

            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            Dim price As Decimal = CType(gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(Me.gvquarters.Rows(gvr.RowIndex).Cells(2).FindControl("lblprice3"), Label).Text = FormatNumber(price * CType(txtqty.Text, Integer), 2)
            Dim qty2 As TextBox = CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox)
            Dim qty1 As TextBox = CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox)
            Dim qty4 As TextBox = CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox)
            qty4.Attributes.Add("onFocus", "this.select()")
            qty4.Attributes.Add("onClick", "this.select()")
            qty4.Focus()

            Dim dr As DataRow
            Dim dt As New DataTable
            objDerived.conStr = objDerived.DbaseConnect()
            dt.Columns.Add("qty1")
            dt.Columns.Add("price1")
            dt.Columns.Add("qty2")
            dt.Columns.Add("price2")
            dt.Columns.Add("qty3")
            dt.Columns.Add("price3")
            dt.Columns.Add("qty4")
            dt.Columns.Add("price4")
            dr = dt.NewRow
            dr.Item(0) = CType(qty1.Text, Integer)
            dr.Item(1) = CType(gvquarters.Rows(0).Cells(0).FindControl("lblprice1"), Label).Text
            dr.Item(2) = CType(qty2.Text, Integer)
            dr.Item(3) = CType(gvquarters.Rows(0).Cells(1).FindControl("lblprice2"), Label).Text
            dr.Item(4) = CType(CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox).Text, Integer)
            dr.Item(5) = CType(gvquarters.Rows(0).Cells(2).FindControl("lblprice3"), Label).Text
            dr.Item(6) = CType(qty4.Text, Integer)
            dr.Item(7) = CType(gvquarters.Rows(0).Cells(3).FindControl("lblprice4"), Label).Text
            dt.Rows.Add(dr)

            Dim id As String = gvbody.SelectedDataKey(0)
            Me.Session(id) = dt

            pItems.Rows(gvbody.SelectedIndex)("qty") = CType(Val(txtqty.Text) + Val(qty2.Text) + Val(qty1.Text) + Val(qty4.Text), Integer)
            pItems.Rows(gvbody.SelectedIndex)("total") = CType(pItems.Rows(gvbody.SelectedIndex)("qty") * price, Decimal)
            gvbody.DataSource = pItems
            gvbody.DataBind()

            CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            'RemainingBalance()

            LoadEnableSaving()
            LoadAvailableBudget()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select a supply first.")
        End Try
    End Sub

    Protected Sub txtqty4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        savestatus = False

        Try
            Dim txtqty As TextBox = TryCast(sender, TextBox)
            If txtqty.Text = "" Then
                txtqty.Text = "0"
            End If
            Dim verify As Boolean
            If Me.Session("Edit") = True Then
                Try
                    verify = CType(objDerived.GetValue("SELECT TOP (1) fourthqrt FROM AMS.ppmp_hdr WHERE Cyear = '" & Year(txtDate.Text) & "' ", CommandType.Text), Boolean)
                Catch ex As Exception
                    verify = False
                End Try

                If verify = True Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Editing data for fourth qurater is not allowed.")
                    Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                    Me.gvquarters.DataBind()
                    Exit Sub

                Else

                    pInputQuantity = True
                    Dim balancetotal As DataTable
                    balancetotal = objDerived.GetDataTable("exec ams.PPMPcheckBalance " & gvbody.SelectedDataKey(1) & "", CommandType.Text)
                    If balancetotal.Rows.Count >= 1 Then
                        If CType(txtqty.Text, Integer) < (CType(balancetotal.Rows(0)("fourthqty"), Integer) - CType(balancetotal.Rows(0)("fourthqtybal"), Integer)) Then
                            msg.UserMsgBox("Quantity must not lower than '" & CType(balancetotal.Rows(0)("fourthqty"), Integer) - CType(balancetotal.Rows(0)("fourthqtybal"), Integer) & "'. The said quantity has already been purchased!.", Me, False)
                            Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                            Me.gvquarters.DataBind()
                            Exit Sub
                        End If
                    End If
                End If
            End If
            txtqty.Focus()

            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            Dim price As Decimal = CType(gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(Me.gvquarters.Rows(gvr.RowIndex).Cells(3).FindControl("lblprice4"), Label).Text = FormatNumber(price * CType(txtqty.Text, Integer), 2)

            Dim qty2 As TextBox = CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox)
            Dim qty3 As TextBox = CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox)
            Dim qty1 As TextBox = CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox)
            Dim dr As DataRow
            Dim dt As New DataTable
            objDerived.conStr = objDerived.DbaseConnect()
            dt.Columns.Add("qty1")
            dt.Columns.Add("price1")
            dt.Columns.Add("qty2")
            dt.Columns.Add("price2")
            dt.Columns.Add("qty3")
            dt.Columns.Add("price3")
            dt.Columns.Add("qty4")
            dt.Columns.Add("price4")
            dr = dt.NewRow
            dr.Item(0) = CType(qty1.Text, Integer)
            dr.Item(1) = CType(gvquarters.Rows(0).Cells(0).FindControl("lblprice1"), Label).Text
            dr.Item(2) = CType(qty2.Text, Integer)
            dr.Item(3) = CType(gvquarters.Rows(0).Cells(1).FindControl("lblprice2"), Label).Text
            dr.Item(4) = CType(qty3.Text, Integer)
            dr.Item(5) = CType(gvquarters.Rows(0).Cells(2).FindControl("lblprice3"), Label).Text
            dr.Item(6) = CType(CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox).Text, Integer)
            dr.Item(7) = CType(gvquarters.Rows(0).Cells(3).FindControl("lblprice4"), Label).Text
            dt.Rows.Add(dr)
            Dim id As String = gvbody.SelectedDataKey(0)
            Me.Session(id) = dt
            pItems.Rows(gvbody.SelectedIndex)("qty") = CType(Val(txtqty.Text) + Val(qty2.Text) + Val(qty3.Text) + Val(qty1.Text), Integer)
            pItems.Rows(gvbody.SelectedIndex)("total") = CType(pItems.Rows(gvbody.SelectedIndex)("qty") * price, Decimal)

            gvbody.DataSource = pItems
            gvbody.DataBind()

            CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            'RemainingBalance()
            If pItems.Rows(gvbody.SelectedIndex + 1)("id") = 1 Then
                addQTY()
            End If

            LoadEnableSaving()
            LoadAvailableBudget()

        Catch ex As Exception
        End Try
    End Sub

    Public Sub addQTY()
        gvbody.SelectedIndex = gvbody.SelectedIndex + 1

        Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
        Me.gvquarters.DataBind()


        If pCanEdit = True And saved = False Then
            CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox).ReadOnly = False
            CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox).ReadOnly = False
            CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox).ReadOnly = False
            CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox).ReadOnly = False


            Dim qty As TextBox = CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox)
            Dim quarter1 As TextBox = CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox)
            Dim quarter2 As TextBox = CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox)
            Dim quarter3 As TextBox = CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox)
            Dim quarter4 As TextBox = CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox)
            quarter1.Attributes.Add("onFocus", "this.select()")
            quarter1.Attributes.Add("onClick", "this.select()")
            qty.Focus()

        Else
            CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox).ReadOnly = True
            CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox).ReadOnly = True
            CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox).ReadOnly = True
            CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox).ReadOnly = True
        End If
    End Sub

    Protected Sub ddPreparedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadEnableSaving()
    End Sub

    Protected Sub ddModeProcurement_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadEnableSaving()
    End Sub

    Protected Sub LoadEnableSaving()
        If ddPreparedBy.SelectedItem.Text <> "Select" And ddModeProcurement.SelectedItem.Text <> "Select" And CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text <> 0 Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If
    End Sub

    Protected Sub LoadAvailableBudget()
        Dim BudgetUsed As Decimal
        Dim ApprovedBudget As Decimal
        Dim AvailableBudget As Decimal

        ApprovedBudget = txtAppropraiteBudget.Text
        BudgetUsed = (CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text)

        AvailableBudget = ApprovedBudget - BudgetUsed

        txtAvailableBudget.Text = FormatNumber(AvailableBudget, 2)


        If CType(txtAvailableBudget.Text, Decimal) < 0 Then
            lblNoti.Visible = True
        Else
            lblNoti.Visible = False
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(txtAvailableBudget.Text, Decimal) < 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Exceed from the approved budget.")
            Exit Sub

        ElseIf ddSuppBudget.SelectedItem.Text = "Select" Or ddDepartment.SelectedItem.Text = "Select" Or ddFunction.SelectedItem.Text = "Select" Or ddPPA.SelectedItem.Text = "Select" Or ddAllotmentType.SelectedItem.Text = "Select" Or ddAccounts.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Complete the dropdown selection.")
            Exit Sub
        End If

        Session("rc") = ddDepartment.SelectedItem.Value
        Session("year") = Year(txtDate.Text)

        If Session("withSaveData") = False Then
            With hdr
                .CYear = Year(txtDate.Text)
                .pDate = txtDate.Text
                .PreparedBy = ddPreparedBy.SelectedItem.Value
                .ReviewedBy = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND (isDeptHead = 'Yes')", CommandType.Text) 'Department Head's EmpID
                .ApprovedBy = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE (deptid = 1) AND (division_key = 86) AND (isDeptHead = 'Yes')", CommandType.Text) 'Mayor's EmpID
                .RecommendedBy = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE (deptid = 7) AND (division_key = 86) AND (isDeptHead = 'Yes')", CommandType.Text) 'GSO's EmpID
                .RC_ID = ddDepartment.SelectedItem.Value
                .Function_ID = ddFunction.SelectedItem.Value
                .GA_ID = Session("GA_ID")
                .BGA_ID = Session("BGA_ID")
                .Project_ID = Session("Project_ID")
                .Program_id = Session("Program_ID")
                .firstqtr = False
                .secondqrt = False
                .thirdqtr = False
                .fourthqrt = False
                .isfinal = False
                .isContinuing = False
                .isSupplemental = True
                .mode_of_procurement = ddModeProcurement.SelectedItem.Value
                .app_id = ddSuppBudget.SelectedItem.Value
                .isforRevision = False
                .Userid = Me.Session("@UserName").ToString
            End With

            Dim hdrid As Long = hdr.save
            Me.Session("hdrid") = hdrid

            For i As Integer = 0 To gvbody.Rows.Count - 1
                If pItems.Rows(i)("Item_ID") <> 0 Then
                    Dim gv As New GridView
                    Dim b As Integer = pItems.Rows(i)("Item_ID")
                    gv.DataSource = CType(Me.Session(pItems.Rows(i)("Item_ID").ToString), DataTable)
                    gv.DataBind()

                    dtl.ppmp_hdr_id = hdrid
                    dtl.Item_ID = pItems.Rows(i)("Item_ID")
                    dtl.Cost = pItems.Rows(i)("Price")
                    dtl.firstqty = gv.Rows(0).Cells(0).Text
                    dtl.secondqty = gv.Rows(0).Cells(2).Text
                    dtl.thirdqty = gv.Rows(0).Cells(4).Text
                    dtl.fourthqty = gv.Rows(0).Cells(6).Text
                    dtl.firstqtybal = gv.Rows(0).Cells(0).Text
                    dtl.secondqtybal = gv.Rows(0).Cells(2).Text
                    dtl.thirdqtybal = gv.Rows(0).Cells(4).Text
                    dtl.fourthqtybal = gv.Rows(0).Cells(6).Text
                    dtl.Userid = Me.Session("@UserName").ToString
                    dtl.save()
                End If
            Next

        ElseIf Session("withSaveData") = True Then
            'pItemsDetails = objDerived.GetDataTable("SELECt firstqty, secondqty, thirdqty, fourthqty,Cost ,Item_ID FROM [AMS].[Load_preV] where rc_id= " & Me.ddRC.SelectedItem.Value & " and CYear='" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "' and Function_ID=" & ddFunction.SelectedItem.Value & "and GA_ID=" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & " and BGA_ID=" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & " and Project_ID=" & hdfppaprojId.Value & "and Program_id=" & hdfppaprogId.Value & " and isContinuing='" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "'", CommandType.Text)
            Session("hdrid") = objDerived.GetValue("SELECT ppmp_hdr_id from AMS.ppmp_hdr WHERE rc_id = " & ddDepartment.SelectedItem.Value & " AND CYear = '" & Year(txtDate.Text) & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "' AND Project_ID = '" & Session("Project_ID") & "' and Program_id = '" & Session("Program_ID") & "' AND isContinuing = 0 AND isSupplemental = 1", CommandType.Text)

            Dim hdrid As Long = CType(Me.Session("hdrid"), Long)
            For i As Integer = 0 To CType(Session("PrevRow"), Integer) - 1

                Dim dataquarter As New DataTable
                Dim id As String = pItems.Rows(i)("Item_ID")
                dataquarter = CType(Me.Session(id), DataTable)

                Dim balancetotal As DataTable
                balancetotal = objDerived.GetDataTable("exec ams.PPMPcheckBalance " & pItems.Rows(i)("ppmp_dtl_id") & "", CommandType.Text)

                Dim firstqty, secondqty, thirdqty, fourthqty, firstqtybal, secondqtybal, thirdqtybal, fourthqtybal As Integer
                firstqty = CType(dataquarter.Rows(0)("qty1"), Integer)
                secondqty = CType(dataquarter.Rows(0)("qty2"), Integer)
                thirdqty = CType(dataquarter.Rows(0)("qty3"), Integer)
                fourthqty = CType(dataquarter.Rows(0)("qty4"), Integer)

                firstqtybal = CType(balancetotal.Rows(0)("firstqtybal"), Integer) + CType(firstqty, Integer)
                secondqtybal = CType(balancetotal.Rows(0)("secondqtybal"), Integer) + CType(secondqty, Integer)
                thirdqtybal = CType(balancetotal.Rows(0)("thirdqtybal"), Integer) + CType(thirdqty, Integer)
                fourthqtybal = CType(balancetotal.Rows(0)("fourthqtybal"), Integer) + CType(fourthqty, Integer)

                firstqtybal = CType(firstqtybal, Integer) - CType(balancetotal.Rows(0)("firstqty"), Integer)
                secondqtybal = CType(secondqtybal, Integer) - CType(balancetotal.Rows(0)("secondqty"), Integer)
                thirdqtybal = CType(thirdqtybal, Integer) - CType(balancetotal.Rows(0)("thirdqty"), Integer)
                fourthqtybal = CType(fourthqtybal, Integer) - CType(balancetotal.Rows(0)("fourthqty"), Integer)

                objDerived.GetRecords("exec AMS.updateppmpdtl " & pItems.Rows(i)("ppmp_dtl_id") & ", " & firstqty & "," & secondqty & "," & thirdqty & _
                 "," & fourthqty & "," & firstqtybal & "," & secondqtybal & "," & thirdqtybal & "," & fourthqtybal & "," & pItems.Rows(i)("price") & ",'" & Me.Session("@UserName").ToString & "'", CommandType.Text)

            Next

            'Session("rowcount") = pItems.Rows.Count - 1
            Dim row As Integer = Session("PrevRow")
            Dim CurrentRowCount As Integer = Me.Session("CurrentRowCount")

            For i As Integer = row To pItems.Rows.Count - 1
                If pItems.Rows(i)("Item_ID") <> 0 Then
                    Dim gv As New GridView
                    Dim id As String = pItems.Rows(i)("Item_ID")
                    gv.DataSource = CType(Me.Session(id.ToString), DataTable)
                    gv.DataBind()
                    dtl.ppmp_hdr_id = hdrid
                    dtl.Item_ID = pItems.Rows(i)("Item_ID")
                    dtl.Cost = pItems.Rows(i)("Price")
                    dtl.firstqty = gv.Rows(0).Cells(0).Text
                    dtl.secondqty = gv.Rows(0).Cells(2).Text
                    dtl.thirdqty = gv.Rows(0).Cells(4).Text
                    dtl.fourthqty = gv.Rows(0).Cells(6).Text
                    dtl.firstqtybal = gv.Rows(0).Cells(0).Text
                    dtl.secondqtybal = gv.Rows(0).Cells(2).Text
                    dtl.thirdqtybal = gv.Rows(0).Cells(4).Text
                    dtl.fourthqtybal = gv.Rows(0).Cells(6).Text
                    dtl.Userid = Me.Session("@UserName").ToString
                    dtl.save()
                End If
            Next

            Dim DeptHead_ID As Long = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND (isDeptHead = 'Yes')", CommandType.Text)

            objDerived.GetRecords("UPDATE AMS.ppmp_hdr set mode_of_procurement = '" & ddModeProcurement.SelectedItem.Value & "', PreparedBy = '" & ddPreparedBy.SelectedItem.Value & "', ReviewedBy = '" & DeptHead_ID & "' WHERE ppmp_hdr_id = '" & Session("hdrid") & "'", CommandType.Text)

        End If

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PPMP has been successfully saved.")

        ddPreparedBy.Enabled = False
        ddModeProcurement.Enabled = False
        btnSave.Enabled = False
        btnPreview.Enabled = True

        '=== DISPLAY IN THE TABLE
        gvPPA.DataSource = objDerived.GetRecords("EXEC [AMS].[sp_PPMPSupplemental_List] '" & Year(txtDate.Text) & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "',1,'" & ddSuppBudget.SelectedItem.Value & "'", CommandType.Text)
        gvPPA.DataBind()

        gvppmp.DataSource = objDerived.GetRecords("EXEC [AMS].[sp_PPMPSupplemental_List] '" & Year(txtDate.Text) & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "',0,'" & ddSuppBudget.SelectedItem.Value & "'", CommandType.Text)
        gvppmp.DataBind()

    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Session("year") = Year(txtDate.Text)
        'Session("rc")
        'Session("Function_ID")
        'Session("GA_ID")
        'Session("BGA_ID")
        'Session("Project_ID")
        'Session("Program_id")
        Session("isContinuing") = 0
        Session("isSupplemental") = 1

        'Me.Page.Response.Redirect("~/planning/rpt_ppmp.aspx")
        Dim url As String = "planning/rpt_ppmp.aspx"
        Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"

        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)
    End Sub
End Class
