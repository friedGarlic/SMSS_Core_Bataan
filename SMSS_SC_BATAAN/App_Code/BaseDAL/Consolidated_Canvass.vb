Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Namespace Consolidated_Canvass


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


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Hdr_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Canvass_Date", Canvass_Date)
            objDerived.cmd.Parameters.AddWithValue("@withWinner", withWinner)
            objDerived.cmd.Parameters.AddWithValue("@PR_Hdr_ID", PR_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@isDBM", isDBM)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Hdr]", CommandType.StoredProcedure, Nothing)
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

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Hdr]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

    '=-= m_Canvass_Dtl1
#Region "m_Canvass_Dtl1"

    Public Class m_Canvass_Dtl1
        Inherits BaseDLL.BaseDAL

        Private pDtl_ID1 As Long
        Public Property Dtl_ID1() As Long
            Get
                Return pDtl_ID1
            End Get
            Set(ByVal value As Long)
                pDtl_ID1 = value
            End Set
        End Property

        Private pHdr_ID As Long
        Public Property Hdr_ID() As Long
            Get
                Return pHdr_ID
            End Get
            Set(ByVal value As Long)
                pHdr_ID = value
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

        Private pwithWinner As Boolean
        Public Property withWinner() As Boolean
            Get
                Return pwithWinner
            End Get
            Set(ByVal value As Boolean)
                pwithWinner = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID1", 0)
            objDerived.cmd.Parameters.AddWithValue("@Hdr_ID", Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@withWinner", withWinner)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Dtl1]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID1", Dtl_ID1)
            objDerived.cmd.Parameters.AddWithValue("@Hdr_ID", Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@withWinner", withWinner)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Dtl1]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

    '=-= m_Canvass_Dtl2
#Region "m_Canvass_Dtl2"

    Public Class m_Canvass_Dtl2
        Inherits BaseDLL.BaseDAL

        Private pDtl_ID2 As Long
        Public Property Dtl_ID2() As Long
            Get
                Return pDtl_ID2
            End Get
            Set(ByVal value As Long)
                pDtl_ID2 = value
            End Set
        End Property

        Private pDtl_ID1 As Long
        Public Property Dtl_ID1() As Long
            Get
                Return pDtl_ID1
            End Get
            Set(ByVal value As Long)
                pDtl_ID1 = value
            End Set
        End Property

        Private pSupplier_ID As Long
        Public Property Supplier_ID() As Long
            Get
                Return pSupplier_ID
            End Get
            Set(ByVal value As Long)
                pSupplier_ID = value
            End Set
        End Property

        Private pUnitPrice As Decimal
        Public Property UnitPrice() As Decimal
            Get
                Return pUnitPrice
            End Get
            Set(ByVal value As Decimal)
                pUnitPrice = value
            End Set
        End Property

        Private pQuantity As Decimal
        Public Property Quantity() As Decimal
            Get
                Return pQuantity
            End Get
            Set(ByVal value As Decimal)
                pQuantity = value
            End Set
        End Property

        Private pisWinner As Boolean
        Public Property isWinner() As Boolean
            Get
                Return pisWinner
            End Get
            Set(ByVal value As Boolean)
                pisWinner = value
            End Set
        End Property


        Private pItemSpecs As String
        Public Property ItemSpecs() As String
            Get
                Return pItemSpecs
            End Get
            Set(ByVal value As String)
                pItemSpecs = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID2", 0)
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID1", Dtl_ID1)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice)
            objDerived.cmd.Parameters.AddWithValue("@Quantity", Quantity)
            objDerived.cmd.Parameters.AddWithValue("@isWinner", isWinner)
            objDerived.cmd.Parameters.AddWithValue("@ItemSpecs", ItemSpecs)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Dtl2]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID2", Dtl_ID2)
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID1", Dtl_ID1)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice)
            objDerived.cmd.Parameters.AddWithValue("@Quantity", Quantity)
            objDerived.cmd.Parameters.AddWithValue("@isWinner", isWinner)
            objDerived.cmd.Parameters.AddWithValue("@ItemSpecs", ItemSpecs)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Dtl2]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region


    '=-= m_Canvass_Dtl_PR1
#Region "m_Canvass_Dtl_PR1"

    Public Class m_Canvass_Dtl_PR1
        Inherits BaseDLL.BaseDAL

        Private pDtl_ID_PR1 As Long
        Public Property Dtl_ID_PR1() As Long
            Get
                Return pDtl_ID_PR1
            End Get
            Set(ByVal value As Long)
                pDtl_ID_PR1 = value
            End Set
        End Property

        Private pHdr_ID As Long
        Public Property Hdr_ID() As Long
            Get
                Return pHdr_ID
            End Get
            Set(ByVal value As Long)
                pHdr_ID = value
            End Set
        End Property

        Private pSupplier_ID As Long
        Public Property Supplier_ID() As Long
            Get
                Return pSupplier_ID
            End Get
            Set(ByVal value As Long)
                pSupplier_ID = value
            End Set
        End Property

        Private pisWinner As Boolean
        Public Property isWinner() As Boolean
            Get
                Return pisWinner
            End Get
            Set(ByVal value As Boolean)
                pisWinner = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID_PR1", 0)
            objDerived.cmd.Parameters.AddWithValue("@Hdr_ID", Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@isWinner", isWinner)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Dtl_PR1]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID_PR1", Dtl_ID_PR1)
            objDerived.cmd.Parameters.AddWithValue("@Hdr_ID", Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@isWinner", isWinner)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Dtl_PR1]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region


    '=-= m_Canvass_Dtl_PR2
#Region "m_Canvass_Dtl_PR2"

    Public Class m_Canvass_Dtl_PR2
        Inherits BaseDLL.BaseDAL

        Private pDtl_ID_PR2 As Long
        Public Property Dtl_ID_PR2() As Long
            Get
                Return pDtl_ID_PR2
            End Get
            Set(ByVal value As Long)
                pDtl_ID_PR2 = value
            End Set
        End Property

        Private pDtl_ID_PR1 As Long
        Public Property Dtl_ID_PR1() As Long
            Get
                Return pDtl_ID_PR1
            End Get
            Set(ByVal value As Long)
                pDtl_ID_PR1 = value
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

        Private pUnitPrice As Decimal
        Public Property UnitPrice() As Decimal
            Get
                Return pUnitPrice
            End Get
            Set(ByVal value As Decimal)
                pUnitPrice = value
            End Set
        End Property

        Private pQuantity As Decimal
        Public Property Quantity() As Decimal
            Get
                Return pQuantity
            End Get
            Set(ByVal value As Decimal)
                pQuantity = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID_PR2", 0)
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID_PR1", Dtl_ID_PR1)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice)
            objDerived.cmd.Parameters.AddWithValue("@Quantity", Quantity)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Dtl_PR2]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID_PR2", Dtl_ID_PR2)
            objDerived.cmd.Parameters.AddWithValue("@Dtl_ID_PR1", Dtl_ID_PR1)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice)
            objDerived.cmd.Parameters.AddWithValue("@Quantity", Quantity)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_m_Canvass_Dtl_PR2]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region



End Namespace
