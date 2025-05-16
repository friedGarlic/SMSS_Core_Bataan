Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class t_obr_evaluation_dtl
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pobr_evaluation_dtl_id As Long
    Public Property obr_evaluation_dtl_id() As Long
        Get
            Return pobr_evaluation_dtl_id
        End Get
        Set(ByVal value As Long)
            pobr_evaluation_dtl_id = value
        End Set
    End Property

    Private pobr_evaluation_hdr_id As Long
    Public Property obr_evaluation_hdr_id() As Long
        Get
            Return pobr_evaluation_hdr_id
        End Get
        Set(ByVal value As Long)
            pobr_evaluation_hdr_id = value
        End Set
    End Property

    Private pwithPreProcurement As Boolean
    Public Property withPreProcurement() As Boolean
        Get
            Return pwithPreProcurement
        End Get
        Set(ByVal value As Boolean)
            pwithPreProcurement = value
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


    Private pSupplier_ID As Integer
    Public Property Supplier_ID() As Integer
        Get
            Return pSupplier_ID
        End Get
        Set(ByVal value As Integer)
            pSupplier_ID = value
        End Set
    End Property


#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@obr_evaluation_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@obr_evaluation_hdr_id", obr_evaluation_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@withPreProcurement", withPreProcurement)
        objDerived.cmd.Parameters.AddWithValue("@prhdr_id", prhdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_obr_evaluation_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
