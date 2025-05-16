Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class AREHdr
    Inherits BaseDLL.BaseDAL
#Region "Properties"
    Private pAREHdr_ID As Integer
    Public Property AREHdr_ID() As Integer
        Get
            Return pAREHdr_ID
        End Get
        Set(ByVal value As Integer)
            pAREHdr_ID = value
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

    Private pARE_No As String
    Public Property ARE_No() As String
        Get
            Return pARE_No
        End Get
        Set(ByVal value As String)
            pARE_No = value
        End Set
    End Property

    Private pARE_Date As DateTime
    Public Property ARE_Date() As DateTime
        Get
            Return pARE_Date
        End Get
        Set(ByVal value As DateTime)
            pARE_Date = value
        End Set
    End Property

    Private pReceived_From As String
    Public Property Received_From() As String
        Get
            Return pReceived_From
        End Get
        Set(ByVal value As String)
            pReceived_From = value
        End Set
    End Property

    Private pReceived_By As String
    Public Property Received_By() As String
        Get
            Return pReceived_By
        End Get
        Set(ByVal value As String)
            pReceived_By = value
        End Set
    End Property




#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.AREHdr_ID = IIf(IsDBNull(rd("AREHdr_ID")), 0, rd("AREHdr_ID"))
            Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
            Me.ARE_No = IIf(IsDBNull(rd("ARE_No")), 0, rd("ARE_No"))
            Me.ARE_Date = IIf(IsDBNull(rd("ARE_Date")), "", rd("ARE_Date"))
            Me.Received_From = IIf(IsDBNull(rd("Received_From")), "", rd("Received_From"))
            Me.Received_By = IIf(IsDBNull(rd("Received_By")), "", rd("Received_By"))


        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Sub saveAREHdr()
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@AREHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@ARE_No", ARE_No)
        objDerived.cmd.Parameters.AddWithValue("@ARE_Date", ARE_Date)
        objDerived.cmd.Parameters.AddWithValue("@Received_From", Received_From)
        objDerived.cmd.Parameters.AddWithValue("@Received_By", Received_By)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_ARE_HDR", CommandType.StoredProcedure, Nothing)
    End Sub

    Public Sub saveEditAREHdr()
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@AREHdr_ID", AREHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@ARE_No", ARE_No)
        objDerived.cmd.Parameters.AddWithValue("@ARE_Date", ARE_Date)
        objDerived.cmd.Parameters.AddWithValue("@Received_From", Received_From)
        objDerived.cmd.Parameters.AddWithValue("@Received_By", Received_By)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_ARE_HDR", CommandType.StoredProcedure, Nothing)
    End Sub
End Class
