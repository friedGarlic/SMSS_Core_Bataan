Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Public Class Audit_Trail
    Inherits BaseDLL.BaseDAL

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

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@AuditId", 0)
        objDerived.cmd.Parameters.AddWithValue("@TableName", TableName)
        objDerived.cmd.Parameters.AddWithValue("@RowId", RowId)
        objDerived.cmd.Parameters.AddWithValue("@Operation", Operation)
        objDerived.cmd.Parameters.AddWithValue("@OccurredAt", OccurredAt)
        objDerived.cmd.Parameters.AddWithValue("@PerformedBy", PerformedBy)
        objDerived.cmd.Parameters.AddWithValue("@FieldName", FieldName)
        objDerived.cmd.Parameters.AddWithValue("@OldValue", OldValue)
        objDerived.cmd.Parameters.AddWithValue("@NewValue", NewValue)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[dbo].[spSave_tbl_AuditTrail]", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
