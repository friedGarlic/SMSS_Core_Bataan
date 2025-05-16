Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class t_pr_invoice_dtl

    Inherits BaseDLL.BaseDAL

#Region "properties"
    Private ppr_invoice_dtl_id As Long
    Public Property pr_invoice_dtl_id() As Long
        Get
            Return ppr_invoice_dtl_id
        End Get
        Set(ByVal value As Long)
            ppr_invoice_dtl_id = value
        End Set
    End Property

    Private ppr_invoice_hdr_id As Long
    Public Property pr_invoice_hdr_id() As Long
        Get
            Return ppr_invoice_hdr_id
        End Get
        Set(ByVal value As Long)
            ppr_invoice_hdr_id = value
        End Set
    End Property

    Private pitem_id As Long
    Public Property item_id() As Long
        Get
            Return pitem_id
        End Get
        Set(ByVal value As Long)
            pitem_id = value
        End Set
    End Property

    Private pqty As Decimal
    Public Property qty() As Decimal
        Get
            Return pqty
        End Get
        Set(ByVal value As Decimal)
            pqty = value
        End Set
    End Property

    Private pprice As Decimal
    Public Property price() As Decimal
        Get
            Return pprice
        End Get
        Set(ByVal value As Decimal)
            pprice = value
        End Set
    End Property





#End Region




    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@pr_invoice_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@pr_invoice_hdr_id", pr_invoice_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@item_id", item_id)
        objDerived.cmd.Parameters.AddWithValue("@qty", qty)
        objDerived.cmd.Parameters.AddWithValue("@price", price)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_pr_invoice_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function


End Class
