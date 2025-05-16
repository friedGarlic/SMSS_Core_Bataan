Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.Collections.Generic


Public Class Disposal_quotation_dtl
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pquotation_dtl_id As Integer
    Public Property quotation_dtl_id() As Integer
        Get
            Return pquotation_dtl_id
        End Get
        Set(ByVal value As Integer)
            pquotation_dtl_id = value
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

    Private pCompliance As Boolean
    Public Property Compliance() As Boolean
        Get
            Return pCompliance
        End Get
        Set(ByVal value As Boolean)
            pCompliance = value
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
        objDerived.cmd.Parameters.AddWithValue("@quotation_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@quotation_hdr_id", quotation_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@cost", cost)
        objDerived.cmd.Parameters.AddWithValue("@Compliance", Compliance)
        objDerived.cmd.Parameters.AddWithValue("@quotation_date_dtl", quotation_date_dtl)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_Disposal_quotation_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
