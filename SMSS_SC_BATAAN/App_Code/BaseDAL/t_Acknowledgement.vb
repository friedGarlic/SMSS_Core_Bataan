Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class t_Acknowledgement
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pAcknowledment_ID As Long
    Public Property Acknowledment_ID() As Long
        Get
            Return pAcknowledment_ID
        End Get
        Set(ByVal value As Long)
            pAcknowledment_ID = value
        End Set
    End Property

    Private pPOHdr_ID As Long
    Public Property POHdr_ID() As Long
        Get
            Return pPOHdr_ID
        End Get
        Set(ByVal value As Long)
            pPOHdr_ID = value
        End Set
    End Property

    Private paDate As Date
    Public Property aDate() As Date
        Get
            Return paDate
        End Get
        Set(ByVal value As Date)
            paDate = value
        End Set
    End Property

    Private pItems As String
    Public Property Items() As String
        Get
            Return pItems
        End Get
        Set(ByVal value As String)
            pItems = value
        End Set
    End Property


    Private pAcknowledgement_to As String
    Public Property Acknowledgement_to() As String
        Get
            Return pAcknowledgement_to
        End Get
        Set(ByVal value As String)
            pAcknowledgement_to = value
        End Set
    End Property

    Private pOfficer As String
    Public Property Officer() As String
        Get
            Return pOfficer
        End Get
        Set(ByVal value As String)
            pOfficer = value
        End Set
    End Property

    Private pPosition As String
    Public Property Position() As String
        Get
            Return pPosition
        End Get
        Set(ByVal value As String)
            pPosition = value
        End Set
    End Property
#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Acknowledment_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@aDate", aDate)
        objDerived.cmd.Parameters.AddWithValue("@Items", Items)
        objDerived.cmd.Parameters.AddWithValue("@Acknowledgement_to", Acknowledgement_to)
        objDerived.cmd.Parameters.AddWithValue("@Officer", Officer)
        objDerived.cmd.Parameters.AddWithValue("@Position", Position)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.Save_Acknowledgement", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
