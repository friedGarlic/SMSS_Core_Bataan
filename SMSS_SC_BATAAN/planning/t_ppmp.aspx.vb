Imports System.Data

Partial Class PLANNING_t_ppmp
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim hdr As New t_ppmp_hdr
    Dim dtl As New t_ppmp_dtl
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim tempPcanedit As Boolean
    Dim AppStatus As Boolean
    Dim tempisfinal As Boolean
    Dim AvailableBuget As Decimal
    Dim LoadPrevPPMP As Boolean = False
    'for PPMP History saving 
    Dim HistHdr As New PPMP_history_HDR
    Dim HistDtl As New PPMP_History_DTL
    Dim savestatus As Boolean
    Dim Proj_id, Prog_id As Integer
    Dim objRepair As New t_RepairAndMaintenance.TbRepairMaintenance
    Dim objRepair_Dtl As New t_RepairAndMaintenance.TbRepair_Dtl

#Region "property"
    'Trial Session
    Private Property ClickConsolidatedView() As Integer
        Get
            Return CType(Session("ClickConsolidatedView"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("ClickConsolidatedView") = value

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
    'FOR OOE
    Private Property ClickView() As Integer
        Get
            Return CType(Session("ClickView"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("ClickView") = value

        End Set
    End Property
    Private Property IsEdited() As Boolean
        Get
            Return CType(Session("IsEdited"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("IsEdited") = value
        End Set
    End Property
    Private Property ButtonPreview() As Integer
        Get
            Return CType(Session("ButtonPreview"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("ButtonPreview") = value

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
    Private Property IsActivity() As Boolean
        Get
            Return CType(Session("IsActivity"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("IsActivity") = value
        End Set
    End Property

    Private Property pYear() As DataTable
        Get
            Return CType(Session("pYear"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pYear") = value
        End Set
    End Property
    Private Property pRoleName() As DataTable
        Get
            Return CType(Session("pRoleName"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRoleName") = value
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
    Private Property saved() As Boolean
        Get
            Return CType(Session("saved"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("saved") = value
        End Set
    End Property
    Private Property withApprovedBudget() As Boolean
        Get
            Return CType(Session("withApprovedBudget"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("withApprovedBudget") = value
        End Set
    End Property


    Private Property ISSubmitted() As Boolean
        Get
            Return CType(Session("ISSubmitted"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("ISSubmitted") = value
        End Set
    End Property
    Private Property AllotmentId() As Integer
        Get
            Return CType(Session("AllotmentId"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("AllotmentId") = value
        End Set
    End Property

    Private Property pWithExisitngData() As Boolean
        Get
            Return CType(Session("pWithExisitngData"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("pWithExisitngData") = value
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

    Private Property pItems() As DataTable
        Get
            Return CType(Session("pItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItems") = value
        End Set
    End Property
    Private Property PPMPSaved() As Decimal
        Get
            Return CType(Session("PPMPSaved"), Decimal)
        End Get
        Set(ByVal value As Decimal)
            Session("PPMPSaved") = value

        End Set
    End Property
    Private Property pRC() As DataTable
        Get
            Return CType(Session("pRC"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRC") = value
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
    Private Property pAccounts() As DataTable
        Get
            Return CType(Session("pAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAccounts") = value
        End Set

    End Property
    Private Property pOpen() As DataTable
        Get
            Return CType(Session("pOpen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pOpen") = value
        End Set

    End Property
    Private Property pListitem() As DataTable
        Get
            Return CType(Session("pListitem"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pListitem") = value
        End Set

    End Property
    Property pTempEmpAccount_tbl() As DataTable
        Get
            Return CType(Session("pTempEmpAccount"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pTempEmpAccount") = value
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
    'sample
    Property Project_ID_sample() As Integer
        Get
            Return CType(Session("ProjectID"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("ProjectID") = value
        End Set
    End Property
    'AEPP/ASPP Histry of Datatable
    Private Property pItemsDetails() As DataTable
        Get
            Return CType(Session("pItemsDetails"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItemsDetails") = value
        End Set
    End Property
    '   Dim data1 As New DataTable
    Private Property data1() As DataTable
        Get
            Return CType(Session("data1"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("data1") = value
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

    Private Property isedit() As Boolean
        Get
            Return CType(Session("isedit"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("isedit") = value
        End Set
    End Property

    'AEPP/ASPP Histry of Datatable

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
        dt.Columns.Add("Item_ID", GetType(Integer))
        dt.Columns.Add("ppmp_dtl_id", GetType(Long))
        'added to recall Price
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
    Public Sub createdatatable2()
        Me.pTempEmpAccount_tbl2 = New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn

        myDataColumn = New DataColumn()
        pTempEmpAccount_tbl2.Columns.Add("qty1")
        pTempEmpAccount_tbl2.Columns.Add("price1")
        pTempEmpAccount_tbl2.Columns.Add("qty2")
        pTempEmpAccount_tbl2.Columns.Add("price2")
        pTempEmpAccount_tbl2.Columns.Add("qty3")
        pTempEmpAccount_tbl2.Columns.Add("price3")
        pTempEmpAccount_tbl2.Columns.Add("qty4")
        pTempEmpAccount_tbl2.Columns.Add("price4")

        dr = pTempEmpAccount_tbl2.NewRow
        dr("qty1") = 0
        dr("price1") = "0.00"
        dr("qty2") = 0
        dr("price2") = 0.0
        dr("qty3") = 0
        dr("price3") = "0.00"
        dr("qty4") = 0
        dr("price4") = "0.00"

        pTempEmpAccount_tbl2.Rows.Add(dr)

    End Sub
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
        'added
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
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True

            chkPrev.Visible = False
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            If Not Page.IsPostBack Then
                Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
                Dim role() As String = Roles.GetRolesForUser(usr.UserName)
                rolename = role(0)
                Session("RoleName") = rolename
                lnkView.Enabled = True
                ddPreparedBy.DataSource = Nothing
                ddPreparedBy.DataBind()
                ddPreparedBy.Items.Insert(0, "Select")

                ddmode_of_procurement.DataSource = objDerived.GetDataTable("Select * from ams.mode_of_procurement", CommandType.Text)
                ddmode_of_procurement.DataTextField = ("mode_description")
                ddmode_of_procurement.DataValueField = ("mode_of_procurement_id")
                ddmode_of_procurement.DataBind()
                ddmode_of_procurement.Items.Insert(0, "Select")

                pYear = objDerived.GetDataTable("Select * from ams.vw_app_status", CommandType.Text)
                ddyear.DataSource = pYear
                ddyear.DataTextField = ("year_title")
                ddyear.DataValueField = ("app_id")
                ddyear.DataBind()
                pRoleName = objDerived.GetDataTable("exec dbo.sp_get_rc_by_role '" & rolename & "'", CommandType.Text)

                gvbody.DataSource = createdatatable1(19)
                gvbody.DataBind()
                createdatatable2()

                gvquarters.DataSource = pTempEmpAccount_tbl2
                gvquarters.DataBind()

                txtDate.Text = String.Format("{0:MM/dd/yyyy}", Date.Today.ToString("MM/dd/yyyy").ToString())

                Me.txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

                pItems = Nothing
                btnpreview.Enabled = False
                lnkView.Enabled = False
                btnsubmit.Enabled = False
                lblpromt.Visible = False
                lblpromt2.Visible = False
                saved = False
                pWithExisitngData = False
                btnfinal.Enabled = False

                gvitems.Columns(3).Visible = True
                gvitems.Columns(4).Visible = True
                gvitems.DataSource = pListitem
                gvitems.DataBind()
                gvitems.Columns(3).Visible = False
                gvitems.Columns(4).Visible = False

                ddmode_of_procurement.Enabled = True

            End If

            SearchBut.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

        Catch ex As Exception

        End Try

    End Sub

    Public Sub RemainingBalance()
        Try
            withApprovedBudget = objDerived.GetValue("select ams.func_budget_status('" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("issupplemental") & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "')", CommandType.Text)

            If withApprovedBudget = True Or withApprovedBudget = 1 Then
                Dim saveppmp_amt As Decimal
                saveppmp_amt = CDec(CType(gvbody.FooterRow.FindControl("lbltotal"), Label).Text)

                txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - saveppmp_amt, 2)

                If txtAvailableBudget.Text < 0 Then
                    Me.lblpromt2.Text = "Please adjust your PPMP."
                    Me.lblpromt2.Visible = True
                Else
                    Me.lblpromt2.Text = "Please adjust your PPMP."
                    Me.lblpromt2.Visible = False
                End If
            Else
                txtAvailableBudget.Text = "0.00"
            End If

        Catch ex As Exception

        End Try

        'saveppmp_amt = objDerived.GetValue("select ams.savedppmp_acctgtitle (" & ddRC.SelectedItem.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("ga_id") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("bga_id") & ", " & hdfppaprojId.Value & "," & hdfppaprogId.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("iscontinuing") & "'," & AllotmentId & ")", CommandType.Text)

        'Try

        '    Dim PPMPSavedAcctgT, PPMPSavedAcctgTPerPPA As Decimal
        '    PPMPSavedAcctgT = objDerived.GetValue("select AMS.SavedPPMP_AcctgTitle (" & ddRC.SelectedItem.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & ", " & hdfppaprojId.Value & "," & hdfppaprogId.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "'," & AllotmentId & ")", CommandType.Text)
        '    PPMPSavedAcctgTPerPPA = objDerived.GetValue("select AMS.SavedPPMP_AcctgTitle_PER_PPA (" & ddRC.SelectedItem.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & ", " & hdfppaprojId.Value & "," & hdfppaprogId.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "'," & AllotmentId & ")", CommandType.Text)

        '    withApprovedBudget = objDerived.GetValue("select AMS.func_budget_status('" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "')", CommandType.Text)
        '    If Me.gvbody.Rows.Count > 0 Then
        '        PPMPSaved = CDec(CType(gvbody.FooterRow.FindControl("lbltotal"), Label).Text)
        '    Else
        '        PPMPSaved = 0
        '    End If

        '    If withApprovedBudget = 1 Or Me.txtbudget.Text <> 0 Then
        '        'FOR OOE Computation of Allocated Budget

        '        'done test
        '        If (pWithExisitngData = False Or pWithExisitngData = True) And (pInputQuantity = True Or pInputQuantity = False) And (savestatus = False Or savestatus = True) And Session("isPPA") = False Then
        '            txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - PPMPSaved, 2)
        '            'FOR OOE Computation of Allocated Budget
        '            'FOR PPA Computation of Allocated Budget

        '        ElseIf pWithExisitngData = False And pInputQuantity = False And savestatus = False And Session("isPPA") = True Then
        '            txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - PPMPSavedAcctgT, 2)

        '        ElseIf pWithExisitngData = True And pInputQuantity = False And savestatus = False And Session("isPPA") = True Then
        '            If isedit = True Then
        '                txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - PPMPSavedAcctgTPerPPA, 2)
        '            Else
        '                txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - PPMPSavedAcctgT, 2)
        '            End If

        '        ElseIf pWithExisitngData = True And pInputQuantity = True And savestatus = False And Session("isPPA") = True Then

        '            If PPMPSavedAcctgTPerPPA > PPMPSaved Then

        '                txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - (PPMPSavedAcctgT - (PPMPSavedAcctgTPerPPA - PPMPSaved)), 2)
        '            Else
        '                txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - (PPMPSavedAcctgT + (PPMPSaved - PPMPSavedAcctgTPerPPA)), 2)
        '            End If

        '        ElseIf pWithExisitngData = True And pInputQuantity = True And savestatus = True And Session("isPPA") = True Then

        '            If PPMPSavedAcctgTPerPPA > PPMPSaved Then
        '                txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - (PPMPSavedAcctgT - (PPMPSavedAcctgTPerPPA - PPMPSaved)), 2)
        '            Else
        '                txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - (PPMPSavedAcctgT + (PPMPSaved - PPMPSavedAcctgTPerPPA)), 2)
        '            End If

        '        ElseIf pWithExisitngData = False And pInputQuantity = False And savestatus = True And Session("isPPA") = True Then
        '            txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - (Me.PPMPSaved + PPMPSavedAcctgT), 2)
        '        ElseIf pWithExisitngData = False And pInputQuantity = True And savestatus = False And Session("isPPA") = True Then
        '            txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - (Me.PPMPSaved + PPMPSavedAcctgT), 2)
        '        Else
        '            txtAvailableBudget.Text = 0
        '        End If

        '        If CType(txtAvailableBudget.Text, Decimal) < CType("0.00", Decimal) Then
        '            txtAvailableBudget.ForeColor = Drawing.Color.Red
        '        Else
        '            txtAvailableBudget.ForeColor = Drawing.Color.Black
        '        End If

        '    Else
        '        txtAvailableBudget.Text = "0.00"
        '    End If

        '    If CDec(Me.txtAvailableBudget.Text) < 0 Then
        '        Me.lblpromt2.Text = "Please adjust your PPMP."
        '        Me.lblpromt2.Visible = True
        '    ElseIf CDec(Me.txtbudget.Text) - CDec(Me.txtAvailableBudget.Text) = 0 Then
        '        Me.lblpromt2.Text = "No prepared PPMP."
        '        Me.lblpromt2.Visible = True
        '    ElseIf CDec(Me.txtbudget.Text) > CDec(Me.txtAvailableBudget.Text) And PPMPSaved <> CDec(Me.txtbudget.Text) And Me.Session("Issubmited") = False And Me.Session("Locked") = False Then

        '        Me.lblpromt2.Text = "You may adjust your PPMP."
        '        Me.lblpromt2.Visible = True

        '    ElseIf CDec(Me.txtbudget.Text) > CDec(Me.txtAvailableBudget.Text) And PPMPSaved <> CDec(Me.txtbudget.Text) And Me.Session("Issubmited") = False And Me.Session("Locked") = True Then
        '        Me.lblpromt2.Text = "Your PPMP has been Locked."
        '        Me.lblpromt2.Visible = True

        '    ElseIf CDec(Me.txtbudget.Text) > CDec(Me.txtAvailableBudget.Text) And PPMPSaved <> CDec(Me.txtbudget.Text) And Me.Session("Issubmited") = True And Me.Session("Locked") = False Then
        '        Me.lblpromt2.Text = "Your PPMP has been Submitted"
        '        Me.lblpromt2.Visible = True
        '        btnfinal.Enabled = False

        '    ElseIf CDec(Me.txtbudget.Text) > CDec(Me.txtAvailableBudget.Text) And PPMPSaved <> CDec(Me.txtbudget.Text) And Me.Session("Issubmited") = True And Me.Session("Locked") = True Then
        '        Me.lblpromt2.Text = "Your PPMP has been Locked."
        '        Me.lblpromt2.Visible = True

        '    ElseIf CDec(Me.txtbudget.Text) > CDec(Me.txtAvailableBudget.Text) And PPMPSaved = 0 And Me.Session("Issubmitted") = False Then
        '        Me.lblpromt2.Text = "No prepared PPMP."
        '        Me.lblpromt2.Visible = True

        '    Else
        '        Me.lblpromt2.Text = ""
        '        Me.lblpromt2.Visible = False

        '    End If

        'Catch ex As Exception
        'End Try

    End Sub

    Public Sub gridEnable()
        ' Dim data As DataTable = pItems
        Dim cb, cbheader As CheckBox
        Dim itemid As Integer
        Dim txt As Integer
        Dim gv As New GridView
        gv.DataSource = pItems
        gv.DataBind()
        Dim countE As Integer = 0
        For i As Integer = 0 To Me.gvitems.Rows.Count - 1
            itemid = CType(Me.gvitems.Rows(i).Cells(3).Text, Integer)
            cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            For o As Integer = 0 To gv.Rows.Count - 1
                txt = CType(gv.Rows(o).Cells(5).Text, Integer)
                If txt = itemid Then
                    cb.Checked = False
                    cb.Enabled = False
                    countE = countE + 1
                End If

            Next
        Next

        '-----------------



        For o As Integer = 0 To Me.gvitems.Rows.Count - 1
            cb = CType(Me.gvitems.Rows(o).Cells(0).FindControl("CheckBox1"), CheckBox)
            If cb.Enabled = False Then
                pListitem.Rows(Me.gvitems.Rows(o).Cells(4).Text).Delete()
            End If
        Next
        gvitems.DataSource = pListitem
        gvitems.DataBind()

    End Sub

    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim cbheader As CheckBox
        Me.gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        Me.gvitems.PageIndex = e.NewPageIndex
        Me.gvitems.DataSource = CType(pListitem, DataTable)
        Me.gvitems.DataBind()
        Me.gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        CType(gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Enabled = True

        ModalPopupExtender3.Show()
    End Sub

    Protected Sub gvitems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub gvbody_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvbody.SelectedIndexChanged
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


        ElseIf pLbtn = "Delete" Then
            Dim id As Integer = gvbody.SelectedDataKey("ppmp_dtl_id")

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PPMPDelete_ItemCheck] WHERE ppmp_dtl_id = '" & gvbody.SelectedDataKey("ppmp_dtl_id") & "' ORDER BY PRDtlID", CommandType.Text)

            If dt.Rows.Count <> 0 Then
                Dim dtitemCount As New DataTable
                dtitemCount = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PPMPDelete_ItemCheck] WHERE ppmp_hdr_id = '" & dt.Rows(0)("ppmp_hdr_id") & "'", CommandType.Text)

                If dtitemCount.Rows.Count = 1 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Save new item to continue.")
                    Exit Sub
                End If

                If dt.Rows(0)("PRDtlID") = 0 Then
                    '=================== WITH PPMP , NO PR
                    objDerived.GetRecords("DELETE FROM AMS.ppmp_dtl WHERE ppmp_dtl_id = '" & gvbody.SelectedDataKey("ppmp_dtl_id") & "'", CommandType.Text)

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected item has been successfully deleted.")

                    pItems = objDerived.GetDataTable("exec ams.  " & Me.ddRC.SelectedItem.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & Me.hdfppaprojId.Value & "," & Me.hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                    gvbody.DataSource = pItems
                    gvbody.DataBind()

                    Session("RowCount_Existing") = pItems.Rows.Count - 1

                ElseIf dt.Rows(0)("PRDtlID") <> 0 And dt.Rows(0)("ppmp_dtl_id") <> 0 And dt.Rows(0)("IsCancelled") = True And dt.Rows.Count = 1 Then
                    '=================== WITH PPMP , WITH PR BUT CANCELLED
                    objDerived.GetRecords("DELETE FROM AMS.ppmp_dtl WHERE ppmp_dtl_id = '" & gvbody.SelectedDataKey("ppmp_dtl_id") & "'", CommandType.Text)

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected item has been successfully deleted.")

                    pItems = objDerived.GetDataTable("exec ams.sp_ppmpsaved " & Me.ddRC.SelectedItem.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & Me.hdfppaprojId.Value & "," & Me.hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                    gvbody.DataSource = pItems
                    gvbody.DataBind()

                    Session("RowCount_Existing") = pItems.Rows.Count - 1

                ElseIf dt.Rows(0)("PRDtlID") <> 0 And dt.Rows(0)("ppmp_dtl_id") <> 0 And dt.Rows(0)("IsCancelled") = 0 Then
                    '=================== WITH PPMP , WITH PR
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected item cannot be deleted. Item has already been used in an existing PR.")

                Else
                    '=================== WITH PPMP , WITH 2 PR (CANCELLED AND APPROVED)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected item cannot be deleted. Item has already been used in an existing PR.")

                End If

            ElseIf dt.Rows.Count = 0 Then
                '=================== NO PPMP , NO PR
                For i As Integer = 0 To pItems.Rows.Count - 1
                    Dim a As Integer = pItems.Rows(i).Item("Item_ID")
                    Dim b As Integer = gvbody.SelectedDataKey("Item_ID")

                    If pItems.Rows(i).Item("Item_ID") = gvbody.SelectedDataKey("Item_ID") Then
                        pItems.Rows(i).Delete()

                        Exit For

                    End If
                Next

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected item has been successfully deleted.")
                gvbody.DataSource = pItems
                gvbody.DataBind()

            End If

            CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            RemainingBalance()

        Else

            'Session("1") = gvbody.SelectedDataKey(0)
            'Session("0") = gvbody.SelectedDataKey(1)

            Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
            Me.gvquarters.DataBind()

            If pCanEdit = True And Session("Issubmited") = False And saved = False Then
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

            ElseIf pCanEdit = True And Session("Issubmited") = True And saved = False Then
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

        End If

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
                    verify = CType(objDerived.GetValue("SELECT TOP (1) firstqtr as firstqtr FROM AMS.ppmp_hdr WHERE Cyear ='" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "' ", CommandType.Text), Boolean)
                Catch ex As Exception
                    verify = False
                End Try

                If verify = True Then
                    msg.UserMsgBox("Editing data for first qurater is not allowed.", Me, False)
                    Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                    Me.gvquarters.DataBind()
                    Exit Sub
                Else
                    'Input Quantity in Items
                    pInputQuantity = True
                    Dim balancetotal As DataTable
                    balancetotal = objDerived.GetDataTable("exec ams.PPMPcheckBalance " & gvbody.SelectedDataKey(1) & "", CommandType.Text)
                    If balancetotal.Rows.Count >= 1 Then
                        If CType(txtqty.Text, Decimal) < (CType(balancetotal.Rows(0)("firstqty"), Decimal) - CType(balancetotal.Rows(0)("firstqtybal"), Decimal)) Then

                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must not lower than '" & CType(balancetotal.Rows(0)("firstqty"), Decimal) - CType(balancetotal.Rows(0)("firstqtybal"), Decimal) & "'. The said quantity has already been purchased!.")
                            Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                            Me.gvquarters.DataBind()
                            Exit Sub
                        End If
                    End If
                End If
            End If
            btnsubmit.Enabled = True


            Dim price As Decimal = CType(gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(Me.gvquarters.Rows(gvr.RowIndex).Cells(0).FindControl("lblprice1"), Label).Text = FormatNumber(price * CType(txtqty.Text, Decimal), 0)

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
            pItems.Rows(gvbody.SelectedIndex)("qty") = FormatNumber(CType(Val(txtqty.Text) + Val(qty2.Text) + Val(qty3.Text) + Val(qty4.Text), Double), 0)
            'pItems.Rows(gvbody.SelectedIndex)("total") = FormatNumber(CType(pItems.Rows(gvbody.SelectedIndex)("qty").ToString, Integer) * CType(Me.gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text, 2)

            pItems.Rows(gvbody.SelectedIndex)("total") = FormatNumber(CType(pItems.Rows(gvbody.SelectedIndex)("qty") * price, Decimal), 0)
            gvbody.DataSource = pItems
            gvbody.DataBind()

            Me.btnsubmit.Enabled = True
            CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            RemainingBalance()

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
                    verify = CType(objDerived.GetValue("SELECT TOP (1) secondqrt FROM AMS.ppmp_hdr WHERE Cyear ='" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "' ", CommandType.Text), Boolean)
                Catch ex As Exception
                    verify = False
                End Try

                If verify = True Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Editing data for second qurater is not allowed.")
                    Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                    Me.gvquarters.DataBind()
                    Exit Sub
                Else
                    'Input Quantity in Items
                    pInputQuantity = True
                    Dim balancetotal As DataTable
                    balancetotal = objDerived.GetDataTable("exec ams.PPMPcheckBalance " & gvbody.SelectedDataKey(1) & "", CommandType.Text)
                    If balancetotal.Rows.Count >= 1 Then
                        If CType(txtqty.Text, Decimal) < (CType(balancetotal.Rows(0)("secondqty"), Decimal) - CType(balancetotal.Rows(0)("secondqtybal"), Decimal)) Then
                            'msg.UserMsgBox("Quantity must not lower than '" & CType(balancetotal.Rows(0)("secondqty"), decimal) - CType(balancetotal.Rows(0)("secondqtybal"), decimal) & "'. The said quantity has already been purchased!.", Me, False)
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must not lower than '" & CType(balancetotal.Rows(0)("secondqty"), Decimal) - CType(balancetotal.Rows(0)("secondqtybal"), Decimal) & "'. The said quantity has already been purchased!.")
                            Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                            Me.gvquarters.DataBind()
                            Exit Sub
                        End If
                    End If
                End If
            End If
            btnsubmit.Enabled = True

            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            Dim price As Decimal = CType(gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(Me.gvquarters.Rows(gvr.RowIndex).Cells(1).FindControl("lblprice2"), Label).Text = FormatNumber(price * CType(txtqty.Text, Decimal), 2)

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

            pItems.Rows(gvbody.SelectedIndex)("qty") = FormatNumber(CType(Val(txtqty.Text) + Val(qty1.Text) + Val(qty3.Text) + Val(qty4.Text), Double), 0)
            'pItems.Rows(gvbody.SelectedIndex)("total") = FormatNumber(CType(pItems.Rows(gvbody.SelectedIndex)("qty").ToString, Integer) * CType(Me.gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text, 2)

            pItems.Rows(gvbody.SelectedIndex)("total") = FormatNumber(CType(pItems.Rows(gvbody.SelectedIndex)("qty") * price, Decimal), 2)
            gvbody.DataSource = pItems
            gvbody.DataBind()

            Me.btnsubmit.Enabled = True
            CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            RemainingBalance()

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
                    verify = CType(objDerived.GetValue("SELECT     TOP (1) thirdqtr FROM AMS.ppmp_hdr WHERE Cyear ='" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "' ", CommandType.Text), Boolean)
                Catch ex As Exception
                    verify = False
                End Try

                If verify = True Then

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Editing data for third qurater is not allowed.")

                    Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                    Me.gvquarters.DataBind()
                    Exit Sub
                Else
                    'Input Quantity in Items
                    pInputQuantity = True
                    Dim balancetotal As DataTable
                    balancetotal = objDerived.GetDataTable("exec ams.PPMPcheckBalance " & gvbody.SelectedDataKey(1) & "", CommandType.Text)
                    If balancetotal.Rows.Count >= 1 Then
                        If CType(txtqty.Text, Decimal) < (CType(balancetotal.Rows(0)("thirdqty"), Decimal) - CType(balancetotal.Rows(0)("thirdqtybal"), Decimal)) Then
                            'msg.UserMsgBox("Quantity must not lower than '" & CType(balancetotal.Rows(0)("thirdqty"), decimal) - CType(balancetotal.Rows(0)("thirdqtybal"), decimal) & "'. The said quantity has already been purchased!.", Me, False)
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must not lower than '" & CType(balancetotal.Rows(0)("thirdqty"), Decimal) - CType(balancetotal.Rows(0)("thirdqtybal"), Decimal) & "'. The said quantity has already been purchased!.")
                            Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                            Me.gvquarters.DataBind()
                            Exit Sub
                        End If
                    End If
                End If
            End If
            btnsubmit.Enabled = True
            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            Dim price As Decimal = CType(gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(Me.gvquarters.Rows(gvr.RowIndex).Cells(2).FindControl("lblprice3"), Label).Text = FormatNumber(price * CType(txtqty.Text, Decimal), 2)
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

            pItems.Rows(gvbody.SelectedIndex)("qty") = FormatNumber(CType(Val(txtqty.Text) + Val(qty2.Text) + Val(qty1.Text) + Val(qty4.Text), Double), 0)
            'pItems.Rows(gvbody.SelectedIndex)("total") = FormatNumber(CType(pItems.Rows(gvbody.SelectedIndex)("qty").ToString, Integer) * CType(Me.gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text, 2)
            pItems.Rows(gvbody.SelectedIndex)("total") = FormatNumber(CType(pItems.Rows(gvbody.SelectedIndex)("qty") * price, Decimal), 2)

            gvbody.DataSource = pItems
            gvbody.DataBind()

            Me.btnsubmit.Enabled = True
            CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            RemainingBalance()

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
                    verify = CType(objDerived.GetValue("SELECT TOP (1) fourthqrt FROM AMS.ppmp_hdr WHERE Cyear ='" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "' ", CommandType.Text), Boolean)
                Catch ex As Exception
                    verify = False
                End Try

                If verify = True Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Editing data for fourth qurater is not allowed.")
                    Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                    Me.gvquarters.DataBind()
                    Exit Sub
                Else
                    'Input Quantity in Items
                    pInputQuantity = True
                    Dim balancetotal As DataTable
                    balancetotal = objDerived.GetDataTable("exec ams.PPMPcheckBalance " & gvbody.SelectedDataKey(1) & "", CommandType.Text)
                    If balancetotal.Rows.Count >= 1 Then
                        If CType(txtqty.Text, Decimal) < (CType(balancetotal.Rows(0)("fourthqty"), Decimal) - CType(balancetotal.Rows(0)("fourthqtybal"), Decimal)) Then
                            ''If (CType(balancetotal.Rows(0)("fourthqtybal"), decimal) + CType(txtqty.Text, Decimal)) < CType(balancetotal.Rows(0)("fourthqty"), decimal) Then
                            msg.UserMsgBox("Quantity must not lower than '" & CType(balancetotal.Rows(0)("fourthqty"), Decimal) - CType(balancetotal.Rows(0)("fourthqtybal"), Decimal) & "'. The said quantity has already been purchased!.", Me, False)
                            Me.gvquarters.DataSource = CType(Me.Session(CType(gvbody.SelectedDataKey(0), String)), DataTable)
                            Me.gvquarters.DataBind()
                            Exit Sub
                        End If
                    End If
                End If
            End If
            txtqty.Focus()


            btnsubmit.Enabled = True
            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            Dim price As Decimal = CType(gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(Me.gvquarters.Rows(gvr.RowIndex).Cells(3).FindControl("lblprice4"), Label).Text = FormatNumber(price * CType(txtqty.Text, Decimal), 2)
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

            pItems.Rows(gvbody.SelectedIndex)("qty") = FormatNumber(CType(Val(txtqty.Text) + Val(qty2.Text) + Val(qty3.Text) + Val(qty1.Text), Double), 0)
            ' pItems.Rows(gvbody.SelectedIndex)("total") = FormatNumber(CType(pItems.Rows(gvbody.SelectedIndex)("qty").ToString, Integer) * CType(Me.gvbody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text, 2)
            pItems.Rows(gvbody.SelectedIndex)("total") = FormatNumber(CType(pItems.Rows(gvbody.SelectedIndex)("qty") * price, Decimal), 2)
            gvbody.DataSource = pItems
            gvbody.DataBind()

            Me.btnsubmit.Enabled = True
            CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            RemainingBalance()

            If pItems.Rows(gvbody.SelectedIndex + 1)("id") = 1 Then
                addQTY()
            End If

        Catch ex As Exception
            ''msg.UserMsgBox("Select a supply first", Me, False)
        End Try
    End Sub


    Protected Sub gvquarters_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvquarters.SelectedIndexChanged

    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True

            If SearchBut.Text = "" Then
                SearchBut.Text = ""
            End If

            Dim myview As DataView
            myview = pListitem.DefaultView

            If drpSearchBy.SelectedItem.Value = 1 Then
                myview.RowFilter = "Item_desc like '%" & replaceapostrophe(SearchBut.Text.ToString) & "%' and isUsed = false"
            ElseIf drpSearchBy.SelectedItem.Value = 2 Then
                If SearchBut.Text = "" Then
                    SearchBut.Text = 0
                End If

                myview.RowFilter = "Price = " & SearchBut.Text & " and isUsed = false"
            End If

            gvitems.DataSource = myview
            gvitems.DataBind()
            gvitems.SelectedIndex = -1
            gvitems.PageIndex = 0

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False

            ModalPopupExtender3.Show()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Protected Sub ddlistRC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddRC.SelectedIndexChanged
        Session("rc") = ddRC.SelectedItem.Value

        Try
            ddFunction.Items.Clear()

            If ddRC.SelectedItem.Text = "Select" Then
                pFunction = Nothing
                ddFunction.DataSource = pFunction
                ddFunction.DataBind()
                ddFunction.Items.Add("Select")
            Else
                'pFunction = objDerived.GetDataTable("select Office_id as Rc_id,Function_id,Function_desc from ams.vw_functions  where Office_id = " & ddRC.SelectedItem.Value & "", CommandType.Text)

                pFunction = objDerived.GetDataTable("EXEC [dbo].[sp_function_systemManager] '" & Session("RoleName") & "','" & Session("rc") & "'", CommandType.Text)
                ddFunction.Items.Add("Select")
                ddFunction.DataSource = pFunction
                ddFunction.DataTextField = ("Function_Desc")
                ddFunction.DataValueField = ("Function_ID")
                ddFunction.DataBind()


                ddFunction.Enabled = True
                'ddRC.Enabled = False

            End If
            Session("rc") = ddRC.SelectedItem.Value

        Catch ex As Exception
        End Try
    End Sub



    Protected Sub gvopen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub gvitems_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub gvitems_SelectedIndexChanged2(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub



    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        gvitems.Columns(4).Visible = True
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                    ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = True
                    pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isChecked") = True

                End If
            Next
        Else
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
                ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = False
                pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isChecked") = False
            Next
        End If

        gvitems.Columns(4).Visible = False
        ModalPopupExtender3.Show()

    End Sub

    Protected Sub CheckBox1_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim pItems1 As New DataTable

        Try
            Dim sumObject As Integer
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            Dim dt As New DataTable
            Dim dr As DataRow
            'Dim cb As CheckBox
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

            Dim cyear As String = "CY" & pYear.Rows(ddyear.SelectedIndex - 1)("year")
            If pItems.Rows.Count <= 0 Then
                dt.Columns.Add("id", GetType(Integer))
                dt.Columns.Add("Item_Desc", GetType(String))
                dt.Columns.Add("Description", GetType(String))
                dt.Columns.Add("qty", GetType(Decimal))
                dt.Columns.Add("price", GetType(Decimal))
                dt.Columns.Add("total", GetType(Decimal))
                dt.Columns.Add("Item_ID", GetType(Integer))
                dt.Columns.Add("ppmp_dtl_id", GetType(Long))

                Session("LoadPrevPPMP") = False

                For i As Integer = 0 To Me.pListitem.Rows.Count - 1
                    Dim pListitem2 As New DataTable
                    pListitem2 = pListitem

                    If pListitem.Rows(i)("isChecked") = True Then
                        dr = dt.NewRow
                        dr("id") = 1
                        dr("Item_Desc") = Replace(pListitem.Rows(i)("Item_Desc"), ">", "<br />")
                        dr("Description") = pListitem.Rows(i)("Description")
                        dr("qty") = 0
                        dr("price") = FormatNumber(objDerived.GetValue("exec AMS.itemprice_withprice '" & pListitem.Rows(i)("Item_ID") & "','" & cyear & "'", CommandType.Text), 2)
                        dr("total") = "0.00"
                        dr("Item_ID") = pListitem.Rows(i)("Item_ID")
                        dr("ppmp_dtl_id") = 0
                        dt.Rows.Add(dr)
                        pListitem.Rows(i)("isUsed") = True
                        pListitem.Rows(i)("isChecked") = False
                        Me.Session(CType(pListitem.Rows(i)("Item_ID"), String)) = dtQ
                    End If
                Next

                pItems = dt

                'sumObject = pItems.Compute("count(id)", "id=1")
                'If sumObject <= 19 Then
                '    pItems.Merge(createdatatable1(19 - sumObject))
                'End If


            Else
                sumObject = pItems.Compute("count(id)", "id=1")
                If Session("LoadPrevPPMP") = False Then
                    For i As Integer = 0 To Me.pListitem.Rows.Count - 1
                        If pListitem.Rows(i)("isChecked") = True Then
                            dt = pItems
                            dr = dt.NewRow
                            dr("id") = 1
                            dr("Item_Desc") = Replace(pListitem.Rows(i)("Item_Desc"), ">", "<br />")
                            dr("Description") = pListitem.Rows(i)("Description")
                            dr("qty") = 0
                            dr("price") = FormatNumber(objDerived.GetValue("exec AMS.itemprice_withprice '" & pListitem.Rows(i)("Item_ID") & "','" & cyear & "'", CommandType.Text), 2)
                            dr("total") = "0.00"
                            dr("Item_ID") = pListitem.Rows(i)("Item_ID")
                            dr("ppmp_dtl_id") = 0
                            dt.Rows.Add(dr)
                            pItems = dt
                            pListitem.Rows(i)("isUsed") = True
                            pListitem.Rows(i)("isChecked") = False
                            Me.Session(CType(pListitem.Rows(i)("Item_ID"), String)) = dtQ
                        End If
                    Next

                    'If pItems.Rows.Count < 20 Then
                    '    pItems.Merge(createdatatable1(19 - pItems.Rows.Count))
                    'End If
                    'If sumObject <= 19 Then
                    '    For i As Integer = 0 To 20
                    '        If sumObject + i < 20 Then
                    '            pItems.Rows(19 - i).Delete()
                    '        Else
                    '            Exit For
                    '        End If
                    '    Next
                    '    sumObject = pItems.Compute("count(id)", "id=1")
                    '    Me.Session("CurrentRowCount") = sumObject
                    '    pItems.Merge(createdatatable1(19 - sumObject))
                    'End If

                Else ' Load Prev PPMP
                    Dim dt2 As New DataTable
                    Dim dr2 As DataRow
                    dt2.Columns.Add("id", GetType(Integer))
                    dt2.Columns.Add("Item_Desc", GetType(String))
                    dt2.Columns.Add("Description", GetType(String))
                    dt2.Columns.Add("qty", GetType(Decimal))
                    dt2.Columns.Add("price", GetType(Decimal))
                    dt2.Columns.Add("total", GetType(Decimal))
                    dt2.Columns.Add("Item_ID", GetType(Integer))
                    dt2.Columns.Add("ppmp_dtl_id", GetType(Integer))
                    For i As Integer = 0 To Me.pListitem.Rows.Count - 1
                        If pListitem.Rows(i)("isChecked") = True Then
                            dt2 = pItems
                            dr2 = dt2.NewRow
                            dr2("id") = 1
                            dr2("Item_Desc") = pListitem.Rows(i)("Item_Desc")
                            dr2("Description") = pListitem.Rows(i)("Description")
                            dr2("qty") = 0
                            dr2("price") = FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & pListitem.Rows(i)("Item_ID") & "','" & cyear & "'", CommandType.Text), 2)
                            dr2("total") = "0.00"
                            dr2("Item_ID") = pListitem.Rows(i)("Item_ID")
                            dr2("ppmp_dtl_id") = 0
                            dt2.Rows.Add(dr2)
                            pItems = dt2
                            pListitem.Rows(i)("isUsed") = True
                            pListitem.Rows(i)("isChecked") = False
                            Me.Session(CType(pListitem.Rows(i)("Item_ID"), String)) = dtQ
                        End If
                    Next

                    'If pItems.Rows.Count < 20 Then
                    '    pItems.Merge(createdatatable1(19 - pItems.Rows.Count))
                    'End If

                    'If sumObject <= 19 Then
                    '    For i As Integer = 0 To 20
                    '        If sumObject + i < 20 Then
                    '            pItems.Rows(19 - i).Delete()
                    '        Else
                    '            Exit For
                    '        End If
                    '    Next
                    '    sumObject = pItems.Compute("count(id)", "id=1")
                    '    Me.Session("CurrentRowCount") = sumObject
                    '    pItems.Merge(createdatatable3(19 - pItems.Rows.Count))
                    'End If

                End If
            End If

            gvbody.DataSource = pItems
            gvbody.DataBind()

            Dim data As DataTable
            data = pListitem

            Dim myview As DataView
            myview = pListitem.DefaultView
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
            Me.gvquarters.DataSource = dtQ
            Me.gvquarters.DataBind()
            gvbody.SelectedIndex = -1
            ddAccount.Enabled = False
            btnsubmit.Enabled = True

            ModalPopupExtender3.Show()

        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub

    Protected Sub gvitems_SelectedIndexChanged3(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    'Protected Sub SearchBut_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        'pListitem = objDerived.GetDataTable("exec  ams.appsearch '" & SearchBut.Text & "'", CommandType.Text)
    '        Me.gvitems.Columns(3).Visible = True
    '        gvitems.Columns(4).Visible = True

    '        Dim myview As DataView
    '        myview = pListitem.DefaultView
    '        myview.RowFilter = "Item_Desc like '" & SearchBut.Text & "%' and isUsed = false"
    '        '  Me.gvitems.DataSource = objDerived.Search(pListitem, "Item_Desc", SearchBut.Text)
    '        gvitems.DataSource = myview

    '        Me.gvitems.DataBind()
    '        Me.gvitems.Columns(3).Visible = False
    '        gvitems.Columns(4).Visible = False
    '        ' Me.Session("search") = True
    '        ' gridEnable()
    '        gvitems.SelectedIndex = -1
    '        gvitems.PageIndex = 0
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        'Added to change the name of PPMP to AEPP or ASPP 05-30-2013

        Dim AllotmenClassID As Integer

        Session("Ga_id") = pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID")
        Session("isSupplemental") = pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental")

        AllotmenClassID = objDerived.GetValue("exec ams.GetAllotmentID " & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "", CommandType.Text)

        If AllotmenClassID = 3 Then
            Session("ASPPName") = "AEPP"
            Session("ASPPNameWithbal") = "AEPP With Balance"
        ElseIf AllotmenClassID = 2 Then
            Session("ASPPName") = "ASPP"
            Session("ASPPNameWithbal") = "ASPP With Balance"
        Else
            Session("ASPPName") = "ASPP/AEPP"
            Session("ASPPNameWithbal") = "ASPP/AEPP With Balance"
        End If

        Me.Page.Response.Redirect("~/planning/rpt_ppmp.aspx")

    End Sub
    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Dim lblTot1 As Double = CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text
        If lblTot1 > 0 Then

        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please encode the quantity on the Quantity Per Unit table.")
            Exit Sub
        End If

        savestatus = True
        Me.Session.Add("ButtonPreview", 1)
        ClickConsolidatedView = 1

        'Try
        'If ddmode_of_procurement.SelectedItem.Text = "Select" Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select mode of procurement.")
        '    lblReq1.Visible = False
        '    lblReq2.Visible = True
        '    Exit Sub
        'Else
        If ddPreparedBy.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory for prepared by.")
            lblReq1.Visible = True
            lblReq2.Visible = False
            Exit Sub
        End If

        If CDec(txtAvailableBudget.Text) > 0 Or CDec(txtAvailableBudget.Text) = 0 Then
            Dim data As DataTable = pItems
            If pWithExisitngData = False Then
                hdr.CYear = pYear.Rows(ddyear.SelectedIndex - 1)("year") '
                hdr.pDate = txtDate.Text '
                'hdr.PreparedBy = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND (isDeptHead = 'Yes')", CommandType.Text) 
                hdr.PreparedBy = ddPreparedBy.SelectedItem.Value '
                hdr.ReviewedBy = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND (isDeptHead = 'Yes')", CommandType.Text) 'Department Head's EmpID
                hdr.ApprovedBy = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE (deptid = 1) AND (division_key = 86) AND (isDeptHead = 'Yes')", CommandType.Text) 'Mayor's EmpID
                hdr.RecommendedBy = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE (deptid = 7) AND (division_key = 86) AND (isDeptHead = 'Yes')", CommandType.Text) 'GSO's EmpID
                Session("rc") = Me.ddRC.SelectedItem.Value
                Session("year") = pYear.Rows(ddyear.SelectedIndex - 1)("year")
                hdr.RC_ID = Me.ddRC.SelectedItem.Value
                hdr.GA_ID = pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID")
                hdr.BGA_ID = pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID")
                '11282022
                hdr.Project_ID = hdfppaprojId.Value
                hdr.Program_id = hdfppaprogId.Value
                hdr.Function_ID = ddFunction.SelectedItem.Value
                hdr.firstqtr = False
                hdr.secondqrt = False
                hdr.thirdqtr = False
                hdr.fourthqrt = False
                hdr.isfinal = True
                hdr.app_id = ddyear.SelectedItem.Value
                hdr.isContinuing = pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing")
                hdr.isSupplemental = pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental")

                If CBIsGoods.Checked Then
                    hdr.isGoods = False
                Else
                    hdr.isGoods = True
                End If

                If CBIsInfra.Checked Then
                    hdr.isInfra = True
                Else
                    hdr.isInfra = False
                End If

                hdr.mode_of_procurement = 0 'Session("mode_of_procurement")hdr.app_id = pYear.Rows(ddyear.SelectedIndex - 1)("app_id")

                'If cbConstructionMaterials.Checked = True Then
                '    hdr.isConstructionMaterials = True
                'Else
                '    hdr.isConstructionMaterials = False
                'End If

                btnsubmit.Enabled = False
                hdr.isforRevision = False 'pCanEdit' remove Firtsload must be False
                hdr.Userid = Me.Session("@UserName").ToString

                Dim hdrid As Long = hdr.save
                Me.Session("hdrid") = hdrid

                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    'If CType(Me.gvbody.Rows(i).Cells(3).FindControl("lblqty"), Label).Text <> "0" Then
                    If pItems.Rows(i)("Item_ID") <> 0 Then
                        Dim gv As New GridView
                        Dim b As Integer = data.Rows(i)("Item_ID")
                        gv.DataSource = CType(Me.Session(data.Rows(i)("Item_ID").ToString), DataTable)
                        gv.DataBind()
                        dtl.ppmp_hdr_id = hdrid
                        dtl.Item_ID = data.Rows(i)("Item_ID")
                        dtl.Cost = data.Rows(i)("Price")
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
                    'End If
                Next


                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PPMP successfully saved.")

                '============ For Repair and Maintainance ===============
                'Dim pProperties As New DataTable
                'If ddAccount.SelectedValue = 822 Or ddAccount.SelectedValue = 826 Or ddAccount.SelectedValue = 821 Or ddAccount.SelectedValue = 823 Or ddAccount.SelectedValue = 802 Or ddAccount.SelectedValue = 841 Or ddAccount.SelectedValue = 811 Then
                '    If ddAccount.SelectedValue = 822 Then
                '        lblRepairItems.Text = "Furniture and Fixtures Items"
                '        Session("rGA_ID") = 534

                '    ElseIf ddAccount.SelectedValue = 826 Then
                '        lblRepairItems.Text = "Machineries Items"
                '        Session("rGA_ID") = 537

                '    ElseIf ddAccount.SelectedValue = 841 Then
                '        lblRepairItems.Text = "Transportation Items"
                '        Session("rGA_ID") = 549

                '    ElseIf ddAccount.SelectedValue = 821 Then
                '        lblRepairItems.Text = "Equipment Items"
                '        Session("rGA_ID") = 535

                '    ElseIf ddAccount.SelectedValue = 811 Then
                '        lblRepairItems.Text = "Buildings"
                '        Session("rGA_ID") = 525

                '    ElseIf ddAccount.SelectedValue = 823 Then
                '        lblRepairItems.Text = "IT Equipment and Software Items"
                '        Session("rGA_ID") = 535

                '    ElseIf ddAccount.SelectedValue = 802 Then
                '        lblRepairItems.Text = "Land and Improvements"
                '        Session("rGA_ID") = 520

                '    End If


                '    pProperties = objDerived.GetDataTable("Select * from dbo.View_ItemsForRepair where GA_ID ='" & Session("rGA_ID") & "' and RC_ID ='" & ddRC.SelectedValue & "' and Function_ID ='" & ddFunction.SelectedValue & "'", CommandType.Text)
                '    If pProperties.Rows.Count = 0 Then
                '        gvRepairs.DataSource = createdatatableRepair(8)
                '        gvRepairs.DataBind()
                '        btnOK.Enabled = False
                '    Else
                '        If pProperties.Rows.Count < 8 Then
                '            pProperties.Merge(createdatatableRepair(8 - pProperties.Rows.Count))
                '        End If
                '        gvRepairs.DataSource = pProperties
                '        gvRepairs.DataBind()
                '        btnOK.Enabled = True
                '    End If

                '    txtItemDesc.Text = ""
                '    txtNatureRepair.Text = ""
                '    txtServiceProvider.Text = ""
                '    txtPropertyNo.Text = ""
                '    txtInvoiceNo.Text = ""
                '    txtrepairDate.Text = Date.Today.ToString("MM/dd/yyyy")

                '    ModalPopupExtender2.Show()
                'End If



            Else
                pItemsDetails = objDerived.GetDataTable("SELECt firstqty, secondqty, thirdqty, fourthqty,Cost ,Item_ID FROM [AMS].[Load_preV] where rc_id= " & Me.ddRC.SelectedItem.Value & " and CYear='" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "' and Function_ID=" & ddFunction.SelectedItem.Value & "and GA_ID=" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & " and BGA_ID=" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & " and Project_ID=" & hdfppaprojId.Value & "and Program_id=" & hdfppaprogId.Value & " and isContinuing='" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "'", CommandType.Text)
                Session("hdrid") = objDerived.GetValue("Select ppmp_hdr_id from AMS.ppmp_hdr where rc_id= " & Me.ddRC.SelectedItem.Value & " and CYear='" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "' and Function_ID=" & ddFunction.SelectedItem.Value & "and GA_ID=" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & " and BGA_ID=" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & " and Project_ID=" & hdfppaprojId.Value & "and Program_id=" & hdfppaprogId.Value & " and isContinuing='" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "'", CommandType.Text)

                '=-= history get prevous data before editing
                Dim hdrid As Long = CType(Me.Session("hdrid"), Long)

                For i As Integer = 0 To Session("RowCount_Existing")
                    Dim dataquarter As New DataTable
                    Dim id As String = data.Rows(i)("Item_ID")
                    dataquarter = CType(Me.Session(id), DataTable)

                    Dim balancetotal As DataTable
                    balancetotal = objDerived.GetDataTable("exec ams.PPMPcheckBalance " & data.Rows(i)("ppmp_dtl_id") & "", CommandType.Text)

                    Dim firstqty, secondqty, thirdqty, fourthqty, firstqtybal, secondqtybal, thirdqtybal, fourthqtybal As Decimal
                    firstqty = CType(dataquarter.Rows(0)("qty1"), Decimal)
                    secondqty = CType(dataquarter.Rows(0)("qty2"), Decimal)
                    thirdqty = CType(dataquarter.Rows(0)("qty3"), Decimal)
                    fourthqty = CType(dataquarter.Rows(0)("qty4"), Decimal)
                    Dim a As Decimal = CType(balancetotal.Rows(0)("thirdqtybal"), Decimal) + thirdqty
                    Dim b As Decimal = CType(balancetotal.Rows(0)("thirdqty"), Decimal)
                    Dim c As Decimal = a - b
                    firstqtybal = CType(balancetotal.Rows(0)("firstqtybal"), Decimal) + CType(firstqty, Decimal) ''- CType(balancetotal.Rows(0)("firstqty"), decimal)
                    secondqtybal = CType(balancetotal.Rows(0)("secondqtybal"), Decimal) + CType(secondqty, Decimal) ''- CType(balancetotal.Rows(0)("secondqty"), decimal)
                    thirdqtybal = CType(balancetotal.Rows(0)("thirdqtybal"), Decimal) + CType(thirdqty, Decimal) ''- CType(balancetotal.Rows(0)("thirdqty"), decimal)
                    fourthqtybal = CType(balancetotal.Rows(0)("fourthqtybal"), Decimal) + CType(fourthqty, Decimal) ''- CType(balancetotal.Rows(0)("fourthqty"), decimal)


                    firstqtybal = CType(firstqtybal, Decimal) - CType(balancetotal.Rows(0)("firstqty"), Decimal)
                    secondqtybal = CType(secondqtybal, Decimal) - CType(balancetotal.Rows(0)("secondqty"), Decimal)
                    thirdqtybal = CType(thirdqtybal, Decimal) - CType(balancetotal.Rows(0)("thirdqty"), Decimal)
                    fourthqtybal = CType(fourthqtybal, Decimal) - CType(balancetotal.Rows(0)("fourthqty"), Decimal)
                    objDerived.GetRecords("exec AMS.updateppmpdtl " & data.Rows(i)("ppmp_dtl_id") & ", " & firstqty & "," & secondqty & "," & thirdqty &
                         "," & fourthqty & "," & firstqtybal & "," & secondqtybal & "," & thirdqtybal & "," & fourthqtybal & "," & data.Rows(i)("price") & ",'" & Me.Session("@UserName").ToString & "'", CommandType.Text)

                Next

                Dim row As Integer = Session("RowCount_Existing")
                Dim CurrentRowCount As Integer = Me.Session("CurrentRowCount")
                For i As Integer = row + 1 To gvbody.Rows.Count - 1
                    If pItems.Rows(i)("Item_ID") <> 0 Then
                        Dim gv As New GridView
                        Dim id As String = data.Rows(i)("Item_ID")
                        gv.DataSource = CType(Me.Session(id.ToString), DataTable)
                        gv.DataBind()
                        dtl.ppmp_hdr_id = hdrid
                        dtl.Item_ID = data.Rows(i)("Item_ID")
                        dtl.Cost = data.Rows(i)("Price")
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

                Dim DeptHead_ID As Long = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND (isDeptHead = 'Yes')", CommandType.Text)

                'objDerived.GetRecords("UPDATE AMS.ppmp_hdr set mode_of_procurement = '" & Session("mode_of_procurement") & "', PreparedBy = '" & ddPreparedBy.SelectedItem.Value & "', ReviewedBy = '" & DeptHead_ID & "' where CYear = '" & Session("year") & "' and RC_ID ='" & Session("rc") & "' and Function_ID ='" & ddFunction.SelectedItem.Value & "' and GA_ID ='" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "' and BGA_ID ='" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "' and Program_ID ='" & hdfppaprogId.Value & "' and Project_ID = '" & hdfppaprojId.Value & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.ppmp_hdr set mode_of_procurement = 0 , PreparedBy = '" & ddPreparedBy.SelectedItem.Value & "', ReviewedBy = '" & DeptHead_ID & "' where CYear = '" & Session("year") & "' and RC_ID ='" & Session("rc") & "' and Function_ID ='" & ddFunction.SelectedItem.Value & "' and GA_ID ='" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "' and BGA_ID ='" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "' and Program_ID ='" & hdfppaprogId.Value & "' and Project_ID = '" & hdfppaprojId.Value & "'", CommandType.Text)

            End If

            '-----------------------------History For Previous PPMP 05212013---------------------------------------------------------

            'saving PPMP History ID
            hdfhdrID.Value = objDerived.GetValue("exec AMS.ppmphdrid '" & Me.ddRC.SelectedItem.Value.ToString & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)

            'saving PPMP History ID
            If pWithExisitngData = True And hdfPcanbedit.Value = True And Me.hdfAppstatus.Value = True And pInputQuantity = True Then
                Dim data2 As DataTable = pItemsDetails 'pItemsDetails
                HistHdr.PPMP_HDR_ID = hdfhdrID.Value
                HistHdr.PreparedBy = ddPreparedBy.SelectedItem.Value
                HistHdr.PPMP_date = Date.Today.ToString("MM/dd/yyyy")
                HistHdr.User_id = Me.Session("@UserName").ToString
                Dim hdrHist As Long = HistHdr.save
                Me.Session("hdrid") = hdrHist

                Try
                    For i As Integer = 0 To Me.pItemsDetails.Rows.Count - 1
                        Dim TotalQTy
                        TotalQTy = data2.Rows(i)("firstqty") + data2.Rows(i)("secondqty") + data2.Rows(i)("thirdqty") + data2.Rows(i)("fourthqty")
                        If pItemsDetails.Rows(i)("Item_ID") <> 0 And TotalQTy <> 0 Then
                            Dim gv As New GridView
                            Dim id2 As String = data2.Rows(i)("Item_ID")
                            Dim b As Integer = data2.Rows(i)("Item_ID")
                            Me.HistDtl.PPMP_HIST_HDR = hdrHist
                            Me.HistDtl.Itemcode = data2.Rows(i)("Item_ID")
                            Me.HistDtl.Cost = data2.Rows(i)("Cost")
                            HistDtl.FirstQTY = data2.Rows(i)("firstqty") 'gv.Rows(0).Cells(5).Text 'data2.Rows(i)("firstqty") 'gv.Rows(0).Cells(0).Text
                            HistDtl.SecondQTY = data2.Rows(i)("secondqty") 'CType(dataquarter.Rows(0)("qty2"), Integer) ' gv.Rows(0).Cells(6).Text 'data2.Rows(i)("secondqty") 'gv.Rows(0).Cells(2).Text
                            HistDtl.ThirdQTY = data2.Rows(i)("thirdqty") 'CType(dataquarter.Rows(0)("qty3"), Integer) 'gv.Rows(0).Cells(7).Text 'data2.Rows(i)("thirdqty") 'gv.Rows(0).Cells(4).Text
                            HistDtl.FourthQTY = data2.Rows(i)("fourthqty") 'CType(dataquarter.Rows(0)("qty4"), Integer) 'gv.Rows(0).Cells(8).Text 'data2.Rows(i)("fourthqty") 'gv.Rows(0).Cells(6).Text
                            HistDtl.save()
                        End If
                    Next
                Catch ex As Exception

                End Try
            End If

            '-----------------------------History For Previous PPMP 05212013---------------------------------------------------------


            Dim data1 As New DataTable

            data1 = objDerived.GetDataTable("exec ams.sp_ppmpsaved '" & Me.ddRC.SelectedItem.Value.ToString & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
            'If data1.Rows.Count < 20 Then
            '    data1.Merge(createdatatable1(19 - data1.Rows.Count))
            'End If
            pItems = data1
            gvbody.DataSource = pItems
            gvbody.DataBind()


            CType(gvbody.FooterRow.FindControl("lbltotal"), Label).Text = FormatNumber(data1.Compute("Sum(Total)", ""), 2)

            ddRC.Enabled = False

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            saved = True
            ddPAPS.Enabled = True

            ddAccount.Enabled = False
            btnsubmit.Enabled = False

            createdatatable2()
            gvquarters.DataSource = pTempEmpAccount_tbl2
            gvquarters.DataBind()

            CType(gvquarters.Rows(0).Cells(0).FindControl("txtqty1"), TextBox).ReadOnly = True
            CType(gvquarters.Rows(0).Cells(1).FindControl("txtqty2"), TextBox).ReadOnly = True
            CType(gvquarters.Rows(0).Cells(2).FindControl("txtqty3"), TextBox).ReadOnly = True
            CType(gvquarters.Rows(0).Cells(3).FindControl("txtqty4"), TextBox).ReadOnly = True
            btnpreview.Enabled = True
            pItems = Nothing

        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Total amount must not exceed from the allocated budget.")
        End If

        Try
            gvPPA.DataSource = objDerived.GetRecords("exec ams.APP_PPMP_Status_per_office '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & withApprovedBudget & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & True & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & Session("isSupplemental") & "','" & Session("app_id") & "'", CommandType.Text)
            gvPPA.DataBind()
            gvPPA.SelectedIndex = 1

            gvppmp.DataSource = objDerived.GetRecords("exec ams.APP_PPMP_Status_per_office '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & withApprovedBudget & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & False & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & Session("isSupplemental") & "','" & Session("app_id") & "'", CommandType.Text)
            gvppmp.DataBind()
            gvppmp.SelectedIndex = 0

            'gvConsolidated.DataSource = objDerived.GetRecords("exec AMS.APP_PPMP_Status_per_office_consolidated'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & withApprovedBudget & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
            'gvConsolidated.DataBind()
            'gvConsolidated.SelectedIndex = 2

            gvConsolidated.DataSource = objDerived.GetRecords("exec [AMS].[APP_PPMP_List_Cosolidated] '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & Session("app_id") & "'", CommandType.Text)
            gvConsolidated.DataBind()

        Catch ex As Exception

        End Try

        btnfinal.Enabled = True

        'Catch ex As Exception
        '    '    msg.UserMsgBox(ex.ToString, Me, False)
        'End Try

        RemainingBalance()

    End Sub

    Protected Sub ddAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddAccount.SelectedIndexChanged

        If lblappstatus.Text = "Executing" Then

            lnkView.Enabled = False
        Else
            lnkView.Enabled = True
        End If
        Session("GA_ID") = pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID")
        Session("BGA_ID") = pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID")
        'Try
        Dim AllotmenClassID As Integer
        '=-= Wla pang Supplemental =-=
        'pItems = objDerived.GetDataTable("exec ams.sp_ppmpsaved " & Me.ddRC.SelectedItem.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)

        '=-= with Supplemental =-=
        pItems = objDerived.GetDataTable("exec ams.sp_ppmpsaved " & Me.ddRC.SelectedItem.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)

        If pItems.Rows.Count = 0 Then
            AllotmenClassID = objDerived.GetValue("exec ams.GetAllotmentID " & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "", CommandType.Text)
            Dim PrevYear = pYear.Rows(ddyear.SelectedIndex - 1)("year") - 1
            Session("Year") = PrevYear

            Try
                hdfProjID.Value = (IIf(IsDBNull(objDerived.GetValue("select top 1 prevproj_id  from LnkdSrvrBOSS.GEOBOS.BOS.m_Project as m_Project where Project_id='" & hdfppaprojId.Value & "'  ", CommandType.Text)), 0, objDerived.GetValue("select top 1 prevproj_id  from LnkdSrvrBOSS.GEOBOS.BOS.m_Project as m_Project where Project_id='" & hdfppaprojId.Value & "'  ", CommandType.Text)))
                hdfProgID.Value = (IIf(IsDBNull(objDerived.GetValue("select top 1 Program_id  from LnkdSrvrBOSS.GEOBOS.BOS.m_Project as m_Project where Project_id='" & hdfProjID.Value & "'  ", CommandType.Text)), 0, objDerived.GetValue("select top 1 Program_id  from LnkdSrvrBOSS.GEOBOS.BOS.m_Project as m_Project where Project_id='" & hdfProjID.Value & "'  ", CommandType.Text)))
            Catch ex As Exception
                hdfProjID.Value = 0
                hdfProgID.Value = 0
            End Try

            pItems = objDerived.GetDataTable("exec ams.sp_ppmpsaved '" & Me.ddRC.SelectedItem.Value & "'," & Session("Year") & ",'" & ddFunction.SelectedItem.Value & "','" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "','" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "','" & hdfProjID.Value & "','" & hdfProgID.Value & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)

            If pItems.Rows.Count = 0 Then
                chkPrev.Visible = False
                LoadPrevPPMP = False
            Else
                chkPrev.Visible = False

            End If

            If AllotmenClassID = 3 Then
                Me.chkPrev.Text = "Load Previous AEPP"
            Else
                Me.chkPrev.Text = "Load Previous ASPP"

            End If

        Else
            chkPrev.Visible = False
            LoadPrevPPMP = False
            AllotmenClassID = objDerived.GetValue("exec ams.GetAllotmentID '" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "'", CommandType.Text)
            If AllotmenClassID = 3 Then
                Me.chkPrev.Text = "Load Previous AEPP"
            Else
                Me.chkPrev.Text = "Load Previous ASPP"
            End If

        End If
        Me.lblpromt.Visible = False
        click_ddAccount()

        'cbConstructionMaterials.Enabled = False
        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Update file maintenance for the current year.")
        'End Try
    End Sub
    Protected Sub CheckBox1_CheckedChanged3(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim pProperties As New DataTable
        'pProperties = objDerived.GetDataTable("Select * from dbo.View_ItemsForRepair where GA_ID ='" & Session("rGA_ID") & "'", CommandType.Text)


        'Dim cb As CheckBox = TryCast(sender, CheckBox)
        'Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)

        'If cb.Checked = True Then
        '    ' pProperties.Rows()
        'Else
        '    pProperties.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(0).Text)("isChecked") = False
        'End If


        'ModalPopupExtender2.Show()
    End Sub
    Public Sub click_ddAccount()
        'Try
        Dim statusID
        Dim cyear As String = "CY" & pYear.Rows(ddyear.SelectedIndex - 1)("year")

        tempPcanedit = objDerived.GetValue("select ams.func_APP_status_Per_GAID(" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & ")", CommandType.Text)
        statusID = objDerived.GetValue("select top 1 status from ams.app where year = " & pYear.Rows(ddyear.SelectedIndex - 1)("year") & " and iscontinuing= '" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "' and isSupplemental ='" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
        'Check if executing
        Try
            If IsEdited = False Then
                If statusID = 2 Then
                    AppStatus = True
                Else
                    AppStatus = False
                End If
            Else
                tempPcanedit = True
            End If

        Catch ex As Exception
            If statusID = 2 Then
                AppStatus = True
            Else
                AppStatus = False
            End If

        End Try

        hdfPcanbedit.Value = tempPcanedit
        Me.hdfAppstatus.Value = AppStatus
        'Check if executing
        If tempPcanedit = True And statusID = 2 Then
            pCanEdit = True
            Me.Session("Edit") = True
            Me.Session("Locked") = False
        ElseIf (tempPcanedit = True Or tempPcanedit = False) And statusID = 1 Then
            pCanEdit = True
            Me.Session("Edit") = True
            Me.Session("Locked") = False
        Else
            pCanEdit = False
            Me.Session("Edit") = False
            Me.Session("Locked") = True
            chkPrev.Visible = False
        End If

        saved = False
        Dim b As DataTable = pAccounts
        Session("GA_ID") = pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID")
        Dim c As Integer = ddAccount.SelectedIndex
        Session("BGA_ID") = pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID")

        withApprovedBudget = objDerived.GetValue("select AMS.func_budget_status('" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "')", CommandType.Text)
        AllotmentId = objDerived.GetValue("exec ams.GetAllotmentID " & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "", CommandType.Text)
        'txtbudget.Text = FormatNumber(objDerived.GetValue("SELECT AMS.AllocatedBudgets ('" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "','" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "', '" & withApprovedBudget & "','" & hdfppaprojId.Value & "','" & hdfppaprogId.Value & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "','" & AllotmentId & "')", CommandType.Text), 2)

        Dim ApprovedBudget As Decimal
        ApprovedBudget = objDerived.GetValue("EXEC [AMS].[sp_Total_ApprovedBudget] '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "','" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "','" & hdfppaprojId.Value & "','" & hdfppaprogId.Value & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "'", CommandType.Text)
        txtbudget.Text = FormatNumber(ApprovedBudget, 2)

        Dim isConstructionMaterial As Boolean

        Dim code As Integer
        code = pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID")
        isConstructionMaterial = objDerived.GetValue("select ams.isConstructionMaterials(" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & ")", CommandType.Text)

        If Me.ddRC.SelectedItem.Value = 18 And ddFunction.SelectedItem.Value = 86 Or isConstructionMaterial = True Then ''Or pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") = 831 Then
            pListitem = objDerived.GetDataTable("EXEC [AMS].[sp_goods_per_account_withPrice] " & 0 & "," & 0 & "," & cyear & "", CommandType.Text)
        ElseIf Me.ddRC.SelectedItem.Value = 1 And ddFunction.SelectedItem.Value = 22 Or isConstructionMaterial = True Then
            pListitem = objDerived.GetDataTable("EXEC [AMS].[sp_goods_per_account_withPrice] " & 0 & "," & 0 & "," & cyear & "", CommandType.Text)
        Else
            Dim G As Integer = pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID")
            Dim BG As Integer = pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID")


            pListitem = objDerived.GetDataTable("EXEC [AMS].[sp_goods_per_account_withPrice] '" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "','" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "','" & cyear & "'", CommandType.Text)
            'gvitems.DataSource = pListitem
            'gvitems.DataBind()
        End If
        Dim issubmited1
        issubmited1 = IIf(IsDBNull(objDerived.GetValue("select top 1 isnull(isfinal,0) from ams.ppmp_hdr  where cyear=" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & " and rc_ID= " & ddRC.SelectedItem.Value & " and function_id=" & ddFunction.SelectedItem.Value & "and Ga_id=" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & " ", CommandType.Text)), 0, objDerived.GetValue("select top 1 isnull(isfinal,0)  from ams.ppmp_hdr  where cyear=" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & " and rc_ID= " & ddRC.SelectedItem.Value & " and function_id=" & ddFunction.SelectedItem.Value & "and Ga_id=" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & " ", CommandType.Text))

        Dim issubmited As Boolean
        If issubmited1 = " " Or issubmited1 = False Then
            issubmited = False
        Else
            issubmited = True
        End If

        Dim isPPA As Boolean
        Try
            If Me.hdfppaprojId.Value <> 0 Then
                isPPA = True
                Session("isPPA") = True
            Else
                isPPA = False
                Session("isPPA") = False
            End If

        Catch ex As Exception
            isPPA = False
        End Try

        Dim appstatusID
        appstatusID = objDerived.GetValue("select top 1 status from ams.app where year = " & pYear.Rows(ddyear.SelectedIndex - 1)("year") & " and iscontinuing= '" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "'", CommandType.Text)
        If issubmited = True And txtbudget.Text <> "0.00" And tempPcanedit = False Then
            lnkView.Enabled = False
            btnsubmit.Enabled = False
            Me.btnfinal.Enabled = False
        ElseIf issubmited = True And txtbudget.Text = "0.00" And tempPcanedit = False Then
            lnkView.Enabled = False
            btnsubmit.Enabled = False
            Me.btnfinal.Enabled = False
            'And isforRevision = True
        ElseIf issubmited = True And CDec(txtbudget.Text) <> "0.00" And tempPcanedit = True Then
            lnkView.Enabled = True
            btnsubmit.Enabled = True
            Me.btnfinal.Enabled = True
            'And isforRevision = True 
        ElseIf ISSubmitted = True And CDec(txtAvailableBudget.Text) > 0 And tempPcanedit = True Then
            lnkView.Enabled = True
            Me.btnfinal.Enabled = True
            btnsubmit.Enabled = True

        Else
            lnkView.Enabled = True
            Me.btnfinal.Enabled = True
            btnsubmit.Enabled = True
        End If

        If isPPA = True And withApprovedBudget = False And txtbudget.Text = "0.00" Then
            lnkView.Enabled = False
            btnsubmit.Enabled = False
            Me.btnfinal.Enabled = False
        ElseIf isPPA = True And withApprovedBudget = True And txtbudget.Text = "0.00" Then
            lnkView.Enabled = False
            btnsubmit.Enabled = False
            Me.btnfinal.Enabled = False
        ElseIf isPPA = True And withApprovedBudget = True And txtbudget.Text <> "0.00" Then
            lnkView.Enabled = True
            Me.btnfinal.Enabled = True
            btnsubmit.Enabled = True
        End If

        Me.Session("Issubmited") = issubmited
        If pCanEdit = False Then
            lnkView.Enabled = False
            btnsubmit.Enabled = False
        Else
            lnkView.Enabled = True
        End If
        If LoadPrevPPMP = True Then
            Dim PreyearLoad
            PreyearLoad = pYear.Rows(ddyear.SelectedIndex - 1)("year") - 1
            LoadPrevPPMP = True

        Else
            pItems = objDerived.GetDataTable("exec ams.sp_ppmpsaved " & Me.ddRC.SelectedItem.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & Me.hdfppaprojId.Value & "," & Me.hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
            LoadPrevPPMP = False
        End If

        If pItems.Rows.Count >= 1 Then
            If LoadPrevPPMP = True Then
                Dim PreyearLoad
                PreyearLoad = pYear.Rows(ddyear.SelectedIndex - 1)("year") - 1
                data1 = objDerived.GetDataTable("exec ams.sp_ppmpsaved_LoadPrevious " & Me.ddRC.SelectedItem.Value & ",'" & PreyearLoad & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfProjID.Value & "," & hdfProgID.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
                pItems = data1
                gvbody.DataSource = data1
                gvbody.DataBind()
                CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)

                For i As Integer = 0 To gvbody.Rows.Count - 1
                    Try
                        Dim id As String = data1.Rows(i)("Item_ID")
                        Me.Session(id) = pTempEmpAccount_tbl2
                        pItemsDetails = Me.Session(id)
                    Catch ex As Exception

                    End Try

                Next
                If Me.ddRC.SelectedItem.Value = 18 And ddFunction.SelectedItem.Value = 86 Or isConstructionMaterial = True Then
                    pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account_withPrice " & 0 & "," & 0 & "," & cyear & "", CommandType.Text)

                ElseIf Me.ddRC.SelectedItem.Value = 1 And ddFunction.SelectedItem.Value = 22 Then
                    pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account_less_existing_data_infra  '" & Me.ddRC.SelectedItem.Value.ToString & "','" & PreyearLoad & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfProjID.Value & "," & hdfProgID.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
                Else
                    'If cbConstructionMaterials.Checked = True Then
                    '    pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account_less_existing_data  '" & Me.ddRC.SelectedItem.Value.ToString & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & ",1033,0," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "," & cyear & "", CommandType.Text)
                    'Else
                    '    pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account_less_existing_data  '" & Me.ddRC.SelectedItem.Value.ToString & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "," & cyear & "", CommandType.Text)
                    'End If

                    pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account_less_existing_data  '" & Me.ddRC.SelectedItem.Value.ToString & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "," & cyear & "", CommandType.Text)

                End If
                pWithExisitngData = False
                Me.Session("hdrid") = objDerived.GetValue("exec AMS.ppmphdrid '" & Me.ddRC.SelectedItem.Value.ToString & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfProjID.Value & "," & hdfProgID.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
                btnpreview.Enabled = True

            Else
                Session("RowCount_Existing") = pItems.Rows.Count - 1
                gvbody.DataSource = pItems
                gvbody.DataBind()

                CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)

                For i As Integer = 0 To gvbody.Rows.Count - 1
                    Dim id As String = pItems.Rows(i)("Item_ID")
                    Me.Session(id) = objDerived.GetDataTable("exec AMS.loadppmpitemdetail " & pItems.Rows(i)("ppmp_dtl_id") & "", CommandType.Text)

                    If pCanEdit = False Then
                        CType(gvbody.Rows(i).Cells(7).FindControl("ImageButton4"), ImageButton).Enabled = False
                    End If
                Next

                If Me.ddRC.SelectedItem.Value = 18 And ddFunction.SelectedItem.Value = 86 Or isConstructionMaterial = True Then
                    pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account " & 0 & "," & 0 & "," & cyear & "", CommandType.Text)
                ElseIf Me.ddRC.SelectedItem.Value = 1 And ddFunction.SelectedItem.Value = 22 Then
                    pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account_less_existing_data_infra  '" & Me.ddRC.SelectedItem.Value.ToString & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
                Else
                    'If cbConstructionMaterials.Checked = True Then
                    '    pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account_less_existing_data  '" & Me.ddRC.SelectedItem.Value.ToString & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & ",1033,0," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "," & cyear & "", CommandType.Text)
                    'Else
                    '    pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account_less_existing_data  '" & Me.ddRC.SelectedItem.Value.ToString & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "," & cyear & "", CommandType.Text)
                    'End If

                    pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account_less_existing_data  '" & Me.ddRC.SelectedItem.Value.ToString & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "," & cyear & "", CommandType.Text)

                End If

                pWithExisitngData = True
                btnpreview.Enabled = True

            End If

        Else
            gvbody.DataSource = createdatatable1(19)
            gvbody.DataBind()
            pWithExisitngData = False

        End If
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.DataSource = pListitem
        gvitems.DataBind()
        If gvitems.DataSource Is Nothing Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No items")
        End If
        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False

        Dim zx As Integer = pListitem.Rows.Count

        gvbody.SelectedIndex = -1
        txtAvailableBudget.ForeColor = Drawing.Color.Black
        createdatatable2()
        gvquarters.DataSource = pTempEmpAccount_tbl2
        gvquarters.DataBind()

        If pWithExisitngData = True Then
            PPMPSaved = CDec(CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text)
        Else
            PPMPSaved = 0
        End If

        txtAvailableBudget.Text = FormatNumber(txtbudget.Text - PPMPSaved, 2)
        If CDec(Me.txtbudget.Text) = 0 Then
            Me.lblpromt.Visible = True
        Else
            Me.lblpromt.Visible = False
        End If

        'Catch ex As Exception
        'End Try
        savestatus = False

        pInputQuantity = False
        'lnkView.Enabled = True
        If lblappstatus.text = "Executing" Then
            lnkView.enabled = "false"
        Else
            lnkView.enabled = "true"
        End If
        RemainingBalance()
    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddFunction.SelectedIndexChanged
        '=-= Load Employee from Selected Department and Function for PreparedBy 
        ddPreparedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
        ddPreparedBy.DataTextField = ("full_name")
        ddPreparedBy.DataValueField = ("empid")
        ddPreparedBy.DataBind()
        ddPreparedBy.Items.Insert(0, "Select")


        Dim Head As Long = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND isDeptHead = 'Yes'", CommandType.Text)
        If Head = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Assign department head for the selected department / function.")
            Exit Sub
        End If

        ddPAPS.Items.Clear()
        Me.DropDownList1.Enabled = True
        If ddFunction.SelectedItem.Text = "Select" Then

            pAccounts = Nothing
            ddPAPS.DataSource = pAccounts
            ddPAPS.DataBind()
            ddPAPS.Items.Add("Select")
        Else
            ddPAPS.Enabled = True
            PAPS = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project " & Me.ddRC.SelectedItem.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
            '[AMS].[sp_PPA]
            'PAPS = objDerived.GetDataTable("EXEC [AMS].[sp_PPA] '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & Me.ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "'", CommandType.Text)

            ddPAPS.DataSource = PAPS
            ddPAPS.DataTextField = ("description")
            ddPAPS.DataValueField = ("description")
            ddPAPS.DataBind()
            ddPAPS.Items.Insert(0, "Select")

            pAccounts = Nothing

            withApprovedBudget = objDerived.GetValue("select AMS.func_budget_status('" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "')", CommandType.Text)
            'withApprovedBudget = objDerived.GetValue("select AMS.func_budget_status('" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "')", CommandType.Text)

            gvPPA.DataSource = objDerived.GetRecords("exec ams.APP_PPMP_Status_per_office '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & withApprovedBudget & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & True & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & Session("app_id") & "'", CommandType.Text)
            gvPPA.DataBind()

            gvppmp.DataSource = objDerived.GetRecords("exec ams.APP_PPMP_Status_per_office '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & withApprovedBudget & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & False & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & Session("app_id") & "'", CommandType.Text)
            gvppmp.DataBind()

            gvConsolidated.DataSource = objDerived.GetRecords("exec [AMS].[APP_PPMP_List_Cosolidated] '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & Session("app_id") & "'", CommandType.Text)
            gvConsolidated.DataBind()

            lblappstatus.Text = pYear.Rows(ddyear.SelectedIndex - 1)("description")
            Session("year") = pYear.Rows(ddyear.SelectedIndex - 1)("year")

            ddyear.Enabled = False
            'ddFunction.Enabled = False

        End If
        Session("Function_ID") = ddFunction.SelectedItem.Value

    End Sub
    Protected Sub ddyear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddyear.SelectedIndexChanged

        Try
            ddRC.Enabled = True
            pRC = objDerived.GetDataTable("exec dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)
            ddRC.DataSource = CType(pRC, DataTable)
            ddRC.DataTextField = ("rc_name")
            ddRC.DataValueField = ("rc_id")
            ddRC.DataBind()

            ddFunction.Enabled = False
            Session("isContinuing") = pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing")
            Session("isSupplemental") = pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental")
            Session("app_id") = pYear.Rows(ddyear.SelectedIndex - 1)("app_id")
        Catch ex As Exception
            pCanEdit = tempPcanedit
            Session("year") = pYear.Rows(ddyear.SelectedIndex - 1)("year")
            Session("isContinuing") = pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing")
            Session("isSupplemental") = pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental")
            Session("app_id") = pYear.Rows(ddyear.SelectedIndex - 1)("app_id")
            ddyear.Enabled = False
        End Try
    End Sub
    Protected Sub ddPAPS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddPAPS.SelectedIndexChanged
        If Me.ddPAPS.SelectedItem.ToString <> "Select" Then
            Me.DropDownList1.Enabled = True
        Else
            Me.DropDownList1.Enabled = False
        End If

        Try
            ISSubmitted = objDerived.GetValue("select AMS.Issubmited(" & ddRC.SelectedItem.Value & ", " & ddFunction.SelectedItem.Value & ", " & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & ")", CommandType.Text)
            If ISSubmitted = False And Me.ddPAPS.SelectedValue = "Office Operational Expense" Then
                ISSubmitted = True
            End If

            If ISSubmitted = True Then
                ddPAPS.Enabled = True
                Dim a As DataTable = PAPS
                'withApprovedBudget = objDerived.GetValue("select AMS.func_budget_status('" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "')", CommandType.Text)
                withApprovedBudget = objDerived.GetValue("select AMS.func_budget_status('" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "')", CommandType.Text)

                pAccounts = Nothing
                ddAccount.Items.Clear()
                ddAccount.Items.Add("Select")


                Dim c As Integer = ddPAPS.SelectedIndex
                Session("Project_ID") = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
                Session("Program_id") = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")

            Else
                msg.UserMsgBox("Please submit first your PPA to proceed with your PPMP", Me, False)
            End If
        Catch ex As Exception

        End Try

        ' if selected is OOE/PPA Table Under willShow OOE/PPA
        ' Dim PPA
        ' PPA = pAccounts.Rows(ddAccount.SelectedIndex)("GA_Title")
        Try
            If Me.ddPAPS.SelectedValue = "Office Operational Expense" Then
                TabContainer1.ActiveTabIndex = 0
            Else
                TabContainer1.ActiveTabIndex = 1
            End If


        Catch ex As Exception

        End Try
        ' if selected is OOE/PPA Table Under willShow OOE/PPA

    End Sub

    Protected Sub CheckBox1_CheckedChanged2(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            gvitems.Columns(4).Visible = True
            Dim cb As CheckBox = TryCast(sender, CheckBox)
            Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)

            If cb.Checked = True Then
                pListitem.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text)("isChecked") = True
            Else
                pListitem.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text)("isChecked") = False
            End If



            gvitems.Columns(4).Visible = False
            ModalPopupExtender3.Show()

        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
    '    Try
    '        Me.gvitems.Columns(3).Visible = True
    '        gvitems.Columns(4).Visible = True
    '        SearchBut.Text = ""
    '        Dim myview As DataView
    '        myview = pListitem.DefaultView
    '        myview.RowFilter = "Item_Desc like '" & SearchBut.Text & "%' and isUsed = false"
    '        gvitems.DataSource = myview

    '        Me.gvitems.DataBind()
    '        Me.gvitems.Columns(3).Visible = False
    '        gvitems.Columns(4).Visible = False
    '        gvitems.SelectedIndex = -1
    '        gvitems.PageIndex = 0
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Protected Sub gvppmp_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvppmp.PageIndexChanging
        gvppmp.SelectedIndex = 0
        gvppmp.DataSource = objDerived.GetRecords("exec ams.APP_PPMP_Status_per_office '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & withApprovedBudget & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & False & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & Session("app_id") & "'", CommandType.Text)
        gvppmp.PageIndex = e.NewPageIndex
        gvppmp.DataBind()

    End Sub

    Protected Sub gvppmp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvppmp.SelectedIndexChanged
        savestatus = False
        isedit = True

        Try
            Session("ClickConsolidatedView") = 1
            Session.Add("ClickConsolidatedView", ClickConsolidatedView)
            btnpreview.Enabled = True
            TabContainer1.ActiveTabIndex = 0
            If Me.chkOOE.Checked = True Then
                ddPAPS.SelectedItem.Text = "Office Operational Expense"

            End If

            '=-= CANCEL MUNA 07102015
            'Dim mode As String
            'mode = objDerived.GetValue("SELECT mode_of_procurement FROM AMS.ppmp_hdr where CYear = '" & Session("year") & "' and RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_ID = '" & ddFunction.SelectedItem.Value & "' and GA_ID ='" & gvppmp.SelectedDataKey("GA_ID") & "' and BGA_ID ='" & gvppmp.SelectedDataKey("BGA_ID") & "'", CommandType.Text)

            'If mode = "" Then
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set mode of procurement.")
            '    ddmode_of_procurement.SelectedIndex = 0
            'Else
            '    ddmode_of_procurement.SelectedValue = mode
            '    Session("mode_of_procurement") = mode
            'End If

            ddmode_of_procurement.SelectedIndex = 0

            hdfppaprojId.Value = 0
            hdfppaprogId.Value = 0
            ddPAPS.Enabled = False
            pAccounts = Nothing
            ddAccount.Items.Clear()
            ddAccount.Items.Add("Select")

            pAccounts = objDerived.GetDataTable("exec ams.sp_GA_ID_from_LBPF_3 '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & withApprovedBudget & "'," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
            ddAccount.DataSource = pAccounts
            ddAccount.DataTextField = ("GA_Title")
            ddAccount.DataValueField = ("GA_CODE2")
            ddAccount.DataBind()
            ddAccount.Items.Insert(0, "Select")

            ddAccount.Enabled = True
            saved = False
            ddAccount.Enabled = True

            ddAccount.SelectedValue = gvppmp.SelectedDataKey(0)
            Session("Project_ID") = hdfppaprojId.Value
            Session("Program_id") = hdfppaprogId.Value
            Session("isContinuing") = pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing")

            click_ddAccount()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub gvPPA_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvPPA.PageIndexChanging
        gvPPA.SelectedIndex = 1

        gvPPA.DataSource = objDerived.GetRecords("exec ams.APP_PPMP_Status_per_office '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & withApprovedBudget & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & True & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & Session("app_id") & "'", CommandType.Text)
        gvPPA.PageIndex = e.NewPageIndex
        gvPPA.DataBind()

    End Sub
    Protected Sub gvPPA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvPPA.SelectedIndexChanged
        savestatus = False
        isedit = True
        Try

            TabContainer1.ActiveTabIndex = 1
            Dim result

            result = gvPPA.SelectedDataKey(2)
            ddPAPS.SelectedValue = gvPPA.SelectedDataKey(2)
            ddPAPS.Enabled = False
            Session("ClickConsolidatedView") = 1
            Session.Add("ClickConsolidatedView", ClickConsolidatedView)
            pAccounts = Nothing

            ddAccount.Items.Clear()
            ddAccount.Items.Add("Select")

            pAccounts = objDerived.GetDataTable("exec  AMS.sp_GA_ID_from_LBPF_3 '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & withApprovedBudget & "'," & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "," & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_ID") & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
            ddAccount.DataSource = pAccounts
            ddAccount.DataTextField = ("GA_Title")
            ddAccount.DataValueField = ("GA_CODE2")
            ddAccount.DataBind()
            ddAccount.Items.Insert(0, "Select")

            ddAccount.Enabled = True
            saved = False
            ddAccount.Enabled = True

            ddAccount.SelectedValue = gvPPA.SelectedDataKey(0)
            hdfppaprojId.Value = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
            hdfppaprogId.Value = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
            Session("isContinuing") = pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing")

            click_ddAccount()

            Session("Program_id") = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") 'gvPPA.SelectedDataKey("Program_id")
            Session("Project_ID") = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") 'gvPPA.SelectedDataKey("Project_ID")

            'Dim mode As String
            'mode = objDerived.GetValue("SELECT mode_of_procurement FROM AMS.ppmp_hdr where CYear = '" & Session("year") & "' and RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_ID = '" & ddFunction.SelectedItem.Value & "' and GA_ID ='" & gvPPA.SelectedDataKey("GA_ID") & "' and BGA_ID ='" & gvPPA.SelectedDataKey("BGA_ID") & "' and Project_ID ='" & gvPPA.SelectedDataKey("Project_ID") & "' and Program_ID ='" & gvPPA.SelectedDataKey("Program_ID") & "'", CommandType.Text)

            'If mode = "" Then
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set mode of procurement.")
            '    ddmode_of_procurement.SelectedIndex = 0
            'Else
            '    ddmode_of_procurement.SelectedValue = mode
            '    Session("mode_of_procurement") = mode
            'End If

            ddmode_of_procurement.SelectedIndex = 0

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnPrintOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintOK.Click

    End Sub
    Protected Sub gvConsolidated_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvConsolidated.PageIndexChanging
        gvConsolidated.DataSource = objDerived.GetRecords("exec [AMS].[APP_PPMP_List_Cosolidated] '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & Session("app_id") & "'", CommandType.Text)
        gvConsolidated.PageIndex = e.NewPageIndex
        gvConsolidated.DataBind()

    End Sub

    Protected Sub gvConsolidated_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConsolidated.SelectedIndexChanged
        Me.btnpreview.Enabled = True
        Try
            TabContainer1.ActiveTabIndex = 2
            ddPAPS.Enabled = False

            Session("ClickConsolidatedView") = 2
            Session.Add("ClickConsolidatedView", ClickConsolidatedView)
            pAccounts = Nothing
            ddAccount.Items.Clear()
            ddAccount.Items.Add("Select")

            pAccounts = objDerived.GetDataTable("Select * from LnkdSrvrBOSS.GEOBOS.BOS.m_GenAccnt where GA_Code ='" & gvConsolidated.SelectedDataKey(0) & "' and GA_ID ='" & gvConsolidated.SelectedDataKey("GA_ID") & "'", CommandType.Text)
            ddAccount.DataSource = pAccounts
            ddAccount.DataTextField = ("GA_Title")
            ddAccount.DataValueField = ("GA_CODE")
            ddAccount.DataBind()
            ddAccount.Items.Insert(0, "Select")

            DropDownList1.Enabled = False
            ddAccount.Enabled = False
            saved = False

            ddAccount.SelectedValue = gvConsolidated.SelectedDataKey(0)
            Session("isContinuing") = pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing")
            Session("GA_ID") = gvConsolidated.SelectedDataKey("GA_ID")

            Dim consolidated As DataTable
            consolidated = objDerived.GetDataTable("exec ams.sp_ppmpsaved_consolidated '" & ddRC.SelectedItem.Value & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & ddFunction.SelectedItem.Value & "','" & gvConsolidated.SelectedDataKey("GA_ID") & "','" & gvConsolidated.SelectedDataKey("BGA_ID") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
            If consolidated.Rows.Count < 20 Then
                consolidated.Merge(createdatatable3(19 - consolidated.Rows.Count))
            End If
            gvbody.DataSource = consolidated
            gvbody.DataBind()

            CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(consolidated.Compute("sum(total)", ""), 2)

            Dim mode As String
            mode = objDerived.GetValue("SELECT mode_of_procurement FROM AMS.ppmp_hdr where CYear = '" & Session("year") & "' and RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_ID = '" & ddFunction.SelectedItem.Value & "' and GA_ID ='" & gvConsolidated.SelectedDataKey("GA_ID") & "' and BGA_ID ='" & gvConsolidated.SelectedDataKey("BGA_ID") & "'", CommandType.Text)

            If mode = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set mode of procurement.")
                ddmode_of_procurement.SelectedIndex = 0
            Else
                ddmode_of_procurement.SelectedValue = mode
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub lnkView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkView.Click
        ModalPopupExtender3.Show()
    End Sub

    Protected Sub txtAvailableBudget_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAvailableBudget.TextChanged

    End Sub

    Protected Sub btnfinal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfinal.Click
        If CDec(txtAvailableBudget.Text) > 0 Or CDec(txtAvailableBudget.Text) = 0 Then
            If saved = True Then
                Try
                    objDerived.GetRecords("UPDATE ams.ppmp_hdr set isFinal = 1  WHERE CYear = '" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "' AND RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_id = '" & ddFunction.SelectedItem.Value & "' and GA_ID = '" & Me.Session("GA_ID") & "' and BGA_ID = '" & Me.Session("BGA_ID") & "'", CommandType.Text)
                    btnfinal.Enabled = False
                    Me.btnsubmit.Enabled = False
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PPMP has been successfully submitted.")
                Catch ex As Exception
                End Try
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Save the PPMP first before submitting.")
            End If
        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Total amount must not exceed from the allocated budget.")
        End If

    End Sub

    Protected Sub chkPrev_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPrev.CheckedChanged

        If Me.chkPrev.Checked = True Then
            chkPrev.Visible = False
            LoadPrevPPMP = True

            If ddPAPS.SelectedItem.Text = "Select" Then
                hdfProjID.Value = 0
                hdfProgID.Value = 0
            Else
                hdfProjID.Value = Session("Project_ID")
                hdfProgID.Value = Session("Program_id")
            End If

            Session("LoadPrevPPMP") = True
            Dim PrevYear = pYear.Rows(ddyear.SelectedIndex - 1)("year") - 1

            pItems = objDerived.GetDataTable("exec ams.sp_ppmpsaved_LoadPrevious " & Me.ddRC.SelectedItem.Value & ",'" & PrevYear & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfProjID.Value & "," & hdfProgID.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
            Me.gvbody.DataSource = pItems
            Me.gvbody.DataBind()

        Else
            chkPrev.Visible = False
            LoadPrevPPMP = False
            Session("LoadPrevPPMP") = False

        End If

        click_ddAccount()
        'lessLoadPrevASPP()


    End Sub
    Public Sub lessLoadPrevASPP()
        Try
            Dim sumObject As Integer
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            Dim dt As New DataTable
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
            If pItems.Rows.Count <= 0 Then
                dt.Columns.Add("id", GetType(Integer))
                dt.Columns.Add("Item_Desc", GetType(String))
                dt.Columns.Add("Description", GetType(String))
                dt.Columns.Add("qty", GetType(Integer))
                dt.Columns.Add("price", GetType(Decimal))
                dt.Columns.Add("total", GetType(Decimal))
                dt.Columns.Add("Item_ID", GetType(Integer))
                dt.Columns.Add("ppmp_dtl_id", GetType(Long))
                For i As Integer = 0 To Me.pListitem.Rows.Count - 1


                    If pListitem.Rows(i)("isChecked") = True Then
                        Dim cyear As String = "CY" & ddyear.SelectedValue
                        dr = dt.NewRow
                        dr("id") = 1
                        dr("Item_Desc") = pListitem.Rows(i)("Item_Desc") ''gvitems.Rows(i).Cells(1).Text
                        dr("Description") = pListitem.Rows(i)("Description") ''gvitems.Rows(i).Cells(2).Text
                        dr("qty") = 0
                        dr("price") = FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & pListitem.Rows(i)("Item_ID") & "','" & cyear & "'", CommandType.Text), 2)
                        dr("total") = "0.00"
                        dr("Item_ID") = pListitem.Rows(i)("Item_ID")
                        dr("ppmp_dtl_id") = 0
                        dt.Rows.Add(dr)
                        pListitem.Rows(i)("isUsed") = True
                        pListitem.Rows(i)("isChecked") = False
                        Me.Session(CType(pListitem.Rows(i)("Item_ID"), String)) = dtQ
                    End If
                Next
                pItems = dt
                sumObject = pItems.Compute("count(id)", "id=1")
                If sumObject <= 19 Then
                    pItems.Merge(createdatatable1(19 - sumObject))
                End If
            Else
                sumObject = pItems.Compute("count(id)", "id=1")
                For i As Integer = 0 To Me.pListitem.Rows.Count - 1
                    '  cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If pListitem.Rows(i)("isChecked") = True Then
                        Dim cyear As String = "CY" & ddyear.SelectedValue
                        dt = pItems
                        dr = dt.NewRow
                        dr("id") = 1
                        dr("Item_Desc") = pListitem.Rows(i)("Item_Desc") ''gvitems.Rows(i).Cells(1).Text
                        dr("Description") = pListitem.Rows(i)("Description") ''gvitems.Rows(i).Cells(2).Text
                        dr("qty") = 0
                        dr("price") = FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & pListitem.Rows(i)("Item_ID") & "','" & cyear & "' ", CommandType.Text), 2)
                        dr("total") = "0.00"
                        dr("Item_ID") = pListitem.Rows(i)("Item_ID")
                        dr("ppmp_dtl_id") = 0
                        dt.Rows.Add(dr)
                        pItems = dt
                        pListitem.Rows(i)("isUsed") = True
                        pListitem.Rows(i)("isChecked") = False
                        Me.Session(CType(pListitem.Rows(i)("Item_ID"), String)) = dtQ
                    End If
                Next
                If sumObject <= 19 Then
                    For i As Integer = 0 To 20
                        If sumObject + i < 20 Then
                            pItems.Rows(19 - i).Delete()
                        Else
                            Exit For
                        End If
                    Next
                    'sumObject = 0
                    sumObject = pItems.Compute("count(id)", "id=1")
                    Me.Session("CurrentRowCount") = sumObject
                    pItems.Merge(createdatatable1(19 - sumObject))
                End If
            End If
            gvbody.DataSource = pItems
            gvbody.DataBind()
            Dim data As DataTable
            data = pListitem
            'For i As Integer///*/*---*-* = 0 To Me.pListitem.Rows.Count - 1
            '    ' cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            '    If pListitem.Rows(i)("isUsed") = True Then
            '        data.Rows(Me.gvitems.Rows(i).Cells(4).Text).Delete()
            '    End If
            'Next
            '  pListitem = data
            Dim myview As DataView
            myview = pListitem.DefaultView
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
            Me.gvquarters.DataSource = dtQ
            Me.gvquarters.DataBind()
            gvbody.SelectedIndex = -1
            ddAccount.Enabled = False
            btnsubmit.Enabled = True
        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim GvBodyTotal As Decimal
        GvBodyTotal = FormatNumber(pItems.Compute("sum(total)", ""), 2)
        CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = GvBodyTotal
        pLbtn = "Recall"

    End Sub

    Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        pLbtn = "Delete"
    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim x As String = DropDownList1.SelectedValue.ToString
        Try
            Try
                ISSubmitted = objDerived.GetValue("select AMS.Issubmited(" & ddRC.SelectedItem.Value & ", " & ddFunction.SelectedItem.Value & ", " & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & ")", CommandType.Text)
            Catch ex As Exception
                ISSubmitted = False
            End Try


            If ISSubmitted = True Or Me.chkOOE.Checked = True Or ddPAPS.SelectedValue.ToString = "Select" Then

                Dim a As DataTable = PAPS
                'withApprovedBudget = objDerived.GetValue("select AMS.func_budget_status('" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "')", CommandType.Text)
                withApprovedBudget = objDerived.GetValue("select AMS.func_budget_status('" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "','" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "')", CommandType.Text)

                pAccounts = Nothing
                ddAccount.Items.Clear()
                ddAccount.Items.Add("Select")

                If Me.chkOOE.Checked = True Then
                    pAccounts = objDerived.GetDataTable("exec  AMS.sp_GA_ID_from_LBPF_3_Per_Allotment  " & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "," & ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & withApprovedBudget & ",0,0," & Me.DropDownList1.SelectedValue.ToString & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                    hdfppaprojId.Value = 0
                    hdfppaprogId.Value = 0
                    'ddAccount.Enabled = True

                Else '=-= PPA

                    If DropDownList1.SelectedItem.Value = 2 Then 'MOOE
                        Dim MMOE As Decimal
                        MMOE = objDerived.GetValue("Select MOOE from  dbo.view_PPA_Budget where Program_id ='" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "' and Project_id ='" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "' and RC_ID ='" & ddRC.SelectedItem.Value & "' and Function_ID ='" & ddFunction.SelectedItem.Value & "' ", CommandType.Text)
                        If MMOE = 0 Then
                            'ddAccount.Enabled = False
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please submit first your PPA to proceed with your PPMP.")
                        Else
                            pAccounts = objDerived.GetDataTable("exec  AMS.sp_GA_ID_from_LBPF_3_Per_Allotment  " & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "," & ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & withApprovedBudget & "," & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "," & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_ID") & "," & Me.DropDownList1.SelectedValue.ToString & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                            Dim c As Integer = ddPAPS.SelectedIndex
                            hdfppaprojId.Value = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
                            hdfppaprogId.Value = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
                            ddAccount.Enabled = True

                            txtbudget.Text = FormatNumber(CType(MMOE.ToString, Decimal), 2)
                            txtAvailableBudget.Text = FormatNumber(txtbudget.Text - PPMPSaved, 2)
                        End If

                    ElseIf DropDownList1.SelectedItem.Value = 3 Then 'Capital Outlay
                        Dim CO As Decimal
                        CO = objDerived.GetValue("Select CO from  dbo.view_PPA_Budget where Program_id ='" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "' and Project_ID ='" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "' and RC_ID ='" & ddRC.SelectedItem.Value & "' and Function_ID ='" & ddFunction.SelectedItem.Value & "' ", CommandType.Text)
                        If CO = 0 Then
                            'ddAccount.Enabled = False
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please submit first your PPA to proceed with your PPMP.")
                        Else
                            pAccounts = objDerived.GetDataTable("exec AMS.sp_GA_ID_from_LBPF_3_Per_Allotment  " _
                                                                & pYear.Rows(ddyear.SelectedIndex - 1)("year") _
                                                                & "," & ddRC.SelectedItem.Value _
                                                                & "," & ddFunction.SelectedItem.Value _
                                                                & "," & withApprovedBudget & "," _
                                                                & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "," _
                                                                & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_ID") & "," _
                                                                & Me.DropDownList1.SelectedValue.ToString & "," _
                                                                & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" _
                                                                & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                            Dim c As Integer = ddPAPS.SelectedIndex
                            hdfppaprojId.Value = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
                            hdfppaprogId.Value = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
                            ddAccount.Enabled = True

                            txtbudget.Text = FormatNumber(CType(CO.ToString, Decimal), 2)
                            txtAvailableBudget.Text = FormatNumber(txtbudget.Text - PPMPSaved, 2)
                        End If
                    End If
                End If

                ddAccount.DataSource = pAccounts
                ddAccount.DataTextField = ("GA_Title")
                ddAccount.DataValueField = ("GA_CODE2")
                ddAccount.DataBind()
                ddAccount.Items.Insert(0, "Select")

                'DropDownList1.Enabled = False
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please submit first your PPA to proceed with your PPMP.")
                'msg.UserMsgBox("Please submit first your PPA to proceed with your PPMP", Me, False)
            End If
        Catch ex As Exception

        End Try

        Try
            If Me.ddPAPS.SelectedValue = "Office Operational Expense" Then
                TabContainer1.ActiveTabIndex = 0
            Else
                TabContainer1.ActiveTabIndex = 1
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub chkOOE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOOE.CheckedChanged

        If Me.chkOOE.Checked = True Then
            If Me.DropDownList1.SelectedValue.ToString = "Select" Then
                Me.ddPAPS.SelectedItem.Text = "Select"
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select allotment type.")
                ddPAPS.Enabled = True
            Else
                DropDownList1.Enabled = True
                Me.ddPAPS.SelectedItem.Text = "Select"
                pAccounts = objDerived.GetDataTable("exec AMS.sp_GA_ID_from_LBPF_3_Per_Allotment  " & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "," & ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & withApprovedBudget & ",0,0," & Me.DropDownList1.SelectedValue.ToString & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                ddAccount.DataSource = pAccounts
                ddAccount.DataTextField = ("GA_Title")
                ddAccount.DataValueField = ("GA_CODE2")
                ddAccount.DataBind()
                ddAccount.Items.Insert(0, "Select")
                ddAccount.Enabled = True

                txtAvailableBudget.Text = "0.00"
                txtbudget.Text = "0.00"

                DropDownList1.Enabled = False '=-= 1-19-2015
                ddPAPS.Enabled = False '12022022
            End If

        Else
            ddPAPS.Items.Clear()
            If ddFunction.SelectedItem.Text = "Select" Then

                pAccounts = Nothing
                ddPAPS.DataSource = pAccounts
                ddPAPS.DataBind()
                ddPAPS.Items.Add("Select")
            Else
                ddPAPS.Enabled = True
                PAPS = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project " & Me.ddRC.SelectedItem.Value & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
                ddPAPS.DataSource = PAPS
                ddPAPS.Items.Add("Select")
                ddPAPS.DataTextField = ("description")
                ddPAPS.DataValueField = ("description")
                ddPAPS.DataBind()
                pAccounts = Nothing
                Session("year") = pYear.Rows(ddyear.SelectedIndex - 1)("year")
                ddyear.Enabled = False
                ddFunction.Enabled = False

                '=-= 1-19-2015
                DropDownList1.Enabled = True
                DropDownList1.SelectedIndex = 0

                pAccounts = Nothing
                ddAccount.Items.Clear()
                ddAccount.Items.Add("Select")

            End If
            Session("Function_ID") = ddFunction.SelectedItem.Value
            ddPAPS.Enabled = True
        End If

        hdfppaprojId.Value = 0
        hdfppaprogId.Value = 0

    End Sub
    Public Function createdatatableRepair(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("PropertyDetai_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtNatureRepair.Text = "" Then
            lblreq.Visible = True
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up required fields.")

        Else
            lblreq.Visible = False
            Try
                objRepair.Property_Dtl_ID = gvRepairs.SelectedDataKey("PropertyDetai_ID")
                objRepair.PropertyNo = gvRepairs.SelectedDataKey("PropertyNo")
                objRepair.dDate = txtrepairDate.Text
                objRepair.ServiceProvider = txtServiceProvider.Text
                objRepair.NatureRepair = txtNatureRepair.Text
                objRepair.InvoiceNo = txtInvoiceNo.Text
                'objRepair.Amount = ""
                objRepair.RC_ID = ddRC.SelectedValue
                objRepair.Function_ID = ddFunction.SelectedValue
                objRepair.GA_Code2 = ddAccount.SelectedValue
                If ddPAPS.SelectedItem.ToString = "Select" Then
                    objRepair.Program_ID = 0
                    objRepair.Project_ID = 0
                Else
                    '11282022
                    objRepair.Program_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_ID")
                    objRepair.Project_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
                End If
                objRepair.Item_ID = gvRepairs.SelectedDataKey("Item_ID")
                objRepair.ppmp_hdr_id = Session("hdrid")
                objRepair.save()

            Catch ex As Exception

            End Try


            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            txtItemDesc.Text = ""
            txtNatureRepair.Text = ""
            txtServiceProvider.Text = ""
            txtPropertyNo.Text = ""
            txtInvoiceNo.Text = ""
            txtrepairDate.Text = ""
        End If

        ModalPopupExtender2.Show()
    End Sub

    Protected Sub gvRepairs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dtRepair As New DataTable
        dtRepair = objDerived.GetDataTable("Select * from dbo.View_ItemsForRepair where PropertyDetai_ID ='" & gvRepairs.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        If dtRepair.Rows.Count = 0 Then
            txtItemDesc.Text = ""
            txtNatureRepair.Text = ""
            txtServiceProvider.Text = ""
            txtPropertyNo.Text = ""
            txtInvoiceNo.Text = ""
            txtrepairDate.Text = ""
            btnOK.Enabled = False
        Else
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("Select * from AMS.TbRepairMaintenance where Property_Dtl_ID ='" & gvRepairs.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
            If dt.Rows.Count = 0 Then
                txtItemDesc.Text = dtRepair.Rows(0)("Item_Desc")
                txtPropertyNo.Text = gvRepairs.SelectedDataKey("PropertyNo")
                txtNatureRepair.Text = ""
                txtServiceProvider.Text = ""
                txtInvoiceNo.Text = ""
                txtrepairDate.Text = Date.Today.ToString("MM/dd/yyyy")
                btnOK.Enabled = True
            Else
                txtItemDesc.Text = dtRepair.Rows(0)("Item_Desc")
                txtPropertyNo.Text = dt.Rows(0)("PropertyNo")
                txtNatureRepair.Text = dt.Rows(0)("NatureRepair")
                txtServiceProvider.Text = dt.Rows(0)("ServiceProvider")
                txtInvoiceNo.Text = dt.Rows(0)("InvoiceNo")
                txtrepairDate.Text = dt.Rows(0)("dDate")
                btnOK.Enabled = False
            End If
        End If
        ModalPopupExtender2.Show()
    End Sub

    Protected Sub gvRepairs_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim pProperties As New DataTable
        pProperties = objDerived.GetDataTable("Select * from dbo.View_ItemsForRepair where GA_ID ='" & Session("rGA_ID") & "' and RC_ID ='" & ddRC.SelectedValue & "' and Function_ID ='" & ddFunction.SelectedValue & "'", CommandType.Text)
        If pProperties.Rows.Count < 8 Then
            pProperties.Merge(createdatatableRepair(8 - pProperties.Rows.Count))
        End If
        gvRepairs.PageIndex = e.NewPageIndex
        gvRepairs.DataSource = pProperties
        gvRepairs.DataBind()
        btnOK.Enabled = True

        ModalPopupExtender2.Show()
    End Sub

    Protected Sub ddmode_of_procurement_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("mode_of_procurement") = ddmode_of_procurement.SelectedItem.Value
        'ddmode_of_procurement.Enabled = False
        btnsubmit.Enabled = True
    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/planning/t_ppmp_contingency.aspx")
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pLbtn = "Select"
    End Sub


    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub CBIsGoods_CheckedChanged(sender As Object, e As EventArgs)
        Dim Goods As Boolean
        If CBIsGoods.Checked = True Then

            Session("isGoods") = False
        Else
            Session("isGoods") = True
        End If
    End Sub
    Protected Sub CBIsInfra_CheckedChanged(sender As Object, e As EventArgs)
        Dim Infra As Boolean
        If CBIsInfra.Checked = True Then

            Session("isInfra") = True
        Else
            Session("isInfra") = False
        End If
    End Sub
End Class
