Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class NoticeAuctionHdr
    Inherits BaseDLL.BaseDAL

#Region "Property"

    Private pNAHdr_ID As Integer
    Public Property NAHdr_ID() As Integer
        Get
            Return pNAHdr_ID
        End Get
        Set(ByVal value As Integer)
            pNAHdr_ID = value
        End Set
    End Property

    Private pNA_Date As DateTime
    Public Property NA_Date() As DateTime
        Get
            Return pNA_Date
        End Get
        Set(ByVal value As DateTime)
            pNA_Date = value
        End Set
    End Property


#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.NAHdr_ID = IIf(IsDBNull(rd("NAHdr_ID")), 0, rd("NAHdr_ID"))
            Me.NA_Date = IIf(IsDBNull(rd("NA_Date")), "", rd("NA_Date"))

        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveNAHdr()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@NAHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@NA_Date", NA_Date)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_NoticeAuction_Hdr", CommandType.StoredProcedure, Nothing)

    End Sub

End Class
