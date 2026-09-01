Imports Microsoft.VisualBasic

Public Class connectionreport
    Inherits BaseDLL.BaseDAL
    Public Shadows pusername, ppassword As String

    Public Overloads Sub UserNameSearch()
        Dim str As String
        str = conStr
        Dim i As Integer = str.IndexOf("User ID=")
        Dim j As Integer = i + 1 + 8 'start of User ID + the length of the string
        Dim k As Integer = j
        Dim username As String = ""

        'User ID=test;Password=p@ssw0rd
        For x As Integer = k To str.IndexOf(";Password") '49 to 53
            username = username & GetChar(conStr, x)
        Next
        pusername = username
    End Sub

    Public Overloads Sub PasswordSearch()
        Dim str As String
        str = conStr
        Dim i As Integer = str.IndexOf("Password=")
        Dim j As Integer = i + 1 + 9 'start of Password + the length of the string
        Dim k As Integer = j
        Dim password As String = ""

        'User ID=test;Password=p@ssw0rd
        For x As Integer = k To str.Length
            password = password & GetChar(conStr, x)
        Next
        ppassword = password
    End Sub

    Public Overloads Property username() As String
        Get
            Call UserNameSearch()
            Return pusername

        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Private ppass As String
    Public Overloads Property Password() As String
        Get
            Call PasswordSearch()
            Return ppassword
        End Get
        Set(ByVal value As String)

        End Set
    End Property
End Class
