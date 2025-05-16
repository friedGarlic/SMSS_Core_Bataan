Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class Disposal_Donation_dtl
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pDisposal_Donation_dtl_id As Integer
    Public Property Disposal_Donation_dtl_id() As Integer
        Get
            Return pDisposal_Donation_dtl_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_Donation_dtl_id = value
        End Set
    End Property

    Private pDisposal_Donation_hdr_id As Integer
    Public Property Disposal_Donation_hdr_id() As Integer
        Get
            Return pDisposal_Donation_hdr_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_Donation_hdr_id = value
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

    Private pvalue As Decimal
    Public Property value() As Decimal
        Get
            Return pvalue
        End Get
        Set(ByVal value As Decimal)
            pvalue = value
        End Set
    End Property

    Private pProperty_Date As String
    Public Property Property_Date() As String
        Get
            Return pProperty_Date
        End Get
        Set(ByVal value As String)
            pProperty_Date = value
        End Set
    End Property




#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Disposal_Donation_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@Disposal_Donation_hdr_id", Disposal_Donation_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@value", value)
        objDerived.cmd.Parameters.AddWithValue("@Property_Date", Property_Date)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_Disposal_Donation_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
