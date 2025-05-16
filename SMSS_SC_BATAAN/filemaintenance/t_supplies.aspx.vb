Imports System.Collections.Generic
Imports System.IO
Imports System.Object
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System


Partial Class t_supplies
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim particular As New item_particular
    Dim item As New m_item
    Dim item2 As New m_itemSub
    Dim item3 As New m_itemWSubClassNoSubcat
    Dim item4 As New m_itemNoSubClassNoSubcat
    Dim itemImage As New m_itemImage
    Dim SubCls As New m_SubClass
    Dim item_detail As New m_item_detail
    Dim edit As New t_Edit_Transaction
    Dim msg As New MsgeBox
    Dim msg2 As New MsgeBox
    Dim AuditTrail As New Audit_Trail
    Dim obj As New AccessRule

#Region "property"
    Private Property pstock() As DataTable
        Get
            Return CType(Session("pstock"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pstock") = value
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
    Private Property pParticulardata() As DataTable
        Get
            Return CType(Session("pParticulardata"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pParticulardata") = value
        End Set
    End Property
    Private Property SubCatdata() As DataTable
        Get
            Return CType(Session("SubCatdata"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("SubCatdata") = value
        End Set
    End Property
    Private Property dv() As DataTable
        Get
            Return CType(Session("dv"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dv") = value
        End Set
    End Property
    Private Property div() As DataTable
        Get
            Return CType(Session("div"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("div") = value
        End Set
    End Property

    Private Property ItemsGvStock() As DataTable
        Get
            Return CType(Session("ItemsGvStock"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("ItemsGvStock") = value
        End Set
    End Property
    Private Property SubCat() As DataTable
        Get
            Return CType(Session("SubCat"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("SubCat") = value
        End Set
    End Property

    Private Property pProperty() As DataTable
        Get
            Return CType(Session("pProperty"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pProperty") = value
        End Set
    End Property

    Private Property pCode() As DataTable
        Get
            Return CType(Session("pCode"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pCode") = value
        End Set
    End Property

    Private Property PYear() As DataTable
        Get
            Return CType(Session("PYear"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PYear") = value
        End Set
    End Property
    Private Property DrpComp() As DataTable
        Get
            Return CType(Session("DrpComp"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("DrpComp") = value
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
    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
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
    Private Property ClassificationGrd() As DataTable
        Get
            Return CType(Session("ClassificationGrd"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("ClassificationGrd") = value
        End Set
    End Property
    Private Property SubClassificationGrd() As DataTable
        Get
            Return CType(Session("SubClassificationGrd"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("SubClassificationGrd") = value
        End Set
    End Property
    Private Property GvClassF() As DataTable
        Get
            Return CType(Session("GvClassF"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("GvClassF") = value
        End Set
    End Property


    Private Property PClassification() As DataTable
        Get
            Return CType(Session("PClassification"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PClassification") = value
        End Set
    End Property

    Private Property GvSubClassF() As DataTable
        Get
            Return CType(Session("GvSubClassF"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("GvSubClassF") = value
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
    Private Property IsEdit() As Boolean
        Get
            Return CType(Session("IsEdit"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("IsEdit") = value
        End Set
    End Property

    Private Property IsClickAll() As Boolean
        Get
            Return CType(Session("IsClickAll"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("IsClickAll") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            Try
                PYear = objDerived.GetDataTable("select year from ams.APP where isContinuing <> 1", CommandType.Text)
                ddyear.DataSource = PYear
                ddyear.DataTextField = "year"
                ddyear.DataValueField = "year"
                ddyear.DataBind()



                GenName.Visible = False
                DrpClass.Items.Insert(0, New ListItem("Select", "0"))

                btnsaveparticular.Enabled = True

                ddParticular.Enabled = False
                ddSubCategory.Enabled = False
                ddUnit.Enabled = False
                LinkButton3.Enabled = True
                txtItemDesc.Enabled = False
                DrpClass.Enabled = True

                txtparticular2.Attributes.Add("onkeypress", "return fun1(event,'" & Button7.ClientID & "')")
                txtsearch2.Attributes.Add("onkeypress", "return fun1(event,'" & btnsearch.ClientID & "')")
                txtSearchAccnt.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchAccnt.ClientID & "')")

            Catch ex As Exception
            End Try

        End If
    End Sub

    Protected Sub gvstock_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvstock.PageIndexChanging
        Session("View") = "Particular"
        Dim b As Integer

        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            b = 0
        Else
            b = DrpSubclass.Selecteditem.Value
        End If

        Dim c As Integer
        If DDSubCategory.text = "" Then
            c = 0
        Else
            c = DDSubCategory.Selecteditem.Value
        End If
        Dim d As Integer

        If drpSubclass.text = "" Or drpSubclass.text = "Select" Then
            d = 0
        Else
            d = drpSubclass.Selecteditem.Value
        End If
        'pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        ''pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & grdAccounts.SelectedDataKey("GA_ID") & "','" & grdAccounts.SelectedDataKey("BGA_ID") & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
        'gvstock.PageIndex = e.NewPageIndex
        'gvstock.DataSource = pstock
        'gvstock.DataBind()

        'If Session("View") = "Particular" Then
        pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & grdAccounts.SelectedDataKey("GA_ID") & "','" & grdAccounts.SelectedDataKey("BGA_ID") & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
            gvstock.PageIndex = e.NewPageIndex
            gvstock.DataSource = pstock
            gvstock.DataBind()



        'ElseIf Session("View") = "Search" Then
        '    pstock =  objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)


        '    Dim myview As DataView
        '    myview = pstock.DefaultView
        '    If ddSearch.SelectedItem.Value = 2 Then
        '        myview.RowFilter = "Item_Code like '%" & replaceapostrophe(txtsearch2.Text.ToString) & "%'"
        '    ElseIf ddSearch.SelectedItem.Value = 1 Then
        '        myview.RowFilter = "Itemdesc like '%" & replaceapostrophe(txtsearch2.Text.ToString) & "%'"
        '    Else
        '        myview.RowFilter = "particular_desc like '%" & replaceapostrophe(txtsearch2.Text.ToString) & "%'"
        '    End If
        '    gvstock.DataSource = myview
        '    gvstock.PageIndex = e.NewPageIndex
        '    gvstock.DataBind()

        'End If

        CType(gvstock.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
        CType(gvstock.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")
        btnadd.Enabled = True
    End Sub

    Protected Sub gvstock_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvstock.SelectedIndexChanged
        hdnItemSubClass.Value = gvstock.SelectedDataKey(4)
        If Session("Option") = "Select" Then
            Dim Active As String
            Active = IIf(IsDBNull(objDerived.GetValue("select isused from dbo.m_item where dbo.m_item.Item_id=" & hdnItemSubClass.Value & "  ", CommandType.Text)), 0, objDerived.GetValue("select isused from dbo.m_item where dbo.m_item.Item_id=" & Me.gvstock.SelectedDataKey(4) & " ", CommandType.Text))
            If Active = "True" Then
                Me.chkInactive.Checked = True
            Else
                Me.chkInactive.Checked = False
            End If

            If DrpClass.SelectedItem.Value = 7 Or DrpClass.text = "Medicine" Then


                ddUnit.Enabled = False
                txtItemDesc.Text = gvstock.SelectedDataKey(7)
                dv = objDerived.getdatatable("select *  from ams.item_particular where item_particular_id = '" & gvstock.SelectedDataKey(5) & "'", commandtype.text)
                ddParticular.DataSource = dv
                ddParticular.DataTextField = "description"
                ddParticular.DataValueField = "item_particular_id"
                ddParticular.DataBind()

                txtRpt.Enabled = False
                txtprice.Enabled = False
                txtItemDesc.Enabled = False
                btnadd.Enabled = True
                btnedit.Enabled = True
                btnsave.Enabled = True
                Me.btncopyall.Enabled = True

                ddUnit.SelectedItem.Text = gvstock.SelectedDataKey(2)
                ddUnit.SelectedItem.Value = gvstock.SelectedDataKey(6)

                Dim brand As Object = gvstock.selectedDataKey(14)
                textboxBrand.text = If(DBNull.Value.Equals(brand), "", brand)
                Dim Color As Object = gvstock.selectedDataKey(15)
                textboxColor.text = If(DBNull.Value.Equals(Color), "", Color)
                Dim size As Object = gvstock.selectedDataKey(16)
                textboxSize.text = If(DBNull.Value.Equals(size), 0.00, size)
                textboxGen.text = gvstock.SelectedDataKey(20)
                txtItemCode.Text = gvstock.SelectedDataKey("Item_Code")
                txtItemDesc.Text = gvstock.SelectedDataKey(7)
                ' ddSubCategory.items.indexof(ddparticular.items.FindByValue(gvstock.SelectedDatakey(6)))
                'ddSubCategory.selectedindex = ddSubCategory.items.indexof(ddparticular.items.FindByValue(gvstock.SelectedDatakey("")))

                ddSubCategory.SelectedValue = gvstock.SelectedDatakey(8)
                On Error Resume Next
                'ddSubCategory.SelectedItem.value = gvstock.SelectedDatakey(8)
                ddUnit.SelectedItem.Text = gvstock.SelectedDataKey(2)
                ddUnit.SelectedItem.Value = gvstock.SelectedDataKey(2)
                Dim ItemPic As String = objDerived.GetValue("select AttachedFile from dbo.m_item where item_id = '" & hdnItemSubClass.Value & "'", CommandType.Text)
                If ItemPic = "" Then
                    Image1.ImageUrl = "~/images/blankImage.jpg"
                Else
                    Image1.ImageUrl = "~/images/" & ItemPic
                End If
            Else
                ddUnit.Enabled = False
                txtItemDesc.Text = gvstock.SelectedDataKey(7)
                dv = objDerived.getdatatable("select *  from ams.item_particular where item_particular_id = '" & gvstock.SelectedDataKey(5) & "'", commandtype.text)
                ddParticular.DataSource = dv
                ddParticular.DataTextField = "description"
                ddParticular.DataValueField = "item_particular_id"
                ddParticular.DataBind()

                Dim a As Integer
                If ddSubCategory.text = "Select" Or ddSubCategory.SelectedItem Is Nothing Then
                    a = 0
                Else
                    a = ddSubCategory.selectedItem.value
                End If

                div = objDerived.getdatatable("select *  from tbl_subcategory where Subcategoryid = '" & gvstock.SelectedDataKey(8) & "'", commandtype.text)
                ddSubCategory.DataSource = div
                ddSubCategory.DataTextField = "SubCat_desc"
                ddSubCategory.DataValueField = "Subcategoryid"
                ddSubCategory.DataBind()
                'ddSubCategory.Items.Insert(0, "Select")
                ddSubCategory.Items.Insert(0, New ListItem("Select", "0"))

                Dim brand As Object = gvstock.selectedDataKey(14)
                textboxBrand.text = If(DBNull.Value.Equals(brand), "", brand)
                Dim Color As Object = gvstock.selectedDataKey(15)
                textboxColor.text = If(DBNull.Value.Equals(Color), "", Color)
                Dim size As Object = gvstock.selectedDataKey(16)
                textboxSize.text = If(DBNull.Value.Equals(size), "", size)

                txtRpt.Enabled = False
                txtprice.Enabled = False
                txtItemDesc.Enabled = False
                btnadd.Enabled = True
                btnedit.Enabled = True
                btnsave.Enabled = True
                Me.btncopyall.Enabled = True

                ddUnit.SelectedItem.Text = gvstock.SelectedDataKey(2)
                ddUnit.SelectedItem.Value = gvstock.SelectedDataKey(6)

                txtItemCode.Text = gvstock.SelectedDataKey("Item_Code")
                txtItemDesc.Text = gvstock.SelectedDataKey(7)
                ' ddSubCategory.items.indexof(ddparticular.items.FindByValue(gvstock.SelectedDatakey(6)))
                'ddSubCategory.selectedindex = ddSubCategory.items.indexof(ddparticular.items.FindByValue(gvstock.SelectedDatakey("")))
                On Error Resume Next
                ddSubCategory.SelectedValue = gvstock.SelectedDatakey(8)

                'ddSubCategory.SelectedItem.value = gvstock.SelectedDatakey(8)
                ddUnit.SelectedItem.Text = gvstock.SelectedDataKey(2)
                ddUnit.SelectedItem.Value = gvstock.SelectedDataKey(2)
                Dim ItemPic As String = objDerived.GetValue("select AttachedFile from dbo.m_item where item_id = '" & hdnItemSubClass.Value & "'", CommandType.Text)
                If ItemPic = "" Then
                    Image1.ImageUrl = "~/images/NoPicture.jpg"
                Else
                    Image1.ImageUrl = "~/images/" & ItemPic
                End If
            End If

            Me.HiddenField3.Value = "CY" & Me.ddyear.SelectedValue.ToString

            Dim Prevyear
            Prevyear = "CY" & Me.ddyear.SelectedValue.ToString - 1
            txtprice.Text = IIf(IsDBNull(objDerived.GetValue("Select " & Me.HiddenField3.Value & "   from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & " ", CommandType.Text)), 0, objDerived.GetValue("Select " & Me.HiddenField3.Value & "   from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & " ", CommandType.Text))

            Session("oldValueItem") = gvstock.SelectedDataKey(7)
            Session("oldValueUnit") = gvstock.SelectedDataKey(2)

            txtReorderPoint.Text = objDerived.GetValue("SELECT reorderPT FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)

            Dim currentYear
            currentYear = "CY" & Me.ddyear.SelectedValue.ToString
            Session("oldValuePrice") = gvstock.SelectedDataKey("price2")
            Session("Item_id") = Me.gvstock.SelectedDataKey(4)
            'Session("action") = "Edit"

        ElseIf Session("Option") = "Delete" Then

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT DISTINCT Item_ID FROM AMS.ppmp_dtl WHERE Item_ID = '" & gvstock.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            If dt.Rows.Count = 0 Then

                objDerived.GetRecords("DELETE FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                objDerived.GetRecords("DELETE FROM dbo.m_item_detail WHERE Item_ID = '" & gvstock.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                objDerived.GetRecords("DELETE FROM dbo.tblclassmatrix WHERE Item_ID = '" & gvstock.SelectedDataKey("Item_ID") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Selected item has been successfully deleted.")

            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Selected item cannot be deleted. Item has already been used in an existing PPPMP.")
            End If

            'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & gvstock.SelectedDataKey("GA_ID") & "','" & grdAccounts.SelectedDataKey("BGA_ID") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
            'gvstock.DataSource = pstock
            'gvstock.DataBind()
            'gvstock.SelectedIndex = -1

            'If pstock.Rows.Count <> 0 Then
            '    CType(gvstock.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
            '    CType(gvstock.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")
            'End If

            Dim c As Integer

            If drpSubclass.text = "" Or drpSubclass.text = "Select" Then
                c = 0
            Else
                c = drpSubclass.Selecteditem.Value
            End If
            dtItems = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            gvstock.DataSource = dtItems
            gvstock.DataBind()
            gvstock.SelectedIndex = -1
        End If

    End Sub


    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click

        Dim a As Integer

        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            a = 0
        Else
            a = DrpSubclass.Selecteditem.Value
        End If

        IsEdit = False
        ddSubCategory.Items.Clear()
        txtItemCode.Enabled = True
        txtprice.Enabled = True
        txtItemDesc.Enabled = True
        txtRpt.Enabled = True
        ddUnit.Enabled = True
        btnadd.Enabled = True
        btnedit.Enabled = False
        FileUpload1.Enabled = True
        btnROP.Enabled = True



        ddParticular.Enabled = True


        pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selectedItem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & a & "'", CommandType.Text)
        ddparticular.datasource = pParticular
        ddparticular.datatextfield = "description"
        ddparticular.datavaluefield = "item_particular_id"
        ddparticular.databind()
        ddParticular.Items.Insert(0, New ListItem("Select", "0"))

        txtReorderPoint.Text = ""
        txtItemDesc.Text = ""
        txtprice.Text = "0.00"
        txtItemCode.Text = ""
        txtItemDesc.Focus()
        Session("action") = "Add"
    End Sub

    Protected Sub btnedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnedit.Click
        Me.chkInactive.Visible = False

        ddUnit.Enabled = True
        txtItemCode.Enabled = True
        txtRpt.Enabled = True
        txtprice.Enabled = True
        txtItemDesc.Enabled = True

        ddSubCategory.Enabled = True
        ddParticular.Enabled = True
        DrpSubClass.Enabled = True
        GenAccnt.Enabled = True
        btnadd.Enabled = False
        btnedit.Enabled = True
        btnsave.Enabled = True
        DrpSubClass.Enabled = True
        FileUpload1.Enabled = True
        btnROP.Enabled = True
        txtItemDesc.Focus()
        Session("action") = "Edit"
    End Sub



    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) ' Handles btnsave.Click

        If Session("action") = "Add" Then

            If ddParticular.SelectedValue = "0" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Please select a valid Particular before saving.")
                Exit Sub
            End If

            ' Example: Validate ddParticular before using it
            Dim particularId As Integer
            If Not Integer.TryParse(ddParticular.SelectedValue, particularId) OrElse particularId = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Please select a valid particular.")
                Exit Sub
            End If


            If Not String.IsNullOrEmpty(ddParticular.SelectedValue) AndAlso IsNumeric(ddParticular.SelectedValue) Then
                If ddParticular.SelectedValue <> 0 Then

                    Me.HiddenField3.Value = "CY" & Me.ddyear.SelectedValue.ToString()
                    If verify() = False Then


                        If DrpClass.SelectedItem.Value = 7 Then


                            If DrpSubClass.Text = "" And ddSubCategory.Text <> "" Then

                                item2.Item_Desc = txtItemDesc.Text
                                item2.Unit_ID = ddUnit.SelectedValue
                                item2.item_particular_id = ddParticular.SelectedValue
                                item2.isAll = True
                                item2.detail = ""
                                item2.Item_Code = txtItemCode.Text
                                'item2.SubCategoryID = If(ddsubcategory.SelectedValue = "Select", 0, ddsubcategory.SelectedValue)
                                If ddSubCategory.SelectedValue = "Select" Then
                                    item2.SubCategoryId = 0
                                Else
                                    item2.SubCategoryId = ddSubCategory.SelectedValue
                                End If

                                item2.ClassificationID = DrpClass.SelectedValue


                                'SIRMARK

                                item2.Brand = TextBoxBrand.Text
                                item2.Color = TextBoxColor.Text
                                item2.Size = TextBoxSize.Text
                                item2.GenericName = TextBoxGen.Text
                                'File UPLOADING
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
                                            item2.AttachedF = imageBytes
                                            Attched.Text = FileUpload1.PostedFile.FileName
                                            Dim FName As String = FileUpload1.PostedFile.FileName
                                            FileUpload1.SaveAs(Server.MapPath("..\") & "images\" & FName)
                                            Dim path1 As String = Image1.ImageUrl
                                            Dim path2 As String = System.IO.Path.GetDirectoryName(FName)



                                            Image1.ImageUrl = Server.MapPath("..\") & "images\" & FName


                                            'msg.UserMsgBox("File has been uploaded.", Me, False)


                                        Else
                                            msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                                        End If
                                    Else
                                        msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                                    End If

                                Else
                                    lblNoti.Visible = True
                                End If

                                item2.AttachedFile = Attched.Text
                                Dim id As Long = item2.save

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtReorderPoint.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                  " VALUES " &
                                                  " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)
                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_ID,classificationID,ga_id,CategoryID,SubcategoryID,BGA_ID)Values('" & id & "','" & DrpClass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & ddSubCategory.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)

                                'update the columns Price
                                'Me.objDerived.Execute(" update into dbo.m_item_detail set " & Session("CYNow") & " = " & item_detail.price & "  where Item_id=" & item_detail.Item_ID & "", CommandType.Text) 'and price = null



                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")

                            ElseIf DrpSubClass.Text <> "" And ddSubCategory.Text <> "" Then


                                item.Item_Desc = txtItemDesc.Text
                                item.Unit_ID = ddUnit.SelectedValue
                                item.item_particular_id = ddParticular.SelectedValue
                                item.isAll = True
                                item.detail = ""
                                item.Item_Code = txtItemCode.Text
                                'item.SubCategoryID = If(ddsubcategory.SelectedValue = "Select", 0, ddsubcategory.SelectedValue)
                                If ddSubCategory.SelectedValue = "Select" Then
                                    item.SubCategoryId = 0
                                Else
                                    item.SubCategoryId = ddSubCategory.SelectedValue
                                End If

                                item.ClassificationID = DrpClass.SelectedValue
                                item.SubClassificationId = DrpSubClass.SelectedValue

                                'SIRMARK
                                item.Brand = TextBoxBrand.Text
                                item.Color = TextBoxColor.Text
                                item.Size = TextBoxSize.Text
                                item.GenericName = TextBoxGen.Text
                                'File UPLOADING
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
                                            item.AttachedF = imageBytes
                                            Attched.Text = FileUpload1.PostedFile.FileName
                                            Dim FName As String = FileUpload1.PostedFile.FileName
                                            FileUpload1.SaveAs(Server.MapPath("..\") & "images\" & FName)
                                            Dim path1 As String = Image1.ImageUrl
                                            Dim path2 As String = System.IO.Path.GetDirectoryName(FName)
                                            'Dim path3 As String() = path2.Split("\")

                                            'msgbox(path3(path3.Length - 2))


                                            'path1 = path + FileUpload1.FileName
                                            'image2.ImageUrl = "~/images/" + FName


                                            Image1.ImageUrl = Server.MapPath("..\") & "images\" & FName


                                            'msg.UserMsgBox("File has been uploaded.", Me, False)


                                        Else
                                            msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                                        End If
                                    Else
                                        msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                                    End If

                                Else
                                    lblNoti.Visible = True
                                End If

                                item.AttachedFile = Attched.Text

                                Dim id As Long = item.save

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtReorderPoint.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                  " VALUES " &
                                                  " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)
                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_id,classificationID,ga_id,CategoryID,SubcategoryID,SubClassificationId,BGA_ID)Values('" & id & "','" & DrpClass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & ddSubCategory.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)


                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")

                            ElseIf DrpSubClass.Text <> "" And ddSubCategory.Text = "" Then

                                item3.Item_Desc = txtItemDesc.Text
                                item3.Unit_ID = ddUnit.SelectedValue
                                item3.item_particular_id = ddParticular.SelectedValue
                                item3.isAll = True
                                item3.detail = ""
                                item3.Item_Code = txtItemCode.Text
                                item3.ClassificationID = DrpClass.SelectedValue
                                item3.SubClassificationId = DrpSubClass.SelectedValue

                                'SIRMARK
                                item3.Brand = TextBoxBrand.Text
                                item3.Color = TextBoxColor.Text
                                item3.Size = TextBoxSize.Text
                                item3.GenericName = TextBoxGen.Text
                                'File UPLOADING
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
                                            item3.AttachedF = imageBytes
                                            Attched.Text = FileUpload1.PostedFile.FileName
                                            Dim FName As String = FileUpload1.PostedFile.FileName
                                            FileUpload1.SaveAs(Server.MapPath("..\") & "images\" & FName)
                                            Dim path1 As String = Image1.ImageUrl
                                            Dim path2 As String = System.IO.Path.GetDirectoryName(FName)
                                            'Dim path3 As String() = path2.Split("\")

                                            'msgbox(path3(path3.Length - 2))


                                            'path1 = path + FileUpload1.FileName
                                            'image2.ImageUrl = "~/images/" + FName


                                            Image1.ImageUrl = Server.MapPath("..\") & "images\" & FName


                                            'msg.UserMsgBox("File has been uploaded.", Me, False)


                                        Else
                                            msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                                        End If
                                    Else
                                        msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                                    End If

                                Else
                                    lblNoti.Visible = True
                                End If
                                item3.AttachedFile = Attched.Text

                                Dim id As Long = item3.save

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtReorderPoint.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                      " VALUES " &
                                                      " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)

                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_ID,classificationID,ga_id,CategoryID,SubClassificationId,BGA_ID)Values('" & id & "','" & DrpClass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)
                                'update the columns Price



                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")

                            Else
                                item4.Item_Desc = txtItemDesc.Text
                                item4.Unit_ID = ddUnit.SelectedValue
                                item4.item_particular_id = ddParticular.SelectedValue
                                item4.isAll = True
                                item4.detail = ""
                                item4.Item_Code = txtItemCode.Text
                                item4.ClassificationID = DrpClass.SelectedValue

                                'SIRMARK
                                item4.Brand = TextBoxBrand.Text
                                item4.Color = TextBoxColor.Text
                                item4.Size = TextBoxSize.Text
                                item4.GenericName = TextBoxGen.Text

                                'File UPLOADING
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
                                            item4.AttachedF = imageBytes
                                            Attched.Text = FileUpload1.PostedFile.FileName
                                            Dim FName As String = FileUpload1.PostedFile.FileName
                                            FileUpload1.SaveAs(Server.MapPath("..\") & "images\" & FName)
                                            Dim path1 As String = Image1.ImageUrl
                                            Dim path2 As String = System.IO.Path.GetDirectoryName(FName)
                                            'Dim path3 As String() = path2.Split("\")

                                            'msgbox(path3(path3.Length - 2))


                                            'path1 = path + FileUpload1.FileName
                                            'image2.ImageUrl = "~/images/" + FName


                                            Image1.ImageUrl = Server.MapPath("..\") & "images\" & FName


                                            'msg.UserMsgBox("File has been uploaded.", Me, False)


                                        Else
                                            msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                                        End If
                                    Else
                                        msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                                    End If

                                Else
                                    lblNoti.Visible = True
                                End If
                                item4.AttachedFile = Attched.Text
                                Dim id As Long = item4.save

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtReorderPoint.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                      " VALUES " &
                                                      " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)

                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_id,classificationID,ga_id,CategoryID_BGA_ID)Values('" & id & "','" & DrpClass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)
                                'update the columns Price
                                'Me.objDerived.Execute(" update into dbo.m_item_detail set " & Session("CYNow") & " = " & item_detail.price & "  where Item_id=" & item_detail.Item_ID & "", CommandType.Text) 'and price = null


                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")

                            End If

                        Else
                            If DrpSubClass.Text = "" And ddSubCategory.Text <> "" Then

                                item2.Item_Desc = txtItemDesc.Text
                                item2.Unit_ID = ddUnit.SelectedValue
                                item2.item_particular_id = ddParticular.SelectedValue
                                item2.isAll = True
                                item2.detail = ""
                                item2.Item_Code = txtItemCode.Text
                                ' item2.SubCategoryID = If(ddsubcategory.SelectedValue = "Select", 0, ddsubcategory.SelectedValue)
                                If ddSubCategory.SelectedValue = "Select" Then
                                    item2.SubCategoryId = 0
                                Else
                                    item2.SubCategoryId = ddSubCategory.SelectedValue
                                End If
                                item2.ClassificationID = DrpClass.SelectedValue


                                'SIRMARK
                                item2.Brand = TextBoxBrand.Text
                                item2.Color = TextBoxColor.Text
                                item2.Size = TextBoxSize.Text

                                'File UPLOADING
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
                                            item2.AttachedF = imageBytes
                                            Attched.Text = FileUpload1.PostedFile.FileName
                                            Dim FName As String = FileUpload1.PostedFile.FileName
                                            FileUpload1.SaveAs(Server.MapPath("..\") & "images\" & FName)
                                            Dim path1 As String = Image1.ImageUrl
                                            Dim path2 As String = System.IO.Path.GetDirectoryName(FName)
                                            'Dim path3 As String() = path2.Split("\")

                                            'msgbox(path3(path3.Length - 2))


                                            'path1 = path + FileUpload1.FileName
                                            'image2.ImageUrl = "~/images/" + FName


                                            Image1.ImageUrl = Server.MapPath("..\") & "images\" & FName


                                            'msg.UserMsgBox("File has been uploaded.", Me, False)


                                        Else
                                            msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                                        End If
                                    Else
                                        msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                                    End If

                                Else
                                    lblNoti.Visible = True
                                End If
                                item2.AttachedFile = Attched.Text

                                Dim id As Long = item2.save

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtReorderPoint.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                  " VALUES " &
                                                  " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)
                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_id,classificationID,ga_id,CategoryID,SubcategoryID,BGA_ID)Values('" & id & "','" & DrpClass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & ddSubCategory.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)

                                'update the columns Price



                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")

                            ElseIf DrpSubClass.Text <> "" And ddSubCategory.Text <> "" Then


                                item.Item_Desc = txtItemDesc.Text
                                item.Unit_ID = ddUnit.SelectedValue
                                item.item_particular_id = ddParticular.SelectedValue
                                item.isAll = True
                                item.detail = ""
                                item.Item_Code = txtItemCode.Text
                                ' item.SubCategoryID = If(ddsubcategory.SelectedValue = "Select", 0, ddsubcategory.SelectedValue)
                                If ddSubCategory.SelectedValue = "Select" Then
                                    item.SubCategoryId = 0
                                Else
                                    item.SubCategoryId = ddSubCategory.SelectedValue
                                End If


                                item.ClassificationID = DrpClass.SelectedValue
                                item.SubClassificationId = DrpSubClass.SelectedValue

                                'SIRMARK
                                item.Brand = TextBoxBrand.Text
                                item.Color = TextBoxColor.Text
                                item.Size = TextBoxSize.Text
                                'File UPLOADING
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
                                            item.AttachedF = imageBytes
                                            Attched.Text = FileUpload1.PostedFile.FileName
                                            Dim FName As String = FileUpload1.PostedFile.FileName
                                            FileUpload1.SaveAs(Server.MapPath("..\") & "images\" & FName)
                                            Dim path1 As String = Image1.ImageUrl
                                            Dim path2 As String = System.IO.Path.GetDirectoryName(FName)
                                            'Dim path3 As String() = path2.Split("\")

                                            'msgbox(path3(path3.Length - 2))


                                            'path1 = path + FileUpload1.FileName
                                            'image2.ImageUrl = "~/images/" + FName


                                            Image1.ImageUrl = Server.MapPath("..\") & "images\" & FName


                                            'msg.UserMsgBox("File has been uploaded.", Me, False)


                                        Else
                                            msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                                        End If
                                    Else
                                        msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                                    End If

                                Else
                                    lblNoti.Visible = True
                                End If
                                item.AttachedFile = Attched.Text
                                Dim id As Long = item.save

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtReorderPoint.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                  " VALUES " &
                                                  " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)
                                'INSERTING ON TBLCLASSMATRIX

                                Dim ddSubCat As String
                                If ddSubCategory.SelectedValue = "Select" Then
                                    ddSubCat = 0
                                Else
                                    ddSubCat = ddSubCategory.SelectedValue
                                End If


                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_id,classificationID,ga_id,CategoryID,SubcategoryID,SubClassificationId,BGA_ID)Values('" & id & "','" & DrpClass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & ddSubCat & "','" & DrpSubClass.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)
                                'here
                                'update the columns Price


                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")

                            ElseIf DrpSubClass.Text <> "" And ddSubCategory.Text = "" Then

                                item3.Item_Desc = txtItemDesc.Text
                                item3.Unit_ID = ddUnit.SelectedValue
                                item3.item_particular_id = ddParticular.SelectedValue
                                item3.isAll = True
                                item3.detail = ""
                                item3.Item_Code = txtItemCode.Text
                                item3.ClassificationID = DrpClass.SelectedValue
                                item3.SubClassificationId = DrpSubClass.SelectedValue

                                'SIRMARK
                                item3.Brand = TextBoxBrand.Text
                                item3.Color = TextBoxColor.Text
                                item3.Size = TextBoxSize.Text
                                Dim id As Long = item3.save

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtReorderPoint.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                      " VALUES " &
                                                      " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)

                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_Id,classificationID,ga_id,CategoryID,SubClassificationId,BGA_ID)Values('" & id & "','" & DrpClass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)
                                'update the columns Price
                                'Me.objDerived.Execute(" update into dbo.m_item_detail set " & Session("CYNow") & " = " & item_detail.price & "  where Item_id=" & item_detail.Item_ID & "", CommandType.Text) 'and price = null

                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")

                            Else
                                item4.Item_Desc = txtItemDesc.Text
                                item4.Unit_ID = ddUnit.SelectedValue
                                item4.item_particular_id = ddParticular.SelectedValue
                                item4.isAll = True
                                item4.detail = ""
                                item4.Item_Code = txtItemCode.Text
                                item4.ClassificationID = DrpClass.SelectedValue

                                'SIRMARK
                                item4.Brand = TextBoxBrand.Text
                                item4.Color = TextBoxColor.Text
                                item4.Size = TextBoxSize.Text
                                'File UPLOADING
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
                                            item4.AttachedF = imageBytes
                                            Attched.Text = FileUpload1.PostedFile.FileName
                                            Dim FName As String = FileUpload1.PostedFile.FileName
                                            FileUpload1.SaveAs(Server.MapPath("..\") & "images\" & FName)
                                            Dim path1 As String = Image1.ImageUrl
                                            Dim path2 As String = System.IO.Path.GetDirectoryName(FName)
                                            'Dim path3 As String() = path2.Split("\")

                                            'msgbox(path3(path3.Length - 2))


                                            'path1 = path + FileUpload1.FileName
                                            'image2.ImageUrl = "~/images/" + FName


                                            Image1.ImageUrl = Server.MapPath("..\") & "images\" & FName


                                            'msg.UserMsgBox("File has been uploaded.", Me, False)


                                        Else
                                            msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                                        End If
                                    Else
                                        msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                                    End If

                                Else
                                    lblNoti.Visible = True
                                End If
                                item4.AttachedFile = Attched.Text
                                Dim id As Long = item4.save

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtReorderPoint.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                      " VALUES " &
                                                      " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)

                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_ID,classificationID,ga_id,CategoryID,BGA_ID)Values('" & id & "','" & DrpClass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)
                                'update the columns Price


                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")

                            End If

                        End If
                        'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & "0" & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
                        'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & "0" & "','" & DrpClass.SelectedValue & "','" & DrpSubClass.SelectedValue & "', '" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
                        'gvstock.DataSource = pstock
                        'gvstock.DataBind()

                        Dim b As Integer
                        If DrpSubClass.Text = "" Or DrpSubClass.Text = "Select" Then
                            b = 0
                        Else
                            b = DrpSubClass.SelectedItem.Value
                        End If
                        Dim d As Integer

                        If DrpSubClass.Text = "" Or DrpSubClass.Text = "Select" Then
                            d = 0
                        Else
                            d = DrpSubClass.SelectedItem.Value
                        End If



                        pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.SelectedItem.Value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)

                        'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & "0" & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
                        gvstock.DataSource = pstock
                        gvstock.DataBind()


                        'CType(gvstock.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
                        'CType(gvstock.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")


                        ddUnit.Enabled = False
                        txtprice.Enabled = False
                        txtItemDesc.Enabled = False
                        btnadd.Enabled = True
                        btnedit.Enabled = False
                        btnsave.Enabled = False
                        gvstock.SelectedIndex = -1

                        btnsave.Enabled = False



                        'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpclass.selectedItem.value & "','" & b & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
                        'pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
                        gvstock.DataSource = pstock
                        gvstock.DataBind()


                        'CType(gvstock.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
                        'CType(gvstock.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")


                        ddUnit.Enabled = False
                        txtprice.Enabled = False
                        txtItemDesc.Enabled = False
                        btnadd.Enabled = True
                        btnedit.Enabled = False
                        btnsave.Enabled = False
                        gvstock.SelectedIndex = -1

                        btnsave.Enabled = False

                    Else
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Record already existing.")
                        Exit Sub
                    End If
                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Please select particular.")
                End If
            Else

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a valid particular.")
                Exit Sub
            End If


        ElseIf Session("action") = "Edit" Then
            ModalPopupExtender1.show()
            If (FileUpload1.HasFile) Then
                Dim fi2 As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
                Dim extension As String = Path.GetExtension(fi2.Name)
                lblNoti.Visible = False
                If extension = ".jpg" Or extension = ".png" Or extension = ".doc" Or extension = ".rar" Or extension = ".zip" Or extension = ".pdf" Or extension = ".xls" Or extension = ".xlsx" Then
                    If FileUpload1.PostedFile.ContentLength <= 25000000 Then
                        Dim fi As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
                        Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
                        FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)



                        itemImage.AttachedF = imageBytes
                        Attched.text = FileUpload1.PostedFile.FileName
                        Dim FName As String = FileUpload1.PostedFile.FileName

                        Dim path1 As String = Image1.ImageUrl
                        Dim path2 As String = System.IO.Path.GetDirectoryName(FName)



                        Image1.ImageUrl = Server.MapPath("..\") & "images\" & FName


                        'msg.UserMsgBox("File has been uploaded.", Me, False)

                        itemImage.AttachedFile = Attched.text
                        Dim id As Long = objDerived.GetValue("Select Item_Id from dbo.m_item where Item_Id ='" & hdnItemSubClass.value & "'", CommandType.text)
                        objDerived.Execute("Update dbo.m_Item set AttachedFile ='" & Attched.text & "' where Item_id ='" & id & "'", CommandType.text)

                        Image1.ImageUrl = "~/images/" & FName
                    Else
                        msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                    End If
                Else
                    msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
                End If

            Else
                lblNoti.Visible = True
            End If





            ModalPopupExtender1.Show()
        End If
        btnROP.Enabled = False


    End Sub


    Protected Sub txtprice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprice.TextChanged
        txtprice.Text = FormatNumber(CType(txtprice.Text, Decimal), 2)
        btnadd.Enabled = True
        btnsave.Enabled = True
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        ' Try
        Dim myview As DataView
        Dim b As Integer

        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            b = 0
        Else
            b = DrpSubclass.Selecteditem.Value
        End If


        Dim d As Integer

        If drpSubclass.text = "" Or drpSubclass.text = "Select" Then
            d = 0
        Else
            d = drpSubclass.Selecteditem.Value
        End If

        Dim c As Integer

        If DDSubCategory.text = "" Or DDSubCategory.text = "Select" Then
            c = 0
        Else
            c = DDSubCategory.Selecteditem.Value
        End If

        pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)


        'gvstock.DataBind()
        myview = pstock.DefaultView
        If ddSearch.SelectedItem.Value = 2 Then
            myview.RowFilter = "Item_Code like '%" & replaceapostrophe(txtsearch2.Text.ToString) & "%'"
        ElseIf ddSearch.SelectedItem.Value = 1 Then
            myview.RowFilter = "particulardesc like'%" & replaceapostrophe(txtsearch2.Text.ToString) & "%'"
        Else
            myview.RowFilter = "particulardesc like '%" & replaceapostrophe(txtsearch2.Text.ToString) & "%'"
        End If

        gvstock.DataSource = myview
        gvstock.DataBind()
        gvstock.PageIndex = 0

        CType(gvstock.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
        CType(gvstock.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")

        Session("View") = "Search"
        ' Catch ex As Exception
        'End Try
    End Sub
    Public Function verify() As Boolean
        Dim myview As DataView
        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            pstock = objDerived.GetDataTable("exec ams.FM_StocksNoSubClass  '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpClass.selectedItem.Value & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
            myview = CType(pstock, DataTable).DefaultView
            myview.RowFilter = "ItemDesc ='" & objDerived.replaceapostrophe(txtItemDesc.Text) & "'  and Unit_ID=" & ddUnit.SelectedItem.Value & ""
        Else
            pstock = objDerived.GetDataTable("exec ams.FM_Stocks  '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpClass.selectedItem.Value & "','" & drpSubClass.selectedItem.Value & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
            myview = CType(pstock, DataTable).DefaultView
            myview.RowFilter = "ItemDesc ='" & objDerived.replaceapostrophe(txtItemDesc.Text) & "'  and Unit_ID=" & ddUnit.SelectedItem.Value & ""
        End If
        'If myview.Count <> 0 Then
        '    Return True
        'Else
        '    Return False
        'End If
        If myview.Count <> 0 Then
            Return False
        Else
            Return False
        End If
    End Function

    Public Function verify2() As Boolean
        Dim myview As DataView
        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            pstock = objDerived.GetDataTable("exec ams.FM_StocksNoSubClass  '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpClass.selectedItem.Value & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
            myview = CType(pstock, DataTable).DefaultView
            myview.RowFilter = "ItemDesc ='" & objDerived.replaceapostrophe(txtItemDesc.Text) & "'  and Unit_ID=" & ddUnit.SelectedItem.Value & ""
        Else
            pstock = objDerived.GetDataTable("exec ams.FM_Stocks  '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpClass.selectedItem.Value & "','" & drpSubClass.selectedItem.Value & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
            myview = CType(pstock, DataTable).DefaultView
            myview.RowFilter = "ItemDesc ='" & objDerived.replaceapostrophe(txtItemDesc.Text) & "'  and Unit_ID=" & ddUnit.SelectedItem.Value & ""
        End If
        If myview.Count <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Protected Sub loadparticular()
        'pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("GA_ID") & "','" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("BGA_ID") & "'", CommandType.Text)
        Dim subClassId As Integer
        If Not Integer.TryParse(DrpSubClass.SelectedValue, subClassId) Then subClassId = 0

        If drpsubClass.text = "Select" Or drpsubClass.text = "" Then


            pParticular = objDerived.GetDataTable("exec ams.FMparticularsSuppliesNoSubClass '" & GenAccnt.selectedItem.value & "','" & DrpClass.SelectedItem.Value & "'", CommandType.Text)
            ddParticular.DataSource = pParticular
            ddParticular.DataTextField = "description"
            ddParticular.DataValueField = "item_particular_id"
            ddParticular.DataBind()
            ddParticular.Items.Insert(0, New ListItem("Select", "0"))
        Else
            pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selectedItem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "'", CommandType.Text)
            ddParticular.DataSource = pParticular
            ddParticular.DataTextField = "description"
            ddParticular.DataValueField = "item_particular_id"
            ddParticular.DataBind()
            ddParticular.Items.Insert(0, New ListItem("Select", "0"))
        End If

        pParticulardata = objDerived.GetDataTable("exec [AMS].[FMparticularsSupplies_data] '" & GenAccnt.selecteditem.value & "','0'", CommandType.Text)
        gvparticular.DataSource = pParticulardata
        gvparticular.DataBind()

        Dim category As String

        If ddparticular.selecteditem.value = "Select" Then
            category = "0"
        Else
            category = ddparticular.selecteditem.value
        End If


        SubCat = objDerived.GetDataTable("exec [AMS].[FMSuBcategory]'" & category & "'", CommandType.Text)
        Gridview2.DataSource = SubCat
        Gridview2.DataBind()



    End Sub
    Protected Sub LoadSupplies()
        Me.ddyear.Enabled = False
        Session("CYNow") = "CY" & Me.ddyear.SelectedValue.ToString
        Session("CYPrev") = "CY" & Me.ddyear.SelectedValue.ToString - 1

        Try

            Try
                'pstock = objDerived.GetDataTable("exec ams.FM_Stocks '" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("GA_ID") & "','" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("BGA_ID") & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
                'pstock = objDerived.GetDataTable("exec ams.FM_Stocks '" & grdAccounts.SelectedDataKey("GA_ID") & "','" & grdAccounts.SelectedDataKey("BGA_ID") & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
                'gvstock.DataSource = pstock
                'gvstock.DataBind()

            Catch ex As Exception
                Dim Isexist As New Boolean
                Try
                    Isexist = IIf(IsDBNull(objDerived.GetValue("select [AMS].[CheckColumnname] (" & Session("CYPrev") & ")", CommandType.Text)), 0, (objDerived.GetValue("select [AMS].[CheckColumnname] (" & Me.ddyear.SelectedValue.ToString & ")", CommandType.Text)))
                Catch ex1 As Exception
                    Isexist = False
                End Try

                If Isexist = False Then
                    objDerived.GetRecords("ALTER TABLE dbo.m_item_detail ADD " & Session("CYPrev") & " decimal(18,2)", CommandType.Text)
                End If

                'pstock = objDerived.GetDataTable("exec ams.FM_Stocks '" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("GA_ID") & "','" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("BGA_ID") & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
                'pstock = objDerived.GetDataTable("exec ams.FM_Stocks '" & grdAccounts.SelectedDataKey("GA_ID") & "','" & grdAccounts.SelectedDataKey("BGA_ID") & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
                'gvstock.DataSource = pstock
                'gvstock.DataBind()
            End Try

            ddUnit.Enabled = False
            txtprice.Enabled = False
            txtItemDesc.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = False
            btnsave.Enabled = False
            txtprice.Text = "0.00"

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub LoadSuppliesPerParticular()
        Me.ddyear.Enabled = False
        Session("CYNow") = "CY" & Me.ddyear.SelectedValue.ToString
        Session("CYPrev") = "CY" & Me.ddyear.SelectedValue.ToString - 1
        Session("View") = "Particular"

        Dim b As Integer

        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            b = 0
        Else
            b = DrpSubclass.Selecteditem.Value
        End If

        Dim c As Integer
        If DDSubCategory.text = "" Then
            c = 0
        Else
            c = DDSubCategory.Selecteditem.Value
        End If
        Try
            'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("GA_ID") & "','" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("BGA_ID") & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
            pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpclass.selectedItem.value & "','" & b & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            gvstock.DataSource = pstock
            gvstock.DataBind()

        Catch ex As Exception
            Dim Isexist As New Boolean
            Try
                Isexist = IIf(IsDBNull(objDerived.GetValue("select [AMS].[CheckColumnname] (" & Session("CYPrev") & ")", CommandType.Text)), 0, (objDerived.GetValue("select [AMS].[CheckColumnname] (" & Me.ddyear.SelectedValue.ToString & ")", CommandType.Text)))
            Catch ex1 As Exception
                Isexist = False
            End Try

            If Isexist = False Then
                objDerived.GetRecords("ALTER TABLE dbo.m_item_detail ADD " & Session("CYNow") & " decimal(18,2)", CommandType.Text)
            End If
            'pstock = objDerived.GetDataTable("exec ams.FM_Stocks '" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("GA_ID") & "','" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("BGA_ID") & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
            'pstock = objDerived.GetDataTable("exec ams.FM_Stocks '" & grdAccounts.SelectedDataKey("GA_ID") & "','" & grdAccounts.SelectedDataKey("BGA_ID") & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
            'gvstock.DataSource = pstock
            'gvstock.DataBind()
        End Try

        If pstock.Rows.Count <> 0 Then
            CType(gvstock.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
            CType(gvstock.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")
        End If

        ddUnit.Enabled = False
        txtprice.Enabled = False
        txtItemDesc.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = False
        btnsave.Enabled = False
        txtprice.Text = "0.00"

    End Sub
    'Protected Sub txtItemDesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemDesc.TextChanged
    '    ddUnit.Focus()
    '    btnadd.Enabled = True
    '    btnsave.Enabled = True
    'End Sub

    Protected Sub ddUnit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub ddUnit_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddUnit.SelectedIndexChanged

    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Try

        Dim b As Integer

            If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
                b = 0
            Else
                b = DrpSubclass.Selecteditem.Value
            End If

            Dim c As Integer

        If DDSubCategory.text = "" Or DDSubCategory.text = "Select" Then
            c = 0
        Else
            c = DDSubCategory.Selecteditem.Value
            End If

            Dim d As Integer

            If drpSubclass.text = "" Or drpSubclass.text = "Select" Then
                d = 0
            Else
                d = drpSubclass.Selecteditem.Value
            End If

            Session("CYNow") = "CY" & Me.ddyear.SelectedValue.ToString
            Session("CYPrev") = "CY" & Me.ddyear.SelectedValue.ToString - 1

            '=-= Check if Description was changed
            If Me.Session("oldValueItem").ToString <> txtItemDesc.Text.ToString Then
                If Me.chkInactive.Checked = True Then
                    objDerived.GetRecords("Update dbo.m_item set isUsed=1,Item_Desc='" & objDerived.replaceapostrophe(txtItemDesc.Text) & "' where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)
                Else
                    objDerived.GetRecords("Update dbo.m_item set Item_Desc='" & objDerived.replaceapostrophe(txtItemDesc.Text) & "' where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)
                End If

                edit.PrimaryColumnName = "Item_ID"
                edit.TransactionID = hdnItemSubClass.Value
                edit.TableName = "dbo.m_item"
                edit.ColumnName = "Item_Desc"
                edit.TransactionDate = DateTime.Now
                edit.NewValue = replaceapostrophe(txtItemDesc.Text)
                edit.OldValue = Me.Session("oldValueItem").ToString
                edit.UserID = Me.Session("@UserID")
                edit.UserName2 = Me.Session("@UserName")
                edit.Remarks = txtremarks.Text

                If Me.chkInactive.Checked = True Then
                    edit.isUsed = True
                Else
                    edit.isUsed = False
                End If
                edit.save()


                '=-= AUDIT TRAIL 11-12-2015
                With AuditTrail
                    .TableName = "dbo.m_item"
                    .RowId = hdnItemSubClass.Value
                    .Operation = "UPDATE"
                    .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                    .PerformedBy = Session("@UserName")
                    .FieldName = "Item_Desc"
                    .OldValue = Session("oldValueItem").ToString
                    .NewValue = replaceapostrophe(txtItemDesc.Text)
                    .save()
                End With

            End If


            '=-= Check if Unit was changed
            If Me.Session("oldValueUnit") <> ddUnit.SelectedItem.Value Then

                If Me.chkInactive.Checked = True Then
                    objDerived.GetRecords("Update dbo.m_item set isUsed=1,Unit_ID='" & ddUnit.SelectedItem.Value & "' where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)

                Else
                    objDerived.GetRecords("Update dbo.m_item set Unit_ID='" & ddUnit.SelectedItem.Value & "' where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)
                End If

                edit.PrimaryColumnName = "Item_ID"
                edit.TransactionID = hdnItemSubClass.Value
                edit.TableName = "dbo.m_item"
                edit.ColumnName = "Unit_ID"
                edit.TransactionDate = DateTime.Now
                edit.NewValue = ddUnit.SelectedItem.Value
                edit.OldValue = Me.Session("oldValueUnit").ToString
                edit.UserID = Me.Session("@UserID")
                edit.UserName2 = Me.Session("@UserName")
                edit.Remarks = txtremarks.Text

                If Me.chkInactive.Checked = True Then
                    edit.isUsed = True
                Else
                    edit.isUsed = False
                End If
                edit.save()


                '=-= AUDIT TRAIL 11-12-2015
                With AuditTrail
                    .TableName = "dbo.m_item"
                    .RowId = hdnItemSubClass.Value
                    .Operation = "UPDATE"
                    .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                    .PerformedBy = Session("@UserName")
                    .FieldName = "Unit_ID"
                    .OldValue = Session("oldValueUnit").ToString
                    .NewValue = ddUnit.SelectedItem.Value
                    .save()
                End With

            End If

        Dim itmdtl As Integer = objDerived.getvalue("Select m_Item_detail_Id from dbo.m_item_detail where item_ID ='" & hdnItemSubClass.Value & "'", CommandType.text)
        '=-= Check if Price was changed
        If CType(Me.Session("oldValuePrice"), Decimal) <> CType(txtprice.Text, Decimal) Then
                If Me.chkInactive.Checked = True Then
                    objDerived.GetRecords("Update dbo.m_item_detail set " & Session("CYNow") & "='" & CType(txtprice.Text, Decimal) & "',userId='" & Me.Session("@UserName") & "' where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)
                Else
                    objDerived.GetRecords("Update dbo.m_item_detail set " & Session("CYNow") & "='" & CType(txtprice.Text, Decimal) & "',userId='" & Me.Session("@UserName") & "' where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)
                End If

                '=-= Update the columns Price
                Me.objDerived.Execute("update dbo.m_item_detail set price = '" & CType(txtprice.Text, Decimal) & "'  where Item_id = '" & hdnItemSubClass.Value & "'", CommandType.Text)

                edit.PrimaryColumnName = "Item_ID"
                edit.TransactionID = hdnItemSubClass.Value
                edit.TableName = "dbo.m_item_detail"
                edit.ColumnName = "price"
                edit.TransactionDate = DateTime.Now
                edit.NewValue = txtprice.Text.ToString
                edit.OldValue = Me.Session("oldValuePrice").ToString
                edit.UserID = Me.Session("@UserID")
                edit.UserName2 = Me.Session("@UserName")
                edit.Remarks = txtremarks.Text

                If Me.chkInactive.Checked = True Then
                    edit.isUsed = True
                Else
                    edit.isUsed = False
                End If
                edit.save()

                '=-= AUDIT TRAIL 11-12-2015
                With AuditTrail
                    .TableName = "dbo.m_item_detail"

                    .RowId = itmdtl
                    .Operation = "UPDATE"
                    .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                    .PerformedBy = Session("@UserName")
                    .FieldName = "price"
                    .OldValue = Session("oldValuePrice").ToString
                    .NewValue = txtprice.Text.ToString
                    .save()
                End With

            End If


            '=-= Check if Re-order Point was Changed
            Dim Rpoint As Integer = objDerived.GetValue("SELECT reorderPT FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
            If Rpoint <> txtReorderPoint.Text Then
                If Me.chkInactive.Checked = True Then
                    objDerived.GetRecords("Update dbo.m_item set isUsed=1,reorderPT = '" & txtReorderPoint.Text & "' where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)
                Else
                    objDerived.GetRecords("Update dbo.m_item set reorderPT = '" & txtReorderPoint.Text & "' where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)
                End If

                edit.PrimaryColumnName = "Item_ID"
                edit.TransactionID = hdnItemSubClass.Value
                edit.TableName = "dbo.m_item"
                edit.ColumnName = "reorderPT"
                edit.TransactionDate = DateTime.Now
                edit.NewValue = txtReorderPoint.Text
                edit.OldValue = Rpoint
                edit.UserID = Me.Session("@UserID")
                edit.UserName2 = Me.Session("@UserName")
                edit.Remarks = txtremarks.Text

                If Me.chkInactive.Checked = True Then
                    edit.isUsed = True
                Else
                    edit.isUsed = False
                End If
                edit.save()

                '=-= AUDIT TRAIL 11-12-2015
                With AuditTrail
                    .TableName = "dbo.m_item"
                    .RowId = hdnItemSubClass.Value
                    .Operation = "UPDATE"
                    .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                    .PerformedBy = Session("@UserName")
                    .FieldName = "reorderPT"
                    .OldValue = Rpoint
                    .NewValue = txtReorderPoint.Text
                    .save()
                End With

            End If


            '=-= Check Item_Code
            Dim ItemCode As String = objDerived.GetValue("SELECT Item_Code FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
            If ItemCode <> txtItemCode.Text Then
                If Me.chkInactive.Checked = True Then
                    objDerived.GetRecords("Update dbo.m_item set isUsed=1, Item_Code = '" & txtItemCode.Text & "' where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)
                Else
                    objDerived.GetRecords("Update dbo.m_item set Item_Code = '" & txtItemCode.Text & "' where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)
                End If

                edit.PrimaryColumnName = "Item_ID"
                edit.TransactionID = hdnItemSubClass.Value
                edit.TableName = "dbo.m_item"
                edit.ColumnName = "Item_Code"
                edit.TransactionDate = DateTime.Now
                edit.NewValue = txtItemCode.Text
                edit.OldValue = ItemCode
                edit.UserID = Me.Session("@UserID")
                edit.UserName2 = Me.Session("@UserName")
                edit.Remarks = txtremarks.Text

                If Me.chkInactive.Checked = True Then
                    edit.isUsed = True
                Else
                    edit.isUsed = False
                End If
                edit.save()

                '=-= AUDIT TRAIL 11-12-2015
                With AuditTrail
                    .TableName = "dbo.m_item"
                    .RowId = hdnItemSubClass.Value
                    .Operation = "UPDATE"
                    .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                    .PerformedBy = Session("@UserName")
                    .FieldName = "Item_Code"
                    .OldValue = ItemCode
                    .NewValue = txtItemCode.Text
                    .save()
                End With

            End If
            pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            gvstock.DataSource = pstock
            gvstock.DataBind()


            If Me.chkInactive.Checked = True Then
                objDerived.GetRecords("Update dbo.m_item set isUsed=1 where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)
            Else
                objDerived.GetRecords("Update dbo.m_item set isUsed=0 where Item_ID=" & hdnItemSubClass.Value & "", CommandType.Text)
            End If

            Dim BrndName As String = objDerived.GetValue("SELECT Brand FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
            If BrndName <> TextBoxBrand.Text Then
                objDerived.GetRecords("UPDATE dbo.m_item SET Brand ='" & TextBoxBrand.Text & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
            End If

            Dim ClrName As String = objDerived.GetValue("SELECT Color FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
            If ClrName <> TextBoxColor.Text Then
                objDerived.GetRecords("UPDATE dbo.m_item SET Color ='" & TextBoxColor.Text & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
            End If

            Dim SzName As String = objDerived.GetValue("SELECT Size FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
            If SzName <> TextBoxSize.Text Then
                objDerived.GetRecords("UPDATE dbo.m_item SET Size ='" & TextBoxSize.Text & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
            End If



            Dim SubC As String = objDerived.GetValue("SELECT SubClassificationID FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)

            If SubC Is Nothing Then

                objDerived.GetRecords("UPDATE dbo.m_item SET SubclassificationID ='" & DrpSubClass.SelectedItem.Value & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)

            Else
                If SubC <> DrpSubClass.SelectedItem.Text Then
                    objDerived.GetRecords("UPDATE dbo.m_item SET SubclassificationID ='" & DrpSubClass.SelectedItem.Value & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
                    objDerived.GetRecords("UPDATE dbo.tblclassmatrix SET SubclassificationID ='" & DrpSubClass.SelectedItem.Value & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
                End If
            End If

            Dim GenA As String = objDerived.GetValue("SELECT GA_ID FROM tblclassmatrix WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
            If GenA Is Nothing Then
                'objDerived.GetRecords("UPDATE dbo.m_item SET GA_ID ='" & GenAccnt.SelectedItem.Value & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
            Else
                If GenA <> GenAccnt.SelectedItem.Text Then
                'objDerived.GetRecords("UPDATE dbo.m_item SET GA_ID ='" & GenAccnt.SelectedItem.Value & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE dbo.tblclassmatrix SET GA_ID ='" & GenAccnt.SelectedItem.Value & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
                End If
            End If

            pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            gvstock.DataSource = pstock
            gvstock.DataBind()





            ddUnit.Enabled = False
            txtItemCode.Enabled = False
            txtprice.Enabled = False
            txtItemDesc.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = False
            btnsave.Enabled = False
            txtremarks.Text = ""
            gvstock.SelectedIndex = -1

            If ddParticular.SelectedValue = 0 Then
                LoadSupplies()
            Else



            End If


            ddUnit.Enabled = False
            txtprice.Enabled = False
            txtItemDesc.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = False
            btnsave.Enabled = False
            gvstock.SelectedIndex = -1

            CType(gvstock.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
            CType(gvstock.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")

            btnsave.Enabled = False

        'Catch ex As Exception

        'End Try
    End Sub

    Protected Sub chkInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkInactive.CheckedChanged

    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Option") = "Select"
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chk As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(chk.NamingContainer, GridViewRow)

        objDerived.GetRecords("Update dbo.m_Item set isUsed = '" & chk.Checked & "' where item_id = " & Me.gvstock.DataKeys(gvr.RowIndex).Item(4), CommandType.Text)

        If chk.Checked = True Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Selected items has been successfully hidden.")
        ElseIf chk.Checked = False Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Selected items has been successfully visible.")
        End If
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("CYNow") = "CY" & Me.ddyear.SelectedValue.ToString
        Session("CYPrev") = "CY" & Me.ddyear.SelectedValue.ToString - 1

        gvstock.Columns(9).HeaderText = Session("CYPrev")
        gvstock.Columns(10).HeaderText = Session("CYNow")



        'Try
        Dim stocks As Boolean
        stocks = False
        Me.chkInactive.Visible = False

        'pCode = objDerived.GetDataTable("SELECT * from ams.vw_supplies ORDER BY GA_Code2", CommandType.Text)
        'ddAccountCode.DataSource = pCode
        'ddAccountCode.DataTextField = "GA_Title2"
        'ddAccountCode.DataValueField = "GA_CODE2"
        'ddAccountCode.DataBind()
        'ddAccountCode.Items.Insert(0, "Select")


        DropdownClassification()
        pCode = objDerived.GetDataTable("SELECT * from ams.vw_supplies ORDER BY GA_Code2", CommandType.Text)
        'grdAccounts.DataSource = pCode
        'grdAccounts.DataBind()

        ddUnit.Enabled = False
        txtprice.Enabled = False
        txtItemDesc.Enabled = False
        btnadd.Enabled = False
        btnedit.Enabled = False
        btnsave.Enabled = False

        ddUnit.DataSource = Nothing
        ddUnit.DataBind()



        ddUnit.DataSource = objDerived.GetRecords("exec [AMS].[loadunit]", CommandType.Text)
        ddUnit.DataTextField = "description"
        ddUnit.DataValueField = "Unit_ID"
        ddUnit.DataBind()

        txtprice.Attributes.Add("OnFocus", "this.select()")
        txtItemDesc.Attributes.Add("OnFocus", "this.select()")
        'loadparticular()
        'LoadSupplies()


        txtSearchAccnt.Enabled = True
        btnSearchAccnt.Enabled = True
        LoadItems()
        Session("Search") = 0

        'Catch ex As Exception
        '    msg()
        'End Try
    End Sub
    Protected Sub bntcopyPerGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("IsClickAll") = True
        For Each row As GridViewRow In Me.gvstock.Rows
            Dim therowindex As Integer = row.RowIndex
            Dim theid As Integer
            theid = gvstock.DataKeys(therowindex)(4).ToString
            'objDerived.GetRecords("update dbo.m_item_detail set " & Session("CYNow") & " =" & gvstock.DataKeys(therowindex)(3).ToString & " where Item_ID=" & gvstock.DataKeys(therowindex)(4).ToString & "", CommandType.Text)
            objDerived.GetRecords("update dbo.m_item_detail set " & Session("CYNow") & " = case when  " & Session("CYPrev") & "  is null  then isnull(" & gvstock.DataKeys(therowindex)(10).ToString & ",0) else isnull(" & gvstock.DataKeys(therowindex)(3).ToString & ",0) end   where Item_ID=" & gvstock.DataKeys(therowindex)(4).ToString & " and( " & Session("CYNow") & " is null or " & Session("CYNow") & "='0.00' )", CommandType.Text)

        Next


    End Sub

    Protected Sub btncopyall_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Session("IsClickAll") = True
        Try
            '    Me.objDerived.GetRecords("update dbo.m_item_detail set " & Session("CYNow") & "=" & Session("CYPrev") & " from dbo.m_item inner join  dbo.m_item_detail on  dbo.m_item.item_id = dbo.m_item_detail.item_id inner join  ams.item_particular on   dbo.m_item.Item_particular_id = ams.item_particular.Item_particular_id where ams.item_particular.ga_id=" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("GA_ID") & " and ams.item_particular.bga_id=" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("BGA_ID") & "", CommandType.Text)
            Me.objDerived.GetRecords("update dbo.m_item_detail set " & Session("CYNow") & "=case when  " & Session("CYPrev") & " is null  then isnull(price,0) else isnull(" & Session("CYPrev") & ",0) end from dbo.m_item inner join  dbo.m_item_detail on  dbo.m_item.item_id = dbo.m_item_detail.item_id inner join  ams.item_particular on   dbo.m_item.Item_particular_id = ams.item_particular.Item_particular_id where ams.item_particular.ga_id='" & GenAccnt.selecteditem.value & "' and ams.item_particular.bga_id='0' And " & Session("CYNow") & " is null or  " & Session("CYNow") & "='0.00' ", CommandType.Text)

        Catch ex As Exception
        End Try

        Dim b As Integer


        Dim C As String

        If DDSubCategory.text = "" Then
            C = 0
        Else
            C = DDSubCategory.Selecteditem.Value
        End If


        pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpclass.selectedItem.value & "','" & b & "','" & C & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        gvstock.DataSource = pstock
        gvstock.DataBind()
        ' msg.UserMsgBox("Have Successfully updated the price", Me, False)
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ModalPopupExtender2.Show()

    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs)

        txtSubCat.Enabled = False
        SubCatdata = objDerived.GetDataTable("exec [AMS].[FMSuBcategory]'" & ddParticular.selecteditem.value & "'", CommandType.Text)
        Gridview2.DataSource = SubCatdata
        Gridview2.DataBind()
        TxtSubCat.text = ddParticular.Selecteditem.text


        ModalpopupExtender4.Show()


    End Sub

    Protected Sub btnaddparticular_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtparticular.Text = ""
        txtParticularCode.Text = ""
        TextBox6.Text = 0
        txtlife.text = ""
        txtparticular.ReadOnly = False
        btnaddparticular.Enabled = True
        ddSubCategory.Enabled = True
        btnsaveparticular.Enabled = True
        SubCattxt.text = ""
        gvparticular.SelectedIndex = -1
        ModalPopupExtender2.Show()

    End Sub


    Protected Sub btnsaveparticular_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim a As Integer
        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            a = 0
        Else
            a = DrpSubclass.Selecteditem.Value
        End If


        If btnsaveparticular.Text = "Save" Then
            Dim Dparticular = objDerived.getvalue("select count(*) from ams.item_particular where isnull(SubClassificationID,0) ='" & a & "' And ClassificationID ='" & drpclass.SelectedItem.Value & "' and ga_id ='" & GenAccnt.selectedItem.Value & "'", CommandType.Text)
            If Dparticular = 0 Then
                With particular
                    particular.description = txtparticular.Text
                    particular.GA_ID = GenAccnt.selecteditem.value
                    particular.BGA_ID = 0
                    particular.useful_life = txtLife.Text
                    particular.ClassificationID = DrpClass.selectedItem.value
                    particular.SubClassificationID = a
                    '.ParticularCode = txtParticularCode.Text
                    particular.save()
                End With
                'Dim Val As Integer = Me.objDerived.getvalue("Select Item_particular_id from Ams.Item_particular where description like '%" & txtparticular.text & "%'", CommandType.Text)
                'Me.objDerived.Execute("INSERT INTO tblclassmatrix (classificationID,CategoryID,ga_id)Values('" & drpclass.selectedItem.Value & "','" & Val & "','" & GenAccnt.SelectedItem.Value & "')", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")

            Else




                Dim gvparticular = objDerived.getvalue("select count(*) from ams.item_particular where description = '" & txtparticular.text & "' and ClassificationID='" & DrpClass.selectedvalue & "' and SubClassificationID='" & DrpSubClass.selectedvalue & "'", CommandType.Text)
                If gvparticular = 0 Then
                    With particular
                        particular.description = txtparticular.Text
                        particular.GA_ID = GenAccnt.selecteditem.value
                        particular.BGA_ID = 0
                        particular.useful_life = txtLife.Text
                        particular.ClassificationID = DrpClass.selectedItem.value
                        particular.SubClassificationID = a
                        particular.ParticularCode = txtParticularCode.Text
                        particular.save()
                    End With
                    'Dim Val As Integer = Me.objDerived.getvalue("Select Item_particular_id from Ams.Item_particular where description like '%" & txtparticular.text & "%'", CommandType.Text)
                    'Me.objDerived.Execute("INSERT INTO tblclassmatrix (classificationID,CategoryID,ga_id)Values('" & drpclass.selectedItem.Value & "','" & Val & "','" & GenAccnt.SelectedItem.Value & "')", CommandType.Text)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")
                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Record Already Exist.")
                End If

                'Exit Sub
            End If


        ElseIf btnsaveparticular.Text = "Update" Then
            objDerived.GetRecords("Update ams.item_particular set description='" & txtparticular.Text & "', useful_life = '" & txtLife.Text & "'  where item_particular_id='" & gvparticular.SelectedDataKey("item_particular_id") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Record has been successfully updated.")


            btnsaveparticular.Text = "Save"
        Else
            objDerived.GetRecords("Update ams.item_particular set description='" & txtparticular.Text & "', useful_life = '" & txtLife.Text & "'  where item_particular_id='" & gvparticular.SelectedDataKey(0) & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully updated.")

            If drpsubClass.text = "" Or DrpSubClass.text = "Select" Then

                pParticular = objDerived.GetDataTable("exec ams.FMparticularsSuppliesNoSubClass '" & GenAccnt.selecteditem.value & "','" & DrpClass.SelectedItem.Value & "'", CommandType.Text)
            Else
                pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "'", CommandType.Text)
            End If
            btnsaveparticular.Text = "Save"
        End If



        pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selectedItem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & a & "'", CommandType.Text)
        ddparticular.datasource = pParticular
        ddparticular.datatextfield = "description"
        ddparticular.datavaluefield = "item_particular_id"
        ddparticular.databind()
        ddParticular.Items.Insert(0, New ListItem("Select", "0"))



        gvparticular.datasource = pParticular
        gvparticular.databind()

        ModalPopupExtender2.Show()

    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim myview As DataView

        Dim a As Integer
        If DdSubClassification.Text = "" Or DdSubClassification.Text = "Select" Then
            a = 0
        Else
            a = DdSubClassification.SelectedItem.value
        End If


        pstock = objDerived.GetDataTable("Select * from tbl_Classification", CommandType.Text)
        GvClass.DataSource = pstock
        GvClass.DataBind()


        myview = pstock.DefaultView


        myview.RowFilter = "ClassificationName like '%" & replaceapostrophe(TextBox12.Text.ToString) & "%'"


        GvClass.DataSource = myview
        GvClass.DataBind()
        GvClass.PageIndex = 0

        'CType(GvClass.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
        'CType(GvClass.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")

        Session("View") = "Search"


        ModalPopupExtender5.Show()
    End Sub
    Protected Sub gvparticular_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Trace: Log entry into the method
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Log", "console.log('Entered gvparticular_SelectedIndexChanged method.');", True)

        ' Ensure the DataKey index exists for the selected row.
        If gvparticular.SelectedIndex >= 0 Then
            ' Trace: Log the selected index
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LogSelectedIndex", "console.log('Selected Index: " & gvparticular.SelectedIndex.ToString() & "');", True)

            txtparticular.ReadOnly = False
            btnsaveparticular.Text = "Update"
            btnaddparticular.Enabled = False
            btnsaveparticular.Enabled = True

            ' Trace: Log the txtparticular ReadOnly and button states
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LogButtonStates", "console.log('txtparticular.ReadOnly = ' + " & txtparticular.ReadOnly.ToString() & "); console.log('btnsaveparticular.Enabled = " & btnsaveparticular.Enabled.ToString() & "');", True)

            ' Clear previous value of txtLife
            txtLife.Text = ""

            ' Trace: Log clearing txtLife
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LogClearLife", "console.log('txtLife cleared.');", True)

            ' Set the value of txtparticular from the selected DataKey
            txtparticular.Text = gvparticular.SelectedDataKey("description").ToString()

            ' Trace: Log the value of txtparticular
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LogParticular", "console.log('txtparticular value: " & txtparticular.Text & "');", True)

            ' Access the useful_life from SelectedDataKey by name
            Dim usefulLife As Object = gvparticular.SelectedDataKey("useful_life")

            ' Trace: Log the value of usefulLife
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LogUsefulLife", "console.log('usefulLife: " & usefulLife.ToString() & "');", True)

            ' If the useful_life column is not DBNull, assign it to txtLife
            If Not IsDBNull(usefulLife) Then
                txtLife.Text = usefulLife.ToString()

                ' Trace: Log the value set in txtLife
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LogUsefulLifeSet", "console.log('txtLife value set to: " & txtLife.Text & "');", True)
            Else
                ' Default to 0 if DBNull
                txtLife.Text = "0"

                ' Trace: Log setting default value
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LogUsefulLifeDefault", "console.log('txtLife value set to default: 0');", True)
            End If

            ' Show the ModalPopup
            ModalPopupExtender2.Show()

            ' Trace: Log showing the modal
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LogShowModal", "console.log('ModalPopupExtender2.Show() called.');", True)
        End If
    End Sub

    Protected Sub Gridview2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        txtparticular.ReadOnly = False
        'txtlife.ReadOnly = True

        btnaddparticular.Enabled = False
        btnsaveparticular.Enabled = True

        TxtSubCat.Text = Gridview2.SelectedDataKey("description")
        SubCattxt.Text = Gridview2.SelectedDataKey("subcat_desc")


        TextBox6.Text = Gridview2.SelectedDataKey(3).ToString
        gvparticular1.text = "Update"
        ModalPopupExtender4.Show()
    End Sub

    Protected Sub gvparticular_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pParticulardata = objDerived.GetDataTable("exec [AMS].[FMparticularsSupplies_data] '" & GenAccnt.selecteditem.value & "','0'", CommandType.Text)
        gvparticular.PageIndex = e.NewPageIndex
        gvparticular.DataSource = pParticulardata
        'gvparticular.DataSource = CType(pParticular, DataTable)
        gvparticular.DataBind()
        ModalPopupExtender2.Show()

    End Sub

    Protected Sub ddParticular_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        ' LoadSuppliesPerParticular()
        ddUnit.ClearSelection()
        ddUnit.DataSource = objDerived.GetRecords("exec [AMS].[loadunit]", CommandType.Text)
        ddUnit.DataTextField = "description"
        ddUnit.DataValueField = "Unit_ID"
        ddUnit.DataBind()
        ddUnit.Items.Insert(0, "Select")

        Dim items As New DataTable
        items = objDerived.GetDataTable("select SubCategoryID,SubCat_Desc from dbo.tbl_SubCategory where Item_particular_id = " & ddParticular.selecteditem.value & "Order by Subcat_Desc", CommandType.Text)
        ddSubCategory.DataSource = items
        ddSubCategory.DataTextField = "SubCat_Desc"
        ddSubCategory.DataValueField = "SubCategoryID"
        ddSubCategory.DataBind()
        'ddSubCategory.Items.Insert(0, "Select")
        ddSubCategory.Items.Insert(0, New ListItem("Select", "0"))

        ddSubCategory.Enabled = True
        Session("CYNow") = "CY" & ddYear.SelectedItem.Text
        Session("CYPrev") = "CY" & ddYear.SelectedItem.Text - 1

        Dim c As Integer

        If drpSubclass.text = "" Or drpSubclass.text = "Select" Then
            c = 0
        Else
            c = drpSubclass.Selecteditem.Value
        End If

        dtItems = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        gvstock.DataSource = dtItems
        gvstock.DataBind()
        gvstock.SelectedIndex = -1


    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim items As New DataTable
        items = objDerived.GetDataTable("Select * from dbo.View_ItemsList order by Item_Desc", CommandType.Text)
        grdITEMS.DataSource = items
        grdITEMS.DataBind()

        btnDel.Enabled = False
        ModalPopupExtender3.Show()
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim items As New DataTable
        If DropDownList1.SelectedItem.Value = 1 Then
            items = objDerived.GetDataTable("Select * from dbo.View_ItemsList order by Item_Desc", CommandType.Text)
            gvstock.DataSource = items
            gvstock.DataBind()

        Else
            items = objDerived.GetDataTable("Select * from AMS.View_ItemsList order by Description", CommandType.Text)
            gvstock.DataSource = items
            gvstock.DataBind()
        End If
        btnDel.Enabled = False
        ModalPopupExtender3.Show()

    End Sub

    Protected Sub grdITEMS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnDel.Enabled = True
        ModalPopupExtender3.Show()
    End Sub

    Protected Sub btnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'objDerived.GetRecords("Delete from dbo.Supplier where Supplier_Id ='" & gvbody.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
        Dim itemcheck As New DataTable
        itemcheck = objDerived.GetDataTable("", CommandType.Text)
    End Sub


    Protected Sub grdAccounts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
        '    e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
        '    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdAccounts, "Select$" + e.Row.RowIndex.ToString()))
        'End If
    End Sub

    Protected Sub grdAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        loadparticular()

        ddParticular.Enabled = True
        ddUnit.Enabled = False
        txtItemDesc.Enabled = False
        'Button1.Enabled = True
        LinkButton3.Enabled = True
    End Sub

    Protected Sub btnSearchAccnt_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = pCode.DefaultView
        myview.RowFilter = "GA_Title2 like '%" & replaceapostrophe(txtSearchAccnt.Text.ToString) & "%'"
        'grdAccounts.DataSource = myview
        'grdAccounts.DataBind()
        'grdAccounts.PageIndex = 0

        ddUnit.Enabled = False
        txtprice.Enabled = False
        txtItemDesc.Enabled = False
        btnadd.Enabled = False
        btnedit.Enabled = False
        btnsave.Enabled = False
        ddParticular.Enabled = False

        Session("Search") = 1

    End Sub

    Protected Sub txtItemDesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim dt As New DataTable
        'Dim Desc As String = ddParticular.SelectedItem.Text + " - " + replaceapostrophe(txtItemDesc.Text)
        'dt = objDerived.GetDataTable("SELECT DISTINCT dbo.m_item.Item_Desc, AMS.item_particular.GA_ID FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id WHERE dbo.m_item.Item_Desc = '" & replaceapostrophe(Desc) & "' AND AMS.item_particular.GA_ID = '" & gvstock.SelectedDataKey("GA_ID") & "'", CommandType.Text)
        'If dt.Rows.Count = 0 Then
        '    imgCheck.Visible = True
        '    lblmsg.Visible = False
        'Else
        '    imgCheck.Visible = False
        '    lblmsg.Visible = True
        'End If

    End Sub



    Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Session("Option") = "Delete"
    End Sub

    Protected Sub txtItemCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles txtItemCode.TextChanged

        Dim ItemCode As Integer
        If ItemCode = 0 Then
            btnsave.Enabled = True
            Image2.Visible = True
            Label4.Visible = False
        Else
            btnsave.Enabled = False
            Image2.Visible = False
            Label4.Visible = True
        End If

    End Sub


    Protected Sub DrpClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        'ddSubCategory.items.clear()
        'ddParticular.items.clear()
        'DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies where ClassificationID ='" & DrpClass.SelectedItem.Value & "' and BGA_ID = 0 Order by ga_title", CommandType.Text)
        'GenAccnt.DataSource = DrpGenAcc
        'GenAccnt.DataTextField = "GA_title"
        'GenAccnt.DataValueField = "GA_ID"
        'GenAccnt.items.clear()
        'GenAccnt.DataBind()
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
            DrpSubClass.Items.Insert(0, New ListItem("Select", "0"))
        End If

        If DrpClass.SelectedItem.Value = 5 Or DrpClass.Text = "Medicines" Then
            TextBoxGen.enabled = "True"
            GenName.Visible = True
        Else
            TextBoxGen.enabled = "False"
            GenName.Visible = False
        End If
        'DrpSubClassF = objDerived.GetDataTable("Select SubClassificationID, SubclassificationName from dbo.tbl_SubClassification where ClassificationID = '" & DrpClass.SelectedItem.Value & "'", CommandType.Text)
        'DrpSubClass.DataSource = DrpSubClassF
        'DrpSubClass.DataTextField = "SubClassificationName"
        'DrpSubClass.DataValueField = "SubClassificationID"
        'DrpSubClass.items.clear()
        'DrpSubClass.DataBind()

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

        Session("CYNow") = "CY" & ddYear.SelectedItem.Text
        Session("CYPrev") = "CY" & ddYear.SelectedItem.Text - 1
        'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpclass.selectedItem.value & "','" & b & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        ''pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & "0" & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
        'gvstock.DataSource = pstock
        'gvstock.DataBind()
        'End If


        ddParticular.items.clear()
        ddSubCategory.items.clear()

        textboxbrand.text = ""
        textboxColor.text = ""
        textboxSize.text = ""
        txtItemDesc.text = ""

        txtprice.text = ""
        txtItemCode.text = ""



        Session("Action") = "Save"
    End Sub
    Public Sub DropdownClassification()


        dtClass = objDerived.GetDataTable("Select * from dbo.tbl_Classification where AllotmentClass_id = 2 order by seqno ", CommandType.Text)



        DrpClass.DataSource = dtClass
        DrpClass.DataTextField = "ClassificationName"
        DrpClass.DataValueField = "ClassificationID"

        DrpClass.DataBind()
        DrpClass.Items.Insert(0, New ListItem("Select", "0"))
        'DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies where ClassificationID ='" & DrpClass.SelectedItem.Value & "' and BGA_ID = 0 Order by ga_title", CommandType.Text)
        'DrpGenAcc = objDerived.GetDataTable("Exec [AMS].[FMgetGenAccnt]'" & DrpClass.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "'", CommandType.Text)
        'GenAccnt.DataSource = DrpGenAcc
        'GenAccnt.DataTextField = "GA_title"
        'GenAccnt.DataValueField = "GA_ID"
        'GenAccnt.Items.Insert(0, "Select")
        'GenAccnt.items.clear()
        'GenAccnt.DataBind()


    End Sub
    Protected Sub GenAccnt_Textchanged(sender As Object, e As EventArgs)
        ddSubCategory.items.clear()
        ddParticular.items.clear()
        Dim items As New DataTable
        items = objDerived.GetDataTable("select SubCategoryID,SubCat_Desc from dbo.tbl_SubCategory where Item_particular_id = " & ddParticular.selecteditem.value & "Order by Subcat_Desc", CommandType.Text)
        ddSubCategory.DataSource = items
        ddSubCategory.DataTextField = "SubCat_Desc"
        ddSubCategory.DataValueField = "SubCategoryID"
        ddSubCategory.DataBind()
        'ddSubCategory.Items.Insert(0, "Select")
        ddSubCategory.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub GenAccnt_SelectedIndexChanged(sender As Object, e As EventArgs)
        ddParticular.enabled = True
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
        ddParticular.Items.Insert(0, New ListItem("Select", "0"))


        If ddParticular.selecteditem.value = "Select" Then


            Dim items As New DataTable
            items = objDerived.GetDataTable("select SubCategoryID,SubCat_Desc from dbo.tbl_SubCategory Order by Subcat_Desc", CommandType.Text)
            SubCattxt.text = ""

            ddSubCategory.DataSource = items
            ddSubCategory.DataTextField = "SubCat_Desc"
            ddSubCategory.DataValueField = "SubCategoryID"
            ddSubCategory.DataBind()
            'ddSubCategory.Items.Insert(0, "Select")
            ddSubCategory.Items.Insert(0, New ListItem("Select", "0"))
            ddSubCategory.Selecteditem.value = +1
        End If


        Dim c As Integer

        If drpSubclass.text = "" Or drpSubclass.text = "Select" Then
            c = 0
        Else
            c = drpSubclass.Selecteditem.Value
        End If

        dtItems = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        gvstock.DataSource = dtItems
        gvstock.DataBind()
        gvstock.SelectedIndex = -1



        Me.gvstock.Columns(9).HeaderText = "Price " & "(" & Session("CYPrev") & ")"
        Me.gvstock.Columns(10).HeaderText = "Price " & "(" & Session("CYNow") & ")"
    End Sub
    Private Sub LoadItems()
        'Session("CYNow") = "CY" & ddYear.SelectedItem.Text
        'Session("CYPrev") = "CY" & ddYear.SelectedItem.Text - 1
        'dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_FM_ItemList] '" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & Session("CYPrev") & "','" & Session("CYNow") & "',null", CommandType.Text)
        'gvstock.DataSource = dtItems
        'gvstock.DataBind()
        'gvstock.SelectedIndex = -1

        'If dtItems.Rows.Count <> 0 Then
        '    CType(grdItems.HeaderRow.Cells(5).FindControl("lblHeader_Previous"), Label).Text = Session("CYPrev")
        '    CType(grdItems.HeaderRow.Cells(6).FindControl("lblHeader_Current"), Label).Text = Session("CYNow")
        'End If

        btnAdd.Enabled = True
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        txtparticular.ReadOnly = False
        'txtlife.ReadOnly = True
        btnedit.Enabled = True
        btnaddparticular.Enabled = False
        btnsaveparticular.Enabled = True
        btnsaveparticular.Text = "Update"

        'txtparticular.Text = GridView1.SelectedDataKey("item_particular_id")
        ddparticular.selectedindex = ddparticular.items.indexof(ddparticular.items.FindByValue(GridView1.SelectedDataKey("item_particular_id")))
        'txtParticular_desc.text = GridView1.SelectedDataKey("Particular_desc")
        txtItemDesc.text = GridView1.SelectedDataKey("ItemDesc")
        ddunit.selectedindex = ddunit.items.indexof(ddUnit.items.FindByValue(GridView1.SelectedDataKey("Unit_ID")))
        txtPrice.text = GridView1.SelectedDataKey("Year_Current")
        txtItemCode.text = GridView1.SelectedDataKey("Item_Code")

        '   ddUnit.items.FindByValue(GridView1.SelectedDataKey("Unit_ID")).selected = True
        ' msgbox(ddUnit.selected)

        '  txtLife.Text = GridView1.SelectedDataKey("ItemDesc")

        'ModalPopupExtender2.Show()
    End Sub
    Protected Sub LinkButton3_Click(sender As Object, e As EventArgs)
        'pParticulardata = objDerived.GetDataTable("exec [AMS].[FMparticularsSupplies_data] '" & GenAccnt.selecteditem.value & "','0'", CommandType.Text)
        'gvparticular.DataSource = pParticulardata
        'gvparticular.DataBind()
        Dim a As Integer

        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            a = 0
        Else
            a = DrpSubclass.Selecteditem.Value
        End If
        txtparticular.text = ""
        btnsaveparticular.enabled = True
        btnsaveparticular.Text = "Save"
        ModalPopupExtender2.Show()
        pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selectedItem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & a & "'", CommandType.Text)
        gvparticular.datasource = pParticular
        gvparticular.databind()




    End Sub
    Protected Sub btnsaveSubCat_Click(sender As Object, e As EventArgs)

        If gvparticular1.text = "Update" Then

            Me.objDerived.Execute("Update tbl_SubCategory set Subcat_Desc ='" & SubCattxt.text & "',Useful_life ='" & TextBox6.text & "' where SubCategoryid = '" & gridview2.selecteddatakey("SubCategoryID") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Record has been successfully updated.")
        Else

            Me.objDerived.Execute("Insert into tbl_SubCategory(Subcat_Desc, Item_particular_id, ClassificationID, Useful_life)Values('" & SubCattxt.text & "','" & ddparticular.Selectedvalue & "','" & DrpClass.SelectedItem.Value & "','" & TextBox6.text & "') ", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        End If

        Dim category As String

        If ddparticular.selecteditem.value = "Select" Then
            category = "0"
        Else
            category = ddparticular.selecteditem.value
        End If




        SubCat = objDerived.GetDataTable("exec [AMS].[FMSuBcategory]'" & category & "'", CommandType.Text)
        Gridview2.DataSource = SubCat
        Gridview2.DataBind()

        Dim items As New DataTable
        items = objDerived.GetDataTable("select SubCategoryID,SubCat_Desc from dbo.tbl_SubCategory where Item_particular_id = " & ddParticular.selecteditem.value & "Order by Subcat_Desc", CommandType.Text)
        SubCattxt.text = ""
        ddSubCategory.DataSource = items
        ddSubCategory.DataTextField = "SubCat_Desc"
        ddSubCategory.DataValueField = "SubCategoryID"
        ddSubCategory.DataBind()
        'ddSubCategory.Items.Insert(0, "Select")
        ddSubCategory.Items.Insert(0, New ListItem("Select", "0"))
        gvparticular1.text = "Save"
        ModalPopupExtender4.show()
    End Sub
    Protected Sub ddSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Protected Sub Gridview2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        SubCat = objDerived.GetDataTable("exec [AMS].[FMSuBcategory]'" & ddparticular.selecteditem.value & "'", CommandType.Text)


        Gridview2.PageIndex = e.NewPageIndex
        Gridview2.DataSource = CType(SubCat, DataTable)
        Gridview2.DataBind()
        ModalPopupExtender4.Show()

    End Sub


    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs)
        ModalPopupExtender5.show()


        LinkButton5.Enabled = False
        Me.WithSubClass.Checked = False

        TxtClassification.enabled = True
        DdSubClassification.enabled = True



        GvClass.DataSource = objDerived.GetDataTable("Select * from tbl_classification where allotmentClass_ID = 2 order by ClassificationName asc", CommandType.Text)
        GvClass.DataBind()


        DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies where AllotmentClass_ID = 2 order by GA_Title ", CommandType.Text)
        DropGA.DataSource = DrpGenAcc
        DropGA.DataTextField = "GA_title"
        DropGA.DataValueField = "GA_ID"


        DropGA.items.clear()
        DropGA.DataBind()


    End Sub
    Protected Sub LinkButton6_Click(sender As Object, e As EventArgs)
        ddClassNewSub.enabled = True
        NewSubClassificationTxt.enabled = True
        ddClassNewSub.enabled = False
        Dim Cls As Integer = objDerived.GetValue("select classificationID from tbl_classification where classificationid= '" & DrpClass.selectedItem.value & "'", CommandType.Text)
        ClassificationGrd = objDerived.GetDataTable("Select * from dbo.tbl_Classification where AllotmentClass_id = 2 and Classificationid= '" & Cls & "'order by ClassificationName ", CommandType.Text)
        ddclassNewsub.DataSource = ClassificationGrd
        ddclassNewsub.DatatextField = "ClassificationName"
        ddclassNewsub.DataValueField = "ClassificationId"
        ddclassNewsub.DataBind()

        DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies where AllotmentClass_ID = 2 order by GA_Title ", CommandType.Text)
        ddGASubClass.DataSource = DrpGenAcc
        ddGASubClass.DataTextField = "GA_title"
        ddGASubClass.DataValueField = "GA_ID"
        ddGASubClass.items.clear()
        ddGASubClass.DataBind()

        SubClassificationGrd = objDerived.GetDataTable("Exec AMS.FMSubClassification '" & ddClassNewSub.SelectedItem.value & "'", CommandType.Text)
        GvSubClass.DataSource = SubClassificationGrd
        GvSubClass.DataBind()


        NewSubClassificationTxt.text = DrpSubClass.selecteditem.text

        NewSubClassificationtxt.enabled = True
        ModalPopupExtender6.show()

    End Sub
    Protected Sub LinkButton5_Click(sender As Object, e As EventArgs)
        ddClassNewSub.enabled = True
        NewSubClassificationTxt.enabled = True
        DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies  where AllotmentClass_Id = 2 order by GA_Title ", CommandType.Text)
        ddGASubClass.DataSource = DrpGenAcc
        ddGASubClass.DataTextField = "GA_title"
        ddGASubClass.DataValueField = "GA_ID"

        ddGASubClass.items.clear()
        ddGASubClass.DataBind()
        DdSubClassification.enabled = True
        ModalPopupExtender6.show()

    End Sub
    Protected Sub BtnClearClass_Click(sender As Object, e As EventArgs)
        txtClassification.text = " "

        DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies where AllotmentClass_ID = 2 order by GA_Title ", CommandType.Text)
        DropGA.DataSource = DrpGenAcc
        DropGA.DataTextField = "GA_title"
        DropGA.DataValueField = "GA_ID"


        WithSubClass.Checked = False
        GA.Visible = True
        DropGA.Visible = True
        WSUB.Visible = True
        WithSubClass.Visible = True
        ModalPopupExtender5.Show()
        btnSaveClass.text = "Save"
    End Sub
    Protected Sub WithSubClass_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WithSubClass.CheckedChanged
        'If Me.WithSubClass.Checked = True Then


        '    DrpSubClassF = objDerived.GetDataTable("Select SubClassificationName,SubCLassificationID from tbl_SubClassification Order by subclassificationName ", CommandType.Text)
        '    DdSubClassification.DataSource = DrpSubClassF
        '    DdSubClassification.DataTextField = "SubClassificationName"
        '    DdSubClassification.DataValueField = "SubClassificationID"
        '    DdSubClassification.items.clear()
        '    DdSubClassification.DataBind()

        '    DdSubClassification.Enabled = True
        '    LinkButton5.Enabled = True
        '    ModalPopupExtender5.show()
        'Else

        '    DdSubClassification.DataSource = Nothing
        '    DdSubClassification.DataBind()

        '    DdSubClassification.Enabled = False
        '    LinkButton5.Enabled = False
        '    DdSubClassification.items.clear()

        'End If
        If Me.WithSubClass.Checked = True Then
            DropGA.enabled = False
        Else
            DropGA.enabled = True
        End If
        ModalPopupExtender5.show()
    End Sub
    Protected Sub DrpClassSub_SelectedIndexChanged(sender As Object, e As EventArgs)

        If Session("action") = "Edit" Then
            If Drpclass.Selecteditem.value = 5 Then


                GenAccnt.selectedItem.Value = objDerived.getvalue("select Ga_id from tblclassmatrix where item_id = '" & gvstock.SelectedDatakey(4) & "'", commandtype.text)
                ddparticular.selectedItem.Value = gvstock.SelectedDatakey(5)
                ddSubCategory.selectedItem.Value = gvstock.SelectedDatakey(8)
                textboxgen.text = gvstock.SelectedDatakey(19)
                Dim brand As Object = gvstock.selectedDataKey(14)
                textboxBrand.text = If(DBNull.Value.Equals(brand), "", brand)
                Dim Color As Object = gvstock.selectedDataKey(15)
                textboxColor.text = If(DBNull.Value.Equals(Color), "", Color)
                Dim size As Object = gvstock.selectedDataKey(16)
                textboxSize.text = If(DBNull.Value.Equals(size), "", size)
                txtItemDesc.text = gvstock.SelectedDatakey("itemdesc")
                ddunit.selectedItem.Value = gvstock.SelectedDatakey(2)
                txtprice.text = gvstock.SelectedDatakey(12)
                txtItemCode.text = gvstock.SelectedDatakey("Item_Code")
            Else
                GenAccnt.selectedItem.Value = objDerived.getvalue("select Ga_id from tblclassmatrix where item_id = '" & gvstock.SelectedDatakey(4) & "'", commandtype.text)
                ddparticular.selectedItem.Value = gvstock.SelectedDatakey(5)
                ddSubCategory.selectedItem.Value = gvstock.SelectedDatakey(8)

                Dim brand As Object = gvstock.selectedDataKey(14)
                textboxBrand.text = If(DBNull.Value.Equals(brand), "", brand)
                Dim Color As Object = gvstock.selectedDataKey(15)
                textboxColor.text = If(DBNull.Value.Equals(Color), "", Color)
                Dim size As Object = gvstock.selectedDataKey(16)
                textboxSize.text = If(DBNull.Value.Equals(size), "", size)

                txtItemDesc.text = gvstock.SelectedDatakey("itemdesc")
                ddunit.selectedItem.Value = gvstock.SelectedDatakey(2)
                txtprice.text = gvstock.SelectedDatakey(12)
                txtItemCode.text = gvstock.SelectedDatakey("Item_Code")
            End If
        Else


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
            GenAccnt.items.clear()
            GenAccnt.DataBind()
            GenAccnt.Items.Insert(0, "Select")





            Dim c As Integer
            If ddSubCategory.text = "" Then
                c = 0
            Else
                c = ddSubCategory.Selecteditem.Value
            End If


        End If
    End Sub
    Protected Sub btnSaveClass_Click(sender As Object, e As EventArgs)
        If btnSaveClass.text = "SAVE" Then
            Dim DtGrid = objDerived.GetValue("Select classificationID from dbo.tbl_classification where ClassificationName ='" & TxtClassification.text & "'", CommandType.Text)
            Dim a As Integer
            If DdSubClassification.Text = "" Or DdSubClassification.Text = "Select" Then
                a = 0
            Else
                a = DdSubClassification.SelectedItem.value
            End If

            If Me.WithSubClass.checked = True Then


                If DtGrid Is Nothing Then

                    Dim Cls = objDerived.getvalue("select count(*) from tbl_Classification where ClassificationName ='" & TxtClassification.text & "'", CommandType.Text)
                    If Cls <> 0 Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Classification is already Exist.")
                    Else
                        Me.objDerived.Execute("Insert into dbo.tbl_Classification(ClassificationName,AllotmentClass_id)Values('" & TxtClassification.text & "','3')", CommandType.Text)

                        Dim Matrx = objDerived.GetValue("Select TOP 1 classificationID from dbo.tbl_classification order by ClassificationID desc ", CommandType.Text)

                        Me.objDerived.Execute("Insert into dbo.tblclassmatrix(ClassificationID,SubClassificationID)Values('" & Matrx & "','" & a & "')", CommandType.Text)
                        GvClass.DataSource = objDerived.GetDataTable("Select * from tbl_classification where allotmentClass_ID = 2 order by ClassificationName asc", CommandType.Text)
                        GvClass.DataBind()
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")
                        TxtClassification.enabled = False
                        DdSubClassification.enabled = False
                    End If
                Else
                    Dim Gen = objDerived.Getvalue("select count(*) from tblClassmatrix where GA_ID ='" & DropGA.SelectedItem.Value & "' And ClassificationID='" & Session("ClassificationID") & "'And SubClassificationID ='" & a & "'", CommandType.Text)
                    If Gen <> 0 Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected General Account is already Saved.")

                    Else
                        Dim Matrx = objDerived.GetValue("Select TOP 1 classificationID from dbo.tbl_classification order by ClassificationID desc ", CommandType.Text)
                        Me.objDerived.Execute("Insert into dbo.tblclassmatrix(ClassificationID,SubClassificationID)Values('" & Matrx & "','" & a & "')", CommandType.Text)
                        GvClass.DataSource = objDerived.GetDataTable("Select * from tbl_classification where allotmentClass_ID = 3 order by ClassificationName asc", CommandType.Text)
                        GvClass.DataBind()
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")
                        TxtClassification.enabled = False
                        DdSubClassification.enabled = False
                    End If


                End If
            Else
                If DtGrid Is Nothing Then

                    Dim Cls = objDerived.getvalue("select count(*) from tbl_Classification where ClassificationName ='" & TxtClassification.text & "'", CommandType.Text)
                    If Cls <> 0 Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Classification is already Exist.")
                    Else
                        Me.objDerived.Execute("Insert into dbo.tbl_Classification(ClassificationName,AllotmentClass_id)Values('" & TxtClassification.text & "','3')", CommandType.Text)

                        Dim Matrx = objDerived.GetValue("Select TOP 1 classificationID from dbo.tbl_classification order by ClassificationID desc ", CommandType.Text)

                        Me.objDerived.Execute("Insert into dbo.tblclassmatrix(ClassificationID,GA_ID ,SubClassificationID)Values('" & Matrx & "','" & DropGA.SelectedItem.Value & "','" & a & "')", CommandType.Text)
                        GvClass.DataSource = objDerived.GetDataTable("Select * from tbl_classification where allotmentClass_ID = 3 order by ClassificationName asc", CommandType.Text)
                        GvClass.DataBind()
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")
                        TxtClassification.enabled = False
                        DdSubClassification.enabled = False
                    End If
                Else
                    Dim Gen = objDerived.Getvalue("select count(*) from tblClassmatrix where GA_ID ='" & DropGA.SelectedItem.Value & "' And ClassificationID='" & Session("ClassificationID") & "'And SubClassificationID ='" & a & "'", CommandType.Text)
                    If Gen <> 0 Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Selected General Account is already Saved.")

                    Else
                        Dim Matrx = objDerived.GetValue("Select TOP 1 classificationID from dbo.tbl_classification order by ClassificationID desc ", CommandType.Text)
                        Me.objDerived.Execute("Insert into dbo.tblclassmatrix(ClassificationID,GA_ID,SubClassificationID)Values('" & Matrx & "','" & DropGA.SelectedItem.Value & "','" & a & "')", CommandType.Text)
                        GvClass.DataSource = objDerived.GetDataTable("Select * from tbl_classification where allotmentClass_ID = 3 order by ClassificationName asc", CommandType.Text)
                        GvClass.DataBind()
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")
                        TxtClassification.enabled = False
                        DdSubClassification.enabled = False
                    End If


                End If
            End If

        Else
            objDerived.GetRecords("UPDATE tbl_classification SET ClassificationName = '" & TxtClassification.text & "' WHERE ClassificationID = '" & GvClass.SelectedDatakey(0) & "'", CommandType.Text)
            Dim F As Integer = objDerived.GetValue("Select ClassificationID from tbl_classification where classificationName ='" & TxtClassification.text & "'", CommandType.Text)

            GvClassF = objDerived.GetDataTable("Select ClassificationName,ClassificationID from tbl_classification where classificationID='" & F & "'", CommandType.Text)
            GvClass.DataSource = GvClassF
            GvClass.DataBind()

        End If


        TxtClassification.text = ""
        Me.WithSubClass.Checked = False
        DdSubClassification.items.clear()

        Modalpopupextender5.show()

    End Sub
    Protected Sub DropGA_SelectedIndexChanged(sender As Object, e As EventArgs)
        Modalpopupextender5.show()
    End Sub
    Protected Sub GvClass_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvClass.PageIndexChanging
        'SubCat = objDerived.GetDataTable("exec [AMS].[FMSuBcategory]'" & ddparticular.selecteditem.value & "'", CommandType.Text)
            Dim a As Integer
        If DdSubClassification.Text = "" Or DdSubClassification.Text = "Select" Then
            a = 0
        Else
            a = DdSubClassification.SelectedItem.value
        End If




        ClassificationGrd = objDerived.GetDataTable("Select * from tbl_classification where AllotmentClass_id = 2 order by ClassificationName asc", CommandType.Text)
        GvClass.PageIndex = e.NewPageIndex
        GvClass.DataSource = CType(ClassificationGrd, DataTable)
        GvClass.DataBind()
        ModalPopupExtender5.Show()
    End Sub
    Protected Sub GvSubClass_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvSubClass.PageIndexChanging
        Session("SubClassificationID") = objDerived.GetValue("Select TOP 1 SubclassificationID from dbo.tbl_Subclassification order by SubClassificationID desc ", CommandType.Text)
        GvSubClassF = objDerived.getDataTable("exec [AMS].[sp_FM_GvClass] null, '" & ddGASubClass.SelectedItem.Value & "','" & ddClassNewSub.selectedItem.Value & "','" & Session("SubClassificationID") & "'", CommandType.Text)
        GvSubClass.PageIndex = e.NewPageIndex
        GvSubClass.DataSource = CType(GvSubClassF, DataTable)
        GvSubClass.DataBind()
        ModalPopupExtender6.Show()
    End Sub
    Protected Sub BtnSave_SUBCLASS_Click(sender As Object, e As EventArgs)
        If BtnSave_SUBCLASS.text = "SAVE" Then


            Dim DtGrid = objDerived.GetValue("Select SubclassificationID from dbo.tbl_Subclassification where SubClassificationName ='" & NewSubClassificationTxt.text & "'", CommandType.Text)

            Dim SubCls = objDerived.GetValue("select count(*) from tbl_SubClassification where SubClassificationName ='" & NewSubClassificationTxt.text & "' and GA_ID = '" & ddGASubClass.SelectedItem.Value & "'", CommandType.Text)
            If DtGrid = 0 Then

                If SubCls <> 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Sub Classification is already Exist.")
                Else
                    If NewSubClassificationTxt.text = "" Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Sub Classification is Required.")
                    Else
                        Me.objDerived.Execute("Insert into dbo.tbl_SubClassification (SubClassificationName,ClassificationID,GA_ID)Values('" & NewSubClassificationTxt.text & "','" & ddClassNewSub.SelectedItem.Value & "','" & ddGASubClass.SelectedItem.Value & "')", CommandType.Text)


                        Dim MatrxSub = objDerived.GetValue("Select TOP 1 SubclassificationID from dbo.tbl_Subclassification order by SubClassificationID desc ", CommandType.Text)

                        Me.objDerived.Execute("Insert into dbo.tblclassmatrix(ClassificationID,GA_ID,SubClassificationID,BGA_ID)Values('" & ddClassNewSub.SelectedItem.Value & "','" & ddGASubClass.SelectedItem.Value & "','" & MatrxSub & "','" & 0 & "')", CommandType.Text)


                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")
                        Load_GVSubClass()


                        ddClassNewSub.enabled = False
                        NewSubClassificationTxt.enabled = False

                    End If
                End If

            Else
                Dim SubMat = objDerived.GetValue("Select TOP 1 SubclassificationID from dbo.tbl_Subclassification order by SubClassificationID desc ", CommandType.Text)
                Dim Gen = objDerived.GetValue("select count(*) from tblClassmatrix where GA_ID ='" & ddGASubClass.SelectedItem.Value & "' And ClassificationID='" & ddClassNewSub.SelectedItem.Value & "'", CommandType.Text)
                If Gen <> 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Selected General Account is already Saved.")

                Else
                    If NewSubClassificationTxt.text = "" Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Sub Classification is Required.")
                    Else
                        Me.objDerived.Execute("Insert into dbo.tbl_SubClassification (SubClassificationName,ClassificationID,GA_ID)Values('" & NewSubClassificationTxt.text & "','" & ddClassNewSub.SelectedItem.Value & "','" & ddGASubClass.SelectedItem.Value & "')", CommandType.Text)


                        Dim MatrxSub = objDerived.GetValue("Select TOP 1 SubclassificationID from dbo.tbl_Subclassification order by SubClassificationID desc ", CommandType.Text)

                        Me.objDerived.Execute("Insert into dbo.tblclassmatrix(ClassificationID,GA_ID,SubClassificationID,BGA_ID)Values('" & ddClassNewSub.SelectedItem.Value & "','" & ddGASubClass.SelectedItem.Value & "','" & MatrxSub & "','" & 0 & "')", CommandType.Text)

                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")
                        Load_GVSubClass()
                        ddClassNewSub.enabled = False
                        NewSubClassificationTxt.enabled = False
                    End If
                End If
            End If

        Else

            If NewSubClassificationTxt.text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Sub Classification is required.")
            Else
                'If updating

                Dim F As Integer = objDerived.GetValue("Select SubClassificationID from tbl_Subclassification where SubclassificationName ='" & NewSubClassificationTxt.text & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE tbl_Subclassification SET SubClassificationName = '" & NewSubClassificationTxt.text & "' WHERE SubClassificationID = '" & GvSubClass.SelectedDataKey(0) & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE tbl_Subclassification SET GA_ID = '" & ddGASubClass.SelectedItem.Value & "' WHERE GA_ID = '" & GvSubClass.SelectedDatakey(4) & "'", CommandType.Text)



                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")
                Load_GVSubClass()
                'GvClassF = objDerived.GetDataTable("Exec AMS.FMSubClassification '" & ddClassNewSub.SelectedItem.value & "'", CommandType.Text)
                'GvClass.DataSource = GvClassF
                'GvClass.DataBind()

            End If
        End If

        ModalPopupExtender6.show()
        Load_GVSubClass()
    End Sub


    Protected Sub Load_GVClass()

        Dim a As Integer
        If DdSubClassification.Text = "" Or DdSubClassification.Text = "Select" Then
            a = 0
        Else
            a = DdSubClassification.SelectedItem.value
        End If


        Session("ClassificationID") = objDerived.GetValue("Select TOP 1 classificationID from dbo.tbl_classification order by ClassificationID desc ", CommandType.Text)
        GvClassF = objDerived.getDataTable("exec [AMS].[sp_FM_GvClass] null, '" & DropGA.SelectedItem.Value & "','" & Session("ClassificationID") & "','" & a & "'", CommandType.Text)
        GvClass.DataSource = GvClassF
        GvClass.DataBind()


    End Sub

    Protected Sub Load_GVSubClass()

        Session("SubClassificationID") = objDerived.GetValue("Select TOP 1 SubclassificationID from dbo.tbl_Subclassification order by SubClassificationID desc ", CommandType.Text)
        GvSubClassF = objDerived.getDataTable("exec [AMS].[sp_FM_GvClass] '" & ddGASubClass.SelectedItem.Value & "','" & ddClassNewSub.selectedItem.Value & "','" & Session("SubClassificationID") & "'", CommandType.Text)
        GvSubClass.DataSource = GvSubClassF
        GvSubClass.DataBind()


    End Sub


    'Public Function Createdatatable_Accounts(ByVal row As Integer) As DataTable
    '    Dim dt As New DataTable()
    '    Dim dr As DataRow
    '    Dim myDataColumn As DataColumn
    '    myDataColumn = New DataColumn()
    '    dt.Columns.Add("GA_Code2", GetType(String))
    '    dt.Columns.Add("GA_Title", GetType(String))
    '    dt.Columns.Add("Quarter", GetType(Integer))
    '    dt.Columns.Add("CYear", GetType(Integer))
    '    dt.Columns.Add("TotalAmt", GetType(Decimal))
    '    dt.Columns.Add("GA_ID", GetType(Integer))
    '    dt.Columns.Add("BGA_ID", GetType(Integer))
    '    dt.Columns.Add("isVisible", GetType(Boolean))
    '    dt.Columns.Add("prhdr_id", GetType(Long))
    '    dt.Columns.Add("ItemClass_Desc", GetType(String))
    '    dt.Columns.Add("remarks", GetType(String))
    '    dt.Columns.Add("ItemClass_ID", GetType(Integer))

    '    For i As Integer = 0 To row
    '        dr = dt.NewRow
    '        dr("GA_Code2") = DBNull.Value
    '        dr("GA_Title") = DBNull.Value
    '        dr("Quarter") = DBNull.Value
    '        dr("CYear") = DBNull.Value
    '        dr("TotalAmt") = DBNull.Value
    '        dr("GA_ID") = DBNull.Value
    '        dr("BGA_ID") = DBNull.Value
    '        dr("isVisible") = False
    '        dr("prhdr_id") = DBNull.Value
    '        dr("ItemClass_Desc") = DBNull.Value
    '        dr("remarks") = DBNull.Value
    '        dr("ItemClass_ID") = DBNull.Value
    '        dt.Rows.Add(dr)

    '    Next
    '    Return dt

    'End Function

    Protected Sub SrchSubClass_Click(sender As Object, e As EventArgs)
        Dim myview As DataView

        Dim a As Integer
        If DdSubClassification.Text = "" Or DdSubClassification.Text = "Select" Then
            a = 0
        Else
            a = DdSubClassification.SelectedItem.value
        End If

        pstock = objDerived.GetDataTable("exec [AMS].[sp_FM_Srch_GvClass]", CommandType.Text)
        GvSubClass.DataSource = pstock
        GvSubClass.DataBind()


        myview = pstock.DefaultView


        'myview.RowFilter = "SubClassificationName like '%" & replaceapostrophe(TextBox14.Text.ToString) & "%'"


        GvSubClass.DataSource = myview
        GvSubClass.DataBind()
        GvSubClass.PageIndex = 0

        'CType(GvClass.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
        'CType(GvClass.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")

        Session("View") = "Search"


        ModalPopupExtender6.Show()
    End Sub

    Protected Sub SrchCat_Click(sender As Object, e As EventArgs)
        Dim myview As DataView


        Dim a As Integer
        If DdSubClassification.Text = "" Or DdSubClassification.Text = "Select" Then
            a = 0
        Else
            a = DdSubClassification.SelectedItem.value
        End If

        pstock = objDerived.GetDataTable("Select * from ams.item_particular ", CommandType.Text)
        Gvparticular.DataSource = pstock
        Gvparticular.DataBind()


        myview = pstock.DefaultView


        myview.RowFilter = "description like '%" & replaceapostrophe(txtparticular2.Text.ToString) & "%'"


        Gvparticular.DataSource = myview
        Gvparticular.DataBind()
        Gvparticular.PageIndex = 0

        'CType(GvClass.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
        'CType(GvClass.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")

        Session("View") = "Search"


        ModalPopupExtender2.Show()
    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs)
        Dim myview As DataView


        Dim a As Integer
        If DdSubClassification.Text = "" Or DdSubClassification.Text = "Select" Then
            a = 0
        Else
            a = DdSubClassification.SelectedItem.value
        End If
        pstock = objDerived.GetDataTable("exec [AMS].[sp_FM_Srch_SubCat]", CommandType.Text)
        'pstock = objDerived.GetDataTable("Select * from tbl_subcategory ", CommandType.Text)
        Gridview2.DataSource = pstock
        Gridview2.DataBind()


        myview = pstock.DefaultView


        myview.RowFilter = "Subcat_Desc like '%" & replaceapostrophe(TextBox8.Text.ToString) & "%'"


        Gridview2.DataSource = myview
        Gridview2.DataBind()
        Gridview2.PageIndex = 0

        'CType(GvClass.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
        'CType(GvClass.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")

        Session("View") = "Search"


        ModalPopupExtender4.Show()
    End Sub

    Protected Sub GvClass_SelectedIndexChanged(sender As Object, e As EventArgs)

        TxtClassification.Text = gvclass.SelectedDataKey("ClassificationName")
        GA.Visible = False
        DropGA.Visible = False
        WSUB.Visible = False
        WithSubClass.Visible = False
        ModalPopupExtender5.Show()
        btnSaveClass.text = "Update"
    End Sub
    Protected Sub GvSubClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        ddClassNewSub.SelectedItem.Text = gvSubclass.SelectedDataKey("ClassificationName")
        NewSubClassificationTxt.text = gvSubclass.SelectedDataKey("SubClassificationName")
        ddGASubClass.SelectedItem.Text = gvSubclass.SelectedDataKey("GA_Title2")
        ModalPopupExtender6.Show()
        BtnSave_SUBCLASS.text = "Update"
    End Sub

    Protected Sub ddClassNewSub_SelectedIndexChanged(sender As Object, e As EventArgs)


        'If drpSubClass.text = "" Then

        '    DrpGenAcc = objDerived.GetDataTable("Exec [AMS].[FMgetGenAccntNoSubclass]'" & DrpClass.SelectedItem.Value & "','" & 0 & "'", CommandType.Text)
        '    ddGASubClass.DataSource = DrpGenAcc
        '    ddGASubClass.DataTextField = "GA_title"
        '    ddGASubClass.DataValueField = "GA_ID"
        '    ddGASubClass.items.clear()
        '    ddGASubClass.DataBind()


        'Else

        '    DrpGenAcc = objDerived.GetDataTable("Exec [AMS].[FMgetGenAccnt]'" & DrpClass.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "','" & 0 & "'", CommandType.Text)
        '    ddGASubClass.DataSource = DrpGenAcc
        '    ddGASubClass.DataTextField = "GA_title"
        '    ddGASubClass.DataValueField = "GA_ID"
        '    ddGASubClass.items.clear()
        '    ddGASubClass.DataBind()

        'End If


        SubClassificationGrd = objDerived.GetDataTable("Exec AMS.FMSubClassification '" & ddClassNewSub.SelectedItem.value & "'", CommandType.Text)
        GvSubClass.DataSource = SubClassificationGrd
        GvSubClass.DataBind()

        Modalpopupextender6.show()

    End Sub

    Protected Sub BtnClearSubClass_Click(sender As Object, e As EventArgs)
        NewSubClassificationTxt.text = ""
        Modalpopupextender6.show()
        BtnSave_SUBCLASS.text = "Save"
    End Sub


    Protected Sub ddGASubClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        ModalPopupExtender6.show()
    End Sub
    Protected Sub btnROP_Click(sender As Object, e As EventArgs) Handles btnROP.Click
        ModalPopupExtender7.Show()
    End Sub
    Protected Sub BtnCompute_Click1(sender As Object, e As EventArgs) Handles BtnCompute.Click
        If DRP.Text <> "" And LTD.Text <> "" Then
            RP.Text = DRP.Text * LTD.Text
            ModalPopupExtender7.Show()
            txtReorderPoint.Text = DRP.Text * LTD.Text

        Else

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please fill Demand Per Day & Lead Time For Deliver.")

        End If
    End Sub

End Class
