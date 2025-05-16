Imports System.Data
Partial Class Inventory_Disposal_Disposal_WasteMaterials
    Inherits System.Web.UI.Page
    Private obj As New AccessRule
    Private objDerived As New DerivedDal

    Private Property dtPropertyList() As DataTable
        Get
            Return CType(Session("dtPropertyList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPropertyList") = value
        End Set
    End Property
    Private Property dtParts() As DataTable
        Get
            Return CType(Session("dtParts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtParts") = value
        End Set
    End Property
    Private Property dtWaste() As DataTable
        Get
            Return CType(Session("dtWaste"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtWaste") = value
        End Set
    End Property

    Public Function tempTable_PropertyList(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Integer))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("ItemDesc", GetType(String))
        dt.Columns.Add("UnitDesc", GetType(String))
        dt.Columns.Add("UnitCost", GetType(Decimal))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PropertyDetai_ID") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("POHdr_ID") = DBNull.Value
            dr("PO_No") = DBNull.Value
            dr("ItemDesc") = DBNull.Value
            dr("UnitDesc") = DBNull.Value
            dr("UnitCost") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function tempTable_Parts(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("parts_id", GetType(Integer))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("unit", GetType(String))
        dt.Columns.Add("Qty", GetType(Decimal))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("parts_id") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("unit") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub Inventory_Disposal_Disposal_WasteMaterials_Load(sender As Object, e As EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@username"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then
            LoadPage()

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
        txtCost.Attributes.Add("onclick", "HighlightAll(this);")
        txtAppraisedValue.Attributes.Add("onclick", "HighlightAll(this);")

    End Sub

    Protected Sub LoadPage()
        drpDepartment.DataSource = objDerived.GetDataTable("SELECT RC_ID, RC_Name FROM DBO.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
        drpDepartment.DataTextField = ("RC_Name")
        drpDepartment.DataValueField = ("RC_ID")
        drpDepartment.DataBind()
        drpDepartment.Items.Insert(0, "Select")

        drpGenAccount.DataSource = objDerived.GetDataTable("SELECT (A.GA_Code2 + ' - ' + A.GA_Title2) AS GA_Title, A.GA_ID, A.BGA_ID, A.GA_Code, A.GA_Code2  FROM AMS.View_AccountList AS A WHERE A.AllotmentClass_ID = 3 AND A.BGA_ID = 0 ORDER BY A.GA_Title, A.GA_Code2", CommandType.Text)
        drpGenAccount.DataTextField = ("GA_Title")
        drpGenAccount.DataValueField = ("GA_ID")
        drpGenAccount.DataBind()
        drpGenAccount.Items.Insert(0, "Select")

        grdPropertyList.DataSource = tempTable_PropertyList(4)
        grdPropertyList.DataBind()

        grdParts.DataSource = tempTable_Parts(4)
        grdParts.DataBind()

        dtWaste = Nothing
        grdForWaste.DataSource = Nothing
        grdForWaste.DataBind()

    End Sub
    Private Sub drpDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpDepartment.SelectedIndexChanged
        drpFunction.DataSource = objDerived.GetDataTable("SELECT Function_ID, Function_Desc FROM DBO.View_RespCenter_withFunctions WHERE RC_ID = '" & drpDepartment.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        drpFunction.DataTextField = ("Function_Desc")
        drpFunction.DataValueField = ("Function_ID")
        drpFunction.DataBind()
        drpFunction.Items.Insert(0, "Select")
    End Sub
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try

            If drpDepartment.SelectedItem.Text = "Select" Or drpFunction.SelectedItem.Text = "Select" Or drpGenAccount.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select department, function and account to view properties.")

            Else
                dtPropertyList = objDerived.GetDataTable("EXEC [AMS].[sp_WasteMaterials_PropertyList] '" & drpDepartment.SelectedItem.Value & "','" & drpFunction.SelectedItem.Value & "','" & drpGenAccount.SelectedItem.Value & "'", CommandType.Text)
                If dtPropertyList.Rows.Count < 5 Then
                    dtPropertyList.Merge(tempTable_PropertyList(4 - dtPropertyList.Rows.Count))
                End If
                grdPropertyList.DataSource = dtPropertyList
                grdPropertyList.DataBind()
                grdPropertyList.SelectedIndex = -1

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try

            Dim myview As DataView
            myview = dtPropertyList.DefaultView

            If drpSearchBy.SelectedItem.Value = 2 Then
                myview.RowFilter = "PO_No like '%" & replaceapostrophe(txtSearch.Text) & "%'"
            Else
                myview.RowFilter = "ItemDesc like '%" & replaceapostrophe(txtSearch.Text) & "%'"

            End If

            grdPropertyList.DataSource = myview
            grdPropertyList.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdPropertyList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdPropertyList.PageIndexChanging
        grdPropertyList.DataSource = dtPropertyList
        grdPropertyList.PageIndex = e.NewPageIndex
        grdPropertyList.DataBind()
    End Sub
    Private Sub grdPropertyList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPropertyList.SelectedIndexChanged
        Try
            dtParts = objDerived.GetDataTable("SELECT A.description, A.unit, ISNULL(A.cost,0) AS cost, A.qty, A.parts_id, CONVERT(BIT,1) AS isVisible   " &
                                              "  FROM AMS.tbl_equip_parts AS A INNER JOIN AMS.PO_Dtl AS B ON A.PODtl_ID = B.PODtl_ID                    " &
                                              "  INNER JOIN AMS.Property AS C ON B.POHdr_ID = C.POHdr_ID AND B.Item_ID = C.Item_ID                      " &
                                              "  INNER JOIN AMS.Property_Dtl AS D ON C.Property_ID = D.Property_ID                                      " &
                                              "  WHERE D.PropertyDetai_ID = '" & grdPropertyList.SelectedDataKey("PropertyDetai_ID") & "' ORDER BY A.description", CommandType.Text)
            If dtParts.Rows.Count < 5 Then
                dtParts.Merge(tempTable_Parts(4 - dtParts.Rows.Count))
            End If
            grdParts.DataSource = dtParts
            grdParts.DataBind()
            grdParts.SelectedIndex = -1

            btnAddParts.Enabled = True
            LoadDetails()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Protected Sub LoadDetails()
        txtDate.Text = Date.Today.ToShortDateString

        drpCertifiedby.DataSource = objDerived.GetDataTable("SELECT Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = 7 AND division_Key = 86 ORDER BY Full_Name", CommandType.Text)
        drpCertifiedby.DataTextField = "Full_Name"
        drpCertifiedby.DataValueField = "EmpID"
        drpCertifiedby.DataBind()
        drpCertifiedby.Items.Insert(0, "Select")

        drpInspector.DataSource = objDerived.GetDataTable("SELECT Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = 7 AND division_Key = 86 ORDER BY Full_Name", CommandType.Text)
        drpInspector.DataTextField = "Full_Name"
        drpInspector.DataValueField = "EmpID"
        drpInspector.DataBind()
        drpInspector.Items.Insert(0, "Select")

        drpApprovedby.DataSource = objDerived.GetDataTable("SELECT Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = 7 AND division_Key = 86 AND isDeptHead = 'Yes' ORDER BY Full_Name", CommandType.Text)
        drpApprovedby.DataTextField = "Full_Name"
        drpApprovedby.DataValueField = "EmpID"
        drpApprovedby.DataBind()

        grdForWaste.Dispose()
        grdForWaste.DataSource = Nothing
        grdForWaste.DataBind()

        txtCtrlNo.Text = "WMR-" & CType(Year(txtDate.Text), String) & "-"
        txtStorage.Text = ""
        txtTransfer.Text = ""
        txtWitness.Text = ""

    End Sub
    Private Sub grdParts_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdParts.PageIndexChanging
        grdParts.DataSource = dtParts
        grdParts.PageIndex = e.NewPageIndex
        grdParts.DataBind()
    End Sub
    Private Sub grdParts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdParts.SelectedIndexChanged
        txtDesc.Text = ""
        txtQty.Text = ""
        txtUnit.Text = ""
        txtCost.Text = "0.00"
        txtAppraisedValue.Text = "0.00"
    End Sub
    Private Sub btnAddParts_Click(sender As Object, e As EventArgs) Handles btnAddParts.Click
        Try


            Dim dt As New DataTable
            Dim dr As DataRow

            If grdForWaste.Rows.Count = Nothing Then
                dt.Columns.Add("PropertyDetai_ID", GetType(Integer))
                dt.Columns.Add("description", GetType(String))
                dt.Columns.Add("qty", GetType(Decimal))
                dt.Columns.Add("unit", GetType(String))
                dt.Columns.Add("OR", GetType(String))
                dt.Columns.Add("cost", GetType(Decimal))
                dt.Columns.Add("AppValue", GetType(Decimal))

                dr = dt.NewRow

                If txtDesc.Text = "" Then
                    dr("PropertyDetai_ID") = grdPropertyList.SelectedDataKey("PropertyDetai_ID")
                    dr("description") = grdParts.SelectedDataKey("description")
                    dr("qty") = CType(grdParts.SelectedRow.Cells(3).FindControl("txtWasteQty"), TextBox).Text
                    dr("unit") = grdParts.SelectedDataKey("unit")
                    dr("OR") = ""
                    dr("cost") = 0
                    dr("AppValue") = CType(grdParts.SelectedDataKey("cost"), Decimal)


                Else
                    dr("PropertyDetai_ID") = grdPropertyList.SelectedDataKey("PropertyDetai_ID")
                    dr("description") = replaceapostrophe(txtDesc.Text)
                    dr("qty") = txtQty.Text
                    dr("unit") = replaceapostrophe(txtUnit.Text)
                    dr("OR") = ""
                    dr("cost") = 0
                    dr("AppValue") = CType(txtAppraisedValue.Text, Decimal)

                End If

                dt.Rows.Add(dr)

                dtWaste = dt

            Else
                dt = dtWaste
                dr = dt.NewRow

                If txtDesc.Text = "" Then
                    dr("PropertyDetai_ID") = grdPropertyList.SelectedDataKey("PropertyDetai_ID")
                    dr("description") = grdParts.SelectedDataKey("description")
                    dr("qty") = CType(grdParts.SelectedRow.Cells(3).FindControl("txtWasteQty"), TextBox).Text
                    dr("unit") = grdParts.SelectedDataKey("unit")
                    dr("OR") = ""
                    dr("cost") = 0
                    dr("AppValue") = CType(txtAppraisedValue.Text, Decimal)

                Else
                    dr("PropertyDetai_ID") = grdPropertyList.SelectedDataKey("PropertyDetai_ID")
                    dr("description") = replaceapostrophe(txtDesc.Text)
                    dr("qty") = txtQty.Text
                    dr("unit") = replaceapostrophe(txtUnit.Text)
                    dr("OR") = ""
                    dr("cost") = 0
                    dr("AppValue") = CType(txtAppraisedValue.Text, Decimal)

                End If

                dt.Rows.Add(dr)
                dtWaste = dt

            End If

            grdForWaste.DataSource = dtWaste
            grdForWaste.DataBind()
            grdParts.SelectedIndex = -1

            txtDesc.Text = ""
            txtQty.Text = ""
            txtUnit.Text = ""
            txtCost.Text = "0.00"
            txtAppraisedValue.Text = "0.00"

            btnSaveWaste.Enabled = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No Data Found.")
        End Try
    End Sub

    Private Sub btnSaveWaste_Click(sender As Object, e As EventArgs) Handles btnSaveWaste.Click
        Try

            If drpCertifiedby.SelectedItem.Text = "Select" Or drpInspector.SelectedItem.Text = "Select" Or drpApprovedby.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory to proceed.")

            ElseIf dtWaste.Rows.Count = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No Data Found.")

            Else
                Dim ctr_no As String = objDerived.GetValue("SELECT [AMS].[func_Generate_WMR] ('" & txtDate.Text & "')", CommandType.Text)

                objDerived.Execute("INSERT INTO [AMS].[WMR_Hdr] ([WM_Date],[ctrl_no],[Placeofstorage],[Certifiedby],[Approvedby],[Inspector],[Witness],[POHdr_ID],[isPosted],[DisposeAs],[TransferTo],[RC_ID],[Function_ID],[PropertyDetai_ID],[UserID]) " &
                                     "  VALUES                                                  " &
                                     "  ('" & txtDate.Text & "'                                 " &
                                     "  ,'" & ctr_no & "'                                       " &
                                     "  ,'" & replaceapostrophe(txtStorage.Text) & "'           " &
                                     "  ,'" & drpCertifiedby.SelectedItem.Value & "'            " &
                                     "  ,'" & drpApprovedby.SelectedItem.Value & "'             " &
                                     "  ,'" & drpInspector.SelectedItem.Value & "'              " &
                                     "  ,'" & replaceapostrophe(txtWitness.Text) & "'           " &
                                     "  ,'" & grdPropertyList.SelectedDataKey("POHdr_ID") & "'  " &
                                     "  ,0                                                      " &
                                     "  ,'" & rbDispose.SelectedItem.Text & "'                  " &
                                     "  ,'" & replaceapostrophe(txtTransfer.Text) & "'          " &
                                     "  ,'" & drpDepartment.SelectedItem.Value & "'             " &
                                     "  ,'" & drpFunction.SelectedItem.Value & "'               " &
                                     "  ,'" & grdPropertyList.SelectedDataKey("PropertyDetai_ID") & "' " &
                                     " , '" & Session("@username") & "')", CommandType.Text)


                Session("WMHdr_ID") = objDerived.GetValue("SELECT TOP(1) WMHdr_ID FROM AMS.WMR_Hdr ORDER BY WMHdr_ID DESC", CommandType.Text)

                For i As Integer = 0 To dtWaste.Rows.Count - 1
                    objDerived.Execute("INSERT INTO [AMS].[WMR_Dtl] ([WMHdr_ID],[description],[unit],[qty],[or_no],[amount],[AppraisedValue])    " &
                                           " VALUES                                                                             " &
                                           " ('" & Session("WMHdr_ID") & "'                                                     " &
                                           " ,'" & dtWaste.Rows(i)("description") & "'                                          " &
                                           " ,'" & dtWaste.Rows(i)("unit") & "'                                                 " &
                                           " ,'" & dtWaste.Rows(i)("qty") & "'                                                  " &
                                           " ,'" & CType(grdForWaste.Rows(i).FindControl("txtOR"), TextBox).Text & "'           " &
                                           " ,'" & CType(CType(grdForWaste.Rows(i).FindControl("txtCost"), TextBox).Text, Decimal) & "'     " &
                                           " ,'" & CType(CType(grdForWaste.Rows(i).FindControl("txtAppValue"), TextBox).Text, Decimal) & "')", CommandType.Text)


                Next

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved. Control Number is : " & ctr_no)
                btnSaveWaste.Enabled = False
                btnPreview.Enabled = True

                LoadDetails()

            End If



        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub



    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Session("Page") = "Disposal"
        Session("Report") = "WMR"
        Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")
    End Sub

    Private Sub btnPreview_Summary_Click(sender As Object, e As EventArgs) Handles btnPreview_Summary.Click
        drpPreparedBy1.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE deptid = 7 AND division_Key = 86 ORDER BY Full_Name", CommandType.Text)
        drpPreparedBy1.DataValueField = "EmpID"
        drpPreparedBy1.DataTextField = "Full_Name"
        drpPreparedBy1.DataBind()
        drpPreparedBy1.Items.Insert(0, "Select")

        drpPreparedBy2.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE deptid = 7 AND division_Key = 86 ORDER BY Full_Name", CommandType.Text)
        drpPreparedBy2.DataValueField = "EmpID"
        drpPreparedBy2.DataTextField = "Full_Name"
        drpPreparedBy2.DataBind()
        drpPreparedBy2.Items.Insert(0, "Select")

        ModalPopupExtender1.Show()
    End Sub

    Private Sub btnPreview_SummaryWMR_Click(sender As Object, e As EventArgs) Handles btnPreview_SummaryWMR.Click

        If drpPreparedBy1.SelectedItem.Text = "Select" Or drpPreparedBy1.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatories.")
            ModalPopupExtender1.Show()
        Else
            Session("Page") = "Disposal"
            Session("Report") = "Summary_WMR"
            Session("Date") = Date.Today.ToShortDateString
            Session("PrepareBy1") = drpPreparedBy1.SelectedItem.Value
            Session("PrepareBy2") = drpPreparedBy2.SelectedItem.Value
            Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")
        End If

    End Sub
End Class
