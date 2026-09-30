Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Collections.Generic

Partial Class filemaintenance_Import_Items
    Inherits System.Web.UI.Page

    Dim objDerived As New DerivedDal

#Region "property"
    Private Property PYear() As DataTable
        Get
            Return CType(Session("PYear"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PYear") = value
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
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindYear()
            BindAllotmentType()
            BindEmptyGrid()

        Else
            ' If a save just completed, any subsequent postback (like F5) should
            ' restart the page cleanly instead of re-running btnSave_Click.
            If Object.Equals(Session("ImportItems_Saved"), True) Then
                Session("ImportItems_Saved") = Nothing
                Response.Redirect("~/filemaintenance/Import_Items.aspx", False)
                Context.ApplicationInstance.CompleteRequest()
                Exit Sub
            End If
        End If
    End Sub

    ' ------------------------------------------------------------
    ' Bind ddyear from ams.APP
    ' ------------------------------------------------------------
    Private Sub BindYear()
        Try
            PYear = objDerived.GetDataTable("select year from ams.APP where isContinuing <> 1 ORDER BY YEAR DESC", CommandType.Text)
            Me.ddyear.DataSource = PYear
            Me.ddyear.DataTextField = "year"
            Me.ddyear.DataValueField = "year"
            Me.ddyear.DataBind()
            Me.ddyear.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub

    ' ------------------------------------------------------------
    ' Hardcoded Allotment Type
    ' ------------------------------------------------------------
    Private Sub BindAllotmentType()
        ddAllotmentType.Items.Clear()
        ddAllotmentType.Items.Add(New ListItem("Select", "0"))
        ddAllotmentType.Items.Add(New ListItem("MOOE", "2"))
        ddAllotmentType.Items.Add(New ListItem("Capital Outlay", "3"))
    End Sub

    ' ------------------------------------------------------------
    ' ddyear change
    ' ------------------------------------------------------------
    Protected Sub ddyear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddyear.SelectedIndexChanged
        If ddyear.SelectedValue = "0" Then Exit Sub

        Session("CYNow") = "CY" & ddyear.SelectedValue
        Session("CYPrev") = "CY" & (CInt(ddyear.SelectedValue) - 1)

        If ddAllotmentType.SelectedValue <> "0" Then
            BindGenAccnt()
        End If
    End Sub

    ' ------------------------------------------------------------
    ' ddAllotmentType change — reload GenAccnt, reset class/subclass
    ' ------------------------------------------------------------
    Protected Sub ddAllotmentType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddAllotmentType.SelectedIndexChanged
        drpclass.Items.Clear()
        drpclass.Items.Add(New ListItem("Select", "0"))

        DrpSubClass.Items.Clear()
        DrpSubClass.Items.Add(New ListItem("Select", "0"))

        If ddAllotmentType.SelectedValue = "0" Then Exit Sub

        BindGenAccnt()
    End Sub

    ' ------------------------------------------------------------
    ' Bind GenAccnt from vw_AccountWithClass by AllotmentClass_ID
    ' ------------------------------------------------------------
    Private Sub BindGenAccnt()
        If ddAllotmentType.SelectedValue = "0" Then Exit Sub

        DrpGenAcc = objDerived.GetDataTable(
            "SELECT DISTINCT GA_ID, GA_Title FROM dbo.vw_AccountWithClass " &
            "WHERE AllotmentClass_ID = " & ddAllotmentType.SelectedValue & " ORDER BY GA_Title",
            CommandType.Text)

        GenAccnt.DataSource = DrpGenAcc
        GenAccnt.DataTextField = "GA_Title"
        GenAccnt.DataValueField = "GA_ID"
        GenAccnt.Items.Clear()
        GenAccnt.DataBind()
        GenAccnt.Items.Insert(0, New ListItem("Select", "0"))
    End Sub

    ' ------------------------------------------------------------
    ' GenAccnt change — load Class + SubClass, auto-select from view
    ' ------------------------------------------------------------
    Protected Sub GenAccnt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenAccnt.SelectedIndexChanged
        If GenAccnt.SelectedValue = "0" Then Exit Sub
        If ddAllotmentType.SelectedValue = "0" Then Exit Sub

        ' 1) Load drpclass
        dtClass = objDerived.GetDataTable(
            "Select * from dbo.tbl_Classification where AllotmentClass_id = " &
            ddAllotmentType.SelectedValue & " order by ClassificationName",
            CommandType.Text)

        drpclass.DataSource = dtClass
        drpclass.DataTextField = "ClassificationName"
        drpclass.DataValueField = "ClassificationID"
        drpclass.Items.Clear()
        drpclass.DataBind()
        drpclass.Items.Insert(0, New ListItem("Select", "0"))

        ' 2) Auto-select ClassificationID from view
        Dim selectedClassID As Object = objDerived.GetValue(
            "SELECT TOP 1 ClassificationID FROM dbo.vw_AccountWithClass WHERE GA_ID = '" &
            GenAccnt.SelectedValue & "'", CommandType.Text)

        If selectedClassID Is Nothing OrElse IsDBNull(selectedClassID) OrElse selectedClassID.ToString() = "" Then
            drpclass.SelectedIndex = 0
        Else
            Dim itemClass As ListItem = drpclass.Items.FindByValue(selectedClassID.ToString())
            If itemClass IsNot Nothing Then
                drpclass.ClearSelection()
                itemClass.Selected = True
            Else
                drpclass.SelectedIndex = 0
            End If
        End If

        ' 3) Load DrpSubClass
        DrpSubClass.Items.Clear()

        Dim selectedSubClassID As Object = objDerived.GetValue(
            "SELECT TOP 1 SubClassificationID FROM dbo.vw_AccountWithClass WHERE GA_ID = '" &
            GenAccnt.SelectedValue & "'", CommandType.Text)

        If selectedSubClassID Is Nothing OrElse IsDBNull(selectedSubClassID) OrElse selectedSubClassID.ToString() = "" Then
            DrpSubClass.Items.Add(New ListItem("Select", "0"))
        Else
            DrpSubClassF = objDerived.GetDataTable(
                "SELECT SubClassificationID, SubClassificationName FROM dbo.tbl_SubClassification " &
                "WHERE GA_ID = '" & GenAccnt.SelectedValue & "' " &
                "AND ClassificationID = '" & drpclass.SelectedValue & "' ORDER BY SubClassificationName",
                CommandType.Text)

            DrpSubClass.DataSource = DrpSubClassF
            DrpSubClass.DataTextField = "SubClassificationName"
            DrpSubClass.DataValueField = "SubClassificationID"
            DrpSubClass.Items.Clear()
            DrpSubClass.DataBind()
            DrpSubClass.Items.Insert(0, New ListItem("No Subclass", "0"))

            Dim itemSubClass As ListItem = DrpSubClass.Items.FindByValue(selectedSubClassID.ToString())
            If itemSubClass IsNot Nothing Then
                DrpSubClass.ClearSelection()
                itemSubClass.Selected = True
            Else
                DrpSubClass.SelectedIndex = 0
            End If
        End If
    End Sub

    ' ------------------------------------------------------------
    ' drpclass change — rebuild DrpSubClass
    ' ------------------------------------------------------------
    Protected Sub drpclass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpclass.SelectedIndexChanged
        If drpclass.SelectedValue = "0" Then Exit Sub
        If GenAccnt.SelectedValue = "0" Then Exit Sub

        DrpSubClassF = objDerived.GetDataTable(
            "SELECT SubClassificationID, SubClassificationName FROM dbo.tbl_SubClassification " &
            "WHERE GA_ID = '" & GenAccnt.SelectedValue & "' " &
            "AND ClassificationID = '" & drpclass.SelectedValue & "' ORDER BY SubClassificationName",
            CommandType.Text)

        DrpSubClass.DataSource = DrpSubClassF
        DrpSubClass.DataTextField = "SubClassificationName"
        DrpSubClass.DataValueField = "SubClassificationID"
        DrpSubClass.Items.Clear()
        DrpSubClass.DataBind()
        DrpSubClass.Items.Insert(0, New ListItem("No Subclass", "0"))
    End Sub

    ' ------------------------------------------------------------
    ' DrpSubClass change — stub for now
    ' ------------------------------------------------------------
    Protected Sub DrpSubClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpSubClass.SelectedIndexChanged
        ' TODO: filter grid by selected SubClassification
    End Sub

    ' ------------------------------------------------------------
    ' Binds 4 empty rows to grdUploadedItems when no data is available
    ' ------------------------------------------------------------
    Private Sub BindEmptyGrid()
        Dim dt As New DataTable()
        dt.Columns.Add("Item_Code")
        dt.Columns.Add("CategoryName")
        dt.Columns.Add("Item_Desc")
        dt.Columns.Add("price")
        dt.Columns.Add("UnitDescription")
        dt.Columns.Add("reorderPT")
        dt.Columns.Add("UsefulLife")

        For i As Integer = 1 To 4
            Dim dr As DataRow = dt.NewRow()
            dr("Item_Code") = ""
            dr("CategoryName") = ""
            dr("Item_Desc") = ""
            dr("price") = ""
            dr("UnitDescription") = ""
            dr("reorderPT") = ""
            dr("UsefulLife") = ""
            dt.Rows.Add(dr)
        Next

        grdUploadedItems.DataSource = dt
        grdUploadedItems.DataBind()
    End Sub

    ' ------------------------------------------------------------
    ' New Subclass Button — opens the modal
    ' ------------------------------------------------------------
    Protected Sub btnNewSubClass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewSubClass.Click

        If GenAccnt.SelectedIndex = 0 Or GenAccnt.SelectedIndex = -1 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Select a General Account.")
            Exit Sub
        End If

        If drpclass.SelectedIndex = 0 Or drpclass.SelectedIndex = -1 OrElse
        drpclass.SelectedItem Is Nothing OrElse
        String.IsNullOrEmpty(drpclass.SelectedValue) OrElse
        drpclass.SelectedValue = "0" Then

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Select a Classification.")
            Exit Sub
        End If

        ' Set the labels from the current dropdown selections
        lblNewSubClass_Class.Text = drpclass.SelectedItem.Text
        lblNewSubClass_GA.Text = GenAccnt.SelectedItem.Text

        NewSubClassificationTxt.Enabled = True
        NewSubClassificationTxt.Text = ""
        GvSubClass.SelectedIndex = -1
        BtnSave_SUBCLASS.Text = "SAVE"

        Load_GVSubClass()

        ModalPopupExtender7.Show()
    End Sub

    ' ------------------------------------------------------------
    ' Load the Sub Classification grid for current Class + GA
    ' ------------------------------------------------------------
    Private Sub Load_GVSubClass()
        Dim dt As DataTable = objDerived.GetDataTable(
        "SELECT sc.SubClassificationID, sc.SubClassificationName, sc.ClassificationID, " &
        "       c.ClassificationName, sc.GA_ID, " &
        "       (SELECT TOP 1 GA_Title FROM dbo.vw_AccountWithClass WHERE GA_ID = sc.GA_ID) AS GA_Title2 " &
        "FROM dbo.tbl_SubClassification sc " &
        "INNER JOIN dbo.tbl_Classification c ON sc.ClassificationID = c.ClassificationId " &
        "WHERE sc.ClassificationID = '" & drpclass.SelectedValue & "' " &
        "AND sc.GA_ID = '" & GenAccnt.SelectedValue & "' " &
        "ORDER BY sc.SubClassificationName", CommandType.Text)

        GvSubClass.DataSource = dt
        GvSubClass.DataBind()
    End Sub

    ' ------------------------------------------------------------
    ' Save / Update Sub Classification
    ' ------------------------------------------------------------
    ' ------------------------------------------------------------
    ' Save / Update Sub Classification
    ' ------------------------------------------------------------
    Protected Sub BtnSave_SUBCLASS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave_SUBCLASS.Click

        If String.IsNullOrWhiteSpace(NewSubClassificationTxt.Text) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Sub Classification is required.")
            ModalPopupExtender7.Show()
            Exit Sub
        End If

        Dim subName As String = replaceapostrophe(NewSubClassificationTxt.Text.Trim())
        Dim gaId As Integer = CInt(GenAccnt.SelectedValue)
        Dim classId As Integer = CInt(drpclass.SelectedValue)

        If BtnSave_SUBCLASS.Text = "SAVE" Then

            ' Prevent duplicates under the same Class + GA
            Dim exists As Object = objDerived.GetValue(
            "SELECT COUNT(*) FROM dbo.tbl_SubClassification " &
            "WHERE SubClassificationName = '" & subName & "' " &
            "AND ClassificationID = '" & classId & "' " &
            "AND GA_ID = '" & gaId & "'", CommandType.Text)

            If CInt(exists) > 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Sub Classification already exists.")
                ModalPopupExtender7.Show()
                Exit Sub
            End If

            ' Insert new Sub Classification
            Me.objDerived.Execute(
            "INSERT INTO dbo.tbl_SubClassification (SubClassificationName, ClassificationID, GA_ID) " &
            "VALUES ('" & subName & "', '" & classId & "', '" & gaId & "')", CommandType.Text)

            ' Retrieve the new ID
            Dim newId As Integer = CInt(objDerived.GetValue(
            "SELECT TOP 1 SubClassificationID FROM dbo.tbl_SubClassification " &
            "WHERE SubClassificationName = '" & subName & "' " &
            "AND ClassificationID = '" & classId & "' " &
            "AND GA_ID = '" & gaId & "' " &
            "ORDER BY SubClassificationID DESC", CommandType.Text))

            ' Mirror into tblclassmatrix
            Me.objDerived.Execute(
            "INSERT INTO dbo.tblclassmatrix (ClassificationID, GA_ID, SubClassificationID) " &
            "VALUES ('" & classId & "', '" & gaId & "', '" & newId & "')", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            NewSubClassificationTxt.Text = ""
            GvSubClass.SelectedIndex = -1
            BtnSave_SUBCLASS.Text = "SAVE"
            Load_GVSubClass()
            LoadDrpSubClass()
            ModalPopupExtender7.Show()

        Else
            ' Update mode
            If GvSubClass.SelectedIndex >= 0 Then

                Dim subId As Integer = CInt(GvSubClass.SelectedDataKey("SubClassificationID"))

                Me.objDerived.Execute(
                "UPDATE dbo.tbl_SubClassification " &
                "SET SubClassificationName = '" & subName & "' " &
                "WHERE SubClassificationID = '" & subId & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")

                NewSubClassificationTxt.Text = ""
                GvSubClass.SelectedIndex = -1
                BtnSave_SUBCLASS.Text = "SAVE"
                Load_GVSubClass()
                LoadDrpSubClass()
                ModalPopupExtender7.Show()
            End If
        End If
    End Sub

    ' ------------------------------------------------------------
    ' Repopulate DrpSubClass for the current GenAccnt + drpclass
    ' ------------------------------------------------------------
    Private Sub LoadDrpSubClass()
        If GenAccnt.SelectedValue = "0" Then Exit Sub
        If drpclass.SelectedValue = "0" Then Exit Sub

        Dim previousValue As String = DrpSubClass.SelectedValue

        DrpSubClassF = objDerived.GetDataTable(
        "SELECT SubClassificationID, SubClassificationName FROM dbo.tbl_SubClassification " &
        "WHERE GA_ID = '" & GenAccnt.SelectedValue & "' " &
        "AND ClassificationID = '" & drpclass.SelectedValue & "' ORDER BY SubClassificationName",
        CommandType.Text)

        DrpSubClass.DataSource = DrpSubClassF
        DrpSubClass.DataTextField = "SubClassificationName"
        DrpSubClass.DataValueField = "SubClassificationID"
        DrpSubClass.Items.Clear()
        DrpSubClass.DataBind()
        DrpSubClass.Items.Insert(0, New ListItem("No Subclass", "0"))

        If previousValue IsNot Nothing AndAlso previousValue <> "" Then
            Dim item As ListItem = DrpSubClass.Items.FindByValue(previousValue)
            If item IsNot Nothing Then
                DrpSubClass.ClearSelection()
                item.Selected = True
            End If
        End If
    End Sub
    ' ------------------------------------------------------------
    ' Clear Sub Classification textbox
    ' ------------------------------------------------------------
    Protected Sub BtnClearSubClass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClearSubClass.Click
        NewSubClassificationTxt.Text = ""
        GvSubClass.SelectedIndex = -1
        BtnSave_SUBCLASS.Text = "SAVE"
        ModalPopupExtender7.Show()
    End Sub

    ' ------------------------------------------------------------
    ' Grid — select a row for update
    ' ------------------------------------------------------------
    Protected Sub GvSubClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GvSubClass.SelectedIndexChanged
        NewSubClassificationTxt.Text = GvSubClass.SelectedDataKey("SubClassificationName").ToString()
        BtnSave_SUBCLASS.Text = "Update"
        ModalPopupExtender7.Show()
    End Sub

    ' ------------------------------------------------------------
    ' Grid — paging
    ' ------------------------------------------------------------
    Protected Sub GvSubClass_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvSubClass.PageIndexChanging
        GvSubClass.PageIndex = e.NewPageIndex
        Load_GVSubClass()
        ModalPopupExtender7.Show()
    End Sub

    ' ------------------------------------------------------------
    ' Download Template Button
    ' ------------------------------------------------------------
    Protected Sub btnDownloadTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownloadTemplate.Click
        Dim filePath As String = Server.MapPath("~/filemaintenance/AMS_Import_Items_Template.xlsx")

        If File.Exists(filePath) Then
            Response.Clear()
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("Content-Disposition", "attachment; filename=AMS_Import_Items_Template.xlsx")
            Response.WriteFile(filePath)
            Response.Flush()
            Response.End()
        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Template file not found.")
        End If
    End Sub

    ' ------------------------------------------------------------
    ' Upload File Button
    ' ------------------------------------------------------------
    Protected Sub btnUploadFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadFile.Click

        ' 1) File must be present
        If Not FileUpload1.HasFile Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please upload a file using the AMS Import Items template.")
            Exit Sub
        End If

        ' 2) File must be .xlsx
        Dim fi2 As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
        Dim extension As String = Path.GetExtension(fi2.Name).ToLower()
        If extension <> ".xlsx" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid file type. Please upload a .xlsx file.")
            Exit Sub
        End If

        ' 3) Dropdowns must be selected
        If ddyear.SelectedValue = "0" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a Calendar Year.")
            Exit Sub
        End If
        If ddAllotmentType.SelectedValue = "0" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select an Allotment Type.")
            Exit Sub
        End If
        If GenAccnt.SelectedValue = "0" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a General Account.")
            Exit Sub
        End If
        If drpclass.SelectedValue = "0" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a Classification.")
            Exit Sub
        End If

        ' 4) Clear existing rows in AMS.Import_Items
        objDerived.GetRecords("DELETE FROM AMS.Import_Items", CommandType.Text)

        ' 5) Save uploaded file to a temp location (OleDb needs a physical file)
        Dim tempFolder As String = Server.MapPath("~/filemaintenance/temp/")
        If Not Directory.Exists(tempFolder) Then Directory.CreateDirectory(tempFolder)

        Dim tempFileName As String = Guid.NewGuid().ToString("N") & ".xlsx"
        Dim tempFilePath As String = Path.Combine(tempFolder, tempFileName)
        FileUpload1.SaveAs(tempFilePath)

        Try
            Dim yearValue As Integer = CInt(ddyear.SelectedValue)
            Dim cyNow As String = "CY" & ddyear.SelectedValue

            Dim subClassID As Integer = 0
            If DrpSubClass.SelectedValue <> "" AndAlso DrpSubClass.SelectedValue <> "0" Then
                subClassID = CInt(DrpSubClass.SelectedValue)
            End If

            Dim insertedCount As Integer = 0

            ' Connection string for Excel 2007+ (.xlsx)
            Dim connString As String =
            "Provider=Microsoft.ACE.OLEDB.12.0;" &
            "Data Source=" & tempFilePath & ";" &
            "Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"

            Using conn As New OleDbConnection(connString)
                conn.Open()

                ' Get the first sheet name dynamically
                Dim sheetName As String = ""
                Dim schemaTable As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                If schemaTable IsNot Nothing AndAlso schemaTable.Rows.Count > 0 Then
                    sheetName = schemaTable.Rows(0)("TABLE_NAME").ToString()
                End If

                If sheetName = "" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No worksheet found in the uploaded file.")
                    Exit Sub
                End If

                ' Read all rows from the sheet
                Dim selectCmd As String = "SELECT * FROM [" & sheetName & "]"
                Using cmd As New OleDbCommand(selectCmd, conn)
                    Using adapter As New OleDbDataAdapter(cmd)
                        Dim dtExcel As New DataTable()
                        adapter.Fill(dtExcel)

                        ' Validate required columns
                        If Not dtExcel.Columns.Contains("Item_Code") OrElse Not dtExcel.Columns.Contains("Item_Desc") Then
                            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The uploaded file does not match the template. Required columns are missing.")
                            Exit Sub
                        End If

                        For Each dr As DataRow In dtExcel.Rows
                            Dim itemCode As String = GetRowValue(dr, "Item_Code")
                            Dim categoryName As String = GetRowValue(dr, "CategoryName")
                            Dim itemDesc As String = GetRowValue(dr, "Item_Desc")
                            Dim priceStr As String = GetRowValue(dr, "price")
                            Dim unitDesc As String = GetRowValue(dr, "UnitDescription")
                            Dim reorderStr As String = GetRowValue(dr, "reorderPT")
                            Dim usefulStr As String = GetRowValue(dr, "UsefulLife")

                            ' Skip blank rows
                            If String.IsNullOrWhiteSpace(itemCode) AndAlso String.IsNullOrWhiteSpace(itemDesc) Then
                                Continue For
                            End If

                            Dim priceVal As Decimal = 0
                            If Not String.IsNullOrWhiteSpace(priceStr) Then
                                Decimal.TryParse(priceStr, priceVal)
                            End If

                            Dim reorderVal As Integer = 0
                            If Not String.IsNullOrWhiteSpace(reorderStr) Then
                                Integer.TryParse(reorderStr, reorderVal)
                            End If

                            Dim usefulVal As Integer = 0
                            If Not String.IsNullOrWhiteSpace(usefulStr) Then
                                Integer.TryParse(usefulStr, usefulVal)
                            End If

                            Me.objDerived.Execute(
                            "INSERT INTO AMS.Import_Items (" &
                            "Item_ID, Item_Code, Item_Desc, Unit_ID, item_particular_id, " &
                            "SubClassificationID, ClassificationID, reorderPT, price, GA_ID, " &
                            "YearNumber, CYNow, UnitDescription, CategoryName, UsefulLife, " &
                            "ClassificationName, SubClassificationName, AccountName) " &
                            "VALUES (" &
                            "NULL, " &
                            "'" & replaceapostrophe(itemCode) & "', " &
                            "'" & replaceapostrophe(itemDesc) & "', " &
                            "NULL, " &
                            "NULL, " &
                            subClassID & ", " &
                            drpclass.SelectedValue & ", " &
                            reorderVal & ", " &
                            priceVal & ", " &
                            GenAccnt.SelectedValue & ", " &
                            yearValue & ", " &
                            "'" & cyNow & "', " &
                            "'" & replaceapostrophe(unitDesc) & "', " &
                            "'" & replaceapostrophe(categoryName) & "', " &
                            usefulVal & ", " &
                            "'" & replaceapostrophe(drpclass.SelectedItem.Text) & "', " &
                            "'" & replaceapostrophe(DrpSubClass.SelectedItem.Text) & "', " &
                            "'" & replaceapostrophe(GenAccnt.SelectedItem.Text) & "'" &
                            ")", CommandType.Text)

                            insertedCount += 1
                        Next
                    End Using
                End Using
            End Using

            ' 6) Resolve Unit_ID and item_particular_id on AMS.Import_Items
            Me.objDerived.GetRecords("EXEC AMS.sp_Import_Items_Update", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, insertedCount & " item(s) uploaded successfully.")
            LoadUploadedItems()

            ' 7) Lock the dropdowns
            DisableDropdowns()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error reading file: " & ex.Message)
        Finally
            Try
                If File.Exists(tempFilePath) Then File.Delete(tempFilePath)
            Catch
            End Try
        End Try
    End Sub

    ' ------------------------------------------------------------
    ' Get value from DataRow by column name (safe)
    ' ------------------------------------------------------------
    Private Function GetRowValue(ByVal dr As DataRow, ByVal colName As String) As String
        If dr Is Nothing OrElse dr.Table Is Nothing Then Return ""
        If Not dr.Table.Columns.Contains(colName) Then Return ""
        If dr(colName) Is DBNull.Value Then Return ""
        Return dr(colName).ToString().Trim()
    End Function


    ' ------------------------------------------------------------
    ' Load uploaded items into the GridView
    ' ------------------------------------------------------------
    Private Sub LoadUploadedItems()
        Dim dt As DataTable = objDerived.GetDataTable(
        "SELECT Item_Code, CategoryName, Item_Desc, price, UnitDescription, reorderPT, UsefulLife " &
        "FROM AMS.Import_Items", CommandType.Text)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BindEmptyGrid()
        Else
            grdUploadedItems.DataSource = dt
            grdUploadedItems.DataBind()
        End If
    End Sub


    ' ------------------------------------------------------------
    ' Escape single quotes for SQL
    ' ------------------------------------------------------------
    Public Function replaceapostrophe(ByVal str As String) As String
        If str Is Nothing Then Return ""
        Return Replace(str, "'", "''")
    End Function


    ' ------------------------------------------------------------
    ' Save Button — run SP then clear staging table
    ' ------------------------------------------------------------
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ' 1) Ensure there is something to save
        Dim countVal As Object = objDerived.GetValue("SELECT COUNT(*) FROM AMS.Import_Items", CommandType.Text)
        Dim rowCount As Integer = 0
        If countVal IsNot Nothing AndAlso Not IsDBNull(countVal) Then
            Integer.TryParse(countVal.ToString(), rowCount)
        End If

        If rowCount = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No items to save. Please upload a file first.")
            Exit Sub
        End If

        Try
            ' 2) Execute the insertion stored procedure
            Me.objDerived.GetRecords("EXEC AMS.Import_Items_SaveInsertion", CommandType.Text)

            ' 3) Clear the staging table
            objDerived.GetRecords("DELETE FROM AMS.Import_Items", CommandType.Text)

            ' 4) Disable Save button so it cannot be clicked again
            btnSave.Enabled = False

            ' 5) Reset grid and notify
            BindEmptyGrid()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, rowCount & " item(s) saved successfully.")

            ' 6) Flag for F5 handling on the next postback
            Session("ImportItems_Saved") = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error saving items: " & ex.Message)
        End Try

    End Sub
    ' ------------------------------------------------------------
    ' Cancel Button
    ' ------------------------------------------------------------
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/filemaintenance/Import_Items.aspx")
    End Sub


    ' ------------------------------------------------------------
    ' Disable all dropdowns after a successful upload
    ' ------------------------------------------------------------
    Private Sub DisableDropdowns()
        ddyear.Enabled = False
        ddAllotmentType.Enabled = False
        GenAccnt.Enabled = False
        drpclass.Enabled = False
        DrpSubClass.Enabled = False
    End Sub

End Class