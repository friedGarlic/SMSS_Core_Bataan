Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class unit_hdr
    Inherits BaseDLL.BaseDAL
#Region "property"
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


#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Unit_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@Description", Description)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_m_unit_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
