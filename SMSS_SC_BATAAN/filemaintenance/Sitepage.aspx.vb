'Imports System.Data
'Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.Windows.Forms.Control
Imports System.ComponentModel


Partial Class Sitepage
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadGrid()
            If Me.grdLGU.SelectedIndex = -1 Then
                Me.Button1.Visible = False
            Else
                Me.Button1.Text = True

            End If
            data()


        End If

    End Sub

    Public Sub LoadGrid()
        Dim objs As New BaseClasses.AccountClassAcounts
        Me.grdLGU.DataSource = objs.GetDataTable("SELECT SiteID, SiteName, IsDefault, Description,Province,Address,logo,City_Name FROM dbo.tbl_Client_Site1", CommandType.Text)
        Me.grdLGU.DataBind()

        'Dim str As String = "Data Source=GEODATA\BOSS_PASAY;uid=sa;pwd=P@ssw0rd;database=GeoBOS_SysManager"
        'Dim con As New SqlConnection(str)
        'Dim com As String = "SELECT SiteID, SiteName, IsDefault, Description FROM GeoBOS_SysManager.dbo.tbl_Client_Site"
        'Dim Adpt As New SqlDataAdapter(com, con)
        'Dim ds As New DataSet()
        'Adpt.Fill(ds, "Emp")
        'grdSignatory.DataSource = ds.Tables(0)

        Me.Button1.Visible = False
        Me.TextBox3.Text = ""
        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
        txtAddress.text = ""
    End Sub


    'Protected Sub grdLGU_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdLGU.SelectedIndexChanged
    '    Dim objs As New BaseClasses.AccountClassAcounts
    '    If Me.grdLGU.SelectedRow.Cells(1).Text = "" Then
    '        Me.Image2 = Nothing

    '    Else
    '        Me.Image2.ViewStateMode = objs.GetDataTable("SELECT logo FROM GeoBOS_SysManager.dbo.tbl_Client_Site where SiteId =" & Me.grdLGU.SelectedDataKey.Item(0) & "", CommandType.Text)
    '    End If

    'End Sub

    Protected Sub grdLGU_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles grdLGU.SelectedIndexChanged
        Dim obj As New BaseClasses.AccountClassAcounts
        Me.TextBox3.Text = Server.HtmlDecode(Me.grdLGU.SelectedRow.Cells(1).Text)
        Me.TextBox1.Text = Server.HtmlDecode(Me.grdLGU.SelectedRow.Cells(2).Text)
        Me.TextBox2.Text = Server.HtmlDecode(Me.grdLGU.SelectedRow.Cells(3).Text)
        Me.txtAddress.Text = Server.HtmlDecode(Me.grdLGU.SelectedRow.Cells(4).Text)
        'Me.Image2.ImageUrl = 

        'Me.Image2.ImageUrl = Convert.ToString("SELECT logo FROM bos.tbl_Client_Site1 where SiteID=" & grdLGU.SelectedDataKey.Item(0))

        Me.Button1.Visible = True




    End Sub



    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        update_Site()
        LoadGrid()
    End Sub
    Protected Sub update_Site()

        ' Declare and instantiate the obj variable
        Dim obj As New BaseClasses.AccountClassAcounts()

        ' Check if file is uploaded
        If (FileUpload1.HasFile) Then

            ' Ensure the file is a JPEG image
            If Not FileUpload1.FileName.ToLower().EndsWith(".jpg") Then
                ' Show message box if the file is not a JPEG
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Please upload a valid file, such as a JPG.');", True)

                Exit Sub ' Stop further execution
            End If

            ' Proceed with file save if it is a JPEG
            If FileUpload1.FileName.ToLower.Contains(".jpg") Or FileUpload1.FileName.ToLower.Contains(".png") Then

                Dim existfile As String
                existfile = obj.GetValue("SELECT count(siteID) FROM [dbo].[tbl_Client_Site1] WHERE siteID = " & grdLGU.SelectedDataKey.Item(0), CommandType.Text)
                If existfile <> 0 Then
                    obj.Execute("Delete from [dbo].[tbl_Client_Site1] where siteID = " & grdLGU.SelectedDataKey.Item(0), CommandType.Text)
                End If

                If FileUpload1.PostedFile.ContentLength <= 65000000 Then

                    Dim fi As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
                    Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
                    FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)

                    objDerived.cmd.Parameters.AddWithValue("@SiteID", 0)
                    objDerived.cmd.Parameters.AddWithValue("@SiteName", Me.TextBox3.Text)
                    objDerived.cmd.Parameters.AddWithValue("@isDefault", 1)
                    objDerived.cmd.Parameters.AddWithValue("@Description", Me.TextBox1.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Province", Me.TextBox2.Text)
                    objDerived.cmd.Parameters.AddWithValue("@AttachedFilename", fi.Name)
                    objDerived.cmd.Parameters.AddWithValue("@Logo", imageBytes)
                    objDerived.cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
                    objDerived.cmd.Parameters.AddWithValue("@City_Name", txtCityName.Text)
                    objDerived.Execute("[dbo].[spSave_Site_Name1]", CommandType.StoredProcedure)

                    ShowConfOK("File has been uploaded.", "Success")
                Else
                    ShowConfOK("Invalid filesize. Choose another file.", "")
                End If
            Else
                ShowConfOK("Invalid filetype. Choose another file.", "")
            End If
        Else
            Dim obj1 As New BaseClasses.AccountClassAcounts
            obj1.Execute("UPDATE dbo.tbl_Client_Site1 SET SiteName ='" & Me.TextBox3.Text & "',Description ='" & Me.TextBox1.Text & "',Province ='" & Me.TextBox2.Text & "',Address = '" & txtAddress.Text & "' where SiteID=" & grdLGU.SelectedDataKey.Item(0), CommandType.Text)
        End If
    End Sub


    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Save()
        LoadGrid()
        data()
    End Sub

    Protected Sub Save()

        ' Declare and instantiate the obj variable
        Dim obj As New BaseClasses.AccountClassAcounts()

        ' Check if file is uploaded
        If (FileUpload1.HasFile) Then

            ' Ensure the file is a JPEG image
            If Not FileUpload1.FileName.ToLower().EndsWith(".jpg") Then
                ' Show message box if the file is not a JPEG
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Please upload a valid file, such as a JPG.');", True)
                Exit Sub ' Stop further execution
            End If

            ' Proceed with file save if it is a JPEG
            If FileUpload1.PostedFile.ContentLength <= 65000000 Then

                Dim fi As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
                Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
                FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)

                objDerived.cmd.Parameters.AddWithValue("@SiteID", 0)
                objDerived.cmd.Parameters.AddWithValue("@SiteName", TextBox3.Text)
                objDerived.cmd.Parameters.AddWithValue("@isDefault", 1)
                objDerived.cmd.Parameters.AddWithValue("@Description", TextBox1.Text)
                objDerived.cmd.Parameters.AddWithValue("@Province", Me.TextBox2.Text)
                objDerived.cmd.Parameters.AddWithValue("@AttachedFilename", fi.Name)
                objDerived.cmd.Parameters.AddWithValue("@Logo", imageBytes)
                objDerived.cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
                objDerived.cmd.Parameters.AddWithValue("@City_Name", txtCityName.Text)
                objDerived.Execute("[dbo].[spSave_Site_Name1]", CommandType.StoredProcedure)

                ' Show success message
                ShowConfOK("File has been uploaded.", "Success")
            Else
                ShowConfOK("Invalid filesize. Choose another file.", "")
            End If
        Else
            ShowConfOK("Invalid filetype. Choose another file.", "")
        End If
    End Sub


    Protected Sub ShowConfOK(ByVal confmsg As String, ByVal conftype As String)
        LoadGrid()
    End Sub

    Protected Sub OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dr As DataRowView = CType(e.Row.DataItem, DataRowView)
            Dim imageUrl As String = "data:image/jpg;base64," & Convert.ToBase64String(CType(dr("logo"), Byte()))
            'CType(e.Row.FindControl("Image1"), Image).ImageUrl = imageUrl
            CType(e.Row.FindControl("Image1"), System.Web.UI.WebControls.Image).ImageUrl = imageUrl
            'Dim Logo As  System.Web.UI.WebControls.Image = CType(e.Item.FindControl("Image1"), System.Web.UI.WebControls.Image)
        End If
    End Sub


    Protected Sub UploadButton_Click(sender As Object, e As System.EventArgs) Handles UploadButton.Click

    End Sub



    Protected Sub data()
        Dim obj As New BaseClasses.AccountClassAcounts
        Dim data As String = obj.GetValue("Select count(*)  from [dbo].[tbl_Client_Site1]", CommandType.Text)
        If data = "0" Then
            Me.Button2.Visible = True
        Else
            Me.Button2.Visible = False
        End If

    End Sub
End Class
