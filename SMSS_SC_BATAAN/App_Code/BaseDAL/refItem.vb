Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class refItem
    Inherits BaseDLL.BaseDAL


#Region "Property"
    Private pItemId As Integer
    Public Property ItemId() As Integer
        Get
            Return pItemId
        End Get
        Set(ByVal value As Integer)
            pItemId = value
        End Set
    End Property

    Private pItemTypeId As Integer
    Public Property ItemTypeId() As Integer
        Get
            Return pItemTypeId
        End Get
        Set(ByVal value As Integer)
            pItemTypeId = value
        End Set
    End Property

    Private pItemDetailId As Integer
    Public Property ItemDetailId() As Integer
        Get
            Return pItemDetailId
        End Get
        Set(ByVal value As Integer)
            pItemDetailId = value
        End Set
    End Property

    Private pItemCode As String
    Public Property ItemCode() As String
        Get
            Return pItemCode
        End Get
        Set(ByVal value As String)
            pItemCode = value
        End Set
    End Property
#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            ItemId = IIf(IsDBNull(rd("ItemId")), 0, rd("ItemId"))
            ItemTypeId = IIf(IsDBNull(rd("ItemTypeId")), 0, rd("ItemTypeId"))
            ItemDetailId = IIf(IsDBNull(rd("ItemDetailId")), 0, rd("ItemDetailId"))
            ItemCode = IIf(IsDBNull(rd("ItemCode")), "", rd("ItemCode"))
        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function SaverefItem() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ItemId", 0)
        objDerived.cmd.Parameters.AddWithValue("@ItemTypeId", ItemTypeId)
        objDerived.cmd.Parameters.AddWithValue("@ItemDetailId", ItemDetailId)
        objDerived.cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaverefItem", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
