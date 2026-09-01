Imports System.Data
Imports System.Data.SqlClient

Partial Class Reports_and_Query_t_RIS_Conso
    Inherits System.Web.UI.Page

    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

#Region "Property"
    Private Property dtRISConso() As DataTable
        Get
            Return CType(Session("dtRISConso"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtRISConso") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadYear()
            LoadMonth()
            LoadDepartment()

            txtDate.Text = Date.Now.ToString("MM/dd/yyyy")
        End If
    End Sub

    Private Sub LoadYear()
        Try
            drpYear.Items.Clear()
            drpYear.Items.Insert(0, "Select")

            Dim dtYear As DataTable = objDerived.GetDataTable("SELECT DISTINCT year FROM AMS.APP ORDER BY year DESC", CommandType.Text)

            For Each row As DataRow In dtYear.Rows
                drpYear.Items.Add(row("year").ToString())
            Next
        Catch ex As Exception
            ' Fallback to current year if query fails
            drpYear.Items.Clear()
            drpYear.Items.Insert(0, "Select")
            For i As Integer = Date.Today.Year To Date.Today.Year - 10 Step -1
                drpYear.Items.Add(i.ToString())
            Next
        End Try
    End Sub
    Private Sub LoadMonth()
        drpMonthFrom.Items.Clear()
        drpMonthTo.Items.Clear()
        drpMonthFrom.Items.Insert(0, "Select")
        drpMonthTo.Items.Insert(0, "Select")

        For i As Integer = 1 To 12
            drpMonthFrom.Items.Add(New ListItem(MonthName(i), i.ToString()))
            drpMonthTo.Items.Add(New ListItem(MonthName(i), i.ToString()))
        Next
    End Sub

    Private Sub LoadDepartment()
        Try
            ddRC.Items.Clear()
            ddRC.Items.Insert(0, "Select")

            Dim dtDepartment As DataTable = objDerived.GetDataTable("SELECT RC_ID, RC_Name FROM DBO.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)

            ddRC.DataSource = dtDepartment
            ddRC.DataTextField = "RC_Name"
            ddRC.DataValueField = "RC_ID"
            ddRC.DataBind()
            ddRC.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
            ddRC.Items.Clear()
            ddRC.Items.Insert(0, New ListItem("-- Error Loading Departments --", "0"))
        End Try
    End Sub



    Protected Sub ddRC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddRC.SelectedIndexChanged
        If ddRC.SelectedIndex > 0 Then
            Session("RIS_RC_ID") = ddRC.SelectedValue
        Else
            Session("RIS_RC_ID") = Nothing
        End If
    End Sub



    Protected Sub drpYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpYear.SelectedIndexChanged
        If drpYear.SelectedIndex > 0 Then
            Session("RIS_Year") = drpYear.SelectedValue
        Else
            Session("RIS_Year") = Nothing
        End If
    End Sub

    Protected Sub drpMonthFrom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpMonthFrom.SelectedIndexChanged
        If drpMonthFrom.SelectedIndex > 0 Then
            Session("RIS_MonthFrom") = drpMonthFrom.SelectedValue
        Else
            Session("RIS_MonthFrom") = Nothing
        End If
    End Sub

    Protected Sub drpMonthTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpMonthTo.SelectedIndexChanged
        If drpMonthTo.SelectedIndex > 0 Then
            Session("RIS_MonthTo") = drpMonthTo.SelectedValue
        Else
            Session("RIS_MonthTo") = Nothing
        End If
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ' Validate Month From
        If ddRC.SelectedIndex = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a Department.")
            Exit Sub
        End If
        ' Validate Month From
        If drpYear.SelectedIndex = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a Year.")
            Exit Sub

        End If
        ' Validate Month From
        If drpMonthFrom.SelectedIndex = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a Month From.")
            Exit Sub
        End If

        ' Validate Month To
        If drpMonthTo.SelectedIndex = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a Month To.")
            Exit Sub
        End If

        ' Store Department value in Session
        If ddRC.SelectedIndex > 0 Then
            Session("RIS_RC_ID") = ddRC.SelectedValue
        Else
            Session("RIS_RC_ID") = Nothing
        End If

        ' Store Year value in Session
        If drpYear.SelectedIndex > 0 Then
            Session("RIS_Year") = drpYear.SelectedValue
        Else
            Session("RIS_Year") = Nothing
        End If

        ' Store Month From value in Session
        If drpMonthFrom.SelectedIndex > 0 Then
            Session("RIS_MonthFrom") = drpMonthFrom.SelectedValue
        Else
            Session("RIS_MonthFrom") = Nothing
        End If

        ' Store Month To value in Session
        If drpMonthTo.SelectedIndex > 0 Then
            Session("RIS_MonthTo") = drpMonthTo.SelectedValue
        Else
            Session("RIS_MonthTo") = Nothing
        End If


        SaveRisConsoData()


        ' Open report in new tab
        Dim script As String = "window.open('t_rpt_RIS_Conso.aspx', '_blank');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OpenReport", script, True)
    End Sub
    Private Sub LoadRISConso()
        'Future database loading function
    End Sub
    Private Sub SaveRisConsoData()

        Try

            Dim formNumber As String = txtFormNumber.Text.Trim()
            Dim office As String = txtOffice.Text.Trim()
            Dim purpose As String = txtPurpose.Text.Trim()
            Dim printedName As String = txtPrintedName.Text.Trim()
            Dim designation As String = txtDesignation.Text.Trim()
            Dim dateValue As String = txtDate.Text.Trim()


            Dim checkQuery As String =
                "SELECT COUNT(*) AS [RowCount] " &
                "FROM AMS.RIS_Conso_Temp"

            Dim dtCheck As DataTable =
            objDerived.GetDataTable(checkQuery, CommandType.Text)



            Dim rowCount As Integer = 0


            If dtCheck IsNot Nothing AndAlso dtCheck.Rows.Count > 0 Then

                If Not IsDBNull(dtCheck.Rows(0)("RowCount")) Then

                    rowCount =
                    Convert.ToInt32(dtCheck.Rows(0)("RowCount"))

                End If

            End If



            If rowCount = 0 Then


                Dim insertQuery As String =
                "INSERT INTO AMS.RIS_Conso_Temp " &
                "(FormNumber, Office, Purpose, PrintedName, Designation, Date) " &
                "VALUES " &
                "('" & formNumber.Replace("'", "''") & "', " &
                "'" & office.Replace("'", "''") & "', " &
                "'" & purpose.Replace("'", "''") & "', " &
                "'" & printedName.Replace("'", "''") & "', " &
                "'" & designation.Replace("'", "''") & "', " &
                "'" & dateValue.Replace("'", "''") & "')"



                objDerived.Execute(
                insertQuery,
                CommandType.Text
            )


                MsgeBox.CreateMessageAlertInUpdatePanel(
                Me.UpdatePanel1,
                "Data saved successfully."
            )


            Else


                Dim updateQuery As String =
                "UPDATE TOP (1) AMS.RIS_Conso_Temp SET " &
                "FormNumber = '" & formNumber.Replace("'", "''") & "', " &
                "Office = '" & office.Replace("'", "''") & "', " &
                "Purpose = '" & purpose.Replace("'", "''") & "', " &
                "PrintedName = '" & printedName.Replace("'", "''") & "', " &
                "Designation = '" & designation.Replace("'", "''") & "', " &
                "Date = '" & dateValue.Replace("'", "''") & "'"



                objDerived.Execute(
                updateQuery,
                CommandType.Text
            )


                MsgeBox.CreateMessageAlertInUpdatePanel(
                Me.UpdatePanel1,
                "Data updated successfully."
            )


            End If


        Catch ex As Exception


            MsgeBox.CreateMessageAlertInUpdatePanel(
            Me.UpdatePanel1,
            "Error saving data: " & ex.Message
        )


        End Try

    End Sub
End Class