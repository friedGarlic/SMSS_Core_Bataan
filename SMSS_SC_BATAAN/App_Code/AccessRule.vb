Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class AccessRule
    Private dtlvl2 As New DataTable
    Private dtlvl3 As New DataTable

#Region "Properties"
    Private pUserName As String
    Public Property UserName() As String
        Get
            Return pUserName
        End Get
        Set(ByVal value As String)
            pUserName = value
        End Set
    End Property
    Private pApplicationName As String
    Public Property ApplicationName() As String
        Get
            Return pApplicationName
        End Get
        Set(ByVal value As String)
            pApplicationName = value
        End Set
    End Property

    Private pComponentID As Integer
    Public Property ComponentID() As Integer
        Get
            Return pComponentID
        End Get
        Set(ByVal value As Integer)
            pComponentID = value
        End Set
    End Property

    Private pRoleId As Guid
    Public Property RoleId() As Guid
        Get
            Return pRoleId
        End Get
        Set(ByVal value As Guid)
            pRoleId = value
        End Set
    End Property

    Private pHasAccess As Boolean
    Public Property HasAccess() As Boolean
        Get
            Return pHasAccess
        End Get
        Set(ByVal value As Boolean)
            pHasAccess = value
        End Set
    End Property

    Private pCanAdd As Boolean
    Public Property CanAdd() As Boolean
        Get
            Return pCanAdd
        End Get
        Set(ByVal value As Boolean)
            pCanAdd = value
        End Set
    End Property

    Private pCanEdit As Boolean
    Public Property CanEdit() As Boolean
        Get
            Return pCanEdit
        End Get
        Set(ByVal value As Boolean)
            pCanEdit = value
        End Set
    End Property

    Private pCanDelete As Boolean
    Public Property CanDelete() As Boolean
        Get
            Return pCanDelete
        End Get
        Set(ByVal value As Boolean)
            pCanDelete = value
        End Set
    End Property

    Private pCanView As Boolean
    Public Property CanView() As Boolean
        Get
            Return pCanView
        End Get
        Set(ByVal value As Boolean)
            pCanView = value
        End Set
    End Property

    Private pCanPrint As Boolean
    Public Property CanPrint() As Boolean
        Get
            Return pCanPrint
        End Get
        Set(ByVal value As Boolean)
            pCanPrint = value
        End Set
    End Property

    Private pOther As Boolean
    Public Property Other() As Boolean
        Get
            Return pOther
        End Get
        Set(ByVal value As Boolean)
            pOther = value
        End Set
    End Property
#End Region

    Public Sub BindAccessibleURL(ByVal sender As Menu, ByVal e As System.Web.UI.WebControls.MenuEventArgs)
        Dim str As String

        str = e.Item.Text.ToString
        If e.Item.Depth = 0 Then
            If Not isFoundInlevel2(str.Trim) Then
                'CType(sender, Menu).Items.Remove(CType(sender, Menu).FindItem(str))
            End If
        ElseIf e.Item.Depth = 1 Then
            If Not e.Item.Parent.Value = Nothing Then
                If Not isFoundInlevel2(str.Trim) Then
                    e.Item.Parent.ChildItems.Remove(e.Item)
                End If

            End If
        ElseIf e.Item.Depth > 1 Then
            If Not e.Item.Parent.Value = Nothing Then
                If Not isFoundInlevel3(str.Trim) Then
                    e.Item.Parent.ChildItems.Remove(e.Item)
                End If

            End If
        End If
    End Sub
    Public Sub LoadAccessibleURL(ByVal userid As String, ByVal roleid As String)
        Dim objDal As New BaseGeneral
        'Dim str As String = "exec dbo.GetComponents '" & Session("@UserID") & "','" & Session("@roleID") & "'"

        'Hiding PR-DBM Submodule:
        dtlvl2 = objDal.GetDataTable("exec dbo.GetSubModule '" & userid & "','" & roleid & "'", CommandType.Text)
        dtlvl2 = dtlvl2.AsEnumerable().Where(Function(row) row("SubModuleName").ToString() <> "PR-DBM").CopyToDataTable()

        'Before Hiding the PR-DBM submodule:
        'dtlvl2 = objDal.GetDataTable("exec dbo.GetSubModule '" & userid & "','" & roleid & "'", CommandType.Text)
        'dtlvl2.DefaultView.Sort = "SubModuleName"

        dtlvl3 = objDal.GetDataTable("exec dbo.GetComponents '" & userid & "','" & roleid & "'", CommandType.Text)
        dtlvl3.DefaultView.Sort = "ComponentName"
    End Sub
    Private Function isFoundInlevel2(ByVal str As String) As Boolean
        Try


            Dim bol As Boolean = False

            'Before Hiding PR-DBM
            'If Not dtlvl2.DefaultView.Find(str) = -1 Then


            'Hiding 'PR-DBM'
            If Not dtlvl2.DefaultView.Find(str) = -1 AndAlso str <> "PR-DBM" Then
                bol = True
            Else
                bol = False
            End If

            Return bol
        Catch ex As Exception
        End Try
    End Function


    Private Function isFoundInlevel3(ByVal str As String) As Boolean
        Dim bol As Boolean = False

        If Not dtlvl3.DefaultView.Find(str) = -1 Then
            bol = True
        Else
            bol = False
        End If
        Return bol
    End Function



    Public Function GetAccessRight(ByVal userName As String, ByVal page As Page) As Boolean
        Try
            Dim port As String = "~" & HttpContext.Current.Request.RawUrl
            ' MsgBox(port)
            If port.Contains("%20") Then
                port.Replace("%20", " ")
            End If
            Dim homepage As String = page.AppRelativeVirtualPath
            Dim roleName() As String = Roles.GetRolesForUser(userName)
            Dim conStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
            Dim conn As SqlConnection = New SqlConnection(conStr)
            Dim qryCmd As String = "SELECT * FROM vw_AccessRule WHERE HomePageURL=@HomePage AND RoleName=@RoleName"
            Dim cmd As SqlCommand = New SqlCommand(qryCmd, conn)

            ' cmd.Parameters.AddWithValue("@HomePage", homepage)
            cmd.Parameters.AddWithValue("@HomePage", port)

            cmd.Parameters.AddWithValue("@RoleName", roleName(0))
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            conn.Open()
            da.Fill(dt)
            conn.Close()

            Dim dr As DataRow
            dr = dt.Rows(0)

            Me.HasAccess = IIf(IsDBNull(dr("HasAccess")), False, dr("HasAccess"))
            Me.CanAdd = IIf(IsDBNull(dr("CanAdd")), False, dr("CanAdd"))
            Me.CanEdit = IIf(IsDBNull(dr("CanEdit")), False, dr("CanEdit"))
            Me.CanDelete = IIf(IsDBNull(dr("CanDelete")), False, dr("CanDelete"))
            Me.CanPrint = IIf(IsDBNull(dr("CanPrint")), False, dr("CanPrint"))
            Me.Other = IIf(IsDBNull(dr("Other")), False, dr("Other"))
        Catch ex As Exception
            Try


                'page.Response.Redirect("~/index.aspx")
                Dim homepage As String = page.AppRelativeVirtualPath
                Dim roleName() As String = Roles.GetRolesForUser(userName)
                Dim conStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
                Dim conn As SqlConnection = New SqlConnection(conStr)
                Dim qryCmd As String = "SELECT * FROM vw_accesrole_submodule WHERE HomePageURL=@HomePage AND RoleName=@RoleName"

                Dim cmd As SqlCommand = New SqlCommand(qryCmd, conn)
                cmd.Parameters.AddWithValue("@HomePage", homepage)
                cmd.Parameters.AddWithValue("@RoleName", roleName(0))
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                Dim dt As New DataTable
                conn.Open()
                da.Fill(dt)
                conn.Close()

                Dim dr As DataRow
                dr = dt.Rows(0)

                Me.HasAccess = IIf(IsDBNull(dr("HasAccess")), False, dr("HasAccess"))
                Me.CanAdd = IIf(IsDBNull(dr("CanAdd")), False, dr("CanAdd"))
                Me.CanEdit = IIf(IsDBNull(dr("CanEdit")), False, dr("CanEdit"))
                Me.CanDelete = IIf(IsDBNull(dr("CanDelete")), False, dr("CanDelete"))
                Me.CanPrint = IIf(IsDBNull(dr("CanPrint")), False, dr("CanPrint"))
                Me.Other = IIf(IsDBNull(dr("Other")), False, dr("Other"))
            Catch ex2 As Exception
                page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End Try
        End Try
    End Function
    Public Function GetComponentId(ByVal homepage As String) As Integer
        Dim compId As Integer
        Dim conStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim conn As SqlConnection = New SqlConnection(conStr)
        Dim qryCmd As String = "SELECT TOP 1 ComponentId FROM tbl_Component WHERE HomePageURL='" & homepage & "'"
        Dim cmd As SqlCommand = New SqlCommand(qryCmd, conn)
        conn.Open()
        compId = cmd.ExecuteScalar()
        conn.Close()
        Return compId
    End Function

    Public Function GetMenuString(ByVal homepage As String) As String
        Dim compId As String
        Dim conStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim conn As SqlConnection = New SqlConnection(conStr)
        Dim qryCmd As String = "exec dbo.GetMenuName '" & homepage & "'"
        Dim cmd As SqlCommand = New SqlCommand(qryCmd, conn)
        conn.Open()
        compId = cmd.ExecuteScalar()
        conn.Close()
        Return compId
    End Function


End Class
