Imports Microsoft.VisualBasic
Imports System.Data
Imports System

Public Class AuditTrail
    Inherits BaseGeneral

#Region "Property"
    Private pAuditId As Long
    Public Property AuditId() As Long
        Get
            Return pAuditId
        End Get
        Set(ByVal value As Long)
            pAuditId = value
        End Set
    End Property

    Private pTableName As String
    Public Property TableName() As String
        Get
            Return pTableName
        End Get
        Set(ByVal value As String)
            pTableName = value
        End Set
    End Property

    Private pRowId As Long
    Public Property RowId() As Long
        Get
            Return pRowId
        End Get
        Set(ByVal value As Long)
            pRowId = value
        End Set
    End Property

    Private pOperation As String
    Public Property Operation() As String
        Get
            Return pOperation
        End Get
        Set(ByVal value As String)
            pOperation = value
        End Set
    End Property

    Private pOccurredAt As DateTime
    Public Property OccurredAt() As DateTime
        Get
            Return pOccurredAt
        End Get
        Set(ByVal value As DateTime)
            pOccurredAt = value
        End Set
    End Property

    Private pPerformedBy As String
    Public Property PerformedBy() As String
        Get
            Return pPerformedBy
        End Get
        Set(ByVal value As String)
            pPerformedBy = value
        End Set
    End Property

    Private pFieldName As String
    Public Property FieldName() As String
        Get
            Return pFieldName
        End Get
        Set(ByVal value As String)
            pFieldName = value
        End Set
    End Property

    Private pOldValue As String
    Public Property OldValue() As String
        Get
            Return pOldValue
        End Get
        Set(ByVal value As String)
            pOldValue = value
        End Set
    End Property

    Private pNewValue As String
    Public Property NewValue() As String
        Get
            Return pNewValue
        End Get
        Set(ByVal value As String)
            pNewValue = value
        End Set
    End Property




#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.AuditId = IIf(IsDBNull(rd("AuditId")), 0, rd("AuditId"))
            Me.TableName = IIf(IsDBNull(rd("TableName")), "", rd("TableName"))
            Me.RowId = IIf(IsDBNull(rd("RowId")), 0, rd("RowId"))
            Me.Operation = IIf(IsDBNull(rd("Operation")), "", rd("Operation"))
            Me.OccurredAt = IIf(IsDBNull(rd("OccurredAt")), "", rd("OccurredAt"))
            Me.PerformedBy = IIf(IsDBNull(rd("PerformedBy")), "", rd("PerformedBy"))
            Me.FieldName = IIf(IsDBNull(rd("FieldName")), "", rd("FieldName"))
            Me.OldValue = IIf(IsDBNull(rd("OldValue")), "", rd("OldValue"))
            Me.NewValue = IIf(IsDBNull(rd("NewValue")), "", rd("NewValue"))

        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub
    Public Sub save()
        Dim i As Long
        Me.cmd.Parameters.AddWithValue("@AuditId", 0)
        Me.cmd.Parameters.AddWithValue("@TableName", TableName)
        Me.cmd.Parameters.AddWithValue("@RowId", RowId)
        Me.cmd.Parameters.AddWithValue("@Operation", Operation)
        Me.cmd.Parameters.AddWithValue("@OccurredAt", OccurredAt)
        Me.cmd.Parameters.AddWithValue("@PerformedBy", PerformedBy)
        Me.cmd.Parameters.AddWithValue("@FieldName", FieldName)
        Me.cmd.Parameters.AddWithValue("@OldValue", OldValue)
        Me.cmd.Parameters.AddWithValue("@NewValue", NewValue)
        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = Me.Execute("@CurrID", "[dbo].[spSave_tbl_AuditTrail]", CommandType.StoredProcedure, Nothing)

    End Sub

End Class
