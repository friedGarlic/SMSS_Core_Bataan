Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class employee
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pid As Integer
    Public Property id() As Integer
        Get
            Return pid
        End Get
        Set(ByVal value As Integer)
            pid = value
        End Set
    End Property

    Private pemp_id As String
    Public Property emp_id() As String
        Get
            Return pemp_id
        End Get
        Set(ByVal value As String)
            pemp_id = value
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

    Private pEname As String
    Public Property Ename() As String
        Get
            Return pEname
        End Get
        Set(ByVal value As String)
            pEname = value
        End Set
    End Property

    Private pFullName As String
    Public Property FullName() As String
        Get
            Return pFullName
        End Get
        Set(ByVal value As String)
            pFullName = value
        End Set
    End Property

    Private pstatus As Boolean
    Public Property status() As Boolean
        Get
            Return pstatus
        End Get
        Set(ByVal value As Boolean)
            pstatus = value
        End Set
    End Property

   

    Private pUserId As Integer
    Public Property UserId() As Integer
        Get
            Return pUserId
        End Get
        Set(ByVal value As Integer)
            pUserId = value
        End Set
    End Property


 








#End Region



    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@id", 0)
        objDerived.cmd.Parameters.AddWithValue("@emp_id", emp_id)
        objDerived.cmd.Parameters.AddWithValue("@rc_id", rc_id)
        objDerived.cmd.Parameters.AddWithValue("@Fname", Fname)
        objDerived.cmd.Parameters.AddWithValue("@Mname", Mname)
        objDerived.cmd.Parameters.AddWithValue("@Lname", Lname)
        objDerived.cmd.Parameters.AddWithValue("@Ename", Ename)
        objDerived.cmd.Parameters.AddWithValue("@FullName", FullName)
        objDerived.cmd.Parameters.AddWithValue("@status", status)
        objDerived.cmd.Parameters.AddWithValue("@UserId", UserId)
        'objDerived.cmd.Parameters.AddWithValue("@TableId", TableId)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_employee", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
