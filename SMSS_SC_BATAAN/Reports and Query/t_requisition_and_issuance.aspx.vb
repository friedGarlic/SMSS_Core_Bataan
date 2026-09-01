Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control


Partial Class t_requisition_and_issuance

    Inherits System.Web.UI.Page

    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

    Private prhdr As New t_purchase_request_hdr
    Private objMREHdr As New MREHdr

#Region "Property"

    Private Property popen() As DataTable
        Get
            Return CType(Session("popen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("popen") = value
        End Set
    End Property

    Private Property popentrans() As DataTable
        Get
            Return CType(Session("popentrans"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("popentrans") = value
        End Set
    End Property

    Private Property pFunction() As DataTable
        Get
            Return CType(Session("pFunction"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pFunction") = value
        End Set
    End Property

    Private Property pRC() As DataTable
        Get
            Return CType(Session("pRC"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRC") = value
        End Set
    End Property

    Private Property ListEmployee() As DataTable
        Get
            Return CType(Session("ListEmployee"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("ListEmployee") = value
        End Set
    End Property

#End Region

    Private Property dtRIS() As DataTable
        Get
            Return CType(Session("dtRIS"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtRIS") = value
        End Set
    End Property




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
            Me.txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")

            drpDept.DataSource = objDerived.GetDataTable("SELECT * FROM  dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
            drpDept.DataTextField = ("RC_Name")
            drpDept.DataValueField = ("RC_ID")
            drpDept.DataBind()
            drpDept.Items.Insert(0, "Select")

            drpFunction.Items.Insert(0, "Select")

            dtRIS = objDerived.GetDataTable("EXEC [AMS].[sp_RIS_List]", CommandType.Text)
            grdRIS.DataSource = dtRIS
            grdRIS.DataBind()

            Session("Page") = "RQ"
            LoadRdChoice()

        End If

        txtrisnumber.Attributes.Add("onkeypress", "return fun1(event,'" & btnRISNo.ClientID & "')")
        txtdatefrom.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")
        txtdateto.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")

    End Sub

    Protected Sub grdRIS_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdRIS.PageIndexChanging
        grdRIS.DataSource = dtRIS
        grdRIS.DataBind()
        grdRIS.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub drpDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpDept.SelectedIndexChanged
        drpFunction.DataSource = objDerived.GetDataTable("SELECT * FROM  dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & drpDept.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        drpFunction.DataTextField = "Function_Desc"
        drpFunction.DataValueField = "Function_ID"
        drpFunction.DataBind()

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        LoadRdChoice()
    End Sub

    Protected Sub LoadRdChoice()
        If RadioButtonList1.SelectedItem.Value = 1 Then
            MultiView1.SetActiveView(Me.View1)

        ElseIf RadioButtonList1.SelectedItem.Value = 2 Then
            MultiView1.SetActiveView(Me.View2)

        ElseIf RadioButtonList1.SelectedItem.Value = 3 Then
            MultiView1.SetActiveView(Me.View3)

        End If
    End Sub

    Protected Sub gvopen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRIS.SelectedIndexChanged

        Session("ris_no") = grdRIS.SelectedDataKey("RIS_No")
        Session("RISHdr_ID") = grdRIS.SelectedDataKey("RISHdr_ID")

        If Session("Action") = "Cancel" Then
            Try
                Dim isCancelled As Boolean = objDerived.GetValue("SELECT ISNULL([isCancelled],0) FROM [AMS].[RIS_Hdr] WHERE [RISHdr_ID] = '" & grdRIS.SelectedDataKey("RISHdr_ID") & "'", CommandType.Text)

                If isCancelled = True Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected RIS is already cancelled.")
                Else
                    If grdRIS.SelectedDataKey("StockID") <> 0 Then
                        objDerived.Execute("UPDATE [AMS].[RIS_Hdr] SET [isCancelled] = 1, RIS_No = RIS_No + '-(Cancelled)' WHERE [RISHdr_ID] = '" & Session("RISHdr_ID") & "'", CommandType.Text)
                        objDerived.Execute("DELETE FROM [AMS].[TbStock_Ledger] WHERE [Ref] = '" & Session("ris_no") & "'", CommandType.Text)
                        objDerived.Execute("EXEC [AMS].[sp_RIS_Cancellation] '" & Session("RISHdr_ID") & "'", CommandType.Text)

                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "RIS has been successfully cancelled.")

                        dtRIS = objDerived.GetDataTable("EXEC [AMS].[sp_RIS_List]", CommandType.Text)
                        grdRIS.DataSource = dtRIS
                        grdRIS.DataBind()

                    Else
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select RIS for supplies.")
                    End If
                End If


            Catch ex As Exception
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, pls contact administrator.")
            End Try

        Else
            Session("Page") = "RQ"
            Session("Report") = "RIS"
            Me.Page.Response.Redirect("~/MainReports/Inventory_Reports.aspx")
        End If

    End Sub

    Protected Sub btnDepartment_Click(sender As Object, e As EventArgs) Handles btnDepartment.Click
        Dim myview As DataView
        myview = dtRIS.DefaultView
        myview.RowFilter = "RC_ID = '" & drpDept.SelectedItem.Value & "' AND Func_ID = '" & drpFunction.SelectedItem.Value & "'"
        grdRIS.DataSource = myview
        grdRIS.DataBind()

    End Sub
    Protected Sub btnRISNo_Click(sender As Object, e As EventArgs) Handles btnRISNo.Click
        Dim myview As DataView
        myview = dtRIS.DefaultView
        myview.RowFilter = "RIS_No like '%" & replaceapostrophe(txtrisnumber.Text) & "%'"
        grdRIS.DataSource = myview
        grdRIS.DataBind()

    End Sub
    Protected Sub btnByDate_Click(sender As Object, e As EventArgs) Handles btnByDate.Click
        Dim myview As DataView
        myview = dtRIS.DefaultView
        myview.RowFilter = "RISDate >= '" & txtdatefrom.Text & "' And RISDate <= '" & txtdateto.Text & "'"
        'myview.RowFilter = "RISDate BETWEEN '" & txtdatefrom.Text & "' And '" & txtdateto.Text & "'"
        grdRIS.DataSource = myview
        grdRIS.DataBind()

    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function


    Protected Sub lnkCancel_Click(sender As Object, e As EventArgs)
        Session("Action") = "Cancel"
    End Sub
    Protected Sub lnkPreview_Click(sender As Object, e As EventArgs)
        Session("Action") = "Preview"
    End Sub
End Class
