Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic


Public Class Disposal_quotation_Lot
    Inherits BaseDLL.BaseDAL
#Region "Property"

    Private pquotation_Lot_ID As Long
    Public Property quotation_Lot_ID() As Long
        Get
            Return pquotation_Lot_ID
        End Get
        Set(ByVal value As Long)
            pquotation_Lot_ID = value
        End Set
    End Property

    Private pquotation_hdr_id As Long
    Public Property quotation_hdr_id() As Long
        Get
            Return pquotation_hdr_id
        End Get
        Set(ByVal value As Long)
            pquotation_hdr_id = value
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

    Private pTotalAmount As Decimal
    Public Property TotalAmount() As Decimal
        Get
            Return pTotalAmount
        End Get
        Set(ByVal value As Decimal)
            pTotalAmount = value
        End Set
    End Property

    Private pCompliance As Decimal
    Public Property Compliance() As Decimal
        Get
            Return pCompliance
        End Get
        Set(ByVal value As Decimal)
            pCompliance = value
        End Set
    End Property

    Private pquotation_date_dtl As Date
    Public Property quotation_date_dtl() As Date
        Get
            Return pquotation_date_dtl
        End Get
        Set(ByVal value As Date)
            pquotation_date_dtl = value
        End Set
    End Property

#End Region


    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@quotation_Lot_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@quotation_hdr_id", quotation_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount)
        objDerived.cmd.Parameters.AddWithValue("@Compliance", Compliance)
        objDerived.cmd.Parameters.AddWithValue("@quotation_date_dtl", quotation_date_dtl)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[spSave_Disposal_quotation_Lot]", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@quotation_Lot_ID", quotation_Lot_ID)
        objDerived.cmd.Parameters.AddWithValue("@quotation_hdr_id", quotation_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount)
        objDerived.cmd.Parameters.AddWithValue("@Compliance", Compliance)
        objDerived.cmd.Parameters.AddWithValue("@quotation_date_dtl", quotation_date_dtl)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[spSave_Disposal_quotation_Lot]", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
