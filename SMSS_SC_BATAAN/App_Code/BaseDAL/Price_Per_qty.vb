Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.Collections.Generic


Public Class Price_per_qty
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pitem_ID As Integer
    Public Property item_ID() As Integer
        Get
            Return pitem_ID
        End Get
        Set(ByVal value As Integer)
            pitem_ID = value
        End Set
    End Property


    Private pPPQ_ID As Integer
    Public Property PPQ_ID() As Integer
        Get
            Return pPPQ_ID
        End Get
        Set(ByVal value As Integer)
            pPPQ_ID = value
        End Set
    End Property
    Private pquotation_hdr_id As Integer
    Public Property quotation_hdr_id() As Integer
        Get
            Return pquotation_hdr_id
        End Get
        Set(ByVal value As Integer)
            pquotation_hdr_id = value
        End Set
    End Property

    Private pSupplier_Id As Integer
    Public Property Supplier_Id() As Integer
        Get
            Return pSupplier_Id
        End Get
        Set(ByVal value As Integer)
            pSupplier_Id = value
        End Set
    End Property

    Private pQtyPack As Integer
    Public Property QtyPack() As Integer
        Get
            Return pQtyPack
        End Get
        Set(ByVal value As Integer)
            pQtyPack = value
        End Set
    End Property

    Private pSelling_price As Decimal
    Public Property Selling_price() As Decimal
        Get
            Return pSelling_price
        End Get
        Set(ByVal value As Decimal)
            pSelling_price = value
        End Set
    End Property
    Private pUnit_Cost As Decimal
    Public Property Unit_Cost() As Decimal
        Get
            Return pUnit_Cost
        End Get
        Set(ByVal value As Decimal)
            pUnit_Cost = value
        End Set
    End Property

    Private pPPQ_Percent As Integer
    Public Property PPQ_Percent() As Integer
        Get
            Return pPPQ_Percent
        End Get
        Set(ByVal value As Integer)
            pPPQ_Percent = value
        End Set
    End Property

    Private pquotation_date_dtl As DateTime
    Public Property quotation_date_dtl() As DateTime
        Get
            Return pquotation_date_dtl
        End Get
        Set(ByVal value As DateTime)
            pquotation_date_dtl = value
        End Set
    End Property




#End Region


    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@PPQ_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", item_ID)
        objDerived.cmd.Parameters.AddWithValue("@QtyPack", QtyPack)
        objDerived.cmd.Parameters.AddWithValue("@Unit_Cost", Unit_Cost)
        objDerived.cmd.Parameters.AddWithValue("@PPQ_Percent", PPQ_Percent)
        objDerived.cmd.Parameters.AddWithValue("@Selling_price", Selling_price)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_Price_per_Qty", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
