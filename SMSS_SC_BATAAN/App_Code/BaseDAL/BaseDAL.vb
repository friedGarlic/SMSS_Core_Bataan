Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic
Imports System
Imports System.Configuration

Public MustInherit Class BaseDAL
    Public cn As New SqlConnection
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public rd As SqlDataReader
    Public rtrnValue As Long
    Public conStr As String = ConfigurationManager.ConnectionStrings("constr").ToString
    Public pusername, ppassword As String

    Private Function SetDefaultCon() As String
        Return ConfigurationManager.ConnectionStrings(0).ToString
    End Function

    Public Sub UserNameSearch()
        Dim str As String
        str = conStr
        Dim i As Integer = str.IndexOf("User ID=")
        Dim j As Integer = i + 1 + 8 'start of User ID + the length of the string
        Dim k As Integer = j
        Dim username As String = ""

        For x As Integer = k To str.IndexOf(";Password") '49 to 53
            username = username & GetChar(conStr, x)
        Next
        pusername = username
    End Sub

    Public Sub PasswordSearch()
        Dim str As String
        str = conStr
        Dim i As Integer = str.IndexOf("Password=")
        Dim j As Integer = i + 1 + 9 'start of Password + the length of the string
        Dim k As Integer = j
        Dim password As String = ""

        For x As Integer = k To str.Length
            password = password & GetChar(conStr, x)
        Next
        ppassword = password
    End Sub

    Public Property username() As String
        Get
            Call UserNameSearch()
            Return pusername

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property Password() As String
        Get
            Call PasswordSearch()
            Return ppassword
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public MustOverride Sub FillEntity()

    Public Overridable Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing)
        cn = New SqlConnection(conStr)
        Try
            cmd.CommandTimeout = 50000
            cmd.CommandText = strCmd
            cmd.Connection = cn
            cmd.CommandType = cmdType

            If Not IsNothing(param) Then
                For Each p As SqlParameter In param
                    If IsNothing(p) Then
                        Continue For
                    Else
                        cmd.Parameters.Add(p)
                    End If
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If cn.State = Data.ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Overridable Function Execute(ByVal rtnPrm As String, ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As Long
        cn = New SqlConnection(conStr)
        'cn = New SqlConnection(SetDefaultCon)
        Try
            If Not IsNothing(param) Then
                For Each p As SqlParameter In param
                    If IsNothing(p) Then
                        Continue For
                    Else
                        cmd.Parameters.Add(p)
                    End If
                Next
            End If
            cmd.CommandTimeout = 50000
            cmd.CommandText = strCmd
            cmd.Connection = cn
            cmd.CommandType = cmdType
            cn.Open()
            cmd.ExecuteScalar()
            If rtnPrm <> "" Then
                rtrnValue = cmd.Parameters(rtnPrm).Value
            End If
            cmd.Parameters.Clear()

            Return rtrnValue

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If cn.State = Data.ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function

    Public Overridable Function GetRecords(ByVal param() As SqlParameter, ByVal ds As DataSet, ByVal strCmd As String, ByVal cmdType As CommandType) As DataSet
        'cn = New SqlConnection(SetDefaultCon)
        cn = New SqlConnection(conStr)

        Try
            If Not IsNothing(param) Then
                For Each p As SqlParameter In param
                    If IsNothing(p) Then
                        Continue For
                    Else
                        cmd.Parameters.Add(p)
                    End If
                Next
            End If
            cmd.CommandTimeout = 50000
            cmd.CommandText = strCmd
            cmd.CommandType = cmdType
            cmd.Connection = cn
            da.SelectCommand = cmd
            cn.Open()
            da.Fill(ds)
            'da.Dispose()

            Return ds

        Catch ex As Exception
            Throw New Exception(ex.Message)
            'Throw New Exception("There was an error retrieving inmate record")
        Finally
            If cn.State = Data.ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function

    Public Overridable Function GetRecords(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As DataSet
        Dim ds As New DataSet
        cn = New SqlConnection(conStr)
        Try
            If Not IsNothing(param) Then
                For Each p As SqlParameter In param
                    cmd.Parameters.Add(p)
                Next
            End If
            cmd.CommandTimeout = 50000
            cmd.CommandText = strCmd
            cmd.CommandType = cmdType
            cmd.Connection = cn
            da.SelectCommand = cmd
            cn.Open()
            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If cn.State = Data.ConnectionState.Open Then
                cn.Close()
                cmd.Parameters.Clear()
            End If
        End Try
    End Function

    Public Overridable Function GetDataTable(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As DataTable
        Dim dt As New DataTable
        cn = New SqlConnection(conStr)
        Try
            If Not IsNothing(param) Then
                For Each p As SqlParameter In param
                    If IsNothing(p) Then
                        Continue For
                    Else
                        cmd.Parameters.Add(p)
                    End If
                Next
            End If
            cmd.CommandTimeout = 50000
            cmd.CommandText = strCmd
            cmd.CommandType = cmdType
            cmd.Connection = cn
            da.SelectCommand = cmd
            cn.Open()
            da.Fill(dt)

            Return dt
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            da.Dispose()
            If cn.State = Data.ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function

    Public Overridable Function GetValue(ByVal strCmd As String, ByVal cmdType As CommandType) As String
        Dim rtnVal As String
        cn = New SqlConnection(conStr)
        Try
            cmd.CommandTimeout = 50000
            cmd.CommandText = strCmd
            cmd.Connection = cn
            cmd.CommandType = cmdType
            cn.Open()
            rtnVal = cmd.ExecuteScalar()

            Return rtnVal
        Catch ex As Exception
            Throw New Exception(ex.Message.Trim())
        Finally
            If cn.State = Data.ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function

    Public Overridable Function Execute(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As Long
        'cn = New SqlConnection(SetDefaultCon)
        cn = New SqlConnection(conStr)
        Try
            If Not IsNothing(param) Then
                If Not IsNothing(param) Then
                    For Each p As SqlParameter In param
                        cmd.Parameters.Add(p)
                    Next
                End If
            End If
            cmd.CommandTimeout = 50000
            cmd.CommandText = strCmd
            cmd.Connection = cn
            cmd.CommandType = cmdType
            cn.Open()
            cmd.ExecuteScalar()
            'rtrnValue = cmd.Parameters(rtnprm).Value

            Return rtrnValue
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If cn.State = Data.ConnectionState.Open Then
                cn.Close()
                cmd.Parameters.Clear()
            End If
        End Try
    End Function

    Public Overridable Function GetTable(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As DataTable
        Dim dt As New DataTable
        'cn = New SqlConnection(SetDefaultCon)
        cn = New SqlConnection(conStr)
        Try
            If Not IsNothing(param) Then
                For Each p As SqlParameter In param
                    If IsNothing(p) Then
                        Continue For
                    Else
                        cmd.Parameters.Add(p)
                    End If
                Next
            End If
            cmd.CommandTimeout = 50000
            cmd.CommandText = strCmd
            cmd.CommandType = cmdType
            cmd.Connection = cn
            da.SelectCommand = cmd
            cn.Open()
            da.Fill(dt)

            Return dt
        Catch ex As Exception
            Throw New Exception(ex.Message)
            'Finally
            da.Dispose()
            If cn.State = Data.ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function
End Class

