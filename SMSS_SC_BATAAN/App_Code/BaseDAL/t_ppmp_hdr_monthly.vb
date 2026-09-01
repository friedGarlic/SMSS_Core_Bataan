Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class t_ppmp_hdr_monthly
    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pppmp_hdr_id As Long
    Public Property ppmp_hdr_id() As Long
        Get
            Return pppmp_hdr_id
        End Get
        Set(ByVal value As Long)
            pppmp_hdr_id = value
        End Set
    End Property

    Private pCYear As Integer
    Public Property CYear() As Integer
        Get
            Return pCYear
        End Get
        Set(ByVal value As Integer)
            pCYear = value
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

    Private pFunction_ID As Integer
    Public Property Function_ID() As Integer
        Get
            Return pFunction_ID
        End Get
        Set(ByVal value As Integer)
            pFunction_ID = value
        End Set
    End Property

    Private pProject_ID As Integer
    Public Property Project_ID() As Integer
        Get
            Return pProject_ID
        End Get
        Set(ByVal value As Integer)
            pProject_ID = value
        End Set
    End Property

    Private pProgram_id As Integer
    Public Property Program_id() As Integer
        Get
            Return pProgram_id
        End Get
        Set(ByVal value As Integer)
            pProgram_id = value
        End Set
    End Property

    Private pGA_ID As Integer
    Public Property GA_ID() As Integer
        Get
            Return pGA_ID
        End Get
        Set(ByVal value As Integer)
            pGA_ID = value
        End Set
    End Property

    Private pBGA_ID As Integer
    Public Property BGA_ID() As Integer
        Get
            Return pBGA_ID
        End Get
        Set(ByVal value As Integer)
            pBGA_ID = value
        End Set
    End Property

    Private ppDate As DateTime
    Public Property pDate() As DateTime
        Get
            Return ppDate
        End Get
        Set(ByVal value As DateTime)
            ppDate = value
        End Set
    End Property

    Private pfirstqtr As Boolean
    Public Property firstqtr() As Boolean
        Get
            Return pfirstqtr
        End Get
        Set(ByVal value As Boolean)
            pfirstqtr = value
        End Set
    End Property

    Private psecondqrt As Boolean
    Public Property secondqrt() As Boolean
        Get
            Return psecondqrt
        End Get
        Set(ByVal value As Boolean)
            psecondqrt = value
        End Set
    End Property

    Private pthirdqtr As Boolean
    Public Property thirdqtr() As Boolean
        Get
            Return pthirdqtr
        End Get
        Set(ByVal value As Boolean)
            pthirdqtr = value
        End Set
    End Property

    Private pfourthqrt As Boolean
    Public Property fourthqrt() As Boolean
        Get
            Return pfourthqrt
        End Get
        Set(ByVal value As Boolean)
            pfourthqrt = value
        End Set
    End Property

    Private pPreparedBy As Integer
    Public Property PreparedBy() As Integer
        Get
            Return pPreparedBy
        End Get
        Set(ByVal value As Integer)
            pPreparedBy = value
        End Set
    End Property

    Private pReviewedBy As Integer
    Public Property ReviewedBy() As Integer
        Get
            Return pReviewedBy
        End Get
        Set(ByVal value As Integer)
            pReviewedBy = value
        End Set
    End Property

    Private pApprovedBy As Integer
    Public Property ApprovedBy() As Integer
        Get
            Return pApprovedBy
        End Get
        Set(ByVal value As Integer)
            pApprovedBy = value
        End Set
    End Property

    Private pRecommendedBy As Integer
    Public Property RecommendedBy() As Integer
        Get
            Return pRecommendedBy
        End Get
        Set(ByVal value As Integer)
            pRecommendedBy = value
        End Set
    End Property




    Private pisforRevision As Boolean
    Public Property isforRevision() As Boolean
        Get
            Return pisforRevision
        End Get
        Set(ByVal value As Boolean)
            pisforRevision = value
        End Set
    End Property

    Private pisContinuing As Boolean
    Public Property isContinuing() As Boolean
        Get
            Return pisContinuing
        End Get
        Set(ByVal value As Boolean)
            pisContinuing = value
        End Set
    End Property

    Private pisSupplemental As Boolean
    Public Property isSupplemental() As Boolean
        Get
            Return pisSupplemental
        End Get
        Set(ByVal value As Boolean)
            pisSupplemental = value
        End Set
    End Property

    Private pmode_of_procurement As Integer
    Public Property mode_of_procurement() As Integer
        Get
            Return pmode_of_procurement
        End Get
        Set(ByVal value As Integer)
            pmode_of_procurement = value
        End Set
    End Property

    Private pisfinal As Boolean
    Public Property isfinal() As Boolean
        Get
            Return pisfinal
        End Get
        Set(ByVal value As Boolean)
            pisfinal = value
        End Set
    End Property

    Private papp_id As Long
    Public Property app_id() As Long
        Get
            Return papp_id
        End Get
        Set(ByVal value As Long)
            papp_id = value
        End Set
    End Property


    Private pUserid As String
    Public Property Userid() As String
        Get
            Return pUserid
        End Get
        Set(ByVal value As String)
            pUserid = value
        End Set
    End Property

    'Private pisConstructionMaterials As Boolean
    'Public Property isConstructionMaterials() As Boolean
    '    Get
    '        Return pisConstructionMaterials
    '    End Get
    '    Set(ByVal value As Boolean)
    '        pisConstructionMaterials = value
    '    End Set
    'End Property

#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ppmp_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@CYear", CYear)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
        objDerived.cmd.Parameters.AddWithValue("@Program_id", Program_id)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
        objDerived.cmd.Parameters.AddWithValue("@pDate", pDate)
        objDerived.cmd.Parameters.AddWithValue("@firstqtr", firstqtr)
        objDerived.cmd.Parameters.AddWithValue("@secondqrt", secondqrt)
        objDerived.cmd.Parameters.AddWithValue("@thirdqtr", thirdqtr)
        objDerived.cmd.Parameters.AddWithValue("@fourthqrt", fourthqrt)
        objDerived.cmd.Parameters.AddWithValue("@PreparedBy", PreparedBy)
        objDerived.cmd.Parameters.AddWithValue("@ReviewedBy", ReviewedBy)
        objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)
        objDerived.cmd.Parameters.AddWithValue("@RecommendedBy", RecommendedBy)
        objDerived.cmd.Parameters.AddWithValue("@isforRevision", isforRevision)
        objDerived.cmd.Parameters.AddWithValue("@isContinuing", isContinuing)
        objDerived.cmd.Parameters.AddWithValue("@isSupplemental", isSupplemental)
        objDerived.cmd.Parameters.AddWithValue("@mode_of_procurement", mode_of_procurement)
        objDerived.cmd.Parameters.AddWithValue("@isfinal", isfinal)
        objDerived.cmd.Parameters.AddWithValue("@app_id", app_id)
        objDerived.cmd.Parameters.AddWithValue("@Userid", Userid)
        'objDerived.cmd.Parameters.AddWithValue("@isConstructionMaterials", isConstructionMaterials)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_ppmp_hdr_New", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ppmp_hdr_id", ppmp_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@CYear", CYear)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
        objDerived.cmd.Parameters.AddWithValue("@Program_id", Program_id)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
        objDerived.cmd.Parameters.AddWithValue("@pDate", pDate)
        objDerived.cmd.Parameters.AddWithValue("@firstqtr", firstqtr)
        objDerived.cmd.Parameters.AddWithValue("@secondqrt", secondqrt)
        objDerived.cmd.Parameters.AddWithValue("@thirdqtr", thirdqtr)
        objDerived.cmd.Parameters.AddWithValue("@fourthqrt", fourthqrt)
        objDerived.cmd.Parameters.AddWithValue("@PreparedBy", PreparedBy)
        objDerived.cmd.Parameters.AddWithValue("@ReviewedBy", ReviewedBy)
        objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)
        objDerived.cmd.Parameters.AddWithValue("@RecommendedBy", RecommendedBy)
        objDerived.cmd.Parameters.AddWithValue("@isforRevision", isforRevision)
        objDerived.cmd.Parameters.AddWithValue("@isContinuing", isContinuing)
        objDerived.cmd.Parameters.AddWithValue("@isSupplemental", isSupplemental)
        objDerived.cmd.Parameters.AddWithValue("@mode_of_procurement", mode_of_procurement)
        objDerived.cmd.Parameters.AddWithValue("@isfinal", isfinal)
        objDerived.cmd.Parameters.AddWithValue("@app_id", app_id)
        objDerived.cmd.Parameters.AddWithValue("@Userid", Userid)
        'objDerived.cmd.Parameters.AddWithValue("@isConstructionMaterials", isConstructionMaterials)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_ppmp_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
