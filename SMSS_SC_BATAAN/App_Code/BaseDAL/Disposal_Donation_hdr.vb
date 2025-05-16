Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class Disposal_Donation_hdr
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pDisposal_Donation_hdr_id As Integer
    Public Property Disposal_Donation_hdr_id() As Integer
        Get
            Return pDisposal_Donation_hdr_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_Donation_hdr_id = value
        End Set
    End Property

    Private pDisposa_date As DateTime
    Public Property Disposa_date() As DateTime
        Get
            Return pDisposa_date
        End Get
        Set(ByVal value As DateTime)
            pDisposa_date = value
        End Set
    End Property

    Private pTransTo As String
    Public Property TransTo() As String
        Get
            Return pTransTo
        End Get
        Set(ByVal value As String)
            pTransTo = value
        End Set
    End Property

    Private pRAO As String
    Public Property RAO() As String
        Get
            Return pRAO
        End Get
        Set(ByVal value As String)
            pRAO = value
        End Set
    End Property

    Private pAuthorizedBy As String
    Public Property AuthorizedBy() As String
        Get
            Return pAuthorizedBy
        End Get
        Set(ByVal value As String)
            pAuthorizedBy = value
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



#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Disposal_Donation_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@Disposa_date", Disposa_date)
        objDerived.cmd.Parameters.AddWithValue("@TransTo", TransTo)
        objDerived.cmd.Parameters.AddWithValue("@RAO", RAO)
        objDerived.cmd.Parameters.AddWithValue("@AuthorizedBy", AuthorizedBy)
        objDerived.cmd.Parameters.AddWithValue("@IIRUPHdr_ID", IIRUPHdr_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_Disposal_Donation_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
