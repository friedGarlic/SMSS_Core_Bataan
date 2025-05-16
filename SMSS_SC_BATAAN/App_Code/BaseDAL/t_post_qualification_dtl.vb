Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class t_post_qualification_dtl
    Inherits BaseDLL.BaseDAL
#Region "properties"
    Private ppost_qualification_dtl_id As Long
    Public Property post_qualification_dtl_id() As Long
        Get
            Return ppost_qualification_dtl_id
        End Get
        Set(ByVal value As Long)
            ppost_qualification_dtl_id = value
        End Set
    End Property

    Private ppost_qualification_hdr_id As Long
    Public Property post_qualification_hdr_id() As Long
        Get
            Return ppost_qualification_hdr_id
        End Get
        Set(ByVal value As Long)
            ppost_qualification_hdr_id = value
        End Set
    End Property

    Private pItem_ID As Long
    Public Property Item_ID() As Long
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Long)
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

    Private pCost As Decimal
    Public Property Cost() As Decimal
        Get
            Return pCost
        End Get
        Set(ByVal value As Decimal)
            pCost = value
        End Set
    End Property









#End Region



    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@post_qualification_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@post_qualification_hdr_id", post_qualification_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_post_qualification_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
