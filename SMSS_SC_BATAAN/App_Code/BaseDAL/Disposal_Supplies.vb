Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Namespace Disposal_Supplies

#Region "Disposal_Supplies_Hdr"

    Public Class Disposal_Supplies_Hdr
        Inherits BaseDLL.BaseDAL

        Private pDSupplies_Hdr_ID As Long
        Public Property DSupplies_Hdr_ID() As Long
            Get
                Return pDSupplies_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pDSupplies_Hdr_ID = value
            End Set
        End Property

        Private pQuotation_Date As Date
        Public Property Quotation_Date() As Date
            Get
                Return pQuotation_Date
            End Get
            Set(ByVal value As Date)
                pQuotation_Date = value
            End Set
        End Property

        Private pDisposal_ID As Long
        Public Property Disposal_ID() As Long
            Get
                Return pDisposal_ID
            End Get
            Set(ByVal value As Long)
                pDisposal_ID = value
            End Set
        End Property


        Private pIIRUS_ID As Long
        Public Property IIRUS_ID() As Long
            Get
                Return pIIRUS_ID
            End Get
            Set(ByVal value As Long)
                pIIRUS_ID = value
            End Set
        End Property

        Private pSupplier_ID As Long
        Public Property Supplier_ID() As Long
            Get
                Return pSupplier_ID
            End Get
            Set(ByVal value As Long)
                pSupplier_ID = value
            End Set
        End Property

        Private pTotalAmount As Decimal
        Public Property TotalAmount() As Decimal
            Get
                Return pTotalAmount
            End Get
            Set(ByVal value As Decimal)
                pTotalAmount = value
            End Set
        End Property

        Private pisComplete As Boolean
        Public Property isComplete() As Boolean
            Get
                Return pisComplete
            End Get
            Set(ByVal value As Boolean)
                pisComplete = value
            End Set
        End Property

        Private pUserID As String
        Public Property UserID() As String
            Get
                Return pUserID
            End Get
            Set(ByVal value As String)
                pUserID = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DSupplies_Hdr_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Quotation_Date", Quotation_Date)
            objDerived.cmd.Parameters.AddWithValue("@Disposal_ID", Disposal_ID)
            objDerived.cmd.Parameters.AddWithValue("@IIRUS_ID", IIRUS_ID)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount)
            objDerived.cmd.Parameters.AddWithValue("@isComplete", isComplete)
            objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_Disposal_Supplies_Hdr]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DSupplies_Hdr_ID", DSupplies_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Quotation_Date", Quotation_Date)
            objDerived.cmd.Parameters.AddWithValue("@Disposal_ID", Disposal_ID)
            objDerived.cmd.Parameters.AddWithValue("@IIRUS_ID", IIRUS_ID)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount)
            objDerived.cmd.Parameters.AddWithValue("@isComplete", isComplete)
            objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_Disposal_Supplies_Hdr]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

#Region "Disposal_Supplies_Dtl"

    Public Class Disposal_Supplies_Dtl
        Inherits BaseDLL.BaseDAL

        Private pDSupplies_Dtl_ID As Long
        Public Property DSupplies_Dtl_ID() As Long
            Get
                Return pDSupplies_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pDSupplies_Dtl_ID = value
            End Set
        End Property

        Private pDSupplies_Hdr_ID As Long
        Public Property DSupplies_Hdr_ID() As Long
            Get
                Return pDSupplies_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pDSupplies_Hdr_ID = value
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

        Private pBidUnit_Price As Decimal
        Public Property BidUnit_Price() As Decimal
            Get
                Return pBidUnit_Price
            End Get
            Set(ByVal value As Decimal)
                pBidUnit_Price = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DSupplies_Dtl_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@DSupplies_Hdr_ID", DSupplies_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
            objDerived.cmd.Parameters.AddWithValue("@BidUnit_Price", BidUnit_Price)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_Disposal_Supplies_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DSupplies_Dtl_ID", DSupplies_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@DSupplies_Hdr_ID", DSupplies_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
            objDerived.cmd.Parameters.AddWithValue("@BidUnit_Price", BidUnit_Price)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_Disposal_Supplies_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

End Namespace
