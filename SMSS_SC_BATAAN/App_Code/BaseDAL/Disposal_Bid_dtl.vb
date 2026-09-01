Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class Disposal_bid_dtl
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pDisposal_Bid_dtl_id As Integer
    Public Property Disposal_Bid_dtl_id() As Integer
        Get
            Return pDisposal_Bid_dtl_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_Bid_dtl_id = value
        End Set
    End Property

    Private pDisposal_Bid_hdr_id As Integer
    Public Property Disposal_Bid_hdr_id() As Integer
        Get
            Return pDisposal_Bid_hdr_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_Bid_hdr_id = value
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

    Private pPropertyNo As String
    Public Property PropertyNo() As String
        Get
            Return pPropertyNo
        End Get
        Set(ByVal value As String)
            pPropertyNo = value
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

    Private pIs_Award As Boolean
    Public Property Is_Award() As Boolean
        Get
            Return pIs_Award
        End Get
        Set(ByVal value As Boolean)
            pIs_Award = value
        End Set
    End Property

    Private pwith_notice As Boolean
    Public Property with_notice() As Boolean
        Get
            Return pwith_notice
        End Get
        Set(ByVal value As Boolean)
            pwith_notice = value
        End Set
    End Property







#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Disposal_Bid_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@Disposal_Bid_hdr_id", Disposal_Bid_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@cost", cost)
        objDerived.cmd.Parameters.AddWithValue("@Is_Award", Is_Award)
        objDerived.cmd.Parameters.AddWithValue("@with_notice", with_notice)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_Disposal_Bid_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
