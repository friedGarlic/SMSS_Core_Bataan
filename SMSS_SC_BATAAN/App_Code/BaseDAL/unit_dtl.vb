
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Public Class unit_dtl
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pUnit_ID As Integer
    Public Property Unit_ID() As Integer
        Get
            Return pUnit_ID
        End Get
        Set(ByVal value As Integer)
            pUnit_ID = value
        End Set
    End Property

    Private pUnit_hdr_id As Integer
    Public Property Unit_hdr_id() As Integer
        Get
            Return pUnit_hdr_id
        End Get
        Set(ByVal value As Integer)
            pUnit_hdr_id = value
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

    Private pUnit_hdr_id2 As Integer
    Public Property Unit_hdr_id2() As Integer
        Get
            Return pUnit_hdr_id2
        End Get
        Set(ByVal value As Integer)
            pUnit_hdr_id2 = value
        End Set
    End Property

    Private pvalue As Integer
    Public Property value() As Integer
        Get
            Return pvalue
        End Get
        Set(ByVal value As Integer)
            pvalue = value
        End Set
    End Property


#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Unit_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Unit_hdr_id", Unit_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Description", Description)
        objDerived.cmd.Parameters.AddWithValue("@Unit_hdr_id2", Unit_hdr_id2)
        objDerived.cmd.Parameters.AddWithValue("@value", value)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_m_Unit", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
