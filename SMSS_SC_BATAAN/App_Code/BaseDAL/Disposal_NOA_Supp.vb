Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic


Public Class Disposal_NOA_Supp
    Inherits BaseDLL.BaseDAL

#Region "Property"

    Private pNOA_SuppID As Long
    Public Property NOA_SuppID() As Long
        Get
            Return pNOA_SuppID
        End Get
        Set(ByVal value As Long)
            pNOA_SuppID = value
        End Set
    End Property

    Private pNOA_SuppDate As Date
    Public Property NOA_SuppDate() As Date
        Get
            Return pNOA_SuppDate
        End Get
        Set(ByVal value As Date)
            pNOA_SuppDate = value
        End Set
    End Property

    Private pDSupplies_Hdr_ID As Long
    Public Property DSupplies_Hdr_ID() As Long
        Get
            Return pDSupplies_Hdr_ID
        End Get
        Set(ByVal value As Long)
            pDSupplies_Hdr_ID = value
        End Set
    End Property

    Private pApprovedBy As String
    Public Property ApprovedBy() As String
        Get
            Return pApprovedBy
        End Get
        Set(ByVal value As String)
            pApprovedBy = value
        End Set
    End Property

    Private pUserID As String
    Public Property UserID() As String
        Get
            Return pUserID
        End Get
        Set(ByVal value As String)
            pUserID = value
        End Set
    End Property


#End Region


    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@NOA_SuppID", 0)
        objDerived.cmd.Parameters.AddWithValue("@NOA_SuppDate", NOA_SuppDate)
        objDerived.cmd.Parameters.AddWithValue("@DSupplies_Hdr_ID", DSupplies_Hdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[spSave_Disposal_NOA_Supp]", CommandType.StoredProcedure, Nothing)
        Return i
    End Function


    Public Function update() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@NOA_SuppID", NOA_SuppID)
        objDerived.cmd.Parameters.AddWithValue("@NOA_SuppDate", NOA_SuppDate)
        objDerived.cmd.Parameters.AddWithValue("@DSupplies_Hdr_ID", DSupplies_Hdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[spSave_Disposal_NOA_Supp]", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
