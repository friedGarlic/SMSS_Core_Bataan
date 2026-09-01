Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class PR_OBR
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pPR_OBR_ID As Integer
    Public Property PR_OBR_ID() As Integer
        Get
            Return pPR_OBR_ID
        End Get
        Set(ByVal value As Integer)
            pPR_OBR_ID = value
        End Set
    End Property

    Private pPRHdr_ID As Integer
    Public Property PRHdr_ID() As Integer
        Get
            Return pPRHdr_ID
        End Get
        Set(ByVal value As Integer)
            pPRHdr_ID = value
        End Set
    End Property

    Private pOBR_NO As String
    Public Property OBR_NO() As String
        Get
            Return pOBR_NO
        End Get
        Set(ByVal value As String)
            pOBR_NO = value
        End Set
    End Property

    Private pRC_ID As String
    Public Property RC_ID() As String
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As String)
            pRC_ID = value
        End Set
    End Property

    Private pdeptid As String
    Public Property deptid() As String
        Get
            Return pdeptid
        End Get
        Set(ByVal value As String)
            pdeptid = value
        End Set
    End Property




#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.PR_OBR_ID = IIf(IsDBNull(rd("PR_OBR_ID")), 0, rd("PR_OBR_ID"))
            Me.PRHdr_ID = IIf(IsDBNull(rd("PRHdr_ID")), 0, rd("PRHdr_ID"))
            Me.OBR_NO = IIf(IsDBNull(rd("OBR_NO")), "", rd("OBR_NO"))
            Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), "", rd("RC_ID"))
            '  Me.deptid = IIf(IsDBNull(rd("deptid")), "", rd("deptid"))
        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Public Function save_PR_OBR() As Long


        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long

        objDerived.cmd.Parameters.AddWithValue("@PR_OBR_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PRHdr_ID", PRHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@OBR_NO", OBR_NO)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        ' objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "geofmssms.AMS.spSave_PR_OBR", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
