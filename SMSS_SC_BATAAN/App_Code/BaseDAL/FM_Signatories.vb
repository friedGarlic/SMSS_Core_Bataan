Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Namespace FM_Signatories

#Region "m_Signatory"

    Public Class m_Signatory
        Inherits BaseDLL.BaseDAL

        Private pSignatory_ID As Long
        Public Property Signatory_ID() As Long
            Get
                Return pSignatory_ID
            End Get
            Set(ByVal value As Long)
                pSignatory_ID = value
            End Set
        End Property

        Private pdeptid As Integer
        Public Property deptid() As Integer
            Get
                Return pdeptid
            End Get
            Set(ByVal value As Integer)
                pdeptid = value
            End Set
        End Property

        Private pdivision_key As Integer
        Public Property division_key() As Integer
            Get
                Return pdivision_key
            End Get
            Set(ByVal value As Integer)
                pdivision_key = value
            End Set
        End Property

        Private pisDeptHead As Boolean
        Public Property isDeptHead() As Boolean
            Get
                Return pisDeptHead
            End Get
            Set(ByVal value As Boolean)
                pisDeptHead = value
            End Set
        End Property

        Private pempsig_ID As Long
        Public Property empsig_ID() As Long
            Get
                Return pempsig_ID
            End Get
            Set(ByVal value As Long)
                pempsig_ID = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Signatory_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
            objDerived.cmd.Parameters.AddWithValue("@division_key", division_key)
            objDerived.cmd.Parameters.AddWithValue("@isDeptHead", isDeptHead)
            objDerived.cmd.Parameters.AddWithValue("@empsig_ID", empsig_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[BOS].[spSave_m_Signatory]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region

#Region "m_Emp_Signatory"

    Public Class m_Emp_Signatory
        Inherits BaseDLL.BaseDAL

        Private pempsig_id As Long
        Public Property empsig_id() As Long
            Get
                Return pempsig_id
            End Get
            Set(ByVal value As Long)
                pempsig_id = value
            End Set
        End Property

        Private pposition_id As Long
        Public Property position_id() As Long
            Get
                Return pposition_id
            End Get
            Set(ByVal value As Long)
                pposition_id = value
            End Set
        End Property

        Private pempid As Long
        Public Property empid() As Long
            Get
                Return pempid
            End Get
            Set(ByVal value As Long)
                pempid = value
            End Set
        End Property

        Private pfull_name As String
        Public Property full_name() As String
            Get
                Return pfull_name
            End Get
            Set(ByVal value As String)
                pfull_name = value
            End Set
        End Property

        Private peffectivity_date As Date
        Public Property effectivity_date() As Date
            Get
                Return peffectivity_date
            End Get
            Set(ByVal value As Date)
                peffectivity_date = value
            End Set
        End Property

        Private pposition_desc As String
        Public Property position_desc() As String
            Get
                Return pposition_desc
            End Get
            Set(ByVal value As String)
                pposition_desc = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@empsig_id", 0)
            objDerived.cmd.Parameters.AddWithValue("@position_id", position_id)
            objDerived.cmd.Parameters.AddWithValue("@empid", empid)
            objDerived.cmd.Parameters.AddWithValue("@full_name", full_name)
            objDerived.cmd.Parameters.AddWithValue("@effectivity_date", effectivity_date)
            objDerived.cmd.Parameters.AddWithValue("@position_desc", position_desc)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[BOS].[spSave_m_Emp_Signatory]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region

#Region "pay_m_emp_payroll_info"

    Public Class pay_m_emp_payroll_info
        Inherits BaseDLL.BaseDAL

        Private pempid As Long
        Public Property empid() As Long
            Get
                Return pempid
            End Get
            Set(ByVal value As Long)
                pempid = value
            End Set
        End Property


        Private pdeptid As Long
        Public Property deptid() As Long
            Get
                Return pdeptid
            End Get
            Set(ByVal value As Long)
                pdeptid = value
            End Set
        End Property

        Private pdivision_key As Long
        Public Property division_key() As Long
            Get
                Return pdivision_key
            End Get
            Set(ByVal value As Long)
                pdivision_key = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
        
            objDerived.cmd.Parameters.AddWithValue("@empid", 0)
            objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
            objDerived.cmd.Parameters.AddWithValue("@division_key", division_key)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[Save_pay_m_emp_payroll_info]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region

#Region "BAC_Members"

    Public Class BAC_Members
        Inherits BaseDLL.BaseDAL

        Private pid As Long
        Public Property id() As Long
            Get
                Return pid
            End Get
            Set(ByVal value As Long)
                pid = value
            End Set
        End Property

        Private pName As String
        Public Property Name() As String
            Get
                Return pName
            End Get
            Set(ByVal value As String)
                pName = value
            End Set
        End Property

        Private pBAC_PostionID As Integer
        Public Property BAC_PostionID() As Integer
            Get
                Return pBAC_PostionID
            End Get
            Set(ByVal value As Integer)
                pBAC_PostionID = value
            End Set
        End Property


        Private pisPublicInfra As Boolean
        Public Property isPublicInfra() As Boolean
            Get
                Return pisPublicInfra
            End Get
            Set(ByVal value As Boolean)
                pisPublicInfra = value
            End Set
        End Property

        Private pisActive As Boolean
        Public Property isActive() As Boolean
            Get
                Return pisActive
            End Get
            Set(ByVal value As Boolean)
                pisActive = value
            End Set
        End Property


        Private pisDefault As Boolean
        Public Property isDefault() As Boolean
            Get
                Return pisDefault
            End Get
            Set(ByVal value As Boolean)
                pisDefault = value
            End Set
        End Property
        Private pPosition As String
        Public Property Position() As String
            Get
                Return pPosition
            End Get
            Set(ByVal value As String)
                pPosition = value
            End Set
        End Property

        Private pempsig_id As Long
        Public Property empsig_id() As Long
            Get
                Return pempsig_id
            End Get
            Set(ByVal value As Long)
                pempsig_id = value
            End Set
        End Property

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@id", id)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@BAC_PostionID", BAC_PostionID)
            objDerived.cmd.Parameters.AddWithValue("@isPublicInfra", isPublicInfra)
            objDerived.cmd.Parameters.AddWithValue("@Position", Position)
            objDerived.cmd.Parameters.AddWithValue("@empsig_id", empsig_id)
            objDerived.cmd.Parameters.AddWithValue("@isActive", isActive)
            objDerived.cmd.Parameters.AddWithValue("@isDefault", isDefault)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[Save_BACMembers]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@id", 0)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@BAC_PostionID", BAC_PostionID)
            objDerived.cmd.Parameters.AddWithValue("@isPublicInfra", isPublicInfra)
            objDerived.cmd.Parameters.AddWithValue("@Position", Position)
            objDerived.cmd.Parameters.AddWithValue("@empsig_id", empsig_id)
            objDerived.cmd.Parameters.AddWithValue("@isActive", isActive)
            objDerived.cmd.Parameters.AddWithValue("@isDefault", isDefault)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[Save_BACMembers]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region


#Region "TbDisposal_Committee_Members"

    Public Class TbDisposal_Committee_Members
        Inherits BaseDLL.BaseDAL

        Private pDC_ID As Long
        Public Property DC_ID() As Long
            Get
                Return pDC_ID
            End Get
            Set(ByVal value As Long)
                pDC_ID = value
            End Set
        End Property

        Private pName As String
        Public Property Name() As String
            Get
                Return pName
            End Get
            Set(ByVal value As String)
                pName = value
            End Set
        End Property

        Private pDC_position_id As Long
        Public Property DC_position_id() As Long
            Get
                Return pDC_position_id
            End Get
            Set(ByVal value As Long)
                pDC_position_id = value
            End Set
        End Property

        Private pDepartment As String
        Public Property Department() As String
            Get
                Return pDepartment
            End Get
            Set(ByVal value As String)
                pDepartment = value
            End Set
        End Property

        Private pempsig_id As Long
        Public Property empsig_id() As Long
            Get
                Return pempsig_id
            End Get
            Set(ByVal value As Long)
                pempsig_id = value
            End Set
        End Property

        Private status_id As Long
        Public Property Status() As Long
            Get
                Return status_id
            End Get
            Set(ByVal value As Long)
                status_id = value
            End Set
        End Property

        Private status_Description As String
        Public Property Status_Desc() As String
            Get
                Return status_Description
            End Get
            Set(ByVal value As String)
                status_Description = value
            End Set
        End Property




        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DC_ID", DC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@DC_position_id", DC_position_id)
            objDerived.cmd.Parameters.AddWithValue("@Department", Department)
            objDerived.cmd.Parameters.AddWithValue("@empsig_id", empsig_id)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Status_Description", Status_Desc)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[Save_TbDisposal_Committee_Members]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            'objDerived.cmd.Parameters.AddWithValue("@DC_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Name", Name)
            objDerived.cmd.Parameters.AddWithValue("@DC_position_id", DC_position_id)
            objDerived.cmd.Parameters.AddWithValue("@Department", Department)
            objDerived.cmd.Parameters.AddWithValue("@empsig_id", empsig_id)
            objDerived.cmd.Parameters.AddWithValue("@Status", status_id)
            objDerived.cmd.Parameters.AddWithValue("@Status_Description", status_Description)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[Save_TbDisposal_Committee_Members]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region
End Namespace
