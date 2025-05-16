Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class ProjectHdr
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pProject_ID As Integer
    Public Property Project_ID() As Integer
        Get
            Return pProject_ID
        End Get
        Set(ByVal value As Integer)
            pProject_ID = value
        End Set
    End Property

    Private pProj_Name As String
    Public Property Proj_Name() As String
        Get
            Return pProj_Name
        End Get
        Set(ByVal value As String)
            pProj_Name = value
        End Set
    End Property

    Private pStart_Date As DateTime
    Public Property Start_Date() As DateTime
        Get
            Return pStart_Date
        End Get
        Set(ByVal value As DateTime)
            pStart_Date = value
        End Set
    End Property

    Private pEndDate As DateTime
    Public Property EndDate() As DateTime
        Get
            Return pEndDate
        End Get
        Set(ByVal value As DateTime)
            pEndDate = value
        End Set
    End Property

    Private pProj_Cost As Decimal
    Public Property Proj_Cost() As Decimal
        Get
            Return pProj_Cost
        End Get
        Set(ByVal value As Decimal)
            pProj_Cost = value
        End Set
    End Property

    Private pFund_ID As String
    Public Property Fund_ID() As String
        Get
            Return pFund_ID
        End Get
        Set(ByVal value As String)
            pFund_ID = value
        End Set
    End Property

    Private pStatus As Decimal
    Public Property Status() As Decimal
        Get
            Return pStatus
        End Get
        Set(ByVal value As Decimal)
            pStatus = value
        End Set
    End Property

    Private pcontractorID As Long
    Public Property contractorID() As Long
        Get
            Return pcontractorID
        End Get
        Set(ByVal value As Long)
            pcontractorID = value
        End Set
    End Property

    Private premarks As String
    Public Property remarks() As String
        Get
            Return premarks
        End Get
        Set(ByVal value As String)
            premarks = value
        End Set
    End Property

    Private pGA_code As Integer
    Public Property GA_code() As Integer
        Get
            Return pGA_code
        End Get
        Set(ByVal value As Integer)
            pGA_code = value
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









#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()

            Me.Project_ID = IIf(IsDBNull(rd("Project_ID")), 0, rd("Project_ID"))
            Me.Proj_Name = IIf(IsDBNull(rd("Proj_Name")), "", rd("Proj_Name"))
            Me.Start_Date = IIf(IsDBNull(rd("Start_Date")), "", rd("Start_Date"))
            Me.EndDate = IIf(IsDBNull(rd("EndDate")), "", rd("EndDate"))
            Me.Proj_Cost = IIf(IsDBNull(rd("Proj_Cost")), 0.0, rd("Proj_Cost"))
            Me.Fund_ID = IIf(IsDBNull(rd("Fund_ID")), "", rd("Fund_ID"))
            Me.Status = IIf(IsDBNull(rd("Status")), 0.0, rd("Status"))
            Me.contractorID = IIf(IsDBNull(rd("contractorID")), 0, rd("contractorID"))
            Me.remarks = IIf(IsDBNull(rd("remarks")), "", rd("remarks"))
            Me.GA_code = IIf(IsDBNull(rd("GA_code")), 0, rd("GA_code"))
            Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))

        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function saveProjectHdr() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Project_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Proj_Name", Proj_Name)
        objDerived.cmd.Parameters.AddWithValue("@Start_Date", Start_Date)
        objDerived.cmd.Parameters.AddWithValue("@EndDate", EndDate)
        objDerived.cmd.Parameters.AddWithValue("@Proj_Cost", Proj_Cost)
        objDerived.cmd.Parameters.AddWithValue("@Fund_ID", Fund_ID)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@contractorID", contractorID)
        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@GA_code", GA_code)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Project_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
