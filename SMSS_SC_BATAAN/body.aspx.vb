Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb

Partial Class body
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private getprofile As New ProfileCommon


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("user") = Nothing Then
                lblUser.Text = FileClass.b64decode(Session("user"))
            End If

            Dim Fname, MI, Lname, Position As String
            Fname = getprofile.GetProfile(Session("@UserName")).FirstName.ToString()
            MI = getprofile.GetProfile(Session("@UserName")).MiddleName.ToString
            Lname = getprofile.GetProfile(Session("@UserName")).LastName.ToString()
            Position = getprofile.GetProfile(Session("@UserName")).Position.ToString()

            lblName.Text = Fname + " " + MI + " " + Lname
            lblPosition.Text = Position
            lblDate.Text = Now.ToLongDateString '& " | " & DateTime.Now.ToLongTimeString()
            lblTime.Text = DateTime.Now.ToLongTimeString()


            'Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
            'Dim role() As String = Roles.GetRolesForUser(usr.UserName)
            'Dim rolename As String = role(0)
            'Session("RoleName") = rolename

            'Dim dt As New DataTable
            'dt = objDerived.GetDataTable("[AMS].[sp_PPMP_Notification_PerOffice] '" & Session("RoleName") & "'", CommandType.Text)
            'If dt.Rows(0)("withPPMP") = 0 Then
            '    lblDepartment.Text = dt.Rows(0)("rc_name")
            '    lblNote.Text = "hasn't yet submitted PPMP for the Year " + CType(dt.Rows(0)("CYear"), String)
            '    AlwaysVisibleControlExtender1.Enabled = True
            'Else
            '    AlwaysVisibleControlExtender1.Enabled = False
            'End If
        End If

        'lblUser.Text = Me.Session("LogUser")
        'Me.Label1.Text = Me.Session("LogUser")
        'Me.lblDate.Text = Now.ToLongDateString & " | " & DateTime.Now.ToLongTimeString()
        'Label2.Text = Now.ToLongDateString & " | " & DateTime.Now.ToLongTimeString()

        'If Not Page.IsPostBack Then
        '    obj.LoadAccessibleURL(Session("@UserID"), Session("@RoleID"))
        '    Dim a = Session("@RoleID")
        'End If
    End Sub
    'Protected Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLogout.Click
    '    Session.Abandon()
    '    FormsAuthentication.SignOut()

    '    'redirect to login page
    '    Response.Redirect("index.aspx")
    'End Sub

    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    Dim url As String = objDerived.GetValue("select URL from GEOFMS_INTEGRATION.dbo.Application_Links where SystemID=5", Data.CommandType.Text)
    '    Me.Page.Response.Redirect(url.ToString)
    'End Sub

    'Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    AlwaysVisibleControlExtender1.Enabled = False
    '    Panel4.Visible = False
    'End Sub


    'Protected Sub lnkPPMP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.Page.Response.Redirect("~/planning/t_ppmp.aspx")
    'End Sub
End Class
