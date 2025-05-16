Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class bidding_t_repeatorderapproval
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule


#Region "Property"
    Dim countgrdItemList As Integer
    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems "), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems ") = value
        End Set
    End Property

    Private Property dtApprovedby() As DataTable
        Get
            Return CType(Session("dtApprovedby "), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtApprovedby ") = value
        End Set
    End Property

    Private Property dtAbstract() As DataTable
        Get
            Return CType(Session("dtAbstract"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAbstract") = value
        End Set
    End Property
#End Region
#Region "Tables"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("Hdr_ID", GetType(Long))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("Canvass_Date", GetType(Date))
        dt.Columns.Add("withWinner", GetType(Boolean))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("isWinner", GetType(Boolean))
        dt.Columns.Add("isApproved", GetType(Boolean))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("Hdr_ID") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("Canvass_Date") = DBNull.Value
            dr("withWinner") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("isWinner") = DBNull.Value
            dr("isApproved") = DBNull.Value
            dr("isVisible") = False

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function CreateTable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Hdr_ID", GetType(Long))
        dt.Columns.Add("Supplier_ID", GetType(Long))
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Quantity", GetType(Integer))
        dt.Columns.Add("CanvassPrice", GetType(Decimal))
        dt.Columns.Add("ApprovedBudget", GetType(Decimal))
        dt.Columns.Add("OrderBy", GetType(String))
        dt.Columns.Add("Total", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Hdr_ID") = DBNull.Value
            dr("Supplier_ID") = DBNull.Value
            dr("prhdr_id") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("Quantity") = DBNull.Value
            dr("CanvassPrice") = DBNull.Value
            dr("ApprovedBudget") = DBNull.Value
            dr("OrderBy") = DBNull.Value
            dr("Total") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If

        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            LoadGrids()
            txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")



            drpDepartment.DataSource = objDerived.GetDataTable("SELECT DISTINCT RC_Name,RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
            drpDepartment.DataTextField = ("RC_Name")
            drpDepartment.DataValueField = ("RC_ID")
            drpDepartment.DataBind()
            drpDepartment.Items.Insert(0, "Select")

            dtApprovedby = objDerived.GetDataTable("EXEC [AMS].[sp_NoticeOfAward_Signatory]", CommandType.Text)
            ddApprovedBy.DataSource = dtApprovedby
            ddApprovedBy.DataTextField = ("SignatoryName")
            ddApprovedBy.DataValueField = ("ID")
            ddApprovedBy.DataBind()
            ddApprovedBy.Items.Insert(0, "Select")
        End If
    End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not Page.IsPostBack Then
    '        InitializeControls()
    '        LoadDynamicData()
    '    End If
    'End Sub

    Private Sub InitializeControls()
        txtDate.Text = Date.Today.ToString("MM/dd/yyyy")
        txtSearch.Attributes.Add("onkeypress", "return fun1(event, '" & btnSearch.ClientID & "')")
    End Sub

    Private Sub LoadDynamicData()
        BindDropdown(drpDepartment, "SELECT DISTINCT RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", "RC_Name", "RC_ID")
        BindDropdown(ddApprovedBy, "EXEC [AMS].[sp_NoticeOfAward_Signatory]", "SignatoryName", "ID")
        LoadGrids()
    End Sub

    Private Sub BindDropdown(ByRef dropdown As DropDownList, ByVal query As String, ByVal textField As String, ByVal valueField As String)
        Dim dt As DataTable = objDerived.GetDataTable(query, CommandType.Text)
        With dropdown
            .DataSource = dt
            .DataTextField = textField
            .DataValueField = valueField
            .DataBind()
            .Items.Insert(0, "Select")
        End With
    End Sub

    'Private Sub LoadGrids()
    '    ' Implement the logic to load data into any grid views you might have on this page.
    '    ' Example: gvYourGrid.DataSource = ...
    '    ' gvYourGrid.DataBind()
    'End Sub

    Protected Sub LoadGrids()
        dtAbstract = objDerived.GetDataTable("EXEC [AMS].[sp_AbstractofCanvass_Approval_Repeat_Order]", CommandType.Text)

        If dtAbstract.Rows.Count < 8 Then
            dtAbstract.Merge(CreateTable1(8 - dtAbstract.Rows.Count))
        End If
        grdAbstractCanvass.DataSource = dtAbstract
        grdAbstractCanvass.DataBind()

        grdItemList.DataSource = CreateTable2(5)
        grdItemList.DataBind()

        btnApproved.Enabled = False
        btnCancel.Enabled = False
        btnResolution.Enabled = False

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtAbstract.DefaultView

        If ddSearchAbstract.SelectedItem.Value = 1 Then
            myview.RowFilter = "pr_no like '%" & txtSearch.Text & "%'"
        ElseIf ddSearchAbstract.SelectedItem.Value = 2 Then
            myview.RowFilter = "RC_Name like '%" & drpDepartment.SelectedItem.Text & "%'"
        ElseIf ddSearchAbstract.SelectedItem.Value = 3 Then
            myview.RowFilter = "OBR_No like '%" & txtSearch.Text & "%'"
        End If

        grdAbstractCanvass.DataSource = myview
        grdAbstractCanvass.DataBind()
        grdAbstractCanvass.SelectedIndex = -1


    End Sub

    Protected Sub ddSearchAbstract_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSearchAbstract.SelectedItem.Value = 1 Then
            lblSearch.Text = "PR Number :"
            txtSearch.Visible = True
            drpDepartment.Visible = False
        ElseIf ddSearchAbstract.SelectedItem.Value = 2 Then
            lblSearch.Text = "Department :"
            txtSearch.Visible = False
            drpDepartment.Visible = True
        ElseIf ddSearchAbstract.SelectedItem.Value = 3 Then
            lblSearch.Text = "OBR Number :"
            txtSearch.Visible = True
            drpDepartment.Visible = False
        End If
    End Sub

    Protected Sub lnkSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    'Protected Sub grdAbstractCanvass_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
    '    Session("prhdr_id") = grdAbstractCanvass.SelectedDataKey("prhdr_id")
    '    Session("Hdr_ID") = grdAbstractCanvass.SelectedDataKey("Hdr_ID")


    '    dtAbstract = objDerived.GetDataTable("EXEC [AMS].[sp_AbstractofCanvass_Approval_Direct]", CommandType.Text)

    '    If dtAbstract.Rows.Count < 8 Then
    '        dtAbstract.Merge(CreateTable1(8 - dtAbstract.Rows.Count))
    '    End If
    '    grdAbstractCanvass.PageIndex = e.NewPageIndex
    '    grdAbstractCanvass.DataSource = dtAbstract
    '    grdAbstractCanvass.DataBind()

    '    grdItemList.DataSource = CreateTable2(5)
    '    grdItemList.DataBind()

    '    btnApproved.Enabled = False
    '    btnCancel.Enabled = False
    'End Sub
    Protected Sub grdAbstractCanvass_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdAbstractCanvass.PageIndexChanging
        UpdateSessionFromSelectedData()

        ReloadAbstractCanvassData(e.NewPageIndex)

        InitializeItemList()

        ResetControlStates()
    End Sub

    Private Sub UpdateSessionFromSelectedData()
        ' Ensure that these keys are actually present and valid before assigning them to avoid errors.
        If grdAbstractCanvass.SelectedDataKey IsNot Nothing Then
            Session("prhdr_id") = grdAbstractCanvass.SelectedDataKey("prhdr_id")
            Session("Hdr_ID") = grdAbstractCanvass.SelectedDataKey("Hdr_ID")
        End If
    End Sub

    Private Sub ReloadAbstractCanvassData(ByVal newPageIndex As Integer)
        Dim dtAbstract As DataTable = objDerived.GetDataTable("EXEC [AMS].[sp_AbstractofCanvass_Approval_Repeat_Order]", CommandType.Text)
        If dtAbstract.Rows.Count < 8 Then
            dtAbstract.Merge(CreateTable1(8 - dtAbstract.Rows.Count))
        End If
        With grdAbstractCanvass
            .PageIndex = newPageIndex
            .DataSource = dtAbstract
            .DataBind()
        End With
    End Sub

    Private Sub InitializeItemList()
        ' Assuming CreateTable2 generates the correct structure for your GridView.
        grdItemList.DataSource = CreateTable2(5)
        grdItemList.DataBind()
    End Sub

    Private Sub ResetControlStates()
        btnApproved.Enabled = False
        btnResolution.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Protected Sub grdAbstractCanvass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Dim dtItems As New DataTable
        dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_Abstract_ItemList_Direct] '" & grdAbstractCanvass.SelectedDataKey("Hdr_ID") & "','" & grdAbstractCanvass.SelectedDataKey("Supplier_ID") & "','" & grdAbstractCanvass.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        grdItemList.DataSource = dtItems
        If dtItems.Rows.Count < 5 Then
            dtItems.Merge(CreateTable1(5 - dtItems.Rows.Count))
        End If
        grdItemList.DataBind()

        btnApproved.Enabled = True
        btnCancel.Enabled = True

    End Sub

    Protected Sub btnApproved_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtTraps1.Value = "Yes" Then
            Try
                objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET withWinner = 1 WHERE PR_Hdr_ID = '" & Session("prhdr_id") & "' AND Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET withWinner = 1 WHERE PR_Hdr_ID = '" & Session("prhdr_id") & "' AND isDBM = 1", CommandType.Text)
                'objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET withWinner = 1 WHERE PR_Hdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
                'objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl1 SET withWinner = 1 WHERE Hdr_ID = '" & grdItemList.SelectedDataKey("Hdr_ID") & "'", CommandType.Text)

                dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_Abstract_ItemList_Direct] '" & grdAbstractCanvass.SelectedDataKey("Hdr_ID") & "','" & grdAbstractCanvass.SelectedDataKey("Supplier_ID") & "','" & grdAbstractCanvass.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                countgrdItemList = dtItems.Rows.Count


                For i As Integer = 0 To countgrdItemList - 1
                    Dim id As Long
                    Dim Dtl_ID1 As Long
                    Dtl_ID1 = dtItems.Rows(i)("Dtl_ID1")


                    id = grdAbstractCanvass.SelectedDataKey("Supplier_ID")

                    objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 SET isWinner = 1 WHERE Dtl_ID1 = '" & Dtl_ID1 & "' AND Supplier_Id = '" & id & "'", CommandType.Text)
                    objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl1 SET withWinner = 1 WHERE Dtl_ID1 = '" & Dtl_ID1 & "'", CommandType.Text)

                    'If grdItemList.SelectedDataKey("isReCanvass") = True Then
                    '    objDerived.GetRecords("UPDATE [AMS].[m_ReCanvass] SET withWinner = 1 WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
                    'End If


                Next

                objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET ApprovedBy = '" & ddApprovedBy.SelectedItem.Value & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND PR_Hdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)


                '==== ADD ABSTRACT NUMBER
                Dim check1 As String
                check1 = objDerived.GetValue("SELECT ISNULL([Abstract_No],'') AS Abstract_No FROM [AMS].[m_Canvass_Hdr] WHERE [Hdr_ID] = '" & grdAbstractCanvass.SelectedDataKey("Hdr_ID") & "'", CommandType.Text)
                If check1 = "" Then
                    Dim AbstractNo As String = objDerived.GetValue("SELECT [AMS].[func_Generate_AbstractNo] ('" & grdAbstractCanvass.SelectedDataKey("Canvass_Date") & "','" & Session("prhdr_id") & "')", CommandType.Text)
                    objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET Abstract_No = '" & AbstractNo & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND PR_Hdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
                End If




                objDerived.Execute("UPDATE AMS.m_Canvass_Hdr SET isApproved = 1, DateApproved = '" & txtDate.Text & "' WHERE PR_Hdr_ID = '" & Session("prhdr_id") & "' AND Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                LoadGrids()
            Catch ex As Exception

            End Try
            btnResolution.Enabled = True

        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '=== REMOVE WINNER/S AND RETURN THE TRANSACTION TO CANVASS GOODS / ABSTRACT OF CANVASS ===
        If txtTraps.Value = "Yes" Then



            '=== UPDATE AMS.m_Canvass_Hdr
            objDerived.Execute("UPDATE AMS.m_Canvass_Hdr SET withWinner = 0, PreparedBy = '', isApproved = 0 WHERE Hdr_ID = '" & grdAbstractCanvass.SelectedDataKey("Hdr_ID") & "'", CommandType.Text)

            '=== UPDATE AMS.m_Canvass_Dtl1
            objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl1 SET withWinner = 0 WHERE Hdr_ID = '" & grdAbstractCanvass.SelectedDataKey("Hdr_ID") & "'", CommandType.Text)

            '=== UPDATE AMS.m_Canvass_Dtl2
            Dim dtDetails As New DataTable
            dtDetails = objDerived.GetDataTable("SELECT * FROM AMS.m_Canvass_Dtl1 WHERE Hdr_ID = '" & grdAbstractCanvass.SelectedDataKey("Hdr_ID") & "'", CommandType.Text)

            For i As Integer = 0 To dtDetails.Rows.Count - 1
                Dim id As Long
                id = dtDetails.Rows(i)("Dtl_ID1")

                objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 SET isWinner = 0 WHERE Dtl_ID1 = '" & id & "'", CommandType.Text)
            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Abstract has been successfully returned.")
            LoadGrids()
        End If
    End Sub

    Protected Sub btnResolution_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "Bidding"
        Session("Hdr_ID") = grdAbstractCanvass.SelectedDataKey("Hdr_ID")
        Session("Supplier_ID") = grdAbstractCanvass.SelectedDataKey("Supplier_ID")

        Me.Page.Response.Redirect("~/bidding/BACResolution_repeat.aspx")
    End Sub
End Class
