Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Namespace t_SAI

#Region "TbSai_Hdr"

    Public Class TbSai_Hdr
        Inherits BaseDLL.BaseDAL

        Private pSai_Hdr_ID As Long
        Public Property Sai_Hdr_ID() As Long
            Get
                Return pSai_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pSai_Hdr_ID = value
            End Set
        End Property

        Private pSai_Date As Date
        Public Property Sai_Date() As Date
            Get
                Return pSai_Date
            End Get
            Set(ByVal value As Date)
                pSai_Date = value
            End Set
        End Property

        Private pSai_No As String
        Public Property Sai_No() As String
            Get
                Return pSai_No
            End Get
            Set(ByVal value As String)
                pSai_No = value
            End Set
        End Property

        Private pRC_ID As Integer
        Public Property RC_ID() As Integer
            Get
                Return pRC_ID
            End Get
            Set(ByVal value As Integer)
                pRC_ID = value
            End Set
        End Property

        Private pFunction_ID As Integer
        Public Property Function_ID() As Integer
            Get
                Return pFunction_ID
            End Get
            Set(ByVal value As Integer)
                pFunction_ID = value
            End Set
        End Property

        Private pGA_Code As Integer
        Public Property GA_Code() As Integer
            Get
                Return pGA_Code
            End Get
            Set(ByVal value As Integer)
                pGA_Code = value
            End Set
        End Property

        Private pPurposeRemarks As String
        Public Property PurposeRemarks() As String
            Get
                Return pPurposeRemarks
            End Get
            Set(ByVal value As String)
                pPurposeRemarks = value
            End Set
        End Property

        Private pInquiryby As String
        Public Property Inquiryby() As String
            Get
                Return pInquiryby
            End Get
            Set(ByVal value As String)
                pInquiryby = value
            End Set
        End Property

        Private pposition1 As String
        Public Property position1() As String
            Get
                Return pposition1
            End Get
            Set(ByVal value As String)
                pposition1 = value
            End Set
        End Property

        Private pProvidedby As String
        Public Property Providedby() As String
            Get
                Return pProvidedby
            End Get
            Set(ByVal value As String)
                pProvidedby = value
            End Set
        End Property

        Private pposition2 As String
        Public Property position2() As String
            Get
                Return pposition2
            End Get
            Set(ByVal value As String)
                pposition2 = value
            End Set
        End Property

        Private pDate_Provided As String
        Public Property Date_Provided() As String
            Get
                Return pDate_Provided
            End Get
            Set(ByVal value As String)
                pDate_Provided = value
            End Set
        End Property

        Private pisConfirm As Boolean
        Public Property isConfirm() As Boolean
            Get
                Return pisConfirm
            End Get
            Set(ByVal value As Boolean)
                pisConfirm = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Sai_Hdr_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Sai_Date", Sai_Date)
            objDerived.cmd.Parameters.AddWithValue("@Sai_No", Sai_No)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_Code", GA_Code)
            objDerived.cmd.Parameters.AddWithValue("@PurposeRemarks", PurposeRemarks)
            objDerived.cmd.Parameters.AddWithValue("@Inquiryby", Inquiryby)
            objDerived.cmd.Parameters.AddWithValue("@position1", position1)
            objDerived.cmd.Parameters.AddWithValue("@Providedby", Providedby)
            objDerived.cmd.Parameters.AddWithValue("@position2", position2)
            objDerived.cmd.Parameters.AddWithValue("@Date_Provided", Date_Provided)
            objDerived.cmd.Parameters.AddWithValue("@isConfirm", isConfirm)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbSai_Hdr", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Sai_Hdr_ID", Sai_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Sai_Date", Sai_Date)
            objDerived.cmd.Parameters.AddWithValue("@Sai_No", Sai_No)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_Code", GA_Code)
            objDerived.cmd.Parameters.AddWithValue("@PurposeRemarks", PurposeRemarks)
            objDerived.cmd.Parameters.AddWithValue("@Inquiryby", Inquiryby)
            objDerived.cmd.Parameters.AddWithValue("@position1", position1)
            objDerived.cmd.Parameters.AddWithValue("@Providedby", Providedby)
            objDerived.cmd.Parameters.AddWithValue("@position2", position2)
            objDerived.cmd.Parameters.AddWithValue("@Date_Provided", Date_Provided)
            objDerived.cmd.Parameters.AddWithValue("@isConfirm", isConfirm)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbSai_Hdr", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region
#Region "TbSai_Dtl"

    Public Class TbSai_Dtl
        Inherits BaseDLL.BaseDAL

        Private pSai_Dtl_ID As Long
        Public Property Sai_Dtl_ID() As Long
            Get
                Return pSai_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pSai_Dtl_ID = value
            End Set
        End Property


        Private pSai_Hdr_ID As Long
        Public Property Sai_Hdr_ID() As Long
            Get
                Return pSai_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pSai_Hdr_ID = value
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

        Private pUnit As String
        Public Property Unit() As String
            Get
                Return pUnit
            End Get
            Set(ByVal value As String)
                pUnit = value
            End Set
        End Property

        Private pInquireQty As Integer
        Public Property InquireQty() As Integer
            Get
                Return pInquireQty
            End Get
            Set(ByVal value As Integer)
                pInquireQty = value
            End Set
        End Property

        Private pAvailbleQty As Integer
        Public Property AvailbleQty() As Integer
            Get
                Return pAvailbleQty
            End Get
            Set(ByVal value As Integer)
                pAvailbleQty = value
            End Set
        End Property
        


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Sai_Dtl_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Sai_Hdr_ID", Sai_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Unit", Unit)
            objDerived.cmd.Parameters.AddWithValue("@InquireQty", InquireQty)
            objDerived.cmd.Parameters.AddWithValue("@AvailbleQty", AvailbleQty)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbSai_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Sai_Dtl_ID", Sai_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Sai_Hdr_ID", Sai_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Unit", Unit)
            objDerived.cmd.Parameters.AddWithValue("@InquireQty", InquireQty)
            objDerived.cmd.Parameters.AddWithValue("@AvailbleQty", AvailbleQty)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TbSai_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

End Namespace
