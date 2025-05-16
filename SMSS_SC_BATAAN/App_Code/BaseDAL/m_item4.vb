Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class m_itemNoSubClassNoSubcat
    Inherits BaseDLL.BaseDAL
#Region "property"

    Private pAttachedFile As String
    Public Property AttachedFile() As String
        Get
            Return pAttachedFile
        End Get
        Set(ByVal value As String)
            pAttachedFile = value
        End Set
    End Property

    Private pAttachedF As Byte()
    Public Property AttachedF() As Byte()
        Get
            Return pAttachedF
        End Get
        Set(ByVal value As Byte())
            pAttachedF = value
        End Set
    End Property

    Private pItem_ID As Long
    Public Property Item_ID() As Long
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Long)
            pItem_ID = value
        End Set
    End Property

    Private pBrand As String
    Public Property Brand() As String
        Get
            Return pBrand
        End Get
        Set(ByVal value As String)
            pBrand = value
        End Set
    End Property

    Private pGenericName As String
    Public Property GenericName() As String
        Get
            Return pGenericName
        End Get
        Set(ByVal value As String)
            pGenericName = value
        End Set
    End Property

    Private pColor As String
    Public Property Color() As String
        Get
            Return pColor
        End Get
        Set(ByVal value As String)
            pColor = value
        End Set
    End Property
    Private pSize As String
    Public Property Size() As String
        Get
            Return pSize
        End Get
        Set(ByVal value As String)
            pSize = value
        End Set
    End Property
    Private pItem_Code As String
    Public Property Item_Code() As String
        Get
            Return pItem_Code
        End Get
        Set(ByVal value As String)
            pItem_Code = value
        End Set
    End Property

    Private pItem_Desc As String
    Public Property Item_Desc() As String
        Get
            Return pItem_Desc
        End Get
        Set(ByVal value As String)
            pItem_Desc = value
        End Set
    End Property

    Private pUnit_ID As Integer
    Public Property Unit_ID() As Integer
        Get
            Return pUnit_ID
        End Get
        Set(ByVal value As Integer)
            pUnit_ID = value
        End Set
    End Property

    Private pitem_particular_id As Integer
    Public Property item_particular_id() As Integer
        Get
            Return pitem_particular_id
        End Get
        Set(ByVal value As Integer)
            pitem_particular_id = value
        End Set
    End Property

    Private pSubCategoryId As Integer
    Public Property SubCategoryId() As Integer
        Get
            Return pSubCategoryId
        End Get
        Set(ByVal value As Integer)
            pSubCategoryId = value
        End Set
    End Property

    Private pSubClassificationId As Integer
    Public Property SubClassificationId() As Integer
        Get
            Return pSubClassificationId
        End Get
        Set(ByVal value As Integer)
            pSubClassificationId = value
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
    Private pRC_ID As Integer
    Public Property RC_ID() As Integer
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Integer)
            pRC_ID = value
        End Set
    End Property

    Private pisAll As Boolean
    Public Property isAll() As Boolean
        Get
            Return pisAll
        End Get
        Set(ByVal value As Boolean)
            pisAll = value
        End Set
    End Property

    'Added 1/22/2013
    Private pisUsed As Boolean
    Public Property isUsed() As Boolean
        Get
            Return pisUsed
        End Get
        Set(ByVal value As Boolean)
            pisUsed = value
        End Set
    End Property
    'Added 1/22/2013


    Private pdetail As String
    Public Property detail() As String
        Get
            Return pdetail
        End Get
        Set(ByVal value As String)
            pdetail = value
        End Set
    End Property

    Private pDepRate As Decimal
    Public Property DepRate() As Decimal
        Get
            Return pDepRate
        End Get
        Set(ByVal value As Decimal)
            pDepRate = value
        End Set
    End Property
    Private pDepYear As Decimal
    Public Property DepYear() As Decimal
        Get
            Return pDepYear
        End Get
        Set(ByVal value As Decimal)
            pDepYear = value
        End Set
    End Property
#End Region


    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Item_Code", Item_Code)
        objDerived.cmd.Parameters.AddWithValue("@Item_Desc", Item_Desc)
        If Brand <> Nothing Then
            objDerived.cmd.Parameters.AddWithValue("@Brand", Brand)
        Else

        End If
        If Color <> Nothing Then
            objDerived.cmd.Parameters.AddWithValue("@Color", Color)
        Else

        End If
        If Size <> Nothing Then
            objDerived.cmd.Parameters.AddWithValue("@Size", Size)
        Else

        End If
        objDerived.cmd.Parameters.AddWithValue("@DepRate", DepRate)
        objDerived.cmd.Parameters.AddWithValue("@DepYear", DepYear)
        objDerived.cmd.Parameters.AddWithValue("@Unit_ID", Unit_ID)
        objDerived.cmd.Parameters.AddWithValue("@item_particular_id", item_particular_id)
        objDerived.cmd.Parameters.AddWithValue("@ClassificationID", ClassificationID)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@isAll", isAll)
        objDerived.cmd.Parameters.AddWithValue("@detail", detail)
        objDerived.cmd.Parameters.AddWithValue("@isUsed", isUsed)
        objDerived.cmd.Parameters.AddWithValue("@GenericName", GenericName)
        'objDerived.cmd.Parameters.AddWithValue("@AttachedFile", AttachedFile)
        'objDerived.cmd.Parameters.AddWithValue("@AttachedF", AttachedF)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_m_item4", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function saveEditItem() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Item_Code", Item_Code)
        objDerived.cmd.Parameters.AddWithValue("@Item_Desc", Item_Desc)
        objDerived.cmd.Parameters.AddWithValue("@Brand", Brand)
        objDerived.cmd.Parameters.AddWithValue("@Color", Color)
        objDerived.cmd.Parameters.AddWithValue("@Size", Size)
        objDerived.cmd.Parameters.AddWithValue("@DepRate", DepRate)
        objDerived.cmd.Parameters.AddWithValue("@DepYear", DepYear)
        objDerived.cmd.Parameters.AddWithValue("@Unit_ID", Unit_ID)
        objDerived.cmd.Parameters.AddWithValue("@item_particular_id", item_particular_id)
        objDerived.cmd.Parameters.AddWithValue("@ClassificationID", ClassificationID)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@isAll", isAll)
        objDerived.cmd.Parameters.AddWithValue("@detail", detail)
        objDerived.cmd.Parameters.AddWithValue("@isUsed", isUsed)
        objDerived.cmd.Parameters.AddWithValue("@GenericName", GenericName)
        'objDerived.cmd.Parameters.AddWithValue("@AttachedFile", AttachedFile)
        'objDerived.cmd.Parameters.AddWithValue("@AttachedF", AttachedF)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_m_item4", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
