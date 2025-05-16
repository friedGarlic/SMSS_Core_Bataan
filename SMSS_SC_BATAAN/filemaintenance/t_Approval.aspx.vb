Imports System.Web
Imports System.Net.Http
Imports System.Web.Configuration
Imports Newtonsoft.Json
Imports System.Security.Cryptography

Imports System.Data


Partial Class filemaintenance_t_Approval
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        If txtApproveName.text = "" Or txtApprovePwd.text = "" Or txtApproveConfirmPwd.text = "" Or txtApprovePosition.text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "All Fields are Required")
        Else
            If txtApprovePwd.text <> txtApproveConfirmPwd.text Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Password Do Not Match")

            Else
                objDerived.Execute("Insert into ams.tbl_approval(full_name,npassword,nposition) values('" & txtApproveName.text & "','" & DecryptEncrypt(txtApprovePwd.text) & "','" & txtApprovePosition.text & "')", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Approving Officer Successfully Added")

            End If

        End If

        '        
    End Sub

    Public Sub loadapprovalofficers()
        Dim dt As New DataTable

        dt = objDerived.GetDataTable("SELECT [full_name],[nposition] FROM [SMSS_Premium].[AMS].[tbl_approval]", CommandType.Text)

        GridView1.datasource = dt
        GridView1.databind()

    End Sub

    Private Sub filemaintenance_t_Approval_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadapprovalofficers()

        End If

    End Sub

    Private Function DecryptEncrypt(ByVal TheText As String) As String
        Dim tempChar As String = Nothing
        Dim i As Integer = 0
        For i = 1 To TheText.Length
            If Convert.ToInt32(TheText.Chars(i - 1)) < 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) + 100)
            ElseIf Convert.ToInt32(TheText.Chars(i - 1)) > 128 Then
                tempChar = System.Convert.ToString(Convert.ToInt32(TheText.Chars(i - 1)) - 100)
            End If
            TheText = TheText.Remove(i - 1, 1).Insert(i - 1, (CChar(ChrW(tempChar))).ToString())
        Next i
        Return TheText

    End Function
End Class
