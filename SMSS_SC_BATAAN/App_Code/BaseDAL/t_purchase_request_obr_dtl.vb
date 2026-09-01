Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class t_purchase_request_obr_dtl
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pOBR_Dtl_ID As Long
    Public Property OBR_Dtl_ID() As Long
        Get
            Return pOBR_Dtl_ID
        End Get
        Set(ByVal value As Long)
            pOBR_Dtl_ID = value
        End Set
    End Property

    Private pOBR_Hdr_ID As Long
    Public Property OBR_Hdr_ID() As Long
        Get
            Return pOBR_Hdr_ID
        End Get
        Set(ByVal value As Long)
            pOBR_Hdr_ID = value
        End Set
    End Property

    Private pRC_ID As Long
    Public Property RC_ID() As Long
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Long)
            pRC_ID = value
        End Set
    End Property

    Private pFunction_ID As Long
    Public Property Function_ID() As Long
        Get
            Return pFunction_ID
        End Get
        Set(ByVal value As Long)
            pFunction_ID = value
        End Set
    End Property

    Private pProgram_ID As Long
    Public Property Program_ID() As Long
        Get
            Return pProgram_ID
        End Get
        Set(ByVal value As Long)
            pProgram_ID = value
        End Set
    End Property

    Private pProject_ID As Long
    Public Property Project_ID() As Long
        Get
            Return pProject_ID
        End Get
        Set(ByVal value As Long)
            pProject_ID = value
        End Set
    End Property

    Private pGA_ID As Long
    Public Property GA_ID() As Long
        Get
            Return pGA_ID
        End Get
        Set(ByVal value As Long)
            pGA_ID = value
        End Set
    End Property

    Private pAmount As Decimal
    Public Property Amount() As Decimal
        Get
            Return pAmount
        End Get
        Set(ByVal value As Decimal)
            pAmount = value
        End Set
    End Property

    Private pAllotmentClass_ID As Long
    Public Property AllotmentClass_ID() As Long
        Get
            Return pAllotmentClass_ID
        End Get
        Set(ByVal value As Long)
            pAllotmentClass_ID = value
        End Set
    End Property

    Private pBGA_ID As Long
    Public Property BGA_ID() As Long
        Get
            Return pBGA_ID
        End Get
        Set(ByVal value As Long)
            pBGA_ID = value
        End Set
    End Property
    Private pparticulars As String
    Public Property particulars() As String
        Get
            Return pparticulars
        End Get
        Set(ByVal value As String)
            pparticulars = value
        End Set
    End Property

#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@OBR_Dtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@OBR_Hdr_ID", OBR_Hdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@particulars", particulars)
        objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)

        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@Program_ID", Program_ID)
        objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@Amount", Amount)
        objDerived.cmd.Parameters.AddWithValue("@AllotmentClass_ID", AllotmentClass_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.BOS.spSave_T_CAA_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
