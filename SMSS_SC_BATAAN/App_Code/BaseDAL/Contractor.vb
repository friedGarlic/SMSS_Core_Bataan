Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class Contractor
    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pContractorID As Integer
    Public Property ContractorID() As Integer
        Get
            Return pContractorID
        End Get
        Set(ByVal value As Integer)
            pContractorID = value
        End Set
    End Property

    Private pFname As String
    Public Property Fname() As String
        Get
            Return pFname
        End Get
        Set(ByVal value As String)
            pFname = value
        End Set
    End Property

    Private pMname As String
    Public Property Mname() As String
        Get
            Return pMname
        End Get
        Set(ByVal value As String)
            pMname = value
        End Set
    End Property

    Private pLname As String
    Public Property Lname() As String
        Get
            Return pLname
        End Get
        Set(ByVal value As String)
            pLname = value
        End Set
    End Property

    Private pExtensionName As String
    Public Property ExtensionName() As String
        Get
            Return pExtensionName
        End Get
        Set(ByVal value As String)
            pExtensionName = value
        End Set
    End Property

    Private pAddress As String
    Public Property Address() As String
        Get
            Return pAddress
        End Get
        Set(ByVal value As String)
            pAddress = value
        End Set
    End Property

    Private pTIN As String
    Public Property TIN() As String
        Get
            Return pTIN
        End Get
        Set(ByVal value As String)
            pTIN = value
        End Set
    End Property

    Private pContactNo As String
    Public Property ContactNo() As String
        Get
            Return pContactNo
        End Get
        Set(ByVal value As String)
            pContactNo = value
        End Set
    End Property

    Private pFullname As String
    Public Property Fullname() As String
        Get
            Return pFullname
        End Get
        Set(ByVal value As String)
            pFullname = value
        End Set
    End Property


#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.ContractorID = IIf(IsDBNull(rd("ContractorID")), 0, rd("ContractorID"))
            Me.Fname = IIf(IsDBNull(rd("Fname")), "", rd("Fname"))
            Me.Mname = IIf(IsDBNull(rd("Mname")), "", rd("Mname"))
            Me.Lname = IIf(IsDBNull(rd("Lname")), "", rd("Lname"))
            Me.ExtensionName = IIf(IsDBNull(rd("ExtensionName")), "", rd("ExtensionName"))
            Me.Address = IIf(IsDBNull(rd("Address")), "", rd("Address"))
            Me.TIN = IIf(IsDBNull(rd("TIN")), "", rd("TIN"))
            Me.ContactNo = IIf(IsDBNull(rd("ContactNo")), "", rd("ContactNo"))
            Me.Fullname = IIf(IsDBNull(rd("Fullname")), "", rd("Fullname"))


        End While

        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveContractor()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ContractorID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Fname", Fname)
        objDerived.cmd.Parameters.AddWithValue("@Mname", Mname)
        objDerived.cmd.Parameters.AddWithValue("@Lname", Lname)
        objDerived.cmd.Parameters.AddWithValue("@ExtensionName", ExtensionName)
        objDerived.cmd.Parameters.AddWithValue("@Address", Address)
        objDerived.cmd.Parameters.AddWithValue("@TIN", TIN)
        objDerived.cmd.Parameters.AddWithValue("@ContactNo", ContactNo)
        objDerived.cmd.Parameters.AddWithValue("@Fullname", Fullname)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "spSave_Contractor", CommandType.StoredProcedure, Nothing)

    End Sub

    Public Sub saveEditContractor()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ContractorID", ContractorID)
        objDerived.cmd.Parameters.AddWithValue("@Fname", Fname)
        objDerived.cmd.Parameters.AddWithValue("@Mname", Mname)
        objDerived.cmd.Parameters.AddWithValue("@Lname", Lname)
        objDerived.cmd.Parameters.AddWithValue("@ExtensionName", ExtensionName)
        objDerived.cmd.Parameters.AddWithValue("@Address", Address)
        objDerived.cmd.Parameters.AddWithValue("@TIN", TIN)
        objDerived.cmd.Parameters.AddWithValue("@ContactNo", ContactNo)
        objDerived.cmd.Parameters.AddWithValue("@Fullname", Fullname)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "spSave_Contractor", CommandType.StoredProcedure, Nothing)

    End Sub
End Class
