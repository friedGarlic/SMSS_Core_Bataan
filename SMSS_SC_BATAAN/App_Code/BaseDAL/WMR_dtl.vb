Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class WMR_dtl
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pWMDtl_ID As Integer
    Public Property WMDtl_ID() As Integer
        Get
            Return pWMDtl_ID
        End Get
        Set(ByVal value As Integer)
            pWMDtl_ID = value
        End Set
    End Property

    Private pWMHdr_ID As Integer
    Public Property WMHdr_ID() As Integer
        Get
            Return pWMHdr_ID
        End Get
        Set(ByVal value As Integer)
            pWMHdr_ID = value
        End Set
    End Property

    Private pICSDt_lID As Integer
    Public Property ICSDt_lID() As Integer
        Get
            Return pICSDt_lID
        End Get
        Set(ByVal value As Integer)
            pICSDt_lID = value
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

    Private pORNUMEBER As String
    Public Property ORNUMEBER() As String
        Get
            Return pORNUMEBER
        End Get
        Set(ByVal value As String)
            pORNUMEBER = value
        End Set
    End Property

    Private pamount As Decimal
    Public Property amount() As Decimal
        Get
            Return pamount
        End Get
        Set(ByVal value As Decimal)
            pamount = value
        End Set
    End Property

    Private pDonee As String
    Public Property Donee() As String
        Get
            Return pDonee
        End Get
        Set(ByVal value As String)
            pDonee = value
        End Set
    End Property

    Private pMD As Integer
    Public Property MD() As Integer
        Get
            Return pMD
        End Get
        Set(ByVal value As Integer)
            pMD = value
        End Set
    End Property



#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@WMDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@WMHdr_ID", WMHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@ICSDt_lID", ICSDt_lID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)

        objDerived.cmd.Parameters.AddWithValue("@ORNUMEBER", ORNUMEBER)
        objDerived.cmd.Parameters.AddWithValue("@amount", amount)
        objDerived.cmd.Parameters.AddWithValue("@Donee", Donee)
        objDerived.cmd.Parameters.AddWithValue("@MD", MD)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_WMR_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@WMDtl_ID", WMDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@WMHdr_ID", WMHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@ICSDt_lID", ICSDt_lID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)

        objDerived.cmd.Parameters.AddWithValue("@ORNUMEBER", ORNUMEBER)
        objDerived.cmd.Parameters.AddWithValue("@amount", amount)
        objDerived.cmd.Parameters.AddWithValue("@Donee", Donee)
        objDerived.cmd.Parameters.AddWithValue("@MD", MD)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_WMR_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
