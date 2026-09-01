Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class procurement_t_PR_DBM
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Dim DBM_PR_Hdr As New DBM_PR.DBM_PR
    Dim DBM_PR_Dtl As New DBM_PR.DBM_PR_Dtl
    Private prhdr As New t_purchase_request_hdr


#Region "property"
    Private Property dtDBM_Items() As DataTable
        Get
            Return CType(Session("dtDBM_Items"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDBM_Items") = value
        End Set
    End Property

    Private Property dtDBMList() As DataTable
        Get
            Return CType(Session("dtDBMList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDBMList") = value
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
   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            ddYear.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.APP WHERE STATUS = 2", CommandType.Text)
            ddYear.DataTextField = ("year")
            ddYear.DataValueField = ("year")
            ddYear.DataBind()
            ddYear.Items.Insert(0, "Select")

            ddQuarter.Items.Insert(0, "Select")
            ddRequestedBy.Items.Insert(0, "Select")

            grdDBMList.DataSource = Createdatatable1(4)
            grdDBMList.DataBind()

            grdItems.DataSource = Createdatatable2(5)
            grdItems.DataBind()

            ddCheckBy.DataSource = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, empsig_id FROM AMS.BAC_Members ORDER BY Name", CommandType.Text)
            ddCheckBy.DataTextField = ("Name")
            ddCheckBy.DataValueField = ("empsig_id")
            ddCheckBy.DataBind()
            ddCheckBy.Items.Insert(0, "Select")

            ddNotedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, empsig_id FROM AMS.BAC_Members ORDER BY Name", CommandType.Text)
            ddNotedBy.DataTextField = ("Name")
            ddNotedBy.DataValueField = ("empsig_id")
            ddNotedBy.DataBind()
            ddNotedBy.Items.Insert(0, "Select")
        End If
    End Sub

    Protected Sub ddYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddQuarter.SelectedItem.Text = "Select" Then
            btnSearch.Enabled = False
        Else
            btnSearch.Enabled = True
        End If

        dtDBMList = objDerived.GetDataTable("SELECT *,Convert(bit,1) AS isVisible FROM AMS.DBM_PR WHERE Year = '" & ddYear.SelectedItem.Value & "' ORDER BY Quarter", CommandType.Text)
        If dtDBMList.Rows.Count < 4 Then
            dtDBMList.Merge(Createdatatable1(3 - dtDBMList.Rows.Count))
        End If
        grdDBMList.DataSource = dtDBMList
        grdDBMList.DataBind()

    End Sub

    Protected Sub ddQuarter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSearch.Enabled = True
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ddRequestedBy.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_RequestedBy_DBM]", CommandType.Text)
        ddRequestedBy.DataTextField = ("full_name")
        ddRequestedBy.DataValueField = ("full_name")
        ddRequestedBy.DataBind()
        ddRequestedBy.Items.Insert(0, "Select")

        LoadDisplayItems()

    End Sub

    Protected Sub LoadDisplayItems()
        dtDBM_Items = objDerived.GetDataTable("EXEC [AMS].[sp_pr_dbm] '" & ddYear.SelectedItem.Value & "','" & ddQuarter.SelectedItem.Value & "'", CommandType.Text)
        grdItems.DataSource = dtDBM_Items
        grdItems.DataBind()

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT * FROM AMS.DBM_PR WHERE Year = '" & ddYear.SelectedItem.Value & "' AND Quarter = '" & ddQuarter.SelectedItem.Value & "'", CommandType.Text)

        If dt.Rows.Count <> 0 Or dtDBM_Items.Rows.Count = 0 Then
            btnCreatePR.Enabled = False
        Else
            btnCreatePR.Enabled = True
        End If

        Dim GrandTotal As Decimal
        For i As Integer = 0 To grdItems.Rows.Count - 1
            Dim x As Decimal
            x = CType(grdItems.Rows(i).Cells(5).FindControl("lblTotalCost"), Label).Text
            GrandTotal = GrandTotal + x
        Next

        txtTotalAmount.Text = FormatNumber(GrandTotal, 2)
        Session("TotalAmount") = FormatNumber(GrandTotal, 2)
    End Sub

    Protected Sub btnCreatePR_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            If ddRequestedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory for requested by.")
                Exit Sub
            End If

            '=== CHECKING IF EXIST
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM AMS.DBM_PR WHERE Year = '" & ddYear.SelectedItem.Value & "' AND Quarter = '" & ddQuarter.SelectedItem.Value & "'", CommandType.Text)
            If dt.Rows.Count <> 0 Then
                Dim qtr As String = ""
                If ddQuarter.SelectedItem.Value = 1 Then
                    qtr = "1st Quarter"
                ElseIf ddQuarter.SelectedItem.Value = 2 Then
                    qtr = "2nd Quarter"
                ElseIf ddQuarter.SelectedItem.Value = 3 Then
                    qtr = "3rd Quarter"
                ElseIf ddQuarter.SelectedItem.Value = 4 Then
                    qtr = "4th Quarter"
                End If

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "DBM Purchase Request for the Year " & ddYear.SelectedItem.Value & " and " & qtr & " already exist.")
                Exit Sub
            End If


            Dim cb1 As CheckBox
            Dim x1 As Decimal = 0
            Dim x2 As Decimal = 0
            For i As Integer = 0 To grdItems.Rows.Count - 1
                cb1 = CType(Me.grdItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb1.Checked = True Then
                    x1 = dtDBM_Items.Rows(i)("Qty") * dtDBM_Items.Rows(i)("UnitCost")
                    x2 = x2 + x1
                End If
            Next

            Session("DBM_ABC") = FormatNumber(x2, 2)

            '=-= Saving PR_Hdr (Goods)
            Dim pr_no As String
            pr_no = objDerived.GetValue("select [AMS].[func_GeneratePR_Toledo]('" & Date.Today.ToString("MM/dd/yyyy") & "')", CommandType.Text)

            With prhdr
                .PR_Year = Year(Date.Today.ToString("MM/dd/yyyy"))
                .PR_Date = Date.Today.ToString("MM/dd/yyyy")
                .pr_no = pr_no
                .RC_ID = 0
                .Function_ID = 0
                .remarks = "Consolidation of All P.R. for DBM"
                .Transaction_type = 0
                .Project_ID = 0
                .Program_id = 0
                .ABC = Session("DBM_ABC")
                .Requestedby = ddRequestedBy.SelectedItem.Text
                .Approvedby = objDerived.GetValue("SELECT UPPER(full_name) FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                .Date_Submitted = Date.Today.ToString("MM/dd/yyyy")
                .Date_gso_rcv = Date.Today.ToString("MM/dd/yyyy")
                .IsCancelled = False
                .IsApproved = False
                .isOnBid = False
                .POHdr_ID = 0
                .withWinner = False
                .withPO = False
                .declarationDate = "01/01/1900"
                .rcv_date = "01/01/1900"
                .isPublicInfra = False
                .isStraight = False
                .DateApproved_PR_Mayor = "01/01/1900"
                .DateReceived_PR_Mayor = "01/01/1900"
                .isApproved_PR_Mayor = False
                .isReceived_PR_Mayor = False
                .DateDisApprove = "01/01/1900"
                .isGasoline = False
                .pr_period_key_id = 0
                .pr_invoice_hdr_id = 0
                .isReimbursement = False
                .isContract = False
                .isEditable = True
                .RequestingOfficer = ""
                .Position = ""
                .isContinuing = False
                .mode_of_procurement_id = 0
                .isTrustFund = False
                .GA_ID = 0
                .UserID = Session("@UserName")

            End With
            Dim prhdrID As Long = prhdr.save

            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET CheckBy = '" & ddCheckBy.SelectedItem.Value & "', NotedBy = '" & ddNotedBy.SelectedItem.Value & "', DateCheck = '" & Date.Today.ToString("MM/dd/yyyy") & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)


            Dim cb2 As CheckBox
            Dim number1 As String
            Dim number2 As String
            number2 = "0"
            For i As Integer = 0 To grdItems.Rows.Count - 1
                cb2 = CType(Me.grdItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb2.Checked = True Then
                    number1 = objDerived.GetValue("EXEC [AMS].[sp_dbm_PRNumber] '" & ddQuarter.SelectedItem.Value & "', '" & dtDBM_Items.Rows(i)("Item_ID") & "'", CommandType.Text)
                    If number2 = "0" Then
                        number2 = number1
                    Else
                        number2 = number2 & " / " & number1
                    End If
                End If
            Next

            'Dim PRNumber As String
            'PRNumber = objDerived.GetValue("EXEC [AMS].[sp_GetPRNumber_DBM] '" & ddYear.SelectedItem.Value & "','" & ddQuarter.SelectedItem.Value & "'", CommandType.Text)

            '=== SAVE AMS.DBM_PR
            With DBM_PR_Hdr
                .PRDBM_Date = Date.Today.ToString("MM/dd/yyyy")
                .Year = ddYear.SelectedItem.Value
                .Quarter = ddQuarter.SelectedItem.Value
                .TotalAmount = Session("DBM_ABC")
                .PR_No = "Consolidated PR Number : " + number2
                .ApprovedBy = objDerived.GetValue("SELECT UPPER(full_name) FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                .RequestedBy = ddRequestedBy.SelectedItem.Text
                .BAC_HeadSecretariat = ddNotedBy.SelectedItem.Text
                .BAC_Secretariat = ddCheckBy.SelectedItem.Text
                .PRHdr_ID = prhdrID
            End With

            Dim DBM_ID As Long = DBM_PR_Hdr.save
            Session("DBM_ID") = DBM_ID


            '=== SAVE AMS.DBM_PR_Dtl
            Dim cb As CheckBox
            For i As Integer = 0 To grdItems.Rows.Count - 1
                cb = CType(Me.grdItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Checked = True Then
                    With DBM_PR_Dtl
                        .DBM_ID = DBM_ID
                        .GA_ID = dtDBM_Items.Rows(i)("GA_ID")
                        .Item_ID = dtDBM_Items.Rows(i)("Item_ID")
                        .Qty = dtDBM_Items.Rows(i)("Qty")
                        .Cost = dtDBM_Items.Rows(i)("UnitCost")
                        .save()
                    End With
                End If
            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            dtDBMList = objDerived.GetDataTable("SELECT *,Convert(bit,1) AS isVisible FROM AMS.DBM_PR WHERE Year = '" & ddYear.SelectedItem.Value & "' ORDER BY Quarter", CommandType.Text)
            grdDBMList.DataSource = dtDBMList
            grdDBMList.DataBind()

            btnCreatePR.Enabled = False
            btnPreview.Enabled = True
        Catch ex As Exception
        End Try
      

    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/procurement/rpt_PR_DBM.aspx")
    End Sub

    Protected Sub grdDBMList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("DBM_ID") = grdDBMList.SelectedDataKey("DBM_ID")

        If Lbtn = "View" Then
            Me.Page.Response.Redirect("~/procurement/rpt_PR_DBM.aspx")
        End If

    End Sub

    Protected Sub ddRequestedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub lnkView_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "View"
    End Sub

    Public Function Createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Year", GetType(Integer))
        dt.Columns.Add("Quarter", GetType(Integer))
        dt.Columns.Add("TotalAmount", GetType(Decimal))
        dt.Columns.Add("DBM_ID", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Year") = DBNull.Value
            dr("Quarter") = DBNull.Value
            dr("TotalAmount") = DBNull.Value
            dr("DBM_ID") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function Createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("RowNo", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("UnitCost", GetType(Decimal))
        dt.Columns.Add("TotalCost", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("RowNo") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("UnitCost") = DBNull.Value
            dr("TotalCost") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
End Class
