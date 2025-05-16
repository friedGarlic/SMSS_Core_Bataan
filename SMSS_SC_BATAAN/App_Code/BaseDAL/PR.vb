Imports System
Imports Microsoft.VisualBasic

Public Class PR

    Inherits BaseDLL.BaseDAL
#Region "property"


    Private pPRHdr_ID As Integer
    Public Property PRHdr_ID() As Integer
        Get
            Return pPRHdr_ID
        End Get
        Set(ByVal value As Integer)
            pPRHdr_ID = value
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

    Private pRC_ID As Integer
    Public Property RC_ID() As Integer
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Integer)
            pRC_ID = value
        End Set
    End Property

    Private pPR_Year As Integer
    Public Property PR_Year() As Integer
        Get
            Return pPR_Year
        End Get
        Set(ByVal value As Integer)
            pPR_Year = value
        End Set
    End Property

    Private pPR_Status As String
    Public Property PR_Status() As String
        Get
            Return pPR_Status
        End Get
        Set(ByVal value As String)
            pPR_Status = value
        End Set
    End Property
#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.PRHdr_ID = IIf(IsDBNull(rd("PRHdr_ID")), 0, rd("PRHdr_ID"))
            Me.PR_No = IIf(IsDBNull(rd("PR_No")), "", rd("PR_No"))
            Me.PR_Date = IIf(IsDBNull(rd("PR_Date")), "", rd("PR_Date"))
            Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
            Me.PR_Year = IIf(IsDBNull(rd("PR_Year")), 0, rd("PR_Year"))
            Me.PR_Status = IIf(IsDBNull(rd("PR_Status")), "", rd("PR_Status"))

        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub


End Class