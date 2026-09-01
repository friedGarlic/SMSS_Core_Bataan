Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.IO
Imports System.Net.Mail
Imports System.Web.Mail
Public Class FileClass
    Public Sub New()
    End Sub

    Public Shared Function ReadFile(ByVal FileName As String) As String
        'Try
        '    'INSTANT VB NOTE: The variable FILENAME was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
        '    Dim FILENAME_Renamed As String = System.Web.HttpContext.Current.Server.MapPath(FileName)
        '    Dim objStreamReader As StreamReader = File.OpenText(FILENAME_Renamed)
        '    Dim contents As String = objStreamReader.ReadToEnd()
        '    objStreamReader.Close()
        '    Return contents
        'Catch ex As Exception

        'End Try
        Return ""
    End Function


    Public Shared Function SendMail(ByVal From As String, ByVal [To] As String, ByVal CC As String, ByVal AttachmentFilePath As String, ByVal Subject As String, ByVal Body As String, ByRef intResult As Integer, ByRef MailResult As String) As String

        Try
            Dim mailClient As New SmtpClient("mail.geosolutions.com.ph", 25)
            Dim uid As String = ConfigurationManager.AppSettings("uid")
            Dim pwd As String = ConfigurationManager.AppSettings("pwd")

            mailClient.Credentials = New System.Net.NetworkCredential(uid, pwd)

            'mailClient.Credentials = New System.Net.NetworkCredential("kj_retirado@geosolutions.com.ph", "karenjan")

            Dim mailmessage As New System.Net.Mail.MailMessage(From, [To], Subject, Body)
            If CC.Trim() <> "" Then
                mailmessage.CC.Add(CC)
            End If
            Dim Attach As System.Net.Mail.Attachment = Nothing
            If AttachmentFilePath.Trim() <> "" Then
                Attach = New System.Net.Mail.Attachment(AttachmentFilePath)
            End If
            If Attach IsNot Nothing Then
                mailmessage.Attachments.Add(Attach)
            End If
            mailmessage.IsBodyHtml = True
            'mailClient.DeliveryMethod = SmtpDeliveryMethod.Network
            mailClient.EnableSsl = False
            mailmessage.SubjectEncoding = System.Text.Encoding.UTF8
            mailmessage.BodyEncoding = System.Text.Encoding.UTF8


            mailClient.Send(mailmessage)
            MailResult = "Mail(s) sent successfully."
            intResult = 0
        Catch ex As Exception
            MailResult = "Mail Unsuccessful : " & ex.Message
            intResult = -1
            'if( ex.ToString() = "System.UnauthorizedAccessException")
            '{
            ' MailResult +="Please give the ASP Net permission to the file before attachment.";
            '}
            Return MailResult
        End Try
        Return MailResult
    End Function

    Public Shared Function b64encode(ByVal StrEncode As String)
        Dim encodedString As String
        encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(StrEncode)))
        Return (encodedString)
    End Function
    Public Shared Function b64decode(ByVal StrDecode As String)
        Dim decodedString As String
        decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(StrDecode))
        Return decodedString
    End Function
End Class
