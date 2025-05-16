Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class IIRUPDtl
    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pIIRUPDtl_ID As Integer
    Public Property IIRUPDtl_ID() As Integer
        Get
            Return pIIRUPDtl_ID
        End Get
        Set(ByVal value As Integer)
            pIIRUPDtl_ID = value
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

    Private pProperty_ID As Integer
    Public Property Property_ID() As Integer
        Get
            Return pProperty_ID
        End Get
        Set(ByVal value As Integer)
            pProperty_ID = value
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

    Private pAdep As Decimal
    Public Property Adep() As Decimal
        Get
            Return pAdep
        End Get
        Set(ByVal value As Decimal)
            pAdep = value
        End Set
    End Property

    Private pnetval As Decimal
    Public Property netval() As Decimal
        Get
            Return pnetval
        End Get
        Set(ByVal value As Decimal)
            pnetval = value
        End Set
    End Property

    Private pAppraisedVal As Decimal
    Public Property AppraisedVal() As Decimal
        Get
            Return pAppraisedVal
        End Get
        Set(ByVal value As Decimal)
            pAppraisedVal = value
        End Set
    End Property

    Private pDisposal_id As Integer
    Public Property Disposal_id() As Integer
        Get
            Return pDisposal_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_id = value
        End Set
    End Property

    Private premarks As String
    Public Property remarks() As String
        Get
            Return premarks
        End Get
        Set(ByVal value As String)
            premarks = value
        End Set
    End Property

    Private pProperty_Date As DateTime
    Public Property Property_Date() As DateTime
        Get
            Return pProperty_Date
        End Get
        Set(ByVal value As DateTime)
            pProperty_Date = value
        End Set
    End Property

    Private pIIRUPHdr_ID As Integer
    Public Property IIRUPHdr_ID() As Integer
        Get
            Return pIIRUPHdr_ID
        End Get
        Set(ByVal value As Integer)
            pIIRUPHdr_ID = value
        End Set
    End Property

    Private pwithQuote As Boolean
    Public Property withQuote() As Boolean
        Get
            Return pwithQuote
        End Get
        Set(ByVal value As Boolean)
            pwithQuote = value
        End Set
    End Property
    Private pRC_ID As Integer
    Public Property RC_ID() As Integer
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Integer)
            pRC_ID = value
        End Set
    End Property

    Private pFUNCTION_ID As Integer
    Public Property FUNCTION_ID() As Integer
        Get
            Return pFUNCTION_ID
        End Get
        Set(ByVal value As Integer)
            pFUNCTION_ID = value
        End Set
    End Property

#End Region



    Public Sub save()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@IIRUPDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@cost", cost)
        objDerived.cmd.Parameters.AddWithValue("@Adep", Adep)
        objDerived.cmd.Parameters.AddWithValue("@netval", netval)
        objDerived.cmd.Parameters.AddWithValue("@AppraisedVal", AppraisedVal)
        objDerived.cmd.Parameters.AddWithValue("@Disposal_id", Disposal_id)
        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@Property_Date", Property_Date)
        objDerived.cmd.Parameters.AddWithValue("@IIRUPHdr_ID", IIRUPHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@withQuote", 0)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@FUNCTION_ID", FUNCTION_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_IIRUP_Dtl", CommandType.StoredProcedure, Nothing)

    End Sub

End Class
