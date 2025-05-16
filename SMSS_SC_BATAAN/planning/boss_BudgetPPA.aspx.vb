Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System
Imports System.Runtime.InteropServices
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO


Partial Class filemaintenance_boss_BudgetPPA
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule

    Dim LBPF_3_Hdr As New BOSS.LBPF_3_Hdr
    Dim LBPF_3_Dtl As New BOSS.LBPF_3_Dtl

    Dim LBEF_2_Hdr As New BOSS.LBEF_2_Hdr
    Dim LBEF_2_Dtl As New BOSS.LBEF_2_Dtl

    Dim m_Program As New BOSS.m_Program
    Dim m_Project As New BOSS.m_Project

    Private Property dtAccounts() As DataTable
        Get
            Return CType(Session("dtAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAccounts") = value
        End Set
    End Property
    Private Property pdt() As DataTable
        Get
            Return CType(Session("pdt"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pdt") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' obj.GetAccessRight(Me.Session("@UserName"), Page)
            'If obj.HasAccess = False Then
            '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            'End If


            pdt = objDerived.GetDataTable("SELECT * FROM AMS.APP WHERE status IN (1,2) ORDER BY Year DESC", CommandType.Text)
            ddYear.DataSource = pdt
            ddYear.DataTextField = ("Year")
            ddYear.DataValueField = ("app_id")
            ddYear.DataBind()
            ddYear.Items.Insert(0, "Select")
            'ddYear.selecteditem.text = Date.Today.Year

            'Dim Stats As Integer = objDerived.GetValue("Select Status from AMS.APP where year ='" & Session("CYear") & "'", CommandType.Text)
            'Session("Stats") = Stats
            ddDepartment.DataSource = objDerived.GetDataTable("SELECT DISTINCT RC_Name,RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
            ddDepartment.DataTextField = ("RC_Name")
            ddDepartment.DataValueField = ("RC_ID")
            ddDepartment.DataBind()
            ddDepartment.Items.Insert(0, "Select")

            ddFunction.Items.Insert(0, "Select")
            ddAllotment.Items.Insert(0, "Select")
            ddAccounts.Items.Insert(0, "Select")


            drpFund.DataSource = objDerived.GetDataTable("select * from [ACCNTG].[Funds]", CommandType.Text)
            drpFund.DataTextField = ("Description")
            drpFund.DataValueField = ("F_ID")
            drpFund.DataBind()
            drpFund.Items.Insert(0, "Select")



            grdPPA_List.DataSource = createdatatable3(4)
            grdPPA_List.DataBind()

            grdAccounts.DataSource = createdatatable1(4)
            grdAccounts.DataBind()

            GrdLedger.DataSource = createdatatable2(4)
            GrdLedger.DataBind()

            Session("Update") = 0

        End If
    End Sub
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn

        myDataColumn = New DataColumn()
        dt.Columns.Add("PR_Amt", GetType(Decimal))
        dt.Columns.Add("GA_ID", GetType(Int64))
        dt.Columns.Add("BGA_ID", GetType(Int64))
        dt.Columns.Add("GA_Code", GetType(String))
        dt.Columns.Add("Budget_Year", GetType(Integer))
        dt.Columns.Add("RC_ID", GetType(Int64))
        dt.Columns.Add("Function_ID", GetType(Int64))
        dt.Columns.Add("Program_ID", GetType(Int64))
        dt.Columns.Add("Project_ID", GetType(Int64))
        dt.Columns.Add("MOOE", GetType(Decimal))
        dt.Columns.Add("CO", GetType(Decimal))
        dt.Columns.Add("Project_Code", GetType(String))
        dt.Columns.Add("Program_Code", GetType(String))
        dt.Columns.Add("PPA_Desc", GetType(String))
        dt.Columns.Add("Total_Cost", GetType(Integer))
        dt.Columns.Add("GA_Title2", GetType(String))
        dt.Columns.Add("AllotmentClass_ID", GetType(Int64))
        dt.Columns.Add("GA_Title", GetType(String))
        dt.Columns.Add("F_ID", GetType(Int64))
        dt.Columns.Add("Balance", GetType(Decimal))
        dt.Columns.Add("ApprovedFinal", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PR_Amt") = 0.0
            dr("GA_ID") = 0
            dr("BGA_ID") = 0
            dr("GA_Code") = ""
            dr("Budget_Year") = 0
            dr("RC_ID") = 0.00
            dr("Function_ID") = 0
            dr("Program_ID") = 0
            dr("Project_ID") = 0
            dr("MOOE") = 0.00
            dr("CO") = 0.00
            dr("Project_Code") = ""
            dr("Program_Code") = ""
            dr("PPA_Desc") = ""
            dr("Total_Cost") = 0
            dr("GA_Title2") = ""
            dr("F_ID") = 0
            dr("Balance") = 0
            dr("ApprovedFinal") = 0

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn

        myDataColumn = New DataColumn()
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("Budget_Year", GetType(String))
        dt.Columns.Add("RC_ID", GetType(String))
        dt.Columns.Add("Function_ID", GetType(String))
        dt.Columns.Add("GA_ID", GetType(String))
        dt.Columns.Add("Program_ID", GetType(String))
        dt.Columns.Add("Project_ID", GetType(String))
        dt.Columns.Add("ABC", GetType(String))
        dt.Columns.Add("Particulars", GetType(String))
        dt.Columns.Add("MOP", GetType(String))
        dt.Columns.Add("OBR_DateApproved", GetType(String))
        dt.Columns.Add("PO_Date", GetType(String))
        dt.Columns.Add("PO_DateApproved", GetType(String))
        dt.Columns.Add("Received_Date", GetType(String))
        dt.Columns.Add("AIR_Date", GetType(String))
        dt.Columns.Add("prhdr_id", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = ""
            dr("Budget_Year") = ""
            dr("RC_ID") = ""
            dr("Function_ID") = ""
            dr("GA_ID") = ""
            dr("Program_ID") = ""
            dr("Project_ID") = ""
            dr("ABC") = 0
            dr("Particulars") = ""
            dr("MOP") = ""
            dr("OBR_DateApproved") = ""
            dr("PO_Date") = ""
            dr("PO_DateApproved") = ""
            dr("Received_Date") = ""
            dr("AIR_Date") = ""
            dr("prhdr_id") = ""

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function createdatatable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn

        myDataColumn = New DataColumn()
        dt.Columns.Add("Budget_Year", GetType(Integer))
        dt.Columns.Add("RC_ID", GetType(Int64))
        dt.Columns.Add("Function_ID", GetType(Int64))
        dt.Columns.Add("Program_ID", GetType(Int64))
        dt.Columns.Add("Project_ID", GetType(Int64))
        dt.Columns.Add("MOOE", GetType(Decimal))
        dt.Columns.Add("CO", GetType(Decimal))
        dt.Columns.Add("Project_Code", GetType(String))
        dt.Columns.Add("Program_Code", GetType(String))
        dt.Columns.Add("PPA_Desc", GetType(String))
        dt.Columns.Add("FundSource", GetType(String))
        dt.Columns.Add("F_ID", GetType(Int64))
        dt.Columns.Add("ApprovedFinal", GetType(Decimal))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Budget_Year") = 0
            dr("RC_ID") = 0.00
            dr("Function_ID") = 0
            dr("Program_ID") = 0
            dr("Project_ID") = 0
            dr("MOOE") = 0.00
            dr("CO") = 0.00
            dr("Project_Code") = ""
            dr("Program_Code") = ""
            dr("Program_Code") = ""
            dr("PPA_Desc") = ""
            dr("FundSource") = ""
            dr("F_ID") = 0
            dr("ApprovedFinal") = 0.00
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Private Function IsFileInUse(ByVal filePath As String) As Boolean
        Try
            ' Try to open the file exclusively.
            Using fileStream As New FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                ' If we get here, the file is not in use
                Return False
            End Using
        Catch ex As IOException
            ' If an IOException is thrown, the file is in use or locked
            Return True
        End Try
    End Function




    Protected Sub ddYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If ddYear.SelectedItem.value = 1 Then
        '    Session("CYear") = 2021
        'ElseIf ddYear.SelectedItem.value = 2 Then
        '    Session("CYear") = 2022
        'Else
        '    Session("CYear") = 2023
        'End If
        Session("CYear") = ddYear.SelectedItem.Text
        Session("Stats") = Session("CYear")
    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddFunction.DataSource = objDerived.GetDataTable("SELECT DISTINCT Function_Desc,Function_ID FROM dbo.View_RespCenter_withFunctions where function_id = 86 ORDER BY Function_Desc", CommandType.Text)
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")

        lblappstatus.Text = Session("CYear")
        Session("CY") = Session("CYear")

        Dim Stat As String = objDerived.GetValue("Select Status from AMS.APP where year ='" & lblappstatus.Text & "'", CommandType.Text)
        If Stat = 1 Then
            lblappstatus.Text = "Planning"
        Else
            lblappstatus.Text = "Executing"
        End If
        If ddFunction.Text = "Select" And drpFund.Text = "Select" Then
            grdPPA_List.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_BudgetPPA] WHERE Budget_Year = '" & ddYear.SelectedItem.Text & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & 0 & "' AND F_ID = " & 0 & " ORDER BY PPA_Desc", CommandType.Text)
            grdPPA_List.DataBind()
        ElseIf ddFunction.Text = "Select" And drpFund.Text <> 0 Then
            grdPPA_List.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_BudgetPPA] WHERE Budget_Year = '" & ddYear.SelectedItem.Text & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & 86 & "' AND F_ID = " & drpFund.SelectedItem.Value & " ORDER BY PPA_Desc", CommandType.Text)
            grdPPA_List.DataBind()
        Else
            grdPPA_List.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_BudgetPPA] WHERE Budget_Year = '" & ddYear.SelectedItem.Text & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND F_ID = " & drpFund.SelectedItem.Value & " ORDER BY PPA_Desc", CommandType.Text)
            grdPPA_List.DataBind()
        End If

    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'grdPPA_List.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_BudgetPPA] WHERE Budget_Year = '" & ddYear.SelectedItem.Text & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "'ORDER BY PPA_Desc", CommandType.Text)
        'grdPPA_List.DataBind()

    End Sub

    Protected Sub btnSavePPA_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Session("Stats") = 2 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The APP status is already executing")
            Else

                AddTrace(txtApproved.Text)

         


                If CBIsInfra.Checked = True Then
                    Session("isInfra") = True
                Else
                    Session("isInfra") = False
                End If

                If txtPPA_Desc.Text = "" Or txtApproved.Text = "" Or txtApproved.Text = "0.00" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
                    Exit Sub
                End If

                Dim intTrap As String = objDerived.GetValue("SELECT PPA_desc FROM [dbo].[View_FM_BudgetPPA] WHERE Budget_Year = '" & ddYear.SelectedItem.Text & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND F_ID = " & drpFund.SelectedItem.Value & " and PPA_desc='" & txtPPA_Desc.Text & "' ORDER BY PPA_Desc", CommandType.Text)

                If btnSavePPA.Text = "SAVE" Then

                    If intTrap <> "" Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "This PPA is already exist, Please change the PPA Description.")
                        Exit Sub
                    Else

                    End If

                End If



                Dim ProgCode As String
                Dim Cnt As Integer
                Dim Program_Code As String
                ProgCode = objDerived.GetValue("SELECT TOP(1)ProgramCode FROM [dbo].[View_FM_ProgramCode] WHERE RC_ID = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
                Cnt = objDerived.GetValue("SELECT COUNT(RC_ID)  FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Program AS m_Program WHERE Budget_Year = '" & Session("CYear") & "' GROUP BY Budget_Year", CommandType.Text)

                If Cnt = 0 Then
                    Cnt = 1
                Else
                    Cnt = Cnt + 1
                End If

                Program_Code = ProgCode + "-" + CType(Cnt, String)
                '==== SAVE m_Program
                With m_Program
                    .Program_Name = txtPPA_Desc.Text
                    .Program_Code = Program_Code
                    .Sector_ID = 0
                    .SubSector_ID = 0
                    .F_ID = drpFund.SelectedItem.Value
                    .RC_ID = ddDepartment.SelectedItem.Value
                    .Function_ID = ddFunction.SelectedItem.Value
                    .ExpectedOutputs = ""
                    .StartDate = "1/1/" + CType(Year(Date.Today.ToString("MM/dd/yyyy")), String)
                    .CompletionDate = "12/31/" + CType(Year(Date.Today.ToString("MM/dd/yyyy")), String)
                    '  MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, datetime.now)
                    .Objectives = ""
                    .Budget_Year = ddYear.SelectedItem.Text
                    .fundingsource_id = 1
                    .status = 1
                    .PS = 0
                    .MOOE = txtApproved.Text
                    .CO = txtApproved.Text
                    .OFE = 0
                    .TotalCost = txtApproved.Text
                    .AIP_SubReport_ID = 0
                    .PerformanceInd = ""
                    .TargetBeneficiaries = ""
                    .OtherOffices = ""
                    .isInfra = Session("isInfra")
                    .UserID = Session("@UserName")
                    .TableName = "BOS.m_Program"
                    .Trush_Fund_Description = txtTrustFundRemarks.Text
                End With

                Dim Program_ID As Long
                If Session("Update") = 0 Then
                    Program_ID = m_Program.save

                ElseIf Session("Update") = 1 Then
                    If txtApproved.Text < Session("SummaryTotal") Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Updating failed, the Total Balance exceeds the Approved Budget.")
                        Exit Sub

                    End If

                    m_Program.Program_ID = grdPPA_List.SelectedDataKey("Program_ID")
                    Program_ID = m_Program.update

                End If

                '==== SAVE m_Project
                Dim Cnt2 As Integer
                Cnt2 = objDerived.GetValue("SELECT COUNT(RC_ID) AS cnt FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Project AS m_Project WHERE Program_ID = '" & Program_ID & "' GROUP BY Program_ID", CommandType.Text)

                If Cnt2 = 0 Then
                    Cnt2 = 1
                Else
                    Cnt2 = Cnt + 1
                End If

                With m_Project
                    .isProject = True
                    .isActivity = True
                    .Project_Name = txtPPA_Desc.Text
                    .Project_Code = Program_Code + "-" + CType(Cnt2, String)
                    .Program_ID = Program_ID
                    .RC_ID = ddDepartment.SelectedItem.Value
                    .Function_ID = ddFunction.SelectedItem.Value
                    .ExpectedOutputs = ""
                    .OtherOffices = ""
                    .StartDate = "1/1/" + CType(Year(Date.Today.ToString("MM/dd/yyyy")), String)
                    .CompletionDate = "12/31/" + CType(Year(Date.Today.ToString("MM/dd/yyyy")), String)
                    '  MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, datetime.now)
                    .Objectives = ""
                    .status = 1
                    .PS = 0
                    .MOOE = txtApproved.Text
                    .CO = txtApproved.Text
                    .OFE = 0
                    .TotalCost = txtApproved.Text
                    .MajorProjID = 0
                    .isSC = False
                    .isSubmit = True
                    .isfinal = True
                    .UserID = Session("@UserName")
                    .TableName = "BOS.m_Project"
                    .Trush_Fund_Description = txtTrustFundRemarks.Text
                    .isInfraActivity = Session("isInfra")
                End With

                Dim Project_ID As Long
                If Session("Update") = 0 Then
                    Project_ID = m_Project.save

                ElseIf Session("Update") = 1 Then
                    m_Project.Project_ID = grdPPA_List.SelectedDataKey("Project_ID")
                    Project_ID = m_Project.update
                End If





                Dim strBudget_Year As String = "Budget Year = " + ddYear.SelectedItem.Text
                Dim strDepartment As String = "Department = " + ddDepartment.SelectedItem.Text
                Dim strFunction As String = "Function = " + ddFunction.SelectedItem.Text
                Dim strFund As String = "Fund = " + drpFund.SelectedItem.Text
                Dim strTrust_Fund_Description As String = "Trust Fund Description = " + txtTrustFundRemarks.Text
                Dim strPPA_Description As String = "PPA Description = " + txtPPA_Desc.Text
                Dim strApproved_Budget As String = "Approved Budget = " + txtApproved.Text

                Dim strDetails As String = strBudget_Year + ", " + strDepartment + ", " + strFunction + ", " + strFund + ", " + strTrust_Fund_Description + ", " + strPPA_Description + ", " + strApproved_Budget

                Dim strTask As String
                If btnSavePPA.Text = "SAVE" Then
                    strTask = "Added PPA"
                Else
                    strTask = "Edit PPA"
                End If







                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                txtPPA_Desc.Text = ""
                txtApproved.Text = "0.00"

                grdPPA_List.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_BudgetPPA] WHERE Budget_Year = '" & ddYear.SelectedItem.Text & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND F_ID = " & drpFund.SelectedItem.Value & " ORDER BY PPA_Desc", CommandType.Text)
                grdPPA_List.DataBind()
                btnSavePPA.Text = "SAVE"



                If btnSavePPA.Text = "SAVE" Then
                    'Dim excelManager As New ExcelManager()
                    'Dim data As New List(Of String()) From
                    '    {
                    '        New String() {Date.Today, Session("@UserID"), strTask, strDetails}
                    '    }

                    Dim filePath As String = Server.MapPath("~/Audit.xlsx")
                    Dim tempDirectory As String = Server.MapPath("~/TempFiles")
                    If Not Directory.Exists(tempDirectory) Then
                        Directory.CreateDirectory(tempDirectory)
                    End If

                    ' Use String.Format instead of interpolated string
                    Dim tempFileName As String = String.Format("Audit_temp_{0}.xlsx", Guid.NewGuid().ToString())
                    Dim tempFilePath As String = Path.Combine(tempDirectory, tempFileName)

                    Dim data As New List(Of String()) From {
                            New String() {Date.Today.ToShortDateString(), Session("@UserID"), strTask, strDetails}
                        }

                    Dim manager As New ExcelManager()

                    ' Use String.Format instead of interpolated string
                    If IsFileInUse(filePath) Then
                        ' Avoid overwriting by using a unique filename
                        filePath = Server.MapPath(String.Format("~/Audit_{0}.xlsx", DateTime.Now.ToString("yyyyMMddHHmmss")))
                    End If

                    Try
                        manager.InsertData(tempFilePath, data)
                        If File.Exists(tempFilePath) Then
                            File.Move(tempFilePath, filePath)
                        End If
                    Catch ex As IOException
                        'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error saving file: " & ex.Message)

                        AddTrace("Error saving file:")
                    End Try

                End If
            End If

        Catch ex As Exception
            Dim safeMessage As String = ex.Message.Replace("'", "\'").Replace(Environment.NewLine, " ")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ConsoleError", "console.error('" & safeMessage & "');", True)
        End Try





    End Sub



    Protected Sub btnCancelPPA_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtPPA_Desc.Text = ""
        txtApproved.Text = "0.00"
    End Sub

    Protected Sub grdPPA_List_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If lblappstatus.Text = "Executing" Then

            'Enabling the txtApproved
            'txtApproved.Enabled = False
        Else
            txtApproved.Enabled = True
        End If
        Session("Update") = 1
        Session("Program_ID") = grdPPA_List.SelectedDataKey("Program_ID")
        Session("Project_ID") = grdPPA_List.SelectedDataKey("Project_ID")


        txtPPA_Desc.Text = grdPPA_List.SelectedDataKey("PPA_Desc")
        txtApproved.Text = FormatNumber(grdPPA_List.SelectedDataKey("ApprovedFinal"), 2)

        ddAllotment.DataSource = objDerived.GetDataTable("SELECT AllotmentClass_ID,AllotmentClass FROM LnkdSrvrBOSS.GEOBOS.BOS.m_AllotmentClass WHERE AllotmentClass_ID IN (2,3)", CommandType.Text)
        ddAllotment.DataTextField = ("AllotmentClass")
        ddAllotment.DataValueField = ("AllotmentClass_ID")
        ddAllotment.DataBind()
        ddAllotment.Items.Insert(0, "Select")

        Dim sql As String = "EXEC [AMS].[sp_LedgerCardBudget]'" &
                    ddYear.SelectedItem.Text & "','" &
                    ddDepartment.SelectedItem.Value & "','" &
                    ddFunction.SelectedItem.Value & "','" &
                    grdPPA_List.SelectedDataKey("Program_ID") & "','" &
                    grdPPA_List.SelectedDataKey("Project_ID") & "','" &
                    drpFund.SelectedItem.Value & "','" & "0" & "'"

        ' Add trace
        AddTrace("Executing SQL: " & sql)


        Dim dt = objDerived.GetDataTable("EXEC [AMS].[sp_LedgerCardBudget]'" & ddYear.SelectedItem.Text & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & grdPPA_List.SelectedDataKey("Program_ID") & "','" & grdPPA_List.SelectedDataKey("Project_ID") & "','" & drpFund.SelectedItem.Value & "','" & "0" & "'", CommandType.Text)
        If dt.Rows.Count = 0 Then
            dt.Merge(createdatatable1(4))

            grdAccounts.DataSource = dt
            grdAccounts.DataBind()
            grdAccounts.SelectedIndex = -1
        ElseIf dt.Rows.Count < 5 Then
            dt.Merge(createdatatable1(4 - dt.Rows.Count))
            grdAccounts.DataSource = dt
            grdAccounts.DataBind()
        End If

        CType(grdAccounts.FooterRow.Cells(2).FindControl("lblTotalApprovedBudget"), Label).Text = FormatNumber(dt.Compute("sum(ApprovedFinal)", ""), 2)
        CType(grdAccounts.FooterRow.Cells(3).FindControl("lblTotalPurchaseRequest"), Label).Text = FormatNumber(dt.Compute("sum(PR_Amt)", ""), 2)
        'Dim Total = CType(grdAccounts.FooterRow.Cells(4).FindControl("lblTotalPPABalance"), Label).Text = FormatNumber(dt.Compute("sum(Balance)", ""), 2)

        Dim prSum As Object = dt.Compute("sum(PR_Amt)", "")
        Dim totalPR As Double = If(prSum Is DBNull.Value, 0, CDbl(prSum))
        Session("PRTotal") = totalPR
        CType(grdAccounts.FooterRow.Cells(3).FindControl("lblTotalPurchaseRequest"), Label).Text = FormatNumber(totalPR, 2)

        AddTrace("PRTotal:" & Session("PRTotal"))

        Dim balanceSum As Object = dt.Compute("sum(Balance)", "")
        Dim totalBalance As Double = If(balanceSum Is DBNull.Value, 0, CDbl(balanceSum))

        ' Set the formatted value to the label
        CType(grdAccounts.FooterRow.Cells(4).FindControl("lblTotalPPABalance"), Label).Text = FormatNumber(totalBalance, 2)

        ' Store the original numeric value in session
        Session("SummaryTotal") = totalBalance



        hndApprovedBudgetValue.Value = dt.Compute("sum(ApprovedFinal)", "")



        ddAllotment.Enabled = True
        txtAccountAmt.Enabled = True
        ddAllotment.Enabled = True
        btnSave.Enabled = True
        'txtApproved.enabled = True
        btnSavePPA.Text = "UPDATE"

    End Sub

    Protected Sub ddAllotment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("AllotmentType") = ddAllotment.SelectedItem.Value

        '==== DISPLAY ACCOUNT TO ENCODE NEW BUDGET
        dtAccounts = objDerived.GetDataTable("SELECT DISTINCT * FROM AMS.View_AccountList WHERE AllotmentClass_ID = '" & ddAllotment.SelectedItem.Value & "' ORDER BY GA_Title", CommandType.Text)
        ddAccounts.DataSource = dtAccounts
        ddAccounts.DataTextField = ("GA_Title2")
        ddAccounts.DataValueField = ("GA_Code2")
        ddAccounts.DataBind()
        ddAccounts.Items.Insert(0, "Select")

        ddAccounts.Enabled = True



    End Sub

    Protected Sub drpFund_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpFund.SelectedIndexChanged
        Try
            '=== DISPLAY ALL PPA UNDER SELECTED FUND

            grdPPA_List.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_BudgetPPA] WHERE Budget_Year = '" & ddYear.SelectedItem.Text & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND F_ID = " & drpFund.SelectedItem.Value & " ORDER BY PPA_Desc", CommandType.Text)
            grdPPA_List.DataBind()

            If drpFund.SelectedItem.Text = "Trust Fund" Or drpFund.SelectedItem.Text = "General Fund" Then
                txtTrustFundRemarks.Enabled = True
            Else
                txtTrustFundRemarks.Enabled = False
                txtTrustFundRemarks.Text = ""
            End If



        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ddAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Update") = 0
        Session("GA_ID") = dtAccounts.Rows(ddAccounts.SelectedIndex - 1)("GA_ID")
        Session("BGA_ID") = dtAccounts.Rows(ddAccounts.SelectedIndex - 1)("BGA_ID")

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Approvedbudget As Double = Val(txtApproved.Text.Replace(",", ""))

        Dim NewBudgetAmount As Double = Val(txtAccountAmt.Text.Replace(",", ""))
        Dim SaveApprovedBudget As Double = hndApprovedBudgetValue.Value

        Dim selectedSavedBudgetAmount As Double = Val(hndSelectedBudgetValue.Value)


        Dim TotalAvailableBudget As Double = Approvedbudget - (NewBudgetAmount + (SaveApprovedBudget - selectedSavedBudgetAmount))
        AddTrace("TotalAvailableBudget: " & TotalAvailableBudget)
        ''Val(txtAccountAmt.Text.Replace(",", "")) + hndApprovedBudgetValue.Value <= Val(txtApproved.Text.Replace(",", ""))

        If TotalAvailableBudget >= 0 Then

            Session("AppropriationSource_ID") = objDerived.GetValue("SELECT AppropriationSource_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_AppropriationSource AS m_AppropriationSource WHERE Budget_Year = '" & Session("CYear") & "'", CommandType.Text)
            Dim AppBud As Integer
            If txtApproved.Text <> "" Then
                AppBud = txtApproved.Text
            End If
            Dim Amnt As Integer = txtAccountAmt.Text

            AddTrace("txtAccountAmt: " & txtAccountAmt.Text)
            If txtAccountAmt.Text < Session("PRTotal") Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Updating failed, the Purchase Request(CREDIT) exceeds the entered amount.")
                Exit Sub

            End If


            If Amnt > AppBud Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The amount exceeds the value of Approved budget.")
                txtAccountAmt.Text = "0.00"
            Else

                If txtAccountAmt.Text = "" Or txtAccountAmt.Text = "0.00" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
                    Exit Sub
                End If



                '==== PAOO HEADER LBPF_3_Hdr
                With LBPF_3_Hdr
                    .RC_ID = ddDepartment.SelectedItem.Value
                    .Function_ID = ddFunction.SelectedItem.Value
                    .Program_ID = Session("Program_ID")
                    .Project_ID = Session("Project_ID")
                    .AppropriationSource_ID = Session("AppropriationSource_ID")
                    .AdjustmentType_ID = 0
                    .F_ID = grdPPA_List.SelectedDataKey("F_ID")
                    .Budget_Year = ddYear.SelectedItem.Text
                    .isApproved = True
                    .isPosted = True
                    .PreparedBy = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND isDeptHead = 'Yes'", CommandType.Text)
                    .ReviewedBy = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = 8 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                    .ApprovedBy = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                    .isFinal = True
                    .DatePrepared = Date.Today.ToString("MM/dd/yyyy")
                    .DateReviewed = Date.Today.ToString("MM/dd/yyyy")
                    .DateApproved = Date.Today.ToString("MM/dd/yyyy")
                    .UserID = Session("@UserName")
                    .TableName = "BOS.LBPF_3_Hdr"
                End With

                Dim LBPF_3_Hdr_ID As Long
                Dim LBPF_ID As Long = objDerived.GetValue("SELECT LBPF_3_Hdr_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBPF_3_Hdr WHERE Budget_Year = '" & Session("CYear") & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND Program_ID = '" & Session("Program_ID") & "' AND Project_ID = '" & Session("Project_ID") & "' AND F_ID = " & grdPPA_List.SelectedDataKey("F_ID") & "", CommandType.Text)
                If LBPF_ID = 0 Then
                    LBPF_3_Hdr_ID = LBPF_3_Hdr.save

                Else
                    LBPF_3_Hdr_ID = LBPF_ID
                    LBPF_3_Hdr.LBPF_3_Hdr_ID = LBPF_ID
                    LBPF_3_Hdr.update()
                End If


                '==== RELEASE HEADER LBEF_2_Hdr
                Dim yr As String = Session("CYear")

                With LBEF_2_Hdr
                    .ARO_No = yr + "-" + "00"
                    .Budget_Year = ddYear.SelectedItem.Text
                    .AppropriationSource_ID = Session("AppropriationSource_ID")
                    .AllotmentType_ID = 5
                    .Quarter = 0
                    .F_ID = grdPPA_List.SelectedDataKey("F_ID")
                    '.F_ID = 1
                    .RC_ID = ddDepartment.SelectedItem.Value
                    .Function_ID = ddFunction.SelectedItem.Value
                    .Program_ID = Session("Program_ID")
                    .Project_ID = Session("Project_ID")
                    .DateIssued = Date.Today.ToString("MM/dd/yyyy")
                    .Purpose = ""
                    .Notes = ""
                    .Signatory1_ID = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = 8 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                    .DateSigned = Date.Today.ToString("MM/dd/yyyy")
                    .Signatory2_ID = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                    .Signatory3_ID = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                    .Position3 = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                    .isApproved = True
                    .DateSigned = Date.Today.ToString("MM/dd/yyyy")
                    .isContinuing = False
                    .isAdjustment = False
                    .UserID = Session("@UserName")
                End With

                Dim LBEF_2_Hdr_ID As Long
                Dim LBEF_ID As Long = objDerived.GetValue("SELECT LBEF_2_Hdr_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Hdr WHERE Budget_Year = '" & Session("CYear") & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND Program_ID = '" & Session("Program_ID") & "' AND Project_ID = '" & Session("Project_ID") & "'", CommandType.Text)
                If LBEF_ID = 0 Then
                    LBEF_2_Hdr.TotalAmount = txtApproved.Text
                    LBEF_2_Hdr_ID = LBEF_2_Hdr.save

                Else
                    LBEF_2_Hdr_ID = LBEF_ID
                    Dim xTotalAmount As Decimal
                    If Session("BGA_ID") = 0 Then
                        xTotalAmount = objDerived.GetValue("SELECT SUM(Amount) FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Dtl WHERE LBEF_2_Hdr_ID = '" & LBEF_ID & "' AND GA_ID <> '" & Session("GA_ID") & "' GROUP BY  LBEF_2_Hdr_ID", CommandType.Text)
                    Else
                        xTotalAmount = objDerived.GetValue("SELECT SUM(Amount) FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Dtl WHERE LBEF_2_Hdr_ID = '" & LBEF_ID & "' AND GA_ID <> '" & Session("GA_ID") & "' AND BGA_ID <> '" & Session("BGA_ID") & "' GROUP BY  LBEF_2_Hdr_ID", CommandType.Text)
                    End If
                    LBEF_2_Hdr.TotalAmount = txtApproved.Text + xTotalAmount
                    LBEF_2_Hdr.LBEF_2_Hdr_ID = LBEF_ID
                    LBEF_2_Hdr.update()
                End If


                '=== SAVE PAOO DETAILS BOS.LBPF_3_Dtl
                With LBPF_3_Dtl
                    .LBPF_3_Hdr_ID = LBPF_3_Hdr_ID
                    .GA_ID = Session("GA_ID")
                    .BGA_ID = Session("BGA_ID")
                    .PastYear_Amount = 0
                    .CurrentYear_Amount = txtAccountAmt.Text
                    .ProposedAmount = 0
                    .ApprovedAmount = txtAccountAmt.Text
                    .ApprovedFinal = txtAccountAmt.Text
                    .AllotmentClass_ID = Session("AllotmentType")
                    .UserID = Session("@UserName")
                    .TableName = "BOS.LBPF_3_Dtl"
                End With

                Dim LBPF_3_Dtl_ID As Long = objDerived.GetValue("SELECT LBPF_3_Dtl_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBPF_3_Dtl WHERE LBPF_3_Hdr_ID = '" & LBPF_3_Hdr_ID & "' AND GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "'", CommandType.Text)
                If LBPF_3_Dtl_ID = 0 Then
                    LBPF_3_Dtl.save()
                Else
                    LBPF_3_Dtl.LBPF_3_Dtl_ID = LBPF_3_Dtl_ID
                    LBPF_3_Dtl.update()
                End If

                '=== SAVE RELEASE DETAILS BOS.LBEF_2_Dtl
                With LBEF_2_Dtl
                    .LBEF_2_Hdr_ID = LBEF_2_Hdr_ID
                    .GA_ID = Session("GA_ID")
                    .BGA_ID = Session("BGA_ID")
                    .AllotmentClass_ID = Session("AllotmentType")
                    .Amount = txtAccountAmt.Text
                    .UserID = Session("@UserName")
                End With

                Dim LBEF_2_Dtl_ID As Long = objDerived.GetValue("SELECT LBEF_2_Dtl_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Dtl WHERE LBEF_2_Hdr_ID = '" & LBEF_2_Hdr_ID & "' AND GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "'", CommandType.Text)
                If LBEF_2_Dtl_ID = 0 Then
                    LBEF_2_Dtl.save()
                Else
                    LBEF_2_Dtl.LBEF_2_Dtl_ID = LBEF_2_Dtl_ID
                    LBEF_2_Dtl.update()
                End If

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                txtPPA_Desc.Enabled = False
                txtApproved.Enabled = False



                Dim Allotment_Class As String = "Allotment Class = " + ddAllotment.SelectedItem.Text
                Dim Accounts As String = "Accounts = " + ddAccounts.SelectedItem.Text
                Dim Amount As String = "Amount = " + txtAccountAmt.Text
                Dim PPA_Description As String = "PPA Description = " + txtPPA_Desc.Text


                Dim strTask As String = "Added Budget Details"
                Dim strDetails As String = PPA_Description + ", " + Allotment_Class + ", " + Accounts + ", " + Amount


                'Dim excelManager As New ExcelManager()
                'Dim data As New List(Of String()) From
                '        {
                '            New String() {Date.Today, Session("@UserID"), strTask, strDetails}
                '        }

                'excelManager.InsertData(Server.MapPath("~/Audit.xlsx"), data)




                '=== DISPLAY ALL ACCOUNT UNDER SELECTED FUND

                GrdLedger.DataSource = createdatatable2(4)
                GrdLedger.DataBind()


                Dim dt = objDerived.GetDataTable("EXEC [AMS].[sp_LedgerCardBudget]'" & ddYear.SelectedItem.Text & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & grdPPA_List.SelectedDataKey("Program_ID") & "','" & grdPPA_List.SelectedDataKey("Project_ID") & "','" & drpFund.SelectedItem.Value & "','" & "0" & "'", CommandType.Text)
                If dt.Rows.Count < 5 Then
                    dt.Merge(createdatatable1(4 - dt.Rows.Count))
                End If
                grdAccounts.DataSource = dt
                grdAccounts.DataBind()

                CType(grdAccounts.FooterRow.Cells(2).FindControl("lblTotalApprovedBudget"), Label).Text = FormatNumber(dt.Compute("sum(ApprovedFinal)", ""), 2)
                CType(grdAccounts.FooterRow.Cells(3).FindControl("lblTotalPurchaseRequest"), Label).Text = FormatNumber(dt.Compute("sum(PR_Amt)", ""), 2)
                Dim balanceSum As Object = dt.Compute("sum(Balance)", "")
                Dim totalBalance As Double = If(balanceSum Is DBNull.Value, 0, CDbl(balanceSum))

                ' Set the formatted value to the label
                CType(grdAccounts.FooterRow.Cells(4).FindControl("lblTotalPPABalance"), Label).Text = FormatNumber(totalBalance, 2)

                ' Store the original numeric value in session
                Session("SummaryTotal") = totalBalance

                hndApprovedBudgetValue.Value = dt.Compute("sum(ApprovedFinal)", "")
                ddAllotment.SelectedItem.Text = "Select"
                ddAccounts.SelectedItem.Text = "Select"
                txtAccountAmt.Text = 0.00




                ' Log the actions for further debugging if needed
                Dim filePath As String = Server.MapPath("~/Audit_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx")
                Dim tempFilePath As String = Path.Combine(Server.MapPath("~/TempFiles"), "Audit_temp_" & Guid.NewGuid().ToString() & ".xlsx")

                ' Check if the file is in use before saving
                Try
                    If IsFileInUse(filePath) Then
                        ' Handle the case where the file is in use
                        AddTrace("The file is currently in use. Please try again later.")
                    Else
                        ' Proceed with saving the data
                        Dim data As New List(Of String()) From {
                        New String() {Date.Today.ToShortDateString(), Session("@UserID"), "Added Budget Details", "Some task details"}
                    }

                        ' Using the manager to insert data into the temporary file first
                        Dim manager As New ExcelManager()
                        manager.InsertData(tempFilePath, data)

                        ' Once successfully saved, move the temporary file to the final location
                        If File.Exists(tempFilePath) Then
                            File.Move(tempFilePath, filePath)
                        End If
                    End If
                Catch ex As Exception
                    ' Log error to the console for debugging
                    AddTrace("Error during file save: " & ex.Message)
                End Try




            End If
        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The amount exceeds the value of PPA Approved budget.")
        End If






    End Sub

    Protected Sub grdAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Update") = 1
        txtAccountAmt.Enabled = True
        Session("GA_ID") = grdAccounts.SelectedDataKey("GA_ID")
        Session("BGA_ID") = grdAccounts.SelectedDataKey("BGA_ID")
        ddAllotment.SelectedItem.Text = objDerived.GetValue("select AllotmentClass from LnkdSrvrBOSS.GEOBOS.BOS.m_AllotmentClass where AllotmentClass_ID = '" & grdAccounts.SelectedDataKey("AllotmentClass_ID") & "'", CommandType.Text)
        ddAllotment.Enabled = False
        dtAccounts = objDerived.GetDataTable("SELECT DISTINCT * FROM AMS.View_AccountList WHERE AllotmentClass_ID = '" & grdAccounts.SelectedDataKey("AllotmentClass_ID") & "' ORDER BY GA_Title", CommandType.Text)
        ddAccounts.DataSource = dtAccounts
        ddAccounts.DataTextField = ("GA_Title2")
        ddAccounts.DataValueField = ("GA_Code2")
        ddAccounts.DataBind()

        ddAccounts.SelectedValue = objDerived.GetValue("SELECT TOP(1) GA_Code2 FROM AMS.View_AccountList WHERE GA_ID = '" & grdAccounts.SelectedDataKey("GA_ID") & "' AND BGA_ID = '" & grdAccounts.SelectedDataKey("BGA_ID") & "'", CommandType.Text)
        txtAccountAmt.Text = FormatNumber(grdAccounts.SelectedDataKey("ApprovedFinal"), 2)
        hndSelectedBudgetValue.Value = grdAccounts.SelectedDataKey("ApprovedFinal")
        ddAccounts.Enabled = False
        ''HERE 
        Dim dt = objDerived.GetDataTable("exec [AMS].[sp_LedgerCardPerPPA] '" & ddYear.SelectedItem.Text & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & grdPPA_List.SelectedDataKey("Program_ID") & "','" & grdPPA_List.SelectedDataKey("Project_ID") & "','" & grdAccounts.SelectedDataKey("GA_ID") & "','" & grdAccounts.SelectedDataKey("BGA_ID") & "','" & grdAccounts.SelectedDataKey("GA_CODE") & "' ", CommandType.Text)
        If dt.Rows.Count = 0 Then
            dt.Merge(createdatatable2(4))
            GrdLedger.DataSource = dt
            GrdLedger.DataBind()
            GrdLedger.SelectedIndex = -1
        ElseIf dt.Rows.Count < 5 Then
            dt.Merge(createdatatable2(4 - dt.Rows.Count))
            GrdLedger.DataSource = dt
            GrdLedger.DataBind()
        End If







    End Sub
    Protected Sub grdPPA_List_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdPPA_List.PageIndexChanging
        Dim Page = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_BudgetPPA] WHERE Budget_Year = '" & ddYear.SelectedItem.Text & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND F_ID = " & drpFund.SelectedItem.Value & " ORDER BY PPA_Desc", CommandType.Text)

        grdPPA_List.PageIndex = e.NewPageIndex
        grdPPA_List.DataSource = Page
        grdPPA_List.DataBind()
        'CType(grdPPA_List.HeaderRow.Cells(3).FindControl("lblPrevious"), Label).Text = Session("CYPrev")
        'CType(grdPPA_List.HeaderRow.Cells(3).FindControl("lblCurrent"), Label).Text = Session("CYNow")
    End Sub
    Protected Sub txtApproved_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtApproved.Text = FormatNumber(txtApproved.Text, 2)
    End Sub



    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtAccountAmt.Text = "0.00"
    End Sub


    Protected Sub txtAccountAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtAccountAmt.Text = FormatNumber(txtAccountAmt.Text, 2)
    End Sub

    Protected Sub GrdLedger_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("Page") = "PPA"
        Session("Report") = "PR"
        Session("prhdr_id") = GrdLedger.SelectedDataKey("prhdr_id")



        If GrdLedger.SelectedDataKey("prhdr_id") <> "" Then
            Dim strDetails As String = "Preview PR Repor = " + GrdLedger.SelectedDataKey("prhdr_id")
            'Dim excelManager As New ExcelManager()
            'Dim data As New List(Of String()) From
            '                {
            '                    New String() {Date.Today, Session("@UserID"), "Preview PR Report", strDetails}
            '                }
            Dim filePath As String = Server.MapPath("~/Audit_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx")

            ' Prepare the data to be saved
            Dim data As New List(Of String()) From
                        {
                            New String() {Date.Today.ToShortDateString(), Session("@UserID"), "Preview PR Report", strDetails}
                        }

            ' Define the temporary file path
            Dim tempFilePath As String = Path.Combine(Server.MapPath("~/TempFiles"), "Audit_temp_" & Guid.NewGuid().ToString() & ".xlsx")

            Try
                ' Check if the file is in use before saving
                If IsFileInUse(filePath) Then
                    ' Handle the case where the file is in use
                    AddTrace("The file is currently in use. Please try again later.")
                Else
                    ' Proceed with saving the data to a temporary file
                    Dim manager As New ExcelManager()
                    manager.InsertData(tempFilePath, data)

                    ' Once successfully saved, move the temporary file to the final location
                    If File.Exists(tempFilePath) Then
                        File.Move(tempFilePath, filePath)
                    End If
                End If
            Catch ex As Exception
                ' Log error to the console
                AddTrace("Error during file save in GrdLedger_SelectedIndexChanged: " & ex.Message)
            End Try

        Else
            ' Handle the case where no prhdr_id is selected (if needed)
        End If

        'Me.Page.Response.Redirect("~/MainReports/Procurement_Reports.aspx")

        Dim url As String = "Procurement_Reports.aspx?"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

    End Sub
    Protected Sub CBIsInfra_CheckedChanged(sender As Object, e As EventArgs)
        Dim Infra As Boolean
        If CBIsInfra.Checked = True Then

            Session("isInfra") = True
        Else
            Session("isInfra") = False
        End If
    End Sub


    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)

    End Sub




End Class
