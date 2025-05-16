Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class Disposal_appraisal_hdr
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pDisposal_appraisal_hdr_id As Integer
    Public Property Disposal_appraisal_hdr_id() As Integer
        Get
            Return pDisposal_appraisal_hdr_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_appraisal_hdr_id = value
        End Set
    End Property

    Private pappraisal_date As DateTime
    Public Property appraisal_date() As DateTime
        Get
            Return pappraisal_date
        End Get
        Set(ByVal value As DateTime)
            pappraisal_date = value
        End Set
    End Property

    Private pappraiser As String
    Public Property appraiser() As String
        Get
            Return pappraiser
        End Get
        Set(ByVal value As String)
            pappraiser = value
        End Set
    End Property


#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Disposal_appraisal_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@appraisal_date", appraisal_date)
        objDerived.cmd.Parameters.AddWithValue("@appraiser", appraiser)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_Disposal_appraisal_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
