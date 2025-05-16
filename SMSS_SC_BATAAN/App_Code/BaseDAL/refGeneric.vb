Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class refGeneric
    Inherits BaseDLL.BaseDAL

#Region "property"

    Private pGenericId As Integer
    Public Property GenericId() As Integer
        Get
            Return pGenericId
        End Get
        Set(ByVal value As Integer)
            pGenericId = value
        End Set
    End Property

    Private pGenericName As String
    Public Property GenericName() As String
        Get
            Return pGenericName
        End Get
        Set(ByVal value As String)
            pGenericName = value
        End Set
    End Property

    Private pStockId As Integer
    Public Property StockId() As Integer
        Get
            Return pStockId
        End Get
        Set(ByVal value As Integer)
            pStockId = value
        End Set
    End Property
#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            GenericId = IIf(IsDBNull(rd("GenericId")), 0, rd("GenericId"))
            GenericName = IIf(IsDBNull(rd("GenericName")), "", rd("GenericName"))
            StockId = IIf(IsDBNull(rd("StockId")), 0, rd("StockId"))
        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function Save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@GenericId", 0)
        objDerived.cmd.Parameters.AddWithValue("@GenericName", GenericName)
        objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaverefGeneric", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@GenericId", GenericId)
        objDerived.cmd.Parameters.AddWithValue("@GenericName", GenericName)
        objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaverefGeneric", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
