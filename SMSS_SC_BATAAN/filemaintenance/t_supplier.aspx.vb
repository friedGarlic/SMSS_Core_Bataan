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
Imports System.Collections.Generic
Imports System.Configuration

Partial Class t_supplier
    Inherits System.Web.UI.Page
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal
    Private save As New Supplier
    Private saveD As New Document
    Dim obj As New AccessRule
    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl
    Private obr_hdr As New t_purchase_request_obr_hdr
#Region "property"
    Private Property pBody() As DataTable
        Get
            Return CType(Session("pBody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBody") = value
        End Set
    End Property
    Private Property dtClass() As DataTable
        Get
            Return CType(Session("dtClass"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtClass") = value
        End Set
    End Property
    Private Property DrpGenAcc() As DataTable
        Get
            Return CType(Session("DrpGenAcc"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("DrpGenAcc") = value
        End Set
    End Property
    Private Property DrpSubClassF() As DataTable
        Get
            Return CType(Session("DrpSubClassF"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("DrpSubClassF") = value
        End Set
    End Property
    Private Property pParticular() As DataTable
        Get
            Return CType(Session("pParticular"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pParticular") = value
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
    Private Property dtPPMP_Items() As DataTable
        Get
            Return CType(Session("dtPPMP_Items"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPPMP_Items") = value
        End Set
    End Property
    Private Property dtPR_Items() As DataTable
        Get
            Return CType(Session("dtPR_Items"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPR_Items") = value
        End Set
    End Property
#End Region
#Region "Procedure"
    'Public Sub txtboxEnable(ByVal val As Boolean)
    '    For Each c As Control In Form.Controls
    '        If TypeOf c Is ContentPlaceHolder Then
    '            Dim cp As ContentPlaceHolder = CType(c, ContentPlaceHolder)
    '            For Each p As Control In cp.Controls

    '                If TypeOf p Is Panel Then
    '                    Dim p2 As Panel = CType(p, Panel)
    '                    For Each txt1 As Control In p2.Controls
    '                        If TypeOf txt1 Is TextBox Then
    '                            CType(txt1, TextBox).ReadOnly = val
    '                        End If
    '                    Next

    '                End If

    '            Next
    '        End If
    '    Next

    '    txtsearch.ReadOnly = False
    '    ddtax.Enabled = IIf(val = True, False, True)
    'End Sub
    'Public Sub txtboxClear()
    '    For Each c As Control In Form.Controls
    '        If TypeOf c Is ContentPlaceHolder Then
    '            Dim cp As ContentPlaceHolder = CType(c, ContentPlaceHolder)
    '            For Each p As Control In cp.Controls

    '                If TypeOf p Is Panel Then
    '                    Dim p2 As Panel = CType(p, Panel)
    '                    For Each txt1 As Control In p2.Controls
    '                        If TypeOf txt1 Is TextBox Then
    '                            CType(txt1, TextBox).Text = ""
    '                        End If
    '                    Next

    '                End If

    '            Next
    '        End If
    '    Next


    'End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If
            Dim dt As New DataTable
            DropdownClassification()
            LoadSupplierList()
            grdItems_ForSupplier.datasource = Nothing
            grdItems_ForSupplier.databind()
            dt = Nothing
            txtcompany.ReadOnly = True
            txtadd1.ReadOnly = True
            txtfaxno.ReadOnly = True
            ddtax.Enabled = False
            txttin.ReadOnly = True
            'txtname.ReadOnly = True
            'txtadd2.ReadOnly = True
            'txtcontactno.ReadOnly = True

            txtsearch.Attributes.Add("onkeypress", "return fun1(event,'" & Button3.ClientID & "')")


        End If
    End Sub

    Protected Sub LoadSupplierList()
        pBody = objDerived.GetDataTable("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
        gvbody.DataSource = pBody
        gvbody.DataBind()

        Session("SearchSuppName") = 0
    End Sub

    Protected Sub gvbody_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvbody.PageIndexChanging
        If Session("SearchSuppName") = 0 Then
            pBody = objDerived.GetDataTable("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
          
        ElseIf Session("SearchSuppName") = 1 Then
            Dim SuppName As String = objDerived.replaceapostrophe(txtsearch.Text)
            pBody = objDerived.GetDataTable("SELECT * FROM dbo.Supplier WHERE SuppName LIKE '%" & SuppName & "%' ORDER BY SuppName", CommandType.Text)
        End If

        gvbody.PageIndex = e.NewPageIndex
        gvbody.DataSource = pBody
        gvbody.DataBind()

    End Sub
    Public Sub ClearAllSupplier()
        txtcompany.text = ""
        txtadd1.text = ""
        txtofficeno.text = ""
        txtfaxno.text = ""
        ddtax.selecteditem.text = "VAT"
        txttin.text = ""
        txtPS.text = ""
        txtAccNo.text = ""
        txtAccDate.text = ""
        txtAccUntil.text = ""
        txtAccApprovedBy.text = ""
        txtMOA.text = ""
        DTI_Regno.text = ""
        Iss_DTI.text = ""
        DI_DTI.text = ""
        Val_DTI.text = ""
        Tax_no.text = ""
        Iss_tax.text = ""
        DI_Tax.text = ""
        Val_tax.text = ""
        Sec_Regno.text = ""
        Iss_Sec.text = ""
        DI_Sec.text = ""
        Val_Sec.text = ""
        Phil_no.text = ""
        Iss_phil.text = ""
        DI_phil.text = ""
        Val_phil.text = ""
        BP_No.text = ""
        Iss_Bp.text = ""
        DI_BP.text = ""
        Val_BP.text = ""
        PCAB_No.text = ""
        Iss_PCAB.text = ""
        DI_PCAB.text = ""
        Val_PCAB.text = ""
        FDA_No.text = ""
        Iss_FDA.text = ""
        DI_FDA.text = ""
        Val_FDA.text = ""
        cFullName.text = ""
        cAddress.text = ""
        cMobileNum.text = ""
        CEmailAdd.text = ""
        Position.text = ""
        CBdate.text = ""
        CAge.text = ""
        cGender.SelectedItem.text = "Select"
        cNationality.text = ""
        Image1.imageUrl = "~/images/noPicture.jpg"
        Image2.imageUrl = "~/images/noPicture.jpg"
    End Sub
    Protected Sub gvbody_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvbody.SelectedIndexChanged
        hdnItemSubClass.Value = gvbody.SelectedDataKey(0)
        Try
            btnDelete.Enabled = True
            txtcompany.ReadOnly = True
            txtadd1.ReadOnly = True
            txtfaxno.ReadOnly = True
            ddtax.Enabled = False
            txttin.ReadOnly = True
            'txtname.ReadOnly = True
            'txtadd2.ReadOnly = True
            'txtcontactno.ReadOnly = True
            txtPS.ReadOnly = True

            txtAccNo.ReadOnly = True
            txtAccDate.ReadOnly = True
            txtAccUntil.ReadOnly = True
            txtAccApprovedBy.ReadOnly = True
            txtMOA.ReadOnly = True


            ClearAllSupplier()
            txtcompany.Text = gvbody.SelectedDataKey(1)
            txtadd1.Text = gvbody.SelectedDataKey(2)
            CFullName.Text = gvbody.SelectedDataKey(3)
            txtofficeno.Text = IIf(IsDBNull(gvbody.SelectedDataKey(4)), "", (gvbody.SelectedDataKey(4)))
            txtfaxno.Text = IIf(IsDBNull(gvbody.SelectedDataKey(5)), "", (gvbody.SelectedDataKey(5)))
            txttin.Text = IIf(IsDBNull(gvbody.SelectedDataKey(6)), "", (gvbody.SelectedDataKey(6)))
            txtPS.Text = objDerived.GetValue("SELECT ProductService FROM [dbo].[View_SuppliersInfo] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            CAddress.Text = IIf(IsDBNull(gvbody.SelectedDataKey(7)), "", (gvbody.SelectedDataKey(7)))
            CMobileNum.Text = IIf(IsDBNull(gvbody.SelectedDataKey(8)), "", (gvbody.SelectedDataKey(8)))
            CEmailAdd.Text = IIf(IsDBNull(gvbody.SelectedDataKey(10)), "", (gvbody.SelectedDataKey(10)))
            Position.text = IIf(IsDBNull(gvbody.SelectedDataKey(11)), "", (gvbody.SelectedDataKey(11)))
            CBdate.text = IIf(IsDBNull(gvbody.SelectedDataKey(12)), "", (gvbody.SelectedDataKey(12)))
            CAge.text = IIf(IsDBNull(gvbody.SelectedDataKey(13)), "", (gvbody.SelectedDataKey(13)))
            cGender.SelectedItem.text = IIf(IsDBNull(gvbody.SelectedDataKey(14)), "", (gvbody.SelectedDataKey(14)))
            CNationality.text = IIf(IsDBNull(gvbody.SelectedDataKey(15)), "", (gvbody.SelectedDataKey(15)))
            ddtax.SelectedValue = gvbody.SelectedDataKey(9)
            txtOwner_Name.text = IIf(IsDBNull(gvbody.SelectedDataKey(16)), "", (gvbody.SelectedDataKey(16)))
            txtOwner_Addresss.text = IIf(IsDBNull(gvbody.SelectedDataKey(17)), "", (gvbody.SelectedDataKey(17)))
            txtContactOwner_ContactNo.text = IIf(IsDBNull(gvbody.SelectedDataKey(18)), "", (gvbody.SelectedDataKey(18)))
            txtOwner_EmailAddress.text = IIf(IsDBNull(gvbody.SelectedDataKey(19)), "", (gvbody.SelectedDataKey(19)))



            Dim Company As String = objDerived.GetValue("select AttachedFile from dbo.Supplier where Supplier_Id = '" & gvbody.SelectedDataKey(0) & "'", CommandType.Text)
            Dim Contact As String = objDerived.GetValue("select CPAttachedFile from dbo.Supplier where Supplier_Id = '" & gvbody.SelectedDataKey(0) & "'", CommandType.Text)

            If Company = "" Then
                Image2.ImageUrl = "~/images/NoPicture.jpg"
            Else
                Image2.ImageUrl = "~/images/" & Company
            End If

            If Contact = "" Then
                Image1.ImageUrl = "~/images/NoPicture.jpg"
            Else
                Image1.ImageUrl = "~/images/" & Contact
            End If




            Try
                ' Get the image data as a byte array
                Dim supplierId As String = gvbody.SelectedDataKey(0).ToString()
                Dim query As String = "SELECT AttachedF FROM dbo.Supplier WHERE Supplier_Id = @SupplierId"

                Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@SupplierId", supplierId)
                        connection.Open()

                        ' Execute the SQL query and get the image data
                        Dim imageBytes() As Byte = DirectCast(command.ExecuteScalar(), Byte())

                        ' Check if imageBytes is not null and contains data
                        If imageBytes IsNot Nothing AndAlso imageBytes.Length > 0 Then
                            ' Convert the byte array to a Base64 string
                            Dim base64String As String = Convert.ToBase64String(imageBytes)

                            ' Set the Image control's ImageUrl property to display the image
                            Image2.ImageUrl = "data:image/jpeg;base64," & base64String
                        Else
                            ' If no image data is found, display a placeholder or default image
                            Image2.ImageUrl = "~/images/NoPicture.jpg"
                        End If
                        connection.close()
                    End Using
                End Using
            Catch ex As Exception
                ' Handle exceptions here, e.g., log the error or display a user-friendly message
                'MsgBox(ex.Message)
            End Try


            Try
                ' Get the image data as a byte array
                Dim supplierId1 As String = gvbody.SelectedDataKey(0).ToString()
                Dim query1 As String = "SELECT CPAttachedF FROM dbo.Supplier WHERE Supplier_Id = @SupplierId"

                Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
                    Using command As New SqlCommand(query1, connection)
                        command.Parameters.AddWithValue("@SupplierId", supplierId1)
                        connection.Open()

                        ' Execute the SQL query and get the image data
                        Dim imageBytes() As Byte = DirectCast(command.ExecuteScalar(), Byte())

                        ' Check if imageBytes is not null and contains data
                        If imageBytes IsNot Nothing AndAlso imageBytes.Length > 0 Then
                            ' Convert the byte array to a Base64 string
                            Dim base64String As String = Convert.ToBase64String(imageBytes)

                            ' Set the Image control's ImageUrl property to display the image
                            Image1.ImageUrl = "data:image/jpeg;base64," & base64String
                        Else
                            ' If no image data is found, display a placeholder or default image
                            Image1.ImageUrl = "~/images/NoPicture.jpg"
                        End If
                        connection.close()
                    End Using
                End Using
            Catch ex As Exception
                ' Handle exceptions here, e.g., log the error or display a user-friendly message
                'MsgBox(ex.Message)
            End Try

            Try
                ' Get the image data as a byte array
                Dim supplierId1 As String = gvbody.SelectedDataKey(0).ToString()
                Dim query1 As String = "SELECT AttachedFOwner FROM dbo.Supplier WHERE Supplier_Id = @SupplierId"

                Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
                    Using command As New SqlCommand(query1, connection)
                        command.Parameters.AddWithValue("@SupplierId", supplierId1)
                        connection.Open()

                        ' Execute the SQL query and get the image data
                        Dim imageBytes() As Byte = DirectCast(command.ExecuteScalar(), Byte())

                        ' Check if imageBytes is not null and contains data
                        If imageBytes IsNot Nothing AndAlso imageBytes.Length > 0 Then
                            ' Convert the byte array to a Base64 string
                            Dim base64String As String = Convert.ToBase64String(imageBytes)

                            ' Set the Image control's ImageUrl property to display the image
                            Image3.ImageUrl = "data:image/jpeg;base64," & base64String
                        Else
                            ' If no image data is found, display a placeholder or default image
                            Image3.ImageUrl = "~/images/NoPicture.jpg"
                        End If
                        connection.close()
                    End Using
                End Using
            Catch ex As Exception
                ' Handle exceptions here, e.g., log the error or display a user-friendly message
                'MsgBox(ex.Message)
            End Try






            txtAccNo.Text = objDerived.GetValue("SELECT AccreditationNo FROM [dbo].[View_SuppliersInfo] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            txtAccDate.Text = objDerived.GetValue("SELECT DateAccreditation FROM [dbo].[View_SuppliersInfo] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            txtAccUntil.Text = objDerived.GetValue("SELECT validUntil FROM [dbo].[View_SuppliersInfo] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            txtAccApprovedBy.Text = objDerived.GetValue("SELECT ApprovedBy FROM [dbo].[View_SuppliersInfo] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            txtMOA.Text = objDerived.GetValue("SELECT MOA FROM [dbo].[View_SuppliersInfo] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

            DTI_RegNo.Text = objDerived.GetValue("SELECT DTI_No FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Iss_DTI.Text = objDerived.GetValue("SELECT IssuedAt_DTI FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            DI_DTI.Text = objDerived.GetValue("SELECT Date_Issued_DTI FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Val_DTI.Text = objDerived.GetValue("SELECT Validity_DTI FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

            Tax_no.Text = objDerived.GetValue("SELECT Tax_No FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Iss_Tax.Text = objDerived.GetValue("SELECT IssuedAt_Tax FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            DI_Tax.Text = objDerived.GetValue("SELECT Date_Issued_Tax FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Val_Tax.Text = objDerived.GetValue("SELECT Validity_Tax FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

            Sec_Regno.Text = objDerived.GetValue("SELECT Sec_No FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Iss_Sec.Text = objDerived.GetValue("SELECT IssuedAt_Sec FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            DI_Sec.Text = objDerived.GetValue("SELECT Date_Issued_Sec FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Val_Sec.Text = objDerived.GetValue("SELECT Validity_Sec FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

            Phil_no.Text = objDerived.GetValue("SELECT PhilGEPS_No FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Iss_Phil.Text = objDerived.GetValue("SELECT IssuedAt_PG FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            DI_Phil.Text = objDerived.GetValue("SELECT Date_Issued_PG FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Val_Phil.Text = objDerived.GetValue("SELECT Validity_PG FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

            BP_no.Text = objDerived.GetValue("SELECT BusinessPermit_No FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Iss_BP.Text = objDerived.GetValue("SELECT IssuedAt_BP FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            DI_BP.Text = objDerived.GetValue("SELECT Date_Issued_BP FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Val_BP.Text = objDerived.GetValue("SELECT Validity_BP FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

            PCAB_no.Text = objDerived.GetValue("SELECT PCAB_No FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Iss_PCAB.Text = objDerived.GetValue("SELECT IssuedAt_PCAB FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            DI_PCAB.Text = objDerived.GetValue("SELECT Date_Issued_PCAB FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Val_PCAB.Text = objDerived.GetValue("SELECT Validity_PCAB FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

            FDA_no.Text = objDerived.GetValue("SELECT FDA_No FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Iss_FDA.Text = objDerived.GetValue("SELECT IssuedAt_FDA FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            DI_FDA.Text = objDerived.GetValue("SELECT Date_Issued_FDA FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            Val_FDA.Text = objDerived.GetValue("SELECT Validity_FDA FROM [dbo].[Document_details] WHERE Supplier_Id = '" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)


            btnedit.Enabled = True
            btnsave.Enabled = False
        Catch ex As Exception
            btnedit.Enabled = True
            btnsave.Enabled = False
        End Try
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtcompany.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all required fields.")
            Exit Sub
        End If


        'Try
        If Me.Session("save") = "new" Then

            save.SuppName = txtcompany.Text
            save.Address1 = txtadd1.Text
            save.Officeno = txtofficeno.Text
            save.Faxno = txtfaxno.Text
            save.TIN = txttin.Text
            save.ContactP = cFullName.Text
            save.Address2 = cAddress.Text
            save.contactno = cMobileNum.Text
            save.TaxType = ddtax.SelectedItem.Value
            save.AccreditationNo = txtAccNo.Text
            save.EmailAddress = CEmailAdd.text

            If CBdate.text = "" Then
                save.CBdate = "1/1/1900"
            Else
                save.CBdate = CBdate.text
            End If
            save.CBdate = CBdate.text
            save.CAge = CAge.text
            save.Position = Position.text



            save.CNationality = CNationality.text
            save.CGender = cGender.SelectedItem.Text
            If txtAccDate.Text = "" Then
                save.DateAccreditation = "1/1/1900"
            Else
                save.DateAccreditation = txtAccDate.Text
            End If

            If txtAccUntil.Text = "" Then
                save.validUntil = "1/1/1900"
            Else
                save.validUntil = txtAccUntil.Text
            End If

            save.ProductService = txtPS.Text
            save.ApprovedBy = txtAccApprovedBy.Text
            save.MOA = txtMOA.Text


            '*****SAVING OF IMAGE OF COMPANY****

            If (FileUpload1.HasFile) Then
                Dim fi2 As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
                Dim extension As String = Path.GetExtension(fi2.Name)
                lblNoti.Visible = False
                If extension = ".jpg" Or extension = ".png" Or extension = ".doc" Or extension = ".rar" Or extension = ".zip" Or extension = ".pdf" Or extension = ".xls" Or extension = ".xlsx" Then
                    If FileUpload1.PostedFile.ContentLength <= 25000000 Then
                        Dim fi As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
                        Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
                        FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)


                        objDerived.cmd.Parameters.AddWithValue("@AttachedF", imageBytes)
                        save.AttachedF = imageBytes
                        Attched.text = FileUpload1.PostedFile.FileName
                        Dim FName As String = FileUpload1.PostedFile.FileName
                        FileUpload1.SaveAs(Server.MapPath("..\") & "images\" & FName)
                        Dim path1 As String = Image2.ImageUrl
                        Dim path2 As String = System.IO.Path.GetDirectoryName(FName)
                        'Dim path3 As String() = path2.Split("\")

                        'msgbox(path3(path3.Length - 2))


                        'path1 = path + FileUpload1.FileName
                        'image2.ImageUrl = "~/images/" + FName


                        Image2.ImageUrl = Server.MapPath("..\") & "images\" & FName


                        'msg.UserMsgBox("File has been uploaded.", Me, False)

                        Image2.ImageUrl = "~/images/" & FName
                    Else
                        msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                    End If
                Else
                    msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                End If

            Else
                lblNoti.Visible = True
            End If

            '****End  SAVING Of IMAGE Of COMPANY****


            '***SAVING OF IMAGE OF CONTACT PERSON***
            If (FileUpload2.HasFile) Then
                    Dim fi3 As FileInfo = New FileInfo(Me.FileUpload2.PostedFile.FileName)
                    Dim extension1 As String = Path.GetExtension(fi3.Name)
                    lblNoti.Visible = False
                    If extension1 = ".jpg" Or extension1 = ".png" Or extension1 = ".doc" Or extension1 = ".rar" Or extension1 = ".zip" Or extension1 = ".pdf" Or extension1 = ".xls" Or extension1 = ".xlsx" Then
                        If FileUpload2.PostedFile.ContentLength <= 25000000 Then
                            Dim fi As FileInfo = New FileInfo(Me.FileUpload2.PostedFile.FileName)
                            Dim imageBytes1(FileUpload2.PostedFile.InputStream.Length) As Byte
                            FileUpload2.PostedFile.InputStream.Read(imageBytes1, 0, imageBytes1.Length)


                            objDerived.cmd.Parameters.AddWithValue("@CPAttachedF", imageBytes1)
                            save.CPAttachedF = imageBytes1
                            CPAttached.text = FileUpload2.PostedFile.FileName
                            Dim FName As String = FileUpload2.PostedFile.FileName
                            FileUpload2.SaveAs(Server.MapPath("..\") & "images\" & FName)
                            Dim path1 As String = Image1.ImageUrl
                            Dim path2 As String = System.IO.Path.GetDirectoryName(FName)
                        'Dim path3 As String() = path2.Split("\")

                        'msgbox(path3(path3.Length - 2))


                        'path1 = path + FileUpload1.FileName
                        'image2.ImageUrl = "~/images/" + FName


                        Image1.ImageUrl = Server.MapPath("..\") & "images\" & FName


                        'msg.UserMsgBox("File has been uploaded.", Me, False)

                        Image1.ImageUrl = "~/images/" & FName
                    Else
                            msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                        End If
                    Else
                        msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                    End If

                Else
                lblNoti.Visible = False
            End If


            '***END OF SAVING OF IMAGE OF CONTACT PERSON***

            save.AttachedFile = Attched.text
            save.CPAttachedFile = CPAttached.text


            save.FullnameOwner = txtOwner_Name.text
            save.AddressOwner = txtOwner_Addresss.text
            save.MobileNoOwner = txtContactOwner_ContactNo.text
            save.EmailAddressOwner = txtOwner_EmailAddress.text



            If (FileUpload3.HasFile) Then
                Dim fi3 As FileInfo = New FileInfo(Me.FileUpload3.PostedFile.FileName)
                Dim extension1 As String = Path.GetExtension(fi3.Name)
                lblNoti.Visible = False
                If extension1 = ".jpg" Or extension1 = ".png" Or extension1 = ".doc" Or extension1 = ".rar" Or extension1 = ".zip" Or extension1 = ".pdf" Or extension1 = ".xls" Or extension1 = ".xlsx" Then
                    If FileUpload3.PostedFile.ContentLength <= 25000000 Then
                        Dim fi As FileInfo = New FileInfo(Me.FileUpload3.PostedFile.FileName)
                        Dim imageBytes2(FileUpload3.PostedFile.InputStream.Length) As Byte
                        FileUpload3.PostedFile.InputStream.Read(imageBytes2, 0, imageBytes2.Length)


                        objDerived.cmd.Parameters.AddWithValue("@AttachedFOwner", imageBytes2)
                        save.AttachedFOwner = imageBytes2
                        hndFileOwner.value = FileUpload3.PostedFile.FileName
                        Dim FName As String = FileUpload3.PostedFile.FileName
                        FileUpload3.SaveAs(Server.MapPath("..\") & "images\" & FName)
                        Dim path1 As String = Image3.ImageUrl
                        Dim path2 As String = System.IO.Path.GetDirectoryName(FName)
                        'Dim path3 As String() = path2.Split("\")

                        'msgbox(path3(path3.Length - 2))


                        'path1 = path + FileUpload1.FileName
                        'image2.ImageUrl = "~/images/" + FName


                        Image3.ImageUrl = Server.MapPath("..\") & "images\" & FName


                        'msg.UserMsgBox("File has been uploaded.", Me, False)

                        Image3.ImageUrl = "~/images/" & FName
                    Else
                        msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                    End If
                Else
                    msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                End If

            Else
                lblNoti.Visible = False
            End If

            save.AttachedFileOwner = hndFileOwner.value

            save.saveSupplier()

            Dim supplierid As Long = objDerived.GetValue("select max(supplier_id) from dbo.Supplier", commandtype.text)
            saveD.Supplier_ID = supplierid
            saveD.IssuedAt_DTI = Iss_DTI.text
            saveD.Date_Issued_DTI = DI_DTI.text
            saveD.Validity_DTI = Val_DTI.text

            saveD.IssuedAt_Tax = Iss_Tax.text
            saveD.Date_Issued_Tax = DI_Tax.text
            saveD.Validity_Tax = Val_Tax.text

            saveD.IssuedAt_Sec = Iss_Sec.text
            saveD.Date_Issued_Sec = DI_Sec.text
            saveD.Validity_Sec = Val_Sec.text

            saveD.IssuedAt_PG = Iss_Phil.text
            saveD.Date_Issued_PG = DI_Phil.text
            saveD.Validity_PG = Val_Phil.text

            saveD.IssuedAt_BP = Iss_BP.text
            saveD.Date_Issued_BP = DI_BP.text
            saveD.Validity_BP = Val_BP.text

            saveD.IssuedAt_PCAB = Iss_PCAB.text
            saveD.Date_Issued_PCAB = DI_PCAB.text
            saveD.Validity_PCAB = Val_PCAB.text

            saveD.IssuedAt_FDA = Iss_FDA.text
            saveD.Date_Issued_FDA = DI_FDA.text
            saveD.Validity_FDA = Val_FDA.text

            saveD.DTI_No = DTI_RegNo.text
            saveD.Tax_No = Tax_No.text
            saveD.Sec_No = Sec_RegNo.text
            saveD.PhilGEPS_No = Phil_No.text
            saveD.BusinessPermit_No = BP_No.text
            saveD.PCAB_No = PCAB_No.text
            saveD.FDA_No = FDA_No.text


            saveD.saveDocument()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been saved Successfully")

            '***EDITTING***
        Else
            save.Supplier_Id = gvbody.SelectedDataKey(0)
            save.SuppName = txtcompany.Text
            save.Address1 = txtadd1.Text
            save.Officeno = txtofficeno.Text
            save.Faxno = txtfaxno.Text
            save.TIN = txttin.Text
            save.ContactP = cFullName.Text
            save.Address2 = cAddress.Text
            save.contactno = cMobileNum.Text
            save.TaxType = ddtax.SelectedItem.Value
            save.AccreditationNo = txtAccNo.Text
            save.EmailAddress = CEmailAdd.text

            If CBdate.text = "" Then
                save.CBdate = "1/1/1900"
            Else
                save.CBdate = CBdate.text
            End If
            save.CAge = CAge.text
            save.Position = Position.text
            save.CGender = cGender.SelectedItem.Text
            save.CNationality = CNationality.text
            save.CGender = cGender.SelectedItem.Text
            If txtAccDate.Text = "" Then
                save.DateAccreditation = "1/1/1900"
            Else
                save.DateAccreditation = txtAccDate.Text
            End If

            If txtAccUntil.Text = "" Then
                save.validUntil = "1/1/1900"
            Else
                save.validUntil = txtAccUntil.Text
            End If

            save.ApprovedBy = txtAccApprovedBy.Text
            save.MOA = txtMOA.Text
            save.ProductService = txtPS.Text
            '***START OF EDITTING IMAGE2***
            If (FileUpload1.HasFile) Then
                Dim fi2 As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
                Dim extension As String = Path.GetExtension(fi2.Name)
                lblNoti.Visible = False
                If extension = ".jpg" Or extension = ".png" Or extension = ".doc" Or extension = ".rar" Or extension = ".zip" Or extension = ".pdf" Or extension = ".xls" Or extension = ".xlsx" Then
                    If FileUpload1.PostedFile.ContentLength <= 25000000 Then
                        Dim fi As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
                        Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
                        FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)



                        'itemImage.AttachedF = imageBytes
                        Attched.text = FileUpload1.PostedFile.FileName
                        Dim FName As String = FileUpload1.PostedFile.FileName

                        Dim path1 As String = Image2.ImageUrl
                        Dim path2 As String = System.IO.Path.GetDirectoryName(FName)



                        Image2.ImageUrl = Server.MapPath("..\") & "images\" & FName


                        'msg.UserMsgBox("File has been uploaded.", Me, False)

                        'itemImage.AttachedFile = Attched.text
                        save.AttachedF = imageBytes
                        Dim id As Long = objDerived.GetValue("Select Supplier_ID from dbo.Supplier where Supplier_ID ='" & hdnItemSubClass.value & "'", CommandType.text)
                        objDerived.Execute("Update dbo.Supplier set AttachedFile ='" & Attched.text & "' where Supplier_ID ='" & id & "'", CommandType.text)

                        Image2.ImageUrl = "~/images/" & FName
                    Else
                        msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                    End If
                Else
                    msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                End If

            Else
                lblNoti.Visible = False
            End If




            '***END OF SAVING OF IMAGE OF CONTACT PERSON***


            '**START OF EDITTING IMAGE 1 ***
            If (FileUpload2.HasFile) Then
                Dim fi2 As FileInfo = New FileInfo(Me.FileUpload2.PostedFile.FileName)
                Dim extension As String = Path.GetExtension(fi2.Name)
                lblNoti.Visible = False
                If extension = ".jpg" Or extension = ".png" Or extension = ".doc" Or extension = ".rar" Or extension = ".zip" Or extension = ".pdf" Or extension = ".xls" Or extension = ".xlsx" Then
                    If FileUpload2.PostedFile.ContentLength <= 25000000 Then
                        Dim fi As FileInfo = New FileInfo(Me.FileUpload2.PostedFile.FileName)
                        Dim imageBytes(FileUpload2.PostedFile.InputStream.Length) As Byte
                        FileUpload2.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)



                        'itemImage.AttachedF = imageBytes
                        CPAttached.text = FileUpload2.PostedFile.FileName
                        Dim FName As String = FileUpload2.PostedFile.FileName

                        Dim path1 As String = Image1.ImageUrl
                        Dim path2 As String = System.IO.Path.GetDirectoryName(FName)



                        Image1.ImageUrl = Server.MapPath("..\") & "images\" & FName


                        'msg.UserMsgBox("File has been uploaded.", Me, False)

                        'itemImage.AttachedFile = Attched.text
                        save.CPAttachedF = imageBytes
                        Dim id As Long = objDerived.GetValue("Select Supplier_ID from dbo.Supplier where Supplier_ID ='" & hdnItemSubClass.value & "'", CommandType.text)
                        objDerived.Execute("Update dbo.Supplier set CPAttachedFile ='" & CPAttached.text & "' where Supplier_ID ='" & id & "'", CommandType.text)

                        Image1.ImageUrl = "~/images/" & FName
                    Else
                        msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                    End If
                Else
                    msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                End If

            Else
                lblNoti.Visible = False
            End If

            save.AttachedFile = Attched.text
            save.CPAttachedFile = CPAttached.text



            If (FileUpload3.HasFile) Then
                Dim fi2 As FileInfo = New FileInfo(Me.FileUpload3.PostedFile.FileName)
                Dim extension As String = Path.GetExtension(fi2.Name)
                lblNoti.Visible = False
                If extension = ".jpg" Or extension = ".png" Or extension = ".doc" Or extension = ".rar" Or extension = ".zip" Or extension = ".pdf" Or extension = ".xls" Or extension = ".xlsx" Then
                    If FileUpload3.PostedFile.ContentLength <= 25000000 Then
                        Dim fi As FileInfo = New FileInfo(Me.FileUpload3.PostedFile.FileName)
                        Dim imageBytes(FileUpload3.PostedFile.InputStream.Length) As Byte
                        FileUpload3.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)



                        'itemImage.AttachedF = imageBytes
                        hndFileOwner.value = FileUpload3.PostedFile.FileName
                        Dim FName As String = FileUpload3.PostedFile.FileName

                        Dim path1 As String = Image3.ImageUrl
                        Dim path2 As String = System.IO.Path.GetDirectoryName(FName)



                        Image3.ImageUrl = Server.MapPath("..\") & "images\" & FName


                        'msg.UserMsgBox("File has been uploaded.", Me, False)

                        'itemImage.AttachedFile = Attched.text
                        save.AttachedFOwner = imageBytes
                        Dim id As Long = objDerived.GetValue("Select Supplier_ID from dbo.Supplier where Supplier_ID ='" & hdnItemSubClass.value & "'", CommandType.text)
                        objDerived.Execute("Update dbo.Supplier set AttachedFileOwner ='" & hndFileOwner.value & "' where Supplier_ID ='" & id & "'", CommandType.text)

                        Image3.ImageUrl = "~/images/" & FName
                    Else
                        msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                    End If
                Else
                    msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                End If

            Else
                lblNoti.Visible = False
            End If

            save.AttachedFileOwner = hndFileOwner.value
            save.FullnameOwner = txtOwner_Name.text
            save.AddressOwner = txtOwner_Addresss.text
            save.MobileNoOwner = txtContactOwner_ContactNo.text
            save.EmailAddressOwner = txtOwner_EmailAddress.text



            save.saveEDITSupplier()

            Dim supplierid As Long = objDerived.GetValue("select supplier_id from dbo.Supplier where Supplier_ID ='" & hdnItemSubClass.value & "'", commandtype.text)
            saveD.Supplier_ID = supplierid
            saveD.IssuedAt_DTI = Iss_DTI.text
            saveD.Date_Issued_DTI = DI_DTI.text
            saveD.Validity_DTI = Val_DTI.text

            saveD.IssuedAt_Tax = Iss_Tax.text
            saveD.Date_Issued_Tax = DI_Tax.text
            saveD.Validity_Tax = Val_Tax.text

            saveD.IssuedAt_Sec = Iss_Sec.text
            saveD.Date_Issued_Sec = DI_Sec.text
            saveD.Validity_Sec = Val_Sec.text

            saveD.IssuedAt_PG = Iss_Phil.text
            saveD.Date_Issued_PG = DI_Phil.text
            saveD.Validity_PG = Val_Phil.text

            saveD.IssuedAt_BP = Iss_BP.text
            saveD.Date_Issued_BP = DI_BP.text
            saveD.Validity_BP = Val_BP.text


            saveD.IssuedAt_BP = Iss_BP.text
            saveD.Date_Issued_BP = DI_BP.text
            saveD.Validity_BP = Val_BP.text

            saveD.IssuedAt_PCAB = Iss_PCAB.text
            saveD.Date_Issued_PCAB = DI_PCAB.text
            saveD.Validity_PCAB = Val_PCAB.text

            saveD.IssuedAt_FDA = Iss_FDA.text
            saveD.Date_Issued_FDA = DI_FDA.text
            saveD.Validity_FDA = Val_FDA.text

            saveD.DTI_No = DTI_RegNo.text
            saveD.Tax_No = Tax_No.text
            saveD.Sec_No = Sec_RegNo.text
            saveD.PhilGEPS_No = Phil_No.text
            saveD.BusinessPermit_No = BP_No.text
            saveD.PCAB_No = PCAB_No.text
            saveD.FDA_No = FDA_No.text

            saveD.saveEditDocument()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been saved Successfully")
            End If





        txtcompany.ReadOnly = True
        txtadd1.ReadOnly = True
        txtfaxno.ReadOnly = True
        ddtax.Enabled = False
        txttin.ReadOnly = True
        'txtname.ReadOnly = True
        'txtadd2.ReadOnly = True
        'txtcontactno.ReadOnly = True
        txtofficeno.ReadOnly = True


        txtAccNo.ReadOnly = True
        txtAccDate.ReadOnly = True
        txtAccUntil.ReadOnly = True
        txtAccApprovedBy.ReadOnly = True
        txtMOA.ReadOnly = True



        LoadSupplierList()

        btnsave.Enabled = False
        btnedit.Enabled = False
        btnDelete.Enabled = False

        'Catch ex As Exception
        'End Try
    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click

        txtcompany.Text = ""
        txtadd1.Text = ""
        txtofficeno.Text = ""
        txtfaxno.Text = ""
        txttin.Text = ""
        txtPS.Text = ""

        'txtname.Text = ""
        'txtadd2.Text = ""
        'txtcontactno.Text = ""


        txtAccNo.Text = ""
        txtAccDate.Text = ""
        txtAccUntil.Text = ""
        txtAccApprovedBy.Text = ""
        txtMOA.Text = ""

        txtcompany.ReadOnly = False
        txtadd1.ReadOnly = False
        txtfaxno.ReadOnly = False
        ddtax.Enabled = True
        txttin.ReadOnly = False
        'txtname.ReadOnly = False
        'txtadd2.ReadOnly = False
        txtofficeno.ReadOnly = False
        'txtcontactno.ReadOnly = False

        txtAccNo.ReadOnly = False
        txtAccDate.ReadOnly = False
        txtAccUntil.ReadOnly = False
        txtAccApprovedBy.ReadOnly = False
        txtMOA.ReadOnly = False
        'EmailAdd.REadOnly = False
        CMobileNum.REadOnly = False
        CFullName.REadOnly = False
        CAddress.REadOnly = False
        CEmailAdd.REadOnly = False
        CBDate.REadOnly = False
        CAge.REadOnly = False
        CNationality.REadOnly = False
        btnedit.Enabled = False
        btnsave.Enabled = True
        btnDelete.Enabled = False
        Position.ReadOnly = False
        Fileupload1.Enabled = True
        Fileupload2.Enabled = True
        Me.Session("save") = "new"
    End Sub
    Private Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim SuppName As String = objDerived.replaceapostrophe(txtsearch.Text)
        gvbody.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier WHERE SuppName LIKE '%" & SuppName & "%' ORDER BY SuppName", CommandType.Text)
        gvbody.DataBind()

        Session("SearchSuppName") = 1

    End Sub


    Protected Sub btnedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnedit.Click
        btnsave.Enabled = True
        Me.Session("save") = "edit"

        txtcompany.ReadOnly = False
        txtadd1.ReadOnly = False
        txtfaxno.ReadOnly = False
        ddtax.Enabled = True
        txttin.ReadOnly = False
        'txtname.ReadOnly = False
        'txtadd2.ReadOnly = False
        'txtcontactno.ReadOnly = False
        txtofficeno.ReadOnly = False
        txtPS.ReadOnly = False

        txtAccNo.ReadOnly = False
        txtAccDate.ReadOnly = False
        txtAccUntil.ReadOnly = False
        txtAccApprovedBy.ReadOnly = False
        txtMOA.ReadOnly = False
        cAddress.ReadOnly = False
        CMobileNum.ReadOnly = False
        CEmailAdd.ReadOnly = False
        Position.ReadOnly = False
        CNationality.ReadOnly = False
        FileUpload1.Enabled = True
        FileUpload2.Enabled = True
        btnDelete.Enabled = False

        txtOwner_Name.Enabled = True
        txtContactOwner_ContactNo.Enabled = True
        txtOwner_Addresss.Enabled = True
        txtOwner_EmailAddress.Enabled = True
        FileUpload3.Enabled = True


    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        objDerived.GetRecords("Delete from dbo.Supplier where Supplier_Id ='" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)

        pBody = objDerived.GetDataTable("select * from  dbo.listsupplier", CommandType.Text)
        gvbody.DataSource = pBody
        gvbody.DataBind()

        btnDelete.Enabled = False
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

        '
        Dim p As String = file_name
        Dim extension As String = Path.GetExtension(p)


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
        If extension = ".doc" Or extension = ".docx" Or extension = ".rar" Or extension = ".zip" Or extension = ".pdf" Or extension = ".xls" Or extension = ".xlsx" Then
            Page.Response.Redirect("..\obj\temp\Downloads\" & "\" & file_name)
            Image2.Attributes("src") = "/images/blankImage.jpg"

        Else

            'Dim img As System.Web.ui.AttributeCollection = imgprattachdoc.attributes
            'img.add("src", "..\obj\temp\downloads\" & "\" & file_name)
            Dim img As System.Web.ui.AttributeCollection = Image2.Attributes
            img.add("src", "..\obj\temp\downloads\" & "\" & file_name)
        End If
    End Sub


    Protected Sub CBdate_TextChanged(sender As Object, e As EventArgs)
        Dim Today As String = Date.Today.ToString("MM/dd/yyyy")
        Dim Bday As String = CBdate.Text
        Dim Age As Double = Year(Date.Today) - Year(Bday)
        CAge.text = Age

    End Sub

    Public Sub DropdownClassification()


        dtClass = objDerived.GetDataTable("Select * from dbo.tbl_Classification  order by ClassificationName Asc ", CommandType.Text)



        DrpClass.DataSource = dtClass
        DrpClass.DataTextField = "ClassificationName"
        DrpClass.DataValueField = "ClassificationID"

        DrpClass.DataBind()
        DrpClass.Items.Insert(0, "Select")
        'DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies where ClassificationID ='" & DrpClass.SelectedItem.Value & "' and BGA_ID = 0 Order by ga_title", CommandType.Text)
        'DrpGenAcc = objDerived.GetDataTable("Exec [AMS].[FMgetGenAccnt]'" & DrpClass.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "'", CommandType.Text)
        'GenAccnt.DataSource = DrpGenAcc
        'GenAccnt.DataTextField = "GA_title"
        'GenAccnt.DataValueField = "GA_ID"
        'GenAccnt.Items.Insert(0, "Select")
        'GenAccnt.items.clear()
        'GenAccnt.DataBind()


    End Sub
    Protected Sub DrpClass_SelectedIndexChanged(sender As Object, e As EventArgs)

        GenAccnt.items.clear()
        DrpSubClass.items.clear()

        Dim count = objDerived.GetValue("Select count(*) from dbo.tbl_SubClassification where ClassificationID = '" & DrpClass.SelectedItem.Value & "'", CommandType.Text)
        If count = 0 Then

            If drpSubClass.text = "" Or drpSubClass.text = "Select" Then

                DrpGenAcc = objDerived.GetDataTable("Exec [AMS].[FMgetGenAccntNoSubclass]'" & DrpClass.SelectedItem.Value & "','" & 0 & "'", CommandType.Text)
                GenAccnt.DataSource = DrpGenAcc
                GenAccnt.DataTextField = "GA_title"
                GenAccnt.DataValueField = "GA_ID"
                GenAccnt.items.clear()
                GenAccnt.DataBind()
                GenAccnt.Items.Insert(0, "Select")



            Else

                DrpGenAcc = objDerived.GetDataTable("Exec [AMS].[FMgetGenAccnt]'" & DrpClass.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "','" & 0 & "'", CommandType.Text)
                GenAccnt.DataSource = DrpGenAcc
                GenAccnt.DataTextField = "GA_title"
                GenAccnt.DataValueField = "GA_ID"
                GenAccnt.items.clear()
                GenAccnt.DataBind()
                GenAccnt.Items.Insert(0, "Select")

            End If


        Else
            DrpSubClassF = objDerived.GetDataTable("Select SubClassificationID, SubclassificationName from dbo.tbl_SubClassification where ClassificationID = '" & DrpClass.SelectedItem.Value & "'", CommandType.Text)
            DrpSubClass.DataSource = DrpSubClassF
            DrpSubClass.DataTextField = "SubClassificationName"
            DrpSubClass.DataValueField = "SubClassificationID"
            DrpSubClass.items.clear()
            DrpSubClass.DataBind()
            DrpSubClass.Items.Insert(0, "Select")
        End If




        If DrpSubClass.text = "" Then
            DrpSubClass.Enabled = False
        Else
            DrpSubClass.Enabled = True
        End If






        Dim b As Integer

        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            b = 0
        Else
            b = DrpSubclass.Selecteditem.Value
        End If
        DrpSubClass.DataSource = Nothing
        Dim c As Integer
        If DDSubCategory.text = "" Then
            c = 0
        Else
            c = DDSubCategory.Selecteditem.Value
        End If

        Session("CYNow") = "CY" & "2022"
        Session("CYPrev") = "CY" & "2023"



        ddParticular.items.clear()
        ddSubCategory.items.clear()

        'textboxbrand.text = ""
        'textboxColor.text = ""
        'textboxSize.text = ""
        'txtItemDesc.text = ""

        'txtprice.text = ""
        'txtItemCode.text = ""



        Session("Action") = "Save"
    End Sub
    Protected Sub DrpSubClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim b As Integer

        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            b = 0
        Else
            b = DrpSubclass.Selecteditem.Value
        End If
        DrpGenAcc = objDerived.GetDataTable("EXEC [AMS].[sp_FM_GvClass] null,'" & DrpClass.SelectedItem.Value & "','" & b & "','" & 0 & "'", CommandType.Text)
        GenAccnt.DataSource = DrpGenAcc
        GenAccnt.DataTextField = "GA_title2"
        GenAccnt.DataValueField = "GA_ID"
        'GenAccnt.items.clear()
        GenAccnt.DataBind()
        GenAccnt.Items.Insert(0, "Select")





        Dim c As Integer
        If ddSubCategory.text = "" Then
            c = 0
        Else
            c = ddSubCategory.Selecteditem.Value
        End If
    End Sub
    Protected Sub GenAccnt_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim a As Integer
        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            a = 0
        Else
            a = DrpSubclass.Selecteditem.Value
        End If
        pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selectedItem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & a & "'", CommandType.Text)
        ddparticular.datasource = pParticular
        ddparticular.datatextfield = "description"
        ddparticular.datavaluefield = "item_particular_id"
        ddparticular.databind()
        ddparticular.items.insert(0, "Select")





        'If ddParticular.text = "Select" Or ddParticular.text = "" Then


        '    Dim items As New DataTable
        '    items = objDerived.GetDataTable("select SubCategoryID,SubCat_Desc from dbo.tbl_SubCategory Order by Subcat_Desc", CommandType.Text)
        '    'SubCattxt.text = ""

        '    ddSubCategory.DataSource = items
        '    ddSubCategory.DataTextField = "SubCat_Desc"
        '    ddSubCategory.DataValueField = "SubCategoryID"
        '    ddSubCategory.DataBind()
        '    ddSubCategory.Items.Insert(0, "Select")
        '    ddSubCategory.Selecteditem.value = +1
        'End If


        'Dim c As Integer

        'If drpSubclass.text = "" Or drpSubclass.text = "Select" Then
        '    c = 0
        'Else
        '    c = drpSubclass.Selecteditem.Value
        'End If

        'dtItems = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        'gvstock.DataSource = dtItems
        'gvstock.DataBind()
        'gvstock.SelectedIndex = -1



    End Sub
    Protected Sub ddParticular_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        ' LoadSuppliesPerParticular()


        Dim items As New DataTable
        items = objDerived.GetDataTable("select SubCategoryID,SubCat_Desc from dbo.tbl_SubCategory where Item_particular_id = " & ddParticular.selecteditem.value & "Order by Subcat_Desc", CommandType.Text)
        ddSubCategory.DataSource = items
        ddSubCategory.DataTextField = "SubCat_Desc"
        ddSubCategory.DataValueField = "SubCategoryID"

        ddSubCategory.DataBind()
        ddSubCategory.Items.Insert(0, "Select")
        ddSubCategory.Enabled = True
        Session("CYNow") = "CY" & "2022"
        Session("CYPrev") = "CY" & "2023"

        Dim c As Integer

        If drpSubclass.text = "" Or drpSubclass.text = "Select" Then
            c = 0
        Else
            c = drpSubclass.Selecteditem.Value
        End If

        'dtItems = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        'gvstock.DataSource = dtItems
        'gvstock.DataBind()
        'gvstock.SelectedIndex = -1


    End Sub
    Protected Sub BtnViewList_Click(sender As Object, e As EventArgs)
        Session("CYNow") = "CY" & "2022"
        Session("CYPrev") = "CY" & "2023"


        If drpclass.text = "Select" Or drpclass.text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Classification is Required")
        ElseIf GenAccnt.text = "Select" Or GenAccnt.text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Gen Account is required")
        ElseIf ddParticular.text = "Select" Or ddParticular.text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Category is required")
        Else
            Dim c As Integer

            If drpSubclass.text = "" Or drpSubclass.text = "Select" Then
                c = 0
            Else
                c = drpSubclass.Selecteditem.Value
            End If

            Dim a As Integer
            If ddSubCategory.text = "Select" Or ddSubCategory.text = "" Then
                a = 0
            Else
                a = ddSubCategory.SelectedItem.Value
            End If
            dtItems = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass_Supplier] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & ddParticular.SelectedItem.Value & "','" & a & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            grdSupplier_Items.DataSource = dtItems
            grdSupplier_Items.DataBind()
            grdSupplier_Items.SelectedIndex = -1
        End If
        ModalPopupExtender1.show()
    End Sub

    Protected Sub cbItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb1 As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb1.NamingContainer, GridViewRow)

        grdSupplier_Items.Columns(1).Visible = True
        grdSupplier_Items.Columns(2).Visible = True
        grdSupplier_Items.Columns(3).Visible = True

        Dim a As Integer = Me.grdSupplier_Items.Rows(gvr.RowIndex).Cells(1).text
        If cb1.Checked = True Then
            ' MsgBox(Me.grdPPMP_Items.Rows(gvr.RowIndex).Cells(1).Text)
            'dtItems.Rows(Me.grdSupplier_Items.Rows(gvr.RowIndex).Cells(5).Text)("isChecked") = True
            dtItems.Rows(a)("isChecked") = True
            ' MsgBox(dtPPMP_Items.Rows(gvr.RowIndex)(1).ToString())
        Else
            'dtPPMP_Items.Rows(Me.grdPPMP_Items.Rows(gvr.RowIndex).Cells(5).Text)("isChecked") = False
            dtItems.Rows(gvr.RowIndex)("isChecked") = False
        End If

        'grdSupplier_Items.Columns(1).Visible = False
        'grdSupplier_Items.Columns(2).Visible = False
        'grdSupplier_Items.Columns().Visible = False

        ModalPopupExtender1.Show()

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        ' Try
        grdSupplier_Items.Columns(1).Visible = True
        grdSupplier_Items.Columns(2).Visible = True
        grdSupplier_Items.Columns(3).Visible = True

        Dim cb As New CheckBox
        Dim dt As New DataTable
        Dim dr As DataRow


        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("AccntCode", GetType(String))
        dt.Columns.Add("Item_Code", GetType(String))
        dt.Columns.Add("Particulardesc", GetType(String))
        dt.Columns.Add("UnitDesc", GetType(String))
        dt.Columns.Add("Price", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Integer))



        If dtPR_Items Is Nothing Then

            '    For Each row As DataRow In dtPPMP_Items.Rows
            '        Dim c As Boolean = TryCast(row.Item("cbItem"), CheckBox).Checked
            '        If c = True Then
            '            MsgBox("1")
            '        End If
            '        Dim a As Boolean ' = TryCast(row.FindControl("cbItem"), CheckBox).Checked
            '        Dim b As String
            '        If a = True Then
            '            '      b = row.DataItem(2).ToString
            '            MsgBox(b)
            '    Next
            'End If


            For i As Integer = 0 To Me.dtItems.Rows.Count - 1
                If dtItems.Rows(i)("isChecked") = True Then
                    dr = dt.NewRow
                    dr("ID") = dtItems.Rows(i)("ID")
                    dr("AccntCode") = dtItems.Rows(i)("AccntCode")
                    dr("Item_Code") = dtItems.Rows(i)("Item_Code")
                    dr("Particulardesc") = dtItems.Rows(i)("Particulardesc")
                    dr("UnitDesc") = dtItems.Rows(i)("UnitDesc")
                    dr("Price") = dtItems.Rows(i)("Price")

                    dt.Rows.Add(dr)

                    dtItems.Rows(i)("isUsed") = True
                    dtItems.Rows(i)("isChecked") = False

                End If
            Next

            dtPR_Items = dt

        Else

            dt = dtPR_Items
            For i As Integer = 0 To Me.dtItems.Rows.Count - 1
                If dtItems.Rows(i)("isChecked") = True Then
                    dr = dt.NewRow
                    dr("ID") = dtItems.Rows(i)("ID")
                    dr("AccntCode") = dtItems.Rows(i)("AccntCode")
                    dr("Item_Code") = dtItems.Rows(i)("Item_Code")
                    dr("Particulardesc") = dtItems.Rows(i)("Particulardesc")
                    dr("UnitDesc") = dtItems.Rows(i)("UnitDesc")
                    dr("Price") = dtItems.Rows(i)("Price")

                    dt.Rows.Add(dr)

                    dtItems.Rows(i)("isUsed") = True
                    dtItems.Rows(i)("isChecked") = False

                End If
            Next

            dtPR_Items = dt

        End If

        grdItems_ForSupplier.DataSource = dtPR_Items
        grdItems_ForSupplier.DataBind()

        'CType(grdSupplier_Items.FooterRow.Cells(6).FindControl("lblABC"), Label).Text = FormatNumber(dtPR_Items.Compute("SUM(TotalCost)", ""), 2)

        Dim myview As DataView
        myview = dtItems.DefaultView
        myview.RowFilter = "isUsed = false "
        grdSupplier_Items.DataSource = myview
        grdSupplier_Items.DataBind()

        'grdSupplier_Items.Columns(5).Visible = False
        'grdSupplier_Items.Columns(6).Visible = False
        'grdSupplier_Items.Columns(7).Visible = False

        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        'End Try
    End Sub
    Protected Sub grdItems_ForSupplier_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class


