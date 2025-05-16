Imports System.Data

Partial Class filemaintenance_ReservedPercentage
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule
    Dim AuditTrail As New Audit_Trail
    Private Property dtReserved() As DataTable
        Get
            Return CType(Session("dtReserved"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtReserved") = value
        End Set
    End Property

    Private Property dtExAccounts() As DataTable
        Get
            Return CType(Session("dtExAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtExAccounts") = value
        End Set
    End Property


    Private Sub filemaintenance_ReservedPercentage_Load(sender As Object, e As EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then
            drpYear.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.APP WHERE STATUS <> 3 ORDER BY year DESC", CommandType.Text)
            drpYear.DataTextField = "year"
            drpYear.DataValueField = "app_id"
            drpYear.DataBind()
            drpYear.Items.Insert(0, "Select")

            drpYear.Attributes.Add("onChange", "StartProgressBar();")


            Session("AllotmentClass") = 2
            grdReserved.DataSource = Nothing
            grdReserved.DataBind()

            grdExcemptedAccounts.DataSource = Nothing
            grdExcemptedAccounts.DataBind()

            ' DEFAULT VIEW
            btnTab1.CssClass = "TabButton_Active"
            btnTab2.CssClass = "TabButton_InActive"

            btnTabEx1.CssClass = "TabButton_Active"
            btnTabEx2.CssClass = "TabButton_InActive"



            drpAllotment.DataSource = objDerived.GetDataTable("SELECT AllotmentClass_ID,AllotmentClass FROM LnkdSrvrBOSS.GEOBOS.BOS.m_AllotmentClass WHERE AllotmentClass_ID IN (2,3)", CommandType.Text)
            drpAllotment.DataTextField = ("AllotmentClass")
            drpAllotment.DataValueField = ("AllotmentClass_ID")
            drpAllotment.DataBind()
            drpAllotment.Items.Insert(0, "Select")
        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
        txtSearchExempt.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchExempt.ClientID & "')")

    End Sub

    Private Sub drpYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpYear.SelectedIndexChanged

        Session("Year") = drpYear.SelectedItem.Text

        If drpYear.SelectedItem.Text = "Select" Then
            grdReserved.DataSource = Nothing
            grdReserved.DataBind()

            grdExcemptedAccounts.DataSource = Nothing
            grdExcemptedAccounts.DataBind()

        Else
            'FOR ACCOUNTS WITH RESERVED PERCENTAGE
            If btnTab1.CssClass = "TabButton_Active" Then
                Session("AllotmentClass") = 2
                LoadReservedPercentage_Accounts()
            Else
                Session("AllotmentClass") = 3
                LoadReservedPercentage_Accounts()
            End If

            'FOR ACCOUNTS EXEMPTED FOR RESERVED PERCENTAGE
            If btnTabEx1.CssClass = "TabButton_Active" Then
                Session("AllotmentClass") = 2
                LoadExemptedAccounts()
            Else
                Session("AllotmentClass") = 3
                LoadExemptedAccounts()
            End If

        End If

        btnSave.Enabled = True

    End Sub

    Private Sub btnTab1_Click(sender As Object, e As EventArgs) Handles btnTab1.Click
        btnTab1.CssClass = "TabButton_Active"
        btnTab2.CssClass = "TabButton_InActive"

        Session("AllotmentClass") = 2
        LoadReservedPercentage_Accounts()

    End Sub

    Private Sub btnTab2_Click(sender As Object, e As EventArgs) Handles btnTab2.Click
        btnTab1.CssClass = "TabButton_InActive"
        btnTab2.CssClass = "TabButton_Active"

        Session("AllotmentClass") = 3
        LoadReservedPercentage_Accounts()

    End Sub

    Private Sub btnTabEx1_Click(sender As Object, e As EventArgs) Handles btnTabEx1.Click
        btnTabEx1.CssClass = "TabButton_Active"
        btnTabEx2.CssClass = "TabButton_InActive"

        Session("AllotmentClass") = 2
        LoadExemptedAccounts()
    End Sub

    Private Sub btnTabEx2_Click(sender As Object, e As EventArgs) Handles btnTabEx2.Click
        btnTabEx1.CssClass = "TabButton_InActive"
        btnTabEx2.CssClass = "TabButton_Active"

        Session("AllotmentClass") = 3
        LoadExemptedAccounts()
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim myview As DataView
        myview = dtReserved.DefaultView
        myview.RowFilter = "Accnt_Desc like '%" & txtSearch.Text & "%'"
        grdReserved.DataSource = myview
        grdReserved.DataBind()

    End Sub

    Private Sub btnSearchExempt_Click(sender As Object, e As EventArgs) Handles btnSearchExempt.Click

        Dim myview As DataView
        myview = dtExAccounts.DefaultView
        myview.RowFilter = "Accnt_Desc like '%" & txtSearchExempt.Text & "%'"
        grdExcemptedAccounts.DataSource = myview
        grdExcemptedAccounts.DataBind()

    End Sub


    Protected Sub LoadReservedPercentage_Accounts()
        dtReserved = objDerived.GetDataTable("SELECT DISTINCT A.GA_Code2 + ' ' + A.GA_Title AS Accnt_Desc, A.GA_Code2, A.GA_Title, B.ReservedPercentage, B.CYear, A.GA_ID, A.BGA_ID, CONVERT(BIT,0) AS isChecked " &
                                               " FROM AMS.View_AccountList AS A INNER JOIN AMS.ReservedPercentage AS B ON A.GA_ID = B.GA_ID AND A.BGA_ID = B.BGA_ID  " &
                                               " WHERE A.AllotmentClass_ID = '" & Session("AllotmentClass") & "' AND B.withReserved = 1 AND B.CYear = " & Session("Year") & " ORDER BY A.GA_Title", CommandType.Text)
        grdReserved.DataSource = dtReserved
        grdReserved.DataBind()

    End Sub

    Protected Sub LoadExemptedAccounts()
        dtExAccounts = objDerived.GetDataTable("SELECT A.GA_Code2 + ' ' + A.GA_Title AS Accnt_Desc, A.GA_Code2, A.GA_Title, B.ReservedPercentage, B.CYear, A.GA_ID, A.BGA_ID, CONVERT(BIT,0) AS isChecked " &
                                               " FROM AMS.View_AccountList AS A INNER JOIN AMS.ReservedPercentage AS B ON A.GA_ID = B.GA_ID AND A.BGA_ID = B.BGA_ID  " &
                                               " WHERE A.AllotmentClass_ID = '" & Session("AllotmentClass") & "' AND B.withReserved = 0 AND B.CYear = " & Session("Year") & " ORDER BY A.GA_Title", CommandType.Text)
        grdExcemptedAccounts.DataSource = dtExAccounts
        grdExcemptedAccounts.DataBind()
    End Sub


    Private Sub grdReserved_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdReserved.PageIndexChanging
        grdReserved.DataSource = dtReserved
        grdReserved.PageIndex = e.NewPageIndex
        grdReserved.DataBind()
    End Sub

    Private Sub grdExcemptedAccounts_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdExcemptedAccounts.PageIndexChanging
        grdExcemptedAccounts.DataSource = dtExAccounts
        grdExcemptedAccounts.PageIndex = e.NewPageIndex
        grdExcemptedAccounts.DataBind()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If drpYear.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select budget year.")

            ElseIf txtReservedPercentage.Text = "0.00" Or txtReservedPercentage.Text = "" Or txtReservedPercentage.Text = "0" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Input reserved percentage.")

            Else
                Dim withReserved As Integer = objDerived.GetValue("SELECT DISTINCT CYear FROM AMS.ReservedPercentage WHERE CYear = '" & Session("Year") & "'", CommandType.Text)
                If withReserved = 0 Then
                    objDerived.Execute("EXEC [AMS].[sp_Save_ReservedPercetange] '" & Session("Year") & "','" & txtReservedPercentage.Text & "','" & drpAllotment.SelectedValue & "'", CommandType.Text)

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                    txtReservedPercentage.Text = 0.00
                    btnSave.Enabled = False

                    'Session("AllotmentClass") = 2
                    LoadReservedPercentage_Accounts()
                    LoadExemptedAccounts()

                Else

                    Dim withPPMP As Integer = objDerived.GetValue("SELECT DISTINCT CYear FROM AMS.PPMP_Monthly_Hdr WHERE CYear = '" & Session("Year") & "'", CommandType.Text)
                    If withPPMP = 0 Then

                        objDerived.Execute("UPDATE AMS.ReservedPercentage SET ReservedPercentage = '" & txtReservedPercentage.Text & "' WHERE CYear = '" & Session("Year") & "'", CommandType.Text)

                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, Session("Year") & " Reserved Percentage Has Been Successfully Updated.")

                        btnSave.Enabled = False

                        LoadReservedPercentage_Accounts()
                        LoadExemptedAccounts()

                    Else
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The Year " & Session("Year") & " Has Already PPMP. You Can Update Reserved Percentage Per Account.")

                    End If

                End If

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub


    Private Sub grdReserved_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdReserved.SelectedIndexChanged
        If Session("Event") = "Edit" Then

            txtEditReserved.Focus()
            txtEditReserved.Text = grdReserved.SelectedDataKey("ReservedPercentage")
            ModalPopupExtender_PnleDIT.Show()

        ElseIf Session("Event") = "Exempt" Then

            Try

                Dim withPPMP As Integer = objDerived.GetValue("SELECT DISTINCT CYear FROM AMS.PPMP_Monthly_Hdr WHERE CYear = '" & Session("Year") & "' AND GA_ID = " & grdReserved.SelectedDataKey("GA_ID") & "", CommandType.Text)
                If withPPMP = 0 Then

                    objDerived.Execute("UPDATE AMS.ReservedPercentage SET withReserved = 0, ReservedPercentage = 0  WHERE GA_ID = " & grdReserved.SelectedDataKey("GA_ID") & " AND CYear = '" & Session("Year") & "'", CommandType.Text)

                    With AuditTrail
                        .TableName = "AMS.ReservedPercentage"
                        .RowId = grdReserved.SelectedDataKey("GA_ID")
                        .Operation = "UPDATE"
                        .OccurredAt = DateTime.Now
                        .PerformedBy = Session("@UserName")
                        .FieldName = "withReserved"
                        .OldValue = "True"
                        .NewValue = "False"
                        '.ModuleName = "File Maintenance"
                        '.ComputerName = System.Net.Dns.GetHostName
                        .save()
                    End With

                    LoadReservedPercentage_Accounts()
                    LoadExemptedAccounts()

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Account Has Been Successfully Exempted.")

                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected Account Has Already a PPMP.")

                End If


            Catch ex As Exception
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
            End Try

        End If
    End Sub

    Private Sub grdExcemptedAccounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdExcemptedAccounts.SelectedIndexChanged
        Try
            If Session("Event") = "AddReserved" Then
                objDerived.Execute("UPDATE AMS.ReservedPercentage SET withReserved = 1 WHERE GA_ID = " & grdExcemptedAccounts.SelectedDataKey("GA_ID") & " AND CYear = '" & Session("Year") & "'", CommandType.Text)

                With AuditTrail
                    .TableName = "AMS.ReservedPercentage"
                    .RowId = grdReserved.SelectedDataKey("GA_ID")
                    .Operation = "UPDATE"
                    .OccurredAt = DateTime.Now
                    .PerformedBy = Session("@UserName")
                    .FieldName = "withReserved"
                    .OldValue = "False"
                    .NewValue = "True"
                    ' .ModuleName = "File Maintenance"
                    '.ComputerName = System.Net.Dns.GetHostName
                    .save()
                End With


                LoadReservedPercentage_Accounts()
                LoadExemptedAccounts()

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Account Has Been Successfully Added to Reserved Percentage List.")

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub

    Protected Sub lnkEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Event") = "Edit"
    End Sub

    Protected Sub lnkExempt_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Event") = "Exempt"
    End Sub

    Protected Sub lnkAddReserved_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Event") = "AddReserved"
    End Sub

    Private Sub btnUpdate_Reserved_Click(sender As Object, e As EventArgs) Handles btnUpdate_Reserved.Click
        Try

            Dim withPPMP As Integer = objDerived.GetValue("SELECT DISTINCT CYear FROM AMS.PPMP_Monthly_Hdr WHERE CYear = '" & Session("Year") & "' AND GA_ID = " & grdReserved.SelectedDataKey("GA_ID") & "", CommandType.Text)
            If withPPMP = 0 Then

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT * FROM AMS.ReservedPercentage WHERE GA_ID = " & grdReserved.SelectedDataKey("GA_ID") & " AND CYear = '" & Session("Year") & "'", CommandType.Text)

                objDerived.Execute("UPDATE AMS.ReservedPercentage SET ReservedPercentage = '" & txtEditReserved.Text & "' WHERE GA_ID = " & grdReserved.SelectedDataKey("GA_ID") & " AND CYear = '" & Session("Year") & "'", CommandType.Text)

                With AuditTrail
                    .TableName = "AMS.ReservedPercentage"
                    .RowId = grdReserved.SelectedDataKey("GA_ID")
                    .Operation = "UPDATE"
                    .OccurredAt = DateTime.Now
                    .PerformedBy = Session("@UserName")
                    .FieldName = "ReservedPercentage"
                    .OldValue = dt.Rows(0)("ReservedPercentage")
                    .NewValue = txtEditReserved.Text
                    '.ModuleName = "File Maintenance"
                    '.ComputerName = System.Net.Dns.GetHostName
                    .save()
                End With


                LoadReservedPercentage_Accounts()
                LoadExemptedAccounts()

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Reserved Percentage Has Been Successufully Updated.")

            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected Account Has Already a PPMP.")

            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

End Class
