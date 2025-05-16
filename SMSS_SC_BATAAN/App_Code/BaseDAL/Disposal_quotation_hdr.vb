Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class Disposal_quotation_hdr
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pquotation_hdr_id As Integer
    Public Property quotation_hdr_id() As Integer
        Get
            Return pquotation_hdr_id
        End Get
        Set(ByVal value As Integer)
            pquotation_hdr_id = value
        End Set
    End Property

    Private pquotation_date As DateTime
    Public Property quotation_date() As DateTime
        Get
            Return pquotation_date
        End Get
        Set(ByVal value As DateTime)
            pquotation_date = value
        End Set
    End Property

    Private pIscomplete As Boolean
    Public Property Iscomplete() As Boolean
        Get
            Return pIscomplete
        End Get
        Set(ByVal value As Boolean)
            pIscomplete = value
        End Set
    End Property

    Private pwithBID As Boolean
    Public Property withBID() As Boolean
        Get
            Return pwithBID
        End Get
        Set(ByVal value As Boolean)
            pwithBID = value
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

    Private pDisposal_id As Integer
    Public Property Disposal_id() As Integer
        Get
            Return pDisposal_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_id = value
        End Set
    End Property




#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@quotation_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@quotation_date", quotation_date)
        objDerived.cmd.Parameters.AddWithValue("@Iscomplete", Iscomplete)
        objDerived.cmd.Parameters.AddWithValue("@withBID", withBID)
        objDerived.cmd.Parameters.AddWithValue("@IIRUPHdr_ID", IIRUPHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Disposal_id", Disposal_id)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_Disposal_quotation_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
