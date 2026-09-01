Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class Cost
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pCost_ID As Integer
    Public Property Cost_ID() As Integer
        Get
            Return pCost_ID
        End Get
        Set(ByVal value As Integer)
            pCost_ID = value
        End Set
    End Property

    Private pDirectMaterial As Decimal
    Public Property DirectMaterial() As Decimal
        Get
            Return pDirectMaterial
        End Get
        Set(ByVal value As Decimal)
            pDirectMaterial = value
        End Set
    End Property

    Private pEquipment As Decimal
    Public Property Equipment() As Decimal
        Get
            Return pEquipment
        End Get
        Set(ByVal value As Decimal)
            pEquipment = value
        End Set
    End Property

    Private pOther As Decimal
    Public Property Other() As Decimal
        Get
            Return pOther
        End Get
        Set(ByVal value As Decimal)
            pOther = value
        End Set
    End Property


#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()

            Me.Cost_ID = IIf(IsDBNull(rd("Cost_ID")), 0, rd("Cost_ID"))
            Me.DirectMaterial = IIf(IsDBNull(rd("DirectMaterial")), 0.0, rd("DirectMaterial"))
            Me.Equipment = IIf(IsDBNull(rd("Equipment")), 0.0, rd("Equipment"))
            Me.Other = IIf(IsDBNull(rd("Other")), 0.0, rd("Other"))



        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function saveCost() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Cost_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@DirectMaterial", DirectMaterial)
        objDerived.cmd.Parameters.AddWithValue("@Equipment", Equipment)
        objDerived.cmd.Parameters.AddWithValue("@Other", Other)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_Cost_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
