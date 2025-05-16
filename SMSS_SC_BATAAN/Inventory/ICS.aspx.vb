Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing
Imports System.IO

Partial Class Inventory_ICS
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim ICS_hdr As New ICSHdr
    Dim ICS_Dtl As New ICSDtl

    Private Property dtRIS() As DataTable
        Get
            Return CType(Session("dtRIS"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtRIS") = value
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

    Private Sub Inventory_ICS_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadPage()
        End If

        txtIssuedBy.Attributes.Add("onkeydown", "return (event.keyCode!=13);")
        txtIssuedTo.Attributes.Add("onkeydown", "return (event.keyCode!=13);")
        txtDate.Attributes.Add("onkeydown", "return (event.keyCode!=13);")
    End Sub

    Protected Sub loadPage()
        txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

        dtRIS = objDerived.GetDataTable("SELECT DISTINCT AMS.RIS_Hdr.RISHdr_ID, AMS.RIS_Hdr.RIS_No, AMS.RIS_Hdr.RISDate, AMS.RIS_Hdr.RC_ID, AMS.RIS_Hdr.Func_ID,		                                                                    " &
                                         "         CASE WHEN dbo.View_RespCenter_withFunctions.Function_ID = 86 THEN dbo.View_RespCenter_withFunctions.RC_Name ELSE dbo.View_RespCenter_withFunctions.Function_Desc END AS RC_Name          " &
                                         " From AMS.item_particular INNER Join dbo.m_item ON AMS.item_particular.item_particular_id = dbo.m_item.item_particular_id INNER Join                                                              " &
                                         "         AMS.RIS_Hdr INNER Join AMS.RIS_Dtl ON AMS.RIS_Hdr.RISHdr_ID = AMS.RIS_Dtl.RISHdr_ID ON dbo.m_item.Item_ID = AMS.RIS_Dtl.Item_ID LEFT OUTER Join                                          " &
                                         "         AMS.ICS_Dtl INNER Join AMS.ICS_Hdr ON AMS.ICS_Dtl.ICSHdr_ID = AMS.ICS_Hdr.ICSHdr_ID ON AMS.RIS_Dtl.Item_ID = AMS.ICS_Dtl.Item_ID And AMS.RIS_Hdr.RIS_No = AMS.ICS_Hdr.RIS_No             " &
                                         "         INNER Join dbo.View_RespCenter_withFunctions ON AMS.RIS_Hdr.RC_ID = dbo.View_RespCenter_withFunctions.RC_ID And AMS.RIS_Hdr.Func_ID =  dbo.View_RespCenter_withFunctions.Function_ID     " &
                                         " WHERE(AMS.item_particular.useful_life <> 0) And (AMS.RIS_Dtl.ApprovedQty - ISNULL(AMS.ICS_Dtl.Qty,0)) <> 0 AND  ISNULL(AMS.RIS_Hdr.isCancelled,0) = 0 AND AMS.RIS_Dtl.StockID <> 0               " &
                                         " ORDER BY AMS.RIS_Hdr.RISDate DESC, AMS.RIS_Hdr.RIS_No DESC", CommandType.Text)
        grdRIS.DataSource = dtRIS
        grdRIS.DataBind()
        grdRIS.SelectedIndex = -1

        grdItems.DataSource = dt_Items(2)
        grdItems.DataBind()

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ' Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtRIS.DefaultView
        myview.RowFilter = "RIS_No like '%" & txtSearch.Text & "%'"
        grdRIS.DataSource = myview
        grdRIS.DataBind()
        grdRIS.SelectedIndex = -1

        grdItems.DataSource = dt_Items(2)
        grdItems.DataBind()
    End Sub

    Private Sub grdRIS_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdRIS.PageIndexChanging
        grdRIS.DataSource = dtRIS
        grdRIS.DataBind()
        grdRIS.PageIndex = e.NewPageIndex
    End Sub

    Private Sub grdRIS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdRIS.SelectedIndexChanged
        dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_RIS_ItemsFor_ICS] " & grdRIS.SelectedDataKey("RISHdr_ID") & "", CommandType.Text)
        grdItems.DataSource = dtItems
        grdItems.DataBind()
        grdItems.SelectedIndex = -1

    End Sub

    Private Sub btnSaveICS_Click(sender As Object, e As EventArgs) Handles btnSaveICS.Click
        If txtIssuedBy.Text = "" Or txtIssuedTo.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all required fileds.")

        Else
            Try
                Dim ICSNumber As String = objDerived.GetValue("SELECT [AMS].[func_GenerateICS] ('" & txtDate.Text & "','" & grdRIS.SelectedDataKey("RC_ID") & "')", CommandType.Text)
                '=-= ICS HEADER
                With ICS_hdr
                    .ICS_No = ICSNumber
                    .Date_Acquired = txtDate.Text
                    .RIS_no = grdRIS.SelectedDataKey("RIS_No")
                    .RC_ID = grdRIS.SelectedDataKey("RC_ID")
                    .Function_ID = grdRIS.SelectedDataKey("Func_ID")
                    .IssuedBy = txtIssuedBy.Text
                    .IssuedBy_Pos = txtIssuedBy_Pos.Text
                    .IssuedTo = txtIssuedTo.Text
                    .IssuedTo_Pos = txtIssuedTo_Pos.Text
                    .AccountablePerson = txtAccountablePerson.Text
                    .AccountablePerson_Pos = txtAccountablePerson_Pos.Text
                End With

                Dim ICSHdr_ID As Long = ICS_hdr.saveICSHdr()
                Session("ICSHdr_ID") = ICSHdr_ID


                For i As Integer = 0 To grdItems.Rows.Count - 1
                    Dim txtQty As TextBox = CType(grdItems.Rows(i).FindControl("txtQuantity"), TextBox)
                    Dim lblCost As Label = CType(grdItems.Rows(i).FindControl("lblCost"), Label)
                    Dim item As Integer = dtItems.Rows(i)("Item_ID")

                    If txtQty.Text <> 0.00 Or txtQty.Text <> 0 Then
                        objDerived.Execute("INSERT INTO [AMS].[ICS_Dtl] ([ICSHdr_ID],[Item_ID],[Qty],[Cost],[Status],[Remarks]) " &
                                              " VALUES('" & ICSHdr_ID & "','" & dtItems.Rows(i)("Item_ID") & "','" & txtQty.Text & "','" & lblCost.Text & "', " &
                                              " 'Issued','')", CommandType.Text)
                    End If
                Next

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                loadPage()

                btnSaveICS.Enabled = False
                btnPreviewICS.Enabled = True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub txtQuantity_TextChanged(sender As Object, e As EventArgs)

        Dim txtqty As TextBox = TryCast(sender, TextBox)
        If txtqty.Text = "" Then
            txtqty.Text = "0"
        End If

        Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
        Dim data As DataTable = dtItems

        If CType(dtItems.Rows(gvr.RowIndex)("Available_Qty"), Integer) >= CType(txtqty.Text, Integer) Then
            txtqty.Text = FormatNumber(txtqty.Text, 2)
        Else
            txtqty.Text = FormatNumber(CType(dtItems.Rows(gvr.RowIndex)("Available_Qty"), Integer), 2)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must not exceed to the available quantity.")

        End If
    End Sub

    Private Sub btnPreviewICS_Click(sender As Object, e As EventArgs) Handles btnPreviewICS.Click
        Try
            Session("Page") = "INV"
            Session("Report") = "ICS"
            Me.Page.Response.Redirect("~/MainReports/Inventory_Reports.aspx")

        Catch ex As Exception

        End Try

    End Sub


#Region "DataTables"
    Public Function dt_Items(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("Available_Qty", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("Available_Qty") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next

        Return dt

    End Function
#End Region


End Class
