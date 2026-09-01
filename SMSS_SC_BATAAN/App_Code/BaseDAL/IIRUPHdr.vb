Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class IIRUPHdr
    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pIIRUPHdr_ID As Integer
    Public Property IIRUPHdr_ID() As Integer
        Get
            Return pIIRUPHdr_ID
        End Get
        Set(ByVal value As Integer)
            pIIRUPHdr_ID = value
        End Set
    End Property

    Private pIIRUP_Date As DateTime
    Public Property IIRUP_Date() As DateTime
        Get
            Return pIIRUP_Date
        End Get
        Set(ByVal value As DateTime)
            pIIRUP_Date = value
        End Set
    End Property

    Private pCertified As String
    Public Property Certified() As String
        Get
            Return pCertified
        End Get
        Set(ByVal value As String)
            pCertified = value
        End Set
    End Property

    Private pCert_position As String
    Public Property Cert_position() As String
        Get
            Return pCert_position
        End Get
        Set(ByVal value As String)
            pCert_position = value
        End Set
    End Property

    Private pVerified As String
    Public Property Verified() As String
        Get
            Return pVerified
        End Get
        Set(ByVal value As String)
            pVerified = value
        End Set
    End Property

    Private pVer_position As String
    Public Property Ver_position() As String
        Get
            Return pVer_position
        End Get
        Set(ByVal value As String)
            pVer_position = value
        End Set
    End Property

    Private pApproved As String
    Public Property Approved() As String
        Get
            Return pApproved
        End Get
        Set(ByVal value As String)
            pApproved = value
        End Set
    End Property

    Private pInspectedby As String
    Public Property Inspectedby() As String
        Get
            Return pInspectedby
        End Get
        Set(ByVal value As String)
            pInspectedby = value
        End Set
    End Property

    Private pIsInspectioned As Boolean
    Public Property IsInspectioned() As Boolean
        Get
            Return pIsInspectioned
        End Get
        Set(ByVal value As Boolean)
            pIsInspectioned = value
        End Set
    End Property
    Private pRC_ID As String
    Public Property RC_ID() As String
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As String)
            pRC_ID = value
        End Set
    End Property

    Private pFUNCTION_ID As String
    Public Property FUNCTION_ID() As String
        Get
            Return pFUNCTION_ID
        End Get
        Set(ByVal value As String)
            pFUNCTION_ID = value
        End Set
    End Property




#End Region


    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@IIRUPHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@IIRUP_Date", IIRUP_Date)
        objDerived.cmd.Parameters.AddWithValue("@Certified", Certified)
        objDerived.cmd.Parameters.AddWithValue("@Cert_position", Cert_position)
        objDerived.cmd.Parameters.AddWithValue("@Verified", Verified)
        objDerived.cmd.Parameters.AddWithValue("@Ver_position", Ver_position)
        objDerived.cmd.Parameters.AddWithValue("@Approved", Approved)
        objDerived.cmd.Parameters.AddWithValue("@Inspected_by", Inspectedby)
        objDerived.cmd.Parameters.AddWithValue("@IsInspectioned", IsInspectioned)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@FUNCTION_ID", FUNCTION_ID)




        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "ams.spSave_IIRUP_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
