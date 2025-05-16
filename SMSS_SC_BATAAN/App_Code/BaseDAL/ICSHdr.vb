Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class ICSHdr
    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pICSHdr_ID As Integer
    Public Property ICSHdr_ID() As Integer
        Get
            Return pICSHdr_ID
        End Get
        Set(ByVal value As Integer)
            pICSHdr_ID = value
        End Set
    End Property

    Private pICS_No As String
    Public Property ICS_No() As String
        Get
            Return pICS_No
        End Get
        Set(ByVal value As String)
            pICS_No = value
        End Set
    End Property

    Private pDate_Acquired As DateTime
    Public Property Date_Acquired() As DateTime
        Get
            Return pDate_Acquired
        End Get
        Set(ByVal value As DateTime)
            pDate_Acquired = value
        End Set
    End Property

    Private pRIS_no As String
    Public Property RIS_no() As String
        Get
            Return pRIS_no
        End Get
        Set(ByVal value As String)
            pRIS_no = value
        End Set
    End Property

    Private pRC_ID As Integer
    Public Property RC_ID() As Integer
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Integer)
            pRC_ID = value
        End Set
    End Property

    Private pFunction_ID As Integer
    Public Property Function_ID() As Integer
        Get
            Return pFunction_ID
        End Get
        Set(ByVal value As Integer)
            pFunction_ID = value
        End Set
    End Property

    Private pIssuedBy As String
    Public Property IssuedBy() As String
        Get
            Return pIssuedBy
        End Get
        Set(ByVal value As String)
            pIssuedBy = value
        End Set
    End Property

    Private pIssuedTo As String
    Public Property IssuedTo() As String
        Get
            Return pIssuedTo
        End Get
        Set(ByVal value As String)
            pIssuedTo = value
        End Set
    End Property

    Private pIssuedBy_Pos As String
    Public Property IssuedBy_Pos() As String
        Get
            Return pIssuedBy_Pos
        End Get
        Set(ByVal value As String)
            pIssuedBy_Pos = value
        End Set
    End Property

    Private pIssuedTo_Pos As String
    Public Property IssuedTo_Pos() As String
        Get
            Return pIssuedTo_Pos
        End Get
        Set(ByVal value As String)
            pIssuedTo_Pos = value
        End Set
    End Property

    Private pAccountablePerson As String
    Public Property AccountablePerson() As String
        Get
            Return pAccountablePerson
        End Get
        Set(ByVal value As String)
            pAccountablePerson = value
        End Set
    End Property

    Private pAccountablePerson_Pos As String
    Public Property AccountablePerson_Pos() As String
        Get
            Return pAccountablePerson_Pos
        End Get
        Set(ByVal value As String)
            pAccountablePerson_Pos = value
        End Set
    End Property

#End Region


    Public Function saveICSHdr() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ICSHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@ICS_No", ICS_No)
        objDerived.cmd.Parameters.AddWithValue("@Date_Acquired", Date_Acquired)
        objDerived.cmd.Parameters.AddWithValue("@RIS_no", RIS_no)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@IssuedBy", IssuedBy)
        objDerived.cmd.Parameters.AddWithValue("@IssuedTo", IssuedTo)
        objDerived.cmd.Parameters.AddWithValue("@IssuedBy_Pos", IssuedBy_Pos)
        objDerived.cmd.Parameters.AddWithValue("@IssuedTo_Pos", IssuedTo_Pos)
        objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
        objDerived.cmd.Parameters.AddWithValue("@AccountablePerson_Pos", AccountablePerson_Pos)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_ICS_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function updateICSHdr() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ICSHdr_ID", ICSHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@ICS_No", ICS_No)
        objDerived.cmd.Parameters.AddWithValue("@Date_Acquired", Date_Acquired)
        objDerived.cmd.Parameters.AddWithValue("@RIS_no", RIS_no)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@IssuedBy", IssuedBy)
        objDerived.cmd.Parameters.AddWithValue("@IssuedTo", IssuedTo)
        objDerived.cmd.Parameters.AddWithValue("@IssuedBy_Pos", IssuedBy_Pos)
        objDerived.cmd.Parameters.AddWithValue("@IssuedTo_Pos", IssuedTo_Pos)
        objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
        objDerived.cmd.Parameters.AddWithValue("@AccountablePerson_Pos", AccountablePerson_Pos)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_ICS_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
