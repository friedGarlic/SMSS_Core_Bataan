Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class filemaintenance_boss_function
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule

    Dim Funct As New BOSS.m_Function
    Dim mFPO As New BOSS.Function_per_Office

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_Department] ORDER BY RC_Name", CommandType.Text)
            ddDepartment.DataSource = dt
            ddDepartment.DataTextField = ("Office_Name")
            ddDepartment.DataValueField = ("RC_ID")
            ddDepartment.DataBind()
            ddDepartment.Items.Insert(0, "Select")

            grdFunctions.DataSource = Nothing
            grdFunctions.DataBind()

            Session("Update_Funct") = 0

        End If
    End Sub
    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Update_Funct") = 0

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_DepartmentFunction] WHERE RC_ID = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
        grdFunctions.DataSource = dt
        grdFunctions.DataBind()
        grdFunctions.SelectedIndex = -1


        txtFunction.Text = ""
        txtAbbr.Text = ""
        txtCode.Text = ""

    End Sub
    Protected Sub grdFunctions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        txtFunction.Text = grdFunctions.SelectedDataKey("Function_Desc")
        txtAbbr.Text = grdFunctions.SelectedDataKey("Function_Abb")
        txtCode.Text = grdFunctions.SelectedDataKey("Office_Code")

        Session("Update_Funct") = 1
    End Sub



    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddDepartment.SelectedItem.Text = "Select" Or txtFunction.Text = "" Or txtAbbr.Text = "" Or txtCode.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up necessary fields.")
            Exit Sub

        Else
            If Session("Update_Funct") = 1 Then '=== UPDATE FUNCTION
                '== UPDATE m_function
                With Funct
                    .Function_ID = grdFunctions.SelectedDataKey("Function_ID")
                    .Function_Desc = txtFunction.Text
                    .Function_Abb = txtAbbr.Text
                    .UserID = Session("@UserName")
                    .update()
                End With

                '== UPDATE m_Function_per_Office
                With mFPO
                    .Func_per_Office_ID = grdFunctions.SelectedDataKey("Func_per_Office_ID")
                    .Office_ID = grdFunctions.SelectedDataKey("RC_ID")
                    .Function_ID = grdFunctions.SelectedDataKey("Function_ID")
                    .Office_Code = txtCode.Text
                    .Sector_ID = objDerived.GetValue("SELECT Sector_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office WHERE Office_ID = '" & grdFunctions.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                    .SubSector_ID = objDerived.GetValue("SELECT SubSector_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office WHERE Office_ID = '" & grdFunctions.SelectedDataKey("RC_ID") & "'", CommandType.Text)
                    .F_ID = 1
                    .isBR = False
                    .isNationalOffice = False
                    .F_ID_Accntg = 4
                    .UserID = Session("@UserName")
                    .update()
                End With

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Function has been successfully updated.")
                loadRefresh()

            ElseIf Session("Update_Funct") = 0 Then '=== SAVE NEW FUNCTION
                '== SAVE m_function
                With Funct
                    .Function_Desc = txtFunction.Text
                    .Function_Abb = txtAbbr.Text
                    .UserID = Session("@UserName")
                End With
                Dim Function_ID As Long = Funct.save


                '== SAVE m_Function_per_Office
                With mFPO
                    .Office_ID = ddDepartment.SelectedItem.Value
                    .Function_ID = Function_ID
                    .Office_Code = txtCode.Text
                    .Sector_ID = objDerived.GetValue("SELECT Sector_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office AS m_Function_per_Office WHERE Office_ID = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
                    .SubSector_ID = objDerived.GetValue("SELECT SubSector_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office  AS m_Function_per_Office WHERE Office_ID = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
                    .F_ID = 1
                    .isBR = False
                    .isNationalOffice = False
                    .F_ID_Accntg = 4
                    .UserID = Session("@UserName")
                    .save()
                End With

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                loadRefresh()

            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/filemaintenance/boss_function.aspx")
        BtnSave.text = "SAVE FUNCTION"
    End Sub

    Protected Sub loadRefresh()
        txtFunction.Text = ""
        txtAbbr.Text = ""
        txtCode.Text = ""

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_DepartmentFunction] WHERE RC_ID = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
        grdFunctions.DataSource = dt
        grdFunctions.DataBind()

    End Sub




End Class
