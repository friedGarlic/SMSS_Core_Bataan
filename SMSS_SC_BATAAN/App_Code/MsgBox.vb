Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System

Public Class MsgeBox
    Public Sub UserMsgBox(ByVal sMsg As String, ByVal e As System.Web.UI.Page, ByVal msgTag As Boolean)

        Dim sb As New StringBuilder()
        Dim oFormObject As New System.Web.UI.Control

        sMsg = sMsg.Replace("'", "\'")
        sMsg = sMsg.Replace(Chr(34), "\" & Chr(34))
        sMsg = sMsg.Replace(vbCrLf, "\n")
        If msgTag = True Then
            sMsg = "<script language=javascript>return confirm(""" & sMsg & """)</script>"
        Else
            sMsg = "<script language=javascript>alert(""" & sMsg & """)</script>"
        End If

        sb = New StringBuilder()
        sb.Append(sMsg)

        For Each oFormObject In e.Controls
            If TypeOf oFormObject Is HtmlForm Then
                Exit For
            End If
        Next

        ' Add the javascript after the form object so that the 
        ' message doesn't appear on a blank screen.
        oFormObject.Controls.AddAt(oFormObject.Controls.Count, New LiteralControl(sb.ToString()))
    End Sub

    Public Shared Sub MessageBox(ByRef btn As WebControls.Button, _
                                 ByVal strMessage As String, ByVal isAlert As Boolean)
        If isAlert = True Then
            btn.Attributes.Add("onclick", "alert('" & strMessage & "');")
        Else
            btn.Attributes.Add("onclick", "return confirm('" & strMessage & "');")
        End If

    End Sub

    Public Shared Sub CreateMessageAlertInUpdatePanel(ByVal up As UpdatePanel, ByVal strMessage As String, vbOKCancel As MsgBoxStyle)
        Dim strScript As String = "alert('" & strMessage & "');"
        Dim guidKey As Guid = Guid.NewGuid()
        ScriptManager.RegisterStartupScript(up, up.GetType(), guidKey.ToString(), strScript, True)
    End Sub

    Public Shared Sub CreateMessageAlertInUpdatePanel(ByVal up As UpdatePanel, ByVal strMessage As String)
        Dim strScript As String = "alert('" & strMessage & "');"
        Dim guidKey As Guid = Guid.NewGuid()
        ScriptManager.RegisterStartupScript(up, up.GetType(), guidKey.ToString(), strScript, True)
    End Sub

End Class

