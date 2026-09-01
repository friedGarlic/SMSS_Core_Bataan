Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data

Partial Class bidding_Bidding_Infra_t_Bill_Quantities
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

    Private Infra_Hdr As New Bidding_Infra.tb_Infra_Hdr
    Private Infra_Dtl As New Bidding_Infra.tb_Infra_Dtl
    Dim dt1 As New DataTable

#Region "DataTable"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("no")
        dt.Columns.Add("txtDescription")
        dt.Columns.Add("txtUnit")
        dt.Columns.Add("txtQty")

        For i As Integer = 1 To 20
            Dim x As String
            Select Case True
                Case (i = 1)
                    x = "I"
                Case (i = 2)
                    x = "II"
                Case (i = 3)
                    x = "III"
                Case (i = 4)
                    x = "IV"
                Case (i = 5)
                    x = "V"
                Case (i = 6)
                    x = "VI"
                Case (i = 7)
                    x = "VII"
                Case (i = 8)
                    x = "VIII"
                Case (i = 9)
                    x = "IX"
                Case (i = 10)
                    x = "X"
                Case (i = 11)
                    x = "XI"
                Case (i = 12)
                    x = "XII"
                Case (i = 13)
                    x = "XIII"
                Case (i = 14)
                    x = "XIV"
                Case (i = 15)
                    x = "XV"
                Case (i = 16)
                    x = "XVI"
                Case (i = 17)
                    x = "XVII"
                Case (i = 18)
                    x = "XVIII"
                Case (i = 19)
                    x = "XIV"
                Case (i = 20)
                    x = "XX"
                Case Else

            End Select

            dr = dt.NewRow
            dr("No") = x
            dr("txtDescription") = ""
            dr("txtUnit") = ""
            dr("txtQty") = ""
            dt.Rows.Add(dr)
        Next

        Return dt

    End Function
    Public Function CreateTable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("PPA", GetType(String))
        dt.Columns.Add("OBR_Title", GetType(String))
        dt.Columns.Add("TotalAmount", GetType(Decimal))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("OBR_Date", GetType(Date))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PPA") = DBNull.Value
            dr("OBR_Title") = DBNull.Value
            dr("TotalAmount") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("OBR_Date") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

#End Region

    Private Property dtOBRList() As DataTable
        Get
            Return CType(Session("dtOBRList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtOBRList") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadInfraList()
        End If
    End Sub

    Protected Sub LoadInfraList()
        txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

        dtOBRList = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_OBR_ProjectList]", CommandType.Text)
        If dtOBRList.Rows.Count < 5 Then
            dtOBRList.Merge(CreateTable2(5 - dtOBRList.Rows.Count))
        End If
        grdProjectList.DataSource = dtOBRList
        grdProjectList.DataBind()

        grdItems.DataSource = Nothing
        grdItems.DataBind()

        ddBACChairman.DataSource = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, empsig_id FROM dbo.View_BAC ORDER BY Name", CommandType.Text)
        ddBACChairman.DataTextField = ("Name")
        ddBACChairman.DataValueField = ("empsig_id")
        ddBACChairman.DataBind()
        ddBACChairman.Items.Insert(0, "Select")
    End Sub

    Private Sub grdProjectList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdProjectList.PageIndexChanging
        grdProjectList.DataSource = dtOBRList
        grdProjectList.PageIndex = e.NewPageIndex
        grdProjectList.DataBind()
    End Sub

    Protected Sub grdProjectList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnAdd.Text = "ADD"

        LoadItems()
        btnAdd.Enabled = True
        btnSave.Enabled = True
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddBACChairman.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select BAC Chairman signatory.")
            Exit Sub
        Else
            Try
                Dim Hdr_ID As Integer
                Hdr_ID = objDerived.GetValue("SELECT Infra_Hdr_ID FROM AMS.tb_Infra_Hdr WHERE prhdr_id = '" & grdProjectList.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.tb_Infra_Hdr SET isFinal = 1, BACC = '" & ddBACChairman.SelectedItem.Value & "' WHERE Infra_Hdr_ID = '" & Hdr_ID & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                btnPreview.Enabled = True
                LoadInfraList()
            Catch ex As Exception
            End Try
        End If

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If txtDescription.Text = "" Or txtUnit.Text = "" Or txtQty.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all information before saving.")
                Exit Sub
            Else

                'Dim Hdr_ID As Integer
                'Hdr_ID = objDerived.GetValue("SELECT Infra_Hdr_ID FROM AMS.tb_Infra_Hdr WHERE prhdr_id = '" & grdProjectList.SelectedDataKey("prhdr_id") & "'", CommandType.Text)

                ''=== SAVE BIDDING INFRA HEADER
                'With Infra_Hdr
                '    .OBR_Hdr_ID = grdProjectList.SelectedDataKey("OBR_Hdr_ID")
                '    .Program_ID = grdProjectList.SelectedDataKey("Program_ID")
                '    .Project_ID = grdProjectList.SelectedDataKey("Project_ID")
                '    .TotalAmount = grdProjectList.SelectedDataKey("TotalAmount")
                '    .Bid_Date = CType(txtDate.Text, DateTime)
                '    '.BACC = ddBACChairman.SelectedItem.Value
                'End With

                'Dim Infra_Hdr_ID As Long
                'If Hdr_ID = 0 Then
                '    Infra_Hdr_ID = Infra_Hdr.save
                'Else
                '    Infra_Hdr_ID = Hdr_ID
                '    Infra_Hdr.Infra_Hdr_ID = Hdr_ID
                '    Infra_Hdr.update()
                'End If

                'Session("Infra_Hdr_ID") = Infra_Hdr_ID

                ''=== SAVE BIDDING INFRA DETAILS
                'With Infra_Dtl
                '    .Infra_Hdr_ID = Infra_Hdr_ID
                '    .Description = txtDescription.Text
                '    .Unit = txtUnit.Text
                '    .Quantity = txtQty.Text

                '    If btnAdd.Text = "UPDATE" Then
                '        .Infra_Dtl_ID = grdItems.SelectedDataKey("Infra_Dtl_ID")
                '        .update()
                '    ElseIf btnAdd.Text = "ADD" Then
                '        .save()
                '    End If

                'End With

                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                'txtDescription.Text = ""
                'txtUnit.Text = ""
                'txtQty.Text = ""
                'btnAdd.Text = "ADD"

                'LoadItems()
                'btnSave.Enabled = True

            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error occured, Contact administrator for assistant.")
        End Try

    End Sub

    Protected Sub LoadItems()

        grdItems.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_ItemsDescription] '" & grdProjectList.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        grdItems.DataBind()

    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/bidding/Bidding_Infra/rpt_Bill_Quantities.aspx")
    End Sub

    Protected Sub grdItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtDescription.Text = grdItems.SelectedDataKey("Description")
        txtUnit.Text = grdItems.SelectedDataKey("Unit")
        txtQty.Text = grdItems.SelectedDataKey("Quantity")

        btnAdd.Text = "UPDATE"


    End Sub


End Class
