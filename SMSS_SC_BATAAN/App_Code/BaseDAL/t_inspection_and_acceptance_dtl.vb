Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class t_inspection_and_acceptance_dtl
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pAIRDtl_ID As Long
    Public Property AIRDtl_ID() As Long
        Get
            Return pAIRDtl_ID
        End Get
        Set(ByVal value As Long)
            pAIRDtl_ID = value
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

    Private pQty As Decimal
    Public Property Qty() As Decimal
        Get
            Return pQty
        End Get
        Set(ByVal value As Decimal)
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

    Private pAIRHdr_ID As Integer
    Public Property AIRHdr_ID() As Integer
        Get
            Return pAIRHdr_ID
        End Get
        Set(ByVal value As Integer)
            pAIRHdr_ID = value
        End Set
    End Property

    Private pGA_ID As Long
    Public Property GA_ID() As Long
        Get
            Return pGA_ID
        End Get
        Set(ByVal value As Long)
            pGA_ID = value
        End Set
    End Property

    Private pWarranty As String
    Public Property Warranty() As String
        Get
            Return pWarranty
        End Get
        Set(ByVal value As String)
            pWarranty = value
        End Set
    End Property


    Private pDate_Inspected As Date
    Public Property Date_Inspected() As Date
        Get
            Return pDate_Inspected
        End Get
        Set(ByVal value As Date)
            pDate_Inspected = value
        End Set
    End Property


    Private pDate_Accepted As Date
    Public Property Date_Accepted() As Date
        Get
            Return pDate_Accepted
        End Get
        Set(ByVal value As Date)
            pDate_Accepted = value
        End Set
    End Property


    Private pQty_Inspected As Decimal
    Public Property Qty_Inspected() As Decimal
        Get
            Return pQty_Inspected
        End Get
        Set(ByVal value As Decimal)
            pQty_Inspected = value
        End Set
    End Property


#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@AIRHdr_ID", AIRHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
        objDerived.cmd.Parameters.AddWithValue("@Qty_Inspected", Qty_Inspected)
        objDerived.cmd.Parameters.AddWithValue("@Qty_Accepted", Qty)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_AIR_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@AIRHdr_ID", AIRHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@Warranty", Warranty)
        objDerived.cmd.Parameters.AddWithValue("@Qty_Inspected", Qty_Inspected)
        objDerived.cmd.Parameters.AddWithValue("@Qty_Accepted", Qty)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_AIR_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
