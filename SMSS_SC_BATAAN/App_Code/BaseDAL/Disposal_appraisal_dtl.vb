Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class Disposal_appraisal_dtl
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pDisposal_appraisal_dtl_id As Integer
    Public Property Disposal_appraisal_dtl_id() As Integer
        Get
            Return pDisposal_appraisal_dtl_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_appraisal_dtl_id = value
        End Set
    End Property

    Private pDisposal_appraisal_hdr_id As Integer
    Public Property Disposal_appraisal_hdr_id() As Integer
        Get
            Return pDisposal_appraisal_hdr_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_appraisal_hdr_id = value
        End Set
    End Property

    Private pDisposal_inspection_dtl_id As Integer
    Public Property Disposal_inspection_dtl_id() As Integer
        Get
            Return pDisposal_inspection_dtl_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_inspection_dtl_id = value
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

    Private pwithBid As Boolean
    Public Property withBid() As Boolean
        Get
            Return pwithBid
        End Get
        Set(ByVal value As Boolean)
            pwithBid = value
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
#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Disposal_appraisal_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@Disposal_appraisal_hdr_id", Disposal_appraisal_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Disposal_inspection_dtl_id", Disposal_inspection_dtl_id)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@withBid", withBid)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Disposal_appraisal_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
