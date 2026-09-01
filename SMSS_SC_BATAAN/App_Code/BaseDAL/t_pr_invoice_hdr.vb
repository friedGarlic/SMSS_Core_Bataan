Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class t_pr_invoice_hdr

    Inherits BaseDLL.BaseDAL

#Region "properties"
    Private ppr_invoice_hdr_id As Long
    Public Property pr_invoice_hdr_id() As Long
        Get
            Return ppr_invoice_hdr_id
        End Get
        Set(ByVal value As Long)
            ppr_invoice_hdr_id = value
        End Set
    End Property

    Private ppr_period_key_id As Long
    Public Property pr_period_key_id() As Long
        Get
            Return ppr_period_key_id
        End Get
        Set(ByVal value As Long)
            ppr_period_key_id = value
        End Set
    End Property

    Private prc_id As Long
    Public Property rc_id() As Long
        Get
            Return prc_id
        End Get
        Set(ByVal value As Long)
            prc_id = value
        End Set
    End Property

    Private pfunction_id As Long
    Public Property function_id() As Long
        Get
            Return pfunction_id
        End Get
        Set(ByVal value As Long)
            pfunction_id = value
        End Set
    End Property

    Private pInvoice_No As Long
    Public Property Invoice_No() As Long
        Get
            Return pInvoice_No
        End Get
        Set(ByVal value As Long)
            pInvoice_No = value
        End Set
    End Property

    Private pInvoice_Date As DateTime
    Public Property Invoice_Date() As DateTime
        Get
            Return pInvoice_Date
        End Get
        Set(ByVal value As DateTime)
            pInvoice_Date = value
        End Set
    End Property



    Private pSOA_No As Long
    Public Property SOA_No() As Long
        Get
            Return pSOA_No
        End Get
        Set(ByVal value As Long)
            pSOA_No = value
        End Set
    End Property


#End Region




    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@pr_invoice_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@pr_period_key_id", pr_period_key_id)
        objDerived.cmd.Parameters.AddWithValue("@rc_id", rc_id)
        objDerived.cmd.Parameters.AddWithValue("@function_id", function_id)
        objDerived.cmd.Parameters.AddWithValue("@Invoice_No", Invoice_No)
        objDerived.cmd.Parameters.AddWithValue("@Invoice_Date", Invoice_Date)
        objDerived.cmd.Parameters.AddWithValue("@SOA_No", SOA_No)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_pr_invoice_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function


End Class
