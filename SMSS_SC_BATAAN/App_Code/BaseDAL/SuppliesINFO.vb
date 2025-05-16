Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class SupplieINFO
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pSuppliesId As Long
    Public Property SuppliesId() As Long
        Get
            Return pSuppliesId
        End Get
        Set(ByVal value As Long)
            pSuppliesId = value
        End Set
    End Property

    Private pStockID As Long
    Public Property StockID() As Long
        Get
            Return pStockID
        End Get
        Set(ByVal value As Long)
            pStockID = value
        End Set
    End Property

    Private pAIRDtl_ID As Long
    Public Property AIRDtl_ID() As Long
        Get
            Return pAIRDtl_ID
        End Get
        Set(ByVal value As Long)
            pAIRDtl_ID = value
        End Set
    End Property

    Private pItemId As Long
    Public Property ItemId() As Long
        Get
            Return pItemId
        End Get
        Set(ByVal value As Long)
            pItemId = value
        End Set
    End Property

    Private pDescription As String
    Public Property Description() As String
        Get
            Return pDescription
        End Get
        Set(ByVal value As String)
            pDescription = value
        End Set
    End Property

    Private pBrandName As String
    Public Property BrandName() As String
        Get
            Return pBrandName
        End Get
        Set(ByVal value As String)
            pBrandName = value
        End Set
    End Property

    Private pSupplierId As Long
    Public Property SupplierId() As Long
        Get
            Return pSupplierId
        End Get
        Set(ByVal value As Long)
            pSupplierId = value
        End Set
    End Property

    Private pSize As String
    Public Property Size() As String
        Get
            Return pSize
        End Get
        Set(ByVal value As String)
            pSize = value
        End Set
    End Property

    Private pColor As String
    Public Property Color() As String
        Get
            Return pColor
        End Get
        Set(ByVal value As String)
            pColor = value
        End Set
    End Property

    Private pCategory As String
    Public Property Category() As String
        Get
            Return pCategory
        End Get
        Set(ByVal value As String)
            pCategory = value
        End Set
    End Property

    Private pLength As String
    Public Property Length() As String
        Get
            Return pLength
        End Get
        Set(ByVal value As String)
            pLength = value
        End Set
    End Property

    Private pWidth As String
    Public Property Width() As String
        Get
            Return pWidth
        End Get
        Set(ByVal value As String)
            pWidth = value
        End Set
    End Property

    Private pHeight As String
    Public Property Height() As String
        Get
            Return pHeight
        End Get
        Set(ByVal value As String)
            pHeight = value
        End Set
    End Property

    Private pWeight As String
    Public Property Weight() As String
        Get
            Return pWeight
        End Get
        Set(ByVal value As String)
            pWeight = value
        End Set

    End Property

    Private pDepreciatedValue As String
    Public Property DepreciatedValue() As String
        Get
            Return pDepreciatedValue
        End Get
        Set(ByVal value As String)
            pDepreciatedValue = value
        End Set
    End Property

    Private pDepreciatedRate As String
    Public Property DepreciatedRate() As String
        Get
            Return pDepreciatedRate
        End Get
        Set(ByVal value As String)
            pDepreciatedRate = value
        End Set
    End Property

    Private pStatus As String
    Public Property Status() As String
        Get
            Return pStatus
        End Get
        Set(ByVal value As String)
            pStatus = value
        End Set
    End Property

    Private pComponentof As String
    Public Property Componentof() As String
        Get
            Return pComponentof
        End Get
        Set(ByVal value As String)
            pComponentof = value
        End Set
    End Property

    Private pReceived_ID As Long
    Public Property Received_ID() As Long
        Get
            Return pReceived_ID
        End Get
        Set(ByVal value As Long)
            pReceived_ID = value
        End Set
    End Property
    Private pDose As String
    Public Property Dose() As String
        Get
            Return pDose
        End Get
        Set(ByVal value As String)
            pDose = value
        End Set
    End Property
#End Region



    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@SuppliesId", 0)
        objDerived.cmd.Parameters.AddWithValue("@StockID", StockID)
        objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@ItemId", ItemId)
        objDerived.cmd.Parameters.AddWithValue("@Description", Description)
        objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
        objDerived.cmd.Parameters.AddWithValue("@SupplierId", SupplierId)
        objDerived.cmd.Parameters.AddWithValue("@Size", Size)
        objDerived.cmd.Parameters.AddWithValue("@Color", Color)
        objDerived.cmd.Parameters.AddWithValue("@Category", Category)
        objDerived.cmd.Parameters.AddWithValue("@Length", Length)
        objDerived.cmd.Parameters.AddWithValue("@Width", Width)
        objDerived.cmd.Parameters.AddWithValue("@Height", Height)
        objDerived.cmd.Parameters.AddWithValue("@Weight", Weight)
        objDerived.cmd.Parameters.AddWithValue("@DepreciatedValue", DepreciatedValue)
        objDerived.cmd.Parameters.AddWithValue("@DepreciatedRate", DepreciatedRate)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
        objDerived.cmd.Parameters.AddWithValue("@Componentof", Componentof)
        'objDerived.cmd.Parameters.AddWithValue("@Dose", Dose)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.Save_SuppliesInfo", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@SuppliesId", SuppliesId)
        objDerived.cmd.Parameters.AddWithValue("@StockID", StockID)
        objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@ItemId", ItemId)
        objDerived.cmd.Parameters.AddWithValue("@Description", Description)
        objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
        objDerived.cmd.Parameters.AddWithValue("@SupplierId", SupplierId)
        objDerived.cmd.Parameters.AddWithValue("@Size", Size)
        objDerived.cmd.Parameters.AddWithValue("@Color", Color)
        objDerived.cmd.Parameters.AddWithValue("@Category", Category)
        objDerived.cmd.Parameters.AddWithValue("@Length", Length)
        objDerived.cmd.Parameters.AddWithValue("@Width", Width)
        objDerived.cmd.Parameters.AddWithValue("@Height", Height)
        objDerived.cmd.Parameters.AddWithValue("@Weight", Weight)
        objDerived.cmd.Parameters.AddWithValue("@DepreciatedValue", DepreciatedValue)
        objDerived.cmd.Parameters.AddWithValue("@DepreciatedRate", DepreciatedRate)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
        objDerived.cmd.Parameters.AddWithValue("@Componentof", Componentof)
        objDerived.cmd.Parameters.AddWithValue("@Dose", Dose)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.Save_SuppliesInfo", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
