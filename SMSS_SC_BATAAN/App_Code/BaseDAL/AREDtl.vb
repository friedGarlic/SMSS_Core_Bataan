Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class AREDtl
    Inherits BaseDLL.BaseDAL
#Region "Properties"
    Private pAREDtl_ID As Integer
    Public Property AREDtl_ID() As Integer
        Get
            Return pAREDtl_ID
        End Get
        Set(ByVal value As Integer)
            pAREDtl_ID = value
        End Set
    End Property

    Private pPropertyNo As String
    Public Property PropertyNo() As String
        Get
            Return pPropertyNo
        End Get
        Set(ByVal value As String)
            pPropertyNo = value
        End Set
    End Property

    Private pAREHdr_ID As Integer
    Public Property AREHdr_ID() As Integer
        Get
            Return pAREHdr_ID
        End Get
        Set(ByVal value As Integer)
            pAREHdr_ID = value
        End Set
    End Property







#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.AREDtl_ID = IIf(IsDBNull(rd("AREDtl_ID")), 0, rd("AREDtl_ID"))
            Me.PropertyNo = IIf(IsDBNull(rd("PropertyNo")), "", rd("PropertyNo"))
            Me.AREHdr_ID = IIf(IsDBNull(rd("AREHdr_ID")), 0, rd("AREHdr_ID"))



        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Sub saveAREDtl()
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@AREDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@AREHdr_ID", AREHdr_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_ARE_DTL", CommandType.StoredProcedure, Nothing)
    End Sub

    Public Sub saveEditAREDtl()
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@AREDtl_ID", AREDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@AREHdr_ID", AREHdr_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_ARE_DTL", CommandType.StoredProcedure, Nothing)
    End Sub
End Class

