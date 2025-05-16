Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class ProjectDtl
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pprojectDtl_ID As Integer
    Public Property projectDtl_ID() As Integer
        Get
            Return pprojectDtl_ID
        End Get
        Set(ByVal value As Integer)
            pprojectDtl_ID = value
        End Set
    End Property

    Private pproject_ID As Integer
    Public Property project_ID() As Integer
        Get
            Return pproject_ID
        End Get
        Set(ByVal value As Integer)
            pproject_ID = value
        End Set
    End Property

    Private pdate As DateTime
    Public Property tdate() As DateTime
        Get
            Return pdate
        End Get
        Set(ByVal value As DateTime)
            pdate = value
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

    Private pcost_ID As Integer
    Public Property cost_ID() As Integer
        Get
            Return pcost_ID
        End Get
        Set(ByVal value As Integer)
            pcost_ID = value
        End Set
    End Property

    Private pamount As Decimal
    Public Property amount() As Decimal
        Get
            Return pamount
        End Get
        Set(ByVal value As Decimal)
            pamount = value
        End Set
    End Property

    Private pSupplier_Id As Integer
    Public Property Supplier_Id() As Integer
        Get
            Return pSupplier_Id
        End Get
        Set(ByVal value As Integer)
            pSupplier_Id = value
        End Set
    End Property

    Private pTD_ID As Long
    Public Property TD_ID() As Long
        Get
            Return pTD_ID
        End Get
        Set(ByVal value As Long)
            pTD_ID = value
        End Set
    End Property








#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.projectDtl_ID = IIf(IsDBNull(rd("projectDtl_ID")), 0, rd("projectDtl_ID"))
            Me.project_ID = IIf(IsDBNull(rd("project_ID")), 0, rd("project_ID"))
            Me.tdate = IIf(IsDBNull(rd("date")), "", rd("date"))
            Me.remarks = IIf(IsDBNull(rd("remarks")), "", rd("remarks"))
            Me.cost_ID = IIf(IsDBNull(rd("cost_ID")), 0, rd("cost_ID"))
            Me.amount = IIf(IsDBNull(rd("amount")), 0.0, rd("amount"))
            Me.Supplier_Id = IIf(IsDBNull(rd("Supplier_Id")), 0, rd("Supplier_Id"))
            Me.TD_ID = IIf(IsDBNull(rd("TD_ID")), 0, rd("TD_ID"))





        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Sub saveProjectDtl()
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@projectDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@project_ID", project_ID)
        objDerived.cmd.Parameters.AddWithValue("@date", tdate)
        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@cost_ID", cost_ID)
        objDerived.cmd.Parameters.AddWithValue("@amount", amount)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@TD_ID", TD_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Project_Dtl", CommandType.StoredProcedure, Nothing)
    End Sub
End Class
