Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class filemaintenance_t_Department
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule

    Dim Dept As New BOSS.Office
    Dim Funct As New BOSS.m_Function
    Dim mFPO As New BOSS.Function_per_Office


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT Sector_ID, Sector_Desc FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Sector as m_Sector", CommandType.Text)
            ddSector.DataSource = dt
            ddSector.DataTextField = ("Sector_Desc")
            ddSector.DataValueField = ("Sector_ID")
            ddSector.DataBind()
            ddSector.Items.Insert(0, "Select")

            ddSubSector.Items.Insert(0, "Select")

            LoadOfficeList()
            Session("Update_Dept") = 0

        End If
    End Sub

    Protected Sub LoadOfficeList()
        Dim dtDept As New DataTable
        dtDept = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_Department] ORDER BY RC_Name", CommandType.Text)
        grdDepartments.DataSource = dtDept
        grdDepartments.DataBind()
    End Sub

    Protected Sub ddSector_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT * FROM LnkdSrvrBOSS.GEOBOS.BOS.m_SubSector as m_SubSector WHERE Sector_ID = '" & ddSector.SelectedItem.Value & "'", CommandType.Text)
        ddSubSector.DataSource = dt
        ddSubSector.DataTextField = ("SubSector_Name")
        ddSubSector.DataValueField = ("SubSector_ID")
        ddSubSector.DataBind()
        ddSubSector.Items.Insert(0, "Select")

        If dt.Rows.Count = 0 Then
            Session("SubSector_ID") = 0
        End If

    End Sub

    Protected Sub ddSubSector_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("SubSector_ID") = ddSubSector.SelectedItem.Value
    End Sub

    Protected Sub grdDepartments_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Update_Dept") = 1

        txtDeparment.Text = grdDepartments.SelectedDataKey("RC_Name")
        txtAbbr.Text = grdDepartments.SelectedDataKey("Office_Ab")
        txtCode.Text = grdDepartments.SelectedDataKey("Office_Code")

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT Sector_ID, Sector_Desc FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Sector as m_Sector", CommandType.Text)
        ddSector.DataSource = dt
        ddSector.DataTextField = ("Sector_Desc")
        ddSector.DataValueField = ("Sector_ID")
        ddSector.DataBind()
        ddSector.Items.Insert(0, "Select")



        If Not IsDBNull(grdDepartments.SelectedDataKey("Sector_ID")) Then
            Dim sectorID As String = grdDepartments.SelectedDataKey("Sector_ID").ToString()
            If ddSector.Items.FindByValue(sectorID) IsNot Nothing Then
                ddSector.SelectedValue = sectorID
            End If
        End If

        btnSave.Text = "UPDATE OFFICE"


    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If txtDeparment.Text = "" Or txtAbbr.Text = "" Or ddSector.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up necessary fields.")
                Exit Sub

            Else
                If Session("Update_Dept") = 1 Then '=== UPDATE DEPARTMENT

                    '== UPDATE m_office
                    With Dept
                        .Office_ID = grdDepartments.SelectedDataKey("RC_ID")
                        .Office_Name = txtDeparment.Text
                        .Office_Ab = txtAbbr.Text
                        .UserID = Session("@UserName")
                        .update()
                    End With

                    '== UPDATE m_Function_per_Office
                    With mFPO
                        .Func_per_Office_ID = grdDepartments.SelectedDataKey("Func_per_Office_ID")
                        .Office_ID = grdDepartments.SelectedDataKey("RC_ID")
                        .Function_ID = 86
                        .Office_Code = txtCode.Text
                        .Sector_ID = ddSector.SelectedItem.Value
                        If ddSubSector.SelectedItem.Text = "Select" Then
                            .SubSector_ID = 0
                        Else
                            .SubSector_ID = ddSubSector.SelectedItem.Value
                        End If

                        .F_ID = 1
                        .isBR = False
                        .isNationalOffice = False
                        .F_ID_Accntg = 4
                        .UserID = Session("@UserName")
                        .update()
                    End With

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Department has been successfully updated.")
                    loadRefresh()


                Else '=== SAVE NEW DEPARTMENT

                    '== SAVE m_office
                    With Dept
                        .Office_Name = txtDeparment.Text
                        .Office_Ab = txtAbbr.Text
                        .UserID = Session("@UserName")
                    End With
                    Dept.save
                    Dim RC_ID As Long = objDerived.getvalue("select max(Office_id) from geobos.bos.m_office", commandtype.text)
                    'objDerived.GetValue("SELECT MAX(Office_ID) FROM BOS.m_Office", CommandType.Text)

                    ''== SAVE m_function
                    'With Funct
                    '    .Function_Desc = ""
                    '    .Function_Abb = ""
                    '    .UserID = ""
                    'End With
                    'Dim Function_ID As Long = Funct.save

                    '== SAVE m_Function_per_Office
                    With mFPO
                        .Office_ID = RC_ID
                        .Function_ID = 86
                        .Office_Code = txtCode.Text
                        .Sector_ID = ddSector.SelectedItem.Value
                        If ddSubSector.SelectedItem.Text = "Select" Then
                            .SubSector_ID = 0
                        Else
                            .SubSector_ID = ddSubSector.SelectedItem.Value
                        End If

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

            btnSave.Text = "SAVE OFFICE"
        Catch ex As Exception
            msgbox(ex.message)
        End Try
    End Sub

    Protected Sub loadRefresh()
        txtDeparment.Text = ""
        txtAbbr.Text = ""
        txtCode.Text = ""

        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT Sector_ID, Sector_Desc FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Sector as m_Sector", CommandType.Text)
        ddSector.DataSource = dt
        ddSector.DataTextField = ("Sector_Desc")
        ddSector.DataValueField = ("Sector_ID")
        ddSector.DataBind()
        ddSector.Items.Insert(0, "Select")

        ddSubSector.ClearSelection()
        ddSubSector.Items.Insert(0, "Select")

        LoadOfficeList()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/filemaintenance/t_Department.aspx")
    End Sub

    Protected Sub grdDepartments_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtDept As New DataTable
        dtDept = objDerived.GetDataTable("SELECT * FROM [dbo].[View_FM_Department] ORDER BY RC_Name", CommandType.Text)
        grdDepartments.DataSource = dtDept
        grdDepartments.PageIndex = e.NewPageIndex
        grdDepartments.DataBind()
    End Sub
End Class
