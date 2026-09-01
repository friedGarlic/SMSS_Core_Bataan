
Partial Class MasterPage1
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.lblDate.Text = Now.ToLongDateString & " | " & DateTime.Now.ToLongTimeString()
            If Not Session("user") = Nothing Then
                Me.lblUser.Text = FileClass.b64decode(Session("user"))
            End If
        End If

        'If Session("@UserID") Is Nothing Then
        '    Page.Response.Redirect("~/UnauthorizedSystemAccess.aspx")
        'End If

    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session.Abandon()
        FormsAuthentication.SignOut()
        Response.Redirect("~/index.aspx")

        'Page.Response.Redirect("~\MainPage\frm_index.aspx")
        'Response.Redirect("~/index.aspx")
        'redirect to login page

    End Sub

    'Protected Sub lnkUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkUpdate.Click

    'End Sub
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
'                Me.DataList1.DataSource = dtReminder
'                Me.DataList1.DataBind()
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

'    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
'    '    Session.Abandon()
'    '    FormsAuthentication.SignOut()
'    '    Response.Redirect("~/index.aspx")
'    'End Sub

'    'Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
'    '    ' Session.Abandon()
'    '    'FormsAuthentication.SignOut()
'    '    Response.Redirect("~/body.aspx")
'    'End Sub
'End Class

