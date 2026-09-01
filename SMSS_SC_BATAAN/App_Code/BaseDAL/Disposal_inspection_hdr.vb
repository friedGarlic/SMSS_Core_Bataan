Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.Collections.Generic

Public Class Disposal_inspection_hdr
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pDisposal_inspection_hdr_id As Integer
    Public Property Disposal_inspection_hdr_id() As Integer
        Get
            Return pDisposal_inspection_hdr_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_inspection_hdr_id = value
        End Set
    End Property

    Private pinspection_date As DateTime
    Public Property inspection_date() As DateTime
        Get
            Return pinspection_date
        End Get
        Set(ByVal value As DateTime)
            pinspection_date = value
        End Set
    End Property

    Private pinspector As String
    Public Property inspector() As String
        Get
            Return pinspector
        End Get
        Set(ByVal value As String)
            pinspector = value
        End Set
    End Property

    Private pisAppraisedAll As Boolean
    Public Property isAppraisedAll() As Boolean
        Get
            Return pisAppraisedAll
        End Get
        Set(ByVal value As Boolean)
            pisAppraisedAll = value
        End Set
    End Property

    Private pisCancel As Boolean
    Public Property isCancel() As Boolean
        Get
            Return pisCancel
        End Get
        Set(ByVal value As Boolean)
            pisCancel = value
        End Set
    End Property


#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Disposal_inspection_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@inspection_date", inspection_date)
        objDerived.cmd.Parameters.AddWithValue("@inspector", inspector)
        objDerived.cmd.Parameters.AddWithValue("@isAppraisedAll", isAppraisedAll)
        objDerived.cmd.Parameters.AddWithValue("@isCancel", isCancel)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Disposal_inspection_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
