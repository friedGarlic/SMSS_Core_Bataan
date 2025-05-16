Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.Encoding
Imports System.IO.Stream
Imports System
Imports System.Text
Imports System.Data.OleDb




Partial Class Inventory_t_InventoryTaking
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private CsvDataReader



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If
          
            ddYear.DataSource = objDerived.GetDataTable("SELECT [year] FROM [AMS].[APP] WHERE [status] <> 3 ORDER BY [year] DESC", CommandType.Text)
            ddYear.DataTextField = "year"
            ddYear.DataValueField = "year"
            ddYear.DataBind()
            ddYear.Items.Insert(0, "Select")

            lblMsg.Visible = False

            '============== REQUIREMENT FOR UPLOADING FUNCTION ==============
            Page.Form.Attributes.Add("enctype", "multipart/form-data")

        End If
    End Sub

    Protected Sub Upload(ByVal sender As Object, ByVal e As EventArgs)
        If ddYear.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select calendar year.")
            Exit Sub

        End If

        'Upload and save the file
        If FileUpload1.HasFile Then
            Dim csvPath As String = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName)
            FileUpload1.SaveAs(csvPath)

            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(4) {New DataColumn("IDs", GetType(String)), New DataColumn("EPC", GetType(String)), New DataColumn("UserData", GetType(String)), New DataColumn("ReadTime", GetType(String)), New DataColumn("Status", GetType(String))})

            Dim x1 As Integer = 0
            Dim csvData As String = File.ReadAllText(csvPath)

            For Each row As String In csvData.Split(ControlChars.Lf)
                If Not String.IsNullOrEmpty(row) Then
                    dt.Rows.Add()
                    Dim i As Integer = 0
                    For Each cell As String In row.Split(","c)
                        If i = 5 Then
                            x1 = 1
                        End If

                        If x1 = 0 Then
                            dt.Rows(dt.Rows.Count - 1)(i) = cell
                            i += 1
                        Else
                            Exit For
                        End If
                    Next
                End If

                x1 = 0
            Next


            Dim consString As String = ConfigurationManager.ConnectionStrings("constr").ToString '"Data Source=DEV2K16\BATAAN_2K16;Initial Catalog=SMSS_Premium; User Id=sa; Password=P@ssw0rd;"

            Using con As New SqlConnection(consString)
                Using sqlBulkCopy As New SqlBulkCopy(con)
                    'Set the database table name
                    sqlBulkCopy.DestinationTableName = "AMS.Tb_RFID_InventoryTaking"
                    con.Open()
                    sqlBulkCopy.WriteToServer(dt)
                    con.Close()
                End Using
            End Using


            '=================== CONVERT HEX TO ASCII AND SAVE TO [AMS].[tb_RFID] ===================
            Session("CYear") = ddYear.SelectedItem.Text
            objDerived.GetRecords("EXEC [AMS].[sp_SavePropNo_HexToASCII] '" & Session("CYear") & "'", CommandType.Text)

            lblMsg.Visible = True

            ddYear.DataSource = objDerived.GetDataTable("SELECT [year] FROM [AMS].[APP] WHERE [status] <> 3 ORDER BY [year] DESC", CommandType.Text)
            ddYear.DataTextField = "year"
            ddYear.DataValueField = "year"
            ddYear.DataBind()
            ddYear.Items.Insert(0, "Select")

            btnPreview.Enabled = True

        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No files has been uploaded.")

        End If
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/Inventory/rpt_RFID_InventoryTaking.aspx")
    End Sub
End Class
