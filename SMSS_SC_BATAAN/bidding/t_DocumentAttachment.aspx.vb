Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.IO
Imports System.Object
Imports System.Web.UI.Control
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebControl
Imports System.Web.UI.WebControls.FileUpload



Partial Class bidding_t_DocumentAttachment
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule
    Dim msg As New MsgeBox
    Dim Doc_ID As Integer
    Dim FName As String

    Private Property dt() As DataTable
        Get
            Return CType(Session("dt"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dt") = value
        End Set
    End Property

    Private Property dtPublicBidding() As DataTable
        Get
            Return CType(Session("dtPublicBidding"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPublicBidding") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Request.UserAgent.IndexOf("AppleWebKit") > 0) Then
            Request.Browser.Adapters.Clear()
        End If

        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If
        Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
        Dim role() As String = Roles.GetRolesForUser(usr.UserName)
        Dim rolename As String = role(0)
        Session("RoleName") = rolename


        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")
            dtPublicBidding = objDerived.GetDataTable("EXEC [AMS].[sp_PublicBiddingList]", CommandType.Text)
            If dtPublicBidding.Rows.Count < 10 Then
                dtPublicBidding.Merge(CreateTabl2(9 - dtPublicBidding.Rows.Count))
            End If
            grdPurchaseRequest.DataSource = dtPublicBidding
            grdPurchaseRequest.DataBind()

            grdDocuments.DataSource = CreateTable1(4)
            grdDocuments.DataBind()

            txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

        End If
    End Sub

    Protected Sub grdPurchaseRequest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPurchaseRequest.SelectedIndexChanged
        If grdPurchaseRequest.SelectedDataKey("pre_procurement_hdr_id") = 0 Then
            FileUpload1.Enabled = False
        Else
            FileUpload1.Enabled = True
        End If

        lblNoti.Visible = False
        LoadDocumentList()
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtPublicBidding.DefaultView

        If ddSearch.SelectedItem.Text = "PR Number" Then
            myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%'"

        ElseIf ddSearch.SelectedItem.Text = "PPA Description" Then
            myview.RowFilter = "project_name like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%'"

        End If

        grdPurchaseRequest.DataSource = myview
        grdPurchaseRequest.DataBind()

        Session("Search") = 1
    End Sub

    Protected Sub grdPurchaseRequest_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdPurchaseRequest, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdPurchaseRequest_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdPurchaseRequest.PageIndexChanging
        grdPurchaseRequest.PageIndex = e.NewPageIndex
        grdPurchaseRequest.DataSource = dtPublicBidding
        grdPurchaseRequest.DataBind()

    End Sub

    Protected Sub LoadDocumentList()
        dt = objDerived.GetDataTable("EXEC [AMS].[sp_DocumentAttachment_List] '" & grdPurchaseRequest.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        If dt.Rows.Count < 5 Then
            dt.Merge(CreateTable1(4 - dt.Rows.Count))
        End If
        grdDocuments.DataSource = dt
        grdDocuments.DataBind()
    End Sub

    Protected Sub grdDocuments_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDocuments.PageIndexChanging
        grdDocuments.PageIndex = e.NewPageIndex
        grdDocuments.DataSource = dt
        grdDocuments.DataBind()
    End Sub

    Protected Sub UploadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (FileUpload1.HasFile) Then
            lblNoti.Visible = False
            If FileUpload1.FileName.ToLower.Contains(".jpg") Or FileUpload1.FileName.ToLower.Contains(".png") Or FileUpload1.FileName.ToLower.Contains(".doc") Or FileUpload1.FileName.ToLower.Contains(".rar") Or FileUpload1.FileName.ToLower.Contains(".zip") Or FileUpload1.FileName.ToLower.Contains(".pdf") Or FileUpload1.FileName.ToLower.Contains(".xls") Or FileUpload1.FileName.ToLower.Contains(".xlsx") Then
                If FileUpload1.PostedFile.ContentLength <= 25000000 Then
                    Dim fi As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
                    Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
                    FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)

                    objDerived.cmd.Parameters.AddWithValue("@Document_ID", 0)
                    objDerived.cmd.Parameters.AddWithValue("@PRHdr_ID", grdPurchaseRequest.SelectedDataKey("prhdr_id"))
                    objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", grdPurchaseRequest.SelectedDataKey("pre_procurement_hdr_id"))
                    objDerived.cmd.Parameters.AddWithValue("@DateUploaded", Date.Today.ToString("MM/dd/yyyy"))
                    objDerived.cmd.Parameters.AddWithValue("@AttachedFilename", fi.Name)
                    objDerived.cmd.Parameters.AddWithValue("@AttachedFile", imageBytes)
                    objDerived.cmd.Parameters.AddWithValue("@UserID", Session("@UserName"))
                    objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
                    objDerived.Execute("@CurrID", "[AMS].[spSave_Document_Attachment]", CommandType.StoredProcedure, Nothing)

                    msg.UserMsgBox("File has been uploaded.", Me, False)
                    LoadDocumentList()
                Else
                    msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                End If
            Else
                msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
            End If
        Else
            lblNoti.Visible = True
        End If
    End Sub


    Protected Sub LoadFile()
        If grdDocuments.SelectedDataKey("Location") = "SMSS" Then
            CreateFile(Doc_ID, FName, "SELECT AttachedFile FROM AMS.Document_Attachment WHERE Document_ID = @param")
        ElseIf grdDocuments.SelectedDataKey("Location") = "BOSS" Then
            CreateFile(Doc_ID, FName, "SELECT AttachedFile FROM LnkdSrvrBOSS.GEOBOS.DBO.Attached_Document WHERE DocumentId = @param")
        End If

    End Sub



    Public Sub CreateFile(ByVal UniqueID As String, ByVal file_name As String, ByVal cmdstr As String)
        Dim oFileStream As System.IO.FileStream
        Dim connection As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("constr").ToString)
        Dim buffer As Byte()

        Try
            connection.Open()
            Dim command As New SqlCommand(cmdstr, connection)
            command.Parameters.AddWithValue("@param", UniqueID)
            Using reader As SqlDataReader = command.ExecuteReader
                Do While reader.Read
                    buffer = DirectCast(reader.GetValue(0), Byte())
                Loop
            End Using
        Catch ex As Exception

        Finally
            connection.Close()
        End Try

        If System.IO.Directory.Exists(Server.MapPath("..\") & "obj\temp\Downloads\") Then
            'delete the directory including the lates files that the client has downloaded manually.
            Dim s As String
            For Each s In System.IO.Directory.GetFiles(Server.MapPath("..\") & "\obj\temp\Downloads\")
                System.IO.File.Delete(s)
            Next s
        Else
            'create a new directory for the client.
            Directory.CreateDirectory(Server.MapPath("..\") & "obj\temp\Downloads\")
        End If

        'write the file for manual download.
        Dim filepath As String = Server.MapPath("..\") & "obj\temp\Downloads\" & "\" & file_name

        oFileStream = New System.IO.FileStream(filepath, System.IO.FileMode.Create)
        oFileStream.Write(buffer, 0, buffer.Length)
        oFileStream.Close()
        Page.Response.Redirect("..\obj\temp\Downloads\" & "\" & file_name)

    End Sub

    Protected Sub grdDocuments_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocuments.SelectedIndexChanged
        FName = grdDocuments.SelectedDataKey("AttachedFilename")
        Doc_ID = grdDocuments.SelectedDataKey("Document_ID")
        LoadFile()
    End Sub

    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Document_ID", GetType(Long))
        dt.Columns.Add("AttachedFilename", GetType(String))
        dt.Columns.Add("DateUploaded", GetType(Date))
        dt.Columns.Add("Location", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Document_ID") = DBNull.Value
            dr("AttachedFilename") = DBNull.Value
            dr("DateUploaded") = DBNull.Value
            dr("Location") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function CreateTabl2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("project_name", GetType(String))
        dt.Columns.Add("opening_date", GetType(Date))
        dt.Columns.Add("opening_venue", GetType(String))
   
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("pre_procurement_hdr_id") = 0
            dr("ABC") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("project_name") = DBNull.Value
            dr("opening_date") = DBNull.Value
            dr("opening_venue") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function


End Class
