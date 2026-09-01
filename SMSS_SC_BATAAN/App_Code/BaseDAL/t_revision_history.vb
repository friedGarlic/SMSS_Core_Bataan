Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class t_revision_history

    Inherits BaseDLL.BaseDAL

#Region "properties"
    Private prevision_id As Long
    Public Property revision_id() As Long
        Get
            Return prevision_id
        End Get
        Set(ByVal value As Long)
            prevision_id = value
        End Set
    End Property

    Private prc_id As Long
    Public Property rc_id() As Long
        Get
            Return prc_id
        End Get
        Set(ByVal value As Long)
            prc_id = value
        End Set
    End Property

    Private pfunction_id As Long
    Public Property function_id() As Long
        Get
            Return pfunction_id
        End Get
        Set(ByVal value As Long)
            pfunction_id = value
        End Set
    End Property

    Private pstatus As String
    Public Property status() As String
        Get
            Return pstatus
        End Get
        Set(ByVal value As String)
            pstatus = value
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

    Private pusername2 As String
    Public Property username2() As String
        Get
            Return pusername2
        End Get
        Set(ByVal value As String)
            pusername2 = value
        End Set
    End Property


#End Region




    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@revision_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@rc_id", rc_id)
        objDerived.cmd.Parameters.AddWithValue("@function_id", function_id)
        objDerived.cmd.Parameters.AddWithValue("@status", status)
        objDerived.cmd.Parameters.AddWithValue("@transaction_date", transaction_date)
        objDerived.cmd.Parameters.AddWithValue("@username", username2)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_revision_history", CommandType.StoredProcedure, Nothing)
        Return i
    End Function


End Class
