Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class item_particular
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

    Private pClassificationID As Integer
    Public Property ClassificationID() As Integer
        Get
            Return pClassificationID
        End Get
        Set(ByVal value As Integer)
            pClassificationID = value
        End Set
    End Property
    Private pSubClassificationID As Integer
    Public Property SubClassificationID() As Integer
        Get
            Return pSubClassificationID
        End Get
        Set(ByVal value As Integer)
            pSubClassificationID = value
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
        objDerived.cmd.Parameters.AddWithValue("@item_particular_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@description", description)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@useful_life", useful_life)
        objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
        objDerived.cmd.Parameters.AddWithValue("@ParticularCode", ParticularCode)
        objDerived.cmd.Parameters.AddWithValue("@ClassificationID", ClassificationID)
        objDerived.cmd.Parameters.AddWithValue("@SubClassificationID", SubClassificationID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_item_particular", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
