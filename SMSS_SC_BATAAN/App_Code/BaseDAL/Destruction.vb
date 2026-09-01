Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Namespace Destruction

#Region "Disposal_Destruction_hdr"

    Public Class Disposal_Destruction_hdr
        Inherits BaseDLL.BaseDAL

        Private pDestruction_Hdr_ID As Long
        Public Property Destruction_Hdr_ID() As Long
            Get
                Return pDestruction_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pDestruction_Hdr_ID = value
            End Set
        End Property

        Private pDestruction_Date As Date
        Public Property Destruction_Date() As Date
            Get
                Return pDestruction_Date
            End Get
            Set(ByVal value As Date)
                pDestruction_Date = value
            End Set
        End Property

        Private pAccountable_Officer As String
        Public Property Accountable_Officer() As String
            Get
                Return pAccountable_Officer
            End Get
            Set(ByVal value As String)
                pAccountable_Officer = value
            End Set
        End Property

        Private pAuthorizedBy As String
        Public Property AuthorizedBy() As String
            Get
                Return pAuthorizedBy
            End Get
            Set(ByVal value As String)
                pAuthorizedBy = value
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

        Private pIIRUPHdr_ID As Long
        Public Property IIRUPHdr_ID() As Long
            Get
                Return pIIRUPHdr_ID
            End Get
            Set(ByVal value As Long)
                pIIRUPHdr_ID = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Destruction_Hdr_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Destruction_Date", Destruction_Date)
            objDerived.cmd.Parameters.AddWithValue("@Accountable_Officer", Accountable_Officer)
            objDerived.cmd.Parameters.AddWithValue("@AuthorizedBy", AuthorizedBy)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
            objDerived.cmd.Parameters.AddWithValue("@IIRUPHdr_ID", IIRUPHdr_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.spSave_Disposal_Destruction_hdr", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Destruction_Hdr_ID", Destruction_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Destruction_Date", Destruction_Date)
            objDerived.cmd.Parameters.AddWithValue("@Accountable_Officer", Accountable_Officer)
            objDerived.cmd.Parameters.AddWithValue("@AuthorizedBy", AuthorizedBy)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
            objDerived.cmd.Parameters.AddWithValue("@IIRUPHdr_ID", IIRUPHdr_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.spSave_Disposal_Destruction_hdr", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

#Region "Disposal_Destruction_Dtl"

    Public Class Disposal_Destruction_Dtl
        Inherits BaseDLL.BaseDAL

        Private pDestruction_Dtl_ID As Long
        Public Property Destruction_Dtl_ID() As Long
            Get
                Return pDestruction_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pDestruction_Dtl_ID = value
            End Set
        End Property

        Private pDestruction_Hdr_ID As Long
        Public Property Destruction_Hdr_ID() As Long
            Get
                Return pDestruction_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pDestruction_Hdr_ID = value
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

        Private pProperty_ID As Long
        Public Property Property_ID() As Long
            Get
                Return pProperty_ID
            End Get
            Set(ByVal value As Long)
                pProperty_ID = value
            End Set
        End Property

        Private pvalue As Decimal
        Public Property value() As Decimal
            Get
                Return pvalue
            End Get
            Set(ByVal value As Decimal)
                pvalue = value
            End Set
        End Property

        Private pProperty_Date As Date
        Public Property Property_Date() As Date
            Get
                Return pProperty_Date
            End Get
            Set(ByVal value As Date)
                pProperty_Date = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Destruction_Dtl_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Destruction_Hdr_ID", Destruction_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
            objDerived.cmd.Parameters.AddWithValue("@value", value)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", Property_Date)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.spSave_Disposal_Destruction_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Destruction_Dtl_ID", Destruction_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Destruction_Hdr_ID", Destruction_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
            objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
            objDerived.cmd.Parameters.AddWithValue("@value", value)
            objDerived.cmd.Parameters.AddWithValue("@Property_Date", Property_Date)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.spSave_Disposal_Destruction_Dtl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region



End Namespace
