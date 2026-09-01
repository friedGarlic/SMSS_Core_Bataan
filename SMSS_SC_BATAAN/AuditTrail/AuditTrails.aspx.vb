Imports System.Data


Partial Class AuditTrail_AuditTrails
    Inherits System.Web.UI.Page
    Dim audit As New AuditTrail
    Dim obj As New BaseClasses.Items
    Public msg As New MsgeBox
    Dim objDerived As New DerivedDal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Me.dgLogTables.DataSource = audit.GetRecords("SELECT dbo.tbl_AuditTrail.PerformedBy, dbo.aspnet_Users.SystemUserID , dbo.tbl_AuditTrail.TableName, dbo.tbl_AuditTrail.RowId, dbo.tbl_AuditTrail.Operation,  dbo.tbl_AuditTrail.OccurredAt, dbo.tbl_AuditTrail.TimeCaptured, dbo.tbl_AuditTrail.FieldName, dbo.tbl_AuditTrail.OldValue, dbo.tbl_AuditTrail.NewValue, dbo.aspnet_Users.ApplicationId, dbo.tbl_AuditTrail.AuditId  FROM         dbo.aspnet_Users INNER JOIN dbo.tbl_AuditTrail ON dbo.aspnet_Users.SystemUserID = dbo.tbl_AuditTrail.PerformedBy", Data.CommandType.Text)
            'Me.dgLogTables.DataBind()

            Me.drpUsers.DataSource = audit.GetDataTable("SELECT SystemUserID, UserName FROM dbo.aspnet_Users", Data.CommandType.Text)
            Me.drpUsers.DataValueField = "SystemUserID"
            Me.drpUsers.DataTextField = "UserName"
            Me.drpUsers.DataBind()

            chkAll.Enabled = False
        End If
    End Sub

    Protected Sub dgLogTables_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgLogTables.PageIndexChanging
        Me.dgLogTables.PageIndex = e.NewPageIndex
        Me.dgLogTables.SelectedIndex = 0

        If txtDateFrom.Text <> "" And txtDateTo.Text <> "" And drpUsers.SelectedValue <> 0 Then
            Me.dgLogTables.DataSource = audit.GetRecords("SELECT * FROM smsSysmanager.dbo.tbl_AuditTrail WHERE PerformedBy = '" & drpUsers.SelectedItem.Text & "' order by OccurredAt Desc", CommandType.Text)
            Me.dgLogTables.DataBind()

        Else
            Me.dgLogTables.DataSource = audit.GetRecords("SELECT dbo.tbl_AuditTrail.PerformedBy, dbo.aspnet_Users.SystemUserID , dbo.tbl_AuditTrail.TableName, dbo.tbl_AuditTrail.RowId, dbo.tbl_AuditTrail.Operation,  dbo.tbl_AuditTrail.OccurredAt, dbo.tbl_AuditTrail.TimeCaptured, dbo.tbl_AuditTrail.FieldName, dbo.tbl_AuditTrail.OldValue, dbo.tbl_AuditTrail.NewValue, dbo.aspnet_Users.ApplicationId, dbo.tbl_AuditTrail.AuditId  FROM         dbo.aspnet_Users INNER JOIN dbo.tbl_AuditTrail ON dbo.aspnet_Users.SystemUserID = dbo.tbl_AuditTrail.PerformedBy", Data.CommandType.Text)
            Me.dgLogTables.DataBind()
        End If

     
    End Sub

    Protected Sub dgLogTables_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgLogTables.SelectedIndexChanged
        Dim tr As String = Me.dgLogTables.SelectedDataKey.Item(1).ToString + " " + "-" + " " + Me.dgLogTables.SelectedDataKey.Item(2).ToString

        If Me.dgLogTables.Rows.Count <> 0 Then
            Me.txtFieldName.Text = Me.dgLogTables.SelectedDataKey.Item(7).ToString
            Me.txtOperation.Text = Me.dgLogTables.SelectedDataKey.Item(3).ToString
            Me.txtDateTime.Text = Me.dgLogTables.SelectedDataKey.Item(4).ToString
            Me.txtDateTime.Text = Me.dgLogTables.SelectedDataKey.Item(4).ToString

            Me.txtOldValue.Text = Me.dgLogTables.SelectedDataKey.Item(8).ToString
            Me.txtNewValue.Text = Me.dgLogTables.SelectedDataKey.Item(9).ToString
            Me.txtTable.Text = tr

        End If

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
       If txtDateFrom.Text = "" Or txtDateTo.Text = "" Or drpUsers.SelectedValue = 0 Then
            msg.UserMsgBox("Fill up all the required fields to search.!", Me, False)
        Else
            Dim dtAudit As New DataTable
            dtAudit = objDerived.GetDataTable("SELECT * FROM smsSysmanager.dbo.tbl_AuditTrail WHERE PerformedBy = '" & drpUsers.SelectedItem.Text & "'order by OccurredAt desc", CommandType.Text)

            If dtAudit.Rows.Count = 0 Then
                dgLogTables.DataSource = Nothing
                dgLogTables.DataBind()
                msg.UserMsgBox("No records Found!", Me, False)
            Else
                dgLogTables.DataSource = dtAudit 'audit.GetRecords("SELECT dbo.tbl_AuditTrail.PerformedBy, dbo.aspnet_Users.SystemUserID, dbo.tbl_AuditTrail.TableName, dbo.tbl_AuditTrail.RowId, dbo.tbl_AuditTrail.Operation,  dbo.tbl_AuditTrail.OccurredAt, dbo.tbl_AuditTrail.TimeCaptured, dbo.tbl_AuditTrail.FieldName, dbo.tbl_AuditTrail.OldValue, dbo.tbl_AuditTrail.NewValue,  dbo.aspnet_Users.ApplicationId, dbo.tbl_AuditTrail.AuditId FROM dbo.aspnet_Users INNER JOIN dbo.tbl_AuditTrail ON dbo.aspnet_Users.SystemUserID = dbo.tbl_AuditTrail.PerformedBy where  dbo.tbl_AuditTrail.PerformedBy = '" & drpUsers.SelectedValue & "' and   dbo.tbl_AuditTrail.OccurredAt between '" & txtDateFrom.Text & "' and '" & txtDateTo.Text & "'", Data.CommandType.Text)
                dgLogTables.DataBind()
                chkAll.Enabled = True
                chkAll.Checked = False
            End If
        End If

    End Sub

    Protected Sub chkAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Me.dgLogTables.DataSource = audit.GetRecords("SELECT      dbo.tbl_AuditTrail.PerformedBy, dbo.aspnet_Users.SystemUserID , dbo.tbl_AuditTrail.TableName, dbo.tbl_AuditTrail.RowId, dbo.tbl_AuditTrail.Operation,  dbo.tbl_AuditTrail.OccurredAt, dbo.tbl_AuditTrail.TimeCaptured, dbo.tbl_AuditTrail.FieldName, dbo.tbl_AuditTrail.OldValue, dbo.tbl_AuditTrail.NewValue, dbo.aspnet_Users.ApplicationId, dbo.tbl_AuditTrail.AuditId  FROM         dbo.aspnet_Users INNER JOIN dbo.tbl_AuditTrail ON dbo.aspnet_Users.SystemUserID = dbo.tbl_AuditTrail.PerformedBy", Data.CommandType.Text)
        Me.dgLogTables.DataBind()

        txtDateFrom.Text = ""
        txtDateTo.Text = ""
        drpUsers.SelectedValue = 0
    End Sub
End Class
