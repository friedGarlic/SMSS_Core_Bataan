Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class t_obr_evaluation_hdr
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pobr_evaluation_hdr_id As Long
    Public Property obr_evaluation_hdr_id() As Long
        Get
            Return pobr_evaluation_hdr_id
        End Get
        Set(ByVal value As Long)
            pobr_evaluation_hdr_id = value
        End Set
    End Property

    Private pmode_of_procurement_id As Integer
    Public Property mode_of_procurement_id() As Integer
        Get
            Return pmode_of_procurement_id
        End Get
        Set(ByVal value As Integer)
            pmode_of_procurement_id = value
        End Set
    End Property

    Private ptransaction_date As DateTime
    Public Property transaction_date() As DateTime
        Get
            Return ptransaction_date
        End Get
        Set(ByVal value As DateTime)
            ptransaction_date = value
        End Set
    End Property

    Private presolution_mode_of_procurement As String
    Public Property resolution_mode_of_procurement() As String
        Get
            Return presolution_mode_of_procurement
        End Get
        Set(ByVal value As String)
            presolution_mode_of_procurement = value
        End Set
    End Property

    Private pwithPreProcurement As Boolean
    Public Property withPreProcurement() As Boolean
        Get
            Return pwithPreProcurement
        End Get
        Set(ByVal value As Boolean)
            pwithPreProcurement = value
        End Set
    End Property

    Private pdatePreProcurement As DateTime
    Public Property datePreProcurement() As DateTime
        Get
            Return pdatePreProcurement
        End Get
        Set(ByVal value As DateTime)
            pdatePreProcurement = value
        End Set
    End Property

    Private pF_ID As Integer
    Public Property F_ID() As Integer
        Get
            Return pF_ID
        End Get
        Set(ByVal value As Integer)
            pF_ID = value
        End Set
    End Property


    Private pUserID As String
    Public Property UserID() As String
        Get
            Return pUserID
        End Get
        Set(ByVal value As String)
            pUserID = value
        End Set
    End Property


#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@obr_evaluation_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@mode_of_procurement_id", mode_of_procurement_id)
        objDerived.cmd.Parameters.AddWithValue("@transaction_date", transaction_date)
        objDerived.cmd.Parameters.AddWithValue("@resolution_mode_of_procurement", resolution_mode_of_procurement)
        objDerived.cmd.Parameters.AddWithValue("@withPreProcurement", withPreProcurement)
        objDerived.cmd.Parameters.AddWithValue("@datePreProcurement", datePreProcurement)
        'objDerived.cmd.Parameters.AddWithValue("@venue", venue)
        'objDerived.cmd.Parameters.AddWithValue("@isbyLot", isbyLot)
        objDerived.cmd.Parameters.AddWithValue("@F_ID", F_ID)
        'objDerived.cmd.Parameters.AddWithValue("@isPublicInfra", isPublicInfra)
        'objDerived.cmd.Parameters.AddWithValue("@isStraight", isStraight)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_obr_evaluation_hdr", CommandType.StoredProcedure, Nothing)
        Return i

    End Function
End Class
