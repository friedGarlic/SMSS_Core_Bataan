Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class t_pre_procurement_dtl
    Inherits BaseDLL.BaseDAL
#Region "properties"



    Private ppre_procurement_dtl_id As Long
    Public Property pre_procurement_dtl_id() As Long
        Get
            Return ppre_procurement_dtl_id
        End Get
        Set(ByVal value As Long)
            ppre_procurement_dtl_id = value
        End Set
    End Property

    Private ppre_procurement_hdr_id As Long
    Public Property pre_procurement_hdr_id() As Long
        Get
            Return ppre_procurement_hdr_id
        End Get
        Set(ByVal value As Long)
            ppre_procurement_hdr_id = value
        End Set
    End Property

    Private pobr_evaluation_dtl_id As Long
    Public Property obr_evaluation_dtl_id() As Long
        Get
            Return pobr_evaluation_dtl_id
        End Get
        Set(ByVal value As Long)
            pobr_evaluation_dtl_id = value
        End Set
    End Property

    Private pABC As Decimal
    Public Property ABC() As Decimal
        Get
            Return pABC
        End Get
        Set(ByVal value As Decimal)
            pABC = value
        End Set
    End Property






#End Region



    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@pre_procurement_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", pre_procurement_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@obr_evaluation_dtl_id", obr_evaluation_dtl_id)
        objDerived.cmd.Parameters.AddWithValue("@ABC", ABC)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_pre_procurement_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
