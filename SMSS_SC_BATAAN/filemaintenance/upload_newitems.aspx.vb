
Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.Text
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices



Partial Class filemaintenance_upload_newitems
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule
    Dim exMsg As MsgeBox
    Dim item_detail As New m_item_detail

    Public Function CreateDataTable_Items(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mycolumn As New DataColumn
        dt.Columns.Add("Particular", GetType(String))
        dt.Columns.Add("SubCat_Desc", GetType(String))
        dt.Columns.Add("Item_Code", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("UnitDesc", GetType(String))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("Useful_Life", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Particular") = DBNull.Value
            dr("SubCat_Desc") = DBNull.Value
            dr("Item_Code") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("UnitDesc") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("Useful_Life") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Private Property dtItemList() As DataTable
        Get
            Return CType(Session("dtItemList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItemList") = value
        End Set
    End Property
    Private Property dtGenAccounts() As DataTable
        Get
            Return CType(Session("dtGenAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtGenAccounts") = value
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
    Private Property DrpSubClassF() As DataTable
        Get
            Return CType(Session("DrpSubClassF"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("DrpSubClassF") = value
        End Set
    End Property
    Private Sub filemaintenance_upload_newitems_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'obj.GetAccessRight(Me.Session("@UserName"), Page)
            'If obj.HasAccess = False Then
            '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
            'End If

            drpYear.DataSource = objDerived.GetDataTable("SELECT year FROM AMS.APP ORDER BY year DESC", CommandType.Text)
            drpYear.DataTextField = "year"
            drpYear.DataValueField = "year"
            drpYear.DataBind()

            dtGenAccounts = objDerived.GetDataTable("SELECT GA_ID, BGA_ID, GA_Code2, '(' + GA_Code2 + ') ' + GA_Title AS GenAccount, GA_Title FROM AMS.View_AccountList WHERE AllotmentClass_ID = 2  ORDER BY GA_Title", CommandType.Text)
            drpGenAccount.DataSource = dtGenAccounts
            drpGenAccount.DataTextField = "GenAccount"
            drpGenAccount.DataValueField = "GA_ID"
            drpGenAccount.DataBind()
            drpGenAccount.Items.Insert(0, "Select")

            grdItems.DataSource = CreateDataTable_Items(5)
            grdItems.DataBind()

        End If
    End Sub
    Private Sub drpAllotment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpAllotment.SelectedIndexChanged
        dtGenAccounts = objDerived.GetDataTable("SELECT GA_ID, BGA_ID, GA_Code2, '(' + GA_Code2 + ') ' + GA_Title AS GenAccount, GA_Title FROM AMS.View_AccountList WHERE AllotmentClass_ID = '" & drpAllotment.SelectedItem.Value & "' ORDER BY GA_Title", CommandType.Text)
        drpGenAccount.DataSource = dtGenAccounts
        drpGenAccount.DataTextField = "GenAccount"
        drpGenAccount.DataValueField = "GA_ID"
        drpGenAccount.DataBind()
        drpGenAccount.Items.Insert(0, "Select")
        DropdownClassification()
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        ' Try

        If FileUpload1.HasFile Then

            'grdItems.DataSource = Nothing
            'grdItems.DataBind()

            Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
            Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")

            Dim FilePath As String = Server.MapPath(FolderPath + FileName)
            FileUpload1.SaveAs(FilePath)
            Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)

        Else

        End If

        'Catch ex As Exception
        '    Dim x As String
        '    x = "ssssssssssssssss"
        'End Try

    End Sub

    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)
        Dim conStr As String = ""
        Select Case Extension
            Case ".xls"
                'Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
                Exit Select
            Case ".xlsx"
                'Excel 07
                conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString
                Exit Select
        End Select
        conStr = String.Format(conStr, FilePath, isHDR)

        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        Dim dt As New DataTable()

        cmdExcel.Connection = connExcel

        'Get the name of First Sheet
        connExcel.Open()
        Dim dtExcelSchema As DataTable
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
        connExcel.Close()

        'Read Data from First Sheet
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        connExcel.Close()

        'Bind Data to GridView
        grdItems.Caption = Path.GetFileName(FilePath)
        grdItems.DataSource = dt
        grdItems.DataBind()

        dtItemList = dt

    End Sub


    Private Sub grdItems_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdItems.PageIndexChanging
        Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
        Dim FileName As String = grdItems.Caption
        Dim Extension As String = Path.GetExtension(FileName)
        Dim FilePath As String = Server.MapPath(FolderPath + FileName)

        Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)
        grdItems.PageIndex = e.NewPageIndex
        grdItems.DataBind()

    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Try
        If drpGenAccount.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select general account.")

        ElseIf dtItemList.Rows.Count = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No items found.")
        Else
            Dim ULife As Integer = 0
            If drpAllotment.SelectedItem.Value = 3 Then
                ULife = 5
            End If

            Dim CYear As String = "CY" & drpYear.SelectedValue.ToString

            For i As Integer = 0 To dtItemList.Rows.Count - 1
                If dtItemList.Rows(i)("Item_Desc") = "" Then
                    Exit For

                Else
                    '== CHECK IF PARTICULAR IS EXISTING , SAVE PARTICULAR
                    Dim GA_ID As Integer = dtGenAccounts.Rows(drpGenAccount.SelectedIndex - 1)("GA_ID")
                    Session("GAID") = GA_ID
                    Dim BGA_ID As Integer = dtGenAccounts.Rows(drpGenAccount.SelectedIndex - 1)("BGA_ID")
                    Session("BGAID") = BGA_ID
                    Dim ParticularID As Integer = objDerived.GetValue("SELECT item_particular_id FROM [AMS].[item_particular] WHERE description = '" & dtItemList.Rows(i)("Particular").ToString().Replace("'", "''") & "' AND GA_ID = '" & GA_ID & "' AND BGA_ID = '" & BGA_ID & "'", CommandType.Text)
                    Dim ParticularID2 As Integer = objDerived.GetValue("SELECT item_particular_id FROM [AMS].[item_particular] WHERE description = '" & dtItemList.Rows(i)("Particular").ToString().Replace("'", "''") & "' AND GA_ID = '" & GA_ID & "' AND BGA_ID = '" & BGA_ID & "'", CommandType.Text)
                    If ParticularID = 0 Then
                        objDerived.Execute("INSERT INTO [AMS].[item_particular] ([description],[GA_ID],[useful_life],[BGA_ID]) " &
                            " VALUES ('" & dtItemList.Rows(i)("Particular").ToString().Replace("'", "''") & "','" & Session("GAID") & "','" & ULife & "','" & Session("BGAID") & "')", CommandType.Text)

                        ParticularID = objDerived.GetValue("SELECT TOP(1) item_particular_id FROM [AMS].[item_particular] ORDER BY item_particular_id DESC", CommandType.Text)

                    End If
                    Dim subclassF As String
                    If DdSubClassF.SelectedValue = 0 Or DdSubClassF.text = "Select" Or DdSubClassF.text = "" Then
                        subclassF = 0
                        Session("SubClassF") = subclassF
                    Else
                        subclassF = DdSubClassF.SelectedValue
                        Session("SubClassF") = subclassF
                    End If

                    '== Sub_CATEGORY SAVING
                    Dim SubCatID As Integer = objDerived.Execute("Select SubCategoryID from dbo.tbl_SubCategory where SubCat_desc='" & dtItemList.Rows(i)("Subcat_Desc").ToString().Replace("'", "''") & "'and Item_particular_id ='" & ParticularID2 & "'And ClassificationID='" & DdClassF.SelectedValue & "'And SubClassification_ID ='" & Session("SubClassF") & "'and GA_ID = '" & Session("GAID") & "'", CommandType.Text)
                    Session("SubCategoryID") = SubCatID
                    If SubCatID <> 0 Then
                        objDerived.Execute("Insert into dbo.tbl_SubCategory (Subcat_desc,Item_particular_id,ClassificationID,useful_life,Subclassification_ID,GA_ID  VALUES " &
                                                                                         " ('" & dtItemList.Rows(i)("Subcat_Desc").ToString().Replace("'", "''") & "','" & ParticularID2 & "','" & DdClassF.SelectedValue & "', '" & Session("SubClassF") & "','" & Session("GAID") & "') ", CommandType.Text)

                    End If
                    If SubCatID = 0 Then
                        SubCatID = 0
                    Else
                        SubCatID = SubCatID
                    End If
                    '== CHECK AND SAVE ITEM UNIT
                    Dim UnitID As Integer
                    If dtItemList.Rows(i)("UnitDesc") = "" Then
                        UnitID = 1
                    Else
                        UnitID = objDerived.GetValue("SELECT TOP(1) Unit_ID FROM AMS.m_Unit WHERE Description LIKE '" & dtItemList.Rows(i)("UnitDesc") & "'", CommandType.Text)
                        If UnitID = 0 Then
                            objDerived.Execute("INSERT INTO [AMS].[m_Unit] ([Unit_hdr_id],[Description],[Unit_hdr_id2],[value]) VALUES (0,'" & dtItemList.Rows(i)("UnitDesc") & "',0,1)", CommandType.Text)

                            UnitID = objDerived.GetValue("SELECT TOP(1) Unit_ID FROM AMS.m_Unit ORDER BY Unit_ID DESC", CommandType.Text)

                        End If
                    End If


                    Dim G As String = dtItemList.Rows(i)("Item_Desc")
                    Dim unit As String = objDerived.GetValue("SELECT TOP(1) UNIT_ID FROM  ams.m_Unit   WHERE Description like '%" & dtItemList.Rows(i)("UnitDesc") & "%'", CommandType.Text)
                    Dim unitdsc As String = objDerived.GetValue("SELECT TOP(1) Description FROM ams.m_unit WHERE UNIT_ID ='" & unit & "'", CommandType.Text)
                    Dim Item_ID As Integer
                    Item_ID = objDerived.GetValue("SELECT TOP(1) Item_ID FROM DBO.m_item WHERE ITEM_DESC ='" & dtItemList.Rows(i)("Item_Desc").ToString().Replace("'", "''") & "' and unit_id='" & unit & "' and Item_code='" & dtItemList.Rows(i)("Item_Code").ToString().Replace("'", "''") & "' ORDER BY Item_ID DESC", CommandType.Text)

                    Dim Item_detail_ID As Integer
                    Item_detail_ID = objDerived.GetValue("SELECT count(Item_ID) as count FROM DBO.m_item_detail WHERE ITEM_ID ='" & Item_ID & "'", CommandType.Text)

                    Dim CategoryID As Integer = objDerived.GetValue("Select Item_particular_id from ams.Item_particular where description ='" & dtItemList.Rows(i)("Particular").ToString().Replace("'", "''") & "'", CommandType.text)
                    Session("CategoryID") = CategoryID
                    Dim SubCatID1 As Integer = objDerived.GetValue("Select SubCategoryID from  dbo.tbl_SubCategory where SubCat_Desc ='" & dtItemList.Rows(i)("SubCat_Desc").ToString().Replace("'", "''") & "'", CommandType.text)

                    If Item_ID <> 0 Then

                        'objDerived.Execute("Update dbo.m_item_detail set CY2024 ='" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "','" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "' where ITEM_ID ='" & Item_ID & "'", CommandType.Text)
                        If CYear = "CY2023" Then
                            objDerived.Execute("update dbo.m_item_detail set price= '" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "'," & CYear & "='" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "'where ITEM_ID ='" & Item_ID & "'", CommandType.Text)
                            '== SAVE ITEM DETAILS - UNIT PRICE

                            If Item_ID <> 0 Then
                                objDerived.Execute("update dbo.m_item set Item_Code= '" & dtItemList.Rows(i)("Item_Code") & "'where ITEM_ID ='" & Item_ID & "'", CommandType.Text)
                            Else
                            End If


                            If Item_detail_ID <> 0 Then
                                objDerived.Execute("update dbo.m_item_detail set price= '" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "'," & CYear & "='" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "'where ITEM_ID ='" & Item_ID & "'", CommandType.Text)

                            Else
                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & CYear & ",UserId) " &
                                                                                         " VALUES " &
                                                                                         " ('" & Item_ID & "','" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "','" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "', '" & "admin" & "') ", CommandType.Text)
                            End If
                            objDerived.Execute("insert into dbo.tblclassmatrix (classificationid,ga_id,categoryid,subcategoryid,item_id,SubClassificationID,BGA_ID) Values " &
                                                                                         " ('" & DdClassF.SelectedValue & "','" & Session("GAID") & "','" & Session("CategoryID") & "','" & Session("SubCategoryID") & "','" & Session("Item_ID1") & "','" & Session("SubClassF") & "','" & 0 & "') ", CommandType.Text)

                        ElseIf CYear = "CY2024" Then

                            If Item_ID <> 0 Then
                                objDerived.Execute("update dbo.m_item set Item_Code= '" & dtItemList.Rows(i)("Item_Code") & "'where ITEM_ID ='" & Item_ID & "'", CommandType.Text)
                            Else

                            End If

                            If Item_detail_ID <> 0 Then
                                ' objDerived.Execute("update dbo.m_item_detail set price= '" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "'where ITEM_ID ='" & Item_ID & "'", CommandType.Text)
                                objDerived.Execute("update dbo.m_item_detail set price= '" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "'," & CYear & "='" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "'where ITEM_ID ='" & Item_ID & "'", CommandType.Text)
                            Else
                                Me.objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID,price," & CYear & ",UserId) " &
                                                                                         " VALUES " &
                                                                                         " ('" & Item_ID & "','" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "','" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "', '" & "admin" & "') ", CommandType.Text)
                            End If
                            objDerived.Execute("insert into dbo.tblclassmatrix (classificationid,ga_id,categoryid,subcategoryid,item_id,SubClassificationID,BGA_ID) Values " &
                                                                                         " ('" & DdClassF.SelectedValue & "','" & Session("GAID") & "','" & Session("CategoryID") & "','" & Session("SubCategoryID") & "','" & Session("Item_ID1") & "','" & Session("SubClassF") & "','" & 0 & "') ", CommandType.Text)

                        End If

                    Else
                        '== SAVE NEW ITEM DESCRIPTION
                        'objDerived.Execute("INSERT INTO [dbo].[m_item] ([item_particular_id],[Item_Code],[Item_Desc],[Unit_ID],[detail],[isUsed],[TableId],[QtyPerBox],[reorderPT],[MinQtyPerOrder]) " &
                        '    " VALUES('" & ParticularID & "','" & dtItemList.Rows(i)("Item_Code") & "','" & dtItemList.Rows(i)("Item_Desc") & "','" & UnitID & "','',0,'542729086',0,0,0)", CommandType.Text)


                        Dim dt As New DataTable()

                        'Try
                        'Dim conn As String

                        ' MyBase.conStr = ConfigurationManager.ConnectionStrings("constr").ToString
                        'Return ConfigurationManager.ConnectionStrings("constr").ToString
                        '  Dim conStr = ConfigurationManager.ConnectionStrings("constr").ConnectionString

                        'conn = ConfigurationManager.ConnectionStrings("constr").ConnectionString
                        '  Using conn As New SqlConnection("conStr")
                        'Using conn As New SqlConnection("Data Source=LAPTOP-418T0H65\SQLSVR2017;Initial Catalog=SMSS_Premium;User ID=sa;Password=P@ssw0rd")

                        '    conn.Open()
                        '    '  objDerived.DbConnect()
                        Dim connString As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString

                        Using conn As New SqlConnection(connString)

                            Dim cmd As New SqlCommand("INSERT INTO [dbo].[m_item] ([Item_Code],[Item_Desc],[Unit_ID],[item_particular_id],[detail],[isUsed],[TableId],[SubCategoryID],[Brand],[Color],[Size],[Deprate],[Depyear],[ClassificationID],[SubClassificationID],[QtyPerBox],[reorderPT],[MinQtyPerOrder]) " &
                            "VALUES (@Item_Code, @Item_Desc,  @UnitID,@item_particular_id,'', 0, '542729086',@SubCatID ,'','','',0,0,@ClassificationID ,@SubClassificationID,0,0,0)", conn)


                            cmd.Parameters.Add("@Item_Code", SqlDbType.NVarChar).Value = dtItemList.Rows(i)("Item_Code")
                            cmd.Parameters.Add("@Item_Desc", SqlDbType.NVarChar).Value = dtItemList.Rows(i)("Item_Desc")
                            cmd.Parameters.Add("@UnitID", SqlDbType.Int).Value = UnitID
                            cmd.Parameters.Add("@item_particular_id", SqlDbType.Int).Value = ParticularID
                            cmd.Parameters.Add("@SubCatID", SqlDbType.Int).Value = SubCatID
                            cmd.Parameters.Add("@ClassificationID", SqlDbType.Int).Value = DdClassF.SelectedValue
                            cmd.Parameters.Add("@SubClassificationID", SqlDbType.Int).Value = subclassF
                            cmd.ExecuteNonQuery()

                            cmd.CommandText = "SELECT TOP(1) Item_ID FROM DBO.m_item order by Item_ID desc"
                            cmd.Parameters.Clear()

                            Dim Item_ID2 As String = cmd.ExecuteScalar().ToString()
                        End Using
                        Dim Item_ID1 As String = objDerived.GetValue("SELECT TOP(1) Item_ID FROM DBO.m_item order by Item_ID desc", CommandType.Text)
                        Session("Item_ID1") = Item_ID1
                        'Catch ex As Exception
                        '    'Handle any exceptions while reading the Excel file
                        '    ' You can display an error message Or log the exception here
                        'End Try

                        'Return dt
                        '== SAVE ITEM DETAILS - UNIT PRICE
                        objDerived.Execute("INSERT INTO dbo.m_item_detail (Item_ID, price, " & CYear & ", UserId) VALUES ('" & Session("Item_ID1") & "','" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "','" & IIf(CType(dtItemList.Rows(i)("Cost"), String) = "", 0, CType(dtItemList.Rows(i)("Cost"), Decimal)) & "', '" & Session("@UserName") & "')", CommandType.Text)
                        objDerived.Execute("insert into dbo.tblclassmatrix (classificationid,ga_id,categoryid,subcategoryid,item_id,SubClassificationID,BGA_ID) Values " &
                                                                                         " ('" & DdClassF.SelectedValue & "','" & Session("GAID") & "','" & Session("CategoryID") & "','" & Session("SubCategoryID") & "','" & Session("Item_ID1") & "','" & Session("SubClassF") & "','" & 0 & "') ", CommandType.Text)

                    End If
                End If

            Next
            '== tblclassmatrix table saving

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                drpYear.DataSource = objDerived.GetDataTable("SELECT year FROM AMS.APP WHERE status = 1 ORDER BY year DESC", CommandType.Text)
                drpYear.DataTextField = "year"
                drpYear.DataValueField = "year"
                drpYear.DataBind()

                drpGenAccount.DataSource = objDerived.GetDataTable("SELECT GA_ID, '(' + GA_Code + ') ' + GA_Title AS GenAccount, GA_Title FROM AMS.View_AccountList WHERE AllotmentClass_ID = 2 AND BGA_ID = 0 ORDER BY GA_Title", CommandType.Text)
                drpGenAccount.DataTextField = "GenAccount"
            drpGenAccount.DataValueField = "GA_ID"
            drpGenAccount.DataBind()
                drpGenAccount.Items.Insert(0, "Select")

                grdItems.DataSource = CreateDataTable_Items(5)
                grdItems.DataBind()

            End If

        'Catch ex As Exception

        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        'End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Page.Response.Redirect("~/filemaintenance/upload_newitems.aspx")
    End Sub


    Protected Sub grdItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdItems.SelectedIndexChanged

    End Sub
    Public Sub DropdownClassification()


        dtClass = objDerived.GetDataTable("Select * from dbo.tbl_Classification where AllotmentClass_id ='" & drpAllotment.SelectedValue & "' order by seqno ", CommandType.Text)



        DdClassF.DataSource = dtClass
        DdClassF.DataTextField = "ClassificationName"
        DdClassF.DataValueField = "ClassificationID"

        DdClassF.DataBind()
        DdClassF.Items.Insert(0, "Select")
        'DrpGenAcc = objDerived.GetDataTable("Select GA_ID, GA_Code + ' - '+ GA_Title as ga_title from ams.vw_supplies where ClassificationID ='" & DrpClass.SelectedItem.Value & "' and BGA_ID = 0 Order by ga_title", CommandType.Text)
        'DrpGenAcc = objDerived.GetDataTable("Exec [AMS].[FMgetGenAccnt]'" & DrpClass.SelectedItem.Value & "','" & DrpSubClass.SelectedItem.Value & "'", CommandType.Text)
        'GenAccnt.DataSource = DrpGenAcc
        'GenAccnt.DataTextField = "GA_title"
        'GenAccnt.DataValueField = "GA_ID"
        'GenAccnt.Items.Insert(0, "Select")
        'GenAccnt.items.clear()
        'GenAccnt.DataBind()


    End Sub
    Protected Sub drpYear_SelectedIndexChanged1(sender As Object, e As EventArgs)

    End Sub
    Protected Sub DdClassF_SelectedIndexChanged(sender As Object, e As EventArgs)
        DrpSubClassF = objDerived.GetDataTable("Select SubClassificationID, SubclassificationName from dbo.tbl_SubClassification where ClassificationID = '" & DdClassF.SelectedItem.Value & "'", CommandType.Text)
        DdSubClassF.DataSource = DrpSubClassF
        DdSubClassF.DataTextField = "SubClassificationName"
        DdSubClassF.DataValueField = "SubClassificationID"
        DdSubClassF.items.clear()
        DdSubClassF.DataBind()
        DdSubClassF.Items.Insert(0, "Select")
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        If drpGenAccount.SELECTEDITEM.TEXT = "" Or DdSubClassF.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select General Account first!!!")
        Else
            ' Specify the file name
            Dim excelFileName As String = "D:\SMSS_Premium_Core_StandAlone\Book1.xlsx"
            Dim a As Integer
            If DdSubClassF.Text = "" Or DdSubClassF.Text = "Select" Then
                a = 0
            Else
                a = DdSubClassF.SelectedItem.Value
            End If
            Dim data As DataTable = objDerived.GetDataTable("exec ams.TempCategory '" & drpGenAccount.SelectedItem.Value & "','" & 0 & "','" & DdClassF.SelectedItem.Value & "','" & a & "'", CommandType.Text)

            Dim data2 As DataTable = objDerived.GetDataTable("exec ams.TempSubCategory", CommandType.Text)

            Dim data3 As DataTable = objDerived.GetDataTable("exec [AMS].[loadunit]", CommandType.Text)

            ' Call the function to create the Excel file
            Dim excelBytes As Byte() = ExcelCreator.CreateExcelFile(excelFileName, data, data2, data3)

            ' Send the Excel file to the user for download
            ExcelCreator.SendExcelToClient(excelBytes, excelFileName)

            ' Display a message or perform further actions as needed
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Excel file opened successfully.")
        End If




    End Sub
    Public Class ExcelCreator
        Public Shared Function CreateExcelFile(filePath As String, data As DataTable, data2 As DataTable, data3 As DataTable) As Byte()
            ' Set the license context for EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial

            ' Create a new Excel package
            Using package As New ExcelPackage()


                ' Add a new worksheet to the package
                Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Sheet1")


                Dim worksheet2 As ExcelWorksheet = package.Workbook.Worksheets.Add("Sheet2")

                ' Define the column headers
                Dim columnHeaders As String() = {"Category_item_particular_id", "Category_description", "SubCategoryID", "SubCat_Desc", "sub_cat_Item_particular_id", "unit_description", "Unit_ID"}

                ' Dim columnHeaders As String() = {"Category"}

                ' Add the column headers to the worksheet
                For col As Integer = 0 To columnHeaders.Length - 1
                    worksheet2.Cells(1, col + 1).Value = columnHeaders(col)
                Next

                ' Write data to the worksheet
                For row As Integer = 0 To data.Rows.Count - 1
                    For col As Integer = 0 To data.Columns.Count - 1
                        worksheet2.Cells(row + 2, col + 1).Value = data.Rows(row)(col).ToString()
                    Next
                Next

                ' Continue adding columns for data2 to the same sheet
                Dim startCol As Integer = data.Columns.Count
                For row2 As Integer = 0 To data2.Rows.Count - 1
                    For col2 As Integer = 0 To data2.Columns.Count - 1
                        worksheet2.Cells(row2 + 2, startCol + col2 + 1).Value = data2.Rows(row2)(col2).ToString()
                    Next
                Next

                Dim startCol2 As Integer = data.Columns.Count + data2.Columns.Count
                For row3 As Integer = 0 To data3.rows.count - 1
                    For col3 As Integer = 0 To data3.columns.count - 1
                        worksheet2.cells(row3 + 2, startCol2 + col3 + 1).Value = data3.Rows(row3)(col3).toString()
                    Next
                Next


                ' Create a MemoryStream
                Using memoryStream As New MemoryStream()
                    ' Save the Excel package to the MemoryStream
                    package.SaveAs(memoryStream)

                    ' Save the MemoryStream to a file
                    File.WriteAllBytes(filePath, memoryStream.ToArray())

                    ' Return the byte array of the MemoryStream
                    Return memoryStream.ToArray()
                End Using
            End Using
        End Function

        Public Shared Sub SendExcelToClient(excelBytes As Byte(), fileName As String)
            ' Clear the response
            HttpContext.Current.Response.Clear()

            ' Set the content type and header for the file
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" & fileName)

            ' Write the file content to the response
            HttpContext.Current.Response.BinaryWrite(excelBytes)

            ' End the response
            HttpContext.Current.Response.End()
        End Sub



    End Class

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Dim excelApp As New Excel.Application()
        Dim excelWorkbook As Excel.Workbook = excelApp.Workbooks.Open("D:\SMSS_Premium_Core_StandAlone\Book1.xlsx")
        Dim excelWorksheet As Excel.Worksheet = CType(excelWorkbook.Sheets("Sheet1"), Excel.Worksheet)
        Dim excelWorksheet2 As Excel.Worksheet = CType(excelWorkbook.Sheets("Sheet2"), Excel.Worksheet)
        Dim a As Integer
        If DdSubClassF.Text = "" Or DdSubClassF.Text = "Select" Then
            a = 0
        Else
            a = DdSubClassF.SelectedItem.Value
        End If
        ' Populate data into Excel cells
        Dim data As DataTable = objDerived.GetDataTable("exec ams.TempCategory '" & drpGenAccount.SelectedItem.Value & "','" & 0 & "','" & DdClassF.SelectedItem.Value & "','" & a & "'", CommandType.Text)
        Dim data2 As DataTable = objDerived.GetDataTable("exec ams.TempSubCategory", CommandType.Text)
        Dim data3 As DataTable = objDerived.GetDataTable("exec [AMS].[loadunit]", CommandType.Text)



        '' Define the column headers
        'Dim columnHeaders As String() = {"Category_item_particular_id", "Category_description", "SubCategoryID", "SubCat_Desc", "sub_cat_Item_particular_id", "unit_description", "Unit_ID"}

        '' Dim columnHeaders As String() = {"Category"}

        '' Add the column headers to the worksheet
        'For col As Integer = 0 To columnHeaders.Length - 1
        '    excelWorksheet2.Cells(1, col + 1).Value = columnHeaders(col)
        'Next

        ' Write data to the worksheet
        For row As Integer = 0 To data.Rows.Count - 1
            For col As Integer = 0 To data.Columns.Count - 1
                excelWorksheet2.Cells(row + 2, col + 1).Value = data.Rows(row)(col).ToString()
            Next
        Next

        ' Continue adding columns for data2 to the same sheet
        Dim startCol As Integer = data.Columns.Count
        For row2 As Integer = 0 To data2.Rows.Count - 1
            For col2 As Integer = 0 To data2.Columns.Count - 1
                excelWorksheet2.Cells(row2 + 2, startCol + col2 + 1).Value = data2.Rows(row2)(col2).ToString()
            Next
        Next

        Dim startCol2 As Integer = data.Columns.Count + data2.Columns.Count
        For row3 As Integer = 0 To data3.Rows.Count - 1
            For col3 As Integer = 0 To data3.Columns.Count - 1
                excelWorksheet2.Cells(row3 + 2, startCol2 + col3 + 1).Value = data3.Rows(row3)(col3).ToString()
            Next
        Next



        ' Make Excel visible
        excelApp.Visible = True

        ' Release resources
        Marshal.ReleaseComObject(excelWorksheet)
        Marshal.ReleaseComObject(excelWorkbook)
        Marshal.ReleaseComObject(excelApp)

        excelWorksheet = Nothing
        excelWorkbook = Nothing
        excelApp = Nothing
    End Sub
End Class
