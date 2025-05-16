Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic
Imports System
Imports System.Configuration

Public MustInherit Class BaseDAL_SysMngr
    Public cn As New SqlConnection
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public rd As SqlDataReader
    Public rtrnValue As Long
    Public DBuserID As String = "sa"
    Public DBpassWord As String = "P@ssw0rd"
    Public defaultCon As Integer

    Public conStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
    '= ConfigurationManager.ConnectionStrings(defaultCon).ToString
    'ConfigurationManager.ConnectionStrings(defaultCon).ToString
    '= "data source=.;Database = FSIS;integrated security=false;user id=" & DBuserID & ";password=" & DBpassWord
    'Public conStr As String = "data source=.;Database = MED;integrated security=false;user id=" & DBuserID & ";password=" & DBpassWord

    Private Function SetDefaultCon() As String
        'conStr = ConfigurationManager.ConnectionStrings(defaultCon).ToString
        Return ConfigurationManager.ConnectionStrings(defaultCon).ToString
    End Function

    Public MustOverride Sub FillEntity()

    Public Overridable Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing)
        'cn = New SqlConnection(conStr)
        cn = New SqlConnection(SetDefaultCon)
        Try
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
            Throw New Exception(ex.Message)  '"There was an error retrieving record")
        Finally


        End Try

    End Sub

    Public Overridable Function Execute(ByVal rtnPrm As String, ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As Long
        'cn = New SqlConnection(conStr)
        cn = New SqlConnection(SetDefaultCon)
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

    'Public Overridable Function GetRecords(ByVal param() As SqlParameter, ByVal ds As DataSet, ByVal strCmd As String, ByVal cmdType As CommandType) As DataSet
    '    cn = New SqlConnection(SetDefaultCon)
    '    ' cn = New SqlConnection(conStr)

    '    Try
    '        If Not IsNothing(param) Then
    '            For Each p As SqlParameter In param
    '                If IsNothing(p) Then
    '                    Continue For
    '                Else
    '                    cmd.Parameters.Add(p)
    '                End If
    '            Next
    '        End If

    '        cmd.CommandText = strCmd
    '        cmd.CommandType = cmdType
    '        cmd.Connection = cn
    '        da.SelectCommand = cmd
    '        cn.Open()
    '        da.Fill(ds)
    '        'da.Dispose()

    '        Return ds

    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '        'Throw New Exception("There was an error retrieving inmate record")
    '    Finally
    '        If cn.State = Data.ConnectionState.Open Then
    '            cn.Close()
    '        End If
    '    End Try

    'End Function
    Public Overridable Function GetRecords(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As DataSet
        Dim ds As New DataSet

        cn = New SqlConnection(conStr)
        Try
            If Not IsNothing(param) Then
                For Each p As SqlParameter In param
                    cmd.Parameters.Add(p)
                Next
            End If

            cmd.CommandText = strCmd
            cmd.CommandType = cmdType
            cmd.Connection = cn
            cmd.CommandTimeout = 0
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
    Public Overridable Function GetTable(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As DataTable
        Dim dt As New DataTable
        cn = New SqlConnection(SetDefaultCon)
        'cn = New SqlConnection(conStr)
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
    'Public Overridable Function GetDataTable(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As DataSet
    '    Dim dt As New DataSet
    '    cn = New SqlConnection(SetDefaultCon)
    '    'cn = New SqlConnection(conStr)
    '    Try
    '        If Not IsNothing(param) Then
    '            For Each p As SqlParameter In param
    '                If IsNothing(p) Then
    '                    Continue For
    '                Else
    '                    cmd.Parameters.Add(p)
    '                End If
    '            Next
    '        End If

    '        cmd.CommandText = strCmd
    '        cmd.CommandType = cmdType
    '        cmd.Connection = cn
    '        da.SelectCommand = cmd
    '        cn.Open()
    '        da.Fill(dt)

    '        Return dt

    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '        'Finally
    '        da.Dispose()
    '        If cn.State = Data.ConnectionState.Open Then
    '            cn.Close()
    '        End If
    '    End Try
    'End Function
    Public Overridable Function GetValue(ByVal strCmd As String, ByVal cmdType As CommandType) As String
        Dim rtnVal As String
        'cn = New SqlConnection(conStr)
        cn = New SqlConnection(SetDefaultCon)

        Try
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
    Public Overridable Function GetDataTable(ByVal strCmd As String, _
                                                ByVal cmdType As CommandType, _
                                                Optional ByVal param() As SqlParameter = Nothing) As DataTable
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

            cmd.CommandText = strCmd
            cmd.CommandType = cmdType
            cmd.Connection = cn

            da.SelectCommand = cmd
            cn.Open()
            da.Fill(dt)

            ''da.Dispose()

            Return dt
        Catch ex As Exception
            Throw New Exception(ex.Message)
            ''Throw New Exception("There was an error retrieving inmate record")
        Finally
            'da.Dispose() 
            If cn.State = Data.ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function
    Public Overridable Function Execute(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As Long
        cn = New SqlConnection(SetDefaultCon)
        Try
            If Not IsNothing(param) Then
                If Not IsNothing(param) Then
                    For Each p As SqlParameter In param
                        cmd.Parameters.Add(p)
                    Next
                End If
            End If

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


    Public Overridable Function GetUserID(ByVal userName As String) As Integer
        Dim rtnVal As String
        cn = New SqlConnection(conStr)
        cn.Open()
        Try
            cmd.CommandText = "SELECT SystemUserID FROM aspnet_Users WHERE LoweredUserName= '" & LCase(userName) & "'"
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text

            rtnVal = cmd.ExecuteScalar()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        Return rtnVal
    End Function


End Class
