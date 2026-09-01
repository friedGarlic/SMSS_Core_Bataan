Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class refBrand
    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pBrandId As Integer
    Public Property BrandId() As Integer
        Get
            Return pBrandId
        End Get
        Set(ByVal value As Integer)
            pBrandId = value
        End Set
    End Property

    Private pBrandName As String
    Public Property BrandName() As String
        Get
            Return pBrandName
        End Get
        Set(ByVal value As String)
            pBrandName = value
        End Set
    End Property

    Private pManufacturerId As Integer
    Public Property ManufacturerId() As Integer
        Get
            Return pManufacturerId
        End Get
        Set(ByVal value As Integer)
            pManufacturerId = value
        End Set
    End Property

    Private pDistributorId As Integer
    Public Property DistributorId() As Integer
        Get
            Return pDistributorId
        End Get
        Set(ByVal value As Integer)
            pDistributorId = value
        End Set
    End Property
#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            BrandId = IIf(IsDBNull(rd("BrandId")), 0, rd("BrandId"))
            BrandName = IIf(IsDBNull(rd("BrandName")), "", rd("BrandName"))
            ManufacturerId = IIf(IsDBNull(rd("ManufacturerId")), 0, rd("ManufacturerId"))
            DistributorId = IIf(IsDBNull(rd("DistributorId")), 0, rd("DistributorId"))
        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@BrandId", 0)
        objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
        objDerived.cmd.Parameters.AddWithValue("@ManufacturerId", ManufacturerId)
        objDerived.cmd.Parameters.AddWithValue("@DistributorId", DistributorId)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaverefBrand", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@BrandId", BrandId)
        objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
        objDerived.cmd.Parameters.AddWithValue("@ManufacturerId", ManufacturerId)
        objDerived.cmd.Parameters.AddWithValue("@DistributorId", DistributorId)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaverefBrand", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
