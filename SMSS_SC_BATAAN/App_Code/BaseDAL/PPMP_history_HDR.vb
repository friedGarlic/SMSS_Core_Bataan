Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class PPMP_history_HDR
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pPPMP_HIST_HDR As Long
    Public Property PPMP_HIST_HDR() As Long
        Get
            Return pPPMP_HIST_HDR
        End Get
        Set(ByVal value As Long)
            pPPMP_HIST_HDR = value
        End Set
    End Property

    Private pPPMP_HDR_ID As Long
    Public Property PPMP_HDR_ID() As Long
        Get
            Return pPPMP_HDR_ID
        End Get
        Set(ByVal value As Long)
            pPPMP_HDR_ID = value
        End Set
    End Property

    Private pPreparedBy As Integer
    Public Property PreparedBy() As Integer
        Get
            Return pPreparedBy
        End Get
        Set(ByVal value As Integer)
            pPreparedBy = value
        End Set
    End Property

    Private pPPMP_date As DateTime
    Public Property PPMP_date() As DateTime
        Get
            Return pPPMP_date
        End Get
        Set(ByVal value As DateTime)
            pPPMP_date = value
        End Set

    End Property

    Private pUser_id As String
    Public Property User_id() As String
        Get
            Return pUser_id
        End Get
        Set(ByVal value As String)
            pUser_id = value
        End Set
    End Property

#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@PPMP_HIST_HDR", 0)
        objDerived.cmd.Parameters.AddWithValue("@PPMP_HDR_ID", PPMP_HDR_ID)
        objDerived.cmd.Parameters.AddWithValue("@PreparedBy", PreparedBy)
        objDerived.cmd.Parameters.AddWithValue("@PPMP_date", PPMP_date)
        objDerived.cmd.Parameters.AddWithValue("@User_id", User_id)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_PPMP_history_HDR", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class


