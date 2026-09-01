Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class t_ppmp_contingency
    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pCont_ID As Long
    Public Property Cont_ID() As Long
        Get
            Return pCont_ID
        End Get
        Set(ByVal value As Long)
            pCont_ID = value
        End Set
    End Property

    Private pYear As Integer
    Public Property Year() As Integer
        Get
            Return pYear
        End Get
        Set(ByVal value As Integer)
            pYear = value
        End Set
    End Property

    Private pRC_ID As Long
    Public Property RC_ID() As Long
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Long)
            pRC_ID = value
        End Set
    End Property

    Private pFunction_ID As Long
    Public Property Function_ID() As Long
        Get
            Return pFunction_ID
        End Get
        Set(ByVal value As Long)
            pFunction_ID = value
        End Set
    End Property

    Private pGA_ID As Long
    Public Property GA_ID() As Long
        Get
            Return pGA_ID
        End Get
        Set(ByVal value As Long)
            pGA_ID = value
        End Set
    End Property

    Private pBGA_ID As Long
    Public Property BGA_ID() As Long
        Get
            Return pBGA_ID
        End Get
        Set(ByVal value As Long)
            pBGA_ID = value
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

    Private pFirstQtr As Decimal
    Public Property FirstQtr() As Decimal
        Get
            Return pFirstQtr
        End Get
        Set(ByVal value As Decimal)
            pFirstQtr = value
        End Set
    End Property

    Private pSecondQtr As Decimal
    Public Property SecondQtr() As Decimal
        Get
            Return pSecondQtr
        End Get
        Set(ByVal value As Decimal)
            pSecondQtr = value
        End Set
    End Property

    Private pThirdQtr As Decimal
    Public Property ThirdQtr() As Decimal
        Get
            Return pThirdQtr
        End Get
        Set(ByVal value As Decimal)
            pThirdQtr = value
        End Set
    End Property

    Private pFourthQtr As Decimal
    Public Property FourthQtr() As Decimal
        Get
            Return pFourthQtr
        End Get
        Set(ByVal value As Decimal)
            pFourthQtr = value
        End Set
    End Property


    Private pPreparedBy As String
    Public Property PreparedBy() As String
        Get
            Return pPreparedBy
        End Get
        Set(ByVal value As String)
            pPreparedBy = value
        End Set
    End Property

    Private pPreparedBy_Pos As String
    Public Property PreparedBy_Pos() As String
        Get
            Return pPreparedBy_Pos
        End Get
        Set(ByVal value As String)
            pPreparedBy_Pos = value
        End Set
    End Property

    Private pReviewedBy As String
    Public Property ReviewedBy() As String
        Get
            Return pReviewedBy
        End Get
        Set(ByVal value As String)
            pReviewedBy = value
        End Set
    End Property

    Private pReviewedBy_Pos As String
    Public Property ReviewedBy_Pos() As String
        Get
            Return pReviewedBy_Pos
        End Get
        Set(ByVal value As String)
            pReviewedBy_Pos = value
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
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Cont_ID", Cont_ID)
        objDerived.cmd.Parameters.AddWithValue("@Year", Year)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
        objDerived.cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount)
        objDerived.cmd.Parameters.AddWithValue("@FirstQtr", FirstQtr)
        objDerived.cmd.Parameters.AddWithValue("@SecondQtr", SecondQtr)
        objDerived.cmd.Parameters.AddWithValue("@ThirdQtr", ThirdQtr)
        objDerived.cmd.Parameters.AddWithValue("@FourthQtr", FourthQtr)
        objDerived.cmd.Parameters.AddWithValue("@PreparedBy", PreparedBy)
        objDerived.cmd.Parameters.AddWithValue("@PreparedBy_Pos", PreparedBy_Pos)
        objDerived.cmd.Parameters.AddWithValue("@ReviewedBy", ReviewedBy)
        objDerived.cmd.Parameters.AddWithValue("@ReviewedBy_Pos", ReviewedBy_Pos)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[spSave_ppmp_contingency]", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Cont_ID", Cont_ID)
        objDerived.cmd.Parameters.AddWithValue("@Year", Year)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
        objDerived.cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount)
        objDerived.cmd.Parameters.AddWithValue("@FirstQtr", FirstQtr)
        objDerived.cmd.Parameters.AddWithValue("@SecondQtr", SecondQtr)
        objDerived.cmd.Parameters.AddWithValue("@ThirdQtr", ThirdQtr)
        objDerived.cmd.Parameters.AddWithValue("@FourthQtr", FourthQtr)
        objDerived.cmd.Parameters.AddWithValue("@PreparedBy", PreparedBy)
        objDerived.cmd.Parameters.AddWithValue("@PreparedBy_Pos", PreparedBy_Pos)
        objDerived.cmd.Parameters.AddWithValue("@ReviewedBy", ReviewedBy)
        objDerived.cmd.Parameters.AddWithValue("@ReviewedBy_Pos", ReviewedBy_Pos)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[spSave_ppmp_contingency]", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
