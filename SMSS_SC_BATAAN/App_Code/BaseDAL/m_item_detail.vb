Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class m_item_detail
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pm_item_detail_id As Long
    Public Property m_item_detail_id() As Long
        Get
            Return pm_item_detail_id
        End Get
        Set(ByVal value As Long)
            pm_item_detail_id = value
        End Set
    End Property

    Private pItem_ID As Integer
    Public Property Item_ID() As Integer
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Integer)
            pItem_ID = value
        End Set
    End Property

    Private pprice As Decimal
    Public Property price() As Decimal
        Get
            Return pprice
        End Get
        Set(ByVal value As Decimal)
            pprice = value
        End Set
    End Property

    Private pUserId As String
    Public Property UserId() As String
        Get
            Return pUserId
        End Get
        Set(ByVal value As String)
            pUserId = value
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

#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.m_item_detail_id = IIf(IsDBNull(rd("m_item_detail_id")), 0, rd("m_item_detail_id"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.price = IIf(IsDBNull(rd("price")), 0.0, rd("price"))



        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@m_item_detail_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@price", price)
        objDerived.cmd.Parameters.AddWithValue("@UserId", UserId)
        'objDerived.cmd.Parameters.AddWithValue("@TableName", TableName)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_m_item_detail", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
