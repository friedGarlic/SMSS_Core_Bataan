Imports System
Imports Microsoft.VisualBasic

Public Class ORUserStatus
    Inherits BaseDLL.BaseDAL
    Private pID As Long
    Public Property ID() As Long
        Get
            Return pID
        End Get
        Set(ByVal value As Long)
            pID = value
        End Set
    End Property

    Private pUserID As String
    Public Property UserID() As String
        Get
            Return pUserID
        End Get
        Set(ByVal value As String)
            pUserID = value
        End Set
    End Property

    Private pORID As Long
    Public Property ORID() As Long
        Get
            Return pORID
        End Get
        Set(ByVal value As Long)
            pORID = value
        End Set
    End Property

    Private pORTypeID As Integer
    Public Property ORTypeID() As Integer
        Get
            Return pORTypeID
        End Get
        Set(ByVal value As Integer)
            pORTypeID = value
        End Set
    End Property

    Private pCurrentOR As String
    Public Property CurrentOR() As String
        Get
            Return pCurrentOR
        End Get
        Set(ByVal value As String)
            pCurrentOR = value
        End Set
    End Property

    Private pEndingOR As String
    Public Property EndingOR() As String
        Get
            Return pEndingOR
        End Get
        Set(ByVal value As String)
            pEndingOR = value
        End Set
    End Property

    Private pCurrentQuantity As Integer
    Public Property CurrentQuantity() As Integer
        Get
            Return pCurrentQuantity
        End Get
        Set(ByVal value As Integer)
            pCurrentQuantity = value
        End Set
    End Property

    Private pConsumed As Boolean
    Public Property Consumed() As Boolean
        Get
            Return pConsumed
        End Get
        Set(ByVal value As Boolean)
            pConsumed = value
        End Set
    End Property

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader
        While rd.Read()


            ID = IIf(IsDBNull(rd("ID")), 0, rd("ID"))
            UserID = IIf(IsDBNull(rd("UserID")), 0, rd("UserID"))
            ORID = IIf(IsDBNull(rd("ORID")), 0, rd("ORID"))
            ORTypeID = IIf(IsDBNull(rd("ORTypeID")), 0, rd("ORTypeID"))
            CurrentOR = IIf(IsDBNull(rd("CurrentOR")), "", rd("CurrentOR"))
            EndingOR = IIf(IsDBNull(rd("EndingOR")), "", rd("EndingOR"))
            CurrentQuantity = IIf(IsDBNull(rd("CurrentQuantity")), 0, rd("CurrentQuantity"))
            Consumed = IIf(IsDBNull(rd("Consumed")), 0, rd("Consumed"))


        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Public Function spSave_UserORStatus()

        'cmd.Parameters.AddWithValue("@ID", 0)
        cmd.Parameters.AddWithValue("@UserID", UserID)
        cmd.Parameters.AddWithValue("@ORID", ORID)
        cmd.Parameters.AddWithValue("@ORTypeID", ORTypeID)
        cmd.Parameters.AddWithValue("@CurrentOR", CurrentOR)
        cmd.Parameters.AddWithValue("@EndingOR", EndingOR)
        'cmd.Parameters.AddWithValue("@CurrentQuantity", 0)
        cmd.Parameters.AddWithValue("@Consumed", Consumed)
        cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
        Return Execute("@CurrID", "dbo.spSave_UserORStatus", Data.CommandType.StoredProcedure)

    End Function





End Class
