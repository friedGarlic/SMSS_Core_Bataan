Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class APR_dtl
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private papr_dtl_id As Integer
    Public Property apr_dtl_id() As Integer
        Get
            Return papr_dtl_id
        End Get
        Set(ByVal value As Integer)
            papr_dtl_id = value
        End Set
    End Property

    Private papr_hdr_id As Integer
    Public Property apr_hdr_id() As Integer
        Get
            Return papr_hdr_id
        End Get
        Set(ByVal value As Integer)
            papr_hdr_id = value
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

    Private pQty As Integer
    Public Property Qty() As Integer
        Get
            Return pQty
        End Get
        Set(ByVal value As Integer)
            pQty = value
        End Set
    End Property

    Private pcost As Decimal
    Public Property cost() As Decimal
        Get
            Return pcost
        End Get
        Set(ByVal value As Decimal)
            pcost = value
        End Set
    End Property

    Private pdeptid As Integer
    Public Property deptid() As Integer
        Get
            Return pdeptid
        End Get
        Set(ByVal value As Integer)
            pdeptid = value
        End Set
    End Property



#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader
        While rd.Read()
            Me.apr_dtl_id = IIf(IsDBNull(rd("apr_dtl_id")), 0, rd("apr_dtl_id"))
            Me.apr_hdr_id = IIf(IsDBNull(rd("apr_hdr_id")), 0, rd("apr_hdr_id"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.Qty = IIf(IsDBNull(rd("Qty")), 0, rd("Qty"))
            Me.cost = IIf(IsDBNull(rd("cost")), 0.0, rd("cost"))



        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function save_APR_dtl() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@apr_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@apr_hdr_id", apr_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@cost", cost)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_APR_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
