Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Public Class t_Purchase_request_disbursement
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pDisbursementID As Long
    Public Property DisbursementID() As Long
        Get
            Return pDisbursementID
        End Get
        Set(ByVal value As Long)
            pDisbursementID = value
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

    Private pID As Long
    Public Property ID() As Long
        Get
            Return pID
        End Get
        Set(ByVal value As Long)
            pID = value
        End Set
    End Property




#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@DisbursementID", 0)
        objDerived.cmd.Parameters.AddWithValue("@OBR_Hdr_ID", OBR_Hdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@ID", ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_DisbursementTransaction", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
