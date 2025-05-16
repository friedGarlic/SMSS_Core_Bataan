Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class ImageDocument
    Inherits BaseDLL.BaseDAL
#Region "ImagePropoerty"


    Private pDocuID As Integer
    Public Property DocuID() As Integer
        Get
            Return pDocuID
        End Get
        Set(ByVal value As Integer)
            pDocuID = value
        End Set
    End Property

    Private pIdentityNo As Integer
    Public Property IdentityNo() As Integer
        Get
            Return pIdentityNo
        End Get
        Set(ByVal value As Integer)
            pIdentityNo = value
        End Set
    End Property

    Private pPropertyDetai_ID As Integer
    Public Property PropertyDetai_ID() As Integer
        Get
            Return pPropertyDetai_ID
        End Get
        Set(ByVal value As Integer)
            pPropertyDetai_ID = value
        End Set
    End Property

    Private pImagefile As Byte()
    Public Property Imagefile() As Byte()
        Get
            Return pImagefile
        End Get
        Set(ByVal value As Byte())
            pImagefile = value
        End Set
    End Property

    Private pDocumentName As String
    Public Property DocumentName() As String
        Get
            Return pDocumentName
        End Get
        Set(ByVal value As String)
            pDocumentName = value
        End Set
    End Property

    Private pDocumentNo As String
    Public Property DocumentNo() As String
        Get
            Return pDocumentNo
        End Get
        Set(ByVal value As String)
            pDocumentNo = value
        End Set
    End Property

    Private pValidatedBy As String
    Public Property ValidatedBy() As String
        Get
            Return pValidatedBy
        End Get
        Set(ByVal value As String)
            pValidatedBy = value
        End Set
    End Property

    Private pDateValidated As DateTime
    Public Property DateValidated() As DateTime
        Get
            Return pDateValidated
        End Get
        Set(ByVal value As DateTime)
            pDateValidated = value
        End Set
    End Property


    Private pRemarks As String
    Public Property Remarks() As String
        Get
            Return pRemarks
        End Get
        Set(ByVal value As String)
            pRemarks = value
        End Set
    End Property


    Private pTableName As String
    Public Property TableName() As String
        Get
            Return pTableName
        End Get
        Set(ByVal value As String)
            pTableName = value
        End Set
    End Property



#End Region
    Public Function SaveImage() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@DocuId", 0)
        objDerived.cmd.Parameters.AddWithValue("@IdentityNo", IdentityNo)
        objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", PropertyDetai_ID)
        objDerived.cmd.Parameters.AddWithValue("@ImageFile", Imagefile)
        objDerived.cmd.Parameters.AddWithValue("@DocumentName", DocumentName)
        objDerived.cmd.Parameters.AddWithValue("@DocumentNo", DocumentNo)
        objDerived.cmd.Parameters.AddWithValue("@ValidatedBy", ValidatedBy)
        objDerived.cmd.Parameters.AddWithValue("@DateValidated", DateValidated)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@TableName", TableName)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_IMAGE_AttachDoc", CommandType.StoredProcedure, Nothing)

        Return i


    End Function

    Public Function UpdateImage() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@DocuId", DocuID)
        objDerived.cmd.Parameters.AddWithValue("@IdentityNo", IdentityNo)
        objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", PropertyDetai_ID)
        objDerived.cmd.Parameters.AddWithValue("@ImageFile", Imagefile)
        objDerived.cmd.Parameters.AddWithValue("@DocumentName", DocumentName)
        objDerived.cmd.Parameters.AddWithValue("@DocumentNo", DocumentNo)
        objDerived.cmd.Parameters.AddWithValue("@ValidatedBy", ValidatedBy)
        objDerived.cmd.Parameters.AddWithValue("@DateValidated", DateValidated)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@TableName", TableName)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_IMAGE_AttachDoc", CommandType.StoredProcedure, Nothing)

        Return i


    End Function
End Class
