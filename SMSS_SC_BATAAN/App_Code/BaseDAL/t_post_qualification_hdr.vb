Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class t_post_qualification_hdr
    Inherits BaseDLL.BaseDAL
#Region "properties"
    Private ppost_qualification_hdr_id As Long
    Public Property post_qualification_hdr_id() As Long
        Get
            Return ppost_qualification_hdr_id
        End Get
        Set(ByVal value As Long)
            ppost_qualification_hdr_id = value
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

    Private pSupplier_Id As Long
    Public Property Supplier_Id() As Long
        Get
            Return pSupplier_Id
        End Get
        Set(ByVal value As Long)
            pSupplier_Id = value
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

    Private ptransaction_date As DateTime
    Public Property transaction_date() As DateTime
        Get
            Return ptransaction_date
        End Get
        Set(ByVal value As DateTime)
            ptransaction_date = value
        End Set
    End Property

    Private pisWinner As Boolean
    Public Property isWinner() As Boolean
        Get
            Return pisWinner
        End Get
        Set(ByVal value As Boolean)
            pisWinner = value
        End Set
    End Property









#End Region



    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@post_qualification_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", pre_procurement_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@amount", amount)
        objDerived.cmd.Parameters.AddWithValue("@transaction_date", transaction_date)
        objDerived.cmd.Parameters.AddWithValue("@isWinner", isWinner)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_post_qualification_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
