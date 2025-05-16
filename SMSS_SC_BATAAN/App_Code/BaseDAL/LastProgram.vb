Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic
Imports System


Public Class LastProgram
    Inherits BaseDAL
#Region "property"
    Private pProgram_ID As Long
    Public Property Program_ID() As Long
        Get
            Return pProgram_ID
        End Get
        Set(ByVal value As Long)
            pProgram_ID = value
        End Set
    End Property

    Private pProgram_Name As String
    Public Property Program_Name() As String
        Get
            Return pProgram_Name
        End Get
        Set(ByVal value As String)
            pProgram_Name = value
        End Set
    End Property

    Private pProgram_Code As String
    Public Property Program_Code() As String
        Get
            Return pProgram_Code
        End Get
        Set(ByVal value As String)
            pProgram_Code = value
        End Set
    End Property

    Private pSector_ID As Long
    Public Property Sector_ID() As Long
        Get
            Return pSector_ID
        End Get
        Set(ByVal value As Long)
            pSector_ID = value
        End Set
    End Property

    Private pSubSector_ID As Integer
    Public Property SubSector_ID() As Integer
        Get
            Return pSubSector_ID
        End Get
        Set(ByVal value As Integer)
            pSubSector_ID = value
        End Set
    End Property

    Private pF_ID As Long
    Public Property F_ID() As Long
        Get
            Return pF_ID
        End Get
        Set(ByVal value As Long)
            pF_ID = value
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

    Private pGA_ID As Long
    Public Property GA_ID() As Long
        Get
            Return pGA_ID
        End Get
        Set(ByVal value As Long)
            pGA_ID = value
        End Set
    End Property

    Private pExpectedOutputs As String
    Public Property ExpectedOutputs() As String
        Get
            Return pExpectedOutputs
        End Get
        Set(ByVal value As String)
            pExpectedOutputs = value
        End Set
    End Property

    Private pStartDate As DateTime
    Public Property StartDate() As DateTime
        Get
            Return pStartDate
        End Get
        Set(ByVal value As DateTime)
            pStartDate = value
        End Set
    End Property

    Private pCompletionDate As DateTime
    Public Property CompletionDate() As DateTime
        Get
            Return pCompletionDate
        End Get
        Set(ByVal value As DateTime)
            pCompletionDate = value
        End Set
    End Property

    Private pObjectives As String
    Public Property Objectives() As String
        Get
            Return pObjectives
        End Get
        Set(ByVal value As String)
            pObjectives = value
        End Set
    End Property

    Private pBudget_Year As String
    Public Property Budget_Year() As String
        Get
            Return pBudget_Year
        End Get
        Set(ByVal value As String)
            pBudget_Year = value
        End Set
    End Property

    Private pfundingsource_id As Long
    Public Property fundingsource_id() As Long
        Get
            Return pfundingsource_id
        End Get
        Set(ByVal value As Long)
            pfundingsource_id = value
        End Set
    End Property

    Private pstatus As String
    Public Property status() As String
        Get
            Return pstatus
        End Get
        Set(ByVal value As String)
            pstatus = value
        End Set
    End Property

    Private pPS As Decimal
    Public Property PS() As Decimal
        Get
            Return pPS
        End Get
        Set(ByVal value As Decimal)
            pPS = value
        End Set
    End Property

    Private pMOOE As Decimal
    Public Property MOOE() As Decimal
        Get
            Return pMOOE
        End Get
        Set(ByVal value As Decimal)
            pMOOE = value
        End Set
    End Property

    Private pCO As Decimal
    Public Property CO() As Decimal
        Get
            Return pCO
        End Get
        Set(ByVal value As Decimal)
            pCO = value
        End Set
    End Property

    Private pTotalCost As Decimal
    Public Property TotalCost() As Decimal
        Get
            Return pTotalCost
        End Get
        Set(ByVal value As Decimal)
            pTotalCost = value
        End Set
    End Property

    Private pisGAD As Boolean
    Public Property isGAD() As Boolean
        Get
            Return pisGAD
        End Get
        Set(ByVal value As Boolean)
            pisGAD = value
        End Set
    End Property

    Private pTargetBeneficiaries As String
    Public Property TargetBeneficiaries() As String
        Get
            Return pTargetBeneficiaries
        End Get
        Set(ByVal value As String)
            pTargetBeneficiaries = value
        End Set
    End Property

    Private pPerformanceInd As String
    Public Property PerformanceInd() As String
        Get
            Return pPerformanceInd
        End Get
        Set(ByVal value As String)
            pPerformanceInd = value
        End Set
    End Property

    Private pProgramSeq As Long
    Public Property ProgramSeq() As Long
        Get
            Return pProgramSeq
        End Get
        Set(ByVal value As Long)
            pProgramSeq = value
        End Set
    End Property

    Private pOtherOffices As String
    Public Property OtherOffices() As String
        Get
            Return pOtherOffices
        End Get
        Set(ByVal value As String)
            pOtherOffices = value
        End Set
    End Property

    Private pAIP_SubReport_ID As Long
    Public Property AIP_SubReport_ID() As Long
        Get
            Return pAIP_SubReport_ID
        End Get
        Set(ByVal value As Long)
            pAIP_SubReport_ID = value
        End Set
    End Property

    Private pOFE As Decimal
    Public Property OFE() As Decimal
        Get
            Return pOFE
        End Get
        Set(ByVal value As Decimal)
            pOFE = value
        End Set
    End Property
    Private pPrevprog_ID As Long
    Public Property Prevprog_ID() As Long
        Get
            Return pPrevprog_ID
        End Get
        Set(ByVal value As Long)
            pPrevprog_ID = value
        End Set
    End Property
    Private pisInfra As Boolean
    Public Property isInfra() As Boolean
        Get
            Return pisInfra
        End Get
        Set(ByVal value As Boolean)
            pisInfra = value
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

    Private pTableName As String
    Public Property TableName() As String
        Get
            Return pTableName
        End Get
        Set(ByVal value As String)
            pTableName = value
        End Set
    End Property
#End Region

    Public Overrides Sub FillEntity()
        Try
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                With Me
                    .Program_ID = IIf(IsDBNull(rd("Program_ID")), 0, rd("Program_ID"))
                    .Program_Name = IIf(IsDBNull(rd("Program_Name")), "", rd("Program_Name"))
                    .Program_Code = IIf(IsDBNull(rd("Program_Code")), "", rd("Program_Code"))
                    .Sector_ID = IIf(IsDBNull(rd("Sector_ID")), 0, rd("Sector_ID"))
                    .SubSector_ID = IIf(IsDBNull(rd("SubSector_ID")), 0, rd("SubSector_ID"))
                    .F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
                    .RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
                    .Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                    .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                    .ExpectedOutputs = IIf(IsDBNull(rd("ExpectedOutputs")), "", rd("ExpectedOutputs"))
                    .StartDate = IIf(IsDBNull(rd("StartDate")), "", rd("StartDate"))
                    .CompletionDate = IIf(IsDBNull(rd("CompletionDate")), "", rd("CompletionDate"))
                    .Objectives = IIf(IsDBNull(rd("Objectives")), "", rd("Objectives"))
                    .Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                    .fundingsource_id = IIf(IsDBNull(rd("fundingsource_id")), 0, rd("fundingsource_id"))
                    .status = IIf(IsDBNull(rd("status")), "", rd("status"))
                    .PS = IIf(IsDBNull(rd("PS")), 0.0, rd("PS"))
                    .MOOE = IIf(IsDBNull(rd("MOOE")), 0.0, rd("MOOE"))
                    .CO = IIf(IsDBNull(rd("CO")), 0.0, rd("CO"))
                    .OFE = IIf(IsDBNull(rd("OFE")), 0.0, rd("OFE"))
                    .TotalCost = IIf(IsDBNull(rd("TotalCost")), 0.0, rd("TotalCost"))
                    .isGAD = IIf(IsDBNull(rd("isGAD")), 0, rd("isGAD"))
                    .TargetBeneficiaries = IIf(IsDBNull(rd("TargetBeneficiaries")), "", rd("TargetBeneficiaries"))
                    .PerformanceInd = IIf(IsDBNull(rd("PerformanceInd")), "", rd("PerformanceInd"))
                    .ProgramSeq = IIf(IsDBNull(rd("ProgramSeq")), 0, rd("ProgramSeq"))
                    .OtherOffices = IIf(IsDBNull(rd("OtherOffices")), "", rd("OtherOffices"))
                    .AIP_SubReport_ID = IIf(IsDBNull(rd("AIP_SubReport_ID")), 0, rd("AIP_SubReport_ID"))
                    .Prevprog_ID = IIf(IsDBNull(rd("prevprog_id")), 0, rd("prevprog_id"))
                    .isInfra = IIf(IsDBNull(rd("isInfra")), 0, rd("isInfra"))
                    .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                End With
            End While
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub


End Class
