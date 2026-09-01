Imports Microsoft.VisualBasic
Imports System.Data

Namespace Namespace_Bidding

#Region "BACResolution"
    Public Class BACResolution
        Inherits BaseDLL.BaseDAL

        Private xBACResolution_ID As Long
        Public Property BACResolution_ID() As Long
            Get
                Return xBACResolution_ID
            End Get
            Set(ByVal value As Long)
                xBACResolution_ID = value
            End Set
        End Property


        Private xpre_procurement_hdr_id As Long
        Public Property pre_procurement_hdr_id() As Long
            Get
                Return xpre_procurement_hdr_id
            End Get
            Set(ByVal value As Long)
                xpre_procurement_hdr_id = value
            End Set
        End Property

        Private xResolution_No As String
        Public Property Resolution_No() As String
            Get
                Return xResolution_No
            End Get
            Set(ByVal value As String)
                xResolution_No = value
            End Set
        End Property

        Private xProjectName As String
        Public Property ProjectName() As String
            Get
                Return xProjectName
            End Get
            Set(ByVal value As String)
                xProjectName = value
            End Set
        End Property

        Private xtxtContent_1 As String
        Public Property txtContent_1() As String
            Get
                Return xtxtContent_1
            End Get
            Set(ByVal value As String)
                xtxtContent_1 = value
            End Set
        End Property

        Private xtxtContent_2 As String
        Public Property txtContent_2() As String
            Get
                Return xtxtContent_2
            End Get
            Set(ByVal value As String)
                xtxtContent_2 = value
            End Set
        End Property


        Private xtxtContent_3 As String
        Public Property txtContent_3() As String
            Get
                Return xtxtContent_3
            End Get
            Set(ByVal value As String)
                xtxtContent_3 = value
            End Set
        End Property


        Private xtxtContent_4 As String
        Public Property txtContent_4() As String
            Get
                Return xtxtContent_4
            End Get
            Set(ByVal value As String)
                xtxtContent_4 = value
            End Set
        End Property

        Private xtxtContent_5 As String
        Public Property txtContent_5() As String
            Get
                Return xtxtContent_5
            End Get
            Set(ByVal value As String)
                xtxtContent_5 = value
            End Set
        End Property

        Private xtxtContent_6 As String
        Public Property txtContent_6() As String
            Get
                Return xtxtContent_6
            End Get
            Set(ByVal value As String)
                xtxtContent_6 = value
            End Set
        End Property

        Private xtxtContent_7 As String
        Public Property txtContent_7() As String
            Get
                Return xtxtContent_7
            End Get
            Set(ByVal value As String)
                xtxtContent_7 = value
            End Set
        End Property

        Private xtxtContent_8 As String
        Public Property txtContent_8() As String
            Get
                Return xtxtContent_8
            End Get
            Set(ByVal value As String)
                xtxtContent_8 = value
            End Set
        End Property

        Private xtxtContent_9 As String
        Public Property txtContent_9() As String
            Get
                Return xtxtContent_9
            End Get
            Set(ByVal value As String)
                xtxtContent_9 = value
            End Set
        End Property

        Private xtxtContent_10 As String
        Public Property txtContent_10() As String
            Get
                Return xtxtContent_10
            End Get
            Set(ByVal value As String)
                xtxtContent_10 = value
            End Set
        End Property

        Private xtxtContent_11 As String
        Public Property txtContent_11() As String
            Get
                Return xtxtContent_11
            End Get
            Set(ByVal value As String)
                xtxtContent_11 = value
            End Set
        End Property


        Private xBAC1 As Integer
        Public Property BAC1() As Integer
            Get
                Return xBAC1
            End Get
            Set(ByVal value As Integer)
                xBAC1 = value
            End Set
        End Property

        Private xBAC2 As Integer
        Public Property BAC2() As Integer
            Get
                Return xBAC2
            End Get
            Set(ByVal value As Integer)
                xBAC2 = value
            End Set
        End Property

        Private xBAC3 As Integer
        Public Property BAC3() As Integer
            Get
                Return xBAC3
            End Get
            Set(ByVal value As Integer)
                xBAC3 = value
            End Set
        End Property
        Private xBACVC As Integer
        Public Property BACVC() As Integer
            Get
                Return xBACVC
            End Get
            Set(ByVal value As Integer)
                xBACVC = value
            End Set
        End Property

        Private xBACC As Integer
        Public Property BACC() As Integer
            Get
                Return xBACC
            End Get
            Set(ByVal value As Integer)
                xBACC = value
            End Set
        End Property

        Private xApprovedBy As Integer
        Public Property ApprovedBy() As Integer
            Get
                Return xApprovedBy
            End Get
            Set(ByVal value As Integer)
                xApprovedBy = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@BACResolution_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", pre_procurement_hdr_id)
            objDerived.cmd.Parameters.AddWithValue("@Resolution_No", Resolution_No)
            objDerived.cmd.Parameters.AddWithValue("@ProjectName", ProjectName)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_1", txtContent_1)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_2", txtContent_2)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_3", txtContent_3)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_4", txtContent_4)
            'objDerived.cmd.Parameters.AddWithValue("@txtContent_5", txtContent_5)
            'objDerived.cmd.Parameters.AddWithValue("@txtContent_6", txtContent_6)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_7", txtContent_7)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_8", txtContent_8)
            'objDerived.cmd.Parameters.AddWithValue("@txtContent_9", txtContent_9)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_10", txtContent_10)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_11", txtContent_11)
            objDerived.cmd.Parameters.AddWithValue("@BAC1", BAC1)
            objDerived.cmd.Parameters.AddWithValue("@BAC2", BAC2)
            objDerived.cmd.Parameters.AddWithValue("@BAC3", BAC3)
            objDerived.cmd.Parameters.AddWithValue("@BACVC", BACVC)
            objDerived.cmd.Parameters.AddWithValue("@BACC", BACC)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_tb_BACResolution]", CommandType.StoredProcedure, Nothing)

            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@BACResolution_ID", BACResolution_ID)
            objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", pre_procurement_hdr_id)
            objDerived.cmd.Parameters.AddWithValue("@Resolution_No", Resolution_No)
            objDerived.cmd.Parameters.AddWithValue("@ProjectName", ProjectName)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_1", txtContent_1)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_2", txtContent_2)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_3", txtContent_3)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_4", txtContent_4)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_5", txtContent_5)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_6", txtContent_6)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_7", txtContent_7)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_8", txtContent_8)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_9", txtContent_9)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_10", txtContent_10)
            objDerived.cmd.Parameters.AddWithValue("@txtContent_11", txtContent_11)
            objDerived.cmd.Parameters.AddWithValue("@BAC1", BAC1)
            objDerived.cmd.Parameters.AddWithValue("@BAC2", BAC2)
            objDerived.cmd.Parameters.AddWithValue("@BAC3", BAC3)
            objDerived.cmd.Parameters.AddWithValue("@BACVC", BACVC)
            objDerived.cmd.Parameters.AddWithValue("@BACC", BACC)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_tb_BACResolution]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

End Namespace

