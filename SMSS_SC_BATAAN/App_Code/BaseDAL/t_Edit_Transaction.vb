Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class t_Edit_Transaction
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pid As Long
    Public Property id() As Long
        Get
            Return pid
        End Get
        Set(ByVal value As Long)
            pid = value
        End Set
    End Property

    Private pPrimaryColumnName As String
    Public Property PrimaryColumnName() As String
        Get
            Return pPrimaryColumnName
        End Get
        Set(ByVal value As String)
            pPrimaryColumnName = value
        End Set
    End Property

    Private pTransactionID As Long
    Public Property TransactionID() As Long
        Get
            Return pTransactionID
        End Get
        Set(ByVal value As Long)
            pTransactionID = value
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

    Private pColumnName As String
    Public Property ColumnName() As String
        Get
            Return pColumnName
        End Get
        Set(ByVal value As String)
            pColumnName = value
        End Set
    End Property


    Private pTransactionDate As DateTime
    Public Property TransactionDate() As DateTime
        Get
            Return pTransactionDate
        End Get
        Set(ByVal value As DateTime)
            pTransactionDate = value
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

    Private pOldValue As String
    Public Property OldValue() As String
        Get
            Return pOldValue
        End Get
        Set(ByVal value As String)
            pOldValue = value
        End Set
    End Property

    Private pUserID As String
    Public Property UserID() As String
        Get
            Return pUserID
        End Get
        Set(ByVal value As String)
            pUserID = value
        End Set
    End Property

    Private pUserName2 As String
    Public Property UserName2() As String
        Get
            Return pUserName2
        End Get
        Set(ByVal value As String)
            pUserName2 = value
        End Set
    End Property

    Private pRemarks As String
    Public Property Remarks() As String
        Get
            Return pRemarks
        End Get
        Set(ByVal value As String)
            pRemarks = value
        End Set
    End Property

    'added 1/22/2013
    Private pisUsed As Boolean
    Public Property isUsed() As Boolean
        Get
            Return pisUsed
        End Get
        Set(ByVal value As Boolean)
            pisUsed = value
        End Set
    End Property

    'Added 1/22/2013
#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@id", 0)
        objDerived.cmd.Parameters.AddWithValue("@PrimaryColumnName", PrimaryColumnName)
        objDerived.cmd.Parameters.AddWithValue("@TransactionID", TransactionID)
        objDerived.cmd.Parameters.AddWithValue("@TableName", TableName)
        objDerived.cmd.Parameters.AddWithValue("@ColumnName", ColumnName)
        objDerived.cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate)
        objDerived.cmd.Parameters.AddWithValue("@NewValue", NewValue)
        objDerived.cmd.Parameters.AddWithValue("@OldValue", OldValue)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.AddWithValue("@UserName", UserName2)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@isUsed", isUsed)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Edit_Transaction", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
