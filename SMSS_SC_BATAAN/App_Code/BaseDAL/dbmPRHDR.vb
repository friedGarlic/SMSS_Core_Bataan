Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class dbmPRHDR
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pdbmHdr As Integer
    Public Property dbmHdr() As Integer
        Get
            Return pdbmHdr
        End Get
        Set(ByVal value As Integer)
            pdbmHdr = value
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


#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.dbmHdr = IIf(IsDBNull(rd("dbmHdr")), 0, rd("dbmHdr"))
            Me.PR_No = IIf(IsDBNull(rd("PR_No")), "", rd("PR_No"))




        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function savedbmPRHDR() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@dbmHdr", 0)
        objDerived.cmd.Parameters.AddWithValue("@PR_No", PR_No)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_dbmPRHDR", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
