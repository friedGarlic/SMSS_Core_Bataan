Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class Property_Building
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pMachineryId As Integer
    Public Property MachineryId() As Integer
        Get
            Return pMachineryId
        End Get
        Set(ByVal value As Integer)
            pMachineryId = value
        End Set
    End Property

    Private pProperty_ID As Integer
    Public Property Property_ID() As Integer
        Get
            Return pProperty_ID
        End Get
        Set(ByVal value As Integer)
            pProperty_ID = value
        End Set
    End Property


    Private pLandDetailId As Integer
    Public Property LandDetailId() As Integer
        Get
            Return pLandDetailId
        End Get
        Set(ByVal value As Integer)
            pLandDetailId = value
        End Set
    End Property

    Private pProjectCost As Decimal
    Public Property ProjectCost() As Decimal
        Get
            Return pProjectCost
        End Get
        Set(ByVal value As Decimal)
            pProjectCost = value
        End Set
    End Property
    Private pTotalFlrArea As String
    Public Property TotalFlrArea() As String
        Get
            Return pTotalFlrArea
        End Get
        Set(ByVal value As String)
            pTotalFlrArea = value
        End Set
    End Property

    Private pAveAreaPerFlr As Decimal
    Public Property AveAreaPerFlr() As Decimal
        Get
            Return pAveAreaPerFlr
        End Get
        Set(ByVal value As Decimal)
            pAveAreaPerFlr = value
        End Set
    End Property

    Private pCostPersqM As Decimal
    Public Property CostPersqM() As Decimal
        Get
            Return pCostPersqM
        End Get
        Set(ByVal value As Decimal)
            pCostPersqM = value
        End Set
    End Property


    Private pHeight As String
    Public Property Height() As String
        Get
            Return pHeight
        End Get
        Set(ByVal value As String)
            pHeight = value
        End Set
    End Property


    Private pNoofFloors As Integer
    Public Property NoofFloors() As String
        Get
            Return pNoofFloors
        End Get
        Set(ByVal value As String)
            pNoofFloors = value
        End Set
    End Property

    Private popenSpace As String
    Public Property openSpace() As String
        Get
            Return popenSpace
        End Get
        Set(ByVal value As String)
            popenSpace = value
        End Set
    End Property


    Private pStarted As Date
    Public Property Started() As Date
        Get
            Return pStarted
        End Get
        Set(ByVal value As Date)
            pStarted = value
        End Set
    End Property


    Private pCompleted As Date
    Public Property Completed() As Date
        Get
            Return pCompleted
        End Get
        Set(ByVal value As Date)
            pCompleted = value
        End Set
    End Property


#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MachineryId", 0)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@LandDetailId", LandDetailId)
        objDerived.cmd.Parameters.AddWithValue("@ProjectCost", ProjectCost)
        objDerived.cmd.Parameters.AddWithValue("@TotalFlrArea", TotalFlrArea)
        objDerived.cmd.Parameters.AddWithValue("@AveAreaPerFlr", AveAreaPerFlr)
        objDerived.cmd.Parameters.AddWithValue("@CostPersqM", CostPersqM)
        objDerived.cmd.Parameters.AddWithValue("@Height", Height)
        objDerived.cmd.Parameters.AddWithValue("@NoofFloors", NoofFloors)
        objDerived.cmd.Parameters.AddWithValue("@openSpace", openSpace)
        objDerived.cmd.Parameters.AddWithValue("@Started", Started)
        objDerived.cmd.Parameters.AddWithValue("@Completed", Completed)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveBuilding", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MachineryId", MachineryId)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@LandDetailId", LandDetailId)

        objDerived.cmd.Parameters.AddWithValue("@ProjectCost", ProjectCost)
        objDerived.cmd.Parameters.AddWithValue("@TotalFlrArea", TotalFlrArea)
        objDerived.cmd.Parameters.AddWithValue("@AveAreaPerFlr", AveAreaPerFlr)
        objDerived.cmd.Parameters.AddWithValue("@CostPersqM", CostPersqM)
        objDerived.cmd.Parameters.AddWithValue("@Height", Height)
        objDerived.cmd.Parameters.AddWithValue("@NoofFloors", NoofFloors)
        objDerived.cmd.Parameters.AddWithValue("@openSpace", openSpace)
        objDerived.cmd.Parameters.AddWithValue("@Started", Started)
        objDerived.cmd.Parameters.AddWithValue("@Completed", Completed)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveBuilding", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
