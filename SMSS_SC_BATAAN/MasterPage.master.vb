Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Partial Class MasterPage_MasterPage
    Inherits System.Web.UI.MasterPage
    Dim obj As New AccessRule
    Private getprofile As New ProfileCommon
    Dim objDerived As New DerivedDal
    Private objMenuCntrl As New ManageButtons

    Dim data As New Integer
    Dim msg As New MsgeBox
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Request.UserAgent.IndexOf("AppleWebKit") > 0) Then
            Request.Browser.Adapters.Clear()
        End If

        Try
            If Not Page.IsPostBack Then
                obj.LoadAccessibleURL(Session("@UserID"), Session("@RoleID"))
                Dim a = Session("@RoleID")

                Dim Fname, MI, Lname As String
                Fname = getprofile.GetProfile(Session("@UserName")).FirstName.ToString()
                MI = getprofile.GetProfile(Session("@UserName")).MiddleName.ToString
                Lname = getprofile.GetProfile(Session("@UserName")).LastName.ToString()

                Me.Session("LogUser") = UCase("WELCOME, " & Fname)
                objMenuCntrl.LoadSubMenu(Me.Session("SubModuleID"), Me)
                EnableButton(Me.Session("SubModuleID"))
                Me.lblUser.Text = Fname

                Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
                Dim role() As String = Roles.GetRolesForUser(usr.UserName)
                Dim rolename As String = role(0)
                Session("RoleName") = rolename

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("[AMS].[sp_PPMP_Notification_PerOffice] '" & Session("RoleName") & "'", CommandType.Text)
                If dt.Rows(0)("withAPP") = 1 And dt.Rows(0)("withPPMP") = 0 Then
                    lblNote.Text = "You have not yet encoded your Department's PPMP for the Year " + CType(dt.Rows(0)("NextYear"), String) + "."
                    'AlwaysVisibleControlExtender1.Enabled = True
                    Panel4.Visible = True
                Else
                    Panel4.Visible = False
                    '   AlwaysVisibleControlExtender1.Enabled = False
                End If

                Dim dtNotification As New DataTable
                dtNotification = objDerived.GetDataTable("[AMS].[Notification]", CommandType.Text)
                rptNotifications.DataSource = dtNotification
                rptNotifications.DataBind()


                If Session("NotificationStatus") = "Show" Then
                        Panel4.Height = 150
                        btnClose.Text = "Hide"
                        Dim msgbox1 As System.Web.UI.AttributeCollection = message_box.Attributes
                        msgbox1.Add("style", "background-position: left top;    position: fixed;    bottom: 0px;    width: 250px;    height: 150px;    -webkit-border-radius: 3px;    -moz-border-radius: 3px;    background-repeat: no-repeat;    /* background-image: url('images/Background/noti.png'); */    padding-top: 10px;    padding-left: 15px;    right: 0px;")

                    ElseIf Session("NotificationStatus") = "Hide" Then
                        Panel4.Height = 150
                        btnClose.Text = "Show"
                        Dim msgbox1 As System.Web.UI.AttributeCollection = message_box.Attributes
                        msgbox1.Add("style", "background-position: left top;    position: fixed;    bottom: -120px;    width: 250px;    height: 150px;    -webkit-border-radius: 3px;    -moz-border-radius: 3px;    background-repeat: no-repeat;    /* background-image: url('images/Background/noti.png'); */    padding-top: 10px;    padding-left: 15px;    right: 0px;")

                    End If

                    selectmenu()

                End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub selectmenu()
        Dim str As String = obj.GetMenuString(Page.AppRelativeVirtualPath)
        For Each item As MenuItem In Menu1.Items
            If str = item.Text Then
                item.Selected = True
            End If
        Next

    End Sub


    'Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
    '    If txtTraps.Value = "Yes" Then


    '        objMenuCntrl.LoadSubMenu(11, Me)
    '        'objMenuCntrl.EnableButton(Me, sender.ID.ToString)

    '        Me.Session("SubModuleID") = 11
    '        EnableButton(Me.Session("SubModuleID"))
    '        'FillMenu(0)
    '        Me.Page.Response.Redirect("~/Records/t_StockCard_v2.aspx")

    '    End If
    'End Sub
    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click

        objMenuCntrl.LoadSubMenu(4, Me)
        'objMenuCntrl.EnableButton(Me, sender.ID.ToString)
        Me.Session("SubModuleID") = 4
        EnableButton(Me.Session("SubModuleID"))
        ' FillMenu(8)

        Me.Page.Response.Redirect("~/PLANNING/boss_BudgetPPA.aspx")
        'Me.Page.Response.Redirect("~/PLANNING/t_ppmp.aspx")

    End Sub
    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click

        objMenuCntrl.LoadSubMenu(5, Me)
        'objMenuCntrl.EnableButton(Me, sender.ID.ToString)
        EnableButton(Me.Session("SubModuleID"))
        Me.Session("SubModuleID") = 5
        'FillMenu(9)
        Me.Page.Response.Redirect("~/procurement/t_purchase_request_v2.aspx")

    End Sub
    Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton4.Click

        objMenuCntrl.LoadSubMenu(6, Me)
        'objMenuCntrl.EnableButton(Me, sender.ID.ToString)
        Me.Session("SubModuleID") = 6
        EnableButton(Me.Session("SubModuleID"))
        'FillMenu(10)
        Me.Page.Response.Redirect("~/Inventory/t_RequisitionAndIssunace.aspx")

    End Sub
    Protected Sub ImageButton5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton5.Click

        objMenuCntrl.LoadSubMenu(7, Me)
        ' objMenuCntrl.EnableButton(Me, sender.ID.ToString)
        Me.Session("SubModuleID") = 7
        EnableButton(Me.Session("SubModuleID"))
        ' FillMenu(11)
        Me.Page.Response.Redirect("~/Reports and Query/t_purchase_request.aspx")

    End Sub
    Protected Sub ImageButton6_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton6.Click

        objMenuCntrl.LoadSubMenu(8, Me)
        'objMenuCntrl.EnableButton(Me, sender.ID.ToString)
        Me.Session("SubModuleID") = 8
        EnableButton(Me.Session("SubModuleID"))
        'FillMenu(12)

        Me.Page.Response.Redirect("~/bidding/t_obr_evaluation.aspx")
        'Me.Page.Response.Redirect("~/bidding/t_canvass_goods.aspx")
    End Sub
    Protected Sub ImageButton7_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton7.Click

        objMenuCntrl.LoadSubMenu(9, Me)

        'objMenuCntrl.EnableButton(Me, sender.ID.ToString)
        Me.Session("SubModuleID") = 9
        EnableButton(Me.Session("SubModuleID"))
        'FillMenu(13)
        Me.Page.Response.Redirect("~/filemaintenance/t_goods_master_list.aspx")

    End Sub
    Protected Sub ImageButton8_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton8.Click

        objMenuCntrl.LoadSubMenu(10, Me)
        '  objMenuCntrl.EnableButton(Me, sender.ID.ToString)
        Me.Session("SubModuleID") = 10
        EnableButton(Me.Session("SubModuleID"))
        ' FillMenu(15)
        Me.Page.Response.Redirect("~/etc/body.aspx")

    End Sub


    Private Sub EnableButton(ByVal imgbtn As Integer)
        Dim selectedModule As String = "Home"
        'Me.ImageButton1.ImageUrl = "~/images/Default2/b-records.jpg"
        Me.ImageButton2.ImageUrl = "~/images/Default2/b-planning.jpg"
        Me.ImageButton3.ImageUrl = "~/images/Default2/b-procurement.jpg"
        Me.ImageButton4.ImageUrl = "~/images/Default2/b-inventory.jpg"
        Me.ImageButton5.ImageUrl = "~/images/Default2/b-Reports.jpg"
        Me.ImageButton6.ImageUrl = "~/images/Default2/b-bidding.jpg"
        Me.ImageButton7.ImageUrl = "~/images/Default2/b-fm.jpg"
        Me.ImageButton8.ImageUrl = "~/images/Default2/b-sm.jpg"
        Select Case imgbtn
            'Case 11
            '    Me.ImageButton1.ImageUrl = "~/images/Active2/y-records.jpg"
            '    selectedModule = "Records"
            Case 4
                Me.ImageButton2.ImageUrl = "~/images/Active2/y-planning.jpg"
                selectedModule = "PLANNING"
            Case 5
                Me.ImageButton3.ImageUrl = "~/images/Active2/PROCUREMENT PROCESS_ACTIVE.png"
                selectedModule = "PROCUREMENT"
            Case 6
                Me.ImageButton4.ImageUrl = "~/images/Active2/INVENTORY MANAGEMENT_ACTIVE.png"
                selectedModule = "INVENTORY"
            Case 7
                Me.ImageButton5.ImageUrl = "~/images/Active2/REPORTS QUERIES_ACTIVE.png"
                selectedModule = "REPORTS AND QUERIES"
            Case 8
                Me.ImageButton6.ImageUrl = "~/images/Active2/PROCUREMENT MODE_ACTIVE.png"
                selectedModule = "BIDDING"
            Case 9
                Me.ImageButton7.ImageUrl = "~/images/Active2/FILE MAINTENANCE_ACTIVE.png"
                selectedModule = "FILE MAINTENANCE"
            Case 10
                Me.ImageButton8.ImageUrl = "~/images/Active2/SYSTEM MANAGER_ACTIVE.png"
                selectedModule = "SYSTEM MANAGER"
        End Select


    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session.Abandon()
        FormsAuthentication.SignOut()
        Response.Redirect("~/index.aspx")
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        ' Session.Abandon()
        'FormsAuthentication.SignOut()
        Response.Redirect("~/body.aspx")

    End Sub
    Dim _link As String
    Protected Sub link_view_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        _link = "_view"
        '  Panel4.Visible = True
    End Sub

    Protected Sub link_action_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        _link = "_action"
    End Sub

    Protected Sub GridView_view_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub lnkbtnnotification_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If btnClose.Text = "Hide" Then

            Panel4.Height = 0
            btnClose.Text = "Show"
            Session("NotificationStatus") = "Hide"
            lblNote.visible = False
            Label2.visible = False
            lnkPPMP.visible = False
            Dim msgbox1 As System.Web.UI.AttributeCollection = message_box.Attributes
            msgbox1.Add("style", "background-position: left top;    position: fixed;    bottom: -120px;    width: 250px;    height: 150px;    -webkit-border-radius: 3px;    -moz-border-radius: 3px;    background-repeat: no-repeat;    /* background-image: url('images/Background/noti.png'); */    padding-top: 10px;    padding-left: 15px;    right: 0px;")


        Else
            Panel4.Height = 150
            btnClose.Text = "Hide"
            Session("NotificationStatus") = "Show"
            lblNote.visible = True
            Label2.visible = True
            lnkPPMP.visible = True
            Dim msgbox1 As System.Web.UI.AttributeCollection = message_box.Attributes
            msgbox1.Add("style", "background-position: left top;    position: fixed;    bottom: 0px;    width: 250px;    height: 150px;    -webkit-border-radius: 3px;    -moz-border-radius: 3px;    background-repeat: no-repeat;    /* background-image: url('images/Background/noti.png'); */    padding-top: 10px;    padding-left: 15px;    right: 0px;")

        End If



    End Sub

    Protected Sub btnClose1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If btnClose.Text = "Hide" Then

            Panel4.Height = 0
            btnClose.Text = "Show"
            Session("NotificationStatus") = "Hide"
            lblNote.visible = False
            Label2.visible = False
            lnkPPMP.visible = False
            Dim msgbox1 As System.Web.UI.AttributeCollection = message_box.Attributes
            msgbox1.Add("style", "background-position: left top;    position: fixed;    bottom: -80px;    width: 250px;    height: 130px;    -webkit-border-radius: 3px;    -moz-border-radius: 3px;    background-repeat: no-repeat;    /* background-image: url('images/Background/noti.png'); */    padding-top: 10px;    padding-left: 15px;    right: 0px;")

        Else
            Panel4.Height = 130
            btnClose.Text = "Hide"
            Session("NotificationStatus") = "Show"
            lblNote.visible = True
            Label2.visible = True
            lnkPPMP.visible = True
            Dim msgbox1 As System.Web.UI.AttributeCollection = message_box.Attributes
            msgbox1.Add("style", "background-position: left top;    position: fixed;    bottom: 0px;    width: 250px;    height: 130px;    -webkit-border-radius: 3px;    -moz-border-radius: 3px;    background-repeat: no-repeat;    /* background-image: url('images/Background/noti.png'); */    padding-top: 10px;    padding-left: 15px;    right: 0px;")

        End If



    End Sub

    Protected Sub lnkPPMP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("withPPMP") = 1
        Me.Page.Response.Redirect("~/planning/t_ppmp.aspx")
    End Sub


    Protected Sub Menu1_MenuItemClick(sender As Object, e As MenuEventArgs)

    End Sub

    Private Sub MasterPage_MasterPage_Unload(sender As Object, e As EventArgs) Handles Me.Unload

    End Sub
    Protected Sub btnNotifications_Click(sender As Object, e As EventArgs)
        pnlNotifications.Visible = Not pnlNotifications.Visible

    End Sub

End Class



'Imports System.Data
'Imports System.Data.SqlClient
'Imports System.Web.UI.WebControls
'Partial Class MasterPage_MasterPage
'    Inherits System.Web.UI.MasterPage
'    Dim obj As New AccessRule
'    Private getprofile As New ProfileCommon
'    Dim objDerived As New DerivedDal
'    Private objMenuCntrl As New ManageButtons

'    Dim data As New Integer
'    Dim msg As New MsgeBox
'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        Try
'            If Not Page.IsPostBack Then


'                '  Me.lblDate.Text = Now.ToLongDateString & " | " & DateTime.Now.ToLongTimeString()
'                obj.LoadAccessibleURL(Session("@UserID"), Session("@RoleID"))
'                Dim a = Session("@RoleID")

'                Dim Fname, MI, Lname As String
'                Fname = getprofile.GetProfile(Session("@UserName")).FirstName.ToString()
'                MI = getprofile.GetProfile(Session("@UserName")).MiddleName.ToString
'                Lname = getprofile.GetProfile(Session("@UserName")).LastName.ToString()
'                'Data = objDerived.GetDataTableV2("SELECT ComponentName,ComponentID,HomePageURL FROM tbl_Component WHERE SubModuleID='" & Me.Session("SubModuleID") & "'", CommandType.Text)
'                ' FillMenu(Me.Session("SubModuleID"))
'                ' Me.Label1.Text = Fname
'                Me.Session("LogUser") = UCase("WELCOME, " & Fname)
'                objMenuCntrl.LoadSubMenu(Me.Session("SubModuleID"), Me)
'                EnableButton(Me.Session("SubModuleID"))
'                'Me.Label1.Text = Me.Session("LogUser")
'                'Me.Label2.Text = Now.ToLongDateString & " | " & DateTime.Now.ToLongTimeString()
'                Me.lblUser.Text = Fname
'                Dim dtReminder As New DataTable
'                dtReminder = objDerived.GetDataTable("exec dbo.sp_ReminderList", CommandType.Text)
'                'Me.DataList1.DataSource = dtReminder
'                'Me.DataList1.DataBind()
'            End If

'        Catch ex As Exception

'        End Try
'    End Sub


'    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
'        objMenuCntrl.LoadSubMenu(11, Me)
'        ' objMenuCntrl.EnableButton(Me, sender.ID.ToString)

'        Me.Session("SubModuleID") = 11
'        EnableButton(Me.Session("SubModuleID"))
'        ' FillMenu(0)
'        Me.Page.Response.Redirect("~/Records/t_StockCard_v2.aspx")

'    End Sub
'    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
'        objMenuCntrl.LoadSubMenu(4, Me)
'        'objMenuCntrl.EnableButton(Me, sender.ID.ToString)
'        Me.Session("SubModuleID") = 4
'        EnableButton(Me.Session("SubModuleID"))
'        ' FillMenu(8)
'        Me.Page.Response.Redirect("~/PLANNING/t_annual_procurement_plan.aspx")

'    End Sub
'    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
'        objMenuCntrl.LoadSubMenu(5, Me)
'        ' objMenuCntrl.EnableButton(Me, sender.ID.ToString)
'        EnableButton(Me.Session("SubModuleID"))
'        Me.Session("SubModuleID") = 5
'        'FillMenu(9)
'        Me.Page.Response.Redirect("~/procurement/t_purchase_request_v2.aspx")

'    End Sub
'    Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton4.Click
'        objMenuCntrl.LoadSubMenu(6, Me)
'        'objMenuCntrl.EnableButton(Me, sender.ID.ToString)
'        Me.Session("SubModuleID") = 6
'        EnableButton(Me.Session("SubModuleID"))
'        ' FillMenu(10)
'        Me.Page.Response.Redirect("~/Inventory/t_RequisitionAndIssunace.aspx")

'    End Sub
'    Protected Sub ImageButton5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton5.Click

'        objMenuCntrl.LoadSubMenu(7, Me)
'        ' objMenuCntrl.EnableButton(Me, sender.ID.ToString)
'        Me.Session("SubModuleID") = 7
'        EnableButton(Me.Session("SubModuleID"))
'        ' FillMenu(11)
'        Me.Page.Response.Redirect("~/Reports and Query/t_purchase_request.aspx")

'    End Sub
'    Protected Sub ImageButton6_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton6.Click

'        objMenuCntrl.LoadSubMenu(8, Me)
'        'objMenuCntrl.EnableButton(Me, sender.ID.ToString)
'        Me.Session("SubModuleID") = 8
'        EnableButton(Me.Session("SubModuleID"))
'        'FillMenu(12)
'        Me.Page.Response.Redirect("~/bidding/t_canvass_goods.aspx")

'    End Sub
'    Protected Sub ImageButton7_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton7.Click
'        objMenuCntrl.LoadSubMenu(9, Me)
'        'objMenuCntrl.EnableButton(Me, sender.ID.ToString)
'        Me.Session("SubModuleID") = 9
'        EnableButton(Me.Session("SubModuleID"))
'        'FillMenu(13)
'        Me.Page.Response.Redirect("~/filemaintenance/t_goods_master_list.aspx")

'    End Sub
'    Protected Sub ImageButton8_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton8.Click

'        objMenuCntrl.LoadSubMenu(10, Me)
'        '  objMenuCntrl.EnableButton(Me, sender.ID.ToString)
'        Me.Session("SubModuleID") = 10
'        EnableButton(Me.Session("SubModuleID"))
'        ' FillMenu(15)
'        'Me.Page.Response.Redirect("~/body.aspx")

'    End Sub


'    Private Sub EnableButton(ByVal imgbtn As Integer)
'        Dim selectedModule As String = "Home"
'        Me.ImageButton1.ImageUrl = "~/images/Default2/b-records.jpg"
'        Me.ImageButton2.ImageUrl = "~/images/Default2/b-planning.jpg"
'        Me.ImageButton3.ImageUrl = "~/images/Default2/b-procurement.jpg"
'        Me.ImageButton4.ImageUrl = "~/images/Default2/b-inventory.jpg"
'        Me.ImageButton5.ImageUrl = "~/images/Default2/b-Reports.jpg"
'        Me.ImageButton6.ImageUrl = "~/images/Default2/b-bidding.jpg"
'        Me.ImageButton7.ImageUrl = "~/images/Default2/b-fm.jpg"
'        Me.ImageButton8.ImageUrl = "~/images/Default2/b-sm.jpg"
'        Select Case imgbtn
'            Case 11
'                Me.ImageButton1.ImageUrl = "~/images/Active2/y-records.jpg"
'                selectedModule = "Records"
'            Case 4
'                Me.ImageButton2.ImageUrl = "~/images/Active2/y-planning.jpg"
'                selectedModule = "PLANNING"
'            Case 5
'                Me.ImageButton3.ImageUrl = "~/images/Active2/y-procurement.jpg"
'                selectedModule = "PROCUREMENT"
'            Case 6
'                Me.ImageButton4.ImageUrl = "~/images/Active2/y-inventory.jpg"
'                selectedModule = "INVENTORY"
'            Case 7
'                Me.ImageButton5.ImageUrl = "~/images/Active2/y-Reports.jpg"
'                selectedModule = "REPORTS AND QUERIES"
'            Case 8
'                Me.ImageButton6.ImageUrl = "~/images/Active2/y-bidding.jpg"
'                selectedModule = "BIDDING"
'            Case 9
'                Me.ImageButton7.ImageUrl = "~/images/Active2/y-fm.jpg"
'                selectedModule = "FILE MAINTENANCE"
'            Case 10
'                Me.ImageButton8.ImageUrl = "~/images/Active2/y-sm.jpg"
'                selectedModule = "SYSTEM MANAGER"
'        End Select
'        'Me.lblModule.Text = selectedModule
'    End Sub

'    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
'        Session.Abandon()
'        FormsAuthentication.SignOut()
'        Response.Redirect("~/index.aspx")
'    End Sub

'    'Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
'    '    ' Session.Abandon()
'    '    'FormsAuthentication.SignOut()
'    '    Response.Redirect("~/body.aspx")
'    'End Sub
'End Class

