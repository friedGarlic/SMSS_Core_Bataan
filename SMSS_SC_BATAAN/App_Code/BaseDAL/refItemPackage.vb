Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class refItemPackage
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pItemPackageId As Integer
    Public Property ItemPackageId() As Integer
        Get
            Return pItemPackageId
        End Get
        Set(ByVal value As Integer)
            pItemPackageId = value
        End Set
    End Property
    Private pItemId As Integer
    Public Property ItemId() As Integer
        Get
            Return pItemId
        End Get
        Set(ByVal value As Integer)
            pItemId = value
        End Set
    End Property

    Private pAmount As Decimal
    Public Property Amount() As Decimal
        Get
            Return pAmount
        End Get
        Set(ByVal value As Decimal)
            pAmount = value
        End Set
    End Property

    Private pUnitId As Integer
    Public Property UnitId() As Integer
        Get
            Return pUnitId
        End Get
        Set(ByVal value As Integer)
            pUnitId = value
        End Set
    End Property

    Private pFormatId As Integer
    Public Property FormatId() As Integer

        Get
            Return pFormatId
        End Get
        Set(ByVal value As Integer)
            pFormatId = value
        End Set
    End Property
#End Region

    Public Function Save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ItemPackageId", 0)
        objDerived.cmd.Parameters.AddWithValue("@ItemId", ItemId)
        objDerived.cmd.Parameters.AddWithValue("@Amount", Amount)
        objDerived.cmd.Parameters.AddWithValue("@UnitId", UnitId)
        objDerived.cmd.Parameters.AddWithValue("@FormatId", FormatId)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaverefItemPackage", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ItemPackageId", ItemPackageId)
        objDerived.cmd.Parameters.AddWithValue("@ItemId", ItemId)
        objDerived.cmd.Parameters.AddWithValue("@Amount", Amount)
        objDerived.cmd.Parameters.AddWithValue("@UnitId", UnitId)
        objDerived.cmd.Parameters.AddWithValue("@FormatId", FormatId)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaverefItemPackage", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
