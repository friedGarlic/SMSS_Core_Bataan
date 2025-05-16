Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class canvass_negotiated
    '=-= m_Canvass_Hdr
#Region "m_Canvass_Hdr"

    Public Class m_Canvass_Hdr
        Inherits BaseDLL.BaseDAL

        Private pHdr_ID As Long
        Public Property Hdr_ID() As Long
            Get
                Return pHdr_ID
            End Get
            Set(ByVal value As Long)
                pHdr_ID = value
            End Set
        End Property

        Private pCanvass_Date As Date
        Public Property Canvass_Date() As Date
            Get
                Return pCanvass_Date
            End Get
            Set(ByVal value As Date)
                pCanvass_Date = value
            End Set
        End Property

        Private pwithWinner As Boolean
        Public Property withWinner() As Boolean
            Get
                Return pwithWinner
            End Get
            Set(ByVal value As Boolean)
                pwithWinner = value
            End Set
        End Property

        Private pPR_Hdr_ID As Long
        Public Property PR_Hdr_ID() As Long
            Get
                Return pPR_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pPR_Hdr_ID = value
            End Set
        End Property


        Private pisDBM As Boolean
        Public Property isDBM() As Boolean
            Get
                Return pisDBM
            End Get
            Set(ByVal value As Boolean)
                pisDBM = value
            End Set
        End Property

        Private pMOP_NEGO As Long
        Public Property MOP_NEGO() As Long
            Get
                Return pMOP_NEGO
            End Get
            Set(ByVal value As Long)
                pMOP_NEGO = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Hdr_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Canvass_Date", Canvass_Date)
            objDerived.cmd.Parameters.AddWithValue("@withWinner", withWinner)
            objDerived.cmd.Parameters.AddWithValue("@PR_Hdr_ID", PR_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@isDBM", isDBM)
            objDerived.cmd.Parameters.AddWithValue("@MOP_NEGO", MOP_NEGO)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Nego_Hdr]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Hdr_ID", Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Canvass_Date", Canvass_Date)
            objDerived.cmd.Parameters.AddWithValue("@withWinner", withWinner)
            objDerived.cmd.Parameters.AddWithValue("@PR_Hdr_ID", PR_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@isDBM", isDBM)
            objDerived.cmd.Parameters.AddWithValue("@MOP_NEGO", MOP_NEGO)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Nego_Hdr]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region
End Class
