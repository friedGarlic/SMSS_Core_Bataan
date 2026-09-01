Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Configuration
Imports System

Public Class ManageButtons
    'Public Sub EnableButton(ByVal mp As MasterPage, ByVal imgbtnID As String)
    '    ' Dim imID As String = imgbtn.ID.ToString
    '    Dim mpImgBtn As ImageButton

    '    mpImgBtn = CType(mp.FindControl("ImageButton1"), ImageButton)
    '    mpImgBtn.ImageUrl = "../images/default/img-02.jpg"

    '    mpImgBtn = CType(mp.FindControl("ImageButton2"), ImageButton)
    '    mpImgBtn.ImageUrl = "../images/default/img-03.jpg"

    '    mpImgBtn = CType(mp.FindControl("ImageButton3"), ImageButton)
    '    mpImgBtn.ImageUrl = "../images/default/img-04.jpg"

    '    mpImgBtn = CType(mp.FindControl("ImageButton4"), ImageButton)
    '    mpImgBtn.ImageUrl = "../images/default/img-05.jpg"

    '    mpImgBtn = CType(mp.FindControl("ImageButton5"), ImageButton)
    '    mpImgBtn.ImageUrl = "../images/default/img-06.jpg"

    '    mpImgBtn = CType(mp.FindControl("ImageButton6"), ImageButton)
    '    mpImgBtn.ImageUrl = "../images/default/img-07.jpg"

    '    mpImgBtn = CType(mp.FindControl("ImageButton7"), ImageButton)
    '    mpImgBtn.ImageUrl = "../images/default/img-08.jpg"

    '    mpImgBtn = CType(mp.FindControl("ImageButton8"), ImageButton)
    '    mpImgBtn.ImageUrl = "../images/default/img-09.jpg"

    '    mpImgBtn = CType(mp.FindControl(imgbtnID), ImageButton)

    '    Select Case mpImgBtn.ID
    '        Case "ImageButton1"
    '            mpImgBtn.ImageUrl = "../images/active/active_btn-02.jpg"
    '        Case "ImageButton2"
    '            mpImgBtn.ImageUrl = "../images/active/active_btn-03.jpg"
    '        Case "ImageButton3"
    '            mpImgBtn.ImageUrl = "../images/active/active_btn-04.jpg"
    '        Case "ImageButton4"
    '            mpImgBtn.ImageUrl = "../images/active/active_btn-05.jpg"
    '        Case "ImageButton5"
    '            mpImgBtn.ImageUrl = "../images/active/active_btn-06.jpg"
    '        Case "ImageButton6"
    '            mpImgBtn.ImageUrl = "../images/active/active_btn-07.jpg"
    '        Case "ImageButton7"
    '            mpImgBtn.ImageUrl = "../images/active/active_btn-08.jpg"
    '        Case "ImageButton8"
    '            mpImgBtn.ImageUrl = "../images/active/active_btn-09.jpg"
    '    End Select

    'End Sub


    Public Sub loadButtonColor(ByVal sender As Object, ByVal btnToday As LinkButton, ByVal btnThisWeek As LinkButton, ByVal btnThisMonth As LinkButton, ByVal btnALL As LinkButton)
        'Session("ID")
        Dim ID As String
        If sender.ID = "btnToday" Then
            btnToday.BackColor = Drawing.Color.FromArgb(0, 183, 217, 187)
            'btnToday.BorderColor = Drawing.Color.Black
            'btnToday.BorderStyle = BorderStyle.Solid
            'btnToday.BorderWidth = 1
            ID = "Today"
        Else
            btnToday.BackColor = Drawing.Color.White
            'btnToday.BorderColor = Drawing.Color.Gray
            'btnToday.BorderStyle = BorderStyle.Solid
            'btnToday.BorderWidth = 1

        End If

        If sender.ID = "btnThisWeek" Then
            btnThisWeek.BackColor = Drawing.Color.FromArgb(0, 183, 217, 187)
            ID = "ThisWeek"
            'btnThisWeek.BorderColor = Drawing.Color.Black
            'btnThisWeek.BorderStyle = BorderStyle.Solid
            'btnThisWeek.BorderWidth = 1
        Else
            btnThisWeek.BackColor = Drawing.Color.White
            'btnThisWeek.BorderColor = Drawing.Color.Gray
            'btnThisWeek.BorderStyle = BorderStyle.Solid
            'btnThisWeek.BorderWidth = 1
        End If

        If sender.ID = "btnThisMonth" Then
            btnThisMonth.BackColor = Drawing.Color.FromArgb(0, 183, 217, 187)
            ID = "This Month"
            'btnThisMonth.BorderColor = Drawing.Color.Black
            'btnThisMonth.BorderStyle = BorderStyle.Solid
            'btnThisMonth.BorderWidth = 1
        Else
            btnThisMonth.BackColor = Drawing.Color.White
            'btnThisMonth.BorderColor = Drawing.Color.Gray
            'btnThisMonth.BorderStyle = BorderStyle.Solid
            'btnThisMonth.BorderWidth = 1
        End If

        If sender.ID = "btnALL" Then
            btnALL.BackColor = Drawing.Color.FromArgb(0, 183, 217, 187)
            ID = "ALL"
            'btnCustomSearch.BorderColor = Drawing.Color.Black
            'btnCustomSearch.BorderStyle = BorderStyle.Solid
            'btnCustomSearch.BorderWidth = 1
        Else
            btnALL.BackColor = Drawing.Color.White
            'btnCustomSearch.BorderColor = Drawing.Color.Gray
            'btnCustomSearch.BorderStyle = BorderStyle.Solid
            'btnCustomSearch.BorderWidth = 1
        End If

        'ses(ID)

    End Sub


    Public Sub LoadSubMenu(ByVal menuID As Integer, ByVal mp As MasterPage)
        Dim xmlds As XmlDataSource = CType(mp.FindControl("xmlDataSource"), XmlDataSource)
        xmlds.Data = Nothing
        Dim ds As New DataSet()
        Dim dsChild As New DataSet()
        Dim connStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString '"data source=.;uid=sa;pwd=P@ssw0rd;Integrated Security=False;database=SMSApp"

        Using conn As New SqlConnection(connStr)
            'Dim sql As String = "SELECT SubModuleID SubModuleName as ComponentName,Description,HomePageURL FROM tbl_SubModule WHERE ModuleID=" & menuID
            Dim cmd As New SqlCommand("spLoad_MenuHierarchy", conn)
            cmd.Parameters.AddWithValue("@MenuID", menuID)
            cmd.CommandType = CommandType.StoredProcedure
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(ds)
            da.Dispose()
            conn.Dispose()
        End Using
        ds.DataSetName = "Menus"
        ds.Tables(0).TableName = "Menu"

        Dim relation As New DataRelation("ParentChild", ds.Tables("Menu").Columns("ID"), ds.Tables("Menu").Columns("ParentID"), True)
        relation.Nested = True
        ds.Relations.Add(relation)

        xmlds.Data = ds.GetXml()
        xmlds.DataBind()

        Dim mnu As Menu = CType(mp.FindControl("Menu1"), Menu)
        mnu.DataSource = xmlds
        mnu.DataBind()
    End Sub
End Class
