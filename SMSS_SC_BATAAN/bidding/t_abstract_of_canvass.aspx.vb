Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class t_abstract_of_canvass
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Private hdr As New t_bid_opening_hdr
    Private dtl As New t_bid_opening_dtl
    Dim dtSuppList As New DataTable

#Region "property"


    Private Property dtSupplier() As DataTable
        Get
            Return CType(Session("dtSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSupplier") = value
        End Set
    End Property
    Private Property dtItemList() As DataTable
        Get
            Return CType(Session("dtItemList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItemList") = value
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

    Private Property dtPRList() As DataTable
        Get
            Return CType(Session("dtPRList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPRList") = value
        End Set
    End Property
    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property

#End Region
#Region "Functions"

    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("NoBidder", GetType(Integer))
        dt.Columns.Add("Canvass_Date", GetType(Date))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = DBNull.Value
            dr("NoBidder") = DBNull.Value
            dr("Canvass_Date") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatableSuppliers(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName")
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("status")
        dt.Columns.Add("isOld", GetType(Boolean))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = ""
            dr("Supplier_Id") = 0
            dr("isVisible") = False
            dr("amount") = "0.00"
            dr("status") = ""
            dr("isOld") = False

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            Session("Selected") = 0

            LoadrbChoice()

            '=== SIGNATORIES
            ddBAC1.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 3", CommandType.Text)
            ddBAC1.DataTextField = ("Name")
            ddBAC1.DataValueField = ("empsig_id")
            ddBAC1.DataBind()

            ddBAC2.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 4", CommandType.Text)
            ddBAC2.DataTextField = ("Name")
            ddBAC2.DataValueField = ("empsig_id")
            ddBAC2.DataBind()

            ddBAC3.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 5", CommandType.Text)
            ddBAC3.DataTextField = ("Name")
            ddBAC3.DataValueField = ("empsig_id")
            ddBAC3.DataBind()

            ddBAC4.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 15", CommandType.Text)
            ddBAC4.DataTextField = ("Name")
            ddBAC4.DataValueField = ("empsig_id")
            ddBAC4.DataBind()


            ddBACVC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 2", CommandType.Text)
            ddBACVC.DataTextField = ("Name")
            ddBACVC.DataValueField = ("empsig_id")
            ddBACVC.DataBind()

            ddBACC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 1", CommandType.Text)
            ddBACC.DataTextField = ("Name")
            ddBACC.DataValueField = ("empsig_id")
            ddBACC.DataBind()

            ddPreparedBy.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1  AND Position_desc LIKE '%Canvasser%' ORDER BY  [Name]", CommandType.Text)
            ddPreparedBy.DataTextField = ("Name")
            ddPreparedBy.DataValueField = ("empsig_id")
            ddPreparedBy.DataBind()
            ddPreparedBy.Items.Insert(0, "Select")

            ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT empid, UPPER(full_name) AS full_name FROM HRMS.view_signatory WHERE deptid IN (1,2,3,8,13,104) AND division_key = 86 AND isDeptHead = 'Yes' ORDER BY full_name", CommandType.Text)
            ddApprovedBy.DataTextField = ("full_name")
            ddApprovedBy.DataValueField = ("empid")
            ddApprovedBy.DataBind()
            ddApprovedBy.Items.Insert(0, "Select")

            txtSearchPR.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchPR.ClientID & "')")

        End If


    End Sub
    Protected Sub ddSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSearch.SelectedItem.Value = 1 Then
            lblSearchBy.Text = "PR Number :"
        ElseIf ddSearch.SelectedItem.Value = 2 Then
            lblSearchBy.Text = "OBR Number :"
        End If
    End Sub

    Protected Sub btnSearchPR_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim myview As DataView
        myview = dtItemList.DefaultView

        If ddSearch.SelectedItem.Value = 1 Then
            myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearchPR.Text) & "%'"
        ElseIf ddSearch.SelectedItem.Value = 2 Then
            myview.RowFilter = "OBR_No like '%" & replaceapostrophe(txtSearchPR.Text) & "%'"
        End If

        grdItemList.DataSource = myview
        grdItemList.DataBind()

    End Sub

    Protected Sub LoadrbChoice()

        ' dtItemList = Nothing
        dtItemList = objDerived.GetDataTable("EXEC [AMS].[sp_AbstractofCanvass_PerPR]", CommandType.Text)
        If dtItemList.Rows.Count < 5 Then
            dtItemList.Merge(createdatatable1(5 - dtItemList.Rows.Count))
        End If
        grdItemList.DataSource = dtItemList
        grdItemList.DataBind()

        grdList.Columns(3).Visible = False
        grdList.DataSource = Nothing
        grdList.DataBind()

    End Sub

    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Lbtn = "Select"
    'End Sub
    Protected Sub lnkSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "Select"
    End Sub

    Protected Sub grdItemList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        grdList.Columns(3).Visible = True

        Session("Selected") = 1

        If Lbtn = "Select" Then
            Session("prhdr_id") = grdItemList.SelectedDataKey("prhdr_id")
            Session("Hdr_ID") = grdItemList.SelectedDataKey("Hdr_ID")
            Dim a As Integer = grdItemList.SelectedDataKey("Hdr_ID")
            Session("Hdr_ID_1") = a


            Session("ProcurementMode") = objDerived.GetValue("SELECT mode_of_procurement_id FROM AMS.PR_Hdr WHERE prhdr_id = '" & grdItemList.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            If Session("ProcurementMode") = 99 Then
                dtItems = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Abstract_ItemList_DBM] WHERE PR_Hdr_ID = '" & grdItemList.SelectedDataKey("prhdr_id") & "' AND Hdr_ID = '" & grdItemList.SelectedDataKey("Hdr_ID") & "'", CommandType.Text)
                grdList.DataSource = dtItems
                grdList.DataBind()
            Else
                'dtItems = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Abstract_ItemList] WHERE PR_Hdr_ID = '" & grdItemList.SelectedDataKey("prhdr_id") & "' AND Hdr_ID = '" & grdItemList.SelectedDataKey("Hdr_ID") & "'", CommandType.Text)
                dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_Abstract_Items] " & grdItemList.SelectedDataKey("prhdr_id") & "," & grdItemList.SelectedDataKey("Hdr_ID") & "", CommandType.Text)
                grdList.DataSource = dtItems
                grdList.DataBind()
            End If

            For i As Integer = 0 To dtItems.Rows.Count - 1
                CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_Abstract_BidderList]  '" & dtItems.Rows(i)("Item_ID") & "','" & dtItems.Rows(i)("Dtl_ID1") & "'", CommandType.Text)
                CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).DataTextField = ("SuppName")
                CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).DataValueField = ("Supplier_Id")
                CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).DataBind()
                CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).Items.Insert(0, "Re-Canvass")

                drpListOfBidders.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_Abstract_BidderList_v2]  '" & dtItems.Rows(i)("Item_ID") & "','" & dtItems.Rows(i)("Dtl_ID1") & "'", CommandType.Text)
                drpListOfBidders.DataTextField = ("SuppName")
                drpListOfBidders.DataValueField = ("Supplier_Id")
                drpListOfBidders.DataBind()
                drpListOfBidders.Items.Insert(0, "Re-Canvass")

            Next

            'Dim RC_ID As Integer
            'RC_ID = objDerived.GetValue("SELECT DISTINCT RC_ID FROM AMS.PR_Hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
            'If RC_ID = 20 Then
            '    lblBAC_Pos.Text = "BAC Member 4 :"
            'Else
            '    lblBAC_Pos.Text = "BAC Vice Chairman :"
            'End If

        End If
        grdList.Columns(3).Visible = False
    End Sub


    Protected Sub btnWinner_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If ddBAC1.SelectedItem.Text = "" Or ddBAC2.SelectedItem.Text = "" Or ddBAC3.SelectedItem.Text = "" Or ddBAC3.SelectedItem.Text = "" Then
            ElseIf ddBACVC.SelectedItem.Text = "" Or ddBACC.SelectedItem.Text = "" Then
            ElseIf ddApprovedBy.SelectedItem.Text = "Select" Or ddPreparedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory")
                Exit Sub
            ElseIf Session("Selected") = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select transaction.")
                Exit Sub
            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set default BAC signatories in File Maintenance.")
            Exit Sub
        End Try

        Try
            grdList.Columns(3).Visible = True

            objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET withWinner = 1 WHERE PR_Hdr_ID = '" & Session("prhdr_id") & "' AND Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET withWinner = 1 WHERE PR_Hdr_ID = '" & Session("prhdr_id") & "' AND isDBM = 1", CommandType.Text)
            'objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET withWinner = 1 WHERE PR_Hdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
            'objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl1 SET withWinner = 1 WHERE Hdr_ID = '" & grdItemList.SelectedDataKey("Hdr_ID") & "'", CommandType.Text)

            For i As Integer = 0 To grdList.Rows.Count - 1
                Dim id As Long
                Dim Dtl_ID1 As Long
                Dtl_ID1 = CType(grdList.Rows(i).FindControl("lblDtl_ID1"), Label).Text

                If CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).SelectedItem.Text = "Re-Canvass" Then
                    '=========== CHECK IF THERE IS EXISTING RECANVASS HEADER =================
                    Dim ReCanvassID As Integer = objDerived.GetValue("SELECT ISNULL(ReCanvass_ID,0) FROM [AMS].[m_ReCanvass] WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
                    If ReCanvassID = 0 Then
                        objDerived.GetRecords("INSERT INTO [AMS].[m_ReCanvass] (ReCanvass_Date,withWinner,prhdr_id) VALUES ('" & Date.Today.ToString("MM/dd/yyyy") & "', 0,'" & Session("prhdr_id") & "')", CommandType.Text)
                    End If

                    objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl1 SET isReCanvass = 1,withWinner = 0 WHERE Dtl_ID1 = '" & Dtl_ID1 & "'", CommandType.Text)

                    Dim ReCanvass_ID As Integer
                    ReCanvass_ID = objDerived.GetValue("SELECT TOP(1) ReCanvass_ID FROM [AMS].[m_ReCanvass] ORDER BY ReCanvass_ID DESC", CommandType.Text)
                    objDerived.GetRecords("INSERT INTO [AMS].[m_ReCanvass_Dtl] (ReCanvass_ID, Dtl_ID1) VALUES('" & ReCanvass_ID & "','" & Dtl_ID1 & "')", CommandType.Text)

                Else
                    id = CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).SelectedItem.Value
                    objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 SET isWinner = 1 WHERE Dtl_ID1 = '" & Dtl_ID1 & "' AND Supplier_Id = '" & id & "'", CommandType.Text)
                    objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl1 SET withWinner = 1 WHERE Dtl_ID1 = '" & Dtl_ID1 & "'", CommandType.Text)

                    If grdItemList.SelectedDataKey("isReCanvass") = True Then
                        objDerived.GetRecords("UPDATE [AMS].[m_ReCanvass] SET withWinner = 1 WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
                    End If

                End If
            Next

            '=== UPDATE SIGNATORY 05022016
            'objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET BAC1 = '" & ddBAC1.SelectedItem.Value & "', BAC2 = '" & ddBAC2.SelectedItem.Value & "', BAC3 = '" & ddBAC3.SelectedItem.Value & "' WHERE PR_Hdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
            'objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET BACVC = '" & ddBACVC.SelectedItem.Value & "', BACC = '" & ddBACC.SelectedItem.Value & "', ApprovedBy = '" & ddApprovedBy.SelectedItem.Value & "' WHERE PR_Hdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
            'objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET PreparedBy = '" & ddPreparedBy.SelectedItem.Text & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND PR_Hdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET BAC1 = '" & ddBAC1.SelectedItem.Value & "', BAC2 = '" & ddBAC2.SelectedItem.Value & "', BAC3 = '" & ddBAC3.SelectedItem.Value & "', BAC4 = '" & ddBAC4.SelectedItem.Value & "', " &
                                    " BACVC = '" & ddBACVC.SelectedItem.Value & "', BACC = '" & ddBACC.SelectedItem.Value & "', ApprovedBy = '" & ddApprovedBy.SelectedItem.Value & "', " &
                                    " PreparedBy = '" & ddPreparedBy.SelectedItem.Text & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND PR_Hdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)


            '==== ADD ABSTRACT NUMBER
            Dim check1 As String
            check1 = objDerived.GetValue("SELECT ISNULL([Abstract_No],'') AS Abstract_No FROM [AMS].[m_Canvass_Hdr] WHERE [Hdr_ID] = '" & grdItemList.SelectedDataKey("Hdr_ID") & "'", CommandType.Text)
            If check1 = "" Then
                Dim AbstractNo As String = objDerived.GetValue("SELECT [AMS].[func_Generate_AbstractNo] ('" & grdItemList.SelectedDataKey("Canvass_Date") & "','" & Session("prhdr_id") & "')", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET Abstract_No = '" & AbstractNo & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND PR_Hdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
            End If

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            LoadrbChoice()

            btnPreWinning.Enabled = False
            btnPrintPreAOQ.Enabled = False
            btnWinner.Enabled = False
            btnPreview.Enabled = True

        Catch ex As Exception
        End Try

    End Sub

    Protected Sub linkPR_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "PR"
    End Sub

    Protected Sub linkPRWin_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "PR_Supp"
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        dtSupplier = objDerived.GetDataTable("SELECT DISTINCT AMS.m_Canvass_Hdr.Hdr_ID, dbo.Supplier.SuppName, AMS.m_Canvass_Dtl2.Supplier_ID, AMS.m_Canvass_Dtl2.Remarks  " &
                        " FROM AMS.m_Canvass_Hdr INNER JOIN " &
                        " AMS.m_Canvass_Dtl1 ON AMS.m_Canvass_Hdr.Hdr_ID = AMS.m_Canvass_Dtl1.Hdr_ID INNER JOIN " &
                        " AMS.m_Canvass_Dtl2 ON AMS.m_Canvass_Dtl1.Dtl_ID1 = AMS.m_Canvass_Dtl2.Dtl_ID1 INNER JOIN " &
                        " dbo.Supplier ON AMS.m_Canvass_Dtl2.Supplier_ID = dbo.Supplier.Supplier_Id " &
                        " WHERE (AMS.m_Canvass_Hdr.Hdr_ID = '" & Session("Hdr_ID") & "') AND (AMS.m_Canvass_Hdr.PR_Hdr_ID = '" & Session("prhdr_id") & "')", CommandType.Text)
        grvSupplierRemarksEdit.DataSource = dtSupplier
        grvSupplierRemarksEdit.DataBind()
        ModalPopupExtenderEditAOQ.Show()
        '=== SIGNATORIES
        drpBM1.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 3", CommandType.Text)
        drpBM1.DataTextField = ("Name")
        drpBM1.DataValueField = ("empsig_id")
        drpBM1.DataBind()

        drpBM2.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 4", CommandType.Text)
        drpBM2.DataTextField = ("Name")
        drpBM2.DataValueField = ("empsig_id")
        drpBM2.DataBind()

        drpBM3.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 5", CommandType.Text)
        drpBM3.DataTextField = ("Name")
        drpBM3.DataValueField = ("empsig_id")
        drpBM3.DataBind()

        drpBM4.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 15", CommandType.Text)
        drpBM4.DataTextField = ("Name")
        drpBM4.DataValueField = ("empsig_id")
        drpBM4.DataBind()


        drpBVC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 2", CommandType.Text)
        drpBVC.DataTextField = ("Name")
        drpBVC.DataValueField = ("empsig_id")
        drpBVC.DataBind()

        drpBC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 1", CommandType.Text)
        drpBC.DataTextField = ("Name")
        drpBC.DataValueField = ("empsig_id")
        drpBC.DataBind()

        drpEditCanvassed.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1  AND Position_desc LIKE '%Canvasser%' ORDER BY  [Name]", CommandType.Text)
        drpEditCanvassed.DataTextField = ("Name")
        drpEditCanvassed.DataValueField = ("empsig_id")
        drpEditCanvassed.DataBind()
        drpEditCanvassed.Items.Insert(0, "Select")

        drpApprovedByEdit.DataSource = objDerived.GetDataTable("SELECT empid, UPPER(full_name) AS full_name FROM HRMS.view_signatory WHERE deptid IN (1,2,3,8,13,104) AND division_key = 86 AND isDeptHead = 'Yes' ORDER BY full_name", CommandType.Text)
        drpApprovedByEdit.DataTextField = ("full_name")
        drpApprovedByEdit.DataValueField = ("empid")
        drpApprovedByEdit.DataBind()
        drpApprovedByEdit.Items.Insert(0, "Select")
    End Sub

    Protected Sub btnNOA_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim url As String = "rpt_Canvass_NOA.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub

    Protected Sub ddBidder_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim ddBidder As DropDownList = TryCast(sender, DropDownList)
        Dim gvr As GridViewRow = TryCast(ddBidder.NamingContainer, GridViewRow)

        Dim dt As New DataTable
        dt = dtItems

        CType(grdList.Rows(gvr.RowIndex).FindControl("lblDesc"), Label).Text = dtItems.Rows(gvr.RowIndex)("Item_Desc")

        Dim SuppID As Long
        Dim Dtl_ID1 As Long
        Dim ItemDesc As String
        Dim Specs As String

        If CType(grdList.Rows(gvr.RowIndex).FindControl("ddBidder"), DropDownList).SelectedItem.Text = "Re-Canvass" Then
            SuppID = 0
        Else
            SuppID = CType(grdList.Rows(gvr.RowIndex).FindControl("ddBidder"), DropDownList).SelectedItem.Value
        End If

        Dtl_ID1 = CType(grdList.Rows(gvr.RowIndex).FindControl("lblDtl_ID1"), Label).Text
        ItemDesc = CType(grdList.Rows(gvr.RowIndex).FindControl("lblDesc"), Label).Text

        Specs = objDerived.GetValue("SELECT ISNULL(ItemSpecs, '') AS ItemSpecs FROM AMS.m_Canvass_Dtl2 WHERE  Dtl_ID1 = '" & Dtl_ID1 & "' AND Supplier_ID = '" & SuppID & "'", CommandType.Text)

        If Specs <> "" Then
            CType(grdList.Rows(gvr.RowIndex).FindControl("lblDesc"), Label).Text = ItemDesc & " - " & Specs
        End If

        btnWinner.Enabled = False
        btnPreWinning.Enabled = True
        '========= CHECK IF SELECTED BIDDER EXCEED FROM THE APPROVED BUDGET ==========
        loadCheckPrice()


        '========= CHANGE 061418 ==========
        'Dim ddBidder As DropDownList = TryCast(sender, DropDownList)
        'Dim gvr As GridViewRow = TryCast(ddBidder.NamingContainer, GridViewRow)

        'Dim dt As New DataTable
        'dt = dtItems

        'CType(grdList.Rows(gvr.RowIndex).FindControl("lblDesc"), Label).Text = dtItems.Rows(gvr.RowIndex)("Item_Desc")

        'Dim SuppID As Long
        'Dim Dtl_ID1 As Long
        'Dim ItemDesc As String
        'Dim Specs As String

        'Dtl_ID1 = CType(grdList.Rows(gvr.RowIndex).FindControl("lblDtl_ID1"), Label).Text
        'SuppID = CType(grdList.Rows(gvr.RowIndex).FindControl("ddBidder"), DropDownList).SelectedItem.Value
        'ItemDesc = CType(grdList.Rows(gvr.RowIndex).FindControl("lblDesc"), Label).Text

        'Specs = objDerived.GetValue("SELECT ISNULL(ItemSpecs, '') AS ItemSpecs FROM AMS.m_Canvass_Dtl2 WHERE  Dtl_ID1 = '" & Dtl_ID1 & "' AND Supplier_ID = '" & SuppID & "'", CommandType.Text)

        'If Specs <> "" Then
        '    CType(grdList.Rows(gvr.RowIndex).FindControl("lblDesc"), Label).Text = ItemDesc & " - " & Specs
        'End If
        'For i As Integer = 0 To grdList.Rows.Count - 1
        '    If CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).SelectedItem.Text = "Select" Or ddPreparedBy.SelectedItem.Text = "Select" Then
        '        btnWinner.Enabled = False
        '        Exit Sub
        '    End If
        'Next
        'btnWinner.Enabled = True
    End Sub
    Protected Sub loadCheckPrice()
        For i As Integer = 0 To grdList.Rows.Count - 1
            Dim id As Long
            Dim xDtl_ID1 As Long
            Dim CanvassPrice As Decimal
            Dim AppprovedBudget As Decimal
            Dim Item_ID As Long

            xDtl_ID1 = CType(grdList.Rows(i).FindControl("lblDtl_ID1"), Label).Text

            If CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).SelectedItem.Text = "Re-Canvass" Then

            Else
                id = CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).SelectedItem.Value
                CanvassPrice = objDerived.GetValue("SELECT TOP(1) AMS.m_Canvass_Dtl2.UnitPrice " & _
                        " FROM AMS.m_Canvass_Dtl1 INNER JOIN AMS.m_Canvass_Dtl2 ON AMS.m_Canvass_Dtl1.Dtl_ID1 = AMS.m_Canvass_Dtl2.Dtl_ID1 " & _
                        " WHERE AMS.m_Canvass_Dtl1.Dtl_ID1 = '" & xDtl_ID1 & "' AND AMS.m_Canvass_Dtl2.Supplier_ID = '" & id & "'", CommandType.Text)

                Item_ID = objDerived.GetValue("SELECT AMS.m_Canvass_Dtl1.Item_ID " & _
                    " FROM AMS.m_Canvass_Dtl1 INNER JOIN AMS.m_Canvass_Dtl2 ON AMS.m_Canvass_Dtl1.Dtl_ID1 = AMS.m_Canvass_Dtl2.Dtl_ID1 " & _
                    " WHERE AMS.m_Canvass_Dtl1.Dtl_ID1 = '" & xDtl_ID1 & "' AND AMS.m_Canvass_Dtl2.Supplier_ID = '" & id & "'", CommandType.Text)

                If Session("ProcurementMode") = 99 Then
                    AppprovedBudget = objDerived.GetValue("SELECT ApprovedBudget FROM [dbo].[View_Abstract_ItemList_DBM] WHERE PR_Hdr_ID = '" & grdItemList.SelectedDataKey("prhdr_id") & "' AND Item_ID = '" & Item_ID & "'", CommandType.Text)
                Else
                    AppprovedBudget = objDerived.GetValue("SELECT TOP(1) Cost FROM AMS.PR_Dtl WHERE PRHdr_ID = '" & Session("prhdr_id") & "' AND Item_ID = '" & Item_ID & "'", CommandType.Text)
                End If

                If AppprovedBudget < CanvassPrice Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected supplier canvass price exceeded the allocated budget.")
                    Session("ExceedCost") = 1
                    btnWinner.Enabled = False
                    Exit Sub
                End If

            End If
        Next
    End Sub
    Protected Sub ddPreparedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To grdList.Rows.Count - 1
            If CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).SelectedItem.Text = "Select" Then
                btnWinner.Enabled = False
                Exit Sub
            End If
        Next

        btnWinner.Enabled = False
        btnPreWinning.Enabled = True
    End Sub


    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function




    Protected Sub grdItemList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)


        dtItemList = Nothing
        dtItemList = objDerived.GetDataTable("EXEC [AMS].[sp_AbstractofCanvass_PerPR]", CommandType.Text)
        If dtItemList.Rows.Count < 5 Then
            dtItemList.Merge(createdatatable1(5 - dtItemList.Rows.Count))
        End If
        grdItemList.PageIndex = e.NewPageIndex
        grdItemList.DataSource = dtItemList
        grdItemList.DataBind()

        grdList.Columns(3).Visible = False
        grdList.DataSource = Nothing
        grdList.DataBind()
    End Sub
    Protected Sub drpListOfBidders_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim drp As DropDownList
        For i As Integer = 0 To grdList.Rows.Count - 1
            drp = CType(Me.grdList.Rows(i).Cells(0).FindControl("ddBidder"), DropDownList)
            If drpListOfBidders.selecteditem.text = "Re-Canvass" Then
                drp.SelectedIndex = drpListOfBidders.SelectedIndex

            Else
                drp.SelectedIndex = drpListOfBidders.SelectedIndex
            End If
        Next
    End Sub

    Protected Sub AddRemarks_Click(sender As Object, e As EventArgs) Handles AddRemarks.Click

        dtSupplier = objDerived.GetDataTable("SELECT DISTINCT AMS.m_Canvass_Hdr.Hdr_ID, dbo.Supplier.SuppName, AMS.m_Canvass_Dtl2.Supplier_ID, AMS.m_Canvass_Dtl2.Remarks  " &
                        " FROM AMS.m_Canvass_Hdr INNER JOIN " &
                        " AMS.m_Canvass_Dtl1 ON AMS.m_Canvass_Hdr.Hdr_ID = AMS.m_Canvass_Dtl1.Hdr_ID INNER JOIN " &
                        " AMS.m_Canvass_Dtl2 ON AMS.m_Canvass_Dtl1.Dtl_ID1 = AMS.m_Canvass_Dtl2.Dtl_ID1 INNER JOIN " &
                        " dbo.Supplier ON AMS.m_Canvass_Dtl2.Supplier_ID = dbo.Supplier.Supplier_Id " &
                        " WHERE (AMS.m_Canvass_Hdr.Hdr_ID = '" & grdItemList.SelectedDataKey("Hdr_ID") & "') AND (AMS.m_Canvass_Hdr.PR_Hdr_ID = '" & grdItemList.SelectedDataKey("prhdr_id") & "')", CommandType.Text)
        grdSupplierRemarks.DataSource = dtSupplier
        grdSupplierRemarks.DataBind()
        ModalPopupExtender2.Show()
    End Sub
    Protected Sub btnSaveSupplierRemarks_Click(sender As Object, e As EventArgs) Handles btnSaveSupplierRemarks.Click
        For i As Integer = 0 To grdSupplierRemarks.Rows.Count - 1
            objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 " &
                                   " SET Remarks = '" & CType(grdSupplierRemarks.Rows(i).FindControl("txtRemarks"), TextBox).Text & "' " &
                                   " WHERE Supplier_ID = '" & dtSupplier.Rows(i)("Supplier_ID") & "' " &
                                   " AND Dtl_ID2 IN (SELECT D2.Dtl_ID2 " &
                                   " FROM AMS.m_Canvass_Dtl2 AS D2 " &
                                   " INNER JOIN AMS.m_Canvass_Dtl1 AS D1 ON D1.Dtl_ID1 = D2.Dtl_ID1 " &
                                   " INNER JOIN AMS.m_Canvass_Hdr AS H ON H.Hdr_ID = D1.Hdr_ID " &
                                   " WHERE D2.Supplier_ID = '" & dtSupplier.Rows(i)("Supplier_ID") & "' " &
                                   " AND H.Hdr_ID = '" & grdItemList.SelectedDataKey("Hdr_ID") & "')", CommandType.Text)


        Next
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Remarks Saved")

    End Sub
    Protected Sub btnCancelRemarks_Click(sender As Object, e As EventArgs) Handles btnCancelRemarks.Click
        ModalPopupExtender2.Hide()
    End Sub
    Protected Sub btnPreWinning_Click(sender As Object, e As EventArgs) Handles btnPreWinning.Click
        Try
            If ddBAC1.SelectedItem.Text = "" Or ddBAC2.SelectedItem.Text = "" Or ddBAC3.SelectedItem.Text = "" Or ddBAC3.SelectedItem.Text = "" Then
            ElseIf ddBACVC.SelectedItem.Text = "" Or ddBACC.SelectedItem.Text = "" Then
            ElseIf ddApprovedBy.SelectedItem.Text = "Select" Or ddPreparedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory")
                Exit Sub
            ElseIf Session("Selected") = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select transaction.")
                Exit Sub
            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set default BAC signatories in File Maintenance.")
            Exit Sub
        End Try
        For i As Integer = 0 To grdList.Rows.Count - 1
            Dim id As Long
            Dim Dtl_ID1 As Long
            Dtl_ID1 = CType(grdList.Rows(i).FindControl("lblDtl_ID1"), Label).Text

            id = CType(grdList.Rows(i).FindControl("ddBidder"), DropDownList).SelectedItem.Value
            objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 SET isPre_Winner = 1 WHERE Dtl_ID1 = '" & Dtl_ID1 & "' AND Supplier_Id = '" & id & "'", CommandType.Text)
            'objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl1 SET withWinner = 1 WHERE Dtl_ID1 = '" & Dtl_ID1 & "'", CommandType.Text)

            If grdItemList.SelectedDataKey("isReCanvass") = True Then
                objDerived.GetRecords("UPDATE [AMS].[m_ReCanvass] SET withWinner = 1 WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
            End If
        Next
        objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET BAC1 = '" & ddBAC1.SelectedItem.Value & "', BAC2 = '" & ddBAC2.SelectedItem.Value & "', BAC3 = '" & ddBAC3.SelectedItem.Value & "', BAC4 = '" & ddBAC4.SelectedItem.Value & "', " &
                                    " BACVC = '" & ddBACVC.SelectedItem.Value & "', BACC = '" & ddBACC.SelectedItem.Value & "', ApprovedBy = '" & ddApprovedBy.SelectedItem.Value & "', " &
                                    " PreparedBy = '" & ddPreparedBy.SelectedItem.Text & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND PR_Hdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        btnPrintPreAOQ.Enabled = True
        btnWinner.Enabled = True

    End Sub
    Protected Sub btnPrintPreAOQ_Click(sender As Object, e As EventArgs) Handles btnPrintPreAOQ.Click
        Session("Page") = "BID"
        Session("Category") = "Abstract"
        Session("Report") = "PRE_AOQ"

        AddTrace("Page: " & Session("Page"))
        AddTrace("Category: " & Session("Category"))
        AddTrace("Report: " & Session("Report"))

        AddTrace("prhdr_id: " & Session("prhdr_id"))
        AddTrace("Hdr_ID: " & Session("Hdr_ID"))

        'Me.Page.Response.Redirect("~/MainReports/Canvass_Reports.aspx")


        Dim url As String = ResolveUrl("~/MainReports/Canvass_Reports.aspx")
        Dim script As String = "window.open('" & url & "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)
        'Me.Page.Response.Redirect("~/bidding/rpt_abstract_of_canvass.aspx")
    End Sub


    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)

    End Sub

    Protected Sub btnCancelEdit_Click(sender As Object, e As EventArgs) Handles btnCancelEdit.Click
        Session("Page") = "BID"
        Session("Category") = "Abstract"
        Session("Report") = "AOQ"


        'Me.Page.Response.Redirect("~/MainReports/Canvass_Reports.aspx")


        Dim url As String = ResolveUrl("~/MainReports/Canvass_Reports.aspx")
        Dim script As String = "window.open('" & url & "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)
        'Me.Page.Response.Redirect("~/bidding/rpt_abstract_of_canvass.aspx")
    End Sub
    Protected Sub btnSavedEdit_Click(sender As Object, e As EventArgs) Handles btnSavedEdit.Click

        For i As Integer = 0 To grvSupplierRemarksEdit.Rows.Count - 1
            objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl2 " &
                                   " SET Remarks = '" & CType(grvSupplierRemarksEdit.Rows(i).FindControl("txtRemarksEdit"), TextBox).Text & "' " &
                                   " WHERE Supplier_ID = '" & dtSupplier.Rows(i)("Supplier_ID") & "' " &
                                   " AND Dtl_ID2 IN (SELECT D2.Dtl_ID2 " &
                                   " FROM AMS.m_Canvass_Dtl2 AS D2 " &
                                   " INNER JOIN AMS.m_Canvass_Dtl1 AS D1 ON D1.Dtl_ID1 = D2.Dtl_ID1 " &
                                   " INNER JOIN AMS.m_Canvass_Hdr AS H ON H.Hdr_ID = D1.Hdr_ID " &
                                   " WHERE D2.Supplier_ID = '" & dtSupplier.Rows(i)("Supplier_ID") & "' " &
                                   " AND H.Hdr_ID = '" & grdItemList.SelectedDataKey("Hdr_ID") & "')", CommandType.Text)


        Next

        objDerived.GetRecords("UPDATE AMS.m_Canvass_Hdr SET BAC1 = '" & drpBM1.SelectedItem.Value & "', BAC2 = '" & drpBM2.SelectedItem.Value & "', BAC3 = '" & drpBM3.SelectedItem.Value & "', BAC4 = '" & drpBM4.SelectedItem.Value & "', " &
                                    " BACVC = '" & drpBVC.SelectedItem.Value & "', BACC = '" & drpBC.SelectedItem.Value & "', ApprovedBy = '" & drpApprovedByEdit.SelectedItem.Value & "', " &
                                    " PreparedBy = '" & drpEditCanvassed.SelectedItem.Text & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "' AND PR_Hdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)


        'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Remarks Saved")



        Session("Page") = "BID"
        Session("Category") = "Abstract"
        Session("Report") = "AOQ"


        'Me.Page.Response.Redirect("~/MainReports/Canvass_Reports.aspx")


        Dim url As String = ResolveUrl("~/MainReports/Canvass_Reports.aspx")
        Dim script As String = "window.open('" & url & "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OPEN_WINDOW", script, True)
        'Me.Page.Response.Redirect("~/bidding/rpt_abstract_of_canvass.aspx")
    End Sub
End Class
