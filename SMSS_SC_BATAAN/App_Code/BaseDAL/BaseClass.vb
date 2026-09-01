Imports Microsoft.VisualBasic
Imports System.Data
Imports System
Imports System.Configuration

Namespace BaseClasses


    Public Class App_Dtl

        Private pResponsibilityCenter As String


    End Class
    Public Class DBPassUsernname
        Dim obj As New BaseDLL.BaseDAL
        Private pServerName As String
        Public Property ServerName() As String

            Get
                Dim pservername As String = obj.GetValue("use SMSS_PREMIUM Select top 1 Server from Report_Settings", Data.CommandType.Text)
                Return pservername
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        Private pDatabaseName As String
        Public Property DatabaseName() As String

            Get
                Dim pDatabaseName As String = obj.GetValue("use SMSS_PREMIUM Select top 1 [Database] from Report_Settings", Data.CommandType.Text)
                Return pDatabaseName
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        Private pusername As String
        Public Property username() As String

            Get
                Dim userid As String = obj.GetValue("use SMSS_PREMIUM Select top 1 UserName from Report_Settings", Data.CommandType.Text)
                Return userid
            End Get
            Set(ByVal value As String)

            End Set
        End Property
        Private ppass As String
        Public Property Password() As String
            Get
                Dim pasword As String = obj.GetValue("Use SMSS_PREMIUM Select top 1 Password from Report_Settings", Data.CommandType.Text)
                Return pasword
            End Get
            Set(ByVal value As String)

            End Set
        End Property
    End Class
    Public Class RC
        Inherits BaseDLL.BaseDAL


        Public Sub dbaseCon()
            conStr = ConfigurationManager.ConnectionStrings("FMSConnectionString").ToString
        End Sub
        Public Overrides Function GetRecords(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing) As System.Data.DataSet
            Return MyBase.GetRecords(strCmd, cmdType, param)
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
                Me.RC_Code = IIf(IsDBNull(rd("RC_Code")), "", rd("RC_Code"))
                Me.RC_Name = IIf(IsDBNull(rd("RC_Name")), "", rd("RC_Name"))
                Me.R_ClassID = IIf(IsDBNull(rd("R_ClassID")), 0, rd("R_ClassID"))
                Me.RCT_ID = IIf(IsDBNull(rd("RCT_ID")), 0, rd("RCT_ID"))
            End While
            If cn.State = Data.ConnectionState.Open Then
                cn.Close()
            End If

        End Function


        Private pRC_ID As Integer
        Public Property RC_ID() As Integer
            Get
                Return pRC_ID
            End Get
            Set(ByVal value As Integer)
                pRC_ID = value
            End Set
        End Property

        Private pRC_Code As String
        Public Property RC_Code() As String
            Get
                Return pRC_Code
            End Get
            Set(ByVal value As String)
                pRC_Code = value
            End Set
        End Property

        Private pRC_Name As String
        Public Property RC_Name() As String
            Get
                Return pRC_Name
            End Get
            Set(ByVal value As String)
                pRC_Name = value
            End Set
        End Property

        Private pR_ClassID As Integer
        Public Property R_ClassID() As Integer
            Get
                Return pR_ClassID
            End Get
            Set(ByVal value As Integer)
                pR_ClassID = value
            End Set
        End Property

        Private pRCT_ID As Integer
        Public Property RCT_ID() As Integer
            Get
                Return pRCT_ID
            End Get
            Set(ByVal value As Integer)
                pRCT_ID = value
            End Set
        End Property


    End Class
    Public Class Items
        Inherits BaseDLL.BaseDAL


        Public Sub dbaseCon()
            conStr = ConfigurationManager.ConnectionStrings("FMSConnectionString").ToString
        End Sub
        Private pitem_key As Integer
        Public Property item_key() As Integer
            Get
                Return pitem_key
            End Get
            Set(ByVal value As Integer)
                pitem_key = value
            End Set
        End Property

        Private pcity_key As Integer
        Public Property city_key() As Integer
            Get
                Return pcity_key
            End Get
            Set(ByVal value As Integer)
                pcity_key = value
            End Set
        End Property

        Private pitem_code As String
        Public Property item_code() As String
            Get
                Return pitem_code
            End Get
            Set(ByVal value As String)
                pitem_code = value
            End Set
        End Property

        Private pitem_desc As String
        Public Property item_desc() As String
            Get
                Return pitem_desc
            End Get
            Set(ByVal value As String)
                pitem_desc = value
            End Set
        End Property

        Private punit_cost As Decimal
        Public Property unit_cost() As Decimal
            Get
                Return punit_cost
            End Get
            Set(ByVal value As Decimal)
                punit_cost = value
            End Set
        End Property

        Private pselling_price As Decimal
        Public Property selling_price() As Decimal
            Get
                Return pselling_price
            End Get
            Set(ByVal value As Decimal)
                pselling_price = value
            End Set
        End Property

        Private pitem_usage As String
        Public Property item_usage() As String
            Get
                Return pitem_usage
            End Get
            Set(ByVal value As String)
                pitem_usage = value
            End Set
        End Property

        Private pitemclass_key As Integer
        Public Property itemclass_key() As Integer
            Get
                Return pitemclass_key
            End Get
            Set(ByVal value As Integer)
                pitemclass_key = value
            End Set
        End Property

        Private pmin_stock_level As Decimal
        Public Property min_stock_level() As Decimal
            Get
                Return pmin_stock_level
            End Get
            Set(ByVal value As Decimal)
                pmin_stock_level = value
            End Set
        End Property

        Private pmax_stock_level As Decimal
        Public Property max_stock_level() As Decimal
            Get
                Return pmax_stock_level
            End Get
            Set(ByVal value As Decimal)
                pmax_stock_level = value
            End Set
        End Property

        Private preorder_quantity As Decimal
        Public Property reorder_quantity() As Decimal
            Get
                Return preorder_quantity
            End Get
            Set(ByVal value As Decimal)
                preorder_quantity = value
            End Set
        End Property

        Private pdiscontinued As Boolean
        Public Property discontinued() As Boolean
            Get
                Return pdiscontinued
            End Get
            Set(ByVal value As Boolean)
                pdiscontinued = value
            End Set
        End Property

        Private punit_key As Integer
        Public Property unit_key() As Integer
            Get
                Return punit_key
            End Get
            Set(ByVal value As Integer)
                punit_key = value
            End Set
        End Property

        Private pcost_method As String
        Public Property cost_method() As String
            Get
                Return pcost_method
            End Get
            Set(ByVal value As String)
                pcost_method = value
            End Set
        End Property

        Private pinventory_coa_key As Integer
        Public Property inventory_coa_key() As Integer
            Get
                Return pinventory_coa_key
            End Get
            Set(ByVal value As Integer)
                pinventory_coa_key = value
            End Set
        End Property

        Private psales_coa_key As Integer
        Public Property sales_coa_key() As Integer
            Get
                Return psales_coa_key
            End Get
            Set(ByVal value As Integer)
                psales_coa_key = value
            End Set
        End Property

        Private pcgs_coa_key As Integer
        Public Property cgs_coa_key() As Integer
            Get
                Return pcgs_coa_key
            End Get
            Set(ByVal value As Integer)
                pcgs_coa_key = value
            End Set
        End Property

        Private pperishable_good As Boolean
        Public Property perishable_good() As Boolean
            Get
                Return pperishable_good
            End Get
            Set(ByVal value As Boolean)
                pperishable_good = value
            End Set
        End Property

        Private pquantity_on_hand As Decimal
        Public Property quantity_on_hand() As Decimal
            Get
                Return pquantity_on_hand
            End Get
            Set(ByVal value As Decimal)
                pquantity_on_hand = value
            End Set
        End Property

        Private pfund_key As Integer
        Public Property fund_key() As Integer
            Get
                Return pfund_key
            End Get
            Set(ByVal value As Integer)
                pfund_key = value
            End Set
        End Property

        Private pAccntID As Integer
        Public Property AccntID() As Integer
            Get
                Return pAccntID
            End Get
            Set(ByVal value As Integer)
                pAccntID = value
            End Set
        End Property

        Private pTangibleID As Integer
        Public Property TangibleID() As Integer
            Get
                Return pTangibleID
            End Get
            Set(ByVal value As Integer)
                pTangibleID = value
            End Set
        End Property

        Private pUsefulLife As Integer
        Public Property UsefulLife() As Integer
            Get
                Return pUsefulLife
            End Get
            Set(ByVal value As Integer)
                pUsefulLife = value
            End Set
        End Property

        Private pclassid As Integer
        Public Property classid() As Integer
            Get
                Return pclassid
            End Get
            Set(ByVal value As Integer)
                pclassid = value
            End Set
        End Property
    End Class



#Region "Signatory"
    Public Class Signatory
        Inherits BaseDAL

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

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.Signatory_ID = IIf(IsDBNull(rd("Signatory_ID")), 0, rd("Signatory_ID"))
                    Me.deptid = IIf(IsDBNull(rd("deptid")), 0, rd("deptid"))
                    Me.division_key = IIf(IsDBNull(rd("division_key")), 0, rd("division_key"))
                    Me.isDeptHead = IIf(IsDBNull(rd("isDeptHead")), 0, rd("isDeptHead"))
                    Me.empsig_ID = IIf(IsDBNull(rd("empsig_ID")), 0, rd("empsig_ID"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_to_signatory() As Long
            With Me
                .cmd.Parameters.AddWithValue("@Signatory_ID", 0)
                .cmd.Parameters.AddWithValue("@deptid", pdeptid)
                .cmd.Parameters.AddWithValue("@division_key", pdivision_key)
                .cmd.Parameters.AddWithValue("@isDeptHead", pisDeptHead)
                .cmd.Parameters.AddWithValue("@empsig_ID", pempsig_ID)
            End With
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[BOS].[spSave_m_Signatory]", CommandType.StoredProcedure)
        End Function

        Public Function update_signatory() As Long
            With Me
                .cmd.Parameters.AddWithValue("@Signatory_ID", pSignatory_ID)
                .cmd.Parameters.AddWithValue("@deptid", pdeptid)
                .cmd.Parameters.AddWithValue("@division_key", pdivision_key)
                .cmd.Parameters.AddWithValue("@isDeptHead", pisDeptHead)
                .cmd.Parameters.AddWithValue("@empsig_ID", pempsig_ID)
            End With
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[BOS].[spSave_m_Signatory]", CommandType.StoredProcedure)
        End Function
    End Class
#End Region
#Region "Office"
    Public Class Office
        Inherits BaseDAL

        Private pOffice_ID As Long
        Public Property Office_ID() As Long
            Get
                Return pOffice_ID
            End Get
            Set(ByVal value As Long)
                pOffice_ID = value
            End Set
        End Property

        Private pOffice_Name As String
        Public Property Office_Name() As String
            Get
                Return pOffice_Name
            End Get
            Set(ByVal value As String)
                pOffice_Name = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.Office_ID = IIf(IsDBNull(rd("Office_ID")), 0, rd("Office_ID"))
                    Me.Office_Name = IIf(IsDBNull(rd("Office_Name")), "", rd("Office_Name"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub save_office()
            Me.cmd.Parameters.AddWithValue("@Office_ID", 0)
            Me.cmd.Parameters.AddWithValue("@Office_Name", pOffice_Name)

            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[BOS].[spSave_m_Office]", CommandType.StoredProcedure)
        End Sub

        Public Sub update_office()
            Me.cmd.Parameters.AddWithValue("@Office_ID", pOffice_ID)
            Me.cmd.Parameters.AddWithValue("@Office_Name", pOffice_Name)

            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[BOS].[spSave_m_Office]", CommandType.StoredProcedure)
        End Sub

        Public Function getOfficeID() As Long
            Me.cmd.Parameters.AddWithValue("office_name", pOffice_Name)
            Dim x As Long
            x = Me.GetValue("BOS.office_getID", CommandType.StoredProcedure)
            Return x
        End Function
    End Class
#End Region
#Region "AccountClassAccounts"
    Public Class AccountClassAcounts
        Inherits BaseDAL

        Private pAllotmentClassAccount_ID As Long
        Public Property AllotmentClassAccount_ID() As Long
            Get
                Return pAllotmentClassAccount_ID
            End Get
            Set(ByVal value As Long)
                pAllotmentClassAccount_ID = value
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

        Private pBGA_ID As Long
        Public Property BGA_ID() As Long
            Get
                Return pBGA_ID
            End Get
            Set(ByVal value As Long)
                pBGA_ID = value
            End Set
        End Property

        Private pAllotmentClass_ID As Long
        Public Property AllotmentClass_ID() As Long
            Get
                Return pAllotmentClass_ID
            End Get
            Set(ByVal value As Long)
                pAllotmentClass_ID = value
            End Set
        End Property


        Private pisReserved As Boolean
        Public Property isReserved() As Boolean
            Get
                Return pisReserved
            End Get
            Set(ByVal value As Boolean)
                pisReserved = value
            End Set
        End Property

        Private pReservedPercentage As Integer
        Public Property ReservedPercentage() As Integer
            Get
                Return pReservedPercentage
            End Get
            Set(ByVal value As Integer)
                pReservedPercentage = value
            End Set
        End Property

        Private pforFullRelease As Boolean
        Public Property forFullRelease() As Boolean
            Get
                Return pforFullRelease
            End Get
            Set(ByVal value As Boolean)
                pforFullRelease = value
            End Set
        End Property

        Private pisContinuing As Boolean
        Public Property isContinuing() As Boolean
            Get
                Return pisContinuing
            End Get
            Set(ByVal value As Boolean)
                pisContinuing = value
            End Set
        End Property

        Private pforOBRCashAdvance As Boolean
        Public Property forOBRCashAdvance() As Boolean
            Get
                Return pforOBRCashAdvance
            End Get
            Set(ByVal value As Boolean)
                pforOBRCashAdvance = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    With Me
                        .AllotmentClassAccount_ID = IIf(IsDBNull(rd("AllotmentClassAccount_ID")), 0, rd("AllotmentClassAccount_ID"))
                        .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                        .BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                        .AllotmentClass_ID = IIf(IsDBNull(rd("AllotmentClass_ID")), 0, rd("AllotmentClass_ID"))
                        .AllotmentClass_ID = IIf(IsDBNull(rd("AccountCode")), 0, rd("AccountCode"))
                        .isReserved = IIf(IsDBNull(rd("isReserved")), 0, rd("isReserved"))
                        .ReservedPercentage = IIf(IsDBNull(rd("ReservedPercentage")), 0, rd("ReservedPercentage"))
                        .forFullRelease = IIf(IsDBNull(rd("forFullRelease")), 0, rd("forFullRelease"))
                        .isContinuing = IIf(IsDBNull(rd("isContinuing")), 0, rd("isContinuing"))
                        .forOBRCashAdvance = IIf(IsDBNull(rd("forOBRCashAdvance")), 0, rd("forOBRCashAdvance"))
                    End With
                End While
            Catch ex As Exception
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_to_AllotmentclassAccount() As Long
            Me.cmd.Parameters.AddWithValue("@AllotmentClassAccount_ID", 0)
            Me.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            Me.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            Me.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            Me.cmd.Parameters.AddWithValue("@isReserved", pisReserved)
            Me.cmd.Parameters.AddWithValue("@ReservedPercentage", pReservedPercentage)
            Me.cmd.Parameters.AddWithValue("@forFullRelease", pforFullRelease)
            Me.cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)
            Me.cmd.Parameters.AddWithValue("@forOBRCashAdvance", pforOBRCashAdvance)

            Execute("[dbo].[spSave_M_AllotmentClassAccount]", Data.CommandType.StoredProcedure)
        End Function

        Public Function update_allotmentclassaccounts() As Long
            Me.cmd.Parameters.AddWithValue("@AllotmentClassAccount_ID", pAllotmentClassAccount_ID)
            Me.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            Me.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            Me.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            Me.cmd.Parameters.AddWithValue("@isReserved", pisReserved)
            Me.cmd.Parameters.AddWithValue("@ReservedPercentage", pReservedPercentage)
            Me.cmd.Parameters.AddWithValue("@forFullRelease", pforFullRelease)
            Me.cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)
            Me.cmd.Parameters.AddWithValue("@forOBRCashAdvance", pforOBRCashAdvance)

            Execute("[dbo].[spSave_M_AllotmentClassAccount]", Data.CommandType.StoredProcedure)
        End Function
    End Class
#End Region
#Region "m_Emp_Signatory"
    Public Class m_Emp_Signatory
        Inherits BaseDAL

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

        Private peffectivity_date As DateTime
        Public Property effectivity_date() As DateTime
            Get
                Return peffectivity_date
            End Get
            Set(ByVal value As DateTime)
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

        Public Overrides Sub FillEntity()
            Try
                With Me
                    .empsig_id = IIf(IsDBNull(rd("empsig_id")), 0, rd("empsig_id"))
                    .position_id = IIf(IsDBNull(rd("position_id")), 0, rd("position_id"))
                    .empid = IIf(IsDBNull(rd("empid")), 0, rd("empid"))
                    .full_name = IIf(IsDBNull(rd("full_name")), "", rd("full_name"))
                    .effectivity_date = IIf(IsDBNull(rd("effectivity_date")), "", rd("effectivity_date"))
                    .position_desc = IIf(IsDBNull(rd("position_desc")), "", rd("position_desc"))
                End With
                'fill entity statements here
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Sub save()
            With Me
                .cmd.Parameters.AddWithValue("@empsig_id", 0)
                .cmd.Parameters.AddWithValue("@position_id", pposition_id)
                .cmd.Parameters.AddWithValue("@empid", pempid)
                .cmd.Parameters.AddWithValue("@full_name", pfull_name)
                .cmd.Parameters.AddWithValue("@effectivity_date", peffectivity_date)
                .cmd.Parameters.AddWithValue("@position_desc", pposition_desc)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("spSave_m_Emp_Signatory", Data.CommandType.StoredProcedure)
        End Sub

        Public Sub update()
            With Me
                .cmd.Parameters.AddWithValue("@empsig_id", pempsig_id)
                .cmd.Parameters.AddWithValue("@position_id", pposition_id)
                .cmd.Parameters.AddWithValue("@empid", pempid)
                .cmd.Parameters.AddWithValue("@full_name", pfull_name)
                .cmd.Parameters.AddWithValue("@effectivity_date", peffectivity_date)
                .cmd.Parameters.AddWithValue("@position_desc", pposition_desc)
                .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            End With

            Execute("@CurrID", "spSave_m_Emp_Signatory", Data.CommandType.StoredProcedure)
        End Sub
    End Class
#End Region



#Region "Budget General Accounts"

    Public Class BudgetGenAccounts
        Inherits BaseDAL

        Private pBGA_ID As Long
        Public Property BGA_ID() As Long
            Get
                Return pBGA_ID
            End Get
            Set(ByVal value As Long)
                pBGA_ID = value
            End Set
        End Property

        Private pBGA_Title As String
        Public Property BGA_Title() As String
            Get
                Return pBGA_Title
            End Get
            Set(ByVal value As String)
                pBGA_Title = value
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

        Private pBGA_No As String
        Public Property BGA_No() As String
            Get
                Return pBGA_No
            End Get
            Set(ByVal value As String)
                pBGA_No = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                    Me.BGA_Title = IIf(IsDBNull(rd("BGA_Title")), "", rd("BGA_Title"))
                    Me.GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                    Me.BGA_No = IIf(IsDBNull(rd("BGA_No")), "", rd("BGA_No"))
                End While
            Catch ex As Exception
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save_to_BudgetGenAccounts() As Long
            Me.cmd.Parameters.AddWithValue("@BGA_ID", 0)
            Me.cmd.Parameters.AddWithValue("@BGA_Title", pBGA_Title)
            Me.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            Me.cmd.Parameters.AddWithValue("@BGA_No", pBGA_No)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[bos].[spSave_BudgetGen_Accounts]", Data.CommandType.StoredProcedure)
        End Function

        Public Function update_BudgetGenAccounts() As Long
            Me.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            Me.cmd.Parameters.AddWithValue("@BGA_Title", pBGA_Title)
            Me.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            Me.cmd.Parameters.AddWithValue("@BGA_No", pBGA_No)
            Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

            Execute("[bos].[spSave_BudgetGen_Accounts]", Data.CommandType.StoredProcedure)
        End Function
    End Class

#End Region
#Region "Allotment Class"

    Public Class allotmentClass
        Inherits BaseDAL

        Private pAllotmentClass_ID As Integer
        Public Property AllotmentClass_ID() As Integer
            Get
                Return pAllotmentClass_ID
            End Get
            Set(ByVal value As Integer)
                pAllotmentClass_ID = value
            End Set
        End Property

        Private pAllotmentClass_Code As Integer
        Public Property AllotmentClass_Code() As Integer
            Get
                Return pAllotmentClass_Code
            End Get
            Set(ByVal value As Integer)
                pAllotmentClass_Code = value
            End Set
        End Property

        Private pAllotmentClass As String
        Public Property AllotmentClass() As String
            Get
                Return pAllotmentClass
            End Get
            Set(ByVal value As String)
                pAllotmentClass = value
            End Set
        End Property

        Public Overrides Sub FillEntity()

            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    Me.AllotmentClass_ID = IIf(IsDBNull(rd("AllotmentClass_ID")), 0, rd("AllotmentClass_ID"))
                    Me.AllotmentClass_Code = IIf(IsDBNull(rd("AllotmentClass_Code")), 0, rd("AllotmentClass_Code"))
                    Me.AllotmentClass = IIf(IsDBNull(rd("AllotmentClass")), "", rd("AllotmentClass"))
                End While
            Catch ex As Exception

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try

        End Sub
    End Class

#End Region

#Region "m_GenAccnt"

    Public Class m_GenAccnt
        Inherits BaseDAL

        Private pGA_ID As Long
        Public Property GA_ID() As Long
            Get
                Return pGA_ID
            End Get
            Set(ByVal value As Long)
                pGA_ID = value
            End Set
        End Property

        Private pGA_Code As Long
        Public Property GA_Code() As Long
            Get
                Return pGA_Code
            End Get
            Set(ByVal value As Long)
                pGA_Code = value
            End Set
        End Property

        Private pGA_Title As String
        Public Property GA_Title() As String
            Get
                Return pGA_Title
            End Get
            Set(ByVal value As String)
                pGA_Title = value
            End Set
        End Property

        Private pRev_ID As Integer
        Public Property Rev_ID() As Integer
            Get
                Return pRev_ID
            End Get
            Set(ByVal value As Integer)
                pRev_ID = value
            End Set
        End Property


        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                    GA_Code = IIf(IsDBNull(rd("GA_Code")), 0, rd("GA_Code"))
                    GA_Title = IIf(IsDBNull(rd("GA_Title")), "", rd("GA_Title"))
                    Rev_ID = IIf(IsDBNull(rd("Rev_ID")), 0, rd("Rev_ID"))
                End While
            Catch ex As Exception
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@GA_Code", GA_Code)
            objDerived.cmd.Parameters.AddWithValue("@GA_Title", GA_Title)
            objDerived.cmd.Parameters.AddWithValue("@Rev_ID", Rev_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[ACCNTG].[spSave_m_GenAccnt]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_Code", GA_Code)
            objDerived.cmd.Parameters.AddWithValue("@GA_Title", GA_Title)
            objDerived.cmd.Parameters.AddWithValue("@Rev_ID", Rev_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[ACCNTG].[spSave_m_GenAccnt]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class

#End Region
#Region "m_AllotmentClassAccount"

    Public Class m_AllotmentClassAccount
        Inherits BaseDAL


        Private pAllotmentClassAccount_ID As Long
        Public Property AllotmentClassAccount_ID() As Long
            Get
                Return pAllotmentClassAccount_ID
            End Get
            Set(ByVal value As Long)
                pAllotmentClassAccount_ID = value
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

        Private pBGA_ID As Long
        Public Property BGA_ID() As Long
            Get
                Return pBGA_ID
            End Get
            Set(ByVal value As Long)
                pBGA_ID = value
            End Set
        End Property

        Private pAllotmentClass_ID As Long
        Public Property AllotmentClass_ID() As Long
            Get
                Return pAllotmentClass_ID
            End Get
            Set(ByVal value As Long)
                pAllotmentClass_ID = value
            End Set
        End Property

        Private pisReserved As Boolean
        Public Property isReserved() As Boolean
            Get
                Return pisReserved
            End Get
            Set(ByVal value As Boolean)
                pisReserved = value
            End Set
        End Property

        Private pReservedPercentage As Integer
        Public Property ReservedPercentage() As Integer
            Get
                Return pReservedPercentage
            End Get
            Set(ByVal value As Integer)
                pReservedPercentage = value
            End Set
        End Property

        Private pforFullRelease As Boolean
        Public Property forFullRelease() As Boolean
            Get
                Return pforFullRelease
            End Get
            Set(ByVal value As Boolean)
                pforFullRelease = value
            End Set
        End Property

        Private pisContinuing As Boolean
        Public Property isContinuing() As Boolean
            Get
                Return pisContinuing
            End Get
            Set(ByVal value As Boolean)
                pisContinuing = value
            End Set
        End Property

        Private pforOBRCashAdvance As Boolean
        Public Property forOBRCashAdvance() As Boolean
            Get
                Return pforOBRCashAdvance
            End Get
            Set(ByVal value As Boolean)
                pforOBRCashAdvance = value
            End Set
        End Property

        Public Overrides Sub FillEntity()
            Try
                cn.Open()
                rd = cmd.ExecuteReader
                While rd.Read()
                    AllotmentClassAccount_ID = IIf(IsDBNull(rd("AllotmentClassAccount_ID")), 0, rd("AllotmentClassAccount_ID"))
                    GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                    BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                    AllotmentClass_ID = IIf(IsDBNull(rd("AllotmentClass_ID")), 0, rd("AllotmentClass_ID"))
                    isReserved = IIf(IsDBNull(rd("isReserved")), 0, rd("isReserved"))
                    ReservedPercentage = IIf(IsDBNull(rd("ReservedPercentage")), 0, rd("ReservedPercentage"))
                    forFullRelease = IIf(IsDBNull(rd("forFullRelease")), 0, rd("forFullRelease"))
                    isContinuing = IIf(IsDBNull(rd("isContinuing")), 0, rd("isContinuing"))
                    forOBRCashAdvance = IIf(IsDBNull(rd("forOBRCashAdvance")), 0, rd("forOBRCashAdvance"))
                End While
            Catch ex As Exception
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Sub

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@AllotmentClassAccount_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@AllotmentClass_ID", AllotmentClass_ID)
            objDerived.cmd.Parameters.AddWithValue("@isReserved", isReserved)
            objDerived.cmd.Parameters.AddWithValue("@ReservedPercentage", ReservedPercentage)
            objDerived.cmd.Parameters.AddWithValue("@forFullRelease", forFullRelease)
            objDerived.cmd.Parameters.AddWithValue("@isContinuing", isContinuing)
            objDerived.cmd.Parameters.AddWithValue("@forOBRCashAdvance", forOBRCashAdvance)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[BOS].[spSave_m_AllotmentClassAccount]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@AllotmentClassAccount_ID", AllotmentClassAccount_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
            objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
            objDerived.cmd.Parameters.AddWithValue("@AllotmentClass_ID", AllotmentClass_ID)
            objDerived.cmd.Parameters.AddWithValue("@isReserved", isReserved)
            objDerived.cmd.Parameters.AddWithValue("@ReservedPercentage", ReservedPercentage)
            objDerived.cmd.Parameters.AddWithValue("@forFullRelease", forFullRelease)
            objDerived.cmd.Parameters.AddWithValue("@isContinuing", isContinuing)
            objDerived.cmd.Parameters.AddWithValue("@forOBRCashAdvance", forOBRCashAdvance)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[BOS].[spSave_m_AllotmentClassAccount]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class

#End Region




End Namespace