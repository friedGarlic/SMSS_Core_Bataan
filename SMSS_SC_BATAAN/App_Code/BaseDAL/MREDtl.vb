Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class MREDtl
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pMREDtl_ID As Integer
    Public Property MREDtl_ID() As Integer
        Get
            Return pMREDtl_ID
        End Get
        Set(ByVal value As Integer)
            pMREDtl_ID = value
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

    Private pMREHdr_ID As Integer
    Public Property MREHdr_ID() As Integer
        Get
            Return pMREHdr_ID
        End Get
        Set(ByVal value As Integer)
            pMREHdr_ID = value
        End Set
    End Property








#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.MREDtl_ID = IIf(IsDBNull(rd("MREDtl_ID")), 0, rd("MREDtl_ID"))
            Me.PropertyNo = IIf(IsDBNull(rd("PropertyNo")), "", rd("PropertyNo"))
            Me.MREHdr_ID = IIf(IsDBNull(rd("MREHdr_ID")), 0, rd("MREHdr_ID"))
        End While

        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub
    Public Function saveMREDtl() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MREDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@MREHdr_ID", MREHdr_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_MRE_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function



End Class
