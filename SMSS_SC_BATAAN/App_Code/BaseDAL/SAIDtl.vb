Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class SAIDtl

    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pSAIDtl_ID As Integer
    Public Property SAIDtl_ID() As Integer
        Get
            Return pSAIDtl_ID
        End Get
        Set(ByVal value As Integer)
            pSAIDtl_ID = value
        End Set
    End Property

    Private pSAIHdr_ID As Integer
    Public Property SAIHdr_ID() As Integer
        Get
            Return pSAIHdr_ID
        End Get
        Set(ByVal value As Integer)
            pSAIHdr_ID = value
        End Set
    End Property

    Private pItem_ID As Integer
    Public Property Item_ID() As Integer
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Integer)
            pItem_ID = value
        End Set
    End Property

    Private pInquireQty As Integer
    Public Property InquireQty() As Integer
        Get
            Return pInquireQty
        End Get
        Set(ByVal value As Integer)
            pInquireQty = value
        End Set
    End Property

    Private pAvailableQty As Integer
    Public Property AvailableQty() As Integer
        Get
            Return pAvailableQty
        End Get
        Set(ByVal value As Integer)
            pAvailableQty = value
        End Set
    End Property



#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.SAIDtl_ID = IIf(IsDBNull(rd("SAIDtl_ID")), 0, rd("SAIDtl_ID"))
            Me.SAIHdr_ID = IIf(IsDBNull(rd("SAIHdr_ID")), 0, rd("SAIHdr_ID"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.InquireQty = IIf(IsDBNull(rd("InquireQty")), 0, rd("InquireQty"))
            Me.AvailableQty = IIf(IsDBNull(rd("AvailableQty")), 0, rd("AvailableQty"))


        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Function saveSAIDtl() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@SAIDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@SAIHdr_ID", SAIHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@InquireQty", InquireQty)
        objDerived.cmd.Parameters.AddWithValue("@AvailableQty", AvailableQty)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_SAI_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
