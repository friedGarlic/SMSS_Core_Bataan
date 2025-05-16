Imports System
Imports Microsoft.VisualBasic

Public Class spSave_tbl_RCD_JEV_tag
    Inherits BaseDLL.BaseDAL
    Private pRCDID As Long
    Public Property RCDID() As Long
        Get
            Return pRCDID
        End Get
        Set(ByVal value As Long)
            pRCDID = value
        End Set
    End Property

    Private pRCDno As String
    Public Property RCDno() As String
        Get
            Return pRCDno
        End Get
        Set(ByVal value As String)
            pRCDno = value
        End Set
    End Property

    Private pJEV_TAG As Boolean
    Public Property JEV_TAG() As Boolean
        Get
            Return pJEV_TAG
        End Get
        Set(ByVal value As Boolean)
            pJEV_TAG = value
        End Set
    End Property

    Private pSystemName As String
    Public Property SystemName() As String
        Get
            Return pSystemName
        End Get
        Set(ByVal value As String)
            pSystemName = value
        End Set
    End Property


    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader
        While rd.Read()
            RCDID = IIf(IsDBNull(rd("RCDID")), 0, rd("RCDID"))
            RCDno = IIf(IsDBNull(rd("RCDno")), "", rd("RCDno"))
            JEV_TAG = IIf(IsDBNull(rd("JEV_TAG")), 0, rd("JEV_TAG"))
            SystemName = IIf(IsDBNull(rd("SystemName")), "", rd("SystemName"))
        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Sub spSave_tbl_RCD_JEV_tag()
        ' cmd.Parameters.AddWithValue("@OfficeID", 0)
        ' cmd.Parameters.AddWithValue("@RCDID", 0)
        cmd.Parameters.AddWithValue("@RCDno", RCDno)
        cmd.Parameters.AddWithValue("@JEV_TAG", JEV_TAG)
        cmd.Parameters.AddWithValue("@SystemName", SystemName)
        cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
        Execute("dbo.spSave_tbl_RCD_JEV_tag", Data.CommandType.StoredProcedure)
    End Sub
End Class
