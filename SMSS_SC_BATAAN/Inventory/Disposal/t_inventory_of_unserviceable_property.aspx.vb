Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class t_inventory_of_unserviceable_property
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim hdr As New IIRUPHdr
    Dim dtl As New IIRUPDtl
    Dim msg As New MsgeBox
    Dim obj As New AccessRule


#Region "property"
    Private Property pItems() As DataTable
        Get
            Return CType(Session("pItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItems") = value
        End Set
    End Property

    Private Property myPview() As DataView
        Get
            Return CType(Session("myPview"), DataView)
        End Get
        Set(ByVal value As DataView)
            Session("myPview") = value
        End Set
    End Property

    Private Property mySview() As DataView
        Get
            Return CType(Session("mySview"), DataView)
        End Get
        Set(ByVal value As DataView)
            Session("mySview") = value
        End Set
    End Property

    Private Property pItemsProp() As DataTable
        Get
            Return CType(Session("pItemsProp"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItemsProp") = value
        End Set
    End Property

    Private Property pItemsSupp() As DataTable
        Get
            Return CType(Session("pItemsSupp"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItemsSupp") = value
        End Set
    End Property

    Private Property pBody() As DataTable
        Get
            Return CType(Session("pBody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBody") = value
        End Set
    End Property

    Private Property dtUSupply() As DataTable
        Get
            Return CType(Session("dtUSupply"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtUSupply") = value
        End Set
    End Property

    Private Property dtSupply() As DataTable
        Get
            Return CType(Session("dtSupply"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSupply") = value
        End Set
    End Property

    Private Property pOPen() As DataTable
        Get
            Return CType(Session("pOPen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pOPen") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            If Not Page.IsPostBack Then
                btnsave.Enabled = False

                dtSupply = Nothing
                grdSupply.DataSource = dtSupply
                grdSupply.DataBind()

                Me.mvUncerviceable.SetActiveView(Me.vwProperty)
                LoadPageLoad()


                txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
                txtSupSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSupSearch.ClientID & "')")
                txtSearchDesc.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchDesc.ClientID & "')")
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnSearchDesc_Click(sender As Object, e As EventArgs) Handles btnSearchDesc.Click
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.Columns(6).Visible = True

        Dim myview As DataView
        myview = pItems.DefaultView
        myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtSearchDesc.Text) & "%'"
        gvitems.DataSource = myview
        gvitems.DataBind()
        For i As Integer = 3 To 8
            gvitems.Columns(i).Visible = False
        Next

        'gvitems.Columns(3).Visible = False
        'gvitems.Columns(4).Visible = False
        'gvitems.Columns(5).Visible = False
        'gvitems.Columns(6).Visible = False
        'gvitems.Columns(7).Visible = False
        'gvitems.Columns(8).Visible = False

    End Sub


    Protected Sub LoadPageLoad()
        pBody = Nothing
        gvbody.DataSource = pBody
        gvbody.DataBind()
        txtdate.Text = Date.Today.ToString("MM/dd/yyyy")

        btnnew.Enabled = True
        btnopen.Enabled = True
        btnadd.Enabled = True
        btnpreview.Enabled = False

        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.Columns(6).Visible = True




        pItems = objDerived.GetDataTable("Exec [dbo].[sp_PropertyList_Unserviceable]", CommandType.Text)
        gvitems.DataSource = pItems
        gvitems.DataBind()

        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
        gvitems.Columns(8).Visible = False

    End Sub
    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.Columns(6).Visible = True

        'pItems = objDerived.GetDataTable("select * from  ams.ListofPropertyforInspection order by Property_Date", CommandType.Text)
        pItems = objDerived.GetDataTable("Exec [dbo].[sp_PropertyList_Unserviceable]", CommandType.Text)
        gvitems.PageIndex = e.NewPageIndex
        gvitems.DataSource = pItems
        gvitems.DataBind()

        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
        gvitems.Columns(8).Visible = False
        gvitems.SelectedIndex = -1

        'ModalPopupExtender1.Show()

    End Sub
    Protected Sub btnload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnload.Click

        Try
            Dim dt As New DataTable
            Dim dr As DataRow
            Dim cb As CheckBox

            Dim check As New DataTable
            check = pItems

            dt.Columns.Add("id", GetType(Integer))
            dt.Columns.Add("PropertyNo")
            dt.Columns.Add("Item_desc")
            dt.Columns.Add("cost", GetType(Decimal))
            dt.Columns.Add("Adep", GetType(Decimal))
            dt.Columns.Add("netval", GetType(Decimal))
            dt.Columns.Add("Property_ID", GetType(Integer))
            dt.Columns.Add("Property_Date", GetType(DateTime))
            dt.Columns.Add("RC_ID", GetType(Integer))
            dt.Columns.Add("FUNCTION_ID", GetType(Integer))

            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True

            If pBody Is Nothing Then
                For i As Integer = 0 To Me.pItems.Rows.Count - 1
                    '=== CHANGE 04112016
                    If pItems.Rows(i)("isChecked") = True Then
                        dr = dt.NewRow
                        dr("id") = 1
                        dr("PropertyNo") = pItems.Rows(i)("PropertyNo")
                        dr("Item_desc") = pItems.Rows(i)("Item_desc")
                        dr("cost") = pItems.Rows(i)("cost")

                        Dim acc, netval As Decimal
                        acc = objDerived.GetValue("select accuDepreciation from AMS.vw_ppe_depreciation_v2 where PropertyNo = '" & pItems.Rows(i)("PropertyNo") & "'", CommandType.Text)
                        netval = objDerived.GetValue("select bookvalue from AMS.vw_ppe_depreciation_v2 where PropertyNo = '" & pItems.Rows(i)("PropertyNo") & "'", CommandType.Text)

                        dr("Adep") = acc.ToString
                        dr("netval") = netval.ToString
                        dr("Property_ID") = pItems.Rows(i)("Property_ID")
                        dr("Property_Date") = pItems.Rows(i)("Property_Date")

                        Dim rc_id, functionid As Integer
                        rc_id = objDerived.GetValue("select RC_ID from AMS.Property_Dtl where PropertyNo = '" & pItems.Rows(i)("PropertyNo") & "'", CommandType.Text)
                        functionid = objDerived.GetValue("select Function_ID from AMS.Property_Dtl where PropertyNo = '" & pItems.Rows(i)("PropertyNo") & "'", CommandType.Text)



                        dr("RC_ID") = pItems.Rows(i)("RC_ID")
                        dr("FUNCTION_ID") = pItems.Rows(i)("FUNCTION_ID")

                        dt.Rows.Add(dr)

                        pItems.Rows(i)("isUsed") = True
                        pItems.Rows(i)("isChecked") = False
                    End If

                Next
                pBody = dt

            Else
                For i As Integer = 0 To Me.pItems.Rows.Count - 1
                    '=== NEW 041116
                    Dim dr2 As DataRow
                    'dt.Columns.Add("id", GetType(Long))
                    dt = pBody

                    If pItems.Rows(i)("isChecked") = True Then
                        dr2 = dt.NewRow
                        dr2("id") = 1
                        dr2("PropertyNo") = pItems.Rows(i)("PropertyNo")
                        dr2("Item_desc") = pItems.Rows(i)("Item_desc")
                        dr2("cost") = pItems.Rows(i)("cost")

                        Dim acc, netval As Decimal
                        acc = objDerived.GetValue("select accuDepreciation from AMS.vw_ppe_depreciation_v2 where PropertyNo = '" & pItems.Rows(i)("PropertyNo") & "'", CommandType.Text)
                        netval = objDerived.GetValue("select bookvalue from AMS.vw_ppe_depreciation_v2 where PropertyNo = '" & pItems.Rows(i)("PropertyNo") & "'", CommandType.Text)

                        dr2("Adep") = acc.ToString
                        dr2("netval") = netval.ToString
                        dr2("Property_ID") = pItems.Rows(i)("Property_ID")
                        dr2("Property_Date") = pItems.Rows(i)("Property_Date")

                        Dim rc_id, functionid As Integer
                        rc_id = objDerived.GetValue("select RC_ID from AMS.Property_Dtl where PropertyNo = '" & pItems.Rows(i)("PropertyNo") & "'", CommandType.Text)
                        functionid = objDerived.GetValue("select Function_ID from AMS.Property_Dtl where PropertyNo = '" & pItems.Rows(i)("PropertyNo") & "'", CommandType.Text)

                        dr2("RC_ID") = rc_id.ToString
                        dr2("FUNCTION_ID") = functionid.ToString

                        dt.Rows.Add(dr2)
                        pBody = dt
                        pItems.Rows(i)("isUsed") = True
                        pItems.Rows(i)("isChecked") = False
                    End If

                Next
                pBody = dt

            End If

            gvbody.DataSource = pBody
            gvbody.DataBind()

            '=== NEW 041116
            Dim myview As DataView
            myview = pItems.DefaultView
            myview.RowFilter = "isUsed = false"
            gvitems.DataSource = myview
            gvitems.DataBind()

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = False
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            gvitems.Columns(7).Visible = False
            gvitems.Columns(8).Visible = False

            btnsave.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'ModalPopupExtender1.Hide()
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            If rbChoice.SelectedItem.Value = 1 Then
                'Me.mvUncerviceable.SetActiveView(Me.vwProperty)

                If pBody.Rows.Count >= 1 Then
                    hdr.IIRUP_Date = txtdate.Text
                    hdr.RC_ID = pBody.Rows(0)("RC_ID")
                    hdr.FUNCTION_ID = pBody.Rows(0)("FUNCTION_ID")
                    Dim hdrid As Long = hdr.save

                    For i As Integer = 0 To pBody.Rows.Count - 1
                        dtl.IIRUPHdr_ID = hdrid
                        dtl.Property_ID = pBody.Rows(i)("Property_ID")
                        dtl.PropertyNo = pBody.Rows(i)("PropertyNo")
                        dtl.Property_Date = pBody.Rows(i)("Property_Date")
                        dtl.cost = pBody.Rows(i)("cost")
                        dtl.Adep = pBody.Rows(i)("Adep")
                        dtl.netval = pBody.Rows(i)("netval")
                        dtl.RC_ID = pBody.Rows(i)("RC_ID")
                        dtl.FUNCTION_ID = pBody.Rows(i)("FUNCTION_ID")
                        dtl.withQuote = False
                        dtl.save()
                        'objDerived.GetRecords("Update ams.property_dtl set IsInspectionForDisposal=1 where PropertyNo = '" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text)
                    Next

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                    txtdate.ReadOnly = True

                    btnnew.Enabled = True
                    btnopen.Enabled = True
                    btnsave.Enabled = False
                    btnadd.Enabled = False
                    btnpreview.Enabled = True

                    rbChoice.Enabled = False

                    Me.Session("TransID") = hdrid
                    Session("IIRUPHdr_ID") = hdrid
                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No records to save.")
                End If


            ElseIf rbChoice.SelectedItem.Value = 2 Then
                'Me.mvUncerviceable.SetActiveView(Me.vwSupply)

                If dtSupply.Rows.Count >= 1 Then

                    '=-= Save IIRUS Header
                    objDerived.Execute("INSERT INTO [AMS].[IIRUS_Hdr](IIRUS_Date,UserID,IsInspectioned) values('" & txtdate.Text & "','" & Session("@UserName") & "','" & False & "') ", CommandType.Text)
                    Dim hdrid As Long = objDerived.GetValue("SELECT MAX(IIRUS_ID) FROM [AMS].[IIRUS_Hdr]", CommandType.Text)
                    Session("IIRUS_ID") = hdrid

                    For i As Integer = 0 To dtSupply.Rows.Count - 1
                        '=-= Save IIRUS Details
                        Dim Eqty As Integer = CType(grdSupply.Rows(i).FindControl("txtqty"), TextBox).Text

                        objDerived.Execute("INSERT INTO [AMS].[IIRUS_Dtl](IIRUS_ID,StockID,StockDate,cost,Qty,withQuote) values('" & hdrid & "','" & dtSupply.Rows(i)("StockID") & "','" & dtSupply.Rows(i)("StockDate") & "','" & dtSupply.Rows(i)("cost") & "','" & Eqty & "','" & False & "') ", CommandType.Text)

                        Dim qty1 As Integer = objDerived.GetValue("SELECT Qty FROM AMS.Stock WHERE StockID = '" & dtSupply.Rows(i)("StockID") & "'", CommandType.Text)
                        Dim balance1 As Integer = objDerived.GetValue("SELECT Balance FROM AMS.Stock WHERE StockID = '" & dtSupply.Rows(i)("StockID") & "'", CommandType.Text)

                        Dim qty2 As Integer = qty1 - Eqty
                        Dim balance2 As Integer = balance1 - Eqty

                        objDerived.Execute("UPDATE AMS.Stock SET Balance = '" & balance2 & "' WHERE StockID = '" & dtSupply.Rows(i)("StockID") & "'", CommandType.Text)

                    Next

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


                    grdSupply.Enabled = False

                    btnsave.Enabled = False
                    btnadd.Enabled = False
                    btnpreview.Enabled = True
                    rbChoice.Enabled = False

                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No records to save.")
                End If

            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No records to save.")
        End Try

    End Sub

    Protected Sub btnnew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnew.Click

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.Columns(6).Visible = True

        Session("PropSearch") = 1

        Dim myview As DataView
        myview = pItems.DefaultView
        myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%' and isUsed = false"
        gvitems.DataSource = myview
        gvitems.DataBind()
        gvitems.PageIndex = 0

        'ModalPopupExtender1.Show()

        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
        gvitems.Columns(8).Visible = False

    End Sub

    Protected Sub btnSupSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        gvSupItems.Columns(4).Visible = True
        gvSupItems.Columns(5).Visible = True
        gvSupItems.Columns(6).Visible = True
        gvSupItems.Columns(7).Visible = True

        Dim myview As DataView
        myview = dtUSupply.DefaultView
        myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtSupSearch.Text.ToString) & "%' and isUsed = false"
        gvSupItems.DataSource = myview
        gvSupItems.DataBind()

        ModalPopupExtender2.Show()

        gvSupItems.Columns(4).Visible = False
        gvSupItems.Columns(5).Visible = False
        gvSupItems.Columns(6).Visible = False
        gvSupItems.Columns(7).Visible = False
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If CType(sender, CheckBox).Checked = True Then
        '    For i As Integer = 0 To Me.gvitems.Rows.Count - 1
        '        'item = Me.gvitems.Rows(i).Cells(1).Text
        '        Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
        '        If s.Enabled = True Then
        '            s.Checked = True
        '        End If
        '    Next
        'Else
        '    For i As Integer = 0 To Me.gvitems.Rows.Count - 1
        '        'item = Me.gvitems.Rows(i).Cells(1).Text
        '        Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
        '        s.Checked = False
        '    Next
        'End If


        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.Columns(6).Visible = True

        Dim cb2 As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb2.NamingContainer, GridViewRow)


        If cb2.Checked = True Then
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                pItems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(6).Text)("isChecked") = True
            Next

        Else
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                pItems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(6).Text)("isChecked") = False
            Next
        End If

        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
        gvitems.Columns(8).Visible = False

        'ModalPopupExtender1.Show()

    End Sub

    Public Sub CompareTwoDataTable(ByVal dt1 As DataTable, ByVal dt2 As DataTable)


        For i As Integer = 0 To dt2.Rows.Count - 1
            For o As Integer = 0 To dt1.Rows.Count - 1
                If dt2.Rows(i)("PropertyNo") = dt1.Rows(i)("PropertyNo") Then
                    dt1.Rows(i).Delete()
                    Exit For
                End If

            Next
        Next
        pItems = dt1

    End Sub

    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        Session("Report") = "ITB"
        Me.Page.Response.Redirect("~/MainReports/Disposal_Reports.aspx")

        'Dim url As String = "rpt_ITB.aspx?"
        'Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=800,left=250,top=100');"
        'ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub

    Protected Sub btnopen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnopen.Click

    End Sub
    Public Function CreatedatatableAddItems(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mycolumn As New DataColumn
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("Property_Date", GetType(Date))
        ' dt.Columns.Add("DocuID", GetType(Long))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PropertyNo") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("Property_Date") = DBNull.Value
            'dr("DocuID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If rbChoice.SelectedItem.Value = 1 Then

            Me.mvUncerviceable.SetActiveView(Me.vwProperty)
            'LoadPageLoad()
            ModalPopupExtender1.Show()

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            Me.mvUncerviceable.SetActiveView(Me.vwSupply)

            gvSupItems.Columns(4).Visible = False
            gvSupItems.Columns(5).Visible = False
            gvSupItems.Columns(6).Visible = False

            ModalPopupExtender2.Show()

        End If
    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If rbChoice.SelectedItem.Value = 1 Then
            Me.mvUncerviceable.SetActiveView(Me.vwProperty)
            Session("PropSearch") = 0

            btnpreview.Visible = True
            LoadPageLoad()

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            Me.mvUncerviceable.SetActiveView(Me.vwSupply)
            gvSupItems.Columns(7).Visible = True

            dtUSupply = objDerived.GetDataTable("EXEC [AMS].[sp_Unserviceable_Supply]", CommandType.Text)
            gvSupItems.DataSource = dtUSupply
            gvSupItems.DataBind()

            grdSupply.DataSource = Nothing
            grdSupply.DataBind()

            gvSupItems.Columns(7).Visible = False
            btnpreview.Visible = False
        End If
    End Sub

    Protected Sub btnLoadSupp_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Try

            gvSupItems.Columns(4).Visible = True
            gvSupItems.Columns(5).Visible = True
            gvSupItems.Columns(6).Visible = True
            gvSupItems.Columns(7).Visible = True

            'Dim dtsupp As New DataTable
            'Dim dr As DataRow
            'Dim cb As CheckBox

            'dtsupp.Columns.Add("Item_Desc", GetType(String))
            'dtsupp.Columns.Add("Unit", GetType(String))
            'dtsupp.Columns.Add("balance", GetType(Decimal))
            'dtsupp.Columns.Add("cost", GetType(Decimal))
            'dtsupp.Columns.Add("Item_ID", GetType(Long))
            'dtsupp.Columns.Add("StockID", GetType(Long))
            'dtsupp.Columns.Add("StockDate", GetType(String))

            'If dtSupply Is Nothing Then
            '    For i As Integer = 0 To dtUSupply.Rows.Count - 1
            '        '    MsgBox(gvSupItems.Rows(i)(1).text)
            '        If dtUSupply.Rows(i)("isChecked") = True Then
            '            dr = dtsupp.NewRow
            '            dr("Item_Desc") = dtUSupply.Rows(i)("Item_Desc")
            '            dr("Unit") = dtUSupply.Rows(i)("Unit")
            '            dr("balance") = dtUSupply.Rows(i)("balance")
            '            dr("cost") = dtUSupply.Rows(i)("cost")
            '            dr("Item_ID") = dtUSupply.Rows(i)("Item_ID")
            '            dr("StockID") = dtUSupply.Rows(i)("StockID")
            '            dr("StockDate") = dtUSupply.Rows(i)("StockDate")
            '            dtsupp.Rows.Add(dr)

            '            dtUSupply.Rows(i)("isUsed") = True
            '            dtUSupply.Rows(i)("isChecked") = False
            '        End If
            '    Next
            '    dtSupply = dtsupp

            'Else
            '    For i As Integer = 0 To dtUSupply.Rows.Count - 1
            '        'cb = CType(Me.gvSupItems.Rows(i).Cells(0).FindControl("cbSupp"), CheckBox)
            '        'If cb.Checked = True Then

            '        If dtUSupply.Rows(i)("isChecked") = True Then
            '            dtsupp = dtSupply
            '            dr = dtsupp.NewRow
            '            dr("Item_Desc") = dtUSupply.Rows(i)("Item_Desc")
            '            dr("Unit") = dtUSupply.Rows(i)("Unit")
            '            dr("balance") = dtUSupply.Rows(i)("balance")
            '            dr("cost") = dtUSupply.Rows(i)("cost")
            '            dr("Item_ID") = dtUSupply.Rows(i)("Item_ID")
            '            dr("StockID") = dtUSupply.Rows(i)("StockID")
            '            dr("StockDate") = dtUSupply.Rows(i)("StockDate")

            '            dtsupp.Rows.Add(dr)

            '            dtUSupply.Rows(i)("isUsed") = True
            '            dtUSupply.Rows(i)("isChecked") = False
            '        End If
            '    Next

            '    dtSupply = dtsupp

            'End If
            'Optimize
            Dim dtsupp As New DataTable
            Dim dr As DataRow
            Dim selectedRows As New List(Of Integer)

            dtsupp.Columns.Add("Item_Desc", GetType(String))
            dtsupp.Columns.Add("Unit", GetType(String))
            dtsupp.Columns.Add("balance", GetType(String))
            dtsupp.Columns.Add("cost", GetType(Decimal))
            dtsupp.Columns.Add("Item_ID", GetType(Long))
            dtsupp.Columns.Add("StockID", GetType(Long))
            dtsupp.Columns.Add("StockDate", GetType(String))

            For Each row As DataRow In dtUSupply.Rows
                If row.Field(Of Boolean)("isChecked") Then
                    dr = dtsupp.NewRow
                    dr("Item_Desc") = row.Field(Of String)("Item_Desc")
                    dr("Unit") = row.Field(Of String)("Unit")
                    dr("balance") = row.Field(Of String)("balance")
                    dr("cost") = row.Field(Of Decimal)("cost")
                    dr("Item_ID") = row.Field(Of Long)("Item_ID")
                    dr("StockID") = row.Field(Of Long)("StockID")
                    dr("StockDate") = row.Field(Of String)("StockDate")
                    dtsupp.Rows.Add(dr)

                    selectedRows.Add(dtUSupply.Rows.IndexOf(row))
                End If
            Next

            If dtSupply Is Nothing Then
                dtSupply = dtsupp
            Else
                For Each index As Integer In selectedRows
                    dtUSupply.Rows(index)("isUsed") = True
                    dtUSupply.Rows(index)("isChecked") = False
                Next
                dtSupply.Merge(dtsupp)
            End If


            grdSupply.Columns(4).Visible = True

            grdSupply.DataSource = dtSupply
            grdSupply.DataBind()

            grdSupply.Columns(4).Visible = False

            Dim myview As DataView
            myview = dtUSupply.DefaultView
            myview.RowFilter = "isUsed = false"
            gvSupItems.DataSource = myview
            gvSupItems.DataBind()

            gvSupItems.Columns(4).Visible = False
            gvSupItems.Columns(5).Visible = False
            gvSupItems.Columns(6).Visible = False
            gvSupItems.Columns(7).Visible = False

            btnsave.Enabled = True

            ModalPopupExtender2.Hide()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cbAllSupp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.gvSupItems.Rows.Count - 1
                Dim s As CheckBox = CType(Me.gvSupItems.Rows(i).Cells(0).FindControl("cbSupp"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.gvSupItems.Rows.Count - 1

                Dim s As CheckBox = CType(Me.gvSupItems.Rows(i).Cells(0).FindControl("cbSupp"), CheckBox)
                s.Checked = False
            Next
        End If

        ModalPopupExtender2.Show()

    End Sub

    Protected Sub gvitems_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.Columns(6).Visible = True

        Dim myview As DataView
        myview = pItems.DefaultView

        If Session("PropSearch") = 0 Then
            myview.RowFilter = "isUsed = false"
        ElseIf Session("PropSearch") = 1 Then
            myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%' and isUsed = false"
        End If

        gvitems.DataSource = myview
        gvitems.PageIndex = e.NewPageIndex
        gvitems.DataBind()

        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
        gvitems.Columns(8).Visible = False
        'ModalPopupExtender1.Show()
    End Sub

    Protected Sub gvSupItems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        gvSupItems.Columns(7).Visible = True

        gvSupItems.PageIndex = e.NewPageIndex
        gvSupItems.DataSource = CType(dtUSupply, DataTable)
        gvSupItems.DataBind()

        gvSupItems.Columns(7).Visible = False
        ModalPopupExtender2.Show()
    End Sub

    Protected Sub cbSupp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        gvSupItems.Columns(4).Visible = True
        gvSupItems.Columns(5).Visible = True
        gvSupItems.Columns(6).Visible = True
        gvSupItems.Columns(7).Visible = True


        Dim cb As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)

        If cb.Checked = True Then
            dtUSupply.Rows(Me.gvSupItems.Rows(gvr.RowIndex).Cells(7).Text)("isChecked") = True
            ' MsgBox(dtUSupply.Rows(Me.gvSupItems.Rows(gvr.RowIndex).Cells(7).Text)("Item_Desc"))
            'dtUSupply.Rows(i)()
        Else
            dtUSupply.Rows(Me.gvSupItems.Rows(gvr.RowIndex).Cells(7).Text)("isChecked") = False
        End If

        ModalPopupExtender2.Show()

        gvSupItems.Columns(4).Visible = False
        gvSupItems.Columns(5).Visible = False
        gvSupItems.Columns(6).Visible = False
        gvSupItems.Columns(7).Visible = False
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.Columns(6).Visible = True

        Dim cb2 As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb2.NamingContainer, GridViewRow)

        If cb2.Checked = True Then
            pItems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(6).Text)("isChecked") = True
        Else
            pItems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(6).Text)("isChecked") = False
        End If

        'ModalPopupExtender1.Show()

        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
        gvitems.Columns(8).Visible = False
    End Sub


    Protected Sub txtqty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtqty As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)

        Dim BalQty As Decimal = CType(grdSupply.Rows(gvr.RowIndex).FindControl("lblBalance"), Label).Text

        If BalQty >= txtqty.Text Then
            txtqty.Text = FormatNumber(txtqty.Text, 0)
        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Available Quantity is " & BalQty & ".")
            txtqty.Text = FormatNumber(BalQty, 0)
        End If


    End Sub


End Class
