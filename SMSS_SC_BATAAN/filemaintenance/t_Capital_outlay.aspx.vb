Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.IO
Imports System.Object
Partial Class t_Capital_outlay
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim particular As New item_particular
    Dim item As New m_item
    Dim item2 As New m_itemSub
    Dim item3 As New m_itemWSubClassNoSubcat
    Dim item4 As New m_itemNoSubClassNoSubcat
    Dim itemImage As New m_itemImage
    Dim AuditTrail As New Audit_Trail
    Dim item_detail As New m_item_detail
    Dim msg As New MsgeBox
    Dim msg2 As New MsgeBox
    Dim obj As New AccessRule
    Dim edit As New t_Edit_Transaction
#Region "property"
    Private Property pstock() As DataTable
        Get
            Return CType(Session("pstock"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pstock") = value
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
    Private Property DrpSubClassF() As DataTable
        Get
            Return CType(Session("DrpSubClassF"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("DrpSubClassF") = value
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
    Private Property GvClassF() As DataTable
        Get
            Return CType(Session("GvClassF"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("GvClassF") = value
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
    Private Property pProperty() As DataTable
        Get
            Return CType(Session("pProperty"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pProperty") = value
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
#End Region
    Private Property DrpGenAcc() As DataTable
        Get
            Return CType(Session("DrpGenAcc"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("DrpGenAcc") = value
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
    Private Property pParticular() As DataTable
        Get
            Return CType(Session("pParticular"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pParticular") = value
        End Set
    End Property
    Private Property pParticularData() As DataTable
        Get
            Return CType(Session("pParticularData"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pParticularData") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim year As String

        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            Dim stocks As Boolean
            stocks = True

            pCode = objDerived.GetDataTable("SELECT * FROM AMS.vw_PPE4 ORDER BY GA_Title", CommandType.Text)
            gvcode.DataSource = pCode
            gvcode.DataBind()

            GenName.Visible = False
            ddParticular.Enabled = False
            ddSubcategory.Enabled = False
            ddUnit.Enabled = False
            txtdescription.Enabled = False
            button2.Enabled = True
            txtprice.Enabled = False
            btnadd.Enabled = False
            btnedit.Enabled = False
            btnsave.Enabled = False
            btnaddp.Enabled = True

            btnaddparticular.Enabled = True
            btnsaveparticular.Enabled = False
            'txtparticular.ReadOnly = True

            ddUnit.DataSource = Nothing
            ddUnit.DataBind()

            txtdescription.Attributes.Add("OnFocus", "this.select()")
            txtprice.Attributes.Add("OnFocus", "this.select()")

            Session("Option") = "Select"

            gvstock.DataSource = Nothing
            gvstock.DataBind()
            'txtprice.Attributes.Add("onchange", "this.value = formatCurrency(this.value); ")

            Try
                PYear = objDerived.GetDataTable("select year from ams.APP where isContinuing <> 1", CommandType.Text)
                Me.ddyear.DataSource = PYear
                Me.ddyear.DataTextField = "year"
                Me.ddyear.DataValueField = "year"
                Me.ddyear.DataBind()
            Catch ex As Exception
            End Try

        Else
            Try
                year = "CY" & Me.ddyear.SelectedValue.ToString
                Me.HiddenField1.Value = year
                Me.HiddenField2.Value = Me.ddyear.SelectedValue.ToString - 1
                Me.HiddenField3.Value = "CY" & HiddenField2.Value
                Dim Isexist As New Boolean
                Isexist = IIf(IsDBNull(objDerived.GetValue("select [AMS].[CheckColumnname] (" & Me.ddyear.SelectedValue.ToString & ")", CommandType.Text)), 0, (objDerived.GetValue("select [AMS].[CheckColumnname] (" & Me.ddyear.SelectedValue.ToString & ")", CommandType.Text)))
                If Isexist = False Then
                    objDerived.GetRecords("ALTER TABLE dbo.m_item_detail ADD " & year & " decimal(18,2)", CommandType.Text)
                    Isexist = IIf(IsDBNull(objDerived.GetValue("select [AMS].[CheckColumnname] (" & Me.ddyear.SelectedValue.ToString - 1 & ")", CommandType.Text)), 0, (objDerived.GetValue("select [AMS].[CheckColumnname] (" & Me.ddyear.SelectedValue.ToString - 1 & ")", CommandType.Text)))
                    If Isexist = False Then
                        objDerived.GetRecords("ALTER TABLE dbo.m_item_detail ADD " & Me.HiddenField3.Value & " decimal(18,2)", CommandType.Text)
                    End If
                End If

            Catch ex As Exception
            End Try
        End If

        txtAccnTitle.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchAccnt.ClientID & "')")
        txtsearch2.Attributes.Add("onkeypress", "return fun1(event,'" & btnsearch.ClientID & "')")
        txtparticular2.Attributes.Add("onkeypress", "return fun1(event,'" & Button7.ClientID & "')")

    End Sub



    Protected Sub gvcode_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvcode.PageIndexChanging
        gvcode.PageIndex = e.NewPageIndex
        gvcode.DataSource = CType(pCode, DataTable)
        gvcode.DataBind()

        ModalPopupExtender1.Show()

    End Sub

    Protected Sub gvcode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvcode.SelectedIndexChanged
        Session("pGA_ID") = gvcode.SelectedDataKey("GA_ID")
        Session("pBGA_ID") = gvcode.SelectedDataKey("BGA_ID")

        ModalPopupExtender1.Show()
    End Sub

    Protected Sub gvstock_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvstock.PageIndexChanging

        Session("View") = "Particular"
        Dim b As Integer

        If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
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

        If DrpSubClass.Text = "" Or DrpSubClass.Text = "Select" Then
            d = 0
        Else
            d = drpSubclass.Selecteditem.Value
        End If


        If Session("View") = "Particular" Then
            pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & grdAccounts.SelectedDataKey("GA_ID") & "','" & grdAccounts.SelectedDataKey("BGA_ID") & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
            gvstock.PageIndex = e.NewPageIndex
            gvstock.DataSource = pstock
            gvstock.DataBind()


        ElseIf Session("View") = "Search" Then
            pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            Dim myview As DataView
            myview = pstock.DefaultView
            If ddSearch.SelectedItem.Value = 2 Then
                myview.RowFilter = "Item_Code like '%" & replaceapostrophe(txtsearch2.Text.ToString) & "%'"
            Else
                myview.RowFilter = "Itemdesc like '%" & replaceapostrophe(txtsearch2.Text.ToString) & "%'"
            End If
            gvstock.DataSource = myview
            gvstock.PageIndex = e.NewPageIndex
            gvstock.DataBind()

        End If

        CType(gvstock.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
        CType(gvstock.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")
        btnadd.Enabled = True


    End Sub

    Protected Sub gvstock_SelectedIndexChanged(sender As Object, e As EventArgs)
        hdnItemSubClass.Value = gvstock.SelectedDataKey("Item_ID")
        Session("ITMID") = hdnItemSubClass.Value
        If Session("Option") = "Delete" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT DISTINCT Item_ID FROM AMS.ppmp_dtl WHERE Item_ID = '" & gvstock.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            If dt.Rows.Count = 0 Then

                objDerived.GetRecords("DELETE FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                objDerived.GetRecords("DELETE FROM dbo.m_item_detail WHERE Item_ID = '" & gvstock.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected item has been successfully deleted.")
                'pstock = objDerived.GetDataTable("exec ams.FM_Stocks  '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpClass.selectedItem.Value & "','" & drpSubClass.selectedItem.Value & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
                '' pstock = objDerived.GetDataTable("exec ams.FM_Stocks '" & gvcode.SelectedDataKey(2) & "','" & gvcode.SelectedDataKey(4) & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
                'gvstock.DataSource = pstock
                'gvstock.DataBind()
            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected item cannot be deleted. Item has already been used in an existing PPPMP.")
            End If
            Dim b As Integer

            If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
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



            pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            '12162022
            gvstock.DataSource = pstock
            gvstock.DataBind
            Session("Option") = "Select"
        Else
            If DrpClass.SelectedItem.Value = 7 Or DrpClass.text = "Medicine" Then


                ddParticular.Enabled = False
                ddUnit.Enabled = False
                txtRpt.Enabled = False
                txtItemCode.Text = False
                txtdescription.Enabled = False
                txtprice.Enabled = False
                btnadd.Enabled = True
                btnedit.Enabled = True
                btnsave.Enabled = False
                btncopyall.Enabled = True

                textboxdeptrate.text = objDerived.GetValue("Select DepRate from dbo.m_item where item_ID = '" & gvstock.SelectedDataKey("item_particular_id") & "'", CommandType.Text)
                textboxdeptYear.text = objDerived.GetValue("Select DepYear from dbo.m_item where item_ID = '" & gvstock.SelectedDataKey("item_particular_id") & "'", CommandType.Text)
                dv = objDerived.getdatatable("select *  from ams.item_particular where item_particular_id = '" & gvstock.SelectedDataKey(5) & "'", commandtype.text)
                ddParticular.DataSource = dv
                ddParticular.DataTextField = "description"
                ddParticular.DataValueField = "item_particular_id"
                ddParticular.DataBind()

                div = objDerived.getdatatable("select *  from tbl_subcategory where Subcategoryid = '" & gvstock.SelectedDataKey(8) & "'", commandtype.text)
                ddSubCategory.DataSource = div
                ddSubCategory.DataTextField = "Subcat_desc"
                ddSubCategory.DataValueField = "Subcategoryid"
                ddSubCategory.DataBind()
                ddSubCategory.items.insert(0, "select")


                ddSubCategory.selecteditem.Text = gvstock.SelectedDatakey(11)

                ddUnit.SelectedItem.Text = gvstock.SelectedDataKey(2)
                ddUnit.SelectedItem.Value = gvstock.SelectedDataKey(6)
                Dim brand As Object = gvstock.selectedDataKey(14)
                textboxBrand.text = If(DBNull.Value.Equals(brand), "", brand)
                Dim Color As Object = gvstock.selectedDataKey(15)
                textboxColor.text = If(DBNull.Value.Equals(Color), "", Color)
                Dim size As Object = gvstock.selectedDataKey(16)
                textboxSize.text = If(DBNull.Value.Equals(size), "", size)
                textboxGen.text = gvstock.SelectedDataKey(20)
                txtdescription.Text = gvstock.SelectedDataKey("ItemDesc")

                txtItemCode.Text = gvstock.SelectedDataKey("Item_Code")
                txtprice.Text = FormatNumber(gvstock.SelectedDataKey(7), 2)
                Dim ItemPic As String = objDerived.GetValue("select AttachedFile from dbo.m_item where item_id = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
                If ItemPic = "" Then
                    Image1.ImageUrl = "~/images/NoPicture.jpg"
                Else
                    Image1.ImageUrl = "~/images/" & ItemPic
                End If


            Else
                ddParticular.Enabled = False
                ddUnit.Enabled = False
                txtRpt.Enabled = False
                txtItemCode.Text = False
                txtdescription.Enabled = False
                txtprice.Enabled = False
                btnadd.Enabled = True
                btnedit.Enabled = True
                btnsave.Enabled = False
                btncopyall.Enabled = True

                textboxdeptrate.text = objDerived.GetValue("Select DepRate from dbo.m_item where item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
                textboxdeptYear.text = objDerived.GetValue("Select DepYear from dbo.m_item where item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)

                dv = objDerived.getdatatable("select *  from ams.item_particular where item_particular_id = '" & gvstock.SelectedDataKey(5) & "'", commandtype.text)
                ddParticular.DataSource = dv
                ddParticular.DataTextField = "description"
                ddParticular.DataValueField = "item_particular_id"
                ddParticular.DataBind()

                Dim SubCat As Object = gvstock.SelectedDatakey(8)
                ddSubCategory.SelectedValue = If(DBNull.Value.Equals(ddSubCategory.SelectedValue), "", ddSubCategory.SelectedValue)

                'ddSubCategory.SelectedItem.Value = gvstock.SelectedDatakey(12)

                ddUnit.SelectedItem.Text = gvstock.SelectedDataKey(2)
                ddUnit.SelectedItem.Value = gvstock.SelectedDataKey(2)
                Dim brand As Object = gvstock.selectedDataKey(14)
                textboxBrand.text = If(DBNull.Value.Equals(brand), "", brand)
                Dim Color As Object = gvstock.selectedDataKey(15)
                textboxColor.text = If(DBNull.Value.Equals(Color), "", Color)
                Dim size As Object = gvstock.selectedDataKey(16)
                textboxSize.text = If(DBNull.Value.Equals(size), "", size)
                txtdescription.Text = gvstock.SelectedDataKey(7)

                txtItemCode.Text = gvstock.SelectedDataKey(13)
                txtprice.Text = FormatNumber(gvstock.SelectedDataKey(12), 2)
                Dim ItemPic As String = objDerived.GetValue("select AttachedFile from dbo.m_item where item_id = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
                If ItemPic = "" Then
                    Image1.ImageUrl = "~/images/blankImage.jpg"
                Else
                    Image1.ImageUrl = "~/images/" & ItemPic
                End If
            End If

            txtRpt.Text = objDerived.GetValue("SELECT reorderPT FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)

            Session("oldValueItem") = gvstock.SelectedDataKey(7)
            Session("oldValueUnit") = gvstock.SelectedDataKey(2)

            Dim PrevYear, currentYear
            PrevYear = "CY" & Me.ddyear.SelectedValue.ToString - 1
            currentYear = "CY" & Me.ddyear.SelectedValue.ToString
            Session("oldValuePrice") = gvstock.SelectedDataKey("price2")
        End If

    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click

        Me.ddyear.Enabled = False

        Try
            pstock = objDerived.GetDataTable("exec ams.FM_Stocks '" & gvcode.SelectedDataKey(2) & "','" & gvcode.SelectedDataKey(4) & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
            gvstock.DataSource = pstock
            gvstock.DataBind()

            Session("SearchGrid") = 0

            txtcode.Text = gvcode.SelectedDataKey(3)
            txttitle.Text = gvcode.SelectedDataKey(1)

            pParticular = Nothing
            ddParticular.Items.Clear()
            ddParticular.Items.Add("Select")
            ddParticular.Items(0).Text = "Select"
            ddParticular.Items(0).Value = "0"
            ddParticular.DataBind()

            ddParticular.Enabled = False
            ddUnit.Enabled = False
            txtdescription.Enabled = False
            txtprice.Enabled = False
            btnadd.Enabled = False
            btnedit.Enabled = False
            btnsave.Enabled = False
            txtprice.Text = "0.00"
            txtdescription.Text = ""

            btnadd.Enabled = True

            btnaddparticular.Enabled = True
            btnsaveparticular.Enabled = True
            txtparticular.ReadOnly = True

            pParticular = objDerived.GetDataTable("exec ams.FMparticularCapitaloutlay'" & gvcode.SelectedDataKey(2) & "','" & gvcode.SelectedDataKey(4) & "'", CommandType.Text)
            ddParticular.DataSource = pParticular
            ddParticular.DataTextField = "description"
            ddParticular.DataValueField = "item_particular_id"
            ddParticular.DataBind()

            gvparticular.DataSource = pParticular
            gvparticular.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            Dim a As Integer

            If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
                a = 0
            Else
                a = DrpSubclass.Selecteditem.Value
            End If
            ddSubCategory.Items.Clear()
            txtItemCode.Enabled = True
            txtprice.Enabled = True
            txtdescription.Enabled = True
            txtRpt.Enabled = True
            ddUnit.Enabled = True
            btnadd.Enabled = True
            btnedit.Enabled = False
            textboxgen.text = ""
            textboxbrand.text = ""
            TextboxColor.text = ""
            textboxSize.text = ""
            TextBoxDeptRate.text = ""
            TextBoxDeptYear.text = ""
            Fileupload1.Enabled = True


            ddParticular.Enabled = True

            btnSave.Enabled = True



            pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selectedItem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & a & "'", CommandType.Text)
            ddparticular.datasource = pParticular
            ddparticular.datatextfield = "description"
            ddparticular.datavaluefield = "item_particular_id"
            ddparticular.databind()
            ddparticular.items.insert(0, "select")


            ddUnit.Enabled = False
            ddUnit.SelectedItem.Text = "Select"
            ddUnit.SelectedIndex = 0

            txtdescription.Enabled = True
            txtItemCode.Enabled = True
            txtprice.Enabled = True
            txtRpt.Enabled = True
            btnadd.Enabled = True
            btnedit.Enabled = False
            btnsave.Enabled = True
            txtprice.Text = "0.00"
            txtdescription.Text = ""
            txtRpt.Text = ""
            txtItemCode.Text = ""

            Session("Action") = "Add"
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnedit.Click

        ddParticular.Enabled = False
        txtItemCode.Enabled = True
        ddUnit.Enabled = True
        txtdescription.Enabled = True
        txtRpt.Enabled = True
        txtprice.Enabled = True
        txtprice.Focus()
        ddSubCategory.Enabled = True
        ddParticular.Enabled = True
        DrpSubClass.Enabled = True
        DrpSubClass.Enabled = True
        GenAccnt.Enabled = True
        btnadd.Enabled = False
        btnedit.Enabled = True
        btnsave.Enabled = True
        btnadd.Enabled = False
        btnedit.Enabled = True
        btnsave.Enabled = True
        Fileupload1.enabled = True
        ddUnit.DataSource = objDerived.GetRecords("exec [AMS].[loadunit]", CommandType.Text)
        ddUnit.DataTextField = "description"
        ddUnit.DataValueField = "Unit_ID"
        ddUnit.DataBind()
        Session("action") = "Edit"
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            If Session("action") = "Add" Then
                Dim Ddp As Integer
                If ddParticular.Text = "" Then
                    Ddp = 0
                Else
                    Ddp = ddParticular.SelectedItem.Value
                End If
                'If TextBoxDeptRate.Text = "" Then
                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Deprate is required.")
                'End If
                'If TextBoxDeptYear.Text = "" Then
                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Deprate year is required.")
                'End If



                If Ddp <> 0 Then

                    Me.HiddenField3.Value = "CY" & Me.ddyear.SelectedValue.ToString
                    If verify() = False Then


                        If drpclass.SelectedItem.Value = 7 Then


                            If DrpSubClass.Text = "" And ddSubCategory.Text <> "" Then

                                item2.Item_Desc = txtdescription.Text
                                item2.Unit_ID = ddUnit.SelectedValue
                                item2.item_particular_id = ddParticular.SelectedValue
                                item2.isAll = True
                                item2.detail = ""
                                item2.Item_Code = txtItemCode.Text
                                If ddSubCategory.SelectedValue = "select" Or ddSubCategory.SelectedValue Is Nothing Then
                                    item2.SubCategoryId = 0
                                Else
                                    item2.SubCategoryId = ddSubCategory.SelectedValue
                                End If
                                item2.ClassificationID = drpclass.SelectedValue

                                item2.DepRate = 0
                                item2.DepYear = 0
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

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtRpt.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                      " VALUES " &
                                                      " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)
                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_id,classificationID,ga_id,CategoryID,SubcategoryID,BGA_ID)Values('" & id & "','" & drpclass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & ddSubCategory.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)

                                'update the columns Price
                                'Me.objDerived.Execute(" update into dbo.m_item_detail set " & Session("CYNow") & " = " & item_detail.price & "  where Item_id=" & item_detail.Item_ID & "", CommandType.Text) 'and price = null


                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                            ElseIf DrpSubClass.Text <> "" And ddSubCategory.Text <> "" Then


                                item.Item_Desc = txtdescription.Text
                                item.Unit_ID = ddUnit.SelectedValue
                                item.item_particular_id = ddParticular.SelectedValue
                                item.isAll = True
                                item.detail = ""
                                item.Item_Code = txtItemCode.Text
                                If ddSubCategory.SelectedValue = "select" Or ddSubCategory.SelectedValue Is Nothing Then
                                    item.SubCategoryId = 0
                                Else
                                    item.SubCategoryId = ddSubCategory.SelectedValue
                                End If
                                item.ClassificationID = drpclass.SelectedValue
                                item.SubClassificationId = DrpSubClass.SelectedValue

                                item.DepRate = 0
                                item.DepYear = 0
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

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtRpt.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                      " VALUES " &
                                                      " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)
                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_ID,classificationID,ga_id,CategoryID,SubcategoryID,SubClassificationId,BGA)Values('" & id & "','" & drpclass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & ddSubCategory.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)
                                'update the columns Price
                                'Me.objDerived.Execute(" update into dbo.m_item_detail set " & Session("CYNow") & " = " & item_detail.price & "  where Item_id=" & item_detail.Item_ID & "", CommandType.Text) 'and price = null

                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                            ElseIf DrpSubClass.Text <> "" And ddSubCategory.Text = "" Then

                                item3.Item_Desc = txtdescription.Text
                                item3.Unit_ID = ddUnit.SelectedValue
                                item3.item_particular_id = ddParticular.SelectedValue
                                item3.isAll = True
                                item3.detail = ""
                                item3.Item_Code = txtItemCode.Text
                                item3.ClassificationID = drpclass.SelectedValue
                                item3.SubClassificationId = DrpSubClass.SelectedValue

                                item3.DepRate = 0
                                item3.DepYear = 0

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

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtRpt.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                          " VALUES " &
                                                          " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)

                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_ID,classificationID,ga_id,CategoryID,SubClassificationId,BGA_ID)Values('" & id & "','" & drpclass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)
                                'update the columns Price
                                'Me.objDerived.Execute(" update into dbo.m_item_detail set " & Session("CYNow") & " = " & item_detail.price & "  where Item_id=" & item_detail.Item_ID & "", CommandType.Text) 'and price = null
                                If TextBoxBrand.Text = "" Then
                                    objDerived.Execute("Update dbo.m_item set Brand = null where Item_id ='" & id & "'", CommandType.Text)

                                End If
                                If TextBoxColor.Text = "" Then
                                    objDerived.Execute("Update dbo.m_item set Color = null where Item_id ='" & id & "'", CommandType.Text)

                                End If
                                If TextBoxSize.Text = "" Then
                                    objDerived.Execute("Update dbo.m_item set Size = null where Item_id ='" & id & "'", CommandType.Text)

                                End If
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                            Else
                                item4.Item_Desc = txtdescription.Text
                                item4.Unit_ID = ddUnit.SelectedValue
                                item4.item_particular_id = ddParticular.SelectedValue
                                item4.isAll = True
                                item4.detail = ""
                                item4.Item_Code = txtItemCode.Text
                                item4.ClassificationID = drpclass.SelectedValue

                                item4.DepRate = 0
                                item4.DepYear = 0
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

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtRpt.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                          " VALUES " &
                                                          " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)

                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_ID,classificationID,ga_id,CategoryID,BGA_ID)Values('" & id & "','" & drpclass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)
                                'update the columns Price
                                'Me.objDerived.Execute(" update into dbo.m_item_detail set " & Session("CYNow") & " = " & item_detail.price & "  where Item_id=" & item_detail.Item_ID & "", CommandType.Text) 'and price = null

                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                            End If

                        Else
                            If DrpSubClass.Text = "" And ddSubCategory.Text <> "" Then

                                item2.Item_Desc = txtdescription.Text
                                item2.Unit_ID = ddUnit.SelectedValue
                                item2.item_particular_id = ddParticular.SelectedValue
                                item2.isAll = True
                                item2.detail = ""
                                item2.Item_Code = txtItemCode.Text

                                If ddSubCategory.SelectedValue = "select" Or ddSubCategory.SelectedValue Is Nothing Then
                                    item2.SubCategoryId = 0
                                Else
                                    item2.SubCategoryId = ddSubCategory.SelectedValue
                                End If
                                item2.ClassificationID = drpclass.SelectedValue


                                item2.DepRate = 0
                                item2.DepYear = 0
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

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtRpt.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                      " VALUES " &
                                                      " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)
                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_ID,classificationID,ga_id,CategoryID,SubcategoryID,BGA_ID)Values('" & id & "','" & drpclass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & ddSubCategory.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)

                                'update the columns Price
                                'Me.objDerived.Execute(" update into dbo.m_item_detail set " & Session("CYNow") & " = " & item_detail.price & "  where Item_id=" & item_detail.Item_ID & "", CommandType.Text) 'and price = null


                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                            ElseIf DrpSubClass.Text <> "" And ddSubCategory.Text <> "" Then


                                item.Item_Desc = txtdescription.Text
                                item.Unit_ID = ddUnit.SelectedValue
                                item.item_particular_id = ddParticular.SelectedValue
                                item.isAll = True
                                item.detail = ""
                                item.Item_Code = txtItemCode.Text

                                If ddSubCategory.SelectedValue = "select" Or ddSubCategory.SelectedValue Is Nothing Then
                                    item.SubCategoryId = 0
                                Else
                                    item.SubCategoryId = ddSubCategory.SelectedValue
                                End If


                                item.ClassificationID = drpclass.SelectedValue
                                    item.SubClassificationId = DrpSubClass.SelectedValue

                                item.DepRate = 0
                                item.DepYear = 0
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

                                    objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtRpt.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                    Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                          " VALUES " &
                                                          " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)
                                'INSERTING ON TBLCLASSMATRIX
                                Dim subCat As Integer = 0
                                If ddSubCategory.SelectedValue = "select" Or ddSubCategory.SelectedValue Is Nothing Then
                                    subCat = 0
                                Else
                                    subCat = ddSubCategory.SelectedValue
                                End If
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_ID,classificationID,ga_id,CategoryID,SubcategoryID,SubClassificationId,BGA_ID)Values('" & id & "','" & drpclass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & subCat & "','" & DrpSubClass.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)
                                'update the columns Price
                                'Me.objDerived.Execute(" update into dbo.m_item_detail set " & Session("CYNow") & " = " & item_detail.price & "  where Item_id=" & item_detail.Item_ID & "", CommandType.Text) 'and price = null

                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                                ElseIf DrpSubClass.Text <> "" And ddSubCategory.Text = "" Then

                                    item3.Item_Desc = txtdescription.Text
                                    item3.Unit_ID = ddUnit.SelectedValue
                                    item3.item_particular_id = ddParticular.SelectedValue
                                    item3.isAll = True
                                    item3.detail = ""
                                    item3.Item_Code = txtItemCode.Text
                                    item3.ClassificationID = drpclass.SelectedValue
                                    item3.SubClassificationId = DrpSubClass.SelectedValue

                                item3.DepRate = 0
                                item3.DepYear = 0
                                If TextBoxBrand.Text <> "" Then
                                        item3.Brand = TextBoxBrand.Text
                                    Else
                                    End If
                                    If TextBoxColor.Text <> "" Then
                                        item3.Color = TextBoxColor.Text
                                    Else
                                    End If

                                    If TextBoxSize.Text <> "" Then
                                        item3.Size = TextBoxColor.Text
                                    Else
                                    End If



                                    Dim id As Long = item3.save

                                    objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtRpt.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                    Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                              " VALUES " &
                                                              " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)

                                    'INSERTING ON TBLCLASSMATRIX
                                    Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_ID,classificationID,ga_id,CategoryID,SubClassificationId,BGA_ID)Values('" & id & "','" & drpclass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)
                                    'update the columns Price
                                    'Me.objDerived.Execute(" update into dbo.m_item_detail set " & Session("CYNow") & " = " & item_detail.price & "  where Item_id=" & item_detail.Item_ID & "", CommandType.Text) 'and price = null

                                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                                Else
                                    item4.Item_Desc = txtdescription.Text
                                item4.Unit_ID = ddUnit.SelectedValue
                                item4.item_particular_id = ddParticular.SelectedValue
                                item4.isAll = True
                                item4.detail = ""
                                item4.Item_Code = txtItemCode.Text
                                item4.ClassificationID = drpclass.SelectedValue
                                'If TextBoxDeptRate.Text = "" Or TextBoxDeptYear.Text = "" Then
                                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please enter a value.")
                                'Else
                                item4.DepRate = 0
                                    item4.DepYear = 0
                                'End If

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

                                objDerived.GetRecords("UPDATE dbo.m_item SET reorderPT = '" & txtRpt.Text & "' WHERE Item_ID = '" & id & "'", CommandType.Text)


                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & Me.HiddenField3.Value & ",UserId) " &
                                                          " VALUES " &
                                                          " ('" & id & "','" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & item_detail.UserId & "') ", CommandType.Text)

                                'INSERTING ON TBLCLASSMATRIX
                                Me.objDerived.Execute("INSERT INTO tblclassmatrix (Item_ID,classificationID,ga_id,CategoryID,BGA_ID)Values('" & id & "','" & drpclass.SelectedItem.Value & "','" & GenAccnt.SelectedItem.Value & "','" & ddParticular.SelectedItem.Value & "','" & 0 & "')", CommandType.Text)
                                'update the columns Price
                                'Me.objDerived.Execute(" update into dbo.m_item_detail set " & Session("CYNow") & " = " & item_detail.price & "  where Item_id=" & item_detail.Item_ID & "", CommandType.Text) 'and price = null

                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                            End If

                        End If


                        'Dim b As Integer

                        'If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
                        '    b = 0
                        'Else
                        '    b = DrpSubclass.Selecteditem.Value
                        'End If

                        'Dim d As Integer

                        'If drpSubclass.text = "" Or drpSubclass.text = "Select" Then
                        '    d = 0
                        'Else
                        '    d = drpSubclass.Selecteditem.Value
                        'End If



                        'pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)

                        'Session("CYNow") = "CY" & ddYear.SelectedItem.Text
                        'Session("CYPrev") = "CY" & ddYear.SelectedItem.Text - 1
                        ''pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & "0" & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
                        'gvstock.DataSource = pstock
                        'gvstock.DataBind()


                        'CType(gvstock.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
                        'CType(gvstock.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")


                        ddUnit.Enabled = False
                        txtprice.Enabled = False
                        txtdescription.Enabled = False
                        btnadd.Enabled = True
                        btnedit.Enabled = False
                        btnsave.Enabled = False
                        gvstock.SelectedIndex = -1

                        btnsave.Enabled = False

                    Else
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Record already existing.")
                        Exit Sub
                    End If
                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select particular.")
                End If
                '*****EDIT SAVING***
            ElseIf Session("action") = "Edit" Then


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



                            itemImage.AttachedF = imageBytes
                            Attched.Text = FileUpload1.PostedFile.FileName
                            Dim FName As String = FileUpload1.PostedFile.FileName

                            Dim path1 As String = Image1.ImageUrl
                            Dim path2 As String = System.IO.Path.GetDirectoryName(FName)



                            Image1.ImageUrl = Server.MapPath("..\") & "images\" & FName


                            'msg.UserMsgBox("File has been uploaded.", Me, False)

                            itemImage.AttachedFile = Attched.Text
                            Dim id As Long = objDerived.GetValue("Select Item_Id from dbo.m_item where Item_Id ='" & hdnItemSubClass.Value & "'", CommandType.Text)
                            objDerived.Execute("Update dbo.m_Item set AttachedFile ='" & Attched.Text & "' where Item_id ='" & id & "'", CommandType.Text)

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



                ModalPopupExtender3.Show()


            End If

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



            pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.SelectedItem.Value & "','" & 0 & "','" & drpclass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)

            Session("CYNow") = "CY" & ddyear.SelectedItem.Text
            Session("CYPrev") = "CY" & ddyear.SelectedItem.Text - 1
            'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & "0" & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
            gvstock.DataSource = pstock
            gvstock.DataBind()
            btnsave.enabled = False
        Catch ex As Exception

        End Try


    End Sub


    Protected Sub txtprice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprice.TextChanged
        txtprice.Text = FormatNumber(txtprice.Text, 2)
    End Sub

    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ddyear.SelectedValue.ToString = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select year.")
        Else
            Session("CYNow") = "CY" & Me.ddyear.SelectedValue.ToString
            Session("CYPrev") = "CY" & Me.ddyear.SelectedValue.ToString - 1

            ModalPopupExtender1.Show()
        End If

    End Sub

    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            Dim myview As DataView
            Dim b As Integer

            If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
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



            pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            'gvstock.DataSource = pstock
            'gvstock.DataBind()

            myview = pstock.DefaultView
            If ddSearch.SelectedItem.Value = 2 Then
                myview.RowFilter = "Item_Code like '%" & replaceapostrophe(txtsearch2.Text.ToString) & "%'"
            Else ddSearch.SelectedItem.Value = 1
                myview.RowFilter = "particulardesc like '%" & replaceapostrophe(txtsearch2.Text.ToString) & "%'"

            End If

            gvstock.DataSource = myview
            gvstock.DataBind()
            gvstock.PageIndex = 0

            CType(gvstock.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
            CType(gvstock.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")

            Session("View") = "Search"
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ddParticular_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddParticular.SelectedIndexChanged
        ddUnit.ClearSelection()
        ddUnit.DataSource = objDerived.GetRecords("exec [AMS].[loadunit]", CommandType.Text)
        ddUnit.DataTextField = "description"
        ddUnit.DataValueField = "Unit_ID"
        ddUnit.DataBind()
        ddUnit.Items.Insert(0, "Select")

        Dim items As New DataTable
        items = objDerived.GetDataTable("select SubCategoryID,SubCat_Desc from dbo.tbl_SubCategory where Item_particular_id = " & ddParticular.selecteditem.value & "Order by Subcat_Desc", CommandType.Text)
        ddSubCategory.enabled = True
        ddSubCategory.DataSource = items
        ddSubCategory.DataTextField = "SubCat_Desc"
        ddSubCategory.DataValueField = "SubCategoryID"
        ddSubCategory.DataBind()
        ddSubCategory.items.insert(0, "select")

        ddSubCategory.Enabled = True
        Dim b As Integer

        If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
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






        dtItems = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        gvstock.DataSource = dtItems
        gvstock.DataBind()
        gvstock.SelectedIndex = -1
        ddUnit.Enabled = True
    End Sub
    Protected Sub btnaddP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnaddP.Click
        Dim a As Integer

        If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
            a = 0
        Else
            a = DrpSubclass.Selecteditem.Value
        End If
        txtparticular.text = ""
        btnsaveparticular.enabled = True
        btnsaveparticular.Text = "Save"
        ModalPopupExtender5.Show()
        pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selectedItem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & a & "'", CommandType.Text)
        gvparticular.datasource = pParticular
        gvparticular.databind()


    End Sub

    Protected Sub gvparticular_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvparticular.PageIndexChanging
        gvparticular.PageIndex = e.NewPageIndex
        gvparticular.DataSource = CType(pParticular, DataTable)
        gvparticular.DataBind()

        ModalPopupExtender2.Show()

    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

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


        ModalPopupExtender8.Show()
    End Sub

    Protected Sub btnaddparticular_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnaddparticular.Enabled = True
        btnsaveparticular.Enabled = True
        txtparticular.ReadOnly = False

        txtparticular.Text = ""
        txtParticularCode.Text = ""
        TextBoxLife.Text = 0
        TxtLife.Text = 0
        txtparticular.Focus()

        txtLife.Enabled = True
        txtparticular.Enabled = True
        txtParticularCode.Enabled = True
        btnsaveparticular.Text = "Save"
        SubCattxt.text = ""

        ModalPopupExtender5.Show()

    End Sub
    Protected Sub Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnaddparticular.Enabled = True
        btnsaveparticular.Enabled = True
        txtparticular.ReadOnly = False

        txtparticular.Text = ""
        txtParticularCode.Text = ""
        TextBoxLife.Text = 0
        TxtLife.Text = ""
        txtparticular.Focus()

        txtLife.Enabled = True
        txtparticular.Enabled = True
        txtParticularCode.Enabled = True
        btnsaveparticular.Text = "Save"
        SubCattxt.text = ""

        ModalPopupExtender5.Show()

    End Sub

    Protected Sub btneditparticular_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnaddparticular.Enabled = False
        btnsaveparticular.Enabled = True
        txtparticular.ReadOnly = True
        txtparticular.Focus()

    End Sub

    Protected Sub gvparticular_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtLife.text = ""
        txtparticular.Text = gvparticular.SelectedDataKey(1)
        Dim a As String
        If txtLife.text = "" Then
            a = 0
        Else
            a = gvparticular.SelectedDataKey(2)
        End If
        txtlife.text = a



        txtparticular.ReadOnly = False
        txtparticular.Enabled = True

        txtParticularCode.Enabled = True

        txtLife.ReadOnly = False
        txtLife.Enabled = True

        btnsaveparticular.Text = "Update"
        btnsaveparticular.Enabled = True

        ModalPopupExtender5.Show()
    End Sub
    Protected Sub Gridview2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtparticular.Text = Gridview2.SelectedDataKey(1)
        Subcattxt.Text = Gridview2.SelectedDataKey("subcat_desc")
        Dim a As String
        textboxlife.text = Gridview2.SelectedDataKey(2)

        txtparticular.ReadOnly = False
        txtparticular.Enabled = True

        txtParticularCode.Enabled = True

        txtLife.ReadOnly = False
        txtLife.Enabled = True

        gvparticular1.Text = "Update"
        gvparticular1.Enabled = True

        ModalPopupExtender6.Show()
    End Sub
    Protected Sub btnsaveparticular_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim a As Integer

        If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
            a = 0
        Else
            a = DrpSubclass.Selecteditem.Value
        End If
        If txtlife.text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Put useful life of the property.")
            ModalPopupExtender2.Show()

        Else



            If btnsaveparticular.Text = "Save" Then
                Dim Dparticular = objDerived.getvalue("select count(*) from ams.item_particular where isnull(SubClassificationid,0) ='" & a & "' And ClassificationID ='" & drpclass.SelectedItem.Value & "' and ga_id ='" & GenAccnt.selectedItem.Value & "'", CommandType.Text)
                If Dparticular = 0 Then
                    With particular
                        particular.description = txtparticular.Text
                        particular.GA_ID = GenAccnt.selecteditem.value
                        particular.BGA_ID = 0
                        particular.useful_life = txtLife.Text
                        particular.ClassificationID = DrpClass.selectedItem.value
                        particular.SubClassificationID = a
                        '.ParticularCode = txtParticularCode.Text
                        .save()
                    End With
                    'Dim Val As Integer = Me.objDerived.getvalue("Select Item_particular_id from Ams.Item_particular where description like '%" & txtparticular.text & "%'", CommandType.Text)
                    'Me.objDerived.Execute("INSERT INTO tblclassmatrix (classificationID,CategoryID,ga_id)Values('" & drpclass.selectedItem.Value & "','" & Val & "','" & GenAccnt.SelectedItem.Value & "')", CommandType.Text)

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                Else
                    Dim gvparticular = objDerived.getvalue("select count(*) from ams.item_particular where description = '" & txtparticular.text & "' and GA_ID = '" & GenAccnt.selectedItem.value & "'AND BGA_ID='" & 0 & "'And ClassificationID='" & DrpClass.SelectedItem.Value & "'And SubclassificationID='" & a & "'", CommandType.Text)


                    If gvparticular = 0 Then
                        With particular
                            .description = txtparticular.Text
                            .GA_ID = GenAccnt.selecteditem.value
                            .BGA_ID = 0
                            .useful_life = txtLife.Text
                            .ClassificationID = DrpClass.selectedItem.value
                            .SubClassificationID = a
                            .ParticularCode = txtParticularCode.Text
                            .save()
                        End With
                        'Dim Val As Integer = Me.objDerived.getvalue("Select Item_particular_id from Ams.Item_particular where description like '%" & txtparticular.text & "%'", CommandType.Text)
                        'Me.objDerived.Execute("INSERT INTO tblclassmatrix (classificationID,CategoryID,ga_id)Values('" & drpclass.selectedItem.Value & "','" & Val & "','" & GenAccnt.SelectedItem.Value & "')", CommandType.Text)
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                    Else
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Record Already Exist.")
                    End If

                    'Exit Sub
                End If
            ElseIf btnsaveparticular.Text = "Update" Then
                objDerived.GetRecords("Update ams.item_particular set description='" & txtparticular.Text & "', useful_life = '" & txtLife.Text & "'  where item_particular_id='" & gvparticular.SelectedDataKey("item_particular_id") & "'", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Record has been successfully updated.")
            End If

        End If
        pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selectedItem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & a & "'", CommandType.Text)
        ddparticular.datasource = pParticular
        ddparticular.datatextfield = "description"
        ddparticular.datavaluefield = "item_particular_id"
        ddparticular.databind()
        ddparticular.items.insert(0, "select")

        gvparticular.datasource = pParticular
        gvparticular.databind()

        '    Else
        '        objDerived.GetRecords("Update ams.item_particular set description='" & txtparticular.Text & "', useful_life = '" & txtLife.Text & "'  where item_particular_id='" & gvparticular.SelectedDataKey(0) & "'", CommandType.Text)

        '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")
        '        If drpsubClass.text = "" Then

        '            pParticular = objDerived.GetDataTable("exec ams.FMparticularsSuppliesNoSubClass '" & GenAccnt.selecteditem.value & "','" & DrpClass.SelectedItem.Value & "'", CommandType.Text)
        '        Else
        '            pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "'", CommandType.Text)
        '        End If
        '        'pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies'" & GenAccnt.selecteditem.value & "','" & "0" & "'", CommandType.Text)
        '        pParticularData = objDerived.GetDataTable("exec ams.FMparticularsSupplies_data'" & GenAccnt.selecteditem.value & "','" & "0" & "'", CommandType.Text)

        '        gvstock.SelectedIndex = -1
        '        ddParticular.Enabled = True
        '        ddParticular.DataSource = Nothing
        '        ddParticular.DataBind()
        '        ddParticular.DataSource = pParticular
        '        ddParticular.DataTextField = "description"
        '        ddParticular.DataValueField = "item_particular_id"
        '        ddParticular.DataBind()


        '        gvparticular.DataSource = pParticularData
        '        gvparticular.DataBind()


        '        btnaddparticular.Enabled = True
        '        btnsaveparticular.Enabled = False
        '        ModalPopupExtender2.Show()
        '    End If
        '    Exit Sub
        'End If

        'If drpsubClass.text = "Select" Or drpsubClass.text = "" Then
        '    pParticular = objDerived.GetDataTable("exec ams.FMparticularsSuppliesNoSubClass '" & GenAccnt.selectedItem.value &  "','" & DrpClass.SelectedItem.Value & "'", CommandType.Text)
        '    ddParticular.DataSource = pParticular
        '    ddParticular.DataTextField = "description"
        '    ddParticular.DataValueField = "item_particular_id"
        '    ddParticular.DataBind()
        '    ddParticular.Items.Insert(0, "Select")
        'Else
        '    pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selectedItem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "'", CommandType.Text)
        '    ddParticular.DataSource = pParticular
        '    ddParticular.DataTextField = "description"
        '    ddParticular.DataValueField = "item_particular_id"
        '    ddParticular.DataBind()
        '    ddParticular.Items.Insert(0, "Select")
        'End If

        ModalPopupExtender2.Show()



    End Sub

    Protected Sub txtparticular_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Public Function verify() As Boolean
        Dim myview As DataView

        'pstock = objDerived.GetDataTable("exec   ams.FM_Stocks '" & gvcode.SelectedDataKey(2) & "','" & gvcode.SelectedDataKey(4) & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
        'pstock = objDerived.GetDataTable("exec  ams.FM_Stocks '" & GenAccnt.Selecteditem.value & "','" & "0" & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
        If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then


            pstock = objDerived.GetDataTable("exec ams.FM_StocksNoSubClass  '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpClass.selectedItem.Value & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
            myview = CType(pstock, DataTable).DefaultView
            myview.RowFilter = "particulardesc ='" & objDerived.replaceapostrophe(ddParticular.SelectedItem.Text) & "' and detail='" & objDerived.replaceapostrophe(txtdescription.Text) & "' and Unit_ID=" & ddUnit.SelectedItem.Value & ""
        Else
            pstock = objDerived.GetDataTable("exec ams.FM_Stocks  '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpClass.selectedItem.Value & "','" & drpSubClass.selectedItem.Value & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
            myview = CType(pstock, DataTable).DefaultView
            myview.RowFilter = "particulardesc ='" & objDerived.replaceapostrophe(ddParticular.SelectedItem.Text) & "' and detail='" & objDerived.replaceapostrophe(txtdescription.Text) & "' and Unit_ID=" & ddUnit.SelectedItem.Value & ""
        End If
        If btnadd.Enabled = False Then
            Return False
        End If
        If myview.Count <> 0 Then
            Return False
        Else
            Return False
        End If

    End Function

    Public Function verify2() As Boolean
        Dim myview As DataView
        If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then


            pstock = objDerived.GetDataTable("exec ams.FM_StocksNoSubClass  '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpClass.selectedItem.Value & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
            myview = CType(pstock, DataTable).DefaultView
            myview.RowFilter = "particulardesc ='" & objDerived.replaceapostrophe(ddParticular.SelectedItem.Text) & "' and detail='" & objDerived.replaceapostrophe(txtdescription.Text) & "' and Unit_ID=" & ddUnit.SelectedItem.Value & ""
        Else
            pstock = objDerived.GetDataTable("exec ams.FM_Stocks  '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpClass.selectedItem.Value & "','" & drpSubClass.selectedItem.Value & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
            myview = CType(pstock, DataTable).DefaultView
            myview.RowFilter = "particulardesc ='" & objDerived.replaceapostrophe(ddParticular.SelectedItem.Text) & "' and detail='" & objDerived.replaceapostrophe(txtdescription.Text) & "' and Unit_ID=" & ddUnit.SelectedItem.Value & ""
        End If
        Dim category As String

        If ddParticular.SelectedItem.Text = "Select" Then
            category = ""
        Else
            category = ddParticular.SelectedItem.Text
        End If
        myview.RowFilter = "particulardesc ='" & objDerived.replaceapostrophe(category) & "' and detail='" & objDerived.replaceapostrophe(txtdescription.Text) & "' and Unit_ID <> " & ddUnit.SelectedItem.Value & ""

        If myview.Count <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub GoEdit()



        Session("CYNow") = "CY" & Me.ddyear.SelectedValue.ToString
        Session("CYPrev") = "CY" & Me.ddyear.SelectedValue.ToString - 1
        Dim b As Integer

        If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
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


        '=-= Check if Description was changed
        If Me.Session("oldValueItem").ToString <> txtdescription.Text.ToString Then
            objDerived.GetRecords("Update dbo.m_item set Item_Desc = '" & replaceapostrophe(txtdescription.Text) & "' where Item_ID = '" & gvstock.SelectedDatakey(4) & "'", CommandType.Text)

            edit.PrimaryColumnName = "Item_ID"
            edit.TransactionID = gvstock.SelectedDataKey(4)
            edit.TableName = "dbo.m_item"
            edit.ColumnName = "Item_Desc"
            edit.TransactionDate = DateTime.Now
            edit.NewValue = replaceapostrophe(txtdescription.Text)
            edit.OldValue = Me.Session("oldValueItem").ToString
            edit.UserID = Me.Session("@UserID")
            edit.UserName2 = Me.Session("@UserName")
            edit.Remarks = txtremarks.Text
            edit.save()

            '=-= AUDIT TRAIL 11-12-2015
            With AuditTrail
                .TableName = "dbo.m_item"
                .RowId = gvstock.SelectedDataKey(4)
                .Operation = "UPDATE"
                .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                .PerformedBy = Session("@UserName")
                .FieldName = "Item_Desc"
                .OldValue = Session("oldValueItem").ToString
                .NewValue = replaceapostrophe(txtdescription.Text)
                .save()
            End With

        End If

        '=-= Check if Unit was changed
        If Me.Session("oldValueUnit") <> ddUnit.SelectedItem.Value Then
            objDerived.GetRecords("Update dbo.m_item set Unit_ID = '" & ddUnit.SelectedItem.Value & "' where Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)

            edit.PrimaryColumnName = "Item_ID"
            edit.TransactionID = gvstock.SelectedDataKey(4)
            edit.TableName = "dbo.m_item"
            edit.ColumnName = "Unit_ID"
            edit.TransactionDate = DateTime.Now
            edit.NewValue = ddUnit.SelectedItem.Value
            edit.OldValue = Me.Session("oldValueUnit").ToString
            edit.UserID = Me.Session("@UserID")
            edit.UserName2 = Me.Session("@UserName")
            edit.Remarks = txtremarks.Text
            edit.save()

            '=-= AUDIT TRAIL 11-12-2015
            With AuditTrail
                .TableName = "dbo.m_item"
                .RowId = gvstock.SelectedDataKey(4)
                .Operation = "UPDATE"
                .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                .PerformedBy = Session("@UserName")
                .FieldName = "Unit_ID"
                .OldValue = Session("oldValueUnit").ToString
                .NewValue = ddUnit.SelectedItem.Value
                .save()
            End With
        End If

        '=-= Check if Price was changed
        If CType(Me.Session("oldValuePrice"), Decimal) <> CType(txtprice.Text, Decimal) Then
            objDerived.GetRecords("Update dbo.m_item_detail set " & Session("CYNow") & "='" & CType(txtprice.Text, Decimal) & "', userId = '" & Me.Session("@UserName") & "', price = '" & CType(txtprice.Text, Decimal) & "' where Item_ID=" & gvstock.SelectedDataKey(4) & "", CommandType.Text)

            edit.PrimaryColumnName = "Item_ID"
            edit.TransactionID = gvstock.SelectedDataKey(4)
            edit.TableName = "dbo.m_item_detail"
            edit.ColumnName = "price"
            edit.TransactionDate = DateTime.Now
            edit.NewValue = txtprice.Text.ToString
            edit.OldValue = Me.Session("oldValuePrice").ToString
            edit.UserID = Me.Session("@UserID")
            edit.UserName2 = Me.Session("@UserName")
            edit.Remarks = txtremarks.Text
            edit.save()


            '=-= AUDIT TRAIL 11-12-2015
            With AuditTrail
                .TableName = "dbo.m_item_detail"
                .RowId = gvstock.SelectedDataKey(4)
                .Operation = "UPDATE"
                .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                .PerformedBy = Session("@UserName")
                .FieldName = "price"
                .OldValue = Session("oldValuePrice").ToString
                .NewValue = txtprice.Text.ToString
                .save()
            End With

        End If

        '=-= Check if Re-order Point was changed
        Dim Rpoint As Integer = objDerived.GetValue("SELECT reorderPT FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        If Rpoint <> txtRpt.Text Then
            objDerived.GetRecords("Update dbo.m_item set reorderPT ='" & txtRpt.Text & "' where Item_ID=" & gvstock.SelectedDataKey(4) & "", CommandType.Text)

            edit.PrimaryColumnName = "Item_ID"
            edit.TransactionID = gvstock.SelectedDataKey(4)
            edit.TableName = "dbo.m_item"
            edit.ColumnName = "reorderPT"
            edit.TransactionDate = DateTime.Now
            edit.NewValue = txtRpt.Text
            edit.OldValue = Rpoint
            edit.UserID = Me.Session("@UserID")
            edit.UserName2 = Me.Session("@UserName")
            edit.Remarks = txtremarks.Text
            edit.save()

            '=-= AUDIT TRAIL 11-12-2015
            With AuditTrail
                .TableName = "dbo.m_item"
                .RowId = gvstock.SelectedDataKey(4)
                .Operation = "UPDATE"
                .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                .PerformedBy = Session("@UserName")
                .FieldName = "reorderPT"
                .OldValue = Rpoint
                .NewValue = txtRpt.Text
                .save()
            End With

        End If


        '=-= Check Item_Code
        Dim ItemCode As String = objDerived.GetValue("SELECT Item_Code FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        If ItemCode <> txtItemCode.Text Then
            objDerived.GetRecords("Update dbo.m_item set Item_Code = '" & txtItemCode.Text & "' where Item_ID=" & gvstock.SelectedDataKey(4) & "", CommandType.Text)

            edit.PrimaryColumnName = "Item_ID"
            edit.TransactionID = gvstock.SelectedDataKey(4)
            edit.TableName = "dbo.m_item"
            edit.ColumnName = "Item_Code"
            edit.TransactionDate = DateTime.Now
            edit.NewValue = txtItemCode.Text
            edit.OldValue = ItemCode
            edit.UserID = Me.Session("@UserID")
            edit.UserName2 = Me.Session("@UserName")
            edit.Remarks = txtremarks.Text
            edit.save()

            '=-= AUDIT TRAIL 11-12-2015
            With AuditTrail
                .TableName = "dbo.m_item"
                .RowId = gvstock.SelectedDataKey(4)
                .Operation = "UPDATE"
                .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                .PerformedBy = Session("@UserName")
                .FieldName = "Item_Code"
                .OldValue = ItemCode
                .NewValue = txtItemCode.Text
                .save()
            End With
        End If

        pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        gvstock.DataSource = pstock
        gvstock.DataBind()




        Dim DepRate As String = objDerived.GetValue("SELECT DepRate FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        If DepRate <> TextBoxDeptRate.Text Then
            objDerived.GetRecords("UPDATE dbo.m_item SET DepRate ='" & TextBoxDeptRate.Text & "' WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        End If
        Dim DepYear As String = objDerived.GetValue("SELECT DepYear FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        If DepYear <> TextBoxDeptYear.Text Then
            objDerived.GetRecords("UPDATE dbo.m_item SET DepYear ='" & TextBoxDeptYear.Text & "' WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        End If

        Dim GeneName As String = objDerived.GetValue("SELECT GenericName FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        If GeneName <> TextBoxGen.Text Then
            objDerived.GetRecords("UPDATE dbo.m_item SET GenericName ='" & TextBoxGen.Text & "' WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        End If

        Dim BrndName As String = objDerived.GetValue("SELECT Brand FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        If BrndName <> TextBoxBrand.Text Then
            objDerived.GetRecords("UPDATE dbo.m_item SET Brand ='" & TextBoxBrand.Text & "' WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        End If

        Dim ClrName As String = objDerived.GetValue("SELECT Color FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        If ClrName <> TextBoxColor.Text Then
            objDerived.GetRecords("UPDATE dbo.m_item SET Color ='" & TextBoxColor.Text & "' WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        End If

        Dim SzName As String = objDerived.GetValue("SELECT Size FROM dbo.m_item WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        If SzName <> TextBoxSize.Text Then
            objDerived.GetRecords("UPDATE dbo.m_item SET Size ='" & TextBoxSize.Text & "' WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
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

        Dim GenA As String = objDerived.GetValue("SELECT GA_ID FROM tblclassmatrix WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        If GenA Is Nothing Then
            objDerived.GetRecords("UPDATE dbo.tblclassmatrix SET GA_ID ='" & GenAccnt.SelectedItem.Value & "' WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
        Else
            If GenA <> GenAccnt.SelectedItem.Text Then
                'objDerived.GetRecords("UPDATE dbo.m_item SET ga_id ='" & GenAccnt.SelectedItem.Value & "' WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE dbo.tblclassmatrix SET ga_id ='" & GenAccnt.SelectedItem.Value & "' WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
            End If
        End If


        pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        gvstock.DataSource = pstock
        gvstock.DataBind()


        ddParticular.Enabled = False
        ddUnit.Enabled = False
        txtItemCode.Enabled = False
        txtdescription.Enabled = False
        txtprice.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = False
        btnsave.Enabled = False
        txtremarks.Text = ""

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully updated.")


    End Sub
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        hdnItemSubClass.Value = Session("ITMID")

        Session("CYNow") = "CY" & Me.ddyear.SelectedValue.ToString
        Session("CYPrev") = "CY" & Me.ddyear.SelectedValue.ToString - 1
        Dim b As Integer

        If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
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


        '=-= Check if Description was changed
        If Me.Session("oldValueItem").ToString <> txtdescription.Text.ToString Then

                objDerived.GetRecords("Update dbo.m_item set Item_Desc = '" & replaceapostrophe(txtdescription.Text) & "' where Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)

                edit.PrimaryColumnName = "Item_ID"
                edit.TransactionID = hdnItemSubClass.value
                edit.TableName = "dbo.m_item"
                edit.ColumnName = "Item_Desc"
                edit.TransactionDate = DateTime.Now
                edit.NewValue = replaceapostrophe(txtdescription.Text)
                edit.OldValue = Me.Session("oldValueItem").ToString
                edit.UserID = Me.Session("@UserID")
                edit.UserName2 = Me.Session("@UserName")
                edit.Remarks = txtremarks.Text
                edit.save()

                '=-= AUDIT TRAIL 11-12-2015
                With AuditTrail
                    .TableName = "dbo.m_item"
                    .RowId = hdnItemSubClass.value
                    .Operation = "UPDATE"
                    .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                    .PerformedBy = Session("@UserName")
                    .FieldName = "Item_Desc"
                    .OldValue = Session("oldValueItem").ToString
                    .NewValue = replaceapostrophe(txtdescription.Text)
                    .save()
                End With

            End If

            '=-= Check if Unit was changed
            If Me.Session("oldValueUnit") <> ddUnit.SelectedItem.Value Then
                objDerived.GetRecords("Update dbo.m_item set Unit_ID = '" & ddUnit.SelectedItem.Value & "' where Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)

                edit.PrimaryColumnName = "Item_ID"
                edit.TransactionID = hdnItemSubClass.value
                edit.TableName = "dbo.m_item"
                edit.ColumnName = "Unit_ID"
                edit.TransactionDate = DateTime.Now
                edit.NewValue = ddUnit.SelectedItem.Value
                edit.OldValue = Me.Session("oldValueUnit").ToString
                edit.UserID = Me.Session("@UserID")
                edit.UserName2 = Me.Session("@UserName")
                edit.Remarks = txtremarks.Text
                edit.save()

                '=-= AUDIT TRAIL 11-12-2015
                With AuditTrail
                    .TableName = "dbo.m_item"
                    .RowId = hdnItemSubClass.value
                    .Operation = "UPDATE"
                    .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                    .PerformedBy = Session("@UserName")
                    .FieldName = "Unit_ID"
                    .OldValue = Session("oldValueUnit").ToString
                    .NewValue = ddUnit.SelectedItem.Value
                    .save()
                End With
            End If

            '=-= Check if Price was changed
            If CType(Me.Session("oldValuePrice"), Decimal) <> CType(txtprice.Text, Decimal) Then
                objDerived.GetRecords("Update dbo.m_item_detail set " & Session("CYNow") & "='" & CType(txtprice.Text, Decimal) & "', userId = '" & Me.Session("@UserName") & "', price = '" & CType(txtprice.Text, Decimal) & "' where Item_ID=" & Session("itmid") & "", CommandType.Text)

                edit.PrimaryColumnName = "Item_ID"
                edit.TransactionID = hdnItemSubClass.value
                edit.TableName = "dbo.m_item_detail"
                edit.ColumnName = "price"
                edit.TransactionDate = DateTime.Now
                edit.NewValue = txtprice.Text.ToString
                edit.OldValue = Me.Session("oldValuePrice").ToString
                edit.UserID = Me.Session("@UserID")
                edit.UserName2 = Me.Session("@UserName")
                edit.Remarks = txtremarks.Text
                edit.save()


                '=-= AUDIT TRAIL 11-12-2015
                With AuditTrail
                    .TableName = "dbo.m_item_detail"
                    .RowId = hdnItemSubClass.value
                    .Operation = "UPDATE"
                    .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                    .PerformedBy = Session("@UserName")
                    .FieldName = "price"
                    .OldValue = Session("oldValuePrice").ToString
                    .NewValue = txtprice.Text.ToString
                    .save()
                End With

            End If

            '=-= Check if Re-order Point was changed
            Dim Rpoint As Integer = objDerived.GetValue("SELECT reorderPT FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            If Rpoint <> txtRpt.Text Then
                objDerived.GetRecords("Update dbo.m_item set reorderPT ='" & txtRpt.Text & "' where Item_ID=" & hdnItemSubClass.value & "", CommandType.Text)

                edit.PrimaryColumnName = "Item_ID"
                edit.TransactionID = hdnItemSubClass.value
                edit.TableName = "dbo.m_item"
                edit.ColumnName = "reorderPT"
                edit.TransactionDate = DateTime.Now
                edit.NewValue = txtRpt.Text
                edit.OldValue = Rpoint
                edit.UserID = Me.Session("@UserID")
                edit.UserName2 = Me.Session("@UserName")
                edit.Remarks = txtremarks.Text
                edit.save()

                '=-= AUDIT TRAIL 11-12-2015
                With AuditTrail
                    .TableName = "dbo.m_item"
                    .RowId = hdnItemSubClass.value
                    .Operation = "UPDATE"
                    .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                    .PerformedBy = Session("@UserName")
                    .FieldName = "reorderPT"
                    .OldValue = Rpoint
                    .NewValue = txtRpt.Text
                    .save()
                End With

            End If


            '=-= Check Item_Code
            Dim ItemCode As String = objDerived.GetValue("SELECT Item_Code FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            If ItemCode <> txtItemCode.Text Then
                objDerived.GetRecords("Update dbo.m_item set Item_Code = '" & txtItemCode.Text & "' where Item_ID=" & hdnItemSubClass.value & "", CommandType.Text)

                edit.PrimaryColumnName = "Item_ID"
                edit.TransactionID = hdnItemSubClass.value
                edit.TableName = "dbo.m_item"
                edit.ColumnName = "Item_Code"
                edit.TransactionDate = DateTime.Now
                edit.NewValue = txtItemCode.Text
                edit.OldValue = ItemCode
                edit.UserID = Me.Session("@UserID")
                edit.UserName2 = Me.Session("@UserName")
                edit.Remarks = txtremarks.Text
                edit.save()

                '=-= AUDIT TRAIL 11-12-2015
                With AuditTrail
                    .TableName = "dbo.m_item"
                    .RowId = hdnItemSubClass.value
                    .Operation = "UPDATE"
                    .OccurredAt = Date.Today.ToString("MM/dd/yyyy")
                    .PerformedBy = Session("@UserName")
                    .FieldName = "Item_Code"
                    .OldValue = ItemCode
                    .NewValue = txtItemCode.Text
                    .save()
                End With
            End If

            pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            gvstock.DataSource = pstock
            gvstock.DataBind()




            Dim DepRate As String = objDerived.GetValue("SELECT DepRate FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            If DepRate <> TextBoxDeptRate.Text Then
                objDerived.GetRecords("UPDATE dbo.m_item SET DepRate ='" & TextBoxDeptRate.Text & "' WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            End If
            Dim DepYear As String = objDerived.GetValue("SELECT DepYear FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            If DepYear <> TextBoxDeptYear.Text Then
                objDerived.GetRecords("UPDATE dbo.m_item SET DepYear ='" & TextBoxDeptYear.Text & "' WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            End If

            Dim GeneName As String = objDerived.GetValue("SELECT GenericName FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            If GeneName <> TextBoxGen.Text Then
                objDerived.GetRecords("UPDATE dbo.m_item SET GenericName ='" & TextBoxGen.Text & "' WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            End If

            Dim BrndName As String = objDerived.GetValue("SELECT Brand FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            If BrndName <> TextBoxBrand.Text Then
                objDerived.GetRecords("UPDATE dbo.m_item SET Brand ='" & TextBoxBrand.Text & "' WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            End If

            Dim ClrName As String = objDerived.GetValue("SELECT Color FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            If ClrName <> TextBoxColor.Text Then
                objDerived.GetRecords("UPDATE dbo.m_item SET Color ='" & TextBoxColor.Text & "' WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            End If

            Dim SzName As String = objDerived.GetValue("SELECT Size FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            If SzName <> TextBoxSize.Text Then
                objDerived.GetRecords("UPDATE dbo.m_item SET Size ='" & TextBoxSize.Text & "' WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            End If


            Dim SubC As String = objDerived.GetValue("SELECT SubClassificationID FROM dbo.m_item WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)

            If SubC Is Nothing Then

                objDerived.GetRecords("UPDATE dbo.m_item SET SubclassificationID ='" & DrpSubClass.SelectedItem.Value & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)

            Else
                If DrpSubClass.Text <> "" Then


                    If SubC <> DrpSubClass.SelectedItem.Text Then
                        objDerived.GetRecords("UPDATE dbo.m_item SET SubclassificationID ='" & DrpSubClass.SelectedItem.Value & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
                        objDerived.GetRecords("UPDATE dbo.tblclassmatrix SET SubclassificationID ='" & DrpSubClass.SelectedItem.Value & "' WHERE Item_ID = '" & hdnItemSubClass.Value & "'", CommandType.Text)
                    End If

                End If
            End If

            Dim GenA As String = objDerived.GetValue("SELECT GA_ID FROM tblclassmatrix WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            If GenA Is Nothing Then
                objDerived.GetRecords("UPDATE dbo.tblclassmatrix SET GA_ID ='" & GenAccnt.SelectedItem.Value & "' WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
            Else
                If GenA <> GenAccnt.SelectedItem.Text Then
                    'objDerived.GetRecords("UPDATE dbo.m_item SET ga_id ='" & GenAccnt.SelectedItem.Value & "' WHERE Item_ID = '" & gvstock.SelectedDataKey(4) & "'", CommandType.Text)
                    objDerived.GetRecords("UPDATE dbo.tblclassmatrix SET ga_id ='" & GenAccnt.SelectedItem.Value & "' WHERE Item_ID = '" & hdnItemSubClass.value & "'", CommandType.Text)
                End If
            End If


        pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        gvstock.DataSource = pstock
        gvstock.DataBind()


        ddParticular.Enabled = False
        ddUnit.Enabled = False
        txtItemCode.Enabled = False
        txtdescription.Enabled = False
        txtprice.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = False
        btnsave.Enabled = False
        txtremarks.Text = ""

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully updated.")


    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chk As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(chk.NamingContainer, GridViewRow)

        Try
            If chk.Checked = True Then
                objDerived.GetRecords("Update dbo.m_Item set isUsed = '" & chk.Checked & "' where item_id = " & Me.gvstock.DataKeys(gvr.RowIndex).Item(4), CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Item has been successfully hide.")
            Else
                objDerived.GetRecords("Update dbo.m_Item set isUsed = '" & chk.Checked & "' where item_id = " & Me.gvstock.DataKeys(gvr.RowIndex).Item(4), CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Item has been successfully Visible.")
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddyear.SelectedIndexChanged
        drpclass.Items.clear()
        Me.gvstock.Columns(7).HeaderText = "Price " & "(" & HiddenField2.Value & ")"
        Me.gvstock.Columns(8).HeaderText = "Price " & "(" & HiddenField2.Value + 1 & ")"


        Session("CYPrev") = "CY" & ddyear.selectedvalue - 1

        Session("CYNow") = "CY" & ddyear.selectedvalue

        dtClass = objDerived.GetDataTable("Select * from dbo.tbl_Classification where AllotmentClass_id = 3 order by ClassificationName  ", CommandType.Text)
        DrpClass.DataSource = dtClass
        DrpClass.DataTextField = "ClassificationName"
        DrpClass.DataValueField = "ClassificationID"
        DrpClass.Items.Insert(0, "Select")
        DrpClass.DataBind()

        ddUnit.DataSource = objDerived.GetRecords("exec [AMS].[loadunit]", CommandType.Text)
        ddUnit.DataTextField = "description"
        ddUnit.DataValueField = "Unit_ID"
        ddUnit.DataBind()

    End Sub

    Protected Sub bntcopyPerGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntcopyPerGrid.Click
        For Each row As GridViewRow In Me.gvstock.Rows
            Dim therowindex As Integer = row.RowIndex
            Dim theid As Integer
            theid = gvstock.DataKeys(therowindex)(4).ToString

            objDerived.GetRecords("update dbo.m_item_detail set " & Session("CYNow") & " = case when  " & Session("CYPrev") & "  is null  then isnull(" & gvstock.DataKeys(therowindex)(8).ToString & ",'0.00') else isnull(" & gvstock.DataKeys(therowindex)(3).ToString & ",'0.00') end   where Item_ID=" & gvstock.DataKeys(therowindex)(4).ToString & " and (" & Session("CYNow") & " is null or " & Session("CYNow") & "='0.00') ", CommandType.Text)
        Next
        pstock = objDerived.GetDataTable("exec ams.FM_Stocks  '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpClass.selectedItem.Value & "','" & drpSubClass.selectedItem.Value & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
        ' pstock = objDerived.GetDataTable("exec ams.FM_Stocks '" & gvcode.SelectedDataKey(2) & "','" & gvcode.SelectedDataKey(4) & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "'", CommandType.Text)
        gvstock.DataSource = pstock
        gvstock.DataBind()

    End Sub

    Protected Sub btncopyall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncopyall.Click
        Try

            'Me.objDerived.GetRecords("update dbo.m_item_detail set " & Session("CYNow") & " = case when  " & Session("CYPrev") & " is null  then  price else " & Session("CYPrev") & "  end from dbo.m_item inner join  dbo.m_item_detail on  dbo.m_item.item_id = dbo.m_item_detail.item_id inner join  ams.item_particular on   dbo.m_item.Item_particular_id = ams.item_particular.Item_particular_id where ams.item_particular.ga_id = '" & gvstock.SelectedDataKey(2) & "' and ams.item_particular.bga_id = '" & gvstock.SelectedDataKey(4) & "' and " & Session("CYNow") & " is null or  " & Session("CYNow") & " = '0.00' ", CommandType.Text)
            Me.objDerived.GetRecords("update dbo.m_item_detail set " & Session("CYNow") & "=case when  " & Session("CYPrev") & " is null  then isnull(price,0) else isnull(" & Session("CYPrev") & ",0) end from dbo.m_item inner join  dbo.m_item_detail on  dbo.m_item.item_id = dbo.m_item_detail.item_id inner join  ams.item_particular on   dbo.m_item.Item_particular_id = ams.item_particular.Item_particular_id where ams.item_particular.ga_id='" & GenAccnt.selecteditem.value & "' and ams.item_particular.bga_id='0' And " & Session("CYNow") & " is null or  " & Session("CYNow") & "='0.00' ", CommandType.Text)
        Catch ex As Exception
        End Try

        Dim b As Integer

        If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
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


        pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpclass.selectedItem.value & "','" & b & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        gvstock.DataSource = pstock
        gvstock.DataBind()
    End Sub

    Protected Sub ddUnit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        txtdescription.Enabled = True
        txtprice.Enabled = True
        txtItemCode.enabled = True
    End Sub

    Protected Sub btn_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pParticular = objDerived.GetDataTable("exec ams.FMparticularCapitaloutlay '" & gvcode.SelectedDataKey("GA_ID") & "','" & gvcode.SelectedDataKey("BGA_ID") & "'", CommandType.Text)
        ddParticular.DataSource = pParticular
        ddParticular.DataTextField = "description"
        ddParticular.DataValueField = "item_particular_id"
        ddParticular.DataBind()
        ddParticular.Items.Insert(0, "Select")

        ModalPopupExtender2.Hide()
    End Sub

    Protected Sub btnSearchAccnt_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = pCode.DefaultView
        myview.RowFilter = "GA_Title like '%" & replaceapostrophe(txtAccnTitle.Text.ToString) & "%'"
        gvcode.DataSource = myview
        gvcode.DataBind()
        gvcode.PageIndex = 0

        ModalPopupExtender1.Show()

    End Sub

    Protected Sub txtdescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '    Dim dt As New DataTable
        '    Dim Desc As String = ddParticular.SelectedItem.Text + " - " + replaceapostrophe(txtdescription.Text)
        '    dt = objDerived.GetDataTable("SELECT DISTINCT dbo.m_item.Item_Desc, AMS.item_particular.GA_ID FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id WHERE dbo.m_item.Item_Desc = '" & Desc & "' AND AMS.item_particular.GA_ID = '" & Session("pGA_ID") & "'", CommandType.Text)
        '    If dt.Rows.Count = 0 Then
        '        imgCheck.Visible = True
        '        lblmsg.Visible = False
        '    Else
        '        imgCheck.Visible = False
        '        lblmsg.Visible = True
        '    End If
    End Sub

    Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Session("Option") = "Delete"
    End Sub

    Protected Sub txtItemCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ItemCode As String
        ItemCode = objDerived.GetValue("SELECT DISTINCT Item_ID FROM dbo.m_item WHERE Item_Code = '" & txtItemCode.Text & "'", CommandType.Text)

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
    Protected Sub drpclass_SelectedIndexChanged(sender As Object, e As EventArgs)


        txtdescription.text = ""
        Dim prc As Decimal = 0.00
        txtprice.text = prc
        ddSubCategory.Items.Clear()
        btnadd.enabled = True
        btnedit.enabled = True
        ddParticular.items.clear()
        GenAccnt.items.clear()

        If DrpClass.SelectedItem.Value = 5 Then
            TextBoxGen.enabled = "True"
            GenName.Visible = True
        Else
            TextBoxGen.enabled = "False"
            GenName.Visible = False
        End If
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

        Dim b As Integer

        If DrpSubClass.text = "" Or DrpSubClass.text = "Select" Then
            b = 0
        Else
            b = DrpSubclass.Selecteditem.Value
        End If

        Dim c As Integer
        If ddSubCategory.text = "" Then
            c = 0
        Else
            c = ddSubCategory.Selecteditem.Value
        End If



        Session("CYNow") = "CY" & ddYear.SelectedItem.Text
        Session("CYPrev") = "CY" & ddYear.SelectedItem.Text - 1
        'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpclass.selectedItem.value & "','" & b & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        ''pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & "0" & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
        'gvstock.DataSource = pstock
        'gvstock.DataBind()


        Session("Action") = "Add"

        '
    End Sub
    Protected Sub GenAccnt_SelectedIndexChanged(sender As Object, e As EventArgs)


        Dim a As Integer
        If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
            a = 0
        Else
            a = DrpSubclass.Selecteditem.Value
        End If
        pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selectedItem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & a & "'", CommandType.Text)
        ddparticular.datasource = pParticular
        ddparticular.datatextfield = "description"
        ddparticular.datavaluefield = "item_particular_id"
        ddparticular.databind()
        ddparticular.items.insert(0, "select")

        If ddParticular.selecteditem.value = "Select" Then


            Dim items As New DataTable
            items = objDerived.GetDataTable("select SubCategoryID,SubCat_Desc from dbo.tbl_SubCategory Order by Subcat_Desc", CommandType.Text)
            SubCattxt.text = ""

            ddSubCategory.DataSource = items
            ddSubCategory.DataTextField = "SubCat_Desc"
            ddSubCategory.DataValueField = "SubCategoryID"
            ddSubCategory.DataBind()
            ddSubCategory.Items.Insert(0, "Select")
            ddSubCategory.Selecteditem.value = +1
        End If



        Dim b As Integer

        If DrpSubClass.text = "" Or drpSubClass.text = "Select" Then
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



        pstock = objDerived.GetDataTable("EXEC [AMS].[GA_perClass&SubClass] '" & GenAccnt.selecteditem.value & "','" & 0 & "','" & DrpClass.SelectedItem.Value & "','" & d & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        '12162022
        Session("CYNow") = "CY" & ddYear.SelectedItem.Text
        Session("CYPrev") = "CY" & ddYear.SelectedItem.Text - 1
        'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & "0" & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)



        gvstock.DataSource = pstock
        gvstock.DataBind()
        Dim cb As CheckBox
        For i As Integer = 0 To gvstock.Rows.Count - 1
            If pstock.Rows(i)("isused") = 0 Then
                cb = CType(Me.gvstock.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                cb.Checked = False
            Else
                cb = CType(Me.gvstock.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                cb.Checked = True
            End If



        Next


    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs)

        Try
            Dim depval As Decimal
            textboxDeptyear.text = depval
            textboxDeptRate.text = depval

            SubCat = objDerived.GetDataTable("exec [AMS].[FMSuBcategory]'" & ddparticular.selecteditem.value & "'", CommandType.Text)
            Gridview2.DataSource = SubCat
            Gridview2.DataBind()
            TxtSubCat.text = ddParticular.Selecteditem.text
            ModalPopupExtender6.show()
            TxtSubCat.Enabled = False
            ddunit.Enabled = True
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Sub Category must have a value")
        End Try
    End Sub
    Protected Sub loadparticular()
        'pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("GA_ID") & "','" & pCode.Rows(ddAccountCode.SelectedIndex - 1)("BGA_ID") & "'", CommandType.Text)

        pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & GenAccnt.selecteditem.value & "','0'", CommandType.Text)
        ddParticular.DataSource = pParticular
        ddParticular.DataTextField = "description"
        ddParticular.DataValueField = "item_particular_id"
        ddParticular.DataBind()
        ddParticular.Items.Insert(0, "Select")

        pParticularData = objDerived.GetDataTable("exec [AMS].[FMparticularsSupplies_data] '" & GenAccnt.selecteditem.value & "','0'", CommandType.Text)
        gvparticular.DataSource = pParticularData
        gvparticular.DataBind()

        'SubCat = objDerived.GetDataTable("exec [AMS].[FMSuBcategory]'" & ddparticular.selecteditem.value & "'", CommandType.Text)
        'Gridview2.DataSource = SubCat
        'Gridview2.DataBind()



    End Sub
    Protected Sub btnsaveSubCat_Click(sender As Object, e As EventArgs)
        If gvparticular1.text = "Update" Then

            Me.objDerived.Execute("Update tbl_SubCategory set Subcat_Desc ='" & SubCattxt.text & "',Useful_life ='" & TextBoxLife.text & "' where SubCategoryid = '" & gridview2.selecteddatakey("SubCategoryID") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Record has been successfully updated.")
        Else

            Me.objDerived.Execute("Insert into tbl_SubCategory(Subcat_Desc,Item_particular_id,ClassificationID,Useful_life)Values('" & SubCattxt.text & "','" & ddparticular.Selectedvalue & "','" & DrpClass.SelectedItem.Value & "','" & TextBoxLife.text & "') ", CommandType.Text)
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
        ddSubCategory.DataSource = items
        ddSubCategory.DataTextField = "SubCat_Desc"
        ddSubCategory.DataValueField = "SubCategoryID"
        ddSubCategory.DataBind()
        ddSubCategory.items.insert(0, "select")

        gvparticular1.text = "Save"
        ModalPopupExtender6.show()
    End Sub
    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs)
        Me.ModalPopupExtender8.show()
        LinkButton5.Enabled = False
        Me.WithSubClass.Checked = False
        TxtClassification.text = ""

        DdSubClassification.items.clear()


        GvClass.DataSource = objDerived.GetDataTable("Select * from tbl_classification order by ClassificationName asc", CommandType.Text)
        GvClass.DataBind()

        DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies where AllotmentClass_ID = 3 order by GA_Title ", CommandType.Text)
        DropGA.DataSource = DrpGenAcc
        DropGA.DataTextField = "GA_title"
        DropGA.DataValueField = "GA_ID"

        DropGA.items.clear()
        DropGA.DataBind()



    End Sub
    Protected Sub WithSubClass_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WithSubClass.CheckedChanged
        If Me.WithSubClass.Checked = True Then
            DropGA.enabled = False
        Else
            DropGA.enabled = True
        End If
        ModalPopupExtender8.show()
    End Sub
    Protected Sub LinkButton5_Click(sender As Object, e As EventArgs)
        ClassificationGrd = objDerived.GetDataTable("Select * from dbo.tbl_Classification where AllotmentClass_id = 3 order by ClassificationName ", CommandType.Text)
        ddClassNewSub.DataSource = ClassificationGrd
        ddClassNewSub.DatatextField = "ClassificationName"
        ddClassNewSub.DataValueField = "ClassificationId"
        ddClassNewSub.DataBind()

        NewSubClassificationTxt.enabled = True

        DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies  where AllotmentClass_Id = 3 order by GA_Title ", CommandType.Text)
        ddGASubClass.DataSource = DrpGenAcc
        ddGASubClass.DataTextField = "GA_title"
        ddGASubClass.DataValueField = "GA_ID"

        ddGASubClass.items.clear()
        ddGASubClass.DataBind()

        DropGA.items.clear()
        DropGA.DataBind()
        ModalPopupExtender7.show()

    End Sub

    Protected Sub LinkButton6_Click(sender As Object, e As EventArgs)
        ddClassNewSub.enabled = True
        NewSubClassificationTxt.enabled = True
        ddClassNewSub.enabled = False
        Dim Cls As Integer = objDerived.GetValue("select classificationID from tbl_classification where classificationid= '" & DrpClass.selectedItem.value & "'", CommandType.Text)
        ClassificationGrd = objDerived.GetDataTable("Select  * from dbo.tbl_classification where  AllotmentClass_id = 3 and Classificationid= '" & Cls & "'order by ClassificationName ", CommandType.Text)
        ddclassNewsub.DataSource = ClassificationGrd
        ddclassNewsub.DatatextField = "ClassificationName"
        ddclassNewsub.DataValueField = "ClassificationId"
        ddclassNewsub.DataBind()

        DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies  where AllotmentClass_Id = 3 order by GA_Title ", CommandType.Text)
        ddGASubClass.DataSource = DrpGenAcc
        ddGASubClass.DataTextField = "GA_title"
        ddGASubClass.DataValueField = "GA_ID"
        ddGASubClass.items.clear()
        ddGASubClass.DataBind()

        SubClassificationGrd = objDerived.GetDataTable("Exec AMS.FMSubClassification '" & ddClassNewSub.SelectedItem.value & "'", CommandType.Text)
        GvSubClass.DataSource = SubClassificationGrd
        GvSubClass.DataBind()




        NewSubClassificationtxt.enabled = True
        ModalPopupExtender7.show()

    End Sub
    Protected Sub ddClassNewSub_SelectedIndexChanged(sender As Object, e As EventArgs)

        'If drpSubClass.text = "" Or drpSubClass.text = "Select" Then

        'DrpGenAcc = objDerived.GetDataTable("Exec [AMS].[FMgetGenAccntNoSubclass]'" & ddClassNewSub.SelectedItem.Value & "','" & 0 & "'", CommandType.Text)
        'ddGASubClass.DataSource = DrpGenAcc
        'ddGASubClass.DataTextField = "GA_title"
        'ddGASubClass.DataValueField = "GA_ID"
        'ddGASubClass.items.clear()
        'ddGASubClass.DataBind()
        DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies where AllotmentClass_ID = 3 order by GA_Title ", CommandType.Text)
        ddGASubClass.DataSource = DrpGenAcc
        ddGASubClass.DataTextField = "GA_title"
        ddGASubClass.DataValueField = "GA_ID"
        ddGASubClass.items.clear()
        ddGASubClass.DataBind()

        'Else

        '    DrpGenAcc = objDerived.GetDataTable("Exec [AMS].[FMgetGenAccnt]'" & ddClassNewSub.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "','" & 0 & "'", CommandType.Text)
        '    ddGASubClass.DataSource = DrpGenAcc
        '    ddGASubClass.DataTextField = "GA_title"
        '    ddGASubClass.DataValueField = "GA_ID"
        '    ddGASubClass.items.clear()
        '    ddGASubClass.DataBind()

        'End If


        SubClassificationGrd = objDerived.GetDataTable("Exec AMS.FMSubClassification '" & ddClassNewSub.SelectedItem.Value & "'", CommandType.Text)
        GvSubClass.DataSource = SubClassificationGrd
        GvSubClass.DataBind()

        ModalPopupExtender7.show()

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
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Classification is already Exist.")
                    Else
                        Me.objDerived.Execute("Insert into dbo.tbl_Classification(ClassificationName,AllotmentClass_id)Values('" & TxtClassification.text & "','3')", CommandType.Text)

                        Dim Matrx = objDerived.GetValue("Select TOP 1 classificationID from dbo.tbl_classification order by ClassificationID desc ", CommandType.Text)

                        Me.objDerived.Execute("Insert into dbo.tblclassmatrix(ClassificationID,SubClassificationID)Values('" & Matrx & "','" & a & "')", CommandType.Text)
                        GvClass.DataSource = objDerived.GetDataTable("Select * from tbl_classification where allotmentClass_ID = 2 order by ClassificationName asc", CommandType.Text)
                        GvClass.DataBind()
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
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
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                        TxtClassification.enabled = False
                        DdSubClassification.enabled = False
                    End If


                End If
            Else
                If DtGrid Is Nothing Then

                    Dim Cls = objDerived.getvalue("select count(*) from tbl_Classification where ClassificationName ='" & TxtClassification.text & "'", CommandType.Text)
                    If Cls <> 0 Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Classification is already Exist.")
                    Else
                        Me.objDerived.Execute("Insert into dbo.tbl_Classification(ClassificationName,AllotmentClass_id)Values('" & TxtClassification.text & "','3')", CommandType.Text)

                        Dim Matrx = objDerived.GetValue("Select TOP 1 classificationID from dbo.tbl_classification order by ClassificationID desc ", CommandType.Text)

                        Me.objDerived.Execute("Insert into dbo.tblclassmatrix(ClassificationID,GA_ID ,SubClassificationID)Values('" & Matrx & "','" & DropGA.SelectedItem.Value & "','" & a & "')", CommandType.Text)
                        GvClass.DataSource = objDerived.GetDataTable("Select * from tbl_classification where allotmentClass_ID = 3 order by ClassificationName asc", CommandType.Text)
                        GvClass.DataBind()
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                        TxtClassification.enabled = False
                        DdSubClassification.enabled = False
                    End If
                Else
                    Dim Gen = objDerived.Getvalue("select count(*) from tblClassmatrix where GA_ID ='" & DropGA.SelectedItem.Value & "' And ClassificationID='" & Session("ClassificationID") & "'And SubClassificationID ='" & a & "'", CommandType.Text)
                    If Gen <> 0 Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected General Account is already Saved.")

                    Else
                        Dim Matrx = objDerived.GetValue("Select TOP 1 classificationID from dbo.tbl_classification order by ClassificationID desc ", CommandType.Text)
                        Me.objDerived.Execute("Insert into dbo.tblclassmatrix(ClassificationID,GA_ID,SubClassificationID)Values('" & Matrx & "','" & DropGA.SelectedItem.Value & "','" & a & "')", CommandType.Text)
                        GvClass.DataSource = objDerived.GetDataTable("Select * from tbl_classification where allotmentClass_ID = 3 order by ClassificationName asc", CommandType.Text)
                        GvClass.DataBind()
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
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

        Modalpopupextender8.show()
    End Sub
    Protected Sub DropGA_SelectedIndexChanged(sender As Object, e As EventArgs)
        Modalpopupextender7.show()
    End Sub
    Protected Sub BtnClearClass_Click(sender As Object, e As EventArgs)
        txtClassification.text = " "

        DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies where AllotmentClass_ID = 3 order by GA_Title ", CommandType.Text)
        DropGA.DataSource = DrpGenAcc
        DropGA.DataTextField = "GA_title"
        DropGA.DataValueField = "GA_ID"


        WithSubClass.Checked = False
        GA.Visible = True
        DropGA.Visible = True
        WSUB.Visible = True
        WithSubClass.Visible = True
        ModalPopupExtender8.Show()
        btnSaveClass.text = "Save"
    End Sub
    Protected Sub BtnSave_SUBCLASS_Click(sender As Object, e As EventArgs)
        If BtnSave_SUBCLASS.text = "SAVE" Then
            Dim DtGrid = objDerived.GetValue("Select SubclassificationID from dbo.tbl_Subclassification where SubClassificationName ='" & NewSubClassificationTxt.text & "'", CommandType.Text)

            Dim SubCls = objDerived.getvalue("select count(*) from tbl_SubClassification where SubClassificationName ='" & NewSubClassificationTxt.text & "'", CommandType.Text)
            If DtGrid = 0 Then
                If SubCls <> 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Sub Classification is already Exist.")
                Else
                    If NewSubClassificationTxt.text = "" Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Sub Classification is Required.")
                    Else
                        Me.objDerived.Execute("Insert into dbo.tbl_SubClassification(SubClassificationName,CLassificationID,GA_ID)Values('" & NewSubClassificationTxt.Text & "','" & ddClassNewSub.SelectedItem.Value & "','" & ddGASubClass.SelectedItem.Value & "')", CommandType.Text)


                        Dim MatrxSub = objDerived.GetValue("Select TOP 1 SubclassificationID from dbo.tbl_Subclassification order by SubClassificationID desc ", CommandType.Text)

                        Me.objDerived.Execute("Insert into dbo.tblclassmatrix(ClassificationID,GA_ID,SubClassificationID)Values('" & ddClassNewSub.SelectedItem.Value & "','" & ddGASubClass.SelectedItem.Value & "','" & MatrxSub & "')", CommandType.Text)


                        Load_GVSubClass()
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                        ddClassNewSub.enabled = False
                        NewSubClassificationTxt.enabled = False
                    End If
                End If
            Else
                Dim SubMat = objDerived.GetValue("Select TOP 1 SubclassificationID from dbo.tbl_Subclassification order by SubClassificationID desc ", CommandType.Text)
                Dim Gen = objDerived.Getvalue("select count(*) from tblClassmatrix where GA_ID ='" & ddGASubClass.SelectedItem.Value & "' And ClassificationID='" & ddClassNewSub.SelectedItem.Value & "'", CommandType.Text)
                If Gen <> 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected General Account is already Saved.")

                Else
                    If NewSubClassificationTxt.text = "" Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Sub Classification is Required.")
                    Else
                        Me.objDerived.Execute("Insert into dbo.tblclassmatrix(ClassificationID,GA_ID,SubClassificationID)Values('" & ddClassNewSub.SelectedItem.Value & "','" & ddGASubClass.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "')", CommandType.Text)
                        Load_GVSubClass()
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                        ddClassNewSub.enabled = False
                        NewSubClassificationTxt.enabled = False
                    End If
                End If
            End If
        Else

            'If Update
            If NewSubClassificationTxt.text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Sub Classification is required.")
            Else

                Dim F As Integer = objDerived.GetValue("Select SubClassificationID from tbl_Subclassification where SubclassificationName ='" & NewSubClassificationTxt.text & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE tbl_Subclassification SET SubClassificationName = '" & NewSubClassificationTxt.text & "' WHERE SubClassificationID = '" & GvSubClass.SelectedDataKey(0) & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE tbl_Subclassification SET GA_ID = '" & ddGASubClass.SelectedItem.Value & "' WHERE GA_ID = '" & GvSubClass.SelectedDatakey(4) & "'", CommandType.Text)



                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                GvClassF = objDerived.GetDataTable("Exec AMS.FMSubClassification '" & ddClassNewSub.SelectedItem.value & "'", CommandType.Text)
                GvClass.DataSource = GvClassF
                GvClass.DataBind()

            End If
        End If

        ModalPopupExtender7.show()
    End Sub
    Protected Sub GvClass_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvClass.PageIndexChanging
        'SubCat = objDerived.GetDataTable("exec [AMS].[FMSuBcategory]'" & ddparticular.selecteditem.value & "'", CommandType.Text)
        Dim a As Integer
        If DdSubClassification.Text = "" Or DdSubClassification.Text = "Select" Then
            a = 0
        Else
            a = DdSubClassification.SelectedItem.value
        End If



        ClassificationGrd = objDerived.GetDataTable("Select * from tbl_classification where AllotmentClass_id = 3 order by ClassificationName asc", CommandType.Text)
        GvClass.PageIndex = e.NewPageIndex
        GvClass.DataSource = CType(ClassificationGrd, DataTable)
        GvClass.DataBind()
        ModalPopupExtender8.Show()
    End Sub
    Protected Sub GvSubClass_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvSubClass.PageIndexChanging
        Session("SubClassificationID") = objDerived.GetValue("Select TOP 1 SubclassificationID from dbo.tbl_Subclassification order by SubClassificationID desc ", CommandType.Text)
        GvSubClassF = objDerived.getDataTable("Exec AMS.FMSubClassification '" & ddClassNewSub.SelectedItem.Value & "'", CommandType.Text)
        GvSubClass.PageIndex = e.NewPageIndex
        GvSubClass.DataSource = CType(GvSubClassF, DataTable)
        GvSubClass.DataBind()
        ModalPopupExtender7.Show()
    End Sub

    Protected Sub Load_GVClass()

        Dim a As Integer
        If DdSubClassification.Text = "" Or DdSubClassification.Text = "Select" Then
            a = 0
        Else
            a = DdSubClassification.SelectedItem.value
        End If


        Session("ClassificationID") = objDerived.GetValue("Select TOP 1 classificationID from dbo.tbl_classification order by ClassificationID desc ", CommandType.Text)
        GvClassF = objDerived.getDataTable("exec [AMS].[sp_FM_GvClass] null,'" & DropGA.SelectedItem.Value & "','" & Session("ClassificationID") & "','" & a & "'", CommandType.Text)
        GvClass.DataSource = GvClassF
        GvClass.DataBind()


    End Sub

    Protected Sub Load_GVSubClass()

        Session("SubClassificationID") = objDerived.GetValue("Select TOP 1 SubclassificationID from dbo.tbl_Subclassification order by SubClassificationID desc ", CommandType.Text)
        GvSubClassF = objDerived.getDataTable("exec [AMS].[sp_FM_GvClass] '" & ddGASubClass.SelectedItem.Value & "','" & ddClassNewSub.selectedItem.Value & "','" & Session("SubClassificationID") & "'", CommandType.Text)
        GvSubClass.DataSource = GvSubClassF
        GvSubClass.DataBind()


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
                txtdescription.text = gvstock.SelectedDatakey("itemdesc")
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

                txtdescription.text = gvstock.SelectedDatakey("itemdesc")
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
            DrpGenAcc = objDerived.GetDataTable(" [AMS].[sp_FM_GvClass] null,'" & DrpClass.SelectedItem.Value & "','" & b & "','" & 0 & "'", CommandType.Text)
            GenAccnt.DataSource = DrpGenAcc
            GenAccnt.DataTextField = "GA_title2"
            GenAccnt.DataValueField = "GA_ID"
            GenAccnt.items.clear()
            GenAccnt.DataBind()
            GenAccnt.Items.Insert(0, "Select")

            Session("CYNow") = "CY" & ddYear.SelectedItem.Text
            Session("CYPrev") = "CY" & ddYear.SelectedItem.Text - 1
            'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & 0 & "','" & drpclass.selectedItem.value & "','" & b & "','" & c & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
            ''pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & GenAccnt.SelectedItem.value & "','" & "0" & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
            'gvstock.DataSource = pstock
            'gvstock.DataBind()
        End If

    End Sub

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


        ModalPopupExtender7.Show()
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


    End Sub

    Protected Sub GvClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        TxtClassification.Text = gvclass.SelectedDataKey("ClassificationName")
        GA.Visible = False
        DropGA.Visible = False
        WSUB.Visible = False
        WithSubClass.Visible = False
        ModalPopupExtender8.Show()
        btnSaveClass.text = "Update"
    End Sub
    Protected Sub GvSubClass_SelectedIndexChanged(sender As Object, e As EventArgs)
        ddClassNewSub.SelectedItem.Text = gvSubclass.SelectedDataKey("ClassificationName")
        NewSubClassificationTxt.text = gvSubclass.SelectedDataKey("SubClassificationName")
        ddGASubClass.SelectedItem.Text = gvSubclass.SelectedDataKey("GA_Title2")
        ModalPopupExtender7.Show()
        BtnSave_SUBCLASS.text = "Update"
    End Sub
    Protected Sub BtnClearSubClass_Click(sender As Object, e As EventArgs)
        NewSubClassificationTxt.text = ""
        ModalPopupExtender7.Show()
        BtnSave_SUBCLASS.text = "Save"
    End Sub

    Protected Sub btnCloseParticular_Click(sender As Object, e As EventArgs)
        txtparticular.text = ""
        txtLife.text = ""

    End Sub

End Class
