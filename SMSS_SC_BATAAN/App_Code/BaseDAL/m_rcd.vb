Imports System
Imports Microsoft.VisualBasic
Public Class m_rcd
    Inherits BaseDLL.BaseDAL

    Private pRCD_ID As Long
    Public Property RCD_ID() As Long
        Get
            Return pRCD_ID
        End Get
        Set(ByVal value As Long)
            pRCD_ID = value
        End Set
    End Property

    Private pRCD As String
    Public Property RCD() As String
        Get
            Return pRCD
        End Get
        Set(ByVal value As String)
            pRCD = value
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

    Private pDDate As DateTime
    Public Property DDate() As DateTime
        Get
            Return pDDate
        End Get
        Set(ByVal value As DateTime)
            pDDate = value
        End Set
    End Property



    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader
        While rd.Read()

            'RCD_ID = IIf(IsDBNull(rd("RCD_ID")), 0, rd("RCD_ID"))
            RCD = IIf(IsDBNull(rd("RCD")), "", rd("RCD"))
            F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
            DDate = IIf(IsDBNull(rd("DDate")), "", rd("DDate"))

        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Sub spSave_m_rcd()
        ' cmd.Parameters.AddWithValue("@OfficeID", 0)

        'cmd.Parameters.AddWithValue("@RCD_ID", 0)
        cmd.Parameters.AddWithValue("@RCD", RCD)
        cmd.Parameters.AddWithValue("@F_ID", F_ID)
        cmd.Parameters.AddWithValue("@DDate", DDate)

        cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
        Execute("dbo.spSave_m_rcd", Data.CommandType.StoredProcedure)
    End Sub
End Class
