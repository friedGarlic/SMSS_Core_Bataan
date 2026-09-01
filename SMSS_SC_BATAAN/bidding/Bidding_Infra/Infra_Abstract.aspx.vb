Imports System.Data
Partial Class bidding_Bidding_Infra_Infra_Abstract
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal

    Private Infra_Hdr As New Bidding_Infra.tb_Infra_Hdr
    Private Infra_Dtl As New Bidding_Infra.tb_Infra_Dtl
    Private Property dtOBR() As DataTable
        Get
            Return CType(Session("dtOBR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtOBR") = value
        End Set
    End Property

    Public Function CreateTable_Bidders(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("BidAmount", GetType(Decimal))
        dt.Columns.Add("Winner", GetType(String))
        dt.Columns.Add("Infra_Hdr_ID", GetType(Long))
        dt.Columns.Add("Infra_Dtl_ID", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("Supplier_ID", GetType(Integer))
        dt.Columns.Add("OBR_Hdr_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = DBNull.Value
            dr("BidAmount") = DBNull.Value
            dr("Winner") = DBNull.Value
            dr("Infra_Hdr_ID") = DBNull.Value
            dr("Infra_Dtl_ID") = DBNull.Value
            dr("isVisible") = False
            dr("Supplier_ID") = DBNull.Value
            dr("OBR_Hdr_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Sub bidding_Bidding_Infra_Infra_Abstract_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            dtOBR = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_OBR_ProjectList]", CommandType.Text)
            grdInfaOBR.DataSource = dtOBR
            grdInfaOBR.DataBind()

            grdBidders.DataSource = CreateTable_Bidders(3)
            grdBidders.DataBind()

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

        txtBidAmount.Attributes.Add("onChange", "this.value = formatCurrency(this.value);")
        txtRequiredBidSec.Attributes.Add("onChange", "this.value = formatCurrency(this.value);")
        txtBidSecurityAmt.Attributes.Add("onChange", "this.value = formatCurrency(this.value);")

    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtOBR.DefaultView

        If drpSearch.SelectedItem.Value = 1 Then
            myview.RowFilter = "OBR_No like '%" & txtSearch.Text & "%'"
        ElseIf drpSearch.SelectedItem.Value = 2 Then
            myview.RowFilter = "PPA like '%" & txtSearch.Text & "%'"
        End If


        grdInfaOBR.DataSource = myview
        grdInfaOBR.DataBind()
    End Sub

    Protected Sub lnkSelect_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub grdInfaOBR_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdInfaOBR.PageIndexChanging
        grdInfaOBR.DataSource = dtOBR
        grdInfaOBR.PageIndex = e.NewPageIndex
        grdInfaOBR.DataBind()

    End Sub

    Private Sub grdInfaOBR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdInfaOBR.SelectedIndexChanged
        Try
            txtBidAmount.Text = FormatNumber(grdInfaOBR.SelectedDataKey("TotalAmount"), 2)

            drpBidders.DataSource = objDerived.GetDataTable("SELECT * FROM DBO.Supplier ORDER BY SuppName", CommandType.Text)
            drpBidders.DataTextField = "SuppName"
            drpBidders.DataValueField = "Supplier_ID"
            drpBidders.DataBind()
            drpBidders.Items.Insert(0, "Select")

            btnAddBidder.Enabled = True

            txtBidDate.Text = Date.Today.ToString("MM/dd/yyyy")

            LoadBidders()

            If grdBidders.Rows.Count > 0 Then
                btnSave.Enabled = True

                LoadBACSignatories()

            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, pls contact system admin.")

        End Try

    End Sub
    Protected Sub LoadBidders()
        Dim dt As New DataTable
        dt = objDerived.GetDataTable("SELECT B.Supplier_ID, C.SuppName, B.BidAmount, A.OBR_Hdr_ID, A.Infra_Hdr_ID, B.Infra_Dtl_ID, CASE WHEN ISNULL(B.isWinner,0) = 0 THEN 'No' ELSE 'Yes' END AS Winner, CONVERT(BIT,1) AS isVisible " &
                                      " FROM AMS.tb_Infra_Hdr AS  A INNER JOIN AMS.tb_Infra_Dtl AS B ON A.Infra_Hdr_ID = B.Infra_Hdr_ID " &
                                      " INNER JOIN DBO.Supplier AS C ON B.Supplier_ID = C.Supplier_Id " &
                                      " WHERE A.OBR_Hdr_ID = " & grdInfaOBR.SelectedDataKey("OBR_Hdr_ID") & "", CommandType.Text)
        If dt.Rows.Count < 4 Then
            dt.Merge(CreateTable_Bidders(3 - dt.Rows.Count))
        End If
        grdBidders.DataSource = dt
        grdBidders.DataBind()
    End Sub

    Protected Sub LoadBACSignatories()
        drpBAC1.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_BAC WHERE isDefault = 1 AND BAC_PostionID = 3", CommandType.Text)
        drpBAC1.DataTextField = "Name"
        drpBAC1.DataValueField = "empsig_id"
        drpBAC1.DataBind()
        'drpBAC1.Items.Insert(0, "Selcet")

        drpBAC2.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_BAC WHERE isDefault = 1 AND BAC_PostionID = 4", CommandType.Text)
        drpBAC2.DataTextField = "Name"
        drpBAC2.DataValueField = "empsig_id"
        drpBAC2.DataBind()
        'drpBAC2.Items.Insert(0, "Selcet")

        drpBAC3.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_BAC WHERE isDefault = 1 AND BAC_PostionID = 5", CommandType.Text)
        drpBAC3.DataTextField = "Name"
        drpBAC3.DataValueField = "empsig_id"
        drpBAC3.DataBind()
        'drpBAC3.Items.Insert(0, "Selcet")

        drpBAC4.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_BAC WHERE isDefault = 1 AND BAC_PostionID = 15", CommandType.Text)
        drpBAC4.DataTextField = "Name"
        drpBAC4.DataValueField = "empsig_id"
        drpBAC4.DataBind()
        'drpBAC4.Items.Insert(0, "Selcet")

        drpBACVC.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_BAC WHERE isDefault = 1 AND BAC_PostionID = 2", CommandType.Text)
        drpBACVC.DataTextField = "Name"
        drpBACVC.DataValueField = "empsig_id"
        drpBACVC.DataBind()
        'drpBACVC.Items.Insert(0, "Selcet")

        drpBACC.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_BAC WHERE isDefault = 1 AND BAC_PostionID = 1", CommandType.Text)
        drpBACC.DataTextField = "Name"
        drpBACC.DataValueField = "empsig_id"
        drpBACC.DataBind()
        'drpBACC.Items.Insert(0, "Selcet")

        drpBAC_TWG.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_BAC WHERE isDefault = 1 AND BAC_PostionID = 12", CommandType.Text)
        drpBAC_TWG.DataTextField = "Name"
        drpBAC_TWG.DataValueField = "empsig_id"
        drpBAC_TWG.DataBind()
        'drpBAC_TWG.Items.Insert(0, "Selcet")

        drpEndUser.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & grdInfaOBR.SelectedDataKey("RC_ID") & "' AND division_Key = '" & grdInfaOBR.SelectedDataKey("Function_ID") & "'  ORDER BY Full_Name", CommandType.Text)
        drpEndUser.DataTextField = "Full_Name"
        drpEndUser.DataValueField = "EmpID"
        drpEndUser.DataBind()
        drpEndUser.Items.Insert(0, "Select")

    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub btnAddBidder_Click(sender As Object, e As EventArgs) Handles btnAddBidder.Click
        If drpBidders.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "There is no selected bidder.")
        Else
            Try
                '==== Save AMS.tb_Infra_Hdr
                Dim Hdr_ID As Integer
                Hdr_ID = objDerived.GetValue("SELECT Infra_Hdr_ID FROM AMS.tb_Infra_Hdr WHERE OBR_Hdr_ID = " & grdInfaOBR.SelectedDataKey("OBR_Hdr_ID") & "", CommandType.Text)

                If Hdr_ID = 0 Then
                    With Infra_Hdr
                        .InfraDate = txtDate.Text
                        .OBR_Hdr_ID = grdInfaOBR.SelectedDataKey("OBR_Hdr_ID")
                        .OBR_No = grdInfaOBR.SelectedDataKey("OBR_No")
                        .ApprovedBudget = grdInfaOBR.SelectedDataKey("TotalAmount")
                        .RC_ID = grdInfaOBR.SelectedDataKey("RC_ID")
                        .Function_ID = grdInfaOBR.SelectedDataKey("Function_ID")
                        .Program_ID = grdInfaOBR.SelectedDataKey("Program_ID")
                        .Project_ID = grdInfaOBR.SelectedDataKey("Project_ID")
                        .ProjectName = grdInfaOBR.SelectedDataKey("PPA")
                        .ProjectLocation = replaceapostrophe(txtProjectLocation.Text)
                        .BidPlace = replaceapostrophe(txtBidPlace.Text)
                        .BidTime = txtBidTime.Text
                        .ResolutionNo = ""
                        .isFinal = False
                        .withNOA = False
                        .withNTP = False

                    End With

                    Hdr_ID = Infra_Hdr.save()

                End If

                '==== Save AMS.tb_Infra_Dtl
                With Infra_Dtl
                    .Infra_Hdr_ID = Hdr_ID
                    .isWinner = False
                    .Supplier_ID = drpBidders.SelectedItem.Value
                    .BidAmount = txtBidAmount.Text
                    .TimeDuration = txtTimeDuration.Text
                    .BidSecurity = txtBidSecurityForm.Text
                    .Bank_Campany = txtBankCampany.Text
                    .Number = txtNumber.Text
                    .ValidityPeriod = txtValidityPeriod.Text
                    .BidSecurity_Amount = txtBidSecurityAmt.Text
                    .Required_BidSecurity = txtRequiredBidSec.Text
                    .Sufficient_InSufficient = ddSufficient.SelectedItem.Text
                    .Remarks = txtRemarks.Text
                End With

                If btnAddBidder.Text = "Update" Then
                    Infra_Dtl.Infra_Dtl_ID = grdBidders.SelectedDataKey("Infra_Dtl_ID")
                    Infra_Dtl.update()
                Else
                    Infra_Dtl.save()
                End If

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


                LoadBidders()
                LoadClearfields()
                LoadBACSignatories()

            Catch ex As Exception
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, plss contact system admin.")
            End Try

        End If


    End Sub

    Protected Sub LoadClearfields()
        txtTimeDuration.Text = ""
        txtBidSecurityForm.Text = ""
        txtBankCampany.Text = ""
        txtNumber.Text = ""
        txtValidityPeriod.Text = ""
        txtProjectLocation.Text = ""
        txtBidPlace.Text = ""

        txtBidSecurityAmt.Text = "0.00"
        txtRequiredBidSec.Text = "0.00"
        txtBidAmount.Text = FormatNumber(grdInfaOBR.SelectedDataKey("TotalAmount"), 2)
        txtRemarks.Text = ""

        drpBidders.SelectedIndex = 0
        drpBidders.Enabled = True

        grdBidders.SelectedIndex = -1

        btnAddBidder.Text = "Save"

        If grdBidders.Rows.Count > 0 Then
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub grdBidders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdBidders.SelectedIndexChanged
        Try
            If Session("Action") = "Update" Then
                btnAddBidder.Text = "Update"

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT * FROM AMS.tb_Infra_Dtl WHERE Infra_Dtl_ID = '" & grdBidders.SelectedDataKey("Infra_Dtl_ID") & "'", CommandType.Text)

                txtTimeDuration.Text = dt.Rows(0)("TimeDuration")
                txtBidSecurityForm.Text = dt.Rows(0)("BidSecurity")
                txtBankCampany.Text = dt.Rows(0)("Bank_Campany")
                txtNumber.Text = dt.Rows(0)("Number")
                txtValidityPeriod.Text = dt.Rows(0)("ValidityPeriod")

                txtBidSecurityAmt.Text = FormatNumber(dt.Rows(0)("BidSecurity_Amount"), 2)
                txtRequiredBidSec.Text = FormatNumber(dt.Rows(0)("Required_BidSecurity"), 2)
                txtBidAmount.Text = FormatNumber(dt.Rows(0)("BidAmount"), 2)
                txtRemarks.Text = dt.Rows(0)("Remarks")

                drpBidders.SelectedValue = dt.Rows(0)("Supplier_ID")
                drpBidders.Enabled = False


            ElseIf Session("Action") = "Delete" Then

                objDerived.Execute("DELETE FROM AMS.tb_Infra_Dtl WHERE Infra_Dtl_ID = '" & grdBidders.SelectedDataKey("Infra_Dtl_ID") & "'", CommandType.Text)

                LoadBidders()
                LoadClearfields()

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Bidder has been successfully removed.")

            ElseIf Session("Action") = "Winner" Then

                objDerived.Execute("UPDATE AMS.tb_Infra_Dtl SET isWinner = 0 WHERE Infra_Hdr_ID = '" & grdBidders.SelectedDataKey("Infra_Hdr_ID") & "'", CommandType.Text)
                objDerived.Execute("UPDATE AMS.tb_Infra_Dtl SET isWinner = 1 WHERE Infra_Dtl_ID = '" & grdBidders.SelectedDataKey("Infra_Dtl_ID") & "'", CommandType.Text)


                LoadBidders()
                LoadClearfields()

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Bidder has been successfully declared as winner.")

            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub lnkSelectBidder_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Action") = "Update"
    End Sub

    Protected Sub lnkDeleteBidder_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Action") = "Delete"
    End Sub

    Protected Sub lnkWinnerBidder_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Action") = "Winner"
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If drpEndUser.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select end user signatory.")
        ElseIf txtProjectLocation.Text = "" Or txtBidPlace.Text = "" Or txtBidTime.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "All fields are required.")
        Else

            Dim withWinner As Integer = objDerived.GetValue("SELECT B.Infra_Dtl_ID FROM AMS.tb_Infra_Hdr AS A INNER JOIN AMS.tb_Infra_Dtl AS B ON A.Infra_Hdr_ID = B.Infra_Hdr_ID " &
                                                    " WHERE B.isWinner = 1 AND A.OBR_Hdr_ID = '" & grdInfaOBR.SelectedDataKey("OBR_Hdr_ID") & "'", CommandType.Text)

            If withWinner = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Declare a winner in order to proceed.")
            Else
                Try
                    objDerived.Execute("UPDATE AMS.tb_Infra_Hdr SET isFinal = 1, BACC = " & drpBACC.SelectedItem.Value & ", BACVC = " & drpBACVC.SelectedItem.Value & ", BAC1 = " & drpBAC1.SelectedItem.Value & " " &
                                        " , BAC2 = " & drpBAC2.SelectedItem.Value & ", BAC3 = " & drpBAC3.SelectedItem.Value & ", BAC4 = " & drpBAC4.SelectedItem.Value & ", BAC_TWG = " & drpBAC_TWG.SelectedItem.Value & " " &
                                        " , ProjectLocation = '" & txtProjectLocation.Text & "', BidPlace = '" & txtBidPlace.Text & "', BidTime = '" & txtBidTime.Text & "', BidDate = '" & txtBidDate.Text & "' " &
                                        " , EndUser = " & drpEndUser.SelectedItem.Value & " WHERE OBR_Hdr_ID = '" & grdInfaOBR.SelectedDataKey("OBR_Hdr_ID") & "'", CommandType.Text)

                    Session("Infra_Hdr_ID_Abstract") = objDerived.GetValue("SELECT Infra_Hdr_ID FROM AMS.tb_Infra_Hdr WHERE OBR_Hdr_ID = '" & grdInfaOBR.SelectedDataKey("OBR_Hdr_ID") & "'", CommandType.Text)

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                    btnPreview.Enabled = True

                    dtOBR = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_OBR_ProjectList]", CommandType.Text)
                    grdInfaOBR.DataSource = dtOBR
                    grdInfaOBR.DataBind()

                    grdBidders.DataSource = CreateTable_Bidders(3)
                    grdBidders.DataBind()

                    LoadClearfields()

                    btnSave.Enabled = False
                    btnPreview.Enabled = True

                Catch ex As Exception
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, pls contact system admin.")
                End Try
            End If


        End If

    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Session("Page") = "Abstract"
        Me.Page.Response.Redirect("~/bidding/Bidding_Infra/Infra_Reports.aspx")
    End Sub
End Class
