Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Drawing.Imaging

Public Class Image
    Inherits BaseDLL.BaseDAL

#Region "properties"
    Private pIssuance_ID As Integer
    Public Property Issuance_ID() As Integer
        Get
            Return pIssuance_ID
        End Get
        Set(ByVal value As Integer)
            pIssuance_ID = value
        End Set
    End Property

    Private pDocuID As Integer
    Public Property DocuID() As Integer
        Get
            Return pDocuID
        End Get
        Set(ByVal value As Integer)
            pDocuID = value
        End Set
    End Property

    Private pItem_ID As Integer
    Public Property Item_ID() As Integer
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Integer)
            pItem_ID = value
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

    Private pImageFile As Byte()
    Public Property ImageFile() As Byte()
        Get
            Return pImageFile
        End Get
        Set(ByVal value As Byte())
            pImageFile = value
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

    Private pPropertyNo As String
    Public Property PropertyNo() As String
        Get
            Return pPropertyNo
        End Get
        Set(ByVal value As String)
            pPropertyNo = value
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

    Private pDateValidated As Date
    Public Property DateValidated() As Date
        Get
            Return pDateValidated
        End Get
        Set(ByVal value As Date)
            pDateValidated = value
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
        objDerived.cmd.Parameters.AddWithValue("@Issuance_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@DocuID", DocuID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@ImageFile", ImageFile)
        objDerived.cmd.Parameters.AddWithValue("@DocumentName", DocumentName)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@ValidatedBy", ValidatedBy)
        objDerived.cmd.Parameters.AddWithValue("@DateValidated", DateValidated)
        objDerived.cmd.Parameters.AddWithValue("@TableName", TableName)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_IssuanceAttch", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Sub Save(ms As MemoryStream, jpeg As ImageFormat)
        Throw New NotImplementedException()
    End Sub
End Class
