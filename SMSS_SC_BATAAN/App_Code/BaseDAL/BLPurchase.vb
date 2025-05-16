Imports Microsoft.VisualBasic

Public Class BLPurchase
    Inherits BaseDLL.BaseDAL

#Region "properties"
    Private pStockNo As String
    Public Property StockNo() As String
        Get
            Return pStockNo
        End Get
        Set(ByVal value As String)
            pStockNo = value
        End Set
    End Property

    Private pItemDesc As String
    Public Property Item_Desc() As String
        Get
            Return pItemDesc
        End Get
        Set(ByVal value As String)
            pItemDesc = value
        End Set
    End Property

    Private pUnitDesc As String
    Public Property Description() As String
        Get
            Return pUnitDesc
        End Get
        Set(ByVal value As String)
            pUnitDesc = value
        End Set
    End Property

    Private pQuantity As String
    Public Property Qty() As String
        Get
            Return pQuantity
        End Get
        Set(ByVal value As String)
            pQuantity = value
        End Set
    End Property

    Private pUnitCost As String
    Public Property Cost() As String
        Get
            Return pUnitCost
        End Get
        Set(ByVal value As String)
            pUnitCost = value
        End Set
    End Property

    Private pTotalCost As String
    Public Property Total() As String
        Get
            Return pTotalCost
        End Get
        Set(ByVal value As String)
            pTotalCost = value
        End Set
    End Property
#End Region

End Class
