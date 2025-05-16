Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class canvashdr
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pcnvashdr_id As Integer
    Public Property cnvashdr_id() As Integer
        Get
            Return pcnvashdr_id
        End Get
        Set(ByVal value As Integer)
            pcnvashdr_id = value
        End Set
    End Property

    Private pPR_No As String
    Public Property PR_No() As String
        Get
            Return pPR_No
        End Get
        Set(ByVal value As String)
            pPR_No = value
        End Set
    End Property

    Private pPR_Date As DateTime
    Public Property PR_Date() As DateTime
        Get
            Return pPR_Date
        End Get
        Set(ByVal value As DateTime)
            pPR_Date = value
        End Set
    End Property

    Private pcanvasdate As DateTime
    Public Property canvasdate() As DateTime
        Get
            Return pcanvasdate
        End Get
        Set(ByVal value As DateTime)
            pcanvasdate = value
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
    Private pRC_ID As Integer
    Public Property RC_ID() As Integer
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Integer)
            pRC_ID = value
        End Set
    End Property
    Private pdeptid As Integer
    Public Property deptid() As Integer
        Get
            Return pdeptid
        End Get
        Set(ByVal value As Integer)
            pdeptid = value
        End Set
    End Property
    Private pwithBID As Boolean
    Public Property withBID() As Boolean
        Get
            Return pwithBID
        End Get
        Set(ByVal value As Boolean)
            pwithBID = value
        End Set
    End Property




#End Region
    
    Public Function saveCanvashdr() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@cnvashdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@PR_No", PR_No)
        objDerived.cmd.Parameters.AddWithValue("@PR_Date", PR_Date)
        objDerived.cmd.Parameters.AddWithValue("@canvasdate", canvasdate)
        objDerived.cmd.Parameters.AddWithValue("@status", status)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.AddWithValue("@withBID", withBID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_canvas_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
