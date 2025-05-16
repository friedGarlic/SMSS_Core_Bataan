Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class refDistributor
    Inherits BaseDLL.BaseDAL

#Region "Property"


    Private pDistributorId As Integer
    Public Property DistributorId() As Integer

        Get
            Return pDistributorId

        End Get
        Set(ByVal value As Integer)
            pDistributorId = value
        End Set
    End Property

    Private pDistributor As String
    Public Property Distributor() As String
        Get
            Return pDistributor
        End Get
        Set(ByVal value As String)
            pDistributor = value
        End Set
    End Property

    Private pDistributorAddress As String
    Public Property DistributorAddress() As String
        Get
            Return pDistributorAddress
        End Get
        Set(ByVal value As String)
            pDistributorAddress = value
        End Set
    End Property
#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            DistributorId = IIf(IsDBNull(rd("DistributorId")), 0, rd("DistributorId"))
            Distributor = IIf(IsDBNull(rd("Distributor")), "", rd("Distributor"))
            DistributorAddress = IIf(IsDBNull(rd("DistributorAddress")), "", rd("DistributorAddress"))
        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function saverefDistributor() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@DistributorId", 0)
        objDerived.cmd.Parameters.AddWithValue("@Distributor", Distributor)
        objDerived.cmd.Parameters.AddWithValue("@DistributorAddress", DistributorAddress)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaverefDistributor", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
