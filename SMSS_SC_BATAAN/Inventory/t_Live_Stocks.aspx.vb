Imports System.Data
Imports System.Drawing
Partial Class Inventory_t_Live_Stocks
    Inherits System.Web.UI.Page
    Dim objx As New AccessRule
    Dim objDerived As New DerivedDal
    Dim item As New m_item
    Private Prop_Ledger As New t_PropertyLedger
    Dim Prop_Hdr As New t_property_hdr
    Dim Prop_Dtl As New t_property_dtl_livestock
    Dim ObjLivestock_Info As New ConsolidatedPropertySaving.TbLivestock_Information


#Region "Function"
    Public Function createdatatableledger(ByVal row As Integer) As DataTable
        'Dim dt As New DataTable()
        'Dim dr As DataRow
        'Dim myDataColumn As DataColumn
        'myDataColumn = New DataColumn()
        ''dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        'dt.Columns.Add("dDate", GetType(Date))
        'dt.Columns.Add("Trans_Type", GetType(String))
        'dt.Columns.Add("ref", GetType(String))
        'dt.Columns.Add("AccountablePerson", GetType(String))
        'dt.Columns.Add("Department", GetType(String))
        'dt.Columns.Add("position", GetType(String))
        'dt.Columns.Add("acceptedby", GetType(String))
        'dt.Columns.Add("inspectedby", GetType(String))
        'dt.Columns.Add("DebitQty", GetType(Integer))
        'dt.Columns.Add("DebitUnit", GetType(String))
        'dt.Columns.Add("DebitCost", GetType(Decimal))
        'dt.Columns.Add("CreditQty", GetType(Integer))
        'dt.Columns.Add("CreditUnit", GetType(String))
        'dt.Columns.Add("CreditCost", GetType(Decimal))
        'dt.Columns.Add("BalQty", GetType(Integer))
        'dt.Columns.Add("BalanceUnit", GetType(String))
        'dt.Columns.Add("BalCost", GetType(Decimal))
        'For i As Integer = 0 To row
        '    dr = dt.NewRow
        '    'dr("Property_Dtl_ID") = DBNull.Value
        '    dr("dDate") = DBNull.Value
        '    dr("Trans_Type") = DBNull.Value
        '    dr("ref") = DBNull.Value
        '    dr("AccountablePerson") = DBNull.Value
        '    dr("Department") = DBNull.Value
        '    dr("position") = DBNull.Value
        '    dr("acceptedby") = DBNull.Value
        '    dr("inspectedby") = DBNull.Value
        '    dr("DebitQty") = DBNull.Value
        '    dr("DebitUnit") = DBNull.Value
        '    dr("DebitCost") = DBNull.Value
        '    dr("CreditQty") = DBNull.Value
        '    dr("CreditUnit") = DBNull.Value
        '    dr("CreditCost") = DBNull.Value
        '    dr("BalQty") = DBNull.Value
        '    dr("BalanceUnit") = DBNull.Value
        '    dr("BalCost") = DBNull.Value
        '    dt.Rows.Add(dr)
        'Next
        'Return dt
        'Optimize Code
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add(New DataColumn("dDate", GetType(Date)))
        dt.Columns.Add(New DataColumn("Trans_Type", GetType(String)))
        dt.Columns.Add(New DataColumn("ref", GetType(String)))
        dt.Columns.Add(New DataColumn("AccountablePerson", GetType(String)))
        dt.Columns.Add(New DataColumn("Department", GetType(String)))
        dt.Columns.Add(New DataColumn("position", GetType(String)))
        dt.Columns.Add(New DataColumn("acceptedby", GetType(String)))
        dt.Columns.Add(New DataColumn("inspectedby", GetType(String)))
        dt.Columns.Add(New DataColumn("DebitQty", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DebitUnit", GetType(String)))
        dt.Columns.Add(New DataColumn("DebitCost", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("CreditQty", GetType(Integer)))
        dt.Columns.Add(New DataColumn("CreditUnit", GetType(String)))
        dt.Columns.Add(New DataColumn("CreditCost", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("BalQty", GetType(Integer)))
        dt.Columns.Add(New DataColumn("BalanceUnit", GetType(String)))
        dt.Columns.Add(New DataColumn("BalCost", GetType(Decimal)))

        dt.BeginLoadData()

        Dim values() As Object = {DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value}

        For i As Integer = 0 To row
            dr = dt.Rows.Add()
            dr.ItemArray = values
        Next

        dt.EndLoadData()

        Return dt
    End Function
    Public Sub loadEquipmentLedger()
        ' btnEquipmentLedger.CssClass = "Clicked"
        'btnequipmentrepairs.CssClass = "Initial"
        ' btnequipmentattachdoc.CssClass = "Initial"
        ' Me.mvledger.SetActiveView(Me.vwledger)

        Dim dtAccount As New DataTable
        Dim itemid As String

        'TODO [Save_TbProperty_Ledger]?? > AMS.TbProperty_Ledger 
        dtAccount = objDerived.GetDataTable("Exec [AMS].[LivestockLedgerList]", CommandType.Text)


        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
    End Sub
#End Region
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        Dim cell As New TableHeaderCell()
        cell.Text = "LAND"
        cell.ColumnSpan = 3
        cell.BorderWidth = 2
        cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        row.Controls.Add(cell)

        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.Text = "DEBIT"
        cell.BorderWidth = 2
        cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        row.Controls.Add(cell)


        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.Text = "CREDIT"
        cell.BorderWidth = 2
        cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        row.Controls.Add(cell)


        cell = New TableHeaderCell()
        cell.ColumnSpan = 1
        cell.Text = "BALANCE"
        cell.BorderWidth = 2
        cell.BorderColor = ColorTranslator.FromHtml("#12306b")
        row.Controls.Add(cell)

        row.BackColor = ColorTranslator.FromHtml("WHITE")
        row.ForeColor = ColorTranslator.FromHtml("#12306b")

        grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)
    End Sub
    Private Sub t_Live_Stocks_Load(sender As Object, e As EventArgs) Handles Me.Load
        'objx.GetAccessRight(Me.Session("@UserName"), Page)
        'If objx.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If

        If Not Page.IsPostBack Then
            drpBreed.datasource = objDerived.GetDataTable("Select * from dbo.Breed ", CommandType.Text)
            drpBreed.DataTextField = ("BreedName")
            drpBreed.DataValueField = ("BreedID")
            drpBreed.DataBind()
            drpBreed.Items.Insert(0, "Select")

            drpSubClassification.datasource = objDerived.GetDataTable("Select * from dbo.tbl_SubClassification where ClassificationID = 17", CommandType.Text)
            drpSubClassification.DataTextField = ("SubClassificationName")
            drpSubClassification.DataValueField = ("SubClassificationID")
            drpSubClassification.DataBind()
            drpSubClassification.Items.Insert(0, "Select")


            loadEquipmentLedger()
        End If
    End Sub
    Protected Sub lnkAddStockInformation_Click(sender As Object, e As EventArgs)
        If txtQuantity.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Input Quantity")
        Else
            Dim dt As New DataTable()

            If ViewState("Customers") IsNot Nothing Then
                dt = DirectCast(ViewState("Customers"), DataTable)
            Else
                dt = New DataTable()
                dt.Columns.Add("LivePropertyNo", GetType(String))
                dt.Columns.Add("DateAquired", GetType(String))
                dt.Columns.Add("Age", GetType(String))
                dt.Columns.Add("Weight", GetType(String))
                dt.Columns.Add("Amount", GetType(String))
            End If

            While dt.Rows.Count < Convert.ToInt32(txtQuantity.Text)
                dt.Rows.Add("", "", "", "")
            End While

            ViewState("Customers") = dt
            Me.BindGrid()

            ModalPopupExtender1.Show()
        End If

    End Sub
    Public Sub LoadBreed()
        Dim dtBreed As New DataTable
        dtBreed = objDerived.GetDataTable("select * from dbo.Breed", CommandType.Text)
        gvBreeds.DataSource = dtBreed
        gvBreeds.DataBind()
    End Sub
    Protected Sub lnkBreed_Click(sender As Object, e As EventArgs)
        LoadBreed()
        ModalPopupExtender2.SHOW()
    End Sub
    Protected Sub BindGrid()
        grdPropertyInfo.DataSource = DirectCast(ViewState("Customers"), DataTable)
        grdPropertyInfo.DataBind()
    End Sub
    Protected Sub gvBreeds_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")

            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvBreeds, "Select$" + e.Row.RowIndex.ToString()))
            ' e.Row.Cells(0).Visible = False

        End If

    End Sub
    Protected Sub gvBreeds_SelectedIndexChanged(sender As Object, e As EventArgs)
        'hndBreedID.value = gvBreeds.SelectedDataKey("BreedID")
        'txtBreedName.text = gvBreeds.SelectedDataKey("BreedName")
        'txtDescription.text = gvBreeds.SelectedDataKey("Description")
        'txtOrigin.text = gvBreeds.SelectedDataKey("Origin")
        'txtAverageSize.text = gvBreeds.SelectedDataKey("AverageSize")
        'txtAverageLifespan.text = gvBreeds.SelectedDataKey("AverageLifespan")

        'ModalPopupExtender2.SHOW()
        'btnSAVEBreed.text = "UPDATE"


        ' Retrieve selected data key values
        Dim selectedKey As DataKey = gvBreeds.SelectedDataKey

        ' Check if a valid selection is made
        If selectedKey IsNot Nothing Then
            ' Update form controls with selected values
            With selectedKey
                hndBreedID.Value = .Item("BreedID").ToString()
                txtBreedName.Text = .Item("BreedName").ToString()
                txtDescription.Text = .Item("Description").ToString()
                txtOrigin.Text = .Item("Origin").ToString()
                txtAverageSize.Text = .Item("AverageSize").ToString()
                txtAverageLifespan.Text = .Item("AverageLifespan").ToString()
            End With

            ' Show the modal popup
            ModalPopupExtender2.Show()

            ' Set the button text to "UPDATE"
            btnSAVEBreed.Text = "UPDATE"
        End If
    End Sub

#Region "livestock breed"
    Protected Sub btnClearBreed_Click(sender As Object, e As EventArgs)
        txtBreedName.Text = String.Empty
        txtOrigin.Text = String.Empty
        txtAverageLifespan.Text = String.Empty
        txtDescription.Text = String.Empty
        txtAverageSize.Text = String.Empty

        hndBreedID.Value = String.Empty
        'btnSAVEBreed.Text = "SAVE"
        ModalPopupExtender2.Show()
    End Sub
    Protected Sub btnCloseBreed_Click(sender As Object, e As EventArgs)
        btnSAVEBreed.text = "SAVE"
        ModalPopupExtender2.Hide()
    End Sub
    Public Sub SaveBreed()


        objDerived.GetRecords("INSERT INTO dbo.Breed (BreedName,Description,Origin,AverageSize,AverageLifespan)VALUES('" _
                              & txtBreedName.text & "','" & txtDescription.text & "','" & txtOrigin.text & "','" _
                              & txtAverageSize.text & "','" & txtAverageLifespan.text & "') ", CommandType.Text)
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Breed has been successfully saved.")
        LoadBreed()

    End Sub
    Public Sub UpdateBreed()
        If hndBreedID.value = "" Then
        Else
            objDerived.GetRecords("UPDATE dbo.Breed SET BreedName ='" & txtBreedName.text & "',Description = '" & txtDescription.text & "',Origin = '" & txtOrigin.text & "',AverageSize = '" & txtAverageSize.text & "',AverageLifespan = '" & txtAverageLifespan.text & "' WHERE BreedID = '" & hndBreedID.value & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Breed has been successfully Update.")
            LoadBreed()
            btnSAVEBreed.text = "SAVE"
        End If

    End Sub
    Protected Sub btnSAVEBreed_Click(sender As Object, e As EventArgs)
        If btnSAVEBreed.text = "SAVE" Then
            SaveBreed()
        Else
            UpdateBreed()
        End If


        ModalPopupExtender2.Hide()
    End Sub

    Protected Sub btnProceed_Click(sender As Object, e As EventArgs)
        Dim dt As DataTable
        If ViewState("Customers") IsNot Nothing Then
            dt = DirectCast(ViewState("Customers"), DataTable)
        Else
            Exit Sub
        End If

        ' Loop through GridView rows and save the data
        For Each row As GridViewRow In grdPropertyInfo.Rows
            Dim txtLivePropertyNo As TextBox = CType(row.FindControl("txtLivePropertyNo"), TextBox)
            Dim txtDateAquired As TextBox = CType(row.FindControl("txtDateAquired"), TextBox)
            Dim txtAge As TextBox = CType(row.FindControl("txtAge"), TextBox)
            Dim txtWeight As TextBox = CType(row.FindControl("txtWeight"), TextBox)
            Dim txtPrice As TextBox = CType(row.FindControl("txtPrice"), TextBox)

            ' Update DataTable with new values
            dt.Rows(row.RowIndex)("LivePropertyNo") = txtLivePropertyNo.Text
            dt.Rows(row.RowIndex)("DateAquired") = txtDateAquired.Text
            dt.Rows(row.RowIndex)("Age") = txtAge.Text
            dt.Rows(row.RowIndex)("Weight") = txtWeight.Text
            dt.Rows(row.RowIndex)("Amount") = txtPrice.Text

        Next

        ' Save back to ViewState
        ViewState("Customers") = dt

        ' Close the modal
        ModalPopupExtender1.Hide()
    End Sub
#End Region


    Protected Sub btnCancelProperty_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.hIDE()
    End Sub

    'LIVE PROPERTY TEXTBOX VALIDATOR
    Protected Sub txtPropertyNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim text As TextBox

        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            text = CType(Me.grdPropertyInfo.Rows(i).Cells(0).FindControl("txtLivePropertyNo"), TextBox)
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT a.Item_ID, b.PropertyNo FROM AMS.Property as a INNER JOIN AMS.Property_Dtl as b ON a.Property_ID = b.Property_ID WHERE  (b.PropertyNo = '" & text.Text & "')", CommandType.Text)

            If dt.Rows.Count > 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property No. is already exist!")
                text.Text = "" ' Clear the input field
            End If
        Next

        ' Keep the modal popup open
        ModalPopupExtender1.Show()
    End Sub




    Public Sub Save() 'TODO [Save_TbProperty_Ledger]?? > AMS.TbProperty_Ledger 
        Dim a As String
        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            'msgbox(CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text)

            If CType(grdPropertyInfo.Rows(i).FindControl("txtLivePropertyNo"), TextBox).Text = "" Then
                a = ""
            Else
                a = 1
            End If
        Next

        If a = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please Fill Up the Property Information Fields")
            Exit Sub
        End If
        With item
            .Item_Code = ""
            .Item_Desc = txtDescriptionLivestock.Text
            .Unit_ID = 0
        End With

        Dim itemid As Integer

        itemid = item.save()
        objDerived.Execute("exec [dbo].[spSave_m_item_detail] '0','" & itemid & "','" & 0 & "',null", CommandType.Text)

        Dim classification As String = objDerived.GetValue("EXEC [dbo].[usp_GetClassificationIdByClassificationName] ", CommandType.Text)

        'objDerived.GetValue("select  a.ClassificationId From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%'", CommandType.Text)
        Dim category As Integer = objDerived.GetValue("select a.item_particular_id  From dbo.m_item as a inner join ams.item_particular as b on a.item_particular_id = b.item_particular_id where a.Item_ID =" & itemid, CommandType.Text)
        Dim gaid As Integer = objDerived.GetValue("EXEC [AMS].[LivestockGA_ID] ", CommandType.Text)
        'objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%' ", CommandType.Text)
        Dim matrix As String = objDerived.GetValue("select id From tblclassmatrix where classificationid = " & classification & " and ga_id = " & gaid & " and item_id = " & itemid & "", CommandType.Text)

        If matrix = "" Then
            objDerived.Execute("insert into tblclassmatrix(classificationid,ga_id,item_id,categoryid,bga_id) values('" & classification & "','" & gaid & "','" & itemid & "','" & category & "','0')", CommandType.Text)
        End If

        With Prop_Hdr
            '.Property_ID = Property_ID
            .Property_Date = Date.Today.ToString("MM/dd/yyyy")
            .Issuance = 0
            .Remarks = "Manual Encoding of Old Properties"
            .Emp_ID = 0
            .F_ID = 1
            .AIRDtl_ID = 0
            .deptid = 0
            .isDonated = False
            .GA_ID = gaid
            'objDerived.GetValue("select b.GA_ID  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%' ", CommandType.Text)

            .DonationRemarks = ""
            .Qty = 1
            .Balance = txtQuantity.Text
            .Cost = 0
            .Item_ID = itemid
            .Property_code = objDerived.GetValue("EXEC [AMS].[GetLivestockGACodes] ", CommandType.Text)
            'objDerived.GetValue("select ga_code  From dbo.tbl_Classification as a inner join dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid inner join geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id  = b.GA_ID   where a.ClassificationName  like '%Machinery%' ", CommandType.Text)
            .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
            .Function_ID = 86
            .TD_ID = 1
            .Project_ID = 0
            .Program_id = 0
            .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & itemid & "' ", CommandType.Text)
        End With
        Dim PropHdr_ID As Integer = 0
        PropHdr_ID = Prop_Hdr.save()

        objDerived.GetRecords("UPDATE AMS.Property SET JEV_Number = ' ' WHERE Property_ID = '" & PropHdr_ID & "'", CommandType.Text)

        For i As Integer = 0 To grdPropertyInfo.Rows.Count - 1
            With Prop_Dtl
                .PropertyNo = CType(grdPropertyInfo.Rows(i).FindControl("txtLivePropertyNo"), TextBox).Text
                .Property_ID = PropHdr_ID
                .Issued = False
                .Repair = False
                .Dispose = False
                .DisposeDate = "1/1/1900"
                .IsInspectionForDisposal = False
                .InspectionDate = CType(grdPropertyInfo.Rows(i).FindControl("txtDateAquired"), TextBox).Text 'TODO Conversion from string "" to type 'Date' is not valid.'

                .F_ID = 1
                .SerialNo = ""
                .Barcode = " "
                .Amount = CType(grdPropertyInfo.Rows(i).FindControl("txtPrice"), TextBox).Text
                .Status = "Accepted"
                .type = "Livestock"
                .RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                .Function_ID = 86
                .AccountablePerson = ""
                .Age = CType(grdPropertyInfo.Rows(i).FindControl("txtAge"), TextBox).Text
            End With

            Dim PropDtl_ID As Integer
            PropDtl_ID = Prop_Dtl.save()

            'UPDATE PROPERTY DETAIL objDerived

            With ObjLivestock_Info
                .PropDtl_ID = PropDtl_ID
                .SubClassification_ID = Convert.ToInt32(drpSubClassification.Text)
                .Breed_ID = Convert.ToInt32(drpBreed.Text)
                .Description = txtDescriptionLivestock.Text
                .Quantity = Convert.ToInt32(txtQuantity.Text)
                .SourceOfLivestock = txtSourceofLivestock.Text
                .Remarks = txtRemarks.Text
            End With


            ObjLivestock_Info.save()

            'objDerived.Execute("insert into dbo.Livestock_Info (Sub_Classification_ID,PropDtl_ID,Breed_ID,Description,Quantity,Source_of_Livestock,Remarks)VALUES('" _
            '                   & drpSubClassification.SelectedValue & "','" _
            '                   & PropDtl_ID & "','" _
            '                   & drpBreed.SelectedValue & "','" _
            '                   & txtDescriptionLivestock.Text & "','" _
            '                   & txtQuantity.Text & "','" & txtSourceofLivestock.Text & "','" & txtRemarks.Text & "')", CommandType.Text)

            With Prop_Ledger
                .Ledger_ID = 0
                .PropertyNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtPropertyNo"), TextBox).Text
                .SerialNo = "" 'CType(grdPropertyInfo.Rows(i).FindControl("txtSerialNumber"), TextBox).Text
                .Trans_Type = "Manual Entry"
                .dDate = Date.Today.ToString("MM/dd/yyyy")
                .Ref = ""
                .AccountablePerson = ""
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                .Item_ID = itemid
                .DebitQty = txtQuantity.Text

                'TODO TEMPORARY SOLUTION AS the tables is designed to create each property, but the livestock have individual price instead of 1 for all
                'txt price should be inside each row but then the ledger will be created twice individualy( 1 row is 2 insert)
                .DebitCost = txtQuantity.Text * CType(grdPropertyInfo.Rows(0).FindControl("txtPrice"), TextBox).Text

                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & itemid & "'", CommandType.Text)
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & itemid & "'", CommandType.Text)

                Dim Eqty As Integer
                Dim Eqbalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    Eqty = 0
                    Eqbalance = 0.0
                Else
                    Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
                    Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & itemid & "'", CommandType.Text)
                End If

                Dim balanceCost As Decimal
                a = CType(grdPropertyInfo.Rows(0).FindControl("txtPrice"), TextBox).Text
                Decimal.TryParse(a, balanceCost)

                .BalanceQty = Eqty + txtQuantity.Text
                .BalanceCost = balanceCost

            End With
            Prop_Ledger.save()
        Next




        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        loadEquipmentLedger()

        btnSave.Enabled = False

    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save()
    End Sub
    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdPropertyInfo.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim txtLivePropertyNo As TextBox = CType(e.Row.FindControl("txtLivePropertyNo"), TextBox)
            Dim txtDateAquired As TextBox = CType(e.Row.FindControl("txtDateAquired"), TextBox)
            Dim txtAge As TextBox = CType(e.Row.FindControl("txtAge"), TextBox)
            Dim txtWeight As TextBox = CType(e.Row.FindControl("txtWeight"), TextBox)
            Dim txtPrice As TextBox = CType(e.Row.FindControl("txtPrice"), TextBox)

            ' Restore previously selected value if available
            Dim dt As DataTable = DirectCast(ViewState("Customers"), DataTable)

            If dt IsNot Nothing AndAlso e.Row.RowIndex < dt.Rows.Count Then
                txtLivePropertyNo.Text = dt.Rows(e.Row.RowIndex)("LivePropertyNo").ToString()
                txtDateAquired.Text = dt.Rows(e.Row.RowIndex)("DateAquired").ToString()
                txtAge.Text = dt.Rows(e.Row.RowIndex)("Age").ToString()
                txtWeight.Text = dt.Rows(e.Row.RowIndex)("Weight").ToString()
                txtPrice.Text = dt.Rows(e.Row.RowIndex)("Amount").ToString()
            End If
        End If
    End Sub
    Protected Sub clearLivestockBtn_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        drpSubClassification.SelectedIndex = -1
        txtDescription.Text = String.Empty
        drpBreed.SelectedIndex = -1
        txtDescriptionLivestock.Text = String.Empty
        txtQuantity.Text = String.Empty
        txtSourceofLivestock.Text = String.Empty
        txtRemarks.Text = String.Empty


    End Sub
End Class
