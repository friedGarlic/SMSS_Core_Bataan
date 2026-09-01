Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class t_purchase_request_obr_adjustment_hdr
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pobr_adjustment_hdr_id As Long
    Public Property obr_adjustment_hdr_id() As Long
        Get
            Return pobr_adjustment_hdr_id
        End Get
        Set(ByVal value As Long)
            pobr_adjustment_hdr_id = value
        End Set
    End Property

    Private pOBR_Hdr_ID As Long
    Public Property OBR_Hdr_ID() As Long
        Get
            Return pOBR_Hdr_ID
        End Get
        Set(ByVal value As Long)
            pOBR_Hdr_ID = value
        End Set
    End Property

    Private pPOHdr_ID As Long
    Public Property POHdr_ID() As Long
        Get
            Return pPOHdr_ID
        End Get
        Set(ByVal value As Long)
            pPOHdr_ID = value
        End Set
    End Property

    Private pisforAdjustment As Boolean
    Public Property isforAdjustment() As Boolean
        Get
            Return pisforAdjustment
        End Get
        Set(ByVal value As Boolean)
            pisforAdjustment = value
        End Set
    End Property
    Private pprhdr_id As Long
    Public Property prhdr_id() As Long
        Get
            Return pprhdr_id
        End Get
        Set(ByVal value As Long)
            pprhdr_id = value
        End Set
    End Property


#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@obr_adjustment_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@OBR_Hdr_ID", OBR_Hdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@prhdr_id", prhdr_id)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@isforAdjustment", isforAdjustment)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_obr_adjustment_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
