Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class procurement_t_purchase_request_receiving
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim bc As New ManageButtons


#Region "property"
    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property
    Private Property dtSubmittedPR() As DataTable
        Get
            Return CType(Session("dtSubmittedPR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSubmittedPR") = value
        End Set
    End Property
    Private Property pRoleName() As DataTable
        Get
            Return CType(Session("pRoleName"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRoleName") = value
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

#End Region
#Region "function"
    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("rc_name", GetType(String))
        dt.Columns.Add("Function_Desc", GetType(String))
        dt.Columns.Add("Date_Submitted", GetType(Date))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("ABC", GetType(Decimal))
    

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("rc_name") = DBNull.Value
            dr("Function_Desc") = DBNull.Value
            dr("Date_Submitted") = DBNull.Value
            dr("isVisible") = False
            dr("ABC") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Sub PRCounter()
        Dim dtToday As DataTable
        dtToday = objDerived.GetDataTable("EXEC [AMS].[sp_PR_ReceivingList] '" & 1 & "'", CommandType.Text)
        lblToday.Text = dtToday.Rows.Count
        If lblToday.Text = "0" Then
            lblToday.Visible = False
        Else
            lblToday.Visible = True
        End If


        Dim dtWeek As DataTable
        dtWeek = objDerived.GetDataTable("EXEC [AMS].[sp_PR_ReceivingList] '" & 2 & "'", CommandType.Text)
        lblthisWeek.Text = dtWeek.Rows.Count
        If lblthisWeek.Text = "0" Then
            lblthisWeek.Visible = False
        Else
            lblthisWeek.Visible = True
        End If


        Dim dtMonth As DataTable
        dtMonth = objDerived.GetDataTable("EXEC [AMS].[sp_PR_ReceivingList] '" & 3 & "'", CommandType.Text)
        lblThisMonth.Text = dtMonth.Rows.Count
        If lblThisMonth.Text = "0" Then
            lblThisMonth.Visible = False
        Else
            lblThisMonth.Visible = True
        End If


        Dim dtYear As DataTable
        dtYear = objDerived.GetDataTable("EXEC [AMS].[sp_PR_ReceivingList] '" & 4 & "'", CommandType.Text)
        lblall.Text = dtYear.Rows.Count
        If lblall.Text = "0" Then
            lblall.Visible = False
        Else
            lblall.Visible = True
        End If
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
            Dim role() As String = Roles.GetRolesForUser(usr.UserName)
            Dim rolename As String = role(0)

            Session("RoleName") = rolename
            pRoleName = objDerived.GetDataTable("EXEC [dbo].[sp_GetRC_ByRole_systemManager] '" & rolename & "'", CommandType.Text)
            pRC = objDerived.GetDataTable("exec dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)
            ddRC.DataSource = CType(pRC, DataTable)
            ddRC.DataTextField = ("rc_name")
            ddRC.DataValueField = ("rc_id")
            ddRC.DataBind()
            ddRC.Items.Insert(0, "Select")

            Session("btnActive") = "Today"
            LoadButtons()
            PRCounter()

            Me.Session("ID") = CType(btnToday, Object)

        End If
    End Sub

    Protected Sub gvPurchaseRequest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvPurchaseRequest.SelectedIndexChanged
        Session("prhdr_id") = gvPurchaseRequest.SelectedDataKey("prhdr_id")

        Try
            If Lbtn = "report" Then
                Dim url As String = "rpt_purchase_request_pop_up.aspx?"
                Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
                ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

            ElseIf Lbtn = "rcv" Then
                btnReceiveDoc.Focus()
                txtDateReceive.Text = Date.Today.ToString("MM/dd/yyyy")
                ModalPopupExtender123.Show()

            ElseIf Lbtn = "return" Then
                objDerived.GetRecords("UPDATE [AMS].[PR_Hdr] SET [isFinal] = 0 WHERE [prhdr_id] = '" & Session("prhdr_id") & "'", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel22, "Purchase request has been successfully return for editing.")

                LoadButtons()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Function GetPTType(ByVal isNonPPMP As Object) As String
        ' Check if the value is DBNull or nothing (empty row)
        If isNonPPMP Is DBNull.Value OrElse isNonPPMP Is Nothing Then
            Return ""  ' Display nothing for empty rows

            ' Check if the value is 0 or NULL (treated as "PPMP-Based")
        ElseIf Convert.ToInt32(isNonPPMP) = 0 Then
            Return "PPMP-Based"

            ' Check if the value is 1 or True (treated as "Non-PPMP")
        ElseIf Convert.ToInt32(isNonPPMP) = 1 Then
            Return "Non-PPMP"
        End If

        ' Default case if none of the conditions are met (optional)
        Return ""
    End Function



    Protected Sub lnkview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "report"
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "rcv"
    End Sub

    Protected Sub lnkReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "return"
    End Sub

    Protected Sub btnToday_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToday.Click
        Session("btnActive") = "Today"
        LoadButtons()

    End Sub

    Protected Sub btnThisWeek_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThisWeek.Click
        Session("btnActive") = "ThisWeek"
        LoadButtons()

    End Sub

    Protected Sub btnThisMonth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThisMonth.Click
        Session("btnActive") = "ThisMonth"
        LoadButtons()

    End Sub

    Protected Sub btnALL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnALL.Click
        Session("btnActive") = "ThisYear"
        LoadButtons()

    End Sub

    Protected Sub btnReceiveDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceiveDoc.Click
        objDerived.GetRecords("Update ams.PR_Hdr set rcv_date='" & txtDateReceive.Text & "', isEditable = 0 where prhdr_id=" & gvPurchaseRequest.SelectedDataKey(0) & "", CommandType.Text)

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel22, "Purchase Request has been sent to the City General Services Office." & vbCrLf & "For approval")

        LoadButtons()
        PRCounter()

    End Sub

    Protected Function CheckIfTitleExists(ByVal strval As Boolean) As String
        If strval = True Then
            Return "Reimbursement"
        Else
            Return ""
        End If
    End Function

    Protected Sub LoadButtons()
        Dim strRC_ID As String
        If ddRC.SelectedValue = "Select" Then
            strRC_ID = 0
        Else
            strRC_ID = ddRC.SelectedValue
        End If
        If Session("btnActive") = "Today" Then
            btnToday.BackColor = Drawing.Color.LightGreen
            btnThisWeek.BackColor = Drawing.Color.Transparent
            btnThisMonth.BackColor = Drawing.Color.Transparent
            btnALL.BackColor = Drawing.Color.Transparent

            dtSubmittedPR = objDerived.GetDataTable("EXEC [AMS].[sp_PR_ReceivingList] '" & 1 & "','" & strRC_ID & "'", CommandType.Text)
            If dtSubmittedPR.Rows.Count < 10 Then
                dtSubmittedPR.Merge(createdatatable(10 - dtSubmittedPR.Rows.Count))
            End If
            gvPurchaseRequest.DataSource = dtSubmittedPR
            gvPurchaseRequest.DataBind()

        ElseIf Session("btnActive") = "ThisWeek" Then
            btnToday.BackColor = Drawing.Color.Transparent
            btnThisWeek.BackColor = Drawing.Color.LightGreen
            btnThisMonth.BackColor = Drawing.Color.Transparent
            btnALL.BackColor = Drawing.Color.Transparent

            dtSubmittedPR = objDerived.GetDataTable("EXEC [AMS].[sp_PR_ReceivingList] '" & 2 & "','" & strRC_ID & "'", CommandType.Text)
            If dtSubmittedPR.Rows.Count < 10 Then
                dtSubmittedPR.Merge(createdatatable(10 - dtSubmittedPR.Rows.Count))
            End If
            gvPurchaseRequest.DataSource = dtSubmittedPR
            gvPurchaseRequest.DataBind()

        ElseIf Session("btnActive") = "ThisMonth" Then
            btnToday.BackColor = Drawing.Color.Transparent
            btnThisWeek.BackColor = Drawing.Color.Transparent
            btnThisMonth.BackColor = Drawing.Color.LightGreen
            btnALL.BackColor = Drawing.Color.Transparent

            dtSubmittedPR = objDerived.GetDataTable("EXEC [AMS].[sp_PR_ReceivingList] '" & 3 & "','" & strRC_ID & "'", CommandType.Text)
            If dtSubmittedPR.Rows.Count < 10 Then
                dtSubmittedPR.Merge(createdatatable(10 - dtSubmittedPR.Rows.Count))
            End If
            gvPurchaseRequest.DataSource = dtSubmittedPR
            gvPurchaseRequest.DataBind()

        ElseIf Session("btnActive") = "ThisYear" Then
            btnToday.BackColor = Drawing.Color.Transparent
            btnThisWeek.BackColor = Drawing.Color.Transparent
            btnThisMonth.BackColor = Drawing.Color.Transparent
            btnALL.BackColor = Drawing.Color.LightGreen

            dtSubmittedPR = objDerived.GetDataTable("EXEC [AMS].[sp_PR_ReceivingList] '" & 4 & "','" & strRC_ID & "'", CommandType.Text)
            If dtSubmittedPR.Rows.Count < 10 Then
                dtSubmittedPR.Merge(createdatatable(10 - dtSubmittedPR.Rows.Count))
            End If
            gvPurchaseRequest.DataSource = dtSubmittedPR
            gvPurchaseRequest.DataBind()

        End If

    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        LoadButtons()
    End Sub
End Class
