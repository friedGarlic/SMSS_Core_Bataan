Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Public Class t_annual_procurement_plan_hdr
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private papp_id As Long
    Public Property app_id() As Long
        Get
            Return papp_id
        End Get
        Set(ByVal value As Long)
            papp_id = value
        End Set
    End Property

    Private ptitle As String
    Public Property title() As String
        Get
            Return ptitle
        End Get
        Set(ByVal value As String)
            ptitle = value
        End Set
    End Property

    Private pyear As Integer
    Public Property year() As Integer
        Get
            Return pyear
        End Get
        Set(ByVal value As Integer)
            pyear = value
        End Set
    End Property

    Private pisPosted As Boolean
    Public Property isPosted() As Boolean
        Get
            Return pisPosted
        End Get
        Set(ByVal value As Boolean)
            pisPosted = value
        End Set
    End Property

    Private pisApproved As Boolean
    Public Property isApproved() As Boolean
        Get
            Return pisApproved
        End Get
        Set(ByVal value As Boolean)
            pisApproved = value
        End Set
    End Property

    Private pisforRevision As Boolean
    Public Property isforRevision() As Boolean
        Get
            Return pisforRevision
        End Get
        Set(ByVal value As Boolean)
            pisforRevision = value
        End Set
    End Property

    Private pstatus As Integer
    Public Property status() As Integer
        Get
            Return pstatus
        End Get
        Set(ByVal value As Integer)
            pstatus = value
        End Set
    End Property

    Private ppreparedby As Integer
    Public Property preparedby() As Integer
        Get
            Return ppreparedby
        End Get
        Set(ByVal value As Integer)
            ppreparedby = value
        End Set
    End Property

    Private pcerifiedby As Integer
    Public Property cerifiedby() As Integer
        Get
            Return pcerifiedby
        End Get
        Set(ByVal value As Integer)
            pcerifiedby = value
        End Set
    End Property

    Private papprovedby As Integer
    Public Property approvedby() As Integer
        Get
            Return papprovedby
        End Get
        Set(ByVal value As Integer)
            papprovedby = value
        End Set
    End Property

    Private pisContinuing As Boolean
    Public Property isContinuing() As Boolean
        Get
            Return pisContinuing
        End Get
        Set(ByVal value As Boolean)
            pisContinuing = value
        End Set
    End Property

    Private pisSupplemental As Boolean
    Public Property isSupplemental() As Boolean
        Get
            Return pisSupplemental
        End Get
        Set(ByVal value As Boolean)
            pisSupplemental = value
        End Set
    End Property

#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@app_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@title", title)
        objDerived.cmd.Parameters.AddWithValue("@year", year)
        objDerived.cmd.Parameters.AddWithValue("@isPosted", isPosted)
        objDerived.cmd.Parameters.AddWithValue("@isApproved", isApproved)
        objDerived.cmd.Parameters.AddWithValue("@isforRevision", isforRevision)
        objDerived.cmd.Parameters.AddWithValue("@status", status)
        objDerived.cmd.Parameters.AddWithValue("@preparedby", preparedby)
        objDerived.cmd.Parameters.AddWithValue("@cerifiedby", cerifiedby)
        objDerived.cmd.Parameters.AddWithValue("@approvedby", approvedby)
        objDerived.cmd.Parameters.AddWithValue("@isContinuing", isContinuing)
        objDerived.cmd.Parameters.AddWithValue("@isSupplemental", isSupplemental)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_APP", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
