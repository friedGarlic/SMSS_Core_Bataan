
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control




Partial Class t_construction
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim particular As New item_particular
    Dim item As New m_item
    Dim item_detail As New m_item_detail
    Dim msg As New MsgeBox
    Dim msg2 As New MsgeBox
    Dim edit As New t_Edit_Transaction
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
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim year As String
        If Not Page.IsPostBack Then
            ddParticular.Enabled = False
            txtItemDesc.Enabled = False
            ddUnit.Enabled = False
            txtprice.Enabled = False

            btnadd.Enabled = False
            btnedit.Enabled = False
            btnsave.Enabled = False

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
                Me.HiddenField1.Value = Me.ddyear.SelectedValue.ToString
                'Previous
                Me.HiddenField2.Value = "CY" & Me.HiddenField1.Value - 1
                'Now
                Me.HiddenField3.Value = "CY" & Me.HiddenField1.Value
                Dim Isexist As New Boolean
                Isexist = IIf(IsDBNull(objDerived.GetValue("select [AMS].[CheckColumnname] (" & Me.ddyear.SelectedValue.ToString & ")", CommandType.Text)), 0, (objDerived.GetValue("select [AMS].[CheckColumnname] (" & Me.ddyear.SelectedValue.ToString & ")", CommandType.Text)))
                If Isexist = False Then
                    objDerived.GetRecords("ALTER TABLE dbo.m_item_detail ADD " & year & " decimal(18,2)", CommandType.Text)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub





    Protected Sub gvstock_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        gvstock.SelectedIndex = -1
        gvstock.PageIndex = e.NewPageIndex
        gvstock.DataSource = CType(pstock, DataTable)
        gvstock.DataBind()
    End Sub

    Protected Sub gvstock_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddUnit.Enabled = False
        txtItemDesc.Text = gvstock.SelectedDataKey(7)
        txtprice.Enabled = False
        txtItemDesc.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = True
        btnsave.Enabled = False
        ddUnit.SelectedItem.Text = gvstock.SelectedDataKey(2)
        ddUnit.SelectedItem.Value = gvstock.SelectedDataKey(6)
        ' txtprice.Text = FormatNumber(gvstock.SelectedDataKey(3), 2)
        txtprice.Text = IIf(IsDBNull(objDerived.GetValue("Select " & Me.HiddenField3.Value & "   from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & " ", CommandType.Text)), 0, objDerived.GetValue("Select " & Me.HiddenField3.Value & "   from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & " ", CommandType.Text))

        Me.Session("oldValueItem") = gvstock.SelectedDataKey(7)
        Me.Session("oldValueUnit") = gvstock.SelectedDataKey(6)
        'Me.Session("oldValuePrice") = CType(FormatNumber(gvstock.SelectedDataKey(3), 2), Decimal)
        Me.Session("oldValuePrice") = CType(IIf(IsDBNull(objDerived.GetValue("Select " & Me.HiddenField3.Value & "   from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & " ", CommandType.Text)), 0, objDerived.GetValue("Select " & Me.HiddenField3.Value & "   from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & " ", CommandType.Text)), Decimal)
    End Sub



    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        ddParticular.Enabled = True
        txtItemDesc.Enabled = True
        txtprice.Enabled = True


        txtItemDesc.Text = ""
        txtprice.Text = "0.00"
        txtItemDesc.Focus()


        ddUnit.Enabled = True
        btnadd.Enabled = True
        btnedit.Enabled = False
        btnsave.Enabled = True

        Session("save") = "New"

    End Sub

    Protected Sub btnedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnedit.Click
        ddUnit.Enabled = True
        txtprice.Enabled = True
        txtItemDesc.Enabled = True

        txtItemDesc.Focus()

        btnadd.Enabled = False
        btnedit.Enabled = True
        btnsave.Enabled = True

        Session("save") = "Edit"
    End Sub

    Protected Sub txtprice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprice.TextChanged
        txtprice.Text = FormatNumber(CType(txtprice.Text, Decimal), 2)
    End Sub


    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            Me.gvstock.DataSource = objDerived.Search(pstock, "item_desc", txtsearch2.Text)
            Me.gvstock.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Public Function verify() As Boolean
        Dim myview As DataView
        ' added 10/7/2013
        pstock = objDerived.GetDataTable("exec  ams.FM_Stocks '" & 0 & "','" & 0 & "'," & Me.HiddenField2.Value & "," & Me.HiddenField3.Value & "", CommandType.Text)
        myview = CType(pstock, DataTable).DefaultView
        myview.RowFilter = "Item_Desc ='" & objDerived.replaceapostrophe(txtItemDesc.Text) & "'  and Unit_ID=" & ddUnit.SelectedItem.Value & ""
        If btnadd.Enabled = False Then
            Return False
        End If
        If myview.Count <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function verify2() As Boolean
        Dim myview As DataView
        ' added 10 / 7 /2013
        pstock = objDerived.GetDataTable("exec  ams.FM_Stocks '" & 0 & "','" & 0 & "'," & Me.HiddenField2.Value & "," & Me.HiddenField3.Value & "", CommandType.Text)
        myview = CType(pstock, DataTable).DefaultView
        myview.RowFilter = "Item_Desc ='" & objDerived.replaceapostrophe(txtItemDesc.Text) & "'  and Unit_ID <> " & ddUnit.SelectedItem.Value & ""

        If myview.Count <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub txtItemDesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemDesc.TextChanged
        ddUnit.Focus()
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try


            'objDerived.GetRecords("Update ams.item_particular set description='" & txtItemDesc.Text & "' where item_particular_id=" & gvstock.SelectedDataKey(5) & "", CommandType.Text)
            If Me.Session("oldValueItem").ToString <> txtItemDesc.Text.ToString Then
                objDerived.GetRecords("Update dbo.m_item set Item_Desc='" & objDerived.replaceapostrophe(txtItemDesc.Text) & "',detail='' where Item_ID=" & gvstock.SelectedDataKey(4) & "", CommandType.Text)
                edit.PrimaryColumnName = "Item_ID"
                edit.TransactionID = gvstock.SelectedDataKey(4)
                edit.TableName = "dbo.m_item"
                edit.ColumnName = "Item_Desc"
                edit.TransactionDate = DateTime.Now
                edit.NewValue = txtItemDesc.Text
                edit.OldValue = Me.Session("oldValueItem").ToString
                edit.UserID = Me.Session("@UserID")
                edit.UserName2 = Me.Session("@UserName")
                edit.Remarks = txtremarks.Text
                edit.save()

            End If
            If Me.Session("oldValueUnit") <> ddUnit.SelectedItem.Value Then
                objDerived.GetRecords("Update dbo.m_item set Unit_ID='" & ddUnit.SelectedItem.Value & "' where Item_ID=" & gvstock.SelectedDataKey(4) & "", CommandType.Text)
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
            End If
            If CType(Me.Session("oldValuePrice"), Decimal) <> CType(txtprice.Text, Decimal) Then
                'objDerived.GetRecords("Update dbo.m_item_detail set price='" & CType(txtprice.Text, Decimal) & "',userId='" & Me.Session("@UserName") & "' where Item_ID=" & gvstock.SelectedDataKey(4) & "", CommandType.Text)
                objDerived.GetRecords("Update dbo.m_item_detail set " & Me.HiddenField3.Value & "='" & CType(txtprice.Text, Decimal) & "',userId='" & Me.Session("@UserName") & "' where Item_ID=" & gvstock.SelectedDataKey(4) & "", CommandType.Text)


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
            End If
            pstock = objDerived.GetDataTable("exec  ams.FM_Stocks '" & 0 & "','" & 0 & "'," & Me.HiddenField2.Value & "," & Me.HiddenField3.Value & "", CommandType.Text)
            gvstock.DataSource = pstock
            gvstock.DataBind()
            ddUnit.Enabled = False
            txtprice.Enabled = False
            txtItemDesc.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = False
            btnsave.Enabled = False
            gvstock.SelectedIndex = -1
            txtremarks.Text = ""
            msg.UserMsgBox("Transaction has been succesfully saved", Me, False)
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddyear.SelectedIndexChanged
        Dim stocks As Boolean
        stocks = False

        btnAddP.Enabled = True

        'pCode = objDerived.GetDataTable("SELECT     StockCode as accntg_code, Description FROM         AMS.m_Stock", CommandType.Text)
        Me.gvstock.Columns(3).HeaderText = "Price" & Me.HiddenField1.Value - 1
        Me.gvstock.Columns(4).HeaderText = "Price" & Me.HiddenField1.Value

        ddParticular.Enabled = True
        Dim pParticular As New DataTable
        ddParticular.DataSource = Nothing
        ddParticular.DataBind()

        'pParticular = objDerived.GetDataTable("SELECT  * FROM dbo.view_ConstructionMaterials_Particular", CommandType.Text)

        pParticular = objDerived.GetDataTable("SELECT  * FROM dbo.view_ConstructionParticular order by  particular", CommandType.Text)
        ddParticular.DataSource = pParticular
        ddParticular.DataTextField = ("particular")
        ddParticular.DataValueField = ("item_particular_id")
        ddParticular.DataBind()
        ddParticular.Items.Insert(0, "Select")


        ddUnit.DataSource = Nothing
        ddUnit.DataBind()
        ddUnit.DataSource = objDerived.GetRecords("exec [AMS].[loadunit]", CommandType.Text)
        ddUnit.DataTextField = "description"
        ddUnit.DataValueField = "Unit_ID"
        ddUnit.DataBind()
        txtprice.Attributes.Add("OnFocus", "this.select()")
        pParticular = Nothing
        pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & 0 & "','" & 0 & "'", CommandType.Text)


        ddUnit.Enabled = False
        txtprice.Enabled = False
        txtItemDesc.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = False
        btnsave.Enabled = False
        txtprice.Text = "0.00"

        Session("CYNow") = "CY" & Me.ddyear.SelectedValue.ToString
        Session("CYPrev") = "CY" & Me.ddyear.SelectedValue.ToString - 1

        'pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & 541 & "','" & 0 & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
        'gvstock.DataSource = pstock
        'gvstock.DataBind()

        'pstock = objDerived.GetDataTable("exec  ams.FM_Stocks '" & 541 & "','" & 0 & "','" & Session("CYPrev") & "','" & Session("CYNow") & "'", CommandType.Text)
        'gvstock.DataSource = pstock
        'gvstock.DataBind()


    End Sub

    Protected Sub ddUnit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddUnit.SelectedIndexChanged
        Session("unit") = ddUnit.SelectedItem.Value

        If ddUnit.SelectedValue.ToString = 0 Then
            Me.ddyear.Enabled = False
        Else
            Me.ddyear.Enabled = True
        End If
    End Sub

    Protected Sub bntcopyPerGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntcopyPerGrid.Click
        For Each row As GridViewRow In Me.gvstock.Rows
            Dim therowindex As Integer = row.RowIndex
            Dim theid As Integer
            Dim aa, bb
            aa = Me.HiddenField3.Value
            bb = HiddenField2.Value
            theid = gvstock.DataKeys(therowindex)(4).ToString
            '" & Me.HiddenField2.Value & " like 'CY2012' and  gvstock.DataKeys(therowindex)(3).ToStrin
            '  objDerived.GetRecords("update dbo.m_item_detail set " & Me.HiddenField3.Value & " = case when  " & Me.HiddenField2.Value & "  is null  then " & gvstock.DataKeys(therowindex)(9).ToString & " else " & gvstock.DataKeys(therowindex)(3).ToString & " end   where Item_ID=" & gvstock.DataKeys(therowindex)(4).ToString & " and " & Me.HiddenField3.Value & " is null ", CommandType.Text)
            objDerived.GetRecords("update dbo.m_item_detail set " & Me.HiddenField3.Value & " = case when  " & Me.HiddenField2.Value & "  is null  then isnull(" & gvstock.DataKeys(therowindex)(9).ToString & ",'0.00') else isnull(" & gvstock.DataKeys(therowindex)(3).ToString & ",'0.00') end   where Item_ID=" & gvstock.DataKeys(therowindex)(4).ToString & " and " & Me.HiddenField3.Value & " is null or " & Me.HiddenField3.Value & "='0.00' ", CommandType.Text)

        Next
        pstock = objDerived.GetDataTable("exec   ams.FM_Stocks '0','0','" & Me.HiddenField2.Value & "' , '" & Me.HiddenField3.Value & "'", CommandType.Text)
        gvstock.DataSource = pstock
        gvstock.DataBind()
    End Sub

    Protected Sub btncopyall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncopyall.Click
        Try

            Me.objDerived.GetRecords("update dbo.m_item_detail set " & Me.HiddenField3.Value & "=case when  " & Me.HiddenField2.Value & " is null  then  price else " & Me.HiddenField2.Value & "  end from dbo.m_item inner join  dbo.m_item_detail on  dbo.m_item.item_id = dbo.m_item_detail.item_id inner join  ams.item_particular on   dbo.m_item.Item_particular_id = ams.item_particular.Item_particular_id where ams.item_particular.ga_id='0' and ams.item_particular.bga_id='0' and " & Me.HiddenField3.Value & " is null ", CommandType.Text)
        Catch ex As Exception
        End Try

        pstock = objDerived.GetDataTable("exec   ams.FM_Stocks '0','0','" & Me.HiddenField2.Value & "' , '" & Me.HiddenField3.Value & "'", CommandType.Text)
        gvstock.DataSource = pstock
        gvstock.DataBind()
    End Sub


    Protected Sub btnAddP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ddParticular.SelectedItem.Text = "Select"
        txtItemDesc.Text = ""
        txtprice.Text = 0.0
        ddUnit.SelectedItem.Text = "Select"

        ModalPopupExtender2.Show()

        Dim dtparticular As New DataTable
        dtparticular = objDerived.GetDataTable("SELECT  * FROM AMS.item_particular WHERE GA_ID = 541 order by  item_particular_id desc", CommandType.Text)
        If dtparticular.Rows.Count = 0 Then
            gvparticular.DataSource = createdatatable1(5)
            gvparticular.DataBind()
        Else
            If dtparticular.Rows.Count < 5 Then
                dtparticular.Merge(createdatatable1(5 - dtparticular.Rows.Count))
            End If
            gvparticular.DataSource = dtparticular
            gvparticular.DataBind()

        End If
    End Sub

    Protected Sub gvparticular_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        ModalPopupExtender2.Show()

        Dim dtparticular As New DataTable
        dtparticular = objDerived.GetDataTable("SELECT  * FROM AMS.item_particular WHERE GA_ID = 541 order by description", CommandType.Text)
        If dtparticular.Rows.Count < 5 Then
            dtparticular.Merge(createdatatable1(5 - dtparticular.Rows.Count))
        End If
        gvparticular.PageIndex = e.NewPageIndex
        gvparticular.DataSource = dtparticular
        gvparticular.DataBind()
    End Sub

    Protected Sub ddParticular_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'btnAddP.Enabled = False
        LoadStock()
    End Sub
    Protected Sub LoadStock()
        'Dim dtStock As New DataTable
        'dtStock = objDerived.GetDataTable("SELECT  * FROM dbo.view_ConstructionMaterials_Particular  where item_particular_id ='" & ddParticular.SelectedItem.Value & "'", CommandType.Text)
        'If dtStock.Rows.Count = 0 Then
        '    gvstock.DataSource = createdatatable2(5)
        '    gvstock.DataBind()
        'Else
        '    If dtStock.Rows.Count < 5 Then
        '        dtStock.Merge(createdatatable2(5 - dtStock.Rows.Count))
        '    End If
        '    gvstock.DataSource = dtStock
        '    gvstock.DataBind()

        'End If

        pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & 541 & "','" & 0 & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
        gvstock.DataSource = pstock
        gvstock.DataBind()
    End Sub
    Protected Sub gvstock_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtStock As New DataTable
        dtStock = objDerived.GetDataTable("SELECT  * FROM dbo.view_ConstructionMaterials_Particular  where item_particular_id ='" & ddParticular.SelectedItem.Value & "'", CommandType.Text)
        If dtStock.Rows.Count = 0 Then
            gvstock.DataSource = createdatatable2(5)
            gvstock.DataBind()
        Else
            If dtStock.Rows.Count < 5 Then
                dtStock.Merge(createdatatable2(5 - dtStock.Rows.Count))
            End If
            gvstock.PageIndex = e.NewPageIndex
            gvstock.DataSource = dtStock
            gvstock.DataBind()

        End If
    End Sub
    Protected Sub gvstock_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        txtItemDesc.Text = gvstock.SelectedDataKey("Item_Desc")
        ddUnit.SelectedItem.Text = gvstock.SelectedDataKey("unit")
        ddUnit.SelectedItem.Value = gvstock.SelectedDataKey("Unit_ID")
        txtprice.Text = gvstock.SelectedDataKey("price")


        btnedit.Enabled = True
        btnsave.Enabled = True
        btnadd.Enabled = False
    End Sub
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("description", GetType(String))
        dt.Columns.Add("useful_life", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("description") = DBNull.Value
            dr("useful_life") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("unit", GetType(String))
        dt.Columns.Add("price", GetType(Decimal))
        dt.Columns.Add("item_particular_id", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Unit_ID", GetType(Integer))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("unit") = DBNull.Value
            dr("price") = DBNull.Value
            dr("item_particular_id") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("Unit_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles btnsave.Click
        If Session("save") = "Edit" Then
            objDerived.GetDataTable("Update dbo.m_item set Item_Desc = '" & txtItemDesc.Text & "' where Item_ID ='" & gvstock.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            objDerived.GetDataTable("Update  dbo.m_item_detail set price = '" & txtprice.Text & "'," & Session("CYNow") & " ='" & txtprice.Text & "' where Item_ID ='" & gvstock.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            objDerived.GetDataTable("Update dbo.m_item  set unit_id = '" & Session("unit") & "' where Item_ID ='" & gvstock.SelectedDataKey("Item_ID") & "'", CommandType.Text)

            'msg.UserMsgBox("Update has been succesfully saved", Me, False)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanelCons, "Item has been successfully updated.")
        ElseIf Session("save") = "New" Then

            '=== SAVE Item_Desc ===
            item.Item_Desc = txtItemDesc.Text
            item.Unit_ID = ddUnit.SelectedValue
            item.item_particular_id = ddParticular.SelectedItem.Value
            item.isAll = True
            item.detail = ""

            Dim id As Long = item.save

            Me.objDerived.Execute("insert into dbo.m_item_detail(Item_ID,price," & Me.HiddenField3.Value & ",UserId) values(" & id & ",'" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & Me.Session("@UserName") & "') ", CommandType.Text)

        ElseIf Session("save") = "xxx" Then
            Try
                If btnadd.Enabled = True Then
                    Dim particularID As Long
                    ''----------------------------------
                    Dim myview As DataView
                    ' added 10 /7 /2013
                    pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & 0 & "','" & 0 & "'", CommandType.Text)
                    myview = CType(pParticular, DataTable).DefaultView
                    Dim str As String = txtItemDesc.Text.Trim
                    myview.RowFilter = "description ='" & objDerived.replaceapostrophe(str) & "'"
                    Me.Session("viewcount") = myview.Count
                    ' If myview.Count = 0 Then
                    particular.item_particular_id = ddParticular.SelectedItem.Value
                    particular.description = ddParticular.SelectedItem.Text
                    particular.GA_ID = 541
                    particular.useful_life = txtLife.Text
                    particular.BGA_ID = 0
                    particularID = particular.save()

                    ''--------------------------------
                    If verify() = False Then
                        If verify2() = True Then
                            msg2.UserMsgBox("This data is similar to an existing data but different in Unit.", Me, False)
                        End If
                        item.Item_Desc = txtItemDesc.Text
                        item.Unit_ID = ddUnit.SelectedValue
                        item.item_particular_id = particularID
                        item.isAll = True
                        item.detail = ""
                        Dim id As Long = item.save

                        'item_detail.Item_ID = id
                        'item_detail.UserId = Me.Session("@UserName")
                        'item_detail.price = txtprice.Text
                        'item_detail.save()

                        Me.objDerived.Execute("insert into dbo.m_item_detail(Item_ID,price," & Me.HiddenField3.Value & ",UserId) values(" & id & ",'" & CType(txtprice.Text, Decimal) & "','" & CType(txtprice.Text, Decimal) & "', '" & Me.Session("@UserName") & "') ", CommandType.Text)

                    Else
                        msg2.UserMsgBox("Record already existing", Me, False)
                        Exit Sub
                    End If
                Else
                    ModalPopupExtender1.Show()
                    Exit Sub
                    'objDerived.GetRecords("Update dbo.m_item_detail set price='" & CType(txtprice.Text, Decimal) & "',userId='" & Me.Session("@UserName") & "' where Item_ID=" & gvstock.SelectedDataKey(4) & "", CommandType.Text)
                    ' objDerived.GetRecords("Update dbo.m_item set Item_Desc='" & objDerived.replaceapostrophe(txtItemDesc.Text) & "',detail='' where Item_ID=" & gvstock.SelectedDataKey(4) & "", CommandType.Text)
                    ''objDerived.GetRecords("Update ams.item_particular set description='" & txtItemDesc.Text & "' where item_particular_id=" & gvstock.SelectedDataKey(5) & "", CommandType.Text)
                End If
                'pstock = objDerived.GetDataTable("exec  ams.FM_Stocks '" & 0 & "','" & 0 & "'," & Me.HiddenField2.Value & "," & Me.HiddenField3.Value & "", CommandType.Text)
                'gvstock.DataSource = pstock
                'gvstock.DataBind()

                'ddUnit.Enabled = False
                'txtprice.Enabled = False
                'txtItemDesc.Enabled = False

                'btnadd.Enabled = True
                'btnedit.Enabled = False
                'btnsave.Enabled = False
                'gvstock.SelectedIndex = -1
                msg.UserMsgBox("Transaction has been succesfully saved", Me, False)

            Catch ex As Exception
                msg.UserMsgBox(ex.ToString, Me, False)
            End Try
        End If

        LoadStock()

        ddUnit.Enabled = False
        txtprice.Enabled = False
        txtItemDesc.Enabled = False

        btnadd.Enabled = True
        btnedit.Enabled = False
        btnsave.Enabled = False
        ' lblsaving.Visible = True
    End Sub

    Protected Sub btnaddparticular_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtParticularDesc.Enabled = True
        btnsaveparticular.Enabled = True
        btnaddparticular.Enabled = False
        txtLife.Enabled = True
        txtParticularDesc.ReadOnly = False
        txtLife.ReadOnly = False
        txtParticularDesc.Text = ""
        txtLife.Text = 0
        ModalPopupExtender2.Show()

    End Sub
    Protected Sub btnsaveparticular_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim myview As DataView
        pParticular = objDerived.GetDataTable("exec ams.FMparticularsSupplies '" & 0 & "','" & 0 & "'", CommandType.Text)
        myview = CType(pParticular, DataTable).DefaultView

        Dim str As String = txtItemDesc.Text.Trim
        myview.RowFilter = "description ='" & objDerived.replaceapostrophe(str) & "'"
        Me.Session("viewcount") = myview.Count

        'particular.item_particular_id = ""
        'particular.description = txtParticularDesc.Text
        'particular.GA_ID = 541
        'particular.useful_life = 0
        'particular.BGA_ID = 0
        'particularID = particular.save()

        '=== SAVE Particular ===
        particular.description = txtParticularDesc.Text 'ddParticular.SelectedItem.Text
        particular.GA_ID = 541
        particular.useful_life = txtLife.Text
        particular.BGA_ID = 0

        Dim particularID As Long = particular.save()

        Dim dtparticular As New DataTable
        dtparticular = objDerived.GetDataTable("SELECT  * FROM AMS.item_particular WHERE GA_ID = 541 order by  item_particular_id desc", CommandType.Text)
        If dtparticular.Rows.Count = 0 Then
            gvparticular.DataSource = createdatatable1(5)
            gvparticular.DataBind()
        Else
            If dtparticular.Rows.Count < 5 Then
                dtparticular.Merge(createdatatable1(5 - dtparticular.Rows.Count))
            End If
            gvparticular.DataSource = dtparticular
            gvparticular.DataBind()

        End If

        pParticular = objDerived.GetDataTable("SELECT  * FROM dbo.view_ConstructionParticular order by  particular", CommandType.Text)
        ddParticular.DataSource = pParticular
        ddParticular.DataTextField = ("particular")
        ddParticular.DataValueField = ("item_particular_id")
        ddParticular.DataBind()
        ddParticular.Items.Insert(0, "Select")

        btnaddparticular.Enabled = True
        btnsaveparticular.Enabled = False

        txtParticularDesc.ReadOnly = True
        txtLife.ReadOnly = True
        ModalPopupExtender2.Show()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chk As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(chk.NamingContainer, GridViewRow)
        objDerived.GetRecords("Update dbo.m_Item set isUsed = '" & chk.Checked & "' where item_id = " & Me.gvstock.DataKeys(gvr.RowIndex).Item(4), CommandType.Text)

        If chk.Checked = True Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanelCons, "Selected items has been successfully hidden.")
        ElseIf chk.Checked = False Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanelCons, "Selected items has been successfully visible.")
        End If
    End Sub

    Protected Sub gvstock_SelectedIndexChanged2(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim Active As String
        'Active = IIf(IsDBNull(objDerived.GetValue("select isused from dbo.m_item where dbo.m_item.Item_id=" & Me.gvstock.SelectedDataKey(4) & "  ", CommandType.Text)), 0, objDerived.GetValue("select isused from dbo.m_item where dbo.m_item.Item_id=" & Me.gvstock.SelectedDataKey(4) & " ", CommandType.Text))
        'If Active = "True" Then
        '    Me.chkInactive.Checked = True
        'Else
        '    Me.chkInactive.Checked = False
        'End If

        'added 1/22/2013
        ddUnit.Enabled = False
        txtItemDesc.Text = gvstock.SelectedDataKey(7)
        ddParticular.SelectedValue = gvstock.SelectedDataKey(5)
        txtprice.Enabled = False
        txtItemDesc.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = True
        btnsave.Enabled = False
        Me.btncopyall.Enabled = True
        'old 

        ddUnit.SelectedItem.Text = gvstock.SelectedDataKey(2)
        ddUnit.SelectedItem.Value = gvstock.SelectedDataKey(6)
        Session("unit") = gvstock.SelectedDataKey(6)
        'new 09042013
        Me.txtItemDesc.Text = Me.gvstock.SelectedDataKey(7)
        ddUnit.SelectedItem.Text = gvstock.SelectedDataKey(2)
        ddUnit.SelectedItem.Value = gvstock.SelectedDataKey(2)
        Me.HiddenField3.Value = "CY" & Me.ddyear.SelectedValue.ToString
        Dim Prevyear
        Prevyear = "CY" & Me.ddyear.SelectedValue.ToString - 1
        'Session("CYNow") = "CY" & Me.ddyear.SelectedValue.ToString
        'Session("CYPrev") = "CY" & Me.ddyear.SelectedValue.ToString - 1
        txtprice.Text = IIf(IsDBNull(objDerived.GetValue("Select " & Me.HiddenField3.Value & "   from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & " ", CommandType.Text)), 0, objDerived.GetValue("Select " & Me.HiddenField3.Value & "   from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & " ", CommandType.Text))
        ' txtprice.Text = FormatNumber(gvstock.SelectedDataKey(3), 2)
        Me.Session("oldValueItem") = gvstock.SelectedDataKey(7)
        Me.Session("oldValueUnit") = gvstock.SelectedDataKey(2) 'gvstock.SelectedDataKey(6)
        ' Me.Session("oldValuePrice") = CType(FormatNumber(gvstock.SelectedDataKey(3), 2), Decimal)
        ' Me.Session("oldValuePrice") = IIf(IsDBNull(objDerived.GetValue("Select  case when  " & Me.HiddenField3.Value & " is null then price else isnull(" & Me.HiddenField3.Value & "," & Prevyear & ") end  from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & " ", CommandType.Text)), 0, objDerived.GetValue("Select  case when  " & Me.HiddenField3.Value & "  is null then price else isnull(" & Me.HiddenField3.Value & "," & Prevyear & ") end  from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & "", CommandType.Text))
        Dim currentYear
        currentYear = "CY" & Me.ddyear.SelectedValue.ToString
        Me.Session("oldValuePrice") = IIf(IsDBNull(objDerived.GetValue("Select  case when  " & currentYear & " is null then isnull(" & Prevyear & ", price) else isnull(" & currentYear & "," & Prevyear & ") end  from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & " ", CommandType.Text)), 0, objDerived.GetValue("Select  case when  " & currentYear & " is null then isnull(" & Prevyear & ", price) else isnull(" & currentYear & "," & Prevyear & ") end  from dbo.m_item_detail where Item_id=" & gvstock.SelectedDataKey(4) & " ", CommandType.Text))
        Me.Session("Item_id") = Me.gvstock.SelectedDataKey(4)
        Session("action") = "Edit"
    End Sub

    Protected Sub gvstock_PageIndexChanging2(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pstock = objDerived.GetDataTable("exec [AMS].[FM_Stocks_perParticular] '" & 541 & "','" & 0 & "','" & Session("CYPrev") & "' , '" & Session("CYNow") & "','" & ddParticular.SelectedValue & "'", CommandType.Text)
        gvstock.DataSource = pstock
        gvstock.DataBind()
    End Sub
End Class
