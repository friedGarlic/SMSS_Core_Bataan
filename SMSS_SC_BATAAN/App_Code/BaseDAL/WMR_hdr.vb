Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class WMR_hdr
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pWMHdr_ID As Integer
    Public Property WMHdr_ID() As Integer
        Get
            Return pWMHdr_ID
        End Get
        Set(ByVal value As Integer)
            pWMHdr_ID = value
        End Set
    End Property

    Private pWM_Date As DateTime
    Public Property WM_Date() As DateTime
        Get
            Return pWM_Date
        End Get
        Set(ByVal value As DateTime)
            pWM_Date = value
        End Set
    End Property

    Private pPlaceofstorage As String
    Public Property Placeofstorage() As String
        Get
            Return pPlaceofstorage
        End Get
        Set(ByVal value As String)
            pPlaceofstorage = value
        End Set
    End Property

    Private pCertifiedby As String
    Public Property Certifiedby() As String
        Get
            Return pCertifiedby
        End Get
        Set(ByVal value As String)
            pCertifiedby = value
        End Set
    End Property

    Private pApprovedby As String
    Public Property Approvedby() As String
        Get
            Return pApprovedby
        End Get
        Set(ByVal value As String)
            pApprovedby = value
        End Set
    End Property

    Private pInspector As String
    Public Property Inspector() As String
        Get
            Return pInspector
        End Get
        Set(ByVal value As String)
            pInspector = value
        End Set
    End Property

    Private pWitness As String
    Public Property Witness() As String
        Get
            Return pWitness
        End Get
        Set(ByVal value As String)
            pWitness = value
        End Set
    End Property
    Private prc_id As Integer
    Public Property rc_id() As Integer
        Get
            Return prc_id
        End Get
        Set(ByVal value As Integer)
            prc_id = value
        End Set
    End Property
    Private pfunction_id As Integer
    Public Property function_id() As Integer
        Get
            Return pfunction_id
        End Get
        Set(ByVal value As Integer)
            pfunction_id = value
        End Set
    End Property


#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@WMHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@WM_Date", WM_Date)
        objDerived.cmd.Parameters.AddWithValue("@Placeofstorage", Placeofstorage)
        objDerived.cmd.Parameters.AddWithValue("@Certifiedby", Certifiedby)
        objDerived.cmd.Parameters.AddWithValue("@Approvedby", Approvedby)
        objDerived.cmd.Parameters.AddWithValue("@Inspector", Inspector)
        objDerived.cmd.Parameters.AddWithValue("@Witness", Witness)
        objDerived.cmd.Parameters.AddWithValue("@rc_id", Inspector)
        objDerived.cmd.Parameters.AddWithValue("@function_id", Witness)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_WMR_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
