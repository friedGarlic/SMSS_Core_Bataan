Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class item_classification
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pitem_classification_id As Integer
    Public Property item_classification_id() As Integer
        Get
            Return pitem_classification_id
        End Get
        Set(ByVal value As Integer)
            pitem_classification_id = value
        End Set
    End Property

    Private pcode As String
    Public Property code() As String
        Get
            Return pcode
        End Get
        Set(ByVal value As String)
            pcode = value
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

    Private pisProperty As Boolean
    Public Property isProperty() As Boolean
        Get
            Return pisProperty
        End Get
        Set(ByVal value As Boolean)
            pisProperty = value
        End Set
    End Property

    Private pgroupid As Integer
    Public Property groupid() As Integer
        Get
            Return pgroupid
        End Get
        Set(ByVal value As Integer)
            pgroupid = value
        End Set
    End Property

    Private paccntg_code As Integer
    Public Property accntg_code() As Integer
        Get
            Return paccntg_code
        End Get
        Set(ByVal value As Integer)
            paccntg_code = value
        End Set
    End Property

    Private paccntg_code_partner As Integer
    Public Property accntg_code_partner() As Integer
        Get
            Return paccntg_code_partner
        End Get
        Set(ByVal value As Integer)
            paccntg_code_partner = value
        End Set
    End Property


#End Region

    Public Sub save()
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@item_classification_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@code", code)
        objDerived.cmd.Parameters.AddWithValue("@description", description)
        objDerived.cmd.Parameters.AddWithValue("@isProperty", isProperty)
        objDerived.cmd.Parameters.AddWithValue("@groupid", groupid)
        objDerived.cmd.Parameters.AddWithValue("@accntg_code", accntg_code)
        objDerived.cmd.Parameters.AddWithValue("@accntg_code_partner", accntg_code_partner)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_item_classification", CommandType.StoredProcedure, Nothing)
        'Return i
    End Sub
End Class
