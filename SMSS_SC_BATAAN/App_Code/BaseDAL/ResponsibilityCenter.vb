Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class ResponsibilityCenter
    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private prc_id As Integer
    Public Property rc_id() As Integer
        Get
            Return prc_id
        End Get
        Set(ByVal value As Integer)
            prc_id = value
        End Set
    End Property

    Private prc_code As String
    Public Property rc_code() As String
        Get
            Return prc_code
        End Get
        Set(ByVal value As String)
            prc_code = value
        End Set
    End Property

    Private prc_name As String
    Public Property rc_name() As String
        Get
            Return prc_name
        End Get
        Set(ByVal value As String)
            prc_name = value
        End Set
    End Property

    Private phead As String
    Public Property head() As String
        Get
            Return phead
        End Get
        Set(ByVal value As String)
            phead = value
        End Set
    End Property


   

#End Region

    

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@rc_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@rc_code", rc_code)
        objDerived.cmd.Parameters.AddWithValue("@rc_name", rc_name)
        objDerived.cmd.Parameters.AddWithValue("@head", head)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_Resp_Center", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
