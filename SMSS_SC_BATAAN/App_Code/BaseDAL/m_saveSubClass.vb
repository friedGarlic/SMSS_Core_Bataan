Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class m_SubClass
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pitem_particular_id As Long
    Public Property item_particular_id() As Long
        Get
            Return pitem_particular_id
        End Get
        Set(ByVal value As Long)
            pitem_particular_id = value
        End Set
    End Property

    Private pSubClassificationName As Integer
    Public Property SubClassificationName() As Integer
        Get
            Return pSubClassificationName
        End Get
        Set(ByVal value As Integer)
            pSubClassificationName = value
        End Set
    End Property

    Private pClassificationId As Integer
    Public Property ClassificationId() As Integer
        Get
            Return pClassificationId
        End Get
        Set(ByVal value As Integer)
            pClassificationId = value
        End Set
    End Property


    Private pClassificationName As Integer
    Public Property ClassificationName() As Integer
        Get
            Return pClassificationName
        End Get
        Set(ByVal value As Integer)
            pClassificationName = value
        End Set
    End Property

    Private pdescription As String
    Public Property description() As String
        Get
            Return pdescription
        End Get
        Set(ByVal value As String)
            pdescription = value
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

    Private puseful_life As Integer
    Public Property useful_life() As Integer
        Get
            Return puseful_life
        End Get
        Set(ByVal value As Integer)
            puseful_life = value
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

    Private pParticularCode As String
    Public Property ParticularCode() As String
        Get
            Return pParticularCode
        End Get
        Set(ByVal value As String)
            pParticularCode = value
        End Set
    End Property



#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ClassificationID", ClassificationId)
        objDerived.cmd.Parameters.AddWithValue("@ClassificationName", ClassificationName)
        objDerived.cmd.Parameters.AddWithValue("@SubClassificationName", SubClassificationName)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_SubClass", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
