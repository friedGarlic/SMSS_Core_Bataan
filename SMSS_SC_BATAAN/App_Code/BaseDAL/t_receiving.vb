Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Namespace Receiving



#Region "receiving_hdr"

    Public Class t_receiving
        Inherits BaseDLL.BaseDAL

        Private pReceived_ID As Long
        Public Property Received_ID() As Long
            Get
                Return pReceived_ID
            End Get
            Set(ByVal value As Long)
                pReceived_ID = value
            End Set
        End Property

        Private pReceived_Date As Date
        Public Property Received_Date() As Date
            Get
                Return pReceived_Date
            End Get
            Set(ByVal value As Date)
                pReceived_Date = value
            End Set
        End Property


        Private pReceivedBY As Long
        Public Property ReceivedBY() As Long
            Get
                Return pReceivedBY
            End Get
            Set(ByVal value As Long)
                pReceivedBY = value
            End Set
        End Property

        Private pInspectedBy As Long
        Public Property InspectedBy() As Long
            Get
                Return pInspectedBy
            End Get
            Set(ByVal value As Long)
                pInspectedBy = value
            End Set
        End Property

        Private pPOHdr_ID As Long
        Public Property POHdr_ID() As Long
            Get
                Return pPOHdr_ID
            End Get
            Set(ByVal value As Long)
                pPOHdr_ID = value
            End Set
        End Property

        Private pPO_No As String
        Public Property PO_No() As String
            Get
                Return pPO_No
            End Get
            Set(ByVal value As String)
                pPO_No = value
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

        Private pGA_ID As Long
        Public Property GA_ID() As Long
            Get
                Return pGA_ID
            End Get
            Set(ByVal value As Long)
                pGA_ID = value
            End Set
        End Property

        Private pisAccepted As Boolean
        Public Property isAccepted() As Boolean
            Get
                Return pisAccepted
            End Get
            Set(ByVal value As Boolean)
                pisAccepted = value
            End Set
        End Property

        Private pUserID As String
        Public Property UserID() As String
            Get
                Return pUserID
            End Get
            Set(ByVal value As String)
                pUserID = value
            End Set
        End Property

        Private pStatus As Long
        Public Property Status() As Long
            Get
                Return pStatus
            End Get
            Set(ByVal value As Long)
                pStatus = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Received_Date", Received_Date)
            objDerived.cmd.Parameters.AddWithValue("@ReceivedBY", ReceivedBY)
            objDerived.cmd.Parameters.AddWithValue("@InspectedBy", InspectedBy)
            objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@PO_No", PO_No)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
            objDerived.cmd.Parameters.AddWithValue("@isAccepted", isAccepted)
            objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
            objDerived.cmd.Parameters.AddWithValue("@status", Status)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_Receiving]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@Received_Date", Received_Date)
            objDerived.cmd.Parameters.AddWithValue("@ReceivedBY", ReceivedBY)
            objDerived.cmd.Parameters.AddWithValue("@InspectedBy", InspectedBy)
            objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@PO_No", PO_No)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
            objDerived.cmd.Parameters.AddWithValue("@isAccepted", isAccepted)
            objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
            objDerived.cmd.Parameters.AddWithValue("@status", Status)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_Receiving]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region

#Region "receiving_dtl"

    Public Class t_receiving_dtl
        Inherits BaseDLL.BaseDAL

        Private pReceived_Dtl_ID As Long
        Public Property Received_Dtl_ID() As Long
            Get
                Return pReceived_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pReceived_Dtl_ID = value
            End Set
        End Property

        Private pReceived_ID As Long
        Public Property Received_ID() As Long
            Get
                Return pReceived_ID
            End Get
            Set(ByVal value As Long)
                pReceived_ID = value
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

        Private pPO_Qty As Decimal
        Public Property PO_Qty() As Decimal
            Get
                Return pPO_Qty
            End Get
            Set(ByVal value As Decimal)
                pPO_Qty = value
            End Set
        End Property

        Private pQty_Received As Decimal
        Public Property Qty_Received() As Decimal
            Get
                Return pQty_Received
            End Get
            Set(ByVal value As Decimal)
                pQty_Received = value
            End Set
        End Property

        Private pCost As Decimal
        Public Property Cost() As Decimal
            Get
                Return pCost
            End Get
            Set(ByVal value As Decimal)
                pCost = value
            End Set
        End Property

        Private pCondition As String
        Public Property Condition() As String
            Get
                Return pCondition
            End Get
            Set(ByVal value As String)
                pCondition = value
            End Set
        End Property

        Private pLocation As String
        Public Property Location() As String
            Get
                Return pLocation
            End Get
            Set(ByVal value As String)
                pLocation = value
            End Set
        End Property

        Private pStatus As Long
        Public Property Status() As Long
            Get
                Return pStatus
            End Get
            Set(ByVal value As Long)
                pStatus = value
            End Set
        End Property
        Private pQty_Inspecting As Decimal
        Public Property Qty_Inspecting() As Decimal
            Get
                Return pQty_Inspecting
            End Get
            Set(ByVal value As Decimal)
                pQty_Inspecting = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@Received_Dtl_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@PO_Qty", PO_Qty)
            objDerived.cmd.Parameters.AddWithValue("@Qty_Received", Qty_Received)
            objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Qty_Inspecting", Qty_Inspecting)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_Receiving_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function


        Public Function update() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@Received_Dtl_ID", Received_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@PO_Qty", PO_Qty)
            objDerived.cmd.Parameters.AddWithValue("@Qty_Received", Qty_Received)
            objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
            objDerived.cmd.Parameters.AddWithValue("@Condition", Condition)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_Receiving_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

End Namespace