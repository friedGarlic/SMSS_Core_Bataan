Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class t_public_bidding_canvas
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pcanvas_id As Long
    Public Property canvas_id() As Long
        Get
            Return pcanvas_id
        End Get
        Set(ByVal value As Long)
            pcanvas_id = value
        End Set
    End Property

    Private pbidding_hdr_id As Long
    Public Property bidding_hdr_id() As Long
        Get
            Return pbidding_hdr_id
        End Get
        Set(ByVal value As Long)
            pbidding_hdr_id = value
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

    Private pdatecanvas As DateTime
    Public Property datecanvas() As DateTime
        Get
            Return pdatecanvas
        End Get
        Set(ByVal value As DateTime)
            pdatecanvas = value
        End Set
    End Property

    Private pCompliance As Boolean
    Public Property Compliance() As Boolean
        Get
            Return pCompliance
        End Get
        Set(ByVal value As Boolean)
            pCompliance = value
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
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@canvas_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@bidding_hdr_id", bidding_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@datecanvas", datecanvas)
        objDerived.cmd.Parameters.AddWithValue("@Compliance", Compliance)
        objDerived.cmd.Parameters.AddWithValue("@isWinner", isWinner)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_canvas", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
