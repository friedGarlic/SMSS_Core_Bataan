Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Namespace Returned_History


    'EQUIPMENTS
#Region "ARE_Returned_History_Hdr"

    Public Class ARE_Returned_History_Hdr
        Inherits BaseDLL.BaseDAL

        Private pReturned_ID As Long
        Public Property Returned_ID() As Long
            Get
                Return pReturned_ID
            End Get
            Set(ByVal value As Long)
                pReturned_ID = value
            End Set
        End Property

        Private pReturned_To As Long
        Public Property Returned_To() As Long
            Get
                Return pReturned_To
            End Get
            Set(ByVal value As Long)
                pReturned_To = value
            End Set
        End Property

        Private pReturned_By As Long
        Public Property Returned_By() As Long
            Get
                Return pReturned_By
            End Get
            Set(ByVal value As Long)
                pReturned_By = value
            End Set
        End Property

        Private pReturned_Date As Date
        Public Property Returned_Date() As Date
            Get
                Return pReturned_Date
            End Get
            Set(ByVal value As Date)
                pReturned_Date = value
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

        Private pPurpose As String
        Public Property Purpose() As String
            Get
                Return pPurpose
            End Get
            Set(ByVal value As String)
                pPurpose = value
            End Set
        End Property

        Private pRemarks As String
        Public Property Remarks() As String
            Get
                Return pRemarks
            End Get
            Set(ByVal value As String)
                pRemarks = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Returned_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Returned_To", Returned_To)
            objDerived.cmd.Parameters.AddWithValue("@Returned_By", Returned_By)
            objDerived.cmd.Parameters.AddWithValue("@Returned_Date", Returned_Date)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
            objDerived.cmd.Parameters.AddWithValue("@Purpose", Purpose)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_ARE_Returned_History_Hdr]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Returned_ID", Returned_ID)
            objDerived.cmd.Parameters.AddWithValue("@Returned_To", Returned_To)
            objDerived.cmd.Parameters.AddWithValue("@Returned_By", Returned_By)
            objDerived.cmd.Parameters.AddWithValue("@Returned_Date", Returned_Date)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
            objDerived.cmd.Parameters.AddWithValue("@Purpose", Purpose)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_ARE_Returned_History_Hdr]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class


#End Region

#Region "ARE_Returned_History_Dtl"

    Public Class ARE_Returned_History_Dtl
        Inherits BaseDLL.BaseDAL

        Private pReturned_ID_Dtl As Long
        Public Property Returned_ID_Dtl() As Long
            Get
                Return pReturned_ID_Dtl
            End Get
            Set(ByVal value As Long)
                pReturned_ID_Dtl = value
            End Set
        End Property

        Private pReturned_ID As Long
        Public Property Returned_ID() As Long
            Get
                Return pReturned_ID
            End Get
            Set(ByVal value As Long)
                pReturned_ID = value
            End Set
        End Property

        Private pAcquired_Date As Date
        Public Property Acquired_Date() As Date
            Get
                Return pAcquired_Date
            End Get
            Set(ByVal value As Date)
                pAcquired_Date = value
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

        Private pPropertyNo As String
        Public Property PropertyNo() As String
            Get
                Return pPropertyNo
            End Get
            Set(ByVal value As String)
                pPropertyNo = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Returned_ID_Dtl", 0)
            objDerived.cmd.Parameters.AddWithValue("@Returned_ID", Returned_ID)
            objDerived.cmd.Parameters.AddWithValue("@Acquired_Date", Acquired_Date)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_ARE_Returned_History_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Returned_ID_Dtl", Returned_ID_Dtl)
            objDerived.cmd.Parameters.AddWithValue("@Returned_ID", Returned_ID)
            objDerived.cmd.Parameters.AddWithValue("@Acquired_Date", Acquired_Date)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_ARE_Returned_History_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class


#End Region

End Namespace
