Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class m_property
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pProperty_ID As Integer
    Public Property Property_ID() As Integer
        Get
            Return pProperty_ID
        End Get
        Set(ByVal value As Integer)
            pProperty_ID = value
        End Set
    End Property

    Private pProperty_Code As String
    Public Property Property_Code() As String
        Get
            Return pProperty_Code
        End Get
        Set(ByVal value As String)
            pProperty_Code = value
        End Set
    End Property

    Private pDescription As String
    Public Property Description() As String
        Get
            Return pDescription
        End Get
        Set(ByVal value As String)
            pDescription = value
        End Set
    End Property

    Private pUsefulLife As Integer
    Public Property UsefulLife() As Integer
        Get
            Return pUsefulLife
        End Get
        Set(ByVal value As Integer)
            pUsefulLife = value
        End Set
    End Property

    Private pRev_ID As Integer
    Public Property Rev_ID() As Integer
        Get
            Return pRev_ID
        End Get
        Set(ByVal value As Integer)
            pRev_ID = value
        End Set
    End Property


#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Property_Code", Property_Code)
        objDerived.cmd.Parameters.AddWithValue("@Description", Description)
        objDerived.cmd.Parameters.AddWithValue("@UsefulLife", UsefulLife)
        objDerived.cmd.Parameters.AddWithValue("@Rev_ID", Rev_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_m_Property", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
