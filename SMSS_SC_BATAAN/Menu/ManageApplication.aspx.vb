Imports System.Data.SqlClient
Imports System.Data
Partial Class Menu_ManageApplication
    Inherits System.Web.UI.Page
    Private Sub LoadApplications()
        Dim dt As New DataTable
        Dim objBase As New BaseGeneral
        objBase.conStr = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim selectSql As String = "SELECT * FROM aspnet_Applications"
        dt = objBase.GetDataTable(selectSql, CommandType.Text)

        Me.grdApplications.DataSource = dt
        Me.grdApplications.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadApplications()
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim objBase As New BaseGeneral
        objBase.conStr = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        objBase.cmd.Parameters.AddWithValue("@ApplicationName", Me.txtApplication.Text)
        objBase.cmd.Parameters.AddWithValue("@Description", Me.txtDescription.Text)
        objBase.cmd.Parameters.Add("@ApplicationId", SqlDbType.UniqueIdentifier).Direction = ParameterDirection.Output
        objBase.Execute("", "spApplication_SaveApplication", CommandType.StoredProcedure)
        LoadApplications()
    End Sub
End Class