Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System
Imports System.Configuration

Public Class DerivedDal
    Inherits BaseDLL.BaseDAL


    Public Function DbaseConnect() As String
        MyBase.conStr = ConfigurationManager.ConnectionStrings("constr").ToString
        Return ConfigurationManager.ConnectionStrings("constr").ToString

        ' for imaqge connection string

        'MyBase.Imageconstr = ConfigurationManager.ConnectionStrings("Imageconstr").ToString
        'Return ConfigurationManager.ConnectionStrings("Imageconstr").ToString

    End Function

    Private obj As New BaseDLL.BaseDAL
    Public Sub deleteRecordsByID(ByVal id As Integer, ByVal field As String, ByVal table As String)
        obj.conStr = Me.DbaseConnect()
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection.ConnectionString = Me.DbaseConnect
        cmd.Connection = cn
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id
        cmd.Parameters.Add("@fieldId", SqlDbType.NVarChar).Value = field
        cmd.Parameters.Add("@table", SqlDbType.NVarChar).Value = table
        cmd.CommandText = "HRMS.sp_deleteRecordById"

        cn.ConnectionString = DbaseConnect()
        cn.Open()

        cmd.ExecuteNonQuery()
        cmd.Dispose()

        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub


    'Public Overridable Function GetValue(ByVal strCmd As String, ByVal cmdType As CommandType) As String
    '    Dim rtnVal As String
    '    cn = New SqlConnection(conStr)
    '    Try
    '        cmd.CommandTimeout = 50000
    '        cmd.CommandText = strCmd
    '        cmd.Connection = cn
    '        cmd.CommandType = cmdType
    '        cmd.CommandTimeout = 0
    '        cn.Open()
    '        If IsDBNull(cmd.ExecuteScalar) Then
    '            rtnVal = ""
    '        Else
    '            rtnVal = cmd.ExecuteScalar()
    '        End If
    '        Return rtnVal
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message.Trim())
    '    Finally
    '        If cn.State = Data.ConnectionState.Open Then
    '            cn.Close()
    '        End If
    '    End Try
    'End Function

    Public Overridable Function GetImageValue(ByVal strCmd As String, ByVal cmdType As CommandType) As String
        Dim rtnVal As String
        cn = New SqlConnection(conStr)
        Try
            cmd.CommandTimeout = 50000
            cmd.CommandText = strCmd
            cmd.Connection = cn
            cmd.CommandType = cmdType
            cmd.CommandTimeout = 0
            cn.Open()
            If IsDBNull(cmd.ExecuteScalar) Then
                rtnVal = ""
            Else
                rtnVal = cmd.ExecuteScalar()
            End If
            Return rtnVal
        Catch ex As Exception
            Throw New Exception(ex.Message.Trim())
        Finally
            If cn.State = Data.ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function

    Private Function IsDBNull(executeScalar As Object) As Boolean
        Throw New NotImplementedException()
    End Function
End Class
