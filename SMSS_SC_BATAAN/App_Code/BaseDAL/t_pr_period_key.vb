Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class t_pr_period_key

    Inherits BaseDLL.BaseDAL

#Region "properties"
    Private ppr_period_key_id As Long
    Public Property pr_period_key_id() As Long
        Get
            Return ppr_period_key_id
        End Get
        Set(ByVal value As Long)
            ppr_period_key_id = value
        End Set
    End Property

    Private ppr_period_key_desc As String
    Public Property pr_period_key_desc() As String
        Get
            Return ppr_period_key_desc
        End Get
        Set(ByVal value As String)
            ppr_period_key_desc = value
        End Set
    End Property

    Private pdate_from As DateTime
    Public Property date_from() As DateTime
        Get
            Return pdate_from
        End Get
        Set(ByVal value As DateTime)
            pdate_from = value
        End Set
    End Property

    Private pdate_to As DateTime
    Public Property date_to() As DateTime
        Get
            Return pdate_to
        End Get
        Set(ByVal value As DateTime)
            pdate_to = value
        End Set
    End Property

    Private pisClosed As Boolean
    Public Property isClosed() As Boolean
        Get
            Return pisClosed
        End Get
        Set(ByVal value As Boolean)
            pisClosed = value
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



#End Region




    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@pr_period_key_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@pr_period_key_desc", pr_period_key_desc)
        objDerived.cmd.Parameters.AddWithValue("@date_from", date_from)
        objDerived.cmd.Parameters.AddWithValue("@date_to", date_to)
        objDerived.cmd.Parameters.AddWithValue("@isClosed", isClosed)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_pr_period_key", CommandType.StoredProcedure, Nothing)
        Return i
    End Function


End Class
