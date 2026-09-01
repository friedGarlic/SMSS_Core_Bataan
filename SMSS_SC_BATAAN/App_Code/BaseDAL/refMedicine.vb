Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class refMedicine
    Inherits BaseDLL.BaseDAL


#Region "property"
    Private pMedicineId As Integer
    Public Property MedicineId() As Integer
        Get
            Return pMedicineId
        End Get
        Set(ByVal value As Integer)
            pMedicineId = value
        End Set
    End Property

    Private pGenericId As Integer
    Public Property GenericId() As Integer
        Get
            Return pGenericId
        End Get
        Set(ByVal value As Integer)
            pGenericId = value
        End Set
    End Property

    Private pBrandId As Integer
    Public Property BrandId() As Integer
        Get
            Return pBrandId
        End Get
        Set(ByVal value As Integer)
            pBrandId = value
        End Set
    End Property

    Private pBFADNo As String
    Public Property BFADNo() As String
        Get
            Return pBFADNo
        End Get
        Set(ByVal value As String)
            pBFADNo = value

        End Set
    End Property
    Private pIsRx As Boolean
    Public Property IsRx() As Boolean
        Get
            Return pIsRx
        End Get
        Set(ByVal value As Boolean)
            pIsRx = value
        End Set
    End Property

    Private pIsNarcotics As Boolean
    Public Property IsNarcotics() As Boolean
        Get
            Return pIsNarcotics
        End Get
        Set(ByVal value As Boolean)
            pIsNarcotics = value
        End Set
    End Property
#End Region



    'Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
    '    MyBase.GetRecordsByID(strCmd, cmdType, param)

    '    cn.Open()
    '    rd = cmd.ExecuteReader

    '    While rd.Read()
    '        MedicineId = IIf(IsDBNull(rd("MedicineId")), 0, rd("MedicineId"))
    '        GenericId = IIf(IsDBNull(rd("GenericId")), 0, rd("GenericId"))
    '        BrandId = IIf(IsDBNull(rd("BrandId")), 0, rd("DeliveBrandIdryId"))
    '        BFADNo = IIf(IsDBNull(rd("BFADNo")), "", rd("BFADNo"))
    '        IsRx = IIf(IsDBNull(rd("IsRx")), 0, rd("IsRx"))
    '        ExpirationDate = IIf(IsDBNull(rd("ExpirationDate")), "", rd("ExpirationDate"))
    '        Qty = IIf(IsDBNull(rd("Qty")), 0, rd("Qty"))
    '    End While
    '    If cn.State = Data.ConnectionState.Open Then
    '        cn.Close()
    '    End If
    'End Sub
    Public Function SaverefMedicine() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MedicineId", 0)
        objDerived.cmd.Parameters.AddWithValue("@GenericId", GenericId)
        objDerived.cmd.Parameters.AddWithValue("@BrandId", BrandId)
        objDerived.cmd.Parameters.AddWithValue("@BFADNo", BFADNo)
        objDerived.cmd.Parameters.AddWithValue("@IsRx", IsRx)
        objDerived.cmd.Parameters.AddWithValue("@IsNarcotics", IsNarcotics)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaverefMedicine", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MedicineId", MedicineId)
        objDerived.cmd.Parameters.AddWithValue("@GenericId", GenericId)
        objDerived.cmd.Parameters.AddWithValue("@BrandId", BrandId)
        objDerived.cmd.Parameters.AddWithValue("@BFADNo", BFADNo)
        objDerived.cmd.Parameters.AddWithValue("@IsRx", IsRx)
        objDerived.cmd.Parameters.AddWithValue("@IsNarcotics", IsNarcotics)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaverefMedicine", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
