Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class LastProject
    Inherits BaseDAL

    Private pProject_ID As Long
    Public Property Project_ID() As Long
        Get
            Return pProject_ID
        End Get
        Set(ByVal value As Long)
            pProject_ID = value
        End Set
    End Property
    Private pMajorProjID As Long
    Public Property MajorProjID() As Long
        Get
            Return pMajorProjID
        End Get
        Set(ByVal value As Long)
            pMajorProjID = value
        End Set
    End Property
    Private pProject_Name As String
    Public Property Project_Name() As String
        Get
            Return pProject_Name
        End Get
        Set(ByVal value As String)
            pProject_Name = value
        End Set
    End Property

    Private pProject_Code As String
    Public Property Project_Code() As String
        Get
            Return pProject_Code
        End Get
        Set(ByVal value As String)
            pProject_Code = value
        End Set
    End Property

    Private pProgram_ID As Long
    Public Property Program_ID() As Long
        Get
            Return pProgram_ID
        End Get
        Set(ByVal value As Long)
            pProgram_ID = value
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

    Private pExpectedOutputs As String
    Public Property ExpectedOutputs() As String
        Get
            Return pExpectedOutputs
        End Get
        Set(ByVal value As String)
            pExpectedOutputs = value
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

    Private pisActivity As Boolean
    Public Property isActivity() As Boolean
        Get
            Return pisActivity
        End Get
        Set(ByVal value As Boolean)
            pisActivity = value
        End Set
    End Property

    Private pisProject As Boolean
    Public Property isProject() As Boolean
        Get
            Return pisProject
        End Get
        Set(ByVal value As Boolean)
            pisProject = value
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

    Private pstatus As String
    Public Property status() As String
        Get
            Return pstatus
        End Get
        Set(ByVal value As String)
            pstatus = value
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

    Private pProjectSeq As Long
    Public Property ProjectSeq() As Long
        Get
            Return pProjectSeq
        End Get
        Set(ByVal value As Long)
            pProjectSeq = value
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

    Private pOFE As Decimal
    Public Property OFE() As Decimal
        Get
            Return pOFE
        End Get
        Set(ByVal value As Decimal)
            pOFE = value
        End Set
    End Property

    Private pPrevproj_ID As Long
    Public Property Prevproj_ID() As Long
        Get
            Return pPrevproj_ID
        End Get
        Set(ByVal value As Long)
            pPrevproj_ID = value
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

    Private pisSC As Boolean
    Public Property isSC() As Boolean
        Get
            Return pisSC
        End Get
        Set(ByVal value As Boolean)
            pisSC = value
        End Set
    End Property
    Private pisSubmit As Boolean
    Public Property isSubmit() As Boolean
        Get
            Return pisSubmit
        End Get
        Set(ByVal value As Boolean)
            pisSubmit = value
        End Set
    End Property

    Private pisfinal As Boolean
    Public Property isfinal() As Boolean
        Get
            Return pisfinal
        End Get
        Set(ByVal value As Boolean)
            pisfinal = value
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

    Public Overrides Sub FillEntity()
        Try
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                With Me
                    .Project_ID = IIf(IsDBNull(rd("Project_ID")), 0, rd("Project_ID"))
                    .MajorProjID = IIf(IsDBNull(rd("MajorProjID")), 0, rd("MajorProjID"))
                    .Project_Name = IIf(IsDBNull(rd("Project_Name")), "", rd("Project_Name"))
                    .Project_Code = IIf(IsDBNull(rd("Project_Code")), "", rd("Project_Code"))
                    .Program_ID = IIf(IsDBNull(rd("Program_ID")), 0, rd("Program_ID"))
                    .RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
                    .Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                    .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                    .StartDate = IIf(IsDBNull(rd("StartDate")), "", rd("StartDate"))
                    .CompletionDate = IIf(IsDBNull(rd("CompletionDate")), "", rd("CompletionDate"))
                    .ExpectedOutputs = IIf(IsDBNull(rd("ExpectedOutputs")), "", rd("ExpectedOutputs"))
                    .TotalCost = IIf(IsDBNull(rd("TotalCost")), 0.0, rd("TotalCost"))
                    .isActivity = IIf(IsDBNull(rd("isActivity")), 0, rd("isActivity"))
                    .isProject = IIf(IsDBNull(rd("isProject")), 0, rd("isProject"))
                    .PS = IIf(IsDBNull(rd("PS")), 0.0, rd("PS"))
                    .MOOE = IIf(IsDBNull(rd("MOOE")), 0.0, rd("MOOE"))
                    .CO = IIf(IsDBNull(rd("CO")), 0.0, rd("CO"))
                    .CO = IIf(IsDBNull(rd("OFE")), 0.0, rd("OFE"))
                    .status = IIf(IsDBNull(rd("status")), "", rd("status"))
                    .Objectives = IIf(IsDBNull(rd("Objectives")), "", rd("Objectives"))
                    .ProjectSeq = IIf(IsDBNull(rd("ProjectSeq")), 0, rd("ProjectSeq"))
                    .OtherOffices = IIf(IsDBNull(rd("OtherOffices")), "", rd("OtherOffices"))
                    .Prevproj_ID = IIf(IsDBNull(rd("prevproj_id")), 0, rd("prevproj_id"))
                    .Location = IIf(IsDBNull(rd("Location")), "", rd("Location"))
                    .isSC = IIf(IsDBNull(rd("isSC")), 0, rd("isSC"))
                    .isSubmit = IIf(IsDBNull(rd("isSubmit")), 0, rd("isSubmit"))
                    .isfinal = IIf(IsDBNull(rd("isfinal")), 0, rd("isfinal"))
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
